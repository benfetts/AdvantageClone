Imports System.Data
Imports System.Data.SqlClient

Namespace Dashboard

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const Unassigned As String = "*Unassigned"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region "Employee Utilization"
        Public Function LoadEmployeeUtilization(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationItem)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationItem) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim StartDate As Date = Nothing
                    Dim EndDate As Date = Nothing

                    Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterGroupBy As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterLimitWIP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOfficeList As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterDepartmentList As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.DateTime)
                    SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.DateTime)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar)
                    SqlParameterGroupBy = New System.Data.SqlClient.SqlParameter("@Groupby", SqlDbType.VarChar)
                    SqlParameterLimitWIP = New System.Data.SqlClient.SqlParameter("@LimitWIP", SqlDbType.Bit)
                    SqlParameterOfficeList = New System.Data.SqlClient.SqlParameter("@OFFICE_LIST", SqlDbType.VarChar)
                    SqlParameterDepartmentList = New System.Data.SqlClient.SqlParameter("@DEPT_LIST", SqlDbType.VarChar)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth = 13 Then

                            StartDate = CDate("1/1/" & Filter.FromYear)
                            EndDate = CDate(Filter.FromMonth & "/" & Date.DaysInMonth(Filter.FromYear, Filter.FromMonth) & "/" & Filter.FromYear)

                        Else

                            StartDate = CDate(Filter.FromMonth & "/1/" & Filter.FromYear)
                            EndDate = CDate(Filter.FromMonth & "/" & Date.DaysInMonth(Filter.FromYear, Filter.FromMonth) & "/" & Filter.FromYear)

                        End If

                    End If

                    SqlParameterStartDate.Value = StartDate
                    SqlParameterEndDate.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterGroupBy.Value = Filter.Page
                    SqlParameterLimitWIP.Value = 0

                    'If ParameterDictionary.Keys.Contains(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedDepartments.ToString) AndAlso ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedDepartments.ToString) IsNot Nothing Then

                    '    SqlParameterDepartmentList.Value = String.Join(",", DirectCast(ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedDepartments.ToString), IEnumerable(Of String)).ToArray)

                    'Else

                    SqlParameterDepartmentList.Value = System.DBNull.Value

                    'End If

                    'If ParameterDictionary.Keys.Contains(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedOffices.ToString) AndAlso ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedOffices.ToString) IsNot Nothing Then

                    '    SqlParameterOfficeList.Value = String.Join(",", DirectCast(ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedOffices.ToString), IEnumerable(Of String)).ToArray)

                    'Else

                    SqlParameterOfficeList.Value = System.DBNull.Value

                    'End If

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationItem)("exec dbo.advsp_employee_time_util_dashboard @StartDate, @EndDate, @UserID, @Groupby, @LimitWIP, @OFFICE_LIST, @DEPT_LIST", SqlParameterStartDate, SqlParameterEndDate, SqlParameterUserID, SqlParameterGroupBy, SqlParameterLimitWIP, SqlParameterOfficeList, SqlParameterDepartmentList).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.EmployeeUtilizationItem)

            Return List

        End Function

        Public Function GetEmployeeManagerUserColumnSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                      ByVal GridName As String, ByVal UserCode As String) _
                        As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationGridColumnSetting)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationGridColumnSetting) = Nothing

            Try

                Dim GridNameSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                GridNameSqlParameter = New System.Data.SqlClient.SqlParameter("@GRID_NAME", SqlDbType.VarChar, 100)
                UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

                GridNameSqlParameter.Value = GridName
                UserCodeSqlParameter.Value = UserCode

                List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationGridColumnSetting)(
                                                    "EXEC [dbo].[usp_wv_EmployeeUtilizationGetColumnSettings] @GRID_NAME, @USER_CODE;",
                                                    GridNameSqlParameter, UserCodeSqlParameter).ToList

            Catch ex As Exception

            End Try

            If List Is Nothing Then List = New List(Of Classes.EmployeeUtilizationGridColumnSetting)

            Return List

        End Function

        Public Function GetUserViewSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal UserCode As String, ByVal ApplicationName As String) _
                                                    As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationUserViewSetting)

            Dim UserSettings As Generic.List(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationUserViewSetting) = Nothing

            Try

                Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim ApplicationNameSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                ApplicationNameSqlParameter = New System.Data.SqlClient.SqlParameter("@APPLICATION_NAME", SqlDbType.VarChar, 200)

                UserCodeSqlParameter.Value = UserCode
                ApplicationNameSqlParameter.Value = ApplicationName

                UserSettings = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.EmployeeUtilizationUserViewSetting)(
                                                    "EXEC [dbo].[usp_wv_EmployeeUtilizationGetUserViewSettings] @USER_CODE, @APPLICATION_NAME;",
                                                    UserCodeSqlParameter, ApplicationNameSqlParameter).ToList

            Catch ex As Exception

            End Try

            Return UserSettings

        End Function

