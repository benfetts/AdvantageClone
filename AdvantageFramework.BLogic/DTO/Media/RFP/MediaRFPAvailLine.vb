Namespace DTO.Media.RFP

    Public Class MediaRFPAvailLine
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Status
            BatchNumber
            VendorName
            NetworkName
            CableNetworkStationCode
            ComscoreTVStationCallLetters
            CallLetters
            AvailName
            StartDate
            EndDate
            DaypartID
            DaypartName
            SpotLength
            Days
            StartTime
            EndTime
            Program
            Rate
            Spots
            MediaDemoID
            Rating
            Impressions
            Comments
            StartHour
            EndHour
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.MediaRFPAvailLineStatus)>
        Public Property Status As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Batch")>
        Public Property BatchNumber As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property VendorName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property NetworkName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.CableNetworkStation, CustomColumnCaption:="Cable Network")>
        Public Property CableNetworkStationCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.CableNetworkStation, CustomColumnCaption:="Cable Network")>
        Public Property ComscoreTVStationCallLetters() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property CallLetters As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property AvailName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartDate As Date?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndDate As Date?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Daypart from File")>
        Public Property DaypartName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.Methods.PropertyTypes.DaypartID, CustomColumnCaption:="Daypart", IsAutoFillProperty:=True)>
        Public Property DaypartID As Integer?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property SpotLength As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Days As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
        Public Property StartTime As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
        Public Property EndTime As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Program As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2")>
        Public Property Rate As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(UseMinValue:=True, MinValue:=0)>
        Public Property Spots As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public ReadOnly Property OnWorksheet As Boolean
            Get
                OnWorksheet = Me.MediaBroadcastWorksheetMarketDetailID.HasValue
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.MediaDemographic, CustomColumnCaption:="Demographic")>
        Public Property MediaDemoID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True, DisplayFormat:="n2")>
        Public Property Rating As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True, DisplayFormat:="n0", CustomColumnCaption:="Imps (000)")>
        Public Property Impressions As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property CPP As Decimal
            Get
                If Me.Rating = 0 Then
                    CPP = 0
                Else
                    CPP = Math.Round(Me.Rate, 2) / Math.Round(Me.Rating, 2)
                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property CPM As Decimal
            Get
                If Math.Round(Me.Impressions, 0) = 0 Then
                    CPM = 0
                Else
                    CPM = Math.Round(Me.Rate, 2) / (Math.Round(Me.Impressions, 0) / 1000)
                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Comments As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketDetailID As Integer?
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Modified As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTypeCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Sunday As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Monday As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Tuesday As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Wednesday As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Thursday As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Friday As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Saturday As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property StartHour As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EndHour As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasMultipleRatings As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasMultipleLineSpots As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasMultipleImpressions As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasMultipleLineRates As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CableNetworkNielsenTVStationCode() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetStartDate As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetEndDate As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property HasDateOutsideOfWorksheet As Boolean
            Get
                If Me.StartDate.HasValue AndAlso Me.StartDate.Value < Me.MediaBroadcastWorksheetStartDate Then
                    HasDateOutsideOfWorksheet = True
                ElseIf Me.EndDate.HasValue AndAlso Me.EndDate.Value > Me.MediaBroadcastWorksheetEndDate Then
                    HasDateOutsideOfWorksheet = True
                Else
                    HasDateOutsideOfWorksheet = False
                End If
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasDetailDatesBeforeStartDate As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasDetailDatesAfterEndDate As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsWeeklyWorksheet As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsComscore As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsCableSystem As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsCanadianWorksheet As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasDemosFromImportFile As Boolean

#End Region

