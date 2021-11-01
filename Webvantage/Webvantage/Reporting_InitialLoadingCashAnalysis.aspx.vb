Public Class Reporting_InitialLoadingCashAnalysis
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DynamicReportType As Integer = -1
    Protected _DynamicReportTemplateID As Integer = 0
    Private _UserDefinedReportID As Integer = 0
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

#End Region

#Region " Methods "

    Private Sub LoadDynamicReport()

        _DynamicReportType = Session("DRPT_Type")

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

    Private Sub Reporting_InitialLoadingCashAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        Dim oAccounting As cAccounting = New cAccounting(CStr(Session("ConnString")))
        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.RadComboBoxStart.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                Me.RadComboBoxEnd.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                Me.RadComboBoxStart.DataBind()
                Me.RadComboBoxEnd.DataBind()

                Try
                    Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                    Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Catch ex As Exception
                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                Try

                    RadComboBoxStart.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.CashAnaylsisParameters.StartingPostPeriodCode.ToString)

                Catch ex As Exception

                End Try

                Try

                    RadComboBoxEnd.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.CashAnaylsisParameters.EndingPostPeriodCode.ToString)

                Catch ex As Exception

                End Try



            Else


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

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.CashAnaylsisParameters.StartingPostPeriodCode.ToString) = RadComboBoxStart.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.CashAnaylsisParameters.EndingPostPeriodCode.ToString) = RadComboBoxEnd.SelectedValue
                    If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CashAnalysis Then
                        _ParameterDictionary(AdvantageFramework.Reporting.CashAnaylsisParameters.Query.ToString) = 1
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

                    Me.CloseThisWindowAndOpenNewWindow("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined) & "")

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

    Private Sub RadButton1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1Year.Click
        Try
            Dim current As String
            Dim m As Integer
            Dim y As Integer
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                current = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                If current <> "" Then
                    m = CInt(current.Substring(4, 2))
                    y = CInt(current.Substring(0, 4)) - 1
                End If
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, m, y.ToString).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadButton2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2Years.Click
        Try
            Dim current As String
            Dim m As Integer
            Dim y As Integer
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                current = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                If current <> "" Then
                    m = CInt(current.Substring(4, 2))
                    y = CInt(current.Substring(0, 4)) - 2
                End If
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, m, y.ToString).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadButtonMTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonMTD.Click
        Try
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadButtonYTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonYTD.Click
        Try
            Dim current As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim m As Integer
            Dim y As Integer
            Dim pp As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                current = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                pp = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, current.Year)
				Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, pp.Month.GetValueOrDefault(1), pp.Year.ToString).ToString
				Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadButton2YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2YTD.Click
        Try
            Dim current As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim m As Integer
            Dim y As Integer
            Dim pp As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                current = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                pp = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, current.Year)
				Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, pp.Month.GetValueOrDefault(1), CInt(pp.Year) - 1).ToString
				Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

End Class
