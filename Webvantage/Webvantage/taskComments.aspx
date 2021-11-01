<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="taskComments.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Task Completion Comments" Inherits="Webvantage.taskComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <textarea id="TextAreaComment" runat="server" style="width: 99%; height: 310px; min-height: 310px;
        overflow: hidden;" onkeyup="sz(this);"></textarea>
        <br />
    <asp:CheckBox ID="chkMarkCompleted" runat="server" Text="Mark Completed" Checked="true" />
    <asp:CheckBox ID="chkMarkNotCompleted" runat="server" Text="Mark Not Completed" />
    <div class="centered" style="padding-top: 3px;">
        <asp:Button ID="BtnSave" runat="server" Text="Save" />&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel"
            Text="Cancel" /></div>
</asp:Content>
