Namespace WinForm.Presentation.Controls

    Public Class BroadcastInvoiceControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get

                Dim EntryChanged As Boolean = False

                If _ByPassUserEntryChanged = False Then

                    For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                        If Control.UserEntryChanged Then

                            EntryChanged = True
                            Exit For

                        End If

                    Next

                End If

                UserEntryChanged = EntryChanged

            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)

                For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.ByPassUserEntryChanged = value

                Next

                _ByPassUserEntryChanged = value

            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)

                For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.SuspendedForLoading = value

                Next

                _SuspendedForLoading = value

            End Set
        End Property
        Public ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = GetParameterDictionary()
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub LoadControl()

            Me.SuspendLayout()

            EnableOrDisableActions()

            Me.ResumeLayout()

        End Sub
        Private Function GetParameterDictionary() As Generic.Dictionary(Of String, Object)

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim SelectedCodesList As Generic.List(Of String) = Nothing
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing

            ParameterDictionary = New Generic.Dictionary(Of String, Object)

            If CheckBoxForm_Radio.Checked OrElse CheckBoxForm_TV.Checked Then

                If ParameterDictionary Is Nothing Then

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartPeriod.ToString) = CInt(CStr(NumericInputForm_YearFrom.EditValue) & AdvantageFramework.StringUtilities.PadWithCharacter(CStr(ComboBoxForm_MonthFrom.SelectedValue), 2, "0", True, True))
                ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndPeriod.ToString) = CInt(CStr(NumericInputForm_YearTo.EditValue) & AdvantageFramework.StringUtilities.PadWithCharacter(CStr(ComboBoxForm_MonthTo.SelectedValue), 2, "0", True, True))

                ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeRadio.ToString) = CheckBoxForm_Radio.Checked
                ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeTV.ToString) = CheckBoxForm_TV.Checked

                If RadioButtonForm_OpenAndClosedOrders.Checked Then

                    ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.OrderStatus.ToString) = 1

                ElseIf RadioButtonForm_OpenOrdersOnly.Checked Then

                    ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.OrderStatus.ToString) = 2

                End If

                If RadioButtonSelectOffices_AllOffices.Checked Then

                    ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.SelectedOffices.ToString) = Nothing

                Else

                    ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                End If

                If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_AllClients.Checked Then

                    ClientCodeList = Nothing
                    DivisionCodeList = Nothing
                    ProductCodeList = Nothing

                Else

                    If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClients.Checked Then

                        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ClientCodeList

                        ClientCodeList = SelectedCodesList
                        DivisionCodeList = Nothing
                        ProductCodeList = Nothing

                    ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisions.Checked Then

                        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.DivisionCodeList

                        ClientCodeList = Nothing
                        DivisionCodeList = SelectedCodesList
                        ProductCodeList = Nothing

                    ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ProductCodeList

                        ClientCodeList = Nothing
                        DivisionCodeList = Nothing
                        ProductCodeList = SelectedCodesList

                    End If

                End If

                ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.SelectedClients.ToString) = ClientCodeList
                ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.SelectedDivisions.ToString) = DivisionCodeList
                ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.SelectedProducts.ToString) = ProductCodeList

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select at least one media type.")

            End If

            GetParameterDictionary = ParameterDictionary

        End Function
        Private Sub EnableOrDisableActions()


        End Sub
        Public Function ValidateControl(ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = True

            If CheckBoxForm_Radio.Checked = False AndAlso CheckBoxForm_TV.Checked = False Then

                IsValid = False
                ErrorMessage = "Please select at least one media type."

            End If

            ValidateControl = IsValid

        End Function
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Control Event Handlers "

        Private Sub BroadcastInvoiceControl_Load(sender As Object, e As EventArgs) Handles Me.Load

            ComboBoxForm_MonthFrom.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))
            ComboBoxForm_MonthTo.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))

            NumericInputForm_YearFrom.Properties.MinValue = 1980
            NumericInputForm_YearFrom.Properties.MaxValue = 2078
            NumericInputForm_YearFrom.Properties.MaxLength = 4
            NumericInputForm_YearFrom.SetPropertySettings(DisplayName:="Year From")
            NumericInputForm_YearFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

            NumericInputForm_YearTo.Properties.MinValue = 1980
            NumericInputForm_YearTo.Properties.MaxValue = 2078
            NumericInputForm_YearTo.Properties.MaxLength = 4
            NumericInputForm_YearTo.SetPropertySettings(DisplayName:="Year To")
            NumericInputForm_YearTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

            ComboBoxForm_MonthFrom.SelectedIndex = Now.Month - 1
            ComboBoxForm_MonthTo.SelectedIndex = Now.Month - 1

            ComboBoxForm_MonthFrom.SetRequired(True)
            ComboBoxForm_MonthTo.SetRequired(True)

            NumericInputForm_YearFrom.Value = Now.Year
            NumericInputForm_YearTo.Value = Now.Year

            NumericInputForm_YearFrom.SetRequired(True)
            NumericInputForm_YearTo.SetRequired(True)

            CheckBoxForm_Radio.Checked = True
            CheckBoxForm_TV.Checked = True

            RadioButtonForm_OpenAndClosedOrders.Checked = True
            RadioButtonForm_OpenOrdersOnly.Checked = False

            'If _ParameterDictionary IsNot Nothing Then

            '    ComboBoxForm_MonthFrom.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartMonth.ToString)
            '    NumericInputForm_YearFrom.EditValue = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartYear.ToString)
            '    ComboBoxForm_MonthTo.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndMonth.ToString)
            '    NumericInputForm_YearTo.EditValue = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndYear.ToString)

            '    CheckBoxForm_Radio.Checked = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeRadio.ToString)
            '    CheckBoxForm_TV.Checked = _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeTV.ToString)

            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartMonth.ToString) = ComboBoxForm_MonthFrom.SelectedValue
            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartYear.ToString) = NumericInputForm_YearFrom.EditValue
            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndMonth.ToString) = ComboBoxForm_MonthTo.SelectedValue
            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndYear.ToString) = NumericInputForm_YearTo.EditValue

            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeRadio.ToString) = CheckBoxForm_Radio.Checked
            '    _ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.IncludeTV.ToString) = CheckBoxForm_TV.Checked

            'End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub RadioButtonSelectOffices_AllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_AllOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_AllOffices.Checked Then

                    DataGridViewSelectOffices_Offices.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectOffices_ChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_ChooseOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_ChooseOffices.Checked Then

                    If DataGridViewSelectOffices_Offices.HasRows = False Then

                        LoadOffices()

                    End If

                    DataGridViewSelectOffices_Offices.Enabled = True

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
