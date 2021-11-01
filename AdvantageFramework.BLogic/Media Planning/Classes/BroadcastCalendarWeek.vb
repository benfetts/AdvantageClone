Namespace MediaPlanning.Classes

    <Serializable()>
    Public Class BroadcastCalendarWeek

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Year
            Week
            Month
            WeekDate
        End Enum

#End Region

#Region " Variables "

        Private _Year As Integer = Nothing
        Private _Week As Integer = Nothing
        Private _Month As Integer = Nothing
        Private _WeekDate As Date = Nothing


#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Integer
            Get
                Year = _Year
            End Get
            Set(ByVal value As Integer)
                _Year = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Week() As Integer
            Get
                Week = _Week
            End Get
            Set(ByVal value As Integer)
                _Week = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Month() As Integer
            Get
                Month = _Month
            End Get
            Set(ByVal value As Integer)
                _Month = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WeekDate() As Date
            Get
                WeekDate = _WeekDate
            End Get
            Set(ByVal value As Date)
                _WeekDate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.WeekDate.ToShortDateString

        End Function

#End Region

    End Class

End Namespace