Namespace Security.Setup.Presentation

    Public Class ClientPortalUserSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LoadClientPortalUserModuleAccess As Boolean = False
        Private _ClientPortalUserList As Generic.List(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub SaveClientPortalUserModuleAccess(ByVal ClientPortalUserModuleAccessProperty As AdvantageFramework.Security.Database.Entities.ClientPortalUserModuleAccess.Properties, ByVal NewValue As Boolean)

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim ClientPortalUserModuleAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserModuleAccess = Nothing

            If _LoadClientPortalUserModuleAccess = False AndAlso _ClientPortalUserList IsNot Nothing AndAlso _ClientPortalUserList.Count > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each SelectedNode In AdvTreeModuleAccess_Modules.SelectedNodes

                        Try

                            [Module] = SelectedNode.Tag

                        Catch ex As Exception
                            [Module] = Nothing
                        End Try

                        If [Module] IsNot Nothing Then

                            If [Module].IsCategory = False Then

                                For Each ClientPortalUser In _ClientPortalUserList

                                    Try

                                        ClientPortalUserModuleAccess = ClientPortalUser.ClientPortalUserModuleAccesses.SingleOrDefault(Function(GrpModAccess) GrpModAccess.ModuleID = [Module].ModuleID)

                                    Catch ex As Exception
                                        ClientPortalUserModuleAccess = Nothing
                                    End Try

                                    If ClientPortalUserModuleAccess IsNot Nothing Then

                                        Try

                                            PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(ClientPortalUserModuleAccess).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                                                  Where [Property].Name = ClientPortalUserModuleAccessProperty.ToString
                                                                  Select [Property]).SingleOrDefault

                                        Catch ex As Exception
                                            PropertyDescriptor = Nothing
                                        End Try

                                        If PropertyDescriptor IsNot Nothing Then

                                            PropertyDescriptor.SetValue(ClientPortalUserModuleAccess, NewValue)

                                        End If

                                        AdvantageFramework.Security.Database.Procedures.ClientPortalUserModuleAccess.Update(SecurityDbContext, ClientPortalUserModuleAccess)

                                    End If

                                Next

                            End If

                        End If

                    Next

                End Using

            End If

        End Sub
        Private Sub LoadClientPortalUserModuleAccess()

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ClientPortalUserModuleAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserModuleAccess = Nothing
            Dim FirstSelectedModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            For Each SelectedNode In AdvTreeModuleAccess_Modules.SelectedNodes

                Try

                    [Module] = SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                Finally

                    If [Module] IsNot Nothing Then

                        If [Module].IsCategory = False Then

                            If FirstSelectedModule Is Nothing Then

                                FirstSelectedModule = [Module]

                            End If

                        End If

                    End If

                End Try

                If FirstSelectedModule IsNot Nothing Then

                    Exit For

                End If

            Next

            _LoadClientPortalUserModuleAccess = True

            If FirstSelectedModule IsNot Nothing AndAlso _ClientPortalUserList IsNot Nothing AndAlso _ClientPortalUserList.Count > 0 Then

                CheckBoxModuleAccess_IsBlocked.Visible = True

                If AdvTreeModuleAccess_Modules.SelectedNodes.Count = 1 Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If _ClientPortalUserList.Count = 1 Then

                            Try

                                ClientPortalUserModuleAccess = _ClientPortalUserList(0).ClientPortalUserModuleAccesses.SingleOrDefault(Function(GrpModAccess) GrpModAccess.ModuleID = FirstSelectedModule.ModuleID)

                            Catch ex As Exception
                                ClientPortalUserModuleAccess = Nothing
                            End Try

                            If ClientPortalUserModuleAccess IsNot Nothing Then

                                CheckBoxModuleAccess_IsBlocked.Checked = ClientPortalUserModuleAccess.IsBlocked

                            End If

                        Else

                            CheckBoxModuleAccess_IsBlocked.Checked = True

                            For Each ClientPortalUser In _ClientPortalUserList

                                Try

                                    ClientPortalUserModuleAccess = ClientPortalUser.ClientPortalUserModuleAccesses.SingleOrDefault(Function(GrpModAccess) GrpModAccess.ModuleID = FirstSelectedModule.ModuleID)

                                Catch ex As Exception
                                    ClientPortalUserModuleAccess = Nothing
                                End Try

                                If ClientPortalUserModuleAccess IsNot Nothing Then

                                    If ClientPortalUserModuleAccess.IsBlocked = False Then

                                        CheckBoxModuleAccess_IsBlocked.Checked = False

                                    End If

                                End If

                            Next

                        End If

                    End Using

                Else

                    CheckBoxModuleAccess_IsBlocked.Checked = False

                End If

            Else

                CheckBoxModuleAccess_IsBlocked.Visible = False

            End If

            TabItemClientPortalUserDetails_ModuleAccessTab.Tag = True

            _LoadClientPortalUserModuleAccess = False

        End Sub
        Private Sub LoadClientPortalUserApplicationAccess()

            'objects
            Dim ClientPortalUserApplicationAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserApplicationAccess = Nothing

            If _ClientPortalUserList IsNot Nothing AndAlso _ClientPortalUserList.Count > 0 Then

                _LoadClientPortalUserModuleAccess = True

                If _ClientPortalUserList.Count = 1 Then

                    Try

                        ClientPortalUserApplicationAccess = _ClientPortalUserList.FirstOrDefault.ClientPortalUserApplicationAccesses.SingleOrDefault(Function(CPUAppAccess) CPUAppAccess.ApplicationID = AdvantageFramework.Security.Application.Client_Portal)

                    Catch ex As Exception
                        ClientPortalUserApplicationAccess = Nothing
                    End Try

                    If ClientPortalUserApplicationAccess IsNot Nothing Then

                        CheckBoxModuleAccess_IsBlockedFromClientPortal.Checked = ClientPortalUserApplicationAccess.IsBlocked

                    Else

                        CheckBoxModuleAccess_IsBlockedFromClientPortal.Checked = False

                    End If

                Else

                    If _ClientPortalUserList.SelectMany(Function(ClientPortalUser) ClientPortalUser.ClientPortalUserApplicationAccesses).Any(Function(CPUAppAccess) CPUAppAccess.ApplicationID = AdvantageFramework.Security.Application.Client_Portal AndAlso CPUAppAccess.IsBlocked = True) Then

                        CheckBoxModuleAccess_IsBlockedFromClientPortal.Checked = True

                    Else

                        CheckBoxModuleAccess_IsBlockedFromClientPortal.Checked = False

                    End If

                End If

                _LoadClientPortalUserModuleAccess = False

            End If

        End Sub
		Private Sub SaveClientPortalUserApplicationAccess()

			'objects
			Dim ClientPortalUserApplicationAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserApplicationAccess = Nothing

			If _LoadClientPortalUserModuleAccess = False AndAlso _ClientPortalUserList IsNot Nothing AndAlso _ClientPortalUserList.Count > 0 Then

				Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					For Each ClientPortalUser In _ClientPortalUserList

						Try

							ClientPortalUserApplicationAccess = ClientPortalUser.ClientPortalUserApplicationAccesses.SingleOrDefault(Function(CPUAppAccess) CPUAppAccess.ApplicationID = AdvantageFramework.Security.Application.Client_Portal)

						Catch ex As Exception
							ClientPortalUserApplicationAccess = Nothing
						End Try

						If ClientPortalUserApplicationAccess IsNot Nothing Then

							ClientPortalUserApplicationAccess.IsBlocked = CheckBoxModuleAccess_IsBlockedFromClientPortal.Checked

							AdvantageFramework.Security.Database.Procedures.ClientPortalUserApplicationAccess.Update(SecurityDbContext, ClientPortalUserApplicationAccess)

						Else

							ClientPortalUserApplicationAccess = New AdvantageFramework.Security.Database.Entities.ClientPortalUserApplicationAccess

							ClientPortalUserApplicationAccess.DbContext = SecurityDbContext

							ClientPortalUserApplicationAccess.ApplicationID = AdvantageFramework.Security.Application.Client_Portal
							ClientPortalUserApplicationAccess.ClientPortalUserID = ClientPortalUser.ID
							ClientPortalUserApplicationAccess.IsBlocked = CheckBoxModuleAccess_IsBlockedFromClientPortal.Checked
							ClientPortalUserApplicationAccess.CanPrint = True
							ClientPortalUserApplicationAccess.CanUpdate = True
							ClientPortalUserApplicationAccess.CanAdd = True
							ClientPortalUserApplicationAccess.Custom1 = False
							ClientPortalUserApplicationAccess.Custom2 = False

							If AdvantageFramework.Security.Database.Procedures.ClientPortalUserApplicationAccess.Insert(SecurityDbContext, ClientPortalUserApplicationAccess) Then

								LoadClientPortalUserDetails(Nothing)

							End If

						End If

					Next

				End Using

			End If

		End Sub
		Private Sub LoadConceptShareTab()

			Dim ConceptShareUser As ConceptShareAPI.User = Nothing
			Dim ConceptShareAccountUser As ConceptShareAPI.AccountUser = Nothing
			Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing

			If _ClientPortalUserList IsNot Nothing AndAlso _ClientPortalUserList.Count = 1 Then

				ClientPortalUser = _ClientPortalUserList(0)

				If String.IsNullOrWhiteSpace(ClientPortalUser.ConceptSharePassword) = False Then

                    TextBoxConceptShare_Password.Text = AdvantageFramework.Security.Encryption.Decrypt(ClientPortalUser.ConceptSharePassword)

                End If

				Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

						If AdvantageFramework.ConceptShare.IsConceptShareEnabled(DataContext) = False Then

							TextBoxConceptShare_Password.Text = ""
							CheckBoxConceptShare_IsActive.Checked = True

							ButtonConceptShare_CreateUser.SecurityEnabled = False
							ButtonConceptShare_UpdateUser.SecurityEnabled = False
							ButtonConceptShare_RemoveUser.SecurityEnabled = False
							TextBoxConceptShare_Password.SecurityEnabled = False
							CheckBoxConceptShare_IsActive.SecurityEnabled = False

						Else

							ButtonConceptShare_CreateUser.Enabled = False
							ButtonConceptShare_UpdateUser.Enabled = (ClientPortalUser.ConceptShareUserID.GetValueOrDefault(0) > 0)
							ButtonConceptShare_RemoveUser.Enabled = (ClientPortalUser.ConceptShareUserID.GetValueOrDefault(0) > 0)

							If ClientPortalUser.ConceptShareUserID.GetValueOrDefault(0) > 0 Then

								Try

									ConceptShareAccountUser = AdvantageFramework.ConceptShare.LoadUser(DataContext, SecurityDbContext, New Security.Classes.ClientPortalUser(ClientPortalUser), ConceptShareUser)

								Catch ex As Exception

								End Try

								If ConceptShareUser IsNot Nothing AndAlso ConceptShareAccountUser IsNot Nothing Then

									CheckBoxConceptShare_IsActive.Checked = ConceptShareUser.IsActive

								Else

									CheckBoxConceptShare_IsActive.Checked = False

								End If

							Else

								TextBoxConceptShare_Password.Text = ""
								CheckBoxConceptShare_IsActive.Checked = True

							End If

						End If

					End Using

				End Using

				TabItemClientPortalUserDetails_ConceptShareTab.Tag = True

			End If

		End Sub
		Private Sub LoadClientPortalUserClientDivisionProductAccess()

            'objects
            Dim ClientContactDetailList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ClientContactDetail) = Nothing
            Dim Division As AdvantageFramework.Security.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Security.Database.Entities.Product = Nothing

            If _ClientPortalUserList IsNot Nothing AndAlso _ClientPortalUserList.Count > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientContactDetailList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.ClientContactDetail)

                    If _ClientPortalUserList.Count = 1 Then

                        If _ClientPortalUserList(0).ClientContact.ClientContactDetails.ToList.Count > 0 Then

                            For Each ClientContactDetail In _ClientPortalUserList(0).ClientContact.ClientContactDetails.ToList

                                If ClientContactDetail.ProductCode Is Nothing Then

                                    Division = AdvantageFramework.Security.Database.Procedures.Division.LoadByClientAndDivisionCode(SecurityDbContext, _ClientPortalUserList(0).ClientContact.ClientCode, ClientContactDetail.DivisionCode)

                                    If Division IsNot Nothing Then

                                        ClientContactDetailList.Add(New AdvantageFramework.Security.Database.Classes.ClientContactDetail(Division))

                                    End If

                                Else

                                    Product = AdvantageFramework.Security.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(SecurityDbContext, _ClientPortalUserList(0).ClientContact.ClientCode, ClientContactDetail.DivisionCode, ClientContactDetail.ProductCode)

                                    If Product IsNot Nothing Then

                                        ClientContactDetailList.Add(New AdvantageFramework.Security.Database.Classes.ClientContactDetail(Product))

                                    End If

                                End If

                            Next

                        Else

                            For Each Product In AdvantageFramework.Security.Database.Procedures.Product.LoaddByClientCode(SecurityDbContext, _ClientPortalUserList(0).ClientContact.ClientCode).ToList

                                ClientContactDetailList.Add(New AdvantageFramework.Security.Database.Classes.ClientContactDetail(Product))

                            Next

                        End If

                    End If

                    DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.DataSource = ClientContactDetailList

                    DataGridViewClientDivisionProductAccess_ClientDivisionProductAccess.CurrentView.BestFitColumns()

                End Using

            End If

        End Sub
        Private Sub LoadClientPortalUsers()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_ClientPortalUsers.DataSource = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Load(SecurityDbContext).Include("ClientContact").Include("ClientContact.Client").ToList

                DataGridViewLeftSection_ClientPortalUsers.CurrentView.BestFitColumns()

			End Using

        End Sub
		Private Sub LoadClientPortalUserDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

			'objects
			Dim ClearClientPortalUserDetails As Boolean = False
			Dim ClientPortalUserIDArray() As System.Guid = Nothing

			If DataGridViewLeftSection_ClientPortalUsers.HasASelectedRow Then

				If TabItem Is Nothing Then

					Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

						ClientPortalUserIDArray = DataGridViewLeftSection_ClientPortalUsers.GetAllSelectedRowsBookmarkValues().OfType(Of System.Guid).ToArray()

						_ClientPortalUserList = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserIDs(SecurityDbContext, ClientPortalUserIDArray).Include("ClientPortalUserApplicationAccesses").Include("ClientPortalUserModuleAccesses").Include("ClientContact").Include("ClientContact.ClientContactDetails").ToList

					End Using

					For Each TabItem In TabControlRightSection_ClientPortalUserDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

						TabItem.Tag = False

					Next

					TabItem = TabControlRightSection_ClientPortalUserDetails.SelectedTab

				End If

				CheckToShowConceptShareTab()

				If _ClientPortalUserList.Count = 1 Then

					TextBoxForm_Name.Text = _ClientPortalUserList(0).ClientContact.FullNameFML
					TextBoxForm_Email.Text = _ClientPortalUserList(0).ClientContact.EmailAddress

				Else

					TextBoxForm_Name.Text = ""
					TextBoxForm_Email.Text = ""

				End If

				If TabItem Is TabItemClientPortalUserDetails_ModuleAccessTab AndAlso TabItem.Tag = False Then

					LoadClientPortalUserModuleAccess()

					LoadClientPortalUserApplicationAccess()

				ElseIf TabItem Is TabItemClientPortalUserDetails_ClientDivisionProductAccessTab AndAlso TabItem.Tag = False Then

					LoadClientPortalUserClientDivisionProductAccess()

				ElseIf TabItem Is TabItemClientPortalUserDetails_ConceptShareTab AndAlso TabItem.Tag = False Then

					LoadConceptShareTab()

				End If

			Else

				_ClientPortalUserList = Nothing

				ClearClientPortalUserDetails = True

			End If

			If ClearClientPortalUserDetails Then

				ClearClientPortalUserDetail()

			End If

		End Sub
		Private Sub CheckToShowConceptShareTab()

			If _ClientPortalUserList.Count = 1 Then

				TabItemClientPortalUserDetails_ConceptShareTab.Visible = True

			Else

				If TabControlRightSection_ClientPortalUserDetails.SelectedTab Is TabItemClientPortalUserDetails_ConceptShareTab Then

					TabControlRightSection_ClientPortalUserDetails.SelectNextTab()

				End If

				TabItemClientPortalUserDetails_ConceptShareTab.Visible = False

			End If

		End Sub
		Private Sub ClearClientPortalUserDetail()

            AdvTreeModuleAccess_Modules.SelectedNode = Nothing

            CheckBoxModuleAccess_IsBlocked.Checked = False

			CheckBoxModuleAccess_IsBlockedFromClientPortal.Checked = False

			TextBoxForm_Name.Text = ""
			TextBoxForm_Email.Text = ""

			TextBoxConceptShare_Password.Text = ""
			CheckBoxConceptShare_IsActive.Checked = True

		End Sub
        Private Sub LoadModules()

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing
            Dim ApplicationID As Integer = 0

            AdvTreeModuleAccess_Modules.Nodes.Clear()

            ApplicationID = AdvantageFramework.Security.Application.Client_Portal

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each ModuleView In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.ModuleView).Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID Is Nothing AndAlso ModView.IsInactive = False).OrderBy(Function(ModView) ModView.SortOrder)

                    Node = New DevComponents.AdvTree.Node

                    Node.Text = ModuleView.ModuleDescription
                    Node.Tag = ModuleView

                    AdvTreeModuleAccess_Modules.Nodes.Add(Node)

                    LoadSubModule(ApplicationID, ModuleView, Node)

                Next

            End Using

        End Sub
		Private Sub LoadSubModule(ByVal ApplicationID As Integer, ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByRef ParentNode As DevComponents.AdvTree.Node)

			'objects
			Dim Node As DevComponents.AdvTree.Node = Nothing

			Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				For Each [SubModule] In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.ModuleView).Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID = ModuleView.ModuleID AndAlso ModView.IsInactive = False).OrderBy(Function(ModView) ModView.SortOrder)

					Node = New DevComponents.AdvTree.Node

					Node.Text = AdvantageFramework.Security.LoadDescriptionForModule(SecurityDbContext, SubModule)
					Node.Tag = SubModule

					ParentNode.Nodes.Add(Node)

					If SubModule.IsCategory Then

						LoadSubModule(ApplicationID, SubModule, Node)

					End If

				Next

			End Using

		End Sub
		Private Sub EnableOrDisableConceptShareCreateUser()

			'objects
			Dim Enable As Boolean = True

			If Me.FormAction = WinForm.Presentation.FormActions.None Then

				If ButtonConceptShare_UpdateUser.Enabled = False Then

					Enable = (String.IsNullOrWhiteSpace(TextBoxForm_Email.Text) = False)

					If Enable Then

						Enable = (String.IsNullOrWhiteSpace(TextBoxConceptShare_Password.Text) = False)

					End If

					ButtonConceptShare_CreateUser.Enabled = Enable

				Else

					ButtonConceptShare_CreateUser.Enabled = False

				End If

			End If

		End Sub

