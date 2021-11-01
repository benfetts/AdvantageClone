Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioReportType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            ID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Code() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioReportType As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioReportType)

            Me.Code = NielsenRadioReportType.Code
            Me.Name = NielsenRadioReportType.Name
            Me.ID = NielsenRadioReportType.ID

        End Sub

#End Region

    End Class

End Namespace
