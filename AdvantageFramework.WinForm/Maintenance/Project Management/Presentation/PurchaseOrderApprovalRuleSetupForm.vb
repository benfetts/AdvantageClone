Namespace Maintenance.ProjectManagement.Presentation

    Public Class PurchaseOrderApprovalRuleSetupForm

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

                DataGridViewLeftSection_PurchaseOrderApprovalRule.DataSource = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.Load(DbContext).ToList

            End Using

            DataGridViewLeftSection_PurchaseOrderApprovalRule.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.ClearControl()

            PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.Enabled = DataGridViewLeftSection_PurchaseOrderApprovalRule.HasOnlyOneSelectedRow

            If PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.Enabled Then

                PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.Enabled = PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.LoadControl(DataGridViewLeftSection_PurchaseOrderApprovalRule.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.Enabled = (DataGridViewLeftSection_PurchaseOrderApprovalRule.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_PurchaseOrderApprovalRule.HasOnlyOneSelectedRow AndAlso PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.Enabled)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            If PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.Enabled Then

                If PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.PurchaseOrderApprovalRuleDetailHasOnlyOneSelectedRow(False) Then

                    If PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.PurchaseOrderApprovalRuleDetailIsNewItemRow(PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.PurchaseOrderApprovalRuleDetailFocusedRowHandle) Then

                        ButtonItemDetails_Cancel.Enabled = True
                        ButtonItemDetails_Delete.Enabled = False
                        ButtonItemActions_Approvers.Enabled = False

                    Else

                        ButtonItemDetails_Cancel.Enabled = False
                        ButtonItemDetails_Delete.Enabled = True
                        ButtonItemActions_Approvers.Enabled = True

                    End If

                Else

                    ButtonItemDetails_Cancel.Enabled = False
                    ButtonItemDetails_Delete.Enabled = PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.PurchaseOrderApprovalRuleDetailHasRows
                    ButtonItemActions_Approvers.Enabled = False

                End If

            Else

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = False
                ButtonItemActions_Approvers.Enabled = False

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

                            IsOkay = PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.Save()

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
            Dim PurchaseOrderApprovalRuleSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.PurchaseOrderApprovalRuleSetupForm = Nothing

            PurchaseOrderApprovalRuleSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.PurchaseOrderApprovalRuleSetupForm()

            PurchaseOrderApprovalRuleSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderApprovalSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Approvers.Image = AdvantageFramework.My.Resources.UserImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            DataGridViewLeftSection_PurchaseOrderApprovalRule.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_PurchaseOrderApprovalRule.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub PurchaseOrderApprovalSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PurchaseOrderApprovalSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PurchaseOrderApprovalSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_PurchaseOrderApprovalRule.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_PurchaseOrderApprovalRule_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_PurchaseOrderApprovalRule.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_PurchaseOrderApprovalRule_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_PurchaseOrderApprovalRule.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_PurchaseOrderApprovalRule.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                            LoadSelectedItemDetails()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_PurchaseOrderApprovalRule.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a PO Approval Rule to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            Dim PurchaseOrderApprovalRuleCode As String = Nothing
            Dim CanAdd As Boolean = True

            If DataGridViewLeftSection_PurchaseOrderApprovalRule.HasOnlyOneSelectedRow Then

                CanAdd = CheckForUnsavedChanges()

            End If

            If CanAdd Then

                If AdvantageFramework.Maintenance.ProjectManagement.Presentation.PurchaseOrderApprovalRuleEditDialog.ShowFormDialog(PurchaseOrderApprovalRuleCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_PurchaseOrderApprovalRule.SelectRow(PurchaseOrderApprovalRuleCode)

                Else

                    LoadSelectedItemDetails()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_PurchaseOrderApprovalRule.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.Delete() Then

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_PurchaseOrderApprovalRule.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a PO Approval Rule to delete.")

            End If

        End Sub
        Private Sub PurchaseOrderApprovalRuleControlRightSection_POApprovalRule_PurchaseOrderApprovalRuleDetailInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.PurchaseOrderApprovalRuleDetailInitNewRowEvent

            ButtonItemDetails_Cancel.Enabled = True
            ButtonItemDetails_Delete.Enabled = False

        End Sub
        Private Sub PurchaseOrderApprovalRuleControlRightSection_POApprovalRule_PurchaseOrderApprovalRuleDetailSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.PurchaseOrderApprovalRuleDetailSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub PurchaseOrderApprovalRuleControlRightSection_POApprovalRule_PurchaseOrderApprovalRuleInActiveChanged() Handles PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.PurchaseOrderApprovalRuleInActiveChanged

            LoadGrid()

            LoadSelectedItemDetails()

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.CancelNewItemRowPurchaseOrderApprovalRuleDetail()

            EnableOrDisableActions()

            If PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.PurchaseOrderApprovalRuleDetailHasOnlyOneSelectedRow(False) Then

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.PurchaseOrderApprovalRuleDetailHasRows

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            Me.ShowWaitForm("Processing...")

            Try

                PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.DeletePurchaseOrderApprovalRuleDetail()

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_Approvers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Approvers.Click

            Dim PurchaseOrderApprovalRuleCode As String = Nothing
            Dim PurchaseOrderApprovalRuleDetailSequenceNumber As Short = Nothing

            If DataGridViewLeftSection_PurchaseOrderApprovalRule.HasASelectedRow Then

                PurchaseOrderApprovalRuleCode = DataGridViewLeftSection_PurchaseOrderApprovalRule.GetFirstSelectedRowBookmarkValue

                If PurchaseOrderApprovalRuleCode IsNot Nothing Then

                    If PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.PurchaseOrderApprovalRuleDetailHasOnlyOneSelectedRow() Then

                        PurchaseOrderApprovalRuleDetailSequenceNumber = DirectCast(PurchaseOrderApprovalRuleControlRightSection_POApprovalRule.DataGridViewControl_PurchaseOrderApprovalRuleDetails.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail).SequenceNumber

                        AdvantageFramework.Maintenance.ProjectManagement.Presentation.PurchaseOrderApprovalRuleEmployeesSetupForm.ShowFormDialog(PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleDetailSequenceNumber)

                        LoadSelectedItemDetails()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            'objects
            Dim CodesList As Generic.List(Of String) = Nothing
            Dim PurchaseOrderApprovalRuleDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail) = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                CodesList = DataGridViewLeftSection_PurchaseOrderApprovalRule.GetAllRowsBookmarkValues.OfType(Of String).ToList

                PurchaseOrderApprovalRuleDetailsList = (From PurchaseOrderApprovalDetail In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.Load(DbContext).Include("PurchaseOrderApprovalRule").ToList.Where(Function(Entity) CodesList.Contains(Entity.PurchaseOrderApprovalRuleCode) = True)
                                                        Select New AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail(DbContext, PurchaseOrderApprovalDetail)).ToList


            End Using

            ParameterDictionary = New Generic.Dictionary(Of String, Object)

            ParameterDictionary.Add("DataSource", PurchaseOrderApprovalRuleDetailsList)

            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.PurchaseOrderApprovalRuleReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            'objects
            Dim PurchaseOrderApprovalRuleDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail) = Nothing
            Dim PurchaseOrderApprovalRuleCode As String = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            If DataGridViewLeftSection_PurchaseOrderApprovalRule.HasOnlyOneSelectedRow Then

                PurchaseOrderApprovalRuleCode = DataGridViewLeftSection_PurchaseOrderApprovalRule.GetFirstSelectedRowBookmarkValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    PurchaseOrderApprovalRuleDetailsList = (From PurchaseOrderApprovalDetail In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.Load(DbContext).Include("PurchaseOrderApprovalRule").ToList
                                                            Where PurchaseOrderApprovalDetail.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleCode
                                                            Select New AdvantageFramework.Database.Classes.PurchaseOrderApprovalRuleDetail(DbContext, PurchaseOrderApprovalDetail)).ToList


                End Using

                ParameterDictionary = New Generic.Dictionary(Of String, Object)

                ParameterDictionary.Add("DataSource", PurchaseOrderApprovalRuleDetailsList)

                AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.PurchaseOrderApprovalRuleReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace