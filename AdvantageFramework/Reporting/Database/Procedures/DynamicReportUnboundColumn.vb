Namespace Reporting.Database.Procedures.DynamicReportUnboundColumn

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

        Public Function LoadByDynamicReportIDAndFieldName(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal DynamicReportID As Integer, ByVal FieldName As String) As Reporting.Database.Entities.DynamicReportUnboundColumn

            Try

                LoadByDynamicReportIDAndFieldName = (From DynamicReportUnboundColumn In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReportUnboundColumn)
                                                     Where DynamicReportUnboundColumn.DynamicReportID = DynamicReportID AndAlso
                                                           DynamicReportUnboundColumn.FieldName = FieldName
                                                     Select DynamicReportUnboundColumn).SingleOrDefault

            Catch ex As Exception
                LoadByDynamicReportIDAndFieldName = Nothing
            End Try

        End Function
        Public Function LoadByDynamicReportID(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal DynamicReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.DynamicReportUnboundColumn)

            LoadByDynamicReportID = From DynamicReportUnboundColumn In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReportUnboundColumn)
                                    Where DynamicReportUnboundColumn.DynamicReportID = DynamicReportID
                                    Select DynamicReportUnboundColumn

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.DynamicReportUnboundColumn)

            Load = From DynamicReportUnboundColumn In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReportUnboundColumn)
                   Select DynamicReportUnboundColumn

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportID As Integer,
                       ByVal FieldName As String, ByVal HeaderText As String, ByVal IsVisible As Boolean, ByVal SortIndex As Integer,
                       ByVal SortOrder As Integer, ByVal GroupIndex As Integer, ByVal Width As Integer,
                       ByVal VisibleIndex As Integer, ByVal UnboundType As Integer, ByVal Expression As String, ByVal Format As String,
                       ByRef DynamicReportUnboundColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DynamicReportUnboundColumn = New AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn

                DynamicReportUnboundColumn.DbContext = ReportingDbContext
                DynamicReportUnboundColumn.DynamicReportID = DynamicReportID
                DynamicReportUnboundColumn.FieldName = FieldName
                DynamicReportUnboundColumn.HeaderText = HeaderText
                DynamicReportUnboundColumn.IsVisible = IsVisible
                DynamicReportUnboundColumn.SortIndex = SortIndex
                DynamicReportUnboundColumn.SortOrder = SortOrder
                DynamicReportUnboundColumn.GroupIndex = GroupIndex
                DynamicReportUnboundColumn.Width = Width

                If DynamicReportUnboundColumn.IsVisible AndAlso DynamicReportUnboundColumn.Width = 0 Then

                    DynamicReportUnboundColumn.Width = 100

                End If

                If DynamicReportUnboundColumn.IsVisible AndAlso DynamicReportUnboundColumn.GroupIndex = -1 Then

                    DynamicReportUnboundColumn.VisibleIndex = VisibleIndex

                Else

                    DynamicReportUnboundColumn.VisibleIndex = -1

                End If

                DynamicReportUnboundColumn.UnboundType = UnboundType
                DynamicReportUnboundColumn.Expression = Expression
                DynamicReportUnboundColumn.Format = Format

                Inserted = Insert(ReportingDbContext, DynamicReportUnboundColumn)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportUnboundColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.DynamicReportUnboundColumns.Add(DynamicReportUnboundColumn)

                ErrorText = DynamicReportUnboundColumn.ValidateEntity(IsValid)

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
        Public Function Update(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportUnboundColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.UpdateObject(DynamicReportUnboundColumn)

                ErrorText = DynamicReportUnboundColumn.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportUnboundColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportUnboundColumn) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    ReportingDbContext.DeleteEntityObject(DynamicReportUnboundColumn)

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
