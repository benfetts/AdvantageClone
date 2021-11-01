Namespace Nielsen.Database.Classes

    <Serializable()>
    Public Class NCCTVSyscode

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Syscode
            MVPD
            SystemName
            Description
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Syscode As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Provider As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SystemName As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Description As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace