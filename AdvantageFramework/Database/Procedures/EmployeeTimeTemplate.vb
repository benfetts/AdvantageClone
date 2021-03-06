Namespace Database.Procedures.EmployeeTimeTemplate

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

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal EmployeeTimeTemplateID As Integer) As Database.Entities.EmployeeTimeTemplate

            Try

                LoadByID = (From EmployeeTimeTemplate In DbContext.GetQuery(Of Database.Entities.EmployeeTimeTemplate)
                            Where EmployeeTimeTemplate.EmployeeTimeTemplateID = EmployeeTimeTemplateID
                            Select EmployeeTimeTemplate).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimeTemplate)

            Load = From EmployeeTimeTemplate In DbContext.GetQuery(Of Database.Entities.EmployeeTimeTemplate)
                   Select EmployeeTimeTemplate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeTemplate As AdvantageFramework.Database.Entities.EmployeeTimeTemplate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimeTemplates.Add(EmployeeTimeTemplate)

                ErrorText = EmployeeTimeTemplate.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeTemplate As AdvantageFramework.Database.Entities.EmployeeTimeTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimeTemplate)

                ErrorText = EmployeeTimeTemplate.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeTemplate As AdvantageFramework.Database.Entities.EmployeeTimeTemplate) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimeTemplate)

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
