Imports DevExpress.XtraGrid.Views.Base

Namespace ProjectManagement.Presentation

    Public Class PurchaseOrderSetupForm

#Region " Constants "



#End Region

#Region " Enum "

        Protected Enum POViewLayout
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "By Purchase Order")>
            ByPurchaseOrder = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "By PO Detail")>
            ByPODetail = 1
        End Enum

#End Region

#Region " Variables "

        Private _LoadCounter As Short = 0
        Private _LastSearchedClientCode As String = Nothing
        Private _LastSearchedDivisionCode As String = Nothing
        Private _LastSearchedProductCode As String = Nothing
        Private _LastSearchedEmployeeCode As String = Nothing
        Private _LastSearchedVendorCode As String = Nothing
        Private _LastSearchedJobNumber As Integer = Nothing
        Private _LastSearchedJobCompNumber As Short = Nothing
        Private _LastSearchedPODate As System.DateTime = Nothing
        Private _LastSearchedDueDate As System.DateTime = Nothing
        Private _LastSearchedBy As Integer = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Function LoadGrid(ByVal RefreshGridOnly As Boolean)

            'objects
            Dim ViewLayout As POViewLayout = Nothing
            Dim CancelLoadGrid As Boolean = False
            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""
            Dim ProductCode As String = ""
            Dim JobNumber As Integer = Nothing
            Dim JobCompNumber As Short = Nothing

            Try

                ViewLayout = DirectCast(CInt(ComboBoxActions_SearchBy.GetSelectedValue), POViewLayout)

            Catch ex As Exception
                ViewLayout = POViewLayout.ByPurchaseOrder
            End Try

            If RefreshGridOnly = False Then

                Select Case ViewLayout

                    Case POViewLayout.ByPODetail

                        If RefreshGridOnly = False Then

                            If AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderInitialLoadingDialog.ShowFormDialog(ClientCode, DivisionCode, ProductCode, JobNumber, JobCompNumber) = Windows.Forms.DialogResult.OK Then

                                _LastSearchedClientCode = ClientCode
                                _LastSearchedDivisionCode = DivisionCode
                                _LastSearchedProductCode = ProductCode
                                _LastSearchedJobNumber = JobNumber
                                _LastSearchedJobCompNumber = JobCompNumber

                            Else

                                CancelLoadGrid = True

                            End If

                        End If

                    Case Else

                        CancelLoadGrid = False

                End Select

            End If

            If CancelLoadGrid = False Then

                If Me.FormShown Then

                    GetCurrentDataGridView.Focus()
                    Me.ShowWaitForm()

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Select Case ViewLayout

                        Case POViewLayout.ByPODetail

                            DataGridViewLeftSection_PODetails.Visible = True
                            DataGridViewLeftSection_PurchaseOrders.Visible = False

                            DataGridViewLeftSection_PODetails.DataSource = AdvantageFramework.Database.Procedures.PurchaseOrderDetailsComplex.Load(DbContext, Nothing, _LastSearchedClientCode, _LastSearchedDivisionCode, _LastSearchedProductCode, _LastSearchedJobNumber, _LastSearchedJobCompNumber).OrderByDescending(Function(PODetail) PODetail.SortOrder)
                            DataGridViewLeftSection_PODetails.CurrentView.BestFitColumns()

                        Case POViewLayout.ByPurchaseOrder

                            DataGridViewLeftSection_PODetails.Visible = False
                            DataGridViewLeftSection_PurchaseOrders.Visible = True

                            DataGridViewLeftSection_PurchaseOrders.DataSource = AdvantageFramework.Database.Procedures.PurchaseOrderComplexType.Load(DbContext, Me.Session.UserCode, False, False, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing).OrderBy(Function(Entity) Entity.SortOrder)
                            DataGridViewLeftSection_PurchaseOrders.CurrentView.BestFitColumns()

                    End Select

                End Using

                If Me.FormShown Then

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                End If

            End If

            LoadGrid = Not CancelLoadGrid

        End Function
        Private Sub LoadSelectedItemDetails()

            'objects
            Dim PONumber As Integer = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                PurchaseOrderControlRightSection_PurchaseOrder.ClearControl()

                PurchaseOrderControlRightSection_PurchaseOrder.Enabled = GetCurrentDataGridView.HasOnlyOneSelectedRow

                If PurchaseOrderControlRightSection_PurchaseOrder.Enabled Then

                    Try

                        PONumber = CInt(GetCurrentDataGridView.GetFirstSelectedRowBookmarkValue)

                    Catch ex As Exception
                        PONumber = Nothing
                    End Try

                    PurchaseOrderControlRightSection_PurchaseOrder.Enabled = PurchaseOrderControlRightSection_PurchaseOrder.LoadControl(PONumber)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions(Optional ByVal IsResetting As Boolean = False)

            If IsResetting = False Then

                PurchaseOrderControlRightSection_PurchaseOrder.Enabled = (Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso GetCurrentDataGridView.HasOnlyOneSelectedRow)

            End If

            RibbonBarOptions_Spelling.Visible = If(PurchaseOrderControlRightSection_PurchaseOrder.SelectedTab IsNot PurchaseOrderControlRightSection_PurchaseOrder.TabItemPODetails_DetailsTab, True, False)

            If PurchaseOrderControlRightSection_PurchaseOrder.SelectedTab Is PurchaseOrderControlRightSection_PurchaseOrder.TabItemPODetails_DetailsTab Then

                RibbonBarOptions_Details.Visible = True
                RibbonBarOptions_Spelling.Visible = False

            Else

                RibbonBarOptions_Details.Visible = False
                RibbonBarOptions_Spelling.Visible = True

            End If

            If PurchaseOrderControlRightSection_PurchaseOrder.Enabled Then

                If PurchaseOrderControlRightSection_PurchaseOrder.POLocked Then

                    ButtonItemActions_Save.Enabled = False
                    ButtonItemActions_Revise.Enabled = False

                    ButtonItemDetails_Copy.Enabled = False
                    ButtonItemDetails_CopyFrom.Enabled = False
                    ButtonItemDetails_Delete.Enabled = False
                    ButtonItemDetails_Cancel.Enabled = False
                    ButtonItemDetails_Estimate.Enabled = False
                    ButtonItemDetails_Add.Enabled = False

                    ButtonItemSpelling_CheckSpelling.Enabled = False

                Else

                    ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                    ButtonItemActions_Revise.Enabled = True

                    ButtonItemDetails_Copy.Enabled = PurchaseOrderControlRightSection_PurchaseOrder.CanCopySelectedItem
                    ButtonItemDetails_CopyFrom.Enabled = True
                    ButtonItemDetails_Delete.Enabled = PurchaseOrderControlRightSection_PurchaseOrder.CanDeleteSelectedItem
                    ButtonItemDetails_Cancel.Enabled = PurchaseOrderControlRightSection_PurchaseOrder.DetailsDataGridView.IsNewItemRow
                    ButtonItemDetails_Estimate.Enabled = PurchaseOrderControlRightSection_PurchaseOrder.CanEstimate
                    ButtonItemDetails_Add.Enabled = True

                    ButtonItemSpelling_CheckSpelling.Enabled = True

                End If

                ButtonItemActions_Copy.Enabled = True
                ButtonItemActions_Void.Enabled = PurchaseOrderControlRightSection_PurchaseOrder.CanVoid
                ButtonItemActions_PrintOrSend.Enabled = PurchaseOrderControlRightSection_PurchaseOrder.CanPrint
                ButtonItemActions_CancelApproval.Enabled = PurchaseOrderControlRightSection_PurchaseOrder.CanCancelApproval
                ButtonItemDetails_AP.Enabled = PurchaseOrderControlRightSection_PurchaseOrder.IsSelectedItemAttachedToAP

            Else

                ButtonItemActions_PrintOrSend.Enabled = False
                ButtonItemActions_CancelApproval.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Void.Enabled = False
                ButtonItemActions_Copy.Enabled = False
                ButtonItemActions_Revise.Enabled = False

                ButtonItemDetails_Copy.Enabled = False
                ButtonItemDetails_CopyFrom.Enabled = False
                ButtonItemDetails_Delete.Enabled = False
                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Estimate.Enabled = False
                ButtonItemDetails_Add.Enabled = False
                ButtonItemDetails_AP.Enabled = False

                ButtonItemSpelling_CheckSpelling.Enabled = False

            End If

        End Sub
        Private Function CheckForUnsavedChanges(ByVal ForceReloadOnFail As Boolean) As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = PurchaseOrderControlRightSection_PurchaseOrder.Save()

                        Catch ex As Exception
                            IsOkay = False
                        End Try

                        If IsOkay = False AndAlso AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Would you like to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            If ForceReloadOnFail Then

                                LoadSelectedItemDetails()

                            End If

                            IsOkay = True

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                Else

                    If ForceReloadOnFail Then

                        LoadSelectedItemDetails()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function IsOkToPrint() As Boolean

            'objects
            Dim OkToPrint As Boolean = True

            Try

                If Me.UserEntryChanged = True Then

                    AdvantageFramework.Navigation.ShowMessageBox("Please save all changes before printing.")

                    OkToPrint = False

                End If

            Catch ex As Exception
                OkToPrint = False
            Finally
                IsOkToPrint = OkToPrint
            End Try

        End Function
        Private Function GetCurrentDataGridView() As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

            If DataGridViewLeftSection_PODetails.Visible Then

                GetCurrentDataGridView = DataGridViewLeftSection_PODetails

            ElseIf DataGridViewLeftSection_PurchaseOrders.Visible Then

                GetCurrentDataGridView = DataGridViewLeftSection_PurchaseOrders

            Else

                DataGridViewLeftSection_PurchaseOrders.Visible = True
                GetCurrentDataGridView = DataGridViewLeftSection_PurchaseOrders

            End If

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim PurchaseOrderSetupForm As AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderSetupForm = Nothing

            PurchaseOrderSetupForm = New AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderSetupForm()

            PurchaseOrderSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim CanUserUpdate As Boolean = False
            Dim CanUserAdd As Boolean = False

            ItemContainerActions_ItemContainer.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle

            CanUserAdd = AdvantageFramework.Security.CanUserAddInModule(Me.Session, Security.Modules.ProjectManagement_PurchaseOrders)
            CanUserUpdate = AdvantageFramework.Security.CanUserUpdateInModule(Me.Session, Security.Modules.ProjectManagement_PurchaseOrders)

            ButtonItemActions_Add.SecurityEnabled = CanUserAdd
            ButtonItemActions_Copy.SecurityEnabled = CanUserAdd
            ButtonItemActions_Void.SecurityEnabled = CanUserUpdate
            ButtonItemActions_CancelApproval.SecurityEnabled = CanUserUpdate
            ButtonItemActions_PrintOrSend.SecurityEnabled = AdvantageFramework.Security.CanUserPrintInModule(Me.Session, Security.Modules.ProjectManagement_PurchaseOrders)
            ButtonItemActions_Save.SecurityEnabled = CanUserUpdate
            ButtonItemActions_Revise.SecurityEnabled = CanUserUpdate

            ButtonItemDetails_Add.SecurityEnabled = CanUserAdd
            ButtonItemDetails_Copy.SecurityEnabled = CanUserAdd
            ButtonItemDetails_CopyFrom.SecurityEnabled = CanUserAdd
            ButtonItemDetails_Delete.SecurityEnabled = CanUserUpdate
            ButtonItemDetails_Cancel.SecurityEnabled = CanUserUpdate
            ButtonItemDetails_Estimate.SecurityEnabled = CanUserUpdate

            ButtonItemSpelling_CheckSpelling.SecurityEnabled = CanUserUpdate

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Void.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_PrintOrSend.Image = AdvantageFramework.My.Resources.PrintImage
            ButtonItemActions_CancelApproval.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Revise.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemDetails_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemDetails_CopyFrom.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Estimate.Image = AdvantageFramework.My.Resources.CalculatorImage
            ButtonItemDetails_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemDetails_AP.Image = AdvantageFramework.My.Resources.AccountsPayableImage

            ButtonItemSpelling_CheckSpelling.Image = AdvantageFramework.My.Resources.ValidateImage

            DataGridViewLeftSection_PurchaseOrders.MultiSelect = False
            DataGridViewLeftSection_PODetails.MultiSelect = False
            DataGridViewLeftSection_PODetails.Visible = False

            DataGridViewLeftSection_PODetails.ItemDescription = "Purchase Order Detail(s)"

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ComboBoxActions_SearchBy.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(POViewLayout)).ToList

            Try

                LoadGrid(False)

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_PurchaseOrders.CurrentView.AFActiveFilterString = "[IsComplete] = False AND [IsVoid] = False"

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_PODetails.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderDetailsComplex))

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_PODetails.CurrentView.AFActiveFilterString = "[POComplete] = False AND [VoidFlag] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub PurchaseOrderSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PurchaseOrderSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PurchaseOrderSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_PurchaseOrders.FocusToFindPanel(True)

        End Sub
        Private Sub FocusToFindPanel(ByVal DeselectAllRows As Boolean)

            If DataGridViewLeftSection_PODetails.Visible Then

                DataGridViewLeftSection_PODetails.FocusToFindPanel(False)

            ElseIf DataGridViewLeftSection_PurchaseOrders.Visible Then

                DataGridViewLeftSection_PurchaseOrders.FocusToFindPanel(False)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

