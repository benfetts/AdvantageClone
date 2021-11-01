Namespace WinForm.Presentation

    Public Class ConnectedUsersDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LicenseKeyType As AdvantageFramework.Security.LicenseKey.Types = AdvantageFramework.Security.LicenseKey.Types.PowerUser

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal LicenseKeyType As AdvantageFramework.Security.LicenseKey.Types)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _LicenseKeyType = LicenseKeyType

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal LicenseKeyType As AdvantageFramework.Security.LicenseKey.Types) As System.Windows.Forms.DialogResult

            'objects
            Dim ConnectedUsersDialog As ConnectedUsersDialog = Nothing

            ConnectedUsersDialog = New ConnectedUsersDialog(LicenseKeyType)

            ShowFormDialog = ConnectedUsersDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ConnectedUsersDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_ConnectedUsers.DataSource = AdvantageFramework.Security.LicenseKey.LoadAllConnectedUsers(Me.Session, _LicenseKeyType)

            If _LicenseKeyType = Security.LicenseKey.Types.PowerUser Then

                Me.Text = "Power User Connected Users"

            ElseIf _LicenseKeyType = Security.LicenseKey.Types.WebvantageOnly Then

                Me.Text = "Webvantage Only Connected Users"

            ElseIf _LicenseKeyType = Security.LicenseKey.Types.ClientPortalUser Then

                Me.Text = "Client Portal Connected Users"

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace