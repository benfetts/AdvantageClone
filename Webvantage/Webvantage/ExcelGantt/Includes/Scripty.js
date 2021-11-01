
Gantt = new Object();

// *****************************************************************************
//     ____                            _   _
//    |  _ \ _ __ ___  _ __   ___ _ __| |_(_) ___  ___
//    | |_) | '__/ _ \| '_ \ / _ \ '__| __| |/ _ \/ __|
//    |  __/| | | (_) | |_) |  __/ |  | |_| |  __/\__ \
//    |_|   |_|  \___/| .__/ \___|_|   \__|_|\___||___/
//                    |_|
// *****************************************************************************

Gantt.Wrap = null;
Gantt.Table = "";
Gantt.Rows = 0;
Gantt.Cols = 0;
Gantt.MinDate = null;
Gantt.MaxDate = null;
Gantt.Weeks = null;
Gantt.Months = null;
Gantt.Inited = false;
Gantt.LastCell = null;
Gantt.LastEdit = null;
Gantt.TaskActionRow = null;
Gantt.Unique = -1;

Gantt.Error = function(text, err) {
    text += "\n\n";
    text += "Error description: " + err.description + "\n";
    text += "Click OK to continue.\n";
    alert(text);
}

// *****************************************************************************
//     ____                _             __  __      _   _               _     
//    |  _ \ ___ _ __   __| | ___ _ __  |  \/  | ___| |_| |__   ___   __| |___ 
//    | |_) / _ \ '_ \ / _` |/ _ \ '__| | |\/| |/ _ \ __| '_ \ / _ \ / _` / __|
//    |  _ <  __/ | | | (_| |  __/ |    | |  | |  __/ |_| | | | (_) | (_| \__ \
//    |_| \_\___|_| |_|\__,_|\___|_|    |_|  |_|\___|\__|_| |_|\___/ \__,_|___/
// *****************************************************************************

Gantt.Init = function(wrap) {

    Gantt.Wrap = wrap;
    Gantt.Rows = Gantt.Tasks.length - 1;

    Gantt.RenderTable();
}

Gantt.RenderTable = function() {
    try {
        Gantt.GetDates();
        Gantt.Table = '<Table border="0" cellpadding="0" cellspacing="0" Id="GanttTable">';
        Gantt.RenderHeader1();
        Gantt.RenderHeader2();
        Gantt.RenderHeader3();
        Gantt.RenderHeader4();
        for (var i = 0; i < Gantt.Tasks.length; i++) {
            Gantt.Tasks[i].Sequence = i;
            if (Gantt.Tasks[i].TaskType == "Task") Gantt.RenderTaskRow(i);
            else Gantt.RenderPhaseRow(i);
        }
        Gantt.Table += "</table>";
        Gantt.Wrap.innerHTML = Gantt.Table;

        Gantt.Inited = true;
        if (Gantt.LastCell) {
            $(Gantt.LastCell).focus();
            Gantt.LastCell = null;
        }
    } catch (err) { Gantt.Error("Render Table Error", err); }
}

Gantt.GetDates = function() {
    try {
        for (var i = 0; i < Gantt.Tasks.length; i++) {
            if (!Gantt.Inited) Gantt.Tasks[i].StartDate = new Date(parseInt(Gantt.Tasks[i].StartDate.replace("/Date(", "").replace(")/", "")));
            if (Gantt.Tasks[i].StartDate.getDay() == 6) Gantt.Tasks[i].StartDate = Gantt.Tasks[i].StartDate.addDays(2);
            if (Gantt.Tasks[i].StartDate.getDay() == 0) Gantt.Tasks[i].StartDate = Gantt.Tasks[i].StartDate.addDays(1);
            var d = Gantt.Tasks[i].Days - 1;
            Gantt.Tasks[i].FinishDate = Gantt.Tasks[i].StartDate;
            while (d > 0) {
                Gantt.Tasks[i].FinishDate = Gantt.Tasks[i].FinishDate.addDays(1);
                if (Gantt.Tasks[i].FinishDate.getDay() != 6 && Gantt.Tasks[i].FinishDate.getDay() != 0) d--;
            }
        }

        Gantt.MinDate = Gantt.Tasks[0].StartDate;
        for (var i = 1; i < Gantt.Tasks.length; i++) {
            if (Gantt.Tasks[i].StartDate.getYear() < 2000) continue;
            if (Gantt.Tasks[i].StartDate < Gantt.MinDate || Gantt.MinDate.getYear() < 2000) Gantt.MinDate = Gantt.Tasks[i].StartDate;
        }
        Gantt.MinDate = Gantt.MinDate.firstMondayOfTheMonth();

        Gantt.MaxDate = Gantt.Tasks[0].FinishDate;
        for (var i = 1; i < Gantt.Tasks.length; i++) {
            if (Gantt.Tasks[i].FinishDate > Gantt.MaxDate) Gantt.MaxDate = Gantt.Tasks[i].FinishDate;
        }
        Gantt.MaxDate = Gantt.MaxDate.lastMondayOfTheMonth();

        Gantt.Weeks = new Array();
        for (var dt = Gantt.MinDate; dt <= Gantt.MaxDate; dt = dt.addDays(7))
            Gantt.Weeks[Gantt.Weeks.length] = dt;

        Gantt.Months = new Array();
        for (var i = 0; i < Gantt.Weeks.length; i++) {
            if (Gantt.Months.length == 0) {
                Gantt.Months[0] = new Object();
                Gantt.Months[0].name = Gantt.Weeks[i].getMonthName();
                Gantt.Months[0].value = 1;
            } else if (Gantt.Months[Gantt.Months.length - 1].name == Gantt.Weeks[i].getMonthName()) {
                Gantt.Months[Gantt.Months.length - 1].value++
            } else {
                Gantt.Months[Gantt.Months.length] = new Object();
                Gantt.Months[Gantt.Months.length - 1].name = Gantt.Weeks[i].getMonthName();
                Gantt.Months[Gantt.Months.length - 1].value = 1;
            }
        }
        Gantt.Cols = 5 + Gantt.Weeks.length;
    } catch (err) { Gantt.Error("Get Dates Error", err); }
}

