'<DataContract>

Public Class DirectTimeAPIReport

#Region " Constants "



#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

    'Force Update
    <DataMember>
    Public Property ID As Nullable(Of Integer)
    <DataMember>
    Public Property EmployeeCode As String
    <DataMember>
    Public Property Employee As String
    <DataMember>
    Public Property EmployeeFirstName As String
    <DataMember>
    Public Property EmployeeLastName As String
    <DataMember>
    Public Property EmployeeLastFirst As String
    <DataMember>
    Public Property EmployeeTitle As String
    <DataMember>
    Public Property EmployeeAccountNumber As String
    <DataMember>
    Public Property IsEmployeeFreelance As String
    <DataMember>
    Public Property IsActiveFreelance As String
    <DataMember>
    Public Property DirectHoursGoalPercent As Nullable(Of Decimal)
    <DataMember>
    Public Property BillableHoursGoal As Nullable(Of Decimal)
    <DataMember>
    Public Property DepartmentTeamCode As String
    <DataMember>
    Public Property DepartmentTeam As String
    <DataMember>
    Public Property SupervisorCode As String
    <DataMember>
    Public Property Supervisor As String
    <DataMember>
    Public Property ClientCode As String
    <DataMember>
    Public Property ClientDescription As String
    <DataMember>
    Public Property DivisionCode As String
    <DataMember>
    Public Property DivisionDescription As String
    <DataMember>
    Public Property ProductCode As String
    <DataMember>
    Public Property ProductDescription As String
    <DataMember>
    Public Property ProductCategoryCode As String
    <DataMember>
    Public Property ProductCategoryDescription As String
    <DataMember>
    Public Property SalesClassCode As String
    <DataMember>
    Public Property SalesClassDescription As String
    <DataMember>
    Public Property CampaignID As Nullable(Of Integer)
    <DataMember>
    Public Property CampaignCode As String
    <DataMember>
    Public Property CampaignName As String
    <DataMember>
    Public Property JobNumber As Integer
    <DataMember>
    Public Property JobDescription As String
    <DataMember>
    Public Property JobComponentNumber As Short
    <DataMember>
    Public Property JobComponentDescription As String
    <DataMember>
    Public Property JobComponent As String
    <DataMember>
    Public Property LabelFromUDFTable1 As String
    <DataMember>
    Public Property LabelFromUDFTable2 As String
    <DataMember>
    Public Property LabelFromUDFTable3 As String
    <DataMember>
    Public Property LabelFromUDFTable4 As String
    <DataMember>
    Public Property LabelFromUDFTable5 As String
    <DataMember>
    Public Property AccountExecutiveCode As String
    <DataMember>
    Public Property AccountExecutive As String
    <DataMember>
    Public Property JobTypeCode As String
    <DataMember>
    Public Property JobTypeDescription As String
    <DataMember>
    Public Property FunctionCode As String
    <DataMember>
    Public Property FunctionDescription As String
    <DataMember>
    Public Property [Date] As Nullable(Of Date)
    <DataMember>
    Public Property DateStr As String
    <DataMember>
    Public Property DateEntered As Nullable(Of Date)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="AR GL Account")>
    Public Property DateEnteredStr As String
    <DataMember>
    Public Property StandardHours As Nullable(Of Decimal)
    <DataMember>
    Public Property TotalHoursWorked As Nullable(Of Decimal)
    <DataMember>
    Public Property ApprovalUserCode As String
    <DataMember>
    Public Property ApprovalDate As Nullable(Of Date)
    <DataMember>
    Public Property ApprovalDateStr As String
    <DataMember>
    Public Property PendingApproval As String
    <DataMember>
    Public Property Approved As String
    <DataMember>
    Public Property Hours As Nullable(Of Decimal)
    <DataMember>
    Public Property Amount As Nullable(Of Decimal)
    <DataMember>
    Public Property MarkupAmount As Nullable(Of Decimal)
    <DataMember>
    Public Property ResaleTax As Nullable(Of Decimal)
    <DataMember>
    Public Property TotalAmount As Nullable(Of Decimal)
    <DataMember>
    Public Property TotalBilled As Nullable(Of Decimal)
    <DataMember>
    Public Property TotalAmountWithTax As Nullable(Of Decimal)
    <DataMember>
    Public Property TotalBilledWithTax As Nullable(Of Decimal)
    <DataMember>
    Public Property NonBillable As String
    <DataMember>
    Public Property Billed As String
    <DataMember>
    Public Property FunctionHeadingDescription As String
    <DataMember>
    Public Property Comments As String
    <DataMember>
    Public Property EmployeeOfficeCode As String
    <DataMember>
    Public Property JobOfficeCode As String
    <DataMember>
    Public Property IsFeeTime As String
    <DataMember>
    Public Property DefaultRoleCode As String
    <DataMember>
    Public Property DefaultRole As String
    <DataMember>
    Public Property Type As String
    <DataMember>
    Public Property Status As String
    <DataMember>
    Public Property EmployeeRateFrom As String
    <DataMember>
    Public Property AdjustmentComments As String
    <DataMember>
    Public Property ARPostPeriod As String
    <DataMember>
    Public Property ARInvoiceNumber As Nullable(Of Integer)
    <DataMember>
    Public Property UserID As String
    <DataMember>
    Public Property AssignmentType As String
    <DataMember>
    Public Property TaskCode As String
    <DataMember>
    Public Property Assignment As String
    <DataMember>
    Public Property CmpBeginDate As Nullable(Of Date)
    <DataMember>
    Public Property CmpBeginDateStr As String
    <DataMember>
    Public Property CmpEndDate As Nullable(Of Date)
    <DataMember>
    Public Property CmpEndDateStr As String
    <DataMember>
    Public Property FunctionConsolidationCode As String
    <DataMember>
    Public Property FunctionConsolidationDescription As String
    <DataMember>
    Public Property ClientPO As String
    <DataMember>
    Public Property Terminated As String
    <DataMember>
    Public Property TerminatedDate As Nullable(Of Date)
    <DataMember>
    Public Property TerminatedDateStr As String



#End Region

#Region " Methods "

    Public Sub New()



    End Sub

    Public Overrides Function ToString() As String

        ToString = Me.ID.ToString

    End Function

#End Region

End Class

