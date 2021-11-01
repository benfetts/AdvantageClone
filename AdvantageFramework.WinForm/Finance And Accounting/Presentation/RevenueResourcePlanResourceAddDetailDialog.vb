Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanResourceAddDetailDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceAddDetailViewModel = Nothing
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

            ' This call is required by the designer.
            InitializeComponent()

            _RevenueResourcePlanID = RevenueResourcePlanID
            _RevenueResourcePlanResourceID = RevenueResourcePlanResourceID
            _RevenueResourcePlanResourceRevisionID = RevenueResourcePlanResourceRevisionID

        End Sub
        Private Sub LoadViewModel()

            DataGridViewForm_Staffs.DataSource = _ViewModel.PlanResourceStaffs

            DataGridViewForm_Staffs.CurrentView.BestFitColumns()

        End Sub
        Private Sub SaveViewModel()



        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Staffs.SetupForEditableGrid()

            DataGridViewForm_Staffs.MultiSelect = False

        End Sub
        Private Sub RepositoryItemCheckEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            DirectCast(DataGridViewForm_Staffs.CurrentView.GetRow(DataGridViewForm_Staffs.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceStaff).Selected = e.NewValue

            _Controller.ResourceAddDetail_SelectedChanged(_ViewModel)

            RefreshViewModel()

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

                CheckEdit.Checked = Not CheckEdit.Checked

                CType(e, DevExpress.Utils.DXMouseEventArgs).Handled = True

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(RevenueResourcePlanID As Integer, RevenueResourcePlanResourceID As Integer, RevenueResourcePlanResourceRevisionID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim RevenueResourcePlanResourceAddDetailDialog As RevenueResourcePlanResourceAddDetailDialog = Nothing

            RevenueResourcePlanResourceAddDetailDialog = New RevenueResourcePlanResourceAddDetailDialog(RevenueResourcePlanID, RevenueResourcePlanResourceID, RevenueResourcePlanResourceRevisionID)

            ShowFormDialog = RevenueResourcePlanResourceAddDetailDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanResourceAddDetailDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.ResourceAddDetail_Load(_RevenueResourcePlanID, _RevenueResourcePlanResourceID, _RevenueResourcePlanResourceRevisionID)

            LoadViewModel()

            RefreshViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub RevenueResourcePlanResourceAddDetailDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewForm_Staffs.GridViewSelectionChanged()

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

                _Controller.ResourceAddDetail_Add(_ViewModel)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

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
        Private Sub DataGridViewForm_Staffs_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Staffs.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceStaff.Properties.Selected.ToString Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                AddHandler RepositoryItemCheckEdit.EditValueChanging, AddressOf RepositoryItemCheckEdit_EditValueChanging
                AddHandler RepositoryItemCheckEdit.MouseDown, AddressOf RepositoryItemCheckEdit_MouseDown

                e.RepositoryItem = RepositoryItemCheckEdit

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
