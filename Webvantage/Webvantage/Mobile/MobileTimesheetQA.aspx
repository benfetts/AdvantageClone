<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MobileTimesheetQA.aspx.vb"
    Inherits="Webvantage.MobileTimesheetQA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <td valign="top">
                        Client:
                        <asp:Label   ID="LblClient" runat="server"> </asp:Label>
                        <asp:HiddenField ID="HfClient" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Division: 
                        <asp:Label   ID="LblDivision" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        Product: 
                        <asp:Label   ID="LblProduct" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        Job: 
                        <asp:Label   ID="LblJob" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        Job Comp: 
                        <asp:Label   ID="LblJobComp" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        Task: 
                        <asp:Label   ID="LblTask" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        Task Comment: 
                        <asp:Label   ID="LblTaskComment" runat="server" Text=""></asp:Label></td>
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
                <tr >
                    <td style="width: 100px">
                        Function:</td>
                        <td>
                        <asp:DropDownList ID="DropFunction" runat="server" CssClass="RequiredInput" Width="190px" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="ProdCatRow" runat="server">
                    <td style="width: 100px">
                        Product Cat:</td><td>
                        <asp:DropDownList ID="DropProdCat" runat="server" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Hours:</td><td>
                        <asp:TextBox ID="TxtHours" runat="server" CssClass="RequiredInput" 
                            Enabled="true" Width="40px" AutoCompleteType="Cellular"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Department:</td><td>
                        <asp:DropDownList ID="DropDepartment" runat="server" CssClass="RequiredInput" >
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            
            <table>
                <tr>
                    <td  valign="bottom">
                        Time Comment:
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:TextBox ID="TxtComments" runat="server"  Height="60px"
                            TextMode="multiLine" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="ChkMarkCompleted" runat="server" Text="Mark Completed?" />
                        <asp:HiddenField ID="HfAlreadyMarked" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td  valign="bottom">
                        Completed Comment:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtCompletedComments" runat="server"  Height="60px"
                            TextMode="multiLine" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label   ID="LblMSG" runat="server" CssClass="CssRequired" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <div align="left">&nbsp;&nbsp;
                <asp:LinkButton ID="BtnSave"  runat="server" Text="Save"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbCancel"  runat="server" Text="Cancel"></asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
