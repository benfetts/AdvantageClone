Namespace EnumUtilities.Attributes

    <AttributeUsage(AttributeTargets.Field)> _
    Public Class EnumObjectAttribute
        Inherits Attribute

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Code As String = ""
        Private _Description As String = ""

#End Region

#Region " Properties "

        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal Code As String, ByVal Description As String)

            _Code = Code
            _Description = Description

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace

