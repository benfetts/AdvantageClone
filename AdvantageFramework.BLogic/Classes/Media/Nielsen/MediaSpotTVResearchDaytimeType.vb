Namespace Classes.Media.Nielsen

	Public Class MediaSpotTVResearchDaytimeType

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
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
            ExactSpotDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer
		Public Property Monday As Boolean
		Public Property Tuesday As Boolean
		Public Property Wednesday As Boolean
		Public Property Thursday As Boolean
		Public Property Friday As Boolean
		Public Property Saturday As Boolean
		Public Property Sunday As Boolean
		Public Property StartTime As String
		Public Property EndTime As String
		Public Property StartHour As Short
		Public Property EndHour As Short
		Public Property Days As String
        Public Property ExactSpotDate As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Sub New()


		End Sub
		Public Sub New(WorksheetMarketDetail As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetail)

			Me.ID = WorksheetMarketDetail.ID

			Me.Monday = WorksheetMarketDetail.Monday
			Me.Tuesday = WorksheetMarketDetail.Tuesday
			Me.Wednesday = WorksheetMarketDetail.Wednesday
			Me.Thursday = WorksheetMarketDetail.Thursday
			Me.Friday = WorksheetMarketDetail.Friday
			Me.Saturday = WorksheetMarketDetail.Saturday
			Me.Sunday = WorksheetMarketDetail.Sunday

			Me.StartTime = WorksheetMarketDetail.StartTime
			Me.EndTime = WorksheetMarketDetail.EndTime

			Me.StartHour = WorksheetMarketDetail.StartHour
			Me.EndHour = WorksheetMarketDetail.EndHour

			Me.Days = WorksheetMarketDetail.Days

		End Sub
		Public Sub New(MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail)

			Me.ID = MediaBroadcastWorksheetMarketDetail.ID

			Me.Monday = MediaBroadcastWorksheetMarketDetail.Monday
			Me.Tuesday = MediaBroadcastWorksheetMarketDetail.Tuesday
			Me.Wednesday = MediaBroadcastWorksheetMarketDetail.Wednesday
			Me.Thursday = MediaBroadcastWorksheetMarketDetail.Thursday
			Me.Friday = MediaBroadcastWorksheetMarketDetail.Friday
			Me.Saturday = MediaBroadcastWorksheetMarketDetail.Saturday
			Me.Sunday = MediaBroadcastWorksheetMarketDetail.Sunday

			Me.StartTime = MediaBroadcastWorksheetMarketDetail.StartTime
			Me.EndTime = MediaBroadcastWorksheetMarketDetail.EndTime

			Me.StartHour = MediaBroadcastWorksheetMarketDetail.StartHour
			Me.EndHour = MediaBroadcastWorksheetMarketDetail.EndHour

			Me.Days = MediaBroadcastWorksheetMarketDetail.Days

		End Sub
        Public Sub New(MediaSpotTVResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVResearchDayTime)

            Me.ID = MediaSpotTVResearchDayTime.ID

            Me.Monday = MediaSpotTVResearchDayTime.Monday
            Me.Tuesday = MediaSpotTVResearchDayTime.Tuesday
            Me.Wednesday = MediaSpotTVResearchDayTime.Wednesday
            Me.Thursday = MediaSpotTVResearchDayTime.Thursday
            Me.Friday = MediaSpotTVResearchDayTime.Friday
            Me.Saturday = MediaSpotTVResearchDayTime.Saturday
            Me.Sunday = MediaSpotTVResearchDayTime.Sunday

            Me.StartTime = MediaSpotTVResearchDayTime.StartTime
            Me.EndTime = MediaSpotTVResearchDayTime.EndTime

            Me.StartHour = MediaSpotTVResearchDayTime.StartHour
            Me.EndHour = MediaSpotTVResearchDayTime.EndHour

            Me.Days = MediaSpotTVResearchDayTime.Days

        End Sub
        Public Sub New(AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail)

            'objects
            Dim NewStart As Date = Nothing
            Dim NewEnd As Date = Nothing
            Dim NewStartTime As Date = Date.MinValue
            Dim DayStartHour As Integer = 300

            Me.ID = AccountPayableTVBroadcastDetail.ID

            Me.ExactSpotDate = AccountPayableTVBroadcastDetail.RunDate + AccountPayableTVBroadcastDetail.TimeOfDay

            Select Case AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0)

                Case 1

                    Me.Monday = True
                    Me.Days = "M"

                Case 2

                    Me.Tuesday = True
                    Me.Days = "Tu"

                Case 3

                    Me.Wednesday = True
                    Me.Days = "W"

                Case 4

                    Me.Thursday = True
                    Me.Days = "Th"

                Case 5

                    Me.Friday = True
                    Me.Days = "F"

                Case 6

                    Me.Saturday = True
                    Me.Days = "Sa"

                Case 7

                    Me.Sunday = True
                    Me.Days = "Su"

            End Select

            'this if block performs break-averaging
            If (Me.ExactSpotDate.Value.Hour = 2 AndAlso (Me.ExactSpotDate.Value.Minute = 58 OrElse Me.ExactSpotDate.Value.Minute = 59)) OrElse
                    (Me.ExactSpotDate.Value.Hour = 3 AndAlso (Me.ExactSpotDate.Value.Minute = 0 OrElse Me.ExactSpotDate.Value.Minute = 1)) Then

                NewStart = Me.ExactSpotDate.Value
                NewEnd = Me.ExactSpotDate.Value

            Else

                NewStart = Me.ExactSpotDate.Value.AddMinutes(-2)

                If AccountPayableTVBroadcastDetail.TimeOfDay.Minutes = 28 OrElse AccountPayableTVBroadcastDetail.TimeOfDay.Minutes = 43 OrElse AccountPayableTVBroadcastDetail.TimeOfDay.Minutes = 58 OrElse AccountPayableTVBroadcastDetail.TimeOfDay.Minutes = 13 Then

                    NewEnd = Me.ExactSpotDate.Value.AddMinutes(3)

                Else

                    NewEnd = Me.ExactSpotDate.Value.AddMinutes(2)

                End If

            End If

            Me.StartTime = NewStart.Hour.ToString & ":" & NewStart.Minute.ToString.PadLeft(2, "0")

            Me.EndTime = NewEnd.Hour.ToString & ":" & NewEnd.Minute.ToString.PadLeft(2, "0")

            Me.StartHour = NewStart.Hour.ToString & NewStart.Minute.ToString.PadLeft(2, "0")

            Me.EndHour = NewEnd.Hour.ToString & NewEnd.Minute.ToString.PadLeft(2, "0")

            If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

                Me.StartTime = Me.StartTime

            Else

                Me.StartTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

                Me.EndTime = Me.EndTime

            Else

                Me.EndTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

                If DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.StartTime)) Mod 15 = 0 Then

                    If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.StartTime)) < DayStartHour Then

                        Me.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.StartTime)) + 2400

                    Else

                        Me.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.StartTime))

                    End If

                Else

                    NewStartTime = DateAdd(DateInterval.Minute, -(DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.StartTime)) Mod 15), CDate(Now.ToShortDateString & " " & Me.StartTime))

                    If DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) < DayStartHour Then

                        Me.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) + 2400

                    Else

                        Me.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime)

                    End If

                End If

            End If

            If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.EndTime)) < DayStartHour Then

                    Me.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.EndTime)) + 2400

                Else

                    Me.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.EndTime))

                End If

            End If

        End Sub
        Public Sub New(AccountPayableRadioBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail)

            'objects
            Dim NewStart As Date = Nothing
            Dim NewEnd As Date = Nothing
            Dim NewStartTime As Date = Date.MinValue
            Dim DayStartHour As Integer = 300

            Me.ID = AccountPayableRadioBroadcastDetail.ID

            Me.ExactSpotDate = AccountPayableRadioBroadcastDetail.RunDate + AccountPayableRadioBroadcastDetail.TimeOfDay

            Select Case AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0)

                Case 1

                    Me.Monday = True
                    Me.Days = "M"

                Case 2

                    Me.Tuesday = True
                    Me.Days = "Tu"

                Case 3

                    Me.Wednesday = True
                    Me.Days = "W"

                Case 4

                    Me.Thursday = True
                    Me.Days = "Th"

                Case 5

                    Me.Friday = True
                    Me.Days = "F"

                Case 6

                    Me.Saturday = True
                    Me.Days = "Sa"

                Case 7

                    Me.Sunday = True
                    Me.Days = "Su"

            End Select

            NewStart = Me.ExactSpotDate.Value
            NewEnd = Me.ExactSpotDate.Value

            Me.StartTime = If(NewStart.Hour < 5, NewStart.Hour + 24, NewStart.Hour).ToString & ":" & NewStart.Minute.ToString.PadLeft(2, "0")

            Me.EndTime = If(NewEnd.Hour < 5, NewEnd.Hour + 24, NewEnd.Hour).ToString & ":" & NewEnd.Minute.ToString.PadLeft(2, "0")

            Me.StartHour = If(NewStart.Hour < 5, NewStart.Hour + 24, NewStart.Hour).ToString & NewStart.Minute.ToString.PadLeft(2, "0")

            Me.EndHour = If(NewEnd.Hour < 5, NewEnd.Hour + 24, NewEnd.Hour).ToString & NewEnd.Minute.ToString.PadLeft(2, "0")

            'If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

            '    Me.StartTime = Me.StartTime

            'Else

            '    Me.StartTime = String.Empty

            'End If

            'If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

            '    Me.EndTime = Me.EndTime

            'Else

            '    Me.EndTime = String.Empty

            'End If

        End Sub
        Public Sub SetBreakValues(AddMinutes As Integer)

            If Me.Monday Then

                Me.Sunday = If(AddMinutes = -2, True, False)
                Me.Tuesday = If(AddMinutes = 2, True, False)
                Me.Monday = False

            ElseIf Me.Tuesday Then

                Me.Monday = If(AddMinutes = -2, True, False)
                Me.Wednesday = If(AddMinutes = 2, True, False)
                Me.Tuesday = False

            ElseIf Me.Wednesday Then

                Me.Tuesday = If(AddMinutes = -2, True, False)
                Me.Thursday = If(AddMinutes = 2, True, False)
                Me.Wednesday = False

            ElseIf Me.Thursday Then

                Me.Wednesday = If(AddMinutes = -2, True, False)
                Me.Friday = If(AddMinutes = 2, True, False)
                Me.Thursday = False

            ElseIf Me.Friday Then

                Me.Thursday = If(AddMinutes = -2, True, False)
                Me.Saturday = If(AddMinutes = 2, True, False)
                Me.Friday = False

            ElseIf Me.Saturday Then

                Me.Friday = If(AddMinutes = -2, True, False)
                Me.Sunday = If(AddMinutes = 2, True, False)
                Me.Saturday = False

            ElseIf Me.Sunday Then

                Me.Saturday = If(AddMinutes = -2, True, False)
                Me.Monday = If(AddMinutes = 2, True, False)
                Me.Sunday = False

            End If

            If AddMinutes = 2 Then

                Me.StartHour = 300
                Me.EndHour = 302

            ElseIf AddMinutes = -2 Then

                Me.StartHour = 2645
                Me.EndHour = 2658

            End If

            Me.ExactSpotDate = DateAdd(DateInterval.Day, If(AddMinutes = 2, 1, -1), DateAdd(DateInterval.Minute, AddMinutes, Me.ExactSpotDate.Value))

            If Me.StartTime = "2:58" Then

                Me.StartTime = "3:00"
                Me.EndTime = "3:00"

            ElseIf Me.StartTime = "2:59" Then

                Me.StartTime = "3:01"
                Me.EndTime = "3:01"

            ElseIf Me.StartTime = "3:00" Then

                Me.StartTime = "2:58"
                Me.EndTime = "2:58"

            ElseIf Me.StartTime = "3:01" Then

                Me.StartTime = "2:59"
                Me.EndTime = "2:59"

            End If

        End Sub
        ''' <summary>
        ''' Only use this method if indeed for Puerto Rico data!
        ''' </summary>
        ''' <param name="AccountPayableTVBroadcastDetail"></param>
        ''' <param name="IsPuertoRico"></param>
        Public Sub New(AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail, IsPuertoRico As Boolean)

            'objects
            Dim NewStart As Date = Nothing
            Dim NewEnd As Date = Nothing
            Dim NewStartTime As Date = Date.MinValue
            Dim DayStartHour As Integer = 200

            Me.ID = AccountPayableTVBroadcastDetail.ID

            Me.ExactSpotDate = AccountPayableTVBroadcastDetail.RunDate + AccountPayableTVBroadcastDetail.TimeOfDay

            Select Case AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0)

                Case 1

                    Me.Monday = True
                    Me.Days = "M"

                Case 2

                    Me.Tuesday = True
                    Me.Days = "Tu"

                Case 3

                    Me.Wednesday = True
                    Me.Days = "W"

                Case 4

                    Me.Thursday = True
                    Me.Days = "Th"

                Case 5

                    Me.Friday = True
                    Me.Days = "F"

                Case 6

                    Me.Saturday = True
                    Me.Days = "Sa"

                Case 7

                    Me.Sunday = True
                    Me.Days = "Su"

            End Select

            'note Puerto Rico does not use break-averaging
            NewStart = Me.ExactSpotDate.Value
            NewEnd = Me.ExactSpotDate.Value

            Me.StartTime = NewStart.Hour.ToString & ":" & NewStart.Minute.ToString.PadLeft(2, "0")

            Me.EndTime = NewEnd.Hour.ToString & ":" & NewEnd.Minute.ToString.PadLeft(2, "0")

            Me.StartHour = NewStart.Hour.ToString & NewStart.Minute.ToString.PadLeft(2, "0")

            Me.EndHour = NewEnd.Hour.ToString & NewEnd.Minute.ToString.PadLeft(2, "0")

            If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

                Me.StartTime = Me.StartTime

            Else

                Me.StartTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

                Me.EndTime = Me.EndTime

            Else

                Me.EndTime = String.Empty

            End If

            If Not String.IsNullOrWhiteSpace(Me.StartTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.StartTime, NewStartTime) Then

                If DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.StartTime)) Mod 15 = 0 Then

                    If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.StartTime)) < DayStartHour Then

                        Me.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.StartTime)) + 2400

                    Else

                        Me.StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.StartTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.StartTime))

                    End If

                Else

                    NewStartTime = DateAdd(DateInterval.Minute, -(DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.StartTime)) Mod 15), CDate(Now.ToShortDateString & " " & Me.StartTime))

                    If DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) < DayStartHour Then

                        Me.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime) + 2400

                    Else

                        Me.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime)

                    End If

                End If

            End If

            If Not String.IsNullOrWhiteSpace(Me.EndTime) AndAlso Date.TryParse(Now.ToShortDateString & " " & Me.EndTime, NewStartTime) Then

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.EndTime)) < DayStartHour Then

                    Me.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.EndTime)) + 2400

                Else

                    Me.EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & Me.EndTime)) * 100 + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & Me.EndTime))

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace
