Namespace WinForm.MVC.Presentation.Controls

    Public Class MediaPlanTemplateControl

        Public Event TemplateDetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event TemplateDetails_SelectionChangedEvent(sender As Object, e As EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel = Nothing
        Private _Controller As AdvantageFramework.Controller.Maintenance.Media.MediaPlanEstimateTemplateController = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaPlanTemplateViewModel
            Get
                ViewModel = _ViewModel
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    If _Controller Is Nothing Then

                        _Controller = New AdvantageFramework.Controller.Maintenance.Media.MediaPlanEstimateTemplateController(DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session)

                    End If

                End If

                TextBoxControl_Description.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate.Properties.Description)

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadViewModel()

            TextBoxControl_Description.Text = _ViewModel.PlanTemplate.Description
            CheckBoxControl_IsInactive.Checked = _ViewModel.PlanTemplate.IsInactive

            DataGridViewControl_PlanEstimateTemplates.DataSource = _ViewModel.TemplateDetails
            DataGridViewControl_PlanEstimateTemplates.CurrentView.BestFitColumns()

            If DataGridViewControl_PlanEstimateTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.MediaTypeDescription.ToString) IsNot Nothing Then

                DataGridViewControl_PlanEstimateTemplates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.MediaTypeDescription.ToString).OptionsColumn.AllowFocus = False

            End If

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.PlanTemplate.Description = TextBoxControl_Description.Text
            _ViewModel.PlanTemplate.IsInactive = CheckBoxControl_IsInactive.Checked

        End Sub

