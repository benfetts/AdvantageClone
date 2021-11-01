@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard
@Code

    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section


<style>
    .container-table {
        width: 100%;
    }

    .left-cell {
        width: 200px;
    }

    .right-cell {
    }
</style>

<div id="gridToolBarWrap">
    @Code
        Dim CanUpdate As Boolean = False
        Dim CanPrint As Boolean = False
        If ViewData("CanUpdate") IsNot Nothing AndAlso ViewData("CanUpdate") = True Then
            CanUpdate = True
        End If
        If ViewData("CanPrint") IsNot Nothing AndAlso ViewData("CanPrint") = True Then
            CanPrint = True
        End If

        Dim TopToolBar = Html.Kendo().ToolBar.Name("TopToolBar")
        TopToolBar.Items(
Sub(items)
    'If CanUpdate = True Then
    items.Add().Id("toolBarButtonCompleteReopen").Type(CommandType.Button).Click("openCloseSprint").Enable(CanUpdate)
    'End If

    items.Add().Id("toolBarButtonEdit").Type(CommandType.Button).Click("editSprint").Text("<span class='wvi wvi-pencil'></span>").HtmlAttributes(New With {.title = "Edit Sprint", .class = "wv-icon-button wv-neutral"})
    items.Add().Id("toolBarButtonReorderByDueDate").Type(CommandType.Button).Click("reorderByDueDate").Text("Reorder").HtmlAttributes(New With {.title = "Remove custom ordering.  Click to see options."})
    items.Add().Id("toolBarButtonStartStopSprint").Type(CommandType.Button).Text("StartStop").Click("stopStartSprint").Enable(CanUpdate)

    items.Add().Type(CommandType.Separator)
    items.Add().Type(CommandType.Button).Click("printKanBan").Text("<span class='wvi wvi-printer'></span>").HtmlAttributes(New With {.title = "Print", .class = "k-button wv-icon-button "}).Enable(CanPrint)
    items.Add().Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .class = "k-button wv-icon-button"}).Text("<span class='wvi wvi-refresh'></span>").Click("reloadWindow")

    items.Add().Type(CommandType.Separator)
    items.Add().Type(CommandType.Button).Click("goBack").Text("<span class='wvi wvi-arrow_left'></span>").HtmlAttributes(New With {.title = "Go Back", .class = "wv-icon-button wv-neutral"})

    items.Add().Type(CommandType.Separator)

    items.Add().Type(CommandType.ButtonGroup).Buttons(Sub(b)

                                                          b.Add().Text("Default View").Togglable(True).Group("CardView").Selected(True).Id("card-view-standard")
                                                          b.Add().Text("Full View").Togglable(True).Group("CardView").Id("card-view-full")
                                                          b.Add().Text("Summary View").Togglable(True).Group("CardView").Id("card-view-summary")

                                                      End Sub)
    items.Add().Type(CommandType.Separator)
    items.Add().Type(CommandType.Button).Click("bookmarkSprint").Text("<span class='wvi wvi-book-bookmark'></span>").HtmlAttributes(New With {.title = "Bookmark this sprint", .class = " k-button wv-icon-button "})

