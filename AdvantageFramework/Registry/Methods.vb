Namespace Registry

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enums "

        Public Enum LoginRegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Login\", "Server", "")>
            Server
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Login\", "Database", "")>
            Database
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Login\", "UseWindowsAuthentication", "False")>
            UseWindowsAuthentication
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Login\", "UserName", "")>
            UserName
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Login\", "Password", "")>
            Password
        End Enum

        Public Enum SettingsType
            Service
            Process
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(ByRef RegistryKey As Microsoft.Win32.RegistryKey, ByVal [Enum] As [Enum]) As String

            'objects
            Dim SettingValue As String = ""
            Dim RegistryAttribute As AdvantageFramework.Registry.Attributes.RegistryAttribute = Nothing

            RegistryAttribute = System.Attribute.GetCustomAttribute([Enum].GetType().GetField([Enum].ToString), GetType(AdvantageFramework.Registry.Attributes.RegistryAttribute))

            If RegistryAttribute IsNot Nothing Then

                If RegistryKey IsNot Nothing Then

                    SettingValue = RegistryKey.GetValue(RegistryAttribute.Key, RegistryAttribute.Default)

                Else

                    SettingValue = RegistryAttribute.Default

                End If

            End If

            Load = SettingValue

        End Function
        Public Sub Save(ByRef RegistryKey As Microsoft.Win32.RegistryKey, ByVal [Enum] As [Enum], ByVal Value As String)

            'objects
            Dim RegistryAttribute As AdvantageFramework.Registry.Attributes.RegistryAttribute = Nothing

            RegistryAttribute = System.Attribute.GetCustomAttribute([Enum].GetType().GetField([Enum].ToString), GetType(AdvantageFramework.Registry.Attributes.RegistryAttribute))

            If RegistryAttribute IsNot Nothing Then

                If RegistryKey IsNot Nothing Then

                    RegistryKey.SetValue(RegistryAttribute.Key, Value)

                End If

            End If

        End Sub
        Public Function Delete(ByRef RegistryKey As Microsoft.Win32.RegistryKey, ByVal [Enum] As [Enum]) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim RegistryAttribute As AdvantageFramework.Registry.Attributes.RegistryAttribute = Nothing

            RegistryAttribute = System.Attribute.GetCustomAttribute([Enum].GetType().GetField([Enum].ToString), GetType(AdvantageFramework.Registry.Attributes.RegistryAttribute))

            If RegistryAttribute IsNot Nothing Then

                If RegistryKey IsNot Nothing Then

                    RegistryKey.DeleteValue(RegistryAttribute.Key)
                    Deleted = True

                End If

            End If

            Delete = Deleted

        End Function
        Public Function CreateAndOpenRegistryKeyByWin32(ByVal RegistryKey As Microsoft.Win32.RegistryKey, ByVal Path As String) As Microsoft.Win32.RegistryKey

            'objects
            Dim NewOrOpenedRegistryKey As Microsoft.Win32.RegistryKey = Nothing

            If RegistryKey IsNot Nothing Then

                If OpenRegistryKeyByWin32(RegistryKey, Path) Is Nothing Then

                    RegistryKey.CreateSubKey(Path, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree, Microsoft.Win32.RegistryOptions.None)

                End If

                NewOrOpenedRegistryKey = OpenRegistryKeyByWin32(RegistryKey, Path)

            End If

            CreateAndOpenRegistryKeyByWin32 = NewOrOpenedRegistryKey

        End Function
        Public Function OpenRegistryKeyByWin32(ByVal RegistryKey As Microsoft.Win32.RegistryKey, ByVal Path As String) As Microsoft.Win32.RegistryKey

            OpenRegistryKeyByWin32 = Nothing

            If RegistryKey IsNot Nothing Then

                OpenRegistryKeyByWin32 = RegistryKey.OpenSubKey(Path, True)

            End If

        End Function
        Public Function SaveRegistryValueByWin32(ByVal RegistryKey As Microsoft.Win32.RegistryKey, ByVal Name As String, ByVal Value As Object, Optional ByVal RegistryValueKind As Microsoft.Win32.RegistryValueKind = Microsoft.Win32.RegistryValueKind.String) As Boolean

            SaveRegistryValueByWin32 = False

            If RegistryKey IsNot Nothing Then

                RegistryKey.SetValue(Name, Value, RegistryValueKind)

                SaveRegistryValueByWin32 = True

            End If

        End Function
        Public Function LoadRegistryValueByWin32(ByVal RegistryKey As Microsoft.Win32.RegistryKey, ByVal Name As String) As Object

            LoadRegistryValueByWin32 = Nothing

            If RegistryKey IsNot Nothing Then

                LoadRegistryValueByWin32 = RegistryKey.GetValue(Name)

            End If

        End Function
        Public Function OpenUserVirutalRegistryKey() As Microsoft.Win32.RegistryKey

            OpenUserVirutalRegistryKey = OpenUserVirutalRegistryKey(System.Security.Principal.WindowsIdentity.GetCurrent().User.AccountDomainSid.ToString())

        End Function
        Public Function OpenUserVirutalRegistryKey(ByVal UserSID As String) As Microsoft.Win32.RegistryKey

            OpenUserVirutalRegistryKey = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.Users, UserSID & "_Classes\VirtualStore\Machine\Software\Advantage")

        End Function
        Public Function OpenMachineDefaultRegistryKey() As Microsoft.Win32.RegistryKey

            OpenMachineDefaultRegistryKey = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Advantage")

            'If IsAdvantageServices Then

            '    OpenMachineDefaultRegistryKey = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Advantage")

            'Else

            '    OpenMachineDefaultRegistryKey = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Advantage Software")

            'End If

        End Function
        Public Function OpenMachineDefaultRegistryKeyWin64() As Microsoft.Win32.RegistryKey

            OpenMachineDefaultRegistryKeyWin64 = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Wow6432Node\Advantage")

            'If IsAdvantageServices Then

            '    OpenMachineDefaultRegistryKeyWin64 = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Wow6432Node\Advantage")

            'Else

            '    OpenMachineDefaultRegistryKeyWin64 = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Wow6432Node\Advantage Software")

            'End If

        End Function
        Public Function OpenUserDefaultRegistryKey() As Microsoft.Win32.RegistryKey

            OpenUserDefaultRegistryKey = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.CurrentUser, "Software\Advantage")

        End Function
        Public Function LoadServicesRegistryKey() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = AdvantageFramework.Registry.OpenMachineDefaultRegistryKey()

            If RegistryKey IsNot Nothing Then

                RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Services")

            End If

            LoadServicesRegistryKey = RegistryKey

        End Function
        Public Function LoadDatabaseProfilesRegistryKey() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = AdvantageFramework.Registry.OpenMachineDefaultRegistryKey()

            If RegistryKey IsNot Nothing Then

                RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Servers")

            End If

            LoadDatabaseProfilesRegistryKey = RegistryKey

        End Function
        Public Function LoadConnectionDatabaseProfilesRegistryKeyReadOnly() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = OpenRegistryKeyByWin32ReadOnly(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Advantage")

            If RegistryKey IsNot Nothing Then

                RegistryKey = AdvantageFramework.Registry.OpenRegistryKeyByWin32ReadOnly(RegistryKey, "Connections")

            End If

            LoadConnectionDatabaseProfilesRegistryKeyReadOnly = RegistryKey

        End Function
        Public Function LoadConnectionDatabaseProfilesRegistryKey() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = AdvantageFramework.Registry.OpenMachineDefaultRegistryKey()

            If RegistryKey IsNot Nothing Then

                RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Connections")

            End If

            LoadConnectionDatabaseProfilesRegistryKey = RegistryKey

        End Function
        Public Function LoadODBCCurrentUserRegistryKeyReadOnly() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = OpenRegistryKeyByWin32ReadOnly(Microsoft.Win32.Registry.CurrentUser, "SOFTWARE\ODBC\ODBC.INI")

            LoadODBCCurrentUserRegistryKeyReadOnly = RegistryKey

        End Function
        Public Function LoadODBCLocalMachineRegistryKeyReadOnly() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = OpenRegistryKeyByWin32ReadOnly(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\ODBC\ODBC.INI")

            LoadODBCLocalMachineRegistryKeyReadOnly = RegistryKey

        End Function
        Public Function LoadODBCCurrentUserRegistryKeyReadOnly32Bit() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = OpenRegistryKeyByWin32ReadOnly(Microsoft.Win32.Registry.CurrentUser, "SOFTWARE\Wow6432Node\ODBC\ODBC.INI")

            LoadODBCCurrentUserRegistryKeyReadOnly32Bit = RegistryKey

        End Function
        Public Function LoadODBCLocalMachineRegistryKeyReadOnly32Bit() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = OpenRegistryKeyByWin32ReadOnly(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Wow6432Node\ODBC\ODBC.INI")

            LoadODBCLocalMachineRegistryKeyReadOnly32Bit = RegistryKey

        End Function
        Public Function LoadConnectionDatabaseProfilesRegistryKeyWin64() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = AdvantageFramework.Registry.OpenMachineDefaultRegistryKeyWin64()

            If RegistryKey IsNot Nothing Then

                RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Connections")

            End If

            LoadConnectionDatabaseProfilesRegistryKeyWin64 = RegistryKey

        End Function
        Public Function LoadEmailListenerDatabaseProfilesRegistryKey() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = AdvantageFramework.Registry.OpenMachineDefaultRegistryKey()

            If RegistryKey IsNot Nothing Then

                RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Services")

                If RegistryKey IsNot Nothing Then

                    RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Email Listener")

                    If RegistryKey IsNot Nothing Then

                        RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Database Profiles")

                    End If

                End If

            End If

            LoadEmailListenerDatabaseProfilesRegistryKey = RegistryKey

        End Function
        Public Function LoadExportDatabaseProfilesRegistryKey() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = AdvantageFramework.Registry.OpenMachineDefaultRegistryKey()

            If RegistryKey IsNot Nothing Then

                RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Services")

                If RegistryKey IsNot Nothing Then

                    RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Export")

                    If RegistryKey IsNot Nothing Then

                        RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Database Profiles")

                    End If

                End If

            End If

            LoadExportDatabaseProfilesRegistryKey = RegistryKey

        End Function
        Public Function LoadExportClientCampaignsRegistryKey(ByVal DatabaseProfileName As String) As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = AdvantageFramework.Registry.OpenMachineDefaultRegistryKey()

            If RegistryKey IsNot Nothing Then

                RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Services")

                If RegistryKey IsNot Nothing Then

                    RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Export")

                    If RegistryKey IsNot Nothing Then

                        RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Client Campaigns")

                        If RegistryKey IsNot Nothing Then

                            RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, DatabaseProfileName)

                        End If

                    End If

                End If

            End If

            LoadExportClientCampaignsRegistryKey = RegistryKey

        End Function
        Public Function LoadExportRegistryKey() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = AdvantageFramework.Registry.OpenMachineDefaultRegistryKey()

            If RegistryKey IsNot Nothing Then

                RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Services")

                If RegistryKey IsNot Nothing Then

                    RegistryKey = AdvantageFramework.Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Export")

                End If

            End If

            LoadExportRegistryKey = RegistryKey

        End Function
        Public Function LoadMicrosoftAccessEXEPath() As String

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim AccessEXEPath As String = ""

            Try

                If System.Environment.Is64BitOperatingSystem Then

                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\App Paths\MSACCESS.EXE", False)

                Else

                    RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\MSACCESS.EXE", False)

                End If

            Catch ex As Exception
                RegistryKey = Nothing
            End Try

            If RegistryKey IsNot Nothing Then

                Try

                    AccessEXEPath = RegistryKey.GetValue("Path")

                Catch ex As Exception
                    AccessEXEPath = ""
                End Try

            End If

            LoadMicrosoftAccessEXEPath = AccessEXEPath

        End Function
        Public Function CheckHelpFileEmulation(UseLocalMachine As Boolean) As Boolean

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
            Dim Emulator As Decimal = 0
            Dim EmulatorSet As Boolean = False

            Try

                If UseLocalMachine Then

                    If System.Environment.Is64BitOperatingSystem Then

                        RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", True)

                    Else

                        RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", True)

                    End If

                Else

                    If System.Environment.Is64BitOperatingSystem Then

                        RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", True)

                    Else

                        RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", True)

                    End If

                End If

            Catch ex As Exception
                RegistryKey = Nothing
            End Try

            Try

                If RegistryKey IsNot Nothing Then

                    Try

                        Emulator = RegistryKey.GetValue("Advantage.exe", 0)

                    Catch ex As Exception
                        Emulator = 0
                    End Try

                    If Emulator = 0 Then

                        RegistryKey.SetValue("Advantage.exe", 9999, Microsoft.Win32.RegistryValueKind.DWord)

                        EmulatorSet = True

                    Else

                        EmulatorSet = True

                    End If

                End If

            Catch ex As Exception
                EmulatorSet = False
            End Try

            CheckHelpFileEmulation = EmulatorSet

        End Function
        Public Function OpenRegistryKeyByWin32ReadOnly(ByVal RegistryKey As Microsoft.Win32.RegistryKey, ByVal Path As String) As Microsoft.Win32.RegistryKey

            OpenRegistryKeyByWin32ReadOnly = Nothing

            If RegistryKey IsNot Nothing Then

                OpenRegistryKeyByWin32ReadOnly = RegistryKey.OpenSubKey(Path, Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree, System.Security.AccessControl.RegistryRights.ReadKey)

            End If

        End Function
        Public Function SetEnabledLinkedConnections() As Boolean

            Dim EnabledLinkedConnectionsSet As Boolean = False
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            Try

                If IsAdministrator() Then

                    RegistryKey = CreateAndOpenRegistryKeyByWin32(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System")

                    If RegistryKey IsNot Nothing Then

                        EnabledLinkedConnectionsSet = SaveRegistryValueByWin32(RegistryKey, "EnableLinkedConnections", 1, Microsoft.Win32.RegistryValueKind.DWord)

                    End If

                End If

            Catch ex As Exception
                EnabledLinkedConnectionsSet = False
            End Try

            SetEnabledLinkedConnections = EnabledLinkedConnectionsSet

        End Function
        Private Function IsAdministrator() As Boolean

            Dim WindowsIdentity As System.Security.Principal.WindowsIdentity = Nothing
            Dim WindowsPrincipal As System.Security.Principal.WindowsPrincipal = Nothing

            WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
            WindowsPrincipal = New System.Security.Principal.WindowsPrincipal(WindowsIdentity)

            IsAdministrator = WindowsPrincipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator)

        End Function

#End Region

    End Module

End Namespace
