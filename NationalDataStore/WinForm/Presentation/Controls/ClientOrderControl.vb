Namespace WinForm.Presentation.Controls

    Public Class ClientOrderControl

        Public Event DetailInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event DetailSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _ConnectionString As String = Nothing
        Private _ClientID As Integer = 0
        Private _ClientOrderID As Integer = 0
        Private _ViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderDetailViewModel = Nothing
        Private _Controller As NationalFramework.Controller.Maintenance.ClientOrderController = Nothing

#End Region

#Region " Properties "

        'Public ReadOnly Property DetailCancelEnabled As Boolean
        '    Get
        '        DetailCancelEnabled = If(_ViewModel IsNot Nothing, _ViewModel.DetailCancelEnabled, False)
        '    End Get
        'End Property
        'Public ReadOnly Property DetailDeleteEnabled As Boolean
        '    Get
        '        DetailDeleteEnabled = If(_ViewModel IsNot Nothing, _ViewModel.DetailDeleteEnabled, False)
        '    End Get
        'End Property

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

                    NumericInputControl_OrderNumber.Properties.AllowNullInput = True
                    NumericInputControl_OrderNumber.SetPropertySettings(NationalFramework.DTO.ClientOrder.Properties.OrderNumber)

                    DateTimePickerControl_OrderDateTime.SetPropertySettings(NationalFramework.DTO.ClientOrder.Properties.OrderDatetime)
                    DateTimePickerControl_LastChangedDateTime.SetPropertySettings(NationalFramework.DTO.ClientOrder.Properties.LastChangedDatetime)

                    TextBoxControl_OrderDuration.SetPropertySettings(NationalFramework.DTO.ClientOrder.Properties.OrderDuration)
                    TextBoxControl_Report.SetPropertySettings(NationalFramework.DTO.ClientOrder.Properties.Report)
                    TextBoxControl_ClientAlias.SetPropertySettings(NationalFramework.DTO.ClientOrder.Properties.ClientAlias)

                    DataGridViewControl_Details.OptionsBehavior.Editable = True
                    DataGridViewControl_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                    DataGridViewControl_Details.CurrentView.OptionsMenu.EnableColumnMenu = False
                    DataGridViewControl_Details.CurrentView.OptionsCustomization.AllowFilter = False
                    DataGridViewControl_Details.MultiSelect = False

                    DataGridViewControl_Details.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If _ViewModel.ClientOrder.ID <> 0 Then

                NumericInputControl_OrderNumber.EditValue = _ViewModel.ClientOrder.OrderNumber
                DateTimePickerControl_OrderDateTime.ValueObject = _ViewModel.ClientOrder.OrderDatetime
                DateTimePickerControl_LastChangedDateTime.ValueObject = _ViewModel.ClientOrder.LastChangedDatetime
                NumericInputControl_StartYear.EditValue = _ViewModel.ClientOrder.StartYear
                NumericInputControl_EndYear.EditValue = _ViewModel.ClientOrder.EndYear
                TextBoxControl_OrderDuration.Text = _ViewModel.ClientOrder.OrderDuration
                TextBoxControl_Report.Text = _ViewModel.ClientOrder.Report
                TextBoxControl_ClientAlias.Text = _ViewModel.ClientOrder.ClientAlias

            End If

            CheckBoxControl_IsSuspended.Checked = _ViewModel.ClientOrder.IsSuspended

            If LoadGrid Then

                DataGridViewControl_Details.DataSource = _ViewModel.ClientOrderDetails
                DataGridViewControl_Details.CurrentView.RefreshData()

            End If

            SetGridColumnHeaders()
            DataGridViewControl_Details.CurrentView.BestFitColumns()

        End Sub

