Namespace DTO

    Public Class ClientOrderMarket
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientOrderID
            MarketNumber
            Cume
            September
            October
            November
            December
            January
            February
            March
            April
            May
            June
            July
            August

            WinterQuarterly
            SpringQuarterly
            SummerQuarterly
            FallQuarterly
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ClientOrderID() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=AdvantageFramework.BaseClasses.Methods.PropertyTypes.NielsenMarket)>
        Public Property MarketNumber() As Integer

        Public Property Cume() As Boolean

        Public Property September() As Boolean
        Public Property October() As Boolean
        Public Property November() As Boolean
        Public Property December() As Boolean
        Public Property January() As Boolean
        Public Property February() As Boolean
        Public Property March() As Boolean
        Public Property April() As Boolean
        Public Property May() As Boolean
        Public Property June() As Boolean
        Public Property July() As Boolean
        Public Property August() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Fall Quarterly (Oct)")>
        Public Property FallQuarterly() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Winter Quarterly (Jan)")>
        Public Property WinterQuarterly() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Spring Quarterly (Apr)")>
        Public Property SpringQuarterly() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Summer Quarterly (Jul)")>
        Public Property SummerQuarterly() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ClientOrderMarket As Database.Entities.ClientOrderMarket)

            Me.ID = ClientOrderMarket.ID
            Me.ClientOrderID = ClientOrderMarket.ClientOrderID
            Me.MarketNumber = ClientOrderMarket.MarketNumber
            Me.September = ClientOrderMarket.September
            Me.October = ClientOrderMarket.October
            Me.November = ClientOrderMarket.November
            Me.December = ClientOrderMarket.December
            Me.January = ClientOrderMarket.January
            Me.February = ClientOrderMarket.February
            Me.March = ClientOrderMarket.March
            Me.April = ClientOrderMarket.April
            Me.May = ClientOrderMarket.May
            Me.June = ClientOrderMarket.June
            Me.July = ClientOrderMarket.July
            Me.August = ClientOrderMarket.August

            Me.WinterQuarterly = ClientOrderMarket.WinterQuarterly
            Me.SpringQuarterly = ClientOrderMarket.SpringQuarterly
            Me.SummerQuarterly = ClientOrderMarket.SummerQuarterly
            Me.FallQuarterly = ClientOrderMarket.FallQuarterly

            Me.CUME = ClientOrderMarket.Cume

        End Sub
        Public Sub SaveToEntity(ByRef ClientOrderMarket As Database.Entities.ClientOrderMarket)

            ClientOrderMarket.ID = Me.ID
            ClientOrderMarket.ClientOrderID = Me.ClientOrderID
            ClientOrderMarket.MarketNumber = Me.MarketNumber
            ClientOrderMarket.September = Me.September
            ClientOrderMarket.October = Me.October
            ClientOrderMarket.November = Me.November
            ClientOrderMarket.December = Me.December
            ClientOrderMarket.January = Me.January
            ClientOrderMarket.February = Me.February
            ClientOrderMarket.March = Me.March
            ClientOrderMarket.April = Me.April
            ClientOrderMarket.May = Me.May
            ClientOrderMarket.June = Me.June
            ClientOrderMarket.July = Me.July
            ClientOrderMarket.August = Me.August

            ClientOrderMarket.WinterQuarterly = Me.WinterQuarterly
            ClientOrderMarket.SpringQuarterly = Me.SpringQuarterly
            ClientOrderMarket.SummerQuarterly = Me.SummerQuarterly
            ClientOrderMarket.FallQuarterly = Me.FallQuarterly

            ClientOrderMarket.Cume = Me.Cume

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
