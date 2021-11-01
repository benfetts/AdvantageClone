Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Protected Overrides Function OnInitialize(ByVal commandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean

            Me.MinimumSplashScreenDisplayTime = 3000

            Return MyBase.OnInitialize(commandLineArgs)

        End Function
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            DevExpress.UserSkins.BonusSkins.Register()
            System.Windows.Forms.Application.EnableVisualStyles()

        End Sub
        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            If AdvantageFramework.Error.ShowFormDialog(e.Exception) = System.Windows.Forms.DialogResult.Abort Then

                e.ExitApplication = True

            Else

                e.ExitApplication = False

            End If

            If e.ExitApplication Then

                If TypeOf Me.MainForm Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                    DirectCast(Me.MainForm, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).ShutDown()

                End If

            End If

        End Sub

    End Class

End Namespace

