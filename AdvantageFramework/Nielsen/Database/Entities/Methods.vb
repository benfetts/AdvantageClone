Namespace Nielsen.Database.Entities

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum BroadcastTypeID As Integer
            LocalTV = 1
            NetworkTV = 2
        End Enum

        Public Enum RatingsServiceID As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Nielsen")>
            Nielsen = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Comscore")>
            Comscore = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Numeris")>
            Numeris = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "OzTAM")>
            OzTAM = 4
        End Enum

        Public Enum NCCTVGeo As Short
            DMA = 5
            CDMA = 13
        End Enum

        Public Enum RadioSource As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Nielsen")>
            Nielsen = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Eastlan")>
            Eastlan = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "NielsenCounty")>
            NielsenCounty = 2
        End Enum

        Public Enum NielsenRadioMarketScope As Short
            Market = 0
            County = 1
            CountyCluster = 2
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