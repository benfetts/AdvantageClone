Namespace DTO.Media.SpotRadio

    Public Class Station
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			NielsenRadioStationID
			ComboID
			Name
            CallLetters
            Band
            Frequency
            Format
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property NielsenRadioStationID() As Integer

		<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property ComboID() As Integer

		<AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CallLetters() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Band() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Frequency() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Format() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsSelected() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.NielsenRadioStationID.ToString

        End Function

#End Region

    End Class

End Namespace
