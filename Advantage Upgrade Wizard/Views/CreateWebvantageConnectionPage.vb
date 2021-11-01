Partial Public Class CreateWebvantageConnectionPage
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
    Public Sub Create()

        SimpleButtonForm_Create.PerformClick()

    End Sub
    Public Sub Skip()

        Me.WizardViewModel.Next()

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub SimpleButtonForm_Create_Click(sender As Object, e As System.EventArgs) Handles SimpleButtonForm_Create.Click

        Dim CreatedWebvantageConnection As Boolean = False
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        Dim ErrorMessage As String = String.Empty

        OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me)

        If ContainsIllegalCharacters(Me.WizardViewModel.WizardInputs.AdvantagePassword) = False Then

            Try

                ConnectionDatabaseProfile = New AdvantageFramework.Database.ConnectionDatabaseProfile

                ConnectionDatabaseProfile.ServerName = Me.WizardViewModel.WizardInputs.ServerName
                ConnectionDatabaseProfile.DatabaseName = Me.WizardViewModel.WizardInputs.Database
                ConnectionDatabaseProfile.UserName = Me.WizardViewModel.WizardInputs.AdvantageUserName
                ConnectionDatabaseProfile.Password = Me.WizardViewModel.WizardInputs.AdvantagePassword

                If AdvantageFramework.Database.SaveConnectionDatabaseProfile(ConnectionDatabaseProfile, False) Then

                    CreatedWebvantageConnection = True

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

        Else

            CreatedWebvantageConnection = False
            ErrorMessage = "Password cannot include characters:  ?, #, /, ', &, or ""."

        End If

        DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

        If CreatedWebvantageConnection = False Then

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("WebvantageConnectionPage", "Failed to saving to the connection database profile to registry.")

                Else

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("WebvantageConnectionPage", "Failed to saving to the connection database profile to registry." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                End If

            Else

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    DevExpress.XtraEditors.XtraMessageBox.Show("Failed to saving to the connection database profile to registry.")

                Else

                    DevExpress.XtraEditors.XtraMessageBox.Show("Failed to saving to the connection database profile to registry." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                End If

            End If

        End If

        If CreatedWebvantageConnection Then

            Me.WizardViewModel.PageCompleted()

        Else

            CType(Me.WizardViewModel.View.Documents(9).Control, ConversionPage).SetupSkipConversion()
            CType(Me.WizardViewModel.Pages(9), ConversionPageViewModel).SetIsComplete(True)

            Me.WizardViewModel.GoToPage(10)

        End If

    End Sub
    Public Function ContainsIllegalCharacters(ByVal StringToCheck As String) As Boolean

        If StringToCheck.Contains("?") = True OrElse
           StringToCheck.Contains("#") = True OrElse
           StringToCheck.Contains("/") = True OrElse
           StringToCheck.Contains("'") = True OrElse
           StringToCheck.Contains("&") = True OrElse
           StringToCheck.Contains("""") = True Then

            Return True

        Else

            Return False

        End If

    End Function

#End Region

#End Region

End Class
