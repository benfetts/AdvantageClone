Namespace MediaPlanning.FlowChart

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum CellValueType
            General = 0
            Text = 1
            [Integer] = 2
            [Decimal] = 3
            Currency = 4
            Percentage = 5
            [Date] = 6
            Time = 7
            Accounting = 8
        End Enum

        Public Enum FlowChartGroupingOptions
            Plan_Estimate = 0
            Plan_MediaType_Market = 1
            Plan_MediaType_Vendor = 2
        End Enum

        Public Enum FlowChartSummaryOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "None")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "By Media Type")>
            ByMediaType = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "By Market")>
            ByMarket = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "By Market Vendor")>
            ByMarket_Vendor = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "By Vendor")>
            ByVendor = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "By Quarter")>
            ByQuarter = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "By Year")>
            ByYear = 6
        End Enum

        Public Enum FlowChartDateHeaderOptions
            FromPlan = 0
            ChooseLevels = 1
        End Enum

        Public Enum FlowChartWeekDisplayTypes
            FromPlan = 0
            WeekNumber = 1
            WeekStartDate = 2
            WeekStartDay = 3
        End Enum

        Public Enum FlowChartDateOverrideOptions
            None = 0
            Calendar = 1
            BroadcastCalendar = 2
        End Enum

        Public Enum EstimateColumnTotalsTypes
            [Default] = 1
            ByMonth = 2
            Both = 3
        End Enum

        Public Enum GrandTotalsTypes
            [Default] = 1
            ByMonth = 2
            Both = 3
        End Enum

        Public Enum GroupByLevels
            None = 0
            Level1 = 1
            Level2 = 2
            Level3 = 3
            Level4 = 4
            Level5 = 5
            Level6 = 6
            Level7 = 7
            Level8 = 8
            Level9 = 9
            Level10 = 10
        End Enum

        Public Enum FlowChartEstimateCustomLevels
            None = 0
            Package = 1
            DateRange = 2
            AdSizes = 3
        End Enum

        Public Enum DataColumns
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

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#End Region

    End Module

End Namespace
