Namespace Controller.Media

    Public Class DigitalCampaignManagerController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum QtyRateAmount
            Quantity
            Rate
            Amount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub EstimateDetail_LoadFlightGridLayout(DataContext As AdvantageFramework.Database.DataContext, ByRef ViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel)

            Dim FlightGridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing

            FlightGridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCode(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerEstimateDetailByFlight, Me.Session.UserCode)

            If FlightGridAdvantage IsNot Nothing Then

                ViewModel.EstimateDetailByFlightGridLayout = New AdvantageFramework.DTO.GridAdvantage(FlightGridAdvantage)

            Else

                ViewModel.EstimateDetailByFlightGridLayout = New AdvantageFramework.DTO.GridAdvantage

                ViewModel.EstimateDetailByFlightGridLayout.UserCode = Me.Session.UserCode
                ViewModel.EstimateDetailByFlightGridLayout.GridType = Database.Entities.GridAdvantageType.DigitalCampaignManagerEstimateDetailByFlight
                ViewModel.EstimateDetailByFlightGridLayout.GridSubtype = Nothing

            End If

        End Sub
        Private Sub EstimateDetail_LoadPeriodGridLayout(DataContext As AdvantageFramework.Database.DataContext, ByRef ViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel)

            Dim PeriodGridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing

            PeriodGridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCode(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerEstimateDetailByPeriod, Me.Session.UserCode)

            If PeriodGridAdvantage IsNot Nothing Then

                ViewModel.EstimateDetailByPeriodGridLayout = New AdvantageFramework.DTO.GridAdvantage(PeriodGridAdvantage)

            Else

                ViewModel.EstimateDetailByPeriodGridLayout = New AdvantageFramework.DTO.GridAdvantage

                ViewModel.EstimateDetailByPeriodGridLayout.UserCode = Me.Session.UserCode
                ViewModel.EstimateDetailByPeriodGridLayout.GridType = Database.Entities.GridAdvantageType.DigitalCampaignManagerEstimateDetailByFlight
                ViewModel.EstimateDetailByPeriodGridLayout.GridSubtype = Nothing

            End If

        End Sub
        Private Function GetCDPDescription(Product As AdvantageFramework.Database.Entities.Product) As String

            'objects
            Dim CDPDescription As String = String.Empty

            If Product IsNot Nothing Then

                CDPDescription = Product.Client.Name

                If Product.ClientCode <> Product.DivisionCode AndAlso Product.ClientCode <> Product.Code Then

                    CDPDescription &= " (" & Product.DivisionCode & "/" & Product.Code & ")"

                ElseIf Product.ClientCode = Product.DivisionCode AndAlso Product.ClientCode <> Product.Code Then

                    CDPDescription &= " (" & Product.Code & ")"

                ElseIf Product.ClientCode <> Product.DivisionCode AndAlso Product.ClientCode = Product.Code Then

                    CDPDescription &= " (" & Product.DivisionCode & ")"

                End If

            End If

            GetCDPDescription = CDPDescription

        End Function
        Private Function CalculateQuantity(ByVal Rate As Decimal, ByVal Amount As Decimal, ByVal QuantityScale As Short, Optional ByVal UseCPM As Boolean = False) As Decimal?

            'objects
            Dim CalculatedQuantity As Decimal? = Nothing

            Try

                CalculatedQuantity = Math.Round(Convert.ToDecimal((Amount / Rate) * If(UseCPM, 1000, 1)), If(QuantityScale > 0, QuantityScale, 0), MidpointRounding.AwayFromZero)

                If QuantityScale <= 0 Then

                    CalculatedQuantity = Convert.ToInt32(CalculatedQuantity)

                End If

            Catch ex As Exception
                CalculatedQuantity = Nothing
            Finally
                CalculateQuantity = CalculatedQuantity
            End Try

        End Function
        Private Function CalculateRate(ByVal Quantity As Decimal?, ByVal Amount As Decimal, ByVal RateScale As Short, Optional ByVal UseCPM As Boolean = False) As Decimal

            'objects
            Dim CalculatedRate As Decimal = Nothing

            Try

                CalculatedRate = Convert.ToDecimal((Amount / Quantity) * If(UseCPM, 1000, 1))

                If RateScale >= 0 Then

                    CalculatedRate = Math.Round(CalculatedRate, RateScale, MidpointRounding.AwayFromZero)

                End If

            Catch ex As Exception
                CalculatedRate = Nothing
            Finally
                CalculateRate = CalculatedRate
            End Try

        End Function
        Private Function CalculateAmount(ByVal Quantity As Decimal?, ByVal Rate As Decimal, ByVal AmountScale As Short, Optional ByVal UseCPM As Boolean = False) As Decimal

            'Objects
            Dim RealRate As Decimal = 0

            Try

                If UseCPM Then

                    RealRate = Rate / 1000

                Else

                    RealRate = Rate

                End If

                If AmountScale >= 0 Then

                    CalculateAmount = Math.Round(Convert.ToDecimal(Quantity * RealRate), AmountScale, MidpointRounding.AwayFromZero)

                Else

                    CalculateAmount = Convert.ToDecimal(Quantity * RealRate)

                End If

            Catch ex As Exception
                CalculateAmount = Nothing
            End Try

        End Function
        Private Sub CalculateQuantityRateAndAmount(ByRef Quantity As Decimal?, ByRef Rate As Decimal?, ByRef Amount As Decimal, ByVal FieldChanged As QtyRateAmount,
                                                   Optional ByVal QuantityScale As Short = 0, Optional ByVal RateScale As Short = 4, Optional ByVal AmountScale As Short = 2,
                                                   Optional ByVal UseCPM As Boolean = False)

            Try

                Select Case FieldChanged

                    Case QtyRateAmount.Quantity, QtyRateAmount.Rate

                        If Quantity IsNot Nothing AndAlso Rate IsNot Nothing Then

                            Amount = CalculateAmount(Quantity, Rate, AmountScale, UseCPM)

                            'ElseIf Quantity Is Nothing AndAlso Rate IsNot Nothing AndAlso Rate <> 0 Then

                            '    Quantity = CalculateQuantity(Rate, Amount, QuantityScale, UseCPM)

                            '    If CalculateAmount(Quantity, Rate, AmountScale) <> Amount Then

                            '        Rate = CalculateRate(Quantity, Amount, RateScale, UseCPM)

                            '    End If

                            'ElseIf Rate Is Nothing AndAlso Quantity IsNot Nothing AndAlso Quantity <> 0 Then

                            '    Rate = CalculateRate(Quantity, Amount, RateScale, UseCPM)

                        End If

                    Case QtyRateAmount.Amount

                        If Rate IsNot Nothing AndAlso Rate > 0 Then

                            Quantity = CalculateQuantity(Rate, Amount, QuantityScale, UseCPM)

                            'Else

                            '    Quantity = Nothing
                            '    Rate = Nothing

                        End If

                End Select

            Catch ex As Exception

            End Try

        End Sub
        Private Function GetMediaTypes(ViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel) As String

            Dim MediaTypes As Generic.List(Of String) = Nothing

            MediaTypes = New Generic.List(Of String)

            If ViewModel.IncludeInternet Then

                MediaTypes.Add("I")

            End If

            If ViewModel.IncludeMagazine Then

                MediaTypes.Add("M")

            End If

            If ViewModel.IncludeNewspaper Then

                MediaTypes.Add("N")

            End If

            If ViewModel.IncludeOutOfHome Then

                MediaTypes.Add("O")

            End If

            'If ViewModel.IncludeRadio Then

            '    MediaTypes.Add("R")

            'End If

            'If ViewModel.IncludeTV Then

            '    MediaTypes.Add("T")

            'End If

            GetMediaTypes = String.Join(",", MediaTypes.ToArray)

        End Function

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel

            'objects
            Dim DigitalCampaignManagerViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel = Nothing
            Dim DigitalCampaignManagerUserSetting As AdvantageFramework.Database.Entities.DigitalCampaignManagerUserSetting = Nothing
            Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing

            DigitalCampaignManagerViewModel = New AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DigitalCampaignManagerUserSetting = DbContext.DigitalCampaignManagerUserSettings.Where(Function(Entity) Entity.UserCode = Session.UserCode).SingleOrDefault

                If DigitalCampaignManagerUserSetting IsNot Nothing Then

                    DigitalCampaignManagerViewModel.IncludeInternet = DigitalCampaignManagerUserSetting.IncludeInternet
                    DigitalCampaignManagerViewModel.IncludeMagazine = DigitalCampaignManagerUserSetting.IncludeMagazine
                    DigitalCampaignManagerViewModel.IncludeNewspaper = DigitalCampaignManagerUserSetting.IncludeNewspaper
                    DigitalCampaignManagerViewModel.IncludeOutOfHome = DigitalCampaignManagerUserSetting.IncludeOutOfHome
                    'DigitalCampaignManagerViewModel.IncludeRadio = DigitalCampaignManagerUserSetting.IncludeRadio
                    'DigitalCampaignManagerViewModel.IncludeTV = DigitalCampaignManagerUserSetting.IncludeTV

                Else

                    DigitalCampaignManagerViewModel.IncludeInternet = True

                End If

                DigitalCampaignManagerViewModel.OpenPlanEstimates = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate)(String.Format("exec [advsp_digital_campaign_mgr_open_plan_estimates] '{0}', '{1}'", Session.UserCode, GetMediaTypes(DigitalCampaignManagerViewModel))).ToList

            End Using

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCode(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.DigitalCampaignManagerOpenPlanEstimates, Me.Session.UserCode)

            End Using

            If GridAdvantage IsNot Nothing Then

                DigitalCampaignManagerViewModel.OpenPlanEstimateGridLayout = New AdvantageFramework.DTO.GridAdvantage(GridAdvantage)

            Else

                DigitalCampaignManagerViewModel.OpenPlanEstimateGridLayout = New AdvantageFramework.DTO.GridAdvantage

                DigitalCampaignManagerViewModel.OpenPlanEstimateGridLayout.UserCode = Me.Session.UserCode
                DigitalCampaignManagerViewModel.OpenPlanEstimateGridLayout.GridType = Database.Entities.GridAdvantageType.DigitalCampaignManagerOpenPlanEstimates
                DigitalCampaignManagerViewModel.OpenPlanEstimateGridLayout.GridSubtype = Nothing

            End If

            Load = DigitalCampaignManagerViewModel

        End Function
        Public Sub RefreshOpenPlanEstimates(ByRef ViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ViewModel.OpenPlanEstimates = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate)(String.Format("exec [advsp_digital_campaign_mgr_open_plan_estimates] '{0}', '{1}'", Session.UserCode, GetMediaTypes(ViewModel))).ToList

            End Using

        End Sub
        Public Sub SaveUserSettings(ByRef ViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel)

            Dim DigitalCampaignManagerUserSetting As AdvantageFramework.Database.Entities.DigitalCampaignManagerUserSetting = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DigitalCampaignManagerUserSetting = DbContext.DigitalCampaignManagerUserSettings.Where(Function(Entity) Entity.UserCode = Session.UserCode).SingleOrDefault

                If DigitalCampaignManagerUserSetting IsNot Nothing Then

                    DigitalCampaignManagerUserSetting.IncludeInternet = ViewModel.IncludeInternet
                    DigitalCampaignManagerUserSetting.IncludeMagazine = ViewModel.IncludeMagazine
                    DigitalCampaignManagerUserSetting.IncludeNewspaper = ViewModel.IncludeNewspaper
                    DigitalCampaignManagerUserSetting.IncludeOutOfHome = ViewModel.IncludeOutOfHome
                    'DigitalCampaignManagerUserSetting.IncludeRadio = ViewModel.IncludeRadio
                    'DigitalCampaignManagerUserSetting.IncludeTV = ViewModel.IncludeTV

                    DbContext.TryAttach(DigitalCampaignManagerUserSetting)

                    DbContext.Entry(DigitalCampaignManagerUserSetting).State = Entity.EntityState.Modified
                    DbContext.SaveChanges()

                Else

                    DigitalCampaignManagerUserSetting = New Database.Entities.DigitalCampaignManagerUserSetting

                    DigitalCampaignManagerUserSetting.UserCode = Session.UserCode
                    DigitalCampaignManagerUserSetting.IncludeInternet = ViewModel.IncludeInternet
                    DigitalCampaignManagerUserSetting.IncludeMagazine = ViewModel.IncludeMagazine
                    DigitalCampaignManagerUserSetting.IncludeNewspaper = ViewModel.IncludeNewspaper
                    DigitalCampaignManagerUserSetting.IncludeOutOfHome = ViewModel.IncludeOutOfHome
                    'DigitalCampaignManagerUserSetting.IncludeRadio = ViewModel.IncludeRadio
                    'DigitalCampaignManagerUserSetting.IncludeTV = ViewModel.IncludeTV

                    DbContext.TryAttach(DigitalCampaignManagerUserSetting)

                    DbContext.Entry(DigitalCampaignManagerUserSetting).State = Entity.EntityState.Added
                    DbContext.SaveChanges()

                End If

            End Using

        End Sub
        Public Sub EstimateDetail_Actualize(ByRef DigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail))

            For Each DigitalEstimateDetail In DigitalEstimateDetails

                DigitalEstimateDetail.PlanImpressions = DigitalEstimateDetail.ActualImpressions
                DigitalEstimateDetail.PlanSpend = DigitalEstimateDetail.ActualSpend
                DigitalEstimateDetail.PlanRevenue = DigitalEstimateDetail.ActualRevenue
                DigitalEstimateDetail.PlanNetCharge = DigitalEstimateDetail.ActualNetCharge

                DigitalEstimateDetail.IsActualized = True

                DigitalEstimateDetail.IsDirty = True

            Next

        End Sub
        Public Sub EstimateDetail_ActualizeRollForwardAll(ByRef AllDigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail),
                                                          ByVal SelectedDigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail))

            Dim MaxYearMonth As Integer = 0
            Dim RollForwardToCount As Integer = 0
            Dim NewRemainingImpressions As Integer = 0
            Dim NewRemainingSpend As Decimal = 0
            Dim NewRemainingRevenue As Decimal = 0
            Dim NewRemainingNetCharge As Decimal = 0
            Dim LastDigitalEstimateDetail As AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail = Nothing

            For Each RowIndex In SelectedDigitalEstimateDetails.Select(Function(DED) DED.RowIndex).Distinct.ToList

                MaxYearMonth = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Max(Function(DED) DED.YearMonth)

                RollForwardToCount = AllDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex AndAlso DED.YearMonth > MaxYearMonth).Count

                If RollForwardToCount > 0 Then

                    NewRemainingImpressions = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingImpressions) / RollForwardToCount

                    If NewRemainingImpressions = 0 Then

                        NewRemainingImpressions = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingImpressions) Mod RollForwardToCount

                    End If

                    NewRemainingSpend = Fix(SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingSpend) / RollForwardToCount * 100) / 100
                    NewRemainingRevenue = Fix(SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingRevenue) / RollForwardToCount * 100) / 100
                    NewRemainingNetCharge = Fix(SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingNetCharge) / RollForwardToCount * 100) / 100

                    For Each DigitalEstimateDetail In AllDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex AndAlso DED.YearMonth > MaxYearMonth).OrderBy(Function(DED) DED.YearMonth).ToList

                        DigitalEstimateDetail.PlanSpend += If(NewRemainingSpend > 0, NewRemainingSpend, 0)
                        DigitalEstimateDetail.PlanRevenue += If(NewRemainingRevenue > 0, NewRemainingRevenue, 0)
                        DigitalEstimateDetail.PlanNetCharge += If(NewRemainingNetCharge > 0, NewRemainingNetCharge, 0)

                        If DigitalEstimateDetail.CostType <> "NA" Then

                            DigitalEstimateDetail.PlanImpressions += If(NewRemainingImpressions > 0, NewRemainingImpressions, 0)

                            If DigitalEstimateDetail.PlanRate > 0 Then

                                CalculateQuantityRateAndAmount(DigitalEstimateDetail.PlanImpressions, DigitalEstimateDetail.PlanRate, DigitalEstimateDetail.PlanSpend, QtyRateAmount.Amount, UseCPM:=DigitalEstimateDetail.IsCPM)

                            End If

                        End If

                        DigitalEstimateDetail.IsDirty = True

                        LastDigitalEstimateDetail = DigitalEstimateDetail

                    Next

                    If RollForwardToCount > 1 Then 'handle any rounding issues

                        If NewRemainingSpend > 0 AndAlso (NewRemainingSpend * RollForwardToCount) <> SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingSpend) Then

                            LastDigitalEstimateDetail.PlanSpend += SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingSpend) - (NewRemainingSpend * RollForwardToCount)

                        End If

                        If NewRemainingRevenue > 0 AndAlso (NewRemainingRevenue * RollForwardToCount) <> SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingRevenue) Then

                            LastDigitalEstimateDetail.PlanRevenue += SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingRevenue) - (NewRemainingRevenue * RollForwardToCount)

                        End If

                        If NewRemainingNetCharge > 0 AndAlso (NewRemainingNetCharge * RollForwardToCount) <> SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingNetCharge) Then

                            LastDigitalEstimateDetail.PlanNetCharge += SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingNetCharge) - (NewRemainingNetCharge * RollForwardToCount)

                        End If

                        If NewRemainingImpressions > 0 AndAlso (NewRemainingImpressions * RollForwardToCount) <> SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingImpressions) Then

                            If LastDigitalEstimateDetail.CostType <> "NA" Then

                                LastDigitalEstimateDetail.PlanImpressions += SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingImpressions) - (NewRemainingImpressions * RollForwardToCount)

                                If LastDigitalEstimateDetail.PlanRate > 0 Then

                                    CalculateQuantityRateAndAmount(LastDigitalEstimateDetail.PlanImpressions, LastDigitalEstimateDetail.PlanRate, LastDigitalEstimateDetail.PlanSpend, QtyRateAmount.Amount, UseCPM:=LastDigitalEstimateDetail.IsCPM)

                                End If

                            End If

                        End If

                    End If

                End If

            Next

            EstimateDetail_Actualize(SelectedDigitalEstimateDetails)

        End Sub
        Public Sub EstimateDetail_ActualizeRollForwardNext(ByRef AllDigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail),
                                                           ByVal SelectedDigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail))

            Dim MaxYearMonth As Integer = 0
            Dim RollForwardToDigitalEstimateDetail As AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail = Nothing
            Dim NewRemainingImpressions As Integer = 0
            Dim NewRemainingSpend As Decimal = 0
            Dim NewRemainingRevenue As Decimal = 0
            Dim NewRemainingNetCharge As Decimal = 0

            For Each RowIndex In SelectedDigitalEstimateDetails.Select(Function(DED) DED.RowIndex).Distinct.ToList

                MaxYearMonth = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Max(Function(DED) DED.YearMonth)

                RollForwardToDigitalEstimateDetail = AllDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex AndAlso DED.YearMonth > MaxYearMonth).OrderBy(Function(DED) DED.YearMonth).FirstOrDefault

                If RollForwardToDigitalEstimateDetail IsNot Nothing Then

                    NewRemainingImpressions = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingImpressions)

                    NewRemainingSpend = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingSpend)
                    NewRemainingRevenue = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingRevenue)
                    NewRemainingNetCharge = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingNetCharge)

                    RollForwardToDigitalEstimateDetail.PlanSpend += If(NewRemainingSpend > 0, NewRemainingSpend, 0)
                    RollForwardToDigitalEstimateDetail.PlanRevenue += If(NewRemainingRevenue > 0, NewRemainingRevenue, 0)
                    RollForwardToDigitalEstimateDetail.PlanNetCharge += If(NewRemainingNetCharge > 0, NewRemainingNetCharge, 0)

                    If RollForwardToDigitalEstimateDetail.CostType <> "NA" Then

                        RollForwardToDigitalEstimateDetail.PlanImpressions += If(NewRemainingImpressions > 0, NewRemainingImpressions, 0)

                        If RollForwardToDigitalEstimateDetail.PlanRate > 0 Then

                            CalculateQuantityRateAndAmount(RollForwardToDigitalEstimateDetail.PlanImpressions, RollForwardToDigitalEstimateDetail.PlanRate, RollForwardToDigitalEstimateDetail.PlanSpend, QtyRateAmount.Amount, UseCPM:=RollForwardToDigitalEstimateDetail.IsCPM)

                        End If

                    End If

                    RollForwardToDigitalEstimateDetail.IsDirty = True

                End If

            Next

            EstimateDetail_Actualize(SelectedDigitalEstimateDetails)

        End Sub
        Public Sub EstimateDetail_ActualizeRollForwardPercent(ByRef AllDigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail),
                                                              ByVal SelectedDigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail))

            Dim MaxYearMonth As Integer = 0
            Dim RollForwardToDigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail) = Nothing
            Dim NewRemainingImpressions As Integer = 0
            Dim NewRemainingSpend As Decimal = 0
            Dim NewRemainingRevenue As Decimal = 0
            Dim NewRemainingNetCharge As Decimal = 0
            Dim WeightedPercent As Decimal = 0
            Dim LastDigitalEstimateDetail As AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail = Nothing
            Dim AppliedImpressions As Integer = 0
            Dim AppliedSpend As Decimal = 0
            Dim AppliedRevenue As Decimal = 0
            Dim AppliedNetCharge As Decimal = 0

            For Each RowIndex In SelectedDigitalEstimateDetails.Select(Function(DED) DED.RowIndex).Distinct.ToList

                MaxYearMonth = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Max(Function(DED) DED.YearMonth)

                RollForwardToDigitalEstimateDetails = AllDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex AndAlso DED.YearMonth > MaxYearMonth).ToList

                If RollForwardToDigitalEstimateDetails IsNot Nothing AndAlso RollForwardToDigitalEstimateDetails.Count > 0 Then

                    AppliedImpressions = 0
                    AppliedSpend = 0
                    AppliedRevenue = 0
                    AppliedNetCharge = 0

                    NewRemainingImpressions = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingImpressions)

                    NewRemainingSpend = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingSpend)
                    NewRemainingRevenue = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingRevenue)
                    NewRemainingNetCharge = SelectedDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex).Sum(Function(DED) DED.RemainingNetCharge)

                    For Each DigitalEstimateDetail In AllDigitalEstimateDetails.Where(Function(DED) DED.RowIndex = RowIndex AndAlso DED.YearMonth > MaxYearMonth).OrderBy(Function(DED) DED.YearMonth).ToList

                        WeightedPercent = FormatNumber(DigitalEstimateDetail.PlanSpend / RollForwardToDigitalEstimateDetails.Sum(Function(DED) DED.PlanSpend), 5)

                        If NewRemainingSpend > 0 Then

                            DigitalEstimateDetail.PlanSpend += FormatNumber(NewRemainingSpend * WeightedPercent, 2)
                            AppliedSpend += FormatNumber(NewRemainingSpend * WeightedPercent, 2)

                        End If

                        If NewRemainingRevenue > 0 Then

                            DigitalEstimateDetail.PlanRevenue += FormatNumber(NewRemainingRevenue * WeightedPercent, 2)
                            AppliedRevenue += FormatNumber(NewRemainingRevenue * WeightedPercent, 2)

                        End If

                        If NewRemainingNetCharge > 0 Then

                            DigitalEstimateDetail.PlanNetCharge += FormatNumber(NewRemainingNetCharge * WeightedPercent, 2)
                            AppliedNetCharge += FormatNumber(NewRemainingNetCharge * WeightedPercent, 2)

                        End If

                        If NewRemainingImpressions > 0 Then

                            If DigitalEstimateDetail.CostType <> "NA" Then

                                DigitalEstimateDetail.PlanImpressions += Math.Round(Fix(NewRemainingImpressions * WeightedPercent * 100) / 100, MidpointRounding.AwayFromZero)

                                If DigitalEstimateDetail.PlanRate > 0 Then

                                    CalculateQuantityRateAndAmount(DigitalEstimateDetail.PlanImpressions, DigitalEstimateDetail.PlanRate, DigitalEstimateDetail.PlanSpend, QtyRateAmount.Amount, UseCPM:=DigitalEstimateDetail.IsCPM)

                                End If

                            End If

                            AppliedImpressions += Math.Round(Fix(NewRemainingImpressions * WeightedPercent * 100) / 100, MidpointRounding.AwayFromZero)

                        End If

                        DigitalEstimateDetail.IsDirty = True

                        LastDigitalEstimateDetail = DigitalEstimateDetail

                    Next

                    If RollForwardToDigitalEstimateDetails.Count > 1 Then 'handle any rounding issues

                        If NewRemainingSpend > 0 AndAlso NewRemainingSpend <> AppliedSpend Then

                            LastDigitalEstimateDetail.PlanSpend += NewRemainingSpend - AppliedSpend

                        End If

                        If NewRemainingRevenue > 0 AndAlso NewRemainingRevenue <> AppliedRevenue Then

                            LastDigitalEstimateDetail.PlanRevenue += NewRemainingRevenue - AppliedRevenue

                        End If

                        If NewRemainingNetCharge > 0 AndAlso NewRemainingNetCharge <> AppliedNetCharge Then

                            LastDigitalEstimateDetail.PlanNetCharge += NewRemainingNetCharge - AppliedNetCharge

                        End If

                        If NewRemainingImpressions > 0 AndAlso NewRemainingImpressions <> AppliedImpressions Then

                            If LastDigitalEstimateDetail.CostType <> "NA" Then

                                LastDigitalEstimateDetail.PlanImpressions += NewRemainingImpressions - AppliedImpressions

                                If LastDigitalEstimateDetail.PlanRate > 0 Then

                                    CalculateQuantityRateAndAmount(LastDigitalEstimateDetail.PlanImpressions, LastDigitalEstimateDetail.PlanRate, LastDigitalEstimateDetail.PlanSpend, QtyRateAmount.Amount, UseCPM:=LastDigitalEstimateDetail.IsCPM)

                                End If

                            End If

                        End If

                    End If

                End If

            Next

            EstimateDetail_Actualize(SelectedDigitalEstimateDetails)

        End Sub
        Public Sub EstimateDetail_Recalculate(ByRef DigitalEstimateDetail As AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail, ByVal FieldChanged As QtyRateAmount)

            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            CalculateQuantityRateAndAmount(DigitalEstimateDetail.PlanImpressions, DigitalEstimateDetail.PlanRate, DigitalEstimateDetail.PlanSpend, FieldChanged, UseCPM:=DigitalEstimateDetail.IsCPM)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AdvantageFramework.MediaPlanning.SetProductAmountValues(DbContext, DigitalEstimateDetail.ClientCode, DigitalEstimateDetail.DivisionCode, DigitalEstimateDetail.ProductCode, DigitalEstimateDetail.SalesClassType,
                                                                        DigitalEstimateDetail.SalesClassCode, DigitalEstimateDetail.ProductUsesNetAmount, DigitalEstimateDetail.ProductRebateAmount, DigitalEstimateDetail.ProductMarkupAmount)

                MediaPlanDetailLevelLineData = New Database.Entities.MediaPlanDetailLevelLineData()

                MediaPlanDetailLevelLineData.Dollars = DigitalEstimateDetail.PlanSpend
                MediaPlanDetailLevelLineData.BillAmount = DigitalEstimateDetail.PlanRevenue
                MediaPlanDetailLevelLineData.NetCharge = DigitalEstimateDetail.PlanNetCharge
                MediaPlanDetailLevelLineData.AgencyFee = DigitalEstimateDetail.AgencyFee

                AdvantageFramework.MediaPlanning.CalculateMediaPlanDetailLevelLineData(DigitalEstimateDetail.IsEstimateGrossAmount, DigitalEstimateDetail.VendorCommission, DigitalEstimateDetail.VendorMarkup,
                                                                                       DigitalEstimateDetail.ProductUsesNetAmount, DigitalEstimateDetail.ProductRebateAmount, DigitalEstimateDetail.ProductMarkupAmount,
                                                                                       MediaPlanDetailLevelLineData)

                DigitalEstimateDetail.PlanRevenue = MediaPlanDetailLevelLineData.BillAmount
                DigitalEstimateDetail.IsDirty = True

            End Using

        End Sub
        Public Function EstimateDetail_Load(OpenPlanEstimateList As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.OpenPlanEstimate)) As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel

            'objects
            Dim DigitalCampaignManagerViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel = Nothing
            Dim MediaPlanDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            DigitalCampaignManagerViewModel = New AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DigitalCampaignManagerViewModel.IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                DigitalCampaignManagerViewModel.HostedPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                If String.IsNullOrWhiteSpace(DigitalCampaignManagerViewModel.HostedPath) = False Then

                    If DigitalCampaignManagerViewModel.HostedPath.EndsWith("\") = False Then

                        DigitalCampaignManagerViewModel.HostedPath += "\"

                    End If

                    DigitalCampaignManagerViewModel.HostedPath += "Reports\"

                End If

                MediaPlanDetailIDs = OpenPlanEstimateList.Select(Function(OPE) OPE.MediaPlanDetailID).Distinct.ToArray

                DigitalCampaignManagerViewModel.DigitalEstimateDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail)(String.Format("exec advsp_digital_campaign_mgr_estimate_detail '{0}'", String.Join(",", MediaPlanDetailIDs.ToArray))).ToList

                If OpenPlanEstimateList.Count = 1 Then

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, OpenPlanEstimateList.First.ClientCode, OpenPlanEstimateList.First.DivisionCode, OpenPlanEstimateList.First.ProductCode)

                    If Product IsNot Nothing Then

                        DigitalCampaignManagerViewModel.CDPDescription = GetCDPDescription(Product)

                    End If

                End If

            End Using

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EstimateDetail_LoadFlightGridLayout(DataContext, DigitalCampaignManagerViewModel)

                EstimateDetail_LoadPeriodGridLayout(DataContext, DigitalCampaignManagerViewModel)

            End Using

            DigitalCampaignManagerViewModel.AllowActualizationToVaryFromLastPlan = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaPlanning_Actions_AllowActualizationToVaryFromLastPlan, Me.Session.User)

            EstimateDetail_Load = DigitalCampaignManagerViewModel

        End Function
        Public Function EstimateDetail_Load(MediaPlanDetailID As Integer) As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel

            'objects
            Dim DigitalCampaignManagerViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing

            DigitalCampaignManagerViewModel = New AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DigitalCampaignManagerViewModel.DigitalEstimateDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail)(String.Format("exec advsp_digital_campaign_mgr_estimate_detail {0}", MediaPlanDetailID)).ToList

                Try

                    MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID)

                    If MediaPlanDetail IsNot Nothing AndAlso MediaPlanDetail.MediaPlan IsNot Nothing Then

                        If MediaPlanDetail.MediaPlan.Product IsNot Nothing Then

                            DigitalCampaignManagerViewModel.CDPDescription = GetCDPDescription(MediaPlanDetail.MediaPlan.Product)

                        End If

                        DigitalCampaignManagerViewModel.MediaPlanActualizeDialogText = "Media Plan Actualize - [Media Plan - " & MediaPlanDetail.MediaPlan.Description & " (" & MediaPlanDetail.Name & ") - " & DigitalCampaignManagerViewModel.CDPDescription & "]"

                    End If

                Catch ex As Exception

                End Try

            End Using

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                'EstimateDetail_LoadFlightGridLayout(DataContext, DigitalCampaignManagerViewModel)

                EstimateDetail_LoadPeriodGridLayout(DataContext, DigitalCampaignManagerViewModel)

            End Using

            DigitalCampaignManagerViewModel.AllowActualizationToVaryFromLastPlan = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaPlanning_Actions_AllowActualizationToVaryFromLastPlan, Me.Session.User)

            EstimateDetail_Load = DigitalCampaignManagerViewModel

        End Function
        Public Function EstimateDetail_Save(ByVal DigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail), MediaPlanDetailID As Integer,
                                            ByRef ViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel, ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    For Each DigitalEstimateDetail In DigitalEstimateDetails

                        MediaPlanDetailLevelLineData = AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanDetailLevelLineDataID(DbContext, DigitalEstimateDetail.MediaPlanDetailLevelLineDataID)

                        If MediaPlanDetailLevelLineData IsNot Nothing Then

                            If DigitalEstimateDetail.CostType = "CPA" Then

                                MediaPlanDetailLevelLineData.Units = DigitalEstimateDetail.PlanImpressions
                                MediaPlanDetailLevelLineData.Clicks = Nothing
                                MediaPlanDetailLevelLineData.Impressions = Nothing

                            ElseIf DigitalEstimateDetail.CostType = "CPC" Then

                                MediaPlanDetailLevelLineData.Clicks = DigitalEstimateDetail.PlanImpressions
                                MediaPlanDetailLevelLineData.Units = Nothing
                                MediaPlanDetailLevelLineData.Impressions = Nothing

                            ElseIf DigitalEstimateDetail.CostType = "CPI" Then

                                MediaPlanDetailLevelLineData.Impressions = DigitalEstimateDetail.PlanImpressions
                                MediaPlanDetailLevelLineData.Units = Nothing
                                MediaPlanDetailLevelLineData.Clicks = Nothing

                            ElseIf DigitalEstimateDetail.CostType = "NA" Then

                                MediaPlanDetailLevelLineData.Units = Nothing
                                MediaPlanDetailLevelLineData.Clicks = Nothing
                                MediaPlanDetailLevelLineData.Impressions = Nothing

                            End If

                            MediaPlanDetailLevelLineData.Rate = DigitalEstimateDetail.PlanRate
                            MediaPlanDetailLevelLineData.Dollars = DigitalEstimateDetail.PlanSpend
                            MediaPlanDetailLevelLineData.BillAmount = DigitalEstimateDetail.PlanRevenue
                            MediaPlanDetailLevelLineData.NetCharge = DigitalEstimateDetail.PlanNetCharge

                            If DigitalEstimateDetail.IsActualized Then

                                MediaPlanDetailLevelLineData.IsActualized = True

                            End If

                            MediaPlanDetailLevelLineData.ModifiedByUserCode = DbContext.UserCode
                            MediaPlanDetailLevelLineData.ModifiedDate = Now

                            DbContext.Entry(MediaPlanDetailLevelLineData).State = Entity.EntityState.Modified

                        End If

                    Next

                    DbContext.SaveChanges()

                    Saved = True

                    ViewModel.DigitalEstimateDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail)(String.Format("exec advsp_digital_campaign_mgr_estimate_detail {0}", MediaPlanDetailID)).ToList

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message
            End Try

            EstimateDetail_Save = Saved

        End Function
        Public Function EstimateDetail_AllowSave(DigitalEstimateDetails As Generic.List(Of AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail), AllowActualizationToVaryFromLastPlan As Boolean,
                                                 ByRef IssueWarning As Boolean) As Boolean

            Dim AllowSave As Boolean = True
            Dim EstimateLines As IEnumerable(Of Integer) = Nothing
            Dim DoesNotMatch As Boolean = False

            EstimateLines = DigitalEstimateDetails.Select(Function(DED) DED.EstimateLine).Distinct.ToArray

            For Each EstLine In EstimateLines

                If DigitalEstimateDetails.Where(Function(DED) DED.EstimateLine = EstLine).Sum(Function(DED) DED.PlanSpend) <> DigitalEstimateDetails.Where(Function(DED) DED.EstimateLine = EstLine).Sum(Function(DED) DED.OrigPlanSpend) Then

                    DoesNotMatch = True
                    Exit For

                End If

            Next

            If AllowActualizationToVaryFromLastPlan = False AndAlso DoesNotMatch Then

                AllowSave = False

            ElseIf AllowActualizationToVaryFromLastPlan AndAlso DoesNotMatch Then

                IssueWarning = True

            End If

            EstimateDetail_AllowSave = AllowSave

        End Function
        Public Sub Reset_FlightGridLayout(DigitalCampaignManagerViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel)

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EstimateDetail_LoadFlightGridLayout(DataContext, DigitalCampaignManagerViewModel)

            End Using

        End Sub
        Public Sub Reset_PeriodGridLayout(DigitalCampaignManagerViewModel As AdvantageFramework.ViewModels.Media.DigitalCampaignManager.ViewModel)

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EstimateDetail_LoadPeriodGridLayout(DataContext, DigitalCampaignManagerViewModel)

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace
