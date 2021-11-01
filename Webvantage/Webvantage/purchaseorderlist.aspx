<%@ Page AutoEventWireup="false" CodeBehind="purchaseorderlist.aspx.vb" Inherits="Webvantage.purchaseorderlist"
    Title="Find Purchase Order" Language="vb" MasterPageFile="~/ChildPage.Master" %>

<%@ Register Src="purchaseorder_search.ascx" TagName="purchaseorder_search" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <telerik:RadTabStrip ID="RadTabStripAR" runat="server" AutoPostBack="True" CausesValidation="False"
        Width="100%">
        <Tabs>
            <telerik:RadTab ID="TabAll" runat="server" NavigateUrl="purchaseorderlist.aspx?Tab=1"
                Text="Search">
            </telerik:RadTab>
            <telerik:RadTab ID="TabMy" runat="server" NavigateUrl="purchaseorderlist_emp.aspx?Tab=2"
                Text="My Purchase Orders">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <table width="100%" border="0" cellspacing="2" cellpadding="0">
        <tr>
            <td width="250" align="left" valign="top">
                <uc1:purchaseorder_search ID="POpanel1" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
            </td>
            <td align="left" valign="top">
                <telerik:RadToolBar ID="RadToolBarPurchaseOrderList" runat="server" AutoPostBack="True"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="Search" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New" Value="New" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Clear" Value="Clear" ToolTip="Clear" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
                <telerik:RadGrid ID="RadGridPurchaseOrderSearch" runat="server" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                    PageSize="10" EnableEmbeddedSkins="True">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom">
                    </PagerStyle>
                    <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                    <ClientSettings AllowColumnsReorder="False">
                    </ClientSettings>
                    <GroupingSettings GroupByFieldsSeparator=" " />
                    <MasterTableView HorizontalAlign="Left">
                        <Columns>
                            <telerik:GridTemplateColumn>
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ibtn_po" runat="server" AlternateText="Purchase Order" CausesValidation="false"
                                            CommandName="Select" SkinID="ImageButtonViewWhite" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <div id="DivPrint" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonPrint" runat="server" CommandName="Print" SkinID="ImageButtonPrintWhite" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonCopy" runat="server" CommandName="Copy" SkinID="ImageButtonCopyWhite" ToolTip="Copy" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="PO Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblPONumber" runat="server" Text='<%#Eval("DISPLAY_PO_NUMBER").ToString%>'></asp:Label>
                                    <asp:HiddenField ID="hfPONumber" runat="server" Value='<%#Eval("PO_NUMBER").ToString%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="PO Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblPODate" runat="server" Text='<%#Eval("PO_DATE").ToString%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Vendor Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblVNCode" runat="server" Text='<%#Eval("VN_CODE").ToString%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Vendor Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblVNName" runat="server" Text='<%#Eval("VN_NAME").ToString%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblPODescription" runat="server" Text='<%#Eval("PO_DESCRIPTION").ToString%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Due Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblPODueDate" runat="server" Text='<%#Eval("PO_DUE_DATE").ToString%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Issued By">
                                <ItemTemplate>
                                    <asp:Label ID="lblPOIssuedBy" runat="server" Text='<%#Eval("ISSUED_BY").ToString%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Match">
                                <ItemTemplate>
                                    <asp:Label ID="lblSearchCode" runat="server" Text='<%#Eval("SEARCH_CODE").ToString%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblPOStatus" runat="server" Text='<%#Eval("PO_APPROVAL_FLAG").ToString%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" UniqueName="TemplateColumn1"
                                HeaderText="Void">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background standard-red" runat="server" id="DivFlagColor">
                                        <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" ToolTip="Void" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <FilterItemStyle VerticalAlign="Top" Wrap="False" />
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
    <div style="display: none;">
        <asp:Button ID="BtnSearch" runat="server" Text="Search" Visible="true" TabIndex="-1" />
    </div>
</asp:Content>