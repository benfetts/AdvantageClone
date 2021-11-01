Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioFormat

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Code() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioFormat As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioFormat)

            Me.Code = NielsenRadioFormat.Code
            Me.Name = NielsenRadioFormat.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString

        End Function

#End Region

    End Class

End Namespace
