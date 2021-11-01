Namespace Database.Entities

	<Table("OFF_INTER_CO")>
	Public Class OfficeInterCompany
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			OfficeCode
			Code
			DueFromGLACode
			DueToGLACode
			GeneralLedgerAccount
			GeneralLedgerAccount2
			Office
			Office2

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
		<MaxLength(4)>
        <Column("INTER_CO_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<Required>
		<MaxLength(30)>
		<Column("DUE_FROM", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property DueFromGLACode() As String
		<Required>
		<MaxLength(30)>
		<Column("DUE_TO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property DueToGLACode() As String

        Public Overridable Property Office As Database.Entities.Office

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OfficeCode.ToString

        End Function

#End Region

	End Class

End Namespace
