Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ResultSet9
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            IsOverBooked
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _IsOverBooked As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        Public Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        Public Property IsOverBooked As Nullable(Of Integer)
            Get
                IsOverBooked = _IsOverBooked
            End Get
            Set(value As Nullable(Of Integer))
                _IsOverBooked = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace