Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ResultSet4
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CTR
            Year
            WeekOfYear
        End Enum

#End Region

#Region " Variables "

        Private _CTR As Nullable(Of Integer) = Nothing
        Private _Year As Nullable(Of Integer) = Nothing
        Private _WeekOfYear As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        Public Property CTR As Nullable(Of Integer)
            Get
                CTR = _CTR
            End Get
            Set(value As Nullable(Of Integer))
                _CTR = value
            End Set
        End Property
        Public Property Year As Nullable(Of Integer)
            Get
                Year = _Year
            End Get
            Set(value As Nullable(Of Integer))
                _Year = value
            End Set
        End Property
        Public Property WeekOfYear As Nullable(Of Date)
            Get
                WeekOfYear = _WeekOfYear
            End Get
            Set(value As Nullable(Of Date))
                _WeekOfYear = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace