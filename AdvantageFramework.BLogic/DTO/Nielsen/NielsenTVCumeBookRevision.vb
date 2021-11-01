Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVCumeBookRevision

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OldNielsenTVCumeBookID
            NewNielsenTVCumeBookID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OldNielsenTVCumeBookID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewNielsenTVCumeBookID() As Integer

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(NielsenTVCumeBookRevision As AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeBookRevision)

            Me.ID = NielsenTVCumeBookRevision.ID
            Me.OldNielsenTVCumeBookID = NielsenTVCumeBookRevision.OldNielsenTVCumeBookID
            Me.NewNielsenTVCumeBookID = NielsenTVCumeBookRevision.NewNielsenTVCumeBookID

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
