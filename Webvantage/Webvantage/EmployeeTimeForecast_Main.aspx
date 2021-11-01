<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="EmployeeTimeForecast_Main.aspx.vb" Inherits="Webvantage.EmployeeTimeForecast_Main" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentEmployeeTimeForecast" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
        <script type="text/javascript">
            function ViewEmployeeTimeForecast(EmployeeTimeForecastOfficeDetailID) {
                __doPostBack("<%= RadGridEmployeeTimeForecastOfficeDetails.UniqueID %>", "EmployeeTimeForecastOfficeDetailID:" + EmployeeTimeForecastOfficeDetailID);
            }
        </script>
    </telerik:RadScriptBlock>
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecast" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonNew" runat="server" SkinID="RadToolBarButtonNew"
                    Text="New" Value="New" ToolTip="Create new Employee Time Forecast" />
                 <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />

                <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonComparisonDashboard" runat="server"
                    Text="Comparison Dashboard" Value="ComparisonDashboard"
                    ToolTip="Open Comparison Dashboard" />
                <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSettings" runat="server" SkinID="RadToolBarButtonSettings"
                    Text="Settings" Value="Settings" ToolTip="Open Employee Time Forecast Settings" />
                <telerik:RadToolBarButton ID="RadToolBarButtonFifthSeparator" runat="server" IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div class="more-info">
                <span style="white-space: nowrap; margin-right: 10px;">
                    Post Period:     
                    <telerik:RadComboBox ID="DropDownListPostPeriod" runat="server" AutoPostBack="true" Width="100"
                        DataTextField="Description" DataValueField="Code" SkinID="RadComboBoxOffice">
                    </telerik:RadComboBox>
                </span>
                <span style="white-space: nowrap; margin-right: 10px;">
                    Office:
                    <telerik:RadComboBox ID="DropDownListOffice" runat="server" AutoPostBack="true" Width="150"
                        DataTextField="Name" DataValueField="Code" SkinID="RadComboBoxOffice">
                    </telerik:RadComboBox>
                </span>
                <span style="white-space: nowrap;">
                    Employee:
                    <telerik:RadComboBox ID="DropDownListEmployee" runat="server" AutoPostBack="true"
                        Width="150" DataTextField="Name" DataValueField="Code" SkinID="RadComboBoxEmployee">
                    </telerik:RadComboBox>
                </span>
            </div>
            <telerik:RadGrid ID="RadGridEmployeeTimeForecastOfficeDetails" runat="server" AllowPaging="false"
                AllowSorting="true" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                ShowFooter="false" AutoGenerateColumns="false" Width="100%" PagerStyle-Visible="false">
                <MasterTableView DataKeyNames="EmployeeTimeForecastID, OfficeCode, RevisionNumber, AssignedToEmployeeCode">
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewEmployeeTimeForecast">
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
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeTimeForecastID"
                            HeaderText="ID" Visible="false">
                            <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# Eval("EmployeeTimeForecastID")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeTimeForecastDescription"
                            HeaderText="Description" SortExpression="Description">
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# Eval("Description")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeTimeForecastOfficeCode"
                            HeaderText="Office Code" Visible="false">
                            <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# Eval("OfficeCode")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeTimeForecastOfficeName"
                            HeaderText="Office" SortExpression="OfficeName">
                            <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# Eval("OfficeName")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeTimeForecastRevisionNumber"
                            HeaderText="Revision" SortExpression="RevisionNumber">
                            <HeaderStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Right" />
                            <ItemStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Right" />
                            <FooterStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <%# Eval("RevisionNumber")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeTimeForecastAssignedToEmployeeCode"
                            HeaderText="Assigned To User Code" Visible="false">
                            <HeaderStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# Eval("AssignedToEmployeeCode")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeTimeForecastAssignedToEmployeeName"
                            HeaderText="Assigned To" SortExpression="AssignedToEmployeeName">
                            <HeaderStyle Width="110" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle Width="110" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle Width="110" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# Eval("AssignedToEmployeeName")%>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeTimeForecastIsApproved"
                            HeaderText="Approved" SortExpression="IsApproved">
                            <HeaderStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                            <FooterStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <div id="DivIsApproved" runat="server" class="icon-background standard-green">
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
