Public Class Reporting_InitialLoadingAccountsPayableInvoiceWithBalanceAging
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DynamicReportType As Integer = -1
    Private _DynamicReportTemplateID As Integer = 0
    Private _UserDefinedReportID As Integer = 0
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadDynamicReport()

        _DynamicReportType = CType(Session("DRPT_Type"), Integer)

        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        Try

            If Request.QueryString("UserDefinedReportID") IsNot Nothing Then

                _UserDefinedReportID = CType(Request.QueryString("UserDefinedReportID"), Integer)

            End If

        Catch ex As Exception
            _UserDefinedReportID = 0
        End Try

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingAccountsPayableInvoiceWithBalanceAging_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxStart.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                RadComboBoxEnd.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                RadComboBoxRecordSource.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).ToList

                RadComboBoxStart.DataBind()
                RadComboBoxEnd.DataBind()
                RadComboBoxRecordSource.DataBind()
                RadComboBoxRecordSource.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                Try

                    RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString

                Catch ex As Exception
                    RadComboBoxStart.SelectedValue = Nothing
                End Try

                Try

                    RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString

                Catch ex As Exception
                    RadComboBoxEnd.SelectedValue = Nothing
                End Try

            End Using

            RadDatePickerAging.SelectedDate = cEmployee.TimeZoneToday

            If _ParameterDictionary IsNot Nothing Then

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.StartingPostPeriodCode.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.StartingPostPeriodCode.ToString)) = False Then

                    Try

                        RadComboBoxStart.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.StartingPostPeriodCode.ToString)

                    Catch ex As Exception
                        RadComboBoxStart.SelectedValue = Nothing
                    End Try

                End If

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.EndingPostPeriodCode.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.EndingPostPeriodCode.ToString)) = False Then

                    Try

                        RadComboBoxEnd.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.EndingPostPeriodCode.ToString)

                    Catch ex As Exception
                        RadComboBoxEnd.SelectedValue = Nothing
                    End Try

                End If

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.RecordSource.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.RecordSource.ToString)) = False Then

                    Try

                        RadComboBoxRecordSource.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.RecordSource.ToString)

                    Catch ex As Exception
                        RadComboBoxRecordSource.SelectedValue = Nothing
                    End Try

                End If

                Try

                    RadDatePickerAging.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.AgingDate.ToString)

                Catch ex As Exception

                End Try

                RadioButtonInvoiceDate.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.AgingOptionIsInvoiceDate.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.AgingOptionIsInvoiceDate.ToString) = 1, True, False)
                RadioButtonDateToPay.Checked = Not Me.RadioButtonInvoiceDate.Checked
                CheckBoxIncludeOpenAccountsPayableOnly.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.IncludeOpenAccountsPayableOnly.ToString)), True, _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.IncludeOpenAccountsPayableOnly.ToString))

            Else

                RadioButtonInvoiceDate.Checked = True
                RadioButtonDateToPay.Checked = False
                CheckBoxIncludeOpenAccountsPayableOnly.Checked = False

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Session("DRPT_ParameterDictionary") = Nothing

                If RadComboBoxStart.SelectedValue <= RadComboBoxEnd.SelectedValue Then

                    If RadDatePickerAging.SelectedDate IsNot Nothing Then

                        If _ParameterDictionary Is Nothing Then

                            _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.StartingPostPeriodCode.ToString) = RadComboBoxStart.SelectedValue
                        _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.EndingPostPeriodCode.ToString) = RadComboBoxEnd.SelectedValue
                        _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.AgingDate.ToString) = RadDatePickerAging.SelectedDate

                        _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.IncludeOpenAccountsPayableOnly.ToString) = If(CheckBoxIncludeOpenAccountsPayableOnly.Checked, 1, 0)
                        _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.AgingOptionIsInvoiceDate.ToString) = If(RadioButtonInvoiceDate.Checked, 1, 0)

                        If Not String.IsNullOrWhiteSpace(RadComboBoxRecordSource.SelectedValue) Then

                            _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.RecordSource.ToString) = CInt(RadComboBoxRecordSource.SelectedValue)

                        Else

                            _ParameterDictionary(AdvantageFramework.Reporting.AccountsPayableInvoiceWithBalanceAgingInitialCriteria.RecordSource.ToString) = 0

                        End If

                        Session("DRPT_Criteria") = Nothing
                        Session("DRPT_FilterString") = Nothing
                        Session("DRPT_UseBlankData") = False
                        Session("DRPT_DashboardLoaded") = False
                        Session("DRPT_From") = Nothing
                        Session("DRPT_To") = Nothing
                        Session("DRPT_ShowJobsWithNoDetails") = Nothing
                        Session("DRPT_ParameterDictionary") = _ParameterDictionary

                    Else

                        Me.ShowMessage("Please select an aging date.")

                    End If

                Else

                    Me.ShowMessage("Please select a starting post period that is before the ending post period.")

                End If

                If _UserDefinedReportID = 0 Then

                    If _DynamicReportTemplateID <> 0 Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    Else

                        Me.CloseThisWindowAndRefreshCaller("Reporting_DynamicReportEdit.aspx", False, True)

                    End If

                Else

                    Session("UserDefinedReportID") = _UserDefinedReportID

                    Me.CloseThisWindowAndOpenNewWindow("Reporting_ViewReport.aspx?Report=" & CType(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined.ToString), String) & "")

                End If

            Case RadToolBarButtonCancel.Value

                'Session("DRPT_Criteria") = Nothing
                'Session("DRPT_FilterString") = Nothing
                'Session("DRPT_UseBlankData") = True
                'Session("DRPT_DashboardLoaded") = False
                'Session("DRPT_From") = Nothing
                'Session("DRPT_To") = Nothing
                'Session("DRPT_ShowJobsWithNoDetails") = Nothing
                'Session("DRPT_ParameterDictionary") = Nothing

                'If _DynamicReportTemplateID <> 0 Then

                '    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                'Else

                Me.CloseThisWindow()

                'End If

        End Select

    End Sub
    Private Sub RadButtonYTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonYTD.Click

        Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, CurrentPostPeriod.Year)

                Try

					RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), PostPeriod.Year.ToString).ToString

				Catch ex As Exception
                    RadComboBoxStart.SelectedValue = Nothing
                End Try

                Try

                    RadComboBoxEnd.SelectedValue = CurrentPostPeriod.ToString

                Catch ex As Exception
                    RadComboBoxEnd.SelectedValue = Nothing
                End Try

            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadButtonMTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonMTD.Click

        Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                Try

                    RadComboBoxStart.SelectedValue = CurrentPostPeriod.ToString

                Catch ex As Exception
                    RadComboBoxStart.SelectedValue = Nothing
                End Try

                Try

                    RadComboBoxEnd.SelectedValue = CurrentPostPeriod.ToString

                Catch ex As Exception
                    RadComboBoxEnd.SelectedValue = Nothing
                End Try

            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadButton1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1Year.Click

        Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Dim Month As Integer = 0
        Dim Year As Integer = 0

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                If CurrentPostPeriod IsNot Nothing Then

                    Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
                    Year = CInt(CurrentPostPeriod.Year) - 1

                End If

                Try

                    RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).ToString

                Catch ex As Exception
                    RadComboBoxStart.SelectedValue = Nothing
                End Try

                Try

                    RadComboBoxEnd.SelectedValue = CurrentPostPeriod.ToString

                Catch ex As Exception
                    RadComboBoxEnd.SelectedValue = Nothing
                End Try

            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadButton2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2Years.Click

        Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Dim Month As Integer = 0
        Dim Year As Integer = 0

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                If CurrentPostPeriod IsNot Nothing Then

                    Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
                    Year = CInt(CurrentPostPeriod.Year) - 2

                End If

                Try

                    RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).ToString

                Catch ex As Exception
                    RadComboBoxStart.SelectedValue = Nothing
                End Try

                Try

                    RadComboBoxEnd.SelectedValue = CurrentPostPeriod.ToString

                Catch ex As Exception
                    RadComboBoxEnd.SelectedValue = Nothing
                End Try

            End Using

        Catch ex As Exception

        End Try

    End Sub

#End Region

#End Region

End Class
