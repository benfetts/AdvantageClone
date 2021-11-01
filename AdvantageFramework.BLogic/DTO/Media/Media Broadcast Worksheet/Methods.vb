Namespace DTO.Media.MediaBroadcastWorksheet

	<HideModuleName()>
	Public Module Methods

#Region " Constants "

        Public Const SubmarketColumnNameTemplate As String = "SM{0}_{1}_{2}"
        Public Const SubmarketCacheTemplate As String = "SM{0}_{1}_{2}_{3}"
        Public Const CanadianUniverseCacheKeyTemplate As String = "{0}_{1}"

#End Region

#Region " Enum "

        Public Enum SubmarketDemoDataType
            Rating = 1
            GRP = 2
            IMP = 3
            GIMP = 4
            Allocation = 5
            Percentage = 6
        End Enum

        Public Enum MediaTypeCodes
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Spot Radio")>
			R
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Spot TV")>
			T
			'<AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Network TV")>
			'N
		End Enum

		Public Enum MediaTypes
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Spot Radio")>
			SpotRadio
			<AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Spot TV")>
			SpotTV
			'<AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "Network TV")>
			'NetworkTV
		End Enum

		Public Enum DateTypes
			Daily = 1
			Weekly = 2
		End Enum

		Public Enum OrderStatuses
            Unordered = 1
            [Partial] = 2
            Ordered = 3
            OrderedModified = 4
        End Enum

        Public Enum TVGeographies
            DMA = 1
            CDMA = 2
        End Enum

        Public Enum RadioGeographies
            Metro = 1
            TSA = 2
            DMA = 3
        End Enum

        Public Enum RadioEthnicities
            All = 1
            Black = 2
            Hispanic = 3
        End Enum

        Public Enum ScheduleSummaries
            [Default]
            Daypart
            DaypartWeeklyDaily
            DaypartGRPWeeklyDaily
            Station
            Length
            DaypartLength
            MarketMonthly
            StationMonthly
        End Enum

        Public Enum MakegoodStatusImages
            RedTriangle = 1
            RedSquare = 2
            BlackSquare = 3
            BlueSquare = 4
            WhiteSquare = 5
        End Enum

        Public Enum RowSources
            ManualEntry = 0
            APImport = 1
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
