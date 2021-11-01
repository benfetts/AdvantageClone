Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI

Partial Public Class JobTemplate_Search
    Inherits Webvantage.BaseChildPage

    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private Closed As Boolean = False
    Private SalesCode As String = ""
    Private Office As String = ""
    Private SalesClass As String = ""
    Private AE As String = ""
    Private Campaign As String = ""
    Private taxflag As Boolean = False
    Private FromForm As Integer = 0 ' 1 = A loaded job, 2 = From a job level alert
    Private Level As Integer = 0 ' 1 = Job, 2 = component
    Private rights As String
    Private _DataSource As DataTable = Nothing
    Private _LoadingDatasource As Boolean = False



    Private Sub Page_Init2(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.SetPanelControls()
        If Me.IsClientPortal = True Then
            Me.TrOffice.Visible = False
            Me.TrClient.Visible = False
            Me.TrSalesClass.Visible = False
            Me.TrCampaign.Visible = False
            Me.TrAE.Visible = False
            Me.RadToolbarJobSearch.Items(2).Visible = False
            Me.RadToolbarJobSearch.Items(3).Visible = False
            Me.RadToolbarJobSearch.Items(6).Visible = False
            Me.RadToolbarJobSearch.Items(7).Visible = False
            Me.RadToolbarJobSearch.FindItemByValue("Bookmark").Visible = False
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.RadToolBarButtonUpdateAE.Enabled = False

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket)
            If Me.IsClientPortal = False Then
                Me.RadToolbarJobSearch.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks
            End If
            Try
                If Not Request.QueryString("f") Is Nothing Then
                    FromForm = CType(Request.QueryString("f"), Integer)
                End If
            Catch ex As Exception
                FromForm = 0
            End Try
            Try
                If Not Request.QueryString("l") Is Nothing Then
                    Level = CType(Request.QueryString("l"), Integer)
                End If
            Catch ex As Exception
                Level = 0
            End Try

            If FromForm = 1 Or FromForm = 2 Then
                Try
                    Me.JobNum = CType(Request.QueryString("j"), Integer)
                Catch ex As Exception
                    Me.JobNum = 0
                End Try
                Try
                    If FromForm = 1 Then
                        Me.JobCompNum = CType(Request.QueryString("jc"), Integer)
                    End If
                Catch ex As Exception
                    Me.JobCompNum = 0
                End Try
                Select Case Level
                    Case 0 'blank
                        Me.txtJob.Focus()
                    Case 1 'job
                        Me.txtJob.Text = ""
                        Me.txtComponent.Text = ""
                        Me.txtJob.Focus()
                    Case 2 'comp
                        If Me.JobNum > 0 Then
                            Me.txtJob.Text = Me.JobNum.ToString()
                            Me.txtComponent.Focus()
                        End If
                    Case Else
                        Me.txtJob.Focus()
                End Select

                Dim ts As New cTimeSheet(Session("ConnString"))
                If Me.JobNum > 0 Then
                    ts.GetJobInfo(Me.JobNum, , Me.Office, Me.Client, Me.Division, Me.Product, , , , , Me.SalesClass)
                End If

                Me.txtOffice.Text = Me.Office
                Me.txtClient.Text = Me.Client
                Me.txtDivision.Text = Me.Division
                Me.txtProduct.Text = Me.Product
                'Me.txtSalesClass.Text = Me.SalesClass

                If Level = 1 And Me.Client <> "" And Me.Division <> "" And Me.Product <> "" And Me.Office = "" Then
                    Me.Office = ts.GetOfficeCodeFromProduct(Me.Client, Me.Division, Me.Product)
                    Me.txtOffice.Text = Me.Office
                End If

                If FromForm = 2 Or FromForm = 1 Then

                    If Me.ValidateSearch() = True Then

                        Select Case Level
                            Case 1

                                Me.JobNum = 0
                                Me.JobCompNum = 0

                            Case 2

                                Me.JobCompNum = 0

                        End Select

                        Me.RadGridJobTemplateSearch.Rebind()

                    End If

                End If

            End If

            Try
                If Me.EnableBookmarks = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs = qs.FromCurrent()

                    If qs.Get("isbookmark") = "1" Then

                        If qs.OfficeCode <> "" Then
                            Me.txtOffice.Text = qs.OfficeCode
                        End If
                        If qs.ClientCode <> "" Then
                            Me.txtClient.Text = qs.ClientCode
                        End If
                        If qs.DivisionCode <> "" Then
                            Me.txtDivision.Text = qs.DivisionCode
                        End If
                        If qs.ProductCode <> "" Then
                            Me.txtProduct.Text = qs.ProductCode
                        End If
                        If qs.SalesClassCode <> "" Then
                            Me.txtSalesClass.Text = qs.SalesClassCode
                        End If
                        If qs.CampaignCode <> "" Then
                            Me.txtCampaign.Text = qs.CampaignCode
                        End If
                        If qs.JobNumber > 0 Then
                            Me.txtJob.Text = qs.JobNumber
                        End If
                        If qs.JobComponentNumber > 0 Then
                            Me.txtComponent.Text = qs.JobComponentNumber
                        End If
                        If qs.AccountExecutiveCode <> "" Then
                            Me.txtAE.Text = qs.AccountExecutiveCode
                        End If
                        If qs.Get("closedarchived").ToLower() = "true" Then
                            Me.cbClosedJobs.Checked = True
                        End If
                    End If
                    If Me.ValidateSearch() = True Then
                        Me.RadGridJobTemplateSearch.Rebind()
                    End If
                End If

            Catch ex As Exception
            End Try

        End If

        Me.MyUnityContextMenu.SetRadGrid(Me.RadGridJobTemplateSearch)
        'Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.JobJacket}

        Me.CheckUserRights()

    End Sub

    Protected Sub SetPanelControls()
        Try

            If Me.IsClientPortal = True Then
                Me.hlDivision.Attributes.Add("onclick", "ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobsearch&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
                Me.hlProduct.Attributes.Add("onclick", "ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=product&control=" & Me.txtProduct.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
                If Me.cbClosedJobs.Checked = True Then
                    Me.hlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtComponent.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=job&checked=1&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=&salesclass=');return false;")
                    Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=jobcompjj&checked=1&control=" & Me.txtComponent.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=&salesclass=');return false;")
                Else
                    Me.hlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtComponent.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=job&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=&salesclass=');return false;")
                    Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=jobcompjj&control=" & Me.txtComponent.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=&salesclass=');return false;")
                End If

                Me.txtDivision.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');")
                Me.txtProduct.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');")
                Me.txtJob.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtComponent.ClientID & "');")
            Else
                Me.hlClient.Attributes.Add("onclick", "ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID &
                                      "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');ClearTB('" & Me.txtCampaign.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobsearch&control=" &
                                      Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." &
                                      Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." &
                                      Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." &
                                      Me.txtOffice.ClientID & ".value);return false;")
                ''Me.hlClient.Attributes.Add("onclick", Me.HookUpLookUp("LookUp_Quick.aspx?calledfrom=custom&form=jobsearch&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value", "ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');", ""))
                ''Me.hlClient.Attributes.Add("onclick", Me.HookUpLookUp("LookUp_Quick.aspx"))

                Me.hlDivision.Attributes.Add("onclick", "ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');ClearTB('" & Me.txtCampaign.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobsearch&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
                Me.hlProduct.Attributes.Add("onclick", "ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');ClearTB('" & Me.txtCampaign.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=product&control=" & Me.txtProduct.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
                If Me.cbClosedJobs.Checked = True Then
                    Me.hlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=job&checked=1&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
                    Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=jobcompjj&checked=1&control=" & Me.txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
                Else
                    Me.hlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
                    Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=jobcompjj&control=" & Me.txtComponent.ClientID & "&sbid=" & Me.RadToolBarButtonSearch.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
                End If
                Me.hlOffice.Attributes.Add("onclick", "ClearTB('" & Me.txtClient.ClientID & "');ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');ClearTB('" & Me.txtCampaign.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacketnew&control=" & Me.txtOffice.ClientID & "&type=office&ddtype=client');return false;")
                Me.hlAE.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobsearch&control=" & Me.txtAE.ClientID & "&type=accountexec&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=&jobcomp=');return false;")
                Me.hlSalesClass.Attributes.Add("onclick", "ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtCampaign.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobsearch&control=" & Me.txtSalesClass.ClientID & "&type=salesclass');return false;")
                'Me.hlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtCampaign.ClientID & "&type=campaignfilterjob&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=&jobcomp=');return false;")
                Me.hlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=jobcmpsearch&type=campaign&control=" & Me.txtCampaign.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&cmpID=' + document.forms[0]." & Me.hfCampaignID.ClientID & ".value);return false;")

                Me.txtOffice.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtClient.ClientID & "');ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');ClearTB('" & Me.txtCampaign.ClientID & "');")
                Me.txtClient.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');ClearTB('" & Me.txtCampaign.ClientID & "');")
                Me.txtDivision.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');ClearTB('" & Me.txtCampaign.ClientID & "');")
                Me.txtProduct.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtSalesClass.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');ClearTB('" & Me.txtCampaign.ClientID & "');")
                Me.txtJob.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');")
                Me.txtSalesClass.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtCampaign.ClientID & "');")
            End If

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub cbClosedJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbClosedJobs.CheckedChanged
        Try
            If Me.cbClosedJobs.Checked = True Then
                Me.hlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=job&checked=1&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
                Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=jobcompjj&checked=1&control=" & Me.txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
            Else
                Me.hlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtComponent.ClientID & "');ClearTB('" & Me.txtAE.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
                Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobsearch&type=jobcompjj&control=" & Me.txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value);return false;")
            End If
        Catch ex As Exception
            ' Me.LblMSG.Text = ex.Message.ToString()
        End Try
    End Sub

    Private ClearFilter As Boolean = False
    Private RowCount As Integer = 0

    Private Sub RadToolbarJobSearch_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarJobSearch.ButtonClick
        Select Case e.Item.Value
            Case "Print"

                If SearchIsValid() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    Me.SetupQueryString(qs)
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

                    Me.OpenPrintSendSilently(qs)

                End If

            Case "SendAlert"

                If SearchIsValid() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    Me.SetupQueryString(qs)
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                    Me.OpenPrintSendSilently(qs)

                End If

            Case "SendAssignment"

                If SearchIsValid() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    Me.SetupQueryString(qs)
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

                    Me.OpenPrintSendSilently(qs)

                End If

            Case "SendEmail"

                If SearchIsValid() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    Me.SetupQueryString(qs)
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)

                    Me.OpenPrintSendSilently(qs)

                End If

            Case "PrintSendOptions"

                If SearchIsValid() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    Me.SetupQueryString(qs)
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                    Me.OpenWindow(qs)

                End If

            Case "Search"

                If Me.ValidateSearch() = True Then Me.RadGridJobTemplateSearch.Rebind()

                If Me.txtClient.Text <> "" And Me.txtDivision.Text <> "" And Me.txtProduct.Text <> "" Then
                    Me.RadToolBarButtonUpdateAE.Enabled = True
                Else
                    Me.RadToolBarButtonUpdateAE.Enabled = False
                End If

            Case "Clear"

                Me.txtClient.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtJob.Text = ""
                Me.txtComponent.Text = ""
                Me.txtOffice.Text = ""
                Me.txtSalesClass.Text = ""
                Me.txtAE.Text = ""
                Me.txtCampaign.Text = ""
                Me.cbClosedJobs.Checked = False
                Me.Client = ""
                Me.Division = ""
                Me.Product = ""
                Me.JobNum = 0
                Me.JobCompNum = 0
                Me.Office = ""
                Me.SalesClass = ""
                Me.AE = ""
                Me.Campaign = ""
                Me.SetPanelControls()

                If Me.IsClientPortal = True Then

                    Session("CurrClient") = Session("CL_CODE")
                    Me.Client = Session("CL_CODE")
                    Me.txtClient.Text = Session("CL_CODE")
                    Me.TrOffice.Visible = False
                    Me.TrClient.Visible = False
                    Me.TrSalesClass.Visible = False
                    Me.TrCampaign.Visible = False
                    Me.TrAE.Visible = False

                End If

                Me.ClearFilter = True
                Me.RadGridJobTemplateSearch.MasterTableView.CurrentPageIndex = 0
                Me.RadGridJobTemplateSearch.Rebind()

                Me.RadToolBarButtonUpdateAE.Enabled = False

            Case "New"

                Me.OpenWindow("", "JobTemplate_New.aspx?from=search&client=" & Me.txtClient.Text & "&division=" & Me.txtDivision.Text & "&product=" & Me.txtProduct.Text & "&salesclass=" & Me.txtSalesClass.Text & "&ae=" & Me.txtAE.Text & "&campcode=" & Me.txtCampaign.Text & "&campid=" & Me.hfCampaignID.Value)

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                With qs
                    .OfficeCode = Me.txtOffice.Text
                    .ClientCode = Me.txtClient.Text
                    .DivisionCode = Me.txtDivision.Text
                    .ProductCode = Me.txtProduct.Text
                    .SalesClassCode = Me.txtSalesClass.Text
                    .CampaignCode = Me.txtCampaign.Text
                    If IsNumeric(Me.txtJob.Text) = True Then
                        .JobNumber = Me.txtJob.Text
                    End If
                    If IsNumeric(Me.txtComponent.Text) = True Then
                        .JobComponentNumber = Me.txtComponent.Text
                    End If
                    .AccountExecutiveCode = Me.txtAE.Text
                    .Add("closedarchived", Me.cbClosedJobs.Checked.ToString())
                    .Add("isbookmark", "1")
                    .Build()
                End With

                'qs = qs.FromCurrent()

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_JobJacket
                    .UserCode = Session("UserCode")
                    '.Name = "Alert: " & Me.CurrentAlertID & " " & Me.TxtSubject.Text
                    .Name = "Custom Job search"
                    .PageURL = "JobTemplate_Search.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                Else
                    Me.RefreshBookmarksDesktopObject()
                End If

            Case "UpdateAE"

                Session("JT_FIND_REPLACE_COMPONENTS") = Nothing

                RowCount = Me.RadGridJobTemplateSearch.MasterTableView.Items.Count
                Dim SbJobCompList As New System.Text.StringBuilder
                Dim JobString As String = Nothing

                Dim dt As New DataTable
                Dim jobtemp As Job_Template = New Job_Template(Session("ConnString"))
                Try
                    Me.Client = txtClient.Text
                    Me.Division = txtDivision.Text
                    Me.Product = txtProduct.Text
                    If txtJob.Text <> "" Then
                        Me.JobNum = Convert.ToInt32(txtJob.Text)
                    End If
                    If txtComponent.Text <> "" Then
                        Me.JobCompNum = Convert.ToInt32(txtComponent.Text)
                    End If
                    Me.Closed = Me.cbClosedJobs.Checked
                    Me.Office = Me.txtOffice.Text
                    Me.SalesClass = Me.txtSalesClass.Text
                    Me.AE = Me.txtAE.Text
                    Me.Campaign = Me.txtCampaign.Text

                    If JobNum = 0 And JobCompNum = 0 Then
                        dt = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), Client, Division, Product, "", "", Office, SalesClass, AE, Closed, Campaign, Me.IsClientPortal, Session("UserID"))
                    ElseIf JobNum > 0 And JobCompNum = 0 Then
                        dt = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), Client, Division, Product, JobNum, "", Office, SalesClass, AE, Closed, Campaign, Me.IsClientPortal, Session("UserID"))
                    Else
                        dt = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), Client, Division, Product, JobNum, JobCompNum, Office, SalesClass, AE, Closed, Campaign, Me.IsClientPortal, Session("UserID"))
                    End If
                Catch ex As Exception
                    dt = Nothing
                End Try

                If dt.Rows.Count > 0 Then

                    JobString = String.Join("|", (From DataRow In dt.Rows.OfType(Of System.Data.DataRow)
                                                  Select DataRow("JOB_NUMBER").ToString & "," & DataRow("JOB_COMPONENT_NBR").ToString).ToArray)

                    Session("JT_FIND_REPLACE_COMPONENTS") = JobString

                End If

                If RowCount > 0 Then
                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridJobTemplateSearch.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim CurrentJobNumber As Integer = 0
                            Dim CurrentJobComponentNumber As Integer = 0
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try

                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                    'Do stuff with each row
                                    With SbJobCompList
                                        .Append(CurrentJobNumber.ToString())
                                        .Append(",")
                                        .Append(CurrentJobComponentNumber.ToString())
                                        .Append("|")
                                    End With
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    Dim StrURL As String = "JobTemplate_Update.aspx?update=AE&Components=" & MiscFN.RemoveTrailingDelimiter(SbJobCompList.ToString(), "|") '"JobJacket/UpdateJobs?wm=1&Components=" & MiscFN.RemoveTrailingDelimiter(SbJobCompList.ToString(), "|") ' & sbQueryString.ToString
                    'If SbJobCompList.ToString <> "" Then
                    Me.OpenWindow("", StrURL, 200, 500, False, True)
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerScheduler, "FandRWindow", "Search and Replace", StrURL, 285, 645, False)
                    'Else
                    'Me.ShowMessage("No rows selected.")
                    'End If
                End If


            Case "UpdateAlertGroup"

                Session("JT_FIND_REPLACE_COMPONENTS") = Nothing

                RowCount = Me.RadGridJobTemplateSearch.MasterTableView.Items.Count
                Dim SbJobCompList As New System.Text.StringBuilder
                Dim DataTable As DataTable = Nothing
                Dim JobString As String = Nothing

                Dim dt As New DataTable
                Dim jobtemp As Job_Template = New Job_Template(Session("ConnString"))
                Try
                    Me.Client = txtClient.Text
                    Me.Division = txtDivision.Text
                    Me.Product = txtProduct.Text
                    If txtJob.Text <> "" Then
                        Me.JobNum = Convert.ToInt32(txtJob.Text)
                    End If
                    If txtComponent.Text <> "" Then
                        Me.JobCompNum = Convert.ToInt32(txtComponent.Text)
                    End If
                    Me.Closed = Me.cbClosedJobs.Checked
                    Me.Office = Me.txtOffice.Text
                    Me.SalesClass = Me.txtSalesClass.Text
                    Me.AE = Me.txtAE.Text
                    Me.Campaign = Me.txtCampaign.Text

                    If JobNum = 0 And JobCompNum = 0 Then
                        dt = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), Client, Division, Product, "", "", Office, SalesClass, AE, Closed, Campaign, Me.IsClientPortal, Session("UserID"))
                    ElseIf JobNum > 0 And JobCompNum = 0 Then
                        dt = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), Client, Division, Product, JobNum, "", Office, SalesClass, AE, Closed, Campaign, Me.IsClientPortal, Session("UserID"))
                    Else
                        dt = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), Client, Division, Product, JobNum, JobCompNum, Office, SalesClass, AE, Closed, Campaign, Me.IsClientPortal, Session("UserID"))
                    End If
                Catch ex As Exception
                    dt = Nothing
                End Try

                If dt.Rows.Count > 0 Then

                    JobString = String.Join("|", (From DataRow In dt.Rows.OfType(Of System.Data.DataRow)
                                                  Select DataRow("JOB_NUMBER").ToString & "," & DataRow("JOB_COMPONENT_NBR").ToString).ToArray)

                    Session("JT_FIND_REPLACE_COMPONENTS") = JobString

                End If

                If RowCount > 0 Then
                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridJobTemplateSearch.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim CurrentJobNumber As Integer = 0
                            Dim CurrentJobComponentNumber As Integer = 0
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try

                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                    'Do stuff with each row
                                    With SbJobCompList
                                        .Append(CurrentJobNumber.ToString())
                                        .Append(",")
                                        .Append(CurrentJobComponentNumber.ToString())
                                        .Append("|")
                                    End With
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    Dim StrURL As String = "JobTemplate_Update.aspx?update=AG&Components=" & MiscFN.RemoveTrailingDelimiter(SbJobCompList.ToString(), "|") '"JobJacket/UpdateJobs?wm=1&Components=" & MiscFN.RemoveTrailingDelimiter(SbJobCompList.ToString(), "|") ' & sbQueryString.ToString
                    'If SbJobCompList.ToString <> "" Then
                    Me.OpenWindow("", StrURL, 200, 500, False, True)
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerScheduler, "FandRWindow", "Search and Replace", StrURL, 285, 645, False)
                    'Else
                    'Me.ShowMessage("No rows selected.")
                    'End If
                End If


        End Select
    End Sub

    Private Function SearchIsValid() As Boolean

        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        If Me.txtOffice.Text <> "" Then
            If myVal.ValidateOffice(Me.txtOffice.Text, True) = False Then
                Me.ShowMessage("Invalid Office!")
                Return False
            End If
        End If
        If Me.txtJob.Text <> "" Then
            If myVal.ValidateJobNumber(txtJob.Text) = False Then
                Me.ShowMessage("This job does not exist")
                Return False
            End If
        End If
        If txtJob.Text <> "" And txtComponent.Text <> "" Then
            If myVal.ValidateJobCompNumber(txtJob.Text, txtComponent.Text) = False Then
                Me.ShowMessage("This is not a valid job/component")
                Return False
            End If
        End If
        If txtClient.Text <> "" Then
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), txtClient.Text, "", "") = False Then
                Me.ShowMessage("Access to this client is denied")
                Return False
            End If
        End If
        If txtDivision.Text <> "" Then
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), txtClient.Text, txtDivision.Text, "") = False Then
                Me.ShowMessage("Access to this division is denied")
                Return False
            End If
        End If
        If txtProduct.Text <> "" Then
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), txtClient.Text, txtDivision.Text, txtProduct.Text) = False Then
                Me.ShowMessage("Access to this product is denied")
                Return False
            End If
        End If
        If txtJob.Text <> "" And txtComponent.Text <> "" Then
            If myVal.ValidateJobCompIsViewable(Session("UserCode"), txtJob.Text, txtComponent.Text) = False Then
                Me.ShowMessage("Access to this job/comp is denied")
                Return False
            End If
        End If
        If txtClient.Text <> "" And txtDivision.Text <> "" And txtProduct.Text <> "" And txtJob.Text <> "" And txtComponent.Text <> "" Then
            If myVal.ValidateCDPJCIsViewable(txtClient.Text, txtDivision.Text, txtProduct.Text, txtJob.Text, txtComponent.Text) = False Then
                Me.ShowMessage("This Job/Comp does not exist for selected Client/Division/Product.")
                Return False
            End If
        End If
        If Me.txtSalesClass.Text <> "" Then
            If myVal.ValidateSalesClassCode(Me.txtSalesClass.Text, True) = False Then
                Me.ShowMessage("Invalid Sales Class.")
                Return False
            End If
        End If
        If Me.txtCampaign.Text <> "" Then
            If myVal.ValidateCampaignFilter(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.txtCampaign.Text.Trim) = False Then
                Me.ShowMessage("Campaign invalid")
                Return False
            End If
            If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.txtCampaign.Text.Trim) = False Then
                Me.ShowMessage("Access to this campaign is denied")
                Return False
            End If
        End If
        If Me.txtAE.Text <> "" Then
            If myVal.ValidateEmpCode(Me.txtAE.Text) = False Then
                Me.ShowMessage("Invalid Account Executive.")
                Return False
            End If
        End If

        Return True

    End Function
    Private Sub SetupQueryString(ByRef qs As AdvantageFramework.Web.QueryString)

        qs.Page = "JobTemplate_Print.aspx"

        Dim count As Integer = 0
        Dim jobcompids As String = ""

        RowCount = Me.RadGridJobTemplateSearch.MasterTableView.Items.Count

        Session("ProjectScheduleJobCompIDS") = ""

        If RowCount > 0 Then

            For i As Integer = 0 To RowCount - 1
                Try
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridJobTemplateSearch.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                    Dim chk As CheckBox
                    chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                    If chk.Checked = True Then
                        count += 1
                        Dim CurrentJobNumber As Integer = 0
                        Try
                            CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                        Catch ex As Exception
                            CurrentJobNumber = 0
                        End Try
                        Dim CurrentJobComponentNumber As Integer = 0
                        Try
                            CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                        Catch ex As Exception
                            CurrentJobComponentNumber = 0
                        End Try
                        If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                            jobcompids &= CurrentJobNumber & "/" & CurrentJobComponentNumber & ","
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next

            Session("ProjectScheduleJobCompCount") = count
            Session("ProjectScheduleJobCompIDS") = jobcompids

        End If

        Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))

        If Me.txtJob.Text <> "" And Me.txtComponent.Text = "" And Session("ProjectScheduleJobCompIDS") = "" Then

            Dim JobsList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobsList = AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext).ToList.Where(Function(JobComponent) JobComponent.JobNumber = CInt(Me.txtJob.Text)).ToList

                For Each JobComponent In JobsList

                    jobcompids &= JobComponent.JobNumber & "/" & JobComponent.Number & ","
                    count += 1

                Next

                Session("ProjectScheduleJobCompIDS") = jobcompids
                Session("ProjectScheduleJobCompCount") = count

            End Using

            If count = 1 Then

                Dim jc() As String = jobcompids.Split("/")
                Dim j As String = jc(0)
                Dim c As String = MiscFN.RemoveTrailingDelimiter(jc(1), ",")

                Session("ProjectScheduleJobCompIDS") = ""

                qs.ClientCode = Me.txtClient.Text
                qs.DivisionCode = Me.txtDivision.Text
                qs.ProductCode = Me.txtProduct.Text
                qs.JobNumber = j
                qs.JobComponentNumber = c

                qs.Add("fromapp", "jobsearch")
                qs.Add("client", Me.txtClient.Text)
                qs.Add("division", Me.txtDivision.Text)
                qs.Add("product", Me.txtProduct.Text)

                ''''''Me.OpenWindow("", "JobTemplate_Print.aspx?client=" & txtClient.Text & "&division=" & txtDivision.Text & "&product=" & txtProduct.Text & "&job=" & j & "&jobcomp=" & c & "&fromapp=jobsearch")

            Else

                qs.Add("fromapp", "jobsearchmul")
                '''''''Me.OpenWindow("", "JobTemplate_Print.aspx?fromapp=jobsearchmul")

            End If
        ElseIf Session("ProjectScheduleJobCompIDS") <> "" Then

            If count = 1 Then

                Dim jc() As String = Session("ProjectScheduleJobCompIDS").Split("/")
                Dim j As String = jc(0)
                Dim c As String = MiscFN.RemoveTrailingDelimiter(jc(1), ",")

                Session("ProjectScheduleJobCompIDS") = ""

                qs.ClientCode = Me.txtClient.Text
                qs.DivisionCode = Me.txtDivision.Text
                qs.ProductCode = Me.txtProduct.Text
                qs.JobNumber = j
                qs.JobComponentNumber = c

                qs.Add("fromapp", "jobsearch")
                qs.Add("client", Me.txtClient.Text)
                qs.Add("division", Me.txtDivision.Text)
                qs.Add("product", Me.txtProduct.Text)

                ''''''Me.OpenWindow("", "JobTemplate_Print.aspx?client=" & txtClient.Text & "&division=" & txtDivision.Text & "&product=" & txtProduct.Text & "&job=" & j & "&jobcomp=" & c & "&fromapp=jobsearch")

            Else

                qs.Add("fromapp", "jobsearchmul")
                ''''''Me.OpenWindow("", "JobTemplate_Print.aspx?fromapp=jobsearchmul")

            End If

        ElseIf Me.txtJob.Text = "" And Me.txtComponent.Text = "" And Session("ProjectScheduleJobCompIDS") = "" Then

            Me.ShowMessage("No jobs selected to print.")
            Exit Sub

        Else

            qs.ClientCode = Me.txtClient.Text
            qs.DivisionCode = Me.txtDivision.Text
            qs.ProductCode = Me.txtProduct.Text
            qs.JobNumber = Me.txtJob.Text
            qs.JobComponentNumber = Me.txtComponent.Text

            '' '' ''Me.OpenWindow("", "JobTemplate_Print.aspx?client=" & txtClient.Text & "&division=" & txtDivision.Text & "&product=" & _
            '' '' ''                              txtProduct.Text & "&job=" & txtJob.Text & "&jobcomp=" & txtComponent.Text & "&fromapp=jobsearch")

        End If

    End Sub

