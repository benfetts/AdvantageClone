Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class LookUp_Quick
    Inherits Webvantage.BaseLookupPage

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

    Private FromForm As String = ""
    Private CurrType As String = ""
    Private Office As String = ""
    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private Vendor As String = ""
    Private Job As Integer = 0
    Private JobComp As Integer = 0
    Private Control As String = ""
    Private EmpCode As String = ""
    Private Campaign As String = ""
    Private SectionDiv As String = ""
    Private SectionPrd As String = ""
    Private _AutoSearch As Boolean = True

    Private DefaultClientControlPrefix As String = "CallingWindowContent.document.getElementById('_ctl0_ContentPlaceHolderMain_"

#Region " Page "

    Private Sub LookUp_Quick_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.SetLookupGrid(Me.RadGridLookup)

        Try
            Me.OpenerRadWindowName = Request.QueryString("opener")
        Catch ex As Exception
            Me.OpenerRadWindowName = ""
        End Try
        Try
            FromForm = Request.QueryString("form")
            Session("fromForm") = Request.QueryString("Form")
        Catch ex As Exception
            Me.FromForm = ""
        End Try
        Try
            If Me.FromForm = Nothing Then
                Me.FromForm = ""
            End If
        Catch ex As Exception
            Me.FromForm = ""
        End Try
        If Me.FromForm.Trim() = "" Then
            Try
                FromForm = Request.QueryString("fromform")
            Catch ex As Exception
                FromForm = ""
            End Try
        End If
        Try
            CurrType = Request.QueryString("type")
        Catch ex As Exception
        End Try
        Try
            Control = Request.QueryString("control")
        Catch ex As Exception
            Control = ""
        End Try
        Try
            If Not Me.Control = Nothing Then
                If Me.Control.Trim() <> "" Then
                    Me.DefaultClientControlPrefix = "CallingWindowContent.document.getElementById('" & MiscFN.ParseClientIDPrefix(Me.Control.Trim())
                End If
            End If
        Catch ex As Exception
            Me.DefaultClientControlPrefix = "CallingWindowContent.document.getElementById('_ctl0_ContentPlaceHolderMain_"
        End Try
        Try
            Office = Request.QueryString("office")
        Catch ex As Exception
            Office = ""
        End Try
        Try
            Me.Client = Request.QueryString("client")
        Catch ex As Exception
            Me.Client = ""
        End Try
        Try
            Division = Request.QueryString("division")
        Catch ex As Exception
            Division = ""
        End Try
        Try
            Product = Request.QueryString("product")
        Catch ex As Exception
            Product = ""
        End Try
        Try
            Vendor = Request.QueryString("vendor")
        Catch ex As Exception
            Vendor = ""
        End Try
        Try
            If IsNumeric(Request.QueryString("job")) = True Then
                Job = CInt(Request.QueryString("job"))
            End If
        Catch ex As Exception
            Job = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("job")) = True Then
                Job = CInt(Request.QueryString("job"))
            End If
        Catch ex As Exception
            Job = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("jobcomp")) = True Then
                JobComp = CInt(Request.QueryString("jobcomp"))
            End If
        Catch ex As Exception
            JobComp = 0
        End Try
        Try
            EmpCode = Request.QueryString("emp")
        Catch ex As Exception
            EmpCode = ""
        End Try
        Try
            Campaign = Request.QueryString("campaign")
        Catch ex As Exception
            Campaign = ""
        End Try
        Try
            SectionDiv = Request.QueryString("sectiondiv")
        Catch ex As Exception
            SectionDiv = ""
        End Try
        Try
            SectionPrd = Request.QueryString("sectionprd")
        Catch ex As Exception
            SectionPrd = ""
        End Try

        If Not Request.QueryString("autoSearch") Is Nothing Then

            _AutoSearch = CBool(Request.QueryString("autoSearch"))

        End If

        'Try
        '    CalledFrom = Request.QueryString("calledfrom")
        'Catch ex As Exception
        '    CalledFrom = ""
        'End Try
    End Sub

    Protected Sub LookUp_Quick_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.IsPostBack = False And Me.IsCallback = False Then
            Try
                Select Case Request.QueryString("form")
                    Case "docmgr"
                        If CurrType = "client" Then
                            Me.CheckboxClosedJobs.Visible = True
                            Me.CheckboxClosedJobs.Text = "Show Inactive Clients?"
                        ElseIf CurrType = "divisionjj" Then
                            Me.CheckboxClosedJobs.Visible = True
                            Me.CheckboxClosedJobs.Text = "Show Inactive Divisions?"
                        ElseIf CurrType = "campaignfilter" Then
                            Me.CheckboxClosedJobs.Visible = False
                            Me.CheckboxClosedJobs.Text = "Show Closed Campaigns?"
                        ElseIf CurrType = "empcodeall" Then
                            Me.CheckboxClosedJobs.Visible = True
                            Me.CheckboxClosedJobs.Text = "Show Terminated Employees?"
                        End If
                    Case "explookup"
                        If CurrType = "expempcode" Then
                            Me.CheckboxClosedJobs.Visible = True
                            Me.CheckboxClosedJobs.Text = "Show Terminated Employees?"
                        End If
                    Case Else
                        If Me.CheckboxClosedJobs.Checked = True Then Me.CheckboxClosedJobs.Checked = False
                        If Me.CheckboxClosedJobs.Visible = True Then Me.CheckboxClosedJobs.Visible = False
                End Select
            Catch ex As Exception
            End Try
        End If

    End Sub

    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)
        Try

            Dim oGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
            MyBase.RaisePostBackEvent(sourceControl, eventArgument)
            If sourceControl Is RadGridLookup AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") > -1) Then
                oGridDataItem = RadGridLookup.Items(Integer.Parse(eventArgument.Split(":"c)(1)))
                If oGridDataItem IsNot Nothing Then
                    oGridDataItem.Selected = True

                    Me.SelectItem()

                End If
            End If
            If sourceControl Is RadGridLookup AndAlso (eventArgument.IndexOf("IndexOfRowClicked") > -1) Then
                oGridDataItem = RadGridLookup.Items(Integer.Parse(eventArgument.Split(":"c)(1)))
                If oGridDataItem IsNot Nothing Then
                    oGridDataItem.Selected = True
                End If
            End If

        Catch ex As Exception

            If ex.Message.ToString().Contains("Invalid attempt to call FieldCount when reader is closed") = True Then

                Me.ShowMessage("You cannot search the data before the data is loaded")

            Else

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

            End If

            Me.CloseThisWindow()

        End Try


    End Sub

