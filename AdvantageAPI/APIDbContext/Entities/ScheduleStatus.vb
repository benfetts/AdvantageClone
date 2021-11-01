<Table("TRAFFIC")>
Public Class ScheduleStatus

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

	<Key>
	<Required>
	<MaxLength(10)>
	<Column("TRF_CODE", TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(30)>
	<Column("TRF_DESCRIPTION", TypeName:="varchar")>
	<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
	Public Property Description() As String
	<Column("INACTIVE_FLAG")>
	Public Property IsInactive() As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

End Class
