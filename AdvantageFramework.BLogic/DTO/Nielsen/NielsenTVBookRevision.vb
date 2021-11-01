Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVBookRevision

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OldNielsenTVBookID
            NewNielsenTVBookID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OldNielsenTVBookID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewNielsenTVBookID() As Integer

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(NielsenTVBookRevision As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBookRevision)

            Me.ID = NielsenTVBookRevision.ID
            Me.OldNielsenTVBookID = NielsenTVBookRevision.OldNielsenTVBookID
            Me.NewNielsenTVBookID = NielsenTVBookRevision.NewNielsenTVBookID

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