#Region " Radgrid "

    Dim lab As System.Web.UI.WebControls.Label
    Private Sub RadGridJobTemplateSearch_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobTemplateSearch.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = 0
        If Not e.Item Is Nothing Then
            index = e.Item.ItemIndex
        Else
            Exit Sub
        End If
        If index = -1 Then 'command item
            MiscFN.SavePageSize(Me.RadGridJobTemplateSearch.ID, Me.RadGridJobTemplateSearch.PageSize)
            Exit Sub
        End If
        Select Case e.CommandName
            Case "Detail"
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
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), clienttemp, "", "") = False Then
                    Me.ShowMessage("Access to this client is denied")
                    Exit Sub
                End If
                If divisiontemp <> "" Then
                    If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), clienttemp, divisiontemp, "") = False Then
                        Me.ShowMessage("Access to this division is denied")
                        Exit Sub
                    End If
                End If
                If producttemp <> "" Then
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), clienttemp, divisiontemp, producttemp) = False Then
                        Me.ShowMessage("Access to this product is denied")
                        Exit Sub
                    End If
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), jobtemp, jobcomptemp) = False Then
                    Me.ShowMessage("Access to this job/comp is denied")
                    Exit Sub
                End If

                Dim qs As New AdvantageFramework.Web.QueryString
                qs.Page = "Content.aspx"
                qs.JobNumber = jobtemp
                qs.JobComponentNumber = jobcomptemp
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate

                Me.OpenWindow(qs)

            Case "Print"
                Session("ProjectScheduleJobCompIDS") = ""
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
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), clienttemp, "", "") = False Then
                    Me.ShowMessage("Access to this client is denied")
                    Exit Sub
                End If
                If divisiontemp <> "" Then
                    If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), clienttemp, divisiontemp, "") = False Then
                        Me.ShowMessage("Access to this division is denied")
                        Exit Sub
                    End If
                End If
                If producttemp <> "" Then
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), clienttemp, divisiontemp, producttemp) = False Then
                        Me.ShowMessage("Access to this product is denied")
                        Exit Sub
                    End If
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), jobtemp, jobcomptemp) = False Then
                    Me.ShowMessage("Access to this job/comp is denied")
                    Exit Sub
                End If
                Me.OpenWindow("", "JobTemplate_Print.aspx?client=" & clienttemp & "&division=" & divisiontemp & "&product=" & producttemp & "&job=" & jobtemp & "&jobcomp=" & jobcomptemp & "&fromapp=jobsearch")
        End Select
    End Sub

    Dim labJT As System.Web.UI.WebControls.Label
    Private Sub RadGridJobTemplateSearch_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobTemplateSearch.ItemDataBound
        Select Case e.Item.ItemType
            Case GridItemType.Header
            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                labJT = e.Item.FindControl("lblJobNum")
                labJT.Text = labJT.Text.PadLeft(6, "0")
                labJT = e.Item.FindControl("lblJobComp")
                labJT.Text = labJT.Text.PadLeft(3, "0")

                Dim imgbtn As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImgBtnPrint")
                If Me.IsClientPortal = True Then
                    imgbtn.Visible = False
                End If
        End Select
    End Sub
    Private Property CurrentGridPageIndex As Integer = 0
    Private Sub RadGridJobTemplateSearch_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobTemplateSearch.NeedDataSource
        Dim jobtemp As Job_Template = New Job_Template(Session("ConnString"))
        Dim dt As New DataTable

        _LoadingDatasource = True

        Try
            If (Office = "" And Client = "" And Division = "" And Product = "" _
                And JobNum = 0 And JobCompNum = 0 And SalesClass = "" And AE = "" And Campaign = "" _
                And Me.Page.IsPostBack = False) Or Me.ClearFilter = True Then
                Me.ClearFilter = False
            ElseIf JobNum = 0 And JobCompNum = 0 Then
                dt = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), Client, Division, Product, "", "", Office, SalesClass, AE, Closed, Campaign, Me.IsClientPortal, Session("UserID"))
            ElseIf JobNum > 0 And JobCompNum = 0 Then
                dt = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), Client, Division, Product, JobNum, "", Office, SalesClass, AE, Closed, Campaign, Me.IsClientPortal, Session("UserID"))
            Else
                dt = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), Client, Division, Product, JobNum, JobCompNum, Office, SalesClass, AE, Closed, Campaign, Me.IsClientPortal, Session("UserID"))
            End If
        Catch ex As Exception
            dt = Nothing
        End Try

        If dt Is Nothing Then Exit Sub

        Me.RadGridJobTemplateSearch.DataSource = dt

        Try

            If dt.Rows.Count = 1 Then
                'go
                Session("ProjectScheduleJobCompIDS") = ""
                Dim qs As New AdvantageFramework.Web.QueryString
                qs.Page = "Content.aspx"
                qs.JobNumber = dt.Rows(0)("JOB_NUMBER")
                qs.JobComponentNumber = dt.Rows(0)("JOB_COMPONENT_NBR")
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate

                Me.OpenWindow(qs)

            End If
        Catch ex As Exception

        End Try

        Me.RadGridJobTemplateSearch.CurrentPageIndex = Me.CurrentGridPageIndex
        Me.RadGridJobTemplateSearch.PageSize = MiscFN.LoadPageSize(Me.RadGridJobTemplateSearch.ID)
        If Me.txtClient.Text <> "" And Me.txtDivision.Text <> "" And Me.txtProduct.Text <> "" Then
            Me.RadToolBarButtonUpdateAE.Enabled = True
        Else
            Me.RadToolBarButtonUpdateAE.Enabled = False
        End If

        _LoadingDatasource = False

    End Sub

    Private Sub RadGridJobTemplateSearch_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridJobTemplateSearch.PageIndexChanged
        Me.Client = Me.txtClient.Text
        Me.Division = Me.txtDivision.Text
        Me.Product = Me.txtProduct.Text
        If Me.txtJob.Text <> "" Then
            Me.JobNum = Convert.ToInt32(Me.txtJob.Text)
        End If
        If Me.txtComponent.Text <> "" Then
            Me.JobCompNum = Convert.ToInt32(Me.txtComponent.Text)
        End If
        Me.Closed = Me.cbClosedJobs.Checked
        Me.Office = Me.txtOffice.Text
        Me.SalesClass = Me.txtSalesClass.Text
        Me.AE = Me.txtAE.Text
        Me.Campaign = Me.txtCampaign.Text
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridJobTemplateSearch.Rebind()
    End Sub