#Region " Methods "

        Private Sub SetDays(DayString As String)

            Dim Day As String = String.Empty
            Dim RangeStarted As Boolean = False
            Dim RangeComplete As Boolean = False

            For i As Integer = 1 To 7

                If Mid(DayString, i, 1) = "1" Then

                    Select Case i

                        Case System.DayOfWeek.Monday
                            Day = "M"

                        Case System.DayOfWeek.Tuesday
                            Day = "Tu"

                        Case System.DayOfWeek.Wednesday
                            Day = "W"

                        Case System.DayOfWeek.Thursday
                            Day = "Th"

                        Case System.DayOfWeek.Friday
                            Day = "F"

                        Case System.DayOfWeek.Saturday
                            Day = "Sa"

                        Case System.DayOfWeek.Sunday + 7
                            Day = "Su"

                    End Select

                    If Not RangeStarted Then

                        If Me.Days IsNot Nothing Then

                            Me.Days += Day

                        Else

                            Me.Days = Day

                        End If

                    ElseIf Not Me.Days.EndsWith("-") Then

                        If Not RangeComplete Then

                            Me.Days += "-"

                            If i = 7 Then

                                Me.Days += "Su"

                            End If

                        Else

                            Me.Days += "," & Day

                        End If

                    ElseIf i = 7 Then

                        Me.Days += "Su"

                    End If

                    RangeStarted = True

                Else

                    If RangeStarted AndAlso Me.Days.EndsWith("-") Then

                        Select Case i - 1

                            Case System.DayOfWeek.Monday
                                Me.Days += "M"

                            Case System.DayOfWeek.Tuesday
                                Me.Days += "Tu"

                            Case System.DayOfWeek.Wednesday
                                Me.Days += "W"

                            Case System.DayOfWeek.Thursday
                                Me.Days += "Th"

                            Case System.DayOfWeek.Friday
                                Me.Days += "F"

                            Case System.DayOfWeek.Saturday
                                Me.Days += "Sa"

                            Case System.DayOfWeek.Sunday + 7
                                Me.Days += "Su"

                        End Select

                        RangeComplete = True

                    Else

                        If Me.Days IsNot Nothing AndAlso Me.Days.EndsWith(",") = False Then

                            Me.Days += ","

                        End If

                        RangeStarted = False

                    End If

                End If

            Next

            If String.IsNullOrWhiteSpace(Me.Days) = False AndAlso Me.Days.EndsWith("-") Then

                Me.Days = Replace(Me.Days, "-", "")

            ElseIf String.IsNullOrWhiteSpace(Me.Days) = False AndAlso Me.Days.EndsWith(",") Then

                Me.Days = Replace(Me.Days, ",", "")

            End If

        End Sub
        Public Sub New()



        End Sub
        Public Sub New(VendorName As String, MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine, IsComscore As Boolean)

            'objects
            Dim DayString As String = String.Empty
            Dim RangeStarted As Boolean = False

            Me.MediaBroadcastWorksheetMarketID = MediaRFPAvailLine.MediaRFPHeader.MediaBroadcastWorksheetMarketID

            Me.ID = MediaRFPAvailLine.ID
            Me.VendorCode = MediaRFPAvailLine.MediaRFPHeader.VendorCode
            Me.VendorName = VendorName
            Me.NetworkName = MediaRFPAvailLine.NetworkName
            Me.CableNetworkStationCode = MediaRFPAvailLine.CableNetworkStationCode
            Me.CableNetworkNielsenTVStationCode = MediaRFPAvailLine.CableNetworkNielsenTVStationCode
            Me.ComscoreTVStationCallLetters = MediaRFPAvailLine.ComscoreTVStationCallLetters
            Me.CallLetters = MediaRFPAvailLine.CallLetters
            Me.AvailName = MediaRFPAvailLine.AvailName
            Me.Status = MediaRFPAvailLine.Status
            Me.StartDate = MediaRFPAvailLine.StartDate
            Me.EndDate = MediaRFPAvailLine.EndDate
            Me.DaypartID = MediaRFPAvailLine.DaypartID
            Me.DaypartName = MediaRFPAvailLine.DaypartName
            Me.SpotLength = MediaRFPAvailLine.SpotLength

            Me.StartTime = MediaRFPAvailLine.StartTime
            Me.EndTime = MediaRFPAvailLine.EndTime
            Me.Program = MediaRFPAvailLine.Program

            Me.BatchNumber = MediaRFPAvailLine.BatchNumber

            Me.MediaBroadcastWorksheetMarketDetailID = MediaRFPAvailLine.MediaBroadcastWorksheetMarketDetailID
            Me.Modified = False

            Me.Sunday = MediaRFPAvailLine.Sunday
            Me.Monday = MediaRFPAvailLine.Monday
            Me.Tuesday = MediaRFPAvailLine.Tuesday
            Me.Wednesday = MediaRFPAvailLine.Wednesday
            Me.Thursday = MediaRFPAvailLine.Thursday
            Me.Friday = MediaRFPAvailLine.Friday
            Me.Saturday = MediaRFPAvailLine.Saturday
            Me.StartHour = MediaRFPAvailLine.StartHour
            Me.EndHour = MediaRFPAvailLine.EndHour

            Me.Comments = MediaRFPAvailLine.Comments

            Me.MediaTypeCode = MediaRFPAvailLine.MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode
            Me.MediaBroadcastWorksheetStartDate = MediaRFPAvailLine.MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.StartDate
            Me.MediaBroadcastWorksheetEndDate = MediaRFPAvailLine.MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.EndDate

            Me.IsWeeklyWorksheet = (MediaRFPAvailLine.MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaBroadcastWorksheetDateTypeID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.DateTypes.Weekly)
            Me.IsComscore = IsComscore

            If MediaRFPAvailLine.MediaRFPDemos IsNot Nothing AndAlso MediaRFPAvailLine.MediaRFPDemos.Count > 0 Then

                Me.MediaDemoID = MediaRFPAvailLine.MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographicID

                If MediaRFPAvailLine.MediaRFPDemos.Where(Function(D) D.Type IsNot Nothing AndAlso D.Type.ToUpper.StartsWith("RATING")).Count > 0 Then

                    Me.Rating = MediaRFPAvailLine.MediaRFPDemos.Where(Function(D) D.Type.ToUpper.StartsWith("RATING")).First.Value
                    Me.HasMultipleRatings = If(MediaRFPAvailLine.MediaRFPDemos.Where(Function(D) D.Type.ToUpper.StartsWith("RATING") AndAlso
                                                                                                 D.MediaDemoID.GetValueOrDefault(0) = Me.MediaDemoID.GetValueOrDefault(0)).Select(Function(D) D.Value).Distinct.Count > 1, True, False)

                End If

                If MediaRFPAvailLine.MediaRFPDemos.Where(Function(D) D.Type IsNot Nothing AndAlso D.Type.ToUpper.StartsWith("IMPRESSION")).Count > 0 Then

                    Me.Impressions = MediaRFPAvailLine.MediaRFPDemos.Where(Function(D) D.Type.ToUpper.StartsWith("IMPRESSION")).First.Value
                    Me.HasMultipleImpressions = If(MediaRFPAvailLine.MediaRFPDemos.Where(Function(D) D.Type.ToUpper.StartsWith("IMPRESSION") AndAlso
                                                                                                     D.MediaDemoID.GetValueOrDefault(0) = Me.MediaDemoID.GetValueOrDefault(0)).Select(Function(D) D.Value).Distinct.Count > 1, True, False)

                End If

            End If

            If MediaRFPAvailLine.MediaRFPAvailLineSpots IsNot Nothing AndAlso MediaRFPAvailLine.MediaRFPAvailLineSpots.Count > 0 Then

                Me.Spots = MediaRFPAvailLine.MediaRFPAvailLineSpots.First.Quantity
                Me.HasMultipleLineSpots = If(MediaRFPAvailLine.MediaRFPAvailLineSpots.Select(Function(D) D.Quantity).Distinct.Count > 1, True, False)

                Me.Rate = MediaRFPAvailLine.MediaRFPAvailLineSpots.First.Rate
                Me.HasMultipleLineRates = If(MediaRFPAvailLine.MediaRFPAvailLineSpots.Select(Function(D) D.Rate).Distinct.Count > 1, True, False)

            End If

            DayString = If(MediaRFPAvailLine.Monday, "1", "0") & If(MediaRFPAvailLine.Tuesday, "1", "0") & If(MediaRFPAvailLine.Wednesday, "1", "0") & If(MediaRFPAvailLine.Thursday, "1", "0") & If(MediaRFPAvailLine.Friday, "1", "0") & If(MediaRFPAvailLine.Saturday, "1", "0") & If(MediaRFPAvailLine.Sunday, "1", "0")

            Me.IsCableSystem = MediaRFPAvailLine.MediaRFPHeader.Vendor.IsCableSystem
            Me.IsCanadianWorksheet = MediaRFPAvailLine.MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.CountryID = AdvantageFramework.DTO.Countries.Canada
            'Me.StationID = MediaRFPAvailLine.StationID

            SetDays(DayString)

        End Sub
        Public Sub SaveToEntity(ByRef MediaRFPAvailLine As AdvantageFramework.Database.Entities.MediaRFPAvailLine)

            MediaRFPAvailLine.DaypartID = Me.DaypartID
            MediaRFPAvailLine.Status = Me.Status
            MediaRFPAvailLine.StartDate = Me.StartDate
            MediaRFPAvailLine.EndDate = Me.EndDate
            MediaRFPAvailLine.ComscoreTVStationCallLetters = Me.ComscoreTVStationCallLetters

        End Sub

#End Region

    End Class

End Namespace