#Region "   Ribbonbar Buttons "

        Private Sub ButtonItemActions_CancelApproval_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CancelApproval.Click

            'objects
            Dim ErrorMessage As String = ""

            If GetCurrentDataGridView.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If PurchaseOrderControlRightSection_PurchaseOrder.CancelApproval() Then

                            Me.ClearChanged()

                            LoadGrid(True)

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        GetCurrentDataGridView.FocusToFindPanel(False)
                        GetCurrentDataGridView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a purchase order.")

            End If

        End Sub
        Private Sub ButtonItemActions_PrintOrSend_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintOrSend.Click

            'objects
            Dim ErrorMessage As String = ""

            If GetCurrentDataGridView.HasOnlyOneSelectedRow Then

                If CheckForUnsavedChanges(True) Then

                    If Me.Validator Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            If PurchaseOrderControlRightSection_PurchaseOrder.SubmitForApprovalOrPrint() Then

                                Me.ClearChanged()

                                LoadGrid(True)

                            End If

                        Catch ex As Exception
                            ErrorMessage = ex.Message
                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                        End Try

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        If ErrorMessage = "" Then

                            GetCurrentDataGridView.FocusToFindPanel(False)
                            GetCurrentDataGridView.CurrentView.GridViewSelectionChanged()

                        End If

                    Else

                        For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                            ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                        Next

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a purchase order.")

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim ContinueCopy As Boolean = False
            Dim PONumber As String = Nothing

            If GetCurrentDataGridView.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges(False)

                If ContinueCopy Then

                    PONumber = GetCurrentDataGridView.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderEditDialog.ShowFormDialog(PONumber, True) = Windows.Forms.DialogResult.OK Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            LoadGrid(True)

                            GetCurrentDataGridView.SelectRow(PONumber)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        GetCurrentDataGridView.CurrentView.GridViewSelectionChanged()

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a purchase order to copy.")

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            AdvantageFramework.Exporting.Presentation.ExportForm.ShowForm(Exporting.ExportTypes.PurchaseOrder, False, True, Nothing)

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ContinueAdd As Boolean = True
            Dim PONumber As String = Nothing

            If GetCurrentDataGridView.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges(False)

            End If

            If ContinueAdd Then

                If AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderEditDialog.ShowFormDialog(PONumber, False) = Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid(True)

                        GetCurrentDataGridView.SelectRow(PONumber)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    GetCurrentDataGridView.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If GetCurrentDataGridView.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        If PurchaseOrderControlRightSection_PurchaseOrder.Save() Then

                            Me.ClearChanged()

                            LoadGrid(True)

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        GetCurrentDataGridView.FocusToFindPanel(False)

                        GetCurrentDataGridView.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a purchase order to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Void_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Void.Click

            If GetCurrentDataGridView.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to void this purchase order? If yes, it will be marked as voided and will no longer be available for use.", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        If PurchaseOrderControlRightSection_PurchaseOrder.Void() Then

                            Me.ClearChanged()

                            LoadGrid(True)

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    GetCurrentDataGridView.CurrentView.GridViewSelectionChanged()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a purchase order to void.")

            End If

        End Sub
        Private Sub ButtonItemSpelling_CheckSpelling_Click(sender As Object, e As EventArgs) Handles ButtonItemSpelling_CheckSpelling.Click

            PurchaseOrderControlRightSection_PurchaseOrder.CheckSpelling()

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            PurchaseOrderControlRightSection_PurchaseOrder.DeleteSelectedItem()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Cancel.Click

            PurchaseOrderControlRightSection_PurchaseOrder.DetailsDataGridView.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_Estimate_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Estimate.Click

            PurchaseOrderControlRightSection_PurchaseOrder.Estimate(False)

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxActions_SearchBy_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBoxActions_SearchBy.SelectionChangeCommitted

            'objects
            Dim SelectedIndex As Integer = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If CheckForUnsavedChanges(False) Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    SelectedIndex = ComboBoxActions_SearchBy.SelectedIndex

                    If LoadGrid(False) Then

                        _LastSearchedBy = SelectedIndex
                        GetCurrentDataGridView.FocusToFindPanel(True)
                        PurchaseOrderControlRightSection_PurchaseOrder.ClearControl()
                        PurchaseOrderControlRightSection_PurchaseOrder.Enabled = False

                    End If

                    ComboBoxActions_SearchBy.SelectedIndex = _LastSearchedBy

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    EnableOrDisableActions(True)

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Copy.Click

            If GetCurrentDataGridView.HasOnlyOneSelectedRow Then

                Try

                    PurchaseOrderControlRightSection_PurchaseOrder.CopySelectedItem()

                Catch ex As Exception
                    AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                End Try

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Revise_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Revise.Click

            If CheckForUnsavedChanges(False) Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                Try

                    If PurchaseOrderControlRightSection_PurchaseOrder.Revise() Then

                        Me.ClearChanged()

                    End If

                Catch ex As Exception
                    AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub ButtonItemDetails_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Add.Click

            'objects
            Dim ContinueAdd As Boolean = False
            Dim ErrorMessage As String = ""
            Dim Reload As Boolean = False

            If CheckForUnsavedChanges(False) Then

                Try

                    If PurchaseOrderControlRightSection_PurchaseOrder.AutoGenerateItems() Then

                        Me.ClearChanged()

                        GetCurrentDataGridView.CurrentView.GridViewSelectionChanged()

                    End If

                Catch ex As Exception
                    AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                End Try

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_AP_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_AP.Click

            PurchaseOrderControlRightSection_PurchaseOrder.ViewAPInfo()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemDetails_CopyFrom_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_CopyFrom.Click

            'objects
            Dim ContinueCopy As Boolean = False
            Dim PONumber As Integer = Nothing

            If GetCurrentDataGridView.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges(False)

                If ContinueCopy Then

                    PONumber = GetCurrentDataGridView.GetFirstSelectedRowBookmarkValue

                    If AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderDetailCopyDialog.ShowFormDialog(PONumber) = Windows.Forms.DialogResult.OK Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                        Try

                            LoadGrid(True)

                            GetCurrentDataGridView.SelectRow(PONumber)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        GetCurrentDataGridView.CurrentView.GridViewSelectionChanged()

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a purchase order.")

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If Me.CheckForUnsavedChanges(False) Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                Me.ShowWaitForm("Processing...")

                Try

                    PurchaseOrderControlRightSection_PurchaseOrder.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If DataGridViewLeftSection_PurchaseOrders.Visible Then

                    DataGridViewLeftSection_PurchaseOrders.GridViewSelectionChanged()

                ElseIf DataGridViewLeftSection_PODetails.Visible Then

                    DataGridViewLeftSection_PODetails.GridViewSelectionChanged()

                End If

            End If

        End Sub

