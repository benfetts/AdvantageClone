Namespace Nielsen.Database.Entities

    <Table("NIELSEN_TV_PROGRAM")>
    Public Class NielsenTVProgram
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenTVProgramBookID
            StationCode
            QtrHourStartTime
            QtrHourEndTime
            ProgramName
            Subtitle
            TrackageName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_TV_PROGRAM_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Int64
        <Required>
        <Column("NIELSEN_TV_PROGRAM_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenTVProgramBookID() As Integer
        <Required>
        <Column("STATION_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StationCode() As Integer
        <Required>
        <Column("QTR_HOUR_START_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property QtrHourStartTime() As Date
        <Required>
        <Column("QTR_HOUR_END_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property QtrHourEndTime() As Date
        <Required>
        <MaxLength(14)>
        <Column("PROGRAM_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ProgramName() As String
        <MaxLength(12)>
        <Column("SUBTITLE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Subtitle() As String
        <MaxLength(14)>
        <Column("TRACKAGE_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TrackageName() As String

        Public Overridable Property NielsenTVProgramBook As Nielsen.Database.Entities.NielsenTVProgramBook

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
