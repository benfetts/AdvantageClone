Namespace Reporting.Database.Procedures.DynamicReportSummaryItem

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

        Public Function LoadByDynamicReportID(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal DynamicReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.DynamicReportSummaryItem)

            LoadByDynamicReportID = From DynamicReportSummaryItem In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReportSummaryItem)
                                    Where DynamicReportSummaryItem.DynamicReportID = DynamicReportID
                                    Select DynamicReportSummaryItem

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.DynamicReportSummaryItem)

            Load = From DynamicReportSummaryItem In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReportSummaryItem)
                   Select DynamicReportSummaryItem

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext,
                               ByVal DynamicReportID As Integer, ByVal SummaryItemType As Integer,
                               ByVal FieldName As String, ByVal OnFooter As Boolean, ByVal DisplayFormat As String, ByVal ColumnName As String,
                               ByRef DynamicReportSummaryItem As AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DynamicReportSummaryItem = New AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem

                DynamicReportSummaryItem.DbContext = ReportingDbContext
                DynamicReportSummaryItem.DynamicReportID = DynamicReportID
                DynamicReportSummaryItem.SummaryItemType = SummaryItemType
                DynamicReportSummaryItem.FieldName = FieldName
                DynamicReportSummaryItem.OnFooter = OnFooter
                DynamicReportSummaryItem.DisplayFormat = DisplayFormat
                DynamicReportSummaryItem.ColumnName = ColumnName

                Inserted = Insert(ReportingDbContext, DynamicReportSummaryItem)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportSummaryItem As AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.DynamicReportSummaryItems.Add(DynamicReportSummaryItem)

                ErrorText = DynamicReportSummaryItem.ValidateEntity(IsValid)

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
        Public Function Update(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportSummaryItem As AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.UpdateObject(DynamicReportSummaryItem)

                ErrorText = DynamicReportSummaryItem.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportSummaryItem As AdvantageFramework.Reporting.Database.Entities.DynamicReportSummaryItem) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    ReportingDbContext.DeleteEntityObject(DynamicReportSummaryItem)

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
