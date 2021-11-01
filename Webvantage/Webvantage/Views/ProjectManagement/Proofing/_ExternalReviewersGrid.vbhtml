@ModelType Generic.List(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer)
<div style="margin-bottom: 4px;">
    <span style="font-size: smaller; font-style: italic;">* <a onclick="clearFilters()" style="cursor: pointer;">Clear filter(s)</a> to show all External Reviewers.</span>
</div>
<div id="proofingExternalReviewerGrid"></div>
<script type="text/x-kendo-template" id="gridToolbarTemplate">
    <button id="saveButton" class="k-button wv-icon-button wv-save" title="Save changes"><span class='wvi wvi-floppy-disk'></span></button>
    <button id="cancelButton" class="wv-icon-button k-button wv-cancel" title="Cancel"><span class='wvi wvi-sign-forbidden'></span></button>
</script>
<script>
</script>
@Scripts.Render("~/JScripts/proofing._externalreviewersgrid.mvc.min.js")
