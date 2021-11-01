@ModelType Generic.List(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)
@Code
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code

<script src="~/JScripts/validator.js" type="text/javascript"></script>
<script src="~/JScripts/projectmanagement.agile.addjobtoboards.min.js" type="text/javascript"></script>
<link href="~/CSS/projectmanagement.agile.addjobtoboards.min.css" rel="stylesheet" />

<div id="toolbar-container">
    <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable" style="        width: 100%;
        background-color: #E5E5E5;
        padding: 8px 0px 8px 0px;
        border-bottom: 1px solid #CCC;
        box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);
        margin: 5px auto;
        overflow: auto;">
        <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
            <li style="padding:0">
                <button id="saveButton" class="k-button wv-icon-button wv-save k-state-disabled" onclick="saveClick()" title="Save changes"><span class='wvi wvi-floppy-disk'></span></button>
            </li>
            <li style="padding:0">
                <button id="cancelButton" class="k-button wv-icon-button wv-cancel k-state-disabled" style="" onclick="cancelClick()"><span class='wvi wvi-sign-forbidden' title="Cancel"></span></button>
            </li>
            <li style="padding:0">
                <button class="k-button wv-icon-button wv-neutral" onclick="refreshClick()"><span class='wvi wvi-refresh' title="Refresh"></span></button>
            </li>
        </ul>
    </div>
</div>
<div id="grid-container">
    @Code Dim WrapSettings As New Syncfusion.JavaScript.Models.TextWrapSettings
        Dim GridBuilder = Html.EJ().Grid(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)("BoardsGrid")

        WrapSettings.WrapMode = WrapMode.Both

        GridBuilder.Datasource(Model)
        GridBuilder.EditSettings(Sub(Edit)
                                     Edit.AllowEditing(True)
                                 End Sub)
        GridBuilder.AllowFiltering(False)
        GridBuilder.AllowGrouping(True)
        GridBuilder.AllowMultiSorting(True)
        GridBuilder.AllowSelection(True)
        GridBuilder.AllowSorting(True)
        GridBuilder.AllowTextWrap(True)
        GridBuilder.AllowKeyboardNavigation(True)
        GridBuilder.AllowSearching(False)
        GridBuilder.EnableTouch(True)
        GridBuilder.IsResponsive(True)
        GridBuilder.SearchSettings(Sub(ss)
                                       ss.IgnoreCase(True)
                                       ss.Operator([Operator].Contains)
                                   End Sub)
        GridBuilder.GroupSettings(Sub(settings)
                                      settings.ShowDropArea(False)
                                      settings.ShowToggleButton(False)
                                  End Sub)
        GridBuilder.TextWrapSettings(WrapSettings)
        GridBuilder.SelectionType(SelectionType.Multiple)
        GridBuilder.EnableToolbarItems(False)
        GridBuilder.Columns(Sub(Column)
                                Column.Field("Name").HeaderText("Name").AllowGrouping(True).Add()
                                Column.Field("JobIsOnBoard").HeaderText("Is On Board *").AllowGrouping(True).TextAlign(Syncfusion.JavaScript.TextAlign.Center).Template("#jobIsOnBoardTemplate").Width(120).Add()
                            End Sub)
        GridBuilder.ClientSideEvents(Sub(Events)
                                         Events.ActionBegin("gridActionBegin")
                                         Events.QueryCellInfo("gridQueryCellInfo")
                                     End Sub)
        GridBuilder.Render() End Code
</div>
<div style="font-style:italic; margin-top: 6px;">
    *  Check the checkbox to add this job to the board.<br />
    &nbsp;&nbsp;&nbsp;Uncheck the checkbox to remove this job from the board.
</div>
<script id="jobIsOnBoardTemplate" type="text/template">
    {{if JobIsOnBoard}}
    <input type="checkbox" id="jobIsOnBoardCheckBox" name="jobIsOnBoardCheckBox" onchange="jobIsOnBoardCheckBoxChanged(event)" checked="checked" class="e-field e-checkbox" style="width:30px" />
    {{else}}
    <input type="checkbox" id="jobIsOnBoardCheckBox" name="jobIsOnBoardCheckBox" onchange="jobIsOnBoardCheckBoxChanged(event)" class="e-field e-checkbox" style="width:30px" />
    {{/if}}
</script>
<script>
</script>
