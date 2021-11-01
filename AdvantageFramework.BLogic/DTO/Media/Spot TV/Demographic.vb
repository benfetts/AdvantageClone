Namespace DTO.Media.SpotTV

    Public Class Demographic
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            Group
            Category
            ComscoreDemoNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Group() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Category() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComscoreDemoNumber() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property GroupSortOrder() As Integer
            Get
                If Me.Group = "comScore Demographics" Then
                    GroupSortOrder = 0
                Else
                    GroupSortOrder = 1
                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic)

            Me.ID = MediaDemographic.ID
            Me.Description = MediaDemographic.Description
            Me.Group = MediaDemographic.ComscoreGroupOwnerName
            Me.Category = MediaDemographic.ComscoreGroupName
            Me.ComscoreDemoNumber = MediaDemographic.ComscoreDemoNumber

        End Sub
        Public Sub New(MediaSpotTVResearchDemo As AdvantageFramework.Database.Entities.MediaSpotTVResearchDemo)

            Me.ID = MediaSpotTVResearchDemo.MediaDemoID
            Me.Description = MediaSpotTVResearchDemo.MediaDemographic.Description
            Me.Group = MediaSpotTVResearchDemo.MediaDemographic.ComscoreGroupOwnerName
            Me.Category = MediaSpotTVResearchDemo.MediaDemographic.ComscoreGroupName
            Me.ComscoreDemoNumber = MediaSpotTVResearchDemo.MediaDemographic.ComscoreDemoNumber

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
