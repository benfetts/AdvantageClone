Namespace Database.Classes

    <Serializable()>
    Public Class ClientMediaPercentage
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            RadioRebate
            TVRebate
            MagazineRebate
            NewspaperRebate
            OutdoorRebate
            InternetRebate
            RadioMarkup
            TVMarkup
            MagazineMarkup
            NewspaperMarkup
            OutdoorMarkup
            InternetMarkup
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ClientCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ClientName As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property DivisionCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property DivisionName As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ProductCode As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ProductDescription As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Markup", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property InternetMarkup As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Rebate", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property InternetRebate As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Markup", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property MagazineMarkup As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Rebate", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property MagazineRebate As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Markup", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property NewspaperMarkup As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Rebate", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property NewspaperRebate As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Markup", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property OutdoorMarkup As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Rebate", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property OutdoorRebate As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Markup", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property RadioMarkup As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Rebate", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property RadioRebate As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Markup", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property TVMarkup As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3", CustomColumnCaption:="Rebate", MaxValue:=9999.999, UseMaxValue:=True, MinValue:=-9999.999, UseMinValue:=True),
        AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property TVRebate As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace