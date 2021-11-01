Namespace DTO.Media

    Public Class MediaDemographic
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ID
			Code
			Description
			Type
            IsInactive
            MediaDemoSourceID
            Group
            Category
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public Property Code() As String
		<AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public Property Description() As String
		<AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public Property Type() As String
		<AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public Property IsInactive() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaDemoSourceID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Group() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Category() As String
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

			Me.ID = 0
			Me.Code = String.Empty
			Me.Description = String.Empty
			Me.Type = String.Empty
			Me.IsInactive = False

		End Sub
        Public Sub New(MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic)

			Me.ID = MediaDemographic.ID
			Me.Code = MediaDemographic.Code
			Me.Description = MediaDemographic.Description
			Me.Type = MediaDemographic.Type
            Me.IsInactive = MediaDemographic.IsInactive
            Me.MediaDemoSourceID = MediaDemographic.MediaDemoSourceID
            Me.Group = MediaDemographic.ComscoreGroupOwnerName
            Me.Category = MediaDemographic.ComscoreGroupName

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
