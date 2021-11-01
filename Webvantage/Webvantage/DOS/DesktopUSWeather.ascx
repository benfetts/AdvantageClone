<%@ Control AutoEventWireup="false" Codebehind="DesktopUSWeather.ascx.vb" Inherits="Webvantage.DesktopUSWeather"
    Language="vb" %>
Zip:  <asp:TextBox ID="TxtZip" runat="server"  Width="40px" MaxLength="5"></asp:TextBox>
<asp:ImageButton ID="BtnRefresh" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
<br />
<asp:Literal ID="LitData" runat="server"></asp:Literal>