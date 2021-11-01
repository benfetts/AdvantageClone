@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner
@Code       ViewData("Title") = "Board Designer"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
<style>
    .container-table {
        width: 100%;
    }

    .left-cell {
        width: 200px;
        vertical-align: top;
    }

    .right-cell {
        vertical-align: top;
    }

    td {
        padding: 6px;
        vertical-align: top;
    }

    a {
        text-decoration: none !important;
    }
    #target {
        margin: 0 auto;
    }

    #target_WaitingPopup .e-image {
        display: block;
        height: 70px;
    }

    #popup {
        height: auto;
        width: auto;
        margin-top: 100px;
    }
    .e-kanban .e-kanbanheader .e-headercelldiv .e-headerOpen {
        font-family: Calibri,Tahoma, Verdana, Arial !important;
        font-size: 16px !important;
    }
    .e-kanban .e-kanbantoolbar .e-customtoolbar .e-tooltxt {
        border: 0px;
    }
</style>
@Html.EJ().WaitingPopup("target").ShowOnInit(False)
<div id="divHeader">
    <div id="gridToolBarWrap">
        @Code
            Dim TopToolBar = Html.Kendo().ToolBar.Name("TopToolBar")
            TopToolBar.Items(
                Sub(items)
                    items.Add().Id("SaveToolBarItem").Type(CommandType.Button).Click("buttonSaveBoardClick").Text("<span class='wvi wvi-floppy-disk'></span>").HtmlAttributes(New With {.title = "Save header information and default filter for workflow template", .class = "wv-icon-button wv-save"})
                    items.Add().Id("AddColumnToolBarItem").Text("New Column").Type(CommandType.Button).HtmlAttributes(New With {.title = "Add a new column to the board"}).Click("addDialog").Enable(Not Model.IsBasicBoard)
                    items.Add().Id("DeleteBoardToolBarItem").Type(CommandType.Button).Click("deleteBoardClick").Text("<span class='wvi wvi-delete'></span>").HtmlAttributes(New With {.title = Model.DeleteMessage, .class = "wv-icon-button wv-remove"}).Enable(Model.CanDeleteBoard)
                    items.Add().Id("RefreshToolBarItem").Text("").Type(CommandType.Button).Text("<span class='wvi wvi-rotate-right'></span>").HtmlAttributes(New With {.title = "Refresh", .class = "wv-icon-button wv-neutral"}).Click("reloadKanban")
                End Sub
            )
            TopToolBar.Events(
                Sub(e)
                End Sub)
            TopToolBar.Render()
        End Code
    </div>
    <div>
        <table style="width: 100%; margin: 10px 0px 0px 0px;">
            <colgroup>
                <col style="width:50%; padding: 6px; vertical-align:top;" />
                <col style="width:50%; padding: 6px; vertical-align:top;" />
            </colgroup>
            <tr>
                <td>
                    <div class="form-group" style="width:100%;">
                        <div>
                            Name:
                        </div>
                        <div>
                            @Html.TextBox("BoardName", Model.Header.Name, New With {.class = "e-textbox", .style = "width: 100%;"})
                        </div>
                    </div>
                    <div class="form-group" style="width:100%;">
                        <div>
                            Description:
                        </div>
                        <div>
                            @Html.TextArea("BoardDescription", Model.Header.Description, New With {.class = "e-textbox", .style = "width: 100%; height: 80px;"})
                        </div>
                    </div>
                    <div class="form-group">
                        <div>
                            Filter by Workflow Template:
                        </div>
                        <div>
                            @Html.EJ().DropDownList("AssignmentTemplates").Width("100%").Datasource(DirectCast(Model.AssignmentTemplates,
Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.AssignmentTemplate))).DropDownListFields(Function(F) F.Value("ID").Text("Name")).Value(Model.Header.AlertTemplateID).ClientSideEvents(Sub(evt)
                                                                                                                                                                                                                           evt.Change("filterChanged")
                                                                                                                                                                                                                           evt.Create("assignmentTemplatesCreate")
                                                                                                                                                                                                                       End Sub)
                        </div>
                    </div>
                    <div id="DivBoardOptions" class="form-group" style="width:100%; margin-top: -6px !important; padding-top: 0px !important;">
                        <div style="display:none !important;">
                            <div style="display:inline-block;">
                                @Html.EJ().CheckBox("CheckboxSequential").Value("IsSequential").Size(Size.Medium).Checked(Model.Header.IsSequential)
                                Must move in sequence
                            </div>
                            <div style="display:inline-block; margin: 0px 0px 0px 6px;">
                                @Html.EJ().CheckBox("CheckboxForceAllColumns").Value("ForceAllColumns").Size(Size.Medium).Checked(Model.Header.ForceAllColumns)
                                Must hit all columns
                            </div>
                        </div>

                        <div style="display:inline-block; margin: 0px 0px 0px 6px;">
                            @Html.EJ().CheckBox("CheckboxExcludeTasks").Value("ExcludeTasks").Size(Size.Medium).Checked(Model.Header.ExcludeTasks.GetValueOrDefault(False))
                            Exclude Tasks
                        </div>
                        <div style="display:inline-block;" title="Automatically add a comment when a card is moved from column to column">
                            @Html.EJ().CheckBox("CheckboxTrackChanges").Value("TrackChanges").Size(Size.Medium).Checked(If(Model.Header.TrackChanges IsNot Nothing, Model.Header.TrackChanges, False))
                            Track Changes
                        </div>
                        <div style="display:inline-block;" title="Send email when card is moved from column to column and comment is automatically added">
                            @Html.EJ().CheckBox("CheckboxEmailOnChange").Value("EmailOnChange").Size(Size.Medium).Checked(If(Model.Header.EmailOnChange IsNot Nothing, Model.Header.EmailOnChange, False))
                            Email On Change
                        </div>

                    </div>

                </td>
                <td><div>
                            &nbsp;
                        </div>
                    <div style="display:inline-block; margin: 0px 0px 0px 6px;">
                        <div style="position: relative; top: -6px;">
                        @Html.EJ().CheckBox("CheckboxIsActive").Value("IsActive").Size(Size.Medium).Checked(Model.Header.IsActive)
                            Active
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div style="margin: 10px 0px 20px 6px;display:none !important;">
        <button id="ButtonSaveBoard" class="k-button k-primary" onclick="buttonSaveBoardClick();">Save</button>
        <button id="ButtonAddColumn" style="margin: 0px 0px 0px 6px;" class="k-button k-primary" onclick="addDialog();">Add Column</button>
        <button id="ButtonReload" style="margin: 0px 0px 0px 6px; display: none !important;" class="k-button" onclick="reloadKanban();">Refresh</button>
    </div>
</div>
<script id="customCardTemplate" type="text/x-jsrender">
    <div style="min-height: 30px;">
        <div style="padding: 4px 0px 4px 8px;">
            <div style="display:inline-block;padding-top:1px;">
                {{:Title}}
            </div>
            <div style="display:inline-block; float: right; margin-right: 10px;">
                <span id='deletebutton{{:BoardHeaderID}}_{{:BoardColumnID}}_{{:StateID}}' style='margin-top: 4px; cursor: pointer;' class='glyphicon glyphicon-remove' title='Delete State' onclick='deleteState({{:BoardHeaderID}},{{:BoardColumnID}},{{:StateID}});'></span>
            </div>
        </div>
    </div>
</script>

<div id="divEditDialog">
    @Code
        Dim editDialog = Html.EJ().Dialog("EditDialog")
        editDialog.Title("Actions")
        editDialog.ShowHeader(False)
        editDialog.ShowFooter(False)
        editDialog.ShowOnInit(False)
        editDialog.ContentTemplate(Sub(content)
                                    @<div>
                                        <input type="hidden" id="editDialogBoardColumnId" name="editDialogBoardColumnId" value="">
                                        <input type="hidden" id="editDialogBoardColumnName" name="editDialogBoardColumnName" value="">
                                        <div>
                                            <div>
                                                Column Name:
                                            </div>
                                            <div>
                                                <input type="text" id="editDialogNewBoardName" name="editDialogNewBoardName" style="width: 100%;" maxlength="100" onfocus="this.select();" />
                                            </div>
                                            <div style="margin: 6px 0px 0px 0px;">
                                                <input type="button" id="editDialogRenameColumnButton" name="editDialogRenameColumnButton" onclick="editDialogRenameColumnButtonClick();" value="Save" class="k-button k-primary"  />
                                                <input style="display: none;" type="button" id="editDialogAddLeftButton" name="editDialogAddLeftButton" onclick="editDialogAddLeftButtonClick();" value="Add to left" class="k-button k-primary"  />
                                                <input style="display: none;" type="button" id="editDialogAddRightButton" name="editDialogAddRightButton" onclick="editDialogAddRightButton();" value="Add to right" class="k-button k-primary"  />
                                                <input type="button" id="editDialogCancelButton" name="editDialogCancelButton" onclick="editDialogCancelButton();" value="Cancel" class="k-button"  />
                                            </div>
                                            <div style="margin: 6px 0px 0px 0px; font-size:x-small; font-style:italic; display: none;">
                                                <ul>
                                                    <li>To rename:  Enter a new column name and click the "Rename Column" button</li>
                                                    <li style="display: none;">To add a column to the left:  Enter a new column name and click the "Add to left" button</li>
                                                    <li style="display: none;">To add a column to the right:  Enter a new column name and click the "Add to right" button</li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                       End Sub
                                                            )
        editDialog.Render()
    End Code
</div>
<div id="divAddDialog">
    @Code
        Dim addNewDialog = Html.EJ().Dialog("AddDialog")
        addNewDialog.Title("Add Column")
        addNewDialog.ShowHeader(True)
        addNewDialog.ShowFooter(False)
        addNewDialog.ShowOnInit(False)
        addNewDialog.ContentTemplate(Sub(content)
                                        @<div style="margin: 10px 0px 20px 0px;">
                                            <input type="hidden" id="addDialogBoardColumnId" name="addDialogBoardColumnId" value="">
                                            <input type="hidden" id="addDialogBoardColumnName" name="addDialogBoardColumnName" value="">
                                            <div>
                                                <div class="form-group">
                                                    <div>
                                                        <input placeholder="Enter column name" type="text" id="addDialogNewBoardName" name="addDialogNewBoardName" maxlength="100" style="width: 100%;" onfocus="this.select();" />
                                                    </div>
                                                </div>
                                                <div style="display: none !important;">
                                                    <div>
                                                        Colors:
                                                    </div>
                                                   <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width:50%; padding: 6px;">Header Text and Border</td>
                                                            <td style="width:50%; padding: 6px;">Background</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:50%; padding: 6px;">
                                                                @Html.EJ().ColorPicker("HeaderBoarderColor")
                                                            </td>
                                                            <td style="width:50%; padding: 6px;">
                                                                @Html.EJ().ColorPicker("BackgroundColor")
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div style="margin: 20px 0px 0px 0px;">
                                                    <input type="button" id="addDialogAddButton" name="addDialogAddButton" onclick="addDialogAddButtonButtonClick();" value="Add"  class="k-button k-primary" />
                                                    <input type="button" id="addDialogCancelButton" name="addDialogCancelButton" onclick="addDialogCancelButton();" value="Cancel"  class="k-button" />
                                                </div>
                                            </div>
                                        </div>
                                         End Sub)
        addNewDialog.Render()
    End Code
</div>
<script id="newStateTemplate" type="text/x-jsrender">
    <div style="display:none !important">
        <input type="hidden" id="BoardHeaderID" name="BoardHeaderID" value="@Model.BoardHeaderID" />
        <input type="hidden" id="BoardColumnID" name="BoardColumnID" value="{{:BoardColumnID}}" />
        <input type="hidden" id="StateID" name="StateID" value="{{:StateID}}" />
        <input type="hidden" id="IsEdit" name="IsEdit" value="0" />
        <div id="CurrentName" name="CurrentName" style="display:none !important;"></div>
    </div>
    <div>
        <div id="NewState">
            <input id="newStateName" placeholder="Enter new state name" type="text" maxlength="100" style="width: 240px;" />
        </div>
        <div id="EditState">
            <input id="EditStateName" type="text" maxlength="100" style="width: 240px;" />
        </div>
    </div>
</script>
<script id="customKanBanToolbar" type="text/x-jsrender">
    <table>
        <tr>
            <td><label class="custom">Available States:</label></td>
            <td><input type="text" id="statesDropDown" /></td>
        </tr>
    </table>
</script>
<div id="divKanBan" class="form-group">
    @Code

        Dim BaseURL = String.Format("{0}://{1}{2}{3}",
                                Request.Url.Scheme,
                                Request.Url.Authority,
                                Url.Content("~"),
                                Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)

        Dim kanbanbuilder = Html.EJ().Kanban("Kanban")
        kanbanbuilder.DataSource(Model.Cards)
        kanbanbuilder.KeyField("BoardColumnID")
        kanbanbuilder.Locale(Me.Locale)
        kanbanbuilder.AllowTitle(False)
        kanbanbuilder.AllowDragAndDrop(True)
        kanbanbuilder.AllowFiltering(True)
        kanbanbuilder.AllowHover(True)
        kanbanbuilder.AllowKeyboardNavigation(True)
        kanbanbuilder.AllowSelection(False)
        kanbanbuilder.AllowToggleColumn(False)
        kanbanbuilder.IsResponsive(True)
        kanbanbuilder.SelectionType(SelectionType.Single)
        kanbanbuilder.EnableTouch(True)
        kanbanbuilder.EnableTotalCount(False)
        kanbanbuilder.CssClass("custom-class")
        kanbanbuilder.ClientSideEvents(
             Sub(events)
                 events.CardDrop("cardDrop")
                 events.ActionBegin("actionBegin")
                 events.ActionComplete("actionComplete")
                 events.EndAdd("endAdd")
                 events.EndEdit("endEdit")
                 events.HeaderClick("headerClick")
                 events.CardDragStart("cardDragStart")
             End Sub)
        kanbanbuilder.Fields(
    Sub(field)
        field.PrimaryKey("ID")
        field.Title("Title")
        field.Content("Title")
        field.Priority("SequenceNumber")
    End Sub)
        kanbanbuilder.Columns(
            Sub(col)
                If Model.Columns IsNot Nothing Then

                    For Each Column As AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.DesignColumn In Model.Columns

                        If Column.BoardColumnID > 0 Then

                            If Model.IsBasicBoard = False Then

                                col.HeaderText(String.Format("<a class=""eCustomHeader{0}"" href=""#"" id=""rename"" onclick=""actions({0},'{1}');"" title=""Click for actions"">{1}</a>&nbsp;<span class=""glyphicon glyphicon-remove"" onclick=""deleteColumn({0},'{1}');"" title=""Click to delete this column"" style=""cursor: pointer;""></span>" &
                                                                          "&nbsp;<span class=""glyphicon glyphicon-arrow-left"" onclick=""moveColumn({0},'left');"" title=""Move column to left"" style=""cursor: pointer;""></span>" &
                                                                          "&nbsp;<span class=""glyphicon glyphicon-arrow-right"" onclick=""moveColumn({0},'right');"" title=""Move column to right"" style=""cursor: pointer;""></span>",
                                                                          Column.BoardColumnID,
                                                                          Column.Name)).Key(Column.BoardColumnID).ShowAddButton(True).IsCollapsed(False).Add()

                            Else

                                col.HeaderText(Column.Name).Key(Column.BoardColumnID).IsCollapsed(False).Add()

                            End If

                        Else

                            col.HeaderText(Column.Name).Key(Column.BoardColumnID).IsCollapsed(False).Add()

                        End If

                    Next

                End If
            End Sub)
        kanbanbuilder.StackedHeaderRows(
            Sub(rows)
            End Sub)
        kanbanbuilder.CardSettings(
            Sub(card)
                card.Template("#customCardTemplate")
            End Sub)
        kanbanbuilder.CustomToolbarItems(Sub(items)
                                             items.Template("#customKanBanToolbar")
                                         End Sub)
        kanbanbuilder.EditSettings(
        Sub(edit)
            edit.AllowAdding(True)
            edit.AllowEditing(True)
            edit.EditMode(KanbanEditMode.DialogTemplate)
            edit.DialogTemplate("#newStateTemplate")
        End Sub)
        kanbanbuilder.ContextMenuSettings(
            Sub(context)
                context.Enable(False)
            End Sub)
        kanbanbuilder.TooltipSettings(
            Sub(tooltip)
            End Sub)
        kanbanbuilder.Render()

    End Code
</div>
<script type="text/javascript">
    var boardId = @Html.Raw(Model.BoardHeaderID) * 1;
    function deleteState(boardHeaderId, boardColumnId, stateId) {
        var msg = "Remove?";
        var alertTemplateId = getSelectedTemplateId();
        //console.log(alertTemplateId)
        //console.log(boardColumnId)
        if (alertTemplateId == -1) {
            if (boardColumnId == -3) {
                msg = "Delete state?"
            }
            if (boardColumnId > 0) {
                msg = "Remove from column?"
            }
        }
        if (alertTemplateId > 0) {
            if (boardColumnId == -3) {
                msg = "Remove from template?"
            }
            if (boardColumnId > 0) {
                msg = "Remove from column?"
            }
        }
        showKendoConfirm(msg)
            .done(function () {
                var data = {
                    BoardHeaderID: boardHeaderId,
                    BoardColumnID: boardColumnId,
                    StateID: stateId,
                    AlertTemplateID: getSelectedTemplateId()
                };
                //console.log(data);
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/DesignDeleteState",
                    dataType: "json",
                    data: data
                }).always(function (result) {
                    //console.log(result);
                    if (result) {
                        //console.log(result.Success);
                        //console.log(result.Message);
                        //console.log(result.Data);
                        if (result.Success && result.Success == true && result.Data) {
                            $("#Kanban").ejKanban({ dataSource: result.Data });
                            window.scrollTo(0, 0);
                        } else {
                            if (result.Message && result.Message != "") {
                                showKendoAlert(result.Message);
                            }
                        }
                    }
                });
            })
            .fail(function () {
            });
    }
    function filterChanged(args) {
        //console.log("filterChanged")
        var selectedTemplateId = -1;
        if (args && args.value) {
            selectedTemplateId = args.value * 1;
        } else {
            selectedTemplateId = getSelectedTemplateId();
        }
        var filterData = {
            BoardID: boardId,
            AlertTemplateID: selectedTemplateId
        };
        //console.log(filterData)
        $.post({
            url: window.appBase + "ProjectManagement/Agile/DesignFilter",
            dataType: "json",
            data: filterData
        }).always(function (result) {
            $("#Kanban").ejKanban({ dataSource: result });
            window.scrollTo(0, 0);
         });
        setBasicBoard();
    }
    function getSelectedTemplateId() {
        //console.log("getSelectedTemplateId")
        var selectedTemplateId = -1;
        var assignmentTemplates = $('#AssignmentTemplates').data("ejDropDownList");
        if (assignmentTemplates) {
            if (assignmentTemplates.option("value")) {
                selectedTemplateId = assignmentTemplates.option("value") * 1;
            }
        }
        return selectedTemplateId;
    }
    function isBasicBoard() {
        var yesItIs = false;
        var boardName = $("#BoardName").val();
        //var assignmentTemplates = $('#AssignmentTemplates').data("ejDropDownList");
        //if (assignmentTemplates) {
        //    if (assignmentTemplates.option("text") && assignmentTemplates.option("text") == "Basic Board") {
        //        yesItIs = true;
        //    }
        //}
        if (yesItIs == false && boardName && boardName == "Basic Board") {
            //console.log("isBasicBoard " + boardName)
            //console.log("isBasicBoard " + yesItIs)
            yesItIs = true;
        }
        return yesItIs;
    }
    function setBasicBoard() {
        if (isBasicBoard() == true) {
            //console.log($("#TopToolBar").kendoToolBar().items[0])
            //$("#SaveToolBarItem").removeClass("k-button").addClass("k-button-disabled");
            $("#BoardName").attr("readonly", "true");
            $("#BoardDescription").attr("readonly", "true");
            $("#CheckboxSequential").ejCheckBox({ enabled: false, checked: false });
            $("#CheckboxForceAllColumns").ejCheckBox({ enabled: false, checked: false });
        } else {
            //$("#BoardName").attr("readonly", "false");
            //$("#BoardDescription").attr("readonly", "false");
            $("#BoardName").removeAttr("readonly");
            $("#BoardDescription").removeAttr("readonly");
            $("#CheckboxSequential").ejCheckBox({ enabled: true });
            $("#CheckboxForceAllColumns").ejCheckBox({ enabled: true });
        }
    }
    function assignmentTemplatesCreate(args) {
        setBasicBoard();
    }
    function buttonSaveBoardClick(e, ui) {
        //if (isBasicBoard() == false) {
            var boardName = $("#BoardName").val();
            var boardDescription = $("#BoardDescription").val();
            var selectedAssignmentTemplate = $("#AssignmentTemplates")[0].value;
            var isSequential = $("#CheckboxSequential").ejCheckBox("instance").option("checked");
            var forceAllColumns = $("#CheckboxForceAllColumns").ejCheckBox("instance").option("checked");
            var excludeTasks = $("#CheckboxExcludeTasks").ejCheckBox("instance").option("checked");
            var isActive = $("#CheckboxIsActive").ejCheckBox("instance").option("checked");
            var trackChanges = $("#CheckboxTrackChanges").ejCheckBox("instance").option("checked");
            var emailOnChange = $("#CheckboxEmailOnChange").ejCheckBox("instance").option("checked");
            if (boardName == "") {
                showKendoAlert("Please enter a board name")
            } else {
                var data = {
                    BoardHeaderID: boardId,
                    BoardName: boardName,
                    BoardDescription: boardDescription,
                    AlertTemplateID: selectedAssignmentTemplate,
                    IsSequential: isSequential,
                    ForceAllColumns: forceAllColumns,
                    ExcludeTasks: excludeTasks,
                    IsActive: isActive,
                    TrackChanges: trackChanges,
                    EmailOnChange: emailOnChange
                };
                kendo.ui.progress($('body'), true);
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/UpdateBoardHeader",
                    dataType: "json",
                    data: data
                }).always(function (response) {
                    kendo.ui.progress($('body'), false);
                    if (response) {
                        //console.log(response);
                        if (response.Success && response.Success === true) {
                            showSuccessNotification('Board Saved');
                            window.scrollTo(0, 0);
                            //location.reload();
                            //filterChanged();
                        }
                        if (response.Success && response.Success === false && response.Message) {
                            showKendoAlert("Error in action: UpdateBoardHeader" + "<br/>" + response.Message);
                        }
                    }
                });
            }
        //} else {
        //    showKendoAlert("Cannot change header information for Basic Board");
        //}
    }
    $(function () {
        //var assignmentTemplates = $('#AssignmentTemplates').data("ejDropDownList");
        //console.log(assignmentTemplates)
        //if (assignmentTemplates) {
        //    if (assignmentTemplates.option("text") == "Basic Board") {
        //        setBasicBoard(false);
        //    } else {
        //        setBasicBoard(true);
        //    }
        //}
        $("#BoardName").select().focus();

        $("#addDialogNewBoardName").keyup(function (event) {
            if (event.keyCode === 13) {
                $("#addDialogAddButton").click();
            }
        });
        $("#newStateName").keyup(function (event) {
            if (event.keyCode === 13) {
                addDesignState();
            }
        });
    });
    function reloadKanban() {
       var selectedTemplateId = -1;
       selectedTemplateId = getSelectedTemplateId();
        var data = {
            BoardID: boardId,
            AlertTemplateID: selectedTemplateId
        };
        //console.log(data)
        $.post({
            url: window.appBase + "ProjectManagement/Agile/DesignReload",
            dataType: "json",
            data: data
        }).always(function (result) {
            if (result) {
                //console.log(result)
                var colss = [];
                var arrayLength = result.Columns.length;
                var thisKey = "";
                var showAdd = false;
                for (var i = 0; i < arrayLength; i++) {
                    if (isNaN(result.Columns[i].key) == false && result.Columns[i].key * 1 > 0) {
                        showAdd = true;
                    } else {
                        showAdd = false;
                    }
                    colss.push({ headerText: result.Columns[i].headerText, key: result.Columns[i].key + "", showAddButton: showAdd })
                }
                $("#Kanban").ejKanban({
                    columns: colss,
                    dataSource: result.Cards
                });
                window.scrollTo(0, 0);
            }
        });
    }
    function headerClick(args){
		var obj = $("#Kanban").data("ejKanban");
		var columns = obj.model.columns;
		for (var i=0; i< columns.length; i++){
		    if(obj.getHeaderTable().find(".e-headercell").eq(i).hasClass("e-shrinkcol")){
			    var key = $(obj.element.find(".e-columnrow")).find('td[ej-mappingkey="'+columns[i].key+'"]');
				for(var j=0;j< key.length; j++){
			        key.eq(j).find(".e-shrinklabel").css("display", "none")
				}
			}
		}
    }

    function actionBegin(args) {
        if (args && args.requestType) {
            //console.log("actionBegin requestType: ", args.requestType)
            if (args.data) {
                if (args.requestType === "add") {
                    var boardColumnId = 0;
                    if (args.data.BoardColumnID) {
                        boardColumnId = args.data.BoardColumnID * 1;
                    }
                    if (boardColumnId == -2 || boardColumnId == -3) {
                        args.cancel = true;
                    }
                }
                if (args.requestType === "beginedit") {
                    var stateId = 0;
                    if (args.data.StateID) {
                        stateId = args.data.StateID * 1;
                    }
                    if (stateId > 0) {
                       //console.log("edit", args)
                    }
                } 
            }
        }
    }
    function actionComplete(args) {
        var obj = $("#Kanban").data("ejKanban");
        // Dynamic coloring
        try {
            for (var i = 0; i < args.model.columns.length; i++) {
                var key = args.model.columns[i].key;
                //if (key[0] == "-1" || key[0] == "-2" || key[0] == "-3") {
                obj.getContentTable().find(".e-columnrow td[ej-mappingkey=" + key + "]").addClass("eCustom" + key);
                obj.getHeaderTable().find(".e-headerdiv").eq(i).addClass("eCustomHeader" + key);
                //}
            }
        } catch (e) {}
        // Dialogs
        if (args.model.editSettings.editMode == "dialogtemplate"){
            if (args.requestType == "add") {
                $("#" + this._id + "_dialogEdit").ejDialog({ title: "Add" });
                $("#NewState").show();
                $("#EditState").hide();
                $("#IsEdit").val("0");
            }
            if (args.requestType == "beginedit") {
                $("#" + this._id + "_dialogEdit").ejDialog({ title: "Edit" });
                $("#NewState").hide();
                $("#EditState").show();
                $("#IsEdit").val("1");
                $("#EditStateName").val(args.data["Title"]);
                $("#CurrentName").html(args.data["Title"]);
            }
            if (args.requestType == "save") {
                if ($("#IsEdit").val() * 1 == 0) {
                    if (addDesignState() == false) {
                        args.cancel = true;
                        return false;
                    } else {
                        reloadKanban();
                    }
                } else {
                    if (editState() == false) {
                        args.cancel = true;
                        return false;
                    } else {
                        reloadKanban();
                    }
                }
            }
        }
    }
    function addDesignState() {
        var boardId = 0;
        var columnId = 0;
        var stateName = "";
        var assignmentTemplateId = 0;
        var assignmentTemplates = $('#AssignmentTemplates').data("ejDropDownList");

        boardId = $("#BoardHeaderID").val() * 1;
        columnId = $("#BoardColumnID").val() * 1;
        stateName = $("#newStateName").val();
        assignmentTemplateId = assignmentTemplates.option("value");

        if (!stateName || stateName.trim() == "") {
            showKendoAlert("No state name entered");
            return false;
        } else {
            var dataNewCard = {
                BoardHeaderID: boardId,
                BoardColumnID: columnId,
                StateName: stateName,
                AssignmentTemplateID: assignmentTemplateId
            };
            $.post({
                url: window.appBase + "ProjectManagement/Agile/AddDesignState",
                dataType: "json",
                data: dataNewCard
            }).always(function (response) {
                if (response) {
                    if (response.Success && response.Success === true) {
                        //reloadKanban();
                        return true;
                    }
                    if (response.Success && response.Success === false && response.Message) {
                        showKendoAlert("Error in action: AddDesignState\n" + response.Message);
                        return false;
                    }
                }
            });
        }
    }
    function editState() {
        var stateId = 0;
        var stateName = "";
        var oldStateName = "";
        stateId = $("#StateID").val() * 1;
        stateName = $("#EditStateName").val();
        oldStateName = $("#CurrentName").html();
        if (!stateName || stateName.trim() == "") {
            showKendoAlert("No state name entered");
            return false;
        } else {
            if (stateName != oldStateName) {
                var dataEdit = {
                    StateID: stateId,
                    StateName: stateName
                };
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/UpdateStateName",
                    dataType: "json",
                    data: dataEdit
                }).always(function (response) {
                    if (response) {
                        if (response.Success && response.Success === true) {
                            reloadKanban();
                            return true;
                        }
                        if (response.Success && response.Success === false && response.Message) {
                            showKendoAlert("Error in action: UpdateStateName\n" + response.Message);
                            return false;
                        }
                    }
                });
            } else {
                return false;
            }
        }
    }
    function endAdd(args) {
        //console.log(args)
    }
    function endEdit(args) {
        //console.log(args)
    }
    function showWaitingPopUp() {
        var popup = $("#target").data("ejWaitingPopup");
        popup.show();
    }
    function hideWaitingPopUp() {
        var popup = $("#target").ejWaitingPopup("hide");
    }
    function cardDragStart(args) {
        //console.log(args)
    }
    function cardDrop(args){
        if (args.draggedElement.parent()) {
            //console.log(args.draggedElement.parent())
            //console.log(args.data[0])
            var stateId = 0;
            var boardDetailId = 0;
            var targetBoardColumnID = args.draggedElement.parent().attr("data-ej-mappingkey") * 1;
            if (args.data[0]) {
                //console.log(args.data[0])
                boardDetailId = args.data[0].ID * 1;
                stateId = args.data[0].StateID * 1;
                var data = {
                    BoardHeaderID: args.data[0].BoardHeaderID,
                    BoardColumnID: args.data[0].BoardColumnID,
                    TargetBoardColumnID: targetBoardColumnID,
                    StateID: stateId,
                };
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/DesignMoveStateCard",
                    dataType: "json",
                    data: data
                }).always(function (response) {
                    if (response) {
                        filterChanged(null);
                        //console.log(response);
                        //if (response.Success && response.Success === true) {
                        //    args.data[0].BoardColumnID = args.draggedElement.parent().attr("data-ej-mappingkey")
                        //    //alert ("Success!");
                        //}
                        //if (response.Success && response.Success === false && response.Message) {
                        //    alert ("Error in action: DesignMoveStateCard\n" + response.Message);
                        //}
                        //if (response.Data) {
                        //}
                    }
                    });
            }
            args = null;
        }
    }
    function saveBoardHeader() {
        showKendoAlert("saveBoardHeader");
    }
    function addDialog() {
        $("#addDialogNewBoardName").focus();
        $("#AddDialog").ejDialog("open");
    }
    function addDialogCancelButton() {
        $("#AddDialog").ejDialog("close");
    }
    function addDialogAddButtonButtonClick() {
        //showWaitingPopUp();
        var assignmentTemplateId = 0;
        var assignmentTemplates = $('#AssignmentTemplates').data("ejDropDownList");
        assignmentTemplateId = assignmentTemplates.option("value") * 1;
        var data = {
            BoardID: boardId,
            BoardColumnID: 0,
            Direction: "right",
            NewColumnName: $("#addDialogNewBoardName").val(),
            AlertTemplateID: assignmentTemplateId
        };
        //console.log(data);
        /*
        */
        $.post({
            url: window.appBase + "ProjectManagement/Agile/AddDesignColumn",
            dataType: "json",
            data: data
        }).always(function (result) {
            if (result) {
                reloadKanban();
                //filterChanged(null);
                $("#addDialogNewBoardName").val(null)
                $("#AddDialog").ejDialog("close");
                //location.reload();
                //filterChanged();
            }
        });
    }
    function addRight(columnId) {
        showKendoAlert("addRight clicked " + columnId)
    }
    function addLeft(columnId) {
        showKendoAlert("addLeft clicked " + columnId)
    }
    function moveRight(columnId) {
        showKendoAlert("moveRight clicked " + columnId)
    }
    function moveLeft(columnId) {
        showKendoAlert("moveLeft clicked " + columnId)
    }
    function actions(columnId, columnName) {
        $("#editDialogBoardColumnId").text(columnId);
        $("#editDialogBoardColumnName").text(columnName);
        $("#editDialogNewBoardName").val(columnName);
        $("#EditDialog").ejDialog("open");
    }
    function deleteColumn(columnId, columnName) {
        showKendoConfirm("Delete  this column?")
            .done(function () {
                var data = {
                    BoardID: boardId,
                    BoardColumnID: columnId
                };
                //console.log(data);
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/DeleteColumn",
                    dataType: "json",
                    data: data
                }).always(function (response) {
                    if (response) {
                        if (response.Success == true) {
                            reloadKanban();
                        }
                        if (response.Success == false && response.Message != "") {
                            showKendoAlert(response.Message);
                        }
                    }
                });
            })
            .fail(function () {
            });
    }
    function editDialogRenameColumnButtonClick() {
        var currentColumnId = 0;
        var inputText = "";
        var originalText = "";
        currentColumnID = $("#editDialogBoardColumnId").text();
        originalText = $("#editDialogBoardColumnName").text();
        inputText = $("#editDialogNewBoardName").val();
        if (originalText == inputText) {
            showKendoAlert("Please choose a different name");
            $("#editDialogNewBoardName").focus();
        } else {
            renameColumn(currentColumnID, inputText);
        }
    }
    function editDialogAddLeftButtonClick() {
        var currentColumnId = 0;
        var inputText = "";
        var originalText = "";
        currentColumnID = $("#editDialogBoardColumnId").text();
        originalText = $("#editDialogBoardColumnName").text();
        inputText = $("#editDialogNewBoardName").val();
        if (originalText == inputText) {
            showKendoAlert("Please choose a different name");
            $("#editDialogNewBoardName").focus();
        } else {
            showKendoAlert(currentColumnID);
            showKendoAlert(inputText);
        }
    }
    function editDialogAddRightButton() {
        var currentColumnId = 0;
        var inputText = "";
        var originalText = "";
        currentColumnID = $("#editDialogBoardColumnId").text();
        originalText = $("#editDialogBoardColumnName").text();
        inputText = $("#editDialogNewBoardName").val();
        if (originalText == inputText) {
            showKendoAlert("Please choose a different name");
            $("#editDialogNewBoardName").focus();
        } else {
            showKendoAlert(currentColumnID);
            showKendoAlert(inputText);
        }
    }
    function editDialogCancelButton() {
        $("#EditDialog").ejDialog("close");
    }
    function moveToLeft(boardColumnId) {
        moveColumn(boardColumnId, "left");
    }
    function moveToRight(boardColumnId) {
        moveColumn(boardColumnId, "right");
    }
    function moveColumn(boardColumnId, direction) {
        //console.log("moveColumn");
        var data = {
            BoardID: boardId,
            BoardColumnID: boardColumnId,
            Direction: direction,
        };
        //console.log(data);
        $.post({
            url: window.appBase + "ProjectManagement/Agile/MoveColumn",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                if (response.Success && response.Success === true) {
                    reloadKanban();
                    //location.reload();
                    //filterChanged();
                }
                if (response.Success && response.Success === false && response.Message) {
                    alert ("Error in action: moveColumn\n" + response.Message);
                }
                if (response.Data) {
                    //response.Data.BoardColumnID;
                }
            }
        });
    }
    function renameColumn(boardColumnId, newName) {
        //console.log("renameColumn");
        var data = {
            BoardID: boardId,
            BoardColumnID: boardColumnId,
            NewName: newName,
        };
        //console.log(data);
        $.post({
            url: window.appBase + "ProjectManagement/Agile/RenameColumn",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                if (response.Success && response.Success === true) {
                    reloadKanban();
                    $("#EditDialog").ejDialog("close");
                    //location.reload();
                    //filterChanged();
                }
                if (response.Success && response.Success === false && response.Message) {
                    alert ("Error in action: renameColumn\n" + response.Message);
                }
                if (response.Data) {
                    //response.Data.BoardColumnID;
                }
            }
        });
    }
    function deleteBoardClick() {
        showKendoConfirm("Delete  board?")
            .done(function () {
                var data = {
                    BoardHeaderID: boardId
                };
                //console.log(data);
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/DesignDeleteBoard",
                    dataType: "json",
                    data: data
                }).always(function (result) {
                    //console.log(result);
                    if (result) {
                        if (result.Success && result.Success == true) {
                            RefreshWindow("ProjectManagement/Agile/Boards", true, false);
                            CloseThisWindow();
                        } else {
                            if (result.Message && result.Message != "") {
                                showKendoAlert(result.Message);
                            }
                        }
                    }
                });
            })
            .fail(function () {
            });
    }
</script>
