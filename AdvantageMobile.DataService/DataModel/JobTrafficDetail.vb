'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class JobTrafficDetail
    Public Property JobNumber As Integer
    Public Property JobComponentNumber As Short
    Public Property SequenceNumber As Short
    Public Property FunctionCode As String
    Public Property EstimateFunctionCode As String
    Public Property Description As String
    Public Property StartDate As Nullable(Of Date)
    Public Property DueDate As Nullable(Of Date)
    Public Property RevisedDate As Nullable(Of Date)
    Public Property IsDueDateLocked As Nullable(Of Short)
    Public Property CompletedDate As Nullable(Of Date)
    Public Property Order As Nullable(Of Short)
    Public Property Days As Nullable(Of Short)
    Public Property ParentJobTrafficDetailID As String
    Public Property FunctionComments As String
    Public Property DueDateComments As String
    Public Property RevisedDateComments As String
    Public Property Hours As Nullable(Of Decimal)
    Public Property DueTime As String
    Public Property RevisedDueTime As String
    Public Property TaskStatus As String
    Public Property IsMilestone As Nullable(Of Short)
    Public Property TrafficPhaseID As Nullable(Of Integer)
    Public Property ID As Integer
    Public Property TEMP_SEQ As Nullable(Of Short)
    Public Property TRF_ROLE As String
    Public Property HoursAssigned As Nullable(Of Decimal)
    Public Property EmployeeCode As String
    Public Property TempCompleteDate As Nullable(Of Date)
    Public Property PARENT_TASK_SEQ As Nullable(Of Short)
    Public Property GRID_ORDER As Nullable(Of Short)

    Public Overridable Property [Function] As [Function]
    Public Overridable Property JobComponent As JobComponent
    Public Overridable Property JobTrafficDetailEmployee As ICollection(Of JobTrafficDetailEmployee) = New HashSet(Of JobTrafficDetailEmployee)

End Class
