Namespace MediaPlanning

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const GrossPercentageInTotalsCaption As String = "% of Spending"
        Public Const NetDollarsCaption As String = "Net Dollars"
        Public Const CPP1Caption As String = "CPP 1"
        Public Const CPP2Caption As String = "CPP 2"
        Public Const CPICaption As String = "CPI"
        Public Const CTRCaption As String = "CTR"
        Public Const ConversionRateCaption As String = "Conversion Rate"
        Public Const TotalDemo1Caption As String = "Total Demo 1"
        Public Const TotalDemo2Caption As String = "Total Demo 2"
        Public Const TotalNetCaption As String = "Total Net"
        Public Const CommissionCaption As String = "Commission"

#End Region

#Region " Enum "

        Public Enum DataColumns
            ID = 0
            MediaPlanDetailLevelLineDataID = 1
            LevelLineID = 2
            Year = 3
            Quarter = 4
            Month = 5
            MonthName = 6
            Week = 7
            Day = 8
            [Date] = 9
            StartDate = 10
            RowIndex = 11
            Demo1 = 12
            Demo2 = 13
            Units = 14
            Impressions = 15
            Clicks = 16
            Rate = 17
            Dollars = 18
            AgencyFee = 19
            BillAmount = 20
            Note = 21
            Color = 22
            NetCharge = 23
            Columns = 24
            InchesLines = 25
        End Enum

        Public Enum GrossPercentInTotals
            Dollars = 18
            BillAmount = 20
        End Enum

        Public Enum DataAreaDataColumns
            Demo1 = 12
            Demo2 = 13
            Units = 14
            Impressions = 15
            Clicks = 16
            Rate = 17
            Dollars = 18
            AgencyFee = 19
            BillAmount = 20
            NetCharge = 23
            Columns = 24
            InchesLines = 25
        End Enum

        Public Enum DataAreaQuantityColumns
            Units = 14
            Impressions = 15
            Clicks = 16
            Columns = 24
            InchesLines = 25
        End Enum

        Public Enum Settings
            QuarterPrefix = 1
            Filter_MarketTagType = 2
            Filter_VendorTagType = 3
            Filter_AdSizeTagType = 4
            Filter_InternetTypeTagType = 5
            Filter_DaypartTagType = 6
            GrossPercentageInTotals = 7
            WeekDisplayType = 8
            IsUnitsCPM = 9
            IsImpressionsCPM = 10
            IsClicksCPM = 11
            NetDollars = 12
            CPP1 = 13
            CPP2 = 14
            CPI = 15
            Filter_OutOfHomeTypeTagType = 16
            ProductUsesNetAmount = 17
            ProductRebateAmount = 18
            ProductMarkupAmount = 19
            Filter_AdNumberTagType = 20
            HiatusWeeks = 21
            HiatusMonths = 22
            DaysOfWeek = 23
            Filter_JobComponentTagType = 24
            Print_PageSettings = 25
            Print_PageHeaderAndFooterSettings = 26
            Print_AutoFitPagesToWidth = 27
            Print_ScaleFactor = 28
            CTR = 29
            ConversionRate = 30
            CTRCaption = 31
            CTRIndex = 32
            ConversionRateCaption = 33
            ConversionRateIndex = 34
            CPP1Caption = 35
            CPP2Caption = 36
            TotalDemo1 = 37
            TotalDemo1Caption = 38
            TotalDemo1Index = 39
            TotalDemo2 = 40
            TotalDemo2Caption = 41
            TotalDemo2Index = 42
            NetDollarsCaption = 43
            NetDollarsIndex = 44
            CPP1Index = 45
            CPP2Index = 46
            CPICaption = 47
            CPIIndex = 48
            GrossPercentageInTotalsIndex = 49
            GrossPercentageInTotalsCaption = 50
            GrossPercentageInTotalsShowTotals = 51
            NetDollarsShowTotals = 52
            CPP1ShowTotals = 53
            CPP2ShowTotals = 54
            CPIShowTotals = 55
            CTRShowTotals = 56
            ConversionRateShowTotals = 57
            TotalDemo1ShowTotals = 58
            TotalDemo2ShowTotals = 59
            GrossPercentageInTotalsWidth = 60
            NetDollarsWidth = 61
            CPP1Width = 62
            CPP2Width = 63
            CPIWidth = 64
            CTRWidth = 65
            ConversionRateWidth = 66
            TotalDemo1Width = 67
            TotalDemo2Width = 68
            FreezeLevels = 69
            ShowPackageLevels = 70
            Filter_CampaignTagType = 71
            ShowDateRange = 72
            DateRangeCaption = 73
            PackageLevelWidth = 74
            DateRangeWidth = 75
            Filter_MarketOrderLineTagType = 76
            ShowAdSizes = 77
            AdSizesCaption = 78
            AdSizesWidth = 79
            ShowPackageName = 80
            PackageLevelIndex = 81
            DateRangeIndex = 82
            AdSizesIndex = 83
            TotalNet = 84
            TotalNetCaption = 85
            TotalNetIndex = 86
            TotalNetWidth = 87
            TotalNetShowTotals = 88
            Commission = 89
            CommissionCaption = 90
            CommissionIndex = 91
            CommissionWidth = 92
            CommissionShowTotals = 93
            PackageNameCaption = 94
            Filter_MediaChannelTagType = 95
            Filter_MediaTacticTagType = 96
            PackagePlacementWidth = 97
        End Enum

        Public Enum SettingTypes
            DetailSetting = 1
        End Enum

        Public Enum SettingValueTypes
            [String] = 1
            [Numeric] = 2
            [Date] = 3
            [Boolean] = 4
        End Enum

        Public Enum LevelLineColumns
            ID
            RowIndex
            Color
            PackageName
            PackagePlacement
            PackageDetails
        End Enum

        Public Enum WeekDisplayTypes
            WeekNumber = 1
            WeekStartDate = 2
            WeekStartDay = 3
        End Enum

        Public Enum TagTypes
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            [Default] = 0
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Name:="Market (Order)")>
            Market = 1
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            Vendor = 2
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Radio:=False, Television:=False)>
            AdSize = 3
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            InternetType = 4
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, OutOfHome:=False)>
            Daypart = 5
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            StartDate = 6
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            EndDate = 7
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, Radio:=False, Television:=False)>
            OutOfHomeType = 8
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            AdNumber = 9
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Name:="Job/Component")>
            JobComponent = 10
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            Campaign = 11
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Name:="Market (Order Line)", Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            MarketOrderLine = 12
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            MediaChannel = 13
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            MediaTactic = 14
        End Enum

        Public Enum MappingTypes
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            [None] = 0
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            OrderDescription = 1
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            OrderComment = 2
            '<AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            'Buyer = 3
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            Market = 4
            '<AdvantageFramework.MediaPlanning.Attributes.EstimateType(Radio:=False, Television:=False)>
            'AdSizeCode = 5
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Radio:=False, Television:=False)>
            AdSizeDescription = 6
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            AdNumber = 7
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Radio:=False, Television:=False)>
            Headline = 8
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            Issue = 9
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            InternetType = 10
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            Placement = 11
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, Radio:=False, Television:=False)>
            OutOfHomeType = 12
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, OutOfHome:=False)>
            Daypart = 13
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, OutOfHome:=False)>
            StartTime = 14
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, OutOfHome:=False)>
            EndTime = 15
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, OutOfHome:=False)>
            Length = 18
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, OutOfHome:=False)>
            Programming = 16
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, OutOfHome:=False)>
            NetworkCode = 17
            '<AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            'LineDescription = 19
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            Instructions = 20
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, OutOfHome:=False)>
            Remarks = 21
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            Section = 22
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Radio:=False, Television:=False)>
            OrderCopy = 23
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            MaterialNotes = 24
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, OutOfHome:=False)>
            PositionInfo = 25
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, OutOfHome:=False)>
            CloseInfo = 26
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, OutOfHome:=False)>
            RateInfo = 27
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            MiscInfo = 28
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, Magazine:=False, Newspaper:=False, Radio:=False, Television:=False)>
            Location = 29
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            URL = 30
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            TargetAudience = 31
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Name:="Job/Component")>
            JobComponent = 32
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            Material = 33
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType()>
            Campaign = 34
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Name:="Market (Order Line)", Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            MarketOrderLine = 35
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Internet:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            Circulation = 36
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            MediaChannel = 37
            <AdvantageFramework.MediaPlanning.Attributes.EstimateType(Magazine:=False, Newspaper:=False, OutOfHome:=False, Radio:=False, Television:=False)>
            MediaTactic = 38
            'PLEASE NOTE: NEXT NUMBER SHOULD BE 39
        End Enum

        Public Enum CreateOrderBroadcastCalendarType
            FromPlan = 0
            ByCalendar = 1
            ByBroadcast = 2
        End Enum

        Public Enum DaysOfWeeksType
            None = 0
            AsLevel = 1
            OverrideDataWithMerge = 2
            OverrideDataWithoutMerge = 3
        End Enum

        Public Enum CreateOrderOptions
            [Default] = 0
            AddToOrder = 1
            NewOrderLineForEveryPeriod = 2
        End Enum

        Public Enum OrderGroupingLevelLinesColumns
            GroupBy
            HasMediaOrder
        End Enum

        Public Enum PeriodTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "[None]")>
            [None] = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Day")>
            [Day] = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Week")>
            [Week] = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Month")>
            [Month] = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "4 - Week")>
            [OOH4Week] = 4
        End Enum

        Public Enum ShowPackageLevel
            None = 0
            AdSize = 1
            PackageLevel = 2
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function GetLastDateInPeriod(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                            StartDate As Date, DataColumn As AdvantageFramework.MediaPlanning.DataColumns) As Date

            'objects
            Dim LastDateInPeriod As Date = Date.MinValue

            If DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Year Then

                LastDateInPeriod = New Date(StartDate.Year, 12, 31)

            ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Quarter Then

                LastDateInPeriod = MediaPlan.MediaPlanEstimate.GetLastDayOfQuarter(StartDate)

            ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Month OrElse
                    DataColumn = AdvantageFramework.MediaPlanning.DataColumns.MonthName Then

                LastDateInPeriod = MediaPlan.MediaPlanEstimate.GetLastDayOfMonth(StartDate)

            ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Week Then

                LastDateInPeriod = MediaPlan.MediaPlanEstimate.GetLastDayOfWeek(StartDate)

            ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Day OrElse
                    DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Date Then

                LastDateInPeriod = StartDate

            End If

            GetLastDateInPeriod = LastDateInPeriod

        End Function
        Public Function LoadTagTypes() As Generic.List(Of AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute)

            'objects
            Dim TagTypes As Generic.List(Of AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute) = Nothing
            Dim TagType As AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute = Nothing

            TagTypes = New Generic.List(Of AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute)

            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(TagTypes), False)

                TagType = System.Attribute.GetCustomAttribute(GetType(TagTypes).GetField(KeyValuePair.Value), GetType(AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute))

                If TagType IsNot Nothing Then

                    If TagType.Value = -1 Then

                        TagType.Value = CInt(KeyValuePair.Key)

                    End If

                    If String.IsNullOrWhiteSpace(TagType.Name) Then

                        TagType.Name = AdvantageFramework.StringUtilities.GetNameAsWords(KeyValuePair.Value)

                    End If

                    TagTypes.Add(TagType)

                End If

            Next

            LoadTagTypes = TagTypes

        End Function
        Public Function LoadMappingTypes() As Generic.List(Of AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute)

            'objects
            Dim MappingTypes As Generic.List(Of AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute) = Nothing
            Dim MappingType As AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute = Nothing

            MappingTypes = New Generic.List(Of AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute)

            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(MappingTypes), False)

                MappingType = System.Attribute.GetCustomAttribute(GetType(MappingTypes).GetField(KeyValuePair.Value), GetType(AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute))

                If MappingType IsNot Nothing Then

                    If MappingType.Value = -1 Then

                        MappingType.Value = CInt(KeyValuePair.Key)

                    End If

                    If String.IsNullOrWhiteSpace(MappingType.Name) Then

                        MappingType.Name = AdvantageFramework.StringUtilities.GetNameAsWords(KeyValuePair.Value)

                    End If

                    MappingTypes.Add(MappingType)

                End If

            Next

            LoadMappingTypes = MappingTypes

        End Function
        Public Function CopyMediaPlanDetailDetailLines(ByVal Session As AdvantageFramework.Security.Session, ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer, ByVal FromMediaPlanDetailID As Integer, ByVal RowIndexesList As IEnumerable(Of Integer), ByVal IncludeData As Boolean) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim NewMediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim NewMediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim NewMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaPlanDetailLevelID As Integer = 0
            Dim MaxRowIndex As Integer = -1
            Dim NewRowIndexesDictionary As Generic.Dictionary(Of Integer, Integer) = Nothing
            Dim RowIndex As Integer = -1

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction

                MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

                If MediaPlan IsNot Nothing Then

                    MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID)

                    If MediaPlanDetail IsNot Nothing Then

                        Try

                            Try

                                MaxRowIndex = AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLine.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID).Select(Function(Entity) Entity.RowIndex).Max

                            Catch ex As Exception
                                MaxRowIndex = -1
                            End Try

                            NewRowIndexesDictionary = New Generic.Dictionary(Of Integer, Integer)

                            For Each RowIndex In RowIndexesList

                                MaxRowIndex += 1

                                NewRowIndexesDictionary(RowIndex) = MaxRowIndex

                            Next

                            For Each MediaPlanDetailLevel In AdvantageFramework.Database.Procedures.MediaPlanDetailLevel.LoadByMediaPlanDetailID(DbContext, FromMediaPlanDetailID).ToList

                                Try

                                    MediaPlanDetailLevelID = AdvantageFramework.Database.Procedures.MediaPlanDetailLevel.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID).SingleOrDefault(Function(Entity) Entity.Description = MediaPlanDetailLevel.Description).ID

                                Catch ex As Exception
                                    MediaPlanDetailLevelID = 0
                                End Try

                                If MediaPlanDetailLevelID > 0 Then

                                    For Each RowIndex In RowIndexesList

                                        For Each MediaPlanDetailLevelLine In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLine.LoadByMediaPlanDetailID(DbContext, FromMediaPlanDetailID).Where(Function(Entity) Entity.MediaPlanDetailLevelID = MediaPlanDetailLevel.ID AndAlso Entity.RowIndex = RowIndex).ToList

                                            NewMediaPlanDetailLevelLine = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine

                                            NewMediaPlanDetailLevelLine.MediaPlanDetailLevelID = MediaPlanDetailLevelID
                                            NewMediaPlanDetailLevelLine.MediaPlanDetailID = MediaPlanDetailID
                                            NewMediaPlanDetailLevelLine.MediaPlanID = MediaPlanID
                                            NewMediaPlanDetailLevelLine.Description = MediaPlanDetailLevelLine.Description
                                            NewMediaPlanDetailLevelLine.RowIndex = NewRowIndexesDictionary(RowIndex)
                                            NewMediaPlanDetailLevelLine.Expanded = MediaPlanDetailLevelLine.Expanded
                                            NewMediaPlanDetailLevelLine.Color = MediaPlanDetailLevelLine.Color
                                            NewMediaPlanDetailLevelLine.IsCPM = MediaPlanDetailLevelLine.IsCPM
                                            NewMediaPlanDetailLevelLine.QuantityColumn = MediaPlanDetailLevelLine.QuantityColumn
                                            NewMediaPlanDetailLevelLine.PackageName = MediaPlanDetailLevelLine.PackageName

                                            NewMediaPlanDetailLevelLine.CreatedByUserCode = Session.UserCode
                                            NewMediaPlanDetailLevelLine.CreatedDate = Now
                                            NewMediaPlanDetailLevelLine.ModifiedByUserCode = Nothing
                                            NewMediaPlanDetailLevelLine.ModifiedDate = Nothing

                                            DbContext.MediaPlanDetailLevelLines.Add(NewMediaPlanDetailLevelLine)

                                            For Each MediaPlanDetailLevelLineTag In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineTag.LoadByMediaPlanDetailID(DbContext, FromMediaPlanDetailID).Where(Function(Entity) Entity.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).ToList

                                                NewMediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag

                                                NewMediaPlanDetailLevelLineTag.MediaPlanDetailID = MediaPlanDetailID
                                                NewMediaPlanDetailLevelLineTag.MediaPlanID = MediaPlanID
                                                NewMediaPlanDetailLevelLineTag.MarketCode = MediaPlanDetailLevelLineTag.MarketCode
                                                NewMediaPlanDetailLevelLineTag.VendorCode = MediaPlanDetailLevelLineTag.VendorCode
                                                NewMediaPlanDetailLevelLineTag.VendorCommission = MediaPlanDetailLevelLineTag.VendorCommission
                                                NewMediaPlanDetailLevelLineTag.VendorMarkup = MediaPlanDetailLevelLineTag.VendorMarkup
                                                NewMediaPlanDetailLevelLineTag.MediaType = MediaPlanDetailLevelLineTag.MediaType
                                                NewMediaPlanDetailLevelLineTag.SizeCode = MediaPlanDetailLevelLineTag.SizeCode
                                                NewMediaPlanDetailLevelLineTag.InternetTypeCode = MediaPlanDetailLevelLineTag.InternetTypeCode
                                                NewMediaPlanDetailLevelLineTag.DaypartID = MediaPlanDetailLevelLineTag.DaypartID
                                                NewMediaPlanDetailLevelLineTag.StartDate = MediaPlanDetailLevelLineTag.StartDate
                                                NewMediaPlanDetailLevelLineTag.EndDate = MediaPlanDetailLevelLineTag.EndDate
                                                NewMediaPlanDetailLevelLineTag.OutOfHomeTypeCode = MediaPlanDetailLevelLineTag.OutOfHomeTypeCode
                                                NewMediaPlanDetailLevelLineTag.AdNumber = MediaPlanDetailLevelLineTag.AdNumber
                                                NewMediaPlanDetailLevelLineTag.JobNumber = MediaPlanDetailLevelLineTag.JobNumber
                                                NewMediaPlanDetailLevelLineTag.JobComponentNumber = MediaPlanDetailLevelLineTag.JobComponentNumber
                                                NewMediaPlanDetailLevelLineTag.CampaignID = MediaPlanDetailLevelLineTag.CampaignID
                                                NewMediaPlanDetailLevelLineTag.MediaChannelID = MediaPlanDetailLevelLineTag.MediaChannelID
                                                NewMediaPlanDetailLevelLineTag.MediaTacticID = MediaPlanDetailLevelLineTag.MediaTacticID

                                                NewMediaPlanDetailLevelLineTag.CreatedByUserCode = Session.UserCode
                                                NewMediaPlanDetailLevelLineTag.CreatedDate = Now
                                                NewMediaPlanDetailLevelLineTag.ModifiedByUserCode = Nothing
                                                NewMediaPlanDetailLevelLineTag.ModifiedDate = Nothing

                                                If NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags Is Nothing Then

                                                    NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

                                                End If

                                                NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Add(NewMediaPlanDetailLevelLineTag)

                                            Next

                                        Next

                                    Next

                                End If

                            Next

                            If IncludeData Then

                                For Each RowIndex In RowIndexesList

                                    For Each MediaPlanDetailLevelLineData In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanDetailIDAndRowIndex(DbContext, FromMediaPlanDetailID, RowIndex).ToList

                                        NewMediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

                                        NewMediaPlanDetailLevelLineData.MediaPlanDetailID = MediaPlanDetailID
                                        NewMediaPlanDetailLevelLineData.MediaPlanID = MediaPlanID
                                        NewMediaPlanDetailLevelLineData.StartDate = MediaPlanDetailLevelLineData.StartDate
                                        NewMediaPlanDetailLevelLineData.EndDate = MediaPlanDetailLevelLineData.EndDate
                                        NewMediaPlanDetailLevelLineData.Demo1 = MediaPlanDetailLevelLineData.Demo1
                                        NewMediaPlanDetailLevelLineData.Demo2 = MediaPlanDetailLevelLineData.Demo2
                                        NewMediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Dollars
                                        NewMediaPlanDetailLevelLineData.Units = MediaPlanDetailLevelLineData.Units
                                        NewMediaPlanDetailLevelLineData.Rate = MediaPlanDetailLevelLineData.Rate
                                        NewMediaPlanDetailLevelLineData.Note = MediaPlanDetailLevelLineData.Note
                                        NewMediaPlanDetailLevelLineData.Color = MediaPlanDetailLevelLineData.Color
                                        NewMediaPlanDetailLevelLineData.RowIndex = NewRowIndexesDictionary(RowIndex)
                                        NewMediaPlanDetailLevelLineData.Impressions = MediaPlanDetailLevelLineData.Impressions
                                        NewMediaPlanDetailLevelLineData.Clicks = MediaPlanDetailLevelLineData.Clicks
                                        NewMediaPlanDetailLevelLineData.AgencyFee = MediaPlanDetailLevelLineData.AgencyFee
                                        NewMediaPlanDetailLevelLineData.BillAmount = MediaPlanDetailLevelLineData.BillAmount
                                        NewMediaPlanDetailLevelLineData.NetCharge = MediaPlanDetailLevelLineData.NetCharge
                                        NewMediaPlanDetailLevelLineData.Columns = MediaPlanDetailLevelLineData.Columns
                                        NewMediaPlanDetailLevelLineData.InchesLines = MediaPlanDetailLevelLineData.InchesLines
                                        NewMediaPlanDetailLevelLineData.IsActualized = False

                                        NewMediaPlanDetailLevelLineData.Sunday = MediaPlanDetailLevelLineData.Sunday
                                        NewMediaPlanDetailLevelLineData.Monday = MediaPlanDetailLevelLineData.Monday
                                        NewMediaPlanDetailLevelLineData.Tuesday = MediaPlanDetailLevelLineData.Tuesday
                                        NewMediaPlanDetailLevelLineData.Wednesday = MediaPlanDetailLevelLineData.Wednesday
                                        NewMediaPlanDetailLevelLineData.Thursday = MediaPlanDetailLevelLineData.Thursday
                                        NewMediaPlanDetailLevelLineData.Friday = MediaPlanDetailLevelLineData.Friday
                                        NewMediaPlanDetailLevelLineData.Saturday = MediaPlanDetailLevelLineData.Saturday

                                        NewMediaPlanDetailLevelLineData.CreatedByUserCode = Session.UserCode
                                        NewMediaPlanDetailLevelLineData.CreatedDate = Now
                                        NewMediaPlanDetailLevelLineData.ModifiedByUserCode = Nothing
                                        NewMediaPlanDetailLevelLineData.ModifiedDate = Nothing

                                        DbContext.MediaPlanDetailLevelLineDatas.Add(NewMediaPlanDetailLevelLineData)

                                    Next

                                Next

                            End If

                            Try

                                DbContext.SaveChanges()

                                Copied = True

                            Catch ex As Exception

                            End Try

                        Catch ex As Exception
                            Copied = False
                        End Try

                    End If

                End If

                If Copied Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

                DbContext.Database.Connection.Close()

            End Using

            CopyMediaPlanDetailDetailLines = Copied

        End Function
        Public Function CopyMediaPlanDetailDetailLevelAndLines(ByVal Session As AdvantageFramework.Security.Session, ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer, ByVal FromMediaPlanDetailID As Integer, ByVal RowIndexesList As IEnumerable(Of Integer), ByVal IncludeData As Boolean) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim NewMediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim NewMediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim NewMediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim NewMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim NewRowIndexes As Dictionary(Of Integer, Integer) = Nothing
            Dim NewRowIndex As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction

                MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

                If MediaPlan IsNot Nothing Then

                    MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID)

                    If MediaPlanDetail IsNot Nothing Then

                        NewRowIndexes = New Dictionary(Of Integer, Integer)

                        For Each RowIndex In RowIndexesList.OrderBy(Function(RI) RI).ToList

                            NewRowIndexes(RowIndex) = NewRowIndex

                            NewRowIndex += 1

                        Next

                        Try

                            For Each MediaPlanDetailLevel In AdvantageFramework.Database.Procedures.MediaPlanDetailLevel.LoadByMediaPlanDetailID(DbContext, FromMediaPlanDetailID).ToList

                                NewMediaPlanDetailLevel = New AdvantageFramework.Database.Entities.MediaPlanDetailLevel

                                NewMediaPlanDetailLevel.MediaPlanDetailID = MediaPlanDetailID
                                NewMediaPlanDetailLevel.MediaPlanID = MediaPlanID
                                NewMediaPlanDetailLevel.Description = MediaPlanDetailLevel.Description
                                NewMediaPlanDetailLevel.OrderNumber = MediaPlanDetailLevel.OrderNumber
                                NewMediaPlanDetailLevel.Width = MediaPlanDetailLevel.Width
                                NewMediaPlanDetailLevel.TagType = MediaPlanDetailLevel.TagType
                                NewMediaPlanDetailLevel.MappingType = MediaPlanDetailLevel.MappingType
                                NewMediaPlanDetailLevel.IsVisible = MediaPlanDetailLevel.IsVisible

                                NewMediaPlanDetailLevel.CreatedByUserCode = Session.UserCode
                                NewMediaPlanDetailLevel.CreatedDate = Now
                                NewMediaPlanDetailLevel.ModifiedByUserCode = Nothing
                                NewMediaPlanDetailLevel.ModifiedDate = Nothing

                                DbContext.MediaPlanDetailLevels.Add(NewMediaPlanDetailLevel)

                                For Each MediaPlanDetailLevelLine In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLine.LoadByMediaPlanDetailID(DbContext, FromMediaPlanDetailID).Where(Function(Entity) Entity.MediaPlanDetailLevelID = MediaPlanDetailLevel.ID).ToList

                                    If RowIndexesList.Contains(MediaPlanDetailLevelLine.RowIndex) Then

                                        NewMediaPlanDetailLevelLine = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine

                                        NewMediaPlanDetailLevelLine.MediaPlanDetailID = MediaPlanDetailID
                                        NewMediaPlanDetailLevelLine.MediaPlanID = MediaPlanID
                                        NewMediaPlanDetailLevelLine.MediaPlanDetailLevel = NewMediaPlanDetailLevel
                                        NewMediaPlanDetailLevelLine.Description = MediaPlanDetailLevelLine.Description
                                        NewMediaPlanDetailLevelLine.RowIndex = NewRowIndexes(MediaPlanDetailLevelLine.RowIndex)
                                        NewMediaPlanDetailLevelLine.Expanded = MediaPlanDetailLevelLine.Expanded
                                        NewMediaPlanDetailLevelLine.Color = MediaPlanDetailLevelLine.Color
                                        NewMediaPlanDetailLevelLine.IsCPM = MediaPlanDetailLevelLine.IsCPM
                                        NewMediaPlanDetailLevelLine.QuantityColumn = MediaPlanDetailLevelLine.QuantityColumn
                                        NewMediaPlanDetailLevelLine.PackageName = MediaPlanDetailLevelLine.PackageName

                                        NewMediaPlanDetailLevelLine.CreatedByUserCode = Session.UserCode
                                        NewMediaPlanDetailLevelLine.CreatedDate = Now
                                        NewMediaPlanDetailLevelLine.ModifiedByUserCode = Nothing
                                        NewMediaPlanDetailLevelLine.ModifiedDate = Nothing

                                        If NewMediaPlanDetailLevel.MediaPlanDetailLevelLines Is Nothing Then

                                            NewMediaPlanDetailLevel.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                                        End If

                                        NewMediaPlanDetailLevel.MediaPlanDetailLevelLines.Add(NewMediaPlanDetailLevelLine)

                                        DbContext.MediaPlanDetailLevelLines.Add(NewMediaPlanDetailLevelLine)

                                        For Each MediaPlanDetailLevelLineTag In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineTag.LoadByMediaPlanDetailID(DbContext, FromMediaPlanDetailID).Where(Function(Entity) Entity.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).ToList.ToList

                                            NewMediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag

                                            NewMediaPlanDetailLevelLineTag.MediaPlanDetailID = MediaPlanDetailID
                                            NewMediaPlanDetailLevelLineTag.MediaPlanID = MediaPlanID
                                            NewMediaPlanDetailLevelLineTag.MediaPlanDetailLevelLine = NewMediaPlanDetailLevelLine
                                            NewMediaPlanDetailLevelLineTag.MarketCode = MediaPlanDetailLevelLineTag.MarketCode
                                            NewMediaPlanDetailLevelLineTag.VendorCode = MediaPlanDetailLevelLineTag.VendorCode
                                            NewMediaPlanDetailLevelLineTag.VendorCommission = MediaPlanDetailLevelLineTag.VendorCommission
                                            NewMediaPlanDetailLevelLineTag.VendorMarkup = MediaPlanDetailLevelLineTag.VendorMarkup
                                            NewMediaPlanDetailLevelLineTag.MediaType = MediaPlanDetailLevelLineTag.MediaType
                                            NewMediaPlanDetailLevelLineTag.SizeCode = MediaPlanDetailLevelLineTag.SizeCode
                                            NewMediaPlanDetailLevelLineTag.InternetTypeCode = MediaPlanDetailLevelLineTag.InternetTypeCode
                                            NewMediaPlanDetailLevelLineTag.DaypartID = MediaPlanDetailLevelLineTag.DaypartID
                                            NewMediaPlanDetailLevelLineTag.StartDate = MediaPlanDetailLevelLineTag.StartDate
                                            NewMediaPlanDetailLevelLineTag.EndDate = MediaPlanDetailLevelLineTag.EndDate
                                            NewMediaPlanDetailLevelLineTag.OutOfHomeTypeCode = MediaPlanDetailLevelLineTag.OutOfHomeTypeCode
                                            NewMediaPlanDetailLevelLineTag.AdNumber = MediaPlanDetailLevelLineTag.AdNumber
                                            NewMediaPlanDetailLevelLineTag.JobNumber = MediaPlanDetailLevelLineTag.JobNumber
                                            NewMediaPlanDetailLevelLineTag.JobComponentNumber = MediaPlanDetailLevelLineTag.JobComponentNumber
                                            NewMediaPlanDetailLevelLineTag.CampaignID = MediaPlanDetailLevelLineTag.CampaignID
                                            NewMediaPlanDetailLevelLineTag.MediaChannelID = MediaPlanDetailLevelLineTag.MediaChannelID
                                            NewMediaPlanDetailLevelLineTag.MediaTacticID = MediaPlanDetailLevelLineTag.MediaTacticID

                                            NewMediaPlanDetailLevelLineTag.CreatedByUserCode = Session.UserCode
                                            NewMediaPlanDetailLevelLineTag.CreatedDate = Now
                                            NewMediaPlanDetailLevelLineTag.ModifiedByUserCode = Nothing
                                            NewMediaPlanDetailLevelLineTag.ModifiedDate = Nothing

                                            If NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags Is Nothing Then

                                                NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

                                            End If

                                            NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Add(NewMediaPlanDetailLevelLineTag)

                                            DbContext.MediaPlanDetailLevelLineTags.Add(NewMediaPlanDetailLevelLineTag)

                                        Next

                                    End If

                                Next

                            Next

                            If IncludeData Then

                                For Each MediaPlanDetailLevelLineData In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanDetailID(DbContext, FromMediaPlanDetailID).ToList

                                    If RowIndexesList.Contains(MediaPlanDetailLevelLineData.RowIndex) AndAlso
                                            (CDate(MediaPlanDetailLevelLineData.StartDate.ToShortDateString) >= CDate(MediaPlan.StartDate.ToShortDateString) AndAlso
                                             CDate(MediaPlanDetailLevelLineData.StartDate.ToShortDateString) <= CDate(MediaPlan.EndDate.ToShortDateString)) Then

                                        NewMediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

                                        NewMediaPlanDetailLevelLineData.MediaPlanDetailID = MediaPlanDetailID
                                        NewMediaPlanDetailLevelLineData.MediaPlanID = MediaPlanID
                                        NewMediaPlanDetailLevelLineData.StartDate = MediaPlanDetailLevelLineData.StartDate
                                        NewMediaPlanDetailLevelLineData.EndDate = MediaPlanDetailLevelLineData.EndDate
                                        NewMediaPlanDetailLevelLineData.Demo1 = MediaPlanDetailLevelLineData.Demo1
                                        NewMediaPlanDetailLevelLineData.Demo2 = MediaPlanDetailLevelLineData.Demo2
                                        NewMediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Dollars
                                        NewMediaPlanDetailLevelLineData.Units = MediaPlanDetailLevelLineData.Units
                                        NewMediaPlanDetailLevelLineData.Rate = MediaPlanDetailLevelLineData.Rate
                                        NewMediaPlanDetailLevelLineData.Note = MediaPlanDetailLevelLineData.Note
                                        NewMediaPlanDetailLevelLineData.Color = MediaPlanDetailLevelLineData.Color
                                        NewMediaPlanDetailLevelLineData.RowIndex = NewRowIndexes(MediaPlanDetailLevelLineData.RowIndex)
                                        NewMediaPlanDetailLevelLineData.Impressions = MediaPlanDetailLevelLineData.Impressions
                                        NewMediaPlanDetailLevelLineData.Clicks = MediaPlanDetailLevelLineData.Clicks
                                        NewMediaPlanDetailLevelLineData.AgencyFee = MediaPlanDetailLevelLineData.AgencyFee
                                        NewMediaPlanDetailLevelLineData.BillAmount = MediaPlanDetailLevelLineData.BillAmount
                                        NewMediaPlanDetailLevelLineData.NetCharge = MediaPlanDetailLevelLineData.NetCharge
                                        NewMediaPlanDetailLevelLineData.Columns = MediaPlanDetailLevelLineData.Columns
                                        NewMediaPlanDetailLevelLineData.InchesLines = MediaPlanDetailLevelLineData.InchesLines
                                        NewMediaPlanDetailLevelLineData.IsActualized = False

                                        NewMediaPlanDetailLevelLineData.Sunday = MediaPlanDetailLevelLineData.Sunday
                                        NewMediaPlanDetailLevelLineData.Monday = MediaPlanDetailLevelLineData.Monday
                                        NewMediaPlanDetailLevelLineData.Tuesday = MediaPlanDetailLevelLineData.Tuesday
                                        NewMediaPlanDetailLevelLineData.Wednesday = MediaPlanDetailLevelLineData.Wednesday
                                        NewMediaPlanDetailLevelLineData.Thursday = MediaPlanDetailLevelLineData.Thursday
                                        NewMediaPlanDetailLevelLineData.Friday = MediaPlanDetailLevelLineData.Friday
                                        NewMediaPlanDetailLevelLineData.Saturday = MediaPlanDetailLevelLineData.Saturday

                                        NewMediaPlanDetailLevelLineData.CreatedByUserCode = Session.UserCode
                                        NewMediaPlanDetailLevelLineData.CreatedDate = Now
                                        NewMediaPlanDetailLevelLineData.ModifiedByUserCode = Nothing
                                        NewMediaPlanDetailLevelLineData.ModifiedDate = Nothing

                                        DbContext.MediaPlanDetailLevelLineDatas.Add(NewMediaPlanDetailLevelLineData)

                                    End If

                                Next

                            End If

                            Try

                                DbContext.SaveChanges()

                                Copied = True

                            Catch ex As Exception

                            End Try

                        Catch ex As Exception
                            Copied = False
                        End Try

                    End If

                End If

                If Copied Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

                DbContext.Database.Connection.Close()

            End Using

            CopyMediaPlanDetailDetailLevelAndLines = Copied

        End Function
        Public Function CopyMediaPlanDetailDetailLevels(ByVal Session As AdvantageFramework.Security.Session, ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer, ByVal FromMediaPlanDetailID As Integer) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim NewMediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction

                MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

                If MediaPlan IsNot Nothing Then

                    MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID)

                    If MediaPlanDetail IsNot Nothing Then

                        Try

                            For Each MediaPlanDetailLevel In AdvantageFramework.Database.Procedures.MediaPlanDetailLevel.LoadByMediaPlanDetailID(DbContext, FromMediaPlanDetailID).ToList

                                NewMediaPlanDetailLevel = New AdvantageFramework.Database.Entities.MediaPlanDetailLevel

                                NewMediaPlanDetailLevel.MediaPlanDetailID = MediaPlanDetailID
                                NewMediaPlanDetailLevel.MediaPlanID = MediaPlanID
                                NewMediaPlanDetailLevel.Description = MediaPlanDetailLevel.Description
                                NewMediaPlanDetailLevel.OrderNumber = MediaPlanDetailLevel.OrderNumber
                                NewMediaPlanDetailLevel.Width = MediaPlanDetailLevel.Width
                                NewMediaPlanDetailLevel.TagType = MediaPlanDetailLevel.TagType
                                NewMediaPlanDetailLevel.MappingType = MediaPlanDetailLevel.MappingType
                                NewMediaPlanDetailLevel.IsVisible = MediaPlanDetailLevel.IsVisible

                                NewMediaPlanDetailLevel.CreatedByUserCode = Session.UserCode
                                NewMediaPlanDetailLevel.CreatedDate = Now
                                NewMediaPlanDetailLevel.ModifiedByUserCode = Nothing
                                NewMediaPlanDetailLevel.ModifiedDate = Nothing

                                DbContext.MediaPlanDetailLevels.Add(NewMediaPlanDetailLevel)

                            Next

                            Try

                                DbContext.SaveChanges()

                                Copied = True

                            Catch ex As Exception

                            End Try

                        Catch ex As Exception
                            Copied = False
                        End Try

                    End If

                End If

                If Copied Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

                DbContext.Database.Connection.Close()

            End Using

            CopyMediaPlanDetailDetailLevels = Copied

        End Function
        Public Function CopyMediaPlanDetail(ByVal Session As AdvantageFramework.Security.Session, ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer, ByRef NewMediaPlanDetailID As Integer, ByVal NewPlanIndex As Integer) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                CopyMediaPlanDetail = CopyMediaPlanDetail(DbContext, MediaPlanID, MediaPlanDetailID, NewMediaPlanDetailID, NewPlanIndex, Nothing)

            End Using

        End Function
        Public Function CopyMediaPlanDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer, ByRef NewMediaPlanDetailID As Integer, ByVal NewPlanIndex As Integer, NewSalesClassCode As String) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim NewMediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim NewMediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim NewMediaPlanDetailPackageDetail As AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail = Nothing
            Dim NewMediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim NewMediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim NewMediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim NewMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim NewMediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            'Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            'Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing
            Dim ProductUsesNetAmount As Boolean = False
            Dim ProductRebateAmount As Decimal = 0
            Dim ProductMarkupAmount As Decimal = 0
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorMediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim VendorMediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim VendorMediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim NewMediaPlanDetailPackagePlacementName As AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName = Nothing

            MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

            If MediaPlan IsNot Nothing Then

                MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID)

                If MediaPlanDetail IsNot Nothing Then

                    Try

                        NewMediaPlanDetail = New AdvantageFramework.Database.Entities.MediaPlanDetail

                        NewMediaPlanDetail.DbContext = DbContext
                        NewMediaPlanDetail.MediaPlanID = MediaPlanDetail.MediaPlanID
                        NewMediaPlanDetail.SalesClassType = MediaPlanDetail.SalesClassType

                        If Not String.IsNullOrWhiteSpace(NewSalesClassCode) Then

                            NewMediaPlanDetail.SalesClassCode = NewSalesClassCode

                        Else

                            NewMediaPlanDetail.SalesClassCode = MediaPlanDetail.SalesClassCode

                        End If

                        NewMediaPlanDetail.IsEstimateGrossAmount = MediaPlanDetail.IsEstimateGrossAmount
                        NewMediaPlanDetail.IsCalendarMonth = MediaPlanDetail.IsCalendarMonth
                        NewMediaPlanDetail.Color = MediaPlanDetail.Color
                        NewMediaPlanDetail.Notes = MediaPlanDetail.Notes
                        NewMediaPlanDetail.CreatedByUserCode = DbContext.UserCode
                        NewMediaPlanDetail.CreatedDate = Now
                        NewMediaPlanDetail.ModifiedByUserCode = Nothing
                        NewMediaPlanDetail.ModifiedDate = Nothing
                        NewMediaPlanDetail.CalculateDollars = MediaPlanDetail.CalculateDollars
                        NewMediaPlanDetail.ShowColumnTotals = MediaPlanDetail.ShowColumnTotals
                        NewMediaPlanDetail.ShowRowTotals = MediaPlanDetail.ShowRowTotals
                        NewMediaPlanDetail.CampaignID = MediaPlanDetail.CampaignID
                        NewMediaPlanDetail.ShowRowGrandTotals = MediaPlanDetail.ShowRowGrandTotals
                        NewMediaPlanDetail.ShowColumnGrandTotals = MediaPlanDetail.ShowColumnGrandTotals
                        NewMediaPlanDetail.Name = MediaPlanDetail.Name
                        NewMediaPlanDetail.IsApproved = False
                        NewMediaPlanDetail.ApprovedBy = Nothing
                        NewMediaPlanDetail.ApprovedDate = Nothing
                        NewMediaPlanDetail.SplitWeeks = MediaPlanDetail.SplitWeeks
                        NewMediaPlanDetail.OrderGrouping = 0
                        NewMediaPlanDetail.OrderNumber = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).Count + 1
                        NewMediaPlanDetail.BuyerEmployeeCode = MediaPlanDetail.BuyerEmployeeCode
                        NewMediaPlanDetail.GrossBudgetAmount = MediaPlanDetail.GrossBudgetAmount
                        NewMediaPlanDetail.IsCable = MediaPlanDetail.IsCable
                        NewMediaPlanDetail.CreateOrderOption = MediaPlanDetail.CreateOrderOption
                        NewMediaPlanDetail.ShowRowTotalsValues = MediaPlanDetail.ShowRowTotalsValues
                        NewMediaPlanDetail.ShowRowGrandTotalsValues = MediaPlanDetail.ShowRowGrandTotalsValues
                        NewMediaPlanDetail.AllowCampaignLevel = MediaPlanDetail.AllowCampaignLevel

                        If MediaPlanDetail.PeriodType = 0 Then

                            If NewMediaPlanDetail.SalesClassType = "O" Then

                                NewMediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week

                            ElseIf NewMediaPlanDetail.SalesClassType = "R" AndAlso MediaPlanDetail.SalesClassType = "T" Then

                                NewMediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None

                            ElseIf NewMediaPlanDetail.SalesClassType = "I" Then

                                NewMediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month

                            ElseIf NewMediaPlanDetail.SalesClassType = "N" Then

                                NewMediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Day

                            Else

                                NewMediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month

                            End If

                        Else

                            NewMediaPlanDetail.PeriodType = MediaPlanDetail.PeriodType

                        End If

                        Copied = AdvantageFramework.Database.Procedures.MediaPlanDetail.Insert(DbContext, NewMediaPlanDetail)

                    Catch ex As Exception
                        Copied = False
                    End Try

                    If Copied Then

                        NewMediaPlanDetailID = NewMediaPlanDetail.ID

                        Select Case NewMediaPlanDetail.SalesClassType

                            Case "I"

                                NewMediaPlanDetail.Name = NewPlanIndex.ToString.PadLeft(6, "0") & " - Internet"

                            Case "M"

                                NewMediaPlanDetail.Name = NewPlanIndex.ToString.PadLeft(6, "0") & " - Magazine"

                            Case "N"

                                NewMediaPlanDetail.Name = NewPlanIndex.ToString.PadLeft(6, "0") & " - Newspaper"

                            Case "O"

                                NewMediaPlanDetail.Name = NewPlanIndex.ToString.PadLeft(6, "0") & " - Out Of Home"

                            Case "R"

                                NewMediaPlanDetail.Name = NewPlanIndex.ToString.PadLeft(6, "0") & " - Radio"

                            Case "T"

                                NewMediaPlanDetail.Name = NewPlanIndex.ToString.PadLeft(6, "0") & " - Television"

                        End Select

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET NAME = '{0}' WHERE MEDIA_PLAN_DTL_ID = {1}", NewMediaPlanDetail.Name, NewMediaPlanDetailID))

                    End If

                End If

            End If

            If Copied Then

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction

                MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

                If MediaPlan IsNot Nothing Then

                    Try

                        MediaPlanDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanDetail).Include("MediaPlanDetailLevelLineDatas").
                                                                                                                                      Include("MediaPlanDetailSettings").
                                                                                                                                      Include("MediaPlanDetailLevels").
                                                                                                                                      Include("MediaPlanDetailLevels.MediaPlanDetailLevelLines").
                                                                                                                                      Include("MediaPlanDetailLevels.MediaPlanDetailLevelLines.MediaPlanDetailLevelLineTags").
                                                                                                                                      Include("MediaPlanDetailFields")
                                           Where Entity.ID = MediaPlanDetailID
                                           Select Entity).SingleOrDefault

                    Catch ex As Exception
                        MediaPlanDetail = Nothing
                    End Try

                    If MediaPlanDetail IsNot Nothing Then

                        NewMediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, NewMediaPlanDetailID)

                        If NewMediaPlanDetail IsNot Nothing Then

                            SetProductAmountValues(DbContext, MediaPlan.ClientCode, MediaPlan.DivisionCode, MediaPlan.ProductCode, NewMediaPlanDetail.SalesClassType, NewMediaPlanDetail.SalesClassCode, ProductUsesNetAmount, ProductRebateAmount, ProductMarkupAmount)

                            'Try

                            '    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, MediaPlan.ClientCode, MediaPlan.DivisionCode, MediaPlan.ProductCode)

                            'Catch ex As Exception
                            '    Product = Nothing
                            'End Try

                            'If Product IsNot Nothing Then

                            '    Try

                            '        ProductMediaOverrides = AdvantageFramework.Database.Procedures.ProductMediaOverrides.LoadByClientDivisionProduct(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code).SingleOrDefault(Function(Entity) Entity.MediaType = NewMediaPlanDetail.SalesClassType AndAlso Entity.SalesClassCode = NewMediaPlanDetail.SalesClassCode)

                            '    Catch ex As Exception
                            '        ProductMediaOverrides = Nothing
                            '    End Try

                            '    If ProductMediaOverrides IsNot Nothing Then

                            '        If NewMediaPlanDetail.SalesClassType = "R" Then

                            '            If Product.RadioBillNet = 1 Then

                            '                ProductUsesNetAmount = True

                            '            Else

                            '                ProductUsesNetAmount = False

                            '            End If

                            '        ElseIf NewMediaPlanDetail.SalesClassType = "T" Then

                            '            If Product.TelevisionBillNet = 1 Then

                            '                ProductUsesNetAmount = True

                            '            Else

                            '                ProductUsesNetAmount = False

                            '            End If

                            '        ElseIf NewMediaPlanDetail.SalesClassType = "M" Then

                            '            If Product.MagazineBillNet = 1 Then

                            '                ProductUsesNetAmount = True

                            '            Else

                            '                ProductUsesNetAmount = False

                            '            End If

                            '        ElseIf NewMediaPlanDetail.SalesClassType = "O" Then

                            '            If Product.OutOfHomeBillNet = 1 Then

                            '                ProductUsesNetAmount = True

                            '            Else

                            '                ProductUsesNetAmount = False

                            '            End If

                            '        ElseIf NewMediaPlanDetail.SalesClassType = "I" Then

                            '            If Product.InternetBillNet = 1 Then

                            '                ProductUsesNetAmount = True

                            '            Else

                            '                ProductUsesNetAmount = False

                            '            End If

                            '        ElseIf NewMediaPlanDetail.SalesClassType = "N" Then

                            '            If Product.NewspaperBillNet = 1 Then

                            '                ProductUsesNetAmount = True

                            '            Else

                            '                ProductUsesNetAmount = False

                            '            End If

                            '        End If

                            '        ProductRebateAmount = ProductMediaOverrides.RebatePercent.GetValueOrDefault(0)
                            '        ProductMarkupAmount = ProductMediaOverrides.MarkupPercent.GetValueOrDefault(0)

                            '    Else

                            '        If NewMediaPlanDetail.SalesClassType = "R" Then

                            '            If Product.RadioBillNet = 1 Then

                            '                ProductUsesNetAmount = True
                            '                ProductRebateAmount = 0
                            '                ProductMarkupAmount = 0

                            '            Else

                            '                ProductUsesNetAmount = False
                            '                ProductRebateAmount = Product.RadioRebate.GetValueOrDefault(0)
                            '                ProductMarkupAmount = Product.RadioMarkup.GetValueOrDefault(0)

                            '            End If

                            '        ElseIf NewMediaPlanDetail.SalesClassType = "T" Then

                            '            If Product.TelevisionBillNet = 1 Then

                            '                ProductUsesNetAmount = True
                            '                ProductRebateAmount = 0
                            '                ProductMarkupAmount = 0

                            '            Else

                            '                ProductUsesNetAmount = False
                            '                ProductRebateAmount = Product.TelevisionRebate.GetValueOrDefault(0)
                            '                ProductMarkupAmount = Product.TelevisionMarkup.GetValueOrDefault(0)

                            '            End If

                            '        ElseIf NewMediaPlanDetail.SalesClassType = "M" Then

                            '            If Product.MagazineBillNet = 1 Then

                            '                ProductUsesNetAmount = True
                            '                ProductRebateAmount = 0
                            '                ProductMarkupAmount = 0

                            '            Else

                            '                ProductUsesNetAmount = False
                            '                ProductRebateAmount = Product.MagazineRebate.GetValueOrDefault(0)
                            '                ProductMarkupAmount = Product.MagazineMarkup.GetValueOrDefault(0)

                            '            End If

                            '        ElseIf NewMediaPlanDetail.SalesClassType = "O" Then

                            '            If Product.OutOfHomeBillNet = 1 Then

                            '                ProductUsesNetAmount = True
                            '                ProductRebateAmount = 0
                            '                ProductMarkupAmount = 0

                            '            Else

                            '                ProductUsesNetAmount = False
                            '                ProductRebateAmount = Product.OutOfHomeRebate.GetValueOrDefault(0)
                            '                ProductMarkupAmount = Product.OutOfHomeMarkup.GetValueOrDefault(0)

                            '            End If

                            '        ElseIf NewMediaPlanDetail.SalesClassType = "I" Then

                            '            If Product.InternetBillNet = 1 Then

                            '                ProductUsesNetAmount = True
                            '                ProductRebateAmount = 0
                            '                ProductMarkupAmount = 0

                            '            Else

                            '                ProductUsesNetAmount = False
                            '                ProductRebateAmount = Product.InternetRebate.GetValueOrDefault(0)
                            '                ProductMarkupAmount = Product.InternetMarkup.GetValueOrDefault(0)

                            '            End If

                            '        ElseIf NewMediaPlanDetail.SalesClassType = "N" Then

                            '            If Product.NewspaperBillNet = 1 Then

                            '                ProductUsesNetAmount = True
                            '                ProductRebateAmount = 0
                            '                ProductMarkupAmount = 0

                            '            Else

                            '                ProductUsesNetAmount = False
                            '                ProductRebateAmount = Product.NewspaperRebate.GetValueOrDefault(0)
                            '                ProductMarkupAmount = Product.NewspaperMarkup.GetValueOrDefault(0)

                            '            End If

                            '        Else

                            '            ProductUsesNetAmount = True
                            '            ProductRebateAmount = 0
                            '            ProductMarkupAmount = 0

                            '        End If

                            '    End If

                            'End If

                            Try

                                For Each MediaPlanDetailField In MediaPlanDetail.MediaPlanDetailFields.ToList

                                    NewMediaPlanDetailField = New AdvantageFramework.Database.Entities.MediaPlanDetailField

                                    NewMediaPlanDetailField.MediaPlanDetailID = NewMediaPlanDetailID
                                    NewMediaPlanDetailField.MediaPlanID = MediaPlanID
                                    NewMediaPlanDetailField.FieldID = MediaPlanDetailField.FieldID
                                    NewMediaPlanDetailField.Caption = MediaPlanDetailField.Caption
                                    NewMediaPlanDetailField.IsVisible = MediaPlanDetailField.IsVisible
                                    NewMediaPlanDetailField.Index = MediaPlanDetailField.Index
                                    NewMediaPlanDetailField.Area = MediaPlanDetailField.Area
                                    NewMediaPlanDetailField.AreaIndex = MediaPlanDetailField.AreaIndex
                                    NewMediaPlanDetailField.SortOrder = MediaPlanDetailField.SortOrder
                                    NewMediaPlanDetailField.Width = MediaPlanDetailField.Width
                                    NewMediaPlanDetailField.ShowInGrandTotals = MediaPlanDetailField.ShowInGrandTotals
                                    NewMediaPlanDetailField.ShowInTotals = MediaPlanDetailField.ShowInTotals
                                    NewMediaPlanDetailField.ShowInValues = MediaPlanDetailField.ShowInValues

                                    NewMediaPlanDetailField.CreatedByUserCode = DbContext.UserCode
                                    NewMediaPlanDetailField.CreatedDate = Now
                                    NewMediaPlanDetailField.ModifiedByUserCode = Nothing
                                    NewMediaPlanDetailField.ModifiedDate = Nothing

                                    DbContext.MediaPlanDetailFields.Add(NewMediaPlanDetailField)

                                Next

                                For Each MediaPlanDetailPackageDetail In MediaPlanDetail.MediaPlanDetailPackageDetails.ToList

                                    NewMediaPlanDetailPackageDetail = New AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail

                                    NewMediaPlanDetailPackageDetail.MediaPlanDetailID = NewMediaPlanDetailID
                                    NewMediaPlanDetailPackageDetail.MediaPlanID = MediaPlanID
                                    NewMediaPlanDetailPackageDetail.RowIndex = MediaPlanDetailPackageDetail.RowIndex
                                    NewMediaPlanDetailPackageDetail.MediaType = MediaPlanDetailPackageDetail.MediaType
                                    NewMediaPlanDetailPackageDetail.SizeCode = MediaPlanDetailPackageDetail.SizeCode

                                    NewMediaPlanDetailPackageDetail.CreatedByUserCode = DbContext.UserCode
                                    NewMediaPlanDetailPackageDetail.CreatedDate = Now

                                    DbContext.MediaPlanDetailPackageDetails.Add(NewMediaPlanDetailPackageDetail)

                                Next

                                For Each MediaPlanDetailPackagePlacementName In MediaPlanDetail.MediaPlanDetailPackagePlacementNames.ToList

                                    NewMediaPlanDetailPackagePlacementName = New AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName

                                    NewMediaPlanDetailPackagePlacementName.MediaPlanDetailID = NewMediaPlanDetailID
                                    NewMediaPlanDetailPackagePlacementName.MediaPlanID = MediaPlanID
                                    NewMediaPlanDetailPackagePlacementName.RowIndex = MediaPlanDetailPackagePlacementName.RowIndex
                                    NewMediaPlanDetailPackagePlacementName.PlacementName = MediaPlanDetailPackagePlacementName.PlacementName

                                    NewMediaPlanDetailPackagePlacementName.CreatedByUserCode = DbContext.UserCode
                                    NewMediaPlanDetailPackagePlacementName.CreatedDate = Now

                                    DbContext.MediaPlanDetailPackagePlacementNames.Add(NewMediaPlanDetailPackagePlacementName)

                                Next

                                For Each MediaPlanDetailLevel In MediaPlanDetail.MediaPlanDetailLevels.ToList

                                    If MediaPlanDetailLevel.TagType <> AdvantageFramework.MediaPlanning.TagTypes.StartDate AndAlso
                                            MediaPlanDetailLevel.TagType <> AdvantageFramework.MediaPlanning.TagTypes.EndDate Then

                                        NewMediaPlanDetailLevel = New AdvantageFramework.Database.Entities.MediaPlanDetailLevel

                                        NewMediaPlanDetailLevel.MediaPlanDetailID = NewMediaPlanDetailID
                                        NewMediaPlanDetailLevel.MediaPlanID = MediaPlanID
                                        NewMediaPlanDetailLevel.Description = MediaPlanDetailLevel.Description
                                        NewMediaPlanDetailLevel.OrderNumber = MediaPlanDetailLevel.OrderNumber
                                        NewMediaPlanDetailLevel.Width = MediaPlanDetailLevel.Width
                                        NewMediaPlanDetailLevel.TagType = MediaPlanDetailLevel.TagType
                                        NewMediaPlanDetailLevel.MappingType = MediaPlanDetailLevel.MappingType
                                        NewMediaPlanDetailLevel.IsVisible = MediaPlanDetailLevel.IsVisible

                                        NewMediaPlanDetailLevel.CreatedByUserCode = DbContext.UserCode
                                        NewMediaPlanDetailLevel.CreatedDate = Now
                                        NewMediaPlanDetailLevel.ModifiedByUserCode = Nothing
                                        NewMediaPlanDetailLevel.ModifiedDate = Nothing

                                        DbContext.MediaPlanDetailLevels.Add(NewMediaPlanDetailLevel)

                                        For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.ToList

                                            NewMediaPlanDetailLevelLine = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine

                                            NewMediaPlanDetailLevelLine.MediaPlanDetailID = NewMediaPlanDetailID
                                            NewMediaPlanDetailLevelLine.MediaPlanID = MediaPlanID
                                            NewMediaPlanDetailLevelLine.MediaPlanDetailLevel = NewMediaPlanDetailLevel
                                            NewMediaPlanDetailLevelLine.Description = MediaPlanDetailLevelLine.Description
                                            NewMediaPlanDetailLevelLine.RowIndex = MediaPlanDetailLevelLine.RowIndex
                                            NewMediaPlanDetailLevelLine.Expanded = MediaPlanDetailLevelLine.Expanded
                                            NewMediaPlanDetailLevelLine.Color = MediaPlanDetailLevelLine.Color
                                            NewMediaPlanDetailLevelLine.IsCPM = MediaPlanDetailLevelLine.IsCPM
                                            NewMediaPlanDetailLevelLine.QuantityColumn = MediaPlanDetailLevelLine.QuantityColumn
                                            NewMediaPlanDetailLevelLine.PackageName = MediaPlanDetailLevelLine.PackageName

                                            NewMediaPlanDetailLevelLine.CreatedByUserCode = DbContext.UserCode
                                            NewMediaPlanDetailLevelLine.CreatedDate = Now
                                            NewMediaPlanDetailLevelLine.ModifiedByUserCode = Nothing
                                            NewMediaPlanDetailLevelLine.ModifiedDate = Nothing

                                            If NewMediaPlanDetailLevel.MediaPlanDetailLevelLines Is Nothing Then

                                                NewMediaPlanDetailLevel.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                                            End If

                                            NewMediaPlanDetailLevel.MediaPlanDetailLevelLines.Add(NewMediaPlanDetailLevelLine)

                                            DbContext.MediaPlanDetailLevelLines.Add(NewMediaPlanDetailLevelLine)

                                            For Each MediaPlanDetailLevelLineTag In MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.ToList

                                                NewMediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag

                                                NewMediaPlanDetailLevelLineTag.MediaPlanDetailID = NewMediaPlanDetailID
                                                NewMediaPlanDetailLevelLineTag.MediaPlanID = MediaPlanID
                                                NewMediaPlanDetailLevelLineTag.MediaPlanDetailLevelLine = NewMediaPlanDetailLevelLine
                                                NewMediaPlanDetailLevelLineTag.MarketCode = MediaPlanDetailLevelLineTag.MarketCode
                                                NewMediaPlanDetailLevelLineTag.VendorCode = MediaPlanDetailLevelLineTag.VendorCode

                                                NewMediaPlanDetailLevelLineTag.VendorCommission = Nothing
                                                NewMediaPlanDetailLevelLineTag.VendorMarkup = Nothing

                                                If String.IsNullOrWhiteSpace(NewMediaPlanDetailLevelLineTag.VendorCode) = False Then

                                                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, NewMediaPlanDetailLevelLineTag.VendorCode)

                                                    If Vendor IsNot Nothing Then

                                                        NewMediaPlanDetailLevelLineTag.VendorCommission = Vendor.Commission
                                                        NewMediaPlanDetailLevelLineTag.VendorMarkup = Vendor.Markup

                                                    End If

                                                End If

                                                NewMediaPlanDetailLevelLineTag.MediaType = MediaPlanDetailLevelLineTag.MediaType
                                                NewMediaPlanDetailLevelLineTag.SizeCode = MediaPlanDetailLevelLineTag.SizeCode
                                                NewMediaPlanDetailLevelLineTag.InternetTypeCode = MediaPlanDetailLevelLineTag.InternetTypeCode
                                                NewMediaPlanDetailLevelLineTag.DaypartID = MediaPlanDetailLevelLineTag.DaypartID
                                                NewMediaPlanDetailLevelLineTag.StartDate = MediaPlanDetailLevelLineTag.StartDate
                                                NewMediaPlanDetailLevelLineTag.EndDate = MediaPlanDetailLevelLineTag.EndDate
                                                NewMediaPlanDetailLevelLineTag.OutOfHomeTypeCode = MediaPlanDetailLevelLineTag.OutOfHomeTypeCode
                                                NewMediaPlanDetailLevelLineTag.AdNumber = MediaPlanDetailLevelLineTag.AdNumber
                                                NewMediaPlanDetailLevelLineTag.JobNumber = MediaPlanDetailLevelLineTag.JobNumber
                                                NewMediaPlanDetailLevelLineTag.JobComponentNumber = MediaPlanDetailLevelLineTag.JobComponentNumber
                                                NewMediaPlanDetailLevelLineTag.CampaignID = MediaPlanDetailLevelLineTag.CampaignID
                                                NewMediaPlanDetailLevelLineTag.MediaChannelID = MediaPlanDetailLevelLineTag.MediaChannelID
                                                NewMediaPlanDetailLevelLineTag.MediaTacticID = MediaPlanDetailLevelLineTag.MediaTacticID

                                                NewMediaPlanDetailLevelLineTag.CreatedByUserCode = DbContext.UserCode
                                                NewMediaPlanDetailLevelLineTag.CreatedDate = Now
                                                NewMediaPlanDetailLevelLineTag.ModifiedByUserCode = Nothing
                                                NewMediaPlanDetailLevelLineTag.ModifiedDate = Nothing

                                                If NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags Is Nothing Then

                                                    NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

                                                End If

                                                NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Add(NewMediaPlanDetailLevelLineTag)

                                                DbContext.MediaPlanDetailLevelLineTags.Add(NewMediaPlanDetailLevelLineTag)

                                            Next

                                        Next

                                    End If

                                Next

                                For Each MediaPlanDetailSetting In MediaPlanDetail.MediaPlanDetailSettings.ToList

                                    NewMediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                                    NewMediaPlanDetailSetting.MediaPlanDetailID = NewMediaPlanDetailID
                                    NewMediaPlanDetailSetting.MediaPlanID = MediaPlanID
                                    NewMediaPlanDetailSetting.Setting = MediaPlanDetailSetting.Setting
                                    NewMediaPlanDetailSetting.StringValue = MediaPlanDetailSetting.StringValue
                                    NewMediaPlanDetailSetting.NumericValue = MediaPlanDetailSetting.NumericValue
                                    NewMediaPlanDetailSetting.DateValue = MediaPlanDetailSetting.DateValue
                                    NewMediaPlanDetailSetting.BooleanValue = MediaPlanDetailSetting.BooleanValue

                                    NewMediaPlanDetailSetting.CreatedByUserCode = DbContext.UserCode
                                    NewMediaPlanDetailSetting.CreatedDate = Now
                                    NewMediaPlanDetailSetting.ModifiedByUserCode = Nothing
                                    NewMediaPlanDetailSetting.ModifiedDate = Nothing

                                    DbContext.MediaPlanDetailSettings.Add(NewMediaPlanDetailSetting)

                                Next

                                If NewMediaPlanDetail.MediaPlanDetailLevels IsNot Nothing Then

                                    VendorMediaPlanDetailLevel = NewMediaPlanDetail.MediaPlanDetailLevels.FirstOrDefault(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor)

                                End If

                                For Each MediaPlanDetailLevelLineData In MediaPlanDetail.MediaPlanDetailLevelLineDatas.ToList

                                    NewMediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

                                    NewMediaPlanDetailLevelLineData.MediaPlanDetailID = NewMediaPlanDetailID
                                    NewMediaPlanDetailLevelLineData.MediaPlanID = MediaPlanID
                                    NewMediaPlanDetailLevelLineData.StartDate = MediaPlanDetailLevelLineData.StartDate
                                    NewMediaPlanDetailLevelLineData.EndDate = MediaPlanDetailLevelLineData.EndDate
                                    NewMediaPlanDetailLevelLineData.Demo1 = MediaPlanDetailLevelLineData.Demo1
                                    NewMediaPlanDetailLevelLineData.Demo2 = MediaPlanDetailLevelLineData.Demo2
                                    NewMediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Dollars
                                    NewMediaPlanDetailLevelLineData.Units = MediaPlanDetailLevelLineData.Units
                                    NewMediaPlanDetailLevelLineData.Rate = MediaPlanDetailLevelLineData.Rate
                                    NewMediaPlanDetailLevelLineData.Note = MediaPlanDetailLevelLineData.Note
                                    NewMediaPlanDetailLevelLineData.Color = MediaPlanDetailLevelLineData.Color
                                    NewMediaPlanDetailLevelLineData.RowIndex = MediaPlanDetailLevelLineData.RowIndex
                                    NewMediaPlanDetailLevelLineData.Impressions = MediaPlanDetailLevelLineData.Impressions
                                    NewMediaPlanDetailLevelLineData.Clicks = MediaPlanDetailLevelLineData.Clicks
                                    NewMediaPlanDetailLevelLineData.AgencyFee = MediaPlanDetailLevelLineData.AgencyFee
                                    NewMediaPlanDetailLevelLineData.BillAmount = MediaPlanDetailLevelLineData.BillAmount
                                    NewMediaPlanDetailLevelLineData.NetCharge = MediaPlanDetailLevelLineData.NetCharge
                                    NewMediaPlanDetailLevelLineData.Columns = MediaPlanDetailLevelLineData.Columns
                                    NewMediaPlanDetailLevelLineData.InchesLines = MediaPlanDetailLevelLineData.InchesLines
                                    NewMediaPlanDetailLevelLineData.IsActualized = False

                                    NewMediaPlanDetailLevelLineData.Sunday = MediaPlanDetailLevelLineData.Sunday
                                    NewMediaPlanDetailLevelLineData.Monday = MediaPlanDetailLevelLineData.Monday
                                    NewMediaPlanDetailLevelLineData.Tuesday = MediaPlanDetailLevelLineData.Tuesday
                                    NewMediaPlanDetailLevelLineData.Wednesday = MediaPlanDetailLevelLineData.Wednesday
                                    NewMediaPlanDetailLevelLineData.Thursday = MediaPlanDetailLevelLineData.Thursday
                                    NewMediaPlanDetailLevelLineData.Friday = MediaPlanDetailLevelLineData.Friday
                                    NewMediaPlanDetailLevelLineData.Saturday = MediaPlanDetailLevelLineData.Saturday

                                    If VendorMediaPlanDetailLevel IsNot Nothing Then

                                        VendorMediaPlanDetailLevelLine = VendorMediaPlanDetailLevel.MediaPlanDetailLevelLines.FirstOrDefault(Function(Entity) Entity.RowIndex = NewMediaPlanDetailLevelLineData.RowIndex)

                                        If VendorMediaPlanDetailLevelLine IsNot Nothing Then

                                            VendorMediaPlanDetailLevelLineTag = VendorMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.FirstOrDefault(Function(Entity) Entity.MediaPlanDetailLevelLineID = VendorMediaPlanDetailLevelLine.ID)

                                        End If

                                        If VendorMediaPlanDetailLevelLineTag IsNot Nothing Then

                                            CalculateMediaPlanDetailLevelLineData(NewMediaPlanDetail.IsEstimateGrossAmount, VendorMediaPlanDetailLevelLineTag.VendorCommission, VendorMediaPlanDetailLevelLineTag.VendorMarkup,
                                                                                  ProductUsesNetAmount, ProductRebateAmount, ProductMarkupAmount, NewMediaPlanDetailLevelLineData)

                                        Else

                                            CalculateMediaPlanDetailLevelLineData(NewMediaPlanDetail.IsEstimateGrossAmount, Nothing, Nothing,
                                                                                  ProductUsesNetAmount, ProductRebateAmount, ProductMarkupAmount,
                                                                                  NewMediaPlanDetailLevelLineData)

                                        End If

                                    Else

                                        CalculateMediaPlanDetailLevelLineData(NewMediaPlanDetail.IsEstimateGrossAmount, Nothing, Nothing,
                                                                                  ProductUsesNetAmount, ProductRebateAmount, ProductMarkupAmount,
                                                                                  NewMediaPlanDetailLevelLineData)

                                    End If

                                    NewMediaPlanDetailLevelLineData.CreatedByUserCode = DbContext.UserCode
                                    NewMediaPlanDetailLevelLineData.CreatedDate = Now
                                    NewMediaPlanDetailLevelLineData.ModifiedByUserCode = Nothing
                                    NewMediaPlanDetailLevelLineData.ModifiedDate = Nothing

                                    DbContext.MediaPlanDetailLevelLineDatas.Add(NewMediaPlanDetailLevelLineData)

                                Next

                                Try

                                    DbContext.SaveChanges()

                                    Copied = True

                                Catch ex As Exception

                                End Try

                            Catch ex As Exception
                                Copied = False
                            End Try

                        End If

                    End If

                End If

                If Copied Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

                DbContext.Database.Connection.Close()

                If Copied = False Then

                    NewMediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, NewMediaPlanDetailID)

                    If NewMediaPlanDetail IsNot Nothing Then

                        AdvantageFramework.Database.Procedures.MediaPlanDetail.Delete(DbContext, NewMediaPlanDetail)

                    End If

                End If

            End If

            CopyMediaPlanDetail = Copied

        End Function
        Public Function CopyMediaPlan(ByVal Session As AdvantageFramework.Security.Session, ByVal MediaPlanID As Integer, ByRef NewMediaPlanID As Integer,
                                      DictionaryMediaPlanDetailIDs As Dictionary(Of Integer, String),
                                      Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim NewMediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim NewMediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim NewMediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim NewMediaPlanDetailPackageDetail As AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail = Nothing
            Dim NewMediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim NewMediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim NewMediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim NewMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim NewMediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing
            Dim ProductUsesNetAmount As Boolean = False
            Dim ProductRebateAmount As Decimal = 0
            Dim ProductMarkupAmount As Decimal = 0
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorMediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim VendorMediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim VendorMediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim IsNewCDP As Boolean = False
            Dim NewMediaPlanDetailPackagePlacementName As AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

                If MediaPlan IsNot Nothing Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        NewMediaPlan = MediaPlan.DuplicateEntity

                        If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                            NewMediaPlan.ClientCode = ClientCode
                            NewMediaPlan.DivisionCode = DivisionCode
                            NewMediaPlan.ProductCode = ProductCode

                            IsNewCDP = True

                        End If

                        Try

                            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, NewMediaPlan.ClientCode, NewMediaPlan.DivisionCode, NewMediaPlan.ProductCode)

                        Catch ex As Exception
                            Product = Nothing
                        End Try

                        NewMediaPlan.CampaignID = If(IsNewCDP, Nothing, MediaPlan.CampaignID)
                        'NewMediaPlan.IsApproved = False
                        'NewMediaPlan.ApprovedBy = Nothing
                        'NewMediaPlan.ApprovedDate = Nothing
                        NewMediaPlan.CreatedByUserCode = Session.UserCode
                        NewMediaPlan.CreatedDate = Now
                        NewMediaPlan.ModifiedByUserCode = Nothing
                        NewMediaPlan.ModifiedDate = Nothing
                        NewMediaPlan.IsTemplate = False

                        If AdvantageFramework.Database.Procedures.MediaPlan.Insert(DbContext, NewMediaPlan) Then

                            For Each MediaPlanDetail In MediaPlan.MediaPlanDetails.ToList

                                NewMediaPlanDetail = New AdvantageFramework.Database.Entities.MediaPlanDetail

                                NewMediaPlanDetail.DbContext = DbContext
                                NewMediaPlanDetail.MediaPlanID = MediaPlanDetail.MediaPlanID
                                NewMediaPlanDetail.SalesClassType = MediaPlanDetail.SalesClassType

                                If DictionaryMediaPlanDetailIDs IsNot Nothing AndAlso DictionaryMediaPlanDetailIDs.ContainsKey(MediaPlanDetail.ID) Then

                                    NewMediaPlanDetail.SalesClassCode = DictionaryMediaPlanDetailIDs.Item(MediaPlanDetail.ID)

                                Else

                                    NewMediaPlanDetail.SalesClassCode = MediaPlanDetail.SalesClassCode

                                End If

                                NewMediaPlanDetail.IsEstimateGrossAmount = MediaPlanDetail.IsEstimateGrossAmount
                                NewMediaPlanDetail.IsCalendarMonth = MediaPlanDetail.IsCalendarMonth
                                NewMediaPlanDetail.Color = MediaPlanDetail.Color
                                NewMediaPlanDetail.Notes = MediaPlanDetail.Notes
                                NewMediaPlanDetail.CreatedByUserCode = DbContext.UserCode
                                NewMediaPlanDetail.CreatedDate = Now
                                NewMediaPlanDetail.ModifiedByUserCode = Nothing
                                NewMediaPlanDetail.ModifiedDate = Nothing
                                NewMediaPlanDetail.CalculateDollars = MediaPlanDetail.CalculateDollars
                                NewMediaPlanDetail.ShowColumnTotals = MediaPlanDetail.ShowColumnTotals
                                NewMediaPlanDetail.ShowRowTotals = MediaPlanDetail.ShowRowTotals
                                NewMediaPlanDetail.CampaignID = If(IsNewCDP, Nothing, MediaPlanDetail.CampaignID)
                                NewMediaPlanDetail.ShowRowGrandTotals = MediaPlanDetail.ShowRowGrandTotals
                                NewMediaPlanDetail.ShowColumnGrandTotals = MediaPlanDetail.ShowColumnGrandTotals
                                NewMediaPlanDetail.Name = MediaPlanDetail.Name
                                NewMediaPlanDetail.IsApproved = False
                                NewMediaPlanDetail.ApprovedBy = Nothing
                                NewMediaPlanDetail.ApprovedDate = Nothing
                                NewMediaPlanDetail.SplitWeeks = MediaPlanDetail.SplitWeeks
                                NewMediaPlanDetail.OrderGrouping = 0
                                NewMediaPlanDetail.OrderNumber = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).Count + 1
                                NewMediaPlanDetail.BuyerEmployeeCode = MediaPlanDetail.BuyerEmployeeCode
                                NewMediaPlanDetail.GrossBudgetAmount = MediaPlanDetail.GrossBudgetAmount
                                NewMediaPlanDetail.IsCable = MediaPlanDetail.IsCable
                                NewMediaPlanDetail.CreateOrderOption = MediaPlanDetail.CreateOrderOption
                                NewMediaPlanDetail.ShowRowTotalsValues = MediaPlanDetail.ShowRowTotalsValues
                                NewMediaPlanDetail.ShowRowGrandTotalsValues = MediaPlanDetail.ShowRowGrandTotalsValues
                                NewMediaPlanDetail.AllowCampaignLevel = MediaPlanDetail.AllowCampaignLevel

                                If MediaPlanDetail.PeriodType = 0 Then

                                    If NewMediaPlanDetail.SalesClassType = "O" Then

                                        NewMediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week

                                    ElseIf NewMediaPlanDetail.SalesClassType = "R" AndAlso MediaPlanDetail.SalesClassType = "T" Then

                                        NewMediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None

                                    ElseIf NewMediaPlanDetail.SalesClassType = "I" Then

                                        NewMediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month

                                    ElseIf NewMediaPlanDetail.SalesClassType = "N" Then

                                        NewMediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Day

                                    Else

                                        NewMediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month

                                    End If

                                Else

                                    NewMediaPlanDetail.PeriodType = MediaPlanDetail.PeriodType

                                End If

                                If NewMediaPlan.MediaPlanDetails Is Nothing Then

                                    NewMediaPlan.MediaPlanDetails = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetail)

                                End If

                                NewMediaPlan.MediaPlanDetails.Add(NewMediaPlanDetail)

                                If Product IsNot Nothing Then

                                    Try

                                        ProductMediaOverrides = AdvantageFramework.Database.Procedures.ProductMediaOverrides.LoadByClientDivisionProduct(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code).SingleOrDefault(Function(Entity) Entity.MediaType = NewMediaPlanDetail.SalesClassType AndAlso Entity.SalesClassCode = NewMediaPlanDetail.SalesClassCode)

                                    Catch ex As Exception
                                        ProductMediaOverrides = Nothing
                                    End Try

                                    If ProductMediaOverrides IsNot Nothing Then

                                        If NewMediaPlanDetail.SalesClassType = "R" Then

                                            If Product.RadioBillNet = 1 Then

                                                ProductUsesNetAmount = True

                                            Else

                                                ProductUsesNetAmount = False

                                            End If

                                        ElseIf NewMediaPlanDetail.SalesClassType = "T" Then

                                            If Product.TelevisionBillNet = 1 Then

                                                ProductUsesNetAmount = True

                                            Else

                                                ProductUsesNetAmount = False

                                            End If

                                        ElseIf NewMediaPlanDetail.SalesClassType = "M" Then

                                            If Product.MagazineBillNet = 1 Then

                                                ProductUsesNetAmount = True

                                            Else

                                                ProductUsesNetAmount = False

                                            End If

                                        ElseIf NewMediaPlanDetail.SalesClassType = "O" Then

                                            If Product.OutOfHomeBillNet = 1 Then

                                                ProductUsesNetAmount = True

                                            Else

                                                ProductUsesNetAmount = False

                                            End If

                                        ElseIf NewMediaPlanDetail.SalesClassType = "I" Then

                                            If Product.InternetBillNet = 1 Then

                                                ProductUsesNetAmount = True

                                            Else

                                                ProductUsesNetAmount = False

                                            End If

                                        ElseIf NewMediaPlanDetail.SalesClassType = "N" Then

                                            If Product.NewspaperBillNet = 1 Then

                                                ProductUsesNetAmount = True

                                            Else

                                                ProductUsesNetAmount = False

                                            End If

                                        End If

                                        ProductRebateAmount = ProductMediaOverrides.RebatePercent.GetValueOrDefault(0)
                                        ProductMarkupAmount = ProductMediaOverrides.MarkupPercent.GetValueOrDefault(0)

                                    Else

                                        If NewMediaPlanDetail.SalesClassType = "R" Then

                                            If Product.RadioBillNet = 1 Then

                                                ProductUsesNetAmount = True
                                                ProductRebateAmount = 0
                                                ProductMarkupAmount = 0

                                            Else

                                                ProductUsesNetAmount = False
                                                ProductRebateAmount = Product.RadioRebate.GetValueOrDefault(0)
                                                ProductMarkupAmount = Product.RadioMarkup.GetValueOrDefault(0)

                                            End If

                                        ElseIf NewMediaPlanDetail.SalesClassType = "T" Then

                                            If Product.TelevisionBillNet = 1 Then

                                                ProductUsesNetAmount = True
                                                ProductRebateAmount = 0
                                                ProductMarkupAmount = 0

                                            Else

                                                ProductUsesNetAmount = False
                                                ProductRebateAmount = Product.TelevisionRebate.GetValueOrDefault(0)
                                                ProductMarkupAmount = Product.TelevisionMarkup.GetValueOrDefault(0)

                                            End If

                                        ElseIf NewMediaPlanDetail.SalesClassType = "M" Then

                                            If Product.MagazineBillNet = 1 Then

                                                ProductUsesNetAmount = True
                                                ProductRebateAmount = 0
                                                ProductMarkupAmount = 0

                                            Else

                                                ProductUsesNetAmount = False
                                                ProductRebateAmount = Product.MagazineRebate.GetValueOrDefault(0)
                                                ProductMarkupAmount = Product.MagazineMarkup.GetValueOrDefault(0)

                                            End If

                                        ElseIf NewMediaPlanDetail.SalesClassType = "O" Then

                                            If Product.OutOfHomeBillNet = 1 Then

                                                ProductUsesNetAmount = True
                                                ProductRebateAmount = 0
                                                ProductMarkupAmount = 0

                                            Else

                                                ProductUsesNetAmount = False
                                                ProductRebateAmount = Product.OutOfHomeRebate.GetValueOrDefault(0)
                                                ProductMarkupAmount = Product.OutOfHomeMarkup.GetValueOrDefault(0)

                                            End If

                                        ElseIf NewMediaPlanDetail.SalesClassType = "I" Then

                                            If Product.InternetBillNet = 1 Then

                                                ProductUsesNetAmount = True
                                                ProductRebateAmount = 0
                                                ProductMarkupAmount = 0

                                            Else

                                                ProductUsesNetAmount = False
                                                ProductRebateAmount = Product.InternetRebate.GetValueOrDefault(0)
                                                ProductMarkupAmount = Product.InternetMarkup.GetValueOrDefault(0)

                                            End If

                                        ElseIf NewMediaPlanDetail.SalesClassType = "N" Then

                                            If Product.NewspaperBillNet = 1 Then

                                                ProductUsesNetAmount = True
                                                ProductRebateAmount = 0
                                                ProductMarkupAmount = 0

                                            Else

                                                ProductUsesNetAmount = False
                                                ProductRebateAmount = Product.NewspaperRebate.GetValueOrDefault(0)
                                                ProductMarkupAmount = Product.NewspaperMarkup.GetValueOrDefault(0)

                                            End If

                                        Else

                                            ProductUsesNetAmount = True
                                            ProductRebateAmount = 0
                                            ProductMarkupAmount = 0

                                        End If

                                    End If

                                End If

                                For Each MediaPlanDetailField In MediaPlanDetail.MediaPlanDetailFields.ToList

                                    NewMediaPlanDetailField = New AdvantageFramework.Database.Entities.MediaPlanDetailField

                                    NewMediaPlanDetailField.MediaPlanDetailID = NewMediaPlanDetail.ID
                                    NewMediaPlanDetailField.MediaPlanID = NewMediaPlan.ID
                                    NewMediaPlanDetailField.FieldID = MediaPlanDetailField.FieldID
                                    NewMediaPlanDetailField.Caption = MediaPlanDetailField.Caption
                                    NewMediaPlanDetailField.IsVisible = MediaPlanDetailField.IsVisible
                                    NewMediaPlanDetailField.Index = MediaPlanDetailField.Index
                                    NewMediaPlanDetailField.Area = MediaPlanDetailField.Area
                                    NewMediaPlanDetailField.AreaIndex = MediaPlanDetailField.AreaIndex
                                    NewMediaPlanDetailField.SortOrder = MediaPlanDetailField.SortOrder
                                    NewMediaPlanDetailField.Width = MediaPlanDetailField.Width
                                    NewMediaPlanDetailField.ShowInGrandTotals = MediaPlanDetailField.ShowInGrandTotals
                                    NewMediaPlanDetailField.ShowInTotals = MediaPlanDetailField.ShowInTotals
                                    NewMediaPlanDetailField.ShowInValues = MediaPlanDetailField.ShowInValues

                                    NewMediaPlanDetailField.CreatedByUserCode = DbContext.UserCode
                                    NewMediaPlanDetailField.CreatedDate = Now
                                    NewMediaPlanDetailField.ModifiedByUserCode = Nothing
                                    NewMediaPlanDetailField.ModifiedDate = Nothing

                                    If NewMediaPlan.MediaPlanDetailFields Is Nothing Then

                                        NewMediaPlan.MediaPlanDetailFields = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailField)

                                    End If

                                    If NewMediaPlanDetail.MediaPlanDetailFields Is Nothing Then

                                        NewMediaPlanDetail.MediaPlanDetailFields = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailField)

                                    End If

                                    NewMediaPlan.MediaPlanDetailFields.Add(NewMediaPlanDetailField)
                                    NewMediaPlanDetail.MediaPlanDetailFields.Add(NewMediaPlanDetailField)

                                Next

                                For Each MediaPlanDetailPackageDetail In MediaPlanDetail.MediaPlanDetailPackageDetails.ToList

                                    NewMediaPlanDetailPackageDetail = New AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail

                                    NewMediaPlanDetailPackageDetail.MediaPlanDetailID = NewMediaPlanDetail.ID
                                    NewMediaPlanDetailPackageDetail.MediaPlanID = NewMediaPlan.ID
                                    NewMediaPlanDetailPackageDetail.RowIndex = MediaPlanDetailPackageDetail.RowIndex
                                    NewMediaPlanDetailPackageDetail.MediaType = MediaPlanDetailPackageDetail.MediaType
                                    NewMediaPlanDetailPackageDetail.SizeCode = MediaPlanDetailPackageDetail.SizeCode

                                    NewMediaPlanDetailPackageDetail.CreatedByUserCode = DbContext.UserCode
                                    NewMediaPlanDetailPackageDetail.CreatedDate = Now

                                    If NewMediaPlan.MediaPlanDetailPackageDetails Is Nothing Then

                                        NewMediaPlan.MediaPlanDetailPackageDetails = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail)

                                    End If

                                    If NewMediaPlanDetail.MediaPlanDetailPackageDetails Is Nothing Then

                                        NewMediaPlanDetail.MediaPlanDetailPackageDetails = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail)

                                    End If

                                    NewMediaPlan.MediaPlanDetailPackageDetails.Add(NewMediaPlanDetailPackageDetail)
                                    NewMediaPlanDetail.MediaPlanDetailPackageDetails.Add(NewMediaPlanDetailPackageDetail)

                                Next

                                For Each MediaPlanDetailPackagePlacementName In MediaPlanDetail.MediaPlanDetailPackagePlacementNames.ToList

                                    NewMediaPlanDetailPackagePlacementName = New AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName

                                    NewMediaPlanDetailPackagePlacementName.MediaPlanDetailID = NewMediaPlanDetail.ID
                                    NewMediaPlanDetailPackagePlacementName.MediaPlanID = NewMediaPlan.ID
                                    NewMediaPlanDetailPackagePlacementName.RowIndex = MediaPlanDetailPackagePlacementName.RowIndex
                                    NewMediaPlanDetailPackagePlacementName.PlacementName = MediaPlanDetailPackagePlacementName.PlacementName

                                    NewMediaPlanDetailPackagePlacementName.CreatedByUserCode = DbContext.UserCode
                                    NewMediaPlanDetailPackagePlacementName.CreatedDate = Now

                                    If NewMediaPlan.MediaPlanDetailPackagePlacementNames Is Nothing Then

                                        NewMediaPlan.MediaPlanDetailPackagePlacementNames = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName)

                                    End If

                                    If NewMediaPlanDetail.MediaPlanDetailPackagePlacementNames Is Nothing Then

                                        NewMediaPlanDetail.MediaPlanDetailPackagePlacementNames = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName)

                                    End If

                                    NewMediaPlan.MediaPlanDetailPackagePlacementNames.Add(NewMediaPlanDetailPackagePlacementName)
                                    NewMediaPlanDetail.MediaPlanDetailPackagePlacementNames.Add(NewMediaPlanDetailPackagePlacementName)

                                Next

                                For Each MediaPlanDetailLevel In MediaPlanDetail.MediaPlanDetailLevels.ToList

                                    If MediaPlanDetailLevel.TagType <> AdvantageFramework.MediaPlanning.TagTypes.StartDate AndAlso
                                            MediaPlanDetailLevel.TagType <> AdvantageFramework.MediaPlanning.TagTypes.EndDate Then

                                        NewMediaPlanDetailLevel = New AdvantageFramework.Database.Entities.MediaPlanDetailLevel

                                        NewMediaPlanDetailLevel.MediaPlanDetailID = NewMediaPlanDetail.ID
                                        NewMediaPlanDetailLevel.MediaPlanID = NewMediaPlan.ID
                                        NewMediaPlanDetailLevel.Description = MediaPlanDetailLevel.Description
                                        NewMediaPlanDetailLevel.OrderNumber = MediaPlanDetailLevel.OrderNumber
                                        NewMediaPlanDetailLevel.Width = MediaPlanDetailLevel.Width
                                        NewMediaPlanDetailLevel.TagType = MediaPlanDetailLevel.TagType
                                        NewMediaPlanDetailLevel.MappingType = MediaPlanDetailLevel.MappingType
                                        NewMediaPlanDetailLevel.IsVisible = MediaPlanDetailLevel.IsVisible

                                        NewMediaPlanDetailLevel.CreatedByUserCode = DbContext.UserCode
                                        NewMediaPlanDetailLevel.CreatedDate = Now
                                        NewMediaPlanDetailLevel.ModifiedByUserCode = Nothing
                                        NewMediaPlanDetailLevel.ModifiedDate = Nothing

                                        If NewMediaPlan.MediaPlanDetailLevels Is Nothing Then

                                            NewMediaPlan.MediaPlanDetailLevels = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel)

                                        End If

                                        If NewMediaPlanDetail.MediaPlanDetailLevels Is Nothing Then

                                            NewMediaPlanDetail.MediaPlanDetailLevels = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel)

                                        End If

                                        NewMediaPlan.MediaPlanDetailLevels.Add(NewMediaPlanDetailLevel)
                                        NewMediaPlanDetail.MediaPlanDetailLevels.Add(NewMediaPlanDetailLevel)

                                        For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.ToList

                                            NewMediaPlanDetailLevelLine = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine

                                            NewMediaPlanDetailLevelLine.MediaPlanDetailID = NewMediaPlanDetail.ID
                                            NewMediaPlanDetailLevelLine.MediaPlanID = NewMediaPlan.ID

                                            If MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.Campaign Then

                                                NewMediaPlanDetailLevelLine.Description = If(IsNewCDP, String.Empty, MediaPlanDetailLevelLine.Description)

                                            Else

                                                NewMediaPlanDetailLevelLine.Description = MediaPlanDetailLevelLine.Description

                                            End If

                                            NewMediaPlanDetailLevelLine.RowIndex = MediaPlanDetailLevelLine.RowIndex
                                            NewMediaPlanDetailLevelLine.Expanded = MediaPlanDetailLevelLine.Expanded
                                            NewMediaPlanDetailLevelLine.Color = MediaPlanDetailLevelLine.Color
                                            NewMediaPlanDetailLevelLine.IsCPM = MediaPlanDetailLevelLine.IsCPM
                                            NewMediaPlanDetailLevelLine.QuantityColumn = MediaPlanDetailLevelLine.QuantityColumn
                                            NewMediaPlanDetailLevelLine.PackageName = MediaPlanDetailLevelLine.PackageName

                                            NewMediaPlanDetailLevelLine.CreatedByUserCode = DbContext.UserCode
                                            NewMediaPlanDetailLevelLine.CreatedDate = Now
                                            NewMediaPlanDetailLevelLine.ModifiedByUserCode = Nothing
                                            NewMediaPlanDetailLevelLine.ModifiedDate = Nothing

                                            If NewMediaPlanDetailLevel.MediaPlanDetailLevelLines Is Nothing Then

                                                NewMediaPlanDetailLevel.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                                            End If

                                            If NewMediaPlan.MediaPlanDetailLevelLines Is Nothing Then

                                                NewMediaPlan.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                                            End If

                                            If NewMediaPlanDetail.MediaPlanDetailLevelLines Is Nothing Then

                                                NewMediaPlanDetail.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                                            End If

                                            NewMediaPlanDetailLevel.MediaPlanDetailLevelLines.Add(NewMediaPlanDetailLevelLine)
                                            NewMediaPlan.MediaPlanDetailLevelLines.Add(NewMediaPlanDetailLevelLine)
                                            NewMediaPlanDetail.MediaPlanDetailLevelLines.Add(NewMediaPlanDetailLevelLine)

                                            For Each MediaPlanDetailLevelLineTag In MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.ToList

                                                NewMediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag

                                                NewMediaPlanDetailLevelLineTag.MediaPlanDetailID = NewMediaPlanDetail.ID
                                                NewMediaPlanDetailLevelLineTag.MediaPlanID = NewMediaPlan.ID
                                                NewMediaPlanDetailLevelLineTag.MarketCode = MediaPlanDetailLevelLineTag.MarketCode
                                                NewMediaPlanDetailLevelLineTag.VendorCode = MediaPlanDetailLevelLineTag.VendorCode

                                                NewMediaPlanDetailLevelLineTag.VendorCommission = Nothing
                                                NewMediaPlanDetailLevelLineTag.VendorMarkup = Nothing

                                                If String.IsNullOrWhiteSpace(NewMediaPlanDetailLevelLineTag.VendorCode) = False Then

                                                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, NewMediaPlanDetailLevelLineTag.VendorCode)

                                                    If Vendor IsNot Nothing Then

                                                        NewMediaPlanDetailLevelLineTag.VendorCommission = Vendor.Commission
                                                        NewMediaPlanDetailLevelLineTag.VendorMarkup = Vendor.Markup

                                                    End If

                                                End If

                                                NewMediaPlanDetailLevelLineTag.MediaType = MediaPlanDetailLevelLineTag.MediaType
                                                NewMediaPlanDetailLevelLineTag.SizeCode = MediaPlanDetailLevelLineTag.SizeCode
                                                NewMediaPlanDetailLevelLineTag.InternetTypeCode = MediaPlanDetailLevelLineTag.InternetTypeCode
                                                NewMediaPlanDetailLevelLineTag.DaypartID = MediaPlanDetailLevelLineTag.DaypartID
                                                NewMediaPlanDetailLevelLineTag.StartDate = MediaPlanDetailLevelLineTag.StartDate
                                                NewMediaPlanDetailLevelLineTag.EndDate = MediaPlanDetailLevelLineTag.EndDate
                                                NewMediaPlanDetailLevelLineTag.OutOfHomeTypeCode = MediaPlanDetailLevelLineTag.OutOfHomeTypeCode
                                                NewMediaPlanDetailLevelLineTag.AdNumber = MediaPlanDetailLevelLineTag.AdNumber
                                                NewMediaPlanDetailLevelLineTag.JobNumber = MediaPlanDetailLevelLineTag.JobNumber
                                                NewMediaPlanDetailLevelLineTag.JobComponentNumber = MediaPlanDetailLevelLineTag.JobComponentNumber
                                                NewMediaPlanDetailLevelLineTag.CampaignID = If(IsNewCDP, Nothing, MediaPlanDetailLevelLineTag.CampaignID)
                                                NewMediaPlanDetailLevelLineTag.MediaChannelID = MediaPlanDetailLevelLineTag.MediaChannelID
                                                NewMediaPlanDetailLevelLineTag.MediaTacticID = MediaPlanDetailLevelLineTag.MediaTacticID

                                                NewMediaPlanDetailLevelLineTag.CreatedByUserCode = DbContext.UserCode
                                                NewMediaPlanDetailLevelLineTag.CreatedDate = Now
                                                NewMediaPlanDetailLevelLineTag.ModifiedByUserCode = Nothing
                                                NewMediaPlanDetailLevelLineTag.ModifiedDate = Nothing

                                                If NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags Is Nothing Then

                                                    NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

                                                End If

                                                If NewMediaPlan.MediaPlanDetailLevelLineTags Is Nothing Then

                                                    NewMediaPlan.MediaPlanDetailLevelLineTags = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

                                                End If

                                                If NewMediaPlanDetail.MediaPlanDetailLevelLineTags Is Nothing Then

                                                    NewMediaPlanDetail.MediaPlanDetailLevelLineTags = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)

                                                End If

                                                NewMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Add(NewMediaPlanDetailLevelLineTag)
                                                NewMediaPlan.MediaPlanDetailLevelLineTags.Add(NewMediaPlanDetailLevelLineTag)
                                                NewMediaPlanDetail.MediaPlanDetailLevelLineTags.Add(NewMediaPlanDetailLevelLineTag)

                                            Next

                                        Next

                                    End If

                                Next

                                If NewMediaPlanDetail.MediaPlanDetailLevels IsNot Nothing Then

                                    VendorMediaPlanDetailLevel = NewMediaPlanDetail.MediaPlanDetailLevels.FirstOrDefault(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor)

                                End If

                                For Each MediaPlanDetailLevelLineData In MediaPlanDetail.MediaPlanDetailLevelLineDatas.ToList

                                    NewMediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

                                    NewMediaPlanDetailLevelLineData.MediaPlanDetailID = NewMediaPlanDetail.ID
                                    NewMediaPlanDetailLevelLineData.MediaPlanID = NewMediaPlan.ID
                                    NewMediaPlanDetailLevelLineData.StartDate = MediaPlanDetailLevelLineData.StartDate
                                    NewMediaPlanDetailLevelLineData.EndDate = MediaPlanDetailLevelLineData.EndDate
                                    NewMediaPlanDetailLevelLineData.Demo1 = MediaPlanDetailLevelLineData.Demo1
                                    NewMediaPlanDetailLevelLineData.Demo2 = MediaPlanDetailLevelLineData.Demo2
                                    NewMediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Dollars
                                    NewMediaPlanDetailLevelLineData.Units = MediaPlanDetailLevelLineData.Units
                                    NewMediaPlanDetailLevelLineData.Rate = MediaPlanDetailLevelLineData.Rate
                                    NewMediaPlanDetailLevelLineData.Note = MediaPlanDetailLevelLineData.Note
                                    NewMediaPlanDetailLevelLineData.Color = MediaPlanDetailLevelLineData.Color
                                    NewMediaPlanDetailLevelLineData.RowIndex = MediaPlanDetailLevelLineData.RowIndex
                                    NewMediaPlanDetailLevelLineData.Impressions = MediaPlanDetailLevelLineData.Impressions
                                    NewMediaPlanDetailLevelLineData.Clicks = MediaPlanDetailLevelLineData.Clicks
                                    NewMediaPlanDetailLevelLineData.AgencyFee = MediaPlanDetailLevelLineData.AgencyFee
                                    NewMediaPlanDetailLevelLineData.BillAmount = MediaPlanDetailLevelLineData.BillAmount
                                    NewMediaPlanDetailLevelLineData.NetCharge = MediaPlanDetailLevelLineData.NetCharge
                                    NewMediaPlanDetailLevelLineData.Columns = MediaPlanDetailLevelLineData.Columns
                                    NewMediaPlanDetailLevelLineData.InchesLines = MediaPlanDetailLevelLineData.InchesLines
                                    NewMediaPlanDetailLevelLineData.IsActualized = False

                                    NewMediaPlanDetailLevelLineData.Sunday = MediaPlanDetailLevelLineData.Sunday
                                    NewMediaPlanDetailLevelLineData.Monday = MediaPlanDetailLevelLineData.Monday
                                    NewMediaPlanDetailLevelLineData.Tuesday = MediaPlanDetailLevelLineData.Tuesday
                                    NewMediaPlanDetailLevelLineData.Wednesday = MediaPlanDetailLevelLineData.Wednesday
                                    NewMediaPlanDetailLevelLineData.Thursday = MediaPlanDetailLevelLineData.Thursday
                                    NewMediaPlanDetailLevelLineData.Friday = MediaPlanDetailLevelLineData.Friday
                                    NewMediaPlanDetailLevelLineData.Saturday = MediaPlanDetailLevelLineData.Saturday

                                    NewMediaPlanDetailLevelLineData.CreatedByUserCode = DbContext.UserCode
                                    NewMediaPlanDetailLevelLineData.CreatedDate = Now
                                    NewMediaPlanDetailLevelLineData.ModifiedByUserCode = Nothing
                                    NewMediaPlanDetailLevelLineData.ModifiedDate = Nothing

                                    If VendorMediaPlanDetailLevel IsNot Nothing AndAlso VendorMediaPlanDetailLevel.MediaPlanDetailLevelLines IsNot Nothing Then

                                        VendorMediaPlanDetailLevelLine = VendorMediaPlanDetailLevel.MediaPlanDetailLevelLines.FirstOrDefault(Function(Entity) Entity.RowIndex = NewMediaPlanDetailLevelLineData.RowIndex)

                                        VendorMediaPlanDetailLevelLineTag = Nothing

                                        If VendorMediaPlanDetailLevelLine IsNot Nothing AndAlso VendorMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing Then

                                            VendorMediaPlanDetailLevelLineTag = VendorMediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.FirstOrDefault(Function(Entity) Entity.MediaPlanDetailLevelLineID = VendorMediaPlanDetailLevelLine.ID)

                                        End If

                                        If VendorMediaPlanDetailLevelLineTag IsNot Nothing Then

                                            CalculateMediaPlanDetailLevelLineData(NewMediaPlanDetail.IsEstimateGrossAmount, VendorMediaPlanDetailLevelLineTag.VendorCommission, VendorMediaPlanDetailLevelLineTag.VendorMarkup,
                                                                              ProductUsesNetAmount, ProductRebateAmount, ProductMarkupAmount, NewMediaPlanDetailLevelLineData)

                                        Else

                                            CalculateMediaPlanDetailLevelLineData(NewMediaPlanDetail.IsEstimateGrossAmount, Nothing, Nothing,
                                                                              ProductUsesNetAmount, ProductRebateAmount, ProductMarkupAmount,
                                                                              NewMediaPlanDetailLevelLineData)

                                        End If

                                    Else

                                        CalculateMediaPlanDetailLevelLineData(NewMediaPlanDetail.IsEstimateGrossAmount, Nothing, Nothing,
                                                                              ProductUsesNetAmount, ProductRebateAmount, ProductMarkupAmount,
                                                                              NewMediaPlanDetailLevelLineData)

                                    End If

                                    If NewMediaPlan.MediaPlanDetailLevelLineDatas Is Nothing Then

                                        NewMediaPlan.MediaPlanDetailLevelLineDatas = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

                                    End If

                                    If NewMediaPlanDetail.MediaPlanDetailLevelLineDatas Is Nothing Then

                                        NewMediaPlanDetail.MediaPlanDetailLevelLineDatas = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

                                    End If

                                    NewMediaPlan.MediaPlanDetailLevelLineDatas.Add(NewMediaPlanDetailLevelLineData)
                                    NewMediaPlanDetail.MediaPlanDetailLevelLineDatas.Add(NewMediaPlanDetailLevelLineData)

                                Next

                                For Each MediaPlanDetailSetting In MediaPlanDetail.MediaPlanDetailSettings.ToList

                                    NewMediaPlanDetailSetting = New AdvantageFramework.Database.Entities.MediaPlanDetailSetting

                                    NewMediaPlanDetailSetting.MediaPlanDetailID = NewMediaPlanDetail.ID
                                    NewMediaPlanDetailSetting.MediaPlanID = NewMediaPlan.ID
                                    NewMediaPlanDetailSetting.Setting = MediaPlanDetailSetting.Setting
                                    NewMediaPlanDetailSetting.StringValue = MediaPlanDetailSetting.StringValue
                                    NewMediaPlanDetailSetting.NumericValue = MediaPlanDetailSetting.NumericValue
                                    NewMediaPlanDetailSetting.DateValue = MediaPlanDetailSetting.DateValue
                                    NewMediaPlanDetailSetting.BooleanValue = MediaPlanDetailSetting.BooleanValue

                                    If Product IsNot Nothing Then

                                        If NewMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ProductUsesNetAmount.ToString Then

                                            NewMediaPlanDetailSetting.BooleanValue = ProductUsesNetAmount

                                        ElseIf NewMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ProductMarkupAmount.ToString Then

                                            NewMediaPlanDetailSetting.NumericValue = ProductMarkupAmount

                                        ElseIf NewMediaPlanDetailSetting.Setting = AdvantageFramework.MediaPlanning.Settings.ProductRebateAmount.ToString Then

                                            NewMediaPlanDetailSetting.NumericValue = ProductRebateAmount

                                        End If

                                    End If

                                    NewMediaPlanDetailSetting.CreatedByUserCode = DbContext.UserCode
                                    NewMediaPlanDetailSetting.CreatedDate = Now
                                    NewMediaPlanDetailSetting.ModifiedByUserCode = Nothing
                                    NewMediaPlanDetailSetting.ModifiedDate = Nothing

                                    If NewMediaPlan.MediaPlanDetailSettings Is Nothing Then

                                        NewMediaPlan.MediaPlanDetailSettings = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailSetting)

                                    End If

                                    If NewMediaPlanDetail.MediaPlanDetailSettings Is Nothing Then

                                        NewMediaPlanDetail.MediaPlanDetailSettings = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailSetting)

                                    End If

                                    NewMediaPlan.MediaPlanDetailSettings.Add(NewMediaPlanDetailSetting)
                                    NewMediaPlanDetail.MediaPlanDetailSettings.Add(NewMediaPlanDetailSetting)

                                Next

                            Next

                            Try

                                DbContext.SaveChanges()

                                Copied = True

                            Catch ex As Exception

                            End Try

                        End If

                    Catch ex As Exception
                        Copied = False
                    End Try

                    If Copied Then

                        DbTransaction.Commit()

                        NewMediaPlanID = NewMediaPlan.ID

                    Else

                        DbTransaction.Rollback()

                    End If

                    DbContext.Database.Connection.Close()

                End If

            End Using

            CopyMediaPlan = Copied

        End Function
        Public Sub FillMediaPlanDetailLevelLineDataForAutoCalculate(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate,
                                                                    ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            'objects
            Dim HasRate As Boolean = False
            Dim HasDollars As Boolean = False
            Dim QuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.ID
            Dim QuantityDataColumns As Generic.List(Of System.Data.DataColumn) = Nothing
            Dim FirstVisibleQuantityColumn As System.Data.DataColumn = Nothing

            HasRate = (MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0) <> 0)
            HasDollars = (MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) <> 0)

            If HasDollars AndAlso HasRate Then

                If MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Units.HasValue = False OrElse MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0) = 0 Then

                        If MediaPlanEstimate.CheckForUnitsCPM(MediaPlanDetailLevelLineData.RowIndex) Then

                            MediaPlanDetailLevelLineData.Units = FormatNumber(CDec(((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)), 1)

                        Else

                            MediaPlanDetailLevelLineData.Units = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 1)

                        End If

                    End If

                ElseIf MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Impressions.HasValue = False OrElse MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0) = 0 Then

                        If MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanDetailLevelLineData.RowIndex) Then

                            MediaPlanDetailLevelLineData.Impressions = FormatNumber(CDec(((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)), 1)

                        Else

                            MediaPlanDetailLevelLineData.Impressions = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 1)

                        End If

                    End If

                ElseIf MediaPlanEstimate.CheckForClicksQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Clicks.HasValue = False OrElse MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0) = 0 Then

                        If MediaPlanEstimate.CheckForClicksCPM(MediaPlanDetailLevelLineData.RowIndex) Then

                            MediaPlanDetailLevelLineData.Clicks = FormatNumber(CDec(((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)), 1)

                        Else

                            MediaPlanDetailLevelLineData.Clicks = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 1)

                        End If

                    End If

                ElseIf MediaPlanEstimate.CheckForColumnsQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Columns.HasValue = False OrElse MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0) = 0 Then

                        MediaPlanDetailLevelLineData.Columns = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 2)
                        MediaPlanDetailLevelLineData.InchesLines = FormatNumber(CDec((MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0) / 2)), 2)
                        MediaPlanDetailLevelLineData.Columns = FormatNumber(CDec((MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0) / 2)), 2)

                    End If

                ElseIf MediaPlanEstimate.CheckForInchesLinesQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.InchesLines.HasValue = False OrElse MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0) = 0 Then

                        MediaPlanDetailLevelLineData.InchesLines = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 2)

                    End If

                Else

                    QuantityDataColumns = MediaPlanEstimate.EstimateDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString) = 3 AndAlso DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString) = True).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString)).ToList

                    For Each DataColumn In QuantityDataColumns.ToList

                        If (DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse
                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse
                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString OrElse
                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString OrElse
                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString) = False Then

                            QuantityDataColumns.Remove(DataColumn)

                        End If

                    Next

                    If QuantityDataColumns.Count > 0 Then

                        FirstVisibleQuantityColumn = QuantityDataColumns(0)

                    End If

                    If FirstVisibleQuantityColumn IsNot Nothing Then

                        If FirstVisibleQuantityColumn.ColumnName = DataColumns.Demo1.ToString Then

                            If MediaPlanDetailLevelLineData.Demo1.HasValue = False OrElse MediaPlanDetailLevelLineData.Demo1.GetValueOrDefault(0) = 0 Then

                                MediaPlanDetailLevelLineData.Demo1 = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 1)

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = DataColumns.Demo2.ToString Then

                            If MediaPlanDetailLevelLineData.Demo2.HasValue = False OrElse MediaPlanDetailLevelLineData.Demo2.GetValueOrDefault(0) = 0 Then

                                MediaPlanDetailLevelLineData.Demo2 = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 1)

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = DataColumns.Units.ToString Then

                            If MediaPlanDetailLevelLineData.Units.HasValue = False OrElse MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0) = 0 Then

                                If MediaPlanEstimate.IsUnitsCPM Then

                                    MediaPlanDetailLevelLineData.Units = FormatNumber(CDec(((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)), 0)

                                Else

                                    MediaPlanDetailLevelLineData.Units = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 0)

                                End If

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = DataColumns.Impressions.ToString Then

                            If MediaPlanDetailLevelLineData.Impressions.HasValue = False OrElse MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0) = 0 Then

                                If MediaPlanEstimate.IsImpressionsCPM Then

                                    MediaPlanDetailLevelLineData.Impressions = FormatNumber(CDec(((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)), 0)

                                Else

                                    MediaPlanDetailLevelLineData.Impressions = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 0)

                                End If

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = DataColumns.Clicks.ToString Then

                            If MediaPlanDetailLevelLineData.Clicks.HasValue = False OrElse MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0) = 0 Then

                                If MediaPlanEstimate.IsClicksCPM Then

                                    MediaPlanDetailLevelLineData.Clicks = FormatNumber(CDec(((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)), 0)

                                Else

                                    MediaPlanDetailLevelLineData.Clicks = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 0)

                                End If

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = DataColumns.Columns.ToString Then

                            If MediaPlanDetailLevelLineData.Columns.HasValue = False OrElse MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0) = 0 Then

                                MediaPlanDetailLevelLineData.Columns = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 2)

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = DataColumns.InchesLines.ToString Then

                            If MediaPlanDetailLevelLineData.InchesLines.HasValue = False OrElse MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0) = 0 Then

                                MediaPlanDetailLevelLineData.InchesLines = FormatNumber(CDec((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0))), 2)

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub FillMediaPlanDetailLevelLineDataQty(MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate,
                                                       MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            'objects
            Dim Dollars As Decimal = 0
            Dim RebateAmount As Decimal = 0
            Dim CommissionAmount As Decimal = 0
            Dim FoundFirstQuantity As Boolean = False
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim QuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.ID
            Dim QuantityDataColumns As Generic.List(Of System.Data.DataColumn) = Nothing
            Dim FirstVisibleQuantityColumn As System.Data.DataColumn = Nothing
            Dim SecondVisibleQuantityColumn As System.Data.DataColumn = Nothing
            Dim ThirdVisibleQuantityColumn As System.Data.DataColumn = Nothing

            If MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0) <> 0 Then

                If MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) <> 0 Then

                        If MediaPlanEstimate.CheckForUnitsCPM(MediaPlanDetailLevelLineData.RowIndex) Then

                            MediaPlanDetailLevelLineData.Units = ((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)

                        Else

                            MediaPlanDetailLevelLineData.Units = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        End If

                    Else

                        'MediaPlanDetailLevelLineData.Dollars = 0

                    End If

                ElseIf MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) <> 0 Then

                        If MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanDetailLevelLineData.RowIndex) Then

                            MediaPlanDetailLevelLineData.Impressions = ((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)

                        Else

                            MediaPlanDetailLevelLineData.Impressions = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        End If

                    Else

                        'MediaPlanDetailLevelLineData.Dollars = 0

                    End If

                ElseIf MediaPlanEstimate.CheckForClicksQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) <> 0 Then

                        If MediaPlanEstimate.CheckForClicksCPM(MediaPlanDetailLevelLineData.RowIndex) Then

                            MediaPlanDetailLevelLineData.Clicks = ((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)

                        Else

                            MediaPlanDetailLevelLineData.Clicks = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        End If

                    Else

                        ' MediaPlanDetailLevelLineData.Dollars = 0

                    End If

                ElseIf MediaPlanEstimate.CheckForColumnsQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) <> 0 Then

                        MediaPlanDetailLevelLineData.Columns = Math.Round((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero)

                    Else

                        ' MediaPlanDetailLevelLineData.Dollars = 0

                    End If

                ElseIf MediaPlanEstimate.CheckForInchesLinesQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) <> 0 Then

                        MediaPlanDetailLevelLineData.InchesLines = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                    Else

                        ' MediaPlanDetailLevelLineData.Dollars = 0

                    End If

                Else

                    QuantityDataColumns = MediaPlanEstimate.EstimateDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString) = 3 AndAlso DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString) = True).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString)).ToList

                    For Each DataColumn In QuantityDataColumns.ToList

                        If (DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString) = False Then

                            QuantityDataColumns.Remove(DataColumn)

                        End If

                    Next

                    If QuantityDataColumns.Count > 0 Then

                        FirstVisibleQuantityColumn = QuantityDataColumns(0)

                    End If

                    If QuantityDataColumns.Count > 1 Then

                        SecondVisibleQuantityColumn = QuantityDataColumns(1)

                    End If

                    If QuantityDataColumns.Count > 2 Then

                        ThirdVisibleQuantityColumn = QuantityDataColumns(2)

                    End If

                    If MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) <> 0 Then

                        If FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                            MediaPlanDetailLevelLineData.Demo1 = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                            MediaPlanDetailLevelLineData.Demo2 = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                            If MediaPlanEstimate.IsUnitsCPM Then

                                MediaPlanDetailLevelLineData.Units = ((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)

                            Else

                                MediaPlanDetailLevelLineData.Units = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                            If MediaPlanEstimate.IsImpressionsCPM Then

                                MediaPlanDetailLevelLineData.Impressions = ((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)

                            Else

                                MediaPlanDetailLevelLineData.Impressions = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                            If MediaPlanEstimate.IsClicksCPM Then

                                MediaPlanDetailLevelLineData.Clicks = ((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)

                            Else

                                MediaPlanDetailLevelLineData.Clicks = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                            MediaPlanDetailLevelLineData.Columns = Math.Round((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero)

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                            MediaPlanDetailLevelLineData.InchesLines = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        End If

                    Else

                        QuantityColumn = GetQuantityColumn(MediaPlanEstimate, MediaPlanDetailLevelLineData.RowIndex, MediaPlanDetailLevelLineData.Demo1.GetValueOrDefault(0), MediaPlanDetailLevelLineData.Demo2.GetValueOrDefault(0),
                                                           MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0), MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0), MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0),
                                                           MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0), MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0),
                                                           QuantityDataColumns)

                        If QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Demo1 Then

                            MediaPlanDetailLevelLineData.Demo1 = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Demo2 Then

                            MediaPlanDetailLevelLineData.Demo2 = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units Then

                            If MediaPlanEstimate.IsUnitsCPM Then

                                MediaPlanDetailLevelLineData.Units = ((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)

                            Else

                                MediaPlanDetailLevelLineData.Units = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions Then

                            If MediaPlanEstimate.IsImpressionsCPM Then

                                MediaPlanDetailLevelLineData.Impressions = ((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)

                            Else

                                MediaPlanDetailLevelLineData.Impressions = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks Then

                            If MediaPlanEstimate.IsClicksCPM Then

                                MediaPlanDetailLevelLineData.Clicks = ((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * 1000)

                            Else

                                MediaPlanDetailLevelLineData.Clicks = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns Then

                            MediaPlanDetailLevelLineData.Columns = Math.Round((MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) * MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero)

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines Then

                            MediaPlanDetailLevelLineData.InchesLines = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0) / MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        End If

                    End If

                End If

            End If

            MediaPlanDetailLevelLineTag = MediaPlanEstimate.GetVendorLevelLineTag(MediaPlanDetailLevelLineData.RowIndex)

            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                CalculateMediaPlanDetailLevelLineData(MediaPlanEstimate.IsEstimateGrossAmount, MediaPlanDetailLevelLineTag.VendorCommission,
                                                      MediaPlanDetailLevelLineTag.VendorMarkup, MediaPlanEstimate.ProductUsesNetAmount,
                                                      MediaPlanEstimate.ProductRebateAmount, MediaPlanEstimate.ProductMarkupAmount,
                                                      MediaPlanDetailLevelLineData)

            Else

                CalculateMediaPlanDetailLevelLineData(MediaPlanEstimate.IsEstimateGrossAmount, Nothing, Nothing,
                                                      MediaPlanEstimate.ProductUsesNetAmount, MediaPlanEstimate.ProductRebateAmount,
                                                      MediaPlanEstimate.ProductMarkupAmount, MediaPlanDetailLevelLineData)

            End If

        End Sub
        Public Sub FillMediaPlanDetailLevelLineData(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate,
                                                    ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            'objects
            Dim Dollars As Decimal = 0
            Dim RebateAmount As Decimal = 0
            Dim CommissionAmount As Decimal = 0
            Dim FoundFirstQuantity As Boolean = False
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim QuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.ID
            Dim QuantityDataColumns As Generic.List(Of System.Data.DataColumn) = Nothing
            Dim FirstVisibleQuantityColumn As System.Data.DataColumn = Nothing
            Dim SecondVisibleQuantityColumn As System.Data.DataColumn = Nothing
            Dim ThirdVisibleQuantityColumn As System.Data.DataColumn = Nothing

            If MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0) <> 0 Then

                If MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0) <> 0 Then

                        If MediaPlanEstimate.CheckForUnitsCPM(MediaPlanDetailLevelLineData.RowIndex) Then

                            MediaPlanDetailLevelLineData.Dollars = ((MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) / 1000)

                        Else

                            MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        End If

                    Else

                        'MediaPlanDetailLevelLineData.Dollars = 0

                    End If

                ElseIf MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0) <> 0 Then

                        If MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanDetailLevelLineData.RowIndex) Then

                            MediaPlanDetailLevelLineData.Dollars = ((MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) / 1000)

                        Else

                            MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        End If

                    Else

                        'MediaPlanDetailLevelLineData.Dollars = 0

                    End If

                ElseIf MediaPlanEstimate.CheckForClicksQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0) <> 0 Then

                        If MediaPlanEstimate.CheckForClicksCPM(MediaPlanDetailLevelLineData.RowIndex) Then

                            MediaPlanDetailLevelLineData.Dollars = ((MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) / 1000)

                        Else

                            MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        End If

                    Else

                        ' MediaPlanDetailLevelLineData.Dollars = 0

                    End If

                ElseIf MediaPlanEstimate.CheckForColumnsQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0) <> 0 Then

                        MediaPlanDetailLevelLineData.Dollars = Math.Round((MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0)) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero)

                    Else

                        ' MediaPlanDetailLevelLineData.Dollars = 0

                    End If

                ElseIf MediaPlanEstimate.CheckForInchesLinesQuantity(MediaPlanDetailLevelLineData.RowIndex) Then

                    If MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0) <> 0 Then

                        MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                    Else

                        ' MediaPlanDetailLevelLineData.Dollars = 0

                    End If

                Else

                    QuantityDataColumns = MediaPlanEstimate.EstimateDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString) = 3 AndAlso DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString) = True).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString)).ToList

                    For Each DataColumn In QuantityDataColumns.ToList

                        If (DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString OrElse
                                        DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString) = False Then

                            QuantityDataColumns.Remove(DataColumn)

                        End If

                    Next

                    If QuantityDataColumns.Count > 0 Then

                        FirstVisibleQuantityColumn = QuantityDataColumns(0)

                    End If

                    If QuantityDataColumns.Count > 1 Then

                        SecondVisibleQuantityColumn = QuantityDataColumns(1)

                    End If

                    If QuantityDataColumns.Count > 2 Then

                        ThirdVisibleQuantityColumn = QuantityDataColumns(2)

                    End If

                    If MediaPlanDetailLevelLineData.Demo1.GetValueOrDefault(0) <> 0 AndAlso
                            MediaPlanDetailLevelLineData.Demo2.GetValueOrDefault(0) <> 0 AndAlso
                            MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0) <> 0 AndAlso
                            MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0) <> 0 AndAlso
                            MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0) <> 0 AndAlso
                            MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0) <> 0 AndAlso
                            MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0) <> 0 Then

                        If FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                            MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Demo1.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                            MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Demo2.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                            If MediaPlanEstimate.IsUnitsCPM Then

                                MediaPlanDetailLevelLineData.Dollars = ((MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) / 1000)

                            Else

                                MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                            If MediaPlanEstimate.IsImpressionsCPM Then

                                MediaPlanDetailLevelLineData.Dollars = ((MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) / 1000)

                            Else

                                MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                            If MediaPlanEstimate.IsClicksCPM Then

                                MediaPlanDetailLevelLineData.Dollars = ((MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) / 1000)

                            Else

                                MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                            MediaPlanDetailLevelLineData.Dollars = Math.Round((MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0)) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero)

                        ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                            MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        End If

                    Else

                        QuantityColumn = GetQuantityColumn(MediaPlanEstimate, MediaPlanDetailLevelLineData.RowIndex, MediaPlanDetailLevelLineData.Demo1.GetValueOrDefault(0), MediaPlanDetailLevelLineData.Demo2.GetValueOrDefault(0),
                                                           MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0), MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0), MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0),
                                                           MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0), MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0),
                                                           QuantityDataColumns)

                        If QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Demo1 Then

                            MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Demo1.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Demo2 Then

                            MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Demo2.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units Then

                            If MediaPlanEstimate.IsUnitsCPM Then

                                MediaPlanDetailLevelLineData.Dollars = ((MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) / 1000)

                            Else

                                MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions Then

                            If MediaPlanEstimate.IsImpressionsCPM Then

                                MediaPlanDetailLevelLineData.Dollars = ((MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) / 1000)

                            Else

                                MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks Then

                            If MediaPlanEstimate.IsClicksCPM Then

                                MediaPlanDetailLevelLineData.Dollars = ((MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)) / 1000)

                            Else

                                MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                            End If

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns Then

                            MediaPlanDetailLevelLineData.Dollars = Math.Round((MediaPlanDetailLevelLineData.Columns.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0)) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero)

                        ElseIf QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines Then

                            MediaPlanDetailLevelLineData.Dollars = MediaPlanDetailLevelLineData.InchesLines.GetValueOrDefault(0) * MediaPlanDetailLevelLineData.Rate.GetValueOrDefault(0)

                        End If

                    End If

                End If

            End If

            MediaPlanDetailLevelLineTag = MediaPlanEstimate.GetVendorLevelLineTag(MediaPlanDetailLevelLineData.RowIndex)

            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                CalculateMediaPlanDetailLevelLineData(MediaPlanEstimate.IsEstimateGrossAmount, MediaPlanDetailLevelLineTag.VendorCommission,
                                                      MediaPlanDetailLevelLineTag.VendorMarkup, MediaPlanEstimate.ProductUsesNetAmount,
                                                      MediaPlanEstimate.ProductRebateAmount, MediaPlanEstimate.ProductMarkupAmount,
                                                      MediaPlanDetailLevelLineData)

            Else

                CalculateMediaPlanDetailLevelLineData(MediaPlanEstimate.IsEstimateGrossAmount, Nothing, Nothing,
                                                      MediaPlanEstimate.ProductUsesNetAmount, MediaPlanEstimate.ProductRebateAmount,
                                                      MediaPlanEstimate.ProductMarkupAmount, MediaPlanDetailLevelLineData)

            End If

        End Sub
        Public Function GetQuantityColumn(MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, RowIndex As Integer, Demo1 As Decimal, Demo2 As Decimal,
                                          Units As Decimal, Impressions As Decimal, Clicks As Decimal, Columns As Decimal, InchesLines As Decimal,
                                          DataColumns As Generic.List(Of System.Data.DataColumn)) As AdvantageFramework.MediaPlanning.DataColumns

            'objects
            Dim QuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.ID
            Dim FirstVisibleQuantityColumn As System.Data.DataColumn = Nothing
            Dim SecondVisibleQuantityColumn As System.Data.DataColumn = Nothing
            Dim ThirdVisibleQuantityColumn As System.Data.DataColumn = Nothing
            Dim FoundFirstQuantity As Boolean = False

            If MediaPlanEstimate.CheckForUnitsQuantity(RowIndex) Then

                QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

            ElseIf MediaPlanEstimate.CheckForImpressionsQuantity(RowIndex) Then

                QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

            ElseIf MediaPlanEstimate.CheckForClicksQuantity(RowIndex) Then

                QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

            Else

                If DataColumns.Count > 0 Then

                    FirstVisibleQuantityColumn = DataColumns(0)

                End If

                If DataColumns.Count > 1 Then

                    SecondVisibleQuantityColumn = DataColumns(1)

                End If

                If DataColumns.Count > 2 Then

                    ThirdVisibleQuantityColumn = DataColumns(2)

                End If

                If Demo1 <> 0 AndAlso Demo2 <> 0 AndAlso Units <> 0 AndAlso Impressions <> 0 AndAlso
                        Clicks <> 0 AndAlso Columns <> 0 AndAlso InchesLines <> 0 AndAlso FirstVisibleQuantityColumn IsNot Nothing Then

                    If FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                        QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Demo1

                    ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                        QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Demo2

                    ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                        QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units

                    ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                        QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions

                    ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                        QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks

                    ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                        QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns

                    ElseIf FirstVisibleQuantityColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                        QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines

                    End If

                Else

                    For Each DataColumn In DataColumns

                        If DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString AndAlso Demo1 <> 0 Then

                            QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Demo1
                            Exit For

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString AndAlso Demo2 <> 0 Then

                            QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Demo2
                            Exit For

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString AndAlso Units <> 0 Then

                            QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Units
                            Exit For

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString AndAlso Impressions <> 0 Then

                            QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Impressions
                            Exit For

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString AndAlso Clicks <> 0 Then

                            QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Clicks
                            Exit For

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString AndAlso Columns <> 0 Then

                            QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.Columns
                            Exit For

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString AndAlso InchesLines <> 0 Then

                            QuantityColumn = AdvantageFramework.MediaPlanning.DataColumns.InchesLines
                            Exit For

                        End If

                    Next

                End If

            End If

            GetQuantityColumn = QuantityColumn

        End Function
        Public Sub CalculateMediaPlanDetailLevelLineData(IsEstimateGrossAmount As Boolean, VendorCommission As Nullable(Of Decimal), VendorMarkup As Nullable(Of Decimal),
                                                         ProductUsesNetAmount As Boolean, ProductRebateAmount As Decimal, ProductMarkupAmount As Decimal,
                                                         MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            'objects
            Dim Dollars As Decimal = 0
            Dim RebateAmount As Decimal = 0
            Dim CommissionAmount As Decimal = 0
            Dim UseProductAmounts As Boolean = False

            Dollars = 0
            RebateAmount = 0
            CommissionAmount = 0

            Dollars = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0)

            If IsEstimateGrossAmount Then

                UseProductAmounts = True

            Else

                If VendorMarkup.HasValue Then

                    If VendorMarkup.Value = 0 Then

                        MediaPlanDetailLevelLineData.BillAmount = Dollars + MediaPlanDetailLevelLineData.AgencyFee.GetValueOrDefault(0) + MediaPlanDetailLevelLineData.NetCharge.GetValueOrDefault(0)

                    Else

                        MediaPlanDetailLevelLineData.BillAmount = Dollars + (Dollars * (VendorMarkup.Value / 100)) + MediaPlanDetailLevelLineData.AgencyFee.GetValueOrDefault(0) + MediaPlanDetailLevelLineData.NetCharge.GetValueOrDefault(0)

                    End If

                Else

                    UseProductAmounts = True

                End If

            End If

            If UseProductAmounts Then

                If ProductUsesNetAmount Then

                    If IsEstimateGrossAmount Then

                        MediaPlanDetailLevelLineData.BillAmount = (Dollars * 0.85) + MediaPlanDetailLevelLineData.AgencyFee.GetValueOrDefault(0) + MediaPlanDetailLevelLineData.NetCharge.GetValueOrDefault(0)

                    Else

                        MediaPlanDetailLevelLineData.BillAmount = Dollars + MediaPlanDetailLevelLineData.AgencyFee.GetValueOrDefault(0) + MediaPlanDetailLevelLineData.NetCharge.GetValueOrDefault(0)

                    End If

                Else

                    If IsEstimateGrossAmount Then

                        RebateAmount = Dollars * (ProductRebateAmount / 100)

                        MediaPlanDetailLevelLineData.BillAmount = Dollars - RebateAmount + MediaPlanDetailLevelLineData.AgencyFee.GetValueOrDefault(0) + MediaPlanDetailLevelLineData.NetCharge.GetValueOrDefault(0)

                    Else

                        CommissionAmount = Dollars * (ProductMarkupAmount / 100)

                        MediaPlanDetailLevelLineData.BillAmount = Dollars + CommissionAmount + MediaPlanDetailLevelLineData.AgencyFee.GetValueOrDefault(0) + MediaPlanDetailLevelLineData.NetCharge.GetValueOrDefault(0)

                    End If

                End If

            End If

            MediaPlanDetailLevelLineData.BillAmount = If(MediaPlanDetailLevelLineData.BillAmount.HasValue, CDec(FormatNumber(MediaPlanDetailLevelLineData.BillAmount.Value, 2)), Nothing)
            MediaPlanDetailLevelLineData.Dollars = If(MediaPlanDetailLevelLineData.Dollars.HasValue, CDec(FormatNumber(MediaPlanDetailLevelLineData.Dollars.Value, 2)), Nothing)

        End Sub
        Public Sub FillEstimateDateData(ByVal MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail,
                                        ByVal DataRow As System.Data.DataRow,
                                        ByVal MediaPlanDetailDate As Date,
                                        ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek))

            'objects
            Dim RevisedDate As Date = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            DataRow(AdvantageFramework.MediaPlanning.DataColumns.Date.ToString) = MediaPlanDetailDate
            DataRow(AdvantageFramework.MediaPlanning.DataColumns.Day.ToString) = MediaPlanDetailDate 'CInt(MediaPlanDetailDate.Day)

            If MediaPlanDetail.IsCalendarMonth Then

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Week.ToString) = GetWeekDateForEstimate(MediaPlanDetailDate, True, BroadcastCalendarWeeks, MediaPlanDetail.SplitWeeks)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString) = New Date(MediaPlanDetailDate.Year, MediaPlanDetailDate.Month, 1)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Month.ToString) = New Date(MediaPlanDetailDate.Year, MediaPlanDetailDate.Month, 1)

                If CInt(Math.Ceiling(MediaPlanDetailDate.Month / 3)) = 1 Then

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(MediaPlanDetailDate.Year, 1, 1)

                ElseIf CInt(Math.Ceiling(MediaPlanDetailDate.Month / 3)) = 2 Then

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(MediaPlanDetailDate.Year, 4, 1)

                ElseIf CInt(Math.Ceiling(MediaPlanDetailDate.Month / 3)) = 3 Then

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(MediaPlanDetailDate.Year, 7, 1)

                ElseIf CInt(Math.Ceiling(MediaPlanDetailDate.Month / 3)) = 4 Then

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(MediaPlanDetailDate.Year, 10, 1)

                End If

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) = New Date(MediaPlanDetailDate.Year, 1, 1)

            Else

                RevisedDate = MediaPlanDetailDate

                Do Until RevisedDate.DayOfWeek = DayOfWeek.Monday

                    RevisedDate = RevisedDate.AddDays(-1)

                Loop

                Try

                    BroadcastCalendarWeek = BroadcastCalendarWeeks.FirstOrDefault(Function(Entity) Entity.WeekDate = RevisedDate)

                Catch ex As Exception
                    BroadcastCalendarWeek = Nothing
                End Try

                If BroadcastCalendarWeek IsNot Nothing Then

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Week.ToString) = GetWeekDateForEstimate(MediaPlanDetailDate, False, BroadcastCalendarWeek, MediaPlanDetail.SplitWeeks)
                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString) = New Date(BroadcastCalendarWeek.Year, BroadcastCalendarWeek.Month, 1)
                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Month.ToString) = New Date(BroadcastCalendarWeek.Year, BroadcastCalendarWeek.Month, 1)

                    If CInt(Math.Ceiling(BroadcastCalendarWeek.Month / 3)) = 1 Then

                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(BroadcastCalendarWeek.Year, 1, 1)

                    ElseIf CInt(Math.Ceiling(BroadcastCalendarWeek.Month / 3)) = 2 Then

                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(BroadcastCalendarWeek.Year, 4, 1)

                    ElseIf CInt(Math.Ceiling(BroadcastCalendarWeek.Month / 3)) = 3 Then

                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(BroadcastCalendarWeek.Year, 7, 1)

                    ElseIf CInt(Math.Ceiling(BroadcastCalendarWeek.Month / 3)) = 4 Then

                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(BroadcastCalendarWeek.Year, 10, 1)

                    End If

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) = New Date(BroadcastCalendarWeek.Year, 1, 1)

                Else

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Week.ToString) = GetWeekDateForEstimate(MediaPlanDetailDate, False, BroadcastCalendarWeeks, MediaPlanDetail.SplitWeeks)
                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString) = New Date(MediaPlanDetailDate.Year, MediaPlanDetailDate.Month, 1)
                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Month.ToString) = New Date(MediaPlanDetailDate.Year, MediaPlanDetailDate.Month, 1)

                    If CInt(Math.Ceiling(MediaPlanDetailDate.Month / 3)) = 1 Then

                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(MediaPlanDetailDate.Year, 1, 1)

                    ElseIf CInt(Math.Ceiling(MediaPlanDetailDate.Month / 3)) = 2 Then

                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(MediaPlanDetailDate.Year, 4, 1)

                    ElseIf CInt(Math.Ceiling(MediaPlanDetailDate.Month / 3)) = 3 Then

                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(MediaPlanDetailDate.Year, 7, 1)

                    ElseIf CInt(Math.Ceiling(MediaPlanDetailDate.Month / 3)) = 4 Then

                        DataRow(AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString) = New Date(MediaPlanDetailDate.Year, 10, 1)

                    End If

                    DataRow(AdvantageFramework.MediaPlanning.DataColumns.Year.ToString) = New Date(MediaPlanDetailDate.Year, 1, 1)

                End If

            End If

        End Sub
        Public Sub FillMediaPlanDetailDataRowData(ByVal DataRow As System.Data.DataRow, ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            If MediaPlanDetailLevelLineData IsNot Nothing Then

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString) = If(MediaPlanDetailLevelLineData.Demo1.HasValue, MediaPlanDetailLevelLineData.Demo1, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) = If(MediaPlanDetailLevelLineData.Demo2.HasValue, MediaPlanDetailLevelLineData.Demo2, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString) = If(MediaPlanDetailLevelLineData.Units.HasValue, MediaPlanDetailLevelLineData.Units, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = If(MediaPlanDetailLevelLineData.Rate.HasValue, MediaPlanDetailLevelLineData.Rate, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString) = If(MediaPlanDetailLevelLineData.Clicks.HasValue, MediaPlanDetailLevelLineData.Clicks, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString) = If(MediaPlanDetailLevelLineData.Impressions.HasValue, MediaPlanDetailLevelLineData.Impressions, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) = If(MediaPlanDetailLevelLineData.Dollars.HasValue, MediaPlanDetailLevelLineData.Dollars, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString) = If(MediaPlanDetailLevelLineData.NetCharge.HasValue, MediaPlanDetailLevelLineData.NetCharge, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString) = If(MediaPlanDetailLevelLineData.AgencyFee.HasValue, MediaPlanDetailLevelLineData.AgencyFee, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString) = If(MediaPlanDetailLevelLineData.BillAmount.HasValue, MediaPlanDetailLevelLineData.BillAmount, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString) = If(MediaPlanDetailLevelLineData.Columns.HasValue, MediaPlanDetailLevelLineData.Columns, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString) = If(MediaPlanDetailLevelLineData.InchesLines.HasValue, MediaPlanDetailLevelLineData.InchesLines, DBNull.Value)

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) = If(MediaPlanDetailLevelLineData.Note IsNot Nothing, MediaPlanDetailLevelLineData.Note, DBNull.Value)
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = MediaPlanDetailLevelLineData.Color

            Else

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString) = DBNull.Value

                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) = DBNull.Value
                DataRow(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) = 0

            End If

        End Sub
        Public Function BuildLevelLines(ByVal MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = New System.Data.DataTable

            BuildLevelLines(DataTable, MediaPlanDetail, MediaPlanDetail.MediaPlanDetailLevels.ToList)

            BuildLevelLines = DataTable

        End Function
        Public Sub BuildLevelLines(DataTable As System.Data.DataTable,
                                   MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail,
                                   MediaPlanDetailLevels As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel))

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim RowIndex As Integer = -1
            Dim MediaPlanDetailPackageDetails As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail) = Nothing
            Dim MediaPlanDetailPackagePlacementNames As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName) = Nothing

            DataColumn = DataTable.Columns.Add(AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString, GetType(Integer))
            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)
            DataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}

            DataColumn = DataTable.Columns.Add(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)

            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Integer)
            DataColumn.Caption = DataColumn.ColumnName
            DataColumn.DefaultValue = 0
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)

            DataColumn = DataTable.Columns.Add(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString)

            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Integer)
            DataColumn.Caption = DataColumn.ColumnName
            DataColumn.DefaultValue = 0
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)

            DataColumn = DataTable.Columns.Add(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString)

            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(String)
            DataColumn.Caption = DataColumn.ColumnName
            DataColumn.DefaultValue = String.Empty
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)

            DataColumn = DataTable.Columns.Add(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString)

            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(String)
            DataColumn.Caption = DataColumn.ColumnName
            DataColumn.DefaultValue = String.Empty
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)

            DataColumn = DataTable.Columns.Add(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString)

            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(String)
            DataColumn.Caption = DataColumn.ColumnName
            DataColumn.DefaultValue = String.Empty
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)

            For Each MediaPlanDetailLevel In MediaPlanDetailLevels.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                DataColumn = DataTable.Columns.Add(MediaPlanDetailLevel.Description)

                DataColumn.DataType = GetType(String)
                DataColumn.DefaultValue = ""
                DataColumn.Caption = DataColumn.ColumnName
                SetLevelLineColumnProperties(DataColumn, MediaPlanDetailLevel.ID, MediaPlanDetailLevel.TagType, MediaPlanDetailLevel.Width, MediaPlanDetailLevel.OrderNumber, MediaPlanDetailLevel.MappingType, MediaPlanDetailLevel.IsVisible)

            Next

            If MediaPlanDetailLevels.SelectMany(Function(MediaPlanDetailLevel)

                                                    Dim MediaPlanDetailLevelLines As HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) = Nothing

                                                    If MediaPlanDetailLevel.MediaPlanDetailLevelLines IsNot Nothing Then

                                                        MediaPlanDetailLevelLines = MediaPlanDetailLevel.MediaPlanDetailLevelLines

                                                    Else

                                                        MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                                                    End If

                                                    Return MediaPlanDetailLevelLines

                                                End Function).Any Then

                For Each MediaPlanDetailLevelLine In MediaPlanDetailLevels.SelectMany(Function(MediaPlanDetailLevel) MediaPlanDetailLevel.MediaPlanDetailLevelLines).OrderBy(Function(Entity) Entity.RowIndex).ThenBy(Function(Entity) Entity.MediaPlanDetailLevel.OrderNumber).ToList

                    If RowIndex <> MediaPlanDetailLevelLine.RowIndex Then

                        DataRow = DataTable.Rows.Add()

                        RowIndex = MediaPlanDetailLevelLine.RowIndex

                    End If

                    DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = RowIndex
                    DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) = MediaPlanDetailLevelLine.Color

                    MediaPlanDetailPackageDetails = MediaPlanDetail.MediaPlanDetailPackageDetails.Where(Function(Entity) Entity.RowIndex = RowIndex).ToList

                    If MediaPlanDetailPackageDetails IsNot Nothing Then

                        DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) = String.Join(",", (From Entity In MediaPlanDetailPackageDetails
                                                                                                                               Select Entity.AdSize.Description))

                    End If

                    MediaPlanDetailPackagePlacementNames = MediaPlanDetail.MediaPlanDetailPackagePlacementNames.Where(Function(Entity) Entity.RowIndex = RowIndex).ToList

                    If MediaPlanDetailPackagePlacementNames IsNot Nothing Then

                        DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString) = String.Join(",", (From Entity In MediaPlanDetailPackagePlacementNames
                                                                                                                                 Select Entity.PlacementName))

                    End If

                    If String.IsNullOrWhiteSpace(DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString)) Then

                        DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString) = MediaPlanDetailLevelLine.PackageName

                    End If

                    DataRow(MediaPlanDetailLevelLine.MediaPlanDetailLevel.Description) = MediaPlanDetailLevelLine.Description

                Next

            End If

        End Sub
        Public Function BuildOrderGroupingLevelLines(Session As AdvantageFramework.Security.Session, MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail) As System.Data.DataTable

            'objects
            Dim OrderGroupingLevelLinesDataTable As System.Data.DataTable = Nothing

            OrderGroupingLevelLinesDataTable = New System.Data.DataTable

            BuildOrderGroupingLevelLines(Session, OrderGroupingLevelLinesDataTable, MediaPlanDetail, MediaPlanDetail.MediaPlanDetailLevels.ToList)

            BuildOrderGroupingLevelLines = OrderGroupingLevelLinesDataTable

        End Function
        Private Sub BuildOrderGroupingLevelLines(Session As AdvantageFramework.Security.Session,
                                                 OrderGroupingLevelLinesDataTable As System.Data.DataTable,
                                                 MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail,
                                                 MediaPlanDetailLevels As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel))

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim RowIndex As Integer = -1
            Dim DefaultGroupingType As Integer = 0
            Dim DefaultEstimateGroupingType As Integer = 0
            Dim HasDataLongerThanAMonth As Boolean = False

            DataColumn = OrderGroupingLevelLinesDataTable.Columns.Add(AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString, GetType(Integer))
            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)
            OrderGroupingLevelLinesDataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}

            DataColumn = OrderGroupingLevelLinesDataTable.Columns.Add(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)

            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Integer)
            DataColumn.Caption = DataColumn.ColumnName
            DataColumn.DefaultValue = 0
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)

            DataColumn = OrderGroupingLevelLinesDataTable.Columns.Add(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString)

            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Integer)
            DataColumn.Caption = DataColumn.ColumnName
            DataColumn.DefaultValue = 0
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)

            DataColumn = OrderGroupingLevelLinesDataTable.Columns.Add(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString)

            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Integer)
            DataColumn.Caption = DataColumn.ColumnName
            DataColumn.DefaultValue = 0
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)

            DataColumn = OrderGroupingLevelLinesDataTable.Columns.Add(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString)

            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Boolean)
            DataColumn.Caption = DataColumn.ColumnName
            DataColumn.DefaultValue = False
            SetLevelLineColumnProperties(DataColumn, -1, 0, 0, 0, 0, False)

            For Each MediaPlanDetailLevel In MediaPlanDetailLevels.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                DataColumn = OrderGroupingLevelLinesDataTable.Columns.Add(MediaPlanDetailLevel.Description)

                DataColumn.DataType = GetType(String)
                DataColumn.DefaultValue = ""
                DataColumn.Caption = DataColumn.ColumnName
                SetLevelLineColumnProperties(DataColumn, MediaPlanDetailLevel.ID, MediaPlanDetailLevel.TagType, MediaPlanDetailLevel.Width, MediaPlanDetailLevel.OrderNumber, MediaPlanDetailLevel.MappingType, MediaPlanDetailLevel.IsVisible)

            Next

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                If MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                    If MediaPlanDetail.OrderGrouping > 0 Then

                        DefaultEstimateGroupingType = MediaPlanDetail.OrderGrouping

                    Else

                        If MediaPlanDetail.SalesClassType = "I" Then

                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_INT), DefaultGroupingType) Then

                                DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                            Else

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                            End If

                        ElseIf MediaPlanDetail.SalesClassType = "M" Then

                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_MAG), DefaultGroupingType) Then

                                DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                            Else

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                            End If

                        ElseIf MediaPlanDetail.SalesClassType = "N" Then

                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_NEW), DefaultGroupingType) Then

                                DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                            Else

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay))

                            End If

                        ElseIf MediaPlanDetail.SalesClassType = "O" Then

                            If MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                            ElseIf MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                                If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_OUT), DefaultGroupingType) Then

                                    If DefaultEstimateGroupingType = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek Then

                                        DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                                    End If

                                Else

                                    DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                                End If

                            Else

                                If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_OUT), DefaultGroupingType) Then

                                    DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                                Else

                                    DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                                End If

                            End If

                        ElseIf MediaPlanDetail.SalesClassType = "R" Then

                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_RAD), DefaultGroupingType) Then

                                DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                            Else

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                            End If

                        ElseIf MediaPlanDetail.SalesClassType = "T" Then

                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_TV), DefaultGroupingType) Then

                                DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                            Else

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                            End If

                        End If

                    End If

                Else

                    If MediaPlanDetail.OrderGrouping > 0 Then

                        DefaultEstimateGroupingType = MediaPlanDetail.OrderGrouping

                    Else

                        If MediaPlanDetail.SalesClassType = "I" Then

                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_INT), DefaultGroupingType) Then

                                DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                            Else

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                            End If

                        ElseIf MediaPlanDetail.SalesClassType = "M" Then

                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_MAG), DefaultGroupingType) Then

                                DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                            Else

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                            End If

                        ElseIf MediaPlanDetail.SalesClassType = "N" Then

                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_NEW), DefaultGroupingType) Then

                                DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                            Else

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay))

                            End If

                        ElseIf MediaPlanDetail.SalesClassType = "O" Then

                            If MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                            ElseIf MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                                If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_OUT), DefaultGroupingType) Then

                                    If DefaultEstimateGroupingType = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek Then

                                        DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                                    End If

                                Else

                                    DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                                End If

                            Else

                                If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_OUT), DefaultGroupingType) Then

                                    DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                                Else

                                    DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                                End If

                            End If

                        ElseIf MediaPlanDetail.SalesClassType = "R" Then

                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_RAD), DefaultGroupingType) Then

                                DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                            Else

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                            End If

                        ElseIf MediaPlanDetail.SalesClassType = "T" Then

                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_TV), DefaultGroupingType) Then

                                DefaultEstimateGroupingType = CInt(DefaultGroupingType)

                            Else

                                DefaultEstimateGroupingType = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                            End If

                        End If

                    End If

                End If

            End Using

            If MediaPlanDetailLevels.SelectMany(Function(MediaPlanDetailLevel)

                                                    Dim MediaPlanDetailLevelLines As HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) = Nothing

                                                    If MediaPlanDetailLevel.MediaPlanDetailLevelLines IsNot Nothing Then

                                                        MediaPlanDetailLevelLines = MediaPlanDetailLevel.MediaPlanDetailLevelLines

                                                    Else

                                                        MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

                                                    End If

                                                    Return MediaPlanDetailLevelLines

                                                End Function).Any Then

                For Each MediaPlanDetailLevelLine In MediaPlanDetailLevels.SelectMany(Function(MediaPlanDetailLevel) MediaPlanDetailLevel.MediaPlanDetailLevelLines).OrderBy(Function(Entity) Entity.RowIndex).ThenBy(Function(Entity) Entity.MediaPlanDetailLevel.OrderNumber).ToList

                    If RowIndex <> MediaPlanDetailLevelLine.RowIndex Then

                        DataRow = OrderGroupingLevelLinesDataTable.Rows.Add()

                        RowIndex = MediaPlanDetailLevelLine.RowIndex

                    End If

                    DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = RowIndex
                    DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString) = MediaPlanDetailLevelLine.Color

                    If DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString) = False Then

                        If MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex AndAlso (Entity.OrderNumber IsNot Nothing OrElse Entity.HasPendingOrders = True)).Any() Then

                            DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString) = If(MediaPlanDetailLevelLine.OrderGrouping = 0, DefaultEstimateGroupingType, MediaPlanDetailLevelLine.OrderGrouping)

                            If MediaPlanDetailLevelLine.OrderGrouping = 0 Then

                                If MediaPlanDetail.SalesClassType = "R" OrElse MediaPlanDetail.SalesClassType = "T" Then

                                    If MediaPlanDetail.OrderGrouping <> 0 Then

                                        DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString) = True

                                    Else

                                        DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString) = False

                                    End If

                                Else

                                    DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString) = False

                                End If


                            Else

                                DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString) = True

                            End If

                        Else

                            DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString) = DefaultEstimateGroupingType
                            DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString) = False

                        End If

                    End If

                    DataRow(MediaPlanDetailLevelLine.MediaPlanDetailLevel.Description) = MediaPlanDetailLevelLine.Description

                Next

            End If

        End Sub
        Public Sub AllocateDataOnMediaPlanDetailLevelLineData(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData, ByVal RowCount As Integer)

            Dim HasQuantityColumn As Boolean = False
            Dim HasDollarsColumn As Boolean = False

            If DataEntryMediaPlanDetailLevelLineData.Demo1.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Demo1 = FormatNumber(CDec(DataEntryMediaPlanDetailLevelLineData.Demo1 / RowCount), 1)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Demo1 = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Demo2.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Demo2 = FormatNumber(CDec(DataEntryMediaPlanDetailLevelLineData.Demo2 / RowCount), 1)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Demo2 = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Units.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Units = FormatNumber(CDec(DataEntryMediaPlanDetailLevelLineData.Units / RowCount), 0)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Units = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Rate.HasValue Then

                'If DataEntryMediaPlanDetailLevelLineData.Rate.Value = 0 Then

                '    If MediaPlanDetailLevelLineData.OrderNumber Is Nothing AndAlso MediaPlanDetailLevelLineData.HasPendingOrders = False Then

                '        Try

                '            MediaPlanDetailLevelLineData.Rate = DataEntryMediaPlanDetailLevelLineData.Rate

                '        Catch ex As Exception
                '            MediaPlanDetailLevelLineData.Rate = Nothing
                '        End Try

                '    End If

                'Else

                Try

                    MediaPlanDetailLevelLineData.Rate = DataEntryMediaPlanDetailLevelLineData.Rate

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Rate = Nothing
                End Try

                ' End If

            End If

            If DataEntryMediaPlanDetailLevelLineData.Impressions.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Impressions = FormatNumber(CDec(DataEntryMediaPlanDetailLevelLineData.Impressions / RowCount), 0)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Impressions = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Clicks.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Clicks = FormatNumber(CDec(DataEntryMediaPlanDetailLevelLineData.Clicks / RowCount), 0)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Clicks = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Columns.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Columns = FormatNumber(CDec(DataEntryMediaPlanDetailLevelLineData.Columns / RowCount), 2)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Columns = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.InchesLines.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.InchesLines = FormatNumber(CDec(DataEntryMediaPlanDetailLevelLineData.InchesLines / RowCount), 2)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.InchesLines = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Dollars.HasValue Then

                HasDollarsColumn = True

                Try

                    MediaPlanDetailLevelLineData.Dollars = FormatNumber(CDec(DataEntryMediaPlanDetailLevelLineData.Dollars / RowCount), 2)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Dollars = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.NetCharge.HasValue Then

                Try

                    MediaPlanDetailLevelLineData.NetCharge = FormatNumber(CDec(DataEntryMediaPlanDetailLevelLineData.NetCharge / RowCount), 2)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.NetCharge = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.AgencyFee.HasValue Then

                Try

                    MediaPlanDetailLevelLineData.AgencyFee = FormatNumber(CDec(DataEntryMediaPlanDetailLevelLineData.AgencyFee / RowCount), 2)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.AgencyFee = Nothing
                End Try

            End If

            If String.IsNullOrEmpty(DataEntryMediaPlanDetailLevelLineData.Note) = False AndAlso DataEntryMediaPlanDetailLevelLineData.Note.Trim <> "" Then

                MediaPlanDetailLevelLineData.Note = DataEntryMediaPlanDetailLevelLineData.Note

            End If

            If HasDollarsColumn = False AndAlso HasQuantityColumn = False Then

                MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, DataColumns.Color)

            ElseIf HasDollarsColumn AndAlso HasQuantityColumn = False Then

                MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, DataColumns.Dollars)

            ElseIf HasDollarsColumn = False AndAlso HasQuantityColumn Then

                MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, DataColumns.Color)

            ElseIf HasDollarsColumn AndAlso HasQuantityColumn Then

                MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, DataColumns.Color)

            End If

        End Sub
        Public Sub UpdateDataOnMediaPlanDetailLevelLineData(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            Dim HasQuantityColumn As Boolean = False
            Dim HasDollarsColumn As Boolean = False

            If DataEntryMediaPlanDetailLevelLineData.Demo1.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Demo1 = DataEntryMediaPlanDetailLevelLineData.Demo1

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Demo1 = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Demo2.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Demo2 = DataEntryMediaPlanDetailLevelLineData.Demo2

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Demo2 = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Units.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Units = DataEntryMediaPlanDetailLevelLineData.Units

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Units = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Rate.HasValue Then

                'If DataEntryMediaPlanDetailLevelLineData.Rate.Value = 0 Then

                '    If MediaPlanDetailLevelLineData.OrderNumber Is Nothing AndAlso MediaPlanDetailLevelLineData.HasPendingOrders = False Then

                '        Try

                '            MediaPlanDetailLevelLineData.Rate = DataEntryMediaPlanDetailLevelLineData.Rate

                '        Catch ex As Exception
                '            MediaPlanDetailLevelLineData.Rate = Nothing
                '        End Try

                '    End If

                'Else

                Try

                    MediaPlanDetailLevelLineData.Rate = DataEntryMediaPlanDetailLevelLineData.Rate

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Rate = Nothing
                End Try

                'End If

            End If

            If DataEntryMediaPlanDetailLevelLineData.Impressions.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Impressions = DataEntryMediaPlanDetailLevelLineData.Impressions

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Impressions = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Clicks.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Clicks = DataEntryMediaPlanDetailLevelLineData.Clicks

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Clicks = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Columns.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.Columns = DataEntryMediaPlanDetailLevelLineData.Columns

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Columns = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.InchesLines.HasValue Then

                HasQuantityColumn = True

                Try

                    MediaPlanDetailLevelLineData.InchesLines = DataEntryMediaPlanDetailLevelLineData.InchesLines

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.InchesLines = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.Dollars.HasValue Then

                HasDollarsColumn = True

                Try

                    MediaPlanDetailLevelLineData.Dollars = DataEntryMediaPlanDetailLevelLineData.Dollars

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.Dollars = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.NetCharge.HasValue Then

                Try

                    MediaPlanDetailLevelLineData.NetCharge = DataEntryMediaPlanDetailLevelLineData.NetCharge

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.NetCharge = Nothing
                End Try

            End If

            If DataEntryMediaPlanDetailLevelLineData.AgencyFee.HasValue Then

                Try

                    MediaPlanDetailLevelLineData.AgencyFee = DataEntryMediaPlanDetailLevelLineData.AgencyFee

                Catch ex As Exception
                    MediaPlanDetailLevelLineData.AgencyFee = Nothing
                End Try

            End If

            If String.IsNullOrEmpty(DataEntryMediaPlanDetailLevelLineData.Note) = False AndAlso DataEntryMediaPlanDetailLevelLineData.Note.Trim <> "" Then

                MediaPlanDetailLevelLineData.Note = DataEntryMediaPlanDetailLevelLineData.Note

            End If

            If HasDollarsColumn = False AndAlso HasQuantityColumn = False Then

                MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, DataColumns.Color)

            ElseIf HasDollarsColumn AndAlso HasQuantityColumn = False Then

                MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, DataColumns.Dollars)

            ElseIf HasDollarsColumn = False AndAlso HasQuantityColumn Then

                MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, DataColumns.Color)

            ElseIf HasDollarsColumn AndAlso HasQuantityColumn Then

                MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, DataColumns.Color)

            End If

        End Sub
        Public Sub SetLevelLineColumnProperties(ByRef DataColumn As System.Data.DataColumn, ByVal MediaPlanDetailLevelID As Integer, ByVal TagType As AdvantageFramework.MediaPlanning.TagTypes,
                                                ByVal Width As Integer, ByVal OrderNumber As Integer, ByVal MappingType As AdvantageFramework.MediaPlanning.MappingTypes, ByVal IsVisible As Boolean)

            If DataColumn.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine.Properties.MediaPlanDetailLevelID.ToString) = False Then

                DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine.Properties.MediaPlanDetailLevelID.ToString, MediaPlanDetailLevelID)

            Else

                DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine.Properties.MediaPlanDetailLevelID.ToString) = MediaPlanDetailLevelID

            End If
            '=============================================================================================================================================
            '=============================================================================================================================================
            '=============================================================================================================================================
            If DataColumn.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) = False Then

                DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString, TagType)

            Else

                DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) = TagType

            End If
            '=============================================================================================================================================
            '=============================================================================================================================================
            '=============================================================================================================================================
            If DataColumn.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString) = False Then

                DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString, Width)

            Else

                DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString) = Width

            End If
            '=============================================================================================================================================
            '=============================================================================================================================================
            '=============================================================================================================================================
            If DataColumn.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = False Then

                DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString, OrderNumber)

            Else

                DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = OrderNumber

            End If
            '=============================================================================================================================================
            '=============================================================================================================================================
            '=============================================================================================================================================
            If DataColumn.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString) = False Then

                DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString, MappingType)

            Else

                DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString) = MappingType

            End If
            '=============================================================================================================================================
            '=============================================================================================================================================
            '=============================================================================================================================================
            If DataColumn.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString) = False Then

                DataColumn.ExtendedProperties.Add(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString, IsVisible)

            Else

                DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString) = IsVisible

            End If

        End Sub
        Public Function ValidateGroupingFieldsHaveData(MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData),
                                                       OrderGroupingLevelLinesDataTable As System.Data.DataTable,
                                                       EstimateMediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings,
                                                       ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim MediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings = AdvantageFramework.Exporting.Methods.MediaPlanOrderGroupings.FullFlight
            Dim MediaPlanningDatas As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData) = Nothing

            For Each DataRow In OrderGroupingLevelLinesDataTable.Select

                MediaPlanningDatas = MediaPlanningDataList.Where(Function(Entity) Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).ToList

                If DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString) > 0 Then

                    MediaPlanOrderGrouping = DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString)

                Else

                    MediaPlanOrderGrouping = EstimateMediaPlanOrderGrouping

                End If

                Select Case MediaPlanOrderGrouping

                    Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.FullFlight

                        For Each MediaPlanningData In MediaPlanningDatas

                            If String.IsNullOrEmpty(MediaPlanningData.VendorCode) Then

                                ErrorMessage = "Please fill in a vendor for all selected data."

                                IsValid = False

                                Exit For

                            End If

                        Next

                    Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay

                        For Each MediaPlanningData In MediaPlanningDatas

                            If String.IsNullOrEmpty(MediaPlanningData.VendorCode) Then

                                ErrorMessage = "Please fill in a vendor for all selected data."

                                IsValid = False

                                Exit For

                            End If

                        Next

                    Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth

                        For Each MediaPlanningData In MediaPlanningDatas

                            If String.IsNullOrEmpty(MediaPlanningData.VendorCode) Then

                                ErrorMessage = "Please fill in a vendor for all selected data."

                                IsValid = False

                                Exit For

                            ElseIf MediaPlanningData.Month.HasValue = False Then

                                ErrorMessage = "Please fill in a month for all selected data."

                                IsValid = False

                                Exit For

                            End If

                        Next

                    Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByQuarter

                        For Each MediaPlanningData In MediaPlanningDatas

                            If String.IsNullOrEmpty(MediaPlanningData.VendorCode) Then

                                ErrorMessage = "Please fill in a vendor for all selected data."

                                IsValid = False

                                Exit For

                            ElseIf MediaPlanningData.Quarter.HasValue = False Then

                                ErrorMessage = "Please fill in a quarter for all selected data."

                                IsValid = False

                                Exit For

                            End If

                        Next

                    Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek

                        For Each MediaPlanningData In MediaPlanningDatas

                            If String.IsNullOrEmpty(MediaPlanningData.VendorCode) Then

                                ErrorMessage = "Please fill in a vendor for all selected data."

                                IsValid = False

                                Exit For

                            End If

                        Next

                End Select

                If IsValid = False Then

                    Exit For

                End If

            Next

            ValidateGroupingFieldsHaveData = IsValid

        End Function
        Private Sub SetTotalSpotsAndCostType(ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                             ByVal TotalUnits As Decimal, ByVal TotalImpressions As Decimal, ByVal TotalClicks As Decimal,
                                             ByVal TotalColumns As Decimal, ByVal TotalInchesLines As Decimal,
                                             ByVal RowIndex As Integer, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate,
                                             ByRef IsUnits As Boolean, ByRef IsImpressions As Boolean, ByRef IsClicks As Boolean, ByRef IsColumns As Boolean, ByRef IsInchesLines As Boolean)

            If MediaPlanEstimate.CheckForUnitsQuantity(RowIndex) Then

                ImportOrder.TotalSpots = TotalUnits
                IsUnits = True

                If MediaPlanEstimate.CheckForUnitsCPM(RowIndex) Then

                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                End If

            ElseIf MediaPlanEstimate.CheckForImpressionsQuantity(RowIndex) Then

                ImportOrder.TotalSpots = TotalImpressions
                IsImpressions = True

                If MediaPlanEstimate.CheckForImpressionsCPM(RowIndex) Then

                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                End If

            ElseIf MediaPlanEstimate.CheckForClicksQuantity(RowIndex) Then

                ImportOrder.TotalSpots = TotalClicks
                IsClicks = True

                If MediaPlanEstimate.CheckForClicksCPM(RowIndex) Then

                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                End If

            ElseIf MediaPlanEstimate.CheckForColumnsQuantity(RowIndex) Then

                ImportOrder.MediaPlanColumns = TotalColumns
                ImportOrder.MediaPlanInches = TotalInchesLines

                ImportOrder.TotalSpots = (TotalColumns * TotalInchesLines)
                IsColumns = True

            ElseIf MediaPlanEstimate.CheckForInchesLinesQuantity(RowIndex) Then

                ImportOrder.TotalSpots = TotalInchesLines
                IsInchesLines = True

            Else

                If MediaPlanEstimate.FirstVisibleQuantityColumn = MediaPlanning.DataColumns.Units AndAlso TotalUnits > 0 Then

                    ImportOrder.TotalSpots = TotalUnits
                    IsUnits = True

                    If MediaPlanEstimate.IsUnitsCPM Then

                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                    End If

                ElseIf MediaPlanEstimate.FirstVisibleQuantityColumn = MediaPlanning.DataColumns.Impressions AndAlso TotalImpressions > 0 Then

                    ImportOrder.TotalSpots = TotalImpressions
                    IsImpressions = True

                    If MediaPlanEstimate.IsImpressionsCPM Then

                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                    End If

                ElseIf MediaPlanEstimate.FirstVisibleQuantityColumn = MediaPlanning.DataColumns.Clicks AndAlso TotalClicks > 0 Then

                    ImportOrder.TotalSpots = TotalClicks
                    IsClicks = True

                    If MediaPlanEstimate.IsClicksCPM Then

                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                    End If

                ElseIf MediaPlanEstimate.FirstVisibleQuantityColumn = MediaPlanning.DataColumns.Columns AndAlso TotalColumns > 0 Then

                    ImportOrder.MediaPlanColumns = TotalColumns
                    ImportOrder.MediaPlanInches = TotalInchesLines

                    ImportOrder.TotalSpots = (TotalColumns * TotalInchesLines)
                    IsColumns = True

                ElseIf MediaPlanEstimate.FirstVisibleQuantityColumn = MediaPlanning.DataColumns.InchesLines AndAlso TotalInchesLines > 0 Then

                    ImportOrder.TotalSpots = TotalInchesLines
                    IsInchesLines = True

                End If

                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 Then

                    If MediaPlanEstimate.SecondVisibleQuantityColumn = MediaPlanning.DataColumns.Units AndAlso TotalUnits > 0 Then

                        ImportOrder.TotalSpots = TotalUnits
                        IsUnits = True

                        If MediaPlanEstimate.IsUnitsCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.SecondVisibleQuantityColumn = MediaPlanning.DataColumns.Impressions AndAlso TotalImpressions > 0 Then

                        ImportOrder.TotalSpots = TotalImpressions
                        IsImpressions = True

                        If MediaPlanEstimate.IsImpressionsCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.SecondVisibleQuantityColumn = MediaPlanning.DataColumns.Clicks AndAlso TotalClicks > 0 Then

                        ImportOrder.TotalSpots = TotalClicks
                        IsClicks = True

                        If MediaPlanEstimate.IsClicksCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.SecondVisibleQuantityColumn = MediaPlanning.DataColumns.Columns AndAlso TotalColumns > 0 Then

                        ImportOrder.MediaPlanColumns = TotalColumns
                        ImportOrder.MediaPlanInches = TotalInchesLines

                        ImportOrder.TotalSpots = (TotalColumns * TotalInchesLines)
                        IsColumns = True

                    ElseIf MediaPlanEstimate.SecondVisibleQuantityColumn = MediaPlanning.DataColumns.InchesLines AndAlso TotalInchesLines > 0 Then

                        ImportOrder.TotalSpots = TotalInchesLines
                        IsInchesLines = True

                    End If

                End If

                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 Then

                    If MediaPlanEstimate.ThirdVisibleQuantityColumn = MediaPlanning.DataColumns.Units AndAlso TotalUnits > 0 Then

                        ImportOrder.TotalSpots = TotalUnits
                        IsUnits = True

                        If MediaPlanEstimate.IsUnitsCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.ThirdVisibleQuantityColumn = MediaPlanning.DataColumns.Impressions AndAlso TotalImpressions > 0 Then

                        ImportOrder.TotalSpots = TotalImpressions
                        IsImpressions = True

                        If MediaPlanEstimate.IsImpressionsCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.ThirdVisibleQuantityColumn = MediaPlanning.DataColumns.Clicks AndAlso TotalClicks > 0 Then

                        ImportOrder.TotalSpots = TotalClicks
                        IsClicks = True

                        If MediaPlanEstimate.IsClicksCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.ThirdVisibleQuantityColumn = MediaPlanning.DataColumns.Columns AndAlso TotalColumns > 0 Then

                        ImportOrder.MediaPlanColumns = TotalColumns
                        ImportOrder.MediaPlanInches = TotalInchesLines

                        ImportOrder.TotalSpots = (TotalColumns * TotalInchesLines)
                        IsColumns = True

                    ElseIf MediaPlanEstimate.ThirdVisibleQuantityColumn = MediaPlanning.DataColumns.InchesLines AndAlso TotalInchesLines > 0 Then

                        ImportOrder.TotalSpots = TotalInchesLines
                        IsInchesLines = True

                    End If

                End If

                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 Then

                    If MediaPlanEstimate.FourthVisibleQuantityColumn = MediaPlanning.DataColumns.Units AndAlso TotalUnits > 0 Then

                        ImportOrder.TotalSpots = TotalUnits
                        IsUnits = True

                        If MediaPlanEstimate.IsUnitsCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.FourthVisibleQuantityColumn = MediaPlanning.DataColumns.Impressions AndAlso TotalImpressions > 0 Then

                        ImportOrder.TotalSpots = TotalImpressions
                        IsImpressions = True

                        If MediaPlanEstimate.IsImpressionsCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.FourthVisibleQuantityColumn = MediaPlanning.DataColumns.Clicks AndAlso TotalClicks > 0 Then

                        ImportOrder.TotalSpots = TotalClicks
                        IsClicks = True

                        If MediaPlanEstimate.IsClicksCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.FourthVisibleQuantityColumn = MediaPlanning.DataColumns.Columns AndAlso TotalColumns > 0 Then

                        ImportOrder.MediaPlanColumns = TotalColumns
                        ImportOrder.MediaPlanInches = TotalInchesLines

                        ImportOrder.TotalSpots = (TotalColumns * TotalInchesLines)
                        IsColumns = True

                    ElseIf MediaPlanEstimate.FourthVisibleQuantityColumn = MediaPlanning.DataColumns.InchesLines AndAlso TotalInchesLines > 0 Then

                        ImportOrder.TotalSpots = TotalInchesLines
                        IsInchesLines = True

                    End If

                End If

                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 Then

                    If MediaPlanEstimate.FifthVisibleQuantityColumn = MediaPlanning.DataColumns.Units AndAlso TotalUnits > 0 Then

                        ImportOrder.TotalSpots = TotalUnits
                        IsUnits = True

                        If MediaPlanEstimate.IsUnitsCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.FifthVisibleQuantityColumn = MediaPlanning.DataColumns.Impressions AndAlso TotalImpressions > 0 Then

                        ImportOrder.TotalSpots = TotalImpressions
                        IsImpressions = True

                        If MediaPlanEstimate.IsImpressionsCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.FifthVisibleQuantityColumn = MediaPlanning.DataColumns.Clicks AndAlso TotalClicks > 0 Then

                        ImportOrder.TotalSpots = TotalClicks
                        IsClicks = True

                        If MediaPlanEstimate.IsClicksCPM Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        End If

                    ElseIf MediaPlanEstimate.FifthVisibleQuantityColumn = MediaPlanning.DataColumns.Columns AndAlso TotalColumns > 0 Then

                        ImportOrder.MediaPlanColumns = TotalColumns
                        ImportOrder.MediaPlanInches = TotalInchesLines

                        ImportOrder.TotalSpots = (TotalColumns * TotalInchesLines)
                        IsColumns = True

                    ElseIf MediaPlanEstimate.FifthVisibleQuantityColumn = MediaPlanning.DataColumns.InchesLines AndAlso TotalInchesLines > 0 Then

                        ImportOrder.TotalSpots = TotalInchesLines
                        IsInchesLines = True

                    End If

                End If

            End If

        End Sub
        Public Function BuildFullFlightOrderList(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                                 MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData),
                                                 Session As AdvantageFramework.Security.Session,
                                                 DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing
            Dim MediaPlanDetailLevelLineDataIDList As Generic.List(Of Integer) = Nothing
            Dim IsUnits As Boolean = False
            Dim IsImpressions As Boolean = False
            Dim IsClicks As Boolean = False
            Dim IsColumns As Boolean = False
            Dim IsInchesLines As Boolean = False
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim UseVendorsRateType As Boolean = False
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    UseVendorsRateType = AdvantageFramework.Agency.LoadVendorsRateTypeSetting(DataContext)

                End Using

                MediaPlan.SelectMediaPlanEstimateByMediaPlanDetailID(CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID)

                For Each MediaPlanData In (From Entity In MediaPlanningDataList
                                           Group By Entity.VendorCode, Entity.RowIndex, Entity.Rate Into MPD = Group
                                           Select VendorCode, RowIndex, Rate, MPD).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex)

                    IsUnits = False
                    IsImpressions = False
                    IsClicks = False
                    IsColumns = False
                    IsInchesLines = False

                    If MediaPlanData.VendorCode IsNot Nothing Then

                        ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                        ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                        'ImportOrder.IsSourceMediaPlanning = True
                        ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                        ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                        ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                        ImportOrder.ClientCode = MediaPlan.ClientCode
                        ImportOrder.DivisionCode = MediaPlan.DivisionCode
                        ImportOrder.ProductCode = MediaPlan.ProductCode
                        ImportOrder.VendorCode = MediaPlanData.VendorCode
                        'ImportOrder.StartDate = MediaPlanData.MPD.Select(Function(Entity) Entity.Date).Min
                        'ImportOrder.EndDate = MediaPlanData.MPD.Select(Function(Entity) Entity.Date).Max

                        If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                            If MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                                If MediaPlanData.MPD.FirstOrDefault.LineStartDate IsNot Nothing Then

                                    ImportOrder.StartDate = MediaPlanData.MPD.FirstOrDefault.LineStartDate

                                Else

                                    ImportOrder.StartDate = MediaPlan.StartDate

                                End If

                                If MediaPlanData.MPD.FirstOrDefault.LineEndDate IsNot Nothing Then

                                    ImportOrder.EndDate = MediaPlanData.MPD.FirstOrDefault.LineEndDate

                                Else

                                    ImportOrder.EndDate = MediaPlan.EndDate

                                End If

                            Else

                                ImportOrder.StartDate = MediaPlanData.MPD.Min(Function(Entity) Entity.StartDate)
                                ImportOrder.EndDate = MediaPlanData.MPD.Max(Function(Entity) Entity.EndDate)

                            End If

                        Else

                            If MediaPlanData.MPD.FirstOrDefault.LineStartDate IsNot Nothing Then

                                ImportOrder.StartDate = MediaPlanData.MPD.FirstOrDefault.LineStartDate

                            Else

                                ImportOrder.StartDate = MediaPlan.StartDate

                            End If

                            If MediaPlanData.MPD.FirstOrDefault.LineEndDate IsNot Nothing Then

                                ImportOrder.EndDate = MediaPlanData.MPD.FirstOrDefault.LineEndDate

                            Else

                                ImportOrder.EndDate = MediaPlan.EndDate

                            End If

                        End If

                        ImportOrder.MediaPlanRate = MediaPlanData.Rate
                        ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                        ImportOrder.OrderID = MediaPlanData.MPD.FirstOrDefault.OrderID
                        ImportOrder.LineNumber = MediaPlanData.MPD.FirstOrDefault.OrderLineID
                        ImportOrder.OrderNumber = MediaPlanData.MPD.FirstOrDefault.OrderNumber
                        ImportOrder.OrderLineNumber = MediaPlanData.MPD.FirstOrDefault.OrderLineNumber

                        If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                            ImportOrder.IsRevision = True

                        End If

                        ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                        SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.MPD.FirstOrDefault.RowIndex, MediaPlanData.VendorCode)

                        MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MPD
                                                              Select Entity.MediaPlanDetailLevelLineDataID).ToList

                        ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                        If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                            Try

                                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                            Catch ex As Exception
                                Campaign = Nothing
                            End Try

                            If Campaign IsNot Nothing Then

                                ImportOrder.CampaignCode = Campaign.Code
                                ImportOrder.Campaign = Campaign.Name

                            End If

                        End If

                        If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                            GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                        Else

                            If UseVendorsRateType Then

                                Try

                                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                                Catch ex As Exception
                                    Vendor = Nothing
                                End Try

                                If Vendor IsNot Nothing Then

                                    If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                        ImportOrder.NetGross = 0

                                    Else

                                        ImportOrder.NetGross = 1

                                    End If

                                Else

                                    If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                        ImportOrder.NetGross = 1

                                    Else

                                        ImportOrder.NetGross = 0

                                    End If

                                End If

                            Else

                                If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                    ImportOrder.NetGross = 1

                                Else

                                    ImportOrder.NetGross = 0

                                End If

                            End If

                        End If

                        ImportOrder.MediaNetAmount = MediaPlanData.MPD.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                        If MediaPlanData.MPD.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                            ImportOrder.AddAmount = MediaPlanData.MPD.Sum(Function(LD) LD.AgencyFee)

                        Else

                            ImportOrder.AddAmount = 0

                        End If

                        If MediaPlanData.MPD.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                            ImportOrder.NetCharge = MediaPlanData.MPD.Sum(Function(LD) LD.NetCharge)

                        Else

                            ImportOrder.NetCharge = 0

                        End If

                        'If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                        '	ImportOrder.NetRate = (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.85)
                        '	ImportOrder.GrossRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))

                        'Else

                        '	ImportOrder.NetRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))
                        '	ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.17647), 2)

                        'End If

                        SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                                 MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                                 MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                                 IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                        If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                            If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                                ImportOrder.TotalSpots = 1

                            End If

                        ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                            If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                                If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                                If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                                If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                End If

                            Else

                                If MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                    If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                    End If

                                ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                    If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                                    If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                    End If

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                End If

                            End If

                        ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                            If (MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                                    MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                                    MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                                    MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                                    MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                                If IsColumns Then

                                    ImportOrder.CostType = "CPI"
                                    ImportOrder.RateType = "STD"

                                ElseIf IsInchesLines Then

                                    ImportOrder.CostType = "CPL"
                                    ImportOrder.RateType = "STD"

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                            (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                             MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                        ImportOrder.RateType = "CPM"

                                    Else

                                        ImportOrder.RateType = "STD"

                                    End If

                                End If

                            Else

                                ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                                ImportOrder.RateType = "STD"

                            End If

                        ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                            If MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                                ImportOrder.MediaPlanImpressions = MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                            Else

                                ImportOrder.MediaPlanImpressions = Nothing

                            End If

                        End If

                        SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

                        ImportOrder.Units = "M"

                        If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                            If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                ImportOrder.TotalSpots = 0

                            End If

                            ImportOrderList.Add(ImportOrder)

                        End If

                    End If

                Next

                DbContext.Database.Connection.Close()

            End Using

            BuildFullFlightOrderList = ImportOrderList

        End Function
        Public Function BuildPeriodOrderList(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                             MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData),
                                             Session As AdvantageFramework.Security.Session,
                                             DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing
            Dim MediaPlanDetailLevelLineDataIDList As Generic.List(Of Integer) = Nothing
            Dim IsUnits As Boolean = False
            Dim IsImpressions As Boolean = False
            Dim IsClicks As Boolean = False
            Dim IsColumns As Boolean = False
            Dim IsInchesLines As Boolean = False
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim UseVendorsRateType As Boolean = False
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    UseVendorsRateType = AdvantageFramework.Agency.LoadVendorsRateTypeSetting(DataContext)

                End Using

                MediaPlan.SelectMediaPlanEstimateByMediaPlanDetailID(CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID)

                If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                    MediaPlan.MediaPlanEstimate.RefreshEntryDates()

                    For Each MediaPlanData In (From Entity In MediaPlanningDataList
                                               Group By Entity.VendorCode, Entity.StartDate, Entity.RowIndex, Entity.Rate,
                                                        DayOfWeeks = CreateDayOfWeeks(MediaPlan.MediaPlanEstimate, New Integer() {Entity.RowIndex}, New Date() {Entity.StartDate}) Into MPD = Group
                                               Select VendorCode, StartDate, RowIndex, Rate, MPD).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.StartDate)

                        IsUnits = False
                        IsImpressions = False
                        IsClicks = False
                        IsColumns = False
                        IsInchesLines = False

                        If MediaPlanData.VendorCode IsNot Nothing Then

                            ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                            ImportOrder.MediaPlanMonday = MediaPlanData.MPD.Any(Function(Entity) Entity.Monday = True)
                            ImportOrder.MediaPlanTuesday = MediaPlanData.MPD.Any(Function(Entity) Entity.Tuesday = True)
                            ImportOrder.MediaPlanWednesday = MediaPlanData.MPD.Any(Function(Entity) Entity.Wednesday = True)
                            ImportOrder.MediaPlanThursday = MediaPlanData.MPD.Any(Function(Entity) Entity.Thursday = True)
                            ImportOrder.MediaPlanFriday = MediaPlanData.MPD.Any(Function(Entity) Entity.Friday = True)
                            ImportOrder.MediaPlanSaturday = MediaPlanData.MPD.Any(Function(Entity) Entity.Saturday = True)
                            ImportOrder.MediaPlanSunday = MediaPlanData.MPD.Any(Function(Entity) Entity.Sunday = True)

                            ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                            'ImportOrder.IsSourceMediaPlanning = True 
                            ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                            ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                            ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                            ImportOrder.ClientCode = MediaPlan.ClientCode
                            ImportOrder.DivisionCode = MediaPlan.DivisionCode
                            ImportOrder.ProductCode = MediaPlan.ProductCode
                            ImportOrder.VendorCode = MediaPlanData.VendorCode
                            ImportOrder.MediaPlanAirDate = MediaPlanData.StartDate

                            ImportOrder.StartDate = MediaPlanData.StartDate
                            ImportOrder.EndDate = MediaPlanData.MPD.Max(Function(Entity) Entity.EndDate)

                            ImportOrder.UserCode = Session.UserCode

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            ImportOrder.OrderID = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderID)
                            ImportOrder.LineNumber = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderLineID)
                            ImportOrder.OrderNumber = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderNumber)
                            ImportOrder.OrderLineNumber = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderLineNumber)

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            If ImportOrder.OrderID.HasValue = False AndAlso ImportOrder.LineNumber.HasValue = False Then

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).Any(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                            Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                            Entity.OrderNumber.GetValueOrDefault(0) <> 0) = True Then

                                    ImportOrder.OrderID = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                             Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                             Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderID

                                    ImportOrder.OrderNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                                 Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                                 Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderNumber

                                    ImportOrder.LineNumber = Nothing
                                    ImportOrder.OrderLineNumber = Nothing

                                End If

                            End If

                            If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                                ImportOrder.IsRevision = True

                            End If

                            ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                            SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.MPD.FirstOrDefault.RowIndex, MediaPlanData.VendorCode)

                            MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MPD
                                                                  Select Entity.MediaPlanDetailLevelLineDataID).ToList

                            ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                            If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                                Try

                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    ImportOrder.CampaignCode = Campaign.Code
                                    ImportOrder.Campaign = Campaign.Name

                                End If

                            End If

                            If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                                GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                            Else

                                If UseVendorsRateType Then

                                    Try

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                                    Catch ex As Exception
                                        Vendor = Nothing
                                    End Try

                                    If Vendor IsNot Nothing Then

                                        If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                            ImportOrder.NetGross = 0

                                        Else

                                            ImportOrder.NetGross = 1

                                        End If

                                    Else

                                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                            ImportOrder.NetGross = 1

                                        Else

                                            ImportOrder.NetGross = 0

                                        End If

                                    End If

                                Else

                                    If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                        ImportOrder.NetGross = 1

                                    Else

                                        ImportOrder.NetGross = 0

                                    End If

                                End If

                            End If

                            ImportOrder.MediaNetAmount = MediaPlanData.MPD.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                            If MediaPlanData.MPD.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                                ImportOrder.AddAmount = MediaPlanData.MPD.Sum(Function(LD) LD.AgencyFee)

                            Else

                                ImportOrder.AddAmount = 0

                            End If

                            If MediaPlanData.MPD.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                                ImportOrder.NetCharge = MediaPlanData.MPD.Sum(Function(LD) LD.NetCharge)

                            Else

                                ImportOrder.NetCharge = 0

                            End If

                            'If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                            '	ImportOrder.NetRate = (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.85)
                            '	ImportOrder.GrossRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))

                            'Else

                            '	ImportOrder.NetRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))
                            '	ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.17647), 2)

                            'End If

                            SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                                     MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                                     MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                                     IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                                    ImportOrder.TotalSpots = 1

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                                If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                    End If

                                Else

                                    If MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                        End If

                                    ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                        End If

                                    ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                        End If

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                                If (MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                                    If IsColumns Then

                                        ImportOrder.CostType = "CPI"
                                        ImportOrder.RateType = "STD"

                                    ElseIf IsInchesLines Then

                                        ImportOrder.CostType = "CPL"
                                        ImportOrder.RateType = "STD"

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                                (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                                 MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                            ImportOrder.RateType = "CPM"

                                        Else

                                            ImportOrder.RateType = "STD"

                                        End If

                                    End If

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                                    ImportOrder.RateType = "STD"

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                                    ImportOrder.MediaPlanImpressions = MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                                Else

                                    ImportOrder.MediaPlanImpressions = Nothing

                                End If

                            End If

                            SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

                            ImportOrder.Units = "D"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    Next

                Else

                    For Each MediaPlanData In (From Entity In MediaPlanningDataList
                                               Group By Entity.VendorCode, Entity.StartDate, Entity.RowIndex, Entity.Rate Into MPD = Group
                                               Select VendorCode, StartDate, RowIndex, Rate, MPD).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.StartDate)

                        IsUnits = False
                        IsImpressions = False
                        IsClicks = False
                        IsColumns = False
                        IsInchesLines = False

                        If MediaPlanData.VendorCode IsNot Nothing Then

                            ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                            ImportOrder.MediaPlanMonday = MediaPlanData.MPD.FirstOrDefault.Monday
                            ImportOrder.MediaPlanTuesday = MediaPlanData.MPD.FirstOrDefault.Tuesday
                            ImportOrder.MediaPlanWednesday = MediaPlanData.MPD.FirstOrDefault.Wednesday
                            ImportOrder.MediaPlanThursday = MediaPlanData.MPD.FirstOrDefault.Thursday
                            ImportOrder.MediaPlanFriday = MediaPlanData.MPD.FirstOrDefault.Friday
                            ImportOrder.MediaPlanSaturday = MediaPlanData.MPD.FirstOrDefault.Saturday
                            ImportOrder.MediaPlanSunday = MediaPlanData.MPD.FirstOrDefault.Sunday

                            ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                            'ImportOrder.IsSourceMediaPlanning = True 
                            ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                            ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                            ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                            ImportOrder.ClientCode = MediaPlan.ClientCode
                            ImportOrder.DivisionCode = MediaPlan.DivisionCode
                            ImportOrder.ProductCode = MediaPlan.ProductCode
                            ImportOrder.VendorCode = MediaPlanData.VendorCode
                            ImportOrder.MediaPlanAirDate = MediaPlanData.StartDate

                            ImportOrder.StartDate = MediaPlanData.StartDate
                            ImportOrder.EndDate = MediaPlanData.MPD.Max(Function(Entity) Entity.EndDate)

                            ImportOrder.UserCode = Session.UserCode

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            ImportOrder.OrderID = MediaPlanData.MPD.FirstOrDefault.OrderID
                            ImportOrder.LineNumber = MediaPlanData.MPD.FirstOrDefault.OrderLineID
                            ImportOrder.OrderNumber = MediaPlanData.MPD.FirstOrDefault.OrderNumber
                            ImportOrder.OrderLineNumber = MediaPlanData.MPD.FirstOrDefault.OrderLineNumber

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            If ImportOrder.OrderID.HasValue = False AndAlso ImportOrder.LineNumber.HasValue = False Then

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).Any(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                            Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                            Entity.OrderNumber.GetValueOrDefault(0) <> 0) = True Then

                                    ImportOrder.OrderID = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                             Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                             Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderID

                                    ImportOrder.OrderNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                                 Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                                 Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderNumber

                                    ImportOrder.LineNumber = Nothing
                                    ImportOrder.OrderLineNumber = Nothing

                                End If

                            End If

                            If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                                ImportOrder.IsRevision = True

                            End If

                            ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                            SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.MPD.FirstOrDefault.RowIndex, MediaPlanData.VendorCode)

                            MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MPD
                                                                  Select Entity.MediaPlanDetailLevelLineDataID).ToList

                            ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                            If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                                Try

                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    ImportOrder.CampaignCode = Campaign.Code
                                    ImportOrder.Campaign = Campaign.Name

                                End If

                            End If

                            If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                                GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                            Else

                                If UseVendorsRateType Then

                                    Try

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                                    Catch ex As Exception
                                        Vendor = Nothing
                                    End Try

                                    If Vendor IsNot Nothing Then

                                        If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                            ImportOrder.NetGross = 0

                                        Else

                                            ImportOrder.NetGross = 1

                                        End If

                                    Else

                                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                            ImportOrder.NetGross = 1

                                        Else

                                            ImportOrder.NetGross = 0

                                        End If

                                    End If

                                Else

                                    If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                        ImportOrder.NetGross = 1

                                    Else

                                        ImportOrder.NetGross = 0

                                    End If

                                End If

                            End If

                            ImportOrder.MediaNetAmount = MediaPlanData.MPD.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                            If MediaPlanData.MPD.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                                ImportOrder.AddAmount = MediaPlanData.MPD.Sum(Function(LD) LD.AgencyFee)

                            Else

                                ImportOrder.AddAmount = 0

                            End If

                            If MediaPlanData.MPD.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                                ImportOrder.NetCharge = MediaPlanData.MPD.Sum(Function(LD) LD.NetCharge)

                            Else

                                ImportOrder.NetCharge = 0

                            End If

                            'If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                            '	ImportOrder.NetRate = (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.85)
                            '	ImportOrder.GrossRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))

                            'Else

                            '	ImportOrder.NetRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))
                            '	ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.17647), 2)

                            'End If

                            SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                                     MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                                     MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                                     IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                                    ImportOrder.TotalSpots = 1

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                                If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                    End If

                                Else

                                    If MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                        End If

                                    ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                        End If

                                    ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                        End If

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                                If (MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                                    If IsColumns Then

                                        ImportOrder.CostType = "CPI"
                                        ImportOrder.RateType = "STD"

                                    ElseIf IsInchesLines Then

                                        ImportOrder.CostType = "CPL"
                                        ImportOrder.RateType = "STD"

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                                (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                                 MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                            ImportOrder.RateType = "CPM"

                                        Else

                                            ImportOrder.RateType = "STD"

                                        End If

                                    End If

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                                    ImportOrder.RateType = "STD"

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                                    ImportOrder.MediaPlanImpressions = MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                                Else

                                    ImportOrder.MediaPlanImpressions = Nothing

                                End If

                            End If

                            SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

                            ImportOrder.Units = "D"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    Next

                End If

                DbContext.Database.Connection.Close()

            End Using

            BuildPeriodOrderList = ImportOrderList

        End Function
        Private Sub GetExistingOrderNetGross(DbContext As AdvantageFramework.Database.DbContext, ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder, SalesClassCode As String)

            Dim IsGross As Boolean = False

            'If SalesClassCode = "R" OrElse
            '        SalesClassCode = "T" OrElse
            '        SalesClassCode = "M" Then

            '    IsGross = True

            'ElseIf SalesClassCode = "I" OrElse
            '        SalesClassCode = "N" OrElse
            '        SalesClassCode = "O" Then

            '    IsGross = False

            'End If

            If SalesClassCode = "M" Then

                Try

                    IsGross = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(NET_GROSS, 1) as bit) FROM dbo.MAGAZINE_HEADER WHERE ORDER_NBR = {0}", ImportOrder.OrderNumber.GetValueOrDefault(0))).First

                Catch ex As Exception
                    IsGross = True
                End Try

            ElseIf SalesClassCode = "N" Then

                Try

                    IsGross = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(NET_GROSS, 0) as bit) FROM dbo.NEWSPAPER_HEADER WHERE ORDER_NBR = {0}", ImportOrder.OrderNumber.GetValueOrDefault(0))).First

                Catch ex As Exception
                    IsGross = False
                End Try

            ElseIf SalesClassCode = "I" Then

                Try

                    IsGross = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(NET_GROSS, 0) as bit) FROM dbo.INTERNET_HEADER WHERE ORDER_NBR = {0}", ImportOrder.OrderNumber.GetValueOrDefault(0))).First

                Catch ex As Exception
                    IsGross = False
                End Try

            ElseIf SalesClassCode = "O" Then

                Try

                    IsGross = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(NET_GROSS, 0) as bit) FROM dbo.OUTDOOR_HEADER WHERE ORDER_NBR = {0}", ImportOrder.OrderNumber.GetValueOrDefault(0))).First

                Catch ex As Exception
                    IsGross = False
                End Try

            ElseIf SalesClassCode = "R" Then

                Try

                    IsGross = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(NET_GROSS, 1) as bit) FROM dbo.RADIO_HDR WHERE ORDER_NBR = {0}", ImportOrder.OrderNumber.GetValueOrDefault(0))).First

                Catch ex As Exception
                    IsGross = True
                End Try

            ElseIf SalesClassCode = "T" Then

                Try

                    IsGross = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(NET_GROSS, 1) as bit) FROM dbo.TV_HDR WHERE ORDER_NBR = {0}", ImportOrder.OrderNumber.GetValueOrDefault(0))).First

                Catch ex As Exception
                    IsGross = True
                End Try

            End If

            If IsGross Then

                ImportOrder.NetGross = 1

            Else

                ImportOrder.NetGross = 0

            End If

        End Sub
        Private Function IsMediaPlanDetailCalendarMonth(ByVal DbContext As AdvantageFramework.Database.DbContext, MediaPlanDetailID As Integer) As Boolean

            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim IsCalendarMonth As Boolean = False

            MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID)

            If MediaPlanDetail IsNot Nothing Then

                IsCalendarMonth = MediaPlanDetail.IsCalendarMonth

            End If

            IsMediaPlanDetailCalendarMonth = IsCalendarMonth

        End Function
        Private Function GetLastDayOfBroadcastMonth(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Month As Integer, ByVal Year As Integer, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            Dim LastDay As Date = Nothing

            LastDay = (From Dates In BroadcastCalendarWeeks
                       Where Dates.Month = Month AndAlso
                             Dates.Year = Year
                       Select Dates.WeekDate).Max.AddDays(6)

            GetLastDayOfBroadcastMonth = LastDay

        End Function
        Private Function GetLastDayOfBroadcastMonth(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Month As Integer, ByVal Year As Integer) As Date

            Dim BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
            Dim LastDay As Date = Nothing

            BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

            LastDay = GetLastDayOfBroadcastMonth(DbContext, Month, Year, BroadcastCalendarWeeks)

            GetLastDayOfBroadcastMonth = LastDay

        End Function
        Private Function GetLastDayOfBroadcastMonth(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Day As Date, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            Dim MaxWeekDate As Nullable(Of Date) = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            Dim LastDay As Nullable(Of Date) = Nothing

            MaxWeekDate = (From Dates In BroadcastCalendarWeeks
                           Where Dates.WeekDate <= Day
                           Select Dates.WeekDate).Max

            If MaxWeekDate IsNot Nothing Then

                BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
                                         Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

                If BroadcastCalendarWeek IsNot Nothing Then

                    LastDay = (From Dates In BroadcastCalendarWeeks
                               Where Dates.Month = BroadcastCalendarWeek.Month AndAlso
                                     Dates.Year = BroadcastCalendarWeek.Year
                               Select Dates.WeekDate).Max.AddDays(6)

                End If

            End If

            GetLastDayOfBroadcastMonth = LastDay

        End Function
        Private Function GetLastDayOfBroadcastMonth(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Day As Date) As Date

            Dim BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
            Dim LastDay As Nullable(Of Date) = Nothing

            BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

            LastDay = GetLastDayOfBroadcastMonth(DbContext, Day, BroadcastCalendarWeeks)

            GetLastDayOfBroadcastMonth = LastDay

        End Function
        Private Function GetLastDayOfBroadcastWeek(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Week As Integer, ByVal Year As Integer, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            Dim LastDay As Date = Nothing

            LastDay = (From Dates In BroadcastCalendarWeeks
                       Where Dates.Week = Week AndAlso
                             Dates.Year = Year
                       Select Dates.WeekDate).FirstOrDefault.AddDays(6)

            GetLastDayOfBroadcastWeek = LastDay

        End Function
        Private Function GetLastDayOfBroadcastWeek(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Week As Integer, ByVal Year As Integer) As Date

            Dim BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
            Dim LastDay As Date = Nothing

            BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

            LastDay = GetLastDayOfBroadcastWeek(DbContext, Week, Year, BroadcastCalendarWeeks)

            GetLastDayOfBroadcastWeek = LastDay

        End Function
        Private Function GetLastDayOfBroadcastQuarter(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Day As Date) As Date

            Dim BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            Dim MaxWeekDate As Nullable(Of Date) = Nothing
            Dim Month As Integer = Nothing
            Dim LastDay As Date = Nothing

            BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

            MaxWeekDate = (From Dates In BroadcastCalendarWeeks
                           Where Dates.WeekDate <= Day
                           Select Dates.WeekDate).Max

            If MaxWeekDate IsNot Nothing Then

                BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
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

                    LastDay = (From Dates In BroadcastCalendarWeeks
                               Where Dates.Month = Month AndAlso
                                     Dates.Year = BroadcastCalendarWeek.Year
                               Select Dates.WeekDate).Max.AddDays(6)

                End If

            End If

            GetLastDayOfBroadcastQuarter = LastDay

        End Function
        Private Function GetLastDayOfBroadcastQuarter(BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek), Day As Date) As Date

            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            Dim MaxWeekDate As Nullable(Of Date) = Nothing
            Dim Month As Integer = Nothing
            Dim LastDay As Date = Nothing

            MaxWeekDate = (From Dates In BroadcastCalendarWeeks
                           Where Dates.WeekDate <= Day
                           Select Dates.WeekDate).Max

            If MaxWeekDate IsNot Nothing Then

                BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
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

                    LastDay = (From Dates In BroadcastCalendarWeeks
                               Where Dates.Month = Month AndAlso
                                     Dates.Year = BroadcastCalendarWeek.Year
                               Select Dates.WeekDate).Max.AddDays(6)

                End If

            End If

            GetLastDayOfBroadcastQuarter = LastDay

        End Function
        Private Function GetStartDateByTag(ByVal DbContext As AdvantageFramework.Database.DbContext, MediaPlanDetailID As Integer) As Nullable(Of Date)

            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing

            MediaPlanDetailLevel = AdvantageFramework.Database.Procedures.MediaPlanDetailLevel.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID).Where(Function(T) T.TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate).SingleOrDefault

            If MediaPlanDetailLevel IsNot Nothing Then



            End If

        End Function
        Public Function BuildDayOrderList(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                          MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData),
                                          Session As AdvantageFramework.Security.Session,
                                          DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                          CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing
            Dim MediaPlanDetailLevelLineDataIDList As Generic.List(Of Integer) = Nothing
            Dim EntryDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue
            Dim IsUnits As Boolean = False
            Dim IsImpressions As Boolean = False
            Dim IsClicks As Boolean = False
            Dim IsColumns As Boolean = False
            Dim IsInchesLines As Boolean = False
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim UseVendorsRateType As Boolean = False
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    UseVendorsRateType = AdvantageFramework.Agency.LoadVendorsRateTypeSetting(DataContext)

                End Using

                MediaPlan.SelectMediaPlanEstimateByMediaPlanDetailID(CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID)

                If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                    MediaPlan.MediaPlanEstimate.RefreshEntryDates()

                    For Each MediaPlanData In (From Entity In MediaPlanningDataList
                                               Group By Entity.VendorCode, Entity.StartDate, Entity.RowIndex, Entity.Rate,
                                                        DayOfWeeks = CreateDayOfWeeks(MediaPlan.MediaPlanEstimate, New Integer() {Entity.RowIndex}, New Date() {Entity.StartDate}) Into MPD = Group
                                               Select VendorCode, StartDate, RowIndex, Rate, MPD).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.StartDate)

                        IsUnits = False
                        IsImpressions = False
                        IsClicks = False
                        IsColumns = False
                        IsInchesLines = False

                        If MediaPlanData.VendorCode IsNot Nothing Then

                            EntryDate = MediaPlanData.StartDate.AddDays(-1)
                            EndDate = MediaPlanData.MPD.Max(Function(Entity) Entity.EndDate)

                            'Do

                            EntryDate = EntryDate.AddDays(1)

                            ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                            ImportOrder.MediaPlanMonday = MediaPlanData.MPD.Any(Function(Entity) Entity.Monday = True)
                            ImportOrder.MediaPlanTuesday = MediaPlanData.MPD.Any(Function(Entity) Entity.Tuesday = True)
                            ImportOrder.MediaPlanWednesday = MediaPlanData.MPD.Any(Function(Entity) Entity.Wednesday = True)
                            ImportOrder.MediaPlanThursday = MediaPlanData.MPD.Any(Function(Entity) Entity.Thursday = True)
                            ImportOrder.MediaPlanFriday = MediaPlanData.MPD.Any(Function(Entity) Entity.Friday = True)
                            ImportOrder.MediaPlanSaturday = MediaPlanData.MPD.Any(Function(Entity) Entity.Saturday = True)
                            ImportOrder.MediaPlanSunday = MediaPlanData.MPD.Any(Function(Entity) Entity.Sunday = True)

                            ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                            'ImportOrder.IsSourceMediaPlanning = True 
                            ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                            ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                            ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                            ImportOrder.ClientCode = MediaPlan.ClientCode
                            ImportOrder.DivisionCode = MediaPlan.DivisionCode
                            ImportOrder.ProductCode = MediaPlan.ProductCode
                            ImportOrder.VendorCode = MediaPlanData.VendorCode
                            ImportOrder.MediaPlanAirDate = MediaPlanData.StartDate

                            ImportOrder.StartDate = MediaPlanData.StartDate
                            ImportOrder.EndDate = ImportOrder.StartDate

                            ImportOrder.UserCode = Session.UserCode

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            ImportOrder.OrderID = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderID)
                            ImportOrder.LineNumber = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderLineID)
                            ImportOrder.OrderNumber = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderNumber)
                            ImportOrder.OrderLineNumber = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderLineNumber)

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            If ImportOrder.OrderID.HasValue = False AndAlso ImportOrder.LineNumber.HasValue = False Then

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).Any(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                            Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                            Entity.OrderNumber.GetValueOrDefault(0) <> 0) = True Then

                                    ImportOrder.OrderID = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                             Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                             Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderID

                                    ImportOrder.OrderNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                                 Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                                 Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderNumber

                                    ImportOrder.LineNumber = Nothing
                                    ImportOrder.OrderLineNumber = Nothing

                                End If

                            End If

                            If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                                ImportOrder.IsRevision = True

                            End If

                            ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                            SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.MPD.FirstOrDefault.RowIndex, MediaPlanData.VendorCode)

                            MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MPD
                                                                  Select Entity.MediaPlanDetailLevelLineDataID).ToList

                            ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                            If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                                Try

                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    ImportOrder.CampaignCode = Campaign.Code
                                    ImportOrder.Campaign = Campaign.Name

                                End If

                            End If

                            If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                                GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                            Else

                                If UseVendorsRateType Then

                                    Try

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                                    Catch ex As Exception
                                        Vendor = Nothing
                                    End Try

                                    If Vendor IsNot Nothing Then

                                        If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                            ImportOrder.NetGross = 0

                                        Else

                                            ImportOrder.NetGross = 1

                                        End If

                                    Else

                                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                            ImportOrder.NetGross = 1

                                        Else

                                            ImportOrder.NetGross = 0

                                        End If

                                    End If

                                Else

                                    If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                        ImportOrder.NetGross = 1

                                    Else

                                        ImportOrder.NetGross = 0

                                    End If

                                End If

                            End If

                            ImportOrder.MediaNetAmount = MediaPlanData.MPD.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                            If MediaPlanData.MPD.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                                ImportOrder.AddAmount = MediaPlanData.MPD.Sum(Function(LD) LD.AgencyFee)

                            Else

                                ImportOrder.AddAmount = 0

                            End If

                            If MediaPlanData.MPD.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                                ImportOrder.NetCharge = MediaPlanData.MPD.Sum(Function(LD) LD.NetCharge)

                            Else

                                ImportOrder.NetCharge = 0

                            End If

                            'If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                            '	ImportOrder.NetRate = (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.85)
                            '	ImportOrder.GrossRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))

                            'Else

                            '	ImportOrder.NetRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))
                            '	ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.17647), 2)

                            'End If

                            SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                                     MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                                     MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                                     IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                                    ImportOrder.TotalSpots = 1

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                                If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                    End If

                                Else

                                    If MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                        End If

                                    ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                        End If

                                    ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                        End If

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                                If (MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                                    If IsColumns Then

                                        ImportOrder.CostType = "CPI"
                                        ImportOrder.RateType = "STD"

                                    ElseIf IsInchesLines Then

                                        ImportOrder.CostType = "CPL"
                                        ImportOrder.RateType = "STD"

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                                (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                                 MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                            ImportOrder.RateType = "CPM"

                                        Else

                                            ImportOrder.RateType = "STD"

                                        End If

                                    End If

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                                    ImportOrder.RateType = "STD"

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                                    ImportOrder.MediaPlanImpressions = MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                                Else

                                    ImportOrder.MediaPlanImpressions = Nothing

                                End If

                            End If

                            SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

                            ImportOrder.Units = "D"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                            'Loop Until EntryDate >= EndDate

                        End If

                    Next

                Else

                    For Each MediaPlanData In (From Entity In MediaPlanningDataList
                                               Group By Entity.VendorCode, Entity.StartDate, Entity.RowIndex, Entity.Rate Into MPD = Group
                                               Select VendorCode, StartDate, RowIndex, Rate, MPD).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.StartDate)

                        IsUnits = False
                        IsImpressions = False
                        IsClicks = False
                        IsColumns = False
                        IsInchesLines = False

                        If MediaPlanData.VendorCode IsNot Nothing Then

                            EntryDate = MediaPlanData.StartDate.AddDays(-1)
                            EndDate = MediaPlanData.MPD.Max(Function(Entity) Entity.EndDate)

                            'Do

                            EntryDate = EntryDate.AddDays(1)

                            ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                            ImportOrder.MediaPlanMonday = MediaPlanData.MPD.FirstOrDefault.Monday
                            ImportOrder.MediaPlanTuesday = MediaPlanData.MPD.FirstOrDefault.Tuesday
                            ImportOrder.MediaPlanWednesday = MediaPlanData.MPD.FirstOrDefault.Wednesday
                            ImportOrder.MediaPlanThursday = MediaPlanData.MPD.FirstOrDefault.Thursday
                            ImportOrder.MediaPlanFriday = MediaPlanData.MPD.FirstOrDefault.Friday
                            ImportOrder.MediaPlanSaturday = MediaPlanData.MPD.FirstOrDefault.Saturday
                            ImportOrder.MediaPlanSunday = MediaPlanData.MPD.FirstOrDefault.Sunday

                            ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                            'ImportOrder.IsSourceMediaPlanning = True 
                            ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                            ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                            ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                            ImportOrder.ClientCode = MediaPlan.ClientCode
                            ImportOrder.DivisionCode = MediaPlan.DivisionCode
                            ImportOrder.ProductCode = MediaPlan.ProductCode
                            ImportOrder.VendorCode = MediaPlanData.VendorCode
                            ImportOrder.MediaPlanAirDate = MediaPlanData.StartDate

                            ImportOrder.StartDate = MediaPlanData.StartDate
                            ImportOrder.EndDate = ImportOrder.StartDate

                            ImportOrder.UserCode = Session.UserCode

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            ImportOrder.OrderID = MediaPlanData.MPD.FirstOrDefault.OrderID
                            ImportOrder.LineNumber = MediaPlanData.MPD.FirstOrDefault.OrderLineID
                            ImportOrder.OrderNumber = MediaPlanData.MPD.FirstOrDefault.OrderNumber
                            ImportOrder.OrderLineNumber = MediaPlanData.MPD.FirstOrDefault.OrderLineNumber

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            If ImportOrder.OrderID.HasValue = False AndAlso ImportOrder.LineNumber.HasValue = False Then

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).Any(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                            Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                            Entity.OrderNumber.GetValueOrDefault(0) <> 0) = True Then

                                    ImportOrder.OrderID = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                             Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                             Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderID

                                    ImportOrder.OrderNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                                 Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                                 Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderNumber

                                    ImportOrder.LineNumber = Nothing
                                    ImportOrder.OrderLineNumber = Nothing

                                End If

                            End If

                            If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                                ImportOrder.IsRevision = True

                            End If

                            ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                            SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.MPD.FirstOrDefault.RowIndex, MediaPlanData.VendorCode)

                            MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MPD
                                                                  Select Entity.MediaPlanDetailLevelLineDataID).ToList

                            ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                            If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                                Try

                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    ImportOrder.CampaignCode = Campaign.Code
                                    ImportOrder.Campaign = Campaign.Name

                                End If

                            End If

                            If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                                GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                            Else

                                If UseVendorsRateType Then

                                    Try

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                                    Catch ex As Exception
                                        Vendor = Nothing
                                    End Try

                                    If Vendor IsNot Nothing Then

                                        If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                            ImportOrder.NetGross = 0

                                        Else

                                            ImportOrder.NetGross = 1

                                        End If

                                    Else

                                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                            ImportOrder.NetGross = 1

                                        Else

                                            ImportOrder.NetGross = 0

                                        End If

                                    End If

                                Else

                                    If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                        ImportOrder.NetGross = 1

                                    Else

                                        ImportOrder.NetGross = 0

                                    End If

                                End If

                            End If

                            ImportOrder.MediaNetAmount = MediaPlanData.MPD.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                            If MediaPlanData.MPD.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                                ImportOrder.AddAmount = MediaPlanData.MPD.Sum(Function(LD) LD.AgencyFee)

                            Else

                                ImportOrder.AddAmount = 0

                            End If

                            If MediaPlanData.MPD.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                                ImportOrder.NetCharge = MediaPlanData.MPD.Sum(Function(LD) LD.NetCharge)

                            Else

                                ImportOrder.NetCharge = 0

                            End If

                            'If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                            '	ImportOrder.NetRate = (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.85)
                            '	ImportOrder.GrossRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))

                            'Else

                            '	ImportOrder.NetRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))
                            '	ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.17647), 2)

                            'End If

                            SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                                     MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                                     MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                                     IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                                    ImportOrder.TotalSpots = 1

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                                If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                    End If

                                Else

                                    If MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                        End If

                                    ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                        End If

                                    ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                        End If

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                                If (MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                                    If IsColumns Then

                                        ImportOrder.CostType = "CPI"
                                        ImportOrder.RateType = "STD"

                                    ElseIf IsInchesLines Then

                                        ImportOrder.CostType = "CPL"
                                        ImportOrder.RateType = "STD"

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                                (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                                 MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                            ImportOrder.RateType = "CPM"

                                        Else

                                            ImportOrder.RateType = "STD"

                                        End If

                                    End If

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                                    ImportOrder.RateType = "STD"

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                                    ImportOrder.MediaPlanImpressions = MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                                Else

                                    ImportOrder.MediaPlanImpressions = Nothing

                                End If

                            End If

                            SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

                            ImportOrder.Units = "D"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                            'Loop Until EntryDate >= EndDate

                        End If

                    Next

                End If

                DbContext.Database.Connection.Close()

            End Using

            BuildDayOrderList = ImportOrderList

        End Function
        Public Function BuildMonthOrderList(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                            MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData),
                                            Session As AdvantageFramework.Security.Session,
                                            DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                            CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType,
                                            BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing
            Dim OrderStartDate As Date = Date.MinValue
            Dim OrderEndDate As Date = Date.MinValue
            Dim MediaPlanDataList As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanData) = Nothing
            Dim MediaPlanEndDateBroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            Dim MediaPlanDataLastDateList As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanData) = Nothing
            Dim UseVendorsRateType As Boolean = False

            ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    UseVendorsRateType = AdvantageFramework.Agency.LoadVendorsRateTypeSetting(DataContext)

                End Using

                MediaPlan.SelectMediaPlanEstimateByMediaPlanDetailID(CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID)

                If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                    MediaPlan.MediaPlanEstimate.RefreshEntryDates()

                    MediaPlanDataList = (From Entity In MediaPlanningDataList
                                         Group By Entity.VendorCode,
                                                  Entity.Month,
                                                  Entity.Year,
                                                  Entity.RowIndex,
                                                  Entity.Rate,
                                                  DayOfWeeks = CreateDayOfWeeks(MediaPlan.MediaPlanEstimate, New Integer() {Entity.RowIndex}, New Date() {Entity.StartDate}),
                                                  Entity.OrderID,
                                                  Entity.OrderLineID Into MPD = Group
                                         Select New MediaPlanning.Classes.MediaPlanData With {.VendorCode = VendorCode,
                                                                                              .Month = Month,
                                                                                              .Year = Year,
                                                                                              .RowIndex = RowIndex,
                                                                                              .Rate = Rate,
                                                                                              .DayOfWeeks = DayOfWeeks,
                                                                                              .MediaPlanDataDetails = MPD.ToList}).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.Year).ThenBy(Function(E) E.Month).ToList

                    For Each MediaPlanData In MediaPlanDataList

                        GetMonthOrderStartAndEndDate(DbContext, MediaPlan, MediaPlanData, OrderStartDate, OrderEndDate,
                                                     MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks, CreateOrderBroadcastCalendarType,
                                                     False)

                        ImportOrder = CreateMonthImportOrder(DbContext, MediaPlan, MediaPlanData, ImportOrderList, OrderStartDate, OrderEndDate,
                                                             MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks, DataFilter, UseVendorsRateType)

                        If ImportOrder IsNot Nothing Then

                            ImportOrder.Units = "M"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse
                                    ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    Next

                ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                    MediaPlanDataList = (From Entity In MediaPlanningDataList
                                         Group By Entity.VendorCode,
                                                  Entity.Month,
                                                  Entity.Year,
                                                  Entity.RowIndex,
                                                  Entity.Rate,
                                                  Entity.OrderID,
                                                  Entity.OrderLineID Into MPD = Group
                                         Select New MediaPlanning.Classes.MediaPlanData With {.VendorCode = VendorCode,
                                                                                              .Month = Month,
                                                                                              .Year = Year,
                                                                                              .RowIndex = RowIndex,
                                                                                              .Rate = Rate,
                                                                                              .MediaPlanDataDetails = MPD.ToList}).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.Year).ThenBy(Function(E) E.Month).ToList

                    MediaPlanDataLastDateList = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanData)

                    If MediaPlan.MediaPlanEstimate.PeriodType <> AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                        For Each VendorCode In MediaPlanDataList.Select(Function(Entity) Entity.VendorCode).Distinct

                            For Each RowIndex In MediaPlanDataList.Where(Function(Entity) Entity.VendorCode = VendorCode).Select(Function(Entity) Entity.RowIndex).Distinct

                                MediaPlanDataLastDateList.Add(MediaPlanDataList.Where(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.RowIndex = RowIndex).Last)

                            Next

                        Next

                    End If

                    For Each MediaPlanData In MediaPlanDataList

                        GetMonthOrderStartAndEndDate(DbContext, MediaPlan, MediaPlanData, OrderStartDate, OrderEndDate,
                                                     MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks, CreateOrderBroadcastCalendarType,
                                                     MediaPlanDataLastDateList.Contains(MediaPlanData))

                        ImportOrder = CreateMonthImportOrder(DbContext, MediaPlan, MediaPlanData, ImportOrderList, OrderStartDate, OrderEndDate,
                                                             MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks, DataFilter, UseVendorsRateType)

                        If ImportOrder IsNot Nothing Then

                            ImportOrder.Units = "M"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse
                                    ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    Next

                Else

                    MediaPlanDataList = (From Entity In MediaPlanningDataList
                                         Group By Entity.VendorCode,
                                                  Entity.Month,
                                                  Entity.Year,
                                                  Entity.RowIndex,
                                                  Entity.Rate,
                                                  Entity.OrderID,
                                                  Entity.OrderLineID Into MPD = Group
                                         Select New MediaPlanning.Classes.MediaPlanData With {.VendorCode = VendorCode,
                                                                                              .Month = Month,
                                                                                              .Year = Year,
                                                                                              .RowIndex = RowIndex,
                                                                                              .Rate = Rate,
                                                                                              .MediaPlanDataDetails = MPD.ToList}).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.Year).ThenBy(Function(E) E.Month).ToList

                    For Each MediaPlanData In MediaPlanDataList

                        GetMonthOrderStartAndEndDate(DbContext, MediaPlan, MediaPlanData, OrderStartDate, OrderEndDate,
                                                     MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks, CreateOrderBroadcastCalendarType,
                                                     False)

                        ImportOrder = CreateMonthImportOrder(DbContext, MediaPlan, MediaPlanData, ImportOrderList, OrderStartDate, OrderEndDate,
                                                             MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks, DataFilter, UseVendorsRateType)

                        If ImportOrder IsNot Nothing Then

                            ImportOrder.Units = "M"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse
                                    ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    Next

                End If

                DbContext.Database.Connection.Close()

            End Using

            BuildMonthOrderList = ImportOrderList

        End Function
        Private Sub GetMonthOrderStartAndEndDate(DbContext As AdvantageFramework.Database.DbContext,
                                                 MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                                 MediaPlanData As AdvantageFramework.MediaPlanning.Classes.MediaPlanData,
                                                 ByRef OrderStartDate As Date,
                                                 ByRef OrderEndDate As Date,
                                                 IsCalendarMonth As Boolean,
                                                 BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek),
                                                 CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType,
                                                 IsLastDate As Boolean)

            'objects
            Dim StartDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue
            Dim LastDate As Date = Date.MinValue
            Dim FourWeekEndDate As Date = Date.MinValue
            Dim PlanStartDateMonth As Integer = 0
            Dim PlanStartDateYear As Integer = 0
            Dim OrderStartDateMonth As Integer = 0
            Dim OrderStartDateYear As Integer = 0

            StartDate = MediaPlanData.MediaPlanDataDetails.Min(Function(Entity) Entity.StartDate)
            OrderStartDate = StartDate

            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                If MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                    If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.LineEndDate.HasValue) Then

                        EndDate = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) Entity.LineEndDate.HasValue).Max(Function(Entity) Entity.LineEndDate)

                    Else

                        EndDate = MediaPlan.EndDate

                    End If

                    If IsCalendarMonth Then

                        LastDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateSerial(StartDate.Year, StartDate.Month, 1)))

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    Else

                        LastDate = GetLastDayOfBroadcastMonth(DbContext, StartDate, BroadcastCalendarWeeks)

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    End If

                Else

                    If IsLastDate Then

                        EndDate = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.EndDate)

                    Else

                        EndDate = MediaPlan.EndDate

                    End If

                    If IsCalendarMonth Then

                        LastDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateSerial(StartDate.Year, StartDate.Month, 1)))

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    Else

                        LastDate = GetLastDayOfBroadcastMonth(DbContext, StartDate, BroadcastCalendarWeeks)

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    End If

                End If

            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "M" Then

                If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.LineEndDate.HasValue) Then

                    EndDate = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) Entity.LineEndDate.HasValue).Max(Function(Entity) Entity.LineEndDate)

                Else

                    EndDate = MediaPlan.EndDate

                End If

                If IsCalendarMonth Then

                    LastDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateSerial(StartDate.Year, StartDate.Month, 1)))

                    If EndDate > LastDate Then

                        OrderEndDate = LastDate

                    Else

                        OrderEndDate = EndDate

                    End If

                Else

                    LastDate = GetLastDayOfBroadcastMonth(DbContext, StartDate, BroadcastCalendarWeeks)

                    If EndDate > LastDate Then

                        OrderEndDate = LastDate

                    Else

                        OrderEndDate = EndDate

                    End If

                End If

            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.LineEndDate.HasValue) Then

                    EndDate = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) Entity.LineEndDate.HasValue).Max(Function(Entity) Entity.LineEndDate)

                Else

                    EndDate = MediaPlan.EndDate

                End If

                If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.StartDate <> Entity.EndDate) Then

                    FourWeekEndDate = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.EndDate)

                Else

                    FourWeekEndDate = Date.MinValue

                End If

                If FourWeekEndDate = Date.MinValue Then

                    If IsCalendarMonth Then

                        LastDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateSerial(StartDate.Year, StartDate.Month, 1)))

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    Else

                        LastDate = GetLastDayOfBroadcastMonth(DbContext, StartDate, BroadcastCalendarWeeks)

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    End If

                Else

                    OrderEndDate = FourWeekEndDate

                End If

            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.LineEndDate.HasValue) Then

                    EndDate = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) Entity.LineEndDate.HasValue).Max(Function(Entity) Entity.LineEndDate)

                Else

                    EndDate = MediaPlan.EndDate

                End If

                PlanStartDateMonth = GetMonthForEstimate(MediaPlan.StartDate, IsCalendarMonth, BroadcastCalendarWeeks, PlanStartDateYear)
                OrderStartDateMonth = GetMonthForEstimate(OrderStartDate, IsCalendarMonth, BroadcastCalendarWeeks, OrderStartDateYear)

                If PlanStartDateMonth = OrderStartDateMonth AndAlso PlanStartDateYear = OrderStartDateYear Then

                    OrderStartDate = MediaPlan.StartDate

                Else

                    If IsCalendarMonth Then

                        OrderStartDate = New Date(OrderStartDateYear, OrderStartDateMonth, 1)

                    Else

                        OrderStartDate = GetBroadcastMonthStartDate(OrderStartDateMonth, OrderStartDateYear, BroadcastCalendarWeeks)

                    End If

                End If

                If CreateOrderBroadcastCalendarType = Methods.CreateOrderBroadcastCalendarType.ByCalendar Then

                    IsCalendarMonth = True

                ElseIf CreateOrderBroadcastCalendarType = Methods.CreateOrderBroadcastCalendarType.ByBroadcast Then

                    IsCalendarMonth = False

                End If

                If IsCalendarMonth Then

                    LastDate = DateSerial(StartDate.Year, StartDate.Month + 1, 0)

                    If EndDate > LastDate Then

                        OrderEndDate = LastDate

                    Else

                        OrderEndDate = EndDate

                    End If

                Else

                    LastDate = GetLastDayOfBroadcastMonth(DbContext, MediaPlanData.Month, MediaPlanData.Year, BroadcastCalendarWeeks)

                    If EndDate > LastDate Then

                        OrderEndDate = LastDate

                    Else

                        OrderEndDate = EndDate

                    End If

                End If

            End If

        End Sub
        Private Function CreateMonthImportOrder(DbContext As AdvantageFramework.Database.DbContext,
                                                MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                                MediaPlanData As AdvantageFramework.MediaPlanning.Classes.MediaPlanData,
                                                ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder),
                                                OrderStartDate As Date,
                                                OrderEndDate As Date,
                                                IsCalendarMonth As Boolean,
                                                BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek),
                                                DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                                UseVendorsRateType As Boolean) As AdvantageFramework.Media.Classes.ImportOrder

            'objects
            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing
            Dim MediaPlanDetailLevelLineDataIDList As Generic.List(Of Integer) = Nothing
            Dim IsUnits As Boolean = False
            Dim IsImpressions As Boolean = False
            Dim IsClicks As Boolean = False
            Dim IsColumns As Boolean = False
            Dim IsInchesLines As Boolean = False
            Dim MonthWeeks As Generic.List(Of Integer) = Nothing
            Dim MediaPlanDetailLevelLineDataOrderDetail As AdvantageFramework.MediaPlanning.Classes.MediaPlanDetailLevelLineDataOrderDetail = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If MediaPlanData IsNot Nothing AndAlso String.IsNullOrWhiteSpace(MediaPlanData.VendorCode) = False Then

                IsUnits = False
                IsImpressions = False
                IsClicks = False
                IsColumns = False
                IsInchesLines = False

                ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                ImportOrder.MediaPlanMonday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Monday = True)
                ImportOrder.MediaPlanTuesday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Tuesday = True)
                ImportOrder.MediaPlanWednesday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Wednesday = True)
                ImportOrder.MediaPlanThursday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Thursday = True)
                ImportOrder.MediaPlanFriday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Friday = True)
                ImportOrder.MediaPlanSaturday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Saturday = True)
                ImportOrder.MediaPlanSunday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Sunday = True)

                ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                'ImportOrder.IsSourceMediaPlanning = True
                ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                ImportOrder.ClientCode = MediaPlan.ClientCode
                ImportOrder.DivisionCode = MediaPlan.DivisionCode
                ImportOrder.ProductCode = MediaPlan.ProductCode
                ImportOrder.VendorCode = MediaPlanData.VendorCode

                ImportOrder.StartDate = OrderStartDate
                ImportOrder.EndDate = OrderEndDate

                ImportOrder.UserCode = DbContext.UserCode
                ImportOrder.CalendarType = If(IsCalendarMonth, "CM", "BM")

                ImportOrder.OrderID = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderID)
                ImportOrder.LineNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderLineID)
                ImportOrder.OrderNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderNumber)
                ImportOrder.OrderLineNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderLineNumber)

                ImportOrder.MediaPlanRate = MediaPlanData.Rate
                ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                If ImportOrder.OrderID.HasValue AndAlso ImportOrder.OrderID.GetValueOrDefault(0) <> 0 AndAlso ImportOrder.LineNumber.HasValue AndAlso ImportOrder.LineNumber.GetValueOrDefault(0) <> 0 Then

                    If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                        ImportOrder.MediaPlanDayOfWeeks = MediaPlanData.DayOfWeeks

                        If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.OrderID = ImportOrder.OrderID AndAlso Entity.LineNumber = ImportOrder.LineNumber) = True Then

                            If ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                       Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                       Entity.MediaPlanDayOfWeeks = ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                       Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                       Entity.LineNumber <> ImportOrder.LineNumber) Then

                                ImportOrder.LineNumber = Nothing
                                ImportOrder.OrderLineNumber = Nothing

                            ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                           Entity.MediaPlanRate.GetValueOrDefault(0) <> ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                           Entity.MediaPlanDayOfWeeks = ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                           Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                           Entity.LineNumber = ImportOrder.LineNumber) Then

                                ImportOrder.LineNumber = Nothing
                                ImportOrder.OrderLineNumber = Nothing

                            ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                           Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                           Entity.MediaPlanDayOfWeeks <> ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                           Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                           Entity.LineNumber = ImportOrder.LineNumber) Then

                                ImportOrder.LineNumber = Nothing
                                ImportOrder.OrderLineNumber = Nothing

                            ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                           Entity.MediaPlanRate.GetValueOrDefault(0) <> ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                           Entity.MediaPlanDayOfWeeks <> ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                           Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                           Entity.LineNumber = ImportOrder.LineNumber) Then

                                ImportOrder.LineNumber = Nothing
                                ImportOrder.OrderLineNumber = Nothing

                            ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate <> ImportOrder.EndDate AndAlso
                                                                                                                                                                                           Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                           Entity.MediaPlanDayOfWeeks = ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                           Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                           Entity.LineNumber = ImportOrder.LineNumber) Then

                                ImportOrder.LineNumber = Nothing
                                ImportOrder.OrderLineNumber = Nothing

                            End If

                        End If

                    Else

                        If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.OrderID = ImportOrder.OrderID AndAlso Entity.LineNumber = ImportOrder.LineNumber) = True Then

                            If ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                       Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                       Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                       Entity.LineNumber <> ImportOrder.LineNumber) Then

                                ImportOrder.LineNumber = Nothing
                                ImportOrder.OrderLineNumber = Nothing

                            ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                           Entity.MediaPlanRate.GetValueOrDefault(0) <> ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                           Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                           Entity.LineNumber = ImportOrder.LineNumber) Then

                                ImportOrder.LineNumber = Nothing
                                ImportOrder.OrderLineNumber = Nothing

                            ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate <> ImportOrder.EndDate AndAlso
                                                                                                                                                                                           Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                           Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                           Entity.LineNumber = ImportOrder.LineNumber) Then

                                ImportOrder.LineNumber = Nothing
                                ImportOrder.OrderLineNumber = Nothing

                            End If

                        End If

                    End If

                Else

                    If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).Any(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                    Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                    Entity.OrderNumber.GetValueOrDefault(0) <> 0) = True Then

                        ImportOrder.OrderID = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                     Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                     Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderID

                        ImportOrder.OrderNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                         Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                         Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderNumber

                        ImportOrder.LineNumber = Nothing
                        ImportOrder.OrderLineNumber = Nothing

                    End If

                End If

                If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                    ImportOrder.IsRevision = True

                End If

                ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.MediaPlanDataDetails.FirstOrDefault.RowIndex, MediaPlanData.VendorCode)

                MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MediaPlanDataDetails
                                                      Select Entity.MediaPlanDetailLevelLineDataID).ToList

                ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                    Try

                        Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                    Catch ex As Exception
                        Campaign = Nothing
                    End Try

                    If Campaign IsNot Nothing Then

                        ImportOrder.CampaignCode = Campaign.Code
                        ImportOrder.Campaign = Campaign.Name

                    End If

                End If

                If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                    GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                Else

                    If UseVendorsRateType Then

                        Try

                            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                        Catch ex As Exception
                            Vendor = Nothing
                        End Try

                        If Vendor IsNot Nothing Then

                            If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                ImportOrder.NetGross = 0

                            Else

                                ImportOrder.NetGross = 1

                            End If

                        Else

                            If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                ImportOrder.NetGross = 1

                            Else

                                ImportOrder.NetGross = 0

                            End If

                        End If

                    Else

                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                            ImportOrder.NetGross = 1

                        Else

                            ImportOrder.NetGross = 0

                        End If

                    End If

                End If

                ImportOrder.MediaNetAmount = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                If MediaPlanData.MediaPlanDataDetails.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                    ImportOrder.AddAmount = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.AgencyFee)

                Else

                    ImportOrder.AddAmount = 0

                End If

                If MediaPlanData.MediaPlanDataDetails.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                    ImportOrder.NetCharge = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.NetCharge)

                Else

                    ImportOrder.NetCharge = 0

                End If

                SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                         MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                         MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                         IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                If (MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T") Then

                    MonthWeeks = GetWeeksForMonth(MediaPlan.StartDate, MediaPlanData.Year, MediaPlanData.Month, IsCalendarMonth, BroadcastCalendarWeeks)

                    If MonthWeeks.Count > 1 Then

                        If IsUnits Then

                            ImportOrder.Spots1 = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(0)).Sum(Function(Entity) Entity.Units.GetValueOrDefault(0))
                            ImportOrder.Spots2 = If(MonthWeeks.Count >= 2, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(1)).Sum(Function(Entity) Entity.Units.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots3 = If(MonthWeeks.Count >= 3, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(2)).Sum(Function(Entity) Entity.Units.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots4 = If(MonthWeeks.Count >= 4, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(3)).Sum(Function(Entity) Entity.Units.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots5 = If(MonthWeeks.Count >= 5, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(4)).Sum(Function(Entity) Entity.Units.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots6 = If(MonthWeeks.Count >= 6, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(5)).Sum(Function(Entity) Entity.Units.GetValueOrDefault(0)), Nothing)

                        ElseIf IsImpressions Then

                            ImportOrder.Spots1 = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(0)).Sum(Function(Entity) Entity.Impressions.GetValueOrDefault(0))
                            ImportOrder.Spots2 = If(MonthWeeks.Count >= 2, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(1)).Sum(Function(Entity) Entity.Impressions.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots3 = If(MonthWeeks.Count >= 3, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(2)).Sum(Function(Entity) Entity.Impressions.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots4 = If(MonthWeeks.Count >= 4, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(3)).Sum(Function(Entity) Entity.Impressions.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots5 = If(MonthWeeks.Count >= 5, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(4)).Sum(Function(Entity) Entity.Impressions.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots6 = If(MonthWeeks.Count >= 6, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(5)).Sum(Function(Entity) Entity.Impressions.GetValueOrDefault(0)), Nothing)

                        ElseIf IsClicks Then

                            ImportOrder.Spots1 = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(0)).Sum(Function(Entity) Entity.Clicks.GetValueOrDefault(0))
                            ImportOrder.Spots2 = If(MonthWeeks.Count >= 2, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(1)).Sum(Function(Entity) Entity.Clicks.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots3 = If(MonthWeeks.Count >= 3, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(2)).Sum(Function(Entity) Entity.Clicks.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots4 = If(MonthWeeks.Count >= 4, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(3)).Sum(Function(Entity) Entity.Clicks.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots5 = If(MonthWeeks.Count >= 5, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(4)).Sum(Function(Entity) Entity.Clicks.GetValueOrDefault(0)), Nothing)
                            ImportOrder.Spots6 = If(MonthWeeks.Count >= 6, MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) GetWeek(Entity.StartDate, IsCalendarMonth, BroadcastCalendarWeeks) = MonthWeeks(5)).Sum(Function(Entity) Entity.Clicks.GetValueOrDefault(0)), Nothing)

                        End If

                    End If

                    'ElseIf (MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T") AndAlso
                    '            MediaPlanData.MediaPlanDataDetails.Count = 1 Then

                    '    If IsUnits Then

                    '        ImportOrder.Spots1 = MediaPlanData.MediaPlanDataDetails.Sum(Function(Entity) Entity.Units.GetValueOrDefault(0))
                    '        ImportOrder.Spots2 = 0
                    '        ImportOrder.Spots3 = 0
                    '        ImportOrder.Spots4 = 0
                    '        ImportOrder.Spots5 = 0
                    '        ImportOrder.Spots6 = 0

                    '    ElseIf IsImpressions Then

                    '        ImportOrder.Spots1 = MediaPlanData.MediaPlanDataDetails.Sum(Function(Entity) Entity.Impressions.GetValueOrDefault(0))
                    '        ImportOrder.Spots2 = 0
                    '        ImportOrder.Spots3 = 0
                    '        ImportOrder.Spots4 = 0
                    '        ImportOrder.Spots5 = 0
                    '        ImportOrder.Spots6 = 0

                    '    ElseIf IsClicks Then

                    '        ImportOrder.Spots1 = MediaPlanData.MediaPlanDataDetails.Sum(Function(Entity) Entity.Clicks.GetValueOrDefault(0))
                    '        ImportOrder.Spots2 = 0
                    '        ImportOrder.Spots3 = 0
                    '        ImportOrder.Spots4 = 0
                    '        ImportOrder.Spots5 = 0
                    '        ImportOrder.Spots6 = 0

                    '    End If

                End If

                If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                    If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                        ImportOrder.TotalSpots = 1

                    End If

                ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                    If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                        If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        Else

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                        End If

                    ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                        If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        Else

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                        End If

                    ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                        If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                        Else

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                        End If

                    Else

                        If MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                    MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                    MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                            If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                            Else

                                ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                            End If

                        ElseIf MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                    MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                    MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                            If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                            Else

                                ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                            End If

                        ElseIf MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                    MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                    MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                            If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                            Else

                                ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                            End If

                        Else

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                        End If

                    End If

                ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                    If (MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                        If IsColumns Then

                            ImportOrder.CostType = "CPI"
                            ImportOrder.RateType = "STD"

                        ElseIf IsInchesLines Then

                            ImportOrder.CostType = "CPL"
                            ImportOrder.RateType = "STD"

                        Else

                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                            If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                    (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                     MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                ImportOrder.RateType = "CPM"

                            Else

                                ImportOrder.RateType = "STD"

                            End If

                        End If

                    Else

                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                        ImportOrder.RateType = "STD"

                    End If

                ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                    If MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                        ImportOrder.MediaPlanImpressions = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                    Else

                        ImportOrder.MediaPlanImpressions = Nothing

                    End If

                End If

                SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

            End If

            CreateMonthImportOrder = ImportOrder

        End Function
        Public Function BuildQuarterOrderList(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                              MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData),
                                              Session As AdvantageFramework.Security.Session,
                                              DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                              CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType,
                                              BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing
            Dim MediaPlanDetailLevelLineDataIDList As Generic.List(Of Integer) = Nothing
            Dim StartDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue
            Dim LastDate As Date = Date.MinValue
            Dim OrderStartDate As Date = Date.MinValue
            Dim OrderEndDate As Date = Date.MinValue
            Dim MediaPlanDataList As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanData) = Nothing
            Dim IsUnits As Boolean = False
            Dim IsImpressions As Boolean = False
            Dim IsClicks As Boolean = False
            Dim IsColumns As Boolean = False
            Dim IsInchesLines As Boolean = False
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim UseVendorsRateType As Boolean = False
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    UseVendorsRateType = AdvantageFramework.Agency.LoadVendorsRateTypeSetting(DataContext)

                End Using

                MediaPlan.SelectMediaPlanEstimateByMediaPlanDetailID(CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID)

                If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                    MediaPlan.MediaPlanEstimate.RefreshEntryDates()

                    MediaPlanDataList = (From Entity In MediaPlanningDataList
                                         Group By Entity.VendorCode,
                                                  Entity.Quarter,
                                                  Entity.Year,
                                                  Entity.RowIndex,
                                                  Entity.Rate,
                                                  DayOfWeeks = CreateDayOfWeeks(MediaPlan.MediaPlanEstimate, New Integer() {Entity.RowIndex}, New Date() {Entity.StartDate}),
                                                  Entity.OrderID,
                                                  Entity.OrderLineID Into MPD = Group
                                         Select New MediaPlanning.Classes.MediaPlanData With {.VendorCode = VendorCode,
                                                                                              .Quarter = Quarter,
                                                                                              .Year = Year,
                                                                                              .RowIndex = RowIndex,
                                                                                              .Rate = Rate,
                                                                                              .DayOfWeeks = DayOfWeeks,
                                                                                              .MediaPlanDataDetails = MPD.ToList}).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.Year).ThenBy(Function(E) E.Quarter).ToList

                    For Each MediaPlanData In MediaPlanDataList

                        IsUnits = False
                        IsImpressions = False
                        IsClicks = False
                        IsColumns = False
                        IsInchesLines = False

                        If MediaPlanData.VendorCode IsNot Nothing Then

                            StartDate = MediaPlanData.MediaPlanDataDetails.Min(Function(Entity) Entity.StartDate)
                            OrderStartDate = StartDate

                            If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.LineEndDate.HasValue) Then

                                EndDate = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) Entity.LineEndDate.HasValue).Max(Function(Entity) Entity.LineEndDate)

                            Else

                                EndDate = MediaPlan.EndDate

                            End If

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "M" OrElse
                                        MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlan.MediaPlanEstimate.IsCalendarMonth Then

                                    If MediaPlanData.Quarter = 1 Then

                                        LastDate = DateSerial(StartDate.Year, 3, 31)

                                    ElseIf MediaPlanData.Quarter = 2 Then

                                        LastDate = DateSerial(StartDate.Year, 6, 30)

                                    ElseIf MediaPlanData.Quarter = 3 Then

                                        LastDate = DateSerial(StartDate.Year, 9, 30)

                                    ElseIf MediaPlanData.Quarter = 4 Then

                                        LastDate = DateSerial(StartDate.Year, 12, 31)

                                    End If

                                    If EndDate > LastDate Then

                                        OrderEndDate = LastDate

                                    Else

                                        OrderEndDate = EndDate

                                    End If

                                Else

                                    LastDate = GetLastDayOfBroadcastQuarter(BroadcastCalendarWeeks, StartDate)

                                    If EndDate > LastDate Then

                                        OrderEndDate = LastDate

                                    Else

                                        OrderEndDate = EndDate

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If MediaPlan.MediaPlanEstimate.IsCalendarMonth AndAlso
                                        (CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.FromPlan OrElse
                                         CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.ByCalendar) Then

                                    LastDate = DateSerial(StartDate.Year, StartDate.Month + 1, 0)

                                    If EndDate > LastDate Then

                                        OrderEndDate = LastDate

                                    Else

                                        OrderEndDate = EndDate

                                    End If

                                Else

                                    LastDate = GetLastDayOfBroadcastMonth(DbContext, StartDate, BroadcastCalendarWeeks)

                                    If EndDate > LastDate Then

                                        OrderEndDate = LastDate

                                    Else

                                        OrderEndDate = EndDate

                                    End If

                                End If

                            End If

                            ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                            ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                            'ImportOrder.IsSourceMediaPlanning = True
                            ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                            ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                            ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                            ImportOrder.ClientCode = MediaPlan.ClientCode
                            ImportOrder.DivisionCode = MediaPlan.DivisionCode
                            ImportOrder.ProductCode = MediaPlan.ProductCode
                            ImportOrder.VendorCode = MediaPlanData.VendorCode

                            ImportOrder.StartDate = OrderStartDate
                            ImportOrder.EndDate = OrderEndDate

                            ImportOrder.UserCode = Session.UserCode
                            ImportOrder.CalendarType = If(MediaPlan.MediaPlanEstimate.IsCalendarMonth AndAlso
                                                            (CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.FromPlan OrElse
                                                             CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.ByCalendar), "CM", "BM")

                            ImportOrder.OrderID = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderID)
                            ImportOrder.LineNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderLineID)
                            ImportOrder.OrderNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderNumber)
                            ImportOrder.OrderLineNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderLineNumber)

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            If ImportOrder.OrderID.HasValue AndAlso ImportOrder.OrderID.GetValueOrDefault(0) <> 0 AndAlso ImportOrder.LineNumber.HasValue AndAlso ImportOrder.LineNumber.GetValueOrDefault(0) <> 0 Then

                                ImportOrder.MediaPlanDayOfWeeks = MediaPlanData.DayOfWeeks

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.OrderID = ImportOrder.OrderID AndAlso Entity.LineNumber = ImportOrder.LineNumber) = True Then

                                    If ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                               Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                               Entity.MediaPlanDayOfWeeks = ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                               Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                               Entity.LineNumber <> ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) <> ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.MediaPlanDayOfWeeks = ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.MediaPlanDayOfWeeks <> ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) <> ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.MediaPlanDayOfWeeks <> ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate <> ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.MediaPlanDayOfWeeks = ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    End If

                                End If

                            Else

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).Any(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                            Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                            Entity.OrderNumber.GetValueOrDefault(0) <> 0) = True Then

                                    ImportOrder.OrderID = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                             Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                             Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderID

                                    ImportOrder.OrderNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                                 Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                                 Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderNumber

                                    ImportOrder.LineNumber = Nothing
                                    ImportOrder.OrderLineNumber = Nothing

                                End If

                            End If

                            If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                                ImportOrder.IsRevision = True

                            End If

                            ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                            SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.RowIndex, MediaPlanData.VendorCode)

                            MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MediaPlanDataDetails
                                                                  Select Entity.MediaPlanDetailLevelLineDataID).ToList

                            ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                            If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                                Try

                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    ImportOrder.CampaignCode = Campaign.Code
                                    ImportOrder.Campaign = Campaign.Name

                                End If

                            End If

                            If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                                GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                            Else

                                If UseVendorsRateType Then

                                    Try

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                                    Catch ex As Exception
                                        Vendor = Nothing
                                    End Try

                                    If Vendor IsNot Nothing Then

                                        If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                            ImportOrder.NetGross = 0

                                        Else

                                            ImportOrder.NetGross = 1

                                        End If

                                    Else

                                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                            ImportOrder.NetGross = 1

                                        Else

                                            ImportOrder.NetGross = 0

                                        End If

                                    End If

                                Else

                                    If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                        ImportOrder.NetGross = 1

                                    Else

                                        ImportOrder.NetGross = 0

                                    End If

                                End If

                            End If

                            ImportOrder.MediaNetAmount = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                            If MediaPlanData.MediaPlanDataDetails.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                                ImportOrder.AddAmount = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.AgencyFee)

                            Else

                                ImportOrder.AddAmount = 0

                            End If

                            If MediaPlanData.MediaPlanDataDetails.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                                ImportOrder.NetCharge = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.NetCharge)

                            Else

                                ImportOrder.NetCharge = 0

                            End If

                            'If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                            '	ImportOrder.NetRate = (MediaPlanData.MediaPlanDataDetails.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.85)
                            '	ImportOrder.GrossRate = MediaPlanData.MediaPlanDataDetails.Average(Function(LD) LD.Rate.GetValueOrDefault(0))

                            'Else

                            '	ImportOrder.NetRate = MediaPlanData.MediaPlanDataDetails.Average(Function(LD) LD.Rate.GetValueOrDefault(0))
                            '	ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (MediaPlanData.MediaPlanDataDetails.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.17647), 2)

                            'End If

                            SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                                     MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                                     MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                                     IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                                    ImportOrder.TotalSpots = 1

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                                If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                    End If

                                Else

                                    If MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                                MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                                MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                        End If

                                    ElseIf MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                                MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                                MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                        End If

                                    ElseIf MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                                MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                                MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                        End If

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                                If (MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                                    If IsColumns Then

                                        ImportOrder.CostType = "CPI"
                                        ImportOrder.RateType = "STD"

                                    ElseIf IsInchesLines Then

                                        ImportOrder.CostType = "CPL"
                                        ImportOrder.RateType = "STD"

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                                (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                                 MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                            ImportOrder.RateType = "CPM"

                                        Else

                                            ImportOrder.RateType = "STD"

                                        End If

                                    End If

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                                    ImportOrder.RateType = "STD"

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                                    ImportOrder.MediaPlanImpressions = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                                Else

                                    ImportOrder.MediaPlanImpressions = Nothing

                                End If

                            End If

                            SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

                            ImportOrder.Units = "M"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    Next

                Else

                    For Each MediaPlanData In (From Entity In MediaPlanningDataList
                                               Group By Entity.VendorCode,
                                                        Entity.Quarter,
                                                        Entity.Year,
                                                        Entity.RowIndex,
                                                        Entity.Rate,
                                                        Entity.OrderID,
                                                        Entity.OrderLineID Into MPD = Group
                                               Select VendorCode, Quarter, Year, RowIndex, Rate, OrderID, OrderLineID, MPD).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.Year).ThenBy(Function(E) E.Quarter)

                        IsUnits = False
                        IsImpressions = False
                        IsClicks = False
                        IsColumns = False
                        IsInchesLines = False

                        If MediaPlanData.VendorCode IsNot Nothing Then

                            StartDate = MediaPlanData.MPD.Min(Function(Entity) Entity.StartDate)
                            OrderStartDate = StartDate

                            If MediaPlanData.MPD.Any(Function(Entity) Entity.LineEndDate.HasValue) Then

                                EndDate = MediaPlanData.MPD.Where(Function(Entity) Entity.LineEndDate.HasValue).Max(Function(Entity) Entity.LineEndDate)

                            Else

                                EndDate = MediaPlan.EndDate

                            End If

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "M" OrElse
                                        MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlan.MediaPlanEstimate.IsCalendarMonth Then

                                    If MediaPlanData.Quarter = 1 Then

                                        LastDate = DateSerial(StartDate.Year, 3, 31)

                                    ElseIf MediaPlanData.Quarter = 2 Then

                                        LastDate = DateSerial(StartDate.Year, 6, 30)

                                    ElseIf MediaPlanData.Quarter = 3 Then

                                        LastDate = DateSerial(StartDate.Year, 9, 30)

                                    ElseIf MediaPlanData.Quarter = 4 Then

                                        LastDate = DateSerial(StartDate.Year, 12, 31)

                                    End If

                                    If EndDate > LastDate Then

                                        OrderEndDate = LastDate

                                    Else

                                        OrderEndDate = EndDate

                                    End If

                                Else

                                    LastDate = GetLastDayOfBroadcastQuarter(BroadcastCalendarWeeks, StartDate)

                                    If EndDate > LastDate Then

                                        OrderEndDate = LastDate

                                    Else

                                        OrderEndDate = EndDate

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If MediaPlan.MediaPlanEstimate.IsCalendarMonth AndAlso
                                        (CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.FromPlan OrElse
                                         CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.ByCalendar) Then

                                    LastDate = DateSerial(StartDate.Year, StartDate.Month + 1, 0)

                                    If EndDate > LastDate Then

                                        OrderEndDate = LastDate

                                    Else

                                        OrderEndDate = EndDate

                                    End If

                                Else

                                    LastDate = GetLastDayOfBroadcastMonth(DbContext, StartDate, BroadcastCalendarWeeks)

                                    If EndDate > LastDate Then

                                        OrderEndDate = LastDate

                                    Else

                                        OrderEndDate = EndDate

                                    End If

                                End If

                            End If

                            ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                            ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                            'ImportOrder.IsSourceMediaPlanning = True
                            ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                            ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                            ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                            ImportOrder.ClientCode = MediaPlan.ClientCode
                            ImportOrder.DivisionCode = MediaPlan.DivisionCode
                            ImportOrder.ProductCode = MediaPlan.ProductCode
                            ImportOrder.VendorCode = MediaPlanData.VendorCode

                            ImportOrder.StartDate = OrderStartDate
                            ImportOrder.EndDate = OrderEndDate

                            ImportOrder.UserCode = Session.UserCode
                            ImportOrder.CalendarType = If(MediaPlan.MediaPlanEstimate.IsCalendarMonth AndAlso
                                                            (CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.FromPlan OrElse
                                                            CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.ByCalendar), "CM", "BM")

                            ImportOrder.OrderID = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderID)
                            ImportOrder.LineNumber = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderLineID)
                            ImportOrder.OrderNumber = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderNumber)
                            ImportOrder.OrderLineNumber = MediaPlanData.MPD.Max(Function(Entity) Entity.OrderLineNumber)

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            If ImportOrder.OrderID.HasValue AndAlso ImportOrder.OrderID.GetValueOrDefault(0) <> 0 AndAlso ImportOrder.LineNumber.HasValue AndAlso ImportOrder.LineNumber.GetValueOrDefault(0) <> 0 Then

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.OrderID = ImportOrder.OrderID AndAlso Entity.LineNumber = ImportOrder.LineNumber) = True Then

                                    If ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                               Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                               Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                               Entity.LineNumber <> ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) <> ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate <> ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    End If

                                End If

                            Else

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).Any(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                            Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                            Entity.OrderNumber.GetValueOrDefault(0) <> 0) = True Then

                                    ImportOrder.OrderID = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                             Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                             Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderID

                                    ImportOrder.OrderNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                                 Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                                 Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderNumber

                                    ImportOrder.LineNumber = Nothing
                                    ImportOrder.OrderLineNumber = Nothing

                                End If

                            End If

                            If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                                ImportOrder.IsRevision = True

                            End If

                            ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                            SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.MPD.FirstOrDefault.RowIndex, MediaPlanData.VendorCode)

                            MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MPD
                                                                  Select Entity.MediaPlanDetailLevelLineDataID).ToList

                            ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                            If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                                Try

                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    ImportOrder.CampaignCode = Campaign.Code
                                    ImportOrder.Campaign = Campaign.Name

                                End If

                            End If

                            If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                                GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                            Else

                                If UseVendorsRateType Then

                                    Try

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                                    Catch ex As Exception
                                        Vendor = Nothing
                                    End Try

                                    If Vendor IsNot Nothing Then

                                        If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                            ImportOrder.NetGross = 0

                                        Else

                                            ImportOrder.NetGross = 1

                                        End If

                                    Else

                                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                            ImportOrder.NetGross = 1

                                        Else

                                            ImportOrder.NetGross = 0

                                        End If

                                    End If

                                Else

                                    If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                        ImportOrder.NetGross = 1

                                    Else

                                        ImportOrder.NetGross = 0

                                    End If

                                End If

                            End If

                            ImportOrder.MediaNetAmount = MediaPlanData.MPD.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                            If MediaPlanData.MPD.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                                ImportOrder.AddAmount = MediaPlanData.MPD.Sum(Function(LD) LD.AgencyFee)

                            Else

                                ImportOrder.AddAmount = 0

                            End If

                            If MediaPlanData.MPD.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                                ImportOrder.NetCharge = MediaPlanData.MPD.Sum(Function(LD) LD.NetCharge)

                            Else

                                ImportOrder.NetCharge = 0

                            End If

                            'If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                            '	ImportOrder.NetRate = (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.85)
                            '	ImportOrder.GrossRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))

                            'Else

                            '	ImportOrder.NetRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))
                            '	ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.17647), 2)

                            'End If

                            SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                                     MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                                     MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                                     IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                                    ImportOrder.TotalSpots = 1

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                                If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                    End If

                                Else

                                    If MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                                MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                                MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                        End If

                                    ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                                MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                                MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                        End If

                                    ElseIf MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                                MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                                MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                        End If

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                                If (MediaPlanData.MPD.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                                        MediaPlanData.MPD.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                                    If IsColumns Then

                                        ImportOrder.CostType = "CPI"
                                        ImportOrder.RateType = "STD"

                                    ElseIf IsInchesLines Then

                                        ImportOrder.CostType = "CPL"
                                        ImportOrder.RateType = "STD"

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                                (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                                 MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                            ImportOrder.RateType = "CPM"

                                        Else

                                            ImportOrder.RateType = "STD"

                                        End If

                                    End If

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                                    ImportOrder.RateType = "STD"

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                                    ImportOrder.MediaPlanImpressions = MediaPlanData.MPD.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                                Else

                                    ImportOrder.MediaPlanImpressions = Nothing

                                End If

                            End If

                            SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

                            ImportOrder.Units = "M"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    Next

                End If

                DbContext.Database.Connection.Close()

            End Using

            BuildQuarterOrderList = ImportOrderList

        End Function
        Private Function GetWeek(ByVal Day As Date, ByVal IsCalendarMonth As Boolean, ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Integer

            Dim Week As Integer = Nothing
            Dim MaxWeekDate As Nullable(Of Date) = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            If IsCalendarMonth Then

                Week = CInt(System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear(Day, System.Globalization.CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday))

            Else

                MaxWeekDate = (From Dates In BroadcastCalendarWeeks
                               Where Dates.WeekDate <= Day
                               Select Dates.WeekDate).Max

                If MaxWeekDate IsNot Nothing Then

                    BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
                                             Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

                    If BroadcastCalendarWeek IsNot Nothing Then

                        Week = BroadcastCalendarWeek.Week

                    End If

                End If

            End If

            GetWeek = Week

        End Function
        Public Function GetYear(ByVal [Date] As Date, ByVal IsCalendarMonth As Boolean, ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Integer

            'objects
            Dim Year As Integer = 0
            Dim RevisedDate As Date = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            If [Date] <> Nothing Then

                If IsCalendarMonth Then

                    Year = [Date].Year

                Else

                    RevisedDate = [Date]

                    Do Until RevisedDate.DayOfWeek = DayOfWeek.Monday

                        RevisedDate = RevisedDate.AddDays(-1)

                    Loop

                    If BroadcastCalendarWeeks IsNot Nothing AndAlso BroadcastCalendarWeeks.Count > 0 Then

                        Try

                            BroadcastCalendarWeek = BroadcastCalendarWeeks.SingleOrDefault(Function(Entity) Entity.WeekDate = RevisedDate)

                        Catch ex As Exception
                            BroadcastCalendarWeek = Nothing
                        End Try

                    End If

                    If BroadcastCalendarWeek IsNot Nothing Then

                        Year = BroadcastCalendarWeek.Year

                    Else

                        Year = RevisedDate.Year

                    End If

                End If

            End If

            GetYear = Year

        End Function
        Public Function GetYearForEstimate(ByVal [Date] As Date, ByVal IsCalendarMonth As Boolean, ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Integer

            'objects
            Dim Year As Integer = 0
            Dim RevisedDate As Date = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            If [Date] <> Nothing Then

                If IsCalendarMonth Then

                    Year = [Date].Year

                Else

                    RevisedDate = [Date]

                    Do Until RevisedDate.DayOfWeek = DayOfWeek.Monday

                        RevisedDate = RevisedDate.AddDays(-1)

                    Loop

                    If BroadcastCalendarWeeks IsNot Nothing AndAlso BroadcastCalendarWeeks.Count > 0 Then

                        Try

                            BroadcastCalendarWeek = BroadcastCalendarWeeks.SingleOrDefault(Function(Entity) Entity.WeekDate = RevisedDate)

                        Catch ex As Exception
                            BroadcastCalendarWeek = Nothing
                        End Try

                    End If

                    If BroadcastCalendarWeek IsNot Nothing Then

                        Year = BroadcastCalendarWeek.Year

                    Else

                        Year = RevisedDate.Year

                    End If

                End If

            End If

            GetYearForEstimate = Year

        End Function
        Public Function GetQuarterForEstimate(ByVal [Date] As Date, ByVal IsCalendarMonth As Boolean, ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek), Optional ByRef Year As Integer = 0) As Integer

            'objects
            Dim Quarter As Integer = 0
            Dim RevisedDate As Date = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            Year = 0

            If [Date] <> Nothing Then

                If IsCalendarMonth Then

                    Quarter = CInt(Math.Ceiling([Date].Month / 3))
                    Year = [Date].Year

                Else

                    RevisedDate = [Date]

                    Do Until RevisedDate.DayOfWeek = DayOfWeek.Monday

                        RevisedDate = RevisedDate.AddDays(-1)

                    Loop

                    If BroadcastCalendarWeeks IsNot Nothing AndAlso BroadcastCalendarWeeks.Count > 0 Then

                        Try

                            BroadcastCalendarWeek = BroadcastCalendarWeeks.SingleOrDefault(Function(Entity) Entity.WeekDate = RevisedDate)

                        Catch ex As Exception
                            BroadcastCalendarWeek = Nothing
                        End Try

                    End If

                    If BroadcastCalendarWeek IsNot Nothing Then

                        Quarter = CInt(Math.Ceiling(BroadcastCalendarWeek.Month / 3))
                        Year = BroadcastCalendarWeek.Year

                    Else

                        Quarter = CInt(Math.Ceiling(RevisedDate.Month / 3))
                        Year = RevisedDate.Year

                    End If

                End If

            End If

            GetQuarterForEstimate = Quarter

        End Function
        Public Function GetMonthForEstimate(ByVal [Date] As Date, ByVal IsCalendarMonth As Boolean, ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek), Optional ByRef Year As Integer = 0) As Integer

            'objects
            Dim Month As Integer = 0
            Dim RevisedDate As Date = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            Year = 0

            If [Date] <> Nothing Then

                If IsCalendarMonth Then

                    Month = [Date].Month
                    Year = [Date].Year

                Else

                    RevisedDate = [Date]

                    Do Until RevisedDate.DayOfWeek = DayOfWeek.Monday

                        RevisedDate = RevisedDate.AddDays(-1)

                    Loop

                    If BroadcastCalendarWeeks IsNot Nothing AndAlso BroadcastCalendarWeeks.Count > 0 Then

                        Try

                            BroadcastCalendarWeek = BroadcastCalendarWeeks.SingleOrDefault(Function(Entity) Entity.WeekDate = RevisedDate)

                        Catch ex As Exception
                            BroadcastCalendarWeek = Nothing
                        End Try

                    End If

                    If BroadcastCalendarWeek IsNot Nothing Then

                        Month = BroadcastCalendarWeek.Month
                        Year = BroadcastCalendarWeek.Year

                    Else

                        Month = RevisedDate.Month
                        Year = RevisedDate.Year

                    End If

                End If

            End If

            GetMonthForEstimate = Month

        End Function
        Public Function GetWeekForEstimate(ByVal [Date] As Date, ByVal IsCalendarMonth As Boolean, ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Integer

            'objects
            Dim Week As Integer = 0
            Dim RevisedDate As Date = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            If [Date] <> Nothing Then

                If IsCalendarMonth Then

                    Week = CInt(System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear([Date], System.Globalization.CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday))

                Else

                    RevisedDate = [Date]

                    Do Until RevisedDate.DayOfWeek = DayOfWeek.Monday

                        RevisedDate = RevisedDate.AddDays(-1)

                    Loop

                    If BroadcastCalendarWeeks IsNot Nothing AndAlso BroadcastCalendarWeeks.Count > 0 Then

                        Try

                            BroadcastCalendarWeek = BroadcastCalendarWeeks.SingleOrDefault(Function(Entity) Entity.WeekDate = RevisedDate)

                        Catch ex As Exception
                            BroadcastCalendarWeek = Nothing
                        End Try

                    End If

                    If BroadcastCalendarWeek IsNot Nothing Then

                        Week = BroadcastCalendarWeek.Week

                    Else

                        If CInt(System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear("12/31/" & [Date].Year, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)) = 54 Then

                            Week = If(CInt(System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear([Date], System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)) = 54, 1, CInt(System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear([Date], System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)))

                        Else

                            Week = If(CInt(System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear([Date], System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)) = 53, 1, CInt(System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear([Date], System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)))

                        End If

                    End If

                End If

            End If

            GetWeekForEstimate = Week

        End Function
        Public Function GetWeekDateForEstimate(ByVal [Date] As Date, ByVal IsCalendarMonth As Boolean,
                                               ByVal BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek,
                                               ByVal SplitWeeks As Boolean) As Date

            'objects
            Dim WeekDate As Date = Nothing
            Dim RevisedDate As Date = Nothing

            If [Date] <> Nothing Then

                RevisedDate = [Date]

                If IsCalendarMonth Then

                    If SplitWeeks Then

                        If [Date].Day < 7 Then

                            Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday OrElse RevisedDate.Day = 1

                                RevisedDate = RevisedDate.AddDays(-1)

                            Loop

                        Else

                            Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday

                                RevisedDate = RevisedDate.AddDays(-1)

                            Loop

                        End If

                    Else

                        Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday

                            RevisedDate = RevisedDate.AddDays(-1)

                        Loop

                    End If

                    WeekDate = RevisedDate

                Else

                    If BroadcastCalendarWeek IsNot Nothing Then

                        WeekDate = BroadcastCalendarWeek.WeekDate

                    Else

                        WeekDate = RevisedDate

                    End If

                End If

            End If

            GetWeekDateForEstimate = WeekDate

        End Function
        Public Function GetCalendarMonthWeekDateForEstimate([Date] As Date, SplitWeeks As Boolean) As Date

            'objects
            Dim WeekDate As Date = Nothing
            Dim RevisedDate As Date = Nothing

            If [Date] <> Nothing Then

                RevisedDate = [Date]

                If SplitWeeks Then

                    If [Date].Day < 7 Then

                        Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday OrElse RevisedDate.Day = 1

                            RevisedDate = RevisedDate.AddDays(-1)

                        Loop

                    Else

                        Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday

                            RevisedDate = RevisedDate.AddDays(-1)

                        Loop

                    End If

                Else

                    Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday

                        RevisedDate = RevisedDate.AddDays(-1)

                    Loop

                End If

                WeekDate = RevisedDate

            End If

            GetCalendarMonthWeekDateForEstimate = WeekDate

        End Function
        Public Function GetWeekDateForEstimate(ByVal [Date] As Date, ByVal IsCalendarMonth As Boolean,
                                               ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek), ByVal SplitWeeks As Boolean) As Date

            'objects
            Dim WeekDate As Date = Nothing
            Dim RevisedDate As Date = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            If [Date] <> Nothing Then

                RevisedDate = [Date]

                If IsCalendarMonth Then

                    If SplitWeeks Then

                        If [Date].Day < 7 Then

                            Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday OrElse RevisedDate.Day = 1

                                RevisedDate = RevisedDate.AddDays(-1)

                            Loop

                        Else

                            Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday

                                RevisedDate = RevisedDate.AddDays(-1)

                            Loop

                        End If

                    Else

                        Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday

                            RevisedDate = RevisedDate.AddDays(-1)

                        Loop

                    End If

                    WeekDate = RevisedDate

                Else

                    Do Until RevisedDate.DayOfWeek = DayOfWeek.Monday

                        RevisedDate = RevisedDate.AddDays(-1)

                    Loop

                    If BroadcastCalendarWeeks IsNot Nothing AndAlso BroadcastCalendarWeeks.Count > 0 Then

                        Try

                            BroadcastCalendarWeek = BroadcastCalendarWeeks.FirstOrDefault(Function(Entity) Entity.WeekDate = RevisedDate)

                        Catch ex As Exception
                            BroadcastCalendarWeek = Nothing
                        End Try

                    End If

                    If BroadcastCalendarWeek IsNot Nothing Then

                        WeekDate = BroadcastCalendarWeek.WeekDate

                    Else

                        WeekDate = RevisedDate

                    End If

                End If

            End If

            GetWeekDateForEstimate = WeekDate

        End Function
        Private Function GetWeeksForMonth(PlanStartDate As Date, Year As Integer, Month As Integer,
                                          IsCalendarMonth As Boolean, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Generic.List(Of Integer)

            'objects
            Dim Week As Integer = 0
            Dim Weeks As Generic.List(Of Integer) = Nothing
            Dim StartDate As Date = Date.MinValue
            Dim MonthBroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing

            Weeks = New Generic.List(Of Integer)

            StartDate = New Date(Year, Month, 1)

            If StartDate <> Date.MinValue Then

                If IsCalendarMonth Then

                    If StartDate < PlanStartDate Then

                        StartDate = PlanStartDate

                    End If

                    Do While StartDate.Month = Month

                        Week = CInt(System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar.GetWeekOfYear(StartDate, System.Globalization.CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday))

                        If Weeks.Contains(Week) = False Then

                            Weeks.Add(Week)

                        End If

                        StartDate = StartDate.AddDays(1)

                    Loop

                Else

                    MonthBroadcastCalendarWeeks = BroadcastCalendarWeeks.Where(Function(Entity) Entity.Month = Month AndAlso Entity.Year = Year).ToList

                    For Each MBCW In MonthBroadcastCalendarWeeks

                        If (MBCW.WeekDate < PlanStartDate AndAlso MBCW.WeekDate.AddDays(6) < PlanStartDate) = False Then

                            Weeks.Add(MBCW.Week)

                        End If

                    Next

                End If

            End If

            GetWeeksForMonth = Weeks

        End Function
        Private Function GetNextSaturday(ByVal Day As Date) As Date

            'objects
            Dim Saturday As Date = Nothing

            For DayCounter As Integer = 0 To 6

                If Day.AddDays(DayCounter).DayOfWeek = DayOfWeek.Saturday Then

                    Saturday = Day.AddDays(DayCounter)

                    Exit For

                End If

            Next

            GetNextSaturday = Saturday

        End Function
        Private Function GetBroadcastMonthStartDate(Month As Integer, Year As Integer, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            'objects
            Dim BroadcastMonthStartDate As Date = Date.MinValue
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            BroadcastCalendarWeek = BroadcastCalendarWeeks.Where(Function(Entity) Entity.Month = Month AndAlso Entity.Year = Year).OrderBy(Function(Entity) Entity.WeekDate).FirstOrDefault

            If BroadcastCalendarWeek IsNot Nothing Then

                BroadcastMonthStartDate = BroadcastCalendarWeek.WeekDate

            End If

            GetBroadcastMonthStartDate = BroadcastMonthStartDate

        End Function
        Private Function GetWeekOrderEndDate(DbContext As AdvantageFramework.Database.DbContext,
                                             MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                             MediaPlanData As AdvantageFramework.MediaPlanning.Classes.MediaPlanData,
                                             StartDate As Date,
                                             IsCalendarMonth As Boolean,
                                             BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek),
                                             CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType,
                                             IsLastDate As Boolean) As Date

            'objects
            Dim OrderEndDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue
            Dim LastDate As Date = Date.MinValue
            Dim FourWeekEndDate As Date = Date.MinValue

            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                If MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                    If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.LineEndDate.HasValue) Then

                        EndDate = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) Entity.LineEndDate.HasValue).Max(Function(Entity) Entity.LineEndDate)

                    Else

                        EndDate = MediaPlan.EndDate

                    End If

                    If IsCalendarMonth Then

                        LastDate = GetNextSaturday(StartDate)

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    Else

                        LastDate = GetLastDayOfBroadcastWeek(DbContext, MediaPlanData.Week, MediaPlanData.Year, BroadcastCalendarWeeks)

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    End If

                Else

                    If IsLastDate Then

                        EndDate = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.EndDate)

                    Else

                        EndDate = MediaPlan.EndDate

                    End If

                    If IsCalendarMonth Then

                        LastDate = GetNextSaturday(StartDate)

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    Else

                        LastDate = GetLastDayOfBroadcastWeek(DbContext, MediaPlanData.Week, MediaPlanData.Year, BroadcastCalendarWeeks)

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    End If

                End If

            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "M" Then

                If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.LineEndDate.HasValue) Then

                    EndDate = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) Entity.LineEndDate.HasValue).Max(Function(Entity) Entity.LineEndDate)

                Else

                    EndDate = MediaPlan.EndDate

                End If

                If IsCalendarMonth Then

                    LastDate = GetNextSaturday(StartDate)

                    If EndDate > LastDate Then

                        OrderEndDate = LastDate

                    Else

                        OrderEndDate = EndDate

                    End If

                Else

                    LastDate = GetLastDayOfBroadcastWeek(DbContext, MediaPlanData.Week, MediaPlanData.Year, BroadcastCalendarWeeks)

                    If EndDate > LastDate Then

                        OrderEndDate = LastDate

                    Else

                        OrderEndDate = EndDate

                    End If

                End If

            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.LineEndDate.HasValue) Then

                    EndDate = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) Entity.LineEndDate.HasValue).Max(Function(Entity) Entity.LineEndDate)

                Else

                    EndDate = MediaPlan.EndDate

                End If

                If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.StartDate <> Entity.EndDate) Then

                    FourWeekEndDate = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.EndDate)

                Else

                    FourWeekEndDate = Date.MinValue

                End If

                If FourWeekEndDate = Date.MinValue Then

                    If IsCalendarMonth Then

                        LastDate = GetNextSaturday(StartDate)

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    Else

                        LastDate = GetLastDayOfBroadcastWeek(DbContext, MediaPlanData.Week, MediaPlanData.Year, BroadcastCalendarWeeks)

                        If EndDate > LastDate Then

                            OrderEndDate = LastDate

                        Else

                            OrderEndDate = EndDate

                        End If

                    End If

                Else

                    OrderEndDate = FourWeekEndDate

                End If

            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                If MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.LineEndDate.HasValue) Then

                    EndDate = MediaPlanData.MediaPlanDataDetails.Where(Function(Entity) Entity.LineEndDate.HasValue).Max(Function(Entity) Entity.LineEndDate)

                Else

                    EndDate = MediaPlan.EndDate

                End If

                If IsCalendarMonth AndAlso
                        (CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.FromPlan OrElse CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.ByCalendar) Then

                    LastDate = DateSerial(StartDate.Year, StartDate.Month + 1, 0)

                    If EndDate > LastDate Then

                        OrderEndDate = LastDate

                    Else

                        OrderEndDate = EndDate

                    End If

                Else

                    LastDate = GetLastDayOfBroadcastWeek(DbContext, MediaPlanData.Week, MediaPlanData.Year, BroadcastCalendarWeeks)

                    If EndDate > LastDate Then

                        OrderEndDate = LastDate

                    Else

                        OrderEndDate = EndDate

                    End If

                End If

            End If

            GetWeekOrderEndDate = OrderEndDate

        End Function
        Public Function BuildWeekOrderList(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                           MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData),
                                           Session As AdvantageFramework.Security.Session,
                                           DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                           CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType,
                                           BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ImportOrder As AdvantageFramework.Media.Classes.ImportOrder = Nothing
            Dim MediaPlanDetailLevelLineDataIDList As Generic.List(Of Integer) = Nothing
            Dim StartDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue
            Dim LastDate As Date = Date.MinValue
            Dim OrderStartDate As Date = Date.MinValue
            Dim OrderEndDate As Date = Date.MinValue
            Dim FourWeekEndDate As Date = Date.MinValue
            Dim MediaPlanDataList As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanData) = Nothing
            Dim IsUnits As Boolean = False
            Dim IsImpressions As Boolean = False
            Dim IsClicks As Boolean = False
            Dim IsColumns As Boolean = False
            Dim IsInchesLines As Boolean = False
            Dim MediaPlanDataLastDateList As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanData) = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim UseVendorsRateType As Boolean = False
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    UseVendorsRateType = AdvantageFramework.Agency.LoadVendorsRateTypeSetting(DataContext)

                End Using

                MediaPlan.SelectMediaPlanEstimateByMediaPlanDetailID(CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID)

                If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                    MediaPlan.MediaPlanEstimate.RefreshEntryDates()

                    MediaPlanDataList = (From Entity In MediaPlanningDataList
                                         Group By Entity.VendorCode,
                                                  Week = GetWeek(Entity.StartDate, MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks),
                                                  Entity.Year,
                                                  Entity.RowIndex,
                                                  Entity.Rate,
                                                  DayOfWeeks = CreateDayOfWeeks(MediaPlan.MediaPlanEstimate, New Integer() {Entity.RowIndex}, New Date() {Entity.StartDate}),
                                                  Entity.OrderID,
                                                  Entity.OrderLineID Into MPD = Group
                                         Select New MediaPlanning.Classes.MediaPlanData With {.VendorCode = VendorCode,
                                                                                              .Week = Week,
                                                                                              .Year = Year,
                                                                                              .RowIndex = RowIndex,
                                                                                              .Rate = Rate,
                                                                                              .DayOfWeeks = DayOfWeeks,
                                                                                              .MediaPlanDataDetails = MPD.ToList}).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.Year).ThenBy(Function(E) E.Week).ToList

                    For Each MediaPlanData In MediaPlanDataList

                        IsUnits = False
                        IsImpressions = False
                        IsClicks = False
                        IsColumns = False
                        IsInchesLines = False

                        If MediaPlanData.VendorCode IsNot Nothing Then

                            StartDate = MediaPlanData.MediaPlanDataDetails.Min(Function(Entity) Entity.StartDate)
                            OrderStartDate = StartDate
                            OrderEndDate = GetWeekOrderEndDate(DbContext, MediaPlan, MediaPlanData, OrderStartDate,
                                                               MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks, CreateOrderBroadcastCalendarType,
                                                               False)

                            ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                            ImportOrder.MediaPlanMonday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Monday = True)
                            ImportOrder.MediaPlanTuesday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Tuesday = True)
                            ImportOrder.MediaPlanWednesday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Wednesday = True)
                            ImportOrder.MediaPlanThursday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Thursday = True)
                            ImportOrder.MediaPlanFriday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Friday = True)
                            ImportOrder.MediaPlanSaturday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Saturday = True)
                            ImportOrder.MediaPlanSunday = MediaPlanData.MediaPlanDataDetails.Any(Function(Entity) Entity.Sunday = True)

                            ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                            'ImportOrder.IsSourceMediaPlanning = True
                            ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                            ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                            ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                            ImportOrder.ClientCode = MediaPlan.ClientCode
                            ImportOrder.DivisionCode = MediaPlan.DivisionCode
                            ImportOrder.ProductCode = MediaPlan.ProductCode
                            ImportOrder.VendorCode = MediaPlanData.VendorCode

                            ImportOrder.StartDate = OrderStartDate
                            ImportOrder.EndDate = OrderEndDate

                            ImportOrder.UserCode = Session.UserCode
                            ImportOrder.CalendarType = If(MediaPlan.MediaPlanEstimate.IsCalendarMonth AndAlso
                                                            (CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.FromPlan OrElse
                                                             CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.ByCalendar), "CM", "BM")

                            ImportOrder.OrderID = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderID)
                            ImportOrder.LineNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderLineID)
                            ImportOrder.OrderNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderNumber)
                            ImportOrder.OrderLineNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderLineNumber)

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            ImportOrder.MediaPlanDayOfWeeks = MediaPlanData.DayOfWeeks

                            If ImportOrder.OrderID.HasValue AndAlso ImportOrder.OrderID.GetValueOrDefault(0) <> 0 AndAlso ImportOrder.LineNumber.HasValue AndAlso ImportOrder.LineNumber.GetValueOrDefault(0) <> 0 Then

                                ImportOrder.MediaPlanDayOfWeeks = MediaPlanData.DayOfWeeks

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.OrderID = ImportOrder.OrderID AndAlso Entity.LineNumber = ImportOrder.LineNumber) = True Then

                                    If ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                               Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                               Entity.MediaPlanDayOfWeeks = ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                               Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                               Entity.LineNumber <> ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) <> ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.MediaPlanDayOfWeeks = ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.MediaPlanDayOfWeeks <> ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) <> ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.MediaPlanDayOfWeeks <> ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate <> ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.MediaPlanDayOfWeeks = ImportOrder.MediaPlanDayOfWeeks AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    End If

                                End If

                            Else

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).Any(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                            Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                            Entity.OrderNumber.GetValueOrDefault(0) <> 0) = True Then

                                    ImportOrder.OrderID = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                             Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                             Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderID

                                    ImportOrder.OrderNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                                 Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                                 Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderNumber

                                    ImportOrder.LineNumber = Nothing
                                    ImportOrder.OrderLineNumber = Nothing

                                End If

                            End If

                            If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                                ImportOrder.IsRevision = True

                            End If

                            ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                            SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.RowIndex, MediaPlanData.VendorCode)

                            MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MediaPlanDataDetails
                                                                  Select Entity.MediaPlanDetailLevelLineDataID).ToList

                            ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                            If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                                Try

                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    ImportOrder.CampaignCode = Campaign.Code
                                    ImportOrder.Campaign = Campaign.Name

                                End If

                            End If

                            If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                                GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                            Else

                                If UseVendorsRateType Then

                                    Try

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                                    Catch ex As Exception
                                        Vendor = Nothing
                                    End Try

                                    If Vendor IsNot Nothing Then

                                        If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                            ImportOrder.NetGross = 0

                                        Else

                                            ImportOrder.NetGross = 1

                                        End If

                                    Else

                                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                            ImportOrder.NetGross = 1

                                        Else

                                            ImportOrder.NetGross = 0

                                        End If

                                    End If

                                Else

                                    If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                        ImportOrder.NetGross = 1

                                    Else

                                        ImportOrder.NetGross = 0

                                    End If

                                End If

                            End If

                            ImportOrder.MediaNetAmount = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                            If MediaPlanData.MediaPlanDataDetails.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                                ImportOrder.AddAmount = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.AgencyFee)

                            Else

                                ImportOrder.AddAmount = 0

                            End If

                            If MediaPlanData.MediaPlanDataDetails.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                                ImportOrder.NetCharge = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.NetCharge)

                            Else

                                ImportOrder.NetCharge = 0

                            End If

                            'If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                            '	ImportOrder.NetRate = (MediaPlanData.MediaPlanDataDetails.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.85)
                            '	ImportOrder.GrossRate = MediaPlanData.MediaPlanDataDetails.Average(Function(LD) LD.Rate.GetValueOrDefault(0))

                            'Else

                            '	ImportOrder.NetRate = MediaPlanData.MediaPlanDataDetails.Average(Function(LD) LD.Rate.GetValueOrDefault(0))
                            '	ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (MediaPlanData.MediaPlanDataDetails.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.17647), 2)

                            'End If

                            SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                                     MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                                     MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                                     IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                                    ImportOrder.TotalSpots = 1

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                                If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                    End If

                                Else

                                    If MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                        End If

                                    ElseIf MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                        End If

                                    ElseIf MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                        End If

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                                If (MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                                    If IsColumns Then

                                        ImportOrder.CostType = "CPI"
                                        ImportOrder.RateType = "STD"

                                    ElseIf IsInchesLines Then

                                        ImportOrder.CostType = "CPL"
                                        ImportOrder.RateType = "STD"

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                                (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                                 MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                            ImportOrder.RateType = "CPM"

                                        Else

                                            ImportOrder.RateType = "STD"

                                        End If

                                    End If

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                                    ImportOrder.RateType = "STD"

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                                    ImportOrder.MediaPlanImpressions = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                                Else

                                    ImportOrder.MediaPlanImpressions = Nothing

                                End If

                            End If

                            SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

                            ImportOrder.Units = "W"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    Next

                ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                    MediaPlanDataList = (From Entity In MediaPlanningDataList
                                         Group By Entity.VendorCode,
                                                  Week = GetWeek(Entity.StartDate, MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks),
                                                  Year = GetYear(Entity.StartDate, MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks),
                                                  Entity.RowIndex,
                                                  Entity.Rate,
                                                  Entity.OrderID,
                                                  Entity.OrderLineID Into MPD = Group
                                         Select New MediaPlanning.Classes.MediaPlanData With {.VendorCode = VendorCode,
                                                                                              .Week = Week,
                                                                                              .Year = Year,
                                                                                              .RowIndex = RowIndex,
                                                                                              .Rate = Rate,
                                                                                              .MediaPlanDataDetails = MPD.ToList}).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.Year).ThenBy(Function(E) E.Week).ToList

                    MediaPlanDataLastDateList = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanData)

                    If MediaPlan.MediaPlanEstimate.PeriodType <> AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                        For Each VendorCode In MediaPlanDataList.Select(Function(Entity) Entity.VendorCode).Distinct

                            For Each RowIndex In MediaPlanDataList.Where(Function(Entity) Entity.VendorCode = VendorCode).Select(Function(Entity) Entity.RowIndex).Distinct

                                MediaPlanDataLastDateList.Add(MediaPlanDataList.Where(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.RowIndex = RowIndex).Last)

                            Next

                        Next

                    End If

                    For Each MediaPlanData In MediaPlanDataList

                        IsUnits = False
                        IsImpressions = False
                        IsClicks = False
                        IsColumns = False
                        IsInchesLines = False

                        If MediaPlanData.VendorCode IsNot Nothing Then

                            StartDate = MediaPlanData.MediaPlanDataDetails.Min(Function(Entity) Entity.StartDate)
                            OrderStartDate = StartDate
                            OrderEndDate = GetWeekOrderEndDate(DbContext, MediaPlan, MediaPlanData, OrderStartDate,
                                                               MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks, CreateOrderBroadcastCalendarType,
                                                               MediaPlanDataLastDateList.Contains(MediaPlanData))

                            ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                            ImportOrder.MediaPlanMonday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Monday
                            ImportOrder.MediaPlanTuesday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Tuesday
                            ImportOrder.MediaPlanWednesday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Wednesday
                            ImportOrder.MediaPlanThursday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Thursday
                            ImportOrder.MediaPlanFriday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Friday
                            ImportOrder.MediaPlanSaturday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Saturday
                            ImportOrder.MediaPlanSunday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Sunday

                            ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                            'ImportOrder.IsSourceMediaPlanning = True
                            ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                            ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                            ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                            ImportOrder.ClientCode = MediaPlan.ClientCode
                            ImportOrder.DivisionCode = MediaPlan.DivisionCode
                            ImportOrder.ProductCode = MediaPlan.ProductCode
                            ImportOrder.VendorCode = MediaPlanData.VendorCode

                            ImportOrder.StartDate = OrderStartDate
                            ImportOrder.EndDate = OrderEndDate

                            ImportOrder.UserCode = Session.UserCode
                            ImportOrder.CalendarType = If(MediaPlan.MediaPlanEstimate.IsCalendarMonth AndAlso
                                                        (CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.FromPlan OrElse
                                                        CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.ByCalendar), "CM", "BM")

                            ImportOrder.OrderID = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderID)
                            ImportOrder.LineNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderLineID)
                            ImportOrder.OrderNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderNumber)
                            ImportOrder.OrderLineNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderLineNumber)

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            If ImportOrder.OrderID.HasValue AndAlso ImportOrder.OrderID.GetValueOrDefault(0) <> 0 AndAlso ImportOrder.LineNumber.HasValue AndAlso ImportOrder.LineNumber.GetValueOrDefault(0) <> 0 Then

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.OrderID = ImportOrder.OrderID AndAlso Entity.LineNumber = ImportOrder.LineNumber) = True Then

                                    If ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                               Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                               Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                               Entity.LineNumber <> ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) <> ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate <> ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    End If

                                End If

                            Else

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).Any(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                            Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                            Entity.OrderNumber.GetValueOrDefault(0) <> 0) = True Then

                                    ImportOrder.OrderID = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                             Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                             Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderID

                                    ImportOrder.OrderNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                                 Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                                 Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderNumber

                                    ImportOrder.LineNumber = Nothing
                                    ImportOrder.OrderLineNumber = Nothing

                                End If

                            End If

                            If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                                ImportOrder.IsRevision = True

                            End If

                            ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                            SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.MediaPlanDataDetails.FirstOrDefault.RowIndex, MediaPlanData.VendorCode)

                            MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MediaPlanDataDetails
                                                                  Select Entity.MediaPlanDetailLevelLineDataID).ToList

                            ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                            If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                                Try

                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    ImportOrder.CampaignCode = Campaign.Code
                                    ImportOrder.Campaign = Campaign.Name

                                End If

                            End If

                            If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                                GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                            Else

                                If UseVendorsRateType Then

                                    Try

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                                    Catch ex As Exception
                                        Vendor = Nothing
                                    End Try

                                    If Vendor IsNot Nothing Then

                                        If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                            ImportOrder.NetGross = 0

                                        Else

                                            ImportOrder.NetGross = 1

                                        End If

                                    Else

                                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                            ImportOrder.NetGross = 1

                                        Else

                                            ImportOrder.NetGross = 0

                                        End If

                                    End If

                                Else

                                    If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                        ImportOrder.NetGross = 1

                                    Else

                                        ImportOrder.NetGross = 0

                                    End If

                                End If

                            End If

                            ImportOrder.MediaNetAmount = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                            If MediaPlanData.MediaPlanDataDetails.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                                ImportOrder.AddAmount = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.AgencyFee)

                            Else

                                ImportOrder.AddAmount = 0

                            End If

                            If MediaPlanData.MediaPlanDataDetails.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                                ImportOrder.NetCharge = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.NetCharge)

                            Else

                                ImportOrder.NetCharge = 0

                            End If
                            'If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                            '	ImportOrder.NetRate = (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.85)
                            '	ImportOrder.GrossRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))

                            'Else

                            '	ImportOrder.NetRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))
                            '	ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.17647), 2)

                            'End If

                            SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                                     MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                                     MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                                     IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                                    ImportOrder.TotalSpots = 1

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                                If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                    End If

                                Else

                                    If MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                        End If

                                    ElseIf MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                        End If

                                    ElseIf MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                        End If

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                                If (MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                                    If IsColumns Then

                                        ImportOrder.CostType = "CPI"
                                        ImportOrder.RateType = "STD"

                                    ElseIf IsInchesLines Then

                                        ImportOrder.CostType = "CPL"
                                        ImportOrder.RateType = "STD"

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                                (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                                 MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                            ImportOrder.RateType = "CPM"

                                        Else

                                            ImportOrder.RateType = "STD"

                                        End If

                                    End If

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                                    ImportOrder.RateType = "STD"

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                                    ImportOrder.MediaPlanImpressions = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                                Else

                                    ImportOrder.MediaPlanImpressions = Nothing

                                End If

                            End If

                            SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

                            ImportOrder.Units = "W"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    Next

                Else

                    MediaPlanDataList = (From Entity In MediaPlanningDataList
                                         Group By Entity.VendorCode,
                                                  Week = GetWeek(Entity.StartDate, MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks),
                                                  Year = GetYear(Entity.StartDate, MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks),
                                                  Entity.RowIndex,
                                                  Entity.Rate,
                                                  Entity.OrderID,
                                                  Entity.OrderLineID Into MPD = Group
                                         Select New MediaPlanning.Classes.MediaPlanData With {.VendorCode = VendorCode,
                                                                                              .Week = Week,
                                                                                              .Year = Year,
                                                                                              .RowIndex = RowIndex,
                                                                                              .Rate = Rate,
                                                                                              .MediaPlanDataDetails = MPD.ToList}).Distinct.OrderBy(Function(E) E.VendorCode).ThenBy(Function(E) E.RowIndex).ThenBy(Function(E) E.Year).ThenBy(Function(E) E.Week).ToList

                    For Each MediaPlanData In MediaPlanDataList

                        IsUnits = False
                        IsImpressions = False
                        IsClicks = False
                        IsColumns = False
                        IsInchesLines = False

                        If MediaPlanData.VendorCode IsNot Nothing Then

                            StartDate = MediaPlanData.MediaPlanDataDetails.Min(Function(Entity) Entity.StartDate)
                            OrderStartDate = StartDate
                            OrderEndDate = GetWeekOrderEndDate(DbContext, MediaPlan, MediaPlanData, OrderStartDate,
                                                               MediaPlan.MediaPlanEstimate.IsCalendarMonth, BroadcastCalendarWeeks, CreateOrderBroadcastCalendarType,
                                                               False)

                            ImportOrder = New AdvantageFramework.Media.Classes.ImportOrder

                            ImportOrder.MediaPlanMonday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Monday
                            ImportOrder.MediaPlanTuesday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Tuesday
                            ImportOrder.MediaPlanWednesday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Wednesday
                            ImportOrder.MediaPlanThursday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Thursday
                            ImportOrder.MediaPlanFriday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Friday
                            ImportOrder.MediaPlanSaturday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Saturday
                            ImportOrder.MediaPlanSunday = MediaPlanData.MediaPlanDataDetails.FirstOrDefault.Sunday

                            ImportOrder.ImportSource = Media.ImportSource.MediaPlanning
                            'ImportOrder.IsSourceMediaPlanning = True
                            ImportOrder.MediaType = MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code
                            ImportOrder.SalesClassCode = MediaPlan.MediaPlanEstimate.SalesClassCode
                            ImportOrder.ClientPO = MediaPlan.MediaPlanEstimate.ID
                            ImportOrder.ClientCode = MediaPlan.ClientCode
                            ImportOrder.DivisionCode = MediaPlan.DivisionCode
                            ImportOrder.ProductCode = MediaPlan.ProductCode
                            ImportOrder.VendorCode = MediaPlanData.VendorCode

                            ImportOrder.StartDate = OrderStartDate
                            ImportOrder.EndDate = OrderEndDate

                            ImportOrder.UserCode = Session.UserCode
                            ImportOrder.CalendarType = If(MediaPlan.MediaPlanEstimate.IsCalendarMonth AndAlso
                                                        (CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.FromPlan OrElse
                                                        CreateOrderBroadcastCalendarType = CreateOrderBroadcastCalendarType.ByCalendar), "CM", "BM")

                            ImportOrder.OrderID = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderID)
                            ImportOrder.LineNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderLineID)
                            ImportOrder.OrderNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderNumber)
                            ImportOrder.OrderLineNumber = MediaPlanData.MediaPlanDataDetails.Max(Function(Entity) Entity.OrderLineNumber)

                            ImportOrder.MediaPlanRate = MediaPlanData.Rate
                            ImportOrder.MediaPlanRowIndex = MediaPlanData.RowIndex

                            If ImportOrder.OrderID.HasValue AndAlso ImportOrder.OrderID.GetValueOrDefault(0) <> 0 AndAlso ImportOrder.LineNumber.HasValue AndAlso ImportOrder.LineNumber.GetValueOrDefault(0) <> 0 Then

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.OrderID = ImportOrder.OrderID AndAlso Entity.LineNumber = ImportOrder.LineNumber) = True Then

                                    If ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                               Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                               Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                               Entity.LineNumber <> ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate = ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) <> ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    ElseIf ImportOrderList.Where(Function(Entity) Entity.EndDate.HasValue AndAlso Entity.OrderID.HasValue AndAlso Entity.LineNumber.HasValue).Any(Function(Entity) Entity.EndDate <> ImportOrder.EndDate AndAlso
                                                                                                                                                                                                   Entity.MediaPlanRate.GetValueOrDefault(0) = ImportOrder.MediaPlanRate.GetValueOrDefault(0) AndAlso
                                                                                                                                                                                                   Entity.OrderID = ImportOrder.OrderID AndAlso
                                                                                                                                                                                                   Entity.LineNumber = ImportOrder.LineNumber) Then

                                        ImportOrder.LineNumber = Nothing
                                        ImportOrder.OrderLineNumber = Nothing

                                    End If

                                End If

                            Else

                                If ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).Any(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                            Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                            Entity.OrderNumber.GetValueOrDefault(0) <> 0) = True Then

                                    ImportOrder.OrderID = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                             Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                             Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderID

                                    ImportOrder.OrderNumber = ImportOrderList.Where(Function(Entity) Entity.OrderID.HasValue AndAlso Entity.OrderNumber.HasValue).LastOrDefault(Function(Entity) Entity.MediaPlanRowIndex = ImportOrder.MediaPlanRowIndex AndAlso
                                                                                                                                                                                                 Entity.OrderID.GetValueOrDefault(0) <> 0 AndAlso
                                                                                                                                                                                                 Entity.OrderNumber.GetValueOrDefault(0) <> 0).OrderNumber

                                    ImportOrder.LineNumber = Nothing
                                    ImportOrder.OrderLineNumber = Nothing

                                End If

                            End If

                            If ImportOrder.OrderID IsNot Nothing AndAlso ImportOrder.LineNumber IsNot Nothing Then

                                ImportOrder.IsRevision = True

                            End If

                            ImportOrder.MediaPlanBuyer = MediaPlan.MediaPlanEstimate.BuyerEmployeeCode

                            SetMappingValues(DbContext, ImportOrder, MediaPlan, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID, MediaPlanData.MediaPlanDataDetails.FirstOrDefault.RowIndex, MediaPlanData.VendorCode)

                            MediaPlanDetailLevelLineDataIDList = (From Entity In MediaPlanData.MediaPlanDataDetails
                                                                  Select Entity.MediaPlanDetailLevelLineDataID).ToList

                            ImportOrder.MediaPlanDetailLevelLineDataIDs = AdvantageFramework.StringUtilities.CreateCommaDelimitedString(MediaPlanDetailLevelLineDataIDList)

                            If MediaPlan.MediaPlanEstimate.CampaignID IsNot Nothing Then

                                Try

                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaPlan.MediaPlanEstimate.CampaignID)

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Campaign IsNot Nothing Then

                                    ImportOrder.CampaignCode = Campaign.Code
                                    ImportOrder.Campaign = Campaign.Name

                                End If

                            End If

                            If ImportOrder.IsRevision AndAlso ImportOrder.OrderNumber.GetValueOrDefault(0) > 0 Then

                                GetExistingOrderNetGross(DbContext, ImportOrder, MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code)

                            Else

                                If UseVendorsRateType Then

                                    Try

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanData.VendorCode)

                                    Catch ex As Exception
                                        Vendor = Nothing
                                    End Try

                                    If Vendor IsNot Nothing Then

                                        If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                                            ImportOrder.NetGross = 0

                                        Else

                                            ImportOrder.NetGross = 1

                                        End If

                                    Else

                                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                            ImportOrder.NetGross = 1

                                        Else

                                            ImportOrder.NetGross = 0

                                        End If

                                    End If

                                Else

                                    If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                                        ImportOrder.NetGross = 1

                                    Else

                                        ImportOrder.NetGross = 0

                                    End If

                                End If

                            End If

                            ImportOrder.MediaNetAmount = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Dollars.GetValueOrDefault(0))

                            If MediaPlanData.MediaPlanDataDetails.Where(Function(LD) LD.AgencyFee.HasValue).Any Then

                                ImportOrder.AddAmount = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.AgencyFee)

                            Else

                                ImportOrder.AddAmount = 0

                            End If

                            If MediaPlanData.MediaPlanDataDetails.Where(Function(LD) LD.NetCharge.HasValue).Any Then

                                ImportOrder.NetCharge = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.NetCharge)

                            Else

                                ImportOrder.NetCharge = 0

                            End If
                            'If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount Then

                            '	ImportOrder.NetRate = (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.85)
                            '	ImportOrder.GrossRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))

                            'Else

                            '	ImportOrder.NetRate = MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0))
                            '	ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (MediaPlanData.MPD.Average(Function(LD) LD.Rate.GetValueOrDefault(0)) * 0.17647), 2)

                            'End If

                            SetTotalSpotsAndCostType(ImportOrder, MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)), MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)),
                                                     MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)), MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)),
                                                     MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0)), MediaPlanData.RowIndex, MediaPlan.MediaPlanEstimate,
                                                     IsUnits, IsImpressions, IsClicks, IsColumns, IsInchesLines)

                            If MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                                If ImportOrder.TotalSpots.GetValueOrDefault(0) = 0 AndAlso (ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0) Then

                                    ImportOrder.TotalSpots = 1

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                                If MediaPlan.MediaPlanEstimate.CheckForClicksQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForImpressionsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                ElseIf MediaPlan.MediaPlanEstimate.CheckForUnitsQuantity(MediaPlanData.RowIndex) Then

                                    If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) Then

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                    End If

                                Else

                                    If MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) > 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPC.ToString

                                        End If

                                    ElseIf MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) = 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsImpressionsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                        End If

                                    ElseIf MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) = 0 AndAlso
                                            MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) > 0 Then

                                        If MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM Then

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        Else

                                            ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPA.ToString

                                        End If

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                                    End If

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                                If (MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Clicks.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Units.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Columns.GetValueOrDefault(0)) +
                                        MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.InchesLines.GetValueOrDefault(0))) > 1 Then

                                    If IsColumns Then

                                        ImportOrder.CostType = "CPI"
                                        ImportOrder.RateType = "STD"

                                    ElseIf IsInchesLines Then

                                        ImportOrder.CostType = "CPL"
                                        ImportOrder.RateType = "STD"

                                    Else

                                        ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString

                                        If (MediaPlan.MediaPlanEstimate.IsImpressionsCPM OrElse MediaPlan.MediaPlanEstimate.IsUnitsCPM OrElse MediaPlan.MediaPlanEstimate.IsClicksCPM) OrElse
                                                (MediaPlan.MediaPlanEstimate.CheckForImpressionsCPM(MediaPlanData.RowIndex) OrElse MediaPlan.MediaPlanEstimate.CheckForUnitsCPM(MediaPlanData.RowIndex) OrElse
                                                 MediaPlan.MediaPlanEstimate.CheckForClicksCPM(MediaPlanData.RowIndex)) Then

                                            ImportOrder.RateType = "CPM"

                                        Else

                                            ImportOrder.RateType = "STD"

                                        End If

                                    End If

                                Else

                                    ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString
                                    ImportOrder.RateType = "STD"

                                End If

                            ElseIf MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                                If MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0)) > 0 Then

                                    ImportOrder.MediaPlanImpressions = MediaPlanData.MediaPlanDataDetails.Sum(Function(LD) LD.Impressions.GetValueOrDefault(0))

                                Else

                                    ImportOrder.MediaPlanImpressions = Nothing

                                End If

                            End If

                            SetRate(DbContext, MediaPlan.MediaPlanEstimate, MediaPlanData.RowIndex, IsUnits, IsImpressions, IsClicks, ImportOrder)

                            ImportOrder.Units = "W"

                            If ImportOrder.IsRevision OrElse ImportOrder.TotalSpots.GetValueOrDefault(0) <> 0 OrElse ImportOrder.MediaNetAmount.GetValueOrDefault(0) <> 0 OrElse ImportOrder.AddAmount.GetValueOrDefault(0) <> 0 Then

                                If ImportOrder.IsRevision AndAlso Not ImportOrder.TotalSpots.HasValue Then

                                    ImportOrder.TotalSpots = 0

                                End If

                                ImportOrderList.Add(ImportOrder)

                            End If

                        End If

                    Next

                End If

                DbContext.Database.Connection.Close()

            End Using

            BuildWeekOrderList = ImportOrderList

        End Function
        Private Sub SetMappingValues(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder,
                                     MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanDetailID As Integer, ByVal RowIndex As Integer, ByVal VendorCode As String)

            'objects
            Dim MediaPlanDetailLevelLineList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing
            Dim InternetType As AdvantageFramework.Database.Entities.InternetType = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim OutOfHomeType As AdvantageFramework.Database.Entities.OutOfHomeType = Nothing
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorName As String = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim MediaChannel As AdvantageFramework.Database.Entities.MediaChannel = Nothing
            Dim MediaTactic As AdvantageFramework.Database.Entities.MediaTactic = Nothing

            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode)

            If Vendor IsNot Nothing Then

                VendorName = Vendor.Name

            End If

            MediaPlanDetailLevelLineList = AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLine.LoadByMediaPlanDetailIDAndRowIndex(DbContext, MediaPlanDetailID, RowIndex).Include("MediaPlanDetailLevel").Include("MediaPlanDetailLevelLineTags").ToList

            For Each MediaPlanDetailLevelLine In MediaPlanDetailLevelLineList

                If MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.AdSize OrElse
                        MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.Daypart OrElse
                        MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.InternetType OrElse
                        MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.Market OrElse
                        MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.MarketOrderLine OrElse
                        MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType OrElse
                        MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.AdNumber OrElse
                        MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.JobComponent OrElse
                        MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.Campaign OrElse
                        MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaChannel OrElse
                        MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic Then

                    Select Case MediaPlanDetailLevelLine.MediaPlanDetailLevel.TagType

                        Case AdvantageFramework.MediaPlanning.TagTypes.AdSize

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.AdSize IsNot Nothing Then

                                ImportOrder.MediaPlanAdSizeCode = MediaPlanDetailLevelLineTag.AdSize.Code
                                ImportOrder.MediaPlanAdSizeDescription = MediaPlanDetailLevelLineTag.AdSize.Description

                            Else

                                Try

                                    AdSize = AdvantageFramework.Database.Procedures.AdSize.LoadByCodeAndMediaType(DbContext, MediaPlanDetailLevelLine.Description, ImportOrder.MediaType)

                                Catch ex As Exception
                                    AdSize = Nothing
                                End Try

                                If AdSize IsNot Nothing Then

                                    ImportOrder.MediaPlanAdSizeCode = AdSize.Code
                                    ImportOrder.MediaPlanAdSizeDescription = AdSize.Description

                                Else

                                    ImportOrder.MediaPlanAdSizeCode = Nothing
                                    ImportOrder.MediaPlanAdSizeDescription = MediaPlanDetailLevelLine.Description

                                End If

                            End If

                        Case AdvantageFramework.MediaPlanning.TagTypes.Daypart

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.Daypart IsNot Nothing Then

                                ImportOrder.MediaPlanDaypart = MediaPlanDetailLevelLineTag.Daypart.Code
                                ImportOrder.DaypartID = MediaPlanDetailLevelLineTag.Daypart.ID

                            Else

                                Try

                                    Daypart = (From Entity In AdvantageFramework.Database.Procedures.Daypart.Load(DbContext)
                                               Where Entity.Code = MediaPlanDetailLevelLine.Description
                                               Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    Daypart = Nothing
                                End Try

                                If Daypart IsNot Nothing Then

                                    ImportOrder.MediaPlanDaypart = Daypart.Code
                                    ImportOrder.DaypartID = Daypart.ID

                                Else

                                    ImportOrder.MediaPlanDaypart = Nothing
                                    ImportOrder.DaypartID = Nothing

                                End If

                            End If

                        Case AdvantageFramework.MediaPlanning.TagTypes.InternetType

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.InternetTypeCode IsNot Nothing Then

                                ImportOrder.MediaPlanInternetType = MediaPlanDetailLevelLineTag.InternetTypeCode

                            Else

                                Try

                                    InternetType = (From Entity In AdvantageFramework.Database.Procedures.InternetType.Load(DbContext)
                                                    Where Entity.Code = MediaPlanDetailLevelLine.Description
                                                    Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    InternetType = Nothing
                                End Try

                                If InternetType IsNot Nothing Then

                                    ImportOrder.MediaPlanInternetType = InternetType.Code

                                Else

                                    ImportOrder.MediaPlanInternetType = Nothing

                                End If

                            End If

                        Case AdvantageFramework.MediaPlanning.TagTypes.Campaign

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.Campaign IsNot Nothing Then

                                ImportOrder.CampaignCode = MediaPlanDetailLevelLineTag.Campaign.Code
                                ImportOrder.Campaign = MediaPlanDetailLevelLineTag.Campaign.Name

                            Else

                                Try

                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignCode(DbContext, MediaPlanDetailLevelLine.Description)

                                Catch ex As Exception
                                    Campaign = Nothing
                                End Try

                                If Market IsNot Nothing Then

                                    ImportOrder.CampaignCode = Campaign.Code
                                    ImportOrder.Campaign = Campaign.Name

                                Else

                                    ImportOrder.CampaignCode = MediaPlanDetailLevelLine.Description
                                    ImportOrder.Campaign = MediaPlanDetailLevelLine.Description

                                End If

                            End If

                        Case AdvantageFramework.MediaPlanning.TagTypes.Market

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.Market IsNot Nothing Then

                                ImportOrder.MediaPlanMarketCode = MediaPlanDetailLevelLineTag.Market.Code
                                ImportOrder.MediaPlanMarketDescription = MediaPlanDetailLevelLineTag.Market.Description

                            Else

                                Try

                                    Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MediaPlanDetailLevelLine.Description)

                                Catch ex As Exception
                                    Market = Nothing
                                End Try

                                If Market IsNot Nothing Then

                                    ImportOrder.MediaPlanMarketCode = Market.Code
                                    ImportOrder.MediaPlanMarketDescription = Market.Description

                                Else

                                    ImportOrder.MediaPlanMarketCode = Nothing
                                    ImportOrder.MediaPlanMarketDescription = MediaPlanDetailLevelLine.Description

                                End If

                            End If

                        Case AdvantageFramework.MediaPlanning.TagTypes.MarketOrderLine

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.Market IsNot Nothing Then

                                ImportOrder.MediaPlanOrderLineMarketCode = MediaPlanDetailLevelLineTag.Market.Code
                                ImportOrder.MediaPlanOrderLineMarketDescription = MediaPlanDetailLevelLineTag.Market.Description

                            Else

                                Try

                                    Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MediaPlanDetailLevelLine.Description)

                                Catch ex As Exception
                                    Market = Nothing
                                End Try

                                If Market IsNot Nothing Then

                                    ImportOrder.MediaPlanOrderLineMarketCode = Market.Code
                                    ImportOrder.MediaPlanOrderLineMarketDescription = Market.Description

                                Else

                                    ImportOrder.MediaPlanOrderLineMarketCode = Nothing
                                    ImportOrder.MediaPlanOrderLineMarketDescription = MediaPlanDetailLevelLine.Description

                                End If

                            End If

                        Case AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.OutOfHomeTypeCode IsNot Nothing Then

                                ImportOrder.MediaPlanOutOfHomeType = MediaPlanDetailLevelLineTag.OutOfHomeTypeCode

                            Else

                                Try

                                    OutOfHomeType = (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeType.Load(DbContext)
                                                     Where Entity.Code = MediaPlanDetailLevelLine.Description
                                                     Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    OutOfHomeType = Nothing
                                End Try

                                If OutOfHomeType IsNot Nothing Then

                                    ImportOrder.MediaPlanOutOfHomeType = OutOfHomeType.Code

                                Else

                                    ImportOrder.MediaPlanOutOfHomeType = Nothing

                                End If

                            End If

                        Case AdvantageFramework.MediaPlanning.TagTypes.AdNumber

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.AdNumber IsNot Nothing Then

                                ImportOrder.MediaPlanAdNumber = MediaPlanDetailLevelLineTag.AdNumber

                            Else

                                Try

                                    Ad = (From Entity In AdvantageFramework.Database.Procedures.Ad.Load(DbContext)
                                          Where Entity.Number = MediaPlanDetailLevelLine.Description
                                          Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    Ad = Nothing
                                End Try

                                If Ad IsNot Nothing Then

                                    ImportOrder.MediaPlanAdNumber = Ad.Number

                                Else

                                    ImportOrder.MediaPlanAdNumber = Nothing

                                End If

                            End If

                        Case AdvantageFramework.MediaPlanning.TagTypes.JobComponent

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.JobNumber IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.JobComponentNumber IsNot Nothing Then

                                ImportOrder.MediaPlanJobNumber = MediaPlanDetailLevelLineTag.JobNumber
                                ImportOrder.MediaPlanJobComponentNumber = MediaPlanDetailLevelLineTag.JobComponentNumber

                            Else

                                Try

                                    Job = (From Entity In AdvantageFramework.Database.Procedures.Job.Load(DbContext)
                                           Where Entity.Number = MediaPlanDetailLevelLine.Description
                                           Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    Job = Nothing
                                End Try

                                If Job IsNot Nothing Then

                                    ImportOrder.MediaPlanJobNumber = Job.Number

                                Else

                                    ImportOrder.MediaPlanJobNumber = Nothing

                                End If

                            End If

                        Case AdvantageFramework.MediaPlanning.TagTypes.MediaChannel

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.MediaChannel IsNot Nothing Then

                                ImportOrder.MediaPlanMediaChannelID = MediaPlanDetailLevelLineTag.MediaChannel.ID

                            Else

                                Try

                                    MediaChannel = AdvantageFramework.Database.Procedures.MediaChannel.LoadByMediaChannelID(DbContext, MediaPlanDetailLevelLine.Description)

                                Catch ex As Exception
                                    MediaChannel = Nothing
                                End Try

                                If MediaChannel IsNot Nothing Then

                                    ImportOrder.MediaPlanMediaChannelID = MediaChannel.ID

                                Else

                                    ImportOrder.MediaPlanMediaChannelID = Nothing

                                End If

                            End If

                        Case AdvantageFramework.MediaPlanning.TagTypes.MediaTactic

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Where(Function(Tag) Tag.MediaPlanDetailLevelLineID = MediaPlanDetailLevelLine.ID).FirstOrDefault()

                            If MediaPlanDetailLevelLineTag IsNot Nothing AndAlso MediaPlanDetailLevelLineTag.MediaTactic IsNot Nothing Then

                                ImportOrder.MediaPlanMediaTacticID = MediaPlanDetailLevelLineTag.MediaTactic.ID

                            Else

                                Try

                                    MediaTactic = AdvantageFramework.Database.Procedures.MediaTactic.LoadByMediaTacticID(DbContext, MediaPlanDetailLevelLine.Description)

                                Catch ex As Exception
                                    MediaTactic = Nothing
                                End Try

                                If MediaTactic IsNot Nothing Then

                                    ImportOrder.MediaPlanMediaTacticID = MediaTactic.ID

                                Else

                                    ImportOrder.MediaPlanMediaTacticID = Nothing

                                End If

                            End If

                    End Select

                ElseIf MediaPlanDetailLevelLine.MediaPlanDetailLevel.MappingType <> 0 Then

                    Select Case MediaPlanDetailLevelLine.MediaPlanDetailLevel.MappingType

                        'Case AdvantageFramework.MediaPlanning.MappingTypes.AdSizeCode

                        '    ImportOrder.MediaPlanAdSizeCode = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.AdSizeDescription

                            ImportOrder.MediaPlanAdSizeDescription = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Daypart

                            ImportOrder.MediaPlanDaypart = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.InternetType

                            ImportOrder.MediaPlanInternetType = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Market

                            Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MediaPlanDetailLevelLine.Description)

                            If Market IsNot Nothing Then

                                ImportOrder.MediaPlanMarketCode = Market.Code
                                ImportOrder.MediaPlanMarketDescription = Market.Description

                            Else

                                ImportOrder.MediaPlanMarketCode = Nothing
                                ImportOrder.MediaPlanMarketDescription = MediaPlanDetailLevelLine.Description

                            End If

                        Case AdvantageFramework.MediaPlanning.MappingTypes.MarketOrderLine

                            Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MediaPlanDetailLevelLine.Description)

                            If Market IsNot Nothing Then

                                ImportOrder.MediaPlanOrderLineMarketCode = Market.Code
                                ImportOrder.MediaPlanOrderLineMarketDescription = Market.Description

                            Else

                                ImportOrder.MediaPlanOrderLineMarketCode = Nothing
                                ImportOrder.MediaPlanOrderLineMarketDescription = MediaPlanDetailLevelLine.Description

                            End If

                        Case AdvantageFramework.MediaPlanning.MappingTypes.OutOfHomeType

                            ImportOrder.MediaPlanOutOfHomeType = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.OrderDescription

                            ImportOrder.MediaPlanOrderDescription = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.OrderComment

                            ImportOrder.MediaPlanOrderComment = MediaPlanDetailLevelLine.Description

                        'Case AdvantageFramework.MediaPlanning.MappingTypes.Buyer

                        '    ImportOrder.MediaPlanBuyer = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Headline

                            ImportOrder.MediaPlanHeadline = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.StartTime

                            ImportOrder.MediaPlanStartTime = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.EndTime

                            ImportOrder.MediaPlanEndTime = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Programming

                            ImportOrder.MediaPlanProgramming = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.NetworkCode

                            ImportOrder.MediaPlanNetworkCode = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Length

                            ImportOrder.MediaPlanLength = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Circulation

                            If String.IsNullOrWhiteSpace(MediaPlanDetailLevelLine.Description) = False AndAlso
                                    IsNumeric(MediaPlanDetailLevelLine.Description) Then

                                ImportOrder.MediaPlanCirculation = MediaPlanDetailLevelLine.Description

                            Else

                                ImportOrder.MediaPlanCirculation = Nothing

                            End If

                        Case AdvantageFramework.MediaPlanning.MappingTypes.AdNumber

                            ImportOrder.MediaPlanAdNumber = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Issue

                            ImportOrder.MediaPlanIssue = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Placement

                            ImportOrder.MediaPlanPlacement = MediaPlanDetailLevelLine.Description

                        'Case AdvantageFramework.MediaPlanning.MappingTypes.LineDescription

                        '    ImportOrder.LineDescription = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Instructions

                            ImportOrder.LineDescription = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Remarks

                            ImportOrder.MediaPlanRemarks = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Section

                            ImportOrder.MediaPlanSection = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.OrderCopy

                            ImportOrder.MediaPlanOrderCopy = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.MaterialNotes

                            ImportOrder.MediaPlanMaterialNotes = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.PositionInfo

                            ImportOrder.MediaPlanPositionInfo = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.CloseInfo

                            ImportOrder.MediaPlanCloseInfo = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.RateInfo

                            ImportOrder.MediaPlanRateInfo = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.MiscInfo

                            ImportOrder.MediaPlanMiscInfo = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Location

                            ImportOrder.MediaPlanLocation = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.URL

                            ImportOrder.MediaPlanURL = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.TargetAudience

                            ImportOrder.MediaPlanTargetAudience = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.JobComponent

                            ImportOrder.MediaPlanJobNumber = MediaPlanDetailLevelLine.Description

                        Case AdvantageFramework.MediaPlanning.MappingTypes.Material

                            ImportOrder.MediaPlanMaterial = MediaPlanDetailLevelLine.Description

                    End Select

                End If

                If String.IsNullOrWhiteSpace(ImportOrder.MediaPlanOrderDescription) Then

                    ImportOrder.MediaPlanOrderDescription = VendorName & " - " & MediaPlan.Description

                End If

                If String.IsNullOrEmpty(ImportOrder.MediaPlanOrderDescription) = False Then

                    If ImportOrder.MediaPlanOrderDescription.Length > 40 Then

                        ImportOrder.MediaPlanOrderDescription = ImportOrder.MediaPlanOrderDescription.Substring(0, 40)

                    End If

                End If

                If String.IsNullOrEmpty(ImportOrder.MediaPlanStartTime) = False Then

                    If ImportOrder.MediaPlanStartTime.Length > 10 Then

                        ImportOrder.MediaPlanStartTime = ImportOrder.MediaPlanStartTime.Substring(0, 10)

                    End If

                End If

                If String.IsNullOrEmpty(ImportOrder.MediaPlanEndTime) = False Then

                    If ImportOrder.MediaPlanEndTime.Length > 10 Then

                        ImportOrder.MediaPlanEndTime = ImportOrder.MediaPlanEndTime.Substring(0, 10)

                    End If

                End If

                If String.IsNullOrEmpty(ImportOrder.LineDescription) = False Then

                    If ImportOrder.LineDescription.Length > 254 Then

                        ImportOrder.LineDescription = ImportOrder.LineDescription.Substring(0, 254)

                    End If

                End If

            Next

        End Sub
        Private Sub SetRate(DbContext As AdvantageFramework.Database.DbContext, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, RowIndex As Integer,
                            IsUnits As Boolean, IsImpressions As Boolean, IsClicks As Boolean, ByRef ImportOrder As AdvantageFramework.Media.Classes.ImportOrder)

            'objects
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim VendorCommission As Nullable(Of Decimal) = Nothing
            Dim VendorMarkup As Nullable(Of Decimal) = Nothing
            Dim MediaPlanRate As Decimal = 0
            Dim UseProductAmounts As Boolean = False
            Dim RebateAmount As Decimal = 0
            Dim CommissionAmount As Decimal = 0
            Dim CalculateRate As Boolean = False

            MediaPlanDetailLevel = MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).FirstOrDefault

            If MediaPlanDetailLevel IsNot Nothing AndAlso MediaPlanDetailLevel.MediaPlanDetailLevelLines IsNot Nothing Then

                MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                If MediaPlanDetailLevelLine IsNot Nothing AndAlso MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing Then

                    MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.FirstOrDefault

                    If MediaPlanDetailLevelLineTag IsNot Nothing Then

                        VendorCommission = MediaPlanDetailLevelLineTag.VendorCommission
                        VendorMarkup = MediaPlanDetailLevelLineTag.VendorMarkup

                    End If

                End If

            End If

            If ImportOrder.MediaPlanRate.HasValue AndAlso ImportOrder.MediaPlanRate.Value <> 0 Then

                MediaPlanRate = ImportOrder.MediaPlanRate.Value

            Else

                If ImportOrder.TotalSpots.HasValue AndAlso ImportOrder.TotalSpots.Value > 1 Then

                    If MediaPlanEstimate.SalesClassTypeEnumObject.Code = "I" Then

                        If IsUnits OrElse IsClicks Then

                            CalculateRate = True

                        End If

                    ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                        If IsUnits Then

                            CalculateRate = True

                        ElseIf IsImpressions Then

                            If MediaPlanEstimate.CheckForImpressionsCPM(RowIndex) = False AndAlso
                                    MediaPlanEstimate.IsImpressionsCPM = False Then

                                CalculateRate = True

                            End If

                        End If

                    ElseIf MediaPlanEstimate.SalesClassTypeEnumObject.Code = "R" OrElse
                            MediaPlanEstimate.SalesClassTypeEnumObject.Code = "T" Then

                        If IsUnits Then

                            CalculateRate = True

                        End If

                    End If

                End If

                If CalculateRate Then

                    If MediaPlanEstimate.SalesClassTypeEnumObject.Code = "N" Then

                        If ImportOrder.RateType = AdvantageFramework.Database.Entities.CostType.CPM.ToString Then

                            MediaPlanRate = FormatNumber(((ImportOrder.MediaNetAmount.GetValueOrDefault(0) / ImportOrder.TotalSpots) * 1000), 4)

                        Else

                            MediaPlanRate = FormatNumber((ImportOrder.MediaNetAmount.GetValueOrDefault(0) / ImportOrder.TotalSpots), 4)

                        End If

                    Else

                        If ImportOrder.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString Then

                            MediaPlanRate = FormatNumber(((ImportOrder.MediaNetAmount.GetValueOrDefault(0) / ImportOrder.TotalSpots) * 1000), 4)

                        Else

                            MediaPlanRate = FormatNumber((ImportOrder.MediaNetAmount.GetValueOrDefault(0) / ImportOrder.TotalSpots), 4)

                        End If

                    End If

                Else

                    MediaPlanRate = ImportOrder.MediaNetAmount.Value

                    If ImportOrder.TotalSpots.HasValue = False Then

                        ImportOrder.TotalSpots = 1

                    End If

                End If

            End If

            If MediaPlanEstimate.IsEstimateGrossAmount Then

                ImportOrder.GrossRate = FormatNumber(MediaPlanRate, 4)

                If VendorCommission.HasValue = False OrElse VendorCommission.Value = 0 Then

                    ImportOrder.NetRate = FormatNumber(ImportOrder.GrossRate * 0.85, 4)

                Else

                    ImportOrder.NetRate = FormatNumber(ImportOrder.GrossRate * ((100 - VendorCommission.Value) / 100), 4)

                End If

            Else

                ImportOrder.NetRate = FormatNumber(MediaPlanRate, 4)

                If VendorMarkup.HasValue Then

                    If VendorMarkup.Value = 0 Then

                        ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate, 4)

                    Else

                        ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + (ImportOrder.NetRate * (VendorMarkup.Value / 100)), 4)

                    End If

                Else

                    UseProductAmounts = True

                End If

            End If

            If UseProductAmounts Then

                If MediaPlanEstimate.ProductUsesNetAmount Then

                    If MediaPlanEstimate.IsEstimateGrossAmount Then

                        ImportOrder.NetRate = FormatNumber((ImportOrder.GrossRate * 0.85), 4)

                    Else

                        If ImportOrder.GrossRate.HasValue = False Then

                            ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate, 4)

                        Else

                            ImportOrder.NetRate = FormatNumber(ImportOrder.GrossRate, 4)

                        End If

                    End If

                Else

                    If MediaPlanEstimate.IsEstimateGrossAmount Then

                        RebateAmount = ImportOrder.GrossRate * (MediaPlanEstimate.ProductRebateAmount / 100)

                        ImportOrder.NetRate = FormatNumber(ImportOrder.GrossRate - RebateAmount, 4)

                    Else

                        CommissionAmount = ImportOrder.NetRate * (MediaPlanEstimate.ProductMarkupAmount / 100)

                        ImportOrder.GrossRate = FormatNumber(ImportOrder.NetRate + CommissionAmount, 4)

                    End If

                End If

            End If

        End Sub
        Public Function CreateDayOfWeeks(MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, RowIndexes() As Integer, EntryDates() As Date) As String

            'objects
            Dim DaysOfWeeks As String = ""

            If MediaPlanEstimate.IsCalendarMonth Then

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Sunday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "SU", ",SU")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Monday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "M", ",M")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Tuesday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "TU", ",TU")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Wednesday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "W", ",W")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Thursday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "TH", ",TH")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Friday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "F", ",F")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Saturday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "SA", ",SA")

                End If

            Else

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Monday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "M", ",M")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Tuesday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "TU", ",TU")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Wednesday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "W", ",W")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Thursday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "TH", ",TH")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Friday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "F", ",F")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Saturday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "SA", ",SA")

                End If

                If MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Any(Function(MPDLLD) RowIndexes.Contains(MPDLLD.RowIndex) = True AndAlso EntryDates.Contains(MPDLLD.StartDate) = True AndAlso MPDLLD.Sunday = True) Then

                    DaysOfWeeks &= If(DaysOfWeeks = "", "SU", ",SU")

                End If

            End If

            CreateDayOfWeeks = DaysOfWeeks

        End Function
        Public Function CreateDayOfWeeks(MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate, RowIndexes() As Integer) As String

            'objects
            Dim DaysOfWeeks As String = ""

            DaysOfWeeks = CreateDayOfWeeks(MediaPlanEstimate, RowIndexes, MediaPlanEstimate.EntryDates)

            CreateDayOfWeeks = DaysOfWeeks

        End Function
        Public Function IsEstimateLocked(DbContext As AdvantageFramework.Database.DbContext, MediaPlanDetailID As Integer, ByRef Message As String) As Boolean

            'objects
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim ConnectedUsers As Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser) = Nothing
            Dim IsLocked As Boolean = False

            MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID)

            If MediaPlanDetail IsNot Nothing Then

                If String.IsNullOrWhiteSpace(MediaPlanDetail.LockedByUserCode) Then

                    If MediaPlanDetail.MediaPlan.SyncDetailSettings = False Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET LOCKED_BY = '{0}' WHERE MEDIA_PLAN_DTL_ID = {1}", DbContext.UserCode, MediaPlanDetailID))

                    Else

                        MediaPlanDetail = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanDetail.MediaPlanID).ToList
                                           Where String.IsNullOrWhiteSpace(Entity.LevelLineEditLockedByUserCode) = False).FirstOrDefault

                        If MediaPlanDetail IsNot Nothing Then

                            Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                                ConnectedUsers = AdvantageFramework.Security.LicenseKey.LoadConnectedUsers(SecurityDbContext, Security.LicenseKey.Types.PowerUser)

                            End Using

                            If ConnectedUsers.Where(Function(Entity) Entity.UserCode.ToUpper = MediaPlanDetail.LevelLineEditLockedByUserCode.ToUpper AndAlso Entity.UserCode.ToUpper <> DbContext.UserCode.ToUpper).Any Then

                                IsLocked = True

                                Message = "Media level lines being edited by " & MediaPlanDetail.LevelLineEditLockedByUserCode & " (" & ConnectedUsers.Where(Function(Entity) Entity.UserCode.ToUpper = MediaPlanDetail.LevelLineEditLockedByUserCode.ToUpper).First.EmployeeName & ")"

                            Else

                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET LOCKED_BY = '{0}' WHERE MEDIA_PLAN_DTL_ID = {1}", DbContext.UserCode, MediaPlanDetailID))

                            End If

                        Else

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET LOCKED_BY = '{0}' WHERE MEDIA_PLAN_DTL_ID = {1}", DbContext.UserCode, MediaPlanDetailID))

                        End If

                    End If

                Else

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        ConnectedUsers = AdvantageFramework.Security.LicenseKey.LoadConnectedUsers(SecurityDbContext, Security.LicenseKey.Types.PowerUser)

                    End Using

                    If ConnectedUsers.Where(Function(Entity) Entity.UserCode.ToUpper = MediaPlanDetail.LockedByUserCode.ToUpper AndAlso Entity.UserCode.ToUpper <> DbContext.UserCode.ToUpper).Any Then

                        IsLocked = True

                        If Not String.IsNullOrWhiteSpace(MediaPlanDetail.LevelLineEditLockedByUserCode) Then

                            Message = "Media level lines being edited by " & MediaPlanDetail.LevelLineEditLockedByUserCode & " (" & ConnectedUsers.Where(Function(Entity) Entity.UserCode.ToUpper = MediaPlanDetail.LockedByUserCode.ToUpper).First.EmployeeName & ")"

                        Else

                            Message = "Estimate is in use by " & MediaPlanDetail.LockedByUserCode & " (" & ConnectedUsers.Where(Function(Entity) Entity.UserCode.ToUpper = MediaPlanDetail.LockedByUserCode.ToUpper).First.EmployeeName & ")"

                        End If

                    Else

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET LOCKED_BY = '{0}' WHERE MEDIA_PLAN_DTL_ID = {1}", DbContext.UserCode, MediaPlanDetailID))

                    End If

                End If

            End If

            IsEstimateLocked = IsLocked

        End Function
        Public Function IsEstimateLocked(Session As AdvantageFramework.Security.Session, MediaPlanDetailID As Integer, ByRef Message As String) As Boolean

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                IsEstimateLocked = IsEstimateLocked(DbContext, MediaPlanDetailID, Message)

            End Using

        End Function
        Public Sub ClearEstimateLock(Session As AdvantageFramework.Security.Session, MediaPlanDetailID As Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET LOCKED_BY = NULL, LEVEL_LINE_EDIT_LOCKED_BY = NULL WHERE MEDIA_PLAN_DTL_ID = {0}", MediaPlanDetailID))

            End Using

        End Sub
        Public Function IsAnyEstimateLockedForMediaPlan(DbContext As AdvantageFramework.Database.DbContext, MediaPlanID As Integer, ByRef Message As String, Optional IsDeleting As Boolean = False) As Boolean

            'objects
            Dim Islocked As Boolean = False
            Dim LockedByUserCodes As IEnumerable(Of String) = Nothing
            Dim ConnectedUsers As Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser) = Nothing
            Dim VerifiedLockedByUserCodes As Generic.List(Of String) = Nothing

            If (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).ToList
                Where Not String.IsNullOrWhiteSpace(Entity.LockedByUserCode)).Any Then

                Islocked = True

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                    ConnectedUsers = AdvantageFramework.Security.LicenseKey.LoadConnectedUsers(SecurityDbContext, Security.LicenseKey.Types.PowerUser)

                End Using

                LockedByUserCodes = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).ToList
                                     Where Not String.IsNullOrWhiteSpace(Entity.LockedByUserCode)
                                     Select Entity.LockedByUserCode).Distinct.ToList

                VerifiedLockedByUserCodes = New Generic.List(Of String)

                For Each LockedByUserCode In LockedByUserCodes

                    If ConnectedUsers.Where(Function(CU) CU.UserCode.ToUpper = LockedByUserCode.ToUpper).Any Then

                        VerifiedLockedByUserCodes.Add(LockedByUserCode)

                    Else

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET LOCKED_BY = NULL WHERE MEDIA_PLAN_ID = {0} AND UPPER(LOCKED_BY) = '{1}'", MediaPlanID, LockedByUserCode.ToUpper))

                    End If

                Next

                If VerifiedLockedByUserCodes.Count = 0 Then

                    Islocked = False

                Else

                    If IsDeleting Then

                        Message = "Cannot delete Plan, estimates are in use by (" & String.Join(", ", VerifiedLockedByUserCodes) & ")"

                    Else

                        Message = "Cannot update Plan settings, estimates are in use by (" & String.Join(", ", VerifiedLockedByUserCodes) & ")"

                    End If

                End If

            End If

            IsAnyEstimateLockedForMediaPlan = Islocked

        End Function
        Public Function IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session As AdvantageFramework.Security.Session, MediaPlanID As Integer, SelectedEstimateID As Integer, ByRef Message As String,
                                                                                   Optional IsLevelLinesCheck As Boolean = True) As Boolean

            'objects
            Dim Islocked As Boolean = False
            Dim LockedByUserCodes As IEnumerable(Of String) = Nothing
            Dim ConnectedUsers As Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.ConnectedUser) = Nothing
            Dim VerifiedLockedByUserCodes As Generic.List(Of String) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).ToList
                    Where Not String.IsNullOrWhiteSpace(Entity.LockedByUserCode) AndAlso
                          Entity.ID <> SelectedEstimateID).Any Then

                    Islocked = True

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                        ConnectedUsers = AdvantageFramework.Security.LicenseKey.LoadConnectedUsers(SecurityDbContext, Security.LicenseKey.Types.PowerUser)

                    End Using

                    LockedByUserCodes = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).ToList
                                         Where Not String.IsNullOrWhiteSpace(Entity.LockedByUserCode) AndAlso
                                               Entity.ID <> SelectedEstimateID
                                         Select Entity.LockedByUserCode).Distinct.ToList

                    VerifiedLockedByUserCodes = New Generic.List(Of String)

                    For Each LockedByUserCode In LockedByUserCodes

                        If ConnectedUsers.Where(Function(CU) CU.UserCode.ToUpper = LockedByUserCode.ToUpper).Any Then

                            VerifiedLockedByUserCodes.Add(LockedByUserCode)

                        Else

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET LOCKED_BY = NULL WHERE MEDIA_PLAN_ID = {0} AND UPPER(LOCKED_BY) = '{1}'", MediaPlanID, LockedByUserCode.ToUpper))

                        End If

                    Next

                    If VerifiedLockedByUserCodes.Count = 0 Then

                        Islocked = False

                    Else

                        If IsLevelLinesCheck Then

                            Message = "Cannot manage level/lines for a synced plan, other estimates are in use by (" & String.Join(", ", VerifiedLockedByUserCodes) & ")"

                        Else

                            Message = "Cannot approve/unapprove all estimates for this plan, other estimates are in use by (" & String.Join(", ", VerifiedLockedByUserCodes) & ")"

                        End If

                    End If

                End If

            End Using

            IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID = Islocked

        End Function
        Public Function GetMediaPlanEstimatesWithInactiveSalesClassByMediaPlanID(Session As AdvantageFramework.Security.Session, MediaPlanID As Integer, MediaPlanDetailID As Integer,
                                                                                 ByRef MediaPlanDetailIDs As IEnumerable(Of Integer)) As Boolean

            'objects
            Dim Exists As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If MediaPlanDetailID = 0 Then

                    MediaPlanDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).Include("SalesClass")
                                          Where Entity.SalesClass.IsInactive = 1
                                          Select Entity.ID).ToArray

                Else

                    MediaPlanDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).Include("SalesClass")
                                          Where Entity.SalesClass.IsInactive = 1 AndAlso
                                                Entity.ID = MediaPlanDetailID
                                          Select Entity.ID).ToArray

                End If

                If MediaPlanDetailIDs IsNot Nothing AndAlso MediaPlanDetailIDs.Count > 0 Then

                    Exists = True

                End If

            End Using

            GetMediaPlanEstimatesWithInactiveSalesClassByMediaPlanID = Exists

        End Function
        Public Sub SetProductAmountValues(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, DivisionCode As String, ProductCode As String, SalesClassType As String, SalesClassCode As String,
                                          ByRef ProductUsesNetAmount As Boolean, ByRef ProductRebateAmount As Decimal, ByRef ProductMarkupAmount As Decimal)

            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing

            Try

                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

            Catch ex As Exception
                Product = Nothing
            End Try

            If Product IsNot Nothing Then

                Try

                    ProductMediaOverrides = AdvantageFramework.Database.Procedures.ProductMediaOverrides.LoadByClientDivisionProduct(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code).SingleOrDefault(Function(Entity) Entity.MediaType = SalesClassType AndAlso Entity.SalesClassCode = SalesClassCode)

                Catch ex As Exception
                    ProductMediaOverrides = Nothing
                End Try

                If ProductMediaOverrides IsNot Nothing Then

                    If SalesClassType = "R" Then

                        If Product.RadioBillNet = 1 Then

                            ProductUsesNetAmount = True

                        Else

                            ProductUsesNetAmount = False

                        End If

                    ElseIf SalesClassType = "T" Then

                        If Product.TelevisionBillNet = 1 Then

                            ProductUsesNetAmount = True

                        Else

                            ProductUsesNetAmount = False

                        End If

                    ElseIf SalesClassType = "M" Then

                        If Product.MagazineBillNet = 1 Then

                            ProductUsesNetAmount = True

                        Else

                            ProductUsesNetAmount = False

                        End If

                    ElseIf SalesClassType = "O" Then

                        If Product.OutOfHomeBillNet = 1 Then

                            ProductUsesNetAmount = True

                        Else

                            ProductUsesNetAmount = False

                        End If

                    ElseIf SalesClassType = "I" Then

                        If Product.InternetBillNet = 1 Then

                            ProductUsesNetAmount = True

                        Else

                            ProductUsesNetAmount = False

                        End If

                    ElseIf SalesClassType = "N" Then

                        If Product.NewspaperBillNet = 1 Then

                            ProductUsesNetAmount = True

                        Else

                            ProductUsesNetAmount = False

                        End If

                    End If

                    ProductRebateAmount = ProductMediaOverrides.RebatePercent.GetValueOrDefault(0)
                    ProductMarkupAmount = ProductMediaOverrides.MarkupPercent.GetValueOrDefault(0)

                Else

                    If SalesClassType = "R" Then

                        If Product.RadioBillNet = 1 Then

                            ProductUsesNetAmount = True
                            ProductRebateAmount = 0
                            ProductMarkupAmount = 0

                        Else

                            ProductUsesNetAmount = False
                            ProductRebateAmount = Product.RadioRebate.GetValueOrDefault(0)
                            ProductMarkupAmount = Product.RadioMarkup.GetValueOrDefault(0)

                        End If

                    ElseIf SalesClassType = "T" Then

                        If Product.TelevisionBillNet = 1 Then

                            ProductUsesNetAmount = True
                            ProductRebateAmount = 0
                            ProductMarkupAmount = 0

                        Else

                            ProductUsesNetAmount = False
                            ProductRebateAmount = Product.TelevisionRebate.GetValueOrDefault(0)
                            ProductMarkupAmount = Product.TelevisionMarkup.GetValueOrDefault(0)

                        End If

                    ElseIf SalesClassType = "M" Then

                        If Product.MagazineBillNet = 1 Then

                            ProductUsesNetAmount = True
                            ProductRebateAmount = 0
                            ProductMarkupAmount = 0

                        Else

                            ProductUsesNetAmount = False
                            ProductRebateAmount = Product.MagazineRebate.GetValueOrDefault(0)
                            ProductMarkupAmount = Product.MagazineMarkup.GetValueOrDefault(0)

                        End If

                    ElseIf SalesClassType = "O" Then

                        If Product.OutOfHomeBillNet = 1 Then

                            ProductUsesNetAmount = True
                            ProductRebateAmount = 0
                            ProductMarkupAmount = 0

                        Else

                            ProductUsesNetAmount = False
                            ProductRebateAmount = Product.OutOfHomeRebate.GetValueOrDefault(0)
                            ProductMarkupAmount = Product.OutOfHomeMarkup.GetValueOrDefault(0)

                        End If

                    ElseIf SalesClassType = "I" Then

                        If Product.InternetBillNet = 1 Then

                            ProductUsesNetAmount = True
                            ProductRebateAmount = 0
                            ProductMarkupAmount = 0

                        Else

                            ProductUsesNetAmount = False
                            ProductRebateAmount = Product.InternetRebate.GetValueOrDefault(0)
                            ProductMarkupAmount = Product.InternetMarkup.GetValueOrDefault(0)

                        End If

                    ElseIf SalesClassType = "N" Then

                        If Product.NewspaperBillNet = 1 Then

                            ProductUsesNetAmount = True
                            ProductRebateAmount = 0
                            ProductMarkupAmount = 0

                        Else

                            ProductUsesNetAmount = False
                            ProductRebateAmount = Product.NewspaperRebate.GetValueOrDefault(0)
                            ProductMarkupAmount = Product.NewspaperMarkup.GetValueOrDefault(0)

                        End If

                    Else

                        ProductUsesNetAmount = True
                        ProductRebateAmount = 0
                        ProductMarkupAmount = 0

                    End If

                End If

            End If

        End Sub

#Region "  Digital Results "

        Public Function LoadAvailableMediaPlanDetailLevelLineTags(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                  ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer)


            Try

                LoadAvailableMediaPlanDetailLevelLineTags = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineTag.Load(DbContext)
                                                             Where Entity.MediaPlanID = MediaPlanID AndAlso
                                                                   If(MediaPlanDetailID <= 0, True, If(Entity.MediaPlanDetailID = MediaPlanDetailID, True, False))
                                                             Select Entity).ToList

            Catch ex As Exception
                LoadAvailableMediaPlanDetailLevelLineTags = Nothing
            End Try

        End Function

#End Region

#End Region

    End Module

End Namespace
