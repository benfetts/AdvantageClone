Imports System.Data.SqlClient
Imports System.Text

Imports System
Imports System.Data
Imports System.Data.DataRow
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Webvantage.MiscFN


Partial Public Class CreativeBrief
    Inherits Webvantage.BaseChildPage
    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#Region " Private vars: "
    Private OpenSpacerTable As String = "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""2"" align=""center"">"
    Private CloseSpacerTable As String = "</table>"
    Private JobNum As Integer
    Private JobCompNum As Int16
    Private CreativeBrfCPID As Integer = 0
#End Region

    Private Sub CreativeBrief_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_CreativeBrief)

        If Not Page.IsPostBack Then
            Session("CBNewSaved") = 1
        End If


        If Not Request.QueryString("JobNo") Is Nothing AndAlso IsNumeric(Request.QueryString("JobNo")) Then

            Me.JobNum = CType(Request.QueryString("JobNo"), Integer)

        End If
        If Not Request.QueryString("JobComp") Is Nothing AndAlso IsNumeric(Request.QueryString("JobComp")) Then

            Me.JobCompNum = CType(Request.QueryString("JobComp"), Int16)

        End If

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber

        If Me.JobNum > 0 And Me.JobCompNum > 0 And Session("CBNewSaved") = 1 Then
            CheckApproval()
            PopulateTemplate()

            Dim textboxID As String
            If Not Session("CBFirstTextbox") Is Nothing Then
                textboxID = Session("CBFirstTextbox")
                Dim myTextbox As System.Web.UI.WebControls.TextBox = Panel1.FindControl(textboxID)
                If Not myTextbox Is Nothing Then
                    MiscFN.SetFocus(myTextbox)
                End If
            End If
        End If

        'If (Me.JobNum = 0 AndAlso Me.JobCompNum = 0) OrElse Me.CurrentQuerystring.IsJobDashboard = True Then

        Me.RadToolbarCreativeBrief.FindItemByText("Print/Send").Visible = False

        'End If

        If Me.IsClientPortal = True Then

            Me.RadToolbarCreativeBrief.FindItemByValue("SaveSeparator").Visible = False
            Me.RadToolbarCreativeBrief.FindItemByValue("Save").Visible = False
            Me.RadToolbarCreativeBrief.FindItemByValue("DeleteSeparator").Visible = False
            Me.RadToolbarCreativeBrief.FindItemByValue("Delete").Visible = False

            Me.RadToolbarCreativeBrief.FindItemByValue("SendAssignment").Visible = False

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Creative Brief for Job/Comp: " & Me.JobNum.ToString.PadLeft(6, "0") & " / " & Me.JobCompNum.ToString.PadLeft(2, "0")

        If Not IsPostBack Then
            Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
            'Me.InjectScriptLabel.Text = Me.WriteSpellScript()
            If Request.QueryString("fw") = "ProjectView" Then
                Dim existingtemps As Boolean
                existingtemps = cb.ExistingTemplates(Me.JobNum, Me.JobCompNum)
                If existingtemps = False Then
                    Session("CBNewSaved") = 0
                    Session("CBNewCanceled") = 0
                    'Me.OpenWindow("", "CreativeBrief_New.aspx?JobNo=" & JobNumber & "&JobComp=" & JobComponentNbr)
                    If Me.IsClientPortal = True Then
                        Me.ShowMessage("No Creative Brief exists for this job.")
                        Me.CloseThisWindow()
                    Else
                        Me.OpenWindow("", "CreativeBrief_New.aspx?JobNo=" & Me.JobNum.ToString() & "&JobComp=" & Me.JobCompNum.ToString() & "&fw=ProjectView")
                    End If
                    'Me.HookUpOpenWindow(cbImage, "CreativeBrief_New.aspx?JobNo=" & Me.JobNum.ToString() & "&JobComp=" & Me.JobCompNum.ToString())
                End If
            End If

        Else
            Select Case Me.EventArgument
                Case "Delete"
                    Dim existingtemps As Boolean
                    Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
                    Session("CBNewSaved") = 0
                    Session("CBDeleted") = 0
                    deleteApproval()
                    deleteCreativeBrief()
                Case "Refresh"

            End Select

            CheckApproval()

        End If

    End Sub

    Private Function isApprovedVersion() As Boolean
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim count As Int16

        SQL_STRING = "SELECT COUNT(*), ISNULL(CB_APPR_USER_ID_CP,0) FROM CRTV_BRF_APPR "
        SQL_STRING &= " WHERE JOB_NUMBER = " & CStr(Me.JobNum) & " AND JOB_COMPONENT_NBR = " & CStr(Me.JobCompNum) & " GROUP BY CB_APPR_USER_ID_CP"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            count = dr.GetInt32(0)
            CreativeBrfCPID = dr.GetInt32(1)
            dr.Close()
        End If

        If count > 0 Then
            Return True
        End If
        Return False

    End Function

    Private Sub CheckApproval()
        Try
            Dim button As New Telerik.Web.UI.RadToolBarButton

            If isApprovedVersion() = True Then
                ApprVerBut.Visible = True
                button = Me.RadToolbarCreativeBrief.FindItemByValue("Approve")
                button.Text = "Unapprove"
                button.ToolTip = "Unapprove"
                If IsClientPortal = True And CreativeBrfCPID = 0 Then
                    button.Enabled = False
                End If
            Else
                ApprVerBut.Visible = False
                button = Me.RadToolbarCreativeBrief.FindItemByValue("Approve")
                button.Text = "Approve"
                button.ToolTip = "Approve"
            End If

        Catch ex As Exception
            Me.ShowMessage("Error checkapproval!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub PopulateTemplate()
        Dim strXMLData, XMLString As String
        Dim sbXMLData As StringBuilder = New StringBuilder
        Dim fontsz1, fontsz2, fontsz3, fontsz4 As String
        Dim fontStyle1, fontStyle2, fontStyle3, fontStyle4, fontstyle As String
        Dim begin1, begin2, begin3, begin4 As String
        Dim end1, end2, end3, end4 As String
        Dim dr1, dr2, dr3, dr4 As SqlDataReader
        Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
        Dim style As String


        cb.getfontInfo(JobNum, JobCompNum, 1, fontsz1, fontStyle1, fontsz2, fontStyle2, fontsz3, fontStyle3, fontsz4, fontStyle4)
        'cb.getfontInfo(JobNum, JobCompNum, 2, fontsz2, fontStyle2)
        'cb.getfontInfo(JobNum, JobCompNum, 3, fontsz3, fontStyle3)
        'cb.getfontInfo(JobNum, JobCompNum, 4, fontsz4, fontStyle4)

        'Build level 1 tags
        style = ""
        begin1 &= "<tr> <td colspan=""4"" align=""left"" class=""MainContentCell""><span style="""
        end1 = ""

        If InStr(fontStyle1, "italic") Then
            style &= "font-style:italic;"
        End If
        If InStr(fontStyle1, "underline") Then
            end1 &= "</u> "
        End If
        If InStr(fontStyle1, "bold") Then
            style &= " font-weight:bold;"
        End If
        If InStr(fontStyle1, "bullit") Then
            end1 &= "</li> "
        End If
        end1 &= " </span></td></tr>"

        style &= "font-size:" & fontsz1 & "pt;"" >"
        begin1 &= style

        If InStr(fontStyle1, "bullit") Then
            begin1 &= "<li> "
        End If
        If InStr(fontStyle1, "underline") Then
            begin1 &= "<u> "
        End If

        'Build level 2 tags
        style = ""
        begin2 = "<tr> <td style=""width:1px"">&nbsp;</td> <td colspan=""3"" align=""left"" class=""MainContentCell""><span style="""
        end2 = ""
        If InStr(fontStyle2, "italic") Then
            style &= "font-style:italic;"
        End If
        If InStr(fontStyle2, "underline") Then
            end2 &= "</u> "
        End If
        If InStr(fontStyle2, "bold") Then
            style &= " font-weight:bold;"
        End If
        If InStr(fontStyle2, "bullit") Then
            end2 &= "</li> "
        End If
        end2 &= " </span></td></tr>"

        'style &= "text-indent:20px; font-size:""" & fontsz2 & """ >"
        style &= "font-size:" & fontsz2 & "pt;"" >"
        begin2 &= style

        If InStr(fontStyle2, "bullit") Then
            begin2 &= "<li> "
        End If
        If InStr(fontStyle2, "underline") Then
            begin2 &= "<u> "
        End If

        'Build level 3 tags
        style = ""
        begin3 = "<tr> <td style=""width:1px"">&nbsp;</td>  <td style=""width:1px"">&nbsp;</td>  <td colspan=""2"" align=""left"" class=""MainContentCell""><span style="""
        end3 = ""
        If InStr(fontStyle3, "italic") Then
            style &= "font-style:italic;"
        End If
        If InStr(fontStyle3, "underline") Then
            end3 &= "</u> "
        End If
        If InStr(fontStyle3, "bold") Then
            style &= " font-weight:bold;"
        End If
        If InStr(fontStyle3, "bullit") Then
            end3 &= "</li> "
        End If
        end3 &= " </span></td></tr>"

        'style &= "text-indent:20px; font-size:""" & fontsz3 & """ >"
        style &= "font-size:" & fontsz3 & "pt;"" >"
        begin3 &= style

        If InStr(fontStyle3, "bullit") Then
            begin3 &= "<li> "
        End If
        If InStr(fontStyle3, "underline") Then
            begin3 &= "<u> "
        End If

        Dim Style4 As Generic.Dictionary(Of String, String) = Nothing

        Style4 = New Generic.Dictionary(Of String, String)

        'Build detail level tags
        style = ""
        begin4 = "<tr> <td style=""width:1px"">&nbsp;</td>  <td style=""width:1px"">&nbsp;</td> <td style=""width:1px"">&nbsp;</td> <td align=""left"" class=""MainContentCell""><span style="""
        end4 = ""
        If InStr(fontStyle4, "italic") Then
            Style4.Add("font-style", "italic")
            style &= " font-style:italic;"
        End If
        If InStr(fontStyle4, "underline") Then
            Style4.Add("text-decoration", "underline")
            end4 &= " </u> "
        End If
        If InStr(fontStyle4, "bold") Then
            Style4.Add("font-weight", "bold")
            style &= " font-weight:bold;"
        End If
        If InStr(fontStyle4, "bullit") Then
            end4 &= " </li> "
        End If
        end4 &= " </span></td></tr>"

        style &= " font-size:" & fontsz4 & "pt;"" >"
        Style4.Add("font-size", fontsz4.ToString & "pt")

        begin4 &= style

        If InStr(fontStyle4, "bullit") Then
            begin4 &= "<li> "
        End If
        If InStr(fontStyle4, "underline") Then
            begin4 &= "<u> "
        End If

        Dim desc1, desc2, desc3, desc4 As String
        Dim ID1, ID2, ID3, ID4 As Int16
        Dim szLen, szHt, rowsNbr As Integer
        Dim textboxCount As Integer = 0
        Dim tabindex As Integer = 0

        Panel1.Controls.Add(MiscFN.NewLiteral(OpenSpacerTable))
        dr1 = cb.getLevel1Data(JobNum, JobCompNum)
        Do While dr1.Read
            desc1 = dr1.GetString(1)
            ID1 = dr1.GetInt16(2)

            Panel1.Controls.Add(MiscFN.NewLiteral(begin1))
            Panel1.Controls.Add(MiscFN.NewLiteral(desc1))
            Panel1.Controls.Add(MiscFN.NewLiteral(end1))

            dr2 = cb.getLevel2Data(CStr(ID1), JobNum, JobCompNum)
            Do While dr2.Read
                desc2 = dr2.GetString(1)
                ID2 = dr2.GetInt16(2)

                Panel1.Controls.Add(MiscFN.NewLiteral(begin2))
                Panel1.Controls.Add(MiscFN.NewLiteral(desc2))
                Panel1.Controls.Add(MiscFN.NewLiteral(end2))

                dr3 = cb.getLevel3Data(CStr(ID2), JobNum, JobCompNum)
                Do While dr3.Read
                    desc3 = dr3.GetString(1)
                    ID3 = dr3.GetInt16(2)

                    Panel1.Controls.Add(MiscFN.NewLiteral(begin3))
                    Panel1.Controls.Add(MiscFN.NewLiteral(desc3))
                    Panel1.Controls.Add(MiscFN.NewLiteral(end3))

                    dr4 = cb.getDetailData(CStr(ID3), JobNum, JobCompNum)
                    Do While dr4.Read
                        Dim myTextbox As New System.Web.UI.WebControls.TextBox

                        desc4 = dr4.GetString(1)
                        ID4 = dr4.GetInt32(0)
                        szLen = desc4.Length
                        If szLen <= 10000 Then
                            rowsNbr = szLen / 200
                        ElseIf szLen > 10000 And szLen <= 20000 Then
                            rowsNbr = szLen / 400
                        ElseIf szLen > 20000 Then
                            rowsNbr = szLen / 600
                        End If
                        If rowsNbr < 7 Then rowsNbr = 7

                        Panel1.Controls.Add(MiscFN.NewLiteral(begin4))
                        Panel1.Controls.Add(myTextbox)
                        Panel1.Controls.Add(MiscFN.NewLiteral(end4))

                        myTextbox.ID = "textbox" + CStr(ID4)
                        myTextbox.Rows = rowsNbr
                        myTextbox.Width = Unit.Percentage(90)
                        myTextbox.Wrap = True
                        'myTextbox.Font.Size = fontsz4

                        For Each CssProp In Style4

                            myTextbox.Style(CssProp.Key) = CssProp.Value

                        Next

                        myTextbox.TextMode = TextBoxMode.MultiLine
                        myTextbox.CssClass = "CssTextBox"
                        myTextbox.Text = desc4
                        If Me.IsClientPortal = True Then
                            myTextbox.ReadOnly = True
                        End If
                        tabindex += 10
                        myTextbox.TabIndex = tabindex
                        If textboxCount = 0 Then
                            Session("CBFirstTextbox") = "textbox" & CStr(ID4)
                        End If
                        textboxCount += 1
                    Loop
                    dr4.Close()
                Loop
                dr3.Close()
            Loop
            dr2.Close()
        Loop
        dr1.Close()
        Session("CBTextboxCount") = textboxCount
        Panel1.Controls.Add(MiscFN.NewLiteral(CloseSpacerTable))


    End Sub

    Private Sub refreshTemplate()
        Dim dr1, dr2, dr3, dr4 As SqlDataReader
        Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
        Dim desc4 As String
        Dim ID1, ID2, ID3, ID4 As Int16
        Dim szLen, szHt As Integer
        Dim textboxID As String

        dr1 = cb.getLevel1Data(JobNum, JobCompNum)
        Do While dr1.Read
            ID1 = dr1.GetInt16(2)

            dr2 = cb.getLevel2Data(CStr(ID1), JobNum, JobCompNum)
            Do While dr2.Read
                ID2 = dr2.GetInt16(2)

                dr3 = cb.getLevel3Data(CStr(ID2), JobNum, JobCompNum)
                Do While dr3.Read
                    ID3 = dr3.GetInt16(2)

                    dr4 = cb.getDetailData(CStr(ID3), JobNum, JobCompNum)
                    Do While dr4.Read
                        desc4 = dr4.GetString(1)
                        ID4 = dr4.GetInt32(0)

                        textboxID = "textbox" + CStr(ID4)
                        Dim myTextbox As System.Web.UI.WebControls.TextBox = Panel1.FindControl(textboxID)
                        myTextbox.Text = desc4

                    Loop
                    dr4.Close()
                Loop
                dr3.Close()
            Loop
            dr2.Close()
        Loop
        dr1.Close()
    End Sub

    Private Sub deleteCreativeBrief()
        Dim SQL_UPDATE_STR As String
        Dim oSQL As SqlHelper

        SQL_UPDATE_STR = "DELETE CRTV_BRF_DTL WHERE JOB_NUMBER = " & CStr(JobNum) & " AND JOB_COMPONENT_NBR = " & CStr(JobCompNum)

        Try
            oSQL.ExecuteNonQuery(CStr(Session("ConnString")), CommandType.Text, SQL_UPDATE_STR)
            Dim StrUrl
            If Request.QueryString("fw") = "ProjectView" Then
                StrUrl = "CreativeBrief_New.aspx?JobNo=" & Me.JobNum.ToString() & "&JobComp=" & Me.JobCompNum.ToString() & "&fw=ProjectView"
            Else
                StrUrl = "CreativeBrief_New.aspx?JobNo=" & Me.JobNum.ToString() & "&JobComp=" & Me.JobCompNum.ToString()
            End If
            Me.OpenWindow("New Creative Brief", StrUrl, 265, 625)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.aspx Routine:deleteCreativeBrief", Err.Description)
        End Try

    End Sub

    Private Sub SaveTemplate()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim crtv_brf_dtl_id As Integer
        Dim textboxID, textboxText As String
        Dim SQL_UPDATE_STR As String
        Dim textStr As String
        Dim szLen, szHt, rowsNbr As Integer

        Session("SaveOK") = 0

        SQL_STRING = "SELECT CRTV_BRF_DTL_ID "
        SQL_STRING &= " FROM CRTV_BRF_DTL "
        SQL_STRING &= " WHERE JOB_NUMBER = " & CStr(JobNum) & " AND JOB_COMPONENT_NBR = " & CStr(JobCompNum)

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch

            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:SaveTemplate", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            Do While dr.Read
                SQL_UPDATE_STR = "UPDATE CRTV_BRF_DTL SET CRTV_BRF_DTL_DESC = '"
                crtv_brf_dtl_id = dr.GetInt32(0)
                textboxID = "textbox" & CStr(crtv_brf_dtl_id)
                Dim myTextbox As System.Web.UI.WebControls.TextBox = Panel1.FindControl(textboxID)

                If myTextbox.Text = Nothing Then
                    textboxText = ""
                Else
                    textboxText = myTextbox.Text
                End If

                textStr = textboxText.Replace("'", "''")

                SQL_UPDATE_STR += textStr
                SQL_UPDATE_STR += "' WHERE JOB_NUMBER = " & CStr(JobNum) & " AND JOB_COMPONENT_NBR = " & CStr(JobCompNum) & " AND CRTV_BRF_DTL_ID = " & CStr(crtv_brf_dtl_id)

                Try
                    oSQL.ExecuteDataset(CStr(Session("ConnString")), CommandType.Text, SQL_UPDATE_STR)
                    szLen = textboxText.Length
                    If szLen <= 10000 Then
                        rowsNbr = szLen / 200
                    ElseIf szLen > 10000 And szLen <= 20000 Then
                        rowsNbr = szLen / 400
                    ElseIf szLen > 20000 Then
                        rowsNbr = szLen / 600
                    End If
                    If rowsNbr < 7 Then rowsNbr = 7
                    myTextbox.Rows = rowsNbr

                Catch
                    Session("SaveOK") = 0
                    Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:SaveTemplate", Err.Description)
                Finally
                End Try
            Loop
            dr.Close()
            Session("SaveOK") = 1

        Else    'Detail has no rows, allow to save
            Session("SaveOK") = 1
        End If



    End Sub

    Private Sub RadToolbarCreativeBrief_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarCreativeBrief.ButtonClick
        Select Case e.Item.Value
            Case "Save"
                Try
                    SaveTemplate()
                Catch ex As Exception
                    Me.ShowMessage("Error! " & ex.Message.ToString())
                End Try

            Case "Print"
                SaveTemplate()
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "CreativeBrief_Print.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

                Me.OpenPrintSendSilently(qs)

            Case "SendAlert"
                SaveTemplate()
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "CreativeBrief_Print.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                Me.OpenPrintSendSilently(qs)

            Case "SendAssignment"
                SaveTemplate()
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "CreativeBrief_Print.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

                Me.OpenPrintSendSilently(qs)

            Case "SendEmail"
                SaveTemplate()
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "CreativeBrief_Print.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)

                Me.OpenPrintSendSilently(qs)

            Case "PrintSendOptions"
                SaveTemplate()
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "CreativeBrief_Print.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                Me.OpenWindow(qs)



                'Case "Print"
                '    Me.OpenWindow("", "CreativeBrief_Print.aspx?Job=" & Me.JobNum.ToString() & "&JobComp=" & Me.JobCompNum.ToString())

            Case "Refresh"
                refreshTemplate()
            Case "Approve"
                SaveTemplate()
                If isApprovedVersion() = True Then  'Already approved, Unapprove
                    deleteApproval()
                Else    'Approve 
                    Dim StrURL As String = "CreativeBrief_Approved.aspx?JobNo=" & CStr(JobNum) & "&JobComp=" & CStr(JobCompNum)
                    Me.OpenWindow("Approve Version", StrURL, 245, 485, False, True, "RefreshPage")
                End If
                CheckApproval()
            Case "Delete"
                Dim existingtemps As Boolean
                Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
                Session("CBNewSaved") = 0
                Session("CBDeleted") = 0
                deleteApproval()
                deleteCreativeBrief()
                Dim StrURL As String
                If Request.QueryString("fw") = "ProjectView" Then
                    StrURL = "CreativeBrief_New.aspx?JobNo=" & Me.JobNum.ToString() & "&JobComp=" & Me.JobCompNum.ToString() & "&fw=ProjectView"
                Else
                    StrURL = "CreativeBrief_New.aspx?JobNo=" & Me.JobNum.ToString() & "&JobComp=" & Me.JobCompNum.ToString()
                End If
                If Me.CurrentQuerystring.IsJobDashboard = True Or Request.QueryString("jd") = "True" Then
                    MiscFN.ResponseRedirect(StrURL & "&jd=" & IIf(Me.CurrentQuerystring.IsJobDashboard, True, Request.QueryString("jd")), True)
                Else
                    Me.CloseThisWindowAndOpenNewWindow(StrURL)
                End If
        End Select
    End Sub

    Private Sub ApprVerBut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ApprVerBut.Click
        Dim StrURL As String = "CreativeBrief_Approved.aspx?JobNo=" & CStr(JobNum) & "&JobComp=" & CStr(JobCompNum)
        Me.OpenWindow("Approve Version", StrURL, 245, 485, False, True)
    End Sub

    Private Sub deleteApproval()
        Dim SQL_UPDATE_STR As String
        Dim oSQL As SqlHelper

        SQL_UPDATE_STR = "DELETE CRTV_BRF_APPR "
        SQL_UPDATE_STR += " WHERE JOB_NUMBER = " & CStr(JobNum) & " AND JOB_COMPONENT_NBR = " & CStr(JobCompNum)

        Try
            oSQL.ExecuteDataset(CStr(Session("ConnString")), CommandType.Text, SQL_UPDATE_STR)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:deleteApproval", Err.Description)
        Finally
        End Try

    End Sub

End Class
