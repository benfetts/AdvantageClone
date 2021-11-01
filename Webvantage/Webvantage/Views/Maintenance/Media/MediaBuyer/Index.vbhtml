
@ModelType AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel 
@Code
    ViewData("Title") = "Media Buyer"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code

<script type="text/javascript">

    function error_handler(e) {
        if (e.errors) {
            var message = "Errors:\n";
            $.each(e.errors, function (key, value) {
                if ('errors' in value) {
                    $.each(value.errors, function() {
                        message += this + "\n";
                    });
                }
            });
            showKendoAlert(message);
        }
    }


</script>

<style>
    .abutton,
    div.k-grid .k-grid-edit,
    div.k-grid .k-grid-cancel,

    .k-button-icontext {
    }

    div.k-grid .k-grid-delete {
        display: inline-block;
        width: 6px;
        height: 20px;
        background-color: transparent;
        min-width: 0;
        border: 0;
        text-decoration: none;
        background: url('@Url.Content("~/Images/Delete2.png")') no-repeat;
    }

    .abutton.delete {
        background: url('@Url.Content("~/Images/Delete2.png")') no-repeat;

    .delete-icon {
        background: url('@Url.Content("~/Images/Delete2.png")') no-repeat;
    }

    input#search    {
        background:url(../Images/Delete2.png);
        background-repeat: no-repeat;
        width:40px;
        height:40px;
        border: 0;
    }
</style>

<script type='text/javascript'>
        function navigate(target) {
            //Perform your AJAX call to your Controller Action
            $.post(target,{ ID: $('#ID').val() });
        }
</script>

<script type="text/x-kendo-template" id="columnDeleteTemplate">
    <a href="@Url.Action("MediaBuyerDelete", "MediaBuyer")">
        <i class="delete-icon"></i>
        <span>
            <strong>Delete</strong>
        </span>
    </a>
</script>

<script>
    var myTemplate = kendo.template($('#columnDeleteTemplate').html());
</script>

<script type="text/x-kendo-template" id="employeeDropDownTemplate">
    <div class="go-center">
        @(Html.Kendo().DropDownList().Name("EmployeeDropDownList").DataTextField("LastName").DataValueField("EmployeeCode").DataSource(Sub(dsd)
                                                                                                                                           dsd.Read(Sub(read)
                                                                                                                                                        read.Action("EmployeeListRead", "Index")
                                                                                                                                                    End Sub)
                                                                                                                                       End Sub)
        )
    </div>
</script>

<div>
@(Html.Kendo().Grid(Of AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel) _
                                                                                                .Name("MediaBuyer") _
                                                                                                .Pageable _
                                                                                                .Sortable _
                                                                                                .ToolBar(Sub(ToolBar)
                                                                                                             ToolBar.Create()
                                                                                                         End Sub) _
                                                                                                .Editable(Sub(MyEdit)
                                                                                                              MyEdit.Mode(GridEditMode.InLine)
                                                                                                          End Sub) _
                                                                                                .DataSource(Sub(ds)
                                                                                                                ds.Ajax.Batch(False)
                                                                                                                ds.Ajax.Create("MediaBuyerCreate", "MediaBuyer")
                                                                                                                ds.Ajax.Read("MediaBuyerRead", "MediaBuyer")
                                                                                                                ds.Ajax.Events(Sub(MBEvent)
                                                                                                                                   MBEvent.Error("error_handler")
                                                                                                                               End Sub)
                                                                                                                ds.Ajax.Model(Sub(Model)
                                                                                                                                  Model.Id(AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.ID.ToString)
                                                                                                                                  Model.Field(AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.EmployeeCode.ToString, GetType(String))
                                                                                                                                  Model.Field(AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.EmployeeName.ToString, GetType(String)).Editable(False)
                                                                                                                              End Sub)
                                                                                                            End Sub) _
                                                                                                .Columns(Sub(Column)
                                                                                                             Column.Bound(AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.EmployeeCode.ToString).ClientTemplate("#=EmployeeCode#").Title("Employee").EditorTemplateName("EmployeeDropDownList")
                                                                                                             Column.Bound(AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.EmployeeName.ToString)
                                                                                                             Column.Bound(AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel.Properties.IsInactive.ToString).ClientTemplate(
                                                                                                 "<input type='checkbox' value='#= EmployeeCode #' " +
                                                                                                 "# if (IsInactive) { #" +
                                                                                                 "checked='checked'" +
                                                                                                 "# } #" +
                                                                                                 "/>").Width(100)
                                                                                                             Column.Bound("ID").ClientTemplate(
                                                                                                            "<a href=" + Url.Action("MediaBuyerDelete", "MediaBuyer") +
" onclick='navigate(this.href);'><input type='button' id='search' value=''></a>"
                                                                                     )
                                                                                                         End Sub)
)
</div>
