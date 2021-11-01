<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_UserDefinedReports.aspx.vb"
    Inherits="Webvantage.Reporting_UserDefinedReports" Title="User Defined Reports"
    MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="ContentUserDefinedReports" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
     
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolBarUserDefinedReports" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton SkinId="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                    ToolTip="Bookmark" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server"
                    IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body" style="margin-top: 5px !important;">       
        <div class="more-info">
            Report Category:&nbsp;&nbsp;
            <telerik:RadComboBox ID="RadComboBoxReportCategory" runat="server" AutoPostBack="true"
                Width="50%" DataTextField="Description" DataValueField="ID">
            </telerik:RadComboBox>
        </div>
        <telerik:RadTabStrip ID="RadTabStripReports" runat="server" MultiPageID="RadMultiPageReports"
                AutoPostBack="true" SelectedIndex="0" Style="z-index: 1000;" Width="99%">
                <Tabs>
                    <telerik:RadTab Text="Advanced Report Writer">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Dynamic">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPageReports" runat="server" SelectedIndex="0" Width="100%">
                <telerik:RadPageView ID="RadPageViewARW" runat="server" Width="100%">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <telerik:RadGrid ID="RadGridARW" runat="server" AllowPaging="True" AllowSorting="True"
                            GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                            AutoGenerateColumns="False" Width="100%" AllowMultiRowSelection="false" AllowFilteringByColumn="True" >
                            <GroupingSettings CaseSensitive="false" />
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                            <ClientSettings Scrolling-AllowScroll="false" Resizing-AllowColumnResize="false">
                            </ClientSettings>
                            <MasterTableView DataKeyNames="ID">
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewReport" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonViewReport" runat="server" CommandName="ViewReport"
                                                    ToolTip="View Report" SkinID="ImageButtonViewWhite" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnID" DataField="ID" HeaderText="ID"
                                        ReadOnly="true" Visible="false" SortExpression="ID">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnReportCategoryID" DataField="ReportCategoryID"
                                        HeaderText="Report Category ID" ReadOnly="true" Visible="false" SortExpression="ReportCategoryID">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnReportCategory" DataField="ReportCategory" AllowFiltering="false" 
                                        HeaderText="Report Category" ReadOnly="true" Visible="true" SortExpression="ReportCategory">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnReportType" DataField="ReportType"
                                        HeaderText="Report Type" ReadOnly="true" Visible="false" SortExpression="ReportType">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDescription" DataField="Description" FilterControlWidth="200px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Description" ReadOnly="true" Visible="true" SortExpression="Description">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDatasetType" DataField="DatasetType" FilterControlWidth="200px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Dataset Type" ReadOnly="true" Visible="true" SortExpression="DatasetType">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnCreatedByUserCode" DataField="CreatedByUserCode" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Created By" ReadOnly="true" Visible="true" SortExpression="CreatedByUserCode">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                   <%-- <telerik:GridBoundColumn UniqueName="GridBoundColumnCreatedDate" DataField="CreatedDate" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Created Date" ReadOnly="true" Visible="true" SortExpression="CreatedDate" DataFormatString="{0:d}">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridDateTimeColumn UniqueName="GridBoundColumnCreatedDate" HeaderText="Created Date" FilterControlWidth="100px" FilterDelay="1250" CurrentFilterFunction="GreaterThanOrEqualTo"
                                        SortExpression="CreatedDate" DataField="CreatedDate" DataFormatString="{0:d}" AutoPostBackOnFilter="true">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                        <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnUpdatedByUserCode" DataField="UpdatedByUserCode" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Updated By" ReadOnly="true" Visible="true" SortExpression="UpdatedByUserCode">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn UniqueName="GridBoundColumnUpdatedDate" DataField="UpdatedDate" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Updated Date" ReadOnly="true" Visible="true" SortExpression="UpdatedDate" DataFormatString="{0:d}">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridDateTimeColumn UniqueName="GridBoundColumnUpdatedDate" HeaderText="Updated Date" FilterControlWidth="100px" FilterDelay="1250" CurrentFilterFunction="GreaterThanOrEqualTo"
                                        SortExpression="UpdatedDate" DataField="UpdatedDate" DataFormatString="{0:d}" AutoPostBackOnFilter="true">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnReportDefinition" DataField="ReportDefinition"
                                        HeaderText="Report Definition" ReadOnly="true" Visible="false" SortExpression="ReportDefinition">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                            </MasterTableView>
                        </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewDynamic" runat="server" Width="100%">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <telerik:RadGrid ID="RadGridDynamic" runat="server" AllowPaging="True" AllowSorting="True"
                            GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
                            AutoGenerateColumns="False" Width="100%" AllowMultiRowSelection="false" AllowFilteringByColumn="true">
                            <GroupingSettings CaseSensitive="false" />
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                            <ClientSettings Scrolling-AllowScroll="false" Resizing-AllowColumnResize="false">
                            </ClientSettings>
                            <MasterTableView DataKeyNames="ID, DatasetTypeID">
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewReport" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonViewReport" runat="server" CommandName="ViewReport"
                                                    ToolTip="Click to View Report" SkinID="ImageButtonViewWhite" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnID" DataField="ID" HeaderText="ID"
                                        ReadOnly="true" Visible="false" SortExpression="ID">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnReportCategoryID" DataField="ReportCategoryID"
                                        HeaderText="Report Category ID" ReadOnly="true" Visible="false" SortExpression="ReportCategoryID">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnReportCategory" DataField="ReportCategory" AllowFiltering="false"
                                        HeaderText="Report Category" ReadOnly="true" Visible="true" SortExpression="ReportCategory">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnReportType" DataField="ReportType"
                                        HeaderText="Report Type" ReadOnly="true" Visible="false" SortExpression="ReportType">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDescription" DataField="Description" FilterControlWidth="200px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Description" ReadOnly="true" Visible="true" SortExpression="Description">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDatasetType" DataField="DatasetType" FilterControlWidth="200px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Dataset Type" ReadOnly="true" Visible="true" SortExpression="DatasetType">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDatasetTypeID" DataField="DatasetTypeID"
                                        HeaderText="Dataset Type ID" ReadOnly="true" Visible="false" SortExpression="DatasetTypeID">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnCreatedByUserCode" DataField="CreatedByUserCode" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Created By" ReadOnly="true" Visible="true" SortExpression="CreatedByUserCode">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn UniqueName="GridBoundColumnCreatedDate" DataField="CreatedDate" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Created Date" ReadOnly="true" Visible="true" SortExpression="CreatedDate" DataFormatString="{0:d}">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridDateTimeColumn UniqueName="GridBoundColumnCreatedDate" HeaderText="Created Date" FilterControlWidth="100px" FilterDelay="1250" CurrentFilterFunction="GreaterThanOrEqualTo"
                                        SortExpression="CreatedDate" DataField="CreatedDate" DataFormatString="{0:d}" AutoPostBackOnFilter="true">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                        <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnUpdatedByUserCode" DataField="UpdatedByUserCode" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Updated By" ReadOnly="true" Visible="true" SortExpression="UpdatedByUserCode">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn UniqueName="GridBoundColumnUpdatedDate" DataField="UpdatedDate" FilterControlWidth="75px" FilterDelay="1250" CurrentFilterFunction="Contains"
                                        HeaderText="Updated Date" ReadOnly="true" Visible="true" SortExpression="UpdatedDate" DataFormatString="{0:d}">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridDateTimeColumn UniqueName="GridBoundColumnUpdatedDate" HeaderText="Updated Date" FilterControlWidth="100px" FilterDelay="1250" CurrentFilterFunction="GreaterThanOrEqualTo"
                                        SortExpression="UpdatedDate" DataField="UpdatedDate" DataFormatString="{0:d}" AutoPostBackOnFilter="true">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnReportDefinition" DataField="ReportDefinition"
                                        HeaderText="Report Definition" ReadOnly="true" Visible="false" SortExpression="ReportDefinition">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                            </MasterTableView>
                        </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
    </div>
    
</asp:Content>
