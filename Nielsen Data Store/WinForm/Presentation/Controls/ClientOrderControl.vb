Namespace WinForm.Presentation.Controls

    Public Class ClientOrderControl

        Public Event MarketInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event MarketSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)

        Public Event StateInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event StateSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _ConnectionString As String = Nothing
        Private _ClientID As Integer = 0
        Private _ClientOrderID As Integer = 0
        Private _OrderType As String = Nothing
        Private _ViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderDetailViewModel = Nothing
        Private _Controller As NielsenFramework.Controller.Maintenance.ClientOrderController = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property MarketCancelEnabled As Boolean
            Get
                MarketCancelEnabled = If(_ViewModel IsNot Nothing, _ViewModel.MarketCancelEnabled, False)
            End Get
        End Property
        Public ReadOnly Property MarketDeleteEnabled As Boolean
            Get
                MarketDeleteEnabled = If(_ViewModel IsNot Nothing, _ViewModel.MarketDeleteEnabled, False)
            End Get
        End Property
        Public ReadOnly Property StateCancelEnabled As Boolean
            Get
                StateCancelEnabled = If(_ViewModel IsNot Nothing, _ViewModel.StateCancelEnabled, False)
            End Get
        End Property
        Public ReadOnly Property StateDeleteEnabled As Boolean
            Get
                StateDeleteEnabled = If(_ViewModel IsNot Nothing, _ViewModel.StateDeleteEnabled, False)
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

                    NumericInputControl_OrderNumber.Properties.AllowNullInput = True
                    NumericInputControl_OrderNumber.SetPropertySettings(NielsenFramework.DTO.ClientOrder.Properties.OrderNumber)

                    TextBoxControl_OrderType.Enabled = False

                    DateTimePickerControl_OrderDateTime.SetPropertySettings(NielsenFramework.DTO.ClientOrder.Properties.OrderDatetime)
                    DateTimePickerControl_LastChangedDateTime.SetPropertySettings(NielsenFramework.DTO.ClientOrder.Properties.LastChangedDatetime)

                    TextBoxControl_OrderDuration.SetPropertySettings(NielsenFramework.DTO.ClientOrder.Properties.OrderDuration)
                    TextBoxControl_Report.SetPropertySettings(NielsenFramework.DTO.ClientOrder.Properties.Report)
                    TextBoxControl_ClientAlias.SetPropertySettings(NielsenFramework.DTO.ClientOrder.Properties.ClientAlias)

                    DataGridViewControl_Markets.OptionsBehavior.Editable = True
                    DataGridViewControl_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                    DataGridViewControl_Markets.CurrentView.OptionsMenu.EnableColumnMenu = False
                    DataGridViewControl_Markets.CurrentView.OptionsCustomization.AllowFilter = False
                    DataGridViewControl_Markets.MultiSelect = False

                    DataGridViewControl_Markets.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

                    DataGridViewControl_States.OptionsBehavior.Editable = True
                    DataGridViewControl_States.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                    DataGridViewControl_States.CurrentView.OptionsMenu.EnableColumnMenu = False
                    DataGridViewControl_States.CurrentView.OptionsCustomization.AllowFilter = False
                    DataGridViewControl_States.MultiSelect = False

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            TextBoxControl_OrderType.Text = _ViewModel.ClientOrder.OrderTypeDescription

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

            CheckBoxControl_AllMarkets.Checked = _ViewModel.ClientOrder.AllMarkets
            CheckBoxControl_AllMarketsCume.Visible = _ViewModel.ClientOrder.AllMarkets AndAlso (_OrderType = "T")
            CheckBoxControl_AllMarketsCume.Checked = _ViewModel.ClientOrder.Cume

            CheckBoxControl_AllStates.Checked = _ViewModel.ClientOrder.AllStates

            DataGridViewControl_Markets.Enabled = Not _ViewModel.ClientOrder.AllMarkets
            DataGridViewControl_States.Enabled = Not _ViewModel.ClientOrder.AllStates

            CheckBoxControl_IsSuspended.Checked = _ViewModel.ClientOrder.IsSuspended

            If LoadGrid Then

                If _ViewModel.ClientOrder.OrderType = "C" Then

                    DataGridViewControl_States.DataSource = _ViewModel.ClientOrderStates
                    DataGridViewControl_States.CurrentView.RefreshData()

                Else

                    DataGridViewControl_Markets.DataSource = _ViewModel.ClientOrderMarkets
                    DataGridViewControl_Markets.CurrentView.RefreshData()

                End If

            End If

            If _ViewModel.ClientOrder.OrderType <> "C" Then

                SetGridColumnHeaders()
                DataGridViewControl_Markets.CurrentView.BestFitColumns()

            End If

            If _ViewModel.ClientOrder.OrderType = "T" Then

                For Each RadioButtonControl In Me.GroupBoxControl_EthnicityOptions.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                    If CShort(RadioButtonControl.Tag) = _ViewModel.ClientOrder.Ethnicity Then

                        RadioButtonControl.Checked = True
                        Exit For

                    End If

                Next

                CheckBoxOption_IsOlympic.Checked = _ViewModel.ClientOrder.IsOlympic

            ElseIf _ViewModel.ClientOrder.OrderType = "R" Then

                For Each RadioButtonControl In Me.GroupBoxControl_RadioEthnicityOptions.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                    If CShort(RadioButtonControl.Tag) = _ViewModel.ClientOrder.Ethnicity Then

                        RadioButtonControl.Checked = True
                        Exit For

                    End If

                Next

                CheckBoxOption_IsOlympic.Checked = False

            Else

                RadioButtonOption_Standard.Checked = True
                CheckBoxOption_IsOlympic.Checked = False

            End If

        End Sub
        Private Sub HideColumns()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If _OrderType = "T" Then

                For Each GridColumn In DataGridViewControl_Markets.Columns

                    If GridColumn.FieldName = NielsenFramework.DTO.ClientOrderMarket.Properties.WinterQuarterly.ToString OrElse
                            GridColumn.FieldName = NielsenFramework.DTO.ClientOrderMarket.Properties.SpringQuarterly.ToString OrElse
                            GridColumn.FieldName = NielsenFramework.DTO.ClientOrderMarket.Properties.SummerQuarterly.ToString OrElse
                            GridColumn.FieldName = NielsenFramework.DTO.ClientOrderMarket.Properties.FallQuarterly.ToString Then

                        GridColumn.Visible = False

                    End If

                Next

            ElseIf _OrderType = "R" Then

                If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.Cume.ToString) IsNot Nothing Then

                    DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.Cume.ToString).Visible = False

                End If

            End If

        End Sub

