<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_myprojects.aspx.vb" Inherits="Webvantage.dtp_myprojects" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <script type="text/javascript">
            function PrintRadGrid() {

                var styleStr = "<html><head><link href='" +
                    "CSS/Material/Bootstrap.Cyan.css" +
                    "' rel='stylesheet' type='text/css'></link><link href='" +
                    "CSS/Common.css" +
                    "' rel='stylesheet' type='text/css'></link><link href='" +
                    "CSS/CardLayout.css" +
                    "' rel='stylesheet' type='text/css'></link><link href='" +
                    "CSS/CardLayout.Colors.css" +
                    "' rel='stylesheet' type='text/css'></link><link href='" +
                    "App_Themes/Metro/Metro.min.css" +
                    "' rel='stylesheet' type='text/css'></link>";

                var htmlcontent = styleStr + "<body>" + window["TasksRadGrid2"].outerHTML + "</body></html>";
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
    <table border="0" cellpadding="6" cellspacing="0" width="100%">
        <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" OnClientClick="PrintRadGrid(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" />&nbsp;
                    <br/>
                </td>
            </tr>
        <tr>
            <td align="left" colspan="10">
                &nbsp;&nbsp;<asp:Label   ID="lblTitle" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="TasksRadGrid2" runat="server" AllowPaging="false" AllowSorting="True" ClientIDMode="Static" 
                    AutoGenerateColumns="False" GridLines="None" Width="98%">
                    <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                    <MasterTableView AllowMultiColumnSorting="true">
                        <Columns>
                            <telerik:GridBoundColumn DataField="CDP" HeaderText="Client" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobAndComp" HeaderText="Project" UniqueName="column4">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StartDate" DataFormatString="{0:d}" HeaderText="Start Date"
                                UniqueName="column5">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DueDate" DataFormatString="{0:d}" HeaderText="Due Date"
                                UniqueName="column6">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Status" HeaderText="Status" UniqueName="column7">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AE" HeaderText="AE" UniqueName="column8">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TrafficCount" HeaderText="Open Tasks" UniqueName="column9">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <%--<webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />--%>
</asp:Content>
