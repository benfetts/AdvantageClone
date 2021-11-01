Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports Webvantage
Imports System.Data.SqlClient
Imports System
Imports System.Drawing
Imports Microsoft.VisualBasic

Public Class arptCreativeBrief 
    Public dtData As DataTable
    Public description As String
    Public version As String
    Public client As String
    Public division As String
    Public product As String
    Public cl_code, div_code, prd_code As String
    Public job, jobDesc As String
    Public jobcomp, compDesc As String
    Public jobNbr As Integer
    Public jobCompNbr As Int16
    Public imgPath As String
    Public ReportTitle As String
    Public Reporter As String
    Public LogoPath As String
    Public LogoPlacement As Integer
    Public LogoID As String
    Public dtAgency As DataTable
    Public RTBText As String
    Public fld As New Field
    Public mConnectionString As String
    Public UserCode As String
    Public omitEmptyFields As Boolean = False

    Private CLIENT_REF, ACCT_EXEC, TEAM, CAMPAIGN_CODE, CAMPAIGN_NAME, OPENED_BY, CDP_ADDR, CDP_ADDR2, CDP_ADDR3 As String
    Private BUDGET As Decimal
    Private JOB_DATE_OPENED, JOB_FIRST_USE_DATE, JOB_COMP_DATE As Date
    Private JOB_ESTIMATE_REQ, JOB_RUSH_CHARGES As Int16
    Private CAMPAIGN_ID As Integer

    Private SHOW_CLIENT, SHOW_CLIENT_REF, SHOW_DIVISION, SHOW_PRODUCT, SHOW_CL_ADDRESS, SHOW_DIV_ADDRESS, SHOW_PRD_ADDRESS As Int16
    Private SHOW_JOB_NUMBER, SHOW_JOB_DESC, SHOW_JOB_COMP_NBR, SHOW_JOB_COMP_DESC, SHOW_ACCT_EXEC, SHOW_BUDGET As Int16
    Private SHOW_TEAM, SHOW_DATE_OPENED, SHOW_CAMPAIGN, SHOW_APPRV_EST_REQ, SHOW_RUSH_CHGS_OK, SHOW_DUE_DATE, SHOW_OPENED_BY As Int16

    Private CBSubreportHeader1 As arptCBHeader1 = Nothing
    Private CBSubreportHeader2 As arptCBHeader2 = Nothing

    Private fontsz1, fontsz2, fontsz3, fontsz4 As String
    Private fontStyle1, fontStyle2, fontStyle3, fontStyle4 As String

    Public CultureCode As String = "en-US"
    Public _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing


    Private Sub arptCreativeBrief_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        setCBOptions()
        Me.CBSubreportHeader1 = New arptCBHeader1
        Me.CBSubreportHeader1.jobNbr = jobNbr
        Me.CBSubreportHeader1.jobCompNbr = jobCompNbr
        Me.CBSubreportHeader1.job = job
        Me.CBSubreportHeader1.jobcomp = jobcomp
        Me.CBSubreportHeader1.jobDesc = jobDesc
        Me.CBSubreportHeader1.compDesc = compDesc
        Me.CBSubreportHeader1.UserCode = UserCode
        Me.CBSubreportHeader1.mConnectionString = mConnectionString
        Me.CBSubreportHeader1.client = client
        Me.CBSubreportHeader1.division = division
        Me.CBSubreportHeader1.product = product
        Me.CBSubreportHeader1.cl_code = cl_code
        Me.CBSubreportHeader1.div_code = div_code
        Me.CBSubreportHeader1.prd_code = prd_code
        Me.SubReport1.Report = CBSubreportHeader1

        'Report Header 2
        Me.CBSubreportHeader2 = New arptCBHeader2
        Me.CBSubreportHeader2.jobNbr = jobNbr
        Me.CBSubreportHeader2.jobCompNbr = jobCompNbr
        Me.CBSubreportHeader2.job = job
        Me.CBSubreportHeader2.jobcomp = jobcomp
        Me.CBSubreportHeader2.client = client
        Me.CBSubreportHeader2.division = division
        Me.CBSubreportHeader2.product = product
        Me.CBSubreportHeader2.cl_code = cl_code
        Me.CBSubreportHeader2.div_code = div_code
        Me.CBSubreportHeader2.prd_code = prd_code
        Me.CBSubreportHeader2.UserCode = UserCode
        Me.CBSubreportHeader2.mConnectionString = mConnectionString
        Me.CBSubreportHeader2.CultureCode = Me.CultureCode
        Me.SubReport2.Report = CBSubreportHeader2


        dtData = getTemplateData(jobNbr, jobCompNbr)
        Me.DataSource = dtData

        'Create StyleSheets for Textboxes
        Dim cb As New cCreativeBrief(mConnectionString, UserCode)

        cb.getfontInfo(jobNbr, jobCompNbr, 1, fontsz1, fontStyle1, fontsz2, fontStyle2, fontsz3, fontStyle3, fontsz4, fontStyle4)
        'cb.getfontInfo(jobNbr, jobCompNbr, 2, fontsz2, fontStyle2)
        'cb.getfontInfo(jobNbr, jobCompNbr, 3, fontsz3, fontStyle3)
        'cb.getfontInfo(jobNbr, jobCompNbr, 4, fontsz4, fontStyle4)

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


    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        'Me.txtClient.Text = client
        'Me.txtDivision.Text = division
        'Me.txtProduct.Text = product

        If SHOW_JOB_NUMBER = 1 Then
            job = job
        Else
            job = ""
        End If
        If SHOW_JOB_DESC = 1 Then
            If job = "" Then
                job &= jobDesc
            Else
                job &= " - " & jobDesc
            End If
        End If
        If SHOW_JOB_NUMBER = 1 Or SHOW_JOB_DESC = 1 Then
            'Me.txtJob.Text = job
        End If


        If SHOW_JOB_COMP_NBR = 1 Then
            jobcomp = jobcomp
        Else
            jobcomp = ""
        End If
        If SHOW_JOB_COMP_DESC = 1 Then
            If jobcomp = "" Then
                jobcomp &= compDesc
            Else
                jobcomp &= " - " & compDesc
            End If
        End If
        If SHOW_JOB_COMP_NBR = 1 Or SHOW_JOB_COMP_DESC = 1 Then
            'Me.txtComponent.Text = jobcomp
        End If

        If Me.LogoID = "None" Then
            PageHeader1.Visible = False
        Else
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

            Dim str As String
            Dim str3 As String
            Try
                If Me.dtAgency.Rows.Count > 0 AndAlso Me.LogoID <> "None" AndAlso Me.dtAgency.Rows(0)("PRT_HEADER").ToString = "1" Then
                    str3 = ""

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
                        str3 = Me.dtAgency.Rows(0)("ADDRESS1").ToString
                    End If
                    If str3 > "" Then
                        str3 = str3 & " • "
                    End If
                    If Me.dtAgency.Rows(0)("PRT_ADDR2").ToString = "1" And Me.dtAgency.Rows(0)("ADDRESS2").ToString <> "" Then
                        str3 = str3 & Me.dtAgency.Rows(0)("ADDRESS2").ToString
                    End If
                    If Me.dtAgency.Rows(0)("PRT_CITY").ToString = "1" And Me.dtAgency.Rows(0)("CITY").ToString <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & Me.dtAgency.Rows(0)("CITY").ToString & ", "
                    End If
                    If Me.dtAgency.Rows(0)("PRT_STATE").ToString = "1" And Me.dtAgency.Rows(0)("STATE").ToString <> "" Then
                        str3 = str3 & Me.dtAgency.Rows(0)("STATE").ToString & "  "
                    End If
                    If Me.dtAgency.Rows(0)("PRT_ZIP").ToString = "1" And Me.dtAgency.Rows(0)("ZIP").ToString <> "" Then
                        str3 = str3 & Me.dtAgency.Rows(0)("ZIP").ToString
                    End If
                    If Me.dtAgency.Rows(0)("PRT_PHONE").ToString = "1" And Me.dtAgency.Rows(0)("PHONE").ToString <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & Me.dtAgency.Rows(0)("PHONE").ToString
                    End If
                    If Me.dtAgency.Rows(0)("PRT_FAX").ToString = "1" And Me.dtAgency.Rows(0)("FAX").ToString <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & Me.dtAgency.Rows(0)("FAX").ToString & " Fax "
                    End If
                    If Me.dtAgency.Rows(0)("PRT_EMAIL").ToString = "1" And Me.dtAgency.Rows(0)("EMAIL").ToString <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & Me.dtAgency.Rows(0)("EMAIL").ToString
                    End If
                    Me.txtAgencyInfo.Text = str3

                Else
                    Me.txtAgencyName.Text = ""
                    Me.txtAgencyInfo.Text = ""
                End If
            Catch ex As Exception
                Me.txtAgencyName.Text = ""
                Me.txtAgencyInfo.Text = ""
            End Try
        End If
    End Sub

    Private Sub PageFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
        Me.lblBy.Text = "by " & Reporter
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            If ReportTitle <> "" Then
                Me.lblReportTitle.Text = ReportTitle
            Else
                Me.lblReportTitle.Text = "Creative Brief Report"
            End If

            Select Case LogoPlacement
                Case 1
                    Me.lblReportTitle.Alignment = TextAlignment.Left
                Case 2
                    Me.lblReportTitle.Alignment = TextAlignment.Center
                Case 3
                    Me.lblReportTitle.Alignment = TextAlignment.Right
                Case Else
                    Me.lblReportTitle.Alignment = TextAlignment.Left
            End Select
        Catch ex As Exception

        End Try
    End Sub

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

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim cb As New cCreativeBrief(mConnectionString, UserCode)

        'Me.TextBox1.Visible = False
        'Me.TextBox2.Visible = False
        'Me.TextBox3.Visible = False
        'Me.TextBox4.Visible = False

        'cb.getfontInfo(jobNbr, jobCompNbr, 1, fontsz1, fontStyle1, fontsz2, fontStyle2, fontsz3, fontStyle3, fontsz4, fontStyle4)
        'cb.getfontInfo(jobNbr, jobCompNbr, 2, fontsz2, fontStyle2)
        'cb.getfontInfo(jobNbr, jobCompNbr, 3, fontsz3, fontStyle3)
        'cb.getfontInfo(jobNbr, jobCompNbr, 4, fontsz4, fontStyle4)

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

    End Sub

    Public Function getTemplateData(ByVal jobNbr As Integer, ByVal jobCompNbr As Int16) As DataTable
        Dim cb As New cCreativeBrief(mConnectionString, UserCode)
        Dim fontsz1, fontsz2, fontsz3, fontsz4 As String
        Dim fontStyle1, fontStyle2, fontStyle3, fontStyle4, fontstyle As String
        Dim begin1, begin2, begin3, begin4 As String
        Dim end1, end2, end3, end4 As String
        Dim dr1, dr2, dr3, dr4, drCheck1, drCheck2, drCheck3 As SqlDataReader
        Dim dt As New DataTable

        Try
            dt = cb.CreativeBriefTmpltData(jobNbr, jobCompNbr, IIf(omitEmptyFields, 1, 0))
        Catch ex As Exception

        End Try

        'Dim colDesc As DataColumn = New DataColumn("Desc")
        'colDesc.DataType = System.Type.GetType("System.String")
        'dt.Columns.Add(colDesc)

        'Dim colLevel As DataColumn = New DataColumn("Level")
        'colLevel.DataType = System.Type.GetType("System.String")
        'dt.Columns.Add(colLevel)

        'Dim desc1, desc2, desc3, desc4, descCheck As String
        'Dim ID1, ID2, ID3, ID4 As Int16

        'dr1 = cb.getLevel1Data(jobNbr, jobCompNbr)
        'Do While dr1.Read
        '    Dim drNewRow1 As DataRow = dt.NewRow()

        '    desc1 = dr1.GetString(1)
        '    drNewRow1.Item("Desc") = desc1
        '    drNewRow1.Item("Level") = "1"

        '    ID1 = dr1.GetInt16(2)
        '    drCheck1 = cb.getLevel2Data(CStr(ID1), jobNbr, jobCompNbr)

        '    If omitEmptyFields = True Then
        '        Do While drCheck1.Read
        '            ID2 = drCheck1.GetInt16(2)
        '            Dim drID2 As SqlDataReader = cb.getLevel3Data(CStr(ID2), jobNbr, jobCompNbr)
        '            Do While drID2.Read
        '                ID3 = drID2.GetInt16(2)
        '                Dim drID3 As SqlDataReader = cb.getDetailData(CStr(ID3), jobNbr, jobCompNbr)
        '                Do While drID3.Read
        '                    descCheck = drID3.GetString(1)
        '                    If descCheck.Trim <> "" Then
        '                        dt.Rows.Add(drNewRow1)
        '                        Exit Do
        '                    End If
        '                Loop
        '                drID3.Close()
        '                Exit Do
        '            Loop
        '            drID2.Close()
        '            Exit Do
        '        Loop
        '        drCheck1.Close()
        '    Else
        '        dt.Rows.Add(drNewRow1)
        '    End If

        '    dr2 = cb.getLevel2Data(CStr(ID1), jobNbr, jobCompNbr)
        '    Do While dr2.Read
        '        Dim drNewRow2 As DataRow = dt.NewRow()

        '        desc2 = dr2.GetString(1)
        '        drNewRow2.Item("Desc") = desc2
        '        drNewRow2.Item("Level") = "2"

        '        ID2 = dr2.GetInt16(2)
        '        drCheck2 = cb.getLevel3Data(CStr(ID2), jobNbr, jobCompNbr)

        '        If omitEmptyFields = True Then
        '            Do While drCheck2.Read
        '                ID3 = drCheck2.GetInt16(2)
        '                Dim dr As SqlDataReader = cb.getDetailData(CStr(ID3), jobNbr, jobCompNbr)
        '                Do While dr.Read
        '                    descCheck = dr.GetString(1)
        '                    If descCheck.Trim <> "" Then
        '                        dt.Rows.Add(drNewRow2)
        '                        Exit Do
        '                    End If
        '                Loop
        '                dr.Close()
        '                Exit Do
        '            Loop
        '            drCheck2.Close()
        '        Else
        '            dt.Rows.Add(drNewRow2)
        '        End If

        '        dr3 = cb.getLevel3Data(CStr(ID2), jobNbr, jobCompNbr)
        '        Do While dr3.Read
        '            Dim drNewRow3 As DataRow = dt.NewRow()

        '            desc3 = dr3.GetString(1)
        '            drNewRow3.Item("Desc") = desc3
        '            drNewRow3.Item("Level") = "3"

        '            ID3 = dr3.GetInt16(2)
        '            drCheck3 = cb.getDetailData(CStr(ID3), jobNbr, jobCompNbr)

        '            If omitEmptyFields = True Then
        '                Do While drCheck3.Read
        '                    descCheck = drCheck3.GetString(1)
        '                    If descCheck.Trim <> "" Then
        '                        dt.Rows.Add(drNewRow3)
        '                        Exit Do
        '                    End If
        '                Loop
        '                drCheck3.Close()
        '            Else
        '                dt.Rows.Add(drNewRow3)
        '            End If

        '            dr4 = cb.getDetailData(CStr(ID3), jobNbr, jobCompNbr)

        '            Do While dr4.Read
        '                Dim drNewRow4 As DataRow = dt.NewRow()

        '                desc4 = dr4.GetString(1)
        '                If omitEmptyFields = True Then
        '                    If desc4.Trim <> "" Then
        '                        drNewRow4.Item("Desc") = desc4
        '                        drNewRow4.Item("Level") = "4"
        '                        dt.Rows.Add(drNewRow4)
        '                        ID4 = dr4.GetInt32(0)
        '                    End If

        '                Else
        '                    drNewRow4.Item("Desc") = desc4
        '                    drNewRow4.Item("Level") = "4"
        '                    dt.Rows.Add(drNewRow4)
        '                    ID4 = dr4.GetInt32(0)
        '                End If
        '            Loop
        '            dr4.Close()
        '        Loop
        '        dr3.Close()
        '    Loop
        '    dr2.Close()
        'Loop
        'dr1.Close()
        Return dt

    End Function

    Public Sub setCBOptions()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim count As Int16
        Dim BriefDefID As Integer
        Dim cb As New cCreativeBrief(mConnectionString, UserCode)

        'Get default report header data
        BriefDefID = cb.getBriefDefID(jobNbr, jobCompNbr)

        SQL_STRING = "SELECT ISNULL(SHOW_CLIENT,0), ISNULL(SHOW_CLIENT_REF,0), ISNULL(SHOW_DIVISION,0), ISNULL(SHOW_PRODUCT,0), ISNULL(SHOW_CL_ADDRESS,0), ISNULL(SHOW_DIV_ADDRESS,0),"
        SQL_STRING &= " ISNULL(SHOW_PRD_ADDRESS,0), ISNULL(SHOW_JOB_NUMBER,0), ISNULL(SHOW_JOB_DESC,0), ISNULL(SHOW_JOB_COMP_NBR,0), ISNULL(SHOW_JOB_COMP_DESC,0), ISNULL(SHOW_ACCT_EXEC,0), ISNULL(SHOW_BUDGET,0),"
        SQL_STRING &= " ISNULL(SHOW_TEAM,0), ISNULL(SHOW_DATE_OPENED,0), ISNULL(SHOW_CAMPAIGN,0), ISNULL(SHOW_APPRV_EST_REQ,0), ISNULL(SHOW_RUSH_CHGS_OK,0), ISNULL(SHOW_DUE_DATE,0), ISNULL(SHOW_OPENED_BY,0)"
        SQL_STRING &= " FROM CRTV_BRF_DEF"
        SQL_STRING &= " WHERE CRTV_BRF_DEF_ID = " & CStr(BriefDefID)

        Try
            dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            SHOW_CLIENT = dr.GetInt16(0)
            SHOW_CLIENT_REF = dr.GetInt16(1)
            SHOW_DIVISION = dr.GetInt16(2)
            SHOW_PRODUCT = dr.GetInt16(3)
            SHOW_CL_ADDRESS = dr.GetInt16(4)
            SHOW_DIV_ADDRESS = dr.GetInt16(5)
            SHOW_PRD_ADDRESS = dr.GetInt16(6)
            SHOW_JOB_NUMBER = dr.GetInt16(7)
            SHOW_JOB_DESC = dr.GetInt16(8)
            SHOW_JOB_COMP_NBR = dr.GetInt16(9)
            SHOW_JOB_COMP_DESC = dr.GetInt16(10)
            SHOW_ACCT_EXEC = dr.GetInt16(11)
            SHOW_BUDGET = dr.GetInt16(12)
            SHOW_TEAM = dr.GetInt16(13)
            SHOW_DATE_OPENED = dr.GetInt16(14)
            SHOW_CAMPAIGN = dr.GetInt16(15)
            SHOW_APPRV_EST_REQ = dr.GetInt16(16)
            SHOW_RUSH_CHGS_OK = dr.GetInt16(17)
            SHOW_DUE_DATE = dr.GetInt16(18)
            SHOW_OPENED_BY = dr.GetInt16(19)
        End If
        dr.Close()

        'If SHOW_CLIENT = 1 Then
        '    Me.lblClient.Visible = True
        '    Me.txtClient.Visible = True
        'Else
        '    Me.lblClient.Visible = False
        '    Me.txtClient.Visible = False
        'End If
        'If SHOW_DIVISION = 1 Then
        '    Me.lblDivision.Visible = True
        '    Me.txtDivision.Visible = True
        'Else
        '    Me.lblDivision.Visible = False
        '    Me.txtDivision.Visible = False
        'End If
        'If SHOW_PRODUCT = 1 Then
        '    Me.lblProduct.Visible = True
        '    Me.txtProduct.Visible = True
        'Else
        '    Me.lblProduct.Visible = False
        '    Me.txtProduct.Visible = False
        'End If

        'If SHOW_JOB_NUMBER = 1 Or SHOW_JOB_DESC = 1 Then
        '    Me.txtJob.Visible = True
        '    Me.lblJob.Visible = True
        'Else
        '    Me.txtJob.Visible = False
        '    Me.lblJob.Visible = False
        'End If

        'If SHOW_JOB_COMP_NBR = 1 Or SHOW_JOB_COMP_DESC = 1 Then
        '    Me.txtComponent.Visible = True
        '    Me.lblComponent.Visible = True
        'Else
        '    Me.txtComponent.Visible = False
        '    Me.lblComponent.Visible = False
        'End If



        'Get Job data
        SQL_STRING = " SELECT ISNULL(JOB_LOG.CMP_CODE,''), ISNULL(JOB_LOG.CMP_IDENTIFIER,0), ISNULL(JOB_LOG.JOB_DATE_OPENED,''), ISNULL(JOB_LOG.USER_ID,''), ISNULL(JOB_LOG.JOB_ESTIMATE_REQ,0), ISNULL(JOB_LOG.JOB_RUSH_CHARGES,0), ISNULL(JOB_LOG.JOB_CLI_REF,'') "
        SQL_STRING &= " FROM JOB_LOG WHERE JOB_LOG.JOB_NUMBER = " & CStr(jobNbr)

        Try
            dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            CAMPAIGN_CODE = dr.GetString(0)
            CAMPAIGN_ID = dr.GetInt32(1)
            JOB_DATE_OPENED = dr.GetDateTime(2) 'don't use this one, use component
            OPENED_BY = dr.GetString(3)         'don't use this one, use component
            JOB_ESTIMATE_REQ = dr.GetInt16(4)
            JOB_RUSH_CHARGES = dr.GetInt16(5)
            CLIENT_REF = dr.GetString(6)
        End If
        dr.Close()

        If JOB_ESTIMATE_REQ = 0 Then
            SHOW_APPRV_EST_REQ = 0
        End If
        If JOB_RUSH_CHARGES = 0 Then
            SHOW_RUSH_CHGS_OK = 0
        End If
        If CLIENT_REF = "" Then
            SHOW_CLIENT_REF = 0
        End If

        'If SHOW_APPRV_EST_REQ = 1 Then
        '    Me.lblApprEstReq.Visible = True
        'Else
        '    Me.lblApprEstReq.Visible = False
        'End If

        'If SHOW_RUSH_CHGS_OK = 1 Then
        '    Me.lblRushChargesApproved.Visible = True
        'Else
        '    Me.lblRushChargesApproved.Visible = False
        'End If

        'If SHOW_CLIENT_REF = 1 Then
        '    Me.txtCliRef.Visible = True
        '    Me.lblCliRef.Visible = True
        '    Me.txtCliRef.Text = CLIENT_REF
        'Else
        '    Me.txtCliRef.Visible = False
        '    Me.lblCliRef.Visible = False
        'End If


        'Job Component Data
        SQL_STRING = " SELECT dbo.udf_get_empl_name(EMP_CODE, 'FML'), ISNULL(DP_TM_CODE,''), ISNULL(JOB_COMP_BUDGET_AM,0), JOB_FIRST_USE_DATE, JOB_COMP_DATE  "
        SQL_STRING &= " FROM JOB_COMPONENT "
        SQL_STRING &= " WHERE JOB_NUMBER = " & CStr(jobNbr) & " AND JOB_COMPONENT_NBR = " & CStr(jobCompNbr)

        Try
            dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            OPENED_BY = dr.GetString(0)
            TEAM = dr.GetString(1)
            BUDGET = dr.GetDecimal(2)

            If Not IsDBNull(dr.GetValue(3)) Then
                JOB_FIRST_USE_DATE = dr.GetDateTime(3)
            Else
                SHOW_DUE_DATE = 0
            End If

            If Not IsDBNull(dr.GetValue(4)) Then
                JOB_COMP_DATE = dr.GetDateTime(4)
            Else
                SHOW_DATE_OPENED = 0
            End If

        End If
        dr.Close()

        If OPENED_BY = "" Then
            SHOW_OPENED_BY = 0
        End If
        If TEAM = "" Then
            SHOW_TEAM = 0
        End If
        If BUDGET = 0 Then
            SHOW_BUDGET = 0
        End If

        'Populate Report textboxes
        'If SHOW_OPENED_BY = 1 Then
        '    Me.txtOpenedBy.Visible = True
        '    Me.lblOpenedBy.Visible = True
        '    Me.txtOpenedBy.Text = OPENED_BY
        'Else
        '    Me.txtOpenedBy.Visible = False
        '    Me.lblOpenedBy.Visible = False
        'End If

        'If SHOW_TEAM = 1 Then
        '    Me.txtDeptTeam.Visible = True
        '    Me.lblDeptTeam.Visible = True
        '    Me.txtDeptTeam.Text = TEAM
        'Else
        '    Me.txtDeptTeam.Visible = False
        '    Me.lblDeptTeam.Visible = False
        'End If

        'If SHOW_BUDGET = 1 Then
        '    Me.txtBudget.Visible = True
        '    Me.lblBudget.Visible = True
        '    Me.txtBudget.Text = BUDGET
        'Else
        '    Me.txtBudget.Visible = False
        '    Me.lblBudget.Visible = False
        'End If

        'If SHOW_DUE_DATE = 1 Then
        '    Me.txtDue.Visible = True
        '    Me.lblDue.Visible = True
        '    Me.txtDue.Text = JOB_FIRST_USE_DATE
        'Else
        '    Me.txtDue.Visible = False
        '    Me.lblDue.Visible = False
        'End If

        'If SHOW_DATE_OPENED = 1 Then
        '    Me.txtOpened.Visible = True
        '    Me.lblOpened.Visible = True
        '    Me.txtOpened.Text = JOB_COMP_DATE
        'Else
        '    Me.txtOpened.Visible = False
        '    Me.lblOpened.Visible = False
        'End If


        'C/D/P Address
        Dim ls_addr1, ls_addr2, ls_city, ls_state, ls_zip As String
        SQL_STRING = "SELECT ISNULL(CL_ADDRESS1,'') FROM CLIENT WHERE 1=2 "
        If SHOW_CL_ADDRESS = 1 Then
            SQL_STRING = " SELECT ISNULL(CL_ADDRESS1,''), ISNULL(CL_ADDRESS2,''), ISNULL(CL_CITY,''), ISNULL(CL_STATE,''), ISNULL(CL_ZIP,'') "
            SQL_STRING &= "FROM CLIENT "
            SQL_STRING &= "WHERE CL_CODE = '" & cl_code & "'"
        Else
            If SHOW_DIV_ADDRESS = 1 Then
                SQL_STRING = " SELECT ISNULL(DIV_BADDRESS1,''), ISNULL(DIV_BADDRESS2,''), ISNULL(DIV_BCITY,''), ISNULL(DIV_BSTATE,''), ISNULL(DIV_BZIP,'')"
                SQL_STRING &= "FROM DIVISION "
                SQL_STRING &= "WHERE DIV_CODE = '" & div_code & "' And CL_CODE = '" & cl_code & "'"
            Else
                If SHOW_PRD_ADDRESS = 1 Then
                    SQL_STRING = " SELECT ISNULL(PRD_BILL_ADDRESS1,''), ISNULL(PRD_BILL_ADDRESS2,''), ISNULL(PRD_BILL_CITY,''), ISNULL(PRD_BILL_STATE,''), ISNULL(PRD_BILL_ZIP,'')"
                    SQL_STRING &= "FROM PRODUCT "
                    SQL_STRING &= "WHERE PRD_CODE = '" & prd_code & "' And CL_CODE = '" & cl_code & "' And DIV_CODE = '" & div_code & "'"
                End If
            End If
        End If

        Try
            dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            ls_addr1 = dr.GetString(0)
            ls_addr2 = dr.GetString(1)
            ls_city = dr.GetString(2)
            ls_state = dr.GetString(3)
            ls_zip = dr.GetString(4)

            CDP_ADDR = ""
            If ls_city <> "" Then
                CDP_ADDR = ls_city
            End If

            If ls_state <> "" Then
                If CDP_ADDR <> "" Then
                    CDP_ADDR = CDP_ADDR & ", " & ls_state
                Else
                    CDP_ADDR = ls_state
                End If
            End If

            If ls_zip <> "" Then
                If CDP_ADDR <> "" Then
                    CDP_ADDR = CDP_ADDR & "  " & ls_zip
                Else
                    CDP_ADDR = ls_zip
                End If
            End If


            If SHOW_CL_ADDRESS = 1 Or SHOW_DIV_ADDRESS = 1 Or SHOW_PRD_ADDRESS = 1 Then
                If CDP_ADDR = "" Then
                    SHOW_CL_ADDRESS = 0
                    SHOW_DIV_ADDRESS = 0
                    SHOW_PRD_ADDRESS = 0
                    'txtAddress.Visible = False
                    'txtAddress2.Visible = False
                    'txtAddress3.Visible = False
                    'lblAddress.Visible = False
                    'lblAddress2.Visible = False
                Else
                    'txtAddress.Visible = True
                    'txtAddress2.Visible = True
                    'txtAddress3.Visible = True
                    'lblAddress.Visible = True
                    'lblAddress2.Visible = True

                    'If ls_addr1 <> "" Then
                    '    txtAddress.Text = ls_addr1
                    'Else
                    '    txtAddress.Visible = False
                    'End If

                    'If ls_addr2 <> "" Then
                    '    If ls_addr1 <> "" Then
                    '        txtAddress2.Text = ls_addr2
                    '    Else
                    '        txtAddress.Text = ls_addr2
                    '        txtAddress.Visible = True
                    '    End If

                    'Else
                    '    txtAddress2.Visible = False
                    'End If

                    'If CDP_ADDR <> "" Then
                    '    If ls_addr2 <> "" Then
                    '        txtAddress3.Text = CDP_ADDR
                    '    Else
                    '        txtAddress2.Text = CDP_ADDR
                    '        txtAddress2.Visible = True
                    '        txtAddress3.Visible = False
                    '    End If

                    'Else
                    '    txtAddress3.Visible = False
                    'End If

                    'If SHOW_CL_ADDRESS = 1 Then
                    '    lblAddress.Text = "Client"
                    'End If
                    'If SHOW_DIV_ADDRESS = 1 Then
                    '    lblAddress.Text = "Division"
                    'End If
                    'If SHOW_PRD_ADDRESS = 1 Then
                    '    lblAddress.Text = "Product"
                    'End If
                End If
            End If

        Else
            CDP_ADDR = ""
            SHOW_CL_ADDRESS = 0
            SHOW_DIV_ADDRESS = 0
            SHOW_PRD_ADDRESS = 0
            'txtAddress.Visible = False
            'txtAddress2.Visible = False
            'txtAddress3.Visible = False
            'lblAddress.Visible = False
            'lblAddress2.Visible = False
        End If

        dr.Close()


        'TEAM
        If TEAM = "" Then
            SHOW_TEAM = 0
        End If
        If SHOW_TEAM = 1 Then
            SQL_STRING = " Select ISNULL(DP_TM_DESC,'') FROM DEPT_TEAM WHERE DP_TM_CODE = '" & TEAM & "'"

            Try
                dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
            Finally
            End Try

            If dr.HasRows Then
                dr.Read()
                TEAM = dr.GetString(0)
            End If
            If TEAM = "" Then
                SHOW_TEAM = 0
            End If
        End If
        dr.Close()

        'If SHOW_TEAM = 1 Then
        '    Me.txtDeptTeam.Visible = True
        '    Me.lblDeptTeam.Visible = True
        '    Me.txtDeptTeam.Text = TEAM
        'Else
        '    Me.txtDeptTeam.Visible = False
        '    Me.lblDeptTeam.Visible = False
        'End If


        'Campaign
        CAMPAIGN_NAME = ""
        If CAMPAIGN_ID = 0 Then
            SHOW_CAMPAIGN = 0
        End If
        If SHOW_CAMPAIGN = 1 Then
            SQL_STRING = " Select CMP_NAME FROM CAMPAIGN WHERE CMP_IDENTIFIER = " & CStr(CAMPAIGN_ID)

            Try
                dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
            Finally
            End Try

            If dr.HasRows Then
                dr.Read()
                CAMPAIGN_NAME = dr.GetString(0)
            End If
        End If
        If CAMPAIGN_NAME = "" Then
            SHOW_CAMPAIGN = 0
        End If
        dr.Close()

        'If SHOW_CAMPAIGN = 1 Then
        '    Me.txtCampaign.Visible = True
        '    Me.lblCampaign.Visible = True
        '    Me.txtCampaign.Text = CAMPAIGN_NAME
        'Else
        '    Me.txtCampaign.Visible = False
        '    Me.lblCampaign.Visible = False
        'End If

        'Account Executive
        ACCT_EXEC = ""
        If SHOW_ACCT_EXEC = 1 Then
            SQL_STRING = " SELECT dbo.udf_get_empl_name(EMP_CODE, 'FML')"
            SQL_STRING &= " FROM ACCOUNT_EXECUTIVE "
            SQL_STRING &= " WHERE CL_CODE = '" & cl_code & "' AND DIV_CODE = '" & div_code & "' AND PRD_CODE = '" & prd_code & "'"
            SQL_STRING &= " AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL) "
            SQL_STRING &= " AND DEFAULT_AE = 1"

            Try
                dr = oSQL.ExecuteReader(mConnectionString, CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:arptCreativeBrief Routine:getCBOptions", Err.Description)
            Finally
            End Try

            If dr.HasRows Then
                dr.Read()
                ACCT_EXEC = dr.GetString(0)
            End If
        End If
        If ACCT_EXEC = "" Then
            SHOW_ACCT_EXEC = 0
        End If
        dr.Close()

        'If SHOW_ACCT_EXEC = 1 Then
        '    Me.txtAcctExec.Visible = True
        '    Me.lblAcctExec.Visible = True
        '    Me.txtAcctExec.Text = ACCT_EXEC
        'Else
        '    Me.txtAcctExec.Visible = False
        '    Me.lblAcctExec.Visible = False
        'End If

    End Sub


End Class
