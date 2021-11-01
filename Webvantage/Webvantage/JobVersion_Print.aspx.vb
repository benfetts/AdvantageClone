Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel

Imports Webvantage.cGlobals

Partial Public Class JobVersion_Print
    Inherits Webvantage.BasePrintSendPage

#Region " Private vars: "
    Private JobNum As Integer
    Private JobCompNum As Integer
    Private JobVerHdrID As Integer
    Private version_nbr As Int16
    Private jobrequest As Boolean = False
#End Region

    Private Sub JobVersionPrint_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.JobNum = CType(Request.QueryString("Job"), Integer)
        Me.JobCompNum = CType(Request.QueryString("JobComp"), Integer)
        Me.JobVerHdrID = CType(Request.QueryString("JobVerHdrID"), Integer)

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber
        If qs.JobVersionHeaderID > 0 Then Me.JobVerHdrID = qs.JobVersionHeaderID
        If qs.JobVersionSequenceNumber > 0 Then Me.version_nbr = qs.JobVersionSequenceNumber
        If qs.Get("fromapp") = "request" Then Me.jobrequest = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ojob As New Job(Session("ConnString"))
            Dim desc As String

            If Me.jobrequest = False Then
                ojob.GetJob(Me.JobNum, Me.JobCompNum)
            End If

            If Not Me.IsPostBack Then
                'Me.CheckAppAccess("Job Version")
                FillLocationDropDown()
                'LoadSettings()

                Me.lblClient.Text = ojob.CL_CODE & " - " & ojob.ClientDesc
                Me.lblDivision.Text = ojob.DIV_CODE & " - " & ojob.DivisionDesc
                Me.lblProduct.Text = ojob.PRD_CODE & " - " & ojob.ProductDesc

                Me.lblJobNum.Text = Me.JobNum.ToString().PadLeft(6, "0")
                Me.lblJobCompNum.Text = Me.JobCompNum.ToString().PadLeft(2, "0")
                Me.LabelJobDescription.Text = ojob.JOB_DESC
                Me.LabelJobComponentDescription.Text = ojob.JobComponent.JOB_COMP_DESC

                Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
                desc = MyJV.GetAgencyDesc()
                Me.Title = "Print " & desc
                Me.hdrID1.Text = desc & " to Print"
                Me.lblversionheader.Text = desc & ":"

                LoadLabels()

                LoadSettings()

                'Me.btn_Send.Attributes.Add("onclick", "window.open('jobtemplatesend.aspx', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=800,height=725,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
            End If



        Catch ex As Exception
            Me.lbl_msg.Text = "Page_load err: " & ex.Message.ToString
        End Try
        If Me.IsClientPortal = True Then

            Me.ToolbarRadToolbar.FindItemByValue("SendAssignment").Visible = False

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

        Dim oAppVars As New cAppVars(cAppVars.Application.JOBVERSIONS)
        oAppVars.getAllAppVars()
        If oAppVars.getAppVar("JVPrint") <> "" Then
            For j As Integer = 0 To Me.dl_location.Items.Count - 1
                If Me.dl_location.Items(j).Text.Contains(oAppVars.getAppVar("JVPrint")) = True Then
                    Me.dl_location.Items(j).Selected = True
                End If
            Next
        End If
    End Sub

    Private Sub dl_location_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles dl_location.SelectedIndexChanged
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.JOBVERSIONS)
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
            oAppVars.setAppVarDB("JVPrint", str2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolbarRadToolbar_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles ToolbarRadToolbar.ButtonClick
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

                SaveSettings()

                'Case "Back"
                '    MiscFN.ResponseRedirect("JobVerTmplt.aspx?JobNum=" & JobNum.ToString() & "&JobCompNum=" & JobCompNum.ToString() & "&JobVerHdrID= " & JobVerHdrID.ToString())

        End Select
    End Sub

    Private Sub LoadLabels()
        Dim jv As New JobVersion(Session("ConnString"))
        Dim dr As SqlDataReader

        'Populate Header
        dr = jv.GetJVDescriptions(JobNum, CType(JobCompNum, Int16), JobVerHdrID)
        '0 JL.JOB_DESC, 1 JC.JOB_COMP_DESC, 2 JVH.JOB_VER_DESC, 3 JVTH.JV_TMPLT_DESC, 4 JVH.JOB_VER_SEQ_NBR, 5 JVH.JV_TMPLT_CODE
        If dr.HasRows Then
            dr.Read()

            'Job Nbr/Desc
            'If IsDBNull(dr.GetString(0)) Then
            '    Me.lblJobNum.Text = Me.JobNum.ToString.PadLeft(6, "0")
            'Else
            '    Me.lblJobNum.Text = Me.JobNum.ToString.PadLeft(6, "0") & " - " & dr.GetString(0)
            'End If

            'Comp Nbr/Desc
            'If IsDBNull(dr.GetString(1)) Then
            '    Me.lblJobCompNum.Text = Me.JobCompNum.ToString.PadLeft(2, "0")
            'Else
            '    Me.lblJobCompNum.Text = Me.JobCompNum.ToString.PadLeft(2, "0") & " - " & dr.GetString(1)
            'End If

            'Job Version Nbr/Desc
            If IsDBNull(dr.GetValue(2)) Then
                Me.lblversion.Text = CType(dr.GetInt16(4), String)
            Else
                Me.lblversion.Text = CType(dr.GetInt16(4), String) & " - " & dr.GetString(2)
            End If
            If IsDBNull(dr.GetString(3)) Then

            Else

                Session("JVTemplateName") = AdvantageFramework.StringUtilities.FileSystemFilenameAndPathSafe(dr.GetString(3))

            End If

            'Job Version Template Code/Desc
            'If IsDBNull(dr.GetString(3)) Then
            '    Me.lblversion.Text = dr.GetString(5)
            'Else
            '    Me.lblversion.Text = dr.GetString(5) & " - " & dr.GetString(3)
            'End If

        End If
    End Sub

    Private Sub Print()
        Dim desc As String
        Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
        Dim ar() As String

        'desc = MyJV.GetAgencyDesc()
        'If desc <> "" Then
        Session("JVReportTitle") = Session("JVTemplateName")
        ' End If

        Try
            If Me.dl_location.SelectedItem.Text = "[None]" Then
                Session("JVLogoLocation") = ""
                Session("JVLogoLocationID") = "None"
            Else
                ar = dl_location.SelectedValue.ToString.Split("|")
                Session("JVLogoLocation") = ar(1)
                Session("JVLogoLocationID") = ar(0)
            End If
        Catch ex As Exception
            Session("JVLogoLocation") = ""
        End Try

        If Me.rbReportLeft.Checked Then
            Session("JVLogoPlacement") = 1
        ElseIf Me.rbReportCenter.Checked Then
            Session("JVLogoPlacement") = 2
        ElseIf Me.rbReportRight.Checked Then
            Session("JVLogoPlacement") = 3
        Else
            Session("JVLogoPlacement") = 1
        End If

        Session("JVOmitEmptyFields") = Me.cbOmitEmptyFields.Checked

        Dim strURL As String = "popReportViewer.aspx?JobNum=" & Me.lblJobNum.Text & "&JobCompNum=" & Me.lblJobCompNum.Text & "&JobVerHdrID=" & Me.JobVerHdrID.ToString() & "&Report=JobVersion" & "&Type=" & Me.Reporttype1.strReportSelect
        'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'strBuilder.Append("<script language='javascript'>")
        'strBuilder.Append("window.open('" & strURL & "', '', 'width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
        'strBuilder.Append("</")
        'strBuilder.Append("script>")
        'Page.RegisterStartupScript("JVPrint", strBuilder.ToString())
        Response.Redirect(strURL.ToString())
    End Sub
    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)
        Dim ojob As New Job(Session("ConnString"))
        Dim desc As String
        Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
        Dim ar() As String

        Session("JobVerSendClient") = ojob.CL_CODE
        Session("JobVerSendDivision") = ojob.DIV_CODE
        Session("JobVerSendProduct") = ojob.PRD_CODE
        Session("JVReportJobNum") = Me.JobNum
        Session("JVReportJobCompNum") = Me.JobCompNum
        Session("JVReportVersion") = Me.version_nbr
        'Session("JVDescription") = Me.VersionDesc.Text
        Session("JVReportTitle") = Session("JVTemplateName")
        Session("JobVerHdrID") = Me.JobVerHdrID
        Session("JVOmitEmptyFields") = Me.cbOmitEmptyFields.Checked
        Session("JVOutputFormat") = Me.Reporttype1.strReportSelect

        Try
            Session("JVJobNum") = Me.lblJobNum.Text
            Session("JVJobCompNum") = Me.lblJobCompNum.Text

            'desc = MyJV.GetAgencyDesc()
            'If desc <> "" Then
            '    Session("JVReportTitle") = desc '& " Report"
            'End If

            Try
                If Me.dl_location.SelectedItem.Text = "[None]" Then
                    Session("JVLogoLocationID") = "None"
                    Session("JVLogoLocation") = ""
                Else
                    ar = dl_location.SelectedValue.ToString.Split("|")
                    Session("JVLogoLocationID") = ar(0)
                    Session("JVLogoLocation") = ar(1)
                End If
            Catch ex As Exception
                Session("JVLogoLocation") = ""
                Session("JVLogoLocationID") = "None"
            End Try

            If Me.rbReportLeft.Checked Then
                Session("JVLogoPlacement") = 1
            ElseIf Me.rbReportCenter.Checked Then
                Session("JVLogoPlacement") = 2
            ElseIf Me.rbReportRight.Checked Then
                Session("JVLogoPlacement") = 3
            Else
                Session("JVLogoPlacement") = 1
            End If

            'Session("JSPage") = "jobversion"
            Dim EmailSwitch As String = ""
            If AsEmail = True Then

                EmailSwitch = "eml=1&"

            Else

                EmailSwitch = "eml=0&"

            End If

            Dim strURL As String
            If IsAssignment = True Then 'assignment switch overrides email switch

                EmailSwitch = "eml=0&assn=1&"
                strURL = "Desktop_NewAssignment?" & EmailSwitch & "send=1&caller=JobVersionPrint&j=" & Me.JobNum & "&jc=" & Me.JobCompNum & "&pagetype=jv" & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.JobJacket)
                Me.OpenWindow("New Assignment", strURL)

            Else

                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=jobversionprint&j=" & Me.JobNum & "&jc=" & Me.JobCompNum & "&pagetype=jv" & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.JobJacket)
                Me.OpenWindow("New Alert", strURL)

            End If

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
                If Request.QueryString("content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If


            Case PageMode.SendAssignment

                Me.SendAlert(False, True)
                If Request.QueryString("content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case PageMode.SendEmail

                Me.SendAlert(True, False)
                If Request.QueryString("content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

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

            Dim oAppVars As New cAppVars(cAppVars.Application.JOBVERSIONS_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                .setAppVar("JobVersionLocation", dl_location.SelectedValue)
                .setAppVar("JobVersionOmitFields", Me.cbOmitEmptyFields.Checked)
                .setAppVar("JobVersionLogoPlacement", logoplacement)
                .setAppVar("JobVersionOutput", Me.Reporttype1.strReportSelect)
                .SaveAllAppVars()
            End With
        Catch ex As Exception
            Me.ShowMessage("SaveSettings err: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadSettings()
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.JOBVERSIONS_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()
            Dim s As String = ""
            s = oAppVars.getAppVar("JobVersionLocation")
            If s <> "" Then
                Me.dl_location.SelectedValue = s
            End If
            s = oAppVars.getAppVar("JobVersionOmitFields")
            If s <> "" Then
                Me.cbOmitEmptyFields.Checked = s
            End If
            s = oAppVars.getAppVar("JobVersionLogoPlacement")
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
            s = oAppVars.getAppVar("JobVersionOutput")
            If s <> "" Then
                Me.Reporttype1.strReportSelect = s
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
