Namespace Database.Presentation

    Public Class SQLUserEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserCode As String = ""

#End Region

#Region " Properties "

        Private Property UserCode As String
            Get
                UserCode = _UserCode
            End Get
            Set(ByVal value As String)
                _UserCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal UserCode As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _UserCode = UserCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef UserCode As String = "") As System.Windows.Forms.DialogResult

            'objects
            Dim SQLUserEditDialog As SQLUserEditDialog = Nothing

            SQLUserEditDialog = New SQLUserEditDialog(UserCode)

            ShowFormDialog = SQLUserEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub SQLUserEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ServerSQLUser As AdvantageFramework.Security.Database.Views.ServerSQLUser = Nothing

            If _UserCode = "" Then

                ButtonForm_Update.Visible = False
                ButtonForm_Add.Visible = True
                Me.Text = "Add SQL User"

            Else

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ' ServerSQLUser = AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.LoadByName(SecurityDbContext, _UserCode)

                    If ServerSQLUser IsNot Nothing Then

                        ButtonForm_Update.Visible = True
                        ButtonForm_Add.Visible = False
                        Me.Text = "Edit SQL User"

                        TextBoxForm_LoginName.Text = ServerSQLUser.Name

                        If ServerSQLUser.Type = "U" Then

                            RadioButtonForm_Windows.Checked = True
                            RadioButtonForm_SQLUser.Checked = False

                        Else

                            RadioButtonForm_Windows.Checked = False
                            RadioButtonForm_SQLUser.Checked = True

                        End If

                        'If AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.IsServerSQLUserSecurityAdmin(SecurityDbContext, ServerSQLUser.ID) Then

                        '    CheckBoxForm_IsSecurityAdmin.Checked = True

                        'Else

                        '    CheckBoxForm_IsSecurityAdmin.Checked = False

                        'End If

                    Else

                        ButtonForm_Update.Visible = False
                        ButtonForm_Add.Visible = True
                        Me.Text = "Add SQL User"

                    End If

                End Using

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "


        Private Sub RadioButtonForm_Windows_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonForm_Windows.CheckedChanged

            If RadioButtonForm_Windows.Checked Then

                TextBoxForm_Password.Enabled = False
                TextBoxForm_Confirm.Enabled = False
                CheckBoxForm_EnforcePasswordPolicy.Enabled = False

            End If

        End Sub
        Private Sub RadioButtonForm_SQLUser_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonForm_SQLUser.CheckedChanged

            If RadioButtonForm_SQLUser.Checked Then

                TextBoxForm_Password.Enabled = True
                TextBoxForm_Confirm.Enabled = True
                CheckBoxForm_EnforcePasswordPolicy.Enabled = True

            End If

        End Sub
        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                'If AdvantageFramework.Security.Database.Procedures.ServerSQLUserView.CreateServerSQLUser(SecurityDbContext, TextBoxForm_LoginName.Text,
                '                                                                                         RadioButtonForm_Windows.Checked, TextBoxForm_Password.Text,
                '                                                                                         TextBoxForm_Confirm.Text, CheckBoxForm_IsSecurityAdmin.Checked,
                '                                                                                         CheckBoxForm_EnforcePasswordPolicy.Checked, False, ErrorMessage) Then

                '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                '    Me.Close()

                'Else

                '    If ErrorMessage <> "" Then

                '        AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                '    End If

                'End If

            End Using

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
