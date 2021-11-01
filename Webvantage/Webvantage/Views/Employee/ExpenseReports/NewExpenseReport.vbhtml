@*@Code
        Layout = "~/Views/Shared/_Angular.vbhtml"
        End Code
    <app-root></app-root>
    @ModelType AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel
*@
@Code 'ViewData("Title") = "Expense reports"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
    ViewData("IsAngular") = True



    Dim employeeJson = ViewBag.EmployeeJson
    Dim employeeCode = ViewBag.EmployeeCode
    Dim employeeFullName = ViewBag.EmployeeFullName
    Dim userCode = ViewBag.UserCode

    Dim functionCodes = ViewBag.FunctionCodes
    Dim paymentTypes = ViewBag.PaymentTypes
    Dim jobs = ViewBag.Jobs
    Dim colSettings = ViewBag.ColumnSettings
    Dim uploadedImages = ViewBag.UploadedImages
    Dim labelStatusInfo = ViewBag.LabelStatusInfo
    Dim imageStatus = ViewBag.Image_Status
    Dim canAdd = ViewBag.CanAdd
    Dim canUpdate = ViewBag.CanUpdate
    Dim canPrint = ViewBag.CanPrint
    Dim custom1Sec = ViewBag.Custom1
    Dim custom2Sec = ViewBag.Custom2
    Dim pageSizeGrid = ViewBag.PageSize
    Dim defaultPaymentType = ViewBag.DefaultPaymentType
    Dim HasDocuments = ViewBag.HasDocuments
    Dim receiptCount = ViewBag.ReceiptCount

    Dim expReport As AdvantageFramework.DTO.Employee.ExpenseReport = ViewBag.ExpenseReportHeader
    Dim expReportDetails As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail) = ViewBag.ExpenseReportDetails


    ViewData("Title") = ViewBag.PageTitle


End Code

<!--  Script Source Here  -->
<script src="~/Scripts/ExpenseReports/expenseReport.js"></script>

<style>

    .k-i-calendar {
        height: 40px !important;
    }

    .k-picker-wrap.k-input {
        height: 2.667em !important;
        line-height: 2.667em !important;
        min-height: 2.667em !important;
    }

    .k-picker-wrap {
        height: 2.667em !important;
    }

        .k-picker-wrap.k-select {
            height: 2.667em !important;
            min-height: 2.667em !important;
            line-height: 2.667em !important;
        }

    .k-dropdown-wrap {
        line-height: 2.5em !important;
        min-height: 2.5em !important;
    }

    /*.k-dropdown {
        width: 5.0em !important;
    }*/

    .template-wrapper {
        padding: 15px;
        width: 200px;
        height: 300px;
    }


    .fieldlist {
        text-align: left;
        margin: 1em 0 -1em 1em;
        padding: 0;
    }

        .fieldlist li {
            list-style: none;
            padding-bottom: 1em;
        }

    .k-combobox > .k-dropdown-wrap > .k-i-close {
        color: black;
    }

    .thumbnail {
        margin-bottom: 0;
        position: relative;
        width: 150px;
    }

    .standard-thumbnail {
        padding-top: 2px;
        margin-bottom: 0;
        position: relative;
        float: left;
        width: 50px;
        border: none
    }

    .delete-thumbnail {
        position: absolute;
        top: 2px;
        right: 5px;
    }



    td .k-dropzone {
        height: 30px !important;
        min-height: unset;
        max-height: 30px !important;
        padding: 0px;
        line-height: 25px;
    }

        td .k-dropzone-active {
            border: 1px solid yellow;
        }

            td .k-dropzone-active .k-dropzone-hovered {
                border: 2px solid green;
            }

    .k-grid-header th.k-state-focused .k-link {
        color: #FFF !important;
    }

    .k-grid td {
        max-width: 350px;
    }

    .k-numerictextbox {
        font-size: 13px !important;
    }

    .k-picker-wrap {
        padding-left: 8px;
    }

    .drag-drop-hover {
        background-color: #e5e5e5;
    }

    #panelbar {
        border-style: solid;
        border-width: 1px;
        /*padding: 10px;*/
        /*margin: auto;*/
        margin-bottom: 5px;
        border-radius: 4px;
        border-color: lightgrey;
        min-width: 1000px !important;        
    }

    #PanelHeader {
        /*background-color: white !important;
        border-color:#ccc !important;
        color: black;*/
    }

    .e-widget-content + .e-box {
        height: 100% !important;
    }
</style>

