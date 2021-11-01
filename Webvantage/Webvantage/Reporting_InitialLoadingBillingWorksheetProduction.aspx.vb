Public Class Reporting_InitialLoadingBillingWorksheetProduction
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

                RadGridClient.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)
                                            Select Client.Code,
                                                   Client.Name,
                                                   Client.IsNewBusiness,
                                                   Client.IsActive).ToList.Select(Function(Client) New With {.Code = Client.Code,
                                                                                                                    .Client = Client.Code & " - " & Client.Name,
                                                                                                                    .IsNewBusiness = CBool(Client.IsNewBusiness.GetValueOrDefault(0)),
                                                                                                                    .IsInactive = Not CBool(Client.IsActive.GetValueOrDefault(0))}).ToList
                RadGridClient.DataBind()

            End Using

        ElseIf RadioButtonClientDivision.Checked Then
            Me.RadGridClient.Visible = False
            Me.RadGridCD.Visible = True
            Me.RadGridCDP.Visible = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadGridCD.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext).Include("Client")
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

        ElseIf RadioButtonClientDivisionProduct.Checked Then
            Me.RadGridClient.Visible = False
            Me.RadGridCD.Visible = False
            Me.RadGridCDP.Visible = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadGridCDP.DataSource = (From product In AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext).Include("Office").Include("Client").Include("Division")
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

        End If

    End Sub
    Private Sub LoadAccountExecutives()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridAccountExecutives.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AccountExecutive.Load(DbContext).Include("Employee").ToList
                                                   Select [Code] = Entity.Employee.Code,
                                                          [Name] = Entity.Employee.ToString
                                                   Distinct).ToList

            RadGridAccountExecutives.DataBind()

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingBillingWorksheetProduction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxAPPostingPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                RadComboBoxAPPostingPeriod.DataBind()

                Try

                    RadComboBoxAPPostingPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString

                Catch ex As Exception
                    RadComboBoxAPPostingPeriod.SelectedValue = Nothing
                End Try

            End Using

            RadDatePickerEmployeeTimeDate.SelectedDate = cEmployee.TimeZoneToday
            RadDatePickerIncomeOnlyDate.SelectedDate = cEmployee.TimeZoneToday

            RadDatePickerFromDate.SelectedDate = Now.AddYears(-2).ToShortDateString
            RadDatePickerToDate.SelectedDate = Now.ToShortDateString

            CheckBoxPrintItemDetail.Checked = True
            CheckBoxPopulateAPComments.Checked = True
            CheckBoxPopulateIOComments.Checked = True
            CheckBoxPopulateTimeComments.Checked = True

            If _ParameterDictionary IsNot Nothing Then

                Try

                    RadDatePickerEmployeeTimeDate.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString)

                Catch ex As Exception

                End Try

                Try

                    RadDatePickerIncomeOnlyDate.SelectedDate = _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncomeOnlyDateCutoff.ToString)

                Catch ex As Exception

                End Try

                'If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString) AndAlso
                '        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString)) = False Then

                '    Try

                '        RadComboBoxAPPostingPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString)

                '    Catch ex As Exception
                '        RadComboBoxAPPostingPeriod.SelectedValue = Nothing
                '    End Try

                'End If

            End If

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

                Session("DRPT_ParameterDictionary") = Nothing

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString) = RadDatePickerEmployeeTimeDate.SelectedDate
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncomeOnlyDateCutoff.ToString) = RadDatePickerIncomeOnlyDate.SelectedDate
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString) = RadComboBoxAPPostingPeriod.SelectedValue

                If RadioButtonAll.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.JobType.ToString) = 1

                ElseIf RadioButtonAdvanceBillJobsOnly.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.JobType.ToString) = 2

                ElseIf RadioButtonServiceFeeJobsOnly.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.JobType.ToString) = 3

                End If

                If RadioButtonOpenJobswithUnbilledandOther.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.JobOption.ToString) = 1

                ElseIf RadioButtonOpenJobswithUnbilledOnly.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.JobOption.ToString) = 2

                ElseIf RadioButtonOpenJobs.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.JobOption.ToString) = 3

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeContingency.ToString) = CheckBoxIncludeContingency.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableTimeDetail.ToString) = CheckBoxIncludeNonBillableTimeDetail.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableAPIODetail.ToString) = CheckBoxIncludeNonBillableAPIODetail.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.PrintItemDetail.ToString) = CheckBoxPrintItemDetail.Checked

                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.PopulateTimeComments.ToString) = CheckBoxPopulateTimeComments.Visible AndAlso CheckBoxPopulateTimeComments.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.PopulateAPComments.ToString) = CheckBoxPopulateAPComments.Visible AndAlso CheckBoxPopulateAPComments.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.PopulateIOComments.ToString) = CheckBoxPopulateIOComments.Visible AndAlso CheckBoxPopulateIOComments.Checked

                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.UserCode.ToString) = _Session.UserCode

                If CheckBoxIncludeNonBillableTimeDetail.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.NonBillableTimeStartDate.ToString) = RadDatePickerFromDate.SelectedDate
                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.NonBillableTimeEndDate.ToString) = RadDatePickerToDate.SelectedDate

                End If

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

                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedClients.ToString) = ClientCodesList
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedDivisions.ToString) = DivisionCodesList
                _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedProducts.ToString) = ProductCodesList

                If RadioButtonAllAccountExecutives.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedAccountExecutives.ToString) = Nothing

                Else

                    If RadGridAccountExecutives.Items.Count > 0 Then
                        AccountExecutivesCodesList = New Generic.List(Of String)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridAccountExecutives.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                AccountExecutivesCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.SelectedAccountExecutives.ToString) = AccountExecutivesCodesList

                End If


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

    Private Sub RadioButtonChoose_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChoose.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChoose.Checked Then

            LoadCDPs()

            PanelCDP.Visible = True
            RadGridClient.Enabled = True
            RadGridClient.Visible = True
            RadGridCD.Visible = False
            RadGridCDP.Visible = False

        End If

        'End If

    End Sub
    Private Sub RadioButtonClient_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClient.CheckedChanged

        If RadioButtonChoose.Checked AndAlso RadioButtonClient.Checked Then

            LoadCDPs()

            PanelCDP.Enabled = True
            RadGridClient.Enabled = True
            RadGridClient.Visible = True
            RadGridCD.Visible = False
            RadGridCDP.Visible = False

        End If

    End Sub
    Private Sub RadioButtonClientDivision_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClientDivision.CheckedChanged

        If RadioButtonChoose.Checked AndAlso RadioButtonClientDivision.Checked Then

            LoadCDPs()

            PanelCDP.Enabled = True
            RadGridCD.Enabled = True
            RadGridClient.Visible = False
            RadGridCD.Visible = True
            RadGridCDP.Visible = False

        End If


    End Sub
    Private Sub RadioButtonClientDivisionProduct_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClientDivisionProduct.CheckedChanged

        If RadioButtonChoose.Checked AndAlso RadioButtonClientDivisionProduct.Checked Then

            LoadCDPs()

            PanelCDP.Enabled = True
            RadGridCDP.Enabled = True
            RadGridClient.Visible = False
            RadGridCD.Visible = False
            RadGridCDP.Visible = True

        End If

    End Sub

    Private Sub RadioButtonAllAccountExecutives_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllAccountExecutives.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonAllAccountExecutives.Checked Then

            RadGridAccountExecutives.Enabled = False
            RadGridAccountExecutives.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive)
            RadGridAccountExecutives.DataBind()

        End If

        'End If

    End Sub
    Private Sub RadioButtonChooseAccountExecutives_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseAccountExecutives.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChooseAccountExecutives.Checked Then

            If RadGridAccountExecutives.Items.Count = 0 Then

                LoadAccountExecutives()

            End If

            RadGridAccountExecutives.Enabled = True

        End If

        'End If

    End Sub

#End Region

#End Region


End Class
