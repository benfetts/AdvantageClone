Imports DevExpress.LookAndFeel

Friend NotInheritable Class Program
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    Private Sub New()
    End Sub
    <STAThread>
    Shared Sub Main()

        DevExpress.UserSkins.BonusSkins.Register()
        System.Windows.Forms.Application.EnableVisualStyles()

        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New StartPage())
    End Sub
End Class
