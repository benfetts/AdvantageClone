<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval.aspx.vb" Inherits="Webvantage.BillingApproval"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Billing Approval" %>

<asp:Content ID="ContentBillingApproval" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlockSignIn" runat="server">
        <script type="text/javascript">
            function capLock(e) {
                var radToolTip = $find("<%= RadToolTipCapsLock.ClientID %>");
                kc = e.keyCode ? e.keyCode : e.which;
                sk = e.shiftKey ? e.shiftKey : ((kc == 16) ? true : false);
                if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk)) {
                    //alert('caps on');
                    radToolTip.show();
                }
                else {
                    //alert('caps off');
                    radToolTip.hide();
                };
            };
        </script>
    </telerik:RadScriptBlock>
    <div style="padding: 40px 0px 0px 0px; background: white;">
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="HlEmployee" runat="server" TabIndex="-1" href="">Employee:</asp:HyperLink>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="TxtEmployeeCode" runat="server" CssClass="RequiredInput" MaxLength="6"
                    TabIndex="1" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Password:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TxtPassword" runat="server" CssClass="RequiredInput" MaxLength="20" ReadOnly="false" TabIndex="2" Text="" TextMode="Password" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                <telerik:RadToolTip ID="RadToolTipCapsLock" runat="server" HideEvent="FromCode" Position="BottomCenter" RenderMode="Classic"
                    Font-Size="Larger" Font-Bold="true" VisibleOnPageLoad="false" EnableShadow="false"
                    ShowEvent="FromCode" TargetControlID="TxtPassword">
                    <div style="padding-left: 8px; padding-right: 8px; padding-bottom: 8px;">
                        <h4>
                            <asp:Image ID="ImageWarning" runat="server" SkinID="ImageWarning" ImageAlign="AbsBottom" />
                            &nbsp;&nbsp;<strong>Caps Lock is on</strong></h4>
                        Having Caps Lock on may cause you to enter your password<br />
                        incorrectly.
                                        <br />
                        You should press Caps Lock to turn it off before entering your<br />
                        password.
                    </div>
                </telerik:RadToolTip>
            </div>
           <%-- <div id="divMayus" style="visibility: hidden">
                Caps Lock is on.
            </div>--%>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
                <asp:CheckBox ID="CheckBoxRemember" runat="server" Text="Remember" />
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-code">
                <asp:Button ID="BtnOK" runat="server" Text="OK" />
                &nbsp;&nbsp;
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClientClick="CloseThisWindow();" />
            </div>
        </div>
    </div>
</asp:Content>
