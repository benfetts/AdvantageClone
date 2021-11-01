Namespace DTO.Maintenance.Media.MarketGroup

    Public Class MarketGroup
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaType
            CountryID
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MediaType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Media Type")>
        Public Property MediaTypeDesc() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CountryID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Country")>
        Public Property Country() As String
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.MediaType = "T"
            Me.MediaTypeDesc = "TV"
            Me.CountryID = AdvantageFramework.DTO.Countries.UnitedStates
            Me.Country = "United States"
            Me.Name = String.Empty

        End Sub
        Public Sub New(MarketGroup As AdvantageFramework.Database.Entities.MarketGroup)

            Me.ID = MarketGroup.ID
            Me.MediaType = MarketGroup.MediaType

            Select Case Me.MediaType

                Case "T"

                    Me.MediaTypeDesc = "TV"

                Case "R"

                    Me.MediaTypeDesc = "Radio"

                Case "M"

                    Me.MediaTypeDesc = "Magazine"

                Case "N"

                    Me.MediaTypeDesc = "Newspaper"

                Case "O"

                    Me.MediaTypeDesc = "Out of Home"

                Case "I"

                    Me.MediaTypeDesc = "Internet"

            End Select

            Me.CountryID = MarketGroup.CountryID
            Me.Country = MarketGroup.Country.Name

            Me.Name = MarketGroup.Name

        End Sub
        Public Sub SaveToEntity(ByRef MarketGroup As AdvantageFramework.Database.Entities.MarketGroup)

            MarketGroup.MediaType = Me.MediaType
            MarketGroup.CountryID = Me.CountryID
            MarketGroup.Name = Me.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.Name

        End Function

#End Region

    End Class

End Namespace
