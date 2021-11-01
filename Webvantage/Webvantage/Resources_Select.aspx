<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Resources_Select.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.Resources_Select" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
    <telerik:RadGrid ID="RadGridResources" runat="server" AllowMultiRowSelection="False"
        AllowPaging="False" AllowSorting="true" AutoGenerateColumns="False" EnableAJAX="False"
        EnableAJAXLoadingTemplate="False" EnableOutsideScripts="true" GroupingEnabled="true"
        ShowFooter="True" Visible="True" Width="99%">
        <ClientSettings EnablePostBackOnRowClick="true">
            <Selecting AllowRowSelect="true" EnableDragToSelectRows="True" />
        </ClientSettings>
        <MasterTableView GroupsDefaultExpanded="true" NoMasterRecordsText="No records found"
            DataKeyNames="">
            <Columns>
                <telerik:GridTemplateColumn UniqueName="ColSelect">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="20px" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20px" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                    <ItemTemplate>
                        <asp:LinkButton ID="LBtnSelect" runat="server" CommandName="SelectResource" CommandArgument='<%#Eval("RESOURCE_CODE")%>'>Select</asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="RESOURCE_CODE" HeaderText="Resource Code" UniqueName="ColRESOURCE_CODE">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="20px" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20px" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="RESOURCE_DESC" HeaderText="Description" UniqueName="ColRESOURCE_DESCRIPTION">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="120px" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120px" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="120px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PRIORITY" HeaderText="Priority" UniqueName="ColPRIORITY">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="40px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LAST_AD_NUMBER" HeaderText="Last Ad Number" UniqueName="ColLAST_AD_NUMBER">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="120px" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120px" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="120px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LAST_DATE" HeaderText="Last Date" UniqueName="ColLAST_DATE"
                    DataFormatString="{0:d}">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LAST_START_TIME" HeaderText="Last Start" UniqueName="ColLAST_START_TIME"
                    DataFormatString="{0:t}">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LAST_END_TIME" HeaderText="Last End" UniqueName="ColLAST_END_TIME"
                    DataFormatString="{0:t}">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </telerik:GridBoundColumn>
            </Columns>
            <RowIndicatorColumn Visible="False">
            </RowIndicatorColumn>
            <ExpandCollapseColumn Resizable="False" Visible="False">
            </ExpandCollapseColumn>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>