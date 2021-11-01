Imports System.Data.SqlClient

Partial Public Class VendorQuote_Comments
    Inherits Webvantage.BaseChildPage

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
    Private VendorQteNbr As Integer
    Private fromgrid As String
    Private VendorCode As String
    Private FuncCode As String
    Private rights As String

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
            VendorQteNbr = CType(Request.QueryString("reqNum"), Integer)
        Catch ex As Exception
            VendorQteNbr = 0
        End Try
        Try
            VendorCode = Request.QueryString("vncode")
        Catch ex As Exception
            VendorCode = ""
        End Try
        Try
            FuncCode = Request.QueryString("funccode")
        Catch ex As Exception
            FuncCode = ""
        End Try

        If Not Me.IsPostBack Then
            Try


                Dim ds As DataSet
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                If Request.QueryString("From") = "quote" Then
                    Me.cbEstimate.Visible = False
                    Me.cbComponent.Visible = False
                    Me.cbFunction.Visible = False
                    If Not Session("VendorReqQuoteText") Is Nothing Then
                        If Session("VendorReqQuoteText") <> "" Then
                            Me.TxtComments.Text = Session("VendorReqQuoteText")
                        End If
                    Else
                        ds = est.GetRequestQuotes(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, ThisTask_QuoteNum, Session("UserCode"))
                        If ds.Tables(0).Rows.Count > 0 Then
                            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                                If CInt(ds.Tables(0).Rows(i)("EST_QUOTE_NBR")) = ThisTask_QuoteNum Then
                                    If IsDBNull(ds.Tables(0).Rows(i)("VN_QTE_SPECS")) = False Then
                                        Me.TxtComments.Text = ds.Tables(0).Rows(i)("VN_QTE_SPECS")
                                    End If
                                End If
                            Next
                        End If
                    End If
                ElseIf Request.QueryString("From") = "vendor" Then
                    Me.cbEstimate.Visible = False
                    Me.cbComponent.Visible = False
                    Me.BtnImportSpecs.Enabled = False
                    Me.cbQuote.Visible = False
                    Me.cbFunction.Visible = False
                    If Not Session("VendorReqVendorText") Is Nothing Then
                        If Session("VendorReqVendorText") <> "" Then
                            Me.TxtComments.Text = Session("VendorReqVendorText")
                        End If
                    Else
                        ds = est.GetRequestVendors(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, Session("UserCode"))
                        If ds.Tables(0).Rows.Count > 0 Then
                            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                                If ds.Tables(0).Rows(i)("VN_CODE") = VendorCode Then
                                    If IsDBNull(ds.Tables(0).Rows(i)("VN_NOTES")) = False Then
                                        Me.TxtComments.Text = ds.Tables(0).Rows(i)("VN_NOTES")
                                    End If
                                End If
                            Next
                        End If
                    End If
                ElseIf Request.QueryString("From") = "vendorrep" Then
                    Me.cbEstimate.Visible = False
                    Me.cbComponent.Visible = False
                    Me.BtnImportSpecs.Enabled = False
                    Me.PanelDetailComments.Visible = False
                    Me.PanelNotesComments.Visible = True
                    Me.cbFunction.Visible = False
                    If Not Session("VendorReqVendorReplyText") Is Nothing Then
                        If Session("VendorReqVendorReplyText") <> "" Then
                            Me.TxtCom.Text = Session("VendorReqVendorReplyText")
                        End If
                    Else
                        ds = est.GetRequestVendorReplies(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, Session("UserCode"))
                        If ds.Tables(0).Rows.Count > 0 Then
                            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                                If CInt(ds.Tables(0).Rows(i)("EST_QUOTE_NBR")) = ThisTask_QuoteNum And CInt(ds.Tables(0).Rows(i)("EST_REV_NBR")) = ThisTask_RevNum And ds.Tables(0).Rows(i)("EST_FNC_CODE") = FuncCode And ds.Tables(0).Rows(i)("VN_CODE") = VendorCode Then
                                    If IsDBNull(ds.Tables(0).Rows(i)("REPLY_NOTES")) = False Then
                                        Me.TxtCom.Text = ds.Tables(0).Rows(i)("REPLY_NOTES")
                                    End If
                                    If IsDBNull(ds.Tables(0).Rows(i)("APPROVAL_NOTES")) = False Then
                                        Me.TxtNotes.Text = ds.Tables(0).Rows(i)("APPROVAL_NOTES")
                                    End If
                                End If
                            Next
                        End If
                    End If
                ElseIf Request.QueryString("From") = "header" Then
                    Me.cbQuote.Visible = False
                    Me.cbFunction.Visible = False
                    If Not Session("VendorReqHeaderText") Is Nothing Then
                        If Session("VendorReqHeaderText") <> "" Then
                            Me.TxtComments.Text = Session("VendorReqHeaderText")
                        End If
                    Else
                        ds = est.GetRequestData(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, Session("UserCode"))
                        If ds.Tables(0).Rows.Count > 0 Then
                            If IsDBNull(ds.Tables(0).Rows(0)("VN_QTE_MEMO")) = False Then
                                Me.TxtComments.Text = ds.Tables(0).Rows(0)("VN_QTE_MEMO")
                            End If
                        End If
                    End If
                ElseIf Request.QueryString("From") = "func" Then
                    Me.cbQuote.Visible = False
                    Me.cbEstimate.Visible = False
                    Me.cbComponent.Visible = False
                    If Not Session("VendorReqFunctionText") Is Nothing Then
                        If Session("VendorReqFunctionText") <> "" Then
                            Me.TxtComments.Text = Session("VendorReqFunctionText")
                        End If
                    Else
                        ds = est.GetRequestQuotes(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, ThisTask_QuoteNum, Session("UserCode"))
                        If ds.Tables(1).Rows.Count > 0 Then
                            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                                If ds.Tables(1).Rows(i)("EST_FNC_CODE") = FuncCode Then
                                    If IsDBNull(ds.Tables(1).Rows(i)("FNC_NOTES")) = False Then
                                        Me.TxtComments.Text = ds.Tables(1).Rows(i)("FNC_NOTES")
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
                Session("VendorReqQuoteText") = Nothing
                Session("VendorReqVendorText") = Nothing
                Session("VendorReqVendorReplyText") = Nothing
                Session("VendorReqHeaderText") = Nothing
                Session("VendorReqFunctionText") = Nothing
                
                If Me.JobNum = 0 Then
                    Me.BtnImportSpecs.Enabled = False
                End If
                Me.CheckUserRights()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            If Request.QueryString("From") = "quote" Then
                est.UpdateRequestQuote(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, ThisTask_QuoteNum, ThisTask_RevNum, Me.TxtComments.Text)
            ElseIf Request.QueryString("From") = "vendor" Then
                est.UpdateRequestVendorComment(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, VendorCode, Me.TxtComments.Text)
            ElseIf Request.QueryString("From") = "vendorrep" Then
                est.UpdateRequestDetailComments(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, ThisTask_QuoteNum, ThisTask_RevNum, FuncCode, VendorCode, Me.TxtCom.Text, Me.TxtNotes.Text)
            ElseIf Request.QueryString("From") = "header" Then
                est.UpdateRequestMemo(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, Me.TxtComments.Text, Session("UserCode"))
            ElseIf Request.QueryString("From") = "func" Then
                est.UpdateRequestFunction(ThisTask_EstNum, ThisTask_EstComp, VendorQteNbr, FuncCode, Me.TxtComments.Text)
            End If
            CloseAndRefresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CloseAndRefresh()
        Me.CloseThisWindowAndRefreshCaller("VendorQuote.aspx")
    End Sub

    Private Sub cbQuote_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuote.CheckedChanged
        Try
            If cbQuote.Checked = True Then
                Dim dr As SqlDataReader
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                dr = est.GetEstimateQuoteInfo(ThisTask_EstNum, ThisTask_EstComp, ThisTask_QuoteNum, ThisTask_RevNum)
                If dr.HasRows = True Then
                    dr.Read()
                    If IsDBNull(dr("EST_QTE_COMMENT")) = False Then
                        Me.TxtComments.Text = dr("EST_QTE_COMMENT")
                    End If
                End If
            Else
                Me.TxtComments.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbEstimate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEstimate.CheckedChanged
        Try
            If cbEstimate.Checked = True Then
                Me.cbComponent.Checked = False
                Dim dt As DataTable
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                dt = est.GetEstimateData(ThisTask_EstNum, ThisTask_EstComp, 0, 0, Session("UserCode"))
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("EST_LOG_COMMENT")) = False Then
                        Me.TxtComments.Text = dt.Rows(0)("EST_LOG_COMMENT")
                    Else
                        Me.TxtComments.Text = ""
                    End If
                End If
            Else
                Me.TxtComments.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbComponent_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbComponent.CheckedChanged
        Try
            If cbComponent.Checked = True Then
                Me.cbEstimate.Checked = False
                Dim dt As DataTable
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                dt = est.GetEstimateData(ThisTask_EstNum, ThisTask_EstComp, 0, 0, Session("UserCode"))
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("EST_COMP_COMMENT")) = False Then
                        Me.TxtComments.Text = dt.Rows(0)("EST_COMP_COMMENT")
                    Else
                        Me.TxtComments.Text = ""
                    End If
                End If
            Else
                Me.TxtComments.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbFunction_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFunction.CheckedChanged
        Try
            If cbFunction.Checked = True Then
                Dim ds As DataSet
                Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                ds = est.GetEstimateQuoteDetailsDS(ThisTask_EstNum, ThisTask_EstComp, ThisTask_QuoteNum, ThisTask_RevNum)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        If IsDBNull(ds.Tables(0).Rows(i)("EST_FNC_COMMENT")) = False Then
                            Me.TxtComments.Text = Me.TxtComments.Text & ds.Tables(0).Rows(i)("EST_FNC_COMMENT") & vbCrLf
                        End If
                    Next
                End If
            Else
                Me.TxtComments.Text = ""
            End If
        Catch ex As Exception

        End Try
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
                    Me.TxtComments.ReadOnly = True
                    Me.TxtCom.ReadOnly = True
                    Me.TxtNotes.ReadOnly = True
                    Me.BtnImportSpecs.Enabled = False
                    Me.BtnSave.Enabled = False
                    Me.cbEstimate.Enabled = False
                    Me.cbComponent.Enabled = False
                    Me.cbQuote.Enabled = False
                    Me.cbFunction.Enabled = False
                ElseIf secEdit = "Y" And secInsert = "N" Then

                ElseIf secEdit = "N" And secInsert = "Y" Then

                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.CloseThisWindow()
    End Sub

    Private Sub BtnImportSpecs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImportSpecs.Click
        Try
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim str As String = Me.TxtComments.ClientID
            fromgrid = Request.QueryString("From")
            Dim strURL As String
            strURL = "VendorQuote_ImportSpecs.aspx?From=" & fromgrid & "&EstNum=" & Me.ThisTask_EstNum & "&EstComp=" & Me.ThisTask_EstComp & "&QuoteNum=" & Me.ThisTask_QuoteNum & "&RevNum=" & Me.ThisTask_RevNum & "&SeqNum= " & ThisTask_SeqNum & "&JobNum=" & Me.JobNum & "&JobComp=" & Me.JobComp & "&SpecVer=" & Me.SpecVer & "&SpecRev=" & Me.SpecRev & "&control=" & Me.TxtComments.ClientID & "&VendorQteNbr=" & Me.VendorQteNbr & "&funccode=" & Me.FuncCode

            If Me.JobNum = 0 Then
                Me.ShowMessage("There are no specs associated with this quote.")
            End If
            Me.OpenWindow("", strURL, 500, 700, False, True)
            'Me.CloseThisWindowAndRefreshCaller("VendorQuote.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class