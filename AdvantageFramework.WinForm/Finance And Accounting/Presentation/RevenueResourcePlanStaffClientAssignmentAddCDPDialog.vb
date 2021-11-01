Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanStaffClientAssignmentAddCDPDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsAddCDPViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController = Nothing
        Protected _RevenueResourcePlanID As Integer = 0
        Protected _RevenueResourcePlanStaffID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(RevenueResourcePlanID As Integer, RevenueResourcePlanStaffID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _RevenueResourcePlanID = RevenueResourcePlanID
            _RevenueResourcePlanStaffID = RevenueResourcePlanStaffID

        End Sub
        Private Sub LoadViewModel()

            DataGridViewForm_CDPs.ClearDatasource()
            DataGridViewForm_CDPs.ClearColumns()

            If RadioButtonForm_Clients.Checked Then

                DataGridViewForm_CDPs.ItemDescription = "Client(s)"

                DataGridViewForm_CDPs.DataSource = _ViewModel.PlanStaffClientAssignmentClients

                DataGridViewForm_CDPs.MakeColumnNotVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.DivisionCode.ToString)
                DataGridViewForm_CDPs.MakeColumnNotVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.DivisionName.ToString)
                DataGridViewForm_CDPs.MakeColumnNotVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.ProductCode.ToString)
                DataGridViewForm_CDPs.MakeColumnNotVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.ProductName.ToString)

            ElseIf RadioButtonForm_Divisions.Checked Then

                DataGridViewForm_CDPs.ItemDescription = "Division(s)"

                DataGridViewForm_CDPs.DataSource = _ViewModel.PlanStaffClientAssignmentDivisions

                DataGridViewForm_CDPs.MakeColumnVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.DivisionCode.ToString)
                DataGridViewForm_CDPs.MakeColumnVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.DivisionName.ToString)
                DataGridViewForm_CDPs.MakeColumnNotVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.ProductCode.ToString)
                DataGridViewForm_CDPs.MakeColumnNotVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.ProductName.ToString)

            ElseIf RadioButtonForm_Products.Checked Then

                DataGridViewForm_CDPs.ItemDescription = "Product(s)"

                DataGridViewForm_CDPs.DataSource = _ViewModel.PlanStaffClientAssignmentProducts

                DataGridViewForm_CDPs.MakeColumnVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.DivisionCode.ToString)
                DataGridViewForm_CDPs.MakeColumnVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.DivisionName.ToString)
                DataGridViewForm_CDPs.MakeColumnVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.ProductCode.ToString)
                DataGridViewForm_CDPs.MakeColumnVisible(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct.Properties.ProductName.ToString)

            End If

            DataGridViewForm_CDPs.CurrentView.BestFitColumns()

        End Sub
        Private Sub SaveViewModel()

            '_ViewModel.Worksheet.Name = TextBoxForm_Description.Text

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

            RadioButtonForm_Clients.Enabled = _ViewModel.CDPSelectionEnabled
            RadioButtonForm_Divisions.Enabled = _ViewModel.CDPSelectionEnabled
            RadioButtonForm_Products.Enabled = _ViewModel.CDPSelectionEnabled

        End Sub
        Private Sub SetControlDataSources()



        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_CDPs.SetupForEditableGrid()

            DataGridViewForm_CDPs.MultiSelect = False

            RadioButtonForm_Clients.ByPassUserEntryChanged = True
            RadioButtonForm_Divisions.ByPassUserEntryChanged = True
            RadioButtonForm_Products.ByPassUserEntryChanged = True

        End Sub
        Private Sub RepositoryItemCheckEdit_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs)

            'objects
            Dim CheckEdit As DevExpress.XtraEditors.CheckEdit = Nothing
            Dim CheckEditViewInfo As DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo = Nothing
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim EditorRectangle As System.Drawing.Rectangle = Nothing

            CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
            CheckEditViewInfo = CType(CheckEdit.GetViewInfo(), DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)
            Rectangle = CheckEditViewInfo.CheckInfo.GlyphRect

            EditorRectangle = New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), CheckEdit.Size)

            If (Not Rectangle.Contains(e.Location)) AndAlso EditorRectangle.Contains(e.Location) Then

                CType(e, DevExpress.Utils.DXMouseEventArgs).Handled = True

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(RevenueResourcePlanID As Integer, RevenueResourcePlanStaffID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim RevenueResourcePlanStaffClientAssignmentAddCDPDialog As RevenueResourcePlanStaffClientAssignmentAddCDPDialog = Nothing

            RevenueResourcePlanStaffClientAssignmentAddCDPDialog = New RevenueResourcePlanStaffClientAssignmentAddCDPDialog(RevenueResourcePlanID, RevenueResourcePlanStaffID)

            ShowFormDialog = RevenueResourcePlanStaffClientAssignmentAddCDPDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanStaffClientAssignmentAddCDPDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.StaffClientAssignmentAddCDP_Load(_RevenueResourcePlanID, _RevenueResourcePlanStaffID)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewForm_CDPs.CurrentView.BestFitColumns()

        End Sub
        Private Sub RevenueResourcePlanStaffClientAssignmentAddCDPDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewForm_CDPs.GridViewSelectionChanged()

        End Sub
        Private Sub RevenueResourcePlanStaffClientAssignmentAddCDPDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.StaffClientAssignmentAddCDP_UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub RevenueResourcePlanStaffClientAssignmentAddCDPDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.StaffClientAssignmentAddCDP_ClearChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            DataGridViewForm_CDPs.CloseGridEditorAndSaveValueToDataSource()

            _Controller.StaffClientAssignmentAddCDP_Save(_ViewModel)

            Me.ClearChanged()

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_CDPs_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_CDPs.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentClient.Properties.Selected.ToString Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                AddHandler RepositoryItemCheckEdit.MouseDown, AddressOf RepositoryItemCheckEdit_MouseDown

                e.RepositoryItem = RepositoryItemCheckEdit

            End If

        End Sub
        Private Sub DataGridViewForm_CDPs_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_CDPs.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentClient.Properties.Selected.ToString Then

                RefreshViewModel()

            End If

        End Sub
        Private Sub RadioButtonForm_Clients_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_Clients.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso Me.FormShown AndAlso RadioButtonForm_Clients.Checked Then

                LoadViewModel()

            End If

        End Sub
        Private Sub RadioButtonForm_Divisions_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_Divisions.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso Me.FormShown AndAlso RadioButtonForm_Divisions.Checked Then

                LoadViewModel()

            End If

        End Sub
        Private Sub RadioButtonForm_Products_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_Products.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso Me.FormShown AndAlso RadioButtonForm_Products.Checked Then

                LoadViewModel()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
