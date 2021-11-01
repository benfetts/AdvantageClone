<%@ Page Title="Chat Room Log" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Chat_RoomViewAsLog.aspx.vb" Inherits="Webvantage.Chat_RoomViewAsLog" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="width:100%;">
        <telerik:RadGrid ID="RadGridChatRoomLog" runat="server" AllowMultiRowSelection="True" AllowSorting="True" AutoGenerateColumns="False" GridLines="None" ShowGroupPanel="False" Width="100%">
            <ClientSettings AllowColumnsReorder="False" AllowDragToGroup="False">
                <Resizing AllowColumnResize="True" EnableRealTimeResize="True" />
                <Selecting AllowRowSelect="False" />
            </ClientSettings>
            <ExportSettings IgnorePaging="true" OpenInNewWindow="true" ExportOnlyData="true" HideStructureColumns="true">
                <Pdf PageHeight="210mm" PageWidth="297mm" DefaultFontFamily="Arial Unicode MS" PageBottomMargin="20mm"
                    PageTopMargin="20mm" PageLeftMargin="20mm" PageRightMargin="20mm" />
            </ExportSettings>
            <MasterTableView AllowMultiColumnSorting="true" CommandItemDisplay="TopAndBottom" DataKeyNames="ID" Width="100%">
                <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" RefreshText="Refresh" ShowExportToExcelButton="true" ShowExportToWordButton="true" ShowExportToPdfButton="true" />
                <Columns>
                    <telerik:GridBoundColumn DataField="Message" HeaderText="Message" UniqueName="GridBoundColumnMessage">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle  />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UserCode" HeaderText="By" UniqueName="GridBoundColumnUserCode" >
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-usercode-column" Width="80" />
                        <ItemStyle Width="80" CssClass="radgrid-usercode-column" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="MessageDate" HeaderText="On" UniqueName="GridBoundColumnMessageDate" DataFormatString="{0:MM/dd/yy hh:mm tt}">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="right" CssClass="radgrid-datetime-column" Width="180" />
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="right" CssClass="radgrid-datetime-column" Width="180" />
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
</asp:Content>
