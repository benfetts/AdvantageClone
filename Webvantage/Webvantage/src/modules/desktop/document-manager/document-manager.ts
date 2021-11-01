import { ModuleBase } from 'modules/base/module-base';
import { Router } from 'aurelia-router';
import { customElement } from 'aurelia-framework'
import { AlertModel } from 'models/desktop/alert-model';

export class Document_Manager {

    data: kendo.data.DataSource;
    grid: kendo.ui.Grid;
    autoClose = true;
    data2: kendo.ui.TreeList;

    // search editors
    levelMultiSelect: kendo.ui.MultiSelect;
   

    // search datasources
    levelDataSource: kendo.data.DataSource;
   

    // search parameters
    levelCode = [];
   

    items = [];

    search() {
        this.grid.dataSource.read();
    }

    //on change functions
    levelMultiSelect_OnChange(e) {
        //console.log(this);
    }
   

    //set datasources
   
    constructor() {
        let me = this;

        this.data = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/DocumentManager/GetDocuments'
                }
            },
            schema: {
                model: {
                    id: 'FileName',
                    fields: {
                        FileName: { type: 'string' },
                        FileDescription: { type: 'string' },
                        Type: { type: 'string' },
                        Size: { type: 'number' },
                        UploadedBy: { type: 'string' },
                        Date: { type: 'date' },
                        Private: { type: 'boolean' }
                    }
                }
            }

        });
        //console.log(this.data);
        //var data2 = new kendo.data.TreeListDataSource({
        //    data = [{
        //        id: 1, text: 'Level', expanded: false, items: [
        //            {
        //                id: 2, text: 'Kendo UI Project', expanded: true, items: [
        //                    { id: 3, text: 'about.html', spriteCssClass: 'html' },
        //                    { id: 4, text: 'index.html', spriteCssClass: 'html' },
        //                    { id: 5, text: 'logo.png', spriteCssClass: 'image' }
        //                ]
        //            },
        //            {
        //                id: 6, text: 'New Web Site', expanded: true, spriteCssClass: 'folder', items: [
        //                    { id: 7, text: 'mockup.jpg', spriteCssClass: 'image' },
        //                    { id: 8, text: 'Research.pdf', spriteCssClass: 'pdf' }
        //                ]
        //            },
        //            {
        //                id: 9, text: 'Reports', expanded: true, spriteCssClass: 'folder', items: [
        //                    { id: 10, text: 'February.pdf', spriteCssClass: 'pdf' },
        //                    { id: 11, text: 'March.pdf', spriteCssClass: 'pdf' },
        //                    { id: 12, text: 'April.pdf', spriteCssClass: 'pdf' }
        //                ]
        //            }
        //        ] 
        //    }]    
        //});
    }

    // function that gathers IDs of checked nodes
    checkedNodeIds(nodes, checkedNodes) {
        for (let i = 0; i < nodes.length; i++) {
            if (nodes[i].checked) {
                checkedNodes.push(nodes[i].id);
            }

            if (nodes[i].hasChildren) {
                this.checkedNodeIds(nodes[i].children.view(), checkedNodes);
            }
        }
    }

    // show checked node IDs on datasource change
    onCheck() {
        let checkedNodes = [];
        let message;

        this.checkedNodeIds(this.data2.dataSource.view(), checkedNodes);

        if (checkedNodes.length > 0) {
            message = 'IDs of checked nodes: ' + checkedNodes.join(',');
        } else {
            message = 'No nodes checked.';
        }
    }

    pageable = {
        refresh: true,
        pageSizes: true
    };

    hasLoaded = false

    gridOnDataBound(e) {

       
    }

    test() {
       this.autoClose = false;
    }

    isSearchExpanded = false;

    expand() {
        this.isSearchExpanded = !this.isSearchExpanded;
       

    }

}
