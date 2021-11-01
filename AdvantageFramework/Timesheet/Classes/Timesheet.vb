Namespace Timesheet

    <Serializable()> Public Class TimeSheet
        Inherits CollectionBase

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private _EmpCode As String
        Private _EmpName As String
        Private _StartDate As Date
        Private _EndDate As Date

        Public Property Days As New List(Of _TimesheetDay)

        Public IsMissingComments As Boolean = False

        Public Property EmpCode() As String
            Get
                Return _EmpCode
            End Get
            Set(ByVal Value As String)
                _EmpCode = Value
            End Set
        End Property
        Public Property EmpName() As String
            Get
                Return _EmpName
            End Get
            Set(ByVal Value As String)
                _EmpName = Value
            End Set
        End Property
        Public Property StartDate() As Date
            Get
                Return _StartDate
            End Get
            Set(ByVal Value As Date)
                _StartDate = Value
            End Set
        End Property
        Public Property EndDate() As Date
            Get
                Return _EndDate
            End Get
            Set(ByVal Value As Date)
                _EndDate = Value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Function GetTotalHoursByDay(ByVal pDayofWeek As DayOfWeek) As Double
            Dim ThisLine As TimesheetLine
            Dim MyReturn As Double = CType(0, Double)

            For Each ThisLine In Me
                Select Case pDayofWeek
                    Case DayOfWeek.Monday
                        If Not ThisLine.Monday Is Nothing Then
                            MyReturn += ThisLine.Monday.Hours
                        End If
                    Case DayOfWeek.Tuesday
                        If Not ThisLine.Tuesday Is Nothing Then
                            MyReturn += ThisLine.Tuesday.Hours
                        End If
                    Case DayOfWeek.Wednesday
                        If Not ThisLine.Wednesday Is Nothing Then
                            MyReturn += ThisLine.Wednesday.Hours
                        End If
                    Case DayOfWeek.Thursday
                        If Not ThisLine.Thursday Is Nothing Then
                            MyReturn += ThisLine.Thursday.Hours
                        End If
                    Case DayOfWeek.Friday
                        If Not ThisLine.Friday Is Nothing Then
                            MyReturn += ThisLine.Friday.Hours
                        End If
                    Case DayOfWeek.Saturday
                        If Not ThisLine.Saturday Is Nothing Then
                            MyReturn += ThisLine.Saturday.Hours
                        End If
                    Case DayOfWeek.Sunday
                        If Not ThisLine.Sunday Is Nothing Then
                            MyReturn += ThisLine.Sunday.Hours
                        End If
                End Select
            Next

            Return MyReturn

        End Function
        Public Function GetTotalHours() As Double
            Dim myReturn As Double

            myReturn += GetTotalHoursByDay(DayOfWeek.Monday)
            myReturn += GetTotalHoursByDay(DayOfWeek.Tuesday)
            myReturn += GetTotalHoursByDay(DayOfWeek.Wednesday)
            myReturn += GetTotalHoursByDay(DayOfWeek.Thursday)
            myReturn += GetTotalHoursByDay(DayOfWeek.Friday)
            myReturn += GetTotalHoursByDay(DayOfWeek.Saturday)
            myReturn += GetTotalHoursByDay(DayOfWeek.Sunday)

            Return myReturn

        End Function

#Region "Collection Code"

        Default Public Property Item(ByVal index As Integer) As TimesheetLine
            Get
                Return CType(List(index), TimesheetLine)
            End Get
            Set(ByVal Value As TimesheetLine)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As TimesheetLine) As Integer
            Return List.Add(value)
        End Function
        Public Function IndexOf(ByVal value As TimesheetLine) As Integer
            Return List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As TimesheetLine)
            List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As TimesheetLine)
            List.Remove(value)
        End Sub
        Public Function Contains(ByVal value As TimesheetLine) As Boolean
            Return List.Contains(value)
        End Function

#End Region

#End Region

    End Class

End Namespace