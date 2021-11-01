function BACalculateTax(ApprResaleTaxFlag, ApprTaxCommFlag, ApprTaxCommOnlyFlag, FunctionType, NetAmount, MarkupAmt, StateTax, CountyTax, CityTax,
                        ApprResaleTaxField, ApprVendorTaxField, TaxAmountField, TaxAmountHiddenField, AgencyTaxOnBilling) {

    //alert("BACalculateTax");

    var errmsg = "";
    var isDebug = false;
    var debugLineHits = false;
    var debug_output = "";

    try {

        //these are "read only" flags in hidden fields
        var vApprResaleTaxFlag = document.getElementById(ApprResaleTaxFlag).value;
        var vApprTaxCommFlag = document.getElementById(ApprTaxCommFlag).value;
        var vApprTaxCommOnlyFlag = document.getElementById(ApprTaxCommOnlyFlag).value;
        var vFunctionType = document.getElementById(FunctionType).value;

        //these are textboxes
        var vNetAmount = document.getElementById(NetAmount).value;
        var vMarkupAmt = document.getElementById(MarkupAmt).value;

        //these are "read only" flags in hidden fields
        var vStateTax = document.getElementById(StateTax).value;
        var vCountyTax = document.getElementById(CountyTax).value;
        var vCityTax = document.getElementById(CityTax).value;

        vApprResaleTaxFlag = Number.parseLocale(vApprResaleTaxFlag);
        vApprTaxCommFlag = Number.parseLocale(vApprTaxCommFlag);
        vApprTaxCommOnlyFlag = Number.parseLocale(vApprTaxCommOnlyFlag);
        vNetAmount = Number.parseLocale(vNetAmount);
        vMarkupAmt = Number.parseLocale(vMarkupAmt);
        vStateTax = Number.parseLocale(vStateTax);
        vCountyTax = Number.parseLocale(vCountyTax);
        vCityTax = Number.parseLocale(vCityTax);

        var vApprResaleTaxField = document.getElementById(ApprResaleTaxField); //hidden field
        var vApprVendorTaxField = document.getElementById(ApprVendorTaxField); //hidden field
        var vTaxAmountField = document.getElementById(TaxAmountField); //visible textbox
        var vTaxAmountHiddenField = document.getElementById(TaxAmountHiddenField); //hidden field

        var vTaxTotal = 0.000;
        var vTaxTotal2 = 0.000;
        var vTaxTotalSum = 0.000;

        try { vNetAmount = (vNetAmount * 1.000); } catch (err) { vNetAmount = 0.000; }
        try { vMarkupAmt = (vMarkupAmt * 1.000); } catch (err) { vMarkupAmt = 0.000; }
        try { vStateTax = (vStateTax * 1.000); } catch (err) { vStateTax = 0.000; }
        try { vCountyTax = (vCountyTax * 1.000); } catch (err) { vCountyTax = 0.000; }
        try { vCityTax = (vCityTax * 1.000); } catch (err) { vCityTax = 0.000; }

        if (isDebug === true) {

            debug_output = "FLAGS:\n";
            debug_output += "vApprResaleTaxFlag: " + vApprResaleTaxFlag + "\n";
            debug_output += "vApprTaxCommOnlyFlag: " + vApprTaxCommOnlyFlag + "\n";
            debug_output += "vApprTaxCommFlag: " + vApprTaxCommFlag + "\n";
            debug_output += "vFunctionType: " + vFunctionType + "\n";
            debug_output += "\n\nVALUES:";
            debug_output += "vNetAmount: " + (vNetAmount * 1.000) + "\n";
            debug_output += "vStateTax: " + (vStateTax / 100.000) + "\n";
            debug_output += "vCountyTax: " + (vCountyTax / 100.000) + "\n";
            debug_output += "vCityTax: " + (vCityTax / 100.000) + "\n";
            alert(debug_output);

        }

        var taxedNetAmount = 0.000;
        var taxedMarkupAmount = 0.000;

        taxedNetAmount = ((vNetAmount * vStateTax) / 100) + ((vNetAmount * vCountyTax) / 100) + ((vNetAmount * vCityTax) / 100);
        taxedMarkupAmount = ((vMarkupAmt * vStateTax) / 100) + ((vMarkupAmt * vCountyTax) / 100) + ((vMarkupAmt * vCityTax) / 100);

        if (debugLineHits === true) { alert("You hit line number 74"); }
        if (vFunctionType == "E" || vFunctionType == "I") {
            if (debugLineHits === true) { alert("You hit line number 76"); }

            if (vApprTaxCommFlag == "1") {

                if (debugLineHits === true) { alert("You hit line number 80"); }
                if (isDebug === true) { alert("vMarkupAmt is: " + vMarkupAmt); }

                vTaxTotal = taxedNetAmount;
                if (isDebug === true) { alert("vTaxTotal is:" + vTaxTotal); }

                vTaxTotal2 = taxedMarkupAmount;
                if (isDebug === true) { alert("vTaxTotal2 is:" + vTaxTotal2); }

                vTaxTotalSum = (vTaxTotal * 1.000) + (vTaxTotal2 * 1.000);
                vTaxTotalSum = String.localeFormat("{0:n}", vTaxTotalSum);
                vTaxAmountField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                vTaxAmountHiddenField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                vApprResaleTaxField.value = String.localeFormat("{0:n}", vTaxTotalSum);

            }
            if (vApprTaxCommFlag == "0") {

                if (debugLineHits === true) { alert("You hit line number 98"); }
                if (isDebug === true) { alert("vMarkupAmt is: " + vMarkupAmt); }

                vTaxTotal = taxedNetAmount;
                vTaxTotal2 = 0.000;
                if (isDebug === true) { alert("vTaxTotal is:" + vTaxTotal); }

                vTaxTotalSum = (vTaxTotal * 1.000) + (vTaxTotal2 * 1.000);
                vTaxTotalSum = String.localeFormat("{0:n}", vTaxTotalSum);
                vTaxAmountField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                vTaxAmountHiddenField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                vApprResaleTaxField.value = String.localeFormat("{0:n}", vTaxTotalSum);

            }
            if (vApprTaxCommOnlyFlag == "1") {

                if (debugLineHits === true) { alert("You hit line number 114"); }
                if (isDebug === true) { alert("vMarkupAmt is: " + vMarkupAmt); }

                vTaxTotal = 0.000;
                vTaxTotal2 = taxedMarkupAmount;
                if (isDebug === true) { alert("vTaxTotal2 is:" + vTaxTotal2); }

                vTaxTotalSum = (vTaxTotal * 1.000) + (vTaxTotal2 * 1.000);
                vTaxTotalSum = String.localeFormat("{0:n}", vTaxTotalSum);
                vTaxAmountField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                vTaxAmountHiddenField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                vApprResaleTaxField.value = String.localeFormat("{0:n}", vTaxTotalSum);

            }
        }


        if (vFunctionType == "V") {

            if (debugLineHits === true) { alert("You hit line number 133"); }

            if (AgencyTaxOnBilling === false) {
                if (vApprResaleTaxFlag == "1") { // APPR_RESALE_TAX = TRUE

                    if (debugLineHits === true) { alert("You hit line number 138"); }
                    if (vApprTaxCommFlag == "1") {

                        if (debugLineHits === true) { alert("You hit line number 141"); }
                        vTaxTotal = taxedNetAmount;
                        vTaxTotal2 = taxedMarkupAmount;

                    }
                    if (vApprTaxCommFlag == "0") {

                        if (debugLineHits === true) { alert("You hit line number 148"); }

                        vTaxTotal = taxedNetAmount;
                        vTaxTotal2 = 0;

                    }
                    if (vApprTaxCommOnlyFlag == "1") {

                        vTaxTotal = 0;
                        vTaxTotal2 = taxedMarkupAmount;

                    }

                    vTaxTotalSum = (vTaxTotal * 1.000) + (vTaxTotal2 * 1.000);
                    vTaxTotalSum = String.localeFormat("{0:n}", vTaxTotalSum);
                    vTaxAmountField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                    vTaxAmountHiddenField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                    vApprResaleTaxField.value = String.localeFormat("{0:n}", vTaxTotalSum);

                }
                if (vApprResaleTaxFlag == "0") { // APPR_RESALE_TAX = FALSE

                    if (debugLineHits === true) { alert("You hit line number 170"); }
                    if (vApprTaxCommFlag === "1") {
                        if (debugLineHits === true) { alert("You hit line number 172"); }
                        vTaxTotal = taxedNetAmount;
                        vTaxTotal2 = taxedMarkupAmount;
                    }
                    if (vApprTaxCommFlag == "0") {
                        if (debugLineHits === true) { alert("You hit line number 177"); }
                        vTaxTotal = taxedNetAmount;
                        vTaxTotal2 = 0;
                    }
                    if (vApprTaxCommOnlyFlag == "1") {
                        vTaxTotal = 0;
                        vTaxTotal2 = taxedMarkupAmount;
                    }

                    vTaxTotalSum = (vTaxTotal * 1.000) + (vTaxTotal2 * 1.000);
                    vTaxTotalSum = String.localeFormat("{0:n}", vTaxTotalSum);
                    vTaxAmountField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                    vTaxAmountHiddenField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                    //place in "non-resale tax amount"
                    vApprVendorTaxField.value = String.localeFormat("{0:n}", vTaxTotal);
                    //place in the "city/county/state tax amounts"
                    vApprResaleTaxField.value = String.localeFormat("{0:n}", vTaxTotal2);

                }

            }

            if (AgencyTaxOnBilling === true) {
                if (vApprResaleTaxFlag == "0") { // APPR_RESALE_TAX = FALSE
                    if (debugLineHits === true) { alert("You hit line number 201"); }
                    vTaxTotal = taxedNetAmount;
                    vTaxTotal2 = 0;
                }
                if (vApprResaleTaxFlag == "1") { // APPR_RESALE_TAX = TRUE
                    vTaxTotal = 0;
                    vTaxTotal2 = taxedMarkupAmount;
                }

                vTaxTotalSum = (vTaxTotal * 1.000) + (vTaxTotal2 * 1.000);
                vTaxTotalSum = String.localeFormat("{0:n}", vTaxTotalSum);
                vTaxAmountField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                vTaxAmountHiddenField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                //place in "non-resale tax amount"
                vApprVendorTaxField.value = String.localeFormat("{0:n}", vTaxTotal);
                //place in the "city/county/state tax amounts"
                vApprResaleTaxField.value = String.localeFormat("{0:n}", vTaxTotal2);
                if (debugLineHits === true) { alert("You hit line number 218"); }

            }

        }
    }
    catch (err) {
        errmsg = "Error with tax calc javascript:\n";
        errmsg += err.description;
        alert(errmsg);
    }
}
/*
function OLD___BACalculateTax(ApprResaleTaxFlag, ApprTaxCommFlag, ApprTaxCommOnlyFlag, FunctionType, NetAmount, MarkupAmt, StateTax, CountyTax, CityTax, ApprResaleTaxField, ApprVendorTaxField, TaxAmountField, TaxAmountHiddenField) {
    //alert('BACalculateTax');
    var errmsg = "";
    var isDebug = false;
    var debugLineHits = false;
    var debug_output = "";

    try {
        //these are "read only" flags in hidden fields
        var vApprResaleTaxFlag = document.getElementById(ApprResaleTaxFlag).value;
        var vApprTaxCommFlag = document.getElementById(ApprTaxCommFlag).value;
        var vApprTaxCommOnlyFlag = document.getElementById(ApprTaxCommOnlyFlag).value;
        var vFunctionType = document.getElementById(FunctionType).value;

        //these are textboxes
        var vNetAmount = document.getElementById(NetAmount).value;
        var vMarkupAmt = document.getElementById(MarkupAmt).value;

        //these are "read only" flags in hidden fields
        var vStateTax = document.getElementById(StateTax).value;
        var vCountyTax = document.getElementById(CountyTax).value;
        var vCityTax = document.getElementById(CityTax).value;

        vApprResaleTaxFlag = Number.parseLocale(vApprResaleTaxFlag);
        vApprTaxCommFlag = Number.parseLocale(vApprTaxCommFlag);
        vApprTaxCommOnlyFlag = Number.parseLocale(vApprTaxCommOnlyFlag);
        vFunctionType = Number.parseLocale(vFunctionType);
        vNetAmount = Number.parseLocale(vNetAmount);
        vMarkupAmt = Number.parseLocale(vMarkupAmt);
        vStateTax = Number.parseLocale(vStateTax);
        vCountyTax = Number.parseLocale(vCountyTax);
        vCityTax = Number.parseLocale(vCityTax);

        var vApprResaleTaxField = document.getElementById(ApprResaleTaxField); //hidden field
        var vApprVendorTaxField = document.getElementById(ApprVendorTaxField); //hidden field
        var vTaxAmountField = document.getElementById(TaxAmountField); //visible textbox
        var vTaxAmountHiddenField = document.getElementById(TaxAmountHiddenField); //hidden field

        var vTaxTotal = 0.000;
        var vTaxTotal2 = 0.000;
        var vTaxTotal3 = 0.000;
        var vTaxTotalSum = 0.000;

        try { vNetAmount = (vNetAmount * 1.000); } catch (err) { vNetAmount = 0.000; }
        try { vMarkupAmt = (vMarkupAmt * 1.000); } catch (err) { vMarkupAmt = 0.000; }
        try { vStateTax = (vStateTax * 1.000); } catch (err) { vStateTax = 0.000; }
        try { vCountyTax = (vCountyTax * 1.000); } catch (err) { vCountyTax = 0.000; }
        try { vCityTax = (vCityTax * 1.000); } catch (err) { vCityTax = 0.000; }

        if (isDebug == true) {
            debug_output = "FLAGS:\n";
            debug_output += "vApprResaleTaxFlag: " + vApprResaleTaxFlag + "\n";
            debug_output += "vApprTaxCommOnlyFlag: " + vApprTaxCommOnlyFlag + "\n";
            debug_output += "vApprTaxCommFlag: " + vApprTaxCommFlag + "\n";
            debug_output += "vFunctionType: " + vFunctionType + "\n";
            debug_output += "\n\nVALUES:";
            debug_output += "vNetAmount: " + (vNetAmount * 1.000) + "\n";
            debug_output += "vStateTax: " + (vStateTax / 100.000) + "\n";
            debug_output += "vCountyTax: " + (vCountyTax / 100.000) + "\n";
            debug_output += "vCityTax: " + (vCityTax / 100.000) + "\n";
            alert(debug_output);
        }

        if (vApprResaleTaxFlag == "1") // APPR_RESALE_TAX = TRUE
        {
            if (debugLineHits == true) { alert("You hit line number 409"); }
            if (vApprTaxCommOnlyFlag == "0") {
                vTaxTotal = ((vNetAmount * 1.000) * (vStateTax / 100.000)) + ((vNetAmount * 1.000) * (vCountyTax / 100.000)) + ((vNetAmount * 1.000) * (vCityTax / 100.000));
            };
            if (vApprTaxCommFlag == "1") {
                if (debugLineHits == true) { alert("You hit line number 414"); }
                vTaxTotal2 = ((vMarkupAmt * 1.000) * (vStateTax / 100.000)) + ((vMarkupAmt * 1.000) * (vCountyTax / 100.000)) + ((vMarkupAmt * 1.000) * (vCityTax / 100.000));
            };
            //                if(vApprTaxCommOnlyFlag == "1")
            //                {
            //                    vTaxTotal = 0.000;
            //	                vTaxTotal2 = ((vMarkupAmt * 1.000) * (vStateTax / 100.000)) + ((vMarkupAmt * 1.000) * (vCountyTax / 100.000)) + ((vMarkupAmt * 1.000) * (vCityTax / 100.000));
            //                }
            vTaxTotalSum = vTaxTotal + vTaxTotal2;
            //vTaxTotalSum = vTaxTotalSum.toFixed(2);
            vApprResaleTaxField.value = String.localeFormat("{0:n}", vTaxTotalSum);
            vTaxAmountField.value = String.localeFormat("{0:n}", vTaxTotalSum);
            vTaxAmountHiddenField.value = String.localeFormat("{0:n}", vTaxTotalSum);
        }
        else // APPR_RESALE_TAX = FALSE
        {
            if (debugLineHits == true) { alert("You hit line number 430"); }
            if (vFunctionType == "V") {
                if (debugLineHits == true) { alert("You hit line number 432"); }
                if (vApprTaxCommOnlyFlag == "0") {
                    if (isDebug == true) { alert("vApprTaxCommOnlyFlag is false"); }
                    vTaxTotal = ((vNetAmount * 1.000) * (vStateTax / 100.000)) + ((vNetAmount * 1.000) * (vCountyTax / 100.000)) + ((vNetAmount * 1.000) * (vCityTax / 100.000));
                    //vTaxTotal = vTaxTotal.toFixed(2);
                    vApprVendorTaxField.value = String.localeFormat("{0:n}", vTaxTotal);
                    vTaxAmountField.value = String.localeFormat("{0:n}", vTaxTotal);
                    vTaxAmountHiddenField.value = String.localeFormat("{0:n}", vTaxTotal);
                }
            }
            if (vFunctionType == "E" || vFunctionType == "I") {
                if (debugLineHits == true) { alert("You hit line number 443"); }
                if (vApprTaxCommOnlyFlag == "0") {
                    if (debugLineHits == true) { alert("You hit line number 445"); }
                    vTaxTotal = ((vNetAmount * 1.000) * (vStateTax / 100.000)) + ((vNetAmount * 1.000) * (vCountyTax / 100.000)) + ((vNetAmount * 1.000) * (vCityTax / 100.000));
                    //vTaxTotal = vTaxTotal.toFixed(2);
                    vApprResaleTaxField.value = String.localeFormat("{0:n}", vTaxTotal);
                    vTaxAmountField.value = String.localeFormat("{0:n}", vTaxTotal);
                    vTaxAmountHiddenField.value = String.localeFormat("{0:n}", vTaxTotal);
                }
            }
            if (vApprTaxCommFlag == "1") {
                if (debugLineHits == true) { alert("You hit line number 454"); }
                if (isDebug == true) { alert("vMarkupAmt is: " + vMarkupAmt); }
                vTaxTotal2 = ((vMarkupAmt * 1.000) * (vStateTax / 100.000)) + ((vMarkupAmt * 1.000) * (vCountyTax / 100.000)) + ((vMarkupAmt * 1.000) * (vCityTax / 100.000));
                if (isDebug == true) { alert("vTaxTotal2 is:" + vTaxTotal2); }
                if (vFunctionType == "E" || vFunctionType == "I") {
                    vApprResaleTaxField.value = String.localeFormat("{0:n}", ((vTaxTotal * 1.000) + (vTaxTotal2 * 1.000)));
                }
                if (vFunctionType == "V") {
                    vApprResaleTaxField.value = String.localeFormat("{0:n}", vTaxTotal2);
                }
                vTaxTotalSum = (vTaxTotal * 1.000) + (vTaxTotal2 * 1.000);
                vTaxTotalSum = String.localeFormat("{0:n}", vTaxTotalSum);
                //vTaxTotalSum = vTaxTotalSum.toFixed(2);
                //for display:
                vTaxAmountField.value = String.localeFormat("{0:n}", vTaxTotalSum);
                vTaxAmountHiddenField.value = String.localeFormat("{0:n}", vTaxTotalSum);
            }
            //                if(vApprTaxCommOnlyFlag == "1")
            //                {
            //                    if(debugLineHits == true){	alert("You hit line number 329");}
            //                    if(isDebug == true){alert("vMarkupAmt is: " + vMarkupAmt);}
            //	                vTaxTotal2 = ((vMarkupAmt * 1.000) * (vStateTax / 100.000)) + ((vMarkupAmt * 1.000) * (vCountyTax / 100.000)) + ((vMarkupAmt * 1.000) * (vCityTax / 100.000));
            //	                if(isDebug == true){alert("vTaxTotal2 is:"+vTaxTotal2);	}
            //                    if(vFunctionType == "E" || vFunctionType == "I")
            //                    {
            //	                    vApprResaleTaxField.value = vTaxTotal2;
            //	                }
            //	                if(vFunctionType == "V")
            //	                {
            //	                    vApprResaleTaxField.value = vTaxTotal2;
            //	                }
            //	                vTaxTotalSum = (vTaxTotal2 * 1.000);
            //	                vTaxTotalSum = vTaxTotalSum.toFixed(2);
            //	                //for display:
            //	                vTaxAmountField.value = vTaxTotalSum;
            //	                vTaxAmountHiddenField.value = vTaxTotalSum;
            //                }

        }
    }
    catch (err) {
        errmsg = "Error with tax calc javascript:\n";
        errmsg += err.description;
        alert(errmsg);
    }
}
*/
function BACalculateApprovedAmount(NetAmt, MarkupAmt, VendorTaxAmt, ResaleTaxAmt, AmountApprovedField) {
    try {
        //alert('BACalculateApprovedAmount');
        var vNetAmt = document.getElementById(NetAmt).value;
        var vMarkupAmt = document.getElementById(MarkupAmt).value;
        var vVendorTaxAmt = document.getElementById(VendorTaxAmt).value;
        var vResaleTaxAmt = document.getElementById(ResaleTaxAmt).value;

        vNetAmt = Number.parseLocale(vNetAmt);
        vMarkupAmt = Number.parseLocale(vMarkupAmt);
        vVendorTaxAmt = Number.parseLocale(vVendorTaxAmt);
        vResaleTaxAmt = Number.parseLocale(vResaleTaxAmt);

        var vAmountApprovedField = document.getElementById(AmountApprovedField);

        var vAmountApproved = 0.000;

        vNetAmt = (vNetAmt * 1.000);
        vMarkupAmt = (vMarkupAmt * 1.000);
        vVendorTaxAmt = (vVendorTaxAmt * 1.000);
        vResaleTaxAmt = 0 // (vResaleTaxAmt * 1.000);  Per Ellen, do not include Resale tax

        vAmountApproved = vNetAmt + vMarkupAmt + vVendorTaxAmt; // + vResaleTaxAmt; Per Ellen, do not include Resale tax
        vAmountApproved = String.localeFormat("{0:n}", vAmountApproved);
        //vAmountApproved = vAmountApproved.toFixed(2);
        vAmountApprovedField.value = vAmountApproved;
    }
    catch (err) {
    }
}

