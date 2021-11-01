Namespace Security

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
        Public Shared Function ASCIIDecoding(ByVal StringValue As String) As String

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
        Public Shared Function ASCIIEncoding(ByVal StringValue As String) As String

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
        Public Shared Function EncryptPO(ByVal StringToEncrypt As String) As String

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
        Public Shared Function DecryptPO(ByVal StringToDecrypt As String) As String

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
        Public Shared Function EncryptLicenseKey(ByVal ClearText As String) As String

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
        Public Shared Function DecryptLicenseKey(ByVal EncryptedText As String) As String

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

        Public Shared Function GenerateSHA256ManagedHash(ByVal SourceText As String) As String

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
        Public Shared Function RijndaelSimpleEncrypt(ByVal plainText As String) As String

            Try
                Dim passPhrase As String = "@dV@nT@G3"
                Dim saltValue As String = "s@1tV@lu3"
                Dim hashAlgorithm As String = "SHA1"
                Dim passwordIterations As Int16 = 2                  ' can be any number
                Dim initVector As String = "@1B2C3D4E5F6G7H8" ' must be 16 bytes
                Dim keySize As Int16 = 256

                ' Convert strings into byte arrays.
                ' Let us assume that strings only contain ASCII codes.
                ' If strings include Unicode characters, use Unicode, UTF7, or UTF8 
                ' encoding.
                Dim initVectorBytes As Byte()
                initVectorBytes = System.Text.Encoding.ASCII.GetBytes(initVector)

                Dim saltValueBytes As Byte()
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(saltValue)

                ' Convert our plaintext into a byte array.
                ' Let us assume that plaintext contains UTF8-encoded characters.
                Dim plainTextBytes As Byte()
                plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText)

                ' First, we must create a password, from which the key will be derived.
                ' This password will be generated from the specified passphrase and 
                ' salt value. The password will be created using the specified hash 
                ' algorithm. Password creation can be done in several iterations.
                Dim password As System.Security.Cryptography.PasswordDeriveBytes
                password = New System.Security.Cryptography.PasswordDeriveBytes(passPhrase,
                                                   saltValueBytes,
                                                   hashAlgorithm,
                                                   passwordIterations)

                ' Use the password to generate pseudo-random bytes for the encryption
                ' key. Specify the size of the key in bytes (instead of bits).
                Dim keyBytes As Byte()
                ' Type or member is obsolete
                keyBytes = password.GetBytes(keySize / 8)
                ' Type or member is obsolete

                ' Create uninitialized Rijndael encryption object.
                Dim symmetricKey As System.Security.Cryptography.RijndaelManaged
                symmetricKey = New System.Security.Cryptography.RijndaelManaged()

                ' It is reasonable to set encryption mode to Cipher Block Chaining
                ' (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC

                ' Generate encryptor from the existing key bytes and initialization 
                ' vector. Key size will be defined based on the number of the key 
                ' bytes.
                Dim encryptor As System.Security.Cryptography.ICryptoTransform
                encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

                ' Define memory stream which will be used to hold encrypted data.
                Dim memoryStream As System.IO.MemoryStream
                memoryStream = New System.IO.MemoryStream()

                ' Define cryptographic stream (always use Write mode for encryption).
                Dim cryptoStream As System.Security.Cryptography.CryptoStream
                cryptoStream = New System.Security.Cryptography.CryptoStream(memoryStream,
                                                encryptor,
                                                System.Security.Cryptography.CryptoStreamMode.Write)
                ' Start encrypting.
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)

                ' Finish encrypting.
                cryptoStream.FlushFinalBlock()

                ' Convert our encrypted data from a memory stream into a byte array.
                Dim cipherTextBytes As Byte()
                cipherTextBytes = memoryStream.ToArray()

                ' Close both streams.
                memoryStream.Close()
                cryptoStream.Close()

                ' Convert encrypted data into a base64-encoded string.
                Dim cipherText As String
                cipherText = Convert.ToBase64String(cipherTextBytes)

                ' Return encrypted string.
                RijndaelSimpleEncrypt = cipherText
            Catch ex As Exception
                'Return plainText
                RijndaelSimpleEncrypt = plainText
            End Try

        End Function
        Public Shared Function RijndaelSimpleDecrypt(ByVal cipherText As String) As String

            Try
                If cipherText = "" Then
                    Return ""
                End If
                Dim passPhrase As String = "@dV@nT@G3"
                Dim saltValue As String = "s@1tV@lu3"
                Dim hashAlgorithm As String = "SHA1"
                Dim passwordIterations As Int16 = 2                  ' can be any number
                Dim initVector As String = "@1B2C3D4E5F6G7H8" ' must be 16 bytes
                Dim keySize As Int16 = 256

                ' Convert strings defining encryption key characteristics into byte
                ' arrays. Let us assume that strings only contain ASCII codes.
                ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
                ' encoding.
                Dim initVectorBytes As Byte()
                initVectorBytes = System.Text.Encoding.ASCII.GetBytes(initVector)

                Dim saltValueBytes As Byte()
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(saltValue)

                ' Convert our ciphertext into a byte array.
                Dim err As String = False
                Dim cipherTextBytes As Byte()
                Try
                    cipherTextBytes = Convert.FromBase64String(cipherText.Replace(" ", "+"))
                Catch ex As Exception
                    Return ""
                End Try

                ' First, we must create a password, from which the key will be 
                ' derived. This password will be generated from the specified 
                ' passphrase and salt value. The password will be created using
                ' the specified hash algorithm. Password creation can be done in
                ' several iterations.
                Dim password As System.Security.Cryptography.PasswordDeriveBytes
                password = New System.Security.Cryptography.PasswordDeriveBytes(passPhrase,
                                                   saltValueBytes,
                                                   hashAlgorithm,
                                                   passwordIterations)

                ' Use the password to generate pseudo-random bytes for the encryption
                ' key. Specify the size of the key in bytes (instead of bits).
                Dim keyBytes As Byte()

                ' Type or member is obsolete
                keyBytes = password.GetBytes(keySize / 8)
                ' Type or member is obsolete

                ' Create uninitialized Rijndael encryption object.
                Dim symmetricKey As System.Security.Cryptography.RijndaelManaged
                symmetricKey = New System.Security.Cryptography.RijndaelManaged()

                ' It is reasonable to set encryption mode to Cipher Block Chaining
                ' (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC

                ' Generate decryptor from the existing key bytes and initialization 
                ' vector. Key size will be defined based on the number of the key 
                ' bytes.
                Dim decryptor As System.Security.Cryptography.ICryptoTransform
                decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

                ' Define memory stream which will be used to hold encrypted data.
                Dim memoryStream As System.IO.MemoryStream
                memoryStream = New System.IO.MemoryStream(cipherTextBytes)

                ' Define memory stream which will be used to hold encrypted data.
                Dim cryptoStream As System.Security.Cryptography.CryptoStream
                cryptoStream = New System.Security.Cryptography.CryptoStream(memoryStream,
                                                decryptor,
                                                System.Security.Cryptography.CryptoStreamMode.Read)

                ' Since at this point we don't know what the size of decrypted data
                ' will be, allocate the buffer long enough to hold ciphertext;
                ' plaintext is never longer than ciphertext.
                Dim plainTextBytes As Byte()
                ReDim plainTextBytes(cipherTextBytes.Length)

                ' Start decrypting.
                Dim decryptedByteCount As Integer
                decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                       0,
                                                       plainTextBytes.Length)

                ' Close both streams.
                memoryStream.Close()
                cryptoStream.Close()

                ' Convert decrypted data into a string. 
                ' Let us assume that the original plaintext string was UTF8-encoded.
                Dim plainText As String
                plainText = System.Text.Encoding.UTF8.GetString(plainTextBytes,
                                                    0,
                                                    decryptedByteCount)

                ' Return decrypted string.
                RijndaelSimpleDecrypt = plainText
            Catch ex As Exception
                'Return cipherText
                RijndaelSimpleDecrypt = cipherText
            End Try

        End Function
        Public Shared Function EncryptOld_DONOTUSE(ByVal ClearText As String) As String

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
        Private Shared Function Encrypt(ByVal ClearBytes() As Byte, ByVal KeyBytes() As Byte, ByVal IVBytes() As Byte) As Byte()

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
        Public Shared Function DecryptOld_DONOTUSE(ByVal EncryptedText As String) As String

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
        Private Shared Function Decrypt(ByVal CipherBytes() As Byte, ByVal KeyBytes() As Byte, ByVal IVBytes() As Byte) As Byte()

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

End Namespace

