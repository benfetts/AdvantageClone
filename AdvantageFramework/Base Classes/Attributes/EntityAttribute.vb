Namespace BaseClasses.Attributes

    <AttributeUsage(AttributeTargets.Property)> _
    Public Class EntityAttribute
        Inherits Attribute

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _IsRequired As Boolean = False
        Private _DisplayFormat As String = ""
        Private _ShowColumnInGrid As Boolean = True
        Private _IsReadOnlyColumn As Boolean = True
        Private _CustomColumnCaption As String = ""
        Private _PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = Nothing
        Private _IsImportDefaultProperty As Boolean = False
        Private _DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes = DefaultColumnTypes.None
        Private _MaxValue As Double = Nothing
        Private _MinValue As Double = Nothing
        Private _IsAutoFillProperty As Boolean = False

#End Region

#Region " Properties "

        Public Property IsRequired As Boolean
            Get
                IsRequired = _IsRequired
            End Get
            Set(ByVal value As Boolean)
                _IsRequired = value
            End Set
        End Property
        Public Property DisplayFormat As String
            Get
                DisplayFormat = _DisplayFormat
            End Get
            Set(ByVal value As String)
                _DisplayFormat = value
            End Set
        End Property
        Public Property ShowColumnInGrid As Boolean
            Get
                ShowColumnInGrid = _ShowColumnInGrid
            End Get
            Set(ByVal value As Boolean)
                _ShowColumnInGrid = value
            End Set
        End Property
        Public Property IsReadOnlyColumn As Boolean
            Get
                IsReadOnlyColumn = _IsReadOnlyColumn
            End Get
            Set(ByVal value As Boolean)
                _IsReadOnlyColumn = value
            End Set
        End Property
        Public Property CustomColumnCaption As String
            Get
                CustomColumnCaption = _CustomColumnCaption
            End Get
            Set(ByVal value As String)
                _CustomColumnCaption = value
            End Set
        End Property
        Public Property PropertyType As AdvantageFramework.BaseClasses.PropertyTypes
            Get
                PropertyType = _PropertyType
            End Get
            Set(ByVal value As AdvantageFramework.BaseClasses.PropertyTypes)
                _PropertyType = value
            End Set
        End Property
        Public Property IsImportDefaultProperty As Boolean
            Get
                IsImportDefaultProperty = _IsImportDefaultProperty
            End Get
            Set(ByVal value As Boolean)
                _IsImportDefaultProperty = value
            End Set
        End Property
        Public Property DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes
            Get
                DefaultColumnType = _DefaultColumnType
            End Get
            Set(ByVal value As AdvantageFramework.BaseClasses.DefaultColumnTypes)
                _DefaultColumnType = value
            End Set
        End Property
        Public Property MaxValue As Double
            Get
                MaxValue = _MaxValue
            End Get
            Set(ByVal value As Double)
                _MaxValue = value
            End Set
        End Property
        Public Property MinValue As Double
            Get
                MinValue = _MinValue
            End Get
            Set(ByVal value As Double)
                _MinValue = value
            End Set
        End Property
        Public Property IsAutoFillProperty As Boolean
            Get
                IsAutoFillProperty = _IsAutoFillProperty
            End Get
            Set(ByVal value As Boolean)
                _IsAutoFillProperty = value
            End Set
        End Property
        Public Property UseMaxValue As Boolean = False
        Public Property UseMinValue As Boolean = False

#End Region

#Region " Methods "

        Public Sub New(Optional ByVal IsRequired As Boolean = False, Optional ByVal DisplayFormat As String = "",
                       Optional ByVal ShowColumnInGrid As Boolean = True, Optional ByVal IsReadOnlyColumn As Boolean = False,
                       Optional ByVal CustomColumnCaption As String = "",
                       Optional ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = PropertyTypes.Default,
                       Optional ByVal IsImportDefaultProperty As Boolean = False,
                       Optional ByVal DefaultColumnType As AdvantageFramework.BaseClasses.DefaultColumnTypes = DefaultColumnTypes.None,
                       Optional ByVal MaxValue As Double = Nothing, Optional ByVal MinValue As Double = Nothing,
                       Optional ByVal IsAutoFillProperty As Boolean = False)

            _IsRequired = IsRequired
            _DisplayFormat = DisplayFormat
            _ShowColumnInGrid = ShowColumnInGrid
            _IsReadOnlyColumn = IsReadOnlyColumn
            _CustomColumnCaption = CustomColumnCaption
            _PropertyType = PropertyType
            _IsImportDefaultProperty = IsImportDefaultProperty
            _DefaultColumnType = DefaultColumnType
            _MaxValue = MaxValue
            _MinValue = MinValue
            _IsAutoFillProperty = IsAutoFillProperty

        End Sub

#End Region

    End Class

End Namespace