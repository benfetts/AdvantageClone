Namespace Controller.Media

    Public Class MediaPlanningController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function AddAd(ViewModel As AdvantageFramework.ViewModels.Media.MediaPlanningViewModel) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing

            Ad = New AdvantageFramework.Database.Entities.Ad
            Ad.Number = ViewModel.Code
            Ad.Description = ViewModel.Description
            Ad.ClientCode = ViewModel.ClientCode
            Ad.IsInactive = 1

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Ad.DbContext = DbContext

                Added = AdvantageFramework.Database.Procedures.Ad.Insert(DbContext, Ad)

            End Using

            AddAd = Added

        End Function
        Private Function AddAdSize(ViewModel As AdvantageFramework.ViewModels.Media.MediaPlanningViewModel) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing

            AdSize = New AdvantageFramework.Database.Entities.AdSize
            AdSize.Code = ViewModel.Code
            AdSize.Description = ViewModel.Description
            AdSize.MediaType = ViewModel.MediaType
            AdSize.IsInactive = 0

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AdSize.DbContext = DbContext

                Added = AdvantageFramework.Database.Procedures.AdSize.Insert(DbContext, AdSize)

            End Using

            AddAdSize = Added

        End Function

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function AddTag(ViewModel As AdvantageFramework.ViewModels.Media.MediaPlanningViewModel)

            'objects
            Dim TagAdded As Boolean = False

            If ViewModel.TagType = MediaPlanning.Methods.TagTypes.AdNumber Then

                TagAdded = AddAd(ViewModel)

            ElseIf ViewModel.TagType = MediaPlanning.Methods.TagTypes.AdSize Then

                TagAdded = AddAdSize(ViewModel)

            End If

            AddTag = TagAdded

        End Function

