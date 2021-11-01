<%@ Page AutoEventWireup="false" CodeBehind="VendorQuote_Comments.aspx.vb" MasterPageFile="~/ChildPage.Master" ValidateRequest="false"
    Title="Vendor Quote Comments" Inherits="Webvantage.VendorQuote_Comments" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                <asp:Panel ID="PanelDetailComments" runat="server" Width="100%">
                    <div>
                        Comments
                    </div>
                    <div>
                        <asp:TextBox ID="TxtComments" runat="server" Height="400px" TabIndex="0" TextMode="multiLine" SkinID="TextBoxStandard"
                            Width="595px"></asp:TextBox><asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                    <div>
                        <asp:CheckBox ID="cbQuote" runat="server" Text="Use Quote Comments" AutoPostBack="true" />
                        <asp:CheckBox ID="cbFunction" runat="server" Text="Use Function Comments" AutoPostBack="true" />
                        <asp:CheckBox ID="cbEstimate" runat="server" Text="Use Estimate Comments" AutoPostBack="true" /><br />
                        <asp:CheckBox ID="cbComponent" runat="server" Text="Use Component Comments" AutoPostBack="true" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelNotesComments" runat="server" Width="100%" Visible="false">
                    <div>
                        Reply Notes
                    </div>
                    <div>
                        <asp:TextBox ID="TxtCom" runat="server" Height="200px" TabIndex="0" TextMode="multiLine" SkinID="TextBoxStandard"
                            Width="595px"></asp:TextBox><asp:HiddenField ID="HiddenField2" runat="server" />
                    </div>
                    <div>
                        Approval Notes
                    </div>
                    <div>
                        <asp:TextBox ID="TxtNotes" runat="server" Height="200px" TabIndex="0" TextMode="multiLine" SkinID="TextBoxStandard"
                            Width="595px"></asp:TextBox>
                    </div>
                </asp:Panel>
                <div class="bottom-buttons">
                    <asp:Button ID="BtnSave" runat="server" TabIndex="0" Text="Save" />
                    &nbsp; 
                    <asp:Button ID="BtnImportSpecs" runat="server" TabIndex="0" Text="Insert Specs" />
                    &nbsp;
                    <asp:Button ID="BtnCancel" runat="server" TabIndex="0" Text="Cancel" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
