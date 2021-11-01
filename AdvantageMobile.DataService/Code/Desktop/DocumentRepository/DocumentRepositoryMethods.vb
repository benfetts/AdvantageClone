Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Data.Services.Providers
Imports System.Data.SqlClient
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
Imports AdvantageFramework.Security.Classes

Namespace AdvantageMobile.DataService.DocumentRepository

    <System.Serializable()> Public Class Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private Property _DataEntities As DataEntities
        Private Property _DataServiceUser As AdvantageFramework.Security.Classes.DataServiceUser
        Private Property _ConnectionString As String = ""
        Private Property _UserCode As String = ""

#End Region

#Region " Methods "

        Public Function GetDocument(ByVal DocumentID As Integer) As Byte()

            Application.DebugMessageToEventLog("GetDocument called")

            Dim DocBytes() As Byte = Nothing

            Try
                Dim Doc = (From Document In Me._DataEntities.Documents
                           Where Document.ID = DocumentID
                           Select Document).Single()

                If Doc IsNot Nothing Then

                    Dim Repository As New AdvantageMobile.DataService.DocumentRepository.Classes.Repository



                    'get from repository where filename
                    Dim RepositoryFilename As String
                    RepositoryFilename = Doc.RepositoryFilename

                    Dim FileInfo As System.IO.FileInfo = Nothing

                    If My.Computer.FileSystem.FileExists(RepositoryFilename) = True Then

                        FileInfo = My.Computer.FileSystem.GetFileInfo(RepositoryFilename)

                        If FileInfo IsNot Nothing Then

                            Using FileStream = New System.IO.FileStream(RepositoryFilename, System.IO.FileMode.Open, System.IO.FileAccess.Read)

                                Using BinaryReader = New System.IO.BinaryReader(FileStream)

                                    DocBytes = BinaryReader.ReadBytes(FileInfo.Length)

                                End Using

                            End Using
                        End If

                    End If

                End If

            Catch ex As Exception
                Application.ErrorToEventLog(ex)
            End Try

            Return DocBytes

        End Function

        Sub New(ByVal DataSource As DataEntities, ByVal CurrentDataServiceUser As AdvantageFramework.Security.Classes.DataServiceUser)

            Me._DataEntities = DataSource
            Me._DataServiceUser = CurrentDataServiceUser
            Me._ConnectionString = CurrentDataServiceUser.ConnectionString
            Me._UserCode = Me._DataServiceUser.UserCode

        End Sub

#End Region

    End Class

End Namespace

