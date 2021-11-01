@ModelType HandleErrorInfo
@Code 
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
<!DOCTYPE html>
<html>
    <head>
        <meta name="viewport" content="width=device-width" />
        <script src="@Url.Content("~/Scripts/kendo/current/jquery.min.js")"></script>
        <title>Error</title>
        <style>    
            html, body, form { 
                height: 100% !important; 
                margin: 0px !important; 
                padding: 0px !important; 
                background: white;
                font-family: "Open Sans", Calibri, Tahoma, Verdana, Arial, sans-serif;
                -webkit-font-smoothing: antialiased;
            }
        </style>
    </head>
    <body>
        @Code
            Try

                If Model IsNot Nothing AndAlso Model.Exception IsNot Nothing Then

                    'If Session(MiscFN.ShowErrorSessionKey) Is Nothing OrElse CType(Session(MiscFN.ShowErrorSessionKey), Boolean) = True Then
                    If Session("ii8j47EohQAB5ZFYGE3cdqy") Is Nothing OrElse CType(Session("ii8j47EohQAB5ZFYGE3cdqy"), Boolean) = True Then

                        @<div style="margin-top: 10px;">
                            <h1 class="alert alert-danger text-danger" role="alert">Error</h1>
                            <h3 style="margin: 0px 20px 0px 20px;">@Model.Exception.Message</h3>
                        </div>


                    Else


                        @<div style="margin-top: 10px;">
                            <h1 class="alert alert-danger text-danger" role="alert">Error</h1>
                            <h3 style="margin: 0px 20px 0px 20px;">Please contact Advantage support.</h3>
                        </div>

                    End If

                End If

            Catch ex As Exception
                @<h1 Class="text-danger">Error</h1>
            End Try
        End Code
    </body>
</html>
