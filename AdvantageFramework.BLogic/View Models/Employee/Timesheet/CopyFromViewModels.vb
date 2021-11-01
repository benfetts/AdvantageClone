Namespace ViewModels.Employee.Timesheet.CopyFrom

    <Serializable()>
    Public Class MyProject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ClientCode As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property FunctionCategory As String = String.Empty
        Public Property JobWithDescription As String = String.Empty
        Public Property JobComponentWithDescription As String = String.Empty
        Public Property JobNumber As Integer? = 0
        Public Property JobComponentNumber As Short? = 0
        Public Property JobDescription As String = String.Empty
        Public Property JobComponentDescription As String = String.Empty
        Public Property TaskSequenceNumber As Short? = -1
        Public Property TaskDescription As String = String.Empty
        Public Property IsFunctionInactive As Boolean? = False
        Public Property DueDate As Date? = Nothing
        Public Property HoursAllowed As Decimal? = 0.00
        Public Property AlertID As Integer? = 0
        Public Property AlertSubject As String = String.Empty
        Public ReadOnly Property JobAndComponentNumbers As String
            Get
                Dim s As String = String.Empty
                If JobNumber Is Nothing Then JobNumber = 0
                If JobComponentNumber Is Nothing Then JobComponentNumber = 0
                s = JobNumber.ToString.PadLeft(6, "0") & "/" & JobComponentNumber.ToString.PadLeft(3, "0")
                Return s
            End Get
        End Property

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

    '    <Serializable()>
    '    Public Class MyCalendarItem

    '#Region " Constants "



    '#End Region

    '#Region " Enum "



    '#End Region

    '#Region " Variables "



    '#End Region

    '#Region " Properties "

    '        Public Property ID As Nullable(Of Integer) = 0
    '        Public Property StartDate As Nullable(Of Date) = Nothing
    '        Public Property EndDate As Nullable(Of Date) = Nothing
    '        Public Property StartTime As Nullable(Of Date) = Nothing
    '        Public Property EndTime As Nullable(Of Date) = Nothing
    '        Public Property Hours As Nullable(Of Decimal) = 0
    '        Public Property EmployeeCode As String = String.Empty
    '        Public Property OutlookID As String = String.Empty
    '        Public Property GoogleID As String = String.Empty
    '        Public Property CalendarID As String = String.Empty
    '        Public Property Comments As String = String.Empty
    '        Public Property ClientCode As String = String.Empty
    '        Public Property DivisionCode As String = String.Empty
    '        Public Property ProductCode As String = String.Empty
    '        Public Property JobNumber As Nullable(Of Integer) = 0
    '        Public Property JobComponentNumber As Nullable(Of Short) = 0
    '        Public Property FunctionCode As String = String.Empty
    '        Public Property DepartmentCode As String = String.Empty
    '        Public Property DepartmentName As String = String.Empty
    '        Public Property ProductCategoryCode As String = String.Empty


    '#End Region

    '#Region " Methods "



    '#End Region

    '    End Class

    <Serializable()>
    Public Class MyTemplate

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
