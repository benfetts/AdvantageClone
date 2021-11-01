Public Class ImageStreamProvider
    Implements System.Data.Services.Providers.IDataServiceStreamProvider

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public ReadOnly Property StreamBufferSize() As Integer Implements System.Data.Services.Providers.IDataServiceStreamProvider.StreamBufferSize
        Get
            Return 64000
        End Get
    End Property

#End Region

#Region " Methods "

    Public Sub DeleteStream(ByVal entity As Object, ByVal operationContext As System.Data.Services.DataServiceOperationContext) Implements System.Data.Services.Providers.IDataServiceStreamProvider.DeleteStream

        Throw New NotImplementedException()

    End Sub
    Public Function GetReadStream(ByVal entity As Object, ByVal etag As String, ByVal checkETagForEquality? As Boolean, ByVal operationContext As System.Data.Services.DataServiceOperationContext) As System.IO.Stream Implements System.Data.Services.Providers.IDataServiceStreamProvider.GetReadStream

        If checkETagForEquality.HasValue Then

            Throw New System.Data.Services.DataServiceException(400, "This sample service does not support the ETag header for a media resource.")

        End If

        Dim imageSource = TryCast(entity, IImageSource)

        If imageSource Is Nothing Then

            Throw New System.Data.Services.DataServiceException(500, "Internal Server Error.")

        End If

        Dim image = imageSource.Image

        Return New System.IO.MemoryStream(image)

    End Function
    Public Function GetReadStreamUri(ByVal entity As Object, ByVal operationContext As System.Data.Services.DataServiceOperationContext) As Uri Implements System.Data.Services.Providers.IDataServiceStreamProvider.GetReadStreamUri

        Return Nothing

    End Function
    Public Function GetStreamContentType(ByVal entity As Object, ByVal operationContext As System.Data.Services.DataServiceOperationContext) As String Implements System.Data.Services.Providers.IDataServiceStreamProvider.GetStreamContentType

        Return "image/png"

    End Function
    Public Function GetStreamETag(ByVal entity As Object, ByVal operationContext As System.Data.Services.DataServiceOperationContext) As String Implements System.Data.Services.Providers.IDataServiceStreamProvider.GetStreamETag

        Return Nothing

    End Function
    Public Function GetWriteStream(ByVal entity As Object, ByVal etag As String, ByVal checkETagForEquality? As Boolean, ByVal operationContext As System.Data.Services.DataServiceOperationContext) As System.IO.Stream Implements System.Data.Services.Providers.IDataServiceStreamProvider.GetWriteStream

        Throw New NotImplementedException()

    End Function
    Public Function ResolveType(ByVal entitySetName As String, ByVal operationContext As System.Data.Services.DataServiceOperationContext) As String Implements System.Data.Services.Providers.IDataServiceStreamProvider.ResolveType

        Return "AdvantageAPI." & entitySetName

    End Function

#End Region

End Class