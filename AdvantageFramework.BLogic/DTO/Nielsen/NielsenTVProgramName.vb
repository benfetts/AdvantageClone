Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVProgram

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenTVProgramBookID
            StationCode
            QtrHourStartTime
            QtrHourEndTime
            ProgramName
            Subtitle
            TrackageName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenTVProgramBookID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StationCode() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QtrHourStartTime() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QtrHourEndTime() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProgramName() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Subtitle() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TrackageName() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenTVProgram As AdvantageFramework.Nielsen.Database.Entities.NielsenTVProgram)

            Me.ID = NielsenTVProgram.ID
            Me.NielsenTVProgramBookID = NielsenTVProgram.NielsenTVProgramBookID
            Me.StationCode = NielsenTVProgram.StationCode
            Me.QtrHourStartTime = NielsenTVProgram.QtrHourStartTime
            Me.QtrHourEndTime = NielsenTVProgram.QtrHourEndTime
            Me.ProgramName = NielsenTVProgram.ProgramName
            Me.Subtitle = NielsenTVProgram.Subtitle
            Me.TrackageName = NielsenTVProgram.TrackageName

        End Sub

#End Region

    End Class

End Namespace
