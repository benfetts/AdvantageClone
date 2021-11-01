import * as moment from 'moment';

export class ModelBase {
    
    // getters
    getDate(date?: Date): Date {
        if (date) {
            return this.formatDate(date, "LLLL");
        }
        return;
    }
    getShortDate(date?: Date): Date {
        if (date) {
            return this.formatDate(date, "L");
        }
        return;
    }
    formatDate(date: Date, format: moment.LongDateFormatKey): Date {
        var d = new Date(date);
        if (isNaN(Number(d))) {
            d = date;
        }
        return new Date(moment(d).format(moment.localeData().longDateFormat(format)));
    }
    getShortDateTimeDisplay(date: Date) {
        return moment(date).format(moment.localeData().longDateFormat('l')) + ' ' + moment(date).format(moment.localeData().longDateFormat('LT'));
    }

    toJSON() {
        var obj: any = {};
        for (var prop in this) {
            obj[prop] = this[prop];
        }
        return obj;
    }

    constructor() {

    }

}
