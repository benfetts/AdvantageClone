@ModelType Webvantage.Models.AlertModel
@Code

End Code
<div class="k-content">
    @Model.AlertID
    @Model.AlertEntity.Subject
    <h4>Description</h4>
    <textarea id="description" rows="10" cols="30" style="height:440px;">
        @Model.AlertEntity.Body
    </textarea>
</div>
<script>
    $(document).ready(function () {
        $("#description").kendoEditor({
            resizable: {
                content: true,
                toolbar: true
            }
        });
    });
</script>