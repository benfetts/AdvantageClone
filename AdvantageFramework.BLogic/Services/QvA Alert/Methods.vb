Namespace Services.QvAAlert

	<HideModuleName()>
	Public Module Methods

		Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum ShowLevel
			JobOnly = 0
			JobAndFunctions = 1
		End Enum

		Public Enum SetAlertLevel
			JobTotalOnly = 0
			JobOrFunction = 1
		End Enum

		Public Enum SendAlertTo
			AccountExecutiveOnJob = 0
			DefaultAccountExecutiveForCDP = 1
			DefaultAlertGroup = 2
			'AssignedStaff = 3
		End Enum

		Public Enum RegistrySetting
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "RunAt", "01/01/2001 01:00 AM")>
			RunAt
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "SendAlertTo", "0")>
			SendAlertTo
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel1Enabled", "FALSE")>
			ThresholdLevel1Enabled
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel1Start", "0")>
			ThresholdLevel1Start
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel1End", "0")>
			ThresholdLevel1End
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel1Description", "")>
			ThresholdLevel1Description
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel2Enabled", "FALSE")>
			ThresholdLevel2Enabled
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel2Start", "0")>
			ThresholdLevel2Start
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel2End", "0")>
			ThresholdLevel2End
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel2Description", "")>
			ThresholdLevel2Description
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel3Enabled", "FALSE")>
			ThresholdLevel3Enabled
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel3Start", "0")>
			ThresholdLevel3Start
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ThresholdLevel3Description", "")>
			ThresholdLevel3Description
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "Calculation_Time", "TRUE")>
			Calculation_Time
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "Calculation_IncomeOnly", "TRUE")>
			Calculation_IncomeOnly
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "Calculation_VendorCharges", "TRUE")>
			Calculation_VendorCharges
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "Calculation_IncludeResaleTaxAmount", "FALSE")>
			Calculation_IncludeEstimate
			<AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "SetAlertLevel", "1")>
			SetAlertLevel
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "ShowLevel", "1")>
            ShowLevel
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "Calculation_IncludeNonBillableTime", "FALSE")>
            Calculation_IncludeNonBillableTime
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\QvA Alert\", "Calculation_IncludeTimeMarkedFeeTime", "FALSE")>
            Calculation_IncludeTimeMarkedFeeTime
        End Enum

		Public Enum CustomCommand As Integer
			LoadSettings = 128
		End Enum

#End Region

