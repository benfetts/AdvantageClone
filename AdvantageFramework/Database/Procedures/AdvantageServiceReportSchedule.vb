Namespace Database.Procedures.AdvantageServiceReportSchedule

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

        Public Function LoadByReportScheduleType(DbContext As AdvantageFramework.Database.DbContext, ReportScheduleType As AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleType) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AdvantageServiceReportSchedule)

            LoadByReportScheduleType = From AdvantageServiceReportSchedule In DbContext.GetQuery(Of Database.Entities.AdvantageServiceReportSchedule)
                                       Where AdvantageServiceReportSchedule.ReportScheduleType = ReportScheduleType
                                       Select AdvantageServiceReportSchedule

        End Function
        Public Function LoadByReportScheduleTypeAndReportID(DbContext As AdvantageFramework.Database.DbContext, ReportScheduleType As AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleType, ReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AdvantageServiceReportSchedule)

            LoadByReportScheduleTypeAndReportID = From AdvantageServiceReportSchedule In DbContext.GetQuery(Of Database.Entities.AdvantageServiceReportSchedule)
                                                  Where AdvantageServiceReportSchedule.ReportScheduleType = ReportScheduleType AndAlso
                                                        AdvantageServiceReportSchedule.ReportID = ReportID
                                                  Select AdvantageServiceReportSchedule

        End Function
        Public Function LoadByID(DbContext As AdvantageFramework.Database.DbContext, ID As Integer) As Database.Entities.AdvantageServiceReportSchedule

            LoadByID = (From AdvantageServiceReportSchedule In DbContext.GetQuery(Of Database.Entities.AdvantageServiceReportSchedule)
                        Where AdvantageServiceReportSchedule.ID = ID
                        Select AdvantageServiceReportSchedule).SingleOrDefault

        End Function
        Public Function Load(DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AdvantageServiceReportSchedule)

            Load = From AdvantageServiceReportSchedule In DbContext.GetQuery(Of Database.Entities.AdvantageServiceReportSchedule)
                   Select AdvantageServiceReportSchedule

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, AdvantageServiceReportSchedule As AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AdvantageServiceReportSchedules.Add(AdvantageServiceReportSchedule)

                ErrorText = AdvantageServiceReportSchedule.ValidateEntity(IsValid)

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, AdvantageServiceReportSchedule As AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AdvantageServiceReportSchedule)

                ErrorText = AdvantageServiceReportSchedule.ValidateEntity(IsValid)

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
        Public Function Delete(DbContext As AdvantageFramework.Database.DbContext, AdvantageServiceReportSchedule As AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AdvantageServiceReportSchedule)

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
        Public Function DeleteByID(DbContext As AdvantageFramework.Database.DbContext, ID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand("DELETE dbo.ADV_SERVICE_REPORT_SCHEDULE WHERE ADV_SERVICE_REPORT_SCHEDULE_ID = {0}", ID)

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
