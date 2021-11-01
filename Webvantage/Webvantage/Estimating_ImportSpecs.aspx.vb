Imports System.Data.SqlClient

Public Class Estimating_ImportSpecs
    Inherits Webvantage.BaseChildPage

    Private EstNum As Integer
    Private EstCompNum As Integer
    Private QuoteNum As Integer
    Private RevNum As Integer
    Private SeqNum As Integer
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private SpecVer As Integer = 0
    Private SpecRev As Integer = 0
    Private PONum As Integer = 0
    Private LineNum As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsNumeric(Request.QueryString("EstNum")) = True Then
                EstNum = CType(Request.QueryString("EstNum"), Integer)
            Else
                EstNum = 0
            End If
        Catch ex As Exception
            EstNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("EstComp")) = True Then
                EstCompNum = CType(Request.QueryString("EstComp"), Integer)
            Else
                EstCompNum = 0
            End If
        Catch ex As Exception
            EstCompNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("QuoteNum")) = True Then
                QuoteNum = CType(Request.QueryString("QuoteNum"), Integer)
            Else
                QuoteNum = 0
            End If
        Catch ex As Exception
            QuoteNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("RevNum")) = True Then
                RevNum = CType(Request.QueryString("RevNum"), Integer)
            Else
                RevNum = 0
            End If
        Catch ex As Exception
            RevNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("SeqNum")) = True Then
                SeqNum = CType(Request.QueryString("SeqNum"), Integer)
            Else
                SeqNum = 0
            End If
        Catch ex As Exception
            SeqNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("JobNum")) = True Then
                JobNum = CType(Request.QueryString("JobNum"), Integer)
            Else
                JobNum = 0
            End If
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("JobComp")) = True Then
                JobCompNum = CType(Request.QueryString("JobComp"), Integer)
            Else
                JobCompNum = 0
            End If
        Catch ex As Exception
            JobCompNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("SpecVer")) = True Then
                SpecVer = CType(Request.QueryString("SpecVer"), Integer)
            Else
                SpecVer = 0
            End If
        Catch ex As Exception
            SpecVer = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("SpecRev")) = True Then
                SpecRev = CType(Request.QueryString("SpecRev"), Integer)
            Else
                SpecRev = 0
            End If
        Catch ex As Exception
            SpecRev = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("PONum")) = True Then
                PONum = CType(Request.QueryString("PONum"), Integer)
            Else
                PONum = 0
            End If
        Catch ex As Exception
            PONum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("LineNum")) = True Then
                LineNum = CType(Request.QueryString("LineNum"), Integer)
            Else
                LineNum = 0
            End If
        Catch ex As Exception
            LineNum = 0
        End Try

        If Not Me.IsPostBack Then
            If Request.QueryString("control").Contains("CommentsEstimate") = True Or Request.QueryString("control").Contains("CommentsComponent") = True Or
                Request.QueryString("control").Contains("det_desc") = True Or Request.QueryString("control").Contains("det_instruct") = True Or
                Request.QueryString("control").Contains("DetailDescription") = True Or Request.QueryString("control").Contains("Instructions") = True Then

                Me.rbSelectQuote.Visible = True
                Me.rbSelectCategories.Visible = True
                Me.rbSelectQuote.Checked = True
                Me.lblSpecs.Visible = False
            ElseIf Me.SpecVer = 0 Then
                Me.rbSelectQuote.Visible = True
                Me.rbSelectCategories.Visible = True
                Me.rbSelectQuote.Checked = True
                Me.lblSpecs.Visible = False
            Else
                Me.rbSelectQuote.Visible = False
                Me.rbSelectCategories.Visible = False
            End If
            Me.checkchanged()
            loadSpecCategories()
            Me.txtSpecs.Text = CreateText(Me.JobNum, Me.JobCompNum, Me.SpecVer, Me.SpecRev)
        End If
        Me.CheckUserRights()
    End Sub

    Private Sub RadGridSpecs_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridSpecs.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

        End If
    End Sub

    Private Sub RadGridSpecs_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSpecs.NeedDataSource
        Try
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim dt As New DataTable
            If Request.QueryString("control").Contains("det_desc") = True Or Request.QueryString("control").Contains("det_instruct") = True Or
                 Request.QueryString("control").Contains("DetailDescription") = True Or Request.QueryString("control").Contains("Instructions") = True Then

                dt = est.GetEstimateImportSpecsJC(Me.JobNum, Me.JobCompNum)
            Else
                dt = est.GetEstimateImportSpecs(Me.EstNum, Me.EstCompNum)
            End If
            Me.RadGridSpecs.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridSpecs_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridSpecs.PreRender

    End Sub

    Private Sub CloseAndRefresh()
        Dim FromPO As Boolean = False

        Dim FunctionName As String
        If Request.QueryString("control").Contains("QuoteComment") = True Then
            Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx")
            Exit Sub
        End If
        If Request.QueryString("control").Contains("RevisionComment") = True Then
            Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx")
            Exit Sub
        End If
        If Request.QueryString("control").Contains("EstimateComment") = True Then
            If Request.QueryString("jd") = 1 Then
                Me.CloseThisWindowAndRefreshCaller("Content.aspx?contaid=10&j=" & JobNum & "&jc=" & JobCompNum)
            Else
                Me.CloseThisWindowAndRefreshCaller("Estimating.aspx")
            End If
            Exit Sub
        End If
        If Request.QueryString("control").Contains("ComponentComment") = True Then
            If Request.QueryString("jd") = 1 Then
                Me.CloseThisWindowAndRefreshCaller("Content.aspx?contaid=10&j=" & JobNum & "&jc=" & JobCompNum)
            Else
                Me.CloseThisWindowAndRefreshCaller("Estimating.aspx")
            End If
            Exit Sub
        End If
        If Request.QueryString("control").Contains("det_desc") = True Then
            FunctionName = "SpecsDesc"
        End If
        If Request.QueryString("control").Contains("det_instruct") = True Then
            FunctionName = "SpecsInstruct"
        End If
        If Request.QueryString("control").Contains("DetailDescription") = True Then
            FunctionName = "SpecsDesc"
        End If
        If Request.QueryString("control").Contains("TextBoxInstructions") = True Then
            FunctionName = "SpecsInstruct"
        End If
        If Request.QueryString("control").Contains("RadEditorDetailComment") = True Then
            Me.CloseThisWindowAndRefreshCaller("Estimating_FunctionComments.aspx")
            Exit Sub
        End If
        Select Case Me.CallingPage()
            Case "purchaseorder_dtl.aspx"
                Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
                'Me.CloseThisWindowAndRefreshCaller("purchaseorder_dtl.aspx")
            Case Else
                Me.CallFunctionOnParentPage(Me.CallingPage(), FunctionName, True)
        End Select
        'Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
    End Sub

    Private Sub rbSelectQuote_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSelectQuote.CheckedChanged
        checkchanged()
    End Sub

    Private Sub rbSelectCategories_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSelectCategories.CheckedChanged
        checkchanged()
    End Sub

    Private Sub checkchanged()
        Try
            If Request.QueryString("control").Contains("CommentsEstimate") = True Or Request.QueryString("control").Contains("CommentsComponent") = True Or
                Request.QueryString("control").Contains("det_desc") = True Or Request.QueryString("control").Contains("det_instruct") = True Or
                Me.SpecVer = 0 Or Request.QueryString("control").Contains("DetailDescription") = True Or Request.QueryString("control").Contains("Instructions") Then

                If rbSelectQuote.Checked = True Then
                    Me.pnlSelectQuote.Visible = True
                    Me.pnlSelectCategories.Visible = False
                End If
                If rbSelectCategories.Checked = True Then
                    Me.pnlSelectCategories.Visible = True
                    Me.pnlSelectQuote.Visible = False
                    loadSpecCategories()
                    Dim chk As CheckBox
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridSpecs.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            Me.SpecVer = CInt(gridDataItem("colSPEC_VER").Text.Replace("&nbsp;", ""))
                            Me.SpecRev = CInt(gridDataItem("colSPEC_REV").Text.Replace("&nbsp;", ""))
                            Session("ImportSpecsSpecVer") = Me.SpecVer
                            Session("ImportSpecsSpecRev") = Me.SpecRev
                        End If
                    Next
                    Me.txtSpecs.Text = CreateText(Me.JobNum, Me.JobCompNum, Me.SpecVer, Me.SpecRev)
                End If
            Else
                Me.pnlSelectCategories.Visible = True
                Me.pnlSelectQuote.Visible = False
                loadSpecCategories()
                Me.txtSpecs.Text = CreateText(Me.JobNum, Me.JobCompNum, Me.SpecVer, Me.SpecRev)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadSpecCategories()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim spectype As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
            With lbSpecs
                .DataTextField = "CATEGORY_DESC"
                .DataValueField = "CATEGORY_ID"
                .DataSource = js.GetJobSpecCategories(spectype)
                .DataBind()
            End With

            Dim i As Integer
            For i = 0 To Me.lbSpecs.Items.Count - 1
                Me.lbSpecs.Items(i).Selected = True
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function CreateText(ByVal jobnum As Integer, ByVal jobcomp As Integer, ByVal specver As Integer, ByVal specrev As Integer)
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim catHeader As String = "================================================================"
            Dim catSubHeader As String = "--------------------------------"
            Dim sbSpecs As New System.Text.StringBuilder
            Dim i As Integer
            Dim j As Integer

            Dim ds As DataSet
            ds = js.GetJobSpecsDataSet(jobnum, jobcomp, specver, specrev)

            For i = 0 To Me.lbSpecs.Items.Count - 1
                If lbSpecs.Items(i).Selected = True Then
                    sbSpecs.AppendLine(catHeader)
                    sbSpecs.AppendLine(Me.lbSpecs.Items(i).Text)
                    sbSpecs.AppendLine(catHeader)
                    For j = 0 To ds.Tables(0).Rows.Count - 1
                        If lbSpecs.Items(i).Value = ds.Tables(0).Rows(j)("CATEGORY_ID") Then
                            If ds.Tables(0).Rows(j)("CONTROL_TYPE") = 4 Or ds.Tables(0).Rows(j)("CONTROL_TYPE") = 5 Then
                                sbSpecs.AppendLine(catSubHeader)
                                sbSpecs.AppendLine(ds.Tables(0).Rows(j)("SHORT_DESC"))
                                sbSpecs.AppendLine(catSubHeader)
                                sbSpecs.AppendLine(ds.Tables(0).Rows(j)("FIELD_VALUE"))
                                sbSpecs.AppendLine("")
                            Else
                                sbSpecs.AppendLine(ds.Tables(0).Rows(j)("SHORT_DESC") & ":  " & ds.Tables(0).Rows(j)("FIELD_VALUE"))
                            End If
                        End If
                    Next
                End If
            Next
            Return sbSpecs.ToString.Replace("#semicolon#", ";")
        Catch ex As Exception

        End Try
    End Function

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim strScript As String
            Dim cScript As String
            Dim SpecText As String
            Dim dt As DataTable
            Dim dr As SqlDataReader
            If Request.QueryString("control").Contains("EstimateComment") = True Or
                Request.QueryString("control").Contains("ComponentComment") = True Or
                Request.QueryString("control").Contains("det_desc") = True Or
                Request.QueryString("control").Contains("det_instruct") = True Or
                Request.QueryString("control").Contains("DetailDescription") = True Or
                Request.QueryString("control").Contains("Instructions") = True Then
                If rbSelectQuote.Checked = True Then
                    Dim chk As CheckBox
                    Dim specv As Integer
                    Dim specr As Integer
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridSpecs.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked Then
                            Try
                                specv = CType(gridDataItem.Item("colSPEC_VER").Text, Integer)
                            Catch ex As Exception
                                specv = 0
                            End Try
                            Try
                                specr = CType(gridDataItem.Item("colSPEC_REV").Text, Integer)
                            Catch ex As Exception
                                specr = 0
                            End Try
                            SpecText = CreateText(Me.JobNum, Me.JobCompNum, specv, specr)
                            'est.UpdateQuoteComments(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, Me.SeqNum, Me.TxtDetailComments.Text, Me.TxtSuppliedByNotes.Text)
                        End If
                    Next
                End If
                If rbSelectCategories.Checked = True Then
                    SpecText = Me.txtSpecs.Text
                    Me.CloseAndRefresh()
                End If
            ElseIf Me.SpecVer = 0 Then
                If rbSelectQuote.Checked = True Then
                    Dim chk As CheckBox
                    Dim specv As Integer
                    Dim specr As Integer
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridSpecs.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked Then
                            Try
                                specv = CType(gridDataItem.Item("colSPEC_VER").Text, Integer)
                            Catch ex As Exception
                                specv = 0
                            End Try
                            Try
                                specr = CType(gridDataItem.Item("colSPEC_REV").Text, Integer)
                            Catch ex As Exception
                                specr = 0
                            End Try
                            SpecText = CreateText(Me.JobNum, Me.JobCompNum, specv, specr)
                            'est.UpdateQuoteComments(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, Me.SeqNum, Me.TxtDetailComments.Text, Me.TxtSuppliedByNotes.Text)
                        End If
                    Next
                    'Session("EstImportSpecText") = SpecText
                End If
                If rbSelectCategories.Checked = True Then
                    SpecText = Me.txtSpecs.Text
                End If
                'If Request.QueryString("control").Contains("CommentsQuote") = True Or Request.QueryString("control").Contains("CommentsRevision") = True Then
                '    Me.CloseAndRefresh()
                'Else
                '    strScript = "<script type=""text/javascript"">"
                '    '    strScript &= "opener.document.forms[0]." & Request.QueryString("control") & ".value = '" & Me.txtSpecs.Text & "';"
                '    strScript &= "window.close();</script>"
                '    If Not Page.IsStartupScriptRegistered("Webvantage") Then
                '        Page.RegisterStartupScript("Webvantage", strScript)
                '    End If
                '    cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
                '    RegisterStartupScript("parentwindow", cScript)
                'End If
            Else
                'If Request.QueryString("control").Contains("CommentsQuote") = True Or Request.QueryString("control").Contains("CommentsRevision") = True Then
                SpecText = Me.txtSpecs.Text
                '    Me.CloseAndRefresh()
                'Else
                '    Session("EstImportSpecText") = Me.txtSpecs.Text
                '    strScript = "<script type=""text/javascript"">"
                '    '    strScript &= "opener.document.forms[0]." & Request.QueryString("control") & ".value = '" & Me.txtSpecs.Text & "';"
                '    strScript &= "window.close();</script>"
                '    If Not Page.IsStartupScriptRegistered("Webvantage") Then
                '        Page.RegisterStartupScript("Webvantage", strScript)
                '    End If
                '    cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
                '    RegisterStartupScript("parentwindow", cScript)
                'End If
            End If

            Dim estlog As String
            Dim estcomp As String
            Dim estquote As String
            Dim estrev As String
            If Request.QueryString("control").Contains("EstimateComment") = True Then
                dt = est.GetEstimateData(EstNum, EstCompNum, JobNum, JobCompNum, Session("UserCode"))
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("EST_COMP_COMMENT")) = False Then
                        estcomp = dt.Rows(0)("EST_COMP_COMMENT")
                    End If
                End If
                est.UpdateEstimateComments(Me.EstNum, Me.EstCompNum, estcomp, SpecText)
            ElseIf Request.QueryString("control").Contains("ComponentComment") = True Then
                dt = est.GetEstimateData(EstNum, EstCompNum, JobNum, JobCompNum, Session("UserCode"))
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("EST_LOG_COMMENT")) = False Then
                        estlog = dt.Rows(0)("EST_LOG_COMMENT")
                    End If
                End If
                est.UpdateEstimateComments(Me.EstNum, Me.EstCompNum, SpecText, estlog)
            ElseIf Request.QueryString("control").Contains("QuoteComment") = True Then
                dr = est.GetEstimateQuoteInfo(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum)
                If dr.HasRows = True Then
                    dr.Read()
                    estrev = dr("EST_REV_COMMENT")
                    dr.Close()
                End If
                est.UpdateEstimateCommentsQuote(Me.EstNum, Me.EstCompNum, Me.QuoteNum, SpecText, Me.RevNum, estrev)
            ElseIf Request.QueryString("control").Contains("RevisionComment") = True Then
                dr = est.GetEstimateQuoteInfo(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum)
                If dr.HasRows = True Then
                    dr.Read()
                    estquote = dr("EST_QTE_COMMENT")
                    dr.Close()
                End If
                est.UpdateEstimateCommentsQuote(Me.EstNum, Me.EstCompNum, Me.QuoteNum, estquote, Me.RevNum, SpecText)
            ElseIf Request.QueryString("control").Contains("det_desc") = True OrElse Request.QueryString("control").Contains("DetailDescription") Then
                'Dim PODtl As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                'PODtl.UpdatePODetailMemoText("det_desc", PONum, LineNum, SpecText)
                Session("EstImportSpecText") = SpecText
            ElseIf Request.QueryString("control").Contains("det_instruct") = True OrElse Request.QueryString("control").Contains("Instructions") Then
                'Dim PODtl As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
                'PODtl.UpdatePODetailMemoText("det_instruct", PONum, LineNum, SpecText)
                Session("EstImportSpecText") = SpecText
            ElseIf Request.QueryString("control").Contains("RadEditorDetailComment") = True Then
                dt = est.GetEstimateQuoteDetailBySeq(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, Me.SeqNum)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("EST_REV_SUP_BY_NTE")) = False Then
                        estlog = dt.Rows(0)("EST_REV_SUP_BY_NTE")
                    End If
                End If
                est.UpdateQuoteComments(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum, Me.SeqNum, SpecText, estlog, SpecText, estlog)
            End If
            'Session("EstImportSpecText") = SpecText
            Me.CloseAndRefresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbSpecs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSpecs.SelectedIndexChanged
        Try
            If Request.QueryString("control").Contains("CommentsEstimate") = True Or Request.QueryString("control").Contains("CommentsComponent") = True Or
               Request.QueryString("control").Contains("det_desc") = True Or Request.QueryString("control").Contains("det_instruct") = True Or
               Request.QueryString("control").Contains("DetailDescription") = True Or Request.QueryString("control").Contains("Instructions") = True Or Me.SpecVer = 0 Then
                Me.SpecVer = Session("ImportSpecsSpecVer")
                Me.SpecRev = Session("ImportSpecsSpecRev")
            End If
            Me.txtSpecs.Text = Me.CreateText(Me.JobNum, Me.JobCompNum, Me.SpecVer, Me.SpecRev)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Estimating_ImportSpecs_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Not Me.IsPostBack Then
                'Me.RadGridSpecs.Items(0).Selected = True
                Dim chk As CheckBox
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridSpecs.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If chk.Checked = True Then
                        Me.SpecVer = CInt(gridDataItem("colSPEC_VER").Text.Replace("&nbsp;", ""))
                        Me.SpecRev = CInt(gridDataItem("colSPEC_REV").Text.Replace("&nbsp;", ""))
                        Session("ImportSpecsSpecVer") = Me.SpecVer
                        Session("ImportSpecsSpecRev") = Me.SpecRev
                    End If
                Next
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
                    Me.lbSpecs.Enabled = False
                    Me.txtSpecs.ReadOnly = True
                    Me.SaveButton.Enabled = False
                ElseIf secEdit = "Y" And secInsert = "N" Then

                ElseIf secEdit = "N" And secInsert = "Y" Then

                End If
            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Me.CloseThisWindow()
    End Sub
End Class
