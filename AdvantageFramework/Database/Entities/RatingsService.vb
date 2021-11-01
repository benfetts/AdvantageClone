Namespace Database.Entities

    <Table("RATINGS_SERVICE")>
    Public Class RatingsService
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("RATINGS_SERVICE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID
        <Required>
        <MaxLength(20)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
