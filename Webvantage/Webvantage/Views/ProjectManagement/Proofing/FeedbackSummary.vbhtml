@Code
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code
<style>
    nav ul {
        max-height: 200px;
        width: 50%;
    }
    nav ul {
        overflow: hidden;
        overflow-y: scroll;
    }
    .indent {
        margin-left: 18px;
    }
</style>
<h3>Conceptshare Maintenance</h3>
<div>
    <div style="margin-top: 10px !important; display: block; display: none !important;">
        <h4 style="margin-bottom: 4px;">Backup Assets</h4>
        <div style="margin-bottom: 4px; margin-left: 10px;">
            This will download assets from ConceptShare into Advantage database and repository.  
            <ul>
                <li>Assets will be attached to the related Alert record as well as being saved at the Job/Component level in Document Repository.</li>
                <li>Successful downloads are being logged to prevent duplicates.</li>
                <li>This will try to backup all assets, not just the ones for this job.</li>
                <li>This process is asyncronous and will run as long as you don't close Webvantage.  You don't have to stay on this page.</li>
            </ul>     
            <fieldset>
                Backup details:
                <nav>
                    <ul id="stats">
                    </ul>
                </nav>
            </fieldset>       
        </div>
        <div style="margin: 20px 0px 20px 10px;">
            <button id="backupAssetsButton" class="k-button k-primary" tabindex="-1" style="width: 200px;" onclick="backupAssets()">Start Backup</button>
            <button id="backupAssetsRefreshButton" class="k-button" tabindex="-1" style="width: 200px; margin-left: 15px;" onclick="backupAssetsRefresh()">Refresh</button>
        </div>
    </div>
    <div style="margin-top: 10px !important; display: block;">
        <h4 style="margin-bottom: 4px;">Download Feedback Summary</h4>
        <div style="margin-bottom: 4px; margin-left: 10px;">
            Click the "Download" button to retrieve a Feedback Summary from ConceptShare.
            <ul>
                <li>After you get the "Save file" dialog, the "Last Received" column will record the date and time.</li>
                <li>You can also click the "Mark as received" button to log the latest date/time the report was saved.</li>
                <li style="display: none;">If the download doesn't work or you get a timeout message, try putting in an email address below and then clicking "download".  You will get an email with a link to download the summary.</li>
                <li style="display: none;">Do not try to download too many at once.  It just won't work and will crash the CS server for the client.</li>
                <li style="display: block;"><input id="emailAddress" type="email" class="e-textbox" style="width: 400px;" placeholder="Email address" /></li>
            </ul>
        </div>
        @Html.Partial("_FeedbackSummaryGrid")
    </div>
</div>
<script>
    var baseUrl = window.appBase + "ProjectManagement/Proofing/";
    var progressShowing = false;
    // For todays date;
    Date.prototype.today = function () { 
        return ((this.getDate() < 10)?"0":"") + this.getDate() +"/"+(((this.getMonth()+1) < 10)?"0":"") + (this.getMonth()+1) +"/"+ this.getFullYear();
    }

    // For the time now
    Date.prototype.timeNow = function () {
         return ((this.getHours() < 10)?"0":"") + this.getHours() +":"+ ((this.getMinutes() < 10)?"0":"") + this.getMinutes() +":"+ ((this.getSeconds() < 10)?"0":"") + this.getSeconds();
    }
    function showProgress() {
        if (progressShowing == false) {
            kendo.ui.progress($("body"), true);
            progressShowing = true;
        }
    }        
    function hideProgress() {
        if (progressShowing == true) {
            window.setTimeout(function () {
                kendo.ui.progress($("body"), false);
                progressShowing = false;
            }, 250);
        }
    }
    function backupAssets() {
        var data = {
        }
        $.post({
            url: baseUrl + "StartAssetBackup",
            dataType: "json",
            data: data
        }).always(function (result) {
            if (result) {
            }
        });
    }
    function backupAssetsRefresh() {
        showProgress();
        var data = {
        }
        $.get({
            url: baseUrl + "LoadAssetBackupStats",
            dataType: "json",
            data: data
        }).always(function (result) {
            hideProgress();
            if (result) {
                var newDate = new Date();
                $("#stats").append('<li style="color: green;">Refreshed at:  ' + newDate.today() + ', ' + newDate.timeNow() + '</li>');
                $("#stats").append('<li class="indent">Total reviews in database:  ' + result.Stats.TotalReviewsDB + '</li>');
                $("#stats").append('<li class="indent">Total assets added to backup:  ' + result.Stats.TotalAssetsDB + '</li>');
                $("#stats").append('<li class="indent">Total assets according to CS:  ' + result.Stats.TotalAssetsCS + '</li>');
                $("#stats").append('<li class="indent">Total assets that successfully backed up:  ' + result.Stats.TotalBackedUpDB + '</li>');
                $("#stats").append('<li class="indent">Total assets that failed to backup:  ' + result.Stats.TotalFailedDB + '</li>');
            }
        });
    }
    $(document).ready(function () {
    //    backupAssetsRefresh();
    });
</script>