#Region " MediaPlanCopy "

        Public Function LoadMediaPlanCopy(MediaPlanDetailIDs As IEnumerable(Of Integer)) As AdvantageFramework.ViewModels.Media.MediaPlanCopyViewModel

            'objects
            Dim MediaPlanCopyViewModel As AdvantageFramework.ViewModels.Media.MediaPlanCopyViewModel = Nothing

            MediaPlanCopyViewModel = New AdvantageFramework.ViewModels.Media.MediaPlanCopyViewModel

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaPlanCopyViewModel.MediaPlanCopyList.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetail.Load(DbContext).Where(Function(Entity) MediaPlanDetailIDs.Contains(Entity.ID)).ToList
                                                                  Select New AdvantageFramework.DTO.Media.MediaPlanCopy(Entity))

                MediaPlanCopyViewModel.RepositorySalesClassList = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList

            End Using

            LoadMediaPlanCopy = MediaPlanCopyViewModel

        End Function
        Public Function GetSalesClassesBySalesClassTypeCode(SalesClassTypeCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

            'objects
            Dim SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SalesClasses = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActiveBySalesClassTypeCode(DbContext, SalesClassTypeCode).ToList

            End Using

            GetSalesClassesBySalesClassTypeCode = SalesClasses

        End Function
        Public Sub ValidateMediaPlanCopys(ViewModel As AdvantageFramework.ViewModels.Media.MediaPlanCopyViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each MediaPlanCopy In ViewModel.MediaPlanCopyList

                        ValidateDTO(DbContext, DataContext, MediaPlanCopy, True)

                    Next

                End Using

            End Using

        End Sub
        Public Function ValidateEntity(MediaPlanCopy As AdvantageFramework.DTO.Media.MediaPlanCopy, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaPlanCopy, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(MediaPlanCopy As AdvantageFramework.DTO.Media.MediaPlanCopy, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaPlanCopy.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaPlanCopy, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            ValidateProperty = ErrorText

        End Function

#End Region

#Region " EstimateGRPBudget "

        Public Function EstimateGRPBudget_Load(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan) As AdvantageFramework.ViewModels.Media.MediaPlanEstimateGRPBudgetViewModel

            'objects
            Dim ViewModel As AdvantageFramework.ViewModels.Media.MediaPlanEstimateGRPBudgetViewModel = Nothing
            Dim MediaPlanDetailGRPBudgetList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailGRPBudget) = Nothing
            Dim MediaPlanDetailGRPBudgetEntity As AdvantageFramework.Database.Entities.MediaPlanDetailGRPBudget = Nothing
            Dim MediaPlanDetailGRPBudget As AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget = Nothing
            Dim MediaPlanDetailLevelLineTags As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag) = Nothing
            Dim MarketCodes As Generic.List(Of String) = Nothing
            Dim MediaPlanDetailLevelID As Nullable(Of Integer) = Nothing
            Dim SpotLengths As Generic.List(Of Short) = Nothing
            Dim EntryDates As Generic.List(Of Date) = Nothing
            Dim MediaPlanDetailID As Integer = MediaPlan.MediaPlanEstimate.ID
            Dim Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing
            Dim FromDate As Date = Date.MinValue
            Dim FromDateDay As Integer = 1
            Dim FromDateMonth As Integer = 1
            Dim FromDateYear As Integer = 1
            Dim DataColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID

            EntryDates = New Generic.List(Of Date)

            FromDate = MediaPlan.StartDate

            If (MediaPlan.MediaPlanEstimate.SalesClassType <> "R" AndAlso MediaPlan.MediaPlanEstimate.SalesClassType <> "T") AndAlso
                    MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month AndAlso
                    FromDate.Day <> 1 Then

                Do Until FromDate >= MediaPlan.EndDate

                    If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                        EntryDates.Add(FromDate)

                    End If

                    If FromDate.Month = 12 Then

                        FromDateMonth = 1
                        FromDateYear = FromDate.Year + 1

                    Else

                        FromDateMonth = FromDate.Month + 1
                        FromDateYear = FromDate.Year

                    End If

                    If Date.DaysInMonth(FromDateYear, FromDateMonth) < FromDateDay Then

                        FromDate = New Date(FromDateYear, FromDateMonth, Date.DaysInMonth(FromDateYear, FromDateMonth))

                    Else

                        FromDate = New Date(FromDateYear, FromDateMonth, FromDateDay)

                    End If

                Loop

            Else

                DataColumn = MediaPlan.MediaPlanEstimate.LoadLastDateColumn()

                If MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Day Then

                    DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Day

                ElseIf MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                    DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Week

                ElseIf MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                    DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Month

                End If

                If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                    EntryDates.Add(FromDate)

                End If

                FromDate = FromDate.AddDays(1)

                Do While FromDate < MediaPlan.EndDate.AddDays(1)

                    If DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Year Then

                        If MediaPlan.MediaPlanEstimate.GetYear(FromDate.AddDays(-1)) <> MediaPlan.MediaPlanEstimate.GetYear(FromDate) Then

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                EntryDates.Add(FromDate)

                            End If

                        End If

                    ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Quarter Then

                        If MediaPlan.MediaPlanEstimate.GetQuarter(FromDate.AddDays(-1)) <> MediaPlan.MediaPlanEstimate.GetQuarter(FromDate) Then

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                EntryDates.Add(FromDate)

                            End If

                        End If

                    ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Month OrElse
                            DataColumn = AdvantageFramework.MediaPlanning.DataColumns.MonthName Then

                        If MediaPlan.MediaPlanEstimate.GetMonth(FromDate.AddDays(-1)) <> MediaPlan.MediaPlanEstimate.GetMonth(FromDate) Then

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                EntryDates.Add(FromDate)

                            End If

                        End If

                    ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Week Then

                        If MediaPlan.MediaPlanEstimate.GetWeek(FromDate.AddDays(-1)) <> MediaPlan.MediaPlanEstimate.GetWeek(FromDate) Then

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                EntryDates.Add(FromDate)

                            End If

                        End If

                    ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Day OrElse DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Date Then

                        If FromDate.AddDays(-1).Day <> FromDate.Day Then

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                EntryDates.Add(FromDate)

                            End If

                        End If

                    End If

                    FromDate = FromDate.AddDays(1)

                Loop

            End If

            ViewModel = New AdvantageFramework.ViewModels.Media.MediaPlanEstimateGRPBudgetViewModel
            ViewModel.MediaPlanDetailID = MediaPlan.MediaPlanEstimate.ID

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaPlanDetailLevelLineTags = AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineTag.LoadByMediaPlanDetailID(DbContext, MediaPlan.MediaPlanEstimate.ID).ToList

                If MediaPlanDetailLevelLineTags IsNot Nothing Then

                    MarketCodes = MediaPlanDetailLevelLineTags.Where(Function(T) String.IsNullOrWhiteSpace(T.MarketCode) = False).Select(Function(T) T.MarketCode).Distinct.ToList

                End If

                MediaPlanDetailLevelID = MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(L) L.MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length).Select(Function(L) L.ID).FirstOrDefault

                If MediaPlanDetailLevelID IsNot Nothing Then

                    SpotLengths = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLine.Load(DbContext)
                                   Where Entity.MediaPlanDetailLevelID = MediaPlanDetailLevelID.Value
                                   Select CShort(Entity.Description)).Distinct.ToList

                End If

                MediaPlanDetailGRPBudgetList = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanDetailGRPBudget)
                                                Where Entity.MediaPlanDetailID = MediaPlanDetailID AndAlso
                                                      EntryDates.Contains(Entity.EntryDate)
                                                Select Entity).ToList

                If MarketCodes IsNot Nothing Then

                    MediaPlanDetailGRPBudgetList = MediaPlanDetailGRPBudgetList.Where(Function(L) MarketCodes.Contains(L.MarketCode)).ToList

                    Markets = (From Entity In AdvantageFramework.Database.Procedures.Market.Load(DbContext)
                               Where MarketCodes.Contains(Entity.Code)
                               Select Entity).ToList

                End If

                If SpotLengths IsNot Nothing AndAlso SpotLengths.Count > 0 Then

                    MediaPlanDetailGRPBudgetList = MediaPlanDetailGRPBudgetList.Where(Function(L) SpotLengths.Contains(L.SpotLength)).ToList
                    ViewModel.HasSpotLengths = True

                End If

                If MarketCodes IsNot Nothing AndAlso ViewModel.HasSpotLengths Then

                    For Each MarketCode In MarketCodes

                        For Each SpotLength In SpotLengths

                            For Each EntryDate In EntryDates

                                If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(EntryDate) = False Then

                                    MediaPlanDetailGRPBudgetEntity = MediaPlanDetailGRPBudgetList.Where(Function(T) T.MarketCode = MarketCode AndAlso T.SpotLength = SpotLength AndAlso T.EntryDate = EntryDate).SingleOrDefault

                                    If MediaPlanDetailGRPBudgetEntity Is Nothing Then

                                        MediaPlanDetailGRPBudget = New AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget
                                        MediaPlanDetailGRPBudget.MediaPlanDetailID = MediaPlan.MediaPlanEstimate.ID
                                        MediaPlanDetailGRPBudget.EntryDate = EntryDate
                                        MediaPlanDetailGRPBudget.MarketCode = MarketCode
                                        MediaPlanDetailGRPBudget.SpotLength = SpotLength

                                    Else

                                        MediaPlanDetailGRPBudget = New AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget(MediaPlanDetailGRPBudgetEntity)

                                    End If

                                    MediaPlanDetailGRPBudget.MarketDescription = Markets.Where(Function(M) M.Code = MarketCode).First.Description

                                    ViewModel.MediaPlanDetailGRPBudgets.Add(MediaPlanDetailGRPBudget)

                                End If

                            Next

                        Next

                    Next

                ElseIf MarketCodes IsNot Nothing Then

                    For Each MarketCode In MarketCodes

                        For Each EntryDate In EntryDates

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(EntryDate) = False Then

                                MediaPlanDetailGRPBudgetEntity = MediaPlanDetailGRPBudgetList.Where(Function(T) T.MarketCode = MarketCode AndAlso T.EntryDate = EntryDate).SingleOrDefault

                                If MediaPlanDetailGRPBudgetEntity Is Nothing Then

                                    MediaPlanDetailGRPBudget = New AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget
                                    MediaPlanDetailGRPBudget.MediaPlanDetailID = MediaPlan.MediaPlanEstimate.ID
                                    MediaPlanDetailGRPBudget.EntryDate = EntryDate
                                    MediaPlanDetailGRPBudget.MarketCode = MarketCode

                                Else

                                    MediaPlanDetailGRPBudget = New AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget(MediaPlanDetailGRPBudgetEntity)

                                End If

                                MediaPlanDetailGRPBudget.MarketDescription = Markets.Where(Function(M) M.Code = MarketCode).First.Description

                                ViewModel.MediaPlanDetailGRPBudgets.Add(MediaPlanDetailGRPBudget)

                            End If

                        Next

                    Next

                End If

            End Using

            EstimateGRPBudget_Load = ViewModel

        End Function
        Public Function EstimateGRPBudget_Save(ViewModel As AdvantageFramework.ViewModels.Media.MediaPlanEstimateGRPBudgetViewModel) As Boolean

            Dim Saved As Boolean = True
            Dim MarketCodes As IEnumerable(Of String) = Nothing
            Dim SpotLengths As IEnumerable(Of Short) = Nothing
            Dim MediaPlanDetailGRPBudgetEntity As AdvantageFramework.Database.Entities.MediaPlanDetailGRPBudget = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MarketCodes = ViewModel.MediaPlanDetailGRPBudgets.Where(Function(T) String.IsNullOrWhiteSpace(T.MarketCode) = False).Select(Function(T) T.MarketCode).Distinct.ToArray
                SpotLengths = ViewModel.MediaPlanDetailGRPBudgets.Where(Function(T) T.SpotLength.HasValue).Select(Function(T) T.SpotLength.Value).Distinct.ToArray

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_DTL_GRP_BUDGET WHERE MEDIA_PLAN_DTL_ID = {0} AND MARKET_CODE NOT IN ('{1}')",
                                                                   ViewModel.MediaPlanDetailID, String.Join("','", MarketCodes)))

                    If ViewModel.HasSpotLengths Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_PLAN_DTL_GRP_BUDGET WHERE MEDIA_PLAN_DTL_ID = {0} AND SPOT_LENGTH NOT IN ({1})",
                                                                   ViewModel.MediaPlanDetailID, String.Join(",", SpotLengths)))

                    End If

                    For Each MediaPlanDetailGRPBudget In ViewModel.MediaPlanDetailGRPBudgets

                        MediaPlanDetailGRPBudgetEntity = New AdvantageFramework.Database.Entities.MediaPlanDetailGRPBudget

                        MediaPlanDetailGRPBudget.SaveToEntity(MediaPlanDetailGRPBudgetEntity)

                        If MediaPlanDetailGRPBudgetEntity.ID = 0 Then

                            MediaPlanDetailGRPBudgetEntity.DbContext = DbContext

                            DbContext.MediaPlanDetailGRPBudgets.Add(MediaPlanDetailGRPBudgetEntity)

                        Else

                            DbContext.Entry(MediaPlanDetailGRPBudgetEntity).State = Entity.EntityState.Modified

                        End If

                    Next

                    DbContext.SaveChanges()

                Catch ex As Exception
                    Saved = False
                End Try

            End Using

            EstimateGRPBudget_Save = Saved

        End Function

#End Region

#End Region

#End Region

    End Class

End Namespace
