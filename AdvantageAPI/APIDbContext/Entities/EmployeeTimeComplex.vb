Public Class EmployeeTimeComplex

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

	Public Property EmployeeTimeID As Integer
	Public Property EmployeeTimeDetailID As Integer
	Public Property FunctionCategory As String
	Public Property FunctionCategoryDescription As String
	Public Property EmployeeHours As Decimal
	Public Property ClientCode As String
	Public Property DivisionCode As String
	Public Property ProductCode As String
	Public Property JobNumber As Nullable(Of Integer)
	Public Property ClientReference As String
	Public Property JobComponentNumber As Nullable(Of Short)
	Public Property DepartmentTeamCode As String
	Public Property TimeType As String
	Public Property EditFlag As Short
	Public Property MaxSequence As Nullable(Of Short)
	Public Property StartTime As String
	Public Property EndTime As String
	Public Property EmployeeDate As Nullable(Of Date)
	Public Property Comments As String
	Public Property JobDescription As String
	Public Property JobComponentDescription As String
	Public Property ProductCategoryCode As String
	Public Property ClientName As String
	Public Property DivisionName As String
	Public Property ProductDescription As String
	Public Property JobProcessControl As Nullable(Of Integer)
	Public Property NonEditMessage As String
	Public Property IsLockedByProcessControl As Nullable(Of Short)
	Public Property HasStopwatch As Nullable(Of Integer)
	Public Property StopwatchEmployeeTimeID As Nullable(Of Integer)
	Public Property StopwatchEmployeeTimeDetailID As Nullable(Of Integer)
	Public Property CommentsRequired As Nullable(Of Integer)
	Public Property DayIsDenied As Nullable(Of Boolean)
	Public Property DayIsApproved As Nullable(Of Boolean)
	Public Property DayIsPendingApproval As Nullable(Of Boolean)
	Public Property DayPostPeriodClosed As Nullable(Of Boolean)
	Public Property CreateDate As Nullable(Of Date)
	Public Property ClientCommentRequired As Nullable(Of Boolean)
	Public Property TimesheetMissingComments As Nullable(Of Boolean)
	Public Property TaskCode As String

#End Region

#Region " Methods "



#End Region

End Class
