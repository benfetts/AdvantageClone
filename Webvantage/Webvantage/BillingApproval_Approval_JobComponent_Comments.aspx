<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_Approval_JobComponent_Comments.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.BillingApproval_Approval_JobComponent_Comments"
    Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                <asp:Panel ID="PanelApprovalComments" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="left" >
                                Approval Comments
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TxtApprovalComments" runat="server" Height="85px" TabIndex="0" TextMode="multiLine" SkinID="TextBoxStandard"
                                    Width="460px"></asp:TextBox>
                                <asp:HiddenField ID="HfApprovalComments" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="PanelClientComments" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="left" >
                                Client Comments
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TxtClientComments" runat="server" Height="85px" TabIndex="0" TextMode="multiLine" SkinID="TextBoxStandard"
                                    Width="460px"></asp:TextBox>
                                <asp:HiddenField ID="HfDueDateComments" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div align="center">
                    <asp:Button ID="BtnSave" runat="server" TabIndex="0" Text="Save" />
                    &nbsp;
                    <asp:Button ID="BtnCancel" runat="server" OnClientClick="window.close();return false;"
                        TabIndex="0" Text="Cancel" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
