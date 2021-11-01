<%@ Page Title="Project Schedule Versions" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficScheduleVersion.aspx.vb" Inherits="Webvantage.TrafficScheduleVersion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarJobTrafficVersions" runat="server" AutoPostBack="false" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New"
                    Value="New" CommandName="New" ToolTip="Save the current Schedule as a new Version" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>

    <table width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridJobTrafficVersions" runat="server" AllowSorting="True" AutoGenerateColumns="False" Visible="True"
                    EnableViewState="true" AllowPaging="false" Width="100%" EnableAJAX="false" GridLines="None" ShowFooter="false" ShowHeader="True" EnableEmbeddedSkins="True">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
                    <MasterTableView Width="100%" DataKeyNames="ID">
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVersionSequenceNumber" DataField="VersionSequenceNumber"
                                SortExpression="VersionSequenceNumber" HeaderText="">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="18" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="18" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVersionName" DataField="VersionName" 
                                SortExpression="VersionName" HeaderText="Version Name">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVersionDescription" DataField="VersionComment"
                                SortExpression="VersionComment" HeaderText="Version Description">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </telerik:GridBoundColumn>
                            <telerik:GridCheckBoxColumn UniqueName="GridCheckBoxColumnVersionIsActive" DataField="VersionIsActive" HeaderText="Active" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="18" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="18" />
                            </telerik:GridCheckBoxColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEditJobTrafficVersion">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="25" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonEditJobTrafficVersion" runat="server" Text="Edit" ToolTip="Edit this version" CommandName="OpenEdit"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnApplyJobTrafficVersion">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="25" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonApplyJobTrafficVersion" runat="server" Text="Apply" ToolTip="Apply this version to current Project Schedule" CommandName="Apply"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" HeaderText="">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-delete">
                                    <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="Delete" AlternateText="Delete row"
                                        ToolTip="Delete row" ImageAlign="Top" SkinID="ImageButtonDeleteWhite" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
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
    <script>
        function RefreshWindow(WindowURL, ForceNewURL, OpenWindowIfNotFound) {
            console.log(WindowURL);
            console.log(ForceNewURL);
            console.log(OpenWindowIfNotFound);

            var masterTable = $find("<%= RadGridJobTrafficVersions.ClientID %>").get_masterTableView();
            masterTable.rebind();
        }
    </script>
</asp:Content>
