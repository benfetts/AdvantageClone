import { bindable, inject } from "aurelia-framework";
import { AlertService } from 'services/desktop/alert-service';
//import{ValidationRules} from 'aurelia-framework';

@inject(AlertService)
export class Checklist {

    service: AlertService;

    @bindable checklistId: number;
    @bindable items: Array<any> = [];

    newItemDescription = '';
    checklistName = 'Checklist';
    editItemInput: HTMLTextAreaElement;
    progressBar: kendo.ui.ProgressBar;

    //sortableItems: kendo.ui.Sortable;

    checkedItems: number = 0;
    totalItems: number = 0;

    attached() {
        let me = this;
        window.setTimeout(function () {
            me.checkProgress();
        }, 0);
    }

    constructor(service: AlertService) {
        this.service = service;
    }
    // ValidationRules
    //   ensure(taskListDescription).required()


    checkProgress() {
        //console.log("checklist.ts checkProgress()")
        if (!this.items) {
            this.items = [];
        }
        this.checkedItems = 0;
        this.totalItems = this.items.length;
        if (!this.totalItems) {
            this.totalItems = 0;
        }
        for (var i = 0; i < this.items.length; i++) {
            if (this.items[i].IsChecked === true) {
                this.checkedItems += 1;
            }
        }
        if (this.progressBar) {
            if (this.progressBar.options.max != this.totalItems) {
                this.progressBar.setOptions({
                    max: this.totalItems
                });
            }
            this.progressBar.value(this.checkedItems);
        }
    }

    editTitle(checklistName) {
       //console.log("editTitle", checklistName)
        checklistName.edit = !checklistName.edit;
    }

    add() {
        if (!this.items) {
            this.items = [];
        }
        if (this.newItemDescription) {
            var checklistItem = {
                IsChecked: false,
                Description: this.newItemDescription
            };
            this.service.createChecklistItem(this.checklistId, checklistItem).then(response => {
                if (response.content.Success === true) {
                    this.items.push(response.content.Data);
                    this.newItemDescription = ' ';
                } else {
                    // there was a problem adding
                }
            }).then(() => {
                this.checkProgress();
            });
        }
    }

    itemCheckChanged(item: any) {
       //console.log("itemCheckChanged", item)
       this.service.updateChecklistItem(item).then(response => {
            if (response.content.Success === true) {

            } else {
                //problem updating
            }
        }).then(() => {
            this.checkProgress();
        });
    }
    updateItem(item) {
        this.service.updateChecklistItem(item).then(response => {
            if (response.content.Success === true) {

            } else {
                //problem updating
            }
        }).then(() => {
            this.checkProgress();
        });
    }
    editItem(item) {
        let me = this;
        if (item.edit === true) {
            this.updateItem(item);
        }
        var edit = !item.edit;
        if (edit === true) {
            for (var i = 0; i < this.items.length; i++) {
                if (this.items[i].edit === true) {
                    this.updateItem(item);
                }    
                this.items[i].edit = false;
            }
            window.setTimeout(function () {
                $('#cbtbedit').focus().select();
            }, 10);
        }
        item.edit = edit;
    }
    removeItem(item) {
        let index = this.items.lastIndexOf(item);
        if (index !== -1) {
            this.service.deleteChecklistItem(item).then(response => {
                if (response.content.Success === true) {
                    this.items.splice(index, 1);
                } else {
                    // problem deleting
                }
            }).then(() => {
                this.checkProgress();
            })
        }
    }

    hint(e) {
        return $(e).clone().addClass('sortable-basic-use-hint');
    }

    placeholder(e) {
        return $(e).clone().addClass('sortable-basic-use-placeholder').text('Drop here');
    }

    showMenu() {
        var checklistMenu = $('.checklist-menu');
        checklistMenu.kendoDropDownList();
    }

    convetToAssignment(item) {
        alert('todo: convetToAssignment');
    }
    //@bindable message = 'Hello from Task List';
}
