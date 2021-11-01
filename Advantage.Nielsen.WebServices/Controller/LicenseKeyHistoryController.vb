Imports Newtonsoft.Json
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Web.Hosting
Imports System.Web.Http
Imports System.Web.Http.Filters

Namespace Controller

    Public Class LicenseKeyHistoryController
        Inherits ApiController

        Private Const _ConstConnectionStringBaseSQLAuthentication As String = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};APP={4}"
        Private Const _ConstDateMMDDYYYYRegularExpressionString = "^([1-9]|0[1-9]|1[0-2])[-/]([1-9]|0[1-9]|[12][0-9]|3[01])[-/]([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])$"

        Private Enum LKVersions
            V1
            V2
            V3
            V4
        End Enum






        ''' 08/15/2017 PLEASE replicate any changes involving decryption of the license key to the projects Advantage.Nielsen.WebServices file LicenseKeyController!!!





        'Private Function CreateConnectionString(ByVal ServerName As String, ByVal DatabaseName As String, ByVal UserName As String, ByVal Password As String, Optional ByVal Application As String = "Advantage.Nielsen.WebServices") As String

        '    'objects
        '    Dim ConnectionString As String = ""

        '    ConnectionString = String.Format(_ConstConnectionStringBaseSQLAuthentication, ServerName, DatabaseName, UserName, Password, Application)

        '    CreateConnectionString = ConnectionString

        'End Function
        Private Function GetLicenseKeyDates(ByVal AgencyName As String) As Generic.List(Of Date)

            Dim LicenseKeyDate As Date = Nothing
            Dim LicenseKeyDates As Generic.List(Of Date) = Nothing
            Dim SQLConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim SQLString As String = ""
            Dim DataTable As System.Data.DataTable = Nothing

            SQLString = "SELECT " &
                        "[CreatedDate] " &
                    "FROM  " &
                        "[dbo].[LicenseKeyHistory] AS LKH " &
                    "WHERE  " &
                        "LKH.[AgencyName] = '" & AgencyName & "' " &
                    "ORDER BY " &
                        "[CreatedDate] DESC"

            'SQLConnection = New System.Data.SqlClient.SqlConnection(CreateConnectionString("TASC-SQL1", "PROJECT", "tascwservice", "4@dvanWebService"))
            SQLConnection = New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("LicenseKeyConnectionString").ConnectionString)

            SqlCommand = New System.Data.SqlClient.SqlCommand(SQLString, SQLConnection)

            SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

            DataTable = New System.Data.DataTable

            Try

                SqlDataAdapter.Fill(DataTable)

            Catch ex As Exception
                DataTable = New System.Data.DataTable
            End Try

            LicenseKeyDates = New Generic.List(Of Date)

            If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow).ToList

                    LicenseKeyDate = Nothing

                    Try

                        If Date.TryParse(DataRow(0), LicenseKeyDate) Then

                            LicenseKeyDates.Add(DataRow(0))

                        End If

                    Catch ex As Exception

                    End Try

                Next

            End If

            GetLicenseKeyDates = LicenseKeyDates

        End Function
        Private Function GetClientCode(ByVal EncrpytedLicenseKey As String) As String

            Dim ClientCode As String = ""
            Dim SQLConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim SQLString As String = ""
            Dim DataTable As System.Data.DataTable = Nothing

            SQLString = "SELECT " &
                        "[ClientCode] " &
                    "FROM  " &
                        "[dbo].[LicenseKeyHistory] AS LKH " &
                    "WHERE  " &
                        "LKH.[EncrpytedLicenseKey] = '" & EncrpytedLicenseKey & "'"

            'SQLConnection = New System.Data.SqlClient.SqlConnection(CreateConnectionString("TASC-SQL1", "PROJECT", "tascwservice", "4@dvanWebService"))
            SQLConnection = New System.Data.SqlClient.SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings("LicenseKeyConnectionString").ConnectionString)

            SqlCommand = New System.Data.SqlClient.SqlCommand(SQLString, SQLConnection)

            SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

            DataTable = New System.Data.DataTable

            Try

                SqlDataAdapter.Fill(DataTable)

            Catch ex As Exception
                DataTable = New System.Data.DataTable
            End Try

            If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

                Try

                    ClientCode = DataTable.Rows(0)(0)

                Catch ex As Exception
                    ClientCode = ""
                End Try

            End If

            GetClientCode = ClientCode

        End Function
        Private Function Create(ByVal LKVersion As LKVersions, ByVal LicenseKeyDate As Date, ByVal DaysUntilFileExpires As Integer, ByVal DaysUntilKeyExpires As Integer,
                            ByVal PowerUsersQuantity As Integer, ByVal WVOnlyUsersQuantity As Integer, ByVal ClientPortalUsersQuantity As Integer, ByVal AgencyName As String,
                            ByVal DatabaseID As Integer, ByVal MediaToolsUsersQuantity As Integer, ByVal APIUsersQuantity As Integer) As String

            'objects
            Dim EncryptedLicenseKey As String = ""

            Select Case LKVersion

                Case LKVersions.V1

                    EncryptedLicenseKey = Create(LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName)

                Case LKVersions.V2

                    EncryptedLicenseKey = Create(LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, DatabaseID)

                Case LKVersions.V3

                    EncryptedLicenseKey = Create(LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, DatabaseID, MediaToolsUsersQuantity)

                Case LKVersions.V4

                    EncryptedLicenseKey = Create(LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, DatabaseID, MediaToolsUsersQuantity, APIUsersQuantity)

            End Select

            Create = EncryptedLicenseKey

        End Function
        Private Function Create(ByVal LicenseKeyDate As Date, ByVal DaysUntilFileExpires As Integer, ByVal DaysUntilKeyExpires As Integer, ByVal PowerUsersQuantity As Integer,
                            ByVal WVOnlyUsersQuantity As Integer, ByVal ClientPortalUsersQuantity As Integer, ByVal AgencyName As String) As String

            'objects
            Dim LicenseKey As String = ""
            Dim PowerUsersQuantityValue As String = ""
            Dim WVOnlyUsersQuantityValue As String = ""
            Dim ClientPortalUsersQuantityValue As String = ""
            Dim EncryptedLicenseKey As String = ""

            LicenseKey = LicenseKeyDate.ToString("yyMMdd")
            LicenseKey &= Format(DaysUntilFileExpires, "0000")
            LicenseKey &= Format(DaysUntilKeyExpires, "0000")

            If PowerUsersQuantity <> -1 Then

                PowerUsersQuantityValue = Format(PowerUsersQuantity, "00000")

            Else

                PowerUsersQuantityValue = "#####"

            End If

            If WVOnlyUsersQuantity <> -1 Then

                WVOnlyUsersQuantityValue = Format(WVOnlyUsersQuantity, "00000")

            Else

                WVOnlyUsersQuantityValue = "#####"

            End If

            If ClientPortalUsersQuantity <> -1 Then

                ClientPortalUsersQuantityValue = Format(ClientPortalUsersQuantity, "00000")

            Else

                ClientPortalUsersQuantityValue = "#####"

            End If

            LicenseKey &= PowerUsersQuantityValue
            LicenseKey &= WVOnlyUsersQuantityValue
            LicenseKey &= ClientPortalUsersQuantityValue

            LicenseKey &= PadWithCharacter(AgencyName.Replace("&", ",amp,"), 40)

            EncryptedLicenseKey = Encrypt(LicenseKey)

            Create = EncryptedLicenseKey

        End Function
        Private Function Create(ByVal LicenseKeyDate As Date, ByVal DaysUntilFileExpires As Integer, ByVal DaysUntilKeyExpires As Integer, ByVal PowerUsersQuantity As Integer,
                                ByVal WVOnlyUsersQuantity As Integer, ByVal ClientPortalUsersQuantity As Integer, ByVal AgencyName As String,
                                ByVal DatabaseID As Integer) As String

            'objects
            Dim LicenseKey As String = ""
            Dim PowerUsersQuantityValue As String = ""
            Dim WVOnlyUsersQuantityValue As String = ""
            Dim ClientPortalUsersQuantityValue As String = ""
            Dim EncryptedLicenseKey As String = ""

            LicenseKey = LicenseKeyDate.ToString("yyMMdd")
            LicenseKey &= Format(DaysUntilFileExpires, "0000")
            LicenseKey &= Format(DaysUntilKeyExpires, "0000")

            If PowerUsersQuantity <> -1 Then

                PowerUsersQuantityValue = Format(PowerUsersQuantity, "00000")

            Else

                PowerUsersQuantityValue = "#####"

            End If

            If WVOnlyUsersQuantity <> -1 Then

                WVOnlyUsersQuantityValue = Format(WVOnlyUsersQuantity, "00000")

            Else

                WVOnlyUsersQuantityValue = "#####"

            End If

            If ClientPortalUsersQuantity <> -1 Then

                ClientPortalUsersQuantityValue = Format(ClientPortalUsersQuantity, "00000")

            Else

                ClientPortalUsersQuantityValue = "#####"

            End If

            LicenseKey &= PowerUsersQuantityValue
            LicenseKey &= WVOnlyUsersQuantityValue
            LicenseKey &= ClientPortalUsersQuantityValue

            LicenseKey &= PadWithCharacter(AgencyName.Replace("&", ",amp,"), 40)

            LicenseKey &= Format(DatabaseID, "0000")
            'LicenseKey &= MediaToolsUsersQuantityValue

            EncryptedLicenseKey = Encrypt(LicenseKey)

            Create = EncryptedLicenseKey

        End Function
        Private Function Create(ByVal LicenseKeyDate As Date, ByVal DaysUntilFileExpires As Integer, ByVal DaysUntilKeyExpires As Integer, ByVal PowerUsersQuantity As Integer,
                                ByVal WVOnlyUsersQuantity As Integer, ByVal ClientPortalUsersQuantity As Integer, ByVal AgencyName As String,
                                ByVal DatabaseID As Integer, ByVal MediaToolsUsersQuantity As Integer) As String

            'objects
            Dim LicenseKey As String = ""
            Dim PowerUsersQuantityValue As String = ""
            Dim WVOnlyUsersQuantityValue As String = ""
            Dim ClientPortalUsersQuantityValue As String = ""
            Dim MediaToolsUsersQuantityValue As String = ""
            Dim EncryptedLicenseKey As String = ""

            LicenseKey = LicenseKeyDate.ToString("yyMMdd")
            LicenseKey &= Format(DaysUntilFileExpires, "0000")
            LicenseKey &= Format(DaysUntilKeyExpires, "0000")

            If PowerUsersQuantity <> -1 Then

                PowerUsersQuantityValue = Format(PowerUsersQuantity, "00000")

            Else

                PowerUsersQuantityValue = "#####"

            End If

            If WVOnlyUsersQuantity <> -1 Then

                WVOnlyUsersQuantityValue = Format(WVOnlyUsersQuantity, "00000")

            Else

                WVOnlyUsersQuantityValue = "#####"

            End If

            If ClientPortalUsersQuantity <> -1 Then

                ClientPortalUsersQuantityValue = Format(ClientPortalUsersQuantity, "00000")

            Else

                ClientPortalUsersQuantityValue = "#####"

            End If

            If MediaToolsUsersQuantity <> -1 Then

                MediaToolsUsersQuantityValue = Format(MediaToolsUsersQuantity, "00000")

            Else

                MediaToolsUsersQuantityValue = "#####"

            End If

            LicenseKey &= PowerUsersQuantityValue
            LicenseKey &= WVOnlyUsersQuantityValue
            LicenseKey &= ClientPortalUsersQuantityValue

            LicenseKey &= PadWithCharacter(AgencyName.Replace("&", ",amp,"), 40)

            LicenseKey &= Format(DatabaseID, "0000")
            LicenseKey &= MediaToolsUsersQuantityValue

            EncryptedLicenseKey = Encrypt(LicenseKey)

            Create = EncryptedLicenseKey

        End Function
        Private Function Create(ByVal LicenseKeyDate As Date, ByVal DaysUntilFileExpires As Integer, ByVal DaysUntilKeyExpires As Integer, ByVal PowerUsersQuantity As Integer,
                                ByVal WVOnlyUsersQuantity As Integer, ByVal ClientPortalUsersQuantity As Integer, ByVal AgencyName As String,
                                ByVal DatabaseID As Integer, ByVal MediaToolsUsersQuantity As Integer, ByVal APIUsersQuantity As Integer) As String

            'objects
            Dim LicenseKey As String = ""
            Dim PowerUsersQuantityValue As String = ""
            Dim WVOnlyUsersQuantityValue As String = ""
            Dim ClientPortalUsersQuantityValue As String = ""
            Dim MediaToolsUsersQuantityValue As String = ""
            Dim APIUsersQuantityValue As String = ""
            Dim EncryptedLicenseKey As String = ""

            LicenseKey = LicenseKeyDate.ToString("yyMMdd")
            LicenseKey &= Format(DaysUntilFileExpires, "0000")
            LicenseKey &= Format(DaysUntilKeyExpires, "0000")

            If PowerUsersQuantity <> -1 Then

                PowerUsersQuantityValue = Format(PowerUsersQuantity, "00000")

            Else

                PowerUsersQuantityValue = "#####"

            End If

            If WVOnlyUsersQuantity <> -1 Then

                WVOnlyUsersQuantityValue = Format(WVOnlyUsersQuantity, "00000")

            Else

                WVOnlyUsersQuantityValue = "#####"

            End If

            If ClientPortalUsersQuantity <> -1 Then

                ClientPortalUsersQuantityValue = Format(ClientPortalUsersQuantity, "00000")

            Else

                ClientPortalUsersQuantityValue = "#####"

            End If

            If MediaToolsUsersQuantity <> -1 Then

                MediaToolsUsersQuantityValue = Format(MediaToolsUsersQuantity, "00000")

            Else

                MediaToolsUsersQuantityValue = "#####"

            End If

            If APIUsersQuantity <> -1 Then

                APIUsersQuantityValue = Format(APIUsersQuantity, "00000")

            Else

                APIUsersQuantityValue = "#####"

            End If

            LicenseKey &= PowerUsersQuantityValue
            LicenseKey &= WVOnlyUsersQuantityValue
            LicenseKey &= ClientPortalUsersQuantityValue

            LicenseKey &= PadWithCharacter(AgencyName.Replace("&", ",amp,"), 40)

            LicenseKey &= Format(DatabaseID, "0000")
            LicenseKey &= MediaToolsUsersQuantityValue
            LicenseKey &= APIUsersQuantityValue

            EncryptedLicenseKey = Encrypt(LicenseKey)

            Create = EncryptedLicenseKey

        End Function
        Private Function PadWithCharacter(ByVal Data As String,
                                 ByVal FieldSize As Integer,
                                 Optional ByVal Character As String = " ",
                                 Optional ByVal Prefix As Boolean = False,
                                 Optional ByVal TrimIfTooLong As Boolean = True) As String

            'objects
            Dim Count As Integer = 0

            If Data.Length <= FieldSize Then

                For Count = 1 To FieldSize - Data.Length

                    Data = IIf(Prefix, Character, "") & Data & IIf(Prefix, "", Character)

                Next

            ElseIf TrimIfTooLong Then

                Data = Left(Data, FieldSize)

            End If

            PadWithCharacter = Data

        End Function
        Private Function Encrypt(ByVal ClearText As String) As String

            'objects
            Dim ClearBytes() As Byte = Nothing
            Dim Rfc2898DeriveBytes As System.Security.Cryptography.Rfc2898DeriveBytes = Nothing
            Dim EncryptedBytes() As Byte = Nothing
            Dim EncryptedText As String = ""

            Try

                ClearBytes = System.Text.Encoding.Unicode.GetBytes(ClearText)

                Rfc2898DeriveBytes = New System.Security.Cryptography.Rfc2898DeriveBytes("JustinBieber", New Byte() {&H45, &HF1, &H61, &H6E, &H20, &H0, &H65, &H64, &H76, &H65, &H64, &H3, &H76})

                EncryptedBytes = Encrypt(ClearBytes, Rfc2898DeriveBytes.GetBytes(32), Rfc2898DeriveBytes.GetBytes(16))

                EncryptedText = Convert.ToBase64String(EncryptedBytes)

            Catch ex As Exception
                EncryptedText = ClearText
            Finally
                Encrypt = EncryptedText
            End Try

        End Function
        Private Function Encrypt(ByVal ClearBytes() As Byte, ByVal KeyBytes() As Byte, ByVal IVBytes() As Byte) As Byte()

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim CryptoStream As System.Security.Cryptography.CryptoStream = Nothing
            Dim Rijndael As System.Security.Cryptography.Rijndael = Nothing
            Dim EncryptedBytes() As Byte = Nothing

            Try

                MemoryStream = New System.IO.MemoryStream

                Rijndael = System.Security.Cryptography.Rijndael.Create

                Rijndael.Key = KeyBytes
                Rijndael.IV = IVBytes

                CryptoStream = New System.Security.Cryptography.CryptoStream(MemoryStream, Rijndael.CreateEncryptor, System.Security.Cryptography.CryptoStreamMode.Write)

                CryptoStream.Write(ClearBytes, 0, ClearBytes.Length)
                CryptoStream.FlushFinalBlock()

                EncryptedBytes = MemoryStream.ToArray

            Catch ex As Exception
                EncryptedBytes = Nothing
            Finally

                If CryptoStream IsNot Nothing Then

                    CryptoStream.Close()

                End If

                Encrypt = EncryptedBytes

            End Try

        End Function
        Private Function Read(ByVal EncryptedLicenseKey As String, ByRef LicenseKeyDate As Date, ByRef DaysUntilFileExpires As Integer, ByRef DaysUntilKeyExpires As Integer,
                         ByRef PowerUsersQuantity As Integer, ByRef WVOnlyUsersQuantity As Integer, ByRef ClientPortalUsersQuantity As Integer, ByRef AgencyName As String,
                         ByRef DatabaseID As Integer, ByRef MediaToolsUsersQuantity As Integer) As String

            'objects
            Dim LicenseKey As String = ""

            Try

                LicenseKey = Decrypt(EncryptedLicenseKey)

                LicenseKeyDate = CDate(ConvertStringToShortDateString(LicenseKey.Substring(2, 4) & "20" & LicenseKey.Substring(0, 2)))
                DaysUntilFileExpires = CInt(LicenseKey.Substring(6, 4))
                DaysUntilKeyExpires = CInt(LicenseKey.Substring(10, 4))

                Try

                    If IsNumeric(LicenseKey.Substring(14, 5)) Then

                        PowerUsersQuantity = CInt(LicenseKey.Substring(14, 5))

                    Else

                        PowerUsersQuantity = -1

                    End If

                Catch ex As Exception
                    PowerUsersQuantity = -1
                End Try

                Try

                    If IsNumeric(LicenseKey.Substring(19, 5)) Then

                        WVOnlyUsersQuantity = CInt(LicenseKey.Substring(19, 5))

                    Else

                        WVOnlyUsersQuantity = -1

                    End If

                Catch ex As Exception
                    WVOnlyUsersQuantity = -1
                End Try

                Try

                    If IsNumeric(LicenseKey.Substring(24, 5)) Then

                        ClientPortalUsersQuantity = CInt(LicenseKey.Substring(24, 5))

                    Else

                        ClientPortalUsersQuantity = -1

                    End If

                Catch ex As Exception
                    ClientPortalUsersQuantity = -1
                End Try

                AgencyName = LicenseKey.Substring(29, 40).Replace(",amp,", "&")

                If LicenseKey.Length > 69 Then

                    Try

                        If IsNumeric(LicenseKey.Substring(69, 4)) Then

                            DatabaseID = CInt(LicenseKey.Substring(69, 4))

                        Else

                            DatabaseID = 0

                        End If

                    Catch ex As Exception
                        DatabaseID = 0
                    End Try

                    If LicenseKey.Length = 78 Then

                        Try

                            If IsNumeric(LicenseKey.Substring(73, 5)) Then

                                MediaToolsUsersQuantity = CInt(LicenseKey.Substring(73, 5))

                            Else

                                MediaToolsUsersQuantity = -1

                            End If

                        Catch ex As Exception
                            MediaToolsUsersQuantity = -1
                        End Try

                    End If

                End If

            Catch ex As Exception
                LicenseKey = ""
            Finally
                Read = LicenseKey
            End Try

        End Function
        'MJC 08/15/2017 - please replicate changes to Advantage.Nielsen.WebServices LicenseKeyController
        Private Function Read(ByVal EncryptedLicenseKey As String, ByRef LicenseKeyDate As Date, ByRef DaysUntilFileExpires As Integer, ByRef DaysUntilKeyExpires As Integer,
                         ByRef PowerUsersQuantity As Integer, ByRef WVOnlyUsersQuantity As Integer, ByRef ClientPortalUsersQuantity As Integer, ByRef AgencyName As String,
                         ByRef DatabaseID As Integer, ByRef MediaToolsUsersQuantity As Integer, ByRef APIUsersQuantity As Integer) As String

            'objects
            Dim LicenseKey As String = ""

            Try

                LicenseKey = Decrypt(EncryptedLicenseKey)

                LicenseKeyDate = CDate(ConvertStringToShortDateString(LicenseKey.Substring(2, 4) & "20" & LicenseKey.Substring(0, 2)))
                DaysUntilFileExpires = CInt(LicenseKey.Substring(6, 4))
                DaysUntilKeyExpires = CInt(LicenseKey.Substring(10, 4))

                Try

                    If IsNumeric(LicenseKey.Substring(14, 5)) Then

                        PowerUsersQuantity = CInt(LicenseKey.Substring(14, 5))

                    Else

                        PowerUsersQuantity = -1

                    End If

                Catch ex As Exception
                    PowerUsersQuantity = -1
                End Try

                Try

                    If IsNumeric(LicenseKey.Substring(19, 5)) Then

                        WVOnlyUsersQuantity = CInt(LicenseKey.Substring(19, 5))

                    Else

                        WVOnlyUsersQuantity = -1

                    End If

                Catch ex As Exception
                    WVOnlyUsersQuantity = -1
                End Try

                Try

                    If IsNumeric(LicenseKey.Substring(24, 5)) Then

                        ClientPortalUsersQuantity = CInt(LicenseKey.Substring(24, 5))

                    Else

                        ClientPortalUsersQuantity = -1

                    End If

                Catch ex As Exception
                    ClientPortalUsersQuantity = -1
                End Try

                AgencyName = LicenseKey.Substring(29, 40).Replace(",amp,", "&")

                If LicenseKey.Length > 69 Then

                    If IsNumeric(LicenseKey.Substring(69, 4)) Then

                        DatabaseID = CInt(LicenseKey.Substring(69, 4))

                    Else

                        DatabaseID = 0

                    End If

                    If LicenseKey.Length > 73 Then

                        Try

                            If IsNumeric(LicenseKey.Substring(73, 5)) Then

                                MediaToolsUsersQuantity = CInt(LicenseKey.Substring(73, 5))

                            Else

                                MediaToolsUsersQuantity = -1

                            End If

                        Catch ex As Exception
                            MediaToolsUsersQuantity = -1
                        End Try

                        If LicenseKey.Length > 78 Then

                            Try

                                If IsNumeric(LicenseKey.Substring(78, 5)) Then

                                    APIUsersQuantity = CInt(LicenseKey.Substring(78, 5))

                                Else

                                    APIUsersQuantity = -1

                                End If

                            Catch ex As Exception
                                APIUsersQuantity = -1
                            End Try

                        End If

                    End If

                End If

            Catch ex As Exception
                LicenseKey = ""
            Finally
                Read = LicenseKey
            End Try

        End Function
        Private Function Decrypt(ByVal EncryptedText As String) As String

            'objects
            Dim CipherBytes() As Byte = Nothing
            Dim Rfc2898DeriveBytes As System.Security.Cryptography.Rfc2898DeriveBytes = Nothing
            Dim DecryptedBytes() As Byte = Nothing
            Dim DecryptedText As String = ""

            Try

                CipherBytes = Convert.FromBase64String(EncryptedText)

                Rfc2898DeriveBytes = New System.Security.Cryptography.Rfc2898DeriveBytes("JustinBieber", New Byte() {&H45, &HF1, &H61, &H6E, &H20, &H0, &H65, &H64, &H76, &H65, &H64, &H3, &H76})

                DecryptedBytes = Decrypt(CipherBytes, Rfc2898DeriveBytes.GetBytes(32), Rfc2898DeriveBytes.GetBytes(16))

                DecryptedText = System.Text.Encoding.Unicode.GetString(DecryptedBytes)

            Catch ex As Exception
                DecryptedText = EncryptedText
            Finally
                Decrypt = DecryptedText
            End Try

        End Function
        Private Function Decrypt(ByVal CipherBytes() As Byte, ByVal KeyBytes() As Byte, ByVal IVBytes() As Byte) As Byte()

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim CryptoStream As System.Security.Cryptography.CryptoStream = Nothing
            Dim Rijndael As System.Security.Cryptography.Rijndael = Nothing
            Dim DecryptedBytes() As Byte = Nothing

            Try

                MemoryStream = New System.IO.MemoryStream

                Rijndael = System.Security.Cryptography.Rijndael.Create

                Rijndael.Key = KeyBytes
                Rijndael.IV = IVBytes

                CryptoStream = New System.Security.Cryptography.CryptoStream(MemoryStream, Rijndael.CreateDecryptor, System.Security.Cryptography.CryptoStreamMode.Write)

                CryptoStream.Write(CipherBytes, 0, CipherBytes.Length)
                CryptoStream.FlushFinalBlock()

                DecryptedBytes = MemoryStream.ToArray

            Catch ex As Exception
                DecryptedBytes = Nothing
            Finally

                If CryptoStream IsNot Nothing Then

                    CryptoStream.Close()

                End If

                Decrypt = DecryptedBytes

            End Try

        End Function
        Private Function ConvertStringToShortDateString(ByVal DateString As String) As String

            'objects
            Dim ValidExpressionMatch As Boolean = True
            Dim Year As String = ""
            Dim Day As String = ""
            Dim Month As String = ""
            Dim ConvertedDate As String = ""
            Dim DateSectionsArray() As String = Nothing
            Dim ShortDate As Date = Nothing

            If DateString.Contains("/") Then

                If IsRegularExpressionAMatch(_ConstDateMMDDYYYYRegularExpressionString, DateString) = False Then

                    ValidExpressionMatch = IsRegularExpressionAMatch(_ConstDateMMDDYYYYRegularExpressionString, DateString)

                End If

            Else

                If DateString.Length = 6 Then

                    DateString = DateString.Substring(0, 2) & "/" & DateString.Substring(2, 2) & "/" & DateString.Substring(4, 2)

                ElseIf DateString.Length = 7 Then

                    DateString = "0" & DateString.Substring(0, 1) & "/" & DateString.Substring(1, 2) & "/" & DateString.Substring(3, 4)

                ElseIf DateString.Length = 8 Then

                    DateString = DateString.Substring(0, 2) & "/" & DateString.Substring(2, 2) & "/" & DateString.Substring(4, 4)

                Else

                    Try

                        DateString = Date.Parse(DateString).Month & "/" & Date.Parse(DateString).Day & "/" & Date.Parse(DateString).Year

                    Catch ex As Exception
                        ValidExpressionMatch = False
                    End Try

                End If

            End If

            If ValidExpressionMatch Then

                If Date.TryParse(DateString, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), Globalization.DateTimeStyles.None, ShortDate) Then

                    ShortDate = Nothing

                    DateSectionsArray = Split(DateString, "/")

                    If DateSectionsArray.Length = 3 Then

                        Month = DateSectionsArray(0)
                        Day = DateSectionsArray(1)
                        Year = DateSectionsArray(2)

                    End If

                    If Year.Length = 2 Then

                        Year = "20" & Year

                    End If

                    ConvertedDate = Month & "/" & Day & "/" & Year

                    If Date.TryParse(ConvertedDate, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), Globalization.DateTimeStyles.None, ShortDate) Then

                        If ShortDate = Nothing Then

                            ConvertedDate = ""

                        Else

                            ConvertedDate = ShortDate.ToShortDateString

                        End If

                    Else

                        ConvertedDate = ""

                    End If

                End If

            End If

            ConvertStringToShortDateString = ConvertedDate

        End Function
        Private Function IsRegularExpressionAMatch(ByVal RegularExpression As String, ByVal Value As String) As Boolean

            'objects
            Dim Regex As System.Text.RegularExpressions.Regex = Nothing

            If Value <> Nothing Then

                Regex = New System.Text.RegularExpressions.Regex(RegularExpression)

                IsRegularExpressionAMatch = Regex.IsMatch(Value)

            Else

                IsRegularExpressionAMatch = False

            End If

        End Function
        <HttpGet>
        <Route("api/LicenseKeyHistory/ValidateLicenseKey")>
        Public Function ValidateLicenseKey(EncryptedLicenseKey As String, AgencyName As String) As String

            'objects
            Dim ClientCode As String = String.Empty
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim DatabaseID As Integer = 0
            Dim LicenseKeyDates As Generic.List(Of Date) = Nothing
            Dim LicenseKeyFound As Boolean = False

            Try

                Read(EncryptedLicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, DatabaseID, MediaToolsUsersQuantity, APIUsersQuantity)

                LicenseKeyDates = GetLicenseKeyDates(AgencyName)

                If LicenseKeyDates IsNot Nothing AndAlso LicenseKeyDates.Count > 0 Then

                    For Each LKDate In LicenseKeyDates

                        EncryptedLicenseKey = ""
                        ClientCode = ""

                        For Each LKVersion In [Enum].GetValues(GetType(LKVersions)).OfType(Of LKVersions)()

                            EncryptedLicenseKey = ""

                            EncryptedLicenseKey = Create(LKVersion, LKDate, DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, 0, MediaToolsUsersQuantity, APIUsersQuantity)

                            ClientCode = GetClientCode(EncryptedLicenseKey)

                            If ClientCode <> "" Then

                                LicenseKeyFound = True
                                Exit For

                            End If

                        Next

                        If LicenseKeyFound Then

                            Exit For

                        End If

                    Next

                End If

            Catch ex As Exception

            End Try

            ValidateLicenseKey = ClientCode

        End Function

    End Class

End Namespace