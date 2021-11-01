<%@ Page AutoEventWireup="false" CodeBehind="popTime.aspx.vb" Inherits="Webvantage.popTime"
    MasterPageFile="~/ChildPage.Master" Title="Actual Hours" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <asp:Label   ID="LabelTime" runat="server"></asp:Label>
                <asp:ImageButton ID="butPrint" runat="server" SkinID="ImageButtonPrint" />
                <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridTime" runat="server" AutoGenerateColumns="False" GridLines="None"
                    EnableEmbeddedSkins="True">
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="EMP_DATE" HeaderText="Date" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EMP_HOURS" HeaderText="Hours" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="COMMENTS" HeaderText="Comment" UniqueName="column3">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <EditFormSettings>
                            <PopUpSettings ScrollBars="None" />
                        </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>
