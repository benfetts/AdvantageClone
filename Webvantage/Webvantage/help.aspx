<%@ Page AutoEventWireup="false" Codebehind="help.aspx.vb" Inherits="Webvantage.help" Language="vb" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain" EnableViewState="true">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
            <tr>
            <td align="left" class="MainContentCell" valign="top">
                <p>
                    &nbsp;</p>
                <div align="center">
                    <asp:HyperLink ID="hlHelp" runat="server" NavigateUrl="webhelp/Webvantage_Help.htm" Target="_blank">Open Help</asp:HyperLink>
                </div>
                <p>
                    &nbsp;</p>
            </td>
        </tr>
    </table>
</asp:Content>
