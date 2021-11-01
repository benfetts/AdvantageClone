Namespace Reporting.Presentation

    Public Class MediaResultsComparisonInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport

        End Sub
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub SaveReportSettings()

            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "REPORT_MEDIACOMPCLIENTTYPE")
                              Where Item.Name = "IncludeVendor"
                              Select Item).SingleOrDefault

                    If AppVar IsNot Nothing Then

                        AppVar.Value = IIf(CheckBoxForm_Vendor.Checked, True, False)
                        AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    Else
                        AppVar = New AdvantageFramework.Database.Entities.AppVars
                        AppVar.DbContext = DbContext
                        AppVar.Application = "REPORT_MEDIACOMPCLIENTTYPE"
                        AppVar.UserCode = Me.Session.UserCode
                        AppVar.Group = "0"
                        AppVar.Name = "IncludeVendor"
                        AppVar.Value = IIf(CheckBoxForm_Vendor.Checked, True, False)
                        AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    End If

                    AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "REPORT_MEDIACOMPCLIENTTYPE")
                              Where Item.Name = "IncludePeriod"
                              Select Item).SingleOrDefault

                    If AppVar IsNot Nothing Then

                        AppVar.Value = IIf(CheckBoxForm_Period.Checked, True, False)
                        AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    Else

                        AppVar = New AdvantageFramework.Database.Entities.AppVars
                        AppVar.DbContext = DbContext
                        AppVar.Application = "REPORT_MEDIACOMPCLIENTTYPE"
                        AppVar.UserCode = Me.Session.UserCode
                        AppVar.Group = "0"
                        AppVar.Name = "IncludePeriod"
                        AppVar.Value = IIf(CheckBoxForm_Period.Checked, True, False)
                        AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    End If

                    AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "REPORT_MEDIACOMPCLIENTTYPE")
                              Where Item.Name = "IncludeSalesClass"
                              Select Item).SingleOrDefault

                    If AppVar IsNot Nothing Then

                        AppVar.Value = IIf(CheckBoxForm_SalesClass.Checked, True, False)
                        AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    Else

                        AppVar = New AdvantageFramework.Database.Entities.AppVars
                        AppVar.DbContext = DbContext
                        AppVar.Application = "REPORT_MEDIACOMPCLIENTTYPE"
                        AppVar.UserCode = Me.Session.UserCode
                        AppVar.Group = "0"
                        AppVar.Name = "IncludeSalesClass"
                        AppVar.Value = IIf(CheckBoxForm_SalesClass.Checked, True, False)
                        AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    End If

                    AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "REPORT_MEDIACOMPCLIENTTYPE")
                              Where Item.Name = "IncludeAdNumber"
                              Select Item).SingleOrDefault

                    If AppVar IsNot Nothing Then

                        AppVar.Value = IIf(CheckBoxForm_AdNumber.Checked, True, False)
                        AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    Else

                        AppVar = New AdvantageFramework.Database.Entities.AppVars
                        AppVar.DbContext = DbContext
                        AppVar.Application = "REPORT_MEDIACOMPCLIENTTYPE"
                        AppVar.UserCode = Me.Session.UserCode
                        AppVar.Group = "0"
                        AppVar.Name = "IncludeAdNumber"
                        AppVar.Value = IIf(CheckBoxForm_AdNumber.Checked, True, False)
                        AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    End If

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadReportSettings()

            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "REPORT_MEDIACOMPCLIENTTYPE")
                              Where Item.Name = "IncludeVendor"
                              Select Item).SingleOrDefault

                    If AppVar IsNot Nothing Then

                        If AppVar.Value = "True" Then
                            CheckBoxForm_Vendor.Checked = True
                        End If
                        If AppVar.Value = "False" Then
                            CheckBoxForm_Vendor.Checked = False
                        End If

                    End If

                    AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "REPORT_MEDIACOMPCLIENTTYPE")
                              Where Item.Name = "IncludePeriod"
                              Select Item).SingleOrDefault

                    If AppVar IsNot Nothing Then

                        If AppVar.Value = "True" Then
                            CheckBoxForm_Period.Checked = True
                        End If
                        If AppVar.Value = "False" Then
                            CheckBoxForm_Period.Checked = False
                        End If

                    End If

                    AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "REPORT_MEDIACOMPCLIENTTYPE")
                              Where Item.Name = "IncludeSalesClass"
                              Select Item).SingleOrDefault

                    If AppVar IsNot Nothing Then

                        If AppVar.Value = "True" Then
                            CheckBoxForm_SalesClass.Checked = True
                        End If
                        If AppVar.Value = "False" Then
                            CheckBoxForm_SalesClass.Checked = False
                        End If

                    End If

                    AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "REPORT_MEDIACOMPCLIENTTYPE")
                              Where Item.Name = "IncludeAdNumber"
                              Select Item).SingleOrDefault

                    If AppVar IsNot Nothing Then

                        If AppVar.Value = "True" Then
                            CheckBoxForm_AdNumber.Checked = True
                        End If
                        If AppVar.Value = "False" Then
                            CheckBoxForm_AdNumber.Checked = False
                        End If

                    End If

                End Using

            Catch ex As Exception

            End Try

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim MediaResultsComparisonInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.MediaResultsComparisonInitialLoadingDialog = Nothing

            MediaResultsComparisonInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.MediaResultsComparisonInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = MediaResultsComparisonInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = MediaResultsComparisonInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaResultsComparisonInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

            CheckBoxForm_Vendor.Checked = True
            CheckBoxForm_Period.Checked = True
            CheckBoxForm_SalesClass.Checked = True
            CheckBoxForm_AdNumber.Checked = True

            LoadReportSettings()

        End Sub
        Private Sub MediaResultsComparisonInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            CDPChooserControlSelectClients_SelectClients.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim SelectedCodesList As Generic.List(Of String) = Nothing
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                SaveReportSettings()

                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.StartDate.ToString) = DateSerial(NumericInputForm_YearFrom.GetValue, ComboBoxForm_MonthFrom.GetSelectedValue, 1)
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.EndDate.ToString) = DateSerial(NumericInputForm_YearTo.GetValue, ComboBoxForm_MonthTo.GetSelectedValue + 1, 0)
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludeVendor.ToString) = CheckBoxForm_Vendor.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludeSalesClass.ToString) = CheckBoxForm_SalesClass.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludePeriod.ToString) = CheckBoxForm_Period.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludeAdNumber.ToString) = CheckBoxForm_AdNumber.Checked

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

                If RadioButtonSelectOffices_AllOffices.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.SelectedOffices.ToString) = Nothing
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                End If

                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.SelectedClients.ToString) = ClientCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.SelectedDivisions.ToString) = DivisionCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.SelectedProducts.ToString) = ProductCodeList


                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
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
