using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Collections;

namespace AdvantageFramework.Core.StringUtilities
{
    [HideModuleName()]
    public static class Methods
    {
        public static string EmailRegularExpressionString
        {
            get
            {
                return @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            }
        }
        public static string SocialSecurityNumberRegularExpressionString
        {
            get
            {
                return @"^\d{3}-\d{2}-\d{4}$";
            }
        }
        public static string DateMMDDYYYYRegularExpressionString
        {
            get
            {
                return "^([1-9]|0[1-9]|1[0-2])[-/]([1-9]|0[1-9]|[12][0-9]|3[01])[-/]([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])$";
            }
        }
        public static string DateDDMMYYYYRegularExpressionString
        {
            get
            {
                return "^([1-9]|0[1-9]|[12][0-9]|3[01])[-/]([1-9]|0[1-9]|1[0-2])[-/]([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])$";
            }
        }
        public static string DateDDYYYYMMRegularExpressionString
        {
            get
            {
                return "^([1-9]|0[1-9]|[12][0-9]|3[01])[-/]([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])[-/]([1-9]|0[1-9]|1[0-2])$";
            }
        }
        public static string DateMMYYYYDDRegularExpressionString
        {
            get
            {
                return "^([1-9]|0[1-9]|1[0-2])[-/]([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])[-/]([1-9]|0[1-9]|[12][0-9]|3[01])$";
            }
        }
        public static string DateYYYYDDMMRegularExpressionString
        {
            get
            {
                return "^([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])[-/]([1-9]|0[1-9]|[12][0-9]|3[01])[-/]([1-9]|0[1-9]|1[0-2])$";
            }
        }
        public static string DateYYYYMMDDRegularExpressionString
        {
            get
            {
                return "^([0-9][0-9]|18[5-9][0-9]|19[0-9][0-9]|20[0-9][0-9])[-/]([1-9]|0[1-9]|1[0-2])[-/]([1-9]|0[1-9]|[12][0-9]|3[01])$";
            }
        }
        public static string PhoneNumberRegularExpressionString
        {
            get
            {
                return @"^\([2-9]\d{2}\)\d{3}[-]\d{4}$";
            }
        }
        public static string PhoneNumber7DigitRegularExpressionString
        {
            get
            {
                return @"^\d{3}[-]\d{4}$";
            }
        }
        public static string ZipRegularExpressionString
        {
            get
            {
                return @"^(\d{5})$";
            }
        }
        public static string Zip2RegularExpressionString
        {
            get
            {
                return @"^(\d{4})$";
            }
        }



