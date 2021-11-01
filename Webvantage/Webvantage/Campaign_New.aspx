<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Campaign_New.aspx.vb" Inherits="Webvantage.Campaign_New"
    MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="ContentCampaign" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div style="padding:20px 0px 0px 0px;">
        <asp:TextBox ID="txtCmp_ID" runat="server" Visible="false" SkinID="TextBoxStandard"
            TabIndex="-1"></asp:TextBox>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:LinkButton ID="hlOffice" runat="server" CausesValidation="False" TabIndex="-1">Office:</asp:LinkButton>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="txtOffice" runat="server" SkinID="TextBoxCodeSmall" MaxLength="4"
                    TabIndex="10"></asp:TextBox>
                <asp:Label ID="InvalidOffice" CssClass="warning" Visible="false" Text="Invalid Office"
                    runat="server"></asp:Label>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:LinkButton ID="hlClient" runat="server" CausesValidation="False" TabIndex="-1">Client:</asp:LinkButton>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="txtClient" runat="server" CssClass="RequiredInput"
                    MaxLength="6" SkinID="TextBoxCodeSmall" TabIndex="20"></asp:TextBox>
                <asp:Label ID="InvalidClient" CssClass="warning" Visible="false" Text="Invalid Client"
                    runat="server"></asp:Label>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:LinkButton ID="hlDivision" runat="server" CausesValidation="False" TabIndex="-1">Division:</asp:LinkButton>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="txtDivision" runat="server" SkinID="TextBoxCodeSmall" MaxLength="6"
                    TabIndex="30"></asp:TextBox>
                <asp:Label ID="InvalidDivision" CssClass="warning" Visible="false"
                    Text="Invalid Division" runat="server"></asp:Label>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:LinkButton ID="hlProduct" runat="server" CausesValidation="False" TabIndex="-1">Product:</asp:LinkButton>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="txtProduct" runat="server" SkinID="TextBoxCodeSmall" MaxLength="6"
                    TabIndex="40"></asp:TextBox>
                <asp:Label ID="InvalidProduct" CssClass="warning" Visible="false" Text="Invalid Product"
                    runat="server"></asp:Label>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:Label ID="lblCmp" runat="server" Text="Campaign:"></asp:Label>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="txtCampaignCode" runat="server" CssClass="RequiredInput"
                    MaxLength="6" SkinID="TextBoxCodeSmall" TabIndex="50"></asp:TextBox>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtCampaignCodeDesc" runat="server" CssClass="RequiredInput" SkinID="TextBoxStandard"
                    MaxLength="60" Width="450px" TabIndex="60"></asp:TextBox>
                <asp:Label ID="InvalidCampaign" CssClass="warning" Visible="false"
                    Text="Campaign is required." runat="server"></asp:Label>
                <asp:Label ID="InvalidCampaignDesc" CssClass="warning" Visible="false"
                    Text="Description is required." runat="server"></asp:Label>
            </div>
        </div>

        <div class="code-description-container">
            <div class="code-description-label">
                Alert Group:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="DDAlertGrp" runat="server" SkinID="RadComboBoxStandard"
                    TabIndex="70">
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Campaign Type:
            </div>
            <div class="code-description-description">
                <asp:RadioButtonList runat="server" ID="rbType" RepeatColumns="2" TabIndex="80">
                    <asp:ListItem Text="Assigned to Jobs and Orders" Value="2" Selected="True"> 
                    </asp:ListItem>
                    <asp:ListItem Text="Overall" Value="1"> 
                    </asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
                <asp:Button ID="butCreateJob" runat="server" Text="Create Campaign"
                    CausesValidation="False" TabIndex="71" />
                &nbsp;&nbsp;
                <asp:Button ID="butCancel" runat="server" CausesValidation="False"
                    Text="Cancel" TabIndex="72" />
            </div>
        </div>
    </div>
</asp:Content>
