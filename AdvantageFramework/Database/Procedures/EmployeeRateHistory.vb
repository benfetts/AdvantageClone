Namespace Database.Procedures.EmployeeRateHistory

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

        Public Function LoadByEmployeeRateHistoryID(ByVal DbContext As Database.DbContext, ByVal EmployeeRateHistoryID As Integer) As Database.Entities.EmployeeRateHistory

            Try

                LoadByEmployeeRateHistoryID = (From EmployeeRateHistory In DbContext.GetQuery(Of Database.Entities.EmployeeRateHistory)
                                               Where EmployeeRateHistory.ID = EmployeeRateHistoryID
                                               Select EmployeeRateHistory).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeRateHistoryID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeRateHistory)

            Load = From EmployeeRateHistory In DbContext.GetQuery(Of Database.Entities.EmployeeRateHistory)
                   Select EmployeeRateHistory

        End Function
        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeRateHistory)

            LoadByEmployeeCode = From EmployeeRateHistory In DbContext.GetQuery(Of Database.Entities.EmployeeRateHistory)
                                 Where EmployeeRateHistory.EmployeeCode = EmployeeCode
                                 Select EmployeeRateHistory

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeRateHistories.Add(EmployeeRateHistory)

                ErrorText = EmployeeRateHistory.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeRateHistory)

                ErrorText = EmployeeRateHistory.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeRateHistory)

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
