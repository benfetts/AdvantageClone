Partial Public Class purchaseorder_memo_disp
    Inherits Webvantage.BaseChildPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.GridView1.Columns.Clear()
        'Me.TS_Comment_Sources.Skin = MiscFN.SetRadTabStripSkin()

        If Not Page.IsPostBack Then
            Me.PageTitle = "Purchase Order Job Estimate Comments"

            Me.txtType.Value = ""
            Me.txtRefID.Value = ""
            Me.txtRefID2.Value = ""

            Me.lbSpecs.SelectedValue = "supply_by_notes"
            If Not Request.QueryString("memo_type") Is Nothing Then
                Me.txtType.Value = Request.QueryString("memo_type").Trim
            End If

            If Not Request.QueryString("ref_id") Is Nothing Then
                Me.txtRefID.Value = Request.QueryString("ref_id").Trim
            End If

            If Not Request.QueryString("str") Is Nothing Then
                Me.txtRefID2.Value = Request.QueryString("str").Trim
            End If

            If Not Request.QueryString("fn_code") Is Nothing Then
                Me.fn_code.Value = Request.QueryString("fn_code").Trim
            End If

            If Not Request.QueryString("SeqNbr") Is Nothing Then
                Me.seq_nbr.Value = Request.QueryString("SeqNbr").Trim
            End If
            If Me.seq_nbr.Value = "" Then
                Me.seq_nbr.Value = -1
            End If

            'CreateTabs(Me.txtType.Value.Trim, 0)

            'If Not Request.QueryString("preselect_tab_id") Is Nothing Then
            '    If IsNumeric(Request.QueryString("preselect_tab_id")) = True Then
            '        PreSelectTab(Int32.Parse(Request.QueryString("preselect_tab_id").Trim))
            '    End If
            'End If

            'If Me.TS_Comment_Sources.Tabs.Count > 0 Then
            GetMemo("all", Int32.Parse(Me.txtRefID.Value.Trim), Me.txtRefID2.Value.Trim, Me.fn_code.Value.Trim, Me.seq_nbr.Value)
            'End If

            'Me.TS_Comment_Sources.Skin = Webvantage.MiscFN.SetRadPanelbarSkin

        End If
    End Sub

    'Sub CreateTabs(ByVal tab_function As String, ByVal Selected_Tab As Int16)
    '    Select Case tab_function.Trim
    '        Case "main_del_instruct"
    '            CreateTabGroup1(Selected_Tab)
    '        Case "detail_instruct"
    '            CreateTabGroup1(Selected_Tab)
    '            CreateTabGroup2(Selected_Tab)
    '    End Select

    'End Sub
    'Sub CreateTabGroup1(ByVal Selected_Tab As Int16)
    '    Dim t1, t2, t3, t4 As New Telerik.Web.UI.RadTab

    '    t1.Text = "Estimate Log"
    '    t1.Value = "est_log_comment"

    '    t2.Text = "Estimate Component"
    '    t2.Value = "est_comp_comment"

    '    t3.Text = "Estimate Quote"
    '    t3.Value = "est_qte_comment"

    '    t4.Text = "Estimate Revision"
    '    t4.Value = "est_rev_comment"

    '    Me.TS_Comment_Sources.Tabs.Add(t1)
    '    Me.TS_Comment_Sources.Tabs.Add(t2)
    '    Me.TS_Comment_Sources.Tabs.Add(t3)
    '    Me.TS_Comment_Sources.Tabs.Add(t4)

    '    If Me.TS_Comment_Sources.Tabs.Count > 0 And (Selected_Tab <= TS_Comment_Sources.Tabs.Count) Then
    '        Me.TS_Comment_Sources.Tabs(Selected_Tab).Selected = True
    '    End If
    'End Sub
    'Sub CreateTabGroup2(ByVal Selected_Tab As Int16)
    '    Dim t1, t2 As New Telerik.Web.UI.RadTab

    '    t1.Text = "Function Comment"
    '    t1.Value = "est_funct_comment"

    '    t2.Text = "Supplied By Notes"
    '    t2.Value = "supply_by_notes"

    '    Me.TS_Comment_Sources.Tabs.Add(t1)
    '    Me.TS_Comment_Sources.Tabs.Add(t2)

    '    If Me.TS_Comment_Sources.Tabs.Count > 0 And (Selected_Tab <= TS_Comment_Sources.Tabs.Count) Then
    '        Me.TS_Comment_Sources.Tabs(Selected_Tab).Selected = True
    '    End If

    'End Sub
    Sub GetMemo(ByVal Funct As String, ByVal RefId As Integer, ByVal str As String, ByVal fn_code As String, ByVal seq_nbr As Integer)
        Try
            Dim ds As DataSet
            Dim i As Integer
            Dim j As Integer
            Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Dim sbSpecs As New System.Text.StringBuilder
            ds = POHeader.Select_PO_Estimate_MemosDS(Funct.Trim, RefId, "PO", str.Trim, fn_code.Trim, seq_nbr)
            For i = 0 To Me.lbSpecs.Items.Count - 1
                If lbSpecs.Items(i).Selected = True Then
                    For j = 0 To ds.Tables(0).Rows.Count - 1
                        If lbSpecs.Items(i).Value = ds.Tables(0).Rows(j)("type") Then

                            If Not IsDBNull(ds.Tables(0).Rows(j)("Comment")) Then

                                sbSpecs.AppendLine(ds.Tables(0).Rows(j)("Comment"))
                                sbSpecs.AppendLine("")

                            End If

                        End If
                    Next
                End If
            Next
            Me.RadTextBoxSpecs.Text = sbSpecs.ToString
            'Me.GridView1.DataSource = dr
            'Me.GridView1.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub TS_Comment_Sources_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles TS_Comment_Sources.TabClick
    '    Me.GetMemo(TS_Comment_Sources.SelectedTab.Value.Trim, Int32.Parse(Me.txtRefID.Value.Trim), Me.txtRefID2.Value.Trim, Me.fn_code.Value.Trim)
    '    CreateTabs(e.Tab.Value, e.Tab.Index)
    'End Sub
    'Sub PreSelectTab(ByVal tab_id As Integer)
    '    Try
    '        Me.TS_Comment_Sources.SelectedIndex = tab_id
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub lbSpecs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSpecs.SelectedIndexChanged
        GetMemo("all", Int32.Parse(Me.txtRefID.Value.Trim), Me.txtRefID2.Value.Trim, Me.fn_code.Value.Trim, Me.seq_nbr.Value)
    End Sub

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim strScript As String
            Dim cScript As String
            Dim SpecText As String
            Session("POEstimateComments") = Me.RadTextBoxSpecs.Text
            Me.CloseAndRefresh()
            'Me.CloseThisWindowAndRefreshCaller("purchaseorder_dtl.aspx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CloseAndRefresh()
        Dim FunctionName As String
        If Request.QueryString("control").Contains("det_desc") = True OrElse Request.QueryString("control").Contains("DetailDescription") = True Then
            FunctionName = "SpecsDescEst"
        End If
        If Request.QueryString("control").Contains("det_instruct") = True OrElse Request.QueryString("control").Contains("Instructions") = True Then
            FunctionName = "SpecsInstructEst"
        End If
        Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
    End Sub

    Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Try
            Me.CloseThisWindow()
        Catch ex As Exception

        End Try
    End Sub
End Class
