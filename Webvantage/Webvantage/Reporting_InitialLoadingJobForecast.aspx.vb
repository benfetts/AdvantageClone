Public Class Reporting_InitialLoadingJobForecast
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

    Private Sub Reporting_InitialLoadingJobForecast_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Years As Generic.List(Of Integer) = Nothing
        Dim SearchDate As Date = Nothing

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadComboBoxMonth.DataValueField = "Code"
            RadComboBoxMonth.DataTextField = "Name"

            RadComboBoxMonth.DataSource = (From Item In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
                                           Select [Code] = Item.Key,
                                                  [Name] = Item.Value).ToList
            RadComboBoxMonth.DataBind()

            Years = New Generic.List(Of Integer)

            For I = (System.DateTime.Now.Year - 5) To (System.DateTime.Now.Year + 5)

                Years.Add(I)

            Next

            RadComboBoxYear.DataSource = Years
            RadComboBoxYear.DataBind()

            If _ParameterDictionary IsNot Nothing Then

                Try

                    SearchDate = CType(_ParameterDictionary(AdvantageFramework.Reporting.JobForecastParameters.SearchDate.ToString), Date)

                Catch ex As Exception

                End Try

                If SearchDate <> Nothing Then

                    Try

                        RadComboBoxMonth.SelectedValue = SearchDate.Month

                    Catch ex As Exception

                    End Try

                    Try

                        RadComboBoxYear.SelectedValue = SearchDate.Year

                    Catch ex As Exception

                    End Try

                    Try

                        CheckBoxBreakoutPostPeriods.Checked = CType(_ParameterDictionary(AdvantageFramework.Reporting.JobForecastParameters.BreakoutPostPeriods.ToString), Boolean)

                    Catch ex As Exception

                    End Try

                End If

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

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.JobForecastParameters.SearchDate.ToString) = New Date(RadComboBoxYear.SelectedValue, RadComboBoxMonth.SelectedValue, 1)
                _ParameterDictionary(AdvantageFramework.Reporting.JobForecastParameters.BreakoutPostPeriods.ToString) = CheckBoxBreakoutPostPeriods.Checked

                Session("DRPT_Criteria") = Nothing
                Session("DRPT_FilterString") = Nothing
                Session("DRPT_UseBlankData") = False
                Session("DRPT_DashboardLoaded") = False
                Session("DRPT_From") = Nothing
                Session("DRPT_To") = Nothing
                Session("DRPT_ShowJobsWithNoDetails") = Nothing
                Session("DRPT_ParameterDictionary") = _ParameterDictionary

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

#End Region

#End Region

End Class
