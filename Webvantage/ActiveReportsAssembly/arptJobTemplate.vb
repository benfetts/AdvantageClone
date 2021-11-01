Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Drawing

Public Class arptJobTemplate
    Public MyDT As DataTable
    Public dtTraffic As DataTable
    Public dtTrafficLabels As DataTable
    Public dtSchedule As DataTable
    Public dtAgency As DataTable
    Public dtComments As DataTable
    Public dtData As DataTable
    Public JobNum As Integer
    Public JobCompNum As Integer
    Public printJobOrderForm As Boolean
    Public omitEmptyFields As Boolean
    Public includeTA As Boolean
    Public sectionTitleTA As String
    Public includeTS As Boolean
    Public scheduleCommentTS As Boolean
    Public sectionTitleTS As String
    Public dueDatesOnlyTS As Boolean
    Public milestonesOnlyTS As Boolean
    Public milestoneTitle As String
    Public employeeAssignmentsTS As Boolean
    Public ReportTitle As String
    Public imgPath As String
    Public LogoPath As String
    Public LogoPlacement As Integer
    Public LogoID As String
    Public Reporter As String
    Public rushJob As Short
    Private trafficScheduleSubReport As arptJobTrafficSchedule = Nothing
    Public CultureCode As String = "en-US"
    Public _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

    Private Sub arptJobTemplate_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Try
            If Me.omitEmptyFields = True Then
                Dim j As Integer
                Dim count As Integer
                For j = 0 To Me.MyDT.Rows.Count - 1
                    If j <= Me.MyDT.Rows.Count - 1 Then
                        If Me.MyDT.Rows(j).Item(11).ToString = "" And Me.MyDT.Rows(j).Item(12).ToString = "" And Me.MyDT.Rows(j).Item(1).ToString <> "S" Then
                            Me.MyDT.Rows.Remove(Me.MyDT.Rows(j))
                            'count -= 1
                            j -= 1
                        End If
                    End If
                Next
                Me.DataSource = MyDT
            Else
                Me.DataSource = MyDT
            End If

            If Me.printJobOrderForm = False Then
                Me.GroupHeader3.Visible = False
                Me.GroupFooter3.Visible = False
                Me.Detail1.Visible = False
            End If
            If Me.includeTA = False Then
                Me.lblTrafficAssignments.Text = ""
                Me.lblCW.Text = ""
                Me.lblAC.Text = ""
                Me.lblTM.Text = ""
                Me.lblAD.Text = ""
                Me.lblBM.Text = ""
                Me.txtCW.Text = ""
                Me.txtAC.Text = ""
                Me.txtTM.Text = ""
                Me.txtAD.Text = ""
                Me.txtBM.Text = ""
                Me.Line4.Visible = False
                Me.GroupFooter2.Visible = False
            End If
            If Me.includeTS = False Then
                Me.lblTrafficSchedule.Visible = False
                Me.srTrafficSchedule.Visible = False
                Me.lblMilestoneTitle.Visible = False
                Me.Line5.Visible = False
            End If
            If Me.dtSchedule.Rows.Count = 0 Then
                Me.GroupFooter1.Visible = False
            End If
            If Me.dtTraffic.Rows.Count = 0 Then
                Me.txtCW.Text = ""
                Me.txtAC.Text = ""
                Me.txtTM.Text = ""
                Me.txtAD.Text = ""
                Me.txtBM.Text = ""
                'Me.GroupFooter2.Visible = False
            End If
        Catch ex As Exception
            Me.lblTrafficSchedule.Text = "jobtemplatereport: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        'If Me.omitEmptyFields = True And Me.txtfieldValue.Text = "" Then
        '    Me.txtLongDesc.Visible = False
        '    Me.txtfieldValue.Visible = False
        'End If

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            If Me.lblItemType2.Text = "S" Then
                Me.txtSDesc.Text = ""
                Me.txtfieldValue.Text = ""
            Else
                Me.txtSDesc.Text = Me.txtSDesc.Text & ":"
                If Me.txtfieldDesc.Text = "" Then
                    Me.txtfieldValue.Text = Me.txtfieldValue.Text.Replace("&nbsp;", " ")
                ElseIf Me.txtfieldValue.Text.Contains("&nbsp;") Then
                    Me.txtfieldValue.Text = Me.txtfieldValue.Text.Replace("&nbsp;", " ")
                ElseIf Me.txtLong.Text.Trim = "Client Reference" Then
                    Me.txtfieldValue.Text = Me.txtfieldValue.Text
                ElseIf Me.txtfieldValue.Text = "" And Me.txtfieldDesc.Text <> "" Then
                    Me.txtfieldValue.Text = Me.txtfieldDesc.Text
                Else
                    If Me.txtItemCode.Text.Contains("CL_CODE") = True OrElse
                        Me.txtItemCode.Text.Contains("DIV_CODE") = True OrElse
                        Me.txtItemCode.Text.Contains("PRD_CODE") = True Then

                        Me.txtfieldValue.Text = Me.txtfieldValue.Text.Replace("&nbsp;", " ")

                    Else

                        Me.txtfieldValue.Text = Me.txtfieldValue.Text.Replace("&nbsp;", " ").Replace("-", "") & " - " & Me.txtfieldDesc.Text

                    End If
                End If
            End If
            If Me.txtItemCode.Text.Contains("UDV") = True Then
                Me.txtfieldValue.Text = Me.txtfieldDesc.Text
            End If
            Me.lblRush.Visible = False

            If Me.txtLong.Text.Trim = "Job Number" Then
                Me.txtfieldValue.Text = Me.txtfieldValue.Text.PadLeft(6, "0")
                If rushJob = 1 Then
                    Me.lblRush.Visible = True
                End If
            End If

            If Me.txtLong.Text.Trim = "Job Opened By" Then
                Dim values As String()
                Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-US")
                Dim info As CultureInfo = New CultureInfo(Me.CultureCode)

                values = Me.txtfieldValue.Text.Split("-")

                If values.Length = 2 Then
                    Dim parsedDate As Date = Date.ParseExact(values(1).Trim, "MM/dd/yyyy", ci)
                    Me.txtfieldValue.Text = values(0).Trim & " - " & parsedDate.ToString(info.DateTimeFormat.ShortDatePattern)
                End If

            End If

            If Me.txtLong.Text.Trim = "Total Job Budget" And Me.txtfieldValue.Text <> "" Then
                If dtData.Rows.Count > 0 Then
                    If IsDBNull(dtData.Rows(0)("TOTAL_JOB_BUDGET")) = False Then
                        Me.txtfieldValue.Text = CDec(dtData.Rows(0)("TOTAL_JOB_BUDGET"))
                    End If
                Else
                    Me.txtfieldValue.Text = ReportFunctions.FormatDecimal(Me.txtfieldValue.Text)
                End If
            End If
            If Me.txtLong.Text.Trim = "Budget" And Me.txtfieldValue.Text <> "" Then
                If dtData.Rows.Count > 0 Then
                    If IsDBNull(dtData.Rows(0)("JOB_COMP_BUDGET_AM")) = False Then
                        Me.txtfieldValue.Text = CDec(dtData.Rows(0)("JOB_COMP_BUDGET_AM"))
                    End If
                Else
                    Me.txtfieldValue.Text = ReportFunctions.FormatDecimal(Me.txtfieldValue.Text)
                End If
            End If
            If Me.txtLong.Text.Trim = "Markup Pct" And Me.txtfieldValue.Text <> "" Then
                Me.txtfieldValue.Text = ReportFunctions.FormatDecimal(Me.txtfieldValue.Text)
            End If
            If Me.txtLong.Text.Trim = "Budget:" And Me.txtfieldValue.Text <> "" Then
                Me.txtfieldValue.Text = String.Format("{0:#,###0.00}", Convert.ToDecimal(Me.txtfieldValue.Text))
            End If
            If Me.txtLong.Text.Trim = "Rush Charges Approved" And Me.txtfieldValue.Text.Trim = "1" Then
                Me.txtfieldValue.Text = "Yes"
            ElseIf Me.txtLong.Text.Trim = "Rush Charges Approved" And Me.txtfieldValue.Text.Trim = "0" Then
                Me.txtfieldValue.Text = "No"
            End If
            If Me.txtLong.Text.Trim = "Approved Estimate Required" And Me.txtfieldValue.Text.Trim = "1" Then
                Me.txtfieldValue.Text = "Yes"
            ElseIf Me.txtLong.Text.Trim = "Approved Estimate Required" And Me.txtfieldValue.Text.Trim = "0" Then
                Me.txtfieldValue.Text = "No"
            End If
            If Me.txtLong.Text.Trim = "Traffic Schedule Needed" And Me.txtfieldValue.Text.Trim = "1" Then
                Me.txtfieldValue.Text = "Yes"
            ElseIf Me.txtLong.Text.Trim = "Traffic Schedule Needed" And Me.txtfieldValue.Text.Trim = "0" Then
                Me.txtfieldValue.Text = "No"
            End If
            If Me.txtLong.Text.Trim = "Layout - Thumbnail" And Me.txtfieldValue.Text.Trim = "1" Then
                Me.txtfieldValue.Text = "Yes"
            ElseIf Me.txtLong.Text.Trim = "Layout - Thumbnail" And Me.txtfieldValue.Text.Trim = "0" Then
                Me.txtfieldValue.Text = "No"
            End If
            If Me.txtLong.Text.Trim = "Layout - Comp" And Me.txtfieldValue.Text.Trim = "1" Then
                Me.txtfieldValue.Text = "Yes"
            ElseIf Me.txtLong.Text.Trim = "Layout - Comp" And Me.txtfieldValue.Text.Trim = "0" Then
                Me.txtfieldValue.Text = "No"
            End If
            If Me.txtLong.Text.Trim = "Layout - Rough" And Me.txtfieldValue.Text.Trim = "1" Then
                Me.txtfieldValue.Text = "Yes"
            ElseIf Me.txtLong.Text.Trim = "Layout - Rough" And Me.txtfieldValue.Text.Trim = "0" Then
                Me.txtfieldValue.Text = "No"
            End If
            If Me.txtLong.Text.Trim = "Layout - None" And Me.txtfieldValue.Text.Trim = "1" Then
                Me.txtfieldValue.Text = "Yes"
            ElseIf Me.txtLong.Text.Trim = "Layout - None" And Me.txtfieldValue.Text.Trim = "0" Then
                Me.txtfieldValue.Text = "No"
            End If
            If Me.txtLong.Text.Trim = "Layout - Special" And Me.txtfieldValue.Text.Trim = "1" Then
                Me.txtfieldValue.Text = "Yes"
            ElseIf Me.txtLong.Text.Trim = "Layout - Special" And Me.txtfieldValue.Text.Trim = "0" Then
                Me.txtfieldValue.Text = "No"
            End If
            If Me.txtLong.Text.Trim = "Is Job Component Non-Billable" And Me.txtfieldValue.Text.Trim = "1" Then
                Me.txtfieldValue.Text = "Yes"
            ElseIf Me.txtLong.Text.Trim = "Is Job Component Non-Billable" And Me.txtfieldValue.Text.Trim = "0" Then
                Me.txtfieldValue.Text = "No"
            End If
            If Me.txtLong.Text.Trim = "Taxable" And Me.txtfieldValue.Text.Trim = "1" Then
                Me.txtfieldValue.Text = "Yes"
            ElseIf Me.txtLong.Text.Trim = "Taxable" And Me.txtfieldValue.Text.Trim = "0" Then
                Me.txtfieldValue.Text = "No"
            End If
            If Me.txtLong.Text.Trim = "Job Comment" Then
                If dtComments.Rows(0)("JOB_COMMENTS_HTML").ToString = "" Then
                    Me.txtfieldValue.Text = dtComments.Rows(0)("JOB_COMMENTS").ToString.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
                Else
                    Me.txtfieldValue.Html = dtComments.Rows(0)("JOB_COMMENTS_HTML").ToString.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
                    Me.txtfieldValue.Html = ReportFunctions.WrapRtfInFontTag(Me.txtfieldValue.Html)
                End If
            End If
            If Me.txtLong.Text.Trim = "Component Comments" Then
                If dtComments.Rows(0)("JC_COMMENTS_HTML").ToString = "" Then
                    Me.txtfieldValue.Text = dtComments.Rows(0)("JOB_COMP_COMMENTS").ToString.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
                Else
                    Me.txtfieldValue.Html = dtComments.Rows(0)("JC_COMMENTS_HTML").ToString.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
                    Me.txtfieldValue.Html = ReportFunctions.WrapRtfInFontTag(Me.txtfieldValue.Html)
                End If
            End If
            If Me.txtLong.Text.Trim = "Creative Instructions" Then
                If dtComments.Rows(0)("CREATIVE_INSTR_HTML").ToString = "" Then
                    Me.txtfieldValue.Text = dtComments.Rows(0)("CREATIVE_INSTR").ToString.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
                Else
                    Me.txtfieldValue.Html = dtComments.Rows(0)("CREATIVE_INSTR_HTML").ToString.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
                    Me.txtfieldValue.Html = ReportFunctions.WrapRtfInFontTag(Me.txtfieldValue.Html)
                End If
            End If
            If Me.txtLong.Text.Trim = "Shipping Instructions" Then
                If dtComments.Rows(0)("JOB_DEL_INSTR_HTML").ToString = "" Then
                    Me.txtfieldValue.Text = dtComments.Rows(0)("JOB_DEL_INSTRUCT").ToString.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
                Else
                    Me.txtfieldValue.Html = dtComments.Rows(0)("JOB_DEL_INSTR_HTML").ToString.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
                    Me.txtfieldValue.Html = ReportFunctions.WrapRtfInFontTag(Me.txtfieldValue.Html)
                End If
            End If
            If Me.txtItemCode.Text.Trim() = "JOB_COMPONENT.JOB_PROCESS_CONTRL" Or Me.txtItemCode.Text.Trim() = "SERVICE_FEE_TYPE_ID" Then
                Me.txtfieldValue.Text = Me.txtfieldDesc.Text
            End If
            If Me.txtLong.Text.Trim = "Date Opened" Then
                If Me.txtfieldValue.Text <> "" Then
                    Me.txtfieldValue.Text = CDate(ReportFunctions.FormatDate(Me.txtfieldValue.Text)).ToShortDateString
                End If
            End If
            If Me.txtLong.Text.Trim = "Start Date" Then
                If Me.txtfieldValue.Text <> "" Then
                    Me.txtfieldValue.Text = CDate(ReportFunctions.FormatDate(Me.txtfieldValue.Text)).ToShortDateString
                End If
            End If
            If Me.txtLong.Text.Trim = "Due Date" Then
                If Me.txtfieldValue.Text <> "" Then
                    Me.txtfieldValue.Text = CDate(ReportFunctions.FormatDate(Me.txtfieldValue.Text)).ToShortDateString
                End If
            End If
        Catch ex As Exception
            Me.lblTrafficSchedule.Text = "jobtemplatereport: " & ex.Message.ToString
        End Try

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            Me.Label1.Text = ReportTitle
            If Me.LogoPlacement = 1 Then
                Me.Label1.Alignment = TextAlignment.Left
            ElseIf Me.LogoPlacement = 2 Then
                Me.Label1.Alignment = TextAlignment.Center
            ElseIf Me.LogoPlacement = 3 Then
                Me.Label1.Alignment = TextAlignment.Right
            Else
                Me.Label1.Alignment = TextAlignment.Left
            End If
        Catch ex As Exception
            Me.lblTrafficSchedule.Text = "jobtemplatereport: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Try
            If Me.sectionTitleTS = "" Then
                Me.lblTrafficSchedule.Text = "Traffic Schedule"
            Else
                Me.lblTrafficSchedule.Text = Me.sectionTitleTS
            End If

            If Me.trafficScheduleSubReport Is Nothing Then
                Me.trafficScheduleSubReport = New arptJobTrafficSchedule
                Me.trafficScheduleSubReport.DueDateOnly = Me.dueDatesOnlyTS
                Me.trafficScheduleSubReport.MilestoneOnly = Me.milestonesOnlyTS
                Me.trafficScheduleSubReport.EmployeeAssigned = Me.employeeAssignmentsTS
                Me.trafficScheduleSubReport.ScheduleComment = Me.scheduleCommentTS
                Me.trafficScheduleSubReport.CultureCode = Me.CultureCode
                Me.trafficScheduleSubReport.dtTS = Me.dtSchedule
                Me.srTrafficSchedule.Report = Me.trafficScheduleSubReport
                If Me.milestonesOnlyTS = True Then
                    Dim j As Integer
                    Dim count As Integer
                    For j = 0 To Me.dtSchedule.Rows.Count - 1
                        If j <= Me.dtSchedule.Rows.Count - 1 Then
                            If Me.dtSchedule.Rows(j).Item(8).ToString = "0" Then
                                Me.dtSchedule.Rows.Remove(Me.dtSchedule.Rows(j))
                                'count -= 1
                                j -= 1
                            End If
                        End If
                    Next
                    Me.srTrafficSchedule.Report.DataSource = dtSchedule
                    If Me.milestoneTitle = "" Then
                        Me.lblMilestoneTitle.Text = "Milestones"
                    Else
                        Me.lblMilestoneTitle.Text = Me.milestoneTitle
                    End If

                Else
                    Me.srTrafficSchedule.Report.DataSource = dtSchedule
                    Me.lblMilestoneTitle.Text = ""
                End If
            End If
        Catch ex As Exception
            Me.lblTrafficSchedule.Text = "jobtemplatereport: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub GroupHeader2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.BeforePrint
        'If Me.omitEmptyFields = True And Me.txtfieldValue.Text = "" Then
        '    Me.txtShortDesc.Visible = False
        'End If
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format

    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Try
            Dim i As Integer
            If Me.includeTA = True Then
                For i = 0 To dtTrafficLabels.Rows.Count - 1
                    If dtTrafficLabels.Rows(i).Item(0).ToString.EndsWith("1") Then
                        Me.lblCW.Text = dtTrafficLabels.Rows(i).Item(1).ToString & ":"
                    End If
                    If dtTrafficLabels.Rows(i).Item(0).ToString.EndsWith("2") Then
                        Me.lblAC.Text = dtTrafficLabels.Rows(i).Item(1).ToString & ":"
                    End If
                    If dtTrafficLabels.Rows(i).Item(0).ToString.EndsWith("3") Then
                        Me.lblTM.Text = dtTrafficLabels.Rows(i).Item(1).ToString & ":"
                    End If
                    If dtTrafficLabels.Rows(i).Item(0).ToString.EndsWith("4") Then
                        Me.lblAD.Text = dtTrafficLabels.Rows(i).Item(1).ToString & ":"
                    End If
                    If dtTrafficLabels.Rows(i).Item(0).ToString.EndsWith("5") Then
                        Me.lblBM.Text = dtTrafficLabels.Rows(i).Item(1).ToString & ":"
                    End If
                Next
                For i = 0 To dtTraffic.Rows.Count - 1
                    Dim name As String = dtTraffic.Rows(i).Item(1).ToString & " "
                    If dtTraffic.Rows(i).Item(2).ToString = "" Then
                        name = name & dtTraffic.Rows(i).Item(3).ToString
                    Else
                        name = name & dtTraffic.Rows(i).Item(2).ToString & ". " & dtTraffic.Rows(i).Item(3).ToString
                    End If
                    If dtTraffic.Rows(i).Item(4).ToString = "1" Then
                        Me.txtCW.Text = name
                    End If
                    If dtTraffic.Rows(i).Item(4).ToString = "2" Then
                        Me.txtAC.Text = name
                    End If
                    If dtTraffic.Rows(i).Item(4).ToString = "3" Then
                        Me.txtTM.Text = name
                    End If
                    If dtTraffic.Rows(i).Item(4).ToString = "4" Then
                        Me.txtAD.Text = name
                    End If
                    If dtTraffic.Rows(i).Item(4).ToString = "5" Then
                        Me.txtBM.Text = name
                    End If
                Next
            End If
            If Me.sectionTitleTA = "" Then
                Me.lblTrafficAssignments.Text = "Traffic Assignments"
            Else
                Me.lblTrafficAssignments.Text = Me.sectionTitleTA
            End If
        Catch ex As Exception
            Me.lblTrafficSchedule.Text = "jobtemplatereport: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub GroupFooter3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.Format

    End Sub

    Private Sub GroupHeader3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.Format
        Try
            If Me.lblItemType.Text <> "S" Then
                Me.txtShortDesc.Text = ""
            End If
        Catch ex As Exception
            Me.lblTrafficSchedule.Text = "jobtemplatereport: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try


            If _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                    Using img As Image = System.Drawing.Image.FromStream(MemoryStream)

                        Dim bm As Bitmap

                        bm = New Bitmap(img)

                        Me.Picture1.Image = bm

                    End Using

                End Using

            Else

                If Me.LogoPath <> "" Then
                    Dim f As New IO.FileInfo(Me.LogoPath)
                    If f.Exists Then
                        Me.Picture1.Image = Drawing.Image.FromFile(Me.LogoPath)
                    Else
                        Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                    End If
                Else
                    Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                End If

            End If

            'If Me.LogoPlacement = 1 Then
            '    Me.Picture1.PictureAlignment = PictureAlignment.TopLeft
            'ElseIf Me.LogoPlacement = 2 Then
            '    Me.Picture1.PictureAlignment = PictureAlignment.Center
            'ElseIf Me.LogoPlacement = 3 Then
            '    Me.Picture1.PictureAlignment = PictureAlignment.TopRight
            'Else
            '    Me.Picture1.PictureAlignment = PictureAlignment.TopLeft
            'End If
            If Me.LogoID = "None" Then
                Me.PageHeader1.Visible = False
            End If

            Dim str3 As String
            If Me.dtAgency.Rows.Count > 0 And Me.LogoID <> "None" And Me.dtAgency.Rows(0)("PRT_HEADER").ToString = "1" Then

                If Me.dtAgency.Rows(0)("PRT_NAME").ToString = "1" Then
                    If Me.dtAgency.Rows(0)("NAME").ToString <> "" Then
                        Me.txtAgencyName.Text = Me.dtAgency.Rows(0)("NAME")
                    Else
                        Me.txtAgencyName.Text = ""
                    End If
                Else
                    Me.txtAgencyName.Text = ""
                End If

                If Me.dtAgency.Rows(0)("PRT_ADDR1").ToString = "1" And Me.dtAgency.Rows(0)("ADDRESS1").ToString <> "" Then
                    str3 = Me.dtAgency.Rows(0)("ADDRESS1").ToString & " • "
                End If
                If Me.dtAgency.Rows(0)("PRT_ADDR2").ToString = "1" And Me.dtAgency.Rows(0)("ADDRESS2").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("ADDRESS2").ToString & " • "
                End If
                If Me.dtAgency.Rows(0)("PRT_CITY").ToString = "1" And Me.dtAgency.Rows(0)("CITY").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("CITY").ToString & ", "
                End If
                If Me.dtAgency.Rows(0)("PRT_STATE").ToString = "1" And Me.dtAgency.Rows(0)("STATE").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("STATE").ToString & "  "
                End If
                If Me.dtAgency.Rows(0)("PRT_ZIP").ToString = "1" And Me.dtAgency.Rows(0)("ZIP").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("ZIP").ToString & " • "
                End If
                If Me.dtAgency.Rows(0)("PRT_PHONE").ToString = "1" And Me.dtAgency.Rows(0)("PHONE").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("PHONE").ToString & " • "
                End If
                If Me.dtAgency.Rows(0)("PRT_FAX").ToString = "1" And Me.dtAgency.Rows(0)("FAX").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("FAX").ToString & " Fax • "
                End If
                If Me.dtAgency.Rows(0)("PRT_EMAIL").ToString = "1" And Me.dtAgency.Rows(0)("EMAIL").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("EMAIL").ToString
                End If
                Me.txtAgencyInfo.Text = str3
            Else
                Me.txtAgencyName.Text = ""
                Me.txtAgencyInfo.Text = ""
            End If
            'If Me.LogoPlacement = 1 Then
            '    Me.txtAgencyName.Alignment = TextAlignment.Left
            '    Me.txtAgencyInfo.Alignment = TextAlignment.Left
            'ElseIf Me.LogoPlacement = 2 Then
            '    Me.txtAgencyName.Alignment = TextAlignment.Center
            '    Me.txtAgencyInfo.Alignment = TextAlignment.Center
            'ElseIf Me.LogoPlacement = 3 Then
            '    Me.txtAgencyName.Alignment = TextAlignment.Right
            '    Me.txtAgencyInfo.Alignment = TextAlignment.Right
            'Else
            '    Me.txtAgencyName.Alignment = TextAlignment.Left
            '    Me.txtAgencyInfo.Alignment = TextAlignment.Left
            'End If
        Catch ex As Exception
            Me.lblTrafficSchedule.Text = "jobtemplatereport: " & ex.Message.ToString
        End Try
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PageFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
        Try
            Me.lblEmp.Text = "by " & Reporter
        Catch ex As Exception
            Me.lblTrafficSchedule.Text = "jobtemplatereport: " & ex.Message.ToString
        End Try

    End Sub
End Class
