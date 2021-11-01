Namespace DTO.Employee

    Public Class Timesheet

        Public Property StartDate As Date
        Public Property EmployeeCode As String
        Public Property Rows As Generic.List(Of Row)
        Public Property UserSettings As Settings

        Public Sub New()

            Me.Rows = New List(Of Row)
            Me.UserSettings = New Settings

        End Sub

#Region " Classes "

        Public Class Settings

            Public Property DaysToDisplay As Integer
            Public Property StartTimesheetOnDayOfWeek As Short
            Public Property ShowCommentsUsing As String
            Public Property DivisionLabel As String
            Public Property ProductLabel As String
            Public Property ProductCategoryLabel As String
            Public Property JobLabel As String
            Public Property JobComponentLabel As String
            Public Property FunctionCategoryLabel As String

        End Class
        Public Class Row

            Public Property RowID As Integer
            Public Property ClientCode As String
            Public Property ClientName As String
            Public Property DivisionCode As String
            Public Property DivisionName As String
            Public Property ProductCode As String
            Public Property ProductName As String
            Public Property JobNumber As Integer?
            Public Property JobDescription As String
            Public Property JobComponentNumber As Short?
            Public Property JobComponentDescription As String
            Public Property FunctionCode As String
            Public Property FunctionDescription As String
            Public Property DepartmentTeamCode As String
            Public Property DepartmentTeamDescription As String
            Public Property AlertID As Integer?
            Public Property AlertSubject As String
            Public Property Day1Date As Date?
            Public Property Day1ID As Integer?
            Public Property Day1DetailID As Short?
            Public Property Day1SequenceNumber As Short?
            Public Property Day1Hours As Decimal?
            Public Property Day2Date As Date?
            Public Property Day2ID As Integer?
            Public Property Day2DetailID As Short?
            Public Property Day2SequenceNumber As Short?
            Public Property Day2Hours As Decimal?
            Public Property Day3Date As Date?
            Public Property Day3ID As Integer?
            Public Property Day3DetailID As Short?
            Public Property Day3SequenceNumber As Short?
            Public Property Day3Hours As Decimal?
            Public Property Day4Date As Date?
            Public Property Day4ID As Integer?
            Public Property Day4DetailID As Short?
            Public Property Day4SequenceNumber As Short?
            Public Property Day4Hours As Decimal?
            Public Property Day5Date As Date?
            Public Property Day5ID As Integer?
            Public Property Day5DetailID As Short?
            Public Property Day5SequenceNumber As Short?
            Public Property Day5Hours As Decimal?
            Public Property Day6Date As Date?
            Public Property Day6ID As Integer?
            Public Property Day6DetailID As Short?
            Public Property Day6SequenceNumber As Short?
            Public Property Day6Hours As Decimal?
            Public Property Day7Date As Date?
            Public Property Day7ID As Integer?
            Public Property Day7DetailID As Short?
            Public Property Day7SequenceNumber As Short?
            Public Property Day7Hours As Decimal?

            Public Sub New()

            End Sub

        End Class
        Public Class Entry

            Public Property EmployeeTimeID As Integer
            Public Property EmployeeTimeDetailID As Short
            Public Property FunctionCode As String
            Public Property CategoryCode As String
            Public Property DepartmentTeamCode As String
            Public Property EmployeeCode As String
            Public Property [Date] As Date?
            Public Property Hours As Decimal?
            Public Property Comment As String

            Sub New()

            End Sub

        End Class

#End Region

    End Class

End Namespace

