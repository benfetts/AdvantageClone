using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Registry
{
    public static partial class Methods
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public enum LoginRegistrySetting
        {
            [AdvantageFramework.Core.Registry.Attributes.RegistryAttribute(@"\Login\", "Server", "")]
            Server,
            [AdvantageFramework.Core.Registry.Attributes.RegistryAttribute(@"\Login\", "Database", "")]
            Database,
            [AdvantageFramework.Core.Registry.Attributes.RegistryAttribute(@"\Login\", "UseWindowsAuthentication", "False")]
            UseWindowsAuthentication,
            [AdvantageFramework.Core.Registry.Attributes.RegistryAttribute(@"\Login\", "UserName", "")]
            UserName,
            [AdvantageFramework.Core.Registry.Attributes.RegistryAttribute(@"\Login\", "Password", "")]
            Password
        }

        public enum SettingsType
        {
            Service,
            Process
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static string Load(ref Microsoft.Win32.RegistryKey RegistryKey, Enum Enum)
        {
            string LoadRet = default;

            // objects
            string SettingValue = "";
            AdvantageFramework.Core.Registry.Attributes.RegistryAttribute RegistryAttribute = default;
            RegistryAttribute = (Attributes.RegistryAttribute)Attribute.GetCustomAttribute(Enum.GetType().GetField(Enum.ToString()), typeof(AdvantageFramework.Core.Registry.Attributes.RegistryAttribute));
            if (RegistryAttribute is object)
            {
                if (RegistryKey is object)
                {
                    SettingValue = RegistryKey.GetValue(RegistryAttribute.Key, RegistryAttribute.Default).ToString();
                }
                else
                {
                    SettingValue = RegistryAttribute.Default;
                }
            }

            LoadRet = SettingValue;
            return LoadRet;
        }

        public static void Save(ref Microsoft.Win32.RegistryKey RegistryKey, Enum Enum, string Value)
        {

            // objects
            AdvantageFramework.Core.Registry.Attributes.RegistryAttribute RegistryAttribute = default;
            RegistryAttribute = (Attributes.RegistryAttribute)Attribute.GetCustomAttribute(Enum.GetType().GetField(Enum.ToString()), typeof(AdvantageFramework.Core.Registry.Attributes.RegistryAttribute));
            if (RegistryAttribute is object)
            {
                if (RegistryKey is object)
                {
                    RegistryKey.SetValue(RegistryAttribute.Key, Value);
                }
            }
        }

        public static bool Delete(ref Microsoft.Win32.RegistryKey RegistryKey, Enum Enum)
        {
            bool DeleteRet = default;

            // objects
            bool Deleted = false;
            AdvantageFramework.Core.Registry.Attributes.RegistryAttribute RegistryAttribute = default;
            RegistryAttribute = (Attributes.RegistryAttribute)Attribute.GetCustomAttribute(Enum.GetType().GetField(Enum.ToString()), typeof(AdvantageFramework.Core.Registry.Attributes.RegistryAttribute));
            if (RegistryAttribute is object)
            {
                if (RegistryKey is object)
                {
                    RegistryKey.DeleteValue(RegistryAttribute.Key);
                    Deleted = true;
                }
            }

            DeleteRet = Deleted;
            return DeleteRet;
        }

        public static Microsoft.Win32.RegistryKey CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.RegistryKey RegistryKey, string Path)
        {
            Microsoft.Win32.RegistryKey CreateAndOpenRegistryKeyByWin32Ret = default;

            // objects
            Microsoft.Win32.RegistryKey NewOrOpenedRegistryKey = null;
            if (RegistryKey is object)
            {
                if (OpenRegistryKeyByWin32(RegistryKey, Path) is null)
                {
                    RegistryKey.CreateSubKey(Path, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree, Microsoft.Win32.RegistryOptions.None);
                }

                NewOrOpenedRegistryKey = OpenRegistryKeyByWin32(RegistryKey, Path);
            }

            CreateAndOpenRegistryKeyByWin32Ret = NewOrOpenedRegistryKey;
            return CreateAndOpenRegistryKeyByWin32Ret;
        }

        public static Microsoft.Win32.RegistryKey OpenRegistryKeyByWin32(Microsoft.Win32.RegistryKey RegistryKey, string Path)
        {
            Microsoft.Win32.RegistryKey OpenRegistryKeyByWin32Ret = default;
            OpenRegistryKeyByWin32Ret = null;
            if (RegistryKey is object)
            {
                OpenRegistryKeyByWin32Ret = RegistryKey.OpenSubKey(Path, true);
            }

            return OpenRegistryKeyByWin32Ret;
        }

        public static bool SaveRegistryValueByWin32(Microsoft.Win32.RegistryKey RegistryKey, string Name, object Value, Microsoft.Win32.RegistryValueKind RegistryValueKind = Microsoft.Win32.RegistryValueKind.String)
        {
            bool SaveRegistryValueByWin32Ret = default;
            SaveRegistryValueByWin32Ret = false;
            if (RegistryKey is object)
            {
                RegistryKey.SetValue(Name, Value, RegistryValueKind);
                SaveRegistryValueByWin32Ret = true;
            }

            return SaveRegistryValueByWin32Ret;
        }

        public static object LoadRegistryValueByWin32(Microsoft.Win32.RegistryKey RegistryKey, string Name)
        {
            object LoadRegistryValueByWin32Ret = default;
            LoadRegistryValueByWin32Ret = null;
            if (RegistryKey is object)
            {
                LoadRegistryValueByWin32Ret = RegistryKey.GetValue(Name);
            }

            return LoadRegistryValueByWin32Ret;
        }

        public static Microsoft.Win32.RegistryKey OpenUserVirutalRegistryKey()
        {
            Microsoft.Win32.RegistryKey OpenUserVirutalRegistryKeyRet = default;
            OpenUserVirutalRegistryKeyRet = OpenUserVirutalRegistryKey(System.Security.Principal.WindowsIdentity.GetCurrent().User.AccountDomainSid.ToString());
            return OpenUserVirutalRegistryKeyRet;
        }

        public static Microsoft.Win32.RegistryKey OpenUserVirutalRegistryKey(string UserSID)
        {
            Microsoft.Win32.RegistryKey OpenUserVirutalRegistryKeyRet = default;
            OpenUserVirutalRegistryKeyRet = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.Users, UserSID + @"_Classes\VirtualStore\Machine\Software\Advantage");
            return OpenUserVirutalRegistryKeyRet;
        }

        public static Microsoft.Win32.RegistryKey OpenMachineDefaultRegistryKey()
        {
            Microsoft.Win32.RegistryKey OpenMachineDefaultRegistryKeyRet = default;
            OpenMachineDefaultRegistryKeyRet = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Advantage");
            return OpenMachineDefaultRegistryKeyRet;

            // If IsAdvantageServices Then

            // OpenMachineDefaultRegistryKey = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Advantage")

            // Else

            // OpenMachineDefaultRegistryKey = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Advantage Software")

            // End If

        }

        public static Microsoft.Win32.RegistryKey OpenMachineDefaultRegistryKeyWin64()
        {
            Microsoft.Win32.RegistryKey OpenMachineDefaultRegistryKeyWin64Ret = default;
            OpenMachineDefaultRegistryKeyWin64Ret = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Wow6432Node\Advantage");
            return OpenMachineDefaultRegistryKeyWin64Ret;

            // If IsAdvantageServices Then

            // OpenMachineDefaultRegistryKeyWin64 = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Wow6432Node\Advantage")

            // Else

            // OpenMachineDefaultRegistryKeyWin64 = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Wow6432Node\Advantage Software")

            // End If

        }

        public static Microsoft.Win32.RegistryKey OpenUserDefaultRegistryKey()
        {
            Microsoft.Win32.RegistryKey OpenUserDefaultRegistryKeyRet = default;
            OpenUserDefaultRegistryKeyRet = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.CurrentUser, @"Software\Advantage");
            return OpenUserDefaultRegistryKeyRet;
        }

        public static Microsoft.Win32.RegistryKey LoadServicesRegistryKey()
        {
            Microsoft.Win32.RegistryKey LoadServicesRegistryKeyRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = Registry.Methods.OpenMachineDefaultRegistryKey();
            if (RegistryKey is object)
            {
                RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Services");
            }

            LoadServicesRegistryKeyRet = RegistryKey;
            return LoadServicesRegistryKeyRet;
        }

        public static Microsoft.Win32.RegistryKey LoadDatabaseProfilesRegistryKey()
        {
            Microsoft.Win32.RegistryKey LoadDatabaseProfilesRegistryKeyRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = AdvantageFramework.Core.Registry.Methods.OpenMachineDefaultRegistryKey();
            if (RegistryKey is object)
            {
                RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Servers");
            }

            LoadDatabaseProfilesRegistryKeyRet = RegistryKey;
            return LoadDatabaseProfilesRegistryKeyRet;
        }

        public static Microsoft.Win32.RegistryKey LoadConnectionDatabaseProfilesRegistryKeyReadOnly()
        {
            Microsoft.Win32.RegistryKey LoadConnectionDatabaseProfilesRegistryKeyReadOnlyRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = OpenRegistryKeyByWin32ReadOnly(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Advantage");
            if (RegistryKey is object)
            {
                RegistryKey = AdvantageFramework.Core.Registry.Methods.OpenRegistryKeyByWin32ReadOnly(RegistryKey, "Connections");
            }

            LoadConnectionDatabaseProfilesRegistryKeyReadOnlyRet = RegistryKey;
            return LoadConnectionDatabaseProfilesRegistryKeyReadOnlyRet;
        }

        public static Microsoft.Win32.RegistryKey LoadConnectionDatabaseProfilesRegistryKey()
        {
            Microsoft.Win32.RegistryKey LoadConnectionDatabaseProfilesRegistryKeyRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = AdvantageFramework.Core.Registry.Methods.OpenMachineDefaultRegistryKey();
            if (RegistryKey is object)
            {
                RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Connections");
            }

            LoadConnectionDatabaseProfilesRegistryKeyRet = RegistryKey;
            return LoadConnectionDatabaseProfilesRegistryKeyRet;
        }

        public static Microsoft.Win32.RegistryKey LoadODBCCurrentUserRegistryKeyReadOnly()
        {
            Microsoft.Win32.RegistryKey LoadODBCCurrentUserRegistryKeyReadOnlyRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = OpenRegistryKeyByWin32ReadOnly(Microsoft.Win32.Registry.CurrentUser, @"SOFTWARE\ODBC\ODBC.INI");
            LoadODBCCurrentUserRegistryKeyReadOnlyRet = RegistryKey;
            return LoadODBCCurrentUserRegistryKeyReadOnlyRet;
        }

        public static Microsoft.Win32.RegistryKey LoadODBCLocalMachineRegistryKeyReadOnly()
        {
            Microsoft.Win32.RegistryKey LoadODBCLocalMachineRegistryKeyReadOnlyRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = OpenRegistryKeyByWin32ReadOnly(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\ODBC\ODBC.INI");
            LoadODBCLocalMachineRegistryKeyReadOnlyRet = RegistryKey;
            return LoadODBCLocalMachineRegistryKeyReadOnlyRet;
        }

        public static Microsoft.Win32.RegistryKey LoadConnectionDatabaseProfilesRegistryKeyWin64()
        {
            Microsoft.Win32.RegistryKey LoadConnectionDatabaseProfilesRegistryKeyWin64Ret = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = AdvantageFramework.Core.Registry.Methods.OpenMachineDefaultRegistryKeyWin64();
            if (RegistryKey is object)
            {
                RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Connections");
            }

            LoadConnectionDatabaseProfilesRegistryKeyWin64Ret = RegistryKey;
            return LoadConnectionDatabaseProfilesRegistryKeyWin64Ret;
        }

        public static Microsoft.Win32.RegistryKey LoadEmailListenerDatabaseProfilesRegistryKey()
        {
            Microsoft.Win32.RegistryKey LoadEmailListenerDatabaseProfilesRegistryKeyRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = AdvantageFramework.Core.Registry.Methods.OpenMachineDefaultRegistryKey();
            if (RegistryKey is object)
            {
                RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Services");
                if (RegistryKey is object)
                {
                    RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Email Listener");
                    if (RegistryKey is object)
                    {
                        RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Database Profiles");
                    }
                }
            }

            LoadEmailListenerDatabaseProfilesRegistryKeyRet = RegistryKey;
            return LoadEmailListenerDatabaseProfilesRegistryKeyRet;
        }

        public static Microsoft.Win32.RegistryKey LoadExportDatabaseProfilesRegistryKey()
        {
            Microsoft.Win32.RegistryKey LoadExportDatabaseProfilesRegistryKeyRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = AdvantageFramework.Core.Registry.Methods.OpenMachineDefaultRegistryKey();
            if (RegistryKey is object)
            {
                RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Services");
                if (RegistryKey is object)
                {
                    RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Export");
                    if (RegistryKey is object)
                    {
                        RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Database Profiles");
                    }
                }
            }

            LoadExportDatabaseProfilesRegistryKeyRet = RegistryKey;
            return LoadExportDatabaseProfilesRegistryKeyRet;
        }

        public static Microsoft.Win32.RegistryKey LoadExportClientCampaignsRegistryKey(string DatabaseProfileName)
        {
            Microsoft.Win32.RegistryKey LoadExportClientCampaignsRegistryKeyRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = AdvantageFramework.Core.Registry.Methods.OpenMachineDefaultRegistryKey();
            if (RegistryKey is object)
            {
                RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Services");
                if (RegistryKey is object)
                {
                    RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Export");
                    if (RegistryKey is object)
                    {
                        RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Client Campaigns");
                        if (RegistryKey is object)
                        {
                            RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, DatabaseProfileName);
                        }
                    }
                }
            }

            LoadExportClientCampaignsRegistryKeyRet = RegistryKey;
            return LoadExportClientCampaignsRegistryKeyRet;
        }

        public static Microsoft.Win32.RegistryKey LoadExportRegistryKey()
        {
            Microsoft.Win32.RegistryKey LoadExportRegistryKeyRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            RegistryKey = AdvantageFramework.Core.Registry.Methods.OpenMachineDefaultRegistryKey();
            if (RegistryKey is object)
            {
                RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Services");
                if (RegistryKey is object)
                {
                    RegistryKey = AdvantageFramework.Core.Registry.Methods.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Export");
                }
            }

            LoadExportRegistryKeyRet = RegistryKey;
            return LoadExportRegistryKeyRet;
        }

        public static string LoadMicrosoftAccessEXEPath()
        {
            string LoadMicrosoftAccessEXEPathRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            string AccessEXEPath = "";
            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\App Paths\MSACCESS.EXE", false);
                }
                else
                {
                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\MSACCESS.EXE", false);
                }
            }
            catch (Exception ex)
            {
                RegistryKey = null;
            }

            if (RegistryKey is object)
            {
                try
                {
                    AccessEXEPath = RegistryKey.GetValue("Path").ToString();
                }
                catch (Exception ex)
                {
                    AccessEXEPath = "";
                }
            }

            LoadMicrosoftAccessEXEPathRet = AccessEXEPath;
            return LoadMicrosoftAccessEXEPathRet;
        }

        public static bool CheckHelpFileEmulation(bool UseLocalMachine)
        {
            bool CheckHelpFileEmulationRet = default;

            // objects
            Microsoft.Win32.RegistryKey RegistryKey = null;
            decimal Emulator = 0m;
            bool EmulatorSet = false;
            try
            {
                if (UseLocalMachine)
                {
                    if (Environment.Is64BitOperatingSystem)
                    {
                        RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                    }
                    else
                    {
                        RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                    }
                }
                else if (Environment.Is64BitOperatingSystem)
                {
                    RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                }
                else
                {
                    RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                }
            }
            catch (Exception ex)
            {
                RegistryKey = null;
            }

            try
            {
                if (RegistryKey is object)
                {
                    try
                    {
                        Emulator = decimal.Parse(RegistryKey.GetValue("Advantage.exe", 0).ToString());
                    }
                    catch (Exception ex)
                    {
                        Emulator = 0m;
                    }

                    if (Emulator == 0m)
                    {
                        RegistryKey.SetValue("Advantage.exe", 9999, Microsoft.Win32.RegistryValueKind.DWord);
                        EmulatorSet = true;
                    }
                    else
                    {
                        EmulatorSet = true;
                    }
                }
            }
            catch (Exception ex)
            {
                EmulatorSet = false;
            }

            CheckHelpFileEmulationRet = EmulatorSet;
            return CheckHelpFileEmulationRet;
        }

        public static Microsoft.Win32.RegistryKey OpenRegistryKeyByWin32ReadOnly(Microsoft.Win32.RegistryKey RegistryKey, string Path)
        {
            Microsoft.Win32.RegistryKey OpenRegistryKeyByWin32ReadOnlyRet = default;
            OpenRegistryKeyByWin32ReadOnlyRet = null;
            if (RegistryKey is object)
            {
                OpenRegistryKeyByWin32ReadOnlyRet = RegistryKey.OpenSubKey(Path, Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree, System.Security.AccessControl.RegistryRights.ReadKey);
            }

            return OpenRegistryKeyByWin32ReadOnlyRet;
        }

        public static bool SetEnabledLinkedConnections()
        {
            bool SetEnabledLinkedConnectionsRet = default;
            bool EnabledLinkedConnectionsSet = false;
            Microsoft.Win32.RegistryKey RegistryKey = null;
            try
            {
                if (IsAdministrator())
                {
                    RegistryKey = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                    if (RegistryKey is object)
                    {
                        EnabledLinkedConnectionsSet = SaveRegistryValueByWin32(RegistryKey, "EnableLinkedConnections", 1, Microsoft.Win32.RegistryValueKind.DWord);
                    }
                }
            }
            catch (Exception ex)
            {
                EnabledLinkedConnectionsSet = false;
            }

            SetEnabledLinkedConnectionsRet = EnabledLinkedConnectionsSet;
            return SetEnabledLinkedConnectionsRet;
        }

        private static bool IsAdministrator()
        {
            bool IsAdministratorRet = default;
            System.Security.Principal.WindowsIdentity WindowsIdentity = null;
            System.Security.Principal.WindowsPrincipal WindowsPrincipal = null;
            WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            WindowsPrincipal = new System.Security.Principal.WindowsPrincipal(WindowsIdentity);
            IsAdministratorRet = WindowsPrincipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
            return IsAdministratorRet;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
