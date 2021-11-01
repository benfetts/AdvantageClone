Imports System
Imports System.Text
Imports System.Collections.Generic
Imports System.Collections.Specialized

Namespace iCal.Events
    Public Enum PriorityLevel As Integer
        Normal = 5
        High = 1
        Low = 9
    End Enum

    Public Enum METHODS As Integer
        PUBLISH = 1
        CANCEL = 2 'only works for a single non imported item. (Removes the item from the calendar but only one event at a time.
        REQUEST = 3 'Requests an invite Meeting request.

    End Enum

    Public Class cEvent
        Private Const _DATEFORMAT As String = "yyyyMMdd\THHmmss\Z"
        Public Sub New()

        End Sub
        Public StartTime As Date
        Public EndTime As Date
        Public Location As String = String.Empty
        Public Title As String = String.Empty
        Public Description As String = String.Empty
        Public Organizer As String = String.Empty
        Public UseAlarm As Boolean = True
        Public SEQUENCE As String = "0"
        Public Priority As PriorityLevel = Events.PriorityLevel.Normal
        Public Category As String = String.Empty
        Public UID As String = Now.Ticks.ToString
        Public Overrides Function ToString() As String
            Return Output
        End Function


        Public ReadOnly Property Output() As String
            Get
                Dim sb As StringBuilder = New StringBuilder()
                sb.Append("BEGIN:VEVENT" + System.Environment.NewLine)
                'sb.Append("ORGANIZER:")
                'sb.Append(Organizer)
                sb.Append("DTSTART:")
                sb.Append(StartTime.ToUniversalTime().ToString(_DATEFORMAT))
                sb.Append(System.Environment.NewLine + "DTEND:")
                sb.Append(EndTime.ToUniversalTime().ToString(_DATEFORMAT))

                '/change this so that we have a unique id from the database for each calendar item. danr	
                'sb.AppendFormat("UID:RFCALITEM{0}\n", DateTime.Now.Ticks)
                sb.Append(System.Environment.NewLine + "LOCATION:")
                sb.Append(Location)

                sb.Append(System.Environment.NewLine + "CATEGORIES:")
                sb.Append(Category)

                sb.Append(System.Environment.NewLine + "TRANSP:OPAQUE" + System.Environment.NewLine)
                sb.AppendFormat("SEQUENCE:{0}" + System.Environment.NewLine, SEQUENCE)
                sb.AppendFormat("UID:{0}" + System.Environment.NewLine, UID)
                sb.Append("DTSTAMP:")
                sb.Append(StartTime.ToUniversalTime().ToString(_DATEFORMAT))
                sb.Append(System.Environment.NewLine + "DESCRIPTION;ENCODING=QUOTED-PRINTABLE:")
                If Not String.IsNullOrEmpty(Description) = True Then
                    sb.Append(Description.Replace("\r\n", "=0D=0A"))
                    'sb.Append(Description.Replace("\r\n", vbCrLf))
                Else
                    sb.Append(Description)
                End If
                sb.Append(System.Environment.NewLine + "SUMMARY:")
                sb.Append(Title)
                sb.Append(System.Environment.NewLine + "PRIORITY:")
                sb.Append(CInt(Priority))
                sb.Append(System.Environment.NewLine + "CLASS:PUBLIC" + System.Environment.NewLine)
                If Not Me.StartTime < Now Then
                    If UseAlarm = True Then
                        sb.Append("BEGIN:VALARM" + System.Environment.NewLine)
                        If Mid(UID, 1, 1).Contains("T") Then
                            sb.Append("TRIGGER:PT1080M" + System.Environment.NewLine)
                        Else

                            If StartTime.ToLongTimeString.ToString.Contains("12:00:00 AM") And EndTime.ToLongTimeString.ToString.Contains("11:59:00 PM") Then
                                sb.Append("TRIGGER:PT1080M" + System.Environment.NewLine)
                            Else
                                sb.Append("TRIGGER:PT15M" + System.Environment.NewLine)
                            End If


                        End If
                            sb.Append("ACTION:DISPLAY" + System.Environment.NewLine)
                            sb.Append("DESCRIPTION:Reminder" + System.Environment.NewLine)
                            sb.Append("PRIORITY:5" + System.Environment.NewLine)
                            sb.Append("END:VALARM" + System.Environment.NewLine)
                    End If
                    End If
                    sb.Append("END:VEVENT" + System.Environment.NewLine)
                    Return sb.ToString()
            End Get
        End Property

    End Class
    Public Class cICalendar

        Public cEvents As List(Of cEvent)
        Public METHOD As METHODS = METHODS.PUBLISH
        'Public Sub cICalendar()
        '    Me.cEvents = New List(Of cEvent)
        'End Sub
        Public Sub New()
            Me.cEvents = New List(Of cEvent)
        End Sub
        Public Overrides Function ToString() As String
            Return Output
        End Function

        Public ReadOnly Property Output() As String
            Get
                Dim sb As StringBuilder = New StringBuilder
                sb.Append("BEGIN:VCALENDAR" + System.Environment.NewLine)
                sb.Append("PRODID:-//GoToAdvantage.Com//iCalendar MIMEDIR//EN" + System.Environment.NewLine)
                sb.Append("VERSION:2.0" + System.Environment.NewLine)
                Dim sMethod As String
                Select Case METHOD
                    Case 1
                        sMethod = "PUBLISH"
                    Case 2
                        sMethod = "CANCEL"
                    Case 3
                        sMethod = "REQUEST"

                    Case Else
                        sMethod = "PUBLISH"
                End Select

                sb.Append("METHOD:" + sMethod + System.Environment.NewLine)
                For Each ev As cEvent In cEvents
                    sb.Append(ev.Output)
                Next ev

                sb.Append("END:VCALENDAR")

                Return sb.ToString()
            End Get
        End Property
    End Class

End Namespace
