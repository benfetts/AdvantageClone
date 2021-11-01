<%@ Page AutoEventWireup="false" CodeBehind="Security_Reports.aspx.vb" Inherits="Webvantage.securityreportsbygroup"
    Language="vb" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
            <tr>
                <td align="center">
                   Group:
                    <telerik:RadComboBox ID="ddGroups" runat="server" AutoPostBack="True" Width="200px">
                    </telerik:RadComboBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="600">
                        <tr>
                            <td align="center" valign="top">
                               Allowed<br />
                               
                                <telerik:RadListBox ID="listAllow" runat="server" Height="250px" SelectionMode="Multiple"
                                    Width="250px"></telerik:RadListBox>
                            </td>
                            <td align="center" width="100">
                                <asp:Button ID="butToNotAllowed" runat="server" Text=">" Width="20px" Visible="false" />
                                <asp:ImageButton ID="imgbtnAdd" runat="server" SkinID="ImageButtonAdd" />
                                <br />
                                <br />
                                <asp:Button ID="butToAllow" runat="server" Text="<" Width="20px" Visible="false" />
                                <asp:ImageButton ID="imgbtnRemove" runat="server" SkinID="ImageButtonRemove" />
                            </td>
                            <td align="center" valign="top">
                               Blocked<br />
                               
                                <telerik:RadListBox ID="listNotAllowed" runat="server" Height="250px" SelectionMode="Multiple"
                                    Width="250px"></telerik:RadListBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <asp:Button ID="butSave" runat="server" Visible="false" Text="Save" />
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