#Region " Variables "

        Private WithEvents _EventLog As System.Diagnostics.EventLog = Nothing
        Private _CheckAllFunctions As Boolean = True

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadJobDetailAnalysis(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext) As Generic.List(Of AdvantageFramework.Services.QvAAlert.Classes.JobDetailAnalysis)

            LoadJobDetailAnalysis = DbContext.Database.SqlQuery(Of AdvantageFramework.Services.QvAAlert.Classes.JobDetailAnalysis)("EXEC advsp_job_detail_analysis_qva_service_load").ToList

        End Function
        Private Sub CalculateQvAByJobNumber(ByVal DbContext As AdvantageFramework.Database.DbContext,
											ByVal JobDetailAnalysisList As Generic.List(Of AdvantageFramework.Services.QvAAlert.Classes.JobDetailAnalysis),
											ByVal SendAlertTo As AdvantageFramework.Services.QvAAlert.SendAlertTo,
											ByVal SetAlertLevel As AdvantageFramework.Services.QvAAlert.SetAlertLevel,
											ByVal ShowLevel As AdvantageFramework.Services.QvAAlert.ShowLevel,
											ByVal ThresholdLevel1Enabled As Boolean, ByVal ThresholdLevel1Start As Decimal, ByVal ThresholdLevel1End As Decimal,
											ByVal ThresholdLevel2Enabled As Boolean, ByVal ThresholdLevel2Start As Decimal, ByVal ThresholdLevel2End As Decimal,
											ByVal ThresholdLevel3Enabled As Boolean, ByVal ThresholdLevel3Start As Decimal,
											ByVal CalculationTime As Boolean, ByVal CalculationIncomeOnly As Boolean,
											ByVal CalculationVendorCharges As Boolean, ByVal CalculationIncludeEstimate As Boolean,
											ByRef QvAJob As QvAAlert.Classes.QvAJob)

			'objects
			Dim QvAFunction As QvAAlert.Classes.QvAFunction = Nothing
			Dim JobNumber As Integer = 0
			Dim JobComponentNumber As Integer = 0
			Dim JobFunctionCode As String = ""
			Dim QvA As Decimal = 0
			Dim Message As String = ""
			Dim AddFunction As Boolean = False
			Dim DistinctFunctionCodesList As Generic.List(Of String) = Nothing
			Dim JobFunctionDetail As AdvantageFramework.Services.QvAAlert.Classes.JobDetailAnalysis = Nothing
			Dim DistinctFunctionCode As String = ""

			Try

				JobNumber = QvAJob.JobNumber
				JobComponentNumber = QvAJob.ComponentNumber

				DistinctFunctionCodesList = (From JobDetail In JobDetailAnalysisList
											 Where JobDetail.JobNumber = JobNumber AndAlso
												   JobDetail.JobComponentNumber = JobComponentNumber
											 Select JobDetail.FunctionCode).Distinct().ToList

				For Each DistinctFunctionCode In DistinctFunctionCodesList

					JobFunctionDetail = (From JobDetail In JobDetailAnalysisList
										 Where JobDetail.JobNumber = JobNumber AndAlso
											   JobDetail.JobComponentNumber = JobComponentNumber AndAlso
											   JobDetail.FunctionCode = DistinctFunctionCode
										 Select JobDetail
										 Order By JobDetail.FunctionTypeOrder, JobDetail.FunctionType, JobDetail.FunctionCode).FirstOrDefault()

					AddFunction = False

					Select Case JobFunctionDetail.FunctionType

						Case AdvantageFramework.Database.Entities.FunctionTypes.E.ToString

							If CalculationTime Then

								AddFunction = True

							End If

						Case AdvantageFramework.Database.Entities.FunctionTypes.I.ToString

							If CalculationIncomeOnly Then

								AddFunction = True

							End If

						Case AdvantageFramework.Database.Entities.FunctionTypes.V.ToString

							If CalculationVendorCharges Then

								AddFunction = True

							End If

					End Select

					If AddFunction Then

						QvAFunction = GetActualandQuotedValues(DbContext,
															   JobDetailAnalysisList,
															   JobNumber, JobComponentNumber,
															   JobFunctionDetail,
															   ThresholdLevel1Enabled, ThresholdLevel1Start, ThresholdLevel1End,
															   ThresholdLevel2Enabled, ThresholdLevel2Start, ThresholdLevel2End,
															   ThresholdLevel3Enabled, ThresholdLevel3Start,
															   CalculationIncludeEstimate)

						QvAJob.AddFunction(QvAFunction)

						QvAJob.Quoted += QvAFunction.Quoted
						QvAJob.Actual += QvAFunction.Actual

						QvAJob.JobDescription = JobFunctionDetail.JobDescription

						QvAJob.ComponentDescription = JobFunctionDetail.ComponentDescription
						QvAJob.ClientCode = JobFunctionDetail.ClientCode
						QvAJob.DivisionCode = JobFunctionDetail.DivisionCode
						QvAJob.ProductCode = JobFunctionDetail.ProductCode
						QvAJob.ClientName = JobFunctionDetail.ClientDescription

					End If

				Next

				'message = "Total Quote for Job Number: " & JobNumber & " | Component Number: " & JobComponentNumber & " = (" & FormatCurrency(One_QvAJob.Quoted) & ")"
				'Console.WriteLine(message)
				'WriteToEventLog(message)

				'message = "Total Actual for Job Number: " & JobNumber & " | Component Number: " & JobComponentNumber & " = (" & FormatCurrency(One_QvAJob.Actual) & ")"
				'Console.WriteLine(message)
				'WriteToEventLog(message)

				QvAJob.ThresholdAlert = CheckThresholds(QvAJob.Quoted, QvAJob.Actual, QvAJob.QvA,
															ThresholdLevel1Enabled, ThresholdLevel1Start, ThresholdLevel1End,
															ThresholdLevel2Enabled, ThresholdLevel2Start, ThresholdLevel2End,
															ThresholdLevel3Enabled, ThresholdLevel3Start)

				Message = "QvA for Job Number: " & JobNumber & " | Component Number: " & JobComponentNumber & " = (" & QvAJob.QvA & ") - Threshold Level = " & QvAJob.ThresholdAlert.ToString()
				'Console.WriteLine(message)
				'Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------")
				WriteToEventLog(Message)

			Catch ex As Exception

				Throw New Exception("CalculateQvAByJobNumber Error", ex)

			End Try

		End Sub
		Private Function GetActualandQuotedValues(ByVal DbContext As AdvantageFramework.Database.DbContext,
												  ByVal JobDetailAnalysisList As Generic.List(Of AdvantageFramework.Services.QvAAlert.Classes.JobDetailAnalysis),
												  ByVal JobNumber As Integer, ByVal ComponentNumber As Integer,
												  ByVal JobFunctionDetail As AdvantageFramework.Services.QvAAlert.Classes.JobDetailAnalysis,
												  ByVal ThresholdLevel1Enabled As Boolean, ByVal ThresholdLevel1Start As Decimal, ByVal ThresholdLevel1End As Decimal,
												  ByVal ThresholdLevel2Enabled As Boolean, ByVal ThresholdLevel2Start As Decimal, ByVal ThresholdLevel2End As Decimal,
												  ByVal ThresholdLevel3Enabled As Boolean, ByVal ThresholdLevel3Start As Decimal,
												  ByVal CalculationIncludeEstimate As Boolean) As QvAAlert.Classes.QvAFunction

			'objects
			Dim QvAFunction As QvAAlert.Classes.QvAFunction = Nothing
			Dim QvA As Decimal = 0
			Dim TestFunctionCode As String = ""
			Dim TestFunctionTypeCode As String = ""
			Dim TotalQuotedValue As Decimal = 0D
			Dim QuotedValue As Decimal = 0D
			Dim ContValue As Decimal = 0D
			Dim TotalActualValue As Decimal = 0D
			Dim ActualValue As Decimal = 0D
			Dim TaxValue As Decimal = 0D

			Try

				QvAFunction = New QvAAlert.Classes.QvAFunction()

				TestFunctionCode = JobFunctionDetail.FunctionCode
				TestFunctionTypeCode = JobFunctionDetail.FunctionType

				QvAFunction.FunctionCode = TestFunctionCode
				QvAFunction.FunctionTypeCode = TestFunctionTypeCode
				QvAFunction.FunctionOrderCode = JobFunctionDetail.FunctionTypeOrder
				QvAFunction.FunctionDescription = JobFunctionDetail.FunctionDescription

				QuotedValue = (From JobDetailAnalysis In JobDetailAnalysisList
							   Where JobDetailAnalysis.JobNumber = JobNumber AndAlso
									 JobDetailAnalysis.JobComponentNumber = ComponentNumber AndAlso
									 JobDetailAnalysis.FunctionCode = TestFunctionCode
							   Select JobDetailAnalysis.SumOfEstimate).Sum()

				TaxValue = (From JobDetailAnalysis In JobDetailAnalysisList
							Where JobDetailAnalysis.JobNumber = JobNumber AndAlso
								  JobDetailAnalysis.JobComponentNumber = ComponentNumber AndAlso
								  JobDetailAnalysis.FunctionCode = TestFunctionCode
							Select JobDetailAnalysis.SumOfEstimateResaleTax).Sum()

				If Not CalculationIncludeEstimate Then

					ContValue = (From JobDetailAnalysis In JobDetailAnalysisList
								 Where JobDetailAnalysis.JobNumber = JobNumber AndAlso
									   JobDetailAnalysis.JobComponentNumber = ComponentNumber AndAlso
									   JobDetailAnalysis.FunctionCode = TestFunctionCode
								 Select JobDetailAnalysis.SumOfEstimateCont).Sum()

				End If

				TotalQuotedValue = QuotedValue - ContValue - TaxValue

				ActualValue = (From JobDetailAnalysis In JobDetailAnalysisList
							   Where JobDetailAnalysis.JobNumber = JobNumber AndAlso
									   JobDetailAnalysis.JobComponentNumber = ComponentNumber AndAlso
									   JobDetailAnalysis.FunctionCode = TestFunctionCode
							   Select JobDetailAnalysis.SumOfLineTotal).Sum()

				TaxValue = (From JobDetailAnalysis In JobDetailAnalysisList
							Where JobDetailAnalysis.JobNumber = JobNumber AndAlso
									   JobDetailAnalysis.JobComponentNumber = ComponentNumber AndAlso
									   JobDetailAnalysis.FunctionCode = TestFunctionCode
							Select JobDetailAnalysis.SumOfResaleTax).Sum()

				TotalActualValue = ActualValue - TaxValue

				QvAFunction.Quoted = TotalQuotedValue
				QvAFunction.Actual = TotalActualValue

				'Message = "Quote for Job Number: " & JobNumber & " | Component Number: " & ComponentNumber & " | Function Code: " & FunctionCode & " | Function Type: " & FunctionTypeCode & " = (" & FormatCurrency(RetVal_QvAFunction.Quoted) & ")"
				'Console.WriteLine(Message)
				'WriteToEventLog(Message)

				'Message = "Actual for Job Number: " & JobNumber & " | Component Number: " & ComponentNumber & " | Function Code: " & FunctionCode & " | Function Type: " & FunctionTypeCode & " = (" & FormatCurrency(RetVal_QvAFunction.Actual) & ")"
				'Console.WriteLine(Message)
				'WriteToEventLog(Message)

				QvAFunction.ThresholdAlert = CheckThresholds(QvAFunction.Quoted, QvAFunction.Actual, QvAFunction.QvA,
																	  ThresholdLevel1Enabled, ThresholdLevel1Start, ThresholdLevel1End,
																	  ThresholdLevel2Enabled, ThresholdLevel2Start, ThresholdLevel2End,
																	  ThresholdLevel3Enabled, ThresholdLevel3Start)

				'Message = "QvA for Job Number: " & JobNumber & " | Component Number: " & ComponentNumber & " | Function Code: " & FunctionCode & " | Function Type: " & FunctionTypeCode & " = (" & RetVal_QvAFunction.QvA & ") - Threshold Level = " & RetVal_QvAFunction.ThresholdAlert.ToString()
				'Console.WriteLine(Message)
				'WriteToEventLog(Message)

			Catch ex As Exception
				Throw New Exception("GetActualandQuotedValues Error", ex)
			End Try

			GetActualandQuotedValues = QvAFunction

		End Function
		Private Sub SendAlerts(ByVal DbContext As AdvantageFramework.Database.DbContext,
							   ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
							   ByVal DatabaseProfileName As String,
							   ByVal SendAlertTo As AdvantageFramework.Services.QvAAlert.SendAlertTo,
							   ByVal SetAlertLevel As AdvantageFramework.Services.QvAAlert.SetAlertLevel,
							   ByVal ShowLevel As AdvantageFramework.Services.QvAAlert.ShowLevel,
							   ByVal ThresholdLevel1Enabled As Boolean, ByVal ThresholdLevel1Start As Decimal, ByVal ThresholdLevel1End As Decimal, ByVal ThresholdLevel1Description As String,
							   ByVal ThresholdLevel2Enabled As Boolean, ByVal ThresholdLevel2Start As Decimal, ByVal ThresholdLevel2End As Decimal, ByVal ThresholdLevel2Description As String,
							   ByVal ThresholdLevel3Enabled As Boolean, ByVal ThresholdLevel3Start As Decimal, ByVal ThresholdLevel3Description As String,
							   ByRef JobsList As List(Of QvAAlert.Classes.QvAJob))

			'objects
			Dim NewJobsList As List(Of QvAAlert.Classes.QvAJob) = Nothing

			Try

				If JobsList IsNot Nothing Then

					If ThresholdLevel1Enabled Then

						If ThresholdLevel1Start >= 0 AndAlso ThresholdLevel1End >= 0 AndAlso ThresholdLevel1Start <= ThresholdLevel1End Then

							NewJobsList = CreateAlertJobList(1, SetAlertLevel, JobsList)

							SendAlertOneLevel(DbContext, SecurityDbContext, DatabaseProfileName,
											  SendAlertTo, 1,
											  ThresholdLevel1Start, ThresholdLevel1End, ThresholdLevel1Description,
											  ShowLevel, NewJobsList)
						End If

					End If

					If ThresholdLevel2Enabled Then

						If ThresholdLevel1Start >= 0 AndAlso ThresholdLevel1End >= 0 AndAlso ThresholdLevel1Start <= ThresholdLevel1End Then

							NewJobsList = CreateAlertJobList(2, SetAlertLevel, JobsList)

							SendAlertOneLevel(DbContext, SecurityDbContext, DatabaseProfileName,
											  SendAlertTo, 2,
											  ThresholdLevel2Start, ThresholdLevel2End, ThresholdLevel2Description,
											  ShowLevel, NewJobsList)

						End If

					End If

					If ThresholdLevel3Enabled Then

						If ThresholdLevel3Start >= 0 Then

							NewJobsList = CreateAlertJobList(3, SetAlertLevel, JobsList)

							SendAlertOneLevel(DbContext, SecurityDbContext, DatabaseProfileName,
											  SendAlertTo, 3,
											  ThresholdLevel3Start, 0D, ThresholdLevel3Description,
											  ShowLevel, NewJobsList)

						End If

					End If

					FreeJobsList(JobsList)

				End If

			Catch ex As Exception
				Throw New Exception("Send Alerts Error", ex)
			End Try

		End Sub
		Private Sub SendAlertOneLevel(ByVal DbContext As AdvantageFramework.Database.DbContext,
									  ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
									  ByVal DatabaseProfileName As String,
									  ByVal SendAlertTo As AdvantageFramework.Services.QvAAlert.SendAlertTo,
									  ByVal ThresholdLevel As Integer,
									  ByVal ThresholdLevelStart As Decimal,
									  ByVal ThresholdLevelEnd As Decimal,
									  ByVal ThresholdLevelDescription As String,
									  ByVal ShowLevel As AdvantageFramework.Services.QvAAlert.ShowLevel,
									  ByRef JobsList As List(Of QvAAlert.Classes.QvAJob))

			'objects
			Dim QueryString As String = ""
			Dim SelectString As String = ""
			Dim WhereString As String = ""
			Dim OrderString As String = ""
			Dim EmployeeCode As String = ""
			Dim EmployeeCodeList As List(Of String) = Nothing
			Dim QvASendAlerts As QvAAlert.Classes.QvASendAlerts = Nothing
			Dim Message As String = ""
			Dim TryAgain As Boolean = False

			If JobsList IsNot Nothing Then

				Try

					QvASendAlerts = New QvAAlert.Classes.QvASendAlerts()

					Message = "Alert Level " + ThresholdLevel.ToString() + " - Sending alerts for " + JobsList.Count.ToString() + " jobs --> " + DatabaseProfileName
					Console.WriteLine(Message)
					WriteToEventLog(Message)

					For Each Job In JobsList

						Select Case SendAlertTo

							Case AdvantageFramework.Services.QvAAlert.SendAlertTo.AccountExecutiveOnJob

								QueryString = "SELECT EMP_CODE FROM dbo.JOB_COMPONENT WHERE (JOB_NUMBER = " & Job.JobNumber.ToString() & ") AND (JOB_COMPONENT_NBR = " & Job.ComponentNumber.ToString() + ")"

								EmployeeCode = DbContext.Database.SqlQuery(Of String)(QueryString).FirstOrDefault

								Job.AddAccess(EmployeeCode)

								'Case AdvantageFramework.Services.QvAAlert.SendAlertTo.DefaultAEforCDP
							Case AdvantageFramework.Services.QvAAlert.SendAlertTo.DefaultAccountExecutiveForCDP

								Try

									SelectString = "SELECT ae.EMP_CODE "
									SelectString += "FROM dbo.JOB_LOG jl "
									SelectString += "JOIN dbo.ACCOUNT_EXECUTIVE ae ON (jl.CL_CODE = ae.CL_CODE) AND (jl.DIV_CODE = ae.DIV_CODE) AND (jl.PRD_CODE = ae.PRD_CODE) "
									SelectString += "WHERE (jl.JOB_NUMBER = " + Job.JobNumber.ToString() + ") AND ((ae.INACTIVE_FLAG IS NULL) OR (ae.INACTIVE_FLAG = 0)) "
									WhereString = "AND (ae.DEFAULT_AE = 1) "
									OrderString = "ORDER BY ae.EMP_CODE"

									QueryString = SelectString + WhereString

									EmployeeCodeList = DbContext.Database.SqlQuery(Of String)(QueryString).ToList

								Catch ex As Exception
									EmployeeCodeList = Nothing
								End Try

								If EmployeeCodeList Is Nothing Then

									TryAgain = True

								Else

									If EmployeeCodeList.Count = 0 Then

										TryAgain = True

									Else

										TryAgain = False

									End If

								End If

								If TryAgain Then

									Message = "Default AE not found for job # " + Job.JobNumber.ToString() + " - (" + Job.ClientCode + "/" + Job.DivisionCode + "/" + Job.ProductCode + ") --> " + DatabaseProfileName
									Console.WriteLine(Message)
									WriteToEventLog(Message)

									Try

										QueryString = SelectString + OrderString

										EmployeeCodeList = (DbContext.Database.SqlQuery(Of String)(QueryString)).ToList

									Catch ex As Exception
										EmployeeCodeList = Nothing
									End Try

								End If

								If EmployeeCodeList IsNot Nothing Then

									If EmployeeCodeList.Count > 0 Then

										EmployeeCode = EmployeeCodeList.FirstOrDefault

										If TryAgain Then

											Message = "Employee Code <" + EmployeeCode + "> will be used instead --> " + DatabaseProfileName
											Console.WriteLine(Message)
											WriteToEventLog(Message)

										End If

										Job.AddAccess(EmployeeCode)

									End If

								End If

							Case AdvantageFramework.Services.QvAAlert.SendAlertTo.DefaultAlertGroup

								QueryString = "SELECT eg.EMP_CODE "
								QueryString += "FROM dbo.JOB_COMPONENT jc "
								QueryString += "JOIN dbo.EMAIL_GROUP eg ON (jc.EMAIL_GR_CODE = eg.EMAIL_GR_CODE) "
								QueryString += "WHERE (jc.JOB_NUMBER = " + Job.JobNumber.ToString() + ") AND (jc.JOB_COMPONENT_NBR = " + Job.ComponentNumber.ToString() + ")"

								EmployeeCodeList = DbContext.Database.SqlQuery(Of String)(QueryString).ToList

								For Each EmployeeCode In EmployeeCodeList

									Job.AddAccess(EmployeeCode)

								Next

								'Case AdvantageFramework.Services.QvAAlert.SendAlertTo.AssignedStaff

						End Select

						QvASendAlerts.AddJob(Job)

					Next

					FreeJobsList(JobsList)

					If QvASendAlerts.EmployeeList IsNot Nothing Then

						If QvASendAlerts.EmployeeList.Count > 0 Then

							Message = "Alert Level " + ThresholdLevel.ToString() + " - Sending alerts to " + QvASendAlerts.EmployeeList.Count.ToString() + " employees --> " + DatabaseProfileName
							Console.WriteLine(Message)
							WriteToEventLog(Message)

							For Each Employee In QvASendAlerts.EmployeeList

								Message = "Alert Level " + ThresholdLevel.ToString() + " - Sending alert to employee <" + Employee.EmployeeCode + "> for " + Employee.JobsList.Count.ToString() + " jobs --> " + DatabaseProfileName
								Console.WriteLine(Message)
								WriteToEventLog(Message)

								AdvantageFramework.AlertSystem.CreateAlertForQvANotification(DbContext, SecurityDbContext,
																							 Employee.EmployeeCode, ThresholdLevel,
																							 ThresholdLevelStart, ThresholdLevelEnd, ThresholdLevelDescription,
																							 ShowLevel, Employee.JobsList)

							Next

						End If

					End If

					FreeSendAlertsList(QvASendAlerts)

				Catch ex As Exception
					Throw New Exception("SendAlertOneLevel Error", ex)
				End Try

			End If

		End Sub
		Private Function CheckThresholds(ByVal Quoted As Decimal, ByVal Actual As Decimal, ByRef QvA As Decimal,
										 ByVal ThresholdLevel1Enabled As Boolean, ByVal ThresholdLevel1Start As Decimal, ByVal ThresholdLevel1End As Decimal,
										 ByVal ThresholdLevel2Enabled As Boolean, ByVal ThresholdLevel2Start As Decimal, ByVal ThresholdLevel2End As Decimal,
										 ByVal ThresholdLevel3Enabled As Boolean, ByVal ThresholdLevel3Start As Decimal) As Integer

			'objects
			Dim ThresholdType As Integer = 0

			Try

				If Quoted > 0 Then

					QvA = (Actual / Quoted) * 100

					If ThresholdLevel1Enabled Then

						If ThresholdLevel1Start >= 0 AndAlso ThresholdLevel1End >= 0 AndAlso ThresholdLevel1Start <= ThresholdLevel1End Then

							If ThresholdLevel1Start <= QvA AndAlso ThresholdLevel1End >= QvA Then

								ThresholdType = 1

							End If

						End If

					End If

					If ThresholdLevel2Enabled Then

						If ThresholdLevel2Start >= 0 AndAlso ThresholdLevel2End >= 0 AndAlso ThresholdLevel2Start <= ThresholdLevel2End Then

							If ThresholdLevel2Start <= QvA AndAlso ThresholdLevel2End >= QvA Then

								ThresholdType = 2

							End If

						End If

					End If

					If ThresholdLevel3Enabled Then

						If ThresholdLevel3Start >= 0 Then

							If ThresholdLevel3Start <= QvA Then

								ThresholdType = 3

							End If

						End If

					End If

				Else

					ThresholdType = 0

				End If

			Catch ex As Exception
				ThresholdType = 0
			End Try

			CheckThresholds = ThresholdType

		End Function
		Private Function CreateAlertJobList(ByVal ThresholdLevel As Integer,
											ByVal SetAlertLevel As AdvantageFramework.Services.QvAAlert.SetAlertLevel,
											ByRef AllJobsList As List(Of QvAAlert.Classes.QvAJob))

			'objects
			Dim NewJobsList As List(Of QvAAlert.Classes.QvAJob) = Nothing
			Dim AddJobToList As Boolean = False
			Dim NewJob As QvAAlert.Classes.QvAJob = Nothing
			Dim NewFunctionsList As List(Of QvAAlert.Classes.QvAFunction) = Nothing

			Try

				For Each Job In AllJobsList

					AddJobToList = False
					NewFunctionsList = Nothing

					If NewJobsList Is Nothing Then

						NewJobsList = New List(Of QvAAlert.Classes.QvAJob)()

					End If

					If Job.ThresholdAlert = ThresholdLevel Then

						AddJobToList = True

					End If

					If SetAlertLevel = AdvantageFramework.Services.QvAAlert.SetAlertLevel.JobOrFunction OrElse _CheckAllFunctions Then

						If Job.FunctionList IsNot Nothing Then

							For Each [Function] In Job.FunctionList

								If [Function].ThresholdAlert = ThresholdLevel Then

									If NewFunctionsList Is Nothing Then

										NewFunctionsList = New List(Of QvAAlert.Classes.QvAFunction)()

									End If

									NewFunctionsList.Add([Function])

									If SetAlertLevel = AdvantageFramework.Services.QvAAlert.SetAlertLevel.JobOrFunction Then

										AddJobToList = True

									End If

								End If

							Next

						End If

					End If

					If AddJobToList Then

						NewJob = New QvAAlert.Classes.QvAJob(Job, False)

						If NewFunctionsList IsNot Nothing Then

							NewJob.SetFunctionList(NewFunctionsList)

						End If

						NewJobsList.Add(NewJob)

					End If

				Next

			Catch ex As Exception
				NewJobsList = Nothing
			End Try

			CreateAlertJobList = NewJobsList

		End Function
		Private Sub FreeJobsList(ByRef JobsList As List(Of QvAAlert.Classes.QvAJob))

			If JobsList IsNot Nothing Then

				For Each Job In JobsList

					Try

						If Job IsNot Nothing Then

							Job.Dispose()

						End If

					Catch ex As Exception

					End Try

				Next

				JobsList.Clear()

				JobsList = Nothing

			End If

		End Sub
		Private Sub FreeSendAlertsList(ByRef SendAlerts As QvAAlert.Classes.QvASendAlerts)

			If SendAlerts IsNot Nothing Then

				SendAlerts.Dispose()

			End If

		End Sub
		Private Sub _EventLog_EntryWritten(ByVal sender As Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles _EventLog.EntryWritten

			RaiseEvent EntryLogWrittenEvent(e.Entry)

		End Sub
		Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

			'objects
			Dim RunAt As DateTime = Nothing
			Dim SendAlertTo As AdvantageFramework.Services.QvAAlert.SendAlertTo = AdvantageFramework.Services.QvAAlert.SendAlertTo.AccountExecutiveOnJob
			Dim ThresholdLevel1Enabled As Boolean = False
			Dim ThresholdLevel1Start As Decimal = 0
			Dim ThresholdLevel1End As Decimal = 0
			Dim ThresholdLevel1Description As String = ""
			Dim ThresholdLevel2Enabled As Boolean = False
			Dim ThresholdLevel2Start As Decimal = 0
			Dim ThresholdLevel2End As Decimal = 0
			Dim ThresholdLevel2Description As String = ""
			Dim ThresholdLevel3Enabled As Boolean = False
			Dim ThresholdLevel3Start As Decimal = 0
			Dim ThresholdLevel3Description As String = ""
			Dim Calculation_Time As Boolean = True
			Dim Calculation_IncomeOnly As Boolean = True
			Dim Calculation_VendorCharges As Boolean = True
            Dim Calculation_IncludeEstimate As Boolean = False
            Dim Calculation_IncludeNonBillableTime As Boolean = False
            Dim Calculation_IncludeTimeMarkedFeeTime As Boolean = False
            Dim SetAlertLevel As AdvantageFramework.Services.QvAAlert.SetAlertLevel = AdvantageFramework.Services.QvAAlert.SetAlertLevel.JobOrFunction
			Dim ShowLevel As AdvantageFramework.Services.QvAAlert.ShowLevel = AdvantageFramework.Services.QvAAlert.ShowLevel.JobAndFunctions
			Dim JobDetailAnalysisList As Generic.List(Of AdvantageFramework.Services.QvAAlert.Classes.JobDetailAnalysis) = Nothing
			Dim JobsList As List(Of QvAAlert.Classes.QvAJob) = Nothing
			Dim OneJob As QvAAlert.Classes.QvAJob = Nothing
			Dim Message As String = ""
			Dim JobsListIndex As Integer = 0
			Dim StartTime As DateTime = Nothing
			Dim EndTime As DateTime = Nothing
			Dim Elapsed As TimeSpan = Nothing

			If DatabaseProfile IsNot Nothing Then

				Try

					Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

						Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

							Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

								Message = "Loading settings --> " & DatabaseProfile.DatabaseName
								Console.WriteLine(Message)
								WriteToEventLog(Message)

                                LoadSettings(DataContext, RunAt, SendAlertTo, ThresholdLevel1Enabled, ThresholdLevel1Start, ThresholdLevel1End,
                                             ThresholdLevel1Description, ThresholdLevel2Enabled, ThresholdLevel2Start, ThresholdLevel2End,
                                             ThresholdLevel2Description, ThresholdLevel3Enabled, ThresholdLevel3Start, ThresholdLevel3Description,
                                             Calculation_Time, Calculation_IncomeOnly, Calculation_VendorCharges, Calculation_IncludeEstimate,
                                             Calculation_IncludeNonBillableTime, Calculation_IncludeTimeMarkedFeeTime,
                                             SetAlertLevel, ShowLevel, True)

                                WriteToEventLog("Loading QvA data --> " & DatabaseProfile.DatabaseName)

								JobDetailAnalysisList = LoadJobDetailAnalysis(DbContext).Where(Function(JDA) JDA.ItemDescription <> "Advance Billing").ToList

								WriteToEventLog("Starting QvA calculation --> " & DatabaseProfile.DatabaseName)

								For Each JobItem In (From JobDetailAnalysis In JobDetailAnalysisList
													 Group JobDetailAnalysis By Job = JobDetailAnalysis.JobNumber Into JobComponents = Group
													 Select New With {.JobNumber = Job,
																	  .ComponentNumber = (From JobComponent In JobComponents
																						  Group JobComponent By Component = JobComponent.JobComponentNumber Into Components = Group
																						  Select Component)})

									For Each ComponentItem In JobItem.ComponentNumber

										If JobsList Is Nothing Then

											JobsList = New List(Of QvAAlert.Classes.QvAJob)()

										End If

										OneJob = New QvAAlert.Classes.QvAJob()

										OneJob.JobNumber = JobItem.JobNumber
										OneJob.ComponentNumber = ComponentItem

										JobsList.Add(OneJob)

									Next

								Next

								If JobsList Is Nothing Then

									JobsList = New List(Of QvAAlert.Classes.QvAJob)()

								End If

								StartTime = DateTime.Now

								For JobsListIndex = 0 To JobsList.Count - 1

									'System.Threading.Tasks.Parallel.Invoke(Sub()

									CalculateQvAByJobNumber(DbContext,
															JobDetailAnalysisList,
															SendAlertTo, SetAlertLevel, ShowLevel,
															ThresholdLevel1Enabled, ThresholdLevel1Start, ThresholdLevel1End,
															ThresholdLevel2Enabled, ThresholdLevel2Start, ThresholdLevel2End,
															ThresholdLevel3Enabled, ThresholdLevel3Start,
															Calculation_Time, Calculation_IncomeOnly,
															Calculation_VendorCharges, Calculation_IncludeEstimate,
															JobsList(JobsListIndex))
									'End Sub)
								Next

								EndTime = DateTime.Now

								Elapsed = EndTime - StartTime

								Message = "QvA calculation Finished (" & JobsList.Count.ToString() & " jobs) - Time Elapsed = " & Elapsed.ToString() & " --> " & DatabaseProfile.DatabaseName
								Console.WriteLine(Message)
								WriteToEventLog(Message)

								WriteToEventLog("Sending Alerts --> " & DatabaseProfile.DatabaseName)

								SendAlerts(DbContext,
										   SecurityDbContext,
										   DatabaseProfile.DatabaseName,
										   SendAlertTo,
										   SetAlertLevel,
										   ShowLevel,
										   ThresholdLevel1Enabled, ThresholdLevel1Start, ThresholdLevel1End, ThresholdLevel1Description,
										   ThresholdLevel2Enabled, ThresholdLevel2Start, ThresholdLevel2End, ThresholdLevel2Description,
										   ThresholdLevel3Enabled, ThresholdLevel3Start, ThresholdLevel3Description,
										   JobsList)

								WriteToEventLog("Finished Sending Alerts --> " & DatabaseProfile.DatabaseName)

							End Using

						End Using

					End Using

				Catch ex As Exception
					WriteToEventLog("Error -->" & ex.Message)
				End Try

			End If

		End Sub
		Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

			'objects
			Dim ServiceIsReadyToRun As Boolean = False
			Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
			Dim RunAt As Date = Nothing

			If DatabaseProfile IsNot Nothing Then

				Try

					Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

						AdvantageService = LoadAdvantageService(DataContext)

						If AdvantageService IsNot Nothing Then

							If AdvantageService.Enabled Then

								DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.RunAt), RunAt)

								If RunAt = CDate("01/01/2001 01:00 AM") Then

									RunAt = Now.ToShortDateString & " " & RunAt.ToShortTimeString

								End If

								If DateDiff(DateInterval.Minute, RunAt, Now) >= 0 Then

									RunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

									SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.Contract.RegistrySetting.RunAt, RunAt)

									ServiceIsReadyToRun = True

								End If

							End If

						End If

					End Using

				Catch ex As Exception
					ServiceIsReadyToRun = False
				End Try

			End If

			IsServiceReadyToRun = ServiceIsReadyToRun

		End Function
		Public Sub Run(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

			If DatabaseProfile IsNot Nothing Then

				Try

					If IsServiceReadyToRun(DatabaseProfile) Then

						ProcessDatabase(DatabaseProfile)

					End If

				Catch ex As Exception
					WriteToEventLog("Error -->" & ex.Message)
				End Try

				WriteToEventLog("Running")

			End If

		End Sub
		Public Function LoadLogEntries() As String

			'objects
			Dim Log As String = ""

			Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

			LoadLogEntries = Log

		End Function
		Public Function LoadLog(ByVal LoadEntries As Boolean, Optional ByRef LastEntryMessage As String = "") As String

			'objects
			Dim Log As String = ""
			Dim Entry As System.Diagnostics.EventLogEntry = Nothing

			If System.Diagnostics.EventLog.SourceExists("Adv QvAAlert Source") = False Then

				System.Diagnostics.EventLog.CreateEventSource("Adv QvAAlert Source", "Adv QvAAlert Log")

			End If

			_EventLog = New System.Diagnostics.EventLog("Adv QvAAlert Log", My.Computer.Name, "Adv QvAAlert Source")

			_EventLog.ModifyOverflowPolicy(System.Diagnostics.OverflowAction.OverwriteAsNeeded, _EventLog.MinimumRetentionDays)

			_EventLog.EnableRaisingEvents = True

			If LoadEntries Then

				Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

				Try

					Entry = _EventLog.Entries.OfType(Of System.Diagnostics.EventLogEntry).OrderByDescending(Function(EventLogEntry) EventLogEntry.TimeGenerated).FirstOrDefault

				Catch ex As Exception
					Entry = Nothing
				End Try

				If Entry IsNot Nothing Then

					LastEntryMessage = Entry.Message & "...."

				End If

			End If

			LoadLog = Log

		End Function
		Public Function LoadAdvantageService(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.AdvantageService

			'objects
			Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

			Try

				AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService)

			Catch ex As Exception
				AdvantageService = Nothing
			End Try

			LoadAdvantageService = AdvantageService

		End Function
		Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.QvAAlert.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

			'objects
			Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

			Try

				AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

			Catch ex As Exception
				AdvantageServiceSetting = Nothing
			End Try

			LoadAdvantageServiceSetting = AdvantageServiceSetting

		End Function
		Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.QvAAlert.RegistrySetting) As Object

			'objects
			Dim SettingValue As Object = Nothing

			Try

				SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

			Catch ex As Exception
				SettingValue = Nothing
			End Try

			LoadAdvantageServiceSettingValue = SettingValue

		End Function
		Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.QvAAlert.RegistrySetting, ByVal SettingValue As Object) As Boolean

			'objects
			Dim Saved As Boolean = False

			Try

				Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

			Catch ex As Exception
				Saved = False
			End Try

			SaveAdvantageServiceSettingValue = Saved

		End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAt As DateTime, ByRef SendAlertTo As Integer,
                                ByRef ThresholdLevel1Enabled As Boolean, ByRef ThresholdLevel1Start As Decimal, ByRef ThresholdLevel1End As Decimal, ByRef ThresholdLevel1Description As String,
                                ByRef ThresholdLevel2Enabled As Boolean, ByRef ThresholdLevel2Start As Decimal, ByRef ThresholdLevel2End As Decimal, ByRef ThresholdLevel2Description As String,
                                ByRef ThresholdLevel3Enabled As Boolean, ByRef ThresholdLevel3Start As Decimal, ByRef ThresholdLevel3Description As String,
                                ByRef Calculation_Time As Boolean, ByRef Calculation_IncomeOnly As Boolean,
                                ByRef Calculation_VendorCharges As Boolean, ByRef Calculation_IncludeEstimate As Boolean,
                                ByRef Calculation_IncludeNonBillableTime As Boolean, ByRef Calculation_IncludeTimeMarkedFeeTime As Boolean,
                                ByRef SetAlertLevel As Integer, ByRef ShowLevel As Integer, ByVal ConvertThresholdValuesToPercent As Boolean)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.RunAt), RunAt)

                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.SendAlertTo), SendAlertTo)

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel1Enabled), ThresholdLevel1Enabled)
                Decimal.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel1Start), ThresholdLevel1Start)
                Decimal.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel1End), ThresholdLevel1End)
                ThresholdLevel1Description = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel1Description)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel2Enabled), ThresholdLevel2Enabled)
                Decimal.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel2Start), ThresholdLevel2Start)
                Decimal.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel2End), ThresholdLevel2End)
                ThresholdLevel2Description = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel2Description)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel3Enabled), ThresholdLevel3Enabled)
                Decimal.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel3Start), ThresholdLevel3Start)
                ThresholdLevel3Description = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel3Description)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_Time), Calculation_Time)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_IncomeOnly), Calculation_IncomeOnly)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_VendorCharges), Calculation_VendorCharges)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_IncludeEstimate), Calculation_IncludeEstimate)

                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_IncludeNonBillableTime), Calculation_IncludeNonBillableTime)
                Boolean.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_IncludeTimeMarkedFeeTime), Calculation_IncludeTimeMarkedFeeTime)

                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.SetAlertLevel), SetAlertLevel)
                Integer.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ShowLevel), ShowLevel)

                If ConvertThresholdValuesToPercent Then

                    ThresholdLevel1Start = ThresholdLevel1Start * 100
                    ThresholdLevel2Start = ThresholdLevel2Start * 100
                    ThresholdLevel3Start = ThresholdLevel3Start * 100
                    ThresholdLevel1End = ThresholdLevel1End * 100
                    ThresholdLevel2End = ThresholdLevel2End * 100

                End If

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAt As DateTime, ByVal SendAlertTo As Integer, ByVal ThresholdLevel1Enabled As Boolean, ByVal ThresholdLevel1Start As Decimal, ByVal ThresholdLevel1End As Decimal,
                                ByVal ThresholdLevel1Description As String, ByVal ThresholdLevel2Enabled As Boolean, ByVal ThresholdLevel2Start As Decimal,
                                ByVal ThresholdLevel2End As Decimal, ByVal ThresholdLevel2Description As String, ByVal ThresholdLevel3Enabled As Boolean, ByVal ThresholdLevel3Start As Decimal,
                                ByVal ThresholdLevel3Description As String, ByVal Calculation_Time As Boolean, ByVal Calculation_IncomeOnly As Boolean, ByVal Calculation_VendorCharges As Boolean,
                                ByVal Calculation_IncludeEstimate As Boolean, ByVal Calculation_IncludeNonBillableTime As Boolean, ByVal Calculation_IncludeTimeMarkedFeeTime As Boolean,
                                ByVal SetAlertLevel As Integer, ByVal ShowLevel As Integer)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            'Dim PreviousRunAt As DateTime = Nothing
            'Dim ServiceController As System.ServiceProcess.ServiceController = Nothing

            'DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.RunAt), PreviousRunAt)

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.RunAt, RunAt)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.SendAlertTo, SendAlertTo)

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel1Enabled, ThresholdLevel1Enabled)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel1Start, ThresholdLevel1Start)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel1End, ThresholdLevel1End)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel1Description, ThresholdLevel1Description)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel2Enabled, ThresholdLevel2Enabled)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel2Start, ThresholdLevel2Start)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel2End, ThresholdLevel2End)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel2Description, ThresholdLevel2Description)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel3Enabled, ThresholdLevel3Enabled)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel3Start, ThresholdLevel3Start)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ThresholdLevel3Description, ThresholdLevel3Description)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_Time, Calculation_Time)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_IncomeOnly, Calculation_IncomeOnly)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_VendorCharges, Calculation_VendorCharges)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_IncludeEstimate, Calculation_IncludeEstimate)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_IncludeNonBillableTime, Calculation_IncludeNonBillableTime)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.Calculation_IncludeTimeMarkedFeeTime, Calculation_IncludeTimeMarkedFeeTime)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.SetAlertLevel, SetAlertLevel)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.QvAAlert.RegistrySetting.ShowLevel, ShowLevel)

            End If

            'If PreviousRunAt <> RunAt Then

            '    ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService)

            '    If ServiceController IsNot Nothing AndAlso ServiceController.Status = ServiceProcess.ServiceControllerStatus.Running Then

            '        ServiceController.ExecuteCommand(AdvantageFramework.Services.QvAAlert.CustomCommand.LoadSettings)

            '    End If

            'End If

        End Sub
        Public Sub WriteToEventLog(Message As String)

            Try

                SyncLock _EventLog

                    _EventLog.WriteEntry(Message)

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub
        Public Sub ClearLog()

            Try

                SyncLock _EventLog

                    _EventLog.Clear()

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub

#End Region

    End Module

End Namespace

