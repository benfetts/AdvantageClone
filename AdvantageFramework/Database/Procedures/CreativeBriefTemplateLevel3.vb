Namespace Database.Procedures.CreativeBriefTemplateLevel3

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

        Public Function LoadByCreativeBriefTemplateLevel2ID(ByVal DbContext As Database.DbContext, ByVal CreativeBriefTemplateLevel2ID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CreativeBriefTemplateLevel3)

            LoadByCreativeBriefTemplateLevel2ID = From CreativeBriefTemplateLevel3 In DbContext.GetQuery(Of Database.Entities.CreativeBriefTemplateLevel3)
                                                  Where CreativeBriefTemplateLevel3.CreativeBriefTemplateLevel2ID = CreativeBriefTemplateLevel2ID
                                                  Select CreativeBriefTemplateLevel3

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CreativeBriefTemplateLevel3)

            Load = From CreativeBriefTemplateLevel3 In DbContext.GetQuery(Of Database.Entities.CreativeBriefTemplateLevel3)
                   Select CreativeBriefTemplateLevel3

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplateLevel3 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    CreativeBriefTemplateLevel3.ID = (From Entity In Load(DbContext)
                                                      Select Entity.ID).ToList.Max + 1

                Catch ex As Exception
                    CreativeBriefTemplateLevel3.ID = 1
                End Try

                Try

                    If CreativeBriefTemplateLevel3.OrderNumber Is Nothing Then

                        CreativeBriefTemplateLevel3.OrderNumber = (From Entity In LoadByCreativeBriefTemplateLevel2ID(DbContext, CreativeBriefTemplateLevel3.CreativeBriefTemplateLevel2ID)
                                                                   Select Entity.OrderNumber).ToList.Max + 1

                    End If

                Catch ex As Exception
                    CreativeBriefTemplateLevel3.OrderNumber = 1
                End Try

                DbContext.CreativeBriefTemplateLevel3s.Add(CreativeBriefTemplateLevel3)

                ErrorText = CreativeBriefTemplateLevel3.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplateLevel3 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(CreativeBriefTemplateLevel3)

                ErrorText = CreativeBriefTemplateLevel3.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplateLevel3 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel3) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(CreativeBriefTemplateLevel3)

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
