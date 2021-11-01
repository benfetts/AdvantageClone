Partial Public Class ModifyAdvantageServicesConnectionPage
    Inherits BaseWizardPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        InitializeComponent()

    End Sub
    Public Sub Modify()

        SimpleButtonForm_Modify.PerformClick()

    End Sub
    Public Sub Skip()

        Me.WizardViewModel.Next()

    End Sub
    Public Function LoadDatabaseProfiles() As Generic.List(Of AdvantageFramework.Database.DatabaseProfile)

        'objects
        Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim DatabaseProfiles As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

        RegistryKey = AdvantageFramework.Registry.LoadDatabaseProfilesRegistryKey()

        If RegistryKey IsNot Nothing Then

            DatabaseProfiles = LoadDatabaseProfiles(RegistryKey)

            RegistryKey.Close()

            RegistryKey.Dispose()

            RegistryKey = Nothing

        End If

        If DatabaseProfiles Is Nothing Then

            DatabaseProfiles = New Generic.List(Of AdvantageFramework.Database.DatabaseProfile)

        End If

        LoadDatabaseProfiles = DatabaseProfiles

    End Function
    Public Function LoadDatabaseProfile(ByRef RegistryKey As Microsoft.Win32.RegistryKey, ByVal ServerName As String, ByVal DatabaseName As String) As AdvantageFramework.Database.DatabaseProfile

        'objects
        Dim RegistrySubKey As Microsoft.Win32.RegistryKey = Nothing
        Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing

        If RegistryKey IsNot Nothing Then

            DatabaseProfile = New AdvantageFramework.Database.DatabaseProfile

            RegistrySubKey = AdvantageFramework.Registry.OpenRegistryKeyByWin32(RegistryKey, DatabaseName)

            If RegistrySubKey IsNot Nothing Then

                DatabaseProfile.DatabaseServer = ServerName.Replace("#", "\")
                DatabaseProfile.DatabaseName = DatabaseName
                DatabaseProfile.DatabaseUserName = RegistrySubKey.GetValue("Username").ToString
                DatabaseProfile.DatabasePassword = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(RegistrySubKey.GetValue("Password").ToString)
                DatabaseProfile.CPDatabaseUserName = RegistrySubKey.GetValue("CPUsername").ToString
                DatabaseProfile.CPDatabasePassword = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(RegistrySubKey.GetValue("CPPassword").ToString)

                If RegistrySubKey.GetValue("EnableServices") IsNot Nothing Then

                    DatabaseProfile.EnableServices = RegistrySubKey.GetValue("EnableServices").ToString

                Else

                    DatabaseProfile.EnableServices = True

                End If

            End If

            If RegistrySubKey IsNot Nothing Then

                RegistrySubKey.Close()

                RegistrySubKey.Dispose()

                RegistrySubKey = Nothing

            End If

        End If

        LoadDatabaseProfile = DatabaseProfile

    End Function
    Public Function LoadDatabaseProfiles(ByRef RegistryKey As Microsoft.Win32.RegistryKey) As Generic.List(Of AdvantageFramework.Database.DatabaseProfile)

        'objects
        Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
        Dim DatabaseProfiles As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing
        Dim DatabaseRegistryKey As Microsoft.Win32.RegistryKey = Nothing

        If RegistryKey IsNot Nothing Then

            DatabaseProfiles = New Generic.List(Of AdvantageFramework.Database.DatabaseProfile)

            For Each SubKeyName In RegistryKey.GetSubKeyNames

                DatabaseRegistryKey = RegistryKey.OpenSubKey(SubKeyName)

                For Each DatabaseSubKeyName In DatabaseRegistryKey.GetSubKeyNames

                    DatabaseProfile = LoadDatabaseProfile(DatabaseRegistryKey, SubKeyName, DatabaseSubKeyName)

                    If DatabaseProfile IsNot Nothing Then

                        DatabaseProfiles.Add(DatabaseProfile)

                    End If

                Next

            Next

        End If

        LoadDatabaseProfiles = DatabaseProfiles

    End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub SimpleButtonForm_Modify_Click(sender As Object, e As System.EventArgs) Handles SimpleButtonForm_Modify.Click

        Dim ModifiedAdvantageServicesConnection As Boolean = False
        Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
        Dim DatabaseProfiles As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing
        Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        Dim ErrorMessage As String = String.Empty

        OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me)

        Try

            DatabaseProfiles = LoadDatabaseProfiles()

            If DatabaseProfiles IsNot Nothing AndAlso DatabaseProfiles.Count > 0 Then

                Try

                    DatabaseProfile = DatabaseProfiles.SingleOrDefault(Function(Entity) Entity.DatabaseServer = Me.WizardViewModel.WizardInputs.ServerName AndAlso Entity.DatabaseName = Me.WizardViewModel.WizardInputs.Database)

                Catch ex As Exception
                    DatabaseProfile = Nothing
                End Try

                If DatabaseProfile IsNot Nothing Then

                    DatabaseProfile.DatabaseUserName = Me.WizardViewModel.WizardInputs.AdvantageUserName
                    DatabaseProfile.DatabasePassword = Me.WizardViewModel.WizardInputs.AdvantagePassword

                    If AdvantageFramework.Database.SaveDatabaseProfile(DatabaseProfile, False) Then

                        ModifiedAdvantageServicesConnection = True

                    End If

                Else

                    ModifiedAdvantageServicesConnection = True

                End If

            Else

                ModifiedAdvantageServicesConnection = True

            End If

        Catch ex As Exception

            ErrorMessage = ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

        If ModifiedAdvantageServicesConnection = False Then

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageServicesConnectionPage", "Failed to modifying to the connection database profile to registry.")

                Else

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageServicesConnectionPage", "Failed to modifying to the connection database profile to registry." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                End If

            Else

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    DevExpress.XtraEditors.XtraMessageBox.Show("Failed to modifying to the connection database profile to registry.")

                Else

                    DevExpress.XtraEditors.XtraMessageBox.Show("Failed to modifying to the connection database profile to registry." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                End If

            End If

        End If

        If ModifiedAdvantageServicesConnection Then

            Me.WizardViewModel.PageCompleted()

        Else

            CType(Me.WizardViewModel.View.Documents(9).Control, ConversionPage).SetupSkipConversion()
            CType(Me.WizardViewModel.Pages(9), ConversionPageViewModel).SetIsComplete(True)

            Me.WizardViewModel.GoToPage(10)

        End If

    End Sub

#End Region

#End Region

End Class
