@ModelType Webvantage.Controllers.Account.IndexViewModel
@Code ViewData("IsFullLayout") = True
                Layout = "~/Views/Shared/_LayoutPageBase.vbhtml" End Code
<style>
</style>
@Section PageHeader
    <div class="panel-heading bg-primary">
        <div class="panel-title" style="text-align:center">
            <h2>Admin</h2>
        </div>
    </div>
End Section
<div class="form-horizontal">
    <fieldset style="margin: 20px 0px 0px 0px;">
        <div class="form-group">
            <label class="col-md-4 control-label" for="textinput">Server</label>
            <div class="col-md-4">
                <input id="TextBoxServerName" name="TextBoxServerName" type="text" placeholder="Server Name" class="e-textbox">
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="TextBoxDatabaseName">Database</label>
            <div class="col-md-4">
                <input id="TextBoxDatabaseName" name="TextBoxDatabaseName" type="text" placeholder="Database Name" class="e-textbox" required="">
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="textinput">User ID</label>
            <div class="col-md-4">
                <input id="TextBoxUserCode" name="TextBoxUserCode" type="text" placeholder="User ID" class="e-textbox">
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="TextBoxDatabaseName">Password</label>
            <div class="col-md-4">
                <input id="TextBoxPassword" name="TextBoxPassword" type="text" placeholder="Password" class="e-textbox" required="">
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-8">
                <div style="width: 100%; display: inline-block; margin-top: 10px; margin-right:0px; position: relative; right: 0 !important; text-align: right;" title="Actions.">
                    <div id="buttonsContainer" class="k-button-group">
                        <button id="cancelSignInButton" class="k-button" onclick="bye()" title="Cancel">Cancel</button>
                        <button id="signInButton" class="k-button k-primary" onclick="chk()" title="Sign In">Sign In</button>
                    </div>
                    <div id="buttonProgressContainer" class="k-button-group" style="display: none;">
                        <img src="~/CSS/Material/PleaseWait/spinner.gif" />
                    </div>
                </div>
            </div>
        </div>
    </fieldset>
</div>
@Scripts.Render("~/JScripts/account.gm.mvc.min.js")
