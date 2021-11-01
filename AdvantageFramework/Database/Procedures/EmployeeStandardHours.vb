Namespace Database.Procedures.EmployeeStandardHours

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

        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As Database.Entities.EmployeeStandardHours

            Try

                LoadByUserCode = (From EmployeeStandardHours In DbContext.GetQuery(Of Database.Entities.EmployeeStandardHours)
                                  Where EmployeeStandardHours.UserCode = UserCode
                                  Select EmployeeStandardHours).SingleOrDefault

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeStandardHours)

            Load = From EmployeeStandardHours In DbContext.GetQuery(Of Database.Entities.EmployeeStandardHours)
                   Select EmployeeStandardHours

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String, _
                               ByVal CreatedDate As Date, ByVal StartDate As Date, ByVal EndDate As Date, _
                               ByRef EmployeeStandardHours As AdvantageFramework.Database.Entities.EmployeeStandardHours) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeStandardHours = New AdvantageFramework.Database.Entities.EmployeeStandardHours

                EmployeeStandardHours.DbContext = DbContext
                EmployeeStandardHours.UserCode = UserCode
                EmployeeStandardHours.CreatedDate = CreatedDate
                EmployeeStandardHours.StartDate = StartDate
                EmployeeStandardHours.EndDate = EndDate

                Inserted = Insert(DbContext, EmployeeStandardHours)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeStandardHours As AdvantageFramework.Database.Entities.EmployeeStandardHours) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeStandardHours.Add(EmployeeStandardHours)

                ErrorText = EmployeeStandardHours.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeStandardHours As AdvantageFramework.Database.Entities.EmployeeStandardHours) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeStandardHours)

                ErrorText = EmployeeStandardHours.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeStandardHours As AdvantageFramework.Database.Entities.EmployeeStandardHours) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeStandardHours)

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
        Public Function DeleteByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.W_EMP_STD_HOURS WHERE USERID = '" & UserCode & "'")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByUserCode = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
