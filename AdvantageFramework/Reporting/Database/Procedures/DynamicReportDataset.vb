Namespace Reporting.Database.Procedures.DynamicReportDataset

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

        Public Function LoadByDynamicReportType(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal DynamicReportType As Integer) As Reporting.Database.Entities.DynamicReportDataset

            Try

                LoadByDynamicReportType = (From DynamicReportDataset In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReportDataset)
                                           Where DynamicReportDataset.DynamicReportType = DynamicReportType
                                           Select DynamicReportDataset).SingleOrDefault

            Catch ex As Exception
                LoadByDynamicReportType = Nothing
            End Try

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.DynamicReportDataset)

            Load = From DynamicReportDataset In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReportDataset)
                   Select DynamicReportDataset

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal Type As AdvantageFramework.Reporting.DynamicReports,
                               ByVal LastUpdated As Date, ByVal UpdatedBy As String,
                               ByRef DynamicReportDataset As AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DynamicReportDataset = New AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset

                DynamicReportDataset.DbContext = ReportingDbContext
                DynamicReportDataset.DynamicReportType = Type
                DynamicReportDataset.LastUpdated = LastUpdated
                DynamicReportDataset.UpdatedBy = UpdatedBy

                Inserted = Insert(ReportingDbContext, DynamicReportDataset)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportDataset As AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.DynamicReportDatasets.Add(DynamicReportDataset)

                ErrorText = DynamicReportDataset.ValidateEntity(IsValid)

                If IsValid Then

                    ReportingDbContext.SaveChanges()

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
        Public Function Update(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportDataset As AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.UpdateObject(DynamicReportDataset)

                ErrorText = DynamicReportDataset.ValidateEntity(IsValid)

                If IsValid Then

                    ReportingDbContext.SaveChanges()

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
        Public Function Delete(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DynamicReportDataset As AdvantageFramework.Reporting.Database.Entities.DynamicReportDataset) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""


            Try


                If IsValid Then

                    ReportingDbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.DYNAMIC_RPT_DATASET WHERE ID = {0}", DynamicReportDataset.ID))

                    ReportingDbContext.DeleteEntityObject(DynamicReportDataset)

                    ReportingDbContext.SaveChanges()

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
