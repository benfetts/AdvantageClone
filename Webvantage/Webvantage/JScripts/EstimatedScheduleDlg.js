

function OpenEstimatedScheduleDlg(JobNumber, JobComponentNumber) {
    var dlgStr = "<div id='ESTIMATEDSECHEDULEDLG'><input type='checkbox' id='eq1' class='k-checkbox' onclick='showEmployees()'><label class='k-checkbox-label' for='eq1'>Show Employees</label><div id='gridcontainer'> <div id='grid'></div></div></div>";

    var style = document.createElement('style');
    style.type = 'text/css';
    style.innerHTML = '.___grid-number { text-align: right; }';
    document.getElementsByTagName('head')[0].appendChild(style);

    if ($('#ESTIMATEDSECHEDULEDLG').length === 0) {
        $('body').append(dlgStr);

        var myWindow = $('#ESTIMATEDSECHEDULEDLG');
        var template = kendo.template('<span class="wvi wvi-excel-logo wv-icon-button" onclick="exportToExcelES()" title="Export to Excel"></span>');

        $("#grid").kendoGrid({
            dataSource: {
                pageSize: 10,
                aggregate: [ 
                    { field: "Hours", aggregate: "sum" },
                    { field: "Amount", aggregate: "sum" }
                ],
                schema: {
                    model: {
                        fields: {
                            Hours: { type: "number" },
                            Description: { type: "string" },
                            EmployeeName: { type: "string" },
                            Rate: { type: "number" },
                            Amount: { type: "number" }
                        }
                    }
                },
                transport: {
                    read: (e) => {
                        var IncludeEmployee = 0;
                        var checkBox = document.getElementById("eq1");

                        if (checkBox.checked === true) {
                            IncludeEmployee = 1;
                        }

                        $.ajax({
                            type: "GET",
                            url: window.location.protocol + "//" + window.location.host + "/" + window.appBase + "/ProjectManagement/ProjectSchedule/GetEstamatedSchedule",
                            data: "JobNumber=" + JobNumber + "&JobComponentNumber=" + JobComponentNumber + "&IncludeEmployee=" + IncludeEmployee,
                            dataType: "json",
                            success: (results) => {
                                e.success(results);
                            },
                            error: (results) => {
                                e.error(results);
                            }
                        });
                    }
                }
            },
            height: '100%',
            resizable: true,
            sortable: true,
            pageable: {
                refresh: false,
                pageSizes: true,
                buttonCount: 5
            },
            columns: [{
                field: "Description",
                title: "Function Description",
                width: "300px"
            }, {
                field: "EmployeeName",
                title: "Employee"
            }, {
                field: "Hours",
                title: "Hours",
                width: "100px",
                aggregates: ["sum"],
                footerTemplate: "<div style='text-align: right'>#=sum#</div>",
                attributes: { class: '___grid-number ' }
            }, {
                field: "Rate",
                title: "Rate",
                format: "{0:n2}",
                attributes: { class: '___grid-number ' }
            }, {
                field: "Amount",
                title: "Amount",
                aggregates: ["sum"],
                    footerTemplate: "<div style='text-align: right'>#= kendo.toString(sum, 'n2')#</div>",
                format: "{0:n2}",
                attributes: { class: '___grid-number ' }
            }],
            excel: {
                allPages: true,
                fileName: "Estimated Schedule " + JobNumber + "-" + JobComponentNumber +".xlsx"
            },
            excelExport: function (e) {
                var rows = e.workbook.sheets[0].rows;

                for (var ri = 0; ri < rows.length; ri++) {
                    var row = rows[ri];

                    if (row.type === "group-footer" || row.type === "footer") {
                        for (var ci = 0; ci < row.cells.length; ci++) {
                            var cell = row.cells[ci];
                            if (cell.value) {
                                // Use jQuery.fn.text to remove the HTML and get only the text
                                cell.value = $(cell.value).text();
                                // Set the alignment
                                cell.hAlign = "right";
                            }
                        }
                    }
                }
            },
            dataBound: (e) => {
                var grid = $("#grid").data('kendoGrid');
                grid.pager.options.messages.display = "{2} items in " + grid.pager.totalPages() + " pages";
            },
            toolbar: template
        }).data('kendoGrid').hideColumn("EmployeeName");

        myWindow.ejDialog({
            title: "Estimated Schedule",
            showOnInit: false,
            height: "90%",
            width: "90%",
            showFooter: false,
            enableModal: true,
            backgroundScroll: false,
            enableResize: true,
            enableAutoResize: true,
            close: (e) => {
            },
            open: (e) => {
                console.log(e);
                setTimeout(() => {
                    var height = $('#ESTIMATEDSECHEDULEDLG').height();
                    $('#gridcontainer').height(height - 35);

                    $('#grid').data('kendoGrid').resize();

                }, 100);
            },
            resize: (e) => {

                $('#gridcontainer').height(e.model.height - 100);

                $('#grid').data('kendoGrid').resize();
            }
        });

        $("#ESTIMATEDSECHEDULEDLG").ejDialog("refresh");
        $("#ESTIMATEDSECHEDULEDLG").ejDialog("open");

        //myWindow.kendoWindow({
        //    width: "800px",
        //    title: "Estimated Schedule",
        //    visible: false,
        //    actions: [
        //        "Close"
        //    ],
        //    close: onClose
        //}).data("kendoWindow").center().open();

        //var titleSpan = $('.k-window-titlebar');

        //console.log(titleSpan);

        //for (var i = 0; i < titleSpan.length; i++) {
        //    titleSpan[i].style.backgroundColor = "white";
        //}
    }
    else {
        $("#grid").data('kendoGrid').dataSource.read();
        $("#ESTIMATEDSECHEDULEDLG").ejDialog("refresh");
        $("#ESTIMATEDSECHEDULEDLG").ejDialog("open");

        //$('#ESTIMATEDSECHEDULEDLG').data("kendoWindow").center().open();
    }
}

function exportToExcelES() {
    var grid = $('#grid').data('kendoGrid');
    
    grid.saveAsExcel();
}

function showEmployees() {
    var grid = $('#grid').data('kendoGrid');
    var checkBox = document.getElementById("eq1");

    if (checkBox.checked === true) {
        grid.showColumn("EmployeeName");
    }
    else {
        grid.hideColumn("EmployeeName");
    }

    grid.dataSource.read();
}

function onClose() {
    
}
