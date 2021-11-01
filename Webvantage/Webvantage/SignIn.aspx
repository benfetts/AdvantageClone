<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SignIn.aspx.vb" Inherits="Webvantage.SignIn" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Aqua</title>
    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <link id="MaterialCSSLink" runat="server" type="text/css" rel="stylesheet" href="CSS/Material/Bootstrap.Cyan.min.css" />
    <link href="CSS/Common.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Jscripts/common.js"></script>
    <script type="text/javascript" src="Jscripts/UIHelper.js"></script>
    <script type="text/javascript" src="Scripts/jquery-3.6.0.min.js"></script>

    <link href="Content/kendo/current/kendo.common-bootstrap.min.css" rel="stylesheet"/>
    <link href="Content/kendo/current/kendo.bootstrap.min.css" rel="stylesheet"/>
    <link href="Content/ej/web/bootstrap-theme/ej.web.all.min.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.aspnetmvc.min.js"></script>
    <script type="text/javascript" src="Scripts/darkreader.js"></script>

    <telerik:RadCodeBlock ID="RadCodeBlockCSS" runat="server">
        <style type="text/css">
            html, body, form, #wrapper {
                height: 100%;
                width: 100%;
                margin: 0px 0px 0px 0px;
                padding: 0px;
                border: none;
                font-family: "Open Sans", Calibri, Tahoma, Verdana, Arial, sans-serif !important;
                font-size: 16px !important;
                <%= Me.BackgroundCSS %>
            }
            #wrapper {
                margin: 0 auto;
                height:100%;
                width:100%;
            }
            table.full-height {
                height:100%;
                width:100%;
            }
            #page-background {
                position:fixed; 
                top:0; 
                left:0; 
                width:100%; 
                height:100%;
                z-index:-9000;
            }
            .row {
                overflow: hidden;
                padding: 2px 0px 2px 0px;
                width: 99%;
            }
            .label {
                text-align: right; 
                float: left;
                width: 175px;
                padding: 0px 5px 0px 0px;
                vertical-align:middle;
                margin: 5px 0px 0px 0px;
            }
            .content {
                vertical-align:middle;
                float: left;
            }
            .llta {
                height: 75px;
                width: 253px;
            }
            .message-rad-window {
                color: #888888; 
                text-align: left; 
                vertical-align: top;
                height: 180px !important;
                width: 300px !important;
                padding-top: 16px !important;
            }
            .code-description-label {
                font-size: 16px !important;
            }
        </style>
    </telerik:RadCodeBlock>
    <telerik:RadScriptBlock ID="RadScriptBlockSignIn" runat="server">
        <script type="text/javascript">
            var signInWindow = $("<%= "#" & PanelSignIn.ClientID%>");
            var changePasswordWindow = $("<%= "#" & PanelChangePassword.ClientID%>");
            var lostPasswordWindow = $("<%= "#" & PanelLostPassword.ClientID%>");
            function showSignInWindow() {
                //console.log("showSignInWindow");
                if (signInWindow) {
                    signInWindow.show();
                }
                if (changePasswordWindow) {
                    changePasswordWindow.hide();
                }
                if (lostPasswordWindow) {
                    lostPasswordWindow.hide();
                }
                return false;
            }
            function refreshAdminWindow() {
                try {
                    var url = "";
                    url = document.getElementById('adminIframe').src;
                    if (url && url != "") {
                        //console.log("refreshAdminWindow URL", url);
                        document.getElementById('adminIframe').src = url;
                    }
                } catch (e) {
                    console.log("refreshAdminWindow error", e);
                }
            }
            function showChangePasswordWindow() {
                //console.log("showChangePasswordWindow");
                if (signInWindow) {
                    signInWindow.hide();
                }
                if (changePasswordWindow) {
                    changePasswordWindow.show();
                }
                if (lostPasswordWindow) {
                    lostPasswordWindow.hide();
                }
                return false;
            }
            function showLostPasswordWindow() {
                //console.log("showLostPasswordWindow");
                //if (signInWindow) {
                signInWindow.hide();
                //}
                //if (changePasswordWindow) {
                changePasswordWindow.hide();
                //}
                //if (lostPasswordWindow) {
                lostPasswordWindow.show();
                //}
                return false;
            }
            function ShowMessage(err_msg) {
                showKendoAlert(err_msg);
                ////err_msg = "<div class='message-rad-window'>" + err_msg + "</div>";
                ////var oAlert = radalert(err_msg, 420, 220, "", showMessageCallBack, null);
                ////window.setTimeout(function(){ 
                ////    oAlert.setActive(true);
                ////}, 1000);
                //alert(err_msg);
                ////////$("#dialog").html(err_msg);
                ////////window.setTimeout(function () {
                ////////    $("#dialog").ejDialog({
                ////////        contentType: '',
                ////////        title: 'Error',
                ////////        height: 200,
                ////////        width: 400,
                ////////        enableModal: true,
                ////////        enableResize: false, 
                ////////        footerTemplateId: 'showMessageFooter',
                ////////        showFooter: true,
                ////////        showHeader: true
                ////////    });
                ////////    $("#dialog").ejDialog("open");
                ////////},
                ////////200);
            }
            function showMessageOK() {
                $("#dialog").ejDialog("close");
            }
            function showMessageCancel() {
                $("#dialog").ejDialog("close");
            }
            function showKendoConfirm(content) {
                return $("<div></div>").kendoConfirm({
                    title: false,
                    content: content,
                    buttonLayout: 'normal',
                    close: function (e) {
                        this.wrapper.remove();
                    }
                }).data("kendoConfirm").open().result;
            }
            function showKendoAlert(content) {
                $("<div></div>").kendoAlert({
                    title: false,
                    content: content,
                    buttonLayout: 'normal'
                }).data("kendoAlert").open();
            }
            function showKendoPrompt(content, defaultValue) {
                return $("<div></div>").kendoPrompt({
                    title: false,
                    value: defaultValue,
                    content: content,
                    buttonLayout: 'normal'
                }).data("kendoPrompt").open().result;
            }
            function showMessageCallBack(arg) {
                console.log("showMessageCallBack", arg);
            }
            function ChangePassword(msg) {
                if (msg && msg != "") {
                    ShowMessage(msg);
                }
                __doPostBack('onclick#Refresh', 'ChangePassword');
            }
            function PasswordChanged() {
                __doPostBack('onclick#Refresh', 'PasswordChanged');
            }
            function PasswordChangedCancel() {
                __doPostBack('onclick#Refresh', 'PasswordChangedCancel');
            }
            function closeAdminWindow() {
                __doPostBack('onclick#CloseAdminWindow', 'CloseAdminWindow');
            }
            function UpperCaseTheText(textbox) {
                var tb = document.getElementById(textbox);
                tb.value = tb.value.toUpperCase();
            }
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
                }
            }
            function showPasswordLinks() {
                //console.log("showPasswordLinks")
                try {
                    var pwdIK = '<%= TextBoxUserID.ClientID%>'
                    var val = "";
                    if ($("#" + pwdIK)) {
                        val = $("#" + pwdIK).val();
                        if (val != "") {
                            $("#DivChangePassword").show();
                            //console.log("show")
                        } else {
                            $("#DivChangePassword").hide();
                            //console.log("hide")
                        }
                    }
                } catch (e) {
                    console.log("error", e);
                }
            }
            function OnClientShow(sender) {
                //console.log("OnClientShow", sender);
            }
            function setTextBoxFocus(object) {
                try {
                    if (object && object != null) {
                        if (object.value == null || object.value == '') {
                            object.focus();

                        }
                    }
                } catch (e) {
                }
            }
            function enableButton() {
            }
            function goToPage(page) {
                window.location.replace(page);
            }
            function disableButton(element) {
                element.disabled = 'disabled';
                __doPostBack("SignInNewApp", "SignInNewApp");
            }
            $(document).ready(function () {
                try {
                    var thisURL = "";
                    thisURL = window.top.location.href;
                    if (thisURL.toUpperCase().indexOf("SIGNIN.ASPX") == -1 && thisURL.toUpperCase().indexOf("?X=YZ") == -1) {
                        console.log("Sign in page opened in a tab or something.")
                        window.top.location.href = "SignIn.aspx?X=YZ";
                    }
                } catch (e) {
                }
                $("body").css("display", "none");
                $("body").fadeIn(750);
                window.setTimeout(function () {
                    showPasswordLinks();
                }, 500);
                showSignInWindow();
                $("html").keydown(function (event) {
                    if (event.keyCode == 80 && event.ctrlKey == true && event.altKey == true) {
                        //console.log("Show Admin Sign In!");
                        __doPostBack("admin", "admin");
                    }
                });
                //enableDarkMode();
                <%= Me.DarkModeScript %>
            });
        </script>
    </telerik:RadScriptBlock>
</head>
<body>
    <script id="showMessageFooter" type="text/x-jsrender">        
        <input type="button" name="showMessageOKButton" value="OK" onclick="showMessageOK()" id="showMessageOKButton"
            style="width: 398px; height: 41px !important;" class="rfdDecorated" tabindex="-1" />
    </script>
    <form id="FormSignIn" runat="server" autocomplete="off">
        <div id="page-background">
            <dx:ASPxImage ID="ASPxImageBackground" runat="server" ImageUrl="Images/Wallpaper/default_wallpaper.jpg"
                Width="100%" Height="100%">
            </dx:ASPxImage>
        </div>
        <telerik:RadScriptManager ID="RadScriptManagerSignIn" runat="server" 
            EnablePageMethods="true" EnableScriptGlobalization="true" AsyncPostBackTimeout="900" 
            EnablePartialRendering="true" EnableEmbeddedjQuery="false">
            <Scripts>
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadSkinManager ID="RadSkinManagerSignIn" runat="server" ShowChooser="False" Skin="Bootstrap">
            <TargetControls>
                <telerik:TargetControl ControlsToApplySkin="NotSet" />
            </TargetControls>
        </telerik:RadSkinManager>
        <telerik:RadAjaxManager ID="RadAjaxManagerSignIn" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadFormDecorator ID="RadFormDecoratorSignIn" runat="server" DecoratedControls="All"
            EnableRoundedCorners="false" EnableEmbeddedBaseStylesheet="true" EnableAjaxSkinRendering="true"
            EnableEmbeddedScripts="true" EnableEmbeddedSkins="true" />
        <table id="wrapper" align="center" border="0" cellpadding="0" cellspacing="0" class="full-height" height="100%" width="100%">
            <tr>
                <td align="center" valign="top" height="50px">
                    <br />
                    <asp:Image ID="ImageLogo" runat="server" AlternateText="blue" ImageAlign="Top" ImageUrl="Images/Logos/aqualogo_FFFFFF.png" onclick="__doPostBack('SignInNewApp','SignInNewApp');" title="Sign In to NewApp" style="cursor: pointer;" />
                </td>
            </tr>
            <tr>
                <td id="signInWindowsCell" runat="server" style="min-height: 440px; text-align:center; vertical-align:middle;">
                    <telerik:RadWindowManager ID="RadWindowManagerSignInPage" runat="server" RenderMode="Classic" Skin="Bootstrap" IconUrl="favicon.ico" ></telerik:RadWindowManager>
                    <asp:UpdatePanel runat="server" ID="UpdatePanelUserSummary" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="sign-in-container">
                                <div class="sign-in-header">
                                    <span style="margin-left: 8px;"><asp:Literal ID="LiteralSignInHeader" runat="server">Sign In</asp:Literal></span>
                                </div>
                                <div class="sign-in-content-container">
                                    <asp:Panel ID="PanelNoSSL" runat="server" Visible="false">
                                        <div style="width: 100%; text-align: center; margin-top: 165px;" title="SSL transport is required!">
                                            <h2>SSL REQUIRED</h2>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelSignIn" runat="server" DefaultButton="ButtonLogin" Visible="true">
                                        <div style="width: 100%; margin: 25px 0px 0px -20px">
                                            <div id="DivSqlServer" runat="server" class="code-description-container" title="Enter server name in text box.">
                                                <div class="code-description-label">
                                                    Server:
                                                </div>
                                                <div class="code-description-description">
                                                    <asp:TextBox ID="TextBoxSQLServer" runat="server" SkinID="TextBoxCodeSingleLineDescription" CssClass="k-textbox" style="height: 28px !important;"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="DivDatabase" runat="server" class="code-description-container" title="Enter database name in text box.">
                                                <div class="code-description-label">
                                                    Database:
                                                </div>
                                                <div class="code-description-description">
                                                    <asp:TextBox ID="TextBoxDataBase" runat="server" SkinID="TextBoxCodeSingleLineDescription" CssClass="k-textbox" style="height: 28px !important;"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="DivUserID" runat="server" class="code-description-container" title="Enter user ID in text box.">
                                                <div class="code-description-label">
                                                    User ID:
                                                </div>
                                                <div class="code-description-description">
                                                    <asp:TextBox ID="TextBoxUserID" runat="server" SkinID ="TextBoxCodeSingleLineDescription" CssClass="k-textbox" style="height: 28px !important;"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="DivPassword" runat="server" class="code-description-container" title="Enter password in text box.">
                                                <div class="code-description-label">
                                                    Password:
                                                </div>
                                                <div class="code-description-description">
                                                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" SkinID="TextBoxCodeSingleLineDescription" CssClass="k-textbox" style="height: 28px !important;"></asp:TextBox>
                                                    <telerik:RadToolTip ID="RadToolTipCapsLock" runat="server" HideEvent="FromCode" Position="BottomCenter" RenderMode="Classic"
                                                        Font-Size="Larger" Font-Bold="true" VisibleOnPageLoad="false" EnableShadow="false"
                                                        ShowEvent="FromCode" TargetControlID="TextBoxPassword">
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
                                            </div>
                                            <div id="DivTwoFactorEmail" runat="server" title="Two factor authentication is enabled.  You will need to enter an additional code to sign in.">
                                                <div class="code-description-container" style="padding-left: 62px; border: 0; text-align: left !important;">
                                                    An authentication code was sent to <asp:Label ID="LabelTwoFactorEmailAddress" runat="server" Text=""></asp:Label>.<br />
                                                    Please enter it below.
                                                </div>
                                                <div class="code-description-container" title="Enter authentication code below.">
                                                    <div class="code-description-label" style="margin: -2px;">
                                                        Authentication Code:
                                                    </div>
                                                    <div class="code-description-description">
                                                        <div>
                                                            <asp:TextBox ID="TextBoxTwoFactorEmailCode" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="5" Width="200px" CssClass="k-textbox" style="height: 28px !important;"></asp:TextBox>
                                                        </div>                                                    
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="DivTrusted" runat="server" class="code-description-container">
                                                <div class="code-description-label" style="margin: -2px;">
                                                    Use Trusted Connection:
                                                </div>
                                                <div class="code-description-description">
                                                    <asp:CheckBox ID="CheckBoxUseTrustedConnection" runat="server" Text="" />
                                                </div>
                                            </div>
                                            <div id="DivLanguage" class="code-description-container">
                                                <div class="code-description-label">
                                                    Locale:
                                                </div>
                                                <div class="code-description-description">
                                                    <telerik:RadComboBox ID="RadComboBoxLanguage" runat="server" Width="325" Skin="Bootstrap">
                                                        <Items>
                                                            <telerik:RadComboBoxItem Value="en-US" Text="English (US)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="en-GB" Text="English (UK)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="en-AU" Text="English (Australia)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="en-NZ" Text="English (New Zealand)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="en-IE" Text="English (Ireland)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="fr-FR" Text="français (French)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="fr-CA" Text="français (Canadian)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="es-ES" Text="español (Spain)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="es-MX" Text="español (Mexico)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="en-SG" Text="English (Singapore)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="zh-SG" Text="Simplified Chinese (Singapore)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="en-MY" Text="English (Malaysia)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="ms-MY" Text="Malay (Malaysia)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="id-ID" Text="Indonesian (Indonesia)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="fil-PH" Text="Filipino (Philippines)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="en-PH" Text="English (Republic of the Philippines)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="hi-IN" Text="Hindi (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="bn-IN" Text="Bengali (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="pa-IN" Text="Punjabi (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="gu-IN" Text="Gujarati (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="or-IN" Text="Oriya (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="ta-IN" Text="Tamil (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="te-IN" Text="Telugu (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="kn-IN" Text="Kannada (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="ml-IN" Text="Malayalam (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="as-IN" Text="Assamese (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="mr-IN" Text="Marathi (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="sa-IN" Text="Sanskrit (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="kok-IN" Text="Konkani (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="en-IN" Text="English (India)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="th-TH" Text="Thai (Thailand)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="zh-CN" Text="汉语/漢語 (Simplified PRC)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="zh-TW" Text="中文 (Traditional Taiwan)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="zh-HK" Text="Traditional, Hong Kong S.A.R. (Chinese)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="zh-MO" Text="Traditional, Macao S.A.R. (Chinese)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="ar-EG" Text="Arabic (Egypt)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="ar-AE" Text="Arabic (U.A.E.)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="ar-SA" Text="Arabic (Saudi Arabia)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="de-DE" Text="Deutsch (Germany)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="he-IL" Text="Hebrew (Israel)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="it-IT" Text="italiano (Italy)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="ga-IE" Text="Irish (Ireland)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="bg-BG" Text="български (Bulgarian)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="el-GR" Text="Ελληνικά (Greece)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="fi-FI" Text="suomi (Finnish)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="nl-NL" Text="Nederlands (Dutch Netherlands)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="pt-PT" Text="Português (Portugal)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="sv-SE" Text="svenska (Swedish)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="ru-RU" Text="русский (Russian)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="af-ZA" Text="Afrikaans (South Africa)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="ja-JP" Text="日本語 (Japanese)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="ko-KR" Text="한국어 (Korean)"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="vi-VN" Text="Tiếng Việt (Vietnamese)"></telerik:RadComboBoxItem>
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                </div>
                                            </div>
                                            <div style="width: 408px; text-align: right; margin: 6px auto 0px auto; padding-right: 0px;">
                                                <div style="width: 100%;">
                                                    <div class="" style="display: inline-block;" title="Check to remember.">
                                                        Remember Me:
                                                    </div>
                                                    <div class="" style="display: inline-block;" title="Check to remember.">
                                                        <asp:CheckBox ID="CheckBoxRememberMe" runat="server" Text=""/>
                                                    </div>
                                                    <div style="display: inline-block; margin-left: 4px;" title="Click to sign in.">
                                                        <asp:Button ID="ButtonLogin" runat="server" Text="Sign In" Width="100px" OnClientClick="disableButton(this)"/>
                                                    </div>
                                                </div>
                                                <div style="position: relative; width: 100%; text-align: right; margin: 4px 0px 0px 0px;">
                                                    <div id="DivTwoFactorEmailLink" runat="server" style="display: inline-block;">
                                                        <asp:LinkButton ID="LinkButtonResendTwoFactorEmail" runat="server" ToolTip="Click to resend two factor authentication code email with a new code.">Resend Authentication Code</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                    </div>
                                                    <div id="DivChangePassword" runat="server" style="display: inline-block;">
                                                        <asp:LinkButton ID="LinkButtonChangePassword" runat="server" Visible="True" ToolTip="Click to change password.">Change Password</asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="LinkButtonLostPassword" runat="server" Visible="True" ToolTip="Click to reset lost password.">Forgot Password</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelChangePassword" runat="server" Visible="false">
                                        <div style="width: 100%; margin: 35px 0px 0px 0px">
                                            <div class="code-description-container" style="margin-left: 4px !important;" title="Enter old password.">
                                                <div class="code-description-label">
                                                    Old Password:
                                                </div>
                                                <div class="code-description-description">
                                                    <asp:TextBox ID="TextBoxOldPassword" runat="server" SkinID="TextBoxCodeSingleLineDescription" TextMode="Password" CssClass="k-textbox" style="height: 28px !important;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="code-description-container" style="margin-left: 4px !important;" title="Enter new password.">
                                                <div class="code-description-label">
                                                    New Password:
                                                </div>
                                                <div class="code-description-description">
                                                    <asp:TextBox ID="TextBoxNewPassword" runat="server" SkinID="TextBoxCodeSingleLineDescription" TextMode="Password" CssClass="k-textbox" style="height: 28px !important;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="code-description-container" title="Confirm new password.">
                                                <div class="code-description-label">
                                                    Confirm New Password:
                                                </div>
                                                <div class="code-description-description">
                                                    <asp:TextBox ID="TextBoxConfirmNewPassword" runat="server" SkinID="TextBoxCodeSingleLineDescription" TextMode="Password" CssClass="k-textbox" style="height: 28px !important;">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="code-description-container">
                                                <div class="code-description-label">
                                                    &nbsp;
                                                </div>
                                                <div class="" style="text-align: right; width: 562px !important;">
                                                    <div class="k-button-group k-dialog-buttongroup k-dialog-button-layout-normal" style="padding-right: 30px !important;">
                                                        <asp:Button ID="ButtonChangePasswordCancel" runat="server" Text="Cancel" Width="80px" CssClass="k-button" ToolTip="Cancel password change."/>
                                                        <asp:Button ID="ButtonChangePasswordOK" runat="server" Text="Save" Width="80px" CssClass="k-button k-primary" ToolTip="Click to change password." />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="margin: 0px 0px 0px 172px; text-align: left !important;">
                                                <div>
                                                    <ul style="color: red; text-align: left !important;">
                                                        <asp:Literal ID="LiteralMessages" runat="server"></asp:Literal>
                                                    </ul>
                                                </div>
                                                <asp:Literal ID="LiteralScript" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelLostPassword" runat="server" Visible="false">
                                        <div id="DivLostPasswordEmailForm" runat="server" style="width: 100%; text-align: center; margin-top: 55px;">
                                            <span style="font-size: 18px;">You have requested a password reset.</span>  
                                            <p style="margin-top: 30px;">We’ll email you at <asp:Literal ID="LiteralEmailAddress" runat="server"></asp:Literal> with a link to complete this process.</p>
                                            <p style="margin-top: 30px;">Continue?</p>
                                            <div style="margin-top: 60px;">
                                                <div class="k-button-group k-dialog-buttongroup k-dialog-button-layout-normal" style="">
                                                    <asp:Button ID="ButtonLostPasswordNo" runat="server" Text="No" CssClass="k-button" Width="100px" ToolTip="Click to cancel lost password request."/>
                                                    <asp:Button ID="ButtonLostPasswordYes" runat="server" Text="Yes" CssClass="k-button k-primary" Width="100px" ToolTip="Click to send a lost password email" />
                                                </div>
                                            </div>
                                        </div>
                                        <div id="DivLostPasswordSuccess" runat="server" style="width: 100%; text-align: center; margin-top: 50px;" >
                                            <span style="font-size: 18px;">
                                                SUCCESS!
                                            </span>
                                            <p style="margin-top: 30px;">
                                                Please check your email for further instructions.
                                            </p>                                            
                                            <asp:Literal ID="LiteralLostPasswordSuccess" runat="server"></asp:Literal>
                                            <div class="k-button-group k-dialog-buttongroup k-dialog-button-layout-normal" style="margin-top: 30px;">
                                                <asp:Button ID="ButtonLostPasswordSuccessResend" runat="server" Text="Resend" Width="125px" CssClass="k-button" ToolTip="Click to resend lost password email." />
                                                <asp:Button ID="ButtonLostPasswordSuccessOK" runat="server" Text="OK" Width="125px" CssClass="k-button k-primary" ToolTip="Click to continue."/>
                                            </div>
                                        </div>
                                        <div id="DivLostPasswordFail" runat="server" style="width: 100%; text-align: center; margin-top: 50px;" >
                                            <div style="width: 90%; text-align: center; padding: 30px;">
                                                <h3><asp:Literal ID="LiteralLostPasswordFail" runat="server">FAILED</asp:Literal></h3>  
                                                    <div style="margin-top: 25px;">
                                                    <div style="display: inline-block;">
                                                        <asp:Button ID="ButtonLostPasswordFailOK" runat="server" Text="OK" Width="125px" ToolTip="Click to continue."/>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td id="gmSignIn" runat="server" style="height: 300px; text-align:center; vertical-align:middle;">
                    <div class="sign-in-container-a" style="height: 300px !important;">
                        <div class="sign-in-header-a" style="width: 100%;">
                            <div style="width:225px; display: inline-block;">
                                <span style="margin-left: 8px; cursor: pointer;" onclick="refreshAdminWindow()" title="Click to refresh this page.">Admin Sign In</span>
                            </div>
                            <div style="width:225px; display: inline-block; text-align: right; float: right;">                                
                                <span style="margin-right: 8px; cursor: pointer;" onclick="closeAdminWindow()" title="Click to close the Admin Sign In window and return to the sign in window." >Return to Sign In</span>
                            </div>
                        </div>
                        <div class="sign-in-content-container-a" style="">
                            <asp:Panel ID="PanelAdminSignIn1" runat="server" DefaultButton="ButtonLogin1" Visible="true">
                                <div style="width: 100%; margin: 35px 0px 0px 0px">
                                    <div id="PanelAdminSignInServerInput" runat="server" class="code-description-container" title="Enter server name in text box.">
                                        <div class="code-description-label">
                                            Server:
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TextBoxSQLServer1" runat="server" SkinID="TextBoxCodeSingleLineDescription" autocomplete="off" CssClass="k-textbox" style="height: 28px !important;"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="code-description-container" title="Enter database name in text box.">
                                        <div class="code-description-label">
                                            Database:
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TextBoxDataBase1" runat="server" SkinID="TextBoxCodeSingleLineDescription" autocomplete="off" CssClass="k-textbox" style="height: 28px !important;"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="code-description-container" title="Enter admin user ID in text box.">
                                        <div class="code-description-label">
                                            User ID:
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TextBoxUserID1" runat="server" SkinID ="TextBoxCodeSingleLineDescription" autocomplete="off" CssClass="k-textbox" style="height: 28px !important;"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="code-description-container" title="Enter admin password.">
                                        <div class="code-description-label">
                                            Password:
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TextBoxPassword1" runat="server" TextMode="Password" SkinID="TextBoxCodeSingleLineDescription" autocomplete="off" CssClass="k-textbox" style="height: 28px !important;"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div style="width: 480px; text-align: center; margin: 20px auto 0px auto;" title="Click to sign in to admin.">
                                        <asp:Button ID="ButtonLogin1" runat="server" Text="Sign In" Width="480px" OnClientClick="" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </td>
                <td id="gmWindowCell" runat="server" style="min-height: 560px; text-align:center; vertical-align:middle;">
                    <div class="sign-in-container-a" style="width: 975px; height: 550px !important;">
                        <div class="sign-in-header-a" style="width: 100%;">
                            <div style="width:225px; display: inline-block;">
                                <span style="margin-left: 8px; cursor: pointer;" onclick="refreshAdminWindow()" title="Click to refresh.">Admin</span>
                            </div>
                            <div style="width:225px; display: inline-block; text-align: right; float: right;">                                
                                <span style="margin-right: 8px; cursor: pointer;" onclick="closeAdminWindow()" title="Click to close the Admin window and return to the sign in window." >Return to Sign In</span>
                            </div>
                        </div>
                        <div class="sign-in-content-container-a" style="height:522px;">
                            <iframe id="adminIframe" runat="server" src="Blank.htm" style="width: 970px; height: 520px; border: 0 !important;">
                            </iframe>
                        </div>
                    </div>
                </td>
            </tr>
            <tr id="TrFooter" runat="server">
                <td align="center" valign="bottom" class="">
                    <div style="margin-bottom:-2px;width:100%;text-align:right;">
                        <asp:Image ID="ImageLongLiveTheAgency" runat="server" ImageUrl="Images/Logos/llta_FFFFFF.png" CssClass="llta" Visible="false" />
                    </div>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="dark-bg">
                        <tr>
                            <td align="left" valign="bottom" width="30%" class="dark-bg" style="color: #FFFFFF !important;">&nbsp;&nbsp;
                                <img src="Images/Logos/advantagelogo_white.png" alt="The Advantage Software Company" style="height: 25px;padding:5px 0px 0px 0px;" />
                            </td>
                            <td align="right" valign="middle" width="70%" class="dark-bg" style="color: #FFFFFF !important;">
                                <asp:Label ID="LabelVersion" runat="server"></asp:Label>,
                                &nbsp;&nbsp;
                                <asp:Label ID="LabelCopyright" runat="server"></asp:Label>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
    <input type="hidden" id="caseSensitiveHF" name="caseSensitiveHF" />
</body>
</html>
