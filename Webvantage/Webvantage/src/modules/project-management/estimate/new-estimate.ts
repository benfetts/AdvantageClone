import { ModuleBase } from 'modules/base/module-base';
import { customElement } from 'aurelia-framework'

export class New_Estimate {

    data: kendo.data.DataSource;

    constructor() {

        this.data = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/Campaign/GetCampaigns'
                }
            },
            schema: {
                model: {
                    id: 'ID',
                    fields: {
                        ID: { type: 'number' },
                        Code: { type: 'string' },
                        Name: { type: 'string' },
                        StartDate: { type: 'date' },
                        EndDate: { type: 'date' },
                        ClientCode: { type: 'string' },
                        DivisionCode: { type: 'string' },
                        ProductCode: { type: 'string' }
                    }
                }
            }
        });

    }

    pageable = {
        refresh: true,
        pageSizes: true
    };

    hasLoaded = false

    gridOnDataBound(e) {

        //if (!this.hasLoaded) {
        //    var items = e.sender.items();
        //    items.each(function (i) {
        //        var dataItem = e.sender.dataItem(this);
        //        if (i % 2 === 0) {
        //            dataItem.Paid = true;
        //        } else {
        //            dataItem.Paid = false;
        //        }
        //        this.className += ' wv-temp-status-indicator wv-temp-status-' + i;
        //        switch (i) {
        //            case 0:
        //                dataItem.StatusCode = 'Open';
        //                break;
        //            case 1:
        //                dataItem.StatusCode = 'Pending';
        //                break;
        //            case 2:
        //                dataItem.StatusCode = 'Denied';
        //                break;
        //            case 3:
        //                dataItem.StatusCode = 'Approved';
        //                break;
        //        }
        //    });
        //    this.hasLoaded = true;
        //    e.sender.refresh();
        //}

    }

    isSearchExpanded = false;

    expand() {
        this.isSearchExpanded = !this.isSearchExpanded;
        //console.log('fired');
        //$(".wv-search-expand").hover(function () {

        //    $(this).attr("ishoveredin", 1);
        //    $(this).stop(true, false).animate({
        //        width: "400px"
        //    });
        //}, function () {
        //    $(this).attr("ishoveredin", 0);
        //    if (Number($(this).attr("isfocusedin")) != 1)
        //        $(this).stop(true, false).animate({
        //            width: "200px"
        //        });
        //});

        //$(".wv-search-expand").focus(function () {
        //    $(this).attr("isfocusedin", 1);
        //    $(this).stop(true, false).animate({
        //        width: "400px"
        //    });
        //});

        //$("#.").blur(function () {
        //    $(this).attr("isfocusedin", 0);
        //    $(this).stop(true, false).animate({
        //        width: "200px"
        //    });
        //});

    }

}
