Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel

Imports Webvantage.cGlobals

Partial Public Class JobSpecs_Print
    Inherits Webvantage.BasePrintSendPage

#Region " Private vars: "
    Private JobNum As Integer
    Private JobCompNum As Integer
    Private versionNum As Integer
    Private revisionNum As Integer
#End Region

    Private Sub JobSpecPrint_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.JobNum = CType(Request.QueryString("JobNum"), Integer)
        Me.JobCompNum = CType(Request.QueryString("JobCompNum"), Integer)
        Me.versionNum = CType(Request.QueryString("version"), Integer)
        Me.revisionNum = CType(Request.QueryString("revision"), Integer)

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber
        If qs.VersionID > 0 Then Me.versionNum = qs.VersionID
        If qs.RevisionID > 0 Then Me.revisionNum = qs.RevisionID

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim ojob As New Job(Session("ConnString"))
            Dim desc As String

            ojob.GetJob(JobNum, JobCompNum)

            If Not Me.IsPostBack Then
                'Me.CheckAppAccess("JobSpecs")
                FillLocationDropDown()

                If Request.QueryString("client") = "" Then
                    Me.lblClient.Text = ojob.CL_CODE & " - " & ojob.ClientDesc
                Else
                    Me.lblClient.Text = Request.QueryString("client")
                End If
                If Request.QueryString("division") = "" Then
                    Me.lblDivision.Text = ojob.DIV_CODE & " - " & ojob.DivisionDesc
                Else
                    Me.lblDivision.Text = Request.QueryString("division")
                End If
                If Request.QueryString("product") = "" Then
                    Me.lblProduct.Text = ojob.PRD_CODE & " - " & ojob.ProductDesc
                Else
                    Me.lblProduct.Text = Request.QueryString("product")
                End If
                Me.lblJobNum.Text = Me.JobNum.ToString.PadLeft(6, "0")
                Me.lblJobCompNum.Text = Me.JobCompNum.ToString.PadLeft(2, "0")
                Me.LabelJobDescription.Text = ojob.JOB_DESC
                Me.LabelJobComponentDescription.Text = ojob.JobComponent.JOB_COMP_DESC

                Me.lblversion.Text = Me.versionNum.ToString
                Me.lblrevision.Text = Me.revisionNum.ToString

                Me.hdrID1.Text = "Job Specifications to Print"

                LoadSettings()

            End If

        Catch ex As Exception
            Me.lbl_msg.Text = "Page_load err: " & ex.Message.ToString
        End Try
        If Me.IsClientPortal = True Then

            Me.RadToolbarJobSpecsPrint.FindItemByValue("SendAssignment").Visible = False

        End If

    End Sub

    Private Sub FillLocationDropDown()
        Me.dl_location.Items.Clear()
        Dim oReports As cReports = New cReports(CStr(Session("ConnString")))
        Me.dl_location.DataSource = oReports.GetLocationPO
        Me.dl_location.DataTextField = "ID"
        Me.dl_location.DataValueField = "LOGO_PATH"
        Me.dl_location.DataBind()
        Me.dl_location.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))

        Dim oAppVars As New cAppVars(cAppVars.Application.JOBSPECS)
        oAppVars.getAllAppVars()
        If oAppVars.getAppVar("JSPrint") <> "" Then
            For j As Integer = 0 To Me.dl_location.Items.Count - 1
                If Me.dl_location.Items(j).Text.Contains(oAppVars.getAppVar("JSPrint")) = True Then
                    Me.dl_location.Items(j).Selected = True
                End If
            Next
        End If
    End Sub

    Private Sub dl_location_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles dl_location.SelectedIndexChanged
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.JOBSPECS)
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
            oAppVars.setAppVarDB("JSPrint", str2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarJobSpecsPrint_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarJobSpecsPrint.ButtonClick
        Select Case e.Item.Value
            Case "Print"

                Me.Print()

            Case "SendEmail"

                Me.SendAlert(True, False)

            Case "SendAlert"

                Me.SendAlert()

            Case "SendAssignment"

                Me.SendAlert(False, True)

            Case "Back"

                MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum.ToString() & "&JobCompNum=" & JobCompNum.ToString())
                Exit Sub

            Case "Save"
                SaveSettings()

        End Select
    End Sub

    Private Sub Print()
        Dim ar() As String

        'Session("JSReportTitle") = "Job Specification Report"
        Session("JSOmitEmptyFields") = Me.cbOmitEmptyFields.Checked

        Try
            If Me.dl_location.SelectedItem.Text = "[None]" Then
                Session("JSLogoLocation") = ""
                Session("JSLogoLocationID") = "None"
            Else
                ar = dl_location.SelectedValue.ToString.Split("|")
                Session("JSLogoLocation") = ar(1)
                Session("JSLogoLocationID") = ar(0)
            End If
        Catch ex As Exception
            Session("JSLogoLocation") = ""
        End Try

        If Me.rbReportLeft.Checked Then
            Session("JSLogoPlacement") = 1
        ElseIf Me.rbReportCenter.Checked Then
            Session("JSLogoPlacement") = 2
        ElseIf Me.rbReportRight.Checked Then
            Session("JSLogoPlacement") = 3
        Else
            Session("JSLogoPlacement") = 1
        End If

        Session("JSReportTitle") = Me.txtReportTitle.Text

        Dim strURL As String = "popReportViewer.aspx?JobNum=" & Me.lblJobNum.Text & "&JobCompNum=" & Me.lblJobCompNum.Text & "&version=" & Me.lblversion.Text & "&revision=" & Me.lblrevision.Text & "&Report=JobSpecs" & "&Type=" & Me.Reporttype1.strReportSelect
        'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'strBuilder.Append("<script language='javascript'>")
        'strBuilder.Append("window.open('" & strURL & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
        'strBuilder.Append("</")
        'strBuilder.Append("script>")
        'Page.RegisterStartupScript("JSPrint", strBuilder.ToString())
        Response.Redirect(strURL.ToString())

    End Sub
    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)

        Dim ojob As New Job(Session("ConnString"))

        Session("JobSpecSendClient") = ojob.CL_CODE
        Session("JobSpecSendDivision") = ojob.DIV_CODE
        Session("JobSpecSendProduct") = ojob.PRD_CODE
        Session("JSReportJobNum") = Me.JobNum
        Session("JSReportJobCompNum") = Me.JobCompNum
        Session("JSReportVersion") = Me.versionNum
        Session("JSReportRevision") = Me.revisionNum
        Session("JSOmitEmptyFields") = Me.cbOmitEmptyFields.Checked

        Try
            Session("JSJobNum") = Me.lblJobNum.Text
            Session("JSJobCompNum") = Me.lblJobCompNum.Text

            Dim ar() As String
            Try
                If Me.dl_location.SelectedItem.Text = "[None]" Then
                    Session("JSLogoLocation") = ""
                    Session("JSLogoLocationID") = "None"
                Else
                    ar = dl_location.SelectedValue.ToString.Split("|")
                    Session("JSLogoLocationID") = ar(0)
                    Session("JSLogoLocation") = ar(1)
                End If
            Catch ex As Exception
                Session("JSLogoLocation") = ""
            End Try

            If Me.rbReportLeft.Checked Then
                Session("JSLogoPlacement") = 1
            ElseIf Me.rbReportCenter.Checked Then
                Session("JSLogoPlacement") = 2
            ElseIf Me.rbReportRight.Checked Then
                Session("JSLogoPlacement") = 3
            Else
                Session("JSLogoPlacement") = 1
            End If

            'Session("JSPage") = "jobspec"
            Dim EmailSwitch As String = ""
            If AsEmail = True Then

                EmailSwitch = "eml=1&"

            Else

                EmailSwitch = "eml=0&"

            End If
            If IsAssignment = True Then 'assignment switch overrides email switch

                EmailSwitch = "eml=0&assn=1&"

            End If

            Dim strURL As String = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=JobSpecPrint&j=" & Me.JobNum & "&jc=" & Me.JobCompNum & "&pagetype=js" & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.JobJacket)
            Me.OpenWindow("New Alert", strURL)
        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try

    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Select Case Me.CurrentPageMode
            Case PageMode.Print

                Me.Print()
                Me.CloseThisWindow()

            Case PageMode.SendAlert

                Me.SendAlert()
                Me.CloseThisWindow()

            Case PageMode.SendAssignment

                Me.SendAlert(False, True)
                Me.CloseThisWindow()

            Case PageMode.SendEmail

                Me.SendAlert(True, False)
                Me.CloseThisWindow()

            Case Else

        End Select

    End Sub

    Private Sub SaveSettings()
        Try
            Dim logoplacement As Integer
            If Me.rbReportLeft.Checked Then
                logoplacement = 1
            ElseIf Me.rbReportCenter.Checked Then
                logoplacement = 2
            ElseIf Me.rbReportRight.Checked Then
                logoplacement = 3
            Else
                logoplacement = 1
            End If

            Dim oAppVars As New cAppVars(cAppVars.Application.JOBSPECS_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                .setAppVar("JobSpecsTitle", Me.txtReportTitle.Text)
                .setAppVar("JobSpecsLocation", dl_location.SelectedValue)
                .setAppVar("JobSpecsOmitFields", Me.cbOmitEmptyFields.Checked)
                .setAppVar("JobSpecsLogoPlacement", logoplacement)
                .setAppVar("JobSpecsOutput", Me.Reporttype1.strReportSelect)
                .SaveAllAppVars()
            End With
        Catch ex As Exception
            Me.ShowMessage("SaveSettings err: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadSettings()
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.JOBSPECS_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()
            Dim s As String = ""
            s = oAppVars.getAppVar("JobSpecsTitle")
            If s <> "" Then
                Me.txtReportTitle.Text = s
            End If
            s = oAppVars.getAppVar("JobSpecsLocation")
            If s <> "" Then
                Me.dl_location.SelectedValue = s
            End If
            s = oAppVars.getAppVar("JobSpecsOmitFields")
            If s <> "" Then
                Me.cbOmitEmptyFields.Checked = s
            End If
            s = oAppVars.getAppVar("JobSpecsLogoPlacement")
            If s <> "" Then
                If s = "1" Then
                    Me.rbReportLeft.Checked = True
                End If
                If s = "2" Then
                    Me.rbReportCenter.Checked = True
                End If
                If s = "3" Then
                    Me.rbReportRight.Checked = True
                End If
            End If
            s = oAppVars.getAppVar("JobSpecsOutput")
            If s <> "" Then
                Me.Reporttype1.strReportSelect = s
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