#End Region

    Private Function ValidateSearch() As Boolean
        Try
            If Me.IsClientPortal = True Then
                Session("CurrClient") = Session("CL_CODE")
                Me.Client = Session("CL_CODE")
                Me.txtClient.Text = Session("CL_CODE")
            End If
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim jc As New Job(Session("Connstring"))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing

            If txtJob.Text <> "" Then

                If myVal.ValidateJobNumber(txtJob.Text) = False Then
                    Me.ShowMessage("This job does not exist")
                    Return False
                End If

                If Me.IsClientPortal = False Then
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, txtJob.Text)
                        If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, txtJob.Text) = False AndAlso
                            AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                            Me.ShowMessage("Access to this job is denied.\n")
                            Return False
                        End If
                    End Using
                End If

            End If
            If txtJob.Text = "" And txtComponent.Text <> "" Then
                Me.ShowMessage("Please enter a Job Number")
                Return False
            End If
            If txtJob.Text <> "" And txtComponent.Text <> "" Then
                If IsNumeric(txtJob.Text) = False Or IsNumeric(txtComponent.Text) = False Then
                    Me.ShowMessage("Job Number and Component must be valid numbers")
                    Return False
                End If
                If myVal.ValidateJobCompNumber(txtJob.Text, txtComponent.Text) = False Then
                    Me.ShowMessage("This is not a valid job/component")
                    Return False
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), txtJob.Text, txtComponent.Text) = False Then
                    Me.ShowMessage("Access to this job/comp is denied")
                    Return False
                End If
            End If
            If Me.txtOffice.Text <> "" Then
                If myVal.ValidateOffice(Me.txtOffice.Text, True) = False Then
                    Me.ShowMessage("Invalid Office")
                    Return False
                End If
            End If
            If txtClient.Text <> "" Then
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), txtClient.Text, "", "") = False Then
                    Me.ShowMessage("Access to this client is denied")
                    Return False
                End If
            End If
            If txtDivision.Text <> "" Then
                If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), txtClient.Text, txtDivision.Text, "") = False Then
                    Me.ShowMessage("Access to this division is denied")
                    Return False
                End If
            End If
            If txtProduct.Text <> "" Then
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), txtClient.Text, txtDivision.Text, txtProduct.Text) = False Then
                    Me.ShowMessage("Access to this product is denied")
                    Return False
                End If
            End If
            If txtClient.Text <> "" And txtDivision.Text <> "" And txtProduct.Text <> "" And txtJob.Text <> "" And txtComponent.Text <> "" Then
                If myVal.ValidateCDPJCIsViewable(txtClient.Text, txtDivision.Text, txtProduct.Text, txtJob.Text, txtComponent.Text) = False Then
                    Me.ShowMessage("This Job/Comp does not exist for selected Client/Division/Product")
                    Return False
                End If
            End If
            If Me.txtSalesClass.Text <> "" Then
                If myVal.ValidateSalesClassCode(Me.txtSalesClass.Text, True) = False Then
                    Me.ShowMessage("Invalid Sales Class")
                    Return False
                End If
            End If
            If Me.txtCampaign.Text <> "" Then
                If Me.txtClient.Text.Trim() = "" Then
                    Me.ShowMessage("Client code required for campaign search")
                    Return False
                End If
                If myVal.ValidateCampaignFilter(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.txtCampaign.Text.Trim) = False Then
                    Me.ShowMessage("Campaign invalid")
                    Return False
                End If
                If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.txtCampaign.Text.Trim) = False Then
                    Me.ShowMessage("Access to this campaign is denied")
                    Return False
                End If
            End If
            If Me.txtAE.Text <> "" Then
                If myVal.ValidateEmpCode(Me.txtAE.Text) = False Then
                    Me.ShowMessage("Invalid Account Executive")
                    Return False
                End If
            End If
            Me.Client = txtClient.Text
            Me.Division = txtDivision.Text
            Me.Product = txtProduct.Text
            If txtJob.Text <> "" Then
                Me.JobNum = Convert.ToInt32(txtJob.Text)
            End If
            If txtComponent.Text <> "" Then
                Me.JobCompNum = Convert.ToInt32(txtComponent.Text)
            End If
            Me.Closed = Me.cbClosedJobs.Checked
            Me.Office = Me.txtOffice.Text
            Me.SalesClass = Me.txtSalesClass.Text
            Me.AE = Me.txtAE.Text
            Me.Campaign = Me.txtCampaign.Text

            Return True

        Catch ex As Exception
            Me.ShowMessage("err in search")
        End Try
    End Function

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secView As String = "N"
            Dim secEdit As String = "N"
            Dim secInsert As String = "N"

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")

            If secView = "N" Then
                rights = "N"
                ''''''Me.RadToolBarButtonPrint.Enabled = False
                Me.RadToolbarJobSearch.FindItemByValue("Print").Enabled = False
                Me.RadToolbarJobSearch.FindItemByValue("SendAlert").Enabled = False
                Me.RadToolbarJobSearch.FindItemByValue("SendEmail").Enabled = False
                Me.RadToolbarJobSearch.FindItemByValue("PrintSendOptions").Enabled = False

                Me.RadGridJobTemplateSearch.MasterTableView.GetColumn("GridTemplateColumnPrint").Visible = False

            End If
            If secEdit = "N" And secInsert = "N" Then
                Me.RadToolBarButtonNew.Enabled = False
            ElseIf secEdit = "Y" And secInsert = "N" Then
                Me.RadToolBarButtonNew.Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridJobTemplateSearch_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridJobTemplateSearch.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridJobTemplateSearch.ID, e.NewPageSize)

        End If

        Me.ValidateSearch()
    End Sub

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = RadGridJobTemplateSearch.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
        Me.MyUnityContextMenu.JobComponentNumber = RadGridJobTemplateSearch.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")

    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            If Me.ValidateSearch() = True Then Me.RadGridJobTemplateSearch.Rebind()
        Catch ex As Exception

        End Try
    End Sub
End Class
