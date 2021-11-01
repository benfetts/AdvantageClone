Namespace Database.Procedures.CreativeBriefDetail

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

        Public Function LoadByCreativeBriefTemplateLevel3ID(ByVal DbContext As Database.DbContext, ByVal CreativeBriefTemplateLevel3ID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CreativeBriefDetail)

            LoadByCreativeBriefTemplateLevel3ID = From CreativeBriefDetail In DbContext.GetQuery(Of Database.Entities.CreativeBriefDetail)
                                                  Where CreativeBriefDetail.CreativeBriefTemplateLevel3ID = CreativeBriefTemplateLevel3ID
                                                  Select CreativeBriefDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CreativeBriefDetail)

            Load = From CreativeBriefDetail In DbContext.GetQuery(Of Database.Entities.CreativeBriefDetail)
                   Select CreativeBriefDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefDetail As AdvantageFramework.Database.Entities.CreativeBriefDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.CreativeBriefDetails.Add(CreativeBriefDetail)

                ErrorText = CreativeBriefDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefDetail As AdvantageFramework.Database.Entities.CreativeBriefDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(CreativeBriefDetail)

                ErrorText = CreativeBriefDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CreativeBriefDetail As AdvantageFramework.Database.Entities.CreativeBriefDetail) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(CreativeBriefDetail)

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
