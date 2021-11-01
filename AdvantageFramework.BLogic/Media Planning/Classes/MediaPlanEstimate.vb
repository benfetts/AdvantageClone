Namespace MediaPlanning.Classes

    Public Class MediaPlanEstimate

        Public Event EstimateChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SalesClassType
            SalesClassCode
            MediaPlan
            Product
            IsEstimateGrossAmount
            IsCalendarMonth
            ShowColumnTotals
            ShowRowTotals
            ShowColumnGrandTotals
            ShowRowGrandTotals
            CalculateDollars
            Color
            Notes
            SplitWeeks
            CampaignID
            MediaPlanDetailLevelLineDatas
            MediaPlanDetailLevels
            MediaPlanDetailFields
            MediaPlanDetailSettings
            MediaPlanDetailChangeLogs
            Filter_MarketTagType
            Filter_VendorTagType
            Filter_AdSizeTagType
            Filter_InternetTypeTagType
            Filter_OutOfHomeTypeTagType
            Filter_DaypartTagType
            Filter_AdNumberTagType
            Filter_JobComponentTagType
            Filter_JobComponentNumberTagType
            Filter_CampaignTagType
            Filter_MediaChannelTagType
            Filter_MediaTacticTagType
            QuarterPrefix
            GrossPercentageInTotals
            GrossPercentageInTotalField
            WeekDisplayType
            IsUnitsCPM
            IsImpressionsCPM
            IsClicksCPM
            NetDollars
            CPP1
            CPP2
            CPI
            FirstVisibleQuantityColumn
            SecondVisibleQuantityColumn
            ThirdVisibleQuantityColumn
            SalesClassTypeEnumObject
            IsLoaded
            OrderNumber
            ProductUsesNetAmount
            ProductRebateAmount
            ProductMarkupAmount
            HiatusWeeks
            HiatusMonths
            DaysOfWeekType
            DaysOfWeekCaption
        End Enum

#End Region

#Region " Variables "

        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _Product As AdvantageFramework.Database.Entities.Product = Nothing
        Private _MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
        Private _Filter_MarketTagType As String = ""
        Private _Filter_MarketOrderLineTagType As String = ""
        Private _Filter_VendorTagType As String = ""
        Private _Filter_AdSizeTagType As String = ""
        Private _Filter_InternetTypeTagType As String = ""
        Private _Filter_OutOfHomeTypeTagType As String = ""
        Private _Filter_AdNumberTagType As String = ""
        Private _Filter_DaypartTagType As String = ""
        Private _Filter_JobComponentTagType As String = ""
        Private _Filter_JobComponentNumberTagType As String = ""
        Private _Filter_CampaignTagType As String = ""
        Private _Filter_MediaChannelTagType As String = ""
        Private _Filter_MediaTacticTagType As String = ""
        Private _QuarterPrefix As String = ""
        Private _GrossPercentageInTotals As Boolean = False
        Private _GrossPercentageInTotalField As String = ""
        Private _GrossPercentageInTotalsCaption As String = MediaPlanning.GrossPercentageInTotalsCaption
        Private _GrossPercentageInTotalsIndex As Integer = -1
        Private _GrossPercentageInTotalsShowTotals As Boolean = False
        Private _GrossPercentageInTotalsWidth As Integer = 100
        Private _WeekDisplayType As AdvantageFramework.MediaPlanning.WeekDisplayTypes = MediaPlanning.WeekDisplayTypes.WeekStartDay
        Private _IsUnitsCPM As Boolean = False
        Private _IsImpressionsCPM As Boolean = False
        Private _IsClicksCPM As Boolean = False
        Private _NetDollars As Boolean = False
        Private _NetDollarsCaption As String = MediaPlanning.NetDollarsCaption
        Private _NetDollarsIndex As Integer = -1
        Private _NetDollarsShowTotals As Boolean = False
        Private _NetDollarsWidth As Integer = 100
        Private _CPP1 As Boolean = False
        Private _CPP1Caption As String = MediaPlanning.CPP1Caption
        Private _CPP1Index As Integer = -1
        Private _CPP1ShowTotals As Boolean = False
        Private _CPP1Width As Integer = 100
        Private _CPP2 As Boolean = False
        Private _CPP2Caption As String = MediaPlanning.CPP2Caption
        Private _CPP2Index As Integer = -1
        Private _CPP2ShowTotals As Boolean = False
        Private _CPP2Width As Integer = 100
        Private _CPI As Boolean = False
        Private _CPICaption As String = MediaPlanning.CPICaption
        Private _CPIIndex As Integer = -1
        Private _CPIShowTotals As Boolean = False
        Private _CPIWidth As Integer = 100
        Private _CTR As Boolean = False
        Private _CTRCaption As String = MediaPlanning.CTRCaption
        Private _CTRIndex As Integer = -1
        Private _CTRShowTotals As Boolean = False
        Private _CTRWidth As Integer = 100
        Private _ConversionRate As Boolean = False
        Private _ConversionRateCaption As String = MediaPlanning.ConversionRateCaption
        Private _ConversionRateIndex As Integer = -1
        Private _ConversionRateShowTotals As Boolean = False
        Private _ConversionRateWidth As Integer = 100
        Private _TotalDemo1 As Boolean = False
        Private _TotalDemo1Caption As String = MediaPlanning.TotalDemo1Caption
        Private _TotalDemo1Index As Integer = -1
        Private _TotalDemo1ShowTotals As Boolean = False
        Private _TotalDemo1Width As Integer = 100
        Private _TotalDemo2 As Boolean = False
        Private _TotalDemo2Caption As String = MediaPlanning.TotalDemo2Caption
        Private _TotalDemo2Index As Integer = -1
        Private _TotalDemo2ShowTotals As Boolean = False
        Private _TotalDemo2Width As Integer = 100
        Private _TotalNet As Boolean = False
        Private _TotalNetCaption As String = MediaPlanning.TotalNetCaption
        Private _TotalNetIndex As Integer = -1
        Private _TotalNetShowTotals As Boolean = False
        Private _TotalNetWidth As Integer = 100
        Private _Commission As Boolean = False
        Private _CommissionCaption As String = MediaPlanning.CommissionCaption
        Private _CommissionIndex As Integer = -1
        Private _CommissionShowTotals As Boolean = False
        Private _CommissionWidth As Integer = 100
        Private _FirstVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
        Private _SecondVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
        Private _ThirdVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
        Private _FourthVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
        Private _FifthVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
        Private _SalesClassTypeEnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
        Public WithEvents EstimateDataTable As System.Data.DataTable = Nothing
        Public WithEvents LevelsAndLinesDataTable As System.Data.DataTable = Nothing
        Private _IsLevelsAndLinesDataTableSaving As Boolean = False
        Private _IsEstimateDataTableSaving As Boolean = False
        Private _PreventAutoCalcOfMediaPlanDetailLevelLineData As Boolean = False
        Private _IsDataLoaded As Boolean = False
        Private _IsLevelAndLinesLoaded As Boolean = False
        Private _BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
        Private _ProductUsesNetAmount As Boolean = False
        Private _ProductRebateAmount As Decimal = 0
        Private _ProductMarkupAmount As Decimal = 0
        Private _HiatusWeeks As Generic.List(Of Date) = Nothing
        Private _HiatusMonths As Generic.List(Of Date) = Nothing
        Private _DaysOfWeekType As Integer = 0
        Private _DaysOfWeekCaption As String = ""
        Private _HasChanged As Boolean = False
        Private _EntryDates() As Date = Nothing
        Private _FreezeLevels As Boolean = False
        Private _ShowPackageLevels As Integer = 0
        Private _ShowPackageName As Boolean = False
        Private _ShowAdSizes As Boolean = False
        Private _AdSizesCaption As String = ""
        Private _AdSizesWidth As Integer = 100
        Private _PackageLevelWidth As Integer = 100
        Private _PackageNames As Generic.List(Of String) = Nothing
        Private _ShowDateRange As Boolean = False
        Private _DateRangeCaption As String = ""
        Private _DateRangeWidth As Integer = 100
        Private _PackageLevelIndex As Integer = -1
        Private _DateRangeIndex As Integer = -1
        Private _AdSizesIndex As Integer = -1
        Private _PackageNameCaption As String = ""
        'Private _FirstVisibleQuantityColumnForCalculationOnly As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
        Private _PackagePlacementWidth As Integer = 100

#End Region

#Region " Properties "

        Public ReadOnly Property MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan
            Get
                MediaPlan = _MediaPlan
            End Get
        End Property
        Public ReadOnly Property ID As Integer
            Get
                ID = _MediaPlanDetail.ID
            End Get
        End Property
        Public ReadOnly Property SalesClassType As String
            Get
                SalesClassType = _MediaPlanDetail.SalesClassType
            End Get
        End Property
        Public ReadOnly Property SalesClassCode As String
            Get
                SalesClassCode = _MediaPlanDetail.SalesClassCode
            End Get
        End Property
        Public ReadOnly Property Product() As AdvantageFramework.Database.Entities.Product
            Get
                Product = _Product
            End Get
        End Property
        Public Property IsEstimateGrossAmount() As Boolean
            Get
                IsEstimateGrossAmount = _MediaPlanDetail.IsEstimateGrossAmount
            End Get
            Set(ByVal value As Boolean)

                If value <> _MediaPlanDetail.IsEstimateGrossAmount Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.IsEstimateGrossAmount = value

            End Set
        End Property
        Public Property IsCalendarMonth() As Boolean
            Get
                IsCalendarMonth = _MediaPlanDetail.IsCalendarMonth
            End Get
            Set(ByVal value As Boolean)

                If value <> _MediaPlanDetail.IsCalendarMonth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.IsCalendarMonth = value

            End Set
        End Property
        Public Property ShowColumnTotals() As Boolean
            Get
                ShowColumnTotals = _MediaPlanDetail.ShowColumnTotals
            End Get
            Set(value As Boolean)

                If value <> _MediaPlanDetail.ShowColumnTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.ShowColumnTotals = value

            End Set
        End Property
        Public Property ShowRowTotals() As Boolean
            Get
                ShowRowTotals = _MediaPlanDetail.ShowRowTotals
            End Get
            Set(value As Boolean)

                If value <> _MediaPlanDetail.ShowRowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.ShowRowTotals = value

            End Set
        End Property
        Public Property ShowRowTotalsValues() As Boolean
            Get
                ShowRowTotalsValues = _MediaPlanDetail.ShowRowTotalsValues
            End Get
            Set(value As Boolean)

                If value <> _MediaPlanDetail.ShowRowTotalsValues Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.ShowRowTotalsValues = value

            End Set
        End Property
        Public Property ShowColumnGrandTotals() As Boolean
            Get
                ShowColumnGrandTotals = _MediaPlanDetail.ShowColumnGrandTotals
            End Get
            Set(value As Boolean)

                If value <> _MediaPlanDetail.ShowColumnGrandTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.ShowColumnGrandTotals = value

            End Set
        End Property
        Public Property ShowRowGrandTotals() As Boolean
            Get
                ShowRowGrandTotals = _MediaPlanDetail.ShowRowGrandTotals
            End Get
            Set(value As Boolean)

                If value <> _MediaPlanDetail.ShowRowGrandTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.ShowRowGrandTotals = value

            End Set
        End Property
        Public Property ShowRowGrandTotalsValues() As Boolean
            Get
                ShowRowGrandTotalsValues = _MediaPlanDetail.ShowRowGrandTotalsValues
            End Get
            Set(value As Boolean)

                If value <> _MediaPlanDetail.ShowRowGrandTotalsValues Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.ShowRowGrandTotalsValues = value

            End Set
        End Property
        'Public Property CalculateDollars() As Boolean
        '    Get
        '        CalculateDollars = _MediaPlanDetail.CalculateDollars
        '    End Get
        '    Set(value As Boolean)

        '        If value <> _MediaPlanDetail.CalculateDollars Then

        '            RaiseEvent EstimateChangedEvent()

        '        End If

        '        _MediaPlanDetail.CalculateDollars = value

        '    End Set
        'End Property
        Public Property SplitWeeks() As Boolean
            Get
                SplitWeeks = _MediaPlanDetail.SplitWeeks
            End Get
            Set(ByVal value As Boolean)

                If value <> _MediaPlanDetail.SplitWeeks Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.SplitWeeks = value

            End Set
        End Property
        Public Property Color() As Integer
            Get
                Color = _MediaPlanDetail.Color
            End Get
            Set(ByVal value As Integer)

                If value <> _MediaPlanDetail.Color Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.Color = value

            End Set
        End Property
        Public Property Notes() As String
            Get
                Notes = _MediaPlanDetail.Notes
            End Get
            Set(ByVal value As String)

                If value <> _MediaPlanDetail.Notes Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.Notes = value

            End Set
        End Property
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _MediaPlanDetail.CampaignID
            End Get
            Set(value As Nullable(Of Integer))

                If value.GetValueOrDefault(0) <> _MediaPlanDetail.CampaignID.GetValueOrDefault(0) Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.CampaignID = value

            End Set
        End Property
        Public Property BuyerEmployeeCode() As String
            Get
                BuyerEmployeeCode = _MediaPlanDetail.BuyerEmployeeCode
            End Get
            Set(value As String)

                If value <> _MediaPlanDetail.BuyerEmployeeCode Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.BuyerEmployeeCode = value

            End Set
        End Property
        Public Property IsCable() As Boolean
            Get
                IsCable = _MediaPlanDetail.IsCable
            End Get
            Set(ByVal value As Boolean)

                If value <> _MediaPlanDetail.IsCable Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.IsCable = value

            End Set
        End Property
        Public Property AllowCampaignLevel() As Boolean
            Get
                AllowCampaignLevel = _MediaPlanDetail.AllowCampaignLevel
            End Get
            Set(ByVal value As Boolean)

                If value <> _MediaPlanDetail.AllowCampaignLevel Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.AllowCampaignLevel = value

            End Set
        End Property
        Public Property PeriodType() As AdvantageFramework.MediaPlanning.PeriodTypes
            Get
                PeriodType = _MediaPlanDetail.PeriodType
            End Get
            Set(ByVal value As AdvantageFramework.MediaPlanning.PeriodTypes)

                If CInt(value) <> _MediaPlanDetail.PeriodType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.PeriodType = CInt(value)

            End Set
        End Property
        Public Property CreateOrderOption() As Integer
            Get
                CreateOrderOption = _MediaPlanDetail.CreateOrderOption
            End Get
            Set(value As Integer)
                _MediaPlanDetail.CreateOrderOption = value
            End Set
        End Property
        Public Property GrossBudgetAmount() As Decimal
            Get
                GrossBudgetAmount = _MediaPlanDetail.GrossBudgetAmount
            End Get
            Set(value As Decimal)

                If value <> _MediaPlanDetail.GrossBudgetAmount Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.GrossBudgetAmount = value

            End Set
        End Property
        Public Property RatingsServiceID() As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID
            Get
                RatingsServiceID = _MediaPlanDetail.RatingsServiceID
            End Get
            Set(value As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID)

                If value <> _MediaPlanDetail.RatingsServiceID Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.RatingsServiceID = value

            End Set
        End Property
        Public Property MediaDemographicID() As Nullable(Of Integer)
            Get
                MediaDemographicID = _MediaPlanDetail.MediaDemographicID
            End Get
            Set(value As Nullable(Of Integer))

                If value <> _MediaPlanDetail.MediaDemographicID Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.MediaDemographicID = value

            End Set
        End Property
        Public ReadOnly Property MediaPlanDetailLevelLineDatas() As ICollection(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)
            Get
                MediaPlanDetailLevelLineDatas = _MediaPlanDetail.MediaPlanDetailLevelLineDatas
            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailLevels() As ICollection(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel)
            Get
                MediaPlanDetailLevels = _MediaPlanDetail.MediaPlanDetailLevels
            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailFields() As ICollection(Of AdvantageFramework.Database.Entities.MediaPlanDetailField)
            Get
                MediaPlanDetailFields = _MediaPlanDetail.MediaPlanDetailFields
            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailSettings() As ICollection(Of AdvantageFramework.Database.Entities.MediaPlanDetailSetting)
            Get
                MediaPlanDetailSettings = _MediaPlanDetail.MediaPlanDetailSettings
            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailChangeLogs() As ICollection(Of AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog)
            Get
                MediaPlanDetailChangeLogs = _MediaPlanDetail.MediaPlanDetailChangeLogs
            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailPackageDetails() As ICollection(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail)
            Get
                MediaPlanDetailPackageDetails = _MediaPlanDetail.MediaPlanDetailPackageDetails
            End Get
        End Property
        Public ReadOnly Property MediaPlanDetailPackagePlacementNames() As ICollection(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName)
            Get
                MediaPlanDetailPackagePlacementNames = _MediaPlanDetail.MediaPlanDetailPackagePlacementNames
            End Get
        End Property
        Public Property Filter_AdSizeTagType As String
            Get
                Filter_AdSizeTagType = _Filter_AdSizeTagType
            End Get
            Set(value As String)

                If value <> _Filter_AdSizeTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_AdSizeTagType = value

                SaveFilter_AdSizeTagTypeSetting()

            End Set
        End Property
        Public Property Filter_DaypartTagType As String
            Get
                Filter_DaypartTagType = _Filter_DaypartTagType
            End Get
            Set(value As String)

                If value <> _Filter_DaypartTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_DaypartTagType = value

                SaveFilter_DaypartTagTypeSetting()

            End Set
        End Property
        Public Property Filter_MarketTagType As String
            Get
                Filter_MarketTagType = _Filter_MarketTagType
            End Get
            Set(value As String)

                If value <> _Filter_MarketTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_MarketTagType = value

                SaveFilter_MarketTagTypeSetting()

            End Set
        End Property
        Public Property Filter_MarketOrderLineTagType As String
            Get
                Filter_MarketOrderLineTagType = _Filter_MarketOrderLineTagType
            End Get
            Set(value As String)

                If value <> _Filter_MarketOrderLineTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_MarketOrderLineTagType = value

                SaveFilter_MarketOrderLineTagTypeSetting()

            End Set
        End Property
        Public Property Filter_CampaignTagType As String
            Get
                Filter_CampaignTagType = _Filter_CampaignTagType
            End Get
            Set(value As String)

                If value <> _Filter_CampaignTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_CampaignTagType = value

                SaveFilter_CampaignTagTypeSetting()

            End Set
        End Property
        Public Property Filter_InternetTypeTagType As String
            Get
                Filter_InternetTypeTagType = _Filter_InternetTypeTagType
            End Get
            Set(value As String)

                If value <> _Filter_InternetTypeTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_InternetTypeTagType = value

                SaveFilter_InternetTypeTagTypeSetting()

            End Set
        End Property
        Public Property Filter_VendorTagType As String
            Get
                Filter_VendorTagType = _Filter_VendorTagType
            End Get
            Set(value As String)

                If value <> _Filter_VendorTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_VendorTagType = value

                SaveFilter_VendorTagTypeSetting()

            End Set
        End Property
        Public Property Filter_OutOfHomeTypeTagType As String
            Get
                Filter_OutOfHomeTypeTagType = _Filter_OutOfHomeTypeTagType
            End Get
            Set(value As String)

                If value <> _Filter_OutOfHomeTypeTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_OutOfHomeTypeTagType = value

                SaveFilter_OutOfHomeTypeTagTypeSetting()

            End Set
        End Property
        Public Property Filter_AdNumberTagType As String
            Get
                Filter_AdNumberTagType = _Filter_AdNumberTagType
            End Get
            Set(value As String)

                If value <> _Filter_AdNumberTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_AdNumberTagType = value

                SaveFilter_AdNumberTagTypeSetting()

            End Set
        End Property
        Public Property Filter_JobComponentTagType As String
            Get
                Filter_JobComponentTagType = _Filter_JobComponentTagType
            End Get
            Set(value As String)

                If value <> _Filter_JobComponentTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_JobComponentTagType = value

                SaveFilter_JobComponentTagTypeSetting()

            End Set
        End Property
        Public Property Filter_MediaChannelTagType As String
            Get
                Filter_MediaChannelTagType = _Filter_MediaChannelTagType
            End Get
            Set(value As String)

                If value <> _Filter_MediaChannelTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_MediaChannelTagType = value

                SaveFilter_MediaChannelTagTypeSetting()

            End Set
        End Property
        Public Property Filter_MediaTacticTagType As String
            Get
                Filter_MediaTacticTagType = _Filter_MediaTacticTagType
            End Get
            Set(value As String)

                If value <> _Filter_MediaTacticTagType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Filter_MediaTacticTagType = value

                SaveFilter_MediaTacticTagTypeSetting()

            End Set
        End Property
        Public Property QuarterPrefix As String
            Get
                QuarterPrefix = _QuarterPrefix
            End Get
            Set(value As String)

                If value <> _QuarterPrefix Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _QuarterPrefix = value

                SaveQuarterPrefixSetting()

            End Set
        End Property
        Public Property GrossPercentageInTotals As Boolean
            Get
                GrossPercentageInTotals = _GrossPercentageInTotals
            End Get
            Set(value As Boolean)

                If value <> _GrossPercentageInTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _GrossPercentageInTotals = value

                SaveGrossPercentageInTotalsSetting()

            End Set
        End Property
        Public Property GrossPercentageInTotalField As String
            Get
                GrossPercentageInTotalField = _GrossPercentageInTotalField
            End Get
            Set(value As String)

                If value <> _GrossPercentageInTotalField Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _GrossPercentageInTotalField = value

                SaveGrossPercentageInTotalsSetting()

            End Set
        End Property
        Public Property GrossPercentageInTotalsCaption As String
            Get
                GrossPercentageInTotalsCaption = _GrossPercentageInTotalsCaption
            End Get
            Set(value As String)

                If value <> _GrossPercentageInTotalsCaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _GrossPercentageInTotalsCaption = value

                SaveGrossPercentageInTotalsCaptionSetting()

            End Set
        End Property
        Public Property GrossPercentageInTotalsIndex As Integer
            Get
                GrossPercentageInTotalsIndex = _GrossPercentageInTotalsIndex
            End Get
            Set(value As Integer)

                If value <> _GrossPercentageInTotalsIndex Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _GrossPercentageInTotalsIndex = value

                SaveGrossPercentageInTotalsIndexSetting()

            End Set
        End Property
        Public Property GrossPercentageInTotalsShowTotals As Boolean
            Get
                GrossPercentageInTotalsShowTotals = _GrossPercentageInTotalsShowTotals
            End Get
            Set(value As Boolean)

                If value <> _GrossPercentageInTotalsShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _GrossPercentageInTotalsShowTotals = value

                SaveGrossPercentageInTotalsShowTotalsSetting()

            End Set
        End Property
        Public Property GrossPercentageInTotalsWidth As Integer
            Get
                GrossPercentageInTotalsWidth = _GrossPercentageInTotalsWidth
            End Get
            Set(value As Integer)

                If value <> _GrossPercentageInTotalsWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _GrossPercentageInTotalsWidth = value

                SaveGrossPercentageInTotalsWidthSetting()

            End Set
        End Property
        Public Property WeekDisplayType As AdvantageFramework.MediaPlanning.WeekDisplayTypes
            Get
                WeekDisplayType = _WeekDisplayType
            End Get
            Set(value As AdvantageFramework.MediaPlanning.WeekDisplayTypes)

                If value <> _WeekDisplayType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _WeekDisplayType = value

                SaveWeekDisplayTypeSetting()

            End Set
        End Property
        Public Property IsUnitsCPM As Boolean
            Get
                IsUnitsCPM = _IsUnitsCPM
            End Get
            Set(value As Boolean)

                If value <> _IsUnitsCPM Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _IsUnitsCPM = value

                SaveIsUnitsCPMSetting()

            End Set
        End Property
        Public Property IsImpressionsCPM As Boolean
            Get
                IsImpressionsCPM = _IsImpressionsCPM
            End Get
            Set(value As Boolean)

                If value <> _IsImpressionsCPM Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _IsImpressionsCPM = value

                SaveIsImpressionsCPMSetting()

            End Set
        End Property
        Public Property IsClicksCPM As Boolean
            Get
                IsClicksCPM = _IsClicksCPM
            End Get
            Set(value As Boolean)

                If value <> _IsClicksCPM Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _IsClicksCPM = value

                SaveIsClicksCPMSetting()

            End Set
        End Property
        Public Property NetDollars As Boolean
            Get
                NetDollars = _NetDollars
            End Get
            Set(value As Boolean)

                If value <> _NetDollars Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _NetDollars = value

                SaveNetDollarsSetting()

            End Set
        End Property
        Public Property NetDollarsCaption As String
            Get
                NetDollarsCaption = _NetDollarsCaption
            End Get
            Set(value As String)

                If value <> _NetDollarsCaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _NetDollarsCaption = value

                SaveNetDollarsCaptionSetting()

            End Set
        End Property
        Public Property NetDollarsIndex As Integer
            Get
                NetDollarsIndex = _NetDollarsIndex
            End Get
            Set(value As Integer)

                If value <> _NetDollarsIndex Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _NetDollarsIndex = value

                SaveNetDollarsIndexSetting()

            End Set
        End Property
        Public Property NetDollarsShowTotals As Boolean
            Get
                NetDollarsShowTotals = _NetDollarsShowTotals
            End Get
            Set(value As Boolean)

                If value <> _NetDollarsShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _NetDollarsShowTotals = value

                SaveNetDollarsShowTotalsSetting()

            End Set
        End Property
        Public Property NetDollarsWidth As Integer
            Get
                NetDollarsWidth = _NetDollarsWidth
            End Get
            Set(value As Integer)

                If value <> _NetDollarsWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _NetDollarsWidth = value

                SaveNetDollarsWidthSetting()

            End Set
        End Property
        Public Property CPP1 As Boolean
            Get
                CPP1 = _CPP1
            End Get
            Set(value As Boolean)

                If value <> _CPP1 Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPP1 = value

                SaveCPP1Setting()

            End Set
        End Property
        Public Property CPP1Caption As String
            Get
                CPP1Caption = _CPP1Caption
            End Get
            Set(value As String)

                If value <> _CPP1Caption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPP1Caption = value

                SaveCPP1CaptionSetting()

            End Set
        End Property
        Public Property CPP1Index As Integer
            Get
                CPP1Index = _CPP1Index
            End Get
            Set(value As Integer)

                If value <> _CPP1Index Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPP1Index = value

                SaveCPP1IndexSetting()

            End Set
        End Property
        Public Property CPP1ShowTotals As Boolean
            Get
                CPP1ShowTotals = _CPP1ShowTotals
            End Get
            Set(value As Boolean)

                If value <> _CPP1ShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPP1ShowTotals = value

                SaveCPP1ShowTotalsSetting()

            End Set
        End Property
        Public Property CPP1Width As Integer
            Get
                CPP1Width = _CPP1Width
            End Get
            Set(value As Integer)

                If value <> _CPP1Width Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPP1Width = value

                SaveCPP1WidthSetting()

            End Set
        End Property
        Public Property CPP2 As Boolean
            Get
                CPP2 = _CPP2
            End Get
            Set(value As Boolean)

                If value <> _CPP2 Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPP2 = value

                SaveCPP2Setting()

            End Set
        End Property
        Public Property CPP2Caption As String
            Get
                CPP2Caption = _CPP2Caption
            End Get
            Set(value As String)

                If value <> _CPP2Caption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPP2Caption = value

                SaveCPP2CaptionSetting()

            End Set
        End Property
        Public Property CPP2Index As Integer
            Get
                CPP2Index = _CPP2Index
            End Get
            Set(value As Integer)

                If value <> _CPP2Index Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPP2Index = value

                SaveCPP2IndexSetting()

            End Set
        End Property
        Public Property CPP2ShowTotals As Boolean
            Get
                CPP2ShowTotals = _CPP2ShowTotals
            End Get
            Set(value As Boolean)

                If value <> _CPP2ShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPP2ShowTotals = value

                SaveCPP2ShowTotalsSetting()

            End Set
        End Property
        Public Property CPP2Width As Integer
            Get
                CPP2Width = _CPP2Width
            End Get
            Set(value As Integer)

                If value <> _CPP2Width Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPP2Width = value

                SaveCPP2WidthSetting()

            End Set
        End Property
        Public Property CPI As Boolean
            Get
                CPI = _CPI
            End Get
            Set(value As Boolean)

                If value <> _CPI Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPI = value

                SaveCPISetting()

            End Set
        End Property
        Public Property CPICaption As String
            Get
                CPICaption = _CPICaption
            End Get
            Set(value As String)

                If value <> _CPICaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPICaption = value

                SaveCPICaptionSetting()

            End Set
        End Property
        Public Property CPIIndex As Integer
            Get
                CPIIndex = _CPIIndex
            End Get
            Set(value As Integer)

                If value <> _CPIIndex Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPIIndex = value

                SaveCPIIndexSetting()

            End Set
        End Property
        Public Property CPIShowTotals As Boolean
            Get
                CPIShowTotals = _CPIShowTotals
            End Get
            Set(value As Boolean)

                If value <> _CPIShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPIShowTotals = value

                SaveCPIShowTotalsSetting()

            End Set
        End Property
        Public Property CPIWidth As Integer
            Get
                CPIWidth = _CPIWidth
            End Get
            Set(value As Integer)

                If value <> _CPIWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CPIWidth = value

                SaveCPIWidthSetting()

            End Set
        End Property
        Public Property CTR As Boolean
            Get
                CTR = _CTR
            End Get
            Set(value As Boolean)

                If value <> _CTR Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CTR = value

                SaveCTRSetting()

            End Set
        End Property
        Public Property CTRCaption As String
            Get
                CTRCaption = _CTRCaption
            End Get
            Set(value As String)

                If value <> _CTRCaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CTRCaption = value

                SaveCTRCaptionSetting()

            End Set
        End Property
        Public Property CTRIndex As Integer
            Get
                CTRIndex = _CTRIndex
            End Get
            Set(value As Integer)

                If value <> _CTRIndex Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CTRIndex = value

                SaveCTRIndexSetting()

            End Set
        End Property
        Public Property CTRShowTotals As Boolean
            Get
                CTRShowTotals = _CTRShowTotals
            End Get
            Set(value As Boolean)

                If value <> _CTRShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CTRShowTotals = value

                SaveCTRShowTotalsSetting()

            End Set
        End Property
        Public Property CTRWidth As Integer
            Get
                CTRWidth = _CTRWidth
            End Get
            Set(value As Integer)

                If value <> _CTRWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CTRWidth = value

                SaveCTRWidthSetting()

            End Set
        End Property
        Public Property ConversionRate As Boolean
            Get
                ConversionRate = _ConversionRate
            End Get
            Set(value As Boolean)

                If value <> _ConversionRate Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ConversionRate = value

                SaveConversionRateSetting()

            End Set
        End Property
        Public Property ConversionRateCaption As String
            Get
                ConversionRateCaption = _ConversionRateCaption
            End Get
            Set(value As String)

                If value <> _ConversionRateCaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ConversionRateCaption = value

                SaveConversionRateCaptionSetting()

            End Set
        End Property
        Public Property ConversionRateIndex As Integer
            Get
                ConversionRateIndex = _ConversionRateIndex
            End Get
            Set(value As Integer)

                If value <> _ConversionRateIndex Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ConversionRateIndex = value

                SaveConversionRateIndexSetting()

            End Set
        End Property
        Public Property ConversionRateShowTotals As Boolean
            Get
                ConversionRateShowTotals = _ConversionRateShowTotals
            End Get
            Set(value As Boolean)

                If value <> _ConversionRateShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ConversionRateShowTotals = value

                SaveConversionRateShowTotalsSetting()

            End Set
        End Property
        Public Property ConversionRateWidth As Integer
            Get
                ConversionRateWidth = _ConversionRateWidth
            End Get
            Set(value As Integer)

                If value <> _ConversionRateWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ConversionRateWidth = value

                SaveConversionRateWidthSetting()

            End Set
        End Property
        Public Property TotalDemo1 As Boolean
            Get
                TotalDemo1 = _TotalDemo1
            End Get
            Set(value As Boolean)

                If value <> _TotalDemo1 Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalDemo1 = value

                SaveTotalDemo1Setting()

            End Set
        End Property
        Public Property TotalDemo1Caption As String
            Get
                TotalDemo1Caption = _TotalDemo1Caption
            End Get
            Set(value As String)

                If value <> _TotalDemo1Caption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalDemo1Caption = value

                SaveTotalDemo1CaptionSetting()

            End Set
        End Property
        Public Property TotalDemo1Index As Integer
            Get
                TotalDemo1Index = _TotalDemo1Index
            End Get
            Set(value As Integer)

                If value <> _TotalDemo1Index Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalDemo1Index = value

                SaveTotalDemo1IndexSetting()

            End Set
        End Property
        Public Property TotalDemo1ShowTotals As Boolean
            Get
                TotalDemo1ShowTotals = _TotalDemo1ShowTotals
            End Get
            Set(value As Boolean)

                If value <> _TotalDemo1ShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalDemo1ShowTotals = value

                SaveTotalDemo1ShowTotalsSetting()

            End Set
        End Property
        Public Property TotalDemo1Width As Integer
            Get
                TotalDemo1Width = _TotalDemo1Width
            End Get
            Set(value As Integer)

                If value <> _TotalDemo1Width Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalDemo1Width = value

                SaveTotalDemo1WidthSetting()

            End Set
        End Property
        Public Property TotalDemo2 As Boolean
            Get
                TotalDemo2 = _TotalDemo2
            End Get
            Set(value As Boolean)

                If value <> _TotalDemo2 Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalDemo2 = value

                SaveTotalDemo2Setting()

            End Set
        End Property
        Public Property TotalDemo2Caption As String
            Get
                TotalDemo2Caption = _TotalDemo2Caption
            End Get
            Set(value As String)

                If value <> _TotalDemo2Caption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalDemo2Caption = value

                SaveTotalDemo2CaptionSetting()

            End Set
        End Property
        Public Property TotalDemo2Index As Integer
            Get
                TotalDemo2Index = _TotalDemo2Index
            End Get
            Set(value As Integer)

                If value <> _TotalDemo2Index Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalDemo2Index = value

                SaveTotalDemo2IndexSetting()

            End Set
        End Property
        Public Property TotalDemo2ShowTotals As Boolean
            Get
                TotalDemo2ShowTotals = _TotalDemo2ShowTotals
            End Get
            Set(value As Boolean)

                If value <> _TotalDemo2ShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalDemo2ShowTotals = value

                SaveTotalDemo2ShowTotalsSetting()

            End Set
        End Property
        Public Property TotalDemo2Width As Integer
            Get
                TotalDemo2Width = _TotalDemo2Width
            End Get
            Set(value As Integer)

                If value <> _TotalDemo2Width Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalDemo2Width = value

                SaveTotalDemo2WidthSetting()

            End Set
        End Property
        Public Property TotalNet As Boolean
            Get
                TotalNet = _TotalNet
            End Get
            Set(value As Boolean)

                If value <> _TotalNet Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalNet = value

                SaveTotalNetSetting()

            End Set
        End Property
        Public Property TotalNetCaption As String
            Get
                TotalNetCaption = _TotalNetCaption
            End Get
            Set(value As String)

                If value <> _TotalNetCaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalNetCaption = value

                SaveTotalNetCaptionSetting()

            End Set
        End Property
        Public Property TotalNetIndex As Integer
            Get
                TotalNetIndex = _TotalNetIndex
            End Get
            Set(value As Integer)

                If value <> _TotalNetIndex Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalNetIndex = value

                SaveTotalNetIndexSetting()

            End Set
        End Property
        Public Property TotalNetShowTotals As Boolean
            Get
                TotalNetShowTotals = _TotalNetShowTotals
            End Get
            Set(value As Boolean)

                If value <> _TotalNetShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalNetShowTotals = value

                SaveTotalNetShowTotalsSetting()

            End Set
        End Property
        Public Property TotalNetWidth As Integer
            Get
                TotalNetWidth = _TotalNetWidth
            End Get
            Set(value As Integer)

                If value <> _TotalNetWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _TotalNetWidth = value

                SaveTotalNetWidthSetting()

            End Set
        End Property
        Public Property Commission As Boolean
            Get
                Commission = _Commission
            End Get
            Set(value As Boolean)

                If value <> _Commission Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _Commission = value

                SaveCommissionSetting()

            End Set
        End Property
        Public Property CommissionCaption As String
            Get
                CommissionCaption = _CommissionCaption
            End Get
            Set(value As String)

                If value <> _CommissionCaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CommissionCaption = value

                SaveCommissionCaptionSetting()

            End Set
        End Property
        Public Property CommissionIndex As Integer
            Get
                CommissionIndex = _CommissionIndex
            End Get
            Set(value As Integer)

                If value <> _CommissionIndex Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CommissionIndex = value

                SaveCommissionIndexSetting()

            End Set
        End Property
        Public Property CommissionShowTotals As Boolean
            Get
                CommissionShowTotals = _CommissionShowTotals
            End Get
            Set(value As Boolean)

                If value <> _CommissionShowTotals Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CommissionShowTotals = value

                SaveCommissionShowTotalsSetting()

            End Set
        End Property
        Public Property CommissionWidth As Integer
            Get
                CommissionWidth = _CommissionWidth
            End Get
            Set(value As Integer)

                If value <> _CommissionWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _CommissionWidth = value

                SaveCommissionWidthSetting()

            End Set
        End Property
        Public Property FirstVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns
            Get
                FirstVisibleQuantityColumn = _FirstVisibleQuantityColumn
            End Get
            Set(value As AdvantageFramework.MediaPlanning.DataColumns)

                If value <> _FirstVisibleQuantityColumn Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _FirstVisibleQuantityColumn = value

            End Set
        End Property
        Public Property SecondVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns
            Get
                SecondVisibleQuantityColumn = _SecondVisibleQuantityColumn
            End Get
            Set(value As AdvantageFramework.MediaPlanning.DataColumns)

                If value <> _SecondVisibleQuantityColumn Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _SecondVisibleQuantityColumn = value

            End Set
        End Property
        Public Property ThirdVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns
            Get
                ThirdVisibleQuantityColumn = _ThirdVisibleQuantityColumn
            End Get
            Set(value As AdvantageFramework.MediaPlanning.DataColumns)

                If value <> _ThirdVisibleQuantityColumn Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ThirdVisibleQuantityColumn = value

            End Set
        End Property
        Public Property FourthVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns
            Get
                FourthVisibleQuantityColumn = _FourthVisibleQuantityColumn
            End Get
            Set(value As AdvantageFramework.MediaPlanning.DataColumns)

                If value <> _FourthVisibleQuantityColumn Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _FourthVisibleQuantityColumn = value

            End Set
        End Property
        Public Property FifthVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns
            Get
                FifthVisibleQuantityColumn = _FifthVisibleQuantityColumn
            End Get
            Set(value As AdvantageFramework.MediaPlanning.DataColumns)

                If value <> _FifthVisibleQuantityColumn Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _FifthVisibleQuantityColumn = value

            End Set
        End Property
        Public ReadOnly Property SalesClassTypeEnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute
            Get
                SalesClassTypeEnumObject = _SalesClassTypeEnumObject
            End Get
        End Property
        Public Property IsLevelsAndLinesDataTableSaving As Boolean
            Get
                IsLevelsAndLinesDataTableSaving = _IsLevelsAndLinesDataTableSaving
            End Get
            Set(value As Boolean)
                _IsLevelsAndLinesDataTableSaving = value
            End Set
        End Property
        Public Property IsEstimateDataTableSaving As Boolean
            Get
                IsEstimateDataTableSaving = _IsEstimateDataTableSaving
            End Get
            Set(value As Boolean)
                _IsEstimateDataTableSaving = value
            End Set
        End Property
        Public Property PreventAutoCalcOfMediaPlanDetailLevelLineData As Boolean
            Get
                PreventAutoCalcOfMediaPlanDetailLevelLineData = _PreventAutoCalcOfMediaPlanDetailLevelLineData
            End Get
            Set(value As Boolean)
                _PreventAutoCalcOfMediaPlanDetailLevelLineData = value
            End Set
        End Property
        Public ReadOnly Property IsDataLoaded As Boolean
            Get
                IsDataLoaded = _IsDataLoaded
            End Get
        End Property
        Public ReadOnly Property IsLevelAndLinesLoaded As Boolean
            Get
                IsLevelAndLinesLoaded = _IsLevelAndLinesLoaded
            End Get
        End Property
        Public Property ProductUsesNetAmount As Boolean
            Get
                ProductUsesNetAmount = _ProductUsesNetAmount
            End Get
            Set(value As Boolean)

                If value <> _ProductUsesNetAmount Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ProductUsesNetAmount = value

                SaveProductUsesNetAmountSetting()

            End Set
        End Property
        Public Property ProductRebateAmount As Decimal
            Get
                ProductRebateAmount = _ProductRebateAmount
            End Get
            Set(value As Decimal)

                If value <> _ProductRebateAmount Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ProductRebateAmount = value

                SaveProductRebateAmountSetting()

            End Set
        End Property
        Public Property ProductMarkupAmount As Decimal
            Get
                ProductMarkupAmount = _ProductMarkupAmount
            End Get
            Set(value As Decimal)

                If value <> _ProductMarkupAmount Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ProductMarkupAmount = value

                SaveProductMarkupAmountSetting()

            End Set
        End Property
        'Public ReadOnly Property HasPendingOrders As Boolean
        '    Get
        '        HasPendingOrders = _MediaPlanDetail.HasPendingOrders
        '    End Get
        'End Property
        Public ReadOnly Property HasMediaOrder As Boolean
            Get
                HasMediaOrder = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Data) Data.OrderNumber IsNot Nothing OrElse Data.HasPendingOrders = True).Any()
            End Get
        End Property
        Public Property Name() As String
            Get
                Name = _MediaPlanDetail.Name
            End Get
            Set(ByVal value As String)

                If value <> _MediaPlanDetail.Name Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.Name = value

            End Set
        End Property
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _MediaPlanDetail.OrderNumber
            End Get
            Set(ByVal value As Integer)

                If value <> _MediaPlanDetail.OrderNumber Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.OrderNumber = value

            End Set
        End Property
        Public ReadOnly Property IsApproved As Boolean
            Get
                IsApproved = _MediaPlanDetail.IsApproved
            End Get
            'Set(value As Boolean)

            '    If value <> _MediaPlanDetail.IsApproved Then

            '        RaiseEvent EstimateChangedEvent()

            '    End If

            '    _MediaPlanDetail.IsApproved = value

            'End Set
        End Property
        Public ReadOnly Property ApprovalDateUser As String
            Get

                If _MediaPlanDetail.IsApproved Then

                    ApprovalDateUser = "Approved " & _MediaPlanDetail.ApprovedDate.Value & " by " & _MediaPlanDetail.ApprovedBy

                Else

                    ApprovalDateUser = Nothing

                End If

            End Get
        End Property
        Public ReadOnly Property HasChanged As Boolean
            Get
                HasChanged = _HasChanged
            End Get
        End Property
        Public ReadOnly Property HiatusWeeks As Generic.List(Of Date)
            Get
                HiatusWeeks = _HiatusWeeks
            End Get
        End Property
        Public ReadOnly Property HiatusMonths As Generic.List(Of Date)
            Get
                HiatusMonths = _HiatusMonths
            End Get
        End Property
        Public Property DaysOfWeekType As Integer
            Get
                DaysOfWeekType = _DaysOfWeekType
            End Get
            Set(value As Integer)

                If value <> _DaysOfWeekType Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _DaysOfWeekType = value

                SaveDaysOfWeekSetting()

            End Set
        End Property
        Public Property DaysOfWeekCaption As String
            Get
                DaysOfWeekCaption = _DaysOfWeekCaption
            End Get
            Set(value As String)

                If value <> _DaysOfWeekCaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _DaysOfWeekCaption = value

                SaveDaysOfWeekSetting()

            End Set
        End Property
        Public Property DateRangeCaption As String
            Get
                DateRangeCaption = _DateRangeCaption
            End Get
            Set(value As String)

                If value <> _DateRangeCaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _DateRangeCaption = value

                SaveDateRangeCaptionSetting()

            End Set
        End Property
        Public ReadOnly Property TotalDollars As Decimal
            Get

                If _MediaPlanDetail.MediaPlanDetailLevelLineDatas IsNot Nothing Then

                    TotalDollars = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Sum(Function(Entity) Entity.Dollars.GetValueOrDefault(0))

                Else

                    TotalDollars = 0

                End If

            End Get
        End Property
        Public ReadOnly Property TotalBillAmount As Decimal
            Get

                If _MediaPlanDetail.MediaPlanDetailLevelLineDatas IsNot Nothing Then

                    TotalBillAmount = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Sum(Function(Entity) Entity.BillAmount.GetValueOrDefault(0))

                Else

                    TotalBillAmount = 0

                End If

            End Get
        End Property
        Public ReadOnly Property EntryDates() As Date()
            Get
                EntryDates = _EntryDates
            End Get
        End Property
        Public Property FreezeLevels As Boolean
            Get
                FreezeLevels = _FreezeLevels
            End Get
            Set(value As Boolean)

                If value <> _FreezeLevels Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _FreezeLevels = value

                SaveFreezeLevelsSetting()

            End Set
        End Property
        Public Property ShowPackageLevels As Integer
            Get
                ShowPackageLevels = _ShowPackageLevels
            End Get
            Set(value As Integer)

                If value <> _ShowPackageLevels Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ShowPackageLevels = value

                SaveShowPackageLevelsSetting()

            End Set
        End Property
        Public Property ShowPackageName As Boolean
            Get
                ShowPackageName = _ShowPackageName
            End Get
            Set(value As Boolean)

                If value <> _ShowPackageName Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ShowPackageName = value

                SaveShowPackageNameSetting()

            End Set
        End Property
        Public Property ShowAdSizes As Boolean
            Get
                ShowAdSizes = _ShowAdSizes
            End Get
            Set(value As Boolean)

                If value <> _ShowAdSizes Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ShowAdSizes = value

                SaveShowAdSizesSetting()

            End Set
        End Property
        Public Property AdSizesCaption As String
            Get
                AdSizesCaption = _AdSizesCaption
            End Get
            Set(value As String)

                If value <> _AdSizesCaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _AdSizesCaption = value

                SaveAdSizesCaptionSetting()

            End Set
        End Property
        Public Property AdSizesWidth As Integer
            Get
                AdSizesWidth = _AdSizesWidth
            End Get
            Set(value As Integer)

                If value <> _AdSizesWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _AdSizesWidth = value

                SaveAdSizesWidthSetting()

            End Set
        End Property
        Public Property PackageLevelWidth As Integer
            Get
                PackageLevelWidth = _PackageLevelWidth
            End Get
            Set(value As Integer)

                If value <> _PackageLevelWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _PackageLevelWidth = value

                SavePackageLevelWidthSetting()

            End Set
        End Property
        Public Property ShowDateRange As Boolean
            Get
                ShowDateRange = _ShowDateRange
            End Get
            Set(value As Boolean)

                If value <> _ShowDateRange Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _ShowDateRange = value

                SaveShowDateRangeSetting()

            End Set
        End Property
        Public Property DateRangeWidth As Integer
            Get
                DateRangeWidth = _DateRangeWidth
            End Get
            Set(value As Integer)

                If value <> _DateRangeWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _DateRangeWidth = value

                SaveDateRangeWidthSetting()

            End Set
        End Property
        Public Property PackageLevelIndex As Integer
            Get
                PackageLevelIndex = _PackageLevelIndex
            End Get
            Set(value As Integer)

                If value <> _PackageLevelIndex Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _PackageLevelIndex = value

                SavePackageLevelIndexSetting()

            End Set
        End Property
        Public Property DateRangeIndex As Integer
            Get
                DateRangeIndex = _DateRangeIndex
            End Get
            Set(value As Integer)

                If value <> _DateRangeIndex Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _DateRangeIndex = value

                SaveDateRangeIndexSetting()

            End Set
        End Property
        Public Property AdSizesIndex As Integer
            Get
                AdSizesIndex = _AdSizesIndex
            End Get
            Set(value As Integer)

                If value <> _AdSizesIndex Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _AdSizesIndex = value

                SaveAdSizesIndexSetting()

            End Set
        End Property
        Public ReadOnly Property PackageNames As Generic.List(Of String)
            Get
                PackageNames = _PackageNames
            End Get
        End Property
        'Public Property FirstVisibleQuantityColumnForCalculationOnly As AdvantageFramework.MediaPlanning.DataColumns
        '	Get
        '		FirstVisibleQuantityColumnForCalculationOnly = _FirstVisibleQuantityColumnForCalculationOnly
        '	End Get
        '	Set(value As AdvantageFramework.MediaPlanning.DataColumns)
        '		_FirstVisibleQuantityColumnForCalculationOnly = value
        '	End Set
        'End Property
        Public Property MediaLevelLinesLocked As Boolean
        Public Property PackageNameCaption As String
            Get
                PackageNameCaption = _PackageNameCaption
            End Get
            Set(value As String)

                If value <> _PackageNameCaption Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _PackageNameCaption = value

                SavePackageNameCaptionSetting()

            End Set
        End Property
        Public Property PackagePlacementWidth As Integer
            Get
                PackagePlacementWidth = _PackagePlacementWidth
            End Get
            Set(value As Integer)

                If value <> _PackagePlacementWidth Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _PackagePlacementWidth = value

                SavePackagePlacementsWidthSetting()

            End Set
        End Property
        Public Property MediaPlanEstimateTemplateID() As Nullable(Of Integer)
            Get
                MediaPlanEstimateTemplateID = _MediaPlanDetail.MediaPlanEstimateTemplateID
            End Get
            Set(value As Nullable(Of Integer))

                If value.GetValueOrDefault(0) <> _MediaPlanDetail.MediaPlanEstimateTemplateID.GetValueOrDefault(0) Then

                    RaiseEvent EstimateChangedEvent()

                End If

                _MediaPlanDetail.MediaPlanEstimateTemplateID = value

            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New()



        End Sub
        Public Sub New(ByRef MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByRef MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail,
                       ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek))

            'objects
            Dim OrderNumber As Integer = 0

            _MediaPlan = MediaPlan
            _Product = MediaPlan.Product
            _MediaPlanDetail = MediaPlanDetail
            _BroadcastCalendarWeeks = BroadcastCalendarWeeks
            _HasChanged = False
            _HiatusWeeks = New Generic.List(Of Date)
            _HiatusMonths = New Generic.List(Of Date)

            LoadProductUsesNetAmountSetting()
            LoadProductRebateAmountSetting()
            LoadProductMarkupAmountSetting()
            LoadFilter_AdSizeTagTypeSetting()
            LoadFilter_DaypartTagTypeSetting()
            LoadFilter_InternetTypeTagTypeSetting()
            LoadFilter_MarketTagTypeSetting()
            LoadFilter_MarketOrderLineTagTypeSetting()
            LoadFilter_VendorTagTypeSetting()
            LoadQuarterPrefixSetting()
            LoadGrossPercentageInTotalsSetting()
            LoadGrossPercentageInTotalsCaptionSetting()
            LoadGrossPercentageInTotalsIndexSetting()
            LoadGrossPercentageInTotalsShowTotalsSetting()
            LoadGrossPercentageInTotalsWidthSetting()
            LoadWeekDisplayTypeSetting()
            LoadIsUnitsCPMSetting()
            LoadIsImpressionsCPMSetting()
            LoadIsClicksCPMSetting()
            LoadNetDollarsSetting()
            LoadNetDollarsCaptionSetting()
            LoadNetDollarsIndexSetting()
            LoadNetDollarsShowTotalsSetting()
            LoadNetDollarsWidthSetting()
            LoadCPP1Setting()
            LoadCPP1CaptionSetting()
            LoadCPP1IndexSetting()
            LoadCPP1ShowTotalsSetting()
            LoadCPP1WidthSetting()
            LoadCPP2Setting()
            LoadCPP2CaptionSetting()
            LoadCPP2IndexSetting()
            LoadCPP2ShowTotalsSetting()
            LoadCPP2WidthSetting()
            LoadCPISetting()
            LoadCPICaptionSetting()
            LoadCPIIndexSetting()
            LoadCPIShowTotalsSetting()
            LoadCPIWidthSetting()
            LoadCTRSetting()
            LoadCTRCaptionSetting()
            LoadCTRIndexSetting()
            LoadCTRShowTotalsSetting()
            LoadCTRWidthSetting()
            LoadConversionRateSetting()
            LoadConversionRateCaptionSetting()
            LoadConversionRateIndexSetting()
            LoadConversionRateShowTotalsSetting()
            LoadConversionRateWidthSetting()
            LoadTotalDemo1Setting()
            LoadTotalDemo1CaptionSetting()
            LoadTotalDemo1IndexSetting()
            LoadTotalDemo1ShowTotalsSetting()
            LoadTotalDemo1WidthSetting()
            LoadTotalDemo2Setting()
            LoadTotalDemo2CaptionSetting()
            LoadTotalDemo2IndexSetting()
            LoadTotalDemo2ShowTotalsSetting()
            LoadTotalDemo2WidthSetting()
            LoadFilter_OutOfHomeTypeTagTypeSetting()
            LoadFilter_AdNumberTagTypeSetting()
            LoadFilter_JobComponentTagTypeSetting()
            LoadHiatusWeeks()
            LoadHiatusMonths()
            LoadQuantityColumn(True, False)
            LoadDaysOfWeekSetting()
            LoadFreezeLevelsSetting()
            LoadShowPackageLevelsSetting()
            LoadShowPackageNameSetting()
            LoadShowAdSizesSetting()
            LoadAdSizesCaptionSetting()
            LoadAdSizesWidthSetting()
            LoadPackageLevelWidthSetting()
            LoadFilter_CampaignTagTypeSetting()
            LoadShowDateRangeSetting()
            LoadDateRangeCaptionSetting()
            LoadDateRangeWidthSetting()
            LoadPackageLevelIndexSetting()
            LoadDateRangeIndexSetting()
            LoadAdSizesIndexSetting()
            LoadTotalNetSetting()
            LoadTotalNetCaptionSetting()
            LoadTotalNetIndexSetting()
            LoadTotalNetShowTotalsSetting()
            LoadTotalNetWidthSetting()
            LoadCommissionSetting()
            LoadCommissionCaptionSetting()
            LoadCommissionIndexSetting()
            LoadCommissionShowTotalsSetting()
            LoadCommissionWidthSetting()
            LoadPackageNameCaptionSetting()
            LoadFilter_MediaChannelTagTypeSetting()
            LoadFilter_MediaTacticTagTypeSetting()
            LoadPackagePlacementWidthSetting()

            _SalesClassTypeEnumObject = AdvantageFramework.EnumUtilities.LoadEnumObject(GetType(AdvantageFramework.Database.Entities.SalesClassMediaType), _MediaPlanDetail.SalesClassType)

            _PackageNames = New Generic.List(Of String)

            If _MediaPlanDetail.MediaPlanDetailLevels IsNot Nothing AndAlso _MediaPlanDetail.MediaPlanDetailLevels.Count > 0 Then

                If _MediaPlanDetail.MediaPlanDetailLevels.Min(Function(Entity) Entity.OrderNumber) < 0 Then

                    For Each MediaPlanDetailLevel In _MediaPlanDetail.MediaPlanDetailLevels.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                        MediaPlanDetailLevel.OrderNumber = OrderNumber

                        OrderNumber += 1

                    Next

                ElseIf _MediaPlanDetail.MediaPlanDetailLevels.Min(Function(Entity) Entity.OrderNumber) > 0 Then

                    For Each MediaPlanDetailLevel In _MediaPlanDetail.MediaPlanDetailLevels.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                        MediaPlanDetailLevel.OrderNumber = OrderNumber

                        OrderNumber += 1

                    Next

                Else

                    For Each MediaPlanDetailLevel In _MediaPlanDetail.MediaPlanDetailLevels.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                        MediaPlanDetailLevel.OrderNumber = OrderNumber

                        OrderNumber += 1

                    Next

                End If

            End If

        End Sub
        Private Sub SavePackageNameCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.PackageNameCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.PackageNameCaption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _PackageNameCaption

        End Sub
        Private Sub LoadPackageNameCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.PackageNameCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                If String.IsNullOrEmpty(MediaPlanDetailSetting.StringValue) = False Then

                    _PackageNameCaption = MediaPlanDetailSetting.StringValue

                Else

                    _PackageNameCaption = "Package"

                End If

            Else

                _PackageNameCaption = "Package"

            End If

        End Sub
        Private Sub SavePackageLevelIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.PackageLevelIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.PackageLevelIndex.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _PackageLevelIndex

        End Sub
        Private Sub LoadPackageLevelIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.PackageLevelIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _PackageLevelIndex = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _PackageLevelIndex = -1

            End If

        End Sub
        Private Sub SaveDateRangeIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.DateRangeIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.DateRangeIndex.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _DateRangeIndex

        End Sub
        Private Sub LoadDateRangeIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.DateRangeIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _DateRangeIndex = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _DateRangeIndex = -1

            End If

        End Sub
        Private Sub SaveAdSizesIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.AdSizesIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.AdSizesIndex.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _AdSizesIndex

        End Sub
        Private Sub LoadAdSizesIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.AdSizesIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _AdSizesIndex = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _AdSizesIndex = -1

            End If

        End Sub
        Private Sub SaveShowPackageLevelsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = Nothing
            MediaPlanDetailSetting.NumericValue = _ShowPackageLevels

        End Sub
        Private Sub LoadShowPackageLevelsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ShowPackageLevels = CInt(MediaPlanDetailSetting.NumericValue.GetValueOrDefault(0))

            Else

                _ShowPackageLevels = 0

            End If

        End Sub
        Private Sub SaveShowPackageNameSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ShowPackageName.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ShowPackageName.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _ShowPackageName

        End Sub
        Private Sub LoadShowPackageNameSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ShowPackageName.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ShowPackageName = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _ShowPackageName = False

            End If

        End Sub
        Private Sub SaveShowAdSizesSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _ShowAdSizes

        End Sub
        Private Sub LoadShowAdSizesSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ShowAdSizes = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _ShowAdSizes = False

            End If

        End Sub
        Private Sub SaveAdSizesCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.AdSizesCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.AdSizesCaption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _AdSizesCaption

        End Sub
        Private Sub LoadAdSizesCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.AdSizesCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                If String.IsNullOrEmpty(MediaPlanDetailSetting.StringValue) = False Then

                    _AdSizesCaption = MediaPlanDetailSetting.StringValue

                Else

                    _AdSizesCaption = "Ad Sizes"

                End If

            Else

                _AdSizesCaption = "Ad Sizes"

            End If

        End Sub
        Private Sub SaveAdSizesWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.AdSizesWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.AdSizesWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _AdSizesWidth

        End Sub
        Private Sub LoadAdSizesWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.AdSizesWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _AdSizesWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _AdSizesWidth = 100

            End If

        End Sub
        Private Sub SavePackageLevelWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.PackageLevelWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.PackageLevelWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _PackageLevelWidth

        End Sub
        Private Sub LoadPackageLevelWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.PackageLevelWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _PackageLevelWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _PackageLevelWidth = 100

            End If

        End Sub
        Private Sub SaveShowDateRangeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _ShowDateRange

        End Sub
        Private Sub LoadShowDateRangeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ShowDateRange = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _ShowDateRange = False

            End If

        End Sub
        Private Sub SaveDateRangeCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.DateRangeCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.DateRangeCaption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _DateRangeCaption

        End Sub
        Private Sub LoadDateRangeCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.DateRangeCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                If String.IsNullOrEmpty(MediaPlanDetailSetting.StringValue) = False Then

                    _DateRangeCaption = MediaPlanDetailSetting.StringValue

                Else

                    _DateRangeCaption = "Date Range"

                End If

            Else

                _DateRangeCaption = "Date Range"

            End If

        End Sub
        Private Sub SaveDateRangeWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.DateRangeWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.DateRangeWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _DateRangeWidth

        End Sub
        Private Sub LoadDateRangeWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.DateRangeWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _DateRangeWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _DateRangeWidth = 100

            End If

        End Sub
        Private Sub SaveFreezeLevelsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.FreezeLevels.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.FreezeLevels.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _FreezeLevels

        End Sub
        Private Sub LoadFreezeLevelsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.FreezeLevels.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _FreezeLevels = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _FreezeLevels = False

            End If

        End Sub
        Private Sub SaveProductUsesNetAmountSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ProductUsesNetAmount.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ProductUsesNetAmount.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _ProductUsesNetAmount

        End Sub
        Private Sub LoadProductUsesNetAmountSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ProductUsesNetAmount.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ProductUsesNetAmount = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _ProductUsesNetAmount = False

            End If

        End Sub
        Private Sub SaveProductMarkupAmountSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ProductMarkupAmount.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ProductMarkupAmount.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _ProductMarkupAmount

        End Sub
        Private Sub LoadProductMarkupAmountSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ProductMarkupAmount.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ProductMarkupAmount = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(0)

            Else

                _ProductMarkupAmount = 0

            End If

        End Sub
        Private Sub SaveProductRebateAmountSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ProductRebateAmount.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ProductRebateAmount.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _ProductRebateAmount

        End Sub
        Private Sub LoadProductRebateAmountSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ProductRebateAmount.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ProductRebateAmount = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(0)

            Else

                _ProductRebateAmount = 0

            End If

        End Sub
        Private Sub SaveFilter_DaypartTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_DaypartTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_DaypartTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_DaypartTagType

        End Sub
        Private Sub LoadFilter_DaypartTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_DaypartTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_DaypartTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_DaypartTagType) Then

                    _Filter_DaypartTagType = ""

                End If

            Else

                _Filter_DaypartTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_InternetTypeTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_InternetTypeTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_InternetTypeTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_InternetTypeTagType

        End Sub
        Private Sub LoadFilter_InternetTypeTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_InternetTypeTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_InternetTypeTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_InternetTypeTagType) Then

                    _Filter_InternetTypeTagType = ""

                End If

            Else

                _Filter_InternetTypeTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_AdSizeTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_AdSizeTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_AdSizeTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_AdSizeTagType

        End Sub
        Private Sub LoadFilter_AdSizeTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_AdSizeTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_AdSizeTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_AdSizeTagType) Then

                    _Filter_AdSizeTagType = ""

                End If

            Else

                _Filter_AdSizeTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_VendorTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_VendorTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_VendorTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_VendorTagType

        End Sub
        Private Sub LoadFilter_VendorTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_VendorTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_VendorTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_VendorTagType) Then

                    _Filter_VendorTagType = ""

                End If

            Else

                _Filter_VendorTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_MarketTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MarketTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MarketTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_MarketTagType

        End Sub
        Private Sub LoadFilter_MarketTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MarketTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_MarketTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_MarketTagType) Then

                    _Filter_MarketTagType = ""

                End If

            Else

                _Filter_MarketTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_MarketOrderLineTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MarketOrderLineTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MarketOrderLineTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_MarketOrderLineTagType

        End Sub
        Private Sub LoadFilter_MarketOrderLineTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MarketOrderLineTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_MarketOrderLineTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_MarketOrderLineTagType) Then

                    _Filter_MarketOrderLineTagType = ""

                End If

            Else

                _Filter_MarketOrderLineTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_CampaignTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_CampaignTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_CampaignTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_CampaignTagType

        End Sub
        Private Sub LoadFilter_CampaignTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_CampaignTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_CampaignTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_CampaignTagType) Then

                    _Filter_CampaignTagType = ""

                End If

            Else

                _Filter_CampaignTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_OutOfHomeTypeTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_OutOfHomeTypeTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_OutOfHomeTypeTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_OutOfHomeTypeTagType

        End Sub
        Private Sub LoadFilter_OutOfHomeTypeTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_OutOfHomeTypeTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_OutOfHomeTypeTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_OutOfHomeTypeTagType) Then

                    _Filter_OutOfHomeTypeTagType = ""

                End If

            Else

                _Filter_OutOfHomeTypeTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_AdNumberTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_AdNumberTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_AdNumberTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_AdNumberTagType

        End Sub
        Private Sub LoadFilter_AdNumberTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_AdNumberTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_AdNumberTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_AdNumberTagType) Then

                    _Filter_AdNumberTagType = ""

                End If

            Else

                _Filter_AdNumberTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_JobComponentTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_JobComponentTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_JobComponentTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_JobComponentTagType

        End Sub
        Private Sub LoadFilter_JobComponentTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_JobComponentTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_JobComponentTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_JobComponentTagType) Then

                    _Filter_JobComponentTagType = ""

                End If

            Else

                _Filter_JobComponentTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_MediaChannelTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MediaChannelTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MediaChannelTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_MediaChannelTagType

        End Sub
        Private Sub LoadFilter_MediaChannelTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MediaChannelTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_MediaChannelTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_MediaChannelTagType) Then

                    _Filter_MediaChannelTagType = ""

                End If

            Else

                _Filter_MediaChannelTagType = ""

            End If

        End Sub
        Private Sub SaveFilter_MediaTacticTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MediaTacticTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MediaTacticTagType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _Filter_MediaTacticTagType

        End Sub
        Private Sub LoadFilter_MediaTacticTagTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Filter_MediaTacticTagType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Filter_MediaTacticTagType = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_Filter_MediaTacticTagType) Then

                    _Filter_MediaTacticTagType = ""

                End If

            Else

                _Filter_MediaTacticTagType = ""

            End If

        End Sub
        Public Sub SaveHiatusWeeks()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.HiatusWeeks.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.HiatusWeeks.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = Join(_HiatusWeeks.Select(Function(Week) Week.ToShortDateString).ToArray, ",")

        End Sub
        Private Sub LoadHiatusWeeks()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
            Dim Weeks() As String = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.HiatusWeeks.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(MediaPlanDetailSetting.StringValue) = False Then

                    Try

                        Weeks = Split(MediaPlanDetailSetting.StringValue, ",")

                    Catch ex As Exception
                        Weeks = Nothing
                    End Try

                    If Weeks IsNot Nothing Then

                        For Each Week In Weeks

                            If IsDate(Week) Then

                                Try

                                    _HiatusWeeks.Add(CDate(Week))

                                Catch ex As Exception

                                End Try

                            End If

                        Next

                    End If

                End If

            End If

        End Sub
        Public Sub SaveHiatusMonths()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.HiatusMonths.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.HiatusMonths.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = Join(_HiatusMonths.Select(Function(Month) Month.ToShortDateString).ToArray, ",")

        End Sub
        Private Sub LoadHiatusMonths()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
            Dim Months() As String = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.HiatusMonths.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(MediaPlanDetailSetting.StringValue) = False Then

                    Try

                        Months = Split(MediaPlanDetailSetting.StringValue, ",")

                    Catch ex As Exception
                        Months = Nothing
                    End Try

                    If Months IsNot Nothing Then

                        For Each MonthValue In Months

                            If IsDate(MonthValue) Then

                                Try

                                    _HiatusMonths.Add(CDate(MonthValue))

                                Catch ex As Exception

                                End Try

                            End If

                        Next

                    End If

                End If

            End If

        End Sub
        Private Sub SaveQuarterPrefixSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.QuarterPrefix.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.QuarterPrefix.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _QuarterPrefix

        End Sub
        Private Sub LoadQuarterPrefixSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.QuarterPrefix.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _QuarterPrefix = MediaPlanDetailSetting.StringValue

                If String.IsNullOrEmpty(_QuarterPrefix) Then

                    _QuarterPrefix = ""

                End If

            Else

                _QuarterPrefix = ""

            End If

        End Sub
        Private Sub SaveWeekDisplayTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.WeekDisplayType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.WeekDisplayType.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _WeekDisplayType

        End Sub
        Private Sub LoadWeekDisplayTypeSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.WeekDisplayType.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _WeekDisplayType = CType(MediaPlanDetailSetting.NumericValue.GetValueOrDefault(3), AdvantageFramework.MediaPlanning.WeekDisplayTypes)

            Else

                _WeekDisplayType = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDay

            End If

        End Sub
        Private Sub SaveGrossPercentageInTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _GrossPercentageInTotals
            MediaPlanDetailSetting.StringValue = _GrossPercentageInTotalField

        End Sub
        Private Sub LoadGrossPercentageInTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _GrossPercentageInTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

                If String.IsNullOrEmpty(MediaPlanDetailSetting.StringValue) = False Then

                    _GrossPercentageInTotalField = MediaPlanDetailSetting.StringValue

                Else

                    _GrossPercentageInTotalField = ""

                End If

            Else

                _GrossPercentageInTotals = False
                _GrossPercentageInTotalField = ""

            End If

        End Sub
        Private Sub SaveGrossPercentageInTotalsCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsCaption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _GrossPercentageInTotalsCaption

        End Sub
        Private Sub LoadGrossPercentageInTotalsCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _GrossPercentageInTotalsCaption = MediaPlanDetailSetting.StringValue

            Else

                _GrossPercentageInTotalsCaption = MediaPlanning.GrossPercentageInTotalsCaption

            End If

        End Sub
        Private Sub SaveGrossPercentageInTotalsIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsIndex.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _GrossPercentageInTotalsIndex

        End Sub
        Private Sub LoadGrossPercentageInTotalsIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _GrossPercentageInTotalsIndex = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _GrossPercentageInTotalsIndex = -1

            End If

        End Sub
        Private Sub SaveGrossPercentageInTotalsShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _GrossPercentageInTotalsShowTotals

        End Sub
        Private Sub LoadGrossPercentageInTotalsShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _GrossPercentageInTotalsShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _GrossPercentageInTotalsShowTotals = False

            End If

        End Sub
        Private Sub SaveGrossPercentageInTotalsWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _GrossPercentageInTotalsWidth

        End Sub
        Private Sub LoadGrossPercentageInTotalsWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotalsWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _GrossPercentageInTotalsWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _GrossPercentageInTotalsWidth = 100

            End If

        End Sub
        Private Sub SaveIsUnitsCPMSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.IsUnitsCPM.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.IsUnitsCPM.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _IsUnitsCPM

        End Sub
        Private Sub LoadIsUnitsCPMSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.IsUnitsCPM.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _IsUnitsCPM = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _IsUnitsCPM = False

            End If

        End Sub
        Private Sub SaveIsImpressionsCPMSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.IsImpressionsCPM.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.IsImpressionsCPM.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _IsImpressionsCPM

        End Sub
        Private Sub LoadIsImpressionsCPMSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.IsImpressionsCPM.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _IsImpressionsCPM = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _IsImpressionsCPM = False

            End If

        End Sub
        Private Sub SaveIsClicksCPMSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.IsClicksCPM.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.IsClicksCPM.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _IsClicksCPM

        End Sub
        Private Sub LoadIsClicksCPMSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.IsClicksCPM.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _IsClicksCPM = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _IsClicksCPM = False

            End If

        End Sub
        Private Sub SaveNetDollarsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _NetDollars

        End Sub
        Private Sub LoadNetDollarsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _NetDollars = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _NetDollars = False

            End If

        End Sub
        Private Sub SaveNetDollarsCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsCaption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _NetDollarsCaption

        End Sub
        Private Sub LoadNetDollarsCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _NetDollarsCaption = MediaPlanDetailSetting.StringValue

            Else

                _NetDollarsCaption = MediaPlanning.NetDollarsCaption

            End If

        End Sub
        Private Sub SaveNetDollarsIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsIndex.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _NetDollarsIndex

        End Sub
        Private Sub LoadNetDollarsIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _NetDollarsIndex = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _NetDollarsIndex = -1

            End If

        End Sub
        Private Sub SaveNetDollarsShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _NetDollarsShowTotals

        End Sub
        Private Sub LoadNetDollarsShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _NetDollarsShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _NetDollarsShowTotals = False

            End If

        End Sub
        Private Sub SaveNetDollarsWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _NetDollarsWidth

        End Sub
        Private Sub LoadNetDollarsWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.NetDollarsWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _NetDollarsWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _NetDollarsWidth = 100

            End If

        End Sub
        Private Sub SaveDaysOfWeekSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _DaysOfWeekType
            MediaPlanDetailSetting.StringValue = _DaysOfWeekCaption

        End Sub
        Private Sub LoadDaysOfWeekSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _DaysOfWeekType = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(0)

                If String.IsNullOrEmpty(MediaPlanDetailSetting.StringValue) = False Then

                    _DaysOfWeekCaption = MediaPlanDetailSetting.StringValue

                Else

                    _DaysOfWeekCaption = "Days of Week"

                End If

            Else

                _DaysOfWeekType = False
                _DaysOfWeekCaption = "Days of Week"

            End If

        End Sub
        Private Sub SaveCPP1Setting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _CPP1

        End Sub
        Private Sub LoadCPP1Setting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPP1 = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _CPP1 = False

            End If

        End Sub
        Private Sub SaveCPP1CaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1Caption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1Caption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _CPP1Caption

        End Sub
        Private Sub LoadCPP1CaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1Caption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _CPP1Caption = MediaPlanDetailSetting.StringValue

            Else

                _CPP1Caption = MediaPlanning.CPP1Caption

            End If

        End Sub
        Private Sub SaveCPP1IndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1Index.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1Index.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _CPP1Index

        End Sub
        Private Sub LoadCPP1IndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1Index.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPP1Index = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _CPP1Index = -1

            End If

        End Sub
        Private Sub SaveCPP1ShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1ShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1ShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _CPP1ShowTotals

        End Sub
        Private Sub LoadCPP1ShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1ShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPP1ShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _CPP1ShowTotals = False

            End If

        End Sub
        Private Sub SaveCPP1WidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1Width.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1Width.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _CPP1Width

        End Sub
        Private Sub LoadCPP1WidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP1Width.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPP1Width = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _CPP1Width = 100

            End If

        End Sub
        Private Sub SaveCPP2Setting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _CPP2

        End Sub
        Private Sub LoadCPP2Setting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPP2 = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _CPP2 = False

            End If

        End Sub
        Private Sub SaveCPP2CaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2Caption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2Caption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _CPP2Caption

        End Sub
        Private Sub LoadCPP2CaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2Caption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _CPP2Caption = MediaPlanDetailSetting.StringValue

            Else

                _CPP2Caption = MediaPlanning.CPP2Caption

            End If

        End Sub
        Private Sub SaveCPP2IndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2Index.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2Index.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _CPP2Index

        End Sub
        Private Sub LoadCPP2IndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2Index.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPP2Index = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _CPP2Index = -1

            End If

        End Sub
        Private Sub SaveCPP2ShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2ShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2ShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _CPP2ShowTotals

        End Sub
        Private Sub LoadCPP2ShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2ShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPP2ShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _CPP2ShowTotals = False

            End If

        End Sub
        Private Sub SaveCPP2WidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2Width.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2Width.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _CPP2Width

        End Sub
        Private Sub LoadCPP2WidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPP2Width.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPP2Width = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _CPP2Width = 100

            End If

        End Sub
        Private Sub SaveCPISetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPI.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPI.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _CPI

        End Sub
        Private Sub LoadCPISetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPI.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPI = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _CPI = False

            End If

        End Sub
        Private Sub SaveCPICaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPICaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPICaption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _CPICaption

        End Sub
        Private Sub LoadCPICaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPICaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _CPICaption = MediaPlanDetailSetting.StringValue

            Else

                _CPICaption = MediaPlanning.CPICaption

            End If

        End Sub
        Private Sub SaveCPIIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPIIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPIIndex.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _CPIIndex

        End Sub
        Private Sub LoadCPIIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPIIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPIIndex = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _CPIIndex = -1

            End If

        End Sub
        Private Sub SaveCPIShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPIShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPIShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _CPIShowTotals

        End Sub
        Private Sub LoadCPIShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPIShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPIShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _CPIShowTotals = False

            End If

        End Sub
        Private Sub SaveCPIWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPIWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CPIWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _CPIWidth

        End Sub
        Private Sub LoadCPIWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CPIWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CPIWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _CPIWidth = 100

            End If

        End Sub
        Private Sub SaveCTRSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CTR.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CTR.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _CTR

        End Sub
        Private Sub LoadCTRSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CTR.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CTR = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _CTR = False

            End If

        End Sub
        Private Sub SaveCTRCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CTRCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CTRCaption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _CTRCaption

        End Sub
        Private Sub LoadCTRCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CTRCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _CTRCaption = MediaPlanDetailSetting.StringValue

            Else

                _CTRCaption = MediaPlanning.CTRCaption

            End If

        End Sub
        Private Sub SaveCTRIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CTRIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CTRIndex.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _CTRIndex

        End Sub
        Private Sub LoadCTRIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CTRIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CTRIndex = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _CTRIndex = -1

            End If

        End Sub
        Private Sub SaveCTRShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CTRShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CTRShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _CTRShowTotals

        End Sub
        Private Sub LoadCTRShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CTRShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CTRShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _CTRShowTotals = False

            End If

        End Sub
        Private Sub SaveCTRWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CTRWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CTRWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _CTRWidth

        End Sub
        Private Sub LoadCTRWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CTRWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CTRWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _CTRWidth = 100

            End If

        End Sub
        Private Sub SaveConversionRateSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _ConversionRate

        End Sub
        Private Sub LoadConversionRateSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ConversionRate = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _ConversionRate = False

            End If

        End Sub
        Private Sub SaveConversionRateCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateCaption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _ConversionRateCaption

        End Sub
        Private Sub LoadConversionRateCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _ConversionRateCaption = MediaPlanDetailSetting.StringValue

            Else

                _ConversionRateCaption = MediaPlanning.ConversionRateCaption

            End If

        End Sub
        Private Sub SaveConversionRateIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateIndex.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _ConversionRateIndex

        End Sub
        Private Sub LoadConversionRateIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ConversionRateIndex = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _ConversionRateIndex = -1

            End If

        End Sub
        Private Sub SaveConversionRateShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _ConversionRateShowTotals

        End Sub
        Private Sub LoadConversionRateShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ConversionRateShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _ConversionRateShowTotals = False

            End If

        End Sub
        Private Sub SaveConversionRateWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _ConversionRateWidth

        End Sub
        Private Sub LoadConversionRateWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.ConversionRateWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _ConversionRateWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _ConversionRateWidth = 100

            End If

        End Sub
        Private Sub SaveTotalDemo1Setting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _TotalDemo1

        End Sub
        Private Sub LoadTotalDemo1Setting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalDemo1 = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _TotalDemo1 = False

            End If

        End Sub
        Private Sub SaveTotalDemo1CaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1Caption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1Caption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _TotalDemo1Caption

        End Sub
        Private Sub LoadTotalDemo1CaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1Caption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _TotalDemo1Caption = MediaPlanDetailSetting.StringValue

            Else

                _TotalDemo1Caption = MediaPlanning.TotalDemo1Caption

            End If

        End Sub
        Private Sub SaveTotalDemo1IndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1Index.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1Index.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _TotalDemo1Index

        End Sub
        Private Sub LoadTotalDemo1IndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1Index.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalDemo1Index = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _TotalDemo1Index = -1

            End If

        End Sub
        Private Sub SaveTotalDemo1ShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1ShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1ShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _TotalDemo1ShowTotals

        End Sub
        Private Sub LoadTotalDemo1ShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1ShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalDemo1ShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _TotalDemo1ShowTotals = False

            End If

        End Sub
        Private Sub SaveTotalDemo1WidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1Width.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1Width.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _TotalDemo1Width

        End Sub
        Private Sub LoadTotalDemo1WidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo1Width.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalDemo1Width = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _TotalDemo1Width = 100

            End If

        End Sub
        Private Sub SaveTotalDemo2Setting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _TotalDemo2

        End Sub
        Private Sub LoadTotalDemo2Setting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalDemo2 = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _TotalDemo2 = False

            End If

        End Sub
        Private Sub SaveTotalDemo2CaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2Caption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2Caption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _TotalDemo2Caption

        End Sub
        Private Sub LoadTotalDemo2CaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2Caption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _TotalDemo2Caption = MediaPlanDetailSetting.StringValue

            Else

                _TotalDemo2Caption = MediaPlanning.TotalDemo2Caption

            End If

        End Sub
        Private Sub SaveTotalDemo2IndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2Index.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2Index.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _TotalDemo2Index

        End Sub
        Private Sub LoadTotalDemo2IndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2Index.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalDemo2Index = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _TotalDemo2Index = -1

            End If

        End Sub
        Private Sub SaveTotalDemo2ShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2ShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2ShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _TotalDemo2ShowTotals

        End Sub
        Private Sub LoadTotalDemo2ShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2ShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalDemo2ShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _TotalDemo2ShowTotals = False

            End If

        End Sub
        Private Sub SaveTotalDemo2WidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2Width.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2Width.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _TotalDemo2Width

        End Sub
        Private Sub LoadTotalDemo2WidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalDemo2Width.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalDemo2Width = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _TotalDemo2Width = 100

            End If

        End Sub
        Private Sub SaveTotalNetSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _TotalNet

        End Sub
        Private Sub LoadTotalNetSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalNet = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _TotalNet = False

            End If

        End Sub
        Private Sub SaveTotalNetCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetCaption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _TotalNetCaption

        End Sub
        Private Sub LoadTotalNetCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _TotalNetCaption = MediaPlanDetailSetting.StringValue

            Else

                _TotalNetCaption = MediaPlanning.TotalNetCaption

            End If

        End Sub
        Private Sub SaveTotalNetIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetIndex.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _TotalNetIndex

        End Sub
        Private Sub LoadTotalNetIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalNetIndex = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _TotalNetIndex = -1

            End If

        End Sub
        Private Sub SaveTotalNetShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _TotalNetShowTotals

        End Sub
        Private Sub LoadTotalNetShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalNetShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _TotalNetShowTotals = False

            End If

        End Sub
        Private Sub SaveTotalNetWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _TotalNetWidth

        End Sub
        Private Sub LoadTotalNetWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.TotalNetWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _TotalNetWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _TotalNetWidth = 100

            End If

        End Sub
        Private Sub SaveCommissionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Commission.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.Commission.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _Commission

        End Sub
        Private Sub LoadCommissionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.Commission.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _Commission = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _Commission = False

            End If

        End Sub
        Private Sub SaveCommissionCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionCaption.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.StringValue = _CommissionCaption

        End Sub
        Private Sub LoadCommissionCaptionSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionCaption.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing AndAlso MediaPlanDetailSetting.StringValue <> Nothing Then

                _CommissionCaption = MediaPlanDetailSetting.StringValue

            Else

                _CommissionCaption = MediaPlanning.CommissionCaption

            End If

        End Sub
        Private Sub SaveCommissionIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionIndex.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _CommissionIndex

        End Sub
        Private Sub LoadCommissionIndexSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionIndex.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CommissionIndex = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _CommissionIndex = -1

            End If

        End Sub
        Private Sub SaveCommissionShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionShowTotals.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.BooleanValue = _CommissionShowTotals

        End Sub
        Private Sub LoadCommissionShowTotalsSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionShowTotals.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CommissionShowTotals = MediaPlanDetailSetting.BooleanValue.GetValueOrDefault(False)

            Else

                _CommissionShowTotals = False

            End If

        End Sub
        Private Sub SaveCommissionWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _CommissionWidth

        End Sub
        Private Sub LoadCommissionWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.CommissionWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _CommissionWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _CommissionWidth = 100

            End If

        End Sub
        Public Function LoadLastDateColumn() As AdvantageFramework.MediaPlanning.DataColumns

            'objects
            Dim LastDateColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            Try

                MediaPlanDetailField = _MediaPlanDetail.MediaPlanDetailFields.Where(Function(MPDF) MPDF.Area = 1 AndAlso MPDF.IsVisible = True).OrderBy(Function(MPDF) MPDF.AreaIndex).ToList.Last

            Catch ex As Exception
                MediaPlanDetailField = Nothing
            End Try

            If MediaPlanDetailField IsNot Nothing Then

                Try

                    LastDateColumn = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.MediaPlanning.DataColumns), MediaPlanDetailField.FieldID)

                Catch ex As Exception
                    LastDateColumn = AdvantageFramework.MediaPlanning.DataColumns.ID
                End Try

            End If

            LoadLastDateColumn = LastDateColumn

        End Function
        Public Sub LoadQuantityColumn(ByVal IsInitailLoad As Boolean, ByRef RefreshData As Boolean)

            'objects
            Dim FirstVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
            Dim SecondVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
            Dim ThirdVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
            Dim FourthVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID
            Dim FifthVisibleQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID

            FirstVisibleQuantityColumn = _FirstVisibleQuantityColumn
            SecondVisibleQuantityColumn = _SecondVisibleQuantityColumn
            ThirdVisibleQuantityColumn = _ThirdVisibleQuantityColumn
            FourthVisibleQuantityColumn = _FourthVisibleQuantityColumn
            FifthVisibleQuantityColumn = _FifthVisibleQuantityColumn

            _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID
            _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID
            _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID
            _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID
            _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID

            If IsInitailLoad Then

                Try

                    For Each MediaPlanDetailField In _MediaPlanDetail.MediaPlanDetailFields.Where(Function(MPDF) MPDF.Area = 3 AndAlso MPDF.IsVisible = True).OrderBy(Function(MPDF) MPDF.AreaIndex).ToList

                        If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                            If MediaPlanDetailField.IsVisible Then

                                If _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                                ElseIf _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                                ElseIf _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                                ElseIf _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                                ElseIf _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                                End If

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                            If MediaPlanDetailField.IsVisible Then

                                If _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                                ElseIf _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                                ElseIf _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                                ElseIf _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                                ElseIf _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                                End If

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                            If MediaPlanDetailField.IsVisible Then

                                If _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                                ElseIf _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                                ElseIf _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                                ElseIf _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                                ElseIf _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                                End If

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                            If MediaPlanDetailField.IsVisible Then

                                If _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                                ElseIf _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                                ElseIf _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                                ElseIf _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                                ElseIf _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                                End If

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                            If MediaPlanDetailField.IsVisible Then

                                If _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                                ElseIf _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                                ElseIf _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                                ElseIf _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                                ElseIf _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                                End If

                            End If

                        End If

                    Next

                Catch ex As Exception

                End Try

            Else

                Try

                    For Each DataColumn In Me.EstimateDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString) = 3 AndAlso DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString) = True).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString)).ToList

                        If DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                            If _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                            ElseIf _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                            ElseIf _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                            ElseIf _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                            ElseIf _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                            End If

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                            If _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                            ElseIf _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                            ElseIf _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                            ElseIf _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                            ElseIf _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                            End If

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                            If _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                            ElseIf _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                            ElseIf _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                            ElseIf _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                            ElseIf _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                            End If

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                            If _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                            ElseIf _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                            ElseIf _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                            ElseIf _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                            ElseIf _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                            End If

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                            If _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FirstVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                            ElseIf _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _SecondVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                            ElseIf _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _ThirdVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                            ElseIf _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FourthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                            ElseIf _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                _FifthVisibleQuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                            End If

                        End If

                    Next

                Catch ex As Exception

                End Try

                If FirstVisibleQuantityColumn <> _FirstVisibleQuantityColumn OrElse
                        SecondVisibleQuantityColumn <> _SecondVisibleQuantityColumn OrElse
                        ThirdVisibleQuantityColumn <> _ThirdVisibleQuantityColumn OrElse
                        FourthVisibleQuantityColumn <> _FourthVisibleQuantityColumn OrElse
                        FifthVisibleQuantityColumn <> _FifthVisibleQuantityColumn Then

                    RefreshData = True

                    If Me.IsDataLoaded Then

                        RefreshEstimateDataTableData()

                    End If

                End If

            End If

            'LoadFirstVisibleQuantityColumnForCalculationOnly(IsInitailLoad, RefreshData)

        End Sub
        'Public Sub LoadFirstVisibleQuantityColumnForCalculationOnly(IsInitailLoad As Boolean, ByRef RefreshData As Boolean)

        '	'objects
        '	Dim FirstVisibleQuantityColumnForCalculationOnly As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.DataColumns.ID

        '	FirstVisibleQuantityColumnForCalculationOnly = _FirstVisibleQuantityColumnForCalculationOnly

        '	_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.ID

        '	If IsInitailLoad Then

        '		Try

        '			For Each MediaPlanDetailField In _MediaPlanDetail.MediaPlanDetailFields.Where(Function(MPDF) MPDF.Area = 3 AndAlso MPDF.IsVisible = True).OrderBy(Function(MPDF) MPDF.AreaIndex).ToList

        '				If MediaPlanDetailField.IsVisible Then

        '					If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

        '						_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.Demo1
        '						Exit For

        '					ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

        '						_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.Demo2
        '						Exit For

        '					ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

        '						_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.Units
        '						Exit For

        '					ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

        '						_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.Impressions
        '						Exit For

        '					ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

        '						_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.Clicks
        '						Exit For

        '					End If

        '				End If

        '			Next

        '		Catch ex As Exception

        '		End Try

        '	Else

        '		Try

        '			For Each DataColumn In Me.EstimateDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString) = 3 AndAlso DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString) = True).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString)).ToList

        '				If DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

        '					_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.Demo1
        '					Exit For

        '				ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

        '					_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.Demo2
        '					Exit For

        '				ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

        '					_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.Units
        '					Exit For

        '				ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

        '					_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.Impressions
        '					Exit For

        '				ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

        '					_FirstVisibleQuantityColumnForCalculationOnly = AdvantageFramework.MediaPlanning.DataColumns.Clicks
        '					Exit For

        '				End If

        '			Next

        '		Catch ex As Exception

        '		End Try

        '		If FirstVisibleQuantityColumnForCalculationOnly <> _FirstVisibleQuantityColumnForCalculationOnly Then

        '			RefreshData = True

        '			If Me.IsDataLoaded Then

        '				RefreshEstimateDataTableData()

        '			End If

        '		End If

        '	End If

        'End Sub
        Public Sub CreateEstimateDataTable()

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If _MediaPlanDetail IsNot Nothing Then

                If LevelsAndLinesDataTable Is Nothing Then

                    CreateLevelsAndLinesDataTable()

                End If

                _IsEstimateDataTableSaving = True

                EstimateDataTable = New System.Data.DataTable

                EstimateDataTable.BeginLoadData()

                AddHandler EstimateDataTable.Columns.CollectionChanged, AddressOf EstimateDataTable_CollectionChanged

                If _MediaPlanDetail.MediaPlanDetailFields.Any(Function(Entity) Entity.FieldID = AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString) = False Then

                    MediaPlanDetailField = New AdvantageFramework.Database.Entities.MediaPlanDetailField

                    MediaPlanDetailField.MediaPlanID = _MediaPlan.ID
                    MediaPlanDetailField.MediaPlanDetailID = _MediaPlanDetail.ID
                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString
                    MediaPlanDetailField.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString)
                    MediaPlanDetailField.Index = AdvantageFramework.MediaPlanning.DataColumns.NetCharge
                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.AreaIndex = 9

                    MediaPlanDetailField.IsVisible = False
                    MediaPlanDetailField.SortOrder = 0
                    MediaPlanDetailField.Width = 100
                    MediaPlanDetailField.ShowInGrandTotals = True
                    MediaPlanDetailField.ShowInTotals = True
                    MediaPlanDetailField.ShowInValues = True

                    If _MediaPlanDetail.MediaPlanDetailFields Is Nothing Then

                        _MediaPlanDetail.MediaPlanDetailFields = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailField)

                    End If

                    MediaPlanDetailField.CreatedDate = Now
                    MediaPlanDetailField.CreatedByUserCode = _MediaPlan.DbContext.UserCode

                    _MediaPlanDetail.MediaPlanDetailFields.Add(MediaPlanDetailField)
                    _MediaPlan.DbContext.AddEntityObject(MediaPlanDetailField)

                    _MediaPlan.DbContext.SaveChanges()

                End If

                If _MediaPlanDetail.MediaPlanDetailFields.Any(Function(Entity) Entity.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString) = False Then

                    MediaPlanDetailField = New AdvantageFramework.Database.Entities.MediaPlanDetailField

                    MediaPlanDetailField.MediaPlanID = _MediaPlan.ID
                    MediaPlanDetailField.MediaPlanDetailID = _MediaPlanDetail.ID
                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString
                    MediaPlanDetailField.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString)
                    MediaPlanDetailField.Index = AdvantageFramework.MediaPlanning.DataColumns.Columns
                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.AreaIndex = 5

                    MediaPlanDetailField.IsVisible = False
                    MediaPlanDetailField.SortOrder = 0
                    MediaPlanDetailField.Width = 100
                    MediaPlanDetailField.ShowInGrandTotals = False
                    MediaPlanDetailField.ShowInTotals = False
                    MediaPlanDetailField.ShowInValues = True

                    If _MediaPlanDetail.MediaPlanDetailFields Is Nothing Then

                        _MediaPlanDetail.MediaPlanDetailFields = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailField)

                    End If

                    MediaPlanDetailField.CreatedDate = Now
                    MediaPlanDetailField.CreatedByUserCode = _MediaPlan.DbContext.UserCode

                    _MediaPlanDetail.MediaPlanDetailFields.Add(MediaPlanDetailField)
                    _MediaPlan.DbContext.AddEntityObject(MediaPlanDetailField)

                    _MediaPlan.DbContext.SaveChanges()

                End If

                If _MediaPlanDetail.MediaPlanDetailFields.Any(Function(Entity) Entity.FieldID = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString) = False Then

                    MediaPlanDetailField = New AdvantageFramework.Database.Entities.MediaPlanDetailField

                    MediaPlanDetailField.MediaPlanID = _MediaPlan.ID
                    MediaPlanDetailField.MediaPlanDetailID = _MediaPlanDetail.ID
                    MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString
                    MediaPlanDetailField.Caption = "Inches/Lines"
                    MediaPlanDetailField.Index = AdvantageFramework.MediaPlanning.DataColumns.InchesLines
                    MediaPlanDetailField.Area = 3
                    MediaPlanDetailField.AreaIndex = 6

                    MediaPlanDetailField.IsVisible = False
                    MediaPlanDetailField.SortOrder = 0
                    MediaPlanDetailField.Width = 100
                    MediaPlanDetailField.ShowInGrandTotals = False
                    MediaPlanDetailField.ShowInTotals = False
                    MediaPlanDetailField.ShowInValues = True

                    If _MediaPlanDetail.MediaPlanDetailFields Is Nothing Then

                        _MediaPlanDetail.MediaPlanDetailFields = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailField)

                    End If

                    MediaPlanDetailField.CreatedDate = Now
                    MediaPlanDetailField.CreatedByUserCode = _MediaPlan.DbContext.UserCode

                    _MediaPlanDetail.MediaPlanDetailFields.Add(MediaPlanDetailField)
                    _MediaPlan.DbContext.AddEntityObject(MediaPlanDetailField)

                    _MediaPlan.DbContext.SaveChanges()

                End If

                For Each MediaPlanDetailField In Me.MediaPlanDetailFields.OrderBy(Function(Entity) Entity.Index).ToList

                    DataColumn = EstimateDataTable.Columns.Add(MediaPlanDetailField.FieldID)

                    DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString, MediaPlanDetailField.Area)
                    DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString, MediaPlanDetailField.AreaIndex)
                    DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Index.ToString, MediaPlanDetailField.Index)
                    DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString, MediaPlanDetailField.IsVisible)
                    DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInGrandTotals.ToString, MediaPlanDetailField.ShowInGrandTotals)
                    DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInTotals.ToString, MediaPlanDetailField.ShowInTotals)
                    DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInValues.ToString, MediaPlanDetailField.ShowInValues)
                    DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.SortOrder.ToString, MediaPlanDetailField.SortOrder)
                    DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Width.ToString, MediaPlanDetailField.Width)

                    DataColumn.Caption = MediaPlanDetailField.Caption

                    If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.ID.ToString Then

                        DataColumn.AutoIncrement = True
                        DataColumn.AllowDBNull = False
                        EstimateDataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID.ToString Then

                        DataColumn.DataType = GetType(Integer)
                        DataColumn.DefaultValue = 0

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.[Date].ToString Then

                        DataColumn.DataType = GetType(Date)
                        DataColumn.DefaultValue = System.DBNull.Value

                        'If MediaPlanDetailField.AreaIndex > LastDateColumnIndex Then

                        '	LastDateColumn = AdvantageFramework.MediaPlanning.DataColumns.[Date]
                        '	LastDateColumnIndex = MediaPlanDetailField.AreaIndex

                        'End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString Then

                        DataColumn.DataType = GetType(Date)
                        DataColumn.DefaultValue = System.DBNull.Value

                        'If MediaPlanDetailField.AreaIndex > LastDateColumnIndex Then

                        '	LastDateColumn = AdvantageFramework.MediaPlanning.DataColumns.Day
                        '	LastDateColumnIndex = MediaPlanDetailField.AreaIndex

                        'End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                        DataColumn.DataType = GetType(Date)
                        DataColumn.DefaultValue = System.DBNull.Value

                        'If MediaPlanDetailField.AreaIndex > LastDateColumnIndex Then

                        '	LastDateColumn = AdvantageFramework.MediaPlanning.DataColumns.Week
                        '	LastDateColumnIndex = MediaPlanDetailField.AreaIndex

                        'End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                        DataColumn.DataType = GetType(Date)
                        DataColumn.DefaultValue = System.DBNull.Value

                        If DataColumn.Caption = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                            DataColumn.Caption = "Month Name"

                        End If

                        'If MediaPlanDetailField.AreaIndex > LastDateColumnIndex Then

                        '	LastDateColumn = AdvantageFramework.MediaPlanning.DataColumns.MonthName
                        '	LastDateColumnIndex = MediaPlanDetailField.AreaIndex

                        'End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString Then

                        DataColumn.DataType = GetType(Date)
                        DataColumn.DefaultValue = System.DBNull.Value

                        'If MediaPlanDetailField.AreaIndex > LastDateColumnIndex Then

                        '	LastDateColumn = AdvantageFramework.MediaPlanning.DataColumns.Month
                        '	LastDateColumnIndex = MediaPlanDetailField.AreaIndex

                        'End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                        DataColumn.DataType = GetType(Date)
                        DataColumn.DefaultValue = System.DBNull.Value

                        'If MediaPlanDetailField.AreaIndex > LastDateColumnIndex Then

                        '	LastDateColumn = AdvantageFramework.MediaPlanning.DataColumns.Quarter
                        '	LastDateColumnIndex = MediaPlanDetailField.AreaIndex

                        'End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                        DataColumn.DataType = GetType(Date)
                        DataColumn.DefaultValue = System.DBNull.Value

                        'If MediaPlanDetailField.AreaIndex > LastDateColumnIndex Then

                        '	LastDateColumn = AdvantageFramework.MediaPlanning.DataColumns.Year
                        '	LastDateColumnIndex = MediaPlanDetailField.AreaIndex

                        'End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString Then

                        DataColumn.DataType = GetType(Date)
                        DataColumn.DefaultValue = System.DBNull.Value

                        'ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.EndDate.ToString Then

                        '	DataColumn.DataType = GetType(Date)
                        '	DataColumn.DefaultValue = System.DBNull.Value

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString Then

                        DataColumn.DataType = GetType(Integer)
                        DataColumn.DefaultValue = System.DBNull.Value

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                        If DataColumn.Caption = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                            DataColumn.Caption = "Demo 1"

                        End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                        If DataColumn.Caption = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                            DataColumn.Caption = "Demo 2"

                        End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                        If DataColumn.Caption = AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

                            DataColumn.Caption = "Bill Amount"

                        End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                        If DataColumn.Caption = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString Then

                            DataColumn.Caption = "Agency Fee"

                        End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.DefaultValue = System.DBNull.Value

                        If DataColumn.Caption = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                            DataColumn.Caption = "Inches/Lines"

                        End If

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Note.ToString Then

                        DataColumn.DataType = GetType(String)
                        DataColumn.DefaultValue = System.DBNull.Value

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Color.ToString Then

                        DataColumn.DataType = GetType(Integer)
                        DataColumn.AllowDBNull = False
                        DataColumn.DefaultValue = 0

                    ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.LevelLineID.ToString Then

                        DataColumn.DataType = GetType(Integer)
                        DataColumn.AllowDBNull = False
                        DataColumn.DefaultValue = 0

                    End If

                Next

                For Each LevelsAndLineDataColumn In Me.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString).ToList

                    DataColumn = EstimateDataTable.Columns.Add(LevelsAndLineDataColumn.ColumnName)

                    DataColumn.DataType = GetType(String)
                    DataColumn.DefaultValue = ""
                    DataColumn.Caption = DataColumn.ColumnName
                    SetLevelLineColumnProperties(DataColumn, LevelsAndLineDataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine.Properties.MediaPlanDetailLevelID.ToString),
                                                             LevelsAndLineDataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString),
                                                             LevelsAndLineDataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString),
                                                             LevelsAndLineDataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString),
                                                             LevelsAndLineDataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString),
                                                             LevelsAndLineDataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString))

                Next

                CreateEstimateDataTableRows()

                EstimateDataTable.EndLoadData()

                RefreshEntryDates()

                _IsDataLoaded = True

                AddHandler EstimateDataTable.ColumnChanged, AddressOf EstimateDataTable_ColumnChanged

                _IsEstimateDataTableSaving = False

            End If

        End Sub
        Public Sub CreateLevelsAndLinesDataTable()

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim RowIndex As Integer = -1

            If _MediaPlanDetail IsNot Nothing Then

                _IsLevelsAndLinesDataTableSaving = True

                LevelsAndLinesDataTable = New System.Data.DataTable

                AddHandler LevelsAndLinesDataTable.Columns.CollectionChanged, AddressOf LevelsAndLinesDataTable_CollectionChanged

                AdvantageFramework.MediaPlanning.BuildLevelLines(LevelsAndLinesDataTable, _MediaPlanDetail, Me.MediaPlanDetailLevels.ToList)

                RefreshPackageNames()

                _IsLevelAndLinesLoaded = True

                _IsLevelsAndLinesDataTableSaving = False

            End If

        End Sub
        Public Sub RefreshPackageNames()

            _PackageNames = LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(DR) CStr(DR(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString))).Where(Function(PName) String.IsNullOrWhiteSpace(PName) = False).Distinct.ToList

        End Sub
        Public Sub RefreshWidths()

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing

            If Me.IsLevelAndLinesLoaded Then

                For Each MediaPlanDetailLevel In Me.MediaPlanDetailLevels.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                    If Me.LevelsAndLinesDataTable.Columns.Contains(MediaPlanDetailLevel.Description) Then

                        DataColumn = Me.LevelsAndLinesDataTable.Columns(MediaPlanDetailLevel.Description)

                        If DataColumn IsNot Nothing Then

                            SetLevelLineColumnProperties(DataColumn, MediaPlanDetailLevel.ID, MediaPlanDetailLevel.TagType, MediaPlanDetailLevel.Width, MediaPlanDetailLevel.OrderNumber, MediaPlanDetailLevel.MappingType, MediaPlanDetailLevel.IsVisible)

                        End If

                    End If

                Next

            End If

            If Me.IsDataLoaded Then

                For Each MediaPlanDetailField In Me.MediaPlanDetailFields.OrderBy(Function(Entity) Entity.Index).ToList

                    If Me.EstimateDataTable.Columns.Contains(MediaPlanDetailField.FieldID) Then

                        DataColumn = Me.EstimateDataTable.Columns(MediaPlanDetailField.FieldID)

                        If DataColumn IsNot Nothing Then

                            If DataColumn.ExtendedProperties.ContainsKey(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Width.ToString) Then

                                DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Width.ToString) = MediaPlanDetailField.Width

                            Else

                                DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Width.ToString, MediaPlanDetailField.Width)

                            End If

                        End If

                    End If

                Next

                For Each LevelsAndLineDataColumn In Me.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString).ToList

                    If Me.EstimateDataTable.Columns.Contains(LevelsAndLineDataColumn.ColumnName) Then

                        DataColumn = Me.EstimateDataTable.Columns(LevelsAndLineDataColumn.ColumnName)

                        If DataColumn IsNot Nothing Then

                            If DataColumn.ExtendedProperties.ContainsKey(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Width.ToString) Then

                                DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Width.ToString) = LevelsAndLineDataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString)

                            Else

                                DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Width.ToString, LevelsAndLineDataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString))

                            End If

                        End If

                    End If

                Next

            End If

        End Sub
        Private Function CreateEstimateDataTableWeekStartAndEndDates() As Generic.List(Of WeekStartAndEndDates)

            'objects
            Dim WeekStartAndEndDates As Generic.List(Of WeekStartAndEndDates) = Nothing
            Dim MediaPlanDetailDate As Date = Date.MinValue
            Dim StartDate As Date = Date.MinValue

            WeekStartAndEndDates = New Generic.List(Of WeekStartAndEndDates)

            If Me.IsCalendarMonth Then

                StartDate = _MediaPlan.StartDate

                For DateDayCounter = 0 To Math.Abs(DateDiff(DateInterval.Day, _MediaPlan.StartDate, _MediaPlan.EndDate))

                    MediaPlanDetailDate = _MediaPlan.StartDate.AddDays(DateDayCounter)

                    If MediaPlanDetailDate.Month <> StartDate.Month Then

                        WeekStartAndEndDates.Add(New WeekStartAndEndDates(StartDate, MediaPlanDetailDate.AddDays(-1)))
                        StartDate = MediaPlanDetailDate

                    ElseIf GetCalendarMonthWeekDateForEstimate(MediaPlanDetailDate, Me.SplitWeeks) <> GetCalendarMonthWeekDateForEstimate(StartDate, Me.SplitWeeks) Then

                        WeekStartAndEndDates.Add(New WeekStartAndEndDates(StartDate, MediaPlanDetailDate.AddDays(-1)))
                        StartDate = MediaPlanDetailDate

                    ElseIf MediaPlanDetailDate = _MediaPlan.EndDate Then

                        WeekStartAndEndDates.Add(New WeekStartAndEndDates(StartDate, _MediaPlan.EndDate))

                    End If

                Next

                If WeekStartAndEndDates.Any(Function(Entity) Entity.StartDate = StartDate) = False Then

                    WeekStartAndEndDates.Add(New WeekStartAndEndDates(StartDate, _MediaPlan.EndDate))

                End If

            Else

                MediaPlanDetailDate = _MediaPlan.StartDate.AddDays(7)

                Do Until MediaPlanDetailDate.DayOfWeek = DayOfWeek.Monday

                    MediaPlanDetailDate = MediaPlanDetailDate.AddDays(-1)

                Loop

                WeekStartAndEndDates.Add(New WeekStartAndEndDates(_MediaPlan.StartDate, MediaPlanDetailDate.AddDays(-1)))

                Do Until MediaPlanDetailDate >= _MediaPlan.EndDate

                    If MediaPlanDetailDate.AddDays(6) >= _MediaPlan.EndDate Then

                        WeekStartAndEndDates.Add(New WeekStartAndEndDates(MediaPlanDetailDate, _MediaPlan.EndDate))

                    Else

                        WeekStartAndEndDates.Add(New WeekStartAndEndDates(MediaPlanDetailDate, MediaPlanDetailDate.AddDays(6)))

                    End If

                    MediaPlanDetailDate = MediaPlanDetailDate.AddDays(7)

                Loop

            End If

            CreateEstimateDataTableWeekStartAndEndDates = WeekStartAndEndDates

        End Function
        Private Sub CreateEstimateDataTableRows()

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = 0
            Dim MaxRowIndex As Integer = 0
            Dim LevelLineColor As Integer = 0
            Dim MediaPlanLevelLineDataColor As Integer = 0
            Dim WeekStartAndEndDates As Generic.List(Of WeekStartAndEndDates) = Nothing

            If Me.LevelsAndLinesDataTable.Rows.Count > 0 Then

                MaxRowIndex = Me.LevelsAndLinesDataTable.Rows.Count - 1

                WeekStartAndEndDates = CreateEstimateDataTableWeekStartAndEndDates()

                For RowIndex = 0 To MaxRowIndex

                    For Each WeekStartAndEndDate In WeekStartAndEndDates

                        If Me.MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.StartDate >= WeekStartAndEndDate.StartDate AndAlso
                                                                                 Entity.StartDate <= WeekStartAndEndDate.EndDate) Then

                            For Each MediaPlanDetailLevelLineData In Me.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex AndAlso
                                                                                                                             Entity.StartDate >= WeekStartAndEndDate.StartDate AndAlso
                                                                                                                             Entity.StartDate <= WeekStartAndEndDate.EndDate)

                                AddDataRowToEstimateDataTable(MediaPlanDetailLevelLineData, MediaPlanDetailLevelLineData.RowIndex, MediaPlanDetailLevelLineData.StartDate)

                            Next

                        Else

                            AddDataRowToEstimateDataTable(Nothing, RowIndex, WeekStartAndEndDate.StartDate)

                        End If

                    Next

                Next

                UpdateMediaPlanDetailLevelLineDataColorAfterLoading()

            End If

        End Sub
        Private Function GetLevelLineDescription(ByVal DataRow As System.Data.DataRow, ByVal DataColumn As System.Data.DataColumn) As String

            'objects
            Dim Description As String = ""

            If DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) = AdvantageFramework.MediaPlanning.TagTypes.StartDate OrElse
                    DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) = AdvantageFramework.MediaPlanning.TagTypes.EndDate Then

                If DataRow(DataColumn.ColumnName) IsNot System.DBNull.Value AndAlso DataRow(DataColumn.ColumnName) <> "" Then

                    Try

                        Description = CDate(DataRow(DataColumn.ColumnName)).ToShortDateString

                    Catch ex As Exception
                        Description = ""
                    End Try

                Else

                    Description = ""

                End If

            Else

                If DataRow(DataColumn.ColumnName) Is System.DBNull.Value Then

                    Description = ""

                Else

                    Description = DataRow(DataColumn.ColumnName)

                End If

            End If

            GetLevelLineDescription = Description

        End Function
        Public Function GetVendorLevelLineTag(RowIndex As Integer) As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag

            'objects
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing

            MediaPlanDetailLevel = Me.MediaPlanDetailLevels.FirstOrDefault(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor)

            If MediaPlanDetailLevel IsNot Nothing Then

                MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.FirstOrDefault(Function(Entity) Entity.RowIndex = RowIndex)

                If MediaPlanDetailLevelLine IsNot Nothing AndAlso MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing Then

                    MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.FirstOrDefault(Function(Entity) Entity.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID)

                End If

            End If

            GetVendorLevelLineTag = MediaPlanDetailLevelLineTag

        End Function
        Public Sub RefreshEstimateDataTableDates()

            _IsEstimateDataTableSaving = True

            Me.EstimateDataTable.BeginLoadData()

            Me.EstimateDataTable.Clear()

            CreateEstimateDataTableRows()

            Me.EstimateDataTable.EndLoadData()

            RefreshEntryDates()

            _IsEstimateDataTableSaving = False

        End Sub
        Public Sub RefreshEstimateDataTableData(Optional RowIndexes As Generic.List(Of Integer) = Nothing)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing

            _IsEstimateDataTableSaving = True

            Me.EstimateDataTable.BeginLoadData()

            If RowIndexes IsNot Nothing AndAlso RowIndexes.Count > 0 Then

                MediaPlanDetailLevelLineDatas = Me.MediaPlanDetailLevelLineDatas.Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex)).ToList

            Else

                MediaPlanDetailLevelLineDatas = Me.MediaPlanDetailLevelLineDatas.ToList

            End If

            For Each MediaPlanDetailLevelLineData In MediaPlanDetailLevelLineDatas

                FillMediaPlanDetailLevelLineData(Me, MediaPlanDetailLevelLineData)

                Try

                    DataRow = Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow)().SingleOrDefault(Function(DR) MediaPlanDetailLevelLineData.RowIndex = DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) AndAlso MediaPlanDetailLevelLineData.StartDate = DR(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))

                Catch ex As Exception
                    DataRow = Nothing
                End Try

                If DataRow IsNot Nothing Then

                    FillMediaPlanDetailDataRowData(DataRow, MediaPlanDetailLevelLineData)

                End If

            Next

            Me.EstimateDataTable.EndLoadData()

            _IsEstimateDataTableSaving = False

        End Sub
        Public Sub CalculateQtyEstimateDataTableData()

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            _IsEstimateDataTableSaving = True

            Me.EstimateDataTable.BeginLoadData()

            For Each MediaPlanDetailLevelLineData In Me.MediaPlanDetailLevelLineDatas

                FillMediaPlanDetailLevelLineDataForAutoCalculate(Me, MediaPlanDetailLevelLineData)

                Try

                    DataRow = Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow)().SingleOrDefault(Function(DR) MediaPlanDetailLevelLineData.RowIndex = DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) AndAlso MediaPlanDetailLevelLineData.StartDate = DR(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))

                Catch ex As Exception
                    DataRow = Nothing
                End Try

                If DataRow IsNot Nothing Then

                    FillMediaPlanDetailDataRowData(DataRow, MediaPlanDetailLevelLineData)

                End If

            Next

            Me.EstimateDataTable.EndLoadData()

            _IsEstimateDataTableSaving = False

        End Sub
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.TryAttach(_MediaPlanDetail)

                For Each MediaPlanDetailField In _MediaPlanDetail.MediaPlanDetailFields.ToList

                    DbContext.DeleteEntityObject(MediaPlanDetailField)

                Next

                For Each MediaPlanDetailSetting In _MediaPlanDetail.MediaPlanDetailSettings.ToList

                    DbContext.DeleteEntityObject(MediaPlanDetailSetting)

                Next

                For Each MediaPlanDetailChangeLog In _MediaPlanDetail.MediaPlanDetailChangeLogs.ToList

                    DbContext.DeleteEntityObject(MediaPlanDetailChangeLog)

                Next

                For Each MediaPlanDetailLevelLineData In _MediaPlanDetail.MediaPlanDetailLevelLineDatas.ToList

                    DbContext.DeleteEntityObject(MediaPlanDetailLevelLineData)

                Next

                For Each MediaPlanDetailPackageDetail In _MediaPlanDetail.MediaPlanDetailPackageDetails.ToList

                    DbContext.DeleteEntityObject(MediaPlanDetailPackageDetail)

                Next

                For Each MediaPlanDetailPackagePlacementName In _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.ToList

                    DbContext.DeleteEntityObject(MediaPlanDetailPackagePlacementName)

                Next

                For Each MediaPlanDetailGRPBudget In _MediaPlanDetail.MediaPlanDetailGRPBudgets.ToList

                    DbContext.DeleteEntityObject(MediaPlanDetailGRPBudget)

                Next

                For Each MediaPlanDetailLevel In _MediaPlanDetail.MediaPlanDetailLevels.ToList

                    For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.ToList

                        For Each MediaPlanDetailLevelLineTag In MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.ToList

                            DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                        Next

                        DbContext.DeleteEntityObject(MediaPlanDetailLevelLine)

                    Next

                    DbContext.DeleteEntityObject(MediaPlanDetailLevel)

                Next

                DbContext.DeleteEntityObject(_MediaPlanDetail)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            End Try

            Delete = Deleted

        End Function
        Public Function Save(ByRef DbContext As AdvantageFramework.Database.DbContext, ByRef MediaPlan As AdvantageFramework.Database.Entities.MediaPlan, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim MediaPlanDetailFieldsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailField) = Nothing
            Dim MediaPlanDetailSettingsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailSetting) = Nothing
            Dim MediaPlanDetailLevelLineDatasList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim MediaPlanDetailLevelsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel) = Nothing
            Dim MediaPlanDetailLevelLinesList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) = Nothing
            Dim MediaPlanDetailLevelLineTagsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag) = Nothing
            Dim MediaPlanDetailPackageDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail) = Nothing
            Dim MediaPlanDetailLevelLines As Hashtable = Nothing
            Dim MediaPlanDetailLevelLineTags As Hashtable = Nothing
            Dim CheckMediaPlanDetailLevelsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel) = Nothing
            Dim MPDL As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailPackagePlacementNameList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName) = Nothing

            Try

                If _MediaPlanDetail.MediaPlanDetailPackagePlacementNames Is Nothing Then

                    _MediaPlanDetail.MediaPlanDetailPackagePlacementNames = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName)

                End If

                If _MediaPlanDetail.IsEntityBeingAdded() Then

                    If MediaPlan.MediaPlanDetails.Contains(_MediaPlanDetail) = False AndAlso _MediaPlanDetail.MediaPlan IsNot MediaPlan Then

                        MediaPlan.MediaPlanDetails.Add(_MediaPlanDetail)

                    End If

                    _MediaPlanDetail.CreatedByUserCode = DbContext.UserCode
                    _MediaPlanDetail.CreatedDate = Now

                    DbContext.AddEntityObject(_MediaPlanDetail)

                Else

                    _MediaPlanDetail.ModifiedByUserCode = DbContext.UserCode
                    _MediaPlanDetail.ModifiedDate = Now

                End If

                MediaPlanDetailFieldsList = _MediaPlanDetail.MediaPlanDetailFields.ToList
                MediaPlanDetailSettingsList = _MediaPlanDetail.MediaPlanDetailSettings.ToList
                MediaPlanDetailLevelLineDatasList = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.ToList
                MediaPlanDetailLevelsList = _MediaPlanDetail.MediaPlanDetailLevels.ToList
                MediaPlanDetailPackageDetailsList = _MediaPlanDetail.MediaPlanDetailPackageDetails.ToList
                MediaPlanDetailPackagePlacementNameList = _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.ToList

                MediaPlanDetailLevelLines = New Hashtable
                MediaPlanDetailLevelLineTags = New Hashtable

                For Each MediaPlanDetailLevel In MediaPlanDetailLevelsList

                    If MediaPlanDetailLevel.MediaPlanDetailLevelLines IsNot Nothing Then

                        MediaPlanDetailLevelLinesList = MediaPlanDetailLevel.MediaPlanDetailLevelLines.ToList

                    Else

                        MediaPlanDetailLevelLinesList = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                    End If

                    MediaPlanDetailLevelLines(MediaPlanDetailLevel) = MediaPlanDetailLevelLinesList

                    For Each MediaPlanDetailLevelLine In MediaPlanDetailLevelLinesList

                        If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing Then

                            MediaPlanDetailLevelLineTagsList = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.ToList

                        Else

                            MediaPlanDetailLevelLineTagsList = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

                        End If

                        MediaPlanDetailLevelLineTags(MediaPlanDetailLevelLine) = MediaPlanDetailLevelLineTagsList

                    Next

                Next

                DbContext.TryAttach(_MediaPlanDetail)

                If _MediaPlanDetail.IsEntityBeingAdded() = False Then

                    DbContext.UpdateObject(_MediaPlanDetail)

                End If

                For Each MediaPlanDetailField In MediaPlanDetailFieldsList

                    DbContext.TryAttach(MediaPlanDetailField)

                    If MediaPlanDetailField.IsEntityBeingAdded() Then

                        If _MediaPlanDetail.MediaPlanDetailFields.Contains(MediaPlanDetailField) = False AndAlso MediaPlanDetailField.MediaPlanDetail IsNot _MediaPlanDetail Then

                            _MediaPlanDetail.MediaPlanDetailFields.Add(MediaPlanDetailField)

                        End If

                        MediaPlanDetailField.CreatedByUserCode = DbContext.UserCode
                        MediaPlanDetailField.CreatedDate = Now

                        DbContext.AddEntityObject(MediaPlanDetailField)

                    Else

                        DbContext.UpdateObject(MediaPlanDetailField)

                        MediaPlanDetailField.ModifiedByUserCode = DbContext.UserCode
                        MediaPlanDetailField.ModifiedDate = Now

                    End If

                Next

                For Each MediaPlanDetailSetting In MediaPlanDetailSettingsList

                    DbContext.TryAttach(MediaPlanDetailSetting)

                    If MediaPlanDetailSetting.IsEntityBeingAdded() Then

                        If _MediaPlanDetail.MediaPlanDetailSettings.Contains(MediaPlanDetailSetting) = False AndAlso MediaPlanDetailSetting.MediaPlanDetail IsNot _MediaPlanDetail Then

                            _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

                        End If

                        MediaPlanDetailSetting.CreatedByUserCode = DbContext.UserCode
                        MediaPlanDetailSetting.CreatedDate = Now

                        DbContext.AddEntityObject(MediaPlanDetailSetting)

                    Else

                        DbContext.UpdateObject(MediaPlanDetailSetting)

                        MediaPlanDetailSetting.ModifiedByUserCode = DbContext.UserCode
                        MediaPlanDetailSetting.ModifiedDate = Now

                    End If

                Next

                If _MediaPlanDetail.MediaPlanDetailLevelLineDatas Is Nothing Then

                    _MediaPlanDetail.MediaPlanDetailLevelLineDatas = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

                End If

                For Each MediaPlanDetailLevelLineData In MediaPlanDetailLevelLineDatasList

                    DbContext.TryAttach(MediaPlanDetailLevelLineData)

                    If MediaPlanDetailLevelLineData.IsEntityBeingAdded() Then

                        If _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Contains(MediaPlanDetailLevelLineData) = False AndAlso MediaPlanDetailLevelLineData.MediaPlanDetail IsNot _MediaPlanDetail Then

                            _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Add(MediaPlanDetailLevelLineData)

                        End If

                        MediaPlanDetailLevelLineData.CreatedByUserCode = DbContext.UserCode
                        MediaPlanDetailLevelLineData.CreatedDate = Now

                        DbContext.AddEntityObject(MediaPlanDetailLevelLineData)

                    Else

                        DbContext.UpdateObject(MediaPlanDetailLevelLineData)

                        MediaPlanDetailLevelLineData.ModifiedByUserCode = DbContext.UserCode
                        MediaPlanDetailLevelLineData.ModifiedDate = Now

                    End If

                Next

                For Each MediaPlanDetailPackageDetail In MediaPlanDetailPackageDetailsList

                    DbContext.TryAttach(MediaPlanDetailPackageDetail)

                    If MediaPlanDetailPackageDetail.IsEntityBeingAdded() Then

                        If _MediaPlanDetail.MediaPlanDetailPackageDetails.Contains(MediaPlanDetailPackageDetail) = False AndAlso MediaPlanDetailPackageDetail.MediaPlanDetail IsNot _MediaPlanDetail Then

                            _MediaPlanDetail.MediaPlanDetailPackageDetails.Add(MediaPlanDetailPackageDetail)

                        End If

                        MediaPlanDetailPackageDetail.CreatedByUserCode = DbContext.UserCode
                        MediaPlanDetailPackageDetail.CreatedDate = Now

                        DbContext.AddEntityObject(MediaPlanDetailPackageDetail)

                    Else

                        DbContext.UpdateObject(MediaPlanDetailPackageDetail)

                    End If

                Next

                For Each MediaPlanDetailPackagePlacementName In MediaPlanDetailPackagePlacementNameList

                    DbContext.TryAttach(MediaPlanDetailPackagePlacementName)

                    If MediaPlanDetailPackagePlacementName.IsEntityBeingAdded() Then

                        If _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Contains(MediaPlanDetailPackagePlacementName) = False AndAlso MediaPlanDetailPackagePlacementName.MediaPlanDetail IsNot _MediaPlanDetail Then

                            _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Add(MediaPlanDetailPackagePlacementName)

                        End If

                        MediaPlanDetailPackagePlacementName.CreatedByUserCode = DbContext.UserCode
                        MediaPlanDetailPackagePlacementName.CreatedDate = Now

                        DbContext.AddEntityObject(MediaPlanDetailPackagePlacementName)

                    Else

                        DbContext.UpdateObject(MediaPlanDetailPackagePlacementName)

                    End If

                Next

                For Each MediaPlanDetailLevel In MediaPlanDetailLevelsList

                    MediaPlanDetailLevelLinesList = MediaPlanDetailLevelLines(MediaPlanDetailLevel)

                    DbContext.TryAttach(MediaPlanDetailLevel)

                    If MediaPlanDetailLevel.IsEntityBeingAdded() Then

                        If _MediaPlanDetail.MediaPlanDetailLevels.Contains(MediaPlanDetailLevel) = False AndAlso MediaPlanDetailLevel.MediaPlanDetail IsNot _MediaPlanDetail Then

                            _MediaPlanDetail.MediaPlanDetailLevels.Add(MediaPlanDetailLevel)

                        End If

                        MediaPlanDetailLevel.CreatedByUserCode = DbContext.UserCode
                        MediaPlanDetailLevel.CreatedDate = Now

                        DbContext.AddEntityObject(MediaPlanDetailLevel)

                    Else

                        DbContext.UpdateObject(MediaPlanDetailLevel)

                        MediaPlanDetailLevel.ModifiedByUserCode = DbContext.UserCode
                        MediaPlanDetailLevel.ModifiedDate = Now

                    End If

                    If MediaPlanDetailLevel.MediaPlanDetailLevelLines Is Nothing Then

                        MediaPlanDetailLevel.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                    End If

                    For Each MediaPlanDetailLevelLine In MediaPlanDetailLevelLinesList

                        MediaPlanDetailLevelLineTagsList = MediaPlanDetailLevelLineTags(MediaPlanDetailLevelLine)

                        DbContext.TryAttach(MediaPlanDetailLevelLine)

                        If MediaPlanDetailLevelLine.IsEntityBeingAdded() Then

                            If MediaPlanDetailLevel.MediaPlanDetailLevelLines.Contains(MediaPlanDetailLevelLine) = False AndAlso MediaPlanDetailLevelLine.MediaPlanDetailLevel IsNot MediaPlanDetailLevel Then

                                MediaPlanDetailLevel.MediaPlanDetailLevelLines.Add(MediaPlanDetailLevelLine)

                            End If

                            MediaPlanDetailLevelLine.CreatedByUserCode = DbContext.UserCode
                            MediaPlanDetailLevelLine.CreatedDate = Now

                            DbContext.AddEntityObject(MediaPlanDetailLevelLine)

                        Else

                            DbContext.UpdateObject(MediaPlanDetailLevelLine)

                            MediaPlanDetailLevelLine.ModifiedByUserCode = DbContext.UserCode
                            MediaPlanDetailLevelLine.ModifiedDate = Now

                        End If

                        If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags Is Nothing Then

                            MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

                        End If

                        For Each MediaPlanDetailLevelLineTag In MediaPlanDetailLevelLineTagsList

                            DbContext.TryAttach(MediaPlanDetailLevelLineTag)

                            If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() Then

                                If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Contains(MediaPlanDetailLevelLineTag) = False AndAlso MediaPlanDetailLevelLineTag.MediaPlanDetailLevelLine IsNot MediaPlanDetailLevelLine Then

                                    MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Add(MediaPlanDetailLevelLineTag)

                                End If

                                MediaPlanDetailLevelLineTag.CreatedByUserCode = DbContext.UserCode
                                MediaPlanDetailLevelLineTag.CreatedDate = Now

                                DbContext.AddEntityObject(MediaPlanDetailLevelLineTag)

                            Else

                                DbContext.UpdateObject(MediaPlanDetailLevelLineTag)

                                MediaPlanDetailLevelLineTag.ModifiedByUserCode = DbContext.UserCode
                                MediaPlanDetailLevelLineTag.ModifiedDate = Now

                            End If

                        Next

                    Next

                Next

                Saved = True

                CheckMediaPlanDetailLevelsList = DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevel).Where(Function(Entity) Entity.MediaPlanID = _MediaPlanDetail.MediaPlanID AndAlso
                                                                                                                                      Entity.MediaPlanDetailID = _MediaPlanDetail.ID).ToList

                For Each MediaPlanDetailLevel In MediaPlanDetailLevelsList

                    If CheckMediaPlanDetailLevelsList.Any(Function(Entity) Entity.Description = MediaPlanDetailLevel.Description AndAlso
                                                                           Entity.EntityKey <> MediaPlanDetailLevel.EntityKey) Then

                        If CheckMediaPlanDetailLevelsList.Where(Function(Entity) Entity.Description = MediaPlanDetailLevel.Description AndAlso
                                                                                 Entity.EntityKey <> MediaPlanDetailLevel.EntityKey).Count = 1 Then

                            MPDL = CheckMediaPlanDetailLevelsList.Where(Function(Entity) Entity.Description = MediaPlanDetailLevel.Description AndAlso
                                                                                         Entity.EntityKey <> MediaPlanDetailLevel.EntityKey).SingleOrDefault

                            If MPDL IsNot Nothing Then

                                If MediaPlanDetailLevelsList.Any(Function(Entity) Entity.EntityKey = MPDL.EntityKey AndAlso MPDL.Description <> Entity.Description) = False Then

                                    Saved = False
                                    ErrorMessage = "Please enter a unique level description. (" & MediaPlanDetailLevel.Description & ")"

                                End If

                            End If

                        Else

                            Saved = False
                            ErrorMessage = "Please enter a unique level description. (" & MediaPlanDetailLevel.Description & ")"

                        End If

                    End If

                Next

                _HasChanged = False

            Catch ex As Exception
                Saved = False
                AdvantageFramework.Navigation.ShowError(ex)
            End Try

            Save = Saved

        End Function
        Public Sub SaveFieldWidth(MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel, Width As Integer)

            If MediaPlanDetailLevel IsNot Nothing Then

                MediaPlanDetailLevel.Width = Width

                If Me.IsDataLoaded Then

                    Me.EstimateDataTable.Columns(MediaPlanDetailLevel.Description).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString) = Width
                    Me.LevelsAndLinesDataTable.Columns(MediaPlanDetailLevel.Description).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString) = Width

                End If

            End If

        End Sub
        Public Sub SaveFieldWidth(ByVal FieldName As String, ByVal IsRowArea As Boolean, ByVal Width As Integer)

            'objects
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If IsRowArea Then

                Try

                    MediaPlanDetailLevel = _MediaPlanDetail.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.Description = FieldName)

                Catch ex As Exception
                    MediaPlanDetailLevel = Nothing
                End Try

                If MediaPlanDetailLevel IsNot Nothing Then

                    MediaPlanDetailLevel.Width = Width

                    If Me.IsDataLoaded Then

                        Me.EstimateDataTable.Columns(FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString) = Width
                        Me.LevelsAndLinesDataTable.Columns(FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString) = Width

                    End If

                Else

                    If FieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString Then

                        Me.PackageLevelWidth = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString Then

                        Me.DateRangeWidth = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString Then

                        Me.AdSizesWidth = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.PackagePlacementWidth.ToString Then

                        Me.PackagePlacementWidth = Width

                    End If

                End If

            Else

                Try

                    MediaPlanDetailField = _MediaPlanDetail.MediaPlanDetailFields.SingleOrDefault(Function(Entity) Entity.FieldID = FieldName)

                Catch ex As Exception
                    MediaPlanDetailField = Nothing
                End Try

                If MediaPlanDetailField IsNot Nothing Then

                    MediaPlanDetailField.Width = Width

                    If Me.IsDataLoaded Then

                        Me.EstimateDataTable.Columns(FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Width.ToString) = Width

                    End If

                Else

                    If FieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString Then

                        Me.CTRWidth = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString Then

                        Me.ConversionRateWidth = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString Then

                        Me.NetDollarsWidth = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString Then

                        Me.CPIWidth = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString Then

                        Me.CPP1Width = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString Then

                        Me.CPP2Width = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString Then

                        Me.TotalDemo1Width = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString Then

                        Me.TotalDemo2Width = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString Then

                        Me.TotalNetWidth = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString Then

                        Me.CommissionWidth = Width

                    ElseIf FieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString Then

                        Me.GrossPercentageInTotalsWidth = Width

                    End If

                End If

            End If

        End Sub
        Public Sub SetOrderNumber(ByVal OrderNumber As Integer)

            _MediaPlanDetail.OrderNumber = OrderNumber

        End Sub
        Public Sub ClearMediaPlanDetailLevelLineDataFromEstimateDataTable(StartDate As Date, RowIndex As Integer)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            _IsEstimateDataTableSaving = True

            DataRow = Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(DataColumns.RowIndex.ToString) = RowIndex AndAlso DR(DataColumns.StartDate.ToString) = StartDate)

            If DataRow IsNot Nothing Then

                FillMediaPlanDetailDataRowData(DataRow, Nothing)

            End If

            _IsEstimateDataTableSaving = False

        End Sub
        Public Sub ClearMediaPlanDetailLevelLineDataFromEstimateDataTable(ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            ClearMediaPlanDetailLevelLineDataFromEstimateDataTable(MediaPlanDetailLevelLineData.StartDate, MediaPlanDetailLevelLineData.RowIndex)

        End Sub
        Public Sub ClearMediaPlanDetailLevelLineData(ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            _IsEstimateDataTableSaving = True

            If MediaPlanDetailLevelLineData IsNot Nothing Then

                MediaPlanDetailLevelLineData.Demo1 = Nothing
                MediaPlanDetailLevelLineData.Demo2 = Nothing
                MediaPlanDetailLevelLineData.Units = Nothing
                MediaPlanDetailLevelLineData.Clicks = Nothing
                MediaPlanDetailLevelLineData.Impressions = Nothing
                MediaPlanDetailLevelLineData.Dollars = Nothing
                MediaPlanDetailLevelLineData.AgencyFee = Nothing
                MediaPlanDetailLevelLineData.BillAmount = Nothing

                MediaPlanDetailLevelLineData.Note = Nothing

                If MediaPlanDetailLevelLineData.OrderNumber Is Nothing AndAlso MediaPlanDetailLevelLineData.HasPendingOrders = False Then

                    MediaPlanDetailLevelLineData.Rate = Nothing

                End If

                If DoesMediaPlanDetailLevelLineDataHaveData(MediaPlanDetailLevelLineData) = False Then

                    MediaPlanDetailLevelLineData.Color = 0

                    UpdateMediaPlanDetailLevelLineDataColor(MediaPlanDetailLevelLineData)

                End If

                DataRow = Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(DataColumns.RowIndex.ToString) = MediaPlanDetailLevelLineData.RowIndex AndAlso DR(DataColumns.StartDate.ToString) = MediaPlanDetailLevelLineData.StartDate)

                If DataRow IsNot Nothing Then

                    FillMediaPlanDetailDataRowData(DataRow, MediaPlanDetailLevelLineData)

                End If

            End If

            _IsEstimateDataTableSaving = False

            RaiseEvent EstimateChangedEvent()

        End Sub
        Public Sub RemoveMediaPlanDetailLevelLineData(ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            _IsEstimateDataTableSaving = True

            _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Remove(MediaPlanDetailLevelLineData)

            If MediaPlanDetailLevelLineData.IsEntityBeingAdded = False Then

                _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLineData)

            End If

            DataRow = Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(DataColumns.RowIndex.ToString) = MediaPlanDetailLevelLineData.RowIndex AndAlso DR(DataColumns.StartDate.ToString) = MediaPlanDetailLevelLineData.StartDate)

            If DataRow IsNot Nothing Then

                FillMediaPlanDetailDataRowData(DataRow, Nothing)

            End If

            Me.EstimateDataTable.AcceptChanges()

            MediaPlanDetailLevelLineData.Color = 0

            UpdateMediaPlanDetailLevelLineDataColor(MediaPlanDetailLevelLineData)

            _IsEstimateDataTableSaving = False

            RaiseEvent EstimateChangedEvent()

        End Sub
        Public Function DoesMediaPlanDetailLevelLineDataHaveData(DataRow As System.Data.DataRow) As Boolean

            'objects
            Dim HasData As Boolean = False
            Dim HasOrders As Boolean = False
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            If DataRow IsNot Nothing Then

                MediaPlanDetailLevelLineData = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(Entity) Entity.StartDate = DataRow(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString) AndAlso
                                                                                                                               Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))

                If MediaPlanDetailLevelLineData IsNot Nothing Then

                    HasOrders = (MediaPlanDetailLevelLineData.OrderNumber IsNot Nothing OrElse MediaPlanDetailLevelLineData.HasPendingOrders = True)

                End If

                If HasOrders = False Then

                    If (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "") OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString) <> 0) Then

                        HasData = True

                    End If

                Else

                    If (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "") OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString) <> 0) OrElse
                            (IsDBNull(DataRow(AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString)) = False AndAlso DataRow(AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString) <> 0) Then

                        HasData = True

                    End If

                End If

            End If

            DoesMediaPlanDetailLevelLineDataHaveData = HasData

        End Function
        Public Function DoesMediaPlanDetailLevelLineDataHaveData(MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) As Boolean

            'objects
            Dim HasData As Boolean = False
            Dim HasOrders As Boolean = False

            If MediaPlanDetailLevelLineData IsNot Nothing Then

                HasOrders = (MediaPlanDetailLevelLineData.OrderNumber IsNot Nothing OrElse MediaPlanDetailLevelLineData.HasPendingOrders = True)

                If HasOrders = False Then

                    If MediaPlanDetailLevelLineData.Demo1 <> 0 OrElse
                            MediaPlanDetailLevelLineData.Demo2 <> 0 OrElse
                            MediaPlanDetailLevelLineData.Dollars <> 0 OrElse
                            MediaPlanDetailLevelLineData.Units <> 0 OrElse
                            MediaPlanDetailLevelLineData.Rate <> 0 OrElse
                            MediaPlanDetailLevelLineData.Note <> "" OrElse
                            MediaPlanDetailLevelLineData.Impressions <> 0 OrElse
                            MediaPlanDetailLevelLineData.Clicks <> 0 Then

                        HasData = True

                    End If

                Else

                    If MediaPlanDetailLevelLineData.Demo1 <> 0 OrElse
                            MediaPlanDetailLevelLineData.Demo2 <> 0 OrElse
                            MediaPlanDetailLevelLineData.Dollars <> 0 OrElse
                            MediaPlanDetailLevelLineData.Units <> 0 OrElse
                            MediaPlanDetailLevelLineData.Note <> "" OrElse
                            MediaPlanDetailLevelLineData.Impressions <> 0 OrElse
                            MediaPlanDetailLevelLineData.Clicks <> 0 Then

                        HasData = True

                    End If

                End If

            End If

            DoesMediaPlanDetailLevelLineDataHaveData = HasData

        End Function
        Public Function DoesEstimateHaveData() As Boolean

            'objects
            Dim HasData As Boolean = False
            Dim HasOrders As Boolean = False
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            For Each MediaPlanDetailLevelLineData In _MediaPlanDetail.MediaPlanDetailLevelLineDatas

                HasOrders = (MediaPlanDetailLevelLineData.OrderNumber IsNot Nothing OrElse MediaPlanDetailLevelLineData.HasPendingOrders = True)

                If HasOrders = False Then

                    If MediaPlanDetailLevelLineData.Demo1 <> 0 OrElse
                            MediaPlanDetailLevelLineData.Demo2 <> 0 OrElse
                            MediaPlanDetailLevelLineData.Dollars <> 0 OrElse
                            MediaPlanDetailLevelLineData.Units <> 0 OrElse
                            MediaPlanDetailLevelLineData.Rate <> 0 OrElse
                            MediaPlanDetailLevelLineData.Note <> "" OrElse
                            MediaPlanDetailLevelLineData.Impressions <> 0 OrElse
                            MediaPlanDetailLevelLineData.Clicks <> 0 Then

                        HasData = True

                    End If

                Else

                    If MediaPlanDetailLevelLineData.Demo1 <> 0 OrElse
                            MediaPlanDetailLevelLineData.Demo2 <> 0 OrElse
                            MediaPlanDetailLevelLineData.Dollars <> 0 OrElse
                            MediaPlanDetailLevelLineData.Units <> 0 OrElse
                            MediaPlanDetailLevelLineData.Note <> "" OrElse
                            MediaPlanDetailLevelLineData.Impressions <> 0 OrElse
                            MediaPlanDetailLevelLineData.Clicks <> 0 Then

                        HasData = True

                    End If

                End If

            Next

            DoesEstimateHaveData = HasData

        End Function
        Public Function DoesEstimateHaveAnyData() As Boolean

            'objects
            Dim HasData As Boolean = False

            If _MediaPlanDetail IsNot Nothing AndAlso _MediaPlanDetail.MediaPlanDetailLevelLineDatas IsNot Nothing Then

                HasData = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Any

            Else

                HasData = False

            End If

            DoesEstimateHaveAnyData = HasData

        End Function
        Public Sub UpdateMediaPlanDetailLevelLineDataColor()

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim LevelLineColor As Integer = 0

            _IsEstimateDataTableSaving = True

            Me.EstimateDataTable.BeginLoadData()

            For Each MediaPlanDetailLevelLineData In _MediaPlanDetail.MediaPlanDetailLevelLineDatas

                LevelLineColor = 0

                If _MediaPlanDetail.MediaPlanDetailLevelLines.Any(Function(Entity) Entity.RowIndex = MediaPlanDetailLevelLineData.RowIndex AndAlso Entity.Color <> 0) Then

                    LevelLineColor = _MediaPlanDetail.MediaPlanDetailLevelLines.Where(Function(Entity) Entity.RowIndex = MediaPlanDetailLevelLineData.RowIndex AndAlso Entity.Color <> 0).Max(Function(Entity) Entity.Color)

                End If

                DataRow = Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(DataColumns.RowIndex.ToString) = MediaPlanDetailLevelLineData.RowIndex AndAlso DR(DataColumns.StartDate.ToString) = MediaPlanDetailLevelLineData.StartDate)

                If DataRow IsNot Nothing Then

                    If DoesMediaPlanDetailLevelLineDataHaveData(MediaPlanDetailLevelLineData) Then

                        If LevelLineColor <> 0 Then

                            MediaPlanDetailLevelLineData.Color = LevelLineColor

                        Else

                            MediaPlanDetailLevelLineData.Color = _MediaPlanDetail.Color

                        End If

                    Else

                        MediaPlanDetailLevelLineData.Color = 0

                    End If

                    If MediaPlanDetailLevelLineData.IsEntityBeingAdded = False Then

                        MediaPlanDetailLevelLineData.ModifiedByUserCode = _MediaPlan.DbContext.UserCode
                        MediaPlanDetailLevelLineData.ModifiedDate = Now

                    End If

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = MediaPlanDetailLevelLineData.Color

                End If

            Next

            Me.EstimateDataTable.EndLoadData()

            _IsEstimateDataTableSaving = False

            RaiseEvent EstimateChangedEvent()

        End Sub
        Public Sub UpdateMediaPlanDetailLevelLineDataColorAfterLoading()

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            _IsEstimateDataTableSaving = True

            For Each MediaPlanDetailLevelLineData In _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.StartDate <> Entity.EndDate).ToList

                For Each DataRow In Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(DataColumns.RowIndex.ToString) = MediaPlanDetailLevelLineData.RowIndex AndAlso
                                                                                                                MediaPlanDetailLevelLineData.StartDate <= DR(DataColumns.StartDate.ToString) AndAlso
                                                                                                                MediaPlanDetailLevelLineData.EndDate >= DR(DataColumns.StartDate.ToString))

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = MediaPlanDetailLevelLineData.Color

                Next

            Next

            _IsEstimateDataTableSaving = False

        End Sub
        Public Function AddDataRowToEstimateDataTable(MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData, RowIndex As Integer, StartDate As Date) As System.Data.DataRow

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim LevelLineColor As Integer = 0
            Dim MediaPlanLevelLineDataColor As Integer = 0
            Dim EstimateDataTableSavingChanged As Boolean = False
            Dim BillAmount As Nullable(Of Decimal) = Nothing

            If _IsEstimateDataTableSaving = False Then

                EstimateDataTableSavingChanged = True
                _IsEstimateDataTableSaving = True

            End If

            If MediaPlanDetailLevelLineData IsNot Nothing Then

                DataRow = EstimateDataTable.NewRow()

                'DataRow.BeginEdit()

                LevelLineColor = 0
                MediaPlanLevelLineDataColor = 0

                For Each LevelLineDataRow In Me.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(LevelLineColumns.RowIndex.ToString) = MediaPlanDetailLevelLineData.RowIndex)

                    DataRow(DataColumns.LevelLineID.ToString) = LevelLineDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString)

                    If LevelLineDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) <> 0 Then

                        If LevelLineDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) <> LevelLineColor Then

                            LevelLineColor = LevelLineDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString)

                        End If

                    End If

                    For Each LevelLineDataColumn In Me.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString)

                        DataRow(LevelLineDataColumn.ColumnName) = LevelLineDataRow(LevelLineDataColumn.ColumnName)

                    Next

                Next

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString) = MediaPlanDetailLevelLineData.StartDate
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = MediaPlanDetailLevelLineData.RowIndex
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID.ToString) = MediaPlanDetailLevelLineData.ID

                FillEstimateDateData(_MediaPlanDetail, DataRow, MediaPlanDetailLevelLineData.StartDate, _BroadcastCalendarWeeks)

                BillAmount = MediaPlanDetailLevelLineData.BillAmount

                FillMediaPlanDetailLevelLineData(Me, MediaPlanDetailLevelLineData)

                MediaPlanDetailLevelLineData.BillAmount = BillAmount

                FillMediaPlanDetailDataRowData(DataRow, MediaPlanDetailLevelLineData)

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) = If(MediaPlanDetailLevelLineData.Note IsNot Nothing, MediaPlanDetailLevelLineData.Note, DBNull.Value)

                If MediaPlanDetailLevelLineData.Color = 0 Then

                    If DoesMediaPlanDetailLevelLineDataHaveData(MediaPlanDetailLevelLineData) Then

                        If LevelLineColor <> 0 Then

                            MediaPlanLevelLineDataColor = LevelLineColor

                        ElseIf _MediaPlanDetail.Color <> 0 Then

                            MediaPlanLevelLineDataColor = _MediaPlanDetail.Color

                        End If

                    End If

                Else

                    If DoesMediaPlanDetailLevelLineDataHaveData(MediaPlanDetailLevelLineData) = False Then

                        MediaPlanLevelLineDataColor = 0

                    End If

                End If

                MediaPlanDetailLevelLineData.Color = If(MediaPlanLevelLineDataColor <> 0, MediaPlanLevelLineDataColor, MediaPlanDetailLevelLineData.Color)

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = MediaPlanDetailLevelLineData.Color

                'DataRow.EndEdit()

                EstimateDataTable.Rows.Add(DataRow)

            Else

                DataRow = EstimateDataTable.NewRow()

                'DataRow.BeginEdit()

                LevelLineColor = 0
                MediaPlanLevelLineDataColor = 0

                For Each LevelLineDataRow In Me.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(LevelLineColumns.RowIndex.ToString) = RowIndex)

                    DataRow(DataColumns.LevelLineID.ToString) = LevelLineDataRow(LevelLineColumns.ID.ToString)

                    If LevelLineDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) <> 0 Then

                        If LevelLineDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) <> LevelLineColor Then

                            LevelLineColor = LevelLineDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString)

                        End If

                    End If

                    For Each LevelLineDataColumn In Me.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString AndAlso
                                                                                                                                            DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString)

                        DataRow(LevelLineDataColumn.ColumnName) = LevelLineDataRow(LevelLineDataColumn.ColumnName)

                    Next

                Next

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString) = StartDate
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = RowIndex
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID.ToString) = 0

                FillEstimateDateData(_MediaPlanDetail, DataRow, StartDate, _BroadcastCalendarWeeks)
                FillMediaPlanDetailDataRowData(DataRow, Nothing)

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) = DBNull.Value

                If _MediaPlanDetail.SalesClassType = "O" Then

                    If Me.MediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.StartDate <> Entity.EndDate AndAlso
                                                                             Entity.StartDate <= StartDate AndAlso Entity.EndDate >= StartDate) Then

                        For Each MPDLLD In Me.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.StartDate <> Entity.EndDate AndAlso
                                                                                                   Entity.StartDate <= StartDate AndAlso Entity.EndDate >= StartDate)

                            If MPDLLD.Color = 0 Then

                                If DoesMediaPlanDetailLevelLineDataHaveData(MPDLLD) Then

                                    If LevelLineColor <> 0 Then

                                        MediaPlanLevelLineDataColor = LevelLineColor

                                    ElseIf _MediaPlanDetail.Color <> 0 Then

                                        MediaPlanLevelLineDataColor = _MediaPlanDetail.Color

                                    End If

                                End If

                            Else

                                If DoesMediaPlanDetailLevelLineDataHaveData(MPDLLD) = False Then

                                    MediaPlanLevelLineDataColor = 0

                                Else

                                    MediaPlanLevelLineDataColor = MPDLLD.Color

                                End If

                            End If

                            If MediaPlanLevelLineDataColor <> 0 Then

                                Exit For

                            End If

                        Next

                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = MediaPlanLevelLineDataColor

                    Else

                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = 0

                    End If

                Else

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = 0

                End If

                'DataRow.EndEdit()

                EstimateDataTable.Rows.Add(DataRow)

            End If

            If EstimateDataTableSavingChanged Then

                _IsEstimateDataTableSaving = False

            End If

            AddDataRowToEstimateDataTable = DataRow

        End Function
        Public Sub UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData, DataColumn As AdvantageFramework.MediaPlanning.DataColumns)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim LevelLineColor As Integer = 0
            Dim MediaPlanLevelLineDataColor As Integer = 0

            _IsEstimateDataTableSaving = True

            If MediaPlanDetailLevelLineData IsNot Nothing Then

                DataRow = Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(DataColumns.RowIndex.ToString) = MediaPlanDetailLevelLineData.RowIndex AndAlso
                                                                                                                DR(DataColumns.StartDate.ToString) = MediaPlanDetailLevelLineData.StartDate)

                If DataRow Is Nothing Then

                    AddDataRowToEstimateDataTable(MediaPlanDetailLevelLineData, MediaPlanDetailLevelLineData.RowIndex, MediaPlanDetailLevelLineData.StartDate)

                    RefreshEntryDates()

                Else

                    If MediaPlanDetailLevelLineData.IsEntityBeingAdded() = False Then

                        MediaPlanDetailLevelLineData.ModifiedByUserCode = _MediaPlan.DbContext.UserCode
                        MediaPlanDetailLevelLineData.ModifiedDate = Now

                    End If

                    If DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Dollars Then

                        FillMediaPlanDetailLevelLineDataQty(Me, MediaPlanDetailLevelLineData)

                    Else

                        FillMediaPlanDetailLevelLineData(Me, MediaPlanDetailLevelLineData)

                    End If

                    FillMediaPlanDetailDataRowData(DataRow, MediaPlanDetailLevelLineData)

                    UpdateMediaPlanDetailLevelLineDataColor(MediaPlanDetailLevelLineData)

                End If

            End If

            _IsEstimateDataTableSaving = False

            RaiseEvent EstimateChangedEvent()

        End Sub
        Public Sub UpdateMediaPlanDetailLevelLineDataColor(MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If MediaPlanDetailLevelLineData IsNot Nothing AndAlso MediaPlanDetailLevelLineData.StartDate <> MediaPlanDetailLevelLineData.EndDate Then

                For Each DataRow In Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(DataColumns.RowIndex.ToString) = MediaPlanDetailLevelLineData.RowIndex AndAlso
                                                                                                                MediaPlanDetailLevelLineData.StartDate <= DR(DataColumns.StartDate.ToString) AndAlso
                                                                                                                MediaPlanDetailLevelLineData.EndDate >= DR(DataColumns.StartDate.ToString))

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = MediaPlanDetailLevelLineData.Color

                Next

            End If

        End Sub
        Public Sub UpdateMediaPlanDetailLevelLineDataColor(StartDate As Date, EndDate As Date, RowIndex As Integer, Color As Integer)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If StartDate <> EndDate Then

                _IsEstimateDataTableSaving = True

                For Each DataRow In Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(DataColumns.RowIndex.ToString) = RowIndex AndAlso
                                                                                                                StartDate <= DR(DataColumns.StartDate.ToString) AndAlso
                                                                                                                EndDate >= DR(DataColumns.StartDate.ToString))

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = Color

                Next

                _IsEstimateDataTableSaving = False

            End If

        End Sub
        Public Sub AddMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData, StartDate As Date, RowIndex As Integer)

            MediaPlanDetailLevelLineData.MediaPlanID = _MediaPlan.ID
            MediaPlanDetailLevelLineData.MediaPlanDetailID = _MediaPlanDetail.ID
            MediaPlanDetailLevelLineData.StartDate = StartDate
            MediaPlanDetailLevelLineData.EndDate = StartDate
            MediaPlanDetailLevelLineData.RowIndex = RowIndex

            If _MediaPlanDetail.MediaPlanDetailLevelLineDatas Is Nothing Then

                _MediaPlanDetail.MediaPlanDetailLevelLineDatas = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            End If

            _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Add(MediaPlanDetailLevelLineData)

        End Sub
        Public Sub AddMediaPlanDetailLevelLineTag(ByVal MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine, ByVal MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

            MediaPlanDetailLevelLineTag.MediaPlanID = _MediaPlan.ID
            MediaPlanDetailLevelLineTag.MediaPlanDetailID = _MediaPlanDetail.ID
            MediaPlanDetailLevelLineTag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID

            If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags Is Nothing Then

                MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

            End If

            MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Add(MediaPlanDetailLevelLineTag)

            If _MediaPlanDetail.MediaPlanDetailLevelLineTags Is Nothing Then

                _MediaPlanDetail.MediaPlanDetailLevelLineTags = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

            End If

            _MediaPlanDetail.MediaPlanDetailLevelLineTags.Add(MediaPlanDetailLevelLineTag)

        End Sub
        Public Sub AddMediaPlanDetailPackageDetail(MediaPlanDetailPackageDetail As AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail)

            If _MediaPlanDetail.MediaPlanDetailPackageDetails Is Nothing Then

                _MediaPlanDetail.MediaPlanDetailPackageDetails = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail)

            End If

            _MediaPlanDetail.MediaPlanDetailPackageDetails.Add(MediaPlanDetailPackageDetail)

        End Sub
        Public Function RemoveMediaPlanDetailPackageDetail(MediaPlanDetailPackageDetail As AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail) As String

            Dim SizeCodes As IEnumerable(Of String) = Nothing

            _MediaPlanDetail.MediaPlanDetailPackageDetails.Remove(MediaPlanDetailPackageDetail)

            If MediaPlanDetailPackageDetail.IsEntityBeingAdded = False Then

                _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailPackageDetail)

            End If

            SizeCodes = _MediaPlanDetail.MediaPlanDetailPackageDetails.Where(Function(Entity) Entity.RowIndex = MediaPlanDetailPackageDetail.RowIndex).Select(Function(Entity) Entity.SizeCode).ToArray

            RemoveMediaPlanDetailPackageDetail = String.Join(",", (From Entity In AdvantageFramework.Database.Procedures.AdSize.Load(_MediaPlan.DbContext)
                                                                   Where SizeCodes.Contains(Entity.Code)
                                                                   Select Entity.Description))

        End Function
        Public Sub AddMediaPlanDetailPackagePlacement(MediaPlanDetailPackagePlacementName As AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName)

            If _MediaPlanDetail.MediaPlanDetailPackagePlacementNames Is Nothing Then

                _MediaPlanDetail.MediaPlanDetailPackagePlacementNames = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName)

            End If

            _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Add(MediaPlanDetailPackagePlacementName)

        End Sub
        Public Function RemoveMediaPlanDetailPackagePlacement(MediaPlanDetailPackagePlacementName As AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName) As String

            Dim PlacementNames As IEnumerable(Of String) = Nothing

            _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Remove(MediaPlanDetailPackagePlacementName)

            If MediaPlanDetailPackagePlacementName.IsEntityBeingAdded = False Then

                _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailPackagePlacementName)

            End If

            PlacementNames = _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Where(Function(Entity) Entity.RowIndex = MediaPlanDetailPackagePlacementName.RowIndex).Select(Function(Entity) Entity.PlacementName).ToArray

            RemoveMediaPlanDetailPackagePlacement = String.Join(",", PlacementNames)

        End Function
        Public Function UpdateMediaPlanDetailPackagePlacement(MediaPlanDetailPackagePlacementName As AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName) As String

            Dim PlacementNames As IEnumerable(Of String) = Nothing

            PlacementNames = _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Where(Function(Entity) Entity.RowIndex = MediaPlanDetailPackagePlacementName.RowIndex).Select(Function(Entity) Entity.PlacementName).ToArray

            UpdateMediaPlanDetailPackagePlacement = String.Join(",", PlacementNames)

        End Function
        'Public Sub Refresh(ByVal DbContext As AdvantageFramework.Database.DbContext)

        '    _MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.Load(DbContext).Include("SalesClass") _
        '                                                                                                 .Include("MediaPlanDetailLevels") _
        '                                                                                                 .Include("MediaPlanDetailLevelLines") _
        '                                                                                                 .Include("MediaPlanDetailLevelLines.MediaPlanDetailLevel") _
        '                                                                                                 .Include("MediaPlanDetailLevels.MediaPlanDetailLevelLines") _
        '                                                                                                 .Include("MediaPlanDetailLevelLineDatas") _
        '                                                                                                 .Include("MediaPlanDetailFields") _
        '                                                                                                 .Include("MediaPlanDetailLevelLineTags") _
        '                                                                                                 .Include("MediaPlanDetailSettings").SingleOrDefault(Function(Entity) Entity.ID = _MediaPlanDetail.ID)

        '    CreateLevelsAndLinesDataTable()
        '    CreateEstimateDataTable()

        'End Sub
        Public Function GetEntity() As AdvantageFramework.Database.Entities.MediaPlanDetail

            GetEntity = _MediaPlanDetail

        End Function
        Public Sub RefreshLevelsOrderNumbers()

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing

            If Me.IsLevelAndLinesLoaded Then

                For Each DataColumn In Me.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).OrderBy(Function(DC) DC.Ordinal).ToList

                    If DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then

                        Try

                            DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = DataColumn.Ordinal - 6

                        Catch ex As Exception
                            DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = 0
                        End Try

                        Try

                            MediaPlanDetailLevel = Me.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.Description = DataColumn.ColumnName)

                        Catch ex As Exception
                            MediaPlanDetailLevel = Nothing
                        End Try

                        If MediaPlanDetailLevel IsNot Nothing Then

                            MediaPlanDetailLevel.OrderNumber = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)

                        End If

                    End If

                Next

            End If

        End Sub
        Public Sub ChangeRowIndexes(ByVal OldRowIndex As Integer, ByVal NewRowIndex As Integer)

            'objects
            Dim OldMediaPlanDetailLevelLines As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) = Nothing
            Dim NewMediaPlanDetailLevelLines As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) = Nothing
            Dim OldMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim NewMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim OldMediaPlanDetailPackageDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail) = Nothing
            Dim NewMediaPlanDetailPackageDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail) = Nothing
            Dim OldMediaPlanDetailPackagePlacementNames As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName) = Nothing
            Dim NewMediaPlanDetailPackagePlacementNames As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName) = Nothing

            OldMediaPlanDetailLevelLines = _MediaPlanDetail.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines.Where(Function(MPDLL) MPDLL.RowIndex = OldRowIndex)).ToList
            NewMediaPlanDetailLevelLines = _MediaPlanDetail.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines.Where(Function(MPDLL) MPDLL.RowIndex = NewRowIndex)).ToList

            OldMediaPlanDetailLevelLineDatas = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = OldRowIndex).ToList
            NewMediaPlanDetailLevelLineDatas = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = NewRowIndex).ToList

            OldMediaPlanDetailPackageDetails = _MediaPlanDetail.MediaPlanDetailPackageDetails.Where(Function(Entity) Entity.RowIndex = OldRowIndex).ToList
            NewMediaPlanDetailPackageDetails = _MediaPlanDetail.MediaPlanDetailPackageDetails.Where(Function(Entity) Entity.RowIndex = NewRowIndex).ToList

            OldMediaPlanDetailPackagePlacementNames = _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Where(Function(Entity) Entity.RowIndex = OldRowIndex).ToList
            NewMediaPlanDetailPackagePlacementNames = _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Where(Function(Entity) Entity.RowIndex = NewRowIndex).ToList

            For Each MPDLL In OldMediaPlanDetailLevelLines

                MPDLL.RowIndex = NewRowIndex

            Next
            For Each MPDLL In NewMediaPlanDetailLevelLines

                MPDLL.RowIndex = OldRowIndex

            Next

            For Each MPDLLD In OldMediaPlanDetailLevelLineDatas

                MPDLLD.RowIndex = NewRowIndex

            Next
            For Each MPDLLD In NewMediaPlanDetailLevelLineDatas

                MPDLLD.RowIndex = OldRowIndex

            Next

            For Each MPDPD In OldMediaPlanDetailPackageDetails

                MPDPD.RowIndex = NewRowIndex

            Next
            For Each MPDPD In NewMediaPlanDetailPackageDetails

                MPDPD.RowIndex = OldRowIndex

            Next

            For Each MPDPD In OldMediaPlanDetailPackagePlacementNames

                MPDPD.RowIndex = NewRowIndex

            Next
            For Each MPDPD In NewMediaPlanDetailPackagePlacementNames

                MPDPD.RowIndex = OldRowIndex

            Next

        End Sub
        Public Function GetLastDayOfQuarter(Day As Date) As Date

            'objects
            Dim LastDayOfQuarter As Date = Nothing

            If Me.IsCalendarMonth Then

                Select Case Day.Month

                    Case 1, 2, 3

                        LastDayOfQuarter = New Date(Day.Year, 3, Date.DaysInMonth(Day.Year, 3))

                    Case 4, 5, 6

                        LastDayOfQuarter = New Date(Day.Year, 6, Date.DaysInMonth(Day.Year, 6))

                    Case 7, 8, 9

                        LastDayOfQuarter = New Date(Day.Year, 9, Date.DaysInMonth(Day.Year, 9))

                    Case 10, 11, 12

                        LastDayOfQuarter = New Date(Day.Year, 12, Date.DaysInMonth(Day.Year, 12))

                End Select

            Else

                LastDayOfQuarter = GetLastDayOfBroadcastQuarter(Day)

            End If

            GetLastDayOfQuarter = LastDayOfQuarter

        End Function
        Private Function GetLastDayOfBroadcastQuarter(Day As Date) As Date

            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            Dim MaxWeekDate As Nullable(Of Date) = Nothing
            Dim Month As Integer = Nothing
            Dim LastDay As Date = Nothing

            MaxWeekDate = (From Dates In _BroadcastCalendarWeeks
                           Where Dates.WeekDate <= Day
                           Select Dates.WeekDate).Max

            If MaxWeekDate IsNot Nothing Then

                BroadcastCalendarWeek = (From Dates In _BroadcastCalendarWeeks
                                         Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

                If BroadcastCalendarWeek IsNot Nothing Then

                    Select Case BroadcastCalendarWeek.Month

                        Case 1, 2, 3

                            Month = 3

                        Case 4, 5, 6

                            Month = 6

                        Case 7, 8, 9

                            Month = 9

                        Case 10, 11, 12

                            Month = 12

                    End Select

                    LastDay = (From Dates In _BroadcastCalendarWeeks
                               Where Dates.Month = Month AndAlso
                                     Dates.Year = BroadcastCalendarWeek.Year
                               Select Dates.WeekDate).Max.AddDays(6)

                End If

            End If

            GetLastDayOfBroadcastQuarter = LastDay

        End Function
        Public Function GetLastDayOfWeek(Day As Date) As Date

            'objects
            Dim LastDayOfWeek As Date = Date.MinValue

            If Me.IsCalendarMonth Then

                For DayCounter As Integer = 0 To 6

                    If Day.AddDays(DayCounter).DayOfWeek = DayOfWeek.Saturday Then

                        LastDayOfWeek = Day.AddDays(DayCounter)

                        Exit For

                    End If

                Next

            Else

                LastDayOfWeek = GetLastDayOfBroadcastWeek(GetWeek(Day), Day.Year)

            End If

            GetLastDayOfWeek = LastDayOfWeek

        End Function
        Private Function GetLastDayOfBroadcastWeek(Week As Integer, Year As Integer) As Date

            'objects
            Dim LastDay As Date = Date.MinValue

            LastDay = (From Dates In _BroadcastCalendarWeeks
                       Where Dates.Week = Week AndAlso
                             Dates.Year = Year
                       Select Dates.WeekDate).FirstOrDefault.AddDays(6)

            GetLastDayOfBroadcastWeek = LastDay

        End Function
        Public Function GetWeek(ByVal [Date] As Date) As Integer

            'objects
            Dim Week As Integer = 0
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            If Me.IsCalendarMonth Then

                Week = CInt(System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear([Date], System.Globalization.CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday))

            Else

                Try

                    BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

                Catch ex As Exception
                    BroadcastCalendarWeek = Nothing
                End Try

                If BroadcastCalendarWeek IsNot Nothing Then

                    Week = BroadcastCalendarWeek.Week

                End If

            End If

            GetWeek = Week

        End Function
        Public Function GetWeekDates(ByVal [Date] As Date) As Generic.List(Of Date)

            'objects
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            Dim Dates As Generic.List(Of Date) = Nothing
            Dim StartDate As Date = Nothing
            Dim DayCounter As Integer = 0

            Dates = New Generic.List(Of Date)

            If Me.IsCalendarMonth Then

                StartDate = AdvantageFramework.MediaPlanning.GetWeekDateForEstimate([Date], Me.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks, Me.SplitWeeks)

                If StartDate <> Nothing Then

                    If Me.SplitWeeks Then

                        For DayCounter = 0 To 6 Step 1

                            Dates.Add(StartDate.AddDays(DayCounter))

                            If StartDate.AddDays(DayCounter).Month <> StartDate.Month OrElse StartDate.AddDays(DayCounter).DayOfWeek = DayOfWeek.Sunday Then

                                Exit For

                            End If

                        Next

                    Else

                        For DayCounter = 0 To 6 Step 1

                            Dates.Add(StartDate.AddDays(DayCounter))

                        Next

                    End If

                End If

            Else

                Try

                    BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

                Catch ex As Exception
                    BroadcastCalendarWeek = Nothing
                End Try

                If BroadcastCalendarWeek IsNot Nothing Then

                    For DayCounter = 0 To 6 Step 1

                        Dates.Add(BroadcastCalendarWeek.WeekDate.AddDays(DayCounter))

                    Next

                End If

            End If

            GetWeekDates = Dates

        End Function
        Public Function GetMonth(ByVal [Date] As Date) As Integer

            'objects
            Dim Month As Integer = 0
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            If Me.IsCalendarMonth Then

                Month = [Date].Month

            Else

                Try

                    BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

                Catch ex As Exception
                    BroadcastCalendarWeek = Nothing
                End Try

                If BroadcastCalendarWeek IsNot Nothing Then

                    Month = BroadcastCalendarWeek.Month

                End If

            End If

            GetMonth = Month

        End Function
        Public Function GetLastDayOfMonth(Day As Date) As Date

            'objects
            Dim LastDayOfMonth As Date = Nothing

            If Me.IsCalendarMonth Then

                LastDayOfMonth = New Date(Day.Year, Day.Month, Date.DaysInMonth(Day.Year, Day.Month))

            Else

                LastDayOfMonth = GetLastDayOfBroadcastMonth(Day)

            End If

            GetLastDayOfMonth = LastDayOfMonth

        End Function
        Private Function GetLastDayOfBroadcastMonth(Day As Date) As Date

            Dim MaxWeekDate As Nullable(Of Date) = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            Dim LastDay As Nullable(Of Date) = Nothing

            MaxWeekDate = (From Dates In _BroadcastCalendarWeeks
                           Where Dates.WeekDate <= Day
                           Select Dates.WeekDate).Max

            If MaxWeekDate IsNot Nothing Then

                BroadcastCalendarWeek = (From Dates In _BroadcastCalendarWeeks
                                         Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

                If BroadcastCalendarWeek IsNot Nothing Then

                    LastDay = (From Dates In _BroadcastCalendarWeeks
                               Where Dates.Month = BroadcastCalendarWeek.Month AndAlso
                                     Dates.Year = BroadcastCalendarWeek.Year
                               Select Dates.WeekDate).Max.AddDays(6)

                End If

            End If

            GetLastDayOfBroadcastMonth = LastDay

        End Function
        Public Function GetMonthDates(ByVal [Date] As Date) As Generic.List(Of Date)

            'objects
            Dim Month As Integer = 0
            Dim Year As Integer = 0
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            Dim Dates As Generic.List(Of Date) = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim DayCounter As Integer = 0

            Dates = New Generic.List(Of Date)

            If Me.IsCalendarMonth Then

                Month = [Date].Month

                For Day As Integer = 1 To DateTime.DaysInMonth([Date].Year, Month) Step 1

                    Dates.Add(New Date([Date].Year, Month, Day))

                Next

            Else

                Try

                    BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

                Catch ex As Exception
                    BroadcastCalendarWeek = Nothing
                End Try

                If BroadcastCalendarWeek IsNot Nothing Then

                    Month = BroadcastCalendarWeek.Month
                    Year = BroadcastCalendarWeek.Year

                End If

                For Each BroadcastCalendarWeek In _BroadcastCalendarWeeks.Where(Function(Entity) Entity.Month = Month AndAlso Entity.Year = Year).ToList

                    DayCounter = 0

                    For DayCounter = 0 To 6 Step 1

                        Dates.Add(BroadcastCalendarWeek.WeekDate.AddDays(DayCounter))

                    Next

                Next

            End If

            GetMonthDates = Dates

        End Function
        Public Function GetMonthDates() As Generic.List(Of Date)

            'objects
            Dim Dates As Generic.List(Of Date) = Nothing
            Dim StartDate As Date = Nothing
            Dim [Date] As Date = Nothing

            Dates = New Generic.List(Of Date)

            StartDate = _MediaPlan.StartDate
            Dates.Add(StartDate)

            For DateDayCounter = 0 To Math.Abs(DateDiff(DateInterval.Day, _MediaPlan.StartDate, _MediaPlan.EndDate))

                [Date] = _MediaPlan.StartDate.AddDays(DateDayCounter)

                If Me.GetMonth([Date]) <> Me.GetMonth(StartDate) Then

                    Dates.Add([Date])
                    StartDate = [Date]

                End If

            Next

            GetMonthDates = Dates

        End Function
        Public Function GetWeekDates() As Generic.List(Of Date)

            'objects
            Dim Dates As Generic.List(Of Date) = Nothing
            Dim StartDate As Date = Nothing
            Dim [Date] As Date = Nothing

            Dates = New Generic.List(Of Date)

            StartDate = _MediaPlan.StartDate
            Dates.Add(StartDate)

            For DateDayCounter = 0 To Math.Abs(DateDiff(DateInterval.Day, _MediaPlan.StartDate, _MediaPlan.EndDate))

                [Date] = _MediaPlan.StartDate.AddDays(DateDayCounter)

                If Me.GetWeek([Date]) <> Me.GetWeek(StartDate) Then

                    Dates.Add([Date])
                    StartDate = [Date]

                End If

            Next

            GetWeekDates = Dates

        End Function
        Public Function GetDayDates() As Generic.List(Of Date)

            'objects
            Dim Dates As Generic.List(Of Date) = Nothing

            Dates = New Generic.List(Of Date)

            For DateDayCounter = 0 To Math.Abs(DateDiff(DateInterval.Day, _MediaPlan.StartDate, _MediaPlan.EndDate))

                Dates.Add(_MediaPlan.StartDate.AddDays(DateDayCounter))

            Next

            GetDayDates = Dates

        End Function
        Public Function GetOOH4WeeksDates() As Generic.List(Of Date)

            'objects
            Dim Dates As Generic.List(Of Date) = Nothing
            Dim StartDate As Date = Nothing
            'Dim [Date] As Date = Nothing

            Dates = New Generic.List(Of Date)

            StartDate = _MediaPlan.StartDate
            Dates.Add(StartDate)
            StartDate = StartDate.AddDays(28)

            While StartDate <= _MediaPlan.EndDate

                Dates.Add(StartDate)
                StartDate = StartDate.AddDays(28)

            End While

            'For DateDayCounter = 0 To Math.Abs(DateDiff(DateInterval.Day, _MediaPlan.StartDate, _MediaPlan.EndDate))

            '    [Date] = _MediaPlan.StartDate.AddDays(DateDayCounter)

            '    If [Date] > StartDate Then

            '        Dates.Add([Date])
            '        StartDate = [Date].AddDays(28)

            '    End If

            'Next

            GetOOH4WeeksDates = Dates

        End Function
        Public Function GetDatesByPeriodType() As Generic.List(Of Date)

            'objects
            Dim Dates As Generic.List(Of Date) = Nothing
            Dim FromDate As Date = Nothing
            Dim FromDateMonth As Integer = 0
            Dim FromDateYear As Integer = 0
            Dim FromDateDay As Integer = 0

            If Me.PeriodType = PeriodTypes.Day Then

                Dates = Me.GetDayDates

            ElseIf Me.PeriodType = PeriodTypes.Week Then

                Dates = Me.GetWeekDates

            ElseIf Me.PeriodType = PeriodTypes.Month Then

                FromDate = Me.MediaPlan.StartDate
                FromDateDay = FromDate.Day

                If (Me.SalesClassType <> "R" AndAlso Me.SalesClassType <> "T") AndAlso
                        Me.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month AndAlso
                        FromDate.Day <> 1 Then

                    Dates = New Generic.List(Of Date)

                    Do Until FromDate >= Me.MediaPlan.EndDate

                        If Me.IsOnHiatusDate(FromDate) = False Then

                            Dates.Add(FromDate)

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

                    Dates = Me.GetMonthDates

                End If

            ElseIf Me.PeriodType = PeriodTypes.OOH4Week Then

                Dates = Me.GetOOH4WeeksDates

            End If

            GetDatesByPeriodType = Dates

        End Function
        Public Function GetQuarter(ByVal [Date] As Date) As Integer

            'objects
            Dim Quarter As Integer = 0
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            If Me.IsCalendarMonth Then

                Quarter = CInt(Math.Ceiling([Date].Month / 3))

            Else

                Try

                    BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

                Catch ex As Exception
                    BroadcastCalendarWeek = Nothing
                End Try

                If BroadcastCalendarWeek IsNot Nothing Then

                    Quarter = CInt(Math.Ceiling(BroadcastCalendarWeek.Month / 3))

                End If

            End If

            GetQuarter = Quarter

        End Function
        Public Function GetYear(ByVal [Date] As Date) As Integer

            'objects
            Dim Year As Integer = 0
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            If Me.IsCalendarMonth Then

                Year = [Date].Year

            Else

                Try

                    BroadcastCalendarWeek = _BroadcastCalendarWeeks.Where(Function(Entity) Entity.WeekDate <= [Date]).OrderByDescending(Function(Entity) Entity.WeekDate).FirstOrDefault

                Catch ex As Exception
                    BroadcastCalendarWeek = Nothing
                End Try

                If BroadcastCalendarWeek IsNot Nothing Then

                    Year = BroadcastCalendarWeek.Year

                End If

            End If

            GetYear = Year

        End Function
        Public Sub LevelAndLinesDataTableColumnDefinitionChanged()

            RaiseEvent EstimateChangedEvent()

        End Sub
        Public Sub SetApproval(ByVal IsApproved As Boolean, ByVal EmployeeCode As String)

            If IsApproved Then

                _MediaPlanDetail.IsApproved = True
                _MediaPlanDetail.ApprovedBy = EmployeeCode
                _MediaPlanDetail.ApprovedDate = Now.ToShortDateString

            Else

                _MediaPlanDetail.IsApproved = False
                _MediaPlanDetail.ApprovedBy = Nothing
                _MediaPlanDetail.ApprovedDate = Nothing

            End If

            RaiseEvent EstimateChangedEvent()

        End Sub
        Public Sub OrderNumberChanged()

            RaiseEvent EstimateChangedEvent()

        End Sub
        Public Sub FieldsChanged()

            RaiseEvent EstimateChangedEvent()

        End Sub
        Public Function IsOnHiatusDate(FromDate As Date) As Boolean

            'objects
            Dim OnHiatusDate As Boolean = False

            OnHiatusDate = IsOMonthHiatusDate(FromDate)

            If OnHiatusDate = False Then

                OnHiatusDate = IsOnWeekHiatusDate(FromDate)

            End If

            IsOnHiatusDate = OnHiatusDate

        End Function
        Public Function IsOnWeekHiatusDate(FromDate As Date) As Boolean

            'objects
            Dim OnHiatusDate As Boolean = False
            Dim HiatusDate As Date = Nothing

            HiatusDate = AdvantageFramework.MediaPlanning.GetWeekDateForEstimate(FromDate, Me.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks, Me.SplitWeeks)

            OnHiatusDate = _MediaPlan.MediaPlanEstimate.HiatusWeeks.Contains(HiatusDate)

            IsOnWeekHiatusDate = OnHiatusDate

        End Function
        Public Function IsOMonthHiatusDate(FromDate As Date) As Boolean

            'objects
            Dim OnHiatusDate As Boolean = False
            Dim HiatusDate As Date = Nothing
            Dim Year As Integer = 0
            Dim Month As Integer = 0

            Month = AdvantageFramework.MediaPlanning.GetMonthForEstimate(FromDate, Me.IsCalendarMonth, _BroadcastCalendarWeeks, Year)

            HiatusDate = New Date(Year, Month, 1)

            OnHiatusDate = _MediaPlan.MediaPlanEstimate.HiatusMonths.Contains(HiatusDate)

            IsOMonthHiatusDate = OnHiatusDate

        End Function
        Public Function CheckForUnitsCPM(RowIndex As Integer) As Boolean

            'objects
            Dim IsCPM As Boolean = False

            IsCPM = Me.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Any(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.IsCPM = True AndAlso Entity.QuantityColumn = DataAreaQuantityColumns.Units)

            CheckForUnitsCPM = IsCPM

        End Function
        Public Function CheckForImpressionsCPM(RowIndex As Integer) As Boolean

            'objects
            Dim IsCPM As Boolean = False

            IsCPM = Me.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Any(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.IsCPM = True AndAlso Entity.QuantityColumn = DataAreaQuantityColumns.Impressions)

            CheckForImpressionsCPM = IsCPM

        End Function
        Public Function CheckForClicksCPM(RowIndex As Integer) As Boolean

            'objects
            Dim IsCPM As Boolean = False

            IsCPM = Me.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Any(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.IsCPM = True AndAlso Entity.QuantityColumn = DataAreaQuantityColumns.Clicks)

            CheckForClicksCPM = IsCPM

        End Function
        Public Function CheckForColumnsQuantity(RowIndex As Integer) As Boolean

            'objects
            Dim IsQuantity As Boolean = False

            IsQuantity = Me.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Any(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.QuantityColumn = DataAreaQuantityColumns.Columns)

            CheckForColumnsQuantity = IsQuantity

        End Function
        Public Function CheckForInchesLinesQuantity(RowIndex As Integer) As Boolean

            'objects
            Dim IsQuantity As Boolean = False

            IsQuantity = Me.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Any(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.QuantityColumn = DataAreaQuantityColumns.InchesLines)

            CheckForInchesLinesQuantity = IsQuantity

        End Function
        Public Function CheckForUnitsQuantity(RowIndex As Integer) As Boolean

            'objects
            Dim IsQuantity As Boolean = False

            IsQuantity = Me.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Any(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.QuantityColumn = DataAreaQuantityColumns.Units)

            CheckForUnitsQuantity = IsQuantity

        End Function
        Public Function CheckForImpressionsQuantity(RowIndex As Integer) As Boolean

            'objects
            Dim IsQuantity As Boolean = False

            IsQuantity = Me.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Any(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.QuantityColumn = DataAreaQuantityColumns.Impressions)

            CheckForImpressionsQuantity = IsQuantity

        End Function
        Public Function CheckForClicksQuantity(RowIndex As Integer) As Boolean

            'objects
            Dim IsQuantity As Boolean = False

            IsQuantity = Me.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Any(Function(Entity) Entity.RowIndex = RowIndex AndAlso Entity.QuantityColumn = DataAreaQuantityColumns.Clicks)

            CheckForClicksQuantity = IsQuantity

        End Function
        Private Sub MediaPlanEstimate_EstimateChangedEvent() Handles Me.EstimateChangedEvent

            _HasChanged = True

        End Sub
        Public Sub RefreshEntryDates()

            Try

                _EntryDates = EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(DR) CDate(DR(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))).Distinct.ToArray

            Catch ex As Exception
                _EntryDates = Nothing
            End Try

        End Sub
        Public Function GetDateRangeForRow(RowIndex As Integer) As String

            'objects
            Dim DateRange As String = String.Empty
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim MinDate As Date = Date.MinValue
            Dim MaxDate As Date = Date.MinValue

            MediaPlanDetailLevelLineDatas = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex).ToList

            If MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso MediaPlanDetailLevelLineDatas.Count > 0 Then

                MinDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.StartDate).Min
                MaxDate = MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.EndDate).Max

            End If

            If MinDate <> Date.MinValue AndAlso MaxDate <> Date.MinValue Then

                DateRange = MinDate.ToShortDateString & " - " & MaxDate.ToShortDateString

            End If

            GetDateRangeForRow = DateRange

        End Function
        Public Function GetUnboundFieldsInOrder() As Generic.List(Of String)

            'objects
            Dim UnboundFields As Generic.Dictionary(Of String, Integer) = Nothing
            Dim UnboundFieldsInOrder As Generic.List(Of String) = Nothing

            UnboundFieldsInOrder = New Generic.List(Of String)
            UnboundFields = New Generic.Dictionary(Of String, Integer)

            UnboundFields(AdvantageFramework.MediaPlanning.Settings.ShowPackageName.ToString) = Me.PackageLevelIndex
            UnboundFields(AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString) = Me.DateRangeIndex
            UnboundFields(AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString) = Me.AdSizesIndex

            For Each Entry In UnboundFields.OrderBy(Function(KVP) KVP.Value).ToList

                UnboundFieldsInOrder.Add(Entry.Key)

            Next

            UnboundFieldsInOrder.Add(AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString)

            GetUnboundFieldsInOrder = UnboundFieldsInOrder

        End Function
        Private Sub SavePackagePlacementsWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.PackagePlacementWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting Is Nothing Then

                MediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                MediaPlanDetailSetting.MediaPlanID = _MediaPlan.ID
                MediaPlanDetailSetting.MediaPlanDetailID = _MediaPlanDetail.ID
                MediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.PackagePlacementWidth.ToString

                _MediaPlanDetail.MediaPlanDetailSettings.Add(MediaPlanDetailSetting)

            End If

            MediaPlanDetailSetting.NumericValue = _PackagePlacementWidth

        End Sub
        Private Sub LoadPackagePlacementWidthSetting()

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing

            Try

                MediaPlanDetailSetting = _MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.PackagePlacementWidth.ToString)

            Catch ex As Exception
                MediaPlanDetailSetting = Nothing
            End Try

            If MediaPlanDetailSetting IsNot Nothing Then

                _PackagePlacementWidth = MediaPlanDetailSetting.NumericValue.GetValueOrDefault(-1)

            Else

                _PackagePlacementWidth = 100

            End If

        End Sub

