Namespace Security.Database.Entities

	<Table("SERVICE_FEE_DEF_CDP")>
	Public Class ServiceFeeReconciliationSettingCDP
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			UserID
			ClientCode
			DivisionCode
			ProductCode

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SERVICE_FEE_DEF_CDP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("SEC_USER_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserID() As Integer
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
