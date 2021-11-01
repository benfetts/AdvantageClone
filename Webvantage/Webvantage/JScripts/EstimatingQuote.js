function checkLength(field, len) {
    if (field.value.length > len) // too long...trim it!
        field.value = field.value.substring(0, len);
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
function checkvalue(id) {
    if (document.getElementById) {
        obj = document.getElementById(id);
        if (obj.value == '1') {
            return '1';
        } else {
            return '0';
        }
    }

}
function MultiplyPerc(text1, text2, textResult, textmu) {
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var z = 0;

    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    if (isNaN(x) == false && isNaN(y) == false) {
        z = (x * 1.000) * ((y * 1.000) / 100.000)

        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
        document.getElementById(textmu).value = String.localeFormat("{0:n}", z);
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function Divide(text1, text2, textResult) {
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var z = 0;

    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    if (isNaN(x) == false && isNaN(y) == false) {
        z = (x * 1) / (y * 1)

        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function Multiply(text1, text2, text3, textResult) {
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var c = document.getElementById(text3).value;
    var z = 0;
    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    if (isNaN(x) == false && isNaN(y) == false) {
        if (c == '1') {
            z = ((x * 1) / 1000) * (y * 1)

            document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
        }
        else {
            z = (x * 1) * (y * 1)

            document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
        }
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function CalcRateOverrideEst(text1, text2, text3, text4) //t1 = qty,t2 = rate,t3 = amt
{
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text3).value;
    var r = document.getElementById(text2).value;
    var c = document.getElementById(text4).value;
    var z = 0.000;

    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    c = Number.parseLocale(c);
    r = Number.parseLocale(r);
    if (isNaN(x) == false && isNaN(y) == false && ((x * 1.000) > 0.000)) {
        if (c == '1') {
            z = (y * 1.000) / ((x * 1.000) / 1000)
            //z = z.toFixed(3)
            document.getElementById(text2).value = String.localeFormat("{0:n4}", z);
        }
        else {
            z = (y * 1.000) / (x * 1.000)
            //z = z.toFixed(3)
            document.getElementById(text2).value = String.localeFormat("{0:n4}", z);
        }
    }
    else {
        //document.getElementById(text2).value = '99999';
    }
}
function CalcRateEst(text1, text2, text3) //t1 = qty,t2 = rate,t3 = amt
{
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text3).value;
    var r = document.getElementById(text2).value;
    var z = 0.000;
    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    r = Number.parseLocale(r);
    if (r == "0.000" || r == "")//only recalc the rate if rate doesn't exist
    {
        if (isNaN(x) == false && isNaN(y) == false && ((x * 1.000) > 0.000)) {
            z = (y * 1.000) / (x * 1.000)
            //z = z.toFixed(3)
            document.getElementById(text2).value = String.localeFormat("{0:n}", z);
        }
        else {
            //document.getElementById(text2).value = '0.00';
        }
    }
}
function CalcTaxAmount(text1, text2, taxstate, taxcity, taxcounty, taxcomm, taxcommonly, markup) //t1 = extamt,t2 = taxamt
{
    var x = document.getElementById(text1).value;
    var w = document.getElementById(markup).value;
    var j = document.getElementById(taxstate).value;
    var k = document.getElementById(taxcity).value;
    var l = document.getElementById(taxcounty).value;
    var m = document.getElementById(taxcomm).value;
    var n = document.getElementById(taxcommonly).value;
    var z = 0;
    var y = 0;
    var statetax = 0;
    var citytax = 0;
    var countytax = 0;
    var statemutax = 0;
    var citymutax = 0;
    var countymutax = 0;

    x = Number.parseLocale(x);
    w = Number.parseLocale(w);
    j = Number.parseLocale(j);
    k = Number.parseLocale(k);
    l = Number.parseLocale(l);
    m = Number.parseLocale(m);
    n = Number.parseLocale(n);
    if (isNaN(x) == false && x > 0) {
        if (n != 1) {
            statetax = ((x * 1) * ((j * 1) / 100));
            citytax = ((x * 1) * ((k * 1) / 100));
            countytax = ((x * 1) * ((l * 1) / 100));
            //z = ((x * 1) * ((j * 1) / 100)) + ((x * 1) * ((k * 1) / 100)) + ((x * 1) * ((l * 1) / 100))
        }
        if (m == 1 && w > 0) {
            statemutax = ((w * 1) * ((j * 1) / 100));
            citymutax = ((w * 1) * ((k * 1) / 100));
            countymutax = ((w * 1) * ((l * 1) / 100));
            //y = ((w * 1) * ((j * 1) / 100)) + ((w * 1) * ((k * 1) / 100)) + ((w * 1) * ((l * 1) / 100))
        }

        statetax = statetax + statemutax;
        citytax = citytax + citymutax;
        countytax = countytax + countymutax

        statetax = statetax.toFixed(2);
        citytax = citytax.toFixed(2);
        countytax = countytax.toFixed(2);

        z = parseFloat(statetax) + parseFloat(citytax) + parseFloat(countytax);
        //z = z + y

        if (isNaN(z) == false) {
            document.getElementById(text2).value = String.localeFormat("{0:n}", z);
        }
        else {
            document.getElementById(text2).value = String.localeFormat("{0:n}", 0);
        }

    }
    else {
        document.getElementById(text2).value = String.localeFormat("{0:n}", 0);
    }
}
function AddTotal(text1, text2, text3, textResult) {
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var w = document.getElementById(text3).value;
    var z = 0;

    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    w = Number.parseLocale(w);
    if (isNaN(x) == false && isNaN(y) == false && isNaN(w) == false) {
        z = (x * 1) + (y * 1) + (w * 1)

        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function AddTotalQuoteContingency(text1, text2, text3, text4, textResult) {
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var w = document.getElementById(text3).value;
    var v = document.getElementById(text4).value;
    var z = 0;

    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    w = Number.parseLocale(w);
    if (isNaN(x) == false && isNaN(y) == false && isNaN(w) == false && isNaN(v) == false) {
        z = (x * 1) + (y * 1) + (w * 1) + (v * 1)

        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function AddTotalExtMU(text1, text2, textResult) {
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var z = 0;

    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    if (isNaN(x) == false && isNaN(y) == false) {
        z = (x * 1) + (y * 1)

        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function CalcPerc(text1, text2, textResult, textmu) {
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var z = 0; 
    var m = document.getElementById(textmu).value;

    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    if (isNaN(x) == false && isNaN(y) == false && y != 0) {
        z = ((x * 1) / (y * 1)) * 100
        if (x != m) {
            document.getElementById(textResult).value = String.localeFormat("{0:n3}", z);
            document.getElementById(textmu).value = String.localeFormat("{0:n}", x);
        }       
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n3}", 0);
    }
}
function AddGrossIncome(text1, text2, text3, textResult) {
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var w = document.getElementById(text3).value;
    var z = 0;
    
    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    //w = Number.parseLocale(w);
    if (isNaN(x) == false && isNaN(y) == false) {
        if (w == 'E') {
            z = (x * 1) + (y * 1)

            document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
        }
        if (w == 'I') {
            z = (x * 1) + (y * 1)

            document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
        }
        if (w == 'V') {
            z = (y * 1)

            document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
        }
        if (w == 'C') {
            z = '0.00'

            document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
        }
    }
    else {
        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
    }
}
function CalcContAmount(text1, text2, textresult, hfresult, taxstate, taxcity, taxcounty, markup, taxcomm, taxcommonly) //t1 = extamt,t2 = taxamt
{
    var x = document.getElementById(text1).value;
    var y = document.getElementById(text2).value;
    var m = document.getElementById(markup).value;
    var n = document.getElementById(taxcomm).value;
    var o = document.getElementById(taxcommonly).value;
    var j = document.getElementById(taxstate).value;
    var k = document.getElementById(taxcity).value;
    var l = document.getElementById(taxcounty).value;
    var z = 0;
    var b = 0;
    var u = 0;
    var p = 0;

    x = Number.parseLocale(x);
    y = Number.parseLocale(y);
    o = Number.parseLocale(o);
    j = Number.parseLocale(j);
    k = Number.parseLocale(k);
    l = Number.parseLocale(l);
    m = Number.parseLocale(m);
    n = Number.parseLocale(n);
    if (isNaN(x) == false && isNaN(y) == false) {
        z = (x * 1) * ((y * 1) / 100)
        u = (x * 1) * ((y * 1) / 100)
        p = ((m * 1) * ((y * 1) / 100))
        if (n == 1 && o == 1) {
            b = ((p * 1) * ((j * 1) / 100)) + ((p * 1) * ((k * 1) / 100)) + ((p * 1) * ((l * 1) / 100))
        } else if (n == 1) {
            b = (((z + p) * 1) * ((j * 1) / 100)) + (((z + p) * 1) * ((k * 1) / 100)) + (((z + p) * 1) * ((l * 1) / 100))
        } else {
            b = ((z * 1) * ((j * 1) / 100)) + ((z * 1) * ((k * 1) / 100)) + ((z * 1) * ((l * 1) / 100))
        }
        z = z + p + b

        if (isNaN(z) == false) {
            document.getElementById(textresult).value = String.localeFormat("{0:n}", z);
        }
        else {
            document.getElementById(textresult).value = String.localeFormat("{0:n}", 0);
        }
        if (isNaN(u) == false) {
            document.getElementById(hfresult).value = String.localeFormat("{0:n}", u);
        }
        else {
            document.getElementById(hfresult).value = String.localeFormat("{0:n}", 0);
        }

    }
    else {
        document.getElementById(text2).value = String.localeFormat("{0:n}", 0);
    }
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
    else
        args.set_cancel(true);
}
function confirmDelete() {
    if (confirm("Are you sure you want to delete?")) {
        realPostBack("DelRevision", "DelRevision");
        //return false;
    }
}
function confirmDeleteCApproval() {
    if (confirm("Are you sure you want to delete this Client Approval?")) {
        realPostBack("ClientApprove", "ClientApprove");
        //return false;
    } else {
        return false;
    }
}
function confirmDeleteIApproval() {
    if (confirm("Are you sure you want to delete this Internal Approval?")) {
        realPostBack("InternalApprove", "InternalApprove");
        //return false;
    } else {
        return false;
    }
}
function confirmSave() {
    if (confirm("This quote is approved. Are you sure you want to save the changes?")) {
        realPostBack("Save", "Save");
        //return false;
    } else {
        return false;
    }
}
function confirmSaveEG() {
    if (confirm("This quote is approved. Are you sure you want to create an event?")) {
        realPostBack("EventGenerator", "EventGenerator");
        //return false;
    } else {
        return false;
    }
}
function confirmBack() {
    if (confirm("Did you save all new data?")) {
        window.close();
        window.opener.focus();
        //return false;
    }
}
function confirmRows() {
    radalert("No rows were selected for deletion.")
}
function DataChange(RowDataKey, ControlType, ControlName, ControlValue) {
    try {
        //alert(ControlName);
        PageMethods.DetailAutoSaveEst(RowDataKey, ControlType, ControlName, ControlValue, DataChangeSucceeded, DataChangeFailed);
        //if (DataChangeSucceeded() == false) {
        //alert(ControlName);
        //}
        return false;
    }
    catch (err) { }
}
function DataChangeSucceeded(result, userContext, methodName) {
    try {
        //$get('div1').innerHTML = result;
        if (result != '') {
            var str = "";
            str = result
            str = str.replace("##", '\n');
            str = str.replace("##", '\n');
            if (str.indexOf("[object") > -1) {
            }
            else {
                radalert(str);
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
        var str = '';
        str = error;
        if (str.indexOf("[object") > -1) {
        }
        else {
            radalert(str);
        }
        //return false;
    }
    catch (err) { }
}
function DataChangeQty(ChkRowDataKey, QtyClientId, RateClientId, HfCPMClientID, MarkupPctClientId, TaxCodeClientId, ContPctClientId, HfTaxCommClientId, HfTaxCommOnlyClientId, FunctionTypeClientId, ExtAmtClientID, MarkupAmtClientID, FuncCodeClientID, SuppliedByClientID, EmpTitleClientID, ControlName) {
    try {
        if (ControlName == 'quantity') {
            PageMethods.SaveEstQty(ChkRowDataKey, QtyClientId.value, RateClientId.value, HfCPMClientID.value, MarkupPctClientId.value, TaxCodeClientId.value, ContPctClientId.value, HfTaxCommClientId.value, HfTaxCommOnlyClientId.value, FunctionTypeClientId.value, ExtAmtClientID.value, MarkupAmtClientID.value, FuncCodeClientID.value, SuppliedByClientID.value, EmpTitleClientID.value, ControlName, QtyClientId.id, DataChangeSucceeded, DataChangeFailed);
        } else if (ControlName == 'rate') {
            PageMethods.SaveEstQty(ChkRowDataKey, QtyClientId.value, RateClientId.value, HfCPMClientID.value, MarkupPctClientId.value, TaxCodeClientId.value, ContPctClientId.value, HfTaxCommClientId.value, HfTaxCommOnlyClientId.value, FunctionTypeClientId.value, ExtAmtClientID.value, MarkupAmtClientID.value, FuncCodeClientID.value, SuppliedByClientID.value, EmpTitleClientID.value, ControlName, RateClientId.id, DataChangeSucceeded, DataChangeFailed);
        } else if (ControlName == 'markuppct') {
            PageMethods.SaveEstQty(ChkRowDataKey, QtyClientId.value, RateClientId.value, HfCPMClientID.value, MarkupPctClientId.value, TaxCodeClientId.value, ContPctClientId.value, HfTaxCommClientId.value, HfTaxCommOnlyClientId.value, FunctionTypeClientId.value, ExtAmtClientID.value, MarkupAmtClientID.value, FuncCodeClientID.value, SuppliedByClientID.value, EmpTitleClientID.value, ControlName, MarkupPctClientId.id, DataChangeSucceeded, DataChangeFailed);
        } else if (ControlName == 'markupamt') {
            PageMethods.SaveEstQty(ChkRowDataKey, QtyClientId.value, RateClientId.value, HfCPMClientID.value, MarkupPctClientId.value, TaxCodeClientId.value, ContPctClientId.value, HfTaxCommClientId.value, HfTaxCommOnlyClientId.value, FunctionTypeClientId.value, ExtAmtClientID.value, MarkupAmtClientID.value, FuncCodeClientID.value, SuppliedByClientID.value, EmpTitleClientID.value, ControlName, MarkupAmtClientID.id, DataChangeSucceeded, DataChangeFailed);
        } else if (ControlName == 'contpct') {
            PageMethods.SaveEstQty(ChkRowDataKey, QtyClientId.value, RateClientId.value, HfCPMClientID.value, MarkupPctClientId.value, TaxCodeClientId.value, ContPctClientId.value, HfTaxCommClientId.value, HfTaxCommOnlyClientId.value, FunctionTypeClientId.value, ExtAmtClientID.value, MarkupAmtClientID.value, FuncCodeClientID.value, SuppliedByClientID.value, EmpTitleClientID.value, ControlName, ContPctClientId.id, DataChangeSucceeded, DataChangeFailed);
        } else if (ControlName == 'extamt') {
            PageMethods.SaveEstQty(ChkRowDataKey, QtyClientId.value, RateClientId.value, HfCPMClientID.value, MarkupPctClientId.value, TaxCodeClientId.value, ContPctClientId.value, HfTaxCommClientId.value, HfTaxCommOnlyClientId.value, FunctionTypeClientId.value, ExtAmtClientID.value, MarkupAmtClientID.value, FuncCodeClientID.value, SuppliedByClientID.value, EmpTitleClientID.value, ControlName, ExtAmtClientID.id, DataChangeSucceeded, DataChangeFailed);
        } else {
            PageMethods.SaveEstQty(ChkRowDataKey, QtyClientId.value, RateClientId.value, HfCPMClientID.value, MarkupPctClientId.value, TaxCodeClientId.value, ContPctClientId.value, HfTaxCommClientId.value, HfTaxCommOnlyClientId.value, FunctionTypeClientId.value, ExtAmtClientID.value, MarkupAmtClientID.value, FuncCodeClientID.value, SuppliedByClientID.value, EmpTitleClientID.value, ControlName, '', DataChangeSucceeded, DataChangeFailed);
        }
        
    }
    catch (err) { }
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
            else if (str.indexOf("INVALID|") > -1) {
                var ar = new Array();
                ar = str.split("|");
                alert(ar[1]);
                document.getElementById(ar[2]).value = 0;
                document.getElementById(ar[2]).focus();
            }
            else {
                //alert(str)
                if (str.indexOf("Status code updated") > -1) {
                    //alert("hi");
                    var DataKey = new Array();
                    var NewCode = "";
                    var NewDesc = "";

                    DataKey = str.split('|');

                    NewCode = DataKey[1];
                    NewDesc = DataKey[2];

                    //alert(NewCode);
                    //alert(NewDesc);   
                    //alert("yuppers" + str)

                } else {

                    alert(str);
                   
                    
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
            radalert(str);
        }
        //return false;
    }
    catch (err) { }
}
function DataChangeCheckboxCPU(ChkRowDataKey, ControlClientId) {
    try {
        var val = 0;
        if (document.getElementById(ControlClientId).checked) {
            val = 1;
        }
        DataChange(ChkRowDataKey, 'chk', 'ChkCPU', val);
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
                        radalert(str);
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
            radalert(str);
        }
    }
    catch (err) { }
}
function DataChangeSuppliedByCode(ChkRowDataKey, SuppliedByCodeClientId, HfSuppliedByClientId, HfFunctionTypeClientId, SuppliedByCodeValue) {
    try {
        var TheHfSupByCode;
        var TheFunctionType;
        TheHfSupByCode = HfSuppliedByClientId.value;
        TheFunctionType = HfFunctionTypeClientId.value;
        PageMethods.SaveSuppliedByCode(ChkRowDataKey, SuppliedByCodeClientId, TheHfSupByCode, TheFunctionType, SuppliedByCodeValue, DataChangeSuppliedByCodeSucceeded, DataChangeSuppliedByCodeFailed);
    }
    catch (err) { }
}
function DataChangeSuppliedByCodeSucceeded(result, userContext, methodName) {
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
                        radalert(str);
                    }
                }
            }
            catch (err) { }
        }
        return false;
    }
    catch (err) { }
}
function DataChangeSuppliedByCodeFailed(error, userContext, methodName) {
    try {
        var str = '';
        str = error;
        if (str.indexOf("[object") > -1) {
        }
        else {
            radalert(str);
        }
    }
    catch (err) { }
}
function DataChangeContingency(ChkRowDataKey, ContPctClientId, ExtAmountClientId, MarkupAmtClientId, ContPctValue) {
    try {
        var TheExtAmount;
        var TheMarkupAmount;
        TheExtAmount = ExtAmountClientId.value;
        TheMarkupAmount = MarkupAmtClientId.value;
        PageMethods.SaveContingency(ChkRowDataKey, ContPctClientId, TheExtAmount, TheMarkupAmount, ContPctValue, DataChangeContPctSucceeded, DataChangeContPctFailed);
    }
    catch (err) { }
}
function DataChangeContPctSucceeded(result, userContext, methodName) {
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
                        radalert(str);
                    }
                }
            }
            catch (err) { }
        }
        return false;
    }
    catch (err) { }
}
function DataChangeContPctFailed(error, userContext, methodName) {
    try {
        var str = '';
        str = error;
        if (str.indexOf("[object") > -1) {
        }
        else {
            radalert(str);
        }
    }
    catch (err) { }
}
function DataChangeTaxCode(ChkRowDataKey, TaxCodeClientId, HfTaxCommClientId, HfTaxCommOnlyClientId, ExtAmountClientId, MarkupAmountClientId, ContPctClientId, FunctionTypeClientId, TaxCodeValue) {
    try {
        var TheHfTaxComm;
        var TheHfTaxCommOnly;
        var TheExtAmount;
        var TheMarkupAmount;
        var TheContPct;
        var TheFunctionType;
        TheHfTaxComm = HfTaxCommClientId.value;
        TheHfTaxCommOnly = HfTaxCommOnlyClientId.value;
        TheExtAmount = ExtAmountClientId.value;
        TheMarkupAmount = MarkupAmtClientId.value;
        TheContPct = ContPctClientId.value;
        TheFunctionType = FunctionTypeClientId.value;
        PageMethods.SaveTaxCode(ChkRowDataKey, TaxCodeClientId, TheHfTaxComm, TheHfTaxCommOnly, TheExtAmount, TheMarkupAmount, TheContPct, TheFunctionType, TaxCodeValue, DataChangeTaxCodeSucceeded, DataChangeTaxCodeFailed);
    }
    catch (err) { }
}
function DataChangeTaxCodeSucceeded(result, userContext, methodName) {
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
                        radalert(str);
                    }
                }
            }
            catch (err) { }
        }
        return false;
    }
    catch (err) { }
}
function DataChangeTaxCodeFailed(error, userContext, methodName) {
    try {
        var str = '';
        str = error;
        if (str.indexOf("[object") > -1) {
        }
        else {
            radalert(str);
        }
    }
    catch (err) { }
}
function DataChangeEstimateHeader(ThisDataKey, FieldName, ControlValue, ControlClientId) {
    try {

        //alert(ThisDataKey);
        //alert(FieldName);
        //alert(ControlValue);
        //alert(ControlClientId);

        PageMethods.AutoSaveEstimateHeader(ThisDataKey, FieldName, ControlValue, ControlClientId, DataChangeScheduleHeaderSucceeded, DataChangeScheduleHeaderFailed);

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
            else if (str.indexOf("ERROR|") > -1) {
                var ar = new Array();
                ar = str.split("|");
                alert(ar[1]);
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
            radalert(str);
        }
    }
    catch (err) { }
}
function OnClientClose(sender, EventArgs) {
    //    GetRadWindow().BrowserWindow.location.reload();
    //__doPostBack('onclick#Refresh', 'Refresh');

}
