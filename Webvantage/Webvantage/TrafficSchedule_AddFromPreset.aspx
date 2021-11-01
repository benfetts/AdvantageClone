<%@ Page AutoEventWireup="false" CodeBehind="TrafficSchedule_AddFromPreset.aspx.vb" Title="Project Schedule - Add From Preset" MasterPageFile="~/ChildPage.Master"
    Inherits="Webvantage.TrafficSchedule_AddFromPreset" Language="vb" %>

<asp:Content ID="ContentTrafficSchedule" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <table align="center" border="0" cellpadding="0" cellspacing="0" height="100" width="365">
        <tr>
            <td align="right" valign="middle" width="180">&nbsp;</td>
            <td width="5">&nbsp;</td>
            <td width="180">&nbsp;</td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <telerik:RadComboBox ID="DropPreset" runat="server" TabIndex="4" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnAddPresets" runat="server" CausesValidation="False"
                    TabIndex="5" Text="Add" />
        </tr>
        <tr>
            <td align="center" colspan="3" valign="middle">
                <asp:Label ID="LblMSG" runat="server" Text="&nbsp;"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" valign="middle">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
