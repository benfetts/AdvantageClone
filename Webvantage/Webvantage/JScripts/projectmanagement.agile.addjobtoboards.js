//
var qs = getQueryString();
function gridActionBegin(args) {
    //console.log(args)
}
function gridQueryCellInfo(args) {
    //console.log(args)
    //console.log(args.data)
}
function saveClick() {
    //console.log("saveClick");
    ////var grid = $("#BoardsGrid").data("ejGrid");
    ////if (grid) {
    ////    var selectedRecords = grid.getSelectedRecords();
    ////    if (selectedRecords && selectedRecords.length > 0) {
    ////        console.log(selectedRecords);
    ////    }
    ////}
    if (updates && updates.length > 0) {
        var jobNumber = 0;
        var jobComponentNumber = 0;
        if (qs.j) {
            jobNumber = qs.j * 1;
        }
        if (qs.jc) {
            jobComponentNumber = qs.jc * 1;
        }
        if (jobNumber > 0 && jobComponentNumber > 0) {
            var saveData = {
                JobNumber: jobNumber,
                JobComponentNumber: jobComponentNumber,
                Updates: updates
            }
            $.post({
                url: window.appBase + "ProjectManagement/Agile/SaveAddJobToBoardsData",
                dataType: "json",
                data: saveData
            }).always(function (result) {
                if (result && result.Data) {
                    if (result.Success == true) {
                        window.parent.closeDialogs();
                        window.parent.reloadWindow();
                    } else {
                        if (result.Message && result.Message != "") {
                            console.log("error:", result.Message);
                        }
                    }
                    //console.log("SaveAddJobToBoardsData", result);
                    //console.log("SaveAddJobToBoardsData", result.Data);
                    //console.log("SaveAddJobToBoardsData", result.Data);
                    //console.log("SaveAddJobToBoardsData", result.Data);
                    inserts = [];
                }
            });
        }
    }
}
function cancelClick() {
    window.parent.closeDialogs();
}
function refreshClick() {
    location.reload();
}
var updates = new Array;
function jobIsOnBoardCheckBoxChanged(evt) {
    var obj = $("#BoardsGrid").ejGrid("instance");
    var checked = false;
    var boardId = 0;
    checked = evt.target.checked;
    if (obj) {
        var dataItem = obj.model.dataSource[obj.model.selectedRowIndex];
        if (dataItem) {
            boardId = dataItem.ID;
            let ri = new AddJobToBoardUpdate();
            ri.BoardID = boardId;
            ri.IsChecked = checked;
            addUpdate(ri);
        }
        checkButtons();
    }
}
function addUpdate(entryInfo) {
    if (entryInfo && entryInfo != undefined) {
        removeUpdate(entryInfo);
        updates.push(entryInfo);
        //console.log("Update added", entryInfo.BoardID, updates.length);
    } else {
        //console.log("addUpdate:No entryInfo");
    }
}
function removeUpdate(entryInfo) {
    if (entryInfo && entryInfo != undefined) {
        var key = entryInfo.BoardID;
        if (key) {
            if (updates && updates.length > 0) {
                for (var i = updates.length; i--;) {
                    if (updates[i]) {
                        if (updates[i].BoardID == key) {
                            updates.splice(i, 1);
                            //console.log("Update removed", key);
                        }
                    }
                }
            }
        } else {
            //if (updates && updates.length > 0) {
            //    for (var i = updates.length; i--;) {
            //        if (updates[i]) {
            //            var newUpdateKey = "";
            //            var existingUpdateKey = "";
            //            newUpdateKey = tempKey(entryInfo);
            //            existingUpdateKey = tempKey(updates[i]);
            //            if (newUpdateKey == existingUpdateKey) {
            //                updates.splice(i, 1);
            //                //console.log("Update removed", key);
            //            }
            //        }
            //    }
            //}
        }
    }
}
function checkButtons() {
    //if (updates && updates.length > 0) {
        $("#saveButton").removeClass("k-state-disabled");
        $("#cancelButton").removeClass("k-state-disabled");
    //} else {
    //    $("#saveButton").addClass("k-state-disabled");
    //    $("#cancelButton").addClass("k-state-disabled");
    //}
    //console.log("len?", updates);
}
class AddJobToBoardUpdate {
    constructor() {
        this.BoardID = 0;
        this.IsChecked = false;
    }
}
