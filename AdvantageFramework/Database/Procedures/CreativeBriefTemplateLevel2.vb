Namespace Database.Procedures.CreativeBriefTemplateLevel2

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

        Public Function LoadByCreativeBriefTemplateLevel1ID(ByVal DbContext As Database.DbContext, ByVal CreativeBriefTemplateLevel1ID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CreativeBriefTemplateLevel2)

            LoadByCreativeBriefTemplateLevel1ID = From CreativeBriefTemplateLevel2 In DbContext.GetQuery(Of Database.Entities.CreativeBriefTemplateLevel2)
                                                  Where CreativeBriefTemplateLevel2.CreativeBriefTemplateLevel1ID = CreativeBriefTemplateLevel1ID
                                                  Select CreativeBriefTemplateLevel2

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CreativeBriefTemplateLevel2)

            Load = From CreativeBriefTemplateLevel2 In DbContext.GetQuery(Of Database.Entities.CreativeBriefTemplateLevel2)
                   Select CreativeBriefTemplateLevel2

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplateLevel2 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    CreativeBriefTemplateLevel2.ID = (From Entity In Load(DbContext)
                                                      Select Entity.ID).ToList.Max + 1

                Catch ex As Exception
                    CreativeBriefTemplateLevel2.ID = 1
                End Try

                Try

                    If CreativeBriefTemplateLevel2.OrderNumber Is Nothing Then

                        CreativeBriefTemplateLevel2.OrderNumber = (From Entity In LoadByCreativeBriefTemplateLevel1ID(DbContext, CreativeBriefTemplateLevel2.CreativeBriefTemplateLevel1ID)
                                                                   Select Entity.OrderNumber).ToList.Max + 1

                    End If

                Catch ex As Exception
                    CreativeBriefTemplateLevel2.OrderNumber = 1
                End Try

                DbContext.CreativeBriefTemplateLevel2s.Add(CreativeBriefTemplateLevel2)

                ErrorText = CreativeBriefTemplateLevel2.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplateLevel2 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(CreativeBriefTemplateLevel2)

                ErrorText = CreativeBriefTemplateLevel2.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplateLevel2 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel2) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each CreativeBriefTemplateLevel3Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel3.LoadByCreativeBriefTemplateLevel2ID(DbContext, CreativeBriefTemplateLevel2.ID).ToList

                        DbContext.DeleteEntityObject(CreativeBriefTemplateLevel3Entity)

                    Next

                    DbContext.DeleteEntityObject(CreativeBriefTemplateLevel2)

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
