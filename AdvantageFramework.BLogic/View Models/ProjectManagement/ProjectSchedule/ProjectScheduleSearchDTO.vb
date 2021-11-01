Namespace ViewModels.ProjectManagement.ProjectSchedule
    <Serializable()>
    Public Class ProjectScheduleSearchDTO
#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        '

        'RowId
        Public Property RowId As Integer
        'ClientCode
        Public Property ClientCode As String
        'ClientName
        Public Property ClientName As String
        'DivisionCode
        Public Property DivisionCode As String
        'DivisionName
        Public Property DivisionName As String
        'ProductCode
        Public Property ProductCode As String
        'ProductDescription
        Public Property ProductDescription As String
        'JobNumber
        Public Property JobNumber As Integer
        'JobDescription
        Public Property JobDescription As String
        'JobComponentNumber
        Public Property JobComponentNumber As Short
        'JobComponentDescription
        Public Property JobComponentDescription As String
        'StatusCode
        Public Property StatusCode As String
        'AccountExecutiveCode
        Public Property AccountExecutiveCode As String
        'JobCompleted
        Public Property JobCompleted As Date?
        'Comments
        Public Property Comments As String
        'Status
        Public Property Status As String
        'CompletedDate
        Public Property CompletedDate As Date?
        'DeliveredDate
        Public Property DeliveredDate As Date?
        'ShippedDate
        Public Property ShippedDate As Date?
        'ReceivedBy
        Public Property ReceivedBy As String
        'AccountExecutiveName
        Public Property AccountExecutiveName As String
        'OfficeCode
        Public Property OfficeCode As String
        'OfficeName
        Public Property OfficeName As String
        'ASSIGN_1
        Public Property ASSIGN_1 As String
        'ASSIGN_2
        Public Property ASSIGN_2 As String
        'ASSIGN_3
        Public Property ASSIGN_3 As String
        'ASSIGN_4
        Public Property ASSIGN_4 As String
        'ASSIGN_5
        Public Property ASSIGN_5 As String
        'ASSIGN_1_FML_NAME
        Public Property ASSIGN_1_FML_NAME As String
        'ASSIGN_2_FML_NAME
        Public Property ASSIGN_2_FML_NAME As String
        'ASSIGN_3_FML_NAME
        Public Property ASSIGN_3_FML_NAME As String
        'ASSIGN_4_FML_NAME
        Public Property ASSIGN_4_FML_NAME As String
        'ASSIGN_5_FML_NAME
        Public Property ASSIGN_5_FML_NAME As String
        'TrafficReference
        Public Property TrafficReference As String
        'DueDate
        Public Property DueDate As Date?
        'StartDate
        Public Property StartDate As Date?
        'JobRushCharges
        Public Property JobRushCharges As Short
        'TrafficeScheduledBy
        Public Property TrafficeScheduledBy As Integer
        'MarkupPct
        Public Property MarkupPct As Decimal?
        'NoBill
        Public Property NoBill As Short
        'JOB_AND_COMP
        Public Property JOB_AND_COMP As String
        'AutoUpdateStatus
        Public Property AutoUpdateStatus As Boolean?
        'IsTemplate
        Public Property IsTemplate As Boolean?
        'GutPercent
        Public Property GutPercent As Decimal
        'UserCustom1
        Public Property UserCustom1 As Integer?

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
