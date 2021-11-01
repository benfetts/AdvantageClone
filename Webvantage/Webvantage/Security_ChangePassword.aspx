<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Security_ChangePassword.aspx.vb"
    Inherits="Webvantage.Security_ChangePassword" MasterPageFile="~/ChildPage.Master"
    Title="Change Password" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentChangePassword" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function OnclientButtonClicking(sender, args) {
                var button = args.get_item();
                if (button.get_commandName() == 'Save') {
                    var tabstrip = $find("<%= RadTabStripChangePassword.ClientID%>");
                    var tab = tabstrip.findTabByValue('email');
                    if (tabstrip.get_selectedTab().get_index() == tab.get_index()) {
                        var emailaddr = document.getElementById("<%= TextBoxEmailAddress.ClientID%>").value;
                        var origaddr = document.getElementById("<%= HiddenFieldOriginalEmailAddress.ClientID %>").value;
                        var disablebutton = $find("<%= RadButtonDisableGoogleCalendarSync.ClientID%>");
                        if (disablebutton) {
                            if (emailaddr != origaddr && disablebutton.get_visible() == true) {
                                ////args.set_cancel(!confirm("Changing your email will require you to reauthorize Advantage Calendar Sync. Are you sure you want to continue?"));
                                radToolBarConfirm(sender, args, "Changing your email will require you to reauthorize Advantage OAuth2. Are you sure you want to continue?");
                            }
                        }                                         
                    }
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <div style="width: 100%; padding: 0px 0px 0px 0px;">            
        <div class="no-float-menu">
            <telerik:RadToolBar ID="RadToolBarChangePassword" runat="server" AutoPostBack="true"
                Width="100%" OnClientButtonClicking="OnclientButtonClicking">
                <Items>
                    <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" Text="" Value="Save" CommandName="Save" ToolTip="Save Password" SkinID="RadToolBarButtonSave" />
                    <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonClose" runat="server" Text="Close" Value="Close" CommandName="Close" ToolTip="Close" />
                    <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>
        </div>
        <div class="telerik-aqua-body">
            <telerik:RadTabStrip ID="RadTabStripChangePassword" runat="server" MultiPageID="RadMultiPageChangePassword" AutoPostBack="true" SelectedIndex="0" Width="100%">
                <Tabs>
<%--                    <telerik:RadTab Text="System">
                    </telerik:RadTab>--%>
                    <telerik:RadTab Text="AdAssist">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Billing Approval">
                    </telerik:RadTab>
                    <%--<telerik:RadTab Text="Quote Approval">
                    </telerik:RadTab>--%>
                    <telerik:RadTab Text="Email" Value="email">
                    </telerik:RadTab>
                    <telerik:RadTab Text="SugarCRM">
                    </telerik:RadTab>
                    <telerik:RadTab Text="ProofHQ">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Adobe Signature">
                    </telerik:RadTab>
                    <telerik:RadTab Text="VCC">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPageChangePassword" runat="server" SelectedIndex="0" Width="99%">
<%--                <telerik:RadPageView ID="RadPageViewSystem" runat="server" Width="99%">
                    <div>&nbsp;</div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                Old Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxSystemOldPassword" runat="server" Width="400px" TextMode="Password" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxSystemNewPassword" runat="server" Width="400px" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container" runat="server">
                            <div class="code-description-label-xxxl">
                                Confirm New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxSystemConfirmNewPassword" runat="server" Width="400px" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>                
                    <br />
                </telerik:RadPageView>--%>
                <telerik:RadPageView ID="RadPageViewAdAssist" runat="server">
                    <div>&nbsp;</div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                Old Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxAdAssistOldPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard" >
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxAdAssistNewPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container" runat="server">
                            <div class="code-description-label-xxxl">
                                Confirm New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxAdAssistConfirmNewPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div> 
                    <br />
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewBillingApproval" runat="server">
                    <div>&nbsp;</div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                Old Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxBillingApprovalOldPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard" >
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxBillingApprovalNewPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container" runat="server">
                            <div class="code-description-label-xxxl">
                                Confirm New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxBillingApprovalConfirmNewPassword" runat="server" Width="400px" SkinID="TextBoxStandard"
                                                TextMode="Password">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div> 
                    <br />
                </telerik:RadPageView>
                <%--<telerik:RadPageView ID="RadPageViewQuoteApproval" runat="server">
                    <div>&nbsp;</div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                Old Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxQuoteApprovalOldPassword" runat="server" Width="400px" TextMode="Password" >
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxQuoteApprovalNewPassword" runat="server" Width="400px" TextMode="Password">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container" runat="server">
                            <div class="code-description-label-xxxl">
                                Confirm New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxQuoteApprovalConfirmNewPassword" runat="server" Width="400px" TextMode="Password">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div>                 
                    <br />
                </telerik:RadPageView>--%>
                <telerik:RadPageView ID="RadPageViewEmail" runat="server">
                    <div>&nbsp;</div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                Email:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxEmailAddress" runat="server" Width="400px" SkinID="TextBoxStandard">
                                </asp:TextBox>
                                <asp:HiddenField ID="HiddenFieldOriginalEmailAddress" runat="server" />
                            </div>
                        </div>
                        <div ID="DivEmailOldPassword" runat="server" class="code-description-container" >
                            <div class="code-description-label-xxxl">
                                Old Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxEmailOldPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard" >
                                </asp:TextBox>
                            </div>
                        </div>
                        <div ID="DivEmailNewPassword" runat="server" class="code-description-container">
                            <div class="code-description-label-xxxl">
                                New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxEmailNewPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div ID="DivEmailConfirmNewPassword" runat="server" class="code-description-container">
                            <div class="code-description-label-xxxl">
                                Confirm New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxEmailConfirmNewPassword" runat="server" Width="400px" SkinID="TextBoxStandard"
                                                TextMode="Password">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div ID="DivGoogleOAuth2" runat="server" class="code-description-container">
                            <div class="code-description-label-xxxl">
                                &nbsp;
                            </div>
                            <div class="code-description-description">
                                <asp:Label ID="LabelGoogleCalendarSync" runat="server"></asp:Label>
                                <telerik:RadButton ID="RadButtonDisableGoogleCalendarSync" runat="server" ButtonType="LinkButton" Text="Disable" Visible="false"></telerik:RadButton>
                                <telerik:RadButton ID="RadButtonEnableGoogleCalendarSync" runat="server" ButtonType="LinkButton" Text="Enable" Visible="false"></telerik:RadButton>
                            </div>
                        </div>
                    </div>  
                    <br />
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewSugarCRM" runat="server">
                    <div>&nbsp;</div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                User Name:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxSugarCRMUserName" runat="server" Width="400px" SkinID="TextBoxStandard">
                                </asp:TextBox>
                                <asp:HiddenField ID="HiddenFieldOriginalSugarCRMUserName" runat="server" />
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                Old Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxSugarCRMOldPassword" runat="server" Width="400px" TextMode="Password"  SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxSugarCRMNewPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container" runat="server">
                            <div class="code-description-label-xxxl">
                                Confirm New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxSugarCRMConfirmNewPassword" runat="server" Width="400px" SkinID="TextBoxStandard"
                                                TextMode="Password">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div> 
                    <br />
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewProofHQ" runat="server">
                    <div>&nbsp;</div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                User Name:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxProofHQUserName" runat="server" Width="400px" MaxLength="100" SkinID="TextBoxStandard">
                                </asp:TextBox>
                                <asp:HiddenField ID="HiddenFieldOriginalProofHQUserName" runat="server" />
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                Old Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxProofHQOldPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard" >
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxProofHQNewPassword" runat="server" Width="400px" TextMode="Password" MaxLength="100" SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container" runat="server">
                            <div class="code-description-label-xxxl">
                                Confirm New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxProofHQConfirmNewPassword" runat="server" Width="400px" SkinID="TextBoxStandard"
                                    TextMode="Password" MaxLength="100">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div> 
                    <br />
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewAdobeSignature" runat="server">
                    <div>&nbsp;</div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                Old Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxAdobeSignatureOldPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard" >
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxAdobeSignatureNewPassword" runat="server" Width="400px" TextMode="Password" MaxLength="100" SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container" runat="server">
                            <div class="code-description-label-xxxl">
                                Confirm New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxAdobeSignatureConfirmNewPassword" runat="server" Width="400px" SkinID="TextBoxStandard"
                                    TextMode="Password" MaxLength="100">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div> 
                    <br />
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewVCC" runat="server">
                    <div>&nbsp;</div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                User Name:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxVCCUserName" runat="server" Width="400px" MaxLength="100" SkinID="TextBoxStandard">
                                </asp:TextBox>
                                <asp:HiddenField ID="HiddenFieldOriginalVCCUserName" runat="server" />
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                Old Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxVCCOldPassword" runat="server" Width="400px" TextMode="Password" SkinID="TextBoxStandard" >
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label-xxxl">
                                New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxVCCNewPassword" runat="server" Width="400px" TextMode="Password" MaxLength="100" SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container" runat="server">
                            <div class="code-description-label-xxxl">
                                Confirm New Password:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxVCCConfirmNewPassword" runat="server" Width="400px" SkinID="TextBoxStandard"
                                    TextMode="Password" MaxLength="100">
                                </asp:TextBox>
                            </div>
                        </div>
                    </div> 
                    <br />
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div>            
    </div>                
</asp:Content>
