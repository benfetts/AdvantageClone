Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketID
            OnHold
            LineNumber
            MakegoodNumber
            MakegoodDate
            MakegoodSpots
            MadegoodNumber
            RevisionNumber
            VendorCode
            VendorName
            VendorNielsenRadioStationComboID
            VendorNCCTVSyscodeID
            VendorNielsenTVStationCode
            VendorIsCableSystem
            VendorIsComboRadioStation
            CableNetworkStationCode
            CableNetworkStationDescription
            CableNetworkNielsenTVStationCode
            BookProgram
            Program
            DaypartID
            DaypartCode
            DaypartDescription
            Product
            Piggyback
            Length
            Days
            Sunday
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            StartTime
            EndTime
            StartHour
            EndHour
            Comments
            Bookend
            ValueAdded
            DefaultRate
            OrderComments
            BookPrimaryRating
            PrimaryRating
            BookPrimaryShare
            PrimaryShare
            PrimaryHPUT
            PrimaryCPP
            PrimaryGRP
            PrimaryReach
            PrimaryFrequency
            BookPrimaryImpressions
            PrimaryImpressions
            PrimaryGrossImpressions
            PrimaryUniverse
            PrimaryCumeImpressions
            BookPrimaryAQHRating
            PrimaryAQHRating
            BookPrimaryAQH
            PrimaryAQH
            PrimaryCumeRating
            PrimaryCume
            PrimaryCPM
            BookSecondaryRating
            SecondaryRating
            BookSecondaryShare
            SecondaryShare
            SecondaryHPUT
            SecondaryCPP
            SecondaryGRP
            SecondaryReach
            SecondaryFrequency
            BookSecondaryImpressions
            SecondaryImpressions
            SecondaryGrossImpressions
            SecondaryUniverse
            SecondaryCumeImpressions
            BookSecondaryAQHRating
            SecondaryAQHRating
            BookSecondaryAQH
            SecondaryAQH
            SecondaryCumeRating
            SecondaryCume
            SecondaryCPM
            PrimaryVendorSubmittedRating
            PrimaryVendorSubmittedShare
            PrimaryVendorSubmittedImpressions
            SecondaryVendorSubmittedRating
            SecondaryVendorSubmittedShare
            SecondaryVendorSubmittedImpressions
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
            OverridePost
            OverridePostImpressions
            OverridePostAQH
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetMarketID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OnHold() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineNumber() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MakegoodNumber() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MakegoodDate() As Date
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MakegoodSpots() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MadegoodNumber() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property RevisionNumber() As Integer
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
        Public Property VendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.NielsenRadioStation)>
        Public Property VendorNielsenRadioStationComboID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorNCCTVSyscodeID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.NielsenTVStation)>
        Public Property VendorNielsenTVStationCode() As Nullable(Of Integer)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VendorIsCableSystem() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VendorIsComboRadioStation() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Cable Network")>
        Public Property CableNetworkStationCode() As String
        Public Property CableNetworkStationDescription() As String
        Public Property CableNetworkNielsenTVStationCode() As Nullable(Of Integer)
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BookProgram() As String
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Program() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaypartID() As Nullable(Of Integer)
        Public Property DaypartCode() As String
        Public Property DaypartDescription() As String
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Product() As String
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Piggyback() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Length() As Short
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Days() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Sunday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Monday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Tuesday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Wednesday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Thursday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Friday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Saturday() As Boolean
        <Required(AllowEmptyStrings:=True)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartTime() As String
        <Required(AllowEmptyStrings:=True)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndTime() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartHour() As Short
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndHour() As Short
        <Required(AllowEmptyStrings:=True)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Comments() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Bookend() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ValueAdded() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultRate() As Decimal
        <Required(AllowEmptyStrings:=True)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderComments() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookPrimaryRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookPrimaryShare() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryShare() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryHPUT() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryCPP() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryGRP() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryReach() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryFrequency() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookPrimaryImpressions() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryImpressions() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryGrossImpressions() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryUniverse() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryCumeImpressions() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookPrimaryAQHRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryAQHRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookPrimaryAQH() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryAQH() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryCumeRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryCume() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryCPM() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookSecondaryRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookSecondaryShare() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryShare() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryHPUT() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryCPP() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryGRP() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryReach() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryFrequency() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookSecondaryImpressions() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryImpressions() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryGrossImpressions() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryUniverse() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryCumeImpressions() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookSecondaryAQHRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryAQHRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookSecondaryAQH() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryAQH() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryCumeRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryCume() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryCPM() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryVendorSubmittedRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryVendorSubmittedShare() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryVendorSubmittedImpressions() As Long
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryVendorSubmittedRating() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryVendorSubmittedShare() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryVendorSubmittedImpressions() As Long
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedByUserCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OverridePost() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OverridePostImpressions() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OverridePostAQH() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.MediaBroadcastWorksheetMarketID = 0
            Me.LineNumber = 0
            Me.MakegoodNumber = 0
            Me.MakegoodDate = Date.MinValue
            Me.MakegoodSpots = 0
            Me.MadegoodNumber = 0
            Me.RevisionNumber = -1
            Me.VendorCode = String.Empty
            Me.VendorName = String.Empty
            Me.VendorNielsenRadioStationComboID = Nothing
            Me.VendorNCCTVSyscodeID = Nothing
            Me.VendorNielsenTVStationCode = Nothing
            Me.VendorIsCableSystem = False
            Me.CableNetworkStationCode = String.Empty
            Me.CableNetworkStationDescription = String.Empty
            Me.CableNetworkNielsenTVStationCode = Nothing
            Me.BookProgram = String.Empty
            Me.Program = String.Empty
            Me.DaypartID = Nothing
            Me.DaypartCode = String.Empty
            Me.DaypartDescription = String.Empty
            Me.Product = String.Empty
            Me.Piggyback = String.Empty
            Me.Length = Nothing
            Me.Days = String.Empty
            Me.Sunday = False
            Me.Monday = False
            Me.Tuesday = False
            Me.Wednesday = False
            Me.Thursday = False
            Me.Friday = False
            Me.Saturday = False
            Me.StartTime = String.Empty
            Me.EndTime = String.Empty
            Me.Comments = String.Empty
            Me.Bookend = False
            Me.ValueAdded = False
            Me.DefaultRate = 0
            Me.OrderComments = String.Empty
            Me.OnHold = False
            Me.BookPrimaryRating = 0
            Me.PrimaryRating = 0
            Me.BookPrimaryShare = 0
            Me.PrimaryShare = 0
            Me.PrimaryHPUT = 0
            Me.PrimaryCPP = 0
            Me.PrimaryGRP = 0
            Me.PrimaryReach = 0
            Me.PrimaryFrequency = 0
            Me.BookPrimaryImpressions = 0
            Me.PrimaryImpressions = 0
            Me.PrimaryGrossImpressions = 0
            Me.PrimaryUniverse = 0
            Me.PrimaryCumeImpressions = 0
            Me.BookPrimaryAQHRating = 0
            Me.PrimaryAQHRating = 0
            Me.BookPrimaryAQH = 0
            Me.PrimaryAQH = 0
            Me.PrimaryCumeRating = 0
            Me.PrimaryCume = 0
            Me.PrimaryCPM = 0
            Me.BookSecondaryRating = 0
            Me.SecondaryRating = 0
            Me.BookSecondaryShare = 0
            Me.SecondaryShare = 0
            Me.SecondaryHPUT = 0
            Me.SecondaryCPP = 0
            Me.SecondaryGRP = 0
            Me.SecondaryReach = 0
            Me.SecondaryFrequency = 0
            Me.BookSecondaryImpressions = 0
            Me.SecondaryImpressions = 0
            Me.SecondaryGrossImpressions = 0
            Me.SecondaryUniverse = 0
            Me.SecondaryCumeImpressions = 0
            Me.BookSecondaryAQHRating = 0
            Me.SecondaryAQHRating = 0
            Me.BookSecondaryAQH = 0
            Me.SecondaryAQH = 0
            Me.SecondaryCumeRating = 0
            Me.SecondaryCume = 0
            Me.SecondaryCPM = 0
            Me.PrimaryVendorSubmittedRating = 0
            Me.PrimaryVendorSubmittedShare = 0
            Me.PrimaryVendorSubmittedImpressions = 0
            Me.SecondaryVendorSubmittedRating = 0
            Me.SecondaryVendorSubmittedShare = 0
            Me.SecondaryVendorSubmittedImpressions = 0
            Me.CreatedByUserCode = String.Empty
            Me.CreatedDate = Date.MinValue
            Me.ModifiedByUserCode = Nothing
            Me.ModifiedDate = Nothing
            Me.OverridePost = False
            Me.OverridePostImpressions = False
            Me.OverridePostAQH = False

        End Sub
        Public Sub New(MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail)

            Me.ID = MediaBroadcastWorksheetMarketDetail.ID
            Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID
            Me.LineNumber = MediaBroadcastWorksheetMarketDetail.LineNumber
            Me.MakegoodNumber = MediaBroadcastWorksheetMarketDetail.MakegoodNumber
            Me.MakegoodDate = MediaBroadcastWorksheetMarketDetail.MakegoodDate
            Me.MakegoodSpots = MediaBroadcastWorksheetMarketDetail.MakegoodSpots
            Me.MadegoodNumber = MediaBroadcastWorksheetMarketDetail.MadegoodNumber
            Me.RevisionNumber = MediaBroadcastWorksheetMarketDetail.RevisionNumber
            Me.VendorCode = MediaBroadcastWorksheetMarketDetail.VendorCode
            Me.VendorName = If(MediaBroadcastWorksheetMarketDetail.Vendor IsNot Nothing, MediaBroadcastWorksheetMarketDetail.Vendor.Name, String.Empty)

            If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                Me.VendorNielsenRadioStationComboID = If(MediaBroadcastWorksheetMarketDetail.Vendor IsNot Nothing, MediaBroadcastWorksheetMarketDetail.Vendor.NielsenRadioStationComboID, Nothing)

            Else

                Me.VendorNielsenRadioStationComboID = If(MediaBroadcastWorksheetMarketDetail.Vendor IsNot Nothing, MediaBroadcastWorksheetMarketDetail.Vendor.EastlanRadioStationComboID, Nothing)

            End If

            Me.VendorNCCTVSyscodeID = If(MediaBroadcastWorksheetMarketDetail.Vendor IsNot Nothing, MediaBroadcastWorksheetMarketDetail.Vendor.NCCTVSyscodeID, Nothing)

            If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                Me.VendorNielsenTVStationCode = If(MediaBroadcastWorksheetMarketDetail.Vendor IsNot Nothing, MediaBroadcastWorksheetMarketDetail.Vendor.NielsenTVStationCode, Nothing)

            ElseIf MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                Me.VendorNielsenTVStationCode = If(MediaBroadcastWorksheetMarketDetail.Vendor IsNot Nothing, MediaBroadcastWorksheetMarketDetail.Vendor.ComscoreTVStationID, Nothing)

            ElseIf MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.Methods.RatingsServiceID.NielsenPuertoRico Then

                Me.VendorNielsenTVStationCode = If(MediaBroadcastWorksheetMarketDetail.Vendor IsNot Nothing, MediaBroadcastWorksheetMarketDetail.Vendor.NPRStationID, Nothing)

            End If

            Me.VendorIsCableSystem = If(MediaBroadcastWorksheetMarketDetail.Vendor IsNot Nothing, MediaBroadcastWorksheetMarketDetail.Vendor.IsCableSystem, False)
            Me.CableNetworkStationCode = MediaBroadcastWorksheetMarketDetail.CableNetworkStationCode
            'Me.CableNetworkStationDescription = If(MediaBroadcastWorksheetMarketDetail.CableNetworkStation IsNot Nothing, MediaBroadcastWorksheetMarketDetail.CableNetworkStation.Description, String.Empty)
            'Me.NielsenTVStationCode = If(MediaBroadcastWorksheetMarketDetail.CableNetworkStation IsNot Nothing, MediaBroadcastWorksheetMarketDetail.CableNetworkStation.NielsenTVStationCode, Nothing)
            Me.CableNetworkStationDescription = String.Empty
            Me.CableNetworkNielsenTVStationCode = MediaBroadcastWorksheetMarketDetail.CableNetworkNielsenTVStationCode
            Me.BookProgram = MediaBroadcastWorksheetMarketDetail.BookProgram
            Me.Program = MediaBroadcastWorksheetMarketDetail.Program
            Me.DaypartID = MediaBroadcastWorksheetMarketDetail.DaypartID
            Me.DaypartCode = If(MediaBroadcastWorksheetMarketDetail.Daypart IsNot Nothing, MediaBroadcastWorksheetMarketDetail.Daypart.Code, String.Empty)
            Me.DaypartDescription = If(MediaBroadcastWorksheetMarketDetail.Daypart IsNot Nothing, MediaBroadcastWorksheetMarketDetail.Daypart.Description, String.Empty)
            Me.Product = MediaBroadcastWorksheetMarketDetail.Product
            Me.Piggyback = MediaBroadcastWorksheetMarketDetail.Piggyback
            Me.Length = MediaBroadcastWorksheetMarketDetail.Length
            Me.Days = MediaBroadcastWorksheetMarketDetail.Days
            Me.Sunday = MediaBroadcastWorksheetMarketDetail.Sunday
            Me.Monday = MediaBroadcastWorksheetMarketDetail.Monday
            Me.Tuesday = MediaBroadcastWorksheetMarketDetail.Tuesday
            Me.Wednesday = MediaBroadcastWorksheetMarketDetail.Wednesday
            Me.Thursday = MediaBroadcastWorksheetMarketDetail.Thursday
            Me.Friday = MediaBroadcastWorksheetMarketDetail.Friday
            Me.Saturday = MediaBroadcastWorksheetMarketDetail.Saturday
            Me.StartTime = MediaBroadcastWorksheetMarketDetail.StartTime
            Me.EndTime = MediaBroadcastWorksheetMarketDetail.EndTime
            Me.Comments = MediaBroadcastWorksheetMarketDetail.Comments
            Me.Bookend = MediaBroadcastWorksheetMarketDetail.Bookend
            Me.ValueAdded = MediaBroadcastWorksheetMarketDetail.ValueAdded
            Me.DefaultRate = MediaBroadcastWorksheetMarketDetail.DefaultRate
            Me.OrderComments = MediaBroadcastWorksheetMarketDetail.OrderComments
            Me.OnHold = MediaBroadcastWorksheetMarketDetail.OnHold
            Me.BookPrimaryRating = MediaBroadcastWorksheetMarketDetail.BookPrimaryRating
            Me.PrimaryRating = MediaBroadcastWorksheetMarketDetail.PrimaryRating
            Me.BookPrimaryShare = MediaBroadcastWorksheetMarketDetail.BookPrimaryShare
            Me.PrimaryShare = MediaBroadcastWorksheetMarketDetail.PrimaryShare
            Me.PrimaryHPUT = MediaBroadcastWorksheetMarketDetail.PrimaryHPUT
            Me.PrimaryCPP = MediaBroadcastWorksheetMarketDetail.PrimaryCPP
            Me.PrimaryGRP = MediaBroadcastWorksheetMarketDetail.PrimaryGRP
            Me.PrimaryReach = MediaBroadcastWorksheetMarketDetail.PrimaryReach
            Me.PrimaryFrequency = MediaBroadcastWorksheetMarketDetail.PrimaryFrequency
            Me.BookPrimaryImpressions = MediaBroadcastWorksheetMarketDetail.BookPrimaryImpressions
            Me.PrimaryImpressions = MediaBroadcastWorksheetMarketDetail.PrimaryImpressions
            Me.PrimaryGrossImpressions = MediaBroadcastWorksheetMarketDetail.PrimaryGrossImpressions
            Me.PrimaryUniverse = MediaBroadcastWorksheetMarketDetail.PrimaryUniverse
            Me.PrimaryCumeImpressions = MediaBroadcastWorksheetMarketDetail.PrimaryCumeImpressions
            Me.BookPrimaryAQHRating = MediaBroadcastWorksheetMarketDetail.BookPrimaryAQHRating
            Me.PrimaryAQHRating = MediaBroadcastWorksheetMarketDetail.PrimaryAQHRating
            Me.BookPrimaryAQH = MediaBroadcastWorksheetMarketDetail.BookPrimaryAQH
            Me.PrimaryAQH = MediaBroadcastWorksheetMarketDetail.PrimaryAQH
            Me.PrimaryCumeRating = MediaBroadcastWorksheetMarketDetail.PrimaryCumeRating
            Me.PrimaryCume = MediaBroadcastWorksheetMarketDetail.PrimaryCume
            Me.PrimaryCPM = MediaBroadcastWorksheetMarketDetail.PrimaryCPM
            Me.BookSecondaryRating = MediaBroadcastWorksheetMarketDetail.BookSecondaryRating
            Me.SecondaryRating = MediaBroadcastWorksheetMarketDetail.SecondaryRating
            Me.BookSecondaryShare = MediaBroadcastWorksheetMarketDetail.BookSecondaryShare
            Me.SecondaryShare = MediaBroadcastWorksheetMarketDetail.SecondaryShare
            Me.SecondaryHPUT = MediaBroadcastWorksheetMarketDetail.SecondaryHPUT
            Me.SecondaryCPP = MediaBroadcastWorksheetMarketDetail.SecondaryCPP
            Me.SecondaryGRP = MediaBroadcastWorksheetMarketDetail.SecondaryGRP
            Me.SecondaryReach = MediaBroadcastWorksheetMarketDetail.SecondaryReach
            Me.SecondaryFrequency = MediaBroadcastWorksheetMarketDetail.SecondaryFrequency
            Me.BookSecondaryImpressions = MediaBroadcastWorksheetMarketDetail.BookSecondaryImpressions
            Me.SecondaryImpressions = MediaBroadcastWorksheetMarketDetail.SecondaryImpressions
            Me.SecondaryGrossImpressions = MediaBroadcastWorksheetMarketDetail.SecondaryGrossImpressions
            Me.SecondaryUniverse = MediaBroadcastWorksheetMarketDetail.SecondaryUniverse
            Me.SecondaryCumeImpressions = MediaBroadcastWorksheetMarketDetail.SecondaryCumeImpressions
            Me.BookSecondaryAQHRating = MediaBroadcastWorksheetMarketDetail.BookSecondaryAQHRating
            Me.SecondaryAQHRating = MediaBroadcastWorksheetMarketDetail.SecondaryAQHRating
            Me.BookSecondaryAQH = MediaBroadcastWorksheetMarketDetail.BookSecondaryAQH
            Me.SecondaryAQH = MediaBroadcastWorksheetMarketDetail.SecondaryAQH
            Me.SecondaryCumeRating = MediaBroadcastWorksheetMarketDetail.SecondaryCumeRating
            Me.SecondaryCume = MediaBroadcastWorksheetMarketDetail.SecondaryCume
            Me.SecondaryCPM = MediaBroadcastWorksheetMarketDetail.SecondaryCPM
            Me.PrimaryVendorSubmittedRating = MediaBroadcastWorksheetMarketDetail.PrimaryVendorSubmittedRating
            Me.PrimaryVendorSubmittedShare = MediaBroadcastWorksheetMarketDetail.PrimaryVendorSubmittedShare
            Me.PrimaryVendorSubmittedImpressions = MediaBroadcastWorksheetMarketDetail.PrimaryVendorSubmittedImpressions
            Me.SecondaryVendorSubmittedRating = MediaBroadcastWorksheetMarketDetail.SecondaryVendorSubmittedRating
            Me.SecondaryVendorSubmittedShare = MediaBroadcastWorksheetMarketDetail.SecondaryVendorSubmittedShare
            Me.SecondaryVendorSubmittedImpressions = MediaBroadcastWorksheetMarketDetail.SecondaryVendorSubmittedImpressions
            Me.CreatedByUserCode = MediaBroadcastWorksheetMarketDetail.CreatedByUserCode
            Me.CreatedDate = MediaBroadcastWorksheetMarketDetail.CreatedDate
            Me.ModifiedByUserCode = MediaBroadcastWorksheetMarketDetail.ModifiedByUserCode
            Me.ModifiedDate = MediaBroadcastWorksheetMarketDetail.ModifiedDate
            Me.OverridePost = MediaBroadcastWorksheetMarketDetail.OverridePost
            Me.OverridePostImpressions = MediaBroadcastWorksheetMarketDetail.OverridePostImpressions
            Me.OverridePostAQH = MediaBroadcastWorksheetMarketDetail.OverridePostAQH

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail)

            MediaBroadcastWorksheetMarketDetail.ID = Me.ID
            MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID = Me.MediaBroadcastWorksheetMarketID
            MediaBroadcastWorksheetMarketDetail.LineNumber = Me.LineNumber
            MediaBroadcastWorksheetMarketDetail.MakegoodNumber = Me.MakegoodNumber
            MediaBroadcastWorksheetMarketDetail.MakegoodDate = Me.MakegoodDate
            MediaBroadcastWorksheetMarketDetail.MakegoodSpots = Me.MakegoodSpots
            MediaBroadcastWorksheetMarketDetail.MadegoodNumber = Me.MadegoodNumber
            MediaBroadcastWorksheetMarketDetail.RevisionNumber = Me.RevisionNumber
            MediaBroadcastWorksheetMarketDetail.VendorCode = Me.VendorCode
            MediaBroadcastWorksheetMarketDetail.CableNetworkStationCode = Me.CableNetworkStationCode
            MediaBroadcastWorksheetMarketDetail.CableNetworkNielsenTVStationCode = Me.CableNetworkNielsenTVStationCode
            MediaBroadcastWorksheetMarketDetail.BookProgram = Me.BookProgram
            MediaBroadcastWorksheetMarketDetail.Program = Me.Program
            MediaBroadcastWorksheetMarketDetail.DaypartID = Me.DaypartID
            MediaBroadcastWorksheetMarketDetail.Product = Me.Product
            MediaBroadcastWorksheetMarketDetail.Piggyback = Me.Piggyback
            MediaBroadcastWorksheetMarketDetail.Length = Me.Length
            MediaBroadcastWorksheetMarketDetail.Days = Me.Days
            MediaBroadcastWorksheetMarketDetail.Sunday = Me.Sunday
            MediaBroadcastWorksheetMarketDetail.Monday = Me.Monday
            MediaBroadcastWorksheetMarketDetail.Tuesday = Me.Tuesday
            MediaBroadcastWorksheetMarketDetail.Wednesday = Me.Wednesday
            MediaBroadcastWorksheetMarketDetail.Thursday = Me.Thursday
            MediaBroadcastWorksheetMarketDetail.Friday = Me.Friday
            MediaBroadcastWorksheetMarketDetail.Saturday = Me.Saturday
            MediaBroadcastWorksheetMarketDetail.StartTime = Me.StartTime
            MediaBroadcastWorksheetMarketDetail.EndTime = Me.EndTime
            MediaBroadcastWorksheetMarketDetail.Comments = Me.Comments
            MediaBroadcastWorksheetMarketDetail.Bookend = Me.Bookend
            MediaBroadcastWorksheetMarketDetail.ValueAdded = Me.ValueAdded
            MediaBroadcastWorksheetMarketDetail.DefaultRate = Me.DefaultRate
            MediaBroadcastWorksheetMarketDetail.OrderComments = Me.OrderComments
            MediaBroadcastWorksheetMarketDetail.OnHold = Me.OnHold
            MediaBroadcastWorksheetMarketDetail.BookPrimaryRating = Me.BookPrimaryRating
            MediaBroadcastWorksheetMarketDetail.PrimaryRating = Me.PrimaryRating
            MediaBroadcastWorksheetMarketDetail.BookPrimaryShare = Me.BookPrimaryShare
            MediaBroadcastWorksheetMarketDetail.PrimaryShare = Me.PrimaryShare
            MediaBroadcastWorksheetMarketDetail.PrimaryHPUT = Me.PrimaryHPUT
            MediaBroadcastWorksheetMarketDetail.PrimaryCPP = Me.PrimaryCPP
            MediaBroadcastWorksheetMarketDetail.PrimaryGRP = Me.PrimaryGRP
            MediaBroadcastWorksheetMarketDetail.PrimaryReach = Me.PrimaryReach
            MediaBroadcastWorksheetMarketDetail.PrimaryFrequency = Me.PrimaryFrequency
            MediaBroadcastWorksheetMarketDetail.BookPrimaryImpressions = Me.BookPrimaryImpressions
            MediaBroadcastWorksheetMarketDetail.PrimaryImpressions = Me.PrimaryImpressions
            MediaBroadcastWorksheetMarketDetail.PrimaryGrossImpressions = Me.PrimaryGrossImpressions
            MediaBroadcastWorksheetMarketDetail.PrimaryUniverse = Me.PrimaryUniverse
            MediaBroadcastWorksheetMarketDetail.PrimaryCumeImpressions = Me.PrimaryCumeImpressions
            MediaBroadcastWorksheetMarketDetail.BookPrimaryAQHRating = Me.BookPrimaryAQHRating
            MediaBroadcastWorksheetMarketDetail.PrimaryAQHRating = Me.PrimaryAQHRating
            MediaBroadcastWorksheetMarketDetail.BookPrimaryAQH = Me.BookPrimaryAQH
            MediaBroadcastWorksheetMarketDetail.PrimaryAQH = Me.PrimaryAQH
            MediaBroadcastWorksheetMarketDetail.PrimaryCumeRating = Me.PrimaryCumeRating
            MediaBroadcastWorksheetMarketDetail.PrimaryCume = Me.PrimaryCume
            MediaBroadcastWorksheetMarketDetail.PrimaryCPM = Me.PrimaryCPM
            MediaBroadcastWorksheetMarketDetail.BookSecondaryRating = Me.BookSecondaryRating
            MediaBroadcastWorksheetMarketDetail.SecondaryRating = Me.SecondaryRating
            MediaBroadcastWorksheetMarketDetail.BookSecondaryShare = Me.BookSecondaryShare
            MediaBroadcastWorksheetMarketDetail.SecondaryShare = Me.SecondaryShare
            MediaBroadcastWorksheetMarketDetail.SecondaryHPUT = Me.SecondaryHPUT
            MediaBroadcastWorksheetMarketDetail.SecondaryCPP = Me.SecondaryCPP
            MediaBroadcastWorksheetMarketDetail.SecondaryGRP = Me.SecondaryGRP
            MediaBroadcastWorksheetMarketDetail.SecondaryReach = Me.SecondaryReach
            MediaBroadcastWorksheetMarketDetail.SecondaryFrequency = Me.SecondaryFrequency
            MediaBroadcastWorksheetMarketDetail.BookSecondaryImpressions = Me.BookSecondaryImpressions
            MediaBroadcastWorksheetMarketDetail.SecondaryImpressions = Me.SecondaryImpressions
            MediaBroadcastWorksheetMarketDetail.SecondaryGrossImpressions = Me.SecondaryGrossImpressions
            MediaBroadcastWorksheetMarketDetail.SecondaryUniverse = Me.SecondaryUniverse
            MediaBroadcastWorksheetMarketDetail.SecondaryCumeImpressions = Me.SecondaryCumeImpressions
            MediaBroadcastWorksheetMarketDetail.BookSecondaryAQHRating = Me.BookSecondaryAQHRating
            MediaBroadcastWorksheetMarketDetail.SecondaryAQHRating = Me.SecondaryAQHRating
            MediaBroadcastWorksheetMarketDetail.BookSecondaryAQH = Me.BookSecondaryAQH
            MediaBroadcastWorksheetMarketDetail.SecondaryAQH = Me.SecondaryAQH
            MediaBroadcastWorksheetMarketDetail.SecondaryCumeRating = Me.SecondaryCumeRating
            MediaBroadcastWorksheetMarketDetail.SecondaryCume = Me.SecondaryCume
            MediaBroadcastWorksheetMarketDetail.SecondaryCPM = Me.SecondaryCPM
            MediaBroadcastWorksheetMarketDetail.PrimaryVendorSubmittedRating = Me.PrimaryVendorSubmittedRating
            MediaBroadcastWorksheetMarketDetail.PrimaryVendorSubmittedShare = Me.PrimaryVendorSubmittedShare
            MediaBroadcastWorksheetMarketDetail.PrimaryVendorSubmittedImpressions = Me.PrimaryVendorSubmittedImpressions
            MediaBroadcastWorksheetMarketDetail.SecondaryVendorSubmittedRating = Me.SecondaryVendorSubmittedRating
            MediaBroadcastWorksheetMarketDetail.SecondaryVendorSubmittedShare = Me.SecondaryVendorSubmittedShare
            MediaBroadcastWorksheetMarketDetail.SecondaryVendorSubmittedImpressions = Me.SecondaryVendorSubmittedImpressions
            MediaBroadcastWorksheetMarketDetail.CreatedByUserCode = Me.CreatedByUserCode
            MediaBroadcastWorksheetMarketDetail.CreatedDate = Me.CreatedDate
            MediaBroadcastWorksheetMarketDetail.ModifiedByUserCode = Me.ModifiedByUserCode
            MediaBroadcastWorksheetMarketDetail.ModifiedDate = Me.ModifiedDate
            MediaBroadcastWorksheetMarketDetail.OverridePost = Me.OverridePost
            MediaBroadcastWorksheetMarketDetail.OverridePostImpressions = Me.OverridePostImpressions
            MediaBroadcastWorksheetMarketDetail.OverridePostAQH = Me.OverridePostAQH

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
