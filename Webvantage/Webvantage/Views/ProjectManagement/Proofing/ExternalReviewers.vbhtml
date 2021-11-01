@Code
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code
<div>
    <div style="margin-top: -6px !important;">
        @Html.Partial("_ExternalReviewersGrid")
    </div>
</div>
<script>
</script>
@Scripts.Render("~/JScripts/proofing.externalreviewers.mvc.js")
