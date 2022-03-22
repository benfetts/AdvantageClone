Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports Webvantage.wvTimeSheet

Public Class LookUp
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

#Region " Variables "


    Public OfficeCode As String = ""
    Public ClCode As String = ""
    Public DivCode As String = ""
    Public PrdCode As String = ""
    Public JobNumber As String = "0"
    Public JobComponentNbr As String = "0"
    Public EmpCode As String = ""

    Public ScCode As String = ""
    Public AeEmpCode As String = ""
    Public EstimateNumber As String = ""
    Public EstComponentNbr As String = ""
    Public EstQuoteNbr As String = ""
    Public EstRevNbr As String = ""
    Public CmpCode As String = ""

    Public CampaignId As String = ""
    Public ATBNumber As String = "0"

    Private CurrForm As String = ""
    Private CurrType As String = ""
    Private CurrIndex As Integer

    Public JobDescription As String = ""
    Public CompDescription As String = ""
    Public CampaignDescription As String = ""

    Private _ControlId As String = ""

    Public _POVendorOnly As Boolean = False
    Public _VendorCode As String = ""
    Private _AutoSearch As Boolean = True

#End Region

#Region " Page "

    Private Sub Page_PreInit2(sender As Object, e As EventArgs) Handles Me.PreInit

        Me.SetLookupGrid(Me.RadGridLookup)

        Try
            CurrType = Request.QueryString("type")
        Catch ex As Exception
            CurrType = ""
        End Try

        Try
            CurrForm = Request.QueryString("form")
        Catch ex As Exception
            CurrForm = ""
        End Try

        If Request.QueryString("control") IsNot Nothing Then
            _ControlId = Request.QueryString("control")
        End If

        If Not Request.QueryString("povendoronly") Is Nothing Then
            If Request.QueryString("povendoronly") = "1" Then
                _POVendorOnly = True
            End If
        End If

        If Not Request.QueryString("VendorCode") Is Nothing Then
            _VendorCode = Request.QueryString("VendorCode")
        End If

        If Not Request.QueryString("autoSearch") Is Nothing Then
            _AutoSearch = CBool(Request.QueryString("autoSearch"))
        End If

    End Sub

    Private Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.OpenerRadWindowName = Request.QueryString("opener")
        Catch ex As Exception
            Me.OpenerRadWindowName = ""
        End Try

        If Not Me.IsPostBack And Not Me.IsCallback Then
            Try
                If CurrType = "suppliedby" Then
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    If Request.QueryString("functype") = "" And Request.QueryString("funccode") <> "" Then
                        Dim dt As DataTable = est.GetDefaultFunctionData(Request.QueryString("funccode"), 0, 0, "", "", "", "", "")
                        If dt.Rows.Count > 0 Then
                            If IsDBNull(dt.Rows(0)("FNC_TYPE")) = False Then
                                Me.HiddenFieldLookupType.Value = dt.Rows(0)("FNC_TYPE")
                            End If
                        End If
                        Try
                            dt.Dispose()
                            dt = Nothing
                        Catch ex As Exception
                        End Try
                    End If
                    Me.CheckBoxMediaVendors.Visible = True
                Else
                    Me.CheckBoxMediaVendors.Visible = False
                End If

                If Not Session("ConnString") Is Nothing Then

                    If Session("ConnString") <> "" Then
                        If CurrType = "jobcompjj" And (CurrForm = "jobjacket" Or CurrForm = "jobpanel" Or CurrForm = "jobsearch") Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                        ElseIf CurrType = "jobcompjj" And (CurrForm = "docmgr" Or CurrForm = "alertinbox") Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                        ElseIf CurrType = "client" And (CurrForm = "docmgr" Or CurrForm = "alertinbox") Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                            Me.CheckboxClosedJobs.Text = "Show Inactive Clients?"
                        ElseIf CurrType = "division" And (CurrForm = "docmgr" Or CurrForm = "alertinbox") Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                            Me.CheckboxClosedJobs.Text = "Show Inactive Divisions?"
                        ElseIf CurrType = "product" And (CurrForm = "docmgr" Or CurrForm = "alertinbox") Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                            Me.CheckboxClosedJobs.Text = "Show Inactive Products?"
                        ElseIf CurrType = "job" And CurrForm = "traffictimeline" Then
                            Me.CheckboxClosedJobs.Checked = False
                            If Me.CheckboxClosedJobs.Visible = True Then Me.CheckboxClosedJobs.Visible = False
                        ElseIf CurrType = "product" And CurrForm = "jobnew" Then
                            Me.CheckboxClosedJobs.Checked = False
                            If Me.CheckboxClosedJobs.Visible = True Then Me.CheckboxClosedJobs.Visible = False
                        ElseIf CurrType = "jobcompjj" And (CurrForm = "purchaseorder_dtl") Then
                            If Me.CheckboxClosedJobs.Visible = True Then Me.CheckboxClosedJobs.Visible = False
                        ElseIf CurrType = "job" And (CurrForm = "jobpanel" Or CurrForm = "jobsearch" Or CurrForm = "docmgr" Or CurrForm = "popanel") Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                        ElseIf (CurrType = "jobschedulejt" Or CurrType = "jobcompschedulejt") And CurrForm = "schedulecopy" Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                        ElseIf CurrType = "suppliedby" And CurrForm = "suppliedby" And (Request.QueryString("functype") = "V" Or Me.HiddenFieldLookupType.Value = "V") Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                            Me.CheckboxClosedJobs.Text = "Limit to vendors with default function code '" & Request.QueryString("funccode") & "'"
                        ElseIf CurrType = "jobcopy" And (CurrForm = "jobcopy" Or CurrForm = "jobcopycomp") Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                        ElseIf CurrForm = "jobvercopy" Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                        ElseIf CurrType = "jobcomppo" Then
                            If Me.CheckboxClosedJobs.Visible = False Then Me.CheckboxClosedJobs.Visible = True
                        Else
                            Me.CheckboxClosedJobs.Checked = False
                            If Me.CheckboxClosedJobs.Visible = True Then Me.CheckboxClosedJobs.Visible = False
                        End If

                        If CurrType = "jobcompschedulenew" And CurrForm = "schedulenew" Then
                            With Me.CheckboxClosedJobs
                                .Text = "Only project schedule needed."
                                .Visible = True
                            End With
                        End If

                        If (CurrType = "jobcompjj" Or CurrType = "job") And (CurrForm = "jobpanel" Or CurrForm = "jobsearch") Then
                            If Not Request.QueryString("checked") Is Nothing Then
                                If Request.QueryString("checked") = "1" Then
                                    Me.CheckboxClosedJobs.Checked = True
                                End If
                            End If
                        End If

                        If (CurrType = "jobcopy" And (CurrForm = "jobcopy" Or CurrForm = "jobcopycomp")) OrElse (CurrForm = "estimatesearchjc" AndAlso (CurrType = "estimatejobcompsearch" OrElse CurrType = "estimatejobsearch")) Then
                            If Not Request.QueryString("checked") Is Nothing Then
                                If Request.QueryString("checked") = "1" Then
                                    Me.CheckboxClosedJobs.Checked = True
                                End If
                            End If
                        End If

                        If (CurrType = "jobcopyps" And CurrForm = "jobcopyps") Or (CurrType = "jobcopycompps" And CurrForm = "jobcopycompps") Then
                            If Not Request.QueryString("checked") Is Nothing Then
                                If Request.QueryString("checked") = "1" Then
                                    Me.CheckboxClosedJobs.Checked = True
                                End If
                            End If
                        End If

                    End If
                End If
            Catch ex As Exception
                Throw (ex)
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

#Region " Controls "

    Private Sub CheckboxClosedJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckboxClosedJobs.CheckedChanged
        Me.RadGridLookup.Rebind()
    End Sub

    Private Sub CheckBoxMediaVendors_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxMediaVendors.CheckedChanged
        Me.RadGridLookup.Rebind()
    End Sub

    Private Sub ButtonSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSelect.Click
        Me.SelectItem()
    End Sub

#End Region

