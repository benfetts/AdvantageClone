Namespace Security.Setup.Presentation

    Public Class ClientPortalUserEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientPortalUserID As System.Guid = Nothing

#End Region

#Region " Properties "

        Private Property ClientPortalUserID As System.Guid
            Get
                ClientPortalUserID = _ClientPortalUserID
            End Get
            Set(ByVal value As System.Guid)
                _ClientPortalUserID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef ClientPortalUserID As System.Guid)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ClientPortalUserID = ClientPortalUserID

        End Sub
        Private Sub ClearAndDisableForm()

            TextBoxForm_Name.Text = ""
            TextBoxForm_UserName.Text = ""
            TextBoxForm_UserName.Enabled = False
            TextBoxForm_UserCode.Text = ""
            TextBoxForm_Email.Text = ""

            ComboBoxForm_WorkspaceTemplate.SelectedIndex = 0
            ComboBoxForm_WorkspaceTemplate.Enabled = False

            ComboBoxForm_DefaultAgencyContact.SelectedIndex = 0
            ComboBoxForm_DefaultAlertGroup.SelectedIndex = 0

            ComboBoxForm_DefaultAgencyContact.Enabled = False
            ComboBoxForm_DefaultAlertGroup.Enabled = False

            TextBoxForm_Password.Text = ""
            TextBoxForm_ConfirmPassword.Text = ""

            TextBoxForm_Password.Enabled = False
            TextBoxForm_ConfirmPassword.Enabled = False

            ButtonForm_Add.Enabled = False

        End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(Optional ByRef ClientPortalUserID As System.Guid = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientPortalUserEditDialog As AdvantageFramework.Security.Setup.Presentation.ClientPortalUserEditDialog = Nothing

            ClientPortalUserEditDialog = New AdvantageFramework.Security.Setup.Presentation.ClientPortalUserEditDialog(ClientPortalUserID)

            ShowFormDialog = ClientPortalUserEditDialog.ShowDialog()

            ClientPortalUserID = ClientPortalUserEditDialog.ClientPortalUserID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientPortalUserEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
            Dim UserEmployeeAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserEmployeeAccess) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_DefaultAlertGroup.DataSource = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActive(DbContext)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_WorkspaceTemplate.DataSource = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.LoadClientPortalWorkspaceTemplates(SecurityDbContext)

                    UserEmployeeAccessList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, Me.Session.UserCode).Include("Employee").ToList

                    If UserEmployeeAccessList.Count = 0 Then

                        ComboBoxForm_DefaultAgencyContact.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList

                    Else

                        ComboBoxForm_DefaultAgencyContact.DataSource = UserEmployeeAccessList.Select(Function(UserEmployeeAccess) UserEmployeeAccess.Employee).ToList

                    End If

                    TextBoxForm_UserName.SetPropertySettings(AdvantageFramework.Security.Database.Entities.ClientPortalUser.Properties.UserName)

                    If _ClientPortalUserID = Nothing Then

                        ComboBoxForm_User.ControlType = WinForm.Presentation.Controls.ComboBox.Type.ClientContact
                        ComboBoxForm_User.ExtraComboBoxItem = WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.Nothing

                        ComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)

                        ButtonForm_Update.Visible = False
                        ButtonForm_Add.Visible = True
                        Me.Text = "Add Client Portal User"

                    Else

                        ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserID(SecurityDbContext, _ClientPortalUserID)

                        If ClientPortalUser IsNot Nothing Then

                            ComboBoxForm_User.ControlType = WinForm.Presentation.Controls.ComboBox.Type.ClientPortalUser
                            ComboBoxForm_User.ExtraComboBoxItem = WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.Nothing

                            ComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)

                            ComboBoxForm_Client.Enabled = False
                            ComboBoxForm_User.Enabled = False

                            ButtonForm_Update.Visible = True
                            ButtonForm_Add.Visible = False
                            Me.Text = "Edit Client Portal User"

                            ComboBoxForm_Client.SelectedValue = ClientPortalUser.ClientContact.ClientCode

                            TextBoxForm_Name.Text = ClientPortalUser.ClientContact.FullNameFML
                            TextBoxForm_UserName.Text = ClientPortalUser.UserName
                            TextBoxForm_UserCode.Text = ClientPortalUser.ClientContact.ContactCode
                            TextBoxForm_Email.Text = ClientPortalUser.ClientContact.EmailAddress

                            ComboBoxForm_WorkspaceTemplate.SelectedValue = ClientPortalUser.DesktopTemplate.GetValueOrDefault(0)

                            ComboBoxForm_DefaultAgencyContact.SelectedValue = ClientPortalUser.AgencyContactEmployeeCode
                            ComboBoxForm_DefaultAlertGroup.SelectedValue = ClientPortalUser.AlertGroupCode

                            TextBoxForm_Password.Text = ClientPortalUser.Password
                            TextBoxForm_ConfirmPassword.Text = ClientPortalUser.Password

                            TextBoxForm_Password.Enabled = False
                            TextBoxForm_ConfirmPassword.Enabled = False

                        End If

                    End If

                End Using

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim EnableProofingTool As Boolean = False
            Dim AgencyName As String = ""
            Dim LicenseKey As String = ""
            Dim DatabaseID As Integer = 0
            Dim ErrorMessage As String = ""

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.Security.LicenseKey.CheckForValidLicenseKey(DbContext, LicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, DatabaseID, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage) Then

                        If ClientPortalUsersQuantity = -1 OrElse AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Load(SecurityDbContext).Count + 1 <= ClientPortalUsersQuantity Then

                            Me.ShowWaitForm("Processing...")

                            ClientPortalUser = New AdvantageFramework.Security.Database.Entities.ClientPortalUser

                            ClientPortalUser.DbContext = SecurityDbContext
                            ClientPortalUser.ClientCode = ComboBoxForm_Client.GetSelectedValue
                            ClientPortalUser.ClientContactID = ComboBoxForm_User.GetSelectedValue
                            ClientPortalUser.FullName = TextBoxForm_Name.Text
                            ClientPortalUser.UserName = TextBoxForm_UserName.Text
                            ClientPortalUser.EmailAddress = TextBoxForm_Email.Text
                            ClientPortalUser.DesktopTemplate = CInt(ComboBoxForm_WorkspaceTemplate.GetSelectedValue)
                            ClientPortalUser.LoweredUserName = TextBoxForm_UserName.Text.ToLower
                            ClientPortalUser.Theme = "ThreePointOhOatmeal"

                            ClientPortalUser.CreatedByUserCode = Me.Session.UserCode
                            ClientPortalUser.CreatedDate = Now

                            If ComboBoxForm_DefaultAgencyContact.HasASelectedValue Then

                                ClientPortalUser.AgencyContactEmployeeCode = ComboBoxForm_DefaultAgencyContact.GetSelectedValue

                            Else

                                ClientPortalUser.AgencyContactEmployeeCode = Nothing

                            End If

                            If ComboBoxForm_DefaultAlertGroup.HasASelectedValue Then

                                ClientPortalUser.AlertGroupCode = ComboBoxForm_DefaultAlertGroup.GetSelectedValue

                            Else

                                ClientPortalUser.AlertGroupCode = Nothing

                            End If

                            If TextBoxForm_Password.Text = TextBoxForm_ConfirmPassword.Text Then
                                '*Password must be at least 8 characters long, has to contain letters and numbers, and one uppercase letter. 
                                If TextBoxForm_Password.Text.Length >= 8 Then

                                    If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(TextBoxForm_Password.Text) <> "" Then

                                        If AdvantageFramework.StringUtilities.IsRegularExpressionAMatch("^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,20}$", TextBoxForm_Password.Text) Then

                                            ClientPortalUser.Password = AdvantageFramework.Security.Encryption.GenerateSHA256ManagedHash(TextBoxForm_Password.Text)

                                            If AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Insert(SecurityDbContext, ClientPortalUser) Then

                                                _ClientPortalUserID = ClientPortalUser.ID

                                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                                Me.Close()

                                            End If

                                        Else

                                            AdvantageFramework.WinForm.MessageBox.Show("Password must contain one uppercase letter. Please retype your passwords and try again.")

                                            TextBoxForm_Password.Text = ""
                                            TextBoxForm_ConfirmPassword.Text = ""

                                        End If

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("Password must contain one number. Please retype your passwords and try again.")

                                        TextBoxForm_Password.Text = ""
                                        TextBoxForm_ConfirmPassword.Text = ""

                                    End If

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Password is not greater than or equal to minimum length of 8. Please retype your passwords and try again.")

                                    TextBoxForm_Password.Text = ""
                                    TextBoxForm_ConfirmPassword.Text = ""

                                End If

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("Passwords do not match. Please retype your passwords and try again.")

                                TextBoxForm_Password.Text = ""
                                TextBoxForm_ConfirmPassword.Text = ""

                            End If

                            Me.CloseWaitForm()

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("You do not have enough licenses available to add a new user.  Please contact Advantage support.")

                            TextBoxForm_Password.Text = ""
                            TextBoxForm_ConfirmPassword.Text = ""

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        TextBoxForm_Password.Text = ""
                        TextBoxForm_ConfirmPassword.Text = ""

                    End If

                End Using

            End Using

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
            Dim UpdateWorkspace As Boolean = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Me.ShowWaitForm("Processing...")

                ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserID(SecurityDbContext, _ClientPortalUserID)

                If ClientPortalUser IsNot Nothing Then

                    ClientPortalUser.UserName = TextBoxForm_UserName.Text
                    ClientPortalUser.EmailAddress = TextBoxForm_Email.Text

                    If ClientPortalUser.DesktopTemplate <> CInt(ComboBoxForm_WorkspaceTemplate.GetSelectedValue) Then

                        UpdateWorkspace = True

                    End If

                    ClientPortalUser.DesktopTemplate = CInt(ComboBoxForm_WorkspaceTemplate.GetSelectedValue)

                    If ComboBoxForm_DefaultAgencyContact.HasASelectedValue Then

                        ClientPortalUser.AgencyContactEmployeeCode = ComboBoxForm_DefaultAgencyContact.GetSelectedValue

                    Else

                        ClientPortalUser.AgencyContactEmployeeCode = Nothing

                    End If

                    If ComboBoxForm_DefaultAlertGroup.HasASelectedValue Then

                        ClientPortalUser.AlertGroupCode = ComboBoxForm_DefaultAlertGroup.GetSelectedValue

                    Else

                        ClientPortalUser.AlertGroupCode = Nothing

                    End If

                    If AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Update(SecurityDbContext, ClientPortalUser, UpdateWorkspace) Then

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                End If

                Me.CloseWaitForm()

            End Using

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_Client_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Client.SelectedIndexChanged

            'objects
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _ClientPortalUserID = Nothing Then

                    ComboBoxForm_User.DataSource = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadAllAvailableByClientCode(SecurityDbContext, ComboBoxForm_Client.GetSelectedValue)

                    If ComboBoxForm_Client.HasASelectedValue = False AndAlso ComboBoxForm_User.Items.Count = 0 Then

                        ComboBoxForm_User.Enabled = False

                        ClearAndDisableForm()

                    Else

                        ComboBoxForm_User.Enabled = True

                    End If

                Else

                    ComboBoxForm_User.DataSource = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Load(SecurityDbContext).Include("ClientContact").ToList

                    ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserID(SecurityDbContext, _ClientPortalUserID)

                    If ClientPortalUser IsNot Nothing Then

                        ComboBoxForm_User.SelectedValue = ClientPortalUser.ClientContactID

                    End If

                End If

            End Using

        End Sub
        Private Sub ComboBoxForm_User_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_User.SelectedIndexChanged

            'objects
            Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact = Nothing
            Dim ClearAndDisable As Boolean = True

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _ClientPortalUserID = Nothing Then

                    If ComboBoxForm_User.HasASelectedValue Then

                        ClientContact = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadByClientContactID(SecurityDbContext, ComboBoxForm_User.GetSelectedValue)

                        If ClientContact IsNot Nothing Then

                            ClearAndDisable = False

                            TextBoxForm_Name.Text = ClientContact.FullNameFML
                            TextBoxForm_UserName.Text = ""
                            TextBoxForm_UserName.Enabled = True
                            TextBoxForm_UserCode.Text = ClientContact.ContactCode
                            TextBoxForm_Email.Text = ClientContact.EmailAddress

                            ComboBoxForm_WorkspaceTemplate.SelectedIndex = 0
                            ComboBoxForm_WorkspaceTemplate.Enabled = True

                            ComboBoxForm_DefaultAgencyContact.SelectedIndex = 0
                            ComboBoxForm_DefaultAlertGroup.SelectedIndex = 0

                            ComboBoxForm_DefaultAgencyContact.Enabled = True
                            ComboBoxForm_DefaultAlertGroup.Enabled = True

                            TextBoxForm_Password.Text = ""
                            TextBoxForm_ConfirmPassword.Text = ""

                            TextBoxForm_Password.Enabled = True
                            TextBoxForm_ConfirmPassword.Enabled = True

                            ButtonForm_Add.Enabled = True

                        End If

                    End If

                    If ClearAndDisable Then

                        ClearAndDisableForm()

                    End If

                End If

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace
