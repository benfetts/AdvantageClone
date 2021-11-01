Namespace Database.Procedures.EmployeeAdditionalEmail

    <HideModuleName()>
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

        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeAdditionalEmail)

            LoadByEmployeeCode = From EmployeeAdditionalEmail In DbContext.GetQuery(Of Database.Entities.EmployeeAdditionalEmail)
                                 Where EmployeeAdditionalEmail.EmployeeCode = EmployeeCode
                                 Select EmployeeAdditionalEmail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeAdditionalEmail)

            Load = From EmployeeAdditionalEmail In DbContext.GetQuery(Of Database.Entities.EmployeeAdditionalEmail)
                   Select EmployeeAdditionalEmail

        End Function

        Public Function LoadByEmployeeEmail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeEmail As String) As AdvantageFramework.Database.Entities.EmployeeAdditionalEmail

            Try

                LoadByEmployeeEmail = (From EmployeeAdditionalEmail In DbContext.GetQuery(Of Database.Entities.EmployeeAdditionalEmail)
                                       Where EmployeeAdditionalEmail.Email = EmployeeEmail
                                       Select EmployeeAdditionalEmail).FirstOrDefault

            Catch ex As Exception
                LoadByEmployeeEmail = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeAdditionalEmail As AdvantageFramework.Database.Entities.EmployeeAdditionalEmail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeAdditionalEmails.Add(EmployeeAdditionalEmail)

                ErrorText = EmployeeAdditionalEmail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeAdditionalEmail As AdvantageFramework.Database.Entities.EmployeeAdditionalEmail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeAdditionalEmail)

                ErrorText = EmployeeAdditionalEmail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As Database.DbContext, ByVal EmployeeAdditionalEmail As AdvantageFramework.Database.Entities.EmployeeAdditionalEmail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeAdditionalEmail)

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