#Region " Data "

    Private Sub LoadLookup()

        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim Office As String = ""
        Dim Client As String = ""
        Dim Division As String = ""
        Dim Product As String = ""
        Dim Type As String = ""
        Dim JobNo As Integer = 0
        Dim JobType As String = ""
        Dim FromForm As String = ""
        Dim Vendor As String = ""
        Dim EstNo As Integer = 0
        Dim EstComp As Integer = 0
        Dim EmpCode As String = ""
        Dim SalesClass As String = ""
        Dim JobComp As Integer = 0
        Dim BaBatchId As Integer = 0
        Dim BaApprovalId As Integer = 0
        Dim Campaign As String = ""
        Dim Task_FncCode As String = ""
        Dim ATBNumber As Integer = 0

        Try
            Type = Request.QueryString("type")
        Catch ex As Exception
        End Try
        Try
            Office = Request.QueryString("office")
        Catch ex As Exception
        End Try
        Try
            Client = Request.QueryString("client")
        Catch ex As Exception
        End Try
        Try
            Division = Request.QueryString("division")
        Catch ex As Exception
        End Try
        Try
            Product = Request.QueryString("product")
        Catch ex As Exception
        End Try
        Try
            JobType = Request.QueryString("jobtype")
        Catch ex As Exception
        End Try
        Try
            Vendor = Request.QueryString("vendor")
        Catch ex As Exception
        End Try
        Try
            EmpCode = Request.QueryString("empcode")
        Catch ex As Exception
        End Try
        Try
            SalesClass = Request.QueryString("salesclass")
        Catch ex As Exception
        End Try

        Try
            FromForm = Request.QueryString("form")
        Catch ex As Exception
        End Try

        Try
            If IsNumeric(Request.QueryString("job")) Then
                JobNo = CInt(Request.QueryString("job"))
            Else
                JobNo = 0
            End If
        Catch ex As Exception
            JobNo = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("jobcomp")) Then
                JobComp = CInt(Request.QueryString("jobcomp"))
            Else
                JobComp = 0
            End If
        Catch ex As Exception
            JobComp = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("baid")) Then
                BaBatchId = CInt(Request.QueryString("baid"))
            Else
                BaBatchId = 0
            End If
        Catch ex As Exception
            BaBatchId = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("aid")) Then
                BaApprovalId = CInt(Request.QueryString("aid"))
            Else
                BaApprovalId = 0
            End If
        Catch ex As Exception
            BaApprovalId = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("estimate")) Then
                EstNo = CInt(Request.QueryString("estimate"))
            Else
                EstNo = 0
            End If
        Catch ex As Exception
            EstNo = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("estimatecomp")) Then
                EstComp = CInt(Request.QueryString("estimatecomp"))
            Else
                EstComp = 0
            End If
        Catch ex As Exception
            EstComp = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("atbnumber")) Then
                ATBNumber = CInt(Request.QueryString("atbnumber"))
            Else
                ATBNumber = 0
            End If
        Catch ex As Exception
            ATBNumber = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("cmpId")) Then
                Campaign = CInt(Request.QueryString("cmpId"))
            Else
                Campaign = 0
            End If
        Catch ex As Exception
            Campaign = 0
        End Try

        Select Case Type
            Case "job"
                If CurrType <> "job" And CurrForm <> "jobpanel" And CurrForm <> "jobsearch" Then
                    If Me.CheckboxClosedJobs.Checked = True Then Me.CheckboxClosedJobs.Checked = False
                    If Me.CheckboxClosedJobs.Visible = True Then Me.CheckboxClosedJobs.Visible = False
                End If
                If Me.CheckboxClosedJobs.Checked = True And CurrForm <> "jobpanel" And CurrForm <> "jobsearch" And CurrForm <> "estimatejc" Then
                    If Client.Length < 1 And Division.Length < 1 And Product.Length < 1 Then
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.JobJacket, True)
                        Me.HiddenFieldLookupType.Value = "Job1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.TimeSheet, True)
                        Me.HiddenFieldLookupType.Value = "Job2"
                    End If
                ElseIf Me.CheckboxClosedJobs.Checked = False And CurrForm <> "jobpanel" And CurrForm <> "jobsearch" And CurrForm <> "estimatejc" And CurrForm <> "expenseedit" And CurrForm <> "traffictimeline" And CurrForm <> "schedule" And CurrForm <> "purchaseorder_dtl" And CurrForm <> "popanel" And CurrForm <> "poestsearch" Then
                    If Client.Length < 1 And Division.Length < 1 And Product.Length < 1 Then
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.TimeSheet, FromForm)
                        Me.HiddenFieldLookupType.Value = "Job1"
                    Else
                        If Me.IsClientPortal = True Then
                            Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobJacket, "", "", FromForm, False, True, Session("UserID"))
                        Else
                            Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.TimeSheet, "", "", FromForm)
                        End If
                        Me.HiddenFieldLookupType.Value = "Job2"
                    End If
                ElseIf Me.CheckboxClosedJobs.Checked = True And (CurrForm = "jobpanel" Or CurrForm = "jobsearch" Or CurrForm = "estimatejc") Then
                    If Client.Length < 1 And Division.Length < 1 And Product.Length < 1 And Office.Length < 1 And SalesClass.Length < 1 Then
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.JobJacket, True)
                        Me.HiddenFieldLookupType.Value = "Job1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobJacket, True, Office, SalesClass, Me.IsClientPortal, Session("UserID"))
                        Me.HiddenFieldLookupType.Value = "Job2"
                    End If
                ElseIf Me.CheckboxClosedJobs.Checked = False And (CurrForm = "jobpanel" Or CurrForm = "jobsearch" Or CurrForm = "estimatejc") Then
                    If Client.Length < 1 And Division.Length < 1 And Product.Length < 1 And Office.Length < 1 And SalesClass.Length < 1 Then
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.JobJacket)
                        Me.HiddenFieldLookupType.Value = "Job1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobJacket, Office, SalesClass, "", False, Me.IsClientPortal, Session("UserID"))
                        Me.HiddenFieldLookupType.Value = "Job2"
                    End If

                ElseIf Me.CheckboxClosedJobs.Checked = True And (CurrForm = "purchaseorder_dtl" Or CurrForm = "popanel" Or CurrForm = "poestsearch") Then

                    Dim JobDataTable As DataTable = Nothing

                    If Client.Length < 1 And Division.Length < 1 And Product.Length < 1 Then
                        JobDataTable = oDD.GetJobList(CStr(Session("UserCode")), JobListType.PurchaseOrder, True)
                        Me.HiddenFieldLookupType.Value = "Job1"
                    Else
                        JobDataTable = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.PurchaseOrder, True)
                        Me.HiddenFieldLookupType.Value = "Job2"
                    End If

                    If CurrForm = "poestsearch" Then

                        JobDataTable = FilterDataTableByPOEstimate(JobDataTable, True, False)

                    End If

                    If _POVendorOnly = True Then

                        JobDataTable = FilterDataTableByPOVendor(JobDataTable, True, False, False)

                    End If

                    Me.RadGridLookup.DataSource = JobDataTable

                ElseIf Me.CheckboxClosedJobs.Checked = False And (CurrForm = "purchaseorder_dtl" Or CurrForm = "popanel" Or CurrForm = "poestsearch") Then

                    Dim JobDataTable As DataTable = Nothing

                    If Client.Length < 1 And Division.Length < 1 And Product.Length < 1 Then
                        JobDataTable = oDD.GetJobList(CStr(Session("UserCode")), JobListType.PurchaseOrder)
                        Me.HiddenFieldLookupType.Value = "Job1"
                    Else
                        JobDataTable = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.PurchaseOrder)
                        Me.HiddenFieldLookupType.Value = "Job2"
                    End If

                    If CurrForm = "poestsearch" Then

                        JobDataTable = FilterDataTableByPOEstimate(JobDataTable, True, False)

                    End If

                    If _POVendorOnly = True Then

                        JobDataTable = FilterDataTableByPOVendor(JobDataTable, True, False, False)

                    End If

                    Me.RadGridLookup.DataSource = JobDataTable

                ElseIf Me.CheckboxClosedJobs.Checked = False And CurrForm = "expenseedit" Then
                    If Client.Length < 1 And Division.Length < 1 And Product.Length < 1 Then
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.ExpenseEdit)
                        Me.HiddenFieldLookupType.Value = "Job1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.ExpenseEdit)
                        Me.HiddenFieldLookupType.Value = "Job2"
                    End If
                ElseIf CurrForm = "schedule" Then
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.Traffic, True)
                    Me.HiddenFieldLookupType.Value = "Job2"
                ElseIf CurrForm = "schedule_search" Then
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.Traffic, True)
                    Me.HiddenFieldLookupType.Value = "Job2"
                ElseIf Me.CheckboxClosedJobs.Checked = False And CurrForm = "traffictimeline" Then
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.Traffic)
                    Me.HiddenFieldLookupType.Value = "Job2"
                End If
            Case "task_j"
                Me.HiddenFieldLookupType.Value = Type
                Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.TrafficOpen, Me.CheckboxClosedJobs.Checked)
                'Me.RadGridLookup.DataSource = oDD.GetJobList(Session("UserCode"), JobListType.JobJacket, Me.CheckboxClosedJobs.Checked)
            Case "jobcomp"
                If Me.CheckboxClosedJobs.Checked = True Then 'only available to jobjacket?
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompList(CStr(Session("UserCode")), True)
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobCompList(Session("UserID"), Client, Division, Product, JobNo, True)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                Else 'only this path is really available
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompList(CStr(Session("UserCode")))
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    ElseIf JobNo <> 0 Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompList(Session("UserID"), Client, Division, Product, JobNo)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobCompList(Session("UserID"), Client, Division, Product, JobNo)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                    End If
                End If
            Case "jobcompee"
                If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                    Me.RadGridLookup.DataSource = oDD.GetJobCompListEE(CStr(Session("UserCode")))
                    Me.HiddenFieldLookupType.Value = "JobComp1"
                Else
                    Me.RadGridLookup.DataSource = oDD.GetJobCompListEE(Session("UserID"), Client, Division, Product, JobNo)
                    Me.HiddenFieldLookupType.Value = "JobComp2"
                    Me.ClCode = Client
                    Me.DivCode = Division
                    Me.PrdCode = Product
                    Me.JobNumber = JobNo
                End If
            Case "task_jc"
                'If Me.CheckboxClosedJobs.Checked = True Then
                '    Me.RadGridLookup.DataSource = oDD.GetJobCompListJJ(Session("UserCode"), Client, Division, Product, JobNo, True, Office, SalesClass)
                '    Me.JobNumber = JobNo
                'Else
                '    Me.RadGridLookup.DataSource = oDD.GetJobCompListJJ(Session("UserCode"), Client, Division, Product, JobNo, Office, SalesClass)
                'End If
                Me.JobNumber = JobNo
                Me.HiddenFieldLookupType.Value = Type
                '   Me.RadGridLookup.DataSource = oDD.GetJobCompListJJ(Session("UserCode"), "", "", "", JobNo, Me.CheckboxClosedJobs.Checked, "", "")
                If Client = "" And Division = "" And Product = "" And JobNo < 1 Then 'user hit the comp link with no other data
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")))
                ElseIf JobNo > 0 Then 'user hit the complink with  a job
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(Session("UserCode"), "", "", "", JobNo)
                    'Else
                    '    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")), Client, Division, Product)
                End If

            Case "jobcompjj"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" And Office = "" And SalesClass = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJJ(CStr(Session("UserCode")), True)
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJJ(Session("UserCode"), Client, Division, Product, JobNo, True, Office, SalesClass, Me.IsClientPortal, Session("UserID"))
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                Else
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" And Office = "" And SalesClass = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJJ(CStr(Session("UserCode")))
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJJ(Session("UserCode"), Client, Division, Product, JobNo, Office, SalesClass, False, Me.IsClientPortal, Session("UserID"))
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                End If
            Case "jobcompnewalert"
                If JobNo = 0 And Client = "" And Division = "" And Product = "" And Office = "" And SalesClass = "" Then
                    Me.RadGridLookup.DataSource = oDD.GetJobCompListJJ(CStr(Session("UserCode")))
                    Me.HiddenFieldLookupType.Value = "JobComp1"
                Else
                    Me.RadGridLookup.DataSource = oDD.GetJobCompListJJ(Session("UserCode"), Client, Division, Product, JobNo, Office, SalesClass, True, Me.IsClientPortal, Session("UserID"))
                    Me.HiddenFieldLookupType.Value = "JobComp2"
                    Me.ClCode = Client
                    Me.DivCode = Division
                    Me.PrdCode = Product
                    If JobNo > 0 Then
                        Me.JobNumber = JobNo.ToString()
                    End If
                End If

            Case "jobcomppo" 'need to make new functions for this path....
                Dim JobCompDataReader As SqlDataReader = Nothing
                Dim JobCompDataTable As DataTable = Nothing
                If Me.CheckboxClosedJobs.Checked = True Then
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                        JobCompDataReader = oDD.GetJobCompListJJ(CStr(Session("UserCode")), True)
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        JobCompDataReader = oDD.GetJobCompListJJ(Session("UserCode"), Client, Division, Product, JobNo, True)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                Else
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                        JobCompDataReader = oDD.GetJobCompListJJPO(CStr(Session("UserCode")))
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        JobCompDataReader = oDD.GetJobCompListJJPO(Session("UserCode"), Client, Division, Product, JobNo)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                End If

                JobCompDataTable = New DataTable
                JobCompDataTable.Load(JobCompDataReader)

                If CurrForm = "poestsearch" Then

                    JobCompDataTable = FilterDataTableByPOEstimate(JobCompDataTable, False, True)

                End If

                If _POVendorOnly = True Then

                    JobCompDataTable = FilterDataTableByPOVendor(JobCompDataTable, False, True, False)

                End If

                Me.RadGridLookup.DataSource = JobCompDataTable

            Case "jobschedule"
                If Client = "" And Division = "" And Product = "" Then 'show all
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.TrafficOpen, True)
                ElseIf JobType <> "" Then
                    Me.RadGridLookup.DataSource = oDD.GetJobListJobType(CStr(Session("UserCode")), Client, Division, Product, JobType)
                Else
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.Traffic)
                End If
                Me.HiddenFieldLookupType.Value = "jobschedule"
            Case "jobschedulenew"
                If Me.CheckboxClosedJobs.Checked = True Then 'this pathway not currently used
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.ScheduleRequired)
                Else
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.ScheduleNew, True)
                End If
                Me.HiddenFieldLookupType.Value = "jobschedulenew"
            Case "jobcompschedulenew"
                Me.RadGridLookup.DataSource = oDD.GetJobCompListSchedule(Session("UserCode"), Client, Division, Product, JobNo, Me.CheckboxClosedJobs.Checked)
                Me.HiddenFieldLookupType.Value = "jobcompschedule"
            Case "jobcompschedule"
                If Client = "" And Division = "" And Product = "" And JobNo < 1 Then 'user hit the comp link with no other data
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")))
                ElseIf JobNo > 0 Then 'user hit the complink with  a job
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(Session("UserCode"), "", "", "", JobNo)
                Else
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")), Client, Division, Product)
                End If
                Me.HiddenFieldLookupType.Value = "jobcompschedule"
            Case "jobschedulejt"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If JobType <> "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobListJobType(CStr(Session("UserCode")), Client, Division, Product, JobType, True)
                    ElseIf Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.Traffic, True)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.Traffic, True)
                    End If
                Else
                    If JobType <> "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobListJobType(CStr(Session("UserCode")), Client, Division, Product, JobType)
                    ElseIf Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.TrafficOpen, True)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.Traffic)
                    End If
                End If
                Me.HiddenFieldLookupType.Value = "jobschedule"
            Case "jobcompschedulejt"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If JobNo > 0 Then 'user hit the complink with  a job
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(Session("UserCode"), "", "", "", JobNo, True)
                    ElseIf JobType <> "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasScheduleJT(Session("UserCode"), JobType, True)
                    ElseIf Client = "" And Division = "" And Product = "" And JobNo < 1 Then 'user hit the comp link with no other data
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")), True)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")), Client, Division, Product, True)
                    End If
                Else
                    If JobNo > 0 Then 'user hit the complink with  a job
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(Session("UserCode"), "", "", "", JobNo)
                    ElseIf JobType <> "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasScheduleJT(Session("UserCode"), JobType)
                    ElseIf Client = "" And Division = "" And Product = "" And JobNo < 1 Then 'user hit the comp link with no other data
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")))
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")), Client, Division, Product)
                    End If
                End If
                Me.HiddenFieldLookupType.Value = "jobcompschedule"
            Case "product"
                Me.HiddenFieldLookupType.Value = "product"
                Dim Direction As String
                If Client.Trim = "" And Division.Trim = "" Then
                    Direction = "Backward"
                Else
                    Direction = "Forward"
                End If
                If Me.CheckboxClosedJobs.Checked = True Then
                    Me.RadGridLookup.DataSource = oDD.GetFilterProducts(Session("UserCode"), "", Client, Division, Direction, False, Me.IsClientPortal, Session("UserID"))
                Else
                    Me.RadGridLookup.DataSource = oDD.GetFilterProducts(Session("UserCode"), "", Client, Division, Direction, True, Me.IsClientPortal, Session("UserID"))
                End If
            Case "division"
                Me.HiddenFieldLookupType.Value = "division"
                Me.RadGridLookup.DataSource = oDD.GetDivisionList(CStr(Session("UserCode")), Client)

            Case "badtl_client"
                Me.HiddenFieldLookupType.Value = "badtl_client"
                Dim ThisBatchID As Integer = 0
                Try
                    If Not Request.QueryString("BAID") = Nothing Then
                        ThisBatchID = CType(Request.QueryString("BAID"), Integer)
                    End If
                Catch ex As Exception
                    ThisBatchID = 0
                End Try
                Me.RadGridLookup.DataSource = oDD.GetClientsByBatchID(ThisBatchID)
            Case "adsize"
                Me.RadGridLookup.DataSource = oDD.GetADSizes(Vendor)
            Case "adnumber"
                Me.RadGridLookup.DataSource = oDD.ddAdNumber
            Case "adnumber_cli"
                Me.RadGridLookup.DataSource = oDD.ddAdNumberwithClient(Client)
            Case "badtl_avail_fn"
                Me.HiddenFieldLookupType.Value = "badtl_avail_fn"
                Me.RadGridLookup.DataSource = oDD.GetApprovalAvailableFunctions(JobNo, JobComp, BaApprovalId, BaBatchId)
            Case "polist"
                Me.RadGridLookup.DataSource = oDD.GetPOList(Request.QueryString("void"), Request.QueryString("closed"), Session("UserCode"))
            Case "estimate"
                Me.RadGridLookup.DataSource = oDD.GetEstimateList(Session("UserCode"), Client, Division, Product, JobNo, JobComp)
                Me.HiddenFieldLookupType.Value = "estimate"
            Case "estimatecomp"
                Me.RadGridLookup.DataSource = oDD.GetEstimateCompList(Session("UserCode"), Client, Division, Product, EstNo, JobNo, JobComp)
                Me.HiddenFieldLookupType.Value = "estimatecomp"
            Case "estimatequote"
                Me.RadGridLookup.DataSource = oDD.GetEstimateQuoteList(Session("UserCode"), Client, Division, Product, EstNo, EstComp)
                Me.HiddenFieldLookupType.Value = "estimatequote"
            Case "estimatecopy"
                Me.RadGridLookup.DataSource = oDD.GetEstimateListCopy(Session("UserCode"), Client, Division, Product, JobType)
                Me.HiddenFieldLookupType.Value = "estimatecopy"
            Case "jobestimate"
                If Client = "" And Division = "" And Product = "" And EstNo = 0 And EstComp = 0 Then 'show all
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.JobEstimate, CheckboxClosedJobs.Checked)
                ElseIf EstNo > 0 And EstComp > 0 And est.CheckJobEstimateCompNumber(EstNo, EstComp) = True And est.JobComponentCount(EstNo) > 1 Then
                    Me.RadGridLookup.DataSource = oDD.GetJobList(Session("UserCode"), EstNo, EstComp, CheckboxClosedJobs.Checked)
                ElseIf EstNo > 0 And EstComp > 0 And est.CheckJobEstimateCompNumber(EstNo, EstComp) = True And est.JobComponentCount(EstNo) = 1 Then
                    Me.RadGridLookup.DataSource = oDD.GetJobListEst(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobEstimateSave, SalesClass, "")
                ElseIf EstNo > 0 And est.CheckJobEstimateNumber(EstNo) = True Then
                    Me.RadGridLookup.DataSource = oDD.GetJobList(Session("UserCode"), EstNo, CheckboxClosedJobs.Checked)
                ElseIf EstNo > 0 And est.CheckJobEstimateNumber(EstNo) = False Then
                    Me.RadGridLookup.DataSource = oDD.GetJobListEst(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobEstimateSave, SalesClass, "")
                Else
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobEstimate)
                End If
                Me.HiddenFieldLookupType.Value = "jobschedule"
            Case "jobcompestimate"
                If Client = "" And Division = "" And Product = "" And EstNo = 0 And EstComp = 0 And JobNo < 1 And SalesClass = "" Then 'user hit the comp link with no other data
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimate(CStr(Session("UserCode")), CheckboxClosedJobs.Checked)
                ElseIf JobNo > 0 And EstNo = 0 And EstComp = 0 Then 'user hit the complink with  a job
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimate(Session("UserCode"), "", "", "", JobNo, CheckboxClosedJobs.Checked)
                ElseIf EstNo > 0 And EstComp > 0 And est.CheckJobEstimateCompNumber(EstNo, EstComp) = True And est.JobComponentCount(EstNo) > 1 Then
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimate(Session("UserCode"), EstNo, EstComp)
                ElseIf EstNo > 0 And EstComp > 0 And est.CheckJobEstimateCompNumber(EstNo, EstComp) = True And est.JobComponentCount(EstNo) = 1 Then
                    If JobNo > 0 Then 'user hit the complink with  a job
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimateSave(Session("UserCode"), "", "", "", JobNo)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimateSave(CStr(Session("UserCode")), Client, Division, Product, SalesClass)
                    End If
                ElseIf EstNo > 0 And est.CheckJobEstimateNumber(EstNo) = True Then
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimate(Session("UserCode"), EstNo)
                ElseIf EstNo > 0 And est.CheckJobEstimateNumber(EstNo) = False Then
                    If JobNo > 0 Then 'user hit the complink with  a job
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimateSave(Session("UserCode"), "", "", "", JobNo)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimateSave(CStr(Session("UserCode")), Client, Division, Product, SalesClass)
                    End If
                Else
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimate(CStr(Session("UserCode")), Client, Division, Product, CheckboxClosedJobs.Checked)
                End If
                Me.HiddenFieldLookupType.Value = "jobcompschedule"
            Case "jobestimatesave"
                Me.RadGridLookup.DataSource = oDD.GetJobListEst(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobEstimateSave, SalesClass, "")
                Me.HiddenFieldLookupType.Value = "jobschedule"
            Case "jobcompestimatesave"
                If JobNo > 0 Then 'user hit the complink with  a job
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimateSave(Session("UserCode"), "", "", "", JobNo)
                Else
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimateSave(CStr(Session("UserCode")), Client, Division, Product, SalesClass)
                End If
                Me.HiddenFieldLookupType.Value = "jobcompschedule"
            Case "poGLAccount"
                Me.RadGridLookup.DataSource = oDD.GetGLAccountList(EmpCode)
            Case "taxcodes"
                Me.RadGridLookup.DataSource = oDD.ddTaxCodes
            Case "funcEst"
                Me.RadGridLookup.DataSource = oDD.GetFunctionsAllEst
                Me.JobNumber = JobNo
                Me.JobComponentNbr = JobComp
                Me.ClCode = Client
                Me.DivCode = Division
                Me.PrdCode = Product
                Me.ScCode = SalesClass
                Me.EmpCode = EmpCode
            Case "evt_gen_fnc"
                Me.RadGridLookup.DataSource = oDD.GetFunctionsAllEvt
                Me.JobNumber = JobNo
                Me.JobComponentNbr = JobComp
                Me.ClCode = Client
                Me.DivCode = Division
                Me.PrdCode = Product
                Me.ScCode = SalesClass
            Case "suppliedby"
                If Request.QueryString("functype") = "E" Or Me.HiddenFieldLookupType.Value = "E" Then
                    Me.RadGridLookup.DataSource = oDD.GetEmployees(CStr(Session("UserCode")))
                    Me.CheckBoxMediaVendors.Visible = False
                ElseIf Request.QueryString("functype") = "V" Or Me.HiddenFieldLookupType.Value = "V" Then
                    If Me.CheckboxClosedJobs.Checked = True Then
                        Me.RadGridLookup.DataSource = oDD.GetVendorsByFunctionCode(Request.QueryString("funccode"), Me.CheckBoxMediaVendors.Checked)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetVendorsAll(Me.CheckBoxMediaVendors.Checked)
                    End If
                End If
            Case "jobcopy"

                Dim DataDatatable As New DataTable

                Dim StatusCode As String = String.Empty

                If Request.QueryString("status") IsNot Nothing Then

                    StatusCode = Request.QueryString("status")

                End If

                If Me.CheckboxClosedJobs.Checked = True Then
                    If JobType <> "" Then
                        DataDatatable = oDD.GetJobListWithJobType(CStr(Session("UserCode")), Client, Division, Product, JobType, True)
                    ElseIf Client = "" And Division = "" And Product = "" Then 'show all
                        DataDatatable = oDD.GetJobList(CStr(Session("UserCode")), JobListType.General, True)
                    Else
                        DataDatatable = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobJacket, True)
                    End If
                Else
                    If JobType <> "" Then
                        DataDatatable = oDD.GetJobListWithJobType(CStr(Session("UserCode")), Client, Division, Product, JobType)
                    ElseIf Client = "" And Division = "" And Product = "" Then 'show all
                        DataDatatable = oDD.GetJobList(CStr(Session("UserCode")), JobListType.General)
                    Else
                        DataDatatable = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobJacket)
                    End If
                End If

                If String.IsNullOrWhiteSpace(StatusCode) = False AndAlso DataDatatable IsNot Nothing AndAlso DataDatatable.Rows.Count > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim JobsList As String = String.Empty
                        Dim FilteredJobsList As Generic.List(Of Integer)

                        For i As Integer = 0 To DataDatatable.Rows.Count - 1

                            'JobsList.Add(DataDatatable.Rows(i)("code"))
                            JobsList &= DataDatatable.Rows(i)("code") & ","

                        Next

                        JobsList = MiscFN.CleanStringForSplit(JobsList, ",")

                        FilteredJobsList = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DISTINCT JT.JOB_NUMBER FROM JOB_LOG J INNER JOIN JOB_COMPONENT JC ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN JOB_TRAFFIC JT ON JT.JOB_NUMBER = JC.JOB_NUMBER AND JT.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR WHERE JT.TRF_CODE = '{0}' AND J.JOB_NUMBER IN ({1});", StatusCode, JobsList)).ToList

                        If FilteredJobsList IsNot Nothing AndAlso FilteredJobsList.Count > 0 Then

                            JobsList = String.Empty

                            For Each JobNumber As Integer In FilteredJobsList

                                JobsList &= JobNumber.ToString & ","

                            Next

                            JobsList = MiscFN.CleanStringForSplit(JobsList, ",")


                        End If

                        DataDatatable.DefaultView.RowFilter = String.Format(" code IN ({0})", JobsList)

                        Me.RadGridLookup.DataSource = DataDatatable.DefaultView

                    End Using

                Else

                    Me.RadGridLookup.DataSource = DataDatatable

                End If

                Me.HiddenFieldLookupType.Value = "jobschedule"

            Case "jobcopyps"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If JobType <> "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobListWithJobType(CStr(Session("UserCode")), Client, Division, Product, JobType, True)
                    ElseIf Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.Traffic, True)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.Traffic, True)
                    End If
                Else
                    If JobType <> "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobListWithJobType(CStr(Session("UserCode")), Client, Division, Product, JobType)
                    ElseIf Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.Traffic)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.Traffic)
                    End If
                End If
                Me.HiddenFieldLookupType.Value = "jobschedule"
            Case "jobcopycompps"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If JobType <> "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobListWithJobType(CStr(Session("UserCode")), Client, Division, Product, JobType, True)
                    ElseIf JobNo = 0 And Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")), True)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")), Client, Division, Product, JobNo, True)
                    End If
                Else
                    If JobType <> "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobListWithJobType(CStr(Session("UserCode")), Client, Division, Product, JobType)
                    ElseIf JobNo = 0 And Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")))
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobcompListHasSchedule(CStr(Session("UserCode")), Client, Division, Product, JobNo)
                    End If
                End If
                Me.HiddenFieldLookupType.Value = "jobcompschedule"
            Case "estimatejobsearch"
                If Client = "" And Division = "" And Product = "" And EstNo = 0 And EstComp = 0 Then 'show all
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.JobEstimate, CheckboxClosedJobs.Checked)
                ElseIf EstNo > 0 And EstComp > 0 And est.CheckJobEstimateCompNumber(EstNo, EstComp) = True Then
                    Me.RadGridLookup.DataSource = oDD.GetJobList(Session("UserCode"), EstNo, EstComp, CheckboxClosedJobs.Checked)
                ElseIf EstNo > 0 And est.CheckJobEstimateNumber(EstNo) = True Then
                    Me.RadGridLookup.DataSource = oDD.GetJobList(Session("UserCode"), EstNo, CheckboxClosedJobs.Checked)
                ElseIf EstNo > 0 And est.CheckJobEstimateNumber(EstNo) = False Then
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobEstimateSave, "", "", "", CheckboxClosedJobs.Checked)
                Else
                    Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobEstimate, "", "", "", CheckboxClosedJobs.Checked)
                End If
                Me.HiddenFieldLookupType.Value = "jobschedule"
            Case "estimatejobcompsearch"
                If Client = "" And Division = "" And Product = "" And EstNo = 0 And EstComp = 0 And JobNo < 1 And SalesClass = "" Then 'user hit the comp link with no other data
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimate(CStr(Session("UserCode")), CheckboxClosedJobs.Checked)
                ElseIf JobNo > 0 And EstNo = 0 And EstComp = 0 Then 'user hit the complink with  a job
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimate(Session("UserCode"), "", "", "", JobNo, CheckboxClosedJobs.Checked)
                ElseIf EstNo > 0 And EstComp > 0 And est.CheckJobEstimateCompNumber(EstNo, EstComp) = True Then
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimateSearch(Session("UserCode"), EstNo, EstComp, CheckboxClosedJobs.Checked)
                ElseIf EstNo > 0 And est.CheckJobEstimateNumber(EstNo) = True Then
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimateSearch(Session("UserCode"), EstNo, CheckboxClosedJobs.Checked)
                Else
                    Me.RadGridLookup.DataSource = oDD.GetJobcompListHasEstimate(CStr(Session("UserCode")), Client, Division, Product, CheckboxClosedJobs.Checked)
                End If
                Me.HiddenFieldLookupType.Value = "jobcompschedule"
            Case "jobtype"

                Dim str As String = ""

                If JobNo <> 0 Then

                    Dim j As New JOB_LOG(Session("ConnString"))
                    If j.LoadByPrimaryKey(JobNo) Then

                        str = j.SC_CODE

                    End If

                End If
                If String.IsNullOrWhiteSpace(str) = True AndAlso String.IsNullOrWhiteSpace(SalesClass) = False Then

                    str = SalesClass

                End If
                If str = "" AndAlso Me.CurrForm.Contains("jtn") = True Then

                    Me.RadGridLookup.DataSource = oDD.ddJobTypejh("")

                Else

                    Me.RadGridLookup.DataSource = oDD.ddJobType(str)

                End If
            Case "jobtypejh"
                Me.RadGridLookup.DataSource = oDD.ddJobTypejh("")
            Case "statuscodes", "copyjob_statuscodes"
                Me.RadGridLookup.DataSource = oDD.GetTrafficCodes()

            Case "campaign"
                Dim CmpDataReader As SqlDataReader = Nothing
                Dim CmpDataTable As DataTable = Nothing
                Me.CheckboxClosedJobs.Text = "Show Closed Campaigns?"
                Me.CheckboxClosedJobs.Visible = True

                Dim InclClosed As Integer = 0
                If Me.CheckboxClosedJobs.Checked = True Then
                    InclClosed = 1
                End If

                CmpDataReader = oDD.CampaignSearch(Session("UserCode"), Office, Client, Division, Product, InclClosed)
                CmpDataTable = New DataTable
                CmpDataTable.Load(CmpDataReader)

                If _POVendorOnly Then

                    CmpDataTable = FilterDataTableByPOVendor(CmpDataTable, False, False, True)

                End If

                Me.RadGridLookup.DataSource = CmpDataTable

                Me.HiddenFieldLookupType.Value = "campaign"
                Me.ClCode = Client
                Me.DivCode = Division
                Me.PrdCode = Product
                Me.OfficeCode = Office

            Case "campaignjobnew"
                Me.CheckboxClosedJobs.Text = "Show Closed Campaigns?"
                Me.CheckboxClosedJobs.Visible = False

                Dim InclClosed As Integer = 0
                'If Me.CheckboxClosedJobs.Checked = True Then
                '    InclClosed = 1
                'End If

                Me.RadGridLookup.DataSource = oDD.CampaignSearchJobNew(Session("UserCode"), Office, Client, Division, Product, InclClosed)

                Me.HiddenFieldLookupType.Value = "campaign"
                Me.ClCode = Client
                Me.DivCode = Division
                Me.PrdCode = Product
                Me.OfficeCode = Office

            Case "estcampaign", "estcampaignedit"
                'Me.CheckboxClosedJobs.Text = "Show Closed Campaigns?"
                'Me.CheckboxClosedJobs.Visible = True

                Dim InclClosed As Integer = 0
                If Me.CheckboxClosedJobs.Checked = True Then
                    InclClosed = 1
                End If

                Me.RadGridLookup.DataSource = oDD.CampaignSearchEstimate(Session("UserCode"), Office, Client, Division, Product, InclClosed)

                Me.HiddenFieldLookupType.Value = "campaign"
                Me.ClCode = Client
                Me.DivCode = Division
                Me.PrdCode = Product
                Me.OfficeCode = Office

            Case "creativebrief"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.CreativeBrief, True)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.CreativeBrief, True)
                    End If
                Else
                    If Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.CreativeBrief)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.CreativeBrief)
                    End If
                End If
                Me.HiddenFieldLookupType.Value = "jobschedule"
            Case "creativebriefjj"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListCB(CStr(Session("UserCode")), True)
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListCB(Session("UserCode"), Client, Division, Product, JobNo, True)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                Else
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListCB(CStr(Session("UserCode")))
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListCB(Session("UserCode"), Client, Division, Product, JobNo)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                End If
            Case "jobversion"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.JobVersion, True)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobVersion, True)
                    End If
                Else
                    If Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.JobVersion)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobVersion)
                    End If
                End If
                Me.HiddenFieldLookupType.Value = "jobschedule"
            Case "jobversionjj"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJV(CStr(Session("UserCode")), True)
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJV(Session("UserCode"), Client, Division, Product, JobNo, True)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                Else
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJV(CStr(Session("UserCode")))
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJV(Session("UserCode"), Client, Division, Product, JobNo)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                End If
            Case "jobspecs"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.JobSpecs, True)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobSpecs, True)
                    End If
                Else
                    If Client = "" And Division = "" And Product = "" Then 'show all
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), JobListType.JobSpecs)
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobList(CStr(Session("UserCode")), Client, Division, Product, JobListType.JobSpecs)
                    End If
                End If
                Me.HiddenFieldLookupType.Value = "jobschedule"
            Case "jobspecsjj"
                If Me.CheckboxClosedJobs.Checked = True Then
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJS(CStr(Session("UserCode")), True)
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJS(Session("UserCode"), Client, Division, Product, JobNo, True)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                Else
                    If JobNo = 0 And Client = "" And Division = "" And Product = "" Then
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJS(CStr(Session("UserCode")))
                        Me.HiddenFieldLookupType.Value = "JobComp1"
                    Else
                        Me.RadGridLookup.DataSource = oDD.GetJobCompListJS(Session("UserCode"), Client, Division, Product, JobNo)
                        Me.HiddenFieldLookupType.Value = "JobComp2"
                        Me.ClCode = Client
                        Me.DivCode = Division
                        Me.PrdCode = Product
                        Me.JobNumber = JobNo
                    End If
                End If
            Case "task"
                Dim j As Integer = 0
                Dim jc As Integer = 0
                Try
                    If Not Request.QueryString("j") Is Nothing Then
                        If IsNumeric(Request.QueryString("j")) Then
                            j = CType(Request.QueryString("j"), Integer)
                        End If
                    End If
                Catch ex As Exception
                    j = 0
                End Try

                Try
                    If Not Request.QueryString("jc") Is Nothing Then
                        If IsNumeric(Request.QueryString("jc")) Then
                            jc = CType(Request.QueryString("jc"), Integer)
                        End If
                    End If
                Catch ex As Exception
                    jc = 0
                End Try
                Me.RadGridLookup.DataSource = oDD.GetTasks(j, jc)
                Me.HiddenFieldLookupType.Value = Type
            Case "atb"

                Me.CheckboxClosedJobs.Text = "Show Closed ATBs?"
                Me.CheckboxClosedJobs.Visible = True

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    RadGridLookup.DataSource = (From Entity In AdvantageFramework.Database.Procedures.MediaATBComplex.Load(DbContext, Session("UserCode"), Nothing, Nothing, Nothing, Client, Division, Product, CheckboxClosedJobs.Checked)
                                                Select [ATBNum] = Entity.ATBNumber,
                                                       Entity.Description,
                                                       Entity.ClientCode,
                                                       Entity.DivisionCode,
                                                       Entity.ProductCode).ToList.Select(Function(Entity) New With {.Code = Entity.[ATBNum],
                                                                                                                    .Description = Entity.[ATBNum].ToString.PadLeft(6, "0") & " - " & Entity.Description & " | " & Entity.ClientCode & " | " & Entity.DivisionCode & " | " & Entity.ProductCode}).OrderByDescending(Function(ATB) ATB.Code).ToList
                End Using

                Me.HiddenFieldLookupType.Value = Type

                Me.ClCode = Client
                Me.DivCode = Division
                Me.PrdCode = Product
                Me.CampaignId = Campaign
        End Select

    End Sub

