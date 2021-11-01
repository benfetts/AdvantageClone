<%@ Page Title="Import Specs" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Estimating_ImportSpecs.aspx.vb" Inherits="Webvantage.Estimating_ImportSpecs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">

<telerik:RadScriptBlock ID="RadScriptBlockHeader" runat="server">
    <script type="text/javascript">

        /* Do not remove!! */
        function CallFunctionOnParentPage(functionName) {
            var oWindow = GetRadWindow();
            var callingWindow = oWindow.BrowserWindow.FindWindow('purchaseorder_dtl.aspx');
            if (callingWindow) {
                callingWindow.get_contentFrame().contentWindow[functionName](oWindow);
                oWindow.close();
            }
        }

    </script>
</telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <asp:RadioButton ID="rbSelectQuote" runat="server" Text="Select Version" GroupName="Specs"
                    AutoPostBack="true" />
                <asp:RadioButton ID="rbSelectCategories" runat="server" Text="Select Categories/View Specs"
                    GroupName="Specs" AutoPostBack="true" /><br />
                &nbsp;&nbsp;<asp:Label   ID="lblSpecs" runat="server" Text="Select Categories/View Specs:"></asp:Label>
            </td>
        </tr>
        <asp:Panel ID="pnlSelectQuote" runat="server">
            <tr>
                <td align="center" valign="middle">
                    <telerik:RadGrid ID="RadGridSpecs" runat="server" AllowMultiRowSelection="false"
                        AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
                        Width="100%">
                        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                        <ClientSettings EnablePostBackOnRowClick="False">
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                        </ClientSettings>
                        <MasterTableView>
                            <Columns>
                                <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="SPEC_VER" HeaderText="Spec Version" UniqueName="colSPEC_VER">
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SPEC_REV" HeaderText="Spec Revision" UniqueName="colSPEC_REV">
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SPEC_TYPE_CODE" HeaderText="Spec Type" UniqueName="colSPEC_TYPE_CODE">
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SPEC_VER_DESC" HeaderText="Spec Version Description"
                                    UniqueName="colSPEC_VER_DESC">
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
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
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlSelectCategories" runat="server">
            <tr>
                <td>
                    <table align="center" border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="left" valign="top" width="136px" height="300px">
                                <telerik:RadListBox ID="lbSpecs" runat="server" Width="136px" Height="300px" SelectionMode="Multiple"
                                    AutoPostBack="true">
                                </telerik:RadListBox>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtSpecs" runat="server" TextMode="MultiLine" Height="300px" Width="530px" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </asp:Panel>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
    <div class="centered">
        <asp:Button ID="SaveButton" runat="server" Text="Select" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
    </div>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
