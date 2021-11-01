Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel
Imports Ionic.Zip
Imports System.IO
Imports System.Threading
Imports Webvantage.cGlobals


Partial Public Class JobTemplate_Print
    Inherits Webvantage.BasePrintSendPage

#Region " Private vars: "

    Private PageEdit As Boolean = False
    Private NewJob As Boolean = False
    Private NewComp As Boolean = False

    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0

    Private CurrTemplate As String = String.Empty

    Private dtFormData As DataTable = New DataTable("FormData")
    Private dtUserData As DataTable = New DataTable("UserData")
    Private dtAlertReqs As DataTable = New DataTable("AlertReqs")

    Private IsAgencyRequiredEmail As Boolean = False
    Private IsAutoEmailPromptOnNew As Boolean = False
    Private IsAutoEmailPromptOnUpdate As Boolean = False
    Private IsClientGetsEmailOnNew As Boolean = False
    Private IsClientGetsEmailOnUpdate As Boolean = False

#End Region

#Region " Page "

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.JobNum = CType(Request.QueryString("Job"), Integer)
        Me.JobCompNum = CType(Request.QueryString("JobComp"), Integer)

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber

        Me.MyUnityContextMenu.JobNumber = Me.JobNum
        Me.MyUnityContextMenu.JobComponentNumber = Me.JobCompNum
        Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.Print}

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Dim ojob As New Job(Session("ConnString"))
            ojob.GetJob(Me.JobNum, Me.JobCompNum)

            If Not Me.IsPostBack Then

                Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket)

                FillLocationDropDown()

                If Request.QueryString("fromapp") <> "jobsearchmul" Or Session("ProjectScheduleJobCompCount") = 1 Then

                    Me.lblClient.Text = ojob.CL_CODE & " - " & ojob.ClientDesc
                    Me.lblDivision.Text = ojob.DIV_CODE & " - " & ojob.DivisionDesc
                    Me.lblProduct.Text = ojob.PRD_CODE & " - " & ojob.ProductDesc
                    Me.lblJobNum.Text = Me.JobNum.ToString().PadLeft(6, "0")
                    Me.lblJobCompNum.Text = Me.JobCompNum.ToString().PadLeft(2, "0")
                    Me.LabelJobDescription.Text = ojob.JOB_DESC
                    Me.LabelJobComponentDescription.Text = ojob.JobComponent.JOB_COMP_DESC

                    Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
                    Me.cbPrintJobVersions.Text = MyJV.GetAgencyDesc()

                    Session("JobOrderSendClient") = Me.lblClient.Text
                    Session("JobOrderSendDivision") = Me.lblDivision.Text
                    Session("JobOrderSendProduct") = Me.lblProduct.Text

                End If

                Me.cbJobOrderForm.Checked = True

                LoadSettings()

                If Request.QueryString("fromapp") = "jobsearchmul" And Session("ProjectScheduleJobCompCount") <> 1 Then

                    Me.PanelHeader.Visible = False

                End If

            End If
            If Me.IsClientPortal = True Then

                Me.ToolbarRadToolbar.FindItemByValue("SendAssignment").Visible = False

            End If

        Catch ex As Exception

            Me.lbl_msg.Text = "Page_load err: " & ex.Message.ToString

        End Try
    End Sub
    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Select Case Me.CurrentPageMode
            Case PageMode.Print

                Me.Print()

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case PageMode.SendAlert

                Me.SendAlert()

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case PageMode.SendAssignment

                Me.SendAlert(False, True)

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case PageMode.SendEmail

                Me.SendAlert(True, False)

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case Else

        End Select

    End Sub

#End Region

#Region " Controls "

    Private Sub ToolbarRadToolbar_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles ToolbarRadToolbar.ButtonClick
        Select Case e.Item.Value
            Case "Print"

                Me.Print()

            Case "SendAlert"

                Me.SendAlert()

            Case "SendAssignment"

                Me.SendAlert(False, True)

            Case "SendEmail"

                Me.SendAlert(True, False)

            Case "Save"

                Me.SaveSettings()

            Case "Back"

                Me.CloseThisWindow()

        End Select
    End Sub

#End Region

