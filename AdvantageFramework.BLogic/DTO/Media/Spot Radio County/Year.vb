Namespace DTO.Media.SpotRadioCounty

    Public Class Year
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaSpotRadioCountyResearchYearID
            Year1
            Year2
            Year3
            Year4
            Year5
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaSpotRadioCountyResearchYearID() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Year 1", PropertyType:=BaseClasses.Methods.PropertyTypes.Year)>
        Public Property Year1() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Year 2", PropertyType:=BaseClasses.Methods.PropertyTypes.Year)>
        Public Property Year2() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Year 3", PropertyType:=BaseClasses.Methods.PropertyTypes.Year)>
        Public Property Year3() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Year 4", PropertyType:=BaseClasses.Methods.PropertyTypes.Year)>
        Public Property Year4() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Year 5", PropertyType:=BaseClasses.Methods.PropertyTypes.Year)>
        Public Property Year5() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(MediaSpotRadioCountyResearchYear As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchYear)

            Me.MediaSpotRadioCountyResearchYearID = MediaSpotRadioCountyResearchYear.ID
            Me.Year1 = MediaSpotRadioCountyResearchYear.Year1
            Me.Year2 = MediaSpotRadioCountyResearchYear.Year2
            Me.Year3 = MediaSpotRadioCountyResearchYear.Year3
            Me.Year4 = MediaSpotRadioCountyResearchYear.Year4
            Me.Year5 = MediaSpotRadioCountyResearchYear.Year5

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotRadioCountyResearchYear As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchYear)

            MediaSpotRadioCountyResearchYear.Year1 = Me.Year1
            MediaSpotRadioCountyResearchYear.Year2 = Me.Year2
            MediaSpotRadioCountyResearchYear.Year3 = Me.Year3
            MediaSpotRadioCountyResearchYear.Year4 = Me.Year4
            MediaSpotRadioCountyResearchYear.Year5 = Me.Year5

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.MediaSpotRadioCountyResearchYearID.ToString

        End Function

#End Region

    End Class

End Namespace
