@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.Board
@Code

    ViewData("Title") = "New Board"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
<style>
    td {
        padding: 6px;
        vertical-align: top;
    }

    .e-icon.e-search:before {
        content: "\e63b" !important;
    }

    ul.job-list {
        list-style-type: none;
    }

        ul.job-list li {
            margin-left: -20px;
            margin-bottom: 3px;
            padding: 3px;
            border: solid 1px #cccccc;
            border-radius: 2px;
            cursor: pointer;
        }
</style>
@Code

    Dim AddBoardJobsDialog = Html.EJ().Dialog("AddBoardJobsDialog")

    AddBoardJobsDialog.Title("Add Jobs")
    AddBoardJobsDialog.ShowOnInit(False)
    AddBoardJobsDialog.ContentType("iframe")
    AddBoardJobsDialog.ShowHeader(False)
    AddBoardJobsDialog.ContentUrl("")
    AddBoardJobsDialog.ClientSideEvents(Sub(e)
                                        End Sub)
    AddBoardJobsDialog.Height("500px")
    AddBoardJobsDialog.Width("650px")
    AddBoardJobsDialog.Render()
End Code

<div class="form-horizontal">
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
                        @Html.TextBox("BoardName", Model.Header.Name, New With {.class = "e-textbox RequiredInput", .style = "width: 100%;"})
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
                <div class="form-group" style="width:100%;">
                    <div>
                        Board Type:
                    </div>
                    <div style="">
                        @Html.EJ().DropDownList("Boards").Width("100%").Datasource(Model.Boards).DropDownListFields(Function(F)
                                                                                                                        Return F.Value("ID").Text("Name")
                                                                                                                    End Function).Value(Model.Header.BoardHeaderID).Enabled(ViewData("Enabled"))
                    </div>
                </div>
                <div class="form-group" style="width:100%;">
                    <div>
                        Office:
                    </div>
                    <div>
                        @Html.EJ().DropDownList("Offices").Width("100%").Datasource(Model.Offices).DropDownListFields(Function(F)
                                                                                                                          Return F.Value("Code").Text("Name")
                                                                                                                      End Function).Value(Model.Header.OfficeCode).Enabled(ViewData("Enabled"))
                    </div>
                </div>
                <div class="form-group" style="width:100%;">
                    <div>
                        Owner:
                    </div>
                    <div>
                        @Html.EJ().DropDownList("Owners").Width("100%").Datasource(DirectCast(Model.Employees,
Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.EmployeeSimple))).DropDownListFields(Function(F)
                                                                                                            Return F.Value("Code").Text("FullName")
                                                                                                        End Function).Value(Model.Header.BoardOwnerEmployeeCode).ClientSideEvents(Sub(evt)
                                                                                                                                                                                  End Sub).Enabled(ViewData("Enabled"))
                    </div>
                </div>

            </td>
            <td>
                <div style="margin: 14px 0px 16px -4px;">
                    <div style="display: inline-block;" title="This will include all open jobs">
                        @Html.EJ().CheckBox("CheckboxIncludeAllJobs").Value("IncludeAllJobs").Size(Size.Medium).Checked(If(Model.Header.IncludeAllJobs IsNot Nothing, Model.Header.IncludeAllJobs, False)).ClientSideEvents(Sub(evt)
                                                                                                                                                                                                                                evt.Change("includeAllJobsChange")
                                                                                                                                                                                                                            End Sub).Enabled(ViewData("Enabled"))
                        All jobs
                    </div>
                    <div style="display: inline-block; margin:0px 0px 0px 14px;">
                        <div id="selectJobsButtonContainer" style="display:none;">
                            <button type="button" class="k-button k-primary" onclick="openSelectJobsDialog()">Select Jobs</button>
                        </div>
                    </div>
                </div>
                <div id="SelectJobsDiv" style="display: none;">
                    <div class="form-group" style="width:100%;">
                        <div>
                            Current Jobs:
                        </div>
                        <div id="CurrentJobsDiv" class='@( If(ViewData("Enabled") IsNot Nothing AndAlso ViewData("Enabled") = True, "", "no-edit"))'>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>
