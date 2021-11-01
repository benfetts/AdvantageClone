Namespace Database.Entities

	<Table("BUDGET")>
	Public Class Budget
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			RevisionNumber
			ApprovedRevisionNumber
			Description
			EmployeeCode
			CreatedBy
			ModifiedBy
			CreateDate
			BudgetDate
			ModifiedDate
			Reference
			Memo
			RevisionReason
			PostPeriodCodeFrom
			PostPeriodCodeTo
			ShowActuals
			CurrentOrLast
			BilledPosted
			ShowForecasted
			UseDetail
			IsActivated
			DetailLevel
			BudgetDetails

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(10)>
        <Column("BUDGET_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<Key>
		<Required>
        <Column("REV_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionNumber() As Short
		<Column("APPROVED_REV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovedRevisionNumber() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("BUDGET_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<MaxLength(30)>
		<Column("USER_CREATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedBy() As String
		<MaxLength(30)>
		<Column("USER_MODIFY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedBy() As String
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreateDate() As Nullable(Of Date)
		<Column("BUDGET_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BudgetDate() As Nullable(Of Date)
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<MaxLength(60)>
		<Column("BUDGET_REF1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Reference() As String
		<Column("BUDGET_MEMO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Memo() As String
		<MaxLength(300)>
		<Column("REVISION_REASON", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionReason() As String
		<MaxLength(6)>
		<Column("FRM_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCodeFrom() As String
		<MaxLength(6)>
		<Column("TO_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCodeTo() As String
		<Column("SHOW_ACTUALS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowActuals() As Nullable(Of Short)
		<Column("CURRENT_OR_LAST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CurrentOrLast() As Nullable(Of Short)
		<Column("BILLED_OR_POSTED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BilledPosted() As Nullable(Of Short)
		<Column("SHOW_FORCASTED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowForecasted() As Nullable(Of Short)
		<Column("USE_DETAIL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseDetail() As Nullable(Of Short)
		<Column("ACTIVATED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Is Inactive", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsActivated() As Nullable(Of Short)
		<Column("DETAIL_LEVEL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DetailLevel() As Nullable(Of Short)

        Public Overridable Property BudgetDetails As ICollection(Of Database.Entities.BudgetDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString

        End Function

#End Region

	End Class

End Namespace
