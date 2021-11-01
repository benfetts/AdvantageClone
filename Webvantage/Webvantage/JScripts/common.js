//#region Text/String Functions

//#endregion
function RadComboBoxDisableTyping_OnClientLoadHandler(sender) {
    sender.get_inputDomElement().readOnly = "readonly";
}
function PrintRequest(sender, args) {
    if (args.get_eventTarget().indexOf("ExportTo") >= 0) {
        args.set_enableAjax(false);
    }
}
function ParseLocale(s) {
    try {
        s = Number.parseLocale(s);
        if (isNaN(s) === false) {
            s = String.localeFormat("{0:n}", s);
        }
        return s;
    }
    catch (err) {
        return s;
    }
}
function SetCursorToTextEnd(textControlID) {
    var text = document.getElementById(textControlID);
    if (text !== null) {
        if (text.createTextRange) {
            //IE
            window.setTimeout(function () {
                var range = text.createTextRange();
                range.moveStart('character', text.value.length);
                range.collapse();
                range.select();
            }, 0);
        }
        else if (text.setSelectionRange) {
            //FF, web-kit
            window.setTimeout(function () {
                var textLength = text.value.length;
                text.focus();
                text.value = text.value;
                text.setSelectionRange(textLength, textLength);
            }, 0);
        }
    }
}

function showhideElement(id) {
    if (document.getElementById) {
        var obj = document.getElementById(id);
        if (obj.style.display == "none") {
            obj.style.display = "";
        }
        else {
            obj.style.display = "none";
        }
    }
}
String.prototype.trim = function () {
    return this.replace(/^\s+|\s+$/g, "");
};
String.prototype.ltrim = function () {
    return this.replace(/^\s+/, "");
};
String.prototype.rtrim = function () {
    return this.replace(/\s+$/, "");
};

//Add to both onkeydown and onkeyup events for the textfield
function limitText(limitField, limitNum) {
    if (limitField.value.length > limitNum) {
        limitField.value = limitField.value.substring(0, limitNum);
    }
}

function jsSetToday(tb) {
    var thisTextbox = document.getElementById(tb);
    if (thisTextbox.value === "") {
        var mydate = new Date();
        thisTextbox.value = String.localeFormat("{0:d}", mydate);
    }
}

function SetToday(tb) {
    var thisTextbox = document.getElementById(tb);
    if (thisTextbox.value === "") {
        var mydate = new Date();
        thisTextbox.value = String.localeFormat("{0:d}", mydate);
    }
    /*
    var thisTextbox = document.getElementById(tb);
    var mydate = new Date()
    var year = mydate.getYear()
    if (year < 1000) {
        year += 1900;
    }
    var day = mydate.getDay()
    var month = mydate.getMonth() + 1
    if (month < 10) {
        month = "0" + month;
    }
    var daym = mydate.getDate()
    if (daym < 10) {
        daym = "0" + daym;
    }
    if (thisTextbox.value == "") {
        thisTextbox.value = month + "/" + daym + "/" + year;
    }
    */
}

function ClearTB(tb) {
    try {
        var keyval = window.event.keyCode;
        if (keyval === 9) {
        }
        else {
            var thisTextbox = document.getElementById(tb);
            thisTextbox.value = '';
        }
    }
    catch (err) { }
}
function ClearDescription(codeTextbox, descriptionTextbox) {
    var c = document.getElementById(codeTextbox);
    var d = document.getElementById(descriptionTextbox);
    if (c.value.length === 0) {
        d.value = "";
    }
}
function Deselect(tb) {
    var thisTextbox = $("input[name='" + tb + "']");
    if (thisTextbox) {
        window.setTimeout(function () {
            thisTextbox.selectionEnd = thisTextbox.selectionStart;
        }, 100);
    };
}
function FocusTB(tb) {
    Deselect(tb);
    var thisTextbox = $("input[name='" + tb + "']");
    if (thisTextbox) {
        window.setTimeout(function () {
            thisTextbox.focus();
        }, 100);
    };
}

function ClearTextboxes() {
    ClearInputs(arguments);
}
function ClearInputs(inputArray) {
    try {
        if (inputArray) {
            for (i = 0; i < inputArray.length; i++) {
                document.getElementById(inputArray[i]).value = null;
            }
        }
    } catch (err) {

    }
}

//Open task edit window:
/*
--Array positions for key:
-- 0 = Internal row id
***Going to re-use position zero as a "from page" variable...
-- 1 = Is non task
-- 2 = non task type
-- 3 = is all day
-- 4 = task status, N = normal status
-- 5 = job number
-- 6 = job component number
-- 7 = sequence number
-- 8 = non-task id (this is also Event ID and the Event Task ID)
-- 9 = emp code
-- 10 = client code
-- 11 = division code
-- 12 = product code
*/
function openDetailWindow(sDataKey) {
    //alert(sDataKey);
    var ar = [];
    ar = sDataKey.split('|');
    var IsNonTask;
    var j;
    var c;
    var s;
    var n;
    var emp;
    var cli;
    var div;
    var prd;
    var fromform;
    var nonID;
    var newwindow;
    var left = 0;
    var top = 0;

    fromform = ar[0];
    IsNonTask = ar[1];
    j = ar[5];
    c = ar[6];
    s = ar[7];
    nonID = ar[8];
    emp = ar[9];
    cli = ar[10];
    div = ar[11];
    prd = ar[12];

    if (IsNonTask === 0) {
        //alert('A real task');
        left = parseInt((screen.availWidth / 2) - (860 / 2));
        top = parseInt((screen.availHeight / 2) - (880 / 2));
        newwindow = window.open('TrafficSchedule_TaskDetail.aspx?pop=1&form=' + fromform + '&JobNum=' + j + '&JobComp=' + c + '&SeqNum=' + s + '&EmpCode=' + emp + '&Client=' + cli + '&Division=' + div + '&Product=' + prd, 'CalendarTask', 'screenX=50,left=' + left + ',screenY=50,top=' + top + ',width=860,height=772,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');
        if (window.focus) { newwindow.focus(); }
        return false;
    }
    if (IsNonTask === 1) {
        //alert('A non task'+nonID);
        left = parseInt((screen.availWidth / 2) - (745 / 2));
        top = parseInt((screen.availHeight / 2) - (325 / 2));
        newwindow = window.open('Calendar_NewItem.aspx?TaskNo=' + nonID, 'CalendarNonTask', 'screenX=150,left=' + left + ',screenY=150,top=' + top + ',width=745,height=500,scrollbars=auto,resizable=yes,menubar=no,maximazable=no');
        if (window.focus) { newwindow.focus(); }
        return false;
    }
    if (IsNonTask == 2) {
        //alert('An event '+nonID);
        left = parseInt((screen.availWidth / 2) - (1024 / 2));
        top = parseInt((screen.availHeight / 2) - (850 / 2));
        newwindow = window.open('Event_Detail.aspx?et=0&j=' + j + '&jc=' + c + '&evt=' + nonID + '&cli=' + cli + '&from=1', 'CalendarEvent', 'screenX=150,left=' + left + ',screenY=150,top=' + top + ',width=745,height=325,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');
        if (window.focus) { newwindow.focus(); }
        return false;
    }
    if (IsNonTask == 3) {
        //alert('An event task '+nonID);
        left = parseInt((screen.availWidth / 2) - (1024 / 2));
        top = parseInt((screen.availHeight / 2) - (850 / 2));
        //newwindow = window.open('Event_Detail.aspx?et=1&j=' + j + '&jc=' + c + '&evt=' + s + '&cli=' + cli + '&from=1', 'CalendarEvent', 'screenX=150,left=' + left + ',screenY=150,top=' + top + ',width=745,height=325,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');
        newwindow = window.open('Event_Task_Detail.aspx?etid=' + nonID + '&f=c', 'CalendarEventTask', 'screenX=150,left=' + left + ',screenY=150,top=' + top + ',width=620,height=670,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');
        if (window.focus) { newwindow.focus(); }
        return false;
    }
}
//Open while maintaining focuse and centering the window
function open_JSWindow(sWinName, sURL, iHeight, iWidth, scrollYesNo, resizeYesNo, maximizeYesNo, fullSizeYesNo) {
    if (!sWinName) {
        sWinName = 'JSPopup';
    }
    if (!fullSizeYesNo) {
        fullSizeYesNo = 'no';
    }
    var left;
    var top;
    var newwindow;
    left = parseInt((screen.availWidth / 2) - (iWidth / 2));
    top = parseInt((screen.availHeight / 2) - (iHeight / 2));
    if (fullSizeYesNo == 'yes') {
        left = 0;
        top = 0;
        iWidth = screen.availWidth;
        iHeight = screen.availHeight;
    }
    newwindow = window.open(sURL, sWinName, 'screenX=' + left + ',left=' + left + ',screenY=' + top + ',top=' + top + ',width=' + iWidth + ',height=' +
                iHeight + ',scrollbars=' + scrollYesNo + ',resizable=' + resizeYesNo + ',maximazable=' + maximizeYesNo + ',menubar=no');
    if (window.focus) {
        newwindow.focus();
    }
    return false;
}

