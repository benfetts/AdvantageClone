Imports System.Data.SqlClient
Imports System.Drawing

Partial Public Class purchaseorder_ap_summ
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
    Dim dTotal(20) As Decimal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Me.Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "CSS", MiscFN.SetPopupPageSkin(), False)

        If Not Page.IsPostBack Then
            If Not Request.QueryString("po_number") Is Nothing Then
                Purchaseorder_base_info1.PO_Number = AdvantageFramework.Security.Encryption.DecryptPO(Request.QueryString("po_number").Trim)
                Purchaseorder_base_info1.RetrievePOHeader()

                Dim ix As Integer
                For ix = 0 To 19 Step 1
                    dTotal(ix) = 0
                Next

                RetrievePODetails()
                Try
                    Me.TS_Display_Sources.SelectedIndex = 1
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub TS_Display_Sources_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles TS_Display_Sources.TabClick

        Dim ThisPO As String = ""
        ThisPO = AdvantageFramework.Security.Encryption.EncryptPO(Me.Purchaseorder_base_info1.PO_Number.ToString().Trim())
        Select Case Me.TS_Display_Sources.SelectedTab.Index
            Case 0
                Server.Transfer("purchaseorder_funct_summ.aspx?po_number=" & ThisPO)
            Case 2
                Server.Transfer("purchaseorder_estimates.aspx?po_number=" & ThisPO)
        End Select
    End Sub
    Sub RetrievePODetails()
        Dim dr As SqlDataReader
        Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))

        Me.lbl_title.Text = "Purchase Order A/P Invoice Query"

        dr = PODtl.Select_PODetail_AP_Complete_Dtl(1, Me.Purchaseorder_base_info1.PO_Number, "", "")
        Me.gv_polist.DataSource = dr
        Me.gv_polist.DataBind()
    End Sub

    Private Sub gv_polist_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_polist.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Select Case e.Row.DataItem("OVER_FLG").ToString
                Case "-"
                    e.Row.Cells(11).ForeColor = Color.Green
                Case "+"
                    e.Row.Cells(11).ForeColor = Color.Red
            End Select
        End If
        Dim str() As String
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
            If e.Row.Cells(7).Text <> "" And e.Row.Cells(7).Text <> "&nbsp;" Then
                e.Row.Cells(7).Text = CDate(e.Row.Cells(7).Text).ToShortDateString
            End If
            If ponumber.Value <> "0" Then
                POHeader.Select_POHeader(CInt(ponumber.Value), "")
                dsPOAppr = PO.GetPOApprovals(CInt(ponumber.Value))
                Dim polimit As Decimal = POHeader.Get_PO_Emp_Limit(1, POHeader.Issue_By_Emp_Code, usercode, username)
                If dsPOAppr.HasRows Then
                    If POHeader.PO_Approval_Flag = 0 Then

                    End If
                    If POHeader.PO_Approval_Flag = 1 Then
                        str = e.Row.Cells(1).Text.Split("-")
                        e.Row.Cells(1).Text = "(Pending)-" & str(1)
                    End If
                    If POHeader.PO_Approval_Flag = 2 Then

                    End If
                    If POHeader.PO_Approval_Flag = 3 Then
                        str = e.Row.Cells(1).Text.Split("-")
                        e.Row.Cells(1).Text = "(Denied)-" & str(1)
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
                                    str = e.Row.Cells(1).Text.Split("-")
                                    e.Row.Cells(1).Text = "(Incomplete)-" & str(1)
                                Else
                                    If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                                        str = e.Row.Cells(1).Text.Split("-")
                                        e.Row.Cells(1).Text = "(Incomplete)-" & str(1)
                                    ElseIf POHeader.Exceed = 1 Then
                                        str = e.Row.Cells(1).Text.Split("-")
                                        e.Row.Cells(1).Text = "(Incomplete)-" & str(1)
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If POHeader.PO_Appr_Rule_Code <> "" Then
                            If polimit = -1.0 Then
                                'printImage.Visible = True
                                str = e.Row.Cells(1).Text.Split("-")
                                e.Row.Cells(1).Text = "(Incomplete)-" & str(1)
                            Else
                                If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                                    str = e.Row.Cells(1).Text.Split("-")
                                    e.Row.Cells(1).Text = "(Incomplete)-" & str(1)
                                ElseIf POHeader.Exceed = 1 Then
                                    str = e.Row.Cells(1).Text.Split("-")
                                    e.Row.Cells(1).Text = "(Incomplete)-" & str(1)
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        End If
    End Sub
    Public Function GetColumnAmount(ByVal Column_Id As Integer, ByVal Amount As String) As String
        Try
            Me.dTotal(Column_Id) = Me.dTotal(Column_Id) + Decimal.Parse(Amount)
        Catch ex As Exception
        End Try

        Return Amount
    End Function
    Function GetColumnTotal(ByVal Column_Id As Integer) As String
        Return Me.dTotal(Column_Id).ToString
    End Function
    Public Function GetNonBillableFlagIcon(ByVal val As Int16) As String
        If val = 1 Then
            Return "images/currency_dollar_grayed.png"
        Else
            Return "images/currency_dollar.png"
        End If
    End Function

    Protected Sub lbtn_trans_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtn_trans_view.Click

        Server.Transfer("purchaseorder_trans_summ.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(Me.Purchaseorder_base_info1.PO_Number.ToString.Trim()))
    End Sub
End Class
