@Code ViewData("IsFullLayout") = True
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml" End Code
<style>
    body {
        font-size: 16px !important;
    }
    .settings-container {
        min-height: 420px;
        width: 660px;
        left: 0;
        right: 0;
        position: relative;
        margin: auto;
    }
    .settings-section {
        margin: 14px 0;
        padding-left: 10px;
        padding-right: 10px;
        padding-bottom: 10px;
    }
    .veri-key {
        font-size: 42px;
        height: 56px;
        margin-left: 0px;
    }
    .disabled-button {
        border-color: #666666 !important;
        background-color: #666666 !important;
        color: #808080 !important;
    }
    .questions-container {

    }
    .question-block {
    }
</style>
@Section PageHeader
    <div class="panel-heading bg-primary">
        <div class="panel-title" style="text-align:center">
            <h2>Please help us verify your identity</h2>
        </div>
    </div>
End Section

<div class="settings-container" style="width: 500px;">
    <div id="container" style="padding: 8px 22px 0px 22px;">
        <div id="employee-questions-container" class="questions-container">
            <div id="employee-name" class="question-block" style="display: block;">
                <div style="display: inline-block;">
                    <div>
                        First
                    </div>
                    <div>
                        <input type="text" id="textbox-first-name" class="k-textbox" style="width: 200px;" />
                    </div>
                </div>
                <div style="display: inline-block;">
                    <div>
                        Mi
                    </div>
                    <div>
                        <input type="text" id="textbox-middle-name" class="k-textbox" style="width: 35px;" />
                    </div>
                </div>
                <div style="display: inline-block;">
                    <div>
                        Last
                    </div>
                    <div>
                        <input type="text" id="textbox-last-name" class="k-textbox" style="width: 200px;" />
                    </div>
                </div>
            </div>
            <div id="employee-street" class="question-block" style="display: block;">
                <div style="display: inline-block;">
                    <div>
                        Street name
                    </div>
                    <div>
                        <input type="text" id="textbox-street-name" class="k-textbox" style="width: 443px;" />
                    </div>
                </div>
            </div>
            <div id="employee-zip" class="question-block" style="display: block;">
                <div style="display: inline-block;">
                    <div>
                        Zip code
                    </div>
                    <div>
                        <input type="text" id="textbox-zip-code" class="k-textbox" style="width: 443px;" />
                    </div>
                </div>
            </div>
            <div id="employee-dob" class="question-block" style="display: block;">
                <div style="display: inline-block;">
                    <div>
                        Birthday
                    </div>
                    <div>
                        <input type="text" id="textbox-birthday" />
                    </div>
                </div>
            </div>
            <div id="employee-ssn" class="question-block" style="display: block;">
                <div style="display: inline-block;">
                    <div>
                        Last four digits of SSN
                    </div>
                    <div>
                        <input type="text" id="textbox-last-four" class="k-textbox" style="width: 443px;" />
                    </div>
                </div>
            </div>
        </div>
        <div id="agency-questions-container" class="questions-container">
            <div id="agency-name" class="question-block" style="display: block;">
                <div style="display: inline-block;">
                    <div>
                        Agency name
                    </div>
                    <div>
                        <input type="text" id="textbox-agency-name" class="k-textbox" style="width: 443px;" />
                    </div>
                </div>
            </div>
            <div id="agency-street" class="question-block" style="display: block;">
                <div style="display: inline-block;">
                    <div>
                        Agency street name
                    </div>
                    <div>
                        <input type="text" id="textbox-agency-street-name" class="k-textbox" style="width: 443px;" />
                    </div>
                </div>
            </div>
            <div id="agency-zip" class="question-block" style="display: block;">
                <div style="display: inline-block;">
                    <div>
                        Agency zip
                    </div>
                    <div>
                        <input type="text" id="textbox-agency-zip" class="k-textbox" style="width: 443px;" />
                    </div>
                </div>
            </div>
        </div>
        <div style="width: 100%; display: inline-block; margin-top: 16px; margin-right:0px; position: relative; right: 0 !important; text-align: right;" title="Actions.">
            <div id="buttonsContainer" class="k-button-group">
                <button id="cancelSavePasswordButton" class="k-button" onclick="return false" title="Cancel">Cancel</button>
                <button id="savePasswordButton" class="k-button k-primary" onclick="return false" title="Save your new password">Save</button>
            </div>
            <div id="buttonProgressContainer" class="k-button-group" style="display: none;">
                <img src="~/CSS/Material/PleaseWait/spinner.gif" />
            </div>
        </div>
        <div id="validationContainer" class="form-group" style="width:100%; margin: 0px 0px 30px 0px; display: none;">
        </div>
        <div id="messages-containers" style="margin-top: 65px;"></div>
        <span id="staticNotification"></span>
    </div>
</div>
@Scripts.Render("~/JScripts/account.verify.mvc.min.js")
<script>
</script>
