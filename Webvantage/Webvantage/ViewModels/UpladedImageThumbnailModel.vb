Imports System.Collections.Generic

Namespace ViewModels


    Public Class UpladedImageThumbnailViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DocumentId As Integer = Nothing
        Public Property RowId As Integer = Nothing
        Public Property InvoiceNumber As String = String.Empty
        Public Property Filename As String = String.Empty
        Public Property Mimetype As String = String.Empty
        Public Property Description As String = String.Empty
        Public Property UploadedDate As String = String.Empty
        Public Property ExpenceDescription As String = String.Empty
        Public Property RepositoryFilename As String = String.Empty
        Public Property ThumbnailData As String = String.Empty
        Public Property extension As String = String.Empty
        Public Property Rows As List(Of Integer)


#End Region

#Region " Methods "
        Public Sub New()
            Rows = New List(Of Integer)
        End Sub

#End Region

    End Class

End Namespace
