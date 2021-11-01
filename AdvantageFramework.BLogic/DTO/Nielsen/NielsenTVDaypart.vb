Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVDaypart

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenDaypartID
            IsHispanic
            TimeZone
            Name
            NumberOfQuarterhours
            MilitaryStartTime
            MilitaryEndTime
            StartMinute
            EndMinute
            UseSegment
            Sunday
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "


        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenDaypartID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsHispanic() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TimeZone() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NumberOfQuarterhours() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MilitaryStartTime() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MilitaryEndTime() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartMinute() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndMinute() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UseSegment() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Sunday() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Monday() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Tuesday() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Wednesday() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Thursday() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Friday() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Saturday() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenTVDaypart As AdvantageFramework.Nielsen.Database.Entities.NielsenTVDaypart)

            Me.ID = NielsenTVDaypart.ID

            Me.NielsenDaypartID = NielsenTVDaypart.NielsenDaypartID
            Me.IsHispanic = NielsenTVDaypart.IsHispanic
            Me.TimeZone = NielsenTVDaypart.TimeZone
            Me.Name = NielsenTVDaypart.Name
            Me.NumberOfQuarterhours = NielsenTVDaypart.NumberOfQuarterhours
            Me.MilitaryStartTime = NielsenTVDaypart.MilitaryStartTime
            Me.MilitaryEndTime = NielsenTVDaypart.MilitaryEndTime
            Me.StartMinute = NielsenTVDaypart.StartMinute
            Me.EndMinute = NielsenTVDaypart.EndMinute
            Me.UseSegment = NielsenTVDaypart.UseSegment
            Me.Sunday = NielsenTVDaypart.Sunday
            Me.Monday = NielsenTVDaypart.Monday
            Me.Tuesday = NielsenTVDaypart.Tuesday
            Me.Wednesday = NielsenTVDaypart.Wednesday
            Me.Thursday = NielsenTVDaypart.Thursday
            Me.Friday = NielsenTVDaypart.Friday
            Me.Saturday = NielsenTVDaypart.Saturday
            Me.IsInactive = NielsenTVDaypart.IsInactive

        End Sub

#End Region

    End Class

End Namespace
