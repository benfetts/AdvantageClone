<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_job_comp_list.ascx.vb"
    Inherits="Webvantage.purchaseorder_job_comp_list" %>
<table style="width: 520px; height: 160px" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 692px" align="left">&nbsp;<table cellpadding="0" cellspacing="0" width="95%">
            <tr>
                <td style="width: 100px">
                    <telerik:RadComboBox ID="ddFunct" runat="server" Width="282px" Visible="false">
                        <Items>
                            <telerik:RadComboBoxItem Value="1" Text="All Approved Estimate Items"></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                </td>
                <td style="width: 100px"></td>
                <td style="width: 100px">
                    <asp:Button ID="btn_Close" runat="server" CausesValidation="False" Text="Close" />
                </td>
            </tr>
        </table>
        </td>
    </tr>
    <tr>
        <td style="width: 692px;" valign="top">&nbsp;<div style="width: 850px;">
            <asp:GridView ID="gvEstimateItems" runat="server" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,FNC_CODE,FNC_DESCRIPTION,EST_REV_QUANTITY,EST_REV_RATE,EST_REV_EXT_AMT,EST_REV_COMM_PCT,EXT_MARKUP_AMT,LINE_TOTAL,VENDOR_NAME,CL_CODE,DIV_CODE,PRD_CODE,USE_CPM,SEQ_NBR"
                AutoGenerateColumns="false" EmptyDataText="Select a Job, Component, and (optional) Function Code."
                Width="97%" Visible="false">
                <SelectedRowStyle BackColor="AliceBlue" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtn_select_prod" AlternateText="Add to Purchase Order." CommandName="Select"
                                ImageUrl="images/product.png" CausesValidation="false" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Est Nbr" DataField="ESTIMATE_NUMBER" />
                    <asp:BoundField HeaderText="Est Comp Nbr" DataField="EST_COMPONENT_NBR" />
                    <asp:BoundField HeaderText="Qte Nbr" DataField="EST_QUOTE_NBR" />
                    <asp:BoundField HeaderText="Rev Nbr" DataField="EST_REV_NBR" />
                    <asp:BoundField HeaderText="Function" DataField="FNC_DESCRIPTION" />
                    <asp:BoundField HeaderText="Qty" DataField="EST_REV_QUANTITY">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Rate" DataField="EST_REV_RATE" DataFormatString="{0:n}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Ext Amt" DataField="EST_REV_EXT_AMT" DataFormatString="{0:n}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Markup%" DataField="EST_REV_COMM_PCT">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Markup Amt" DataField="EXT_MARKUP_AMT" DataFormatString="{0:n}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Total" DataField="LINE_TOTAL" DataFormatString="{0:n}">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Use Vendor" DataField="VENDOR_NAME" />
                    <asp:BoundField HeaderText="PO Used(NET)" DataField="PO_EXIST_AMT" DataFormatString="{0:n}">
                        <ItemStyle Font-Italic="True" HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Balance(NET)" DataField="BALANCE" DataFormatString="{0:n}">
                        <ItemStyle Font-Italic="True" HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <HeaderStyle BackColor="LightSkyBlue" />
            </asp:GridView>
            <telerik:RadGrid ID="radGridEstimate" runat="server" AllowPaging="false" AllowSorting="True"
                AutoGenerateColumns="False" GridLines="Horizontal" ClientSettings-EnableClientKeyValues="true"
                GroupingSettings-GroupByFieldsSeparator="  " Width="825px" Height="185px" PageSize="12">
                <MasterTableView HorizontalAlign="Left" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,FNC_CODE,FNC_DESCRIPTION,EST_REV_QUANTITY,EST_REV_RATE,EST_REV_EXT_AMT,EST_REV_COMM_PCT,EXT_MARKUP_AMT,LINE_TOTAL,VENDOR_NAME,CL_CODE,DIV_CODE,PRD_CODE,USE_CPM,SEQ_NBR">
                    <Columns>
                        <telerik:GridTemplateColumn>
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ibtn_select_prod" AlternateText="Add to Purchase Order." CommandName="Select"
                                        SkinID="ImageButtonNewWhite" CausesValidation="false" runat="server" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Est Nbr">
                            <ItemTemplate>
                                <asp:Label ID="lblEstNbr" runat="server" Text='<%#Eval("ESTIMATE_NUMBER").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Est Comp Nbr">
                            <ItemTemplate>
                                <asp:Label ID="lblEstCompNbr" runat="server" Text='<%#Eval("EST_COMPONENT_NBR").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Qte Nbr">
                            <ItemTemplate>
                                <asp:Label ID="lblQteNbr" runat="server" Text='<%#Eval("EST_QUOTE_NBR").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Rev Nbr">
                            <ItemTemplate>
                                <asp:Label ID="lblRevNbr" runat="server" Text='<%#Eval("EST_REV_NBR").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Function">
                            <ItemTemplate>
                                <asp:Label ID="lblFunction" runat="server" Text='<%#Eval("FNC_DESCRIPTION").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Qty">
                            <ItemTemplate>
                                <asp:Label ID="lblQty" runat="server" Text='<%#Eval("EST_REV_QUANTITY").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Rate">
                            <ItemTemplate>
                                <asp:Label ID="lblRate" runat="server" Text='<%#Eval("EST_REV_RATE").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Ext Amt">
                            <ItemTemplate>
                                <asp:Label ID="lblExtAmt" runat="server" Text='<%#Eval("EST_REV_EXT_AMT").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Markup%">
                            <ItemTemplate>
                                <asp:Label ID="lblMarkupPerc" runat="server" Text='<%#Eval("EST_REV_COMM_PCT").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Markup Amt">
                            <ItemTemplate>
                                <asp:Label ID="lblMarkupAmt" runat="server" Text='<%#Eval("EXT_MARKUP_AMT").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("LINE_TOTAL").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Use Vendor">
                            <ItemTemplate>
                                <asp:Label ID="lblUseVendor" runat="server" Text='<%#Eval("VENDOR_NAME").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="PO Used(NET)">
                            <ItemTemplate>
                                <asp:Label ID="lblPOUsedNET" runat="server" Text='<%#Eval("PO_EXIST_AMT").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Balance(NET)">
                            <ItemTemplate>
                                <asp:Label ID="lblBalanceNET" runat="server" Text='<%#Eval("BALANCE").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                    <ExpandCollapseColumn Visible="False">
                        <HeaderStyle Width="19px" />
                    </ExpandCollapseColumn>
                    <PagerStyle Mode="NextPrevAndNumeric" />
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                </MasterTableView>
                <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                <AlternatingItemStyle VerticalAlign="Top" />
                <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                <ClientSettings>
                    <Scrolling AllowScroll="True" ScrollHeight="100%" />
                </ClientSettings>
                <GroupingSettings GroupByFieldsSeparator=" " />
            </telerik:RadGrid>
        </div>
        </td>
    </tr>
    <tr>
        <td style="width: 692px;" align="right">
            <table width="100%">
                <tr>
                    <td align="left" style="width: 60%">
                        <asp:LinkButton ID="lbtn_show_all" runat="server" CausesValidation="False">Show All</asp:LinkButton>
                    </td>
                    <td align="right" style="width: 100px"></td>
                </tr>
            </table>
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        </td>
    </tr>
</table>
<asp:Label ID="lbl_fn_code" runat="server" Visible="False"></asp:Label>
<asp:Label ID="lbl_component_nbr" runat="server" Text="-1" Visible="False"></asp:Label>
<asp:Label ID="lbl_job_number" runat="server" Text="-1" Visible="False"></asp:Label>