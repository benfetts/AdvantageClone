<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_base_info.ascx.vb" Inherits="Webvantage.purchaseorder_base_info" %>
<table>
    <tr>
        <td style="width: 80px" align="right">
            PO Number:</td>
        <td style="width: 70px">
            <asp:TextBox ID="txt_PO_Pad" runat="server" 
                ReadOnly="True" Width="75px" BorderStyle="None">-1</asp:TextBox></td>
        <td style="width: 30px">
            <asp:Image ID="img_lock" runat="server" AlternateText="Locked Purchase Order." ImageUrl="images/lock.png"
                Visible="False" /></td>
        <td colspan="3" style="width: 300px">
            <asp:Label   ID="lbl_descrip" runat="server"></asp:Label></td>
        <td style="width: 90px" align="right">
            Date Issued:</td>
        <td align="left" colspan="1">
            <asp:Label   ID="lbl_po_dt" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 80px" align="right">
            Issue By:</td>
        <td colspan="5">
            <asp:Label   ID="lbl_emp_name" runat="server"></asp:Label>
            (<asp:Label   ID="lbl_emp_code" runat="server" Font-Italic="False"></asp:Label>)
            <asp:Label   ID="lbl_Void_Info" runat="server" CssClass="warning"></asp:Label></td>  
        <td style="width: 90px" align="right">
            Due Date:</td>
        <td align="left" style="width: 100px">
            <asp:Label   ID="lbl_due_dt" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 80px; height: 21px" align="right">
            Issue To:</td>
        <td colspan="5">
            <asp:Label   ID="lbl_vendor" runat="server"></asp:Label>
            (<asp:Label   ID="lbl_vn_code" runat="server" Font-Italic="False"></asp:Label>)</td>
        <td style="width: 90px;" align="right">
            PO Total:</td>
        <td align="left" style="width: 100px; height: 21px">
            <asp:Label   ID="lbl_total" runat="server" ></asp:Label></td>
    </tr>
</table>
<asp:TextBox ID="txt_ponumber" runat="server"  ForeColor="Transparent"
    ReadOnly="True" Visible="False" Width="62px">-1</asp:TextBox>
