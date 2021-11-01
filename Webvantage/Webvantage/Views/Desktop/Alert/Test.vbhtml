@ModelType AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManager
@Code
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code
<style type="text/css" class="cssStyles"> 
    .e-tooltxt {
        background: none !important; 
        border-color: transparent !important; 
    }
    .e-tooltxt:active {
        background: none !important; 
        border-color: transparent !important; 
    }
    .e-tooltxt:hover {
        background: none !important;
        border-color: transparent !important;
    }
</style> 

<div style = " margin: 10px 0px 0px 0px;" >
        @Code


            Dim Tree = Html.EJ().TreeGrid("TreeGridContainer")

            Tree.Datasource(Model.Items)
            Tree.Columns(Sub(Col)
                             Col.Field("Subject").HeaderText("Subject").Add()
                             Col.Field("ClientName").HeaderText("Client").Add()
                             Col.Field("GroupJobComponent").HeaderText("Job").Add()
                             Col.Field("AssignedTo").HeaderText("Assigned").Add()
                             Col.Field("LastUpdated").HeaderText("Updated").Add()
                         End Sub)
            Tree.ToolbarSettings(Sub(Tools)
                                     Tools.ShowToolbar(True)
                                     Tools.CustomToolbarItems(Sub(CustomToolbarItem)
                                                                  CustomToolbarItem.TemplateID("#editButtonTemplate").TooltipText("Edit").Add()
                                                                  CustomToolbarItem.TemplateID("#cancelButtonTemplate").TooltipText("Cancel").Add()
                                                                  CustomToolbarItem.TemplateID("#updateMakegoodButtonTemplate").TooltipText("Update Makegood").Add()
                                                                  CustomToolbarItem.TemplateID("#addMakegoodButtonTemplate").TooltipText("Add Makegood").Add()
                                                                  CustomToolbarItem.TemplateID("#addReplacementButtonTemplate").TooltipText("Add Replacement").Add()
                                                                  CustomToolbarItem.TemplateID("#viewButtonTemplate").TooltipText("View Makegood").Add()
                                                                  CustomToolbarItem.TemplateID("#deleteButtonTemplate").TooltipText("Delete Makegood").Add()
                                                              End Sub)
                                 End Sub)
            Tree.AllowTextWrap(True)
            Tree.ShowGridCellTooltip(True)
            Tree.HeaderTextOverflow(TreeGridHeaderTextOverflow.Wrap)
            Tree.SelectionMode(TreeGridSelectionMode.Row)
            Tree.SizeSettings(Sub(ss)
                                  ss.Height("550px")
                              End Sub)
            Tree.EditSettings(Sub(edit)
                                  edit.AllowAdding(True)
                                  edit.AllowEditing(True)
                                  edit.EditMode(TreeGridEditMode.RowEditing)
                              End Sub)
            Tree.ClientSideEvents(Sub(Events)
                                      Events.Create("create")
                                      Events.ToolbarClick("toolbarClick")
                                  End Sub)
            Tree.Render()




            'Dim WrapSettings As New Syncfusion.JavaScript.Models.TextWrapSettings
            'Dim GridBuilder = Html.EJ().Grid(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerItem)("AamGrid")



            'WrapSettings.WrapMode = WrapMode.Both



            'GridBuilder.Datasource(Model.Items)
            'GridBuilder.EditSettings(Sub(Edit)
            '                         End Sub)
            'GridBuilder.AllowMultiSorting(True)
            'GridBuilder.AllowSelection(False)
            'GridBuilder.AllowSorting(True)
            'GridBuilder.AllowTextWrap(True)
            'GridBuilder.AllowFiltering(True)
            'GridBuilder.AllowGrouping(True)
            'GridBuilder.GroupSettings(Sub(Settings)
            '                              Settings.ShowDropArea(True)
            '                              Settings.ShowGroupedColumn(False)
            '                              Settings.ShowToggleButton(True)
            '                              Settings.ShowUngroupButton(True)
            '                          End Sub)
            'GridBuilder.AllowPaging(True)
            'GridBuilder.PageSettings(Sub(Settings)
            '                             Settings.EnableQueryString(True)
            '                             Settings.PageSize(10)
            '                             Settings.PrintMode(PrintMode.AllPages)
            '                         End Sub)
            'GridBuilder.TextWrapSettings(WrapSettings)
            'GridBuilder.SelectionType(SelectionType.Single)
            'GridBuilder.EnableToolbarItems(False)
            'GridBuilder.Columns(Sub(Column)
            '                        Column.Field("Subject").HeaderText("Subject").AllowGrouping(True).AllowFiltering(True).FilterType(FilterOption.Excel).FilterOperator(FilterOperatorType.Contains).Add()
            '                        Column.Field("ClientName").HeaderText("Client").AllowGrouping(True).AllowFiltering(True).FilterType(FilterOption.Excel).FilterOperator(FilterOperatorType.Contains).Add()
            '                        Column.Field("GroupJobComponent").HeaderText("Job").AllowGrouping(True).AllowFiltering(True).FilterType(FilterOption.Excel).FilterOperator(FilterOperatorType.Contains).Add()
            '                        Column.Field("AssignedTo").HeaderText("Assigned To").AllowGrouping(True).AllowFiltering(True).FilterType(FilterOption.Excel).FilterOperator(FilterOperatorType.Contains).Add()
            '                        Column.Field("LastUpdated").HeaderText("Updated").AllowGrouping(False).AllowFiltering(False).TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(160).Add()
            '                    End Sub)
            ''GridBuilder.ClientSideEvents(Sub(Events)
            ''                                 Events.ActionBegin("gridActionBegin")
            ''                                 Events.QueryCellInfo("gridQueryCellInfo") 



            ''                             End Sub)
            'GridBuilder.Render()

        End Code
</div>
    <script id="editButtonTemplate" type="text/x-jsrender">
        <button id="editButton" class="wv-icon-button k-button wv-add-new"
            onclick="editClick()" title="Edit"><span class="wvi wvi-edit"></span></button>
    </script>
    <script id="cancelButtonTemplate" type="text/x-jsrender">
        <button id="cancelButton" class="wv-icon-button k-button wv-cancel"
            onclick="cancelClick()" title="Cancel"><span class="wvi wvi-sign-forbidden"></span></button>
    </script>
    <script id="updateMakegoodButtonTemplate" type="text/x-jsrender">
        <button id="updateMakegoodButton" class="k-button wv-icon-button wv-save"
            onclick="updateMakegoodClick()" title="Update Makegood"><span class="wvi wvi-floppy-disk"></span></button>
    </script>
    <script id="addMakegoodButtonTemplate" type="text/x-jsrender">
        <button id="addMakegoodButton" class="k-button wv-text-button"
            onclick="addMakegoodClick()" title="Add Makegood"><span>Add Makegood</span></button>
    </script>
    <script id="addReplacementButtonTemplate" type="text/x-jsrender">
        <button id="addReplacementButton" class="k-button wv-text-button"
            onclick="addReplacementClick()" title="Add Replacement"><span>Add Replacement</span></button>
    </script>
    <script id="viewButtonTemplate" type="text/x-jsrender">
        <button id="viewButton" class="k-button wv-icon-button" 
            onclick="viewClick()" title="View Makegood"><span class='wvi wvi-magnifying-glass'></span></button>
    </script>
    <script id="deleteButtonTemplate" type="text/x-jsrender">
        <button id="deleteButton" class="k-button wv-icon-button wv-cancel" 
            onclick="deleteClick()" title="Delete Makegood"><span class="wvi wvi-delete"></span></button>
    </script>
<script>
    //function isButtonDisabled(id) {
    //    var isDisabled = false;
    //    var btn = $("#" + id);
    //    if (btn) {
    //        isDisabled = $(btn).is(":disabled");
    //    }
    //    return isDisabled;
    //}
    //function enableButton(id) {
    //    window.setTimeout(function () {
    //        var btn = $("#" + id);
    //        if (btn) {
    //            $(btn).removeClass("k-state-disabled");
    //            $(btn).prop("disabled", false);
    //        }
    //    }, 10);
    //}
    //function disableButton(id) {
    //    window.setTimeout(function () {
    //        var btn = $("#" + id);
    //        if (btn) {
    //            $(btn).addClass("k-state-disabled");
    //            $(btn).prop("disabled", true);
    //        }
    //    }, 10);
    //}
    function cancelClick() {
        var treeObj = $("#TreeGridContainer").data("ejTreeGrid"); 
        if (treeObj) {
            treeObj.cancelRowEditCell(); 
        }
    }
    function updateMakegoodClick() {
        console.log("updateMakegoodClick");
        var treeObject = $("#TreeGridContainer").data("ejTreeGrid");
        treeObject.showEditDialog(3);
        //disableButton("deleteButton");
        //console.log(isButtonDisabled("deleteButton"));
    }
    function addMakegoodClick() {
        console.log("addMakegoodClick");
        //enableButton("deleteButton");
        //console.log(isButtonDisabled("deleteButton"));
   }
    function addReplacementClick() {
        console.log("addReplacementClick");
    }
    function viewClick() {
        console.log("viewClick");
    }
    function deleteClick() {
        console.log("deleteClick");
    }
    function toolbarClick(args) {
        //console.log("toolbarClick", args);
        if (args.itemName == "Delete Makegood" && isButtonDisabled("deleteButton") == false) {
            disableButton("deleteButton");
            enableButton("deleteButton");
        }
    }
    function create(args) {
    }
    $(document).ready(function () {
        //disableButton("addMakegoodButton");
        //disableButton("addReplacementButton");
        //disableButton("viewButton");
        //disableButton("deleteButton");
    })
</script>
