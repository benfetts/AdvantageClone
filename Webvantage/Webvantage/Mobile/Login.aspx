<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Login.aspx.vb" Inherits="Webvantage.Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Webvantage Mobile</title>
    
    
    <link href="~/CSS/MobileBB.min.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE"/>
    <meta name="viewport" content="width = 320" />  
    <meta name="viewport" content="initial-scale=1, user-scalable=yes" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table runat="server" ID="tblASP">
            <asp:TableRow>
                <asp:TableCell>
                    Welcome to Webvantage Mobile
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table runat="server" ID="tblLogin"  CellPadding="0" CellSpacing="0">
            <asp:TableRow>
                <asp:TableCell>
                        &nbsp;
                </asp:TableCell>
                <asp:TableCell>Please Login:</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow  ID="trSQLServer">
                <asp:TableCell Style="width: 150px; text-align: right;" >
                    <asp:Label   ID="lblServer" runat="server">SQL Server Name:</asp:Label>
                </asp:TableCell>
                <asp:TableCell Style="width: 155px; text-align: left;">
                    <asp:TextBox ID="txtSQLServer" runat="server" BackColor="LightBlue" BorderColor="LightSkyBlue"
                        BorderStyle="Solid" BorderWidth="1px" Font-Size="XX-Small" ForeColor="#0000C0"
                        Width="150px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell  Style="width: 150px; text-align: right;" >
                    <asp:Label   ID="lblDBName" runat="server" Text="Database Name: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell Style="width: 155px; text-align: left;">
                    <asp:TextBox ID="txtDataBase" runat="server" BackColor="LightBlue" BorderColor="LightSkyBlue"
                        BorderStyle="Solid" BorderWidth="1px" Font-Size="XX-Small" ForeColor="#0000C0"
                        Width="150px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow id="TrUserID" runat="server">
                <asp:TableCell  Style="width: 150px; text-align: right;" >
                    <asp:Label   ID="lblUserID" runat="server" Text="User ID:"></asp:Label></asp:TableCell>
                <asp:TableCell valign="middle" Style="width: 155px; text-align: left;">
                    <asp:TextBox ID="txtUserID" runat="server" BackColor="LightBlue" BorderColor="LightSkyBlue"
                        BorderStyle="Solid" BorderWidth="1px" Font-Size="XX-Small" ForeColor="#0000C0"
                        Width="150px">
                    </asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow id="TrPassword" runat="server">
                <asp:TableCell  Style="width: 150px; text-align: right;">
                    <asp:Label   ID="lblPassword" runat="server" Text="Password:"></asp:Label></asp:TableCell>
                <asp:TableCell valign="middle" Style="width: 155px; text-align: left;">
                    <asp:TextBox ID="txtPassword" runat="server" BackColor="LightBlue" BorderColor="LightSkyBlue"
                        BorderStyle="Solid" BorderWidth="1px" Font-Size="XX-Small" ForeColor="#0000C0"
                        TextMode="Password" Width="150px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow id="TrTrusted" runat="server">
           
             <asp:TableCell  Style="width: 150px; text-align: right;" >
                        &nbsp;
                </asp:TableCell>
                 <asp:TableCell  Style="text-align: Left;" >
                    <span class="style4"><strong>Use Trusted Connection</strong></span>
                                            <asp:CheckBox ID="chkTrusted" runat="server" 
                                                Text="" />
            </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell  Style="width: 150px; text-align: right;" >
                        &nbsp;
                </asp:TableCell>
                <asp:TableCell valign="middle" Style="height: 20px; width: 155px; text-align: left;">
                    <asp:CheckBox ID="chkRemember" runat="server" 
                        Text="Remember my Login" Width="151px" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell  Style="width: 150px; text-align: right;" >
                        &nbsp;
                </asp:TableCell>
                <asp:TableCell style="text-align: left;" >
                    <asp:Button ID="btnLogin" runat="server" ForeColor="blue" BorderStyle="Solid" BorderWidth="1px"
                        Font-Size="XX-Small" Text="Login" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label   ID="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Brown" Font-Bold="True"></asp:Label>
    </form>
</body>
</html>
