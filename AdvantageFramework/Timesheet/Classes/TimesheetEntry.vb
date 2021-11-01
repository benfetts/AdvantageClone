Namespace Timesheet

    <Serializable()> Public Class TimesheetEntry

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ETID As Integer = 0
        Private _ETDTLID As Integer = 0
        Private _Hours As Double = CType(0, Double)
        Private _tDate As Date = Nothing
        Private _Comments As String = ""
        Private _EditFlag As TimesheetEditType = TimesheetEditType.Edit
        Private _TimeType As String = ""
        Private _CannotEditDueToProcessingControl As Boolean = False
        Private _HasStopwatch As Boolean = False
        Private _WebDataKey As String = ""
        Private _CommentsRequired As Boolean = False
        Private _CanDelete As Boolean = False
        Private _AlertID As Integer = 0
        Private _AlertSubject As String

#End Region

#Region " Properties "

        Public Property AlertSubject() As String
            Get
                Return _AlertSubject
            End Get
            Set(ByVal Value As String)
                _AlertSubject = Value
            End Set
        End Property
        Public Property ETID() As Integer
            Get
                Return _ETID
            End Get
            Set(ByVal Value As Integer)
                _ETID = Value
            End Set
        End Property
        Public Property ETDTLID() As Integer
            Get
                Return _ETDTLID
            End Get
            Set(ByVal Value As Integer)
                _ETDTLID = Value
            End Set
        End Property
        Public Property Hours() As Double
            Get
                Return _Hours
            End Get
            Set(ByVal Value As Double)
                _Hours = Value
            End Set
        End Property
        Public Property tDate() As Date
            Get
                Return _tDate
            End Get
            Set(ByVal Value As Date)
                _tDate = Value
            End Set
        End Property
        Public Property Comments() As String
            Get
                Return _Comments
            End Get
            Set(ByVal Value As String)
                _Comments = Value
            End Set
        End Property
        Public Property EditFlag() As TimesheetEditType
            Get
                Return _EditFlag
            End Get
            Set(ByVal Value As TimesheetEditType)
                _EditFlag = Value
            End Set
        End Property
        Public Property TimeType() As String
            Get
                Return _TimeType
            End Get
            Set(ByVal Value As String)
                _TimeType = Value
            End Set
        End Property
        Public Property HasStopwatch() As Boolean
            Get
                Return _HasStopwatch
            End Get
            Set(value As Boolean)
                _HasStopwatch = value
            End Set
        End Property
        Public Property CannotEditDueToProcessingControl() As Boolean
            Get
                Return _CannotEditDueToProcessingControl
            End Get
            Set(value As Boolean)
                _CannotEditDueToProcessingControl = value
            End Set
        End Property
        Public Property WebDataKey() As String
            Get
                Return _WebDataKey
            End Get
            Set(ByVal Value As String)
                _WebDataKey = Value
            End Set
        End Property
        Public Property CommentsRequired() As Boolean
            Get
                Return _CommentsRequired
            End Get
            Set(value As Boolean)
                _CommentsRequired = value
            End Set
        End Property
        Public Property CanDelete() As Boolean
            Get
                Return _CanDelete
            End Get
            Set(value As Boolean)
                _CanDelete = value
            End Set
        End Property
        Public Property AlertID() As Integer
            Get
                Return _AlertID
            End Get
            Set(ByVal Value As Integer)
                _AlertID = Value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
