<%@ Control AutoEventWireup="false" CodeBehind="DesktopAllProjects.ascx.vb" Inherits="Webvantage.DesktopAllProjects"
    Language="vb" %>
<%@ Register Src="~/UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div class="DO-ButtonHeader">
        <div style="padding: 12px 0px 0px 0px; float: left; width: 50%; text-align: left;">
            <asp:ImageButton ID="butPrint" runat="server" SkinID="ImageButtonPrint" />
            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
             <asp:ImageButton ID="butRefresh" runat="server"
                            SkinID="ImageButtonRefresh" ToolTip="Refresh" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label15" runat="server" Text="Search:" />
            
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:ImageButton ID="imgbtnSearch" runat="server"  SkinID="ImageButtonFind"  ToolTip="Search" />
        </div>
        <div style="padding: 12px 0px 0px 0px; float: right; width: 50%; text-align: right;">
            <telerik:RadComboBox ID="DropSort" runat="server" AutoPostBack="true" Visible="false" Width="200">
                <Items>
                    <telerik:RadComboBoxItem Value="default" Text="Default"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="CDP" Text="C/D/P"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="jobcomp" Text="Job/Comp"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="startdate" Text="Start Date"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="duedate" Text="Due Date"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="status" Text="Status"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="taskcount" Text="Open Tasks Count"></telerik:RadComboBoxItem>
                </Items>
            </telerik:RadComboBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
                       
        </div>
    </div>
    <div class="DO-Container">
        <telerik:RadGrid ID="ProjectRadGrid" runat="server" AllowPaging="True" AllowSorting="True"
            Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
            <MasterTableView AllowMultiColumnSorting="true" DataKeyNames="JobNo, JobCompNo">
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar">
                                <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image"
                                    SkinID="ImageButtonViewWhite" ToolTip="View Tasks" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="CDP" HeaderText="Client" UniqueName="column2">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="110" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="110" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="110" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="Project" UniqueName="column4" SortExpression="JobNo">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:LinkButton ID="ViewLinkButton" runat="server" Visible="true"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="StartDate" DataFormatString="{0:d}" HeaderText="Start Date"
                        UniqueName="column5">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DueDate" DataFormatString="{0:d}" HeaderText="Due Date"
                        UniqueName="column6">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Status" HeaderText="Status" UniqueName="column7">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AE" HeaderText="AE" UniqueName="column8">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TrafficCount" HeaderText="Open Tasks" UniqueName="column9">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                    </telerik:GridBoundColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
</div>