#Region "  Public "

        Public Sub CancelAddNewMarket()

            DataGridViewControl_Markets.CancelNewItemRow()

        End Sub
        Public Sub CancelAddNewState()

            DataGridViewControl_States.CancelNewItemRow()

        End Sub
        Public Function CheckForUnsavedChanges(ByRef ClientOrderViewModel As NielsenFramework.ViewModels.Maintenance.ClientOrderViewModel) As Boolean

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

            CheckBoxControl_AllMarkets.Checked = False
            CheckBoxControl_IsSuspended.Checked = False

            DataGridViewControl_Markets.ClearDatasource()

            CheckBoxControl_AllStates.Checked = False
            DataGridViewControl_States.ClearDatasource()

            RadioButtonOption_Standard.Checked = True
            CheckBoxOption_IsOlympic.Checked = False

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
        Public Sub DeleteSelectedMarkets()

            If DataGridViewControl_Markets.HasASelectedRow Then

                DataGridViewControl_Markets.CurrentView.CloseEditorForUpdating()

                _Controller.DeleteSelectedMarkets(_ViewModel)

                RefreshViewModel(True)

                DataGridViewControl_Markets.SetUserEntryChanged()

                _Controller.MarketSelectionChanged(_ViewModel, DataGridViewControl_Markets.IsNewItemRow, DataGridViewControl_Markets.GetFirstSelectedRowDataBoundItem)

            End If

        End Sub
        Public Sub DeleteSelectedStates()

            If DataGridViewControl_States.HasASelectedRow Then

                DataGridViewControl_States.CurrentView.CloseEditorForUpdating()

                _Controller.DeleteSelectedStates(_ViewModel)

                RefreshViewModel(True)

                DataGridViewControl_States.SetUserEntryChanged()

                _Controller.StateSelectionChanged(_ViewModel, DataGridViewControl_States.IsNewItemRow, DataGridViewControl_States.GetFirstSelectedRowDataBoundItem)

            End If

        End Sub
        Public Function LoadControl(ConnectionString As String, ClientID As Integer, OrderType As String, ClientOrderID As Integer, Optional IsCopy As Boolean = False) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _ConnectionString = ConnectionString
            _ClientID = ClientID
            _OrderType = OrderType
            _ClientOrderID = ClientOrderID

            If _Controller Is Nothing Then

                _Controller = New NielsenFramework.Controller.Maintenance.ClientOrderController(_ConnectionString)

            End If

            _ViewModel = _Controller.Load(_ClientID, _OrderType, _ClientOrderID)

            If _ClientOrderID <> 0 Then

                If _ViewModel.ClientOrder Is Nothing Then

                    Loaded = False

                End If

            End If

            If IsCopy Then

                _ClientOrderID = 0

            End If

            CheckBoxControl_AllMarkets.AutoCheck = True
            CheckBoxControl_AllMarkets.Checked = False

            CheckBoxControl_AllMarkets.Visible = True
            DataGridViewControl_Markets.Visible = True

            CheckBoxControl_AllStates.Visible = True
            DataGridViewControl_States.Visible = True

            If _ViewModel.ClientOrder.OrderType = "N" Then

                CheckBoxControl_AllMarkets.AutoCheck = False
                CheckBoxControl_AllMarkets.Checked = True

            End If

            If _OrderType = "C" Then

                CheckBoxControl_AllMarkets.Visible = False
                DataGridViewControl_Markets.Visible = False

                DataGridViewControl_States.ClearGridCustomization()

                DataGridViewControl_States.DataSource = _ViewModel.ClientOrderStates

                DataGridViewControl_States.CurrentView.BestFitColumns()

                If DataGridViewControl_States.Columns(NielsenFramework.DTO.ClientOrderState.Properties.State.ToString) IsNot Nothing Then

                    DataGridViewControl_States.Columns(NielsenFramework.DTO.ClientOrderState.Properties.State.ToString).Width = 300

                End If

            Else

                CheckBoxControl_AllStates.Visible = False
                DataGridViewControl_States.Visible = False

                DataGridViewControl_Markets.ClearGridCustomization()

                DataGridViewControl_Markets.DataSource = _ViewModel.ClientOrderMarkets

                HideColumns()

                DataGridViewControl_Markets.CurrentView.BestFitColumns()

            End If

            If _ClientOrderID = 0 Then

                NumericInputControl_OrderNumber.EditValue = Nothing
                DateTimePickerControl_OrderDateTime.ValueObject = Nothing
                DateTimePickerControl_LastChangedDateTime.ValueObject = Nothing

            End If

            GroupBoxControl_EthnicityOptions.Visible = (_ViewModel.ClientOrder.OrderType = "T")
            GroupBoxControl_RadioEthnicityOptions.Visible = (_ViewModel.ClientOrder.OrderType = "R")

            RefreshViewModel(False)

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Private Function GetRadioEthnicity() As Short

            Dim RadioEthnicity As Short = 0

            For Each RadioButtonControl In Me.GroupBoxControl_RadioEthnicityOptions.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked Then

                    RadioEthnicity = CShort(RadioButtonControl.Tag)

                    Exit For

                End If

            Next

            GetRadioEthnicity = RadioEthnicity

        End Function
        Private Sub SaveViewModel()

            DataGridViewControl_Markets.CurrentView.CloseEditorForUpdating()
            DataGridViewControl_States.CurrentView.CloseEditorForUpdating()

            _ViewModel.ClientOrder.ClientID = _ClientID
            _ViewModel.ClientOrder.OrderNumber = NumericInputControl_OrderNumber.GetValue
            _ViewModel.ClientOrder.OrderType = _OrderType
            _ViewModel.ClientOrder.OrderDatetime = DateTimePickerControl_OrderDateTime.GetValue
            _ViewModel.ClientOrder.LastChangedDatetime = DateTimePickerControl_LastChangedDateTime.GetValue
            _ViewModel.ClientOrder.StartYear = NumericInputControl_StartYear.GetValue
            _ViewModel.ClientOrder.EndYear = NumericInputControl_EndYear.GetValue
            _ViewModel.ClientOrder.OrderDuration = TextBoxControl_OrderDuration.GetText
            _ViewModel.ClientOrder.Report = TextBoxControl_Report.GetText
            _ViewModel.ClientOrder.ClientAlias = TextBoxControl_ClientAlias.GetText
            _ViewModel.ClientOrder.AllMarkets = CheckBoxControl_AllMarkets.Checked
            _ViewModel.ClientOrder.IsSuspended = CheckBoxControl_IsSuspended.Checked

            _ViewModel.ClientOrderMarkets = DataGridViewControl_Markets.GetAllRowsDataBoundItems.OfType(Of NielsenFramework.DTO.ClientOrderMarket).ToList

            _ViewModel.ClientOrder.AllStates = CheckBoxControl_AllStates.Checked

            _ViewModel.ClientOrderStates = DataGridViewControl_States.GetAllRowsDataBoundItems.OfType(Of NielsenFramework.DTO.ClientOrderState).ToList

            If _ViewModel.ClientOrder.OrderType = "T" Then

                For Each RadioButtonControl In Me.GroupBoxControl_EthnicityOptions.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                    If RadioButtonControl.Checked Then

                        _ViewModel.ClientOrder.Ethnicity = CShort(RadioButtonControl.Tag)

                        Exit For

                    End If

                Next

                _ViewModel.ClientOrder.IsOlympic = CheckBoxOption_IsOlympic.Checked

            ElseIf _ViewModel.ClientOrder.OrderType = "R" Then

                _ViewModel.ClientOrder.Ethnicity = GetRadioEthnicity()

                _ViewModel.ClientOrder.IsOlympic = False

            Else

                _ViewModel.ClientOrder.IsOlympic = False

            End If

        End Sub
        Public Function Save(ByRef ErrorMessage As String, ByRef ClientOrderID As Integer) As Boolean

            'objects
            Dim Saved As Boolean = False

            SaveViewModel()

            If _ClientOrderID = 0 Then

                Saved = _Controller.Add(_ViewModel, ClientOrderID, ErrorMessage)

            Else

                Saved = _Controller.Update(_ViewModel, ErrorMessage)

                ClientOrderID = _ClientOrderID

            End If

            Save = Saved

        End Function
        Private Function GetCaption(ColumnName As String) As String

            'objects
            Dim Caption As String = Nothing

            If ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.September.ToString OrElse
                    ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.October.ToString OrElse
                    ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.November.ToString OrElse
                    ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.December.ToString OrElse
                    ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.FallQuarterly.ToString Then

                If NumericInputControl_EndYear.Value - NumericInputControl_StartYear.Value = 1 Then

                    Caption = NumericInputControl_StartYear.Value & vbCrLf & IIf(ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.FallQuarterly.ToString, "Fall Quarterly (Oct)", ColumnName)

                Else

                    Caption = IIf(ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.FallQuarterly.ToString, "Fall Quarterly (Oct)", ColumnName)

                End If

            ElseIf ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.SpringQuarterly.ToString Then

                If NumericInputControl_EndYear.Value - NumericInputControl_StartYear.Value = 1 Then

                    Caption = NumericInputControl_EndYear.Value & vbCrLf & IIf(ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.SpringQuarterly.ToString, "Spring Quarterly (Apr)", ColumnName)

                Else

                    Caption = IIf(ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.SpringQuarterly.ToString, "Spring Quarterly (Apr)", ColumnName)

                End If

            ElseIf ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.SummerQuarterly.ToString Then

                If NumericInputControl_EndYear.Value - NumericInputControl_StartYear.Value = 1 Then

                    Caption = NumericInputControl_EndYear.Value & vbCrLf & IIf(ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.SummerQuarterly.ToString, "Summer Quarterly (Jul)", ColumnName)

                Else

                    Caption = IIf(ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.SummerQuarterly.ToString, "Summer Quarterly (Jul)", ColumnName)

                End If

            ElseIf ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.WinterQuarterly.ToString Then

                If NumericInputControl_EndYear.Value - NumericInputControl_StartYear.Value = 1 Then

                    Caption = NumericInputControl_EndYear.Value & vbCrLf & IIf(ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.WinterQuarterly.ToString, "Winter Quarterly (Jan)", ColumnName)

                Else

                    Caption = IIf(ColumnName = NielsenFramework.DTO.ClientOrderMarket.Properties.WinterQuarterly.ToString, "Winter Quarterly (Jan)", ColumnName)

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

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.September.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.September.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.September.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.October.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.October.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.October.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.November.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.November.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.November.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.December.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.December.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.December.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.January.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.January.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.January.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.February.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.February.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.February.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.March.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.March.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.March.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.April.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.April.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.April.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.May.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.May.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.May.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.June.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.June.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.June.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.July.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.July.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.July.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.August.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.August.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.August.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.FallQuarterly.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.FallQuarterly.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.FallQuarterly.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.WinterQuarterly.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.WinterQuarterly.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.WinterQuarterly.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.SpringQuarterly.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.SpringQuarterly.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.SpringQuarterly.ToString)

            End If

            If DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.SummerQuarterly.ToString) IsNot Nothing Then

                DataGridViewControl_Markets.Columns(NielsenFramework.DTO.ClientOrderMarket.Properties.SummerQuarterly.ToString).Caption = GetCaption(NielsenFramework.DTO.ClientOrderMarket.Properties.SummerQuarterly.ToString)

            End If

        End Sub

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

        Private Sub CheckBoxControl_AllMarkets_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckBoxControl_AllMarkets.CheckValueChanged

            _Controller.SetAllMarketsChecked(_ViewModel, CheckBoxControl_AllMarkets.Checked)

            RefreshViewModel(True)

        End Sub
        Private Sub CheckBoxControl_AllMarketsCume_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckBoxControl_AllMarketsCume.CheckValueChanged

            _Controller.SetAllMarketsCumeChecked(_ViewModel, CheckBoxControl_AllMarketsCume.Checked)

            RefreshViewModel(True)

        End Sub
        Private Sub CheckBoxControl_IsSuspended_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckBoxControl_IsSuspended.CheckValueChanged

            _Controller.SetIsSuspendedChecked(_ViewModel, CheckBoxControl_IsSuspended.Checked)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewControl_Markets_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewControl_Markets.FocusedRowChangedEvent

            _Controller.MarketSelectionChanged(_ViewModel, DataGridViewControl_Markets.IsNewItemRow, DataGridViewControl_Markets.GetFirstSelectedRowDataBoundItem)

            RaiseEvent MarketSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_Markets_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_Markets.InitNewRowEvent

            RaiseEvent MarketInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_Markets_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_Markets.QueryPopupNeedDatasourceEvent

            Dim RadioEthnicity As Short = 0

            If FieldName = NielsenFramework.DTO.ClientOrderMarket.Properties.MarketNumber.ToString Then

                If _OrderType = "R" Then

                    RadioEthnicity = GetRadioEthnicity()

                End If

                Datasource = _Controller.GetAvailableMarkets(_OrderType, _ViewModel, RadioEthnicity)

                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewControl_Markets_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewControl_Markets.RepositoryDataSourceLoadingEvent

            If FieldName = NielsenFramework.DTO.ClientOrderMarket.Properties.MarketNumber.ToString Then

                Datasource = _ViewModel.RepositoryAvailableMarkets

            End If

        End Sub
        Private Sub DataGridViewControl_Markets_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewControl_Markets.ShowingEditorEvent

            If DataGridViewControl_Markets.HasOnlyOneSelectedRow AndAlso Not DataGridViewControl_Markets.IsNewItemRow(DataGridViewControl_Markets.CurrentView.FocusedRowHandle) AndAlso
                    DataGridViewControl_Markets.CurrentView.FocusedColumn.FieldName = NielsenFramework.DTO.ClientOrderMarket.Properties.MarketNumber.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewControl_Markets_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewControl_Markets.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ClientOrderMarketValidateEntity(e.Row, e.Valid)

                If DataGridViewControl_Markets.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    If e.Valid Then

                        RefreshViewModel(True)

                        DataGridViewControl_Markets.SetUserEntryChanged()

                        RaiseEvent MarketSelectionChangedEvent(sender, e)

                    Else

                        DataGridViewControl_Markets.CurrentView.NewItemRowText = e.ErrorText

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_Markets_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewControl_Markets.ValidatingEditorEvent

            Dim FocusedRow As NielsenFramework.DTO.ClientOrderMarket = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewControl_Markets.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(_ViewModel, FocusedRow, DataGridViewControl_Markets.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewControl_Markets.CurrentView.SetColumnError(DataGridViewControl_Markets.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

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
        Private Sub DataGridViewControl_States_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewControl_States.FocusedRowChangedEvent

            _Controller.StateSelectionChanged(_ViewModel, DataGridViewControl_States.IsNewItemRow, DataGridViewControl_States.GetFirstSelectedRowDataBoundItem)

            RaiseEvent StateSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_States_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_States.InitNewRowEvent

            RaiseEvent StateInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_States_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_States.QueryPopupNeedDatasourceEvent

            If FieldName = NielsenFramework.DTO.ClientOrderState.Properties.State.ToString Then

                Datasource = _Controller.GetAvailableStates(_OrderType, _ViewModel)

                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewControl_States_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewControl_States.RepositoryDataSourceLoadingEvent

            If FieldName = NielsenFramework.DTO.ClientOrderState.Properties.State.ToString Then

                Datasource = _ViewModel.RepositoryAvailableStates

            End If

        End Sub
        Private Sub DataGridViewControl_States_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewControl_States.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ClientOrderStateValidateEntity(e.Row, e.Valid)

                If DataGridViewControl_States.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    If e.Valid Then

                        RefreshViewModel(True)

                        DataGridViewControl_States.SetUserEntryChanged()

                        RaiseEvent StateSelectionChangedEvent(sender, e)

                    Else

                        DataGridViewControl_States.CurrentView.NewItemRowText = e.ErrorText

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_States_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewControl_States.ShowingEditorEvent

            If DataGridViewControl_States.HasOnlyOneSelectedRow AndAlso Not DataGridViewControl_States.IsNewItemRow(DataGridViewControl_States.CurrentView.FocusedRowHandle) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub CheckBoxControl_AllStates_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckBoxControl_AllStates.CheckValueChanged

            _Controller.SetAllStatesChecked(_ViewModel, CheckBoxControl_AllStates.Checked)

            RefreshViewModel(True)

        End Sub
        Private Sub DataGridViewControl_States_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewControl_States.ValidatingEditorEvent

            Dim FocusedRow As NielsenFramework.DTO.ClientOrderState = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewControl_States.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                e.Valid = True

            End If

        End Sub
        Private Sub RadioButtonOption_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonOption_RadioBlack.CheckedChangedEx,
                RadioButtonOption_RadioHispanic.CheckedChangedEx,
                RadioButtonOption_RadioStandard.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                _Controller.SetRadioEthnicity(_ViewModel, GetRadioEthnicity)

                RefreshViewModel(True)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
