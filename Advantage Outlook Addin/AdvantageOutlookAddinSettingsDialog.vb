Public Class AdvantageOutlookAddinSettingsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    'Private ReadOnly Property SecuritySession As AdvantageFramework.Security.Session
    '    Get
    '        SecuritySession = Me.session
    '    End Get
    'End Property

#End Region

#Region " Methods "

    Private Sub New(ByVal Session As AdvantageFramework.Security.Session)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetSession(Session)

    End Sub
    Private Sub EnableDisableLogin()

        TextBoxForm_User.Enabled = RadioButtonForm_SyncOutlookAndAdvantageAppointments.Checked
        TextBoxForm_Employee.Enabled = RadioButtonForm_SyncOutlookAndAdvantageAppointments.Checked

        ButtonForm_LogIn.Enabled = RadioButtonForm_SyncOutlookAndAdvantageAppointments.Checked
        ButtonForm_LogOut.Enabled = RadioButtonForm_SyncOutlookAndAdvantageAppointments.Checked

        If RadioButtonForm_SyncOutlookAndAdvantageAppointments.Checked = False Then

            Me.SetSession(Nothing)

            TextBoxForm_User.Text = ""
            TextBoxForm_Employee.Text = ""

            ButtonForm_LogIn.Visible = True
            ButtonForm_LogOut.Visible = False

        End If

    End Sub

#Region "  Show Form Methods "

    Public Shared Function ShowFormDialog(ByRef Session As AdvantageFramework.Security.Session) As Windows.Forms.DialogResult

        'objects
        Dim AdvantageOutlookAddinSettingsDialog As Advantage_Outlook_Addin.AdvantageOutlookAddinSettingsDialog = Nothing

        AdvantageOutlookAddinSettingsDialog = New Advantage_Outlook_Addin.AdvantageOutlookAddinSettingsDialog(Session)

        ShowFormDialog = AdvantageOutlookAddinSettingsDialog.ShowDialog()

        Session = AdvantageOutlookAddinSettingsDialog.Session

    End Function

#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageOutlookAddinSettingsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ByPassUserEntryChanged = True

        Me.ShowUnsavedChangesOnFormClosing = False

        RadioButtonForm_None.ByPassUserEntryChanged = True
        RadioButtonForm_SyncAdvantageAppointmentsOnly.ByPassUserEntryChanged = True
        RadioButtonForm_SyncOutlookAndAdvantageAppointments.ByPassUserEntryChanged = True

        TextBoxForm_User.ByPassUserEntryChanged = True
        TextBoxForm_Employee.ByPassUserEntryChanged = True

        If My.Settings.SyncAdvantageAppointmentsOnly = False AndAlso My.Settings.SyncOutlookAndAdvantageAppointments = False Then

            RadioButtonForm_None.Checked = True

        Else

            RadioButtonForm_SyncOutlookAndAdvantageAppointments.Checked = My.Settings.SyncOutlookAndAdvantageAppointments
            RadioButtonForm_SyncAdvantageAppointmentsOnly.Checked = My.Settings.SyncAdvantageAppointmentsOnly

        End If

        If Me.Session IsNot Nothing Then

            TextBoxForm_User.Text = Me.Session.UserCode

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    TextBoxForm_Employee.Text = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode).ToString

                End Using

            Catch ex As Exception

            End Try

            ButtonForm_LogIn.Visible = False
            ButtonForm_LogOut.Visible = True

        Else

            TextBoxForm_User.Text = ""
            TextBoxForm_Employee.Text = ""

            ButtonForm_LogIn.Visible = True
            ButtonForm_LogOut.Visible = False

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

        If Me.Session IsNot Nothing Then

            My.Settings.SyncOutlookAndAdvantageAppointments = RadioButtonForm_SyncOutlookAndAdvantageAppointments.Checked
            My.Settings.SyncAdvantageAppointmentsOnly = False
            My.Settings.ServerName = Me.Session.ServerName
            My.Settings.DatabaseName = Me.Session.DatabaseName
            My.Settings.UserName = Me.Session.UserName
            My.Settings.Password = AdvantageFramework.StringUtilities.Encrypt(Me.Session.Password)
            My.Settings.UseWindowsAuthentication = Me.Session.UseWindowsAuthentication

        Else

            My.Settings.SyncOutlookAndAdvantageAppointments = False
            My.Settings.SyncAdvantageAppointmentsOnly = RadioButtonForm_SyncAdvantageAppointmentsOnly.Checked
            My.Settings.ServerName = ""
            My.Settings.DatabaseName = ""
            My.Settings.UserName = ""
            My.Settings.Password = ""
            My.Settings.UseWindowsAuthentication = False

        End If

        My.Settings.Save()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
    Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
    Private Sub ButtonForm_LogIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_LogIn.Click

        'objects
        Dim SecuritySession As AdvantageFramework.Security.Session = Nothing

        If AdvantageFramework.Security.Presentation.LoginDialog.ShowFormDialog(AdvantageFramework.Security.Application.Outlook_Addin, Nothing, _
                                                                               SecuritySession, "", "", False, "", False) = System.Windows.Forms.DialogResult.OK Then

            Me.SetSession(SecuritySession)

            TextBoxForm_User.Text = Me.Session.UserCode

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    TextBoxForm_Employee.Text = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode).ToString

                End Using

            Catch ex As Exception

            End Try

            ButtonForm_LogIn.Visible = False
            ButtonForm_LogOut.Visible = True

        End If

    End Sub
    Private Sub ButtonForm_LogOut_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_LogOut.Click

        Me.SetSession(Nothing)

        TextBoxForm_User.Text = ""
        TextBoxForm_Employee.Text = ""

        ButtonForm_LogIn.Visible = True
        ButtonForm_LogOut.Visible = False

    End Sub
    Private Sub RadioButtonForm_None_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonForm_None.CheckedChanged

        If RadioButtonForm_None.Checked Then

            EnableDisableLogin()

        End If

    End Sub
    Private Sub RadioButtonForm_SyncAdvantageAppointmentsOnly_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonForm_SyncAdvantageAppointmentsOnly.CheckedChanged

        If RadioButtonForm_SyncAdvantageAppointmentsOnly.Checked Then

            EnableDisableLogin()

        End If

    End Sub
    Private Sub RadioButtonForm_SyncOutlookAndAdvantageAppointments_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonForm_SyncOutlookAndAdvantageAppointments.CheckedChanged

        If RadioButtonForm_SyncOutlookAndAdvantageAppointments.Checked Then

            EnableDisableLogin()

        End If

    End Sub

#End Region

#End Region

End Class