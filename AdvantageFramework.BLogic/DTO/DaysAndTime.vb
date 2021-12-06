Namespace DTO

    Public Class DaysAndTime
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum BroadcastTypes As Integer
            None = 0
            Radio = 1
            TV = 2
            National = 3
            TVPuertoRico = 4
        End Enum

        Public Enum Properties
            BroadcastType
            DayStartHour
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
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property BroadcastType As BroadcastTypes
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property DayStartHour As Integer
            Get

                If Me.BroadcastType = BroadcastTypes.Radio Then

                    DayStartHour = 500

                ElseIf Me.BroadcastType = BroadcastTypes.National Then

                    DayStartHour = 600

                ElseIf Me.BroadcastType = BroadcastTypes.TV Then

                    DayStartHour = 300

                Else 'If Me.BroadcastType = BroadcastTypes.TVPuertoRico Then

                    DayStartHour = 200

                End If

            End Get
        End Property
        <Required(AllowEmptyStrings:=True)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Days() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Sunday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Monday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Tuesday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Wednesday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Thursday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Friday() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Saturday() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartTime() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndTime() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsUsing3rdPartyData() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaSpotTVResearchDayTimeID As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()

            Me.BroadcastType = BroadcastTypes.None

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

            Me.IsUsing3rdPartyData = False

        End Sub
        Public Sub New(BroadcastType As BroadcastTypes)

            Me.BroadcastType = BroadcastType

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

            Me.IsUsing3rdPartyData = False

        End Sub
        Public Sub New(BroadcastType As BroadcastTypes, WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket, WorksheetMarketDetail As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail)

            Me.BroadcastType = BroadcastType

            Me.Days = WorksheetMarketDetail.Days

            Me.Sunday = WorksheetMarketDetail.Sunday
            Me.Monday = WorksheetMarketDetail.Monday
            Me.Tuesday = WorksheetMarketDetail.Tuesday
            Me.Wednesday = WorksheetMarketDetail.Wednesday
            Me.Thursday = WorksheetMarketDetail.Thursday
            Me.Friday = WorksheetMarketDetail.Friday
            Me.Saturday = WorksheetMarketDetail.Saturday

            Me.StartTime = WorksheetMarketDetail.StartTime
            Me.EndTime = WorksheetMarketDetail.EndTime

            If Me.BroadcastType = BroadcastTypes.TV Then

                Me.IsUsing3rdPartyData = WorksheetMarket.SharebookNielsenTVBookID.HasValue

            ElseIf Me.BroadcastType = BroadcastTypes.Radio Then

                Me.IsUsing3rdPartyData = WorksheetMarket.NeilsenRadioPeriodID1.HasValue

            ElseIf Me.BroadcastType = BroadcastTypes.TVPuertoRico Then

                Me.IsUsing3rdPartyData = True

            Else

                Me.IsUsing3rdPartyData = False

            End If

        End Sub
        Public Sub New(BroadcastType As BroadcastTypes, MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket, MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail)

            Me.BroadcastType = BroadcastType

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

            If Me.BroadcastType = BroadcastTypes.TV Then

                Me.IsUsing3rdPartyData = MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue

            ElseIf Me.BroadcastType = BroadcastTypes.Radio Then

                Me.IsUsing3rdPartyData = MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1.HasValue

            ElseIf Me.BroadcastType = BroadcastTypes.TVPuertoRico Then

                Me.IsUsing3rdPartyData = True

            Else

                Me.IsUsing3rdPartyData = False

            End If

        End Sub
        Public Sub New(BroadcastType As BroadcastTypes, MediaSpotTVResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVResearchDayTime)

            Me.BroadcastType = BroadcastType

            Me.Days = MediaSpotTVResearchDayTime.Days
            Me.Sunday = MediaSpotTVResearchDayTime.Sunday
            Me.Monday = MediaSpotTVResearchDayTime.Monday
            Me.Tuesday = MediaSpotTVResearchDayTime.Tuesday
            Me.Wednesday = MediaSpotTVResearchDayTime.Wednesday
            Me.Thursday = MediaSpotTVResearchDayTime.Thursday
            Me.Friday = MediaSpotTVResearchDayTime.Friday
            Me.Saturday = MediaSpotTVResearchDayTime.Saturday
            Me.StartTime = MediaSpotTVResearchDayTime.StartTime
            Me.EndTime = MediaSpotTVResearchDayTime.EndTime

            Me.IsUsing3rdPartyData = True
            Me.MediaSpotTVResearchDayTimeID = MediaSpotTVResearchDayTime.ID

        End Sub
        Public Sub New(BroadcastType As BroadcastTypes, MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch)

            Me.BroadcastType = BroadcastType

            Me.Days = MediaSpotNationalResearch.Days
            Me.Sunday = MediaSpotNationalResearch.Sunday
            Me.Monday = MediaSpotNationalResearch.Monday
            Me.Tuesday = MediaSpotNationalResearch.Tuesday
            Me.Wednesday = MediaSpotNationalResearch.Wednesday
            Me.Thursday = MediaSpotNationalResearch.Thursday
            Me.Friday = MediaSpotNationalResearch.Friday
            Me.Saturday = MediaSpotNationalResearch.Saturday
            Me.StartTime = MediaSpotNationalResearch.StartTime
            Me.EndTime = MediaSpotNationalResearch.EndTime

            Me.IsUsing3rdPartyData = True

        End Sub
        Public Sub New(BroadcastType As BroadcastTypes, MediaSpotTVPuertoRicoResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchDayTime)

            Me.BroadcastType = BroadcastType

            Me.Days = MediaSpotTVPuertoRicoResearchDayTime.Days
            Me.Sunday = MediaSpotTVPuertoRicoResearchDayTime.Sunday
            Me.Monday = MediaSpotTVPuertoRicoResearchDayTime.Monday
            Me.Tuesday = MediaSpotTVPuertoRicoResearchDayTime.Tuesday
            Me.Wednesday = MediaSpotTVPuertoRicoResearchDayTime.Wednesday
            Me.Thursday = MediaSpotTVPuertoRicoResearchDayTime.Thursday
            Me.Friday = MediaSpotTVPuertoRicoResearchDayTime.Friday
            Me.Saturday = MediaSpotTVPuertoRicoResearchDayTime.Saturday
            Me.StartTime = MediaSpotTVPuertoRicoResearchDayTime.StartTime
            Me.EndTime = MediaSpotTVPuertoRicoResearchDayTime.EndTime

            Me.IsUsing3rdPartyData = True
            Me.MediaSpotTVResearchDayTimeID = MediaSpotTVPuertoRicoResearchDayTime.ID

        End Sub
        Public Sub SaveToEntity(ByRef WorksheetMarketDetail As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail)

            'objects
            Dim NewStartTime As Date = Date.MinValue

            WorksheetMarketDetail.Days = Me.Days
            WorksheetMarketDetail.Sunday = Me.Sunday
            WorksheetMarketDetail.Monday = Me.Monday
            WorksheetMarketDetail.Tuesday = Me.Tuesday
            WorksheetMarketDetail.Wednesday = Me.Wednesday
            WorksheetMarketDetail.Thursday = Me.Thursday
            WorksheetMarketDetail.Friday = Me.Friday
            WorksheetMarketDetail.Saturday = Me.Saturday

            If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

                WorksheetMarketDetail.StartTime = Me.StartTime

            Else

                WorksheetMarketDetail.StartTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

                WorksheetMarketDetail.EndTime = Me.EndTime

            Else

                WorksheetMarketDetail.EndTime = String.Empty

            End If

            If Me.BroadcastType = BroadcastTypes.Radio Then

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) < Me.DayStartHour Then

                    WorksheetMarketDetail.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) + 2400

                Else

                    WorksheetMarketDetail.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime))

                End If

            Else 'only adjust start hour to preceding quarter hour if not radio

                If Not String.IsNullOrWhiteSpace(WorksheetMarketDetail.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime, NewStartTime) Then

                    If DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) Mod 15 = 0 Then

                        If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) < Me.DayStartHour Then

                            WorksheetMarketDetail.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) + 2400

                        Else

                            WorksheetMarketDetail.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime))

                        End If

                    Else

                        NewStartTime = DateAdd(DateInterval.Minute, -(DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime)) Mod 15), CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.StartTime))

                        If DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) < Me.DayStartHour Then

                            WorksheetMarketDetail.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) + 2400

                        Else

                            WorksheetMarketDetail.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime)

                        End If

                    End If

                End If

            End If

            If Not String.IsNullOrWhiteSpace(WorksheetMarketDetail.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & WorksheetMarketDetail.EndTime, NewStartTime) Then

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.EndTime)) < Me.DayStartHour Then

                    WorksheetMarketDetail.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.EndTime)) + 2400

                Else

                    WorksheetMarketDetail.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & WorksheetMarketDetail.EndTime))

                End If

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail)

            'objects
            Dim NewStartTime As Date = Date.MinValue

            MediaBroadcastWorksheetMarketDetail.Days = Me.Days
            MediaBroadcastWorksheetMarketDetail.Sunday = Me.Sunday
            MediaBroadcastWorksheetMarketDetail.Monday = Me.Monday
            MediaBroadcastWorksheetMarketDetail.Tuesday = Me.Tuesday
            MediaBroadcastWorksheetMarketDetail.Wednesday = Me.Wednesday
            MediaBroadcastWorksheetMarketDetail.Thursday = Me.Thursday
            MediaBroadcastWorksheetMarketDetail.Friday = Me.Friday
            MediaBroadcastWorksheetMarketDetail.Saturday = Me.Saturday

            If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

                MediaBroadcastWorksheetMarketDetail.StartTime = Me.StartTime

            Else

                MediaBroadcastWorksheetMarketDetail.StartTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

                MediaBroadcastWorksheetMarketDetail.EndTime = Me.EndTime

            Else

                MediaBroadcastWorksheetMarketDetail.EndTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarketDetail.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.StartTime, NewStartTime) Then

                If DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.StartTime)) Mod 15 = 0 Then

                    If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.StartTime)) < Me.DayStartHour Then

                        MediaBroadcastWorksheetMarketDetail.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.StartTime)) + 2400

                    Else

                        MediaBroadcastWorksheetMarketDetail.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.StartTime))

                    End If

                Else

                    NewStartTime = DateAdd(DateInterval.Minute, -(DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.StartTime)) Mod 15), CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.StartTime))

                    If DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) < Me.DayStartHour Then

                        MediaBroadcastWorksheetMarketDetail.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) + 2400

                    Else

                        MediaBroadcastWorksheetMarketDetail.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime)

                    End If

                End If

            End If

            If Not String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarketDetail.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.EndTime, NewStartTime) Then

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.EndTime)) < Me.DayStartHour Then

                    MediaBroadcastWorksheetMarketDetail.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.EndTime)) + 2400

                Else

                    MediaBroadcastWorksheetMarketDetail.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketDetail.EndTime))

                End If

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotTVResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVResearchDayTime)

            'objects
            Dim NewStartTime As Date = Date.MinValue

            MediaSpotTVResearchDayTime.Days = Me.Days
            MediaSpotTVResearchDayTime.Sunday = Me.Sunday
            MediaSpotTVResearchDayTime.Monday = Me.Monday
            MediaSpotTVResearchDayTime.Tuesday = Me.Tuesday
            MediaSpotTVResearchDayTime.Wednesday = Me.Wednesday
            MediaSpotTVResearchDayTime.Thursday = Me.Thursday
            MediaSpotTVResearchDayTime.Friday = Me.Friday
            MediaSpotTVResearchDayTime.Saturday = Me.Saturday

            If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

                MediaSpotTVResearchDayTime.StartTime = Me.StartTime

            Else

                MediaSpotTVResearchDayTime.StartTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

                MediaSpotTVResearchDayTime.EndTime = Me.EndTime

            Else

                MediaSpotTVResearchDayTime.EndTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(MediaSpotTVResearchDayTime.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.StartTime, NewStartTime) Then

                If DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.StartTime)) Mod 15 = 0 Then

                    If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.StartTime)) < Me.DayStartHour Then

                        MediaSpotTVResearchDayTime.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.StartTime)) + 2400

                    Else

                        MediaSpotTVResearchDayTime.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.StartTime))

                    End If

                Else

                    NewStartTime = DateAdd(DateInterval.Minute, -(DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.StartTime)) Mod 15), CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.StartTime))

                    If DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) < Me.DayStartHour Then

                        MediaSpotTVResearchDayTime.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) + 2400

                    Else

                        MediaSpotTVResearchDayTime.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime)

                    End If

                End If

            End If

            If Not String.IsNullOrWhiteSpace(MediaSpotTVResearchDayTime.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.EndTime, NewStartTime) Then

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.EndTime)) < Me.DayStartHour Then

                    MediaSpotTVResearchDayTime.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.EndTime)) + 2400

                Else

                    MediaSpotTVResearchDayTime.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVResearchDayTime.EndTime))

                End If

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail)

            'objects
            Dim NewStartTime As Date = Date.MinValue

            MediaBroadcastWorksheetMarketStagingDetail.Days = Me.Days
            MediaBroadcastWorksheetMarketStagingDetail.Sunday = Me.Sunday
            MediaBroadcastWorksheetMarketStagingDetail.Monday = Me.Monday
            MediaBroadcastWorksheetMarketStagingDetail.Tuesday = Me.Tuesday
            MediaBroadcastWorksheetMarketStagingDetail.Wednesday = Me.Wednesday
            MediaBroadcastWorksheetMarketStagingDetail.Thursday = Me.Thursday
            MediaBroadcastWorksheetMarketStagingDetail.Friday = Me.Friday
            MediaBroadcastWorksheetMarketStagingDetail.Saturday = Me.Saturday

            If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

                MediaBroadcastWorksheetMarketStagingDetail.StartTime = Me.StartTime

            Else

                MediaBroadcastWorksheetMarketStagingDetail.StartTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

                MediaBroadcastWorksheetMarketStagingDetail.EndTime = Me.EndTime

            Else

                MediaBroadcastWorksheetMarketStagingDetail.EndTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarketStagingDetail.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.StartTime, NewStartTime) Then

                If DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.StartTime)) Mod 15 = 0 Then

                    If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.StartTime)) < Me.DayStartHour Then

                        MediaBroadcastWorksheetMarketStagingDetail.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.StartTime)) + 2400

                    Else

                        MediaBroadcastWorksheetMarketStagingDetail.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.StartTime))

                    End If

                Else

                    NewStartTime = DateAdd(DateInterval.Minute, -(DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.StartTime)) Mod 15), CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.StartTime))

                    If DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) < Me.DayStartHour Then

                        MediaBroadcastWorksheetMarketStagingDetail.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) + 2400

                    Else

                        MediaBroadcastWorksheetMarketStagingDetail.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime)

                    End If

                End If

            End If

            If Not String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarketStagingDetail.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.EndTime, NewStartTime) Then

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.EndTime)) < Me.DayStartHour Then

                    MediaBroadcastWorksheetMarketStagingDetail.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.EndTime)) + 2400

                Else

                    MediaBroadcastWorksheetMarketStagingDetail.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaBroadcastWorksheetMarketStagingDetail.EndTime))

                End If

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch)

            'objects
            Dim NewStartTime As Date = Date.MinValue

            MediaSpotNationalResearch.Days = Me.Days
            MediaSpotNationalResearch.Sunday = Me.Sunday
            MediaSpotNationalResearch.Monday = Me.Monday
            MediaSpotNationalResearch.Tuesday = Me.Tuesday
            MediaSpotNationalResearch.Wednesday = Me.Wednesday
            MediaSpotNationalResearch.Thursday = Me.Thursday
            MediaSpotNationalResearch.Friday = Me.Friday
            MediaSpotNationalResearch.Saturday = Me.Saturday

            If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

                MediaSpotNationalResearch.StartTime = Me.StartTime

            Else

                MediaSpotNationalResearch.StartTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

                MediaSpotNationalResearch.EndTime = Me.EndTime

            Else

                MediaSpotNationalResearch.EndTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(MediaSpotNationalResearch.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & MediaSpotNationalResearch.StartTime, NewStartTime) Then

                If DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.StartTime)) Mod 15 = 0 Then

                    If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.StartTime)) < Me.DayStartHour Then

                        MediaSpotNationalResearch.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.StartTime)) + 2400

                    Else

                        MediaSpotNationalResearch.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.StartTime))

                    End If

                Else

                    NewStartTime = CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.StartTime)

                    If DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) < Me.DayStartHour Then

                        MediaSpotNationalResearch.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) + 2400

                    Else

                        MediaSpotNationalResearch.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime)

                    End If

                End If

            End If

            If Not String.IsNullOrWhiteSpace(MediaSpotNationalResearch.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & MediaSpotNationalResearch.EndTime, NewStartTime) Then

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.EndTime)) < Me.DayStartHour Then

                    MediaSpotNationalResearch.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.EndTime)) + 2400

                Else

                    MediaSpotNationalResearch.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotNationalResearch.EndTime))

                End If

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotTVPuertoRicoResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchDayTime)

            'objects
            Dim NewStartTime As Date = Date.MinValue

            MediaSpotTVPuertoRicoResearchDayTime.Days = Me.Days
            MediaSpotTVPuertoRicoResearchDayTime.Sunday = Me.Sunday
            MediaSpotTVPuertoRicoResearchDayTime.Monday = Me.Monday
            MediaSpotTVPuertoRicoResearchDayTime.Tuesday = Me.Tuesday
            MediaSpotTVPuertoRicoResearchDayTime.Wednesday = Me.Wednesday
            MediaSpotTVPuertoRicoResearchDayTime.Thursday = Me.Thursday
            MediaSpotTVPuertoRicoResearchDayTime.Friday = Me.Friday
            MediaSpotTVPuertoRicoResearchDayTime.Saturday = Me.Saturday

            If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

                MediaSpotTVPuertoRicoResearchDayTime.StartTime = Me.StartTime

            Else

                MediaSpotTVPuertoRicoResearchDayTime.StartTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

                MediaSpotTVPuertoRicoResearchDayTime.EndTime = Me.EndTime

            Else

                MediaSpotTVPuertoRicoResearchDayTime.EndTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(MediaSpotTVPuertoRicoResearchDayTime.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.StartTime, NewStartTime) Then

                If DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.StartTime)) Mod 15 = 0 Then

                    If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.StartTime)) < Me.DayStartHour Then

                        MediaSpotTVPuertoRicoResearchDayTime.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.StartTime)) + 2400

                    Else

                        MediaSpotTVPuertoRicoResearchDayTime.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.StartTime))

                    End If

                Else

                    NewStartTime = DateAdd(DateInterval.Minute, -(DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.StartTime)) Mod 15), CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.StartTime))

                    If DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) < Me.DayStartHour Then

                        MediaSpotTVPuertoRicoResearchDayTime.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) + 2400

                    Else

                        MediaSpotTVPuertoRicoResearchDayTime.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime)

                    End If

                End If

            End If

            If Not String.IsNullOrWhiteSpace(MediaSpotTVPuertoRicoResearchDayTime.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.EndTime, NewStartTime) Then

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.EndTime)) < Me.DayStartHour Then

                    MediaSpotTVPuertoRicoResearchDayTime.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.EndTime)) + 2400

                Else

                    MediaSpotTVPuertoRicoResearchDayTime.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & MediaSpotTVPuertoRicoResearchDayTime.EndTime))

                End If

            End If

        End Sub
        Public Function Clone() As DaysAndTime

            'objects
            Dim NewDaysAndTime As DaysAndTime = Nothing

            NewDaysAndTime = New DaysAndTime

            NewDaysAndTime.BroadcastType = Me.BroadcastType
            NewDaysAndTime.Days = Me.Days
            NewDaysAndTime.Sunday = Me.Sunday
            NewDaysAndTime.Monday = Me.Monday
            NewDaysAndTime.Tuesday = Me.Tuesday
            NewDaysAndTime.Wednesday = Me.Wednesday
            NewDaysAndTime.Thursday = Me.Thursday
            NewDaysAndTime.Friday = Me.Friday
            NewDaysAndTime.Saturday = Me.Saturday
            NewDaysAndTime.StartTime = Me.StartTime
            NewDaysAndTime.EndTime = Me.EndTime

            Clone = NewDaysAndTime

        End Function

#End Region

    End Class

End Namespace
