Namespace Registry.Attributes

    <AttributeUsage(AttributeTargets.Field)> _
    Public Class RegistryAttribute
        Inherits Attribute

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Section As String = ""
        Private _Key As String = ""
        Private _Default As String = ""

#End Region

#Region " Properties "

        Public Property Section() As String
            Get
                Section = _Section
            End Get
            Set(ByVal value As String)
                _Section = value
            End Set
        End Property
        Public Property Key() As String
            Get
                Key = _Key
            End Get
            Set(ByVal value As String)
                _Key = value
            End Set
        End Property
        Public Property [Default]() As String
            Get
                [Default] = _Default
            End Get
            Set(ByVal value As String)
                _Default = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal Section As String, ByVal Key As String, ByVal [Default] As String)

            _Section = Section
            _Key = Key
            _Default = [Default]

        End Sub

#End Region

    End Class

End Namespace