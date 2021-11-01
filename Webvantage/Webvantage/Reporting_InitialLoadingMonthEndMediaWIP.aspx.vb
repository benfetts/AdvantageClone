Public Class Reporting_InitialLoadingMonthEndMediaWIP
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

            RadGridOffice.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                                        Select [Code] = Entity.Code,
                                               [Name] = Entity.Name).ToList
            RadGridOffice.DataBind()

        End Using

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

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingSalesJournal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.RadComboBoxEnd.DataTextField = "Description"
                Me.RadComboBoxEnd.DataValueField = "Code"

                Me.RadComboBoxEnd.DataSource = (From Item In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                                                Select [Code] = Item.Code,
                                                       [Description] = Item.ToString).ToList

                Me.RadComboBoxEnd.DataBind()

                Try

                    Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception

                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                Try

                    RadComboBoxEnd.SelectedValue = CType(_ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString), String)

                Catch ex As Exception

                End Try

            End If

            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)

            RadGridClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)


            If _DynamicReportType = 142 Then

                DivOptions.Visible = False
                Me.RadTabStripTaskCalendar.Tabs(2).Visible = False
                DivAging.Visible = False
                CheckboxIncludeDetails.Visible = False

            ElseIf _DynamicReportType = 143 Then

                DivOptions.Visible = False
                Me.RadTabStripTaskCalendar.Tabs(2).Visible = False
                DivAging.Visible = True
                RadDatePickerAgingDate.SelectedDate = Date.Now
                CheckboxIncludeDetails.Visible = True

            Else

                DivAging.Visible = False
                CheckboxIncludeDetails.Visible = False

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

                Dim OfficeCodesList As Generic.List(Of String) = Nothing

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                If _DynamicReportType = 142 Then

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccruedLiabilityParameters.EndPeriod.ToString) = RadComboBoxEnd.SelectedValue

                    If RadioButtonAllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccruedLiabilityParameters.SelectedOffices.ToString) = Nothing

                    Else

                        If RadGridOffice.Items.Count > 0 Then
                            OfficeCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    OfficeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccruedLiabilityParameters.SelectedOffices.ToString) = OfficeCodesList

                    End If

                ElseIf _DynamicReportType = 143 Then

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.EndPeriod.ToString) = RadComboBoxEnd.SelectedValue

                    If RadioButtonAllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.SelectedOffices.ToString) = Nothing

                    Else

                        If RadGridOffice.Items.Count > 0 Then
                            OfficeCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    OfficeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.SelectedOffices.ToString) = OfficeCodesList

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingDate.ToString) = RadDatePickerAgingDate.SelectedDate
                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingOption.ToString) = If(RadioButtonInvoice.Checked, 1, 2)
                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.IncludeDetails.ToString) = If(CheckboxIncludeDetails.Checked, 1, 0)

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString) = RadComboBoxEnd.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString) = If(RadioButtonOpenOnly.Checked, 2, 1)

                    If RadioButtonOpenOrders.Checked Then
                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "O"
                        'ElseIf RadioButtonOpenOrdersGLAccountOrders.Checked Then
                        '    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "G"
                        'ElseIf RadioButtonOpenOrdersGLAccountLineOrders.Checked Then
                        '    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "L"
                    ElseIf RadioButtonZeroBalanceOrders.Checked Then
                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.WIPOption.ToString) = "Z"
                    End If

                    Dim ClientCodesList As Generic.List(Of String) = Nothing
                    Dim DivisionCodesList As Generic.List(Of String) = Nothing
                    Dim ProductCodesList As Generic.List(Of String) = Nothing

                    If RadioButtonAllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.SelectedOffices.ToString) = Nothing

                    Else

                        If RadGridOffice.Items.Count > 0 Then
                            OfficeCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    OfficeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.SelectedOffices.ToString) = OfficeCodesList

                    End If

                    If RadioButtonAll.Checked Then

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

                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.SelectedClients.ToString) = ClientCodesList
                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.SelectedDivisions.ToString) = DivisionCodesList
                    _ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.SelectedProducts.ToString) = ProductCodesList

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
    Private Sub RadioButtonSelectCDPs_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAll.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonAll.Checked Then

            PanelCDP.Visible = False
            RadGridClient.Enabled = False
            RadGridClient.Visible = True
            RadGridCD.Visible = False
            RadGridCDP.Visible = False
            RadGridClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)
            RadGridClient.DataBind()

        End If

        'End If

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

#End Region

#End Region

End Class
