Namespace Security.Database.Entities

	<Table("WV_WORKSPACE_OBJECT")>
	Public Class WorkspaceObject
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			WorkspaceID
			DesktopObjectID
			ZoneID
			Height
			Width
			TopCoordinate
			LeftCoordinate
			SortOrder
			UserWorkspace

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("WORKSPACE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserWorkspaceID() As Integer
        <Required>
		<Column("DESKTOP_OBJECT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DesktopObjectID() As Integer
		<Required>
		<MaxLength(20)>
		<Column("ZONE_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ZoneID() As String
		<Column("HEIGHT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Height() As Nullable(Of Integer)
		<Column("WIDTH")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Width() As Nullable(Of Integer)
		<Column("TOP_COORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TopCoordinate() As Nullable(Of Integer)
		<Column("LEFT_COORD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LeftCoordinate() As Nullable(Of Integer)
		<Column("SORT_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SortOrder() As Nullable(Of Integer)

        Public Overridable Property UserWorkspace As Database.Entities.UserWorkspace

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
