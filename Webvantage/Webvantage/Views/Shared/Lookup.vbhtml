@ModelType Webvantage.Models.LookupModel
@Code
    ViewData("Title") = "Search"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code

<div>

    <div id="LookupGrid"></div>

</div>

@If Model.SearchOptions IsNot Nothing AndAlso Model.SearchOptions.Count > 0 Then

    @<div id="SearchOptions">

        @For Each SearchOption In Model.SearchOptions

            @(Html.Kendo().CheckBox().Name(SearchOption.PropertyName).Label(SearchOption.DisplayLabel).Checked(SearchOption.CheckedByDefault))

        Next

    </div>

End If

<div class="pull-right">
    @(Html.Kendo().Button().Name("Select").Content("Select").Events(Sub(e)
                                                                                e.Click("selectItem")
                                                                            End Sub))
    @(Html.Kendo().Button().Name("Cancel").Content("Cancel").Events(Sub(e)
                                                                                e.Click("cancel")
                                                                            End Sub))
</div>

<style>
    #LookupGrid {
        margin-bottom: 10px;
        margin-top: 10px;
    }
</style>

<script>

    var model = @Html.Raw(Json.Encode(Model));
    var columns = [];

    $.each(model.Columns, function(){
        var col = {};
        col.field = this.Field;
        col.title = this.Title;
        if(model.Columns.length === 1){
            col.headerTemplate = 'Search List';
            if(model.DefaultFilter && model.DefaultFilter !== ''){
                col.filterable = {
                    cell: {
                        operator: model.DefaultFilter,
                        suggestionOperator: model.DefaultFilter
                    }
                }
            }
        }
        columns.push(col);
    });

    var grid = $('#LookupGrid').kendoGrid({
        dataSource: {
            data: model.DataItems
        },
        height: 500,
        pageable: {
            numeric: false,
            previousNext: false,
            messages: {
                display: "Showing {2} items"
            }
        },
        columns: columns,
        selectable: "row",
        filterable: {
            mode: "row"
        },
        scrollable: true,
        change: function(e) {
            checkSelection();
        }
    }).data('kendoGrid');

    var selectedItem;

    function checkSelection(){
        var allowSelect = false;
        if(grid.select().length > 0){
            allowSelect = true;
        }
        $('#Select').data('kendoButton').enable(allowSelect);
    }

    function selectItem() {
        var item = grid.select();
        if(item){
            selectedItem = grid.dataItem(item);
            closeWindow();
        } else {
            showKendoAlert('Please select an item.');
        }
    }
    function cancel() {
        closeWindow();
    }
    function closeWindow() {
        Close(selectedItem);

        //var win = GetRadWindow();
        //win.BrowserWindow.Cancel();
    }

    function applySearchOptions(){
        var gridFilters = grid.dataSource.filter();
        var filters = [];
        if(!gridFilters){
            gridFilters = [];
        }
        $('input.k-checkbox').each(function(){
            if($(this).is(':checked') === true){
                filters.push({ field: this.name, operator: "equals", value: true });
            }
        });
        if(gridFilters){
            var mainFilter;
            $.each(gridFilters.filters, function(){
                if(this.field === 'CodeAndDescription'){
                    mainFilter = this;
                }
            });
            if(mainFilter){
                filters.push(mainFilter);
            }
        }
        grid.dataSource.filter(filters);
    }

    $(document).ready(function(){
        checkSelection();
        applySearchOptions();
    });

    $('body').on('dblclick', 'tbody > tr', function(){
        selectItem();
    }).on('change', '#SearchOptions > input[type=checkbox]', function(){
        applySearchOptions();
    });

</script>
