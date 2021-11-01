@ModelType Object

@Code

    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
<style>
</style>
<div id="content">
    <div class="form-horizontal">
        <div class="wv-widget-rows">
            <div id="headerInfo" class="wv-widget-row">
                <div class="wv-form-group form-x margin-x" style="cursor: help;">
                    <label>Client:</label>
                    <div>
                        <span>DynamicContent</span>
                    </div>
                </div>
            </div>
            <div id="editInfo" class="wv-widget-row">
            </div>
            <div id="days" class="wv-widget-row">
            </div>
        </div>
    </div>
    <div style="text-align: right;">
        <div class="k-button-group">
            <button id="saveButton" onclick="saveButtonClick();" class="k-button k-primary">Save</button>
            <button id="cancelButton" onclick="cancelButtonClick();" class="k-button">Cancel</button>
        </div>
    </div>
</div>
<script>
    function init() {

    }
    $(document).ready(function () {
        init();
    });
</script>
