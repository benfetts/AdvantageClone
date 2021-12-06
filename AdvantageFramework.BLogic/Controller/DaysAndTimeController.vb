Namespace Controller

	Public Class DaysAndTimeController
		Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session)

			MyBase.New(Session)

		End Sub
		Public Function Load(DaysAndTime As AdvantageFramework.DTO.DaysAndTime) As AdvantageFramework.ViewModels.DaysAndTimeViewModel

			'objects
			Dim DaysAndTimeViewModel As AdvantageFramework.ViewModels.DaysAndTimeViewModel = Nothing

			DaysAndTimeViewModel = New AdvantageFramework.ViewModels.DaysAndTimeViewModel

			DaysAndTimeViewModel.DaysAndTime = DaysAndTime

			Load = DaysAndTimeViewModel

		End Function
        'Public Sub ParseDays(ByRef DaysAndTime As AdvantageFramework.DTO.DaysAndTime, ByRef EnteredDays As String, ByRef IsValid As Boolean)

        '	'objects
        '	Dim Days As Generic.List(Of String) = Nothing
        '	Dim FirstDay As Integer = -1
        '	Dim LastDay As Integer = -1
        '	Dim DayCounter As Integer = -1
        '	Dim DayChar As Char = String.Empty

        '	If String.IsNullOrWhiteSpace(EnteredDays) = False Then

        '		If EnteredDays.Contains("-") Then

        '			If EnteredDays.Split("-").Count > 2 OrElse EnteredDays.Split("-").Count < 2 Then

        '				IsValid = False

        '			ElseIf EnteredDays.Split("-").Count = 2 Then

        '				Days = EnteredDays.Split("-").Select(Function(DOW) DOW.ToUpper).ToList

        '				If Days.Distinct.Count = Days.Count Then

        '					Select Case Days(0)

        '						Case "M"

        '							FirstDay = System.DayOfWeek.Monday

        '						Case "TU"

        '							FirstDay = System.DayOfWeek.Tuesday

        '						Case "W"

        '							FirstDay = System.DayOfWeek.Wednesday

        '						Case "TH"

        '							FirstDay = System.DayOfWeek.Thursday

        '						Case "F"

        '							FirstDay = System.DayOfWeek.Friday

        '						Case "SA"

        '							FirstDay = System.DayOfWeek.Saturday

        '						Case "SU"

        '							FirstDay = System.DayOfWeek.Sunday

        '					End Select

        '					Select Case Days(1)

        '						Case "M"

        '							LastDay = System.DayOfWeek.Monday

        '						Case "TU"

        '							LastDay = System.DayOfWeek.Tuesday

        '						Case "W"

        '							LastDay = System.DayOfWeek.Wednesday

        '						Case "TH"

        '							LastDay = System.DayOfWeek.Thursday

        '						Case "F"

        '							LastDay = System.DayOfWeek.Friday

        '						Case "SA"

        '							LastDay = System.DayOfWeek.Saturday

        '						Case "SU"

        '							LastDay = System.DayOfWeek.Sunday

        '					End Select

        '					If (FirstDay > -1 AndAlso FirstDay < 7) AndAlso (LastDay > -1 AndAlso LastDay < 7) Then

        '						DaysAndTime.Monday = False
        '						DaysAndTime.Tuesday = False
        '						DaysAndTime.Wednesday = False
        '						DaysAndTime.Thursday = False
        '						DaysAndTime.Friday = False
        '						DaysAndTime.Saturday = False
        '						DaysAndTime.Sunday = False

        '						DayCounter = FirstDay - 1

        '						Do

        '							DayCounter += 1

        '							If DayCounter > 6 Then

        '								DayCounter = 0

        '							End If

        '							Select Case DayCounter

        '								Case System.DayOfWeek.Monday

        '									DaysAndTime.Monday = True

        '								Case System.DayOfWeek.Tuesday

        '									DaysAndTime.Tuesday = True

        '								Case System.DayOfWeek.Wednesday

        '									DaysAndTime.Wednesday = True

        '								Case System.DayOfWeek.Thursday

        '									DaysAndTime.Thursday = True

        '								Case System.DayOfWeek.Friday

        '									DaysAndTime.Friday = True

        '								Case System.DayOfWeek.Saturday

        '									DaysAndTime.Saturday = True

        '								Case System.DayOfWeek.Sunday

        '									DaysAndTime.Sunday = True

        '							End Select

        '						Loop Until DayCounter = LastDay

        '						EnteredDays = EnteredDays.ToUpper
        '						DaysAndTime.Days = EnteredDays

        '						IsValid = True

        '					Else

        '						IsValid = False

        '					End If

        '				Else

        '					IsValid = False

        '				End If

        '			End If

        '		Else

        '			IsValid = True

        '			Days = New Generic.List(Of String)

        '			For DayCounter = 0 To EnteredDays.Count - 1

        '				Select Case EnteredDays(DayCounter).ToString.ToUpper

        '					Case "M"

        '						Days.Add(EnteredDays(DayCounter).ToString.ToUpper)

        '					Case "T"

        '						If DayCounter + 1 <= EnteredDays.Count - 1 Then

        '							If EnteredDays(DayCounter + 1).ToString.ToUpper = "U" Then

        '								Days.Add("TU")
        '								DayCounter += 1

        '							ElseIf EnteredDays(DayCounter + 1).ToString.ToUpper = "H" Then

        '								Days.Add("TH")
        '								DayCounter += 1

        '							Else

        '								IsValid = False
        '								Exit For

        '							End If

        '						Else

        '							IsValid = False
        '							Exit For

        '						End If

        '					Case "W"

        '						Days.Add(EnteredDays(DayCounter).ToString.ToUpper)

        '					Case "F"

        '						Days.Add(EnteredDays(DayCounter).ToString.ToUpper)

        '					Case "S"

        '						If DayCounter + 1 <= EnteredDays.Count - 1 Then

        '							If EnteredDays(DayCounter + 1).ToString.ToUpper = "A" Then

        '								Days.Add("SA")
        '								DayCounter += 1

        '							ElseIf EnteredDays(DayCounter + 1).ToString.ToUpper = "U" Then

        '								Days.Add("SU")
        '								DayCounter += 1

        '							Else

        '								IsValid = False
        '								Exit For

        '							End If

        '						Else

        '							IsValid = False
        '							Exit For

        '						End If

        '					Case Else

        '						IsValid = False
        '						Exit For

        '				End Select

        '			Next

        '			If IsValid Then

        '				If Days.Distinct.Count = Days.Count Then

        '					DaysAndTime.Monday = False
        '					DaysAndTime.Tuesday = False
        '					DaysAndTime.Wednesday = False
        '					DaysAndTime.Thursday = False
        '					DaysAndTime.Friday = False
        '					DaysAndTime.Saturday = False
        '					DaysAndTime.Sunday = False

        '					For Each DayOfWeek In Days

        '						Select Case DayOfWeek

        '							Case "M"

        '								DaysAndTime.Monday = True

        '							Case "TU"

        '								DaysAndTime.Tuesday = True

        '							Case "W"

        '								DaysAndTime.Wednesday = True

        '							Case "TH"

        '								DaysAndTime.Thursday = True

        '							Case "F"

        '								DaysAndTime.Friday = True

        '							Case "SA"

        '								DaysAndTime.Saturday = True

        '							Case "SU"

        '								DaysAndTime.Sunday = True

        '						End Select

        '					Next

        '					EnteredDays = EnteredDays.ToUpper
        '					DaysAndTime.Days = EnteredDays

        '				Else

        '					IsValid = False

        '				End If

        '			End If

        '		End If

        '	Else

        '		IsValid = True

        '		DaysAndTime.Monday = False
        '		DaysAndTime.Tuesday = False
        '		DaysAndTime.Wednesday = False
        '		DaysAndTime.Thursday = False
        '		DaysAndTime.Friday = False
        '		DaysAndTime.Saturday = False
        '		DaysAndTime.Sunday = False

        '		DaysAndTime.Days = String.Empty

        '	End If

        'End Sub
        Public Sub ParseTime(ByRef DaysAndTime As AdvantageFramework.DTO.DaysAndTime, IsStartTime As Boolean, ByRef Time As String, ByRef IsValid As Boolean)

			'objects
			Dim TimeEntry As String = String.Empty
			Dim TimeNumberString As String = String.Empty
			Dim TimeAMPM As String = String.Empty
			Dim TimeHourString As String = String.Empty
			Dim TimeMinutesString As String = String.Empty
			Dim TimeHour As Integer = 0
			Dim TimeMinutes As Integer = 0
			Dim TimeDate As Date = Date.MinValue
			Dim StartDateTime As Date = Date.MinValue
			Dim EndDateTime As Date = Date.MinValue

			If String.IsNullOrWhiteSpace(Time) = False Then

				IsValid = True

				TimeEntry = AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Time)

				TimeNumberString = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(TimeEntry)

				TimeAMPM = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(TimeEntry)

				If TimeNumberString.Length = 4 Then

					TimeHourString = TimeNumberString.Substring(0, 2)
					TimeMinutesString = TimeNumberString.Substring(2)

				ElseIf TimeNumberString.Length = 3 Then

					TimeHourString = TimeNumberString.Substring(0, 1)
					TimeMinutesString = TimeNumberString.Substring(1)

				ElseIf TimeNumberString.Length = 2 Then

					TimeHourString = TimeNumberString
					TimeMinutesString = "00"

				ElseIf TimeNumberString.Length = 1 Then

					TimeHourString = TimeNumberString
					TimeMinutesString = "00"

				Else

					IsValid = False

				End If

				If IsValid Then

					If Integer.TryParse(TimeHourString, TimeHour) Then

						If TimeHour > 12 OrElse TimeHour < 1 Then

							IsValid = False

						End If

					End If

					If IsValid Then

						If Integer.TryParse(TimeMinutesString, TimeMinutes) Then

							If TimeMinutes > 59 OrElse TimeMinutes < 0 Then

								IsValid = False

							End If

						End If

					End If

				End If

				If IsValid Then

					TimeAMPM = TimeAMPM.ToUpper

					If TimeAMPM.Length = 2 Then

						If TimeAMPM <> "AM" AndAlso TimeAMPM <> "PM" Then

							IsValid = False

						End If

					ElseIf TimeAMPM.Length = 1 Then

						If TimeAMPM = "M" Then

							TimeAMPM = "AM"

						ElseIf TimeAMPM = "N" Then

							TimeAMPM = "PM"

						ElseIf TimeAMPM = "A" Then

							TimeAMPM = "AM"

						ElseIf TimeAMPM = "P" Then

							TimeAMPM = "PM"

						Else

							IsValid = False

						End If

					Else

						IsValid = False

					End If

				End If

				If IsValid Then

					If TimeAMPM = "AM" Then

						If TimeHour = 12 Then

							TimeDate = New Date(Now.Year, Now.Month, Now.Day, 0, TimeMinutes, 0)

						Else

							TimeDate = New Date(Now.Year, Now.Month, Now.Day, TimeHour, TimeMinutes, 0)

						End If

					Else

						If TimeHour = 12 Then

							TimeDate = New Date(Now.Year, Now.Month, Now.Day, TimeHour, TimeMinutes, 0)

						Else

							TimeDate = New Date(Now.Year, Now.Month, Now.Day, TimeHour + 12, TimeMinutes, 0)

						End If

					End If

					Time = TimeDate.ToString("hh:mm tt")

					If IsStartTime Then

						DaysAndTime.StartTime = Time

						'If String.IsNullOrWhiteSpace(DaysAndTime.EndTime) = False Then

						'	If Date.TryParse(DaysAndTime.EndTime, EndDateTime) Then

						'		If DateDiff(DateInterval.Minute, EndDateTime, TimeDate) >= 0 Then

						'			IsValid = False

						'		ElseIf TimeDate.Hour < 3 AndAlso EndDateTime.Hour >= 3 Then

						'			IsValid = False

						'		End If

						'	End If

						'End If

					Else

						DaysAndTime.EndTime = Time

						'If String.IsNullOrWhiteSpace(DaysAndTime.StartTime) = False Then

						'	If Date.TryParse(DaysAndTime.StartTime, StartDateTime) Then

						'		If DateDiff(DateInterval.Minute, StartDateTime, TimeDate) < 0 Then

						'			IsValid = False

						'		End If

						'	End If

						'End If

					End If

				End If

			Else

				IsValid = True

				If IsStartTime Then

					DaysAndTime.StartTime = String.Empty

				Else

					DaysAndTime.EndTime = String.Empty

				End If

			End If

		End Sub
		Public Function ValidateEntityProperty(DaysAndTime As AdvantageFramework.DTO.DaysAndTime, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(DaysAndTime.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, DaysAndTime, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            ValidateEntityProperty = ErrorText

        End Function
        Public Function ValidateEntity(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
                                       ByRef DTO As AdvantageFramework.DTO.BaseClass, ByRef IsValid As Boolean) As String

            ValidateEntity = Me.ValidateDTO(DbContext, DataContext, DTO, IsValid)

        End Function
		Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext, ByRef DTO As AdvantageFramework.DTO.BaseClass,
														   PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

			'objects
			Dim ErrorText As String = ""
			Dim PropertyValue As Object = Nothing
			Dim DaysAndTime As AdvantageFramework.DTO.DaysAndTime = Nothing
			Dim EndTimeValue As Integer = 0
			Dim StartTimeValue As Integer = 0

			DaysAndTime = DTO

			Select Case PropertyName

				Case AdvantageFramework.DTO.DaysAndTime.Properties.Days.ToString

					Me.ParseDays(DaysAndTime, Value, IsValid)

					If Not IsValid Then

						ErrorText = "Invalid Days Entry"

					End If

				Case AdvantageFramework.DTO.DaysAndTime.Properties.StartTime.ToString

					PropertyValue = Value

					If Not IsDate(Value) Then

						IsValid = False

						ErrorText = "Invalid Time Entry"

					ElseIf Not String.IsNullOrWhiteSpace(PropertyValue) AndAlso Not String.IsNullOrWhiteSpace(DaysAndTime.EndTime) Then

                        'If CDate(PropertyValue) = CDate(DaysAndTime.EndTime) Then

                        '	IsValid = False

                        '	ErrorText = "Start time and end time cannot be the same"

                        'Else
                        If DaysAndTime.BroadcastType = AdvantageFramework.DTO.DaysAndTime.BroadcastTypes.TV Then

                            If DaysAndTime.IsUsing3rdPartyData Then

                                If CDate(PropertyValue).Hour < 3 AndAlso CDate(DaysAndTime.EndTime).Hour >= 3 Then

                                    IsValid = False

                                    ErrorText = "Time cannot cross Nielsen’s 3AM start of day"

                                Else

                                    If CDate(PropertyValue).Hour < 3 AndAlso CDate(PropertyValue).Hour >= 0 Then

                                        StartTimeValue = 2400 + (100 * CDate(PropertyValue).Hour)

                                    Else

                                        StartTimeValue = 100 * CDate(PropertyValue).Hour

                                    End If

                                    StartTimeValue += CDate(PropertyValue).Minute

                                    If CDate(DaysAndTime.EndTime).Hour < 3 AndAlso CDate(DaysAndTime.EndTime).Hour >= 0 Then

                                        EndTimeValue = 2400 + (100 * CDate(DaysAndTime.EndTime).Hour)

                                    Else

                                        EndTimeValue = 100 * CDate(DaysAndTime.EndTime).Hour

                                    End If

                                    EndTimeValue += CDate(DaysAndTime.EndTime).Minute

                                    If StartTimeValue > EndTimeValue Then

                                        IsValid = False

                                        ErrorText = "Start time must be before end time"

                                    End If

                                End If

                            End If

                        ElseIf DaysAndTime.BroadcastType = AdvantageFramework.DTO.DaysAndTime.BroadcastTypes.Radio Then

                            If DaysAndTime.IsUsing3rdPartyData Then

                                If CDate(PropertyValue).Hour < 5 AndAlso CDate(DaysAndTime.EndTime).Hour >= 5 Then

                                    IsValid = False

                                    ErrorText = "Time cannot cross Nielsen’s 5AM start of day"

                                Else

                                    If CDate(PropertyValue).Hour < 5 AndAlso CDate(PropertyValue).Hour >= 0 Then

                                        StartTimeValue = 2400 + (100 * CDate(PropertyValue).Hour)

                                    Else

                                        StartTimeValue = 100 * CDate(PropertyValue).Hour

                                    End If

                                    StartTimeValue += CDate(PropertyValue).Minute

                                    If CDate(DaysAndTime.EndTime).Hour < 5 AndAlso CDate(DaysAndTime.EndTime).Hour >= 0 Then

                                        EndTimeValue = 2400 + (100 * CDate(DaysAndTime.EndTime).Hour)

                                    Else

                                        EndTimeValue = 100 * CDate(DaysAndTime.EndTime).Hour

                                    End If

                                    EndTimeValue += CDate(DaysAndTime.EndTime).Minute

                                    If StartTimeValue > EndTimeValue Then

                                        IsValid = False

                                        ErrorText = "Start time must be before end time"

                                    End If

                                End If

                            End If

                        ElseIf DaysAndTime.BroadcastType = AdvantageFramework.DTO.DaysAndTime.BroadcastTypes.National Then

                            If DaysAndTime.IsUsing3rdPartyData Then

                                If CDate(PropertyValue).Hour < 6 AndAlso CDate(DaysAndTime.EndTime).Hour >= 6 Then

                                    IsValid = False

                                    ErrorText = "Time cannot cross Nielsen’s 6AM start of day"

                                Else

                                    If CDate(PropertyValue).Hour < 6 AndAlso CDate(PropertyValue).Hour >= 0 Then

                                        StartTimeValue = 2400 + (100 * CDate(PropertyValue).Hour)

                                    Else

                                        StartTimeValue = 100 * CDate(PropertyValue).Hour

                                    End If

                                    StartTimeValue += CDate(PropertyValue).Minute

                                    If CDate(DaysAndTime.EndTime).Hour < 6 AndAlso CDate(DaysAndTime.EndTime).Hour >= 0 Then

                                        EndTimeValue = 2400 + (100 * CDate(DaysAndTime.EndTime).Hour)

                                    Else

                                        EndTimeValue = 100 * CDate(DaysAndTime.EndTime).Hour

                                    End If

                                    EndTimeValue += CDate(DaysAndTime.EndTime).Minute

                                    If StartTimeValue > EndTimeValue Then

                                        IsValid = False

                                        ErrorText = "Start time must be before end time"

                                    End If

                                End If

                            End If

                        ElseIf DaysAndTime.BroadcastType = AdvantageFramework.DTO.DaysAndTime.BroadcastTypes.TVPuertoRico Then

                            If DaysAndTime.IsUsing3rdPartyData Then

                                If CDate(PropertyValue).Hour < 2 AndAlso CDate(DaysAndTime.EndTime).Hour >= 2 Then

                                    IsValid = False

                                    ErrorText = "Time cannot cross Nielsen’s 2AM start of day"

                                Else

                                    If CDate(PropertyValue).Hour < 2 AndAlso CDate(PropertyValue).Hour >= 0 Then

                                        StartTimeValue = 2400 + (100 * CDate(PropertyValue).Hour)

                                    Else

                                        StartTimeValue = 100 * CDate(PropertyValue).Hour

                                    End If

                                    StartTimeValue += CDate(PropertyValue).Minute

                                    If CDate(DaysAndTime.EndTime).Hour < 2 AndAlso CDate(DaysAndTime.EndTime).Hour >= 0 Then

                                        EndTimeValue = 2400 + (100 * CDate(DaysAndTime.EndTime).Hour)

                                    Else

                                        EndTimeValue = 100 * CDate(DaysAndTime.EndTime).Hour

                                    End If

                                    EndTimeValue += CDate(DaysAndTime.EndTime).Minute

                                    If StartTimeValue > EndTimeValue Then

                                        IsValid = False

                                        ErrorText = "Start time must be before end time"

                                    End If

                                End If

                            End If

                        End If

					End If

				Case AdvantageFramework.DTO.DaysAndTime.Properties.EndTime.ToString

					PropertyValue = Value

					If Not IsDate(Value) Then

						IsValid = False

						ErrorText = "Invalid Time Entry"

					End If

			End Select

			ValidateCustomProperties = ErrorText

		End Function
        Public Sub ParseDays(ByRef DaysAndTime As AdvantageFramework.DTO.DaysAndTime, ByRef EnteredDays As String, ByRef IsValid As Boolean)

            'objects
            Dim AllDays() As String = Nothing
            Dim Days As Generic.List(Of String) = Nothing
            Dim FirstDay As Integer = -1
            Dim LastDay As Integer = -1
            Dim DayCounter As Integer = -1
            Dim DashDays As Generic.List(Of String) = Nothing
            Dim NoOverlap As Boolean = True
            Dim DayValues As Generic.List(Of Integer) = Nothing

            Days = New Generic.List(Of String)
            DayValues = New Generic.List(Of Integer)

            DaysAndTime.Days = String.Empty

            DaysAndTime.Monday = False
            DaysAndTime.Tuesday = False
            DaysAndTime.Wednesday = False
            DaysAndTime.Thursday = False
            DaysAndTime.Friday = False
            DaysAndTime.Saturday = False
            DaysAndTime.Sunday = False

            If String.IsNullOrWhiteSpace(EnteredDays) = False Then

                Try

                    AllDays = EnteredDays.Split(",")

                    IsValid = True

                    For Each AllDay In AllDays

                        NoOverlap = True
                        FirstDay = -1
                        LastDay = -1
                        AllDay = AllDay.Trim

                        If IsValid Then

                            If AllDay.Contains("-") Then

                                If AllDay.Split("-").Count = 2 Then

                                    DashDays = AllDay.Split("-").Select(Function(DOW) DOW.ToUpper).ToList

                                    If DashDays.Distinct.Count = DashDays.Count Then

                                        Select Case DashDays(0)

                                            Case "M"

                                                FirstDay = System.DayOfWeek.Monday

                                            Case "TU"

                                                FirstDay = System.DayOfWeek.Tuesday

                                            Case "W"

                                                FirstDay = System.DayOfWeek.Wednesday

                                            Case "TH"

                                                FirstDay = System.DayOfWeek.Thursday

                                            Case "F"

                                                FirstDay = System.DayOfWeek.Friday

                                            Case "SA"

                                                FirstDay = System.DayOfWeek.Saturday

                                            Case "SU"

                                                FirstDay = System.DayOfWeek.Sunday

                                        End Select

                                        Select Case DashDays(1)

                                            Case "M"

                                                LastDay = System.DayOfWeek.Monday

                                            Case "TU"

                                                LastDay = System.DayOfWeek.Tuesday

                                            Case "W"

                                                LastDay = System.DayOfWeek.Wednesday

                                            Case "TH"

                                                LastDay = System.DayOfWeek.Thursday

                                            Case "F"

                                                LastDay = System.DayOfWeek.Friday

                                            Case "SA"

                                                LastDay = System.DayOfWeek.Saturday

                                            Case "SU"

                                                LastDay = System.DayOfWeek.Sunday

                                        End Select

                                        Select Case FirstDay

                                            Case System.DayOfWeek.Monday

                                                'can have any end date

                                            Case System.DayOfWeek.Tuesday

                                                If LastDay = System.DayOfWeek.Monday Then

                                                    NoOverlap = False

                                                End If

                                            Case System.DayOfWeek.Wednesday

                                                If LastDay = System.DayOfWeek.Monday OrElse
                                                        LastDay = System.DayOfWeek.Tuesday Then

                                                    NoOverlap = False

                                                End If

                                            Case System.DayOfWeek.Thursday

                                                If LastDay = System.DayOfWeek.Monday OrElse
                                                        LastDay = System.DayOfWeek.Tuesday OrElse
                                                        LastDay = System.DayOfWeek.Wednesday Then

                                                    NoOverlap = False

                                                End If

                                            Case System.DayOfWeek.Friday

                                                If LastDay = System.DayOfWeek.Monday OrElse
                                                        LastDay = System.DayOfWeek.Tuesday OrElse
                                                        LastDay = System.DayOfWeek.Wednesday OrElse
                                                        LastDay = System.DayOfWeek.Thursday Then

                                                    NoOverlap = False

                                                End If

                                            Case System.DayOfWeek.Saturday

                                                If LastDay = System.DayOfWeek.Monday OrElse
                                                        LastDay = System.DayOfWeek.Tuesday OrElse
                                                        LastDay = System.DayOfWeek.Wednesday OrElse
                                                        LastDay = System.DayOfWeek.Thursday OrElse
                                                        LastDay = System.DayOfWeek.Friday Then

                                                    NoOverlap = False

                                                End If

                                            Case System.DayOfWeek.Sunday

                                                If LastDay = System.DayOfWeek.Monday OrElse
                                                        LastDay = System.DayOfWeek.Tuesday OrElse
                                                        LastDay = System.DayOfWeek.Wednesday OrElse
                                                        LastDay = System.DayOfWeek.Thursday OrElse
                                                        LastDay = System.DayOfWeek.Friday OrElse
                                                        LastDay = System.DayOfWeek.Saturday Then

                                                    NoOverlap = False

                                                End If

                                        End Select

                                        If NoOverlap AndAlso (FirstDay > -1 AndAlso FirstDay < 7) AndAlso (LastDay > -1 AndAlso LastDay < 7) Then

                                            DayCounter = FirstDay - 1

                                            Do

                                                DayCounter += 1

                                                If DayCounter > 6 Then

                                                    DayCounter = 0

                                                End If

                                                Select Case DayCounter

                                                    Case System.DayOfWeek.Monday

                                                        DaysAndTime.Monday = True
                                                        Days.Add("M")
                                                        DayValues.Add(0)

                                                    Case System.DayOfWeek.Tuesday

                                                        DaysAndTime.Tuesday = True
                                                        Days.Add("TU")
                                                        DayValues.Add(1)

                                                    Case System.DayOfWeek.Wednesday

                                                        DaysAndTime.Wednesday = True
                                                        Days.Add("W")
                                                        DayValues.Add(2)

                                                    Case System.DayOfWeek.Thursday

                                                        DaysAndTime.Thursday = True
                                                        Days.Add("TH")
                                                        DayValues.Add(3)

                                                    Case System.DayOfWeek.Friday

                                                        DaysAndTime.Friday = True
                                                        Days.Add("F")
                                                        DayValues.Add(4)

                                                    Case System.DayOfWeek.Saturday

                                                        DaysAndTime.Saturday = True
                                                        Days.Add("SA")
                                                        DayValues.Add(5)

                                                    Case System.DayOfWeek.Sunday

                                                        DaysAndTime.Sunday = True
                                                        Days.Add("SU")
                                                        DayValues.Add(6)

                                                End Select

                                            Loop Until DayCounter = LastDay

                                            AllDay = AllDay.ToUpper
                                            DaysAndTime.Days += AllDay & ", "

                                            IsValid = True

                                        Else

                                            IsValid = False

                                        End If

                                    Else

                                        IsValid = False

                                    End If

                                Else

                                    IsValid = False

                                End If

                            Else

                                Select Case AllDay.ToUpper

                                    Case "M"

                                        DayValues.Add(0)
                                        Days.Add(AllDay.ToUpper)
                                        DaysAndTime.Monday = True

                                    Case "TU"

                                        DayValues.Add(1)
                                        Days.Add(AllDay.ToUpper)
                                        DaysAndTime.Tuesday = True

                                    Case "W"

                                        DayValues.Add(2)
                                        Days.Add(AllDay.ToUpper)
                                        DaysAndTime.Wednesday = True

                                    Case "TH"

                                        DayValues.Add(3)
                                        Days.Add(AllDay.ToUpper)
                                        DaysAndTime.Thursday = True

                                    Case "F"

                                        DayValues.Add(4)
                                        Days.Add(AllDay.ToUpper)
                                        DaysAndTime.Friday = True

                                    Case "SA"

                                        DayValues.Add(5)
                                        Days.Add(AllDay.ToUpper)
                                        DaysAndTime.Saturday = True

                                    Case "SU"

                                        DayValues.Add(6)
                                        Days.Add(AllDay.ToUpper)
                                        DaysAndTime.Sunday = True

                                    Case Else

                                        IsValid = False

                                End Select

                                If IsValid Then

                                    AllDay = AllDay.ToUpper
                                    DaysAndTime.Days += AllDay & ", "

                                End If

                            End If

                        End If

                    Next

                    If DayValues.SequenceEqual(DayValues.OrderBy(Function(Day) Day).ToList) = False Then

                        IsValid = False

                    End If

                Catch ex As Exception
                    IsValid = False
                End Try

            Else

                IsValid = True

                DaysAndTime.Monday = False
                DaysAndTime.Tuesday = False
                DaysAndTime.Wednesday = False
                DaysAndTime.Thursday = False
                DaysAndTime.Friday = False
                DaysAndTime.Saturday = False
                DaysAndTime.Sunday = False

                DaysAndTime.Days = String.Empty

            End If

            If DaysAndTime.Days.EndsWith(", ") Then

                DaysAndTime.Days = Mid(DaysAndTime.Days, 1, DaysAndTime.Days.Length - 2)

            End If

            DaysAndTime.Days = DaysAndTime.Days.Replace("TU", "Tu")
            DaysAndTime.Days = DaysAndTime.Days.Replace("TH", "Th")
            DaysAndTime.Days = DaysAndTime.Days.Replace("SA", "Sa")
            DaysAndTime.Days = DaysAndTime.Days.Replace("SU", "Su")

            If IsValid Then

                EnteredDays = DaysAndTime.Days

            End If

        End Sub
        Public Function GetFirstDay(DaysAndTime As AdvantageFramework.DTO.DaysAndTime) As Integer

            'objects
            Dim AllDay As String = String.Empty
            Dim AllDays() As String = Nothing
            Dim FirstDay As Integer = -1
            Dim DashDays As Generic.List(Of String) = Nothing

            If DaysAndTime IsNot Nothing AndAlso String.IsNullOrWhiteSpace(DaysAndTime.Days) = False Then

                Try

                    AllDays = DaysAndTime.Days.Split(",")

                    If AllDays.Count > 0 Then

                        AllDay = AllDays.First.Trim

                        If AllDay.Contains("-") Then

                            If AllDay.Split("-").Count = 2 Then

                                DashDays = AllDay.Split("-").Select(Function(DOW) DOW.ToUpper).ToList

                                If DashDays.Distinct.Count = DashDays.Count Then

                                    Select Case DashDays(0)

                                        Case "M"

                                            FirstDay = System.DayOfWeek.Monday

                                        Case "TU"

                                            FirstDay = System.DayOfWeek.Tuesday

                                        Case "W"

                                            FirstDay = System.DayOfWeek.Wednesday

                                        Case "TH"

                                            FirstDay = System.DayOfWeek.Thursday

                                        Case "F"

                                            FirstDay = System.DayOfWeek.Friday

                                        Case "SA"

                                            FirstDay = System.DayOfWeek.Saturday

                                        Case "SU"

                                            FirstDay = System.DayOfWeek.Sunday

                                    End Select

                                End If

                            End If

                        Else

                            Select Case AllDay.ToUpper

                                Case "M"

                                    FirstDay = System.DayOfWeek.Monday

                                Case "TU"

                                    FirstDay = System.DayOfWeek.Tuesday

                                Case "W"

                                    FirstDay = System.DayOfWeek.Wednesday

                                Case "TH"

                                    FirstDay = System.DayOfWeek.Thursday

                                Case "F"

                                    FirstDay = System.DayOfWeek.Friday

                                Case "SA"

                                    FirstDay = System.DayOfWeek.Saturday

                                Case "SU"

                                    FirstDay = System.DayOfWeek.Sunday

                            End Select

                        End If

                    End If

                Catch ex As Exception

                End Try

            End If

            GetFirstDay = FirstDay

        End Function
        Public Function GetDaysNumber(DaysAndTime As AdvantageFramework.DTO.DaysAndTime) As Integer

            'objects
            Dim FirstDay As Integer = -1
            Dim FirstDayOfWeek As System.DayOfWeek = System.DayOfWeek.Monday
            Dim DaysNumber As Integer = 0
            Dim DayCounter As Integer = 0

            If DaysAndTime IsNot Nothing Then

                FirstDay = GetFirstDay(DaysAndTime)

                If FirstDay > -1 AndAlso FirstDay < 7 Then

                    Select Case FirstDay

                        Case 1

                            FirstDayOfWeek = System.DayOfWeek.Monday

                            DaysNumber = 1

                        Case 2

                            FirstDayOfWeek = System.DayOfWeek.Tuesday

                            DaysNumber = 2

                        Case 3

                            FirstDayOfWeek = System.DayOfWeek.Wednesday

                            DaysNumber = 3

                        Case 4

                            FirstDayOfWeek = System.DayOfWeek.Thursday

                            DaysNumber = 4

                        Case 5

                            FirstDayOfWeek = System.DayOfWeek.Friday

                            DaysNumber = 5

                        Case 6

                            FirstDayOfWeek = System.DayOfWeek.Saturday

                            DaysNumber = 6

                        Case 0

                            FirstDayOfWeek = System.DayOfWeek.Sunday

                            DaysNumber = 7

                    End Select

                    If DaysAndTime.Monday Then

                        DayCounter += 1

                    End If

                    If DaysAndTime.Tuesday Then

                        DayCounter += 1

                    End If

                    If DaysAndTime.Wednesday Then

                        DayCounter += 1

                    End If

                    If DaysAndTime.Thursday Then

                        DayCounter += 1

                    End If

                    If DaysAndTime.Friday Then

                        DayCounter += 1

                    End If

                    If DaysAndTime.Saturday Then

                        DayCounter += 1

                    End If

                    If DaysAndTime.Sunday Then

                        DayCounter += 1

                    End If

                    If DayCounter > 1 Then

                        DaysNumber = (DaysNumber * 10) + DayCounter

                    End If

                End If

            End If

            GetDaysNumber = DaysNumber

        End Function
        Public Function SortDays(DaysAndTime1 As AdvantageFramework.DTO.DaysAndTime, DaysAndTime2 As AdvantageFramework.DTO.DaysAndTime) As Integer

            'objects
            Dim SortResult As Integer = 0
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
            Dim Days1Number As Integer = 0
            Dim Days2Number As Integer = 0

            Days1Number = Me.GetDaysNumber(DaysAndTime1)
            Days2Number = Me.GetDaysNumber(DaysAndTime2)

            If Days1Number = Days2Number Then

                SortResult = 0

            ElseIf Days1Number > Days2Number Then

                SortResult = -1

            ElseIf Days1Number < Days2Number Then

                SortResult = 1

            End If

            SortDays = SortResult

        End Function

#End Region

    End Class

End Namespace
