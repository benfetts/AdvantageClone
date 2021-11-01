Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions

Namespace Controllers

    Public Class ReportingController
        Inherits MVCControllerBase

#Region " Methods "

        Public Function GetPostPeriods() As JsonResult

            'objects
            Dim PostPeriods As IEnumerable = Nothing
            Dim CurrentPostPeriod As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                PostPeriods = (From Item In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext)
                               Order By Item.Year Descending, Item.Month Ascending
                               Select Item.Code,
                                      Item.Description).ToList.Select(Function(p) New With {.Code = p.Code, .Description = p.Code & " - " & p.Description, .IsCurrent = If(p.Code = CurrentPostPeriod, True, False)}).ToList

            End Using

            Return Json(PostPeriods, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET")>
        Public Function ViewAccountsPayableBalanceByVendorReport(ByVal EndPostPeriod As String, ByVal RecordSource As Integer) As JsonResult

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ReportData As Object = Nothing
            Dim UserDefinedReportID As Integer = 0
            Dim DynamicReportTemplateID As Integer = 0
            Dim Url As String = ""

            ParameterDictionary = New Dictionary(Of String, Object)

            ParameterDictionary(AdvantageFramework.Reporting.APBalanceByVendorInitialCriteria.EndingPostPeriodCode.ToString) = EndPostPeriod
            ParameterDictionary(AdvantageFramework.Reporting.APBalanceByVendorInitialCriteria.RecordSourceID.ToString) = RecordSource

            If TempData.ContainsKey("UserDefinedReportID") Then

                UserDefinedReportID = TempData("UserDefinedReportID")

            End If

            If TempData.ContainsKey("DynamicReportTemplateID") Then

                DynamicReportTemplateID = TempData("DynamicReportTemplateID")

            End If

            If UserDefinedReportID = 0 Then

                If DynamicReportTemplateID <> 0 Then

                    Url = String.Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID)

                Else

                    Url = "Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}"

                End If

            Else

                System.Web.HttpContext.Current.Session("UserDefinedReportID") = UserDefinedReportID
                Url = "Reporting_ViewReport.aspx?Report=" & CType(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined.ToString), String) & ""

            End If

            System.Web.HttpContext.Current.Session("DRPT_UseBlankData") = False
            System.Web.HttpContext.Current.Session("DRPT_ParameterDictionary") = ParameterDictionary

            ReportData = New With {
                .URL = Url
            }

            Return Json(ReportData, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET")>
        Public Function ViewAccountsReceivableBalanceByClientReport(ByVal EndPostPeriod As String, ByVal RecordSource As Integer) As JsonResult

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ReportData As Object = Nothing
            Dim UserDefinedReportID As Integer = 0
            Dim DynamicReportTemplateID As Integer = 0
            Dim Url As String = ""

            ParameterDictionary = New Dictionary(Of String, Object)

            ParameterDictionary(AdvantageFramework.Reporting.ARBalanceByClientInitialCriteria.EndingPostPeriodCode.ToString) = EndPostPeriod
            ParameterDictionary(AdvantageFramework.Reporting.ARBalanceByClientInitialCriteria.RecordSourceID.ToString) = RecordSource

            If TempData.ContainsKey("UserDefinedReportID") Then

                UserDefinedReportID = TempData("UserDefinedReportID")

            End If

            If TempData.ContainsKey("DynamicReportTemplateID") Then

                DynamicReportTemplateID = TempData("DynamicReportTemplateID")

            End If

            If UserDefinedReportID = 0 Then

                If DynamicReportTemplateID <> 0 Then

                    Url = String.Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID)

                Else

                    Url = "Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}"

                End If

            Else

                System.Web.HttpContext.Current.Session("UserDefinedReportID") = UserDefinedReportID
                Url = "Reporting_ViewReport.aspx?Report=" & CType(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined.ToString), String) & ""

            End If

            System.Web.HttpContext.Current.Session("DRPT_UseBlankData") = False
            System.Web.HttpContext.Current.Session("DRPT_ParameterDictionary") = ParameterDictionary

            ReportData = New With {
                .URL = Url
            }

            Return Json(ReportData, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET")>
        Public Function ViewSalesAndCostOfSalesByClientReport(ByVal StartPostPeriod As String, ByVal EndPostPeriod As String, ByVal RecordSource As Integer) As JsonResult

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ReportData As Object = Nothing
            Dim UserDefinedReportID As Integer = 0
            Dim DynamicReportTemplateID As Integer = 0
            Dim Url As String = ""

            ParameterDictionary = New Dictionary(Of String, Object)

            ParameterDictionary(AdvantageFramework.Reporting.SalesAndCOSbyClientInitialParameters.StartingPostPeriodCode.ToString) = StartPostPeriod
            ParameterDictionary(AdvantageFramework.Reporting.SalesAndCOSbyClientInitialParameters.EndingPostPeriodCode.ToString) = EndPostPeriod
            ParameterDictionary(AdvantageFramework.Reporting.SalesAndCOSbyClientInitialParameters.RecordSourceID.ToString) = RecordSource

            If TempData.ContainsKey("UserDefinedReportID") Then

                UserDefinedReportID = TempData("UserDefinedReportID")

            End If

            If TempData.ContainsKey("DynamicReportTemplateID") Then

                DynamicReportTemplateID = TempData("DynamicReportTemplateID")

            End If

            If UserDefinedReportID = 0 Then

                If DynamicReportTemplateID <> 0 Then

                    Url = String.Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID)

                Else

                    Url = "Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}"

                End If

            Else

                System.Web.HttpContext.Current.Session("UserDefinedReportID") = UserDefinedReportID
                Url = "Reporting_ViewReport.aspx?Report=" & CType(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined.ToString), String) & ""

            End If

            System.Web.HttpContext.Current.Session("DRPT_UseBlankData") = False
            System.Web.HttpContext.Current.Session("DRPT_ParameterDictionary") = ParameterDictionary

            ReportData = New With {
                .URL = Url
            }

            Return Json(ReportData, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("GET")>
        Public Function ViewRevenueBreakdownByClientReport(ByVal StartPostPeriod As String, ByVal EndPostPeriod As String) As JsonResult

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim ReportData As Object = Nothing
            Dim UserDefinedReportID As Integer = 0
            Dim DynamicReportTemplateID As Integer = 0
            Dim Url As String = ""

            ParameterDictionary = New Dictionary(Of String, Object)

            ParameterDictionary(AdvantageFramework.Reporting.RevenueBreakdownByClientInitialParameters.StartingPostPeriodCode.ToString) = StartPostPeriod
            ParameterDictionary(AdvantageFramework.Reporting.RevenueBreakdownByClientInitialParameters.EndingPostPeriodCode.ToString) = EndPostPeriod

            If TempData.ContainsKey("UserDefinedReportID") Then

                UserDefinedReportID = TempData("UserDefinedReportID")

            End If

            If TempData.ContainsKey("DynamicReportTemplateID") Then

                DynamicReportTemplateID = TempData("DynamicReportTemplateID")

            End If

            If UserDefinedReportID = 0 Then

                If DynamicReportTemplateID <> 0 Then

                    Url = String.Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID)

                Else

                    Url = "Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}"

                End If

            Else

                System.Web.HttpContext.Current.Session("UserDefinedReportID") = UserDefinedReportID
                Url = "Reporting_ViewReport.aspx?Report=" & CType(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined.ToString), String) & ""

            End If

            System.Web.HttpContext.Current.Session("DRPT_UseBlankData") = False
            System.Web.HttpContext.Current.Session("DRPT_ParameterDictionary") = ParameterDictionary

            ReportData = New With {
                .URL = Url
            }

            Return Json(ReportData, JsonRequestBehavior.AllowGet)

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
        Public Function GetRecordSources() As JsonResult

            'objects
            Dim RecordSources As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                RecordSources = (From Item In AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext)
                                 Select [Code] = Item.ID,
                                        [Description] = Item.Name).ToList

            End Using

            Return Json(RecordSources, JsonRequestBehavior.AllowGet)

        End Function