Gantt.RenderHeader1 = function() {
    try {
        var template = Gantt.Header1;
        template = template.replace(/::Campaign::/gi, Gantt.Campaign);
        template = template.replace(/::cols::/gi, Gantt.Cols);
        Gantt.Table += template;
    } catch (err) { Gantt.Error("Render Header 1 Error", err); } 
}

Gantt.RenderHeader2 = function() {
    try {
        var template = Gantt.Header2;
        template = template.replace(/::JobNumber::/gi, Gantt.JobNumber);
        template = template.replace(/::Description::/gi, Gantt.Description);
        template = template.replace(/::cols::/gi, Gantt.Cols);
        Gantt.Table += template;
    } catch (err) { Gantt.Error("Render Header 2 Error", err); } 
}

Gantt.RenderHeader3 = function() {
    try {
        var template = Gantt.Header3;
        template = template.replace(/::ClientName::/gi, Gantt.ClientName);
        template = template.replace(/::ProductName::/gi, Gantt.ProductName);
        var monthCells = "";

        for (var i = 0; i < Gantt.Months.length; i++) {
            monthCells += "<td colspan='::span::' class='GanttH3'>::month::</td>";
            monthCells = monthCells.replace(/::span::/gi, Gantt.Months[i].value);
            monthCells = monthCells.replace(/::month::/gi, Gantt.Months[i].name);
        }
        template = template.replace(/::MonthCells::/gi, monthCells);
        Gantt.Table += template;
    } catch (err) { Gantt.Error("Render Header 3 Error", err); }
}

Gantt.RenderHeader4 = function() {
    try {
        var template = Gantt.Header4;
        var weekCells = "";
        for (var i = 0; i < Gantt.Weeks.length; i++) {
            weekCells += "<td class='DateCell'>::monday::</td>";
            weekCells = weekCells.replace(/::monday::/gi, Gantt.Weeks[i].getDate());
        }
        template = template.replace(/::WeekCells::/gi, weekCells);
        Gantt.Table += template;
    } catch (err) { Gantt.Error("Render Header 4 Error", err); } 
}

Gantt.RenderPhaseRow = function(row) {
    try {
        var template = Gantt.PhaseRow;
        template = template.replace(/::id::/gi, Gantt.Tasks[row].Id);
        template = template.replace(/::row::/gi, row);
        template = template.replace(/::Name::/gi, Gantt.Tasks[row].LineName);
        template = template.replace(/::TaskType::/gi, Gantt.Tasks[row].TaskType);
        var weekCells = "";
        for (var i = 0; i < Gantt.Weeks.length; i++) {
            weekCells += "<td class='blankDate'>&nbsp;</td>";
        }
        template = template.replace(/::WeekCells::/gi, weekCells);
        Gantt.Table += template;
    } catch (err) { Gantt.Error("Render Phase Row Error", err); } 
}