#End Region

#Region " Grid "

    Private Sub RadGridLookup_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridLookup.ItemCommand
        Select Case e.CommandName
            Case "Filter"
                Try
                    Dim filteringItem As GridFilteringItem = DirectCast(RadGridLookup.MasterTableView.GetItems(GridItemType.FilteringItem)(0), GridFilteringItem)
                    Dim box As System.Web.UI.WebControls.TextBox = TryCast(filteringItem("GridBoundColumnDescription").Controls(0), TextBox)
                    Me.Page.ClientScript.RegisterStartupScript(Me.GetType(), "justfocus", "SetCursorToTextEnd('" & box.ClientID & "');", True)
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Sub RadGridLookup_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridLookup.PreRender
        Try
            If Not Me.IsPostBack And Not Me.IsCallback Then
                Dim filteringItem As GridFilteringItem = DirectCast(RadGridLookup.MasterTableView.GetItems(GridItemType.FilteringItem)(0), GridFilteringItem)
                Dim box As System.Web.UI.WebControls.TextBox = TryCast(filteringItem("GridBoundColumnDescription").Controls(0), TextBox)
                Me.Page.ClientScript.RegisterStartupScript(Me.GetType(), "justfocus", "SetCursorToTextEnd('" & box.ClientID & "');", True)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridLookup_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridLookup.NeedDataSource
        Me.LoadLookup()
    End Sub

#End Region

#Region " Data "

    Private Sub LoadLookup()

        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        Try

            Select Case CurrType
                Case "empcode"
                    Me.RadGridLookup.DataSource = oDD.GetEmployees(CStr(Session("UserCode")))
                Case "expempcode"

                    If Me.CheckboxClosedJobs.Visible = True Then Me.CheckboxClosedJobs.Text = "Show Terminated Employees?"

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                            If Me.CheckboxClosedJobs.Visible AndAlso Me.CheckboxClosedJobs.Checked Then

                                Me.RadGridLookup.DataSource = (From Entity In AdvantageFramework.ExpenseReports.LoadExpenseEmployees(_Session, DbContext, SecurityDbContext, True)
                                                               Select New With {.Code = Entity.Code,
                                                                                .Description = Entity.Code & " - " & Entity.LastName & ", " & Entity.FirstName & If(Entity.TerminationDate.HasValue, " [TERMINATED]", "")}).ToList


                            Else

                                Me.RadGridLookup.DataSource = (From Entity In AdvantageFramework.ExpenseReports.LoadExpenseEmployees(_Session, DbContext, SecurityDbContext, False)
                                                               Select New With {.Code = Entity.Code,
                                                                                .Description = Entity.Code & " - " & Entity.LastName & ", " & Entity.FirstName}).ToList

                            End If

                        End Using

                    End Using

                Case "empcodeall"
                    If CheckboxClosedJobs.Visible Then
                        Me.RadGridLookup.DataSource = oDD.GetEmployees(CStr(Session("UserCode")), CheckboxClosedJobs.Checked)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetEmployees(CStr(Session("UserCode")), True)
                    End If
                Case "empns"
                    Me.RadGridLookup.DataSource = oDD.GetEmployees(CStr(Session("UserCode")), False, True)
                Case "managers"
                    Me.RadGridLookup.DataSource = oDD.GetManagers(CStr(Session("UserCode")))
                Case "polist"
                    Me.RadGridLookup.DataSource = oDD.GetPOList("False", "False", Session("UserID"))
                Case "client"
                    If Me.CheckboxClosedJobs.Visible = True Then Me.CheckboxClosedJobs.Text = "Show Inactive Clients?"
                    If Office = "" Then
                        If Me.CheckboxClosedJobs.Visible = True And Me.CheckboxClosedJobs.Checked = True Then
                            Me.RadGridLookup.DataSource = oDD.GetFilterClientList(CStr(Session("UserCode")))
                        Else
                            Me.RadGridLookup.DataSource = oDD.GetClientList(CStr(Session("UserCode")))
                        End If
                    Else
                        If Me.CheckboxClosedJobs.Visible = True And Me.CheckboxClosedJobs.Checked = True Then
                            Me.RadGridLookup.DataSource = oDD.GetFilterClientList(CStr(Session("UserCode")), Office)
                        Else
                            Me.RadGridLookup.DataSource = oDD.GetClientList(CStr(Session("UserCode")), Office)
                        End If
                    End If
                Case "clientts"
                    Me.RadGridLookup.DataSource = oDD.GetClientListTS(CStr(Session("UserCode")), "ts")
                Case "division"
                    If Me.Client.Trim() = "" And Me.Division.Trim = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetDivisionList(CStr(Session("UserCode")), "")
                    ElseIf Me.Client.Trim() = "" And Me.Division.Trim <> "" Then
                        Me.RadGridLookup.DataSource = oDD.GetDivisionList(CStr(Session("UserCode")), "")
                    Else
                        If Me.IsClientPortal = True Then
                            Me.RadGridLookup.DataSource = oDD.GetDivisionListCP(CStr(Session("UserID")), Me.Client)
                        Else
                            Me.RadGridLookup.DataSource = oDD.GetDivisionList(CStr(Session("UserCode")), Me.Client)
                        End If
                    End If
                Case "divisionjj"
                    If Me.CheckboxClosedJobs.Visible = True Then Me.CheckboxClosedJobs.Text = "Show Inactive Divisions?"
                    If Me.CheckboxClosedJobs.Visible = True And Me.CheckboxClosedJobs.Checked = True Then
                        Me.RadGridLookup.DataSource = oDD.GetFilterDivisionList(CStr(Session("UserCode")), Me.Client)
                    Else
                        If Me.IsClientPortal = True Then
                            Me.RadGridLookup.DataSource = oDD.GetDivisionListCP(CStr(Session("UserID")), Me.Client)
                        Else
                            Me.RadGridLookup.DataSource = oDD.GetDivisionList(CStr(Session("UserCode")), Me.Client)
                        End If
                    End If
                Case "divisionts"
                    Me.RadGridLookup.DataSource = oDD.GetDivisionListTS(CStr(Session("UserCode")), Me.Client, "ts")
                Case "product"
                    If Me.IsClientPortal = True Then
                        Me.RadGridLookup.DataSource = oDD.GetProductListCP(CStr(Session("UserID")), Me.Client, Division)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetProductList(CStr(Session("UserCode")), Me.Client, Division)
                    End If
                Case "productts"
                    Me.RadGridLookup.DataSource = oDD.GetProductListTS(CStr(Session("UserCode")), Me.Client, Division, "ts")
                Case "job"
                    If Office.Length > 0 Then
                        If Me.CheckboxClosedJobs.Checked Then
                            Me.RadGridLookup.DataSource = oDD.GetJobListFilteredByOffice(CStr(Session("UserCode")), Office, 1)
                        Else
                            Me.RadGridLookup.DataSource = oDD.GetJobListFilteredByOffice(CStr(Session("UserCode")), Office, 0)
                        End If
                    Else
                        If Me.CheckboxClosedJobs.Checked Then
                            If Me.Client.Length < 1 And Division.Length < 1 And Product.Length < 1 Then
                                Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.General, True)
                            Else
                                Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Me.Client, Division, Product, JobListType.Traffic, True)
                            End If
                        Else
                            If Me.Client.Length < 1 And Division.Length < 1 And Product.Length < 1 Then
                                Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.General)
                            Else
                                Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Me.Client, Division, Product, JobListType.Traffic)
                            End If
                        End If
                    End If
                Case "jobtraffic"
                    If Me.Client.Length < 1 And Division.Length < 1 And Product.Length < 1 Then
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.General)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Me.Client, Division, Product, JobListType.Traffic)
                    End If
                Case "jobcomp"
                    Me.RadGridLookup.DataSource = oDD.GetJobCompList(CStr(Session("UserCode")), Me.Client, Division, Product, Job)
                Case "jobcomptimeline"
                    Me.RadGridLookup.DataSource = oDD.GetJobCompListTimeline(Client, Division, Product, Job)
                Case "task"
                    Me.RadGridLookup.DataSource = oDD.GetTasks()
                Case "statuscodes"
                    Me.RadGridLookup.DataSource = oDD.GetTrafficCodes()
                Case "funccat"
                    If Job < 1 Then
                        Me.RadGridLookup.DataSource = oDD.GetCategories()
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetFunctionsByUserID(CStr(Session("UserCode")))
                    End If
                Case "funccatall"
                    Me.RadGridLookup.DataSource = oDD.GetFunctionsAll()
                Case "funccatwithemp"
                    If Job < 1 Then
                        Me.RadGridLookup.DataSource = oDD.GetCategories
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetFunctionsByEmpCode(Request.QueryString("emp"))
                    End If
                Case "funccatwithvndr"
                    Me.RadGridLookup.DataSource = oDD.GetFunctionsVendor(CStr(Session("UserCode")))
                Case "funcest"
                    Me.RadGridLookup.DataSource = oDD.GetFunctionsAllEst()
                Case "roles"
                    Me.RadGridLookup.DataSource = oDD.GetRoles()
                Case "office"
                    Me.RadGridLookup.DataSource = oDD.GetOfficesEmp(CStr(Session("UserCode")))
                Case "campaign"
                    Me.RadGridLookup.DataSource = oDD.GetCampaigns(Product, Session("UserCode"))
                Case "productcategory"
                    Me.RadGridLookup.DataSource = oDD.ddProductCategory(Client, Division, Product)
                Case "accountexec"
                    Me.RadGridLookup.DataSource = oDD.GetAccountExecutive(Client, Division, Product, Session("UserCodE"))
                Case "contact"
                    Me.RadGridLookup.DataSource = oDD.GetProductContact(Client, Division, Product)
                Case "campaign2" 'didn't want to disturb case:campaign above
                    Me.RadGridLookup.DataSource = oDD.ddCampaign(Session("UserCode"), Me.Client, Division, Product)
                Case "campaignjobnew" 'didn't want to disturb case:campaign above
                    Me.RadGridLookup.DataSource = oDD.ddCampaign(Session("UserCode"), Me.Client, Division, Product)
                Case "campaignmedcal"
                    Me.RadGridLookup.DataSource = oDD.GetCampaignsMediaCal(Session("UserCode"), Me.Client, Division, Product)
                Case "campaignfilter" 'didn't want to disturb case:campaign above
                    Dim InclClosed As Integer = 0
                    If Me.CheckboxClosedJobs.Checked = True Then
                        InclClosed = 1
                    End If
                    Me.RadGridLookup.DataSource = oDD.ddCampaignFilter(Session("UserCode"), Me.Client, Division, Product, InclClosed)
                Case "campaignfilterjob" 'didn't want to disturb case:campaign above
                    Dim InclClosed As Integer = 0
                    If Me.CheckboxClosedJobs.Checked = True Then
                        InclClosed = 1
                    End If
                    Me.RadGridLookup.DataSource = oDD.ddFilterCampaignFilter(Session("UserCode"), Me.Client, Division, Product, InclClosed)
                Case "coopbilling"
                    Me.RadGridLookup.DataSource = oDD.ddCoopBilling()
                Case "salesclassformat"
                    Dim strSalesClass As String = ""
                    strSalesClass = Request.QueryString("salesclass")
                    Me.RadGridLookup.DataSource = oDD.ddSalesClassFormat(strSalesClass)
                Case "complexity"
                    Me.RadGridLookup.DataSource = oDD.ddComplexity()
                Case "promotion"
                    Me.RadGridLookup.DataSource = oDD.ddPromotion()
                Case "jobtype"
                    Dim str As String = ""

                    If Request.QueryString.AllKeys.Any(Function(item) item = "sc") Then ' Coming from JobTemplate.aspx, use whatever is in the SC input rather than what is saved.

                        Try

                            str = Request.QueryString("sc")

                        Catch ex As Exception
                            str = ""
                        End Try

                    ElseIf Job <> 0 Then
                        Dim j As New JOB_LOG(Session("ConnString"))
                        If j.LoadByPrimaryKey(Job) Then
                            str = j.SC_CODE
                        End If
                    End If
                    Me.RadGridLookup.DataSource = oDD.ddJobType(str)

                Case "deptteam"
                    Me.RadGridLookup.DataSource = oDD.ddDeptTeam()
                Case "adnumber"
                    If Me.Client.Length < 1 Then
                        Me.RadGridLookup.DataSource = oDD.ddAdNumber()
                    Else
                        Me.RadGridLookup.DataSource = oDD.ddAdNumberwithClient(Client)
                    End If
                Case "expinv"
                    Me.RadGridLookup.DataSource = oDD.ddExpInv(EmpCode)
                Case "market"
                    Me.RadGridLookup.DataSource = oDD.ddMarket()
                Case "taxcodes"
                    Me.RadGridLookup.DataSource = oDD.ddTaxCodes()
                Case "salesclass"
                    Me.RadGridLookup.DataSource = oDD.GetSalesClass()
                Case "JobUD1"
                    Me.RadGridLookup.DataSource = oDD.GetJobUDF1()
                Case "JobUD2"
                    Me.RadGridLookup.DataSource = oDD.GetJobUDF2()
                Case "JobUD3"
                    Me.RadGridLookup.DataSource = oDD.GetJobUDF3()
                Case "JobUD4"
                    Me.RadGridLookup.DataSource = oDD.GetJobUDF4()
                Case "JobUD5"
                    Me.RadGridLookup.DataSource = oDD.GetJobUDF5()
                Case "JCUD1"
                    Me.RadGridLookup.DataSource = oDD.GetJCUDF1()
                Case "JCUD2"
                    Me.RadGridLookup.DataSource = oDD.GetJCUDF2()
                Case "JCUD3"
                    Me.RadGridLookup.DataSource = oDD.GetJCUDF3()
                Case "JCUD4"
                    Me.RadGridLookup.DataSource = oDD.GetJCUDF4()
                Case "JCUD5"
                    Me.RadGridLookup.DataSource = oDD.GetJCUDF5()
                Case "acctnum"
                    Me.RadGridLookup.DataSource = oDD.GetAccountNumber()
                Case "fiscalperiod"
                    Me.RadGridLookup.DataSource = oDD.GetFiscalPeriod()
                Case "blackplt"
                    Me.RadGridLookup.DataSource = oDD.GetBlackPLT()
                Case "status"
                    Me.RadGridLookup.DataSource = oDD.GetStatus()
                Case "region"
                    Me.RadGridLookup.DataSource = oDD.GetRegions()
                Case "jobspectype"
                    Me.RadGridLookup.DataSource = oDD.GetJobSpecTypes()
                Case "apinvoice"
                    Me.RadGridLookup.DataSource = oDD.GetAPInvoices(Vendor)
                Case "arinvoice"
                    Me.RadGridLookup.DataSource = oDD.GetARInvoices(Client)
                Case "adsize"
                    Me.RadGridLookup.DataSource = oDD.GetADSizes(Vendor)
                Case "suppliedby"
                    If Request.QueryString("functype") = "E" Then
                        Me.RadGridLookup.DataSource = oDD.GetEmployees(CStr(Session("UserCode")))
                    ElseIf Request.QueryString("functype") = "V" Then
                        Me.RadGridLookup.DataSource = oDD.GetVendorsAll()
                    End If
                Case "approver"
                    Me.RadGridLookup.DataSource = oDD.GetPOApprovers()
                Case "alertgroups"
                    Me.RadGridLookup.DataSource = oDD.ddAlertGroups()
                Case "polist"
                    Me.RadGridLookup.DataSource = oDD.GetPOList("False", "False", Session("UserID"))
                Case "campaignsearch"
                    Dim InclClosed As Integer = 0
                    If Me.CheckboxClosedJobs.Checked = True Then
                        InclClosed = 1
                    End If
                    Me.RadGridLookup.DataSource = oDD.CampaignSearch(Session("UserCode"), Office, Me.Client, Division, Product, InclClosed)
                Case "contacts"
                    Select Case FromForm
                        Case "jobtemplate"
                            Me.RadGridLookup.DataSource = oDD.GetCDP_ProductContact(Client, Division, Product, "jobtemplate")
                        Case "estimate"
                            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
                            If Me.Job <> 0 Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Job)
                                    If Client = "" Then
                                        Client = jobdata.ClientCode
                                    End If
                                    If Division = "" Then
                                        Division = jobdata.DivisionCode
                                    End If
                                    If Product = "" Then
                                        Product = jobdata.ProductCode
                                    End If
                                End Using
                            End If
                            Me.RadGridLookup.DataSource = oDD.GetCDP_ProductContact(Client, Division, Product, "estimate")
                        Case "ba"
                            Me.RadGridLookup.DataSource = oDD.GetCDP_ClientContact(Client)
                        Case "psfr" 'project schedule find and replace
                            Dim sched As New cSchedule(Session("ConnString"), Session("UserCode"))
                            Me.RadGridLookup.DataSource = sched.GetAvailableContactList(0, 0, 0, Client, "", "")
                    End Select
                Case "atbmedia"

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                        Me.RadGridLookup.DataSource = (From Entity In AdvantageFramework.Database.Procedures.MediaATBComplex.Load(DbContext, Session("UserCode"), Nothing, Nothing, Nothing, Client, Division, Product)
                                                       Select Entity.ATBNumber,
                                                              Entity.Description,
                                                              Entity.ClientCode,
                                                              Entity.DivisionCode,
                                                              Entity.ProductCode).ToList.Select(Function(Entity) New With {.Code = Entity.ATBNumber,
                                                                                                                           .Description = Entity.ATBNumber.ToString & " - " & Entity.Description & " | " & Entity.ClientCode & " | " & Entity.DivisionCode & " | " & Entity.ProductCode}).ToList


                    End Using
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Function DivisionHasOneClient(ByVal DivCode As String) As Boolean
        Try
            Dim arParams(1) As SqlParameter

            Dim paramDivCode As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
            paramDivCode.Value = DivCode
            arParams(0) = paramDivCode

            Dim dt As New DataTable
            dt = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_LOOKUP_DIVISION_HAS_ONE_CLIENT", "DtSearchResults", arParams)
            If CType(dt.Rows(0)("HAS_ONE_CLIENT"), Integer) = 1 Then
                Me.Client = dt.Rows(0)("CL_CODE").ToString()
            Else
                Me.Client = ""
            End If
        Catch ex As Exception
            Me.Client = ""
            Return False
        End Try

    End Function

    Private Function ProductHasOneDivisionAndOneClient(ByVal PrdCode As String) As Boolean
        Try
            Dim arParams(1) As SqlParameter

            Dim paramProdCode As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
            paramProdCode.Value = PrdCode
            arParams(0) = paramProdCode

            Dim dt As New DataTable
            dt = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_LOOKUP_PRD_HAS_ONE_DIV_AND_CL", "DtSearchResults", arParams)
            If CType(dt.Rows(0)("HAS_ONE_CLIENT"), Integer) = 1 Then
                Me.Client = dt.Rows(0)("CL_CODE").ToString()
                Me.Division = dt.Rows(0)("DIV_CODE").ToString()
            Else
                Me.Client = ""
                Me.Division = ""
            End If
        Catch ex As Exception
            Me.Client = ""
            Me.Division = ""
            Return False
        End Try
    End Function

