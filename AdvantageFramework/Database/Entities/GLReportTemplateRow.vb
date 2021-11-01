Namespace Database.Entities

	<Table("GL_REPORT_ROW")>
	Public Class GLReportTemplateRow
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			GLReportTemplateID
			Description
			BalanceType
			DisplayType
			LinkType
			AccountType
			GLACode
			GLACodeRangeStart
			GLACodeRangeTo
			Wildcard
			AccountGroupCode
			RowIndex
			Type
			TotalType
			UseBaseAccountCodes
			IndentSpaces
			UnderlineAmount
			IsBold
			UseCurrencyFormat
			SuppressIfAllZeros
			NumberOfDecimalPlaces
			RollUp
			DataOption
			DataCalculation
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
			ModifiedDate
			DoubleUnderlineAmount
			IsVisible
			GLReportTemplate
			GLReportTemplateRowRelations
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("GL_REPORT_ROW_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("GL_REPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLReportTemplateID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("BALANCE_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BalanceType() As Integer
		<Required>
		<Column("DISPLAY_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DisplayType() As Integer
		<Required>
		<Column("LINK_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LinkType() As Integer
		<Column("ACCOUNT_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountType() As Nullable(Of Integer)
		<MaxLength(30)>
		<Column("GLACODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACode() As String
		<MaxLength(30)>
		<Column("GLACODE_RANGE_START", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeRangeStart() As String
		<MaxLength(30)>
		<Column("GLACODE_RANGE_TO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeRangeTo() As String
		<MaxLength(30)>
		<Column("WILDCARD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Wildcard() As String
		<MaxLength(30)>
		<Column("GROUP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountGroupCode() As String
		<Required>
		<Column("ROW_INDEX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property RowIndex() As Integer
		<Required>
		<Column("TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Type() As Integer
		<Required>
		<Column("TOTAL_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TotalType() As Integer
		<Required>
		<Column("USE_BASE_ACCOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseBaseAccountCodes() As Boolean
		<Required>
		<Column("INDENT_SPACES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IndentSpaces() As Integer
		<Required>
		<Column("UNDERLINE_AMOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UnderlineAmount() As Boolean
		<Required>
		<Column("IS_BOLD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsBold() As Boolean
		<Required>
		<Column("USE_CURRENCY_FORMAT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseCurrencyFormat() As Boolean
		<Required>
		<Column("SUPPRESS_IF_ALL_ZEROS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SuppressIfAllZeros() As Boolean
		<Required>
		<Column("NUMBER_DECIMAL_PLACES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=6, UseMinValue:=True, MinValue:=0)>
        Public Property NumberOfDecimalPlaces() As Integer
		<Required>
		<Column("ROLLUP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RollUp() As Boolean
		<Required>
		<Column("DATA_OPTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DataOption() As Integer
		<Required>
		<Column("DATA_CALCULATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DataCalculation() As Integer
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<MaxLength(100)>
		<Column("USER_MODIFIED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<Required>
		<Column("DOUBLE_UNDERLINE_AMOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DoubleUnderlineAmount() As Boolean
		<Required>
		<Column("IS_VISIBLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsVisible() As Boolean

		Public Overridable Property GLReportTemplate As Database.Entities.GLReportTemplate
        Public Overridable Property GLReportTemplateRowRelations As ICollection(Of Database.Entities.GLReportTemplateRowRelation)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
