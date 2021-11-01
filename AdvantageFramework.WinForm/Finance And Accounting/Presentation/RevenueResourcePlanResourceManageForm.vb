Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanResourceManageForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController = Nothing
        Protected _RevenueResourcePlanID As Integer = 0
        Protected _RevenueResourcePlanResourceID As Integer = 0
        Protected _RevenueResourcePlanResourceRevisionID As Integer = 0

#End Region

#Region " Properties "

        Public ReadOnly Property RevenueResourcePlanID As Integer
            Get
                RevenueResourcePlanID = _RevenueResourcePlanID
            End Get
        End Property
        Public ReadOnly Property RevenueResourcePlanResourceID As Integer
            Get
                RevenueResourcePlanResourceID = _RevenueResourcePlanResourceID
            End Get
        End Property
        Public ReadOnly Property RevenueResourcePlanResourceRevisionID As Integer
            Get
                RevenueResourcePlanResourceRevisionID = _RevenueResourcePlanResourceRevisionID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(RevenueResourcePlanID As Integer, RevenueResourcePlanResourceID As Integer, RevenueResourcePlanResourceRevisionID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _RevenueResourcePlanID = RevenueResourcePlanID
            _RevenueResourcePlanResourceID = RevenueResourcePlanResourceID
            _RevenueResourcePlanResourceRevisionID = RevenueResourcePlanResourceRevisionID

        End Sub
        Private Sub LoadViewModel()

            LabelItemApprovalInfo_ApprovedBy.Text = _ViewModel.ApprovedBy
            LabelItemApprovalInfo_ApprovedDate.Text = _ViewModel.ApprovedByDate

            ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue = If(_ViewModel.SelectedPlanResourceRevision IsNot Nothing, _ViewModel.SelectedPlanResourceRevision.RevisionNumber, 1)

            LoadGrid()

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

            ButtonItemRevisions_View.Enabled = (_ViewModel.ViewRevisionEnabled AndAlso _ViewModel.SelectedPlanResourceRevision IsNot Nothing AndAlso ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue <> _ViewModel.SelectedPlanResourceRevision.RevisionNumber)
            ButtonItemRevisions_Create.Enabled = _ViewModel.CreateRevisionEnabled
            ButtonItemRevisions_Delete.Enabled = _ViewModel.DeleteRevisionEnabled

            ButtonItemApproval_Approve.Visible = _ViewModel.ApproveVisible
            ButtonItemApproval_Unapprove.Visible = Not _ViewModel.ApproveVisible
            ItemContainerApproval_ApprovalInfo.Visible = Not _ViewModel.ApproveVisible

            ButtonItemDetails_Add.Enabled = _ViewModel.AddDetailsEnabled
            ButtonItemDetails_Delete.Enabled = _ViewModel.DeleteDetailsEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_ResourceDetails.SetupForEditableGrid()
            DataGridViewForm_ResourceDetails.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_ResourceDetails.OptionsCustomization.AllowGroup = False
            DataGridViewForm_ResourceDetails.MultiSelect = True

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_ResourceDetails.DataSource = _ViewModel.DataView

        End Sub
        Private Sub FormatGrid()

            MakeColumnNotVisible(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ID.ToString))
            MakeColumnNotVisible(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ResourceDetailID.ToString))
            MakeColumnNotVisible(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.StaffID.ToString))
            MakeColumnNotVisible(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.HoursAvailable.ToString))

            SetColumnFormat(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.AllocationPercentage.ToString), DevExpress.Utils.FormatType.Numeric, "p0")

            MakeColumnReadOnly(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Title.ToString))
            MakeColumnReadOnly(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Employee.ToString))
            MakeColumnReadOnly(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Hours.ToString))
            SetColumnFormat(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Hours.ToString), DevExpress.Utils.FormatType.Numeric, "n2")

            MakeColumnReadOnly(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Cost.ToString))
            SetColumnFormat(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Cost.ToString), DevExpress.Utils.FormatType.Numeric, "c2")

            MakeColumnReadOnly(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Revenue.ToString))
            SetColumnFormat(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Revenue.ToString), DevExpress.Utils.FormatType.Numeric, "c2")

            MakeColumnReadOnly(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ProfitPercentage.ToString))
            SetColumnFormat(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ProfitPercentage.ToString), DevExpress.Utils.FormatType.Numeric, "p2")

            MakeColumnReadOnly(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.UtilizationVariance.ToString))
            SetColumnFormat(DataGridViewForm_ResourceDetails.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.UtilizationVariance.ToString), DevExpress.Utils.FormatType.Numeric, "p2")

            For Each DetailDate In _ViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(DD) DD)

                SetColumnFormat(DataGridViewForm_ResourceDetails.Columns(_ViewModel.DetailDates(DetailDate)), DevExpress.Utils.FormatType.Numeric, "n1")

            Next

            DataGridViewForm_ResourceDetails.OptionsCustomization.AllowGroup = False
            DataGridViewForm_ResourceDetails.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_ResourceDetails.OptionsCustomization.AllowQuickHideColumns = False

        End Sub
        Private Sub SetControlDataSources()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            ComboBoxItemRevisions_Revisions.ComboBoxEx.DisplayMember = "RevisionNumberText"
            ComboBoxItemRevisions_Revisions.ComboBoxEx.ValueMember = "RevisionNumber"

            BindingSource = New System.Windows.Forms.BindingSource

            BindingSource.DataSource = (From RevisionNumber In _ViewModel.PlanResourceRevisions.Select(Function(Entity) Entity.RevisionNumber).Distinct.ToList
                                        Select RevisionNumberText = Format(RevisionNumber, "000"),
                                               RevisionNumber = RevisionNumber).ToList

            ComboBoxItemRevisions_Revisions.ComboBoxEx.DataSource = BindingSource

        End Sub
        Private Sub SetColumnFormat(GridColumn As DevExpress.XtraGrid.Columns.GridColumn, FormatType As DevExpress.Utils.FormatType, FormatString As String)

            If GridColumn IsNot Nothing Then

                GridColumn.DisplayFormat.FormatType = FormatType
                GridColumn.DisplayFormat.FormatString = FormatString

            End If

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

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(RevenueResourcePlanID As Integer, RevenueResourcePlanResourceID As Integer, RevenueResourcePlanResourceRevisionID As Integer)

            'objects
            Dim RevenueResourcePlanResourceManageForm As RevenueResourcePlanResourceManageForm = Nothing

            RevenueResourcePlanResourceManageForm = New RevenueResourcePlanResourceManageForm(RevenueResourcePlanID, RevenueResourcePlanResourceID, RevenueResourcePlanResourceRevisionID)

            RevenueResourcePlanResourceManageForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanResourceManageForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemRevisions_View.Image = AdvantageFramework.My.Resources.RevisionViewImage
            ButtonItemRevisions_Create.Image = AdvantageFramework.My.Resources.RevisionImage
            ButtonItemRevisions_Delete.Image = AdvantageFramework.My.Resources.RevisionDeleteImage

            ButtonItemApproval_Approve.Image = AdvantageFramework.My.Resources.ApproveImage
            ButtonItemApproval_Unapprove.Image = AdvantageFramework.My.Resources.UnapproveImage

            ButtonItemDetails_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.ResourceManage_Load(_RevenueResourcePlanID, _RevenueResourcePlanResourceID, _RevenueResourcePlanResourceRevisionID)

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewForm_ResourceDetails.CurrentView.BestFitColumns()

        End Sub
        Private Sub RevenueResourcePlanResourceManageForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            _Controller.ResourceManage_SelectedRowChanged(_ViewModel, DataGridViewForm_ResourceDetails.CurrentView.SelectedRowsCount)

            RefreshViewModel()

            RibbonBarOptions_Approval.ResetCachedContentSize()
            RibbonBarOptions_Approval.Refresh()
            RibbonBarOptions_Approval.Width = RibbonBarOptions_Approval.GetAutoSizeWidth
            RibbonBarOptions_Approval.Refresh()

            Me.ClearChanged()

            Me.Text &= " - (" & _ViewModel.Plan.Description & " " & _ViewModel.PlanResource.ClientCode & ")"

        End Sub
        Private Sub RevenueResourcePlanResourceManageForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ResourceManage_UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub RevenueResourcePlanResourceManageForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ResourceManage_ClearChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            DataGridViewForm_ResourceDetails.CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

            _Controller.ResourceManage_Save(_ViewModel)

            Me.ClearChanged()

            RefreshViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Me.RaiseClearChanged()

            DataGridViewForm_ResourceDetails.GridViewSelectionChanged()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_ResourceDetails.CloseGridEditorAndSaveValueToDataSource()

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to cancel all your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                DataGridViewForm_ResourceDetails.CurrentView.BeginDataUpdate()

                _Controller.ResourceManage_SelectRevision(_ViewModel, ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue)

                LoadViewModel()

                DataGridViewForm_ResourceDetails.CurrentView.EndDataUpdate()

                Me.ClearChanged()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.RaiseClearChanged()

                DataGridViewForm_ResourceDetails.GridViewSelectionChanged()

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

            DataGridViewForm_ResourceDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue <> _ViewModel.SelectedPlanResourceRevision.RevisionNumber Then

                    If _ViewModel.SaveEnabled Then

                        If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                            _Controller.ResourceManage_Save(_ViewModel)

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

                        DataGridViewForm_ResourceDetails.CurrentView.BeginDataUpdate()

                        _Controller.ResourceManage_SelectRevision(_ViewModel, ComboBoxItemRevisions_Revisions.ComboBoxEx.SelectedValue)

                        LoadViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        DataGridViewForm_ResourceDetails.CurrentView.EndDataUpdate()

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        DataGridViewForm_ResourceDetails.GridViewSelectionChanged()

                        RefreshViewModel()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemRevisions_Create_Click(sender As Object, e As EventArgs) Handles ButtonItemRevisions_Create.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_ResourceDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.ResourceManage_Save(_ViewModel)

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

                    DataGridViewForm_ResourceDetails.CurrentView.BeginDataUpdate()

                    _Controller.ResourceManage_CreateRevision(_ViewModel)

                    SetControlDataSources()

                    LoadViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_ResourceDetails.CurrentView.EndDataUpdate()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                    DataGridViewForm_ResourceDetails.GridViewSelectionChanged()

                    RefreshViewModel()

                End If

            End If

        End Sub
        Private Sub ButtonItemRevisions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemRevisions_Delete.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_ResourceDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.ResourceManage_Save(_ViewModel)

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

                    DataGridViewForm_ResourceDetails.CurrentView.BeginDataUpdate()

                    _Controller.ResourceManage_DeleteRevision(_ViewModel)

                    SetControlDataSources()

                    LoadViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_ResourceDetails.CurrentView.EndDataUpdate()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                    DataGridViewForm_ResourceDetails.GridViewSelectionChanged()

                    RefreshViewModel()

                End If

            End If

        End Sub
        Private Sub ButtonItemApproval_Approve_Click(sender As Object, e As EventArgs) Handles ButtonItemApproval_Approve.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_ResourceDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.ResourceManage_Save(_ViewModel)

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

                    DataGridViewForm_ResourceDetails.CurrentView.BeginDataUpdate()

                    _Controller.ResourceManage_ApproveRevision(_ViewModel)

                    LoadViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_ResourceDetails.CurrentView.EndDataUpdate()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                    DataGridViewForm_ResourceDetails.GridViewSelectionChanged()

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

            DataGridViewForm_ResourceDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.ResourceManage_Save(_ViewModel)

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

                    DataGridViewForm_ResourceDetails.CurrentView.BeginDataUpdate()

                    _Controller.ResourceManage_UnapproveRevision(_ViewModel)

                    LoadViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_ResourceDetails.CurrentView.EndDataUpdate()

                    Me.ClearChanged()

                    Me.RaiseClearChanged()

                    DataGridViewForm_ResourceDetails.GridViewSelectionChanged()

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

            DataGridViewForm_ResourceDetails.CloseGridEditorAndSaveValueToDataSource()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.SaveEnabled Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                        _Controller.ResourceManage_Save(_ViewModel)

                        [Continue] = True

                        Me.ClearChanged()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.RaiseClearChanged()

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    If RevenueResourcePlanResourceAddDetailDialog.ShowFormDialog(_ViewModel.RevenueResourcePlanID, _ViewModel.RevenueResourcePlanResourceID, _ViewModel.SelectedPlanResourceRevision.ID) = System.Windows.Forms.DialogResult.OK Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                        DataGridViewForm_ResourceDetails.CurrentView.BeginDataUpdate()

                        _Controller.ResourceManage_LoadDetails(_ViewModel)

                        LoadViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        DataGridViewForm_ResourceDetails.CurrentView.EndDataUpdate()

                        Me.ClearChanged()

                        Me.RaiseClearChanged()

                        DataGridViewForm_ResourceDetails.GridViewSelectionChanged()

                        RefreshViewModel()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDetails_Delete.Click

            'objects
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataGridViewForm_ResourceDetails.CloseGridEditorAndSaveValueToDataSource()

            RowIndexes = New Generic.List(Of Integer)

            For Each RowHandle In DataGridViewForm_ResourceDetails.CurrentView.GetSelectedRows

                If DataGridViewForm_ResourceDetails.CurrentView.IsDataRow(RowHandle) Then

                    DataRow = CType(DataGridViewForm_ResourceDetails.CurrentView.GetRow(RowHandle), System.Data.DataRowView).Row

                    RowIndexes.Add(_ViewModel.DataTable.Rows.IndexOf(DataRow))

                End If

            Next

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete selected row(s)?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                DataGridViewForm_ResourceDetails.CurrentView.BeginDataUpdate()

                _Controller.ResourceManage_DeleteDetail(_ViewModel, RowIndexes.ToArray)

                DataGridViewForm_ResourceDetails.CurrentView.EndDataUpdate()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_ResourceDetails.SetUserEntryChanged()

                DataGridViewForm_ResourceDetails.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewForm_ResourceDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ResourceDetails.SelectionChangedEvent

            _Controller.ResourceManage_SelectedRowChanged(_ViewModel, DataGridViewForm_ResourceDetails.CurrentView.SelectedRowsCount)

            RefreshViewModel()

        End Sub
        Private Sub DataGridViewForm_ResourceDetails_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_ResourceDetails.PopupMenuShowingEvent

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
        Private Sub DataGridViewForm_ResourceDetails_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_ResourceDetails.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = Nothing

            If _ViewModel.DetailDates.ContainsValue(e.Column.FieldName) Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "n1"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "n1"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "n1"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "n1"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.AllocationPercentage.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "p0"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "p0"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "p0"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "p0"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 100
                RepositoryItemSpinEdit.MaxLength = 3
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            End If

        End Sub
        Private Sub DataGridViewForm_ResourceDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_ResourceDetails.ShowingEditorEvent

            If DataGridViewForm_ResourceDetails.CurrentView.FocusedColumn IsNot Nothing Then

                If DataGridViewForm_ResourceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Cost.ToString OrElse
                        DataGridViewForm_ResourceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Revenue.ToString OrElse
                        DataGridViewForm_ResourceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ProfitPercentage.ToString OrElse
                        DataGridViewForm_ResourceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.UtilizationVariance.ToString OrElse
                        DataGridViewForm_ResourceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Hours.ToString Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ResourceDetails_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ResourceDetails.CellValueChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.AllocationPercentage.ToString Then

                    _Controller.ResourceManage_AllocationPercentageChanged(_ViewModel, DataGridViewForm_ResourceDetails.CurrentView.GetDataSourceRowIndex(e.RowHandle))

                    DataGridViewForm_ResourceDetails.RefreshDataSource()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
