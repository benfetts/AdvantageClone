<%@ Page AutoEventWireup="false" CodeBehind="TrafficSchedule_TaskComments.aspx.vb" ValidateRequest="false"
    MasterPageFile="~/ChildPage.Master" Title="Project Schedule Comments" Inherits="Webvantage.TrafficSchedule_TaskComments"
    Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Panel ID="PanelFunctionComments" runat="server" Width="100%">
        <div>
            Task Comments
        </div>
        <div>
            <asp:TextBox ID="TxtFunctionComments" runat="server" Height="60px" TabIndex="0" TextMode="multiLine" SkinID="TextBoxStandard"
                Width="460px"></asp:TextBox><asp:HiddenField ID="HiddenField1" runat="server" />
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelDueDateComments" runat="server" Width="100%">
        <div>
            Due Date Comments
        </div>
        <div>
            <asp:TextBox ID="TxtDueDateComments" runat="server" Height="60px" TabIndex="0" TextMode="multiLine" SkinID="TextBoxStandard"
                Width="460px"></asp:TextBox><asp:HiddenField ID="HfDueDateComments" runat="server" />
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelRevisionDateComments" runat="server" Width="100%">
        <div>
            Revision Date Comments
        </div>
        <div>
            <asp:TextBox ID="TxtRevisionDateComments" runat="server" Height="60px" TabIndex="0" SkinID="TextBoxStandard"
                TextMode="multiLine" Width="460px"></asp:TextBox><asp:HiddenField ID="HfRevisionDateComments"
                    runat="server" />
        </div>
    </asp:Panel>
    <div class="bottom-buttons">
        <asp:Button ID="BtnSave" runat="server" TabIndex="0" Text="Save" />
        &nbsp;
        <asp:Button ID="BtnCancel" runat="server" TabIndex="0" Text="Cancel" />
    </div>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
