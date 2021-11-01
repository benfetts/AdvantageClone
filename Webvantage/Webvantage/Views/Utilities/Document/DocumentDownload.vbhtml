@ModelType Webvantage.ViewModels.Document.DocumentDownloadModel
@Code
    ViewData("Title") = "Document Download"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code
@Section PageHeader
    <div class="panel-heading bg-primary">
        <div class="panel-title" style="text-align:center">
            @If Model.DocumentDownloadDetailModels.Count < 2 Then
                @<h2>Download Document</h2>
            Else
                @<h2>Download Document(s)</h2>
            End If
        </div>
    </div>
End Section
<br />
@If Model.IsValid = False Then

    If Model.DocumentHasExpired Then

        @<div class="alert alert-danger">
            <strong>Link for document has expired.</strong>
        </div>

    ElseIf Model.InvalidEmployee Then

        @<div class="alert alert-danger">
            <strong>Link to document has invalid employee.</strong>
        </div>

    Else

        @<div class="alert alert-danger">
            <strong>Invalid document requested.</strong>
        </div>

    End If

Else

    @<div Class="row">
        <div Class="form-group">
            @If Model.DocumentDownloadDetailModels.Count > 1 Then
            @Ajax.ActionLink("Download All Documents", "DownloadAllDocuments", New With {.QueryString = Model.QueryString}, New AjaxOptions With {.HttpMethod = "Post"})
            End If
        </div>
    </div>
    @<table id="DocumentDetails" class="table table-striped table-condensed table-responsive">
        <thead>
            <tr>
                <th>

                </th>
                <th>
                    File
                </th>
                <th>
                    Level
                </th>
                <th>
                    Level Details
                </th>
            </tr>
        </thead>
        <tbody>
            @Code
                Dim DetailCounter As Integer = 0
                For DetailCounter = 0 To Model.DocumentDownloadDetailModels.Count - 1
            @<tr>
                <td>
                    @Ajax.ActionLink("Download", "DownloadDocument", New With {.EncryptedID = Model.DocumentDownloadDetailModels(DetailCounter).EncryptedID}, New AjaxOptions With {.HttpMethod = "Post"})
                </td>
                <td>
                    @Html.DisplayFor(Function(M) Model.DocumentDownloadDetailModels(DetailCounter).FileName)
                </td>
                <td>
                    @Html.DisplayFor(Function(M) Model.DocumentDownloadDetailModels(DetailCounter).Level)
                </td>
                <td>
                    @Html.DisplayFor(Function(M) Model.DocumentDownloadDetailModels(DetailCounter).LevelDetails)
                </td>
            </tr>
                Next DetailCounter
            End Code
        </tbody>
    </table>

                End If