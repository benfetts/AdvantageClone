Imports System.Data.SqlClient
Imports System.Drawing

Partial Public Class purchaseorder_job_comp_list
    Inherits System.Web.UI.UserControl
    Public Event Close_Button_Clicked()
    Public Event EstimateItemSelected()
    Public Event ShowAll_Clicked()
    Public Property Job_Number() As Integer
        Get
            Return Int32.Parse(lbl_job_number.Text.Trim)
        End Get
        Set(ByVal value As Integer)
            lbl_job_number.Text = value.ToString
        End Set
    End Property
    Public Property Job_Component_Nbr() As Integer
        Get
            Return Int32.Parse(lbl_component_nbr.Text.Trim)
        End Get
        Set(ByVal value As Integer)
            lbl_component_nbr.Text = value.ToString
        End Set
    End Property
    Public Property Fnc_Code() As String
        Get
            Return lbl_fn_code.Text.Trim
        End Get
        Set(ByVal value As String)
            lbl_fn_code.Text = value.Trim
        End Set
    End Property
    Public WriteOnly Property Show_Close_Button() As Boolean
        Set(ByVal value As Boolean)
            Me.btn_Close.Visible = value
        End Set
    End Property
    Public WriteOnly Property Close_Button_Caption() As String
        Set(ByVal value As String)
            Me.btn_Close.Text = value.Trim
        End Set
    End Property
    Public WriteOnly Property Show_ShowAll_Button() As Boolean
        Set(ByVal value As Boolean)
            lbtn_show_all.Visible = value
        End Set
    End Property
    Public WriteOnly Property ShowAll_Button_Caption() As String
        Set(ByVal value As String)
            lbtn_show_all.Text = value.Trim
        End Set
    End Property
    Public ReadOnly Property Selected_Fnc_Code() As String
        Get
            Dim data As DataKey = gvEstimateItems.DataKeys(gvEstimateItems.SelectedRow.RowIndex)
            Return data.Values("FNC_CODE").ToString
        End Get
    End Property
    Public ReadOnly Property Selected_Fnc_Description() As String
        Get
            Dim data As DataKey = gvEstimateItems.DataKeys(gvEstimateItems.SelectedRow.RowIndex)
            Return data.Values("FNC_DESCRIPTION").ToString
        End Get
    End Property
    Public ReadOnly Property Selected_Qty() As Integer
        Get
            Dim data As DataKey = gvEstimateItems.DataKeys(gvEstimateItems.SelectedRow.RowIndex)
            Return data.Values("EST_REV_QUANTITY")
        End Get
    End Property
    Public ReadOnly Property Selected_Rate() As Decimal
        Get
            Dim data As DataKey = gvEstimateItems.DataKeys(gvEstimateItems.SelectedRow.RowIndex)
            Return data.Values("EST_REV_RATE")
        End Get
    End Property
    Public ReadOnly Property Selected_Ext_Amt() As Decimal
        Get
            Dim data As DataKey = gvEstimateItems.DataKeys(gvEstimateItems.SelectedRow.RowIndex)
            Return data.Values("EST_REV_EXT_AMT")
        End Get
    End Property
    Public ReadOnly Property Selected_Markup_Pct() As Decimal
        Get
            Dim data As DataKey = gvEstimateItems.DataKeys(gvEstimateItems.SelectedRow.RowIndex)
            Return data.Values("EST_REV_COMM_PCT")
        End Get
    End Property
    Public ReadOnly Property Selected_Markup_Amount() As Decimal
        Get
            Dim data As DataKey = gvEstimateItems.DataKeys(gvEstimateItems.SelectedRow.RowIndex)
            Return data.Values("EXT_MARKUP_AMT")
        End Get
    End Property
    Public ReadOnly Property Selected_Line_Total() As Decimal
        Get
            Dim data As DataKey = gvEstimateItems.DataKeys(gvEstimateItems.SelectedRow.RowIndex)
            Return data.Values("LINE_TOTAL")
        End Get
    End Property
    Public ReadOnly Property Use_CPM() As Boolean
        Get
            Dim data As DataKey = gvEstimateItems.DataKeys(gvEstimateItems.SelectedRow.RowIndex)
            If data.Values("USE_CPM") = 1 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public ReadOnly Property RowCount_Items() As Integer
        Get
            'Return Me.gvEstimateItems.Rows.Count
            Return Me.radGridEstimate.Items.Count
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub RetrieveEstimateLines()
        'retrieve approved estimate items for matching job/component/(optional funct code).
        Dim dr As SqlDataReader

        If lbl_job_number.Text.Trim = "-1" Then Exit Sub

        Dim PODetail As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))

        dr = PODetail.LoadAll_PO_Apprv_Estm_Lines_ByJobComp(Int32.Parse(ddFunct.SelectedValue.Trim), Int32.Parse(lbl_job_number.Text.Trim), Int32.Parse(lbl_component_nbr.Text.Trim), lbl_fn_code.Text.Trim)

        'gvEstimateItems.DataSource = dr
        'gvEstimateItems.DataBind()
        If dr.HasRows = True Then
            Me.radGridEstimate.DataSource = dr
            Me.radGridEstimate.DataBind()
        End If
    End Sub
    Public Sub RetrieveEstimateLinesNoFunctFilter()
        'retrieve approved estimate items for matching job/component/(optional funct code), ignoring funct code even if supplied.
        'Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader
        If lbl_job_number.Text.Trim = "-1" Then Exit Sub

        Dim PODetail As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))

        'dr = PODetail.LoadAll_PO_Apprv_Estm_Lines_ByJobComp(Int32.Parse(ddFunct.SelectedValue.Trim), Int32.Parse(lbl_job_number.Text.Trim), Int32.Parse(lbl_component_nbr.Text.Trim), "")
        dr2 = PODetail.LoadAll_PO_Apprv_Estm_Lines_ByJobComp(Int32.Parse(ddFunct.SelectedValue.Trim), Int32.Parse(lbl_job_number.Text.Trim), Int32.Parse(lbl_component_nbr.Text.Trim), "")

        'gvEstimateItems.DataSource = dr
        'gvEstimateItems.DataBind()
        If dr2.HasRows = True Then
            Me.radGridEstimate.DataSource = dr2
            Me.radGridEstimate.DataBind()
        End If
        dr2.Close()
    End Sub

    Private Sub gvEstimateItems_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEstimateItems.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If DataBinder.Eval(e.Row.DataItem, "FNC_CODE") = lbl_fn_code.Text.Trim Then
                e.Row.BackColor = Color.LightGreen
            Else
                e.Row.CssClass = Nothing
            End If
        End If
    End Sub
    Protected Sub gvEstimateItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvEstimateItems.SelectedIndexChanged
        RaiseEvent EstimateItemSelected()
    End Sub
    Protected Sub lbtn_show_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtn_show_all.Click
        RaiseEvent ShowAll_Clicked()
    End Sub

    Protected Sub btn_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Close.Click
        RaiseEvent Close_Button_Clicked()
    End Sub

    Private Sub radGridEstimate_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radGridEstimate.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.CommandName
            Case "Select"
                Session("PODetailFunctionCode") = e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("FNC_CODE")
                Session("PODetailFunctionDesc") = e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("FNC_DESCRIPTION")
                Session("PODetailQty") = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("EST_REV_QUANTITY"))
                Session("PODetailRate") = e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("EST_REV_RATE")
                Session("PODetailExtAmount") = e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("EST_REV_EXT_AMT")
                Session("PODetailMarkupPerc") = e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("EST_REV_COMM_PCT")
                Session("PODetailMarkupAmt") = e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("EXT_MARKUP_AMT")
                Session("PODetailUserCPM") = e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("USER_CPM")
                Session("PODetailSeqNbr") = e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("SEQ_NBR")
                RaiseEvent EstimateItemSelected()
        End Select
    End Sub

    Private Sub radGridEstimate_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles radGridEstimate.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                Dim lab As System.Web.UI.WebControls.Label
                lab = e.Item.FindControl("lblQty")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If
                lab = e.Item.FindControl("lblExtAmt")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If
                lab = e.Item.FindControl("lblRate")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If
                lab = e.Item.FindControl("lblMarkupAmt")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If
                lab = e.Item.FindControl("lblTotal")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If
                lab = e.Item.FindControl("lblPOUsedNET")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If
                lab = e.Item.FindControl("lblBalanceNET")
                If lab.Text <> "" Then
                    lab.Text = String.Format("{0:#,##0.00}", CDec(lab.Text))
                End If
        End Select
    End Sub

    'Private Sub radGridEstimate_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles radGridEstimate.NeedDataSource
    '    Dim dr As SqlDataReader
    '    If lbl_job_number.Text.Trim = "-1" Then Exit Sub
    '    Dim PODetail As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
    '    dr = PODetail.LoadAll_PO_Apprv_Estm_Lines_ByJobComp(Int32.Parse(ddFunct.SelectedValue.Trim), Int32.Parse(lbl_job_number.Text.Trim), Int32.Parse(lbl_component_nbr.Text.Trim), "")
    '    Me.radGridEstimate.DataSource = dr
    'End Sub

    Private Sub radGridEstimate_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles radGridEstimate.PageIndexChanged

    End Sub
End Class