Namespace Database.Procedures.Phase

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

        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Phase)

            LoadAllActive = From Phase In DbContext.GetQuery(Of Database.Entities.Phase)
                            Where Phase.IsInactive = 0
                            Select Phase

        End Function
        Public Function LoadByPhaseID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PhaseID As Long) As AdvantageFramework.Database.Entities.Phase

            Try

                LoadByPhaseID = (From Phase In DbContext.GetQuery(Of Database.Entities.Phase)
                                 Where Phase.ID = PhaseID
                                 Select Phase).SingleOrDefault

            Catch ex As Exception
                LoadByPhaseID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Phase)

            Load = From Phase In DbContext.GetQuery(Of Database.Entities.Phase)
                   Select Phase

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Phase As AdvantageFramework.Database.Entities.Phase) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Phases.Add(Phase)

                ErrorText = Phase.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.Phases.Count = 0 Then

                        Phase.ID = 1

                    Else

                        Phase.ID = (From Entity In DbContext.GetQuery(Of Database.Entities.Phase)
                                    Select Entity.ID).Max + 1

                    End If

                    DbContext.Phases.Add(Phase)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Phase As AdvantageFramework.Database.Entities.Phase) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Phase)

                ErrorText = Phase.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Phase As AdvantageFramework.Database.Entities.Phase) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.JOB_TRAFFIC_DET WHERE TRAFFIC_PHASE_ID = {0}", Phase.ID)).FirstOrDefault > 0 OrElse
                        (From Entity In DataContext.TaskTemplateDetails
                         Where Entity.PhaseID = Phase.ID
                         Select Entity).Any Then

                    ErrorText = "The phase is in use and cannot be deleted."
                    IsValid = False

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(Phase)

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
