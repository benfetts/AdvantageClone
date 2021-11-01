﻿Namespace Security.Database.Entities

	<Table("SEC_CPUSER_MODACCESS")>
	Public Class ClientPortalUserModuleAccess
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ClientPortalUserID
			ModuleID
			IsBlocked
			CanPrint
			CanUpdate
			CanAdd
			Custom1
			Custom2
			ClientPortalUser
			[Module]

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SEC_CPUSER_MODACCESS_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("CPUSER_GUID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientPortalUserID() As Guid
		<Required>
		<Column("SEC_MODULE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModuleID() As Integer
		<Required>
		<Column("IS_BLOCKED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsBlocked() As Boolean
		<Required>
		<Column("CAN_PRINT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CanPrint() As Boolean
		<Required>
		<Column("CAN_UPDATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CanUpdate() As Boolean
		<Required>
		<Column("CAN_ADD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CanAdd() As Boolean
		<Required>
		<Column("CUSTOM1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Custom1() As Boolean
		<Required>
		<Column("CUSTOM2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Custom2() As Boolean

        Public Overridable Property ClientPortalUser As Database.Entities.ClientPortalUser
        Public Overridable Property [Module] As Database.Entities.Module

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
