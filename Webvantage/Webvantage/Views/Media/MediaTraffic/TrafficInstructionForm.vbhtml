@ModelType Webvantage.ViewModels.MediaManager.TrafficInstructionFormViewModel
@Code
    ViewData("Title") = "Media Traffic Instruction Form"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code
@Section PageHeader
    <div class="panel-heading bg-primary">
        <div class="panel-title" style="text-align:center">
            <h2>Media Traffic Instruction From @Html.DisplayFor(Function(M) M.AgencyName)</h2>
        </div>
    </div>
End Section

@Styles.Render("~/CSS/wv-icons.css")
@Styles.Render("~/Content/ej/web/flat-azure/ej.web.all.min.css")
@Styles.Render("~/Content/ej/web/bootstrap-theme/ej.web.all.min.css")

<script type="text/javascript" src="@Url.Content("~/Scripts/jquery.validate.min.js")"></script>
<script type="text/javascript" src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")"></script>

@If Model.IsValid = False Then
    @<div class="alert alert-danger">
        <strong>Invalid Media Traffic Instruction requested.</strong>
    </div>

Else

    If Model.InDifferentOrderState Then
        @<div class="alert alert-danger">
            <strong>The media traffic instruction is not valid anymore.</strong>
        </div>

    Else

        Using Html.BeginForm("TrafficInstructionForm", "MediaManager", New With {.QueryString = Model.QueryString}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(False, "", New With {.style = "color:red"})
            @Html.HiddenFor(Function(M) Model.Subject)
            @Html.HiddenFor(Function(M) Model.Body)
            @Html.HiddenFor(Function(M) Model.IsValid)
            @Html.HiddenFor(Function(M) Model.InDifferentOrderState)
            @Html.HiddenFor(Function(M) Model.UserCode)
            @Html.HiddenFor(Function(M) Model.DatabaseName)
            @Html.HiddenFor(Function(M) Model.Email)
            @Html.HiddenFor(Function(M) Model.MediaTrafficVendorID)
            @Html.HiddenFor(Function(M) Model.AlertID)
            @<div class="row">
                <div Class="page-header">
                    <h3>
                        Media Traffic Instruction
                    </h3>
                </div>
                <div Class="form-group">
                    <Label Class="col-md-2 control-label" style="padding-right:8px;">
                        @Html.DisplayNameFor(Function(M) M.Subject):
                    </Label>
                    <div Class="col-md-10 form-control-static" style="padding-left:22px;">
                        @Html.DisplayFor(Function(M) M.Subject)
                    </div>
                </div>
                <div Class="form-group">
                    <Label Class="col-md-2 control-label" style="padding-right:8px;">
                        @Html.DisplayNameFor(Function(M) M.Body):
                    </Label>
                    <div Class="col-md-10 form-control-static" style="padding-left:22px">
                        @Html.Raw(Model.Body)
                    </div>
                </div>
            </div>
            @<div class="row">
                <ul class="list-inline pull-left menu-bar" style="margin-top: 14px; margin-left: 12px;">
                    <li>
                        <a href='@Url.Action("DownloadInstructionDocument", "MediaTraffic", New With {.QueryString = Model.QueryString})' class="btn btn-primary" id="btnDownloadInstructionDocument" style=" margin-left: 20px;">View Instructions</a>
                    </li>
                    <li>
                        <input type="button" id="btnResponses" class="btn btn-primary" value="Responses" style="" />
                    </li>
                    <li>
                        <input type="button" id="btnNewComment" class="btn btn-primary" value="New Comment" style="" />
                    </li>
                    <li>
                        @If Model.HasBeenAccepted = False Then
                            @<input type="button" id="btnAccept" Class="btn btn-primary" value="Accept" style="" />
                        Else
                            @Html.DisplayFor(Function(M) M.AcceptedByAt)
                        End If
                    </li>
                </ul>
            </div>

            @(Html.EJ().Grid(Of AdvantageFramework.DTO.Media.Traffic.DetailDocument)("Grid").CssClass("e-table").Datasource(Model.DataSource.ToList) _
                            .Columns(Sub(co)
                                         co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.CableNetworkStationCodes.ToString).HeaderText("Cable Networks").Add()
                                         co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.DaypartDescription.ToString).HeaderText("Daypart").Add()
                                         co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.Length.ToString).Add()
                                         co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.StartTime.ToString).HeaderText("Start").Add()
                                         co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.EndTime.ToString).HeaderText("End").Add()
                                         co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.AdNumber.ToString).HeaderText("Ad Number").Add()
                                         co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.CreativeTitle.ToString).HeaderText("Creative Title").Add()
                                         co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.Location.ToString).Add()
                                         If Model.DetailDocuments.Any(Function(DD) DD.IsBookend) Then
                                             co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.IsBookend.ToString).EditType(TreeGridEditingType.Boolean).HeaderText("Is Bookend").Add()
                                             co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.BookendName.ToString).HeaderText("Bookend Name").Add()
                                             co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.Position.ToString).Add()
                                         End If
                                         co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.Rotation.ToString).Add()
                                         co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.HasDocuments.ToString).HeaderText("Has Documents").Add()
                                     End Sub).ChildGrid(Of AdvantageFramework.DTO.Media.Traffic.Detail)(Sub(child)
                                                                                                            child.Datasource(Model.DetailDocuments)
                                                                                                            child.QueryString("ParentID")
                                                                                                            child.Columns(Sub(co)
                                                                                                                              co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.Filename.ToString).Add()
                                                                                                                              co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.Description.ToString).Add()
                                                                                                                              co.Field(AdvantageFramework.DTO.Media.Traffic.DetailDocument.Properties.Link.ToString).Add()
                                                                                                                          End Sub)
                                                                                                        End Sub) _
                                                                                                .AllowResizing(True) _
                                                                                                .AllowResizeToFit(True) _
                                                                                                .AllowScrolling(True) _
                                                                                                .ClientSideEvents(Sub(eve)
                                                                                                                      eve.RowDataBound("rowDataBound")
                                                                                                                  End Sub)
            )@(Html.EJ().ScriptManager())

            @<div>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>

            @<div id="AcceptRejectModal" class="" title="Instruction"></div>
            @<div id="ResponsesModal" class="" title="Responses"></div>

        End Using

    End If

