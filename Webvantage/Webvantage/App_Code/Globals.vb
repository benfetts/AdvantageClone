Imports System.Data
Imports System
Imports System.Configuration
Imports System.IO
Imports System.Web.Mail
Imports System.Text
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports Webvantage.cGlobals
Imports Webvantage.cGlobals.Globals
Imports MailBee.SmtpMail

Public Enum MsgBoxIcon
    Information = 1
    SystemError = 2
    Warning = 3
End Enum
Namespace cGlobals

    '*********************************************************************
    '
    ' Globals Module
    ' This module contains global utility functions, constants, and enumerations.
    '
    '*********************************************************************
    Public Module Globals
        ' returns the absolute server path to the root ( ie. D:\Inetpub\wwwroot\directory\ )
        Public Function GetAbsoluteServerPath(ByVal Request As HttpRequest) As String
            Dim strServerPath As String

            strServerPath = Request.MapPath(Request.ApplicationPath)
            If Not strServerPath.EndsWith("\") Then
                strServerPath += "\"
            End If

            GetAbsoluteServerPath = strServerPath
        End Function
        ' returns the domain name of the current request ( ie. www.domain.com or 207.132.12.123 or www.domain.com/directory if subhost )
        Public Function GetDomainName(ByVal Request As HttpRequest) As String
            Dim DomainName As StringBuilder = New StringBuilder
            Dim URL() As String
            Dim intURL As Integer

            URL = Split(Request.Url.ToString(), "/")
            For intURL = 2 To URL.GetUpperBound(0)
                Select Case URL(intURL).ToLower
                    Case "admin", "controls", "desktopmodules", "mobilemodules", "premiummodules"
                        Exit For
                    Case Else
                        ' check if filename
                        If InStr(1, URL(intURL), ".aspx") = 0 And InStr(1, URL(intURL), ".axd") = 0 Then
                            DomainName.Append(IIf(DomainName.ToString() <> "", "/", "").ToString() & URL(intURL))
                        Else
                            Exit For
                        End If
                End Select
            Next intURL

            Return DomainName.ToString
        End Function

        ' adds HTTP to URL if no other protocol specified
        Public Function AddHTTP(ByVal strURL As String) As String
            If strURL <> "" Then
                If InStr(1, strURL, "://") = 0 And InStr(1, strURL, "~") = 0 And InStr(1, strURL, "\\") = 0 Then
                    If HttpContext.Current.Request.IsSecureConnection Then
                        strURL = "https://" & strURL
                    Else
                        strURL = "http://" & strURL
                    End If
                End If
            End If
            Return strURL
        End Function
        ' convert datareader to dataset
        Public Function ConvertDataReaderToDataSet(ByVal reader As IDataReader) As DataSet

            ' add datatable to dataset
            Dim objDataSet As New DataSet
            objDataSet.Tables.Add(ConvertDataReaderToDataTable(reader))

            Return objDataSet

        End Function
        ' convert datareader to dataset
        Public Function ConvertDataReaderToDataTable(ByVal reader As IDataReader) As DataTable

            ' create datatable from datareader
            Dim objDataTable As New DataTable
            Dim intFieldCount As Integer = reader.FieldCount
            Dim intCounter As Integer
            For intCounter = 0 To intFieldCount - 1
                objDataTable.Columns.Add(reader.GetName(intCounter), reader.GetFieldType(intCounter))
            Next intCounter

            ' populate datatable
            objDataTable.BeginLoadData()
            Dim objValues(intFieldCount - 1) As Object
            While reader.Read()
                reader.GetValues(objValues)
                objDataTable.LoadDataRow(objValues, True)
            End While
            reader.Close()
            objDataTable.EndLoadData()

            Return objDataTable

        End Function
        ' convert datareader to crosstab dataset
        Public Function BuildCrossTabDataSet(ByVal DataSetName As String, ByVal result As IDataReader, ByVal FixedColumns As String, ByVal VariableColumns As String, ByVal KeyColumn As String, ByVal FieldColumn As String, ByVal FieldTypeColumn As String, ByVal StringValueColumn As String, ByVal NumericValueColumn As String) As DataSet

            Dim arrFixedColumns As String()
            Dim arrVariableColumns As String()
            Dim arrField As String()
            Dim FieldName As String
            Dim FieldType As String
            Dim intColumn As Integer
            Dim intKeyColumn As Integer

            ' create dataset
            Dim crosstab As New DataSet(DataSetName)
            crosstab.Namespace = "NetFrameWork"

            ' create table
            Dim tab As New DataTable(DataSetName)

            ' split fixed columns
            arrFixedColumns = FixedColumns.Split(",".ToCharArray())

            ' add fixed columns to table
            For intColumn = LBound(arrFixedColumns) To UBound(arrFixedColumns)
                arrField = arrFixedColumns(intColumn).Split("|".ToCharArray())
                Dim col As New DataColumn(arrField(0), System.Type.GetType("System." & arrField(1)))
                tab.Columns.Add(col)
            Next intColumn

            ' split variable columns
            If VariableColumns <> "" Then
                arrVariableColumns = VariableColumns.Split(",".ToCharArray())

                ' add varible columns to table
                For intColumn = LBound(arrVariableColumns) To UBound(arrVariableColumns)
                    arrField = arrVariableColumns(intColumn).Split("|".ToCharArray())
                    Dim col As New DataColumn(arrField(0), System.Type.GetType("System." & arrField(1)))
                    col.AllowDBNull = True
                    tab.Columns.Add(col)
                Next intColumn
            End If

            ' add table to dataset
            crosstab.Tables.Add(tab)

            ' add rows to table
            intKeyColumn = -1
            Dim row As DataRow
            While result.Read()
                ' loop using KeyColumn as control break
                If Convert.ToInt32(result(KeyColumn)) <> intKeyColumn Then
                    ' add row
                    If intKeyColumn <> -1 Then
                        tab.Rows.Add(row)
                    End If

                    ' create new row
                    row = tab.NewRow()

                    ' assign fixed column values
                    For intColumn = LBound(arrFixedColumns) To UBound(arrFixedColumns)
                        arrField = arrFixedColumns(intColumn).Split("|".ToCharArray())
                        row(arrField(0)) = result(arrField(0))
                    Next intColumn

                    ' initialize variable column values
                    If VariableColumns <> "" Then
                        For intColumn = LBound(arrVariableColumns) To UBound(arrVariableColumns)
                            arrField = arrVariableColumns(intColumn).Split("|".ToCharArray())
                            Select Case arrField(1)
                                Case "Decimal"
                                    row(arrField(0)) = 0
                                Case "String"
                                    row(arrField(0)) = ""
                            End Select
                        Next intColumn
                    End If

                    intKeyColumn = Convert.ToInt32(result(KeyColumn))
                End If

                ' assign pivot column value
                If FieldTypeColumn <> "" Then
                    FieldType = result(FieldTypeColumn).ToString
                Else
                    FieldType = "String"
                End If
                Select Case FieldType
                    Case "Decimal" ' decimal
                        row(Convert.ToInt32(result(FieldColumn))) = result(NumericValueColumn)
                    Case "String" ' string
                        row(result(FieldColumn).ToString()) = result(StringValueColumn)
                End Select
            End While

            result.Close()

            ' add row
            If intKeyColumn <> -1 Then
                tab.Rows.Add(row)
            End If

            ' finalize dataset
            crosstab.AcceptChanges()

            ' return the dataset
            Return crosstab

        End Function
        ' format an address on a single line ( ie. Unit, Street, City, Region, Country, PostalCode )
        Public Function FormatAddress(ByVal Unit As Object, ByVal Street As Object, ByVal City As Object, ByVal Region As Object, ByVal Country As Object, ByVal PostalCode As Object) As String

            Dim strAddress As String = ""

            If Not Unit Is Nothing Then
                If Trim(Unit.ToString()) <> "" Then
                    strAddress += ", " & Unit.ToString
                End If
            End If
            If Not Street Is Nothing Then
                If Trim(Street.ToString()) <> "" Then
                    strAddress += ", " & Street.ToString
                End If
            End If
            If Not City Is Nothing Then
                If Trim(City.ToString()) <> "" Then
                    strAddress += ", " & City.ToString
                End If
            End If
            If Not Region Is Nothing Then
                If Trim(Region.ToString()) <> "" Then
                    strAddress += ", " & Region.ToString
                End If
            End If
            If Not Country Is Nothing Then
                If Trim(Country.ToString()) <> "" Then
                    strAddress += ", " & Country.ToString
                End If
            End If
            If Not PostalCode Is Nothing Then
                If Trim(PostalCode.ToString()) <> "" Then
                    strAddress += ", " & PostalCode.ToString
                End If
            End If
            If Trim(strAddress) <> "" Then
                strAddress = Mid(strAddress, 3)
            End If

            FormatAddress = strAddress

        End Function
        ' format an email address including link
        Public Function FormatEmail(ByVal Email As Object) As String

            If Not IsDBNull(Email) Then
                If Trim(Email.ToString()) <> "" Then
                    If Email.ToString.IndexOf("@") <> -1 Then
                        FormatEmail = "<a href=""mailto:" & Email.ToString() & """>" & Email.ToString() & "</a>"
                    Else
                        FormatEmail = Email.ToString()
                    End If
                End If
            End If

            Return FormatEmail

        End Function
        ' format a domain name including link
        Public Function FormatWebsite(ByVal Website As Object) As String

            If Not IsDBNull(Website) Then
                If Trim(Website.ToString()) <> "" Then
                    If Convert.ToBoolean(InStr(1, Website.ToString(), ".")) Then
                        FormatWebsite = "<a href=""" & IIf(Convert.ToBoolean(InStr(1, Website.ToString(), "://")), "", "http://").ToString() & Website.ToString() & """>" & Website.ToString() & "</a>"
                    Else
                        FormatWebsite = Website.ToString()
                    End If
                End If
            End If

        End Function
        ' injects the upload directory into raw HTML for src and background tags
        Public Function ManageUploadDirectory(ByVal strHTML As String, ByVal strUploadDirectory As String) As String

            Dim P As Integer

            ManageUploadDirectory = ""

            If strHTML <> "" Then
                P = InStr(1, strHTML.ToLower, "src=""")
                While P <> 0
                    ManageUploadDirectory = ManageUploadDirectory & Left(strHTML, P + 4)

                    strHTML = Mid(strHTML, P + 5)

                    ' add uploaddirectory if we are linking internally
                    If InStr(1, strHTML, "://") = 0 Then
                        strHTML = strUploadDirectory & strHTML
                    End If

                    P = InStr(1, strHTML.ToLower, "src=""")
                End While
                ManageUploadDirectory = ManageUploadDirectory & strHTML

                strHTML = ManageUploadDirectory
                ManageUploadDirectory = ""

                P = InStr(1, strHTML.ToLower, "background=""")
                While P <> 0
                    ManageUploadDirectory = ManageUploadDirectory & Left(strHTML, P + 11)

                    strHTML = Mid(strHTML, P + 12)

                    ' add uploaddirectory if we are linking internally
                    If InStr(1, strHTML, "://") = 0 Then
                        strHTML = strUploadDirectory & strHTML
                    End If

                    P = InStr(1, strHTML.ToLower, "background=""")
                End While
            End If

            ManageUploadDirectory = ManageUploadDirectory & strHTML

        End Function
        ' uses recursion to search the control hierarchy for a specific control based on controlname
        Public Function FindControlRecursive(ByVal objControl As System.Web.UI.Control, ByVal strControlName As String) As System.Web.UI.Control
            If objControl.Parent Is Nothing Then
                Return Nothing
            Else
                If Not objControl.Parent.FindControl(strControlName) Is Nothing Then
                    Return objControl.Parent.FindControl(strControlName)
                Else
                    Return FindControlRecursive(objControl.Parent, strControlName)
                End If
            End If
        End Function
        'set focus to any control
        Public Sub SetFormFocus(ByVal control As System.Web.UI.Control)
            If Not control.Page Is Nothing And control.Visible Then
                If control.Page.Request.Browser.JavaScript = True Then

                    ' Create JavaScript 
                    Dim sb As New System.Text.StringBuilder
                    sb.Append("<SCRIPT LANGUAGE='JavaScript'>")
                    sb.Append("<!--")
                    sb.Append(ControlChars.Lf)
                    sb.Append("function SetInitialFocus() {")
                    sb.Append(ControlChars.Lf)
                    sb.Append(" document.")

                    ' Find the Form 
                    Dim objParent As System.Web.UI.Control = control.Parent
                    While Not TypeOf objParent Is System.Web.UI.HtmlControls.HtmlForm
                        objParent = objParent.Parent
                    End While
                    sb.Append(objParent.ClientID)
                    sb.Append("['")
                    sb.Append(control.UniqueID)
                    sb.Append("'].focus(); }")
                    sb.Append("window.onload = SetInitialFocus;")
                    sb.Append(ControlChars.Lf)
                    sb.Append("// -->")
                    sb.Append(ControlChars.Lf)
                    sb.Append("</SCRIPT>")

                    ' Register Client Script 
                    control.Page.RegisterClientScriptBlock("InitialFocus", sb.ToString())
                End If
            End If
        End Sub
        Public Sub DeleteFolderRecursive(ByVal strRoot As String)
            If strRoot <> "" Then
                Dim strFolder As String
                If Directory.Exists(strRoot) Then
                    For Each strFolder In Directory.GetDirectories(strRoot)
                        DeleteFolderRecursive(strFolder)
                    Next
                    Dim strFile As String
                    For Each strFile In Directory.GetFiles(strRoot)
                        File.SetAttributes(strFile, FileAttributes.Normal)
                        File.Delete(strFile)
                    Next
                    Directory.Delete(strRoot)
                End If
            End If
        End Sub
        Public Function CreateValidID(ByVal strID As String) As String

            Dim strBadCharacters As String = " ./-\"

            Dim intIndex As Integer
            For intIndex = 0 To strBadCharacters.Length - 1
                strID = strID.Replace(strBadCharacters.Substring(intIndex, 1), "_")
            Next

            Return strID

        End Function
        Public Function ValidSessionID(ByVal UserCode As String, ByVal ConnString As String) As Boolean
            If UserCode <> "" Then
                Try
                    Dim oSecurity As cSecurity = New cSecurity(ConnString)
                Catch ex As Exception
                    Return False
                End Try
            End If
        End Function
        'Private IsUsingTrustedConn As Boolean = False
        'Private NTAuthUserIgnoreCase As Boolean = False
        'Public Function ValidSessionID(ByVal SessionID As String, ByVal UserCode As String, ByVal ConnectionString As String) As Boolean
        '    If SessionID <> "" And UserCode <> "" Then
        '        Dim strAuthentication As String = System.Configuration.ConfigurationManager.AppSettings("Authentication")
        '        If strAuthentication = "Forms" Then
        '            IsUsingTrustedConn = False
        '        Else
        '            IsUsingTrustedConn = True
        '        End If
        '        Try
        '            If IsUsingTrustedConn = True Then
        '                NTAuthUserIgnoreCase = CType(System.Configuration.ConfigurationManager.AppSettings("NTAuthIgnoreCase").ToString(), Boolean)
        '            End If
        '        Catch ex As Exception
        '            NTAuthUserIgnoreCase = False
        '        End Try

        '        Dim oSecurity As cSecurity = New cSecurity(ConnectionString)
        '        Try

        '            If oSecurity.GetWebID(UserCode, NTAuthUserIgnoreCase).Trim() <> SessionID Then
        '                Return False
        '            Else
        '                Return True
        '            End If

        '        Catch
        '            Return False
        '        End Try
        '    Else
        '        Return False
        '    End If

        '    'Return True
        'End Function
        Public Sub DisableButton(ByVal btn As System.Web.UI.WebControls.Button)
            ' 1- On PageLoad add: 
            ' DisableButton(Button1) 
            ' 
            ' 2- On Button1_Click add: 
            ' Threading.Thread.Sleep(1000) 
            ' 
            ' 3- On Button1 Properties set: 
            ' CauseVaidation to false 

            Dim sJavaScript As String

            sJavaScript += "if (typeof(Page_ClientValidate) == 'function') "
            sJavaScript += "{ if (Page_ClientValidate() == false) "
            sJavaScript += "{ return false; }"
            sJavaScript += "} this.value = 'Please wait...';"
            sJavaScript += "this.disabled = true;"
            sJavaScript += btn.Page.GetPostBackEventReference(btn) & ";"

            btn.Attributes.Add("onclick", sJavaScript)
        End Sub
        Public Function Encrypt(ByVal strKey As String, ByVal strData As String) As String

            Dim strValue As String = ""

            If strKey <> "" Then
                ' convert key to 16 characters for simplicity
                Select Case Len(strKey)
                    Case Is < 16
                        strKey = strKey & Left("zxywaqpoieucxsakx", 16 - Len(strKey))
                    Case Is > 16
                        strKey = Left(strKey, 16)
                End Select

                ' create encryption keys
                Dim byteKey() As Byte = Encoding.UTF8.GetBytes(Left(strKey, 8))
                Dim byteVector() As Byte = Encoding.UTF8.GetBytes(Right(strKey, 8))

                ' convert data to byte array
                Dim byteData() As Byte = Encoding.UTF8.GetBytes(strData)

                ' encrypt 
                Dim objDES As New DESCryptoServiceProvider
                Dim objMemoryStream As New MemoryStream
                Dim objCryptoStream As New CryptoStream(objMemoryStream, objDES.CreateEncryptor(byteKey, byteVector), CryptoStreamMode.Write)
                objCryptoStream.Write(byteData, 0, byteData.Length)
                objCryptoStream.FlushFinalBlock()

                ' convert to string and Base64 encode
                strValue = Convert.ToBase64String(objMemoryStream.ToArray())
                strValue = strValue.Replace("/", "SlashReplace")
                strValue = strValue.Replace("+", "PlusReplace")
                strValue = strValue.Replace("=", "EqualReplace")
                'strValue = Convert.ToString(objMemoryStream.ToArray())
            Else
                strValue = strData
            End If

            Return strValue

        End Function
        Public Function Encrypt(ByVal strData As String) As String
            Return Encrypt("XXIS99AL01ET05XX", strData)
        End Function
        Public Function Decrypt(ByVal strKey As String, ByVal strData As String) As String

            Dim strValue As String = ""

            If strKey <> "" Then
                ' convert key to 16 characters for simplicity
                Select Case Len(strKey)
                    Case Is < 16
                        strKey = strKey & Left("zxywaqpoieucxsakx", 16 - Len(strKey))
                    Case Is > 16
                        strKey = Left(strKey, 16)
                End Select

                strData = strData.Replace("SlashReplace", "/")
                strData = strData.Replace("PlusReplace", "+")
                strData = strData.Replace("EqualReplace", "=")

                ' create encryption keys
                Dim byteKey() As Byte = Encoding.UTF8.GetBytes(Left(strKey, 8))
                Dim byteVector() As Byte = Encoding.UTF8.GetBytes(Right(strKey, 8))

                ' convert data to byte array and Base64 decode
                Dim byteData(strData.Length) As Byte
                Try
                    byteData = Convert.FromBase64String(strData)
                Catch ' invalid length
                    strValue = strData
                End Try

                If strValue = "" Then
                    Try
                        ' decrypt
                        Dim objDES As New DESCryptoServiceProvider
                        Dim objMemoryStream As New MemoryStream
                        Dim objCryptoStream As New CryptoStream(objMemoryStream, objDES.CreateDecryptor(byteKey, byteVector), CryptoStreamMode.Write)
                        objCryptoStream.Write(byteData, 0, byteData.Length)
                        objCryptoStream.FlushFinalBlock()

                        ' convert to string
                        Dim objEncoding As System.Text.Encoding = System.Text.Encoding.UTF8
                        strValue = objEncoding.GetString(objMemoryStream.ToArray())
                    Catch ' decryption error
                        strValue = ""
                    End Try
                End If
            Else
                strValue = strData
            End If

            Return strValue

        End Function
        Public Function Decrypt(ByVal strData As String) As String
            Return Decrypt("XXIS99AL01ET05XX", strData)
        End Function
        Public Sub SortListBox(ByRef ThisListBox As Telerik.Web.UI.RadListBox)
            Dim I As Integer
            Dim ThisItem As Telerik.Web.UI.RadListBoxItem
            Dim sl As New System.Collections.SortedList
            Dim de As DictionaryEntry

            For I = ThisListBox.Items.Count - 1 To 0 Step -1
                sl.Add(ThisListBox.Items(I).Text, ThisListBox.Items(I).Value)
                ThisListBox.Items.Remove(ThisListBox.Items(I))
            Next I

            For Each de In sl
                ThisItem = New Telerik.Web.UI.RadListBoxItem
                ThisItem.Value = de.Value
                ThisItem.Text = de.Key
                ThisListBox.Items.Add(ThisItem)
            Next

        End Sub


        Public Function wvIsDate(ByVal strDate As String, Optional ByVal ForceEnglish As Boolean = False) As Boolean
            ' Dim s As String = System.Globalization.CultureInfo.CurrentCulture.DisplayName
            Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(LoGlo.UserCultureGet())

            If LoGlo.IsEnglish = True Or ForceEnglish = True Then
                Try
                    If strDate.Trim = "" Then
                        Return False
                    End If

                    strDate = Replace(strDate, "-", "/")
                    strDate = Replace(strDate, ".", "/")

                    If IsDate(strDate) = False Then
                        If strDate.IndexOf("/") < 1 And strDate.Length >= 4 Then
                            strDate = strDate.Substring(0, 2) & "/" & strDate.Substring(2, 2) & "/" & strDate.Substring(4)
                        End If
                    End If

                    Dim d As Date
                    Date.TryParse(strDate, d)
                    Dim mind As Date = CDate("01/01/1900")
                    Dim maxd As Date = CDate("6/6/2079")

                    If d < mind Or d > maxd Then
                        Return False
                    End If

                    Return IsDate(strDate)

                Catch ex As Exception
                    Return False
                End Try
            Else 'we are using a foreign locale
                '
                'System.Globalization.CultureInfo.CurrentCulture.
                Try
                    If IsDate(strDate) = False Then
                        LoGlo.FormatDateTime(strDate)
                        Return IsDate(strDate)
                    Else
                        Return True
                    End If
                Catch ex As Exception
                    Return False
                End Try
            End If
        End Function

        Public Function wvCDate(ByVal strDate As String, Optional ByVal ForceEnglish As Boolean = False) As Date
            Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(LoGlo.UserCultureGet())
            If LoGlo.IsEnglish = True Or ForceEnglish = True Then
                Try
                    'If wvIsDate(strDate) = True Then
                    strDate = Replace(strDate, "-", "/")
                    strDate = Replace(strDate, ".", "/")
                    If strDate.IndexOf("/") < 1 And strDate.Length >= 4 Then
                        strDate = strDate.Substring(0, 2) & "/" & strDate.Substring(2, 2) & "/" & strDate.Substring(4)
                    End If
                    If IsDate(strDate) = True Then
                        Return CDate(strDate)
                    Else
                        Err.Raise(9999, "Not a valid date")
                    End If
                    'End If
                Catch ex As Exception
                    Return Now
                End Try
            Else
                Try
                    Return CDate(strDate)
                Catch ex As Exception
                    Return Now
                End Try
            End If
        End Function


        Public Sub CallJavaScript(ByRef aspxPage As System.Web.UI.Page, ByVal pScript As String, ByVal strKey As String)
            Dim strScript As String
            strScript = "<script type=""text/javascript"">"
            strScript &= pScript & "</script>"
            If (Not aspxPage.IsStartupScriptRegistered(strKey)) Then
                aspxPage.RegisterStartupScript(strKey, strScript)
            End If
        End Sub

    End Module

End Namespace
