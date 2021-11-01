'Copyright (c) 2015, ARPDev Pty. Ltd. (arpdev.com)
'All rights reserved.

Namespace CalendarImportServices

    Public Class Data

    End Class
    Public Module VDataUtility
        Public Function EscapedSplit(ByVal sPropertyValue As String, ByVal sToken As String, Optional ByVal sEscapeToken As String = "\") As List(Of String)
            Dim lsUnEscapedSplit As New List(Of String)
            Dim arrFields As String() = Split(sPropertyValue, sToken, -1)
            Dim sValue As String = ""
            Dim iIndex As Integer

            For iIndex = 0 To arrFields.Length - 1
                'If the token end in \, then we should continue appending
                If arrFields(iIndex).EndsWith(sEscapeToken) And (iIndex + 1 < arrFields.Length) Then
                    'We have an incomplete item (prematurely escaped), lets append it to the current value
                    sValue += Mid(arrFields(iIndex), 1, arrFields(iIndex).Length - 1) & ";"
                Else
                    sValue += arrFields(iIndex)
                    lsUnEscapedSplit.Add(sValue)
                    sValue = ""
                End If
            Next
            Return lsUnEscapedSplit
        End Function

        Public Function EscapeDelimitedValue(ByVal sPropertyValue As String, Optional ByVal sDelimiter As String = ";", Optional ByVal EscapedDelimiter As String = "\;") As String
            Return sPropertyValue.Replace(sDelimiter, EscapedDelimiter)
        End Function
    End Module

    Public Class VDataValue
        Sub New()

        End Sub
        Sub New(sValue As String)
            Value = sValue
            Attributes = ""
        End Sub

        Sub New(sValue As String, sAttributes As String)
            Value = sValue
            Attributes = sAttributes
        End Sub

        Public Value As String
        Public Attributes As String
    End Class

    Public Enum ValueMatchType
        LabelOnly = 0
        AttributeMatch = 1
    End Enum

    Public Class VCardNameProperty
        Public Property HonorificPrefixes As String
        Public Property GivenName As String
        Public Property FamilyName As String
        Public Property HonorificSuffixes As String
        Public Property AdditionalNames As String

        Sub New(ByVal sFamilyName As String, ByVal sGivenName As String, Optional ByVal sAdditionalNames As String = "", Optional ByVal sHonorificPrefixes As String = "", Optional ByVal sHonorificSuffixes As String = "")
            HonorificPrefixes = sHonorificPrefixes
            FamilyName = sFamilyName
            GivenName = sGivenName
            HonorificSuffixes = sHonorificSuffixes
            AdditionalNames = sAdditionalNames
        End Sub

        Sub New()

        End Sub

        Sub Load(ByVal sPropertyValue As String)

            ' unescaped rather than doing simple split (since it would break if the values have semicolons in them)

            Dim arrFields As List(Of String) = EscapedSplit(sPropertyValue, ";")
            Try
                FamilyName = arrFields(0)
                GivenName = arrFields(1)
                AdditionalNames = arrFields(2)
                HonorificPrefixes = arrFields(3)
                HonorificSuffixes = arrFields(4)
            Catch ex As Exception
                'This is ok, it presumably means we ran out of fields
            End Try
        End Sub

        Function Serialise() As String
            Return EscapeDelimitedValue(FamilyName) & ";" & EscapeDelimitedValue(GivenName) & ";" & EscapeDelimitedValue(AdditionalNames) & ";" & EscapeDelimitedValue(HonorificPrefixes) & ";" & EscapeDelimitedValue(HonorificSuffixes)
        End Function
    End Class


    Public Class VDataInlineImageProperty
        Private Data As Byte() = Nothing
        Public Property ImageType As String = "JPEG"
        Public Property ImageEncoding As String = "BASE64"

        Sub New()

        End Sub

        Sub New(ByVal FileName As String)
            Load(FileName)
        End Sub

        Function Load(ByVal FileName As String) As Boolean
            Try
                Data = System.IO.File.ReadAllBytes(FileName)
                Load = True
            Catch ex As Exception
                Load = False
            End Try
        End Function

        Function Serialise() As String
            If Not Data Is Nothing Then
                'Note, the boundary qualifier & vbCrLf might need to be added to the end of the item depending on version. We are assuming version 3, which embeds it in tabs, rather than empty boundary
                Serialise = Convert.ToBase64String(Data, Base64FormattingOptions.InsertLineBreaks).Replace(vbCrLf, vbCrLf & vbTab)
            Else
                Serialise = String.Empty
            End If
        End Function
    End Class

    Public Class VCardOrgProperty
        Public Property OrganisationalName As String
        Public Property OrganisationUnit As String

        Sub New(ByVal sOrganisationalName As String, ByVal sOrganisationUnit As String)
            OrganisationalName = sOrganisationalName
            OrganisationUnit = sOrganisationUnit
        End Sub

        Sub New()

        End Sub

        Sub Load(ByVal sPropertyValue As String)
            'Unescape rather than doing simple split (since it will break if the values have semicolons in them)
            Dim arrFields As List(Of String) = EscapedSplit(sPropertyValue, ";")
            Try
                OrganisationalName = arrFields(0)
                OrganisationUnit = arrFields(1)
            Catch ex As Exception
                'This is ok, it presumably means we ran out of fields
            End Try
        End Sub

        Function Serialise() As String
            Return EscapeDelimitedValue(OrganisationalName) & ";" & EscapeDelimitedValue(OrganisationUnit)
        End Function
    End Class


    Public Class VCardAddressProperty
        Public Property PostOfficeBox As String
        Public Property ExtendedAddress As String
        Public Property StreetAddress As String
        Public Property Locality As String
        Public Property Region As String
        Public Property PostCode As String
        Public Property Country As String

        Sub New(ByVal sPostOfficeBox As String, ByVal sExtendedAddress As String, ByVal sStreetAddress As String, ByVal sLocality As String, ByVal sRegion As String, ByVal sPostCode As String, ByVal sCountry As String)
            PostOfficeBox = sPostOfficeBox
            ExtendedAddress = sExtendedAddress
            StreetAddress = sStreetAddress
            Locality = sLocality
            Region = sRegion
            PostCode = sPostCode
            Country = sCountry
        End Sub

        Sub New()

        End Sub

        Sub Load(ByVal sPropertyValue As String)
            'This is unescaped rather than doing simple split (since it will break if the values have semicolons in them)
            Dim arrFields As List(Of String) = EscapedSplit(sPropertyValue, ";", "\")
            Try
                PostOfficeBox = arrFields(0)
                ExtendedAddress = arrFields(1)
                StreetAddress = arrFields(2)
                Locality = arrFields(3)
                Region = arrFields(4)
                PostCode = arrFields(5)
                Country = arrFields(6)
            Catch ex As Exception
                'This is ok, it presumably means we ran out of fields
            End Try
        End Sub

        Function Serialise() As String
            'Values escaped so as to not corrupt semi-colons
            Return EscapeDelimitedValue(PostOfficeBox) & ";" & EscapeDelimitedValue(ExtendedAddress) & ";" & EscapeDelimitedValue(StreetAddress) & ";" & EscapeDelimitedValue(Locality) & ";" & EscapeDelimitedValue(Region) & ";" & EscapeDelimitedValue(PostCode) & ";" & EscapeDelimitedValue(Country)
        End Function
    End Class



    Public Class VDataSection
        Public Name As String

        Sub New(ByVal sLabel As String)
            Name = sLabel
        End Sub

        Private Values As New List(Of KeyValuePair(Of String, VDataValue))
        Private Sections As New List(Of KeyValuePair(Of String, VDataSection))


        Function AddSection(ByVal sLabel As String) As VDataSection
            Dim oNewSection As New VDataSection(sLabel)
            Sections.Add(New KeyValuePair(Of String, VDataSection)(sLabel, oNewSection))
            Return oNewSection
        End Function

        Sub AddValue(ByVal sLabel As String, ByVal vdValue As VDataValue)
            Values.Add(New KeyValuePair(Of String, VDataValue)(sLabel, vdValue))
        End Sub

        Sub AddValue(ByVal sLabel As String, ByVal sValue As String)
            'We want to check the label value for a semi colon to extract the delimiters

            Dim arrLabelAttributes As String() = sLabel.Split(";", 2, StringSplitOptions.RemoveEmptyEntries)
            If arrLabelAttributes.Length <= 1 Then
                Values.Add(New KeyValuePair(Of String, VDataValue)(sLabel, New VDataValue(sValue)))
            Else
                Values.Add(New KeyValuePair(Of String, VDataValue)(arrLabelAttributes(0), New VDataValue(sValue, arrLabelAttributes(1))))
            End If

        End Sub
        Sub AddValue(ByVal sLabel As String, ByVal NameValue As VCardNameProperty, Optional ByVal sAttributes As String = "")
            AddValue(sLabel, New VDataValue(NameValue.Serialise(), sAttributes))
        End Sub
        Sub AddValue(ByVal sLabel As String, ByVal sValue As String, sAttributes As String)
            AddValue(sLabel, New VDataValue(sValue, sAttributes))
        End Sub

        Sub AppendToLastValue(ByVal sData As String)
            Dim ExistingValue As KeyValuePair(Of String, VDataValue) = Values.Last
            Values.Remove(Values.Last)
            Dim NewValue As New KeyValuePair(Of String, VDataValue)(ExistingValue.Key, New VDataValue(ExistingValue.Value.Value & sData))
            Values.Add(NewValue)
        End Sub

        Sub RemoveValue(ByVal sLabel As String, ByVal sAttributeStringMatch As String)
            '
            ' TODO: In a production implementation, the function really should split the attribute string math into it's elements to facilitate accurate matching
            '
            If Not String.IsNullOrEmpty(sAttributeStringMatch) Then
                sAttributeStringMatch = sAttributeStringMatch.ToUpper() ' For Comparison
            End If
            Values.RemoveAll(Function(item As KeyValuePair(Of String, VDataValue)) (item.Key.Equals(sLabel) And (String.IsNullOrEmpty(sAttributeStringMatch) Or item.Value.Attributes.ToUpper().Contains(sAttributeStringMatch))))
        End Sub


        Sub SetValue(ByVal sLabelQualifier As String, ByVal sValue As String, Optional ByVal sAttributes As String = "")
            Dim arrSectionLabels() As String = Split(sLabelQualifier, ".")
            Dim CurrentSection As VDataSection = Me
            Dim iIndex As Integer = 0

            'The last item in the section label is the value name 
            For iIndex = 0 To arrSectionLabels.Length - 2
                Dim Result As List(Of KeyValuePair(Of String, VDataSection)) = CurrentSection.Sections.FindAll(Function(item As KeyValuePair(Of String, VDataSection)) (item.Key.Equals(arrSectionLabels(iIndex))))
                If Result.Count > 0 Then
                    'We found the section, 
                    CurrentSection = Result.First().Value
                Else
                    'Section not found; we should add it
                    CurrentSection = CurrentSection.AddSection(arrSectionLabels(iIndex))
                End If
            Next
            'Finds the section, and sets the value (we will remove any existing one first)
            CurrentSection.RemoveValue(arrSectionLabels.Last(), sAttributes)
            CurrentSection.AddValue(arrSectionLabels.Last(), sValue)
        End Sub


        Sub SetValue(ByVal sLabelQualifier As String, ByVal vdValue As VDataValue, Optional ByVal vMatchType As ValueMatchType = ValueMatchType.LabelOnly)
            Dim arrSectionLabels() As String = Split(sLabelQualifier, ".")
            Dim CurrentSection As VDataSection = Me
            Dim iIndex As Integer = 0

            'The last item in the section label is the value name 
            For iIndex = 0 To arrSectionLabels.Length - 2
                Dim Result As List(Of KeyValuePair(Of String, VDataSection)) = CurrentSection.Sections.FindAll(Function(item As KeyValuePair(Of String, VDataSection)) (item.Key.Equals(arrSectionLabels(iIndex))))
                If Result.Count > 0 Then
                    'We found the section, we can now find the value 
                    CurrentSection = Result.First().Value
                Else
                    'Section not found. we should add it
                    CurrentSection = CurrentSection.AddSection(arrSectionLabels(iIndex))
                End If
            Next
            'Finds the section, and sets the value (we will remove any existing one first)
            If vMatchType = ValueMatchType.LabelOnly Then
                CurrentSection.RemoveValue(arrSectionLabels.Last(), "")
            Else
                CurrentSection.RemoveValue(arrSectionLabels.Last(), vdValue.Attributes)
            End If
            CurrentSection.AddValue(arrSectionLabels.Last(), vdValue)
        End Sub

        Function GetValue(ByVal sLabel As String, Optional ByVal vMatchType As ValueMatchType = ValueMatchType.LabelOnly, Optional ByVal sAttributeStringMatch As String = Nothing) As VDataValue
            '
            ' TODO: In an idealistic implementation, the function really should split the attribute string math into it's elements to facilitate accurate matching
            '
            GetValue = Nothing
            If vMatchType = ValueMatchType.AttributeMatch Then
                If Not String.IsNullOrEmpty(sAttributeStringMatch) Then
                    sAttributeStringMatch = sAttributeStringMatch.ToUpper() ' For Comparison
                End If
            End If

            Dim arrSectionLabels() As String = Split(sLabel, ".")
            Dim iIndex As Integer = 0
            If arrSectionLabels.Count > 1 Then
                'We need to look for the section to find the value
                'The last item in the section label is the value name (yes the -2 looks obscure, but it is there because the last item is a value name, not a section name)
                Dim CurrentSection As VDataSection = Me
                For iIndex = 0 To arrSectionLabels.Length - 2
                    Dim Result As List(Of KeyValuePair(Of String, VDataSection)) = CurrentSection.Sections.FindAll(Function(item As KeyValuePair(Of String, VDataSection)) (item.Key.Equals(arrSectionLabels(iIndex))))
                    If Result.Count > 0 Then
                        'We found the section, now look for the item
                        Try
                            Dim Target As KeyValuePair(Of String, VDataValue) = Result.First().Value.Values.Find(Function(item As KeyValuePair(Of String, VDataValue)) (item.Key.Equals(arrSectionLabels.Last()) And (vMatchType = ValueMatchType.LabelOnly Or (vMatchType = ValueMatchType.AttributeMatch AndAlso item.Value.Attributes.ToUpper().Contains(sAttributeStringMatch)))))
                            GetValue = Target.Value

                        Catch ex As Exception
                            Debug.Assert(False, ex.Message)
                        End Try
                        Exit For
                    Else
                        Exit For
                    End If
                Next
            Else
                Dim Target As KeyValuePair(Of String, VDataValue) = Me.Values.Find(Function(item As KeyValuePair(Of String, VDataValue)) (item.Key.Equals(arrSectionLabels.Last()) And (vMatchType = ValueMatchType.LabelOnly Or (vMatchType = ValueMatchType.AttributeMatch AndAlso item.Value.Attributes.ToUpper().Contains(sAttributeStringMatch)))))
                GetValue = Target.Value
            End If
        End Function

        Function GetStringValue(ByVal sLabel As String, Optional ByVal vMatchType As ValueMatchType = ValueMatchType.LabelOnly, Optional ByVal sAttributeStringMatch As String = Nothing) As String
            GetStringValue = ""
            Dim vdv As VDataValue = GetValue(sLabel, vMatchType, sAttributeStringMatch)
            If (Not vdv Is Nothing) AndAlso (Not String.IsNullOrEmpty(vdv.Value)) Then
                GetStringValue = vdv.Value
            End If
        End Function


        Function Serialise() As String
            Dim sResult As String = ""

            sResult += "BEGIN:" & Me.Name & vbCrLf
            For Each oValue As KeyValuePair(Of String, VDataValue) In Values
                sResult += oValue.Key
                If Not String.IsNullOrEmpty(oValue.Value.Attributes) Then
                    'Write out attributes if we have them
                    sResult += ";" & oValue.Value.Attributes
                End If
                sResult += ":" & oValue.Value.Value & vbCrLf
            Next
            For Each oSection In Sections
                sResult += oSection.Value.Serialise()
            Next
            sResult += "END:" & Me.Name & vbCrLf
            Return sResult
        End Function

        Sub LoadSection(ByRef CurrentSection As VDataSection, ByRef arrLines() As String, ByRef CurrentIndex As Integer)
            While CurrentIndex < arrLines.Length - 1
                Dim arrLine() As String = Split(arrLines(CurrentIndex), ":", 2)
                If arrLine(0) = "BEGIN" Then
                    Dim NewSection As VDataSection = CurrentSection.AddSection(arrLine(1))
                    CurrentIndex += 1
                    LoadSection(NewSection, arrLines, CurrentIndex)
                ElseIf arrLine(0) = "END" Then
                    Exit While
                Else
                    'It is a value, so we should add it to the list
                    If (arrLines(CurrentIndex).StartsWith(" ")) Or (arrLines(CurrentIndex).StartsWith(vbTab)) Then
                        'It is an extension of an existing property (which has been folded), so lets append to the last one
                        CurrentSection.AppendToLastValue(Mid(arrLines(CurrentIndex), 1))
                    Else
                        CurrentSection.AddValue(arrLine(0), arrLine(1))
                    End If
                End If
                CurrentIndex += 1
            End While
        End Sub


        Sub Load(sData As String)
            'Normalise it first (since some systems delimit fields by \n rather than \r\n)
            sData = sData.Replace(vbCr, "")
            sData = sData.Replace(vbLf, vbCrLf)
            'Split the data into lines
            Dim arrLines() As String = Split(sData, vbCrLf)
            'Now split the values according to delimiter
            For CurrentIndex = 0 To arrLines.Length - 1
                Dim arrLine() As String = Split(arrLines(CurrentIndex), ":", 2)
                If arrLine(0) = "BEGIN" Then
                    'It is a new section, we call loadData for that section
                    Me.Name = arrLine(1)
                    CurrentIndex += 1
                    LoadSection(Me, arrLines, CurrentIndex)
                Else
                    If Not String.IsNullOrEmpty(arrLine(0)) Then
                        Debug.Print("Obscure Data: " & arrLine(0))
                        Debug.Assert(False, "Something is obscure with the format of sData; not fatal, but suspicious")
                    End If
                End If
            Next
        End Sub
    End Class


    Public Class VCalendar
        Inherits VDataSection
        Sub New()
            MyBase.New("VCALENDAR")
        End Sub


        Function GetItemId() As String
            Return Guid.NewGuid().ToString & ".ics"
        End Function
    End Class


    Public Class VCard
        Inherits VDataSection


        Sub New()
            MyBase.New("VCARD")
        End Sub

        Sub New(ByVal FirstName As String, ByVal Surname As String, Optional ByVal Company As String = "", Optional ByVal EMailAddress As String = "")
            MyBase.New("VCARD")
            Me.AddValue("VERSION", "3.0")
            Me.AddValue("UID", Guid.NewGuid().ToString)
            Me.AddValue("N", New VCardNameProperty(Surname, FirstName, "").Serialise())
            Me.AddValue("ORG", New VCardOrgProperty(Company, "").Serialise())
            Me.AddValue("EMAIL", EMailAddress, "TYPE=PREF,INTERNET")
        End Sub

        Function GetItemId() As String
            Return Guid.NewGuid().ToString & ".vcf"
        End Function
    End Class

End Namespace