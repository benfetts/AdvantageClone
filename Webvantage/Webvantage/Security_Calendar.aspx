<%@ Page AutoEventWireup="false" CodeBehind="Security_Calendar.aspx.vb" Inherits="Webvantage.Security_Calendar"
    Language="vb" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
            <tr>
                <td align="center">
                    (View All Users in Calendar and have ability to add Holidays)
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="600">
                        <tr>
                            <td align="center" valign="top">
                               Blocked
                                <br />
                                <telerik:RadListBox ID="listNotAllowed" runat="server" Height="250px" SelectionMode="Multiple"
                                    Width="250px"></telerik:RadListBox>
                            </td>
                            <td align="center" width="100">
                                <p>
                                    <asp:Button ID="butToAllow" runat="server" Text=">" Width="20px" Visible="false" />
                                    <asp:ImageButton ID="imgbtnAdd" runat="server" SkinID="ImageButtonAdd" /></p>
                                <p>
                                    <asp:Button ID="butToNotAllowed" runat="server" Text="<" Width="20px" Visible="false" />
                                    <asp:ImageButton ID="imgbtnRemove" runat="server" SkinID="ImageButtonRemove" />
                                    <br />
                                    <br />
                                </p>
                            </td>
                            <td align="center" valign="top">
                               Allowed
                                <telerik:RadListBox ID="listAllow" runat="server" Height="250px" SelectionMode="Multiple"
                                    Width="250px"></telerik:RadListBox>
                                <br />
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
