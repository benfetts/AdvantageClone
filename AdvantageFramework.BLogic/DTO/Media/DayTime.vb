Namespace DTO.Media

    Public Class DayTime
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Days
            StartTime
            EndTime
        End Enum

#End Region

#Region " Variables "

		Private _StartTime As Date = Date.MinValue
		Private _EndTime As Date = Date.MinValue

#End Region

#Region " Properties "

		<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <Required>
        <MaxLength(11)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Days() As String

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartTime() As DateTime
            Get
                StartTime = _StartTime
            End Get
            Set(value As DateTime)
                _StartTime = value
            End Set
        End Property
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndTime() As DateTime
            Get
                EndTime = _EndTime
            End Get
            Set(value As DateTime)
                _EndTime = value
            End Set
        End Property

#End Region

#Region " Methods "

		Public Sub New()

			_StartTime = DateSerial(2000, 1, 1)
			_EndTime = DateSerial(2000, 1, 1)

		End Sub
		Public Sub New(MediaSpotTVResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVResearchDayTime)

            'objects
            Dim Days As String = String.Empty

            Me.ID = MediaSpotTVResearchDayTime.ID

            If MediaSpotTVResearchDayTime.Monday Then

                Days += "M"

            End If

            If MediaSpotTVResearchDayTime.Tuesday Then

                Days += "Tu"

            End If

            If MediaSpotTVResearchDayTime.Wednesday Then

                Days += "W"

            End If

            If MediaSpotTVResearchDayTime.Thursday Then

                Days += "Th"

            End If

            If MediaSpotTVResearchDayTime.Friday Then

                Days += "F"

            End If

            If MediaSpotTVResearchDayTime.Saturday Then

                Days += "Sa"

            End If

            If MediaSpotTVResearchDayTime.Sunday Then

                Days += "Su"

            End If

            Me.Days = Days

            Me.StartTime = MediaSpotTVResearchDayTime.StartTime
            Me.EndTime = MediaSpotTVResearchDayTime.EndTime

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotTVResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVResearchDayTime)

            'objects
            Dim DashPos As Integer = 0
            Dim DayStart As String = Nothing
            Dim DayEnd As String = Nothing
            Dim NewStartTime As Date = Nothing

            MediaSpotTVResearchDayTime.Monday = False
            MediaSpotTVResearchDayTime.Tuesday = False
            MediaSpotTVResearchDayTime.Wednesday = False
            MediaSpotTVResearchDayTime.Thursday = False
            MediaSpotTVResearchDayTime.Friday = False
            MediaSpotTVResearchDayTime.Saturday = False
            MediaSpotTVResearchDayTime.Sunday = False

            If Not String.IsNullOrWhiteSpace(Me.Days) Then

                Me.Days = Replace(Me.Days.ToUpper.Trim, " ", "")

                DashPos = InStr(Me.Days, "-")

                If DashPos >= 1 Then

                    DayStart = Left(Me.Days, DashPos - 1)
                    DayEnd = Mid(Me.Days, DashPos + 1)

                    SetDays(DayStart, DayEnd, MediaSpotTVResearchDayTime)

                ElseIf DashPos = 0 Then

                    MediaSpotTVResearchDayTime.Monday = If(String.IsNullOrWhiteSpace(Me.Days), False, Me.Days.ToUpper.Contains("M"))
                    MediaSpotTVResearchDayTime.Tuesday = If(String.IsNullOrWhiteSpace(Me.Days), False, Me.Days.ToUpper.Contains("TU"))
                    MediaSpotTVResearchDayTime.Wednesday = If(String.IsNullOrWhiteSpace(Me.Days), False, Me.Days.ToUpper.Contains("W"))
                    MediaSpotTVResearchDayTime.Thursday = If(String.IsNullOrWhiteSpace(Me.Days), False, Me.Days.ToUpper.Contains("TH"))
                    MediaSpotTVResearchDayTime.Friday = If(String.IsNullOrWhiteSpace(Me.Days), False, Me.Days.ToUpper.Contains("F"))
                    MediaSpotTVResearchDayTime.Saturday = If(String.IsNullOrWhiteSpace(Me.Days), False, Me.Days.ToUpper.Contains("SA"))
                    MediaSpotTVResearchDayTime.Sunday = If(String.IsNullOrWhiteSpace(Me.Days), False, Me.Days.ToUpper.Contains("SU"))

                End If

            End If

            MediaSpotTVResearchDayTime.StartTime = Me.StartTime
            MediaSpotTVResearchDayTime.EndTime = Me.EndTime

            If DatePart(DateInterval.Minute, MediaSpotTVResearchDayTime.StartTime) Mod 15 = 0 Then

                If DatePart(DateInterval.Hour, MediaSpotTVResearchDayTime.StartTime) * 100 + DatePart(DateInterval.Minute, MediaSpotTVResearchDayTime.StartTime) < 300 Then

                    MediaSpotTVResearchDayTime.StartHour = DatePart(DateInterval.Hour, MediaSpotTVResearchDayTime.StartTime) * 100 + DatePart(DateInterval.Minute, MediaSpotTVResearchDayTime.StartTime) + 2400

                Else

                    MediaSpotTVResearchDayTime.StartHour = DatePart(DateInterval.Hour, MediaSpotTVResearchDayTime.StartTime) * 100 + DatePart(DateInterval.Minute, MediaSpotTVResearchDayTime.StartTime)

                End If

            Else

                NewStartTime = DateAdd(DateInterval.Minute, -(DatePart(DateInterval.Minute, MediaSpotTVResearchDayTime.StartTime) Mod 15), MediaSpotTVResearchDayTime.StartTime)

                MediaSpotTVResearchDayTime.StartHour = DatePart(DateInterval.Hour, NewStartTime) * 100 + DatePart(DateInterval.Minute, NewStartTime)

            End If

            If DatePart(DateInterval.Hour, MediaSpotTVResearchDayTime.EndTime) * 100 + DatePart(DateInterval.Minute, MediaSpotTVResearchDayTime.EndTime) < 300 Then

                MediaSpotTVResearchDayTime.EndHour = DatePart(DateInterval.Hour, MediaSpotTVResearchDayTime.EndTime) * 100 + DatePart(DateInterval.Minute, MediaSpotTVResearchDayTime.EndTime) + 2400

            Else

                MediaSpotTVResearchDayTime.EndHour = DatePart(DateInterval.Hour, MediaSpotTVResearchDayTime.EndTime) * 100 + DatePart(DateInterval.Minute, MediaSpotTVResearchDayTime.EndTime)

            End If

            MediaSpotTVResearchDayTime.Days = If(String.IsNullOrWhiteSpace(Me.Days), Nothing, Me.Days.ToUpper)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Private Sub SetDays(DayStart As String, DayEnd As String, ByRef MediaSpotTVResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVResearchDayTime)

            Select Case DayStart

                Case "M"

                    MediaSpotTVResearchDayTime.Monday = True

                    If DayEnd = "TU" Then

                        MediaSpotTVResearchDayTime.Tuesday = True

                    ElseIf DayEnd = "W" Then

                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True

                    ElseIf DayEnd = "TH" Then

                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True

                    ElseIf DayEnd = "F" Then

                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True

                    ElseIf DayEnd = "SA" Then

                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True

                    ElseIf DayEnd = "SU" Then

                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True

                    End If

                Case "TU"

                    MediaSpotTVResearchDayTime.Tuesday = True

                    If DayEnd = "W" Then

                        MediaSpotTVResearchDayTime.Wednesday = True

                    ElseIf DayEnd = "TH" Then

                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True

                    ElseIf DayEnd = "F" Then

                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True

                    ElseIf DayEnd = "SA" Then

                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True

                    ElseIf DayEnd = "SU" Then

                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True

                    ElseIf DayEnd = "M" Then

                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True

                    End If

                Case "W"

                    MediaSpotTVResearchDayTime.Wednesday = True

                    If DayEnd = "TH" Then

                        MediaSpotTVResearchDayTime.Thursday = True

                    ElseIf DayEnd = "F" Then

                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True

                    ElseIf DayEnd = "SA" Then

                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True

                    ElseIf DayEnd = "SU" Then

                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True

                    ElseIf DayEnd = "M" Then

                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True

                    ElseIf DayEnd = "TU" Then

                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True

                    End If

                Case "TH"

                    MediaSpotTVResearchDayTime.Thursday = True

                    If DayEnd = "F" Then

                        MediaSpotTVResearchDayTime.Friday = True

                    ElseIf DayEnd = "SA" Then

                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True

                    ElseIf DayEnd = "SU" Then

                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True

                    ElseIf DayEnd = "M" Then

                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True

                    ElseIf DayEnd = "TU" Then

                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True

                    ElseIf DayEnd = "W" Then

                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True

                    End If

                Case "F"

                    MediaSpotTVResearchDayTime.Friday = True

                    If DayEnd = "SA" Then

                        MediaSpotTVResearchDayTime.Saturday = True

                    ElseIf DayEnd = "SU" Then

                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True

                    ElseIf DayEnd = "M" Then

                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True

                    ElseIf DayEnd = "TU" Then

                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True

                    ElseIf DayEnd = "W" Then

                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True

                    ElseIf DayEnd = "TH" Then

                        MediaSpotTVResearchDayTime.Saturday = True
                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True

                    End If

                Case "SA"

                    MediaSpotTVResearchDayTime.Saturday = True

                    If DayEnd = "SU" Then

                        MediaSpotTVResearchDayTime.Sunday = True

                    ElseIf DayEnd = "M" Then

                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True

                    ElseIf DayEnd = "TU" Then

                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True

                    ElseIf DayEnd = "W" Then

                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True

                    ElseIf DayEnd = "TH" Then

                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True

                    ElseIf DayEnd = "F" Then

                        MediaSpotTVResearchDayTime.Sunday = True
                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True

                    End If

                Case "SU"

                    MediaSpotTVResearchDayTime.Sunday = True

                    If DayEnd = "M" Then

                        MediaSpotTVResearchDayTime.Monday = True

                    ElseIf DayEnd = "TU" Then

                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True

                    ElseIf DayEnd = "W" Then

                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True

                    ElseIf DayEnd = "TH" Then

                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True

                    ElseIf DayEnd = "F" Then

                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True

                    ElseIf DayEnd = "SA" Then

                        MediaSpotTVResearchDayTime.Monday = True
                        MediaSpotTVResearchDayTime.Tuesday = True
                        MediaSpotTVResearchDayTime.Wednesday = True
                        MediaSpotTVResearchDayTime.Thursday = True
                        MediaSpotTVResearchDayTime.Friday = True
                        MediaSpotTVResearchDayTime.Saturday = True

                    End If

            End Select

        End Sub

#End Region

    End Class

End Namespace