Gantt.RenderTaskRow = function(row) {
    try {
        var template = Gantt.TaskRow;
        template = template.replace(/::id::/gi, Gantt.Tasks[row].Id);
        template = template.replace(/::row::/gi, row);
        template = template.replace(/::Name::/gi, Gantt.Tasks[row].LineName);
        template = template.replace(/::Days::/gi, Gantt.Tasks[row].Days);
        template = template.replace(/::Start::/gi, Gantt.Tasks[row].StartDate.toShortDate());
        template = template.replace(/::Finish::/gi, Gantt.Tasks[row].FinishDate.toShortDate());
        template = template.replace(/::Responsible::/gi, Gantt.Tasks[row].Responsible);
        template = template.replace(/::TaskType::/gi, Gantt.Tasks[row].TaskType);
        var weekCells = "";
        for (var i = 0; i < Gantt.Weeks.length; i++) {
            var ts = Gantt.Tasks[row].StartDate;
            var te = Gantt.Tasks[row].FinishDate;
            var ws = Gantt.Weeks[i];
            var we = Gantt.Weeks[i].addDays(6);
            var t = "blank";
            var n = "&nbsp;";
            if (ts >= ws && ts <= we) t = "active";
            if (te >= ws && te <= we) { t = "active"; n = te.getDate(); }
            if (ts < ws && te > we) t = "active";

            weekCells += "<td class='::Type::Date'>::Number::</td>";
            weekCells = weekCells.replace(/::Type::/gi, t);
            weekCells = weekCells.replace(/::Number::/gi, n);
        }
        template = template.replace("::WeekCells::", weekCells);
        Gantt.Table += template;
    } catch (err) { Gantt.Error("Render Task Row Error", err); } 
}

// ****************************************************************************************************
//     ___       _                      _   _               __  __      _   _               _     
//    |_ _|_ __ | |_ ___ _ __ __ _  ___| |_(_) ___  _ __   |  \/  | ___| |_| |__   ___   __| |___ 
//     | || '_ \| __/ _ \ '__/ _` |/ __| __| |/ _ \| '_ \  | |\/| |/ _ \ __| '_ \ / _ \ / _` / __|
//     | || | | | ||  __/ | | (_| | (__| |_| | (_) | | | | | |  | |  __/ |_| | | | (_) | (_| \__ \
//    |___|_| |_|\__\___|_|  \__,_|\___|\__|_|\___/|_| |_| |_|  |_|\___|\__|_| |_|\___/ \__,_|___/
// ****************************************************************************************************

Gantt.move = function() {
    try {
        var src = event.srcElement;
        var key = event.keyCode;
        var shift = event.shiftKey;
        var row = src.id.split("_")[2];
        var col = src.id.split("_")[3];
        if (event.shiftKey) return;
        switch (key) {
            case 37:
                var caretPos = document.selection.createRange();
                var leftPos = caretPos.duplicate();
                leftPos.moveStart("character", -1);
                if (leftPos.text.length - caretPos.text.length == 0) {
                    if (col == 1) {
                        if (row > 0) {
                            row--;
                            col = 5;
                            if ($("TaskType_" + row).value == "Phase") col = 1;
                        }
                    } else col--;
                    Gantt.lastCol = null;
                }
                break;
            case 39:
                var caretPos = document.selection.createRange();
                var rightPos = caretPos.duplicate();
                rightPos.moveEnd("character", 1);
                if (rightPos.text.length - caretPos.text.length == 0) {
                    if (col == 5 || $("TaskType_" + row).value == "Phase") {
                        if (row < Gantt.Rows) {
                            row++;
                            col = 1;
                        }
                    } else col++;
                    Gantt.lastCol = null;
                }
                break;
            case 38:
                if (row > 0) {
                    row--;
                    if ($("TaskType_" + row).value == "Phase") {
                        Gantt.lastCol = col;
                        col = 1;
                    } else if (Gantt.lastCol) {
                        col = Gantt.lastCol;
                        Gantt.lastCol = null;
                    }
                }
                break;
            case 40: case 13:
                if (row < Gantt.Rows) {
                    row++;
                    if ($("TaskType_" + row).value == "Phase") {
                        Gantt.lastCol = col;
                        col = 1;
                    } else if (Gantt.lastCol) {
                        col = Gantt.lastCol;
                        Gantt.lastCol = null;
                    }
                }
                break;
            default: return;
        }
        var cell = $("Cell_" + Gantt.Tasks[row].Id + "_" + row + "_" + col);
        Gantt.LastCell = cell.id;
        cell.focus();
    } catch (err) { Gantt.Error("Move Error", err); } 
}

