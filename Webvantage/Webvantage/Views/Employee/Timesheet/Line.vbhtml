@ModelType AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetLineViewModel

@Code

    ViewData("Title") = "Time Sheet Row View"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
<style>
    .hours-textbox {
        width: 55px;
        height: 30px;
        text-align: right;
        vertical-align: middle;
        border: 1px solid #ddd;
        border-radius: 2px;
        font-size: 14px;
        font-weight: bold;
        padding-right: 0px;
    }
    .hours-textbox:hover {
        border: 1px solid #AEAEAE;
        background-color: #EBEBEB !important;
    }
    .commments-textbox {
        width: 360px;
        height: 75px;
        vertical-align: middle;
        border: 1px solid #ddd;
        border-radius: 2px;
    }
</style>
<div id="content">
    <div class="form-horizontal">
        <div class="wv-widget-rows">
            <div id="headerInfo" class="wv-widget-row">
                <div class="wv-widget-col wv-form">
                    <div class="wv-form-group form-x margin-x" style="cursor: help;">
                        <label>Client:</label>
                        <div>
                            <span>DynamicContent</span>
                        </div>
                    </div>
                    <div class="wv-form-group form-x margin-x" style="cursor: help;">
                        <label>Division:</label>
                        <div>
                            <span>DynamicContent</span>
                        </div>
                    </div>
                    <div class="wv-form-group form-x margin-x" style="cursor: help;">
                        <label>Product:</label>
                        <div>
                            <span>DynamicContent</span>
                        </div>
                    </div>
                </div>
                <div class="wv-widget-col wv-form">
                    <div class="wv-form-group form-x margin-x" style="cursor: help;">
                        <label>Job:</label>
                        <div>
                            <span>DynamicContent</span>
                        </div>
                    </div>
                    <div class="wv-form-group form-x margin-x" style="cursor: help;">
                        <label>Component:</label>
                        <div>
                            <span>DynamicContent</span>
                        </div>
                    </div>
                </div>
            </div>
            <div id="editInfo" class="wv-widget-row">
                <div class="wv-widget-col wv-form">
                    <div class="wv-form-group form-x margin-x" style="cursor: help;">
                        <label>Function:</label>
                        <div>
                            <span>DynamicContent</span>
                        </div>
                    </div>
                    <div class="wv-form-group form-x margin-x" style="cursor: help;">
                        <label>Department:</label>
                        <div>
                            <span>DynamicContent</span>
                        </div>
                    </div>
                </div>
                <div class="wv-widget-col wv-form">
                    <div class="wv-form-group form-x margin-x" style="cursor: help;">
                        <label>Assignment:</label>
                        <div>
                            <span>DynamicContent</span>
                        </div>
                    </div>
                </div>
            </div>
            <div id="days" class="wv-widget-row">
                <div id="daysContainer">
                    <div id="dayContainer">
                        <h3>Sunday</h3>
                        <table>
                        <tr>
                            <td>
                                <div style="display:inline-block; padding-top: 10px;">
                                    <div>
                                        <label>Comments:</label>
                                    </div>
                                    <div>
                                        <textarea class="commments-textbox"></textarea>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div style="display:inline-block; padding-top: 10px; padding-left: 5px;">
                                    <div>
                                        <label>Hours:</label>
                                    </div>
                                    <div>
                                        <input type="number" step="any" onfocus="this.select();" class="hours-textbox" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        </table>
                    </div>
                </div>
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
