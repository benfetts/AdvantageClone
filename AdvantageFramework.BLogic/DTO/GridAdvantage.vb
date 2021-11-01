Namespace DTO

	Public Class GridAdvantage
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			GridType
			UserCode
			XmlLayout
			GridSubtype
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		Public Property ID() As Long
		<Required>
		Public Property GridType() As Long
		<Required>
		<MaxLength(100)>
		Public Property UserCode() As String
		<Required>
		Public Property XmlLayout() As String
		Public Property GridSubtype() As System.Nullable(Of Long)

#End Region

#Region " Methods "

		Public Sub New()

			Me.ID = 0
			Me.GridType = 0
			Me.UserCode = String.Empty
			Me.XmlLayout = String.Empty
			Me.GridSubtype = Nothing

		End Sub
		Public Sub New(GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage)

			Me.ID = GridAdvantage.ID
			Me.GridType = GridAdvantage.GridType
			Me.UserCode = GridAdvantage.UserCode
			Me.XmlLayout = GridAdvantage.XmlLayout
			Me.GridSubtype = GridAdvantage.GridSubtype

		End Sub
		Public Sub SaveToEntity(ByRef GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage)

			GridAdvantage.ID = Me.ID
			GridAdvantage.GridType = Me.GridType
			GridAdvantage.UserCode = Me.UserCode
			GridAdvantage.XmlLayout = Me.XmlLayout
			GridAdvantage.GridSubtype = Me.GridSubtype

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.GridType & " - " & Me.UserCode

		End Function

#End Region

	End Class

End Namespace