End If

<script id="acceptRejectDialogContent" type="text/template">
    <p style="padding-left: 5px; font-size: 10pt; font-family:Verdana;">
        <label>Comment:</label>
        <textarea name="AcceptRejectComment" id="acceptRejectComment" cols="20" rows="5" style="margin: 0px; height: 92px; width: 361px;"></textarea>
    </p>
</script>
<script id="acceptRejectDialogFooter" type="text/x-jsrender">
    <div class="footerspan" style="float:right">
        <button id='btnAcceptRejectDialogOK' class="btn btn-primary">OK</button>
        <button id='btnAcceptRejectDialogCancel' class="btn btn-normal">Cancel</button>
    </div>
</script>
<script id="responseDialogContent" type="text/template">
    <p style="padding-left: 5px; font-size: 10pt; font-family:Verdana;">
        @(Html.Kendo.Grid(Of AdvantageFramework.DTO.Media.OrderAlertComment) _
                        .Name("ResponsesGrid") _
                        .Editable(False) _
                        .Sortable(Sub(s)
                                      s.SortMode(GridSortMode.SingleColumn)
                                      s.Enabled(True)
                                  End Sub) _
                        .Scrollable(Sub(s)
                                        s.Enabled(True)
                                        s.Height(500)
                                    End Sub) _
                        .Columns(Sub(col)
                                     col.Bound(AdvantageFramework.DTO.Media.OrderAlertComment.Properties.VendorName.ToString).Column.Title = "Vendor Name"
                                     col.Bound(AdvantageFramework.DTO.Media.OrderAlertComment.Properties.Name.ToString).Width(200).Column.Title = "By"
                                     col.Bound(AdvantageFramework.DTO.Media.OrderAlertComment.Properties.CommentDateString.ToString).Width(200).Column.Title = "Date/Time"
                                     col.Bound(AdvantageFramework.DTO.Media.OrderAlertComment.Properties.Comment.ToString)
                                 End Sub) _
                        .DataSource(Sub(d)
                                        d.Ajax() _
                                .ServerOperation(False) _
                                .Read(Function(r) r.Action("GetResponses", "MediaTraffic").Data("getModelData"))
                                    End Sub)
        )
    </p>
</script>
<script id="responseDialogFooter" type="text/x-jsrender">
    <div class="footerspan" style="float:right">
        <button id='btnResponseDialogOK' class="btn btn-primary">OK</button>
    </div>
</script>

