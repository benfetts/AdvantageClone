Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioQualitative

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Code() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioQualitative As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative)

            Me.ID = NielsenRadioQualitative.ID
            Me.Code = NielsenRadioQualitative.Code
            Me.Name = NielsenRadioQualitative.Name

        End Sub

#End Region

    End Class

End Namespace
