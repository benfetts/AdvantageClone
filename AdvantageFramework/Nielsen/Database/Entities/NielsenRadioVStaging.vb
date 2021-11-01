Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_V_STAGING")>
    Public Class NielsenRadioVStaging
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            GeoIndicator
            EstimateType
            Daypart
            ListeningLocation
            DemoID
            StationComboType
            StationComboID
            PurAud
            NielsenRadioSegmentChildID
            NielsenRadioDaypartID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_V_STAGING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("GEO_INDICATOR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property GeoIndicator() As Short
        <Required>
        <Column("ESTIMATE_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EstimateType() As Short
        <Required>
        <Column("DAYPART")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Daypart() As Short
        <Required>
        <MaxLength(1)>
        <Column("LISTENING_LOCATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ListeningLocation() As String
        <Required>
        <Column("DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DemoID() As Integer
        <Required>
        <Column("STATION_COMBO_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StationComboType() As Short
        <Required>
        <MaxLength(6)>
        <Column("STATION_COMBO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StationComboID() As String
        <Required>
        <Column("PUR_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PurAud() As Integer
        <Column("NIELSEN_RADIO_SEGMENT_CHILD_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NielsenRadioSegmentChildID() As Nullable(Of Integer)
        <Column("NIELSEN_RADIO_DAYPART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NielsenRadioDaypartID() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
