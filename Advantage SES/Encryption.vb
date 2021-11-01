Public Class Encryption

#Region " Constants "

    Private Const Aes256Key As String = "W12B&YHNOD5M(IK<64JK&YHN7UJMVH4R"
    'Private Const PBKDF_SHA256Key As String = "3A1A934CB7F3F931FD46AA41727A5654"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Shared Function Encrypt(PlainText As String) As String

        Dim EncryptedText As String = String.Empty
        Dim SourceBytes As Byte() = Nothing

        Try

            Using Aes = System.Security.Cryptography.Aes.Create

                Using Rfc2898DeriveBytes = New System.Security.Cryptography.Rfc2898DeriveBytes(Aes256Key, New Byte() {&H65, &H64, &H65, &H45, &HF1, &H61, &H6E, &H76, &H20, &H0, &H64, &H3, &H76})

                    Aes.BlockSize = 128
                    Aes.KeySize = 256
                    Aes.IV = Rfc2898DeriveBytes.GetBytes(16)
                    Aes.Key = Rfc2898DeriveBytes.GetBytes(32)
                    Aes.Mode = System.Security.Cryptography.CipherMode.CBC
                    Aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7

                    SourceBytes = System.Text.Encoding.Unicode.GetBytes(PlainText)

                    Using MemoryStream = New System.IO.MemoryStream

                        Using CryptoStream = New System.Security.Cryptography.CryptoStream(MemoryStream, Aes.CreateEncryptor, System.Security.Cryptography.CryptoStreamMode.Write)

                            CryptoStream.Write(SourceBytes, 0, SourceBytes.Length)

                        End Using

                        EncryptedText = Convert.ToBase64String(MemoryStream.ToArray)

                    End Using

                End Using

            End Using

        Catch ex As Exception
            EncryptedText = PlainText
        End Try

        Encrypt = EncryptedText

    End Function
    Public Shared Function Decrypt(EncryptedText As String) As String

        Dim DecryptedText As String = String.Empty
        Dim SourceBytes As Byte() = Nothing

        Try

            EncryptedText = EncryptedText.Replace(" ", "+")

            Using Aes = System.Security.Cryptography.Aes.Create

                Using Rfc2898DeriveBytes = New System.Security.Cryptography.Rfc2898DeriveBytes(Aes256Key, New Byte() {&H65, &H64, &H65, &H45, &HF1, &H61, &H6E, &H76, &H20, &H0, &H64, &H3, &H76})

                    Aes.BlockSize = 128
                    Aes.KeySize = 256
                    Aes.IV = Rfc2898DeriveBytes.GetBytes(16)
                    Aes.Key = Rfc2898DeriveBytes.GetBytes(32)
                    Aes.Mode = System.Security.Cryptography.CipherMode.CBC
                    Aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7

                    SourceBytes = System.Convert.FromBase64String(EncryptedText)

                    Using MemoryStream = New System.IO.MemoryStream

                        Using CryptoStream = New System.Security.Cryptography.CryptoStream(MemoryStream, Aes.CreateDecryptor, System.Security.Cryptography.CryptoStreamMode.Write)

                            CryptoStream.Write(SourceBytes, 0, SourceBytes.Length)

                        End Using

                        DecryptedText = System.Text.Encoding.Unicode.GetString(MemoryStream.ToArray)

                    End Using

                End Using

            End Using

        Catch ex As Exception
            DecryptedText = EncryptedText
        End Try

        Decrypt = DecryptedText

    End Function
    Public Shared Function EncryptPassword(PlainText As String) As String

        'objects
        Dim EncryptedText As String = String.Empty
        Dim ClearBytes() As Byte = Nothing
        Dim Rfc2898DeriveBytes As System.Security.Cryptography.Rfc2898DeriveBytes = Nothing
        Dim EncryptedBytes() As Byte = Nothing

        Try

            ClearBytes = System.Text.Encoding.Unicode.GetBytes(PlainText)

            Rfc2898DeriveBytes = New System.Security.Cryptography.Rfc2898DeriveBytes(PlainText, New Byte() {&H64, &H6E, &H20, &H45, &H65, &H0, &H64, &H76, &HF1, &H61, &H65, &H3, &H76},
                                                                                     1000, System.Security.Cryptography.HashAlgorithmName.SHA256)

            EncryptedBytes = Rfc2898DeriveBytes.GetBytes(32)

            EncryptedText = Convert.ToBase64String(EncryptedBytes)

        Catch ex As Exception
            EncryptedText = PlainText
        End Try

        EncryptPassword = EncryptedText

    End Function
    Public Shared Function ASCIIDecoding(StringValue As String) As String

        'objects
        Dim Decoded As String = String.Empty
        Dim HashInput As Byte() = Nothing

        Try

            If String.IsNullOrWhiteSpace(StringValue) = False Then

                HashInput = Convert.FromBase64String(StringValue)

                Decoded = System.Text.ASCIIEncoding.ASCII.GetString(HashInput)

            Else

                Decoded = StringValue

            End If

        Catch ex As Exception
            Decoded = StringValue
        End Try

        ASCIIDecoding = Decoded

    End Function
    Public Shared Function ASCIIEncoding(StringValue As String) As String

        'objects
        Dim Encoded As String = String.Empty
        Dim HashInput As Byte() = Nothing

        Try

            If String.IsNullOrWhiteSpace(StringValue) = False Then

                HashInput = System.Text.ASCIIEncoding.ASCII.GetBytes(StringValue)

                Encoded = Convert.ToBase64String(HashInput)

            Else

                Encoded = StringValue

            End If

        Catch ex As Exception
            Encoded = StringValue
        End Try

        ASCIIEncoding = Encoded

    End Function
    Public Shared Function EncryptPO(StringToEncrypt As String) As String

        Try
            Dim s As String = StringToEncrypt.Trim()
            'If s <> "" Then
            '    s = Encrypt(s)
            'End If
            ''Dim sec As New cSecurity(HttpContext.Current.Session("ConnString"))
            ''s = sec.Encrypt("MyPOKey", s)
            Dim i As Integer = 1
            Dim StrChar As String = ""
            Dim sb As New System.Text.StringBuilder

            For i = 1 To Len(StringToEncrypt)
                StrChar = Mid$(StringToEncrypt, i, 1)
                If IsNumeric(StrChar) = True Then
                    Select Case CType(StrChar, Integer)
                        Case 0
                            StrChar = "T"
                        Case 1
                            StrChar = "u"
                        Case 2
                            StrChar = "y"
                        Case 3
                            StrChar = "Z"
                        Case 4
                            StrChar = "b"
                        Case 5
                            StrChar = "A"
                        Case 6
                            StrChar = "P"
                        Case 7
                            StrChar = "S"
                        Case 8
                            StrChar = "m"
                        Case 9
                            StrChar = "r"
                    End Select
                End If
                sb.Append(StrChar)
            Next
            Return sb.ToString()
        Catch ex As Exception
            Return StringToEncrypt
        End Try

    End Function
    Public Shared Function DecryptPO(StringToDecrypt As String) As String

        Try
            Dim s As String = StringToDecrypt.Trim()
            'If s <> "" Then
            '    s = Decrypt(s)
            'End If
            ''Dim sec As New cSecurity(HttpContext.Current.Session("ConnString"))
            ''s = sec.Decrypt("MyPOKey", s)
            Dim i As Integer = 1
            Dim StrChar As String = ""
            Dim sb As New System.Text.StringBuilder

            For i = 1 To Len(StringToDecrypt)
                StrChar = Mid$(StringToDecrypt, i, 1)
                If IsNumeric(StrChar) = False Then
                    Select Case StrChar
                        Case "T"
                            StrChar = "0"
                        Case "u"
                            StrChar = "1"
                        Case "y"
                            StrChar = "2"
                        Case "Z"
                            StrChar = "3"
                        Case "b"
                            StrChar = "4"
                        Case "A"
                            StrChar = "5"
                        Case "P"
                            StrChar = "6"
                        Case "S"
                            StrChar = "7"
                        Case "m"
                            StrChar = "8"
                        Case "r"
                            StrChar = "9"
                    End Select
                End If
                sb.Append(StrChar)
            Next

            Return sb.ToString()

        Catch ex As Exception
            Return 0
        End Try

    End Function
    Public Shared Function EncryptLicenseKey(ClearText As String) As String

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
            EncryptLicenseKey = EncryptedText
        End Try

    End Function
    Public Shared Function DecryptLicenseKey(EncryptedText As String) As String

        'objects
        Dim CipherBytes() As Byte = Nothing
        Dim DecryptedBytes() As Byte = Nothing
        Dim DecryptedText As String = ""
        Dim Rfc2898DeriveBytes As System.Security.Cryptography.Rfc2898DeriveBytes = Nothing
        Dim DB32Bytes As Byte() = Nothing
        Dim DB16Bytes As Byte() = Nothing

        Try

            EncryptedText = EncryptedText.Replace(" ", "+")

            CipherBytes = Convert.FromBase64String(EncryptedText)

            If Rfc2898DeriveBytes Is Nothing Then

                Rfc2898DeriveBytes = New System.Security.Cryptography.Rfc2898DeriveBytes("JustinBieber", New Byte() {&H45, &HF1, &H61, &H6E, &H20, &H0, &H65, &H64, &H76, &H65, &H64, &H3, &H76})
                DB32Bytes = Rfc2898DeriveBytes.GetBytes(32)
                DB16Bytes = Rfc2898DeriveBytes.GetBytes(16)

            End If

            DecryptedBytes = Decrypt(CipherBytes, DB32Bytes, DB16Bytes)

            DecryptedText = System.Text.Encoding.Unicode.GetString(DecryptedBytes)

        Catch ex As Exception
            DecryptedText = EncryptedText
        Finally
            DecryptLicenseKey = DecryptedText
        End Try

    End Function

