Namespace Reporting.Presentation

    Public Class GLCrossOfficeInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing
        Private _ReportType As AdvantageFramework.Reporting.ReportTypes = ReportTypes.SalesJournal
        Private _ShowReportOption As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property
        Private ReadOnly Property ReportType As AdvantageFramework.Reporting.ReportTypes
            Get
                ReportType = _ReportType
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByVal ReportType As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _ReportType = ReportType
            _DynamicReport = DynamicReport
            _ShowReportOption = ShowReportOption

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim GLCrossOfficeInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.GLCrossOfficeInitialLoadingDialog = Nothing

            GLCrossOfficeInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.GLCrossOfficeInitialLoadingDialog(DynamicReport, ShowReportOption, ReportType, ParameterDictionary)

            ShowFormDialog = GLCrossOfficeInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = GLCrossOfficeInitialLoadingDialog.ParameterDictionary
                ReportType = GLCrossOfficeInitialLoadingDialog.ReportType

            End If

        End Function

        Private Sub EnableOrDisableActions()

            If _ShowReportOption Then

                If ComboBoxTopSection_Report.HasASelectedValue Then

                    '    If CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournal Then

                    '        Me.RadioButtonControl_ARPostPeriod.Visible = False
                    '        Me.RadioButtonControl_SalesPostPeriod.Visible = False
                    '        Me.Label1.Visible = False

                    '    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournalExpanded Then

                    '        Me.RadioButtonControl_ARPostPeriod.Visible = False
                    '        Me.RadioButtonControl_SalesPostPeriod.Visible = False
                    '        Me.Label1.Visible = False

                    '    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournalSummaryByInvoice Then

                    '        Me.RadioButtonControl_ARPostPeriod.Visible = True
                    '        Me.RadioButtonControl_SalesPostPeriod.Visible = True
                    '        Me.Label1.Visible = True

                    '    End If

                Else


                End If

            End If

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MonthEndProductionWIPInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ComboBoxForm_EndPostPeriod.SetRequired(True)

            'ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.GLCrossOfficeReportSeries)).OrderBy(Function(EnumObject) EnumObject.Code).ToList

            PanelForm_TopSection.Visible = _ShowReportOption

            If _ShowReportOption Then

                ComboBoxTopSection_Report.SetRequired(True)
                ComboBoxTopSection_Report.DisplayName = "Report"

            Else


            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_StartPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                Try

                    ComboBoxForm_StartPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception
                    ComboBoxForm_StartPostPeriod.SelectedValue = Nothing
                End Try

            End Using


            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_EndPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                Try

                    ComboBoxForm_EndPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception
                    ComboBoxForm_EndPostPeriod.SelectedValue = Nothing
                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then



            End If

            'CDPChooserControlSelectClients_SelectClients.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing
            Dim SelectedCodesList As Generic.List(Of String) = Nothing

            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                If _ShowReportOption Then

                    _ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

                Else

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.GLCrossOfficeParameters.StartPeriod.ToString) = ComboBoxForm_StartPostPeriod.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.GLCrossOfficeParameters.EndPeriod.ToString) = ComboBoxForm_EndPostPeriod.SelectedValue

                If _ShowReportOption = True Then

                Else

                End If

                'If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_AllClients.Checked Then

                '    ClientCodeList = Nothing
                '    DivisionCodeList = Nothing
                '    ProductCodeList = Nothing

                'Else

                '    If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClients.Checked Then

                '        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ClientCodeList

                '        ClientCodeList = SelectedCodesList
                '        DivisionCodeList = Nothing
                '        ProductCodeList = Nothing

                '    ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisions.Checked Then

                '        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.DivisionCodeList

                '        ClientCodeList = Nothing
                '        DivisionCodeList = SelectedCodesList
                '        ProductCodeList = Nothing

                '    ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                '        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ProductCodeList

                '        ClientCodeList = Nothing
                '        DivisionCodeList = Nothing
                '        ProductCodeList = SelectedCodesList

                '    End If

                'End If

                '_ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.SelectedClients.ToString) = ClientCodeList
                '_ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.SelectedDivisions.ToString) = DivisionCodeList
                '_ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.SelectedProducts.ToString) = ProductCodeList

                'If RadioButtonSelectOffices_AllOffices.Checked Then

                '    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.SelectedOffices.ToString) = Nothing

                'Else

                '    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                'End If

                '_ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.AgingDate.ToString) = DateTimePickerAgingDate.Value
                '_ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.AgingOption.ToString) = If(RadioButtonForm_Invoice.Checked, 1, 2)

                'If CInt(ComboBoxTopSection_Report.SelectedValue) = AdvantageFramework.Reporting.MonthEndReportTypesAccountsReceivable.AccountsReceivableAgedwithDisbursementDetail Then
                '    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.IncludeDetails.ToString) = 1
                'Else
                '    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.IncludeDetails.ToString) = 0
                'End If

                If _ShowReportOption Then

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                Else

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

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
        Private Sub ComboBoxTopSection_Report_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxTopSection_Report.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso _ShowReportOption Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                    PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, CurrentPostPeriod.Year)

                    Try

                        ComboBoxForm_StartPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), PostPeriod.Year.ToString).Code

                    Catch ex As Exception
                        ComboBoxForm_StartPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_EndPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                    Try

                        ComboBoxForm_StartPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_StartPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_EndPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_1Year.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Month As Integer = 0
            Dim Year As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                    If CurrentPostPeriod IsNot Nothing Then

                        Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
                        Year = CInt(CurrentPostPeriod.Year) - 1

                    End If

                    Try

                        ComboBoxForm_StartPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code

                    Catch ex As Exception
                        ComboBoxForm_StartPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_EndPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_2Years.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Month As Integer = 0
            Dim Year As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                    If CurrentPostPeriod IsNot Nothing Then

                        Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
                        Year = CInt(CurrentPostPeriod.Year) - 2

                    End If

                    Try

                        ComboBoxForm_StartPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code

                    Catch ex As Exception
                        ComboBoxForm_StartPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_EndPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub

        'Private Sub RadioButtonSelectOffices_AllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '    If Me.FormShown Then

        '        If RadioButtonSelectOffices_AllOffices.Checked Then

        '            DataGridViewSelectOffices_Offices.Enabled = False

        '        End If

        '    End If

        'End Sub
        'Private Sub RadioButtonSelectOffices_ChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        '    If Me.FormShown Then

        '        If RadioButtonSelectOffices_ChooseOffices.Checked Then

        '            If DataGridViewSelectOffices_Offices.HasRows = False Then

        '                LoadOffices()

        '            End If

        '            DataGridViewSelectOffices_Offices.Enabled = True

        '        End If

        '    End If

        'End Sub

        'Private Sub ComboBoxTopSection_ReportSeries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxTopSection_ReportSeries.SelectedIndexChanged
        '    If ComboBoxTopSection_ReportSeries.SelectedValue = 1 Then
        '        ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.MonthEndReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

        '        LabelForm_AgingDate.Visible = False
        '        LabelForm_AgingOption.Visible = False
        '        DateTimePickerAgingDate.Visible = False
        '        RadioButtonForm_Invoice.Visible = False
        '        RadioButtonForm_InvoiceDueDate.Visible = False

        '        TabItemJDA_SelectClientsTab.Visible = True
        '        Label1.Visible = True
        '        GroupBox1.Visible = True

        '    End If
        '    If ComboBoxTopSection_ReportSeries.SelectedValue = 4 Then
        '        ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.MonthEndReportTypesAccountsReceivable)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

        '        LabelForm_AgingDate.Visible = True
        '        LabelForm_AgingOption.Visible = True
        '        DateTimePickerAgingDate.Visible = True
        '        RadioButtonForm_Invoice.Visible = True
        '        RadioButtonForm_InvoiceDueDate.Visible = True

        '        TabItemJDA_SelectClientsTab.Visible = False
        '        Label1.Visible = False
        '        GroupBox1.Visible = False

        '    End If
        'End Sub


#End Region

#End Region

    End Class

End Namespace
