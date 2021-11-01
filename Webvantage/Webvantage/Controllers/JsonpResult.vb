Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.IO
Imports System.Web.Script.Serialization

Namespace Controllers
    Public Class JsonpResult
        Inherits JsonResult
        Public Sub New(callbackName__1 As String)
            CallbackName = callbackName__1
        End Sub

        Public Sub New()
            Me.New("jsoncallback")
        End Sub

        Public Property CallbackName() As String
            Get
                Return m_CallbackName
            End Get
            Set(value As String)
                m_CallbackName = value
            End Set
        End Property
        Private m_CallbackName As String

        Public Overrides Sub ExecuteResult(context As ControllerContext)
            If context Is Nothing Then
                Throw New ArgumentNullException("context")
            End If

            Dim request = context.HttpContext.Request
            Dim response = context.HttpContext.Response

            Dim jsoncallback As String = If((If(TryCast(context.RouteData.Values(CallbackName), String), request(CallbackName))), CallbackName)

            If Not String.IsNullOrEmpty(jsoncallback) Then
                If String.IsNullOrEmpty(MyBase.ContentType) Then
                    MyBase.ContentType = "application/x-javascript"
                End If
                response.Write(String.Format("{0}(", jsoncallback))
            End If

            MyBase.ExecuteResult(context)

            If Not String.IsNullOrEmpty(jsoncallback) Then
                response.Write(")")
            End If
        End Sub
    End Class

End Namespace