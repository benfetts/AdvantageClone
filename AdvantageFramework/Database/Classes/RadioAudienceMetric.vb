Namespace Database.Classes

    <Serializable()>
    Public Class RadioWorksheetMetric

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaDemoID
            Demographic
            AQHRating
            AQH
            CumeRating
            CUME
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MediaDemoID As Integer

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Demographic() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property AQHRating() As Decimal

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AQH() As Decimal

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property CumeRating() As Decimal

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CUME() As Decimal

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace