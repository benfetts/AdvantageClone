<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MobileBasicTime.aspx.vb" Inherits="Webvantage.MobileBasicTime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Webvantage Mobile</title>
    
    
    <link href="~/CSS/MobileBB.min.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <meta name="viewport" content="width = 320" />
    <meta name="viewport" content="initial-scale=1, user-scalable=yes" />

    <script type="text/javascript">
                function SetToday(tb){
                    var thisTextbox = document.getElementById(tb);
                    var mydate=new Date()
                    var year=mydate.getYear()
                    if (year < 1000){
                    year+=1900;}
                    var day=mydate.getDay()
                    var month=mydate.getMonth()+1
                    if (month<10){
                    month="0"+month;}
                    var daym=mydate.getDate()
                    if (daym<10){
                    daym="0"+daym;}
                    if(thisTextbox.value == ""){
                    thisTextbox.value = month+"/"+daym+"/"+year;}
                    //thisTextbox.select();
            }
    </script>

</head>
<body onload="this.focus();">
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
            <table>
                <tr style="background-color: #d8e4f8;">
                    <td align="center">
                        Add Time</td>
                </tr>
                <tr>
                    <td>
                        Client:<br />
                        <asp:DropDownList runat="server" ID="ddClient" 
                             Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                         <asp:Label   runat="server" ID="lblClient" Width="200px" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelDivision" runat="server" Text="Division"></asp:Label>:<br />
                        <asp:DropDownList runat="server" ID="ddDivision" 
                            Enabled="false" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                         <asp:Label   runat="server" ID="lblDivision" Width="200px" Visible="false"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="LabelProduct" runat="server" Text="Product"></asp:Label>:<br />
                        <asp:DropDownList runat="server" ID="ddProduct" 
                            Enabled="false" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                         <asp:Label   runat="server" ID="lblProduct" Width="200px" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelJob" runat="server" Text="Job"></asp:Label>:<br />
                        <asp:DropDownList runat="server" ID="ddJob"  Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelJobComp" runat="server" Text="Job/Comp"></asp:Label>:<br />
                        <asp:DropDownList runat="server" ID="ddJobComp" 
                            Enabled="false" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id = "TrFunction" runat="server">
                    <td>
                        <asp:Label ID="LabelFunction" runat="server" Text="Function"></asp:Label>:<br />
                        <asp:DropDownList runat="server" ID="ddFunction" CssClass="RequiredInput" 
                            Enabled="false" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="TrCategory" runat="server">
                    <td>
                        <asp:Label ID="LabelCategory" runat="server" Text="Time Category"></asp:Label>:<br />
                        <asp:DropDownList runat="server" ID="DDTimeCategory" CssClass="RequiredInput" 
                            Enabled="false" Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table>
                <tr >
                    <td style="width: 100px">
                        Date:(mm/dd/yyyy)
                    </td>
                    <td>
                        <asp:TextBox ID="TxtDate" runat="server" CssClass="RequiredInput" 
                            Width="68px" AutoCompleteType="Cellular"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 100px">
                        Hours:</td><td>
                        <asp:TextBox ID="TxtHours" runat="server" CssClass="RequiredInput" 
                            Enabled="true" Width="40px" AutoCompleteType="Cellular"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                             ControlToValidate="TxtHours" ErrorMessage="*" 
                             ValidationExpression="^\d{0,2}(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Department:</td><td>
                        <asp:DropDownList ID="ddDepartment" runat="server" CssClass="RequiredInput" 
                            >
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table width="320px">
                <tr>
                    <td  valign="bottom">
                        Comment:
                    </td>
                </tr>
                <tr >
                    <td  >
                        <asp:TextBox ID="TxtComments" runat="server"  Height="60px"
                            TextMode="multiLine" Width="300px" ></asp:TextBox>
                    </td>
                </tr>
               
                <tr>
                    <td>
                        <asp:Label   ID="LblMSG" runat="server" CssClass="CssRequired" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div align="left">&nbsp;&nbsp;
                <asp:LinkButton ID="BtnSave"  runat="server" Text="Save"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbCancel"  runat="server" Text="Cancel"></asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
