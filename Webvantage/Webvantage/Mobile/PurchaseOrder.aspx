<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PurchaseOrder.aspx.vb" Inherits="Webvantage.PurchaseOrder1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>Webvantage Mobile - The Advantage Software Company, Inc.</title>
    
    
    <link href="~/CSS/MobileBB.min.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE"/>
        <meta name="viewport" content="width = 320" />  
    <meta name="viewport" content="initial-scale=1, user-scalable=yes" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table id="tblMobileHeader" runat="server" width="200"  >
                <tr>
                    <td style="width: 60px;">
                        <asp:Button runat="server" ID="btnBack" Text="Back" ForeColor="blue" BorderStyle="Solid"
                            BorderWidth="1px" Font-Size="XX-Small" />
                    </td>
                    <td style="width: 60px;">
                        <asp:Button runat="server" ID="btnLogout" Text="Logout" ToolTip="Logout" ForeColor="blue"
                            BorderStyle="Solid" BorderWidth="1px" Font-Size="XX-Small"></asp:Button>
                    </td>
                </tr>
            </table>
        <asp:Table runat="server" ID="tblPO">
            <asp:TableRow>
            <asp:TableCell>
                <asp:Label   runat="server" ID="lblPONumber" Text="PO Number"></asp:Label>
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label   runat="server" ID="lblOrderDate" Text="Order Date:"></asp:Label>
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
               <asp:Label   runat="server" ID="lblDueDate" Text="Due Date:"></asp:Label>         
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label   runat="server" ID="lblIssuedBy" Text="Issued By:"></asp:Label>
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label   runat="server" ID="lblIssuedTo" Text="Issued To:"></asp:Label>    
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
             <asp:Label   runat="server" ID="lblAddress1" Text="Address1:"></asp:Label>    
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
             <asp:Label   runat="server" ID="lblAddress2" Text="Address2:"></asp:Label>    
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
             <asp:Label   runat="server" ID="lblAddress3" Text="Address3:"></asp:Label>    
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
             <asp:Label   runat="server" ID="lblCityStateZip" Text="City/St/Zip:"></asp:Label>    
            </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label   runat="server" ID="lblPOTotal" Text="PO Total:"></asp:Label>    
            </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Repeater runat="server" ID="rptPO">
            <HeaderTemplate>
                <table >
            </HeaderTemplate>
            <ItemTemplate>
                  <tr>
                <td>
                <asp:Label   ID="lblLineNbr" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblDescription" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblCDP" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblJobComp" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblFunctionCode" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblFunctionDescription" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblGLAccount" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblQTY" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblRate" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblExtendedAmt" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblMarkupPct" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblMarkupAmt" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblLineTotal" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblEstimateBudget" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblPOUsed" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblBalance" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:Label   ID="lblCPM" runat="server"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                <asp:CheckBox ID="chkAP" runat="server" />
                </td>
                </tr>
                <tr>
                <td>
                <asp:CheckBox ID="chkComplete" runat="server" />
                </td>
                </tr>
           
            </ItemTemplate>
                        
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
    </div>
    </form>
</body>
</html>
