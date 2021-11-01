Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NCCTVMVPD

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MVPD
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MVPD() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NCCTVMVPD As AdvantageFramework.Nielsen.Database.Entities.NCCTVMVPD)

            Me.ID = NCCTVMVPD.ID
            Me.MVPD = NCCTVMVPD.MVPD

        End Sub

#End Region

    End Class

End Namespace