<div style="margin: 10px 0px 0px 6px; display:block; width: 100%; text-align: right;">
    <div id="buttonsContainer" class="k-button-group">
        <button id="ButtonCancel" class="k-button" onclick="cancelClick();">Cancel</button>
        <button id="ButtonSaveBoard" class="k-button k-primary" style="cursor:pointer;" onclick="saveBoardClick();"></button>
    </div>
</div>
<script type="text/javascript">
    var boardId = 0;
    var enabled = true;
    var includeAllJobs = false;

    boardId = @Html.Raw(Model.BoardID) * 1;
    enabled = @Html.Raw(ViewData("Enabled").ToString.ToLower);
    includeAllJobs = @Html.Raw(Model.Header.IncludeAllJobs.ToString.ToLower);

    function unityMenu(jobNumber, jobComponentNumber) {
        var menu = $("#UnityMenu").kendoContextMenu({
            target: "#IncludedJob_" + jobNumber + "_" + jobComponentNumber,
        });
    }
    function openPMD(jobNumber, jobComponentNumber) {
        OpenRadWindow('', 'Content.aspx?j=' + jobNumber + '&jc=' + jobComponentNumber);
    }
    function jobAutoCompleteClose(args) {
        this.showSuggestionBox = false;
    }
    function jobAutoCompleteFocusOut(args) {
        this.showSuggestionBox = true;
        $("#JobsAutoComplete").ejAutocomplete("hide");
        if (boardId && boardId > 0) {
            $("#JobsAutoComplete").ejAutocomplete("clearText");
        }
    }
    function jobsAutoCompleteSelect(args) {
        if (boardId && boardId > 0) {
            var addJobData = {
                BoardID: boardId,
                JobNumber: args.item.JobNumber * 1,
                JobComponentNumber: args.item.JobComponentNumber * 1
            };
            $.post({
                url: window.appBase + "ProjectManagement/Agile/AddJobToBoard",
                dataType: "json",
                data: addJobData
            }).always(function (result) {
                if (result) {
                    if (result.Success && result.Success == true && result.Data) {
                        //console.log(result.Data)
                        var token = "<div id='IncludedJob_openBracket2closeBracket_openBracket3closeBracket' class='button-token' title='openBracket4closeBracket, openBracket5closeBracket, openBracket6closeBracket (Click to open PMD)'>" +
                            "<span style='float:left; width: 335px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap;cursor: pointer;' onclick='openPMD(openBracket2closeBracket, openBracket3closeBracket);'>openBracket0closeBracket</span>" +
                            "<span id='IncludedJobDelButton_openBracket2closeBracket_openBracket3closeBracket' style='margin-top: 4px; float: right;cursor: pointer;' class='glyphicon glyphicon-remove' title='Click to remove from board' onclick='removeJob(openBracket2closeBracket,openBracket3closeBracket,this);'></span>" +
                            "</div>"
                        token = token.replace(/openBracket0closeBracket/g, result.Data.Description).replace(/openBracket1closeBracket/g, result.Data.Key).replace(/openBracket2closeBracket/g, result.Data.JobNumber).replace(/openBracket3closeBracket/g, result.Data.JobComponentNumber).replace(/openBracket4closeBracket/g, result.Data.Client).replace(/openBracket5closeBracket/g, result.Data.DivisionCode).replace(/openBracket6closeBracket/g, result.Data.ProductCode)
                        //console.log(token)
                        $("#CurrentJobsDiv").append(token);
                    }
                }
            });
        }
    }
    function jobsAutoCompleteCreate(args) {
        /*
        var items = new Array();
        items = args.model.dataSource
                        if (items) {
            var arrayLength = items.length;
            for (var i = 0; i < arrayLength; i++) {
                if (items[i].IsOnBoard == true) {
                    $("#JobsAutoComplete").ejAutocomplete("selectValueByKey", items[i].Key);
                   //console.log(items[i].Key);
                }
            }
        }
        */
    }
    function addBoardJobsClick() {
            var url = window.appBase + "ProjectManagement_Agile_SelectBoardJobs?BoardID=0"
        $("#AddBoardJobsDialog").ejDialog({
                contentUrl: url
            });
            $("#AddBoardJobsDialog").ejDialog("open");
    }
    function saveBoardClick() {
        var itemsArray = currentJobsDataSource.data();
        var arrayLength = itemsArray.length;
        var checkedItems = new Array();
        for (var i = 0; i < arrayLength; i++) {
            var newItem = {
                AccountExecutiveCode: itemsArray[i].AccountExecutiveCode,
                AccountExecutiveName: itemsArray[i].AccountExecutiveName,
                Client: itemsArray[i].Client,
                ClientCode: itemsArray[i].ClientCode,
                Description: itemsArray[i].Description,
                DivisionCode: itemsArray[i].DivisionCode,
                IsOnBoard: itemsArray[i].IsOnBoard,
                JobComponentNumber: itemsArray[i].JobComponentNumber,
                JobNumber: itemsArray[i].JobNumber,
                JobTypeCode: itemsArray[i].JobTypeCode,
                JobTypeDescription: itemsArray[i].JobTypeDescription,
                Key: itemsArray[i].Key,
                ManagerCode: itemsArray[i].ManagerCode,
                ManagerName: itemsArray[i].ManagerName,
                ProductCode: itemsArray[i].ProductCode,
                SalesClassCode: itemsArray[i].SalesClassCode,
                SalesClassDescription: itemsArray[i].SalesClassDescription
            }
            checkedItems.push(newItem);
        }
        if ($("#BoardName").val() == "") {
            showKendoAlert("Please enter a board name");
        } else {
            var boardHeaderID = 0;
            if ($("#Boards")[0].value && isNaN($("#Boards")[0].value) == false) {
                boardHeaderID = $("#Boards")[0].value * 1;
            }
            if (boardHeaderID <= 0) {
                showKendoAlert("Please select a board type.\nIf no board types are available, please contact an administrator.")
            } else {
                if ($("#Offices")[0].value == "") {
                    showKendoAlert("Please select an office")
                    return false;
                }
                if ($("#Owners")[0].value == "") {
                    showKendoAlert("Please select an owner")
                    return false;
                }
                var includeAllJobs = $("#CheckboxIncludeAllJobs").ejCheckBox("instance").option("checked");
                var newBoardData = {
                    BoardID: boardId,
                    BoardName: $("#BoardName").val(),
                    BoardDescription: $("#BoardDescription").val(),
                    OfficeCode: $("#Offices")[0].value,
                    BoardOwnerEmployeeCode: $("#Owners")[0].value,
                    BoardHeaderID: boardHeaderID,
                    IncludeAllJobs: includeAllJobs,
                    SelectedJobs: JSON.stringify(checkedItems)
                };
            //   console.log(newBoardData)
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/AddAgileBoard",
                    dataType: "json",
                    data: newBoardData
                }).always(function (response) {
                    if (response) {
                       //console.log(response);
                        if (response.Success && response.Success === true) {
                            var parentDoc = window.parent
                            parentDoc.goToURL(response.Data.BoardURL);
                        }
                        if (response.Success && response.Success === false && response.Message) {
                            showKendoAlert("Error in action: AddAgileBoard" + "\n" + response.Message);
                        }
                    }
                });
            }
        }
    }
    function cancelClick() {
        window.parent.closeDialogs();
    }
    function setSelectedJobs() {
        $('#JobsAutoComplete').ejAutocomplete({
            multiColumnSettings: {
                enable: true,
                showHeader: true,
                columns: [
                    {
                        field: "Description", headerText: "Job", type: ej.Type.String,
                        filterType: ej.filterType.Contains
                    },
                    {
                        field: "ClientCode", headerText: "Client", type: ej.Type.String,
                        filterType: ej.filterType.Contains
                    },
                    {
                        field: "Client", headerText: "Name", type: ej.Type.String,
                        filterType: ej.filterType.Contains
                    },
                    {
                        field: "DivisionCode", headerText: "Division", type: ej.Type.String,
                        filterType: ej.filterType.Contains
                    },
                    {
                        field: "ProductCode", headerText: "Product", type: ej.Type.String,
                        filterType: ej.filterType.Contains
                    }
                ],
                searchColumnIndices: [0, 1, 2, 3, 4],
                stringFormat: "{0} ({2}, {3}, {4})"
            }
        });
    }
    function includeAllJobsChange(args) {
        checkShowCurrentJobs();
    }
    function checkShowCurrentJobs() {
        setTimeout(function () {
            var show = !$('#CheckboxIncludeAllJobs').is(':checked');
            if (show) {
                $("#SelectJobsDiv").show();
                $("#selectJobsButtonContainer").show();
            } else {
                $("#SelectJobsDiv").hide();
                $("#selectJobsButtonContainer").hide();
            }
            if (enabled == false) {
                $("#selectJobsButtonContainer").hide();
                $("#ButtonSaveBoard").prop("disabled", true);
            }
        }, 0);
    }
    var currentJobsDataSource = new kendo.data.DataSource({
        requestEnd: function (e) {

        }
    });
    $(document).ready(function () {
        $('#BoardName').focus();
        setSelectedJobs();
        if (enabled == false) {
            $("#BoardName").prop("readonly", true);
            $("#BoardDescription").prop("readonly", true);
            $("#ButtonSaveBoard").prop("disabled", true);
        }
        if (boardId == 0) {
            $("#ButtonSaveBoard").html("Add")
        } else {
            $("#ButtonSaveBoard").html("Save")
        }
        checkShowCurrentJobs();
        currentJobsDataSource.read();
    });
    function openSelectJobsDialog() {
        var URL = "";
        var thisTitle = "Select Jobs";
        URL = window.appBase + "ProjectManagement_Agile_SelectBoardJobs?BoardID=" + @Html.Raw(Model.BoardID);
        $("#AddBoardJobsDialog").ejDialog("destroy");
        $("#AddBoardJobsDialog").ejDialog({
            contentUrl: URL,
            title: thisTitle + "",
            showOnInit: false,
            contentType: "iframe",
            height: "500px",
            width: "700px",
            showFooter: true,
            footerTemplateId: 'addBoardJobsDialogFooter',
            enableModal: true,
            enableResize: false
        });
        $("#addBoardJobsSave").kendoButton({
            click: function () {
                saveAddBoardJobsDialog();
            }
        });
        $("#addBoardJobsCancel").kendoButton({
            click: function () {
                closeAddBoardJobsDialog();
            }
        });
        $("#AddBoardJobsDialog").ejDialog("open");
        $("#AddBoardJobsDialog").ejDialog("refresh");
    }
    function saveAddBoardJobsDialog() {
        var content = $('#AddBoardJobsDialog').find('iframe')[0].contentWindow;
        if (content && content.MvcSaveBridge) {
            var result = content.MvcSaveBridge();
            if (typeof result === 'boolean') {
                if (result === true) {
                    closeAddBoardJobsDialog();
                }
            } else if (Array.isArray(result)) {
                for (var i = 0; i < result.length; i++) {
                    var canAdd = true;
                    for (var d = 0; d < currentJobsDataSource.data().length; d++) {
                        if (result[i].JobNumber === currentJobsDataSource.data()[d].JobNumber && result[i].JobComponentNumber === currentJobsDataSource.data()[d].JobComponentNumber) {
                            canAdd = false;
                        }
                    }
                    if (canAdd === true) {
                        currentJobsDataSource.add(result[i]);
                    }
                }
                syncItems(currentJobsDataSource.data(), true);
                closeAddBoardJobsDialog();
            } else {
                result.then(function (response) {
                    if (response.content.Success === true) {
                        currentJobsDataSource.read();
                        closeAddBoardJobsDialog();
                    } else if (response.content.Message) {
                        showKendoAlert(response.content.Message);
                    }
                });
            }
        }
    }
    function closeAddBoardJobsDialog() {
        $("#AddBoardJobsDialog").ejDialog("close");
    }
    function syncItems(items, isLocal) {
        checkShowCurrentJobs();
        $('#CurrentJobsDiv').html('');
        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            addItemToCurrentJobs(item, isLocal);
        }
    }
    function currentBoardJobsRequestEnd(e) {
        syncItems(e.response, false);
    }
    function addItemToCurrentJobs(item, isLocal) {
       //console.log('addItemToCurrentJobs', item);
        var div = $('<div id="IncludedJob_' + item.JobNumber + '_' + item.JobComponentNumber + '" class="button-token" title="' + item.Client + ', ' + item.DivisionCode + ', ' + item.ProductCode + '"></div>').appendTo('#CurrentJobsDiv');
        var span = $('<span style="float:left; width: 335px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap; cursor: pointer;" title="' + item.Description + ' (Click to open PMD)" onclick="openPMD(' + item.JobNumber + ', ' + item.JobComponentNumber + ');">' + item.Description + '</span>').appendTo(div);
        if (!$('#CurrentJobsDiv').hasClass('no-edit')) {
            var deleteSpan = $('<span id="IncludedJobDelButton_' + item.JobNumber + '_' + item.JobComponentNumber + '" style="margin-top: 4px; float: right; cursor: pointer;" class="glyphicon glyphicon-remove" title="Click to remove from board" onclick="removeJob(' + item.JobNumber + ', ' + item.JobComponentNumber + ', this, ' + isLocal +');"></span>').appendTo(div);
        }
    }
