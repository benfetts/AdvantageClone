Namespace Database.Procedures.PromotionType

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PromotionType)

            Load = From PromotionType In DbContext.GetQuery(Of Database.Entities.PromotionType)
                   Select PromotionType

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PromotionType As AdvantageFramework.Database.Entities.PromotionType) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.PromotionTypes.Add(PromotionType)

                ErrorText = PromotionType.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PromotionType As AdvantageFramework.Database.Entities.PromotionType) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PromotionType)

                ErrorText = PromotionType.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PromotionType As AdvantageFramework.Database.Entities.PromotionType) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    If (From Entity In DbContext.GetQuery(Of Database.Entities.Job)
                        Where Entity.PromotionCode.ToUpper = PromotionType.Code.ToUpper
                        Select Entity).Any Then

                        IsValid = False

                        ErrorText = "This code is in use and cannot be deleted."

                    End If

                Catch ex As Exception
                    ErrorText = "Failed deleting promotion type."
                    IsValid = False
                End Try

                If IsValid Then

                    DbContext.DeleteEntityObject(PromotionType)

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