#Region " SubRoutines "

    Private Sub GoBack()
        Session("MSG") = ""
        If PageEdit = False Then
            MiscFN.ResponseRedirect("JobTemplate.aspx")
        Else
            MiscFN.ResponseRedirect("JobTemplate.aspx?PageMode=&JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&NewComp=0")
        End If
    End Sub
    Private Sub PutPageInEdit(Optional ByVal vJobCompNum As Integer = 0)
        Try
            'should redo this to reload page and not reload qs????

            Dim sb As StringBuilder = New StringBuilder
            Dim IsValidQS As Boolean = True
            With sb
                .Append("JobTemplate.aspx?")
                .Append("PageMode=Edit")
                If JobNum = 0 Then
                    If Not Request.QueryString("JobNum") Is Nothing Then
                        .Append("&JobNum=" & Request.QueryString("JobNum"))
                    Else
                        IsValidQS = False
                    End If
                Else
                    .Append("&JobNum=" & JobNum)
                End If
                'If JobCompNum = 0 Then
                '    If Not Request.QueryString("JobCompNum") Is Nothing Then
                '        .Append("&JobCompNum=" & Request.QueryString("JobCompNum"))
                '    Else
                '        IsValidQS = False
                '    End If
                'Else
                .Append("&JobCompNum=" & JobCompNum)
                'End If
                If Not Request.QueryString("NewJob") Is Nothing Then
                    .Append("&NewJob=" & Request.QueryString("NewComp"))
                Else
                    IsValidQS = False
                End If
                If Not Request.QueryString("NewComp") Is Nothing Then
                    .Append("&NewComp=" & Request.QueryString("NewComp"))
                Else
                    IsValidQS = False
                End If
            End With
            'If IsValidQS = True Then
            Response.Redirect(sb.ToString())
            'Else
            '    lblMSG.Text = "Can't go into edit; missing qs vars."
            'End If



        Catch ex As Exception
            Me.lbl_msg.Text = "Error in: PutPageInEdit sub!<br />" & ex.Message.ToString
        Finally
        End Try
    End Sub
    Private Sub FillLocationDropDown()
        Me.dl_location.Items.Clear()
        Dim oReports As cReports = New cReports(CStr(Session("ConnString")))
        Me.dl_location.DataSource = oReports.GetLocationPO
        Me.dl_location.DataTextField = "ID"
        Me.dl_location.DataValueField = "LOGO_PATH"
        Me.dl_location.DataBind()
        Me.dl_location.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
    End Sub
    Private Sub LoadSettings()
        Try
            Dim oReports As New cReports(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim i As Integer
            Dim s As String
            Dim li As New Telerik.Web.UI.RadComboBoxItem
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            dr = oReports.GetJobOrderFormSettings(Session("UserCode"))
            If dr.HasRows = True Then
                Do While dr.Read
                    Try
                        If dr("LOCATION_ID") <> "" And dr("LOCATION_ID") <> "None" Then
                            li = Me.dl_location.FindItemByText(dr("LOCATION_ID") & " - " & PO.GetPO_PrintDef_LocationName(dr("LOCATION_ID")))
                            li.Selected = True
                        Else
                            li = Me.dl_location.FindItemByText("None")
                            li.Selected = True
                        End If

                    Catch ex As Exception

                    End Try

                    s = dr.GetString(11)
                    If s = "0" Then
                        Me.rbReportLeft.Checked = True
                    ElseIf s = "1" Then
                        Me.rbReportRight.Checked = True
                    ElseIf s = "2" Then
                        Me.rbReportCenter.Checked = True
                    Else
                        Me.rbReportLeft.Checked = True
                    End If
                    i = dr.GetInt16(1)
                    If i = 1 Then
                        Me.cbJobOrderForm.Checked = True
                    Else
                        Me.cbJobOrderForm.Checked = False
                    End If
                    i = dr.GetInt16(6)
                    If i = 1 Then
                        Me.cbOmitEmptyFields.Checked = True
                    End If
                    i = dr.GetInt16(17)
                    If i = 1 Then
                        Me.cbTrafficAssignments.Checked = True
                    End If
                    Me.txtTrafficAssignmentsTitle.Text = dr.GetString(18)
                    i = dr.GetInt16(2)
                    If i = 1 Then
                        Me.cbTrafficSchedule.Checked = True
                    End If
                    Me.txtTrafficScheduleTitle.Text = dr.GetString(7)
                    i = dr.GetInt16(4)
                    If i = 1 Then
                        Me.cbDueDatesOnly.Checked = True
                    End If
                    i = dr.GetInt16(3)
                    If i = 1 Then
                        Me.cbMilestonesOnly.Checked = True
                    End If
                    i = dr.GetInt16(5)
                    If i = 1 Then
                        Me.cbEmployeeAssignments.Checked = True
                    End If
                    Me.txtMilestoneTitle.Text = dr.GetString(8)

                    i = dr.GetInt16(13)
                    If i = 1 Then
                        Me.cbPrintCreativeBrief.Checked = True
                    End If
                    i = dr.GetInt16(14)
                    If i = 1 Then
                        Me.cbApproveOnlyCB.Checked = True
                    End If
                    Me.txtReportTitleCB.Text = dr.GetString(9)

                    i = dr.GetInt16(15)
                    If i = 1 Then
                        Me.cbPrintJobSpecs.Checked = True
                    End If
                    i = dr.GetInt16(16)
                    If i = 1 Then
                        Me.cbApprovedOnlyJS.Checked = True
                    End If
                    Me.txtReportTitleJS.Text = dr.GetString(10)

                    i = dr.GetInt16(19)
                    If i = 1 Then
                        Me.cbScheduleComments.Checked = True
                    End If

                    i = dr.GetInt16(20)
                    If i = 1 Then
                        Me.cbIncludeVendorSpecs.Checked = True
                    End If

                    i = dr.GetInt16(21)
                    If i = 1 Then
                        Me.cbIncludeMediaSpecs.Checked = True
                    End If

                    i = dr.GetInt16(22)
                    If i = 1 Then
                        Me.cbPrintJobVersions.Checked = True
                    End If

                    i = dr.GetInt16(23)
                    If i = 1 Then
                        Me.CBOmitEmptyFieldsCB.Checked = True
                    End If

                    i = dr.GetInt16(24)
                    If i = 1 Then
                        Me.CBOmitEmptyFieldsJV.Checked = True
                    End If

                    i = dr.GetInt16(25)
                    If i = 1 Then
                        Me.CBOmitEmptyFieldsJS.Checked = True
                    End If
                Loop
            End If
            'If Not Request.Cookies("jobspecsprint") Is Nothing Then
            '    If Request.Cookies("jobspecsprint")("IncludeVS") <> "" Then
            '        Me.cbIncludeVendorSpecs.Checked = Request.Cookies("jobspecsprint")("IncludeVS")
            '    End If
            '    If Request.Cookies("jobspecsprint")("IncludeMS") <> "" Then
            '        Me.cbIncludeMediaSpecs.Checked = Request.Cookies("jobspecsprint")("IncludeMS")
            '    End If
            'End If
            'If Not Request.Cookies("trafficscheduleprint") Is Nothing Then
            '    If Request.Cookies("trafficscheduleprint")("IncludeTComments") <> "" Then
            '        Me.cbScheduleComments.Checked = Request.Cookies("trafficscheduleprint")("IncludeTComments")
            '    End If
            'End If
            dr.Close()
            If Me.ddReportFormat.SelectedValue = "" Then
                Me.ddSignature.Enabled = False
                Me.TextBoxJobOrderTitle.Enabled = False
                Me.Label6.Enabled = False
                Me.Label7.Enabled = False
                Me.cbUsePrintedDate.Enabled = False
                Me.RadDatePickerPODate.Enabled = False
            End If
            Me.RadDatePickerPODate.SelectedDate = Today()
        Catch ex As Exception
            Me.lbl_msg.Text = "LoadSettings err: " & ex.Message.ToString
        End Try
    End Sub
    Private Sub SaveSettings()
        Try
            Dim oReports As New cReports(Session("ConnString"))
            Dim save As Boolean
            Dim dr As SqlDataReader = oReports.GetUserIDJobOrderFormSettings(Session("UserCode"))
            Dim position As Integer = 0
            If Me.rbReportLeft.Checked = True Then
                position = 0
            ElseIf Me.rbReportRight.Checked = True Then
                position = 1
            ElseIf Me.rbReportCenter.Checked = True Then
                position = 2
            End If

            Dim ar() As String
            Dim str As String = ""
            Dim str2 As String = ""
            If dl_location.SelectedValue <> "[None]" Then
                ar = dl_location.SelectedValue.ToString.Split("|")
                str = ar(1)
                str2 = ar(0)
            Else
                str2 = dl_location.SelectedItem.Text
            End If

            If dr.HasRows = True Then
                save = oReports.UpdateJobOrderFormSettings(Session("UserCode"),
                                                    str2,
                                                    position,
                                                    Me.cbJobOrderForm.Checked,
                                                    Me.cbOmitEmptyFields.Checked,
                                                    Me.cbTrafficAssignments.Checked,
                                                    Me.txtTrafficAssignmentsTitle.Text,
                                                    Me.cbTrafficSchedule.Checked,
                                                    Me.txtTrafficScheduleTitle.Text,
                                                    Me.cbDueDatesOnly.Checked,
                                                    Me.cbMilestonesOnly.Checked,
                                                    Me.txtMilestoneTitle.Text,
                                                    Me.cbEmployeeAssignments.Checked,
                                                    Me.cbPrintCreativeBrief.Checked,
                                                    Me.cbApproveOnlyCB.Checked,
                                                    Me.txtReportTitleCB.Text,
                                                    Me.cbPrintJobSpecs.Checked,
                                                    Me.cbApprovedOnlyJS.Checked,
                                                    Me.txtReportTitleJS.Text,
                                                    Me.cbScheduleComments.Checked,
                                                    Me.cbIncludeVendorSpecs.Checked,
                                                    Me.cbIncludeMediaSpecs.Checked,
                                                    Me.cbPrintJobVersions.Checked,
                                                    Me.CBOmitEmptyFieldsCB.Checked,
                                                    Me.CBOmitEmptyFieldsJV.Checked,
                                                    Me.CBOmitEmptyFieldsJS.Checked)
            Else
                save = oReports.SaveJobOrderFormSettings(Session("UserCode"),
                                                    str2,
                                                    position,
                                                    Me.cbJobOrderForm.Checked,
                                                    Me.cbOmitEmptyFields.Checked,
                                                    Me.cbTrafficAssignments.Checked,
                                                    Me.txtTrafficAssignmentsTitle.Text,
                                                    Me.cbTrafficSchedule.Checked,
                                                    Me.txtTrafficScheduleTitle.Text,
                                                    Me.cbDueDatesOnly.Checked,
                                                    Me.cbMilestonesOnly.Checked,
                                                    Me.txtMilestoneTitle.Text,
                                                    Me.cbEmployeeAssignments.Checked,
                                                    Me.cbPrintCreativeBrief.Checked,
                                                    Me.cbApproveOnlyCB.Checked,
                                                    Me.txtReportTitleCB.Text,
                                                    Me.cbPrintJobSpecs.Checked,
                                                    Me.cbApprovedOnlyJS.Checked,
                                                    Me.txtReportTitleJS.Text,
                                                    Me.cbScheduleComments.Checked,
                                                    Me.cbIncludeVendorSpecs.Checked,
                                                    Me.cbIncludeMediaSpecs.Checked,
                                                    Me.cbPrintJobVersions.Checked,
                                                    Me.CBOmitEmptyFieldsCB.Checked,
                                                    Me.CBOmitEmptyFieldsJV.Checked,
                                                    Me.CBOmitEmptyFieldsJS.Checked)
            End If
            'Response.Cookies("jobspecsprint").Expires = Now.AddYears(1)
            'Response.Cookies("jobspecsprint")("IncludeVS") = Me.cbIncludeVendorSpecs.Checked
            'Response.Cookies("jobspecsprint")("IncludeMS") = Me.cbIncludeMediaSpecs.Checked
            'Response.Cookies("trafficscheduleprint").Expires = Now.AddYears(1)
            'Response.Cookies("trafficscheduleprint")("IncludeTComments") = Me.cbScheduleComments.Checked
            If save = True Then
                'wvMsgBox("Save Successful.")
            Else
                Me.ShowMessage("Save Failed")
            End If
        Catch ex As Exception
            Me.lbl_msg.Text = "SaveSettings err: " & ex.Message.ToString
        End Try
    End Sub
    Private Function OutputReportFileJT(ByVal job As String, ByVal comp As String, ByVal report As String) As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder
            Dim FileType As Integer = 1 'PDF

            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("Temp\")

            sb1.Append("JobOrder_")
            sb1.Append(job)
            sb1.Append("_")
            sb1.Append(comp)
            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            If Not Request.QueryString("Report") Is Nothing Then sbReportName.Append(Request.QueryString("Report"))

            Dim rpt As New popReportViewer

            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            If report = "002" Then
                rpt.renderDoc(sb1.ToString(), "joborder2", "", "", "", "", "", FileType, imgPath)
            ElseIf report = "003" Then
                rpt.renderDoc(sb1.ToString(), "joborder3", "", "", "", "", "", FileType, imgPath)
            Else
                rpt.renderDoc(sb1.ToString(), "joborder", "", "", "", "", "", FileType, imgPath)
            End If

            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function
    Private Function OutputReportFileJSAllVers(ByVal job As String, ByVal comp As String) As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder
            Dim FileType As Integer = 1 'PDF

            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")

            sb1.Append("Specification_")
            sb1.Append(job)
            sb1.Append("_")
            sb1.Append(comp)
            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            Dim rpt As New popReportViewer
            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), "jobspecs", "", "", "", "", "", FileType, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function
    Private Function OutputReportFileJVAllVers(ByVal job As String, ByVal comp As String) As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder
            Dim FileType As Integer = 1 'PDF

            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")

            sb1.Append(Session("JVReportTitle").ToString.Replace("\", "").Replace("/", "") & "_")
            sb1.Append(job)
            sb1.Append("_")
            sb1.Append(comp)
            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            Dim rpt As New popReportViewer

            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), "jobversions", "", "", "", "", "", FileType, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try

    End Function
    Private Function OutputReportFileCB(ByVal job As String, ByVal comp As String) As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder
            Dim FileType As Integer = 1 'PDF

            If job > 0 Then
                Session("CBReportJobNum") = job.ToString.PadLeft(6, "0")
                Session("JobOrderFormJobNum") = job.ToString.PadLeft(6, "0")
            End If
            If comp > 0 Then
                Session("CBReportJobCompNum") = comp.ToString.PadLeft(2, "0")
                Session("JobOrderFormJobCompNum") = comp.ToString.PadLeft(2, "0")
            End If
            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")

            sb1.Append("CreativeBrief_")
            If Session("pagetype") = "cb" Then
                sb1.Append(Session("CBReportJobNum"))
                sb1.Append("_")
                sb1.Append(Session("CBReportJobCompNum"))
            Else
                sb1.Append(Session("JobOrderFormJobNum"))
                sb1.Append("_")
                sb1.Append(Session("JobOrderFormJobCompNum"))
            End If

            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            'sbReportName.Append("CreativeBrief")

            Dim rpt As New popReportViewer

            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), "CreativeBrief", "", "", "", "", "", FileType, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function

    Private Sub Print()

        Dim ar() As String
        Session("IncludeJOFReport") = Me.cbJobOrderForm.Checked
        Session("OmitEFReport") = Me.cbOmitEmptyFields.Checked
        Session("IncludeTAReport") = Me.cbTrafficAssignments.Checked
        Session("TASectionTitle") = Me.txtTrafficAssignmentsTitle.Text
        Session("IncludeTSReport") = Me.cbTrafficSchedule.Checked
        Session("TSSectionTitle") = Me.txtTrafficScheduleTitle.Text
        Session("TSScheduleComments") = Me.cbScheduleComments.Checked
        Session("TSDueDatesOnly") = Me.cbDueDatesOnly.Checked
        Session("TSMilestonesOnly") = Me.cbMilestonesOnly.Checked
        Session("TSMilestoneTitle") = Me.txtMilestoneTitle.Text
        Session("TSEmpAssignments") = Me.cbEmployeeAssignments.Checked

        'Dim aro As New ActiveReportOptions()
        'With aro.Values

        '    .Add("IncludeJOFReport", Me.cbJobOrderForm.Checked)
        '    .Add("OmitEFReport", Me.cbOmitEmptyFields.Checked)
        '    .Add("IncludeTAReport", Me.cbTrafficAssignments.Checked)
        '    .Add("TASectionTitle", Me.txtTrafficAssignmentsTitle.Text)
        '    .Add("IncludeTSReport", Me.cbTrafficSchedule.Checked)
        '    .Add("TSSectionTitle", Me.txtTrafficScheduleTitle.Text)
        '    .Add("TSScheduleComments", Me.cbScheduleComments.Checked)
        '    .Add("TSDueDatesOnly", Me.cbDueDatesOnly.Checked)
        '    .Add("TSMilestonesOnly", Me.cbMilestonesOnly.Checked)
        '    .Add("TSMilestoneTitle", Me.txtMilestoneTitle.Text)
        '    .Add("TSEmpAssignments", Me.cbEmployeeAssignments.Checked)

        'End With

        Try
            If Me.dl_location.SelectedItem.Text = "[None]" Then
                Session("JobOrderFormLogoLocation") = ""
                Session("JobOrderFormLogoLocationID") = "None"
            Else
                ar = dl_location.SelectedValue.ToString.Split("|")
                Session("JobOrderFormLogoLocation") = ar(1)
                Session("JobOrderFormLogoLocationID") = ar(0)
            End If
        Catch ex As Exception
            Session("JobOrderFormLogoLocation") = ""
        End Try

        If Me.rbReportLeft.Checked Then
            Session("JobOrderFormLogoPlacement") = 1
        ElseIf Me.rbReportCenter.Checked Then
            Session("JobOrderFormLogoPlacement") = 2
        ElseIf Me.rbReportRight.Checked Then
            Session("JobOrderFormLogoPlacement") = 3
        Else
            Session("JobOrderFormLogoPlacement") = 1
        End If
        Session("JSPrintSpecs") = Me.cbPrintJobSpecs.Checked
        Session("JSApproveOnly") = Me.cbApprovedOnlyJS.Checked
        Session("JSReportTitle") = Me.txtReportTitleJS.Text
        Session("JSIncludeVS") = Me.cbIncludeVendorSpecs.Checked
        Session("JSIncludeMS") = Me.cbIncludeMediaSpecs.Checked

        'Default sub reports to false
        Session("OmitEmptyFieldsJS") = False 'Job Specs
        Session("OmitEmptyFieldsJV") = False 'Job Versions
        Session("OmitEmptyFieldsCB") = False 'Creative Brief

        Session("JobOrderFormReportTitle") = Me.TextBoxJobOrderTitle.Text
        Session("JobOrderFormSignatureFormat") = Me.ddSignature.SelectedValue

        If Me.cbUsePrintedDate.Checked = True Then
            If Me.RadDatePickerPODate.SelectedDate Is Nothing Then
                Session("JobOrderPrintDate") = ""
            Else
                Session("JobOrderPrintDate") = cGlobals.wvCDate(Me.RadDatePickerPODate.SelectedDate).ToShortDateString()
            End If
        Else
            Session("JobOrderPrintDate") = ""
        End If

        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim drJS As SqlDataReader
        Dim oSQL As SqlHelper
        Dim JobVerHdrID As String
        Dim versionNbr As Integer
        Dim maxRev As Integer
        Dim verCt As Integer
        Dim regScript As String

        Dim js As New Job_Specs(Session("ConnString"))
        Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
        Dim cb As cCreativeBrief = New cCreativeBrief(Session("ConnString"), Session("UserCode"))

        If Not Session("ProjectScheduleJobCompIDS") Is Nothing And Session("ProjectScheduleJobCompIDS") <> "" Then

            Dim filename As String
            Dim filenameJS As String
            Dim filenameJV As String
            Dim filenameCB As String
            Dim count As Integer = Session("ProjectScheduleJobCompCount")
            ''Dim outputStream As New System.IO.MemoryStream
            ''Dim zipOutStream As New ZipOutputStream(outputStream)
            Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
            ''zipOutStream.SetLevel(5) ' Medium compression
            Select Case count
                Case 0

                    Me.ShowMessage("No file(s) selected.")

                Case 1

                    Dim jc() As String = Session("ProjectScheduleJobCompIDS").Split("/")
                    Dim j As String = jc(0)
                    Dim c As String = MiscFN.RemoveTrailingDelimiter(jc(1), ",")
                    Dim strURL As String = "popReportViewer.aspx?job=" & j & "&jobcomp=" & c & "&ms=False&Type=1&Report=TrafficDetailByJob"
                    Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder

                    strBuilder.Append("<script language='javascript'>")
                    strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                    strBuilder.Append("</")
                    strBuilder.Append("script>")
                    Page.RegisterStartupScript("newpage", strBuilder.ToString())

                Case Is > 1

                    Try

                        Dim outputStream As New System.IO.MemoryStream
                        Dim strfiles As String

                        ''Dim RepositorySecuritySettings As New vDocumentRepositorySettings(Session("ConnString"))
                        ''RepositorySecuritySettings.LoadAll()
                        ''Dim ThisUserDomain As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_DOMAIN
                        ''Dim ThisUserName As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_NAME

                        ''Dim ThisUserPassword As String = AdvantageFramework.StringUtilities.RijndaelSimpleDecrypt(RepositorySecuritySettings.DOC_REPOSITORY_USER_PASSWORD)
                        ''Dim ThisPath = RepositorySecuritySettings.DOC_REPOSITORY_PATH

                        ''Dim impersonateUser As Boolean = False
                        ''Dim AliasAccount As AliasAccount
                        ''impersonateUser = ThisUserName <> ""

                        ''If impersonateUser = True Then

                        ''    AliasAccount.BeginImpersonation(ThisUserName, ThisUserDomain, ThisUserPassword)

                        ''End If

                        Dim zip As New ZipFile

                        Dim jc() As String = Session("ProjectScheduleJobCompIDS").Split(",")

                        For i As Integer = 0 To jc.Length - 1

                            Dim jobc As String = ""
                            jobc = jc(i)

                            If jobc <> "" Then

                                Dim jobcomp() As String = jobc.Split("/")

                                Dim ThisJobNumber As Integer = 0
                                Dim ThisJobComponentNbr As Integer = 0

                                If IsNumeric(jobcomp(0)) = True Then
                                    ThisJobNumber = CType(jobcomp(0), Integer)
                                End If
                                If IsNumeric(jobcomp(1)) = True Then
                                    ThisJobComponentNbr = CType(jobcomp(1), Integer)
                                End If

                                Session("JobOrderFormJobNum") = ThisJobNumber
                                Session("JobOrderFormJobCompNum") = ThisJobComponentNbr

                                If ThisJobNumber > 0 AndAlso ThisJobComponentNbr > 0 Then

                                    filename = Me.OutputReportFileJT(ThisJobNumber, ThisJobComponentNbr, Me.ddReportFormat.SelectedValue)

                                    If Me.ddReportFormat.SelectedValue = "" Then
                                        If Me.cbPrintJobSpecs.Checked = True Then
                                            Dim type As String = js.GetJobSpecType(ThisJobNumber, ThisJobComponentNbr)
                                            Session("JSType") = type
                                            Session("OmitEmptyFieldsJS") = Me.CBOmitEmptyFieldsJS.Checked
                                            filenameJS = Me.OutputReportFileJSAllVers(ThisJobNumber, ThisJobComponentNbr)
                                        End If
                                        If Me.cbPrintJobVersions.Checked = True Then
                                            Dim desc As String
                                            desc = MyJV.GetAgencyDesc()
                                            If desc <> "" Then
                                                Session("JVReportTitle") = desc ' & " Report"
                                            End If

                                            Session("OmitEmptyFieldsJV") = Me.CBOmitEmptyFieldsJV.Checked
                                            filenameJV = Me.OutputReportFileJVAllVers(ThisJobNumber, ThisJobComponentNbr)
                                        End If
                                        If cbPrintCreativeBrief.Checked = True Then
                                            Dim reportTit As String
                                            Dim printApprovedOK As Boolean = True

                                            reportTit = Me.txtReportTitleCB.Text
                                            If reportTit = "" Then
                                                Session("CBReportTitle") = "Creative Brief Report"
                                            Else
                                                Session("CBReportTitle") = reportTit
                                            End If

                                            Try
                                                If Me.dl_location.SelectedItem.Text = "None" Then
                                                    Session("CBLogoLocation") = ""
                                                    Session("CBLogoLocationID") = "None"
                                                Else
                                                    ar = dl_location.SelectedValue.ToString.Split("|")
                                                    Session("CBLogoLocation") = ar(1)
                                                    Session("CBLogoLocationID") = ar(0)
                                                End If
                                            Catch ex As Exception
                                                Session("CBLogoLocation") = ""
                                            End Try

                                            If Me.rbReportLeft.Checked Then
                                                Session("CBLogoPlacement") = 1
                                            ElseIf Me.rbReportCenter.Checked Then
                                                Session("CBLogoPlacement") = 2
                                            ElseIf Me.rbReportRight.Checked Then
                                                Session("CBLogoPlacement") = 3
                                            Else
                                                Session("CBLogoPlacement") = 1
                                            End If

                                            If Me.cbApproveOnlyCB.Checked Then

                                                If cb.isApprovedVersion(ThisJobNumber, ThisJobComponentNbr) = False Then

                                                    printApprovedOK = False

                                                End If

                                            End If

                                            Session("OmitEmptyFieldsCB") = Me.CBOmitEmptyFieldsCB.Checked

                                            If printApprovedOK = True Then

                                                filenameCB = Me.OutputReportFileCB(ThisJobNumber, ThisJobComponentNbr)

                                            End If

                                        End If

                                    End If

                                    Dim f As IO.FileInfo
                                    If filename <> "" Then
                                        f = New IO.FileInfo(filename)
                                        If f.Exists Then
                                            zip.AddFile(filename, "")
                                            strfiles &= filename & "|"
                                        End If
                                    End If
                                    If filenameJS <> "" Then
                                        f = New IO.FileInfo(filenameJS)
                                        If f.Exists Then
                                            zip.AddFile(filenameJS, "")
                                            strfiles &= filenameJS & "|"
                                        End If
                                    End If
                                    If filenameJV <> "" Then
                                        f = New IO.FileInfo(filenameJV)
                                        If f.Exists Then
                                            zip.AddFile(filenameJV, "")
                                            strfiles &= filenameJV & "|"
                                        End If
                                    End If
                                    If filenameCB <> "" Then
                                        f = New IO.FileInfo(filenameCB)
                                        If f.Exists Then
                                            zip.AddFile(filenameCB, "")
                                            strfiles &= filenameCB & "|"
                                        End If
                                    End If

                                End If

                            End If

                        Next

                        zip.Save(Response.OutputStream)

                        Dim str() As String = strfiles.Split("|")
                        For x As Integer = 0 To str.Length - 1

                            If str(x) <> "" Then

                                Try
                                    My.Computer.FileSystem.DeleteFile(str(x).Trim)
                                Catch ex As Exception
                                    'lbl_msg.Text = ex.Message.ToString
                                End Try

                                Try
                                    Kill(str(x).Trim)
                                Catch ex As Exception
                                    'lbl_msg.Text = ex.Message.ToString
                                End Try

                            End If

                        Next

                        ' ''If impersonateUser = True Then

                        ' ''    AliasAccount.EndImpersonation()

                        ' ''End If

                        Response.AddHeader("Content-Disposition", "filename=Webvantage_Job_Templates__" & Today.Year.ToString() & Today.Month.ToString() & Today.Day.ToString() & ".zip")
                        Response.ContentType = "application/zip"
                        Response.End()

                    Catch ex As Exception

                        Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

                        If Not Session("ProjectScheduleJobCompIDS") Is Nothing Then

                            Me.ShowMessage("Trying to print jobs: " & AdvantageFramework.StringUtilities.JavascriptSafe(Session("ProjectScheduleJobCompIDS")))

                        End If

                    End Try

            End Select

        End If

        If Me.JobNum > 0 And Me.JobCompNum > 0 Then

            If Me.ddReportFormat.SelectedValue = "002" Or Me.ddReportFormat.SelectedValue = "003" Then

                Dim strURL As String = "popReportViewer.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Type=" & Me.Reporttype1.strReportSelect & "&Report=JobTemplate" & Me.ddReportFormat.SelectedValue
                Response.Redirect(strURL.ToString())

            Else
                'Print Job Specifications
                If Me.cbPrintJobSpecs.Checked = True Then

                    Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
                    Session("JSType") = type
                    Session("OmitEmptyFieldsJS") = Me.CBOmitEmptyFieldsJS.Checked

                    Dim strURL2 As String = "popReportViewer.aspx?page=jobjacket&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Type=" & Me.Reporttype1.strReportSelect & "&Report=JobSpecsAllVersions"

                    Dim strBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder
                    strBuilder2.Append("<script language='javascript'>")
                    strBuilder2.Append("window.open('" & strURL2 & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                    strBuilder2.Append("</")
                    strBuilder2.Append("script>")
                    regScript = "JSPrint" & versionNbr.ToString
                    Page.RegisterStartupScript(regScript, strBuilder2.ToString())

                End If

                'Print Job Versions
                If Me.cbPrintJobVersions.Checked = True Then

                    Dim desc As String
                    desc = MyJV.GetAgencyDesc()
                    If desc <> "" Then
                        Session("JVReportTitle") = desc ' & " Report"
                    End If

                    Session("OmitEmptyFieldsJV") = Me.CBOmitEmptyFieldsJV.Checked

                    Dim strURLJV As String = "popReportViewer.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Report=JobVersions" & "&Type=" & Me.Reporttype1.strReportSelect
                    'Response.Redirect(strURLJV.ToString())

                    Dim strBuilderJV As System.Text.StringBuilder = New System.Text.StringBuilder
                    strBuilderJV.Append("<script language='javascript'>")
                    strBuilderJV.Append("window.open('" & strURLJV & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                    strBuilderJV.Append("</")
                    strBuilderJV.Append("script>")
                    Page.RegisterStartupScript("JVPrintAll", strBuilderJV.ToString())

                End If


                'Print Creative Brief
                If cbPrintCreativeBrief.Checked = True Then

                    'Dim ar() As String
                    Dim reportTit As String
                    Dim printApprovedOK As Boolean = True

                    reportTit = Me.txtReportTitleCB.Text
                    If reportTit = "" Then
                        Session("CBReportTitle") = "Creative Brief Report"
                    Else
                        Session("CBReportTitle") = reportTit
                    End If

                    Try
                        If Me.dl_location.SelectedItem.Text = "None" Then
                            Session("CBLogoLocation") = ""
                            Session("CBLogoLocationID") = "None"
                        Else
                            ar = dl_location.SelectedValue.ToString.Split("|")
                            Session("CBLogoLocation") = ar(1)
                            Session("CBLogoLocationID") = ar(0)
                        End If
                    Catch ex As Exception
                        Session("CBLogoLocation") = ""
                    End Try

                    If Me.rbReportLeft.Checked Then
                        Session("CBLogoPlacement") = 1
                    ElseIf Me.rbReportCenter.Checked Then
                        Session("CBLogoPlacement") = 2
                    ElseIf Me.rbReportRight.Checked Then
                        Session("CBLogoPlacement") = 3
                    Else
                        Session("CBLogoPlacement") = 1
                    End If

                    If Me.cbApproveOnlyCB.Checked Then
                        Dim job, comp As Integer

                        job = Me.JobNum
                        comp = Me.JobCompNum
                        If cb.isApprovedVersion(job, comp) = False Then
                            printApprovedOK = False
                        End If
                    End If

                    Session("OmitEmptyFieldsCB") = Me.CBOmitEmptyFieldsCB.Checked

                    If printApprovedOK = True Then
                        Dim strURLCB As String = "popReportViewer.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Report=CreativeBrief" & "&Type=" & Me.Reporttype1.strReportSelect
                        'Response.Redirect(strURLCB.ToString())
                        Dim strBuilderCB As System.Text.StringBuilder = New System.Text.StringBuilder
                        strBuilderCB.Append("<script language='javascript'>")
                        strBuilderCB.Append("window.open('" & strURLCB & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                        strBuilderCB.Append("</")
                        strBuilderCB.Append("script>")
                        Page.RegisterStartupScript("CBPrint", strBuilderCB.ToString())
                    End If

                End If

                Dim strURL As String = "popReportViewer.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Type=" & Me.Reporttype1.strReportSelect & "&Report=JobTemplate"
                'Response.Redirect(strURL.ToString())
                Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                strBuilder.Append("<script language='javascript'>")
                strBuilder.Append("window.open('" & strURL & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                strBuilder.Append("</")
                strBuilder.Append("script>")
                Page.RegisterStartupScript("newpage", strBuilder.ToString())

            End If

        End If

    End Sub
    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)

        Try

            Dim MultipleIdString As String = ""

            If Not Session("ProjectScheduleJobCompIDS") Is Nothing And Session("ProjectScheduleJobCompIDS") <> "" Then

                MultipleIdString = Session("ProjectScheduleJobCompIDS")

            End If

            Session("JobOrderFormJobNum") = Me.lblJobNum.Text
            Session("JobOrderFormJobCompNum") = Me.lblJobCompNum.Text
            Session("IncludeJOFReport") = Me.cbJobOrderForm.Checked
            Session("OmitEFReport") = Me.cbOmitEmptyFields.Checked
            Session("IncludeTAReport") = Me.cbTrafficAssignments.Checked
            Session("TASectionTitle") = Me.txtTrafficAssignmentsTitle.Text
            Session("IncludeTSReport") = Me.cbTrafficSchedule.Checked
            Session("TSSectionTitle") = Me.txtTrafficScheduleTitle.Text
            Session("TSScheduleComments") = Me.cbScheduleComments.Checked
            Session("TSDueDatesOnly") = Me.cbDueDatesOnly.Checked
            Session("TSMilestonesOnly") = Me.cbMilestonesOnly.Checked
            Session("TSMilestoneTitle") = Me.txtMilestoneTitle.Text
            Session("TSEmpAssignments") = Me.cbEmployeeAssignments.Checked

            Dim ar() As String

            Try
                If Me.dl_location.SelectedItem.Text = "[None]" Then

                    Session("JobOrderFormLogoLocation") = ""
                    Session("JobOrderFormLogoLocationID") = "None"

                Else

                    ar = dl_location.SelectedValue.ToString.Split("|")
                    Session("JobOrderFormLogoLocationID") = ar(0)
                    Session("JobOrderFormLogoLocation") = ar(1)

                End If
            Catch ex As Exception

                Session("JobOrderFormLogoLocation") = ""

            End Try

            If Me.rbReportLeft.Checked Then

                Session("JobOrderFormLogoPlacement") = 1

            ElseIf Me.rbReportCenter.Checked Then

                Session("JobOrderFormLogoPlacement") = 2

            ElseIf Me.rbReportRight.Checked Then

                Session("JobOrderFormLogoPlacement") = 3

            Else

                Session("JobOrderFormLogoPlacement") = 1

            End If
            Session("JSPrintSpecs") = Me.cbPrintJobSpecs.Checked
            Session("JSApproveOnly") = Me.cbApprovedOnlyJS.Checked
            Session("JSReportTitle") = Me.txtReportTitleJS.Text
            Session("JSIncludeVS") = Me.cbIncludeVendorSpecs.Checked
            Session("JSIncludeMS") = Me.cbIncludeMediaSpecs.Checked
            Session("Page") = "jobjacket"

            'Default sub reports to false
            Session("OmitEmptyFieldsJS") = False 'Job Specs
            Session("OmitEmptyFieldsJV") = False 'Job Versions
            Session("OmitEmptyFieldsCB") = False 'Creative Brief

            Session("JobOrderFormReportTitle") = Me.TextBoxJobOrderTitle.Text
            Session("JobOrderFormSignatureFormat") = Me.ddSignature.SelectedValue

            If Me.cbUsePrintedDate.Checked = True Then

                If Me.RadDatePickerPODate.SelectedDate Is Nothing Then

                    Session("JobOrderPrintDate") = ""

                Else

                    Session("JobOrderPrintDate") = cGlobals.wvCDate(Me.RadDatePickerPODate.SelectedDate).ToShortDateString()

                End If

            Else

                Session("JobOrderPrintDate") = ""

            End If

            Dim strURL As String = ""
            Dim EmailSwitch As String = ""

            If AsEmail = True Then

                EmailSwitch = "eml=1&"

            Else

                EmailSwitch = "eml=0&"

            End If
            If IsAssignment = True Then 'assignment switch overrides email switch

                EmailSwitch = "eml=0&assn=1&"

            End If

            Dim MultiSwitch As String = ""
            Dim ThisFrom As Integer = MiscFN.SourceApp_ToInt(MiscFN.Source_App.JobJacket)

            If MultipleIdString <> "" Then

                MultiSwitch = "&mjobs=" & MultipleIdString
                ThisFrom = MiscFN.SourceApp_ToInt(MiscFN.Source_App.JobJacketMultiPrint)
                Session("JobPrintMultiSwitch") = MultipleIdString

            End If

            If Me.ddReportFormat.SelectedValue = "002" Or Me.ddReportFormat.SelectedValue = "003" Then

                If Me.ddReportFormat.SelectedValue = "002" Then

                    Session("JobPrintReport") = "joborder2"

                    strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=JobTemplatePrint&pagetype=jt" & "&j=" &
                        Me.JobNum & "&jc=" & Me.JobCompNum & "&f=" & ThisFrom.ToString() & "&Report=joborder2" & MultiSwitch

                End If
                If Me.ddReportFormat.SelectedValue = "003" Then

                    Session("JobPrintReport") = "joborder3"
                    strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=JobTemplatePrint&pagetype=jt" & "&j=" &
                        Me.JobNum & "&jc=" & Me.JobCompNum & "&f=" & ThisFrom.ToString() & "&Report=joborder3" & MultiSwitch

                End If
                If Request.QueryString("fromapp") = "jobsearchmul" Then

                    strURL = strURL & "&fromapp=jobsearchmul"
                    Session("printjs") = 0
                    Session("printjv") = 0
                    Session("printcb") = 0

                End If

                If IsAssignment = True Then

                    strURL = strURL.Replace("Alert_New.aspx", "Desktop_NewAssignment")
                    Me.OpenWindow("New Assignment", strURL, 0, 1250)

                ElseIf AsEmail = True Then

                    Me.OpenWindow("New Email", strURL, 0, 1000)

                Else

                    Me.OpenWindow("New Alert", strURL, 0, 1000)

                End If

            Else

                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=JobTemplatePrint&pagetype=jt" & "&j=" &
                    Me.JobNum & "&jc=" & Me.JobCompNum & "&f=" & ThisFrom.ToString() & "&Report=joborder" & MultiSwitch

                'Job Order Form
                If Me.cbJobOrderForm.Checked = True Then

                    strURL = strURL & "&printjof=1"

                Else

                    strURL = strURL & "&printjof=0"

                End If
                Session("JobPrintJobOrder") = Me.cbJobOrderForm.Checked
                Session("OmitEmptyFieldsJS") = Me.CBOmitEmptyFieldsJS.Checked

                'Job Specs
                If Me.cbPrintJobSpecs.Checked = True Then

                    strURL = strURL & "&printjs=1"

                Else

                    strURL = strURL & "&printjs=0"

                End If
                Session("JobPrintJobSpecs") = Me.cbPrintJobSpecs.Checked
                Session("OmitEmptyFieldsJS") = Me.CBOmitEmptyFieldsJS.Checked

                'Job Versions
                If Me.cbPrintJobVersions.Checked = True Then

                    strURL = strURL & "&printjv=1"
                    Dim desc As String
                    Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))

                    desc = MyJV.GetAgencyDesc()

                    If desc <> "" Then

                        Session("JVReportTitle") = desc ' & " Report"

                    End If

                Else

                    strURL = strURL & "&printjv=0"

                End If
                Session("JobPrintJobVersions") = Me.cbPrintJobVersions.Checked
                Session("OmitEmptyFieldsJV") = Me.CBOmitEmptyFieldsJV.Checked

                'Creative Brief
                If Me.cbPrintCreativeBrief.Checked = True Then

                    strURL = strURL & "&printcb=1"

                    Dim reportTit As String

                    reportTit = Me.txtReportTitleCB.Text

                    If reportTit = "" Then

                        Session("CBReportTitle") = "Creative Brief Report"

                    Else

                        Session("CBReportTitle") = reportTit

                    End If

                    Try
                        If Me.dl_location.SelectedItem.Text = "None" Then

                            Session("CBLogoLocation") = ""
                            Session("CBLogoLocationID") = "None"

                        Else

                            ar = dl_location.SelectedValue.ToString.Split("|")
                            Session("CBLogoLocation") = ar(1)
                            Session("CBLogoLocationID") = ar(0)

                        End If
                    Catch ex As Exception

                        Session("CBLogoLocation") = ""

                    End Try

                    If Me.rbReportLeft.Checked Then

                        Session("CBLogoPlacement") = 1

                    ElseIf Me.rbReportCenter.Checked Then

                        Session("CBLogoPlacement") = 2

                    ElseIf Me.rbReportRight.Checked Then

                        Session("CBLogoPlacement") = 3

                    Else

                        Session("CBLogoPlacement") = 1

                    End If

                Else

                    strURL = strURL & "&printcb=0"

                End If
                Session("PrintCreativeBrief") = Me.cbPrintCreativeBrief.Checked
                Session("OmitEmptyFieldsCB") = Me.CBOmitEmptyFieldsCB.Checked

                If Request.QueryString("fromapp") = "jobsearchmul" Then

                    strURL = strURL & "&fromapp=jobsearchmul"

                End If

                If IsAssignment = True Then

                    strURL = strURL.Replace("Alert_New.aspx", "Desktop_NewAssignment")
                    Me.OpenWindow("Send Assignment", strURL, 0, 1250)

                ElseIf AsEmail = True Then

                    Me.OpenWindow("Send Email", strURL, 0, 1000)

                Else

                    Me.OpenWindow("Send Alert", strURL, 0, 1000)

                End If

            End If

        Catch ex As Exception

            Me.ShowMessage("err opening print data window")

        End Try

    End Sub

#End Region

#Region " To be refactored to cJobs "

    Private Sub NewCompClick()
        If JobNum > 0 Then
            Dim qs As New AdvantageFramework.Web.QueryString()
            With qs
                .Page = "JobTemplate_NewComponent.aspx"
                .JobNumber = JobNum
                .JobComponentNumber = JobCompNum
            End With
            Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True))
        End If
    End Sub

    Private Sub AppendChangeToAlertSB(ByVal AlertSB As StringBuilder, ByVal ChangedEntity As String, ByVal OriginalData As String, ByVal NewData As String)
        With AlertSB
            .Append(ChangedEntity)
            .Append(vbCrLf)
            .Append("New Value: ")
            .Append(NewData)
            .Append(vbCrLf)
            .Append("Original Value: ")
            .Append(OriginalData)
            .Append(vbCrLf)
            .Append("--------------------------------------")
            .Append(vbCrLf)
        End With
    End Sub

