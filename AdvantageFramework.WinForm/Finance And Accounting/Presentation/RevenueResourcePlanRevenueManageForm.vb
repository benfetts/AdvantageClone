Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanRevenueManageForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController = Nothing
        Protected _RevenueResourcePlanID As Integer = 0
        Protected _RevenueResourcePlanRevenueID As Integer = 0
        Protected _RevenueResourcePlanRevenueRevisionID As Integer = 0

#End Region

#Region " Properties "

        Public ReadOnly Property RevenueResourcePlanID As Integer
            Get
                RevenueResourcePlanID = _RevenueResourcePlanID
            End Get
        End Property
        Public ReadOnly Property RevenueResourcePlanRevenueID As Integer
            Get
                RevenueResourcePlanRevenueID = _RevenueResourcePlanRevenueID
            End Get
        End Property
        Public ReadOnly Property RevenueResourcePlanRevenueRevisionID As Integer
            Get
                RevenueResourcePlanRevenueRevisionID = _RevenueResourcePlanRevenueRevisionID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(RevenueResourcePlanID As Integer, RevenueResourcePlanRevenueID As Integer, RevenueResourcePlanRevenueRevisionID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _RevenueResourcePlanID = RevenueResourcePlanID
            _RevenueResourcePlanRevenueID = RevenueResourcePlanRevenueID
            _RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueRevisionID

        End Sub
        Private Sub LoadViewModel()

            LabelItemApprovalInfo_ApprovedBy.Text = _ViewModel.ApprovedBy
            LabelItemApprovalInfo_ApprovedDate.Text = _ViewModel.ApprovedByDate

            ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue = If(_ViewModel.SelectedPlanRevenueRevision IsNot Nothing, _ViewModel.SelectedPlanRevenueRevision.RevisionNumber, 1)

            LoadGrid()

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

            ButtonItemRevisions_View.Enabled = (_ViewModel.ViewRevisionEnabled AndAlso _ViewModel.SelectedPlanRevenueRevision IsNot Nothing AndAlso ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue <> _ViewModel.SelectedPlanRevenueRevision.RevisionNumber)
            ButtonItemRevisions_Create.Enabled = _ViewModel.CreateRevisionEnabled
            ButtonItemRevisions_Delete.Enabled = _ViewModel.DeleteRevisionEnabled

            ButtonItemApproval_Approve.Visible = _ViewModel.ApproveVisible
            ButtonItemApproval_Unapprove.Visible = Not _ViewModel.ApproveVisible
            ItemContainerApproval_ApprovalInfo.Visible = Not _ViewModel.ApproveVisible

            ButtonItemDetails_Add.Enabled = _ViewModel.AddDetailsEnabled
            ButtonItemDetails_Delete.Enabled = _ViewModel.DeleteDetailsEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_RevenueDetails.SetupForEditableGrid()
            DataGridViewForm_RevenueDetails.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_RevenueDetails.OptionsCustomization.AllowGroup = False
            DataGridViewForm_RevenueDetails.MultiSelect = True

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_RevenueDetails.DataSource = _ViewModel.DataView

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim SubItemMemoEdit As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemMemoEdit = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            MakeColumnNotVisible(DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.ID.ToString))
            MakeColumnNotVisible(DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueDetailID.ToString))

            If DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueTypeID.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueType), GetType(Integer))

                SubItemGridLookUpEditControl.DataSource = BindingSource

                DataGridViewForm_RevenueDetails.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueTypeID.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            If DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueStatusID.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueStatus), GetType(Integer))

                SubItemGridLookUpEditControl.DataSource = BindingSource

                DataGridViewForm_RevenueDetails.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueStatusID.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            MakeColumnReadOnly(DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Client.ToString))
            MakeColumnReadOnly(DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Division.ToString))
            MakeColumnReadOnly(DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Product.ToString))

            MakeColumnNotVisible(DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.JobNumber.ToString))
            MakeColumnNotVisible(DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.JobComponentNumber.ToString))

            MakeColumnReadOnly(DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.JobComponent.ToString))

            If DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Notes.ToString) IsNot Nothing Then

                SubItemMemoEdit = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemMemoEdit

                SubItemMemoEdit.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemComboBox.Type.Default
                SubItemMemoEdit.ShowIcon = False

                DataGridViewForm_RevenueDetails.GridControl.RepositoryItems.Add(SubItemMemoEdit)

                DataGridViewForm_RevenueDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Notes.ToString).ColumnEdit = SubItemMemoEdit

            End If

            For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(DD) DD)

                GridColumn = DataGridViewForm_RevenueDetails.Columns(_ViewModel.DetailDates(DetailDate).ToString)

                GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridColumn.DisplayFormat.FormatString = "c2"
                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsFilter.AllowFilter = False

                AlterActualColumn(DataGridViewForm_RevenueDetails.Columns(_ViewModel.ActualDetailDates(DetailDate)))

            Next

            DataGridViewForm_RevenueDetails.OptionsCustomization.AllowGroup = False
            DataGridViewForm_RevenueDetails.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_RevenueDetails.OptionsCustomization.AllowQuickHideColumns = False

        End Sub
        Private Sub SetControlDataSources()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            ComboBoxItemRevisions_Revisions.ComboBoxEx.DisplayMember = "RevisionNumberText"
            ComboBoxItemRevisions_Revisions.ComboBoxEx.ValueMember = "RevisionNumber"

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From RevisionNumber In _ViewModel.PlanRevenueRevisions.Select(Function(Entity) Entity.RevisionNumber).Distinct.ToList
                                        Select RevisionNumberText = Format(RevisionNumber, "000"),
                                               RevisionNumber = RevisionNumber).ToList

            ComboBoxItemRevisions_Revisions.ComboBoxEx.DataSource = BindingSource

        End Sub
        Private Sub MakeColumnNotVisible(GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            If GridColumn IsNot Nothing Then

                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.Visible = False

            End If

        End Sub
        Private Sub MakeColumnReadOnly(GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            If GridColumn IsNot Nothing Then

                GridColumn.OptionsColumn.ReadOnly = True

            End If

        End Sub
        Private Sub AlterActualColumn(GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            If GridColumn IsNot Nothing Then

                GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridColumn.DisplayFormat.FormatString = "c2"
                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False
                GridColumn.OptionsFilter.AllowFilter = False

                GridColumn.Visible = ButtonItemActuals_Show.Checked

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(RevenueResourcePlanID As Integer, RevenueResourcePlanRevenueID As Integer, RevenueResourcePlanRevenueRevisionID As Integer)

            'objects
            Dim RevenueResourcePlanRevenueManageForm As RevenueResourcePlanRevenueManageForm = Nothing

            RevenueResourcePlanRevenueManageForm = New RevenueResourcePlanRevenueManageForm(RevenueResourcePlanID, RevenueResourcePlanRevenueID, RevenueResourcePlanRevenueRevisionID)

            RevenueResourcePlanRevenueManageForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanRevenueManageForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemRevisions_View.Image = AdvantageFramework.My.Resources.RevisionViewImage
            ButtonItemRevisions_Create.Image = AdvantageFramework.My.Resources.RevisionImage
            ButtonItemRevisions_Delete.Image = AdvantageFramework.My.Resources.RevisionDeleteImage

            ButtonItemApproval_Approve.Image = AdvantageFramework.My.Resources.ApproveImage
            ButtonItemApproval_Unapprove.Image = AdvantageFramework.My.Resources.UnapproveImage

            ButtonItemDetails_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemActuals_Show.Image = AdvantageFramework.My.Resources.AccountsPayableImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.RevenueManage_Load(_RevenueResourcePlanID, _RevenueResourcePlanRevenueID, _RevenueResourcePlanRevenueRevisionID)

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewForm_RevenueDetails.CurrentView.BestFitColumns()

        End Sub
        Private Sub RevenueResourcePlanRevenueManageForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            _Controller.RevenueManage_SelectedRowChanged(_ViewModel, DataGridViewForm_RevenueDetails.CurrentView.SelectedRowsCount)

            RefreshViewModel()

            RibbonBarOptions_Approval.ResetCachedContentSize()
            RibbonBarOptions_Approval.Refresh()
            RibbonBarOptions_Approval.Width = RibbonBarOptions_Approval.GetAutoSizeWidth
            RibbonBarOptions_Approval.Refresh()

            Me.ClearChanged()

            Me.Text &= " - (" & _ViewModel.Plan.Description & " " & _ViewModel.PlanRevenue.ClientCode & ")"

        End Sub
        Private Sub RevenueResourcePlanRevenueManageForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.RevenueManage_UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub RevenueResourcePlanRevenueManageForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.RevenueManage_ClearChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            DataGridViewForm_RevenueDetails.CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

            _Controller.RevenueManage_Save(_ViewModel)

            Me.ClearChanged()

            RefreshViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Me.RaiseClearChanged()

            DataGridViewForm_RevenueDetails.GridViewSelectionChanged()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_RevenueDetails.CloseGridEditorAndSaveValueToDataSource()

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to cancel all your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                DataGridViewForm_RevenueDetails.CurrentView.BeginDataUpdate()

                _Controller.RevenueManage_SelectRevision(_ViewModel, ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue)

                LoadViewModel()

                DataGridViewForm_RevenueDetails.CurrentView.EndDataUpdate()

                Me.ClearChanged()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.RaiseClearChanged()

                DataGridViewForm_RevenueDetails.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ComboBoxItemRevisions_Revisions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemRevisions_Revisions.SelectedIndexChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemRevisions_View_Click(sender As Object, e As EventArgs) Handles ButtonItemRevisions_View.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_RevenueDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue <> _ViewModel.SelectedPlanRevenueRevision.RevisionNumber Then

                    If _ViewModel.SaveEnabled Then

                        If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                            _Controller.RevenueManage_Save(_ViewModel)

                            [Continue] = True

                            Me.ClearChanged()

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                            Me.RaiseClearChanged()

                        End If

                    Else

                        [Continue] = True

                    End If

                    If [Continue] Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        DataGridViewForm_RevenueDetails.CurrentView.BeginDataUpdate()

                        _Controller.RevenueManage_SelectRevision(_ViewModel, ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue)

                        LoadViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        DataGridViewForm_RevenueDetails.CurrentView.EndDataUpdate()

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        DataGridViewForm_RevenueDetails.GridViewSelectionChanged()

                        RefreshViewModel()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemRevisions_Create_Click(sender As Object, e As EventArgs) Handles ButtonItemRevisions_Create.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_RevenueDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.RevenueManage_Save(_ViewModel)

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    DataGridViewForm_RevenueDetails.CurrentView.BeginDataUpdate()

                    _Controller.RevenueManage_CreateRevision(_ViewModel)

                    SetControlDataSources()

                    LoadViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_RevenueDetails.CurrentView.EndDataUpdate()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                    DataGridViewForm_RevenueDetails.GridViewSelectionChanged()

                    RefreshViewModel()

                End If

            End If

        End Sub
        Private Sub ButtonItemRevisions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemRevisions_Delete.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_RevenueDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.RevenueManage_Save(_ViewModel)

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    DataGridViewForm_RevenueDetails.CurrentView.BeginDataUpdate()

                    _Controller.RevenueManage_DeleteRevision(_ViewModel)

                    SetControlDataSources()

                    LoadViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_RevenueDetails.CurrentView.EndDataUpdate()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                    DataGridViewForm_RevenueDetails.GridViewSelectionChanged()

                    RefreshViewModel()

                End If

            End If

        End Sub
        Private Sub ButtonItemApproval_Approve_Click(sender As Object, e As EventArgs) Handles ButtonItemApproval_Approve.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_RevenueDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.RevenueManage_Save(_ViewModel)

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    DataGridViewForm_RevenueDetails.CurrentView.BeginDataUpdate()

                    _Controller.RevenueManage_ApproveRevision(_ViewModel)

                    LoadViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_RevenueDetails.CurrentView.EndDataUpdate()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                    DataGridViewForm_RevenueDetails.GridViewSelectionChanged()

                    RefreshViewModel()

                    RibbonBarOptions_Approval.ResetCachedContentSize()
                    RibbonBarOptions_Approval.Refresh()
                    RibbonBarOptions_Approval.Width = RibbonBarOptions_Approval.GetAutoSizeWidth
                    RibbonBarOptions_Approval.Refresh()

                End If

            End If

        End Sub
        Private Sub ButtonItemApproval_Unapprove_Click(sender As Object, e As EventArgs) Handles ButtonItemApproval_Unapprove.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_RevenueDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.RevenueManage_Save(_ViewModel)

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    DataGridViewForm_RevenueDetails.CurrentView.BeginDataUpdate()

                    _Controller.RevenueManage_UnapproveRevision(_ViewModel)

                    LoadViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_RevenueDetails.CurrentView.EndDataUpdate()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                    DataGridViewForm_RevenueDetails.GridViewSelectionChanged()

                    RefreshViewModel()

                    RibbonBarOptions_Approval.ResetCachedContentSize()
                    RibbonBarOptions_Approval.Refresh()
                    RibbonBarOptions_Approval.Width = RibbonBarOptions_Approval.GetAutoSizeWidth
                    RibbonBarOptions_Approval.Refresh()

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Add.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_RevenueDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.RevenueManage_Save(_ViewModel)

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    If RevenueResourcePlanRevenueAddDetailDialog.ShowFormDialog(_ViewModel.RevenueResourcePlanID, _ViewModel.RevenueResourcePlanRevenueID, _ViewModel.SelectedPlanRevenueRevision.ID) = System.Windows.Forms.DialogResult.OK Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        DataGridViewForm_RevenueDetails.CurrentView.BeginDataUpdate()

                        _Controller.RevenueManage_LoadDetails(_ViewModel)

                        LoadViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        DataGridViewForm_RevenueDetails.CurrentView.EndDataUpdate()

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        DataGridViewForm_RevenueDetails.GridViewSelectionChanged()

                        RefreshViewModel()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            'objects
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataGridViewForm_RevenueDetails.CloseGridEditorAndSaveValueToDataSource()

            RowIndexes = New Generic.List(Of Integer)

            For Each RowHandle In DataGridViewForm_RevenueDetails.CurrentView.GetSelectedRows

                If DataGridViewForm_RevenueDetails.CurrentView.IsDataRow(RowHandle) Then

                    DataRow = CType(DataGridViewForm_RevenueDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                    RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                End If

            Next

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete selected row(s)?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                DataGridViewForm_RevenueDetails.CurrentView.BeginDataUpdate()

                _Controller.RevenueManage_DeleteDetail(_ViewModel, RowIndexes.ToArray)

                DataGridViewForm_RevenueDetails.CurrentView.EndDataUpdate()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_RevenueDetails.SetUserEntryChanged()

                DataGridViewForm_RevenueDetails.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewForm_RevenueDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_RevenueDetails.SelectionChangedEvent

            _Controller.RevenueManage_SelectedRowChanged(_ViewModel, DataGridViewForm_RevenueDetails.CurrentView.SelectedRowsCount)

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemActuals_Show_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemActuals_Show.CheckedChanged

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 8

            DataGridViewForm_RevenueDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                DataGridViewForm_RevenueDetails.CurrentView.BeginUpdate()

                For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(DD) DD)

                    GridColumn = DataGridViewForm_RevenueDetails.Columns(_ViewModel.ActualDetailDates(DetailDate).ToString)

                    If ButtonItemActuals_Show.Checked Then

                        GridColumn.VisibleIndex = VisibleIndex

                    Else

                        GridColumn.Visible = False

                    End If

                    VisibleIndex += 2

                Next

                DataGridViewForm_RevenueDetails.CurrentView.EndUpdate()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub DataGridViewForm_RevenueDetails_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_RevenueDetails.PopupMenuShowingEvent

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    Select Case MenuItem.Tag

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuColumnShowColumn,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn

                            MenuItem.Visible = False

                    End Select

                Next

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
