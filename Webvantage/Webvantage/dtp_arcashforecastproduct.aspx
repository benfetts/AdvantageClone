<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_arcashforecastproduct.aspx.vb" Inherits="Webvantage.dtp_arcashforecastproduct" %>

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

                var htmlcontent = styleStr + "<body>" + window["ARForcastRG"].outerHTML + "</body></html>";
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
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
          <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" OnClientClick="PrintRadGrid(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" />&nbsp;
                    <br/>
                </td>
            </tr>
        <tr>
            <td align="left">
                &nbsp;<asp:Label   ID="LblTitle" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="ARForcastRG" runat="server" AllowPaging="False" AllowSorting="True" ClientIDMode="Static" 
                    AutoGenerateColumns="False" EnableAJAX="false" GridLines="None" EnableEmbeddedSkins="True">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                    </PagerStyle>
                    <MasterTableView PageSize="10" Width="100%">
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Client" HeaderText="Client" UniqueName="column">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Division" HeaderText="Division" UniqueName="column">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Product" HeaderText="Product" UniqueName="column">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AvgDays" HeaderText="Avg. No. of Days" UniqueName="column1">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalARAmt" DataType="System.Decimal" HeaderText="Open AR Amount"
                                DataFormatString="{0:#,###.00}" UniqueName="column2">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Month1" HeaderText="M1" DataFormatString="{0:#,###.00}"
                                UniqueName="column3">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Month2" HeaderText="M2" DataFormatString="{0:#,###.00}"
                                UniqueName="column4">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Month3" HeaderText="M3" DataFormatString="{0:#,###.00}"
                                UniqueName="column5">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Month4" HeaderText="M4" DataFormatString="{0:#,###.00}"
                                UniqueName="column6">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <%--<webvantage:print_buttons id="Print_Buttons1" runat="server" />--%>
</asp:Content>
