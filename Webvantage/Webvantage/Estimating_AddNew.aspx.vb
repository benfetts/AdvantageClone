Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet
Partial Public Class Estimating_AddNew
    Inherits Webvantage.BaseChildPage

    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private EstNum As Integer = 0
    Private EstCompNum As Integer = 0
    Private IsValidJobAndComp As Boolean = False
    Private IsValidEstAndComp As Boolean = False
    Private Msg1 As String = ""
    Private DtJobAndComp As New DataTable
    Private DtEstAndComp As New DataTable
    Private Copy As String = ""

#Region " Page "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Estimating)
        Me.PageTitle = "New Estimate"
        Me.TxtEstimateDescription.Attributes.Add("onKeyup", "copytext()")
        IsValidJobAndComp = SetJobAndComp()
        IsValidEstAndComp = SetEstAndComp()
        If Not Page.IsPostBack Then
            If Request.QueryString("JT") = "1" Or Request.QueryString("newEst") = "job" Then
                ShowForm()
            Else
                ShowFormEst()
            End If
            LoadLookups()
            If Request.QueryString("copy") = "new" Then
                Copy = "new"
            ElseIf Request.QueryString("copy") = "loaded" Then
                Copy = "loaded"
            End If
        End If
        If Me.TxtEstimateSource.Text <> "" Then
            Me.ShowCopySourceData()
        End If
        Me.TxtClientCode.Focus()
    End Sub

    Private Sub LoadLookups()
        Me.HlClient.Attributes.Add("onclick", "FocusTB('" & Me.TxtClientCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientCode.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value);return false;")
        Me.HlDivision.Attributes.Add("onclick", "FocusTB('" & Me.TxtDivisionCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionCode.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value);return false;")
        Me.HlProduct.Attributes.Add("onclick", "FocusTB('" & Me.TxtProductCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedule&type=product&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
        'Me.HlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobnew&type=product&control=" & Me.TxtProductCode.ClientID & "&office=&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")
        Me.HlClientSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtClientSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientSource.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value);return false;")
        Me.HlDivisionSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtDivisionSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionSource.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value);return false;")
        Me.HlProductSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtProductSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtProductSource.ClientID & "&type=product&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")

        Me.HlJob.Attributes.Add("onclick", "FocusTB('" & Me.TxtJobNum.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=estimatejcnew&type=jobestimatesave&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClass.ClientID & ".value);return false;")
        Me.HlComponent.Attributes.Add("onclick", "FocusTB('" & Me.TxtJobNum.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=estimatejcnew&type=jobcompestimatesave&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value + '&salesclass=' + document.forms[0]." & Me.TxtSalesClass.ClientID & ".value);return false;")
        'Me.HlJob.Attributes.Add("onclick", "FocusTB('" & Me.TxtJobNum.ClientID & "');clearjob();OpenRadWindowLookup('LookUp.aspx?form=schedulenew&type=jobschedulenew&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value);return false;")
        'Me.HlComponent.Attributes.Add("onclick", "FocusTB('" & Me.TxtJobCompNum.ClientID & "');clearcomp();OpenRadWindowLookup('LookUp.aspx?form=schedulenew&type=jobcompschedulenew&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
        Me.HlSalesClass.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtSalesClass.ClientID & "&type=salesclass');return false;")
        Me.HlEstimateSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatecopy&type=estimatecopy&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&jobtype=' + document.forms[0]." & Me.TxtJobTypeSource.ClientID & ".value);return false;")
        Me.HlJobType.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobtype&control=" & Me.TxtJobTypeSource.ClientID & "&type=jobtypejh');return false;")

        Me.hlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=estcampaignnew&type=estcampaign&control=" & Me.TxtCampaign.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")

    End Sub

#End Region

