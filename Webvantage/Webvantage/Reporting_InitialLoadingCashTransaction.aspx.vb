Public Class Reporting_InitialLoadingCashTransaction
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
    Private Function ConvertPeriodToDate(periodValue As String) As Date
        periodValue = periodValue.Split(" ").First
        Dim StatementCutoffMonth As String = periodValue.Substring(4, periodValue.Length - 4)
        Dim StatementCutoffYear As String = periodValue.Substring(0, 4)
        Dim StatementCutoffDate As Date = Date.Parse(StatementCutoffMonth & "-1-" & StatementCutoffYear)
        Return StatementCutoffDate
    End Function
    Private Function ConvertToYearMonth(dateInput As DateTime) As String
        '
        Dim dateAsString As String = dateInput.Year & dateInput.Month
        Return dateAsString

    End Function
    Private Function ConvertToYearMonthFromPeriod(dateInput As String) As String
        '
        Dim dateAsString As String = dateInput.Split(" ").First
        Return dateAsString
    End Function


#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingCashTransaction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.CheckBoxReceipts.Checked = True
            Me.CheckBoxDisbursements.Checked = True
            Me.CheckBoxGLEntries.Checked = True
            Me.RadDatePickerStatementCutoffDate.SelectedDate = cEmployee.TimeZoneToday
            Me.RadioButtonClearandUnclear.Checked = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBox1StartPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                RadComboBox1StartPeriod.DataBind()

                Try
                    RadComboBox1StartPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Catch ex As Exception
                    RadComboBox1StartPeriod.SelectedValue = Nothing
                End Try

                RadComboBox2EndPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                RadComboBox2EndPeriod.DataBind()

                Try
                    RadComboBox2EndPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Catch ex As Exception
                    RadComboBox2EndPeriod.SelectedValue = Nothing
                End Try

            End Using

            If Me.RadioButtonUnclearedOnly.Checked Then
                RadDatePickerStatementCutoffDate.Enabled = True
            Else
                RadDatePickerStatementCutoffDate.Enabled = False
            End If

            RadGridBank.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Bank)

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

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.StartPeriod.ToString) = ConvertToYearMonthFromPeriod(RadComboBox1StartPeriod.SelectedValue)
                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.EndPeriod.ToString) = ConvertToYearMonthFromPeriod(RadComboBox2EndPeriod.SelectedValue) 'ConvertToYearMonth(RadDatePickerEndDate.SelectedDate)
                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeReceipts.ToString) = CheckBoxReceipts.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeDisbursements.ToString) = CheckBoxDisbursements.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.IncludeGLEntries.ToString) = CheckBoxGLEntries.Checked

                '-- @cleared_option 1 = Cleared And uncleared, 2 = Uncleared only (as of @statement cutoff)
                '-- @statement_cutoff:  Enable And apply value entered when @cleared_option = 2
                Dim ClearedOption As String = "1"
                If RadioButtonUnclearedOnly.Checked Then
                    ClearedOption = "2" ' = Uncleared only (as of @statement cutoff)
                End If

                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.ClearedOption.ToString) = ClearedOption

                ' convert the Posting Period dropdown to a Date for the stored procedure
                'Dim StatementCutoffDate As Date = ConvertPeriodToDate(RadComboBoxAPPostingPeriod.SelectedValue) ' ie. "201612 - December"

                _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.StatementCutoff.ToString) = RadDatePickerStatementCutoffDate.SelectedDate   ' <== need a control dropdown or datetime like '12/31/2199'

                Dim BankCodesList As Generic.List(Of String) = Nothing
                Dim OfficeCodesList As Generic.List(Of String) = Nothing
                Dim ClientCodesList As Generic.List(Of String) = Nothing
                Dim DivisionCodesList As Generic.List(Of String) = Nothing
                Dim ProductCodesList As Generic.List(Of String) = Nothing

                If RadioButtonAllBanks.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.SelectedBanks.ToString) = Nothing

                Else

                    If RadGridBank.Items.Count > 0 Then
                        BankCodesList = New Generic.List(Of String)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridBank.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                BankCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.CashTransactionParameters.SelectedBanks.ToString) = BankCodesList

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
    Private Sub CheckBoxUnclearedOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonUnclearedOnly.CheckedChanged

        If Me.RadioButtonUnclearedOnly.Checked Then
            RadDatePickerStatementCutoffDate.Enabled = True
        Else
            RadDatePickerStatementCutoffDate.Enabled = False
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

    Private Sub RadioButtonClearandUnclear_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClearandUnclear.CheckedChanged
        If RadioButtonClearandUnclear.Checked Then
            Me.RadDatePickerStatementCutoffDate.Enabled = False
        Else
            Me.RadDatePickerStatementCutoffDate.Enabled = True
        End If
    End Sub

#End Region

#End Region

End Class
