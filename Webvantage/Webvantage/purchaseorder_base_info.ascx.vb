Public Partial Class purchaseorder_base_info
    Inherits System.Web.UI.UserControl
    Public Property PO_Number() As Integer
        Get
            Return Int32.Parse(txt_ponumber.Text.Trim)
        End Get
        Set(ByVal value As Integer)
            txt_ponumber.Text = value.ToString
        End Set
    End Property
    Public ReadOnly Property Emp_Code() As String
        Get
            Return lbl_emp_code.Text.Trim
        End Get
    End Property
    Public ReadOnly Property Emp_Name() As String
        Get
            Return lbl_emp_name.Text.Trim
        End Get
    End Property
    Public ReadOnly Property Issue_To_Vendor_Name() As String
        Get
            Return Me.lbl_vendor.Text.Trim
        End Get
    End Property
    Public ReadOnly Property Issue_To_Vendor_Code() As String
        Get
            Return Me.lbl_vn_code.Text.Trim
        End Get
    End Property
    Public ReadOnly Property Void_Info() As String
        Get
            Return Me.lbl_Void_Info.Text.Trim
        End Get
    End Property
    Public ReadOnly Property PO_Complete() As Boolean
        Get
            If img_lock.Visible = True Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
    Public Property lblTotal() As System.Web.UI.WebControls.Label
        Get
            Return Me.lbl_total
        End Get
        Set(ByVal value As System.Web.UI.WebControls.Label)
            Me.lbl_total.Text = value.Text
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Public Sub RetrievePOHeader()
        'retrieve base header information for purchase order.
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        POHeader.Select_POHeader(Int32.Parse(txt_ponumber.Text), "")
        txt_PO_Pad.Text = POHeader.PO_Pad.Trim
        lbl_descrip.Text = POHeader.PO_Description.Trim
        lbl_po_dt.Text = LoGlo.FormatDate(POHeader.PO_Date)
        lbl_emp_name.Text = POHeader.Issue_By_Emp_Name.Trim
        lbl_emp_code.Text = POHeader.Issue_By_Emp_Code.Trim
        lbl_due_dt.Text = LoGlo.FormatDate(POHeader.PO_Due_Date)
        lbl_vendor.Text = POHeader.Vendor_Name.Trim
        lbl_total.Text = String.Format("{0:#,##0.00}", CDbl(POHeader.PO_Total))
        If POHeader.PO_Complete = True Or (POHeader.PO_Voided = True And POHeader.PO_Approval_Flag <> 3) Then
            img_lock.Visible = False
        Else
            img_lock.Visible = False
        End If
        If (POHeader.PO_Voided = True And POHeader.PO_Approval_Flag = 3) Then
            lbl_Void_Info.Text = ""
        Else
            lbl_Void_Info.Text = POHeader.Void_Info.Trim
        End If
        lbl_vn_code.Text = POHeader.Vendor_Code.Trim
        CheckFlags_POApproval()
    End Sub
    Public Sub RecalculateTotal(Optional ByVal Add_Amt As Decimal = 0.0)
        Dim PODetail As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
        lbl_total.Text = String.Format("{0:#,##0.00}", PODetail.GetPOTotal(Int32.Parse(txt_ponumber.Text.Trim)))
    End Sub
    Private Sub CheckFlags_POApproval()
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dsPO As SqlClient.SqlDataReader
        Dim dsPOAppr As SqlClient.SqlDataReader
        Dim dept As String
        Dim deptApproval As String = ""
        Dim empApproval As String = ""
        Dim usercode As String = ""
        Dim username As String = ""
        POHeader.Select_POHeader(Int32.Parse(txt_ponumber.Text), "")
        dsPOAppr = PO.GetPOApprovals(Int32.Parse(txt_ponumber.Text.Trim))
        Dim polimit As Decimal = POHeader.Get_PO_Emp_Limit(1, POHeader.Issue_By_Emp_Code, usercode, username)
        If dsPOAppr.HasRows Then
            If POHeader.PO_Approval_Flag = 0 Then
                txt_PO_Pad.Text = POHeader.PO_Pad.Trim
            End If
            If POHeader.PO_Approval_Flag = 1 Then
                txt_PO_Pad.Text = "(Pending)"
            End If
            If POHeader.PO_Approval_Flag = 2 Then
                txt_PO_Pad.Text = POHeader.PO_Pad.Trim
            End If
            If POHeader.PO_Approval_Flag = 3 Then
                txt_PO_Pad.Text = "(Denied)"
            End If
        Else
            dsPO = PODtl.LoadAll_PO_Detail_List(1, Int32.Parse(txt_ponumber.Text.Trim), "", "")
            If PO.GetPOReqdExtAmount_Flg() Then
                If dsPO.HasRows = False Or POHeader.PO_Total.ToString() = "" Or POHeader.PO_Total.ToString() = "0.00" Then
                    Me.txt_PO_Pad.Text = "(Incomplete)"
                Else
                    If POHeader.PO_Appr_Rule_Code <> "" Then
                        If polimit = -1.0 Then
                            Me.txt_PO_Pad.Text = "(Incomplete)"
                        Else
                            If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                                Me.txt_PO_Pad.Text = "(Incomplete)"
                            ElseIf POHeader.Exceed = 1 Then
                                Me.txt_PO_Pad.Text = "(Incomplete)"
                            End If
                        End If
                    End If
                End If
            Else
                If POHeader.PO_Appr_Rule_Code <> "" Then
                    If polimit = -1.0 Then
                        Me.txt_PO_Pad.Text = "(Incomplete)"
                    Else
                        If POHeader.Exceed = 0 And POHeader.PO_Printed = 0 Then
                            Me.txt_PO_Pad.Text = "(Incomplete)"
                        ElseIf POHeader.Exceed = 1 Then
                            Me.txt_PO_Pad.Text = "(Incomplete)"
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Function checkApprovalCode()
        Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim oEmp As New cEmployee(Session("ConnString"))
        Dim dept As String
        Dim deptApproval As String = ""
        Dim empApproval As String = ""
        PO.Select_POHeader(Int32.Parse(txt_ponumber.Text), "")
        dept = oEmp.GetDept(PO.Issue_By_Emp_Code)
        empApproval = PO.GetPOApprRuleCodebyEmp(PO.Issue_By_Emp_Code)
        If dept <> "" Then
            deptApproval = PO.GetPOApprRuleCodebyDept(dept)
        End If
        If empApproval = "" And deptApproval = "" Then
            Return True
        Else
            Return False
        End If
    End Function

End Class