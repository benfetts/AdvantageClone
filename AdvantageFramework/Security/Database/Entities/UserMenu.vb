Namespace Security.Database.Entities

	<Table("SEC_USER_MENU")>
	Public Class UserMenu
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			UserID
			ModuleID
			MenuType
			Order
			UserMenuTabID
			User
			[Module]
			UserMenuTab

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SEC_USER_MENU_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("SEC_USER_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserID() As Integer
		<Required>
		<Column("SEC_MODULE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModuleID() As Integer
		<Required>
		<Column("MENU_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MenuType() As Integer
		<Required>
		<Column("ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Order() As Integer
		<Column("SEC_USER_MENU_TAB_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserMenuTabID() As Nullable(Of Integer)

        Public Overridable Property User As Database.Entities.User
        Public Overridable Property [Module] As Database.Entities.Module
        Public Overridable Property UserMenuTab As Database.Entities.UserMenuTab

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
