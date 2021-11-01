Namespace Database.Procedures.AlertEmployeeHour

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

        Public Function LoadByEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertEmployeeHour)

            LoadByEmployeeCode = From AlertEmployeeHour In DbContext.GetQuery(Of Database.Entities.AlertEmployeeHour)
                                 Where AlertEmployeeHour.EmployeeCode
                                 Select AlertEmployeeHour

        End Function
        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal AlertID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertEmployeeHour)

            LoadByAlertID = From AlertEmployeeHour In DbContext.GetQuery(Of Database.Entities.AlertEmployeeHour)
                            Where AlertEmployeeHour.AlertID = AlertID
                            Select AlertEmployeeHour

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertEmployeeHour)

            Load = From AlertEmployeeHour In DbContext.GetQuery(Of Database.Entities.AlertEmployeeHour)
                   Select AlertEmployeeHour

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal AlertEmployeeHour As AdvantageFramework.Database.Entities.AlertEmployeeHour) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AlertEmployeeHours.Add(AlertEmployeeHour)

                ErrorText = AlertEmployeeHour.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal AlertEmployeeHour As AdvantageFramework.Database.Entities.AlertEmployeeHour) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AlertEmployeeHour)

                ErrorText = AlertEmployeeHour.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal AlertEmployeeHour As AdvantageFramework.Database.Entities.AlertEmployeeHour) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AlertEmployeeHour)

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
