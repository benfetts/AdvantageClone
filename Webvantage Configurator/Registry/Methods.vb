Namespace Registry

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enums "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function CreateAndOpenRegistryKeyByWin32(RegistryKey As Microsoft.Win32.RegistryKey, Path As String) As Microsoft.Win32.RegistryKey

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
        Public Function OpenRegistryKeyByWin32(RegistryKey As Microsoft.Win32.RegistryKey, Path As String) As Microsoft.Win32.RegistryKey

            OpenRegistryKeyByWin32 = Nothing

            If RegistryKey IsNot Nothing Then

                OpenRegistryKeyByWin32 = RegistryKey.OpenSubKey(Path, True)

            End If

        End Function
        Public Function SaveRegistryValueByWin32(RegistryKey As Microsoft.Win32.RegistryKey, Name As String, Value As Object, Optional RegistryValueKind As Microsoft.Win32.RegistryValueKind = Microsoft.Win32.RegistryValueKind.String) As Boolean

            SaveRegistryValueByWin32 = False

            If RegistryKey IsNot Nothing Then

                RegistryKey.SetValue(Name, Value, RegistryValueKind)

                SaveRegistryValueByWin32 = True

            End If

        End Function
        Public Function LoadRegistryValueByWin32(RegistryKey As Microsoft.Win32.RegistryKey, Name As String) As Object

            LoadRegistryValueByWin32 = Nothing

            If RegistryKey IsNot Nothing Then

                LoadRegistryValueByWin32 = RegistryKey.GetValue(Name)

            End If

        End Function
        Public Function OpenUserVirutalRegistryKey() As Microsoft.Win32.RegistryKey

            OpenUserVirutalRegistryKey = OpenUserVirutalRegistryKey(System.Security.Principal.WindowsIdentity.GetCurrent().User.AccountDomainSid.ToString())

        End Function
        Public Function OpenUserVirutalRegistryKey(UserSID As String) As Microsoft.Win32.RegistryKey

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
        Public Function LoadConnectionDatabaseProfilesRegistryKeyReadOnly() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = OpenRegistryKeyByWin32ReadOnly(Microsoft.Win32.Registry.LocalMachine, "SOFTWARE\Advantage")

            If RegistryKey IsNot Nothing Then

                RegistryKey = Registry.OpenRegistryKeyByWin32ReadOnly(RegistryKey, "Connections")

            End If

            LoadConnectionDatabaseProfilesRegistryKeyReadOnly = RegistryKey

        End Function
        Public Function LoadConnectionDatabaseProfilesRegistryKey() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = Registry.OpenMachineDefaultRegistryKey()

            If RegistryKey IsNot Nothing Then

                RegistryKey = Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Connections")

            End If

            LoadConnectionDatabaseProfilesRegistryKey = RegistryKey

        End Function
        Public Function LoadConnectionDatabaseProfilesRegistryKeyWin64() As Microsoft.Win32.RegistryKey

            'objects
            Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing

            RegistryKey = Registry.OpenMachineDefaultRegistryKeyWin64()

            If RegistryKey IsNot Nothing Then

                RegistryKey = Registry.CreateAndOpenRegistryKeyByWin32(RegistryKey, "Connections")

            End If

            LoadConnectionDatabaseProfilesRegistryKeyWin64 = RegistryKey

        End Function
        Public Function OpenRegistryKeyByWin32ReadOnly(ByVal RegistryKey As Microsoft.Win32.RegistryKey, ByVal Path As String) As Microsoft.Win32.RegistryKey

            OpenRegistryKeyByWin32ReadOnly = Nothing

            If RegistryKey IsNot Nothing Then

                OpenRegistryKeyByWin32ReadOnly = RegistryKey.OpenSubKey(Path, Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree, System.Security.AccessControl.RegistryRights.ReadKey)

            End If

        End Function

#End Region

    End Module

End Namespace