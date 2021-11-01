Namespace JobForecast

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const _MaximumPostPeriodsPerForecast As Short = 12

#End Region

#Region " Enum "

        Public Enum StaticJobForecastColumn
            JobForecastJobID
            ClientCode
            ClientName
            SalesClassCode
            SalesClassDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            Comments
            ApprovedEstimateAmount
            ApprovedEstimateRevenueAmount
            ApprovedEstimateBillingAmount
            Forecast
            Actual
            Variance
            Color
        End Enum

        Public Enum JobForecastTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Billing")>
            Billing
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Revenue")>
            Revenue
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Billing and Revenue")>
            BillingAndRevenue
        End Enum

        Public Enum AppVarKeys
            ShowApprovedEstimateAmount
        End Enum

#End Region

#Region " Methods "

        Public Function BuildJobForecastJobDetailsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim JobForecastJobDetails As IEnumerable(Of AdvantageFramework.Database.Entities.JobForecastJobDetail) = Nothing
            Dim JobComponentViews As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim JobForecastActuals As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastActual) = Nothing
            Dim JobForecastJobSummaryList As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastJobSummary) = Nothing

            Try

                If DbContext IsNot Nothing AndAlso DbContext IsNot Nothing Then

                    If JobForecastRevision IsNot Nothing Then

                        JobForecastJobSummaryList = LoadJobForecastJobsSummary(DbContext, JobForecastRevision.ID).ToList
                        JobForecastJobDetails = AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastRevisionID(DbContext, JobForecastRevision.ID).ToList
                        PostPeriods = LoadPostPeriodsByJobForecast(DbContext, JobForecastRevision.JobForecast)
                        JobForecastActuals = LoadBillingAndActualData(DbContext, JobForecastRevision.ID)

                        If BuildDataTableStructure(DbContext, JobForecastRevision.JobForecast, PostPeriods, DataTable) Then

                            BuildJobForecastJobRows(JobForecastJobSummaryList, DataTable)
                            BuildJobForecastJobDetailsRows(JobForecastJobSummaryList, JobForecastJobDetails, CType(JobForecastRevision.JobForecast.ForecastType.GetValueOrDefault(0), AdvantageFramework.JobForecast.JobForecastTypes), PostPeriods, JobForecastActuals, DataTable)

                        End If

                    End If

                End If

            Catch ex As Exception
                DataTable = Nothing
            Finally
                BuildJobForecastJobDetailsDataTable = DataTable
            End Try

        End Function
        Public Function BuildDataTableStructure(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal JobForecast As AdvantageFramework.Database.Entities.JobForecast,
                                                ByVal PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod),
                                                ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim StructureBuilt As Boolean = False
            Dim ColumnType As System.Type = Nothing
            Dim AddBilling As Boolean = False
            Dim AddRevenue As Boolean = False

            Try

                If JobForecast IsNot Nothing Then

                    DataTable = New System.Data.DataTable

                    For Each StaticColumnName In AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(StaticJobForecastColumn), False)

                        Select Case StaticColumnName.ToString

                            Case StaticJobForecastColumn.Actual.ToString, StaticJobForecastColumn.Forecast.ToString, StaticJobForecastColumn.Variance.ToString,
                                 StaticJobForecastColumn.ApprovedEstimateAmount.ToString, StaticJobForecastColumn.ApprovedEstimateBillingAmount.ToString,
                                 StaticJobForecastColumn.ApprovedEstimateRevenueAmount.ToString

                                ColumnType = GetType(Decimal)

                            Case StaticJobForecastColumn.JobForecastJobID.ToString, StaticJobForecastColumn.JobNumber.ToString, StaticJobForecastColumn.Color.ToString

                                ColumnType = GetType(Integer)

                            Case StaticJobForecastColumn.JobComponentNumber.ToString

                                ColumnType = GetType(Short)

                            Case Else

                                ColumnType = GetType(String)

                        End Select

                        DataTable.Columns.Add(StaticColumnName, ColumnType)

                    Next

                    If JobForecast.ForecastType.GetValueOrDefault(0) = AdvantageFramework.JobForecast.JobForecastTypes.Billing Then

                        AddBilling = True

                    ElseIf JobForecast.ForecastType.GetValueOrDefault(0) = AdvantageFramework.JobForecast.JobForecastTypes.Revenue Then

                        AddRevenue = True

                    ElseIf JobForecast.ForecastType.GetValueOrDefault(0) = AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                        AddBilling = True
                        AddRevenue = True

                    End If

                    For Each PostPeriodCode In PostPeriods.Select(Function(pp) pp.Code).ToList

                        If AddBilling Then

                            DataTable.Columns.Add(GetBillingPostPeriodColumnDataField(PostPeriodCode), GetType(Decimal))
                            DataTable.Columns.Add(GetBillingPostPeriodColumnDataField(PostPeriodCode) & "_Actual", GetType(Decimal))

                        End If

                        If AddRevenue Then

                            DataTable.Columns.Add(GetRevenuePostPeriodColumnDataField(PostPeriodCode), GetType(Decimal))
                            DataTable.Columns.Add(GetRevenuePostPeriodColumnDataField(PostPeriodCode) & "_Actual", GetType(Decimal))

                        End If

                    Next

                    StructureBuilt = True

                End If

            Catch ex As Exception
                StructureBuilt = False
            Finally
                BuildDataTableStructure = StructureBuilt
            End Try

        End Function
        Public Function BuildJobForecastJobRows(ByVal JobForecastJobSummaryList As IEnumerable(Of AdvantageFramework.JobForecast.Classes.JobForecastJobSummary),
                                                ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim JobsBuilt As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing

            Try

                If DataTable IsNot Nothing Then

                    If JobForecastJobSummaryList IsNot Nothing AndAlso JobForecastJobSummaryList.Count > 0 Then

                        For Each JobForecastJobSummary In JobForecastJobSummaryList

                            DataRow = DataTable.NewRow()

                            With DataRow

                                DataRow(StaticJobForecastColumn.JobForecastJobID.ToString) = JobForecastJobSummary.JobForecastJobID
                                DataRow(StaticJobForecastColumn.ClientCode.ToString) = JobForecastJobSummary.ClientCode
                                DataRow(StaticJobForecastColumn.ClientName.ToString) = JobForecastJobSummary.ClientName
                                DataRow(StaticJobForecastColumn.SalesClassCode.ToString) = JobForecastJobSummary.SalesClassCode
                                DataRow(StaticJobForecastColumn.SalesClassDescription.ToString) = JobForecastJobSummary.SalesClassDescription
                                DataRow(StaticJobForecastColumn.JobNumber.ToString) = JobForecastJobSummary.JobNumber
                                DataRow(StaticJobForecastColumn.JobDescription.ToString) = JobForecastJobSummary.JobDescription
                                DataRow(StaticJobForecastColumn.JobComponentNumber.ToString) = JobForecastJobSummary.JobComponentNumber
                                DataRow(StaticJobForecastColumn.JobComponentDescription.ToString) = JobForecastJobSummary.JobComponentDescription
                                DataRow(StaticJobForecastColumn.Comments.ToString) = JobForecastJobSummary.Comments

                                If JobForecastJobSummary.ApprovedEstimateBillingAmount.HasValue Then

                                    DataRow(StaticJobForecastColumn.ApprovedEstimateBillingAmount.ToString) = JobForecastJobSummary.ApprovedEstimateBillingAmount

                                End If

                                If JobForecastJobSummary.ApprovedEstimateRevenueAmount.HasValue Then

                                    DataRow(StaticJobForecastColumn.ApprovedEstimateRevenueAmount.ToString) = JobForecastJobSummary.ApprovedEstimateRevenueAmount

                                End If

                                If JobForecastJobSummary.ApprovedEstimateAmount.HasValue Then

                                    DataRow(StaticJobForecastColumn.ApprovedEstimateAmount.ToString) = JobForecastJobSummary.ApprovedEstimateAmount

                                End If

                                If JobForecastJobSummary.Forecast.HasValue Then

                                    DataRow(StaticJobForecastColumn.Forecast.ToString) = JobForecastJobSummary.Forecast

                                End If

                                If JobForecastJobSummary.Actual.HasValue Then

                                    DataRow(StaticJobForecastColumn.Actual.ToString) = JobForecastJobSummary.Actual

                                End If

                                If JobForecastJobSummary.Variance.HasValue Then

                                    DataRow(StaticJobForecastColumn.Variance.ToString) = JobForecastJobSummary.Variance

                                End If

                                If JobForecastJobSummary.Color.HasValue Then

                                    DataRow(StaticJobForecastColumn.Color.ToString) = JobForecastJobSummary.Color

                                End If

                            End With

                            DataTable.Rows.Add(DataRow)

                        Next

                        JobsBuilt = True

                    End If

                End If

            Catch ex As Exception
                JobsBuilt = False
            Finally
                BuildJobForecastJobRows = JobsBuilt
            End Try

        End Function
        Public Function BuildJobForecastJobDetailsRows(ByVal JobForecastJobSummaryList As IEnumerable(Of AdvantageFramework.JobForecast.Classes.JobForecastJobSummary),
                                                       ByVal JobForecastJobDetails As IEnumerable(Of AdvantageFramework.Database.Entities.JobForecastJobDetail),
                                                       ByVal JobForecastType As AdvantageFramework.JobForecast.JobForecastTypes,
                                                       ByVal PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod),
                                                       ByVal JobForecastActuals As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastActual),
                                                       ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim DetailsBuilt As Boolean = False
            Dim JobForecastJobSummary As AdvantageFramework.JobForecast.Classes.JobForecastJobSummary = Nothing
            Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing

            Try

                If DataTable IsNot Nothing Then

                    'If JobForecastJobDetails IsNot Nothing AndAlso JobForecastJobDetails.Count > 0 Then

                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                        JobForecastJobSummary = Nothing

                        Try

                            JobForecastJobSummary = JobForecastJobSummaryList.First(Function(JfJob) JfJob.JobForecastJobID = CInt(DataRow(StaticJobForecastColumn.JobForecastJobID.ToString)))

                        Catch ex As Exception
                            JobForecastJobSummary = Nothing
                        End Try

                        If JobForecastJobSummary IsNot Nothing Then

                            For Each PostPeriod In PostPeriods

                                JobForecastJobDetail = Nothing

                                Try

                                    JobForecastJobDetail = JobForecastJobDetails.Where(Function(item) item.PostPeriod = PostPeriod.Code AndAlso item.JobForecastJobID = JobForecastJobSummary.JobForecastJobID).SingleOrDefault

                                Catch ex As Exception
                                    JobForecastJobDetail = Nothing
                                End Try

                                If JobForecastType = JobForecastTypes.Billing OrElse JobForecastType = JobForecastTypes.BillingAndRevenue Then

                                    If DataTable.Columns.Contains(GetBillingPostPeriodColumnDataField(PostPeriod.Code)) = True Then

                                        If JobForecastJobDetail IsNot Nothing Then

                                            If JobForecastJobDetail.BillingAmount.HasValue Then

                                                DataRow(GetBillingPostPeriodColumnDataField(PostPeriod.Code)) = JobForecastJobDetail.BillingAmount

                                            End If

                                        End If

                                        If JobForecastActuals IsNot Nothing Then

                                            DataRow(GetBillingPostPeriodColumnDataField(PostPeriod.Code) & "_Actual") = CalculateActualBilling(JobForecastActuals, PostPeriods.SingleOrDefault(Function(Pp) Pp.Code = PostPeriod.Code), JobForecastJobSummary.JobNumber, JobForecastJobSummary.JobComponentNumber)

                                        End If

                                    End If

                                End If

                                If JobForecastType = JobForecastTypes.Revenue OrElse JobForecastType = JobForecastTypes.BillingAndRevenue Then

                                    If DataTable.Columns.Contains(GetRevenuePostPeriodColumnDataField(PostPeriod.Code)) = True Then

                                        If JobForecastJobDetail IsNot Nothing Then

                                            If JobForecastJobDetail.RevenueAmount.HasValue Then

                                                DataRow(GetRevenuePostPeriodColumnDataField(PostPeriod.Code)) = JobForecastJobDetail.RevenueAmount

                                            End If

                                        End If

                                        If JobForecastActuals IsNot Nothing Then

                                            DataRow(GetRevenuePostPeriodColumnDataField(PostPeriod.Code) & "_Actual") = CalculateActualRevenue(JobForecastActuals, PostPeriods.SingleOrDefault(Function(Pp) Pp.Code = PostPeriod.Code), JobForecastJobSummary.JobNumber, JobForecastJobSummary.JobComponentNumber)

                                        End If

                                    End If

                                End If

                            Next

                        End If

                    Next

                    DetailsBuilt = True

                End If

            Catch ex As Exception
                DetailsBuilt = False
            Finally
                BuildJobForecastJobDetailsRows = DetailsBuilt
            End Try

        End Function
        Public Function LoadApprovedJobForecastRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastID As Integer) As AdvantageFramework.Database.Entities.JobForecastRevision

            'objects
            Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing

            Try

                JobForecastRevision = (From Item In AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(DbContext, JobForecastID)
                                       Where Item.IsApproved = True
                                       Select Item).SingleOrDefault

            Catch ex As Exception
                JobForecastRevision = Nothing
            Finally
                LoadApprovedJobForecastRevision = JobForecastRevision
            End Try

        End Function
        Public Function LoadCurrentJobForecasts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal JobNumber As Integer,
                                                ByVal JobComponentNumber As Short, ByVal DateToSearch As Date?, ByVal UserCode As String) As IEnumerable(Of AdvantageFramework.JobForecast.Classes.JobForecastView)

            LoadCurrentJobForecasts = LoadRevisions(DbContext, EmployeeCode, JobNumber, JobComponentNumber, DateToSearch, True, UserCode)

        End Function
        Public Function LoadRevisions(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal JobNumber As Integer,
                                      ByVal JobComponentNumber As Short, ByVal DateToSearch As Date?, ByVal CurrentOnly As Boolean, ByVal UserCode As String) As IEnumerable(Of AdvantageFramework.JobForecast.Classes.JobForecastView)

            'objects
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DateToSearchSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CurrentOnlySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar)
            JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            DateToSearchSqlParameter = New System.Data.SqlClient.SqlParameter("@DATE_TO_SEARCH", SqlDbType.SmallDateTime)
            CurrentOnlySqlParameter = New System.Data.SqlClient.SqlParameter("@CURRENT_ONLY", SqlDbType.Bit)
            UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)

            EmployeeCodeSqlParameter.Value = EmployeeCode
            JobNumberSqlParameter.Value = JobNumber
            JobComponentNumberSqlParameter.Value = JobComponentNumber

            If DateToSearch.HasValue Then

                DateToSearchSqlParameter.Value = DateToSearch

            Else

                DateToSearchSqlParameter.Value = DBNull.Value

            End If

            CurrentOnlySqlParameter.Value = CurrentOnly
            UserCodeSqlParameter.Value = UserCode

            Try

                LoadRevisions = DbContext.Database.SqlQuery(Of AdvantageFramework.JobForecast.Classes.JobForecastView) _
                               ("EXEC [dbo].[advsp_job_forecast_load_revisions] @EMP_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @DATE_TO_SEARCH, @CURRENT_ONLY, @USER_CODE",
                                EmployeeCodeSqlParameter, JobNumberSqlParameter, JobComponentNumberSqlParameter, DateToSearchSqlParameter, CurrentOnlySqlParameter, UserCodeSqlParameter).ToList

            Catch ex As Exception
                LoadRevisions = Nothing
            End Try

        End Function
        Public Function CreateNewJobForecast(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Description As String, ByVal Comment As String, ByVal PostPeriodStart As String,
                                             ByVal PostPeriodEnd As String, ByVal Budget As Decimal?, ByVal EmployeeCode As String, ByVal OfficeCode As String,
                                             ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByRef JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing
            Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
            Dim Created As Boolean = False

            Try

                If CreateJobForecastEntity(DbContext, Description, Comment, PostPeriodStart, PostPeriodEnd, Budget, EmployeeCode, OfficeCode, JobForecast) = True Then

                    Created = CreateJobForecastRevisionEntity(DbContext, JobForecast.ID, Comment, JobForecastRevision)

                    If Created Then

                        If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                            CreateJobForecastJobEntity(DbContext, JobForecast.ID, JobForecastRevision.ID, JobNumber, JobComponentNumber, Nothing, Nothing, Nothing, JobForecastJob)

                        End If

                    End If

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateNewJobForecast = Created
            End Try

        End Function
        Public Function InsertNewJobForecastJob(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision,
                                                ByVal JobComponent As AdvantageFramework.Database.Entities.JobComponent) As Boolean

            'objects
            Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
            Dim Inserted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If JobForecastRevision IsNot Nothing AndAlso JobComponent IsNot Nothing Then

                        For Each RelatedJobForecastRevision In AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(DbContext, JobForecastRevision.JobForecastID).ToList

                            If CreateJobForecastJobEntity(DbContext, RelatedJobForecastRevision.JobForecastID, RelatedJobForecastRevision.ID, JobComponent.JobNumber, JobComponent.Number, Nothing, Nothing, Nothing, JobForecastJob) Then

                                Inserted = True

                                UpdateJobForecastRevision(DbContext, AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, RelatedJobForecastRevision.ID))

                            End If

                        Next

                    End If

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                InsertNewJobForecastJob = Inserted
            End Try

        End Function
        Public Function CopyJobForecast(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal JobForecastToCopy As AdvantageFramework.Database.Entities.JobForecast,
                                        ByRef JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing
            Dim JobForecastRevisionToCopy As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
            Dim Copied As Boolean = False

            Try

                If CreateJobForecastEntity(DbContext, JobForecastToCopy.Description, JobForecastToCopy.Comment, JobForecastToCopy.PostPeriodStart, JobForecastToCopy.PostPeriodEnd, JobForecastToCopy.Budget, JobForecastToCopy.AssignedToEmployeeCode, JobForecastToCopy.OfficeCode, JobForecast) Then

                    Try

                        JobForecastRevisionToCopy = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(DbContext, JobForecastToCopy.ID).OrderByDescending(Function(Rev) Rev.RevisionNumber).FirstOrDefault

                    Catch ex As Exception
                        JobForecastRevisionToCopy = Nothing
                    End Try

                    If JobForecastRevisionToCopy IsNot Nothing Then

                        CopyJobForecastRevision(DbContext, JobForecast, JobForecastRevisionToCopy, JobForecastRevision)

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyJobForecast = Copied
            End Try

        End Function
        Public Function CopyJobForecastFromJobForecastRevision(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                               ByVal JobForecastDescription As String, ByVal JobForecastComments As String, ByVal PostPeriodStart As String,
                                                               ByVal PostPeriodEnd As String, ByVal EmployeeCode As String, ByVal OfficeCode As String, ByVal Budget As Decimal?,
                                                               ByVal JobForecastRevisionToCopy As AdvantageFramework.Database.Entities.JobForecastRevision,
                                                               ByRef JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing
            Dim Copied As Boolean = False

            Try

                If CreateJobForecastEntity(DbContext, JobForecastDescription, JobForecastComments, PostPeriodStart, PostPeriodEnd, Budget, EmployeeCode, OfficeCode, JobForecast) Then

                    If JobForecastRevisionToCopy IsNot Nothing Then

                        Copied = CopyJobForecastRevision(DbContext, JobForecast.ID, JobForecastRevisionToCopy, JobForecastRevision)

                        If Copied Then

                            JobForecastRevision.Comment = JobForecastComments

                            AdvantageFramework.Database.Procedures.JobForecastRevision.Update(DbContext, JobForecastRevision)

                        End If

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyJobForecastFromJobForecastRevision = Copied
            End Try

        End Function
        Public Function CopyJobForecastRevision(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal JobForecastID As Integer,
                                                ByVal JobForecastRevisionToCopy As AdvantageFramework.Database.Entities.JobForecastRevision,
                                                ByRef JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim CopyFromRevisionIDParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ForecastIDParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim Copied As Boolean = False

            Try

                If JobForecastRevisionToCopy IsNot Nothing Then

                    CopyFromRevisionIDParameter = New SqlClient.SqlParameter("copyFromRevisionID", System.Data.SqlDbType.Int) With {.Value = JobForecastRevisionToCopy.ID}
                    ForecastIDParameter = New SqlClient.SqlParameter("copyToForecastID", System.Data.SqlDbType.Int) With {.Value = JobForecastID}
                    UserCodeParameter = New SqlClient.SqlParameter("userCode", System.Data.SqlDbType.VarChar) With {.Value = DbContext.UserCode}

                    DbContext.Database.ExecuteSqlCommand("exec dbo.advsp_job_forecast_copy_revision @copyFromRevisionID, @copyToForecastID, @userCode", CopyFromRevisionIDParameter, ForecastIDParameter, UserCodeParameter)

                    With AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(DbContext, JobForecastID)

                        JobForecastRevision = .Where(Function(item) item.RevisionNumber = .Max(Function(rev) rev.RevisionNumber)).SingleOrDefault

                    End With

                End If

                Copied = True

            Catch ex As Exception
                Copied = False
            Finally
                CopyJobForecastRevision = Copied
            End Try

        End Function
        'Public Function CopyJobForecastRevision(ByVal DbContext As AdvantageFramework.Database.DbContext,
        '                                        ByVal JobForecastID As Integer,
        '                                        ByVal JobForecastRevisionToCopy As AdvantageFramework.Database.Entities.JobForecastRevision,
        '                                        ByRef JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

        '    'objects
        '    Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing
        '    Dim Copied As Boolean = False

        '    Try

        '        JobForecast = AdvantageFramework.Database.Procedures.JobForecast.LoadByID(DbContext, JobForecastID)

        '        If JobForecast IsNot Nothing Then

        '            Copied = CopyJobForecastRevision(DbContext, JobForecast, JobForecastRevisionToCopy, JobForecastRevision)

        '        End If

        '    Catch ex As Exception
        '        Copied = False
        '    Finally
        '        CopyJobForecastRevision = Copied
        '    End Try

        'End Function
        Public Function CopyJobForecastRevision(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal JobForecast As AdvantageFramework.Database.Entities.JobForecast,
                                                ByVal JobForecastRevisionToCopy As AdvantageFramework.Database.Entities.JobForecastRevision,
                                                ByRef JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim JobForecastJobToCopy As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim Copied As Boolean = False

            Try

                Copied = CreateJobForecastRevisionEntity(DbContext, JobForecast.ID, JobForecastRevisionToCopy.Comment, JobForecastRevision)

                If Copied = True Then

                    PostPeriods = LoadPostPeriodsByJobForecast(DbContext, JobForecast)

                    For Each JobForecastJobToCopy In AdvantageFramework.Database.Procedures.JobForecastJob.LoadByJobForecastRevisionID(DbContext, JobForecastRevisionToCopy.ID).ToList

                        CopyJobForecastJob(DbContext, JobForecastRevision.JobForecastID, JobForecastRevision.ID, PostPeriods, JobForecastJobToCopy)

                    Next

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyJobForecastRevision = Copied
            End Try

        End Function
        Public Function CopyJobForecastJob(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastID As Integer, ByVal JobForecastRevisionID As Integer,
                                           ByVal PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod),
                                           ByVal JobForecastJobToCopy As AdvantageFramework.Database.Entities.JobForecastJob) As Boolean

            'objects
            Dim Copied As Boolean = True
            Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing

            Try

                Copied = CreateJobForecastJobEntity(DbContext, JobForecastID, JobForecastRevisionID, JobForecastJobToCopy.JobNumber, JobForecastJobToCopy.JobComponentNumber,
                                                    JobForecastJobToCopy.Comment, JobForecastJobToCopy.IncomeAmount, JobForecastJobToCopy.Color, JobForecastJob)

                If Copied = True Then

                    For Each JobForecastJobDetailToCopy In AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastJobID(DbContext, JobForecastJobToCopy.ID).ToList

                        CopyJobForecastJobDetail(DbContext, JobForecastID, JobForecastRevisionID, JobForecastJob.ID, PostPeriods, JobForecastJobDetailToCopy)

                    Next

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyJobForecastJob = Copied
            End Try

        End Function
        Public Function CopyJobForecastJob(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal JobForecastID As Integer, ByVal JobForecastRevisionID As Integer,
                                           ByVal JobForecastJobToCopy As AdvantageFramework.Database.Entities.JobForecastJob) As Boolean

            'objects
            Dim Copied As Boolean = True
            Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

            Try

                Copied = CreateJobForecastJobEntity(DbContext, JobForecastID, JobForecastRevisionID, JobForecastJobToCopy.JobNumber, JobForecastJobToCopy.JobComponentNumber,
                                                    JobForecastJobToCopy.Comment, JobForecastJobToCopy.IncomeAmount, JobForecastJobToCopy.Color, JobForecastJob)

                If Copied = True Then

                    PostPeriods = LoadPostPeriodsByJobForecast(DbContext, JobForecastID)

                    For Each JobForecastJobDetailToCopy In AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastJobID(DbContext, JobForecastJobToCopy.ID).ToList

                        CopyJobForecastJobDetail(DbContext, JobForecastID, JobForecastRevisionID, JobForecastJob.ID, PostPeriods, JobForecastJobDetailToCopy)

                    Next

                End If


            Catch ex As Exception
                Copied = False
            Finally
                CopyJobForecastJob = Copied
            End Try

        End Function
        Public Function CopyJobForecastJobDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastID As Integer, ByVal JobForecastRevisionID As Integer, ByVal JobForecastJobID As Integer,
                                                 ByVal PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod),
                                                 ByVal JobForecastJobDetailToCopy As AdvantageFramework.Database.Entities.JobForecastJobDetail) As Boolean

            'objects
            Dim Copied As Boolean = True
            Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing

            Try

                If PostPeriods.Any(Function(PPeriod) PPeriod.Code = JobForecastJobDetailToCopy.PostPeriod) = True Then

                    Copied = CreateJobForecastJobDetailEntity(DbContext, JobForecastID, JobForecastRevisionID, JobForecastJobID, JobForecastJobDetailToCopy.PostPeriod,
                                                              JobForecastJobDetailToCopy.BillingAmount, JobForecastJobDetailToCopy.RevenueAmount, JobForecastJobDetail)

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyJobForecastJobDetail = Copied
            End Try

        End Function
        Public Function CopyJobForecastJobDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal JobForecastID As Integer, ByVal JobForecastRevisionID As Integer, ByVal JobForecastJobID As Integer,
                                                 ByVal JobForecastJobDetailToCopy As AdvantageFramework.Database.Entities.JobForecastJobDetail) As Boolean

            'objects
            Dim Copied As Boolean = True
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing

            Try

                JobForecast = AdvantageFramework.Database.Procedures.JobForecast.LoadByID(DbContext, JobForecastID)

                If JobForecast IsNot Nothing Then

                    PostPeriods = LoadPostPeriodsByJobForecast(DbContext, JobForecast)

                    Copied = CopyJobForecastJobDetail(DbContext, JobForecast.ID, JobForecastRevisionID, JobForecastJobID, PostPeriods, JobForecastJobDetailToCopy)

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyJobForecastJobDetail = Copied
            End Try

        End Function
        Public Function DeleteJobForecast(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecast As AdvantageFramework.Database.Entities.JobForecast) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If JobForecast IsNot Nothing Then

                        For Each JobForecastRevision In AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(DbContext, JobForecast.ID).ToList

                            DeleteJobForecastRevision(DbContext, JobForecastRevision, True)

                        Next

                    End If

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteJobForecast = Deleted
            End Try

        End Function
        Public Function DeleteJobForecastRevision(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision,
                                                  ByVal DeleteJobForecastIfNoRevision As Boolean) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing
            Dim ForecastHeaderDeleted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If JobForecastRevision IsNot Nothing Then

                        Using DbContextTransaction = DbContext.Database.BeginTransaction

                            DbContext.Database.ExecuteSqlCommand(String.Format("Delete From dbo.JF_JOB_DTL Where JF_REV_ID = {0}", JobForecastRevision.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("Delete From dbo.JF_JOB Where JF_REV_ID = {0}", JobForecastRevision.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("Delete From dbo.JF_REV Where JF_REV_ID = {0}", JobForecastRevision.ID))

                            If DeleteJobForecastIfNoRevision Then

                                ForecastHeaderDeleted = DbContext.Database.SqlQuery(Of Boolean)(String.Format("IF (Select COUNT(*) From dbo.JF_REV WHERE JF_ID = {0}) = 0 BEGIN Delete From dbo.JF_HDR Where JF_ID = {0}; Select Convert(bit, 1) END ELSE Select Convert(bit, 0)", JobForecastRevision.JobForecastID)).FirstOrDefault

                            End If

                            Try

                                DbContextTransaction.Commit()

                                Deleted = True

                            Catch ex As Exception
                                DbContextTransaction.Rollback()
                            End Try

                        End Using

                        If Deleted AndAlso Not ForecastHeaderDeleted Then

                            JobForecast = AdvantageFramework.Database.Procedures.JobForecast.LoadByID(DbContext, JobForecastRevision.JobForecastID)

                            If JobForecast IsNot Nothing Then

                                If DeleteJobForecastIfNoRevision Then

                                    If (From Item In AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(DbContext, JobForecast.ID)
                                        Select Item).Count = 0 Then

                                        AdvantageFramework.Database.Procedures.JobForecast.Delete(DbContext, JobForecast)

                                    End If

                                Else

                                    UpdateJobForecast(DbContext, JobForecast)

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteJobForecastRevision = Deleted
            End Try

        End Function
        Public Function DeleteJobForecastJobFromForecast(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim DbContextTransaction As Entity.DbContextTransaction = Nothing
            Dim IsNewTransaction As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If JobForecastJob IsNot Nothing Then

                        DbContextTransaction = DbContext.Database.CurrentTransaction

                        If DbContextTransaction Is Nothing Then

                            IsNewTransaction = True
                            DbContextTransaction = DbContext.Database.BeginTransaction

                        End If

                        DbContext.Database.ExecuteSqlCommand(String.Format("Delete " &
                                                                                "dtl " &
                                                                            "From " &
                                                                                "dbo.JF_JOB_DTL dtl " &
                                                                            "Join " &
                                                                                "dbo.JF_JOB job On dtl.JF_JOB_ID = job.JF_JOB_ID " &
                                                                            "Where " &
                                                                                "job.JF_ID = {0} And " &
                                                                                "job.JOB_NUMBER = {1} And " &
                                                                                "job.JOB_COMPONENT_NBR = {2}", JobForecastJob.JobForecastID, JobForecastJob.JobNumber, JobForecastJob.JobComponentNumber))

                        DbContext.Database.ExecuteSqlCommand(String.Format("Delete From " &
                                                                                "dbo.JF_JOB " &
                                                                            "Where " &
                                                                                "JF_ID = {0} And " &
                                                                                "JOB_NUMBER = {1} And " &
                                                                                "JOB_COMPONENT_NBR = {2}", JobForecastJob.JobForecastID, JobForecastJob.JobNumber, JobForecastJob.JobComponentNumber))

                        If IsNewTransaction Then

                            Try

                                DbContextTransaction.Commit()

                                Deleted = True

                            Catch ex As Exception
                                DbContextTransaction.Rollback()
                            End Try

                            If Deleted Then

                                UpdateJobForecastRevision(DbContext, AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, JobForecastJob.ID))

                            End If

                            DbContextTransaction.Dispose()

                        Else

                            Deleted = True

                        End If

                    End If

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteJobForecastJobFromForecast = Deleted
            End Try

        End Function
        Public Function DeleteJobForecastJobFromForecast(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing

            Try

                If DbContext IsNot Nothing Then

                    JobForecastJob = AdvantageFramework.Database.Procedures.JobForecastJob.LoadByID(DbContext, JobForecastJobID)

                    If JobForecastJob IsNot Nothing Then

                        Deleted = DeleteJobForecastJobFromForecast(DbContext, JobForecastJob)

                    End If

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteJobForecastJobFromForecast = Deleted
            End Try

        End Function
        Public Function DeleteJobForecastJob(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsNewTransaction As Boolean = False
            Dim DbContextTransaction As Entity.DbContextTransaction = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If JobForecastJob IsNot Nothing Then

                        DbContextTransaction = DbContext.Database.CurrentTransaction

                        If DbContextTransaction Is Nothing Then

                            DbContextTransaction = DbContext.Database.BeginTransaction
                            IsNewTransaction = True

                        End If

                        DbContext.Database.ExecuteSqlCommand(String.Format("Delete From dbo.JF_JOB_DTL Where JF_JOB_ID = {0}", JobForecastJob.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("Delete From dbo.JF_JOB Where JF_JOB_ID = {0}", JobForecastJob.ID))

                        If IsNewTransaction Then

                            Try

                                DbContextTransaction.Commit()

                                Deleted = True

                            Catch ex As Exception
                                DbContextTransaction.Rollback()
                            End Try

                            DbContextTransaction.Dispose()

                            If Deleted Then

                                UpdateJobForecastRevision(DbContext, AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, JobForecastJob.JobForecastRevisionID))

                            End If

                        Else

                            Deleted = True

                        End If

                    End If

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteJobForecastJob = Deleted
            End Try

        End Function
        Public Function DeleteJobForecastJob(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    Deleted = DeleteJobForecastJob(DbContext, AdvantageFramework.Database.Procedures.JobForecastJob.LoadByID(DbContext, JobForecastJobID))

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteJobForecastJob = Deleted
            End Try

        End Function
        Public Function DeleteJobForecastJobDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                If DbContext IsNot Nothing Then

                    If JobForecastJobDetail IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.JobForecastJobDetail.Delete(DbContext, JobForecastJobDetail)

                    End If

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteJobForecastJobDetail = Deleted
            End Try

        End Function
        Public Function UpdateJobForecast(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecast As AdvantageFramework.Database.Entities.JobForecast) As Boolean

            'objects
            Dim Updated As Boolean = False

            Try

                JobForecast.ModifiedByUserCode = DbContext.UserCode
                JobForecast.ModifiedDate = System.DateTime.Now

                Updated = AdvantageFramework.Database.Procedures.JobForecast.Update(DbContext, JobForecast)

            Catch ex As Exception
                Updated = False
            Finally
                UpdateJobForecast = Updated
            End Try

        End Function
        Public Function UpdateJobForecastRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim Updated As Boolean = False

            Try

                JobForecastRevision.ModifiedByUserCode = DbContext.UserCode
                JobForecastRevision.ModifiedDate = System.DateTime.Now

                Updated = AdvantageFramework.Database.Procedures.JobForecastRevision.Update(DbContext, JobForecastRevision)

                If Updated Then

                    UpdateJobForecast(DbContext, AdvantageFramework.Database.Procedures.JobForecast.LoadByID(DbContext, JobForecastRevision.JobForecastID))

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateJobForecastRevision = Updated
            End Try

        End Function
        Public Function UpdateJobForecastJob(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob) As Boolean

            'objects
            Dim Updated As Boolean = False

            Try

                JobForecastJob.ModifiedByUserCode = DbContext.UserCode
                JobForecastJob.ModifiedDate = System.DateTime.Now

                Updated = AdvantageFramework.Database.Procedures.JobForecastJob.Update(DbContext, JobForecastJob)

                If Updated Then

                    UpdateJobForecastRevision(DbContext, AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, JobForecastJob.JobForecastRevisionID))

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateJobForecastJob = Updated
            End Try

        End Function
        Public Function UpdateJobForecastJobDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim JobForecastJobDetailList As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJobDetail) = Nothing

            Try

                JobForecastJobDetailList = New Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJobDetail)

                JobForecastJobDetailList.Add(JobForecastJobDetail)

                Updated = UpdateJobForecastJobDetailBatch(DbContext, JobForecastJobDetailList)

            Catch ex As Exception
                Updated = False
            Finally
                UpdateJobForecastJobDetail = Updated
            End Try

        End Function
        Public Function UpdateJobForecastJobDetailBatch(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobDetails As IEnumerable(Of AdvantageFramework.Database.Entities.JobForecastJobDetail)) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim CreatedOrModifiedDate As DateTime = Nothing
            Dim CreatedOrModifiedUser As String = Nothing
            Dim ErrorText As String = ""
            Dim IsValid As Boolean = False

            Try

                If JobForecastJobDetails IsNot Nothing AndAlso JobForecastJobDetails.Count > 0 Then

                    CreatedOrModifiedDate = System.DateTime.Now
                    CreatedOrModifiedUser = DbContext.UserCode

                    For Each JobForecastJobDetail In JobForecastJobDetails

                        ErrorText = ""
                        IsValid = True

                        ErrorText = JobForecastJobDetail.ValidateEntity(IsValid)

                        If IsValid Then

                            If (From Item In AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastJobID(DbContext, JobForecastJobDetail.JobForecastJobID)
                                Where Item.PostPeriod = JobForecastJobDetail.PostPeriod
                                Select Item).Any Then

                                JobForecastJobDetail.ModifiedByUserCode = CreatedOrModifiedUser
                                JobForecastJobDetail.ModifiedDate = CreatedOrModifiedDate

                                DbContext.Entry(JobForecastJobDetail).State = Entity.EntityState.Modified

                                'Updated = AdvantageFramework.Database.Procedures.JobForecastJobDetail.Update(DbContext, JobForecastJobDetail)

                            Else

                                JobForecastJobDetail.CreatedByUserCode = CreatedOrModifiedUser
                                JobForecastJobDetail.CreatedDate = CreatedOrModifiedDate

                                DbContext.JobForecastJobDetails.Add(JobForecastJobDetail)

                                'Updated = AdvantageFramework.Database.Procedures.JobForecastJobDetail.Insert(DbContext, JobForecastJobDetail)

                            End If

                        End If

                    Next

                    DbContext.SaveChanges()

                    For Each JobForecastJobID In JobForecastJobDetails.Select(Function(JobFCJobDtl) JobFCJobDtl.JobForecastJobID).Distinct

                        UpdateJobForecastJob(DbContext, AdvantageFramework.Database.Procedures.JobForecastJob.LoadByID(DbContext, JobForecastJobID))

                    Next

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateJobForecastJobDetailBatch = Updated
            End Try

        End Function
        Public Function UpdateJobForecastJobDetailBatch(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobID As Integer, ByVal PostPeriodsAndValues As IDictionary) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
            Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing
            Dim JobForecastJobDetails As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJobDetail) = Nothing
            Dim BillingAmount As Decimal? = Nothing

            Try

                If PostPeriodsAndValues IsNot Nothing AndAlso PostPeriodsAndValues.Count > 0 Then

                    JobForecastJob = AdvantageFramework.Database.Procedures.JobForecastJob.LoadByID(DbContext, JobForecastJobID)

                    If JobForecastJob IsNot Nothing Then

                        JobForecastJobDetails = AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastJobID(DbContext, JobForecastJobID).ToList

                        For Each DictionaryEntry In PostPeriodsAndValues.OfType(Of DictionaryEntry)()

                            JobForecastJobDetail = Nothing
                            BillingAmount = Nothing

                            Try

                                JobForecastJobDetail = (From Item In JobForecastJobDetails
                                                        Where Item.PostPeriod = DictionaryEntry.Key
                                                        Select Item).SingleOrDefault

                            Catch ex As Exception
                                JobForecastJobDetail = Nothing
                            End Try

                            If DictionaryEntry.Value IsNot Nothing Then

                                Try

                                    BillingAmount = CDec(DictionaryEntry.Value)

                                Catch ex As Exception
                                    BillingAmount = Nothing
                                End Try

                            End If

                            If JobForecastJobDetail Is Nothing Then

                                JobForecastJobDetail = New AdvantageFramework.Database.Entities.JobForecastJobDetail

                                With JobForecastJobDetail

                                    .JobForecastID = JobForecastJob.JobForecastID
                                    .JobForecastRevisionID = JobForecastJob.JobForecastRevisionID
                                    .JobForecastJobID = JobForecastJob.ID
                                    .CreatedByUserCode = DbContext.UserCode
                                    .CreatedDate = System.DateTime.Now
                                    .BillingAmount = BillingAmount
                                    .PostPeriod = DictionaryEntry.Key

                                End With

                                AdvantageFramework.Database.Procedures.JobForecastJobDetail.Insert(DbContext, JobForecastJobDetail)

                            Else

                                JobForecastJobDetail.ModifiedByUserCode = DbContext.UserCode
                                JobForecastJobDetail.ModifiedDate = System.DateTime.Now
                                JobForecastJobDetail.BillingAmount = BillingAmount

                                AdvantageFramework.Database.Procedures.JobForecastJobDetail.Update(DbContext, JobForecastJobDetail)

                            End If

                        Next

                    End If

                    UpdateJobForecastJob(DbContext, JobForecastJob)

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
            Finally
                UpdateJobForecastJobDetailBatch = Updated
            End Try

        End Function
        Public Function ReviseJobForcast(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision,
                                         ByRef NewJobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim Revised As Boolean = False
            Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing

            Try

                If DbContext IsNot Nothing AndAlso JobForecastRevision IsNot Nothing Then

                    If UpdateJobForecastRevision(DbContext, JobForecastRevision) Then

                        Revised = CopyJobForecastRevision(DbContext, JobForecastRevision.JobForecastID, JobForecastRevision, NewJobForecastRevision)

                        If Revised Then

                            UpdateJobForecast(DbContext, AdvantageFramework.Database.Procedures.JobForecast.LoadByID(DbContext, JobForecastRevision.JobForecastID))

                        End If

                    End If

                End If

            Catch ex As Exception
                Revised = False
            Finally
                ReviseJobForcast = Revised
            End Try

        End Function
        Public Function ApproveJobForecastRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim Approved As Boolean = False
            Dim ApprovedJobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing

            Try

                If DbContext IsNot Nothing AndAlso JobForecastRevision IsNot Nothing Then

                    Try

                        ApprovedJobForecastRevision = (From Item In AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(DbContext, JobForecastRevision.JobForecastID)
                                                       Where Item.IsApproved = True
                                                       Select Item).FirstOrDefault

                    Catch ex As Exception
                        ApprovedJobForecastRevision = Nothing
                    End Try

                    If ApprovedJobForecastRevision IsNot Nothing Then

                        UnapproveJobForecastRevision(DbContext, ApprovedJobForecastRevision)

                    End If

                    JobForecastRevision.ApprovedDate = System.DateTime.Now
                    JobForecastRevision.ApprovedByUserCode = DbContext.UserCode
                    JobForecastRevision.IsApproved = True

                    Approved = UpdateJobForecastRevision(DbContext, JobForecastRevision)

                End If

            Catch ex As Exception
                Approved = False
            Finally
                ApproveJobForecastRevision = Approved
            End Try

        End Function
        Public Function UnapproveJobForecastRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim Unapproved As Boolean = False

            Try

                If DbContext IsNot Nothing AndAlso JobForecastRevision IsNot Nothing Then

                    JobForecastRevision.ApprovedDate = Nothing
                    JobForecastRevision.ApprovedByUserCode = Nothing
                    JobForecastRevision.IsApproved = False

                    Unapproved = UpdateJobForecastRevision(DbContext, JobForecastRevision)

                End If

            Catch ex As Exception
                Unapproved = False
            Finally
                UnapproveJobForecastRevision = Unapproved
            End Try

        End Function
        Public Function LoadAllJobComponents(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                             ByVal User As AdvantageFramework.Security.Classes.User) As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)

            'objects
            Dim AllJobComponents As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim JobComponentObjectQuery As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim UserClientDivisionProductAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

            Try

                JobComponentObjectQuery = AdvantageFramework.Database.Procedures.JobComponentView.LoadAllOpen(DbContext).ToList

                If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, User.EmployeeCode).Any Then

                    JobComponentObjectQuery = (From Item In JobComponentObjectQuery
                                               Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, User.EmployeeCode) On Item.OfficeCode Equals EmpOffice.OfficeCode
                                               Select Item).ToList

                End If

                'If Not String.IsNullOrWhiteSpace(AccountExecutiveCode) Then

                '    JobComponentObjectQuery = From Item In JobComponentObjectQuery _
                '                              Join JobComp In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext) On Item.ID Equals JobComp.ID _
                '                              Where JobComp.AccountExecutiveEmployeeCode = AccountExecutiveCode _
                '                              Select Item

                'End If

                'If String.IsNullOrWhiteSpace(ClientCode) = False Then

                '    JobComponentObjectQuery = JobComponentObjectQuery.Where(Function(JobComp) JobComp.ClientCode = ClientCode)

                'End If

                'If String.IsNullOrWhiteSpace(DivisionCode) = False Then

                '    JobComponentObjectQuery = JobComponentObjectQuery.Where(Function(JobComp) JobComp.DivisionCode = DivisionCode)

                'End If

                'If String.IsNullOrWhiteSpace(ProductCode) = False Then

                '    JobComponentObjectQuery = JobComponentObjectQuery.Where(Function(JobComp) JobComp.ProductCode = ProductCode)

                'End If

                AllJobComponents = JobComponentObjectQuery.ToList

                UserClientDivisionProductAccessList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, User.UserCode).ToList

                If UserClientDivisionProductAccessList IsNot Nothing AndAlso UserClientDivisionProductAccessList.Count > 0 Then

                    AllJobComponents = (From Item In AllJobComponents
                                        Join CDPAccess In UserClientDivisionProductAccessList On Item.ClientCode Equals CDPAccess.ClientCode And Item.DivisionCode Equals CDPAccess.DivisionCode And Item.ProductCode Equals CDPAccess.ProductCode
                                        Select Item).ToList

                End If

            Catch ex As Exception
                AllJobComponents = Nothing
            Finally
                LoadAllJobComponents = AllJobComponents
            End Try

        End Function
        Public Function LoadPostPeriodsByJobForecast(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal PostPeriodStart As String, ByVal PostPeriodEnd As String) As IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)

            'objects
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing

            Try

                If DbContext IsNot Nothing AndAlso String.IsNullOrWhiteSpace(PostPeriodStart) = False AndAlso String.IsNullOrWhiteSpace(PostPeriodEnd) = False Then

                    For Each PostPeriod In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).Where(Function(PPeriod) PPeriod.Code = PostPeriodStart OrElse PPeriod.Code = PostPeriodEnd).ToList

                        If PostPeriod.Code = PostPeriodStart Then

                            StartDate = PostPeriod.StartDate

                        End If

                        If PostPeriod.Code = PostPeriodEnd Then

                            EndDate = PostPeriod.EndDate

                        End If

                    Next

                    PostPeriods = (From Item In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                                   Where Item.StartDate >= StartDate AndAlso
                                         Item.EndDate <= EndDate
                                   Select Item).ToList

                End If

            Catch ex As Exception
                PostPeriods = Nothing
            Finally
                LoadPostPeriodsByJobForecast = PostPeriods
            End Try

        End Function
        Public Function LoadPostPeriodsByJobForecast(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal JobForecast As AdvantageFramework.Database.Entities.JobForecast) As IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)

            'objects
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

            Try

                If JobForecast IsNot Nothing Then

                    PostPeriods = LoadPostPeriodsByJobForecast(DbContext, JobForecast.PostPeriodStart, JobForecast.PostPeriodEnd)

                End If

            Catch ex As Exception
                PostPeriods = Nothing
            Finally
                LoadPostPeriodsByJobForecast = PostPeriods
            End Try

        End Function
        Public Function LoadPostPeriodsByJobForecast(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal JobForecastID As Integer) As IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)

            'objects
            Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing
            Dim PostPeriods As IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

            Try

                JobForecast = AdvantageFramework.Database.Procedures.JobForecast.LoadByID(DbContext, JobForecastID)

                If JobForecast IsNot Nothing Then

                    PostPeriods = LoadPostPeriodsByJobForecast(DbContext, JobForecast)

                End If

            Catch ex As Exception
                PostPeriods = Nothing
            Finally
                LoadPostPeriodsByJobForecast = PostPeriods
            End Try

        End Function
        Private Function CreateJobForecastEntity(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Description As String, ByVal Comment As String, ByVal PostPeriodStart As String,
                                                 ByVal PostPeriodEnd As String, ByVal Budget As Decimal?, ByVal EmployeeCode As String, ByVal OfficeCode As String, ByRef JobForecast As AdvantageFramework.Database.Entities.JobForecast) As Boolean

            'objects
            Dim Created As Boolean = False

            Try

                JobForecast = New AdvantageFramework.Database.Entities.JobForecast

                With JobForecast

                    .Description = Description

                    If String.IsNullOrWhiteSpace(Comment) Then

                        .Comment = Nothing

                    Else

                        .Comment = Comment

                    End If

                    .PostPeriodStart = PostPeriodStart
                    .PostPeriodEnd = PostPeriodEnd
                    .Budget = Budget
                    .OfficeCode = OfficeCode
                    .AssignedToEmployeeCode = EmployeeCode
                    .CreatedByUserCode = DbContext.UserCode
                    .CreatedDate = System.DateTime.Now

                End With

                Created = AdvantageFramework.Database.Procedures.JobForecast.Insert(DbContext, JobForecast)

            Catch ex As Exception
                Created = False
            Finally
                CreateJobForecastEntity = Created
            End Try

        End Function
        Private Function CreateJobForecastRevisionEntity(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastID As Integer, ByVal Comment As String,
                                                         ByRef JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision) As Boolean

            'objects
            Dim Created As Boolean = False

            Try

                JobForecastRevision = New AdvantageFramework.Database.Entities.JobForecastRevision

                With JobForecastRevision

                    .JobForecastID = JobForecastID

                    If String.IsNullOrWhiteSpace(Comment) Then

                        .Comment = Nothing

                    Else

                        .Comment = Comment

                    End If

                    .CreatedByUserCode = DbContext.UserCode
                    .CreatedDate = System.DateTime.Now

                End With

                Created = AdvantageFramework.Database.Procedures.JobForecastRevision.Insert(DbContext, JobForecastRevision)

            Catch ex As Exception
                Created = False
            Finally
                CreateJobForecastRevisionEntity = Created
            End Try

        End Function
        Private Function CreateJobForecastJobEntity(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastID As Integer, ByVal JobForecastRevisionID As Integer,
                                                    ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal Comment As String, ByVal IncomeAmount As Decimal?, ByVal Color As Integer?,
                                                    ByRef JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob) As Boolean

            'objects
            Dim Created As Boolean = False

            Try

                If (From Item In AdvantageFramework.Database.Procedures.JobForecastJob.LoadByJobForecastRevisionID(DbContext, JobForecastRevisionID)
                    Where Item.JobNumber = JobNumber AndAlso
                          Item.JobComponentNumber = JobComponentNumber
                    Select Item).Any = False Then

                    JobForecastJob = New AdvantageFramework.Database.Entities.JobForecastJob

                    With JobForecastJob

                        .JobForecastID = JobForecastID
                        .JobForecastRevisionID = JobForecastRevisionID
                        .JobNumber = JobNumber
                        .JobComponentNumber = JobComponentNumber

                        If String.IsNullOrWhiteSpace(Comment) Then

                            .Comment = Nothing

                        Else

                            .Comment = Comment

                        End If

                        .IncomeAmount = IncomeAmount
                        .Color = Color
                        .CreatedDate = System.DateTime.Now
                        .CreatedByUserCode = DbContext.UserCode

                    End With

                    Created = AdvantageFramework.Database.Procedures.JobForecastJob.Insert(DbContext, JobForecastJob)

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateJobForecastJobEntity = Created
            End Try

        End Function
        Private Function CreateJobForecastJobDetailEntity(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastID As Integer, ByVal JobForecastRevisionID As Integer, ByVal JobForecastJobID As Integer,
                                                          ByVal PostPeriod As String, ByVal BillingAmount As Decimal?, ByVal RevenueAmount As Decimal?, ByRef JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail) As Boolean

            'objects
            Dim Created As Boolean = False

            Try

                If (From Item In AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastJobID(DbContext, JobForecastJobID)
                    Where Item.PostPeriod = PostPeriod
                    Select Item).Any = False Then

                    JobForecastJobDetail = New AdvantageFramework.Database.Entities.JobForecastJobDetail

                    With JobForecastJobDetail

                        .JobForecastID = JobForecastID
                        .JobForecastRevisionID = JobForecastRevisionID
                        .JobForecastJobID = JobForecastJobID
                        .PostPeriod = PostPeriod
                        .BillingAmount = BillingAmount
                        .RevenueAmount = RevenueAmount
                        .CreatedByUserCode = DbContext.UserCode
                        .CreatedDate = System.DateTime.Now

                    End With

                    Created = AdvantageFramework.Database.Procedures.JobForecastJobDetail.Insert(DbContext, JobForecastJobDetail)

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateJobForecastJobDetailEntity = Created
            End Try

        End Function
        Public Function GetBillingPostPeriodColumnDataField(ByVal PostPeriodCode As String) As String

            Return "Billing_" & PostPeriodCode

        End Function
        Public Function GetRevenuePostPeriodColumnDataField(ByVal PostPeriodCode As String) As String

            Return "Revenue_" & PostPeriodCode

        End Function
        Public Sub GetJobForecastJobTotalBudgetAndActual(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastJobID As Integer, ByRef Budget As Decimal, ByRef Actual As Decimal, ByRef Variance As Decimal, ByRef TotalBilling As Decimal, ByRef TotalRevenue As Decimal)

            Try

                With (From Item In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.JobForecastJobDetail).Include("JobForecast")
                      Where Item.JobForecastJobID = JobForecastJobID
                      Select Item.BillingAmount,
                              Item.RevenueAmount,
                              Item.JobForecast.ForecastType).ToArray

                    TotalBilling = .Sum(Function(Item) Item.BillingAmount.GetValueOrDefault(0))
                    TotalRevenue = .Sum(Function(Item) Item.RevenueAmount.GetValueOrDefault(0))

                    If .First.ForecastType.GetValueOrDefault(0) = JobForecastTypes.Revenue Then

                        TotalBilling = Nothing
                        Budget = TotalRevenue

                    ElseIf .First.ForecastType.GetValueOrDefault(0) = JobForecastTypes.Billing Then

                        TotalRevenue = Nothing
                        Budget = TotalBilling

                    ElseIf .First.ForecastType.GetValueOrDefault(0) = JobForecastTypes.BillingAndRevenue Then

                        Budget = TotalBilling

                    End If

                End With

            Catch ex As Exception
                Budget = 0
            End Try

            Try

                Actual = 0

            Catch ex As Exception

            End Try

            Variance = Budget - Actual

        End Sub
        Public Function GetConfirmDeleteMessage(ByVal HasMultipleRevisions As Boolean) As String

            'objects
            Dim Message As String = ""

            If HasMultipleRevisions Then

                Message = "Selected job(s) will be removed from all revisions. "

            End If

            Message &= "Are you sure you want to delete the selected job(s) from the forecast?"

            Return Message

        End Function
        Public Function GetJobForecastBillingAndRevenueActuals(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision)

            'objects
            Dim JobForecastJobs As List(Of AdvantageFramework.Database.Entities.JobForecastJob) = Nothing
            Dim JobForecastActuals As List(Of AdvantageFramework.JobForecast.Classes.JobForecastActual) = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim JobForecastJobDetails As List(Of Object) = Nothing
            Dim Billing As Decimal = Nothing
            Dim Revenue As Decimal = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If JobForecastRevision IsNot Nothing Then

                        If True Then

                            With AdvantageFramework.Database.Procedures.JobForecastJob.LoadByJobForecastRevisionID(DbContext, JobForecastRevision.ID)

                                If .Count() > 0 Then

                                    JobForecastJobs = .ToList

                                End If

                            End With

                        Else

                            JobForecastJobs = AdvantageFramework.Database.Procedures.JobForecastJob.LoadByJobForecastRevisionID(DbContext, JobForecastRevision.ID).ToList

                        End If

                        If JobForecastJobs IsNot Nothing AndAlso JobForecastJobs.Count > 0 Then

                            JobForecastActuals = LoadBillingAndActualData(DbContext, JobForecastRevision.ID)

                            For Each JobForecastJob In JobForecastJobs

                                With (From Item In JobForecastActuals
                                      Where Item.JobNumber = JobForecastJob.JobNumber AndAlso
                                            Item.ComponentNumber = JobForecastJob.JobComponentNumber
                                      Select Item).ToList

                                    Billing = .Sum(Function(Itm) Itm.ActualBillableAmount)
                                    Revenue = .Sum(Function(Itm) If({"E", "I"}.Contains(Itm.FunctionType), Itm.ActualBillableAmount.GetValueOrDefault(0), If({"V"}.Contains(Itm.FunctionType), Itm.ActualBillableMarkupAmount, 0)))

                                End With

                            Next

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

            Return False

        End Function
        Public Function LoadBillingAndActualData(ByVal DbContext As AdvantageFramework.Database.DbContext, Optional ByVal JobForecastRevisionID As Integer = 0) As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastActual)

            Dim JobForecastActuals As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastActual) = Nothing

            Try

                JobForecastActuals = DbContext.Database.SqlQuery(Of AdvantageFramework.JobForecast.Classes.JobForecastActual)(String.Format("EXEC [dbo].[advsp_job_forecast_actuals] {0}", JobForecastRevisionID)).ToList

            Catch ex As Exception
                JobForecastActuals = Nothing
            Finally
                LoadBillingAndActualData = JobForecastActuals
            End Try

        End Function
        Public Function CalculateActualBilling(ByVal JobForecastActuals As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastActual),
                                                ByVal PostPeriod As AdvantageFramework.Database.Entities.PostPeriod, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Decimal

            'objects
            Dim ActualBilling As Decimal = Nothing

            Try

                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    JobForecastActuals = JobForecastActuals.Where(Function(item) item.JobNumber = JobNumber AndAlso item.ComponentNumber = JobComponentNumber).ToList

                End If

                'income only & employee time records & vendor records
                ActualBilling = (From Item In JobForecastActuals
                                 Where Item.ItemDate.GetValueOrDefault() <= If(PostPeriod IsNot Nothing, PostPeriod.EndDate, Item.ItemDate.GetValueOrDefault()) AndAlso
                                       Item.ItemDate.GetValueOrDefault() >= If(PostPeriod IsNot Nothing, PostPeriod.StartDate, Item.ItemDate.GetValueOrDefault()) AndAlso
                                       (Item.FunctionType = "I" OrElse Item.FunctionType = "E" OrElse Item.FunctionType = "V")
                                 Select Item.ActualBillableAmount.GetValueOrDefault(0)).Sum()

            Catch ex As Exception
                ActualBilling = 0
            Finally
                CalculateActualBilling = ActualBilling
            End Try

        End Function
        Public Function CalculateActualRevenue(ByVal JobForecastActuals As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastActual),
                                                ByVal PostPeriod As AdvantageFramework.Database.Entities.PostPeriod, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Decimal

            'objects
            Dim ActualRevenue As Decimal = Nothing

            Try

                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    JobForecastActuals = JobForecastActuals.Where(Function(item) item.JobNumber = JobNumber AndAlso item.ComponentNumber = JobComponentNumber).ToList

                End If

                'income only & employee time records & vendor records
                ActualRevenue = (From Item In JobForecastActuals
                                 Where Item.ItemDate.GetValueOrDefault() <= If(PostPeriod IsNot Nothing, PostPeriod.EndDate, Item.ItemDate.GetValueOrDefault()) AndAlso
                                       Item.ItemDate.GetValueOrDefault() >= If(PostPeriod IsNot Nothing, PostPeriod.StartDate, Item.ItemDate.GetValueOrDefault()) AndAlso
                                       (Item.FunctionType = "I" OrElse Item.FunctionType = "E" OrElse Item.FunctionType = "V")
                                 Select Item.ActualRevenueAmount.GetValueOrDefault(0)).Sum()

            Catch ex As Exception
                ActualRevenue = 0
            Finally
                CalculateActualRevenue = ActualRevenue
            End Try

        End Function
        Public Function ActualizeJobForecast(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal JobForecastRevisionID As Integer,
                                             ByVal PostPeriodCutoff As String, ByVal RollForwardBalance As Boolean, ByVal RollForwardToNextMonthOnly As Boolean,
                                             Optional ByVal JobForecastJobs As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJob) = Nothing) As Boolean

            Dim Actualized As Boolean = False
            Dim RevisionIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ForecastJobListSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim RollFowardBalanceSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim RollFowardNextMonthOnlySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim PostPeriodCutoffSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            Try

                RevisionIDSqlParameter = New System.Data.SqlClient.SqlParameter("@RevisionID", System.Data.SqlDbType.Int) With {.Value = JobForecastRevisionID}
                ForecastJobListSqlParameter = New System.Data.SqlClient.SqlParameter("@ForecastJobList", System.Data.SqlDbType.VarChar) With {.Value = System.DBNull.Value}
                RollFowardBalanceSqlParameter = New System.Data.SqlClient.SqlParameter("@RollFowardBalance", System.Data.SqlDbType.Bit) With {.Value = RollForwardBalance}
                RollFowardNextMonthOnlySqlParameter = New System.Data.SqlClient.SqlParameter("@RollFowardBalanceNextMonthOnly", System.Data.SqlDbType.Bit) With {.Value = RollForwardToNextMonthOnly}
                PostPeriodCutoffSqlParameter = New System.Data.SqlClient.SqlParameter("@PostPeriodCutoff", System.Data.SqlDbType.VarChar) With {.Value = PostPeriodCutoff}
                UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", System.Data.SqlDbType.VarChar) With {.Value = DbContext.UserCode}

                If JobForecastJobs IsNot Nothing AndAlso JobForecastJobs.Count > 0 Then

                    ForecastJobListSqlParameter.Value = String.Join(",", JobForecastJobs.Where(Function(item) item.JobForecastRevisionID = JobForecastRevisionID).Select(Function(item) item.ID).ToArray)

                End If

                DbContext.Database.ExecuteSqlCommand("exec [dbo].[advsp_job_forecast_actualize] @RevisionID, @ForecastJobList, @RollFowardBalance, @RollFowardBalanceNextMonthOnly, @PostPeriodCutoff, @UserCode",
                                                     RevisionIDSqlParameter, ForecastJobListSqlParameter, RollFowardBalanceSqlParameter, RollFowardNextMonthOnlySqlParameter, PostPeriodCutoffSqlParameter, UserCodeSqlParameter)

                Actualized = True

            Catch ex As Exception
                Actualized = False
            Finally
                ActualizeJobForecast = Actualized
            End Try

        End Function
        Public Function GetJobForecastExcelReport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastRevisionID As Integer) As String

            'objects
            Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing
            Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
            Dim JobForecastJobDetails As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJobDetail) = Nothing
            Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing
            Dim JobForecastJobs As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJob) = Nothing
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim JobComponentViews As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim Tab As String = "\t"
            Dim ForecastType As JobForecastTypes = JobForecastTypes.Billing
            Dim BillingAmount As Decimal? = Nothing
            Dim RevenueAmount As Decimal? = Nothing

            Try

                If DbContext IsNot Nothing Then

                    JobForecastRevision = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, JobForecastRevisionID)

                    If JobForecastRevision IsNot Nothing Then

                        ForecastType = JobForecastRevision.JobForecast.ForecastType.GetValueOrDefault(0)

                        PostPeriods = LoadPostPeriodsByJobForecast(DbContext, JobForecastRevision.JobForecast)
                        JobForecastJobDetails = AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastRevisionID(DbContext, JobForecastRevision.ID).ToList
                        JobForecastJobs = AdvantageFramework.Database.Procedures.JobForecastJob.LoadByJobForecastRevisionID(DbContext, JobForecastRevision.ID).ToList

                        JobComponentViews = (From Item In AdvantageFramework.Database.Procedures.JobComponentView.LoadAllOpen(DbContext).ToList
                                             Join JFJob In JobForecastJobs On Item.JobNumber Equals JFJob.JobNumber And Item.JobComponentNumber Equals JFJob.JobComponentNumber
                                             Select Item).ToList

                        StringBuilder = New Text.StringBuilder

                        Dim JobInfoHeaderRowSpan As Short = 0
                        Dim PostPerioHeaderColSpan As Short = 0
                        Dim PostPeriodHeaderRow1ColSpanMultiplier As Short = 0
                        Dim PostPeriodHeaderRow1AdditionalText As String = ""
                        Dim PostPeriodHeaderRow1ColSpan As Short = 0

                        Select Case ForecastType

                            Case JobForecastTypes.Billing

                                JobInfoHeaderRowSpan = 2
                                PostPeriodHeaderRow1ColSpanMultiplier = 1
                                PostPeriodHeaderRow1AdditionalText = " Billing"

                            Case JobForecastTypes.Revenue

                                JobInfoHeaderRowSpan = 2
                                PostPeriodHeaderRow1ColSpanMultiplier = 1
                                PostPeriodHeaderRow1AdditionalText = " Revenue"

                            Case JobForecastTypes.BillingAndRevenue

                                JobInfoHeaderRowSpan = 3
                                PostPeriodHeaderRow1ColSpanMultiplier = 2
                                PostPeriodHeaderRow1AdditionalText = ""

                        End Select

                        StringBuilder.AppendLine("<table>")
                        StringBuilder.AppendLine(Tab & "<tr>")
                        ' header row
                        StringBuilder.AppendLine(Tab & Tab & "<td rowspan='" & JobInfoHeaderRowSpan & "'>Job/Component</td>")
                        StringBuilder.AppendLine(Tab & Tab & "<td rowspan='" & JobInfoHeaderRowSpan & "'>Comments</td>")
                        StringBuilder.AppendLine(Tab & Tab & "<td rowspan='" & JobInfoHeaderRowSpan & "'>Forecast</td>")
                        StringBuilder.AppendLine(Tab & Tab & "<td rowspan='" & JobInfoHeaderRowSpan & "'>Actual</td>")
                        StringBuilder.AppendLine(Tab & Tab & "<td rowspan='" & JobInfoHeaderRowSpan & "'>Variance</td>")

                        For Each PostPeriodYear In PostPeriods.Select(Function(item) item.Year).Distinct

                            PostPeriodHeaderRow1ColSpan = PostPeriods.Where(Function(item) item.Year = PostPeriodYear).Count * PostPeriodHeaderRow1ColSpanMultiplier

                            StringBuilder.AppendLine(Tab & Tab & "<td colspan='" & PostPeriodHeaderRow1ColSpan & "'>" & PostPeriodYear & PostPeriodHeaderRow1AdditionalText & "</td>")

                        Next

                        StringBuilder.AppendLine(Tab & "</tr>")

                        ' header row 2
                        StringBuilder.AppendLine(Tab & "<tr>")

                        For Each PostPeriod In PostPeriods

                            StringBuilder.AppendLine(Tab & Tab & "<td colspan='" & PostPeriodHeaderRow1ColSpanMultiplier & "'>" & [Enum].GetName(GetType(AdvantageFramework.DateUtilities.Months), CInt(PostPeriod.Month.GetValueOrDefault(0))) & "</td>")

                        Next

                        StringBuilder.AppendLine(Tab & "</tr>")

                        'header row 3 if billing & revenue
                        If ForecastType = JobForecastTypes.BillingAndRevenue Then

                            StringBuilder.AppendLine(Tab & "<tr>")

                            For Each PostPeriod In PostPeriods

                                StringBuilder.AppendLine(Tab & Tab & "<td>Billing</td>")
                                StringBuilder.AppendLine(Tab & Tab & "<td>Revenue</td>")

                            Next

                            StringBuilder.AppendLine(Tab & "</tr>")

                        End If

                        For Each Client In JobComponentViews.Select(Function(item) New With {.Code = item.ClientCode, .Name = item.ClientName}).Distinct

                            StringBuilder.AppendLine(Tab & "<tr>")
                            StringBuilder.AppendLine(Tab & Tab & "<td colspan='" & (5 + (PostPeriods.Count() * PostPeriodHeaderRow1ColSpanMultiplier)) & "'>" & Client.Name & "</td>")
                            StringBuilder.AppendLine(Tab & "</tr>")

                            For Each JobForecastJob In JobForecastJobs.Where(Function(item) JobComponentViews.Where(Function(jc) jc.ClientCode = Client.Code AndAlso jc.JobNumber = item.JobNumber).Any = True).ToList

                                StringBuilder.AppendLine(Tab & "<tr>")
                                StringBuilder.AppendLine(Tab & Tab & "<td>" & JobComponentViews.First(Function(jc) jc.JobNumber = JobForecastJob.JobNumber AndAlso jc.JobComponentNumber = JobForecastJob.JobComponentNumber).ToString(True, True) & "</td>")
                                StringBuilder.AppendLine(Tab & Tab & "<td>" & JobForecastJob.Comment & "</td>")
                                StringBuilder.AppendLine(Tab & Tab & "<td>--FORECAST--</td>")
                                StringBuilder.AppendLine(Tab & Tab & "<td>--ACTUAL--</td>")
                                StringBuilder.AppendLine(Tab & Tab & "<td>--VARIANCE--</td>")

                                For Each PostPeriod In PostPeriods

                                    JobForecastJobDetail = JobForecastJobDetails.FirstOrDefault(Function(item) item.JobForecastJobID = JobForecastJob.ID AndAlso item.PostPeriod = PostPeriod.Code)

                                    If JobForecastJobDetail IsNot Nothing Then

                                        BillingAmount = JobForecastJobDetail.BillingAmount
                                        RevenueAmount = JobForecastJobDetail.RevenueAmount

                                    Else

                                        BillingAmount = Nothing
                                        RevenueAmount = Nothing

                                    End If

                                    If ForecastType = JobForecastTypes.BillingAndRevenue Then

                                        StringBuilder.AppendLine(Tab & Tab & "<td>" & BillingAmount & "</td>")
                                        StringBuilder.AppendLine(Tab & Tab & "<td>" & RevenueAmount & "</td>")

                                    ElseIf ForecastType = JobForecastTypes.Billing Then

                                        StringBuilder.AppendLine(Tab & Tab & "<td>" & BillingAmount & "</td>")

                                    ElseIf ForecastType = JobForecastTypes.Revenue Then

                                        StringBuilder.AppendLine(Tab & Tab & "<td>" & RevenueAmount & "</td>")

                                    End If

                                Next

                                StringBuilder.AppendLine(Tab & "</tr>")

                            Next

                        Next

                        StringBuilder.AppendLine("</table>")

                    End If

                End If

            Catch ex As Exception

            Finally

            End Try

            Return StringBuilder.ToString

        End Function
        Public Function AllocateJobForecastJobs(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AllocateJobComponents As Generic.List(Of AdvantageFramework.JobForecast.Classes.AllocateJobComponent)) As Boolean

            'objects
            Dim Allocated As Boolean = False
            Dim RevisionIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobForecastJobIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim BillingAmountSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim RevenueAmountSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            Try

                For Each AllocateJobComponent In AllocateJobComponents.Where(Function(Item) Item.BillingAmountToAllocate.HasValue OrElse Item.RevenueAmountToAllocate.HasValue).ToList

                    RevisionIDSqlParameter = New System.Data.SqlClient.SqlParameter("RevisionID", SqlDbType.Int) With {.Value = AllocateJobComponent.JobForecastRevisionID}
                    JobForecastJobIDSqlParameter = New System.Data.SqlClient.SqlParameter("ForecastJobID", SqlDbType.Int) With {.Value = AllocateJobComponent.JobForecastJobID}
                    UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("UserCode", SqlDbType.VarChar) With {.Value = DbContext.UserCode}
                    BillingAmountSqlParameter = New System.Data.SqlClient.SqlParameter("BillingAllocationAmount", SqlDbType.Decimal) With {.Value = System.DBNull.Value}
                    RevenueAmountSqlParameter = New System.Data.SqlClient.SqlParameter("RevenueAllocationAmount", SqlDbType.Decimal) With {.Value = System.DBNull.Value}

                    If AllocateJobComponent.BillingAmountToAllocate.HasValue AndAlso AllocateJobComponent.BillingAmountToAllocate.Value >= 0 Then

                        BillingAmountSqlParameter.Value = AllocateJobComponent.BillingAmountToAllocate

                    End If

                    If AllocateJobComponent.RevenueAmountToAllocate.HasValue AndAlso AllocateJobComponent.RevenueAmountToAllocate.Value >= 0 Then

                        RevenueAmountSqlParameter.Value = AllocateJobComponent.RevenueAmountToAllocate

                    End If

                    DbContext.Database.ExecuteSqlCommand("exec [dbo].[advsp_job_forecast_allocate] @RevisionID, @ForecastJobID, @BillingAllocationAmount, @RevenueAllocationAmount, @UserCode",
                                                         RevisionIDSqlParameter, JobForecastJobIDSqlParameter, BillingAmountSqlParameter, RevenueAmountSqlParameter, UserCodeSqlParameter)

                Next

                Allocated = True

            Catch ex As Exception
                Allocated = False
            Finally
                AllocateJobForecastJobs = Allocated
            End Try

        End Function
        Public Function LoadJobForecastJobsSummary(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RevisionID As Integer) As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastJobSummary)

            'objects
            Dim RevisionIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            Try

                RevisionIDSqlParameter = New System.Data.SqlClient.SqlParameter("RevisionID", SqlDbType.Int) With {.Value = RevisionID}

                LoadJobForecastJobsSummary = DbContext.Database.SqlQuery(Of AdvantageFramework.JobForecast.Classes.JobForecastJobSummary)("exec [dbo].[advsp_job_forecast_job_summary] @RevisionID ", RevisionIDSqlParameter).ToList

            Catch ex As Exception
                LoadJobForecastJobsSummary = Nothing
            End Try

        End Function
        Public Function LoadFiscalStartMonth(ByVal DbContext As AdvantageFramework.Database.DbContext) As Short

            'objects
            Dim FiscalStartMonth As Short = 0

            Try

                FiscalStartMonth = DbContext.Database.SqlQuery(Of Short)("SELECT TOP 1 [FISCALMTH] FROM [dbo].[GLCONFIG]").FirstOrDefault()

            Catch ex As Exception
                FiscalStartMonth = 1
            Finally

                If FiscalStartMonth = 0 Then

                    FiscalStartMonth = 1

                End If

                LoadFiscalStartMonth = FiscalStartMonth

            End Try

        End Function

#End Region

    End Module

End Namespace