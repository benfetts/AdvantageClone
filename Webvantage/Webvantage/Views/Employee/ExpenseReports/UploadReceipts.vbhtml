@Code ViewData("Title") = "Manage Receipts"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
    ViewData("IsAngular") = True
End Code
<style>

    .k-button.wv-icon-button {
        min-width: unset !important;
    }
    /*.k-dropzone.all-receipts {min-height:80px;}
        .new-receipts .k-dropzone {min-height:15px; border-bottom:5px; padding:5px; line-height:25px;}*/

    .thumbnail {
        margin-bottom: 0;
        position: relative;
        width: 150px;
    }


    .delete-thumbnail {
        position: absolute;
        top: 2px;
        right: 5px;
    }

    .thumbnail > img {
        height: 90px;
        width: 150px;
        object-fit: contain;
    }

    .cell-dropzone {
        min-height: 30px;
        height: 30px !important;
        width: 56px;
    }

    .semi-transparent {
        opacity: 0.5;
    }

    .target-over {
        background-color: #00BCD4;
    }

    .k-dropzone {
        background: white;
        line-height: 30px;
        max-height: 40px;
        min-height: 30px;
        text-align: center;
        border: none;
    }

    .k-dropzone-active {
        border: dashed 2px #2196F3;
    }

    li .k-dropzone {
        padding: unset;
        background-color: #E5E5E5;
        border: none;
        text-align: center;
    }

    li .k-upload {
        border: none;
    }

    li .k-upload-button {
        padding: 0;
        height: 32px;
        width: 140px;
    }

    div.k-dropzone em {
        visibility: hidden !important;
        display: none !important;
    }

    .k-dropzone em {
        display: none !important;
    }

    /*.k-upload-files .k-reset {display:none !important;}*/

    /*.k-upload .k-upload-button {
            margin: 0px;
        }*/

    /*.k-dropzone {
            border: 1px solid #ebebeb !important;
        }*/


    /*td .k-dropzone .k-upload-button{width:100%;}
        td .k-dropzone {line-height:19px; min-height:unset;}*/
    /*td .k-dropzone {
            height: 30px !important;
            min-height: unset;
            max-height: 30px !important;
            width: 30px !important;
            min-width: 30px !important;
            padding: 0px;
            line-height: 25px;
        }

        td .k-dropzone-active {
            border: 1px solid yellow;
        }*/

    .drag-drop-hover {
        background-color: #e5e5e5;
    }

    /* td .k-dropzone-active.k-dropzone-hovered {
                border: 2px solid green !important;
            }*/


    #grid {
        border-width: 0;
        height: 100%; /* DO NOT USE !important for setting the Grid height! */
    }
</style>

<script src="~/Scripts/ExpenseReports/uploadReceipts.js"></script>



<div ng-app="angUploadReceipts" ng-controller="UploadReceiptsController">

    <div class="content padding-x">
        <div class="container-fluid">

            <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable" style="width: 100%; background-color: #E5E5E5; padding: 8px 0px 8px 0px; border-bottom: 1px solid #CCC; box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05); margin: 5px auto; overflow: auto;">
                <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">

                    <li style="padding-right: 3px !important;">
                        <button id="saveButton" class="k-button wv-icon-button wv-save" ng-click="saveClick()" title="Save" ng-class="{'k-state-disabled': !saveCancelEnabled }" ng-disabled="!saveCancelEnabled"><span class='wvi wvi-floppy-disk'></span></button>
                    </li>

                    <li style="padding-right: 3px !important;">
                        <button id="cancelButton" class="wv-icon-button k-button wv-cancel" ng-click="cancelClick()" title="Cancel" ng-class="{'k-state-disabled': !saveCancelEnabled }" ng-disabled="!saveCancelEnabled"><span class='wvi wvi-sign-forbidden'></span></button>
                    </li>

                    <li id="submitListItem" style="padding-right: 3px !important;">
                        <button id="includeRowsWithReceipts" class="k-button wv-icon-button " ng-class="{'wv-add-new': includeRowsWithReceipts, 'wv-neutral':!includeRowsWithReceipts}" ng-click="includeRowsClick()" style="width: 170px !important;" title="Include Rows with Receipts"><span style="font-size: 12px;">Include Rows with Receipts</span></button>
                    </li>

                    <li id="submitListItem" style="padding-right: 3px !important;">
                        <button id="showThumbnail" class="k-button wv-icon-button " ng-class="{'wv-add-new': showThumbnail,'wv-neutral': !showThumbnail }" ng-click="showThumbnailClick()" style="width: 110px !important;" title="Show Thumbnail"><span style="font-size: 12px;">Show Thumbnail</span></button>
                    </li>

                    <li id="submitListItem" style="padding-right: 3px !important;">
                        <button id="hideReceiptsApplied" class="k-button wv-icon-button " ng-class="{'wv-add-new': hideReceiptsApplied, 'wv-neutral':!hideReceiptsApplied}" ng-click="hideReceiptsAppliedClick()" style="width: 140px !important;" title="Hide Receipts Applied"><span style="font-size: 12px;">Hide Receipts Applied</span></button>
                    </li>

                    @*<li id="submitListItem" style="padding:0">
            <button id="showUnassignedReceiptsApplied" class="k-button wv-icon-button " ng-class="{'wv-add-new': hideReceiptsApplied, 'wv-neutral':!hideReceiptsApplied}" ng-click="hideReceiptsAppliedClick()" style="width: 140px !important;" title="Show Unassigned Receipts"><span style="font-size: 12px;">Show Unassigned Receipts</span></button>
        </li>*@
                    <li style="padding-right: 3px !important;" ng-show="!approvedReport()">
                        <input name="AsyncDocuments"
                               id="AsyncDocuments"
                               type="file"
                               title="Select Receipts or Drag and Drop into Top Section or Line Items." />

                    </li>
                    <li style="padding-right: 3px !important;">
                        <button tabindex="-1" class="k-button wv-icon-button " ng-click="printReceipts()" ng-class="{'k-state-disabled': !uploadedImagesCount() }" ng-disabled="!uploadedImagesCount()" style="width: 70px !important;" title="Print"><span style="font-size: 12px;">Print</span></button>
                    </li>
                    <li style="padding-right: 3px !important;">
                        <button tabindex="-1" class="k-button wv-icon-button " ng-click="downloadReceipts()" ng-class="{'k-state-disabled': !uploadedImagesCount() }" ng-disabled="!uploadedImagesCount()" style="width: 70px !important;" title="Download"><span style="font-size: 12px;">Download</span></button>
                    </li>
                </ul>
            </div>
            <div>
                <ul id="panelbarUnassigned" ng-show="showUnassignedReceiptsPanel" style="margin-bottom:5px;">
                    <li id="receiptsFilesUnassigned" class="k-state-active">
                        <span id="Files" class="k-link k-state-selected">Receipts (Unassigned)</span>
                        <div id="dropZoneElementUnassigned" style="padding-top: 5px; padding-bottom: 5px; min-height: 100px;" ng-show="showThumbnail">
                            <div style="float:left; margin-left:7px;margin-bottom: 5px" ng-repeat="receipt in allReceiptsUnassigned">
                                <div ng-if="!hideReceiptsApplied || (hideReceiptsApplied && receipt.RowId == 0)">
                                    <div class="thumbnail ng-cloak" style=" text-align:center;padding-top:10px; " id="thumbnail_{{::receipt.DocumentId}}" kendo-draggable k-hint="draggableHint" k-dragstart="onDragStart" k-dragend="onDragEnd">

                                        <!-- Directive for deciding icon based on file extension -->
                                        <div class="ng-cloak" ng-switch="receipt.extension">
                                            <span ng-switch-when="PDF" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-pdf-regular"></span>
                                            <span ng-switch-when="DOC" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-word-regular"></span>
                                            <span ng-switch-when="DOCX" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-word-regular"></span>
                                            <span ng-switch-when="CSV" style="font-size: 50px; width:50px;  margin: 5px; color: black" class="wvi wvi-excel-logo"></span>
                                            <span ng-switch-when="XLS" style="font-size: 50px; width:50px;  margin: 5px; color: black" class="wvi wvi-excel-logo"></span>
                                            <span ng-switch-when="XLSX" style="font-size: 50px; width:50px; margin: 5px; color: black" class="wvi wvi-excel-logo"></span>
                                            <span ng-switch-when="PPT" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-powerpoint-regular"></span>
                                            <span ng-switch-when="PPTX" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-powerpoint-regular"></span>
                                            <span ng-switch-when="TXT" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-regular"></span>
                                            <span ng-switch-when="ZIP" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-regular"></span>
                                            <img ng-switch-default src="{{receipt.ThumbnailData}}" style="max-height:120px;" />
                                        </div>

                                        <span style="white-space: nowrap;">
                                            <a title="{{receipt.Filename}}" href="{{receipt.url}}" class="au-target" style="max-width:80px; width:80px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;">{{receipt.Filename}}</a>
                                        </span>
                                        <a class="delete-thumbnail" ng-click="deleteHeaderThumbnailUnassignedClick(receipt.DocumentId)" ng-show="!approvedReport()"><span class="wvi wvi-delete" style="color:black; margin-left:2px"></span></a>

                                    </div>
                                </div>


                            </div>
                            <div style="clear:both;"></div>
                        </div>
                        <div id="dropZoneElementFilenameUnassigned" style="padding:5px; min-height: 100px;" ng-show="!showThumbnail" ng-disabled="approvedReport()" ng-class="{'k-state-disabled': approvedReport() }">
                            <div style="float:left; margin-left:7px;" ng-repeat="receipt in allReceiptsUnassigned">
                                <div ng-if="!hideReceiptsApplied || (hideReceiptsApplied && receipt.RowId == 0)">
                                    <div style="width:auto; padding-right: 12px; padding-bottom: 5px" class="row">
                                        <div class="wv-tokens-wrap" id="filename_{{::receipt.DocumentId}}" kendo-draggable k-hint="draggableHint" k-dragstart="onDragStart" k-dragend="onDragEnd" style="vertical-align: middle" ng-disabled="approvedReport()">
                                            <div class="background-color-sidebar" style="overflow:hidden; height:30px; padding-left: 10px; border-radius: 5px">
                                                <a title="{{receipt.Filename}}" href="{{receipt.url}}" style="height: 30px;max-width:110px; display:inline-block; text-overflow:ellipsis; overflow:hidden; color: white; padding-right: 10px;white-space: nowrap; padding-top:5px">{{receipt.Filename}}</a>

                                                <a title="Click to Delete" ng-click="deleteHeaderThumbnailUnassignedClick(receipt.DocumentId)" ng-show="!approvedReport()" class="wv-token-action background-color-sidebar au-target" style="border-left: 0px !important; padding-left: 0px !important; padding-right: 0px !important; padding-top:5px !important">
                                                    <span class="k-icon k-i-close" style="color:white"></span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="clear:both;"></div>
                        </div>
                    </li>
                </ul>
            </div>

            <div>
                <ul id="panelbar" class="" hidden="hidden">
                    <li id="receiptsFiles" class="k-state-active">
                        <span id="Files" class="k-link k-state-selected">Receipts</span>
                        <div id="dropZoneElement" style="padding-top: 5px; padding-bottom: 5px; min-height: 100px" ng-show="showThumbnail">                            
                            <div style="float:left; margin-left:7px;margin-bottom: 5px" ng-repeat="receipt in allReceipts">
                                <div ng-if="!hideReceiptsApplied || (hideReceiptsApplied && receipt.RowId == 0)">
                                    <div class="thumbnail ng-cloak" style=" text-align:center;padding-top:10px; " id="thumbnail_{{::receipt.DocumentId}}" kendo-draggable k-hint="draggableHint" k-dragstart="onDragStart" k-dragend="onDragEnd">

                                        <!-- Directive for deciding icon based on file extension -->
                                        <div class="ng-cloak" ng-switch="receipt.extension">
                                            <span ng-switch-when="PDF" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-pdf-regular"></span>
                                            <span ng-switch-when="DOC" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-word-regular"></span>
                                            <span ng-switch-when="DOCX" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-word-regular"></span>
                                            <span ng-switch-when="CSV" style="font-size: 50px; width:50px;  margin: 5px; color: black" class="wvi wvi-excel-logo"></span>
                                            <span ng-switch-when="XLS" style="font-size: 50px; width:50px;  margin: 5px; color: black" class="wvi wvi-excel-logo"></span>
                                            <span ng-switch-when="XLSX" style="font-size: 50px; width:50px; margin: 5px; color: black" class="wvi wvi-excel-logo"></span>
                                            <span ng-switch-when="PPT" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-powerpoint-regular"></span>
                                            <span ng-switch-when="PPTX" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-powerpoint-regular"></span>
                                            <span ng-switch-when="TXT" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-regular"></span>
                                            <span ng-switch-when="ZIP" style="font-size: 50px; width:50px; color: black" class="wvi wvi-file-regular"></span>
                                            <img ng-switch-default src="{{receipt.ThumbnailData}}" style="max-height:120px;" />
                                        </div>

                                        <span style="white-space: nowrap;">
                                            <a title="{{receipt.Filename}}" href="{{receipt.url}}" class="au-target" style="max-width:80px; width:80px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;">{{receipt.Filename}}</a>
                                        </span>
                                        <a class="delete-thumbnail" ng-click="deleteHeaderThumbnailClick(receipt.DocumentId)" ng-show="!approvedReport()"><span class="wvi wvi-delete" style="color:black; margin-left:2px"></span></a>

                                    </div>
                                </div>


                            </div>
                            <div style="clear:both;"></div>
                        </div>
                        <div id="dropZoneElementFilename" style="padding:5px; min-height: 100px" ng-show="!showThumbnail" ng-disabled="approvedReport()" ng-class="{'k-state-disabled': approvedReport() }">                            
                            <div style="float:left; margin-left:7px;" ng-repeat="receipt in allReceipts">
                                <div ng-if="!hideReceiptsApplied || (hideReceiptsApplied && receipt.RowId == 0)">
                                    <div style="width:auto; padding-right: 12px; padding-bottom: 5px" class="row">
                                        <div class="wv-tokens-wrap" id="filename_{{::receipt.DocumentId}}" kendo-draggable k-hint="draggableHint" k-dragstart="onDragStart" k-dragend="onDragEnd" style="vertical-align: middle" ng-disabled="approvedReport()">
                                            <div class="background-color-sidebar" style="overflow:hidden; height:30px; padding-left: 10px; border-radius: 5px">
                                                @*<div class="au-target wv-token-badge document-image" title="">#= data.Receipts[i].extension #</div>*@

                                                <a title="{{receipt.Filename}}" href="{{receipt.url}}" style="height: 30px;max-width:110px; display:inline-block; text-overflow:ellipsis; overflow:hidden; color: white; padding-right: 10px;white-space: nowrap; padding-top:5px">{{receipt.Filename}}</a>

                                                <a title="Click to Delete" ng-click="deleteHeaderThumbnailClick(receipt.DocumentId)" ng-show="!approvedReport()" class="wv-token-action background-color-sidebar au-target" style="border-left: 0px !important; padding-left: 0px !important; padding-right: 0px !important; padding-top:5px !important">
                                                    <span class="k-icon k-i-close" style="color:white"></span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>
                            <div style="clear:both;"></div>
                        </div>
                    </li>
                </ul>
            </div>


            <!--

    Directive for the receipts at the top of the page

      -->


            <div class="row" style="padding-top: 5px">
                <div id="gridcontainer" class="col-sm-12">
                    <div id="ExpenseReportsGrid" kendo-grid="grid" k-options="mainGridOptions" k-on-change="handleChange(data, dataItem, columns)"></div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/x-kendo-template" id="receiptThumnail">
        <div class="thumbnail" style="width:160px">
            <img src="#= data #" />
        </div>
    </script>

    <!--


        --Template for Upload Input,  drag and drop functionality


    -->
    <script type="text/x-kendo-template" id="uploadCellTemplate">
        <input name="AsyncDocuments"
               id="AsyncDocuments#=data#"
               rowId="#=data#"
               type="file"
               kendo-upload
               k-validation="{allowedExtensions: ['.jpg', '.jpeg', '.png', '.bmp', '.gif', '.csv', '.doc', '.docx', '.pdf', '.ppt', '.pptx', '.txt', '.xls', '.xlsx', '.zip']}"
               k-async="{ saveUrl: 'UploadReceipts', removeUrl: 'remove', autoUpload: true }"
               k-localization="{ select: 'Select Receipts', dropFilesHere: 'Drop receipts here to upload' }"
               k-upload="onUpload"               
               show-file-list="false"
               @*k-drop-zone="getZone(#=data#)"*@
               k-success="onSuccess" />
        @*<div class="dropDrownZone_#=data#" id="dropDrownZone_#=data#">
                my zone;
            </div>*@
    </script>



    <script type="text/x-kendo-template" id="dropCellTemplate">
        <div class="k-dropzone cell-dropzone" id="drop_#=data#" kendo-droptarget k-dragenter="onDragEnter" k-dragleave="onDragLeave" k-drop="onDrop">

        </div>
    </script>


    <script type="text/x-kendo-template" id="newInlineUploadFile">
        <style>
            .top-right {
                position: absolute;
                top: 3px;
                right: -5px;
                /*font-size: 8px;
                font-weight: bold;
                cursor: pointer;*/
            }

            .wv-container {
                position: relative;
                text-align: center;
            }
        </style>


        <!--- Standard Grid View -->
        <div style="width:auto" class="row">
            # for(var i = 0; i < data.Receipts.length; i++) { #
            <a title="#= data.Receipts[i].Filename #" href="#= data.Receipts[i].url #">
                #if(data.Receipts[i].extension == 'PDF'){#
                <div class="wv-container" style="width:48px;float:left;padding-top: 3px" title=" #=data.Receipts[i].Filename #"><span style="font-size: 35px; color: black" class="wvi wvi-file-pdf-regular"></span><div class="top-right wvi wvi-delete" title="Delete File" style="color:black" ng-click="deleteFileClicked( #= data.Receipts[i].DocumentId #, #= data.Id #); $event.stopPropagation();" ng-show="!approvedReport()"></div></div>
                #}else if (data.Receipts[i].extension == 'DOC' || data.Receipts[i].extension == 'DOCX'){#
                <div class="wv-container" style="width:48px;float:left;padding-top: 3px" title=" #=data.Receipts[i].Filename #"><span style="font-size: 35px; color: black" class="wvi wvi-file-word-regular"></span><div class="top-right wvi wvi-delete" title="Delete File" style="color:black" ng-click="deleteFileClicked( #= data.Receipts[i].DocumentId #, #= data.Id #); $event.stopPropagation();" ng-show="!approvedReport()"></div></div>
                #}else if (data.Receipts[i].extension == 'CSV' || data.Receipts[i].extension == 'XLS' || data.Receipts[i].extension == 'XLSX'){#
                <div class="wv-container" style="width:48px;float:left;padding-top: 3px" title=" #=data.Receipts[i].Filename #"><span style="font-size: 35px; color: black" class="wvi wvi-excel-logo"></span><div class="top-right wvi wvi-delete" title="Delete File" style="color:black" ng-click="deleteFileClicked( #= data.Receipts[i].DocumentId #, #= data.Id #); $event.stopPropagation();" ng-show="!approvedReport()"></div></div>
                #}else if (data.Receipts[i].extension == 'TXT' || data.Receipts[i].extension == 'ZIP'){#
                <div class="wv-container" style="width:48px;float:left;padding-top: 3px" title=" #=data.Receipts[i].Filename #"><span style="font-size: 35px; color: black" class="wvi wvi-file-regular"></span><div class="top-right wvi wvi-delete" title="Delete File" style="color:black" ng-click="deleteFileClicked( #= data.Receipts[i].DocumentId #, #= data.Id #); $event.stopPropagation();" ng-show="!approvedReport()"></div></div>
                #}else if (data.Receipts[i].extension == 'PPT' || data.Receipts[i].extension == 'PPTX'){#
                <div class="wv-container" style="width:48px;float:left;padding-top: 3px" title=" #=data.Receipts[i].Filename #"><span style="font-size: 35px; color: black" class="wvi wvi-file-powerpoint-regular"></span><div class="top-right wvi wvi-delete" title="Delete File" style="color:black" ng-click="deleteFileClicked( #= data.Receipts[i].DocumentId #, #= data.Id #); $event.stopPropagation();" ng-show="!approvedReport()"></div></div>
                #}else{#
                <div class="wv-container" style="width:48px;float:left;padding-top: 3px" title=" #=data.Receipts[i].Filename #"><span style="font-size: 35px; color: black" class="wvi wvi-file-image-regular"></span><span class="top-right wvi wvi-delete" title="Delete File" style="color:black" ng-click="deleteFileClicked( #= data.Receipts[i].DocumentId #, #= data.Id #); $event.stopPropagation();" ng-show="!approvedReport()"></span></div>
                #} } #
            </a>
        </div>





    </script>
    <!--    -->
    <script type="text/x-kendo-template" id="inlineUploadFile" ng-disabled="approvedReport()" ng-class="{'k-state-disabled': approvedReport() }">
        <div style="width:auto" class="row">
            <div class="wv-tokens-wrap" ng-disabled="approvedReport()" ng-class="{'k-state-disabled': approvedReport() }">
                # for(var i = 0; i < data.Receipts.length; i++) { #
                <div class="wv-token background-color-sidebar" style="overflow:hidden; height:30px; padding-left: 10px; border-radius: 5px !important">
                    @*<div class="au-target wv-token-badge document-image" title="">#= data.Receipts[i].extension #</div>*@
                    
                        <a title="#=data.Receipts[i].Filename #" href="#= data.Receipts[i].url #" class="au-target" style="max-width:110px; display:inline-block; text-overflow:ellipsis; overflow:hidden; color: white; white-space: nowrap; padding-right: 10px">#=data.Receipts[i].Filename #</a>
                    
                    <a title="Click to Delete" ng-click="deleteFileClicked(#= data.Receipts[i].DocumentId #, #= data.Id #)" ng-show="!approvedReport()" class="wv-token-action background-color-sidebar au-target" style="border-left: 0px !important; padding-left: 0px !important; padding-right: 0px !important">
                        <span class="k-icon k-i-close" style="color:white"></span>
                    </a>
                </div>
                #} #
            </div>
        </div>
    </script>

    <script type="text/x-kendo-template" id="inlineUploadFileOthers">
        <div class="wv-tokens-wrap">
            <div class="wv-token" style="overflow:hidden; height:30px;">
                <div class="au-target wv-token-badge document-image" title="">#= data.extension #</div>
                <span style="white-space: nowrap;">
                    <a title=" #=data.Filename #" href="#= data.url #" class="au-target" style="max-width:110px; display:inline-block; text-overflow:ellipsis; overflow:hidden;">#= data.Filename # </a>
                </span>
                <a title="Click to Delete" ng-click="deleteFileClicked(#= data.DocumentId #, #= data.rowId #); $event.stopPropagation();" class="wv-token-action au-target">
                    <span class="k-icon k-i-close"></span>
                </a>
            </div>
        </div>
    </script>

    <!--

        --For actual Grid Thumbnail

    -->
    <script type="text/x-kendo-template" id="thumbnailUploadFile">
        <div style="width:auto;" class="row">
            # for(var i = 0; i < data.Receipts.length; i++) { #
            <div class="thumbnail ng-cloak" style="text-align:center; float:left;padding-top:10px; margin-right: 5px">
                <div>
                    #if(data.Receipts[i].extension == 'PDF'){#
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
                    <img title="#= data.Receipts[i].Filename #" src="#= data.Receipts[i].ThumbnailData #" style="max-height:145px;  color: black" />
                    #} #
                </div>
                <span style="white-space: nowrap;">
                    <a title="#= data.Receipts[i].Filename #" href="#= data.Receipts[i].url #" class="au-target" style="max-width:70px; width:70px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;">#= data.Receipts[i].Filename # </a>
                </span>
                <a class="delete-thumbnail" style="color:black" ng-click="deleteFileClicked(#= data.Receipts[0].DocumentId #, #= data.Id #)" ng-show="!approvedReport()"><span class="wvi wvi-delete"></span></a>
            </div>
            @*<a ng-show="#= data.receiptsCount > 1 #" class="k-link k-button k-button-icon" ng-class="{'k-primary': #= data.showAllUploadedImages #} " ng-click="toggleExpandAllReceipts(#= data.receipts[0].RowId #); $event.stopPropagation();" style="width: calc(1.72em + 10px); float:right; margin-top:40px;"><span class='wviimport wviimport-documents_empty'></span></a>*@
            # } #
            <div style="clear:both;"></div>
        </div>

    </script>

    <script type="text/x-kendo-template" id="thumbnailUploadFileOther">
        <div class="thumbnail ng-cloak" style="width:160px;text-align:center;">
            <div>
                #if(data.extension == 'PDF'){#
                <span title="#= data.Filename #" style="font-size: 50px" class="wvi wvi-file-pdf-regular"></span>
                #}else if (data.extension == 'DOC' || data.extension == 'DOCX'){#
                <span title="#= data.Filename #" style="font-size: 50px" class="wvi wvi-file-word-regular"></span>
                #}else if (data.extension == 'CSV' || data.extension == 'XLS' || data.extension == 'XLSX'){#
                <span title="#= data.Filename #" style="font-size: 50px" class="wvi wvi-excel-logo"></span>
                #}else if (data.extension == 'PPT' || data.extension == 'PPTX'){#
                <span title="#= data.Filename #" style="font-size: 50px" class="wvi wvi-file-powerpoint-regular"></span>
                #}else if (data.extension == 'TXT' || data.extension == 'ZIP'){#
                <span title="#= data.Filename #" style="font-size: 50px" class="wvi wvi-file-image-regular"></span>
                #}else{#
                <img title="#= data.Filename #" src="#= data.ThumbnailData #" style="max-height:50px;" />
                #} #
            </div>
            <span style="white-space: nowrap;">
                <a title="#= data.Filename #" href="#= data.url #" class="au-target" style="max-width:160px; display:inline-block; text-overflow:ellipsis; overflow:hidden; margin-top:3px;">#= data.Filename #</a>
            </span>
            <a class="delete-thumbnail" ng-click="deleteFileClicked(#= data.DocumentId #, #= data.rowId #)"><span class="wvi wvi-delete"></span></a>
        </div>
    </script>

