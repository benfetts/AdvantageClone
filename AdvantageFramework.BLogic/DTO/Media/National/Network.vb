Namespace DTO.Media.National

    Public Class Network
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Name
            Venue
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
        Public Property Name() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Venue() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NationalNetwork As AdvantageFramework.National.Database.Entities.NationalNetwork)

            Me.ID = NationalNetwork.ID
            Me.Code = NationalNetwork.Code
            Me.Name = NationalNetwork.Name
            Me.Venue = NationalNetwork.VenueCode

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
