Namespace Security.Database.Entities

	<Table("WV_USER_QUICK_LAUNCH_APPS")>
	Public Class UserFavoriteModule
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			UserCode
			WorkspaceID
			ModuleID

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(100)>
        <Column("USERID", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Key>
		<Required>
        <Column("TABNO", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WorkspaceID() As Integer
		<Key>
		<Required>
        <Column("APPID", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModuleID() As Integer


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode

        End Function

#End Region

	End Class

End Namespace
