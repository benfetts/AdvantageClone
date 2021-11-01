Namespace Reporting.Presentation

    Public Class SalesJournalInitialLoadingDialog

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
            Dim SalesJournalInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.SalesJournalInitialLoadingDialog = Nothing

            SalesJournalInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.SalesJournalInitialLoadingDialog(DynamicReport, ShowReportOption, ReportType, ParameterDictionary)

            ShowFormDialog = SalesJournalInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = SalesJournalInitialLoadingDialog.ParameterDictionary
                ReportType = SalesJournalInitialLoadingDialog.ReportType

            End If

        End Function

        Private Sub EnableOrDisableActions()

            If _ShowReportOption Then

                If ComboBoxTopSection_Report.HasASelectedValue Then

                    If CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournal Then

                        Me.RadioButtonControl_ARPostPeriod.Visible = False
                        Me.RadioButtonControl_SalesPostPeriod.Visible = False
                        Me.Label1.Visible = False

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournalExpanded Then

                        Me.RadioButtonControl_ARPostPeriod.Visible = False
                        Me.RadioButtonControl_SalesPostPeriod.Visible = False
                        Me.Label1.Visible = False

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournalSummaryByInvoice Then

                        Me.RadioButtonControl_ARPostPeriod.Visible = True
                        Me.RadioButtonControl_SalesPostPeriod.Visible = True
                        Me.Label1.Visible = True

                    End If

                Else


                End If

            End If

        End Sub

        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub SalesJournalInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ComboBoxForm_StartingPostPeriod.SetRequired(True)
            ComboBoxForm_EndingPostPeriod.SetRequired(True)

            Me.DateTimePickerForm_From.Enabled = False
            Me.DateTimePickerForm_To.Enabled = False
            Me.ButtonInvoiceDate_YTD.Enabled = False
            Me.ButtonInvoiceDate_MTD.Enabled = False
            Me.ButtonInvoiceDate_1Year.Enabled = False
            Me.ButtonInvoiceDate_2Year.Enabled = False

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            PanelForm_TopSection.Visible = _ShowReportOption
            Me.RadioButtonControl_ARPostPeriod.Checked = True

            ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.SalesJournalReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

            If _ShowReportOption Then

                ComboBoxTopSection_Report.SetRequired(True)
                ComboBoxTopSection_Report.DisplayName = "Report"

                If CInt(ComboBoxTopSection_Report.GetSelectedValue) = 134 Then

                    Me.RadioButtonControl_ARPostPeriod.Visible = True
                    Me.RadioButtonControl_SalesPostPeriod.Visible = True
                    Me.Label1.Visible = True

                Else

                    Me.RadioButtonControl_ARPostPeriod.Visible = False
                    Me.RadioButtonControl_SalesPostPeriod.Visible = False
                    Me.Label1.Visible = False

                End If

            Else

                Me.RadioButtonControl_ARPostPeriod.Visible = False
                Me.RadioButtonControl_SalesPostPeriod.Visible = False
                Me.Label1.Visible = False

            End If



            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_StartingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                ComboBoxForm_EndingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                Try

                    ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception
                    ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                End Try

                Try

                    ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception
                    ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                Try

                    ComboBoxForm_StartingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingPostPeriodCode.ToString)

                Catch ex As Exception

                End Try

                Try

                    ComboBoxForm_EndingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingPostPeriodCode.ToString)

                Catch ex As Exception

                End Try

            End If

            CDPChooserControlSelectClients_SelectClients.ForceResize()

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

                If ComboBoxForm_StartingPostPeriod.SelectedValue <= ComboBoxForm_EndingPostPeriod.SelectedValue Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    If _ShowReportOption Then

                        _ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingPostPeriodCode.ToString) = ComboBoxForm_StartingPostPeriod.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingPostPeriodCode.ToString) = ComboBoxForm_EndingPostPeriod.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.BreakoutCoOpBilling.ToString) = CheckBoxForm_BreakoutCoOpBilling.CheckValue
                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.PeriodType.ToString) = If(RadioButtonControl_ARPostPeriod.Checked, 0, 1)
                    If Me.CheckBoxFrom_FilterByDate.Checked = True Then
                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingInvoiceDate.ToString) = DateTimePickerForm_From.Value
                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingInvoiceDate.ToString) = DateTimePickerForm_To.Value
                    Else
                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingInvoiceDate.ToString) = ""
                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingInvoiceDate.ToString) = ""
                    End If

                    If RadioButtonSelectOffices_AllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedOffices.ToString) = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

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

                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedClients.ToString) = ClientCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedDivisions.ToString) = DivisionCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedProducts.ToString) = ProductCodeList


                    If _ShowReportOption Then

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    Else

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a starting post period that is before the ending post period.")

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
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                    PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, CurrentPostPeriod.Year)

                    Try

						ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), PostPeriod.Year.ToString).Code

					Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndingPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
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

                        ComboBoxForm_StartingPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndingPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
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

                        ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code

                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndingPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
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

                        ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code

                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndingPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub


        Private Sub DateTimePickerForm_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_To.ValueChanged

            DateTimePickerForm_From.MaxDate = DateTimePickerForm_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_From.ValueChanged

            DateTimePickerForm_To.MinDate = DateTimePickerForm_From.Value

        End Sub
        Private Sub ComboBoxTopSection_Report_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxTopSection_Report.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso _ShowReportOption Then

                EnableOrDisableActions()

            End If

        End Sub

        Private Sub CheckBoxForm_BreakoutCoOpBilling_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_BreakoutCoOpBilling.CheckedChanged

        End Sub

        Private Sub ButtonInvoiceDate_YTD_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_YTD.Click

			DateTimePickerForm_From.Value = New Date(Now.Year, 1, 1)
			DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonInvoiceDate_MTD_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_MTD.Click

			DateTimePickerForm_From.Value = New Date(Now.Year, Now.Month, 1)
			DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonInvoiceDate_1Year_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_1Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonInvoiceDate_2Year_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_2Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-2)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub CheckBoxFrom_FilterByDate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFrom_FilterByDate.CheckedChanged

            If CheckBoxFrom_FilterByDate.Checked = True Then
                Me.DateTimePickerForm_From.Enabled = True
                Me.DateTimePickerForm_To.Enabled = True
                Me.ButtonInvoiceDate_YTD.Enabled = True
                Me.ButtonInvoiceDate_MTD.Enabled = True
                Me.ButtonInvoiceDate_1Year.Enabled = True
                Me.ButtonInvoiceDate_2Year.Enabled = True
            Else
                Me.DateTimePickerForm_From.Enabled = False
                Me.DateTimePickerForm_To.Enabled = False
                Me.ButtonInvoiceDate_YTD.Enabled = False
                Me.ButtonInvoiceDate_MTD.Enabled = False
                Me.ButtonInvoiceDate_1Year.Enabled = False
                Me.ButtonInvoiceDate_2Year.Enabled = False
            End If

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
