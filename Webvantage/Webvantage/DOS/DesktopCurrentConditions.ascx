<%@ Control AutoEventWireup="false" CodeBehind="DesktopCurrentConditions.ascx.vb"
    Inherits="Webvantage.DesktopCurrentConditions" Language="vb" %>
<%@ Register Assembly="RssToolkit" Namespace="RssToolkit.Web.WebControls" TagPrefix="cc1" %>
<div class="DO-Container">
    Zip:
    <asp:TextBox ID="TxtZip" runat="server" MaxLength="7" SkinID="TextBoxCodeSmall"></asp:TextBox>
    <asp:ImageButton ID="BtnRefresh" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
    <br />
    <br />
    <div style="padding-left:15px;">
    <asp:Literal ID="LitMSG" runat="server"></asp:Literal></div>
</div>