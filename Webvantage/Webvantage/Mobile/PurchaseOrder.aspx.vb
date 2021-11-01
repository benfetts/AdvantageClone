Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports Microsoft.Win32
Imports Webvantage.cGlobals.Globals
Imports Webvantage.MiscFN



Partial Public Class PurchaseOrder1
    Inherits MobileBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Not IsNothing(Request.QueryString("po_number")) Then
                If IsNumeric(Request.QueryString("po_number")) Then
                    btnBack.Attributes.Add("onclick", "history.back(); return false")

                    Session("PONUM") = AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(Request.QueryString("po_number"))
                    LoadPurchaseOrderHeader()
                    LoadPODetail()
                End If
            End If
        End If
    End Sub

    Public Function LoadPurchaseOrderHeader() As Integer
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim usercode, username, spolimit As String

        Try

            POHeader.Select_POHeader(Int32.Parse(AdvantageFramework.StringUtilities.RijndaelSimpleDecryptPO(Session("PONUM"))), "")
            If POHeader.PO_Approval_Flag = 0 Or POHeader.PO_Approval_Flag = 3 Then
                Me.lblPONumber.Text = "PO Number: (Denied)"
            Else
                Me.lblPONumber.Text = "PO Number: " + AdvantageFramework.StringUtilities.RijndaelSimpleDecryptPO(Session("PONUM")) '+ POHeader.PO_Date.ToString
            End If
            'PO_PAD.Text = POHeader.PO_Pad.Trim
            'VN_CODE.Text = POHeader.Vendor_Code.Trim
            'EMP_CODE.Text = POHeader.Issue_By_Emp_Code.Trim
            'PO_DESCRIPTION.Text = POHeader.PO_Description.Trim
            Me.lblIssuedBy.Text = "Issued By: " + POHeader.Issue_By_Emp_Name.Trim.ToString
            Me.lblIssuedTo.Text = "Issued To: " + POHeader.Vendor_Name
            'VN_NAME.Text = POHeader.Vendor_Name.Trim
            Me.lblOrderDate.Text = "Order Date: " + POHeader.PO_Date.ToString
            Me.lblDueDate.Text = "Due Date: " + POHeader.PO_Due_Date.ToString
            Me.lblAddress1.Text = "Address1: " + POHeader.Vendor_Address1.Trim
            Me.lblAddress2.Text = "Address2: " + POHeader.Vendor_Address2.Trim
            Me.lblAddress3.Text = "Address3: " + POHeader.Vendor_Address3.Trim
            Me.lblCityStateZip.Text = "City/St/Zip: " + POHeader.Vendor_CityStateZip.Trim
            'VC_CODE.Text = POHeader.Vendor_Contact_Code.Trim
            'VC_NAME.Text = POHeader.Vendor_Contact_Name.Trim
            'VC_EMAIL.Text = POHeader.Vendor_Contact_Email.Trim

            Me.lblPOTotal.Text = "PO Total: " + String.Format("{0:#,##0.00}", CDbl(POHeader.PO_Total))


            Return 0
        Catch ex As Exception
            Return 1
        End Try

    End Function
    Public Function LoadPODetail()
        Dim dr_PO_Detail2 As SqlDataReader
        Dim PODetail As wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail = New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))

        dr_PO_Detail2 = PODetail.LoadAll_PO_Detail_List(1, Int32.Parse(AdvantageFramework.StringUtilities.RijndaelSimpleDecryptPO(Session("PONUM"))), "", "")
        Me.rptPO.DataSource = dr_PO_Detail2
        rptPO.DataBind()
    End Function

    Protected Sub rptPO_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptPO.ItemCommand

    End Sub

    Private Sub rptPO_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptPO.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = e.Item.ItemType.AlternatingItem Then
            Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
            Dim glselect As Integer
            glselect = PODtl.GetPOGLAccountSelection("ama")



            'lbllinenbr
            Dim lblLineNbr As System.Web.UI.WebControls.Label = e.Item.FindControl("lblLineNbr")
            If DataBinder.Eval(e.Item.DataItem, "LINE_NUMBER") IsNot DBNull.Value Then
                lblLineNbr.Text = "Line: " + e.Item.DataItem("LINE_NUMBER").ToString
            End If

            'lblDescription
            Dim lblDescription As System.Web.UI.WebControls.Label = e.Item.FindControl("lblDescription")
            If DataBinder.Eval(e.Item.DataItem, "LINE_DESC") IsNot DBNull.Value Then
                lblDescription.Text = "Description: " + e.Item.DataItem("LINE_DESC").ToString
            End If
            'lblCDP
            Dim lblCDP As System.Web.UI.WebControls.Label = e.Item.FindControl("lblCDP")
            If DataBinder.Eval(e.Item.DataItem, "CL_CODE") IsNot DBNull.Value And DataBinder.Eval(e.Item.DataItem, "DIV_CODE") IsNot DBNull.Value And DataBinder.Eval(e.Item.DataItem, "PRD_CODE") IsNot DBNull.Value Then
                lblCDP.Text = "C/D/P: " + e.Item.DataItem("CL_CODE").ToString() + "/" + e.Item.DataItem("DIV_CODE").ToString() + "/" + e.Item.DataItem("PRD_CODE").ToString
            End If


            'lblJobComp
            Dim lblJobComp As System.Web.UI.WebControls.Label = e.Item.FindControl("lblJobComp")
            If DataBinder.Eval(e.Item.DataItem, "JOB_NUMBER") IsNot DBNull.Value Then
                lblJobComp.Text = "Job/Comp Nbr: " + e.Item.DataItem("JOB_NUMBER").ToString
            End If

            If lblJobComp.Text <> "" Then
                lblJobComp.Text = lblJobComp.Text.PadLeft(6, "0")
            End If

            Dim lblComp As New System.Web.UI.WebControls.Label
            If DataBinder.Eval(e.Item.DataItem, "JOB_COMPONENT_NBR") IsNot DBNull.Value Then
                lblComp.Text = e.Item.DataItem("JOB_COMPONENT_NBR")
                If lblComp.Text <> "" Then
                    lblComp.Text = lblComp.Text.PadLeft(2, "0")
                End If
                lblJobComp.Text = lblJobComp.Text & "-" & lblComp.Text
            End If

            '____________________________________________________________
            Dim dr As SqlDataReader
            If DataBinder.Eval(e.Item.DataItem, "JOB_NUMBER") IsNot DBNull.Value And DataBinder.Eval(e.Item.DataItem, "JOB_COMPONENT_NBR") IsNot DBNull.Value Then
                If e.Item.DataItem("JOB_NUMBER").ToString() <> "" And e.Item.DataItem("JOB_COMPONENT_NBR").ToString() <> "" Then
                    dr = PODtl.LoadAll_PO_Apprv_Estm_Lines_ByJobComp(1, CInt(e.Item.DataItem("JOB_NUMBER")), CInt(e.Item.DataItem("JOB_COMPONENT_NBR")), e.Item.DataItem("FNC_CODE"))
                    If dr.HasRows = True Then
                        Do While dr.Read
                            'lblPOUsed
                            Dim lblPOUsed As System.Web.UI.WebControls.Label = e.Item.FindControl("lblPOUsed")
                            lblPOUsed.Text = "PO Used: " + dr("PO_EXIST_AMT").ToString

                            'lblBalance
                            Dim lblBalance As System.Web.UI.WebControls.Label = e.Item.FindControl("lblBalance")
                            lblBalance.Text = "Balance: " + dr("BALANCE").ToString

                            'lblEstimateBudget
                            Dim lblEstimateBudget As System.Web.UI.WebControls.Label = e.Item.FindControl("lblEstimateBudget")
                            lblEstimateBudget.Text = "Estimate/Budget: " + dr("EST_REV_EXT_AMT").ToString
                        Loop
                    End If
                End If
                dr.Close()

            End If


            '____________________________________________________________

            'lblFunctionCode
            Dim lblFunctionCode As System.Web.UI.WebControls.Label = e.Item.FindControl("lblFunctionCode")
            If DataBinder.Eval(e.Item.DataItem, "FNC_CODE") IsNot DBNull.Value Then
                lblFunctionCode.Text = "Function Code: " + e.Item.DataItem("FNC_CODE").ToString
            End If
            'lblFunctionDescription
            Dim lblFunctionDescription As System.Web.UI.WebControls.Label = e.Item.FindControl("lblFunctionDescription")
            If DataBinder.Eval(e.Item.DataItem, "FNC_DESCRIPTION") IsNot DBNull.Value Then
                lblFunctionDescription.Text = "Function Description: " + e.Item.DataItem("FNC_DESCRIPTION").ToString
            End If
            'lblGLAccount
            Dim lblGLAccount As System.Web.UI.WebControls.Label = e.Item.FindControl("lblGLAccount")
            If DataBinder.Eval(e.Item.DataItem, "GLACODE") IsNot DBNull.Value Then
                lblGLAccount.Text = "GL Account: " + e.Item.DataItem("GLACODE").ToString
            End If
            'lblQTY
            Dim lblQTY As System.Web.UI.WebControls.Label = e.Item.FindControl("lblQTY")
            If DataBinder.Eval(e.Item.DataItem, "PO_QTY") IsNot DBNull.Value Then
                lblQTY.Text = "QTY: " + e.Item.DataItem("PO_QTY").ToString
            End If
            'lblRate
            Dim lblRate As System.Web.UI.WebControls.Label = e.Item.FindControl("lblRate")
            If DataBinder.Eval(e.Item.DataItem, "PO_RATE") IsNot DBNull.Value Then
                lblRate.Text = "Rate: " + e.Item.DataItem("PO_RATE").ToString
            End If
            'lblExtendedAmt
            Dim lblExtendedAmt As System.Web.UI.WebControls.Label = e.Item.FindControl("lblExtendedAmt")
            If DataBinder.Eval(e.Item.DataItem, "PO_EXT_AMOUNT") IsNot DBNull.Value Then
                lblExtendedAmt.Text = "Extended Amt: " + e.Item.DataItem("PO_EXT_AMOUNT").ToString
            End If
            'lblMarkupPct
            Dim lblMarkupPct As System.Web.UI.WebControls.Label = e.Item.FindControl("lblMarkupPct")
            If DataBinder.Eval(e.Item.DataItem, "PO_COMM_PCT") IsNot DBNull.Value Then
                lblMarkupPct.Text = "Markup Pct: " + e.Item.DataItem("PO_COMM_PCT").ToString
            End If
            'lblMarkupAmt
            Dim lblMarkupAmt As System.Web.UI.WebControls.Label = e.Item.FindControl("lblMarkupAmt")
            If DataBinder.Eval(e.Item.DataItem, "EXT_MARKUP_AMT") IsNot DBNull.Value Then
                lblMarkupAmt.Text = "Markup Amt: " + e.Item.DataItem("EXT_MARKUP_AMT").ToString
            End If
            'lblLineTotal
            Dim lblLineTotal As System.Web.UI.WebControls.Label = e.Item.FindControl("lblLineTotal")
            If DataBinder.Eval(e.Item.DataItem, "LINE_TOTAL") IsNot DBNull.Value Then
                lblLineTotal.Text = "Line Total: " + e.Item.DataItem("LINE_TOTAL").ToString
            End If

            'lblCPM
            Dim lblCPM As System.Web.UI.WebControls.Label = e.Item.FindControl("lblCPM")
            If DataBinder.Eval(e.Item.DataItem, "USE_CPM") IsNot DBNull.Value Then
                lblCPM.Text = "CPM: " + e.Item.DataItem("USE_CPM").ToString
            End If
            'chkAP
            Dim chkAP As CheckBox = e.Item.FindControl("chkAP")
            If DataBinder.Eval(e.Item.DataItem, "ATTACHED_TO_AP") IsNot DBNull.Value Then
                chkAP.Text = "AP"
                chkAP.Checked = e.Item.DataItem("ATTACHED_TO_AP").ToString
                chkAP.Enabled = False
            End If
            'chkComplete
            Dim chkComplete As CheckBox = e.Item.FindControl("chkComplete")
            If DataBinder.Eval(e.Item.DataItem, "PO_COMPLETE") IsNot DBNull.Value Then
                chkComplete.Text = "Complete"
                chkComplete.Checked = e.Item.DataItem("PO_COMPLETE").ToString
                chkComplete.Enabled = False
            End If
        End If



    End Sub
End Class