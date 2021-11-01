Namespace ProjectSchedule.Classes

    Public Class CustomResource

#Region "  Enum "

        Public Enum Properties
            ID
            IDSort
            ParentID
            Description
            Color
            Image
            CustomField1
        End Enum

#End Region

#Region "  Variables "

        Private _ID As Integer = Nothing
        Private _IDSort As Integer = Nothing
        Private _ParentID As Nullable(Of Integer) = Nothing
        Private _Description As String = Nothing
        Private _Color As System.Drawing.Color = Nothing
        Private _Image As String = Nothing
        Private _CustomField1 As String = Nothing

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
        Public Property IDSort As Integer
            Get
                IDSort = _IDSort
            End Get
            Set(value As Integer)
                _IDSort = value
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
        Public Property Description As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        Public Property Color As System.Drawing.Color
            Get
                Color = _Color
            End Get
            Set(value As System.Drawing.Color)
                _Color = value
            End Set
        End Property
        Public Property Image As String
            Get
                Image = _Image
            End Get
            Set(value As String)
                _Image = value
            End Set
        End Property
        Public Property CustomField1 As String
            Get
                CustomField1 = _CustomField1
            End Get
            Set(value As String)
                _CustomField1 = value
            End Set
        End Property

#End Region

#Region "  Methods "

        Public Sub New()
        End Sub

#End Region

    End Class

End Namespace

