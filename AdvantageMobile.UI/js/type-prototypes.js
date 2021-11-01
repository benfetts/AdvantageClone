// TYPE PROTOTYPES:
Date.prototype.toShortTimeString = function () {
    if (this == undefined) {
        return ""
    } else {
        //return Globalize.format(this, 't');
        return this.toLocaleTimeString();
    }
}

Date.prototype.toShortDateString = function () {
    if (this == undefined) {
        return ""
    } else {
        //return Globalize.format(this, 'd');
        return this.toLocaleDateString();
    }
}
Date.prototype.toUtcDate = function () {
    var utcDate = new Date(this.getUTCFullYear(), this.getUTCMonth(), this.getUTCDate());
    return utcDate;
}
Date.prototype.toUtcShortDateString = function () {
    var utcDate = new Date(this.getUTCFullYear(), this.getUTCMonth(), this.getUTCDate());
    //return Globalize.format(utcDate, 'd');
    return utcDate.toLocaleDateString();
}
Date.prototype.addDays = function (days) {
    var dat = new Date(this.valueOf());
    dat.setDate(dat.getDate() + days);
    return dat;
}
Date.prototype.addMonths = function (months) {
    var dat = new Date(this.valueOf());
    var year = parseInt(dat.getFullYear());
    var month = parseInt(dat.getMonth());
    var newDate = new Date(year, month + months, 1);
    return newDate;
}
Date.prototype.monthName = function () {
    var utcDate = new Date(this.getUTCFullYear(), this.getUTCMonth(), 1);
    var monthNames = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];
    return monthNames[utcDate.getUTCMonth()];
    //return Globalize.format(utcDate, 'Y');
}
Date.prototype.weekSpanUTC = function (startOfWeek) {
    var utcDate = new Date(this.getUTCFullYear(), this.getUTCMonth(), this.getUTCDate());
    var startDate;
    var endDate;

    if (!startOfWeek) {
        startOfWeek = 0;
    };
    if (utcDate.getDay() == startOfWeek) {
        startDate = new Date(utcDate);
    } else {
        startDate = utcDate.addDays((utcDate.getDay() * -1) + startOfWeek);
    };
    endDate = startDate.addDays(6);
    return startDate.toUtcShortDateString() + ' - ' + endDate.toUtcShortDateString();
    //return Globalize.format(utcDate, 'd');
};
String.prototype.toTwoDecimalPlaces = function () {
    //var value = Globalize.parseFloat(this);
    //if (isNaN(value)) {
    //    return this;
    //} else {
    //    return Globalize.format(value, "n2");
    //};
    if (isNaN(this)) {
        return this;
    } else {
        return parseFloat(this).toFixed(2);
    };

};
String.prototype.padSix = function () {
    var value = parseFloat(this);
    if (isNaN(value)) {
        return this;
    } else {
        var str = "" + value
        var pad = "000000"
        var ans = pad.substring(0, pad.length - str.length) + str;
        return ans;
    };
};
String.prototype.pad2 = function () {
    var value = parseFloat(this);
    if (isNaN(value)) {
        return this;
    } else {
        var str = "" + value
        var pad = "00"
        var ans = pad.substring(0, pad.length - str.length) + str;
        return ans;
    };
};
String.prototype.slashToPipe = function () {
    return this.replace(/\//g, " | ");
};
String.prototype.dashToPipe = function () {
    return this.replace(/-/g, " | ");
};
String.prototype.replaceAt = function (index, character) {
    return this.substr(0, index) + character + this.substr(index + character.length);
};
String.prototype.splice = function (idx, rem, s) {
    return (this.slice(0, idx) + s + this.slice(idx + Math.abs(rem)));
};
String.prototype.toCurrency = function (c, d, t) {
    var n = this,
        c = isNaN(c = Math.abs(c)) ? 2 : c,
        d = d == undefined ? "." : d,
        t = t == undefined ? "," : t,
        s = n < 0 ? "-" : "",
        i = String(parseInt(n = Math.abs(Number(n) || 0).toFixed(c))),
        j = (j = i.length) > 3 ? j % 3 : 0;
    return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
};

Number.prototype.toCurrency = function (c, d, t) {
    var n = this,
        c = isNaN(c = Math.abs(c)) ? 2 : c,
        d = d == undefined ? "." : d,
        t = t == undefined ? "," : t,
        s = n < 0 ? "-" : "",
        i = String(parseInt(n = Math.abs(Number(n) || 0).toFixed(c))),
        j = (j = i.length) > 3 ? j % 3 : 0;
    return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
};
//Boolean.prototype.toYesNo = function () {
//    if (!this) {
//        return localizeString('No');
//    } else {
//        if (this == true) {
//            return localizeString('Yes');
//        } else {
//            return localizeString('No');
//        }
//    }
//}