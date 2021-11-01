Namespace DTO.Media.SpotTV

    Public Class Station
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Station
            Type
            Affiliation
            Channel
			IsSelected
			StationCode
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Station() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Type() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Affiliation() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Channel() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsSelected() As Boolean

		<AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public Property StationCode() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CallLetters() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComscorePrimaryMarketNumber() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