Gantt.change = function(id) {
    try {
        if (id) {
            var src = id;
        } else {
            var src = event.srcElement.id;
        }
        Gantt.LastEdit = src;
        var src = $(Gantt.LastEdit);
        if (src == null) return;
        var row = src.id.split("_")[2];
        var col = src.id.split("_")[3];
        switch (col) {
            case "1":
                try {
                    if (Gantt.Tasks[row].LineName == src.value) return;
                    Gantt.Tasks[row].LineName == src.value;
                } catch (err) { Gantt.Error("Change Action Name Error", err); }
                break;
            case "2":
                try {
                    if (Gantt.Tasks[row].Days == src.value) return;
                    src.value = src.value.toNumber(Gantt.Tasks[row].Days);
                    if (Gantt.Tasks[row].Days == src.value) return;
                    Gantt.Tasks[row].Days = src.value;
                } catch (err) { Gantt.Error("Change Action Days Error", err); }
                Gantt.RenderTable();
                break;
            case "3":
                try {
                    if (Gantt.Tasks[row].StartDate.toShortDate() == src.value) return;
                    src.value = src.value.toDate(Gantt.Tasks[row].StartDate);
                    if (Gantt.Tasks[row].StartDate.toShortDate() == src.value) return;
                    Gantt.Tasks[row].StartDate = new Date(Date.parse(src.value));
                } catch (err) { Gantt.Error("Change Action Start Error", err); }
                Gantt.RenderTable();
                break;
            case "4":
                try {
                    if (Gantt.Tasks[row].FinishDate.toShortDate() == src.value) return;
                    src.value = src.value.toDate(Gantt.Tasks[row].FinishDate);
                    if (Gantt.Tasks[row].FinishDate.toShortDate() == src.value) return;
                    Gantt.Tasks[row].Days = Gantt.Tasks[row].StartDate.getWorkDays(new Date(Date.parse(src.value)));
                } catch (err) { Gantt.Error("Change Action Finish Error", err); }
                Gantt.RenderTable();
                break;
            case "5":
                try {
                    if (Gantt.Tasks[row].Responsible == src.value) return;
                    Gantt.Tasks[row].Responsible = src.value;
                } catch (err) { Gantt.Error("Change Action Responsible Error", err); }
                break;
        }
    } catch (err) { Gantt.Error("Change Action Error", err); }
}


// *****************************************************************************
//     _____                    _       _            
//    |_   _|__ _ __ ___  _ __ | | __ _| |_ ___  ___ 
//      | |/ _ \ '_ ` _ \| '_ \| |/ _` | __/ _ \/ __|
//      | |  __/ | | | | | |_) | | (_| | ||  __/\__ \
//      |_|\___|_| |_| |_| .__/|_|\__,_|\__\___||___/
//                       |_|
// *****************************************************************************

Gantt.Header1 = "<tr><td colspan='::cols::' class='GanttH1'>::Campaign::</td></tr>";
Gantt.Header2 = "<tr><td colspan='::cols::' class='GanttH2'>::JobNumber:: ::Description::</td></tr>";
Gantt.Header3 = "<tr><td colspan=5 class='GanttH3'>::ClientName:: - ::ProductName::</td>::MonthCells::</tr>";
Gantt.Header4 = "\
    <tr>\
        <td class='GanttH4'>&nbsp;</td>\
        <td class='GanttH4'>Days</td>\
        <td class='GanttH4'>Start</td>\
        <td class='GanttH4'>Finish</td>\
        <td class='GanttH4'>Responsible</td>\
        ::WeekCells::\
    </tr>";
Gantt.PhaseRow = "\
    <tr>\
        <td class='GanttPhaseRow'>\
            <input onblur='Gantt.change()' onkeydown='Gantt.move()' onfocus='this.select()' style='width:250px' class='PhaseInput' id='Cell_::id::_::row::_1' value='::Name::'  oncontextmenu='Gantt.showTaskMenu(this)' />\
        </td>\
        <td class='GanttPhaseRow' colspan=4>&nbsp;</td>\
        ::WeekCells::\
        <input type='hidden' id='TaskType_::row::' value= '::TaskType::' />\
    </tr>";
Gantt.TaskRow = "\
    <tr>\
        <td class='GanttTaskRow'><input onblur='Gantt.change()' onkeydown='Gantt.move()' onfocus='this.select()' style='width:250px' class='TaskInputName' id='Cell_::id::_::row::_1' value='::Name::' oncontextmenu='Gantt.showTaskMenu(this)' /></td>\
        <td class='GanttTaskRow'><input onblur='Gantt.change()' onkeydown='Gantt.move()' onfocus='this.select()' style='width:30px' class='TaskInput' id='Cell_::id::_::row::_2' value='::Days::' /></td>\
        <td class='GanttTaskRow'><input onblur='Gantt.change()' onkeydown='Gantt.move()' onfocus='this.select()' style='width:83px' class='TaskInputDate' id='Cell_::id::_::row::_3' value='::Start::' oncontextmenu='displayDatePicker(this)' /></td>\
        <td class='GanttTaskRow'><input onblur='Gantt.change()' onkeydown='Gantt.move()' onfocus='this.select()' style='width:83px' class='TaskInputDate' id='Cell_::id::_::row::_4' value='::Finish::' oncontextmenu='displayDatePicker(this)' /></td>\
        <td class='GanttTaskRow'><input onblur='Gantt.change()' onkeydown='Gantt.move()' onfocus='this.select()' style='width:150px' class='TaskInput' id='Cell_::id::_::row::_5' value='::Responsible::' /></td>\
        ::WeekCells::\
        <input type='hidden' id='TaskType_::row::' value= '::TaskType::' />\
    </tr>";


