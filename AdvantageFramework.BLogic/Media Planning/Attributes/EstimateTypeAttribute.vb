Namespace MediaPlanning.Attributes

    <AttributeUsage(AttributeTargets.Field)> _
    Public Class EstimateTypeAttribute
        Inherits Attribute

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Value
            Name
            Magazine
            Newspaper
            Radio
            Television
            OutOfHome
            Internet
        End Enum

#End Region

#Region " Variables "

        Private _Value As Integer = -1
        Private _Name As String = ""
        Private _Magazine As Boolean = False
        Private _Newspaper As Boolean = False
        Private _Radio As Boolean = False
        Private _Television As Boolean = False
        Private _OutOfHome As Boolean = False
        Private _Internet As Boolean = False

#End Region

#Region " Properties "

        Public Property Value As Integer
            Get
                Value = _Value
            End Get
            Set(ByVal value As Integer)
                _Value = value
            End Set
        End Property
        Public Property Name As String
            Get
                Name = _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Public Property Magazine As Boolean
            Get
                Magazine = _Magazine
            End Get
            Set(ByVal value As Boolean)
                _Magazine = value
            End Set
        End Property
        Public Property Newspaper As Boolean
            Get
                Newspaper = _Newspaper
            End Get
            Set(ByVal value As Boolean)
                _Newspaper = value
            End Set
        End Property
        Public Property Radio As Boolean
            Get
                Radio = _Radio
            End Get
            Set(ByVal value As Boolean)
                _Radio = value
            End Set
        End Property
        Public Property Television As Boolean
            Get
                Television = _Television
            End Get
            Set(ByVal value As Boolean)
                _Television = value
            End Set
        End Property
        Public Property OutOfHome As Boolean
            Get
                OutOfHome = _OutOfHome
            End Get
            Set(ByVal value As Boolean)
                _OutOfHome = value
            End Set
        End Property
        Public Property Internet As Boolean
            Get
                Internet = _Internet
            End Get
            Set(ByVal value As Boolean)
                _Internet = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(Optional ByVal Value As Integer = -1, Optional ByVal Name As String = "",
                       Optional ByVal Magazine As Boolean = True, Optional ByVal Newspaper As Boolean = True, _
                       Optional ByVal Radio As Boolean = True, Optional ByVal Television As Boolean = True, _
                       Optional ByVal OutOfHome As Boolean = True, Optional ByVal Internet As Boolean = True)

            _Value = Value
            _Name = Name
            _Magazine = Magazine
            _Newspaper = Newspaper
            _Radio = Radio
            _Television = Television
            _OutOfHome = OutOfHome
            _Internet = Internet

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace

