<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popContactsAdd.aspx.vb"
    Inherits="Webvantage.popContactsAdd" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <telerik:RadToolBar ID="RadToolBarClient" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" Text="Save" Value="Save"
                    CommandName="Save" ToolTip="Save Contact" SkinID="RadToolBarButtonSave" />
                <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                    IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
        <table border="0" cellpadding="0" cellspacing="2" align="center">
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMSG" runat="server" CssClass="CssRequired"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Client:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBoxClient" runat="server" MaxLength="6" ReadOnly="true" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td rowspan="25" align="center" valign="top">
                    <telerik:RadGrid ID="RadGridDP" runat="server" AutoGenerateColumns="False" GridLines="None"
                        EnableEmbeddedSkins="True" AllowMultiRowSelection="true" Width="300px">
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="DIV_CODE,PRD_CODE">
                            <Columns>
                                <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="DIV_CODE" HeaderText="Code" UniqueName="colDIV_CODE"
                                    Visible="false" >
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="100" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="colDIV_NAME"
                                    >
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PRD_CODE" HeaderText="Code" UniqueName="colPRD_CODE"
                                    Visible="false" >
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="100" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="colPRD_DESCRIPTION"
                                    >
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                </telerik:GridBoundColumn>
                            </Columns>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Contact Code:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TextBoxContactCode" runat="server" MaxLength="6" CssClass="RequiredInput" SkinID="TextBoxStandard"
                        Width="200px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Contact Type:&nbsp;
                </td>
                <td>
                    <telerik:RadComboBox ID="RadComboBoxContactType" runat="server" AutoPostBack="false" Width="200px">
                        </telerik:RadComboBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    First Name:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="30" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    MI:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtMI" runat="server" MaxLength="1" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Last Name:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="30" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Title:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="40" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Email Address:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtEmailAddress" runat="server" MaxLength="50" Width="270px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Address 1:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" runat="server" MaxLength="40" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Address 2:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" runat="server" MaxLength="40" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    City:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" MaxLength="20" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    County:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtCounty" runat="server" MaxLength="20" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    State:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" MaxLength="10" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Zip:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server" MaxLength="10" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Country:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server" MaxLength="20" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Phone:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="13" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                    &nbsp;&nbsp;Ext:&nbsp;<asp:TextBox ID="txtPhoneExt" runat="server" MaxLength="5" SkinID="TextBoxStandard"
                        Width="50px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Fax:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtFax" runat="server" MaxLength="13" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                    &nbsp;&nbsp;Ext:&nbsp;<asp:TextBox ID="txtFaxExt" runat="server" MaxLength="5" Width="50px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    Cell:&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtCell" runat="server" MaxLength="13" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px" valign="top">
                    Comment:&nbsp;
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TextBoxComment" TextMode="MultiLine" runat="server" Width="270px" SkinID="TextBoxStandard"
                        Height="50px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    &nbsp;
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxScheduleUser" runat="server" Text="" />Schedule User
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    &nbsp;
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxCPUser" runat="server" Text="" AutoPostBack="true" />Client
                    Portal User
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxGetAlerts" runat="server" Text="" />Gets
                    Alerts<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxEmailRcpt" runat="server" Text="" />Email
                    Recipient
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    &nbsp;
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxInactive" runat="server" Text="" />Inactive
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 150px;" align="right" height="22px">
                    &nbsp;
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxCopyAddress" runat="server" Text="" AutoPostBack="true" />Copy Address from
                    Client<%--<br />
                           <asp:CheckBox id="CheckBoxCopyDivAddress" runat="server" Text="" ForeColor="White" />Copy Address from Division<br />
                           <asp:CheckBox id="CheckBoxCopyPrdAddress" runat="server" Text="" ForeColor="White" />Copy Address from Product--%></td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <br />
                    <br />
                    <asp:Button ID="BtnSave" runat="server" Text="Save" Visible="false"/>
                    &nbsp;&nbsp;
                    <asp:Button ID="BtnUpdate" runat="server" Text="Save" Visible="false" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="CloseThisWindow();" Visible="false" /><br />
                    <br />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