// *****************************************************************************
//     _____      _                 _                 
//    | ____|_  _| |_ ___ _ __  ___(_) ___  _ __  ___ 
//    |  _| \ \/ / __/ _ \ '_ \/ __| |/ _ \| '_ \/ __|
//    | |___ >  <| ||  __/ | | \__ \ | (_) | | | \__ \
//    |_____/_/\_\ __\___|_| |_|___/_|\___/|_| |_|___/
// *****************************************************************************


Date.prototype.daysInMonth = function() {
    var m = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    if (this.getMonth() != 1 && this.getYear() % 4 != 0) return m[this.getMonth()];
    return m[1] + 1;
}

Date.prototype.firstWorkDayOfTheWeek = function() {
    var temp = new Date(this.getFullYear(), this.getMonth(), this.getDate() - ((this.getDay() + 6) % 7));
    return temp;
}

Date.prototype.firstMondayOfTheMonth = function() {
    var temp = this.firstWorkDayOfTheWeek();
    temp = new Date(temp.getFullYear(), temp.getMonth(), temp.getDate() + (parseInt((temp.getDate() - 1) / 7) * -7));
    return temp;
}

Date.prototype.lastMondayOfTheMonth = function() {
    var temp = this.firstWorkDayOfTheWeek();
    temp = new Date(temp.getFullYear(), temp.getMonth(), parseInt((temp.daysInMonth() - temp.getDate()) / 7) * 7 + temp.getDate());
    return temp;

}

Date.prototype.addDays = function(days) {
    var temp = new Date(this.getYear(), this.getMonth(), this.getDate() + days);
    return temp;
}

Date.Months = "January,February,March,April,May,June,July,August,September,October,November,December".split(",");
Date.ShortMonths = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec".split(",");
Date.Days = "Sun,Mon,Tue,Wed,Thu,Fri,Sat".split(",");
Date.prototype.getMonthName = function() {
    return Date.Months[this.getMonth()];
}

Date.prototype.getShortMonthName = function() {
    return Date.ShortMonths[this.getMonth()];
}

Date.prototype.toShortDate = function() {
    var d = Date.Days[this.getDay()] + " " + this.getShortMonthName() + " " + this.getDate() + ", " + this.getFullYear();
    return d;
}

Date.prototype.getWorkDays = function(endDate) {
    var c = 0;
    for (var d = this; d <= endDate; d = d.addDays(1)) {
        if (d.getDay() != 0 && d.getDay() != 6) c++;
    }
    if (c < 1) c = 1;
    return c;
}

String.prototype.toNumber = function(num) {
    var t = this.replace(/[^0-9]/g, '');
    if (t == "") t = (num + "").replace(/[^0-9]/g, '');
    if (t == "") t = 1;
    return t;
}

String.prototype.toDate = function(date) {
    var t = this.replace(/-/g, "/");
    t = new Date(Date.parse(t));
    if (isNaN(t)) t = new Date(Date.parse(date));
    if (isNaN(t)) t = new Date();
    return t.toShortDate();
}

function $(id) {
    return document.getElementById(id);
}


// *****************************************************************************
//     ____        _         ____  _      _             
//    |  _ \  __ _| |_ ___  |  _ \(_) ___| | _____ _ __ 
//    | | | |/ _` | __/ _ \ | |_) | |/ __| |/ / _ \ '__|
//    | |_| | (_| | ||  __/ |  __/| | (__|   <  __/ |   
//    |____/ \__,_|\__\___| |_|   |_|\___|_|\_\___|_|   
// *****************************************************************************

var datePickerDivID = "datepicker";
var iFrameDivID = "datepickeriframe";

