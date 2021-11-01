@ModelType AdvantageFramework.ViewModels.Document.UploadAvailViewModel 
@Code       
    ViewData("Title") = "Upload New Avail File(s)"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code
@Section PageHeader
	<div class="panel-heading bg-primary">
		<div class="panel-title" style="text-align:center">
			<h2>Upload New File(s)</h2>
		</div>
	</div>
End Section
<br />

@If Model.IsValid = False Then

	If Model.DocumentHasExpired Then

		@<div class="alert alert-danger">
			<strong>Link to upload a file has expired.</strong>
		</div>

	Else

		@<div class="alert alert-danger">
			<strong>Invalid upload link.</strong>
		</div>

    End If

Else
	@<div style="align-content:center">
		<h1 style="text-align:center">

			@Model.DocumentDescription <br />

		</h1>
    
	</div>

	@<hr/>      If Model.UploadedSucessfully Then

		@<div>
			<h5>File has been uploaded!</h5>
		</div>

    Else

		@<form method = "post" action='@Url.Action("UploadAvail")' enctype="multipart/form-data" class="form-horizontal">

			@Html.HiddenFor(Function(M) Model.IsValid)
			@Html.HiddenFor(Function(M) Model.DocumentHasExpired)
			@Html.HiddenFor(Function(M) Model.ConnectionString)
			@Html.HiddenFor(Function(M) Model.UserCode)
			@Html.HiddenFor(Function(M) Model.UploadedSucessfully)

			@Html.AntiForgeryToken()

			@Html.ValidationSummary(False, "", New With {.style = "color:red"})
    
			<div id="FileProperties">

				<div class="form-group">
					<label class="col-md-2 control-label" style="padding-right:8px">
						Selected Files:
					</label>
					<div class="col-md-10">
						@(Html.Kendo().Upload.Name("UploadFiles").Multiple(True))
					</div>
				</div>

			</div>
    
		 	<div class="form-group">
		   		<label class="col-md-2 control-label" style="padding-right:8px">
		   			&nbsp;
			   </label>
		   		<div class="col-md-10">
		   			<button class="btn btn-lg btn-primary btn-block" type="submit" value="UploadAvail" style="padding-left:10px;padding-right:0px">Upload</button>
		   		</div>
		   	</div>

		</form> End If

End If

@Section PageScripts

	<script>

		

	</script>

End Section
