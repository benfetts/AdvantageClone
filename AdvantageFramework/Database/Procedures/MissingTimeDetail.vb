Namespace Database.Procedures.MissingTimeDetail

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

        Public Function LoadDistinctSupervisorEmployeeCodesByLessThanOrEqualToDate(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal [Date] As Date) As IEnumerable(Of String)

            LoadDistinctSupervisorEmployeeCodesByLessThanOrEqualToDate = From MissingTimeDetail In AdvantageFramework.Database.Procedures.MissingTimeDetail.Load(DataContext)
                                                                         Where MissingTimeDetail.Date <= [Date].ToShortDateString _
                                                                         Select MissingTimeDetail.SupervisorEmployeeCode _
                                                                         Distinct

        End Function
        Public Function LoadDistinctEmployeeCodesBySupervisorEmployeeCodesAndLessThanOrEqualToDate(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SupervisorEmployeeCode As String, ByVal [Date] As Date) As IEnumerable(Of String)

            LoadDistinctEmployeeCodesBySupervisorEmployeeCodesAndLessThanOrEqualToDate = From MissingTimeDetail In AdvantageFramework.Database.Procedures.MissingTimeDetail.Load(DataContext)
                                                                                         Where MissingTimeDetail.SupervisorEmployeeCode = SupervisorEmployeeCode AndAlso _
                                                                                                MissingTimeDetail.Date <= [Date].ToShortDateString _
                                                                                         Select MissingTimeDetail.EmployeeCode _
                                                                                         Distinct

        End Function
        Public Function LoadDistinctEmployeeCodesByLessThanOrEqualToDate(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal [Date] As Date) As IEnumerable(Of String)

            LoadDistinctEmployeeCodesByLessThanOrEqualToDate = From MissingTimeDetail In AdvantageFramework.Database.Procedures.MissingTimeDetail.Load(DataContext)
                                                               Where MissingTimeDetail.Date <= [Date].ToShortDateString _
                                                               Select MissingTimeDetail.EmployeeCode _
                                                               Distinct

        End Function
        Public Function LoadByEmployeeCodeAndLessThanOrEqualToDate(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeCode As String, ByVal [Date] As Date) As IQueryable(Of AdvantageFramework.Database.Entities.MissingTimeDetail)

            LoadByEmployeeCodeAndLessThanOrEqualToDate = From MissingTimeDetail In AdvantageFramework.Database.Procedures.MissingTimeDetail.Load(DataContext)
                                                         Where MissingTimeDetail.Date <= [Date].ToShortDateString AndAlso
                                                               MissingTimeDetail.EmployeeCode = EmployeeCode
                                                         Select MissingTimeDetail

        End Function
        Public Function LoadByEmployeeCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.MissingTimeDetail)

            LoadByEmployeeCode = From MissingTimeDetail In AdvantageFramework.Database.Procedures.MissingTimeDetail.Load(DataContext)
                                 Where MissingTimeDetail.EmployeeCode = EmployeeCode
                                 Select MissingTimeDetail

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.MissingTimeDetail)

            Load = From MissingTimeDetail In DataContext.MissingTimeDetails
                   Select MissingTimeDetail

        End Function
        Public Function LoadMissingTimeDetailsTable(ByVal DbContext As Database.DbContext,
                                                    ByVal StartDate As String,
                                                    ByVal EndDate As String,
                                                    ByVal ExcludeHolidaysAndWeekends As Int16,
                                                    ByVal MissingTimeOnly As Int16) As Integer

            'objects
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterExcludeHolidaysAndWeekends As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMissingTimeOnly As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.VarChar)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.VarChar)
            SqlParameterExcludeHolidaysAndWeekends = New System.Data.SqlClient.SqlParameter("@exclude_hol_wkends", SqlDbType.SmallInt)
            SqlParameterMissingTimeOnly = New System.Data.SqlClient.SqlParameter("@missing_time_only", SqlDbType.SmallInt)

            SqlParameterStartDate.Value = StartDate
            SqlParameterEndDate.Value = EndDate
            SqlParameterExcludeHolidaysAndWeekends.Value = ExcludeHolidaysAndWeekends
            SqlParameterMissingTimeOnly.Value = MissingTimeOnly

            LoadMissingTimeDetailsTable = DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_populate_missing_time_table @start_date, @end_date, @exclude_hol_wkends, @missing_time_only",
                SqlParameterStartDate, SqlParameterEndDate, SqlParameterExcludeHolidaysAndWeekends, SqlParameterMissingTimeOnly)

        End Function

#End Region

    End Module

End Namespace
