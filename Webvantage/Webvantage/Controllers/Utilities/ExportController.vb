Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace Controllers.Utilities
    ''' <summary>
    ''' Copied from https://github.com/telerik/kendo-ui-demos-service
    ''' This class allows for older versions of IE to do PDF export
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ExportController
        Inherits Controller
        <HttpPost>
        Public Function Index(contentType As String, base64 As String, fileName As String) As ActionResult
            Dim fileContents = Convert.FromBase64String(base64)
            Return File(fileContents, contentType, fileName)
        End Function
    End Class
End Namespace
