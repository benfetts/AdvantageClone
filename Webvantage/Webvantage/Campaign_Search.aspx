<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Campaign_Search.aspx.vb"
    Title="Find Campaign" Inherits="Webvantage.Campaign_Search" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="dialogDiv"></div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div >
            <telerik:RadToolBar ID="RadToolbarCampaignSearch" runat="server" AutoPostBack="True"
                Width="100%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSearch" SkinID="RadToolBarButtonFind"
                        Text="Search" Value="Search" ToolTip="Search" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonNew" SkinID="RadToolBarButtonNew" Text="New"
                        Value="New" ToolTip="Add New" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonClear" SkinID="RadToolBarButtonClear" Text="Clear"
                        Value="Clear" ToolTip="Clear" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>
        </div>
        <div >
        </div>
        <div class="wrapper">
            <div id="DivFilter" runat="server" class="two-col-leftcolumn">
                <div class="" style="">
                    <div class="filter-card">
                        <div class="card-content" style="margin-bottom: 20px;">
                            <asp:Panel ID="PnlSearch" runat="server" DefaultButton="BtnSearch">
                                <div>
                                    <div>
                                        <div>
                                            <div>
                                                <asp:HyperLink ID="hlOffice" runat="server" href="" TabIndex="-1"><span>Office:</span></asp:HyperLink>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtOffice" runat="server" Width="125" MaxLength="4" SkinID="TextBoxStandard"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>
                                            <div>
                                                <asp:HyperLink ID="hlClient" runat="server" href="" TabIndex="-1"><span>Client:</span></asp:HyperLink>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtClient" runat="server" Width="125" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>
                                            <div>
                                                <asp:HyperLink ID="hlDivision" runat="server" href="" TabIndex="-1"><span>Division:</span></asp:HyperLink>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtDivision" runat="server" Width="125" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>
                                            <div>
                                                <asp:HyperLink ID="hlProduct" runat="server" href="" TabIndex="-1"><span>Product:</span></asp:HyperLink>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtProduct" runat="server" Width="125" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>
                                            <div>
                                                <asp:HyperLink ID="hlCampaignCode" runat="server" href="" TabIndex="-1"><span>Campaign:</span></asp:HyperLink>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtCampaignCode" runat="server" Width="125" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>
                                            <div>
                                                <asp:CheckBox ID="cbClosedCampaigns" runat="server" Text='Show Closed Campaigns?' />
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
                <telerik:RadGrid ID="RadGridCampaignSearch" runat="server" AllowPaging="True" AllowSorting="False"
                    AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                    PageSize="10" EnableEmbeddedSkins="True">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                    <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                    <ClientSettings AllowColumnsReorder="False">
                    </ClientSettings>
                    <GroupingSettings GroupByFieldsSeparator=" " />
                    <MasterTableView DataKeyNames="CMP_IDENTIFIER, CMP_CODE">
                        <Columns>
                            <telerik:GridTemplateColumn>
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" CommandArgument='<%#Eval("CMP_IDENTIFIER").ToString%>' />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="Campaign ID" SortExpression="CMP_IDENTIFIER"
                                DataField="CMP_IDENTIFIER">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Campaign Code" SortExpression="CMP_CODE" DataField="CMP_CODE">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="105" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="105" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Campaign Description" SortExpression="CMP_NAME"
                                DataField="CMP_NAME">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Client" SortExpression="CL_CODE" DataField="CL_CODE">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="55" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="55" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Division" SortExpression="DIV_CODE" DataField="DIV_CODE">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="55" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="55" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Product" SortExpression="PRD_CODE" DataField="PRD_CODE">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="55" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="55" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn Visible="false" DataField="CMP_IDENTIFIER">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="55" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="55" />
                            </telerik:GridBoundColumn>
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
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