#Region "  Public "

        Public Function LoadControl(MediaPlanTemplateHeaderID As Nullable(Of Integer)) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _ViewModel = _Controller.MediaPlanTemplate_Load(MediaPlanTemplateHeaderID)

            LoadViewModel()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            DataGridViewControl_PlanEstimateTemplates.CurrentView.BestFitColumns()

            LoadControl = Loaded

        End Function
        Public Function Add() As Boolean

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim Added As Boolean = False

            SaveViewModel()

            Added = _Controller.MediaPlanTemplate_Add(_ViewModel, ErrorMessage)

            If Added = False Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Add = Added

        End Function
        Public Function Save() As Boolean

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim Saved As Boolean = False

            SaveViewModel()

            Saved = _Controller.MediaPlanTemplate_Save(_ViewModel, ErrorMessage)

            If Saved = False Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Deleted = _Controller.MediaPlanTemplate_Delete(_ViewModel, ErrorMessage)

            Delete = Deleted

        End Function
        Public Sub PlanEstimateTemplates_CancelNewItemRow()

            DataGridViewControl_PlanEstimateTemplates.CancelNewItemRow()

            _Controller.MediaPlanTemplate_CancelNewItemRow(_ViewModel)

        End Sub
        Public Sub PlanEstimateTemplates_Delete()

            _Controller.MediaPlanTemplate_Delete(_ViewModel)

            DataGridViewControl_PlanEstimateTemplates.CurrentView.RefreshData()

            DataGridViewControl_PlanEstimateTemplates.GridViewSelectionChanged()

            DataGridViewControl_PlanEstimateTemplates.SetUserEntryChanged()

        End Sub
        Public Sub ClearControl()

            _ViewModel = _Controller.MediaPlanTemplate_Load(Nothing)

            LoadViewModel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub MediaPlanTemplateControl_Load(sender As Object, e As EventArgs) Handles Me.Load

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_PlanEstimateTemplates_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_PlanEstimateTemplates.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.MediaPlanEstimateTemplateID.ToString Then

                _Controller.MediaPlanTemplate_SetMediaType(e.Value, DirectCast(DataGridViewControl_PlanEstimateTemplates.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail))
                DataGridViewControl_PlanEstimateTemplates.CurrentView.RefreshRow(e.RowHandle)

            End If

        End Sub
        Private Sub DataGridViewControl_PlanEstimateTemplates_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_PlanEstimateTemplates.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            DataGridViewControl_PlanEstimateTemplates.CurrentView.OptionsView.ShowFooter = True

            For Each GridColumn In DataGridViewControl_PlanEstimateTemplates.Columns

                If GridColumn.ColumnType Is GetType(System.Decimal) OrElse
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                    If GridColumn.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.Percentage.ToString Then

                        If DataGridViewControl_PlanEstimateTemplates.Columns(GridColumn.FieldName).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                            DataGridViewControl_PlanEstimateTemplates.Columns(GridColumn.FieldName).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                            DataGridViewControl_PlanEstimateTemplates.Columns(GridColumn.FieldName).SummaryItem.DisplayFormat = "{0:n2}"

                        End If

                    End If

                End If

            Next

        End Sub
        Private Sub DataGridViewControl_PlanEstimateTemplates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_PlanEstimateTemplates.SelectionChangedEvent

            'objects
            Dim SelectedTemplateDetails As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail) = Nothing

            SelectedTemplateDetails = DataGridViewControl_PlanEstimateTemplates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail).ToList

            _Controller.MediaPlanTemplate_SelectedTemplateDetailsChanged(_ViewModel, DataGridViewControl_PlanEstimateTemplates.IsNewItemRow, SelectedTemplateDetails)

            RaiseEvent TemplateDetails_SelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_PlanEstimateTemplates_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_PlanEstimateTemplates.InitNewRowEvent

            _Controller.MediaPlanTemplate_InitNewRowEvent(_ViewModel)

            DataGridViewControl_PlanEstimateTemplates.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.MediaPlanTemplateHeaderID.ToString, _ViewModel.PlanTemplate.ID)

            RaiseEvent TemplateDetails_InitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_PlanEstimateTemplates_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_PlanEstimateTemplates.QueryPopupNeedDatasourceEvent

            Dim Type As String = Nothing

            If FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.MediaPlanEstimateTemplateID.ToString Then

                Datasource = _Controller.MediaPlanTemplate_GetRepositoryPlanEstimateTemplates(_ViewModel)
                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.SalesClassCode.ToString Then

                Type = DataGridViewControl_PlanEstimateTemplates.CurrentView.GetRowCellValue(DataGridViewControl_PlanEstimateTemplates.CurrentView.FocusedRowHandle, AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.MediaType.ToString)

                If String.IsNullOrWhiteSpace(Type) = False Then

                    Datasource = _Controller.MediaPlanTemplate_GetSalesClassesByMediaType(Type)
                    OverrideDefaultDatasource = True

                End If

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.PeriodType.ToString Then

                Type = DataGridViewControl_PlanEstimateTemplates.CurrentView.GetRowCellValue(DataGridViewControl_PlanEstimateTemplates.CurrentView.FocusedRowHandle, AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.MediaType.ToString)

                Datasource = _Controller.MediaPlanTemplate_GetPeriodTypesByMediaType(Type)
                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewControl_PlanEstimateTemplates_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewControl_PlanEstimateTemplates.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.MediaPlanEstimateTemplateID.ToString Then

                Datasource = _ViewModel.RepositoryPlanEstimateTemplates

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.SalesClassCode.ToString Then

                Datasource = _ViewModel.RepositorySalesClasses

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.PeriodType.ToString Then

                Datasource = _ViewModel.RepositoryPeriodTypes

            End If

        End Sub
        Private Sub DataGridViewControl_PlanEstimateTemplates_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewControl_PlanEstimateTemplates.ShowingEditorEvent

            'objects
            Dim TemplateDetail As AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail = Nothing

            TemplateDetail = DirectCast(DataGridViewControl_PlanEstimateTemplates.CurrentView.GetRow(DataGridViewControl_PlanEstimateTemplates.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail)

            If DataGridViewControl_PlanEstimateTemplates.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.MediaPlanEstimateTemplateID.ToString Then

                e.Cancel = (DataGridViewControl_PlanEstimateTemplates.IsNewItemRow = False)

            End If

            If DataGridViewControl_PlanEstimateTemplates.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.SalesClassCode.ToString Then

                If TemplateDetail Is Nothing OrElse (TemplateDetail IsNot Nothing AndAlso String.IsNullOrWhiteSpace(TemplateDetail.MediaType)) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewControl_PlanEstimateTemplates.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail.Properties.PeriodType.ToString Then

                If TemplateDetail Is Nothing OrElse (TemplateDetail IsNot Nothing AndAlso String.IsNullOrWhiteSpace(TemplateDetail.MediaType)) Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_PlanEstimateTemplates_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewControl_PlanEstimateTemplates.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewControl_PlanEstimateTemplates.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewControl_PlanEstimateTemplates.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        DataGridViewControl_PlanEstimateTemplates.SetUserEntryChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_PlanEstimateTemplates_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewControl_PlanEstimateTemplates.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.TemplateDetail = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewControl_PlanEstimateTemplates.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewControl_PlanEstimateTemplates.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewControl_PlanEstimateTemplates.CurrentView.SetColumnError(DataGridViewControl_PlanEstimateTemplates.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
