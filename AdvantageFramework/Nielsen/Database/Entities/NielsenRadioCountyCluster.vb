Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_COUNTY_CLUSTER")>
    Public Class NielsenRadioCountyCluster
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioCountyPeriodID
            CountyCodeWithinCluster
            Name
            Pop12Plus
            State
            ClusterMeasurementType
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_COUNTY_CLUSTER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("NIELSEN_RADIO_COUNTY_PERIOD_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property NielsenRadioCountyPeriodID() As Integer
        <Required>
        <Column("COUNTY_CODE_WITHIN_CLUSTER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CountyCodeWithinCluster() As Integer
        <Required>
        <MaxLength(22)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <Required>
        <Column("POP_12PLUS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Pop12Plus() As Integer
        <Required>
        <MaxLength(2)>
        <Column("STATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property State() As String
        <Required>
        <MaxLength(1)>
        <Column("CLUSTER_MEASUREMENT_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ClusterMeasurementType() As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
