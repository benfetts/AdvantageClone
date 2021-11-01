Namespace Database.Procedures.ExportTemplateDetail

    <HideModuleName()> _
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

        Public Function LoadByExportTemplateDetailID(ByVal DbContext As Database.DbContext, ByVal ExportTemplateDetailID As Integer) As Database.Entities.ExportTemplateDetail

            Try

                LoadByExportTemplateDetailID = (From ExportTemplateDetail In DbContext.GetQuery(Of Database.Entities.ExportTemplateDetail)
                                                Where ExportTemplateDetail.ID = ExportTemplateDetailID
                                                Select ExportTemplateDetail).SingleOrDefault

            Catch ex As Exception
                LoadByExportTemplateDetailID = Nothing
            End Try

        End Function
        Public Function LoadByExportTemplateID(ByVal DbContext As Database.DbContext, ByVal ExportTemplateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExportTemplateDetail)

            LoadByExportTemplateID = From ExportTemplateDetail In DbContext.GetQuery(Of Database.Entities.ExportTemplateDetail)
                                     Where ExportTemplateDetail.ExportTemplateID = ExportTemplateID
                                     Select ExportTemplateDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ExportTemplateDetail)

            Load = From ExportTemplateDetail In DbContext.GetQuery(Of Database.Entities.ExportTemplateDetail)
                   Select ExportTemplateDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ExportTemplateDetails.Add(ExportTemplateDetail)

                ErrorText = ExportTemplateDetail.ValidateEntity(IsValid)

                If IsValid Then

                    ExportTemplateDetail.CreatedByUserCode = DbContext.UserCode
                    ExportTemplateDetail.CreatedDate = Now

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ExportTemplateDetail)

                ErrorText = ExportTemplateDetail.ValidateEntity(IsValid)

                If IsValid Then

                    ExportTemplateDetail.ModifiedByUserCode = DbContext.UserCode
                    ExportTemplateDetail.ModifiedDate = Now

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ExportTemplateDetail)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function DeleteByExportTemplateID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportTemplateID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.EXPORT_TEMPLATE_DTL WHERE EXPORT_TEMPLATE_ID = {0}", ExportTemplateID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByExportTemplateID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
