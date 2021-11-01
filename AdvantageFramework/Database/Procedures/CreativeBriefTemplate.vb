Namespace Database.Procedures.CreativeBriefTemplate

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

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.CreativeBriefTemplate

            Try

                LoadByID = (From CreativeBriefTemplate In DbContext.GetQuery(Of Database.Entities.CreativeBriefTemplate)
                            Where CreativeBriefTemplate.ID = ID
                            Select CreativeBriefTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByCode(ByVal DbContext As Database.DbContext, ByVal CreativeBriefTemplateCode As String) As Database.Entities.CreativeBriefTemplate

            Try

                LoadByCode = (From CreativeBriefTemplate In DbContext.GetQuery(Of Database.Entities.CreativeBriefTemplate)
                              Where CreativeBriefTemplate.Code = CreativeBriefTemplateCode
                              Select CreativeBriefTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CreativeBriefTemplate)

            Load = From CreativeBriefTemplate In DbContext.GetQuery(Of Database.Entities.CreativeBriefTemplate)
                   Select CreativeBriefTemplate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    CreativeBriefTemplate.ID = (From Entity In Load(DbContext) _
                                                Select Entity.ID).ToList.Max + 1

                Catch ex As Exception
                    CreativeBriefTemplate.ID = 1
                End Try

                DbContext.CreativeBriefTemplates.Add(CreativeBriefTemplate)

                ErrorText = CreativeBriefTemplate.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(CreativeBriefTemplate)

                ErrorText = CreativeBriefTemplate.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplate As AdvantageFramework.Database.Entities.CreativeBriefTemplate) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each CreativeBriefTemplateLevel1Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel1.LoadByCreativeBriefTemplateID(DbContext, CreativeBriefTemplate.ID).ToList

                        For Each CreativeBriefTemplateLevel2Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel2.LoadByCreativeBriefTemplateLevel1ID(DbContext, CreativeBriefTemplateLevel1Entity.ID).ToList

                            For Each CreativeBriefTemplateLevel3Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel3.LoadByCreativeBriefTemplateLevel2ID(DbContext, CreativeBriefTemplateLevel2Entity.ID).ToList

                                DbContext.DeleteEntityObject(CreativeBriefTemplateLevel3Entity)

                            Next

                            DbContext.DeleteEntityObject(CreativeBriefTemplateLevel2Entity)

                        Next

                        DbContext.DeleteEntityObject(CreativeBriefTemplateLevel1Entity)

                    Next

                    DbContext.DeleteEntityObject(CreativeBriefTemplate)

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
