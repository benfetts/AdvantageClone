<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreativeBrief_New.aspx.vb"
    Inherits="Webvantage.CreativeBrief_New" MasterPageFile="~/ChildPage.Master" Title="New Creative Brief" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body">
        <asp:Panel ID="pnlCBNew" runat="server">
                <div class="code-description-container" style="text-align: center">
                    <div class="code-description-label">
                       &nbsp;
                    </div>
                    <div class="code-description-description">
                        &nbsp;
                    </div>
                </div>
                <div class="code-description-container" style="text-align: center">
                    <div class="code-description-code">
                        Select a Template:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadComboBox ID="ddCBTemplates" runat="server" Width="400" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </div>
                </div>

                <div class="bottom-buttons">
                    <asp:Button ID="ButtonNewSave" runat="server" Text="Save" />&nbsp;&nbsp;
                    <asp:Button ID="ButtonNewCopy" runat="server" Text="Copy" />&nbsp;&nbsp;
                    <asp:Button ID="ButtonNewCancel" runat="server" Text="Cancel" OnClientClick="CloseThisWindow();" />
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlCBCopy" runat="server">
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlClientSource" runat="server" Text="Client:" href=""></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtClientSource" runat="server" MaxLength="6" TabIndex="1" Text=""
                            SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtClientSourceDesc" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlDivisionSource" runat="server" TabIndex="-1" Text="Division:"
                            href=""></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtDivisionSource" runat="server" MaxLength="6" TabIndex="2" Text=""
                            SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtDivisionSourceDesc" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlProductSource" runat="server" NavigateUrl="~/LookUp_Quick.aspx"
                            href="" TabIndex="-1" Text="Product:"></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtProductSource" runat="server" MaxLength="6" TabIndex="3" Text=""
                            SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtProductSourceDesc" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlJob" runat="server" TabIndex="-1" Text="Job:" href=""></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtJobNum" runat="server" MaxLength="6" TabIndex="4" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtJobDescription" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlComponent" runat="server" TabIndex="-1" Text="Component:" href=""></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtJobCompNum" runat="server" MaxLength="3" TabIndex="5" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtJobCompDescription" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                        <asp:HiddenField ID="hfContactCodeID" runat="server" />
                    </div>
                </div>
                <div class="bottom-buttons">
                    <asp:Button ID="ButtonCopySave" runat="server" Text="Save" />&nbsp;&nbsp;
                    <asp:Button ID="ButtonCopyNew" runat="server" Text="New" Visible="false" />&nbsp;&nbsp;
                    <asp:Button ID="ButtonCopyCancel" runat="server" Text="Cancel" />
                </div>
            </asp:Panel>
    </div>
    
</asp:Content>
