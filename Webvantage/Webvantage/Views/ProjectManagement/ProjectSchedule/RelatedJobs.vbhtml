@ModelType AdvantageFramework.ViewModels.ProjectSchedule.Schedule

<style>
    .form-group {
        margin-left: unset !important;
        margin-right: unset !important;
    }
</style>

<div style="padding-top: 10px; padding-bottom: 10px;">
    <div class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-sm-4 col-md-3 col-lg-3" for="JobsThatPrecede">Jobs that precede this job</label>
            <div class="col-sm-6 col-md-7 col-lg-7">
                @(Html.ListBox("JobsThatPrecede", New SelectList({""}), New With {.class = "form-control", .size = "6", .onchange = "jobsThatPrecedeChanged()"}))
            </div>
            <div class="col-sm-2 col-md-2 col-lg-2">

                @If Me.IsClientPortal = False AndAlso Model.CanUserEdit Then
                    @(Html.Kendo.Button().Name("DeleteJobsThatPrecede").Content("").Events(Sub(e)
                                                                                                       e.Click("deleteJobThatPrecede")
                                                                                                   End Sub).Enable(False).Icon("close").HtmlAttributes(New With {.style = "width: 35px;", .type = "button"}))
                    @(Html.Kendo.Button().Name("AddJobsThatPrecede").Content("").Events(Sub(e)
                                                                                                    e.Click("addJobThatPrecede")
                                                                                                End Sub).Icon("plus").HtmlAttributes(New With {.style = "width: 35px;", .type = "button"}))
                End If

            </div>
        </div>
        <div class="form-group">
            <Label class="control-label col-sm-4 col-md-3 col-lg-3" for="JobsThatFollow">Jobs that follow this job</Label>
            <div class="col-sm-6 col-md-7 col-lg-7">
                @(Html.ListBox("JobsThatFollow", New SelectList({""}), New With {.class = "form-control", .size = "6", .onchange = "jobsThatFollowChanged()"}))
            </div>
            <div class="col-sm-2 col-md-2 col-lg-2">

                @If Me.IsClientPortal = False AndAlso Model.CanUserEdit Then
                    @(Html.Kendo.Button().Name("DeleteJobsThatFollow").Content("").Events(Sub(e)
                                                                                                      e.Click("deleteJobThatFollow")
                                                                                                  End Sub).Enable(False).Icon("close").HtmlAttributes(New With {.style = "width: 35px;", .type = "button"}))
                End If

            </div>
        </div>
    </div>
</div>

<script type="text/x-kendo-template" id="jobListTemplate">
    <option value="#: ID#">
        #:Description#
    </option>
</script>

<script>

    var relatedJobsChange = false;
    var jobsThatPrecede;
    var jobsThatFollow;

    $(() => {

        jobsThatPrecede = new kendo.data.DataSource({
            transport: {
                read: '@Html.Raw(Url.Action("ReadJobsThatPrecede", New With {.JobNumber = Model.JobNumber, .JobComponentNumber = Model.JobComponentNumber}))'
            },
            requestStart: function () {
                kendo.ui.progress($('#JobsThatPrecede'), true);
            },
            requestEnd: function () {
                kendo.ui.progress($('#JobsThatPrecede'), false);
                jobsThatPrecedeChanged();
            },
            change: function () {
                var template = kendo.template($('#jobListTemplate').html());
                $('#JobsThatPrecede').html(kendo.render(template, this.view()));
                jobsThatPrecedeChanged();
            },
            schema: {
                model: {
                    id: "ID"
                }
            }
        });

        jobsThatFollow = new kendo.data.DataSource({
            transport: {
                read: '@Html.Raw(Url.Action("ReadJobsThatFollow", New With {.JobNumber = Model.JobNumber, .JobComponentNumber = Model.JobComponentNumber}))'
            },
            requestStart: function () {
                kendo.ui.progress($('#JobsThatFollow'), true);
            },
            requestEnd: function () {
                kendo.ui.progress($('#JobsThatFollow'), false);
            },
            change: function () {
                var template = kendo.template($('#jobListTemplate').html());
                $('#JobsThatFollow').html(kendo.render(template, this.view()));
                jobsThatFollowChanged();
            },
            schema: {
                model: {
                    id: "ID"
                }
            }
        });

        $('#saveButton').on('click', saveJobInfo);
        $('#cancelButton').on('click', loadJobInfo);
        $('#refreshProjectSchedule').on('click', loadJobInfo);

        loadrelatedJobs();
    });

    function saveRelatedJobs(e) {
        relatedJobsChange = false;
        setSave();
    }

    function loadrelatedJobs(e) {

        jobsThatPrecede.read();
        jobsThatFollow.read();


        relatedJobsChange = false
        setSave();
    }

    function deleteJobThatPrecede(e) {
        e.preventDefault();
        var ids = [];
        $('#JobsThatPrecede option:selected').each(function () {
            ids.push($(this).val());
        });
        var model = getModelData();
        var data = {
            JobNumber: model.JobNumber,
            JobComponentNumber: model.JobComponentNumber,
            IDs: ids
        };
        kendo.ui.progress($('#JobsThatPrecede'), true);
        $.post({
            url: controllerBase + 'DestroyJobThatPrecedes',
            dataType: 'json',
            data: data
        }).always(function () {
            jobsThatPrecede.read().always(function () {
                kendo.ui.progress($('#JobsThatPrecede'), false);
            });
        });
    }

    function deleteJobThatFollow(e) {
        e.preventDefault();
        var ids = [];
        $('#JobsThatFollow option:selected').each(function () {
            ids.push($(this).val());
        });
        var model = getModelData();
        var data = {
            JobNumber: model.JobNumber,
            JobComponentNumber: model.JobComponentNumber,
            IDs: ids
        };
        kendo.ui.progress($('#JobsThatFollow'), true);
        $.post({
            url: controllerBase + 'DestroyJobThatFollows',
            dataType: 'json',
            data: data
        }).always(function () {
            jobsThatFollow.read().always(function () {
                kendo.ui.progress($('#JobsThatFollow'), false);
            });
        });
    }

    function jobsThatFollowChanged() {
        var deleteBtn = $('#DeleteJobsThatFollow').data('kendoButton');
        if (deleteBtn) {
            deleteBtn.enable($('#JobsThatFollow option:selected').length > 0 ? true : false);
        }
    }
    function jobsThatPrecedeChanged() {
        var deleteBtn = $('#DeleteJobsThatPrecede').data('kendoButton');
        if (deleteBtn) {
            deleteBtn.enable($('#JobsThatPrecede option:selected').length > 0 ? true : false);
        }
    }
    function addJobThatPrecede(e) {
        e.preventDefault();
        var model = getModelData();
        OpenRadWindow('', 'TrafficSchedule_AddJobPred.aspx?j=' + model.JobNumber + '&jc=' + model.JobComponentNumber, 730, 1025, true, function () {
            jobsThatPrecede.read();
        });
    }

</script>
