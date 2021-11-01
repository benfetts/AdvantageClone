Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketDetailAutoFill
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DaypartCode
            Length
            Days
            StartTime
            EndTime
            Comments
            ValueAdded
            Bookend
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaypartCode() As String
        Public Property DaypartClear() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Length() As Nullable(Of Short)
        Public Property LengthClear() As Boolean
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Days() As String
        Public Property DaysClear() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartTime() As String
        Public Property StartTimeClear() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndTime() As String
        Public Property EndTimeClear() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comments() As String
        Public Property CommentsClear() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ValueAdded() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Bookend() As Boolean
        Public ReadOnly Property DaysAndTime As AdvantageFramework.DTO.DaysAndTime

#End Region

#Region " Methods "

        Public Sub New()

            Me.DaypartCode = Nothing
            Me.DaypartClear = False
            Me.Length = Nothing
            Me.LengthClear = False
            Me.Days = String.Empty
            Me.DaysClear = False
            Me.StartTime = String.Empty
            Me.StartTimeClear = False
            Me.EndTime = String.Empty
            Me.EndTimeClear = False
            Me.Comments = String.Empty
            Me.CommentsClear = False
            Me.ValueAdded = False
            Me.Bookend = False
            Me.DaysAndTime = New AdvantageFramework.DTO.DaysAndTime

        End Sub

#End Region

    End Class

End Namespace