var dayArrayShort = new Array('Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa');
var dayArrayMed = new Array('Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat');
var dayArrayLong = new Array('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday');
var monthArrayShort = new Array('Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec');
var monthArrayMed = new Array('Jan', 'Feb', 'Mar', 'Apr', 'May', 'June', 'July', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec');
var monthArrayLong = new Array('January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December');


var defaultDateSeparator = "/";
var defaultDateFormat = "mdy"
var dateSeparator = defaultDateSeparator;
var dateFormat = defaultDateFormat;


function displayDatePicker(targetDateField, displayBelowThisObject, dtFormat, dtSep) {


    if (!displayBelowThisObject)
        displayBelowThisObject = targetDateField;

    if (dtSep)
        dateSeparator = dtSep;
    else
        dateSeparator = defaultDateSeparator;

    if (dtFormat)
        dateFormat = dtFormat;
    else
        dateFormat = defaultDateFormat;

    var x = displayBelowThisObject.offsetLeft;
    var y = displayBelowThisObject.offsetTop + displayBelowThisObject.offsetHeight;

    var parent = displayBelowThisObject;
    while (parent.offsetParent) {
        parent = parent.offsetParent;
        x += parent.offsetLeft;
        y += parent.offsetTop;
    }

    drawDatePicker(targetDateField, x, y);
    event.returnValue = false
    return false;
}

function drawDatePicker(targetDateField, x, y) {
    var dt = getFieldDate(targetDateField.value);

    if (!document.getElementById(datePickerDivID)) {
        var newNode = document.createElement("div");
        newNode.setAttribute("id", datePickerDivID);
        newNode.setAttribute("class", "dpDiv");
        newNode.setAttribute("style", "visibility: hidden;");
        document.body.appendChild(newNode);
    }

    var pickerDiv = document.getElementById(datePickerDivID);
    pickerDiv.style.position = "absolute";
    pickerDiv.style.left = x + "px";
    pickerDiv.style.top = y + "px";
    pickerDiv.style.visibility = (pickerDiv.style.visibility == "visible" ? "hidden" : "visible");
    pickerDiv.style.display = (pickerDiv.style.display == "block" ? "none" : "block");
    pickerDiv.style.zIndex = 10000;

    refreshDatePicker(targetDateField.id, dt.getFullYear(), dt.getMonth(), dt.getDate());
}

function refreshDatePicker(dateFieldName, year, month, day) {
    var thisDay = new Date();

    if ((month >= 0) && (year > 0)) {
        thisDay = new Date(year, month, 1);
    } else {
        day = thisDay.getDate();
        thisDay.setDate(1);
    }

    var crlf = "\r\n";
    var TABLE = "<table cols=7 class='dpTable'>" + crlf;
    var xTABLE = "</table>" + crlf;
    var TR = "<tr class='dpTR'>";
    var TR_title = "<tr class='dpTitleTR'>";
    var TR_days = "<tr class='dpDayTR'>";
    var TR_todaybutton = "<tr class='dpTodayButtonTR'>";
    var xTR = "</tr>" + crlf;
    var TD = "<td class='dpTD' onMouseOut='this.className=\"dpTD\";' onMouseOver=' this.className=\"dpTDHover\";' ";    // leave this tag open, because we'll be adding an onClick event
    var TD_title = "<td colspan=5 class='dpTitleTD'>";
    var TD_buttons = "<td class='dpButtonTD'>";
    var TD_todaybutton = "<td colspan=7 class='dpTodayButtonTD'>";
    var TD_days = "<td class='dpDayTD'>";
    var TD_selected = "<td class='dpDayHighlightTD' onMouseOut='this.className=\"dpDayHighlightTD\";' onMouseOver='this.className=\"dpTDHover\";' ";    // leave this tag open, because we'll be adding an onClick event
    var xTD = "</td>" + crlf;
    var DIV_title = "<div class='dpTitleText'>";
    var DIV_selected = "<div class='dpDayHighlight'>";
    var xDIV = "</div>";

    var html = TABLE;

    html += TR_title;
    html += TD_buttons + getButtonCode(dateFieldName, thisDay, -1, "&lt;") + xTD;
    html += TD_title + DIV_title + monthArrayLong[thisDay.getMonth()] + " " + thisDay.getFullYear() + xDIV + xTD;
    html += TD_buttons + getButtonCode(dateFieldName, thisDay, 1, "&gt;") + xTD;
    html += xTR;

    html += TR_days;
    for (i = 0; i < dayArrayShort.length; i++)
        html += TD_days + dayArrayShort[i] + xTD;
    html += xTR;

    html += TR;

    for (i = 0; i < thisDay.getDay(); i++)
        html += TD + "&nbsp;" + xTD;

    do {
        dayNum = thisDay.getDate();
        TD_onclick = " onclick=\"updateDateField('" + dateFieldName + "', '" + getDateString(thisDay) + "');\">";

        if (dayNum == day)
            html += TD_selected + TD_onclick + DIV_selected + dayNum + xDIV + xTD;
        else
            html += TD + TD_onclick + dayNum + xTD;

        if (thisDay.getDay() == 6)
            html += xTR + TR;

        thisDay.setDate(thisDay.getDate() + 1);
    } while (thisDay.getDate() > 1)

    if (thisDay.getDay() > 0) {
        for (i = 6; i > thisDay.getDay(); i--)
            html += TD + "&nbsp;" + xTD;
    }
    html += xTR;

    var today = new Date();
    var todayString = "Today is " + dayArrayMed[today.getDay()] + ", " + monthArrayMed[today.getMonth()] + " " + today.getDate();
    html += TR_todaybutton + TD_todaybutton;
    html += "<button class='dpTodayButton' onClick='refreshDatePicker(\"" + dateFieldName + "\");'>this month</button> ";
    html += "<button class='dpTodayButton' onClick='updateDateField(\"" + dateFieldName + "\");'>close</button>";
    html += xTD + xTR;

    html += xTABLE;

    document.getElementById(datePickerDivID).innerHTML = html;
    adjustiFrame();
}

function getButtonCode(dateFieldName, dateVal, adjust, label) {
    var newMonth = (dateVal.getMonth() + adjust) % 12;
    var newYear = dateVal.getFullYear() + parseInt((dateVal.getMonth() + adjust) / 12);
    if (newMonth < 0) {
        newMonth += 12;
        newYear += -1;
    }

    return "<button class='dpButton' onClick='refreshDatePicker(\"" + dateFieldName + "\", " + newYear + ", " + newMonth + ");'>" + label + "</button>";
}


function getDateString(dateVal) {
    var dayString = "00" + dateVal.getDate();
    var monthString = "00" + (dateVal.getMonth() + 1);
    dayString = dayString.substring(dayString.length - 2);
    monthString = monthString.substring(monthString.length - 2);

    switch (dateFormat) {
        case "dmy":
            return dayString + dateSeparator + monthString + dateSeparator + dateVal.getFullYear();
        case "ymd":
            return dateVal.getFullYear() + dateSeparator + monthString + dateSeparator + dayString;
        case "mdy":
        default:
            return monthString + dateSeparator + dayString + dateSeparator + dateVal.getFullYear();
    }
}


function getFieldDate(dateString) {
    var dateVal;
    try {
        dateString = dateString.replace(",", "").split(" ");
        var y = dateString[3];
        var m = dateString[1];
        var d = dateString[2];
        for (var i = 0; i < Date.ShortMonths.length; i++) {
            if (Date.ShortMonths[i] == m) { m = i; break; }
        }
        dateVal = new Date(y, m, d);
    } catch (e) {
        dateVal = new Date();
    }
    return dateVal;
}

function splitDateString(dateString) {
    var dArray;
    if (dateString.indexOf("/") >= 0)
        dArray = dateString.split("/");
    else if (dateString.indexOf(".") >= 0)
        dArray = dateString.split(".");
    else if (dateString.indexOf("-") >= 0)
        dArray = dateString.split("-");
    else if (dateString.indexOf("\\") >= 0)
        dArray = dateString.split("\\");
    else
        dArray = false;

    return dArray;
}

function updateDateField(dateFieldName, dateString) {

    var targetDateField = document.getElementById(dateFieldName);

    if (dateString)
        targetDateField.value = formatDate(dateString);



    var pickerDiv = document.getElementById(datePickerDivID);
    pickerDiv.style.visibility = "hidden";
    pickerDiv.style.display = "none";

    adjustiFrame();
    targetDateField.focus();

    if ((dateString) && (typeof (datePickerClosed) == "function"))
        datePickerClosed(targetDateField);

    Gantt.LastEdit = targetDateField.id;
    Gantt.change(targetDateField.id);
    //Gantt.changeAction();
}

function adjustiFrame(pickerDiv, iFrameDiv) {

    var is_opera = (navigator.userAgent.toLowerCase().indexOf("opera") != -1);
    if (is_opera)
        return;

    try {
        if (!document.getElementById(iFrameDivID)) {
            var newNode = document.createElement("iFrame");
            newNode.setAttribute("id", iFrameDivID);
            newNode.setAttribute("src", "javascript:false;");
            newNode.setAttribute("scrolling", "no");
            newNode.setAttribute("frameborder", "0");
            document.body.appendChild(newNode);
        }

        if (!pickerDiv)
            pickerDiv = document.getElementById(datePickerDivID);
        if (!iFrameDiv)
            iFrameDiv = document.getElementById(iFrameDivID);

        try {
            iFrameDiv.style.position = "absolute";
            iFrameDiv.style.width = pickerDiv.offsetWidth;
            iFrameDiv.style.height = pickerDiv.offsetHeight;
            iFrameDiv.style.top = pickerDiv.style.top;
            iFrameDiv.style.left = pickerDiv.style.left;
            iFrameDiv.style.zIndex = pickerDiv.style.zIndex - 1;
            iFrameDiv.style.visibility = pickerDiv.style.visibility;
            iFrameDiv.style.display = pickerDiv.style.display;
        } catch (e) {
        }

    } catch (ee) {
    }

}

function formatDate(dateString) {
    var d = dateString.split("/");
    var d = new Date(d[2], d[0] - 1, d[1]);
    return d.toShortDate();
}

// *****************************************************************************
//     _____         _         _        _   _                 
//    |_   _|_ _ ___| | __    / \   ___| |_(_) ___  _ __  ___ 
//      | |/ _` / __| |/ /   / _ \ / __| __| |/ _ \| '_ \/ __|
//      | | (_| \__ \   <   / ___ \ (__| |_| | (_) | | | \__ \
//      |_|\__,_|___/_|\_\ /_/   \_\___|\__|_|\___/|_| |_|___/
// *****************************************************************************


Gantt.showTaskMenu = function(src) {
    try {
        var x = src.offsetLeft;
        var y = src.offsetTop + src.offsetHeight;

        var parent = src;
        while (parent.offsetParent) {
            parent = parent.offsetParent;
            x += parent.offsetLeft;
            y += parent.offsetTop;
        }


        var menu = $("taskActionContext");
        menu.style.position = "absolute";
        menu.style.left = x + "px";
        menu.style.top = y + "px";
        menu.style.visibility = "visible";
        menu.style.display = "block";
        menu.style.zIndex = 10000;
        Gantt.TaskActionRow = src.id.split("_")[2];

        event.returnValue = false
        return false;
    } catch (err) { Gantt.Error("Show Menu Error", err); } 
}

Gantt.hideTaskMenu = function() {
    try {
        var menu = $("taskActionContext");
        menu.style.visibility = "hidden";
        menu.style.display = "none";
    } catch (err) { Gantt.Error("Hide Menu Error", err); } 
}

Gantt.taskAction = function(task) {
    try {
        Gantt.hideTaskMenu();
        var row = parseInt(Gantt.TaskActionRow);

        switch (task) {
            case "InsertAbove":
                var task = Gantt.CreateTask();
                Gantt.Tasks.splice(Gantt.TaskActionRow, 0, task);
                break;
            case "InsertBelow":
                var task = Gantt.CreateTask();
                Gantt.Tasks.splice(parseInt(Gantt.TaskActionRow) + 1, 0, task);
                break;
            case "Delete":
                if (!confirm("Are you sure you want to delete?")) return;
                Gantt.Tasks.splice(Gantt.TaskActionRow, 1);
                break;
            case "MoveDown":
                if (row == Gantt.Tasks.length - 1) return;
                var task = Gantt.Tasks[row];
                Gantt.Tasks[row] = Gantt.Tasks[row + 1];
                Gantt.Tasks[row + 1] = task;
                break;
            case "MoveUp":
                if (row == 0) return;
                var task = Gantt.Tasks[row];
                Gantt.Tasks[row] = Gantt.Tasks[row - 1];
                Gantt.Tasks[row - 1] = task;
                break;
            case "SetAsPhase":
                Gantt.Tasks[row].TaskType = "Phase";
                break;
            case "SetAsTask":
                Gantt.Tasks[row].TaskType = "Task";
                break;
            default:
                return;
        }
        Gantt.RenderTable();
    } catch (err) { Gantt.Error("Task Action Error", err); } 
}

Gantt.CreateTask = function() {
    try {
        var task = new Object();
        task.Id = (Gantt.Unique--);
        task.TaskType = "Task";
        task.LineName = "";
        task.Days = 1;
        task.StartDate = new Date();
        task.FinishDate = new Date();
        task.Responsible = "";
        task.Sequence = 0;

        return task;
    } catch (err) { Gantt.Error("Create Task Error", err); } 
}

Gantt.serialize = function() {
    try {
        var taskString = "[";
        for (var i = 0; i < Gantt.Tasks.length; i++) {
            if (i != 0) taskString += ",";
            taskString += "{";
            taskString += '"Id":' + Gantt.Tasks[i].Id + ',';
            taskString += '"TaskType":"' + Gantt.Tasks[i].TaskType + '",';
            taskString += '"Name":"' + Gantt.Tasks[i].LineName + '",';
            taskString += '"Days:"' + Gantt.Tasks[i].Days + ',';
            taskString += '"Start":"\\/Date(' + Gantt.Tasks[i].StartDate.valueOf() + ')\\/",';
            taskString += '"Finish":"\\/Date(' + Gantt.Tasks[i].FinishDate.valueOf() + ')\\/",';
            taskString += '"Responsible":"' + Gantt.Tasks[i].Responsible + '",';
            taskString += '"Sequence":' + Gantt.Tasks[i].Sequence;
            taskString += "}";
        }
        taskString += "]";
        return taskString;
    } catch (err) { Gantt.Error("Serialize Error", err); } 
}


function highlight() {
    var src = event.srcElement;
    if (src.tagName == "LI") {
        src.oldcss = src.className;
        src.className += " highlight";
    }
}

function lowlight() {
    var src = event.srcElement;
    if (src.tagName == "LI") {
        src.className = src.oldcss;
    }
}
