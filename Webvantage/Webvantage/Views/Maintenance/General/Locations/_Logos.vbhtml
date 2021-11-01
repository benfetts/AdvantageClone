@ModelType AdvantageFramework.DTO.Maintenance.General.Location.LocationLogo

@code
    Dim ShowChecked As String = Nothing
    Dim HeaderLogoShowChecked As String = Nothing
    Dim HeaderLogoHideChecked As String = Nothing

    Dim FooterLogoShowChecked As String = Nothing
    Dim FooterLogoHideChecked As String = Nothing

    ShowChecked = "checked='checked'"

    If Model.ShowHeaderLogo = "C" Then
        HeaderLogoShowChecked = ShowChecked
    Else
        HeaderLogoHideChecked = ShowChecked
    End If

    If Model.ShowFooterLogo = "C" Then
        FooterLogoShowChecked = ShowChecked
    Else
        FooterLogoHideChecked = ShowChecked
    End If

End Code

<style>
    .k-dropzone{
        min-width:290px;
    }

    .image-preview {
        border: 1px #ccc solid;
        border-radius: 4px;
        margin-left: auto;
        margin-right: auto;
        padding: 3px;
        width: calc(var(--img-preview-width) + 5px);
        height: var(--img-preview-height);
    }
</style>

<div Class="settings-section" style="">
    <h5> Header Logo Selection</h5>
    <div>
        <Table style="width:100%;">
            <thead style="">
                <tr>
                    <td style="width: 150px; vertical-align: top;padding-right:10px;"></td>
                    <td style="width: var(--img-preview-width); vertical-align: top;"></td>
                    <td style="width: 32px; vertical-align: top;"></td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="3">
                        <label class="control-label">Portrait</label>
                    </td>
                </tr>
                <tr colspan="3">
                    <td>
                        <input aria-label="files" id="headerPortraitUpload" name="PicFile" type="file" data-role="upload" multiple="multiple" autocomplete="off">
                        <span style="font-size: smaller; font-style: italic;">
                            Note:
                            The logo must be exactly 7.45 inches wide by 1.5 inches tall with 96 DPI.
                            You can place your graphics anywhere within this total image area to control horizontal and vertical spacing.
                        </span>
                    </td>
                    <td>
                        <div class="image-preview">
                            @If Model.HeaderPortrait.Image = Nothing Then
                                @<span>No Image Selected</span>
                            Else
                                @<img Class="imgPreview" src='@Model.HeaderPortrait.Image' />
                            End If
                        </div>
                    </td>
                    <td style="text-align:right;">
                        @If Model.HeaderPortrait.Image <> Nothing Then
                            @<button id="deleteHeaderPortrait" onclick="DeleteLocationImage(event, '@Model.LocationId', 1)" Class="wv-icon-button k-button wv-cancel"><span Class="glyphicon glyphicon-remove" title="Delete Logo"></span></button>
                        Else
                            @<span></span>
                        End If
                    </td>
                </tr>                
                <tr>
                    <td colspan="3">
                        <label class="control-label">Landscape</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input aria-label="files" id="headerLandscapeUpload" name="PicFile" type="file" data-role="upload" multiple="multiple" autocomplete="off">
                        <span style="font-size: smaller; font-style: italic;">
                            Note:
                            The logo must be exactly 9.95 inches wide by 1.5 inches tall with 96 DPI.
                            You can place your graphics anywhere within this total image area to control horizontal and vertical spacing.
                        </span>
                    </td>
                    <td>
                        <div style="border:1px #ccc solid;border-radius:4px;margin-left:auto;margin-right:auto;padding:3px;width:calc(var(--img-preview-width) + 5px);height:var(--img-preview-height);">
                            @If Model.HeaderLandscape.Image = Nothing Then
                                @<span>No Image Selected</span>
                            Else
                                @<img Class="imgPreview" src='@Model.HeaderLandscape.Image' />
                            End If
                        </div>
                    </td>
                    <td style="text-align:right;">
                        @If Model.HeaderLandscape.Image <> Nothing Then
                            @<button id="deleteHeaderLandscape" onclick="DeleteLocationImage(event, '@Model.LocationId', 2)" Class="wv-icon-button k-button wv-cancel"><span Class="glyphicon glyphicon-remove" title="Delete Logo"></span></button>
                        Else
                            @<span></span>
                        End If

                    </td>
                </tr>
            </tbody>
    </Table>
    <Label Class="control-label" style="color:#767676;">Header Logo Properties</Label>

    <input type="radio" value="C" id="radioHeaderShow" name="HeaderProperties" onclick="PagePropertiesChanged();" @Html.Raw(HeaderLogoShowChecked)>&nbsp;Show
    &nbsp;&nbsp;
    <input type="radio" value="N" id="radioHeaderHide" name="HeaderProperties" onclick="PagePropertiesChanged();" @Html.Raw(HeaderLogoHideChecked)>&nbsp;Hide