</script>
<script id="addBoardJobsDialogFooter" type="text/x-jsrender">
    <div style="text-align: right;">
        <div class="k-button-group">
            <button id='addBoardJobsSave' class="k-primary">Add</button>
            <button id='addBoardJobsCancel'>Cancel</button>
        </div>
    </div>
</script>
@If ViewData("Enabled") IsNot Nothing AndAlso ViewData("Enabled") = True Then

    @<text>
        <script type="text/javascript">

            function removeJob(jobNumber, jobComponentNumber, obj, isLocal) {
               //console.log($("#" + obj.id))
                showKendoConfirm("Remove job from board?\nAll cards on all sprints will be removed for the job.")
                    .done(function () {
                        for (var i = 0; i < currentJobsDataSource.data().length; i++) {
                            var item = currentJobsDataSource.data()[i];
                            if (item.JobNumber === jobNumber && item.JobComponentNumber === jobComponentNumber) {
                                currentJobsDataSource.remove(item);
                            }
                        }
                        if (isLocal) {
                            syncItems(currentJobsDataSource.data(), true);
                        } else {
                            var removeJobData = {
                                BoardID: boardId,
                                JobNumber: jobNumber,
                                JobComponentNumber: jobComponentNumber
                            };
                            $.post({
                                url: window.appBase + "ProjectManagement/Agile/RemoveJobFromBoard",
                                dataType: "json",
                                data: removeJobData
                            }).always(function (result) {
                                syncItems(currentJobsDataSource.data(), false);
                                if (result) {
                                    if (result.Success && result.Success == true) {
                                    }
                                }
                            });
                        }
                    })
                    .fail(function () {
                    });
            }

        </script>
    </text>


End If

@If Model.BoardID > 0 Then

    @<text>
        <script type="text/javascript">

            var currentJobsDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: window.appBase + 'ProjectManagement/Agile/GetCurrentJobsForBoard?BoardID=' + @Html.Raw(Model.BoardID)
                    }
                },
                requestEnd: function (e) {
                    currentBoardJobsRequestEnd(e);
                }
            });

        </script>
    </text>

End If
