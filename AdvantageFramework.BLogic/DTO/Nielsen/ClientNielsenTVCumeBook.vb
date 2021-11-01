Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class ClientNielsenTVCumeBook

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            NielsenTVCumeBookID
            NielsenMarketNumber
            Year
            Month
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenTVCumeBookID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Month() As Short

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

