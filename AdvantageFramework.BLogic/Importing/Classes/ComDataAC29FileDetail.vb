Namespace Importing.Classes

    Public Class ComDataAC29FileDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Line1001
            Line1002
            Line1003
            Line1004
            Line1005
            Line1006
            Line2006
            Line1007
            Line1008
            Line1009
            Line1010
            Line1011
            Line1012
            Line1014
            Line1015
            Line1016
            Line1017
            Line1018
            Line1019
            Line1020
            Line1021
            Line1022
            FileDetailLines
            ComDataAC29File
        End Enum

#End Region

#Region " Variables "

        Private _Line1001 As String = ""
        Private _Line1002 As String = ""
        Private _Line1003 As String = ""
        Private _Line1004 As String = ""
        Private _Line1005 As String = ""
        Private _Line1006 As String = ""
        Private _Line2006 As String = ""
        Private _Line1007 As String = ""
        Private _Line1008 As String = ""
        Private _Line1009 As String = ""
        Private _Line1010 As String = ""
        Private _Line1011 As String = ""
        Private _Line1012 As String = ""
        Private _Line1014 As String = ""
        Private _Line1015 As String = ""
        Private _Line1016 As String = ""
        Private _Line1017 As String = ""
        Private _Line1018 As String = ""
        Private _Line1019 As String = ""
        Private _Line1020 As String = ""
        Private _Line1021 As String = ""
        Private _Line1022 As String = ""
        Private _FileDetailLines As Generic.List(Of String) = Nothing
        Private _ComDataAC29File As ComDataAC29File = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property Line1001() As String
            Get
                Line1001 = _Line1001
            End Get
        End Property
        Public ReadOnly Property Line1002() As String
            Get
                Line1002 = _Line1002
            End Get
        End Property
        Public ReadOnly Property Line1003() As String
            Get
                Line1003 = _Line1003
            End Get
        End Property
        Public ReadOnly Property Line1004() As String
            Get
                Line1004 = _Line1004
            End Get
        End Property
        Public ReadOnly Property Line1005() As String
            Get
                Line1005 = _Line1005
            End Get
        End Property
        Public ReadOnly Property Line1006() As String
            Get
                Line1006 = _Line1006
            End Get
        End Property
        Public ReadOnly Property Line2006() As String
            Get
                Line2006 = _Line2006
            End Get
        End Property
        Public ReadOnly Property Line1007() As String
            Get
                Line1007 = _Line1007
            End Get
        End Property
        Public ReadOnly Property Line1008() As String
            Get
                Line1008 = _Line1008
            End Get
        End Property
        Public ReadOnly Property Line1009() As String
            Get
                Line1009 = _Line1009
            End Get
        End Property
        Public ReadOnly Property Line1010() As String
            Get
                Line1010 = _Line1010
            End Get
        End Property
        Public ReadOnly Property Line1011() As String
            Get
                Line1011 = _Line1011
            End Get
        End Property
        Public ReadOnly Property Line1012() As String
            Get
                Line1012 = _Line1012
            End Get
        End Property
        Public ReadOnly Property Line1014() As String
            Get
                Line1014 = _Line1014
            End Get
        End Property
        Public ReadOnly Property Line1015() As String
            Get
                Line1015 = _Line1015
            End Get
        End Property
        Public ReadOnly Property Line1016() As String
            Get
                Line1016 = _Line1016
            End Get
        End Property
        Public ReadOnly Property Line1017() As String
            Get
                Line1017 = _Line1017
            End Get
        End Property
        Public ReadOnly Property Line1018() As String
            Get
                Line1018 = _Line1018
            End Get
        End Property
        Public ReadOnly Property Line1019() As String
            Get
                Line1019 = _Line1019
            End Get
        End Property
        Public ReadOnly Property Line1020() As String
            Get
                Line1020 = _Line1020
            End Get
        End Property
        Public ReadOnly Property Line1021() As String
            Get
                Line1021 = _Line1021
            End Get
        End Property
        Public ReadOnly Property Line1022() As String
            Get
                Line1022 = _Line1022
            End Get
        End Property
        Public ReadOnly Property FileDetailLines As Generic.List(Of String)
            Get
                FileDetailLines = _FileDetailLines
            End Get
        End Property
        Public ReadOnly Property ComDataAC29File As ComDataAC29File
            Get
                ComDataAC29File = _ComDataAC29File
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ComDataAC29File As ComDataAC29File, ByVal FileDetailLines As Generic.List(Of String))

            _ComDataAC29File = ComDataAC29File
            _FileDetailLines = FileDetailLines

            If Me.FileDetailLines IsNot Nothing AndAlso Me.FileDetailLines.Count > 0 Then

                For Each FileDetailLine In FileDetailLines

                    If FileDetailLine.StartsWith("1001") Then

                        _Line1001 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1002") Then

                        _Line1002 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1003") Then

                        _Line1003 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1004") Then

                        _Line1004 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1005") Then

                        _Line1005 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1006") Then

                        _Line1006 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("2006") Then

                        _Line2006 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1007") Then

                        _Line1007 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1008") Then

                        _Line1008 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1009") Then

                        _Line1009 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1010") Then

                        _Line1010 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1011") Then

                        _Line1011 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1012") Then

                        _Line1012 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1014") Then

                        _Line1014 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1015") Then

                        _Line1015 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1016") Then

                        _Line1016 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1017") Then

                        _Line1017 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1018") Then

                        _Line1018 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1019") Then

                        _Line1019 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1020") Then

                        _Line1020 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1021") Then

                        _Line1021 = FileDetailLine

                    ElseIf FileDetailLine.StartsWith("1022") Then

                        _Line1022 = FileDetailLine

                    End If

                Next

            End If

        End Sub
        Public Function GetCheckNumber() As String

            'objects
            Dim CheckNumber As String = ""

            If String.IsNullOrWhiteSpace(_Line1003) = False AndAlso _Line1003.Length >= 392 Then

                Try

                    CheckNumber = _Line1003.Substring(376, 15)

                Catch ex As Exception
                    CheckNumber = ""
                End Try
                
            End If

            GetCheckNumber = CheckNumber.Trim

        End Function
        Public Function GetCheckAmount() As Decimal

            'objects
            Dim CheckAmount As Decimal = 0

            If String.IsNullOrWhiteSpace(_Line1001) = False AndAlso _Line1001.Length >= 184 Then

                Try

                    If IsNumeric(_Line1001.Substring(172, 11)) Then

                        CheckAmount = _Line1001.Substring(172, 9) & "." & _Line1001.Substring(181, 2)

                    End If
                    
                Catch ex As Exception
                    CheckAmount = 0
                End Try

            End If

            GetCheckAmount = CheckAmount

        End Function
        Public Function GetVendorName() As String

            'objects
            Dim VendorName As String = ""

            If String.IsNullOrWhiteSpace(_Line1002) = False AndAlso _Line1002.Length >= 88 Then

                Try

                    VendorName = _Line1002.Substring(57, 30)

                Catch ex As Exception
                    VendorName = ""
                End Try

            End If

            GetVendorName = VendorName.Trim

        End Function
        Public Function GetCheckClearedDate() As Date

            'objects
            Dim CheckClearedDate As Date = Nothing
            Dim CheckClearedDateString As String = Nothing
            Dim Year As String = Nothing
            Dim Month As String = Nothing
            Dim Day As String = Nothing

            If String.IsNullOrWhiteSpace(_Line1001) = False AndAlso _Line1001.Length >= 92 Then

                Try

                    CheckClearedDateString = _Line1001.Substring(85, 6)

                Catch ex As Exception
                    CheckClearedDateString = ""
                End Try

                If String.IsNullOrWhiteSpace(CheckClearedDateString) = False AndAlso CheckClearedDateString.Length = 6 Then

                    Year = "20" & CheckClearedDateString.Substring(0, 2)
                    Month = CheckClearedDateString.Substring(2, 2)
                    Day = CheckClearedDateString.Substring(4, 2)

                    Date.TryParse(Month & "/" & Day & "/" & Year, CheckClearedDate)

                End If

            End If

            GetCheckClearedDate = CheckClearedDate

        End Function

#End Region

    End Class

End Namespace

