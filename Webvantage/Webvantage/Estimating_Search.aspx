<%@ Page AutoEventWireup="false" CodeBehind="Estimating_Search.aspx.vb" Inherits="Webvantage.Estimating_Search"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Find Estimate" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="ContentEstSearch" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div >
        <telerik:RadToolBar ID="RadToolbarEstimateSearch" runat="server" AutoPostBack="True"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New" Value="New" ToolTip="New Estimate" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Clear" Value="Clear" ToolTip="Clear" />
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
                                    <div id="TrClient" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlClient" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtClient" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrDivision" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlDivision" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtDivision" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrProduct" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlProduct" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtProduct" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrEstimate" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlEst" runat="server" href="" TabIndex="-1">Estimate:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtEstimate" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrEstimateComponent" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlEstComp" runat="server" href="" TabIndex="-1">Component:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtEstimateComponent" runat="server" SkinID="TextBoxCodeLarge" MaxLength="3"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrJob" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlJob" runat="server" href="" TabIndex="-1">Job:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtJob" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrComponent" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlComponent" runat="server" href="" TabIndex="-1">Component:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtComponent" runat="server" SkinID="TextBoxCodeLarge" MaxLength="3"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrCampaign" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlCampaign" runat="server" href="" TabIndex="-1"><span>Campaign:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtCampaign" runat="server" Width="125" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>
                                        <div>
                                            <asp:CheckBox ID="cbClosedJobs" runat="server" Text='Show Closed/Archived Jobs?'
                                                AutoPostBack="true" />
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
            <telerik:RadGrid ID="RadGridEstimatingSearch" runat="server" AllowPaging="True" AllowSorting="False"
                AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                PageSize="10">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                <ClientSettings AllowColumnsReorder="False">
                </ClientSettings>
                <GroupingSettings GroupByFieldsSeparator=" " />
                <MasterTableView HorizontalAlign="Left" DataKeyNames="JOB_NUMBER, JOB_COMPONENT_NBR">
                    <Columns>
                        <telerik:GridTemplateColumn>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Estimate">
                            <ItemTemplate>
                                <asp:Label ID="lblEstNum" runat="server" Text='<%#Eval("ESTIMATE_NUMBER").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Est. Description">
                            <ItemTemplate>
                                <asp:Label ID="lblEstDesc" runat="server" Text='<%#Eval("EST_LOG_DESC").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Est. Component">
                            <ItemTemplate>
                                <asp:Label ID="lblEstComp" runat="server" Text='<%#Eval("EST_COMPONENT_NBR").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Est. Component Description">
                            <ItemTemplate>
                                <asp:Label ID="lblEstCompDesc" runat="server" Text='<%#Eval("EST_COMP_DESC").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Client">
                            <ItemTemplate>
                                <asp:Label ID="lblClientCode" runat="server" Text='<%#Eval("CL_CODE").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Division">
                            <ItemTemplate>
                                <asp:Label ID="lblDivisionCode" runat="server" Text='<%#Eval("DIV_CODE").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Product">
                            <ItemTemplate>
                                <asp:Label ID="lblProductCode" runat="server" Text='<%#Eval("PRD_CODE").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Job">
                            <ItemTemplate>
                                <asp:Label ID="lblJobNum" runat="server" Text='<%#Eval("JOB_NUMBER").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Job Component">
                            <ItemTemplate>
                                <asp:Label ID="lblJobComp" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Campaign">
                            <ItemTemplate>
                                <asp:Label ID="lblCampaign" runat="server" Text='<%#Eval("CMP_CODE").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
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
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
</asp:Content>
