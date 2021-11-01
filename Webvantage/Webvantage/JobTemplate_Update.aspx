<%@ Page Title="Update Job" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="JobTemplate_Update.aspx.vb" Inherits="Webvantage.JobTemplate_Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style>
        html {
            overflow: hidden !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
     <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
         <script type="text/javascript">
             function JsOnClientButtonClicking(sender, args) {
                 var comandName = args.get_item().get_commandName();

                 if (comandName == "UpdateAll") {
                     ////args.set_cancel(!confirm('Are you sure you want to update all jobs?'));
                     radToolBarConfirm(sender, args, "Are you sure you want to update all jobs?");
                 }
                 if (comandName == "Update") {
                     ////args.set_cancel(!confirm('Are you sure you want to update all selected jobs?'));
                     radToolBarConfirm(sender, args, "Are you sure you want to update all selected jobs?");
                 }
             }                        

         </script>
     </telerik:RadScriptBlock>
    <telerik:RadToolBar ID="RadToolBarUpdateJob" runat="server" AutoPostBack="true" OnClientButtonClicking="JsOnClientButtonClicking"
        Width="100%">
        <Items>
            <telerik:RadToolBarButton IsSeparator="True" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonUpdate" Text="Update All Job(s)" Value="UpdateAll" CommandName="UpdateAll"
                ToolTip="Update Job" CausesValidation="true" />
            <telerik:RadToolBarButton IsSeparator="True" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonUpdate" Text="Update Selected Job(s)" Value="Update" CommandName="Update"
                ToolTip="Update Job" CausesValidation="true" />
            <telerik:RadToolBarButton IsSeparator="True" />
        </Items>
    </telerik:RadToolBar>
    <div style="margin: 20px 0px 0px 0px;">
        <asp:Panel ID="PanelAE" runat="server">
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:LinkButton ID="hlAccountExecutive" runat="server" CausesValidation="False" TabIndex="-1">Account Executive:</asp:LinkButton>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="txtAccountExecutive" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                        TabIndex="3" Lookup="AccountExecutive"></asp:TextBox>
                </div>
                <div class="code-description-description">                    
                </div>
                <div class="code-description-label">
                </div>
                <div class="code-description-code">
                    <asp:CheckBox ID="CheckboxDefaultAE" runat="server" Text="Set as Default Account Executive for CDP" />
                </div>
                <div class="code-description-description">
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelAlertGroup" runat="server">
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:LinkButton ID="LinkButtonAlertGroup" runat="server" CausesValidation="False" TabIndex="-1">Alert Group:</asp:LinkButton>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TextBoxAlertGroup" runat="server" MaxLength="6" SkinID="TextBoxCodeSingleLineDescription" CssClass="RequiredInput"
                        TabIndex="3" Lookup="AlertGroup"></asp:TextBox>
                </div>
                <div class="code-description-description">                    
                </div>
                <div class="code-description-label">
                </div>
                <div class="code-description-code">
                    <asp:CheckBox ID="CheckboxDefaultAlertGroup" runat="server" Text="Set as Default Alert Group for CDP" />
                </div>
                <div class="code-description-description">
                </div>
            </div>
        </asp:Panel>
    </div> 
</asp:Content>
