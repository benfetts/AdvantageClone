Namespace Database.Entities

    <Table("CLIENT_ORDER_MARKET")>
    Public Class ClientOrderMarket
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientOrderID
            MarketNumber
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
            CUME
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("CLIENT_ORDER_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ID() As Integer

        <Required>
        <Column("CLIENT_ORDER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientOrderID() As Integer

        <Required>
        <Column("MARKET_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MarketNumber() As Integer

        <Required>
        <Column("SEPTEMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property September() As Boolean

        <Required>
        <Column("OCTOBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property October() As Boolean

        <Required>
        <Column("NOVEMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property November() As Boolean

        <Required>
        <Column("DECEMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property December() As Boolean

        <Required>
        <Column("JANUARY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property January() As Boolean

        <Required>
        <Column("FEBRUARY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property February() As Boolean

        <Required>
        <Column("MARCH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property March() As Boolean

        <Required>
        <Column("APRIL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property April() As Boolean

        <Required>
        <Column("MAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property May() As Boolean

        <Required>
        <Column("JUNE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property June() As Boolean

        <Required>
        <Column("JULY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property July() As Boolean

        <Required>
        <Column("AUGUST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property August() As Boolean

        <Required>
        <Column("WINTER_QUARTERLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property WinterQuarterly() As Boolean

        <Required>
        <Column("SPRING_QUARTERLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SpringQuarterly() As Boolean

        <Required>
        <Column("SUMMER_QUARTERLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SummerQuarterly() As Boolean

        <Required>
        <Column("FALL_QUARTERLY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property FallQuarterly() As Boolean

        <Required>
        <Column("CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Cume() As Boolean

        <ForeignKey("ClientOrderID")>
        Public Overridable Property ClientOrder As Database.Entities.ClientOrder

#End Region

#Region " Methods "

        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case Database.Entities.ClientOrderMarket.Properties.MarketNumber.ToString

                    If Not (Me.January OrElse Me.February OrElse Me.March OrElse Me.April OrElse Me.May OrElse Me.June OrElse
                            Me.July OrElse Me.August OrElse Me.September OrElse Me.October OrElse Me.November OrElse Me.December OrElse
                            Me.WinterQuarterly OrElse Me.SpringQuarterly OrElse Me.SummerQuarterly OrElse Me.FallQuarterly) Then

                        IsValid = False

                        ErrorText = "At least one book must be checked."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
