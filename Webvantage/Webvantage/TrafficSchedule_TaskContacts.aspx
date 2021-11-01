<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TrafficSchedule_TaskContacts.aspx.vb"
    Inherits="Webvantage.TrafficSchedule_TaskContacts" MasterPageFile="~/ChildPage.Master"
    Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">
        function SetDefaultHours(tb, df) {
            var thisTextbox = document.getElementById(tb);
            if (thisTextbox.value == "0.00")
                thisTextbox.value = df;
            thisTextbox.select();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="sub-header sub-header-color">
                <asp:Label   ID="LblHeader" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td width="50%">
                <span>Start Date:</span>&nbsp;&nbsp;
                <asp:Label   ID="LblStartDate" runat="server" Text=""></asp:Label>
            </td>
            <td width="50%">
                <span>Due Date:</span>&nbsp;&nbsp;
                <asp:Label   ID="LblDueDate" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <span>Time Due:</span>&nbsp;&nbsp;<asp:Label   ID="LblTimeDue" runat="server" Text=""></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" valign="middle">
                <asp:Button ID="BtnRefresh" runat="server" Text="Refresh" />&nbsp;
                <asp:Button ID="BtnUpdateContacts" runat="server" Text="Save" />
            </td>
        </tr>
    </table>
    <ew:CollapsablePanel ID="CollapsablePanelCurrentContacts" runat="server" TitleText="Current Contacts">
        <table cellpadding="0" cellspacing="2" border="0" width="100%">
            <tr>
                <td>
                    <telerik:RadGrid ID="RadGridTaskContacts" runat="server" AllowAutomaticDeletes="false"
                        AllowAutomaticInserts="false" AllowAutomaticUpdates="false" AutoGenerateColumns="false"
                        Width="100%">
                        <MasterTableView DataKeyNames="ID,CDP_CONTACT_ID" NoMasterRecordsText="No Records to Display">
                            <Columns>
                                <telerik:GridBoundColumn DataField="CONT_FML" HeaderText="Contact" UniqueName="colCONT_NAME">
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn Display="false" HeaderText="&nbsp;" UniqueName="colUpdateRow">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="imgbtnUpdateRow" runat="server" CommandName="UpdateRow" SkinID="ImageButtonSaveWhite"
                                                ToolTip="UpdateThisRow" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="colRemoveEmpFromTask">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-delete">
                                            <asp:ImageButton ID="imgbtnRemoveContactFromTask" runat="server" CommandName="RemoveContactFromTask"
                                                SkinID="ImageButtonDeleteWhite" ToolTip="Remove Contact from Task" />
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
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelAvailableContacts" runat="server" TitleText="Available Contacts">
        <table cellpadding="0" cellspacing="2" border="0" width="100%">
            <tr>
                <td>
                    <telerik:RadGrid ID="RadGridContactsList" runat="server" AllowAutomaticDeletes="false"
                        AllowAutomaticInserts="false" AllowAutomaticUpdates="false" AutoGenerateColumns="false"
                        Width="100%">
                        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                        <ClientSettings EnablePostBackOnRowClick="False">
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="CDP_CONTACT_ID" NoDetailRecordsText="No Records to Display"
                            NoMasterRecordsText="No Records To Display">
                            <Columns>
                                <telerik:GridBoundColumn DataField="CONT_FML" HeaderText="Contact" UniqueName="colCONT_NAME">
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="colAddContactToTask">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="imgbtnAddContactToTask" runat="server" CommandName="AddContactToTask"
                                                SkinID="ImageButtonNewWhite" ToolTip="Add Contact to Task" />
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
    </ew:CollapsablePanel>
</asp:Content>