</div>
@*<input name="files" id="files" type="file" />*@

<script>
    @code

        Dim employeeJson = ViewBag.EmployeeJson
        Dim expReportDetails As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail) = ViewBag.ExpenseReportDetails

        Dim functionCodes = ViewBag.FunctionCodes
        Dim paymentTypes = ViewBag.PaymentTypes
        Dim jobs = ViewBag.Jobs
        Dim appVariables = ViewBag.AppVars
        Dim canAdd = ViewBag.CanAdd
        Dim canUpdate = ViewBag.CanUpdate
        Dim canPrint = ViewBag.CanPrint
        Dim custom1Sec = ViewBag.Custom1
        Dim custom2Sec = ViewBag.Custom2
        Dim userCode = ViewBag.UserCode
        Dim defaultPaymentType = ViewBag.DefaultPaymentType


        Dim uploadedImagesJson = ViewBag.UploadedImages
        Dim unassignedImagesJson = ViewBag.UnassignedImages
        Dim data = Newtonsoft.Json.JsonConvert.SerializeObject(expReportDetails)
        Dim user = Newtonsoft.Json.JsonConvert.SerializeObject(userCode)

        Dim uploadedImagesList = Newtonsoft.Json.JsonConvert.SerializeObject(uploadedImagesJson.Data)
        Dim unassignedImagesList = Newtonsoft.Json.JsonConvert.SerializeObject(unassignedImagesJson.Data)
        Dim employee = Newtonsoft.Json.JsonConvert.SerializeObject(employeeJson.Data)
        Dim functioncodesList = Newtonsoft.Json.JsonConvert.SerializeObject(functionCodes.Data)
        Dim paymenttypesList = Newtonsoft.Json.JsonConvert.SerializeObject(paymentTypes.Data)
        Dim jobsList = Newtonsoft.Json.JsonConvert.SerializeObject(jobs.Data)
        Dim appvars = Newtonsoft.Json.JsonConvert.SerializeObject(appVariables.Data)
        Dim canAddItem = Newtonsoft.Json.JsonConvert.SerializeObject(canAdd)
        Dim canUpdateItem = Newtonsoft.Json.JsonConvert.SerializeObject(canUpdate)
        Dim canPrintItem = Newtonsoft.Json.JsonConvert.SerializeObject(canPrint)
        Dim custom1SecItem = Newtonsoft.Json.JsonConvert.SerializeObject(custom1Sec)
        Dim custom2SecItem = Newtonsoft.Json.JsonConvert.SerializeObject(custom2Sec)
        Dim defaultPaymentTypeItem = Newtonsoft.Json.JsonConvert.SerializeObject(defaultPaymentType)



    End Code
        var invoiceNumber = @Html.Raw(ViewBag.InvoiceNumber);
        var status = @Html.Raw(ViewBag.Status);
        var initAllReceipts = @Html.Raw(uploadedImagesList);
        var initAllReceiptsUnassigned = @Html.Raw(unassignedImagesList);
        var initUploadedImages = @Html.Raw(uploadedImagesList);
        var initData = @Html.Raw(data);
        var initUserCode = @Html.Raw(user);

        var initEmployee = @Html.Raw(employee);
        var initFunctionCodes = @Html.Raw(functioncodesList);
        var initPaymentTypes = @Html.Raw(paymenttypesList);
        var initJobs = @Html.Raw(jobsList);
        var initAppVars = @Html.Raw(appvars);
        var initCanAdd = @Html.Raw(canAddItem);
        var initCanUpdate = @Html.Raw(canUpdateItem);
        var initCanPrint = @Html.Raw(canPrintItem);
        var initCustom1 = @Html.Raw(custom1SecItem);
        var initCustom2 = @Html.Raw(custom2SecItem);
        var intiDefaultPaymentType = @Html.Raw(defaultPaymentType);
        var includeRowsWithReceipts = false;
        var showThumbnail = false;
        var hideReceiptsApplied = false;
        var showUnassignedReceiptsPanel = false;

        //kendo.ui.Upload.fn._supportsDrop = function () { return false; }

        function closeUploadModalAndRefresh(invoiceNumber) {
            console.log('call close window');
            //closeUploadModal

            window.parent.closeUploadModalAndRefresh(invoiceNumber);
        }

        $("#dropZoneElementFilename").kendoDropTarget({
            drop: function (e) {
                let $scope = getScope('UploadReceiptsController');
                $scope.MoveUnassignedToAssigned(e);    
            }
        });   

        $("#dropZoneElement").kendoDropTarget({
            drop: function (e) {
                let $scope = getScope('UploadReceiptsController');
                $scope.MoveUnassignedToAssigned(e);    
            }
        }); 

    
    $("#dropZoneElementFilenameUnassigned").kendoDropTarget({
        drop: function (e) {
            console.log("droppp");
        }
    }); 

        function getScope(ctrlName) {
            var sel = 'div[ng-controller="' + ctrlName + '"]';
            return angular.element(sel).scope();
        }

    function onExpand(e) {
        document.getElementById('dropZoneElement').style.display = 'block';
        document.getElementById('dropZoneElementFilename').style.display = 'block';
        setTimeout(() => {
            $(window).trigger('resize');
        }, 200);

        //resizeGrid();
        //$(window).trigger('resize');
    }

    function onCollapse(e) {
        setTimeout(() => {
            $(window).trigger('resize');
        }, 200);

        //resizeGrid();
        //$(window).trigger('resize');
    }

        //window.addEventListener("dragover", function (e) {
        //    e = e || event;
        //    e.preventDefault();
        //}, false);

        //window.addEventListener("drop", function (e) {
        //    e = e || event;
        //    e.preventDefault();
        //}, false);

        $(document).ready(function () {
            //console.log("Types in Angular");
            var $scope = getScope('UploadReceiptsController');

            $scope.includeRowsWithReceipts = false;
            $scope.showThumbnail = false;
            $scope.hideReceiptsApplied = false;
            $scope.showUnassignedReceiptsPanel = false;

            if ($scope.allReceiptsUnassigned.length > 0) {
                $scope.showUnassignedReceiptsPanel = true;
            } else {
                $scope.showUnassignedReceiptsPanel = false;
            }            

            for (var key in initAppVars) {
                if (initAppVars.hasOwnProperty(key)) {

                    window[initAppVars[key].Item1] = initAppVars[key].Item2;
                }
            }

            if (typeof window['includeRowsWithReceipts'] !== 'undefined' && window['includeRowsWithReceipts'] == 'true')  {

                $scope.includeRowsWithReceipts = true;

            }

            if (typeof window['showThumbnail'] !== 'undefined' && window['showThumbnail'] == 'true') {

                $scope.showThumbnail = true;
            }


            if (typeof window['hideReceiptsApplied'] !== 'undefined' && window['hideReceiptsApplied'] == 'true') {

                $scope.hideReceiptsApplied = true;

            }

            //$('#AsyncDocuments').kendoUpload({
            //    validation: {
            //        allowedExtensions: ['.jpg', '.jpeg', '.png', '.bmp', '.gif', '.csv', '.doc', '.docx', '.pdf', '.ppt', '.pptx', '.txt', '.xls', '.xlsx', '.zip']
            //    },
            //    async: {
            //        saveUrl: 'UploadReceipts',
            //        autoUpload: true
            //    },
            //    upload: "onUploadReportOnly",
            //    localization: { select: 'Select Receipts', dropFilesHere: 'Drop receipts here to upload' },
            //    success: "onSuccess",
            //    showFileList: false,
            //    dropZone: ".dropZoneElement"
            //});

            $("#AsyncDocuments").kendoUpload({
                async: {
                    saveUrl: 'UploadReceipts',
                    removeUrl: 'remove'                    
                },
                validation: {
                    allowedExtensions: ['.jpg', '.jpeg', '.png', '.bmp', '.gif', '.csv', '.doc', '.docx', '.pdf', '.ppt', '.pptx', '.txt', '.xls', '.xlsx', '.zip']
                },
                success: $scope.onSuccess,
                showFileList: false,
                dropZone: $scope.getDropZoneName,
                upload: (e) => {         
                    console.log(e);
                    e.data = {
                        InvoiceNumber : $scope.invoiceNumber
                    }
                },
                localization: {
                    select: 'Select Receipts',
                    dropFilesHere: ''
                },
                enabled: $scope.approvedReport                
            });


            $("#panelbar").kendoPanelBar({
                expand: onExpand,
                collapse: onCollapse
            }).data("kendoPanelBar");

            $("#panelbar").show();

            window.onresize = (e) => {
                var el = $("#panelbar");
                var bottom = el.position().top + el.outerHeight(true);
                var viewHeight = $(window).height();

                $('#gridcontainer').height(viewHeight - bottom - 10);

                var kendoGrid = $('#ExpenseReportsGrid').data("kendoGrid");
                kendoGrid.resize();
            };

            $("#panelbarUnassigned").kendoPanelBar({
                expand: onExpand,
                collapse: onCollapse
            }).data("kendoPanelBar");

            if (initAllReceiptsUnassigned.length > 0) {
                $("#panelbarUnassigned").show();
            } else {

            }                       

            window.onresize = (e) => {
                var el = $("#panelbarUnassigned");
                var bottom = el.position().top + el.outerHeight(true);
                var viewHeight = $(window).height();

                $('#gridcontainer').height(viewHeight - bottom - 10);

                var kendoGrid = $('#ExpenseReportsGrid').data("kendoGrid");
                kendoGrid.resize();
            };


        });
    

</script>

