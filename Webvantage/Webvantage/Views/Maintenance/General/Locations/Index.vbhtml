@ModelType AdvantageFramework.ViewModels.Maintenance.General.LocationViewModel
@Code ViewData("IsFullLayout") = True
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code

<style>
    :root {
        --img-preview-width: 35vw;
        --img-preview-height: 100px;
        --img-cell-preview-width: calc(img-preview-width + 50px);
    }

    .imgPreview {
        height: auto;
        width: auto;
        max-width: var(--img-preview-width);
        max-height: 100px;
        /*margin-left: auto;*/
        margin:2px;
    }

    .k-dropzone {
        min-height: 25px !important;
        line-height: 25px !important;
    }

    .k-checkbox-label {
        line-height: 10px !important;
    }

    #location-control {
        margin-bottom: 15px;
        border-radius: 4px;
        border-top-left-radius: 0px;
    }

    #logo-control {
        margin-bottom: 15px;
        border-radius: 4px;
    }

    input.readonly {
        opacity: .50;
        filter: alpha(opacity=50); /* IE<9 */
        cursor: default;
    }

    #main-toolbar {
        /*width: 1443px !important;
        margin-left: auto;
        margin-right: auto;
            */
        width: calc(80vw - 62px) !important;
        margin: 5px;
        margin-left: auto;
        margin-right: auto;
        min-width: 750px;
    }

    #settings-container {
        /*width: 1455px;
        margin: 5px auto 5px auto;        */
        width: calc(80vw - 50px) !important;
        margin: 5px;
        margin-left: auto;
        margin-right: auto;
        min-width: 760px;
    }

    #tabstrip {
        width: calc(80vw - 80px) !important;
        margin: 5px;
        margin-left: auto;
        margin-right: auto;
        min-width: 740px;
    }

    .k-tabstrip:focus {
        box-shadow: none;
    }

    .container {
        max-width: none;
        width: 100%
    }
</style>

<div class="container" style="padding-top: 3px; max-height: 875px !important;">
    <div id="main-toolbar" class="wv-bar k-toolbar k-widget k-toolbar-resizable">
        <ul class="list-inline" style="margin-bottom: 0;">
            <li style="padding-right: 0;">
                <a href="#" id="SaveChanges" title="Save Changes" role="button" class="wv-icon-button wv-save k-button k-state-disabled" disabled="true" onclick="SaveLocationDetail(null)"><span class="wvi wvi-floppy-disk"></span></a>
            </li>
            <li style="padding: 0;">
                <a href="#" id="RefreshPage" title="Refresh Page" role="button" class="wv-icon-button k-button wv-cancel k-state-disabled" disabled="true" onclick="RefreshPage()"><span class="wvi wvi-sign-forbidden"></span></a>
            </li>
            <li style="padding: 0;">
                <button id="CreateNew" class="k-button wv-icon-button wv-add-new" onclick="CreateNewLocation()" title="Add New Location"><span class="glyphicon wvi wvi-navigate-plus"></span></button>
            </li>
            <li style="padding: 0;">
                <button id="DeleteLocation" class="k-button wv-icon-button wv-cancel btn-sm" onclick="DeleteLocation()" title="Delete Location"><span class="glyphicon wvi wvi-delete"></span></button>
            </li>
        </ul>
    </div>
    <div id="settings-container" class="row" style="padding: 0px 14px 0px 14px;">
        <div class="settings-section" style="">
            <h5>Location</h5>
            <script id="dropTemplate" type="text/x-kendo-template">
                <span>
                    #:LocationNameDropDisplay(data.LocationName)#
                </span>
            </script>
            <script id="valueTemplate" type="text/x-kendo-template">
                <span>
                    #:LocationNameValueDisplay(data.LocationName)#
                </span>
            </script>
            <div style="width:400px;">
                @(Html.Kendo().DropDownList() _
                                                                                            .Name("LocationsDropDownList") _
                                                                                            .DataTextField("LocationName") _
                                                                                            .DataValueField("LocationID") _
                                                                                            .AutoWidth(True) _
                                                                                            .DataSource(
                                                                                            Sub(ds)
                                                                                                ds.Read("GetLocations", "Locations")
                                                                                            End Sub) _
                                                                                            .Events(
                                                                                            Sub(e)
                                                                                                e.Change("onLocationChange")
                                                                                            End Sub) _
                                                                                            .Filter("contains") _
                                                                                                .OptionLabel("Please Select") _
                                                                                                .HtmlAttributes(
                                                                                                    New With {.style = "width: 100%"}
                                                                                                )
                )

            </div>
        </div>
        <div id="LocationSelectedMessage" style="width:100%; text-align:center; visibility:visible;">No Location Selected.</div>
        <form id="LocationMaintenanceForm" autocomplete="off" onsubmit="return false;" style="visibility:hidden;">
            <div id="tabstrip">
                <ul>
                    <li id="locationTab" class="k-state-active" onclick="manageMainToolbar('location');">
                        Information
                    </li>
                    <li id="logosTab" onclick="manageMainToolbar('logos');">
                        Logos
                    </li>
                </ul>

                <div id="location-control">

                    @Code
                        Html.RenderPartial("_Location", Model.LocationDetails)
                    End Code

                </div>

                <div id="logo-control">
                    @Code
                        Html.RenderPartial("_Logos", Model.LocationLogo)
                    End Code
                </div>
            </div>
        </form>
        </div>
