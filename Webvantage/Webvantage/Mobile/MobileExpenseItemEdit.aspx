<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MobileExpenseItemEdit.aspx.vb" Inherits="Webvantage.MobileExpenseItemEdit1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Webvantage Mobile</title>
    
    
    <link href="~/CSS/MobileBB.min.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <meta name="viewport" content="width = 320" />
    <meta name="viewport" content="initial-scale=1, user-scalable=yes" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="tblMobileHeader" runat="server" width="200">
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
            <br />
            <table runat="server" id="tblItemAdd">
                <tr visible="false">
                    <td>
                        Item #:
                        <asp:Label   runat="server" ID="lblItemNumber"></asp:Label>
                    </td>
                </tr>
                <tr visible="false">
                    <td>
                        EXPDETAILID:
                        <asp:Label   runat="server" ID="lblEXPDETAILID"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Report #:
                        <asp:Label   runat="server" ID="lblReportNum"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Employee #
                        <asp:Label   runat="server" ID="lblEmployee"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Item Date:
                        <asp:TextBox runat="server" ID="txtItemDate"  
                            AutoCompleteType="Cellular" CssClass="RequiredInput"></asp:TextBox>
                    </td>
                </tr>
                <tr visible="false">
                    <td>
                        Report Date:
                        <asp:TextBox runat="server" ID="txtReportDate"  
                              CssClass="RequiredInput"></asp:TextBox>
                    </td>
                </tr>
                <tr visible="false">
                    <td>
                        Description:
                        <asp:TextBox runat="server" ID="txtDescription"  
                             CssClass="RequiredInput" ></asp:TextBox>
                    </td>
                </tr>
                <tr visible="false">
                    <td>
                        <b style="vertical-align: top; text-align: left">Detail:
                        <asp:TextBox runat="server" ID="txtDetail"  
                            TextMode="MultiLine" AutoCompleteType="Cellular"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Credit Card:
                        <asp:CheckBox runat="server" ID="chkCreditCard" Checked="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox runat="server"  ID="chkNonBillable" Checked="false" Visible="false" Text="Non Billable:" Font-Bold="True" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Client:<br />
                        <asp:DropDownList runat="server" ID="ddClient" 
                            Enabled="false" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label   runat="server" ID="lblClient" Width="200px" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Division:<br />
                        <asp:DropDownList runat="server" ID="ddDivision" 
                            Enabled="false" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label   runat="server" ID="lblDivision" Width="200px" Visible="false"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        Product:<br />
                        <asp:DropDownList runat="server" ID="ddProduct" 
                            Enabled="false" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label   runat="server" ID="lblProduct" Width="200px" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Job:<br />
                        <asp:DropDownList runat="server" ID="ddJob"  Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Job Comp:<br />
                        <asp:DropDownList runat="server" ID="ddJobComp" 
                            Enabled="false" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Function:<br />
                        <asp:DropDownList runat="server" ID="ddFunction" 
                            Enabled="false" Width="200px" AutoPostBack="True"  CssClass="RequiredInput">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                            <asp:Label   ID="lblQty" runat="server">Qty:</asp:Label>&nbsp;
                        <asp:TextBox runat="server" ID="txtQty"  
                            Width="50px" AutoCompleteType="Cellular"></asp:TextBox>&nbsp;
                        <asp:ImageButton ID="ImgBtnGetRate" runat="server" AlternateText="Get rate" CommandName="GetRate"
                            ImageAlign="AbsMiddle" ImageUrl="~/Images/arrow_right_green-trans.png" 
                            ToolTip="Get rate" CausesValidation="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        
                            <asp:Label   ID="lblRate" runat="server">Rate:</asp:Label>&nbsp;
                        <asp:TextBox runat="server" ID="txtRate"  
                            Width="100px" AutoCompleteType="Cellular"></asp:TextBox>&nbsp;
                            
                        <asp:ImageButton ID="imgBtnCalcTotal" runat="server" AlternateText="Calculate Total" CommandName="CalcTotal"
                            ImageAlign="AbsMiddle" ImageUrl="~/Images/arrow_right_green-trans.png" 
                            ToolTip="Calculate Total" CausesValidation="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        
                            <asp:Label   ID="lblTotal" runat="server">Amount:</asp:Label>&nbsp;
                        <asp:TextBox runat="server" ID="txtAmount"  
                            Width="100px" AutoCompleteType="Cellular"  CssClass="RequiredInput"></asp:TextBox>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <b style="vertical-align: top; text-align: left">Description:
                        <asp:TextBox runat="server" ID="txtItemDescription" 
                            Rows="3" TextMode="MultiLine" AutoCompleteType="Cellular"  CssClass="RequiredInput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label   runat="server" ID="lblMessage"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:LinkButton ID="lbSave" runat="server">Save</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lbDeleteItem" runat="server" Enabled="False">Delete</asp:LinkButton>&nbsp;
        </div>
    </form>
</body>
</html>
