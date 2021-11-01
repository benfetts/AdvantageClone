Namespace Maintenance.ProjectManagement.Presentation

    Public Class JobVersionTemplateSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobVersionTemplates As Generic.List(Of AdvantageFramework.Database.Entities.JobVersionTemplate) = Nothing
        Private _JobVersionTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail) = Nothing
        Private _GridViewJobVersionTemplateDetails As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing

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

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_JobVersionTemplates.DataSource = AdvantageFramework.Database.Procedures.JobVersionTemplate.Load(DbContext)

            End Using

            DataGridViewLeftSection_JobVersionTemplates.CurrentView.BestFitColumns()

        End Sub
        Private Sub ExpandAndPrintExportDataGridView()

            For RowHandle = 0 To DataGridViewLeftSection_JobVersionTemplateExport.CurrentView.RowCount - 1

                If DataGridViewLeftSection_JobVersionTemplateExport.CurrentView.GetRowExpanded(RowHandle) = False Then

                    Try

                        DataGridViewLeftSection_JobVersionTemplateExport.CurrentView.ExpandMasterRow(RowHandle, 0)

                    Catch ex As Exception

                    End Try

                End If

            Next

            DataGridViewLeftSection_JobVersionTemplateExport.CurrentView.BestFitColumns()

            DataGridViewLeftSection_JobVersionTemplateExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                JobVersionTemplateControlRightSection_JobVersionTemplate.ClearControl()

                JobVersionTemplateControlRightSection_JobVersionTemplate.Enabled = DataGridViewLeftSection_JobVersionTemplates.HasOnlyOneSelectedRow

                If JobVersionTemplateControlRightSection_JobVersionTemplate.Enabled Then

                    JobVersionTemplateControlRightSection_JobVersionTemplate.Enabled = JobVersionTemplateControlRightSection_JobVersionTemplate.LoadControl(DataGridViewLeftSection_JobVersionTemplates.GetFirstSelectedRowBookmarkValue, False)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            JobVersionTemplateControlRightSection_JobVersionTemplate.Enabled = (DataGridViewLeftSection_JobVersionTemplates.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            ButtonItemActions_Export.Enabled = DataGridViewLeftSection_JobVersionTemplates.HasRows

            If JobVersionTemplateControlRightSection_JobVersionTemplate.Enabled Then

                ButtonItemActions_Delete.Enabled = True
                ButtonItemDetails_Cancel.Enabled = JobVersionTemplateControlRightSection_JobVersionTemplate.IsNewItemRowFocused
                ButtonItemDetails_Delete.Enabled = JobVersionTemplateControlRightSection_JobVersionTemplate.HasOnlyOneSelectedDetail
                ButtonItemDetails_MoveDown.Enabled = JobVersionTemplateControlRightSection_JobVersionTemplate.CanMoveSelectedDetailDown
                ButtonItemDetails_MoveUp.Enabled = JobVersionTemplateControlRightSection_JobVersionTemplate.CanMoveSelectedDetailUp
                RibbonBarOptions_ListValues.Visible = JobVersionTemplateControlRightSection_JobVersionTemplate.IsDetailListRow(Nothing)
                ButtonItemActions_Copy.Enabled = True
                ButtonItemExport_CurrentView.Enabled = True
                ButtonItemActions_Sync.Enabled = True

            Else

                ButtonItemActions_Delete.Enabled = False
                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = False
                ButtonItemDetails_MoveDown.Enabled = False
                ButtonItemDetails_MoveUp.Enabled = False
                RibbonBarOptions_ListValues.Visible = False
                ButtonItemActions_Copy.Enabled = False
                ButtonItemExport_CurrentView.Enabled = False
                ButtonItemActions_Sync.Enabled = False

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = JobVersionTemplateControlRightSection_JobVersionTemplate.Save()

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

            If DataGridViewLeftSection_JobVersionTemplates.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If JobVersionTemplateControlRightSection_JobVersionTemplate.Save() Then

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

                        DataGridViewLeftSection_JobVersionTemplates.FocusToFindPanel(False)

                        DataGridViewLeftSection_JobVersionTemplates.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a job version template to save.")

            End If

            Save = Saved

        End Function
        Private Sub LoadDetailView()

            DataGridViewLeftSection_JobVersionTemplateExport.CurrentView.BeginUpdate()

            _GridViewJobVersionTemplateDetails = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            DataGridViewLeftSection_JobVersionTemplateExport.GridControl.LevelTree.Nodes.Add("Job Version Template Details", _GridViewJobVersionTemplateDetails)

            _GridViewJobVersionTemplateDetails.GridControl = DataGridViewLeftSection_JobVersionTemplateExport.GridControl
            _GridViewJobVersionTemplateDetails.Name = "_GridViewJobVersionTemplateDetails"

            _GridViewJobVersionTemplateDetails.Session = Me.Session

            _GridViewJobVersionTemplateDetails.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

            _GridViewJobVersionTemplateDetails.ObjectType = GetType(AdvantageFramework.Database.Entities.JobVersionTemplateDetail)

            _GridViewJobVersionTemplateDetails.OptionsView.ShowViewCaption = False
            _GridViewJobVersionTemplateDetails.OptionsView.ShowFooter = False

            _GridViewJobVersionTemplateDetails.ViewCaption = "Job Version Template Details"

            _GridViewJobVersionTemplateDetails.CreateColumnsBasedOnObjectType()

            _GridViewJobVersionTemplateDetails.BestFitColumns()

            DataGridViewLeftSection_JobVersionTemplateExport.CurrentView.EndUpdate()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim JobVersionTemplateSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionTemplateSetupForm = Nothing

            JobVersionTemplateSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionTemplateSetupForm

            JobVersionTemplateSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub JobVersionTemplateSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_MoveDown.Image = AdvantageFramework.My.Resources.DownImage
            ButtonItemDetails_MoveUp.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemListValues_Edit.Image = AdvantageFramework.My.Resources.JobComponentAddImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Sync.Image = AdvantageFramework.My.Resources.RefreshImage

            DataGridViewLeftSection_JobVersionTemplates.MultiSelect = False
            DataGridViewLeftSection_JobVersionTemplateExport.OptionsPrint.PrintDetails = True
            DataGridViewLeftSection_JobVersionTemplateExport.OptionsPrint.ExpandAllDetails = True
            DataGridViewLeftSection_JobVersionTemplateExport.Visible = False

            Try

                LoadDetailView()

            Catch ex As Exception

            End Try

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_JobVersionTemplates.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub JobVersionTemplateSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub JobVersionTemplateSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub JobVersionTemplateSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_JobVersionTemplates.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_JobVersionTemplates_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_JobVersionTemplates.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JobVersionTemplates_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_JobVersionTemplates.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim JobVersionTemplateCode As String = Nothing
            Dim CanAdd As Boolean = True

            If DataGridViewLeftSection_JobVersionTemplates.HasOnlyOneSelectedRow Then

                CanAdd = CheckForUnsavedChanges()

            End If

            If CanAdd Then

                If AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionTemplateEditDialog.ShowFormDialog(JobVersionTemplateCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_JobVersionTemplates.SelectRow(JobVersionTemplateCode)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_JobVersionTemplates.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim JobVersionTemplateCode As String = Nothing
            Dim ContinueCopy As Boolean = True

            If DataGridViewLeftSection_JobVersionTemplates.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges()

                If ContinueCopy Then

                    JobVersionTemplateCode = DataGridViewLeftSection_JobVersionTemplates.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionTemplateEditDialog.ShowFormDialog(JobVersionTemplateCode, True) = System.Windows.Forms.DialogResult.OK Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            LoadGrid()

                            DataGridViewLeftSection_JobVersionTemplates.SelectRow(JobVersionTemplateCode)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        DataGridViewLeftSection_JobVersionTemplates.CurrentView.GridViewSelectionChanged()

                    Else

                        LoadSelectedItemDetails()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_JobVersionTemplates.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Deleting
                    Me.ShowWaitForm("Deleting...")

                    Try

                        If JobVersionTemplateControlRightSection_JobVersionTemplate.Delete() Then

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    DataGridViewLeftSection_JobVersionTemplates.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a job version template to delete.")

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            JobVersionTemplateControlRightSection_JobVersionTemplate.CancelAddNewDetail()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            JobVersionTemplateControlRightSection_JobVersionTemplate.DeleteSelectedDetail()

        End Sub
        Private Sub JobVersionTemplateControlRightSection_JobVersionTemplate_SelectedDetailChangedEvent() Handles JobVersionTemplateControlRightSection_JobVersionTemplate.SelectedDetailChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemDetails_MoveUp_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemDetails_MoveUp.Click

            JobVersionTemplateControlRightSection_JobVersionTemplate.MoveSelectedDetail(True)

        End Sub
        Private Sub ButtonItemDetails_MoveDown_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemDetails_MoveDown.Click

            JobVersionTemplateControlRightSection_JobVersionTemplate.MoveSelectedDetail(False)

        End Sub
        Private Sub ButtonItemListValues_Edit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemListValues_Edit.Click

            JobVersionTemplateControlRightSection_JobVersionTemplate.EditDetailListValues()

        End Sub
        Private Sub JobVersionTemplateControlRightSection_JobVersionTemplate_InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean) Handles JobVersionTemplateControlRightSection_JobVersionTemplate.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JobVersionTemplateExport_MasterRowEmptyEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewLeftSection_JobVersionTemplateExport.MasterRowEmptyEvent

            e.IsEmpty = False

        End Sub
        Private Sub DataGridViewLeftSection_JobVersionTemplateExport_MasterRowGetChildListEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewLeftSection_JobVersionTemplateExport.MasterRowGetChildListEvent

            'objects
            Dim JobVersionTemplateCode As String = Nothing

            If e.ChildList Is Nothing Then

                Try

                    JobVersionTemplateCode = DataGridViewLeftSection_JobVersionTemplateExport.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.JobVersionTemplate.Properties.Code.ToString)

                Catch ex As Exception
                    JobVersionTemplateCode = Nothing
                End Try

                If String.IsNullOrEmpty(JobVersionTemplateCode) = False Then

                    If e.RelationIndex = 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            e.ChildList = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateCode(DbContext, JobVersionTemplateCode).ToList

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JobVersionTemplateExport_MasterRowGetLevelDefaultViewEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles DataGridViewLeftSection_JobVersionTemplateExport.MasterRowGetLevelDefaultViewEvent

            e.DefaultView = _GridViewJobVersionTemplateDetails

        End Sub
        Private Sub DataGridViewLeftSection_JobVersionTemplateExport_MasterRowGetRelationCountEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewLeftSection_JobVersionTemplateExport.MasterRowGetRelationCountEvent

            e.RelationCount = 1

        End Sub
        Private Sub DataGridViewLeftSection_JobVersionTemplateExport_MasterRowGetRelationNameEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewLeftSection_JobVersionTemplateExport.MasterRowGetRelationNameEvent

            If e.RelationIndex = 0 Then

                e.RelationName = "Job Version Template Details"

            End If

        End Sub
        Private Sub ButtonItemExport_All_Click(sender As Object, e As EventArgs) Handles ButtonItemExport_All.Click

            'objects
            Dim CodeList As Generic.List(Of String) = Nothing

            CodeList = DataGridViewLeftSection_JobVersionTemplates.GetAllRowsBookmarkValues.OfType(Of String).ToList

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_JobVersionTemplateExport.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobVersionTemplate.Load(DbContext)
                                                                               Where CodeList.Contains(Entity.Code)
                                                                               Select Entity).ToList

            End Using

            ExpandAndPrintExportDataGridView()

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(sender As Object, e As EventArgs) Handles ButtonItemExport_CurrentView.Click

            'objects
            Dim JobVersionTemplateCode As String = Nothing

            If DataGridViewLeftSection_JobVersionTemplates.HasOnlyOneSelectedRow Then

                JobVersionTemplateCode = DataGridViewLeftSection_JobVersionTemplates.GetFirstSelectedRowBookmarkValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_JobVersionTemplateExport.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobVersionTemplate.Load(DbContext)
                                                                                   Where Entity.Code = JobVersionTemplateCode
                                                                                   Select Entity).ToList

                End Using

                ExpandAndPrintExportDataGridView()

            End If

        End Sub
        Private Sub ButtonItemActions_Sync_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Sync.Click

            'objects
            Dim JobVersionTemplateCode As String = ""
            Dim JobVersionIDs() As Integer = Nothing

            If DataGridViewLeftSection_JobVersionTemplates.HasASelectedRow Then

                JobVersionTemplateCode = DataGridViewLeftSection_JobVersionTemplates.GetFirstSelectedRowBookmarkValue

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to sync all job/comp versions with this template?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing
                    Me.ShowWaitForm("Syncing...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            AdvantageFramework.Database.Procedures.JobVersionTemplate.Sync(DbContext, JobVersionTemplateCode)

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    AdvantageFramework.WinForm.MessageBox.Show("Job version template sync complete.")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a job version template to sync.")

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace