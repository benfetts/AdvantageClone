<%@ Control AutoEventWireup="false" CodeBehind="DesktopWOTD.ascx.vb" Inherits="Webvantage.DesktopWOTD"
    Language="vb" %>
<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="cc1" %>
<script type="text/javascript">
</script>
<asp:DataList ID="DataList1" runat="server">
    <ItemTemplate>
        <h4>
            <%# Eval("title") %>
        </h4>
        <div>
            <asp:Literal ID="LitText" runat="server" Text='<%# Eval("description") %>'></asp:Literal><br />
            <asp:HyperLink ID="HlMore" runat="server" NavigateUrl='<%#Eval("link") %>' Target="_blank"
                Text="More..."></asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:DataList>
<asp:LinkButton ID="LinkButtonWotdDisclaimer" runat="server" Text="Disclaimer" ToolTip="Disclaimer" OnClientClick="OpenRadWindow('','Disclaimer.aspx?disclaimer=2', 500, 500); return false;"></asp:LinkButton>
<asp:Literal ID="LitMSG" runat="server"></asp:Literal>