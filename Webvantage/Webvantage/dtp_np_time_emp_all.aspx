<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dtp_np_time_emp_all.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.dtp_np_time_emp_all" %>

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

                var htmlcontent = styleStr + "<body>" + window["RadGrid1"].outerHTML + "</body></html>";
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
        <table align="center" cellpadding="0" cellspacing="0"  width="100%">
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" OnClientClick="PrintRadGrid(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" />&nbsp;
                    <br/>
                </td>
            </tr>
            <tr>
                <td  align="Left">
                    &nbsp;<asp:Label   ID="Label1" runat="server"   ></asp:Label>
                </td>
                <td  align="right">
                    <asp:Label   ID="lblType" runat="server"   ></asp:Label>
                </td>
                
            </tr>

            <tr >
                <td  colspan="2">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" ClientIDMode="Static" GridLines="None" EnableEmbeddedSkins="True" >
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="EMPLOYEE_NAME" HeaderText="Employee" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="Category" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DATE_STRING" HeaderText="Dates" UniqueName="column3">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AVAIL_HRS" HeaderText="Hours Available" UniqueName="column4" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="HRS_USED" HeaderText="Hours Used" UniqueName="column5" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="VARIANCE"  HeaderText="Variance" UniqueName="column6" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                </telerik:GridBoundColumn>
                            </Columns>
                            
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <EditFormSettings>
                                <PopUpSettings ScrollBars="None" />
                            </EditFormSettings>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>      
        </table>
    <%--<webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />--%>
</asp:Content>
