Namespace Timesheet

    <Serializable()> Public Class _TimesheetDay
        Inherits CollectionBase

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Date As Date = Nothing
        Private _TotalHours As Decimal = CType(0, Decimal)
        Private _HasStopwatch As Boolean = False
        Private _Status As TimesheetApprovalType = TimesheetApprovalType.ReadyToSubmit

#End Region

#Region " Properties "

        Public Property TotalHours() As Decimal
            Get
                Return _TotalHours
            End Get
            Set(ByVal Value As Decimal)
                _TotalHours = Value
            End Set
        End Property
        Public Property [Date]() As Date
            Get
                Return _Date
            End Get
            Set(ByVal Value As Date)
                _Date = Value
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

        Public Property IsDenied() As Boolean = False
        Public Property IsApproved() As Boolean = False
        Public Property IsPendingApproval() As Boolean = False
        Public Property PostPeriodIsClosed() As Boolean = False
        Public Property CanEdit() As Boolean = False

        Public Property DailyHours As Decimal = 0.0
        Public Property PercentCompletedOfDailyHours As Decimal = 0.0

        Public Property Status As TimesheetApprovalType
            Get
                Return _Status
            End Get
            Set(value As TimesheetApprovalType)
                _Status = value
                Select Case value
                    Case TimesheetApprovalType.NotSubmitted
                        StatusText = "Not Submitted"
                    Case TimesheetApprovalType.AllTime
                        StatusText = "All Time" '?
                    Case TimesheetApprovalType.ReadyToSubmit, TimesheetApprovalType.DoesNotExist
                        StatusText = "Missing"
                    Case TimesheetApprovalType.Pending
                        StatusText = "Pending Approval"
                    Case Else
                        StatusText = [Enum].GetName(GetType(TimesheetApprovalType), CType(value, Integer))
                End Select
            End Set
        End Property
        Public Property StatusText As String = ""

#End Region

#Region " Methods "

#Region "Collection Code"

        Default Public Property Item(ByVal index As Integer) As TimesheetEntry
            Get
                Return CType(List(index), TimesheetEntry)
            End Get
            Set(ByVal Value As TimesheetEntry)
                List(index) = Value
            End Set
        End Property
        Public Function Add(ByVal value As TimesheetEntry) As Integer
            Return List.Add(value)
        End Function
        Public Function IndexOf(ByVal value As TimesheetEntry) As Integer
            Return List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As TimesheetEntry)
            List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As TimesheetEntry)
            List.Remove(value)
        End Sub
        Public Function Contains(ByVal value As TimesheetEntry) As Boolean
            Return List.Contains(value)
        End Function

#End Region

#End Region

    End Class

End Namespace
