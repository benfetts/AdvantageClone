Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_COUNTY_PERIOD")>
    Public Class NielsenRadioCountyPeriod
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioMarketNumber
            CountyCode
            Year
            StartDate
            EndDate
            IsCluster
            Name
            State
            WeightingFlag
            MeasurementType
            Copyright
            Validated
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_COUNTY_PERIOD_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("NIELSEN_RADIO_MARKET_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenRadioMarketNumber() As Integer
        <Required>
        <Column("COUNTY_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CountyCode() As Integer
        <Required>
        <Column("YEAR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Year() As Short
        <Required>
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDate() As Date
        <Required>
        <Column("END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndDate() As Date
        <Required>
        <Column("IS_CLUSTER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsCluster() As Boolean
        <Required>
        <MaxLength(22)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <Required>
        <MaxLength(2)>
        <Column("STATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property State() As String
        <Required>
        <MaxLength(1)>
        <Column("WEIGHTING_FLAG", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WeightingFlag() As String
        <Required>
        <MaxLength(1)>
        <Column("MEASUREMENT_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MeasurementType() As String
        <Required>
        <MaxLength(200)>
        <Column("COPYRIGHT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Copyright() As String
        <Required>
        <Column("VALIDATED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Validated() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
