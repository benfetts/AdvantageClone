Namespace Database.Procedures.TimeCategoryType

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TimeCategoryType)

            Load = From TimeCategoryType In DbContext.GetQuery(Of Database.Entities.TimeCategoryType)
                   Select TimeCategoryType

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TimeCategoryType As AdvantageFramework.Database.Entities.TimeCategoryType) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    TimeCategoryType.ID = (From Entity In Load(DbContext) _
                                           Select Entity.ID).Max + 1

                Catch ex As Exception
                    TimeCategoryType.ID = 1
                End Try

                DbContext.TimeCategoryTypes.Add(TimeCategoryType)

                ErrorText = TimeCategoryType.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TimeCategoryType As AdvantageFramework.Database.Entities.TimeCategoryType) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(TimeCategoryType)

                ErrorText = TimeCategoryType.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TimeCategoryType As AdvantageFramework.Database.Entities.TimeCategoryType) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If TimeCategoryType.DefaultUse = "Vacation" OrElse TimeCategoryType.DefaultUse = "Personal" OrElse TimeCategoryType.DefaultUse = "Sick" Then

                    IsValid = False
                    ErrorText = "Default time category types cannot be deleted."

                ElseIf (From Entity In AdvantageFramework.Database.Procedures.IndirectCategory.Load(DbContext) _
                        Where Entity.Type IsNot Nothing AndAlso _
                              Entity.Type = TimeCategoryType.ID _
                        Select Entity).Any Then

                    IsValid = False
                    ErrorText = "Time category type is in use and cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(TimeCategoryType)

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
