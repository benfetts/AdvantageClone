Namespace Database.Procedures.ServiceStatus

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

        Public Function LoadSingleRecord(DbContext As Database.NielsenDbContext) As Database.Entities.ServiceStatus

            LoadSingleRecord = (From ServiceStatus In DbContext.GetQuery(Of Database.Entities.ServiceStatus)
                                Where ServiceStatus.ID = 1
                                Select ServiceStatus).SingleOrDefault

        End Function
        Public Function Insert(DbContext As Database.NielsenDbContext, ServiceStatus As Database.Entities.ServiceStatus, ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.ServiceStatuses.Add(ServiceStatus)

                ErrorText = ServiceStatus.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                Inserted = False
                ErrorText = ex.Message
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As Database.NielsenDbContext, ByVal ServiceStatus As Database.Entities.ServiceStatus, ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.UpdateObject(ServiceStatus)

                ErrorText = ServiceStatus.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
                ErrorText = ex.Message
            Finally
                Update = Updated
            End Try

        End Function

#End Region

    End Module

End Namespace
