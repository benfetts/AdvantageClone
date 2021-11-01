Namespace Services.Classes

    Public Class Schedule

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            RunAt
            LastRanAt
            Frequency
            ProcessSunday
            ProcessMonday
            ProcessTuesday
            ProcessWednesday
            ProcessThursday
            ProcessFriday
            ProcessSaturday
            RepeatEvery
        End Enum

#End Region

#Region " Variables "

        Private _RunAt As Date = New System.DateTime(2001, 1, 1, 1, 0, 0)
        Private _LastRanAt As Date = New System.DateTime(2001, 1, 1, 1, 0, 0)
        Private _Frequency As String = Nothing
        Private _ProcessSunday As Boolean = False
        Private _ProcessMonday As Boolean = False
        Private _ProcessTuesday As Boolean = False
        Private _ProcessWednesday As Boolean = False
        Private _ProcessThursday As Boolean = False
        Private _ProcessFriday As Boolean = False
        Private _ProcessSaturday As Boolean = False
        Private _RepeatEvery As String = Nothing

#End Region

#Region " Properties "

        Public Property RunAt As Date
            Get
                RunAt = _RunAt
            End Get
            Set(value As Date)
                _RunAt = value
            End Set
        End Property
        Public Property LastRanAt As Date
            Get
                LastRanAt = _LastRanAt
            End Get
            Set(value As Date)
                _LastRanAt = value
            End Set
        End Property
        Public Property Frequency As String
            Get
                Frequency = _Frequency
            End Get
            Set(value As String)
                _Frequency = value
            End Set
        End Property
        Public Property ProcessSunday As Boolean
            Get
                ProcessSunday = _ProcessSunday
            End Get
            Set(value As Boolean)
                _ProcessSunday = value
            End Set
        End Property
        Public Property ProcessMonday As Boolean
            Get
                ProcessMonday = _ProcessMonday
            End Get
            Set(value As Boolean)
                _ProcessMonday = value
            End Set
        End Property
        Public Property ProcessTuesday As Boolean
            Get
                ProcessTuesday = _ProcessTuesday
            End Get
            Set(value As Boolean)
                _ProcessTuesday = value
            End Set
        End Property
        Public Property ProcessWednesday As Boolean
            Get
                ProcessWednesday = _ProcessWednesday
            End Get
            Set(value As Boolean)
                _ProcessWednesday = value
            End Set
        End Property
        Public Property ProcessThursday As Boolean
            Get
                ProcessThursday = _ProcessThursday
            End Get
            Set(value As Boolean)
                _ProcessThursday = value
            End Set
        End Property
        Public Property ProcessFriday As Boolean
            Get
                ProcessFriday = _ProcessFriday
            End Get
            Set(value As Boolean)
                _ProcessFriday = value
            End Set
        End Property
        Public Property ProcessSaturday As Boolean
            Get
                ProcessSaturday = _ProcessSaturday
            End Get
            Set(value As Boolean)
                _ProcessSaturday = value
            End Set
        End Property
        Public Property RepeatEvery As String
            Get
                RepeatEvery = _RepeatEvery
            End Get
            Set(value As String)
                _RepeatEvery = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Function ReadyToRun() As Boolean

            Dim IsReady As Boolean = False

            If Now.TimeOfDay > Me.RunAt.TimeOfDay Then

                If Me.RepeatEvery Is Nothing AndAlso DateDiff(DateInterval.Day, Me.LastRanAt, Now) > 0 Then

                    IsReady = True

                ElseIf Me.RepeatEvery IsNot Nothing Then

                    If DateDiff(DateInterval.Minute, DateAdd(DateInterval.Minute, CInt(Me.RepeatEvery), Me.LastRanAt), Now) > 0 Then

                        IsReady = True

                    End If

                End If

            End If

            ReadyToRun = IsReady

        End Function

#End Region

    End Class

End Namespace
