<DataContract>
Public Class EmployeeTimeRecord

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property EmployeeTimeID As Integer
    <DataMember>
    Public Property EmployeeTimeDetailID As Integer
    <DataMember>
    Public Property ClientCode As String
    <DataMember>
    Public Property ClientName As String
    <DataMember>
    Public Property DivisionCode As String
    <DataMember>
    Public Property DivisionName As String
    <DataMember>
    Public Property ProductCode As String
    <DataMember>
    Public Property ProductDescription As String
    <DataMember>
    Public Property JobNumber As Integer
    <DataMember>
    Public Property JobDescription As String
    <DataMember>
    Public Property JobComponentNumber As Short
    <DataMember>
    Public Property JobComponentDescription As String
    <DataMember>
    Public Property FunctionCategory As String
    <DataMember>
    Public Property FunctionCategoryDescription As String
    <DataMember>
    Public Property [Date] As Date
    <DataMember>
    Public Property Hours As Decimal
    <DataMember>
    Public Property DepartmentTeamCode As String
    <DataMember>
    Public Property Comments As String
    <DataMember>
    Public Property TaskCode As String
    <DataMember>
    Public Property IsEditable As Integer

#End Region

#Region " Methods "

    Friend Sub New()



    End Sub
    Friend Sub New(EmployeeTimeComplex As EmployeeTimeComplex)

        Me.EmployeeTimeID = EmployeeTimeComplex.EmployeeTimeID
        Me.EmployeeTimeDetailID = EmployeeTimeComplex.EmployeeTimeDetailID
        Me.ClientCode = EmployeeTimeComplex.ClientCode
        Me.ClientName = EmployeeTimeComplex.ClientName
        Me.DivisionCode = EmployeeTimeComplex.DivisionCode
        Me.DivisionName = EmployeeTimeComplex.DivisionName
        Me.ProductCode = EmployeeTimeComplex.ProductCode
        Me.ProductDescription = EmployeeTimeComplex.ProductDescription
        Me.JobNumber = EmployeeTimeComplex.JobNumber.GetValueOrDefault(0)
        Me.JobDescription = EmployeeTimeComplex.JobDescription
        Me.JobComponentNumber = EmployeeTimeComplex.JobComponentNumber.GetValueOrDefault(0)
        Me.JobComponentDescription = EmployeeTimeComplex.JobComponentDescription
        Me.FunctionCategory = EmployeeTimeComplex.FunctionCategory
        Me.FunctionCategoryDescription = EmployeeTimeComplex.FunctionCategoryDescription
        Me.[Date] = EmployeeTimeComplex.EmployeeDate
        Me.Hours = EmployeeTimeComplex.EmployeeHours
        Me.DepartmentTeamCode = EmployeeTimeComplex.DepartmentTeamCode
        Me.TaskCode = EmployeeTimeComplex.TaskCode
        Me.Comments = EmployeeTimeComplex.Comments

        If EmployeeTimeComplex.DayPostPeriodClosed.GetValueOrDefault(False) = True Then

            Me.IsEditable = 0

        ElseIf EmployeeTimeComplex.DayIsPendingApproval.GetValueOrDefault(False) = True Then

            Me.IsEditable = 0

        ElseIf EmployeeTimeComplex.DayIsApproved.GetValueOrDefault(False) = True Then

            Me.IsEditable = 0

        ElseIf EmployeeTimeComplex.DayIsDenied.GetValueOrDefault(False) = True Then

            Me.IsEditable = 1

        Else

            Me.IsEditable = 1

        End If

        If EmployeeTimeComplex.IsLockedByProcessControl = 1 Then

            Me.IsEditable = 0

        End If

    End Sub

#End Region

End Class
