@ModelType System.Data.DataTable
@Code
    ViewData("Title") = "Job Forecast"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code

<style type="text/css">
    #Grid > .k-grouping-header {
        display: none;
    }
    .desc-col {
        min-width: 175px !important;
        max-width: 255px;
        overflow: hidden;
        white-space: nowrap;
        -ms-text-overflow: ellipsis;
        -o-text-overflow: ellipsis;
        text-overflow: ellipsis;
        -ms-word-break: normal !important;
        word-break: normal !important;
        -ms-word-wrap: normal !important;
        word-wrap: normal !important;
    }
</style>

<div style="margin:10px;">

    <div>
        @Code

            Html.Kendo().ToolBar() _
                .Name("Toolbar") _
                .Items(Sub(items)
                               items.Add().Type(CommandType.Separator)
                               items.Add().Type(CommandType.Button).Text("Save")
                               items.Add().Type(CommandType.Separator)
                               items.Add().Type(CommandType.Button).Text("Job Components")
                               items.Add().Type(CommandType.Separator)
                               items.Add().Type(CommandType.Button).Text("Create Revision")
                               items.Add().Type(CommandType.Separator)
                               items.Add().Type(CommandType.Button).Text("Delete Forecast")
                               items.Add().Type(CommandType.Separator)
                               items.Add().Type(CommandType.Button).Text("Approve")
                               items.Add().Type(CommandType.Separator)
                               items.Add().Type(CommandType.Button).Text("Settings")
                       End Sub) _
                .Render()

        End Code
    </div>
    <div style="margin:10px;">
        <div style="margin:5px;"><strong>Description</strong><br/><span style="width:800px">@(Html.Kendo().TextBox().Name("Description").Value("")))</span></div>
        <div style="margin:5px;"><strong>Comment</strong><br />@(Html.TextArea("Comment", "", New With {.class = "k-textbox"}))</div>
        <div style="margin:5px;"><strong>Revision</strong><br />@(Html.Kendo().ComboBox().Name("Revision").Value(""))</div>
        <div style="margin:5px;"><strong>Month/Year</strong><br />@(html.Label("Hey"))</div>
        <div style="margin:5px;"><strong>Assigned To</strong><br /></div>
        <div style="margin:5px;"><strong>Created By</strong><br /></div>
        <div style="margin:5px;"><strong>Modified By</strong><br /></div>
        <div style="margin:5px;"><strong>Approved By</strong><br /></div>
    </div>
    <div>
        @Code

            Html.Kendo().Grid(Model) _
                .Name("Grid") _
                .Columns(Sub(columns)

                                 Dim Hierarchy As Generic.Dictionary(Of Integer, Generic.Dictionary(Of Integer, Generic.List(Of String))) = Nothing

                                 Hierarchy = New Generic.Dictionary(Of Integer, Generic.Dictionary(Of Integer, Generic.List(Of String)))

                                 For Each DataColumn In Model.Columns.OfType(Of System.Data.DataColumn)()

                                     If DataColumn.ColumnName.StartsWith("Billing_") OrElse _
                                         DataColumn.ColumnName.StartsWith("Revenue_") Then

                                         Dim PostPeriod As String = DataColumn.ColumnName.Replace("Billing", "").Replace("Revenue", "").Replace("_", "")
                                         Dim Year As Integer = CInt(PostPeriod.Substring(0, 4))
                                         Dim Month As Integer = CInt(PostPeriod.Substring(4, 2))

                                         If Not Hierarchy.ContainsKey(Year) Then

                                             Hierarchy.Add(Year, New Dictionary(Of Integer, List(Of String)))

                                         End If

                                         If Not Hierarchy(Year).ContainsKey(Month) Then

                                             Hierarchy(Year).Add(Month, New Generic.List(Of String))

                                         End If

                                         Hierarchy(Year)(Month).Add(DataColumn.ColumnName)

                                     ElseIf DataColumn.ColumnName = "JobAndComponentWithDescription" Then

                                         columns.Bound(DataColumn.ColumnName) _
                                             .Title("Job/Component") _
                                             .HtmlAttributes(New With {.class = "desc-col"}) _
                                             .Width(200).Template(Function(dr)
                                                                          Dim HtmlColor As String = ""
                                                                          If Not IsDBNull(dr.Item("Color")) Then
                                                                              Try
                                                                                  HtmlColor = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(dr.Item("Color")))
                                                                              Catch ex As Exception
                                                                                  HtmlColor = ""
                                                                              End Try
                                                                          End If
                                                                          Return "<span style='white-space: nowrap;' title='" & dr.Item(DataColumn.ColumnName).ToString & "'>" & dr.Item(DataColumn.ColumnName).ToString & "</span><input type='hidden' value='" & HtmlColor & "' name='row-color' />"

                                                                  End Function)

                                     ElseIf DataColumn.ColumnName = "Comments" Then

                                         columns.Bound(DataColumn.ColumnName) _
                                             .Width(150) _
                                             .Template(Function(dr)
                                                               Dim controlName = DataColumn.ColumnName & "_" & dr.Row.Table.Rows.IndexOf(dr.Row).ToString
                                                               Dim val As String = Nothing
                                                               If Not IsDBNull(dr.Item(DataColumn.ColumnName)) Then
                                                                   val = dr.Item(DataColumn.ColumnName)
                                                               End If
                                                               Return Html.TextArea(controlName, val).ToHtmlString
                                                       End Function)

                                     ElseIf DataColumn.ColumnName = "Budget" Then
                                         columns.Bound(DataColumn.ColumnName) _
                                            .Width(100) _
                                            .Title("Forecast") _
                                            .Format("{0:n2}")

                                     ElseIf DataColumn.ColumnName = "Actual" OrElse _
                                            DataColumn.ColumnName = "Variance" Then
                                         
                                         columns.Bound(DataColumn.ColumnName) _
                                             .Width(100) _
                                             .Format("{0:n2}")

                                     ElseIf DataColumn.ColumnName = "ClientName" Then

                                         columns.Bound(DataColumn.ColumnName).GroupHeaderTemplate(Function(dr)
                                                                                                          Return dr.Key
                                                                                                  End Function).Hidden()

                                     Else

                                         'columns.Bound(DataColumn.ColumnName).Hidden()

                                     End If

                                 Next

                                 For Each UniqueYear In Hierarchy

                                     columns.Group(Sub(group)
                                                           group.Title(UniqueYear.Key.ToString) _
                                                               .Columns(Sub(info)
                                                                                For Each UniqueMonth In UniqueYear.Value
                                                                                    info.Group(Sub(postPeriod)
                                                                                                       postPeriod.Title([Enum].GetName(GetType(AdvantageFramework.DateUtilities.Months), UniqueMonth.Key))
                                                                                                       postPeriod.Columns(Sub(pp)
                                                                                                                                  For Each postP In UniqueMonth.Value
                                                                                                                                      pp.Bound(postP).Width(100) _
                                                                                                                                         .Template(Function(dr)
                                                                                                                                                           Dim controlName = postP & "_" & dr.Row.Table.Rows.IndexOf(dr.Row).ToString
                                                                                                                                                           Dim val As Decimal? = Nothing
                                                                                                                                                           If Not IsDBNull(dr.Item(postP)) Then
                                                                                                                                                               val = CDec(dr.Item(postP))
                                                                                                                                                           End If
                                                                                                                                                           Return Html.Kendo.NumericTextBox().Name(controlName).Value(val).Spinners(False).Decimals(2).Format("n2").ToHtmlString & " <script> $('#" & controlName & "').width(100); </script> "
                                                                                                                                                   End Function) _
                                                                                                                                         .Title(If(postP.StartsWith("Billing"), "Billing", "Revenue"))
                                                                                                                                  Next
                                                                                                                          End Sub)
                                                                                               End Sub)

                                                                                Next
                                                                        End Sub)
                                                   End Sub)
                                 Next

                         End Sub) _
            .Pageable() _
            .Groupable(Sub(g)
                               g.Enabled(True)
                               g.ShowFooter(False)
                       End Sub) _
        .Scrollable(Sub(scroll)
                            scroll.Enabled(False)
                    End Sub) _
            .Selectable(Sub(s)
                                s.Enabled(False)
                        End Sub) _
            .Events(Sub(e)
                            'e.DataBound("gridDataBound")
                    End Sub) _
            .DataSource(Sub(d)
                                d.Server() _
                                .Group(Sub(g)
                                               g.Add("ClientName", GetType(String), ComponentModel.ListSortDirection.Ascending)
                                       End Sub) _
                                .Model(Sub(m)
                                               m.Id(Function(i) i.Item(0))
                                       End Sub)
                        End Sub) _
            .Render()

        End Code
    </div>
</div>

<script>

    $(document).ready(function () {
        $('#Description').width(800);
        $('#Comment').width(800).height(80);
    });

    function initGrid() {
        if ($('#Grid > table[role=grid]')[0]) {
            $('#Grid').width($('#Grid > table[role=grid]').width());
            $('input[name=row-color]').each(function () {
                if ($(this).val() && $(this).val() != '') {
                    $(this).closest('tr').css('background', $(this).val());
                }
            });
        } else {
            setTimeout(function () { initGrid(); }, 100);
        }
    }
    initGrid();

</script>
