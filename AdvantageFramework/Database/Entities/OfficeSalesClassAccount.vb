Namespace Database.Entities

	<Table("OFF_SC_ACCTS")>
	Public Class OfficeSalesClassAccount
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			OfficeCode
			SalesClassCode
			ProductionSalesGLACode
			ProductionCostOfSalesGLACode
			MediaCostOfSalesGLACode
			MediaSalesGLACode
			GeneralLedgerAccount
			GeneralLedgerAccount2
			GeneralLedgerAccount3
			GeneralLedgerAccount4
			Office
			SalesClass
			OfficeSalesClassFunctionAccounts

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(4)>
        <Column("OFFICE_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
		Public Property OfficeCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("SC_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesClassCode)>
		Public Property SalesClassCode() As String
		<MaxLength(30)>
		<Column("PGLACODE_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionSalesGLACode() As String
		<MaxLength(30)>
		<Column("PGLACODE_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionCostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("MGLACODE_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaCostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("MGLACODE_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaSalesGLACode() As String

        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property SalesClass As Database.Entities.SalesClass
        Public Overridable Property OfficeSalesClassFunctionAccounts As ICollection(Of Database.Entities.OfficeSalesClassFunctionAccount)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OfficeCode

        End Function

#End Region

	End Class

End Namespace
