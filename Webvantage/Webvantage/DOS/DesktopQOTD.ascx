<%@ Control AutoEventWireup="false" CodeBehind="DesktopQOTD.ascx.vb" Inherits="Webvantage.DesktopQOTD"
    Language="vb" %>
<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="cc1" %>
<asp:DataList ID="DataList1" runat="server">
    <ItemTemplate>
        <table align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
            <tr>
                <td>
                    <em>
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("description") %>'></asp:Literal>
                    </em>
                    <br />
                    &nbsp;&nbsp;-&nbsp;<%# Eval("title") %>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
<asp:LinkButton ID="LinkButtonDisclaimer" runat="server" Text="Disclaimer" ToolTip="Disclaimer" OnClientClick="OpenRadWindow('','Disclaimer.aspx?disclaimer=0', 500, 500); return false;"></asp:LinkButton>
<asp:Literal ID="LitMSG" runat="server"></asp:Literal>
