<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Media_ATB.aspx.vb" Inherits="Webvantage.Media_ATB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content_MetdiaATB" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
       <style type="text/css">
        .w400 { 
            width:400px !important;
            min-width:400px !important;
            max-width:400px !important;
        }
        .RadForm_Bootstrap.RadForm.rfdTextbox input[type="text"].riTextBox  {
            height: 32px !important;
            padding: 0px 5px;
            vertical-align: middle;
            perspective-origin: 42.5px 16px;
            transform-origin: 42.5px 16px;
        }

    </style>
   <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">
        <script type="text/javascript">
            
            function stopRKey(evt) {
                var evt = (evt) ? evt : ((event) ? event : null);
                var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                if ((evt.keyCode == 13) && (node.type == "text")) {
                    return false;
                }
            }

            document.onkeypress = stopRKey;

            function RoundToFixed(num, numOfDecimals) {
                return Number(Math.round(num + 'e' + numOfDecimals) + 'e-' + numOfDecimals);
            }

            function JsRadToolbarEstimateOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "DeleteRev") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                } else if (comandName == "BuyGross" || comandName == "BuyNet") {
                    SetupBuyGrossOrNet();
                } else if (comandName == "Revise") {
                    var approved = document.getElementById('<%= ATBApproved.ClientID%>');
                    var otherapproved = document.getElementById('<%= ApprovedRevNum.ClientID%>');
                    if (approved.value == '1') {
                        ShowMessage('This revision is approved. The new revision must be approved in order to become the approved revision.');
                    } else if (otherapproved.value != '-1') {
                        ShowMessage("An earlier revision has been approved. The new revision must be approved in order to become the approved revision.");
                    }
                } else if (comandName == "Approval") {
                    var otherapproved = document.getElementById('<%= ApprovedRevNum.ClientID%>');
                    if (otherapproved.value != '-1') {
                        var atbNumber = document.getElementById('<%=  Hidden_ATBNumber.ClientID %>').value;
                        var revNumber = document.getElementById('<%=  Hidden_RevisionNumber.ClientID %>').value;
                        ShowMessage("Warning, approvals for ATB " + atbNumber + "/revision " + otherapproved.value + " will be deleted and ATB " + atbNumber + "/revision " + revNumber + " will be approved.");
                    }
                } else if (comandName == "Unapprove") {
                    ////args.set_cancel(!confirm('Are you sure you want to unapprove?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to unapprove?");
                } else if (comandName == 'AddAdServing' || comandName == 'SubtractAdServing') {
                    <%--var add = false;
                    if (comandName == 'AddAdServing') {
                        add = true;
                    }
                    var dataItems = $find('<%= RadGrid_ATBDetails.ClientID%>').get_masterTableView().get_dataItems();
                    calculating = true;
                    try{
                        for (var i = 0; i < dataItems.length; i++) {
                            var dataItem = dataItems[i];
                            var GrossBudgetInput = dataItem.findControl('RadNumericTextBox_GrossBudget');
                            var AmountInput = dataItem.findControl('RadNumericTextBox_Amount');
                            var AdServingInput = dataItem.findControl('RadNumericTextBox_NetChargeAmount');
                            var NetSpendInput = dataItem.findControl('RadNumericTextBox_NetSpend');
                            var MarkupAmountInput = dataItem.findControl('RadNumericTextBox_MarkupAmount');
                            var MarkupPercentInput = dataItem.findControl('RadNumericTextBox_MarkupPercent');
                            var TotalAmountInput = dataItem.findControl('RadNumericTextBox_TotalAmount');
                            var NetSpendValue = NetSpendInput.get_value();
                            var AdServingValue = AdServingInput.get_value();
                            var GrossBudgetAmount = GrossBudgetInput.get_value();
                            var Amount;
                            if (GrossBudgetAmount > 0) {
                                var Commission = GetProductCommission();
                                Amount = CalcAmountFromGrossBudget(GrossBudgetAmount, Commission);
                                if (add == false) {
                                    Amount = Amount - AdServingValue;
                                }
                            } else {
                                Amount = NetSpendValue;
                                if (add == false) {
                                    Amount = Amount - (2 * AdServingValue);
                                }
                            }
                            Amount = RoundToFixed(Amount, 2);
                            var commissionAmount = RoundToFixed(CalcCommissionAmount(Amount, null, MarkupPercentInput.get_value()), 2);
                            var netSpendValue = RoundToFixed(Amount + AdServingValue, 2);
                            AmountInput.set_value(Amount);
                            MarkupAmountInput.set_value(commissionAmount);
                            NetSpendInput.set_value(netSpendValue);
                            TotalAmountInput.set_value(netSpendValue + commissionAmount);
                        }
                    } catch (err) {

                    }
                    calculating = false;  --%>   
                }
            }
            function JsRadToolbarEstimateOnClientButtonClicked(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "BuyGross" || comandName == "BuyNet") {
                    SetupBuyGrossOrNet();
                }
            }
            function IsBuyGross() {
                var ToolBar = $find('<%= RadToolbar_MediaATB.ClientID%>');
                if (ToolBar.findItemByValue("Gross").get_checked() == true) {
                    return true;
                } else {
                    return false;
                }
            }
            function SetupBuyGrossOrNet() {
                var BuyGross = IsBuyGross();
                var ToolBar = $find('<%= RadToolbar_MediaATB.ClientID%>');
                try {
                    //var separator = ToolBar.findItemByValue("CalcOptionSeparator");
                    //var AddAdServingButton = ToolBar.findItemByValue("AddAdServing");
                    //var SubtractAdServingButton = ToolBar.findItemByValue("SubtractAdServing");
                    var radgrid = $find('<%= RadGrid_ATBDetails.ClientID%>');
                    var mastertable = radgrid.get_masterTableView();
                    var pctcol = mastertable.getColumnByUniqueName("MarkupPercent");
                    var amtcol = mastertable.getColumnByUniqueName("MarkupAmount");
                    var grossBudgetcol = 4;
                    var netamtcol = 10;
                    var inputamtcol = mastertable.getColumnByUniqueName("Amount");

                    if (BuyGross == true) {
                        inputamtcol.get_element().innerHTML = "Gross Amount";
                        pctcol.get_element().innerHTML = "Commission %";
                        amtcol.get_element().innerHTML = "Commission Amount";
                        mastertable.showColumn(netamtcol);
                        mastertable.hideColumn(grossBudgetcol);
                        //separator.hide();
                        //AddAdServingButton.hide();
                        //SubtractAdServingButton.hide();
                    } else {
                        inputamtcol.get_element().innerHTML = "Net Amount";
                        pctcol.get_element().innerHTML = "Markup %";
                        amtcol.get_element().innerHTML = "Markup Amount";
                        mastertable.hideColumn(netamtcol);
                        mastertable.showColumn(grossBudgetcol);
                        //separator.show();
                        //AddAdServingButton.show();
                        //SubtractAdServingButton.show();
                    }
                } catch (ex) {

                }
            }
            function ComboChanged(sender, args) {
                var si = args.get_item();
                var txt = si.get_value();
                sender.set_text(txt);
            }
            
            var calculating = false;

            function CalculateFields(quantity, rate, costtype, amount, commpct, commamt, netamt, netchargepct, netchargeamt,  netspend, total, grossBudget, vendorcommission, changed) {

                var BuyGross = IsBuyGross();

                if (calculating == false) {

                    try {

                        calculating = true;

                        var QuantityInput = $find(quantity);
                        var RateInput = $find(rate);
                        var CostTypeInput = $find(costtype);
                        var AmountInput = $find(amount);
                        var CommissionPctInput = $find(commpct);
                        var CommissionAmtInput = $find(commamt);
                        var NetAmtInput = $find(netamt);
                        var NetChargePctInput = $find(netchargepct);
                        var NetChargeAmtInput = $find(netchargeamt);
                        var NetSpendInput = $find(netspend);
                        var TotalInput = $find(total);
                        var GrossBudgetInput = $find(grossBudget);
                        var VendorCommissionCombo = $find(vendorcommission);

                        var QuantityValue = QuantityInput.get_value();
                        var RateValue = RateInput.get_value();
                        var CostTypeValue = CostTypeInput.get_value();
                        var AmountValue = AmountInput.get_value();
                        var CommissionPctValue = CommissionPctInput.get_value();
                        var CommissionAmtValue = CommissionAmtInput.get_value();
                        var NetChargePctValue = NetChargePctInput.get_value();
                        var NetChargeAmtValue = NetChargeAmtInput.get_value();
                        var GrossBudgetAmtValue = GrossBudgetInput.get_value();
                        var ProductCommissionValue = GetProductCommission();
                        var currentNetSpendValue = NetSpendInput.get_value();
                        var NetAmtValue;
                        var NetSpendValue;
                        var TotalInputValue;
                        var useCPM = false;
                        var recalcNetChargeAmtValue = true;
                        var ToolBar = $find('<%= RadToolbar_MediaATB.ClientID%>');
                        var subtractAdServing = false;

                        //if (ToolBar.findItemByValue("SubtractAdServing").get_checked() == true) {
                        //    subtractAdServing = true;
                        //}

                        if (GrossBudgetAmtValue && GrossBudgetAmtValue > 0) {
                            subtractAdServing = true;
                        }

                        if (CostTypeValue == "CPM") {
                            useCPM = true;
                        }

                        if (changed == "AMOUNT" || changed == "QUANTITY" || changed == "RATE" || changed == "COSTTYPE" || changed == "REFRESH") {
                            if (changed != "REFRESH") {
                                GrossBudgetAmtValue = null;
                            }
                            if (changed == "QUANTITY" || changed == "RATE" || changed == "COSTTYPE") {
                                if (QuantityValue && RateValue) {
                                    if (useCPM == true) {
                                        AmountValue = RoundToFixed(QuantityValue * (RateValue / 1000), 2);
                                    } else {
                                        AmountValue = RoundToFixed(QuantityValue * RateValue, 2);
                                    }
                                } else {
                                    AmountValue = 0;
                                }
                                changed = "REFRESH";
                            }
                        } else if (changed == "GROSSBUDGET") {
                            if (GrossBudgetAmtValue > 0) {
                                AmountValue = CalcAmountFromGrossBudget(GrossBudgetAmtValue, ProductCommissionValue);
                                if (BuyGross == false) {
                                    if (NetChargePctValue && NetChargePctValue > 0) {
                                        NetChargeAmtValue = RoundToFixed(CalcNetChargeAmount(BuyGross, AmountValue, CommissionAmtValue, NetChargePctValue), 2);
                                        AmountValue = RoundToFixed(AmountValue - NetChargeAmtValue, 2);
                                        recalcNetChargeAmtValue = false;
                                    }
                                }
                                changed = "REFRESH";
                            }
                        } else if (changed == "NETCHARGEPCT" || changed == "NETCHARGEAMT") {
                            if (BuyGross == false && subtractAdServing == true) {
                                if (GrossBudgetAmtValue && GrossBudgetAmtValue > 0) {
                                    AmountValue = RoundToFixed(CalcAmountFromGrossBudget(GrossBudgetAmtValue, ProductCommissionValue), 2);
                                } else {
                                    AmountValue = RoundToFixed(currentNetSpendValue, 2);
                                }
                                if (changed == "NETCHARGEPCT") {
                                    NetChargeAmtValue = RoundToFixed(CalcNetChargeAmount(BuyGross, AmountValue, CommissionAmtValue, NetChargePctValue), 2);
                                } else if (changed == "NETCHARGEAMT") {
                                    NetChargePctValue = RoundToFixed(CalcNetChargePct(BuyGross, AmountValue, CommissionAmtValue, NetChargeAmtValue), 4);
                                }
                                AmountValue = RoundToFixed(AmountValue - NetChargeAmtValue, 2);
                                recalcNetChargeAmtValue = false;
                                changed = "REFRESH";
                            }
                        }
                        
                        switch (changed) {

                            case "AMOUNT":
                            case "REFRESH":

                                if (QuantityValue && QuantityValue > 0) {
                                    RateValue = (AmountValue / QuantityValue);
                                    if(useCPM == true){
                                        RateValue = RateValue * 1000;
                                    }
                                    RateValue = RoundToFixed(RateValue, 4);
                                } else if (RateValue && RateValue > 0) {
                                    QuantityValue = (AmountValue / RateValue)
                                    if (useCPM == true) {
                                        QuantityValue = QuantityValue * 1000;
                                    }
                                    QuantityValue = RoundToFixed(QuantityValue, 0);
                                    if (RateValue * QuantityValue != AmountValue) {
                                        RateValue = (AmountValue / QuantityValue);
                                        if (useCPM == true) {
                                            RateValue = RateValue * 1000;
                                        }
                                        RateValue = RoundToFixed(RateValue, 4);
                                    }
                                } else {
                                    QuantityValue = null;
                                    RateValue = null;
                                }

                                if (BuyGross == false) {
                                    if (recalcNetChargeAmtValue == true) {
                                        NetChargeAmtValue = CalcNetChargeAmount(BuyGross, AmountValue, 0, NetChargePctValue);
                                    }
                                    CommissionAmtValue = CalcCommissionAmount(AmountValue, NetChargeAmtValue, CommissionPctValue);
                                } else {
                                    CommissionAmtValue = CalcCommissionAmount(AmountValue, 0, CommissionPctValue);
                                    if (recalcNetChargeAmtValue == true) {
                                        NetChargeAmtValue = CalcNetChargeAmount(BuyGross, AmountValue, CommissionAmtValue, NetChargePctValue);
                                    }
                                }
                                break;

                            case "COMMISSIONPCT":
                                if (BuyGross == true) {
                                    CommissionAmtValue = CalcCommissionAmount(AmountValue, 0, CommissionPctValue);
                                } else {
                                    CommissionAmtValue = CalcCommissionAmount(AmountValue, NetChargeAmtValue, CommissionPctValue);
                                }
                                break;

                            case "COMMISSIONAMT":
                                if (BuyGross == true) {
                                    CommissionPctValue = CalcCommissionPct(AmountValue, CommissionAmtValue);
                                } else {
                                    CommissionPctValue = CalcCommissionPct(AmountValue + NetChargeAmtValue, CommissionAmtValue);
                                }                                
                                break;

                            case "NETCHARGEPCT":
                                if (BuyGross == true) {
                                    NetChargeAmtValue = CalcNetChargeAmount(BuyGross, AmountValue, CommissionAmtValue, NetChargePctValue);
                                } else {
                                    NetChargeAmtValue = CalcNetChargeAmount(BuyGross, AmountValue, CommissionAmtValue, NetChargePctValue);
                                    CommissionAmtValue = CalcCommissionAmount(AmountValue, NetChargeAmtValue, CommissionPctValue);
                                }
                                break;

                            case "NETCHARGEAMT":
                                if (BuyGross == true) {
                                    NetChargePctValue = CalcNetChargePct(BuyGross, CalcAmountFromGrossBudget(AmountValue, ProductCommissionValue), CommissionAmtValue, NetChargeAmtValue);
                                } else {
                                    NetChargePctValue = CalcNetChargePct(BuyGross, AmountValue, CommissionAmtValue, NetChargeAmtValue);
                                    CommissionAmtValue = CalcCommissionAmount(AmountValue, NetChargeAmtValue, CommissionPctValue);
                                }
                                break;
                        }

                        var nonNullAmountValue = AmountValue;
                        var nonNullCommissionAmtValue = CommissionAmtValue;
                        var nonNullNetAmtValue = NetAmtValue;
                        var nonNullNetChargeAmtValue = NetChargeAmtValue;

                        if (!nonNullAmountValue) {
                            nonNullAmountValue = 0;
                        }
                        if (!nonNullCommissionAmtValue) {
                            nonNullCommissionAmtValue = 0;
                        }
                        if (!nonNullNetAmtValue) {
                            nonNullNetAmtValue = 0;
                        }
                        if (!nonNullNetChargeAmtValue) {
                            nonNullNetChargeAmtValue = 0;
                        }

                        if (BuyGross == true) {
                            NetAmtValue = RoundToFixed(nonNullAmountValue - nonNullCommissionAmtValue, 2);
                            NetSpendValue = RoundToFixed(NetAmtValue + nonNullNetChargeAmtValue, 2);
                            TotalInputValue = RoundToFixed(nonNullAmountValue + nonNullNetChargeAmtValue, 2);
                        } else {
                            NetAmtValue = null;
                            NetSpendValue = RoundToFixed(nonNullAmountValue + nonNullNetChargeAmtValue, 2);
                            TotalInputValue = RoundToFixed(NetSpendValue + nonNullCommissionAmtValue, 2);
                        }

                        QuantityInput.set_value(QuantityValue);
                        RateInput.set_value(RateValue);
                        GrossBudgetInput.set_value(GrossBudgetAmtValue);
                        AmountInput.set_value(AmountValue);
                        CommissionPctInput.set_value(CommissionPctValue);
                        CommissionAmtInput.set_value(CommissionAmtValue);
                        NetAmtInput.set_value(NetAmtValue);
                        NetChargePctInput.set_value(NetChargePctValue);
                        NetChargeAmtInput.set_value(NetChargeAmtValue);
                        NetSpendInput.set_value(NetSpendValue);
                        TotalInput.set_value(TotalInputValue);

                    } catch (ex) {

                    }
                    
                    CalcTotals()
                    calculating = false;
                }

            }

            function CalcNetChargeAmount(buyGross, amount, commissionAmount, netChargePercent) {
                var NetChargeAmtValue;
                amount = RoundToFixed(amount, 2);
                commissionAmount = RoundToFixed(commissionAmount, 2);
                netChargePercent = RoundToFixed(netChargePercent, 4);
                try {
                    if (buyGross == true) {
                        NetChargeAmtValue = RoundToFixed((amount - commissionAmount) * (netChargePercent / 100), 2);
                    } else {
                        NetChargeAmtValue = RoundToFixed(amount * (netChargePercent / 100), 2);
                    }
                } catch (err) {
                    NetChargeAmtValue = null;
                }
                return NetChargeAmtValue;
            }
            function CalcNetChargePct(buyGross, amount, commissionAmount, netChargeAmount) {
                var NetChargePctValue;
                amount = RoundToFixed(amount, 2);
                commissionAmount = RoundToFixed(commissionAmount, 2);
                netChargeAmount = RoundToFixed(netChargeAmount, 2);
                try{
                    if (buyGross == true) {
                        NetChargePctValue = RoundToFixed((netChargeAmount / (amount - commissionAmount)) * 100, 4);
                    } else {
                        NetChargePctValue = RoundToFixed((netChargeAmount / amount) * 100, 4);
                    }
                } catch (err) {
                    NetChargePctValue = null;
                }
                return NetChargePctValue;
            }
            function CalcCommissionPct(amount, commissionAmount) {
                var commissionPct;
                commissionAmount = RoundToFixed(commissionAmount, 2);
                try{
                    commissionPct = RoundToFixed((commissionAmount / amount) * 100, 4);
                } catch (err) {
                    commissionPct = null;
                }
                return commissionPct;
            }
            function CalcCommissionAmount(amount, netChargeAmount, commissionPct) {
                var commissionAmount;
                var netAmt;
                if (!amount) {
                    amount = 0;
                }
                if (!netChargeAmount) {
                    netChargeAmount = 0;
                }
                netAmt = amount + netChargeAmount;
                commissionPct = RoundToFixed(commissionPct, 4);
                try {
                    commissionAmount = RoundToFixed(netAmt * (commissionPct / 100), 2);
                } catch (err) {
                    commissionAmount = null;
                }
                return commissionAmount;
            }
            function CalcAmountFromGrossBudget(GrossBudgetAmount, VendorCommission) {
                return RoundToFixed(GrossBudgetAmount - (GrossBudgetAmount * (VendorCommission / 100)), 2);
            }
            function GetProductCommission() {
                var productCommission;
                try{
                    productCommission = document.getElementById('<%= HiddenFieldProductCommission.ClientID%>').value;
                } catch (err) {

                }
                if (isNaN(productCommission)) {
                    productCommission = 15;
                }
                return parseFloat(productCommission);
            }
            function CalcTotals() {

                var grid = $find('<%= RadGrid_ATBDetails.ClientID%>');
                var mastertable = grid.get_masterTableView();
                var items = mastertable.get_dataItems();
                var total = 0;
                var totalnet = 0;
                var totalAd = 0;
                var totalMarkup = 0;
                var totalAmount = 0;
                var totalNetAmount = 0;
                var grossBudgetAmount = 0;
                var BuyGross = false;
                
                for (i = 0; i < items.length; i++) {
                    var item = items[i];
                    if (item) {
                        var grossBudgetAmountControl = item.findControl('RadNumericTextBox_GrossBudget');
                        if (grossBudgetAmountControl) {
                            if (!isNaN(parseFloat(grossBudgetAmountControl.get_value()))) {
                                grossBudgetAmount = grossBudgetAmount + RoundToFixed(grossBudgetAmountControl.get_value(), 2);
                            }
                        }
                        var itemTotalControl = item.findControl('RadNumericTextBox_TotalAmount');
                        if (itemTotalControl) {
                            if (!isNaN(parseFloat(itemTotalControl.get_value()))) {
                                total = total + RoundToFixed(itemTotalControl.get_value(), 2);
                            }
                        }
                        var itemTotalNetControl = item.findControl('RadNumericTextBox_NetSpend');
                        if (itemTotalNetControl) {
                            if (!isNaN(parseFloat(itemTotalNetControl.get_value()))) {
                                totalnet = totalnet + RoundToFixed(itemTotalNetControl.get_value(), 2);
                            }
                        }
                        var itemTotalNetAmountControl = item.findControl('RadNumericTextBox_NetAmount');
                        if (itemTotalNetAmountControl) {
                            if (!isNaN(parseFloat(itemTotalNetAmountControl.get_value()))) {
                                totalNetAmount = totalNetAmount + RoundToFixed(itemTotalNetAmountControl.get_value(), 2);
                            }
                        }
                        var itemAdControl = item.findControl("RadNumericTextBox_NetChargeAmount");
                        if (itemAdControl) {
                            if (!isNaN(parseFloat(itemAdControl.get_value()))) {
                                totalAd = totalAd + RoundToFixed(itemAdControl.get_value(), 2);
                            }
                        }
                        var itemMarkupControl = item.findControl("RadNumericTextBox_MarkupAmount");
                        if (itemMarkupControl) {
                            if (!isNaN(parseFloat(itemMarkupControl.get_value()))) {
                                totalMarkup = totalMarkup + RoundToFixed(itemMarkupControl.get_value(), 2);
                            }
                        }
                        var itemAmountControl = item.findControl("RadNumericTextBox_Amount");
                        if (itemAmountControl) {
                            if (!isNaN(parseFloat(itemAmountControl.get_value()))) {
                                totalAmount = totalAmount + RoundToFixed(itemAmountControl.get_value(), 2);
                            }
                        }
                    }
                }

                var TotalAmountControl = $find('<%= RadGrid_ATBDetails.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer).First.FindControl("RadNumericTextBoxFooter_TotalAmount").ClientID%>');
                var NetSpendControl = $find('<%= RadGrid_ATBDetails.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer).First.FindControl("RadNumericTextBoxFooter_NetSpend").ClientID%>');
                var NetChargeAmountControl = $find('<%= RadGrid_ATBDetails.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer).First.FindControl("RadNumericTextBoxFooter_NetChargeAmount").ClientID%>');
                var MarkupAmountControl = $find('<%= RadGrid_ATBDetails.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer).First.FindControl("RadNumericTextBoxFooter_MarkupAmount").ClientID%>');
                var AmountControl = $find('<%= RadGrid_ATBDetails.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer).First.FindControl("RadNumericTextBoxFooter_Amount").ClientID%>');
                var NetAmountControl = $find('<%= RadGrid_ATBDetails.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer).First.FindControl("RadNumericTextBoxFooter_NetAmount").ClientID%>');
                var GrossBudgetControl = $find('<%= RadGrid_ATBDetails.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer).First.FindControl("RadNumericTextBoxFooter_GrossBudget").ClientID%>');

                if (GrossBudgetControl) {
                    GrossBudgetControl.set_value(grossBudgetAmount);
                }
                if (TotalAmountControl) {
                    TotalAmountControl.set_value(total);
                }
                if (NetSpendControl) {
                    NetSpendControl.set_value(totalnet);
                }
                if (NetChargeAmountControl) {
                    NetChargeAmountControl.set_value(totalAd);
                }
                if (MarkupAmountControl) {
                    MarkupAmountControl.set_value(totalMarkup);
                }
                if (AmountControl) {
                    AmountControl.set_value(totalAmount);
                }
                if (NetAmountControl) {
                    NetAmountControl.set_value(totalNetAmount);
                }

            }

            $(document).ready(function () {

                CalcTotals();
                SetupBuyGrossOrNet();

            });

        </script>
    </telerik:RadScriptBlock>

     <div >
        <telerik:RadToolBar ID="RadToolbar_MediaATB" runat="server" AutoPostBack="true" OnClientButtonClicked="JsRadToolbarEstimateOnClientButtonClicked" OnClientButtonClicking="JsRadToolbarEstimateOnClientButtonClicking"
            Width="100%" TabIndex="20">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" Text="" Value="SaveAll"
                    CommandName="SaveAll" ToolTip="Save ATB" SkinID="RadToolBarButtonSave" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSearch" runat="server" Text="Search" Value="Search"
                    CommandName="Search" ToolTip="ATB Search" SkinID="RadToolBarButtonFind" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonNewATB" runat="server" Text="New ATB" Value="NewATB"
                    CommandName="NewATB" ToolTip="Add New ATB" SkinID="RadToolBarButtonNew" />
                <telerik:RadToolBarButton ID="RadToolBarButtonRevise" runat="server" Text="New Revision" Value="Revise"
                    CommandName="Revise" ToolTip="Increment Revision Number on this Order" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonDelete" runat="server" Text="Delete Revision" Value="DeleteRev"
                    CommandName="DeleteRev" ToolTip="Delete Revision"  />
                <telerik:RadToolBarButton ID="RadToolBarButtonDeleteRevisionSeparator" runat="server" IsSeparator="true" />                
                <telerik:RadToolBarButton ID="RadToolBarButtonBuyNet" runat="server" Text="Buy Net" Value="Net"
                    CommandName="BuyNet" ToolTip="Buy Net" Group="abc" CheckOnClick="true" PostBack="true" AllowSelfUnCheck="false" />
                <telerik:RadToolBarButton ID="RadToolBarButtonBuyGross" runat="server" Text="Buy Gross" Value="Gross"
                    CommandName="BuyGross" ToolTip="Buy Gross" Group="abc" CheckOnClick="true"  PostBack="true" AllowSelfUnCheck="false" />
                <%--<telerik:RadToolBarButton IsSeparator="true" ID="RadToolBarButtonCalcOptionSeparator" Value="CalcOptionSeparator" runat="server" />
                <telerik:RadToolBarButton ID="RadToolBarButtonAddAdServing" runat="server" Text="Add Ad Serving" Value="AddAdServing"
                    CommandName="AddAdServing" ToolTip="Add Ad Serving" Group="AdServingCalc" CheckOnClick="true" PostBack="true" AllowSelfUnCheck="false" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSubtractAdServing" runat="server" Text="Subtract Ad Serving" Value="SubtractAdServing"
                    CommandName="SubtractAdServing" ToolTip="Subtract Ad Serving" Group="AdServingCalc" CheckOnClick="true" PostBack="true" AllowSelfUnCheck="false" />--%>
                <telerik:RadToolBarButton IsSeparator="true" />                
                <telerik:RadToolBarButton SkinID="RadToolBarButtonAlerts" Text="" Value="Alerts" ToolTip="Alerts" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarDropDown Text="Print/Send">
                    <Buttons>
                        <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print" />
                        <telerik:RadToolBarButton Text="Send Alert" Value="SendAlert" ToolTip="Send Alert" />
                        <telerik:RadToolBarButton Text="Send Assignment" Value="SendAssignment" ToolTip="Send Assignment" />
                        <telerik:RadToolBarButton Text="Send Email" Value="SendEmail" ToolTip="Send Email" />
                        <telerik:RadToolBarButton Text="Options" Value="PrintSendOptions" ToolTip="Print/Send Options" />
                    </Buttons>
                </telerik:RadToolBarDropDown>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonApproval" runat="server" Text="Approve" Value="Approval" 
                    CommandName="Approval" ToolTip="Get Approval for this Order"  />
                <telerik:RadToolBarButton ID="RadToolBarButtonUnApprove" runat="server" Text="Unapprove" Value="Unapprove"
                    CommandName="Unapprove" ToolTip="Remove Approval for this Order"   />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" Text="Close ATB" Value="CancelATB"
                    CommandName="CancelATB" ToolTip="Close ATB" />
                <telerik:RadToolBarButton ID="RadToolBarButtonUnCancel" runat="server" Text="Re-Open ATB" Value="UnCancelATB"
                    CommandName="UnCancelATB" ToolTip="Re-Open ATB" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCreateOrder" runat="server" Text="Create Orders" Value="CreateOrder" 
                    CommandName="CreateOrder" ToolTip="Create Orders"  />
                <telerik:RadToolBarButton ID="RadToolBarButtonOrderDetail" runat="server" Text="View Order Details" Value="ViewOrderDetail" 
                    CommandName="ViewOrderDetail" ToolTip="View Order Detail" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>    
    <div >
    </div>

    <br />
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr ID="TrApproved" runat="server">
            <td colspan="2" align="right">
                <asp:Label ID="Label_Approved" runat="server" CssClass="RUSH" Font-Size="X-Large" Font-Bold="true" Text="APPROVED&nbsp;&nbsp;" Visible="true"></asp:Label>
            </td>
        </tr>
        <tr ID="TrOrdered" runat="server">
            <td colspan="2" align="right">
                <asp:Label ID="Label_OrderedStatus" runat="server" CssClass="RUSH" Font-Size="X-Large" Font-Bold="true" Text="ORDERED&nbsp;&nbsp;" Visible="true"></asp:Label>
            </td>
        </tr>
        <tr ID="TrClosed" runat="server">
            <td colspan="2" align="right">
                <asp:Label ID="Label_Canceled" runat="server" CssClass="RUSH" Font-Size="X-Large" Font-Bold="true" Text="CLOSED&nbsp;&nbsp;" Visible="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="50%">
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>ATB Number: </span>
                        </td>
                        <td width="2%">&nbsp;
                        </td>
                        <td width="70%">
                            <div style="display: block;" >
                                <asp:TextBox ID="TextBox_ATBNumber" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSmall"
                                    MaxLength="6" ReadOnly="true"></asp:TextBox>&nbsp;
                                <asp:TextBox ID="TextBox_ATBDescription" runat="server" ReadOnly="false" TabIndex="1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription" CssClass="RequiredInput"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="5"></td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Revision: </span>
                        </td>
                        <td width="2%">&nbsp;
                        </td>
                        <td width="70%">
                            <div style="display: block;" >
                                <telerik:RadComboBox ID="RadComboBox_Revision" runat="server" Width="100px" AutoPostBack="true" TabIndex="2" OnSelectedIndexChanged="RadComboBox_Revision_SelectedIndexChanged"  SkinID="RadComboBoxStandard">

                                </telerik:RadComboBox>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top" width="50%">
                <span>Date of Request:</span>&nbsp;&nbsp;
                <telerik:RadDatePicker ID="RadDatePicker_DateOfRequest" runat="server" 
                     SkinID="RadDatePickerStandard" TabIndex="3">
                    <DatePopupButton ToolTip="Show Calendar" />
                    <DateInput DateFormat="d" EmptyMessage="" runat="server">
                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                    </DateInput>
                    <Calendar ID="DateOfRequest_Calendar" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                        <SpecialDays>
                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                            </telerik:RadCalendarDay>
                        </SpecialDays>
                    </Calendar>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="50%">
                <br />
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Client: </span>
                        </td>
                        <td width="2%">&nbsp;
                        </td>
                        <td width="70%">
                            <div style="display: block;" >
                                <asp:TextBox ID="TextBox_ClientCode" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSmall"
                                    MaxLength="6" ReadOnly="true"></asp:TextBox>&nbsp;
                                <asp:TextBox ID="TextBox_ClientDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">
                            <span>Division:</span>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <div style="display: block;" >
                                <asp:TextBox ID="TextBox_DivisionCode" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSmall"
                                    MaxLength="6" ReadOnly="true"></asp:TextBox>&nbsp;
                                <asp:TextBox ID="TextBox_DivisionDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">
                            <span>Product:</span>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <div style="display: block;" >
                                <asp:TextBox ID="TextBox_ProductCode" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSmall"
                                    MaxLength="6" ReadOnly="true"></asp:TextBox>&nbsp;
                                <asp:TextBox ID="TextBox_ProductDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px;"></td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span><asp:HyperLink ID="Hyperlink_Campaign" runat="server" href="" Visible="false">Campaign:</asp:HyperLink>Campaign: </span>
                        </td>
                        <td width="2%">&nbsp;
                        </td>
                        <td width="70%">
                            <div style="display: block;" >
                                <telerik:RadComboBox ID="RadComboBox_Campaign" runat="server" TabIndex="4" Width="375px" AutoPostBack="true" OnSelectedIndexChanged="RadComboBox_Campaign_SelectedIndexChanged" SkinID="RadComboBoxStandard">

                                </telerik:RadComboBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px;"></td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">
                            <span>Beginning Date:</span>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="RadDatePicker_CampaignBeginningDate" runat="server"   SkinID="RadDatePickerStandard" TabIndex="5">
                                <DatePopupButton ToolTip="Show Calendar" />
                                <DateInput DateFormat="d" EmptyMessage="" runat="server" CssClass="RequiredInput">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="Calendar_CampaignBeginningDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px;"></td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">
                            <span>Ending Date:</span>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="RadDatePicker_CampaignEndingDate" runat="server"   SkinID="RadDatePickerStandard" TabIndex="6">
                                <DatePopupButton ToolTip="Show Calendar" />
                                <DateInput DateFormat="d" EmptyMessage="" runat="server" CssClass="RequiredInput">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="Calendar_CampaignEndingDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px;"></td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">
                            <span>Client Budget:</span>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="RadTextBox_ClientBudget" runat="server" Width="150px" TabIndex="7" ShowSpinButtons="false" NumberFormat-DecimalDigits="2"></telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px;"></td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle">
                            <span>Sales Class: </span>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <div style="display: block;" >
                                <telerik:RadComboBox ID="RadComboBox_SalesClass" runat="server" TabIndex="8" Width="375px" AutoPostBack="false" SkinID="RadComboBoxStandard">

                                </telerik:RadComboBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 5px;"></td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Comments:</span>
                        </td>
                        <td width="2%">&nbsp;
                        </td>
                        <td width="70%">
                            <div style="display: block;" >
                                <asp:TextBox ID="TextBox_Comments" runat="server" Height="90px" Text="" TextMode="MultiLine" Width="375" ReadOnly="false" TabIndex="9" SkinID="TextBoxStandard"></asp:TextBox>
                                        
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" valign="top" width="50%">
                <br />
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td colspan="3">
                            <fieldset style="width:80%;">
                                <legend>Billing Information</legend>
                                <div>
                                    <table align="center" border="0" cellpadding="0" cellspacing="5" width="100%">
                                        <tr>
                                            <td align="right" valign="middle" width="22%">Comments:</td>
                                            <td width="2%">&nbsp;</td>
                                            <td width="76%">
                                                <asp:TextBox ID="TextBox_BillingComment" runat="server" TabIndex="10" Text="" Width="95%" TextMode="MultiLine" Height="70px" SkinID="TextBoxStandard"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle">Date to Bill:</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <telerik:RadDatePicker ID="RadDatePicker_DateToBill" runat="server"   SkinID="RadDatePickerStandard" TabIndex="11">
                                                    <DatePopupButton ToolTip="Show Calendar" />
                                                    <DateInput DateFormat="d" EmptyMessage="" runat="server">
                                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                    </DateInput>
                                                    <Calendar ID="Calendar_DateToBill" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                        <SpecialDays>
                                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                            </telerik:RadCalendarDay>
                                                        </SpecialDays>
                                                    </Calendar>
                                                </telerik:RadDatePicker>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle">Client PO:</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="TextBox_ClientPO" runat="server" Text="" Width="225px" SkinID="TextBoxStandard"
                                                    MaxLength="25" TabIndex="12"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <telerik:RadButton ID="RadButton_BillCommissionOnly" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" Text="Bill Commission Only" AutoPostBack="false" TabIndex="13"></telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle">Billing Method:</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <telerik:RadComboBox ID="RadComboBox_BillingMethod" runat="server" AllowCustomText="false" TabIndex="14" Width="220" SkinID="RadComboBoxStandard">
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                                    
                        </td>
                        <td>&nbsp;
                        </td>
                        <td>
                            <div style="display: block;" >
                                        
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td width="10"></td>
                        <td>
                            <telerik:RadGrid ID="RadGrid_ATBDetails" runat="server" AllowMultiRowSelection="true" AutoGenerateColumns="false" GridLines="None" Width="100%" ShowFooter="true" TabIndex="15">
                                <MasterTableView AutoGenerateColumns="false" Width="100%" EditMode="InPlace" DataKeyNames="DetailID" ShowFooter="true" TabIndex="16">
                                    <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                    <Columns>
                                        <telerik:GridTemplateColumn DataField="VendorCode" HeaderText="Vendor" UniqueName="VendorCode">
                                            <ItemTemplate>
                                                <telerik:RadComboBox ID="RadComboBox_Vendor" runat="server" EnableLoadOnDemand="true" Width="100" Height="150" DropDownWidth="300px" ShowMoreResultsBox="true" InputCssClass="no-border"
                                                    OnItemsRequested="RadComboBox_Vendor_ItemsRequested" OnTextChanged="RadComboBox_Vendor_TextChanged" Filter="Contains" AutoPostBack="true" SkinID="RadComboBoxStandard"
                                                    OnClientSelectedIndexChanged="ComboChanged" CssClass="RequiredInput">

                                                </telerik:RadComboBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Quantity" HeaderText="Quantity" UniqueName="Quantity">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_Quantity" runat="server" Width="85" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="0"  />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Rate" HeaderText="Rate" UniqueName="Rate">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_Rate" runat="server" Width="85" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="4"  />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="CostType" HeaderText="Cost Type" UniqueName="CostType">
                                            <ItemTemplate>
                                                <telerik:RadComboBox ID="RadComboBox_CostType" runat="server" Width="115" InputCssClass="no-border" SkinID="RadComboBoxStandard">
                                                </telerik:RadComboBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="GrossBudget" HeaderText="Gross Budget" UniqueName="GrossBudget">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_GrossBudget" runat="server" Width="115" ShowSpinButtons="false" MaxValue="99999999.99">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2"  />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxFooter_GrossBudget" runat="server" Width="115" ShowSpinButtons="false" ReadOnly="true" Font-Bold="true" BackColor="Transparent" BorderWidth="0">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2"  />
                                                </telerik:RadNumericTextBox>
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Amount" HeaderText="Amount" UniqueName="Amount">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_Amount" runat="server" Width="115" ShowSpinButtons="false" MaxValue="99999999.99">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2"  />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxFooter_Amount" Font-Bold="true" BackColor="Transparent" BorderWidth="0" ReadOnly="true" runat="server" Width="115" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="NetChargePercent" HeaderText="Ad Serving %" UniqueName="NetChargePercent" >
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_NetChargePercent" runat="server" Width="100" ShowSpinButtons="false" MaxValue="9999.9999">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="4" />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="NetChargeAmount" HeaderText="Ad Serving Amount" UniqueName="NetChargeAmount" >
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_NetChargeAmount" runat="server" Width="115" ShowSpinButtons="false" MaxValue="99999999.99">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxFooter_NetChargeAmount" Font-Bold="true" BackColor="Transparent" BorderWidth="0" ReadOnly="true" runat="server" Width="115" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="MarkupPercent" HeaderText="Markup %" UniqueName="MarkupPercent" >
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_MarkupPercent" runat="server" Width="100" ShowSpinButtons="false" MaxValue="9999.9999" BackColor="Transparent" BorderWidth="0" ReadOnly="true">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="4" />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="MarkupAmount" HeaderText="Markup Amount" UniqueName="MarkupAmount" >
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_MarkupAmount" runat="server" Width="115" ShowSpinButtons="false" MaxValue="99999999.99" BackColor="Transparent" BorderWidth="0" ReadOnly="true">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxFooter_MarkupAmount" Font-Bold="true" BackColor="Transparent" BorderWidth="0" ReadOnly="true" runat="server" Width="115" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Net Amount" UniqueName="GridTemplateColumnNetAmount" >
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_NetAmount" Font-Bold="true" BackColor="Transparent" BorderWidth="0" ReadOnly="true" runat="server" Width="115" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxFooter_NetAmount" Font-Bold="true" BackColor="Transparent" BorderWidth="0" ReadOnly="true" runat="server" Width="115" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="NetSpend" HeaderText="Net Spend" UniqueName="NetSpend">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_NetSpend" Font-Bold="true" BackColor="Transparent" BorderWidth="0" ReadOnly="true" runat="server" Width="115" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxFooter_NetSpend" Font-Bold="true" BackColor="Transparent" BorderWidth="0" ReadOnly="true" runat="server" Width="115" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="TotalAmount" HeaderText="Total Amount" UniqueName="TotalAmount"  >
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBox_TotalAmount" Font-Bold="true" BackColor="Transparent" BorderWidth="0" ReadOnly="true" runat="server" Width="115" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxFooter_TotalAmount" Font-Bold="true" BackColor="Transparent" BorderWidth="0" ReadOnly="true" runat="server" Width="115" ShowSpinButtons="false">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <HoveredStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits="2" />
                                                </telerik:RadNumericTextBox>
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="ItemOrdered" HeaderText="Ordered"  >
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div id="DivOrderedIndicator" runat="server" class="icon-background standard-green">
                                                    <asp:Image ID="ImageOrderedIndicator" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                                </div>
                                            </ItemTemplate>
                                            <InsertItemTemplate>

                                            </InsertItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_Save">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div id="DivSaveButton" runat="server" class="icon-background background-color-sidebar">
                                                    <asp:ImageButton ID="ImageButton_Save" runat="server" AlternateText="Save" CommandName="Save"
                                                            CommandArgument='<%#Eval("DetailID")%>' ToolTip="Save" ImageAlign="AbsMiddle"
                                                            SkinID="ImageButtonSaveWhite" />
                                                </div>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ImageButton_Add" runat="server" AlternateText="Add Item" CommandName="AddItem"
                                                            ToolTip="Add Item" ImageAlign="AbsMiddle"
                                                            SkinID="ImageButtonNewWhite" />
                                                    </div>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_Delete">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemTemplate>
                                                    <div id="DivDeleteButton" runat="server" class="icon-background background-color-delete">
                                                        <asp:ImageButton ID="ImageButton_Delete" runat="server" AlternateText="Delete" CommandName="Delete"
                                                            CommandArgument='<%#Eval("DetailID")%>' ToolTip="Delete" SkinID="ImageButtonDeleteWhite" />
                                                    </div>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ImageButton_Cancel" runat="server" AlternateText="Cancel" CommandName="CancelItem"
                                                            ToolTip="Cancel add row" SkinID="ImageButtonCancelWhite" />
                                                    </div>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                        <td width="10"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />

    <asp:HiddenField ID="Hidden_ATBNumber" Value="0" runat="server" />
    <asp:HiddenField ID="Hidden_RevisionNumber" Value="0" runat="server" />
    <asp:HiddenField ID="ATBApproved" Value="0" runat="server" />
    <asp:HiddenField ID="ApprovedRevNum" Value="-1" runat="server" />
    <asp:HiddenField ID="HiddenFieldMediaOrderCreated" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenFieldProductCommission" Value="0" runat="server" />

</asp:Content>
