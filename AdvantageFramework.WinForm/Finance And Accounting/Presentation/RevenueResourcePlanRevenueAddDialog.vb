Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanRevenueAddDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController = Nothing
        Protected _RevenueResourcePlanID As Integer = 0

#End Region

#Region " Properties "

        Public ReadOnly Property RevenueResourcePlanID As Integer
            Get
                RevenueResourcePlanID = _RevenueResourcePlanID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(RevenueResourcePlanID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _RevenueResourcePlanID = RevenueResourcePlanID

        End Sub
        Private Sub LoadViewModel()

            ComboBoxForm_Client.SelectedValue = _ViewModel.PlanRevenue.ClientCode
            ComboBoxForm_Owner.SelectedValue = _ViewModel.PlanRevenue.EmployeeCode
            TextBoxForm_Notes.Text = _ViewModel.PlanRevenue.Notes

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.PlanRevenue.ClientCode = ComboBoxForm_Client.GetSelectedValue
            _ViewModel.PlanRevenue.EmployeeCode = ComboBoxForm_Owner.GetSelectedValue
            _ViewModel.PlanRevenue.Notes = TextBoxForm_Notes.Text

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Visible = _ViewModel.AddVisible
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlDataSources()

            ComboBoxForm_Client.DataSource = _ViewModel.Clients.ToList
            ComboBoxForm_Owner.DataSource = _ViewModel.Employees.ToList

        End Sub
        Private Sub SetControlPropertySettings()

            ComboBoxForm_Client.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenue.Properties.ClientCode)
            ComboBoxForm_Owner.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenue.Properties.EmployeeCode)
            TextBoxForm_Notes.SetPropertySettings(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenue.Properties.Notes)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef RevenueResourcePlanID As Integer = 0) As System.Windows.Forms.DialogResult

            'objects
            Dim RevenueResourcePlanRevenueAddDialog As RevenueResourcePlanRevenueAddDialog = Nothing

            RevenueResourcePlanRevenueAddDialog = New RevenueResourcePlanRevenueAddDialog(RevenueResourcePlanID)

            ShowFormDialog = RevenueResourcePlanRevenueAddDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                RevenueResourcePlanID = RevenueResourcePlanRevenueAddDialog.RevenueResourcePlanID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanRevenueAddDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.RevenueAdd_Load(_RevenueResourcePlanID)

            SetControlDataSources()

            LoadViewModel()

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub RevenueResourcePlanRevenueAddDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                SaveViewModel()

                If _Controller.RevenueAdd_Add(_ViewModel, ErrorMessage) Then

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

#End Region

#End Region

    End Class

End Namespace
