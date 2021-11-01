Namespace Database.Entities

	<Table("BUDGET_DETAIL")>
	Public Class BudgetDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			BudgetCode
			BudgetRevisionNumber
			SequenceNumber
			LineNumber
			OfficeCode
			ClientCode
			DivisionCode
			ProductCode
			Type
			SalesClassCode
			CategoryCode
			PostPeriodCode
			Value
			Budget
			Office
			SalesClass

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(10)>
        <Column("BUDGET_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BudgetCode() As String
		<Key>
		<Required>
        <Column("REV_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BudgetRevisionNumber() As Short
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SequenceNumber() As Integer
		<Required>
		<Column("LINE_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineNumber() As Integer
		<Required>
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<Required>
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<Required>
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<MaxLength(1)>
		<Column("BUDGET_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Type() As String
		<MaxLength(6)>
		<Column("SC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesClassCode() As String
		<Required>
		<MaxLength(6)>
		<Column("CATEGORY_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CategoryCode() As String
		<Required>
		<MaxLength(6)>
		<Column("BUDGET_PERIOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriodCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("BUDGET_VALUE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Value() As Nullable(Of Decimal)

        Public Overridable Property Budget As Database.Entities.Budget
        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property SalesClass As Database.Entities.SalesClass

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.BudgetCode.ToString

        End Function

#End Region

	End Class

End Namespace
