Namespace DTO.Media.SpotRadioCounty

    Public Class Station
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Name
            CallLetters
            Band
            Frequency
            IsSelected
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CallLetters() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Band() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Frequency() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsSelected() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioCountyStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyStation, Optional ByVal IsSelected As Boolean = False)

            Me.CallLetters = NielsenRadioCountyStation.CallLetters
            Me.Band = NielsenRadioCountyStation.Band
            Me.Frequency = NielsenRadioCountyStation.Frequency
            Me.IsSelected = IsSelected
            Me.Name = Me.CallLetters & "-" & Me.Band

        End Sub
        Public Sub New(CallLetters As String, Band As String, Frequency As String)

            Me.CallLetters = CallLetters
            Me.Band = Band
            Me.Frequency = Frequency
            Me.IsSelected = True
            Me.Name = Me.CallLetters & "-" & Me.Band

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Name.ToString

        End Function

#End Region

    End Class

End Namespace
