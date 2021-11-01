@ModelType AdvantageFramework.ViewModels.UserAccount.PasswordIndexViewModel
@Code ViewData("IsFullLayout") = True
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml" End Code
<style>
    body {
    }
    .settings-container {
        background: white;
        border: 0px solid #ccc;
        border-radius: 6px;
        max-width: 1200px;
        margin: 15px auto 0 auto !important;
    }
    .settings-section {
        margin: 14px 0;
        padding-left: 10px;
        padding-right: 10px;
        padding-bottom: 10px;
    }
    .veri-key {
        font-size: 22px;
        height: 38px;
        margin-left: 0px;
        width: 100%;
    }
    .disabled-button {
        border-color: #666666 !important;
        background-color: #666666 !important;
        color: #808080 !important;
    }
</style>
@Section PageHeader
    <div class="panel-heading bg-primary">
        <div class="panel-title" style="text-align:center">
            @Code If Model.IsValid = True Then
                    If Model.HasPassword = True Then
                    @<h2>Lost Password</h2> Else
                    @<h2>Create Password</h2> End If
                End If
            End Code
        </div>
    </div>
End Section
<div class="settings-container" style="width: 500px;">
    <div class="settings-section" style="">
        <div id="container" style="padding: 8px 22px 0px 22px;">
            <div id="validationContainer" class="form-group" style="width:100%; margin: 0px 0px 30px 0px; display: none;">
                <span style="font-size:18px; margin-top: 10px;">
                    Hello @Html.Raw(Model.FirstName),
                </span>
                <p style="margin-top: 26px;">
                    Please enter the five digit security key from the email:
                </p>
                <div style="width: 100%; text-align: center;">
                    <input id="emailKeyTextbox" type="text" 
                           class="e-textbox veri-key" 
                           style=""
                           title="The key you received goes here!"
                           onkeyup="sendSecurityKeyButtonChange();"
                           onchange="sendSecurityKeyButtonChange();"
                           onblur="sendSecurityKeyButtonChange()"
                           maxlength="5"
                           autocomplete="off" />
                </div>
                <div id="validateSecurityKeyButtonContainer" style="margin: 10px 0px 0px 0px;" title="Press this button to validate the security key!">
                    <button id="validateSecurityKeyButton" class="k-button k-primary" style="width: 100%;" onclick="validateSecurityKey()" disabled>Validate</button>
                </div>
                <div id="buttonValidateProgressContainer" class="k-button-group" style="display: none;" title="Please wait">
                    <img src="~/CSS/Material/PleaseWait/spinner.gif" />
                </div>
            </div>
            <div id="passwordsContainer" style="display: none;">
                <div class="form-group" style="width:100%;" title="New password">
                    <div>
                        New Password:
                    </div>
                    <div>
                        <input id="newPasswordTextbox" type="password" class="e-textbox" style="width: 100%;" onkeypress="capLock(event)" autocomplete="off" />
                    </div>
                </div>
                <div class="form-group" style="width:100%;" title="Repeat the password you entered above">
                    <div>
                        Verify New Password:
                    </div>
                    <div>
                        <input id="compareNewPasswordTextbox" type="password" class="e-textbox" style="width: 100%;" onkeypress="capLock(event)" autocomplete="off" />
                    </div>
                </div>
                <div style="display: block;">
                    @Html.EJ().CheckBox("checkBoxTogglePWD").Value("IsActive").Size(Size.Medium).Checked(False).ClientSideEvents(Sub(e)
                                                                                                                                     e.Change("togglePwd")
                                                                                                                                 End Sub)  <span style="margin-top: 3px !important;">Show Password</span>
                </div>
                <div style="width: 100%; display: inline-block; margin-top: 10px; margin-right:0px; position: relative; right: 0 !important; text-align: right;" title="Actions.">
                    <div id="buttonsContainer" class="k-button-group">
                        <button id="cancelSavePasswordButton" class="k-button" onclick="cx()" title="Cancel">Cancel</button>
                        <button id="savePasswordButton" class="k-button k-primary" onclick="snp()" title="Save your new password">Save</button>
                    </div>
                    <div id="buttonProgressContainer" class="k-button-group" style="display: none;" title="Please wait!">
                        <img src="~/CSS/Material/PleaseWait/spinner.gif" />
                    </div>
                </div>
            </div>
            <div id="successContainer" style="display: none; vertical-align:middle; text-align: center; margin-top: 30px;" title="Yoiu successfully changed your password!">
                <div style="font-size: 28px; margin-bottom: 40px; position: relative;">
                    SUCCESS!
                </div>
                <p style="font-size: 18px;">
                    Your new password is set!
                </p>
                <p style="font-size: 18px;" title="Click to sign in to Webvantage">
                    <a id="signInLink" href="#" style="" title="Click to sign in to Webvantage">Sign in to Webvantage.</a>
                </p>
            </div>
            <div id="capsLockWarning" class="alert alert-warning" role="alert" style="display:none; margin-bottom: 0 !important; position: relative; margin-top: 15px;" title="CAPS lock is on!!!">
                <strong>Warning</strong><span style="margin-left: 12px;">Caps Lock is on!</span>
            </div>
            <div id="messages-containers" style="margin-top: 65px;"></div>
            <span id="staticNotification"></span>
            <span id="capsLockNotification"></span>
        </div>
    </div>
</div>
@Scripts.Render("~/JScripts/account.password.mvc.min.js")
<script>
    $(document).ready(function () {
        $("#emailKeyTextbox").focus();
        sendSecurityKeyButtonChange();
        $(document).bind("contextmenu", function (e) {
            return false;
        });
        var isValid = false;
        var s = '@Html.Raw(Model.Message)';
        isValid = @Html.Raw(Model.IsValid.ToString.ToLower);
        if (isValid == false) {
            if (s && s != "") {
                showMessage(s);
                $("#validationContainer").hide();
            }
        } else {
            $("#validationContainer").show();
        }
    });
</script>
