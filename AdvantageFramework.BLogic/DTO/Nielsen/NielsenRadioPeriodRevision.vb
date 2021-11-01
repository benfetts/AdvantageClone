Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenRadioPeriodRevision

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OldNielsenRadioPeriodID
            NewNielsenRadioPeriodID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OldNielsenRadioPeriodID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewNielsenRadioPeriodID() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioPeriodRevision As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriodRevision)

            Me.ID = NielsenRadioPeriodRevision.ID
            Me.OldNielsenRadioPeriodID = NielsenRadioPeriodRevision.OldNielsenRadioPeriodID
            Me.NewNielsenRadioPeriodID = NielsenRadioPeriodRevision.NewNielsenRadioPeriodID

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
