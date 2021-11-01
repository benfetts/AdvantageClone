<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TrafficSchedule_CompletedCmt.aspx.vb" ValidateRequest="false"
    Inherits="Webvantage.TrafficSchedule_CompletedCmt" MasterPageFile="~/ChildPage.Master"
    Title="Completed Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<asp:Panel ID="PanelFunctionComments" runat="server" Width="100%">
    <table border="0" cellpadding="0" cellspacing="2" width="100%">
        <tr>
            <td align="left">
                Completed Comments
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtCompletedComments" runat="server" Height="250px" TabIndex="0" SkinID="TextBoxStandard"
                    TextMode="multiLine" Width="460px"></asp:TextBox>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="HFDateCompleted" runat="server" />
                <asp:HiddenField ID="HFPercentCompleted" runat="server" />
            </td>
        </tr>
    </table>
</asp:Panel>
<div class="bottom-buttons">
    <asp:Button ID="BtnSave" runat="server" TabIndex="0" Text="Save" />
    <asp:Button ID="BtnCancel" runat="server" TabIndex="0" Text="Cancel" />
</div>
</asp:Content>
