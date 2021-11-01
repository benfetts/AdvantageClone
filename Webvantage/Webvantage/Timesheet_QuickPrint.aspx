<%@ Page Title="Print Timesheet" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Timesheet_QuickPrint.aspx.vb" Inherits="Webvantage.Timesheet_QuickPrint" %>
<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <link type="text/css" href="CSS/Print.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <script type="text/javascript">
        function PrintTimeSheet() {
   
            var styleStr = "<html><head><link href='" +
                "CSS/Print.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/Common.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.Colors.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "App_Themes/Metro/Metro.min.css" +
                "' rel='stylesheet' type='text/css'></link></head>";

            var htmlcontent = styleStr + "<body>" + document.getElementById("divTimeSheetQuickPrint").innerHTML + "</body></html>";
            htmlcontent = htmlcontent.replace(/<script .*?>(.|\n)*?<\/script>/gi, "");
            
            //Get the HTML of whole page
            var oldPageHtml = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML = htmlcontent;
               
            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPageHtml;
        }
    </script>
    <asp:Button ID="BtnPrint" runat="server" OnClientClick="PrintTimeSheet(); return false;" Text="Print" style="text-align: right; background-image: url(Images/printer.png); background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="60px" />&nbsp;
<div  id="divTimeSheetQuickPrint" style="margin-left:10px;margin-right:10px;">
    <asp:Repeater ID="repTimeSheet" runat="server">
        <HeaderTemplate>
            <table border="0" cellpadding="6" cellspacing="0" width="100%" >
                <tr >
                    <td colspan="15" align="left" class="HeaderStyle3">
                        <asp:Literal ID="LiteralHeader" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="SubHeaderStyle">
                        Client
                    </td>
                    <td class="SubHeaderStyle">
                        <asp:Label ID="LabelDivision" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle">
                        <asp:Label ID="LabelProduct" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle" style="text-align: right;">
                        <asp:Label ID="LabelJob" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle" style="text-align: right;">
                        <asp:Label ID="LabelJobComponent" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle">
                        <asp:Label ID="LabelFuncCat" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle">
                        Dept
                    </td>
                    <td id="TdProdCatHeader" runat="server" class="SubHeaderStyle">
                        Prod Cat
                    </td>
                    <td class="SubHeaderStyle" style="text-align: right;">
                        <asp:Label ID="LabelSunHeader" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle" style="text-align: right;">
                        <asp:Label ID="LabelMonHeader" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle" style="text-align: right;">
                        <asp:Label ID="LabelTueHeader" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle" style="text-align: right;">
                        <asp:Label ID="LabelWedHeader" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle" style="text-align: right;">
                        <asp:Label ID="LabelThuHeader" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle" style="text-align: right;">
                        <asp:Label ID="LabelFriHeader" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle" style="text-align: right;">
                        <asp:Label ID="LabelSatHeader" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="SubHeaderStyle" style="text-align: right;">
                        Total
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td  >
                    <%# Eval("ClientCode")%>
                </td>
                <td  >
                    <%# Eval("DivisionCode")%>
                </td>
                <td >
                    <%# Eval("ProductCode")%>
                </td>
                <td style="text-align: right;" >
                    <%# IIf(Eval("JobNumber") = 0, "", Eval("JobNumber").ToString().PadLeft(6, "0"))%>
                </td>
                <td style="text-align: right;">
                    <%# IIf(Eval("JobComponentNbr") = 0, "", Eval("JobComponentNbr").ToString().PadLeft(3, "0"))%>
                </td>
                <td  >
                    <%# Eval("FuncCat") %>
                </td>
                <td  >
                    <%# Eval("Dept") %>
                </td>
                <td id="TdProdCat" runat="server" align="center">
                    <%# Eval("ProductCategory") %>
                </td>
                <td style="text-align: right;">
                    <asp:Literal ID="LiteralSunday" runat="server"></asp:Literal>
                </td>
                <td style="text-align: right;">
                    <asp:Literal ID="LiteralMonday" runat="server"></asp:Literal>
                </td>
                <td style="text-align: right;">
                    <asp:Literal ID="LiteralTuesday" runat="server"></asp:Literal>
                </td>
                <td style="text-align: right;">
                    <asp:Literal ID="LiteralWednesday" runat="server"></asp:Literal>
                </td>
                <td style="text-align: right;">
                    <asp:Literal ID="LiteralThursday" runat="server"></asp:Literal>
                </td>
                <td style="text-align: right;">
                    <asp:Literal ID="LiteralFriday" runat="server"></asp:Literal>
                </td>
                <td style="text-align: right;">
                    <asp:Literal ID="LiteralSaturday" runat="server"></asp:Literal>
                </td>
                <td style="text-align: right;">
                    <%# FormatNumber(Eval("TotalHours"), 2)%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
                <td id="TdTotals" runat="server" style="text-align: right;" class="SubHeaderStyle">
                    Totals
                </td>
                <td class="SubHeaderStyle" style="text-align: right;">
                    <%#SunTotal%>
                </td>
                <td class="SubHeaderStyle" style="text-align: right;">
                    <%#MonTotal%>
                </td>
                <td class="SubHeaderStyle" style="text-align: right;">
                    <%#TueTotal%>
                </td>
                <td class="SubHeaderStyle" style="text-align: right;">
                    <%#WedTotal%>
                </td>
                <td class="SubHeaderStyle" style="text-align: right;">
                    <%#ThuTotal%>
                </td>
                <td class="SubHeaderStyle" style="text-align: right;">
                    <%#FriTotal%>
                </td>
                <td class="SubHeaderStyle" style="text-align: right;">
                    <%#SatTotal%>
                </td>
                <td class="SubHeaderStyle" style="text-align: right;">
                    <%#TotalHours%>
                </td>
            </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <table border="0" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td>
               I certify that the time posted on the date(s) listed is accurate and complete.
            </td>
            <td>
               I have reviewed and approved this timesheet for accuracy and reasonableness.
            </td>
        </tr>
        <tr>
            <td height="41" valign="bottom">
                <telerik:RadBinaryImage ID="RadBinaryImageEmployeeSignature" runat="server" AutoAdjustImageControlSize="false"
                    Width="200" Height="100%" />
                &nbsp;
                <asp:Label   ID="LabelDate" runat="server" BorderStyle="None" Text=""> </asp:Label>
            </td>
            <td valign="bottom">
            </td>
        </tr>
        <tr>
            <td valign="top">
               _______________________________________________
            </td>
            <td valign="top">
               _______________________________________________
            </td>
        </tr>
        <tr>
            <td>
               Employee Signature / Date
            </td>
            <td>
               Supervisor Signature / Date
            </td>
        </tr>
    </table>
    <%--<webvantage:print_buttons id="Print_Buttons1" runat="server" />--%>
    </div>
</asp:Content>
