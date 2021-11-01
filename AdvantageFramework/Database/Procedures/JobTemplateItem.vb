Namespace Database.Procedures.JobTemplateItem

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

        Public Function LoadByCode(ByVal DbContext As Database.DbContext, ByVal JobTemplateItemCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTemplateItem)

            LoadByCode = From JobTemplateItem In DbContext.GetQuery(Of Database.Entities.JobTemplateItem)
                         Where JobTemplateItem.Code = JobTemplateItemCode
                         Select JobTemplateItem

        End Function
        Public Function LoadRequired(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTemplateItem)

            LoadRequired = From JobTemplateItem In DbContext.GetQuery(Of Database.Entities.JobTemplateItem)
                           Where JobTemplateItem.AdvantageRequired = CByte(1)
                           Select JobTemplateItem

        End Function
        Public Function LoadByCodeandDatabaseTypeID(ByVal DbContext As Database.DbContext, ByVal DatabaseTypeID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTemplateItem)

            LoadByCodeandDatabaseTypeID = From JobTemplateItem In DbContext.GetQuery(Of Database.Entities.JobTemplateItem)
                                          Where JobTemplateItem.DatabaseTypeID = DatabaseTypeID
                                          Select JobTemplateItem

        End Function

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTemplateItem)

            Load = From JobTemplateItem In DbContext.GetQuery(Of Database.Entities.JobTemplateItem)
                   Select JobTemplateItem

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplateItem As AdvantageFramework.Database.Entities.JobTemplateItem) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobTemplateItems.Add(JobTemplateItem)

                ErrorText = JobTemplateItem.ValidateEntity(IsValid)

                If IsValid Then

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplateItem As AdvantageFramework.Database.Entities.JobTemplateItem) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobTemplateItem)

                ErrorText = JobTemplateItem.ValidateEntity(IsValid)

                If IsValid Then

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplateItem As AdvantageFramework.Database.Entities.JobTemplateItem) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobTemplateItem)

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

#End Region

    End Module

End Namespace
