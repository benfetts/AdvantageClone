Namespace StringUtilities

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property EmailRegularExpressionString As String
            Get
                EmailRegularExpressionString = "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"
            End Get
        End Property
        Public ReadOnly Property SocialSecurityNumberRegularExpressionString As String
            Get
                SocialSecurityNumberRegularExpressionString = "^\d{3}-\d{2}-\d{4}$"
            End Get
        End Property
        Public ReadOnly Property DateMMDDYYYYRegularExpressionString As String
            Get
                DateMMDDYYYYRegularExpressionString = "^([1-9]|0[1-9]|1[0-2])[-/]([1-9]|0[1-9]|[12][0-9]|3[01])[-/]([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])$"
            End Get
        End Property
        Public ReadOnly Property DateDDMMYYYYRegularExpressionString As String
            Get
                DateDDMMYYYYRegularExpressionString = "^([1-9]|0[1-9]|[12][0-9]|3[01])[-/]([1-9]|0[1-9]|1[0-2])[-/]([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])$"
            End Get
        End Property
        Public ReadOnly Property DateDDYYYYMMRegularExpressionString As String
            Get
                DateDDYYYYMMRegularExpressionString = "^([1-9]|0[1-9]|[12][0-9]|3[01])[-/]([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])[-/]([1-9]|0[1-9]|1[0-2])$"
            End Get
        End Property
        Public ReadOnly Property DateMMYYYYDDRegularExpressionString As String
            Get
                DateMMYYYYDDRegularExpressionString = "^([1-9]|0[1-9]|1[0-2])[-/]([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])[-/]([1-9]|0[1-9]|[12][0-9]|3[01])$"
            End Get
        End Property
        Public ReadOnly Property DateYYYYDDMMRegularExpressionString As String
            Get
                DateYYYYDDMMRegularExpressionString = "^([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])[-/]([1-9]|0[1-9]|[12][0-9]|3[01])[-/]([1-9]|0[1-9]|1[0-2])$"
            End Get
        End Property
        Public ReadOnly Property DateYYYYMMDDRegularExpressionString As String
            Get
                DateYYYYMMDDRegularExpressionString = "^([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])[-/]([1-9]|0[1-9]|1[0-2])[-/]([1-9]|0[1-9]|[12][0-9]|3[01])$"
            End Get
        End Property
        Public ReadOnly Property PhoneNumberRegularExpressionString As String
            Get
                PhoneNumberRegularExpressionString = "^\([2-9]\d{2}\)\d{3}[-]\d{4}$"
            End Get
        End Property
        Public ReadOnly Property PhoneNumber7DigitRegularExpressionString As String
            Get
                PhoneNumber7DigitRegularExpressionString = "^\d{3}[-]\d{4}$"
            End Get
        End Property
        Public ReadOnly Property ZipRegularExpressionString As String
            Get
                ZipRegularExpressionString = "^(\d{5})$"
            End Get
        End Property
        Public ReadOnly Property Zip2RegularExpressionString As String
            Get
                Zip2RegularExpressionString = "^(\d{4})$"
            End Get
        End Property
        Public ReadOnly Property UrlRegularExpressionString As String
            Get
                UrlRegularExpressionString = "^(https?|chrome):\/\/[^\s$.?#].[^\s]*$"
            End Get
        End Property
#End Region

