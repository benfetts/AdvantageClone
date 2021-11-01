Public Class Reporting_InitialLoadingMediaResults
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

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

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
    Private Sub HideShowSelection()
        If RadioButtonStandard.Checked = True Then
            PanelNonBroadcast.Visible = True
            PanelMonthlyBroadcast.Visible = False
        Else
            PanelNonBroadcast.Visible = False
            PanelMonthlyBroadcast.Visible = True
        End If
    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingMediaResults_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            'If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.MediaResults Then  '_DynamicReportType

            PanelMonthlyBroadcast.Visible = False

            RadComboBoxFromMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
            RadComboBoxToMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
            RadComboBoxFromMonth.DataTextField = "Value"
            RadComboBoxFromMonth.DataValueField = "Key"
            RadComboBoxToMonth.DataTextField = "Value"
            RadComboBoxToMonth.DataValueField = "Key"
            RadComboBoxFromMonth.DataBind()
            RadComboBoxToMonth.DataBind()

            RadComboBoxFromMonth.SelectedValue = CLng(Now.Month)
            RadComboBoxToMonth.SelectedValue = CLng(Now.Month)

            TextBoxFromYear.Text = Now.Year
            TextBoxToYear.Text = Now.Year

            'Else

            '    PanelMonthlyBroadcast.Visible = False
            '    RadioButtonBroadcast.Visible = False

            'End If

            RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday
            RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday
            RadComboBoxCriteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DigitalResultsCriteria), False)

            PanelCDP.Visible = False

            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)

            RadGridClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

            RadComboBoxCriteria.DataBind()

            If _ParameterDictionary IsNot Nothing Then

                Try

                    RadComboBoxFromMonth.SelectedValue = CLng(_ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString))

                Catch ex As Exception
                    RadComboBoxFromMonth.SelectedValue = CLng(Now.Month)
                End Try

            Else

                RadComboBoxFromMonth.SelectedValue = CLng(Now.Month)
                RadComboBoxToMonth.SelectedValue = CLng(Now.Month)

                TextBoxFromYear.Text = Now.Year
                TextBoxToYear.Text = Now.Year

            End If

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

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.Criteria.ToString) = CInt(RadComboBoxCriteria.SelectedValue)
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.StartDate.ToString) = RadDatePickerFrom.SelectedDate
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.EndDate.ToString) = RadDatePickerTo.SelectedDate

                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.BroadcastDates.ToString) = RadioButtonBroadcast.Checked

                Dim sStartDate As String, sEndDate As String
                Dim dStartDate As DateTime, dEndDate As DateTime
                sStartDate = RadComboBoxFromMonth.SelectedValue.ToString + "-01-" + TextBoxFromYear.Text
                sEndDate = RadComboBoxToMonth.SelectedValue.ToString + "-01-" + TextBoxToYear.Text
                dStartDate = sStartDate
                dEndDate = sEndDate
                dEndDate = dEndDate.AddMonths(1)
                dEndDate = dEndDate.AddDays(-1)

                If RadioButtonBroadcast.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.StartDate.ToString) = dStartDate
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.EndDate.ToString) = dEndDate
                End If

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

                Session("DRPT_Criteria") = Nothing 'CInt(RadComboBoxCriteria.SelectedValue)
                Session("DRPT_FilterString") = AdvantageFramework.Reporting.CreateFilterStringForDynamicReport(_DynamicReportType, CInt(RadComboBoxCriteria.SelectedValue))
                Session("DRPT_UseBlankData") = False
                Session("DRPT_DashboardLoaded") = False
                Session("DRPT_From") = Nothing 'RadDatePickerFrom.SelectedDate
                Session("DRPT_To") = Nothing 'RadDatePickerTo.SelectedDate
                Session("DRPT_ShowJobsWithNoDetails") = CheckBoxShowJobsWithNoDetails.Checked
                Session("DRPT_ParameterDictionary") = _ParameterDictionary

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

        RadDatePickerFrom.SelectedDate = CDate(cEmployee.TimeZoneToday.Month & "/1/" & cEmployee.TimeZoneToday.Year)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadButtonYTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonYTD.Click

        RadDatePickerFrom.SelectedDate = CDate("1/1/" & cEmployee.TimeZoneToday.Year)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

    End Sub
    Private Sub RadDatePickerFrom_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerFrom.SelectedDateChanged

        RadDatePickerTo.MinDate = RadDatePickerFrom.SelectedDate

    End Sub
    Private Sub RadDatePickerTo_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerTo.SelectedDateChanged

        RadDatePickerFrom.MaxDate = RadDatePickerTo.SelectedDate

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

    Private Sub RadioButtonBroadcast_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonBroadcast.CheckedChanged
        HideShowSelection()
    End Sub

    Private Sub RadioButtonStandard_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonStandard.CheckedChanged
        HideShowSelection()
    End Sub

#End Region

#End Region

End Class
