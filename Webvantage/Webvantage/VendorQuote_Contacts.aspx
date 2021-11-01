<%@ Page AutoEventWireup="false" CodeBehind="VendorQuote_Contacts.aspx.vb" Inherits="Webvantage.VendorQuote_Contacts"
    MasterPageFile="~/ChildPage.Master" Title="Vendor Quote Contacts" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table border="0" cellpadding="0" cellspacing="2" align="center" width="100%">
        <tr>
            <td colspan="2">
                <h4>
                    Vendor Contact</h4>
            </td>
        </tr>
        <tr>
            <td align="right" width="140">
                Vendor:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtVendor" runat="server" MaxLength="6" ReadOnly="true" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Vendor Contact Code:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtVendorContactCode" runat="server" MaxLength="4" CssClass="RequiredInput" SkinID="TextBoxStandard"
                    Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Title:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" MaxLength="40" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                First Name:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="30" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                MI:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtMI" runat="server" MaxLength="1" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Last Name:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="30" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Email Address:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtEmailAddress" runat="server" MaxLength="50" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Address 1:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtAddress1" runat="server" MaxLength="40" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Address 2:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server" MaxLength="40" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                City:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" MaxLength="20" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                County:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtCounty" runat="server" MaxLength="20" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                State:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtState" runat="server" MaxLength="10" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Zip:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtZip" runat="server" MaxLength="10" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Country:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtCountry" runat="server" MaxLength="20" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Phone:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="13" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                &nbsp;&nbsp;Ext:&nbsp;<asp:TextBox ID="txtPhoneExt" runat="server" MaxLength="4" SkinID="TextBoxStandard"
                    Width="40px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Cell:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtCell" runat="server" MaxLength="13" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                Fax:&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtFax" runat="server" MaxLength="13" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                &nbsp;&nbsp;Ext:&nbsp;<asp:TextBox ID="txtFaxExt" runat="server" MaxLength="4" Width="40px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <telerik:RadGrid ID="RadGridContacts" runat="server" AllowMultiRowSelection="False"
                    AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
                    Width="98%" Visible="false">
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="VC_CODE">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="VC_CODE" HeaderText="Contact Code" UniqueName="colVC_CODE">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="100" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CONT_FULL_NAME" HeaderText="Name" UniqueName="colCONT_FULL_NAME">
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
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td>
            <asp:Button ID="BtnSave" runat="server" Text="Save" />
                <asp:Button ID="BtnUpdate" runat="server" Text="Update" Visible="false" />
                &nbsp;
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" /><br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMSG" runat="server" CssClass="CssRequired"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
