Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient
Imports System.Drawing

Public Class arptJobTemplate002
    Public MyDT As DataTable
    Public dsBudget As DataSet
    Public dtSchedule As DataTable
    Public dtAgency As DataTable
    Public dtComments As DataTable
    Public dtData As DataTable
    Public JobNum As Integer
    Public JobCompNum As Integer
    Public JobDate As String
    Public Client As String
    Public AE As String
    Public desc As String
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
    Public mConnectionString As String
    Public UserCode As String
    Public rptType As String
    Public signature As String
    Private trafficScheduleSubReport As arptJobTrafficSchedule002 = Nothing
    Public CultureCode As String = "en-US"
    Public _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

    Private Sub arptJobTemplate_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Try
            dtData = getTemplateData(JobNum, JobCompNum)
            Me.DataSource = dtData

            'Create StyleSheets for Textboxes
            Dim cb As New cCreativeBrief(mConnectionString, UserCode)
            Dim fontsz1, fontsz2, fontsz3, fontsz4 As String
            Dim fontStyle1, fontStyle2, fontStyle3, fontStyle4 As String

            cb.getfontInfo(JobNum, JobCompNum, 1, fontsz1, fontStyle1, fontsz2, fontStyle2, fontsz3, fontStyle3, fontsz4, fontStyle4)
            'cb.getfontInfo(JobNum, JobCompNum, 2, fontsz2, fontStyle2)
            'cb.getfontInfo(JobNum, JobCompNum, 3, fontsz3, fontStyle3)
            'cb.getfontInfo(JobNum, JobCompNum, 4, fontsz4, fontStyle4)

            Me.StyleSheet.Add("MyStyle1")
            Me.StyleSheet("MyStyle1").FontName = "Arial"
            Me.StyleSheet("MyStyle1").FontSize = getFontsize(fontsz1)
            If InStr(fontStyle1, "italic") Then
                Me.StyleSheet("MyStyle1").FontItalic = True
            End If
            If InStr(fontStyle1, "bold") Then
                Me.StyleSheet("MyStyle1").FontBold = True
            End If
            If InStr(fontStyle1, "underline") Then
                Me.StyleSheet("MyStyle1").FontUnderline = True
            End If

            Me.StyleSheet.Add("MyStyle2")
            Me.StyleSheet("MyStyle2").FontName = "Arial"
            Me.StyleSheet("MyStyle2").FontSize = getFontsize(fontsz2)
            If InStr(fontStyle2, "italic") Then
                Me.StyleSheet("MyStyle2").FontItalic = True
            End If
            If InStr(fontStyle2, "bold") Then
                Me.StyleSheet("MyStyle2").FontBold = True
            End If
            If InStr(fontStyle2, "underline") Then
                Me.StyleSheet("MyStyle2").FontUnderline = True
            End If

            Me.StyleSheet.Add("MyStyle3")
            Me.StyleSheet("MyStyle3").FontName = "Arial"
            Me.StyleSheet("MyStyle3").FontSize = getFontsize(fontsz3)
            If InStr(fontStyle3, "italic") Then
                Me.StyleSheet("MyStyle3").FontItalic = True
            End If
            If InStr(fontStyle3, "bold") Then
                Me.StyleSheet("MyStyle3").FontBold = True
            End If
            If InStr(fontStyle3, "underline") Then
                Me.StyleSheet("MyStyle3").FontUnderline = True
            End If

            Me.StyleSheet.Add("MyStyle4")
            Me.StyleSheet("MyStyle4").FontName = "Arial"
            Me.StyleSheet("MyStyle4").FontSize = getFontsize(fontsz4)
            If InStr(fontStyle4, "italic") Then
                Me.StyleSheet("MyStyle4").FontItalic = True
            End If
            If InStr(fontStyle4, "bold") Then
                Me.StyleSheet("MyStyle4").FontBold = True
            End If
            If InStr(fontStyle4, "underline") Then
                Me.StyleSheet("MyStyle4").FontUnderline = True
            End If

            If Me.printJobOrderForm = False Then
                Me.GroupHeader3.Visible = False
                Me.GroupFooter3.Visible = False
                Me.Detail1.Visible = False
            End If
            If Me.dtSchedule.Rows.Count = 0 Then
                Me.GroupFooter1.Visible = False
            End If
        Catch ex As Exception

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
            Dim cb As New cCreativeBrief(mConnectionString, UserCode)
            Dim fontsz1, fontsz2, fontsz3, fontsz4 As String
            Dim fontStyle1, fontStyle2, fontStyle3, fontStyle4, fontstyle As String

            'Me.TextBox1.Visible = False
            'Me.TextBox2.Visible = False
            'Me.TextBox3.Visible = False
            'Me.TextBox4.Visible = False

            cb.getfontInfo(JobNum, JobCompNum, 1, fontsz1, fontStyle1, fontsz2, fontStyle2, fontsz3, fontStyle3, fontsz4, fontStyle4)
            'cb.getfontInfo(JobNum, JobCompNum, 2, fontsz2, fontStyle2)
            'cb.getfontInfo(JobNum, JobCompNum, 3, fontsz3, fontStyle3)
            'cb.getfontInfo(JobNum, JobCompNum, 4, fontsz4, fontStyle4)

            Select Case Me.level.Text
                Case Is = "1"
                    Me.TextBox1.Visible = True
                    Me.TextBox2.Text = ""
                    Me.TextBox3.Text = ""
                    Me.TextBox4.Text = ""
                    Me.TextBox1.ClassName = "MyStyle1"

                    If InStr(fontStyle1, "bullit") Then
                        Me.TextBox1.Text = " • " & Me.TextBox1.Text
                    End If

                Case Is = "2"
                    Me.TextBox2.Visible = True
                    Me.TextBox2.Text = Me.TextBox2.Text.Trim
                    Me.TextBox1.Text = ""
                    Me.TextBox3.Text = ""
                    Me.TextBox4.Text = ""
                    Me.TextBox2.ClassName = "MyStyle2"

                    If InStr(fontStyle2, "bullit") Then
                        Me.TextBox2.Text = " • " & Me.TextBox2.Text
                    End If

                Case Is = "3"
                    Me.TextBox3.Visible = True
                    Me.TextBox3.Text = Me.TextBox3.Text.Trim
                    Me.TextBox2.Text = ""
                    Me.TextBox1.Text = ""
                    Me.TextBox4.Text = ""
                    Me.TextBox3.ClassName = "MyStyle3"

                    If InStr(fontStyle3, "bullit") Then
                        Me.TextBox3.Text = " • " & Me.TextBox3.Text
                    End If

                Case Is = "4"
                    Me.TextBox4.Visible = True
                    Me.TextBox2.Text = ""
                    Me.TextBox3.Text = ""
                    Me.TextBox1.Text = ""
                    Me.TextBox4.ClassName = "MyStyle4"

                    If InStr(fontStyle4, "bullit") Then
                        'Me.TextBox4.Text = " • " & Me.TextBox4.Text
                        If Me.TextBox4.Text.Contains(vbCrLf) Then
                            Dim str() As String = Me.TextBox4.Text.Split(vbCrLf)
                            Me.TextBox4.Text = ""
                            For i As Integer = 0 To str.Length - 1
                                str(i).Replace(vbCrLf, "")
                                Me.TextBox4.Text = Me.TextBox4.Text & " • " & str(i).Trim & vbCrLf
                            Next
                        Else
                            Me.TextBox4.Text = " • " & Me.TextBox4.Text
                        End If

                    End If
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            Me.TextBoxJob.Text = Me.JobNum.ToString.PadLeft(6, "0") & "-" & Me.JobCompNum.ToString.PadLeft(2, "0")
            Me.TextBoxDate.Text = JobDate
            Me.TextBoxClient.Text = Client
            Me.TextBoxAE.Text = AE
            Me.TextBoxDescription.Text = desc
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Try
            If signature = "1" Then
                Me.TextBoxAgencyApproval.Text = ""
                Me.TextBoxDateAgency.Text = ""
                Me.Line1.Visible = False
                Me.Line2.Visible = False
            End If
            If signature = "2" Then
                Me.txtClientApprovalText.Text = ""
                Me.TextboxDateClient.Text = ""
                Me.Line6.Visible = False
                Me.Line7.Visible = False
            End If
            If signature = "4" Then
                Me.GroupFooter1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.BeforePrint
        'If Me.omitEmptyFields = True And Me.txtfieldValue.Text = "" Then
        '    Me.txtShortDesc.Visible = False
        'End If
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format

    End Sub

    Private Sub GroupFooter2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.BeforePrint
        Try
            If Me.TextBoxExpenses.Text <> "" Then
                Me.TextBoxExpenses.Text = String.Format("{0:#,##0.00}", CDec(Me.TextBoxExpenses.Text))
            End If
            If Me.TextBoxAgencyFees.Text <> "" Then
                Me.TextBoxAgencyFees.Text = String.Format("{0:#,##0.00}", CDec(Me.TextBoxAgencyFees.Text))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Try
            If rptType = "002" Then
                Me.TextBoxExpensesLabel.Text = ""
                Me.TextBoxExpenses.Text = ""
                If dsBudget.Tables(0).Rows.Count > 0 Then
                    If dsBudget.Tables(0).Rows(0)(0) = 1 Then
                        If dsBudget.Tables(1).Rows.Count > 0 Then
                            Me.TextBoxAgencyFees.Text = dsBudget.Tables(1).Rows(0)(0)
                        End If
                    ElseIf dsBudget.Tables(4).Rows(0)(0) = 1 Then
                        If dsBudget.Tables(5).Rows.Count > 0 Then
                            Me.TextBoxAgencyFees.Text = dsBudget.Tables(5).Rows(0)(0)
                        End If
                    End If
                End If
            End If
            If rptType = "003" Then
                If dsBudget.Tables(0).Rows(0)(0) = 1 Then
                    If dsBudget.Tables(2).Rows.Count > 0 Then
                        Me.TextBoxAgencyFees.Text = dsBudget.Tables(2).Rows(0)(0)
                    End If
                    If dsBudget.Tables(3).Rows.Count > 0 Then
                        Me.TextBoxExpenses.Text = dsBudget.Tables(3).Rows(0)(0)
                    End If
                ElseIf dsBudget.Tables(4).Rows(0)(0) = 1 Then
                    If dsBudget.Tables(6).Rows.Count > 0 Then
                        Me.TextBoxAgencyFees.Text = dsBudget.Tables(6).Rows(0)(0)
                    End If
                    If dsBudget.Tables(7).Rows.Count > 0 Then
                        Me.TextBoxExpenses.Text = dsBudget.Tables(7).Rows(0)(0)
                    End If
                End If
                
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.Format
        Try
            If Me.trafficScheduleSubReport Is Nothing Then
                Me.trafficScheduleSubReport = New arptJobTrafficSchedule002
                Me.trafficScheduleSubReport.DueDateOnly = Me.dueDatesOnlyTS
                Me.trafficScheduleSubReport.MilestoneOnly = True
                Me.trafficScheduleSubReport.EmployeeAssigned = Me.employeeAssignmentsTS
                Me.trafficScheduleSubReport.ScheduleComment = Me.scheduleCommentTS
                Me.trafficScheduleSubReport.CultureCode = Me.CultureCode
                Me.trafficScheduleSubReport.dtTS = Me.dtSchedule
                Me.srTrafficSchedule.Report = Me.trafficScheduleSubReport
                'If Me.milestonesOnlyTS = True Then
                '    Dim j As Integer
                '    Dim count As Integer
                '    For j = 0 To Me.dtSchedule.Rows.Count - 1
                '        If j <= Me.dtSchedule.Rows.Count - 1 Then
                '            If Me.dtSchedule.Rows(j).Item(8).ToString = "0" Then
                '                Me.dtSchedule.Rows.Remove(Me.dtSchedule.Rows(j))
                '                'count -= 1
                '                j -= 1
                '            End If
                '        End If
                '    Next
                '    Me.srTrafficSchedule.Report.DataSource = dtSchedule
                'Else
                Me.srTrafficSchedule.Report.DataSource = dtSchedule
                '    Me.lblMilestoneTitle.Text = ""
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.Format
        Try
            
        Catch ex As Exception

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

            Me.txtReportTitle.Text = ReportTitle
            If Me.LogoPlacement = 1 Then
                Me.txtReportTitle.Alignment = TextAlignment.Left
            ElseIf Me.LogoPlacement = 2 Then
                Me.txtReportTitle.Alignment = TextAlignment.Center
            ElseIf Me.LogoPlacement = 3 Then
                Me.txtReportTitle.Alignment = TextAlignment.Right
            Else
                Me.txtReportTitle.Alignment = TextAlignment.Left
            End If
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

        End Try
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PageFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
       
    End Sub

    Public Function getTemplateData(ByVal jobNbr As Integer, ByVal jobCompNbr As Int16) As DataTable
        Dim cb As New cCreativeBrief(mConnectionString, UserCode)
        Dim fontsz1, fontsz2, fontsz3, fontsz4 As String
        Dim fontStyle1, fontStyle2, fontStyle3, fontStyle4, fontstyle As String
        Dim begin1, begin2, begin3, begin4 As String
        Dim end1, end2, end3, end4 As String
        Dim dr1, dr2, dr3, dr4 As SqlDataReader
        Dim dt As New DataTable

        Dim colDesc As DataColumn = New DataColumn("Desc")
        colDesc.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(colDesc)

        Dim colLevel As DataColumn = New DataColumn("Level")
        colLevel.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(colLevel)

        Dim desc1, desc2, desc3, desc4 As String
        Dim ID1, ID2, ID3, ID4 As Int16

        dr1 = cb.getLevel1Data(jobNbr, jobCompNbr)
        Do While dr1.Read
            Dim drNewRow1 As DataRow = dt.NewRow()

            desc1 = dr1.GetString(1)
            drNewRow1.Item("Desc") = desc1
            drNewRow1.Item("Level") = "1"
            dt.Rows.Add(drNewRow1)

            ID1 = dr1.GetInt16(2)

            dr2 = cb.getLevel2Data(CStr(ID1), jobNbr, jobCompNbr)
            Do While dr2.Read
                Dim drNewRow2 As DataRow = dt.NewRow()

                desc2 = dr2.GetString(1)
                drNewRow2.Item("Desc") = desc2
                drNewRow2.Item("Level") = "2"
                dt.Rows.Add(drNewRow2)

                ID2 = dr2.GetInt16(2)

                dr3 = cb.getLevel3Data(CStr(ID2), jobNbr, jobCompNbr)
                Do While dr3.Read
                    Dim drNewRow3 As DataRow = dt.NewRow()

                    desc3 = dr3.GetString(1)
                    drNewRow3.Item("Desc") = desc3
                    drNewRow3.Item("Level") = "3"
                    dt.Rows.Add(drNewRow3)

                    ID3 = dr3.GetInt16(2)

                    dr4 = cb.getDetailData(CStr(ID3), jobNbr, jobCompNbr)
                    Do While dr4.Read
                        Dim drNewRow4 As DataRow = dt.NewRow()

                        desc4 = dr4.GetString(1)
                        If omitEmptyFields = True Then
                            If desc4 <> "" Then
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
                Loop
            Loop
        Loop
        Return dt

    End Function

    Private Function getFontsize(ByVal sz As String) As Single
        Dim sizeF As Single = 8.0F

        Select Case sz
            Case "8"
                sizeF = 8.0F
            Case "9"
                sizeF = 9.0F
            Case "10"
                sizeF = 10.0F
            Case "11"
                sizeF = 11.0F
            Case "12"
                sizeF = 12.0F
        End Select
        Return sizeF
    End Function

    Private Sub ReportFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        Try

            If signature = "1" Then
                Me.TextBoxAgencyApproval.Text = ""
                Me.TextBoxDateAgency.Text = ""
                Me.Line1.Visible = False
                Me.Line2.Visible = False
            End If
            If signature = "2" Then
                Me.txtClientApprovalText.Text = ""
                Me.TextboxDateClient.Text = ""
                Me.Line6.Visible = False
                Me.Line7.Visible = False
            End If
            If signature = "4" Then
                Me.TextBoxAgencyApproval.Text = ""
                Me.TextBoxDateAgency.Text = ""
                Me.Line1.Visible = False
                Me.Line2.Visible = False
                Me.txtClientApprovalText.Text = ""
                Me.TextboxDateClient.Text = ""
                Me.Line6.Visible = False
                Me.Line7.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
