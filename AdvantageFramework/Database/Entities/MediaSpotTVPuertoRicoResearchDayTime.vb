Namespace Database.Entities

    <Table("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME")>
    Public Class MediaSpotTVPuertoRicoResearchDayTime
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotTVPuertoRicoResearchID
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            Sunday
            StartTime
            EndTime
            StartHour
            EndHour
            Days
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotTVPuertoRicoResearchID() As Integer
        <Required>
        <Column("MONDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Monday() As Boolean
        <Required>
        <Column("TUESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Tuesday() As Boolean
        <Required>
        <Column("WEDNESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Wednesday() As Boolean
        <Required>
        <Column("THURSDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Thursday() As Boolean
        <Required>
        <Column("FRIDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Friday() As Boolean
        <Required>
        <Column("SATURDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Saturday() As Boolean
        <Required>
        <Column("SUNDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Sunday() As Boolean
        <Required>
        <Column("START_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartTime() As String
        <Required>
        <Column("END_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndTime() As String
        <Required>
        <Column("START_HOUR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartHour() As Short
        <Required>
        <Column("END_HOUR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndHour() As Short
        <Required>
        <MaxLength(100)>
        <Column("DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Days() As String

        <ForeignKey("MediaSpotTVPuertoRicoResearchID")>
        Public Overridable Property MediaSpotTVPuertoRicoResearch As Database.Entities.MediaSpotTVPuertoRicoResearch

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
