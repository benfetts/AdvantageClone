Namespace Maintenance.Media.Presentation

    Public Class MediaTemplateMappingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Maintenance.Media.MediaPlanEstimateTemplateController = Nothing
        Private _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanEstimateTemplateMappingViewModel = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.TemplateMapping_Load()

            DataGridViewForm_Vendors.DataSource = _ViewModel.VendorMappings
            DataGridViewForm_Vendors.CurrentView.BestFitColumns()
            DataGridViewForm_Vendors.ValidateAllRows()

            DataGridViewForm_Tactics.DataSource = _ViewModel.TacticMappings
            DataGridViewForm_Tactics.CurrentView.BestFitColumns()
            DataGridViewForm_Tactics.ValidateAllRows()

            Me.ClearChanged()

            RefreshViewModel()

        End Sub
        Private Sub RefreshViewModel()

            Me.ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged
            Me.ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub SaveViewModel()

            DataGridViewForm_Vendors.CloseGridEditorAndSaveValueToDataSource()
            DataGridViewForm_Tactics.CloseGridEditorAndSaveValueToDataSource()

            _ViewModel.VendorMappings = DataGridViewForm_Vendors.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.VendorMapping).ToList
            _ViewModel.TacticMappings = DataGridViewForm_Tactics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.TacticMapping).ToList

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTemplateMappingDialog As AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateMappingDialog = Nothing

            MediaTemplateMappingDialog = New AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateMappingDialog()

            ShowFormDialog = MediaTemplateMappingDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTemplateMappingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_CreateMapTactics.Image = AdvantageFramework.My.Resources.ProcessImage

            DataGridViewForm_Vendors.OptionsBehavior.Editable = True
            DataGridViewForm_Tactics.OptionsBehavior.Editable = True

        End Sub
        Private Sub MediaTemplateMappingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            _Controller = New Controller.Maintenance.Media.MediaPlanEstimateTemplateController(Me.Session)

            LoadViewModel()

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            RefreshViewModel()

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaTemplateMappingDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            Me.ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadViewModel()

        End Sub
        Private Sub ButtonItemActions_CreateMapTactics_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CreateMapTactics.Click

            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            If AdvantageFramework.WinForm.MessageBox.Show("This will create media tactics and map them for the rows with errors.", WinForm.MessageBox.MessageBoxButtons.YesNo, "Continue?", MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                _Controller.TemplateMapping_CreateMapTactics(DataGridViewForm_Tactics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.TacticMapping).Where(Function(T) T.MediaTacticID Is Nothing).ToList, _ViewModel)

                If DataGridViewForm_Tactics.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.TacticMapping.Properties.MediaTacticID.ToString) IsNot Nothing Then

                    SubItemGridLookUpEditControl = DataGridViewForm_Tactics.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.TacticMapping.Properties.MediaTacticID.ToString).ColumnEdit
                    SubItemGridLookUpEditControl.DataSource = _ViewModel.RepositoryMediaTactics

                End If

                DataGridViewForm_Tactics.DataSource = Nothing
                DataGridViewForm_Tactics.DataSource = _ViewModel.TacticMappings
                DataGridViewForm_Tactics.CurrentView.BestFitColumns()
                DataGridViewForm_Tactics.ValidateAllRows()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Dim ErrorMessage As String = Nothing

            SaveViewModel()

            If _Controller.TemplateMapping_Save(_ViewModel, ErrorMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            Else

                Me.ClearChanged()

                LoadViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_Tactics_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Tactics.CellValueChangingEvent

            DataGridViewForm_Tactics.SetUserEntryChanged()

            RefreshViewModel()

        End Sub
        Private Sub DataGridViewForm_Tactics_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_Tactics.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.TacticMapping.Properties.MediaTacticID.ToString Then

                Datasource = _ViewModel.RepositoryMediaTactics

            End If

        End Sub
        Private Sub DataGridViewForm_Vendors_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Vendors.CellValueChangingEvent

            DataGridViewForm_Vendors.SetUserEntryChanged()

            RefreshViewModel()

        End Sub
        Private Sub DataGridViewForm_Vendors_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_Vendors.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.VendorMapping.Properties.VendorCode.ToString Then

                Datasource = _ViewModel.RepositoryVendors

            End If

        End Sub
        Private Sub DataGridViewForm_Tactics_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_Tactics.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewForm_Tactics.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewForm_Tactics.CurrentView.NewItemRowText = e.ErrorText

                    'If e.Valid Then

                    '    _Controller.AddPlanEstimateTemplate(_ViewModel, e.Row)

                    '    RefreshViewModel(True)

                    'End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
