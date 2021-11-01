Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class ClientNielsenTVProgramBook

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            NielsenTVProgramBookID
            NielsenMarketNumber
            Year
            Month
            ReportingService
            Exclusion
            Ethnicity
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenTVProgramBookID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Month() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReportingService() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Exclusion() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Ethnicity() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

