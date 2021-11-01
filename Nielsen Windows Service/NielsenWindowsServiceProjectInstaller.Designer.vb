<System.ComponentModel.RunInstaller(True)> Partial Class NielsenWindowsServiceProjectInstaller
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.NielsenWindowsServiceProcessInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        Me.NielsenWindowsServiceInstaller = New System.ServiceProcess.ServiceInstaller()
        '
        'NielsenWindowsServiceProcessInstaller
        '
        Me.NielsenWindowsServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.NielsenWindowsServiceProcessInstaller.Password = Nothing
        Me.NielsenWindowsServiceProcessInstaller.Username = Nothing
        '
        'NielsenWindowsServiceInstaller
        '
        Me.NielsenWindowsServiceInstaller.Description = "Nielsen Windows Service Installer"
        Me.NielsenWindowsServiceInstaller.DisplayName = "Nielsen Windows Service"
        Me.NielsenWindowsServiceInstaller.ServiceName = "NielsenWindowsService"
        Me.NielsenWindowsServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'NielsenWindowsServiceProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.NielsenWindowsServiceProcessInstaller, Me.NielsenWindowsServiceInstaller})

    End Sub

    Friend WithEvents NielsenWindowsServiceProcessInstaller As ServiceProcess.ServiceProcessInstaller
    Friend WithEvents NielsenWindowsServiceInstaller As ServiceProcess.ServiceInstaller
End Class
