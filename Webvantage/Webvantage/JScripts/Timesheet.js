var MissingCommentMessage = 'Please enter all missing comments before continuing. <span style=\"text-decoration:underline\">No changes will be saved until missing comments are entered.</span>'

function OpenCommentWindow(EmpCode, DataKeyHiddenField, CanEdit, IconDivName) {
    window.setTimeout(function () {
        _OpenCommentWindow(EmpCode, DataKeyHiddenField, CanEdit, IconDivName);
    }, 250);
}
function _OpenCommentWindow(EmpCode, DataKeyHiddenField, CanEdit, IconDivName) {

    var CellDataKey = '';
    CellDataKey = DataKeyHiddenField.value;
    //alert(CellDataKey);

    var DataKey = new Array();
    DataKey = CellDataKey.split('|');

    var EtId = 0;
    var EtDtlId = 0;
    var TimeType = '';
    var TheDate = '';
    var Prefix = '';
    var Hours = '';
    var DayControlName = '';

    Prefix = DataKey[0];

    if (Prefix.indexOf('Sun') > -1) {
        DayControlName = 'TxtSunday';
    } else if (Prefix.indexOf('Mon') > -1) {
        DayControlName = 'TxtMonday';
    } else if (Prefix.indexOf('Tue') > -1) {
        DayControlName = 'TxtTuesday';
    } else if (Prefix.indexOf('Wed') > -1) {
        DayControlName = 'TxtWednesday';
    } else if (Prefix.indexOf('Thu') > -1) {
        DayControlName = 'TxtThursday';
    } else if (Prefix.indexOf('Fri') > -1) {
        DayControlName = 'TxtFriday';
    } else if (Prefix.indexOf('Sat') > -1) {
        DayControlName = 'TxtSaturday';
    }

    if (DayControlName != '') {
        Prefix = Prefix.substring(0, Prefix.length - 3);
        Hours = document.getElementById(Prefix + DayControlName).value;
    } else {
        Hours = 0;
    }

    //alert(Hours);

    if (isNaN(Hours) == true) {
        Hours = 0;
    } else {
        Hours = Hours * 1;
    }

    //alert(Hours);

    if (isNaN(DataKey[7]) == false) {
        EtId = DataKey[7] * 1;
    }
    if (isNaN(DataKey[8]) == false) {
        EtDtlId = DataKey[8] * 1;
    }

    TimeType = DataKey[10];
    TheDate = DataKey[9];

    //alert(EtId);
    //alert(EtDtlId);
    //alert(Hours);

    //alert(DataKey)

    var url = '';
    if (EtId > 0 && EtDtlId > 0) {
        url = 'popcomments.aspx?empcode=' + EmpCode + '&caller=Timesheet&type=hours&id=' + TimeType + '|' + EtId + '|' + EtDtlId + '&date=' + TheDate + '&CanEdit=' + CanEdit + '&IconDivName=' + IconDivName;
        OpenRadWindow('', url, 0, 0, false);
    }
    else {
        //alert('Please enter time before entering a comment');
        DataChangeSaveTime(DataKeyHiddenField, Prefix + DayControlName, '0.0', true);
    }
    return false;
}

