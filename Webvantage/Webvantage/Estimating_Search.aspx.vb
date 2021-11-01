Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel

Imports Webvantage.cGlobals
Imports Telerik.Web.UI

'Page looks for these querystring vars:
'PageMode = determines whether textboxes and submit buttons are enabled/disabled (allow edit or not)
'JobNum,JobCompNum 
'NewComp = determines whether this is a new component
Partial Public Class Estimating_Search
    Inherits Webvantage.BaseChildPage

#Region " Private vars: "

    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private EstNum As Integer = 0
    Private EstCompNum As Integer = 0
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private Campaign As String = ""
    Private rights As String
    Private _FromEstimateLookup As Boolean = False
    Private _LoadingDatasource As Boolean = False

#End Region

#Region " Page "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            SetPanelControls()

            If Not Me.IsPostBack And Not Me.IsCallback Then

                Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Estimating)
                CheckUserRights()

                Me.txtJob.Focus()

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()

                If qs.Get("backsearch") = "1" Or qs.Get("isbookmark") = "1" Then

                    Client = qs.ClientCode
                    Division = qs.DivisionCode
                    Product = qs.ProductCode
                    JobNum = qs.JobNumber
                    JobCompNum = qs.JobComponentNumber
                    EstNum = qs.EstimateNumber
                    EstCompNum = qs.EstimateComponentNumber

                    Me.txtClient.Text = Client
                    Me.txtDivision.Text = Division
                    Me.txtProduct.Text = Product

                    If JobNum > 0 Then

                        Me.txtJob.Text = JobNum

                    End If
                    If JobCompNum > 0 Then

                        Me.txtComponent.Text = JobCompNum

                    End If
                    If EstNum > 0 Then

                        Me.txtEstimate.Text = EstNum

                    End If
                    If EstCompNum > 0 Then

                        Me.txtEstimateComponent.Text = EstCompNum

                    End If

                End If

                Me._FromEstimateLookup = qs.Get("fromest") = "1"

            End If

            Me.MyUnityContextMenu.SetRadGrid(Me.RadGridEstimatingSearch)
            Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.Estimates}

            ''''If Not Session("CurrEstSearchClient") Is Nothing Then
            ''''    If Session("CurrEstSearchClient") <> "" Then
            ''''        Client = Session("CurrEstSearchClient")
            ''''        Me.txtClient.Text = Client
            ''''    End If
            ''''End If
            ''''If Not Session("CurrEstSearchDivision") Is Nothing Then
            ''''    If Session("CurrEstSearchDivision") <> "" Then
            ''''        Division = Session("CurrEstSearchDivision")
            ''''        Me.txtDivision.Text = Division
            ''''    End If
            ''''End If
            ''''If Not Session("CurrEstSearchProduct") Is Nothing Then
            ''''    If Session("CurrEstSearchProduct") <> "" Then
            ''''        Product = Session("CurrEstSearchProduct")
            ''''        Me.txtProduct.Text = Product
            ''''    End If
            ''''End If

            ''''If Not Session("CurrEstSearchJobNum") Is Nothing Then
            ''''    If IsNumeric(Session("CurrEstSearchJobNum")) Then
            ''''        If Session("CurrEstSearchJobNum") <> 0 Then
            ''''            JobNum = CType(Session("CurrEstSearchJobNum"), Integer)
            ''''            Me.txtJob.Text = JobNum
            ''''        End If
            ''''    End If
            ''''End If

            ''''If Not Session("CurrEstSearchJobCompNum") Is Nothing Then
            ''''    If IsNumeric(Session("CurrEstSearchJobCompNum")) Then
            ''''        If Session("CurrEstSearchJobCompNum") <> 0 Then
            ''''            JobCompNum = CType(Session("CurrEstSearchJobCompNum"), Integer)
            ''''            Me.txtComponent.Text = JobCompNum
            ''''        End If
            ''''    End If
            ''''End If

            ''''If Not Session("CurrEstSearchEstNum") Is Nothing Then
            ''''    If IsNumeric(Session("CurrEstSearchEstNum")) Then
            ''''        If Session("CurrEstSearchEstNum") <> 0 Then
            ''''            EstNum = CType(Session("CurrEstSearchEstNum"), Integer)
            ''''            Me.txtEstimate.Text = EstNum
            ''''        End If
            ''''    End If
            ''''End If

            ''''If Not Session("CurrEstSearchEstCompNum") Is Nothing Then
            ''''    If IsNumeric(Session("CurrEstSearchEstCompNum")) Then
            ''''        If Session("CurrEstSearchEstCompNum") <> 0 Then
            ''''            EstCompNum = CType(Session("CurrEstSearchEstCompNum"), Integer)
            ''''            Me.txtEstimateComponent.Text = EstCompNum
            ''''        End If
            ''''    End If
            ''''End If

            ''''Session("CurrEstSearchClient") = ""
            ''''Session("CurrEstSearchDivision") = ""
            ''''Session("CurrEstSearchProduct") = ""
            ''''Session("CurrEstSearchJobNum") = ""
            ''''Session("CurrEstSearchJobCompNum") = ""
            ''''Session("CurrEstSearchEstNum") = ""
            ''''Session("CurrEstSearchEstCompNum") = ""

        Catch ex As Exception

            Me.ShowMessage(ex.Message.ToString())

        End Try

    End Sub

    Protected Sub SetPanelControls()
        Try

            Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=estimatesearch&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=estimatesearch&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatesearchprod&type=product&office=&control=" & Me.txtProduct.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
            Me.hlEst.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatesearchjob&type=estimate&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            Me.hlEstComp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatesearchjob&type=estimatecomp&control=" & Me.txtEstimateComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.txtEstimate.ClientID & ".value);return false;")
            Me.hlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=estcampaignsearch&type=estcampaign&control=" & Me.txtCampaign.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")

            If Me.cbClosedJobs.Checked Then

                Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatesearchjc&type=estimatejobsearch&checked=1&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.txtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.txtEstimateComponent.ClientID & ".value);return false;")
                Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatesearchjc&type=estimatejobcompsearch&checked=1&control=" & Me.txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.txtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.txtEstimateComponent.ClientID & ".value);return false;")

            Else

                Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatesearchjc&type=estimatejobsearch&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.txtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.txtEstimateComponent.ClientID & ".value);return false;")
                Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatesearchjc&type=estimatejobcompsearch&control=" & Me.txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.txtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.txtEstimateComponent.ClientID & ".value);return false;")

            End If

        Catch ex As Exception
            'Me.ShowMessage(ex.Message.ToString())
            'Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

#End Region

#Region " Controls "
    Dim lab As System.Web.UI.WebControls.Label
    Private Sub RadGridEstimatingSearch_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEstimatingSearch.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = 0
        If Not e.Item Is Nothing Then
            index = e.Item.ItemIndex
        Else
            Exit Sub
        End If
        If index = -1 Then 'command item
            MiscFN.SavePageSize(Me.RadGridEstimatingSearch.ID, Me.RadGridEstimatingSearch.PageSize)
            Exit Sub
        End If
        Select Case e.CommandName
            Case "Detail"
                Dim esttemp As String
                Dim estcomptemp As String
                Dim jobtemp As String
                Dim jobcomptemp As String
                Dim clienttemp As String
                Dim divisiontemp As String
                Dim producttemp As String
                lab = e.Item.FindControl("lblEstNum")
                If lab.Text = "" Then
                    esttemp = 0
                Else
                    esttemp = lab.Text
                End If
                lab = e.Item.FindControl("lblEstComp")
                If lab.Text = "" Then
                    estcomptemp = 0
                Else
                    estcomptemp = lab.Text
                End If
                lab = e.Item.FindControl("lblJobNum")
                If lab.Text = "" Then
                    jobtemp = 0
                Else
                    jobtemp = lab.Text
                End If
                lab = e.Item.FindControl("lblJobComp")
                If lab.Text = "" Then
                    jobcomptemp = 0
                Else
                    jobcomptemp = lab.Text
                End If
                lab = e.Item.FindControl("lblClientCode")
                clienttemp = lab.Text
                lab = e.Item.FindControl("lblDivisionCode")
                divisiontemp = lab.Text
                lab = e.Item.FindControl("lblProductCode")
                producttemp = lab.Text

                Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
                If jobtemp <> "0" And jobtemp <> "&nbsp;" Then
                    If myVal.ValidateJobNumber(jobtemp) = False Then
                        Me.ShowMessage("This job does not exist!")
                        Exit Sub
                    End If
                End If
                If jobtemp <> "0" And jobtemp <> "&nbsp;" And jobcomptemp <> "0" And jobcomptemp <> "&nbsp;" Then
                    If myVal.ValidateJobCompNumber(jobtemp, jobcomptemp) = False Then
                        Me.ShowMessage("This is not a valid job/component!")
                        Exit Sub
                    End If
                    If myVal.ValidateJobCompIsViewable(Session("UserCode"), jobtemp, jobcomptemp) = False Then
                        Me.ShowMessage("Access to this job/comp is denied.")
                        Exit Sub
                    End If
                End If

                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), clienttemp, "", "") = False Then
                    Me.ShowMessage("Access to this client is denied.")
                    Exit Sub
                End If
                If divisiontemp <> "" Then
                    If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), clienttemp, divisiontemp, "") = False Then
                        Me.ShowMessage("Access to this division is denied.")
                        Exit Sub
                    End If
                End If
                If producttemp <> "" Then
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), clienttemp, divisiontemp, producttemp) = False Then
                        Me.ShowMessage("Access to this product is denied.")
                        Exit Sub
                    End If
                End If

                If (IsNumeric(jobtemp) = True AndAlso IsNumeric(jobcomptemp) = True) OrElse _FromEstimateLookup = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString
                    qs.Page = "Content.aspx"
                    qs.JobNumber = jobtemp
                    qs.JobComponentNumber = jobcomptemp
                    qs.EstimateNumber = esttemp
                    qs.EstimateComponentNumber = estcomptemp
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                    Me.OpenWindow(qs)

                Else

                    Me.OpenWindow("", "Estimating.aspx?EstNum=" & esttemp & "&EstComp=" & estcomptemp & "&newEst=edit")

                End If

            Case "Print"
                lab = e.Item.FindControl("lblEstNum")
                Dim esttemp As String = lab.Text
                lab = e.Item.FindControl("lblEstComp")
                Dim estcomptemp As String = lab.Text
                lab = e.Item.FindControl("lblJobNum")
                Dim jobtemp As String = lab.Text
                lab = e.Item.FindControl("lblJobComp")
                Dim jobcomptemp As String = lab.Text
                lab = e.Item.FindControl("lblClientCode")
                Dim clienttemp As String = lab.Text
                lab = e.Item.FindControl("lblDivisionCode")
                Dim divisiontemp As String = lab.Text
                lab = e.Item.FindControl("lblProductCode")
                Dim producttemp As String = lab.Text
                Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
                If myVal.ValidateJobNumber(jobtemp) = False Then
                    Me.ShowMessage("This job does not exist!")
                    Exit Sub
                End If
                If myVal.ValidateJobCompNumber(jobtemp, jobcomptemp) = False Then
                    Me.ShowMessage("This is not a valid job/component!")
                    Exit Sub
                End If
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), clienttemp, "", "") = False Then
                    Me.ShowMessage("Access to this client is denied.")
                    Exit Sub
                End If
                If divisiontemp <> "" Then
                    If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), clienttemp, divisiontemp, "") = False Then
                        Me.ShowMessage("Access to this division is denied.")
                        Exit Sub
                    End If
                End If
                If producttemp <> "" Then
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), clienttemp, divisiontemp, producttemp) = False Then
                        Me.ShowMessage("Access to this product is denied.")
                        Exit Sub
                    End If
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), jobtemp, jobcomptemp) = False Then
                    Me.ShowMessage("Access to this job/comp is denied.")
                    Exit Sub
                End If
                Me.OpenWindow("", "Estimating_Print.aspx?From=Est&EstNum=" & esttemp & "&EstComp=" & estcomptemp & "&JobNum=" & jobtemp & "&JobComp=" & jobcomptemp)
        End Select
    End Sub
    Dim labJT As System.Web.UI.WebControls.Label
    Private Sub RadGridEstimatingSearch_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEstimatingSearch.ItemDataBound
        Select Case e.Item.ItemType
            Case GridItemType.Header
            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                labJT = e.Item.FindControl("lblJobNum")
                If labJT.Text = "0" Then
                    labJT.Text = "&nbsp;"
                Else
                    labJT.Text = labJT.Text.PadLeft(6, "0")
                End If
                labJT = e.Item.FindControl("lblJobComp")
                If labJT.Text = "0" Then
                    labJT.Text = "&nbsp;"
                Else
                    labJT.Text = labJT.Text.PadLeft(2, "0")
                End If
                Dim imgbtn As System.Web.UI.WebControls.ImageButton
                'If rights = "N" Then
                '    imgbtn = e.Item.FindControl("butDetail")
                '    imgbtn.Visible = False
                'End If
        End Select
    End Sub

    Private Sub RadGridEstimatingSearch_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEstimatingSearch.NeedDataSource
        _LoadingDatasource = True
        Try
            Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
            Dim dr As New DataSet
            If Me.txtClient.Text <> "" Then
                Me.Client = Me.txtClient.Text
            End If
            If Me.txtDivision.Text <> "" Then
                Me.Division = Me.txtDivision.Text
            End If
            If Me.txtProduct.Text <> "" Then
                Me.Product = Me.txtProduct.Text
            End If
            If Me.txtEstimate.Text <> "" Then
                If IsNumeric(Me.txtEstimate.Text) = True Then
                    EstNum = CInt(Me.txtEstimate.Text)
                End If
            End If
            If Me.txtEstimateComponent.Text <> "" Then
                If IsNumeric(Me.txtEstimateComponent.Text) = True Then
                    EstCompNum = CInt(Me.txtEstimateComponent.Text)
                End If
            End If
            If Me.txtJob.Text <> "" Then
                If IsNumeric(Me.txtJob.Text) = True Then
                    JobNum = CInt(Me.txtJob.Text)
                End If
            End If
            If Me.txtComponent.Text <> "" Then
                If IsNumeric(Me.txtComponent.Text) = True Then
                    JobCompNum = CInt(Me.txtComponent.Text)
                End If
            End If
            If Me.txtCampaign.Text <> "" Then
                Me.Campaign = Me.txtCampaign.Text
            End If

            If Client = "" And Division = "" And Product = "" And EstNum = 0 And EstCompNum = 0 And JobNum = 0 And JobCompNum = 0 And Me.Campaign = "" Then
                dr.Tables.Add("Temp")
            Else
                dr = oEstimating.GetEstimatesForSearch(Session("UserCode"), Client, Division, Product, EstNum, EstCompNum, JobNum, JobCompNum, Campaign, Me.cbClosedJobs.Checked)
            End If

            Me.RadGridEstimatingSearch.DataSource = dr.Tables(0)

            Try
                If dr.Tables(0).Rows.Count = 1 Then
                    Try
                        If IsDBNull(dr.Tables(0).Rows(0)("JOB_NUMBER")) = False Then
                            JobNum = dr.Tables(0).Rows(0)("JOB_NUMBER")
                        End If
                    Catch ex As Exception
                        JobNum = 0
                    End Try
                    Try
                        If IsDBNull(dr.Tables(0).Rows(0)("JOB_COMPONENT_NBR")) = False Then
                            JobCompNum = dr.Tables(0).Rows(0)("JOB_COMPONENT_NBR")
                        End If
                    Catch ex As Exception
                        JobCompNum = 0
                    End Try

                    If JobNum > 0 AndAlso JobCompNum > 0 = True Then

                        Dim qs As New AdvantageFramework.Web.QueryString
                        qs.Page = "Content.aspx"
                        qs.JobNumber = JobNum
                        qs.JobComponentNumber = JobCompNum
                        qs.EstimateNumber = EstNum
                        qs.EstimateComponentNumber = EstCompNum
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                        Me.OpenWindow(qs)

                    Else

                        Me.OpenWindow("", "Estimating.aspx?EstNum=" & dr.Tables(0).Rows(0)("ESTIMATE_NUMBER") & "&EstComp=" & dr.Tables(0).Rows(0)("EST_COMPONENT_NBR") & "&newEst=edit")

                    End If

                End If
            Catch ex As Exception
            End Try

            Me.RadGridEstimatingSearch.CurrentPageIndex = Me.CurrentGridPageIndex
            Me.RadGridEstimatingSearch.PageSize = MiscFN.LoadPageSize(Me.RadGridEstimatingSearch.ID)

        Catch ex As Exception
        End Try
        _LoadingDatasource = False
    End Sub

    Private Sub RadToolbarEstimateSearch_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEstimateSearch.ButtonClick
        Select Case e.Item.Value
            Case "Print"

            Case "Search"
                If Me.ValidateSearch() = True Then
                    Me.RadGridEstimatingSearch.Rebind()
                End If
            Case "Clear"
                reset()
            Case "New"
                Me.OpenWindow("", "Estimating_AddNew.aspx")
        End Select
    End Sub

    Private Function ValidateSearch() As Boolean
        Try
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim cmp As cCampaign = New cCampaign(Session("ConnString"))
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            If Me.txtClient.Text <> "" Then
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text, "", "") = False Then
                    Me.ShowMessage("Access to this client is denied.")
                    Return False
                End If
            End If
            If Me.txtDivision.Text <> "" Then
                If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.txtClient.Text, Me.txtDivision.Text, "") = False Then
                    Me.ShowMessage("Access to this division is denied.")
                    Return False
                End If
            End If
            If Me.txtProduct.Text <> "" Then
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text) = False Then
                    Me.ShowMessage("Access to this product is denied.")
                    Return False
                End If
            End If
            If Me.txtJob.Text <> "" Then
                If myVal.ValidateJobNumber(Me.txtJob.Text) = False Then
                    Me.ShowMessage("This job does not exist!")
                    Return False
                End If
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, txtJob.Text)
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, txtJob.Text) = False AndAlso
                        AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                        Me.ShowMessage("Access to this job is denied.\n.")
                        Return False
                    End If
                End Using
            End If
            If Me.txtJob.Text = "" And Me.txtComponent.Text <> "" Then
                Me.ShowMessage("Please enter a Job Number!")
                Return False
            End If
            If Me.txtEstimate.Text = "" And Me.txtEstimateComponent.Text <> "" Then
                Me.ShowMessage("Please enter a Estimate Number!")
                Return False
            End If
            If Me.txtEstimate.Text <> "" Then
                If myVal.ValidateEstimateNumber(Me.txtEstimate.Text) = False Then
                    Me.ShowMessage("This estimate does not exist!")
                    reset()
                    Exit Function
                End If
                Dim drEst As SqlDataReader = est.CheckJobNumberEstimateDR(Me.txtEstimate.Text)
                If drEst.HasRows Then
                    drEst.Read()
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, drEst("JOB_NUMBER"))
                        If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, drEst("JOB_NUMBER")) = False AndAlso
                            AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                            Me.ShowMessage("Access to this Estimate is denied.\n.")
                            Return False
                        End If
                    End Using
                End If
                drEst.Close()
            End If
            If txtCampaign.Text <> "" Then
                If cmp.CampaignExists(txtCampaign.Text) = False Then
                    Me.ShowMessage("Invalid Campaign")
                    MiscFN.SetFocus(Me.txtCampaign)
                    Return False
                End If

                If myVal.ValidateCampaignIsViewable(Session("UserCode"), txtClient.Text, txtDivision.Text, txtProduct.Text, txtCampaign.Text) = False Then
                    Me.ShowMessage("Access to this campaign is denied.")
                    MiscFN.SetFocus(Me.txtCampaign)
                    Return False
                End If
            End If
            If Me.txtEstimate.Text <> "" And Me.txtEstimateComponent.Text <> "" Then
                If MiscFN.NumberInRange(Me.txtEstimate.Text, Me.txtEstimateComponent.Text) = False Then
                    Me.ShowMessage("Estimate and/or component number not in valid range!")
                    reset()
                    Return False
                Else
                    If myVal.ValidateEstimateCompNumber(Me.txtEstimate.Text, Me.txtEstimateComponent.Text) = False Then
                        Me.ShowMessage("This is not a valid Estimate/component!")
                        reset()
                        Return False
                    End If
                End If
            End If
            If Me.txtJob.Text <> "" And Me.txtComponent.Text <> "" Then
                If IsNumeric(Me.txtJob.Text) = False Or IsNumeric(Me.txtComponent.Text) = False Then
                    Me.ShowMessage("Job Number and Component must be valid numbers!")
                    Return False
                End If
                If myVal.ValidateJobCompNumber(Me.txtJob.Text, Me.txtComponent.Text) = False Then
                    Me.ShowMessage("This is not a valid job/component!")
                    Return False
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.txtJob.Text, Me.txtComponent.Text) = False Then
                    Me.ShowMessage("Access to this job/comp is denied.")
                    Return False
                End If
            End If

            Me.Client = Me.txtClient.Text
            Me.Division = Me.txtDivision.Text
            Me.Product = Me.txtProduct.Text

            If Me.txtJob.Text <> "" Then
                Me.JobNum = Convert.ToInt32(Me.txtJob.Text)
            End If
            If Me.txtComponent.Text <> "" Then
                Me.JobCompNum = Convert.ToInt32(Me.txtComponent.Text)
            End If
            If Me.txtEstimate.Text <> "" Then
                Me.EstNum = Convert.ToInt32(Me.txtEstimate.Text)
            End If
            If Me.txtEstimateComponent.Text <> "" Then
                Me.EstCompNum = Convert.ToInt32(Me.txtEstimateComponent.Text)
            End If
            Dim dr As SqlDataReader

            Session("CurrEstSearchClient") = ""
            Session("CurrEstSearchDivision") = ""
            Session("CurrEstSearchProduct") = ""
            Session("CurrEstSearchJobNum") = ""
            Session("CurrEstSearchJobCompNum") = ""
            Session("CurrEstSearchEstNum") = ""
            Session("CurrEstSearchEstCompNum") = ""
            Session("CurrEstSearchCampaign") = ""

            Dim OkayGo As Boolean = False
            If Me.EstNum > 0 And Me.EstCompNum > 0 Then
                OkayGo = True
            ElseIf Me.JobNum > 0 And Me.JobCompNum > 0 Then
                Try
                    dr = est.GetEstJob(Me.JobNum, Me.JobCompNum)
                    dr.Read()
                    If IsNumeric(dr("ESTIMATE_NUMBER")) = True And IsNumeric(dr("EST_COMPONENT_NBR")) = True Then
                        Me.EstNum = CType(dr("ESTIMATE_NUMBER"), Integer)
                        Me.EstCompNum = CType(dr("EST_COMPONENT_NBR"), Integer)
                        If Me.EstNum = 0 Then
                            OkayGo = False
                        Else
                            OkayGo = True
                        End If
                    Else
                        Me.EstNum = 0
                        Me.EstCompNum = 0
                        OkayGo = False
                    End If
                    dr.Close()
                Catch ex As Exception
                    OkayGo = False
                End Try
            Else
                OkayGo = False
            End If

            'If OkayGo = True Then
            '    Me.OpenWindow("", "Estimating.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&newEst=edit")
            'End If

            Return True

            'Return OkayGo

        Catch ex As Exception
            Me.ShowMessage("Search error")
        End Try

    End Function
#End Region

#Region " SubRoutines "

    Private Sub reset()
        Me.txtClient.Text = ""
        Me.txtDivision.Text = ""
        Me.txtProduct.Text = ""
        Me.txtJob.Text = ""
        Me.txtComponent.Text = ""
        Me.txtEstimate.Text = ""
        Me.txtEstimateComponent.Text = ""
        Me.txtCampaign.Text = ""
        Me.Client = ""
        Me.Division = ""
        Me.Product = ""
        Me.Campaign = ""
        Me.JobNum = 0
        Me.JobCompNum = 0
        Me.EstNum = 0
        Me.EstCompNum = 0

        Session("CurrEstSearchClient") = ""
        Session("CurrEstSearchDivision") = ""
        Session("CurrEstSearchProduct") = ""
        Session("CurrEstSearchJobNum") = ""
        Session("CurrEstSearchJobCompNum") = ""
        Session("CurrEstSearchEstNum") = ""
        Session("CurrEstSearchEstCompNum") = ""
        Session("CurrEstSearchCampaign") = ""
        Me.RadGridEstimatingSearch.MasterTableView.CurrentPageIndex = 0
        Me.RadGridEstimatingSearch.Rebind()
    End Sub

    Private Function GetEstimateData(ByVal EstNumber As Integer, ByVal EstComponentNumber As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer)
        Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim dt As DataTable
        If (EstNumber > 0 And EstComponentNumber > 0) Or (JobNumber > 0 And JobComponentNumber > 0) Then
            If JobNumber > 0 And JobComponentNumber > 0 Then
                If JobNumber <= 0 Then
                    Me.ShowMessage("Please enter a valid job number.")
                    reset()
                    Me.txtJob.Focus()
                    Exit Function
                End If
                If MiscFN.NumberInRange(JobNumber, JobComponentNumber) = False Then
                    Me.ShowMessage("Job and/or component number not in valid range!")
                    reset()
                    Exit Function
                Else
                    If myVal.ValidateJobNumber(JobNumber) = False Then
                        Me.ShowMessage("This job does not exist!")
                        reset()
                        Me.txtJob.Focus()
                        Exit Function
                    End If
                    If myVal.ValidateJobCompNumber(JobNumber, JobComponentNumber) = False Then
                        Me.ShowMessage("This is not a valid job/component!")
                        reset()
                        Exit Function
                    End If
                    'make sure user has access:
                    If myVal.ValidateJobCompIsViewable(Session("UserCode"), JobNumber, JobComponentNumber) = False Then
                        Me.ShowMessage("This job/comp is denied.")
                        reset()
                        Exit Function
                    End If
                End If
            ElseIf EstNumber > 0 And EstComponentNumber > 0 Then
                If EstNumber <= 0 Then
                    Me.ShowMessage("Please enter a valid Estimate number.")
                    reset()
                    Me.txtEstimate.Focus()
                    Exit Function
                End If
                If MiscFN.NumberInRange(EstNumber, EstComponentNumber) = False Then
                    Me.ShowMessage("Estimate and/or component number not in valid range!")
                    reset()
                    Exit Function
                Else
                    If myVal.ValidateEstimateNumber(EstNumber) = False Then
                        Me.ShowMessage("This estimate does not exist!")
                        reset()
                        Exit Function
                    End If
                    If myVal.ValidateEstimateCompNumber(EstNumber, EstComponentNumber) = False Then
                        Me.ShowMessage("This is not a valid Estimate/component!")

                        reset()
                        Exit Function
                    End If
                End If
            End If
        End If
        Try
            'Get data:
            dt = oEstimating.GetEstimateData(EstNumber, EstComponentNumber, JobNumber, JobComponentNumber, Session("UserCode"))
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                    Me.txtClient.Text = dt.Rows(0)("CL_CODE")
                End If
                If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                    Me.txtDivision.Text = dt.Rows(0)("DIV_CODE")
                End If
                If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                    Me.txtProduct.Text = dt.Rows(0)("PRD_CODE")
                End If
                If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                    Me.txtJob.Text = dt.Rows(0)("JOB_NUMBER")
                End If
                If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                    Me.txtComponent.Text = dt.Rows(0)("JOB_COMPONENT_NBR")
                End If
                If IsDBNull(dt.Rows(0)("ESTIMATE_NUMBER")) = False Then
                    Me.txtEstimate.Text = dt.Rows(0)("ESTIMATE_NUMBER")
                End If
                If IsDBNull(dt.Rows(0)("EST_COMPONENT_NBR")) = False Then
                    Me.txtEstimateComponent.Text = dt.Rows(0)("EST_COMPONENT_NBR")
                End If
            Else
                If JobNumber > 0 And JobComponentNumber > 0 Then
                    Me.OpenWindow("", "Estimating_AddNew.aspx?newEst=job&JobNum=" & JobNumber & "&JobComp=" & JobComponentNumber)
                End If
                reset()
            End If
            Return dt
        Catch ex As Exception
            Return ex.Message.ToString
        End Try

    End Function

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")

            If secView = "N" Then
                'rights = "N"
            End If
            If secEdit = "N" And secInsert = "N" Then
                Me.RadToolbarEstimateSearch.FindItemByValue("New").Enabled = False
            ElseIf secEdit = "Y" And secInsert = "N" Then
                Me.RadToolbarEstimateSearch.FindItemByValue("New").Enabled = False
            ElseIf secEdit = "N" And secInsert = "Y" Then

            End If


        Catch ex As Exception
        End Try
    End Sub

#End Region

    Private Sub BtnSearch_Click(sender As Object, e As System.EventArgs) Handles BtnSearch.Click
        If Me.ValidateSearch() = True Then
            Me.RadGridEstimatingSearch.Rebind()
        End If
    End Sub

    Private Property CurrentGridPageIndex As Integer = 0
    Private Sub RadGridEstimatingSearch_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridEstimatingSearch.PageIndexChanged
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridEstimatingSearch.Rebind()
    End Sub

    Private Sub RadGridEstimatingSearch_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridEstimatingSearch.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridEstimatingSearch.ID, e.NewPageSize)

        End If

        'Me.ValidateSearch()
    End Sub

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        If IsNumeric(RadGridEstimatingSearch.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")) = True AndAlso _
           IsNumeric(RadGridEstimatingSearch.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")) = True Then

            Me.MyUnityContextMenu.JobNumber = RadGridEstimatingSearch.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
            Me.MyUnityContextMenu.JobComponentNumber = RadGridEstimatingSearch.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")

        End If

    End Sub
End Class


