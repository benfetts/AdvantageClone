Namespace DTO.Maintenance.Media.MarketGroup

    Public Class Country
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
            ISO2
            ISO3
            ISONumeric
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String
        <Required>
        <MaxLength(2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ISO2() As String
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ISO3() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ISONumeric() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Name = String.Empty
            Me.ISO2 = String.Empty
            Me.ISO3 = String.Empty
            Me.ISONumeric = Nothing

        End Sub
        Public Sub New(Country As AdvantageFramework.Database.Entities.Country)

            Me.ID = Country.ID
            Me.Name = Country.Name
            Me.ISO2 = Country.ISO2
            Me.ISO3 = Country.ISO3
            Me.ISONumeric = Country.ISONumeric

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.Name

        End Function

#End Region

    End Class

End Namespace
