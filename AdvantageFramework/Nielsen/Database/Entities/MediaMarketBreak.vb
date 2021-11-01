Namespace Nielsen.Database.Entities

    <Table("MEDIA_MARKET_BREAK")>
    Public Class MediaMarketBreak
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BroadcastTypeID
            RatingsServiceID
            Name
            Description
            ShortDescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("MEDIA_MARKET_BREAK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Column("BROADCAST_TYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BroadcastTypeID() As AdvantageFramework.Nielsen.Database.Entities.BroadcastTypeID
        <Column("RATINGS_SERVICE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property RatingsServiceID() As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID
        <MaxLength(10)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
        <MaxLength(30)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <MaxLength(15)>
        <Column("SHORT_DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ShortDescription() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
