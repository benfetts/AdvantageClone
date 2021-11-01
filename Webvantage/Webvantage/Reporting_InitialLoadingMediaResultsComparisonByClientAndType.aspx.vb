Public Class Reporting_InitialLoadingMediaResultsComparisonByClientAndType
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
    Private Sub LoadOffices()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList

            RadGridOffice.DataBind()

        End Using

    End Sub
    Private Sub LoadCDPs()

        If RadioButtonClient.Checked Then

            Me.RadGridClient.Visible = True
            Me.RadGridCD.Visible = False
            Me.RadGridCDP.Visible = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    'Changed from LoadAllActive
                    RadGridClient.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
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

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    'Changed from LoadAllActive
                    RadGridCD.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode).Include("Client").ToList
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

                    RadGridCD.DataBind()

                End Using

            End Using

        ElseIf RadioButtonClientDivisionProduct.Checked Then

            Me.RadGridClient.Visible = False
            Me.RadGridCD.Visible = False
            Me.RadGridCDP.Visible = True

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    'Changed from LoadAllActive
                    RadGridCDP.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode).Include("Office").Include("Client").Include("Division").ToList
                                             Where Product.Client.IsActive = 1 AndAlso Product.Division.IsActive = 1
                                             Select Product.OfficeCode,
                                                    Product.ClientCode,
                                                    Product.DivisionCode,
                                                    Product.Code,
                                                    [OfficeName] = Product.Office.Name,
                                                    [ClientName] = Product.Client.Name,
                                                    [DivisionName] = Product.Division.Name,
                                                    Product.Name,
                                                    Product.IsActive).ToList.Select(Function(Entity) New With {.OfficeCode = Entity.OfficeCode,
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

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingBillingWorksheetMedia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadComboBoxMonthFrom.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))

            RadComboBoxMonthFrom.DataBind()

            RadComboBoxMonthTo.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))

            RadComboBoxMonthTo.DataBind()

            RadNumericTextBoxFromYear.MinValue = 1980
            RadNumericTextBoxFromYear.MaxValue = 2078
            RadNumericTextBoxFromYear.Value = Now.Year

            RadNumericTextBoxToYear.MinValue = 1980
            RadNumericTextBoxToYear.MaxValue = 2078
            RadNumericTextBoxToYear.Value = Now.Year

            RadComboBoxMonthFrom.SelectedIndex = Now.Month - 1
            RadComboBoxMonthTo.SelectedIndex = Now.Month - 1

            Me.CheckBoxIncludeVendor.Checked = True
            Me.CheckBoxIncludePeriod.Checked = True
            Me.CheckBoxInckudeSalesClass.Checked = True
            Me.CheckBoxIncludeVendor.Checked = True

            Try
                Dim oAppVars As New cAppVars(cAppVars.Application.REPORT_MEDIACOMPCLIENTTYPE)
                oAppVars.getAllAppVars()
                If oAppVars.getAppVar("IncludeVendor") <> "" Then
                    If oAppVars.getAppVar("IncludeVendor") = "True" Then
                        CheckBoxIncludeVendor.Checked = True
                    Else
                        CheckBoxIncludeVendor.Checked = False
                    End If
                End If
                If oAppVars.getAppVar("IncludePeriod") <> "" Then
                    If oAppVars.getAppVar("IncludePeriod") = "True" Then
                        CheckBoxIncludePeriod.Checked = True
                    Else
                        CheckBoxIncludePeriod.Checked = False
                    End If
                End If
                If oAppVars.getAppVar("IncludeSalesClass") <> "" Then
                    If oAppVars.getAppVar("IncludeSalesClass") = "True" Then
                        CheckBoxInckudeSalesClass.Checked = True
                    Else
                        CheckBoxInckudeSalesClass.Checked = False
                    End If
                End If
                If oAppVars.getAppVar("IncludeAdNumber") <> "" Then
                    If oAppVars.getAppVar("IncludeAdNumber") = "True" Then
                        CheckBoxIncludeAdNumber.Checked = True
                    Else
                        CheckBoxIncludeAdNumber.Checked = False
                    End If
                End If

                PanelCDP.Visible = False

                RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)

                RadGridClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)
            Catch ex As Exception

            End Try


        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        'objects
        Dim OfficeCodesList As Generic.List(Of String) = Nothing
        Dim ClientCodesList As Generic.List(Of String) = Nothing
        Dim DivisionCodesList As Generic.List(Of String) = Nothing
        Dim ProductCodesList As Generic.List(Of String) = Nothing

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Session("DRPT_ParameterDictionary") = Nothing

                Dim appVars As New cAppVars(cAppVars.Application.REPORT_MEDIACOMPCLIENTTYPE)
                appVars.setAppVarDB("IncludeVendor", If(CheckBoxIncludeVendor.Checked, True, False))
                appVars.setAppVarDB("IncludePeriod", If(CheckBoxIncludePeriod.Checked, True, False))
                appVars.setAppVarDB("IncludeSalesClass", If(CheckBoxInckudeSalesClass.Checked, True, False))
                appVars.setAppVarDB("IncludeAdNumber", If(CheckBoxIncludeAdNumber.Checked, True, False))

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.StartDate.ToString) = DateSerial(RadNumericTextBoxFromYear.Value, RadComboBoxMonthFrom.SelectedValue, 1)
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.EndDate.ToString) = DateSerial(RadNumericTextBoxToYear.Value, RadComboBoxMonthTo.SelectedValue + 1, 0)
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludeVendor.ToString) = If(CheckBoxIncludeVendor.Checked, True, False)
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludePeriod.ToString) = If(CheckBoxIncludePeriod.Checked, True, False)
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludeSalesClass.ToString) = If(CheckBoxInckudeSalesClass.Checked, True, False)
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsComparisonByClientTypeParameters.IncludeAdNumber.ToString) = If(CheckBoxIncludeAdNumber.Checked, True, False)

                If RadioButtonAllOffices.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedOffices.ToString) = Nothing

                Else

                    If RadGridOffice.Items.Count > 0 Then

                        OfficeCodesList = New Generic.List(Of String)

                        For Each GridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items

                            If GridDataItem.Selected = True Then
                                OfficeCodesList.Add(GridDataItem.GetDataKeyValue("Code"))
                            End If

                        Next

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedOffices.ToString) = OfficeCodesList

                End If

                If RadioButtonAll.Checked Then

                    ClientCodesList = Nothing
                    DivisionCodesList = Nothing
                    ProductCodesList = Nothing

                Else

                    If RadioButtonClient.Checked Then

                        If RadGridClient.Items.Count > 0 Then

                            ClientCodesList = New Generic.List(Of String)

                            For Each GridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridClient.MasterTableView.Items

                                If GridDataItem.Selected = True Then
                                    ClientCodesList.Add(GridDataItem.GetDataKeyValue("Code"))
                                End If

                            Next

                        End If

                        DivisionCodesList = Nothing
                        ProductCodesList = Nothing

                    ElseIf RadioButtonClientDivision.Checked Then

                        If RadGridCD.Items.Count > 0 Then

                            DivisionCodesList = New Generic.List(Of String)

                            For Each GridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCD.MasterTableView.Items

                                If GridDataItem.Selected = True Then
                                    DivisionCodesList.Add(GridDataItem.GetDataKeyValue("ClientCode") & "|" & GridDataItem.GetDataKeyValue("Code"))
                                End If

                            Next

                        End If

                        ClientCodesList = Nothing
                        ProductCodesList = Nothing

                    ElseIf RadioButtonClientDivisionProduct.Checked Then

                        If RadGridCDP.Items.Count > 0 Then

                            ProductCodesList = New Generic.List(Of String)

                            For Each GridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCDP.MasterTableView.Items

                                If GridDataItem.Selected = True Then
                                    ProductCodesList.Add(GridDataItem.GetDataKeyValue("ClientCode") & "|" & GridDataItem.GetDataKeyValue("DivisionCode") & "|" & GridDataItem.GetDataKeyValue("Code"))
                                End If

                            Next

                        End If

                        ClientCodesList = Nothing
                        DivisionCodesList = Nothing

                    End If

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedClients.ToString) = ClientCodesList
                _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedDivisions.ToString) = DivisionCodesList
                _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedProducts.ToString) = ProductCodesList

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
    Private Sub RadioButtonAllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllOffices.CheckedChanged

        If RadioButtonAllOffices.Checked Then

            RadGridOffice.Enabled = False
            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)
            RadGridOffice.DataBind()

        End If

    End Sub
    Private Sub RadioButtonChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseOffices.CheckedChanged

        If RadioButtonChooseOffices.Checked Then

            If RadGridOffice.Items.Count = 0 Then

                LoadOffices()

            End If

            RadGridOffice.Enabled = True

        End If

    End Sub
    Private Sub RadioButtonSelectCDPs_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAll.CheckedChanged

        If RadioButtonAll.Checked Then

            PanelCDP.Visible = False
            RadGridClient.Enabled = False
            RadGridClient.Visible = True
            RadGridCD.Visible = False
            RadGridCDP.Visible = False
            RadGridClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)
            RadGridClient.DataBind()

        End If

    End Sub
    Private Sub RadioButtonChoose_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChoose.CheckedChanged

        If RadioButtonChoose.Checked Then

            LoadCDPs()

            PanelCDP.Visible = True
            RadGridClient.Enabled = True
            RadGridClient.Visible = True
            RadGridCD.Visible = False
            RadGridCDP.Visible = False

        End If

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

#End Region

#End Region


End Class
