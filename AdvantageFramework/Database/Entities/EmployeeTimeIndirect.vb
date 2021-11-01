Namespace Database.Entities

    <Table("EMP_TIME_NP")>
    Public Class EmployeeTimeIndirect
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeTimeDetailID
            SequenceNumber
            Category
            Hours
            CostRate
            DepartmentTeamCode
            IndirectComment
            DateEntered
            UserID
            TotalCost
            EditFlag
            Notes
            AlternateCostRate
            AlternateCostAmount
            DepartmentTeam
            EmployeeTime
            IndirectCategory

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ET_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("ET_DTL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeDetailID() As Short
        <Key>
        <Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Short
        <Required>
        <MaxLength(10)>
        <Column("CATEGORY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Category() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 2)>
        <Column("EMP_HOURS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 2)>
        <Column("COST_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CostRate() As Nullable(Of Decimal)
        <MaxLength(4)>
        <Column("DP_TM_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DepartmentTeamCode() As String
		<Column("NP_COMMENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IndirectComment() As String
        <Column("DATE_ENTERED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DateEntered() As Nullable(Of Date)
        <MaxLength(100)>
        <Column("USER_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserID() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("TOTAL_COST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalCost() As Nullable(Of Decimal)
        <Column("EDIT_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EditFlag() As Nullable(Of Short)
        <MaxLength(254)>
        <Column("EMP_NOTES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Notes() As String
        <Column("ALT_COST_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateCostRate() As Nullable(Of Decimal)
        <Column("ALT_COST_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateCostAmount() As Nullable(Of Decimal)

        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam
        Public Overridable Property EmployeeTime As Database.Entities.EmployeeTime
        <ForeignKey("Category")>
        Public Overridable Property IndirectCategory As Database.Entities.IndirectCategory

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