#End Region

#Region " Views "

        Public Function AccountsPayableBalanceByVendorReportCriteria(ByVal DynamicReportTemplateID As Integer, ByVal UserDefinedReportID As Integer) As ActionResult

            TempData("DynamicReportTemplateID") = DynamicReportTemplateID
            TempData("UserDefinedReportID") = UserDefinedReportID

            Return View()

        End Function
        Public Function AccountsReceivableBalanceByClientReportCriteria(ByVal DynamicReportTemplateID As Integer, ByVal UserDefinedReportID As Integer) As ActionResult

            TempData("DynamicReportTemplateID") = DynamicReportTemplateID
            TempData("UserDefinedReportID") = UserDefinedReportID

            Return View()

        End Function
        Public Function SalesAndCostOfSalesByClientReportCriteria(ByVal DynamicReportTemplateID As Integer, ByVal UserDefinedReportID As Integer) As ActionResult

            TempData("DynamicReportTemplateID") = DynamicReportTemplateID
            TempData("UserDefinedReportID") = UserDefinedReportID

            Return View()

        End Function
        Public Function RevenueBreakdownByClientReportCriteria(ByVal DynamicReportTemplateID As Integer, ByVal UserDefinedReportID As Integer) As ActionResult

            TempData("DynamicReportTemplateID") = DynamicReportTemplateID
            TempData("UserDefinedReportID") = UserDefinedReportID

            Return View()

        End Function

#End Region

    End Class

End Namespace

