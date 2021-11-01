Namespace Security.Attributes

    <AttributeUsage(AttributeTargets.Field)> _
    Public Class SecuritySettingAttribute
        Inherits Attribute

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ValueType As AdvantageFramework.Security.SettingsValueType = SettingsValueType.StringValue
        Private _ParseValueType As AdvantageFramework.Security.SettingsParseValueType = SettingsParseValueType.Default
        Private _DefaultValue As String = ""

#End Region

#Region " Properties "

        Public Property ValueType() As AdvantageFramework.Security.SettingsValueType
            Get
                ValueType = _ValueType
            End Get
            Set(ByVal value As AdvantageFramework.Security.SettingsValueType)
                _ValueType = value
            End Set
        End Property
        Public Property ParseValueType() As AdvantageFramework.Security.SettingsParseValueType
            Get
                ParseValueType = _ParseValueType
            End Get
            Set(ByVal value As AdvantageFramework.Security.SettingsParseValueType)
                _ParseValueType = value
            End Set
        End Property
        Public Property DefaultValue() As String
            Get
                DefaultValue = _DefaultValue
            End Get
            Set(ByVal value As String)
                _DefaultValue = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ValueType As AdvantageFramework.Security.SettingsValueType, ByVal ParseValueType As AdvantageFramework.Security.SettingsParseValueType, ByVal DefaultValue As String)

            _ValueType = ValueType
            _ParseValueType = ParseValueType
            _DefaultValue = DefaultValue

        End Sub

#End Region

    End Class

End Namespace