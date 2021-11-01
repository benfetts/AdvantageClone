Namespace Classes.Media.Nielsen

    Public Class LeadInLeadOutStartEndTime

#Region " Constants "

        Private Const DayStartHour As Integer = 300
        Private Const DayHour As Integer = 2400
        Private Const Multipler As Integer = 100

#End Region

#Region " Enum "

        Public Enum Properties
            StartDateTime
            StartHour
            EndDateTime
            EndHour
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property StartDateTime As Date
        Public ReadOnly Property StartHour As Integer
            Get

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & StartDateTime.ToShortTimeString)) * Multipler + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & StartDateTime.ToShortTimeString)) < DayStartHour Then

                    StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & StartDateTime.ToShortTimeString)) * Multipler + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & StartDateTime.ToShortTimeString)) + DayHour

                Else

                    StartHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & StartDateTime.ToShortTimeString)) * Multipler + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & StartDateTime.ToShortTimeString))

                End If

            End Get
        End Property
        Public Property EndDateTime As Date
        Public ReadOnly Property EndHour As Integer
            Get

                If DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & EndDateTime.ToShortTimeString)) * Multipler + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & EndDateTime.ToShortTimeString)) <= DayStartHour Then

                    EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & EndDateTime.ToShortTimeString)) * Multipler + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & EndDateTime.ToShortTimeString)) + DayHour

                Else

                    EndHour = DatePart(DateInterval.Hour, CDate(Now.ToShortDateString & " " & EndDateTime.ToShortTimeString)) * Multipler + DatePart(DateInterval.Minute, CDate(Now.ToShortDateString & " " & EndDateTime.ToShortTimeString))

                End If

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.StartDateTime = Date.MinValue
            Me.EndDateTime = Date.MinValue

        End Sub

#End Region

    End Class

End Namespace