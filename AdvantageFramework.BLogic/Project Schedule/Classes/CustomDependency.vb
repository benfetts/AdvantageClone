Namespace ProjectSchedule.Classes

    Public Class CustomDependency

#Region "  Enum "

        Public Enum Properties
            ID
            ParentID
            DependentID
            Type
        End Enum

#End Region

#Region "  Variables "

        Private _ID As Integer = Nothing
        Private _ParentID As Nullable(Of Integer) = Nothing
        Private _DependentID As Nullable(Of Integer) = Nothing
        Private _Type As Integer = Nothing

#End Region

#Region "  Properties "

        Public Property ID As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        Public Property ParentID As Nullable(Of Integer)
            Get
                ParentID = _ParentID
            End Get
            Set(value As Nullable(Of Integer))
                _ParentID = value
            End Set
        End Property
        Public Property DependentID As Nullable(Of Integer)
            Get
                DependentID = _DependentID
            End Get
            Set(value As Nullable(Of Integer))
                _DependentID = value
            End Set
        End Property
        Public Property Type As Integer
            Get
                Type = _Type
            End Get
            Set(value As Integer)
                _Type = value
            End Set
        End Property

#End Region

#Region "  Methods "

        Public Sub New()
        End Sub

#End Region

    End Class

End Namespace

