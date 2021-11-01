Namespace Database.Procedures.CreativeBriefTemplateLevel1

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

        Public Function LoadByCreativeBriefTemplateID(ByVal DbContext As Database.DbContext, ByVal CreativeBriefTemplateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CreativeBriefTemplateLevel1)

            LoadByCreativeBriefTemplateID = From CreativeBriefTemplateLevel1 In DbContext.GetQuery(Of Database.Entities.CreativeBriefTemplateLevel1)
                                            Where CreativeBriefTemplateLevel1.CreativeBriefTemplateID = CreativeBriefTemplateID
                                            Select CreativeBriefTemplateLevel1

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CreativeBriefTemplateLevel1)

            Load = From CreativeBriefTemplateLevel1 In DbContext.GetQuery(Of Database.Entities.CreativeBriefTemplateLevel1)
                   Select CreativeBriefTemplateLevel1

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplateLevel1 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    CreativeBriefTemplateLevel1.ID = (From Entity In Load(DbContext)
                                                      Select Entity.ID).ToList.Max + 1

                Catch ex As Exception
                    CreativeBriefTemplateLevel1.ID = 1
                End Try

                Try

                    If CreativeBriefTemplateLevel1.OrderNumber Is Nothing Then

                        CreativeBriefTemplateLevel1.OrderNumber = (From Entity In LoadByCreativeBriefTemplateID(DbContext, CreativeBriefTemplateLevel1.CreativeBriefTemplateID)
                                                                   Select Entity.OrderNumber).ToList.Max + 1

                    End If

                Catch ex As Exception
                    CreativeBriefTemplateLevel1.OrderNumber = 1
                End Try

                DbContext.CreativeBriefTemplateLevel1s.Add(CreativeBriefTemplateLevel1)

                ErrorText = CreativeBriefTemplateLevel1.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplateLevel1 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(CreativeBriefTemplateLevel1)

                ErrorText = CreativeBriefTemplateLevel1.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefTemplateLevel1 As AdvantageFramework.Database.Entities.CreativeBriefTemplateLevel1) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each CreativeBriefTemplateLevel2Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel2.LoadByCreativeBriefTemplateLevel1ID(DbContext, CreativeBriefTemplateLevel1.ID).ToList

                        For Each CreativeBriefTemplateLevel3Entity In AdvantageFramework.Database.Procedures.CreativeBriefTemplateLevel3.LoadByCreativeBriefTemplateLevel2ID(DbContext, CreativeBriefTemplateLevel2Entity.ID).ToList

                            DbContext.DeleteEntityObject(CreativeBriefTemplateLevel3Entity)

                        Next

                        DbContext.DeleteEntityObject(CreativeBriefTemplateLevel2Entity)

                    Next

                    DbContext.DeleteEntityObject(CreativeBriefTemplateLevel1)

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
