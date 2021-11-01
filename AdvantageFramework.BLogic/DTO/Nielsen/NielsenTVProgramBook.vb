Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVProgramBook

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            Year
            Month
            Validated
            ReportingService
            Exclusion
            Ethnicity
            DownloadFileID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Month() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Validated() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReportingService() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Exclusion() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Ethnicity() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DownloadFileID() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(NielsenTVProgramBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgramBook)

            Me.ID = NielsenTVProgramBook.ID
            Me.NielsenMarketNumber = NielsenTVProgramBook.NielsenMarketNumber
            Me.Year = NielsenTVProgramBook.Year
            Me.Month = NielsenTVProgramBook.Month
            Me.Validated = False
            Me.ReportingService = NielsenTVProgramBook.ReportingService
            Me.Exclusion = NielsenTVProgramBook.Exclusion
            Me.Ethnicity = NielsenTVProgramBook.Ethnicity
            Me.DownloadFileID = NielsenTVProgramBook.DownloadFileID

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
