Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic

Namespace Interfaces
    Public Interface IDocumentRepository


#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

#End Region

#Region " Methods "
        Function FindDocumentHistory(Level As String, LevelKey As String, FileName As String) As List(Of ViewModels.DocumentUploadGridItem)
        Function Find(id As Integer) As AdvantageFramework.Database.Entities.Document
        Function FindDocumentGridItemsByLevel(level As String, levelKeyValue As String) As List(Of ViewModels.DocumentUploadGridItem)
        Function FindDocumentsByLevel(level As String, levelKeyValue As String) As List(Of AdvantageFramework.Database.Entities.Document)
        Function InsertDocumentDatabaseRecord(ByVal documentUpload As ViewModels.DocumentUploadInfo) As ViewModels.DocumentUploadInfo
        Function InsertDocumentFileSystemRecord(ByVal documentUpload As ViewModels.DocumentUploadInfo) As ViewModels.DocumentUploadInfo
        Function LinkDocumentToLevel(ByVal documentUpload As ViewModels.DocumentUploadInfo) As ViewModels.DocumentUploadInfo
        Function InsertAndLinkDocumentToLevel(uploadInfo As ViewModels.DocumentUploadInfo) As ViewModels.DocumentUploadInfo
        Function DeleteDocumentByLevel(level As String, documentId As Long) As Boolean
#End Region


    End Interface
End Namespace

