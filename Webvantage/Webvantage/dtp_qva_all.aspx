<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_qva_all.aspx.vb" Inherits="Webvantage.dtp_qva_all" %>

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

                var htmlcontent = styleStr + "<body>" + window["QVAAllRadGrid2"].outerHTML + "</body></html>";
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
    <div style="margin-left: 10px; margin-right: 10px;">
        <h4>
            <asp:Button ID="Button1" runat="server" OnClientClick="PrintRadGrid(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" />&nbsp;
                    <br/>
            <asp:Label ID="LabelObjectType" runat="server" Text="QvA"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="LabelReportType" runat="server" Text=""></asp:Label>
        </h4>
        <div style="display:block;height:6px;"></div>
        <telerik:RadGrid ID="QVAAllRadGrid2" runat="server" AllowPaging="false" AllowSorting="True" ClientIDMode="Static" 
            AutoGenerateColumns="False" EnableAJAX="True" GridLines="None" ItemStyle-VerticalAlign="Top"
            UseEmbeddedScripts="false" Width="100%">
            <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
            <MasterTableView>
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="colDetails">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("JOB_NUMBER") %>' />
                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("JOB_COMPONENT_NBR") %>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="CDP" HeaderText="Client" ItemStyle-VerticalAlign="Top"
                        UniqueName="column">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CMP_NAME" HeaderText="Campaign" ItemStyle-VerticalAlign="Top"
                        UniqueName="columnCamp">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JobAndComp" HeaderText="Project" ItemStyle-VerticalAlign="Top"
                        UniqueName="columnJob">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FIRST_USE_DATE" HeaderText="Due Date" DataFormatString="{0:d}"
                        UniqueName="DueDate">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="QUOTED_HRS" HeaderText="Quote Qty/Hrs" DataFormatString="{0:#,##0.00}"
                        UniqueName="QuoteHours">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ACTUAL_HRS" HeaderText="Actual Qty/Hrs" DataFormatString="{0:#,##0.00}"
                        UniqueName="ActualHours">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Quoted" HeaderStyle-HorizontalAlign="Right" HeaderText="Quote Total"
                        DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Top"
                        UniqueName="column3">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Actual" HeaderStyle-HorizontalAlign="Right" HeaderText="Actual Total"
                        DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Top"
                        UniqueName="column4">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PERCENT_QUOTED" HeaderText="% of Quote<br />(Hours)"
                        DataFormatString="{0:#,##0.00}" UniqueName="PercentOfQuoted">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PERCENT_QUOTED_AMT" HeaderText="% of Quote<br />(Amount)"
                        DataFormatString="{0:#,##0.00}" UniqueName="PercentOfQuotedAmt">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn UniqueName="Flag">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                                <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="Job" UniqueName="column5" Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JobComp" UniqueName="column6" Visible="false">
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
        <%--<webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />--%>
    </div>
</asp:Content>
