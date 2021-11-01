<%@ Page AutoEventWireup="false" CodeBehind="Estimating_QuickAdd.aspx.vb" Inherits="Webvantage.Estimating_QuickAdd"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td>
                <asp:Panel ID="PnlStandardRush" runat="server" Visible="false" Width="100%">
                    Job Due Date:&nbsp;&nbsp;<asp:Label   ID="LblJobDueDate" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    Today's Date:&nbsp;&nbsp;<asp:Label   ID="LblTodaysDate" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    Working Days:&nbsp;&nbsp;<asp:Label   ID="LblWorkingDays" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </td>
            <td align="right" valign="middle">
                <asp:Button ID="BtnAddTasks" runat="server"  Text="Add Functions" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" valign="top" style="padding-bottom: 5px;">
                <telerik:RadComboBox ID="DropPreset" runat="server" AutoPostBack="true" Width="250px" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
                <asp:RadioButtonList ID="RblStandardRush" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                    RepeatLayout="Flow" Visible="false">
                    <asp:ListItem Value="standard">Standard</asp:ListItem>
                    <asp:ListItem Value="rush">Rush</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>        
        <tr>
            <td align="center" colspan="2" valign="middle">
                <telerik:RadGrid ID="RadGridQuickAdd" runat="server" AllowMultiRowSelection="True"
                    AllowSorting="True" AutoGenerateColumns="False" enableajax="False" GridLines="None"
                    Width="100%" AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="false">
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ROWID">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="FNC_TYPE" HeaderText="Type" UniqueName="colFNC_TYPE" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" FilterControlWidth="30px" HeaderStyle-Width="30px">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRESET_DESC" HeaderText="Preset" UniqueName="colPRESET_DESC" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" FilterControlWidth="75%">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FNC_CODE" HeaderText="Function" UniqueName="colFNC_CODE" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" FilterControlWidth="75%">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FNC_DESCRIPTION" HeaderText="Description" UniqueName="colFNC_DESCRIPTION" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" FilterControlWidth="75%">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="SUPPLIED_BY" HeaderText="Supplied By" UniqueName="colSUPPLIED_BY" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="65px" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtSUPPLIED_BY" runat="server" ReadOnly="true"  SkinID="TextBoxStandard"
                                        MaxLength="10" Text='<%#Eval("SUPPLIED_BY") %>' Width="70px"></asp:TextBox>
                                    <asp:HiddenField ID="HfFunctionType" runat="server" Value='<%#Eval("FNC_TYPE") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="HRS_QTY" HeaderText="Qty/Hrs" UniqueName="colHRS_QTY" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtHRS_QTY" runat="server"  SkinID="TextBoxStandard"
                                        MaxLength="15" Text='<%#Eval("HRS_QTY") %>' Width="80px"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="NET_AMOUNT" HeaderText="Amount" UniqueName="colNET_AMOUNT" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtNET_AMOUNT" runat="server"  SkinID="TextBoxStandard"
                                        MaxLength="17" Text='<%#Eval("NET_AMOUNT") %>' Width="80px"></asp:TextBox>
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
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
