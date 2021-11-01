export class Controls {

    data: Array<any>;

    constructor() {
        this.data = new Array<any>();
        for (var i = 1; i <= 5; i++) {
            this.data.push({ text: 'Item ' + i, value: i });
        }
    }

}
