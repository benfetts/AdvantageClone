<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_tasks.aspx.vb" Inherits="Webvantage.dtp_tasks" %>

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

            var htmlcontent = styleStr + "<body>" + window["RadGridTaskList"].outerHTML + "</body></html>";
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
    <table border="0" bordercolor="#333399" cellpadding="2" cellspacing="0" width="99%" align="center">
    <tr>
    <td>
    <asp:Button ID="BtnPrint" runat="server" OnClientClick="PrintRadGrid(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" />&nbsp;
    </td>
    </tr>
    </table>
    <telerik:RadGrid ID="RadGridTaskList" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
        Width="99%" AllowSorting="true">
        <MasterTableView AllowMultiColumnSorting="true">
            <Columns>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div id="DivPriorityColor" runat="server" class="icon-background background-color-sidebar">
                            <asp:Image ID="ImagePriority" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/progress_bar.png" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="CDP" HeaderText="Client" UniqueName="cdp">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JobData" HeaderText="Project" UniqueName="column3">
                </telerik:GridBoundColumn>                
                <telerik:GridBoundColumn DataField="JOB_COMP" HeaderText="Job/Comp" UniqueName="column36">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Job Description" UniqueName="column34">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Comp Description" UniqueName="column35">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Task" HeaderText="Task" UniqueName="taskcolumn">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FNC_COMMENTS" HeaderText="Task Comment" UniqueName="column31"
                    ItemStyle-Width="125px">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="HoursAllowed" HeaderText="Hours" UniqueName="column">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="StartDate" HeaderText="Start" UniqueName="column77" DataFormatString="{0:d}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DueDate" HeaderText="Due" UniqueName="column78" DataFormatString="{0:d}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DueTime" HeaderText="Due By" UniqueName="column7"
                    ItemStyle-Width="50px">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TASK_STATUS" UniqueName="column14" HeaderText="Status">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn4">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                            <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <ExpandCollapseColumn Visible="False">
                <HeaderStyle Width="19px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
        </MasterTableView>
    </telerik:RadGrid>
    <%--<webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />--%>
</asp:Content>
