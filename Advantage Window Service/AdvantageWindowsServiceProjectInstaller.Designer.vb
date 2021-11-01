<System.ComponentModel.RunInstaller(True)> Partial Class AdvantageWindowsServiceProjectInstaller
    Inherits System.Configuration.Install.Installer

    'Installer overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AdvantageWindowsServiceProcessInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        Me.AdvantageWindowsServiceInstaller = New System.ServiceProcess.ServiceInstaller()
        '
        'AdvantageWindowsServiceProcessInstaller
        '
        Me.AdvantageWindowsServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.AdvantageWindowsServiceProcessInstaller.Password = Nothing
        Me.AdvantageWindowsServiceProcessInstaller.Username = Nothing
        '
        'AdvantageWindowsServiceInstaller
        '
        Me.AdvantageWindowsServiceInstaller.Description = "Advantage Windows Services Controller"
        Me.AdvantageWindowsServiceInstaller.DisplayName = "Advantage Windows Service"
        Me.AdvantageWindowsServiceInstaller.ServiceName = "AdvantageWindowsService"
        Me.AdvantageWindowsServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'AdvantageWindowsServiceProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.AdvantageWindowsServiceProcessInstaller, Me.AdvantageWindowsServiceInstaller})

    End Sub
    Friend WithEvents AdvantageWindowsServiceProcessInstaller As System.ServiceProcess.ServiceProcessInstaller
    Friend WithEvents AdvantageWindowsServiceInstaller As System.ServiceProcess.ServiceInstaller

End Class
