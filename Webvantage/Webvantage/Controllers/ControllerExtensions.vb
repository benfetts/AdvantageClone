Imports System.Collections.Generic
Imports System.Web.Mvc
Imports System.Web.Script.Serialization
Namespace Controllers
    ''' <summary>
    ''' Copied from https://github.com/telerik/kendo-ui-demos-service
    ''' This class produces a json response that is safe to use cross-domain
    ''' </summary>
    ''' <remarks></remarks>
    Module ControllerExtensions
        <System.Runtime.CompilerServices.Extension>
        Public Function Jsonp(controller As Controller, data As Object, Optional callbackName As String = "callback") As JsonpResult
            Return New JsonpResult(callbackName) With {.Data = data, .JsonRequestBehavior = JsonRequestBehavior.AllowGet}
        End Function

        <System.Runtime.CompilerServices.Extension>
        Function DeserializeObject(Of T As Class)(controller As Controller, key As String) As T
            Dim value = controller.HttpContext.Request.QueryString.[Get](key)
            If String.IsNullOrEmpty(value) Then
                Return Nothing
            End If
            Dim javaScriptSerializer As New JavaScriptSerializer()
            Return javaScriptSerializer.Deserialize(Of T)(value)
        End Function
    End Module
End Namespace
