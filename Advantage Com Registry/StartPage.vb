Partial Public Class StartPage
    Inherits DevExpress.XtraEditors.XtraForm

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

#Region "  Show Form Methods "

    Private Sub StartPage_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName)

        Catch ex As Exception

            Me.Icon = AdvantageFramework.My.Resources.MaintenanceIcon

        End Try

    End Sub

#End Region

#Region "  Form Event Handlers "

    Private Sub SimpleButtonRegisterComLibrary_Click(sender As Object, e As EventArgs) Handles SimpleButtonRegisterComLibrary.Click

        Dim Registered As Boolean = False
        Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing

        OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me)

        Try

            Registered = AdvantageFramework.ComUtilities.RegisterDLL("AdvantageFramework.Security.Adassist.dll", "AdvantageFramework.Security.Adassist")

            If Registered Then

                Registered = AdvantageFramework.ComUtilities.RegisterDLL("AdvantageFramework.Com.dll", "AdvantageFramework.Com.FTP")

            End If

        Catch ex As Exception

        End Try

        DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

        If Registered Then

            DevExpress.XtraEditors.XtraMessageBox.Show("Registered com libraries successfully!")

        Else

            DevExpress.XtraEditors.XtraMessageBox.Show("Failed to register a com library!")

        End If

        System.Windows.Forms.Application.Exit()

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class