//function RadAsyncUploadFileAdded(sender, args) {
//if (Telerik.Web.UI.RadAsyncUpload.Modules.FileApi.isAvailable()) {
//    $(".ruDropZone").html("<span>Drop file(s) here</span>");
//}
//}

//function RadAsyncUploadFileAddedSingleOnly(sender, args) {
//if (Telerik.Web.UI.RadAsyncUpload.Modules.FileApi.isAvailable()) {
//    $(".ruDropZone").html("<span>Drop a single file here</span>");
//}
//}

function UnityOnClientShowing(menu, args) {
    var target = args.get_targetElement();
    if (target) {
        var elementType = "";
        elementType = target.nodeName.toLowerCase();
        if (elementType == "input" || elementType == "textarea") {
            args.set_cancel(true);
        }
        try {
            if (target.id.indexOf("RadEditor") > -1) {
                args.set_cancel(true);
            }
        } catch (e) { }
    }
}
function RadEditorOnClientLoad(editor, args) {
    var buttonsHolder = $get(editor.get_id() + "Top");
    var buttons = buttonsHolder.getElementsByTagName("A");
    for (var i = 0; i < buttons.length; i++) {
        var a = buttons[i];
        a.tabIndex = -1;
        a.tabStop = false;
    }
}

function RadEditorOnClientLoadSOFLarge(editor, args) {
    var buttonsHolder = $get(editor.get_id() + "Top");
    var buttons = buttonsHolder.getElementsByTagName("A");
    for (var i = 0; i < buttons.length; i++) {
        var a = buttons[i];
        a.tabIndex = -1;
        a.tabStop = false;
    }

    var $ = $telerik.$;
    var editorElm = editor.get_element();
    var relativeParentPos = $(editorElm).offsetParent().position();

    editor.get_toolAdapter().get_window().add_show(function (sender, args) {
        var popupElementHeight = $(sender.get_popupElement()).height();
        sender.moveTo(674, 177);
    })

    //var element = document.all ? editor.get_document().body : editor.get_document();
    //$telerik.addExternalHandler(element, "click", function (e) {
    //    setTimeout(function () {
    //        var oWnd = editor.get_toolAdapter().get_window(); //get reference to RadWindow based ShowOnFocus toolbar 
    //        oWnd.moveTo(674, 177);
    //    }, 0);
    //});
}

function RadEditorOnClientCommandExecuted(editor, args) {
        var command = args.get_commandName();
        if (command === "InsertLink") {
            var dialog = editor.get_dialogOpener()._dialogContainers[command];
            dialog.set_title("");
        }
    }

function RadEditorOnClientLoadSOFpopup(editor, args) {
    var buttonsHolder = $get(editor.get_id() + "Top");
    var buttons = buttonsHolder.getElementsByTagName("A");
    for (var i = 0; i < buttons.length; i++) {
        var a = buttons[i];
        a.tabIndex = -1;
        a.tabStop = false;
    }

    var $ = $telerik.$;
    var editorElm = editor.get_element();
    var relativeParentPos = $(editorElm).offsetParent().position();

    editor.get_toolAdapter().get_window().add_show(function (sender, args) {
        var popupElementHeight = $(sender.get_popupElement()).height();
        sender.moveTo(7, 61);
    })
}

