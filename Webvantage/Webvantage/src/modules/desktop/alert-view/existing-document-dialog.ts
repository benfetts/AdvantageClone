import { inject } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';
import { ModuleBase } from 'modules/base/module-base';
import { AlertService } from 'services/desktop/alert-service';
import { AlertModel } from 'models/desktop/alert-model';

@inject(DialogController, AlertService)
export class ExistingDocumentDialog extends ModuleBase {
    controller: DialogController;
    Alert: AlertModel;
    service: AlertService;
    existingDocumentsDataSource: kendo.data.DataSource;
    existingDocumentsGrid: kendo.ui.Grid;
    existingDocumentButton: HTMLElement;
    hasDocuments: number = 0;
    linkableDocuments: Array<any>;
    constructor(controller: DialogController, service: AlertService) {
        super();
        this.controller = controller;
        this.service = service;
        this.existingDocumentsDataSource = new kendo.data.DataSource();
    }
    activate(params: any) {
        this.Alert = params.Alert;
        this.linkableDocuments = params.linkableDocuments;

        this.getLinkableDocuments();
    }
    getLinkableDocuments() {
        let me = this;
        this.existingDocumentsDataSource.filter({ field: 'Linked', value: true, operator: 'neq' });
        this.service.getLinkableDocuments(this.Alert).then(response => {
            if (response.content && response.content !== '') {
                this.linkableDocuments.forEach(function (value, index, array) {
                    var obj = response.content.find(o => o.ID === value.ID);
                    if (obj) {
                        obj['Linked'] = true;
                    }
                });
                me.existingDocumentsDataSource.data(response.content);
                me.hasDocuments = me.existingDocumentsDataSource.data().length;
            }
            else {
                me.hasDocuments = 0;
            }
        });
    }
    save() {
        try {
            var items = this.existingDocumentsGrid.select();
            var dataItems = [];
            if (items.length > 0) {
                for (var i = 0; i < items.length; i++) {
                    var dataItem = <any>this.existingDocumentsGrid.dataItem(items[i]);
                    dataItem.Linked = true;
                    dataItems.push(dataItem);
                }
            }
            this.controller.ok(dataItems);
        } catch (e) {
            this.showInfoNotification("Nothing to save.");
            this.controller.cancel();
        }
    }
}
