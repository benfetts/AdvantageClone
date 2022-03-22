Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetPrintOptions

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaBroadcastWorksheetPrintOptionsID
            UserCode
            PrintLocation
            LocationCode
            PrintOnHold
            PrintLineNumber
            PrintCableNetworkStationCode
            PrintDaypart
            PrintLength
            PrintDays
            PrintStartTime
            PrintEndTime
            PrintProgram
            PrintComments
            PrintBookend
            PrintValueAdded
            PrintDefaultRate
            PrintTotalSpots
            PrintTotalDollars
            PrintPrimaryRating
            PrintPrimaryShare
            PrintPrimaryHPUT
            PrintPrimaryAQHRating
            PrintPrimaryCPP
            PrintPrimaryGRP
            PrintPrimaryAQH
            PrintPrimaryCumeRating
            PrintPrimaryCume
            PrintPrimaryReach
            PrintPrimaryGrossImpressions
            PrintSecondaryRating
            PrintSecondaryShare
            PrintSecondaryHPUT
            PrintSecondaryAQHRating
            PrintSecondaryCPP
            PrintSecondaryGRP
            PrintSecondaryAQH
            PrintSecondaryCumeRating
            PrintSecondaryCume
            PrintSecondaryReach
            PrintSecondaryGrossImpressions
            PrintPrimaryTVCume
            PrintPrimaryTVImpressions
            PrintSecondaryTVCume
            PrintSecondaryTVImpressions
            PrintPrimaryCPM
            PrintSecondaryCPM
            PrintZeroSpotLines
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetPrintOptionsID As Integer
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserCode As String
        Public Property PrintLocation As Boolean
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LocationCode As String
        Public Property PrintOnHold As Boolean
        Public Property PrintLineNumber As Boolean
        Public Property PrintCableNetworkStationCode As Boolean
        Public Property PrintDaypart As Boolean
        Public Property PrintLength As Boolean
        Public Property PrintDays As Boolean
        Public Property PrintStartTime As Boolean
        Public Property PrintEndTime As Boolean
        Public Property PrintProgram As Boolean
        Public Property PrintComments As Boolean
        Public Property PrintBookend As Boolean
        Public Property PrintValueAdded As Boolean
        Public Property PrintDefaultRate As Boolean
        Public Property PrintTotalSpots As Boolean
        Public Property PrintTotalDollars As Boolean
        Public Property PrintPrimaryRating As Boolean
        Public Property PrintPrimaryShare As Boolean
        Public Property PrintPrimaryHPUT As Boolean
        Public Property PrintPrimaryAQHRating As Boolean
        Public Property PrintPrimaryCPP As Boolean
        Public Property PrintPrimaryGRP As Boolean
        Public Property PrintPrimaryAQH As Boolean
        Public Property PrintPrimaryCumeRating As Boolean
        Public Property PrintPrimaryCume As Boolean
        Public Property PrintPrimaryReach As Boolean
        Public Property PrintPrimaryGrossImpressions As Boolean
        Public Property PrintSecondaryRating As Boolean
        Public Property PrintSecondaryShare As Boolean
        Public Property PrintSecondaryHPUT As Boolean
        Public Property PrintSecondaryAQHRating As Boolean
        Public Property PrintSecondaryCPP As Boolean
        Public Property PrintSecondaryGRP As Boolean
        Public Property PrintSecondaryAQH As Boolean
        Public Property PrintSecondaryCumeRating As Boolean
        Public Property PrintSecondaryCume As Boolean
        Public Property PrintSecondaryReach As Boolean
        Public Property PrintSecondaryGrossImpressions As Boolean
        Public Property PrintPrimaryTVCume As Boolean
        Public Property PrintPrimaryTVImpressions As Boolean
        Public Property PrintSecondaryTVCume As Boolean
        Public Property PrintSecondaryTVImpressions As Boolean
        Public Property PrintPrimaryCPM As Boolean
        Public Property PrintSecondaryCPM As Boolean
        Public Property PrintRemoveLinesWithoutSpots As Boolean

