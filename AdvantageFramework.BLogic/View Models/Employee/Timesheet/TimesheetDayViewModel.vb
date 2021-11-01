Imports AdvantageFramework.Timesheet.Methods

Namespace ViewModels.Employee.Timesheet

    <Serializable()>
    Public Class TimesheetDayViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            [Date]
            HasStopwatch
            IsDenied
            IsApproved
            IsPendingApproval
            PostPeriodIsClosed
            CanEdit
            DailyHours
            PercentCompletedOfDailyHours
            Status
            TotalHours
            StatusText

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property [Date] As Date
        Public Property HasStopwatch As Boolean? = False
        Public Property IsDenied As Boolean? = False
        Public Property IsApproved As Boolean? = False
        Public Property IsPendingApproval As Boolean? = False
        Public Property PostPeriodIsClosed As Boolean? = False
        Public Property CanEdit As Boolean? = False
        Public Property DailyHours As Decimal? = 0.00
        Public Property PercentCompletedOfDailyHours As Decimal? = 0.00
        Public Property Status As TimesheetApprovalType? = TimesheetApprovalType.AllTime
        Public Property Entries As Generic.List(Of ViewModels.Employee.Timesheet.TimesheetEntryViewModel) = Nothing
        Public ReadOnly Property TotalHours As Decimal
            Get
                If Entries Is Nothing Then

                    Return 0.00

                Else

                    Return (From Entity In Entries
                            Select Entity.Hours).Sum

                End If
            End Get
        End Property
        Public ReadOnly Property StatusText As String
            Get
                If Me.Status IsNot Nothing Then

                    Select Case Me.Status
                        Case TimesheetApprovalType.NotSubmitted

                            StatusText = "Not Submitted"

                        Case TimesheetApprovalType.AllTime

                            StatusText = "All Time"

                        Case TimesheetApprovalType.ReadyToSubmit, TimesheetApprovalType.DoesNotExist

                            StatusText = "Missing"

                        Case TimesheetApprovalType.Pending

                            StatusText = "Pending Approval"

                        Case Else

                            StatusText = [Enum].GetName(GetType(TimesheetApprovalType), CType(Me.Status, Integer))

                    End Select

                Else

                    Me.Status = TimesheetApprovalType.AllTime
                    StatusText = "All Time"

                End If
            End Get
        End Property

#End Region

#Region " Methods "
        Sub New()

            Me.Entries = New List(Of TimesheetEntryViewModel)

        End Sub

#End Region

    End Class

End Namespace
