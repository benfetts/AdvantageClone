Namespace DTO.Media

    Public Class Metric
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            Order
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Order() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(MediaMetric As AdvantageFramework.Database.Entities.MediaMetric, Optional RenameHPUT As Boolean = False)

            Me.ID = MediaMetric.ID

            If RenameHPUT Then

                Me.Description = Replace(MediaMetric.Description, "H/PUT", "SIU")

            Else

                Me.Description = MediaMetric.Description

            End If

        End Sub
        Public Sub New(MediaSpotRadioResearchMetric As AdvantageFramework.Database.Entities.MediaSpotRadioResearchMetric)

            Me.ID = MediaSpotRadioResearchMetric.MediaMetricID
            Me.Description = MediaSpotRadioResearchMetric.MediaMetric.Description
            Me.Order = MediaSpotRadioResearchMetric.Order

        End Sub
        Public Sub New(MediaSpotTVResearchMetric As AdvantageFramework.Database.Entities.MediaSpotTVResearchMetric, Optional RenameHPUT As Boolean = False)

            Me.ID = MediaSpotTVResearchMetric.MediaMetricID

            If RenameHPUT Then

                Me.Description = Replace(MediaSpotTVResearchMetric.MediaMetric.Description, "H/PUT", "SIU")

            Else

                Me.Description = MediaSpotTVResearchMetric.MediaMetric.Description

            End If

            Me.Order = MediaSpotTVResearchMetric.Order

        End Sub
        Public Sub New(ID As Integer, Description As String)

            Me.ID = ID
            Me.Description = Description

        End Sub
        Public Sub New(MediaSpotRadioCountyResearchMetric As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchMetric)

            Me.ID = MediaSpotRadioCountyResearchMetric.MediaMetricID
            Me.Description = MediaSpotRadioCountyResearchMetric.MediaMetric.Description
            Me.Order = MediaSpotRadioCountyResearchMetric.Order

        End Sub
        Public Sub New(MediaSpotNationalResearchMetric As AdvantageFramework.Database.Entities.MediaSpotNationalResearchMetric)

            Me.ID = MediaSpotNationalResearchMetric.MediaMetricID
            Me.Description = MediaSpotNationalResearchMetric.MediaMetric.Description
            Me.Order = MediaSpotNationalResearchMetric.Order

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