#Region " Methods "

        Public Function CheckForEndingPunctuation(ByVal Message As String) As String

            Dim OriginalMessage As String = Message
            Try

                If String.IsNullOrWhiteSpace(Message) = False AndAlso
                   Message.EndsWith(".") = False AndAlso
                   Message.EndsWith("!") = False AndAlso
                   Message.EndsWith("?") = False Then

                    Message &= "."

                End If

            Catch ex As Exception
                Message = OriginalMessage
            End Try

            Return Message

        End Function
        Public Function RemoveAllLineBreaks(Data As String) As String

            'objects
            Dim AlteredData As String = ""

            AlteredData = Data

            If String.IsNullOrEmpty(AlteredData) = False Then

                AlteredData = AlteredData.Replace(vbCrLf, String.Empty)
                AlteredData = AlteredData.Replace(vbCr, String.Empty)
                AlteredData = AlteredData.Replace(vbLf, String.Empty)

            End If

            RemoveAllLineBreaks = AlteredData

        End Function
        Public Function CleanStringForSplit(ByRef OriginalString As String, ByVal Delimiter As String,
                                           Optional ByVal RemoveSpaces As Boolean = True, Optional ByVal RemoveDuplicates As Boolean = True,
                                           Optional ByVal RemoveTrailingDelim As Boolean = True, Optional ByVal RemoveEmptyItems As Boolean = True,
                                           Optional ByVal RemoveLineFeeds As Boolean = True) As String
            Try

                Dim str As String = OriginalString

                If str.Length > 0 Then

                    If RemoveSpaces = True Then

                        str = str.Replace(" ", "")

                    End If
                    str = str.Replace(Delimiter & Delimiter, Delimiter)

                    If RemoveDuplicates = True Then

                        str = RemoveDuplicatesFromString(str, Delimiter)

                    End If
                    If RemoveTrailingDelim = True Then

                        str = RemoveTrailingDelimiter(str, Delimiter)

                    End If
                    If RemoveEmptyItems = True Then

                        If RemoveSpaces = True Then

                            str = str.Replace(" ", "")

                        End If

                        str = str.Replace(Delimiter & Delimiter, Delimiter)
                        str = str.Replace(Delimiter & " " & Delimiter, Delimiter)

                    End If
                    If RemoveLineFeeds = True Then

                        str = str.Replace(Environment.NewLine, "").Replace(vbCrLf, "").Replace(vbCr, "").Replace(vbLf, "")

                    End If

                    Return str

                Else

                    Return OriginalString

                End If
            Catch ex As Exception

                Return OriginalString

            End Try
        End Function
        Public Function RemoveTrailingDelimiter(ByVal OriginalString As String, ByVal delimiter As String) As String
            Try

                OriginalString = RTrim(OriginalString)

                If OriginalString.EndsWith(delimiter) Then

                    Return OriginalString.Substring(0, OriginalString.Length - 1)

                Else

                    Return OriginalString

                End If
            Catch ex As Exception

                Return OriginalString

            End Try
        End Function
        Public Function RemoveDuplicatesFromString(ByVal OriginalString As String, ByVal Delimiter As String, Optional ByVal UseDelimiter As Boolean = False) As String
            Try

                Dim str As String = String.Empty
                Dim strHolder As String = String.Empty
                Dim strArr() As String

                strArr = OriginalString.Split(CType(Delimiter, Char))

                Dim arrList As New ArrayList

                For i As Integer = 0 To strArr.Length - 1

                    If Not arrList.Contains(strArr(i)) Then

                        arrList.Add(strArr(i))

                    End If

                Next
                For j As Integer = 0 To arrList.Count - 1

                    If UseDelimiter = True Then

                        str &= arrList.Item(j).ToString() & Delimiter

                    Else

                        str &= arrList.Item(j).ToString() & ","

                    End If
                Next

                str = str.Replace(Delimiter & Delimiter, Delimiter)

                If str.EndsWith(Delimiter) Then

                    str = str.Substring(0, str.Length - 1)

                End If

                Return str

            Catch ex As Exception

                Return OriginalString

            End Try
        End Function
        Public Function RemoveIllegalFilenameIllegalCharacters(ByVal Filename As String) As String

            'Return System.Text.RegularExpressions.Regex.Replace(Filename, "[^A-Za-z0-9\-/]", "")
            Return Filename.Replace("?", "_").Replace("/", "_").Replace("\", "_").Replace("""", "_").Replace("'", "_")

        End Function
        Public Function ContainsIllegalCharacters(ByVal StringToCheck As String) As Boolean

            If StringToCheck.Contains("?") = True OrElse
                    StringToCheck.Contains("/") = True OrElse
                    StringToCheck.Contains("\") = True OrElse
                    StringToCheck.Contains("'") = True OrElse
                    StringToCheck.Contains("&") = True OrElse
                    StringToCheck.Contains("""") = True Then

                Return True

            Else

                Return False

            End If

        End Function
        Public Function RemoveAllHtmlTags(ByVal SourceText As String) As String

            Return System.Text.RegularExpressions.Regex.Replace(SourceText, "<.*?>", "")

        End Function
        Public Function FileSystemFilenameAndPathSafe(ByVal MakeItSafe As String) As String

            Dim Filename As String = MakeItSafe

            Try

                Dim LastSlash As Integer = Filename.LastIndexOf("\")
                Dim FilenameLength As Integer = Filename.Length

                If LastSlash = -1 Then 'No path

                    For Each c In IO.Path.GetInvalidFileNameChars

                        Filename = Filename.Replace(c, "")

                    Next

                Else

                    Dim JustTheFile As String = Filename.Substring(LastSlash + 1)
                    Dim CleanedName As String = JustTheFile

                    For Each c In IO.Path.GetInvalidFileNameChars

                        CleanedName = CleanedName.Replace(c, "")

                    Next

                    Filename = Filename.Replace(JustTheFile, CleanedName)

                End If

            Catch ex As Exception
                Filename = MakeItSafe
            End Try

            Return Filename

        End Function
        Public Function JavascriptSafe(ByVal MakeItSafe As String) As String

            Try

                Return System.Web.HttpUtility.JavaScriptStringEncode(MakeItSafe)

            Catch ex As Exception

                Return MakeItSafe

            End Try

        End Function
        Public Function ByteArrayToString(ByVal ByteArray() As Byte) As String

            'objects
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            StringBuilder = New System.Text.StringBuilder(ByteArray.Length * 2)

            For ByteArrayCounter As Integer = 0 To ByteArray.Length - 1

                StringBuilder.Append(ByteArray(ByteArrayCounter).ToString("X2"))

            Next

            ByteArrayToString = StringBuilder.ToString().ToLower

        End Function
        Public Function ConvertIntegerToString(ByVal IntegerValue As Integer) As String

            ConvertIntegerToString = IntegerValue.ToString

        End Function
        Public Function IsValidEmailAddress(ByRef EmailAddress As String) As Boolean

            Dim Regex As System.Text.RegularExpressions.Regex = Nothing

            If EmailAddress <> Nothing Then

                Regex = New System.Text.RegularExpressions.Regex(AdvantageFramework.StringUtilities.EmailRegularExpressionString, System.Text.RegularExpressions.RegexOptions.IgnoreCase)

                IsValidEmailAddress = Regex.IsMatch(EmailAddress)

            Else

                IsValidEmailAddress = False

            End If

        End Function
        Public Function IsValidFullZipCode(ByRef FullZipCode As String) As Boolean

            'objects
            Dim ConvertedFullZipCode As String = ""
            Dim Zip As String = ""
            Dim Zip2 As String = ""
            Dim IsValid As Boolean = False

            If FullZipCode <> Nothing Then

                ConvertedFullZipCode = RemoveAllNonNumeric(FullZipCode.Replace(" ", ""))

                If ConvertedFullZipCode.Length = 9 Then

                    IsValid = True
                    FullZipCode = ConvertedFullZipCode.Substring(0, 5) & "-" & ConvertedFullZipCode.Substring(5, 4)

                End If

            End If

            IsValidFullZipCode = IsValid

        End Function
        Public Function IsValidZip2(ByVal Zip2 As String) As Boolean

            IsValidZip2 = IsRegularExpressionAMatch(Zip2RegularExpressionString, Zip2)

        End Function
        Public Function IsValidZip(ByVal Zip As String) As Boolean

            IsValidZip = IsRegularExpressionAMatch(ZipRegularExpressionString, Zip)

        End Function
        Public Function IsValidURL(ByRef URL As String) As Boolean

            If URL.ToLower().StartsWith("http://") = False AndAlso URL.ToLower().StartsWith("https://") = False Then

                URL = "http://" & URL

            End If

            IsValidURL = IsRegularExpressionAMatch(AdvantageFramework.StringUtilities.UrlRegularExpressionString, URL)

        End Function
        Public Function ConvertPhoneNumber(ByVal PhoneNumber As String, ByRef ValidPhoneNumber As Boolean) As String

            'objects
            Dim ConvertedPhoneNumber As String = ""

            ValidPhoneNumber = False

            ConvertedPhoneNumber = RemoveAllNonNumeric(PhoneNumber)

            If ConvertedPhoneNumber.Length = 10 Then

                ConvertedPhoneNumber = "(" & ConvertedPhoneNumber.Substring(0, 3) & ")" & ConvertedPhoneNumber.Substring(3, 3) & "-" & ConvertedPhoneNumber.Substring(6, 4)

                ValidPhoneNumber = IsRegularExpressionAMatch(PhoneNumberRegularExpressionString, ConvertedPhoneNumber)

            ElseIf ConvertedPhoneNumber.Length = 7 Then

                ConvertedPhoneNumber = ConvertedPhoneNumber.Substring(0, 3) & "-" & ConvertedPhoneNumber.Substring(3, 4)

                ValidPhoneNumber = IsRegularExpressionAMatch(PhoneNumber7DigitRegularExpressionString, ConvertedPhoneNumber)

            End If

            If Not ValidPhoneNumber Then

                ConvertedPhoneNumber = PhoneNumber

            End If

            ConvertPhoneNumber = ConvertedPhoneNumber

        End Function
        Public Function IsValidPhoneNumber(ByRef PhoneNumber As String, ByVal TryToConvert As Boolean) As Boolean

            'objects
            Dim ConvertedPhoneNumber As String = ""
            Dim ValidPhoneNumber As Boolean = False

            ValidPhoneNumber = IsRegularExpressionAMatch(PhoneNumberRegularExpressionString, PhoneNumber)

            If Not ValidPhoneNumber Then

                ValidPhoneNumber = IsRegularExpressionAMatch(PhoneNumber7DigitRegularExpressionString, PhoneNumber)

            End If

            If Not ValidPhoneNumber AndAlso TryToConvert Then

                ConvertedPhoneNumber = ConvertPhoneNumber(PhoneNumber, ValidPhoneNumber)

                If ValidPhoneNumber Then

                    PhoneNumber = ConvertedPhoneNumber

                End If

            End If

            IsValidPhoneNumber = ValidPhoneNumber

        End Function
        'Public Function Decrypt(ByVal StringValue As String) As String

        '    Try
        '        If String.IsNullOrWhiteSpace(StringValue) = False Then
        '            'objects
        '            Dim HashInput As Byte() = Nothing

        '            HashInput = Convert.FromBase64String(StringValue)

        '            Decrypt = System.Text.ASCIIEncoding.ASCII.GetString(HashInput)
        '        Else
        '            Return StringValue
        '        End If
        '    Catch ex As Exception
        '        Return StringValue
        '    End Try

        'End Function
        'Public Function Encrypt(ByVal StringValue As String) As String

        '    Try
        '        If String.IsNullOrWhiteSpace(StringValue) = False Then
        '            'objects
        '            Dim HashInput As Byte() = Nothing

        '            HashInput = System.Text.ASCIIEncoding.ASCII.GetBytes(StringValue)

        '            Encrypt = Convert.ToBase64String(HashInput)
        '        Else
        '            Return StringValue
        '        End If
        '    Catch ex As Exception
        '        Return StringValue
        '    End Try

        'End Function
        '<System.Obsolete()>
        'Public Function URLSafeEncrypt(ClearText As String) As String

        '    Try
        '        If String.IsNullOrWhiteSpace(ClearText) = False Then
        '            Dim EncryptedText As String = ""
        '            Dim EncryptionKey As String = ""
        '            Dim ClearBytes As Byte() = Nothing
        '            Dim Rfc2898DeriveBytes As System.Security.Cryptography.Rfc2898DeriveBytes = Nothing

        '            EncryptionKey = "MAKV2SPBNI99212"
        '            ClearBytes = System.Text.Encoding.Unicode.GetBytes(ClearText)

        '            Using Aes As System.Security.Cryptography.Aes = System.Security.Cryptography.Aes.Create()

        '                Rfc2898DeriveBytes = New System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})

        '                Aes.Key = Rfc2898DeriveBytes.GetBytes(32)
        '                Aes.IV = Rfc2898DeriveBytes.GetBytes(16)

        '                Using MemoryStream As New System.IO.MemoryStream()

        '                    Using CryptoStream As New System.Security.Cryptography.CryptoStream(MemoryStream, Aes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

        '                        CryptoStream.Write(ClearBytes, 0, ClearBytes.Length)
        '                        CryptoStream.Close()

        '                    End Using

        '                    EncryptedText = Convert.ToBase64String(MemoryStream.ToArray())

        '                End Using

        '            End Using

        '            URLSafeEncrypt = EncryptedText
        '        Else
        '            Return ClearText
        '        End If
        '    Catch ex As Exception
        '        Return ClearText
        '    End Try

        'End Function
        '<System.Obsolete()>
        'Public Function URLSafeDecrypt(EncryptedText As String) As String

        '    Try
        '        If String.IsNullOrWhiteSpace(EncryptedText) = False Then
        '            Dim DecryptedText As String = ""
        '            Dim EncryptionKey As String = ""
        '            Dim EncryptedBytes As Byte() = Nothing
        '            Dim Rfc2898DeriveBytes As System.Security.Cryptography.Rfc2898DeriveBytes = Nothing

        '            EncryptionKey = "MAKV2SPBNI99212"
        '            EncryptedText = EncryptedText.Replace(" ", "+")
        '            EncryptedBytes = Convert.FromBase64String(EncryptedText)

        '            Using Aes As System.Security.Cryptography.Aes = System.Security.Cryptography.Aes.Create()

        '                Rfc2898DeriveBytes = New System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
        '                Aes.Key = Rfc2898DeriveBytes.GetBytes(32)
        '                Aes.IV = Rfc2898DeriveBytes.GetBytes(16)

        '                Using MemoryStream As New System.IO.MemoryStream()

        '                    Using CryptoStream As New System.Security.Cryptography.CryptoStream(MemoryStream, Aes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

        '                        CryptoStream.Write(EncryptedBytes, 0, EncryptedBytes.Length)
        '                        CryptoStream.Close()

        '                    End Using

        '                    DecryptedText = System.Text.Encoding.Unicode.GetString(MemoryStream.ToArray())

        '                End Using

        '            End Using

        '            URLSafeDecrypt = DecryptedText
        '        Else
        '            Return EncryptedText
        '        End If
        '    Catch ex As Exception
        '        Return EncryptedText
        '    End Try

        'End Function
        '<System.Obsolete()>
        'Public Function RijndaelSimpleEncryptPO(ByVal StringToEncrypt As String) As String

        '    Try
        '        Dim s As String = StringToEncrypt.Trim()
        '        'If s <> "" Then
        '        '    s = Encrypt(s)
        '        'End If
        '        ''Dim sec As New cSecurity(HttpContext.Current.Session("ConnString"))
        '        ''s = sec.Encrypt("MyPOKey", s)
        '        Dim i As Integer = 1
        '        Dim StrChar As String = ""
        '        Dim sb As New System.Text.StringBuilder

        '        For i = 1 To Len(StringToEncrypt)
        '            StrChar = Mid$(StringToEncrypt, i, 1)
        '            If IsNumeric(StrChar) = True Then
        '                Select Case CType(StrChar, Integer)
        '                    Case 0
        '                        StrChar = "T"
        '                    Case 1
        '                        StrChar = "u"
        '                    Case 2
        '                        StrChar = "y"
        '                    Case 3
        '                        StrChar = "Z"
        '                    Case 4
        '                        StrChar = "b"
        '                    Case 5
        '                        StrChar = "A"
        '                    Case 6
        '                        StrChar = "P"
        '                    Case 7
        '                        StrChar = "S"
        '                    Case 8
        '                        StrChar = "m"
        '                    Case 9
        '                        StrChar = "r"
        '                End Select
        '            End If
        '            sb.Append(StrChar)
        '        Next
        '        Return sb.ToString()
        '    Catch ex As Exception
        '        Return StringToEncrypt
        '    End Try

        'End Function
        '<System.Obsolete()>
        'Public Function RijndaelSimpleDecryptPO(ByVal StringToDecrypt As String) As String

        '    Try
        '        Dim s As String = StringToDecrypt.Trim()
        '        'If s <> "" Then
        '        '    s = Decrypt(s)
        '        'End If
        '        ''Dim sec As New cSecurity(HttpContext.Current.Session("ConnString"))
        '        ''s = sec.Decrypt("MyPOKey", s)
        '        Dim i As Integer = 1
        '        Dim StrChar As String = ""
        '        Dim sb As New System.Text.StringBuilder

        '        For i = 1 To Len(StringToDecrypt)
        '            StrChar = Mid$(StringToDecrypt, i, 1)
        '            If IsNumeric(StrChar) = False Then
        '                Select Case StrChar
        '                    Case "T"
        '                        StrChar = "0"
        '                    Case "u"
        '                        StrChar = "1"
        '                    Case "y"
        '                        StrChar = "2"
        '                    Case "Z"
        '                        StrChar = "3"
        '                    Case "b"
        '                        StrChar = "4"
        '                    Case "A"
        '                        StrChar = "5"
        '                    Case "P"
        '                        StrChar = "6"
        '                    Case "S"
        '                        StrChar = "7"
        '                    Case "m"
        '                        StrChar = "8"
        '                    Case "r"
        '                        StrChar = "9"
        '                End Select
        '            End If
        '            sb.Append(StrChar)
        '        Next

        '        Return sb.ToString()

        '    Catch ex As Exception
        '        Return 0
        '    End Try

        'End Function
        '<System.Obsolete()>
        'Public Function GenerateSHA256ManagedHash(ByVal SourceText As String) As String

        '    Try
        '        If String.IsNullOrWhiteSpace(SourceText) = False Then
        '            'objects
        '            Dim UnicodeEncoding As System.Text.UnicodeEncoding = Nothing
        '            Dim ByteSourceText() As Byte = Nothing
        '            Dim SHA256Managed As System.Security.Cryptography.SHA256Managed = Nothing
        '            Dim ByteHash() As Byte = Nothing

        '            UnicodeEncoding = New System.Text.UnicodeEncoding

        '            ByteSourceText = UnicodeEncoding.GetBytes(SourceText)

        '            SHA256Managed = New System.Security.Cryptography.SHA256Managed

        '            ByteHash = SHA256Managed.ComputeHash(ByteSourceText)

        '            GenerateSHA256ManagedHash = Convert.ToBase64String(ByteHash)
        '        Else
        '            Return SourceText
        '        End If
        '    Catch ex As Exception
        '        Return SourceText
        '    End Try

        'End Function
        '' <summary>
        '' Encrypts specified plaintext using Rijndael symmetric key algorithm
        '' and returns a base64-encoded result.
        '' </summary>
        '' <param name="plainText">
        '' Plaintext value to be encrypted.
        '' </param>
        '' <param name="passPhrase">
        '' Passphrase from which a pseudo-random password will be derived. The 
        '' derived password will be used to generate the encryption key. 
        '' Passphrase can be any string. In this example we assume that this 
        '' passphrase is an ASCII string.
        '' </param>
        '' <param name="saltValue">
        '' Salt value used along with passphrase to generate password. Salt can 
        '' be any string. In this example we assume that salt is an ASCII string.
        '' </param>
        '' <param name="hashAlgorithm">
        '' Hash algorithm used to generate password. Allowed values are: "MD5" and
        '' "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
        '' </param>
        '' <param name="passwordIterations">
        '' Number of iterations used to generate password. One or two iterations
        '' should be enough.
        '' </param>
        '' <param name="initVector">
        '' Initialization vector (or IV). This value is required to encrypt the 
        '' first block of plaintext data. For RijndaelManaged class IV must be 
        '' exactly 16 ASCII characters long.
        '' </param>
        '' <param name="keySize">
        '' Size of encryption key in bits. Allowed values are: 128, 192, and 256. 
        '' Longer keys are more secure than shorter keys.
        '' </param>
        '' <returns>
        '' Encrypted value formatted as a base64-encoded string.
        '' </returns>
        '<System.Obsolete()>
        'Public Function RijndaelSimpleEncrypt(ByVal plainText As String) As String

        '    Try
        '        Dim passPhrase As String = "@dV@nT@G3"
        '        Dim saltValue As String = "s@1tV@lu3"
        '        Dim hashAlgorithm As String = "SHA1"
        '        Dim passwordIterations As Int16 = 2                  ' can be any number
        '        Dim initVector As String = "@1B2C3D4E5F6G7H8" ' must be 16 bytes
        '        Dim keySize As Int16 = 256

        '        ' Convert strings into byte arrays.
        '        ' Let us assume that strings only contain ASCII codes.
        '        ' If strings include Unicode characters, use Unicode, UTF7, or UTF8 
        '        ' encoding.
        '        Dim initVectorBytes As Byte()
        '        initVectorBytes = System.Text.Encoding.ASCII.GetBytes(initVector)

        '        Dim saltValueBytes As Byte()
        '        saltValueBytes = System.Text.Encoding.ASCII.GetBytes(saltValue)

        '        ' Convert our plaintext into a byte array.
        '        ' Let us assume that plaintext contains UTF8-encoded characters.
        '        Dim plainTextBytes As Byte()
        '        plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText)

        '        ' First, we must create a password, from which the key will be derived.
        '        ' This password will be generated from the specified passphrase and 
        '        ' salt value. The password will be created using the specified hash 
        '        ' algorithm. Password creation can be done in several iterations.
        '        Dim password As System.Security.Cryptography.PasswordDeriveBytes
        '        password = New System.Security.Cryptography.PasswordDeriveBytes(passPhrase,
        '                                           saltValueBytes,
        '                                           hashAlgorithm,
        '                                           passwordIterations)

        '        ' Use the password to generate pseudo-random bytes for the encryption
        '        ' key. Specify the size of the key in bytes (instead of bits).
        '        Dim keyBytes As Byte()
        '        ' Type or member is obsolete
        '        keyBytes = password.GetBytes(keySize / 8)
        '        ' Type or member is obsolete

        '        ' Create uninitialized Rijndael encryption object.
        '        Dim symmetricKey As System.Security.Cryptography.RijndaelManaged
        '        symmetricKey = New System.Security.Cryptography.RijndaelManaged()

        '        ' It is reasonable to set encryption mode to Cipher Block Chaining
        '        ' (CBC). Use default options for other symmetric key parameters.
        '        symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC

        '        ' Generate encryptor from the existing key bytes and initialization 
        '        ' vector. Key size will be defined based on the number of the key 
        '        ' bytes.
        '        Dim encryptor As System.Security.Cryptography.ICryptoTransform
        '        encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

        '        ' Define memory stream which will be used to hold encrypted data.
        '        Dim memoryStream As System.IO.MemoryStream
        '        memoryStream = New System.IO.MemoryStream()

        '        ' Define cryptographic stream (always use Write mode for encryption).
        '        Dim cryptoStream As System.Security.Cryptography.CryptoStream
        '        cryptoStream = New System.Security.Cryptography.CryptoStream(memoryStream,
        '                                        encryptor,
        '                                        System.Security.Cryptography.CryptoStreamMode.Write)
        '        ' Start encrypting.
        '        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)

        '        ' Finish encrypting.
        '        cryptoStream.FlushFinalBlock()

        '        ' Convert our encrypted data from a memory stream into a byte array.
        '        Dim cipherTextBytes As Byte()
        '        cipherTextBytes = memoryStream.ToArray()

        '        ' Close both streams.
        '        memoryStream.Close()
        '        cryptoStream.Close()

        '        ' Convert encrypted data into a base64-encoded string.
        '        Dim cipherText As String
        '        cipherText = Convert.ToBase64String(cipherTextBytes)

        '        ' Return encrypted string.
        '        RijndaelSimpleEncrypt = cipherText
        '    Catch ex As Exception
        '        'Return plainText
        '        RijndaelSimpleEncrypt = plainText
        '    End Try

        'End Function
        '' <summary>
        '' Decrypts specified ciphertext using Rijndael symmetric key algorithm.
        '' </summary>
        '' <param name="cipherText">
        '' Base64-formatted ciphertext value.
        '' </param>
        '' <param name="passPhrase">
        '' Passphrase from which a pseudo-random password will be derived. The 
        '' derived password will be used to generate the encryption key. 
        '' Passphrase can be any string. In this example we assume that this 
        '' passphrase is an ASCII string.
        '' </param>
        '' <param name="saltValue">
        '' Salt value used along with passphrase to generate password. Salt can 
        '' be any string. In this example we assume that salt is an ASCII string.
        '' </param>
        '' <param name="hashAlgorithm">
        '' Hash algorithm used to generate password. Allowed values are: "MD5" and
        '' "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
        '' </param>
        '' <param name="passwordIterations">
        '' Number of iterations used to generate password. One or two iterations
        '' should be enough.
        '' </param>
        '' <param name="initVector">
        '' Initialization vector (or IV). This value is required to encrypt the 
        '' first block of plaintext data. For RijndaelManaged class IV must be 
        '' exactly 16 ASCII characters long.
        '' </param>
        '' <param name="keySize">
        '' Size of encryption key in bits. Allowed values are: 128, 192, and 256. 
        '' Longer keys are more secure than shorter keys.
        '' </param>
        '' <returns>
        '' Decrypted string value.
        '' </returns>
        '' <remarks>
        '' Most of the logic in this function is similar to the Encrypt 
        '' logic. In order for decryption to work, all parameters of this function
        '' - except cipherText value - must match the corresponding parameters of 
        '' the Encrypt function which was called to generate the 
        '' ciphertext.
        '' </remarks>
        '<System.Obsolete()>
        'Public Function RijndaelSimpleDecrypt(ByVal cipherText As String) As String

        '    Try
        '        If cipherText = "" Then
        '            Return ""
        '        End If
        '        Dim passPhrase As String = "@dV@nT@G3"
        '        Dim saltValue As String = "s@1tV@lu3"
        '        Dim hashAlgorithm As String = "SHA1"
        '        Dim passwordIterations As Int16 = 2                  ' can be any number
        '        Dim initVector As String = "@1B2C3D4E5F6G7H8" ' must be 16 bytes
        '        Dim keySize As Int16 = 256

        '        ' Convert strings defining encryption key characteristics into byte
        '        ' arrays. Let us assume that strings only contain ASCII codes.
        '        ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
        '        ' encoding.
        '        Dim initVectorBytes As Byte()
        '        initVectorBytes = System.Text.Encoding.ASCII.GetBytes(initVector)

        '        Dim saltValueBytes As Byte()
        '        saltValueBytes = System.Text.Encoding.ASCII.GetBytes(saltValue)

        '        ' Convert our ciphertext into a byte array.
        '        Dim err As String = False
        '        Dim cipherTextBytes As Byte()
        '        Try
        '            cipherTextBytes = Convert.FromBase64String(cipherText.Replace(" ", "+"))
        '        Catch ex As Exception
        '            Return ""
        '        End Try

        '        ' First, we must create a password, from which the key will be 
        '        ' derived. This password will be generated from the specified 
        '        ' passphrase and salt value. The password will be created using
        '        ' the specified hash algorithm. Password creation can be done in
        '        ' several iterations.
        '        Dim password As System.Security.Cryptography.PasswordDeriveBytes
        '        password = New System.Security.Cryptography.PasswordDeriveBytes(passPhrase,
        '                                           saltValueBytes,
        '                                           hashAlgorithm,
        '                                           passwordIterations)

        '        ' Use the password to generate pseudo-random bytes for the encryption
        '        ' key. Specify the size of the key in bytes (instead of bits).
        '        Dim keyBytes As Byte()

        '        ' Type or member is obsolete
        '        keyBytes = password.GetBytes(keySize / 8)
        '        ' Type or member is obsolete

        '        ' Create uninitialized Rijndael encryption object.
        '        Dim symmetricKey As System.Security.Cryptography.RijndaelManaged
        '        symmetricKey = New System.Security.Cryptography.RijndaelManaged()

        '        ' It is reasonable to set encryption mode to Cipher Block Chaining
        '        ' (CBC). Use default options for other symmetric key parameters.
        '        symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC

        '        ' Generate decryptor from the existing key bytes and initialization 
        '        ' vector. Key size will be defined based on the number of the key 
        '        ' bytes.
        '        Dim decryptor As System.Security.Cryptography.ICryptoTransform
        '        decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

        '        ' Define memory stream which will be used to hold encrypted data.
        '        Dim memoryStream As System.IO.MemoryStream
        '        memoryStream = New System.IO.MemoryStream(cipherTextBytes)

        '        ' Define memory stream which will be used to hold encrypted data.
        '        Dim cryptoStream As System.Security.Cryptography.CryptoStream
        '        cryptoStream = New System.Security.Cryptography.CryptoStream(memoryStream,
        '                                        decryptor,
        '                                        System.Security.Cryptography.CryptoStreamMode.Read)

        '        ' Since at this point we don't know what the size of decrypted data
        '        ' will be, allocate the buffer long enough to hold ciphertext;
        '        ' plaintext is never longer than ciphertext.
        '        Dim plainTextBytes As Byte()
        '        ReDim plainTextBytes(cipherTextBytes.Length)

        '        ' Start decrypting.
        '        Dim decryptedByteCount As Integer
        '        decryptedByteCount = cryptoStream.Read(plainTextBytes,
        '                                               0,
        '                                               plainTextBytes.Length)

        '        ' Close both streams.
        '        memoryStream.Close()
        '        cryptoStream.Close()

        '        ' Convert decrypted data into a string. 
        '        ' Let us assume that the original plaintext string was UTF8-encoded.
        '        Dim plainText As String
        '        plainText = System.Text.Encoding.UTF8.GetString(plainTextBytes,
        '                                            0,
        '                                            decryptedByteCount)

        '        ' Return decrypted string.
        '        RijndaelSimpleDecrypt = plainText
        '    Catch ex As Exception
        '        'Return cipherText
        '        RijndaelSimpleDecrypt = cipherText
        '    End Try

        'End Function
        Public Function AppendTrailingCharacter(ByVal InitialString As String, ByRef AppendCharacter As String) As String

            If InitialString.Length > 0 Then

                If InitialString.Substring(InitialString.Length - 1) <> AppendCharacter Then

                    InitialString += AppendCharacter

                End If

            End If

            AppendTrailingCharacter = InitialString

        End Function
        Public Function IsValidDecimal(ByVal SourceText As String, ByVal Precision As Long, ByVal Scale As Long) As Boolean

            'objects
            Dim IsValid As Boolean = False
            Dim NumberString As String = ""
            Dim NumberDecimalSeparator As String = ""

            NumberString = SourceText

            Try

                NumberDecimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator

            Catch ex As Exception
                NumberDecimalSeparator = ""
            End Try

            If NumberDecimalSeparator = "" Then

                NumberDecimalSeparator = "."

            End If

            Try

                IsValid = IsRegularExpressionAMatch("^[-]?\d{1," & Precision - Scale & "}(\" & NumberDecimalSeparator & "\d{1," & Scale & "})?$", NumberString)

            Catch ex As Exception
                IsValid = False
            End Try

            Try

                If IsValid = False Then

                    If CDec(SourceText) = Math.Round(CDec(SourceText), CInt(Scale), MidpointRounding.AwayFromZero) Then

                        IsValid = True

                    End If

                End If

            Catch ex As Exception

            End Try

            IsValidDecimal = IsValid

        End Function
        Public Function FormatNumberString(ByVal SourceText As String, ByVal Precision As Long, ByVal Scale As Long) As String

            'objects
            Dim NumberString As String = ""
            Dim NumberDecimalSplit() As String = Nothing
            Dim NumberDecimalSeparator As String = ""

            Try

                NumberString = SourceText

                Try

                    NumberDecimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator

                Catch ex As Exception
                    NumberDecimalSeparator = ""
                End Try

                If NumberDecimalSeparator = "" Then

                    NumberDecimalSeparator = "."

                End If

                If IsRegularExpressionAMatch("(?!^0*$)(?!^0*\" & NumberDecimalSeparator & "0*$)^\d{1," & Precision - Scale & "}(\" & NumberDecimalSeparator & "\d{1," & Scale & "})?$", NumberString) = False Then

                    If NumberString.Contains(NumberDecimalSeparator) Then

                        NumberDecimalSplit = NumberString.Split(NumberDecimalSeparator)

                        If NumberDecimalSplit.Length = 2 Then

                            If NumberDecimalSplit(0).Length > (Precision - Scale) Then

                                NumberDecimalSplit(0) = NumberDecimalSplit(0).Substring(0, (Precision - Scale))

                            End If

                            If NumberDecimalSplit(1).Length > Scale Then

                                NumberDecimalSplit(1) = NumberDecimalSplit(1).Substring(0, Scale)

                            End If

                            NumberString = String.Join(NumberDecimalSeparator, NumberDecimalSplit)

                        End If

                    Else

                        If Not String.IsNullOrWhiteSpace(NumberString) AndAlso NumberString.Length >= (Precision - Scale) Then

                            NumberString = NumberString.Substring(0, (Precision - Scale))

                        End If

                        NumberString = PadWithCharacter(NumberString & NumberDecimalSeparator, Precision + 1, "0")

                    End If

                End If

            Catch ex As Exception
                NumberString = SourceText
            Finally
                FormatNumberString = NumberString
            End Try

        End Function
        Public Function RemoveAllNonAlpha(ByVal SourceText As String, Optional ByVal DefaultReturn As String = "") As String

            Try

                If String.IsNullOrEmpty(SourceText) = False Then

                    RemoveAllNonAlpha = System.Text.RegularExpressions.Regex.Replace(SourceText, "[^a-zA-Z]", "")

                Else

                    RemoveAllNonAlpha = DefaultReturn

                End If

            Catch ex As Exception
                RemoveAllNonAlpha = DefaultReturn
            End Try

        End Function
        Public Function RemoveAllNonNumeric(ByVal SourceText As String, Optional ByVal DefaultReturn As String = "") As String

            Try

                If String.IsNullOrEmpty(SourceText) = False Then

                    RemoveAllNonNumeric = System.Text.RegularExpressions.Regex.Replace(SourceText, "[^0-9]", "")

                Else

                    RemoveAllNonNumeric = DefaultReturn

                End If

            Catch ex As Exception
                RemoveAllNonNumeric = DefaultReturn
            End Try

        End Function
        Public Function RemoveAllNonAlphaNumeric(ByVal SourceText As String, Optional ByVal DefaultReturn As String = "") As String

            Try

                If String.IsNullOrEmpty(SourceText) = False Then

                    RemoveAllNonAlphaNumeric = System.Text.RegularExpressions.Regex.Replace(SourceText, "[^a-zA-Z0-9]", "")

                Else

                    RemoveAllNonAlphaNumeric = DefaultReturn

                End If

            Catch ex As Exception
                RemoveAllNonAlphaNumeric = DefaultReturn
            End Try

        End Function
        Public Function GetNameAsWords(ByVal Value As String) As String

            Try
                If String.IsNullOrWhiteSpace(Value) = False Then
                    'objects
                    Dim NewName As String = ""
                    Dim CharIndex As Integer = 0
                    Dim ThisCharacter As String = ""
                    Dim LastCharacter As String = ""

                    If String.IsNullOrEmpty(Value) = False Then

                        For Each ThisCharacter In Value

                            Select Case ThisCharacter

                                Case "A" To "Z", 0 To 9

                                    Select Case LastCharacter

                                        Case "A" To "Z", " ", ""

                                            If CharIndex + 1 < Value.Length AndAlso Value.Chars(CharIndex + 1).ToString.ToLower = Value.Chars(CharIndex + 1).ToString Then

                                                NewName &= " " & ThisCharacter

                                            Else

                                                NewName &= ThisCharacter

                                            End If

                                        Case Else

                                            If IsNumeric(LastCharacter) AndAlso IsNumeric(ThisCharacter) Then

                                                NewName &= ThisCharacter

                                            Else

                                                NewName &= " " & ThisCharacter

                                            End If

                                    End Select

                                Case Else

                                    NewName &= ThisCharacter

                            End Select

                            LastCharacter = ThisCharacter

                            CharIndex += 1

                        Next

                    End If

                    GetNameAsWords = NewName.TrimStart(" ")
                Else
                    Return Value
                End If
            Catch ex As Exception
                Return Value
            End Try

        End Function
        Public Function ConvertSocialSecurityNumber(ByVal SocialSecurityNumber As String, ByRef IsValidSSN As Boolean) As String

            'objects
            Dim ConvertedSSN As String = ""

            IsValidSSN = False

            ConvertedSSN = RemoveAllNonNumeric(SocialSecurityNumber)

            If ConvertedSSN.Length = 9 Then

                ConvertedSSN = ConvertedSSN.Substring(0, 3) & "-" & ConvertedSSN.Substring(3, 2) & "-" & ConvertedSSN.Substring(5, 4)

                IsValidSSN = AdvantageFramework.StringUtilities.IsRegularExpressionAMatch(AdvantageFramework.StringUtilities.SocialSecurityNumberRegularExpressionString, ConvertedSSN)

                If Not IsValidSSN Then

                    ConvertedSSN = SocialSecurityNumber

                End If

            End If

            ConvertSocialSecurityNumber = ConvertedSSN

        End Function
        Public Function IsValidSocialSecurityNumber(ByRef SocialSecurityNumber As String, ByVal TryToConvert As Boolean) As Boolean

            'objects
            Dim ConvertedSSN As String = ""
            Dim IsValidSSN As Boolean = False

            IsValidSSN = AdvantageFramework.StringUtilities.IsRegularExpressionAMatch(AdvantageFramework.StringUtilities.SocialSecurityNumberRegularExpressionString, SocialSecurityNumber)

            If IsValidSSN = False AndAlso TryToConvert Then

                ConvertedSSN = ConvertSocialSecurityNumber(SocialSecurityNumber, IsValidSSN)

                If IsValidSSN Then

                    SocialSecurityNumber = ConvertedSSN

                End If

            End If

            IsValidSocialSecurityNumber = IsValidSSN

        End Function
        Public Function IsRegularExpressionAMatch(ByVal RegularExpression As String, ByVal Value As String) As Boolean

            'objects
            Dim Regex As System.Text.RegularExpressions.Regex = Nothing

            If Value <> Nothing Then

                Regex = New System.Text.RegularExpressions.Regex(RegularExpression)

                IsRegularExpressionAMatch = Regex.IsMatch(Value)

            Else

                IsRegularExpressionAMatch = False

            End If

        End Function
        Public Function PadWithCharacter(ByVal Data As String,
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
        Public Function CreateCommaDelimitedString(ByVal IntegerList As Generic.List(Of Integer)) As String

            Dim StringBuilderLine As System.Text.StringBuilder = Nothing

            StringBuilderLine = New System.Text.StringBuilder()

            For Each IntegerValue In IntegerList

                If StringBuilderLine.ToString = "" Then

                    StringBuilderLine.Append(IntegerValue.ToString)

                Else

                    StringBuilderLine.Append("," & IntegerValue.ToString)

                End If

            Next

            CreateCommaDelimitedString = StringBuilderLine.ToString

        End Function
        Public Function Truncate(ByVal Text As String, ByVal Length As Integer) As String
            Try

                If Text.Length > Length Then

                    Return Text.Substring(0, Length).Trim() & "..."

                Else

                    Return Text

                End If

            Catch ex As Exception

                Return Text

            End Try
        End Function
        Public Function FormatDecimal(ByVal [Number] As String) As Decimal
            Try

                Dim s As String = [Number]
                s = AdvantageFramework.StringUtilities.FormatNumber(s)
                Return CType(s, Decimal)

            Catch ex As Exception
                Return [Number]
            End Try
        End Function
        Public Function FormatNumber(ByVal [Number] As String) As String
            Try

                Dim NumberDecimalSeparator As String = ""
                Try

                    NumberDecimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator

                Catch ex As Exception
                    NumberDecimalSeparator = ""
                End Try

                Dim s As String = [Number]

                If IsNumeric(s) = False And System.Threading.Thread.CurrentThread.CurrentCulture.Name <> "en-US" Then
                    'Culture is set correctly, yet "Number" is not valid
                    'most likely string being passed in is English
                    'HACK!
                    Try
                        s = s.Replace(" ", "")
                        s = s.Replace(",", "")
                        Dim DecimalSeparator As String = NumberDecimalSeparator
                        s = s.Replace(".", DecimalSeparator)
                    Catch ex As Exception
                        Return [Number]
                    End Try
                End If

                Return Microsoft.VisualBasic.FormatNumber(s, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)

            Catch ex As Exception
                Return [Number]
            End Try
        End Function
        Public Function AreDatesEqual(ByVal Date1 As Date?, ByVal Date2 As Date?) As Boolean

            'objects
            Dim DatesEqual As Boolean = True

            If Not Date.Equals(Date1, Date2) Then

                If Not (Date1.HasValue AndAlso Date2.HasValue AndAlso Date.Equals(Date1.Value.Date, Date2.Value.Date)) Then

                    DatesEqual = False

                End If

            End If

            AreDatesEqual = DatesEqual

        End Function
        Public Function ParseLastDot(ByVal buf As String) As String
            Dim bufs(), ans As String

            If buf.IndexOf(".") > 0 Then
                bufs = buf.Split(".")
                ans = bufs(UBound(bufs))
            Else
                ans = buf
            End If

            Return ans
        End Function
        Public Function GUID_Date(Optional ByVal IncludeSpacer As Boolean = True,
                                  Optional ByVal IncludeTime As Boolean = True,
                                  Optional ByVal IncludeSeconds As Boolean = True,
                                  Optional ByVal IncludeMilliseconds As Boolean = False) As String
            Try

                Dim StringBuilder As New System.Text.StringBuilder

                If IncludeSpacer = True Then StringBuilder.Append("_")

                StringBuilder.Append(Now.Year.ToString())
                StringBuilder.Append(Now.Month.ToString.PadLeft(2, "0"))
                StringBuilder.Append(Now.Day.ToString().PadLeft(2, "0"))

                If IncludeSpacer = True Then StringBuilder.Append("_")

                If IncludeTime = True Then

                    StringBuilder.Append(Now.Hour.ToString().PadLeft(2, "0"))
                    StringBuilder.Append(Now.Minute.ToString().PadLeft(2, "0"))

                    If IncludeSeconds = True Then StringBuilder.Append(Now.Second.ToString().PadLeft(2, "0"))

                    If IncludeMilliseconds = True Then

                        If IncludeSpacer = True Then StringBuilder.Append("_")

                        StringBuilder.Append(Now.Millisecond.ToString().PadLeft(4))

                    End If

                End If

                Return StringBuilder.ToString()

            Catch ex As Exception
                Return ""
            End Try

        End Function
        Public Function IgnoreError(ByVal Message As String) As Boolean

            Dim Ignore = False

            If Message.Contains("cannot append header after") = True OrElse
               Message.Contains("EmployeePicture") = True OrElse
               Message.Contains("CommentPicture") = True OrElse
               Message.Contains("does not implement IController") = True OrElse
               Message.Contains("null entry for parameter") = True OrElse
               Message.Contains("Conversion from string") = True OrElse
               Message.Contains("no row at position 0") = True OrElse
               Message.Contains("Value cannot be null") = True OrElse
               Message.Contains("Conversion from string") = True OrElse
               Message.Contains("reference not set to an instance") = True Then

                Ignore = True

            End If

            Return Ignore

        End Function
        Public Function FullErrorToString(ByVal Ex As Exception) As String

            Dim ErrorString As New System.Text.StringBuilder

            If Ex IsNot Nothing Then

                If String.IsNullOrWhiteSpace(Ex.Message) = False Then ErrorString.Append(Ex.Message)

                If Ex.InnerException IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(Ex.InnerException.Message) = False Then

                        ErrorString.Append(Environment.NewLine)
                        ErrorString.Append(Ex.InnerException.Message)

                    End If

                End If

            End If

            Return ErrorString.ToString

        End Function

#End Region

#Region " Extensions "

        <System.Runtime.CompilerServices.Extension()>
        Public Function ToDbNullIfNullOrWhiteSpace(ByVal aString As String) As Object

            If String.IsNullOrWhiteSpace(aString) Then

                ToDbNullIfNullOrWhiteSpace = DBNull.Value

            Else

                ToDbNullIfNullOrWhiteSpace = aString

            End If

        End Function
        <System.Runtime.CompilerServices.Extension()>
        Public Function ToEmptyStringIfNullOrWhiteSpace(ByVal aString As String) As String

            If String.IsNullOrWhiteSpace(aString) Then

                ToEmptyStringIfNullOrWhiteSpace = String.Empty

            Else

                ToEmptyStringIfNullOrWhiteSpace = aString

            End If

        End Function
        <System.Runtime.CompilerServices.Extension()>
        Public Function ParseDigits(ByVal aString As String) As Integer?

            'objects
            Dim Digits As String = ""

            If Not String.IsNullOrWhiteSpace(aString) Then

                For Each c As Char In aString.ToCharArray()

                    If Char.IsDigit(c) Then

                        Digits &= c

                    End If

                Next

            End If

            If Not String.IsNullOrWhiteSpace(Digits) Then

                ParseDigits = CInt(Digits)

            Else

                ParseDigits = Nothing

            End If

        End Function

#End Region

    End Module

End Namespace

