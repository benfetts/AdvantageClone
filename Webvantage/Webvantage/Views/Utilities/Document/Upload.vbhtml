@ModelType AdvantageFramework.ViewModels.Document.UploadViewModel
@Code
	ViewData("Title") = "Upload A New Document(s)"
	Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code
@Section PageHeader
	<div class="panel-heading bg-primary">
		<div class="panel-title" style="text-align:center">
			<h2>Upload A New Document(s)</h2>
		</div>
	</div>
End Section
<br />

@If Model.IsValid = False Then

	If Model.DocumentHasExpired Then

		@<div class="alert alert-danger">
			<strong>Link to upload a document has expired.</strong>
		</div>

	Else

		@<div class="alert alert-danger">
			<strong>Invalid upload link.</strong>
		</div>

	End If

Else

	@<div style="align-content:center">
		<h1 style="text-align:center">

			@Model.DocumentLevel <br />

		</h1>
		<h3 style="text-align:center">

			@If String.IsNullOrWhiteSpace(Model.DocumentSubLevel) = False Then

				@Model.DocumentSubLevel @<br />

			End If

		</h3>

		<div style="padding-left:25%;padding-right:10%">
			<h5 style="text-align:start">

				@If String.IsNullOrWhiteSpace(Model.DocumentLevelProperties) = False Then

					@Html.Raw(Model.DocumentLevelProperties.Replace(System.Environment.NewLine, "<br />"))

				End If

			</h5>
		</div>

	</div>

	@<hr/>

	If Model.UploadedSucessfully Then

		@<div>
			<h5>Document has been uploaded!</h5>
		</div>

					Else

		@<form method = "post" action='@Url.Action("Upload")' enctype="multipart/form-data" class="form-horizontal">

			@Html.HiddenFor(Function(M) Model.IsValid)
			@Html.HiddenFor(Function(M) Model.DocumentHasExpired)
			@Html.HiddenFor(Function(M) Model.ConnectionString)
			@Html.HiddenFor(Function(M) Model.UserCode)
		 	@Html.HiddenFor(Function(M) Model.DocumentLevelSettingASPString)
			@Html.HiddenFor(Function(M) Model.DocumentLevel)
			@Html.HiddenFor(Function(M) Model.DocumentSubLevel)
			@Html.HiddenFor(Function(M) Model.DocumentLevelProperties)
			@Html.HiddenFor(Function(M) Model.FileSizeMessage)
			@Html.HiddenFor(Function(M) Model.FileLinkMessage)
			@Html.HiddenFor(Function(M) Model.MaxFileSize)
			@Html.HiddenFor(Function(M) Model.UploadedSucessfully)

			@Html.AntiForgeryToken()

			@Html.ValidationSummary(False, "", New With {.style = "color:red"})

			<div class="form-group">
				<label class="col-md-2 control-label" style="padding-right:8px">
					@Html.DisplayNameFor(Function(M) M.FileOrLink):
				</label>
				<div class="col-md-10">
					@(Html.Kendo.ComboBoxFor(Function(M) M.FileOrLink).BindTo(New List(Of SelectListItem) From {New SelectListItem With {.Text = "File\Document", .Value = "File"}, New SelectListItem With {.Text = "Link", .Value = "Link"}}) _
																								.SelectedIndex(0) _
																								.Events(Function(e) e.Change("FileOrLink_Change")))
				</div>
			</div>

			<div id="FileProperties">

				<div class="form-group">
					<label class="col-md-2 control-label" style="padding-right:8px">
						Selected Files:
					</label>
					<div class="col-md-10">
						@(Html.Kendo().Upload.Name("UploadFiles").Multiple(True))
					</div>
				</div>

				<div class="form-group">
					<label class="col-md-2 control-label" style="padding-right:8px">&nbsp;
					</label>
					<div class="col-md-10">
						@Html.DisplayFor(Function(M) M.FileSizeMessage)
					</div>
				</div>

			</div>

			<div id="LinkProperties" hidden="hidden">

				<div class="form-group">
					<label class="col-md-2 control-label" style="padding-right:8px">
						@Html.DisplayNameFor(Function(M) M.LinkName):
					</label>
					<div class="col-md-10">
						@Html.TextBoxFor(Function(M) M.LinkName, New With {.class = "form-control"})
					</div>
				</div>

				<div class="form-group">
					<label class="col-md-2 control-label" style="padding-right:8px">
						@Html.DisplayNameFor(Function(M) M.LinkURL):
					</label>
					<div class="col-md-10">
						@Html.TextBoxFor(Function(M) M.LinkURL, New With {.class = "form-control"})
					</div>
				</div>

				<div class="form-group">
					<label class="col-md-2 control-label" style="padding-right:8px">
						&nbsp;
					</label>
					<div class="col-md-10">
						@Html.DisplayFor(Function(M) M.FileLinkMessage)
					</div>
				</div>

			</div>

			<div class="form-group">
				<label class="col-md-2 control-label" style="padding-right:8px">
					@Html.DisplayNameFor(Function(M) M.DocumentTypeID):
				</label>
				<div class="col-md-10">
					@Html.Kendo.ComboBoxFor(Function(M) M.DocumentTypeID).DataValueField("ID").DataTextField("Name").BindTo(Model.DocumentTypes).AutoBind(True).ValuePrimitive(True)
				</div>
			</div>

			<div class="form-group">
				<label class="col-md-2 control-label" style="padding-right:8px">
					@Html.DisplayNameFor(Function(M) M.IsPrivate)?
				</label>
				<div class="col-md-10">
					@Html.CheckBoxFor(Function(M) M.IsPrivate)
				</div>
			</div>

			<div class="form-group">
				<label class="col-md-2 control-label" style="padding-right:8px">
					@Html.DisplayNameFor(Function(M) M.Description):
				</label>
				<div class="col-md-10">
					@Html.TextBoxFor(Function(M) M.Description, New With {.class = "form-control"})
				</div>
			</div>

			<div class="form-group">
				<label class="col-md-2 control-label" style="padding-right:8px">
					@Html.DisplayNameFor(Function(M) M.Keywords):
				</label>
				<div class="col-md-10">
					@Html.TextBoxFor(Function(M) M.Keywords, New With {.class = "form-control"})
				</div>
			</div>

			<div class="form-group">
				<label class="col-md-2 control-label" style="padding-right:8px">
					@Html.DisplayNameFor(Function(M) M.Labels):
				</label>
				<div class="col-md-10">
					@Html.Kendo.MultiSelectFor(Function(M) M.SelectedLabelIDs).AutoClose(False).DataValueField("ID").DataTextField("Name").BindTo(Model.Labels)
				</div>
			</div>

		 	<div class="form-group">
		   		<label class="col-md-2 control-label" style="padding-right:8px">
		   			&nbsp;
			   </label>
		   		<div class="col-md-10">
		   			<button class="btn btn-lg btn-primary btn-block" type="submit" value="Upload" style="padding-left:10px;padding-right:0px">Upload</button>
		   		</div>
		   	</div>

		</form>

					End If

				End If

@Section PageScripts

	<script>

		function FileOrLink_Change(e) {

			var value = this.value();

			if (value == "File") {

				$("#FileProperties").show();
				$("#LinkProperties").hide();

			} else {

				$("#FileProperties").hide();
				$("#LinkProperties").show();

			}
		}

	</script>

End Section
