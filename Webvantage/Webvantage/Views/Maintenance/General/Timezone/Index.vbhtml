@ModelType AdvantageFramework.ViewModels.Maintenance.General.TimezoneSetupViewModel
@Code

    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>

End Section

<style>
    .e-widget {
        max-height: 500px !important;
    }
</style>
<div style="padding: 20px;">

    <div  style="display:inline-block; width: 45%;">
        <div>
            Database Server Time Zone:
        </div>
        <div>
            @Html.EJ().DropDownList("DatabaseServerTimeZone").Width("100%").Datasource(Model.Timezones).DropDownListFields(Function(F)
                                                                                                                               Return F.Value("Id").Text("StandardName")
                                                                                                                           End Function).Value(Model.DatabaseServerTimezoneID).ClientSideEvents(Sub(evt)
                                                                                                                                                                                                    evt.Change("saveTimeZone")
                                                                                                                                                                                                End Sub)
        </div>
    </div>
    <div  style="display:inline-block; width: 45%; padding-left: 20px;">
        <div>
            Agency Time Zone:
        </div>
        <div>
            @Html.EJ().DropDownList("AgencyTimeZone").Width("100%").Datasource(Model.Timezones).DropDownListFields(Function(F)
                                                                                                                       Return F.Value("Id").Text("StandardName")
                                                                                                                   End Function).Value(Model.AgencyTimezoneID).ClientSideEvents(Sub(evt)
                                                                                                                                                                                    evt.Change("saveTimeZone")
                                                                                                                                                                                End Sub)
        </div>
    </div>

</div>
<script>
    function saveTimeZone() {

        var databaseServerTimezoneId = "";
        var agencyTimezoneId = "";

        databaseServerTimezoneId = $("#DatabaseServerTimeZone")[0].value + "";
        agencyTimezoneId = $("#AgencyTimeZone")[0].value + "";
        /*
        if (agencyTimezoneId == "-1" && databaseServerTimezoneId != "-1") {
            $("#DatabaseServerTimeZone").ejDropDownList("setSelectedValue", "-1");
            databaseServerTimezoneId = "-1";
            return false;
        }
        if (agencyTimezoneId != "-1" && databaseServerTimezoneId == "-1") {
            $("#AgencyTimeZone").ejDropDownList("setSelectedValue", "-1");
            agencyTimezoneId = "-1";
            return false;
        }
        */
        //if ((agencyTimezoneId == "-1" && databaseServerTimezoneId == "-1") || (agencyTimezoneId != "-1" && databaseServerTimezoneId != "-1")) {
            var timezoneData = {
                DatabaseServerTimeZoneID: databaseServerTimezoneId,
                AgencyTimeZoneID: agencyTimezoneId
            };
           //console.log(timezoneData);
            $.post({
                url: window.appBase + "Maintenance/General/Timezone/SaveTimezone",
                dataType: "json",
                data: timezoneData
            }).always(function (response) {
                if (response) {
                   //console.log(response);
                    if (response.Success && response.Success === true) {
                        //showKendoAlert("Sign out and back in to see changes")
                    }
                    if (response.Success && response.Success === false && response.Message) {
                        showKendoAlert("Error in action: databaseServerTimezoneId" + "\n" + response.Message);
                    }
                }
            });
        //}
    }
</script>
