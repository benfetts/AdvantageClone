Namespace Reporting.Database.Procedures.DynamicReportColumn

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

        Public Function LoadByDynamicReportIDAndFieldName(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal DynamicReportID As Integer, ByVal FieldName As String) As Reporting.Database.Entities.DynamicReportColumn

            Try

                LoadByDynamicReportIDAndFieldName = (From DynamicReportColumn In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReportColumn)
                                                     Where DynamicReportColumn.DynamicReportID = DynamicReportID AndAlso
                                                           DynamicReportColumn.FieldName = FieldName
                                                     Select DynamicReportColumn).SingleOrDefault

            Catch ex As Exception
                LoadByDynamicReportIDAndFieldName = Nothing
            End Try

        End Function
        Public Function LoadByDynamicReportID(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal DynamicReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.DynamicReportColumn)

            LoadByDynamicReportID = From DynamicReportColumn In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReportColumn)
                                    Where DynamicReportColumn.DynamicReportID = DynamicReportID
                                    Select DynamicReportColumn

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.DynamicReportColumn)

            Load = From DynamicReportColumn In ReportingDbContext.GetQuery(Of Database.Entities.DynamicReportColumn)
                   Select DynamicReportColumn

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportID As Integer,
                               ByVal FieldName As String, ByVal HeaderText As String, ByVal IsVisible As Boolean, ByVal SortIndex As Integer,
                               ByVal SortOrder As Integer, ByVal GroupIndex As Integer, ByVal Width As Integer,
                               ByVal VisibleIndex As Integer,
                               ByVal TemplateDetailID As Integer,
                               ByRef DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DynamicReportColumn = New AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn

                DynamicReportColumn.DbContext = ReportingDbContext
                DynamicReportColumn.DynamicReportID = DynamicReportID
                DynamicReportColumn.FieldName = FieldName
                DynamicReportColumn.HeaderText = HeaderText
                DynamicReportColumn.IsVisible = IsVisible
                DynamicReportColumn.SortIndex = SortIndex
                DynamicReportColumn.SortOrder = SortOrder
                DynamicReportColumn.GroupIndex = GroupIndex
                DynamicReportColumn.Width = Width
                DynamicReportColumn.TemplateDetailID = TemplateDetailID

                If DynamicReportColumn.IsVisible AndAlso DynamicReportColumn.Width = 0 Then

                    DynamicReportColumn.Width = 100

                End If

                If DynamicReportColumn.IsVisible AndAlso DynamicReportColumn.GroupIndex = -1 Then

                    DynamicReportColumn.VisibleIndex = VisibleIndex

                Else

                    DynamicReportColumn.VisibleIndex = -1

                End If

                Inserted = Insert(ReportingDbContext, DynamicReportColumn)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.DynamicReportColumns.Add(DynamicReportColumn)

                ErrorText = DynamicReportColumn.ValidateEntity(IsValid)

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
        Public Function Update(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.UpdateObject(DynamicReportColumn)

                ErrorText = DynamicReportColumn.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    ReportingDbContext.DeleteEntityObject(DynamicReportColumn)

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