<script type="text/javascript">

    $(document).ready(function () {

        $("#AcceptRejectModal").ejDialog({
            closeOnEscape: true,
            enableModal: true,
            enableResize: false,
            showFooter: true,
            showOnInit: false,
            maxWidth: 500,
            footerTemplateId: "acceptRejectDialogFooter"
        });

        $('#btnAcceptRejectDialogOK').click(function () {
            var modeldbname = @Html.Raw(Json.Encode(Model.DatabaseName));
            var email = @Html.Raw(Json.Encode(Model.Email));
            var mediaTrafficVendorID = @Html.Raw(Json.Encode(Model.MediaTrafficVendorID));

            var commandID = $("#AcceptRejectModal").data("CommandID");
            var comment = $('#acceptRejectComment').val();

            if ((commandID == 2) && (!$.trim($("#acceptRejectComment").val()))) {
                showNotification("Comment is required.", "warning")
            } else {
                $("#AcceptRejectModal").ejDialog("close");
                $('#acceptRejectComment').val("");
                if (commandID == 1) {
                    kendo.ui.progress($('body'), true);
                    $.ajax({
                        url: 'AcceptInstruction',
                        type: "Post",
                        data: { DatabaseName: modeldbname, Comment: comment, MediaTrafficVendorID: mediaTrafficVendorID, Email: email, Command: commandID },
                        success: function (result) {
                            kendo.ui.progress($('body'), false);
                            window.location.href = result;
                        },
                        error: function (e) {
                            kendo.ui.progress($('body'), false);
                            showNotification("Failed to accept", "error");
                        }
                    });
                } else if (commandID == 2) {
                    kendo.ui.progress($('body'), true);
                    $.ajax({
                        url: 'AcceptInstruction',
                        type: "Post",
                        data: { DatabaseName: modeldbname, Comment: comment, MediaTrafficVendorID: mediaTrafficVendorID, Email: email, Command: commandID },
                        success: function (result) {
                            kendo.ui.progress($('body'), false);
                        },
                        error: function (e) {
                            kendo.ui.progress($('body'), false);
                            showNotification("Failed to add new comment", "error");
                        }
                    });
                }
            }
        });

        $('#btnAcceptRejectDialogCancel').click(function () {
            $('#acceptRejectComment').val("");
            $("#AcceptRejectModal").ejDialog("close");
        });

    });

    $('#btnNewComment').click(function () {
        newComment();
    });

    function newComment(args) {
        var template = document.getElementById("acceptRejectDialogContent");
        $("#AcceptRejectModal").data("CommandID", 2);
        $("#AcceptRejectModal").ejDialog("open", args);
        $("#AcceptRejectModal").ejDialog("setTitle", "New Comment");
        $("#AcceptRejectModal").ejDialog("setContent", template.innerHTML);
    };

    $('#btnAccept').click(function () {
        accept();
    });

    function accept(args) {
        var template = document.getElementById("acceptRejectDialogContent");
        $("#AcceptRejectModal").data("CommandID", 1);
        $("#AcceptRejectModal").ejDialog("open", args);
        $("#AcceptRejectModal").ejDialog("setTitle", "Accept Instructions");
        $("#AcceptRejectModal").ejDialog("setContent", template.innerHTML);
    };

    var mgModel = {
        DatabaseName: @Html.Raw(Json.Encode(Model.DatabaseName)),
        AlertID: @Html.Raw(Json.Encode(Model.AlertID)),
        VendorTime: new Date().getTimezoneOffset(),
    };

    function getModelData() {
        return mgModel;
    };

    $("#ResponsesModal").ejDialog({
        close: "onResponseDialogClose",
        closeOnEscape: true,
        enableModal: true,
        enableResize: false,
        showFooter: true,
        showOnInit: false,
        width: 800,
        maxWidth: 800,
        footerTemplateId: "responseDialogFooter"
    });

    $('#btnResponseDialogOK').click(function () {
        $("#ResponsesModal").ejDialog("close");
    });

    function onResponseDialogClose() {
        $("#ResponsesModal").ejDialog("close");
    };

    $('#btnResponses').click(function (args) {
        var template = document.getElementById("responseDialogContent");
        var templateHTML = template.innerHTML;

        $("#ResponsesModal").ejDialog("open", args);
        $("#ResponsesModal").ejDialog("setContent", templateHTML);
    })

    function rowDataBound(args) {
        if (args.data.HasDocuments == true)
            this.expandCollapse($(args.row.find(".e-detailrowcollapse")));
    }

</script>

<style type="text/css">
    .form-group .control-label, .form-group .form-control-static, p, span, .panel-body {
        font-family: Verdana !important;
        font-size: 10pt;
    }

    /*.e-dialog > .e-header .e-title {
        font-family: Verdana, Arial, sans-serif !important;
        font-size: 11pt;
        font-weight: normal;
    }

    .modal-dialog {
        z-index: 9999;
    }*/

    td font span {
        font-family: Verdana !important;
        font-size: 10pt;
        font-weight: normal;
    }

    .form-control-static tr td:first-child font span {
        font-weight: normal !important;
    }

    h2, h3, h4 {
        font-family: Verdana !important;
    }

    h2 {
        font-size: 24px;
    }

    .btn {
        border-radius: 4px;
        padding: 6px 12px;
    }

    .e-row[aria-selected="true"] .e-customizedExpandcell {
        background-color: #e0e0e0;
    }

    .e-grid.e-gridhover tr[role='row']:hover {
        background-color: #eee;
    }
</style>