function BACalculateApprovedAmtInput(QtyField, RateField, AmtField, NetAmtField, MarkupPctField, MarkupAmtField, VendorTaxAmtHiddenField, ResaleTaxAmtHiddenField, TaxAmtField) {
    //alert('BACalculateApprovedAmtInput');
    var vKey = window.event.keyCode;
    if (vKey != 9) //only if not TAB key
    {
        try {
            var x = document.getElementById(QtyField).value;
            var y = document.getElementById(AmtField).value;
            x = Number.parseLocale(x);
            y = Number.parseLocale(y);

            var z = 0.000;
            if (x != 0 && isNaN(x) == false)//only recalc the rate if quantity exists
            {
                if (isNaN(x) == false && isNaN(y) == false && x > 0) {
                    z = (y * 1.000) / (x * 1.000)

                    document.getElementById(RateField).value = String.localeFormat("{0:n}", z);
                }
                else {
                    document.getElementById(RateField).value = String.localeFormat("{0:n}", 0);
                };
            }
        }
        catch (err) {
        };
        document.getElementById(NetAmtField).value = String.localeFormat("{0:n}", 0);
        //document.getElementById(MarkupPctField).value = '0.00';
        document.getElementById(MarkupAmtField).value = String.localeFormat("{0:n}", 0);
        document.getElementById(VendorTaxAmtHiddenField).value = String.localeFormat("{0:n}", 0);
        document.getElementById(ResaleTaxAmtHiddenField).value = String.localeFormat("{0:n}", 0);
        document.getElementById(TaxAmtField).value = String.localeFormat("{0:n}", 0);
    };
};