Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Providers
Imports System.IO
Imports System.Linq
Imports System.Web

Namespace AdvantageMobile.DataService

    Public Interface IFileSource
        ReadOnly Property File() As Byte()
    End Interface

    <System.Serializable()> Public Class FileStreamProvider
        Implements IDataServiceStreamProvider

        Public Sub DeleteStream(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) Implements IDataServiceStreamProvider.DeleteStream
            Throw New NotImplementedException()
        End Sub

        Public Function GetReadStream(ByVal entity As Object, ByVal etag As String, ByVal checkETagForEquality? As Boolean,
                                      ByVal operationContext As DataServiceOperationContext) As Stream Implements IDataServiceStreamProvider.GetReadStream
            If checkETagForEquality.HasValue Then
                Throw New DataServiceException(400, "This sample service does not support the ETag header for a media resource.")
            End If

            Dim FileSource = TryCast(entity, IFileSource)
            If FileSource Is Nothing Then
                Throw New DataServiceException(500, "Internal Server Error.")
            End If
            Dim File = FileSource.File

            Return New MemoryStream(File)

        End Function

        Public Function GetReadStreamUri(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) As Uri Implements IDataServiceStreamProvider.GetReadStreamUri
            Return Nothing
        End Function

        Public Function GetStreamContentType(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) As String Implements IDataServiceStreamProvider.GetStreamContentType
            Return "image/png"
        End Function

        Public Function GetStreamETag(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) As String Implements IDataServiceStreamProvider.GetStreamETag
            Return Nothing
        End Function

        Public Function GetWriteStream(ByVal entity As Object, ByVal etag As String, ByVal checkETagForEquality? As Boolean, ByVal operationContext As DataServiceOperationContext) As Stream Implements IDataServiceStreamProvider.GetWriteStream
            Throw New NotImplementedException()
        End Function

        Public Function ResolveType(ByVal entitySetName As String, ByVal operationContext As DataServiceOperationContext) As String Implements IDataServiceStreamProvider.ResolveType
            Return "AdvantageMobile." & entitySetName
        End Function

        Public ReadOnly Property StreamBufferSize() As Integer Implements IDataServiceStreamProvider.StreamBufferSize
            Get
                Return 64000
            End Get
        End Property

    End Class

End Namespace
