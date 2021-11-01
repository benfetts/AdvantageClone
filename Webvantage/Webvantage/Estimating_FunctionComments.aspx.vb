Imports System.Data.SqlClient

Partial Public Class Estimating_FunctionComments
    Inherits Webvantage.BaseChildPage
    Private CancelScript As String = "javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
    'Private ThisTask_ROWID As Integer = 0
    Private ThisTask_EstNum As Integer = 0
    Private ThisTask_EstComp As Integer = 0
    Private ThisTask_QuoteNum As Integer = 0
    Private ThisTask_RevNum As Integer = 0
    Private ThisTask_SeqNum As Integer = 0
    Private JobNum As Integer = 0
    Private JobComp As Integer = 0
    Private SpecVer As Integer = 0
    Private SpecRev As Integer = 0
    Private StrDetailComments As String = ""
    Private StrSuppliedByNotes As String = ""
    Private ApprovalType As String = ""
    Private CampaignID As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Try
            ThisTask_EstNum = CType(Request.QueryString("EstNum"), Integer)
        Catch ex As Exception
            ThisTask_EstNum = 0
        End Try
        Try
            ThisTask_EstComp = CType(Request.QueryString("EstComp"), Integer)
        Catch ex As Exception
            ThisTask_EstComp = 0
        End Try
        Try
            ThisTask_QuoteNum = CType(Request.QueryString("QuoteNum"), Integer)
        Catch ex As Exception
            ThisTask_QuoteNum = 0
        End Try
        Try
            ThisTask_RevNum = CType(Request.QueryString("RevNum"), Integer)
        Catch ex As Exception
            ThisTask_RevNum = 0
        End Try
        Try
            ThisTask_SeqNum = CType(Request.QueryString("SeqNum"), Integer)
        Catch ex As Exception
            ThisTask_SeqNum = 0
        End Try
        Try
            JobNum = CType(Request.QueryString("JobNum"), Integer)
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            JobComp = CType(Request.QueryString("JobComp"), Integer)
        Catch ex As Exception
            JobComp = 0
        End Try
        Try
            SpecVer = CType(Request.QueryString("SpecVer"), Integer)
        Catch ex As Exception
            SpecVer = 0
        End Try
        Try
            SpecRev = CType(Request.QueryString("SpecRev"), Integer)
        Catch ex As Exception
            SpecRev = 0
        End Try
        Try
            CampaignID = CType(Request.QueryString("CampaignID"), Integer)
        Catch ex As Exception
            CampaignID = 0
        End Try

        If CampaignID > 0 Then
            ApprovalType = "CMP"
        End If


        If Not Me.IsPostBack Then
            Try
                Dim dt As DataTable
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                dt = est.GetEstimateQuoteDetailBySeq(ThisTask_EstNum, ThisTask_EstComp, ThisTask_QuoteNum, ThisTask_RevNum, ThisTask_SeqNum)
                If dt.Rows.Count > 0 Then
                    If Not Session("EstImportSpecText") Is Nothing Then
                        If Session("EstImportSpecText") <> "" Then
                            Me.RadEditorDetailComment.Content = Session("EstImportSpecText")
                        End If
                    Else
                        If dt.Rows(0)("EST_FNC_COMMENT_HTML") <> "" Then
                            Me.RadEditorDetailComment.Html = dt.Rows(0)("EST_FNC_COMMENT_HTML")
                        Else
                            Me.RadEditorDetailComment.Content = dt.Rows(0)("EST_FNC_COMMENT").Replace(vbLf, "<br />").Replace(vbCrLf, "<br />")
                        End If
                    End If
                    If dt.Rows(0)("EST_REV_SUP_BY_HTML") <> "" Then
                        Me.RadEditorSuppliedByNotes.Html = dt.Rows(0)("EST_REV_SUP_BY_HTML")
                    Else
                        Me.RadEditorSuppliedByNotes.Content = dt.Rows(0)("EST_REV_SUP_BY_NTE").Replace(vbLf, "<br />").Replace(vbCrLf, "<br />")
                    End If
                End If
                Session("EstImportSpecText") = Nothing
                
                If Me.JobNum = 0 Then
                    Me.BtnImportSpecs.Enabled = False
                End If

                Dim dr As SqlDataReader
                Dim drInt As SqlDataReader
                Dim approvalInt As Boolean = False
                Dim approval As Boolean = False
                Dim ag As New cAgency(Session("ConnString"))
                Dim max As Integer = est.GetEstimateQuoteMaxRevision(ThisTask_EstNum, ThisTask_EstComp, ThisTask_QuoteNum)
                Dim agrev As Boolean = ag.AutoEstRevFlag()
                drInt = est.GetQuoteApprovalInternal(ThisTask_EstNum, ThisTask_EstComp, ThisTask_QuoteNum, ThisTask_RevNum, ApprovalType)
                dr = est.GetQuoteApproval(ThisTask_EstNum, ThisTask_EstComp, ThisTask_QuoteNum, ThisTask_RevNum, ApprovalType)
                If dr.HasRows = True Then
                    approval = True
                End If
                If drInt.HasRows = True Then
                    approvalInt = True
                End If
                If (max <> ThisTask_RevNum) Or (agrev = True And approval = True) Or (agrev = True And approvalInt = True) Then
                    Me.BtnSave.Enabled = False
                    Me.BtnImportSpecs.Enabled = False
                    Me.RadEditorDetailComment.Enabled = False
                    Me.RadEditorSuppliedByNotes.Enabled = False
                Else
                    Me.BtnSave.Enabled = True
                    Me.BtnImportSpecs.Enabled = True
                    Me.RadEditorDetailComment.Enabled = True
                    Me.RadEditorSuppliedByNotes.Enabled = True
                End If
            Catch ex As Exception

            End Try
        End If
        Me.CheckUserRights()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        est.UpdateQuoteComments(ThisTask_EstNum, ThisTask_EstComp, ThisTask_QuoteNum, ThisTask_RevNum, ThisTask_SeqNum, Me.RadEditorDetailComment.Text, Me.RadEditorSuppliedByNotes.Text, Me.RadEditorDetailComment.Html, Me.RadEditorSuppliedByNotes.Html)
        CloseAndRefresh()
    End Sub
    Private Sub CloseAndRefresh()
        Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx")
    End Sub

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")

            If secView = "N" Then
                Server.Transfer("NoAccess.aspx")
            ElseIf secView = "Y" Then
                If secEdit = "N" And secInsert = "N" Then
                    Me.RadEditorDetailComment.Enabled = False
                    Me.RadEditorSuppliedByNotes.Enabled = False
                    Me.BtnImportSpecs.Enabled = False
                    Me.BtnSave.Enabled = False
                ElseIf secEdit = "Y" And secInsert = "N" Then

                ElseIf secEdit = "N" And secInsert = "Y" Then

                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Private Sub BtnImportSpecs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImportSpecs.Click
    '    Try
    '        'With Me.RadWindowManager.Windows(0)
    '        '    .NavigateUrl = "Estimating_ImportSpecs.aspx?EstNum=" & Me.ThisTask_EstNum & "&EstCompNum=" & Me.ThisTask_EstComp & "&QuoteNum=" & Me.ThisTask_QuoteNum & "&RevNum=" & Me.ThisTask_RevNum & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobComp & "&SpecVer=" & Me.SpecVer & "&SpecRev=" & Me.SpecRev
    '        '    .Title = "Import Spec with Estimate"
    '        '    .Modal = True
    '        '    .Height = New Unit(500, UnitType.Pixel)
    '        '    .Width = New Unit(550, UnitType.Pixel)
    '        '    .InitialBehavior = Telerik.Web.UI.WindowBehaviors.None
    '        '    .ReloadOnShow = True
    '        '    .Behavior = Telerik.Web.UI.WindowBehaviors.None
    '        '    .Skin = MiscFN.SetRadWindowSkin '"WebBlue"
    '        '    .VisibleOnPageLoad = True
    '        '    .VisibleStatusbar = False
    '        'End With
    '        Dim strURL As String
    '        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
    '        strURL = "Estimating_ImportSpecs.aspx?EstNum=" & Me.ThisTask_EstNum & "&EstCompNum=" & Me.ThisTask_EstComp & "&QuoteNum=" & Me.ThisTask_QuoteNum & "&RevNum=" & Me.ThisTask_RevNum & "&JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobComp & "&SpecVer=" & Me.SpecVer & "&SpecRev=" & Me.SpecRev
    '        strBuilder.Append("<script language='javascript'>")
    '        strBuilder.Append("window.open('" & strURL & "', 'WinISPopup', 'screenX=150,left=150,screenY=150,top=150,width=1000,height=600,scrollbars=yes,resizable=yes,menubar=no,maximazable=yes')")
    '        strBuilder.Append("</")
    '        strBuilder.Append("script>")
    '        Dim str2 As String = strBuilder.ToString
    '        Page.RegisterStartupScript("newpage", strBuilder.ToString())
    '    Catch ex As Exception

    '    End Try
    'End Sub



    'Private Sub BtnImportSpecs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImportSpecs.Click
    '    Try
    '        If Me.SpecVer = 0 Then
    '            Me.lblMSG.Text = "There are no specs associated with this quote."
    '            Exit Sub
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.CloseThisWindow()
    End Sub

    Private Sub BtnImportSpecs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImportSpecs.Click
        Try
            Dim strURL As String
            Try
                Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim str As String = Me.RadEditorDetailComment.ClientID
                strURL = "Estimating_ImportSpecs.aspx?EstNum=" & Me.ThisTask_EstNum & "&EstComp=" & Me.ThisTask_EstComp & "&QuoteNum=" & Me.ThisTask_QuoteNum & "&RevNum=" & Me.ThisTask_RevNum & "&SeqNum= " & ThisTask_SeqNum & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobComp & "&SpecVer=" & Me.SpecVer & "&SpecRev=" & Me.SpecRev & "&control=" & Me.RadEditorDetailComment.ClientID
                If Me.JobNum = 0 Then
                    Me.ShowMessage("There are no specs associated with this quote.")
                    Exit Sub
                End If
                Me.OpenWindow("", strURL, , , False, True)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class