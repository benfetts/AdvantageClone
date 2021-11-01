Namespace DTO

	Public Class Dashboard
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Type() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Layout() As Byte()

#End Region

#Region " Methods "

		Public Sub New()

			Me.ID = 0
			Me.Type = 1
			Me.Layout = Nothing

		End Sub
		Public Sub New(Dashboard As AdvantageFramework.Database.Entities.Dashboard)

			Me.ID = Dashboard.ID
			Me.Type = Dashboard.Type
			Me.Layout = Dashboard.Layout

		End Sub
		Public Sub SaveToEntity(ByRef Dashboard As AdvantageFramework.Database.Entities.Dashboard)

			Dashboard.ID = Me.ID
			Dashboard.Type = Me.Type
			Dashboard.Layout = Me.Layout

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID & " - " & Me.Type

		End Function

#End Region

	End Class

End Namespace
