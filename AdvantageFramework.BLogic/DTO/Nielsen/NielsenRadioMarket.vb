Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioMarket

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            Name
            Source
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Number() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Source() As AdvantageFramework.Nielsen.Database.Entities.RadioSource

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioMarket As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket)

            Me.Number = NielsenRadioMarket.Number
            Me.Name = NielsenRadioMarket.Name
            Me.Source = NielsenRadioMarket.Source

        End Sub

#End Region

    End Class

End Namespace