End Sub
)
        TopToolBar.Events(
    Sub(e)
        e.Toggle("TopToolBarToggle")
    End Sub)
        TopToolBar.Render()


    End Code
    <script>
        var sprintId = @Html.Raw(Model.SprintHeader.ID) * 1;
        var boardId = @Html.Raw(Model.Board.ID);
        var editURL = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)NewSprint/0" + "/" + @Html.Raw(ViewData("SprintID"));
        var goBackURL = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)AgileBoard/" + boardId;
        var thisSprintId = sprintId;
        function showProgress() {
            //kendo.ui.progress($("body"), true);
        }
        function hideProgress() {
            //kendo.ui.progress($("body"), false);
        }
        function reorderByDueDate() {
            $("#CheckboxReorderBacklog").ejCheckBox({ checked: false });
            $("#CheckboxReorderBoard").ejCheckBox({ checked: false });
            $("#ReorderByDueDateDialog").ejDialog("open");
        }
        function printKanBan() {
            $("#Kanban").ejKanban("print");
        }
        function TopToolBarToggle(e) {
            if (e.group === 'CardView') {
                $('#Kanban').removeClass(function (index, className) {
                    return (className.match(/(^|\s)card-view-\S+/g) || []).join(' ');
                }).addClass(e.id);
            }
        }
        function canEdit() {
            if ($("#toolBarButtonCompleteReopen")[0].text == "Complete") {
                return true
            } else {
                return false;
            }
        }
        function stopStartSprint(args) {
            if (canEdit() == true) {
                if (args.target[0].text == "Stop") {
                    stopSprint();
                } else {
                    startSprint();
                }
            } else {
                showKendoAlert("Cannot start/stop completed sprint")
                return false;
            }
        }
        function stopSprint(){
            showKendoConfirm("Stop sprint?")
                .done(function () {
                    if (sprintId) {
                        showProgress();
                        var stopSprintData = {
                            SprintID: sprintId
                        };
                        $.post({
                            url: window.appBase + "ProjectManagement/Agile/StopSprint",
                            dataType: "json",
                            data: stopSprintData
                        }).always(function (result) {
                            if (result) {
                                if (result.Success && result.Success == true) {
                                    //$("#active_indicator").removeClass("active-sprint").addClass("inactive-sprint")
                                    setSprintIsActive(false);
                                    //showKendoAlert("Stopped!")
                                }
                            }
                            hideProgress();
                        });
                    }
                })
                .fail(function () {
                });
        }
        function startSprint(){
            showKendoConfirm("Start sprint?")
                .done(function () {
                    if (sprintId) {
                        showProgress();
                        var startSprintData = {
                            SprintID: sprintId,
                            IncludeSprintList: false,
                            IncludeCompleted: false
                        };
                        $.post({
                            url: window.appBase + "ProjectManagement/Agile/StartSprint",
                            dataType: "json",
                            data: startSprintData
                        }).always(function (result) {
                            if (result) {
                                if (result.Success == true) {
                                    setSprintIsActive(true);
                                }
                                if (result.Success == false) {
                                    showKendoAlert(result.Message)
                                }
                            }
                            hideProgress();
                        });
                    }
                })
                .fail(function () {
                });
        }
        function openCloseSprint(args) {
            if (args.target[0].text == "Complete") {
                completeSprint();
            } else {
                reopenSprint();
            }
        }
        function completeSprint(){
            $("#CompleteSprintDialog").ejDialog("open");
        }
        function reopenSprint(){
            showKendoConfirm("Reopen sprint?")
                .done(function () {
                    if (sprintId) {
                        showProgress();
                        var startSprintData = {
                            SprintID: sprintId
                        };
                        $.post({
                            url: window.appBase + "ProjectManagement/Agile/ReopenSprint",
                            dataType: "json",
                            data: startSprintData
                        }).always(function (result) {
                            if (result) {
                                if (result.Success && result.Success == true) {
                                    setSprintComplete(false);
                                    var kanbanObj = $("#Kanban").data("ejKanban");
                                    kanbanObj.refresh(true);
                                    var completedColumn = kanbanObj.getColumnByHeaderText("Completed");
                                    completedColumn.allowDrag = true;
                                    completedColumn.allowDrop = true;
                                    //console.log(completedColumn)
                                    //$("#Kanban").ejKanban("refresh", true);
                                    //$('#Kanban').data('ejKanban').refresh(true);
                                    window.scrollTo(0, 0);
                                    //console.log($('#Kanban').data('ejKanban'))
                                }
                            }
                            hideProgress();
                        });
                    }
                })
                .fail(function () {
                });
        }
        function bookmarkSprint() {
            if (sprintId) {
                showProgress();

                var empInput = $('#FilterEmployees').data('kendoMultiSelect');
                var emps = empInput.value();

                var sprintData = {
                    SprintID: sprintId,
                    Employees: emps
                };
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/BookmarkSprint",
                    dataType: "json",
                    data: sprintData
                }).always(function (result) {
                    hideProgress();
                    showKendoAlert(result.message);
                });
            }
        }
        function editSprint() {
            if (canEdit() == true) {
                $("#EditSprintDialog").ejDialog({
                    contentUrl: editURL
                });
                $("#EditSprintDialog").ejDialog("open");
            } else {
                showKendoAlert("Cannot edit completed sprint")
                return false;
          }
        }
        function saveSprint(){
            document.getElementById("saveHeaderButton").click();
        }
        function reloadWindow(){
            location.reload();
        }
        function goToURL(url){
            if (url) {
                window.location.assign(url);
            } else {
                reloadWindow();
            }
        }
        function goBack(){
            window.location.assign(goBackURL);
        }
        function setSprintIsActive(isActive) {
            if (isActive == "true") {
                isActive = true;
            }
            if (isActive == true) {
                $("#TopToolBar").removeClass("inactive-sprint").removeClass("load-sprint").addClass("active-sprint")
                $("#toolBarButtonStartStopSprint")[0].text = "Stop"
                $("#toolBarButtonStartStopSprint")[0].title = "Sprint is active.  Click to stop this sprint"
            } else {
                $("#TopToolBar").removeClass("active-sprint").removeClass("load-sprint").addClass("inactive-sprint")
                $("#toolBarButtonStartStopSprint")[0].text = "Start"
                $("#toolBarButtonStartStopSprint")[0].title = "Sprint is not active.  Click to start this sprint"
            }
        }
        function setSprintComplete(isComplete) {
            if (isComplete == "true") {
                isComplete = true;
            }
            if (isComplete == true) {
                $("#toolBarButtonCompleteReopen")[0].text = "Reopen"
                $("#toolBarButtonCompleteReopen")[0].title = "Reopen this sprint"
                //$("#toolBarButtonEdit").hide();
                //$("#toolBarButtonStartStopSprint").hide();
            } else {
                $("#toolBarButtonCompleteReopen")[0].text = "Complete"
                $("#toolBarButtonCompleteReopen")[0].title = "Complete this sprint"
           }
        }
        function closeDialogs() {
            closeEditSprintDialog();
        }
        function closeEditSprintDialog() {
            $("#EditSprintDialog").ejDialog("close");
        }
        function checkSprintActiveComplete(sprintId, sprintIsActive, sprintIsComplete) {
            if (sprintId = thisSprintId) {
                if (sprintIsActive) {
                    setSprintIsActive(sprintIsActive);
                }
                if (sprintIsComplete) {
                    setSprintComplete(sprintIsComplete);
                }
            }
        }
        $(function () {
            var sprintActive = false;
            var sprintComplete = false;
            sprintActive = @Html.Raw(If(Model.SprintHeader.IsActive IsNot Nothing, Model.SprintHeader.IsActive.ToString.ToLower, "false"));
            sprintComplete = @Html.Raw(If(Model.SprintHeader.IsComplete IsNot Nothing, Model.SprintHeader.IsComplete.ToString.ToLower, "false"));
            setSprintIsActive(sprintActive);
            setSprintComplete(sprintComplete);
        });
    </script>
</div>
@Code

    Dim EditSprintDialog = Html.EJ().Dialog("EditSprintDialog")
    EditSprintDialog.Title("Edit Sprint")
    EditSprintDialog.ShowOnInit(False)
    EditSprintDialog.ContentType("iframe")
    EditSprintDialog.Height("600px")
    EditSprintDialog.Render()

    Dim CompleteSprintDialog = Html.EJ().Dialog("CompleteSprintDialog")
    CompleteSprintDialog.Title("Complete Sprint?")
    CompleteSprintDialog.ShowOnInit(False)
    CompleteSprintDialog.ContentTemplate(Sub()
                                            @<div style="padding: 10px 0px 0px 0px;">
                                                <div>
                                                    @Html.EJ().RadioButton("RadioButtonBackToBacklog").Name("CompleteOptions").Value("BackToBacklog")&nbsp;&nbsp;Put In Progress items back to Backlog 
                                                </div>
                                                <div style="margin-top: 4px;">
                                                    @Html.EJ().RadioButton("RadioButtonLeaveInState").Name("CompleteOptions").Value("LeaveInCurrentState").Checked(True)&nbsp;&nbsp;Leave In Progress items in current State
                                                </div>
                                                <div style="margin-top: 10px; margin-bottom: 10px; width: 100%; text-align: right;">
                                                    <button id="ButtonSave" class="k-button k-primary" onclick="saveComplete();">Save</button>
                                                    <button id="ButtonCancel" class="k-button" onclick="cancelComplete();">Cancel</button>
                                                </div>
                                            </div>
                                                 End Sub)
    CompleteSprintDialog.Render()

    Dim ReorderByDueDateDialog = Html.EJ().Dialog("ReorderByDueDateDialog")
    ReorderByDueDateDialog.Title("Reorder Cards")
    ReorderByDueDateDialog.ShowOnInit(False)
    ReorderByDueDateDialog.ContentTemplate(Sub()
                                            @<div style="padding: 10px 0px 0px 0px;">
                                                 <div class="alert alert-warning" role="alert" title="Permanently remove any saved custom ordering and reset order back to default">
                                                     <strong>Warning!</strong>&nbsp;&nbsp;This will remove all prior manual ordering.
                                                 </div>                                              
                                                 <div title="Remove any custom ordering from backlog and reset backlog back to default order">
                                                     @Html.EJ().CheckBox("CheckboxReorderBacklog").Value("ReorderBacklog").Size(Size.Medium)
                                                     Remove manual ordering from backlog
                                                 </div>
                                                 <div style="margin-top: 4px;" title="Remove any custom ordering from board columns and reset board columns back to default order">
                                                     @Html.EJ().CheckBox("CheckboxReorderBoard").Value("ReorderBoard").Size(Size.Medium)
                                                     Remove manual ordering from board
                                                 </div>
                                                <div style="margin-top: 10px; margin-bottom: 10px; width: 100%; text-align: right;">
                                                    <div class="k-button-group">
                                                        <button id="ButtonSaveReorderByDueDateDialog" class="k-button k-primary" onclick="saveReorderByDueDate();">Save</button>
                                                        <button id="ButtonCancelReorderByDueDateDialog" class="k-button" onclick="cancelReorderByDueDate();">Cancel</button>
                                                    </div>
                                                </div>
                                            </div>
                                                   End Sub)
    ReorderByDueDateDialog.Render()

