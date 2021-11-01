<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QuoteVsActualDetail.aspx.vb"
    Inherits="Webvantage.QuoteVsActualDetail" EnableViewState="True" MasterPageFile="~/ChildPage.Master"
    Title="Quote Vs Actual Detail" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
        <telerik:RadTabStrip ID="DetailTabs" runat="server" AutoPostBack="True" CausesValidation="False"
                Width="100%">
                <Tabs>
                    <telerik:RadTab ID="Tab2" runat="server" Text="Root Tab">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        <div style="margin-top: 5px;max-width: 100%!important;width: 100%;margin: auto;float: left;display: inline-block;text-align: center;">
            <telerik:RadToolBar ID="RadToolbarQvA" runat="server" AutoPostBack="true" Width="100%">
                <Items>            
                    <telerik:RadToolBarButton ID="RadToolbarButtonSalesTax" Text="Resale Tax" CommandName="SalesTax" ToolTip="Show Sales Tax" Value="SalesTax" Group="SalesTax"
                        AllowSelfUnCheck="true" CheckOnClick="true"  />
                    <telerik:RadToolBarButton IsSeparator="true" /> 
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" CausesValidation="true"
                        CommandName="Export" Value="Export" Hidden="False" ToolTip="Export" /> 
                </Items>
            </telerik:RadToolBar>
        </div>
            
            <table id="Table4" align="center" cellpadding="0" cellspacing="2" width="100%">
                <tr>
                    <td align="center">
                        <telerik:RadGrid ID="RadGrid_Detail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            EnableOutsideScripts="True" GridLines="None" GroupingEnabled="true"
                            PageSize="50" ShowFooter="True" MasterTableView-ShowGroupFooter="True" GroupingSettings-RetainGroupFootersVisibility="True">
                            <PagerStyle Mode="NextPrevAndNumeric" />
                            <ExportSettings FileName="QvA_Detail" IgnorePaging="True" OpenInNewWindow="True">
                                <Pdf PageTitle="QvA_Detail" Title="QvA_Detail" />
                            </ExportSettings>
                            <MasterTableView CommandItemDisplay="Top" HorizontalAlign="Left" ExpandCollapseColumn-Visible="True" ShowGroupFooter="true" DataKeyNames="cc_actual_hrs,cc_est,cc_fnc_consolidationcode,cc_fnc_headingid,cc_fnc_desc,cc_fnc_type,cc_fnc_headingdesc,cc_fnc_consolidationname,cc_ar_inv_nbr,cc_ar_inv_seq,cc_rec_id,cc_ap_inv,cc_supplier_code,cc_ap_id" NoMasterRecordsText="" NoDetailRecordsText="">
                                <%--<GroupByExpressions>
                                    <telerik:GridGroupByExpression>
                                        <SelectFields>  
                                            <telerik:GridGroupByField FieldAlias="Type" FieldName="cc_fnc_name" FormatString="" 
                                                HeaderText=""/>
                                        </SelectFields>
                                        <GroupByFields>
                                            <telerik:GridGroupByField FieldName="cc_fnc_type" FieldAlias="cc_fnc_type" FormatString=""
                                                HeaderText=""/>
                                        </GroupByFields>
                                    </telerik:GridGroupByExpression>
                                    <telerik:GridGroupByExpression>
                                        <SelectFields>  
                                            <telerik:GridGroupByField FieldAlias="Function" FieldName="cc_group" FormatString=""
                                                HeaderText=""/>
                                        </SelectFields>
                                        <GroupByFields>
                                            <telerik:GridGroupByField FieldName="cc_group" FieldAlias="cc_group" FormatString=""
                                                HeaderText=""/>
                                        </GroupByFields>
                                    </telerik:GridGroupByExpression>
                                </GroupByExpressions>--%>
                                <CommandItemTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td align="left" width="50%">
                                                <asp:Label   ID="lblJob" runat="server" Text="Job:"></asp:Label>
                                                <asp:Label   ID="lblJobNumber" runat="server"></asp:Label><br />
                                                <asp:Label   ID="lblJobComp" runat="server" Text="Job Comp:"></asp:Label>
                                                <asp:Label   ID="lblJobCompNum" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btnExpand" runat="server" CommandName="Expand" Text="Collapse" />
                                            </td>
                                        </tr>
                                    </table>
                                </CommandItemTemplate>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Function Code" Visible="False"
                                        UniqueName="TemplateColumn">
                                        <ItemTemplate>
                                            <%# Eval("cc_fnc_code") %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="cc_fnc_desc" HeaderText="Function" UniqueName="cc_fnc_desc" Visible="false">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_fnc_type" HeaderText="Fnc Type"
                                        UniqueName="cc_fnc_type" Visible="false">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_fnc_headingdesc" HeaderText="Fnc Heading"
                                        UniqueName="cc_fnc_headingdesc" Visible="false">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_fnc_consolidationname" HeaderText="Fnc Consolidation"
                                        UniqueName="cc_fnc_consolidationname" Visible="false">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_date" DataFormatString="{0:d}" HeaderText="Date"
                                        UniqueName="cc_date">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_dve_field" HeaderText="Description/ Vendor/Employee"
                                        UniqueName="cc_dve_field">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_ref_invoice" HeaderText="Invoice / Description"
                                        UniqueName="cc_ref_invoice">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnDocumentsAP">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="DivDocumentsInvoice" runat="server" class="icon-background background-color-sidebar">
                                                <asp:LinkButton ID="LinkButtonDocumentsInvoice" runat="server" CssClass="icon-text"  ToolTip="Invoice documents">D</asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="cc_actual_hrs" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Hours/ Quantity"
                                        UniqueName="cc_actual_hrs">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_actual_amount" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Amount" UniqueName="cc_actual_amount">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_actual_mkp" DataFormatString="{0:#,##0.00}" 
                                        HeaderText="Markup/ Commission"
                                        UniqueName="cc_actual_mkp">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_actual_tax" DataFormatString="{0:#,##0.00}" 
                                        HeaderText="Tax" UniqueName="cc_actual_tax">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_actual_total" DataFormatString="{0:#,##0.00}"
                                        HeaderText="Total" UniqueName="cc_actual_total">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="cc_nonbill_flag" HeaderText="Non Billable">
                                        <HeaderStyle CssClass="radgrid-icon-column" Width="80px"/>
                                        <ItemStyle CssClass="radgrid-icon-column" Width="80px"/>
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="DivIsNonBillable" runat="server" class="icon-background standard-green">
                                                <asp:Image ID="ImageIsNonBillable" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="cc_open_po" DataFormatString="{0:#,##0.00}" HeaderText="Open P.O./ Net Amount"
                                        UniqueName="cc_open_po">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_billed" DataFormatString="{0:#,##0.00}" HeaderText="Billed/ To Date"
                                        UniqueName="cc_billed">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" Wrap="False" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_ar_inv_nbr" HeaderText="A/R/ Invoice"
                                        UniqueName="cc_ar_inv_nbr">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnDocumentsAR">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="DivDocumentsAR" runat="server" class="icon-background background-color-sidebar">
                                                <asp:LinkButton ID="LinkButtonDocumentsAR" runat="server" CssClass="icon-text" ToolTip="AR documents">D</asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="cc_adj_comment" HeaderText="Adjustment/ Description"
                                        UniqueName="cc_adj_comment">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cc_est" UniqueName="cc_est" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="cc_alert" HeaderText="">
                                        <HeaderStyle CssClass="radgrid-icon-column" Width="80px"/>
                                        <ItemStyle CssClass="radgrid-icon-column" Width="80px"/>
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                         <ItemTemplate>
                                            <div id="DivGoToTask" runat="server" class="icon-background background-color-sidebar">
                                                <asp:LinkButton ID="LinkButtonTask" runat="server" CssClass="icon-text" CommandName="GoToTask" ToolTip="Go to Task">T</asp:LinkButton>
                                            </div>
                                            <div id="DivGoToAssignment" runat="server" class="icon-background background-color-sidebar">
                                                <asp:LinkButton ID="LinkButtonAssignment" runat="server" CssClass="icon-text" CommandName="GoToAssignment" ToolTip="Go to Assignment">A</asp:LinkButton>
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
                            <FooterStyle />
                        </telerik:RadGrid>
                        <asp:Label   ID="lblMsg" runat="server"  CssClass="warning"></asp:Label>
                    </td>
                </tr>
            </table>
            <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    </div>
    
</asp:Content>
