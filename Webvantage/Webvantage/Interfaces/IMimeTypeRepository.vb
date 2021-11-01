Imports System
Imports System.Collections
Imports System.Collections.Generic

Namespace Interfaces
    Public Interface IMimeTypeRepository
#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

#End Region

#Region " Methods "
        Property MimeTypes() As Dictionary(Of String, String)
        Function GetContentType(ByVal FileName As String, Optional ByVal PullExtensionFromFileName As Boolean = True) As String
#End Region

    End Interface
End Namespace