#End Region

#Region " Functions "

    Private Sub SelectItem()
        Dim jt As New Job_Template(Session("ConnString"))
        Dim js As New Job_Specs(Session("ConnString"))
        Dim ocJobs As New cJobs(Session("ConnString"))
        Dim req As cRequired = New cRequired(Session("ConnString"))
        Dim ThisClientControlPrefix As String

        If Me.CurrType.Trim().ToLower.IndexOf("division") > -1 Then
            Me.CurrType = "division"
        End If

        Dim SbJS As New System.Text.StringBuilder
        With SbJS
            Select Case CurrType
                Case "arinvoice"
                    Dim selectedValueArray As String() = Me.SelectedText(Me.RadGridLookup).Split("|")

                    If (selectedValueArray.Length > 0) Then
                        .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_AccountsReceivableClient", selectedValueArray(0).Trim()))
                    End If
                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_AccountsReceivableInvoice", Me.SelectedValue(Me.RadGridLookup)))
                Case "funccatwithemp"
                    Select Case Me.FromForm
                        Case "ts"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_FunctionCategory", Me.SelectedValue(Me.RadGridLookup)))
                        Case Else
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")
                    End Select
                Case "client", "clientts"
                    Select Case Me.FromForm
                        Case "schedulefilter"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobNum", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobCompNum", ""))
                        Case "tscf"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobNum", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobCompNum", ""))
                        Case "timesheet"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"

                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ClientCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_DivisionCode", String.Empty))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ProductCode", String.Empty))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_JobCode", String.Empty))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ComponentCode", String.Empty))

                        Case "tscv"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxClientCode", Me.SelectedValue(Me.RadGridLookup)))
                        Case "alertinbox"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))
                        Case "jobsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "posearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "poestsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Client", Me.SelectedValue(Me.RadGridLookup)))
                        Case "podtl"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))
                        Case "pssearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "newalert"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxClientDescription", req.GetDescription("CL", Me.SelectedValue(Me.RadGridLookup))))
                            .Append("CallingWindowContent.ReloadAutoRecipientControl();")
                        Case "schedulefilterjh"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", ""))
                        Case "calactivity"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientDesc", req.GetDescription("CL", Me.SelectedValue(Me.RadGridLookup))))
                        Case "atbsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Client", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Division", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Product", ""))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "mediaatb"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", ""))
                        Case "jtclient"
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")
                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_colpnl" & SectionDiv.Replace(" ", "") & "_TxtValue_JOB_LOGDIV_CODE').value = '';")
                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_colpnl" & SectionPrd.Replace(" ", "") & "_TxtValue_JOB_LOGPRD_CODE').value = '';")
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control.Replace("TxtValue", "TxtDescript") & "').value = '';")
                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_colpnl" & SectionDiv.Replace(" ", "") & "_TxtDescript_JOB_LOGDIV_CODE').value = '';")
                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_colpnl" & SectionPrd.Replace(" ", "") & "_TxtDescript_JOB_LOGPRD_CODE').value = '';")
                        Case "estimatesearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "cmpsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "jobreq"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))
                        Case "jobrequestsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Client", Me.SelectedValue(Me.RadGridLookup)))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case Else
                            'ThisClientControlPrefix = "CallingWindowContent.document.getElementById('_ctl0_ContentPlaceHolderMain_"
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.SelectedValue(Me.RadGridLookup)))
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")

                            Dim ClientName As String = ""

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                ClientName = HttpUtility.JavaScriptStringEncode(AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Me.SelectedValue(Me.RadGridLookup)).Name)

                            End Using

                            .Append("try { CallingWindowContent.setLookupReturnData('{""ClientName"": """ & ClientName & """, ""DivisionCode"": null, ""DivisionName"": null, ""ProductCode"": null, ""ProductName"": null}'); } catch (err) { }")

                            'If Me.FromForm = "jobjacketnew" Then
                            '    .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")
                            'End If

                    End Select
                Case "division", "divisionts"
                    Try
                        'Me.DivisionHasOneClient(Me.SelectedValue(Me.RadGridLookup))
                        If Me.SelectedText(Me.RadGridLookup).IndexOf("|") > -1 Then
                            'Dim ar() As String
                            'ar = Me.SelectedText(Me.RadGridLookup).Split("|")
                            'If ar.Length > 1 Then
                            '    Me.Client = ar(1).ToString().Trim()
                            'End If
                            Dim s As String = Me.SelectedText(Me.RadGridLookup)
                            Me.Client = s.Substring(s.LastIndexOf("|"), s.Length - 1)
                        End If
                    Catch ex As Exception
                    End Try
                    Select Case Me.FromForm
                        Case "alertinbox"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                        Case "calactivity"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientDesc", req.GetDescription("CL", Me.Client)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionDesc", req.GetDescription("DI", Me.Client & "," & Me.SelectedValue(Me.RadGridLookup))))
                        Case "jobjacket"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", ""))
                        Case "estimatesearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "docmgr"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                        Case "jobsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            If Me.IsClientPortal = True Then
                                '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                                .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                                '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", ""))
                                '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                                '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", ""))
                            Else
                                .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                                .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                                '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", ""))
                                '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                                '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", ""))
                            End If

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "jobnew"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", ""))
                        Case "newalert"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxClientDescription", req.GetDescription("CL", Me.Client)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxDivisionDescription", req.GetDescription("DI", Me.Client & "," & Me.SelectedValue(Me.RadGridLookup))))
                            .Append("CallingWindowContent.ReloadAutoRecipientControl();")
                        Case "podtl"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", ""))
                        Case "posearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtComponent", ""))
                        Case "poestsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Client", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Division", Me.SelectedValue(Me.RadGridLookup)))
                        Case "pssearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", ""))
                        Case "schedulefilter"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobNum", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobCompNum", ""))
                        Case "schedulefilterjh"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", ""))
                        Case "tscf"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobNum", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobCompNum", ""))
                        Case "timesheet"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", ""))

                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_DivisionCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ProductCode", String.Empty))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_JobCode", String.Empty))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ComponentCode", String.Empty))
                        Case "tscv"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxDivisionCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxProductCode", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxJobNumber", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxJobComponentNbr", ""))
                        Case "cmpsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", ""))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "campaignnew"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", ""))
                        Case "atbsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Client", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Division", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Product", ""))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "mediaatb"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", ""))
                        Case "jobrequestsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Client", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Division", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Product", ""))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "jtdivision"
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")
                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_colpnl" & SectionPrd.Replace(" ", "") & "_TxtValue_JOB_LOGPRD_CODE').value = '';")
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control.Replace("TxtValue", "TxtDescript") & "').value = '';")
                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_colpnl" & SectionPrd.Replace(" ", "") & "_TxtDescript_JOB_LOGPRD_CODE').value = '';")
                        Case Else
                            'ThisClientControlPrefix = "CallingWindowContent.document.getElementById('_ctl0_ContentPlaceHolderMain_"
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.SelectedValue(Me.RadGridLookup)))
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")

                            Dim ClientName As String = Nothing
                            Dim DivisionName As String = Nothing
                            Dim DivisionCode As String = Nothing

                            DivisionCode = Me.SelectedValue(Me.RadGridLookup)

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                With (From Item In AdvantageFramework.Database.Procedures.DivisionView.Load(DbContext)
                                      Where Item.ClientCode = Me.Client AndAlso
                                            Item.DivisionCode = DivisionCode
                                      Select Item).SingleOrDefault

                                    ClientName = HttpUtility.JavaScriptStringEncode(.ClientName)
                                    DivisionName = HttpUtility.JavaScriptStringEncode(.DivisionName)

                                End With

                            End Using

                            .Append("try { CallingWindowContent.setLookupReturnData('{""ClientCode"": """ & Me.Client & """, ""ClientName"": """ & ClientName & """, ""DivisionName"": """ & DivisionName & """, ""ProductCode"": null, ""ProductName"": null}'); } catch (err) { }")

                    End Select
                Case "product", "productts", "products"
                    Try
                        'Me.ProductHasOneDivisionAndOneClient(Me.SelectedValue(Me.RadGridLookup))
                        If Me.SelectedText(Me.RadGridLookup).IndexOf("|") > -1 Then
                            Dim ar() As String
                            ar = Me.SelectedText(Me.RadGridLookup).Split("|")
                            If ar.Length > 1 Then
                                Dim arVal() As String
                                arVal = ar(1).ToString().Split(",")
                                If arVal.Length > 1 Then
                                    Me.Client = arVal(0).Trim().Replace(" ", "")
                                    Me.Division = arVal(1).Trim().Replace(" ", "")
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Select Case Me.FromForm
                        Case "schedule"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobNum", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobCompNum", ""))
                        Case "timesheet"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.Division))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", Me.SelectedValue(Me.RadGridLookup)))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_DivisionCode", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ProductCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_JobCode", String.Empty))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ComponentCode", String.Empty))
                        Case "ts"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_FunctionCategory", Me.SelectedValue(Me.RadGridLookup)))

                        Case "tscv"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxDivisionCode", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxProductCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxJobNumber", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxJobComponentNbr", ""))
                        Case "alertinbox"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", ""))
                        Case "schedulefilter"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobNum", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobCompNum", ""))
                        Case "tscf"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobNum", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtJobCompNum", ""))
                        Case "posearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtComponent", ""))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "poestsearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Client", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Division", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Product", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Job", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBox_Component", ""))
                        Case "podtl"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "lblJobDescription", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "lbl_comp_desc", ""))
                        Case "pssearch"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", Me.SelectedValue(Me.RadGridLookup)))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", ""))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtComponent", ""))

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                        Case "newalert", "calendarfilter"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            If Request.QueryString("cp") <> "1" Then
                                .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                                '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxClientDescription", req.GetDescription("CL", Me.Client)))
                            End If
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.Division))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxDivisionDescription", req.GetDescription("DI", Me.Client & "," & Me.SelectedValue(Me.RadGridLookup))))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", Me.SelectedValue(Me.RadGridLookup)))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TextBoxProductDescription", req.GetDescription("PR", Me.Client & "," & Me.Division & "," & Me.SelectedValue(Me.RadGridLookup))))
                            If FromForm = "newalert" Then
                                .Append("CallingWindowContent.ReloadAutoRecipientControl();")
                            End If
                        Case "schedulefilterjh"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", Me.SelectedValue(Me.RadGridLookup)))
                        Case "mediaatb"
                            ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtClientCode", Me.Client))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtDivisionCode", Me.Division))
                            .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtProductCode", Me.SelectedValue(Me.RadGridLookup)))
                        Case "jtproduct"
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control.Replace("TxtValue", "TxtDescript") & "').value = '';")
                        Case Else
                            'ThisClientControlPrefix = "CallingWindowContent.document.getElementById('_ctl0_ContentPlaceHolderMain_"
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.Division))
                            '.Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", Me.SelectedValue(Me.RadGridLookup)))
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")

                            Dim ClientName As String = Nothing
                            Dim DivisionName As String = Nothing
                            Dim ProductCode As String = Nothing
                            Dim ProductName As String = Nothing

                            ProductCode = Me.SelectedValue(Me.RadGridLookup)

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                With (From Item In AdvantageFramework.Database.Procedures.ProductView.Load(DbContext)
                                      Where Item.ClientCode = Me.Client AndAlso
                                            Item.DivisionCode = Me.Division AndAlso
                                            Item.ProductCode = ProductCode
                                      Select Item).SingleOrDefault

                                    ClientName = HttpUtility.JavaScriptStringEncode(.ClientName)
                                    DivisionName = HttpUtility.JavaScriptStringEncode(.DivisionName)
                                    ProductName = HttpUtility.JavaScriptStringEncode(.ProductDescription)

                                End With

                            End Using

                            .Append("try { CallingWindowContent.setLookupReturnData('{""ClientCode"": """ & Me.Client & """, ""ClientName"": """ & ClientName & """, ""DivisionCode"": """ & Me.Division & """, ""DivisionName"": """ & DivisionName & """, ""ProductName"": """ & ProductName & """}'); } catch (err) { }")

                    End Select
                Case "job"
                    ThisClientControlPrefix = "CallingWindowContent.document.getElementById('_ctl0_ContentPlaceHolderMain_"
                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJob", Me.SelectedValue(Me.RadGridLookup)))
                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", ""))
                Case "jobcomp"
                    ThisClientControlPrefix = "CallingWindowContent.document.getElementById('_ctl0_ContentPlaceHolderMain_"
                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtJobComp", Me.SelectedValue(Me.RadGridLookup)))
                Case "desktopobjects"
                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript("CallingWindowContent.document.getElementById('_ctl0_ContentPlaceHolderMain_", "txtNewDeskTopObject", Me.SelectedValue(Me.RadGridLookup)))
                    .Append("CallingWindowContent.document.getElementById('submit();")
                Case "adnumber"
                    Select Case Me.FromForm
                        Case "jt"
                            Try
                                Dim dr As SqlClient.SqlDataReader
                                dr = jt.GetAdNumBlackPlt(Me.SelectedValue(Me.RadGridLookup))
                                Do While dr.Read
                                    .Append("CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = " & Me.SelectedValue(Me.RadGridLookup) & ";")
                                    If Session("JobTemplateHasBlackplate1") = "True" Then
                                        If dr.GetString(2) <> "" Then
                                            .Append("CallingWindowContent.document.getElementById('" & Request.QueryString("bp1") & "').value = '" & dr.GetString(2) & "';")
                                        End If
                                    End If
                                    If Session("JobTemplateHasBlackplate2") = "True" Then
                                        If dr.GetString(4) <> "" Then
                                            .Append("CallingWindowContent.document.getElementById('" & Request.QueryString("bp2") & "').value = '" & dr.GetString(4) & "';")
                                        End If
                                    End If
                                Loop
                                'End If
                                dr.Close()
                            Catch ex As Exception
                                Me.ShowMessage("Error! " & ex.Message.ToString())
                            End Try
                        Case Else
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")

                    End Select
                Case "task"
                    Select Case Me.FromForm
                        Case "pstask"
                            Dim arValue() As String
                            Dim trfdesc As String = ""
                            arValue = Me.SelectedText(Me.RadGridLookup).Split("-")
                            Try
                                Dim arDatakey() As String
                                arDatakey = Request.QueryString("key").ToString().Split("|")
                                Dim sql As String = "UPDATE JOB_TRAFFIC_DET WITH(ROWLOCK) SET FNC_CODE = @FNC_CODE, TASK_DESCRIPTION = @TASK_DESCRIPTION WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @SEQ_NBR;"
                                Dim sqlDesc As String = "SELECT ISNULL(TRF_DESC,'''') AS TRF_DESC FROM TRAFFIC_FNC WHERE TRF_CODE = @FNC_CODE"
                                Dim drDesc As SqlDataReader

                                Dim arParams(5) As SqlParameter

                                Dim paramCliCode As New SqlParameter("@FNC_CODE", SqlDbType.VarChar, 10)
                                paramCliCode.Value = arValue(0)
                                arParams(0) = paramCliCode

                                If arValue.Length > 2 Then
                                    drDesc = SqlHelper.ExecuteReader(Session("ConnString"), CommandType.Text, sqlDesc, paramCliCode)
                                    If drDesc.HasRows Then
                                        drDesc.Read()
                                        trfdesc = drDesc("TRF_DESC")
                                        drDesc.Close()
                                    End If
                                End If
                                Dim paramDivCode As New SqlParameter("@TASK_DESCRIPTION", SqlDbType.VarChar, 40)
                                If trfdesc <> "" Then
                                    paramDivCode.Value = trfdesc
                                Else
                                    paramDivCode.Value = arValue(1)
                                End If
                                arParams(1) = paramDivCode

                                Dim paramJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                                paramJobNumber.Value = arDatakey(0)
                                arParams(2) = paramJobNumber

                                Dim paramJobCompNumber As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                                paramJobCompNumber.Value = arDatakey(1)
                                arParams(3) = paramJobCompNumber

                                Dim paramProdCode As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                                paramProdCode.Value = arDatakey(2)
                                arParams(4) = paramProdCode

                                SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, sql, arParams)
                            Catch ex As Exception
                            End Try

                            Dim TaskCodeControlName As String = Nothing
                            Dim TaskDescriptionControlName As String = Nothing

                            If Request.QueryString("control").ToString().Contains("TextBoxTaskCode") Then

                                TaskCodeControlName = "TextBoxTaskCode"
                                TaskDescriptionControlName = "TextBoxTaskDescription"

                            Else

                                TaskCodeControlName = "TxtTaskCode"
                                TaskDescriptionControlName = "TxtTASK_DESCRIPTION"

                            End If

                            Dim Prefix As String = Request.QueryString("control").ToString().Replace(TaskCodeControlName, "")

                            .Append("CallingWindowContent.document.getElementById('" & Prefix & TaskCodeControlName & "').value = '" & arValue(0).ToString().Trim() & "';")
                            If trfdesc <> "" Then
                                .Append("try { CallingWindowContent.document.getElementById('" & Prefix & TaskDescriptionControlName & "').value = '" & trfdesc & "'; } catch(err) { }")
                            Else
                                .Append("try { CallingWindowContent.document.getElementById('" & Prefix & TaskDescriptionControlName & "').value = '" & arValue(1).ToString().Trim() & "'; } catch(err) { }")
                            End If
                        Case Else
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")

                            If _AutoSearch Then

                                .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                            End If

                    End Select
                Case "contacts"
                    Dim CdpContactId As Integer = 0
                    Dim CdpContactCode As String = ""
                    Dim CdpContactFullName As String = ""
                    Dim arPK() As String
                    Try
                        arPK = Me.SelectedValue(Me.RadGridLookup).Split("|")
                        CdpContactId = CType(arPK(0), Integer)
                        CdpContactCode = arPK(1).ToString()
                    Catch ex As Exception
                    End Try
                    Dim arText() As String
                    Try
                        arText = Me.SelectedText(Me.RadGridLookup).Split("-")
                        CdpContactCode = arText(0).ToString()
                        CdpContactFullName = arText(1).Trim().Replace("'", "")
                    Catch ex As Exception
                    End Try
                    Select Case Me.FromForm
                        Case "jobtemplate"
                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_HfNewCDP_CONTACT_ID').value = '")
                            .Append(CdpContactId)
                            .Append("';")

                            .Append("CallingWindowContent.document.getElementById('")
                            .Append(Me.Control)
                            .Append("').value = '")
                            .Append(CdpContactCode)
                            .Append("';")
                        Case "estimate"
                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_HfContactCodeID').value = '")
                            .Append(CdpContactId)
                            .Append("';")

                            .Append("CallingWindowContent.document.getElementById('")
                            .Append(Me.Control)
                            .Append("').value = '")
                            .Append(CdpContactCode)
                            .Append("';")

                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtContactDescription').value = '")
                            .Append(CdpContactFullName)
                            .Append("';")
                        Case "ba"
                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_HfContactCodeID').value = '")
                            .Append(CdpContactId)
                            .Append("';")

                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientContactCode').value = '")
                            .Append(CdpContactCode)
                            .Append("';")

                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientContactDescription').value = '")
                            .Append(CdpContactFullName)
                            .Append("';")
                        Case "psfr"
                            Dim HfName As String = ""
                            Dim CtrlName As String = ""
                            Dim ar() As String
                            ar = Me.Control.Split("|")

                            CtrlName = ar(0).ToString()
                            HfName = ar(1).ToString()

                            .Append("CallingWindowContent.document.getElementById('" & HfName & "').value = '")
                            .Append(CdpContactId)
                            .Append("';")

                            .Append("CallingWindowContent.document.getElementById('" & CtrlName & "').value = '")
                            .Append(CdpContactCode)
                            .Append("';")
                        Case Else
                            .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")


                    End Select
                Case "statuscodes"

                    If Not Request.QueryString("autosave") Is Nothing Then
                        If Request.QueryString("autosave") <> "" Then
                            Select Case Request.QueryString("autosave").Trim()
                                Case "TRF_DFLT_STATUS"
                                    Dim m As New cMaintenanceApps()
                                    m.AgencySettingSet("TRF_DFLT_STATUS", Me.SelectedValue(Me.RadGridLookup))
                            End Select
                        End If
                    End If

                    .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")

                Case "atbmedia"

                    Try
                        If Me.SelectedText(Me.RadGridLookup).IndexOf("|") > -1 Then
                            Dim ar() As String
                            ar = Me.SelectedText(Me.RadGridLookup).Split("|")
                            If ar.Length > 1 Then
                                Dim arVal() As String
                                arVal = ar(1).ToString().Split(",")
                                If arVal.Length > 1 Then
                                    Me.Client = arVal(0).Trim().Replace(" ", "")
                                    Me.Division = arVal(1).Trim().Replace(" ", "")
                                    Me.Product = arVal(2).Trim().Replace(" ", "")
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                    ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                    If Request.QueryString("cp") <> "1" Then
                        .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtClient", Me.Client))
                    End If
                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtDivision", Me.Division))
                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtProduct", Me.Product))
                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtMediaATB", Me.SelectedValue(Me.RadGridLookup)))
                    If FromForm = "newalert" Then
                        .Append("CallingWindowContent.ReloadAutoRecipientControl();")
                    End If

                Case "productcategory"
                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ProductCategory", Me.SelectedValue(Me.RadGridLookup)))
                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBoxProductCategory", Me.SelectedValue(Me.RadGridLookup)))

                    .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery(Me.Control, Me.SelectedValue(Me.RadGridLookup)))

                Case "empcode"
                    .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")

                    If Request.QueryString("control2") IsNot Nothing Then

                        Dim Control2 As String = Request.QueryString("control2")
                        Dim EmployeeName As String = Nothing

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                EmployeeName = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.SelectedValue(Me.RadGridLookup).ToString).ToString

                            End Using

                        Catch ex As Exception

                        End Try

                        .Append("try { CallingWindowContent.document.getElementById('" & Control2 & "').value = '" & EmployeeName & "'; } catch (err) { }")

                    End If
                    If Me.FromForm = "schedule_search" Then

                        If _AutoSearch Then

                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                        End If

                    End If

                Case "office"

                    If FromForm = "mediacal" Then
                        ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadPanelbarMediaFilter_i0_i0_"
                        .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtOffice", Me.SelectedValue(Me.RadGridLookup)))
                    ElseIf FromForm = "jt" Or FromForm = "jobjacketnewoffice" Or FromForm = "jobjacketnewdocs" Then
                        .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';")
                    Else
                        ThisClientControlPrefix = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_"
                        .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "txtOffice", Me.SelectedValue(Me.RadGridLookup)))
                    End If

                    If FromForm = "newalert" Then
                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                .Append(AdvantageFramework.Web.Presentation.Controls.SetReturnValueJavascript(ThisClientControlPrefix, "TxtOfficeDescription", req.GetDescription("OF", Me.SelectedValue(Me.RadGridLookup))))

                            End Using

                        Catch ex As Exception

                        End Try
                    End If

                    If Me.FromForm = "jobjacketnew" Or Me.FromForm = "cmpsearch" Then

                        If _AutoSearch Then

                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                        End If

                    End If

                    'Case "campaignjobnew"

                    '    .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "'")
                    '    .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_hfCampaignID').value = '" & ocJobs.GetCampaignIdentifier(Me.SelectedValue(Me.RadGridLookup), Me.Client, Me.Division, Me.Product) & "';")

                Case Else
                    .Append("CallingWindowContent.document.getElementById('" & Me.Control & "').value = '" & Me.SelectedValue(Me.RadGridLookup).Replace("'", "\'") & "';")
                    If Me.FromForm = "jobsearch" Or Me.FromForm = "po" Or Me.FromForm = "schedule_search" Then

                        If _AutoSearch Then

                            .Append("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();")

                        End If

                    End If
            End Select

            '.Append("try { CallingWindowContent.document.getElementById('" & Me.Control & "').focus();alert('focused'); } catch (err) { }")

            .Append("try { CallingWindowContent.lookupComplete('" & Me.Control & "'); } catch (err) { }")

        End With

        Me.ControlsToSet = SbJS.ToString()
        If Me.Control <> "dummy" Then
            Me.ControlsToSet &= Me.SetFocusToInput(Me.Control)
        End If

        Me.HiddenFieldControlsToSet.Value = Me.ControlsToSet

        Telerik.Web.UI.RadAjaxManager.GetCurrent(Me.Page).ResponseScripts.Add("returnValue();")

    End Sub

#End Region

    Private Sub ButtonSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSelect.Click
        Me.SelectItem()
    End Sub

    Private Sub CheckboxClosedJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckboxClosedJobs.CheckedChanged
        Me.RadGridLookup.Rebind()
    End Sub
End Class
