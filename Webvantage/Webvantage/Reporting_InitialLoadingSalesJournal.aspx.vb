Public Class Reporting_InitialLoadingSalesJournal
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

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingSalesJournal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.RadDatePickerStartDate.Enabled = False
            Me.RadDatePickerEndDate.Enabled = False
            Me.RadButtonInvoiceYTD.Enabled = False
            Me.RadButtonInvoiceMTD.Enabled = False
            Me.RadButtonInvoice1Year.Enabled = False
            Me.RadButtonInvoice2Year.Enabled = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.RadComboBoxStart.DataTextField = "Description"
                Me.RadComboBoxStart.DataValueField = "Code"

                Me.RadComboBoxStart.DataSource = (From Item In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                                                  Select [Code] = Item.Code,
                                                         [Description] = Item.ToString).ToList

                Me.RadComboBoxEnd.DataTextField = "Description"
                Me.RadComboBoxEnd.DataValueField = "Code"

                Me.RadComboBoxEnd.DataSource = (From Item In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                                                Select [Code] = Item.Code,
                                                       [Description] = Item.ToString).ToList

                Me.RadComboBoxStart.DataBind()
                Me.RadComboBoxEnd.DataBind()

                RadDatePickerStartDate.SelectedDate = cEmployee.TimeZoneToday
                RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday
                ' RadioButtonARPeriod.Checked = True

                Try

                    Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                    Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception

                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                Try

                    RadComboBoxStart.SelectedValue = CType(_ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingPostPeriodCode.ToString), String)

                Catch ex As Exception

                End Try

                Try

                    RadComboBoxEnd.SelectedValue = CType(_ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingPostPeriodCode.ToString), String)

                Catch ex As Exception

                End Try

            End If

            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)

            RadGridClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

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

                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingPostPeriodCode.ToString) = RadComboBoxStart.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingPostPeriodCode.ToString) = RadComboBoxEnd.SelectedValue

                    If CheckBoxBreakoutCoOpBilling.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.BreakoutCoOpBilling.ToString) = 1

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.BreakoutCoOpBilling.ToString) = 0


                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.PeriodType.ToString) = 0 'If(RadioButtonARPeriod.Checked, 0, 1)

                    If Me.CheckBoxFilterByDate.Checked = True Then
                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingInvoiceDate.ToString) = RadDatePickerStartDate.SelectedDate
                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingInvoiceDate.ToString) = RadDatePickerEndDate.SelectedDate
                    Else
                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingInvoiceDate.ToString) = ""
                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingInvoiceDate.ToString) = ""
                    End If

                    Dim OfficeCodesList As Generic.List(Of String) = Nothing
                    Dim ClientCodesList As Generic.List(Of String) = Nothing
                    Dim DivisionCodesList As Generic.List(Of String) = Nothing
                    Dim ProductCodesList As Generic.List(Of String) = Nothing

                    If RadioButtonAllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedOffices.ToString) = Nothing

                    Else

                        If RadGridOffice.Items.Count > 0 Then
                            OfficeCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    OfficeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                                End If
                            Next
                        End If

                        _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedOffices.ToString) = OfficeCodesList

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

                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedClients.ToString) = ClientCodesList
                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedDivisions.ToString) = DivisionCodesList
                    _ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.SelectedProducts.ToString) = ProductCodesList


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

					RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), PostPeriod.Year.ToString).Code

				Catch ex As Exception
                    RadComboBoxStart.SelectedValue = Nothing
                End Try

                Try

                    RadComboBoxEnd.SelectedValue = CurrentPostPeriod.Code

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

                    RadComboBoxStart.SelectedValue = CurrentPostPeriod.Code

                Catch ex As Exception
                    RadComboBoxStart.SelectedValue = Nothing
                End Try

                Try

                    RadComboBoxEnd.SelectedValue = CurrentPostPeriod.Code

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

                    RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code

                Catch ex As Exception
                    RadComboBoxStart.SelectedValue = Nothing
                End Try

                Try

                    RadComboBoxEnd.SelectedValue = CurrentPostPeriod.Code

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

                    RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code

                Catch ex As Exception
                    RadComboBoxStart.SelectedValue = Nothing
                End Try

                Try

                    RadComboBoxEnd.SelectedValue = CurrentPostPeriod.Code

                Catch ex As Exception
                    RadComboBoxEnd.SelectedValue = Nothing
                End Try

            End Using

        Catch ex As Exception

        End Try

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

    Private Sub CheckBoxFilterByDate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFilterByDate.CheckedChanged
        If CheckBoxFilterByDate.Checked = True Then
            Me.RadDatePickerStartDate.Enabled = True
            Me.RadDatePickerEndDate.Enabled = True
            Me.RadButtonInvoiceYTD.Enabled = True
            Me.RadButtonInvoiceMTD.Enabled = True
            Me.RadButtonInvoice1Year.Enabled = True
            Me.RadButtonInvoice2Year.Enabled = True
        Else
            Me.RadDatePickerStartDate.Enabled = False
            Me.RadDatePickerEndDate.Enabled = False
            Me.RadButtonInvoiceYTD.Enabled = False
            Me.RadButtonInvoiceMTD.Enabled = False
            Me.RadButtonInvoice1Year.Enabled = False
            Me.RadButtonInvoice2Year.Enabled = False
        End If
    End Sub

#End Region

#End Region

End Class
