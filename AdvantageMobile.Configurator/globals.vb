Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

Public Module globals
    Public g_Version As String = "blue beta"
    Public g_AppTitle As String = "Webvantage"
    Public g_PageTitle As String = g_AppTitle & " Configurator"

    Public Function Encrypt(ByVal ClearText As String) As String

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
    Public Function Decrypt(ByVal EncryptedText As String) As String

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
End Module
