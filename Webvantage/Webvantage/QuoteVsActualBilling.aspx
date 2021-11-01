<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QuoteVsActualBilling.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.QuoteVsActualBilling"
    Title="Quote Vs Actual Billing" EnableViewState="True" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
        <telerik:RadTabStrip ID="BillingTabs" runat="server" AutoPostBack="True" CausesValidation="False"
                Width="100%">
                <Tabs>
                    <telerik:RadTab ID="Tab2" runat="server" Text="Root Tab">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        <div style="margin-top: 5px;max-width: 100%!important;width: 100%;margin: auto;float: left;display: inline-block;text-align: center;">
            <telerik:RadToolBar ID="RadToolbarQvA" runat="server" AutoPostBack="true" Width="100%">
                <Items>
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" CausesValidation="true"
                        CommandName="Export" Value="Export" Hidden="False" ToolTip="Export" />
                </Items>
            </telerik:RadToolBar>
        </div>
            
            <table id="Table4" align="center" cellpadding="0" cellspacing="2" width="100%">
                <tr>
                    <td align="center">
                        <telerik:RadGrid ID="RadTabStrip_Billing" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            enableoutsidescripts="True" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                             PageSize="50" ShowFooter="true">
                            <PagerStyle Mode="NextPrevAndNumeric" />
                            <ExportSettings FileName="QvA_Summary" IgnorePaging="True" OpenInNewWindow="True">
                                <Pdf PageTitle="QvA_Billing" Title="QvA_Billing" />
                            </ExportSettings>
                            <MasterTableView CommandItemDisplay="Top" HorizontalAlign="Left" DataKeyNames="AR_INV_NBR,AR_INV_SEQ" NoMasterRecordsText="" NoDetailRecordsText="">
                                <CommandItemTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:Label   ID="lblJob" runat="server" Text="Job:"></asp:Label>
                                                <asp:Label   ID="lblJobNumber" runat="server"></asp:Label>&nbsp;/&nbsp;
                                                <asp:Label   ID="lblJobComp" runat="server" Text="Job Comp:"></asp:Label>
                                                <asp:Label   ID="lblJobCompNum" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </CommandItemTemplate>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="AR_INV_NBR" HeaderText="Invoice Number"
                                        UniqueName="AR_INV_NBR">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AR_TYPE" HeaderText="Invoice Type"
                                        UniqueName="AR_TYPE">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AR_INV_DATE" DataFormatString="{0:d}" HeaderText="Invoice Date"
                                        UniqueName="AR_INV_DATE">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AR_POST_PERIOD" HeaderText="Posting Period"
                                        UniqueName="AR_POST_PERIOD">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_hrs_billed" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Hours Billed" UniqueName="cc_hrs_billed">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_net_amt_billed" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Net Amount Billed"
                                        UniqueName="cc_net_amt_billed">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_markup_billed" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Markup Amount Billed"
                                        UniqueName="cc_markup_billed">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_advance_refrained" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Retained Advance Amount"
                                        UniqueName="cc_advance_refrained">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_actual_billed" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Actual Amount Billed"
                                        UniqueName="cc_actual_billed">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_resale_billed" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Resale Tax Billed"
                                        UniqueName="cc_resale_billed">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_total_billed" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Total Billed" UniqueName="cc_total_billed">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PaidAmount" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Paid Amount" UniqueName="cc_Paid">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnDocuments">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <div id="DivDocuments" runat="server" class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonDocuments" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Icons/White/256/documents_empty.png" CssClass="icon-image" ToolTip="Invoice Documents" />
                                            </div>          
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <FilterItemStyle VerticalAlign="Middle" Wrap="False" />
                                <ExpandCollapseColumn Visible="False" Resizable="False">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                            </MasterTableView>
                            <AlternatingItemStyle VerticalAlign="Middle" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                            <ClientSettings>
                                <Scrolling AllowScroll="false" ScrollHeight="100%" />
                            </ClientSettings>
                            <GroupingSettings GroupByFieldsSeparator=" " />
                            <FooterStyle />
                        </telerik:RadGrid>
                        <asp:Label   ID="lblMsg" runat="server"  CssClass="warning"></asp:Label>
                    </td>
                </tr>
            </table>
            <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    </div>
    
</asp:Content>