#Region " Grid "

    Private Sub RadGridEstCopy_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEstCopy.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridGroupHeaderItem Then
                Dim item As Telerik.Web.UI.GridGroupHeaderItem = CType(e.Item, Telerik.Web.UI.GridGroupHeaderItem)
                Dim groupDataRow As DataRowView = CType(e.Item.DataItem, DataRowView)
                item.DataCell.Text = "Component: " + groupDataRow("EST_COMPONENT_NBR").ToString() + _
                                     " - " + groupDataRow("EST_COMP_DESC").ToString()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadGridEstCopy_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEstCopy.NeedDataSource
        Try
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            If Me.TxtEstimateSource.Text <> "" Then
                If myVal.ValidateEstimateNumber(Me.TxtEstimateSource.Text) = False Then
                    Me.ShowMessage("This estimate does not exist!")
                    Me.TxtEstimateSource.Focus()
                    Exit Sub
                End If
                Dim drEst As SqlDataReader = est.CheckJobNumberEstimateDR(Me.TxtEstimateSource.Text)
                If drEst.HasRows Then
                    drEst.Read()
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, drEst("JOB_NUMBER"))
                        If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, drEst("JOB_NUMBER")) = False AndAlso
                            AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                            Me.ShowMessage("Access to this estimate is denied.\n.")
                            Exit Sub
                        End If
                    End Using
                End If
                drEst.Close()
                Dim client As String
                Dim division As String
                Dim product As String
                Dim dt As DataTable = est.GetInfoForEstimateCopy(CInt(Me.TxtEstimateSource.Text))
                If dt.Rows.Count > 0 Then
                    If IsDBNull(DtEstAndComp.Rows(0)("CL_CODE")) = False Then
                        client = DtEstAndComp.Rows(0)("CL_CODE")
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("DIV_CODE")) = False Then
                        division = DtEstAndComp.Rows(0)("DIV_CODE")
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("PRD_CODE")) = False Then
                        product = DtEstAndComp.Rows(0)("PRD_CODE")
                    End If
                End If

                If client <> "" Then
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), client, "", "") = False Then
                        Me.ShowMessage("Access to this client is denied.")
                        Me.TxtClientCode.Text = ""
                        Me.TxtDivisionCode.Text = ""
                        Me.TxtProductCode.Text = ""
                        Me.TxtSalesClass.Text = ""
                        Me.TxtClientDescription.Text = ""
                        Me.TxtDivisionDescription.Text = ""
                        Me.TxtProductDescription.Text = ""
                        Me.TxtSalesClassDescription.Text = ""
                        Me.TxtEstimateDescription.Text = ""
                        Me.txtEstimateCompDescription.Text = ""
                        Exit Sub
                    End If
                End If
                If division <> "" Then
                    If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), client, division, "") = False Then
                        Me.ShowMessage("Access to this division is denied.")
                        Me.TxtClientCode.Text = ""
                        Me.TxtDivisionCode.Text = ""
                        Me.TxtProductCode.Text = ""
                        Me.TxtSalesClass.Text = ""
                        Me.TxtClientDescription.Text = ""
                        Me.TxtDivisionDescription.Text = ""
                        Me.TxtProductDescription.Text = ""
                        Me.TxtSalesClassDescription.Text = ""
                        Me.TxtEstimateDescription.Text = ""
                        Me.txtEstimateCompDescription.Text = ""
                        Exit Sub
                    End If
                End If
                If product <> "" Then
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), client, division, product) = False Then
                        Me.ShowMessage("Access to this product is denied.")
                        Me.TxtClientCode.Text = ""
                        Me.TxtDivisionCode.Text = ""
                        Me.TxtProductCode.Text = ""
                        Me.TxtSalesClass.Text = ""
                        Me.TxtClientDescription.Text = ""
                        Me.TxtDivisionDescription.Text = ""
                        Me.TxtProductDescription.Text = ""
                        Me.TxtSalesClassDescription.Text = ""
                        Me.TxtEstimateDescription.Text = ""
                        Me.txtEstimateCompDescription.Text = ""
                        Exit Sub
                    End If
                End If
            End If
            Me.RadGridEstCopy.DataSource = est.GetInfoForEstimateCopy(Me.TxtEstimateSource.Text)
            Me.SetGridSort("Comp")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetGridSort(ByVal StrSort As String)
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
            Dim gbf As Telerik.Web.UI.GridGroupByField
            Select Case StrSort
                Case "Comp"
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "EST_COMPONENT_NBR"
                    gbf.HeaderText = "Component"
                    GrpExpr.SelectFields.Add(gbf)
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "EST_COMP_DESC"
                    gbf.HeaderText = "Desc"
                    GrpExpr.SelectFields.Add(gbf)
                    gbf = New Telerik.Web.UI.GridGroupByField
                    gbf.FieldName = "EST_COMPONENT_NBR"
                    GrpExpr.GroupByFields.Add(gbf)
                    'GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("EST_COMPONENT_NBR Component, EST_COMP_DESC Group By EST_COMPONENT_NBR, EST_COMP_DESC")
                    With Me.RadGridEstCopy
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                        '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                    End With
                Case Else
                    Me.RadGridEstCopy.MasterTableView.GroupByExpressions.Clear()
            End Select
            'Session("EstimateGridSort") = StrSort
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Controls "

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.CloseThisWindow()
    End Sub

    Private Sub BtnCreateEstimate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCreateEstimate.Click
        Dim ErrMSG As String = ""
        Dim ThisJobNum As Integer = 0
        Dim ThisJobCompNum As Integer = 0
        Dim ThisStartDate As String = ""
        Dim ThisDueDate As String = ""
        Dim ThisSalesClass As String = ""
        Dim ThisPresetCode As String = ""
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))

        If Me.TxtClientCode.Text = "" Then
            ErrMSG &= "Client Code is required.\n"
        End If
        If Me.TxtDivisionCode.Text = "" Then
            ErrMSG &= "Division Code is required.\n"
        End If
        If Me.TxtProductCode.Text = "" Then
            ErrMSG &= "Product Code is required.\n"
        End If
        If Me.TxtSalesClass.Text = "" Then
            ErrMSG &= "Sales Class is required.\n"
        End If
        If Me.TxtEstimateDescription.Text = "" Then
            ErrMSG &= "Estimate Description is required.\n"
        End If
        If Me.txtEstimateCompDescription.Text = "" Then
            ErrMSG &= "Estimate Component Description is required.\n"
        End If

        If ErrMSG <> "" Then
            Me.ShowMessage(ErrMSG)
            Exit Sub
        End If

        If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" And Me.TxtCampaign.Text <> "" Then
            Me.ShowMessage("Please select a Job/Component or Campaign only.")
            Exit Sub
        End If

        If Me.TxtJobNum.Text <> "" Then
            If IsNumeric(Me.TxtJobNum.Text) = False Then
                ErrMSG &= "Please enter a valid job number.\n"
            Else
                Try
                    ThisJobNum = CType(Me.TxtJobNum.Text, Integer)
                Catch ex As Exception
                    ThisJobNum = 0
                End Try
            End If
        End If
        If Me.TxtJobCompNum.Text <> "" Then
            If IsNumeric(Me.TxtJobCompNum.Text) = False Then
                ErrMSG &= "Please enter a valid component number.\n"
            Else
                Try
                    ThisJobCompNum = CType(Me.TxtJobCompNum.Text, Integer)
                Catch ex As Exception
                    ThisJobCompNum = 0
                End Try
            End If
        End If

        If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, "", "", True) = False Then
            ErrMSG &= "Invalid Client!\n"
            'Exit Sub
        End If
        If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TxtClientCode.Text.Trim, "", "") = False Then
            ErrMSG &= "Access to this client is denied.\n"
            'Exit Sub
        End If
        If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "", True) = False Then
            ErrMSG &= "Invalid Client, Division!\n"
            'Exit Sub
        End If
        If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "") = False Then
            ErrMSG &= "Access to this division is denied.\n"
            'Exit Sub
        End If
        If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim, True) = False Then
            ErrMSG &= "Invalid Client, Division, Product!\n"
            'Exit Sub
        End If
        If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim) = False Then
            ErrMSG &= "Access to this product is denied.\n"
            'Exit Sub
        End If
        'Some basic job validation:
        If ThisJobNum > 0 And ThisJobCompNum > 0 Then
            If myVal.ValidateJobNumber(ThisJobNum) = False Then
                ErrMSG &= "This job does not exist!\n"
            End If
            If myVal.ValidateJobCompNumber(ThisJobNum, ThisJobCompNum) = False Then
                ErrMSG &= "This is not a valid job/component!\n"
            End If
            If ErrMSG <> "" Then
                Me.ShowMessage(ErrMSG)
                Exit Sub
            End If
            If myVal.ValidateJobIsOpen(ThisJobNum, ThisJobCompNum) = False Then
                ErrMSG &= "This job/comp is closed.\n"
            End If
            If myVal.ValidateJobCompIsViewable(Session("UserCode"), ThisJobNum, ThisJobCompNum) = False Then
                ErrMSG &= "Access to this job/comp is denied.\n"
            End If
            If myVal.ValidateJobCompIsEditable(ThisJobNum, ThisJobCompNum, True) = False Then
                ErrMSG &= "Job/comp process control does not allow access.\n"
            End If
        End If
        If myVal.ValidateSalesClassCode(Me.TxtSalesClass.Text) = False Then
            ErrMSG &= "Invalid Sales Class."
            'Exit Sub
        End If

        If Me.TxtCampaign.Text <> "" Then
            If myVal.ValidateCampaignEstimate(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtCampaign.Text) = False Then
                ErrMSG &= "Invalid Campaign."
            End If
            If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtCampaign.Text) = False Then
                ErrMSG &= "Access to this campaign is denied."
            End If
        End If

        If Me.TxtCampaign.Text = "" Then
            Me.HiddenFieldCampaignID.Value = "0"
        End If

        If ErrMSG <> "" Then

            Me.ShowMessage(ErrMSG)
            Exit Sub

        End If
        Dim dr As SqlClient.SqlDataReader
        Dim dr2 As SqlClient.SqlDataReader
        Dim currentJobEstNum As Integer = 0
        If ThisJobNum > 0 And ThisJobCompNum > 0 Then
            dr = est.GetEstJob(ThisJobNum, ThisJobCompNum)
            If dr.HasRows = True Then
                dr.Read()
                If dr("ESTIMATE_NUMBER") > 0 And dr("EST_COMPONENT_NBR") > 0 Then
                    ErrMSG &= "This is not a valid job/component for this new estimate.\n"
                End If
            End If
            dr.Close()
            If ErrMSG <> "" Then
                Me.ShowMessage(ErrMSG)
                Exit Sub
            End If
            dr2 = est.GetEstimateNumJob(ThisJobNum)
            If dr2.HasRows = True Then
                Do While dr2.Read
                    If dr2("ESTIMATE_NUMBER") > 0 Then
                        'ErrMSG &= "This is not a valid job/component for this new estimate.\n"
                        currentJobEstNum = dr2("ESTIMATE_NUMBER")
                        Exit Do
                    End If
                Loop
            End If
            dr2.Close()
        End If
        If ErrMSG <> "" Then
            Me.ShowMessage(ErrMSG)
            Exit Sub
        End If

        Try
            Dim s As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim j As Job = New Job(Session("ConnString"))
            Dim EstNumber As Integer = 0
            Dim markup As Decimal = 0.0
            Dim EstCompNumber As Integer = 0
            If ThisJobNum > 0 And ThisJobCompNum > 0 Then
                j.GetJob(ThisJobNum, ThisJobCompNum)
                If IsDBNull(j.JobComponent.JOB_MARKUP_PCT) = False Then
                    markup = j.JobComponent.JOB_MARKUP_PCT
                Else
                    markup = j.JobComponent.GetMarkupAmt(j.CL_CODE, j.DIV_CODE, j.PRD_CODE)
                End If
                Me.hfContactCodeID.Value = j.JobComponent.CDP_CONTACT_ID
            Else
                markup = j.JobComponent.GetMarkupAmt(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text)
            End If
            If currentJobEstNum > 0 Then
                EstCompNumber = s.AddNewEstimateComponent(currentJobEstNum, Me.hfContactCodeID.Value, Me.txtEstimateCompDescription.Text)
                If EstCompNumber > 0 Then
                    s.UpdateJobEstimate(ThisJobNum, ThisJobCompNum, currentJobEstNum, EstCompNumber)
                End If
            Else
                EstNumber = s.AddNewEstimate(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtSalesClass.Text, markup, Session("UserCode"), Me.TxtEstimateDescription.Text, Me.txtEstimateCompDescription.Text, ThisJobNum, ThisJobCompNum, Me.hfContactCodeID.Value, Me.HiddenFieldCampaignID.Value)
            End If

            Dim fromJT As Integer = 1
            Try
                If Not Session("FromWindow") = Nothing Then
                    If Session("FromWindow") = "ProjectView" Then
                        fromJT = 0
                    End If
                End If
            Catch ex As Exception
            End Try

            'If Me.CurrentQuerystring.IsJobDashboard = True Then
            '    If currentJobEstNum > 0 Then
            '        MiscFN.ResponseRedirect("Estimating.aspx?EstNum=" & currentJobEstNum & "&EstComp=" & EstCompNumber & "&newEst=new" & "&JT=" & CStr(fromJT), True)
            '    Else
            '        MiscFN.ResponseRedirect("Estimating.aspx?EstNum=" & EstNumber & "&EstComp=1&newEst=new" & "&JT=" & CStr(fromJT), True)
            '    End If
            'Else
            '    If currentJobEstNum > 0 Then
            '        Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & currentJobEstNum & "&EstComp=" & EstCompNumber & "&newEst=new" & "&JT=" & CStr(fromJT))
            '    Else
            '        Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & EstNumber & "&EstComp=1&newEst=new" & "&JT=" & CStr(fromJT))
            '    End If
            'End If
            If ThisJobNum > 0 AndAlso ThisJobCompNum > 0 Then

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.JobNumber = ThisJobNum
                qs.JobComponentNumber = ThisJobCompNum
                If currentJobEstNum > 0 Then
                    qs.EstimateNumber = currentJobEstNum
                    qs.EstimateComponentNumber = EstCompNumber
                Else
                    qs.EstimateNumber = EstNumber
                    qs.EstimateComponentNumber = 1
                End If
                qs.IsJobDashboard = True

                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                If Me.CurrentQuerystring.IsJobDashboard = True Then

                    qs.Page = "Estimating.aspx"
                    Response.Redirect(qs.ToString(True))

                Else

                    qs.Page = "Content.aspx"
                    Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True))

                End If

            Else

                If currentJobEstNum > 0 Then

                    Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & currentJobEstNum & "&EstComp=" & EstCompNumber & "&newEst=new" & "&JT=" & CStr(fromJT))

                Else

                    If EstNumber > 0 Then Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & EstNumber & "&EstComp=1&newEst=new" & "&JT=" & CStr(fromJT))

                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCompQuote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompQuote.Click
        Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
        If Me.TxtEstimateSource.Text = "" Then
            Me.ShowMessage("Please enter a valid Estimate number.")
            Me.TxtEstimateSource.Focus()
            Exit Sub
        End If
        Me.RadGridEstCopy.Rebind()
        If Me.TxtEstimateSource.Text <> "" Then
            If IsNumeric(Me.TxtEstimateSource.Text) Then
                Dim drEst As SqlDataReader = est.CheckJobNumberEstimateDR(Me.TxtEstimateSource.Text)
                If drEst.HasRows Then
                    drEst.Read()
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, drEst("JOB_NUMBER"))
                        If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, drEst("JOB_NUMBER")) = False AndAlso
                            AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                            Me.ShowMessage("Access to this Estimate is denied.\n.")
                            Exit Sub
                        End If
                    End Using
                End If
                drEst.Close()

                DtEstAndComp = est.GetInfoForEstimateCopy(CInt(Me.TxtEstimateSource.Text))
                If DtEstAndComp.Rows.Count > 0 Then
                    If Me.TxtClientCode.Text = "" And Me.TxtDivisionCode.Text = "" And Me.TxtProductCode.Text = "" Then
                        If IsDBNull(DtEstAndComp.Rows(0)("CL_CODE")) = False Then
                            Me.TxtClientCode.Text = DtEstAndComp.Rows(0)("CL_CODE")
                        Else
                            Me.TxtClientCode.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("DIV_CODE")) = False Then
                            Me.TxtDivisionCode.Text = DtEstAndComp.Rows(0)("DIV_CODE")
                        Else
                            Me.TxtDivisionCode.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("PRD_CODE")) = False Then
                            Me.TxtProductCode.Text = DtEstAndComp.Rows(0)("PRD_CODE")
                        Else
                            Me.TxtProductCode.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("CL_NAME")) = False Then
                            Me.TxtClientDescription.Text = DtEstAndComp.Rows(0)("CL_NAME")
                        Else
                            Me.TxtClientDescription.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("DIV_NAME")) = False Then
                            Me.TxtDivisionDescription.Text = DtEstAndComp.Rows(0)("DIV_NAME")
                        Else
                            Me.TxtDivisionDescription.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("PRD_DESCRIPTION")) = False Then
                            Me.TxtProductDescription.Text = DtEstAndComp.Rows(0)("PRD_DESCRIPTION")
                        Else
                            Me.TxtProductDescription.Text = ""
                        End If
                    End If
                    If Me.TxtEstimateDescription.Text = "" Then
                        If IsDBNull(DtEstAndComp.Rows(0)("EST_LOG_DESC")) = False Then
                            Me.TxtEstimateDescription.Text = DtEstAndComp.Rows(0)("EST_LOG_DESC")
                        Else
                            Me.TxtEstimateDescription.Text = ""
                        End If
                    End If
                    If Me.txtEstimateCompDescription.Text = "" Then
                        If IsDBNull(DtEstAndComp.Rows(0)("EST_COMP_DESC")) = False Then
                            Me.txtEstimateCompDescription.Text = DtEstAndComp.Rows(0)("EST_COMP_DESC")
                        Else
                            Me.txtEstimateCompDescription.Text = ""
                        End If
                    End If
                    If Me.TxtSalesClass.Text = "" Then
                        If IsDBNull(DtEstAndComp.Rows(0)("SC_CODE")) = False Then
                            Me.TxtSalesClass.Text = DtEstAndComp.Rows(0)("SC_CODE")
                        Else
                            Me.TxtSalesClass.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("SC_DESCRIPTION")) = False Then
                            Me.TxtSalesClassDescription.Text = DtEstAndComp.Rows(0)("SC_DESCRIPTION")
                        Else
                            Me.TxtSalesClassDescription.Text = ""
                        End If
                    End If
                End If
            End If
        End If
        Dim client As String
        Dim division As String
        Dim product As String
        Dim dt As DataTable = est.GetInfoForEstimateCopy(CInt(Me.TxtEstimateSource.Text))
        If dt.Rows.Count > 0 Then
            If IsDBNull(DtEstAndComp.Rows(0)("CL_CODE")) = False Then
                client = DtEstAndComp.Rows(0)("CL_CODE")
            End If
            If IsDBNull(DtEstAndComp.Rows(0)("DIV_CODE")) = False Then
                division = DtEstAndComp.Rows(0)("DIV_CODE")
            End If
            If IsDBNull(DtEstAndComp.Rows(0)("PRD_CODE")) = False Then
                product = DtEstAndComp.Rows(0)("PRD_CODE")
            End If
        End If

        If client <> "" Then
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), client, "", "") = False Then
                Me.TxtClientCode.Text = ""
                Me.TxtDivisionCode.Text = ""
                Me.TxtProductCode.Text = ""
                Me.TxtSalesClass.Text = ""
                Me.TxtClientDescription.Text = ""
                Me.TxtDivisionDescription.Text = ""
                Me.TxtProductDescription.Text = ""
                Me.TxtSalesClassDescription.Text = ""
                Me.TxtEstimateDescription.Text = ""
                Me.txtEstimateCompDescription.Text = ""
            End If
        End If
        If division <> "" Then
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), client, division, "") = False Then
                Me.TxtClientCode.Text = ""
                Me.TxtDivisionCode.Text = ""
                Me.TxtProductCode.Text = ""
                Me.TxtSalesClass.Text = ""
                Me.TxtClientDescription.Text = ""
                Me.TxtDivisionDescription.Text = ""
                Me.TxtProductDescription.Text = ""
                Me.TxtSalesClassDescription.Text = ""
                Me.TxtEstimateDescription.Text = ""
                Me.txtEstimateCompDescription.Text = ""
            End If
        End If
        If product <> "" Then
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), client, division, product) = False Then
                Me.TxtClientCode.Text = ""
                Me.TxtDivisionCode.Text = ""
                Me.TxtProductCode.Text = ""
                Me.TxtSalesClass.Text = ""
                Me.TxtClientDescription.Text = ""
                Me.TxtDivisionDescription.Text = ""
                Me.TxtProductDescription.Text = ""
                Me.TxtSalesClassDescription.Text = ""
                Me.TxtEstimateDescription.Text = ""
                Me.txtEstimateCompDescription.Text = ""
            End If
        End If
    End Sub
    Private Sub btnCopyEstimate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyEstimate.Click
        Try
            Dim ErrMSG As String = ""
            Dim ThisJobNum As Integer = 0
            Dim ThisJobCompNum As Integer = 0
            Dim ThisStartDate As String = ""
            Dim ThisDueDate As String = ""
            Dim ThisSalesClass As String = ""
            Dim ThisPresetCode As String = ""
            Dim recalc As Integer = 0
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))

            If Me.TxtClientCode.Text = "" Then
                ErrMSG &= "Client Code is required.\n"
            End If
            If Me.TxtDivisionCode.Text = "" Then
                ErrMSG &= "Division Code is required.\n"
            End If
            If Me.TxtProductCode.Text = "" Then
                ErrMSG &= "Product Code is required.\n"
            End If
            If Me.TxtSalesClass.Text = "" Then
                ErrMSG &= "Sales Class is required.\n"
            End If
            If Me.TxtEstimateDescription.Text = "" Then
                ErrMSG &= "Estimate Description is required.\n"
            End If

            If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" And Me.TxtCampaign.Text <> "" Then
                Me.ShowMessage("Please select a Job/Component or Campaign only.")
                Exit Sub
            End If

            If Me.TxtJobNum.Text <> "" Then
                If IsNumeric(Me.TxtJobNum.Text) = False Then
                    ErrMSG &= "Please enter a valid job number.\n"
                Else
                    Try
                        ThisJobNum = CType(Me.TxtJobNum.Text, Integer)
                    Catch ex As Exception
                        ThisJobNum = 0
                    End Try
                End If
            End If
            If Me.TxtJobCompNum.Text <> "" Then
                If IsNumeric(Me.TxtJobCompNum.Text) = False Then
                    ErrMSG &= "Please enter a valid component number.\n"
                Else
                    Try
                        ThisJobCompNum = CType(Me.TxtJobCompNum.Text, Integer)
                    Catch ex As Exception
                        ThisJobCompNum = 0
                    End Try
                End If
            End If

            If ErrMSG <> "" Then
                Me.ShowMessage(ErrMSG)
                Exit Sub
            End If

            If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, "", "", True) = False Then
                ErrMSG &= "Invalid Client!\n"
                'Exit Sub
            End If
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TxtClientCode.Text.Trim, "", "") = False Then
                ErrMSG &= "Access to this client is denied.\n"
                'Exit Sub
            End If
            If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "", True) = False Then
                ErrMSG &= "Invalid Client, Division!\n"
                'Exit Sub
            End If
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "") = False Then
                ErrMSG &= "Access to this division is denied.\n"
                'Exit Sub
            End If
            If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim, True) = False Then
                ErrMSG &= "Invalid Client, Division, Product!\n"
                'Exit Sub
            End If
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim) = False Then
                ErrMSG &= "Access to this product is denied.\n"
                'Exit Sub
            End If
            'Some basic job validation:
            If ThisJobNum > 0 And ThisJobCompNum > 0 Then
                If myVal.ValidateJobNumber(ThisJobNum) = False Then
                    ErrMSG &= "This job does not exist!\n"
                End If
                If myVal.ValidateJobCompNumber(ThisJobNum, ThisJobCompNum) = False Then
                    ErrMSG &= "This is not a valid job/component!\n"
                End If
                If ErrMSG <> "" Then
                    Me.ShowMessage(ErrMSG)
                    Exit Sub
                End If
                If myVal.ValidateJobIsOpen(ThisJobNum, ThisJobCompNum) = False Then
                    ErrMSG &= "This job/comp is closed.\n"
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), ThisJobNum, ThisJobCompNum) = False Then
                    ErrMSG &= "Access to this job/comp is denied.\n"
                End If
                If myVal.ValidateJobCompIsEditable(ThisJobNum, ThisJobCompNum, True) = False Then
                    ErrMSG &= "Job/comp process control does not allow access.\n"
                End If
            End If
            If myVal.ValidateSalesClassCode(Me.TxtSalesClass.Text) = False Then
                ErrMSG &= "Invalid Sales Class.\n"
                'Exit Sub
            End If

            If Me.TxtCampaign.Text <> "" Then
                If myVal.ValidateCampaignEstimate(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtCampaign.Text) = False Then
                    ErrMSG &= "Invalid Campaign."
                End If
                If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtCampaign.Text) = False Then
                    ErrMSG &= "Access to this campaign is denied."
                End If
            End If

            If ErrMSG <> "" Then
                Me.ShowMessage(ErrMSG)
                Exit Sub
            End If

            Dim chkbox As CheckBox
            Dim items As Boolean = False
            Dim itemsCount As Integer = 0
            Dim cp
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstCopy.MasterTableView.Items
                chkbox = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                If chkbox.Checked = True Then
                    If cp <> gridDataItem.GetDataKeyValue("EST_COMPONENT_NBR") Then
                        cp = gridDataItem.GetDataKeyValue("EST_COMPONENT_NBR")
                        itemsCount += 1
                    End If
                    items = True
                End If
            Next

            If Me.cbRecalculate.Checked = True Then
                recalc = 1
            End If

            If items = False Then
                Me.ShowMessage("No Components/Quotes Selected for Copy.")
                Exit Sub
            End If

            If ThisJobNum > 0 And ThisJobCompNum > 0 And itemsCount > 1 Then
                Me.ShowMessage("Only one component can be selected for copying, when job/comp selected.")
                Exit Sub
            End If

            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim dr As SqlClient.SqlDataReader
            Dim dr2 As SqlClient.SqlDataReader
            Dim currentJobEstNum As Integer = 0
            If ThisJobNum > 0 And ThisJobCompNum > 0 Then
                dr = est.GetEstJob(ThisJobNum, ThisJobCompNum)
                dr.Read()
                If dr("ESTIMATE_NUMBER") > 0 And dr("EST_COMPONENT_NBR") > 0 Then
                    ErrMSG &= "This is not a valid job/component for this new estimate.\n"
                End If
                dr.Close()
                If ErrMSG <> "" Then
                    Me.ShowMessage(ErrMSG)
                    Exit Sub
                End If
                dr2 = est.GetEstimateNumJob(ThisJobNum)
                If dr2.HasRows = True Then
                    Do While dr2.Read
                        If dr2("ESTIMATE_NUMBER") > 0 Then
                            'ErrMSG &= "This is not a valid job/component for this new estimate.\n"
                            currentJobEstNum = dr2("ESTIMATE_NUMBER")
                            Exit Do
                        End If
                    Loop
                End If
                dr2.Close()
            End If

            If Me.TxtCampaign.Text = "" Then
                Me.HiddenFieldCampaignID.Value = "0"
            End If

            If ErrMSG <> "" Then
                Me.ShowMessage(ErrMSG)
                Exit Sub
            End If


            Dim j As Job = New Job(Session("ConnString"))
            Dim estNumber As Integer
            Dim markup As Decimal = 0.0
            If ThisJobNum > 0 And ThisJobCompNum > 0 Then
                j.GetJob(ThisJobNum, ThisJobCompNum)
                If IsDBNull(j.JobComponent.JOB_MARKUP_PCT) = False Then
                    markup = j.JobComponent.JOB_MARKUP_PCT
                Else
                    markup = j.JobComponent.GetMarkupAmt(j.CL_CODE, j.DIV_CODE, j.PRD_CODE)
                End If
                Me.hfContactCodeID.Value = j.JobComponent.CDP_CONTACT_ID
            Else
                Me.hfContactCodeID.Value = 0
                markup = j.JobComponent.GetMarkupAmt(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text)
            End If
            If currentJobEstNum = 0 Then
                estNumber = est.AddNewEstimateCopy(Me.TxtEstimateSource.Text, Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtSalesClass.Text, markup, Me.TxtEstimateDescription.Text, Session("UserCode"), Me.HiddenFieldCampaignID.Value)
            Else
                estNumber = currentJobEstNum
            End If


            Dim chk As CheckBox
            Dim comp As Integer = 0
            Dim quoteNum As Integer = 0
            Dim quoteDesc As String = ""
            Dim newComp As Integer = 0
            Dim revNum As Integer = 0
            Dim save As Boolean
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridEstCopy.MasterTableView.Items
                chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                If chk.Checked = True Then
                    Try
                        quoteNum = CInt(gridDataItem("colEST_QUOTE_NBR").Text.Replace("&nbsp;", ""))
                    Catch ex As Exception
                        quoteNum = 0
                    End Try
                    Dim c As String = gridDataItem.GetDataKeyValue("EST_COMPONENT_NBR")
                    If comp <> gridDataItem.GetDataKeyValue("EST_COMPONENT_NBR") Then
                        comp = gridDataItem.GetDataKeyValue("EST_COMPONENT_NBR")
                        newComp = est.AddNewEstimateComponentCopy(estNumber, Me.TxtEstimateSource.Text, comp, Me.txtEstimateCompDescription.Text, ThisJobNum, ThisJobCompNum, Me.hfContactCodeID.Value)
                        revNum = est.GetEstimateQuoteMaxRevision(Me.TxtEstimateSource.Text, comp, quoteNum)
                        save = est.AddNewQuoteCopy(estNumber, newComp, Me.TxtEstimateSource.Text, comp, quoteNum, revNum, recalc)
                    Else
                        revNum = est.GetEstimateQuoteMaxRevision(Me.TxtEstimateSource.Text, comp, quoteNum)
                        save = est.AddNewQuoteCopy(estNumber, newComp, Me.TxtEstimateSource.Text, comp, quoteNum, revNum, recalc)
                    End If


                End If
            Next
            'Dim CameFromJobTemplate As Boolean = False
            'If CameFromJobTemplate = True Then

            'Else
            '    If Me.CurrentQuerystring.IsJobDashboard = True Then
            '        If currentJobEstNum <> 0 Then
            '            MiscFN.ResponseRedirect("Estimating.aspx?EstNum=" & estNumber & "&EstComp=" & newComp & "&newEst=new", True)
            '        Else
            '            MiscFN.ResponseRedirect("Estimating.aspx?EstNum=" & estNumber & "&EstComp=1&newEst=new", True)
            '        End If
            '    Else
            '        If currentJobEstNum <> 0 Then
            '            Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & estNumber & "&EstComp=" & newComp & "&newEst=new", True)
            '        Else
            '            Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & estNumber & "&EstComp=1&newEst=new", True)
            '        End If
            '    End If
            'End If
            If ThisJobNum > 0 AndAlso ThisJobCompNum > 0 Then

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.JobNumber = ThisJobNum
                qs.JobComponentNumber = ThisJobCompNum
                qs.EstimateNumber = currentJobEstNum
                qs.EstimateComponentNumber = newComp
                qs.IsJobDashboard = True

                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                If Me.CurrentQuerystring.IsJobDashboard = True Then

                    qs.Page = "Estimating.aspx"
                    Response.Redirect(qs.ToString(True))

                Else

                    qs.Page = "Content.aspx"
                    Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True))

                End If

            Else

                If currentJobEstNum > 0 Then

                    Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & currentJobEstNum & "&EstComp=" & newComp & "&newEst=new" & "&JT=0")

                Else

                    Me.CloseThisWindowAndOpenNewWindow("Estimating.aspx?EstNum=" & estNumber & "&EstComp=1&newEst=new" & "&JT=0")

                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtJobCompNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtJobCompNum.TextChanged
        Try
            Dim jc As New Job(Session("ConnString"))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing

            If IsNumeric(Me.TxtJobNum.Text) = True And IsNumeric(Me.TxtJobCompNum.Text) = True Then
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, TxtJobNum.Text)
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, TxtJobNum.Text) = False AndAlso
                            AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                        Me.ShowMessage("Access to this job is denied.\n.")
                        Exit Sub
                    End If
                End Using
                jc.GetJob(CInt(Me.TxtJobNum.Text), CInt(Me.TxtJobCompNum.Text))
                Me.TxtSalesClass.Text = jc.SC_CODE
                Me.HlSalesClass.Enabled = False
                Me.HlSalesClass.Attributes.Add("onclick", "")
                Me.TxtSalesClass.Enabled = False
                Me.TxtEstimateDescription.Text = jc.JOB_DESC
                Me.txtEstimateCompDescription.Text = jc.JobComponent.JOB_COMP_DESC
                Me.TxtSalesClassDescription.Text = jc.SalesClassDesc
                Me.TxtClientCode.Text = jc.CL_CODE
                Me.TxtClientDescription.Text = jc.ClientDesc
                Me.TxtDivisionCode.Text = jc.DIV_CODE
                Me.TxtDivisionDescription.Text = jc.DivisionDesc
                Me.TxtProductCode.Text = jc.PRD_CODE
                Me.TxtProductDescription.Text = jc.ProductDesc
                Me.hfContactCodeID.Value = jc.JobComponent.CDP_CONTACT_ID
                Me.TxtJobDescription.Text = jc.JOB_DESC
                Me.TxtJobCompDescription.Text = jc.JobComponent.JOB_COMP_DESC
            Else
                Me.HlSalesClass.Enabled = True
                Me.TxtSalesClass.Enabled = True
                Me.TxtEstimateDescription.Text = ""
                Me.txtEstimateCompDescription.Text = ""
                Me.TxtSalesClass.Text = ""
                Me.TxtSalesClassDescription.Text = ""
                Me.TxtJobDescription.Text = ""
                Me.TxtJobCompDescription.Text = ""
                Me.TxtJobCompNum.Text = ""
                Me.LoadLookups()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtJobNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtJobNum.TextChanged
        Try
            Dim jc As New Job(Session("ConnString"))
            If IsNumeric(Me.TxtJobNum.Text) = True And IsNumeric(Me.TxtJobCompNum.Text) = True Then
                jc.GetJob(CInt(Me.TxtJobNum.Text), CInt(Me.TxtJobCompNum.Text))
                Me.TxtSalesClass.Text = jc.SC_CODE
                Me.HlSalesClass.Enabled = False
                Me.HlSalesClass.Attributes.Add("onclick", "")
                Me.TxtSalesClass.Enabled = False
                Me.TxtEstimateDescription.Text = jc.JOB_DESC
                Me.txtEstimateCompDescription.Text = jc.JobComponent.JOB_COMP_DESC
                Me.TxtSalesClassDescription.Text = jc.SalesClassDesc
                Me.TxtClientCode.Text = jc.CL_CODE
                Me.TxtClientDescription.Text = jc.ClientDesc
                Me.TxtDivisionCode.Text = jc.DIV_CODE
                Me.TxtDivisionDescription.Text = jc.DivisionDesc
                Me.TxtProductCode.Text = jc.PRD_CODE
                Me.TxtProductDescription.Text = jc.ProductDesc
                Me.hfContactCodeID.Value = jc.JobComponent.CDP_CONTACT_ID
                Me.TxtJobDescription.Text = jc.JOB_DESC
                Me.TxtJobCompDescription.Text = jc.JobComponent.JOB_COMP_DESC
            Else
                Me.HlSalesClass.Enabled = True
                Me.TxtSalesClass.Enabled = True
                Me.TxtEstimateDescription.Text = ""
                Me.txtEstimateCompDescription.Text = ""
                Me.TxtSalesClass.Text = ""
                Me.TxtSalesClassDescription.Text = ""
                Me.TxtJobDescription.Text = ""
                Me.TxtJobCompDescription.Text = ""
                Me.TxtJobCompNum.Text = ""
                Me.LoadLookups()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCampaign_TextChanged(sender As Object, e As EventArgs) Handles TxtCampaign.TextChanged
        Try
            If Me.TxtCampaign.Text <> "" Then
                Dim camp As AdvantageFramework.Database.Entities.Campaign = Nothing
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    camp = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignCodeFirstRecord(DbContext, Me.TxtCampaign.Text)

                    If camp IsNot Nothing Then
                        Me.TxtClientCode.Text = camp.ClientCode
                        Me.TxtDivisionCode.Text = camp.DivisionCode
                        Me.TxtProductCode.Text = camp.ProductCode
                        Me.HiddenFieldCampaignID.Value = camp.ID
                        Me.TxtCampaignDescription.Text = camp.Name
                    End If

                End Using
            Else
                Me.HiddenFieldCampaignID.Value = ""
                Me.TxtCampaignDescription.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Function SetJobAndComp() As Boolean
        Try
            If IsNumeric(Request.QueryString("JobNum")) = True Then
                JobNum = CType(Request.QueryString("JobNum"), Integer)
            Else
                JobNum = 0
            End If
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("JobComp")) = True Then
                JobCompNum = CType(Request.QueryString("JobComp"), Integer)
            Else
                JobCompNum = 0
            End If
        Catch ex As Exception
            JobCompNum = 0
        End Try

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber

        If JobNum > 0 And JobCompNum > 0 Then
            'Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))
            'Return Not s.HasHeader(JobNum, JobCompNum)
            'Dim i As Integer = s.CheckExistsClosed(JobNum, JobCompNum)
            'If i = -2 Then
            '    Me.LblMSG.Text = "Schedule is completed and cannot be viewed."
            '    Me.PnlAddNewEstimate.Visible = False
            '    Me.PnlDontAddNewSchedule.Visible = True
            '    Return False
            'Else
            Return True
            'End If
        Else
            Return False
        End If

    End Function
    Private Function SetEstAndComp() As Boolean
        Try
            If IsNumeric(Request.QueryString("EstNum")) = True Then
                EstNum = CType(Request.QueryString("EstNum"), Integer)
                Me.TxtEstimateSource.Text = EstNum
            Else
                EstNum = 0
            End If
        Catch ex As Exception
            EstNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("EstComp")) = True Then
                EstCompNum = CType(Request.QueryString("EstComp"), Integer)
            Else
                EstCompNum = 0
            End If
        Catch ex As Exception
            EstCompNum = 0
        End Try

        If EstNum > 0 And EstCompNum > 0 Then
            'Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))
            'Return Not s.HasHeader(JobNum, JobCompNum)
            'Dim i As Integer = s.CheckExistsClosed(EstNum, EstCompNum)
            'If i = -2 Then
            '    Me.LblMSG.Text = "Schedule is completed and cannot be viewed."
            '    Me.PnlAddNewEstimate.Visible = False
            '    Me.PnlDontAddNewSchedule.Visible = True
            '    Return False
            'Else
            Return True
            'End If
        Else
            Return False
        End If

    End Function
    Private Sub ShowForm()
        'Me.PnlAddNewSchedule.Visible = IsValidJobAndComp
        'Me.PnlDontAddNewSchedule.Visible = Not IsValidJobAndComp
        'If IsValidJobAndComp = True Then
        'Else
        '    LblMSG.Text = "Invalid job/comp."
        'End If
        If JobNum > 0 And JobCompNum > 0 Then
            Me.TxtJobNum.Text = JobNum
            Me.TxtJobCompNum.Text = JobCompNum
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            DtJobAndComp = est.GetBaseJobAndCompInfoDT(JobNum, JobCompNum)
            If DtJobAndComp.Rows.Count > 0 Then
                If IsDBNull(DtJobAndComp.Rows(0)("CL_CODE")) = False Then
                    Me.TxtClientCode.Text = DtJobAndComp.Rows(0)("CL_CODE")
                Else
                    Me.TxtClientCode.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("DIV_CODE")) = False Then
                    Me.TxtDivisionCode.Text = DtJobAndComp.Rows(0)("DIV_CODE")
                Else
                    Me.TxtDivisionCode.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("PRD_CODE")) = False Then
                    Me.TxtProductCode.Text = DtJobAndComp.Rows(0)("PRD_CODE")
                Else
                    Me.TxtProductCode.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("CL_NAME")) = False Then
                    Me.TxtClientDescription.Text = DtJobAndComp.Rows(0)("CL_NAME")
                Else
                    Me.TxtClientDescription.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("DIV_NAME")) = False Then
                    Me.TxtDivisionDescription.Text = DtJobAndComp.Rows(0)("DIV_NAME")
                Else
                    Me.TxtDivisionDescription.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("PRD_DESCRIPTION")) = False Then
                    Me.TxtProductDescription.Text = DtJobAndComp.Rows(0)("PRD_DESCRIPTION")
                Else
                    Me.TxtProductDescription.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("JOB_DESC")) = False Then
                    Me.TxtJobDescription.Text = DtJobAndComp.Rows(0)("JOB_DESC")
                Else
                    Me.TxtJobDescription.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("JOB_COMP_DESC")) = False Then
                    Me.TxtJobCompDescription.Text = DtJobAndComp.Rows(0)("JOB_COMP_DESC")
                Else
                    Me.TxtJobCompDescription.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("SC_CODE")) = False Then
                    Me.TxtSalesClass.Text = DtJobAndComp.Rows(0)("SC_CODE")
                Else
                    Me.TxtSalesClass.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("SC_DESCRIPTION")) = False Then
                    Me.TxtSalesClassDescription.Text = DtJobAndComp.Rows(0)("SC_DESCRIPTION")
                Else
                    Me.TxtSalesClassDescription.Text = ""
                End If
                Me.TxtEstimateDescription.Text = Me.TxtJobDescription.Text
                Me.txtEstimateCompDescription.Text = Me.TxtJobCompDescription.Text
            End If
            Me.TxtClientCode.Focus()
        Else
            Me.TxtJobNum.Focus()
        End If
    End Sub
    Private Sub ShowFormEst()
        Try
            'Try
            '    If IsNumeric(Request.QueryString("j")) = True Then
            '        JobNum = CType(Request.QueryString("j"), Integer)
            '        Me.TxtJobNum.Text = JobNum
            '    Else
            '        JobNum = 0
            '    End If
            'Catch ex As Exception
            '    JobNum = 0
            'End Try
            'Try
            '    If IsNumeric(Request.QueryString("jc")) = True Then
            '        JobCompNum = CType(Request.QueryString("jc"), Integer)
            '        Me.TxtJobCompNum.Text = JobCompNum
            '    Else
            '        JobCompNum = 0
            '    End If
            'Catch ex As Exception
            '    JobCompNum = 0
            'End Try
            If EstNum > 0 And EstCompNum > 0 Then
                Dim e As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
                DtEstAndComp = e.GetInfoForEstimateCopy(EstNum)
                If DtEstAndComp.Rows.Count > 0 Then
                    If IsDBNull(DtEstAndComp.Rows(0)("CL_CODE")) = False Then
                        Me.TxtClientCode.Text = DtEstAndComp.Rows(0)("CL_CODE")
                    Else
                        Me.TxtClientCode.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("DIV_CODE")) = False Then
                        Me.TxtDivisionCode.Text = DtEstAndComp.Rows(0)("DIV_CODE")
                    Else
                        Me.TxtDivisionCode.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("PRD_CODE")) = False Then
                        Me.TxtProductCode.Text = DtEstAndComp.Rows(0)("PRD_CODE")
                    Else
                        Me.TxtProductCode.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("CL_NAME")) = False Then
                        Me.TxtClientDescription.Text = DtEstAndComp.Rows(0)("CL_NAME")
                    Else
                        Me.TxtClientDescription.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("DIV_NAME")) = False Then
                        Me.TxtDivisionDescription.Text = DtEstAndComp.Rows(0)("DIV_NAME")
                    Else
                        Me.TxtDivisionDescription.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("PRD_DESCRIPTION")) = False Then
                        Me.TxtProductDescription.Text = DtEstAndComp.Rows(0)("PRD_DESCRIPTION")
                    Else
                        Me.TxtProductDescription.Text = ""
                    End If
                    'If IsDBNull(DtEstAndComp.Rows(0)("JOB_DESC")) = False Then
                    '    Me.TxtJobDescription.Text = DtEstAndComp.Rows(0)("JOB_DESC")
                    'Else
                    '    Me.TxtJobDescription.Text = ""
                    'End If
                    'If IsDBNull(DtEstAndComp.Rows(0)("JOB_COMP_DESC")) = False Then
                    '    Me.TxtJobCompDescription.Text = DtEstAndComp.Rows(0)("JOB_COMP_DESC")
                    'Else
                    '    Me.TxtJobCompDescription.Text = ""
                    'End If
                    If IsDBNull(DtEstAndComp.Rows(0)("SC_CODE")) = False Then
                        Me.TxtSalesClass.Text = DtEstAndComp.Rows(0)("SC_CODE")
                    Else
                        Me.TxtSalesClass.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("SC_DESCRIPTION")) = False Then
                        Me.TxtSalesClassDescription.Text = DtEstAndComp.Rows(0)("SC_DESCRIPTION")
                    Else
                        Me.TxtSalesClassDescription.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("CL_CODE")) = False Then
                        Me.TxtClientSource.Text = DtEstAndComp.Rows(0)("CL_CODE")
                    Else
                        Me.TxtClientSource.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("DIV_CODE")) = False Then
                        Me.TxtDivisionSource.Text = DtEstAndComp.Rows(0)("DIV_CODE")
                    Else
                        Me.TxtDivisionSource.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("PRD_CODE")) = False Then
                        Me.TxtProductSource.Text = DtEstAndComp.Rows(0)("PRD_CODE")
                    Else
                        Me.TxtProductSource.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("CL_NAME")) = False Then
                        Me.TxtClientSourceDesc.Text = DtEstAndComp.Rows(0)("CL_NAME")
                    Else
                        Me.TxtClientSourceDesc.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("DIV_NAME")) = False Then
                        Me.TxtDivisionSourceDesc.Text = DtEstAndComp.Rows(0)("DIV_NAME")
                    Else
                        Me.TxtDivisionSourceDesc.Text = ""
                    End If
                    If IsDBNull(DtEstAndComp.Rows(0)("PRD_DESCRIPTION")) = False Then
                        Me.TxtProductSourceDesc.Text = DtEstAndComp.Rows(0)("PRD_DESCRIPTION")
                    Else
                        Me.TxtProductSourceDesc.Text = ""
                    End If
                End If
                Me.CollapsablePanelHeader.Collapsed = False
                'If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                '    Me.RadGridEstCopy.AllowMultiRowSelection = False
                'Else
                '    Me.RadGridEstCopy.AllowMultiRowSelection = True
                'End If
                Me.TxtClientCode.Focus()
            Else
                Me.TxtClientCode.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub ShowCopySourceData()
        Try
            If Me.TxtEstimateSource.Text <> "" Then
                Dim e As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
                If IsNumeric(Me.TxtEstimateSource.Text) Then
                    DtEstAndComp = e.GetInfoForEstimateCopy(CInt(Me.TxtEstimateSource.Text))
                    If DtEstAndComp.Rows.Count > 0 Then
                        If IsDBNull(DtEstAndComp.Rows(0)("CL_CODE")) = False Then
                            Me.TxtClientSource.Text = DtEstAndComp.Rows(0)("CL_CODE")
                        Else
                            Me.TxtClientSource.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("DIV_CODE")) = False Then
                            Me.TxtDivisionSource.Text = DtEstAndComp.Rows(0)("DIV_CODE")
                        Else
                            Me.TxtDivisionSource.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("PRD_CODE")) = False Then
                            Me.TxtProductSource.Text = DtEstAndComp.Rows(0)("PRD_CODE")
                        Else
                            Me.TxtProductSource.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("CL_NAME")) = False Then
                            Me.TxtClientSourceDesc.Text = DtEstAndComp.Rows(0)("CL_NAME")
                        Else
                            Me.TxtClientSourceDesc.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("DIV_NAME")) = False Then
                            Me.TxtDivisionSourceDesc.Text = DtEstAndComp.Rows(0)("DIV_NAME")
                        Else
                            Me.TxtDivisionSourceDesc.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("PRD_DESCRIPTION")) = False Then
                            Me.TxtProductSourceDesc.Text = DtEstAndComp.Rows(0)("PRD_DESCRIPTION")
                        Else
                            Me.TxtProductSourceDesc.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("EST_LOG_DESC")) = False Then
                            Me.TxtEstimateSourceDesc.Text = DtEstAndComp.Rows(0)("EST_LOG_DESC")
                        Else
                            Me.TxtEstimateSourceDesc.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("JT_CODE")) = False Then
                            Me.TxtJobTypeSource.Text = DtEstAndComp.Rows(0)("JT_CODE")
                        Else
                            Me.TxtJobTypeSource.Text = ""
                        End If
                        If IsDBNull(DtEstAndComp.Rows(0)("JT_DESC")) = False Then
                            Me.TxtJobTypeSourceDesc.Text = DtEstAndComp.Rows(0)("JT_DESC")
                        Else
                            Me.TxtJobTypeSourceDesc.Text = ""
                        End If
                    End If
                End If
            End If
            If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                Dim job As New Job(Session("ConnString"))
                If IsNumeric(Me.TxtJobNum.Text) And IsNumeric(Me.TxtJobCompNum.Text) Then
                    job.GetJob(CInt(Me.TxtJobNum.Text), CInt(Me.TxtJobCompNum.Text))
                    Me.TxtJobDescription.Text = job.JOB_DESC
                    Me.TxtJobCompDescription.Text = job.JobComponent.JOB_COMP_DESC
                    Me.TxtSalesClassDescription.Text = job.SalesClassDesc
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class