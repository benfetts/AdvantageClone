Namespace Database.Procedures.EmployeeCategory

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeCategory)

            LoadAllActive = From EmployeeCategory In DbContext.GetQuery(Of Database.Entities.EmployeeCategory)
                            Where EmployeeCategory.IsInactive Is Nothing OrElse
                                    EmployeeCategory.IsInactive = 0
                            Select EmployeeCategory

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeCategory)

            Load = From EmployeeCategory In DbContext.GetQuery(Of Database.Entities.EmployeeCategory)
                   Select EmployeeCategory

        End Function
        Public Function LoadByEmployeeCategoryID(ByVal DbContext As Database.DbContext, ByVal EmployeeCategoryID As Integer) As Database.Entities.EmployeeCategory

            Try

                LoadByEmployeeCategoryID = (From EmployeeCategory In DbContext.GetQuery(Of Database.Entities.EmployeeCategory)
                                            Where EmployeeCategory.ID = EmployeeCategoryID
                                            Select EmployeeCategory).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeCategoryID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCategory As AdvantageFramework.Database.Entities.EmployeeCategory) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeCategories.Add(EmployeeCategory)

                ErrorText = EmployeeCategory.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCategory As AdvantageFramework.Database.Entities.EmployeeCategory) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeCategory)

                ErrorText = EmployeeCategory.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCategory As AdvantageFramework.Database.Entities.EmployeeCategory) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    If (From Entity In DbContext.GetQuery(Of Database.Entities.EmployeeTitle)
                        Where Entity.EmployeeCategoryID = EmployeeCategory.ID
                        Select Entity).Any Then

                        IsValid = False

                        ErrorText = "This employee category is in use and cannot be deleted."

                    End If

                Catch ex As Exception
                    ErrorText = "Failed deleting employee category."
                    IsValid = False
                End Try

                If IsValid Then

                    Try

                        If (From Entity In DbContext.GetQuery(Of Database.Entities.EmployeeCategory)
                            Where Entity.Description.ToUpper = EmployeeCategory.Description.ToUpper AndAlso
                                     Entity.ID <> EmployeeCategory.ID
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique employee category."

                        End If

                    Catch ex As Exception
                        ErrorText = "Failed deleting employee category."
                        IsValid = False
                    End Try

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeCategory)

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
