Namespace Maintenance.ProjectManagement.Presentation

    Public Class ResourceSetupForm

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

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_Resources.DataSource = AdvantageFramework.Database.Procedures.Resource.Load(DbContext).ToList

            End Using

            DataGridViewLeftSection_Resources.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            ResourceControlRightSection_Resource.ClearControl()

            ResourceControlRightSection_Resource.Enabled = DataGridViewLeftSection_Resources.HasOnlyOneSelectedRow

            If ResourceControlRightSection_Resource.Enabled Then

                ResourceControlRightSection_Resource.Enabled = ResourceControlRightSection_Resource.LoadControl(DataGridViewLeftSection_Resources.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            ResourceControlRightSection_Resource.Enabled = (DataGridViewLeftSection_Resources.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_Resources.HasOnlyOneSelectedRow AndAlso ResourceControlRightSection_Resource.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemDetails_Cancel.Enabled = (ResourceControlRightSection_Resource.Enabled AndAlso ResourceControlRightSection_Resource.ResourceTasksIsNewItemRow(ResourceControlRightSection_Resource.ResourceTasksFocusedRowHandle))

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = (ResourceControlRightSection_Resource.Save())

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

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ResourceSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.ResourceSetupForm = Nothing

            ResourceSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.ResourceSetupForm

            ResourceSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ResourceSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            DataGridViewLeftSection_Resources.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Resources.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ResourceSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ResourceSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ResourceSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Resources.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Resources_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Resources.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Resources_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Resources.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_Resources.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If ResourceControlRightSection_Resource.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_Resources.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a Resource to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ResourceCode As String = Nothing
            Dim CanAdd As Boolean = True

            If DataGridViewLeftSection_Resources.HasOnlyOneSelectedRow Then

                CanAdd = CheckForUnsavedChanges()

            End If

            If CanAdd Then

                If AdvantageFramework.Maintenance.ProjectManagement.Presentation.ResourceEditDialog.ShowFormDialog(ResourceCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Resources.SelectRow(ResourceCode)

                Else

                    LoadSelectedItemDetails()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_Resources.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If ResourceControlRightSection_Resource.Delete() Then

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a Resource to delete.")

            End If

        End Sub
        Private Sub ResourceControlRightSection_Resource_ResourceInActiveChanged() Handles ResourceControlRightSection_Resource.ResourceInActiveChanged

            LoadGrid()

            LoadSelectedItemDetails()

        End Sub
        Private Sub ResourceControlRightSection_Resource_ResourceTasksInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ResourceControlRightSection_Resource.ResourceTasksInitNewRowEvent

            ButtonItemDetails_Cancel.Enabled = True
            ButtonItemDetails_Delete.Enabled = False

        End Sub
        Private Sub ResourceControlRightSection_Resource_ResourceTasksSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ResourceControlRightSection_Resource.ResourceTasksSelectionChangedEvent

            If ResourceControlRightSection_Resource.ResourceTasksHasOnlyOneSelectedRow(False) Then

                If ResourceControlRightSection_Resource.ResourceTasksIsNewItemRow(ResourceControlRightSection_Resource.ResourceTasksFocusedRowHandle) Then

                    ButtonItemDetails_Cancel.Enabled = True
                    ButtonItemDetails_Delete.Enabled = False

                Else

                    ButtonItemDetails_Cancel.Enabled = False
                    ButtonItemDetails_Delete.Enabled = True

                End If

            Else

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = ResourceControlRightSection_Resource.ResourceTasksHasRows

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            ResourceControlRightSection_Resource.ResourceTasksCancelNewItemRow()

            If ResourceControlRightSection_Resource.ResourceTasksHasOnlyOneSelectedRow() = True Then

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = ResourceControlRightSection_Resource.ResourceTasksHasRows

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            ResourceControlRightSection_Resource.DeleteResourceTasks()

        End Sub
        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            'objects
            Dim CodesList As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                CodesList = DataGridViewLeftSection_Resources.GetAllRowsBookmarkValues.OfType(Of String).ToList

                DataGridViewLeftSection_ExportResources.CurrentView.ObjectType = GetType(AdvantageFramework.Database.Entities.ResourceTask)

                If DataGridViewLeftSection_ExportResources.Columns.Count = 0 Then

                    DataGridViewLeftSection_ExportResources.CurrentView.CreateColumnsBasedOnObjectType()

                End If

                DataGridViewLeftSection_ExportResources.ItemDescription = "Resource(s)"

                DataGridViewLeftSection_ExportResources.DataSource = AdvantageFramework.Database.Procedures.ResourceTask.Load(DbContext).Include("Resource").Include("Resource.ResourceType").ToList.Where(Function(Entity) CodesList.Contains(Entity.ResourceCode) = True).Select(Function(Entity) New AdvantageFramework.Database.Classes.ResourceTask(Entity)).ToList

                If DataGridViewLeftSection_ExportResources.Columns(AdvantageFramework.Database.Classes.ResourceTask.Properties.Resource.ToString) IsNot Nothing Then

                    DataGridViewLeftSection_ExportResources.Columns(AdvantageFramework.Database.Classes.ResourceTask.Properties.Resource.ToString).Visible = True

                    DataGridViewLeftSection_ExportResources.Columns(AdvantageFramework.Database.Classes.ResourceTask.Properties.Resource.ToString).Group()

                End If

                DataGridViewLeftSection_ExportResources.CurrentView.BestFitColumns()

                DataGridViewLeftSection_ExportResources.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End Using

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            Dim ResourceCode As String = Nothing

            If DataGridViewLeftSection_Resources.HasASelectedRow Then

                ResourceCode = DataGridViewLeftSection_Resources.GetFirstSelectedRowBookmarkValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_ExportResources.CurrentView.ObjectType = GetType(AdvantageFramework.Database.Entities.ResourceTask)

                    If DataGridViewLeftSection_ExportResources.Columns.Count = 0 Then

                        DataGridViewLeftSection_ExportResources.CurrentView.CreateColumnsBasedOnObjectType()

                    End If

                    DataGridViewLeftSection_ExportResources.ItemDescription = "Resource(s)"

                    DataGridViewLeftSection_ExportResources.DataSource = AdvantageFramework.Database.Procedures.ResourceTask.Load(DbContext).Include("Resource").Include("Resource.ResourceType").Where(Function(Entity) Entity.ResourceCode = ResourceCode).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.ResourceTask(Entity)).ToList

                    If DataGridViewLeftSection_ExportResources.Columns(AdvantageFramework.Database.Classes.ResourceTask.Properties.Resource.ToString) IsNot Nothing Then

                        DataGridViewLeftSection_ExportResources.Columns(AdvantageFramework.Database.Classes.ResourceTask.Properties.Resource.ToString).Visible = True

                        DataGridViewLeftSection_ExportResources.Columns(AdvantageFramework.Database.Classes.ResourceTask.Properties.Resource.ToString).Group()

                    End If

                    DataGridViewLeftSection_ExportResources.CurrentView.BestFitColumns()

                    DataGridViewLeftSection_ExportResources.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

                End Using

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.Refreshing)

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Try

                    ResourceControlRightSection_Resource.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_Resources.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace