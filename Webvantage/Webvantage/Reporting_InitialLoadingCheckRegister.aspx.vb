Public Class Reporting_InitialLoadingCheckRegister
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

        If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.AccountsPayableInvoiceDetailPayments Then

            'RadPageViewSelectBanks.Visible = False
            LabelInclude.Visible = False
            CheckBoxComputerGenerated.Visible = False
            CheckBoxManual.Visible = False
            CheckBoxVoidComments.Visible = False

            LabelLimitTo.Visible = False
            CheckBoxVoidedChecks.Visible = False
            CheckBoxOutstandingChecks.Visible = False
            CheckBoxClearedChecks.Visible = False

            RadPageViewSelectBank.Visible = False
            RadPageViewSelectOffices.Visible = False
            RadPageViewWorkloadSelectCDP.Visible = False

            RadTabStripTaskCalendar.Tabs.Item(1).Visible = False

            PanelCDP.Visible = False
            RadGridCD.Visible = False
            RadGridCDP.Visible = False
            RadGridClient.Visible = False
            RadGridOffice.Visible = False

        End If

    End Sub
    Private Sub LoadOffices()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
            RadGridOffice.DataBind()

        End Using

    End Sub
    Private Sub LoadBanks()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridBank.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadWithOfficeLimits(DbContext, SecuritySession).ToList
            RadGridBank.DataBind()

        End Using

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
                RadGridCD.DataBind()

            End Using

        ElseIf RadioButtonClientDivisionProduct.Checked Then
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
                RadGridCDP.DataBind()

            End Using

        End If

    End Sub
    Private Sub LoadVendors()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridVendor.DataSource = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                                        Select New With {
                                                        .Code = Vendor.Code,
                                                        .Name = Vendor.Name + " (" + Vendor.Code + ")"
                                                        }).ToList
            RadGridVendor.DataBind()

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingCheckRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.CheckBoxComputerGenerated.Checked = True
            Me.CheckBoxManual.Checked = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadDatePickerStartDate.SelectedDate = cEmployee.TimeZoneToday
                RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday

                RadComboBoxCurrentPeriodFrom.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext) Select [Code] = Entity.Code).ToList
                'AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Year).ThenBy(Function(Entity) Entity.Month).ToList
                RadComboBoxCurrentPeriodFrom.DataBind()

                Try
                    RadComboBoxCurrentPeriodFrom.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code.ToString
                Catch ex As Exception
                    RadComboBoxCurrentPeriodFrom.SelectedValue = Nothing
                End Try

                RadComboBoxCurrentPeriodTo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext) Select [Code] = Entity.Code).ToList
                'AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Year).ThenBy(Function(Entity) Entity.Month).ToList
                RadComboBoxCurrentPeriodTo.DataBind()

                Try
                    RadComboBoxCurrentPeriodTo.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code.ToString
                Catch ex As Exception
                    RadComboBoxCurrentPeriodTo.SelectedValue = Nothing
                End Try

            End Using

            RadGridBank.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Bank)

            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)

            RadGridClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

            RadGridVendor.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Vendor)

            FieldsetCheckDateRange.Disabled = False
            RadComboBoxCurrentPeriodFrom.Enabled = False
            RadComboBoxCurrentPeriodTo.Enabled = False
            FieldsetPostPeriodRange.Disabled = True

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.CheckRegisterWithInvoiceDetails Then

                Me.Title = "Check Register with Invoice Details Criteria"

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

                If RadioButtonCheckDate.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.StartingDate.ToString) = RadDatePickerStartDate.SelectedDate
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.EndingDate.ToString) = RadDatePickerEndDate.SelectedDate
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.StartingDate.ToString) = ""
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.EndingDate.ToString) = ""
                End If

                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.IncludeComputerChecks.ToString) = CheckBoxComputerGenerated.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.IncludeManualChecks.ToString) = CheckBoxManual.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.IncludeComments.ToString) = CheckBoxVoidComments.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.LimitVoidedChecks.ToString) = CheckBoxVoidedChecks.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.LimitOutstandingChecks.ToString) = CheckBoxOutstandingChecks.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.LimitClearedChecks.ToString) = CheckBoxClearedChecks.Checked

                If RadioButtonPostPeriod.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.PostPeriodStart.ToString) = RadComboBoxCurrentPeriodFrom.Text
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.PostPeriodEnd.ToString) = RadComboBoxCurrentPeriodTo.Text
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.PostPeriodStart.ToString) = ""
                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.PostPeriodEnd.ToString) = ""
                End If

                _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.UsePayToVendorCode.ToString) = CheckBoxSelectByPayToVendor.Checked

                Dim BankCodesList As Generic.List(Of String) = Nothing
                Dim OfficeCodesList As Generic.List(Of String) = Nothing
                Dim ClientCodesList As Generic.List(Of String) = Nothing
                Dim DivisionCodesList As Generic.List(Of String) = Nothing
                Dim ProductCodesList As Generic.List(Of String) = Nothing

                Dim VendorCodesList As Generic.List(Of String) = Nothing

                If RadioButtonAllBanks.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.SelectedBanks.ToString) = Nothing

                Else

                    If RadGridBank.Items.Count > 0 Then
                        BankCodesList = New Generic.List(Of String)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridBank.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                BankCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.SelectedBanks.ToString) = BankCodesList

                End If

                'If RadioButtonAllOffices.Checked Then

                '        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedOffices.ToString) = Nothing

                '    Else

                '        If RadGridOffice.Items.Count > 0 Then
                '            OfficeCodesList = New Generic.List(Of String)
                '            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                '                If gridDataItem.Selected = True Then
                '                    OfficeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                '                End If
                '            Next
                '        End If

                '        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedOffices.ToString) = OfficeCodesList

                '    End If

                '    If RadioButtonAll.Checked Then

                '        ClientCodesList = Nothing
                '        DivisionCodesList = Nothing
                '        ProductCodesList = Nothing

                '    Else

                '        If RadioButtonClient.Checked Then

                '            If RadGridClient.Items.Count > 0 Then
                '                ClientCodesList = New Generic.List(Of String)
                '                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridClient.MasterTableView.Items
                '                    If gridDataItem.Selected = True Then
                '                        ClientCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                '                    End If
                '                Next
                '            End If

                '            DivisionCodesList = Nothing
                '            ProductCodesList = Nothing

                '        ElseIf RadioButtonClientDivision.Checked Then

                '            If RadGridCD.Items.Count > 0 Then
                '                DivisionCodesList = New Generic.List(Of String)
                '                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCD.MasterTableView.Items
                '                    If gridDataItem.Selected = True Then
                '                        DivisionCodesList.Add(gridDataItem.GetDataKeyValue("ClientCode") & "|" & gridDataItem.GetDataKeyValue("Code"))
                '                    End If
                '                Next
                '            End If

                '            ClientCodesList = Nothing
                '            ProductCodesList = Nothing

                '        ElseIf RadioButtonClientDivisionProduct.Checked Then

                '            If RadGridCDP.Items.Count > 0 Then
                '                ProductCodesList = New Generic.List(Of String)
                '                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCDP.MasterTableView.Items
                '                    If gridDataItem.Selected = True Then
                '                        ProductCodesList.Add(gridDataItem.GetDataKeyValue("ClientCode") & "|" & gridDataItem.GetDataKeyValue("DivisionCode") & "|" & gridDataItem.GetDataKeyValue("Code"))
                '                    End If
                '                Next
                '            End If

                '            ClientCodesList = Nothing
                '            DivisionCodesList = Nothing

                '        End If

                '    End If

                '    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedClients.ToString) = ClientCodesList
                '    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedDivisions.ToString) = DivisionCodesList
                '    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedProducts.ToString) = ProductCodesList

                If RadioButtonAllVendors.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.SelectedVendors.ToString) = Nothing

                Else

                    If RadGridVendor.Items.Count > 0 Then
                        VendorCodesList = New Generic.List(Of String)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendor.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                VendorCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.CheckRegisterParameters.SelectedVendors.ToString) = VendorCodesList

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

    Private Sub RadButtonInvoiceYTD_Click(sender As Object, e As EventArgs) Handles RadButtonInvoiceYTD.Click

        RadDatePickerStartDate.SelectedDate = CDate("1/1/" & Now.Year)
        RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday

    End Sub

    Private Sub RadButtonInvoiceMTD_Click(sender As Object, e As EventArgs) Handles RadButtonInvoiceMTD.Click

        RadDatePickerStartDate.SelectedDate = CDate(Now.Month & "/1/" & Now.Year)
        RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday

    End Sub

    Private Sub RadButtonInvoice1Year_Click(sender As Object, e As EventArgs) Handles RadButtonInvoice1Year.Click

        RadDatePickerStartDate.SelectedDate = cEmployee.TimeZoneToday.AddYears(-1)
        RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday

    End Sub

    Private Sub RadButtonInvoice2Year_Click(sender As Object, e As EventArgs) Handles RadButtonInvoice2Year.Click

        RadDatePickerStartDate.SelectedDate = cEmployee.TimeZoneToday.AddYears(-2)
        RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday

    End Sub


    Private Sub RadioButtonAllBanks_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAllBanks.CheckedChanged
        If RadioButtonAllBanks.Checked Then

            RadGridBank.Enabled = False
            RadGridBank.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Bank)
            RadGridBank.DataBind()

        End If
    End Sub

    Private Sub RadioButtonChooseBanks_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonChooseBanks.CheckedChanged
        If RadioButtonChooseBanks.Checked Then

            If RadGridBank.Items.Count = 0 Then

                LoadBanks()

            End If

            RadGridBank.Enabled = True

        End If

    End Sub
    Private Sub RadioButtonAllVendors_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAllVendors.CheckedChanged
        If RadioButtonAllVendors.Checked Then

            RadGridVendor.Enabled = False
            RadGridVendor.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Vendor)
            RadGridVendor.DataBind()

        End If
    End Sub
    Private Sub RadioButtonChooseVendors_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonChooseVendors.CheckedChanged
        If RadioButtonChooseVendors.Checked Then

            If RadGridVendor.Items.Count = 0 Then

                LoadVendors()

            End If

            RadGridVendor.Enabled = True

        End If

    End Sub
    Private Sub RadioButtonCheckDate_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonCheckDate.CheckedChanged
        If RadioButtonCheckDate.Checked Then

            FieldsetCheckDateRange.Disabled = False
            RadDatePickerStartDate.Enabled = True
            RadDatePickerStartDate.Calendar.Enabled = True
            RadDatePickerEndDate.Enabled = True
            RadDatePickerEndDate.Calendar.Enabled = True

            FieldsetPostPeriodRange.Disabled = True
            RadComboBoxCurrentPeriodFrom.Enabled = False
            RadComboBoxCurrentPeriodTo.Enabled = False

        End If

    End Sub
    Private Sub RadioButtonPostPeriod_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonPostPeriod.CheckedChanged
        If RadioButtonPostPeriod.Checked Then

            FieldsetPostPeriodRange.Disabled = False
            RadComboBoxCurrentPeriodFrom.Enabled = True
            RadComboBoxCurrentPeriodTo.Enabled = True

            FieldsetCheckDateRange.Disabled = True
            RadDatePickerStartDate.Enabled = False
            RadDatePickerStartDate.Calendar.Enabled = False
            RadDatePickerEndDate.Enabled = False
            RadDatePickerEndDate.Calendar.Enabled = False

        End If

    End Sub

#End Region

#End Region

End Class
