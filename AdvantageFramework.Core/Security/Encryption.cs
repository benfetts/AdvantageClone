using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;

namespace AdvantageFramework.Core.Security
{
    public partial class Encryption
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private const string Aes256Key = "W12B&YHNOD5M(IK<64JK&YHN7UJMVH4R";
        // Private Const PBKDF_SHA256Key As String = "3A1A934CB7F3F931FD46AA41727A5654"

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static string Encrypt(string PlainText)
        {
            string EncryptRet = default;
            string EncryptedText = string.Empty;
            byte[] SourceBytes = null;
            try
            {
                using (var Aes = System.Security.Cryptography.Aes.Create())
                {
                    using (var Rfc2898DeriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(Aes256Key, new byte[] { 0x65, 0x64, 0x65, 0x45, 0xF1, 0x61, 0x6E, 0x76, 0x20, 0x0, 0x64, 0x3, 0x76 }))
                    {
                        Aes.BlockSize = 128;
                        Aes.KeySize = 256;
                        Aes.IV = Rfc2898DeriveBytes.GetBytes(16);
                        Aes.Key = Rfc2898DeriveBytes.GetBytes(32);
                        Aes.Mode = System.Security.Cryptography.CipherMode.CBC;
                        Aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                        SourceBytes = Encoding.Unicode.GetBytes(PlainText);
                        using (var MemoryStream = new MemoryStream())
                        {
                            using (var CryptoStream = new System.Security.Cryptography.CryptoStream(MemoryStream, Aes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                            {
                                CryptoStream.Write(SourceBytes, 0, SourceBytes.Length);
                            }

                            EncryptedText = Convert.ToBase64String(MemoryStream.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EncryptedText = PlainText;
            }

            EncryptRet = EncryptedText;
            return EncryptRet;
        }

        public static string Decrypt(string EncryptedText)
        {
            string DecryptRet = default;
            string DecryptedText = string.Empty;
            byte[] SourceBytes = null;
            try
            {
                EncryptedText = EncryptedText.Replace(" ", "+");
                using (var Aes = System.Security.Cryptography.Aes.Create())
                {
                    using (var Rfc2898DeriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(Aes256Key, new byte[] { 0x65, 0x64, 0x65, 0x45, 0xF1, 0x61, 0x6E, 0x76, 0x20, 0x0, 0x64, 0x3, 0x76 }))
                    {
                        Aes.BlockSize = 128;
                        Aes.KeySize = 256;
                        Aes.IV = Rfc2898DeriveBytes.GetBytes(16);
                        Aes.Key = Rfc2898DeriveBytes.GetBytes(32);
                        Aes.Mode = System.Security.Cryptography.CipherMode.CBC;
                        Aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                        SourceBytes = Convert.FromBase64String(EncryptedText);
                        using (var MemoryStream = new MemoryStream())
                        {
                            using (var CryptoStream = new System.Security.Cryptography.CryptoStream(MemoryStream, Aes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                            {
                                CryptoStream.Write(SourceBytes, 0, SourceBytes.Length);
                            }

                            DecryptedText = Encoding.Unicode.GetString(MemoryStream.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DecryptedText = EncryptedText;
            }

            DecryptRet = DecryptedText;
            return DecryptRet;
        }

        public static string EncryptPassword(string PlainText)
        {
            string EncryptPasswordRet = default;

            // objects
            string EncryptedText = string.Empty;
            byte[] ClearBytes = null;
            System.Security.Cryptography.Rfc2898DeriveBytes Rfc2898DeriveBytes = null;
            byte[] EncryptedBytes = null;
            try
            {
                ClearBytes = Encoding.Unicode.GetBytes(PlainText);
                Rfc2898DeriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(PlainText, new byte[] { 0x64, 0x6E, 0x20, 0x45, 0x65, 0x0, 0x64, 0x76, 0xF1, 0x61, 0x65, 0x3, 0x76 }, 1000, System.Security.Cryptography.HashAlgorithmName.SHA256);
                EncryptedBytes = Rfc2898DeriveBytes.GetBytes(32);
                EncryptedText = Convert.ToBase64String(EncryptedBytes);
            }
            catch (Exception ex)
            {
                EncryptedText = PlainText;
            }

            EncryptPasswordRet = EncryptedText;
            return EncryptPasswordRet;
        }

        public static string ASCIIDecoding(string StringValue)
        {
            string ASCIIDecodingRet = default;

            // objects
            string Decoded = string.Empty;
            byte[] HashInput = null;
            try
            {
                if (string.IsNullOrWhiteSpace(StringValue) == false)
                {
                    HashInput = Convert.FromBase64String(StringValue);
                    Decoded = Encoding.ASCII.GetString(HashInput);
                }
                else
                {
                    Decoded = StringValue;
                }
            }
            catch (Exception ex)
            {
                Decoded = StringValue;
            }

            ASCIIDecodingRet = Decoded;
            return ASCIIDecodingRet;
        }

        public static string ASCIIEncoding(string StringValue)
        {
            string ASCIIEncodingRet = default;

            // objects
            string Encoded = string.Empty;
            byte[] HashInput = null;
            try
            {
                if (string.IsNullOrWhiteSpace(StringValue) == false)
                {
                    HashInput = Encoding.ASCII.GetBytes(StringValue);
                    Encoded = Convert.ToBase64String(HashInput);
                }
                else
                {
                    Encoded = StringValue;
                }
            }
            catch (Exception ex)
            {
                Encoded = StringValue;
            }

            ASCIIEncodingRet = Encoded;
            return ASCIIEncodingRet;
        }

        public static string EncryptPO(string StringToEncrypt)
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
                var sb = new StringBuilder();
                var loopTo = Strings.Len(StringToEncrypt);
                for (i = 1; i <= loopTo; i++)
                {
                    StrChar = Strings.Mid(StringToEncrypt, i, 1);
                    if (Information.IsNumeric(StrChar) == true)
                    {
                        switch (Conversions.ToInteger(StrChar))
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

        public static string DecryptPO(string StringToDecrypt)
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
                var sb = new StringBuilder();
                var loopTo = Strings.Len(StringToDecrypt);
                for (i = 1; i <= loopTo; i++)
                {
                    StrChar = Strings.Mid(StringToDecrypt, i, 1);
                    if (Information.IsNumeric(StrChar) == false)
                    {
                        switch (StrChar ?? "")
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
                return 0.ToString();
            }
        }

        public static string EncryptLicenseKey(string ClearText)
        {
            string EncryptLicenseKeyRet = default;

            // objects
            byte[] ClearBytes = null;
            System.Security.Cryptography.Rfc2898DeriveBytes Rfc2898DeriveBytes = null;
            byte[] EncryptedBytes = null;
            string EncryptedText = "";
            try
            {
                ClearBytes = Encoding.Unicode.GetBytes(ClearText);
                Rfc2898DeriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes("JustinBieber", new byte[] { 0x45, 0xF1, 0x61, 0x6E, 0x20, 0x0, 0x65, 0x64, 0x76, 0x65, 0x64, 0x3, 0x76 });
                EncryptedBytes = Encrypt(ClearBytes, Rfc2898DeriveBytes.GetBytes(32), Rfc2898DeriveBytes.GetBytes(16));
                EncryptedText = Convert.ToBase64String(EncryptedBytes);
            }
            catch (Exception ex)
            {
                EncryptedText = ClearText;
            }
            finally
            {
                EncryptLicenseKeyRet = EncryptedText;
            }

            return EncryptLicenseKeyRet;
        }

        public static string DecryptLicenseKey(string EncryptedText)
        {
            string DecryptLicenseKeyRet = default;

            // objects
            byte[] CipherBytes = null;
            byte[] DecryptedBytes = null;
            string DecryptedText = "";
            System.Security.Cryptography.Rfc2898DeriveBytes Rfc2898DeriveBytes = null;
            byte[] DB32Bytes = null;
            byte[] DB16Bytes = null;
            try
            {
                EncryptedText = EncryptedText.Replace(" ", "+");
                CipherBytes = Convert.FromBase64String(EncryptedText);
                if (Rfc2898DeriveBytes is null)
                {
                    Rfc2898DeriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes("JustinBieber", new byte[] { 0x45, 0xF1, 0x61, 0x6E, 0x20, 0x0, 0x65, 0x64, 0x76, 0x65, 0x64, 0x3, 0x76 });
                    DB32Bytes = Rfc2898DeriveBytes.GetBytes(32);
                    DB16Bytes = Rfc2898DeriveBytes.GetBytes(16);
                }

                DecryptedBytes = Decrypt(CipherBytes, DB32Bytes, DB16Bytes);
                DecryptedText = Encoding.Unicode.GetString(DecryptedBytes);
            }
            catch (Exception ex)
            {
                DecryptedText = EncryptedText;
            }
            finally
            {
                DecryptLicenseKeyRet = DecryptedText;
            }

            return DecryptLicenseKeyRet;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static string GenerateSHA256ManagedHash(string SourceText)
        {
            string GenerateSHA256ManagedHashRet = default;
            try
            {
                if (string.IsNullOrWhiteSpace(SourceText) == false)
                {
                    // objects
                    UnicodeEncoding UnicodeEncoding = null;
                    byte[] ByteSourceText = null;
                    System.Security.Cryptography.SHA256Managed SHA256Managed = null;
                    byte[] ByteHash = null;
                    UnicodeEncoding = new UnicodeEncoding();
                    ByteSourceText = UnicodeEncoding.GetBytes(SourceText);
                    SHA256Managed = new System.Security.Cryptography.SHA256Managed();
                    ByteHash = SHA256Managed.ComputeHash(ByteSourceText);
                    GenerateSHA256ManagedHashRet = Convert.ToBase64String(ByteHash);
                }
                else
                {
                    return SourceText;
                }
            }
            catch (Exception ex)
            {
                return SourceText;
            }

            return GenerateSHA256ManagedHashRet;
        }

        public static string RijndaelSimpleEncrypt(string plainText)
        {
            string RijndaelSimpleEncryptRet = default;
            try
            {
                string passPhrase = "@dV@nT@G3";
                string saltValue = "s@1tV@lu3";
                string hashAlgorithm = "SHA1";
                short passwordIterations = 2;                  // can be any number
                string initVector = "@1B2C3D4E5F6G7H8"; // must be 16 bytes
                short keySize = 256;

                // Convert strings into byte arrays.
                // Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
                // encoding.
                byte[] initVectorBytes;
                initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes;
                saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                // Convert our plaintext into a byte array.
                // Let us assume that plaintext contains UTF8-encoded characters.
                byte[] plainTextBytes;
                plainTextBytes = Encoding.UTF8.GetBytes(plainText);

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
                keyBytes = password.GetBytes((int)Math.Round(keySize / 8d));
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
                MemoryStream memoryStream;
                memoryStream = new MemoryStream();

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
                RijndaelSimpleEncryptRet = cipherText;
            }
            catch (Exception ex)
            {
                // Return plainText
                RijndaelSimpleEncryptRet = plainText;
            }

            return RijndaelSimpleEncryptRet;
        }

        public static string RijndaelSimpleDecrypt(string cipherText)
        {
            string RijndaelSimpleDecryptRet = default;
            try
            {
                if (string.IsNullOrEmpty(cipherText))
                {
                    return "";
                }

                string passPhrase = "@dV@nT@G3";
                string saltValue = "s@1tV@lu3";
                string hashAlgorithm = "SHA1";
                short passwordIterations = 2;                  // can be any number
                string initVector = "@1B2C3D4E5F6G7H8"; // must be 16 bytes
                short keySize = 256;

                // Convert strings defining encryption key characteristics into byte
                // arrays. Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                // encoding.
                byte[] initVectorBytes;
                initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes;
                saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                // Convert our ciphertext into a byte array.
                string err = Conversions.ToString(false);
                byte[] cipherTextBytes;
                try
                {
                    cipherTextBytes = Convert.FromBase64String(cipherText.Replace(" ", "+"));
                }
                catch (Exception ex)
                {
                    return "";
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
                keyBytes = password.GetBytes((int)Math.Round(keySize / 8d));
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
                MemoryStream memoryStream;
                memoryStream = new MemoryStream(cipherTextBytes);

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
                plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                // Return decrypted string.
                RijndaelSimpleDecryptRet = plainText;
            }
            catch (Exception ex)
            {
                // Return cipherText
                RijndaelSimpleDecryptRet = cipherText;
            }

            return RijndaelSimpleDecryptRet;
        }

        public static string EncryptOld_DONOTUSE(string ClearText)
        {
            string EncryptOld_DONOTUSERet = default;

            // objects
            byte[] ClearBytes = null;
            System.Security.Cryptography.Rfc2898DeriveBytes Rfc2898DeriveBytes = null;
            byte[] EncryptedBytes = null;
            string EncryptedText = "";
            try
            {
                ClearBytes = Encoding.Unicode.GetBytes(ClearText);
                Rfc2898DeriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes("JustinBieber", new byte[] { 0x45, 0xF1, 0x61, 0x6E, 0x20, 0x0, 0x65, 0x64, 0x76, 0x65, 0x64, 0x3, 0x76 });
                EncryptedBytes = Encrypt(ClearBytes, Rfc2898DeriveBytes.GetBytes(32), Rfc2898DeriveBytes.GetBytes(16));
                EncryptedText = Convert.ToBase64String(EncryptedBytes);
            }
            catch (Exception ex)
            {
                EncryptedText = ClearText;
            }
            finally
            {
                EncryptOld_DONOTUSERet = EncryptedText;
            }

            return EncryptOld_DONOTUSERet;
        }

        private static byte[] Encrypt(byte[] ClearBytes, byte[] KeyBytes, byte[] IVBytes)
        {
            byte[] EncryptRet = default;

            // objects
            MemoryStream MemoryStream = null;
            System.Security.Cryptography.CryptoStream CryptoStream = null;
            System.Security.Cryptography.Rijndael Rijndael = null;
            byte[] EncryptedBytes = null;
            try
            {
                MemoryStream = new MemoryStream();
                Rijndael = System.Security.Cryptography.Rijndael.Create();
                Rijndael.Key = KeyBytes;
                Rijndael.IV = IVBytes;
                CryptoStream = new System.Security.Cryptography.CryptoStream(MemoryStream, Rijndael.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                CryptoStream.Write(ClearBytes, 0, ClearBytes.Length);
                CryptoStream.FlushFinalBlock();
                EncryptedBytes = MemoryStream.ToArray();
            }
            catch (Exception ex)
            {
                EncryptedBytes = null;
            }
            finally
            {
                if (CryptoStream is object)
                {
                    CryptoStream.Close();
                }

                EncryptRet = EncryptedBytes;
            }

            return EncryptRet;
        }

        public static string DecryptOld_DONOTUSE(string EncryptedText)
        {
            string DecryptOld_DONOTUSERet = default;

            // objects
            byte[] CipherBytes = null;
            byte[] DecryptedBytes = null;
            string DecryptedText = "";
            System.Security.Cryptography.Rfc2898DeriveBytes Rfc2898DeriveBytes = null;
            byte[] DB32Bytes = null;
            byte[] DB16Bytes = null;
            try
            {
                EncryptedText = EncryptedText.Replace(" ", "+");
                CipherBytes = Convert.FromBase64String(EncryptedText);
                if (Rfc2898DeriveBytes is null)
                {
                    Rfc2898DeriveBytes = new System.Security.Cryptography.Rfc2898DeriveBytes("JustinBieber", new byte[] { 0x45, 0xF1, 0x61, 0x6E, 0x20, 0x0, 0x65, 0x64, 0x76, 0x65, 0x64, 0x3, 0x76 });
                    DB32Bytes = Rfc2898DeriveBytes.GetBytes(32);
                    DB16Bytes = Rfc2898DeriveBytes.GetBytes(16);
                }

                DecryptedBytes = Decrypt(CipherBytes, DB32Bytes, DB16Bytes);
                DecryptedText = Encoding.Unicode.GetString(DecryptedBytes);
            }
            catch (Exception ex)
            {
                DecryptedText = EncryptedText;
            }
            finally
            {
                DecryptOld_DONOTUSERet = DecryptedText;
            }

            return DecryptOld_DONOTUSERet;
        }

        private static byte[] Decrypt(byte[] CipherBytes, byte[] KeyBytes, byte[] IVBytes)
        {
            byte[] DecryptRet = default;

            // objects
            MemoryStream MemoryStream = null;
            System.Security.Cryptography.CryptoStream CryptoStream = null;
            System.Security.Cryptography.Rijndael Rijndael = null;
            byte[] DecryptedBytes = null;
            try
            {
                MemoryStream = new MemoryStream();
                Rijndael = System.Security.Cryptography.Rijndael.Create();
                Rijndael.Key = KeyBytes;
                Rijndael.IV = IVBytes;
                CryptoStream = new System.Security.Cryptography.CryptoStream(MemoryStream, Rijndael.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                CryptoStream.Write(CipherBytes, 0, CipherBytes.Length);
                CryptoStream.FlushFinalBlock();
                DecryptedBytes = MemoryStream.ToArray();
            }
            catch (Exception ex)
            {
                DecryptedBytes = null;
            }
            finally
            {
                if (CryptoStream is object)
                {
                    CryptoStream.Close();
                }

                DecryptRet = DecryptedBytes;
            }

            return DecryptRet;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
