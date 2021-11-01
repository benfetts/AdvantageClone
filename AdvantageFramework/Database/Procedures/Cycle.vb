Namespace Database.Procedures.Cycle

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

        Public Function LoadByCode(ByVal DbContext As Database.DbContext, ByVal Code As String) As Database.Entities.Cycle

            Try

                LoadByCode = (From Cycle In DbContext.GetQuery(Of Database.Entities.Cycle)
                              Where Cycle.Code = Code
                              Select Cycle).SingleOrDefault

            Catch ex As Exception
                LoadByCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Cycle)

            LoadAllActive = From Cycle In DbContext.GetQuery(Of Database.Entities.Cycle)
                            Where (Cycle.IsInactive Is Nothing OrElse Cycle.IsInactive = 0)
                            Select Cycle

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Cycle)

            Load = From Cycle In DbContext.GetQuery(Of Database.Entities.Cycle)
                   Select Cycle

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Cycle As AdvantageFramework.Database.Entities.Cycle) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If Cycle.IsInactive.GetValueOrDefault(0) = 0 Then 'fix for legacy apps

                    Cycle.IsInactive = Nothing

                End If

                DbContext.Cycles.Add(Cycle)

                ErrorText = Cycle.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Cycle As AdvantageFramework.Database.Entities.Cycle) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If Cycle.IsInactive.GetValueOrDefault(0) = 0 Then 'fix for legacy apps

                    Cycle.IsInactive = Nothing

                End If

                DbContext.UpdateObject(Cycle)

                ErrorText = Cycle.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Cycle As AdvantageFramework.Database.Entities.Cycle) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(Cycle)

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
