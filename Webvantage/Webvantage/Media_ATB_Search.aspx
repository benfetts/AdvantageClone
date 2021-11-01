<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Media_ATB_Search.aspx.vb" Inherits="Webvantage.Media_ATB_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">

        <script type="text/javascript">
        </script>

    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolBar_ATBSearch" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" ToolTip="Search" Value="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" ToolTip="New" Value="New" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" ToolTip="Clear" Value="Clear" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <div id="DivFilter" runat="server" class="two-col-leftcolumn">
            <div class="" style="">
                <div class=" filter-card">
                    <div class="card-content" style="margin-bottom: 20px;">
                        <asp:Panel ID="PnlSearch" runat="server" DefaultButton="BtnSearch">
                            <div>
                                <div>
                                    <div id="TrClient" runat="server">
                                        <div><asp:HyperLink ID="HyperLink_Client" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Client" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrDivision" runat="server">
                                        <div><asp:HyperLink ID="HyperLink_Division" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Division" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrProduct" runat="server">
                                        <div><asp:HyperLink ID="HyperLink_Product" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Product" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrCampaign" runat="server">
                                        <div><asp:HyperLink ID="HyperLink_Campaign" runat="server" href="" TabIndex="-1">Campaign:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Campaign" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                            <asp:HiddenField ID="HiddenField_Campaign" runat="server" Value="" />
                                        </div>
                                    </div>
                                    <div id="TrATB" runat="server">
                                        <div><asp:HyperLink ID="HyperLink_ATB" runat="server" href="" TabIndex="-1">ATB Number:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_ATB" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrATBDescription" runat="server">
                                        <div>Description:
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_ATBDescription" runat="server" SkinID="TextBoxCodeLarge" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrShowClosed" runat="server">
                                        <div>
                                            <asp:CheckBox ID="CheckBoxShowClosed" runat="server" Text="Show Closed ATBs?" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="display: none;">
                                <asp:Button ID="BtnSearch" runat="server" Text="Search" Visible="true" TabIndex="-1" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
        <div id="DivGrid" runat="server" class="two-col-rightcolumn">
            <telerik:RadGrid ID="RadGrid_ATBSearch" runat="server" AllowPaging="True" AllowSorting="False"
                AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                PageSize="10">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                <ClientSettings AllowColumnsReorder="False">
                </ClientSettings>
                <GroupingSettings GroupByFieldsSeparator=" " />
                <MasterTableView HorizontalAlign="Left" DataKeyNames="ATBNumber">
                    <Columns>
                        <telerik:GridTemplateColumn>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButton_Detail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="ATB Number">
                            <ItemTemplate>
                                <asp:Label ID="Label_ATBNumber" runat="server" Text='<%#Eval("ATBNumber").ToString.PadLeft(6, "0")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="ATB Description">
                            <ItemTemplate>
                                <asp:Label ID="Label_Description" runat="server" Text='<%#Eval("Description").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Client">
                            <ItemTemplate>
                                <asp:Label ID="Label_Client" runat="server" Text='<%#Eval("ClientCode").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Division">
                            <ItemTemplate>
                                <asp:Label ID="Label_Division" runat="server" Text='<%#Eval("DivisionCode").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Product">
                            <ItemTemplate>
                                <asp:Label ID="Label_Product" runat="server" Text='<%#Eval("ProductCode").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Campaign">
                            <ItemTemplate>
                                <asp:Label ID="Label_Campaign" runat="server" Text='<%#Eval("CampaignCode")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
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
        </div>
    </div>
</asp:Content>