</div>
</div>
<div class="settings-section" style="">
    <h5>Footer Logo Selection</h5>
    <div>
        <table style="width:100%;">
            <thead style="">
                <tr>
                    <td style="width: 150px; vertical-align: top;padding-right:10px;"></td>
                    <td style="width: var(--img-preview-width); vertical-align: top;"></td>
                    <td style="width: 32px; vertical-align: top;"></td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="3">
                        <label class="control-label">Portrait</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input aria-label="files" id="footerPortraitUpload" name="PicFile" type="file" data-role="upload" multiple="multiple" autocomplete="off">
                        <span style="font-size: smaller; font-style: italic;">
                            Note:
                            The logo must be exactly 7.45 inches wide by 1.5 inches tall with 96 DPI.
                            You can place your graphics anywhere within this total image area to control horizontal and vertical spacing.
                        </span>
                    </td>
                    <td>
                        <div style="border:1px #ccc solid;border-radius:4px;margin-left:auto;margin-right:auto;padding:3px;width:calc(var(--img-preview-width) + 5px);height:var(--img-preview-height);">
                            @If Model.FooterPortrait.Image = Nothing Then
                                @<span>No Image Selected</span>
                            Else
                                @<img Class="imgPreview" src='@Model.FooterPortrait.Image' />
                            End If
                        </div>
                    </td>
                    <td style="text-align:right;">
                        @If Model.FooterPortrait.Image <> Nothing Then
                            @<button id="deleteFooterPortrait" onclick="DeleteLocationImage(event, '@Model.LocationId', 3)" Class="wv-icon-button k-button wv-cancel"><span Class="glyphicon glyphicon-remove" title="Delete Logo"></span></button>
                        Else
                            @<span></span>
                        End If
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <label class="control-label">Landscape</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input aria-label="files" id="footerLandscapeUpload" name="PicFile" type="file" data-role="upload" multiple="multiple" autocomplete="off">
                        <span style="font-size: smaller; font-style: italic;">
                            Note:
                            The logo must be exactly 9.95 inches wide by 1.5 inches tall with 96 DPI.
                            You can place your graphics anywhere within this total image area to control horizontal and vertical spacing.
                        </span>
                    </td>
                    <td>
                        <div style="border:1px #ccc solid;border-radius:4px;margin-left:auto;margin-right:auto;padding:3px;width:calc(var(--img-preview-width) + 5px);height:var(--img-preview-height);">
                            @If Model.FooterLandscape.Image = Nothing Then
                                @<span>No Image Selected</span>
                            Else
                                @<img Class="imgPreview" src='@Model.FooterLandscape.Image' />
                            End If
                        </div>
                    </td>
                    <td style="text-align:right;">
                        @If Model.FooterLandscape.Image <> Nothing Then
                            @<button id="deleteFooterLandscape" onclick="DeleteLocationImage(event, '@Model.LocationId', 4)" Class="wv-icon-button k-button wv-cancel"><span Class="glyphicon glyphicon-remove" title="Delete Logo"></span></button>
                        Else
                            @<span></span>
                        End If
                    </td>
                </tr>
            </tbody>
        </table>
        <label class="control-label" style="color:#767676;">Footer Logo Properties</label>

        <input type="radio" value="C" id="radioFooterShow" name="FooterProperties" onclick="PagePropertiesChanged();" @Html.Raw(FooterLogoShowChecked)>&nbsp;Show
        &nbsp;&nbsp;
        <input type = "radio" value="N" id="radioFooterHide" name="FooterProperties" onclick="PagePropertiesChanged();" @Html.Raw(FooterLogoHideChecked)>&nbsp;Hide
    </div>
</div>

<script>
    $(document).ready(function () {
        LocationDetail.ID = '@Model.LocationID';        

        $("#headerPortraitUpload").kendoUpload({
            async: {
                saveUrl: "Locations/UploadLocationImage?LocationId=" + LocationDetail.ID + "&LocationLogoTypeID=1",
                autoUpload: true
            },
            success: onFileUploadSucess,
            error: onFileUploadError
        });

        $("#headerLandscapeUpload").kendoUpload({
            async: {
                saveUrl: "Locations/UploadLocationImage?LocationId=" + LocationDetail.ID + "&LocationLogoTypeID=2",
                autoUpload: true
            },
            success: onFileUploadSucess,
            error: onFileUploadError
        });

        $("#footerPortraitUpload").kendoUpload({
            async: {
                saveUrl: "Locations/UploadLocationImage?LocationId=" + LocationDetail.ID + "&LocationLogoTypeID=3",
                autoUpload: true
            },
            success: onFileUploadSucess,
            error: onFileUploadError
        });        

        $("#footerLandscapeUpload").kendoUpload({
            async: {
                saveUrl: "Locations/UploadLocationImage?LocationId=" + LocationDetail.ID + "&LocationLogoTypeID=4",
                autoUpload: true
            },
            success: onFileUploadSucess,
            error: onFileUploadError
        });
    });


</script>
