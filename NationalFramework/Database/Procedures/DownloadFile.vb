Namespace Database.Procedures.DownloadFile

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByFileName(DbContext As Database.DbContext, FileName As String) As Database.Entities.DownloadFile

            LoadByFileName = (From DownloadFile In DbContext.GetQuery(Of Database.Entities.DownloadFile)
                              Where DownloadFile.FileName.ToUpper = FileName.ToUpper
                              Select DownloadFile).SingleOrDefault

        End Function
        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.DownloadFile

            LoadByID = (From DownloadFile In DbContext.GetQuery(Of Database.Entities.DownloadFile)
                        Where DownloadFile.ID = ID
                        Select DownloadFile).SingleOrDefault

        End Function
        Public Function LoadUnprocessed(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DownloadFile)

            LoadUnprocessed = From DownloadFile In DbContext.GetQuery(Of Database.Entities.DownloadFile)
                              Where DownloadFile.ProcessedTime Is Nothing
                              Select DownloadFile

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DownloadFile)

            Load = From DownloadFile In DbContext.GetQuery(Of Database.Entities.DownloadFile)
                   Select DownloadFile

        End Function
        Public Function Delete(DbContext As Database.DbContext, DownloadFileID As Integer, ByRef ErrorText As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.DOWNLOAD_FILE WHERE DOWNLOAD_FILE_ID = {0}", DownloadFileID))

                Deleted = True

            Catch ex As Exception
                ErrorText = ex.Message
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
