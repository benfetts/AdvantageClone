Imports System.Data.SqlClient
Imports System.Drawing

Partial Public Class purchaseorder_funct_summ
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Me.Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CSS", MiscFN.SetPopupPageSkin(), False)
        If Not Page.IsPostBack Then
            If Not Request.QueryString("po_number") Is Nothing Then

                Purchaseorder_base_info1.PO_Number = AdvantageFramework.Security.Encryption.DecryptPO(Request.QueryString("po_number").Trim())
                Purchaseorder_base_info1.RetrievePOHeader()
            End If
            RetrievePOList()

            Try
                Me.RadTabStripPOFunctionSummary.SelectedIndex = 0
            Catch ex As Exception
            End Try
        End If

    End Sub

    Sub RetrievePOList()
        Dim dr, dr2 As SqlDataReader
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

        dr = POHeader.LoadAll_PO_Funct_Totals(Int32.Parse(rbl_options.SelectedValue), Int32.Parse(Purchaseorder_base_info1.PO_Number.ToString()), 1, "", "")

        gv_polist.DataSource = dr
        gv_polist.DataBind()

        'retrieve Job Totals...
        dr2 = POHeader.LoadAll_PO_Funct_Totals(99, Int32.Parse(Purchaseorder_base_info1.PO_Number.ToString()), 1, "", "")

        gv_JobTotals.DataSource = dr2
        gv_JobTotals.DataBind()


        POHeader = Nothing

    End Sub
    Protected Sub rbl_options_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbl_options.SelectedIndexChanged
        RetrievePOList()
    End Sub
    Private Sub gv_polist_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_polist.RowDataBound
        If DataBinder.Eval(e.Row.DataItem, "CURRENT_PO_FLG") = 1 Then
            e.Row.BackColor = Color.AliceBlue
            e.Row.ForeColor = Color.DarkBlue
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ponumber As Web.UI.WebControls.HiddenField = e.Row.FindControl("hfPONumber")
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
            Dim oEmp As New cEmployee(Session("ConnString"))
            Dim dsPO As SqlDataReader
            Dim dsPOAppr As SqlDataReader
            Dim usercode As String = ""
            Dim username As String = ""
            If ponumber.Value <> "0" Then
                POHeader.Select_POHeader(CInt(ponumber.Value), "")
                dsPOAppr = PO.GetPOApprovals(CInt(ponumber.Value))
                Dim polimit As Decimal = POHeader.Get_PO_Emp_Limit(1, POHeader.Issue_By_Emp_Code, usercode, username)
                If dsPOAppr.HasRows Then
                    If POHeader.PO_Approval_Flag = 0 Then

                    End If
                    If POHeader.PO_Approval_Flag = 1 Then
                        e.Row.Cells(4).Text = "(Pending)"
                    End If
                    If POHeader.PO_Approval_Flag = 2 Then

                    End If
                    If POHeader.PO_Approval_Flag = 3 Then
                        e.Row.Cells(4).Text = "(Denied)"
                    End If
                Else
                    dsPO = PODtl.LoadAll_PO_Detail_List(1, CInt(ponumber.Value), "", "")
                    If PO.GetPOReqdExtAmount_Flg() Then
                        If dsPO.HasRows = False Or POHeader.PO_Total.ToString() = "" Or POHeader.PO_Total.ToString() = "0.00" Then
                            'printImage.Visible = False
                        Else
                            If POHeader.PO_Appr_Rule_Code <> "" Then
                                If polimit = -1.0 Then
                                    'printImage.Visible = True
                                    e.Row.Cells(4).Text = "(Incomplete)"
                                Else
                                    If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                                        e.Row.Cells(4).Text = "(Incomplete)"
                                        'Me.Purchaseordernav1.Allow_Print = False
                                    ElseIf POHeader.Exceed = 1 Then
                                        e.Row.Cells(4).Text = "(Incomplete)"
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If POHeader.PO_Appr_Rule_Code <> "" Then
                            If polimit = -1.0 Then
                                'printImage.Visible = True
                                e.Row.Cells(4).Text = "(Incomplete)"
                            Else
                                If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                                    e.Row.Cells(4).Text = "(Incomplete)"
                                    'Me.Purchaseordernav1.Allow_Print = False
                                ElseIf POHeader.Exceed = 1 Then
                                    e.Row.Cells(4).Text = "(Incomplete)"
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            e.Row.Cells(5).Text = LoGlo.FormatDate(e.Row.Cells(5).Text)

        End If

    End Sub

    Private Sub gv_JobTotals_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_JobTotals.RowDataBound
        If DataBinder.Eval(e.Row.DataItem, "SEQ") = 2 Then  'seq 2 is total line (could be multiples for multi-job)..
            e.Row.BackColor = Color.LightGreen
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ponumber As Web.UI.WebControls.HiddenField = e.Row.FindControl("hfPONumber")
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
            Dim oEmp As New cEmployee(Session("ConnString"))
            Dim dsPO As SqlDataReader
            Dim dsPOAppr As SqlDataReader
            Dim usercode As String = ""
            Dim username As String = ""
            If ponumber.Value <> "0" Then
                POHeader.Select_POHeader(CInt(ponumber.Value), "")
                dsPOAppr = PO.GetPOApprovals(CInt(ponumber.Value))
                Dim polimit As Decimal = POHeader.Get_PO_Emp_Limit(1, POHeader.Issue_By_Emp_Code, usercode, username)
                If dsPOAppr.HasRows Then
                    If POHeader.PO_Approval_Flag = 0 Then

                    End If
                    If POHeader.PO_Approval_Flag = 1 Then
                        e.Row.Cells(3).Text = "(Pending)"
                    End If
                    If POHeader.PO_Approval_Flag = 2 Then

                    End If
                    If POHeader.PO_Approval_Flag = 3 Then
                        e.Row.Cells(3).Text = "(Denied)"
                    End If
                Else
                    dsPO = PODtl.LoadAll_PO_Detail_List(1, CInt(ponumber.Value), "", "")
                    If PO.GetPOReqdExtAmount_Flg() Then
                        If dsPO.HasRows = False Or POHeader.PO_Total.ToString() = "" Or POHeader.PO_Total.ToString() = "0.00" Then
                            'printImage.Visible = False
                        Else
                            If POHeader.PO_Appr_Rule_Code <> "" Then
                                If polimit = -1.0 Then
                                    'printImage.Visible = True
                                Else
                                    If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                                        e.Row.Cells(3).Text = "(Incomplete)"
                                        'Me.Purchaseordernav1.Allow_Print = False
                                    ElseIf POHeader.Exceed = 1 Then
                                        e.Row.Cells(3).Text = "(Incomplete)"
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If POHeader.PO_Appr_Rule_Code <> "" Then
                            If polimit = -1.0 Then
                                'printImage.Visible = True
                            Else
                                If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                                    e.Row.Cells(3).Text = "(Incomplete)"
                                    'Me.Purchaseordernav1.Allow_Print = False
                                ElseIf POHeader.Exceed = 1 Then
                                    e.Row.Cells(3).Text = "(Incomplete)"
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub RadTabStripPOFunctionSummary_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripPOFunctionSummary.TabClick

        Dim p As String = AdvantageFramework.Security.Encryption.EncryptPO(Me.Purchaseorder_base_info1.PO_Number.ToString())
        Select Case Me.RadTabStripPOFunctionSummary.SelectedTab.Index
            Case 1
                Server.Transfer("purchaseorder_ap_summ.aspx?po_number=" & p)
            Case 2
                Server.Transfer("purchaseorder_estimates.aspx?po_number=" & p)
        End Select
    End Sub
End Class
