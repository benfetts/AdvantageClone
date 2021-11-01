Imports System.Data.SqlClient
Partial Public Class purchaseorderlist_emp
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
        Me.PageTitle = "Purchase Order List"
        If Not Page.IsPostBack Then
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)
            SelectTab()
            RetrieveRecentVendors()
            RetrievePOList(Me.dlVendors.SelectedValue.ToString())
        End If
    End Sub
    Sub RetrieveRecentVendors()
        Dim dr As SqlDataReader
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

        dr = POHeader.LoadAll_PO_Emp_Recent_Vendors(Int32.Parse(dl_Days.SelectedValue.Trim), Session("Empcode"), "", "", "")
        'dl_vendors.DataSource = dr
        'dl_vendors.DataBind()

        Me.dlVendors.DataSource = dr
        Me.dlVendors.DataTextField = "VN_NAME"
        Me.dlVendors.DataValueField = "VN_CODE"
        Me.dlVendors.DataBind()

        POHeader = Nothing

    End Sub
    Private Sub SelectTab(Optional ByVal strTheme As String = "ThreePointOhOatmeal.Master")
        Try
            Try
                If IsNumeric(Request.QueryString("Tab")) = True Then
                    If CInt(Request.QueryString("Tab")) = 1 Then
                        Me.RadTabStripAR.Tabs(0).Selected = True
                    ElseIf CInt(Request.QueryString("Tab")) = 2 Then
                        Me.RadTabStripAR.Tabs(1).Selected = True
                    End If
                Else
                    Me.RadTabStripAR.Tabs(0).Selected = True
                End If
            Catch ex As Exception
                Me.ShowMessage("tab error")
            End Try
        Catch ex As Exception
            Me.ShowMessage("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub
    Sub RetrievePOList(ByVal Vendor_Code As String)
        Dim ds As DataSet
        Dim voided As Integer
        Dim closed As Integer
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        If Me.cbOmitVoid.Checked = True Then
            voided = 1
        Else
            voided = 0
        End If
        If Me.cbOmitClosed.Checked = True Then
            closed = 1
        Else
            closed = 0
        End If
        ds = POHeader.LoadAll_PO_ByEmp(1, Int32.Parse(dl_Days.SelectedValue.Trim), Session("Empcode"), Vendor_Code.Trim, "", "", voided, closed)

        'gvw_po.DataSource = dr
        'gvw_po.DataBind()

        If ds.Tables(0).Rows.Count > 0 Then
            Me.RadGridPurchaseOrderEmployeeList.DataSource = ds
            Me.RadGridPurchaseOrderEmployeeList.DataBind()
            Me.RadGridPurchaseOrderEmployeeList.CurrentPageIndex = Me.CurrentGridPageIndex
            Me.RadGridPurchaseOrderEmployeeList.PageSize = MiscFN.LoadPageSize(Me.RadGridPurchaseOrderEmployeeList.ID)
        End If

        POHeader = Nothing
    End Sub

    Protected Sub dl_Days_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dl_Days.SelectedIndexChanged
        RetrieveRecentVendors()
        lbl_vn_code.Text = dlVendors.SelectedValue
        RetrievePOList(lbl_vn_code.Text.Trim)
    End Sub
    'Private Sub dl_vendors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dl_vendors.SelectedIndexChanged
    '    If Not String.IsNullOrEmpty(dl_vendors.SelectedValue) Then
    '        lbl_vn_code.Text = dl_vendors.SelectedValue
    '        RetrievePOList(lbl_vn_code.Text.Trim)
    '    End If
    'End Sub

    'Private Sub gvw_po_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvw_po.SelectedIndexChanged
    '    Dim data As DataKey = gvw_po.DataKeys(gvw_po.SelectedRow.RowIndex)
    '    Dim sb As New System.Text.StringBuilder

    '    sb.Append("purchaseorder.aspx?po_number=")
    '    sb.Append(data.Values("PO_NUMBER"))
    '    sb.Append("&pagemode=edit&caller=purchaseorderlist._emp")
    '    Server.Transfer(sb.ToString())
    '    sb = Nothing
    'End Sub

    Private Sub RadGridPurchaseOrderEmployeeList_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridPurchaseOrderEmployeeList.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = 0
        If Not e.Item Is Nothing Then
            index = e.Item.ItemIndex
        Else
            Exit Sub
        End If
        Select Case e.CommandName
            Case "Select"
                Dim lab As System.Web.UI.WebControls.HiddenField
                lab = e.Item.FindControl("hfPONumber")
                Dim sb As New System.Text.StringBuilder
                sb.Append("purchaseorder.aspx?po_number=")
                sb.Append(AdvantageFramework.Security.Encryption.EncryptPO(lab.Value))
                sb.Append("&pagemode=edit&caller=purchaseorderlist._emp")
                Me.OpenWindow("", sb.ToString())
                sb = Nothing
        End Select
    End Sub

    Private Sub dlVendors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dlVendors.SelectedIndexChanged
        If Not String.IsNullOrEmpty(dlVendors.SelectedValue) Then
            lbl_vn_code.Text = dlVendors.SelectedValue
            RetrievePOList(lbl_vn_code.Text.Trim)
        End If
    End Sub

    Private Sub RadGridPurchaseOrderEmployeeList_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridPurchaseOrderEmployeeList.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim FlagDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
            If e.Item.DataItem("VOID_FLAG") = 1 Then
                'FlagImage.Visible = True
            Else
                'FlagImage.Visible = False
                AdvantageFramework.Web.Presentation.Controls.DivHide(FlagDiv)
            End If

            Dim label As System.Web.UI.WebControls.Label = e.Item.FindControl("lblPOStatus")
            If label.Text = "0" Then
                label.Text = ""
            End If
            If label.Text = "1" Then
                label.Text = "Pending"
            End If
            If label.Text = "2" Then
                label.Text = "Approved"
            End If
            If label.Text = "3" Then
                label.Text = "Denied"
            End If
            label = e.Item.FindControl("lblPODueDate")
            If label.Text <> "" And label.Text.Trim <> "(?)" Then
                label.Text = LoGlo.FormatDate(label.Text)
            End If

            'Dim printImage As Web.UI.WebControls.ImageButton = e.Item.FindControl("ImgBtnPrint")
            Dim ponumber As Web.UI.WebControls.HiddenField = e.Item.FindControl("hfPONumber")
            Dim labelPONum As Web.UI.WebControls.Label = e.Item.FindControl("lblPONumber")
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
            Dim oEmp As New cEmployee(Session("ConnString"))
            Dim usercode As String = ""
            Dim username As String = ""
            Dim HasApprovals As Boolean = False
            POHeader.Select_POHeader(CInt(ponumber.Value), "")

            Using PoApprovalSqlDataReader = PO.GetPOApprovals(CInt(ponumber.Value))

                HasApprovals = PoApprovalSqlDataReader.HasRows

            End Using

            Dim polimit As Decimal = POHeader.Get_PO_Emp_Limit(1, POHeader.Issue_By_Emp_Code, usercode, username)
            If HasApprovals Then
                If POHeader.PO_Approval_Flag = 0 Then
                    'printImage.Visible = True
                End If
                If POHeader.PO_Approval_Flag = 1 Then
                    'printImage.Visible = False
                    labelPONum.Text = "(Pending)"
                End If
                If POHeader.PO_Approval_Flag = 2 Then
                    'printImage.Visible = True
                End If
                If POHeader.PO_Approval_Flag = 3 Then
                    'printImage.Visible = False
                    labelPONum.Text = "(Denied)"
                End If
            Else

                Using SqlDataReader = PODtl.LoadAll_PO_Detail_List(1, CInt(ponumber.Value), "", "")

                    If PO.GetPOReqdExtAmount_Flg() Then
                        If SqlDataReader.HasRows = False Or POHeader.PO_Total.ToString() = "" Or POHeader.PO_Total.ToString() = "0.00" Then
                            'printImage.Visible = False
                        Else
                            If POHeader.PO_Appr_Rule_Code <> "" Then
                                If polimit = -1.0 Then
                                    'printImage.Visible = True
                                    labelPONum.Text = "(Incomplete)"
                                Else
                                    If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                                        labelPONum.Text = "(Incomplete)"
                                        'Me.Purchaseordernav1.Allow_Print = False
                                    ElseIf POHeader.Exceed = 1 Then
                                        labelPONum.Text = "(Incomplete)"
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If POHeader.PO_Appr_Rule_Code <> "" Then
                            If polimit = -1.0 Then
                                'printImage.Visible = True
                                labelPONum.Text = "(Incomplete)"
                            Else
                                If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                                    labelPONum.Text = "(Incomplete)"
                                    'Me.Purchaseordernav1.Allow_Print = False
                                ElseIf POHeader.Exceed = 1 Then
                                    labelPONum.Text = "(Incomplete)"
                                End If
                            End If
                        End If
                    End If

                End Using

            End If
        End If
    End Sub

    Private Function checkApprovalCode(ByVal empcode As String)
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dept As String
        Dim deptApproval As String = ""
        Dim empApproval As String = ""

        dept = oEmp.GetDept(empcode)
        empApproval = PO.GetPOApprRuleCodebyEmp(empcode)
        If dept <> "" Then
            deptApproval = PO.GetPOApprRuleCodebyDept(dept)
        End If
        If empApproval = "" And deptApproval = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Property CurrentGridPageIndex As Integer = 0
    Private Sub RadGridPurchaseOrderEmployeeList_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridPurchaseOrderEmployeeList.PageIndexChanged
        Me.CurrentGridPageIndex = e.NewPageIndex
        RetrievePOList(Me.dlVendors.SelectedValue.ToString())
    End Sub

    Private Sub cbOmitVoid_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbOmitVoid.CheckedChanged
        Try
            lbl_vn_code.Text = dlVendors.SelectedValue
            RetrievePOList(lbl_vn_code.Text.Trim)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbOmitClosed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbOmitClosed.CheckedChanged
        Try
            lbl_vn_code.Text = dlVendors.SelectedValue
            RetrievePOList(lbl_vn_code.Text.Trim)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridPurchaseOrderEmployeeList_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridPurchaseOrderEmployeeList.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridPurchaseOrderEmployeeList.ID, e.NewPageSize)
    End Sub
End Class
