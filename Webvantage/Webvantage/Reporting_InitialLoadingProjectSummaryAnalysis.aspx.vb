Imports Telerik.Web.UI

Public Class Reporting_InitialLoadingProjectSummaryAnalysis
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

    Private Sub Reporting_InitialLoading_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailInitialCriteria), False)
            RadComboBoxCriteria.DataBind()
            RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday
            RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

            If _ParameterDictionary IsNot Nothing Then

                Try

                    RadDatePickerFrom.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.FromDate.ToString)

                Catch ex As Exception

                End Try

                Try

                    RadDatePickerTo.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ToDate.ToString)

                Catch ex As Exception

                End Try

                CheckBoxIncludeDetail.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeDetail.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeDetail.ToString) = 1, True, False)
                CheckBoxIncludeEmployeeDetail.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeEmployeeDetail.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeEmployeeDetail.ToString) = 1, True, False)
                RadioButtonPlanned.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.QuotedPlanned.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.QuotedPlanned.ToString) = 1, True, False)
                RadioButtonQuoted.Checked = Not Me.RadioButtonPlanned.Checked
                RadioButtonHoursAllowed.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ForecastHoursAllowed.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ForecastHoursAllowed.ToString) = 1, True, False)
                RadioButtonForecast.Checked = Not Me.RadioButtonHoursAllowed.Checked

            Else
                CheckBoxIncludeDetail.Checked = False
                CheckBoxIncludeEmployeeDetail.Checked = False
                RadioButtonQuoted.Checked = False
                RadioButtonPlanned.Checked = True
                RadioButtonForecast.Checked = False
                RadioButtonHoursAllowed.Checked = True

            End If

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.Transfer Then

                'RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.ClientPLParameters), False)

            Else

                'Me.CloseThisWindow()

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

                If RadDatePickerFrom.SelectedDate <= RadDatePickerTo.SelectedDate Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.DateType.ToString) = RadComboBoxCriteria.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.FromDate.ToString) = RadDatePickerFrom.SelectedDate
                    _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ToDate.ToString) = RadDatePickerTo.SelectedDate
                    _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeDetail.ToString) = Me.CheckBoxIncludeDetail.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.IncludeEmployeeDetail.ToString) = Me.CheckBoxIncludeEmployeeDetail.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.QuotedPlanned.ToString) = If(RadioButtonQuoted.Checked, 1, 2)
                    _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ForecastHoursAllowed.ToString) = If(RadioButtonForecast.Checked, 1, 2)

                    Dim ClientCodesList As Generic.List(Of String) = Nothing
                    Dim AccountExecutivesCodesList As Generic.List(Of String) = Nothing
                    Dim SalesClassCodesList As Generic.List(Of String) = Nothing
                    Dim JobTypeCodesList As Generic.List(Of String) = Nothing

                    If RadioButtonAllCDP.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ClientCodes.ToString) = Nothing

                    Else

                        If RadGridClient.Items.Count > 0 Then
                            ClientCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridClient.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    ClientCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.ClientCodes.ToString) = ClientCodesList

                    End If

                    If RadioButtonAllAccountExecutives.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.AECodes.ToString) = Nothing

                    Else

                        If RadGridAccountExecutives.Items.Count > 0 Then
                            AccountExecutivesCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAccountExecutives.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    AccountExecutivesCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.AECodes.ToString) = AccountExecutivesCodesList

                    End If

                    If RadioButtonAllSalesClass.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.SalesClassCodes.ToString) = Nothing

                    Else

                        If RadGridSalesClass.Items.Count > 0 Then
                            SalesClassCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridSalesClass.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    SalesClassCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.SalesClassCodes.ToString) = SalesClassCodesList

                    End If

                    If RadioButtonAllJobTypes.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.JobTypeCodes.ToString) = Nothing

                    Else

                        If RadGridJobTypes.Items.Count > 0 Then
                            JobTypeCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobTypes.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    JobTypeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.ProjectSummaryAnalysisParameters.JobTypeCodes.ToString) = JobTypeCodesList

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

        RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday.AddYears(-1)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadButton2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2Years.Click

        RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday.AddYears(-2)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadButtonMTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonMTD.Click

        RadDatePickerFrom.SelectedDate = CDate(Now.Month & "/1/" & Now.Year)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadButtonYTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonYTD.Click

        RadDatePickerFrom.SelectedDate = CDate("1/1/" & Now.Year)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadDatePickerFrom_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerFrom.SelectedDateChanged

        RadDatePickerTo.MinDate = RadDatePickerFrom.SelectedDate

    End Sub
    Private Sub RadDatePickerTo_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerTo.SelectedDateChanged

        RadDatePickerFrom.MaxDate = RadDatePickerTo.SelectedDate

    End Sub
    Private Sub CheckBoxIncludeDetail_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeDetail.CheckedChanged
        If Me.CheckBoxIncludeDetail.Checked = True Then
            Me.RadioButtonHoursAllowed.Checked = True
            Me.RadioButtonForecast.Checked = False
            Me.CheckBoxIncludeEmployeeDetail.Checked = False
        End If
    End Sub

    Private Sub CheckBoxIncludeEmployeeDetail_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeEmployeeDetail.CheckedChanged
        If Me.CheckBoxIncludeEmployeeDetail.Checked = True Then
            Me.RadioButtonHoursAllowed.Checked = True
            Me.RadioButtonForecast.Checked = False
            Me.RadioButtonPlanned.Checked = True
            Me.RadioButtonQuoted.Checked = False
            Me.CheckBoxIncludeDetail.Checked = False
        End If
    End Sub

    Private Sub RadioButtonQuoted_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonQuoted.CheckedChanged
        If RadioButtonQuoted.Checked = True Then
            CheckBoxIncludeEmployeeDetail.Checked = False
        End If
    End Sub

    Private Sub RadioButtonForecast_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForecast.CheckedChanged
        If RadioButtonForecast.Checked = True Then
            CheckBoxIncludeEmployeeDetail.Checked = False
        End If
    End Sub

    Private Sub RadioButtonAllCDP_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAllCDP.CheckedChanged
        If RadioButtonAllCDP.Checked = True Then
            RadGridClient.Rebind()
        End If
    End Sub
    Private Sub RadioButtonChoose_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChoose.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChoose.Checked Then

            'LoadCDPs()

            PanelCDP.Visible = True
            RadGridClient.Enabled = True
            RadGridClient.Visible = True
            RadGridCD.Visible = False
            RadGridCDP.Visible = False

            RadGridClient.Rebind()

        End If

        'End If

    End Sub
    Private Sub RadioButtonClient_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClient.CheckedChanged

        If RadioButtonChoose.Checked AndAlso RadioButtonClient.Checked Then

            'LoadCDPs()

            PanelCDP.Enabled = True
            RadGridClient.Enabled = True
            RadGridClient.Visible = True
            RadGridCD.Visible = False
            RadGridCDP.Visible = False

            RadGridClient.Rebind()

        End If

    End Sub
    Private Sub RadioButtonClientDivision_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClientDivision.CheckedChanged

        If RadioButtonChoose.Checked AndAlso RadioButtonClientDivision.Checked Then

            'LoadCDPs()

            PanelCDP.Enabled = True
            RadGridCD.Enabled = True
            RadGridClient.Visible = False
            RadGridCD.Visible = True
            RadGridCDP.Visible = False

            RadGridCD.Rebind()

        End If


    End Sub
    Private Sub RadioButtonClientDivisionProduct_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClientDivisionProduct.CheckedChanged

        If RadioButtonChoose.Checked AndAlso RadioButtonClientDivisionProduct.Checked Then

            'LoadCDPs()

            PanelCDP.Enabled = True
            RadGridCDP.Enabled = True
            RadGridClient.Visible = False
            RadGridCD.Visible = False
            RadGridCDP.Visible = True

            RadGridCDP.Rebind()

        End If

    End Sub

    Private Sub RadioButtonAllAccountExecutives_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllAccountExecutives.CheckedChanged

        'If Me.FormShown Then

        RadGridAccountExecutives.Rebind()
        'If RadioButtonAllAccountExecutives.Checked Then

        '    RadGridAccountExecutives.Enabled = False
        '    RadGridAccountExecutives.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive)
        '    RadGridAccountExecutives.DataBind()

        'End If

        'End If

    End Sub
    Private Sub RadioButtonChooseAccountExecutives_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseAccountExecutives.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChooseAccountExecutives.Checked Then

            If RadGridAccountExecutives.Items.Count = 0 Then

                'LoadAccountExecutives()
                Me.RadGridAccountExecutives.Rebind()

            End If

            RadGridAccountExecutives.Enabled = True

        End If

        'End If

    End Sub
    Private Sub RadioButtonAllSalesClasses_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllSalesClass.CheckedChanged

        'If Me.FormShown Then

        RadGridSalesClass.Rebind()

        'If RadioButtonAllCampaigns.Checked Then

        '    RadGridCampaigns.Enabled = False
        '    RadGridCampaigns.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive)
        '    RadGridCampaigns.DataBind()

        'End If

        'End If

    End Sub
    Private Sub RadioButtonChooseSalesClasses_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseSalesClass.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChooseSalesClass.Checked Then

            If RadGridSalesClass.Items.Count = 0 Then

                'LoadCampaigns()
                RadGridSalesClass.Rebind()

            End If

            RadGridSalesClass.Enabled = True

        End If

        'End If

    End Sub

    Private Sub RadGridCD_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridCD.NeedDataSource
        If RadioButtonAllCDP.Checked Then
            RadGridCD.Enabled = False
            RadGridCD.Visible = False
            RadGridCD.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)
        Else
            If RadioButtonClientDivision.Checked Then
                Me.RadGridClient.Visible = False
                Me.RadGridCD.Visible = True
                Me.RadGridCDP.Visible = False

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RadGridCD.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext).Include("Client").ToList
                                            Where Division.Client.IsActive = 1
                                            Select Division.ClientCode,
                                                   Division.Code,
                                                   [ClientName] = Division.Client.Name,
                                                   Division.Name,
                                                   Division.IsActive).ToList.Select(Function(Division) New With {.ClientCode = Division.ClientCode,
                                                                                                                 .Code = Division.Code,
                                                                                                                 .Client = Division.ClientCode & " - " & Division.ClientName,
                                                                                                                 .Division = Division.Code & " - " & Division.Name,
                                                                                                                 .IsInactive = Not CBool(Division.IsActive.GetValueOrDefault(0))}).ToList


                End Using

            End If
        End If

    End Sub

    Private Sub RadGridCDP_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridCDP.NeedDataSource
        If RadioButtonAllCDP.Checked Then
            RadGridCDP.Enabled = False
            RadGridCDP.Visible = False
            RadGridCDP.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)
        Else
            If RadioButtonClientDivisionProduct.Checked Then
                Me.RadGridClient.Visible = False
                Me.RadGridCD.Visible = False
                Me.RadGridCDP.Visible = True

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RadGridCDP.DataSource = (From product In AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext).Include("Office").Include("Client").Include("Division").ToList
                                             Where product.Client.IsActive = 1 AndAlso product.Division.IsActive = 1
                                             Select product.OfficeCode,
                                             product.ClientCode,
                                             product.DivisionCode,
                                             product.Code,
                                             [OfficeName] = product.Office.Name,
                                             [ClientName] = product.Client.Name,
                                             [DivisionName] = product.Division.Name,
                                             product.Name,
                                             product.IsActive).ToList.Select(Function(Entity) New With {.OfficeCode = Entity.OfficeCode,
                                                                                                        .ClientCode = Entity.ClientCode,
                                                                                                        .DivisionCode = Entity.DivisionCode,
                                                                                                        .Code = Entity.Code,
                                                                                                        .Office = Entity.OfficeCode & " - " & Entity.OfficeName,
                                                                                                        .Client = Entity.ClientCode & " - " & Entity.ClientName,
                                                                                                        .Division = Entity.DivisionCode & " - " & Entity.DivisionName,
                                                                                                        .Product = Entity.Code & " - " & Entity.Name,
                                                                                                        .[IsInactive] = Not CBool(Entity.IsActive.GetValueOrDefault(0))}).ToList


                End Using

            End If
        End If

    End Sub

    Private Sub RadGridClient_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridClient.NeedDataSource
        If RadioButtonAllCDP.Checked Then
            RadGridClient.Enabled = False
            RadGridClient.Visible = True
            RadGridClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)
        Else
            If RadioButtonClient.Checked Then
                Me.RadGridClient.Visible = True
                Me.RadGridCD.Visible = False
                Me.RadGridCDP.Visible = False

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RadGridClient.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)
                                                Select Client.Code,
                                                       Client.Name,
                                                       Client.IsNewBusiness,
                                                       Client.IsActive).ToList.Select(Function(Client) New With {.Code = Client.Code,
                                                                                                                        .Client = Client.Code & " - " & Client.Name,
                                                                                                                        .IsNewBusiness = CBool(Client.IsNewBusiness.GetValueOrDefault(0)),
                                                                                                                        .IsInactive = Not CBool(Client.IsActive.GetValueOrDefault(0))}).ToList


                End Using

            End If
        End If

    End Sub

    Private Sub RadGridAccountExecutives_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridAccountExecutives.NeedDataSource

        If RadioButtonAllAccountExecutives.Checked Then

            RadGridAccountExecutives.Enabled = False
            RadGridAccountExecutives.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive)

        Else
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim DataTable As System.Data.DataTable = Nothing

                Try

                    Using SqlCommand = DbContext.CreateCommand()

                        DataTable = New System.Data.DataTable

                        SqlCommand.CommandType = CommandType.StoredProcedure
                        SqlCommand.CommandText = "usp_wv_dd_account_executive"

                        SqlCommand.Parameters.AddWithValue("Client", "")
                        SqlCommand.Parameters.AddWithValue("Division", "")
                        SqlCommand.Parameters.AddWithValue("Product", "")
                        SqlCommand.Parameters.AddWithValue("USER_CODE", _Session.User.UserCode)

                        SqlCommand.Connection.Open()

                        Try

                            DataTable.Load(SqlCommand.ExecuteReader)

                        Catch ex As Exception
                            DataTable = Nothing
                        Finally
                            SqlCommand.Connection.Close()
                        End Try

                    End Using

                Catch ex As Exception

                End Try

                RadGridAccountExecutives.DataSource = DataTable

                'RadGridAccountExecutives.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AccountExecutive.Load(DbContext).Include("Employee").ToList
                '                                       Select [Code] = Entity.Employee.Code,
                '                                              [Name] = Entity.Employee.ToString
                '                                       Distinct).ToList.OrderBy(Function(AE) AE.Code).ToList

            End Using

        End If


    End Sub

    Private Sub RadGridSalesClass_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridSalesClass.NeedDataSource
        Dim ClientCodesList As Generic.List(Of String) = Nothing
        Dim DivisionCodesList As Generic.List(Of String) = Nothing
        Dim ProductCodesList As Generic.List(Of String) = Nothing

        If RadioButtonAllSalesClass.Checked Then

            RadGridSalesClass.Enabled = False
            RadGridSalesClass.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

        Else

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RadGridSalesClass.DataSource = From Entity In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList
                                                   Select [Code] = Entity.Code,
                                                          [Name] = Entity.ToString



                End Using

            End Using

        End If


    End Sub

    Private Sub RadGridJobTypes_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridJobTypes.NeedDataSource

        If RadioButtonAllJobTypes.Checked Then

            RadGridJobTypes.Enabled = False
            RadGridJobTypes.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobType)

        Else
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadGridJobTypes.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobType.Load(DbContext).ToList
                                              Select [Code] = Entity.Code,
                                                     [Name] = Entity.Description.ToString
                                              Distinct).ToList

            End Using

        End If

    End Sub

    Private Sub RadioButtonAllJobTypes_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAllJobTypes.CheckedChanged

        RadGridJobTypes.Rebind()

    End Sub

    Private Sub RadioButtonChooseJobTypes_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonChooseJobTypes.CheckedChanged

        If RadioButtonChooseJobTypes.Checked Then

            If RadGridJobTypes.Items.Count = 0 Then

                'LoadAccountExecutives()
                Me.RadGridJobTypes.Rebind()

            End If

            RadGridJobTypes.Enabled = True

        End If

    End Sub

#End Region

#End Region


End Class
