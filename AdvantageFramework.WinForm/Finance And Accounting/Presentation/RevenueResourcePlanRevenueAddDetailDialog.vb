Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanRevenueAddDetailDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddDetailViewModel = Nothing
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

            ' This call is required by the designer.
            InitializeComponent()

            _RevenueResourcePlanID = RevenueResourcePlanID
            _RevenueResourcePlanRevenueID = RevenueResourcePlanRevenueID
            _RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueRevisionID

        End Sub
        Private Sub LoadViewModel()

            DataGridViewForm_CDPJCs.ClearGridCustomization()

            If _ViewModel.ClientSelected Then

                DataGridViewForm_CDPJCs.DataSource = _ViewModel.Clients

            ElseIf _ViewModel.DivisionSelected Then

                DataGridViewForm_CDPJCs.DataSource = _ViewModel.Divisions

            ElseIf _ViewModel.ProductSelected Then

                DataGridViewForm_CDPJCs.DataSource = _ViewModel.Products

            ElseIf _ViewModel.JobComponentSelected Then

                DataGridViewForm_CDPJCs.DataSource = _ViewModel.JobComponents

            End If

            DataGridViewForm_CDPJCs.CurrentView.BestFitColumns()

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.ClientSelected = RadioButtonForm_Client.Checked
            _ViewModel.DivisionSelected = RadioButtonForm_Division.Checked
            _ViewModel.ProductSelected = RadioButtonForm_Product.Checked
            _ViewModel.JobComponentSelected = RadioButtonForm_JobComponent.Checked

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlDataSources()

            RadioButtonForm_Client.Checked = _ViewModel.ClientSelected
            RadioButtonForm_Division.Checked = _ViewModel.DivisionSelected
            RadioButtonForm_Product.Checked = _ViewModel.ProductSelected
            RadioButtonForm_JobComponent.Checked = _ViewModel.JobComponentSelected

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_CDPJCs.MultiSelect = True

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(RevenueResourcePlanID As Integer, RevenueResourcePlanRevenueID As Integer, RevenueResourcePlanRevenueRevisionID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim RevenueResourcePlanRevenueAddDetailDialog As RevenueResourcePlanRevenueAddDetailDialog = Nothing

            RevenueResourcePlanRevenueAddDetailDialog = New RevenueResourcePlanRevenueAddDetailDialog(RevenueResourcePlanID, RevenueResourcePlanRevenueID, RevenueResourcePlanRevenueRevisionID)

            ShowFormDialog = RevenueResourcePlanRevenueAddDetailDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanRevenueAddDetailDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.RevenueAddDetail_Load(_RevenueResourcePlanID, _RevenueResourcePlanRevenueID, _RevenueResourcePlanRevenueRevisionID)

            SetControlDataSources()

            LoadViewModel()

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub RevenueResourcePlanRevenueAddDetailDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewForm_CDPJCs.GridViewSelectionChanged()

            RefreshViewModel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim Added As Boolean = False

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                SaveViewModel()

                If _ViewModel.ClientSelected Then

                    Added = _Controller.RevenueAddDetail_AddClient(_ViewModel, DataGridViewForm_CDPJCs.GetFirstSelectedRowDataBoundItem, ErrorMessage)

                ElseIf _ViewModel.DivisionSelected Then

                    Added = _Controller.RevenueAddDetail_AddDivisions(_ViewModel, DataGridViewForm_CDPJCs.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Division).ToList, ErrorMessage)

                ElseIf _ViewModel.ProductSelected Then

                    Added = _Controller.RevenueAddDetail_AddProducts(_ViewModel, DataGridViewForm_CDPJCs.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Product).ToList, ErrorMessage)

                ElseIf _ViewModel.JobComponentSelected Then

                    Added = _Controller.RevenueAddDetail_AddJobComponents(_ViewModel, DataGridViewForm_CDPJCs.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.JobComponent).ToList, ErrorMessage)

                End If

                If Added Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonForm_Client_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_Client.CheckedChanged

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If RadioButtonForm_Client.Checked Then

                    _Controller.RevenueAddDetail_CDPJCChanged(_ViewModel, RadioButtonForm_Client.Checked, RadioButtonForm_Division.Checked, RadioButtonForm_Product.Checked, RadioButtonForm_JobComponent.Checked)

                    LoadViewModel()

                    DataGridViewForm_CDPJCs.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub RadioButtonForm_Division_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_Division.CheckedChanged

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If RadioButtonForm_Division.Checked Then

                    _Controller.RevenueAddDetail_CDPJCChanged(_ViewModel, RadioButtonForm_Client.Checked, RadioButtonForm_Division.Checked, RadioButtonForm_Product.Checked, RadioButtonForm_JobComponent.Checked)

                    LoadViewModel()

                    DataGridViewForm_CDPJCs.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub RadioButtonForm_Product_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_Product.CheckedChanged

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If RadioButtonForm_Product.Checked Then

                    _Controller.RevenueAddDetail_CDPJCChanged(_ViewModel, RadioButtonForm_Client.Checked, RadioButtonForm_Division.Checked, RadioButtonForm_Product.Checked, RadioButtonForm_JobComponent.Checked)

                    LoadViewModel()

                    DataGridViewForm_CDPJCs.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub RadioButtonForm_JobComponent_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_JobComponent.CheckedChanged

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If RadioButtonForm_JobComponent.Checked Then

                    _Controller.RevenueAddDetail_CDPJCChanged(_ViewModel, RadioButtonForm_Client.Checked, RadioButtonForm_Division.Checked, RadioButtonForm_Product.Checked, RadioButtonForm_JobComponent.Checked)

                    LoadViewModel()

                    DataGridViewForm_CDPJCs.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_CDPJCs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_CDPJCs.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                _Controller.RevenueAddDetail_SelectedRowChanged(_ViewModel, DataGridViewForm_CDPJCs.CurrentView.SelectedRowsCount)

                RefreshViewModel()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
