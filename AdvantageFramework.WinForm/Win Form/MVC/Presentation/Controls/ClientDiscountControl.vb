Namespace WinForm.MVC.Presentation.Controls

    Public Class ClientDiscountControl

        Public Event Exclusions_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event Exclusions_SelectionChangedEvent(sender As Object, e As EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _ViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel = Nothing
        Private _Controller As AdvantageFramework.Controller.Maintenance.Accounting.ClientDiscountController = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel
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

                        _Controller = New AdvantageFramework.Controller.Maintenance.Accounting.ClientDiscountController(DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session)

                    End If

                End If

                TextBoxControl_Code.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount.Properties.Code)
                TextBoxControl_Name.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount.Properties.Name)
                NumericInputControl_Percent.SetPropertySettings(AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount.Properties.Percent)

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadViewModel()

            TextBoxControl_Code.Text = _ViewModel.ClientDiscount.Code
            TextBoxControl_Name.Text = _ViewModel.ClientDiscount.Name
            NumericInputControl_Percent.EditValue = _ViewModel.ClientDiscount.Percent
            CheckBoxControl_IsInactive.Checked = _ViewModel.ClientDiscount.IsInactive

            DataGridViewControl_Exclusions.DataSource = _ViewModel.ClientDiscountExclusions

            TextBoxControl_Code.ReadOnly = (_ViewModel.AllowCodeEdit = False)
            TextBoxControl_Code.Enabled = _ViewModel.AllowCodeEdit

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.ClientDiscount.Code = TextBoxControl_Code.Text
            _ViewModel.ClientDiscount.Name = TextBoxControl_Name.Text
            _ViewModel.ClientDiscount.Percent = NumericInputControl_Percent.EditValue
            _ViewModel.ClientDiscount.IsInactive = CheckBoxControl_IsInactive.Checked

        End Sub

#Region "  Public "

        Public Function LoadControl(ClientDiscountCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _ViewModel = _Controller.Load(ClientDiscountCode)

            LoadViewModel()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            DataGridViewControl_Exclusions.CurrentView.BestFitColumns()

            LoadControl = Loaded

        End Function
        Public Function Add() As Boolean

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim Added As Boolean = False

            SaveViewModel()

            Added = _Controller.Add(_ViewModel, ErrorMessage)

            If Added = False Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Add = Added

        End Function
        Public Sub Save()

            SaveViewModel()

            _Controller.Save(_ViewModel)

        End Sub
        Public Function Delete(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Deleted = _Controller.Delete(_ViewModel, ErrorMessage)

            Delete = Deleted

        End Function
        Public Sub DiscountExclusions_CancelNewItemRow()

            DataGridViewControl_Exclusions.CancelNewItemRow()

            _Controller.DiscountExclusions_CancelNewItemRow(_ViewModel)

        End Sub
        Public Sub DiscountExclusions_Delete()

            _Controller.DiscountExclusions_Delete(_ViewModel)

            DataGridViewControl_Exclusions.CurrentView.RefreshData()

            DataGridViewControl_Exclusions.GridViewSelectionChanged()

            DataGridViewControl_Exclusions.SetUserEntryChanged()

        End Sub
        Public Sub ClearControl()

            _ViewModel = _Controller.Load(String.Empty)

            LoadViewModel()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ClientDiscountControl_Load(sender As Object, e As EventArgs) Handles Me.Load

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_Exclusions_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_Exclusions.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion.Properties.FunctionCode.ToString Then

                DirectCast(DataGridViewControl_Exclusions.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion).FunctionDescription = _Controller.GetRepositoryFunctionDescription(_ViewModel, e.Value)

            End If

        End Sub
        Private Sub DataGridViewControl_Exclusions_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_Exclusions.SelectionChangedEvent

            'objects
            Dim SelectedClientDiscountExclusions As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion) = Nothing

            SelectedClientDiscountExclusions = DataGridViewControl_Exclusions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion).ToList

            _Controller.SelectedDiscountExclusionsChanged(_ViewModel, DataGridViewControl_Exclusions.IsNewItemRow, SelectedClientDiscountExclusions)

            RaiseEvent Exclusions_SelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_Exclusions_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_Exclusions.InitNewRowEvent

            _Controller.DiscountExclusions_InitNewRowEvent(_ViewModel)

            DataGridViewControl_Exclusions.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion.Properties.ClientDiscountCode.ToString, _ViewModel.ClientDiscount.Code)

            RaiseEvent Exclusions_InitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_Exclusions_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_Exclusions.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion.Properties.FunctionCode.ToString Then

                Datasource = _Controller.GetRepositoryFunctions(_ViewModel)
                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewControl_Exclusions_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewControl_Exclusions.ShowingEditorEvent

            If DataGridViewControl_Exclusions.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion.Properties.FunctionCode.ToString Then

                e.Cancel = (DataGridViewControl_Exclusions.IsNewItemRow = False)

            End If

        End Sub
        Private Sub DataGridViewControl_Exclusions_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewControl_Exclusions.ValidateRowEvent

            e.Valid = True

            DataGridViewControl_Exclusions.SetUserEntryChanged()

        End Sub

#End Region

#End Region

    End Class

End Namespace
