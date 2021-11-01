Namespace Database.Entities

    <Table("MEDIA_RFP_AVAILABLE_LINE")>
    Public Class MediaRFPAvailLine
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaRFPHeaderID
            NetworkName
            CableNetworkStationCode
            CallLetters
            DaypartName
            DaypartID
            AvailName
            SpotLength
            StartDate
            EndDate
            StartTime
            EndTime
            StartHour
            EndHour
            Sunday
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            Program
            Status
            BatchNumber
            MediaBroadcastWorksheetMarketDetailID
            Comments
            CableNetworkNielsenTVStationCode
            ComscoreTVStationCallLetters
            'StationID
            MediaRFPHeader
            MediaBroadcastWorksheetMarketDetail
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_RFP_AVAILABLE_LINE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_RFP_HEADER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaRFPHeaderID() As Integer
        <Column("NETWORK_NAME", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetworkName() As String
        <Column("CABLE_NETWORK_STATION_CODE", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CableNetworkStationCode() As String
        <Required>
        <MaxLength(20)>
        <Column("CALL_LETTERS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CallLetters() As String
        <Column("DAY_PART_NAME", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaypartName() As String
        <Column("DAY_PART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaypartID() As Nullable(Of Integer)
        <Column("AVAIL_NAME", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property AvailName() As String
        <Required>
        <Column("SPOT_LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SpotLength() As Short
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property StartDate() As Nullable(Of Date)
        <Column("END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property EndDate() As Nullable(Of Date)
        <Column("START_TIME", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property StartTime() As String
        <Column("END_TIME", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property EndTime() As String
        <Column("START_HOUR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartHour() As Nullable(Of Short)
        <Column("END_HOUR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndHour() As Nullable(Of Short)
        <Required>
        <Column("SUNDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Sunday() As Boolean
        <Required>
        <Column("MONDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Monday() As Boolean
        <Required>
        <Column("TUESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Tuesday() As Boolean
        <Required>
        <Column("WEDNESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Wednesday() As Boolean
        <Required>
        <Column("THURSDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Thursday() As Boolean
        <Required>
        <Column("FRIDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Friday() As Boolean
        <Required>
        <Column("SATURDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Saturday() As Boolean
        <Column("PROGRAM", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Program() As String
        <Required>
        <Column("STATUS")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Status() As String
        <Required>
        <Column("BATCH_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BatchNumber() As Short
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetMarketDetailID() As Nullable(Of Integer)
        <Column("COMMENTS", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comments() As String
        <Column("CABLE_NETWORK_NIELSEN_TV_STATION_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CableNetworkNielsenTVStationCode() As Nullable(Of Integer)
        <Column("COMSCORE_TV_STATION_CALL_LETTERS", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComscoreTVStationCallLetters() As String
        <Column("FILE_SOURCE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FileSource() As AdvantageFramework.Database.Entities.MediaRFPAvailLineFileSource

        <ForeignKey("MediaRFPHeaderID")>
        Public Overridable Property MediaRFPHeader As Database.Entities.MediaRFPHeader
        Public Overridable Property MediaBroadcastWorksheetMarketDetail As Database.Entities.MediaBroadcastWorksheetMarketDetail
        Public Overridable Property MediaRFPDemos As ICollection(Of Database.Entities.MediaRFPDemo)
        Public Overridable Property MediaRFPAvailLineSpots As ICollection(Of Database.Entities.MediaRFPAvailLineSpot)

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaRFPDemos = New HashSet(Of AdvantageFramework.Database.Entities.MediaRFPDemo)
            Me.MediaRFPAvailLineSpots = New HashSet(Of AdvantageFramework.Database.Entities.MediaRFPAvailLineSpot)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
