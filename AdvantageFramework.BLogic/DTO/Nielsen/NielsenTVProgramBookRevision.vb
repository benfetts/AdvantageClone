Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVProgramBookRevision

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OldNielsenTVProgramBookID
            NewNielsenTVProgramBookID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OldNielsenTVProgramBookID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewNielsenTVProgramBookID() As Integer

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(NielsenTVProgramBookRevision As AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgramBookRevision)

            Me.ID = NielsenTVProgramBookRevision.ID
            Me.OldNielsenTVProgramBookID = NielsenTVProgramBookRevision.OldNielsenTVProgramBookID
            Me.NewNielsenTVProgramBookID = NielsenTVProgramBookRevision.NewNielsenTVProgramBookID

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