#End Region

#Region " Methods "

        Public Sub New(UserCode As String)

            Me.MediaBroadcastWorksheetPrintOptionsID = 0
            Me.UserCode = UserCode
            Me.PrintLocation = True
            Me.LocationCode = Nothing
            Me.PrintOnHold = False
            Me.PrintLineNumber = True
            Me.PrintCableNetworkStationCode = True
            Me.PrintDaypart = True
            Me.PrintLength = True
            Me.PrintDays = True
            Me.PrintStartTime = True
            Me.PrintEndTime = True
            Me.PrintProgram = True
            Me.PrintComments = True
            Me.PrintBookend = True
            Me.PrintValueAdded = True
            Me.PrintDefaultRate = True
            Me.PrintTotalSpots = True
            Me.PrintTotalDollars = True
            Me.PrintPrimaryRating = True
            Me.PrintPrimaryShare = True
            Me.PrintPrimaryHPUT = True
            Me.PrintPrimaryAQHRating = True
            Me.PrintPrimaryCPP = True
            Me.PrintPrimaryGRP = True
            Me.PrintPrimaryAQH = True
            Me.PrintPrimaryCumeRating = True
            Me.PrintPrimaryCume = True
            Me.PrintPrimaryReach = True
            Me.PrintPrimaryGrossImpressions = True
            Me.PrintPrimaryTVCume = True
            Me.PrintPrimaryTVImpressions = True
            Me.PrintSecondaryRating = False
            Me.PrintSecondaryShare = False
            Me.PrintSecondaryHPUT = False
            Me.PrintSecondaryAQHRating = False
            Me.PrintSecondaryCPP = False
            Me.PrintSecondaryGRP = False
            Me.PrintSecondaryAQH = False
            Me.PrintSecondaryCumeRating = False
            Me.PrintSecondaryCume = False
            Me.PrintSecondaryReach = False
            Me.PrintSecondaryGrossImpressions = False
            Me.PrintSecondaryTVCume = False
            Me.PrintSecondaryTVImpressions = False
            Me.PrintPrimaryCPM = False
            Me.PrintSecondaryCPM = False
            Me.PrintRemoveLinesWithoutSpots = False

        End Sub
        Public Sub New(MediaBroadcastWorksheetPrintOptions As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrintOptions)

            Me.MediaBroadcastWorksheetPrintOptionsID = MediaBroadcastWorksheetPrintOptions.MediaBroadcastWorksheetPrintOptionsID
            Me.UserCode = MediaBroadcastWorksheetPrintOptions.UserCode
            Me.PrintLocation = MediaBroadcastWorksheetPrintOptions.PrintLocation
            Me.LocationCode = MediaBroadcastWorksheetPrintOptions.LocationCode
            Me.PrintOnHold = MediaBroadcastWorksheetPrintOptions.PrintOnHold
            Me.PrintLineNumber = MediaBroadcastWorksheetPrintOptions.PrintLineNumber
            Me.PrintCableNetworkStationCode = MediaBroadcastWorksheetPrintOptions.PrintCableNetworkStationCode
            Me.PrintDaypart = MediaBroadcastWorksheetPrintOptions.PrintDaypart
            Me.PrintLength = MediaBroadcastWorksheetPrintOptions.PrintLength
            Me.PrintDays = MediaBroadcastWorksheetPrintOptions.PrintDays
            Me.PrintStartTime = MediaBroadcastWorksheetPrintOptions.PrintStartTime
            Me.PrintEndTime = MediaBroadcastWorksheetPrintOptions.PrintEndTime
            Me.PrintProgram = MediaBroadcastWorksheetPrintOptions.PrintProgram
            Me.PrintComments = MediaBroadcastWorksheetPrintOptions.PrintComments
            Me.PrintBookend = MediaBroadcastWorksheetPrintOptions.PrintBookend
            Me.PrintValueAdded = MediaBroadcastWorksheetPrintOptions.PrintValueAdded
            Me.PrintDefaultRate = MediaBroadcastWorksheetPrintOptions.PrintDefaultRate
            Me.PrintTotalSpots = MediaBroadcastWorksheetPrintOptions.PrintTotalSpots
            Me.PrintTotalDollars = MediaBroadcastWorksheetPrintOptions.PrintTotalDollars
            Me.PrintPrimaryRating = MediaBroadcastWorksheetPrintOptions.PrintPrimaryRating
            Me.PrintPrimaryShare = MediaBroadcastWorksheetPrintOptions.PrintPrimaryShare
            Me.PrintPrimaryHPUT = MediaBroadcastWorksheetPrintOptions.PrintPrimaryHPUT
            Me.PrintPrimaryAQHRating = MediaBroadcastWorksheetPrintOptions.PrintPrimaryAQHRating
            Me.PrintPrimaryCPP = MediaBroadcastWorksheetPrintOptions.PrintPrimaryCPP
            Me.PrintPrimaryGRP = MediaBroadcastWorksheetPrintOptions.PrintPrimaryGRP
            Me.PrintPrimaryAQH = MediaBroadcastWorksheetPrintOptions.PrintPrimaryAQH
            Me.PrintPrimaryCumeRating = MediaBroadcastWorksheetPrintOptions.PrintPrimaryCumeRating
            Me.PrintPrimaryCume = MediaBroadcastWorksheetPrintOptions.PrintPrimaryCume
            Me.PrintPrimaryReach = MediaBroadcastWorksheetPrintOptions.PrintPrimaryReach
            Me.PrintPrimaryGrossImpressions = MediaBroadcastWorksheetPrintOptions.PrintPrimaryGrossImpressions
            Me.PrintSecondaryRating = MediaBroadcastWorksheetPrintOptions.PrintSecondaryRating
            Me.PrintSecondaryShare = MediaBroadcastWorksheetPrintOptions.PrintSecondaryShare
            Me.PrintSecondaryHPUT = MediaBroadcastWorksheetPrintOptions.PrintSecondaryHPUT
            Me.PrintSecondaryAQHRating = MediaBroadcastWorksheetPrintOptions.PrintSecondaryAQHRating
            Me.PrintSecondaryCPP = MediaBroadcastWorksheetPrintOptions.PrintSecondaryCPP
            Me.PrintSecondaryGRP = MediaBroadcastWorksheetPrintOptions.PrintSecondaryGRP
            Me.PrintSecondaryAQH = MediaBroadcastWorksheetPrintOptions.PrintSecondaryAQH
            Me.PrintSecondaryCumeRating = MediaBroadcastWorksheetPrintOptions.PrintSecondaryCumeRating
            Me.PrintSecondaryCume = MediaBroadcastWorksheetPrintOptions.PrintSecondaryCume
            Me.PrintSecondaryReach = MediaBroadcastWorksheetPrintOptions.PrintSecondaryReach
            Me.PrintSecondaryGrossImpressions = MediaBroadcastWorksheetPrintOptions.PrintSecondaryGrossImpressions
            Me.PrintPrimaryTVCume = MediaBroadcastWorksheetPrintOptions.PrintPrimaryTVCume
            Me.PrintPrimaryTVImpressions = MediaBroadcastWorksheetPrintOptions.PrintPrimaryTVImpressions
            Me.PrintSecondaryTVCume = MediaBroadcastWorksheetPrintOptions.PrintSecondaryTVCume
            Me.PrintSecondaryTVImpressions = MediaBroadcastWorksheetPrintOptions.PrintSecondaryTVImpressions
            Me.PrintPrimaryCPM = MediaBroadcastWorksheetPrintOptions.PrintPrimaryCPM
            Me.PrintSecondaryCPM = MediaBroadcastWorksheetPrintOptions.PrintSecondaryCPM
            Me.PrintRemoveLinesWithoutSpots = MediaBroadcastWorksheetPrintOptions.PrintRemoveLinesWithoutSpots

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetPrintOptions As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrintOptions)

            MediaBroadcastWorksheetPrintOptions.UserCode = Me.UserCode
            MediaBroadcastWorksheetPrintOptions.PrintLocation = Me.PrintLocation
            MediaBroadcastWorksheetPrintOptions.LocationCode = If(String.IsNullOrWhiteSpace(Me.LocationCode), Nothing, Me.LocationCode)
            MediaBroadcastWorksheetPrintOptions.PrintOnHold = Me.PrintOnHold
            MediaBroadcastWorksheetPrintOptions.PrintLineNumber = Me.PrintLineNumber
            MediaBroadcastWorksheetPrintOptions.PrintCableNetworkStationCode = Me.PrintCableNetworkStationCode
            MediaBroadcastWorksheetPrintOptions.PrintDaypart = Me.PrintDaypart
            MediaBroadcastWorksheetPrintOptions.PrintLength = Me.PrintLength
            MediaBroadcastWorksheetPrintOptions.PrintDays = Me.PrintDays
            MediaBroadcastWorksheetPrintOptions.PrintStartTime = Me.PrintStartTime
            MediaBroadcastWorksheetPrintOptions.PrintEndTime = Me.PrintEndTime
            MediaBroadcastWorksheetPrintOptions.PrintProgram = Me.PrintProgram
            MediaBroadcastWorksheetPrintOptions.PrintComments = Me.PrintComments
            MediaBroadcastWorksheetPrintOptions.PrintBookend = Me.PrintBookend
            MediaBroadcastWorksheetPrintOptions.PrintValueAdded = Me.PrintValueAdded
            MediaBroadcastWorksheetPrintOptions.PrintDefaultRate = Me.PrintDefaultRate
            MediaBroadcastWorksheetPrintOptions.PrintTotalSpots = Me.PrintTotalSpots
            MediaBroadcastWorksheetPrintOptions.PrintTotalDollars = Me.PrintTotalDollars
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryRating = Me.PrintPrimaryRating
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryShare = Me.PrintPrimaryShare
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryHPUT = Me.PrintPrimaryHPUT
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryAQHRating = Me.PrintPrimaryAQHRating
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryCPP = Me.PrintPrimaryCPP
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryGRP = Me.PrintPrimaryGRP
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryAQH = Me.PrintPrimaryAQH
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryCumeRating = Me.PrintPrimaryCumeRating
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryCume = Me.PrintPrimaryCume
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryReach = Me.PrintPrimaryReach
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryGrossImpressions = Me.PrintPrimaryGrossImpressions
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryRating = Me.PrintSecondaryRating
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryShare = Me.PrintSecondaryShare
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryHPUT = Me.PrintSecondaryHPUT
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryAQHRating = Me.PrintSecondaryAQHRating
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryCPP = Me.PrintSecondaryCPP
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryGRP = Me.PrintSecondaryGRP
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryAQH = Me.PrintSecondaryAQH
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryCumeRating = Me.PrintSecondaryCumeRating
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryCume = Me.PrintSecondaryCume
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryReach = Me.PrintSecondaryReach
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryGrossImpressions = Me.PrintSecondaryGrossImpressions
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryTVCume = Me.PrintPrimaryTVCume
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryTVImpressions = Me.PrintPrimaryTVImpressions
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryTVCume = Me.PrintSecondaryTVCume
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryTVImpressions = Me.PrintSecondaryTVImpressions
            MediaBroadcastWorksheetPrintOptions.PrintPrimaryCPM = Me.PrintPrimaryCPM
            MediaBroadcastWorksheetPrintOptions.PrintSecondaryCPM = Me.PrintSecondaryCPM
            MediaBroadcastWorksheetPrintOptions.PrintRemoveLinesWithoutSpots = Me.PrintRemoveLinesWithoutSpots

        End Sub

#End Region

    End Class

End Namespace
