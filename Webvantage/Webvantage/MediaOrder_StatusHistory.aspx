<%@ Page Title="Status History" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="MediaOrder_StatusHistory.aspx.vb" Inherits="Webvantage.MediaOrder_StatusHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin: 0px 0px 80px 0px;">
            <telerik:RadGrid ID="RadGridMediaStatus" runat="server" AllowFilteringByColumn="False" AllowPaging="False" AllowSorting="true" AllowMultiRowSelection="False"
                AutoGenerateColumns="False" EnableViewState="True" GroupPanelPosition="Top" ShowGroupPanel="False">
                <ItemStyle Wrap="false"></ItemStyle>
                <GroupingSettings CaseSensitive="false" />
                <ClientSettings AllowDragToGroup="False" AllowColumnsReorder="False">
                    <Scrolling SaveScrollPosition="true" />
                    <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
                </ClientSettings>
                <MasterTableView AllowMultiColumnSorting="true" Caption="" EnableHeaderContextMenu="true" HeaderStyle-VerticalAlign="Bottom"
                    DataKeyNames="OrderNumber, LineNumber, RevisionNumber, OrderStatusID, RevisedByName">                   
                    <Columns>  
                        <telerik:GridBoundColumn UniqueName="GridBoundColumnOrderStatusDescription" DataField="OrderStatusDescription" DataType="System.String" HeaderText="Status" AllowFiltering="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <FooterStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumnRevisedDate" DataField="RevisedDate" DataType="System.DateTime" HeaderText="Date" SortExpression="RevisedDate" AllowFiltering="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <FooterStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumnUser" DataField="RevisedByName" DataType="System.Int32" HeaderText="By" SortExpression="RevisedByUserCode" AllowFiltering="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <FooterStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumnOrderNumber" DataField="OrderNumber" DataType="System.Int32" HeaderText="Order" SortExpression="OrderNumber" AllowFiltering="false" Visible="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <FooterStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumnLineNumber" DataField="LineNumber" DataType="System.Int32" HeaderText="Line" SortExpression="LineNumber" AllowFiltering="false" Visible="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <FooterStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumnRevisionNumber" DataField="RevisionNumber" DataType="System.Int32" HeaderText="Revision" SortExpression="RevisionNumber" AllowFiltering="false" Visible="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <FooterStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
</asp:Content>
