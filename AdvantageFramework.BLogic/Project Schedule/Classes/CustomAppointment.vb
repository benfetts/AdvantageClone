Namespace ProjectSchedule.Classes

    Public Class CustomAppointment

#Region " Const "



#End Region

#Region "  Enum "

        Public Enum Properties
            ID
            Type
            StartDate
            EndDate
            AllDay
            Subject
            Location
            Description
            Status
            Label
            ResourceID
            ResourceIDs
            ReminderInfo
            RecurrenceInfo
            PercentComplete
            CustomField1
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _Type As Integer = Nothing
        Private _StartDate As DateTime = Nothing
        Private _EndDate As DateTime = Nothing
        Private _AllDay As Boolean = Nothing
        Private _Subject As String = Nothing
        Private _Location As String = Nothing
        Private _Description As String = Nothing
        Private _Status As Integer = Nothing
        Private _Label As Integer = Nothing
        Private _ResourceID As Integer = Nothing
        Private _ResourceIDs As String = Nothing
        Private _ReminderInfo As String = Nothing
        Private _RecurrenceInfo As String = Nothing
        Private _PercentComplete As Integer = Nothing
        Private _CustomField1 As Object = Nothing

#End Region

#Region "  Properties "

        Public Property ID As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = _ID
            End Set
        End Property
        Public Property Type As Integer
            Get
                Type = _Type
            End Get
            Set(value As Integer)
                _Type = value
            End Set
        End Property
        Public Property StartDate As DateTime
            Get
                StartDate = _StartDate
            End Get
            Set(value As DateTime)
                _StartDate = value
            End Set
        End Property
        Public Property EndDate As DateTime
            Get
                EndDate = _EndDate
            End Get
            Set(value As DateTime)
                _EndDate = value
            End Set
        End Property
        Public Property AllDay As Boolean
            Get
                AllDay = _AllDay
            End Get
            Set(value As Boolean)
                _AllDay = value
            End Set
        End Property
        Public Property Subject As String
            Get
                Subject = _Subject
            End Get
            Set(value As String)
                _Subject = value
            End Set
        End Property
        Public Property Location As String
            Get
                Location = _Location
            End Get
            Set(value As String)
                _Location = value
            End Set
        End Property
        Public Property Description As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        Public Property Status As Integer
            Get
                Status = _Status
            End Get
            Set(value As Integer)
                _Status = value
            End Set
        End Property
        Public Property Label As Integer
            Get
                Label = _Label
            End Get
            Set(value As Integer)
                _Label = value
            End Set
        End Property
        Public Property ResourceID As Integer
            Get
                ResourceID = _ResourceID
            End Get
            Set(value As Integer)
                _ResourceID = value
            End Set
        End Property
        Public Property ResourceIDs As String
            Get
                ResourceIDs = _ResourceIDs
            End Get
            Set(value As String)
                _ResourceIDs = value
            End Set
        End Property
        Public Property ReminderInfo As String
            Get
                ReminderInfo = _ReminderInfo
            End Get
            Set(value As String)
                _ReminderInfo = value
            End Set
        End Property
        Public Property RecurrenceInfo As String
            Get
                RecurrenceInfo = _RecurrenceInfo
            End Get
            Set(value As String)
                _RecurrenceInfo = value
            End Set
        End Property
        Public Property PercentComplete As Integer
            Get
                PercentComplete = _PercentComplete
            End Get
            Set(value As Integer)
                _PercentComplete = value
            End Set
        End Property
        Public Property CustomField1 As Object
            Get
                CustomField1 = _CustomField1
            End Get
            Set(value As Object)
                _CustomField1 = value
            End Set
        End Property

#End Region

#Region "  Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace

