Namespace Security.Database.Procedures.Report

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

        Public Function LoadByReportType(ByVal DbContext As Database.DbContext, ByVal ReportType As Int16) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Report)

            Try
                LoadByReportType = From Report In DbContext.GetQuery(Of Database.Entities.Report)
                                   Where Report.IsActive = "A" AndAlso
                                         Report.Type = ReportType
                                   Select Report

            Catch ex As Exception
                LoadByReportType = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Report)

            LoadAllActive = From Report In DbContext.GetQuery(Of Database.Entities.Report)
                            Where Report.IsActive = "A"
                            Select Report

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Report)

            Load = From Report In DbContext.GetQuery(Of Database.Entities.Report)
                   Select Report

        End Function
        Public Function LoadApplicationModuleByType(ByVal Type As Short) As String

            'objects
            Dim ApplicationModule As String = Nothing
            Dim AccountFinanceTypes As Short() = Nothing
            Dim ClientBudgetsTypes As Short() = Nothing
            Dim EstimateFormsTypes As Short() = Nothing
            Dim JobAnalysisTypes As Short() = Nothing
            Dim JobOrderFormsTypes As Short() = Nothing
            Dim MaintenanceEmployeeTypes As Short() = Nothing
            Dim MaintenanceReportsTypes As Short() = Nothing
            Dim MaintenanceTaskTemplateTypes As Short() = Nothing
            Dim MaintenanceVendorTypes As Short() = Nothing
            Dim ManagemementReportsTypes As Short() = Nothing
            Dim MediaTypes As Short() = Nothing
            Dim MonthEndReports300SeriesTypes As Short() = Nothing
            Dim MonthEndReports400SeriesTypes As Short() = Nothing
            Dim MonthEndReports500SeriesTypes As Short() = Nothing
            Dim MonthEndReports600SeriesTypes As Short() = Nothing
            Dim MonthEndReports700SeriesTypes As Short() = Nothing
            Dim ProjectManagementTypes As Short() = Nothing

            AccountFinanceTypes = {21, 33, 53, 54, 55, 59, 60, 61, 115}
            ClientBudgetsTypes = {105}
            EstimateFormsTypes = {101}
            JobAnalysisTypes = {100}
            JobOrderFormsTypes = {102}
            MaintenanceEmployeeTypes = {109}
            MaintenanceReportsTypes = {1}
            MaintenanceTaskTemplateTypes = {114}
            MaintenanceVendorTypes = {103}
            ManagemementReportsTypes = {110}
            MediaTypes = {62}
            MonthEndReports300SeriesTypes = {106}
            MonthEndReports400SeriesTypes = {108}
            MonthEndReports500SeriesTypes = {112}
            MonthEndReports600SeriesTypes = {111}
            MonthEndReports700SeriesTypes = {113}
            ProjectManagementTypes = {3, 5, 7, 8}

            Try

                If AccountFinanceTypes.Contains(Type) Then

                    ApplicationModule = "Accounting / Finance"

                ElseIf ClientBudgetsTypes.Contains(Type) Then

                    ApplicationModule = "Client Budgets"

                ElseIf EstimateFormsTypes.Contains(Type) Then

                    ApplicationModule = "Estimate Forms"

                ElseIf JobAnalysisTypes.Contains(Type) Then

                    ApplicationModule = "Job Analysis"

                ElseIf JobOrderFormsTypes.Contains(Type) Then

                    ApplicationModule = "Job Order Forms"

                ElseIf MaintenanceEmployeeTypes.Contains(Type) Then

                    ApplicationModule = "Maintenance : Employee"

                ElseIf MaintenanceReportsTypes.Contains(Type) Then

                    ApplicationModule = "Maintenance : Reports"

                ElseIf MaintenanceTaskTemplateTypes.Contains(Type) Then

                    ApplicationModule = "Maintenance : Task Templates"

                ElseIf MaintenanceVendorTypes.Contains(Type) Then

                    ApplicationModule = "Maintenance : Vendor"

                ElseIf ManagemementReportsTypes.Contains(Type) Then

                    ApplicationModule = "Managemement Reports"

                ElseIf MediaTypes.Contains(Type) Then

                    ApplicationModule = "Media"

                ElseIf MonthEndReports300SeriesTypes.Contains(Type) Then

                    ApplicationModule = "Month End Reports - 300 Series"

                ElseIf MonthEndReports400SeriesTypes.Contains(Type) Then

                    ApplicationModule = "Month End Reports - 400 Series"

                ElseIf MonthEndReports500SeriesTypes.Contains(Type) Then

                    ApplicationModule = "Month End Reports - 500 Series"

                ElseIf MonthEndReports600SeriesTypes.Contains(Type) Then

                    ApplicationModule = "Month End Reports - 600 Series"

                ElseIf MonthEndReports700SeriesTypes.Contains(Type) Then

                    ApplicationModule = "Month End Reports - 700 Series"

                ElseIf ProjectManagementTypes.Contains(Type) Then

                    ApplicationModule = "Project Management"

                End If

            Catch ex As Exception
                ApplicationModule = ""
            End Try

            LoadApplicationModuleByType = ApplicationModule

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Report As AdvantageFramework.Security.Database.Entities.Report) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Report)

                ErrorText = Report.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