End Code
<script>
    var sprintId = @Html.Raw(Model.SprintHeaderID);
    function cancelReorderByDueDate() {
        $("#ReorderByDueDateDialog").ejDialog("close");
    }
    function saveReorderByDueDate() {
        var reorderBacklog = $("#CheckboxReorderBacklog").ejCheckBox("instance").option("checked");
        var reorderBoard = $("#CheckboxReorderBoard").ejCheckBox("instance").option("checked");
        var reorderSprintData = {
            SprintID: sprintId,
            ReorderBacklog: reorderBacklog,
            ReorderBoard: reorderBoard
        };
        if (reorderBacklog == false && reorderBoard == false) {
            showKendoAlert("No options selected");
        } else {
            showProgress();
            $.post({
                url: window.appBase + "ProjectManagement/Agile/ReorderSprintByDueDate",
                dataType: "json",
                data: reorderSprintData
            }).always(function (result) {
                if (result) {
                    if (result.Success && result.Success == true) {
                        if (result.Success == true) {
                            showNotification("Success!", "success");
                            var scrollPos = $('html,body').scrollTop();
                            onRefreshCallBack = function () {
                                $('html,body').scrollTop(scrollPos);
                            }
                            filterCards();
                            $("#ReorderByDueDateDialog").ejDialog("close");
                        } else {
                            if (result.Success == false && result.Message && result.Message != "") {
                                showKendoAlert(result.Message)
                            }
                        }
                    } 
                }
                hideProgress();
            });
        }
    }
    function cancelComplete() {
       $("#CompleteSprintDialog").ejDialog("close");
    }
    function saveComplete() {
        //var completeOption = 1;
        $(".e-radiobtn:checked").each(function () {
            var activateNext = true;
            if ($(this).val() == "BackToBacklog") {
                //completeOption = 1
                activateNext = false;
            }
            if ($(this).val() == "LeaveInCurrentState") {
                //completeOption = 2
                activateNext = true;
            }
            //console.log(completeOption);
            showProgress();
            var completeSprintData = {
                SprintID: sprintId,
                ActivateNext: activateNext
            };
            $.post({
                url: window.appBase + "ProjectManagement/Agile/CompleteSprint",
                dataType: "json",
                data: completeSprintData
            }).always(function (result) {
                hideProgress();
                if (result) {
                    if (result.Success && result.Success == true) {
                        goBack();
                    }
                }
            });
        });
        //$("#CompleteSprintDialog").ejDialog("close");
    }
</script>
<style>
    .k-toolbar.active-sprint {
        border-bottom: 4px solid #4B7D70;
    }

    .k-toolbar.inactive-sprint {
        border-bottom: 4px solid #D63251;
    }
    /*.load-sprint {
        width: 100%;
        height: 4px;
        background-color: #4B7D70;
    }*/

    /*.active-sprint {
        width: 100%;
        height: 4px;
        background-color: #4B7D70;
    }

    .inactive-sprint {
        width: 100%;
        height: 4px;
        background-color: #D63251;
    }*/
</style>
@*<div id="active_indicator" class="load-sprint"></div>*@
<div id="ControlRegion" style="margin-top: 12px;">
    @Html.Partial("_Board", Model)
</div>
