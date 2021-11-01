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

namespace AdvantageFramework.Core.Security
{
    public class Impersonate
    {
        private enum Logon32Options : int
        {
            ProviderDefault = 0,
            LogonInteractive = 2,
            LogonNetwork = 3,
            LogonBatch = 4,
            LogonService = 5,
            LogonUnlock = 7,
            LogonNetworkCleartext = 8,
            LogonNewCredentials = 9
        }

        public static void RunImpersonated(string User,string Domain,string Password,Action action)
        {
            if (!string.IsNullOrWhiteSpace(User))
            {
                Microsoft.Win32.SafeHandles.SafeAccessTokenHandle safeAccessTokenHandle;
                bool returnValue = LogonUser(User, Domain, Password, Logon32Options.LogonInteractive, Logon32Options.ProviderDefault, out safeAccessTokenHandle);

                System.Security.Principal.WindowsIdentity.RunImpersonated(safeAccessTokenHandle, action);
            }
            else
            {
                action();
            }
        }


        public static bool CheckNTAuthentication()
        {
            //string Authentication = null;
            bool IsAuthenticated = false;

            //try
            //{
            //    Authentication = System.Configuration.ConfigurationManager.AppSettings("Authentication");

            //    if (Authentication == "Forms")
            //        IsAuthenticated = false;
            //    else
            //        IsAuthenticated = true;
            //}
            //catch (Exception ex)
            //{
                IsAuthenticated = false;
            //}
            return IsAuthenticated;
        }
        public static bool BeginImpersonation(string UserName, string Domain, string Password)
        {

            // objects
            //IntPtr Token = IntPtr.Zero;
            //IntPtr TokenDuplicate = IntPtr.Zero;
            //System.Security.Principal.WindowsIdentity TempWindowsIdentity = null;
            bool HasBegun = false;
            //long Win32ErrorNumber = default(Long);
            //System.Security.Principal.WindowsIdentity CurrentWindowsIdentity = null;

            //try
            //{
            //    CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();

            //    if (CurrentWindowsIdentity != null)
            //    {
            //        if (CurrentWindowsIdentity.ImpersonationLevel == System.Security.Principal.TokenImpersonationLevel.Impersonation)
            //            _OriginalImpersonationIdentity = CurrentWindowsIdentity;
            //    }

            //    if (RevertToSelf())
            //    {
            //        if (LogonUserA(UserName, Domain, Password, Logon32Options.LogonInteractive, Logon32Options.ProviderDefault, ref Token) != 0)
            //        {
            //            if (DuplicateToken(Token, 2, ref TokenDuplicate) != 0)
            //            {
            //                TempWindowsIdentity = new System.Security.Principal.WindowsIdentity(TokenDuplicate);

            //                _ImpersonationContext = TempWindowsIdentity.Impersonate();

            //                if (_ImpersonationContext != null)
            //                    HasBegun = true;
            //            }
            //        }
            //        else if (LogonUserA(UserName, Domain, AdvantageFramework.StringUtilities.RijndaelSimpleDecrypt(Password), Logon32Options.LogonInteractive, Logon32Options.ProviderDefault, ref Token) != 0)
            //        {
            //            if (DuplicateToken(Token, 2, ref TokenDuplicate) != 0)
            //            {
            //                TempWindowsIdentity = new System.Security.Principal.WindowsIdentity(TokenDuplicate);

            //                _ImpersonationContext = TempWindowsIdentity.Impersonate();

            //                if (_ImpersonationContext != null)
            //                    HasBegun = true;
            //            }
            //        }
            //    }

            //    if (!TokenDuplicate.Equals(IntPtr.Zero))
            //        CloseHandle(TokenDuplicate);

            //    if (!Token.Equals(IntPtr.Zero))
            //        CloseHandle(Token);
            //}
            //catch (Exception ex)
            //{
            //    HasBegun = false;
            //}

            return HasBegun;
        }
        public new static bool BeginImpersonation(/*AdvantageFramework.Security.Session Session*/)
        {

            // objects
            bool HasBegun = false;
            AdvantageFramework.Core.Database.Entities.Agency Agency = null;

            //try
            //{
            //    using (var DbContext = new AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode))
            //    {
            //        Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
            //    }

            //    HasBegun = BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.StringUtilities.RijndaelSimpleDecrypt(Agency.FileSystemPassword));
            //}
            //catch (Exception ex)
            //{
            //    HasBegun = false;
            //}

            return HasBegun;
        }
        public static void EndImpersonation()
        {
            //try
            //{
            //    if (_ImpersonationContext != null)
            //        _ImpersonationContext.Dispose();
            //}
            //catch (Exception ex)
            //{
            //}

            //try
            //{
            //    if (_OriginalImpersonationIdentity != null)
            //        _OriginalImpersonationIdentity.Impersonate();
            //}
            //catch (Exception ex)
            //{
            //}
        }
        //public static void EndImpersonation(System.Security.Principal.WindowsIdentity OriginalIdentity)
        //{
        //    try
        //    {
        //        if (_ImpersonationContext != null)
        //            _ImpersonationContext.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    try
        //    {
        //        if (_OriginalImpersonationIdentity != null)
        //            _OriginalImpersonationIdentity.Impersonate();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}



        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        static extern int LogonUserA(string UserName, string Domain, string Password, int LogonType, int LogonProvider, ref IntPtr Token);
        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        static extern int DuplicateToken(IntPtr ExistingTokenHandle, int ImpersonationLevel, ref IntPtr DuplicateTokenHandle);
        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        static extern long RevertToSelf();
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern long CloseHandle(IntPtr Handle);
        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        private static extern bool LogonUser(String UserName, String Domain, String Password, Logon32Options LogonType, Logon32Options LogonProvider, out Microsoft.Win32.SafeHandles.SafeAccessTokenHandle Token);
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int FormatMessage(int Flags, ref IntPtr Source, int MessageID, int LanguageID, ref String Message, int Size, ref IntPtr Arguments);
        private static string GetErrorMessage(int ErrorCode)
        {
            int FormatMessageAllocateBugger = default(int);
            int FormatMessageIgnoreInserts = default(int);
            int FormatMessageFromSystem = default(int);
            int MessageSize = default(int);
            string Message = null;
            int Flags = default(int);
            IntPtr Source = default(IntPtr);
            IntPtr Arguments = default(IntPtr);

            FormatMessageAllocateBugger = 0x100;
            FormatMessageIgnoreInserts = 0x200;
            FormatMessageFromSystem = 0x1000;
            MessageSize = 255;
            Source = IntPtr.Zero;
            Arguments = IntPtr.Zero;

            Flags = FormatMessageAllocateBugger | FormatMessageFromSystem | FormatMessageIgnoreInserts;

            if (FormatMessage(Flags, ref Source, ErrorCode, 0, ref Message, MessageSize, ref Arguments) == 0)
                throw new System.Exception("Failed to format message for error code " + ErrorCode.ToString() + ". ");

            return Message;
        }
    }
}