function Multiply(text1, text2, textResult) //LoGlo OK
{
    //alert('Multiply');
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var z = 0.000;
    x = Number.parseLocale(x);
    y = Number.parseLocale(y);

    if (isNaN(x) === false && isNaN(y) === false) {
        z = (x * 1.000) * (y * 1.000);

        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function MultiplyPerc(text1, text2, textResult) //LoGlo OK
{
    //alert('MultiplyPerc');
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    var z = 0;
    if (isNaN(x) === false && isNaN(y) === false) {
        //if (y > 100)
        //{
        //    y = 100;
        //    document.getElementById(text2).value = y;
        //}
        //if (y < 0)
        //{
        //    y = 0;
        //    document.getElementById(text2).value = y;
        //}
        z = (x * 1.000) * ((y * 1.000) / 100.000);

        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function CalculatePercInt(text1, text2, textResult) //the integer percentage goes into textResult     //LoGlo OK
{
    //alert('CalculatePercInt');
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;

    x = Number.parseLocale(x);
    y = Number.parseLocale(y);

    var z = 0.00;
    if (isNaN(x) === false && isNaN(y) === false) {
        if (y > 0) //avoid divide by zero 
        {
            z = ((x * 1.000) / (y * 1.000) * 100.000);
            //z = z.toFixed(3)
            document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
        }
        else {
            document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
        }
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function CalcRate(text1, text2, text3) //t1 = qty,t2 = rate,t3 = amt   //LoGlo OK
{
    //alert('CalcRate');
    var x = document.getElementById(text1).value;
    var r = document.getElementById(text2).value;
    var y = document.getElementById(text3).value;
    x = Number.parseLocale(x);
    r = Number.parseLocale(r);
    y = Number.parseLocale(y);

    var z = 0.000;
    if (r === 0)//only recalc the rate if rate doesn't exist
    {
        if (isNaN(x) === false && isNaN(y) === false && ((x * 1.000) > 0.000)) {
            z = (y * 1.000) / (x * 1.000);

            document.getElementById(text2).value = String.localeFormat("{0:n}", z);
        }
        else {
            //document.getElementById(text2).value = '0.00';
        }
    }
}
function CalcRateOverride(text1, text2, text3) //t1 = qty,t2 = rate,t3 = amt     //LoGlo OK
{
    //alert('CalcRateOverride');
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text3).value;
    var r = document.getElementById(text2).value;
    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    r = Number.parseLocale(r);

    var z = 0.000;
    if (isNaN(x) === false && isNaN(y) === false && ((x * 1.000) > 0.000)) {
        z = (y * 1.000) / (x * 1.000);

        document.getElementById(text2).value = String.localeFormat("{0:n}", z);
    }
    else {
        //document.getElementById(text2).value = '0.00';
    }
}
function AddTotalExtMU(text1, text2, textResult) {
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var z = 0;

    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    if (isNaN(x) == false && isNaN(y) == false) {
        z = (x * 1.000) + (y * 1.000);

        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function CopyNumericValue(text1, text2) {
    //alert('CopyNumericValue');

    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    x = Number.parseLocale(x);
    y = Number.parseLocale(y);

    var z = 0.000;
    if (isNaN(x) === false) {
        z = x * 1.000;
        document.getElementById(text2).value = String.localeFormat("{0:n}", z);
    }
    else {
        //document.getElementById(text2).value = '0.00';
    }
}

function showhideElement(id) {
    if (document.getElementById) {
        obj = document.getElementById(id);
        if (obj.style.display == "none") {
            obj.style.display = "";
        }
        else {
            obj.style.display = "none";
        }
    }
}


//Add to both onkeydown and onkeyup events for the textfield
function limitText(limitField, limitNum) {
    if (limitField.value.length > limitNum) {
        limitField.value = limitField.value.substring(0, limitNum);
    }
}
function IsNumeric(sText) {
    //try {
    //   var ValidChars = "0123456789.-,";
    //   var IsNumber=true;
    //   var Char;
    //   for (i = 0; i < sText.length && IsNumber == true; i++) 
    //      { 
    //      Char = sText.charAt(i); 
    //      if (ValidChars.indexOf(Char) == -1) 
    //         {
    //             IsNumber = false;
    //         }
    //      }
    //   return IsNumber;
    //   }catch(err){}
    return true;
}
function copyToClipboard(textToCopy) {
    $("body")
        .append($('<input type="text" name="fname" class="textToCopyInput"/>')
        .val(textToCopy))
        .find(".textToCopyInput")
        .select();
    try {
        var successful = document.execCommand('copy');
        if (successful == false) {
            try {
                window.prompt("To copy the text to clipboard: Ctrl+C, Enter", textToCopy);
            } catch (ex) {
                console.log(ex);
            }
        }
    } catch (err) {
        window.prompt("To copy the text to clipboard: Ctrl+C, Enter", textToCopy);
    }
    $(".textToCopyInput").remove();
}
function gqsv(key) {
    //hideMessage();
    return decodeURIComponent(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
}
function enableDarkMode() {
    window.setTimeout(function () {
        _enableDarkMode();
    }, 250);
}
function _enableDarkMode() {
    DarkReader.setFetchMethod(window.fetch);
    DarkReader.enable({
        brightness: 100,
        contrast: 90,
        sepia: 10
    });
}
function disableDarkMode() {

}