#End Region

#Region "   Purchase Order Control Events "

        Private Sub PurchaseOrderControlRightSection_PurchaseOrder_NewItemRowOptionsEvent() Handles PurchaseOrderControlRightSection_PurchaseOrder.NewItemRowOptionsEvent

            EnableOrDisableActions()

        End Sub
        Private Sub PurchaseOrderControlRightSection_PurchaseOrder_NewPODetailEvent() Handles PurchaseOrderControlRightSection_PurchaseOrder.NewPODetailEvent

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            Try

                LoadGrid(True)

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub PurchaseOrderControlRightSection_PurchaseOrder_SelectedDetailChangedEvent() Handles PurchaseOrderControlRightSection_PurchaseOrder.SelectedDetailChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub PurchaseOrderControlRightSection_PurchaseOrder_SelectedTabChangedEvent() Handles PurchaseOrderControlRightSection_PurchaseOrder.SelectedTabChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "   Grids "

        Private Sub DataGridViewLeftSection_PurchaseOrders_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_PurchaseOrders.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges(False)

            End If

        End Sub
        Private Sub DataGridViewLeftSection_PurchaseOrders_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_PurchaseOrders.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_PODetails_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_PODetails.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges(False)

            End If

        End Sub
        Private Sub DataGridViewLeftSection_PODetails_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_PODetails.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub PurchaseOrderControlRightSection_PurchaseOrder_DisplayNumberChangedEvent() Handles PurchaseOrderControlRightSection_PurchaseOrder.DisplayNumberChangedEvent

            If DataGridViewLeftSection_PurchaseOrders.Visible Then

                DataGridViewLeftSection_PurchaseOrders.CurrentView.SetRowCellValue(DataGridViewLeftSection_PurchaseOrders.CurrentView.GetSelectedRows.First, AdvantageFramework.Database.Classes.PurchaseOrderComplex.Properties.DisplayPONumber.ToString, PurchaseOrderControlRightSection_PurchaseOrder.DisplayPONumber)

            ElseIf DataGridViewLeftSection_PODetails.Visible Then

                DataGridViewLeftSection_PODetails.CurrentView.SetRowCellValue(DataGridViewLeftSection_PODetails.CurrentView.GetSelectedRows.First, AdvantageFramework.Database.Classes.PurchaseOrderComplex.Properties.DisplayPONumber.ToString, PurchaseOrderControlRightSection_PurchaseOrder.DisplayPONumber)

            End If

        End Sub


        Private Sub DataGridViewLeftSection_PurchaseOrders_CustomColumnSortEvent(sender As Object, e As CustomColumnSortEventArgs) Handles DataGridViewLeftSection_PurchaseOrders.CustomColumnSortEvent
            Try
                Dim PONumber1 As Integer = 0
                Dim PONumber2 As Integer = 0

                If e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetailsComplex.Properties.DisplayPONumber.ToString Then

                    PONumber1 = DataGridViewLeftSection_PurchaseOrders.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex1, AdvantageFramework.Database.Classes.PurchaseOrderDetailsComplex.Properties.SortOrder.ToString)
                    PONumber2 = DataGridViewLeftSection_PurchaseOrders.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex2, AdvantageFramework.Database.Classes.PurchaseOrderDetailsComplex.Properties.SortOrder.ToString)

                    e.Handled = True
                    e.Result = System.Collections.Comparer.Default.Compare(PONumber1, PONumber2)

                End If

            Catch ex As Exception

            End Try
        End Sub

        Private Sub DataGridViewLeftSection_PurchaseOrders_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_PurchaseOrders.DataSourceChangedEvent

            If DataGridViewLeftSection_PurchaseOrders.Columns IsNot Nothing AndAlso DataGridViewLeftSection_PurchaseOrders.Columns.Count > 0 Then

                For Each GridColumn In DataGridViewLeftSection_PurchaseOrders.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderComplex.Properties.DisplayPONumber.ToString Then

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                    End If

                Next

            End If

        End Sub

        Private Sub DataGridViewLeftSection_PODetails_CustomColumnSortEvent(sender As Object, e As CustomColumnSortEventArgs) Handles DataGridViewLeftSection_PODetails.CustomColumnSortEvent
            Try
                Dim PONumber1 As Integer = 0
                Dim PONumber2 As Integer = 0

                If e.Column.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderDetailsComplex.Properties.DisplayPONumber.ToString Then

                    PONumber1 = DataGridViewLeftSection_PODetails.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex1, AdvantageFramework.Database.Classes.PurchaseOrderDetailsComplex.Properties.SortOrder.ToString)
                    PONumber2 = DataGridViewLeftSection_PODetails.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex2, AdvantageFramework.Database.Classes.PurchaseOrderDetailsComplex.Properties.SortOrder.ToString)

                    e.Handled = True
                    e.Result = System.Collections.Comparer.Default.Compare(PONumber1, PONumber2)

                End If

            Catch ex As Exception

            End Try
        End Sub

        Private Sub DataGridViewLeftSection_PODetails_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_PODetails.DataSourceChangedEvent
            If DataGridViewLeftSection_PurchaseOrders.Columns IsNot Nothing AndAlso DataGridViewLeftSection_PurchaseOrders.Columns.Count > 0 Then

                For Each GridColumn In DataGridViewLeftSection_PODetails.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.PurchaseOrderComplex.Properties.DisplayPONumber.ToString Then

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                    End If

                Next

            End If
        End Sub
#End Region

#End Region

#End Region

    End Class

End Namespace