#End Region

#Region "Financial DB"

        Public Function LoadFinancialDataDS(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As DataSet

            Dim ds As DataSet

            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing

            ds = New DataSet

            Try

                If Filter IsNot Nothing Then

                    SqlConnection = DbContext.Database.Connection

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If

                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = 0

                    SqlCommand = New SqlClient.SqlCommand("usp_wv_get_Financial_data_dt", SqlConnection)

                    SqlCommand.Parameters.Add(SqlParameterStartPP)
                    SqlCommand.Parameters.Add(SqlParameterEndPP)
                    SqlCommand.Parameters.Add(SqlParameterOffice)
                    SqlCommand.Parameters.Add(SqlParameterUserID)
                    SqlCommand.Parameters.Add(SqlParameterOption)

                    SqlCommand.CommandType = CommandType.StoredProcedure

                    SqlDataAdapter = New SqlClient.SqlDataAdapter(SqlCommand)

                    Using SqlCommand

                        SqlDataAdapter.Fill(ds)

                    End Using

                Else

                    ErrorMessage = "No input object."

                End If

                'If ds IsNot Nothing And ds.Tables.Count > 0 Then

                '    List = New List(Of Classes.FinancialDashboardClientChartData)

                '    For i = 0 To dt.Rows.Count - 1

                '        FinancialDashboardClientChartData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartData

                '        FinancialDashboardClientChartData.Client = dt.Rows(i)("Client")
                '        FinancialDashboardClientChartData.Year1 = dt.Rows(i)("Year1")
                '        FinancialDashboardClientChartData.Year2 = dt.Rows(i)("Year2")

                '        List.Add(FinancialDashboardClientChartData)

                '    Next


                'End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                ds = Nothing
            End Try

            'If List Is Nothing Then List = New List(Of Classes.FinancialDashboardClientChartData)



            Return ds

        End Function

        Public Function LoadFinancialData(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If

                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthData)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardMonthData)

            Return List

        End Function

        Public Function LoadFinancialChartData(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthChartData)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthChartData) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If


                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthChartData)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardMonthChartData)

            Return List

        End Function

        Public Function LoadFinancialChartGridData(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthChartGridData)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthChartGridData) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If

                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthChartGridData)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardMonthChartGridData)

            Return List

        End Function

        Public Function LoadFinancialChartDataYTD(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardYTDChartData)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardYTDChartData) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If


                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardYTDChartData)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardYTDChartData)

            Return List

        End Function

        Public Function LoadFinancialChartGridDataYTD(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardYTDChartGridData)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardYTDChartGridData) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If

                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardYTDChartGridData)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardYTDChartGridData)

            Return List

        End Function

        Public Function LoadFinancialChartDataClient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartData)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartData) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If

                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartData)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardClientChartData)

            Return List

        End Function

        Public Function LoadFinancialChartDataClientDT(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartData)

            Dim dt As DataTable
            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartData) = Nothing
            Dim FinancialDashboardClientChartData As AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartData = Nothing
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            dt = New DataTable

            Try

                If Filter IsNot Nothing Then

                    SqlConnection = DbContext.Database.Connection

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If

                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    SqlCommand = New SqlClient.SqlCommand("usp_wv_get_Financial_data", SqlConnection)

                    SqlCommand.Parameters.Add(SqlParameterStartPP)
                    SqlCommand.Parameters.Add(SqlParameterEndPP)
                    SqlCommand.Parameters.Add(SqlParameterOffice)
                    SqlCommand.Parameters.Add(SqlParameterUserID)
                    SqlCommand.Parameters.Add(SqlParameterOption)

                    SqlCommand.CommandType = CommandType.StoredProcedure

                    SqlDataAdapter = New SqlClient.SqlDataAdapter(SqlCommand)

                    Using SqlCommand

                        SqlDataAdapter.Fill(dt)

                    End Using

                Else

                    ErrorMessage = "No input object."

                End If

                If dt IsNot Nothing And dt.Rows.Count > 0 Then

                    List = New List(Of Classes.FinancialDashboardClientChartData)

                    For i = 0 To dt.Rows.Count - 1

                        FinancialDashboardClientChartData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartData

                        FinancialDashboardClientChartData.Client = dt.Rows(i)("Client")
                        FinancialDashboardClientChartData.Year1 = dt.Rows(i)("Year1")
                        FinancialDashboardClientChartData.Year2 = dt.Rows(i)("Year2")

                        List.Add(FinancialDashboardClientChartData)

                    Next


                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            'If List Is Nothing Then List = New List(Of Classes.FinancialDashboardClientChartData)



            Return List

        End Function

        Public Function LoadFinancialChartGridDataClient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartGridData)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartGridData) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If

                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartGridData)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardClientChartGridData)

            Return List

        End Function

        Public Function LoadFinancialChartGridDataClientDT(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartGridData)
            Dim dt As DataTable
            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartGridData) = Nothing
            Dim FinancialDashboardClientChartGridData As AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartGridData = Nothing
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            dt = New DataTable

            Try

                If Filter IsNot Nothing Then

                    SqlConnection = DbContext.Database.Connection

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing
                    Dim j As Integer = 1

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If

                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    SqlCommand = New SqlClient.SqlCommand("usp_wv_get_Financial_data", SqlConnection)

                    SqlCommand.Parameters.Add(SqlParameterStartPP)
                    SqlCommand.Parameters.Add(SqlParameterEndPP)
                    SqlCommand.Parameters.Add(SqlParameterOffice)
                    SqlCommand.Parameters.Add(SqlParameterUserID)
                    SqlCommand.Parameters.Add(SqlParameterOption)

                    SqlCommand.CommandType = CommandType.StoredProcedure

                    SqlDataAdapter = New SqlClient.SqlDataAdapter(SqlCommand)

                    Using SqlCommand

                        SqlDataAdapter.Fill(dt)

                    End Using

                    If dt IsNot Nothing And dt.Rows.Count > 0 Then

                        List = New List(Of Classes.FinancialDashboardClientChartGridData)

                        For i = 0 To dt.Rows.Count - 1

                            FinancialDashboardClientChartGridData = New AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartGridData

                            FinancialDashboardClientChartGridData.Year = dt.Rows(i)("Year")

                            If dt.Columns.Count = 1 Then
                                FinancialDashboardClientChartGridData.Client1 = 0
                                FinancialDashboardClientChartGridData.Client2 = 0
                                FinancialDashboardClientChartGridData.Client3 = 0
                                FinancialDashboardClientChartGridData.Client4 = 0
                                FinancialDashboardClientChartGridData.Client5 = 0
                                FinancialDashboardClientChartGridData.Client6 = 0
                                FinancialDashboardClientChartGridData.Client7 = 0
                                FinancialDashboardClientChartGridData.Client8 = 0
                                FinancialDashboardClientChartGridData.Client9 = 0
                                FinancialDashboardClientChartGridData.Client10 = 0
                            ElseIf dt.Columns.Count = 2 Then
                                FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)(1)
                                FinancialDashboardClientChartGridData.Client2 = 0
                                FinancialDashboardClientChartGridData.Client3 = 0
                                FinancialDashboardClientChartGridData.Client4 = 0
                                FinancialDashboardClientChartGridData.Client5 = 0
                                FinancialDashboardClientChartGridData.Client6 = 0
                                FinancialDashboardClientChartGridData.Client7 = 0
                                FinancialDashboardClientChartGridData.Client8 = 0
                                FinancialDashboardClientChartGridData.Client9 = 0
                                FinancialDashboardClientChartGridData.Client10 = 0
                            ElseIf dt.Columns.Count = 3 Then
                                FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)(1)
                                FinancialDashboardClientChartGridData.Client2 = dt.Rows(i)(2)
                                FinancialDashboardClientChartGridData.Client3 = 0
                                FinancialDashboardClientChartGridData.Client4 = 0
                                FinancialDashboardClientChartGridData.Client5 = 0
                                FinancialDashboardClientChartGridData.Client6 = 0
                                FinancialDashboardClientChartGridData.Client7 = 0
                                FinancialDashboardClientChartGridData.Client8 = 0
                                FinancialDashboardClientChartGridData.Client9 = 0
                                FinancialDashboardClientChartGridData.Client10 = 0
                            ElseIf dt.Columns.Count = 4 Then
                                FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)(1)
                                FinancialDashboardClientChartGridData.Client2 = dt.Rows(i)(2)
                                FinancialDashboardClientChartGridData.Client3 = dt.Rows(i)(3)
                                FinancialDashboardClientChartGridData.Client4 = 0
                                FinancialDashboardClientChartGridData.Client5 = 0
                                FinancialDashboardClientChartGridData.Client6 = 0
                                FinancialDashboardClientChartGridData.Client7 = 0
                                FinancialDashboardClientChartGridData.Client8 = 0
                                FinancialDashboardClientChartGridData.Client9 = 0
                                FinancialDashboardClientChartGridData.Client10 = 0
                            ElseIf dt.Columns.Count = 5 Then
                                FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)(1)
                                FinancialDashboardClientChartGridData.Client2 = dt.Rows(i)(2)
                                FinancialDashboardClientChartGridData.Client3 = dt.Rows(i)(3)
                                FinancialDashboardClientChartGridData.Client4 = dt.Rows(i)(4)
                                FinancialDashboardClientChartGridData.Client5 = 0
                                FinancialDashboardClientChartGridData.Client6 = 0
                                FinancialDashboardClientChartGridData.Client7 = 0
                                FinancialDashboardClientChartGridData.Client8 = 0
                                FinancialDashboardClientChartGridData.Client9 = 0
                                FinancialDashboardClientChartGridData.Client10 = 0
                            ElseIf dt.Columns.Count = 6 Then
                                FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)(1)
                                FinancialDashboardClientChartGridData.Client2 = dt.Rows(i)(2)
                                FinancialDashboardClientChartGridData.Client3 = dt.Rows(i)(3)
                                FinancialDashboardClientChartGridData.Client4 = dt.Rows(i)(4)
                                FinancialDashboardClientChartGridData.Client5 = dt.Rows(i)(5)
                                FinancialDashboardClientChartGridData.Client6 = 0
                                FinancialDashboardClientChartGridData.Client7 = 0
                                FinancialDashboardClientChartGridData.Client8 = 0
                                FinancialDashboardClientChartGridData.Client9 = 0
                                FinancialDashboardClientChartGridData.Client10 = 0
                            ElseIf dt.Columns.Count = 7 Then
                                FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)(1)
                                FinancialDashboardClientChartGridData.Client2 = dt.Rows(i)(2)
                                FinancialDashboardClientChartGridData.Client3 = dt.Rows(i)(3)
                                FinancialDashboardClientChartGridData.Client4 = dt.Rows(i)(4)
                                FinancialDashboardClientChartGridData.Client5 = dt.Rows(i)(5)
                                FinancialDashboardClientChartGridData.Client6 = dt.Rows(i)(6)
                                FinancialDashboardClientChartGridData.Client7 = 0
                                FinancialDashboardClientChartGridData.Client8 = 0
                                FinancialDashboardClientChartGridData.Client9 = 0
                                FinancialDashboardClientChartGridData.Client10 = 0
                            ElseIf dt.Columns.Count = 8 Then
                                FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)(1)
                                FinancialDashboardClientChartGridData.Client2 = dt.Rows(i)(2)
                                FinancialDashboardClientChartGridData.Client3 = dt.Rows(i)(3)
                                FinancialDashboardClientChartGridData.Client4 = dt.Rows(i)(4)
                                FinancialDashboardClientChartGridData.Client5 = dt.Rows(i)(5)
                                FinancialDashboardClientChartGridData.Client6 = dt.Rows(i)(6)
                                FinancialDashboardClientChartGridData.Client7 = dt.Rows(i)(7)
                                FinancialDashboardClientChartGridData.Client8 = 0
                                FinancialDashboardClientChartGridData.Client9 = 0
                                FinancialDashboardClientChartGridData.Client10 = 0
                            ElseIf dt.Columns.Count = 9 Then
                                FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)(1)
                                FinancialDashboardClientChartGridData.Client2 = dt.Rows(i)(2)
                                FinancialDashboardClientChartGridData.Client3 = dt.Rows(i)(3)
                                FinancialDashboardClientChartGridData.Client4 = dt.Rows(i)(4)
                                FinancialDashboardClientChartGridData.Client5 = dt.Rows(i)(5)
                                FinancialDashboardClientChartGridData.Client6 = dt.Rows(i)(6)
                                FinancialDashboardClientChartGridData.Client7 = dt.Rows(i)(7)
                                FinancialDashboardClientChartGridData.Client8 = dt.Rows(i)(8)
                                FinancialDashboardClientChartGridData.Client9 = 0
                                FinancialDashboardClientChartGridData.Client10 = 0
                            ElseIf dt.Columns.Count = 10 Then
                                FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)(1)
                                FinancialDashboardClientChartGridData.Client2 = dt.Rows(i)(2)
                                FinancialDashboardClientChartGridData.Client3 = dt.Rows(i)(3)
                                FinancialDashboardClientChartGridData.Client4 = dt.Rows(i)(4)
                                FinancialDashboardClientChartGridData.Client5 = dt.Rows(i)(5)
                                FinancialDashboardClientChartGridData.Client6 = dt.Rows(i)(6)
                                FinancialDashboardClientChartGridData.Client7 = dt.Rows(i)(7)
                                FinancialDashboardClientChartGridData.Client8 = dt.Rows(i)(8)
                                FinancialDashboardClientChartGridData.Client9 = dt.Rows(i)(9)
                                FinancialDashboardClientChartGridData.Client10 = 0
                            ElseIf dt.Columns.Count = 11 Then
                                FinancialDashboardClientChartGridData.Client1 = dt.Rows(i)(1)
                                FinancialDashboardClientChartGridData.Client2 = dt.Rows(i)(2)
                                FinancialDashboardClientChartGridData.Client3 = dt.Rows(i)(3)
                                FinancialDashboardClientChartGridData.Client4 = dt.Rows(i)(4)
                                FinancialDashboardClientChartGridData.Client5 = dt.Rows(i)(5)
                                FinancialDashboardClientChartGridData.Client6 = dt.Rows(i)(6)
                                FinancialDashboardClientChartGridData.Client7 = dt.Rows(i)(7)
                                FinancialDashboardClientChartGridData.Client8 = dt.Rows(i)(8)
                                FinancialDashboardClientChartGridData.Client9 = dt.Rows(i)(9)
                                FinancialDashboardClientChartGridData.Client10 = dt.Rows(i)(10)
                            End If

                            List.Add(FinancialDashboardClientChartGridData)

                        Next


                    End If

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            Return List

        End Function

        Public Function LoadFinancialBillableData(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthBillableGridData)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthBillableGridData) = Nothing

            Try

                'If Filter IsNot Nothing Then

                '    Dim StartDate As String = Nothing
                '    Dim EndDate As String = Nothing

                '    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                '    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                '    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                '    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                '    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                '    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                '    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                '    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                '    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                '    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                '    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                '        If Filter.ToMonth <= 9 Then
                '            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                '            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                '        Else
                '            StartDate = Filter.FromYear & "" & Filter.FromMonth
                '            EndDate = Filter.ToYear & "" & Filter.ToMonth
                '        End If


                '    End If

                '    SqlParameterStartPP.Value = StartDate
                '    SqlParameterEndPP.Value = EndDate
                '    SqlParameterUserID.Value = DbContext.UserCode
                '    SqlParameterOffice.Value = ""
                '    SqlParameterOption.Value = Filter.Page

                '    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthBillableGridData)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                'Else

                '    ErrorMessage = "No input object."

                'End If

                If Filter IsNot Nothing Then

                    Dim StartDate As Date = Nothing
                    Dim EndDate As Date = Nothing

                    Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterGroupBy As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterLimitWIP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOfficeList As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterDepartmentList As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.DateTime)
                    SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.DateTime)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar)
                    SqlParameterGroupBy = New System.Data.SqlClient.SqlParameter("@Groupby", SqlDbType.VarChar)
                    SqlParameterLimitWIP = New System.Data.SqlClient.SqlParameter("@LimitWIP", SqlDbType.Bit)
                    SqlParameterOfficeList = New System.Data.SqlClient.SqlParameter("@OFFICE_LIST", SqlDbType.VarChar)
                    SqlParameterDepartmentList = New System.Data.SqlClient.SqlParameter("@DEPT_LIST", SqlDbType.VarChar)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        StartDate = CDate("1/1/" & Filter.FromYear)
                        EndDate = CDate(Filter.FromMonth & "/" & Date.DaysInMonth(Filter.FromYear, Filter.FromMonth) & "/" & Filter.FromYear)

                    End If

                    SqlParameterStartDate.Value = StartDate
                    SqlParameterEndDate.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterGroupBy.Value = "month"
                    SqlParameterLimitWIP.Value = 0

                    'If ParameterDictionary.Keys.Contains(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedDepartments.ToString) AndAlso ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedDepartments.ToString) IsNot Nothing Then

                    '    SqlParameterDepartmentList.Value = String.Join(",", DirectCast(ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedDepartments.ToString), IEnumerable(Of String)).ToArray)

                    'Else

                    SqlParameterDepartmentList.Value = System.DBNull.Value

                    'End If

                    'If ParameterDictionary.Keys.Contains(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedOffices.ToString) AndAlso ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedOffices.ToString) IsNot Nothing Then

                    '    SqlParameterOfficeList.Value = String.Join(",", DirectCast(ParameterDictionary(AdvantageFramework.Reporting.EmployeeUtilizationInitialParameters.SelectedOffices.ToString), IEnumerable(Of String)).ToArray)

                    'Else

                    SqlParameterOfficeList.Value = System.DBNull.Value

                    'End If

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardMonthBillableGridData)("exec dbo.advsp_employee_time_util_dashboard @StartDate, @EndDate, @UserID, @Groupby, @LimitWIP, @OFFICE_LIST, @DEPT_LIST", SqlParameterStartDate, SqlParameterEndDate, SqlParameterUserID, SqlParameterGroupBy, SqlParameterLimitWIP, SqlParameterOfficeList, SqlParameterDepartmentList).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardMonthBillableGridData)

            Return List

        End Function

        Public Function LoadFinancialNewBusinessData(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardNewBusinessGridData)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardNewBusinessGridData) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If


                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardNewBusinessGridData)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardNewBusinessGridData)

            Return List

        End Function

        Public Function LoadFinancialGrowData(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardGrowGridData)

            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardGrowGridData) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If


                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = Filter.Page

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardGrowGridData)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardGrowGridData)

            Return List

        End Function

        Public Function LoadFinancialClients(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter,
                                             ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClients)
            'Dim dt As DataTable
            Dim List As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClients) = Nothing
            Dim FinancialDashboardClientChartGridData As AdvantageFramework.Dashboard.Classes.FinancialDashboardClientChartGridData = Nothing
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            Try

                If Filter IsNot Nothing Then

                    SqlConnection = DbContext.Database.Connection

                    Dim StartDate As String = Nothing
                    Dim EndDate As String = Nothing

                    Dim SqlParameterStartPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEndPP As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterOption As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterStartPP = New System.Data.SqlClient.SqlParameter("@startPP", SqlDbType.VarChar)
                    SqlParameterEndPP = New System.Data.SqlClient.SqlParameter("@endPP", SqlDbType.VarChar)
                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                    SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
                    SqlParameterOption = New System.Data.SqlClient.SqlParameter("@Option", SqlDbType.SmallInt)

                    If Filter.FromMonth <> 0 AndAlso Filter.FromYear <> 0 Then

                        If Filter.ToMonth <= 9 Then
                            StartDate = Filter.FromYear & "0" & Filter.FromMonth
                            EndDate = Filter.ToYear & "0" & Filter.ToMonth
                        Else
                            StartDate = Filter.FromYear & "" & Filter.FromMonth
                            EndDate = Filter.ToYear & "" & Filter.ToMonth
                        End If

                    End If

                    SqlParameterStartPP.Value = StartDate
                    SqlParameterEndPP.Value = EndDate
                    SqlParameterUserID.Value = DbContext.UserCode
                    SqlParameterOffice.Value = ""
                    SqlParameterOption.Value = 12

                    SqlCommand = New SqlClient.SqlCommand("usp_wv_get_Financial_data", SqlConnection)

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardClients)("exec dbo.usp_wv_get_Financial_data @startPP, @endPP, @Office, @USER_ID, @Option", SqlParameterStartPP, SqlParameterEndPP, SqlParameterOffice, SqlParameterUserID, SqlParameterOption).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.FinancialDashboardClients)

            Return List

        End Function

#End Region



#End Region

    End Module

End Namespace
