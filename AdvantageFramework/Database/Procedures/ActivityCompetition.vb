Namespace Database.Procedures.ActivityCompetition

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ActivityCompetition)

            Load = From ActivityCompetition In DbContext.GetQuery(Of Database.Entities.ActivityCompetition)
                   Select ActivityCompetition

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As Database.Entities.ActivityCompetition

            Try

                LoadByID = (From ActivityCompetition In DbContext.GetQuery(Of Database.Entities.ActivityCompetition)
                            Where ActivityCompetition.ID = ID
                            Select ActivityCompetition).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByActivityID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ActivityID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ActivityCompetition)

            LoadByActivityID = From ActivityCompetition In DbContext.GetQuery(Of Database.Entities.ActivityCompetition)
                               Where ActivityCompetition.ActivityID = ActivityID
                               Select ActivityCompetition

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ActivityCompetitions.Add(ActivityCompetition)

                ErrorText = ActivityCompetition.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.ActivityCompetitions.Any(Function(Entity) Entity.ActivityID = ActivityCompetition.ActivityID AndAlso _
                                                                               Entity.CompetitionID = ActivityCompetition.CompetitionID) = False Then

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter a unique competitor.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ActivityCompetition)

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
