Namespace Nielsen.Database.Entities

    <Table("NIELSEN_TV_DAYPART")>
    Public Class NielsenTVDaypart
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenDaypartID
            IsHispanic
            TimeZone
            Name
            NumberOfQuarterhours
            MilitaryStartTime
            MilitaryEndTime
            StartMinute
            EndMinute
            UseSegment
            Sunday
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_TV_DAYPART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("NIELSEN_DAYPART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenDaypartID() As Integer
        <Required>
        <Column("IS_HISPANIC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsHispanic() As Boolean
        <Required>
        <MaxLength(1)>
        <Column("TIME_ZONE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property TimeZone() As String
        <Required>
        <MaxLength(30)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <Required>
        <Column("NUMBER_QUARTER_HOURS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NumberOfQuarterhours() As Short
        <Required>
        <Column("MIL_START_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MilitaryStartTime() As Short
        <Required>
        <Column("MIL_END_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MilitaryEndTime() As Short
        <Required>
        <Column("START_MINUTE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartMinute() As Short
        <Required>
        <Column("END_MINUTE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndMinute() As Short
        <Required>
        <Column("USE_SEGMENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UseSegment() As Boolean
        <Required>
        <Column("SUNDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Sunday() As Boolean
        <Required>
        <Column("MONDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Monday() As Boolean
        <Required>
        <Column("TUESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Tuesday() As Boolean
        <Required>
        <Column("WEDNESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Wednesday() As Boolean
        <Required>
        <Column("THURSDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Thursday() As Boolean
        <Required>
        <Column("FRIDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Friday() As Boolean
        <Required>
        <Column("SATURDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Saturday() As Boolean
        <Required>
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
