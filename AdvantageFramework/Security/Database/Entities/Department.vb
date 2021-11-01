Namespace Security.Database.Entities

    <Table("DEPT_TEAM")>
    Public Class Department
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            IsInactive
            DirectHoursPercentGoal
            Category
            PurchaseOrderApprovalRuleCode
            ServiceFeeTypeCode
            Employees
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(4)>
        <Column("DP_TM_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
        Public Property Code() As String
        <MaxLength(30)>
        <Column("DP_TM_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <Column("INACTIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Nullable(Of Short)
        <Column("DIRECT_HRS_PER_GOAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        Public Property DirectHoursPercentGoal() As Nullable(Of Decimal)
        <MaxLength(30)>
        <Column("CATEGORY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Category() As String
        <MaxLength(6)>
        <Column("PO_APPR_RULE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PurchaseOrderApprovalRuleCode)>
        Public Property PurchaseOrderApprovalRuleCode() As String
        <MaxLength(6)>
        <Column("SERVICE_FEE_TYPE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ServiceFeeTypeCode)>
        Public Property ServiceFeeTypeCode() As String

        Public Overridable Property Employees() As ICollection(Of Security.Database.Views.Employee)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
