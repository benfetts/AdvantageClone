Public Class Reporting_InitialLoadingPostPeriod
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
    Private Sub LoadOffices()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridOffice.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                                        Select [Code] = Entity.Code,
                                               [Name] = Entity.Name,
                                               [IsInactive] = Entity.IsInactive).ToList
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
                    RadGridCD.DataBind()

                End Using

            End Using

        ElseIf RadioButtonClientDivisionProduct.Checked Then
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
                    RadGridCDP.DataBind()

                End Using

            End Using

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingPostPeriod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        Dim oAccounting As cAccounting = New cAccounting(CStr(Session("ConnString")))
        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.RadComboBoxStart.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                Me.RadComboBoxEnd.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                Me.RadComboBoxStart.DataBind()
                Me.RadComboBoxEnd.DataBind()

                'Me.RadComboBoxOverheadSet.DataSource = AdvantageFramework.Database.Procedures.OverheadAccount.LoadDistinctOverheadAccounts(DbContext).ToList

                Me.RadComboBoxOverheadSet.DataTextField = "Description"
                Me.RadComboBoxOverheadSet.DataValueField = "Code"
                Me.RadComboBoxOverheadSet.DataSource = (From Entity In AdvantageFramework.Database.Procedures.OverheadAccount.LoadDistinctOverheadAccounts(DbContext)
                                                        Select Entity.Code,
                                                            Entity.Description).ToList.Select(Function(Overhead) New With {.Code = Overhead.Code,
                                                                                                                    .Description = Overhead.Code & " - " & Overhead.Description}).ToList
                Me.RadComboBoxOverheadSet.DataBind()

                Try
                    Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                    Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Catch ex As Exception
                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                Try

                    RadComboBoxStart.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)

                Catch ex As Exception

                End Try

                Try

                    RadComboBoxEnd.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)

                Catch ex As Exception

                End Try

                Try

                    RadComboBoxEnd.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.OverheadSet.ToString)

                Catch ex As Exception

                End Try

                RadioButtonStandard.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.Type.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.Type.ToString) = 1, True, False)
                RadioButtonAlternate.Checked = Not Me.RadioButtonStandard.Checked
                CheckBoxOffice.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = 1, True, False)
                CheckBoxClient.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeClient.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeClient.ToString) = 1, True, False)
                CheckBoxDivision.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeDivision.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeDivision.ToString) = 1, True, False)
                CheckBoxProduct.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProduct.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProduct.ToString) = 1, True, False)
                CheckBoxType.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeType.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeType.ToString) = 1, True, False)
                CheckBoxSalesClass.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeSalesClass.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeSalesClass.ToString) = 1, True, False)
                CheckBoxPostPeriod.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludePostPeriod.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludePostPeriod.ToString) = 1, True, False)
                CheckBoxYear.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeYear.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeYear.ToString) = 1, True, False)
                CheckBoxCampaign.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCampaign.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCampaign.ToString) = 1, True, False)
                CheckBoxAccountExecutive.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeAE.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeAE.ToString) = 1, True, False)
                CheckBoxProductUDF.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProductUDF.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProductUDF.ToString) = 1, True, False)
                CheckBoxManualInvoice.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeManualInvoices.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeManualInvoices.ToString) = 1, True, False)
                CheckBoxGLEntries.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeGLEntries.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeGLEntries.ToString) = 1, True, False)
                CheckBoxBilledIncomeRecognized.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeBilledIncomeRecognized.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeBilledIncomeRecognized.ToString) = 1, True, False)
                RadioButtonFTE.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.FTEAllocation.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.FTEAllocation.ToString) = 1, True, False)
                RadioButtonOverhead.Checked = Not Me.RadioButtonFTE.Checked
                RadioButtonHours.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.HoursCost.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.HoursCost.ToString) = 1, True, False)
                RadioButtonCost.Checked = Not Me.RadioButtonHours.Checked
                RadioButtonBreakout.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.CoopOption.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.CoopOption.ToString) = 1, True, False)
                RadioButtonCombine.Checked = Not Me.RadioButtonBreakout.Checked
                CheckBoxExcludeNewBusiness.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.ExcludeNewBusiness.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.ExcludeNewBusiness.ToString) = 1, True, False)

            Else

                RadioButtonStandard.Checked = True
                RadioButtonAlternate.Checked = False
                CheckBoxOffice.Checked = True
                CheckBoxClient.Checked = True
                CheckBoxDivision.Checked = True
                CheckBoxProduct.Checked = True
                CheckBoxType.Checked = True
                CheckBoxSalesClass.Checked = True
                CheckBoxPostPeriod.Checked = True
                CheckBoxYear.Checked = True
                CheckBoxCampaign.Checked = True
                CheckBoxAccountExecutive.Checked = True
                CheckBoxProductUDF.Checked = True
                CheckBoxManualInvoice.Checked = True
                CheckBoxGLEntries.Checked = True
                CheckBoxBilledIncomeRecognized.Checked = True
                RadioButtonFTE.Checked = False
                RadioButtonOverhead.Checked = True
                RadioButtonHours.Checked = False
                RadioButtonCost.Checked = True
                RadioButtonBreakout.Checked = False
                RadioButtonCombine.Checked = True
                CheckBoxDirectExpenseOperatingOnly.Checked = True

            End If

            PanelCDP.Visible = False

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

                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString) = RadComboBoxStart.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString) = RadComboBoxEnd.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.Type.ToString) = If(RadioButtonStandard.Checked, 1, 0)
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = CheckBoxOffice.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeClient.ToString) = CheckBoxClient.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeDivision.ToString) = CheckBoxDivision.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProduct.ToString) = CheckBoxProduct.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeType.ToString) = CheckBoxType.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeSalesClass.ToString) = CheckBoxSalesClass.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludePostPeriod.ToString) = CheckBoxPostPeriod.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeYear.ToString) = CheckBoxYear.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCampaign.ToString) = CheckBoxCampaign.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeAE.ToString) = CheckBoxAccountExecutive.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProductUDF.ToString) = CheckBoxProductUDF.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeManualInvoices.ToString) = CheckBoxManualInvoice.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeGLEntries.ToString) = CheckBoxGLEntries.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeBilledIncomeRecognized.ToString) = CheckBoxBilledIncomeRecognized.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.FTEAllocation.ToString) = If(RadioButtonFTE.Checked, 1, 2)
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.HoursCost.ToString) = If(RadioButtonHours.Checked, 1, 2)
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.CoopOption.ToString) = If(RadioButtonBreakout.Checked, 1, 2)
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.OverheadSet.ToString) = RadComboBoxOverheadSet.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.UserId.ToString) = Session("UserCode")
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.ExcludeNewBusiness.ToString) = CheckBoxExcludeNewBusiness.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCREntries.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.DirectExpenseFromExpenseOperatingOnly.ToString) = CheckBoxDirectExpenseOperatingOnly.Checked

                    Dim OfficeCodesList As Generic.List(Of String) = Nothing
                    Dim ClientCodesList As Generic.List(Of String) = Nothing
                    Dim DivisionCodesList As Generic.List(Of String) = Nothing
                    Dim ProductCodesList As Generic.List(Of String) = Nothing

                    If RadioButtonAllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedOffices.ToString) = Nothing

                    Else

                        If RadGridOffice.Items.Count > 0 Then
                            OfficeCodesList = New Generic.List(Of String)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                                If gridDataItem.Selected = True Then
                                    OfficeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
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

                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedClients.ToString) = ClientCodesList
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedDivisions.ToString) = DivisionCodesList
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedProducts.ToString) = ProductCodesList

                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriod1Code.ToString) = String.Empty
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriod1Code.ToString) = String.Empty
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriod2Code.ToString) = String.Empty
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriod2Code.ToString) = String.Empty

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
        Try
            Dim current As String
            Dim m As Integer
            Dim y As Integer
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                current = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                If current <> "" Then
                    m = CInt(current.Substring(4, 2))
                    y = CInt(current.Substring(0, 4)) - 1
                End If
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, m, y.ToString).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadButton2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2Years.Click
        Try
            Dim current As String
            Dim m As Integer
            Dim y As Integer
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                current = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                If current <> "" Then
                    m = CInt(current.Substring(4, 2))
                    y = CInt(current.Substring(0, 4)) - 2
                End If
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, m, y.ToString).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadButtonMTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonMTD.Click
        Try
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadButtonYTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonYTD.Click
        Try
            Dim current As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim m As Integer
            Dim y As Integer
            Dim pp As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                current = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                pp = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, current.Year)
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, pp.Month.GetValueOrDefault(1), pp.Year.ToString).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadButton2YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2YTD.Click
        Try
            Dim current As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim m As Integer
            Dim y As Integer
            Dim pp As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                current = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                pp = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, current.Year)
                Me.RadComboBoxStart.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, pp.Month.GetValueOrDefault(1), CInt(pp.Year) - 1).ToString
                Me.RadComboBoxEnd.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).ToString
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadioButtonFTE_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFTE.CheckedChanged
        If RadioButtonFTE.Checked = True Then
            Me.RadComboBoxOverheadSet.Enabled = False
        End If
    End Sub
    Private Sub RadioButtonOverhead_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonOverhead.CheckedChanged
        If RadioButtonOverhead.Checked = True Then
            Me.RadComboBoxOverheadSet.Enabled = True
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

#End Region

#End Region


End Class
