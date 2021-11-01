Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class EmployeeWorkload
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            WorkloadType
            WorkloadHours
        End Enum

#End Region

#Region " Variables "

        Private _WorkloadType As String = Nothing
        Private _WorkloadHours As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        Public Property WorkloadType As String
            Get
                WorkloadType = _WorkloadType
            End Get
            Set(value As String)
                _WorkloadType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="N2")>
        Public Property WorkloadHours As Nullable(Of Decimal)
            Get
                WorkloadHours = _WorkloadHours
            End Get
            Set(value As Nullable(Of Decimal))
                _WorkloadHours = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace


