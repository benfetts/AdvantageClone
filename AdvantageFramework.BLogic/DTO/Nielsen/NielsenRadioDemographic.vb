Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioDemographic

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Number
            Name
            AgeSexCode
            QualitativeCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Number() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AgeSexCode() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QualitativeCode() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioDemographic As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDemographic)

            Me.ID = NielsenRadioDemographic.ID
            Me.Number = NielsenRadioDemographic.Number
            Me.Name = NielsenRadioDemographic.Name
            Me.AgeSexCode = NielsenRadioDemographic.AgeSexCode
            Me.QualitativeCode = NielsenRadioDemographic.QualitativeCode

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
