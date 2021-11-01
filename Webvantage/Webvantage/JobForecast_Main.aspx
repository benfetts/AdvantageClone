<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="JobForecast_Main.aspx.vb" Inherits="Webvantage.JobForecast_Main" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentEmployeeTimeForecast" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockMain" runat="server">
        <script type="text/javascript">
            function RebindGrid() {
                $find('<%= RadGridJobForecasts.ClientID %>').get_masterTableView().rebind();
            }
        </script>
    </telerik:RadScriptBlock>
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolBarJobForecast" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonNew" runat="server" SkinID="RadToolBarButtonNew"
                    Text="New" Value="New" ToolTip="Create new Job Forecast" />
                  <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSettings" runat="server" SkinID="RadToolBarButtonSettings"
                    Text="Settings" Value="Settings" ToolTip="Open Job Forecast Settings" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
                <telerik:RadToolBarButton ID="RadToolbarButtonRefresh" runat="server" SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh" />
                <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <div class="more-info" ID="SearchDiv" runat="server">
                    <asp:label ID="LabelMonthYear" runat="server" AssociatedControlID="RadMonthYearPicker" Text="Include Forecasts as of:" />
                        <telerik:RadMonthYearPicker ID="RadMonthYearPicker" runat="server" AutoPostBack="true"></telerik:RadMonthYearPicker>
                    &nbsp;&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxEmployee" runat="server" AutoPostBack="true"
                        Width="150" DataTextField="Name" DataValueField="Code" Label="Assigned To:" SkinID="RadComboBoxEmployee">
                    </telerik:RadComboBox>
                </div>
                            <telerik:RadGrid ID="RadGridJobForecasts" runat="server" AllowPaging="True"
                                AllowSorting="true" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                                ShowFooter="false" AutoGenerateColumns="false" Width="100%" PagerStyle-Visible="True">
                                <MasterTableView DataKeyNames="JobForecastID, JobForecastRevisionID, AssignedToEmployeeCode">
                                    <PagerStyle AlwaysVisible="true" Mode="NextPrevAndNumeric" />
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewJobForecast">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonView" runat="server" SkinID="ImageButtonViewWhite"
                                                    ToolTip="Click to View" CommandName="View" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobForecastID"
                                            HeaderText="ID" Visible="false">
                                            <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <%# Eval("JobForecastID")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobForecastDescription"
                                            HeaderText="Description" SortExpression="Description">
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("Description")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn UniqueName="GridBoundColumnPostPeriodStartDate" HeaderText="Start" DataField="PostPeriodStartDate" DataType="System.DateTime" DataFormatString="{0:MMMM yyyy}">
                                            <ItemStyle Wrap="false" Width="25" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTo" HeaderText="" AllowSorting="false" ReadOnly="true">
                                            <ItemStyle HorizontalAlign="Center" Width="10" />
                                            <ItemTemplate>
                                                -
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn UniqueName="GridBoundColumnPostPeriodStartDate" HeaderText="End" DataField="PostPeriodEndDate" DataType="System.DateTime" DataFormatString="{0:MMMM yyyy}">
                                            <ItemStyle Wrap="false" Width="25" /></telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobForecastRevisionNumber"
                                            HeaderText="Revision" SortExpression="RevisionNumber">
                                            <HeaderStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <ItemStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <FooterStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <%# Eval("RevisionNumber")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobForecastAssignedToEmployeeCode"
                                            HeaderText="Assigned To User Code" Visible="false">
                                            <HeaderStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%# Eval("AssignedToEmployeeCode")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobForecastAssignedToEmployeeName"
                                            HeaderText="Assigned To" SortExpression="AssignedToEmployeeName">
                                            <HeaderStyle Width="110" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="110" Wrap="false" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="110" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                    <%# Eval("AssignedToEmployeeName")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobForecastIsApproved"
                                            HeaderText="Approved" SortExpression="IsApproved">
                                            <HeaderStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <ItemStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <FooterStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <div id="DivIsApproved" runat="server" class="icon-background standard-green" style='<%# If(Eval("IsApproved") = True, "display:inline-block;", "display:none;") %>'>
                                                    <asp:Image ID="ImageIsApproved" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
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
    </div>
    
</asp:Content>