#Region "  Show Form Methods "

		Public Shared Sub ShowForm()

			'objects
			Dim ClientPortalUserSetupForm As AdvantageFramework.Security.Setup.Presentation.ClientPortalUserSetupForm = Nothing

			ClientPortalUserSetupForm = New AdvantageFramework.Security.Setup.Presentation.ClientPortalUserSetupForm()

			ClientPortalUserSetupForm.Show()

		End Sub

#End Region

#Region "  Form Event Handlers "

		Private Sub ClientPortalUserSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			'objects
			Dim Roles As Dictionary(Of Integer, String) = Nothing
			Dim ProjectRoles As Dictionary(Of Integer, String) = Nothing

			ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
			ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
			ButtonItemActions_ChangePassword.Image = AdvantageFramework.My.Resources.ChangePasswordImage
			ButtonItemActions_RefreshCDPAccess.Image = AdvantageFramework.My.Resources.RefreshImage

			TextBoxConceptShare_Password.SetPropertySettings(AdvantageFramework.Security.Database.Entities.ClientPortalUser.Properties.ConceptSharePassword)

			LoadModules()

			TabControlRightSection_ClientPortalUserDetails.SelectedTab = TabItemClientPortalUserDetails_ModuleAccessTab

			TextBoxForm_Name.ByPassUserEntryChanged = True
			TextBoxForm_Email.ByPassUserEntryChanged = True
			TextBoxConceptShare_Password.ByPassUserEntryChanged = True
			CheckBoxConceptShare_IsActive.ByPassUserEntryChanged = True
			CheckBoxConceptShare_ShowPassword.ByPassUserEntryChanged = True

			Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.ConceptShare.IsConceptShareEnabled(DataContext) = False Then

					TabControlRightSection_ClientPortalUserDetails.Tabs.Remove(TabItemClientPortalUserDetails_ConceptShareTab)

				End If

			End Using

		End Sub
		Private Sub ClientPortalUserSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

			LoadClientPortalUsers()

			ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow
			ButtonItemActions_Update.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow
			ButtonItemActions_ChangePassword.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow

			TabControlRightSection_ClientPortalUserDetails.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasASelectedRow

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub AdvTreeModuleAccess_Modules_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdvTreeModuleAccess_Modules.SelectionChanged

			LoadClientPortalUserModuleAccess()

		End Sub
		Private Sub DataGridViewLeftSection_ClientPortalUsers_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_ClientPortalUsers.SelectionChangedEvent

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

				Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

				LoadClientPortalUserDetails(Nothing)

				ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow
				ButtonItemActions_Update.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow
				ButtonItemActions_ChangePassword.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow

				TabControlRightSection_ClientPortalUserDetails.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasASelectedRow

				Me.ClearChanged()

				Me.FormAction = WinForm.Presentation.Methods.FormActions.None

			End If

		End Sub
		Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

			'objects
			Dim ClientPortalUserID As System.Guid = Nothing

			If AdvantageFramework.Security.Setup.Presentation.ClientPortalUserEditDialog.ShowFormDialog(ClientPortalUserID) = System.Windows.Forms.DialogResult.OK Then

				LoadClientPortalUsers()

				DataGridViewLeftSection_ClientPortalUsers.SelectRow(ClientPortalUserID)

			End If

		End Sub
		Private Sub ButtonItemActions_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Update.Click

			If DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow Then

				If AdvantageFramework.Security.Setup.Presentation.ClientPortalUserEditDialog.ShowFormDialog(DataGridViewLeftSection_ClientPortalUsers.CurrentView.GetRowCellValue(DataGridViewLeftSection_ClientPortalUsers.CurrentView.FocusedRowHandle, AdvantageFramework.Security.Database.Entities.ClientPortalUser.Properties.ID.ToString)) = System.Windows.Forms.DialogResult.OK Then

					LoadClientPortalUsers()

				End If

			End If

		End Sub
		Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

			'objects
			Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing

			If DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow Then

				If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

					Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

						ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientPortalUserID(SecurityDbContext, DataGridViewLeftSection_ClientPortalUsers.CurrentView.GetRowCellValue(DataGridViewLeftSection_ClientPortalUsers.CurrentView.FocusedRowHandle, AdvantageFramework.Security.Database.Entities.ClientPortalUser.Properties.ID.ToString))

						If AdvantageFramework.Security.Database.Procedures.ClientPortalUser.Delete(SecurityDbContext, ClientPortalUser) Then

							LoadClientPortalUsers()

							If DataGridViewLeftSection_ClientPortalUsers.HasRows = False Then

								ClearClientPortalUserDetail()

								ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow
								ButtonItemActions_Update.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow
								ButtonItemActions_ChangePassword.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow

								TabControlRightSection_ClientPortalUserDetails.Enabled = DataGridViewLeftSection_ClientPortalUsers.HasASelectedRow

							End If

						End If

					End Using

				End If

			End If

		End Sub
		Private Sub ButtonItemActions_RefreshCDPAccess_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_RefreshCDPAccess.Click

			Dim ClientContactDetailList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ClientContactDetail) = Nothing
			Dim Division As AdvantageFramework.Security.Database.Entities.Division = Nothing
			Dim Product As AdvantageFramework.Security.Database.Entities.Product = Nothing

			If _ClientPortalUserList IsNot Nothing AndAlso _ClientPortalUserList.Count > 0 Then

				Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					ClientContactDetailList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.ClientContactDetail)

					If _ClientPortalUserList.Count = 1 Then

						If _ClientPortalUserList(0).ClientContact.ClientContactDetails.ToList.Count > 0 Then

							For Each ClientContactDetail In _ClientPortalUserList(0).ClientContact.ClientContactDetails.ToList

								If ClientContactDetail.ProductCode Is Nothing Then

									Division = AdvantageFramework.Security.Database.Procedures.Division.LoadByClientAndDivisionCode(SecurityDbContext, _ClientPortalUserList(0).ClientContact.ClientCode, ClientContactDetail.DivisionCode)

									If Division IsNot Nothing Then

										ClientContactDetailList.Add(New AdvantageFramework.Security.Database.Classes.ClientContactDetail(Division))

									End If

								Else

									Product = AdvantageFramework.Security.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(SecurityDbContext, _ClientPortalUserList(0).ClientContact.ClientCode, ClientContactDetail.DivisionCode, ClientContactDetail.ProductCode)

									If Product IsNot Nothing Then

										ClientContactDetailList.Add(New AdvantageFramework.Security.Database.Classes.ClientContactDetail(Product))

									End If

								End If

							Next

						Else

							For Each Product In AdvantageFramework.Security.Database.Procedures.Product.LoaddByClientCode(SecurityDbContext, _ClientPortalUserList(0).ClientContact.ClientCode).ToList

								ClientContactDetailList.Add(New AdvantageFramework.Security.Database.Classes.ClientContactDetail(Product))

							Next

						End If

					End If

					If ClientContactDetailList IsNot Nothing Then

						SecurityDbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.CP_SEC_CLIENT WHERE [CDP_CONTACT_ID] = " & _ClientPortalUserList(0).ClientContact.ContactID)

						For Each ClientContactDetail In ClientContactDetailList

							SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE], [PRD_CODE])" &
																			  "VALUES({0}, '{1}', '{2}', '{3}')", _ClientPortalUserList(0).ClientContact.ContactID, ClientContactDetail.ClientCode, ClientContactDetail.DivisionCode, ClientContactDetail.ProductCode))

							'For Each Product In AdvantageFramework.Security.Database.Procedures.Product.LoadAllActive(DbContextSecurity).Where(Function(Prod) Prod.ClientCode = _ClientCode).ToList

							'    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE], [PRD_CODE])" & _
							'                                                    "VALUES({0}, '{1}', '{2}', '{3}')", _ClientContactID, Product.ClientCode, Product.DivisionCode, Product.Code))

							'Next

							'For Each Division In AdvantageFramework.Security.Database.Procedures.Division.LoadAllActive(DbContextSecurity).Where(Function(Div) Div.ClientCode = _ClientCode AndAlso Div.Products.Count = 0).ToList

							'    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE])" & _
							'                                                    "VALUES({0}, '{1}', '{2}')", _ClientContactID, Division.ClientCode, Division.Code))

							'Next
						Next

					End If


				End Using

			End If

			'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

			'    For Each ClientContactDetail In AdvantageFramework.Database.Procedures.ClientContactDetail.LoadByContactID(DbContext, _ClientContactID).ToList

			'        AdvantageFramework.Database.Procedures.ClientContactDetail.Delete(DbContext, ClientContactDetail)

			'    Next
			'    'DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.CP_SEC_CLIENT WHERE [CDP_CONTACT_ID] = " & _ClientContactID)
			'End Using

		End Sub
		Private Sub CheckBoxModuleAccess_IsBlocked_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_IsBlocked.CheckedChanged

			SaveClientPortalUserModuleAccess(Database.Entities.ClientPortalUserModuleAccess.Properties.IsBlocked, CheckBoxModuleAccess_IsBlocked.Checked)

		End Sub
		Private Sub ButtonItemView_ExpandAll_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemView_ExpandAll.Click

			AdvTreeModuleAccess_Modules.ExpandAll()

		End Sub
		Private Sub ButtonItemView_CollapseAll_Click(sender As Object, e As System.EventArgs) Handles ButtonItemView_CollapseAll.Click

			AdvTreeModuleAccess_Modules.CollapseAll()

		End Sub
		Private Sub TabControlRightSection_ClientPortalUserDetails_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlRightSection_ClientPortalUserDetails.SelectedTabChanging

			Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

			LoadClientPortalUserDetails(e.NewTab)

			If e.NewTab Is TabItemClientPortalUserDetails_ModuleAccessTab Then

				RibbonBarOptions_View.Visible = True

			Else

				RibbonBarOptions_View.Visible = False

			End If

			Me.FormAction = WinForm.Presentation.Methods.FormActions.None

		End Sub
		Private Sub CheckBoxModuleAccess_IsBlockedFromClientPortal_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxModuleAccess_IsBlockedFromClientPortal.CheckedChanged

			SaveClientPortalUserApplicationAccess()

			CheckBoxModuleAccess_IsBlocked.Enabled = Not CheckBoxModuleAccess_IsBlockedFromClientPortal.Checked
			AdvTreeModuleAccess_Modules.Enabled = Not CheckBoxModuleAccess_IsBlockedFromClientPortal.Checked

		End Sub
		Private Sub ButtonItemActions_ChangePassword_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_ChangePassword.Click

			'objects
			Dim ClientPortalUserID As System.Guid = Nothing

			If DataGridViewLeftSection_ClientPortalUsers.HasOnlyOneSelectedRow Then

				ClientPortalUserID = DataGridViewLeftSection_ClientPortalUsers.CurrentView.GetRowCellValue(DataGridViewLeftSection_ClientPortalUsers.CurrentView.FocusedRowHandle, AdvantageFramework.Security.Database.Entities.ClientPortalUser.Properties.ID.ToString)

				AdvantageFramework.Security.Setup.Presentation.ClientPortalUserChangePasswordDialog.ShowFormDialog(ClientPortalUserID)

			End If

		End Sub
		Private Sub TextBoxConceptShare_Password_TextChanged(sender As Object, e As EventArgs) Handles TextBoxConceptShare_Password.TextChanged

			EnableOrDisableConceptShareCreateUser()

		End Sub
		Private Sub ComboBoxConceptShare_ProjectRole_SelectedIndexChanged(sender As Object, e As EventArgs) 

			EnableOrDisableConceptShareCreateUser()

		End Sub
		Private Sub ComboBoxConceptShare_Role_SelectedIndexChanged(sender As Object, e As EventArgs) 

			EnableOrDisableConceptShareCreateUser()

		End Sub
		Private Sub ButtonConceptShare_CreateUser_Click(sender As Object, e As EventArgs) Handles ButtonConceptShare_CreateUser.Click

			'objects
			Dim ValidDataEntered As Boolean = True
			Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
			Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
			Dim UserName As String = ""

			If String.IsNullOrWhiteSpace(TextBoxForm_Name.Text) Then

				AdvantageFramework.WinForm.MessageBox.Show("Please enter a name.")
				TextBoxForm_Name.Focus()
				ValidDataEntered = False

			End If

			If ValidDataEntered Then

				If String.IsNullOrWhiteSpace(TextBoxForm_Email.Text) OrElse
						AdvantageFramework.StringUtilities.IsValidEmailAddress(TextBoxForm_Email.Text) = False Then

					AdvantageFramework.WinForm.MessageBox.Show("Please enter a valid email address.")
					TextBoxForm_Email.Focus()
					ValidDataEntered = False

				End If

			End If

			If ValidDataEntered Then

				Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

					If AdvantageFramework.ConceptShare.LoadSystemAccountUserNameAndPassword(DataContext, UserName, "") AndAlso
							TextBoxForm_Email.Text = UserName Then

						AdvantageFramework.WinForm.MessageBox.Show("Please enter an email address different from the system account email address.")
						ValidDataEntered = False

					End If

				End Using

			End If

			If ValidDataEntered Then

				If String.IsNullOrWhiteSpace(TextBoxConceptShare_Password.Text) Then

					AdvantageFramework.WinForm.MessageBox.Show("Please enter a password.")
					TextBoxConceptShare_Password.Focus()
					ValidDataEntered = False

				End If

			End If

			If ValidDataEntered Then

				Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Saving, "Saving...")

				ClientPortalUser = _ClientPortalUserList(0)

				Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

					APIReponse = AdvantageFramework.ConceptShare.CreateConceptShareUser(DataContext, New Security.Classes.ClientPortalUser(ClientPortalUser), ClientPortalUser.ClientContact.FirstName, ClientPortalUser.ClientContact.LastName,
																						TextBoxForm_Email.Text, TextBoxConceptShare_Password.Text, CheckBoxConceptShare_IsActive.Checked)

					If APIReponse.CompletedSuccessfully Then

						AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user created!")

						ButtonConceptShare_CreateUser.Enabled = False
						ButtonConceptShare_UpdateUser.Enabled = True
						ButtonConceptShare_RemoveUser.Enabled = True

					Else

						AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

					End If

					LoadClientPortalUserDetails(Nothing)

				End Using

				Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

			End If

		End Sub
		Private Sub ButtonConceptShare_UpdateUser_Click(sender As Object, e As EventArgs) Handles ButtonConceptShare_UpdateUser.Click

			'objects
			Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
			Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing

			Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Saving, "Saving...")

			ClientPortalUser = _ClientPortalUserList(0)

			If ClientPortalUser IsNot Nothing Then

				Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

						APIReponse = AdvantageFramework.ConceptShare.UpdateConceptShareUser(DataContext, SecurityDbContext, New AdvantageFramework.Security.Classes.ClientPortalUser(ClientPortalUser), ClientPortalUser.ConceptShareUserID,
																							ClientPortalUser.ClientContact.FirstName, ClientPortalUser.ClientContact.LastName,
																							TextBoxForm_Email.Text, TextBoxConceptShare_Password.Text, CheckBoxConceptShare_IsActive.Checked)

						If APIReponse.CompletedSuccessfully Then

							AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user updated!")

						Else

							AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

						End If

						LoadClientPortalUserDetails(Nothing)

					End Using

				End Using

			End If

			Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

		End Sub
		Private Sub ButtonConceptShare_RemoveUser_Click(sender As Object, e As EventArgs) Handles ButtonConceptShare_RemoveUser.Click

			'objects
			Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
			Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing

			Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Saving, "Saving...")

			ClientPortalUser = _ClientPortalUserList(0)

			If ClientPortalUser IsNot Nothing Then

				Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

					APIReponse = AdvantageFramework.ConceptShare.RemoveConceptShareUser(DataContext, New Security.Classes.ClientPortalUser(ClientPortalUser))

					If APIReponse.CompletedSuccessfully Then

						AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user removed!")

						ButtonConceptShare_CreateUser.Enabled = False
						ButtonConceptShare_UpdateUser.Enabled = False
						ButtonConceptShare_RemoveUser.Enabled = False

						TextBoxConceptShare_Password.Text = ""
						CheckBoxConceptShare_IsActive.Checked = True

						EnableOrDisableConceptShareCreateUser()

					Else

						AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

					End If

					LoadClientPortalUserDetails(Nothing)

				End Using

			End If

			Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

		End Sub
		Private Sub CheckBoxConceptShare_IsActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxConceptShare_IsActive.CheckedChanged

			'objects
			Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
			Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

				Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Saving, "Saving...")

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					ClientPortalUser = _ClientPortalUserList(0)

					If ClientPortalUser IsNot Nothing AndAlso ClientPortalUser.ConceptShareUserID.GetValueOrDefault(0) > 0 Then

						Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

							APIReponse = AdvantageFramework.ConceptShare.UpdateConceptShareUser(DataContext, ClientPortalUser.ConceptShareUserID, CheckBoxConceptShare_IsActive.Checked)

							If APIReponse IsNot Nothing AndAlso APIReponse.CompletedSuccessfully = False Then

								AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

							End If

						End Using

					End If

				End Using

				Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

			End If

		End Sub
		Private Sub CheckBoxConceptShare_ShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxConceptShare_ShowPassword.CheckedChanged

			TextBoxConceptShare_Password.UseSystemPasswordChar = (CheckBoxConceptShare_ShowPassword.Checked = False)

		End Sub

#End Region

#End Region

	End Class

End Namespace
