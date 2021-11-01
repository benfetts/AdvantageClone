Namespace Database.Procedures.EmployeeTitle

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

        Public Function LoadByEmployeeTitleDescription(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTitleDescription As String) As AdvantageFramework.Database.Entities.EmployeeTitle

            Try

                LoadByEmployeeTitleDescription = (From EmployeeTitle In DbContext.GetQuery(Of Database.Entities.EmployeeTitle)
                                                  Where EmployeeTitle.Description = EmployeeTitleDescription
                                                  Select EmployeeTitle).FirstOrDefault

            Catch ex As Exception
                LoadByEmployeeTitleDescription = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeTitleID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTitleID As Integer) As AdvantageFramework.Database.Entities.EmployeeTitle

            Try

                LoadByEmployeeTitleID = (From EmployeeTitle In DbContext.GetQuery(Of Database.Entities.EmployeeTitle)
                                         Where EmployeeTitle.ID = EmployeeTitleID
                                         Select EmployeeTitle).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeTitleID = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTitle)

            LoadAllActive = From EmployeeTitle In DbContext.GetQuery(Of Database.Entities.EmployeeTitle)
                            Where EmployeeTitle.IsInactive Is Nothing OrElse
                                  EmployeeTitle.IsInactive = 0
                            Select EmployeeTitle
                            Order By EmployeeTitle.Description

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTitle)

            Load = From EmployeeTitle In DbContext.GetQuery(Of Database.Entities.EmployeeTitle)
                   Select EmployeeTitle
                   Order By EmployeeTitle.Description

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTitles.Add(EmployeeTitle)

                ErrorText = EmployeeTitle.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTitle)

                ErrorText = EmployeeTitle.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTitle As AdvantageFramework.Database.Entities.EmployeeTitle) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).Any(Function(Entity) Entity.EmployeeTitleID = EmployeeTitle.ID) Then

                    IsValid = False
                    ErrorText = "The employee title is in use and cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTitle)

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
