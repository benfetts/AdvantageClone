Public Class Reporting_InitialLoadingOpenPurchaseOrderDetail
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

    Private Sub LoadClients()

        Dim Division As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
        Dim Product As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Count > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    Division = AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                    Product = AdvantageFramework.Database.Procedures.Product.LoadCoreByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False).ToList
                End Using

                RadListBoxClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList
                                                Join d In Division On Item.Code Equals d.ClientCode
                                                Join p In Product On d.ClientCode Equals p.ClientCode And d.Code Equals p.DivisionCode
                                                Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList On p.OfficeCode Equals EmpOffice.OfficeCode
                                                Select [Code] = Item.Code,
                                                       [Name] = Item.ToString Distinct)

            Else

                RadListBoxClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList
                                                Select [Code] = Item.Code,
                                                       [Name] = Item.ToString)

            End If

            RadListBoxClients.DataBind()

        End Using

    End Sub
    Private Sub LoadClientDivisions()

        Dim Division As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
        Dim Product As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Count > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    Division = AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                    Product = AdvantageFramework.Database.Procedures.Product.LoadCoreByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False).ToList
                End Using

                RadListBoxClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.DivisionView.Load(DbContext).ToList
                                                Join p In Product On Item.ClientCode Equals p.ClientCode And Item.DivisionCode Equals p.DivisionCode
                                                Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList On p.OfficeCode Equals EmpOffice.OfficeCode
                                                Where Item.ClientActiveFlag = 1
                                                Select Item.ClientCode,
                                                       Item.ClientName,
                                                       Item.DivisionCode,
                                                       Item.DivisionName Distinct).ToList.Select(Function(Div) New With {.Code = Div.ClientCode & "/" & Div.DivisionCode,
                                                                                                                .Name = Div.ClientName & "/" & Div.DivisionName}).ToList

            Else

                RadListBoxClients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.DivisionView.Load(DbContext)
                                                Where Entity.ClientActiveFlag = 1
                                                Select Entity.ClientCode,
                                                   Entity.ClientName,
                                                   Entity.DivisionCode,
                                                   Entity.DivisionName).ToList.Select(Function(Div) New With {.Code = Div.ClientCode & "/" & Div.DivisionCode,
                                                                                                              .Name = Div.ClientName & "/" & Div.DivisionName}).ToList

            End If



            RadListBoxClients.DataBind()

        End Using

    End Sub
    Private Sub LoadClientDivisionProducts()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Count > 0 Then

                    RadListBoxClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.ProductView.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                    Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList On Item.OfficeCode Equals EmpOffice.OfficeCode
                                                    Where Item.ClientActiveFlag = 1 AndAlso
                                                          Item.DivisionActiveFlag = 1
                                                    Select Item.ClientCode,
                                                           Item.ClientName,
                                                           Item.DivisionCode,
                                                           Item.DivisionName,
                                                           Item.ProductCode,
                                                           Item.ProductDescription).ToList.Select(Function(Prod) New With {.Code = Prod.ClientCode & "/" & Prod.DivisionCode & "/" & Prod.ProductCode,
                                                                                                                       .Name = Prod.ClientName & "/" & Prod.DivisionName & "/" & Prod.ProductDescription}).ToList

                Else

                    RadListBoxClients.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ProductView.LoadAllActive(DbContext)
                                                    Where Entity.ClientActiveFlag = 1 AndAlso
                                                      Entity.DivisionActiveFlag = 1
                                                    Select Entity.ClientCode,
                                                       Entity.ClientName,
                                                       Entity.DivisionCode,
                                                       Entity.DivisionName,
                                                       Entity.ProductCode,
                                                       Entity.ProductDescription).ToList.Select(Function(Prod) New With {.Code = Prod.ClientCode & "/" & Prod.DivisionCode & "/" & Prod.ProductCode,
                                                                                                                     .Name = Prod.ClientName & "/" & Prod.DivisionName & "/" & Prod.ProductDescription}).ToList

                End If

                RadListBoxClients.DataBind()

            End Using

        End Using

    End Sub

    Private Sub LoadVendors()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadListBoxVendors.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).ToList
                                            Select [Code] = Entity.Code,
                                                                 [Name] = Entity.Name
                                            Distinct).ToList
            RadListBoxVendors.DataBind()

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoading_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday
            RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday

            CheckBoxIncludeClosedPOs.Visible = True

        End If


    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Dim CDPString As String

                Dim clients As New System.Collections.Generic.List(Of String)
                Dim divisions As New System.Collections.Generic.List(Of String)
                Dim products As New System.Collections.Generic.List(Of String)

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POStartDate.ToString) = RadDatePickerFrom.SelectedDate
                _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POEndDate.ToString) = RadDatePickerTo.SelectedDate
                _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.IncludeClosedPOs.ToString) = If(CheckBoxIncludeClosedPOs.Checked, 1, 0)
                _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.IncludeVoidedPOs.ToString) = If(CheckBoxIncludeVoidedPOs.Checked, 1, 0)
                _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.IncludeClientPOs.ToString) = If(CheckBoxIncludeClientPOs.Checked, 1, 0)
                _ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.IncludeNonClientPOs.ToString) = If(CheckBoxIncludeNonClientPOs.Checked, 1, 0)

                If RadButtonAllClients.Checked Then

                    Session("OpenPurchaseOrderDetail_SelectedClients") = Nothing
                    Session("OpenPurchaseOrderDetail_SelectedDivisions") = Nothing
                    Session("OpenPurchaseOrderDetail_SelectedProducts") = Nothing

                Else

                    If RadButtonChooseClients.Checked = True Then
                        Session("OpenPurchaseOrderDetail_SelectedClients") = (From RadListBoxItem In RadListBoxClients.SelectedItems
                                                                              Select RadListBoxItem.Value).ToList
                        Session("OpenPurchaseOrderDetail_SelectedDivisions") = Nothing
                        Session("OpenPurchaseOrderDetail_SelectedProducts") = Nothing
                    End If
                    If RadButtonChooseClientDivision.Checked = True Then
                        Session("OpenPurchaseOrderDetail_SelectedClients") = (From RadListBoxItem In RadListBoxClients.SelectedItems
                                                                              Select RadListBoxItem.Value).ToList

                        CDPString = Join(Session("OpenPurchaseOrderDetail_SelectedClients").ToArray, ",")

                        Dim CD() As String = CDPString.Split(",")
                        If CD.Count > 0 Then
                            For i As Integer = 0 To CD.Count - 1
                                If CD(i) <> "" Then
                                    Dim division() As String = CD(i).Split("/")
                                    clients.Add(division(0))
                                    divisions.Add(division(0) & "|" & division(1))
                                End If
                            Next
                        End If

                        Session("OpenPurchaseOrderDetail_SelectedClients") = Nothing 'clients
                        Session("OpenPurchaseOrderDetail_SelectedDivisions") = divisions
                        Session("OpenPurchaseOrderDetail_SelectedProducts") = Nothing

                    End If
                    If RadButtonChooseClientDivisionProduct.Checked = True Then
                        Session("OpenPurchaseOrderDetail_SelectedClients") = (From RadListBoxItem In RadListBoxClients.SelectedItems
                                                                              Select RadListBoxItem.Value).ToList

                        CDPString = Join(Session("OpenPurchaseOrderDetail_SelectedClients").ToArray, ",")

                        Dim CDP() As String = CDPString.Split(",")
                        If CDP.Count > 0 Then
                            For i As Integer = 0 To CDP.Count - 1
                                If CDP(i) <> "" Then
                                    Dim product() As String = CDP(i).Split("/")
                                    clients.Add(product(0))
                                    divisions.Add(product(1))
                                    products.Add(product(0) & "|" & product(1) & "|" & product(2))
                                End If
                            Next
                        End If

                        Session("OpenPurchaseOrderDetail_SelectedClients") = Nothing 'clients
                        Session("OpenPurchaseOrderDetail_SelectedDivisions") = Nothing 'divisions
                        Session("OpenPurchaseOrderDetail_SelectedProducts") = products

                    End If

                End If

                If RadButtonAllVendors.Checked Then

                    Session("OpenPurchaseOrderDetail_SelectedVendors") = Nothing

                Else

                    Session("OpenPurchaseOrderDetail_SelectedVendors") = (From RadListBoxItem In RadListBoxVendors.SelectedItems
                                                                          Select RadListBoxItem.Value).ToList

                End If

                _ParameterDictionary("OpenPurchaseOrderDetail_SelectedClients") = Session("OpenPurchaseOrderDetail_SelectedClients")
                _ParameterDictionary("OpenPurchaseOrderDetail_SelectedDivisions") = Session("OpenPurchaseOrderDetail_SelectedDivisions")
                _ParameterDictionary("OpenPurchaseOrderDetail_SelectedProducts") = Session("OpenPurchaseOrderDetail_SelectedProducts")
                _ParameterDictionary("OpenPurchaseOrderDetail_SelectedVendors") = Session("OpenPurchaseOrderDetail_SelectedVendors")


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


    Private Sub RadButtonAllClients_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonAllClients.CheckedChanged

        RadListBoxClients.Enabled = RadButtonChooseVendors.Checked

    End Sub
    Private Sub RadButtonChooseClients_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseClients.CheckedChanged

        If RadButtonChooseClients.Checked Then

            RadListBoxClients.Enabled = True

            LoadClients()

        End If

    End Sub
    Private Sub RadButtonChooseClientDivisions_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseClientDivision.CheckedChanged

        If RadButtonChooseClientDivision.Checked Then

            RadListBoxClients.Enabled = True

            LoadClientDivisions()

        End If

    End Sub
    Private Sub RadButtonChooseClientDivsionProducts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonChooseClientDivisionProduct.CheckedChanged

        If RadButtonChooseClientDivisionProduct.Checked Then

            RadListBoxClients.Enabled = True

            LoadClientDivisionProducts()

        End If

    End Sub

    Private Sub RadButtonChooseVendors_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonChooseVendors.CheckedChanged

        If RadButtonChooseVendors.Checked = True Then

            RadListBoxVendors.Enabled = True

            LoadVendors()

        End If

    End Sub

    Private Sub RadButtonAllVendors_CheckedChanged(sender As Object, e As EventArgs) Handles RadButtonAllVendors.CheckedChanged

        If RadButtonAllVendors.Checked = True Then

            RadListBoxVendors.Enabled = False

        End If

    End Sub

    Private Sub CheckBoxIncludeClosedPOs_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeClosedPOs.CheckedChanged
        If CheckBoxIncludeClosedPOs.Checked = True Then
            CheckBoxIncludeVoidedPOs.Enabled = True
        Else
            CheckBoxIncludeVoidedPOs.Enabled = False
            CheckBoxIncludeVoidedPOs.Checked = False
        End If
    End Sub

    Private Sub CheckBoxIncludeClientPOs_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeClientPOs.CheckedChanged
        If CheckBoxIncludeClientPOs.Checked = True Then
            Me.RadListBoxClients.Enabled = True
            Me.RadButtonAllClients.Enabled = True
            Me.RadButtonChooseClients.Enabled = True
            Me.RadButtonChooseClientDivision.Enabled = True
            Me.RadButtonChooseClientDivisionProduct.Enabled = True
        Else
            Me.RadListBoxClients.Enabled = False
            Me.RadButtonAllClients.Enabled = False
            Me.RadButtonChooseClients.Enabled = False
            Me.RadButtonChooseClientDivision.Enabled = False
            Me.RadButtonChooseClientDivisionProduct.Enabled = False
        End If
    End Sub

#End Region

#End Region

End Class
