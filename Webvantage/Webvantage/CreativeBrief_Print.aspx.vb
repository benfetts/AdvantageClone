Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel
Imports Webvantage.cGlobals

Public Class CreativeBrief_Print
    Inherits Webvantage.BasePrintSendPage

#Region " Private vars: "
    Private JobNum As Integer
    Private JobCompNum As Integer
#End Region

    Private Sub CreativeBriefPrint_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.JobNum = CType(Request.QueryString("Job"), Integer)
        Me.JobCompNum = CType(Request.QueryString("JobComp"), Integer)

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ojob As New Job(Session("ConnString"))

            ojob.GetJob(Me.JobNum, Me.JobCompNum)

            If Not Me.IsPostBack Then

                FillLocationDropDown()

                Me.lblClient.Text = ojob.CL_CODE & " - " & ojob.ClientDesc
                Me.lblDivision.Text = ojob.DIV_CODE & " - " & ojob.DivisionDesc
                Me.lblProduct.Text = ojob.PRD_CODE & " - " & ojob.ProductDesc

                Me.lblJobNum.Text = Me.JobNum.ToString().PadLeft(6, "0")
                Me.lblJobCompNum.Text = Me.JobCompNum.ToString().PadLeft(2, "0")
                Me.LabelJobDescription.Text = ojob.JOB_DESC
                Me.LabelJobComponentDescription.Text = ojob.JobComponent.JOB_COMP_DESC

                LoadSettings()

                'If GridViewFormData.Visible = True Then
                '    With GridViewFormData
                '        .DataSource = getTemplateData(JobNum, JobCompNum)
                '        .DataBind()
                '    End With
                'End If

            End If

        Catch ex As Exception
            Me.lbl_msg.Text = "Page_load err: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub RadToolbarCreativeBriefPrint_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarCreativeBriefPrint.ButtonClick
        Select Case e.Item.Value
            Case "Print"

                Me.Print()

            Case "SendAlert"

                Me.SendAlert()

            Case "SendAssignment"

                Me.SendAlert(False, True)

            Case "SendEmail"

                Me.SendAlert(True, False)

            Case "Back"
                Me.CloseThisWindow()

            Case "Save"
                SaveSettings()

        End Select
    End Sub
    Private Sub Print()

        Dim ar() As String
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

        Session("OmitEmptyFieldsCB") = Me.cbOmitEmptyFields.Checked

        Dim strURL As String = "popReportViewer.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Report=CreativeBrief" & "&Type=" & Me.Reporttype1.strReportSelect
        Response.Redirect(strURL.ToString())

    End Sub
    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)

        Try

            Dim ojob As New Job(Session("ConnString"))
            Dim ar() As String

            Session("CBSendClient") = ojob.CL_CODE
            Session("CBSendDivision") = ojob.DIV_CODE
            Session("CBSendProduct") = ojob.PRD_CODE
            Session("CBReportJobNum") = Me.JobNum
            Session("CBReportJobCompNum") = Me.JobCompNum

            Session("CBJobNum") = Me.lblJobNum.Text
            Session("CBJobCompNum") = Me.lblJobCompNum.Text
            Session("CBReportTitle") = "Creative Brief Report"

            Try
                If Me.dl_location.SelectedItem.Text = "None" Then
                    Session("CBLogoLocationID") = "None"
                    Session("CBLogoLocation") = ""
                Else
                    ar = dl_location.SelectedValue.ToString.Split("|")
                    Session("CBLogoLocationID") = ar(0)
                    Session("CBLogoLocation") = ar(1)
                End If
            Catch ex As Exception
                Session("CBLogoLocation") = ""
                Session("CBLogoLocationID") = "None"
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

            Session("OmitEmptyFieldsCB") = Me.cbOmitEmptyFields.Checked

            Dim EmailSwitch As String = ""
            If AsEmail = True Then

                EmailSwitch = "eml=1&"

            Else

                EmailSwitch = "eml=0&"

            End If
            If IsAssignment = True Then 'assignment switch overrides email switch

                EmailSwitch = "eml=0&assn=1&"

            End If

            Dim strURL As String = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=CreativeBriefPrint&j=" & Me.JobNum & "&jc=" & Me.JobCompNum & "&pagetype=cb" & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.JobJacket)

            If IsAssignment = True Then

                strURL = strURL.Replace("Alert_New.aspx", "Desktop_NewAssignment")
                Me.OpenWindow("New Assignment", strURL)

            Else

                Me.OpenWindow("New Alert", strURL)

            End If

        Catch ex As Exception

            Me.ShowMessage("err opening print data window")

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

        Dim oAppVars As New cAppVars(cAppVars.Application.CREATIVEBRIEF_PRINT)
        oAppVars.getAllAppVars()
        If oAppVars.getAppVar("CBPrint") <> "" Then
            For j As Integer = 0 To Me.dl_location.Items.Count - 1
                If Me.dl_location.Items(j).Text.Contains(oAppVars.getAppVar("CBPrint")) = True Then
                    Me.dl_location.Items(j).Selected = True
                End If
            Next
        End If
    End Sub

    Private Sub dl_location_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles dl_location.SelectedIndexChanged
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.CREATIVEBRIEF_PRINT)
            Dim ar() As String
            Dim str As String = ""
            Dim str2 As String = ""
            If dl_location.SelectedValue <> "[None]" Then
                ar = dl_location.SelectedValue.ToString.Split("|")
                Str = ar(1)
                str2 = ar(0)
            Else
                str2 = dl_location.SelectedItem.Text
            End If
            oAppVars.setAppVarDB("CBPrint", str2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreativeBrief_Print_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

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
        'Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
        'With GridViewFormData
        '    .DataSource = cb.CreativeBriefTmpltData(Me.JobNum, Me.JobCompNum, 0)
        '    .DataBind()
        'End With

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

            Dim oAppVars As New cAppVars(cAppVars.Application.CREATIVEBRIEF_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                .setAppVar("CreativeBriefTitle", Me.txtReportTitleCB.Text)
                .setAppVar("CreativeBriefLocation", dl_location.SelectedValue)
                .setAppVar("CreativeBriefOmitFields", Me.cbOmitEmptyFields.Checked)
                .setAppVar("CreativeBriefLogoPlacement", logoplacement)
                .setAppVar("CreativeBriefOutput", Me.Reporttype1.strReportSelect)
                .SaveAllAppVars()
            End With
        Catch ex As Exception
            Me.ShowMessage("SaveSettings err: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadSettings()
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.CREATIVEBRIEF_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()
            Dim s As String = ""
            s = oAppVars.getAppVar("CreativeBriefTitle")
            If s <> "" Then
                Me.txtReportTitleCB.Text = s
            End If
            s = oAppVars.getAppVar("CreativeBriefLocation")
            If s <> "" Then
                Me.dl_location.SelectedValue = s
            End If
            s = oAppVars.getAppVar("CreativeBriefOmitFields")
            If s <> "" Then
                Me.cbOmitEmptyFields.Checked = s
            End If
            s = oAppVars.getAppVar("CreativeBriefLogoPlacement")
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
            s = oAppVars.getAppVar("CreativeBriefOutput")
            If s <> "" Then
                Me.Reporttype1.strReportSelect = s
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function getTemplateData(ByVal jobNbr As Integer, ByVal jobCompNbr As Int16) As DataTable
        Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
        Dim fontsz1, fontsz2, fontsz3, fontsz4 As String
        Dim fontStyle1, fontStyle2, fontStyle3, fontStyle4, fontstyle As String
        Dim begin1, begin2, begin3, begin4 As String
        Dim end1, end2, end3, end4 As String
        Dim dr1, dr2, dr3, dr4, drCheck1, drCheck2, drCheck3 As SqlDataReader
        Dim dt As New DataTable

        'Try
        '    dt = cb.CreativeBriefTmpltData(jobNbr, jobCompNbr, omitEmptyFields)
        'Catch ex As Exception

        'End Try

        Dim colDesc As DataColumn = New DataColumn("Desc")
        colDesc.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(colDesc)

        Dim colLevel As DataColumn = New DataColumn("Level")
        colLevel.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(colLevel)

        Dim desc1, desc2, desc3, desc4, descCheck As String
        Dim ID1, ID2, ID3, ID4 As Int16

        dr1 = cb.getLevel1Data(jobNbr, jobCompNbr)
        Do While dr1.Read
            Dim drNewRow1 As DataRow = dt.NewRow()

            desc1 = dr1.GetString(1)
            drNewRow1.Item("Desc") = desc1
            drNewRow1.Item("Level") = "1"

            ID1 = dr1.GetInt16(2)
            drCheck1 = cb.getLevel2Data(CStr(ID1), jobNbr, jobCompNbr)

            If Me.cbOmitEmptyFields.Checked = True Then
                Do While drCheck1.Read
                    ID2 = drCheck1.GetInt16(2)
                    Dim drID2 As SqlDataReader = cb.getLevel3Data(CStr(ID2), jobNbr, jobCompNbr)
                    Do While drID2.Read
                        ID3 = drID2.GetInt16(2)
                        Dim drID3 As SqlDataReader = cb.getDetailData(CStr(ID3), jobNbr, jobCompNbr)
                        Do While drID3.Read
                            descCheck = drID3.GetString(1)
                            If descCheck.Trim <> "" Then
                                dt.Rows.Add(drNewRow1)
                                Exit Do
                            End If
                        Loop
                        drID3.Close()
                        Exit Do
                    Loop
                    drID2.Close()
                    Exit Do
                Loop
                drCheck1.Close()
            Else
                dt.Rows.Add(drNewRow1)
            End If

            dr2 = cb.getLevel2Data(CStr(ID1), jobNbr, jobCompNbr)
            Do While dr2.Read
                Dim drNewRow2 As DataRow = dt.NewRow()

                desc2 = dr2.GetString(1)
                drNewRow2.Item("Desc") = desc2
                drNewRow2.Item("Level") = "2"

                ID2 = dr2.GetInt16(2)
                drCheck2 = cb.getLevel3Data(CStr(ID2), jobNbr, jobCompNbr)

                If Me.cbOmitEmptyFields.Checked = True Then
                    Do While drCheck2.Read
                        ID3 = drCheck2.GetInt16(2)
                        Dim dr As SqlDataReader = cb.getDetailData(CStr(ID3), jobNbr, jobCompNbr)
                        Do While dr.Read
                            descCheck = dr.GetString(1)
                            If descCheck.Trim <> "" Then
                                dt.Rows.Add(drNewRow2)
                                Exit Do
                            End If
                        Loop
                        dr.Close()
                        Exit Do
                    Loop
                    drCheck2.Close()
                Else
                    dt.Rows.Add(drNewRow2)
                End If

                dr3 = cb.getLevel3Data(CStr(ID2), jobNbr, jobCompNbr)
                Do While dr3.Read
                    Dim drNewRow3 As DataRow = dt.NewRow()

                    desc3 = dr3.GetString(1)
                    drNewRow3.Item("Desc") = desc3
                    drNewRow3.Item("Level") = "3"

                    ID3 = dr3.GetInt16(2)
                    drCheck3 = cb.getDetailData(CStr(ID3), jobNbr, jobCompNbr)

                    If Me.cbOmitEmptyFields.Checked = True Then
                        Do While drCheck3.Read
                            descCheck = drCheck3.GetString(1)
                            If descCheck.Trim <> "" Then
                                dt.Rows.Add(drNewRow3)
                                Exit Do
                            End If
                        Loop
                        drCheck3.Close()
                    Else
                        dt.Rows.Add(drNewRow3)
                    End If

                    dr4 = cb.getDetailData(CStr(ID3), jobNbr, jobCompNbr)

                    Do While dr4.Read
                        Dim drNewRow4 As DataRow = dt.NewRow()

                        desc4 = dr4.GetString(1)
                        If Me.cbOmitEmptyFields.Checked = True Then
                            If desc4.Trim <> "" Then
                                drNewRow4.Item("Desc") = desc4
                                drNewRow4.Item("Level") = "4"
                                dt.Rows.Add(drNewRow4)
                                ID4 = dr4.GetInt32(0)
                            End If

                        Else
                            drNewRow4.Item("Desc") = desc4
                            drNewRow4.Item("Level") = "4"
                            dt.Rows.Add(drNewRow4)
                            ID4 = dr4.GetInt32(0)
                        End If
                    Loop
                    dr4.Close()
                Loop
                dr3.Close()
            Loop
            dr2.Close()
        Loop
        dr1.Close()
        Return dt

    End Function

End Class
