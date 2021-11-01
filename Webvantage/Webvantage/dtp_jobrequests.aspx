<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dtp_jobrequests.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.dtp_jobrequests" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
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

                var htmlcontent = styleStr + "<body>" + window["RadGridJobRequestsDO"].outerHTML + "</body></html>";
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
     <table border="0" bordercolor="#333399" cellpadding="2" cellspacing="0" width="99%"
        align="center">
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" OnClientClick="PrintRadGrid(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" />&nbsp;
                <br/>
                &nbsp;Job Requests<br />
                &nbsp;<asp:Label ID="Label" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="8">
                <telerik:RadGrid ID="RadGridJobRequestsDO" runat="server" AutoGenerateColumns="False" AllowSorting="True" ClientIDMode="Static" 
                    Width="99%">
                    <MasterTableView AllowMultiColumnSorting="True">
                        <Columns>
                            <telerik:GridBoundColumn DataField="CL_CODE" HeaderText="Client" UniqueName="ClientCode" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client Name" UniqueName="ClientName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_CODE" HeaderText="Division" UniqueName="DivisionCode">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division Name" UniqueName="DivisionName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_CODE" HeaderText="Product" UniqueName="ProductCode">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product Name" UniqueName="ProductName">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_VER_DESC" HeaderText="Description" UniqueName="JobRequestDescription" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CREATE_DATE" HeaderText="Date of Request" UniqueName="RequestDate" DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CREATED_BY" HeaderText="Created By" UniqueName="CreatedBy">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status" UniqueName="RequestStatus">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_NUMBER" HeaderText="Job" UniqueName="JobNumber">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Job Description" UniqueName="JobDescription">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Component" UniqueName="ComponentNumber">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Comp Description" UniqueName="ComponentDescription">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    
    <%--<webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />--%>
</asp:Content>
