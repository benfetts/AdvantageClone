Namespace DTO.Maintenance.Accounting

    Public Class DepartmentTeam

#Region " Enum "

        Public Enum Properties
            Code
            Description
            IsInactive
            DirectHoursPercentGoal
            Category
            PurchaseOrderApprovalRuleCode
            ServiceFeeTypeCode
        End Enum

#End Region

#Region " Properties "

        <Required>
        <MaxLength(4)>
        Public Property Code() As String
        <MaxLength(30)>
        Public Property Description() As String
        Public Property IsInactive() As Nullable(Of Short)
        Public Property DirectHoursPercentGoal() As Nullable(Of Decimal)
        <MaxLength(30)>
        Public Property Category() As String
        <MaxLength(6)>
        Public Property PurchaseOrderApprovalRuleCode() As String
        <MaxLength(6)>
        Public Property ServiceFeeTypeCode() As String

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(ByVal DepartmentTeamEntity As AdvantageFramework.Database.Entities.DepartmentTeam)

            Me.Code = DepartmentTeamEntity.Code
            Me.Description = DepartmentTeamEntity.Description
            Me.IsInactive = DepartmentTeamEntity.IsInactive
            Me.DirectHoursPercentGoal = DepartmentTeamEntity.DirectHoursPercentGoal
            Me.Category = DepartmentTeamEntity.Category
            Me.PurchaseOrderApprovalRuleCode = DepartmentTeamEntity.PurchaseOrderApprovalRuleCode
            Me.ServiceFeeTypeCode = DepartmentTeamEntity.ServiceFeeTypeCode

        End Sub
        Public Function ToEntity(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.DepartmentTeam

            'objects
            Dim DepartmentTeamEntity As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

            If DbContext IsNot Nothing Then

                DepartmentTeamEntity = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, Me.Code)

            End If

            If DepartmentTeamEntity Is Nothing Then

                DepartmentTeamEntity = New Database.Entities.DepartmentTeam

            End If

            DepartmentTeamEntity.Code = Me.Code
            DepartmentTeamEntity.Description = Me.Description
            DepartmentTeamEntity.IsInactive = Me.IsInactive
            DepartmentTeamEntity.DirectHoursPercentGoal = Me.DirectHoursPercentGoal
            DepartmentTeamEntity.Category = Me.Category
            DepartmentTeamEntity.PurchaseOrderApprovalRuleCode = Me.PurchaseOrderApprovalRuleCode
            DepartmentTeamEntity.ServiceFeeTypeCode = Me.ServiceFeeTypeCode

            Return DepartmentTeamEntity

        End Function

#End Region

    End Class

End Namespace


