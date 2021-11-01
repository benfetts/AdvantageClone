@ModelType AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails

<style>
    .col-md-9{
        width: 56vw !important;
        min-width: 680px;
    }

    .col-md-3 {
        width: 18vw !important;
        min-width: 200px;
    }

    #locationDetailHeader input, #locationAddressHeader input{
        
    }
</style>

<div>
    <div Class="col-md-9">
        <div Class="settings-section" style="">
            <h5> Location Details</h5>
            <div>
                <Table id="locationDetailHeader" style="width: 100%;">
                    <thead style="">
                        <tr>
                            <td style="width: 110px; min-width:110px; vertical-align: top;"></td>
                            <td style="width: 100%; min-width:200px; vertical-align: top;"></td><br />
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                ID :
                            </td>
                            <td>
                                @(Html.Kendo.TextBoxFor(Function(m) m.ID).HtmlAttributes(New With {.style = "width: 100%; margin-top: 10px; background-color:#E0E0E0;", .disabled = "disabled", .maxLength = "6"}))
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Name :
                            </td>
                            <td>
                                @(Html.Kendo.TextBoxFor(Function(m) m.Name).HtmlAttributes(New With {.style = "width: 100%; margin-top: 10px;", .maxlength = "50"}))
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email :
                            </td>
                            <td>
                                @(Html.Kendo.TextBoxFor(Function(m) m.Email).HtmlAttributes(New With {.style = "width: 100%; margin-top: 10px;", .maxlength = "60"}))
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone :
                            </td>
                            <td>
                                @(Html.Kendo.TextBoxFor(Function(m) m.Phone).HtmlAttributes(New With {.style = "width: 100%; margin-top: 10px;", .maxlength = "20"}))
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fax :
                            </td>
                            <td>
                                @(Html.Kendo.TextBoxFor(Function(m) m.Fax).HtmlAttributes(New With {.style = "width: 100%; margin-top: 10px;", .maxlength = "20"}))
                            </td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                    </tfoot>
                </Table>
            </div>
        </div>
        <div class="settings-section" style="">
            <h5>Address</h5>
            <div>
                <table id="locationAddressHeader" style="width: 100%;">
                    <thead style="">
                        <tr>
                            <td style="width: 110px; min-width:110px;  vertical-align: top;"></td>
                            <td style="width: 100%; min-width:200px; vertical-align: top;"></td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                Address 1:
                            </td>
                            <td>
                                @(Html.Kendo.TextBoxFor(Function(m) m.Address1).HtmlAttributes(New With {.style = "width: 100%; margin-top: 10px;", .maxlength = "50", .autocomplete = "nofill"}))
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address 2:
                            </td>
                            <td>
                                @(Html.Kendo.TextBoxFor(Function(m) m.Address2).HtmlAttributes(New With {.style = "width: 100%; margin-top: 10px;", .maxlength = "50", .autocomplete = "nofill"}))
                            </td>
                        </tr>
                        <tr>
                            <td>
                                City :
                            </td>
                            <td>
                                @(Html.Kendo.TextBoxFor(Function(m) m.City).HtmlAttributes(New With {.style = "width: 100%; margin-top: 10px;", .maxlength = "35", .autocomplete = "nofill"}))
                            </td>
                        </tr>
                        <tr>
                            <td>
                                State :
                            </td>
                            <td>
                                @(Html.Kendo.TextBoxFor(Function(m) m.State).HtmlAttributes(New With {.style = "width: 100%; margin-top: 10px;", .maxlength = "10", .autocomplete = "nofill"}))
                                @*<div style="margin-top:10px;">
                    @(Html.Kendo().DropDownList() _
        .Name("StatesDropDownList") _
        .DataTextField("StateName") _
        .DataValueField("StateCode") _
        .DataSource(
        Sub(ds)
            ds.Read("GetStates", "Locations")
        End Sub) _
        .Filter("contains") _
        .OptionLabel("Please Select") _
        .HtmlAttributes(
        New With {.style = "width: 100%"}
        ) _
        .Value(Model.State)
                    )
                </div>*@
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Zip :
                            </td>
                            <td>
                                @(Html.Kendo.TextBoxFor(Function(m) m.Zip).HtmlAttributes(New With {.style = "width: 100%; margin-top: 10px;", .maxlength = "10", .autocomplete = "nofill"}))
                            </td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
    <div class="col-md-3">
        <div class="settings-section" style="">
            <h5>Print Options</h5>
            <div>
                <div id="printHeaderDiv">
                    <p>
                        @(Html.Kendo.CheckBoxFor(Function(m) m.PrintHeader))
                        <label class="k-label">Print Header</label>
                    </p>
                    <div id="printHeaderElements">
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintNameHeader))
                            <span>Name</span>
                        </p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintAddressHeader))
                            <span>Address 1</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintAddress2Header))
                            <span>Address 2</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintCityHeader))
                            <span>City</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintStateHeader))
                            <span>State</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintZipHeader))
                            <span>Zip</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintPhoneHeader))
                            <span>Phone</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintFaxHeader))
                            <span>Fax</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintEmailHeader))
                            <span>Email</span>
</p>
                    </div>
                </div>
                <p>
                    &nbsp;
                </p>
                <div id="printFooterDiv">
                    <p>
                        @(Html.Kendo.CheckBoxFor(Function(m) m.PrintFooter))
                        <label class="k-label">Print Footer</label>
                    </p>
                    <div id="printFooterElements">
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintNameFooter))
                            <span>Name</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintAddressFooter))
                            <span>Address 1</span>                                
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintAddress2Footer))
                            <span>Address 2</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintCityFooter))
                            <span>City</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintStateFooter))
                            <span>State</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintZipFooter))
                            <span>Zip</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintPhoneFooter))
                            <span>Phone</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintFaxFooter))
                            <span>Fax</span>
</p>
                        <p style="margin-left:10px;">
                            @(Html.Kendo.CheckBoxFor(Function(m) m.PrintEmailFooter))
                            <span>Email</span>
</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script>
    $(document).ready(function () {
        //  Wire up to events
        $("input[name='PrintHeader']").change(function () {

            checkPrintHeaderChanged();

        });
        $("input[name='PrintFooter']").change(function () {

            checkPrintFooterChanged();

        });
        //  Also run on (re)load
        checkPrintHeaderChanged();
        checkPrintFooterChanged();
    });

    function checkPrintHeaderChanged() {
        if (document.getElementById("PrintHeader").checked === false) {
            
            $("#printHeaderElements input:checkbox").prop("readonly", "readonly");
            $("#printHeaderElements input:checkbox").prop("disabled", true);
            $("#printHeaderElements span").css("color", DisabledFontColor);

        } else {

            $("#printHeaderElements input:checkbox").removeAttr("disabled");
            $("#printHeaderElements input:checkbox").removeAttr("readonly");
            $("#printHeaderElements span").css("color", "#333");

        }
    }
    function checkPrintFooterChanged() {
        if (document.getElementById("PrintFooter").checked === false) {
            
            $("#printFooterElements input:checkbox").prop("readonly", "readonly");
            $("#printFooterElements input:checkbox").prop("disabled", true);
            $("#printFooterElements span").css("color", DisabledFontColor);

        } else {

            $("#printFooterElements input:checkbox").removeAttr("disabled");
            $("#printFooterElements input:checkbox").removeAttr("readonly");
            $("#printFooterElements span").css("color", "#333");

        }
    }
</script>