#Region "  Public "

        'Public Sub CancelAddNewDetail()

        '    DataGridViewControl_Details.CancelNewItemRow()

        'End Sub
        Public Function CheckForUnsavedChanges(ByRef ClientOrderViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderViewModel) As Boolean

            'objects
            Dim IsOkay As Boolean = True
            Dim ErrorMessage As String = ""

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validate Then

                        IsOkay = Me.Save(ErrorMessage, _ClientOrderID)

                        If Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Public Sub ClearControl()

            NumericInputControl_OrderNumber.EditValue = Nothing
            DateTimePickerControl_OrderDateTime.ValueObject = Nothing
            DateTimePickerControl_LastChangedDateTime.ValueObject = Nothing

            NumericInputControl_StartYear.EditValue = Nothing
            NumericInputControl_EndYear.EditValue = Nothing

            TextBoxControl_OrderDuration.Text = Nothing
            TextBoxControl_Report.Text = Nothing
            TextBoxControl_ClientAlias.Text = Nothing

            CheckBoxControl_IsSuspended.Checked = False

            DataGridViewControl_Details.ClearDatasource()

        End Sub
        Public Function Delete() As Boolean

            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Deleted = _Controller.Delete(_ViewModel, ErrorMessage)

                If Not Deleted AndAlso Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

            Delete = Deleted

        End Function
        'Public Sub DeleteSelectedDetails()

        '    If DataGridViewControl_Details.HasASelectedRow Then

        '        DataGridViewControl_Details.CurrentView.CloseEditorForUpdating()

        '        _Controller.DeleteSelectedDetails(_ViewModel)

        '        RefreshViewModel(True)

        '        DataGridViewControl_Details.SetUserEntryChanged()

        '        _Controller.DetailSelectionChanged(_ViewModel, DataGridViewControl_Details.IsNewItemRow, DataGridViewControl_Details.GetFirstSelectedRowDataBoundItem)

        '    End If

        'End Sub
        Public Function LoadControl(ConnectionString As String, ClientID As Integer, ClientOrderID As Integer, Optional IsCopy As Boolean = False) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _ConnectionString = ConnectionString
            _ClientID = ClientID
            _ClientOrderID = ClientOrderID

            If _Controller Is Nothing Then

                _Controller = New NationalFramework.Controller.Maintenance.ClientOrderController(_ConnectionString)

            End If

            _ViewModel = _Controller.Load(_ClientID, _ClientOrderID)

            If _ClientOrderID <> 0 Then

                If _ViewModel.ClientOrder Is Nothing Then

                    Loaded = False

                End If

            End If

            If IsCopy Then

                _ClientOrderID = 0

            End If

            DataGridViewControl_Details.Visible = True

            DataGridViewControl_Details.ClearGridCustomization()

            DataGridViewControl_Details.DataSource = _ViewModel.ClientOrderDetails

            DataGridViewControl_Details.CurrentView.BestFitColumns()

            If _ClientOrderID = 0 Then

                NumericInputControl_OrderNumber.EditValue = Nothing
                DateTimePickerControl_OrderDateTime.ValueObject = Nothing
                DateTimePickerControl_LastChangedDateTime.ValueObject = Nothing

            End If

            RefreshViewModel(False)

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Private Sub SaveViewModel()

            DataGridViewControl_Details.CurrentView.CloseEditorForUpdating()

            _ViewModel.ClientOrder.ClientID = _ClientID
            _ViewModel.ClientOrder.OrderNumber = NumericInputControl_OrderNumber.GetValue
            _ViewModel.ClientOrder.OrderDatetime = DateTimePickerControl_OrderDateTime.GetValue
            _ViewModel.ClientOrder.LastChangedDatetime = DateTimePickerControl_LastChangedDateTime.GetValue
            _ViewModel.ClientOrder.StartYear = NumericInputControl_StartYear.GetValue
            _ViewModel.ClientOrder.EndYear = NumericInputControl_EndYear.GetValue
            _ViewModel.ClientOrder.OrderDuration = TextBoxControl_OrderDuration.GetText
            _ViewModel.ClientOrder.Report = TextBoxControl_Report.GetText
            _ViewModel.ClientOrder.ClientAlias = TextBoxControl_ClientAlias.GetText
            _ViewModel.ClientOrder.IsSuspended = CheckBoxControl_IsSuspended.Checked

            _ViewModel.ClientOrderDetails = DataGridViewControl_Details.GetAllRowsDataBoundItems.OfType(Of NationalFramework.DTO.ClientOrderDetail).ToList

        End Sub
        Public Function Save(ByRef ErrorMessage As String, ByRef ClientOrderID As Integer) As Boolean

            'objects
            Dim Saved As Boolean = False

            If Me.HasAtLeastOneMonthChecked Then

                SaveViewModel()

                If _ClientOrderID = 0 Then

                    Saved = _Controller.Add(_ViewModel, ClientOrderID, ErrorMessage)

                Else

                    Saved = _Controller.Update(_ViewModel, ErrorMessage)

                    ClientOrderID = _ClientOrderID

                End If

            Else

                ErrorMessage = "Please check at least one month for one Detail."

            End If

            Save = Saved

        End Function
        Private Function GetCaption(ColumnName As String) As String

            'objects
            Dim Caption As String = Nothing

            If ColumnName = NationalFramework.DTO.ClientOrderDetail.Properties.September.ToString OrElse
                    ColumnName = NationalFramework.DTO.ClientOrderDetail.Properties.October.ToString OrElse
                    ColumnName = NationalFramework.DTO.ClientOrderDetail.Properties.November.ToString OrElse
                    ColumnName = NationalFramework.DTO.ClientOrderDetail.Properties.December.ToString Then

                If NumericInputControl_EndYear.Value - NumericInputControl_StartYear.Value = 1 Then

                    Caption = NumericInputControl_StartYear.Value & vbCrLf & ColumnName

                Else

                    Caption = ColumnName

                End If

            Else

                If NumericInputControl_EndYear.Value - NumericInputControl_StartYear.Value = 1 Then

                    Caption = NumericInputControl_EndYear.Value & vbCrLf & ColumnName

                Else

                    Caption = ColumnName

                End If

            End If

            GetCaption = Caption

        End Function
        Private Sub SetGridColumnHeaders()

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.September.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.September.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.September.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.October.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.October.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.October.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.November.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.November.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.November.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.December.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.December.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.December.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.January.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.January.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.January.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.February.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.February.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.February.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.March.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.March.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.March.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.April.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.April.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.April.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.May.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.May.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.May.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.June.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.June.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.June.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.July.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.July.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.July.ToString)

            End If

            If DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.August.ToString) IsNot Nothing Then

                DataGridViewControl_Details.Columns(NationalFramework.DTO.ClientOrderDetail.Properties.August.ToString).Caption = GetCaption(NationalFramework.DTO.ClientOrderDetail.Properties.August.ToString)

            End If

        End Sub
        Public Function HasAtLeastOneMonthChecked() As Boolean
            HasAtLeastOneMonthChecked = _ViewModel.ClientOrderDetails.Where(Function(COD) COD.HasAtLeastOneMonthChecked = True).Any
        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub ClientOrderControl_Load(sender As Object, e As EventArgs) Handles Me.Load

            NumericInputControl_StartYear.Properties.MinValue = 2010
            NumericInputControl_StartYear.Properties.MaxValue = 2079
            NumericInputControl_StartYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            NumericInputControl_StartYear.SetPropertySettings("Start Year", True)

            NumericInputControl_EndYear.Properties.MinValue = 2010
            NumericInputControl_EndYear.Properties.MaxValue = 2079
            NumericInputControl_EndYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            NumericInputControl_EndYear.SetPropertySettings("End Year", True)

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub CheckBoxControl_IsSuspended_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckBoxControl_IsSuspended.CheckValueChanged

            _Controller.SetIsSuspendedChecked(_ViewModel, CheckBoxControl_IsSuspended.Checked)

            RefreshViewModel(False)

        End Sub
        Private Sub DateTimePickerControl_LastChangedDateTime_Leave(sender As Object, e As EventArgs) Handles DateTimePickerControl_LastChangedDateTime.Leave

            If _ClientOrderID = 0 AndAlso DateTimePickerControl_LastChangedDateTime.Value = #12:00:00 AM# Then

                DateTimePickerControl_LastChangedDateTime.Value = Now.ToString("g")

            End If

        End Sub
        Private Sub DateTimePickerControl_OrderDateTime_Leave(sender As Object, e As EventArgs) Handles DateTimePickerControl_OrderDateTime.Leave

            If _ClientOrderID = 0 AndAlso DateTimePickerControl_OrderDateTime.Value = #12:00:00 AM# Then

                DateTimePickerControl_OrderDateTime.Value = Now.ToString("g")

            End If

        End Sub
        Private Sub NumericInputControl_EndYear_Leave(sender As Object, e As EventArgs) Handles NumericInputControl_EndYear.Leave

            SetGridColumnHeaders()

        End Sub
        Private Sub NumericInputControl_StartYear_Leave(sender As Object, e As EventArgs) Handles NumericInputControl_StartYear.Leave

            SetGridColumnHeaders()

        End Sub

#End Region

#End Region

    End Class

End Namespace
