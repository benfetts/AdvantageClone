Imports System.Web.Mvc
Imports System.Drawing

Public Class ImageResult
    Inherits System.Web.Mvc.ActionResult

#Region " Properties "

    Public Property Image As Image
    Public Property ImageFormat As Imaging.ImageFormat

#End Region

#Region " Methods "

    Public Overrides Sub ExecuteResult(context As ControllerContext)

        If Me.Image Is Nothing Then

            Throw New ArgumentNullException("Image")

        End If

        If Me.ImageFormat Is Nothing Then

            Throw New ArgumentNullException("ImageFormat")

        End If

        context.HttpContext.Response.Clear()

        If ImageFormat.Equals(Imaging.ImageFormat.Bmp) Then

            context.HttpContext.Response.ContentType = "image/bmp"

        End If

        If ImageFormat.Equals(Imaging.ImageFormat.Gif) Then

            context.HttpContext.Response.ContentType = "image/gif"

        End If

        If ImageFormat.Equals(Imaging.ImageFormat.Icon) Then

            context.HttpContext.Response.ContentType = "image/vnd.microsoft.icon"

        End If

        If ImageFormat.Equals(Imaging.ImageFormat.Jpeg) Then

            context.HttpContext.Response.ContentType = "image/jpeg"

        End If

        If ImageFormat.Equals(Imaging.ImageFormat.Png) Then

            context.HttpContext.Response.ContentType = "image/png"

        End If

        If ImageFormat.Equals(Imaging.ImageFormat.Tiff) Then

            context.HttpContext.Response.ContentType = "image/tiff"

        End If

        If ImageFormat.Equals(Imaging.ImageFormat.Wmf) Then

            context.HttpContext.Response.ContentType = "image/wmf"

        End If

        Me.Image.Save(context.HttpContext.Response.OutputStream, ImageFormat)

    End Sub
    Public Sub New()



    End Sub

#End Region

End Class
