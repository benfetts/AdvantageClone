Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.AGY_SETTINGS")>
    Public Class Setting
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            Value
            DefaultValue
            MinimumValue
            MaximumValue
            SettingModuleID
            SettingModuleTabID
            SettingModuleGroupID
            OrderNumber
            SettingDatabaseTypeID
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = ""
        Private _Description As String = ""
        Private _Value As Object = Nothing
        Private _DefaultValue As Object = Nothing
        Private _MinimumValue As System.Nullable(Of Long) = 0
        Private _MaximumValue As System.Nullable(Of Long) = 0
        Private _SettingModuleID As System.Nullable(Of Long) = 0
        Private _SettingModuleTabID As System.Nullable(Of Long) = 0
        Private _SettingModuleGroupID As System.Nullable(Of Long) = 0
        Private _OrderNumber As System.Nullable(Of Long) = 0
        Private _SettingDatabaseTypeID As System.Nullable(Of Long) = 0
        Private _IsInactive As System.Nullable(Of Short) = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_CODE", Storage:="_Code", DbType:="varchar", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("Code"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property Code() As String
			Get
				Code = _Code
			End Get
			Set(ByVal value As String)
				_Code = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_DESC", Storage:="_Description", DbType:="varchar"),
		System.ComponentModel.DisplayName("Description"),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_VALUE", Storage:="_Value", DBType:="sql_variant"), _
        System.ComponentModel.DisplayName("Value")> _
        Public Property Value() As Object
            Get
                Value = _Value
            End Get
            Set(ByVal value As Object)
                _Value = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_DEF", Storage:="_DefaultValue", DBType:="sql_variant"), _
        System.ComponentModel.DisplayName("Default Value")> _
        Public Property DefaultValue() As Object
            Get
                DefaultValue = _DefaultValue
            End Get
            Set(ByVal value As Object)
                _DefaultValue = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_MIN", Storage:="_MinimumValue", DBType:="int"), _
        System.ComponentModel.DisplayName("Minimum Value")> _
        Public Property MinimumValue() As System.Nullable(Of Long)
            Get
                MinimumValue = _MinimumValue
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _MinimumValue = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_MAX", Storage:="_MaximumValue", DBType:="int"), _
        System.ComponentModel.DisplayName("Maximum Value")> _
        Public Property MaximumValue() As System.Nullable(Of Long)
            Get
                MaximumValue = _MaximumValue
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _MaximumValue = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_APP", Storage:="_SettingModuleID", DBType:="smallint"), _
        System.ComponentModel.DisplayName("Setting Module ID")> _
        Public Property SettingModuleID() As System.Nullable(Of Long)
            Get
                SettingModuleID = _SettingModuleID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _SettingModuleID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_TAB", Storage:="_SettingModuleTabID", DBType:="smallint"), _
        System.ComponentModel.DisplayName("Setting Module Tab ID")> _
        Public Property SettingModuleTabID() As System.Nullable(Of Long)
            Get
                SettingModuleTabID = _SettingModuleTabID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _SettingModuleTabID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_GRP", Storage:="_SettingModuleGroupID", DBType:="smallint"), _
        System.ComponentModel.DisplayName("Setting Module Group ID")> _
        Public Property SettingModuleGroupID() As System.Nullable(Of Long)
            Get
                SettingModuleGroupID = _SettingModuleGroupID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _SettingModuleGroupID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_ORDER", Storage:="_OrderNumber", DBType:="int"), _
        System.ComponentModel.DisplayName("Order Number")> _
        Public Property OrderNumber() As System.Nullable(Of Long)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _OrderNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DTYPE_ID", Storage:="_SettingDatabaseTypeID", DBType:="int"),
        System.ComponentModel.DisplayName("Setting Database Type ID")>
        Public Property SettingDatabaseTypeID() As System.Nullable(Of Long)
            Get
                SettingDatabaseTypeID = _SettingDatabaseTypeID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _SettingDatabaseTypeID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INACTIVE_FLAG", Storage:="_IsInactive", DbType:="smallint"),
        System.ComponentModel.DisplayName("Inactive Flag")>
        Public Property IsInactive() As System.Nullable(Of Short)
            Get
                IsInactive = _IsInactive
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
