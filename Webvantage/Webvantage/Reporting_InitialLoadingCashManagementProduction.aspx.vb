Imports Telerik.Web.UI

Public Class Reporting_InitialLoadingCashManagementProduction
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

    Private Sub LoadCDPs()

        If RadioButtonClient.Checked Then
            Me.RadGridClient.Visible = True
            Me.RadGridCD.Visible = False
            Me.RadGridCDP.Visible = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RadGridClient.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                Select Client.Code,
                                                   Client.Name,
                                                   Client.IsNewBusiness,
                                                   Client.IsActive).ToList.Select(Function(Client) New With {.Code = Client.Code,
                                                                                                                    .Client = Client.Code & " - " & Client.Name,
                                                                                                                    .IsNewBusiness = CBool(Client.IsNewBusiness.GetValueOrDefault(0)),
                                                                                                                    .IsInactive = Not CBool(Client.IsActive.GetValueOrDefault(0))}).ToList
                    RadGridClient.DataBind()

                End Using

            End Using

        ElseIf RadioButtonClientDivision.Checked Then
            Me.RadGridClient.Visible = False
            Me.RadGridCD.Visible = True
            Me.RadGridCDP.Visible = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RadGridCD.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Include("Client")
                                            Select Division.ClientCode,
                                               Division.Code,
                                               [ClientName] = Division.Client.Name,
                                               Division.Name,
                                               Division.IsActive).ToList.Select(Function(Division) New With {.ClientCode = Division.ClientCode,
                                                                                                             .Code = Division.Code,
                                                                                                             .Client = Division.ClientCode & " - " & Division.ClientName,
                                                                                                             .Division = Division.Code & " - " & Division.Name,
                                                                                                             .IsInactive = Not CBool(Division.IsActive.GetValueOrDefault(0))}).ToList
                    RadGridCD.DataBind()

                End Using

            End Using

        ElseIf RadioButtonClientDivisionProduct.Checked Then
            Me.RadGridClient.Visible = False
            Me.RadGridCD.Visible = False
            Me.RadGridCDP.Visible = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RadGridCDP.DataSource = (From product In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Include("Office").Include("Client").Include("Division")
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
                    RadGridCDP.DataBind()

                End Using

            End Using

        End If

    End Sub
    Private Sub LoadOffices()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridOffice.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                                        Select [Code] = Entity.Code,
                                               [Name] = Entity.Name).ToList
            RadGridOffice.DataBind()

        End Using

    End Sub
    'Private Sub LoadJobTypes()

    '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '        RadGridJobTypes.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobType.LoadAllActive(DbContext).ToList
    '                                      Select [Code] = Entity.Code,
    '                                             [Name] = Entity.Description.ToString
    '                                      Distinct).ToList

    '        RadGridJobTypes.DataBind()

    '    End Using

    'End Sub
    'Private Sub LoadCampaigns()

    '    Dim ClientCodesList As Generic.List(Of String) = Nothing
    '    Dim DivisionCodesList As Generic.List(Of String) = Nothing
    '    Dim ProductCodesList As Generic.List(Of String) = Nothing

    '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    '            If RadioButtonAllCampaigns.Checked = False Then

    '                If RadioButtonAllCDP.Checked = True Then

    '                    RadGridCampaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, _Session.UserCode)
    '                                                   Where (Entity.IsClosed Is Nothing OrElse
    '                                                      Entity.IsClosed = 0)
    '                                                   Select [ID] = Entity.ID,
    '                                                      [Code] = Entity.CampaignCode,
    '                                                      [Name] = Entity.CampaignName).ToList

    '                Else

    '                    If RadioButtonClient.Checked Then

    '                        If RadGridClient.Items.Count > 0 Then
    '                            ClientCodesList = New Generic.List(Of String)
    '                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridClient.MasterTableView.Items
    '                                If gridDataItem.Selected = True Then
    '                                    ClientCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
    '                                End If
    '                            Next
    '                        End If

    '                        If ClientCodesList IsNot Nothing Then

    '                            RadGridCampaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, _Session.UserCode).ToList
    '                                                           Where ClientCodesList.Contains(Entity.ClientCode) = True AndAlso
    '                                                                                              (Entity.IsClosed Is Nothing OrElse
    '                                                                                               Entity.IsClosed = 0)
    '                                                           Select [ID] = Entity.ID,
    '                                                                  [Code] = Entity.CampaignCode,
    '                                                                  [Name] = Entity.CampaignName).ToList
    '                        End If



    '                    ElseIf RadioButtonClientDivision.Checked Then

    '                        If RadGridCD.Items.Count > 0 Then
    '                            DivisionCodesList = New Generic.List(Of String)
    '                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCD.MasterTableView.Items
    '                                If gridDataItem.Selected = True Then
    '                                    DivisionCodesList.Add(gridDataItem.GetDataKeyValue("ClientCode") & "|" & gridDataItem.GetDataKeyValue("Code"))
    '                                End If
    '                            Next
    '                        End If

    '                        If DivisionCodesList IsNot Nothing Then

    '                            RadGridCampaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, _Session.UserCode).ToList
    '                                                           Where DivisionCodesList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode) = True AndAlso
    '                                                                                              (Entity.IsClosed Is Nothing OrElse
    '                                                                                               Entity.IsClosed = 0)
    '                                                           Select [ID] = Entity.ID,
    '                                                                  [Code] = Entity.CampaignCode,
    '                                                                  [Name] = Entity.CampaignName).ToList
    '                        End If



    '                    ElseIf RadioButtonClientDivisionProduct.Checked Then

    '                        If RadGridCDP.Items.Count > 0 Then
    '                            ProductCodesList = New Generic.List(Of String)
    '                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCDP.MasterTableView.Items
    '                                If gridDataItem.Selected = True Then
    '                                    ProductCodesList.Add(gridDataItem.GetDataKeyValue("ClientCode") & "|" & gridDataItem.GetDataKeyValue("DivisionCode") & "|" & gridDataItem.GetDataKeyValue("Code"))
    '                                End If
    '                            Next
    '                        End If

    '                        If ProductCodesList IsNot Nothing Then

    '                            RadGridCampaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, _Session.UserCode).ToList
    '                                                           Where ProductCodesList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode) = True AndAlso
    '                                                                                              (Entity.IsClosed Is Nothing OrElse
    '                                                                                               Entity.IsClosed = 0)
    '                                                           Select [ID] = Entity.ID,
    '                                                                  [Code] = Entity.CampaignCode,
    '                                                                  [Name] = Entity.CampaignName).ToList
    '                        End If

    '                    End If

    '                End If

    '            Else


    '                RadGridCampaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, _Session.UserCode)
    '                                               Where (Entity.IsClosed Is Nothing OrElse
    '                                                      Entity.IsClosed = 0)
    '                                               Select [ID] = Entity.ID,
    '                                                      [Code] = Entity.CampaignCode,
    '                                                      [Name] = Entity.CampaignName).ToList
    '            End If



    '            RadGridCampaigns.DataBind()

    '        End Using

    '    End Using

    'End Sub
    Private Sub LoadAccountExecutives()

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

            RadGridAccountExecutives.DataBind()

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingBillingWorksheetProduction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim FunctionCodes As Generic.List(Of String) = Nothing

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            '    RadComboBoxAPPostingPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Year).ThenBy(Function(Entity) Entity.Month).ToList
            '    RadComboBoxAPPostingPeriod.DataBind()

            '    Try
            '        RadComboBoxAPPostingPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            '    Catch ex As Exception
            '        RadComboBoxAPPostingPeriod.SelectedValue = Nothing
            '    End Try

            'End Using

            ''RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.JobDetailItemInitialCriteria), False)
            ''RadComboBoxCriteria.DataBind()

            ''RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday
            ''RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

            'RadDatePickerEmployeeTimeDate.SelectedDate = cEmployee.TimeZoneToday
            'RadDatePickerIncomeOnlyDate.SelectedDate = cEmployee.TimeZoneToday

            'Me.CheckBoxIncludeClosedJobs.Enabled = False

            'Me.RadioButtonCutoff.Checked = True

            'RadDatePickerCurrentStart.Enabled = False
            'RadDatePickerCurrentEnd.Enabled = False
            'RadComboBoxCurrentPeriod.Enabled = False

            If _ParameterDictionary IsNot Nothing Then

                'Try

                '    RadDatePickerEmployeeTimeDate.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString)

                'Catch ex As Exception

                'End Try

                'Try

                '    RadDatePickerIncomeOnlyDate.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString)

                'Catch ex As Exception

                'End Try

                'If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString) AndAlso
                '        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString)) = False Then

                '    Try

                '        RadComboBoxAPPostingPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString)

                '    Catch ex As Exception
                '        RadComboBoxAPPostingPeriod.SelectedValue = Nothing
                '    End Try

                'End If

            End If

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                FunctionCodes = AdvantageFramework.Agency.LoadJobDetailFeesFunctionCodes(DataContext)

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Dim AccountExecutivesCodesList As Generic.List(Of String) = Nothing
                Dim ClientCodesList As Generic.List(Of String) = Nothing
                Dim DivisionCodesList As Generic.List(Of String) = Nothing
                Dim ProductCodesList As Generic.List(Of String) = Nothing
                Dim OfficeCodesList As Generic.List(Of String) = Nothing

                Session("DRPT_ParameterDictionary") = Nothing

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                '_ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.JobDateCriteria.ToString) = CInt(RadComboBoxCriteria.SelectedValue)
                '_ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.JobStartDate.ToString) = RadDatePickerFrom.SelectedDate
                '_ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.JobEndDate.ToString) = RadDatePickerTo.SelectedDate
                '_ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.ShowJobsWithNoDetails.ToString) = CheckBoxShowJobsWithNoDetails.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.IncludeClosed.ToString) = IIf(CheckBoxIncludeClosedJobs.Checked, 0, 1)
                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.IncludeNonBillable.ToString) = IIf(CheckBoxIncludeNonBillable.Checked, 1, 0)


                If RadioButtonAllCDP.Checked Then

                    ClientCodesList = Nothing
                    DivisionCodesList = Nothing
                    ProductCodesList = Nothing

                Else

                    If RadioButtonClient.Checked Then

                        If RadGridClient.Items.Count > 0 Then
                            ClientCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridClient.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    ClientCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        DivisionCodesList = Nothing
                        ProductCodesList = Nothing

                    ElseIf RadioButtonClientDivision.Checked Then

                        If RadGridCD.Items.Count > 0 Then
                            DivisionCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCD.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    DivisionCodesList.Add(gridDataItem.GetDataKeyValue("ClientCode") & "|" & gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        ClientCodesList = Nothing
                        ProductCodesList = Nothing

                    ElseIf RadioButtonClientDivisionProduct.Checked Then

                        If RadGridCDP.Items.Count > 0 Then
                            ProductCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCDP.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    ProductCodesList.Add(gridDataItem.GetDataKeyValue("ClientCode") & "|" & gridDataItem.GetDataKeyValue("DivisionCode") & "|" & gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        ClientCodesList = Nothing
                        DivisionCodesList = Nothing

                    End If

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedClients.ToString) = ClientCodesList
                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedDivisions.ToString) = DivisionCodesList
                _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedProducts.ToString) = ProductCodesList

                If RadioButtonAllAccountExecutives.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedAccountExecutives.ToString) = Nothing

                Else

                    If RadGridAccountExecutives.Items.Count > 0 Then
                        AccountExecutivesCodesList = New Generic.List(Of String)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAccountExecutives.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                AccountExecutivesCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedAccountExecutives.ToString) = AccountExecutivesCodesList

                End If

                If RadioButtonAllOffices.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedOffices.ToString) = Nothing

                Else

                    If RadGridOffice.Items.Count > 0 Then
                        OfficeCodesList = New Generic.List(Of String)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                OfficeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.CashManagementProductionInitialParameters.SelectedOffices.ToString) = OfficeCodesList

                End If


                Session("DRPT_Criteria") = Nothing
                Session("DRPT_FilterString") = Nothing
                Session("DRPT_UseBlankData") = False
                Session("DRPT_DashboardLoaded") = False
                Session("DRPT_From") = Nothing
                Session("DRPT_To") = Nothing
                Session("DRPT_Data") = Nothing
                Session("DRPT_ShowJobsWithNoDetails") = Nothing '_ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.ShowJobsWithNoDetails.ToString)
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
                'Session("DRPT_Data") = Nothing
                'Session("DRPT_ShowJobsWithNoDetails") = Nothing
                'Session("DRPT_ParameterDictionary") = Nothing

                'If _DynamicReportTemplateID <> 0 Then

                '    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                'Else

                Me.CloseThisWindow()

                'End If

        End Select

    End Sub

    'Private Sub RadButton1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1Year.Click

    '    RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday.AddYears(-1)
    '    RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    'End Sub
    'Private Sub RadButton2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2Years.Click

    '    RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday.AddYears(-2)
    '    RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    'End Sub
    'Private Sub RadButtonMTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonMTD.Click

    '    RadDatePickerFrom.SelectedDate = CDate(cEmployee.TimeZoneToday.Month & "/1/" & cEmployee.TimeZoneToday.Year)
    '    RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    'End Sub
    'Private Sub RadButtonYTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonYTD.Click

    '    RadDatePickerFrom.SelectedDate = CDate("1/1/" & cEmployee.TimeZoneToday.Year)
    '    RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    'End Sub
    'Private Sub RadDatePickerFrom_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerFrom.SelectedDateChanged

    '    RadDatePickerTo.MinDate = RadDatePickerFrom.SelectedDate

    'End Sub
    'Private Sub RadDatePickerTo_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerTo.SelectedDateChanged

    '    RadDatePickerFrom.MaxDate = RadDatePickerTo.SelectedDate

    'End Sub

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

    'Private Sub RadComboBoxCriteria_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxCriteria.SelectedIndexChanged
    '    Try
    '        If RadComboBoxCriteria.SelectedValue = 0 Then
    '            Me.CheckBoxIncludeClosedJobs.Checked = False
    '            Me.CheckBoxIncludeClosedJobs.Enabled = False
    '        Else
    '            Me.CheckBoxIncludeClosedJobs.Checked = False
    '            Me.CheckBoxIncludeClosedJobs.Enabled = True
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

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

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        RadGridCD.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Include("Client").ToList
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

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        RadGridCDP.DataSource = (From product In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Include("Office").Include("Client").Include("Division").ToList
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

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        RadGridClient.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                    Select Client.Code,
                                                       Client.Name,
                                                       Client.IsNewBusiness,
                                                       Client.IsActive).ToList.Select(Function(Client) New With {.Code = Client.Code,
                                                                                                                        .Client = Client.Code & " - " & Client.Name,
                                                                                                                        .IsNewBusiness = CBool(Client.IsNewBusiness.GetValueOrDefault(0)),
                                                                                                                        .IsInactive = Not CBool(Client.IsActive.GetValueOrDefault(0))}).ToList


                    End Using

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


    Private Sub RadioButtonAllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllOffices.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonAllOffices.Checked Then

            RadGridOffice.Enabled = False
            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)
            RadGridOffice.DataBind()

        End If

        'End If

    End Sub
    Private Sub RadioButtonChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseOffices.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChooseOffices.Checked Then

            If RadGridOffice.Items.Count = 0 Then

                LoadOffices()

            End If

            RadGridOffice.Enabled = True

        End If

        'End If

    End Sub

    Private Sub RadioButtonAllCDP_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAllCDP.CheckedChanged

        If RadioButtonAllCDP.Checked = True Then

            RadGridClient.Enabled = False
            RadGridClient.Visible = False
            RadGridCD.Visible = False
            RadGridCD.Enabled = False
            RadGridCDP.Visible = False
            RadGridCDP.Enabled = False

        End If

    End Sub

#End Region

#End Region


End Class
