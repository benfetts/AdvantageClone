<%@ Page AutoEventWireup="false" CodeBehind="TrafficSchedule.aspx.vb" Inherits="Webvantage.TrafficSchedule" ValidateRequest="false"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Project Schedule" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<%@ Register Src="Alert_RecipientUC.ascx" TagName="AutoCompleteAlertRecipient" TagPrefix="custom" %>
<asp:Content ID="ContentTrafficSchedule" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <style type="text/css">
        tr.advParentRow > td {
            background-color: #cfcfcf !important;
            font-weight: bold;
        }
            
        .racInput{
            width: 75px !important;
            border: none !important;
        }
        .racToken {
            margin-bottom: 1px;
        }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">
        <script type="text/javascript">

            function styleParentRows() {
                $('input.rgExpand, input.rgCollapse').each(function () {
                    $(this).closest('tr').addClass('advParentRow');
                });
            }

            function LoadComboItems(sender, args) {
                var combo = sender;
                if (combo.get_items().get_count() <= 2) {
                    combo.requestItems("", false);
                }
            }

            var dragging = false;

            $(document).ready(function () {
                dragging = false;

                //alignColumns();

                $(document).mouseup(function () {
                    dragging = false;
                });

                $(window).resize(function () {
                    var radgrid = $find('<%= RadGridProjectSchedule.ClientID %>');
                    radgrid.repaint();
                    alignColumns();
                });

            });

            function SelectAllRows(checked) {
                var radgrid = $find('<%= RadGridProjectSchedule.ClientID %>');
                var masterTableView = radgrid.get_masterTableView()
                var detailTables = radgrid.get_detailTables();
                var allTables = new Array();

                allTables = allTables.concat(detailTables);
                allTables.splice(0, 0, masterTableView);

                for (var t = 0; t < allTables.length; t++) {
                    if (checked == true) {
                        allTables[t].selectAllItems();
                    } else {
                        allTables[t].clearSelectedItems();
                    }
                }
                var HiddenFieldSelectAll = document.getElementById('<%= HiddenFieldSelectAll.ClientID%>');
                if (checked == true) {
                    HiddenFieldSelectAll.value = '1';
                } else {
                    HiddenFieldSelectAll.value = '0';
                }
            }

            function OnRowContextMenu(sender, args) {
                var evt = args.get_domEvent();
                if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                    return;
                }

                document.getElementById('<%= HiddenFieldSelectedRow.ClientID %>').value = args.get_itemIndexHierarchical();

                var menu = $find('<%= RadContextMenuGridItem.ClientID %>');
                var items = menu.get_items();
                var gridDataItem = args.get_gridDataItem();
                enableOrDisableMenuOptions(menu, gridDataItem);
                menu.show(evt);
                evt.cancelBubble = true;
                evt.returnValue = false;

                if (evt.stopPropagation) {
                    evt.stopPropagation();
                    evt.preventDefault();
                }

            }

            function LinkedOnClientCheckedChanged(sender, args) {
                var commandArg = args.get_commandArgument();
                var linked = args.get_checked() == true ? 1 : 0;
                try {
                    PageMethods.LinkItem(commandArg, linked, LinkChanged, DataChangeFailed);
                    return false;
                } catch (err) { }

            }

            function LinkChanged(result) {
                try {
                    var response = JSON.parse(result);
                    if (response != null) {
                        if (response.Status == 200) {
                            var seqNum = null;
                            var masterTableView = $find("<%= RadGridProjectSchedule.ClientID%>").get_masterTableView();
                            var detailTables = $find("<%= RadGridProjectSchedule.ClientID%>").get_detailTables();
                            var allTables = new Array();

                            allTables = allTables.concat(detailTables);
                            allTables.splice(0, 0, masterTableView);

                            seqNum = response.SequenceNumber;

                            for (var t = 0; t < allTables.length; t++) {
                                var dataItems = allTables[t].get_dataItems();
                                for (var i = 0; i < dataItems.length; i++) {
                                    if (dataItems[i].getDataKeyValue('SequenceNumber') == seqNum) {
                                        var index = dataItems[i].get_itemIndexHierarchical();
                                        var indexLevels = new Array();
                                        var lastIndex = new Array();
                                        var lastIndexNumber = null;
                                        var btn = dataItems[i].findControl('RadButtonLinked');
                                        indexLevels = index.split(":");
                                        lastIndex = indexLevels[indexLevels.length - 1].split("_");
                                        lastIndexNumber = lastIndex[lastIndex.length - 1];
                                        if (lastIndexNumber == '0') {
                                            btn.set_visible(false);
                                        }
                                    }
                                }
                            }
                        } else {
                            if (response.Message != "") {
                                ShowMessage(response.Message);
                            }
                        }
                    }
                } catch (ex) {
                }
                refreshPredecessorLabels(seqNum);
            }
            function findDataItemBySeqNum(seqNum) {
                var dataItems = getAllDataItems();
                var notation;
                for (var i = 0; i < dataItems.length; i++) {
                    if (dataItems[i].getDataKeyValue('SequenceNumber') == seqNum) {
                        return dataItems[i];
                    }
                }
                return null;
            }
            function refreshPredecessorLabels(seqNum) {
                var dataItems = getAllDataItems();
                var notation;
                for (var i = 0; i < dataItems.length; i++) {
                    if (dataItems[i].getDataKeyValue('SequenceNumber') == seqNum) {
                        notation = dataItems[i].findElement("LabelLevelNotation").innerHTML;
                    }
                }
                for (var i = 0; i < dataItems.length; i++) {
                    var dataItem = dataItems[i];
                    var sequenceNumber = dataItem.getDataKeyValue("SequenceNumber");
                    var predTxt = dataItem.findElement('LabelPredecessorsLabel');
                    var preds = $(predTxt).text();
                    if (seqNum == sequenceNumber || preds.indexOf(notation) >= 0) {
                        refreshPredecessorLabel(dataItem);
                    }
                }
            }
            function refreshPredecessorLabel(dataItem) {
                var jobNumber = dataItem.getDataKeyValue("JobNumber");
                var jobComponent = dataItem.getDataKeyValue("JobComponentNumber");
                var sequenceNumber = dataItem.getDataKeyValue("SequenceNumber");
                var dataKey = jobNumber + '|' + jobComponent + '|' + sequenceNumber;
                var keyvalues = document.getElementById('<%= TextBoxLabels.ClientID%>').value;
                try {
                    PageMethods.GetPredecessorsLevelList(dataKey, keyvalues, function (response) { SetPredecessorLabelText(dataItem, response); }, DataChangeFailed);
                } catch (err) {

                }
            }
            function getAllTables() {
                var masterTableView = $find("<%= RadGridProjectSchedule.ClientID%>").get_masterTableView();
                var detailTables = $find("<%= RadGridProjectSchedule.ClientID%>").get_detailTables();
                var allTables = new Array();
                allTables = allTables.concat(detailTables);
                allTables.splice(0, 0, masterTableView);
                return allTables;
            }
            function getAllDataItems() {
                var allTables = getAllTables();
                var allDataItems = new Array();
                for (var i = 0; i < allTables.length; i++) {
                    var dataItems = allTables[i].get_dataItems();
                    for (var d = 0; d < dataItems.length; d++) {
                        allDataItems.push(dataItems[d]);
                    }
                }
                return allDataItems;
            }

            function IsChildOfRow(ParentGridDataItem, ChildGridDataItem) {
                var isChild = false;
                var nestedViews = ParentGridDataItem.get_nestedViews();
                for (var v = 0; v < nestedViews.length; v++) {
                    if (isChild == false) {
                        var dataItems = nestedViews[v].get_dataItems()
                        for (var i = 0; i < dataItems.length ; i++) {
                            var dataItem = dataItems[i];
                            var dkv = dataItem.getDataKeyValue('ID');
                            var cdkv = ChildGridDataItem.getDataKeyValue('ID');
                            if (dkv == cdkv) {
                                isChild = true;
                            } else {
                                isChild = IsChildOfRow(dataItem, ChildGridDataItem);
                            }
                        }
                    }
                }
                return isChild;
            }

            function AutoExpandOrCollapseDataItem(GridTableView, selectedItems, rowHoverID) {
                for (var i = 0; i < GridTableView.get_dataItems().length; i++) {
                    var dataItem = GridTableView.get_dataItems()[i];
                    var expanded = false;
                    var dataItemHierarchy = null;

                    if (dataItem.get_nestedViews()[0].get_dataItems().length == 0) {
                        expanded = false;
                    } else {
                        expanded = dataItem.get_expanded();
                    }

                    if (dataItem.getDataKeyValue('ID') == rowHoverID) {
                        var isChild = false;
                        for (var t = 0; t < selectedItems.length; t++) {
                            if (isChild == false) {
                                isChild = IsChildOfRow(selectedItems[t], dataItem);
                            }
                        }
                        expanded = !isChild;
                    }

                    for (var si = 0; si < selectedItems.length; si++) {
                        if (selectedItems[si].getDataKeyValue('ID') == dataItem.getDataKeyValue('ID')) {
                            expanded = dataItem.get_expanded();
                        }
                    }

                    if (dragging == false) {
                        expanded = dataItem.get_expanded();
                    }

                    dataItem.set_expanded(expanded);
                }
            }

            function OnRowMouseOver(sender, args) {

                var rowHoverID = args.getDataKeyValue('ID');
                var radGrid = $find('<%= RadGridProjectSchedule.ClientID%>');
                var selectedItems = radGrid.get_selectedItems();
                var detailTables = radGrid.get_detailTables();
                var masterTableView = radGrid.get_masterTableView();

                var allTables = new Array();

                allTables = allTables.concat(detailTables);
                allTables.splice(0, 0, masterTableView);

                for (var t = 0; t < allTables.length; t++) {
                    AutoExpandOrCollapseDataItem(allTables[t], selectedItems, rowHoverID);
                }
            }

            function alignColumns() {
                var radGrid = $find('<%= RadGridProjectSchedule.ClientID%>');
                var masterTableView = radGrid.get_masterTableView();
                var detailTables = radGrid.get_detailTables();
                var highestLevel = 0;
                var highestGridDataView = null;
                var dragCol = null;
                var allTables = new Array();

                allTables = allTables.concat(detailTables);
                allTables.splice(0, 0, masterTableView);

                var predLabels = document.getElementsByClassName("predLabel");
                var predLabelWidth = 10;
                var ruler = document.getElementById('<%= LabelRuler.ClientID %>');
                for (var p = 0; p < predLabels.length; p++) {
                    var actualLabel = predLabels[p].getElementsByTagName('input')[0];
                    var txt = actualLabel.value;
                    ruler.innerHTML = txt;
                    if (ruler.offsetWidth > predLabelWidth) {
                        predLabelWidth = ruler.offsetWidth;
                    }
                }
                predLabelWidth = predLabelWidth + 10;
                for (var p = 0; p < predLabels.length; p++) {
                    var actualLabel = predLabels[p].getElementsByTagName('input')[0];
                    $(predLabels[p]).width(predLabelWidth);
                    $(actualLabel).width(predLabelWidth);
                }
                if (allTables.length > 0) {
                    for (var t = 0; t < allTables.length; t++) {
                        var detailTable = allTables[t];
                        detailTable.getColumnByUniqueName('ColumnLevelNotation').resizeToFit(false, true);
                        var dataItems = detailTable.get_dataItems();
                        if (dataItems.length > 0) {
                            for (var i = 0; i < dataItems.length; i++) {
                                var dataItem = dataItems[i];
                                var hierarchy = 0;
                                detailTable.getCellByColumnUniqueName(dataItem, 'GridTemplateColumnSpacer').innerHTML = '';
                                var pColumn = detailTable.getCellByColumnUniqueName(dataItem, 'GridTemplateColumnPreds');
                                //$(pColumn).width(predLabelWidth);
                                if ($(dataItem.get_element()).is(':visible') == true) {
                                    hierarchy = dataItem.get_itemIndexHierarchical().split(":").length;
                                    if (hierarchy > highestLevel) {
                                        highestLevel = hierarchy;
                                        highestGridDataView = dataItem.get_owner();
                                    }

                                }
                            }
                        }
                    }
                    if (highestGridDataView == null || highestLevel == 1) {
                        dragCol = masterTableView.getColumnByUniqueName('DragDropColumn').get_element();
                        $(dragCol).html('&nbsp;');
                    } else {
                        var nextColumnUniqueName = ''; //'ColumnAfterSpacer';
                        var cols = highestGridDataView.get_columns();
                        for (var c = 0; c < cols.length; c++) {
                            if (cols[c].get_uniqueName() == 'GridTemplateColumnSpacer') {
                                for (var d = c + 1; d < cols.length; d++) {
                                    if (nextColumnUniqueName == '') {
                                        if (cols[d].get_visible() == true) {
                                            nextColumnUniqueName = cols[d].get_uniqueName();
                                            d = cols.length + 1;
                                            c = d;
                                        }
                                    }
                                }
                            }
                        }
                        var nextColumnPosition = $(highestGridDataView.getCellByColumnUniqueName(highestGridDataView.get_dataItems()[0], nextColumnUniqueName)).position();
                        for (var t = detailTables.length - 1; t >= 0; t--) {
                            var detailTable = allTables[t];
                            var dataItems = detailTable.get_dataItems();
                            if (dataItems.length > 0) {
                                var dataItem = dataItems[0];
                                if ($(dataItem.get_element()).is(":visible") == true) {
                                    var notationColumn = detailTable.getColumnByUniqueName('ColumnLevelNotation');
                                    notationColumn.resizeToFit(true, false);
                                    var columnToAlignPosition = $(detailTable.getCellByColumnUniqueName(dataItem, nextColumnUniqueName)).position();
                                    var counter = 0;

                                    var columnToAlignOffset = $(detailTable.getCellByColumnUniqueName(dataItem, nextColumnUniqueName)).offset();
                                    var nextColumnOffSet = $(highestGridDataView.getCellByColumnUniqueName(highestGridDataView.get_dataItems()[0], nextColumnUniqueName)).offset();

                                    while (columnToAlignPosition.left < nextColumnPosition.left) {
                                        counter = counter + 1;
                                        $(detailTable.getCellByColumnUniqueName(dataItem, 'GridTemplateColumnSpacer')).html('<div style="width: ' + counter + 'px;"></div>');
                                        columnToAlignPosition = $(detailTable.getCellByColumnUniqueName(dataItem, nextColumnUniqueName)).position();
                                        nextColumnPosition = $(highestGridDataView.getCellByColumnUniqueName(highestGridDataView.get_dataItems()[0], nextColumnUniqueName)).position();

                                        columnToAlignOffset = $(detailTable.getCellByColumnUniqueName(dataItem, nextColumnUniqueName)).offset();
                                        nextColumnOffSet = $(highestGridDataView.getCellByColumnUniqueName(highestGridDataView.get_dataItems()[0], nextColumnUniqueName)).offset();

                                    }
                                }
                            }
                        }
                    }
                }
            }

            function isLessThen101(text) {

                if (text.value > 100 || text.value < 0) {
                    text.value = ''
                    ShowMessage(" Must be between 0 and 100%");
                }

            }
            function DataChange(RowDataKey, ControlType, ControlName, ControlValue) {

                try {
                    //alert(ControlValue);
                    PageMethods.DetailAutoSave(RowDataKey, ControlType, ControlName, ControlValue, DataChangeSucceeded, DataChangeFailed);
                    //if (DataChangeSucceeded() == false) {
                    //    alert(str);
                    //}
                    return false;
                } catch (err) { }
            }
            function DataChangeSucceeded(result, userContext, methodName) {
                try {
                    //alert("hi");
                    //alert(result);
                    //$get('div1').innerHTML = result;
                    if (result != '') {

                        var str = "";
                        str = result
                        str = str.replace("##", '\n');
                        str = str.replace("##", '\n');
                        //alert(str);
                        if (str.indexOf("[object") > -1) {

                        }
                        else {
                            //alert(str)

                            var statusCodeOK = 'Status code updated';
                            var nextSeqOK = 'Next Seq Nbr';

                            if (str.indexOf(statusCodeOK) > -1 || str.indexOf(nextSeqOK) > -1) {
                                var DataKey = new Array();
                                var NewCode = "";
                                var NewDesc = "";
                                var NextSeq = "";

                                DataKey = str.split('|');

                                for (var i = 0; i < DataKey.length; i++) {
                                    if (DataKey[i] == statusCodeOK) {
                                        NewCode = DataKey[i + 1];
                                        NewDesc = DataKey[i + 2];
                                        if (NewCode != "" && NewDesc != "") {
                                            var codebox;
                                            var descbox;
                                            codebox = document.getElementById("<%= Me.TxtTrafficStatusCode.ClientID%>");
                                            descbox = document.getElementById("<%= Me.TxtTrafficStatusDescription.ClientID%>");
                                            codebox.value = NewCode;
                                            descbox.value = NewDesc;
                                        }
                                    } else if (DataKey[i] == nextSeqOK) {
                                        var RadGrid = $find('<%= RadGridProjectSchedule.ClientID%>');
                                        var MasterTableView = RadGrid.get_masterTableView();
                                        var DetailTables = RadGrid.get_detailTables();
                                        var AllTables = new Array();
                                        AllTables = AllTables.concat(DetailTables);
                                        AllTables.splice(0, 0, MasterTableView);
                                        for (var s = i + 1; s < DataKey.length; s++) {
                                            NextSeq = DataKey[s];
                                            if (NextSeq != '') {
                                                for (var t = 0; t < AllTables.length; t++) {
                                                    var DataItems = AllTables[t].get_dataItems();
                                                    for (var d = 0; d < DataItems.length; d++) {
                                                        if (DataItems[d].getDataKeyValue('SequenceNumber') == NextSeq) {
                                                            var DataItem = DataItems[d];
                                                            var StatusComboBox = DataItem.findControl('RadComboBoxTaskStatus');
                                                            StatusComboBox.findItemByValue('A').select();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                            }
                        } else {
                                ShowMessage(str);
                        }
                    }
                    return false;
                }
                else {
                    return true;
                }
                return false;
            }
            catch (err) { }
        }

        function DataChangeFailed(error, userContext, methodName) {
            try {
                //alert("fail");
                var str = '';
                str = error;
                if (str.indexOf("[object") > -1) {
                }
                else {
                    ShowMessage(str);
                }
                //return false;
            }
            catch (err) { }
        }
        function DataChangeCheckboxMilestone(ChkRowDataKey, ControlClientId) {
            try {
                var val = 0;
                if (document.getElementById(ControlClientId).checked) {
                    val = 1;
                }
                DataChange(ChkRowDataKey, 'chk', 'CheckBoxMilestone', val);
            }
            catch (err) { }

        }
        function DataChangeCheckboxLock(ChkRowDataKey, ControlClientId) {
            try {
                var val = 0;
                if (document.getElementById(ControlClientId).checked) {
                    val = 1;
                }
                DataChange(ChkRowDataKey, 'chk', 'CheckBoxDueDateLock', val);
            }
            catch (err) { }
        }
        function DataChangeTaskCode(ChkRowDataKey, TaskCodeClientId, TaskDescClientId, TaskCodeValue) {
            try {
                PageMethods.SaveTaskCode(ChkRowDataKey, TaskCodeClientId, TaskDescClientId, TaskCodeValue, DataChangeTaskCodeSucceeded, DataChangeTaskCodeFailed);
            }
            catch (err) { }
        }
        function DataChangeTaskCodeSucceeded(result, userContext, methodName) {
            try {
                if (result != '') {
                    var str = "";
                    str = result
                    str = str.replace("##", '\n');
                    str = str.replace("##", '\n');
                    try {
                        if (str.indexOf("|") > -1) {
                            var ar = new Array();
                            ar = str.split("|");
                            var status;
                            var desc;
                            var descval;
                            status = ar[0];
                            desc = ar[1];
                            descval = ar[2];
                            if (status == "OK") {
                                document.getElementById(desc).value = descval;
                            }
                        } else {
                            if (str.indexOf("[object") > -1) {
                            }
                            else {
                                ShowMessage(str);
                            }
                        }
                    }
                    catch (err) { }
                }
                return false;
            }
            catch (err) { }
        }
        function DataChangeTaskCodeFailed(error, userContext, methodName) {
            try {
                var str = '';
                str = error;
                if (str.indexOf("[object") > -1) {
                }
                else {
                    ShowMessage(str);
                }
            }
            catch (err) { }
        }
        function DataChangeTaskDesc(ChkRowDataKey, TaskCodeClientId, TaskDescClientId, TaskDescValue) {
            try {
                var TheFncCode;
                if (document.getElementById(TaskCodeClientId) != null) {
                    TheFncCode = document.getElementById(TaskCodeClientId).value;
                }
                else {
                    TheFncCode = '';
                }
                PageMethods.SaveTaskDesc(ChkRowDataKey, TaskCodeClientId, TaskDescClientId, TheFncCode, TaskDescValue, DataChangeTaskDescSucceeded, DataChangeTaskDescFailed);
            }
            catch (err) { }
        }
        function DataChangeTaskDescSucceeded(result, userContext, methodName) {
            try {
                if (result != '') {
                    var str = "";
                    str = result
                    str = str.replace("##", '\n');
                    str = str.replace("##", '\n');
                    try {
                        if (str.indexOf("|") > -1) {
                            var ar = new Array();
                            ar = str.split("|");
                            var status;
                            var codetb;
                            var codeval;
                            status = ar[0];
                            codetb = ar[1];
                            codeval = ar[2];
                            if (status == "OK") {
                                document.getElementById(codetb).value = codeval;
                            }
                        } else {
                            if (str.indexOf("[object") > -1) {
                            }
                            else {
                                ShowMessage(str);
                            }
                        }
                    }
                    catch (err) { }
                }
                return false;
            }
            catch (err) { }
        }
        function DataChangeTaskDescFailed(error, userContext, methodName) {
            try {
                var str = '';
                str = error;
                if (str.indexOf("[object") > -1) {
                }
                else {
                    ShowMessage(str);
                }
            }
            catch (err) { }
        }
        function DataChangeScheduleHeader(ThisDataKey, FieldName, ControlValue, ControlClientId) {
            try {

                //alert(ThisDataKey);
                //alert(FieldName);
                //alert(ControlValue);
                //alert(ControlClientId);

                PageMethods.AutoSaveScheduleHeader(ThisDataKey, FieldName, ControlValue, ControlClientId, DataChangeScheduleHeaderSucceeded, DataChangeScheduleHeaderFailed);

            }
            catch (err) { }
        }
        function DataChangeScheduleHeaderSucceeded(result, userContext, methodName) {
            try {
                //alert(result);
                if (result != "") {
                    //alert("hi")
                    var str = "";
                    str = result
                    str = str.replace("##", '\n');
                    str = str.replace("##", '\n');
                    if (str.indexOf("[object") > -1) {
                    }
                    else if (str.indexOf("STATUS_UPDATE|") > -1) {
                        var ar = new Array();
                        ar = str.split("|");
                        //alert(ar[1]);
                        document.getElementById("<%= TxtTrafficStatusDescription.ClientID%>").value = ar[1];
                    }
                    else if (str.indexOf("ERROR|") > -1) {
                        var ar = new Array();
                        ar = str.split("|");
                        ShowMessage(ar[1]);
                    }
                    else {
                        //alert(str);
                    }
                return false;
            }
            else {
                return true;
            }
            return false;
        }
        catch (err) { }
    }
    function DataChangeScheduleHeaderFailed(error, userContext, methodName) {
        try {
            var str = '';
            str = error;
            if (str.indexOf("[object") > -1) {
            }
            else {
                ShowMessage(str);
            }
        }
        catch (err) { }
    }
    function CancelNonInputSelect(sender, args) {

        var e = args.get_domEvent();
        //IE - srcElement, Others - target  
        var targetElement = e.srcElement || e.target;


        //this condition is needed if multi row selection is enabled for the grid  
        if (typeof (targetElement) != "undefined") {
            //is the clicked element an input checkbox? <input type="checkbox"...>  
            if (targetElement.tagName.toLowerCase() != "input" &&
                            (!targetElement.type || targetElement.type.toLowerCase() != "checkbox"))// && currentClickEvent)  
            {

                //cancel the event  
                args.set_cancel(true);
            }
        }
        else {
            args.set_cancel(false);
        }

    }
    function CheckRowSelection(sender, args) {
        var radGrid = $find('<%= RadGridProjectSchedule.ClientID%>');
        var masterTableView = radGrid.get_masterTableView();
        var detailTables = radGrid.get_detailTables();
        var selectedItemsCount = radGrid.get_selectedItems().length;
        var allTables = new Array();
        var itemCount = 0;
        var checked = false;
        allTables = allTables.concat(detailTables);
        allTables.splice(0, 0, masterTableView);
        for (var t = 0; t < allTables.length; t++) {
            itemCount = itemCount + allTables[t].get_dataItems().length;
        }
        if (itemCount == selectedItemsCount) {
            checked = true;
        }
        document.getElementById('CheckBoxSelectAllRows').checked = checked;
        var HiddenFieldSelectAll = document.getElementById('<%= HiddenFieldSelectAll.ClientID%>');
        if (checked == true) {
            HiddenFieldSelectAll.value = '1';
        } else {
            HiddenFieldSelectAll.value = '0';
        }

        var gridDataItem = args.get_gridDataItem();
        var menu = $find('<%= RadContextMenuGridItem.ClientID %>');
        enableOrDisableMenuOptions(menu, gridDataItem);

    }
    function ClearTBe(e, tb) {
        try {
            var keyval = e.keyCode;
            if (keyval == 9) { }
            else {
                var thisTextbox = document.getElementById(tb);
                thisTextbox.value = '';
            }
        }
        catch (err) { }
    }

    function enableOrDisableMenuOptions(menu, gridDataItem) {
        var selectedCount = $find('<%= RadGridProjectSchedule.ClientID %>').get_selectedItems().length;
        if (selectedCount > 1) {
            var menuItems = menu.get_items();
            for (var i = 0; i < menuItems.get_count() ; i++) {
                var item = menuItems.getItem(i);
                if (item.get_value() == "DeleteTask") {
                    item.set_enabled(true);
                } else {
                    item.set_enabled(false);
                }
            }
        } else {
            //no row selected
            var menuItems = menu.get_items();
            for (var i = 0; i < menuItems.get_count() ; i++) {
                var item = menuItems.getItem(i);
                item.set_enabled(true);
               
            }
        }
    }

    function Refresh() {
        //alert("ts refresh!")
        __doPostBack('onclick#Refresh', 'Refresh');
    }
    function RefreshGrid(radWindowCaller) {
        __doPostBack('onclick#Refresh', 'Refresh');
    }
    function SaveFromPopUp(radWindowCaller) {
        __doPostBack('onclick#Save', 'Save');
    }
    var RadGridProjectSchedule;
    function GetGridObject() {
        RadGridProjectSchedule = this;
    }
    function SwapColumns(index1, index2) {
        RadGridProjectSchedule.MasterTableView.SwapColumns(index1, index2);
    }
    function ReorderColumns(index1, index2) {
        RadGridProjectSchedule.MasterTableView.ReorderColumns(index1, index2);
    }
    function ResizeColumn(index, width) {
        RadGridProjectSchedule.MasterTableView.ResizeColumn(index, width);
    }
    function MoveColumnToLeft(index) {
        RadGridProjectSchedule.MasterTableView.MoveColumnToLeft(index);
    }
    function MoveColumnToRight(index) {
        RadGridProjectSchedule.MasterTableView.MoveColumnToRight(index);
    }
    function HideColumn(index) {
        RadGridProjectSchedule.MasterTableView.HideColumn(index);
    }
    function ShowColumn(index) {
        RadGridProjectSchedule.MasterTableView.ShowColumn(index);
    }
    function HideRow(index) {
        RadGridProjectSchedule.MasterTableView.HideRow(index);
    }
    function ShowRow(index) {
        RadGridProjectSchedule.MasterTableView.ShowRow(index);
    }
    function ExportToExcel(fileName) {
        RadGridProjectSchedule.MasterTableView.ExportToExcel(fileName);
    }
    function ExportToWord(fileName) {
        RadGridProjectSchedule.MasterTableView.ExportToWord(fileName);
    }
    function DisplayDetails() {
        var divDetails = document.getElementById('divDetails');
        divDetails.style.display = "inline";
    }
    function CloseActiveToolTip() {
        setTimeout(function () {
            var controller = Telerik.Web.UI.RadToolTipController.getInstance();
            var tooltip = controller.get_ActiveToolTip();
            if (tooltip) tooltip.hide();
        }, 1000);
    }
    function showhide(id) {
        if (document.getElementById) {
            obj = document.getElementById(id);
            if (obj.style.display == "none") {
                obj.style.display = "";
            } else {
                obj.style.display = "none";
            }
        }
    }

    var currentTextBox = null;
    var currentDatePicker = null;
    var currentDataKey = '';

    //This method is called to handle the onclick and onfocus client side events for the texbox
    function showPopup(sender, e) {
        currentTextBox = sender.tagName == "INPUT" ? sender : $telerik.getPreviousHtmlNode(sender);
        var datePicker = $find("<%= RadDatePicker1.ClientID %>");
        currentDatePicker = datePicker;
        datePicker.set_selectedDate(currentDatePicker.get_dateInput().parseDate(currentTextBox.value));
        var position = $telerik.getLocation(currentTextBox);
        datePicker.showPopup(position.x, position.y + currentTextBox.offsetHeight);
    }

    //this handler is used to set the text of the TextBox to the value of selected from the popup
    function dateSelected(sender, args) {
        if (currentTextBox != null) {
            currentTextBox.value = args.get_newValue();
            //alert('dateSelected');
            //alert(currentDataKey);
            DataChange(currentDataKey, 'txt', currentTextBox.name, currentTextBox.value);
        }
    }

    function setDataKey(datakey) {
        currentDataKey = datakey;
    }

    //this function is used to parse the date entered or selected by the user
    function parseDate(sender, e) {
        if (currentDatePicker != null) {
            var date = currentDatePicker.get_dateInput().parseDate(sender.value);
            var dateInput = currentDatePicker.get_dateInput();

            if (date == null) {
                date = currentDatePicker.get_selectedDate();
            }

            var formattedDate = dateInput.get_dateFormatInfo().FormatDate(date, dateInput.get_displayDateFormat());
            sender.value = formattedDate;
        }
    }
    function RadToolbarScheduleJsOnClientButtonClicking(sender, args) {
        var commandName = args.get_item().get_commandName();
        if (commandName == "New") {
            OpenRadWindow('', 'TrafficSchedule_AddNew.aspx', 0, 0, false);
            return false;
        }
    }

    function makeNotationLabelsSameSize() {
        var maxWidth = 0;
        $(".pred-label-wrap > span").each(function () {
            var curWidth = $(this).width();
            if (curWidth > maxWidth) {
                maxWidth = curWidth;
            }
        });
        $(".pred-label-wrap").css('width', maxWidth + 'px');
        alignColumns();
    }

    function predInputChanged(sender, args) {
        var dataItem = sender.get_parent();
        var preds = sender.get_value().toString();
        var jobNumber = dataItem.getDataKeyValue("JobNumber");
        var jobComponent = dataItem.getDataKeyValue("JobComponentNumber");
        var sequenceNumber = dataItem.getDataKeyValue("SequenceNumber");
        var dataKey = jobNumber + '|' + jobComponent + '|' + sequenceNumber
        try {
            $.ajax({
                type: 'POST',
                url: 'TrafficSchedule.aspx/UpdatePredecessors',
                data: JSON.stringify({ "DataKey": dataKey, "Predecessors": preds }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    SetPredecessorLabelText(dataItem, response.d);
                },
                error: function (response) {
                    ShowMessage('Predecessors failed to save.');
                }
            });
        } catch (err) {
            console.log(err);
        }
    }
    
        </script>
    </telerik:RadScriptBlock>
    <style type="text/css">
        .w110 { 
            width:110px !important;
            min-width:110px !important;
            max-width:110px !important;
        }
        .wait {
            cursor: move !important;
        }
        .Greyed {
            opacity: 0.4;
            filter: alpha(opacity=40);
        }
        .col1,
        .col2 {
            margin: 0;
            padding: 0 5px 0 0;
            line-height: 14px;
            float: left;
            overflow: hidden;
        }
        .col1
        {
            width: 80px;
        }
        .col2
        {
            width: 200px;
        }
        .ruler {
            visibility: hidden;
            white-space: nowrap;
        }
    </style>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    <telerik:RadToolBar ID="RadToolbarSchedule" runat="server" AutoPostBack="true" Width="100%"
        OnClientButtonClicking="RadToolbarScheduleJsOnClientButtonClicking">
        <Items>
            <telerik:RadToolBarButton IsSeparator="true" Value="RadToolBarButtonSeparator0" />
            <telerik:RadToolBarButton ID="RadToolBarButtonSaveTemplate" SkinID="RadToolBarButtonSave" Visible="False" Text="Save as Template" Value="SaveTemplate" ToolTip="Save this Schedule as a Template" />
            <telerik:RadToolBarButton ID="RadToolbarButtonSaveAll" SkinID="RadToolBarButtonSave" Visible="false" Text="" Value="SaveHeader" ToolTip="Save header" />
            <telerik:RadToolBarButton ID="RadToolbarButtonClear" SkinID="RadToolBarButtonFind" Text="Search" Value="Search" ToolTip="Search" />
            <telerik:RadToolBarButton ID="RadToolbarButtonNew" SkinID="RadToolBarButtonNew" Text="New" CommandName="New" Value="New" ToolTip="Add new" />
            <telerik:RadToolBarButton IsSeparator="true" Value="Separator1" />
            <telerik:RadToolBarButton ID="RadToolBarButtonUpdateStatus" Text="Update Status" Value="UpdateStatus" ToolTip="Update status based on task status" />
            <telerik:RadToolBarButton ID="RadToolBarButtonJobOrder" Text="Order" CommandName="Order" ToolTip="Calculate by Order" Value="Order" Group="Calculate" AllowSelfUnCheck="true" CheckOnClick="false" />
            <telerik:RadToolBarButton ID="RadToolBarButtonVersions" Text="Versions" Value="Versions" ToolTip="Create and Apply Schedule Versions" Visible="True" />
            <telerik:RadToolBarButton IsSeparator="true" Value="Separator2" />
            <telerik:RadToolBarButton ID="RadToolbarButtonViewSingle" Text="Grid" Visible="false" Value="FilterSingle" Enabled="False" ToolTip="View Grid" />
            <telerik:RadToolBarButton ID="RadToolbarButtonViewMulti" Text="Multi" Value="ViewMulti" Enabled="true" ToolTip="View multiple schedules" />
            <telerik:RadToolBarButton ID="RadToolbarButtonViewWorksheet" Visible="false" Text="Worksheet" Value="ViewWorksheet" ToolTip="View worksheet" />
            <telerik:RadToolBarButton ID="RadToolbarButtonGanttView" Text="Gantt" Value="GanttView" ToolTip="View Gantt" Visible="True" />
            <telerik:RadToolBarButton IsSeparator="true" Value="Separator3" />
            <telerik:RadToolBarButton ID="RadToolbarButtonNewJobAlert" SkinID="RadToolBarButtonNewAlert" Text="" Value="NewJobAlert" ToolTip="New Alert" />
            <telerik:RadToolBarButton ID="RadToolbarButtonNewAlertAssignment" SkinID="RadToolBarButtonNewAssignment" Text="" Value="NewAlertAssignment" ToolTip="New Assignment" />
            <telerik:RadToolBarDropDown Text="Modules">
                <Buttons>
                    <telerik:RadToolBarButton ID="radbtnCalendar" Text="Calendar" Value="Calendar" ToolTip=" View Calendar" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonScheduleAlerts" Value="ScheduleAlerts" ToolTip="Schedule Alerts" Text="Alerts" />
                    <telerik:RadToolBarButton ID="radbtnAlert" Visible="false" Value="Alerts" ToolTip="Job Alerts" Text="Alerts" />
                    <telerik:RadToolBarButton ID="radbtnDocs" Text="Documents" Value="Docs" ToolTip="Documents" />
                    <telerik:RadToolBarButton ID="radbtnJobTemplate" Text="Job Jacket" Value="JobJacket" ToolTip="Job Jacket" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonEstimate" Text="Estimate" Value="Estimate" ToolTip="Estimate" />
                </Buttons>
            </telerik:RadToolBarDropDown>
            <telerik:RadToolBarButton ID="RadToolbarButtonCheckWorkload" Text="Workload" Value="CheckWorkload" Enabled="true" ToolTip="Workload Analysis" />
            <telerik:RadToolBarButton ID="RadToolbarTemplateButtonStatus" Text="Risk Analysis" Value="Status" ToolTip="Risk Analysis" />
            <telerik:RadToolBarButton IsSeparator="true" Value="Separator4" />
            <telerik:RadToolBarButton ID="RadToolbarButtonSetting" SkinID="RadToolBarButtonSettings" Text="Settings" Value="ColumnSettings" ToolTip="Set column preferences" />
            <telerik:RadToolBarButton IsSeparator="true" Value="Separator5" />
            <telerik:RadToolBarDropDown Text="Print/Send">
                <Buttons>
                    <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print" />
                    <telerik:RadToolBarButton Text="Send Alert" Value="SendAlert" ToolTip="Send Alert" />
                    <telerik:RadToolBarButton Text="Send Assignment" Value="SendAssignment" ToolTip="Send Assignment" />
                    <telerik:RadToolBarButton Text="Send Email" Value="SendEmail" ToolTip="Send Email" />
                    <telerik:RadToolBarButton Text="Options" Value="PrintSendOptions" ToolTip="Print/Send Options" />
                </Buttons>
            </telerik:RadToolBarDropDown>
            <telerik:RadToolBarButton IsSeparator="true" Value="Separator6" />
            <telerik:RadToolBarButton ID="RadToolbarTemplateButtonRefresh" SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh" />
            <telerik:RadToolBarButton IsSeparator="true" Value="Separator7" />
            <telerik:RadToolBarButton ID="RadToolBarButtonBookmark" SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" Visible="false" />
        </Items>
    </telerik:RadToolBar>
    <div class="telerik-aqua-body">
         <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server"
                TitleText="Job Information">
                <div style="text-align: right;">
                    <asp:Label ID="LblRush" runat="server" Text="RUSH&nbsp;&nbsp;" Visible="false" CssClass="warning"
                        Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="LblClosed" runat="server" Text="CLOSED&nbsp;&nbsp;" CssClass="warning"
                        Font-Bold="True" Font-Size="X-Large" Visible="false"></asp:Label>
                </div>
                <div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Client:
                            </div>
                            <div class="code-description-description">
                                <asp:LinkButton ID="LinkButtonClient" runat="server"></asp:LinkButton>
                                <asp:HiddenField ID="HiddenFieldClientCode" runat="server" />
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Division:
                            </div>
                            <div class="code-description-description">
                                <asp:LinkButton ID="LinkButtonDivision" runat="server"></asp:LinkButton>
                                <asp:HiddenField ID="HiddenFieldDivisionCode" runat="server" />
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Product:
                            </div>
                            <div class="code-description-description">
                                <asp:LinkButton ID="LinkButtonProduct" runat="server"></asp:LinkButton>
                                <asp:HiddenField ID="HiddenFieldProductCode" runat="server" />
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                            </div>
                            <div class="code-description-description">
                            </div>
                        </div>
                    </div>
                    <div style="display: inline-block;">
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Job:
                            </div>
                            <div class="code-description-description">
                                <asp:LinkButton ID="LinkButtonJob" runat="server"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Component:
                            </div>
                            <div class="code-description-description">
                                <asp:LinkButton ID="LinkButtonJobComponent" runat="server"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Account Executive:
                            </div>
                            <div class="code-description-description">
                                <asp:LinkButton ID="LBtnAccountExecutive" runat="server" Visible="false"></asp:LinkButton>
                                <asp:Label ID="LblAccountExecutive" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="HfAECode" runat="server" />
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:LinkButton ID="LinkButtonVersions" runat="server" Text="Version:"></asp:LinkButton>
                            </div>
                            <div class="code-description-description">
                                <asp:LinkButton ID="LinkButtonVersionInformation" runat="server"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelComments" runat="server"
                TitleText="Comments">
                <div style="padding: 0px;">
                    <asp:TextBox ID="TxtComments" runat="server" Height="50px" TabIndex="7" Text="" TextMode="MultiLine"
                        Width="650px"></asp:TextBox>
                </div>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelOtherInformation" runat="server" TitleText="Other Information" Collapsed="true">
                <div>
                    <div class="code-description-container" style="display:inline-block;">
                        <div class="code-description-label">
                            Date Shipped:
                        </div>
                        <div class="code-description-code">
                            <telerik:RadDatePicker ID="RadDatePickerDateShipped" runat="server" AutoPostBack="true"
                                SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="CalendarDateShipped" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                    <div class="code-description-container" style="display: inline-block;">
                        <div class="code-description-label">
                            Received By:
                        </div>
                        <div class="code-description-description">
                            <asp:TextBox ID="TxtReceivedBy" runat="server" MaxLength="40" TabIndex="10" Text=""
                                SkinID="TextBoxCodeSingleLineDescription"> </asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="code-description-container" style="display: inline-block;">
                        <div class="code-description-label">
                            Date Delivered:
                        </div>
                        <div class="code-description-code">
                            <telerik:RadDatePicker ID="RadDatePickerDateDelivered" runat="server" AutoPostBack="true"
                                SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="CalendarDateDelivered" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                    <div class="code-description-container" style="display: inline-block;">
                        <div class="code-description-label">
                            Reference:
                        </div>
                        <div class="code-description-description">
                            <asp:TextBox ID="TxtReference" runat="server" MaxLength="150" TabIndex="11" Text=""
                                SkinID="TextBoxCodeSingleLineDescription"> </asp:TextBox>
                        </div>
                    </div>
                </div>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelAssignments" runat="server" TitleText="Assignments">
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlASSIGN_1" runat="server" NavigateUrl="~/LookUp_Quick.aspx"></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtASSIGN_1Code" runat="server" MaxLength="6" TabIndex="12" Text=""
                            SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtASSIGN_1Description" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" Width="225px"></asp:TextBox>
                        <asp:Literal ID="LitASSIGN1_Manager" runat="server" Text="(Manager)" Visible="false"></asp:Literal>
                        <asp:HiddenField ID="HfOld_ASSIGN1" runat="server" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlASSIGN_2" runat="server" NavigateUrl="~/LookUp_Quick.aspx"></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtASSIGN_2Code" runat="server" MaxLength="6" TabIndex="13" Text=""
                            SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtASSIGN_2Description" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" Width="225px"></asp:TextBox>
                        <asp:Literal ID="LitASSIGN2_Manager" runat="server" Text="(Manager)" Visible="false"></asp:Literal>
                        <asp:HiddenField ID="HfOld_ASSIGN2" runat="server" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlASSIGN_3" runat="server" NavigateUrl="~/LookUp_Quick.aspx"></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtASSIGN_3Code" runat="server" MaxLength="6" TabIndex="14" Text=""
                            SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtASSIGN_3Description" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" Width="225px"></asp:TextBox>
                        <asp:Literal ID="LitASSIGN3_Manager" runat="server" Text="(Manager)" Visible="false"></asp:Literal>
                        <asp:HiddenField ID="HfOld_ASSIGN3" runat="server" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlASSIGN_4" runat="server" NavigateUrl="~/LookUp_Quick.aspx"></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtASSIGN_4Code" runat="server" MaxLength="6" TabIndex="15" Text=""
                            SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtASSIGN_4Description" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" Width="225px"></asp:TextBox>
                        <asp:Literal ID="LitASSIGN4_Manager" runat="server" Text="(Manager)" Visible="false"></asp:Literal>
                        <asp:HiddenField ID="HfOld_ASSIGN4" runat="server" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlASSIGN_5" runat="server" NavigateUrl="~/LookUp_Quick.aspx"></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtASSIGN_5Code" runat="server" MaxLength="6" TabIndex="16" Text=""
                            SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtASSIGN_5Description" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" Width="225px"></asp:TextBox>
                        <asp:Literal ID="LitASSIGN5_Manager" runat="server" Text="(Manager)" Visible="false"></asp:Literal>
                        <asp:HiddenField ID="HfOld_ASSIGN5" runat="server" />
                    </div>
                </div>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelJobs" runat="server"
                TitleText="Related Jobs">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div style="margin: 0px 0px 10px 0px;">
                        <div style="display: inline-block; width:200px;">
                            Jobs that precede this job:
                        </div>
                        <div style="display: inline-block;">
                            <telerik:RadListBox ID="RadListBoxJobCompPred" runat="server" Height="100px" Width="400px" AllowDelete="True" AutoPostBack="False" AutoPostBackOnDelete="True">
                            </telerik:RadListBox>
                            <asp:ImageButton ID="ImageButtonJobCompPred" runat="server" SkinID="ImageButtonAdd" ToolTip="Add Job/Component Predecessors" />
                        </div>
                    </div>
                    <div>
                        <div style="display: inline-block; width:200px;">
                            Jobs that follow this job:
                        </div>
                        <div style="display: inline-block;">
                            <telerik:RadListBox ID="RadListBoxPredecessors" runat="server" Height="100px" Width="400px" AllowDelete="True" AutoPostBack="False" AutoPostBackOnDelete="True">
                            </telerik:RadListBox>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelDetails" runat="server" TitleText="Task Details">
                <div>
                    <div class="code-description-container" style="display: inline-block;">
                        <div class="code-description-label">
                            <div style="display: inline-block;">
                                <asp:RadioButton ID="RblCalcOnStartDate" runat="server" GroupName="CalcOn" AutoPostBack="true" />
                            </div>
                            <div style="display: inline-block;">
                                Start Date
                            </div>
                        </div>
                        <div class="code-description-code">
                            <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" AutoPostBack="true"
                                SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                    <div class="code-description-container" style="display: inline-block;">
                        <div class="code-description-label">
                            <div style="display: inline-block;">
                                <asp:RadioButton ID="RblCalcOnDueDate" runat="server" GroupName="CalcOn" AutoPostBack="true" />
                            </div>
                            <div style="display: inline-block;">
                                Due Date
                            </div>
                        </div>
                        <div class="code-description-code">
                            <telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server" AutoPostBack="true"
                                SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="CalendarDueDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="code-description-container" style="display: inline-block;">
                        <div class="code-description-label">
                            Gut % Complete
                        </div>
                        <div class="code-description-code">
                            <asp:TextBox ID="TextboxGutPercentComplete" runat="server" Style="text-align: right; min-width: 68px; width: 68px;"
                                MaxLength="6" onKeyUp="isLessThen101(this)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="code-description-container" style="display: inline-block;margin-left:29px;">
                        <div class="code-description-label">
                            Completed Date
                        </div>
                        <div class="code-description-code">
                            <telerik:RadDatePicker ID="RadDatePickerJobCompleted" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="CalendarJobCompleted" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlTrafficStatus" runat="server" NavigateUrl="~/Blank.htm">Status:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtTrafficStatusCode" runat="server" CssClass="RequiredInput" MaxLength="10"
                            ReadOnly="false" TabIndex="19" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtTrafficStatusDescription" runat="server" CssClass="RequiredInput"
                            ReadOnly="true" TabIndex="-1" Text="" Width="225px"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                    </div>
                    <div class="code-description-description">
                        <asp:CheckBox ID="ChkShowCompletedTasks" runat="server" Checked="true" Text="Include Completed Tasks" AutoPostBack="true" />
                    </div>
                </div>
            </ew:CollapsablePanel>
            <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
                <script type="text/javascript">
                    function JsOnClientButtonClicking(sender, args) {
                        var commandName = args.get_item().get_commandName();
                        if (commandName == "DeleteRows") {
                            ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                            radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                        };
                        if (commandName == "ClearAll") {
                            ////args.set_cancel(!confirm('Are you sure you want to clear all assignments?'));
                            radToolBarConfirm(sender, args, "Are you sure you want to clear all assignments?");
                        };
                        if (commandName == "CalculateDates") {
                            ////args.set_cancel(!confirm('This job is a predecessor.  All jobs associated with this job will be calculated.  Are you sure you want to calculate?'));
                            radToolBarConfirm(sender, args, "This job is a predecessor.  All jobs associated with this job will be calculated.  Are you sure you want to calculate?");
                        };
                        if (commandName == "NoPostBack") {
                            args.set_cancel(true);
                        };

                        //if (comandName == "RadToolBarSplitButtonOriginalDueDate") {
                        //    args.set_cancel();
                        //    return false;
                        //};
                    };

                    function RadContextMenuGridItemClicking(sender, args) {
                        var itemValue = args.get_item().get_value();
                        if (itemValue == "DeleteTask") {
                            ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                            radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                        };
                    };
                </script>
            </telerik:RadScriptBlock>
            <div id="gridToolBarWrap">

            <telerik:RadToolBar ID="RadToolbarScheduleGrid" runat="server" AutoPostBack="true"
                OnClientButtonClicking="JsOnClientButtonClicking" Width="100%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" Value="SeparatorQuickEdit" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonQuickEdit" SkinID="RadToolBarButtonEdit"
                        Text="Quick Edit" Value="QuickEdit" ToolTip="Quick Edit" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Value="RadToolBarButtonTasksTooltip" Text="Tasks" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Value="RadToolBarButtonDatesTooltip" Text="Dates" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Value="RadToolBarButtonEmployeesTooltip" Text="Employees" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton runat="server" Width="300" id="RadToolbarButtonPhase" Value="RadToolbarButtonPhase">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="DropPhaseFilter" runat="server" AutoPostBack="true" AppendDataBoundItems="true" Label="Phase Filter:"
                                DropDownWidth="175" Width="175" Visible="true">
                                <Items>
                                    <telerik:RadComboBoxItem Text="[No Filter]" Value="no_filter"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                            &nbsp;&nbsp;
                            <telerik:RadComboBox ID="DropSort" runat="server" AutoPostBack="true" Width="120" Label="Sort:">
                                <Items>
                                    <telerik:RadComboBoxItem Text="Order" Value="order"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="Phase/Order" Value="phase"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="Start/Due" Value="startdue"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>
            </div>
            <telerik:RadToolTip ID="RadToolTipTasks" runat="server" SkinID="RadToolTipToolbarContentArea" Width="600" Height="220" TargetControlID="RadToolBarButtonTasksTooltip">
                <div style="width: 275px; float: left; position: relative;">
                    <div style="font-size: larger;">
                        Add Tasks
                    </div>
                    <div>
                        <div style="padding: 11px 0px 0px 0px;">
                            <asp:Button ID="ButtonAddTasksFromListOfTasks" runat="server" Text="Manually or from list of tasks" ToolTip="Add task(s) from a list of all available tasks and/or manually add tasks with no function code" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonAddTasksFromTaskTemplates" runat="server" Text="From task templates" ToolTip="Add task(s) from predefined task templates or save current tasks as a template" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonAddTasksCopyFromExistingSchedule" runat="server" Text="From an existing schedule" ToolTip="Copy the task(s) from another schedule to this one" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonAddTasksCreateFromEstimate" runat="server" Text="Create from estimate" ToolTip="Create task(s) from estimate functions" Width="250" />
                        </div>
                    </div>
                </div>
                <div style="width: 275px; float: right; position: relative;">
                    <div style="font-size: larger;">
                        Other Task Actions
                    </div>
                    <div>
                        <div style="padding: 11px 0px 0px 0px;">
                            <asp:Button ID="ButtonDeleteSelectedTasks" runat="server" Text="Delete selected tasks" ToolTip="" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonSearchAndReplaceInTasks" runat="server" Text="Search and replace" ToolTip="" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonFilterTasks" runat="server" Text="Filter" ToolTip="" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:CheckBox ID="CheckBoxAutoStatusUpdateTasks" runat="server" Text="Auto Status" ToolTip="Automatically update status when changing task completed date" AutoPostBack="true" />
                        </div>
                    </div>
                </div>
            </telerik:RadToolTip>
            <telerik:RadToolTip ID="RadToolTipDates" runat="server" SkinID="RadToolTipToolbarContentArea" Width="620" Height="250" TargetControlID="RadToolBarButtonDatesTooltip">
                <div style="width: 285px; float: left; position: relative;">
                    <div style="font-size: larger;">
                        Date Actions
                    </div>
                    <div>
                        <div style="padding: 11px 0px 0px 0px;">
                            <asp:Button ID="ButtonDatesCalculate" runat="server" Text="Calculate dates" ToolTip="Automatically calculate dates based on schedule settings" Width="260" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonDatesMarkTempComplete" runat="server" Text="Mark temp complete" ToolTip="" Width="260" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonDatesClear" runat="server" Text="Clear Dates" ToolTip="Clear all dates except original due date & temp complete date." Width="260" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonDatesClearIncludeOriginal" runat="server" Text="Clear Dates including Original Due Date" ToolTip="Clear all dates except temp complete date." Width="260" />
                        </div>
                    </div>
                </div>
                <div style="width: 285px; float: right; position: relative;">
                    <div style="font-size: larger;">
                        Set original due date
                    </div>
                    <div>
                        <div style="padding: 11px 0px 0px 0px;">
                            <asp:Button ID="ButtonSetOriginalDueDateOnlyWhereNotSet" runat="server" Text="Only for tasks where it is not set" ToolTip="Set original due date to current due date for tasks that don't have an original due date" Width="260" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonSetOriginalDueDateOnlySelected" runat="server" Text="Only selected tasks" ToolTip="Set original due date to the current due date for selected tasks" Width="260" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonSetOriginalDueDateAll" runat="server" Text="For all tasks" ToolTip="Set original due date to the current due date for all tasks" Width="260" />
                        </div>
                    </div>
                </div>
            </telerik:RadToolTip>
            <telerik:RadToolTip ID="RadToolTipEmployees" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="220" TargetControlID="RadToolBarButtonEmployeesTooltip">
                <div style="width: 275px; float: left; position: relative;">
                    <div style="font-size: larger;">
                        Employee Actions
                    </div>
                    <div>
                        <div style="padding: 11px 0px 0px 0px;">
                            <asp:Button ID="ButtonEmployeesSetTeamByFunction" runat="server" Text="Set team by function" ToolTip="" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonEmployeesSetTeamByRole" runat="server" Text="Set team by role" ToolTip="" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonEmployeesFind" runat="server" Text="Find employees" ToolTip="" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonEmployeesClearAllAssignments" runat="server" Text="Clear all assignments" ToolTip="" Width="250" />
                        </div>
                    </div>
                </div>
            </telerik:RadToolTip>

            <telerik:RadGrid ID="RadGridProjectSchedule" runat="server" AllowMultiRowSelection="true" AllowSorting="false" ShowFooter="true" HorizontalAlign="Center"
                AutoGenerateColumns="false" GridLines="None" EnableEmbeddedSkins="true" AllowPaging="false" PageSize="10" AllowCustomPaging="True">
                <GroupHeaderItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <GroupPanel>
                    <PanelItemsStyle HorizontalAlign="Left" />
                    <PanelStyle HorizontalAlign="Left" />
                </GroupPanel>
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                <ClientSettings AllowRowsDragDrop="true" AllowColumnHide="true">
                    <Scrolling AllowScroll="false" SaveScrollPosition="true" UseStaticHeaders="false" />
                    <Selecting AllowRowSelect="true" />
                    <ClientEvents OnRowSelecting="CancelNonInputSelect" OnRowSelected="CheckRowSelection" OnRowDeselecting="CancelNonInputSelect" OnRowDeselected="CheckRowSelection" OnHierarchyExpanded="alignColumns"
                        OnHierarchyCollapsed="alignColumns" OnRowContextMenu="OnRowContextMenu" OnRowMouseOver="" OnRowDragStarted="function() { dragging = true; }" OnRowDropping="function() { dragging = false; }"
                        OnGridCreated="function(s, e) { makeNotationLabelsSameSize(); alignColumns(); styleParentRows(); setCustomPaging(); }" />
                </ClientSettings>
                <HeaderContextMenu>
                    <CollapseAnimation Type="OutQuint" Duration="200" />
                </HeaderContextMenu>
                <MasterTableView DataKeyNames="JobNumber, JobComponentNumber, SequenceNumber, HasAssignment, HasAlerts, ID, ParentTaskSequenceNumber" NoMasterRecordsText="No Records" AllowMultiColumnSorting="true" AllowSorting="false"
                    HierarchyLoadMode="Client" FilterExpression="" ClientDataKeyNames="ID, JobNumber, JobComponentNumber, SequenceNumber, ParentTaskSequenceNumber">
                    <NoRecordsTemplate>
                        Drop row(s) here to create a task group.
                    </NoRecordsTemplate>
                    <SelfHierarchySettings KeyName="SequenceNumber" ParentKeyName="ParentTaskSequenceNumber" />
                    <Columns>
                        <telerik:GridDragDropColumn UniqueName="DragDropColumn" ItemStyle-CssClass="ps-drag-drop-column">
                    
                        </telerik:GridDragDropColumn>
                        <telerik:GridTemplateColumn UniqueName="ColumnLevelNotation" Visible="true">
                            <HeaderTemplate>
                                <input id="CheckBoxSelectAllRows" type="checkbox" name="CheckBoxSelectAllRows" onclick="SelectAllRows(this.checked)" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="notation-wrapper">
                                    <asp:Label ID="LabelLevelNotation" runat="server" Text="" style="display:inline-block;" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="PhaseDescription" Visible="False" HeaderText="Phase"
                            SortExpression="PhaseDescription" UniqueName="colPHASE_DESC">
                            <ItemTemplate>
                                <telerik:RadComboBox ID="RadComboBoxPhaseDescription" runat="server" EnableLoadOnDemand="true"
                                    OnItemsRequested="RadComboBoxPhaseDescription_ItemsRequested" OnClientDropDownOpening="LoadComboItems" InputCssClass="no-border" SkinID="RadComboBoxText30">
                                </telerik:RadComboBox>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-RadComboBoxText30-col" />
                            <ItemStyle CssClass="ps-RadComboBoxText30-col" />
                            <FooterStyle CssClass="ps-RadComboBoxText30-col" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="TaskCode" Visible="False" HeaderText="Task Code"
                            SortExpression="TaskCode" UniqueName="colTASK_CODE">
                            <ItemTemplate>
                                <div class="ps-radgrid-code-column">
                                    <asp:TextBox ID="TextBoxTaskCode" runat="server" MaxLength="10" Text='<%# Eval("TaskCode")%>' SkinID="TextBoxCodeMedium" ></asp:TextBox>
                                    <asp:HiddenField ID="HiddenFieldTaskCode" runat="server" Value='<%# Eval("TaskCode")%>' />
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-radgrid-code-column"  />
                            <ItemStyle CssClass="ps-radgrid-code-column" />
                            <FooterStyle CssClass="ps-radgrid-code-column" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="" Visible="False" HeaderText="" UniqueName="colTASK_CODE_LOOKUP" ItemStyle-Width="16px">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonTaskCode" runat="server" SkinID="ImageButtonFind"
                                        AlternateText="Lookup task code" ToolTip="Lookup task code" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="TaskDescription" Visible="False" HeaderText="Task Description"
                            SortExpression="TaskDescription" UniqueName="colTASK_DESCRIPTION">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxTaskDescription" runat="server" MaxLength="40" Text='<%# Eval("TaskDescription")%>' SkinID="TextBoxText20" ></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-radgrid-description-column" />
                            <ItemStyle CssClass="ps-radgrid-description-column" />
                            <FooterStyle CssClass="ps-radgrid-description-column" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSpacer" Visible="true" ItemStyle-Width="1px" HeaderStyle-Width="1px">
                            <ItemTemplate>
                                <div style="width: 1px; min-width: 1px;"></div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="ColumnMove" HeaderText="" Visible="false" ItemStyle-Width="60px">
                            <ItemTemplate>
                                <div class="ps-radgrid-iconX2-column">
                                    <ul>
                                        <li>
                                            <asp:ImageButton runat="server" CommandName="MoveLeft" ID="ImageButtonMoveLeft" ToolTip="Move out"
                                                CssClass="icon-image" ImageUrl="~/Images/Icons/Grey/256/indent_decrease.png" Visible="true" /></li>
                                        <li>
                                            <asp:ImageButton runat="server" CommandName="MoveRight" ID="ImageButtonMoveRight" ToolTip="Move in"
                                                CssClass="icon-image" ImageUrl="~/Images/Icons/Grey/256/indent_increase.png" Visible="true" /></li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="ColumnLinked" Visible="false">
                            <ItemTemplate>
                                <div class="radgrid-icon-column">
                                    <telerik:RadButton ID="RadButtonLinked" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" Visible="true"
                                        AutoPostBack="false" OnClientCheckedChanged="LinkedOnClientCheckedChanged">
                                        <ToggleStates>
                                            <telerik:RadButtonToggleState ImageUrl="~/Images/Icons/Grey/256/link_broken.png" CssClass="icon-image" />
                                            <telerik:RadButtonToggleState ImageUrl="~/Images/Icons/Grey/256/link.png" CssClass="icon-image" Selected="true" />
                                        </ToggleStates>
                                    </telerik:RadButton>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSelectPreds" Visible="false">
                            <ItemTemplate>
                                <div class="radgrid-icon-column">
                                    <telerik:RadToolTip ID="RadToolTipAddPredecessors" runat="server" RenderMode="Classic" Position="MiddleRight" TargetControlID="ImageButtonAddPredecessors" OffsetX="15"></telerik:RadToolTip>
                                    <asp:ImageButton ID="ImageButtonAddPredecessors" runat="server" Visible="true" ImageUrl="~/Images/Icons/Grey/256/link_add.png" CssClass="icon-image" CommandName="PickPredecessors" ToolTip="" /><asp:CheckBox ID="CheckBoxSelectPredecessor" runat="server" Checked="false" AutoPostBack="false" Visible="false" />
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnInputPreds" Visible="false" HeaderText="Predecessors">
                            <ItemTemplate>
                                <div class="ps-radgrid-code-medium-column">
                                    <telerik:RadTextBox ID="RadTextBoxPredecessors" runat="server" SkinID="RadTextBoxCodeMedium" >
                                        <ClientEvents OnBlur="predInputChanged" />
                                    </telerik:RadTextBox>
                                </div>
                            </ItemTemplate>
                            <ItemStyle CssClass="ps-radgrid-code-medium-column" />
                            <HeaderStyle CssClass="ps-radgrid-code-medium-column" />
                            <FooterStyle CssClass="ps-radgrid-code-medium-column" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnPreds" Visible="false">
                            <ItemTemplate>
                                <div class="pred-label-wrap">
                                    <asp:Label ID="LabelPredecessorsLabel" runat="server" Text='<%#Eval("PredecessorLevelNotation")%>' style="white-space: nowrap; display: block;" />
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="pred-label-wrap" />
                            <ItemStyle CssClass="pred-label-wrap" />
                            <FooterStyle CssClass="pred-label-wrap" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="colJOB_ORDER" HeaderText="Order" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxJobOrder" runat="server" Style="text-align: right; min-width: 30px; width: 30px;"
                                    MaxLength="4" Text='<%#Eval("JobOrder")%>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="36px" />
                            <HeaderStyle HorizontalAlign="Center" Width="36px" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="TaskStatus" Visible="False" HeaderText="Task Status"
                            SortExpression="TaskStatus" UniqueName="colTASK_STATUS">
                            <ItemTemplate>
                                <asp:Panel ID="PanelTaskStatus" runat="server" SkinID="colTASK_STATUS">
                                    <telerik:RadComboBox ID="RadComboBoxTaskStatus" runat="server" InputCssClass="no-border" SkinID="RadComboBoxText15">
                                        <Items>
                                            <telerik:RadComboBoxItem Value="P" Text="Projected"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Value="A" Text="Active"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Value="H" Text="High Priority"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Value="L" Text="Low Priority"></telerik:RadComboBoxItem>
                                        </Items>
                                    </telerik:RadComboBox>
                                </asp:Panel>
                            </ItemTemplate>
                            <ItemStyle CssClass="ps-RadComboBoxText15-col" />
                            <HeaderStyle CssClass="ps-RadComboBoxText15-col" />
                            <FooterStyle CssClass="ps-RadComboBoxText15-col" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" UniqueName="colMilestone" SortExpression="Milestone">
                            <ItemTemplate>
                                <div class="ps-checkbox-col">
                                    <asp:CheckBox ID="CheckBoxMilestone" runat="server" />
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-checkbox-col" />
                            <ItemStyle CssClass="ps-checkbox-col" />
                            <FooterStyle CssClass="ps-checkbox-col" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="JobDays" Visible="False" HeaderText="Days"
                            SortExpression="JobDays" UniqueName="colJOB_DAYS">
                            <ItemTemplate>
                                <div class="ps-TextBoxText3-col">
                                    <asp:TextBox ID="TextBoxJobDays" runat="server" Style="text-align: right;"
                                        MaxLength="3" Text='<%# Eval("JobDays")%>' SkinID="TextBoxText3"></asp:TextBox>
                                    <asp:Label ID="LabelJobDays" runat="server" Visible="false" Text='<%# Eval("JobDays")%>' />
                                </div>
                            </ItemTemplate>
                            <ItemStyle CssClass="ps-TextBoxText3-col" />
                            <HeaderStyle CssClass="ps-TextBoxText3-col" />
                            <FooterStyle CssClass="ps-TextBoxText3-col" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="TaskStartDate" Visible="False" HeaderText="Start Date"
                            SortExpression="TaskStartDate" UniqueName="colTASK_START_DATE">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxTaskStartDate" runat="server" MaxLength="10" Text='<%# Eval("TaskStartDate")%>' SkinID="TextBoxShortDate"></asp:TextBox>
                                <asp:Label ID="LabelTaskStartDate" runat="server" Text='<%# String.Format("{0:d}", Eval("TaskStartDate"))%>' Visible="false" SkinID="LabelShortDate"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                            <HeaderStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                            <FooterStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="JobRevisedDate" Visible="False"
                            SortExpression="JobRevisedDate" UniqueName="colJOB_REVISED_DATE">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxJobRevisedDate" runat="server" MaxLength="10" Text='<%# Eval("JobRevisedDate")%>' SkinID="TextBoxShortDate"></asp:TextBox>
                                 <asp:Label ID="LabelJobRevisedDate" runat="server" Text='<%# String.Format("{0:d}", Eval("JobRevisedDate"))%>' Visible="false" SkinID="LabelShortDate"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                            <HeaderStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                            <FooterStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" ItemStyle-HorizontalAlign="center" SortExpression="DueDateLock" UniqueName="colLock">
                            <HeaderTemplate>
                                <asp:Panel ID="PanelcolLockHeader" runat="server" SkinID="colLock">
                                    <asp:Image ID="ImageDueDateLock" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/Grey/256/lock.png" ToolTip="Lock start and due dates" />
                                </asp:Panel>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="radgrid-icon-column">
                                    <asp:CheckBox ID="CheckBoxDueDateLock" runat="server" />
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="radgrid-icon-column" HorizontalAlign="center" />
                            <ItemStyle CssClass="radgrid-icon-column" HorizontalAlign="center" />
                            <FooterStyle CssClass="radgrid-icon-column" HorizontalAlign="center" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="DueTime" Visible="False" HeaderText="Time Due"
                            SortExpression="RevisedDueTime" UniqueName="colDUE_TIME">
                            <ItemTemplate>
                                <div class="ps-TextBoxShortDate-col">
                                    <asp:TextBox ID="TextBoxRevisedDueTime" runat="server" MaxLength="10" Text='<%# Eval("RevisedDueTime")%>' AutoComplete="off" SkinID="TextBoxShortDate"></asp:TextBox>
                                    <asp:HiddenField ID="HiddenFieldRevisedDueTime" runat="server" Value='<%# Eval("RevisedDueTime")%>' />
                                    <asp:HiddenField ID="HiddenFieldDueTime" runat="server" Value='<%# Eval("DueTime")%>' />
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                            <ItemStyle CssClass="ps-TextBoxShortDate-col"  HorizontalAlign="Right" />
                            <FooterStyle CssClass="ps-TextBoxShortDate-col"  HorizontalAlign="Right" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="JobDueDate" Visible="False" HeaderText="Original<br />Due Date"
                            SortExpression="JobDueDate" UniqueName="colJOB_DUE_DATE">
                            <ItemTemplate>
                                <div class="ps-TextBoxShortDate-col">
                                    <asp:TextBox ID="TextBoxJobDueDate" runat="server" AutoComplete="off" SkinID="TextBoxShortDate" MaxLength="10"></asp:TextBox>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                            <ItemStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right"  />
                            <FooterStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right"  />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="JobCompletedDate" Visible="False" HeaderText="Completed"
                            SortExpression="JobCompletedDate" UniqueName="colJOB_COMPLETED_DATE">
                            <ItemTemplate>
                                <div class="ps-TextBoxShortDate-col">
                                    <asp:TextBox ID="TextBoxJobCompletedDate" runat="server" AutoComplete="off" SkinID="TextBoxShortDate" MaxLength="10"></asp:TextBox>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                            <ItemStyle CssClass="ps-TextBoxShortDate-col"  HorizontalAlign="Right" />
                            <FooterStyle CssClass="ps-TextBoxShortDate-col"  HorizontalAlign="Right" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="TemporaryCompleteDate" Visible="False" HeaderText="Temp Complete"
                            SortExpression="TemporaryCompleteDate" UniqueName="colTEMP_COMP_DATE">
                            <ItemTemplate>
                                <div class="ps-TextBoxShortDate-col">
                                    <asp:TextBox ID="TextBoxTemporaryCompleteDate" runat="server" AutoComplete="off" ReadOnly="true" SkinID="TextBoxShortDate" MaxLength="10"></asp:TextBox>
                                    <asp:Label ID="LabelTemporaryCompleteDate" runat="server" Text='<%# String.Format("{0:d}", Eval("TemporaryCompleteDate"))%>' Visible="false" SkinID="LabelShortDate" />
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                            <ItemStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right"  />
                            <FooterStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right"  />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="JobHours" Visible="False" HeaderText="Default Hours"
                            Aggregate="Custom" SortExpression="JobHours" UniqueName="colJOB_HRS">
                            <HeaderTemplate>
                                <div class="ps-TextBoxText5-col">
                                    Default<Br />Hours
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="ps-TextBoxText5-col" style="text-align: right;">
                                    <asp:TextBox ID="TextBoxJobHours" runat="server" Style="text-align: right;" MaxLength="6" Text='<%# Eval("JobHours")%>' SkinID="TextBoxText5"></asp:TextBox>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-TextBoxText5-col" HorizontalAlign="right"  />
                            <ItemStyle CssClass="ps-TextBoxText5-col"  />
                            <FooterStyle CssClass="ps-TextBoxText5-col align-r-pad" Font-Bold="true" HorizontalAlign="right" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="DispersedHours" Visible="False" HeaderText="Disbursed<br/>Hours"
                            Aggregate="Sum" SortExpression="DispersedHours" UniqueName="colDISPERSED_JOB_HRS">
                            <ItemTemplate>
                                <div class="ps-DispersedHours-col">
                                    <asp:LinkButton ID="LinkButtonDispersedHours" runat="server"
                                        CommandName="SetEmployees" Text='<%#Eval("DispersedHours")%>'></asp:LinkButton>
                                    <asp:Label ID="LabelDisbursedHours" runat="server" Visible="false" Text='<%#Eval("DispersedHours")%>' />
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-DispersedHours-col" HorizontalAlign="Right" />
                            <ItemStyle CssClass="ps-DispersedHours-col" HorizontalAlign="Right" />
                            <FooterStyle CssClass="ps-DispersedHours-col align-r-pad" HorizontalAlign="Right" Font-Bold="true" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="PostedHours" Visible="False" HeaderText="Posted<br/>Hours"
                            Aggregate="Sum" SortExpression="PostedHours" UniqueName="colPOSTED_HOURS">
                            <ItemTemplate>
                                <div class="ps-PostedHours-col">
                                    <asp:Label ID="LabelPostedHours" runat="server" Text='<%# Eval("PostedHours")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-PostedHours-col" HorizontalAlign="Right" />
                            <ItemStyle CssClass="ps-PostedHours-col" HorizontalAlign="Right" />
                            <FooterStyle CssClass="ps-PostedHours-col align-r-pad" HorizontalAlign="Right" Font-Bold="true" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="PercentComplete" Visible="False" HeaderText="Percent<br/>Complete"
                            SortExpression="PercentComplete" UniqueName="colPERC_COMPLETE">
                            <ItemTemplate>
                                <div class="ps-TextBoxShortDate-col">
                                    <asp:Label ID="LabelPercentComplete" runat="server" Text='<%# Eval("PercentComplete")%>' SkinID="LabelShortDate"></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-TextBoxShortDate-col" HorizontalAlign="Right" />
                            <ItemStyle CssClass="ps-TextBoxShortDate-col" />
                            <FooterStyle CssClass="ps-TextBoxShortDate-col" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="Employees" UniqueName="colEMP_CODE">
                            <ItemTemplate>
                                <div class="ps-EmployeesLink-col">
                                    <asp:LinkButton ID="LinkButtonEmployees" runat="server" CommandArgument='<%#Eval("SequenceNumber")%>'
                                        CommandName="SetEmployees" Text=''></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-EmployeesLink-col" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ps-EmployeesLink-col"  />
                            <FooterStyle CssClass="ps-EmployeesLink-col" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="Employees" UniqueName="colEMP_CODE_TEXT_AUTO">
                            <HeaderStyle CssClass="radgrid-textarea-column" />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>                        
                                <telerik:RadAutoCompleteBox ID="RadAutoCompleteBoxEmployees" runat="server" Delimiter="," Width="100%" AllowCustomEntry="false" Filter="StartsWith" InputType="Token"></telerik:RadAutoCompleteBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="Employees" UniqueName="colEMP_CODE_TEXT">
                            <HeaderStyle CssClass="radgrid-textarea-column" />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>  
                                <asp:TextBox ID="TextBoxEmployees" runat="server" Text="" TextMode="multiLine" CssClass="radgrid-textarea ps-radgrid-textarea"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" UniqueName="colEMP_CODE_IMGBTN">
                            <HeaderTemplate>
                        
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="radgrid-icon-column">
                                    <div id="DivEmployees" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonEmployees" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/users.png" ToolTip="Employees"
                                            CommandName="SetEmployees" />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column"/>
                            <FooterStyle CssClass="radgrid-icon-column" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="Client<br/>Contacts" UniqueName="colCLI_CONTACT">
                            <HeaderTemplate>
                                <div class="ps-linkBtnWithHdrText-col">
                                    Client<br />
                                    Contacts
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="ps-linkBtnWithHdrText-col">
                                    <asp:LinkButton ID="LinkButtonClientContacts" runat="server" CommandName="SetClientContacts" Text=''></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-linkBtnWithHdrText-col" />
                            <ItemStyle CssClass="ps-linkBtnWithHdrText-col" HorizontalAlign="Center" />
                            <FooterStyle CssClass="ps-linkBtnWithHdrText-col" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="Client Contacts" UniqueName="colCLI_CONTACT_TEXT">
                            <HeaderStyle CssClass="radgrid-textarea-column" />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>
                                <div class="radgrid-textarea-column">
                                    <asp:TextBox ID="TextBoxClientContacts" runat="server" Text="" TextMode="multiLine" CssClass="radgrid-textarea  ps-radgrid-textarea"></asp:TextBox>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" UniqueName="colCLI_CONTACT_IMGBTN">
                            <HeaderTemplate>
                                <div class="radgrid-icon-column">

                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="radgrid-icon-column">
                                    <div id="DivClientContacts" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonClientContacts" runat="server" CommandName="SetClientContacts" SkinID="ImageButtonClientContactWhite" />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="Estimate Function" UniqueName="colEstimateFunction"
                            SortExpression="FNC_EST">
                            <ItemTemplate>
                                <div class="ps-RadComboBoxText10-col">
                                    <telerik:RadComboBox ID="RadComboBoxEstimateFunction" runat="server" InputCssClass="no-border"
                                        DropDownWidth="350px" EnableLoadOnDemand="true" OnItemsRequested="RadComboBoxEstimateFunction_ItemsRequested"
                                        OnClientDropDownOpening="LoadComboItems" HighlightTemplatedItems="true" SkinID="RadComboBoxText10">
                                        <HeaderTemplate>
                                            <div class="grid-lookup-combobox-dropdown-container">
                                                <div class="grid-lookup-combobox-dropdown-code">Code</div>
                                                <div class="grid-lookup-combobox-dropdown-name">Description</div>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="grid-lookup-combobox-dropdown-container">
                                                <div class="grid-lookup-combobox-dropdown-code"><%# If(String.IsNullOrWhiteSpace(DataBinder.Eval(Container.DataItem, "Code")), "&nbsp;", DataBinder.Eval(Container.DataItem, "Code"))%></div>
                                                <div class="grid-lookup-combobox-dropdown-name"><%# DataBinder.Eval(Container.DataItem, "Description")%></div>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="ps-RadComboBoxText10-col"  />
                            <ItemStyle CssClass="ps-RadComboBoxText10-col" />
                            <FooterStyle CssClass="ps-RadComboBoxText10-col" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="&nbsp;" UniqueName="colComments">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <HeaderTemplate>

                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="radgrid-icon-column">
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonShowComments" runat="server" SkinID="ImageButtonCommentWhite" CommandName="ShowComments" />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="Task Comments" UniqueName="colFNC_COMMENTS"
                            SortExpression="FunctionComments">
                            <HeaderStyle CssClass="radgrid-textarea-column" />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>
                                <div class="radgrid-textarea-column">
                                    <asp:TextBox ID="TextBoxFunctionComments" runat="server" Text='<%#Eval("FunctionComments")%>' TextMode="multiLine" CssClass="radgrid-textarea ps-radgrid-textarea"></asp:TextBox>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="Due Date Comments" UniqueName="colDUE_DATE_COMMENTS"
                            SortExpression="DueDateComments">
                            <HeaderStyle CssClass="radgrid-textarea-column" />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxDueDateComments" runat="server" Text='<%#Eval("DueDateComments")%>' TextMode="multiLine" CssClass="radgrid-textarea ps-radgrid-textarea"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="Revision Comments" UniqueName="colREV_DATE_COMMENTS"
                            SortExpression="RevisionDateComments">
                            <HeaderStyle CssClass="radgrid-textarea-column" />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxRevisionDateComments" runat="server" Text='<%#Eval("RevisionDateComments")%>' TextMode="multiLine" CssClass="radgrid-textarea  ps-radgrid-textarea"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" HeaderText="" UniqueName="ColumnDocuments">
                            <HeaderTemplate>

                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="radgrid-icon-column">
                                    <div id="DivHasDocuments" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonHasDocuments" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/documents_empty.png"
                                            CommandName="Documents" ToolTip="Documents" />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" UniqueName="colSave">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <HeaderTemplate>
                                &nbsp;
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonSave" runat="server" AlternateText="Save task" ToolTip="Save task"
                                        CommandName="SaveRow" ImageAlign="AbsMiddle" SkinID="ImageButtonSaveWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="False" UniqueName="colDelete">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <HeaderTemplate>
                                &nbsp;
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="icon-background background-color-delete">
                                    <asp:ImageButton ID="ImageButtonDelete" runat="server" AlternateText="Delete task" ToolTip="Delete task"
                                        CommandName="DeleteRow" ImageAlign="AbsMiddle" SkinID="ImageButtonDeleteWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="true" UniqueName="GridTemplateColumnFiller"></telerik:GridTemplateColumn>
                    </Columns>
                    <ExpandCollapseColumn Resizable="false" Visible="false">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                </MasterTableView>
            </telerik:RadGrid>
            <br />
            <telerik:RadContextMenu ID="RadContextMenuGridItem" runat="server" OnItemClick="RadContextMenuGridItem_ItemClick" OnClientItemClicking="RadContextMenuGridItemClicking">
                <Items>
                    <telerik:RadMenuItem Text="Task Details" Value="TaskDetails"></telerik:RadMenuItem>
                    <telerik:RadMenuItem IsSeparator="true"></telerik:RadMenuItem>
                    <telerik:RadMenuItem Text="New Task Alert" Value="NewTaskAlert"></telerik:RadMenuItem>
                    <telerik:RadMenuItem Text="New Task Assignment" Value="NewTaskAssignment"></telerik:RadMenuItem>
                    <telerik:RadMenuItem IsSeparator="true"></telerik:RadMenuItem>
                    <%--<telerik:RadMenuItem Text="Copy Task" Value="CopyTask"></telerik:RadMenuItem>--%>
                    <telerik:RadMenuItem Text="Delete Task" Value="DeleteTask"></telerik:RadMenuItem>
                </Items>
            </telerik:RadContextMenu>
    </div>
   
    <asp:HiddenField ID="HiddenFieldSelectedRow" runat="server" />
    <asp:HiddenField ID="HiddenFieldLabels" runat="server" EnableViewState="false" />
    <asp:TextBox ID="TextBoxLabels" runat="server" Visible="true" Style="display: none;"></asp:TextBox>
    <telerik:RadDatePicker ID="RadDatePicker1" Style="display: none;" SkinID="RadDatePickerStandard" runat="server">
        <ClientEvents OnDateSelected="dateSelected" />
    </telerik:RadDatePicker>
    <asp:HiddenField ID="HfHasAlertAssignmentColor" Value="#DFEFFB" runat="server" />
    <asp:HiddenField ID="HiddenFieldWindowName" Value="" runat="server" />
    <asp:HiddenField ID="HiddenFieldSelectAll" runat="server" Value="0" />
    <asp:HiddenField ID="CustomGridPagingPageCount" runat="server" Value="" ClientIDMode="Static" />
    <asp:HiddenField ID="CustomGridPagingItemCount" runat="server" Value="" ClientIDMode="Static" />
    <asp:Label ID="LabelRuler" runat="server" CssClass="ruler" />
    <telerik:RadScriptBlock ID="sb2" runat="server">
        <style type="text/css">
            #gridToolBarWrap {
                z-index: 999;
            }
            .RadToolTipToolbarContentArea {
                z-index: 9999;
            }
        </style>
        <script type="text/javascript">

            $(function () {
                var gridNav = $('#gridToolBarWrap');
                var navHomeY = gridNav.offset().top;
                var navHeight = gridNav.height();
                var isFixed = false;
                var $w = $(window);
                $w.scroll(function () {
                    var scrollTop = $w.scrollTop();
                    var shouldBeFixed = scrollTop > navHomeY;
                    if (shouldBeFixed && !isFixed) {
                        gridNav.css({
                            position: 'fixed',
                            top: 0,
                            left: gridNav.offset().left,
                            width: gridNav.width()
                        });
                        isFixed = true;
                    } else if (!shouldBeFixed && isFixed) {
                        gridNav.css({
                            position: 'static',
                            height: navHeight
                        });
                        isFixed = false;
                    }
                });

            });

            function getRadWindowName() {
                try {
                    var oWnd = GetRadWindow();
                    var id = oWnd.get_name();
                    document.getElementById('<%= HiddenFieldWindowName.ClientID %>').value = id;
                } catch (err) {

                }
            }
            function OnClientBeforeShow(sender, args, datakey) {
                try {
                    var keyvalues = document.getElementById('<%= TextBoxLabels.ClientID%>').value;
                    //args.set_cancel(true);
                    PageMethods.GetPredecessorsLevelList(datakey, keyvalues, function (response) { ShowPredecessorToolTip(sender.get_id(), response); }, DataChangeFailed);
                    sender.set_content("Loading...");
                    return false;
                } catch (err) {
                    var idk = null;
                }
            }
            function ShowPredecessorToolTip(toolTipID, result) {
                try {
                    var response = JSON.parse(result);
                    if (response != null) {
                        var tooltipcontent = "Click to Select Predecessor(s)";
                        var radtooltip = null;
                        var controlid = toolTipID;
                        var predsString = parsePredecessorResult(result);
                        if (predsString != null && predsString.length > 0) {
                            tooltipcontent = tooltipcontent + "<br/><br/>Predecessors: " + predsString;
                        }
                        radtooltip = $find(controlid);
                        radtooltip.set_content(tooltipcontent);
                    }
                } catch (err) {

                }
            }
            function SetPredecessorLabelText(dataItem, result) {
                try {
                    var response = JSON.parse(result);
                    if (response != null) {
                        var predsString = parsePredecessorResult(result);
                        $(dataItem.get_element()).find('span[id*=LabelPredecessorsLabel]').text(predsString);
                        $find($(dataItem.get_element()).find('input[id*=RadTextBoxPredecessors]').prop('id')).set_value(predsString);
                    }
                } catch (err) {

                }
                makeNotationLabelsSameSize();
                alignColumns();
            }
            function parsePredecessorResult(result) {
                try {
                    var response = JSON.parse(result);
                    var predList = new Array();
                    var predString = '';
                    if (response != null) {
                        if (response.Predecessors != null && response.Predecessors.length > 0) {
                            for (var i = 0; i < response.Predecessors.length; i++) {
                                predList.push(response.Predecessors[i].Predecessor);
                            }
                            predString = predList.join(", ");
                        }
                    }
                } catch (err) {

                }
                return predString;
            }

            function setCustomPaging(sender, args) {
                var pageCount = $('#CustomGridPagingPageCount').val();
                var itemCount = $('#CustomGridPagingItemCount').val();
                $('.rgPagerCell  > .rgInfoPart').html("<strong>" + itemCount + "</strong> items in <strong>" + pageCount + "</strong> pages");
                $('.rgPagerCell  > .rgNumPart > a').each(function () {
                    var innerSpan = $(this).find('span');
                    if (innerSpan) {
                        var spanNum = innerSpan.html();
                        if (!isNaN(spanNum)) {
                            if (Number(spanNum) > pageCount) {
                                $(this).hide();
                            }
                        }
                    }
                });
            }

            getRadWindowName();
            
            function RadAjaxManagerOnResponseEnd(sender, args) {
                var elemID = $(args.get_eventTargetElement()).prop('id');
                if (elemID === "<%= RadGridProjectSchedule.ClientID %>") {
                    alignColumns();
                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