#End Region

#Region " Functions "

    Private Sub SelectItem()
        Try
            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
            Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim ae As String
            Dim req As cRequired = New cRequired(Session("ConnString"))

            Dim CodeCtrlName As String = ""
            Dim DescriptCtrlName As String = ""

            CodeCtrlName = Me._ControlId
            Try
                If Request.QueryString("ctrlc") IsNot Nothing Then CodeCtrlName = Request.QueryString("ctrlc")
            Catch ex As Exception
                CodeCtrlName = ""
            End Try
            Try
                DescriptCtrlName = Request.QueryString("ctrld")
            Catch ex As Exception
                DescriptCtrlName = ""
            End Try
            Try
                If IsNumeric(Request.QueryString("job")) Then
                    Me.JobNumber = CInt(Request.QueryString("job"))
                Else
                    Me.JobNumber = 0
                End If
            Catch ex As Exception
                Me.JobNumber = 0
            End Try
            Try
                If IsNumeric(Request.QueryString("jobcomp")) Then
                    Me.JobComponentNbr = CInt(Request.QueryString("jobcomp"))
                Else
                    Me.JobComponentNbr = 0
                End If
            Catch ex As Exception
                Me.JobComponentNbr = 0
            End Try

            Dim dtInfo As New DataTable
            Dim dtEst As New DataTable
            Dim dtEstComp As New DataTable

            Select Case Me.HiddenFieldLookupType.Value
                Case "Job1", "Job2", "task_j"         ', "jobschedule"
                    Me.JobNumber = CType(Me.SelectedValue(Me.RadGridLookup), Integer)
                    oTS.GetJobInfo(Me.JobNumber, JobDescription, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", "", "", "", Me.ScCode, "", Me.CmpCode, Me.CampaignId)

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(Me.JobNumber, True)
                    If i > 0 Then
                        Me.JobComponentNbr = i
                        oTS.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, , CompDescription, , , , , , , , , , , , , , , , EmpCode)
                    End If
                Case "jobschedule"
                    Me.JobNumber = Me.SelectedValue(Me.RadGridLookup)
                Case "jobschedulenew"
                    Try
                        If Me.SelectedValue(Me.RadGridLookup).ToString().IndexOf("-") > 0 Then
                            Me.JobNumber = CInt(Me.SelectedValue(Me.RadGridLookup).Split("-")(0).ToString())
                            Me.JobComponentNbr = Me.SelectedValue(Me.RadGridLookup).Split("-")(1).ToString
                        Else
                            If IsNumeric(Me.SelectedValue(Me.RadGridLookup)) = True Then
                                Me.JobNumber = CType(Me.SelectedValue(Me.RadGridLookup), Integer)
                                Me.JobComponentNbr = "0"
                            Else
                                Me.JobNumber = "0"
                                Me.JobComponentNbr = "0"
                            End If
                        End If
                    Catch ex As Exception
                        Me.JobNumber = "0"
                        Me.JobComponentNbr = "0"
                    End Try
                Case "JobComp1"
                    Me.JobNumber = CInt(Me.SelectedValue(Me.RadGridLookup).Split("-")(0).ToString())
                    Me.JobComponentNbr = CInt(Me.SelectedValue(Me.RadGridLookup).Split("-")(1).ToString())
                    oTS.GetJobInfo(Me.JobNumber, "", Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", "", "", "", Me.ScCode, "", Me.CmpCode, Me.CampaignId)
                    If Me.JobComponentNbr > 0 Then
                        oTS.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, , , , , , , , , , , , , , , , , , EmpCode)
                    End If
                Case "JobComp2"
                    Dim IsNewAlert As Boolean = False
                    Try
                        If Not Request.QueryString("form") Is Nothing Then
                            If Request.QueryString("form") = "newalert" Then
                                IsNewAlert = True
                            End If
                        End If
                    Catch ex As Exception
                        IsNewAlert = False
                    End Try
                    If IsNewAlert = False Then 'original path
                        Dim JobComp As String
                        JobComp = Me.SelectedValue(Me.RadGridLookup)
                        Try
                            If Me.JobNumber = "" Or Me.JobNumber = "0" Then
                                Me.JobNumber = CInt(Me.SelectedText(Me.RadGridLookup).Split("-")(0).ToString.Trim)
                            End If
                        Catch ex As Exception
                        End Try
                        If JobComp.IndexOf("-") > 0 Then
                            JobComp = Me.SelectedValue(Me.RadGridLookup).Split("-")(1).ToString
                            Me.JobComponentNbr = JobComp
                        Else
                            Me.JobComponentNbr = JobComp
                        End If
                        If Me.JobComponentNbr > 0 Then
                            oTS.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, JobDescription, CompDescription, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, , , , , Me.ScCode, Me.CmpCode, Me.CampaignId, , , , , Me.EmpCode)
                        Else
                            oTS.GetJobInfo(Me.JobNumber, JobDescription, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", "", "", "", Me.ScCode, "", Me.CmpCode, Me.CampaignId)
                        End If
                    Else
                        Try
                            Dim ar() As String
                            Dim ar1() As String
                            If Me.JobNumber = "" Or Me.JobNumber = "0" Then
                                ar = Me.SelectedText(Me.RadGridLookup).ToString().Split("|")
                                ar1 = ar(0).ToString().Trim().Split("-")
                                Me.JobNumber = ar1(0).ToString()
                                Me.JobComponentNbr = ar1(1).ToString()
                            Else
                                ar = Me.SelectedText(Me.RadGridLookup).ToString().Replace(" ", "").Split("-")
                                If IsNumeric(ar(0)) = True Then
                                    Me.JobComponentNbr = ar(0)
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If

                Case "jobcompschedule", "task_jc"
                    Try
                        Me.JobNumber = Me.SelectedValue(Me.RadGridLookup).ToString.Split("-")(0)
                    Catch ex As Exception
                    End Try
                    Try
                        Me.JobComponentNbr = Me.SelectedValue(Me.RadGridLookup).ToString.Split("-")(1)
                    Catch ex As Exception
                    End Try
                Case "product"
                    Dim arValues() As String
                    arValues = Me.SelectedValue(Me.RadGridLookup).ToString.Split("|")
                    Me.OfficeCode = arValues(0).ToString
                    Me.ClCode = arValues(1).ToString
                    Me.DivCode = arValues(2).ToString
                    Me.PrdCode = arValues(3).ToString
                Case "campaign", "estcampaign", "estcampaignedit"
                    Me.CampaignId = Me.SelectedValue(Me.RadGridLookup)
                    Dim cmp As New cCampaign(Session("ConnString"), CType(Me.CampaignId, Integer))
                    If cmp.OFFICE_CODE IsNot Nothing Then
                        Me.OfficeCode = cmp.OFFICE_CODE
                    End If
                    If cmp.CL_CODE IsNot Nothing Then
                        Me.ClCode = cmp.CL_CODE
                    End If
                    If cmp.DIV_CODE IsNot Nothing Then
                        Me.DivCode = cmp.DIV_CODE
                    End If
                    If cmp.PRD_CODE IsNot Nothing Then
                        Me.PrdCode = cmp.PRD_CODE
                    End If
                    If cmp.CMP_CODE IsNot Nothing Then
                        Me.CmpCode = cmp.CMP_CODE
                    End If
                    If IsNumeric(cmp.CMP_IDENTIFIER) Then
                        Me.CampaignId = cmp.CMP_IDENTIFIER.ToString()
                    End If
                    If cmp.CMP_NAME IsNot Nothing Then
                        Me.CampaignDescription = cmp.CMP_NAME
                    End If
                Case "division"
                    Dim arValues() As String
                    arValues = Me.SelectedValue(Me.RadGridLookup).ToString.Split("|")
                    Me.DivCode = arValues(0).ToString
                Case "badtl_client"
                    Me.ClCode = Me.SelectedValue(Me.RadGridLookup)
                Case "estimate"
                    dtEst = oEstimating.GetInfoForEstimate(Me.SelectedValue(Me.RadGridLookup))
                    If dtEst.Rows.Count > 0 Then
                        Me.EstimateNumber = dtEst.Rows(0).Item("ESTIMATE_NUMBER")
                        Dim s As New cEstimating(Session("ConnString"), Session("UserCode"))
                        Dim i As Integer = s.CountHeaderComponentsOneComp(Me.EstimateNumber)
                        If i <> 0 And i <> -1 Then
                            dtEstComp = oEstimating.GetInfoForEstimateComp(Me.EstimateNumber, i)
                            If dtEstComp.Rows.Count > 0 Then
                                Me.EstComponentNbr = i
                            End If
                        End If
                    End If
                Case "estimatecomp"
                    Dim est As Integer
                    Dim estComp As String
                    est = CInt(Me.SelectedValue(Me.RadGridLookup).Split("-")(0).ToString())
                    estComp = Me.SelectedValue(Me.RadGridLookup).Split("-")(1).ToString
                    Me.EstimateNumber = est
                    Me.EstComponentNbr = estComp
                Case "estimatequote"
                    Dim est As Integer
                    Dim estComp As String
                    Dim quote As String
                    est = CInt(Me.SelectedValue(Me.RadGridLookup).Split("-")(0).ToString())
                    estComp = Me.SelectedValue(Me.RadGridLookup).Split("-")(1).ToString
                    quote = Me.SelectedValue(Me.RadGridLookup).Split("-")(2).ToString
                    Me.EstimateNumber = est
                    Me.EstComponentNbr = estComp
                    Me.EstQuoteNbr = quote
                    Me.EstRevNbr = oEstimating.GetEstimateQuoteMaxRevision(est, estComp, quote)
                Case "estimatecopy"
                    Dim est As Integer
                    est = CInt(Me.SelectedValue(Me.RadGridLookup).Split("-")(0).ToString())
                    Me.EstimateNumber = est
                Case "atb"

                    Dim MediaATB As AdvantageFramework.Database.Entities.MediaATB = Nothing
                    Dim CampaignIDs As Generic.List(Of Integer) = Nothing
                    Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

                    ATBNumber = CInt(Me.SelectedValue(Me.RadGridLookup))

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        MediaATB = AdvantageFramework.Database.Procedures.MediaATB.LoadByATBNumber(DbContext, ATBNumber)

                        If MediaATB IsNot Nothing Then

                            Me.ClCode = MediaATB.ClientCode
                            Me.DivCode = MediaATB.DivisionCode
                            Me.PrdCode = MediaATB.ProductCode
                            Me.ATBNumber = ATBNumber

                            CampaignIDs = MediaATB.MediaATBRevisions.ToList.Where(Function(Entity) Entity.CampaignID IsNot Nothing).Select(Function(Entity) Entity.CampaignID.GetValueOrDefault(0)).Distinct.ToList

                            If CampaignIDs IsNot Nothing AndAlso CampaignIDs.Count = 1 Then

                                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, CampaignIDs(0))

                                If Campaign IsNot Nothing Then

                                    Me.CampaignId = Campaign.ID
                                    Me.CmpCode = Campaign.Code

                                End If

                            End If

                        End If

                    End Using

            End Select
            ae = MyJobTemplate.GetDefaultAE(Me.ClCode, Me.DivCode, Me.PrdCode)

            Dim JobNumber As String = ""
            Dim JobComponentNbr As String = ""

            If Me.JobNumber > 0 Then JobNumber = Me.JobNumber.ToString()
            If Me.JobComponentNbr > 0 Then JobComponentNbr = Me.JobComponentNbr.ToString()

            Dim strScript As String = ""
            Dim x As String
            Dim JobInfoCalled As Boolean = False

            If (IsNumeric(Me.JobNumber) = True AndAlso CType(Me.JobNumber, Integer) > 0) AndAlso (Me.ClCode.Trim() = "" OrElse Me.DivCode.Trim() = "" OrElse Me.PrdCode.Trim() = "") Then

                oTS.GetJobInfo(Me.JobNumber, "", Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", "", "", "", Me.ScCode, "", Me.CmpCode, Me.CampaignId)
                JobInfoCalled = True

            End If



            If Request.QueryString("form") = "ts" Then
                strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ClientCode", Me.ClCode)
                strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_DivisionCode", Me.DivCode)
                strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ProductCode", Me.PrdCode)
                strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_JobCode", JobNumber)
                strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("TextBox_ComponentCode", JobComponentNbr)
            ElseIf Request.QueryString("form") = "jobjacket" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtJob').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtJobComp').value = '" & JobComponentNbr & "';"
            ElseIf Request.QueryString("form") = "jobpanel" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtOffice').value = '" & Me.OfficeCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtJob').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtComponent').value = '" & JobComponentNbr & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Jobpanel1_txtSalesClass').value = '" & Me.ScCode & "';"
            ElseIf Request.QueryString("form") = "jobsearch" Then
                If Me.IsClientPortal = True Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    If Me.JobNumber > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & Me.JobNumber & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='';"
                    End If
                    If Me.JobComponentNbr > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & Me.JobComponentNbr & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '';"
                    End If
                Else
                    'strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOffice').value = '" & Me.OfficeCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    If Me.JobNumber > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & Me.JobNumber & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='';"
                    End If
                    If Me.JobComponentNbr > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & Me.JobComponentNbr & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '';"
                    End If
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtSalesClass').value = '" & Me.ScCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtCampaign').value = '" & Me.CmpCode & "';"
                    Try
                        If Me.CampaignId <> 0 Then
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_hfCampaignID').value = '" & Me.CampaignId & "';"
                        End If
                    Catch ex As Exception
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_hfCampaignID').value = '';"
                    End Try
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtAE').value = '" & Me.EmpCode & "';"

                    If _AutoSearch Then

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                    End If

                End If
            ElseIf Request.QueryString("form") = "jobrequestjob" Then
                If Me.IsClientPortal = True Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    If Me.JobNumber > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value ='" & Me.JobNumber & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_JobNbrRequest').value ='" & Me.JobDescription & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value ='';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_JobNbrRequest').value ='';"
                    End If
                    If Me.JobComponentNbr > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & Me.JobComponentNbr & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_CompNbrRequest').value = '" & Me.CompDescription & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_CompNbrRequest').value = '';"
                    End If
                Else
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    If Me.JobNumber > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value ='" & Me.JobNumber & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_JobNbrRequest').value ='" & Me.JobDescription & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value ='';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_JobNbrRequest').value ='';"
                    End If
                    If Me.JobComponentNbr > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & Me.JobComponentNbr & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_CompNbrRequest').value = '" & Me.CompDescription & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_CompNbrRequest').value = '';"
                    End If
                End If
            ElseIf Request.QueryString("form") = "jobrequestComp" Then

                Dim ClDesc As String = ""
                Dim DivDesc As String = ""
                Dim PrdDesc As String = ""
                Dim JobDesc As String = ""
                Dim ScDesc As String = ""
                oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, ScDesc, Me.CmpCode, Me.CampaignId)

                'strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                'strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                'strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                'strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxClientDescription').value = '" & ClDesc.Replace("'", "\'") & "';"
                'strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxDivisionDescription').value = '" & DivDesc.Replace("'", "\'") & "';"
                'strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxProductDescription').value = '" & PrdDesc.Replace("'", "\'") & "';"
                If Me.JobNumber > 0 Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value ='" & Me.JobNumber & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxJobDescription').value ='" & Me.JobDescription & "';"
                Else
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value ='';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxJobDescription').value ='';"
                End If
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxSalesClass').value = '" & Me.ScCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxSalesClassDescription').value = '" & ScDesc.Replace("'", "\'") & "';"

            ElseIf Request.QueryString("form") = "popanel" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_txtJob').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_txtComponent').value = '" & JobComponentNbr & "';"

                If _AutoSearch Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                End If

            ElseIf Request.QueryString("form") = "poestsearch" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Client').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Division').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Product').value = '" & Me.PrdCode & "';"

                If Request.QueryString("type") = "job" OrElse Request.QueryString("type") = "jobcomppo" Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Job').value ='" & JobNumber & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Component').value = '" & JobComponentNbr & "';"

                ElseIf Request.QueryString("type") = "campaign" Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Campaign').value = '" & Me.CmpCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_HiddenField_Campaign').value = '" & CampaignId & "';"

                End If

            ElseIf Request.QueryString("form") = "taskfilter" Then
                If Request.QueryString("cp") <> "1" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOffice').value = '" & Me.OfficeCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                End If
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJobComp').value = '" & JobComponentNbr & "';"
            ElseIf Request.QueryString("form") = "traffsearch" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & JobComponentNbr & "';"
            ElseIf Request.QueryString("form") = "alertinbox" Then
                Select Case Me.HiddenFieldLookupType.Value
                    Case "product"
                        If Request.QueryString("cp") <> "1" Then
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOffice').value = '" & Me.OfficeCode & "';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                        End If
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    Case "campaign"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOffice').value = '" & Me.OfficeCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtCampaign').value = '" & Me.CmpCode & "';"
                    Case "estimate"
                        dtEst = oEstimating.GetInfoForEstimate(Me.EstimateNumber)
                        If Not dtEst Is Nothing Then
                            If dtEst.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & dtEst.Rows(0)("CL_CODE") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & dtEst.Rows(0)("DIV_CODE") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & dtEst.Rows(0)("PRD_CODE") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateNumber').value = '" & dtEst.Rows(0)("ESTIMATE_NUMBER") & "';"
                            End If
                        End If
                    Case "estimatecomp"
                        dtEst = oEstimating.GetInfoForEstimate(Me.EstimateNumber)
                        If Not dtEst Is Nothing Then
                            If dtEst.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & dtEst.Rows(0)("CL_CODE") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & dtEst.Rows(0)("DIV_CODE") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & dtEst.Rows(0)("PRD_CODE") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateNumber').value = '" & dtEst.Rows(0)("ESTIMATE_NUMBER") & "';"
                                If Me.EstComponentNbr > 0 Then
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentNbr').value = '" & Me.EstComponentNbr & "';"
                                Else
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentNbr').value = '" & dtEst.Rows(0)("EST_COMPONENT_NBR") & "';"
                                End If
                            End If
                        End If
                    Case "job", "Job1", "Job2"
                        If Request.QueryString("cp") <> "1" Then
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOffice').value = '" & Me.OfficeCode & "';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                        End If
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"

                    Case "JobComp1", "JobComp2", "jobcompjj"
                        If Request.QueryString("cp") <> "1" Then
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOffice').value = '" & Me.OfficeCode & "';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                        End If
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & JobComponentNbr & "';"
                    Case "task_j"
                        JobNumber = Me.SelectedValue(Me.RadGridLookup)
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"
                        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                        Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                        If i > 0 Then
                            JobComponentNbr = i
                        End If
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & JobComponentNbr & "';"

                    Case "task_jc"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & JobComponentNbr & "';"
                    Case "task"
                        Try
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtTaskCode').value = '" & Me.SelectedValue(Me.RadGridLookup).ToString() & "';"
                            Try
                                Dim ar()
                                ar = Me.SelectedText(Me.RadGridLookup).ToString().Split("-") ' code - description
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtTaskDescription').value = '" & ar(1).ToString().Trim() & "';"
                            Catch ex As Exception
                            End Try
                        Catch ex As Exception
                        End Try
                    Case "atb"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtATBNumber').value = '" & Me.ATBNumber & "';"

                End Select
            ElseIf Request.QueryString("form") = "newalert" Then
                Dim ClDesc As String = ""
                Dim DivDesc As String = ""
                Dim PrdDesc As String = ""
                Dim JobDesc As String = ""
                Dim compdesc As String = ""
                Dim officedesc As String = ""

                If JobInfoCalled = False AndAlso (IsNumeric(Me.JobNumber) = True AndAlso CType(Me.JobNumber, Integer) > 0) AndAlso (Me.ClCode.Trim() = "" OrElse Me.DivCode.Trim() = "" OrElse Me.PrdCode.Trim() = "") Then

                    oTS.GetJobInfo(IIf(JobNumber = "", 0, JobNumber), JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, officedesc, ClDesc, DivDesc, PrdDesc, Me.ScCode, "", Me.CmpCode, Me.CampaignId)
                    JobInfoCalled = True

                End If

                Select Case Me.HiddenFieldLookupType.Value.ToLower()
                    Case "job1", "job2"
                        If Request.QueryString("o") = "1" Then 'job link at job level alert
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOffice').value = '" & Me.OfficeCode & "';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtOfficeDescription').value = '" & officedesc & "';"
                        End If
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxClientDescription').value = '" & ClDesc.Replace("'", "\'") & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxDivisionDescription').value = '" & DivDesc.Replace("'", "\'") & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxProductDescription').value = '" & PrdDesc.Replace("'", "\'") & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxJobDescription').value = '" & JobDesc.Replace("'", "\'") & "';"

                        If Request.QueryString("o") = "0" And IsNumeric(JobNumber) Then 'job link at job component level alert
                            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))

                            Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                            If i > 0 Then
                                oTS.GetJobComponentInfo(JobNumber, i, "", compdesc)
                                JobComponentNbr = i
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & JobComponentNbr & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxComponentDescription').value = '" & compdesc.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.GetDefaultAssignment();"

                            End If
                        End If
                        'If IsNumeric(JobNumber) = True Then
                        '    strScript &= "CallingWindowContent.ReloadAutoRecipientControl();"
                        'End If
                    Case "jobcomp1", "jobcomp2"
                        oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, "", compdesc)
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & JobComponentNbr & "';"

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxClientDescription').value = '" & ClDesc.Replace("'", "\'") & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxDivisionDescription').value = '" & DivDesc.Replace("'", "\'") & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxProductDescription').value = '" & PrdDesc.Replace("'", "\'") & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxJobDescription').value = '" & JobDesc.Replace("'", "\'") & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxComponentDescription').value = '" & compdesc.Replace("'", "\'") & "';"
                        'strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').blur();"
                        strScript &= "CallingWindowContent.GetDefaultAssignment();"
                        'If IsNumeric(JobNumber) = True Then
                        '    strScript &= "CallingWindowContent.ReloadAutoRecipientControl();"
                        'End If
                    Case "campaign"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtCampaign').value = '" & Me.CmpCode & "';"
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            Dim campaign As AdvantageFramework.Database.Entities.Campaign
                            campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me.CampaignId)
                            If campaign IsNot Nothing Then
                                If campaign.Client IsNot Nothing Then strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxClientDescription').value = '" & campaign.Client.Name & "';"
                                If campaign.Division IsNot Nothing Then strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxDivisionDescription').value = '" & campaign.Division.Name & "';"
                                If campaign.Product IsNot Nothing Then strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxProductDescription').value = '" & campaign.Product.Name & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxCampaignDescription').value = '" & campaign.Name & "';"
                            End If
                        End Using

                End Select
            ElseIf Request.QueryString("form") = "schedule" Then

                If IsNumeric(JobNumber) = True Then
                    Dim ClDesc As String = ""
                    Dim DivDesc As String = ""
                    Dim PrdDesc As String = ""
                    Dim JobDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, "", Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientCode').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionCode').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductCode').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '" & JobNumber & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientDescription').value = '" & ClDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionDescription').value = '" & DivDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductDescription').value = '" & PrdDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '" & JobDesc.Replace("'", "\'") & "';"

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                    Dim compdesc As String = ""
                    If IsNumeric(JobNumber) = True And i > 0 Then
                        oTS.GetJobComponentInfo(JobNumber, i, "", compdesc)
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & i & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & compdesc.Replace("'", "\'") & "';"
                    ElseIf IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, "", compdesc)
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & JobComponentNbr & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & compdesc.Replace("'", "\'") & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                    End If

                End If
            ElseIf Request.QueryString("form") = "schedule_search" Then
                If IsNumeric(JobNumber) = True Then
                    oTS.GetJobInfo(JobNumber, "", Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", "", "", "", Me.ScCode, "", Me.CmpCode, Me.CampaignId)
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value = '" & JobNumber & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOffice').value = '" & Me.OfficeCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtSalesClass').value = '" & Me.ScCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtCampaign').value = '" & Me.CmpCode & "';"
                    If Me.CampaignId > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_hfCampaignID').value = '" & Me.CampaignId.ToString() & "';"
                    End If
                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                    If IsNumeric(JobNumber) = True And i > 0 Then
                        oTS.GetJobComponentInfo(JobNumber, i, , , , , , , , , , , , , , , , , , EmpCode)
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & i & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtAccountExecutive').value = '" & EmpCode & "';"

                    ElseIf IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        oTS.GetJobComponentInfo(JobNumber, i, , , , , , , , , , , , , , , , , , EmpCode)
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & JobComponentNbr & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtAccountExecutive').value = '" & EmpCode & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '';"
                    End If

                    If _AutoSearch Then

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                    End If

                End If
            ElseIf Request.QueryString("form") = "schedulefilter" Then

                If IsNumeric(JobNumber) = True Then
                    oTS.GetJobInfo(JobNumber, "", Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", "", "", "", Me.ScCode, "", Me.CmpCode, Me.CampaignId)
                    strScript &= "CallingWindowContent.document.getElementById('TxtClientCode').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('TxtDivisionCode').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('TxtProductCode').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('TxtJobNum').value = '" & JobNumber & "';"
                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                    If i > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('TxtJobCompNum').value = '" & i & "';"
                    ElseIf IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr) = True Then
                            strScript &= "CallingWindowContent.document.getElementById('TxtJobCompNum').value') = '" & JobComponentNbr & "';"
                        Else
                            strScript &= "CallingWindowContent.document.getElementById('TxtJobCompNum').value') = '';"
                        End If
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('TxtJobCompNum').value') = '';"
                    End If
                End If
            ElseIf Request.QueryString("form") = "psro" Then 'Project Schedule Report Options page
                If IsNumeric(JobNumber) = True Then
                    oTS.GetJobInfo(JobNumber, "", Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", "", "", "", Me.ScCode, "", Me.CmpCode, Me.CampaignId)
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_ScheduleFilterUC_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_ScheduleFilterUC_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_ScheduleFilterUC_txtProduct').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_ScheduleFilterUC_txtJob').value = '" & JobNumber & "';"

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, False)
                    If i = 1 Then
                        Try
                            If oTS.GetJobComponentInfo(JobNumber, i) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_ScheduleFilterUC_txtComponent').value = '" & i & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_ScheduleFilterUC_txtComponent').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    ElseIf i = -1 And IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        Try
                            If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_ScheduleFilterUC_txtComponent').value = '" & JobComponentNbr & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_ScheduleFilterUC_txtComponent').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If

            ElseIf Request.QueryString("form") = "schedulenew" Then
                If IsNumeric(JobNumber) = True Then
                    Dim JobDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", "", "", "", Me.ScCode, "", Me.CmpCode, Me.CampaignId)
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientCode').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionCode').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductCode').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '" & JobNumber & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '" & JobDesc.Replace("'", "\'") & "';"

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                    Dim compdesc As String = ""
                    If i <> 0 And i <> -1 Then
                        Try
                            If oTS.GetJobComponentInfo(JobNumber, i, JobDesc, compdesc) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & i & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & compdesc.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    ElseIf i = -1 Then
                        Try
                            If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, JobDesc, compdesc) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '" & JobNumber & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & JobComponentNbr & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '" & JobDesc.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & compdesc.Replace("'", "\'") & "';"
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If

            ElseIf Request.QueryString("form") = "schedulecopy" Then

                If IsNumeric(JobNumber) = True Then
                    Dim ClDesc As String = ""
                    Dim DivDesc As String = ""
                    Dim PrdDesc As String = ""
                    Dim JobDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, "", Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientCode').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionCode').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductCode').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '" & JobNumber & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientDescription').value = '" & ClDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionDescription').value = '" & DivDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductDescription').value = '" & PrdDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '" & JobDesc.Replace("'", "\'") & "';"

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, False, Me.CheckboxClosedJobs.Checked)
                    Dim CompDesc As String = ""
                    If i = 1 Then
                        Try
                            If oTS.GetJobComponentInfo(JobNumber, i, JobDesc, CompDesc) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & i & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & CompDesc.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                            End If
                        Catch ex As Exception

                        End Try
                    ElseIf (i = -1 Or i > 1) And IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        Try
                            If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, JobDesc, CompDesc) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & JobComponentNbr & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & CompDesc.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                End If
            ElseIf Request.QueryString("form") = "badtl_client" Then
                Dim ThisCode As String = ""
                Dim ThisDescription As String = ""
                ThisCode = Me.SelectedValue(Me.RadGridLookup)
                ThisDescription = Me.SelectedText(Me.RadGridLookup).Replace("'", "")
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientCode').value = '" & ThisCode & "';"
                Try
                    ThisDescription = ThisDescription.Replace(ThisCode & " - ", "")

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientDescription').value = '" & ThisDescription.Replace("'", "\'") & "';"
                Catch ex As Exception
                End Try
                Try
                    Dim bDesc As Boolean = CType(Request.QueryString("cli_desc"), Boolean)
                    If bDesc = True Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtBA_CL_DESC').value = '" & ThisDescription.Replace("'", "\'") & "';"
                    End If
                Catch ex As Exception 'doesn't work, default to still do it
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtBA_CL_DESC').value = '" & ThisDescription.Replace("'", "\'") & "';"
                End Try
            ElseIf Request.QueryString("form") = "docmgr" Then
                strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("txtOffice", Me.OfficeCode)
                strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("txtClient", Me.ClCode)
                strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("txtDivision", Me.DivCode)
                strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("txtProduct", Me.PrdCode)

                If Me.HiddenFieldLookupType.Value <> "product" And Me.HiddenFieldLookupType.Value <> "campaign" Then
                    strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("txtJob", JobNumber)
                End If

                If Me.HiddenFieldLookupType.Value = "JobComp1" Or Me.HiddenFieldLookupType.Value = "JobComp2" Or Me.HiddenFieldLookupType.Value = "jobcompjj" Or Request.QueryString("IncludeJC") = "true" Then
                    strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("txtComponent", JobComponentNbr)
                End If

                If Me.HiddenFieldLookupType.Value = "campaign" Then
                    strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("txtCampaign", Me.CmpCode)
                    strScript &= AdvantageFramework.Web.Presentation.Controls.SetReturnValueJQuery("hfCampaignID", Me.CampaignId)
                End If

            ElseIf Request.QueryString("form") = "mediafilter" Then
                If Request.QueryString("cp") <> "1" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadPanelbarMediaFilter_i0_i0_txtOffice').value = '" & Me.OfficeCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadPanelbarMediaFilter_i0_i0_txtClient').value = '" & Me.ClCode & "';"
                End If
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadPanelbarMediaFilter_i0_i0_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadPanelbarMediaFilter_i0_i0_txtProduct').value = '" & Me.PrdCode & "';"
                If Me.HiddenFieldLookupType.Value <> "product" And Me.HiddenFieldLookupType.Value <> "campaign" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadPanelbarMediaFilter_i0_i0_txtJob').value ='" & JobNumber & "';"
                End If
                If Me.HiddenFieldLookupType.Value = "JobComp1" Or Me.HiddenFieldLookupType.Value = "JobComp2" Or Me.HiddenFieldLookupType.Value = "jobcompjj" Or Request.QueryString("IncludeJC") = "true" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadPanelbarMediaFilter_i0_i0_txtComponent').value = '" & JobComponentNbr & "';"
                End If
                If Me.HiddenFieldLookupType.Value = "campaign" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadPanelbarMediaFilter_i0_i0_txtCampaign').value = '" & Me.CmpCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadPanelbarMediaFilter_i0_i0_hfCampaignID').value = '" & Me.CampaignId & "';"

                End If
            ElseIf Request.QueryString("form") = "trafficedit" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Trafficeditpanel_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Trafficeditpanel_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Trafficeditpanel_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Trafficeditpanel_txtJob').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_Trafficeditpanel_txtJobComp').value = '" & JobComponentNbr & "';"
            ElseIf Request.QueryString("form") = "schedulefilter" Then
                strScript &= "CallingWindowContent.document.getElementById('TxtClientCode').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('TxtDivisionCode').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('TxtProductCode').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('TxtJobNum').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('TxtJobCompNum').value = '" & JobComponentNbr & "';"
            ElseIf Request.QueryString("form") = "traffictimeline" And (Me.HiddenFieldLookupType.Value = "Job1" Or Me.HiddenFieldLookupType.Value = "Job2") Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJobComp').value = '" & JobComponentNbr & "';"
            ElseIf Request.QueryString("form") = "jobnew" And (Me.HiddenFieldLookupType.Value = "product") Then
                Try
                    If Request.QueryString("offvis") = "1" Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtOffice').value = '" & Me.OfficeCode & "';"
                    End If
                Catch ex As Exception

                End Try
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                If ae <> "" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtAE').value = '" & ae & "';"
                End If
            ElseIf Request.QueryString("form") = "jobrequest" And (Me.HiddenFieldLookupType.Value = "product") Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
            ElseIf Request.QueryString("form") = "jobrequestsearch" And (Me.HiddenFieldLookupType.Value = "product") Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Client').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Division').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Product').value = '" & Me.PrdCode & "';"

                If _AutoSearch Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                End If

            ElseIf Request.QueryString("form") = "qvafilter" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_txtProduct').value = '" & Me.PrdCode & "';"
                If JobNumber <> 0 Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_txtJob').value ='" & JobNumber & "';"
                End If
                If JobComponentNbr <> 0 Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_txtJobComp').value = '" & JobComponentNbr & "';"
                End If
            ElseIf Request.QueryString("form") = "tscv" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxClientCode').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxDivisionCode').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxProductCode').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxJobNumber').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxJobComponentNbr').value = '" & JobComponentNbr & "';"
                If IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                    If CType(JobNumber, Integer) > 0 And CType(JobComponentNbr, Integer) > 0 Then
                        Dim JobDesc As String = ""
                        Dim JobCompDesc As String = ""
                        oTS.GetJobComponentInfo(CType(JobNumber, Integer), CType(JobComponentNbr, Integer), JobDesc, JobCompDesc)

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxJobDescription').value ='" & MiscFN.JavascriptSafe(JobDesc) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxJobComponentDescription').value = '" & MiscFN.JavascriptSafe(JobCompDesc) & "';"


                    End If
                End If
            ElseIf Request.QueryString("form") = "approval_detail_fn" Then
                If CodeCtrlName <> "" And DescriptCtrlName <> "" Then
                    Dim descript As String = ""
                    Dim ar() As String
                    Try
                        ar = Me.SelectedText(Me.RadGridLookup).Split("-")
                        If ar.Length > 1 Then
                            descript = ar(1).ToString().Trim()
                        End If
                    Catch ex As Exception
                    End Try
                    strScript &= "CallingWindowContent.document.getElementById('" & CodeCtrlName & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                    strScript &= "CallingWindowContent.document.getElementById('" & DescriptCtrlName & "').value = '" & descript.Replace("'", "\'") & "';"
                End If
            ElseIf Request.QueryString("form") = "approval_detail_taxc" Then

                If CodeCtrlName <> "" Then

                    Dim taxcode As String = ""
                    taxcode = Me.SelectedValue(Me.RadGridLookup)
                    If taxcode Is Nothing Then
                        taxcode = ""
                    End If


                    strScript &= "CallingWindowContent.document.getElementById('" & CodeCtrlName & "').value = '" & taxcode & "';"

                    If Me.SelectedValue(Me.RadGridLookup) <> "" Then

                        Dim taxstate As Decimal = 0.0
                        Dim taxcity As Decimal = 0.0
                        Dim taxcounty As Decimal = 0.0
                        Dim taxresale As Decimal = 0.0
                        Dim est As New cEstimating(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                        dtInfo = est.GetAddNewTaxData(Me.SelectedValue(Me.RadGridLookup))

                        If dtInfo.Rows.Count > 0 Then

                            taxstate = dtInfo.Rows(0)("TAX_STATE_PERCENT")
                            taxcounty = dtInfo.Rows(0)("TAX_COUNTY_PERCENT")
                            taxcity = dtInfo.Rows(0)("TAX_CITY_PERCENT")
                            taxresale = dtInfo.Rows(0)("TAX_RESALE")

                            strScript &= String.Format("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridComponentList_ctl00_ctl05_HfAPPR_TAX_STATE_PCT').value = '{0}';", taxstate)
                            strScript &= String.Format("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridComponentList_ctl00_ctl05_HfAPPR_TAX_COUNTY_PCT').value = '{0}';", taxcounty)
                            strScript &= String.Format("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridComponentList_ctl00_ctl05_HfAPPR_TAX_CITY_PCT').value = '{0}';", taxcity)
                            strScript &= String.Format("CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridComponentList_ctl00_ctl05_HfAPPR_RESALE_TAX').value = '{0}';", taxresale)

                        End If

                    End If

                End If

            ElseIf Request.QueryString("form") = "purchaseorder_dtl" Then
                Dim oJob As Job = New Job(CStr(Session("ConnString")))
                If IsNumeric(JobNumber) = True Then
                    Dim ClDesc As String = ""
                    Dim DivDesc As String = ""
                    Dim PrdDesc As String = ""
                    Dim JobDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, "", Me.CmpCode, Me.CampaignId)
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value = '" & JobNumber & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lblClientDescription').value = '" & ClDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lblDivDescription').value = '" & DivDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lblProdDescription').value = '" & PrdDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lblJobDescription').value = '" & JobDesc.Replace("'", "\'") & "';"
                    Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                    If PODtl.GetPOGLAccountSelection(Request.QueryString("empcode")) = 1 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txt_glaccount_code').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txt_glaccount_descrip').value = '';"
                    End If

                End If
                Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                Dim compdesc As String = ""
                If i <> 0 And i <> -1 Then
                    Try
                        If oTS.GetJobComponentInfo(JobNumber, i, , compdesc) = True Then
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJobComp').value = '" & i & "';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lbl_comp_desc').value = '" & compdesc.Replace("'", "\'") & "';"
                            oJob.GetJob(JobNumber, i)
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lbl_jobtype').value = '" & oJob.JobComponent.JobTypeDesc.Replace("'", "\'") & "';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txt_markup_perc').value = '" & oJob.JobComponent.JOB_MARKUP_PCT & "';"
                        Else
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJobComp').value = '';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lbl_comp_desc').value = '';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lbl_jobtype').value = '';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txt_markup_perc').value ='';"
                        End If
                    Catch ex As Exception

                    End Try
                ElseIf i = -1 And IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                    Try
                        If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, , compdesc) = True Then
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJobComp').value = '" & JobComponentNbr & "';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lbl_comp_desc').value = '" & compdesc.Replace("'", "\'") & "';"
                            oJob.GetJob(JobNumber, JobComponentNbr)
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lbl_jobtype').value = '" & oJob.JobComponent.JobTypeDesc.Replace("'", "\'") & "';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txt_markup_perc').value = '" & oJob.JobComponent.JOB_MARKUP_PCT & "';"
                        Else
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJobComp').value = '';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lbl_comp_desc').value = '';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_lbl_jobtype').value = '';"
                            strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txt_markup_perc').value ='';"
                        End If
                    Catch ex As Exception

                    End Try
                End If
            ElseIf Request.QueryString("form") = "vendordetail" Then
                Try
                    Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
                    Dim js As New Job_Specs(Session("ConnString"))
                    Dim i As Integer
                    Dim vendor As String = Request.QueryString("vendor")
                    dtInfo = oTasks.GetMediaSpecsByAdSize(vendor, js.GetMediaType(vendor), Me.SelectedValue(Me.RadGridLookup))
                    strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                    If dtInfo.Rows.Count <> 0 Then
                        For i = 0 To dtInfo.Rows.Count - 1
                            If dtInfo.Rows(i)("LABEL_DESC").ToString.Trim = "Bleed Size" Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtBleedSize').value = '" & dtInfo.Rows(i)("DATA").ToString() & "';"
                            End If
                            If dtInfo.Rows(i)("LABEL_DESC").ToString.Trim = "Trim Size" Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtTrimSize').value = '" & dtInfo.Rows(i)("DATA").ToString() & "';"
                            End If
                            If dtInfo.Rows(i)("LABEL_DESC").ToString.Trim = "Live Area" Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtLiveArea').value = '" & dtInfo.Rows(i)("DATA").ToString() & "';"
                            End If
                            If dtInfo.Rows(i)("LABEL_DESC").ToString.Trim = "Screen" Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtScreen').value = '" & dtInfo.Rows(i)("DATA").ToString() & "';"
                            End If
                            If dtInfo.Rows(i)("LABEL_DESC").ToString.Trim = "Color" Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtColor').value = '" & dtInfo.Rows(i)("DATA").ToString() & "';"
                            End If
                            If dtInfo.Rows(i)("LABEL_DESC").ToString.Trim = "Density" Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDensity').value = '" & dtInfo.Rows(i)("DATA").ToString() & "';"
                            End If
                            If dtInfo.Rows(i)("LABEL_DESC").ToString.Trim = "Film" Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtFilm').value = '" & dtInfo.Rows(i)("DATA").ToString() & "';"
                            End If
                            If dtInfo.Rows(i)("LABEL_DESC").ToString.Trim = "Location of Sign" Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtLocationSign').value = '" & dtInfo.Rows(i)("DATA").ToString() & "';"
                            End If
                            If dtInfo.Rows(i)("LABEL_DESC").ToString.Trim = "Overall Size" Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOverallSize').value = '" & dtInfo.Rows(i)("DATA").ToString() & "';"
                            End If
                            If dtInfo.Rows(i)("LABEL_DESC").ToString.Trim = "Copy Area" Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtCopyArea').value = '" & dtInfo.Rows(i)("DATA").ToString() & "';"
                            End If
                        Next
                    End If
                Catch ex As Exception
                End Try

            ElseIf Request.QueryString("form") = "jt" Then
                Dim jt As New Job_Template(Session("ConnString"))
                Dim dr As SqlClient.SqlDataReader
                dr = jt.GetAdNumBlackPlt(Me.SelectedValue(Me.RadGridLookup))
                Try
                    Do While dr.Read
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                        If Session("JobTemplateHasBlackplate1") = "True" Then
                            If dr.GetString(2) <> "" Then
                                strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("bp1") & "').value = '" & dr.GetString(2) & "';"
                            End If
                        End If
                        If Session("JobTemplateHasBlackplate2") = "True" Then
                            If dr.GetString(4) <> "" Then
                                strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("bp2") & "').value = '" & dr.GetString(4) & "';"
                            End If
                        End If
                    Loop

                Catch ex As Exception
                    'Me.ShowMessage("Error!<BR />" & ex.Message.ToString())
                Finally

                End Try
            ElseIf Request.QueryString("form") = "poApproval" Then
                Dim strtest As String = Me.SelectedText(Me.RadGridLookup)
                Dim strtest2 As String = Me.SelectedValue(Me.RadGridLookup)
                If Me.SelectedText(Me.RadGridLookup).Contains("(Pending)") = True Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_txtPONumber').value = '(Pending)';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_hfPONumber').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                ElseIf Me.SelectedText(Me.RadGridLookup).Contains("Denied)") = True Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_txtPONumber').value = '(Denied)';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_hfPONumber').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                ElseIf Me.SelectedText(Me.RadGridLookup).Contains("(Incomplete)") = True Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_txtPONumber').value = '(Incomplete)';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_hfPONumber').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                Else
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_POpanel1_txtPONumber').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                End If

                If _AutoSearch Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                End If

            ElseIf Request.QueryString("form") = "estimatejob" Then
                If IsNumeric(Me.EstimateNumber) = True Then

                    dtEst = oEstimating.GetInfoForEstimate(Me.EstimateNumber)
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientCode').value = '" & dtEst.Rows(0)("CL_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionCode').value = '" & dtEst.Rows(0)("DIV_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductCode').value = '" & dtEst.Rows(0)("PRD_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimate').value = '" & dtEst.Rows(0)("ESTIMATE_NUMBER") & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientDescription').value = '" & dtEst.Rows(0)("CL_NAME") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionDescription').value = '" & dtEst.Rows(0)("DIV_NAME") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductDescription').value = '" & dtEst.Rows(0)("PRD_DESCRIPTION").ToString().Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateDescription').value = '" & dtEst.Rows(0)("EST_LOG_DESC").ToString.Replace("'", "\'") & "';"

                    Dim s As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(Me.EstimateNumber)
                    If i <> 0 And i <> -1 Then
                        Try
                            dtEstComp = oEstimating.GetInfoForEstimateComp(Me.EstimateNumber, i)
                            If dtEstComp.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '" & dtEstComp.Rows(0)("EST_COMPONENT_NBR") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '" & dtEstComp.Rows(0)("EST_COMP_DESC").ToString.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '" & dtEstComp.Rows(0)("JOB_NUMBER") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & dtEstComp.Rows(0)("JOB_COMPONENT_NBR") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '" & dtEstComp.Rows(0)("JOB_DESC").ToString.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & dtEstComp.Rows(0)("JOB_COMP_DESC").Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    ElseIf i = -1 And IsNumeric(Me.EstimateNumber) = True And IsNumeric(Me.EstComponentNbr) = True Then
                        Try
                            dtEstComp = oEstimating.GetInfoForEstimateComp(Me.EstimateNumber, Me.EstComponentNbr)
                            If dtEstComp.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '" & dtEstComp.Rows(0)("EST_COMPONENT_NBR") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '" & dtEstComp.Rows(0)("EST_COMP_DESC").ToString.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '" & dtEstComp.Rows(0)("JOB_NUMBER") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & dtEstComp.Rows(0)("JOB_COMPONENT_NBR") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '" & dtEstComp.Rows(0)("JOB_DESC").ToString.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & dtEstComp.Rows(0)("JOB_COMP_DESC").ToString.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
            ElseIf Request.QueryString("form") = "estimatejc" Then
                If IsNumeric(JobNumber) = True Then
                    Dim ClDesc As String = ""
                    Dim DivDesc As String = ""
                    Dim PrdDesc As String = ""
                    Dim JobDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, "", Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientCode').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionCode').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductCode').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '" & JobNumber & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientDescription').value = '" & ClDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionDescription').value = '" & DivDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductDescription').value = '" & PrdDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '" & JobDesc.ToString.Replace("'", "\'") & "';"

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                    If i <> 0 And i >= 1 Then
                        Try
                            Dim ojob As New JOB_COMPONENT(Session("ConnString"))
                            ojob.LoadByPrimaryKey(i, JobNumber)
                            If ojob.s_ESTIMATE_NUMBER <> "" Then
                                If ojob.ESTIMATE_NUMBER <> 0 Then
                                    dtEst = oEstimating.GetInfoForEstimateComp(ojob.ESTIMATE_NUMBER, ojob.EST_COMPONENT_NBR)
                                End If
                            End If
                            Dim compdesc As String = ""
                            If oTS.GetJobComponentInfo(JobNumber, i, , compdesc) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & i & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & compdesc.ToString.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimate').value = '" & ojob.ESTIMATE_NUMBER & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '" & ojob.EST_COMPONENT_NBR & "';"

                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimate').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '';"
                            End If
                            If dtEst.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateDescription').value = '" & dtEst.Rows(0)("EST_LOG_DESC").ToString.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '" & dtEst.Rows(0)("EST_COMP_DESC").ToString.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateDescription').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    ElseIf IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        Try
                            Dim ojob As New JOB_COMPONENT(Session("ConnString"))
                            ojob.LoadByPrimaryKey(JobComponentNbr, JobNumber)

                            If ojob.s_ESTIMATE_NUMBER <> "" Then
                                dtEst = oEstimating.GetInfoForEstimateComp(ojob.ESTIMATE_NUMBER, ojob.EST_COMPONENT_NBR)
                            End If
                            Dim compdesc As String = ""
                            If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, , compdesc) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & JobComponentNbr & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & compdesc.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                            End If
                            If dtEst.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimate').value = '" & ojob.ESTIMATE_NUMBER & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '" & ojob.EST_COMPONENT_NBR & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateDescription').value = '" & dtEst.Rows(0)("EST_LOG_DESC").ToString.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '" & dtEst.Rows(0)("EST_COMP_DESC").ToString.Replace("'", "\'") & "';"
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
            ElseIf Request.QueryString("form") = "estimatejcsave" Then
                If IsNumeric(JobNumber) = True Then
                    Dim JobDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", "", "", "", Me.ScCode, "", Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '" & JobNumber & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '" & JobDesc.ToString.Replace("'", "\'") & "';"

                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                    If i <> 0 And i >= 1 Then
                        Dim compdesc As String = ""
                        Dim contcode As String = ""
                        Dim contfml As String = ""
                        Try
                            Dim drComp As SqlClient.SqlDataReader
                            If oTS.GetJobComponentInfo(JobNumber, i, , compdesc, , , , , , , , , , , , , contcode, contfml) = True Then
                                drComp = est.GetEstJob(JobNumber, i)
                                drComp.Read()
                                If drComp("ESTIMATE_NUMBER") > 0 And drComp("EST_COMPONENT_NBR") > 0 Then
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                                    If Request.QueryString("fromest") = "jc" Then
                                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateCompDescription').value = '';"
                                    End If
                                Else
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & i & "';"
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & compdesc.ToString.Replace("'", "\'") & "';"
                                    If Request.QueryString("fromest") = "jc" Then
                                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateCompDescription').value = '" & compdesc.ToString.Replace("'", "\'") & "';"
                                    End If
                                End If
                                drComp.Close()
                                If Request.QueryString("fromest") <> "jc" Then
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtContactCode').value = '" & contcode.ToString.Replace("'", "\'") & "';"
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtContactDescription').value = '" & contfml.ToString.Replace("'", "\'") & "';"
                                End If
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                                If Request.QueryString("fromest") = "jc" Then
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateCompDescription').value = '';"
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                    ElseIf IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        Try
                            Dim compdesc As String = ""
                            Dim contcode As String = ""
                            Dim contfml As String = ""
                            If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, , compdesc, , , , , , , , , , , , , contcode, contfml) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & JobComponentNbr & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & compdesc.ToString.Replace("'", "\'") & "';"
                                If Request.QueryString("fromest") <> "jc" Then
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtContactCode').value = '" & contcode.ToString.Replace("'", "\'") & "';"
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtContactDescription').value = '" & contfml.ToString.Replace("'", "\'") & "';"
                                End If
                                If Request.QueryString("fromest") = "jc" Then
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateCompDescription').value = '" & compdesc.ToString.Replace("'", "\'") & "';"
                                End If
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                                If Request.QueryString("fromest") = "jc" Then
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateCompDescription').value = '';"
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
            ElseIf Request.QueryString("form") = "estimatejcnew" Then
                If IsNumeric(JobNumber) = True Then
                    Dim ClDesc As String = ""
                    Dim DivDesc As String = ""
                    Dim PrdDesc As String = ""
                    Dim JobDesc As String = ""
                    Dim ScDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, ScDesc, Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientCode').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionCode').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductCode').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '" & JobNumber & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtSalesClass').value = '" & Me.ScCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtSalesClass').disabled = true;"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_HlSalesClass').disabled = true;"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientDescription').value = '" & ClDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionDescription').value = '" & DivDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductDescription').value = '" & PrdDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '" & JobDesc.ToString.Replace("'", "") & "\'';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtSalesClassDescription').value = '" & ScDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateDescription').value = '" & JobDesc.ToString.Replace("'", "\'") & "';"

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                    If i <> 0 And i >= 1 Then
                        Try
                            Dim compdesc As String = ""
                            Dim cdpcontactid As String = ""
                            If oTS.GetJobComponentInfo(JobNumber, i, , compdesc, , , , , , , , , , , , cdpcontactid) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & i & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & compdesc.ToString.Replace("'", "\'") & "';"

                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateCompDescription').value = '" & compdesc.ToString.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_hfContactCodeID').value = '" & cdpcontactid.ToString.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateCompDescription').style.visibility = hidden;"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateCompDescription').value = '" & JobDesc.ToString.Replace("'", "") & "';"
                            End If
                        Catch ex As Exception
                        End Try
                    ElseIf IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        Try
                            Dim compdesc As String = ""
                            Dim cdpcontactid As String = ""
                            If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, , compdesc, , , , , , , , , , , , cdpcontactid) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & JobComponentNbr & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & compdesc.ToString.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateCompDescription').value = '" & compdesc.ToString.Replace("'", "\'") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_hfContactCodeID').value = '" & cdpcontactid.ToString.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateCompDescription').style.visibility = hidden;"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateCompDescription').value = '" & JobDesc.ToString.Replace("'", "\'") & "';"
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                End If
            ElseIf Request.QueryString("form") = "glaccount" Then
                Dim glstr() As String = Me.SelectedText(Me.RadGridLookup).Split("-")
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txt_glaccount_code').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txt_glaccount_descrip').value = '" & glstr(1).ToString().Replace("'", "\'") & "';"
            ElseIf Request.QueryString("form") = "taxcodes" Then
                Dim taxstr() As String
                If Me.SelectedValue(Me.RadGridLookup) <> "" Then
                    taxstr = Me.SelectedText(Me.RadGridLookup).Split("-")
                End If
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                Dim extamt As Decimal = 0.0
                Dim contamt As Decimal = 0.0
                Dim contpct As Decimal = 0.0
                Dim markupamt As Decimal = 0.0
                Dim markuppct As Decimal = 0.0
                Dim linetotal As Decimal = 0.0
                Dim mucontamt As Decimal = 0.0
                Dim extnonresaletax As Decimal = 0.0
                Dim extstateresale As Decimal = 0.0
                Dim extcountyresale As Decimal = 0.0
                Dim extcityresale As Decimal = 0.0
                Dim extstatenonresale As Decimal = 0.0
                Dim extcountynonresale As Decimal = 0.0
                Dim extcitynonresale As Decimal = 0.0
                Dim extstatemarkup As Decimal = 0.0
                Dim extcountymarkup As Decimal = 0.0
                Dim extcitymarkup As Decimal = 0.0
                Dim extmucont As Decimal = 0.0
                Dim extstatecont As Decimal = 0.0
                Dim extcountycont As Decimal = 0.0
                Dim extcitycont As Decimal = 0.0
                Dim extnrcont As Decimal = 0.0
                Dim linetotalcont As Decimal = 0.0

                Dim functionTaxComm As Integer = 0
                Dim functionTaxCommOnly As Integer = 0
                Dim functionType As String = ""

                dtInfo = est.GetDefaultFunctionData(Me.SelectedValue(Me.RadGridLookup), Me.JobNumber, Me.JobComponentNbr, Me.ClCode, Me.DivCode, Me.PrdCode, Me.ScCode, Me.EmpCode)

                If Request.QueryString("taxc") <> "" Then
                    functionTaxComm = Request.QueryString("taxc")
                End If
                If Request.QueryString("taxco") <> "" Then
                    functionTaxCommOnly = Request.QueryString("taxco")
                End If
                If Request.QueryString("functype") <> "" Then
                    functionType = Request.QueryString("functype")
                End If

                If dtInfo.Rows.Count > 0 Then
                    If IsDBNull(dtInfo.Rows(0)("FNC_TYPE")) = False And functionType = "" Then
                        functionType = dtInfo.Rows(0)("FNC_TYPE")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("TAX_COMM")) = False And functionTaxComm = 0 Then
                        functionTaxComm = dtInfo.Rows(0)("TAX_COMM")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("TAX_COMM_ONLY")) = False And functionTaxCommOnly = 0 Then
                        functionTaxCommOnly = dtInfo.Rows(0)("TAX_COMM_ONLY")
                    End If
                End If

                If Request.QueryString("extamt") <> "" Then
                    extamt = CDec(Request.QueryString("extamt"))
                End If
                If Request.QueryString("contamt") <> "" Then
                    contpct = CDec(Request.QueryString("contamt"))
                End If
                If Request.QueryString("line") <> "" Then
                    linetotal = CDec(Request.QueryString("line"))
                End If
                If Request.QueryString("muamt") <> "" Then
                    markuppct = CDec(Request.QueryString("muamt"))
                End If
                Dim taxstate As Decimal = 0.0
                Dim taxcity As Decimal = 0.0
                Dim taxcounty As Decimal = 0.0
                Dim taxresale As Decimal = 0.0
                Dim taxcode As String = ""
                taxcode = Me.SelectedValue(Me.RadGridLookup)
                If taxcode Is Nothing Then
                    taxcode = ""
                End If
                If Me.SelectedValue(Me.RadGridLookup) <> "" Then
                    dtInfo = est.GetAddNewTaxData(Me.SelectedValue(Me.RadGridLookup))
                    If dtInfo.Rows.Count > 0 Then
                        taxstate = dtInfo.Rows(0)("TAX_STATE_PERCENT")
                        taxcounty = dtInfo.Rows(0)("TAX_COUNTY_PERCENT")
                        taxcity = dtInfo.Rows(0)("TAX_CITY_PERCENT")
                        taxresale = dtInfo.Rows(0)("TAX_RESALE")
                    End If
                End If
                If extamt > 0 Then
                    If markuppct > 0 Then
                        markupamt = Math.Round((extamt * (markuppct / 100)), 2, MidpointRounding.AwayFromZero)
                    End If
                    If contpct > 0 Then
                        contamt = Math.Round((extamt * (contpct / 100)), 2, MidpointRounding.AwayFromZero)
                        mucontamt = Math.Round((markupamt * (contpct / 100)), 2, MidpointRounding.AwayFromZero)
                    End If
                End If
                Dim taxamount As Decimal = 0.0
                Dim taxmuamount As Decimal = 0.0
                Dim taxcontamt As Decimal = 0.0
                'If taxresale = 1 Then
                If Request.QueryString("taxco") <> "1" Then
                    taxamount = Math.Round((extamt * (taxstate / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((extamt * (taxcounty / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((extamt * (taxcity / 100)), 2, MidpointRounding.AwayFromZero)
                End If
                If Request.QueryString("taxc") = "1" Then
                    taxmuamount = Math.Round((markupamt * (taxstate / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((markupamt * (taxcounty / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((markupamt * (taxcity / 100)), 2, MidpointRounding.AwayFromZero)
                End If
                If contamt > 0 Then
                    If Request.QueryString("taxc") = "1" And Request.QueryString("taxco") = "1" Then
                        taxcontamt = Math.Round((mucontamt * (taxstate / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((mucontamt * (taxcounty / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((mucontamt * (taxcity / 100)), 2, MidpointRounding.AwayFromZero)
                    ElseIf Request.QueryString("taxc") = "1" Then
                        taxcontamt = Math.Round(((contamt + mucontamt) * (taxstate / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round(((contamt + mucontamt) * (taxcounty / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round(((contamt + mucontamt) * (taxcity / 100)), 2, MidpointRounding.AwayFromZero)
                    Else
                        taxcontamt = Math.Round((contamt * (taxstate / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((contamt * (taxcounty / 100)), 2, MidpointRounding.AwayFromZero) + Math.Round((contamt * (taxcity / 100)), 2, MidpointRounding.AwayFromZero)
                    End If
                End If
                Dim EstNumber As Integer = 0
                Dim EstComponentNbr As Integer = 0
                Dim EstQuoteNbr As Integer = 0
                Dim EstRevNbr As Integer = 0
                Dim SeqNbr As Integer = -1
                Dim ReturnMessage As String = ""
                Dim SQL As New System.Text.StringBuilder

                Dim ar() As String
                ar = Request.QueryString("dk").ToString.Replace("'", "").Split("|")
                Try
                    EstNumber = ar(0)
                Catch ex As Exception
                    EstNumber = 0
                End Try
                Try
                    EstComponentNbr = ar(1)
                Catch ex As Exception
                    EstComponentNbr = 0
                End Try
                Try
                    EstQuoteNbr = ar(2)
                Catch ex As Exception
                    EstQuoteNbr = 0
                End Try
                Try
                    EstRevNbr = ar(3)
                Catch ex As Exception
                    EstRevNbr = 0
                End Try
                Try
                    SeqNbr = ar(4)
                Catch ex As Exception
                    SeqNbr = -1
                End Try

                Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
                Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
                Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
                Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
                Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)
                Dim parameterTAX_STATE_PCT As New SqlParameter("@TAX_STATE_PCT", SqlDbType.Decimal)
                Dim parameterTAX_COUNTY_PCT As New SqlParameter("@TAX_COUNTY_PCT", SqlDbType.Decimal)
                Dim parameterTAX_CITY_PCT As New SqlParameter("@TAX_CITY_PCT", SqlDbType.Decimal)
                Dim parameterTAX_RESALE As New SqlParameter("@TAX_RESALE", SqlDbType.SmallInt)

                parameterEXT_CONTINGENCY.Value = 0
                parameterEXT_MU_CONT.Value = 0
                parameterLINE_TOTAL.Value = 0
                parameterLINE_TOTAL_CONT.Value = 0
                parameterEXT_STATE_RESALE.Value = 0
                parameterEXT_COUNTY_RESALE.Value = 0
                parameterEXT_CITY_RESALE.Value = 0
                parameterEXT_STATE_CONT.Value = 0
                parameterEXT_COUNTY_CONT.Value = 0
                parameterEXT_CITY_CONT.Value = 0
                parameterEXT_NONRESALE_TAX.Value = 0
                parameterEXT_NR_CONT.Value = 0

                SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                SQL.Append(" TAX_CODE = @TAX_CODE")
                SQL.Append(", TAX_STATE_PCT = @TAX_STATE_PCT, TAX_COUNTY_PCT = @TAX_COUNTY_PCT, TAX_CITY_PCT = @TAX_CITY_PCT, TAX_RESALE = @TAX_RESALE")
                parameterTAX_STATE_PCT.Value = taxstate
                parameterTAX_COUNTY_PCT.Value = taxcounty
                parameterTAX_CITY_PCT.Value = taxcity
                parameterTAX_RESALE.Value = taxresale
                parameterEXT_CONTINGENCY.Value = contamt
                parameterEXT_MU_CONT.Value = mucontamt
                parameterTAX_CODE.Value = taxcode

                If taxcode <> "" Then
                    If taxresale = 1 Then
                        If functionTaxCommOnly <> 1 Then
                            extstateresale = extamt * (taxstate / 100)
                            extcountyresale = extamt * (taxcounty / 100)
                            extcityresale = extamt * (taxcity / 100)
                        End If
                        If functionTaxComm = 1 Then
                            If markupamt > 0 Then
                                extstatemarkup = markupamt * (taxstate / 100)
                                extcountymarkup = markupamt * (taxcounty / 100)
                                extcitymarkup = markupamt * (taxcity / 100)
                            End If
                        End If
                        extstateresale += extstatemarkup
                        extcountyresale += extcountymarkup
                        extcityresale += extcitymarkup
                        parameterEXT_STATE_RESALE.Value = extstateresale + extstatemarkup
                        parameterEXT_COUNTY_RESALE.Value = extcountyresale + extcountymarkup
                        parameterEXT_CITY_RESALE.Value = extcityresale + extcitymarkup
                        If contamt > 0 Then
                            If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                extstatecont = extmucont * (taxstate / 100)
                                extcountycont = extmucont * (taxcounty / 100)
                                extcitycont = extmucont * (taxcity / 100)
                            ElseIf functionTaxComm = 1 Then
                                extstatecont = (contamt + extmucont) * (taxstate / 100)
                                extcountycont = (contamt + extmucont) * (taxcounty / 100)
                                extcitycont = (contamt + extmucont) * (taxcity / 100)
                            Else
                                extstatecont = contamt * (taxstate / 100)
                                extcountycont = contamt * (taxcounty / 100)
                                extcitycont = contamt * (taxcity / 100)
                            End If
                            parameterEXT_STATE_CONT.Value = extstatecont
                            parameterEXT_COUNTY_CONT.Value = extcountycont
                            parameterEXT_CITY_CONT.Value = extcitycont
                            'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                        End If
                        SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                        SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                    End If
                    If taxresale <> 1 Then
                        If functionType = "V" Then
                            If functionTaxCommOnly <> 1 Then
                                extstatenonresale = extamt * (taxstate / 100)
                                extcountynonresale = extamt * (taxcounty / 100)
                                extcitynonresale = extamt * (taxcity / 100)
                                extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                Dim trstate As Decimal = extamt * (taxstate / 100)
                                Dim trcounty As Decimal = extamt * (taxcounty / 100)
                                Dim trcity As Decimal = extamt * (taxcity / 100)
                                linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                            End If
                            If contamt > 0 Then
                                If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                    extnrcont = extmucont * (taxstate / 100) + extmucont * (taxcounty / 100) + extmucont * (taxcity / 100)
                                ElseIf functionTaxComm = 1 Then
                                    extnrcont = (contamt + extmucont) * (taxstate / 100) + contamt * (taxcounty / 100) + contamt * (taxcity / 100)
                                End If
                                parameterEXT_NR_CONT.Value = extnrcont
                                SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                            End If
                        ElseIf functionType = "E" Or functionType = "I" Then
                            If functionTaxCommOnly <> 1 Then
                                extstateresale = extamt * (taxstate / 100)
                                extcountyresale = extamt * (taxcounty / 100)
                                extcityresale = extamt * (taxcity / 100)
                            End If
                            If contamt > 0 Then
                                If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                    extstatecont = extmucont * (taxstate / 100)
                                    extcountycont = extmucont * (taxcounty / 100)
                                    extcitycont = extmucont * (taxcity / 100)
                                ElseIf functionTaxComm = "1" Then
                                    extstatecont = (contamt + extmucont) * (taxstate / 100)
                                    extcountycont = (contamt + extmucont) * (taxcounty / 100)
                                    extcitycont = (contamt + extmucont) * (taxcity / 100)
                                End If
                                parameterEXT_STATE_CONT.Value = extstatecont
                                parameterEXT_COUNTY_CONT.Value = extcountycont
                                parameterEXT_CITY_CONT.Value = extcitycont
                                SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                            End If
                        End If
                        If functionTaxComm = 1 Then
                            If markupamt > 0 Then
                                extstatemarkup = markupamt * (taxstate / 100)
                                extcountymarkup = markupamt * (taxcounty / 100)
                                extcitymarkup = markupamt * (taxcity / 100)
                            End If
                        End If
                        extstateresale += extstatemarkup
                        extcountyresale += extcountymarkup
                        extcityresale += extcitymarkup
                        parameterEXT_STATE_RESALE.Value = extstateresale + extstatemarkup
                        parameterEXT_COUNTY_RESALE.Value = extcountyresale + extcountymarkup
                        parameterEXT_CITY_RESALE.Value = extcityresale + extcitymarkup
                        SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                    End If
                Else
                    SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                    SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                    SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                End If
                linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero) + Math.Round(mucontamt, 2, MidpointRounding.AwayFromZero)

                SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                parameterLINE_TOTAL.Value = linetotal
                SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                parameterLINE_TOTAL_CONT.Value = linetotalcont
                With SQL
                    .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                End With

                Dim MyCmd As New SqlCommand()
                MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                MyCmd.Parameters.Add(parameterLINE_TOTAL)
                MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                MyCmd.Parameters.Add(parameterTAX_CODE)
                'If TaxCode <> "" Then
                MyCmd.Parameters.Add(parameterTAX_STATE_PCT)
                MyCmd.Parameters.Add(parameterTAX_COUNTY_PCT)
                MyCmd.Parameters.Add(parameterTAX_CITY_PCT)
                MyCmd.Parameters.Add(parameterTAX_RESALE)
                MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                'End If

                Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                pESTIMATE_NUMBER.Value = EstNumber
                MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                pEST_COMPONENT_NBR.Value = EstComponentNbr
                MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                pEST_QUOTE_NBR.Value = EstQuoteNbr
                MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                pEST_REV_NBR.Value = EstRevNbr
                MyCmd.Parameters.Add(pEST_REV_NBR)

                Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                pSEQ_NBR.Value = SeqNbr
                MyCmd.Parameters.Add(pSEQ_NBR)

                If Request.QueryString("new") <> "1" Then
                    Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                        Dim MyTrans As SqlTransaction
                        MyConn.Open()
                        MyTrans = MyConn.BeginTransaction
                        Try
                            With MyCmd
                                .CommandText = SQL.ToString()
                                .CommandType = CommandType.Text
                                .Connection = MyConn
                                .Transaction = MyTrans
                                .ExecuteNonQuery()
                                ReturnMessage = "OK|" & functionType
                            End With
                            MyTrans.Commit()
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                End If

                Dim strcontrol As String = Request.QueryString("control")
                Dim str() As String = strcontrol.Split("_")
                Dim num As String = str(4).Substring(3)
                If Request.QueryString("new") <> "1" Then
                    If Me.SelectedValue(Me.RadGridLookup) = "" Then
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control2") & "').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCode').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtLINE_TOTAL').value = '" & extamt + taxmuamount + taxamount + markupamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtEXT_CONTINGENCY').value = '" & contamt + taxcontamt + mucontamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxStatePct').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCountyPct').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCityPct').value = '';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control2") & "').value = '" & taxamount + taxmuamount & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCode').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtLINE_TOTAL').value = '" & extamt + taxmuamount + taxamount + markupamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtEXT_CONTINGENCY').value = '" & contamt + taxcontamt + mucontamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxStatePct').value = '" & taxstate & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCountyPct').value = '" & taxcounty & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCityPct').value = '" & taxcity & "';"
                    End If
                Else
                    If Me.SelectedValue(Me.RadGridLookup) = "" Then
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control2") & "').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCode').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtLINE_TOTAL').value = '" & extamt + taxmuamount + taxamount + markupamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtEXT_CONTINGENCY').value = '" & contamt + taxcontamt + mucontamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxStatePct').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCountyPct').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCityPct').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxComm').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCommOnly').value = '';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control2") & "').value = '" & taxamount + taxmuamount & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCode').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtLINE_TOTAL').value = '" & extamt + taxmuamount + taxamount + markupamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtEXT_CONTINGENCY').value = '" & contamt + taxcontamt + mucontamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxStatePct').value = '" & taxstate & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCountyPct').value = '" & taxcounty & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCityPct').value = '" & taxcity & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxComm').value = '" & functionTaxComm & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCommOnly').value = '" & functionTaxCommOnly & "';"
                    End If
                End If
            ElseIf Request.QueryString("form") = "funcEst" Then
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                Dim dt As New DataTable
                Dim SQL As New System.Text.StringBuilder
                Dim functionDesc As String
                Dim functionType As String = ""
                Dim functionRate As String = "0.000"
                Dim functionNonBill As Integer
                Dim functionTaxComm As Integer = 0
                Dim functionTaxCommOnly As Integer = 0
                Dim functiontaxflag As Integer
                Dim taxcode As String = ""
                Dim taxState As Decimal
                Dim taxCounty As Decimal
                Dim taxCity As Decimal
                Dim taxResale As Integer
                Dim taxResaleNbr As String
                Dim suppliedby As String = ""

                Dim qty As Decimal = 0.0
                Dim extamt As Decimal = 0.0
                Dim contamt As Decimal = 0.0
                Dim contpct As Decimal = 0.0
                Dim markupamt As Decimal = 0.0
                Dim markuppct As Decimal = 0.0
                Dim linetotal As Decimal = 0.0
                Dim mucontamt As Decimal = 0.0
                Dim extnonresaletax As Decimal = 0.0
                Dim extstateresale As Decimal = 0.0
                Dim extcountyresale As Decimal = 0.0
                Dim extcityresale As Decimal = 0.0
                Dim extstatenonresale As Decimal = 0.0
                Dim extcountynonresale As Decimal = 0.0
                Dim extcitynonresale As Decimal = 0.0
                Dim extstatemarkup As Decimal = 0.0
                Dim extcountymarkup As Decimal = 0.0
                Dim extcitymarkup As Decimal = 0.0
                Dim extmucont As Decimal = 0.0
                Dim extstatecont As Decimal = 0.0
                Dim extcountycont As Decimal = 0.0
                Dim extcitycont As Decimal = 0.0
                Dim extnrcont As Decimal = 0.0
                Dim linetotalcont As Decimal = 0.0

                Dim parameterFNC_CODE As New SqlParameter("@FNC_CODE", SqlDbType.VarChar)
                Dim parameterEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
                Dim parameterEST_REV_EXT_AMT As New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
                Dim parameterEST_REV_COMM_PCT As New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
                Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
                Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
                Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
                Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
                Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
                Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
                Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)

                parameterFNC_CODE.Value = ""
                parameterEST_REV_RATE.Value = 0
                parameterEST_REV_EXT_AMT.Value = 0
                parameterEXT_MARKUP_AMT.Value = 0
                parameterEXT_CONTINGENCY.Value = 0
                parameterEXT_MU_CONT.Value = 0
                parameterLINE_TOTAL.Value = 0
                parameterLINE_TOTAL_CONT.Value = 0
                parameterEXT_STATE_RESALE.Value = 0
                parameterEXT_COUNTY_RESALE.Value = 0
                parameterEXT_CITY_RESALE.Value = 0
                parameterEXT_STATE_CONT.Value = 0
                parameterEXT_COUNTY_CONT.Value = 0
                parameterEXT_CITY_CONT.Value = 0
                parameterEXT_NONRESALE_TAX.Value = 0
                parameterEXT_NR_CONT.Value = 0

                Me.JobNumber = Session("EstFunctionEstJobNumSB")
                Me.JobComponentNbr = Session("EstFunctionEstJobCompNumSB")
                Me.ClCode = Session("EstFunctionEstClientSB")
                Me.DivCode = Session("EstFunctionEstDivisionSB")
                Me.PrdCode = Session("EstFunctionEstProductSB")
                Me.ScCode = Session("EstFunctionEstSalesClassSB")

                If Request.QueryString("suppliedby") <> "" Then
                    suppliedby = Request.QueryString("suppliedby")
                End If

                parameterFNC_CODE.Value = Me.SelectedValue(Me.RadGridLookup)

                dtInfo = est.GetDefaultFunctionData(Me.SelectedValue(Me.RadGridLookup), Me.JobNumber, Me.JobComponentNbr, Me.ClCode, Me.DivCode, Me.PrdCode, Me.ScCode, suppliedby)
                If dtInfo.Rows.Count > 0 Then
                    If IsDBNull(dtInfo.Rows(0)("FNC_DESCRIPTION")) = False Then
                        functionDesc = dtInfo.Rows(0)("FNC_DESCRIPTION").ToString.Replace("'", "")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("BILLING_RATE")) = False Then
                        functionRate = dtInfo.Rows(0)("BILLING_RATE")
                        parameterEST_REV_RATE.Value = functionRate
                    End If
                    If IsDBNull(dtInfo.Rows(0)("FNC_TYPE")) = False Then
                        functionType = dtInfo.Rows(0)("FNC_TYPE")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("NOBILL_FLAG")) = False Then
                        functionNonBill = dtInfo.Rows(0)("NOBILL_FLAG")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("TAX_COMM")) = False Then
                        functionTaxComm = dtInfo.Rows(0)("TAX_COMM")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("TAX_COMM_ONLY")) = False Then
                        functionTaxCommOnly = dtInfo.Rows(0)("TAX_COMM_ONLY")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("TAX_CODE")) = False Then
                        taxcode = dtInfo.Rows(0)("TAX_CODE")
                        functiontaxflag = 1
                    Else
                        taxcode = ""
                        functiontaxflag = 0
                    End If
                    taxState = dtInfo.Rows(0)("TAX_STATE_PERCENT")
                    taxCounty = dtInfo.Rows(0)("TAX_COUNTY_PERCENT")
                    taxCity = dtInfo.Rows(0)("TAX_CITY_PERCENT")
                    If IsDBNull(dtInfo.Rows(0)("TAX_RESALE")) = False Then
                        taxResale = dtInfo.Rows(0)("TAX_RESALE")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("TAX_RESALE_NUMBER")) = False Then
                        taxResaleNbr = dtInfo.Rows(0)("TAX_RESALE_NUMBER")
                    End If
                    If IsDBNull(dtInfo.Rows(0)("COMM")) = False Then
                        markuppct = dtInfo.Rows(0)("COMM")
                    End If
                End If

                SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                SQL.Append(" FNC_CODE = @FNC_CODE,")
                SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                SQL.Append(" TAX_CODE = @TAX_CODE")

                If Request.QueryString("qty") <> "" Then
                    qty = CDec(Request.QueryString("qty"))
                End If
                If Request.QueryString("muamt") <> "" And markuppct = 0 Then
                    markuppct = CDec(Request.QueryString("muamt"))
                End If
                If Request.QueryString("contamt") <> "" Then
                    contpct = Request.QueryString("contamt")
                End If
                If Request.QueryString("taxcode") <> "" Then
                    taxcode = Request.QueryString("taxcode")
                    dt = est.GetAddNewTaxData(taxcode)
                    If dt.Rows.Count > 0 Then
                        taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                        taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                        taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                        If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                            taxResale = dt.Rows(0)("TAX_RESALE")
                        End If
                    End If
                    functionTaxComm = Request.QueryString("tc")
                    functionTaxCommOnly = Request.QueryString("tco")
                End If


                If qty <> 0 Then
                    extamt = qty * functionRate
                    parameterEST_REV_EXT_AMT.Value = extamt
                End If
                If extamt <> 0 And markuppct <> 0 Then
                    markupamt = extamt * (markuppct / 100)
                    parameterEXT_MARKUP_AMT.Value = markupamt
                End If
                If extamt <> 0 Then
                    If contpct <> 0 Then
                        contamt = extamt * (contpct / 100)
                        extmucont = markupamt * (contpct / 100)
                    End If
                    If markuppct <> 0 Then
                        linetotalcont += (markupamt * (contpct / 100))
                    End If
                    parameterEXT_CONTINGENCY.Value = contamt
                    parameterEXT_MU_CONT.Value = extmucont
                End If

                parameterEST_REV_COMM_PCT.Value = markuppct
                parameterTAX_CODE.Value = taxcode

                If taxcode <> "" Then
                    If taxResale = 1 Then
                        If functionTaxCommOnly <> 1 Then
                            extstateresale = extamt * (taxState / 100)
                            extcountyresale = extamt * (taxCounty / 100)
                            extcityresale = extamt * (taxCity / 100)
                        End If
                        If functionTaxComm = 1 Then
                            If markupamt > 0 Then
                                extstatemarkup = markupamt * (taxState / 100)
                                extcountymarkup = markupamt * (taxCounty / 100)
                                extcitymarkup = markupamt * (taxCity / 100)
                            End If
                        End If
                        extstateresale += extstatemarkup
                        extcountyresale += extcountymarkup
                        extcityresale += extcitymarkup
                        parameterEXT_STATE_RESALE.Value = extstateresale
                        parameterEXT_COUNTY_RESALE.Value = extcountyresale
                        parameterEXT_CITY_RESALE.Value = extcityresale
                        If contamt > 0 Then
                            If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                extstatecont = extmucont * (taxState / 100)
                                extcountycont = extmucont * (taxCounty / 100)
                                extcitycont = extmucont * (taxCity / 100)
                            ElseIf functionTaxComm = 1 Then
                                extstatecont = (contamt + extmucont) * (taxState / 100)
                                extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                extcitycont = (contamt + extmucont) * (taxCity / 100)
                            Else
                                extstatecont = contamt * (taxState / 100)
                                extcountycont = contamt * (taxCounty / 100)
                                extcitycont = contamt * (taxCity / 100)
                            End If
                            parameterEXT_STATE_CONT.Value = extstatecont
                            parameterEXT_COUNTY_CONT.Value = extcountycont
                            parameterEXT_CITY_CONT.Value = extcitycont
                            'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                        End If
                        SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                        SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                    End If
                    If taxResale <> 1 Then
                        If functionType = "V" Then
                            If functionTaxCommOnly <> 1 Then
                                extstatenonresale = extamt * (taxState / 100)
                                extcountynonresale = extamt * (taxCounty / 100)
                                extcitynonresale = extamt * (taxCity / 100)
                                extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                Dim trstate As Decimal = extamt * (taxState / 100)
                                Dim trcounty As Decimal = extamt * (taxCounty / 100)
                                Dim trcity As Decimal = extamt * (taxCity / 100)
                                linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                            End If
                            If contamt > 0 Then
                                If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                    extnrcont = extmucont * (taxState / 100) + extmucont * (taxCounty / 100) + extmucont * (taxCity / 100)
                                ElseIf functionTaxComm = 1 Then
                                    extnrcont = (contamt + extmucont) * (taxState / 100) + contamt * (taxCounty / 100) + contamt * (taxCity / 100)
                                End If
                                parameterEXT_NR_CONT.Value = extnrcont
                                SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                            End If
                        ElseIf functionType = "E" Or functionType = "I" Then
                            If functionTaxCommOnly <> 1 Then
                                extstateresale = extamt * (taxState / 100)
                                extcountyresale = extamt * (taxCounty / 100)
                                extcityresale = extamt * (taxCity / 100)
                            End If
                            If contamt > 0 Then
                                If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                    extstatecont = extmucont * (taxState / 100)
                                    extcountycont = extmucont * (taxCounty / 100)
                                    extcitycont = extmucont * (taxCity / 100)
                                ElseIf functionTaxComm = "1" Then
                                    extstatecont = (contamt + extmucont) * (taxState / 100)
                                    extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                    extcitycont = (contamt + extmucont) * (taxCity / 100)
                                End If
                                parameterEXT_STATE_CONT.Value = extstatecont
                                parameterEXT_COUNTY_CONT.Value = extcountycont
                                parameterEXT_CITY_CONT.Value = extcitycont
                                SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                            End If
                        End If
                        If functionTaxComm = 1 Then
                            If markupamt > 0 Then
                                extstatemarkup = markupamt * (taxState / 100)
                                extcountymarkup = markupamt * (taxCounty / 100)
                                extcitymarkup = markupamt * (taxCity / 100)
                            End If
                        End If
                        extstateresale += extstatemarkup
                        extcountyresale += extcountymarkup
                        extcityresale += extcitymarkup
                        parameterEXT_STATE_RESALE.Value = extstateresale
                        parameterEXT_COUNTY_RESALE.Value = extcountyresale
                        parameterEXT_CITY_RESALE.Value = extcityresale
                        SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                    End If
                End If

                linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                parameterLINE_TOTAL.Value = linetotal
                SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                parameterLINE_TOTAL_CONT.Value = linetotalcont
                With SQL
                    .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                End With

                If Request.QueryString("new") <> "1" Then
                    Dim EstNumber As Integer = 0
                    Dim EstCompNbr As Integer = 0
                    Dim EstQuoteNbr As Integer = 0
                    Dim EstRevNbr As Integer = 0
                    Dim SeqNbr As Integer = -1
                    Dim ar() As String
                    ar = Request.QueryString("dk").ToString.Replace("'", "").Split("|")
                    Try
                        EstNumber = CInt(ar(0))
                    Catch ex As Exception
                        EstNumber = 0
                    End Try
                    Try
                        EstCompNbr = ar(1)
                    Catch ex As Exception
                        EstComponentNbr = 0
                    End Try
                    Try
                        EstQuoteNbr = ar(2)
                    Catch ex As Exception
                        EstQuoteNbr = 0
                    End Try
                    Try
                        EstRevNbr = ar(3)
                    Catch ex As Exception
                        EstRevNbr = 0
                    End Try
                    Try
                        SeqNbr = ar(4)
                    Catch ex As Exception
                        SeqNbr = -1
                    End Try

                    Dim MyCmd As New SqlCommand()
                    MyCmd.Parameters.Add(parameterFNC_CODE)
                    MyCmd.Parameters.Add(parameterEST_REV_RATE)
                    MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                    MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                    'MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                    MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                    MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                    MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                    MyCmd.Parameters.Add(parameterLINE_TOTAL)
                    MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                    MyCmd.Parameters.Add(parameterTAX_CODE)
                    If taxcode <> "" Then
                        MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                        MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                        MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                        MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                        MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                        MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                        MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                        MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                    End If

                    Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                    pESTIMATE_NUMBER.Value = EstNumber
                    MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                    Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                    pEST_COMPONENT_NBR.Value = EstCompNbr
                    MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                    Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                    pEST_QUOTE_NBR.Value = EstQuoteNbr
                    MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                    Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                    pEST_REV_NBR.Value = EstRevNbr
                    MyCmd.Parameters.Add(pEST_REV_NBR)

                    Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                    pSEQ_NBR.Value = SeqNbr
                    MyCmd.Parameters.Add(pSEQ_NBR)

                    Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                        Dim MyTrans As SqlTransaction
                        MyConn.Open()
                        MyTrans = MyConn.BeginTransaction
                        Try
                            With MyCmd
                                .CommandText = SQL.ToString()
                                .CommandType = CommandType.Text
                                .Connection = MyConn
                                .Transaction = MyTrans
                                .ExecuteNonQuery()
                                'ReturnMessage = "OK|" & qty
                            End With
                            MyTrans.Commit()
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                End If

                strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control2") & "').value = '" & functionType & "';"
                strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control3") & "').value = '" & functionDesc.ToString().Replace("'", "\'") & "';"
                strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control4") & "').value = '" & functionDesc.ToString().Replace("'", "\'") & "';"
                strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control5") & "').value = '" & functionRate & "';"
                Dim strcontrol As String = Request.QueryString("control")
                Dim str() As String = strcontrol.Split("_")
                Dim num As String = str(4).Substring(3)
                If Request.QueryString("new") = "1" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtTaxCode').value = '" & taxcode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCode').value = '" & taxcode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldNonbillFlag').value = '" & functionNonBill & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxComm').value = '" & functionTaxComm & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCommOnly').value = '" & functionTaxCommOnly & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxStatePct').value = '" & taxState & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCountyPct').value = '" & taxCounty & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCityPct').value = '" & taxCity & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxResale').value = '" & taxResale & "';"
                Else
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtEST_REV_RATE').value = '" & functionRate & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldNonbillFlag').value = '" & functionNonBill & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtTaxCode').value = '" & taxcode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCode').value = '" & taxcode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxComm').value = '" & functionTaxComm & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCommOnly').value = '" & functionTaxCommOnly & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxStatePct').value = '" & taxState & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCountyPct').value = '" & taxCounty & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCityPct').value = '" & taxCity & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxResale').value = '" & taxResale & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtEST_REV_COMM_PCT').value = '" & markuppct & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtEST_REV_EXT_AMT').value = '" & extamt & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtMARKUP_AMT').value = '" & markupamt & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtLINE_TOTAL').value = '" & linetotal & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtTAX_AMOUNT').value = '" & Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero) & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtEXT_CONTINGENCY').value = '" & Math.Round(linetotalcont, 2, MidpointRounding.AwayFromZero) & "';"
                End If

            ElseIf Request.QueryString("form") = "evt_gen_fnc" Then
                strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                Try
                    Dim arStr() As String
                    arStr = Me.SelectedText(Me.RadGridLookup).Split("-")
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtFunctionCodeDescription').value = '" & arStr(1).ToString().Replace("'", "\'").TrimStart(" ") & "';"
                Catch ex As Exception
                End Try
            ElseIf Request.QueryString("form") = "evt_gen_adnumber" Then
                strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                Try
                    Dim arStr() As String
                    arStr = Me.SelectedText(Me.RadGridLookup).Split("-")
                    strScript &= "CallingWindowContent.document.getElementById('TxtAdNumberDescription').value = '" & arStr(1).ToString().Replace("'", "\'").TrimStart(" ") & "';"
                Catch ex As Exception
                End Try
            ElseIf Request.QueryString("form") = "estimatequotedetailscopy" Then
                If IsNumeric(Me.EstimateNumber) = True Then

                    dtEst = oEstimating.GetInfoForEstimate(Me.EstimateNumber)
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientCode').value = '" & dtEst.Rows(0)("CL_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionCode').value = '" & dtEst.Rows(0)("DIV_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductCode').value = '" & dtEst.Rows(0)("PRD_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimate').value = '" & dtEst.Rows(0)("ESTIMATE_NUMBER") & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientDescription').value = '" & dtEst.Rows(0)("CL_NAME").ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionDescription').value = '" & dtEst.Rows(0)("DIV_NAME").ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductDescription').value = '" & dtEst.Rows(0)("PRD_DESCRIPTION").ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateDescription').value = '" & dtEst.Rows(0)("EST_LOG_DESC").ToString.Replace("'", "\'") & "';"

                    Dim s As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(Me.EstimateNumber)
                    If i <> 0 And i <> -1 Then
                        Try
                            dtEstComp = oEstimating.GetInfoForEstimateComp(Me.EstimateNumber, i)
                            If dtEstComp.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '" & dtEstComp.Rows(0)("EST_COMPONENT_NBR") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '" & dtEstComp.Rows(0)("EST_COMP_DESC").ToString.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    ElseIf i = -1 And IsNumeric(Me.EstimateNumber) = True And IsNumeric(Me.EstComponentNbr) = True Then
                        Try
                            dtEstComp = oEstimating.GetInfoForEstimateComp(Me.EstimateNumber, Me.EstComponentNbr)
                            If dtEstComp.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '" & dtEstComp.Rows(0)("EST_COMPONENT_NBR") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '" & dtEstComp.Rows(0)("EST_COMP_DESC").ToString.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponent').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateComponentDescription').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                    If Me.EstComponentNbr <> "" Then
                        i = s.CountCompQuotesOneComp(Me.EstimateNumber, Me.EstComponentNbr)
                        If 1 <> 0 And i <> -1 Then
                            Try
                                dtEstComp = oEstimating.GetInfoForEstimateQuote(Me.EstimateNumber, Me.EstComponentNbr, i).Tables(0)
                                If dtEstComp.Rows.Count > 0 Then
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtQuote').value = '" & dtEstComp.Rows(0)("EST_QUOTE_NBR") & "';"
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtQuoteDescription').value = '" & dtEstComp.Rows(0)("EST_QUOTE_DESC").ToString.Replace("'", "\'") & "';"
                                Else
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtQuote').value = '';"
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtQuoteDescription').value = '';"
                                End If
                            Catch ex As Exception

                            End Try
                        ElseIf i = -1 And IsNumeric(Me.EstimateNumber) = True And IsNumeric(Me.EstComponentNbr) = True And IsNumeric(EstQuoteNbr) = True Then
                            Try
                                dtEstComp = oEstimating.GetInfoForEstimateQuote(Me.EstimateNumber, Me.EstComponentNbr, EstQuoteNbr).Tables(0)
                                If dtEstComp.Rows.Count > 0 Then
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtQuote').value = '" & dtEstComp.Rows(0)("EST_QUOTE_NBR") & "';"
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtQuoteDescription').value = '" & dtEstComp.Rows(0)("EST_QUOTE_DESC").ToString.Replace("'", "\'") & "';"
                                Else
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtQuote').value = '';"
                                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtQuoteDescription').value = '';"
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                End If
            ElseIf Request.QueryString("form") = "suppliedby" Then
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                Dim dt As New DataTable
                Dim ReturnMessage As String = ""
                Dim SQL As New System.Text.StringBuilder
                Dim functionDesc As String
                Dim functionType As String
                Dim functionRate As String
                Dim functionNonBill As Integer
                Dim functionTaxComm As Integer
                Dim functionTaxCommOnly As Integer
                Dim taxState As Decimal
                Dim taxCounty As Decimal
                Dim taxCity As Decimal
                Dim taxResale As Integer
                Dim taxResaleNbr As String
                Dim markuppct As Decimal
                Dim taxcode As String
                Dim markupamt As Decimal
                Dim extamt As Decimal
                Dim qty As Decimal
                Dim extnonresaletax As Decimal = 0.0
                Dim extstateresale As Decimal = 0.0
                Dim extcountyresale As Decimal = 0.0
                Dim extcityresale As Decimal = 0.0
                Dim extstatenonresale As Decimal = 0.0
                Dim extcountynonresale As Decimal = 0.0
                Dim extcitynonresale As Decimal = 0.0
                Dim extstatemarkup As Decimal = 0.0
                Dim extcountymarkup As Decimal = 0.0
                Dim extcitymarkup As Decimal = 0.0
                Dim extmucont As Decimal = 0.0
                Dim extstatecont As Decimal = 0.0
                Dim extcountycont As Decimal = 0.0
                Dim extcitycont As Decimal = 0.0
                Dim extnrcont As Decimal = 0.0
                Dim linetotal As Decimal = 0.0
                Dim linetotalcont As Decimal = 0.0
                Dim contpct As Decimal = 0.0
                Dim contamt As Decimal = 0.0
                If Me.JobNumber = "" Then
                    Me.JobNumber = "0"
                End If
                If Me.JobComponentNbr = "" Then
                    Me.JobComponentNbr = "0"
                End If
                Dim parameterEST_REV_SUP_BY_CDE As New SqlParameter("@EST_REV_SUP_BY_CDE", SqlDbType.VarChar)
                Dim parameterEST_REV_QUANTITY As New SqlParameter("@EST_REV_QUANTITY", SqlDbType.Decimal)
                Dim parameterEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
                Dim parameterEST_REV_EXT_AMT As New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
                Dim parameterEST_REV_COMM_PCT As New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
                Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
                Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
                Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
                Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
                Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
                Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
                Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)

                parameterEST_REV_QUANTITY.Value = 0
                parameterEST_REV_RATE.Value = 0
                parameterEST_REV_EXT_AMT.Value = 0
                parameterEXT_MARKUP_AMT.Value = 0
                parameterEXT_CONTINGENCY.Value = 0
                parameterEXT_MU_CONT.Value = 0
                parameterLINE_TOTAL.Value = 0
                parameterLINE_TOTAL_CONT.Value = 0
                parameterEXT_STATE_RESALE.Value = 0
                parameterEXT_COUNTY_RESALE.Value = 0
                parameterEXT_CITY_RESALE.Value = 0
                parameterEXT_STATE_CONT.Value = 0
                parameterEXT_COUNTY_CONT.Value = 0
                parameterEXT_CITY_CONT.Value = 0
                parameterEXT_NONRESALE_TAX.Value = 0
                parameterEXT_NR_CONT.Value = 0

                If Request.QueryString("page") = "qa" Then
                    strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                Else
                    Me.JobNumber = Session("EstFunctionEstJobNumSB")
                    Me.JobComponentNbr = Session("EstFunctionEstJobCompNumSB")
                    Me.ClCode = Session("EstFunctionEstClientSB")
                    Me.DivCode = Session("EstFunctionEstDivisionSB")
                    Me.PrdCode = Session("EstFunctionEstProductSB")
                    Me.ScCode = Session("EstFunctionEstSalesClassSB")
                    If Request.QueryString("contpct") <> "" Then
                        contpct = Request.QueryString("contpct")
                    Else
                        contpct = 0.0
                    End If
                    If Request.QueryString("qty") <> "" Then
                        qty = CDec(Request.QueryString("qty"))
                    Else
                        qty = 0.0
                    End If

                    SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                    SQL.Append(" EST_REV_SUP_BY_CDE = @EST_REV_SUP_BY_CDE,")
                    SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                    SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                    SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                    SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                    SQL.Append(" EST_REV_CONT_PCT = @EST_REV_CONT_PCT,")
                    SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                    SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                    SQL.Append(" TAX_CODE = @TAX_CODE")

                    If Me.SelectedValue(Me.RadGridLookup) Is Nothing Then
                        parameterEST_REV_SUP_BY_CDE.Value = DBNull.Value
                    Else
                        parameterEST_REV_SUP_BY_CDE.Value = Me.SelectedValue(Me.RadGridLookup)
                    End If


                    dtInfo = est.GetDefaultFunctionData(Request.QueryString("funccode"), Me.JobNumber, Me.JobComponentNbr, Me.ClCode, Me.DivCode, Me.PrdCode, Me.ScCode, Me.SelectedValue(Me.RadGridLookup))
                    If dtInfo.Rows.Count > 0 Then
                        If IsDBNull(dtInfo.Rows(0)("FNC_DESCRIPTION")) = False Then
                            functionDesc = dtInfo.Rows(0)("FNC_DESCRIPTION")
                        End If
                        If IsDBNull(dtInfo.Rows(0)("BILLING_RATE")) = False Then
                            functionRate = dtInfo.Rows(0)("BILLING_RATE")
                            parameterEST_REV_RATE.Value = functionRate
                        End If
                        If IsDBNull(dtInfo.Rows(0)("FNC_TYPE")) = False Then
                            functionType = dtInfo.Rows(0)("FNC_TYPE")
                        End If
                        If IsDBNull(dtInfo.Rows(0)("NOBILL_FLAG")) = False Then
                            functionNonBill = dtInfo.Rows(0)("NOBILL_FLAG")
                        End If
                        If IsDBNull(dtInfo.Rows(0)("TAX_COMM")) = False Then
                            functionTaxComm = dtInfo.Rows(0)("TAX_COMM")
                        End If
                        If IsDBNull(dtInfo.Rows(0)("TAX_COMM_ONLY")) = False Then
                            functionTaxCommOnly = dtInfo.Rows(0)("TAX_COMM_ONLY")
                        End If
                        If IsDBNull(dtInfo.Rows(0)("TAX_CODE")) = False Then
                            taxcode = dtInfo.Rows(0)("TAX_CODE")
                            taxState = dtInfo.Rows(0)("TAX_STATE_PERCENT")
                            taxCounty = dtInfo.Rows(0)("TAX_COUNTY_PERCENT")
                            taxCity = dtInfo.Rows(0)("TAX_CITY_PERCENT")
                            If IsDBNull(dtInfo.Rows(0)("TAX_RESALE")) = False Then
                                taxResale = dtInfo.Rows(0)("TAX_RESALE")
                            End If
                        ElseIf Request.QueryString("taxcode") <> "" Then
                            taxcode = Request.QueryString("taxcode")
                            dt = est.GetAddNewTaxData(taxcode)
                            If dt.Rows.Count > 0 Then
                                taxState = dt.Rows(0)("TAX_STATE_PERCENT")
                                taxCounty = dt.Rows(0)("TAX_COUNTY_PERCENT")
                                taxCity = dt.Rows(0)("TAX_CITY_PERCENT")
                                If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                    taxResale = dt.Rows(0)("TAX_RESALE")
                                End If
                            End If
                            functionTaxComm = Request.QueryString("tc")
                            functionTaxCommOnly = Request.QueryString("tco")
                        Else
                            taxcode = ""
                        End If
                        If IsDBNull(dtInfo.Rows(0)("TAX_RESALE_NUMBER")) = False Then
                            taxResaleNbr = dtInfo.Rows(0)("TAX_RESALE_NUMBER")
                        End If
                        If IsDBNull(dtInfo.Rows(0)("COMM")) = False Then
                            markuppct = dtInfo.Rows(0)("COMM")
                            parameterEST_REV_COMM_PCT.Value = markuppct
                        ElseIf Request.QueryString("markuppct") <> "" Then
                            markuppct = Request.QueryString("markuppct")
                            parameterEST_REV_COMM_PCT.Value = markuppct
                        End If
                        extamt = qty * functionRate
                        parameterEST_REV_EXT_AMT.Value = extamt
                        If markuppct > 0 Then
                            markupamt = extamt * (markuppct / 100)
                        End If
                        parameterEXT_MARKUP_AMT.Value = markupamt
                        If contpct > 0 Then
                            contamt = extamt * (contpct / 100)
                            extmucont = markupamt * (contpct / 100)
                            If markuppct > 0 Then
                                linetotalcont += (markupamt * (contpct / 100))
                            End If
                        End If

                        parameterEST_REV_CONT_PCT.Value = contpct
                        parameterEXT_CONTINGENCY.Value = contamt
                        parameterEXT_MU_CONT.Value = extmucont
                        parameterTAX_CODE.Value = taxcode

                        If taxcode <> "" Then
                            If taxResale = 1 Then
                                If functionTaxCommOnly <> 1 Then
                                    extstateresale = extamt * (taxState / 100)
                                    extcountyresale = extamt * (taxCounty / 100)
                                    extcityresale = extamt * (taxCity / 100)
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                If contamt > 0 Then
                                    If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                        extstatecont = extmucont * (taxState / 100)
                                        extcountycont = extmucont * (taxCounty / 100)
                                        extcitycont = extmucont * (taxCity / 100)
                                    ElseIf functionTaxComm = 1 Then
                                        extstatecont = (contamt + extmucont) * (taxState / 100)
                                        extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                        extcitycont = (contamt + extmucont) * (taxCity / 100)
                                    Else
                                        extstatecont = contamt * (taxState / 100)
                                        extcountycont = contamt * (taxCounty / 100)
                                        extcitycont = contamt * (taxCity / 100)
                                    End If
                                    parameterEXT_STATE_CONT.Value = extstatecont
                                    parameterEXT_COUNTY_CONT.Value = extcountycont
                                    parameterEXT_CITY_CONT.Value = extcitycont
                                    'linetotalcont += Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero)
                                End If
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                            End If
                            If taxResale <> 1 Then
                                If functionType = "V" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstatenonresale = extamt * (taxState / 100)
                                        extcountynonresale = extamt * (taxCounty / 100)
                                        extcitynonresale = extamt * (taxCity / 100)
                                        extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                        Dim trstate As Decimal = extamt * (taxState / 100)
                                        Dim trcounty As Decimal = extamt * (taxCounty / 100)
                                        Dim trcity As Decimal = extamt * (taxCity / 100)
                                        linetotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                        parameterEXT_NONRESALE_TAX.Value = extstatenonresale + extcountynonresale + extcitynonresale
                                        SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = 1 And functionTaxCommOnly = 1 Then
                                            extnrcont = extmucont * (taxState / 100) + extmucont * (taxCounty / 100) + extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = 1 Then
                                            extnrcont = (contamt + extmucont) * (taxState / 100) + contamt * (taxCounty / 100) + contamt * (taxCity / 100)
                                        End If
                                        parameterEXT_NR_CONT.Value = extnrcont
                                        SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                    End If
                                ElseIf functionType = "E" Or functionType = "I" Then
                                    If functionTaxCommOnly <> 1 Then
                                        extstateresale = extamt * (taxState / 100)
                                        extcountyresale = extamt * (taxCounty / 100)
                                        extcityresale = extamt * (taxCity / 100)
                                    End If
                                    If contamt > 0 Then
                                        If functionTaxComm = "1" And functionTaxCommOnly = "1" Then
                                            extstatecont = extmucont * (taxState / 100)
                                            extcountycont = extmucont * (taxCounty / 100)
                                            extcitycont = extmucont * (taxCity / 100)
                                        ElseIf functionTaxComm = "1" Then
                                            extstatecont = (contamt + extmucont) * (taxState / 100)
                                            extcountycont = (contamt + extmucont) * (taxCounty / 100)
                                            extcitycont = (contamt + extmucont) * (taxCity / 100)
                                        End If
                                        parameterEXT_STATE_CONT.Value = extstatecont
                                        parameterEXT_COUNTY_CONT.Value = extcountycont
                                        parameterEXT_CITY_CONT.Value = extcitycont
                                        SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                    End If
                                End If
                                If functionTaxComm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxState / 100)
                                        extcountymarkup = markupamt * (taxCounty / 100)
                                        extcitymarkup = markupamt * (taxCity / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                parameterEXT_STATE_RESALE.Value = extstateresale
                                parameterEXT_COUNTY_RESALE.Value = extcountyresale
                                parameterEXT_CITY_RESALE.Value = extcityresale
                                SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                            End If
                        End If
                    End If

                    linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
                    linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                    SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                    parameterLINE_TOTAL.Value = linetotal
                    SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                    parameterLINE_TOTAL_CONT.Value = linetotalcont
                    With SQL
                        .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                    End With

                    Dim EstNumber As Integer = 0
                    Dim EstCompNbr As Integer = 0
                    Dim EstQuoteNbr As Integer = 0
                    Dim EstRevNbr As Integer = 0
                    Dim SeqNbr As Integer = -1
                    Dim ar() As String
                    ar = Request.QueryString("dk").ToString.Replace("'", "").Split("|")
                    Try
                        EstNumber = CInt(ar(0))
                    Catch ex As Exception
                        EstNumber = 0
                    End Try
                    Try
                        EstCompNbr = ar(1)
                    Catch ex As Exception
                        EstComponentNbr = 0
                    End Try
                    Try
                        EstQuoteNbr = ar(2)
                    Catch ex As Exception
                        EstQuoteNbr = 0
                    End Try
                    Try
                        EstRevNbr = ar(3)
                    Catch ex As Exception
                        EstRevNbr = 0
                    End Try
                    Try
                        SeqNbr = ar(4)
                    Catch ex As Exception
                        SeqNbr = -1
                    End Try

                    If Request.QueryString("new") <> "1" Then
                        Dim MyCmd As New SqlCommand()
                        MyCmd.Parameters.Add(parameterEST_REV_SUP_BY_CDE)
                        MyCmd.Parameters.Add(parameterEST_REV_QUANTITY)
                        MyCmd.Parameters.Add(parameterEST_REV_RATE)
                        MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                        MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                        MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                        MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                        MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                        MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL)
                        MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                        MyCmd.Parameters.Add(parameterTAX_CODE)
                        If taxcode <> "" Then
                            MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                            MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                            MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                            MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                            MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                        End If

                        Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                        pESTIMATE_NUMBER.Value = EstNumber
                        MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                        Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                        pEST_COMPONENT_NBR.Value = EstCompNbr
                        MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                        Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                        pEST_QUOTE_NBR.Value = EstQuoteNbr
                        MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                        Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                        pEST_REV_NBR.Value = EstRevNbr
                        MyCmd.Parameters.Add(pEST_REV_NBR)

                        Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = SeqNbr
                        MyCmd.Parameters.Add(pSEQ_NBR)

                        Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                            Dim MyTrans As SqlTransaction
                            MyConn.Open()
                            MyTrans = MyConn.BeginTransaction
                            Try
                                With MyCmd
                                    .CommandText = SQL.ToString()
                                    .CommandType = CommandType.Text
                                    .Connection = MyConn
                                    .Transaction = MyTrans
                                    .ExecuteNonQuery()
                                    ReturnMessage = "OK|" & qty
                                End With
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using
                    End If

                    Dim strcontrol As String = Request.QueryString("control")
                    Dim str() As String = strcontrol.Split("_")
                    Dim num As String = str(4).Substring(3)
                    If Request.QueryString("new") <> "1" Then
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HfSuppliedByCode').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtEST_REV_RATE').value = '" & functionRate & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldNonbillFlag').value = '" & functionNonBill & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxComm').value = '" & functionTaxComm & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCommOnly').value = '" & functionTaxCommOnly & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxStatePct').value = '" & taxState & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCountyPct').value = '" & taxCounty & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxCityPct').value = '" & taxCity & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_HiddenFieldTaxResale').value = '" & taxResale & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtEST_REV_COMM_PCT').value = '" & markuppct & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtEST_REV_EXT_AMT').value = '" & extamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtMARKUP_AMT').value = '" & markupamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtLINE_TOTAL').value = '" & linetotal & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtTAX_AMOUNT').value = '" & Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_TxtEXT_CONTINGENCY').value = '" & linetotalcont & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HfSuppliedByCode').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtEST_REV_RATE').value = '" & functionRate & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldNonbillFlag').value = '" & functionNonBill & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxComm').value = '" & functionTaxComm & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCommOnly').value = '" & functionTaxCommOnly & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxStatePct').value = '" & taxState & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCountyPct').value = '" & taxCounty & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxCityPct').value = '" & taxCity & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_HiddenFieldTaxResale').value = '" & taxResale & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtEST_REV_COMM_PCT').value = '" & markuppct & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtEST_REV_EXT_AMT').value = '" & extamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtMARKUP_AMT').value = '" & markupamt & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtLINE_TOTAL').value = '" & linetotal & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtTAX_AMOUNT').value = '" & Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero) & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadGridEstimateQuoteDetails_ctl00_ctl" & num & "_ctl01_TxtEXT_CONTINGENCY').value = '" & linetotalcont & "';"
                    End If
                End If

            ElseIf Request.QueryString("form") = "estimatecopy" Then
                If IsNumeric(Me.EstimateNumber) = True Then

                    dtEst = oEstimating.GetInfoForEstimate(Me.EstimateNumber)
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSource').value = '" & dtEst.Rows(0)("CL_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSource').value = '" & dtEst.Rows(0)("DIV_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSource').value = '" & dtEst.Rows(0)("PRD_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateSource').value = '" & dtEst.Rows(0)("ESTIMATE_NUMBER") & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSourceDesc').value = '" & dtEst.Rows(0)("CL_NAME").ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSourceDesc').value = '" & dtEst.Rows(0)("DIV_NAME").ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSourceDesc').value = '" & dtEst.Rows(0)("PRD_DESCRIPTION").ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtEstimateSourceDesc').value = '" & dtEst.Rows(0)("EST_LOG_DESC").ToString.Replace("'", "\'") & "';"

                    Dim s As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(Me.EstimateNumber)
                End If
            ElseIf Request.QueryString("form") = "estimatequote" Then
                If IsNumeric(EstQuoteNbr) = True Then
                    strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control") & "').value = '" & EstQuoteNbr & "';"
                    strScript &= "CallingWindowContent.document.getElementById('" & Request.QueryString("control2") & "').value = '" & Me.EstRevNbr & "';"
                End If
            ElseIf Request.QueryString("form") = "jobcopy" Then
                If IsNumeric(JobNumber) = True Then
                    Dim ClDesc As String = ""
                    Dim DivDesc As String = ""
                    Dim PrdDesc As String = ""
                    Dim JobDesc As String = ""
                    Dim ScDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, ScDesc, Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSource').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSource').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSource').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobSource').value = '" & JobNumber & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtSalesClassSource').value = '" & Me.ScCode & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSourceDesc').value = '" & ClDesc.ToString().Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSourceDesc').value = '" & DivDesc.ToString().Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSourceDesc').value = '" & PrdDesc.ToString().Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobSourceDesc').value = '" & JobDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtSalesClassDescriptionSource').value = '" & ScDesc.ToString.Replace("'", "\'") & "';"
                    If CheckboxClosedJobs.Checked = True Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_cbShowClosed').checked = 1;"
                    End If

                    If _AutoSearch Then

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_btnComps').click();"

                    End If

                End If
            ElseIf Request.QueryString("form") = "jobcopyps" Then
                If IsNumeric(JobNumber) = True Then
                    Dim ClDesc As String = ""
                    Dim DivDesc As String = ""
                    Dim PrdDesc As String = ""
                    Dim JobDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, "", Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSource').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSource').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSource').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobSource').value = '" & JobNumber & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSourceDesc').value = '" & ClDesc.ToString().Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSourceDesc').value = '" & DivDesc.ToString().Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSourceDesc').value = '" & PrdDesc.ToString().Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobSourceDesc').value = '" & JobDesc.ToString().Replace("'", "\'") & "';"

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True)
                    Dim compdesc As String = ""
                    If i <> 0 And i >= 1 Then
                        Try
                            If oTS.GetJobComponentInfo(JobNumber, i, , compdesc) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompSource').value = '" & i & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompSourceDesc').value = '" & compdesc.ToString().Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompSource').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompSourceDesc').value = '';"
                            End If
                        Catch ex As Exception

                        End Try
                    ElseIf IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        Try
                            If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, , compdesc) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompSource').value = '" & JobComponentNbr & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompSourceDesc').value = '" & compdesc.ToString.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompSource').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompSourceDesc').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
            ElseIf Request.QueryString("form") = "jobcopycomp" Then
                If IsNumeric(JobNumber) = True Then
                    Dim ClDesc As String = ""
                    Dim DivDesc As String = ""
                    Dim PrdDesc As String = ""
                    Dim JobDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, "", Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSource').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSource').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSource').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobSource').value = '" & JobNumber & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSourceDesc').value = '" & ClDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSourceDesc').value = '" & DivDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSourceDesc').value = '" & PrdDesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobSourceDesc').value = '" & JobDesc.Replace("'", "\'") & "';"
                    If CheckboxClosedJobs.Checked = True Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_cbShowClosed').checked = 1;"
                    End If

                    If _AutoSearch Then

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_btnComps').click();"

                    End If

                End If
            ElseIf Request.QueryString("form") = "jobcopycompps" Then
                If IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                    Dim jobdesc As String = ""
                    Dim jobcompdesc As String = ""
                    Dim officename As String = ""
                    Dim cldesc As String = ""
                    Dim divdesc As String = ""
                    Dim prddesc As String = ""

                    oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, jobdesc, jobcompdesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, officename, cldesc, divdesc, prddesc)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSource').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSource').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSource').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobSource').value = '" & JobNumber & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompSource').value = '" & JobComponentNbr & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSourceDesc').value = '" & cldesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSourceDesc').value = '" & divdesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSourceDesc').value = '" & prddesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobSourceDesc').value = '" & jobdesc.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompSourceDesc').value = '" & jobcompdesc.Replace("'", "") & "';"

                End If
            ElseIf Request.QueryString("form") = "estimatesearchjob" Then
                If IsNumeric(Me.EstimateNumber) = True Then

                    dtEst = oEstimating.GetInfoForEstimate(Me.EstimateNumber)
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & dtEst.Rows(0)("CL_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & dtEst.Rows(0)("DIV_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & dtEst.Rows(0)("PRD_CODE") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimate').value = '" & dtEst.Rows(0)("ESTIMATE_NUMBER") & "';"


                    Dim s As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(Me.EstimateNumber)
                    If i <> 0 And i <> -1 Then
                        Try
                            dtEstComp = oEstimating.GetInfoForEstimateComp(Me.EstimateNumber, i)
                            If dtEstComp.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateComponent').value = '" & dtEstComp.Rows(0)("EST_COMPONENT_NBR") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value = '" & dtEstComp.Rows(0)("JOB_NUMBER") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & dtEstComp.Rows(0)("JOB_COMPONENT_NBR") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateComponent').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    ElseIf i = -1 And IsNumeric(Me.EstimateNumber) = True And IsNumeric(Me.EstComponentNbr) = True Then
                        Try
                            dtEstComp = oEstimating.GetInfoForEstimateComp(Me.EstimateNumber, Me.EstComponentNbr)
                            If dtEstComp.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateComponent').value = '" & dtEstComp.Rows(0)("EST_COMPONENT_NBR") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value = '" & dtEstComp.Rows(0)("JOB_NUMBER") & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & dtEstComp.Rows(0)("JOB_COMPONENT_NBR") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateComponent').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    End If

                    If _AutoSearch Then

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                    End If

                End If
            ElseIf Request.QueryString("form") = "estimatesearchjc" Then
                If IsNumeric(JobNumber) = True Then
                    oTS.GetJobInfo(JobNumber, "", Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", "", "", "", Me.ScCode, "", Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value = '" & JobNumber & "';"

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True, CheckboxClosedJobs.Checked)
                    If IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        Try
                            Dim ojob As New JOB_COMPONENT(Session("ConnString"))
                            ojob.LoadByPrimaryKey(JobComponentNbr, JobNumber)
                            If ojob.s_ESTIMATE_NUMBER <> "" Then
                                dtEst = oEstimating.GetInfoForEstimateComp(ojob.ESTIMATE_NUMBER, ojob.EST_COMPONENT_NBR)
                            End If

                            If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & JobComponentNbr & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '';"
                            End If
                            If dtEst.Rows.Count > 0 Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimate').value = '" & ojob.ESTIMATE_NUMBER & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateComponent').value = '" & ojob.EST_COMPONENT_NBR & "';"
                            End If
                        Catch ex As Exception
                        End Try
                    ElseIf i <> 0 And i >= 1 Then
                        Try
                            Dim ojob As New JOB_COMPONENT(Session("ConnString"))
                            ojob.LoadByPrimaryKey(i, JobNumber)
                            If ojob.s_ESTIMATE_NUMBER <> "" Then
                                If ojob.ESTIMATE_NUMBER <> 0 Then
                                    dtEst = oEstimating.GetInfoForEstimateComp(ojob.ESTIMATE_NUMBER, ojob.EST_COMPONENT_NBR)
                                End If
                            End If
                            If oTS.GetJobComponentInfo(JobNumber, i) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & i & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimate').value = '" & ojob.ESTIMATE_NUMBER & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateComponent').value = '" & ojob.EST_COMPONENT_NBR & "';"

                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimate').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtEstimateComponent').value = '';"
                            End If
                        Catch ex As Exception
                        End Try

                    End If

                    If _AutoSearch Then

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                    End If

                End If
            ElseIf Request.QueryString("form") = "estimatesearchprod" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"

                If _AutoSearch Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                End If

            ElseIf Request.QueryString("form") = "jobtype" Or Request.QueryString("form") = "jtn" Then
                Dim str() As String = Me.SelectedText(Me.RadGridLookup).Split("-")
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobTypeSource').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                If str(1) <> "" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobTypeSourceDesc').value = '" & str(1).Trim.Replace("'", "\'") & "';"
                End If
            ElseIf Request.QueryString("form") = "jtn1" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxJobType').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
            ElseIf Request.QueryString("form") = "jobtypejh" Then
                Dim str() As String = Me.SelectedText(Me.RadGridLookup).Split("-")
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobType').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                If str(1) <> "" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobTypeDescription').value = '" & str(1).Trim.Replace("'", "\'") & "';"
                End If
            ElseIf Request.QueryString("form") = "statuscodes" Then
                Dim str() As String = Me.SelectedText(Me.RadGridLookup).Split("-")
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtStatusCopy').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                If str(1) <> "" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtStatusDescCopy').value = '" & str(1).Trim.Replace("'", "\'") & "';"
                End If
            ElseIf Request.QueryString("form") = "copyjob_statuscodes" Then
                Dim str() As String = Me.SelectedText(Me.RadGridLookup).Split("-")
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxStatusFilter').value = '" & Me.SelectedValue(Me.RadGridLookup) & "';"
                If str(1) <> "" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBoxStatusFilterDescription').value = '" & str(1).Trim.Replace("'", "\'") & "';"
                End If
            ElseIf Request.QueryString("form") = "campaignnew" Then
                If Request.QueryString("type") = "division" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"

                ElseIf Request.QueryString("type") = "product" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                End If

            ElseIf Request.QueryString("form") = "campaignsearch" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"

                If Request.QueryString("type") = "campaign" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtCampaignCode').value = '" & Me.CmpCode & "';"
                End If

                If _AutoSearch Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                End If

            ElseIf Request.QueryString("form") = "estcampaignnew" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientCode').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionCode').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductCode').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtCampaign').value = '" & Me.CmpCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtCampaignDescription').value = '" & Me.CampaignDescription.ToString.Replace("'", "\'") & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_HiddenFieldCampaignID').value = '" & Me.CampaignId & "';"
            ElseIf Request.QueryString("form") = "estcampaignsearch" Then
                If Request.QueryString("type") = "estcampaignedit" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtCampaignCode').value = '" & Me.CmpCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtCampaignDescription').value = '" & Me.CampaignDescription.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_HiddenfieldCampaignID').value = '" & Me.CampaignId & "';"
                Else
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtCampaign').value = '" & Me.CmpCode & "';"
                    'strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_HiddenFieldCampaignID').value = '" & Me.CampaignId & "';"

                    If _AutoSearch Then

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                    End If

                End If

            ElseIf Request.QueryString("form") = "jobvercopy" Then
                If IsNumeric(JobNumber) = True Then
                    Dim ClDesc As String = ""
                    Dim DivDesc As String = ""
                    Dim PrdDesc As String = ""
                    Dim JobDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, "", Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSource').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSource').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSource').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobNum').value = '" & JobNumber & "';"

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientSourceDesc').value = '" & ClDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionSourceDesc').value = '" & DivDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductSourceDesc').value = '" & PrdDesc.ToString.Replace("'", "\'") & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value = '" & JobDesc.ToString.Replace("'", "\'") & "';"

                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Dim i As Integer = s.CountHeaderComponentsOneComp(JobNumber, True, CheckboxClosedJobs.Checked)
                    Dim CompDesc As String = ""
                    If i <> 0 And i >= 1 Then
                        Try
                            If oTS.GetJobComponentInfo(JobNumber, i, "", CompDesc) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & i & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & CompDesc.ToString.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    ElseIf IsNumeric(JobNumber) = True And IsNumeric(JobComponentNbr) = True Then
                        Try
                            If oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, "", CompDesc) = True Then
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '" & JobComponentNbr & "';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & CompDesc.Replace("'", "\'") & "';"
                            Else
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompNum').value = '';"
                                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
            ElseIf Request.QueryString("form") = "jobcmpsearch" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOffice').value = '" & Me.OfficeCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtCampaign').value = '" & Me.CmpCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_hfCampaignID').value = '" & Me.CampaignId & "';"

                If _AutoSearch Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                End If

            ElseIf Request.QueryString("form") = "jobcmpnew" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                If Me.DivCode <> "" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                End If
                If Me.PrdCode <> "" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                End If
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtCampaign').value = '" & Me.CmpCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_hfCampaignID').value = '" & Me.CampaignId & "';"
            ElseIf Request.QueryString("form") = "calcmpsearch" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_txtOffice').value = '" & Me.OfficeCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_txtCampaign').value = '" & Me.CmpCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_FilterPanelFilter_i0_i0_hfCampaignID').value = '" & Me.CampaignId & "';"
            ElseIf Request.QueryString("form") = "pscmpsearch" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtOffice').value = '" & Me.OfficeCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtCampaign').value = '" & Me.CmpCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_hfCampaignID').value = '" & Me.CampaignId & "';"

                If _AutoSearch Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                End If

            ElseIf Request.QueryString("form") = "tsta" Then
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJobComp').value = '" & JobComponentNbr & "';"
            ElseIf Request.QueryString("form") = "no_master" Then
                strScript &= "CallingWindowContent.document.getElementById('txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('txtJob').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('txtJobComp').value = '" & JobComponentNbr & "';"
            ElseIf Request.QueryString("form") = "calactivity" Then
                If HiddenFieldLookupType.Value = "product" Then
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientDesc').value = '" & MiscFN.JavascriptSafe(req.GetDescription("CL", Me.ClCode)) & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionDesc').value = '" & MiscFN.JavascriptSafe(req.GetDescription("DI", Me.ClCode & "," & Me.DivCode)) & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductDesc').value = '" & MiscFN.JavascriptSafe(req.GetDescription("PR", Me.ClCode & "," & Me.DivCode & "," & Me.PrdCode)) & "';"
                End If
                If HiddenFieldLookupType.Value = "Job1" Or HiddenFieldLookupType.Value = "Job2" Or HiddenFieldLookupType.Value = "JobComp1" Or HiddenFieldLookupType.Value = "JobComp2" Then
                    Dim ClDesc As String = ""
                    Dim DivDesc As String = ""
                    Dim PrdDesc As String = ""
                    Dim JobDesc As String = ""
                    Dim CompDesc As String = ""
                    oTS.GetJobInfo(JobNumber, JobDesc, Me.OfficeCode, Me.ClCode, Me.DivCode, Me.PrdCode, "", ClDesc, DivDesc, PrdDesc, Me.ScCode, "", Me.CmpCode, Me.CampaignId)

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtClientDesc').value = '" & MiscFN.JavascriptSafe(req.GetDescription("CL", Me.ClCode)) & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtDivisionDesc').value = '" & MiscFN.JavascriptSafe(req.GetDescription("DI", Me.ClCode & "," & Me.DivCode)) & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtProductDesc').value = '" & MiscFN.JavascriptSafe(req.GetDescription("PR", Me.ClCode & "," & Me.DivCode & "," & Me.PrdCode)) & "';"

                    If Me.JobNumber > 0 Then
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & Me.JobNumber & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value ='" & JobDesc & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobDescription').value ='';"
                    End If
                    If Me.JobComponentNbr > 0 Then
                        oTS.GetJobComponentInfo(JobNumber, JobComponentNbr, "", CompDesc)
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '" & Me.JobComponentNbr & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '" & CompDesc & "';"
                    Else
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtComponent').value = '';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtJobCompDescription').value = '';"
                    End If
                End If
                If HiddenFieldLookupType.Value = "task" Then
                    Try
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtTask').value = '" & Me.SelectedValue(Me.RadGridLookup).ToString() & "';"
                        'Try
                        '    Dim ar()
                        '    ar = Me.SelectedText(Me.RadGridLookup).ToString().Split("-") ' code - description
                        '    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TxtTaskDescription').value = '" & ar(1).ToString().Trim() & "';"
                        'Catch ex As Exception
                        'End Try
                    Catch ex As Exception
                    End Try
                End If
            ElseIf Request.QueryString("form") = "atbsearch" Then

                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Client').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Division').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Product').value = '" & Me.PrdCode & "';"

                If Me.HiddenFieldLookupType.Value = "atb" Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_ATB').value = '" & Me.SelectedValue(Me.RadGridLookup).ToString() & "';"

                    If String.IsNullOrWhiteSpace(Me.CmpCode) = False Then

                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_HiddenField_Campaign').value = '" & Me.CampaignId & "';"
                        strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Campaign').value = '" & Me.CmpCode & "';"

                    End If

                ElseIf Me.HiddenFieldLookupType.Value = "campaign" Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_HiddenField_Campaign').value = '" & Me.SelectedValue(Me.RadGridLookup).ToString() & "';"
                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_TextBox_Campaign').value = '" & Me.CmpCode & "';"

                End If

                If _AutoSearch Then

                    strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_BtnSearch').click();"

                End If

            Else
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtClient').value = '" & Me.ClCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtDivision').value = '" & Me.DivCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtProduct').value = '" & Me.PrdCode & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJob').value ='" & JobNumber & "';"
                strScript &= "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtJobComp').value = '" & JobComponentNbr & "';"
            End If
            Try
                If Not dtInfo Is Nothing Then
                    dtInfo.Dispose()
                    dtInfo = Nothing
                End If
            Catch ex As Exception
            End Try
            Try
                If Not dtEst Is Nothing Then
                    dtEst.Dispose()
                    dtEst = Nothing
                End If
            Catch ex As Exception
            End Try
            Try
                If Not dtEstComp Is Nothing Then
                    dtEstComp.Dispose()
                    dtEstComp = Nothing
                End If
            Catch ex As Exception
            End Try

            Me.ControlsToSet = strScript
            Me.ControlsToSet &= Me.SetFocusToInput(Me._ControlId)

            Me.HiddenFieldControlsToSet.Value = Me.ControlsToSet

            ''Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValue", "<script>returnValue();</script>")
            Telerik.Web.UI.RadAjaxManager.GetCurrent(Me.Page).ResponseScripts.Add("returnValue();")

        Catch ex As Exception

            Me.ShowMessage(ex.Message.ToString())

        End Try
    End Sub
    Private Function FilterDataTableByPOVendor(ByVal DataTable As DataTable, ByVal ByJob As Boolean, ByVal ByComponent As Boolean, ByVal ByCampaign As Boolean) As DataTable

        'objects
        Dim DataView As System.Data.DataView = Nothing
        Dim EstimateRevisionDetails As Generic.List(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail) = Nothing
        Dim FilterString As String = ""

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            EstimateRevisionDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail)("exec [advsp_po_load_approved_est]").ToList.Where(Function(erd) erd.VendorCode = _VendorCode).ToList

            If ByJob Then

                FilterString = "Code IN (" & String.Join(",", EstimateRevisionDetails.Select(Function(erd) erd.JobNumber).Distinct.ToList) & ")"

            ElseIf ByComponent Then

                FilterString = "Code IN (" & String.Join(",", EstimateRevisionDetails.Select(Function(erd) "'" & erd.JobNumber & "-" & erd.JobComponentNumber & "'").Distinct.ToList) & ")"

            ElseIf ByCampaign Then

                FilterString = "Code IN (" & String.Join(",", EstimateRevisionDetails.Where(Function(erd) erd.CampaignID.HasValue).Select(Function(erd) erd.CampaignID.GetValueOrDefault(0)).Distinct.ToList) & ")"

            End If

        End Using

        DataView = New DataView(DataTable)

        If Not String.IsNullOrWhiteSpace(FilterString) Then

            DataView.RowFilter = FilterString

        End If

        FilterDataTableByPOVendor = DataView.ToTable

    End Function
    Private Function FilterDataTableByPOEstimate(ByVal DataTable As DataTable, ByVal ByJob As Boolean, ByVal ByComponent As Boolean) As DataTable

        'objects
        Dim DataView As System.Data.DataView = Nothing
        Dim FilterString As String = ""

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If ByJob Then

                FilterString = "Code IN (" & String.Join(",", AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext).Select(Function(eav) eav.JobNumber).Distinct.ToList) & ")"

            ElseIf ByComponent Then

                FilterString = "Code IN (" & String.Join(",", AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext).Select(Function(erd) "'" & erd.JobNumber & "-" & erd.JobComponentNumber & "'").Distinct.ToList) & ")"

            End If

        End Using

        DataView = New DataView(DataTable)

        If Not String.IsNullOrWhiteSpace(FilterString) Then

            DataView.RowFilter = FilterString

        End If

        FilterDataTableByPOEstimate = DataView.ToTable

    End Function

#End Region

End Class
