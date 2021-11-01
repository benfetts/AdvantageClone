Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting

Namespace Controllers.GeneralLedger.Reports

    <Serializable>
    Public Class ReportSettings

        Public Property ReportID As Integer
        Public Property IsDynamic As Boolean

    End Class

    Public Class GeneralLedgerReportController
		Inherits MVCControllerBase

		Public Const BaseRoute As String = "GeneralLedger/Reports/GeneralLedgerReport/"

        Public Function DetailByAccountReport(<FromRoute()> ByVal ReportID As Integer, <FromRoute()> ByVal IsDynamic As Short, <FromRoute()> Optional ByVal DynamicType As Integer = 0) As ActionResult

            Dim ReportSettings As ReportSettings = Nothing
            Dim ReportModel As Object = Nothing
            Dim IncludeOffices As Boolean = False
            Dim IncludeDepartments As Boolean = False
            Dim IncludeOthers As Boolean = False
            Dim IncludeBases As Boolean = False
            Dim IncludeAccountTypes As Boolean = False

            AdvantageFramework.GeneralLedger.ReportWriter.LoadGeneralLedgerDetailByAccountReportSettings(Me.SecuritySession, CBool(IsDynamic), IncludeOffices, IncludeDepartments, IncludeOthers, IncludeBases, IncludeAccountTypes)

            ReportModel = New With {
                .IncludeOffices = IncludeOffices,
                .IncludeDepartments = IncludeDepartments,
                .IncludeOthers = IncludeOthers,
                .IncludeBases = IncludeBases,
                .IncludeAccountTypes = IncludeAccountTypes,
                .HideEndingPostPeriod = If(DynamicType = AdvantageFramework.Reporting.DynamicReports.TrialBalance, True, False)
            }

            ReportSettings = New ReportSettings With {
                .ReportID = ReportID,
                .IsDynamic = CBool(IsDynamic)
            }

            TempData("ReportSettings") = ReportSettings

            Return View(ReportModel)

        End Function
        <AcceptVerbs("GET")>
		Public Function ViewDetailByAccountReport(ByVal Report As String, ByVal StartPostPeriod As String, ByVal EndPostPeriod As String, ByVal RecordSourceID As Integer,
												  ByVal Offices As String, ByVal Departments As String, ByVal Others As String, ByVal Bases As String, ByVal AccountTypes As String) As JsonResult

			'objects
			Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
			Dim Status As Short = 0
			Dim ReportData As Object = Nothing
			Dim ReportSettings As Object = Nothing
			Dim IsDynamic As Boolean = False
			Dim ReportID As Integer = 0
			Dim URL As String = ""
			Dim CurrentAssets As Boolean = False
			Dim NonCurrentAssets As Boolean = False
			Dim FixedAssets As Boolean = False
			Dim CurrentLiabilities As Boolean = False
			Dim NonCurrentLiabilities As Boolean = False
			Dim Equity As Boolean = False
			Dim Income As Boolean = False
			Dim IncomeOther As Boolean = False
			Dim ExpenseCOS As Boolean = False
			Dim ExpenseOperating As Boolean = False
			Dim ExpenseOther As Boolean = False
			Dim ExpenseTaxes As Boolean = False

			Try

				ReportSettings = TempData("ReportSettings")

			Catch ex As Exception

			End Try

			ParameterDictionary = New Dictionary(Of String, Object)

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

				If Not String.IsNullOrWhiteSpace(AccountTypes) Then

					With AccountTypes.Split(",")

						CurrentAssets = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.CurrentAsset).Code)
						NonCurrentAssets = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.NonCurrentAsset).Code)
						FixedAssets = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.FixedAsset).Code)
						CurrentLiabilities = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.CurrentLiability).Code)
						NonCurrentLiabilities = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.NonCurrentLiability).Code)
						Equity = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.Equity).Code)
						Income = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.Income).Code)
						IncomeOther = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.IncomeOther).Code)
						ExpenseCOS = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseCOS).Code)
						ExpenseOperating = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseOperating).Code)
						ExpenseOther = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseOther).Code)
						ExpenseTaxes = .Any(Function(item) item = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes.ExpenseTaxes).Code)

					End With

				End If

				If Not CurrentAssets AndAlso Not NonCurrentAssets AndAlso Not FixedAssets AndAlso Not CurrentLiabilities AndAlso Not NonCurrentLiabilities AndAlso
				   Not Equity AndAlso Not Income AndAlso Not IncomeOther AndAlso Not ExpenseCOS AndAlso Not ExpenseOperating AndAlso Not ExpenseOther AndAlso Not ExpenseTaxes Then

					CurrentAssets = True
					NonCurrentAssets = True
					FixedAssets = True
					CurrentLiabilities = True
					NonCurrentLiabilities = True
					Equity = True
					Income = True
					IncomeOther = True
					ExpenseCOS = True
					ExpenseOperating = True
					ExpenseOther = True
					ExpenseTaxes = True

				End If

				Select Case Report

					Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountLandscape).Code

						ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Report.ToString) = AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountLandscape

					Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountPortrait).Code

						ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Report.ToString) = AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountPortrait

				End Select

				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.StartingPostPeriodCode.ToString) = StartPostPeriod
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.EndingPostPeriodCode.ToString) = EndPostPeriod
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Offices.ToString) = Offices
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Departments.ToString) = Departments
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.OtherCodes.ToString) = Others
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.BaseCodes.ToString) = Bases
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.RecordSourceID.ToString) = RecordSourceID
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeCurrentAssets.ToString) = CurrentAssets
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeNonCurrentAssets.ToString) = NonCurrentAssets
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeFixedAssets.ToString) = FixedAssets
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeCurrentLiabilities.ToString) = CurrentLiabilities
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeNonCurrentLiabilities.ToString) = NonCurrentLiabilities
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeEquity.ToString) = Equity
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeIncome.ToString) = Income
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeIncomeOther.ToString) = IncomeOther
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseCOS.ToString) = ExpenseCOS
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseOperating.ToString) = ExpenseOperating
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseOther.ToString) = ExpenseOther
				ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.IncludeExpenseTaxes.ToString) = ExpenseTaxes

				If ReportSettings IsNot Nothing Then

					ReportID = ReportSettings.ReportID
					IsDynamic = ReportSettings.IsDynamic

					If IsDynamic Then

						If ReportID <> 0 Then

							URL = String.Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", ReportID)

						Else

							URL = String.Format("Reporting_DynamicReportEdit.aspx", ReportID)

						End If

					Else

						System.Web.HttpContext.Current.Session("UserDefinedReportID") = ReportID
						URL = "Reporting_ViewReport.aspx?Report=" & CType(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined.ToString), String) & ""

					End If

					System.Web.HttpContext.Current.Session("DRPT_UseBlankData") = False
					ReportData = New With {.URL = URL}

				End If

				System.Web.HttpContext.Current.Session("DRPT_ParameterDictionary") = ParameterDictionary

			End Using

			Return Json(ReportData, JsonRequestBehavior.AllowGet)

		End Function

		Public Function DetailByAccountReport_LoadOffices(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest) As JsonResult

			'objects
			Dim Offices As IEnumerable = Nothing
			Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

				Offices = (From Item In AdvantageFramework.GeneralLedger.LoadGeneralLedgerReportsOffices(Me.SecuritySession, DbContext)
						   Select [Code] = Item.Key,
								  [Description] = If(Item.Value IsNot Nothing AndAlso Item.Value.Office IsNot Nothing, Item.Value.Office.Name, ""),
								  [IsInactive] = CBool(If(Item.Value IsNot Nothing AndAlso Item.Value.Office IsNot Nothing, Item.Value.Office.IsInactive.GetValueOrDefault(0), False))).ToList

				DataSourceResult = Offices.AsQueryable.ToDataSourceResult(DataSourceRequest)

			End Using

			Return Json(DataSourceResult)

		End Function
		Public Function DetailByAccountReport_PostPeriods() As JsonResult

			'objects
			Dim PostPeriods As IEnumerable = Nothing
			Dim CurrentPostPeriod As String = ""

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

				CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                PostPeriods = (From Item In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                               Order By Item.Code Descending
                               Select Item.Code,
                                      Item.Description).ToList.Select(Function(p) New With {.Code = p.Code, .Description = p.Code & " - " & p.Description, .IsCurrent = If(p.Code = CurrentPostPeriod, True, False)}).ToList

            End Using

			Return Json(PostPeriods, JsonRequestBehavior.AllowGet)

		End Function
		Public Function DetailByAccountReport_RecordSources() As JsonResult

			'objects
			Dim RecordSources As IEnumerable = Nothing

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

				RecordSources = (From Item In AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext)
								 Select [Code] = Item.ID,
										[Description] = Item.Name).ToList

			End Using

			Return Json(RecordSources, JsonRequestBehavior.AllowGet)

		End Function
		Public Function DetailByAccountReport_LoadDepartments(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest) As JsonResult

			'objects
			Dim Departments As IEnumerable = Nothing
			Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

				Departments = (From Item In AdvantageFramework.GeneralLedger.LoadGeneralLedgerReportsDepartments(DbContext)
							   Select [Code] = Item.Key,
									  [Description] = If(Item.Value IsNot Nothing AndAlso Item.Value.DepartmentTeam IsNot Nothing, Item.Value.DepartmentTeam.Description, ""),
									  [IsInactive] = CBool(If(Item.Value IsNot Nothing AndAlso Item.Value.DepartmentTeam IsNot Nothing, Item.Value.DepartmentTeam.IsInactive.GetValueOrDefault(0), False))).ToList

				DataSourceResult = Departments.ToDataSourceResult(DataSourceRequest)

			End Using

			Return Json(DataSourceResult)

		End Function
		Public Function DetailByAccountReport_LoadOthers(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest,
														ByVal Offices As String, ByVal Departments As String, ByVal AccountTypes As String) As JsonResult

			'objects
			Dim AvailableGeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
			Dim OtherCodes As IEnumerable = Nothing
			Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

				OtherCodes = (From Item In LoadFilteredAccounts(DbContext, Offices, Departments, AccountTypes).ToList
							  Group By Item.OtherCode Into Group
							  Select New With {.Code = Group.First.OtherCode,
											   .IsInactive = Not Group.Where(Function(Gla) Gla.Active = "A").Any}).ToList

				DataSourceResult = OtherCodes.ToDataSourceResult(DataSourceRequest)

			End Using

			Return Json(DataSourceResult)

		End Function
		Public Function DetailByAccountReport_LoadBases(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest,
														ByVal Offices As String, ByVal Departments As String, ByVal AccountTypes As String) As JsonResult

			'objects
			Dim BaseCodes As IEnumerable = Nothing
			Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

				BaseCodes = (From Item In LoadFilteredAccounts(DbContext, Offices, Departments, AccountTypes).ToList
							 Group By Item.BaseCode Into Group
							 Select New With {.Code = Group.First.Code,
											  .Description = Group.First.Description,
											  .IsInactive = Not Group.Where(Function(gla) gla.Active = "A").Any}).OrderBy(Function(bc) bc.Code).ToList

				DataSourceResult = BaseCodes.ToDataSourceResult(DataSourceRequest)

			End Using

			Return Json(DataSourceResult)

		End Function
		Public Function DetailByAccountReport_LoadAccountTypes(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest) As JsonResult

			'objects
			Dim AccountTypes As IEnumerable = Nothing
			Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing

			AccountTypes = (From Item In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.GeneralLedger.ReportWriter.AccountTypes))
							Select [Code] = Item.Code,
									   [Description] = Item.Description).ToList

			DataSourceResult = AccountTypes.ToDataSourceResult(DataSourceRequest)

			Return Json(DataSourceResult)

		End Function
		Private Function LoadFilteredAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext,
											  ByVal Offices As String, ByVal Departments As String, ByVal AccountTypes As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

			'objects
			Dim GLObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
			Dim AccountTypesString As String() = Nothing
			Dim OfficesArray As String() = Nothing
			Dim DepartmentsArray As String() = Nothing
			Dim AccountTypesArray As String() = Nothing

			GLObjectQuery = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Me.SecuritySession)

			If Not String.IsNullOrWhiteSpace(Offices) Then

				OfficesArray = Offices.Split(",")

				GLObjectQuery = GLObjectQuery.Where(Function(item) OfficesArray.Contains(item.GeneralLedgerOfficeCrossReferenceCode))

			End If

			If Not String.IsNullOrWhiteSpace(Departments) Then

				DepartmentsArray = Departments.Split(",")

				GLObjectQuery = GLObjectQuery.Where(Function(item) DepartmentsArray.Contains(item.DepartmentCode))

			End If

			If Not String.IsNullOrWhiteSpace(AccountTypes) Then

				AccountTypesArray = AccountTypes.Split(",")

				GLObjectQuery = GLObjectQuery.Where(Function(item) AccountTypesArray.Contains(item.Type))

			End If

			Return GLObjectQuery

		End Function
		Public Function LoadPresetPostPeriod(ByVal PresetOption As Integer) As JsonResult

			'objects
			Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
			Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
			Dim Month As Integer = 0
			Dim Year As Integer = 0
			Dim PostPeriodStart As String = ""
			Dim PostPeriodEnd As String = ""


			Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

				CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

				Select Case PresetOption

					Case 0 'YTD

						PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, CurrentPostPeriod.Year)

						Try

							PostPeriodStart = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), PostPeriod.Year.ToString).Code

						Catch ex As Exception
							PostPeriodStart = Nothing
						End Try

						Try

							PostPeriodEnd = CurrentPostPeriod.Code

						Catch ex As Exception
							PostPeriodEnd = Nothing
						End Try

					Case 1 ' MTD

						Try

							PostPeriodStart = CurrentPostPeriod.Code

						Catch ex As Exception
							PostPeriodStart = Nothing
						End Try

						Try

							PostPeriodEnd = CurrentPostPeriod.Code

						Catch ex As Exception
							PostPeriodEnd = Nothing
						End Try

					Case 2 ' 1 Year

						If CurrentPostPeriod IsNot Nothing Then

							Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
							Year = CInt(CurrentPostPeriod.Year) - 1

						End If

						Try

							PostPeriodStart = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code

						Catch ex As Exception
							PostPeriodStart = Nothing
						End Try

						Try

							PostPeriodEnd = CurrentPostPeriod.Code

						Catch ex As Exception
							PostPeriodEnd = Nothing
						End Try

					Case 3 ' 2 Years

						If CurrentPostPeriod IsNot Nothing Then

							Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
							Year = CInt(CurrentPostPeriod.Year) - 2

						End If

						Try

							PostPeriodStart = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code

						Catch ex As Exception
							PostPeriodStart = Nothing
						End Try

						Try

							PostPeriodEnd = CurrentPostPeriod.Code

						Catch ex As Exception
							PostPeriodEnd = Nothing
						End Try

				End Select

			End Using

			Return Json(New With {.PostPeriodStart = PostPeriodStart, .PostPeriodEnd = PostPeriodEnd}, JsonRequestBehavior.AllowGet)

		End Function

	End Class

End Namespace