#Region "  DataTable Events "

        Private Sub LevelsAndLinesDataTable_CollectionChanged(sender As Object, e As System.ComponentModel.CollectionChangeEventArgs)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing

            If _IsLevelsAndLinesDataTableSaving = False Then

                If e.Action = ComponentModel.CollectionChangeAction.Add OrElse
                        e.Action = ComponentModel.CollectionChangeAction.Remove Then

                    RaiseEvent EstimateChangedEvent()

                    Try

                        DataColumn = e.Element

                    Catch ex As Exception
                        DataColumn = Nothing
                    End Try

                    If DataColumn IsNot Nothing Then

                        If e.Action = ComponentModel.CollectionChangeAction.Add Then

                            Try

                                MediaPlanDetailLevel = New AdvantageFramework.Database.Entities.MediaPlanDetailLevel

                                MediaPlanDetailLevel.MediaPlanID = _MediaPlan.ID
                                MediaPlanDetailLevel.MediaPlanDetailID = _MediaPlanDetail.ID
                                MediaPlanDetailLevel.Description = DataColumn.ColumnName
                                MediaPlanDetailLevel.TagType = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString)
                                MediaPlanDetailLevel.OrderNumber = DataColumn.Ordinal - 6
                                MediaPlanDetailLevel.Width = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString)
                                MediaPlanDetailLevel.MappingType = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString)
                                MediaPlanDetailLevel.IsVisible = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString)

                                _MediaPlanDetail.MediaPlanDetailLevels.Add(MediaPlanDetailLevel)
                                Me.MediaPlan.DbContext.MediaPlanDetailLevels.Add(MediaPlanDetailLevel)

                                For RowIndex As Integer = 0 To Me.LevelsAndLinesDataTable.Rows.Count - 1

                                    MediaPlanDetailLevelLine = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine

                                    MediaPlanDetailLevelLine.MediaPlanID = _MediaPlan.ID
                                    MediaPlanDetailLevelLine.MediaPlanDetailID = _MediaPlanDetail.ID
                                    MediaPlanDetailLevelLine.MediaPlanDetailLevelID = MediaPlanDetailLevel.ID

                                    MediaPlanDetailLevelLine.RowIndex = RowIndex
                                    MediaPlanDetailLevelLine.Description = ""
                                    MediaPlanDetailLevelLine.Expanded = True
                                    MediaPlanDetailLevelLine.PackageName = String.Empty

                                    If MediaPlanDetailLevel.MediaPlanDetailLevelLines Is Nothing Then

                                        MediaPlanDetailLevel.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                                    End If

                                    MediaPlanDetailLevel.MediaPlanDetailLevelLines.Add(MediaPlanDetailLevelLine)

                                    If _MediaPlanDetail.MediaPlanDetailLevelLines Is Nothing Then

                                        _MediaPlanDetail.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                                    End If

                                    _MediaPlanDetail.MediaPlanDetailLevelLines.Add(MediaPlanDetailLevelLine)

                                Next

                            Catch ex As Exception

                            End Try

                        ElseIf e.Action = ComponentModel.CollectionChangeAction.Remove Then

                            Try

                                MediaPlanDetailLevel = _MediaPlanDetail.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.Description = DataColumn.ColumnName)

                            Catch ex As Exception
                                MediaPlanDetailLevel = Nothing
                            End Try

                            If MediaPlanDetailLevel IsNot Nothing Then

                                If MediaPlanDetailLevel.MediaPlanDetailLevelLines IsNot Nothing Then

                                    For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.ToList

                                        If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing Then

                                            For Each MediaPlanDetailLevelLineTag In MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.ToList

                                                MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)
                                                _MediaPlanDetail.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)

                                                Try

                                                    _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                                                Catch ex As Exception
                                                    MediaPlanDetailLevelLineTag = Nothing
                                                End Try

                                            Next

                                        End If

                                        MediaPlanDetailLevel.MediaPlanDetailLevelLines.Remove(MediaPlanDetailLevelLine)
                                        _MediaPlanDetail.MediaPlanDetailLevelLines.Remove(MediaPlanDetailLevelLine)

                                        Try

                                            _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLine)

                                        Catch ex As Exception
                                            MediaPlanDetailLevelLine = Nothing
                                        End Try

                                    Next

                                End If

                                _MediaPlanDetail.MediaPlanDetailLevels.Remove(MediaPlanDetailLevel)

                                Try

                                    _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevel)

                                Catch ex As Exception
                                    MediaPlanDetailLevel = Nothing
                                End Try

                            End If

                            If LevelsAndLinesDataTable.Columns.Count = 5 Then

                                LevelsAndLinesDataTable.Rows.Clear()
                                EstimateDataTable.Rows.Clear()

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub LevelsAndLinesDataTable_ColumnChanged(sender As Object, e As DataColumnChangeEventArgs) Handles LevelsAndLinesDataTable.ColumnChanged

            'objects
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            If _IsLevelsAndLinesDataTableSaving = False Then

                If e.Row IsNot Nothing AndAlso e.Row.RowState <> DataRowState.Detached Then

                    _IsLevelsAndLinesDataTableSaving = True

                    If e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then


                        e.Row(e.Column.ColumnName) = GetLevelLineDescription(e.Row, e.Column)

                    End If

                    If e.Column.ColumnName = AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString Then

                        For Each MediaPlanDetailLevelLine In _MediaPlanDetail.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines.Where(Function(MPDLL) MPDLL.RowIndex = e.Row(LevelLineColumns.RowIndex.ToString)))

                            Try

                                MediaPlanDetailLevelLine.Color = e.Row(e.Column.ColumnName)

                            Catch ex As Exception
                                MediaPlanDetailLevelLine.Color = 0
                            End Try

                        Next

                    ElseIf e.Column.ColumnName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString Then

                        For Each MediaPlanDetailLevelLine In _MediaPlanDetail.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines.Where(Function(MPDLL) MPDLL.RowIndex = e.Row(LevelLineColumns.RowIndex.ToString)))

                            Try

                                If TypeOf e.Row(e.Column.ColumnName) Is System.DBNull Then

                                    MediaPlanDetailLevelLine.PackageName = String.Empty

                                Else

                                    MediaPlanDetailLevelLine.PackageName = e.Row(e.Column.ColumnName)

                                End If

                            Catch ex As Exception
                                MediaPlanDetailLevelLine.PackageName = String.Empty
                            End Try

                        Next

                    ElseIf e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then

                        Try

                            MediaPlanDetailLevel = _MediaPlanDetail.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.Description = e.Column.ColumnName)

                        Catch ex As Exception
                            MediaPlanDetailLevel = Nothing
                        End Try

                        If MediaPlanDetailLevel IsNot Nothing Then

                            Try

                                MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = e.Row(LevelLineColumns.RowIndex.ToString))

                            Catch ex As Exception
                                MediaPlanDetailLevelLine = Nothing
                            End Try

                            If MediaPlanDetailLevelLine Is Nothing Then

                                MediaPlanDetailLevelLine = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine

                                MediaPlanDetailLevelLine.MediaPlanID = _MediaPlan.ID
                                MediaPlanDetailLevelLine.MediaPlanDetailID = _MediaPlanDetail.ID
                                MediaPlanDetailLevelLine.MediaPlanDetailLevelID = MediaPlanDetailLevel.ID
                                MediaPlanDetailLevelLine.Expanded = True
                                MediaPlanDetailLevelLine.RowIndex = e.Row(LevelLineColumns.RowIndex.ToString)
                                MediaPlanDetailLevelLine.PackageName = String.Empty

                                MediaPlanDetailLevel.MediaPlanDetailLevelLines.Add(MediaPlanDetailLevelLine)

                                If _MediaPlanDetail.MediaPlanDetailLevelLines Is Nothing Then

                                    _MediaPlanDetail.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                                End If

                                _MediaPlanDetail.MediaPlanDetailLevelLines.Add(MediaPlanDetailLevelLine)

                            End If

                            MediaPlanDetailLevelLine.Description = e.Row(e.Column.ColumnName)

                        End If

                    End If

                    _IsLevelsAndLinesDataTableSaving = False

                    If e.Column.ColumnName = AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString Then

                        _IsEstimateDataTableSaving = True

                        Me.EstimateDataTable.BeginLoadData()

                        For Each DataRow In Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow)().Where(Function(DR) DR(DataColumns.RowIndex.ToString) = e.Row(LevelLineColumns.RowIndex.ToString)).ToList

                            Try

                                MediaPlanDetailLevelLineData = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(Entity) Entity.RowIndex = DataRow(DataColumns.RowIndex.ToString) AndAlso
                                                                                                                                               Entity.StartDate = DataRow(DataColumns.StartDate.ToString))

                            Catch ex As Exception
                                MediaPlanDetailLevelLineData = Nothing
                            End Try

                            If MediaPlanDetailLevelLineData IsNot Nothing Then

                                If DoesMediaPlanDetailLevelLineDataHaveData(MediaPlanDetailLevelLineData) Then

                                    If e.Row(e.Column.ColumnName) <> 0 Then

                                        MediaPlanDetailLevelLineData.Color = e.Row(e.Column.ColumnName)

                                    Else

                                        MediaPlanDetailLevelLineData.Color = _MediaPlanDetail.Color

                                    End If

                                Else

                                    MediaPlanDetailLevelLineData.Color = 0

                                End If

                                DataRow(DataColumns.Color.ToString) = MediaPlanDetailLevelLineData.Color

                                UpdateMediaPlanDetailLevelLineDataColor(MediaPlanDetailLevelLineData)

                            End If

                        Next

                        Me.EstimateDataTable.EndLoadData()

                        _IsEstimateDataTableSaving = False

                    ElseIf e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString AndAlso
                            e.Column.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then

                        _IsEstimateDataTableSaving = True

                        For Each DataRow In Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow)().Where(Function(DR) DR(DataColumns.LevelLineID.ToString) = e.Row(LevelLineColumns.ID.ToString)).ToList

                            DataRow(e.Column.ColumnName) = e.Row(e.Column.ColumnName)

                        Next

                        _IsEstimateDataTableSaving = False

                    End If

                    RaiseEvent EstimateChangedEvent()

                End If

            End If

        End Sub
        Private Sub LevelsAndLinesDataTable_RowChanged(sender As Object, e As DataRowChangeEventArgs) Handles LevelsAndLinesDataTable.RowChanged

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DateDayCounter As Integer = 0
            Dim MediaPlanDetailDate As Date = Nothing
            Dim RevisedDate As Date = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim WeekStartAndEndDates As Generic.List(Of WeekStartAndEndDates) = Nothing

            If _IsLevelsAndLinesDataTableSaving = False Then

                If e.Action = DataRowAction.Add Then

                    _IsLevelsAndLinesDataTableSaving = True

                    e.Row(LevelLineColumns.RowIndex.ToString) = LevelsAndLinesDataTable.Rows.IndexOf(e.Row)

                    _IsLevelsAndLinesDataTableSaving = False

                    For Each DataColumn In Me.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString).ToList

                        Try

                            MediaPlanDetailLevel = _MediaPlanDetail.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.Description = DataColumn.ColumnName)

                        Catch ex As Exception
                            MediaPlanDetailLevel = Nothing
                        End Try

                        If MediaPlanDetailLevel IsNot Nothing Then

                            MediaPlanDetailLevelLine = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine

                            MediaPlanDetailLevelLine.MediaPlanID = _MediaPlan.ID
                            MediaPlanDetailLevelLine.MediaPlanDetailID = _MediaPlanDetail.ID
                            MediaPlanDetailLevelLine.MediaPlanDetailLevelID = MediaPlanDetailLevel.ID

                            MediaPlanDetailLevelLine.RowIndex = e.Row(LevelLineColumns.RowIndex.ToString)
                            MediaPlanDetailLevelLine.Description = If(e.Row(DataColumn) Is System.DBNull.Value, "", e.Row(DataColumn))
                            MediaPlanDetailLevelLine.Expanded = True
                            MediaPlanDetailLevelLine.PackageName = String.Empty

                            If MediaPlanDetailLevel.MediaPlanDetailLevelLines Is Nothing Then

                                MediaPlanDetailLevel.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                            End If

                            MediaPlanDetailLevel.MediaPlanDetailLevelLines.Add(MediaPlanDetailLevelLine)

                            If _MediaPlanDetail.MediaPlanDetailLevelLines Is Nothing Then

                                _MediaPlanDetail.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                            End If

                            _MediaPlanDetail.MediaPlanDetailLevelLines.Add(MediaPlanDetailLevelLine)

                        End If

                    Next

                    _IsEstimateDataTableSaving = True

                    WeekStartAndEndDates = CreateEstimateDataTableWeekStartAndEndDates()

                    Me.EstimateDataTable.BeginLoadData()

                    For Each WeekStartAndEndDate In WeekStartAndEndDates

                        AddDataRowToEstimateDataTable(Nothing, e.Row(LevelLineColumns.RowIndex.ToString), WeekStartAndEndDate.StartDate)

                    Next

                    Me.EstimateDataTable.EndLoadData()

                    RefreshEntryDates()

                    _IsEstimateDataTableSaving = False

                    RaiseEvent EstimateChangedEvent()

                End If

            End If

        End Sub
        Private Sub LevelsAndLinesDataTable_RowDeleting(sender As Object, e As DataRowChangeEventArgs) Handles LevelsAndLinesDataTable.RowDeleting

            If _IsLevelsAndLinesDataTableSaving = False Then

                For Each MediaPlanDetailLevel In _MediaPlanDetail.MediaPlanDetailLevels.ToList

                    For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.Where(Function(Entity) Entity.RowIndex = e.Row(LevelLineColumns.RowIndex.ToString)).ToList

                        If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing Then

                            For Each MediaPlanDetailLevelLineTag In MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.ToList

                                MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)
                                _MediaPlanDetail.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)

                                Try

                                    _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                                Catch ex As Exception
                                    MediaPlanDetailLevelLineTag = Nothing
                                End Try

                            Next

                        End If

                        MediaPlanDetailLevel.MediaPlanDetailLevelLines.Remove(MediaPlanDetailLevelLine)
                        _MediaPlanDetail.MediaPlanDetailLevelLines.Remove(MediaPlanDetailLevelLine)

                        Try

                            _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLine)

                        Catch ex As Exception
                            MediaPlanDetailLevelLine = Nothing
                        End Try

                    Next

                Next

                For Each MediaPlanDetailPackageDetail In _MediaPlanDetail.MediaPlanDetailPackageDetails.Where(Function(Entity) Entity.RowIndex = e.Row(LevelLineColumns.RowIndex.ToString)).ToList

                    _MediaPlanDetail.MediaPlanDetailPackageDetails.Remove(MediaPlanDetailPackageDetail)

                    If MediaPlanDetailPackageDetail.IsEntityBeingAdded = False Then

                        _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailPackageDetail)

                    End If

                Next

                For Each MediaPlanDetailPackagePlacementName In _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Where(Function(Entity) Entity.RowIndex = e.Row(LevelLineColumns.RowIndex.ToString)).ToList

                    _MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Remove(MediaPlanDetailPackagePlacementName)

                    If MediaPlanDetailPackagePlacementName.IsEntityBeingAdded = False Then

                        _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailPackagePlacementName)

                    End If

                Next

                For Each DataRow In Me.EstimateDataTable.Rows.OfType(Of System.Data.DataRow)().Where(Function(DR) DR(DataColumns.LevelLineID.ToString) = e.Row(LevelLineColumns.ID.ToString)).ToList

                    EstimateDataTable.Rows.Remove(DataRow)

                Next

                RaiseEvent EstimateChangedEvent()

            End If

        End Sub
        Private Sub LevelsAndLinesDataTable_RowDeleted(sender As Object, e As DataRowChangeEventArgs) Handles LevelsAndLinesDataTable.RowDeleted

            If e.Action = DataRowAction.Delete Then

                RefreshPackageNames()

            End If

        End Sub
        Private Sub EstimateDataTable_CollectionChanged(sender As Object, e As System.ComponentModel.CollectionChangeEventArgs)

            If _IsEstimateDataTableSaving = False Then

                If e.Action = ComponentModel.CollectionChangeAction.Add OrElse
                        e.Action = ComponentModel.CollectionChangeAction.Remove Then

                    RaiseEvent EstimateChangedEvent()

                End If

            End If

        End Sub
        Private Sub EstimateDataTable_ColumnChanged(sender As Object, e As DataColumnChangeEventArgs)

            'objects
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            If _IsEstimateDataTableSaving = False Then

                _IsEstimateDataTableSaving = True

                Try

                    MediaPlanDetailLevelLineData = _MediaPlanDetail.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(Entity) Entity.RowIndex = e.Row(DataColumns.RowIndex.ToString) AndAlso Entity.StartDate = e.Row(DataColumns.StartDate.ToString))

                Catch ex As Exception
                    MediaPlanDetailLevelLineData = Nothing
                End Try

                If MediaPlanDetailLevelLineData Is Nothing AndAlso e.Column.ColumnName <> AdvantageFramework.MediaPlanning.DataColumns.Color.ToString Then

                    MediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

                    AddMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, e.Row(DataColumns.StartDate.ToString), e.Row(DataColumns.RowIndex.ToString))

                    If Me.PeriodType <> AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                        If Me.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                            MediaPlanDetailLevelLineData.EndDate = _MediaPlan.MediaPlanEstimate.GetLastDayOfWeek(e.Row(DataColumns.StartDate.ToString))

                        ElseIf Me.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                            MediaPlanDetailLevelLineData.EndDate = _MediaPlan.MediaPlanEstimate.GetLastDayOfMonth(e.Row(DataColumns.StartDate.ToString))

                        ElseIf Me.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                            MediaPlanDetailLevelLineData.EndDate = DateAdd(DateInterval.Day, 27, e.Row(DataColumns.StartDate.ToString))

                        End If

                    End If

                End If

                If Me.PreventAutoCalcOfMediaPlanDetailLevelLineData Then

                    If MediaPlanDetailLevelLineData IsNot Nothing AndAlso e.Column.ColumnName <> AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

                        MediaPlanDetailLevelLineData.SetPropertyValue(e.Column.ColumnName, If(e.ProposedValue Is System.DBNull.Value, Nothing, e.ProposedValue))

                        UpdateMediaPlanDetailLevelLineDataColor(MediaPlanDetailLevelLineData)

                    ElseIf MediaPlanDetailLevelLineData IsNot Nothing AndAlso e.Column.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

                        MediaPlanDetailLevelLineData.SetPropertyValue(e.Column.ColumnName, If(e.ProposedValue Is System.DBNull.Value, Nothing, e.ProposedValue))

                    End If

                Else

                    If MediaPlanDetailLevelLineData IsNot Nothing AndAlso e.Column.ColumnName <> AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

                        MediaPlanDetailLevelLineData.SetPropertyValue(e.Column.ColumnName, If(e.ProposedValue Is System.DBNull.Value, Nothing, e.ProposedValue))

                        If e.Column.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString Then

                            FillMediaPlanDetailLevelLineDataQty(Me, MediaPlanDetailLevelLineData)

                        Else

                            FillMediaPlanDetailLevelLineData(Me, MediaPlanDetailLevelLineData)

                        End If

                        FillMediaPlanDetailDataRowData(e.Row, MediaPlanDetailLevelLineData)

                        UpdateMediaPlanDetailLevelLineDataColor(MediaPlanDetailLevelLineData)

                    ElseIf MediaPlanDetailLevelLineData IsNot Nothing AndAlso e.Column.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

                        MediaPlanDetailLevelLineData.SetPropertyValue(e.Column.ColumnName, If(e.ProposedValue Is System.DBNull.Value, Nothing, e.ProposedValue))

                    End If

                End If

                _IsEstimateDataTableSaving = False

                RaiseEvent EstimateChangedEvent()

            End If

        End Sub
        Private Sub EstimateDataTable_RowDeleting(sender As Object, e As DataRowChangeEventArgs) Handles EstimateDataTable.RowDeleting

            If _IsEstimateDataTableSaving = False Then

                For Each MediaPlanDetailLevelLineData In _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = e.Row(DataColumns.RowIndex.ToString) AndAlso Entity.StartDate = e.Row(DataColumns.StartDate.ToString)).ToList

                    _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Remove(MediaPlanDetailLevelLineData)

                    Try

                        _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLineData)

                    Catch ex As Exception
                        MediaPlanDetailLevelLineData = Nothing
                    End Try

                Next

                RaiseEvent EstimateChangedEvent()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
