<%@ Page AutoEventWireup="false" CodeBehind="purchaseorderlist_emp.aspx.vb" Inherits="Webvantage.purchaseorderlist_emp"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="My Purchase Orders" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadTabStrip ID="RadTabStripAR" runat="server" AutoPostBack="True" CausesValidation="False"
        Width="100%">
        <Tabs>
            <telerik:RadTab ID="TabAll" runat="server" NavigateUrl="purchaseorderlist.aspx?Tab=1"
                Text="Search">
            </telerik:RadTab>
            <telerik:RadTab ID="TabMy" runat="server" NavigateUrl="purchaseorderlist.aspx?Tab=2"
                Text="My Purchase Orders">
            </telerik:RadTab>
        </Tabs>
</telerik:RadTabStrip>

    <div style="margin-top: 20px; margin-bottom: 10px;">
        <div class="form-layout label-3xl label-left">
            <ul>
                <li>Purchase Orders dated within:</li>
                <li><telerik:RadComboBox ID="dl_Days" runat="server" AutoPostBack="True" SkinID="RadComboBoxText15">
                        <Items>
                            <telerik:RadComboBoxItem Value="7" Text="Past Week"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Selected="True" Value="14" Text="Past 2 Weeks"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="30" Text="Past 30 Days"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="60" Text="Past 60 Days"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="90" Text="Past 90 Days"></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox></li>
            </ul>
            <ul>
                <li>Please Choose a Vendor:</li>
                <li><telerik:RadComboBox ID="dlVendors" runat="server" AutoPostBack="True" SkinID="RadComboBoxVendor">
                    </telerik:RadComboBox></li>
            </ul>
            <ul>
                <li></li>
                <li><span><asp:CheckBox ID="cbOmitVoid" runat="server" TextAlign="Left" AutoPostBack="true" />&nbsp;&nbsp;Omit Voided PO's</span><br />
                    <span><asp:CheckBox ID="cbOmitClosed" runat="server" TextAlign="Left" AutoPostBack="true" Checked="true" />&nbsp;&nbsp;Omit Closed PO's</span>
                </li>
            </ul>
        </div>
    </div>
    <div>
        <telerik:RadGrid ID="RadGridPurchaseOrderEmployeeList" runat="server" AllowPaging="True"
            AllowSorting="True" AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
            PageSize="15" Width="99%">
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
                    <telerik:GridTemplateColumn HeaderText="PO Number">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80px" />
                        <ItemTemplate>
                            <asp:Label   ID="lblPONumber" runat="server" Text='<%#Eval("PO_PAD").ToString%>'></asp:Label>
                            <asp:HiddenField ID="hfPONumber" runat="server" Value='<%#Eval("PO_NUMBER").ToString%>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="PO Date">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="65px" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="65px" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="65px" />
                        <ItemTemplate>
                            <asp:Label   ID="lblPODate" runat="server" Text='<%#Eval("PO_DATE").ToString%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Vendor Code">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="85px" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="85px" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="85px" />
                        <ItemTemplate>
                            <asp:Label   ID="lblVNCode" runat="server" Text='<%#Eval("VN_CODE").ToString%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Vendor Name">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label   ID="lblVNName" runat="server" Text='<%#Eval("VN_NAME").ToString%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Description">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label   ID="lblPODescription" runat="server" Text='<%#Eval("PO_DESCRIPTION").ToString%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Due Date">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="65px" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="65px" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="65px" />
                        <ItemTemplate>
                            <asp:Label   ID="lblPODueDate" runat="server" Text='<%#Eval("PO_DUE_DATE").ToString%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Total">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label   ID="lblPOTotal" runat="server" Text='<%#Eval("PO_TOTAL").ToString%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Status">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="55px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="55px" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="55px" />
                        <ItemTemplate>
                            <asp:Label   ID="lblPOStatus" runat="server" Text='<%#Eval("PO_APPROVAL_FLAG").ToString%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left"
                        UniqueName="TemplateColumn1" HeaderText="Void">
                        <ItemTemplate>
                            <div class="icon-background standard-red" runat="server" id="DivFlagColor">
                                <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" ToolTip="Void" />
                            </div>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left"  />
                        <ItemStyle HorizontalAlign="left"  VerticalAlign="Middle" />
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
        <asp:Label ID="lbl_vn_code" runat="server" Visible="False"></asp:Label>
    </div>

</asp:Content>
