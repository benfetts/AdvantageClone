Namespace Database.Entities

	<Table("OFF_SC_FNC_ACCTS")>
	Public Class OfficeSalesClassFunctionAccount
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			OfficeCode
			SalesClassCode
			FunctionCode
			ProductionSalesGLACode
			ProductionCostOfSalesGLACode
			[Function]
			GeneralLedgerAccount
			GeneralLedgerAccount2
			OfficeSalesClassAccount

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(4)>
        <Column("OFFICE_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
		Public Property OfficeCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("SC_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesClassCode)>
		Public Property SalesClassCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("FNC_CODE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Function", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode)>
		Public Property FunctionCode() As String
		<Required>
		<MaxLength(30)>
		<Column("PGLACODE_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Sales Acct", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property ProductionSalesGLACode() As String
		<Required>
		<MaxLength(30)>
		<Column("PGLACODE_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="COS Acct", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property ProductionCostOfSalesGLACode() As String

        Public Overridable Property [Function] As Database.Entities.Function
        <ForeignKey("ProductionCostOfSalesGLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("ProductionSalesGLACode")>
        Public Overridable Property GeneralLedgerAccount2 As Database.Entities.GeneralLedgerAccount
        Public Overridable Property OfficeSalesClassAccount As Database.Entities.OfficeSalesClassAccount

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OfficeCode.ToString

        End Function

#End Region

	End Class

End Namespace
