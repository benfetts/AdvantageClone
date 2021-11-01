import { DialogController } from "../../../node_modules/aurelia-dialog";

export namespace Application {

    export class App {

        MainMenuItems: Array<MenuItem>;
        QuickAccessMenuItems: Array<MenuItem>;
        ProductivityMenuItems: Array<MenuItem>;
        SearchMenuItems: Array<MenuItem>;
        Employee: EmployeeInfo;
        IsClientPortal: boolean
        IsProofingActive: boolean;
        DatabaseName: string;

        formatMenu(item): MenuItem {
            let menuItem: MenuItem;
            if (item.MenuItems) {
                var categoryMenuItem: CategoryMenuItem = new CategoryMenuItem;
                categoryMenuItem.Text = item.Text;
                categoryMenuItem.Value = item.Value;
                for (var i = 0; i < item.MenuItems.length; i++) {
                    let childMenuItem: MenuItem;
                    childMenuItem = this.formatMenu(item.MenuItems[i]);
                    categoryMenuItem.MenuItems.push(childMenuItem);
                }
                menuItem = categoryMenuItem;
            } else {
                var applicationMenuItem: ApplicationMenuItem = new ApplicationMenuItem;
                applicationMenuItem.Text = item.Text;
                applicationMenuItem.IsReport = item.IsReport;
                applicationMenuItem.Url = item.Url;
                applicationMenuItem.UseIframe = item.UseIframe;
                applicationMenuItem.Value = item.Value;
                menuItem = applicationMenuItem;
            }
            return menuItem;
        }

        static fromObject(data: any): Application.App {
            let app: App = new App();
            if (data.MainMenuItems) {
                for (var i = 0; i < data.MainMenuItems.length; i++) {
                    let item = data.MainMenuItems[i];
                    var menuItem: MenuItem = app.formatMenu(item);
                    app.MainMenuItems.push(menuItem);
                }
            }
            if (data.QuickAccessMenuItems) {
                for (var i = 0; i < data.QuickAccessMenuItems.length; i++) {
                    let item = data.QuickAccessMenuItems[i];
                    var menuItem: MenuItem = app.formatMenu(item);
                    if (menuItem.Text != "Timesheet Entry") {
                        app.QuickAccessMenuItems.push(menuItem);
                    }
                }
            }
            if (data.ProductivityMenuItems) {
                for (var i = 0; i < data.ProductivityMenuItems.length; i++) {
                    let item = data.ProductivityMenuItems[i];
                    var menuItem: MenuItem = app.formatMenu(item);
                    app.ProductivityMenuItems.push(menuItem);
                }
            }
            if (data.SearchMenuItems) {
                for (var i = 0; i < data.SearchMenuItems.length; i++) {
                    let item = data.SearchMenuItems[i];
                    var menuItem: MenuItem = app.formatMenu(item);
                    app.SearchMenuItems.push(menuItem);
                }
            }
            if (data.Employee) {
                app.Employee = {
                    Code: data.Employee.Code,
                    Name: data.Employee.Name,
                    Title: data.Employee.Title,
                    Picture: data.Employee.Picture,
                    FirstName: data.Employee.FirstName,
                    MiddleInitial: data.Employee.MiddleInitial,
                    LastName: data.Employee.LastName,
                    Nickname: data.Employee.Nickname,
                    Signature: data.Employee.Signature
                }
            }
            if (data.IsClientPortal) {
                app.IsClientPortal = data.IsClientPortal;
            }
            if (data.IsProofingActive) {
                app.IsProofingActive = data.IsProofingActive;
            }
            if (data.DatabaseName) {
                app.DatabaseName = data.DatabaseName;
            }
            return app;
        }

        constructor() {
            this.MainMenuItems = [];
            this.QuickAccessMenuItems = [];
            this.ProductivityMenuItems = [];
            this.SearchMenuItems = [];
        }

    }
    
    export class MenuItem {

        Text: string;
        Value: string;
        Expanded: boolean;
        
    }

    export class ApplicationMenuItem extends MenuItem {

        Url: string;
        DocumentTitle: string;
        IsReport: boolean;
        UseIframe: boolean;
        Parameters: Array<any>;
        Page: string;
        Frame: HTMLIFrameElement;
        Active: boolean;

        constructor() {
            super();
        }

    }

    export class CategoryMenuItem extends MenuItem {

        MenuItems: Array<MenuItem>;

        constructor() {
            super();
            this.MenuItems = [];
        }

    }

    export class EmployeeInfo {
        Code: string;
        Name: string;
        Title: string;
        Picture: string;
        FirstName: string;
        MiddleInitial: string;
        LastName: string;
        Nickname: string;
        Signature: string;
    }

}
