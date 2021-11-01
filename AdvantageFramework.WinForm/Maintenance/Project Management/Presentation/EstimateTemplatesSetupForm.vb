Namespace Maintenance.ProjectManagement.Presentation

    Public Class EstimateTemplatesSetupForm

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

                DataGridViewLeftSection_EstimateTemplate.DataSource = AdvantageFramework.Database.Procedures.EstimateTemplate.Load(DbContext).ToList

                DataGridViewLeftSection_EstimateTemplate.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                EstimateTemplateControlRightSection_EstimateTemplate.ClearControl()

                EstimateTemplateControlRightSection_EstimateTemplate.Enabled = DataGridViewLeftSection_EstimateTemplate.HasOnlyOneSelectedRow

                If EstimateTemplateControlRightSection_EstimateTemplate.Enabled Then

                    EstimateTemplateControlRightSection_EstimateTemplate.Enabled = EstimateTemplateControlRightSection_EstimateTemplate.LoadControl(DataGridViewLeftSection_EstimateTemplate.GetFirstSelectedRowBookmarkValue)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            EstimateTemplateControlRightSection_EstimateTemplate.Enabled = (DataGridViewLeftSection_EstimateTemplate.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If EstimateTemplateControlRightSection_EstimateTemplate.Enabled Then

                ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_EstimateTemplate.HasOnlyOneSelectedRow

                If EstimateTemplateControlRightSection_EstimateTemplate.DetailsTabSelected Then

                    RibbonBarOptions_Details.Visible = True
                    ButtonItemDetails_Copy.Enabled = DataGridViewLeftSection_EstimateTemplate.HasOnlyOneSelectedRow
                    ButtonItemDetails_Cancel.Enabled = EstimateTemplateControlRightSection_EstimateTemplate.EstimateTemplateDetailIsNewItemRow(EstimateTemplateControlRightSection_EstimateTemplate.EstimateTemplateDetailFocusedRowHandle)
                    ButtonItemDetails_Delete.Enabled = EstimateTemplateControlRightSection_EstimateTemplate.EstimateTemplateDetailHasRows
                    RibbonBarOptions_Text.Visible = False

                ElseIf EstimateTemplateControlRightSection_EstimateTemplate.DefaultCommentsTabSelected Then

                    RibbonBarOptions_Details.Visible = False
                    ButtonItemDetails_Copy.Enabled = False
                    ButtonItemDetails_Cancel.Enabled = False
                    ButtonItemDetails_Delete.Enabled = False
                    RibbonBarOptions_Text.Visible = True

                End If

            Else

                ButtonItemActions_Save.Enabled = False
                ButtonItemDetails_Copy.Enabled = False
                ButtonItemActions_Delete.Enabled = False
                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = False

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = EstimateTemplateControlRightSection_EstimateTemplate.Save()

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

            If DataGridViewLeftSection_EstimateTemplate.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If EstimateTemplateControlRightSection_EstimateTemplate.Save() Then

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

                        DataGridViewLeftSection_EstimateTemplate.FocusToFindPanel(False)

                        DataGridViewLeftSection_EstimateTemplate.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an estimate template to save.")

            End If

            Save = Saved

        End Function
        'Private Function Save(ByVal Reload As Boolean)

        '    'objects
        '    Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing
        '    Dim EstimateTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.EstimateTemplateDetail) = Nothing
        '    Dim EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail = Nothing
        '    Dim ErrorMessage As String = Nothing

        '    If DataGridViewLeftSection_EstimateTemplate.HasOnlyOneSelectedRow Then

        '        If Me.Validator Then

        '            Me.ShowWaitForm("Processing...") 



        '            Me.CloseWaitForm()

        '        Else

        '            For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

        '                ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

        '            Next

        '        End If

        '    Else

        '        ErrorMessage = "Please select a valid estimate template."

        '    End If

        '    If ErrorMessage <> "" Then

        '        Throw New System.Exception(ErrorMessage)

        '    End If

        'End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EstimateTemplatesSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.EstimateTemplatesSetupForm = Nothing

            EstimateTemplatesSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.EstimateTemplatesSetupForm()

            EstimateTemplatesSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EstimateTemplatesSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemDetails_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemText_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            DataGridViewLeftSection_EstimateTemplate.MultiSelect = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_EstimateTemplate.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            DataGridViewLeftSection_EstimateTemplateExport.Enabled = False
            DataGridViewLeftSection_EstimateTemplateExport.Visible = False

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub EstimateTemplatesSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EstimateTemplatesSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EstimateTemplatesSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_EstimateTemplate.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub EstimateTemplateControlRightSection_EstimateTemplate_EstimateTemplateDetailInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EstimateTemplateControlRightSection_EstimateTemplate.EstimateTemplateDetailInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub EstimateTemplateControlRightSection_EstimateTemplate_EstimateTemplateDetailSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles EstimateTemplateControlRightSection_EstimateTemplate.EstimateTemplateDetailSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewLeftSection_EstimateTemplate_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_EstimateTemplate.LeavingRowEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_EstimateTemplate_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_EstimateTemplate.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim EstimateTemplateCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_EstimateTemplate.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.ProjectManagement.Presentation.EstimateTemplateEditDialog.ShowFormDialog(EstimateTemplateCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_EstimateTemplate.SelectRow(EstimateTemplateCode)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_EstimateTemplate.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_EstimateTemplate.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If EstimateTemplateControlRightSection_EstimateTemplate.Delete() Then

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_EstimateTemplate.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an estimate template to delete.")

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            EstimateTemplateControlRightSection_EstimateTemplate.DeleteEstimateTemplateDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Copy_Click(sender As Object, e As System.EventArgs) Handles ButtonItemDetails_Copy.Click

            EstimateTemplateControlRightSection_EstimateTemplate.CopyDetails()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            EstimateTemplateControlRightSection_EstimateTemplate.CancelNewItemRowEstimateTemplateDetail()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemExport_All_Click(sender As Object, e As System.EventArgs) Handles ButtonItemExport_All.Click

            'objects
            Dim CodesList As Generic.List(Of String) = Nothing

            CodesList = DataGridViewLeftSection_EstimateTemplate.GetAllRowsBookmarkValues.OfType(Of String).ToList

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_EstimateTemplateExport.DataSource = AdvantageFramework.Database.Procedures.EstimateTemplateDetail.Load(DataContext).ToList.Where(Function(Entity) CodesList.Contains(Entity.EstimateTemplateCode) = True).ToList()

            End Using

            DataGridViewLeftSection_EstimateTemplateExport.HideOrShowColumn("EstimateTemplateCode", True)
            DataGridViewLeftSection_EstimateTemplateExport.HideOrShowColumn("ID", False)

            DataGridViewLeftSection_EstimateTemplateExport.CurrentView.BestFitColumns()

            DataGridViewLeftSection_EstimateTemplateExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(sender As Object, e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_EstimateTemplateExport.DataSource = AdvantageFramework.Database.Procedures.EstimateTemplateDetail.LoadByEstimateTemplateCode(DataContext, DataGridViewLeftSection_EstimateTemplate.GetFirstSelectedRowBookmarkValue).ToList

            End Using

            DataGridViewLeftSection_EstimateTemplateExport.HideOrShowColumn("EstimateTemplateCode", True)
            DataGridViewLeftSection_EstimateTemplateExport.HideOrShowColumn("ID", False)

            DataGridViewLeftSection_EstimateTemplateExport.CurrentView.BestFitColumns()

            DataGridViewLeftSection_EstimateTemplateExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemText_CheckSpelling_Click(sender As Object, e As EventArgs) Handles ButtonItemText_CheckSpelling.Click

            EstimateTemplateControlRightSection_EstimateTemplate.CheckSpelling()

        End Sub
        Private Sub EstimateTemplateControlRightSection_EstimateTemplate_InactiveChangedEvent(IsInactive As Boolean, ByRef Cancel As Boolean) Handles EstimateTemplateControlRightSection_EstimateTemplate.InactiveChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Cancel = Not Save()

            End If

        End Sub
        Private Sub EstimateTemplateControlRightSection_EstimateTemplate_SelectedTabChangedEvent() Handles EstimateTemplateControlRightSection_EstimateTemplate.SelectedTabChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
