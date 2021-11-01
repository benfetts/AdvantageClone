<%@ Page AutoEventWireup="false" CodeBehind="Security_Group.aspx.vb" Inherits="Webvantage.Security_Group"
    Title="Group Security" Language="vb" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
            <tr>
                <td align="center">
                    <p>
                       Group:
                            <asp:TextBox ID="txtGroup" runat="server" MaxLength="50" Visible="False" SkinID="TextBoxStandard"></asp:TextBox>
                        <telerik:RadComboBox ID="ddGroups" runat="server" AutoPostBack="True" Width="200px">
                        </telerik:RadComboBox>
                        &nbsp;
                        <asp:Button ID="butSaveGroup" runat="server" Text="Save" Visible="False" /><br />
                        <br />
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="600">
                        <tr>
                            <td align="center" valign="top">
                                &nbsp;
                                <asp:Label   ID="lblUsers" runat="server" >Users</asp:Label><br />
                                <telerik:RadListBox ID="listUsers" runat="server" Height="250px" SelectionMode="Multiple"
                                    Width="250px"></telerik:RadListBox>
                            </td>
                            <td align="center" width="100">
                                &nbsp;<asp:ImageButton ID="imgbtnAdd" runat="server" SkinID="ImageButtonAdd" />&nbsp;<br />
                                <br />
                                <asp:ImageButton ID="imgbtnRemove" runat="server" SkinID="ImageButtonRemove" />
                            </td>
                            <td align="center" valign="top">
                                <asp:Label   ID="lblMembers" runat="server" >Group Members</asp:Label><br />
                                <telerik:RadListBox ID="listMember" runat="server" Height="250px" SelectionMode="Multiple"
                                    Width="250px"></telerik:RadListBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <asp:Button ID="butNewGroup" runat="server" Text="New Group" />&nbsp;
                    <asp:Button ID="butDeleteGroup" runat="server" Text="Delete Group" />&nbsp;
                    <asp:Button ID="butSave" runat="server" Text="Save Group" Visible="False" /><br />
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