function UpdateDatakey(DataKeyHiddenField, EtId, EtDtlId, TimeType) {
    var CellDataKey = '';
    CellDataKey = DataKeyHiddenField.value;

    //alert('Original: ' + CellDataKey);

    var DataKey = new Array();
    DataKey = CellDataKey.split('|');
    DataKey[7] = EtId;
    DataKey[8] = EtDtlId;

    if (TimeType.length > 0) {

        DataKey[10] = TimeType;

    }
    

    var NewDataKey = '';

    for (var i = 0; i < DataKey.length; i++) {
        NewDataKey = NewDataKey + DataKey[i] + '|';
    }
    if (NewDataKey.length > 2) {
        NewDataKey = NewDataKey.slice(0, NewDataKey.length - 1);
    }
    else {
        NewDataKey = CellDataKey;
    }

    DataKeyHiddenField.value = NewDataKey;
    //alert('New: ' + NewDataKey);

}
function UpdateDatakeyHasComment(DataKeyHiddenField, HasComment) {
    var CellDataKey = '';
    CellDataKey = DataKeyHiddenField.value;

    //alert('Original: ' + CellDataKey);

    var DataKey = new Array();
    DataKey = CellDataKey.split('|');
    DataKey[14] = HasComment;

    var NewDataKey = '';

    for (var i = 0; i < DataKey.length; i++) {
        NewDataKey = NewDataKey + DataKey[i] + '|';
    }
    if (NewDataKey.length > 2) {
        NewDataKey = NewDataKey.slice(0, NewDataKey.length - 1);
    }
    else {
        NewDataKey = CellDataKey;
    }

    DataKeyHiddenField.value = NewDataKey;
    //alert('New: ' + NewDataKey);

}
/*
                window.setTimeout(function () {
                }, 50);

*/
function DataChangeSaveTime(DataKeyHiddenField, ControlName, ControlValue, IsFromCommentIconPopUp) {
    window.setTimeout(function () {
        try {
            if (DataKeyHiddenField && ControlName) {
                if (!ControlValue) {
                    ControlValue = 0.00;
                    document.getElementById(ControlName).value = String.localeFormat("{0:n}", ControlValue);
                } else {
                    ControlValue = ControlValue.trim();
                    if (ControlValue == "") {
                        ControlValue = 0.00;
                        document.getElementById(ControlName).value = String.localeFormat("{0:n}", ControlValue);
                    }
                }
                if (isNaN(parseFloat(ControlValue))) {
                    //alert("Invalid hours");
                    //document.getElementById(ControlName).focus();
                } else {
                    ControlValue = ParseLocale(ControlValue);
                    if (IsFromCommentIconPopUp && IsFromCommentIconPopUp == true) {
                        PageMethods.SaveTime(DataKeyHiddenField.value, ControlName, ControlValue, true, SaveTimeSucceededFromCommentIconPopUp, SaveTimeFailedFromCommentIconPopUp);
                    } else {
                        PageMethods.SaveTime(DataKeyHiddenField.value, ControlName, ControlValue, false, SaveTimeSucceeded, SaveTimeFailed);
                    }
                    //document.getElementById(ControlName).value = ParseLocale(ControlValue).toFixed(2);
                }
                return false;
            }
            return false; 
        }
        catch (err) { }
    }, 50);
}
function DataChangeSaveComment(DataKeyHiddenField, ControlName, ControlValue) {
    try {
        PageMethods.SaveComment(DataKeyHiddenField.value, ControlName, ControlValue, SaveTimeSucceeded, SaveTimeFailed);
        return false;
    }
    catch (err) { }
}
function SaveTimeSucceeded(result, userContext, methodName) {
    window.setTimeout(function () {
        _SaveTimeSucceeded(result, userContext, methodName);
    }, 50);
};
function _SaveTimeSucceeded(result, userContext, methodName) {
    try {
        if (result && result != '') {
            //alert("success msg: " + result);
            var str = "";
            str = result
            str = str.replace("##", '\n');
            str = str.replace("##", '\n');
            if (str.indexOf("[object") > -1) {
                return false;
            }
            //final datakey positions:
            //0 = success/fail message
            //1 = etid
            //2 = etdtlid
            //3 = db hours formatted
            //4 = billing rate
            //5 = no bill flag
            //6 = error code
            //7 = error text
            // ADDED IN CODEBEHIND
            //8 = Globalized formattetd hours
            //9 = Client control prefix
            //10 = control id
            //11 = comments requred
            // 12 = show comments using (textbox, icon, none)
            var DataKey = new Array();
            var CommentRequired = false;
            var HoursEntered = 0.0;
            var EtId = 0;
            var EtDtlId = 0;
            var TimeType = '';
            var errorCode = 0;
            var returnMessage = "";
            console.log("SAVE RETURN", str);
            var keyOffSet = 0;
            //alert(str);
            if (str.indexOf("INSERT_SUCCESS") > -1 || str.indexOf("INSERT_NP_SUCCESS") > -1) {
                DataKey = str.split('|');
                EtId = DataKey[1];
                EtDtlId = DataKey[2];
                //format hours for display
                if (DataKey[9].indexOf("_Txt") === -1) {
                    keyOffSet = 1;
                }

                if (document.getElementById(DataKey[9 + keyOffSet])) {
                    document.getElementById(DataKey[9 + keyOffSet]).value = DataKey[7 + keyOffSet];
                }
                if (DataKey[6] && isNaN(DataKey[6]) === false) {
                    errorCode = DataKey[6];
                }
                if (DataKey[7] && (errorCode === -15 || errorCode === -16 || errorCode === -17)) {
                    returnMessage = DataKey[7];
                }
                if (returnMessage && returnMessage !== "") {
                    alert(returnMessage);
                }
                if (str.indexOf("INSERT_SUCCESS") > -1) {
                    TimeType = 'D';
                }
                if (str.indexOf("INSERT_NP_SUCCESS") > -1) {
                    TimeType = 'N';
                }
                UpdateDatakey(document.getElementById(DataKey[8] + 'Datakey'), EtId, EtDtlId, TimeType);
                //set comment requirement bg color on insert
                HoursEntered = DataKey[3] * 1.00;
                if (DataKey[DataKey.length - 2] && DataKey[DataKey.length - 2] === 'true') {
                    CommentRequired = true;
                }
                try {
                    if (CommentRequired === true && HoursEntered > 0) {
                        document.getElementById(DataKey[9] + 'TextBoxComment').style.backgroundColor = '#F8C732';
                    }
                } catch (e) {
                }
                RefreshTimesheetDTO();
                ////if (DataKey[6] && isNaN(DataKey[6]) === false) {
                ////    errorCode = DataKey[6];
                ////}
                //////alert(errorCode)
                ////if (DataKey[7] && (errorCode == -15 || errorCode == -16 || errorCode == -17)) {
                ////    returnMessage = DataKey[7];
                ////}
                ////if (returnMessage && returnMessage != "") {
                ////    alert(returnMessage);
                ////}
                //alert(errorCode);
                return false;
            }
            if (str.indexOf("UPDATE_SUCCESS") > -1 || str.indexOf("UPDATE_NP_SUCCESS") > -1) {
                DataKey = str.split('|');
                HoursEntered = DataKey[3] * 1.00;
                //format hours for display
                if (DataKey[9].indexOf("_Txt") === -1) {
                    keyOffSet = 1;
                }
                console.log(keyOffSet, DataKey[9 + keyOffSet], DataKey[7 + keyOffSet])
                if (document.getElementById(DataKey[9 + keyOffSet])) {
                    document.getElementById(DataKey[9 + keyOffSet]).value = DataKey[7 + keyOffSet];
                }
                if (DataKey[6] && isNaN(DataKey[6]) === false) {
                    errorCode = DataKey[6];
                }
                if (DataKey[7] && (errorCode === -15 || errorCode === -16 || errorCode === -17)) {
                    returnMessage = DataKey[7];
                }
                if (returnMessage && returnMessage !== "") {
                    alert(returnMessage);
                }
                if (DataKey[DataKey.length - 2] && DataKey[DataKey.length - 2] === 'true') {
                    CommentRequired = true;
                }
                //clear comments if set to zero
                if (CommentRequired === true && HoursEntered === 0) {
                    if (document.getElementById(DataKey[8] + 'TextBoxComment')) {
                        document.getElementById(DataKey[8] + 'TextBoxComment').style.backgroundColor = 'LightYellow';
                    }
                }
                RefreshTimesheetDTO();
                return false;
            }
            if (str.indexOf("UPDATE_CMT_SUCCESS") > -1 || str.indexOf("INSERT_CMT_SUCCESS") > -1) {
                DataKey = str.split('|');
                EtId = DataKey[3];
                EtDtlId = DataKey[4];
                if (str.indexOf("INSERT_CMT_SUCCESS") > -1) {
                    UpdateDatakey(document.getElementById(DataKey[1] + 'Datakey'), EtId, EtDtlId, '');
                }
                var HasComment = false;
                if (DataKey[6] === 'true') {
                    CommentRequired = true;
                }
                ////if (DataKey[5] == 'true') {
                ////    HasComment = true;
                ////}
                //////alert(DataKey[5]);
                //////document.getElementById(DataKey[1] + 'HiddenFieldHasComment').value = DataKey[5];
                ////UpdateDatakeyHasComment(document.getElementById(DataKey[1] + 'Datakey'), HasComment);
                ////if (CommentRequired == true && HasComment == true) {
                ////    document.getElementById(DataKey[1] + 'TextBoxComment').style.backgroundColor = 'LightYellow';
                ////}
                return false;
            }
            if (str.indexOf("UPDATE_FAIL") > -1) {
                //console.log(str);
                DataKey = str.split('|');
                var thisCtrl = document.getElementById(DataKey[10]);
                if (thisCtrl) {
                    thisCtrl.value = DataKey[8];
                }
                HoursEntered = DataKey[3] * 1.00;
                if (DataKey[6] && isNaN(DataKey[6]) === false) {
                    errorCode = DataKey[6];
                }
                if (DataKey[7] && (errorCode === -15 || errorCode === -16 || errorCode === -17)) {
                    returnMessage = DataKey[7];
                }
                if (returnMessage && returnMessage !== "") {
                    alert(returnMessage);
                }
                if (DataKey[11] === 'true') {
                    CommentRequired = true;
                }
                //clear comments if set to zero
                if (CommentRequired === true && HoursEntered === 0) {
                    document.getElementById(DataKey[9] + 'TextBoxComment').style.backgroundColor = 'LightYellow';
                }
                RefreshTimesheetDTO();
                return false;
            }
            if (str.indexOf("ERROR|") > -1) {
                DataKey = str.split('|');
                alert(DataKey[1]);
                document.getElementById(DataKey[2]).value = '';
                document.getElementById(DataKey[2]).focus();
                return false;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
        return false;
    }
    catch (err) { }
};
function SaveTimeFailed(error, userContext, methodName) {
    try {
        alert(error);
        var str = '';
        str = error;
        if (str.indexOf("[object") > -1) {
        }
        else {
            alert(str);
        }
    }
    catch (err) { }
};

function SaveTimeSucceededFromCommentIconPopUp(result, userContext, methodName) {
    window.setTimeout(function () {
        _SaveTimeSucceeded(result, userContext, methodName);
        if (result && result != '') {
            var str = "";
            str = result
            str = str.replace("##", '\n');
            str = str.replace("##", '\n');
            if (str.indexOf("[object") > -1) {
                return false;
            }

            var DataKey = new Array();
            var CommentRequired = false;
            var HoursEntered = 0.0;
            var EtId = 0;
            var EtDtlId = 0;
            var TimeType = '';
            var errorCode = 0;
            var returnMessage = "";
            var TheDate = '';
            var CanEdit = '';
            if (str.indexOf("INSERT_SUCCESS") > -1 || str.indexOf("INSERT_NP_SUCCESS") > -1) {
                DataKey = str.split('|');
                EtId = DataKey[1];
                EtDtlId = DataKey[2];
                if (str.indexOf("INSERT_SUCCESS") > -1) {
                    TimeType = 'D';
                }
                if (str.indexOf("INSERT_NP_SUCCESS") > -1) {
                    TimeType = 'N';
                }
                var url = '';
                url = 'popcomments.aspx?empcode=' + EmpCode + '&caller=Timesheet&type=hours&id=' + TimeType + '|' + EtId + '|' + EtDtlId + '&date=' + TheDate + '&CanEdit=' + CanEdit + '&IconDivName=' + IconDivName;
                OpenRadWindow('', url, 0, 0, false);

            }
        }
    }, 50);
};
function SaveTimeFailedFromCommentIconPopUp(error, userContext, methodName) {
    SaveTimeFailed(error, userContext, methodName);
};


function setFooterTotals(employeeCode, startDate, endDate) {
    window.setTimeout(function () {
        PageMethods.GetFooterTotals(employeeCode, startDate, endDate, setFooterTotalsSuccess, setFooterTotalsFail);
    }, 750); 
}
function setFooterTotalsSuccess(result, userContext, methodName) {
    if (result) {
        var hours = new Array();
        hours = result.split("|");
        if (hours && hours.length === 9) {

            //alert(hours[8]); // 0 = sun, 1 = mon, 6 = sat
            switch (hours[8] * 1) {
                case 1:
                    $("#SaturdayFooterTotal").html(ParseLocale(hours[0]));
                    $("#SundayFooterTotal").html(ParseLocale(hours[1]));
                    $("#MondayFooterTotal").html(ParseLocale(hours[2]));
                    $("#TuesdayFooterTotal").html(ParseLocale(hours[3]));
                    $("#WednesdayFooterTotal").html(ParseLocale(hours[4]));
                    $("#ThursdayFooterTotal").html(ParseLocale(hours[5]));
                    $("#FridayFooterTotal").html(ParseLocale(hours[6]));
                    break;
                case 6:
                    $("#MondayFooterTotal").html(ParseLocale(hours[0]));
                    $("#TuesdayFooterTotal").html(ParseLocale(hours[1]));
                    $("#WednesdayFooterTotal").html(ParseLocale(hours[2]));
                    $("#ThursdayFooterTotal").html(ParseLocale(hours[3]));
                    $("#FridayFooterTotal").html(ParseLocale(hours[4]));
                    $("#SaturdayFooterTotal").html(ParseLocale(hours[5]));
                    $("#SundayFooterTotal").html(ParseLocale(hours[6]));
                    break;
                default:
                    $("#SundayFooterTotal").html(ParseLocale(hours[0]));
                    $("#MondayFooterTotal").html(ParseLocale(hours[1]));
                    $("#TuesdayFooterTotal").html(ParseLocale(hours[2]));
                    $("#WednesdayFooterTotal").html(ParseLocale(hours[3]));
                    $("#ThursdayFooterTotal").html(ParseLocale(hours[4]));
                    $("#FridayFooterTotal").html(ParseLocale(hours[5]));
                    $("#SaturdayFooterTotal").html(ParseLocale(hours[6]));
                    break;
            }

            $("#WeekGrandTotal").html(ParseLocale(hours[7]));

            var sun = 0;
            var mon = 0;
            var tue = 0;
            var wed = 0;
            var thu = 0;
            var fri = 0;
            var sat = 0;
            var tot = 0;

            sun = hours[0] * 1;
            mon = hours[1] * 1;
            tue = hours[2] * 1;
            wed = hours[3] * 1;
            thu = hours[4] * 1;
            fri = hours[5] * 1;
            sat = hours[6] * 1;
            tot = hours[7] * 1;

            $("#SundayFooterTotal").removeClass("warning");
            $("#MondayFooterTotal").removeClass("warning");
            $("#TuesdayFooterTotal").removeClass("warning");
            $("#WednesdayFooterTotal").removeClass("warning");
            $("#ThursdayFooterTotal").removeClass("warning");
            $("#FridayFooterTotal").removeClass("warning");
            $("#SaturdayFooterTotal").removeClass("warning");

            switch (hours[8] * 1) {
                case 1:
                    if (sun > 24) {
                        $("#SundayFooterTotal").addClass("warning");
                    }
                    if (mon > 24) {
                        $("#MondayFooterTotal").addClass("warning");
                    }
                    if (tue > 24) {
                        $("#TuesdayFooterTotal").addClass("warning");
                    }
                    if (wed > 24) {
                        $("#WednesdayFooterTotal").addClass("warning");
                    }
                    if (thu > 24) {
                        $("#ThursdayFooterTotal").addClass("warning");
                    }
                    if (fri > 24) {
                        $("#FridayFooterTotal").addClass("warning");
                    }
                    if (sat > 24) {
                        $("#SaturdayFooterTotal").addClass("warning");
                    }
                    break;
                case 6:
                    if (sun > 24) {
                        $("#MondayFooterTotal").addClass("warning");
                    }
                    if (mon > 24) {
                        $("#TuesdayFooterTotal").addClass("warning");
                    }
                    if (tue > 24) {
                        $("#WednesdayFooterTotal").addClass("warning");
                    }
                    if (wed > 24) {
                        $("#ThursdayFooterTotal").addClass("warning");
                    }
                    if (thu > 24) {
                        $("#FridayFooterTotal").addClass("warning");
                    }
                    if (fri > 24) {
                        $("#SaturdayFooterTotal").addClass("warning");
                    }
                    if (sat > 24) {
                        $("#SundayFooterTotal").addClass("warning");
                    }
                    break;
                default:
                    if (sun > 24) {
                        $("#SundayFooterTotal").addClass("warning");
                    }
                    if (mon > 24) {
                        $("#MondayFooterTotal").addClass("warning");
                    }
                    if (tue > 24) {
                        $("#TuesdayFooterTotal").addClass("warning");
                    }
                    if (wed > 24) {
                        $("#WednesdayFooterTotal").addClass("warning");
                    }
                    if (thu > 24) {
                        $("#ThursdayFooterTotal").addClass("warning");
                    }
                    if (fri > 24) {
                        $("#FridayFooterTotal").addClass("warning");
                    }
                    if (sat > 24) {
                        $("#SaturdayFooterTotal").addClass("warning");
                    }
                    break;
            }


        }
    }   
}
function setFooterTotalsFail(error, userContext, methodName) {

}

function setLineTotal(sunControlId, monControlId, tueControlId, wedControlId, thuControlId, friControlId, satControlId, totControlId) {
    var sun = 0;
    var mon = 0;
    var tue = 0;
    var wed = 0;
    var thu = 0;
    var fri = 0;
    var sat = 0;
    var tot = 0;

    try {
        if (sunControlId) {
            if ($("#" + sunControlId)) {
                sun = $("#" + sunControlId).val();
            }
        }
    } catch (e) {
        sun = 0;
    }
    try {
        if (monControlId) {
            if ($("#" + monControlId)) {
                mon = $("#" + monControlId).val();
            }
        }
    } catch (e) {
        mon = 0;
    }
    try {
        if (tueControlId) {
            if ($("#" + tueControlId)) {
                tue = $("#" + tueControlId).val();
            }
        }
    } catch (e) {
        tue = 0;
    }
    try {
        if (wedControlId) {
            if ($("#" + wedControlId)) {
                wed = $("#" + wedControlId).val();
            }
        }
    } catch (e) {
        wed = 0;
    }
    try {
        if (thuControlId) {
            if ($("#" + thuControlId)) {
                thu = $("#" + thuControlId).val();
            }
        }
    } catch (e) {
        thu = 0;
    }
    try {
        if (friControlId) {
            if ($("#" + friControlId)) {
                fri = $("#" + friControlId).val();
            }
        }
    } catch (e) {
        fri = 0;
    }
    try {
        if (satControlId) {
            if ($("#" + satControlId)) {
                sat = $("#" + satControlId).val();
            }
        }
    } catch (e) {
        sat = 0;
    }
    if (!sun) {
        sun = 0;
    }
    if (!mon) {
        mon = 0;
    }
    if (!tue) {
        tue = 0;
    }
    if (!wed) {
        wed = 0;
    }
    if (!thu) {
        thu = 0;
    }
    if (!fri) {
        fri = 0;
    }
    if (!sat) {
        sat = 0;
    }
    //alert(sun)
    //alert(mon)
    //alert(tue)
    //alert(wed)
    //alert(thu)
    //alert(fri)
    //alert(sat)
    //tot = parseFloat(sun) + parseFloat(mon) + parseFloat(tue) + parseFloat(wed) + parseFloat(thu) + parseFloat(fri) + parseFloat(sat);      

    try {
        var su = Number.parseLocale(sun);
    } catch (e) {
        su = 0;
    }
    try {
        var mn = Number.parseLocale(mon);
    } catch (e) {
        mn = 0;
    }
    try {
        var tu = Number.parseLocale(tue);
    } catch (e) {
        tu = 0;
    }
    try {
        var we = Number.parseLocale(wed);
    } catch (e) {
        we = 0;
    }
    try {
        var th = Number.parseLocale(thu);
    } catch (e) {
        th = 0;
    }
    try {
        var fr = Number.parseLocale(fri);
    } catch (e) {
        fr = 0;
    }
    try {
        var sa = Number.parseLocale(sat);
    } catch (e) {
        sa = 0;
    }
    
    tot = (su * 1) + (mn * 1) + (tu * 1) + (we * 1) + (th * 1) + (fr * 1) + (sa * 1);
    //alert(tot)

    if (isNaN(tot) == false && totControlId) {
        if ($("#" + totControlId)) {
                $("#" + totControlId).html(String.localeFormat("{0:n}", tot));
        }
    }

}

function ValidateFunctionCategory(jobNumber, jobComponentNumber, employeeCode, functionCategoryCode) {
    PageMethods.ValidateFunctionCategory(jobNumber, jobComponentNumber, employeeCode, functionCategoryCode, functionCategoryValid, functionCategoryInvalid)
}
function functionCategoryValid(result, userContext, methodName) {
    try {
        if (result && result != '') {
            //alert(result);
            var str = "";
            str = result
            str = str.replace("##", '\n');
            str = str.replace("##", '\n');
            if (str.indexOf("[object") > -1) {
                return false;
            } else {
                alert(str);
                return false
            }
        } else {
            return true;
        }
    }
    catch (err) { }
};
function functionCategoryInvalid(error, userContext, methodName) {
    try {
        //alert(error);
        var str = '';
        str = error;
        if (str.indexOf("[object") > -1) {
            return false;
        }
        else {
            alert(str);
            return false;
        }
    }
    catch (err) { }
};
function checkForComment(hoursTextBoxName, commentTextBoxName) {
    var hoursTextBox = document.getElementById(hoursTextBoxName);
    var commentsTextBox = document.getElementById(commentTextBoxName);
    if (hoursTextBox != undefined && commentsTextBox != undefined) {
        var hours = hoursTextBox.value;
        var comment = commentsTextBox.value;
        if (hours && isNaN(hours) === false && hours != 0) {
            var ctb = $('#' + commentTextBoxName);
            if (!comment || comment.trim() == "") {
                ctb.addClass('standard-red');
                commentsTextBox.focus();
            } else {
                if (ctb.hasClass('standard-red')) {
                    ctb.toggleClass('standard-red');
                }
                //if (ctb.hasClass('RequiredInput')) {
                //    ctb.toggleClass('RequiredInput');
                //} else {
                    ctb.addClass('RequiredInput');
                //}
            }
        }
    }
}
