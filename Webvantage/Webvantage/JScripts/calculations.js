var qtyRateAmtCalc = new quantityRateAmountCalculator(0, 4, 2); // defaults

function quantityRateAmountCalculator(quantityDecimals, rateDecimals, amountDecimals) {

    this.isRunning = false;
    this.quantityDecimals = quantityDecimals; // int
    this.rateDecimals = rateDecimals; // int
    this.amountDecimals = amountDecimals; // int
    this.quantityRadNumericInput = null; //telerik.web.ui.radnumericinput
    this.rateRadNumericInput = null; //telerik.web.ui.radnumericinput
    this.amountRadNumericInput = null; //telerik.web.ui.radnumericinput
    this.radGrid = null; // telerik.web.ui.RadGrid
    this.gridDataItem = null; //telerik.web.ui.GridDataItem
    this.quantityColumn = null; // telerik.web.ui.GridColumn
    this.rateColumn = null; // telerik.web.ui.GridColumn
    this.amountColumn = null; // telerik.web.ui.GridColumn

    this.getIsRunning = function () {
        return this.isRunning;
    }
    this.setQuantityDecimals = function (decimals) {
        this.quantityDecimals = decimals;
    }
    this.setRateDecimals = function (decimals) {
        this.rateDecimals = decimals;
    }
    this.setAmountDecimals = function (decimals) {
        this.amountDecimals = decimals;
    }
    this.setQuantityRadNumericInput = function (input) {
        this.quantityRadNumericInput = input;
    }
    this.setRateRadNumericInput = function (input) {
        this.rateRadNumericInput = input;
    }
    this.setAmountRadNumericInput = function (input) {
        this.amountRadNumericInput = input;
    }

    this.setRadGrid = function (radGrid, qtyColumnName, rateColumnName, amtColumnName) {
        this.radGrid = radGrid;
        if (this.radGrid) {
            this.quantityColumn = radGrid.get_masterTableView().getColumnByUniqueName(qtyColumnName);
            this.rateColumn = radGrid.get_masterTableView().getColumnByUniqueName(rateColumnName);
            this.amountColumn = radGrid.get_masterTableView().getColumnByUniqueName(amtColumnName);
        } else {
            this.quantityColumn = null;
            this.rateColumn = null;
            this.amountColumn = null;
        }
    }
    this.setGridDataItem = function (gridDataItem) {
        if (this.radGrid) {
            this.gridDataItem = gridDataItem;
            if (this.quantityColumn) {
                this.setQuantityRadNumericInput(getRadNumericTextBoxFromGridColumn(gridDataItem, this.quantityColumn));
            }
            if (this.rateColumn) {
                this.setRateRadNumericInput(getRadNumericTextBoxFromGridColumn(gridDataItem, this.rateColumn));
            }
            if (this.amountColumn) {
                this.setAmountRadNumericInput(getRadNumericTextBoxFromGridColumn(gridDataItem, this.amountColumn));
            }
        } else {
            this.gridDataItem = null;
        }
    }
    
    /*
    Changed
    --------
    1 = Quantity
    2 = Rate
    3 = Amount
    */
    this.calculateGridDataItem = function (changed, cpm) {
        var results;
        if (this.gridDataItem) {
            var qty, rate, amt;
            if (this.quantityRadNumericInput) {
                qty = this.quantityRadNumericInput.get_value();
            }
            if (this.rateRadNumericInput) {
                rate = this.rateRadNumericInput.get_value();
            }
            if (this.amountRadNumericInput) {
                amt = this.amountRadNumericInput.get_value();
            }
            results = this.calculate(qty, rate, amt, changed, cpm);
            return results;
        }
    }
    this.calculate = function (qty, rate, amt, changed, cpm) {
        if (this.getIsRunning() == false) {
            this.isRunning = true;
            try{
                if (changed == 1 || changed == 2) {
                    if (qty && rate) {
                        amt = this.calcAmount(qty, rate, this.amountDecimals, cpm);
                    } else if (!qty && rate) {
                        qty = this.calcQty(rate, amt, this.quantityDecimals, cpm);
                        if (this.calcAmount(qty, rate, this.amountDecimals, cpm) != amt) {
                            rate = this.calcRate(qty, amt, this.rateDecimals, cpm);
                        }
                    } else if (!rate && qty && !isNaN(qty) && Number(qty) != 0) {
                        rate = this.calcRate(qty, amt, this.rateDecimals, cpm);
                    }
                } else if (changed == 3) {
                    if (qty && !isNaN(qty) && Number(qty) > 0) {
                        rate = this.calcRate(qty, amt, this.rateDecimals, cpm);
                    } else if (rate && !isNaN(rate) && Number(rate) > 0) {
                        qty = this.calcQty(rate, amt, this.quantityDecimals, cpm);
                        if (this.calcAmount(qty, rate, this.amountDecimals, cpm) != amt) {
                            rate = this.calcRate(qty, amt, this.rateDecimals, cpm);
                        }
                    } else {
                        qty = null;
                        rate = null;
                    }
                }
                if (isNaN(qty)) {
                    qty = Number(qty.replace(/,/g, ""));
                }
                if (isNaN(rate)) {
                    rate = Number(rate.replace(/,/g, ""));
                }
                if (isNaN(amt)) {
                    amt = Number(amt.replace(/,/g, ""));
                }
                var results = {
                    qty: Number(qty),
                    rate: Number(rate),
                    amt: Number(amt)
                };
                if (this.quantityRadNumericInput) {
                    this.quantityRadNumericInput.set_value(results.qty);
                }
                if (this.rateRadNumericInput) {
                    this.rateRadNumericInput.set_value(results.rate);
                }
                if (this.amountRadNumericInput) {
                    this.amountRadNumericInput.set_value(results.amt);
                }
            } catch (err) {
            }
            this.isRunning = false;

            return results;
        }
    }
    
    this.calcAmount = function(qty, rate, decimals, cpm) {
        var cpmRate;
        if (cpm == true) {
            cpmRate = rate / 1000;
        } else {
            cpmRate = rate;
        }
        return this.roundNumber((Number(qty) * Number(cpmRate)), decimals);
    }

    this.calcQty = function(rate, amt, decimals, cpm) {
        var qty;
        qty = Number(amt) / Number(rate);
        if (cpm == true) {
            qty = qty * 1000;
        }
        return this.roundNumber(qty, decimals);
    }

    this.calcRate = function(qty, amt, decimals, cpm) {
        var rate;
        rate = Number(amt) / Number(qty);
        if (cpm == true) {
            rate = rate * 1000;
        }
        return this.roundNumber(rate, decimals);
    }

    /*
        Returns number rounded to specified decimal places
        Should be used for calculation purposes.
    */
    this.roundNumber = function (num, decimals) {
        return Number(Number(num).toFixed(decimals).replace(/(\d)(?=(\d{3})+\.)/g, '$1,').replace(/,/g, ''));
    }

    /*
        Returns number with specified decimal places as a string
        Should be used for display purposes.
    */
    this.formatNumber = function (num, decimals) {
        return Number(num).toFixed(decimals).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
    }

    function getRadNumericTextBoxFromGridColumn(gridDataItem, gridColumn) {
        var radNumericTextBox;
        try {
            radNumericTextBox = gridDataItem.findControl('RNTB_' + gridColumn.get_uniqueName());
        } catch (err) {
        }
        if (!radNumericTextBox) {
            try{
                radNumericTextBox = $telerik.findControl(gridDataItem, 'RNTB_' + gridColumn.get_uniqueName()); 
            } catch (err) {
            }
        }
        return radNumericTextBox;
    }

}    
    