Namespace Database.Procedures.JobDetailAnalysisCategoryComplexType

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


        Public Function Load(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext,
                             Optional ByVal IncludeOpenJobsOnly As Boolean = True, Optional ByVal ExcludeNonBillableHours As Boolean = False,
                             Optional ByVal OfficeList As System.Collections.Generic.List(Of String) = Nothing,
                             Optional ByVal ClientList As System.Collections.Generic.List(Of String) = Nothing,
                             Optional ByVal DivisionList As System.Collections.Generic.List(Of String) = Nothing,
                             Optional ByVal ProductList As System.Collections.Generic.List(Of String) = Nothing,
                             Optional ByVal JobList As System.Collections.Generic.List(Of String) = Nothing,
                             Optional ByVal AccountExecutiveList As System.Collections.Generic.List(Of String) = Nothing,
                             Optional ByVal SalesClassList As System.Collections.Generic.List(Of String) = Nothing,
                             Optional ByVal UserCode As String = "", Optional ByVal DateCutoff As String = "") As System.Collections.Generic.List(Of Database.Classes.JobDetailAnalysisCategory)

            'objects
            Dim SqlParameterIncludeOpenJobsOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterExcludeNonBillableHours As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAccountExecutiveList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSalesClassList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDateCutoff As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterIncludeOpenJobsOnly = New System.Data.SqlClient.SqlParameter("@OPEN_JOB_ONLY", SqlDbType.Bit) With {.Value = IncludeOpenJobsOnly}
            SqlParameterExcludeNonBillableHours = New System.Data.SqlClient.SqlParameter("@EXCLUDE_NONBILL_HRS", SqlDbType.Bit) With {.Value = ExcludeNonBillableHours}
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar) With {.Value = UserCode}
            SqlParameterDateCutoff = New System.Data.SqlClient.SqlParameter("@DATE_CUTOFF", SqlDbType.VarChar) With {.Value = DateCutoff}
            SqlParameterOfficeList = New System.Data.SqlClient.SqlParameter("@OFFICE_LIST", SqlDbType.VarChar)
            SqlParameterClientList = New System.Data.SqlClient.SqlParameter("@CLIENT_LIST", SqlDbType.VarChar)
            SqlParameterDivisionList = New System.Data.SqlClient.SqlParameter("@DIVISION_LIST", SqlDbType.VarChar)
            SqlParameterProductList = New System.Data.SqlClient.SqlParameter("@PRODUCT_LIST", SqlDbType.VarChar)
            SqlParameterJobList = New System.Data.SqlClient.SqlParameter("@JOB_LIST", SqlDbType.VarChar)
            SqlParameterAccountExecutiveList = New System.Data.SqlClient.SqlParameter("@ACCT_EXEC_LIST", SqlDbType.VarChar)
            SqlParameterSalesClassList = New System.Data.SqlClient.SqlParameter("@SALES_CLASS_LIST", SqlDbType.VarChar)

            If OfficeList Is Nothing Then

                SqlParameterOfficeList.Value = System.DBNull.Value

            Else

                SqlParameterOfficeList.Value = Join(OfficeList.ToArray, ",")

            End If

            If ClientList Is Nothing Then

                SqlParameterClientList.Value = System.DBNull.Value

            Else

                SqlParameterClientList.Value = Join(ClientList.ToArray, ",")

            End If

            If DivisionList Is Nothing Then

                SqlParameterDivisionList.Value = System.DBNull.Value

            Else

                SqlParameterDivisionList.Value = Join(DivisionList.ToArray, ",")

            End If

            If ProductList Is Nothing Then

                SqlParameterProductList.Value = System.DBNull.Value

            Else

                SqlParameterProductList.Value = Join(ProductList.ToArray, ",")

            End If

            If JobList Is Nothing Then

                SqlParameterJobList.Value = System.DBNull.Value

            Else

                SqlParameterJobList.Value = Join(JobList.ToArray, ",")

            End If

            If AccountExecutiveList Is Nothing Then

                SqlParameterAccountExecutiveList.Value = System.DBNull.Value

            Else

                SqlParameterAccountExecutiveList.Value = Join(AccountExecutiveList.ToArray, ",")

            End If

            If SalesClassList Is Nothing Then

                SqlParameterSalesClassList.Value = System.DBNull.Value

            Else

                SqlParameterSalesClassList.Value = Join(SalesClassList.ToArray, ",")

            End If

            Load = DbContext.Database.SqlQuery(Of Database.Classes.JobDetailAnalysisCategory)("EXEC dbo.advsp_job_detail_analysis_category_load_report @OPEN_JOB_ONLY, @EXCLUDE_NONBILL_HRS, @OFFICE_LIST, @CLIENT_LIST, " &
                                                                                                                                               "@DIVISION_LIST, @PRODUCT_LIST, @JOB_LIST, @ACCT_EXEC_LIST, @SALES_CLASS_LIST, @DATE_CUTOFF, @USER_CODE",
                                                                                              SqlParameterIncludeOpenJobsOnly, SqlParameterExcludeNonBillableHours, SqlParameterOfficeList, SqlParameterClientList,
                                                                                              SqlParameterDivisionList, SqlParameterProductList, SqlParameterJobList, SqlParameterAccountExecutiveList, SqlParameterSalesClassList, SqlParameterDateCutoff, SqlParameterUserCode).ToList

        End Function


#End Region

    End Module

End Namespace
