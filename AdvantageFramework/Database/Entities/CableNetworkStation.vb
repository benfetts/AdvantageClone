Namespace Database.Entities

	<Table("CABLE_NETWORK_STATION")>
	Public Class CableNetworkStation
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Code
			Description
            NielsenTVStationCode
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("CABLE_NETWORK_STATION_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(10)>
		<Column("CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Code() As String
		<Required>
		<MaxLength(100)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("NIELSEN_TV_STATION_CODE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property NielsenTVStationCode() As Integer
        <Column("IS_INACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

			ToString = Me.ID

		End Function

#End Region

	End Class

End Namespace