</div>

<script>
    $(document).ready(function () {

        $("#tabstrip").kendoTabStrip({
        });        

        ManageCheckboxesOnReady();        

        var dropdownlist = $("#LocationsDropDownList").data("kendoDropDownList");
        var LocationID = $("#ID").val()        

        if (LocationID == "") {
            dropdownlist.value(0)
            dropdownlist.trigger("change");
        } else {
            dropdownlist.value(LocationID);
            document.getElementById("LocationMaintenanceForm").style.visibility = "visible";
            document.getElementById("LocationSelectedMessage").style.visibility = "hidden";
        }

        

        $("#Name, #ID").keydown(function (e) {
            if (e.key == "|") {
                return false;
            }
        });

        $("#Name, #ID").focusout(function (e) {
            let LocationName = $("#Name").val();
            let LocationID = $("#ID").val();
            let newValue = "";
            let alertMsg = 'The pipe character "|" cannot be used in the Location Name or Location ID fields and has been removed.';

            if (LocationName.indexOf("|") >= 0) {         
                showKendoAlert(alertMsg);
                newValue = LocationName.replace("|", "");
                $("#Name").val(newValue);
            }

            if (LocationID.indexOf("|") >= 0) {                
                showKendoAlert(alertMsg);
                newValue = LocationID.replace("|", "");
                $("#ID").val(newValue);
            }
        });

        let locations = $("#LocationsDropDownList").data("kendoDropDownList");
        locations.bind("dataBound", dropdownlist_dataBound);
    });

    let DisabledFontColor = "#B0B0B0";
    let pageDirty = false;
    let _newLocationFlag = false;

    let LocationDetail = {
        ID: "",
        Name: "",
        Address: "",
        Address2: "",
        City: "",
        State: "",
        Zip: "",
        Phone: "",
        Fax: "",
        Email: "",
        LocationFooter: "",
        LogoLocation: "",
        PrintHeader: "",
        PrintNameHeader: "",
        PrintAddressHeader: "",
        PrintAddress2Header: "",
        PrintCityHeader: "",
        PrintStateHeader: "",
        PrintZipHeader: "",
        PrintPhoneHeader: "",
        PrintFaxHeader: "",
        PrintEmailHeader: "",
        PrintFooter: "",
        PrintNameFooter: "",
        PrintAddressFooter: "",
        PrintAddress2Footer: "",
        PrintAddress2Footer: "",
        PrintCityFooter: "",
        PrintStateFooter: "",
        PrintZipFooter: "",
        PrintPhoneFooter: "",
        PrintFaxFooter: "",
        PrintEmailFooter: "",
        LogoPath: "",
        LogoLandscapePath: "",
        FooterLogoLocation: "",
        FooterLogoPath: "",
        FooterLogoLandscape: "",
        HeaderLogoLandscapeId: "",
        HeaderLogoPortraitId: "",
        FooterLogoLandscapeId: "",
        FooterLogoPortraitId: "",
    };

    function dropdownlist_dataBound() {        
        if (LocationDetail.ID !== "") {
            this.value(LocationDetail.ID);
        }        
    }   

    function manageMainToolbar(tabId) {    
        /*if (tabId === "location") {
            $("#main-toolbar").show();
        } else {
            $("#main-toolbar").hide();
        }*/
    }

    function LocationNameValueDisplay(LocationName) {
        let toLocation = LocationName.indexOf("|");

        return LocationName.substring(0, toLocation);
    }

    function LocationNameDropDisplay(LocationName) {

        return LocationName.replace('|', ' (') + ')';
    }

    function unSavedChanges() {
        return pageDirty;
    }

    function ParentContainerSave() {
        SaveChanges();
    }

    $("#LocationMaintenanceForm").change(function (e) {      
        
        if (e.target.id !== "radioHeaderShow" && e.target.id !== "radioFooterShow" &&
            e.target.id !== "radioHeaderHide" && e.target.id !== "radioFooterHide" &&
            e.target.ariaLabel !== "files") {

            $("#SaveChanges").removeClass("k-state-disabled");
            $("#RefreshPage").removeClass("k-state-disabled");

            $("#SaveChanges").removeAttr('disabled');
            $("#RefreshPage").removeAttr('disabled');

            var dropdownlist = $("#LocationsDropDownList").data("kendoDropDownList");
            dropdownlist.enable(false);

            pageDirty = true;    
        }
    
    });

    function CleanDirtyPage() {
        $("#SaveChanges").addClass("k-state-disabled");
        $("#RefreshPage").addClass("k-state-disabled");

        $("#SaveChanges").prop('disabled', true);
        $("#RefreshPage").prop('disabled', true);

        var dropdownlist = $("#LocationsDropDownList").data("kendoDropDownList");
        dropdownlist.enable(true);

        pageDirty = false;
    }


    function PagePropertiesChanged() {       
        //$("#SaveChanges").addClass("k-state-disabled");
        //$("#RefreshPage").addClass("k-state-disabled");

        //$("#SaveChanges").prop('disabled', true);
        //$("#RefreshPage").prop('disabled', true);
        SaveLocationDetail('logos'); 
    }

    function onFileUploadError() {
        //$("#SaveChanges").addClass("k-state-disabled");
        //$("#RefreshPage").addClass("k-state-disabled");

        //$("#SaveChanges").prop('disabled', true);
        //$("#RefreshPage").prop('disabled', true);

        showKendoAlert("Unable to save the selected image.");
    }

    function DeleteLocationImage(e, LocationID, LocationLogoTypeID) {    
        let LocationImage = { LocationID: LocationID, LocationLogoTypeID: LocationLogoTypeID };

        $.ajax({
            url: '@(Url.Action("DeleteLocationImage", "Locations"))',
            type: "POST",
            dataType: "json",
            data: LocationImage,
            success: function (data) {
                $("#logo-control").load('@(Url.Action("_Logos", "Locations", Nothing, Request.Url.Scheme))?LocationID=' + $("#LocationsDropDownList").val());
                //$("#SaveChanges").addClass("k-state-disabled");
                //$("#RefreshPage").addClass("k-state-disabled");

                //$("#SaveChanges").prop('disabled', true);
                //$("#RefreshPage").prop('disabled', true);               
            },
            error: function () {
                showKendoAlert("Unable to delete the selected image.");
            }
        });
    }

    function onFileUploadSucess() {

        $("#logo-control").load('@(Url.Action("_Logos", "Locations", Nothing, Request.Url.Scheme))?LocationID=' + $("#LocationsDropDownList").val());


        //$(".k-widget.k-upload.k-header").find("ul").remove();
        //$(".k-dropzone").find("strong").remove();

        //$("#SaveChanges").addClass("k-state-disabled");
        //$("#RefreshPage").addClass("k-state-disabled");

        //$("#SaveChanges").prop('disabled', true);
        //$("#RefreshPage").prop('disabled', true);

        //var dropdownlist = $("#LocationsDropDownList").data("kendoDropDownList");
        //dropdownlist.enable(true);

        //pageDirty = false;
    }

    function ManageCheckboxesOnReady() {

        if (document.getElementById("PrintHeader").checked === false) {

            $("#printHeaderElements input:checkbox").prop("readonly", "readonly");
            $("#printHeaderElements input:checkbox").prop("disabled", true);
            $("#printHeaderElements span").css("color", DisabledFontColor);

        }

        if (document.getElementById("PrintFooter").checked === false) {

            $("#printFooterElements input:checkbox").prop("readonly", "readonly");
            $("#printFooterElements input:checkbox").prop("disabled", true);
            $("#printFooterElements span").css("color", DisabledFontColor);

        }
    }

    function RefreshPage() {
        if (pageDirty) {
            showKendoConfirm("<p>Unsaved changes will be lost, do you want to continue?<p>")
                .done(function () {
                    pageDirty = false;
                    window.location.reload();
                })
                .fail(function () {
                    return false;
                });
        } else {
            window.location.reload();
        }    
    }

    function DeleteLocation() {
        showKendoConfirm("This will permanently delete this location, continue?")
            .done(function () {
                PackageLocationEntity();
                $.ajax({
                    url: '@(Url.Action("DeleteLocation", "Locations"))',
                    type: "POST",
                    dataType: "json",
                    data: LocationDetail,
                    success: function (data) {
                        window.location.reload();
                    },
                    error: function () {
                        alert("failed");
                    }
                });
                pageDirty = false;
            })
            .fail(function () {
            });
    }

    function SaveChanges() {

        SaveLocationDetail(null);
        pageDirty = false;        
    }

    function onLocationChange(e) {
        $("#location-control").load('@(Url.Action("_Location", "Locations", Nothing, Request.Url.Scheme))?LocationID=' + $("#LocationsDropDownList").val());
        $("#logo-control").load('@(Url.Action("_Logos", "Locations", Nothing, Request.Url.Scheme))?LocationID=' + $("#LocationsDropDownList").val());    

        var tabStrip = $("#tabstrip").kendoTabStrip().data("kendoTabStrip");
        tabStrip.select(tabStrip.tabGroup.children().eq(0));
        manageMainToolbar("location");

        if ($("#LocationsDropDownList").val() == "") {
            document.getElementById("LocationMaintenanceForm").style.visibility = "hidden";
            document.getElementById("LocationSelectedMessage").style.visibility = "visible";
        } else {
            document.getElementById("LocationMaintenanceForm").style.visibility = "visible";
            document.getElementById("LocationSelectedMessage").style.visibility = "hidden";
        }


    }

    function CreateNewLocation() {

        if (pageDirty) {
            showKendoConfirm("<p>Unsaved changes will be lost, do you want to continue?<p>")
                .done(function () {
                    CreateNewLocationPageSetup();
                    CleanDirtyPage();
                })
                .fail(function () {
                    return false;
                });
        } else {
            CreateNewLocationPageSetup();
        }
    }


    function CreateNewLocationPageSetup() {
        _newLocationFlag = true;
        $("#ID").css("background-color", "white");
        $("#ID").removeAttr("disabled");    

        $("#DeleteLocation").addClass("k-state-disabled");
        $("#CreateNew").addClass("k-state-disabled");
        $("#DeleteLocation").prop('disabled', true);
        $("#DeleteLocation").prop('disabled', true);

        //var statesdropdownlist = $("#StatesDropDownList").data("kendoDropDownList");
        //statesdropdownlist.value("Please Select");

        var locationsdropdownlist = $("#LocationsDropDownList").data("kendoDropDownList");

        locationsdropdownlist.text('');
        locationsdropdownlist.enable(false);

        $("#logo-control").load('@(Url.Action("_Logos", "Locations", Nothing, Request.Url.Scheme))?LocationID=');

        $("#LocationMaintenanceForm input").val("");
        $('input:checkbox').removeAttr('checked');

        $('#PrintHeader').change();
        $('#PrintFooter').change();

        var tabStrip = $("#tabstrip").kendoTabStrip().data("kendoTabStrip");
        tabStrip.select(tabStrip.tabGroup.children().eq(0));
        tabStrip.disable(tabStrip.tabGroup.children().eq(1));

        document.getElementById("LocationMaintenanceForm").style.visibility = "visible";
        document.getElementById("LocationSelectedMessage").style.visibility = "hidden";

        $("#ID").focus();
    }


    /*FOR TESTING */
    /*$("#ID").val("123123");
    $("#Name").val("test");
    $("#Address1").val("test");
    $("#Address2").val("test");
    $("#City").val("test");
    dropdownlist.value("NC");
    $("#Zip").val("test");
    $("#Phone").val("test");
    $("#Fax").val("test");
    $("#Email").val("test");*/
    /*FOR TESTING */



    function SaveLocationDetail(tabID) {            

        let LocationID = $("#ID").val();
        let LocationName = $("#Name").val();


        if (LocationID.length <= 0 || LocationName.length <= 0) {
            showKendoAlert("Location ID and Name are required for a new location.");
            $("#ID").focus();
            return false;
        }

        PackageLocationEntity();

        if (_newLocationFlag) {
            LocationDetail.LogoLocation = 'C';
            LocationDetail.FooterLogoLocation = 'C';
            _newLocationFlag = false;
        }

        $.ajax({
            url: '@Url.Action("SaveLocationDetails", "Locations")',
            type: 'POST',
            cache: false,
            contentType: 'application/json',
            dataType: "json",

            data: JSON.stringify(LocationDetail),
            success: function (data) {
                if (tabID !== 'logos') {
                    $("#ID").css("background-color", "#E0E0E0");
                    $("#ID").prop("disabled", "disabled");

                    $("#SaveChanges").addClass("k-state-disabled");
                    $("#RefreshPage").addClass("k-state-disabled");
                    $("#CreateNew").removeClass("k-state-disabled");
                    $("#DeleteLocation").removeClass("k-state-disabled");

                    $("#SaveChanges").prop('disabled', true);
                    $("#RefreshPage").prop('disabled', true);
                    $("#CreateNew").removeAttr('disabled');
                    $("#DeleteLocation").removeAttr('disabled');

                    var dropdownlist = $("#LocationsDropDownList").data("kendoDropDownList");
                    dropdownlist.dataSource.read();
                    dropdownlist.enable(true);                                      
                    
                    var tabStrip = $("#tabstrip").kendoTabStrip().data("kendoTabStrip");
                    tabStrip.enable(tabStrip.tabGroup.children().eq(1));
                    pageDirty = false;      

                    $("#logo-control").load('@(Url.Action("_Logos", "Locations", Nothing, Request.Url.Scheme))?LocationID=' + LocationID);
                }            
            },
            error: function () {
                alert("failed");
            }
        });

    }

    function PackageLocationEntity() {

        LocationDetail.ID = $("#ID").val();
        LocationDetail.Name = $("#Name").val();
        LocationDetail.Address1 = $("#Address1").val();
        LocationDetail.Address2 = $("#Address2").val();
        LocationDetail.City = $("#City").val();
        //LocationDetail.State = $("#StatesDropDownList").val();
        LocationDetail.State = $("#State").val();
        LocationDetail.Zip = $("#Zip").val();
        LocationDetail.Phone = $("#Phone").val();
        LocationDetail.Fax = $("#Fax").val();
        LocationDetail.Email = $("#Email").val();

        LocationDetail.PrintHeader = document.getElementById("PrintHeader").checked;
        LocationDetail.PrintNameHeader = document.getElementById("PrintNameHeader").checked;
        LocationDetail.PrintAddressHeader = document.getElementById("PrintAddressHeader").checked;
        LocationDetail.PrintAddress2Header = document.getElementById("PrintAddress2Header").checked;
        LocationDetail.PrintCityHeader = document.getElementById("PrintCityHeader").checked;
        LocationDetail.PrintStateHeader = document.getElementById("PrintStateHeader").checked;
        LocationDetail.PrintZipHeader = document.getElementById("PrintZipHeader").checked;
        LocationDetail.PrintPhoneHeader = document.getElementById("PrintPhoneHeader").checked;
        LocationDetail.PrintFaxHeader = document.getElementById("PrintFaxHeader").checked;
        LocationDetail.PrintEmailHeader = document.getElementById("PrintEmailHeader").checked

        LocationDetail.PrintFooter = document.getElementById("PrintFooter").checked;
        LocationDetail.PrintNameFooter = document.getElementById("PrintNameFooter").checked;
        LocationDetail.PrintAddressFooter = document.getElementById("PrintAddressFooter").checked;
        LocationDetail.PrintAddress2Footer = document.getElementById("PrintAddress2Footer").checked;
        LocationDetail.PrintCityFooter = document.getElementById("PrintCityFooter").checked;
        LocationDetail.PrintStateFooter = document.getElementById("PrintStateFooter").checked;
        LocationDetail.PrintZipFooter = document.getElementById("PrintZipFooter").checked;
        LocationDetail.PrintPhoneFooter = document.getElementById("PrintPhoneFooter").checked;
        LocationDetail.PrintFaxFooter = document.getElementById("PrintFaxFooter").checked;
        LocationDetail.PrintEmailFooter = document.getElementById("PrintEmailFooter").checked;

        LocationDetail.LogoLocation = $("input[name='HeaderProperties']:checked").val()
        LocationDetail.FooterLogoLocation = $("input[name='FooterProperties']:checked").val()
}

</script>