#End Region

    Private Sub ddReportFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddReportFormat.SelectedIndexChanged
        Try
            If Me.ddReportFormat.SelectedValue = "" Then

                Me.ddSignature.Enabled = False
                Me.TextBoxJobOrderTitle.Enabled = False
                Me.Label6.Enabled = False
                Me.Label7.Enabled = False
                Me.cbUsePrintedDate.Enabled = False
                Me.RadDatePickerPODate.Enabled = False
                Me.cbJobOrderForm.Enabled = True
                Me.cbOmitEmptyFields.Enabled = True
                Me.cbTrafficAssignments.Enabled = True
                Me.txtTrafficAssignmentsTitle.Enabled = True
                Me.cbTrafficSchedule.Enabled = True
                Me.txtTrafficScheduleTitle.Enabled = True
                Me.cbMilestonesOnly.Enabled = True
                Me.cbDueDatesOnly.Enabled = True
                Me.cbEmployeeAssignments.Enabled = True
                Me.cbPrintCreativeBrief.Enabled = True
                Me.CBOmitEmptyFieldsCB.Enabled = True
                Me.cbApproveOnlyCB.Enabled = True
                Me.txtReportTitleCB.Enabled = True
                Me.cbPrintJobSpecs.Enabled = True
                Me.CBOmitEmptyFieldsJS.Enabled = True
                Me.cbApprovedOnlyJS.Enabled = True
                Me.cbIncludeVendorSpecs.Enabled = True
                Me.cbIncludeMediaSpecs.Enabled = True
                Me.txtReportTitleJS.Enabled = True
                Me.cbPrintJobVersions.Enabled = True
                Me.CBOmitEmptyFieldsJV.Enabled = True
                Me.cbScheduleComments.Enabled = True
                Me.txtMilestoneTitle.Enabled = True

            Else

                Me.ddSignature.Enabled = True
                Me.TextBoxJobOrderTitle.Enabled = True
                Me.Label6.Enabled = True
                Me.Label7.Enabled = True
                Me.cbUsePrintedDate.Enabled = True
                Me.RadDatePickerPODate.Enabled = True
                Me.cbJobOrderForm.Enabled = False
                Me.cbOmitEmptyFields.Enabled = False
                Me.cbTrafficAssignments.Enabled = False
                Me.txtTrafficAssignmentsTitle.Enabled = False
                Me.cbTrafficSchedule.Enabled = False
                Me.txtTrafficScheduleTitle.Enabled = False
                Me.cbMilestonesOnly.Enabled = False
                Me.cbDueDatesOnly.Enabled = False
                Me.cbEmployeeAssignments.Enabled = False
                Me.cbPrintCreativeBrief.Checked = False
                Me.cbPrintCreativeBrief.Enabled = False
                Me.CBOmitEmptyFieldsCB.Enabled = False
                Me.cbApproveOnlyCB.Enabled = False
                Me.txtReportTitleCB.Enabled = False
                Me.cbPrintJobSpecs.Checked = False
                Me.cbPrintJobSpecs.Enabled = False
                Me.CBOmitEmptyFieldsJS.Enabled = False
                Me.cbApprovedOnlyJS.Enabled = False
                Me.cbIncludeVendorSpecs.Enabled = False
                Me.cbIncludeMediaSpecs.Enabled = False
                Me.txtReportTitleJS.Enabled = False
                Me.cbPrintJobVersions.Checked = False
                Me.cbPrintJobVersions.Enabled = False
                Me.CBOmitEmptyFieldsJV.Enabled = False
                Me.cbScheduleComments.Enabled = False
                Me.txtMilestoneTitle.Enabled = False

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