#Region "  Other Methods "

    Public Shared Function GenerateSHA256ManagedHash(SourceText As String) As String

        Try
            If String.IsNullOrWhiteSpace(SourceText) = False Then
                'objects
                Dim UnicodeEncoding As System.Text.UnicodeEncoding = Nothing
                Dim ByteSourceText() As Byte = Nothing
                Dim SHA256Managed As System.Security.Cryptography.SHA256Managed = Nothing
                Dim ByteHash() As Byte = Nothing

                UnicodeEncoding = New System.Text.UnicodeEncoding

                ByteSourceText = UnicodeEncoding.GetBytes(SourceText)

                SHA256Managed = New System.Security.Cryptography.SHA256Managed

                ByteHash = SHA256Managed.ComputeHash(ByteSourceText)

                GenerateSHA256ManagedHash = Convert.ToBase64String(ByteHash)
            Else
                Return SourceText
            End If
        Catch ex As Exception
            Return SourceText
        End Try

    End Function
    Public Shared Function EncryptOld_DONOTUSE(ClearText As String) As String

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
            EncryptOld_DONOTUSE = EncryptedText
        End Try

    End Function
    Private Shared Function Encrypt(ClearBytes() As Byte, KeyBytes() As Byte, IVBytes() As Byte) As Byte()

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
    Public Shared Function DecryptOld_DONOTUSE(EncryptedText As String) As String

        'objects
        Dim CipherBytes() As Byte = Nothing
        Dim DecryptedBytes() As Byte = Nothing
        Dim DecryptedText As String = ""
        Dim Rfc2898DeriveBytes As System.Security.Cryptography.Rfc2898DeriveBytes = Nothing
        Dim DB32Bytes As Byte() = Nothing
        Dim DB16Bytes As Byte() = Nothing

        Try

            EncryptedText = EncryptedText.Replace(" ", "+")

            CipherBytes = Convert.FromBase64String(EncryptedText)

            If Rfc2898DeriveBytes Is Nothing Then

                Rfc2898DeriveBytes = New System.Security.Cryptography.Rfc2898DeriveBytes("JustinBieber", New Byte() {&H45, &HF1, &H61, &H6E, &H20, &H0, &H65, &H64, &H76, &H65, &H64, &H3, &H76})
                DB32Bytes = Rfc2898DeriveBytes.GetBytes(32)
                DB16Bytes = Rfc2898DeriveBytes.GetBytes(16)

            End If

            DecryptedBytes = Decrypt(CipherBytes, DB32Bytes, DB16Bytes)

            DecryptedText = System.Text.Encoding.Unicode.GetString(DecryptedBytes)

        Catch ex As Exception
            DecryptedText = EncryptedText
        Finally
            DecryptOld_DONOTUSE = DecryptedText
        End Try

    End Function
    Private Shared Function Decrypt(CipherBytes() As Byte, KeyBytes() As Byte, IVBytes() As Byte) As Byte()

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

#End Region

#End Region

End Class

