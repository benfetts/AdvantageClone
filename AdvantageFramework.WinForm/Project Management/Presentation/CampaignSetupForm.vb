Namespace ProjectManagement.Presentation

    Public Class CampaignSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim ClientCodes() As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_Campaigns.DataSource = AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, Me.Session.UserCode).OrderBy(Function(Entity) Entity.CampaignCode)
                    DataGridViewLeftSection_Campaigns.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                CampaignControlRightSection_Campaign.ClearControl()

                CampaignControlRightSection_Campaign.Enabled = DataGridViewLeftSection_Campaigns.HasOnlyOneSelectedRow

                If CampaignControlRightSection_Campaign.Enabled Then

                    CampaignControlRightSection_Campaign.Enabled = CampaignControlRightSection_Campaign.LoadControl(DataGridViewLeftSection_Campaigns.GetFirstSelectedRowBookmarkValue)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            CampaignControlRightSection_Campaign.Enabled = (DataGridViewLeftSection_Campaigns.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_Campaigns.HasOnlyOneSelectedRow AndAlso CampaignControlRightSection_Campaign.Enabled)
            ButtonItemActions_ChangeCode.Enabled = (DataGridViewLeftSection_Campaigns.HasOnlyOneSelectedRow AndAlso CampaignControlRightSection_Campaign.Enabled)

            RibbonBarOptions_Documents.Visible = If(CampaignControlRightSection_Campaign.SelectedTab Is CampaignControlRightSection_Campaign.TabItemCampaignDetails_DocumentsTab, True, False)
            RibbonBarOptions_CampaignDetails.Visible = If(CampaignControlRightSection_Campaign.SelectedTab Is CampaignControlRightSection_Campaign.TabItemCampaignDetails_CampaignDetailsTab, True, False)
            RibbonBarOptions_Budget.Visible = If(CampaignControlRightSection_Campaign.SelectedTab Is CampaignControlRightSection_Campaign.TabItemCampaignDetails_CampaignDetailsTab, True, False)

            If CampaignControlRightSection_Campaign.Enabled Then

                If CampaignControlRightSection_Campaign.SelectedTab Is CampaignControlRightSection_Campaign.TabItemCampaignDetails_GeneralTab Then

                    RibbonBarOptions_CheckSpelling.Visible = True

                Else

                    RibbonBarOptions_CheckSpelling.Visible = False

                End If

            Else

                RibbonBarOptions_CheckSpelling.Visible = False

            End If

            ButtonItemCampaignDetails_Cancel.Enabled = CampaignControlRightSection_Campaign.CampaignDetailsIsNewItemRow
            ButtonItemCampaignDetails_Delete.Enabled = CampaignControlRightSection_Campaign.CampaignDetailsHasASelectedRow

            If RibbonBarOptions_Documents.Visible Then

                ButtonItemDocuments_Delete.Enabled = CampaignControlRightSection_Campaign.DocumentManager.HasOnlyOneSelectedDocument
                ButtonItemDocuments_Download.Enabled = If(CampaignControlRightSection_Campaign.DocumentManager.HasOnlyOneSelectedDocument, Not CampaignControlRightSection_Campaign.DocumentManager.IsSelectedDocumentAURL, CampaignControlRightSection_Campaign.DocumentManager.HasASelectedDocument)
                ButtonItemDocuments_OpenURL.Enabled = If(CampaignControlRightSection_Campaign.DocumentManager.HasOnlyOneSelectedDocument, CampaignControlRightSection_Campaign.DocumentManager.IsSelectedDocumentAURL, False)

            Else

                ButtonItemDocuments_Delete.Enabled = False
                ButtonItemDocuments_Download.Enabled = False
                ButtonItemDocuments_OpenURL.Enabled = False

            End If

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    CampaignControlRightSection_Campaign.LoadRequiredNonGridControlsForValidation()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = CampaignControlRightSection_Campaign.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_Campaigns.HasOnlyOneSelectedRow Then

                CampaignControlRightSection_Campaign.LoadRequiredNonGridControlsForValidation()

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If CampaignControlRightSection_Campaign.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        Saved = True

                        DataGridViewLeftSection_Campaigns.FocusToFindPanel(False)

                        DataGridViewLeftSection_Campaigns.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a campaign to save.")

            End If

            Save = Saved

        End Function
        Private Sub CheckSecuritySettings()

            'objects
            Dim CanUserAddInModule As Boolean = False
            Dim CanUserUpdateInModule As Boolean = False

            CanUserUpdateInModule = AdvantageFramework.Security.CanUserUpdateInModule(Me.Session, AdvantageFramework.Security.Modules.ProjectManagement_Campaigns)
            CanUserAddInModule = AdvantageFramework.Security.CanUserAddInModule(Me.Session, AdvantageFramework.Security.Modules.ProjectManagement_Campaigns)

            ButtonItemActions_Add.SecurityEnabled = CanUserAddInModule

            ButtonItemActions_Save.SecurityEnabled = CanUserUpdateInModule
            ButtonItemActions_Delete.SecurityEnabled = CanUserUpdateInModule
            ButtonItemActions_ChangeCode.SecurityEnabled = CanUserUpdateInModule
            ButtonItemCampaignDetails_Delete.SecurityEnabled = CanUserUpdateInModule
            ButtonItemCampaignDetails_Cancel.SecurityEnabled = CanUserUpdateInModule
            ButtonItemBudget_Create.SecurityEnabled = CanUserUpdateInModule
            ButtonItemBudget_ReAllocate.SecurityEnabled = CanUserUpdateInModule

            RibbonBarOptions_Documents.Enabled = CanUserUpdateInModule

            ButtonItemDocuments_Upload.SecurityEnabled = CampaignControlRightSection_Campaign.DocumentManager.CanUpload

            CampaignControlRightSection_Campaign.CanUserUpdate = CanUserUpdateInModule

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CampaignSetupForm As AdvantageFramework.ProjectManagement.Presentation.CampaignSetupForm = Nothing

            CampaignSetupForm = New AdvantageFramework.ProjectManagement.Presentation.CampaignSetupForm()

            CampaignSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CampaignSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_ChangeCode.Image = AdvantageFramework.My.Resources.ChangeCodeImage
            ButtonItemCampaignDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemCampaignDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemBudget_Create.Image = AdvantageFramework.My.Resources.ClientBudgetImage
            ButtonItemBudget_ReAllocate.Image = AdvantageFramework.My.Resources.ReAllocateBudgetImage
            ButtonItemDocuments_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
			ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
			ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

			ButtonItemSpelling_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            DataGridViewLeftSection_Campaigns.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

					ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
					ButtonItemDocuments_Upload.SplitButton = False

				End If

			End Using

			Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Campaigns.CurrentView.AFActiveFilterString = "[IsClosed] = False"

            Catch ex As Exception

            End Try

            Try

                CheckSecuritySettings()

            Catch ex As Exception

            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemDocuments_OpenURL.SecurityEnabled = Not AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub CampaignSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CampaignSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CampaignSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Campaigns.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Campaigns_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Campaigns.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Campaigns_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Campaigns.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_ChangeCode_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ChangeCode.Click

            'objects
            Dim CampaignID As Integer = 0

            If DataGridViewLeftSection_Campaigns.HasOnlyOneSelectedRow AndAlso CampaignControlRightSection_Campaign.Enabled Then

                If CampaignControlRightSection_Campaign.ChangeCampaignCode() Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

                    Try

                        CampaignID = DataGridViewLeftSection_Campaigns.GetFirstSelectedRowBookmarkValue

                    Catch ex As Exception
                        CampaignID = 0
                    End Try

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    If CampaignID > 0 Then

                        DataGridViewLeftSection_Campaigns.SelectRow(CampaignID)

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_Campaigns.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Deleting...")

                    Try

                        Deleted = CampaignControlRightSection_Campaign.Delete()

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                    If Deleted Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm("Loading...")

                        Try

                            LoadGrid()

                            LoadSelectedItemDetails()

                        Catch ex As Exception

                        End Try

                    End If

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    If Deleted = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a campaign to delete.")

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim CampaignID As Integer = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Campaigns.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.ProjectManagement.Presentation.CampaignEditDialog.ShowFormDialog(CampaignID) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_Campaigns.SelectRow(CampaignID)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Campaigns.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemBudget_Create_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemBudget_Create.Click

            If DataGridViewLeftSection_Campaigns.HasOnlyOneSelectedRow Then

                CampaignControlRightSection_Campaign.CreateBudget()

            End If

        End Sub
        Private Sub ButtonItemBudget_ReAllocate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemBudget_ReAllocate.Click

            If DataGridViewLeftSection_Campaigns.HasOnlyOneSelectedRow Then

                CampaignControlRightSection_Campaign.ReAllocateBudget()

            End If

        End Sub
        Private Sub ButtonItemCampaignDetails_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemCampaignDetails_Cancel.Click

            CampaignControlRightSection_Campaign.CancelNewCampaignDetail()

        End Sub
        Private Sub ButtonItemCampaignDetails_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemCampaignDetails_Delete.Click

            CampaignControlRightSection_Campaign.DeleteCampaignDetail()

        End Sub
        Private Sub CampaignControlRightSection_Campaign_CampaignDetailsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CampaignControlRightSection_Campaign.CampaignDetailsInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub CampaignControlRightSection_Campaign_CampaignDetailsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles CampaignControlRightSection_Campaign.CampaignDetailsSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub CampaignControlRightSection_Campaign_SelectedDocumentChanged() Handles CampaignControlRightSection_Campaign.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub CampaignControlRightSection_Campaign_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles CampaignControlRightSection_Campaign.SelectedTabChanging

            EnableOrDisableActions()

        End Sub
		Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

			CampaignControlRightSection_Campaign.DocumentManager.UploadNewDocument()

			EnableOrDisableActions()

		End Sub
		Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

			CampaignControlRightSection_Campaign.DocumentManager.SendASPUploadEmail()

		End Sub
		Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            CampaignControlRightSection_Campaign.DocumentManager.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            CampaignControlRightSection_Campaign.DocumentManager.DownloadSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDocuments_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Delete.Click

            CampaignControlRightSection_Campaign.DocumentManager.DeleteSelectedDocument()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSpelling_CheckSpelling_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSpelling_CheckSpelling.Click

            CampaignControlRightSection_Campaign.SpellCheckSelectedTab()

        End Sub

#End Region

#End Region

    End Class

End Namespace