        public static string CheckForEndingPunctuation(string Message)
        {
            string OriginalMessage = Message;
            try
            {
                if (string.IsNullOrWhiteSpace(Message) == false && (Message.EndsWith(".") == false || Message.EndsWith("!") == false || Message.EndsWith("?") == false))
                    Message += ".";
            }
            catch (Exception ex)
            {
                Message = OriginalMessage;
            }

            return Message;
        }
        public static string RemoveAllLineBreaks(string Data)
        {

            // objects
            string AlteredData = "";

            AlteredData = Data;

            if (string.IsNullOrEmpty(AlteredData) == false)
            {
                AlteredData = AlteredData.Replace(Constants.vbCrLf, string.Empty);
                AlteredData = AlteredData.Replace(Constants.vbCr, string.Empty);
                AlteredData = AlteredData.Replace(Constants.vbLf, string.Empty);
            }

            return AlteredData;
        }
        public static string CleanStringForSplit(ref string OriginalString, string Delimiter, bool RemoveSpaces = true, bool RemoveDuplicates = true, bool RemoveTrailingDelim = true, bool RemoveEmptyItems = true, bool RemoveLineFeeds = true)
        {
            try
            {
                string str = OriginalString;

                if (str.Length > 0)
                {
                    if (RemoveSpaces == true)
                        str = str.Replace(" ", "");
                    str = str.Replace(Delimiter + Delimiter, Delimiter);

                    if (RemoveDuplicates == true)
                        str = RemoveDuplicatesFromString(str, Delimiter);
                    if (RemoveTrailingDelim == true)
                        str = RemoveTrailingDelimiter(str, Delimiter);
                    if (RemoveEmptyItems == true)
                    {
                        if (RemoveSpaces == true)
                            str = str.Replace(" ", "");

                        str = str.Replace(Delimiter + Delimiter, Delimiter);
                        str = str.Replace(Delimiter + " " + Delimiter, Delimiter);
                    }
                    if (RemoveLineFeeds == true)
                        str = str.Replace(Environment.NewLine, "").Replace(Constants.vbCrLf, "").Replace(Constants.vbCr, "").Replace(Constants.vbLf, "");

                    return str;
                }
                else
                    return OriginalString;
            }
            catch (Exception ex)
            {
                return OriginalString;
            }
        }
        public static string RemoveTrailingDelimiter(string OriginalString, string delimiter)
        {
            try
            {
                OriginalString = Strings.RTrim(OriginalString);

                if (OriginalString.EndsWith(delimiter))
                    return OriginalString.Substring(0, OriginalString.Length - 1);
                else
                    return OriginalString;
            }
            catch (Exception ex)
            {
                return OriginalString;
            }
        }
        public static string RemoveDuplicatesFromString(string OriginalString, string Delimiter, bool UseDelimiter = false)
        {
            try
            {
                string str = string.Empty;
                string strHolder = string.Empty;
                string[] strArr;

                strArr = OriginalString.Split(System.Convert.ToChar(Delimiter));

                ArrayList arrList = new ArrayList();

                for (int i = 0; i <= strArr.Length - 1; i++)
                {
                    if (!arrList.Contains(strArr[i]))
                        arrList.Add(strArr[i]);
                }
                for (int j = 0; j <= arrList.Count - 1; j++)
                {
                    if (UseDelimiter == true)
                        str += arrList[j].ToString() + Delimiter;
                    else
                        str += arrList[j].ToString() + ",";
                }

                str = str.Replace(Delimiter + Delimiter, Delimiter);

                if (str.EndsWith(Delimiter))
                    str = str.Substring(0, str.Length - 1);

                return str;
            }
            catch (Exception ex)
            {
                return OriginalString;
            }
        }
        public static string RemoveIllegalFilenameIllegalCharacters(string Filename)
        {

            // Return System.Text.RegularExpressions.Regex.Replace(Filename, "[^A-Za-z0-9\-/]", "")
            return Filename.Replace("?", "_").Replace("/", "_").Replace(@"\", "_").Replace("\"", "_").Replace("'", "_");
        }
        public static bool ContainsIllegalCharacters(string StringToCheck)
        {
            if (StringToCheck.Contains("?") == true || StringToCheck.Contains("/") == true || StringToCheck.Contains(@"\") == true || StringToCheck.Contains("'") == true || StringToCheck.Contains("&") == true || StringToCheck.Contains("\"") == true)
                return true;
            else
                return false;
        }
        public static string RemoveAllHtmlTags(string SourceText)
        {
            return System.Text.RegularExpressions.Regex.Replace(SourceText, "<.*?>", "");
        }
        public static string JavascriptSafe(string MakeItSafe)
        {
            try
            {
                return System.Web.HttpUtility.JavaScriptStringEncode(MakeItSafe);
            }
            catch (Exception ex)
            {
                return MakeItSafe;
            }
        }
        public static string ByteArrayToString(byte[] ByteArray)
        {

            // objects
            System.Text.StringBuilder StringBuilder = null;

            StringBuilder = new System.Text.StringBuilder(ByteArray.Length * 2);

            for (int ByteArrayCounter = 0; ByteArrayCounter <= ByteArray.Length - 1; ByteArrayCounter++)

                StringBuilder.Append(ByteArray[ByteArrayCounter].ToString("X2"));

            return StringBuilder.ToString().ToLower();
        }
        public static string ConvertIntegerToString(int IntegerValue)
        {
            return IntegerValue.ToString();
        }
        public static bool IsValidEmailAddress(string EmailAddress)
        {
            System.Text.RegularExpressions.Regex Regex = null;

            if (EmailAddress != null)
            {
                Regex = new System.Text.RegularExpressions.Regex(AdvantageFramework.Core.StringUtilities.Methods.EmailRegularExpressionString, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                return Regex.IsMatch(EmailAddress);
            }
            else
                return false;
        }
        public static bool IsValidFullZipCode(ref string FullZipCode)
        {

            // objects
            string ConvertedFullZipCode = "";
            string Zip = "";
            string Zip2 = "";
            bool IsValid = false;

            if (FullZipCode != null)
            {
                ConvertedFullZipCode = RemoveAllNonNumeric(FullZipCode.Replace(" ", ""));

                if (ConvertedFullZipCode.Length == 9)
                {
                    IsValid = true;
                    FullZipCode = ConvertedFullZipCode.Substring(0, 5) + "-" + ConvertedFullZipCode.Substring(5, 4);
                }
            }

            return IsValid;
        }
        public static bool IsValidZip2(string Zip2)
        {
            return IsRegularExpressionAMatch(Zip2RegularExpressionString, Zip2);
        }
        public static bool IsValidZip(string Zip)
        {
            return IsRegularExpressionAMatch(ZipRegularExpressionString, Zip);
        }
        public static string ConvertPhoneNumber(string PhoneNumber, ref bool ValidPhoneNumber)
        {

            // objects
            string ConvertedPhoneNumber = "";

            ValidPhoneNumber = false;

            ConvertedPhoneNumber = RemoveAllNonNumeric(PhoneNumber);

            if (ConvertedPhoneNumber.Length == 10)
            {
                ConvertedPhoneNumber = "(" + ConvertedPhoneNumber.Substring(0, 3) + ")" + ConvertedPhoneNumber.Substring(3, 3) + "-" + ConvertedPhoneNumber.Substring(6, 4);

                ValidPhoneNumber = IsRegularExpressionAMatch(PhoneNumberRegularExpressionString, ConvertedPhoneNumber);
            }
            else if (ConvertedPhoneNumber.Length == 7)
            {
                ConvertedPhoneNumber = ConvertedPhoneNumber.Substring(0, 3) + "-" + ConvertedPhoneNumber.Substring(3, 4);

                ValidPhoneNumber = IsRegularExpressionAMatch(PhoneNumber7DigitRegularExpressionString, ConvertedPhoneNumber);
            }

            if (!ValidPhoneNumber)
                ConvertedPhoneNumber = PhoneNumber;

            return ConvertedPhoneNumber;
        }
        public static bool IsValidPhoneNumber(ref string PhoneNumber, bool TryToConvert)
        {

            // objects
            string ConvertedPhoneNumber = "";
            bool ValidPhoneNumber = false;

            ValidPhoneNumber = IsRegularExpressionAMatch(PhoneNumberRegularExpressionString, PhoneNumber);

            if (!ValidPhoneNumber)
                ValidPhoneNumber = IsRegularExpressionAMatch(PhoneNumber7DigitRegularExpressionString, PhoneNumber);

            if (!ValidPhoneNumber && TryToConvert)
            {
                ConvertedPhoneNumber = ConvertPhoneNumber(PhoneNumber, ref ValidPhoneNumber);

                if (ValidPhoneNumber)
                    PhoneNumber = ConvertedPhoneNumber;
            }

            return ValidPhoneNumber;
        }
        public static string Decrypt(string StringValue)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(StringValue) == false)
                {
                    // objects
                    byte[] HashInput = null;

                    HashInput = Convert.FromBase64String(StringValue);

                    return System.Text.ASCIIEncoding.ASCII.GetString(HashInput);
                }
                else
                    return StringValue;
            }
            catch (Exception ex)
            {
                return StringValue;
            }
        }
        public static string Encrypt(string StringValue)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(StringValue) == false)
                {
                    // objects
                    byte[] HashInput = null;

                    HashInput = System.Text.ASCIIEncoding.ASCII.GetBytes(StringValue);

                    return Convert.ToBase64String(HashInput);
                }
                else
                    return StringValue;
            }
            catch (Exception ex)
            {
                return StringValue;
            }
        }
        public static string URLSafeEncrypt(string ClearText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ClearText) == false)
                {
                    string EncryptedText = "";
                    string EncryptionKey = "";
                    byte[] ClearBytes = null;
                    System.Security.Cryptography.Rfc2898DeriveBytes Rfc2898DeriveBytes = null;

                    EncryptionKey = "MAKV2SPBNI99212";
                    ClearBytes = System.Text.Encoding.Unicode.GetBytes(ClearText);

                    using (System.Security.Cryptography.Aes Aes = System.Security.Cryptography.Aes.Create())
                    {
                        Rfc2898DeriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                        Aes.Key = Rfc2898DeriveBytes.GetBytes(32);
                        Aes.IV = Rfc2898DeriveBytes.GetBytes(16);

                        using (System.IO.MemoryStream MemoryStream = new System.IO.MemoryStream())
                        {
                            using (System.Security.Cryptography.CryptoStream CryptoStream = new System.Security.Cryptography.CryptoStream(MemoryStream, Aes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                            {
                                CryptoStream.Write(ClearBytes, 0, ClearBytes.Length);
                                CryptoStream.Close();
                            }

                            EncryptedText = Convert.ToBase64String(MemoryStream.ToArray());
                        }
                    }

                    return EncryptedText;
                }
                else
                    return ClearText;
            }
            catch (Exception ex)
            {
                return ClearText;
            }
        }
        public static string URLSafeDecrypt(string EncryptedText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(EncryptedText) == false)
                {
                    string DecryptedText = "";
                    string EncryptionKey = "";
                    byte[] EncryptedBytes = null;
                    System.Security.Cryptography.Rfc2898DeriveBytes Rfc2898DeriveBytes = null;

                    EncryptionKey = "MAKV2SPBNI99212";
                    EncryptedText = EncryptedText.Replace(" ", "+");
                    EncryptedBytes = Convert.FromBase64String(EncryptedText);

                    using (System.Security.Cryptography.Aes Aes = System.Security.Cryptography.Aes.Create())
                    {
                        Rfc2898DeriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        Aes.Key = Rfc2898DeriveBytes.GetBytes(32);
                        Aes.IV = Rfc2898DeriveBytes.GetBytes(16);

                        using (System.IO.MemoryStream MemoryStream = new System.IO.MemoryStream())
                        {
                            using (System.Security.Cryptography.CryptoStream CryptoStream = new System.Security.Cryptography.CryptoStream(MemoryStream, Aes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                            {
                                CryptoStream.Write(EncryptedBytes, 0, EncryptedBytes.Length);
                                CryptoStream.Close();
                            }

                            DecryptedText = System.Text.Encoding.Unicode.GetString(MemoryStream.ToArray());
                        }
                    }

                    return DecryptedText;
                }
                else
                    return EncryptedText;
            }
            catch (Exception ex)
            {
                return EncryptedText;
            }
        }
        public static string RijndaelSimpleEncryptPO(string StringToEncrypt)
        {
            try
            {
                string s = StringToEncrypt.Trim();
                // If s <> "" Then
                // s = Encrypt(s)
                // End If
                // 'Dim sec As New cSecurity(HttpContext.Current.Session("ConnString"))
                // 's = sec.Encrypt("MyPOKey", s)
                int i = 1;
                string StrChar = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (i = 1; i <= Strings.Len(StringToEncrypt); i++)
                {
                    StrChar = Microsoft.VisualBasic.Strings.Mid(StringToEncrypt, i, 1);
                    if (Information.IsNumeric(StrChar) == true)
                    {
                        switch (System.Convert.ToInt32(StrChar))
                        {
                            case 0:
                                {
                                    StrChar = "T";
                                    break;
                                }

                            case 1:
                                {
                                    StrChar = "u";
                                    break;
                                }

                            case 2:
                                {
                                    StrChar = "y";
                                    break;
                                }

                            case 3:
                                {
                                    StrChar = "Z";
                                    break;
                                }

                            case 4:
                                {
                                    StrChar = "b";
                                    break;
                                }

                            case 5:
                                {
                                    StrChar = "A";
                                    break;
                                }

                            case 6:
                                {
                                    StrChar = "P";
                                    break;
                                }

                            case 7:
                                {
                                    StrChar = "S";
                                    break;
                                }

                            case 8:
                                {
                                    StrChar = "m";
                                    break;
                                }

                            case 9:
                                {
                                    StrChar = "r";
                                    break;
                                }
                        }
                    }
                    sb.Append(StrChar);
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return StringToEncrypt;
            }
        }
        public static string RijndaelSimpleDecryptPO(string StringToDecrypt)
        {
            try
            {
                string s = StringToDecrypt.Trim();
                // If s <> "" Then
                // s = Decrypt(s)
                // End If
                // 'Dim sec As New cSecurity(HttpContext.Current.Session("ConnString"))
                // 's = sec.Decrypt("MyPOKey", s)
                int i = 1;
                string StrChar = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (i = 1; i <= Strings.Len(StringToDecrypt); i++)
                {
                    StrChar = Microsoft.VisualBasic.Strings.Mid(StringToDecrypt, i, 1);
                    if (Information.IsNumeric(StrChar) == false)
                    {
                        switch (StrChar)
                        {
                            case "T":
                                {
                                    StrChar = "0";
                                    break;
                                }

                            case "u":
                                {
                                    StrChar = "1";
                                    break;
                                }

                            case "y":
                                {
                                    StrChar = "2";
                                    break;
                                }

                            case "Z":
                                {
                                    StrChar = "3";
                                    break;
                                }

                            case "b":
                                {
                                    StrChar = "4";
                                    break;
                                }

                            case "A":
                                {
                                    StrChar = "5";
                                    break;
                                }

                            case "P":
                                {
                                    StrChar = "6";
                                    break;
                                }

                            case "S":
                                {
                                    StrChar = "7";
                                    break;
                                }

                            case "m":
                                {
                                    StrChar = "8";
                                    break;
                                }

                            case "r":
                                {
                                    StrChar = "9";
                                    break;
                                }
                        }
                    }
                    sb.Append(StrChar);
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static string GenerateSHA256ManagedHash(string SourceText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SourceText) == false)
                {
                    // objects
                    System.Text.UnicodeEncoding UnicodeEncoding = null;
                    byte[] ByteSourceText = null;
                    System.Security.Cryptography.SHA256Managed SHA256Managed = null;
                    byte[] ByteHash = null;

                    UnicodeEncoding = new System.Text.UnicodeEncoding();

                    ByteSourceText = UnicodeEncoding.GetBytes(SourceText);

                    SHA256Managed = new System.Security.Cryptography.SHA256Managed();

                    ByteHash = SHA256Managed.ComputeHash(ByteSourceText);

                    return Convert.ToBase64String(ByteHash);
                }
                else
                    return SourceText;
            }
            catch (Exception ex)
            {
                return SourceText;
            }
        }
        // <summary>
        // Encrypts specified plaintext using Rijndael symmetric key algorithm
        // and returns a base64-encoded result.
        // </summary>
        // <param name="plainText">
        // Plaintext value to be encrypted.
        // </param>
        // <param name="passPhrase">
        // Passphrase from which a pseudo-random password will be derived. The 
        // derived password will be used to generate the encryption key. 
        // Passphrase can be any string. In this example we assume that this 
        // passphrase is an ASCII string.
        // </param>
        // <param name="saltValue">
        // Salt value used along with passphrase to generate password. Salt can 
        // be any string. In this example we assume that salt is an ASCII string.
        // </param>
        // <param name="hashAlgorithm">
        // Hash algorithm used to generate password. Allowed values are: "MD5" and
        // "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
        // </param>
        // <param name="passwordIterations">
        // Number of iterations used to generate password. One or two iterations
        // should be enough.
        // </param>
        // <param name="initVector">
        // Initialization vector (or IV). This value is required to encrypt the 
        // first block of plaintext data. For RijndaelManaged class IV must be 
        // exactly 16 ASCII characters long.
        // </param>
        // <param name="keySize">
        // Size of encryption key in bits. Allowed values are: 128, 192, and 256. 
        // Longer keys are more secure than shorter keys.
        // </param>
        // <returns>
        // Encrypted value formatted as a base64-encoded string.
        // </returns>
        public static string RijndaelSimpleEncrypt(string plainText)
        {
            try
            {
                string passPhrase = "@dV@nT@G3";
                string saltValue = "s@1tV@lu3";
                string hashAlgorithm = "SHA1";
                Int16 passwordIterations = 2;                  // can be any number
                string initVector = "@1B2C3D4E5F6G7H8"; // must be 16 bytes
                Int16 keySize = 256;

                // Convert strings into byte arrays.
                // Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
                // encoding.
                byte[] initVectorBytes;
                initVectorBytes = System.Text.Encoding.ASCII.GetBytes(initVector);

                byte[] saltValueBytes;
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(saltValue);

                // Convert our plaintext into a byte array.
                // Let us assume that plaintext contains UTF8-encoded characters.
                byte[] plainTextBytes;
                plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

                // First, we must create a password, from which the key will be derived.
                // This password will be generated from the specified passphrase and 
                // salt value. The password will be created using the specified hash 
                // algorithm. Password creation can be done in several iterations.
                System.Security.Cryptography.PasswordDeriveBytes password;
                password = new System.Security.Cryptography.PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                byte[] keyBytes;
                // Type or member is obsolete
                keyBytes = password.GetBytes((int)(keySize / (double)8));
                // Type or member is obsolete

                // Create uninitialized Rijndael encryption object.
                System.Security.Cryptography.RijndaelManaged symmetricKey;
                symmetricKey = new System.Security.Cryptography.RijndaelManaged();

                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC;

                // Generate encryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                System.Security.Cryptography.ICryptoTransform encryptor;
                encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

                // Define memory stream which will be used to hold encrypted data.
                System.IO.MemoryStream memoryStream;
                memoryStream = new System.IO.MemoryStream();

                // Define cryptographic stream (always use Write mode for encryption).
                System.Security.Cryptography.CryptoStream cryptoStream;
                cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, encryptor, System.Security.Cryptography.CryptoStreamMode.Write);
                // Start encrypting.
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                // Finish encrypting.
                cryptoStream.FlushFinalBlock();

                // Convert our encrypted data from a memory stream into a byte array.
                byte[] cipherTextBytes;
                cipherTextBytes = memoryStream.ToArray();

                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();

                // Convert encrypted data into a base64-encoded string.
                string cipherText;
                cipherText = Convert.ToBase64String(cipherTextBytes);

                // Return encrypted string.
                return cipherText;
            }
            catch (Exception ex)
            {
                // Return plainText
                return plainText;
            }
        }
        // <summary>
        // Decrypts specified ciphertext using Rijndael symmetric key algorithm.
        // </summary>
        // <param name="cipherText">
        // Base64-formatted ciphertext value.
        // </param>
        // <param name="passPhrase">
        // Passphrase from which a pseudo-random password will be derived. The 
        // derived password will be used to generate the encryption key. 
        // Passphrase can be any string. In this example we assume that this 
        // passphrase is an ASCII string.
        // </param>
        // <param name="saltValue">
        // Salt value used along with passphrase to generate password. Salt can 
        // be any string. In this example we assume that salt is an ASCII string.
        // </param>
        // <param name="hashAlgorithm">
        // Hash algorithm used to generate password. Allowed values are: "MD5" and
        // "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
        // </param>
        // <param name="passwordIterations">
        // Number of iterations used to generate password. One or two iterations
        // should be enough.
        // </param>
        // <param name="initVector">
        // Initialization vector (or IV). This value is required to encrypt the 
        // first block of plaintext data. For RijndaelManaged class IV must be 
        // exactly 16 ASCII characters long.
        // </param>
        // <param name="keySize">
        // Size of encryption key in bits. Allowed values are: 128, 192, and 256. 
        // Longer keys are more secure than shorter keys.
        // </param>
        // <returns>
        // Decrypted string value.
        // </returns>
        // <remarks>
        // Most of the logic in this function is similar to the Encrypt 
        // logic. In order for decryption to work, all parameters of this function
        // - except cipherText value - must match the corresponding parameters of 
        // the Encrypt function which was called to generate the 
        // ciphertext.
        // </remarks>
        public static string RijndaelSimpleDecrypt(string cipherText)
        {
            try
            {
                if (cipherText == "")
                    return "";
                string passPhrase = "@dV@nT@G3";
                string saltValue = "s@1tV@lu3";
                string hashAlgorithm = "SHA1";
                Int16 passwordIterations = 2;                  // can be any number
                string initVector = "@1B2C3D4E5F6G7H8"; // must be 16 bytes
                Int16 keySize = 256;

                // Convert strings defining encryption key characteristics into byte
                // arrays. Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                // encoding.
                byte[] initVectorBytes;
                initVectorBytes = System.Text.Encoding.ASCII.GetBytes(initVector);

                byte[] saltValueBytes;
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(saltValue);

                // Convert our ciphertext into a byte array.
                byte[] cipherTextBytes;
                try
                {
                    cipherTextBytes = Convert.FromBase64String(cipherText.Replace(" ", "+"));
                }
                catch (Exception ex)
                {
                    return cipherText;
                }

                // First, we must create a password, from which the key will be 
                // derived. This password will be generated from the specified 
                // passphrase and salt value. The password will be created using
                // the specified hash algorithm. Password creation can be done in
                // several iterations.
                System.Security.Cryptography.PasswordDeriveBytes password;
                password = new System.Security.Cryptography.PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                byte[] keyBytes;

                // Type or member is obsolete
                keyBytes = password.GetBytes((int)(keySize / (double)8));
                // Type or member is obsolete

                // Create uninitialized Rijndael encryption object.
                System.Security.Cryptography.RijndaelManaged symmetricKey;
                symmetricKey = new System.Security.Cryptography.RijndaelManaged();

                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC;

                // Generate decryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                System.Security.Cryptography.ICryptoTransform decryptor;
                decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                // Define memory stream which will be used to hold encrypted data.
                System.IO.MemoryStream memoryStream;
                memoryStream = new System.IO.MemoryStream(cipherTextBytes);

                // Define memory stream which will be used to hold encrypted data.
                System.Security.Cryptography.CryptoStream cryptoStream;
                cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, decryptor, System.Security.Cryptography.CryptoStreamMode.Read);

                // Since at this point we don't know what the size of decrypted data
                // will be, allocate the buffer long enough to hold ciphertext;
                // plaintext is never longer than ciphertext.
                byte[] plainTextBytes;
                plainTextBytes = new byte[cipherTextBytes.Length + 1];

                // Start decrypting.
                int decryptedByteCount;
                decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();

                // Convert decrypted data into a string. 
                // Let us assume that the original plaintext string was UTF8-encoded.
                string plainText;
                plainText = System.Text.Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                // Return decrypted string.
                return plainText;
            }
            catch (Exception ex)
            {
                // Return cipherText
                return cipherText;
            }
        }
        public static string AppendTrailingCharacter(string InitialString, string AppendCharacter)
        {
            if (InitialString.Length > 0)
            {
                if (InitialString.Substring(InitialString.Length - 1) != AppendCharacter)
                    InitialString += AppendCharacter;
            }

            return InitialString;
        }
        public static bool IsValidDecimal(string SourceText, long Precision, long Scale)
        {

            // objects
            bool IsValid = false;
            string NumberString = "";
            string NumberDecimalSeparator = "";

            NumberString = SourceText;

            try
            {
                NumberDecimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            }
            catch (Exception ex)
            {
                NumberDecimalSeparator = "";
            }

            if (NumberDecimalSeparator == "")
                NumberDecimalSeparator = ".";

            try
            {
                IsValid = IsRegularExpressionAMatch(@"^[-]?\d{1," + (Precision - Scale) + @"}(\" + NumberDecimalSeparator + @"\d{1," + Scale + "})?$", NumberString);
            }
            catch (Exception ex)
            {
                IsValid = false;
            }

            try
            {
                if (IsValid == false)
                {
                    if (System.Convert.ToDecimal(SourceText) == Math.Round(System.Convert.ToDecimal(SourceText), System.Convert.ToInt32(Scale), MidpointRounding.AwayFromZero))
                        IsValid = true;
                }
            }
            catch (Exception ex)
            {
            }

            return IsValid;
        }
        public static string FormatNumberString(string SourceText, long Precision, long Scale)
        {

            // objects
            string NumberString = "";
            string[] NumberDecimalSplit = null;
            string NumberDecimalSeparator = "";

            try
            {
                NumberString = SourceText;

                try
                {
                    NumberDecimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                }
                catch (Exception ex)
                {
                    NumberDecimalSeparator = "";
                }

                if (NumberDecimalSeparator == "")
                    NumberDecimalSeparator = ".";

                if (IsRegularExpressionAMatch(@"(?!^0*$)(?!^0*\" + NumberDecimalSeparator + @"0*$)^\d{1," + (Precision - Scale) + @"}(\" + NumberDecimalSeparator + @"\d{1," + Scale + "})?$", NumberString) == false)
                {
                    if (NumberString.Contains(NumberDecimalSeparator))
                    {
                        NumberDecimalSplit = NumberString.Split(NumberDecimalSeparator);

                        if (NumberDecimalSplit.Length == 2)
                        {
                            if (NumberDecimalSplit[0].Length > (Precision - Scale))
                                NumberDecimalSplit[0] = NumberDecimalSplit[0].Substring(0, (int)(Precision - Scale));

                            if (NumberDecimalSplit[1].Length > Scale)
                                NumberDecimalSplit[1] = NumberDecimalSplit[1].Substring(0, (int)Scale);

                            NumberString = string.Join(NumberDecimalSeparator, NumberDecimalSplit);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(NumberString) && NumberString.Length >= (Precision - Scale))
                            NumberString = NumberString.Substring(0, (int)(Precision - Scale));

                        NumberString = PadWithCharacter(NumberString + NumberDecimalSeparator, (int)Precision + 1, "0");
                    }
                }
            }
            catch (Exception ex)
            {
                NumberString = SourceText;
            }
            return NumberString;
        }
        public static string RemoveAllNonAlpha(string SourceText, string DefaultReturn = "")
        {
            try
            {
                if (string.IsNullOrEmpty(SourceText) == false)
                    return System.Text.RegularExpressions.Regex.Replace(SourceText, "[^a-zA-Z]", "");
                else
                    return DefaultReturn;
            }
            catch (Exception ex)
            {
                return DefaultReturn;
            }
        }
        public static string RemoveAllNonNumeric(string SourceText, string DefaultReturn = "")
        {
            try
            {
                if (string.IsNullOrEmpty(SourceText) == false)
                    return System.Text.RegularExpressions.Regex.Replace(SourceText, "[^0-9]", "");
                else
                    return DefaultReturn;
            }
            catch (Exception ex)
            {
                return DefaultReturn;
            }
        }
        public static string RemoveAllNonAlphaNumeric(string SourceText, string DefaultReturn = "")
        {
            try
            {
                if (string.IsNullOrEmpty(SourceText) == false)
                    return System.Text.RegularExpressions.Regex.Replace(SourceText, "[^a-zA-Z0-9]", "");
                else
                    return DefaultReturn;
            }
            catch (Exception ex)
            {
                return DefaultReturn;
            }
        }

        public static string GetNameAsWords(string Value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Value) == false)
                {
                    // objects
                    string NewName = "";
                    int CharIndex = 0;
                    //string ThisCharacter = "";
                    char LastCharacter = (char)0x00;

                    if (string.IsNullOrEmpty(Value) == false)
                    {
                        foreach (var ThisCharacter in Value)
                        {
                            switch (ThisCharacter)
                            {
                                case object _ when 'A' <= ThisCharacter && ThisCharacter <= 'Z':
                                case object _ when 0 <= ThisCharacter && ThisCharacter <= 9:
                                    {
                                        switch (LastCharacter)
                                        {
                                            case object _ when 'A' <= LastCharacter && LastCharacter <= 'Z':
                                            case ' ':
                                            case (char)0x00:
                                                {
                                                    if (CharIndex + 1 < Value.Length && Value[CharIndex + 1].ToString().ToLower() == Value[CharIndex + 1].ToString())
                                                        NewName += " " + ThisCharacter;
                                                    else
                                                        NewName += ThisCharacter;
                                                    break;
                                                }

                                            default:
                                                {
                                                    if (Information.IsNumeric(LastCharacter) && Information.IsNumeric(ThisCharacter))
                                                        NewName += ThisCharacter;
                                                    else
                                                        NewName += " " + ThisCharacter;
                                                    break;
                                                }
                                        }

                                        break;
                                    }

                                default:
                                    {
                                        NewName += ThisCharacter;
                                        break;
                                    }
                            }

                            LastCharacter = ThisCharacter;

                            CharIndex += 1;
                        }
                    }

                    return NewName.TrimStart(' ');
                }
                else
                    return Value;
            }
            catch (Exception ex)
            {
                return Value;
            }
        }
        public static string ConvertSocialSecurityNumber(string SocialSecurityNumber, ref bool IsValidSSN)
        {

            // objects
            string ConvertedSSN = "";

            IsValidSSN = false;

            ConvertedSSN = RemoveAllNonNumeric(SocialSecurityNumber);

            if (ConvertedSSN.Length == 9)
            {
                ConvertedSSN = ConvertedSSN.Substring(0, 3) + "-" + ConvertedSSN.Substring(3, 2) + "-" + ConvertedSSN.Substring(5, 4);

                IsValidSSN = AdvantageFramework.Core.StringUtilities.Methods.IsRegularExpressionAMatch(AdvantageFramework.Core.StringUtilities.Methods.SocialSecurityNumberRegularExpressionString, ConvertedSSN);

                if (!IsValidSSN)
                    ConvertedSSN = SocialSecurityNumber;
            }

            return ConvertedSSN;
        }
        public static bool IsValidSocialSecurityNumber(ref string SocialSecurityNumber, bool TryToConvert)
        {

            // objects
            string ConvertedSSN = "";
            bool IsValidSSN = false;

            IsValidSSN = AdvantageFramework.Core.StringUtilities.Methods.IsRegularExpressionAMatch(AdvantageFramework.Core.StringUtilities.Methods.SocialSecurityNumberRegularExpressionString, SocialSecurityNumber);

            if (IsValidSSN == false && TryToConvert)
            {
                ConvertedSSN = ConvertSocialSecurityNumber(SocialSecurityNumber, ref IsValidSSN);

                if (IsValidSSN)
                    SocialSecurityNumber = ConvertedSSN;
            }

            return IsValidSSN;
        }
        public static bool IsRegularExpressionAMatch(string RegularExpression, string Value)
        {

            // objects
            System.Text.RegularExpressions.Regex Regex = null;

            if (Value != null)
            {
                Regex = new System.Text.RegularExpressions.Regex(RegularExpression);

                return Regex.IsMatch(Value);
            }
            else
                return false;
        }
        public static string PadWithCharacter(string Data, int FieldSize, string Character = " ", bool Prefix = false, bool TrimIfTooLong = true)
        {

            if (Data.Length <= FieldSize)
            {
                for (int Count = 1; Count <= FieldSize - Data.Length; Count++)

                    Data = Interaction.IIf(Prefix, Character, "") + Data + Interaction.IIf(Prefix, "", Character);
            }
            else if (TrimIfTooLong)
                Data = Strings.Left(Data, FieldSize);

            return Data;
        }
        public static string CreateCommaDelimitedString(List<int> IntegerList)
        {
            StringBuilder StringBuilderLine = new StringBuilder();

            foreach (var IntegerValue in IntegerList)
            {
                if (StringBuilderLine.ToString() == "")
                    StringBuilderLine.Append(IntegerValue.ToString());
                else
                    StringBuilderLine.Append("," + IntegerValue.ToString());
            }

            return StringBuilderLine.ToString();
        }
        public static string Truncate(string Text, int Length)
        {
            if (Text.Length > Length)
                return Text.Substring(0, Length).Trim() + "...";
            else
                return Text;
        }
        public static decimal FormatDecimal(string Number)
        {
            try
            {
                string s = Number;
                s = AdvantageFramework.Core.StringUtilities.Methods.FormatNumber(s);
                return System.Convert.ToDecimal(s);
            }
            catch (Exception ex)
            {
                return default(decimal);
            }
        }
        public static string FormatNumber(string Number)
        {
            try
            {
                string NumberDecimalSeparator = "";
                try
                {
                    NumberDecimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                }
                catch (Exception ex)
                {
                    NumberDecimalSeparator = "";
                }

                string s = Number;

                if (Information.IsNumeric(s) == false & System.Threading.Thread.CurrentThread.CurrentCulture.Name != "en-US")
                {
                    // Culture is set correctly, yet "Number" is not valid
                    // most likely string being passed in is English
                    // HACK!
                    try
                    {
                        s = s.Replace(" ", "");
                        s = s.Replace(",", "");
                        string DecimalSeparator = NumberDecimalSeparator;
                        s = s.Replace(".", DecimalSeparator);
                    }
                    catch (Exception ex)
                    {
                        return Number;
                    }
                }

                return Microsoft.VisualBasic.Strings.FormatNumber(s, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
            }
            catch (Exception ex)
            {
                return Number;
            }
        }
        public static bool AreDatesEqual(DateTime? Date1, DateTime? Date2)
        {

            // objects
            bool DatesEqual = true;

            if (!DateTime.Equals(Date1, Date2))
            {
                if (!(Date1.HasValue && Date2.HasValue && DateTime.Equals(Date1.Value.Date, Date2.Value.Date)))
                    DatesEqual = false;
            }

            return DatesEqual;
        }
        public static string ParseLastDot(string buf)
        {
            string[] bufs;
            string ans;

            if (buf.IndexOf(".") > 0)
            {
                bufs = buf.Split(".");
                ans = bufs[Information.UBound(bufs)];
            }
            else
                ans = buf;

            return ans;
        }
        public static string FullErrorToString(Exception Ex)
        {
            System.Text.StringBuilder ErrorString = new System.Text.StringBuilder();

            if (Ex != null)
            {
                if (string.IsNullOrWhiteSpace(Ex.Message) == false)
                    ErrorString.Append(Ex.Message);

                if (Ex.InnerException != null)
                {
                    if (string.IsNullOrWhiteSpace(Ex.InnerException.Message) == false)
                    {
                        ErrorString.Append(Environment.NewLine);
                        ErrorString.Append(Ex.InnerException.Message);
                    }
                }
            }

            return ErrorString.ToString();
        }



        public static object ToDbNullIfNullOrWhiteSpace(this string aString)
        {
            if (string.IsNullOrWhiteSpace(aString))
                return DBNull.Value;
            else
                return aString;
        }
        public static string ToEmptyStringIfNullOrWhiteSpace(this string aString)
        {
            if (string.IsNullOrWhiteSpace(aString))
                return string.Empty;
            else
                return aString;
        }
        public static int? ParseDigits(this string aString)
        {

            // objects
            string Digits = "";

            if (!string.IsNullOrWhiteSpace(aString))
            {
                foreach (char c in aString.ToCharArray())
                {
                    if (char.IsDigit(c))
                        Digits += c;
                }
            }

            if (!string.IsNullOrWhiteSpace(Digits))
                return int.Parse(Digits);
            else
                return default(int?);
        }
    }
}