<div ng-app="angExpenseReport" ng-controller="ExpenseReportController">
    <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable" style="width: calc(100vw - 17);background-color: #E5E5E5;padding: 8px 0px 8px 0px;border-bottom: 1px solid #CCC;box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);margin: 5px auto; overflow:auto;">
        <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
            <li style="padding-right: 3px !important;">
                <button tabindex="-1" class="k-button wv-icon-button wv-add-new" onclick="openNewEntryDialog();" ng-class="{'k-state-disabled': isNew()}" ng-disabled=" isNew()" title="Add new expense report"><span class='glyphicon wvi wvi-navigate-plus'></span></button>
            </li>
            <li style="padding-right: 3px !important;">
                <button tabindex="-1" id="saveButton" class="k-button wv-icon-button wv-save" ng-class="{'k-state-disabled': !saveAvailable() }" ng-disabled="!saveAvailable()" ng-click="saveClick()" title="Save changes"><span class='wvi wvi-floppy-disk'></span></button>
            </li>
            <li style="padding-right: 3px !important;">
                <button tabindex="-1" id="cancelButton" class="wv-icon-button k-button wv-cancel" ng-class="{'k-state-disabled': !cancelAvailable() }" ng-disabled="!cancelAvailable()" ng-click="cancelHeaderClick()" title="Cancel"><span class='wvi wvi-sign-forbidden'></span></button>
            </li>
            <li style="padding-right: 3px !important;">
                <button id="copyButton" class="wv-icon-button k-button wv-copy" ng-class="{'k-state-disabled': !savedRepot('copy') }" ng-disabled="!savedRepot('copy')" ng-click="copyClick()" title="Copy Expense Report"><span class='wvi wvi-copy'></span></button>
            </li>
            <li style="padding-right: 3px !important;">
                <button tabindex="-1" id="deleteButton" class="k-button wv-icon-button wv-cancel" ng-class="{'k-state-disabled': !savedRepot('delete') || approvedReport() }" ng-disabled="!savedRepot('delete') || approvedReport() " ng-click="deleteReportClick()" title="Delete Expense Report"><span class='wvi wvi-delete'></span></button>
            </li>
            <li style="padding-right: 3px !important;">
                <span class="btn-separator"></span>
            </li>

            <li style="padding-right: 3px !important;">
                <button tabindex="-1" class="k-button wv-icon-button wv-neutral" ng-click="openPrintSettingsPage()" ng-class="{'k-state-disabled': !savedRepot('print') }" ng-disabled="!savedRepot('print')" style="width: 80px !important;"><span style="font-size: 12px;" title="Print Report">Print</span></button>
            </li>

            <li id="submitListItem" style="padding-right: 3px !important;" ng-show="expenseReportHeader.IsSubmitted == 0 || expenseReportHeader.IsSubmitted == null">
                <button tabindex="-1" class="k-button wv-icon-button wv-neutral " ng-click="submitClick()" ng-class="{'k-state-disabled': !savedRepot('submit') || approvedReport()  }" ng-disabled="!savedRepot('sumbit') || approvedReport()" style="width: 80px !important;" title="Submit"><span style="font-size: 12px;">Submit</span></button>
            </li>
            <li id="unSubmitListItem" style="padding-right: 3px !important;" ng-show="(expenseReportHeader.IsSubmitted == 1 && (expenseReportHeader.IsApproved == 0 || expenseReportHeader.IsApproved == 1) && expenseReportHeader.Status !== 2) || (expenseReportHeader.IsSubmitted == 1 && expenseReportHeader.IsApproved == 2 && expenseReportHeader.Status == 5)">
                <button tabindex="-1" class="k-button wv-icon-button wv-neutral " ng-click="unSubmitClick()" style="width: 80px !important;" title="Submit"><span style="font-size: 12px;">Un-submit</span></button>
            </li>

            @*<li style="padding:0">
                    <span class="btn-separator"></span>
                </li>*@

            <li id="importExpensesListItem" style="padding-right: 3px !important;">
                <button tabindex="-1" class="k-button wv-icon-button wv-neutral " ng-click="importExpensesClick()" ng-class="{'k-state-disabled': approvedReport() || isNew()}" ng-disabled="approvedReport() || isNew()" style="width: 80px !important;" title="Import Expenses"><span style="font-size: 12px;">Import</span></button>
            </li>
            <li id="uploadReceiptsListItem" style="padding-right: 3px !important;">
                <button tabindex="-1" class="k-button wv-icon-button wv-neutral " ng-click="uploadReceiptsClick()" ng-class="{'k-state-disabled': !savedRepot('manage')}" ng-disabled="!savedRepot('manage')" style="width: 135px !important;" title="Manage Receipts"><span style="font-size: 12px;">Manage Receipts</span></button>
            </li>

            <li style="padding-right: 3px !important;">
                <span class="btn-separator"></span>
            </li>

            <li style="padding-right: 3px !important;">
                <button tabindex="-1" class="k-button wv-icon-button wv-neutral" ng-click="bookmarkClick()" ng-class="{'k-state-disabled': !savedRepot('bookmark') }" ng-disabled="!savedRepot('bookmark')"><span class='wvi wvi-book-bookmark' title="Bookmark"></span></button>
            </li>


        </ul>
        <div class="pull-right">
        </div>
    </div>
    <style>

        /*td {
            border:1px solid black;
        }*/
    </style>
    <div id="JobInfo" class="wv-bar k-widget" style="width:calc(100vw - 16px);background-color: white;padding: 0px 0px 0px 0px;display:inline-block;border:none;">
        <ul id="panelbar" style="display:inline-block;position:relative;width:calc(100vw - 16px);min-width:calc(100vw - 16px);">
            <li class="k-state-active" style="min-width:calc(100vw - 16px) !important;">
                <!--<span id="ClientName" style="background-color:#e5e5e5 !important;border-color:lightgrey !important;color:#333 !important;" class="k-link k-state-selected">Filters</span>-->
                <span id="PanelHeader" class="k-link k-state-selected">
                    <span style="font-weight:600;font-size:14px;"> Expense Report</span>
                    <span style="font-size:14px;font-weight:600;float:right;padding-right:10px;">Invoice Number:  {{expenseReportHeader.InvoiceNumber ? expenseReportHeader.InvoiceNumber : 'TBD' }}</span>
                </span>
                <div style="padding-top: 20px;padding-bottom: 20px;padding-left: 30px; border-bottom: none;overflow:auto;">
                    <table style="margin-bottom:25px;">
                        <tr>
                            <td style="width:300px;min-width:300px;margin:4px;padding-right: 20px;">
                                <div id="tdEmployee">
                                    <div class="wv-employee-box">
                                        <div class="body">
                                            <div class="row">
                                                <div class="image-container" title="@ViewBag.EmployeeName">
                                                    <img id="employeeImage" src='@Url.Action("EmployeePicture", "Utilities")/@Html.Raw(employeeCode)' />
                                                </div>
                                                <div class="name" title="@Html.Raw(employeeFullName)">
                                                    <span class="name-span">@Html.Raw(employeeFullName)</span>
                                                </div>
                                                <div class="button">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td style="width:200px;min-width:200px;margin:4px;padding-right: 30px;">
                                <div class="row" style="margin-left:0px !important;">
                                    <span style="font-weight:bold">Date Created</span>
                                </div>
                                <div class="row ng-cloak" style="margin-left:0px !important;">
                                    {{expenseReportHeader.CreatedDate | date:"MM/dd/yyyy"}}
                                </div>
                            </td>
                            <td style="width:250px;min-width:220px;margin:4px;padding-right: 30px;">
                                <div class="row" style="margin:0px 0px 3px 0px !important;">
                                    <span style="font-weight:bold">Status</span>
                                </div>
                                <div class="row" style="margin-left:0px !important;">
                                    <img src="~/Images/information-trans.png" style="@Html.Raw(imageStatus)" title="@Html.Raw(labelStatusInfo)" /> <span ng-class="getERStatusCssClass()" class="pill">{{expenseReportHeader.Status ? splitCamelCase(expenseReportHeader.StatusCode) : 'Open' }}</span>
                                </div>
                            </td>
                            <td style="width:200px;min-width:200px;">
                                <div class="row" style="margin-left:0px !important;">
                                    <span style="font-weight:bold"> Total Due</span>
                                </div>
                                <div class="row" style="margin-left:0px !important;">
                                    <span class="ng-cloak">{{totalDue | number:2}}</span>
                                </div>
                            </td>
                            <td style="width:200px;min-width:200px;">
                                <div class="row" style="margin-left:0px !important;">
                                    <span style="font-weight:bold"> Less Company Card</span>
                                </div>
                                <div class="row" style="margin-left:0px !important;">
                                    <span class="ng-cloak">{{lessCreditCard | number:2}}</span>
                                </div>
                            </td>
                            <td style="width:200px;min-width:200px;">
                                <div class="row" style="margin-left:0px !important;">
                                    <span style="font-weight:bold"> Total Expenses</span>
                                </div>
                                <div class="row" style="margin-left:0px !important;">
                                    <span class="ng-cloak">{{totalExpenses | number:2}}</span>
                                </div>
                            </td>
                            <td style="width:100px;min-width:100px;">
                                <div id="DivDocuments" style="display: {{HasDocuments ? 'block' : 'none' }}; float:right;" class='icon-background background-color-sidebar standard-light-green'><input style='cursor:default !important;' class='icon-image' type='image' id='image' src='~/Images/Icons/White/256/documents_empty.png' title='{{receiptsCount}} receipt(s)' ng-click="uploadReceiptsClick()"></div>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="width:300px;min-width:300px;margin:4px;padding-right: 20px;">
                                <div class="row" style="margin-left:0px !important;">
                                    <label for="ExpenseReportDate">Report Date</label>
                                </div>
                                <div class="row" style="margin-left:0px !important;">
                                    <input tabindex="1" id="ExpenseReportDate" style="background-color: #FFFFCC" kendo-date-picker k-ng-model="expenseReportHeader.InvoiceDate" k-format="'MM/dd/yyyy'" k-parse-formats='["Mddyy", "MMddyy", "Mddyyyy", "MMddyyyy", "MM/dd/yyyy", "MM/d/yy", "M/dd/yy", "M/d/yy", "yyyy-MM-ddTHH:mm:ss"]' ng-disabled="approvedReport()" />
                                </div>
                            </td>
                            <td style="width:360px;">
                                <label for="descriptionField">Description</label>
                                <div>
                                    <input id="descriptionField" style="height:31px;background-color: #FFFFCC; " class="col-md-12 ng-cloak k-textbox" maxlength="30" ng-model="expenseReportHeader.Description" ng-readonly="approvedReport()" autocomplete="off"  />
                                </div>
                            </td>
                            <td style="width:840px;padding-left:15px;">
                                <label for="detailField">Detail</label>
                                <div>
                                    @*<input id="detailField" resize="both" class="col-md-12 ng-cloak k-textbox" style="height:31px;" ng-model="expenseReportHeader.Details" ng-readonly="approvedReport()" />*@
                                    <textarea id="detailField" rows="1" class="col-md-12 k-textbox" style="height:34px; padding-left: 5px; padding-top: 5px" ng-model="expenseReportHeader.Details" ng-readonly="approvedReport()"></textarea>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </li>
        </ul>
    </div>

    <!--Expense Report Grid -->
    <div class="row">
        <div id="ExpenseReportsGridFrame" class="col-sm-12">
            <div id="ExpenseReportsGrid" kendo-grid="grid" k-options="mainGridOptions" k-on-change="handleChange(data, dataItem, columns)"></div>
        </div>
    </div>

        <script>

        @code
            Dim header = Newtonsoft.Json.JsonConvert.SerializeObject(expReport)
            Dim data = Newtonsoft.Json.JsonConvert.SerializeObject(expReportDetails)
            Dim employee = Newtonsoft.Json.JsonConvert.SerializeObject(employeeJson.Data)
            Dim user = Newtonsoft.Json.JsonConvert.SerializeObject(userCode)

            Dim functioncodesList = Newtonsoft.Json.JsonConvert.SerializeObject(functionCodes.Data)
            Dim paymenttypesList = Newtonsoft.Json.JsonConvert.SerializeObject(paymentTypes.Data)
            Dim jobsList = Newtonsoft.Json.JsonConvert.SerializeObject(jobs.Data)
            Dim colSettingsList = Newtonsoft.Json.JsonConvert.SerializeObject(colSettings)
            Dim uploadedImagesList = Newtonsoft.Json.JsonConvert.SerializeObject(uploadedImages.Data)
            Dim canAddItem = Newtonsoft.Json.JsonConvert.SerializeObject(canAdd)
            Dim canUpdateItem = Newtonsoft.Json.JsonConvert.SerializeObject(canUpdate)
            Dim canPrintItem = Newtonsoft.Json.JsonConvert.SerializeObject(canPrint)
            Dim custom1SecItem = Newtonsoft.Json.JsonConvert.SerializeObject(custom1Sec)
            Dim custom2SecItem = Newtonsoft.Json.JsonConvert.SerializeObject(custom2Sec)
            Dim gridPageSize = Newtonsoft.Json.JsonConvert.SerializeObject(pageSizeGrid)
            Dim defaultPaymentTypeItem = Newtonsoft.Json.JsonConvert.SerializeObject(defaultPaymentType)
            Dim hasDocumentsItem = Newtonsoft.Json.JsonConvert.SerializeObject(HasDocuments)
            Dim receiptCountItem = Newtonsoft.Json.JsonConvert.SerializeObject(receiptCount)


        End Code

        var initHeader = @Html.Raw(header);
        var initData = @Html.Raw(data);
        var initEmployee = @Html.Raw(employee);

        var initFunctionCodes = @Html.Raw(functioncodesList);
        var initPaymentTypes = @Html.Raw(paymenttypesList);
        var initJobs = @Html.Raw(jobsList);
        var initColSettings = @Html.Raw(colSettingsList);
        var initUploadedImages = @Html.Raw(uploadedImagesList);
        var initCanAdd = @Html.Raw(canAddItem);
        var initCanUpdate = @Html.Raw(canUpdateItem);
        var initCanPrint = @Html.Raw(canPrintItem);
        var initCustom1 = @Html.Raw(custom1SecItem);
        var initCustom2 = @Html.Raw(custom2SecItem);
        var initUserCode = @Html.Raw(user);
        var intiPageSize = @Html.Raw(gridPageSize);
        var intiDefaultPaymentType = @Html.Raw(defaultPaymentType);
        var intiHasDocuments = @Html.Raw(hasDocumentsItem);
        var initReceiptCount = @Html.Raw(receiptCountItem);
        var initAllReceipts = @Html.Raw(uploadedImagesList);

        function getReportDetails() {
            return myData;
        }

        function aureliaSave() {
            $('#saveButton').trigger('click');
        }

        </script>
        <style>
            /*.k-upload {
                      max-width: 34px;
                      float: left;
                }*/

            .top-right {
                position: absolute;
                top: 0px;
                right: -10px;
                /*font-size: 8px;
                       font-weight: bold;
                       cursor: pointer;*/
            }

            .container {
                position: relative;
                text-align: center;
                color: black;
            }
        </style>

        <script type="text/x-kendo-template" id="newUploadOnlyColumn">
            <style>
                .k-upload {
                    width: 100%;
                    max-width: 100%;
                    float: none;
                }

                .k-grid tbody .k-button {
                    min-width: 15px;
                    width: 100%;
                }
            </style>

            @*<div style="width:100%">*@
            <input name="AsyncDocuments"
                   tabindex="-1"
                   id="AsyncDocuments#=data#"
                   title="Select or drag and drop receipt"
                   rowId="#=data#"
                   type="file"
                   kendo-upload
                   k-validation="{allowedExtensions: ['.jpg', '.jpeg', '.png', '.bmp', '.gif', '.csv', '.doc', '.docx', '.pdf', '.ppt', '.pptx', '.txt', '.xls', '.xlsx', '.zip']}"
                   k-async="{ saveUrl: 'UploadReceipts', removeUrl: 'remove', autoUpload: true }"
                   k-upload="onUpload"
                   k-localization="{ select: '+', dropFilesHere: '' }"
                   k-show-file-list=false
                   k-success="onSuccess"
                   k-on-error="onError" />
            @*</div>*@
        </script>


        <!-- Standard View Receipts Column Directive-->
        <script type="text/x-kendo-template" id="newUploadColumn">
            <div style="width:auto;" class="row">
                # for(var i = 0; i < data.Receipts.length; i++) { #
                <a title="#= data.Receipts[i].Filename #" href="#= data.Receipts[i].url #">
                    <div class="container standard-thumbnail ng-cloak" style="width:50px;">
                        <div>
                            #if(data.Receipts[i].extension == 'PDF'){#
                            <span title="#= data.Receipts[i].Filename #" style="font-size: 35px; color: black" class="wvi wvi-file-pdf-regular"></span>
                            #}else if (data.Receipts[i].extension == 'DOC' || data.Receipts[i].extension == 'DOCX'){#
                            <span title="#= data.Receipts[i].Filename #" style="font-size: 35px; color: black" class="wvi wvi-file-word-regular"></span>
                            #}else if (data.Receipts[i].extension == 'CSV' || data.Receipts[i].extension == 'XLS' || data.Receipts[i].extension == 'XLSX'){#
                            <span title="#= data.Receipts[i].Filename #" style="font-size: 35px; color: black" class="wvi wvi-excel-logo"></span>
                            #}else if (data.Receipts[i].extension == 'PPT' || data.Receipts[i].extension == 'PPTX'){#
                            <span title="#= data.Receipts[i].Filename #" style="font-size: 35px; color: black" class="wvi wvi-file-powerpoint-regular"></span>
                            #}else if (data.Receipts[i].extension == 'TXT' || data.Receipts[i].extension == 'ZIP'){#
                            <span title="#= data.Receipts[i].Filename #" style="font-size: 35px; color: black" class="wvi wvi-file-image-regular"></span>
                            #}else{#
                            <span title="#= data.Receipts[i].Filename #" style="font-size: 35px; color: black" class="wvi wvi-file-image-regular"></span>
                            @*<img title="#= data.Receipts[i].Filename #" src="#= data.Receipts[i].ThumbnailData #" style="max-height:35px;" />*@
                            #} #
                        </div>
                        <a id="delete-thumbnail-icon" class="delete-thumbnail" style="color:black;float:left;" ng-click="deleteFileClicked(#= data.Receipts[i].DocumentId #); refreshClick();" ng-show="!approvedReport()"><span class="top-right wvi wvi-delete"></span></a>
                    </div>
                    # } #
                    <div style="clear:both;"></div>
                </a>
            </div>

        </script>
        <!-- Standard View Receipts Column Directive (File Name)-->
        <script type="text/x-kendo-template" id="newUploadFileNameColumn">
            <div style="width:auto" class="row">
                <div class="wv-tokens-wrap">
                    # for(var i = 0; i < data.Receipts.length; i++) { #
                    <a title="#= data.Receipts[i].Filename #" href="#= data.Receipts[i].url #" class="au-target" style="max-width:110px; display:inline-block; text-overflow:ellipsis;">
                        <div class="wv-token" style="overflow:hidden; height:30px;">
                            <div>
                                #if(data.Receipts[i].extension == 'PDF'){#
                                <span title="#= data.Receipts[i].Filename #" style="font-size: 12px; color: black">#= data.Receipts[i].Filename #</span>
                                #}else if (data.Receipts[i].extension == 'DOC' || data.Receipts[i].extension == 'DOCX'){#
                                <span title="#= data.Receipts[i].Filename #" style="font-size: 12px; color: black">#= data.Receipts[i].Filename #</span>
                                #}else if (data.Receipts[i].extension == 'CSV' || data.Receipts[i].extension == 'XLS' || data.Receipts[i].extension == 'XLSX'){#
                                <span title="#= data.Receipts[i].Filename #" style="font-size: 12px; color: black">#= data.Receipts[i].Filename #</span>
                                #}else if (data.Receipts[i].extension == 'PPT' || data.Receipts[i].extension == 'PPTX'){#
                                <span title="#= data.Receipts[i].Filename #" style="font-size: 12px; color: black">#= data.Receipts[i].Filename #</span>
                                #}else if (data.Receipts[i].extension == 'TXT' || data.Receipts[i].extension == 'ZIP'){#
                                <span title="#= data.Receipts[i].Filename #" style="font-size: 12px; color: black">#= data.Receipts[i].Filename #</span>
                                #}else{#
                                <span title="#= data.Receipts[i].Filename #" style="font-size: 12px; color: black">#= data.Receipts[i].Filename #</span>
                                @*<img title="#= data.Receipts[i].Filename #" src="#= data.Receipts[i].ThumbnailData #" style="max-height:35px;" />*@
                                #} #
                            </div>
                            <a id="delete-thumbnail-icon" class="delete-thumbnail" style="color:black;float:left;" ng-click="deleteFileClicked(#= data.Receipts[i].DocumentId #);" ng-show="!approvedReport()"><span class="top-right wvi wvi-delete"></span></a>
                        </div>
                        # } #
                        <div style="clear:both;"></div>
                    </a>
                </div>
            </div>
        </script>
        <!-- Thumbnail View Receipts Column Directive-->
        <script type="text/x-kendo-template" id="newUploadThumbnailColumn">
            <div style="width:auto" class="row">
                @*<div style="width:auto" class="row">*@
                # for(var i = 0; i < data.Receipts.length; i++) { #
                <div class="thumbnail ng-cloak" style="text-align:center; float:left; padding-top: 10px; margin-right: 5px; margin-bottom: 5px">
                    @*<img src="#= data.receipts[i].ThumbnailData #" />*@
                    <div>
                        #if(data.Receipts[i].extension == 'PDF'){#
                        @*<img title="#= data.Receipts[i].Filename #" src="#= data.Receipts[i].ThumbnailData #" style="max-height:145px;" />*@
                        <span title="#= data.Receipts[i].Filename #" style="font-size: 50px; color: black" class="wvi wvi-file-pdf-regular"></span>
                        #}else if (data.Receipts[i].extension == 'DOC' || data.Receipts[i].extension == 'DOCX'){#
                        <span title="#= data.Receipts[i].Filename #" style="font-size: 50px; color: black" class="wvi wvi-file-word-regular"></span>
                        #}else if (data.Receipts[i].extension == 'CSV' || data.Receipts[i].extension == 'XLS' || data.Receipts[i].extension == 'XLSX'){#
                        <span title="#= data.Receipts[i].Filename #" style="font-size: 50px; color: black" class="wvi wvi-excel-logo"></span>
                        #}else if (data.Receipts[i].extension == 'PPT' || data.Receipts[i].extension == 'PPTX'){#
                        <span title="#= data.Receipts[i].Filename #" style="font-size: 50px; color: black" class="wvi wvi-file-powerpoint-regular"></span>
                        #}else if (data.Receipts[i].extension == 'TXT' || data.Receipts[i].extension == 'ZIP'){#
                        <span title="#= data.Receipts[i].Filename #" style="font-size: 50px; color: black" class="wvi wvi-file-image-regular"></span>
                        #}else{#
                        <img title="#= data.Receipts[i].Filename #" src="#= data.Receipts[i].ThumbnailData #" style="max-height:145px;" />
                        #} #
                    </div>
                    <span style="white-space: nowrap;">
                        <a title="#= data.Receipts[i].Filename #" href="#= data.Receipts[i].url #" class="au-target" style="max-width:70px; width:70px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;">#= data.Receipts[i].Filename # </a>
                    </span>
                    <a id="delete-thumbnail" class="delete-thumbnail" style="color:black" ng-click="deleteFileClicked(#= data.Receipts[i].DocumentId #);" ng-show="!approvedReport()"><span class="wvi wvi-delete"></span></a>
                </div>
                # } #
                <div style="clear:both;"></div>
                @*</div>*@
            </div>
        </script>

        <script type="text/x-kendo-template" id="templateListViewFunction">
            <div class="containerCardsFunction">
                <div id="card" style="display:grid; width: 220px; grid-template-columns: 90px 20px 110px; border-style: solid; border-color: lightgray; border-width: thin; align-items: center">
                    <div style="width: 90px; font-size: 13px;">
                        <div>#:percentage#%</div>
                        <div style="padding-top: 4px; padding-bottom:4px">$#= kendo.toString(Amount, "n2")#</div>
                    </div>
                    <div style="width: 20px; padding-top:35px; padding-left: 5px; padding-right: 5px; padding-bottom: 35px; width: 10px">
                        <div style="background-color: #:color#; height: 10px"></div>
                    </div>
                    <div style="width: 100px; font-size: 13px;">
                        <div style="text-align:left; padding-left: 10px" title="#:Function#">#:Function#</div>
                    </div>
                </div>
            </div>
            <style>
                .containerCardsFunction {
                    float: left;
                    position: relative;
                    width: 220px;
                    height: 80px;
                    padding: 10px;
                    border: none;
                }
            </style>
        </script>


        <script type="text/x-kendo-template" id="templateListViewJob">
            <div class="containerCards">
                <div id="card" style="display:grid; width: 250px; height: 80px; grid-template-columns: 90px 20px 140px; border-style: solid; border-color: lightgray; border-width: thin; align-items: center">
                    <div style="width: 90px; font-size: 13px;">
                        <div>#:percentage#%</div>
                        <div style="padding-top: 4px; padding-bottom:4px">$#= kendo.toString(Amount, "n2")#</div>
                    </div>
                    <div style="width: 20px; padding-top:35px; padding-left: 5px; padding-right: 5px; padding-bottom: 35px; width: 10px">
                        <div style="background-color: #:color#; height: 10px"></div>
                    </div>
                    <div style="width: 130px; font-size: 13px;">
                        <div style="text-align:left; padding-left: 10px; max-width:125px; width: 125px; overflow: hidden;" title="#:Function#"><span style="text-overflow:ellipsis">#:Function#</span></div>
                    </div>
                </div>
            </div>
            <style>
                .containerCards {
                    float: left;
                    position: relative;
                    width: 250px;
                    height: 80px;
                    padding: 10px;
                    border: none;
                }
            </style>
        </script>


        <script type="text/x-kendo-template" id="template">
            <div class="refreshBtnContainer" style="float:left;">

                <!-- Add New Report Button -->
                <button tabindex="-1" type="button" class="k-button wv-icon-button wv-add-new btn-sm" ng-click="addNewRecord()" title="Add Row" ng-class="{'k-state-disabled': approvedReport() || selectedViewGroup() || isNew() }" ng-disabled=" approvedReport() || selectedViewGroup() || isNew()"><span class='glyphicon wvi wvi-navigate-plus'></span></button>

                <!-- Copy Row Button -->
                <button tabindex="-1" type="button" class="k-button wv-icon-button wv-copy btn-sm" ng-click="copyRecord()" ng-class="{'k-state-disabled': !reportDetailsSelectedRow() || approvedReport() }" ng-disabled="!reportDetailsSelectedRow() || approvedReport()" title="Copy Row"><span class='glyphicon wvi wvi-copy'></span></button>
                @*<button id="cancelButton" class="wv-icon-button k-button wv-cancel btn-sm" ng-click="cancelClick()" ng-class="{'k-state-disabled': !hasDirtyRows || approvedReport() }" ng-disabled="!hasDirtyRows || approvedReport()" title="Cancel"><span class="wvi wvi-sign-forbidden"></span></button>*@

                <!-- Delete Row Button -->
                <button tabindex="-1" type="button" class="k-button wv-icon-button wv-cancel btn-sm" ng-click="deleteRecordtest()" ng-class="{'k-state-disabled': !reportDetailsSelectedRow() || approvedReport() }" ng-disabled="!reportDetailsSelectedRow() || approvedReport()" title="Delete Row"><span class="glyphicon wvi wvi-delete"></span></button>

                <!-- Column Settings Button -->
                <a tabindex="-1" id="showColumn"></a>

                <button tabindex="-1" type="button" class="k-button wv-icon-button wv-copy btn-sm" ng-click="exportToExcel()" title="Export To Excel"><span class='glyphicon wvi wvi-spreadsheet-sum'></span></button>

            </div>



            <div style="margin-left: auto; margin-right: 3px">


                <!-- Standard View Toggle -->
                @*<a tabindex="-1" href="\\#" class="k-link k-button k-button-icon" ng-class="{'k-state-disabled': selectedViewMode == 0 }" id="receiptView" title="Standard View" ng-click="hasReceipViewButton()"><img src="../../Images/Icons/Grey/256/text.png" /></a>*@
                <button tabindex="-1" href="\\#" class="k-button wv-icon-button wv-neutral" ng-class="{'k-state-disabled': selectedViewMode == 1 }" id="defaultView" title="Standard View" ng-click="defaultViewButton()"><span class='glyphicon wvi wvi-text'></span></button>@*receipt_book*@

                <!-- Thumbnail View Toggle -->
                <button tabindex="-1" href="\\#" class="k-button wv-icon-button wv-neutral" ng-class="{'k-state-disabled': selectedViewMode == 2 }" id="thumbnailView" title="Thumbnail View" ng-click="thumbnailView()"><span class='glyphicon wvi wvi-photos'></span></button>

                <!-- Group View Toggle -->
                @*<button tabindex="-1" href="\\#" class="k-button wv-icon-button wv-neutral" ng-class="{'k-state-disabled': selectedViewMode == 3 }" id="jobView" title="Group By Job View" ng-click="jobGroupButton()"><span class='glyphicon wvi wvi-elements3'></span></button>*@

                <!-- View Chart Toggle -->
                <button tabindex="-1" href="\\#" class="k-button wv-icon-button wv-neutral" ng-class="{'k-state-disabled': selectedViewMode == 4 }" id="chartView" title="Chart View" ng-click="viewChart()"><span class='glyphicon wvi wvi-chart_pie'></span></button>
                @*&nbsp;&nbsp;

                    Chart:

                    <div data-overflow="auto" class="k-button-group">
                        <a href tabindex="0" class="k-toggle-button k-button k-group-start k-state-active" data-group="toggleGroup" id="toggleOdd" data-overflow="auto" style="margin: 0 0 0 -5px;">Cards</a>
                        <a href tabindex="0" class="k-toggle-button k-button k-group-end" data-group="toggleGroup" id="toggleAll" data-overflow="auto" style="margin: 0 0 0 -5px;">Grid</a>
                    </div>*@

            </div>



            <div class="clear-fix"></div>
        </script>

        <!-- Another Receipt Configuration -->
        <script type="text/x-kendo-template" id="inlineUploadFile">
            <div class="wv-tokens-wrap">
                # for(var i = 0; i < data.Receipts.length; i++) { #
                <div class="wv-token background-color-sidebar" style="overflow:hidden; height:30px; padding-left: 10px; border-radius: 5px !important">
                    @*<div class="au-target wv-token-badge document-image" title="">#= data.Receipts[i].extension #</div>*@
                    <span>
                        <a title="#= data.Receipts[i].Filename #" href="#= data.Receipts[i].url #" class="au-target" style="max-width:110px; display:inline-block; text-overflow:ellipsis; overflow:hidden; color: white; white-space: nowrap;">#= data.Receipts[i].Filename #</a>
                    </span>
                    <a title="Click to Delete" ng-click="deleteFileClicked(#= data.Receipts[i].DocumentId #); $event.stopPropagation();" ng-show="!approvedReport()" class="wv-token-action background-color-sidebar au-target" style="border-left: 0px !important; padding-left: 0px !important; padding-right: 0px !important">
                        <span class="k-icon k-i-close" style="color:white"></span>
                    </a>
                </div>
                #} #
            </div>
        </script>
        <!-- Another Receipt Configuration -->
        <script type="text/x-kendo-template" id="inlineUploadFileOthers">
            <div class="wv-tokens-wrap">
                <div class="wv-token" style="overflow:hidden; height:30px; ">
                    <div class="au-target wv-token-badge document-image" title="">#= data.extension #</div>
                    <span>
                        <a title="#= data.Filename #" href="#= data.url #" class="au-target" style="max-width:110px; display:inline-block; text-overflow:ellipsis; overflow:hidden;">#= data.Filename #</a>
                    </span>
                    <a title="Click to Delete" ng-click="deleteFileClicked(#= data.DocumentId #); $event.stopPropagation();" class="wv-token-action au-target">
                        <span class="k-icon k-i-close"></span>
                    </a>
                </div>
            </div>
        </script>
        <!-- Another Receipt Configuration -->
        <script type="text/x-kendo-template" id="thumbnailUploadFile">
            <div style="width:205px;">
                <div class="thumbnail ng-cloak" style="width:160px;text-align:center; float:left;">
                    <div class="ng-cloak">
                        #if(data.receipts[0].extension == 'PDF'){#
                        <a title="#= data.receipts[0].Filename #" href="#= data.receipts[0].url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-file-pdf-regular"></span></a>
                        #}else if (data.receipts[0].extension == 'DOC' || data.receipts[0].extension == 'DOCX'){#
                        <a title="#= data.receipts[0].Filename #" href="#= data.receipts[0].url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-file-word-regular"></span></a>
                        #}else if (data.receipts[0].extension == 'CSV' || data.receipts[0].extension == 'XLS' || data.receipts[0].extension == 'XLSX'){#
                        <a title="#= data.receipts[0].Filename #" href="#= data.receipts[0].url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-excel-logo"></span></a>
                        #}else if (data.receipts[0].extension == 'PPT' || data.receipts[0].extension == 'PPTX'){#
                        <a title="#= data.receipts[0].Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-file-powerpoint-regular"></span></a>
                        #}else if (data.receipts[0].extension == 'TXT'){#
                        <a title="#= data.receipts[0].Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-file-regular"></span></a>
                        #}else if (data.receipts[0].extension == 'ZIP'){#
                        <a title="#= data.receipts[0].Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-file-regular"></span></a>
                        #}else{#
                        <a title="#= data.receipts[0].Filename #" href="#= data.receipts[0].url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><img src="#= data.receipts[0].ThumbnailData #" /></a>
                        #}#
                    </div>
                    <span style="white-space: nowrap;">
                        <a title="#= data.Receipts[0].Filename #" href="#= data.Receipts[0].url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;">#= data.Receipts[0].Filename # </a>
                    </span>
                    <a class="delete-thumbnail" ng-click="deleteFileClicked(#= data.Receipts[0].DocumentId #); $event.stopPropagation();"><span class="wvi wvi-delete"></span></a>
                </div>
                <div style="clear:both;"></div>
            </div>
        </script>
        <!-- Another Receipt Configuration -->
        <script type="text/x-kendo-template" id="thumbnailUploadFileOther">
            <div class="thumbnail ng-cloak" style="width:160px;text-align:center;">
                <span class="ng-cloak">
                    #if(data.extension == 'PDF'){#
                    <a title="#= data.Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-file-pdf-regular"></span></a>
                    #}else if (data.extension == 'DOC' || data.extension == 'DOCX'){#
                    <a title="#= data.Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-file-word-regular"></span></a>
                    #}else if (data.extension == 'CSV' || data.extension == 'XLS' || data.extension == 'XLSX'){#
                    <a title="#= data.Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-excel-logo"></span></a>
                    #}else if (data.extension == 'PPT' || data.extension == 'PPTX'){#
                    <a title="#= data.Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-file-powerpoint-regular"></span></a>
                    #}else if (data.extension == 'TXT'){#
                    <a title="#= data.Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-file-image-regular"></span></a>
                    #}else if (data.extension == 'ZIP'){#
                    <a title="#= data.Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><span style="font-size: 18px" class="wvi wvi-file-regular"></span></a>
                    #}else{#
                    <a title="#= data.Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;"><img src="#= data.ThumbnailData #" /></a>
                    #}#
                </span>
                <a class="delete-thumbnail" ng-click="deleteFileClicked(#= data.DocumentId #); $event.stopPropagation();"><span class="wvi wvi-delete"></span></a>
            </div>
        </script>
        <!--k-button wv-icon-button wv-neutral -->
        <script>
            var dateChanged = false;
            var descriptionChanged = false;
            var _scope = null;


            function aureliaSavetest() {
                _scope.saveClick(true);
            }
            /*
             *
             *   This calls the eval on the description input field, calls Expense Report JS , saveAvailable() function, evals the date and descrption input, enables Save button
             *
             */
            function DescriptionChange() {
                dateChanged = true
                //_scope.saveAvailable() = true;
            }

            function DetailChange() {
                dateChanged = true;
                //_scope.saveAvailable() = true;
            }

            //var copiedExpenseReport = 'alek';
            function closeUploadModalAndRefresh(invoiceNumber) {
                $("#uploadReceiptsDialog").ejDialog("close");
                //var dialog = $("#uploadwindow").data("kendoWindow");
                //setTimeout(function () {
                //    dialog.close();
                //}, 1000);

                _scope.refreshClick();

                //window.location.href = window.appBase + "Employee/ExpenseReports/NewExpenseReport?invoice=" + invoiceNumber;
            }

            function closeUploadModal(invoiceNumber) {
                $("#uploadReceiptsDialog").ejDialog("close");

                _scope.refreshClick();
            }

            function closeExpenseReportSubmitOptionsDialog(invoiceNumber) {
                $("#expenseSubmitOptionsDialog").ejDialog("close");
                if (invoiceNumber != null && invoiceNumber != 'undefined') {
                    if (window.location.href.includes("invoice=new") === true) {
                        refreshOnSave(invoiceNumber, "");
                    } else {
                        window.location.href = window.appBase + "Employee/ExpenseReports/NewExpenseReport?invoice=" + invoiceNumber;
                    }                    
                }
            }

            function closeExpenseReportCopyDialog() {
                $("#expenseReportCopyDialog").ejDialog("close");
            }

            function closeCopyDialogAndReloadReport(invoiceNumber) {

                $("#expenseReportCopyDialog").ejDialog("close");

                window.location.href = window.appBase + "Employee/ExpenseReports/NewExpenseReport?invoice=" + invoiceNumber;
            }

            function closePrintDialog(url) {
                $("#expenseReportPrintOptDialog").ejDialog("close");
            }

            function openNewEntryDialog() {
                var url = 'Employee/ExpenseReports/NewExpenseReport?invoice=new&empcode=' + initEmployee.Code;
                OpenRadWindow('New Expense Report', url);
            }

            function closeImportDialogAndReloadReport(invoiceNumber, importrows) {
                $("#expenseReportImportDialog").ejDialog("close");

                //var dialog = $("#importwindow").data("kendoWindow");
                //setTimeout(function () {
                //    dialog.close();
                //}, 1000);

                _scope.importrows = importrows;

                if (_scope.importrows.length > 0) {

                    _scope.refreshGridonNew();

                } else {
                    _scope.refreshClick();
                }

            }

            function closeExpenseReportReceiptsDialogAndReloadReport(invoiceNumber) {
                _scope.refreshClick();
            }

            function refreshOnSave(invoiceNumber, description) {
                var url = 'Employee/ExpenseReports/NewExpenseReport?invoice=new&empcode=' + initEmployee.Code;
                var newUrl = window.appBase + "Employee/ExpenseReports/NewExpenseReport?invoice=" + invoiceNumber
                var windowTitle = 'EX ' + invoiceNumber + " - " + description;
                OpenRadWindowUpdate(windowTitle, url, newUrl);
            }

            function getParameterByName(name) {

                var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
                return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
            }

            window.addEventListener("dragover", function (e) {
                e = e || event;
                e.preventDefault();
            }, false);

            window.addEventListener("drop", function (e) {
                e = e || event;
                e.preventDefault();
            }, false);


            $(document).ready(function () {
                $("#receiptView").css("background-color", "#ebebeb");

                //Set the Report Date to Today if new expense report
                if (getParameterByName('invoice') == "new") {
                    var todayDate = kendo.date.today();
                    $("#ExpenseReportDate").data("kendoDatePicker").value(todayDate);

                    $("#ExpenseReportDate").data("kendoDatePicker").trigger("change");
                } else {
                    resizeGrid();
                }

                $('#ExpenseReportDate').data("kendoDatePicker").wrapper.attr("tabindex", 1);

                $('#ExpenseReportDate').data("kendoDatePicker").bind("change", function () {
                    var value = this.value();
                    dateChanged = true;
                });

                var grid = $("#ExpenseReportsGrid").data("kendoGrid");
                $("#showColumn").kendoColumnMenu({
                    filterable: false,
                    sortable: false,
                    dataSource: grid.dataSource,
                    columns: grid.columns,
                    owner: grid,
                    open: (e) => {
                        if (e.container.find('li[role="menuitemcheckbox"]:nth-child(14)').length > 0) {
                            e.container.find('li[role="menuitemcheckbox"]:nth-child(1)').find('.k-link.k-menu-link').hide();
                            e.container.find('li[role="menuitemcheckbox"]:nth-child(2)').find('.k-link.k-menu-link').hide();
                            e.container.find('li[role="menuitemcheckbox"]:nth-child(3)').find('.k-link.k-menu-link').hide();
                            e.container.find('li[role="menuitemcheckbox"]:nth-child(5)').find('.k-link.k-menu-link').hide();
                            e.container.find('li[role="menuitemcheckbox"]:nth-child(6)').find('.k-link.k-menu-link').hide();
                            e.container.find('li[role="menuitemcheckbox"]:nth-child(12)').find('.k-link.k-menu-link').hide();
                            e.container.find('li[role="menuitemcheckbox"]:nth-child(13)').find('.k-link.k-menu-link').hide();
                            e.container.find('li[role="menuitemcheckbox"]:nth-child(14)').find('.k-link.k-menu-link').hide();
                            e.container.find('li[role="menuitemcheckbox"]:nth-child(15)').find('.k-link.k-menu-link').hide();
                        }
                    }
                });


                $('#descriptionField').on('change', () => {
                    dateChanged = true;
                });

                $('#descriptionField').on('keydown', (e) => {
                    var keyCode = e.keyCode || e.which;
                    dateChanged = true;

                    if (keyCode == 9) {
                        _scope.saveAvailableOnChange(_scope.isNew(), true)
                    }

                });

                $('#detailField').on('change', () => {
                    dateChanged = true;
                });

                $('#detailField').on('keydown', (e) => {
                    var keyCode = e.keyCode || e.which;
                    dateChanged = true;

                    if (keyCode == 9) {
                        _scope.saveAvailableOnChange(_scope.isNew(), true)
                    }

                });

                $("#panelbar").kendoPanelBar({
                    expand: onExpand,
                    collapse: onCollapse
                }).data("kendoPanelBar");

                ResizeExpenseReportGrid();

                $("span.k-icon.k-i-more-vertical").replaceWith('<button tabindex="-1" class="k-button wv-icon-button wv-neutral"><span class="wvi wvi-table-selection-column"></span></button>');
            });

            function onExpand(e) {
                setTimeout(() => {
                    $(window).trigger('resize', false);
                }, 200);
            }

            function onCollapse(e) {
                setTimeout(() => {
                    $(window).trigger('resize', true);
                }, 300);
            }

            $('body').keyup(function (e) {
            });

            function ResizeExpenseReportGrid() {
                var bottom = $('#ExpenseReportsGrid').offset().top;
                var viewHeight = $(window).height();
                $('#ExpenseReportsGrid').height(viewHeight - bottom - 10);

                if ($("div[style='display: none;'].k-grouping-header").length !== 0) {
                    $("div[style='display: none;'].k-grouping-header").css({ "height": "0px", "padding": "0px" });
                } else {
                    $("div[style='display: none;'].k-grouping-header").css({ "height": "49.5px", "padding": "10 0 10 0" });
                }

                $('#ExpenseReportsGrid').data("kendoGrid").resize();
            }
            function unSavedChanges() {
                return _scope.saveAvailable();
            }

            $(window).resize((e) => {
                ResizeExpenseReportGrid();
                setTimeout(() => {
                    var upload = $("#uploadReceiptsDialog");
                    if (upload) {
                        upload.ejDialog("refresh");
                    }

                    var importdlg = $("#expenseReportImportDialog");
                    if (importdlg){
                        importdlg.ejDialog("refresh");
                    }

                }, 250);
            });

            $(document).on('keyup', 'body', function (event) {
                var keycode = (event.keyCode ? event.keyCode : event.which);
                if (keycode == '45') {
                    _scope.addNewRecord();
                }
            });

        </script>

        <div class="row" style="display:none">
            <div class="col-sm-12">
                {{expenseReportHeader | json }}
            </div>
            <div class="col-md-12 mt-2">
                {{gridData | json }}
            </div>
            <div class="col-md-12" style="padding-top:50px;">
                {{reportDetailsList | json }}
            </div>
        </div>
        <div class="row" style="display:none;">
            <div class="col-12">
                <button ng-click="getGridDataJson()">grid data --- </button>  quantity: {{columnSettings}}
            </div>
            <div class="col-12">
                {{testGridData}}
            </div>
            <div class="col-12">
                dirty - {{hasDirtyRows}}
            </div>
        </div>

        @code
            Dim SettingsDialog = Html.EJ().Dialog("expenseSubmitOptionsDialog")
            SettingsDialog.Title("Submit Expense Report Options")
            SettingsDialog.ShowOnInit(False)
            SettingsDialog.ContentType("iframe")
            SettingsDialog.Render()

            Dim CopyDialog = Html.EJ().Dialog("expenseReportCopyDialog")
            CopyDialog.Title("Copy Expense Report")
            CopyDialog.ShowOnInit(False)
            CopyDialog.ContentType("iframe")
            CopyDialog.Render()

            Dim PrintOptDialog = Html.EJ().Dialog("expenseReportPrintOptDialog")
            PrintOptDialog.Title("Print Expense Report")
            PrintOptDialog.ShowOnInit(False)
            PrintOptDialog.ContentType("iframe")
            PrintOptDialog.Render()

            Dim ImportDialog = Html.EJ().Dialog("expenseReportImportDialog")
            ImportDialog.Title("Import data")
            ImportDialog.ShowOnInit(False)
            ImportDialog.ContentType("iframe")
            ImportDialog.Render()


            Dim receiptsDialog = Html.EJ().Dialog("receiptsDialog")
            receiptsDialog.Title("Advantage Receipts")
            receiptsDialog.ShowOnInit(False)
            receiptsDialog.ContentType("iframe")
            receiptsDialog.Render()

            Dim UploadReceiptsDialog = Html.EJ().Dialog("uploadReceiptsDialog")
            UploadReceiptsDialog.Title("Advantage Receipt Manager")
            UploadReceiptsDialog.ShowOnInit(False)
            UploadReceiptsDialog.ContentType("iframe")
            UploadReceiptsDialog.Render()
            UploadReceiptsDialog.Height("100%")

        End Code

        <script type="text/x-kendo-template" id="uploadCellTemplate">
            <input name="AsyncDocuments"
                   id="AsyncDocuments#=data#"
                   rowId="#=data#"
                   type="file"
                   kendo-upload
                   k-validation="{allowedExtensions: ['.jpg', '.jpeg', '.png', '.bmp', '.gif', '.csv', '.doc', '.docx', '.pdf', '.ppt', '.pptx', '.txt', '.xls', '.xlsx', '.zip']}"
                   k-async="{ saveUrl: 'UploadReceipts', removeUrl: 'remove', autoUpload: true }"
                   k-upload="onUpload"
                   k-localization="{ select: '+', dropFilesHere: '' }"
                   k-success="onSuccess"
                   k-on-error="onError" />
        </script>


        <!--Dialog -->
        <div id="uploaddialog" style="display:none">
            <nav>
                <div class="container-fluid">
                    <div class="navbar-header">
                        <span class="navbar-brand">View</span>
                    </div>
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="#" ng-click="createUpdateClickNone()">Create</a></li>
                        <li> <a href="#" ng-click="existingUpdateClick()">Existing</a></li>
                        <li> <a href="#"> Existing2</a></li>
                    </ul>
                </div>
            </nav>
            <div id="example" class="k-content">
                <input name="AsyncDocuments" id="AsyncDocuments" type="file" />
                <script type="text/x-kendo-template" id="template1">
                    <tr class="uploadImage"></tr>
                </script>
                <div class="demo-section k-content wide">
                    <div class="wrapper">
                        <table id="products" class="tableUpdate">
                            <tr>
                                <th></th>
                            </tr>
                        </table>
                        <div class="dropZoneElement" title="Place item here">
                            <div class="textWrapper">
                                <p> <span>+</span>Add Image</p>
                                <p class="dropImageHereText">Drop image here to upload</p>
                            </div>
                        </div>
                    </div>
                </div>
                <script>

                </script>
                <div>
                    <button ng-click="createUpdateClick()" class="btn btn-primary right">Save</button>
                </div>
                <style>
                    .dropZoneElement {
                        position: relative;
                        display: inline-block;
                        background-color: #f8f8f8;
                        border: 1px solid #c7c7c7;
                        width: 230px;
                        height: 110px;
                        text-align: center;
                    }

                    .textWrapper {
                        position: absolute;
                        top: 50%;
                        transform: translateY(-50%);
                        width: 100%;
                        font-size: 24px;
                        line-height: 1.2em;
                        font-family: Arial,Helvetica,sans-serif;
                        color: #000;
                    }

                    .dropImageHereText {
                        color: #c7c7c7;
                        text-transform: uppercase;
                        font-size: 12px;
                    }

                    .uploadImage {
                        float: left;
                        position: relative;
                        margin: 0 10px 10px 0;
                        padding: 0;
                    }

                        .uploadImage img {
                            width: 110px;
                            height: 110px;
                        }

                    .wrapper:after {
                        content: ".";
                        display: block;
                        height: 0;
                        clear: both;
                        visibility: hidden;
                    }
                </style>
            </div>
        </div>

        @*<div id="uploadwindow"></div>*@
        @*<div id="importwindow"></div>*@
    </div>
