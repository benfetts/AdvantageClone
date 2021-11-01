Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.AGY_SETTINGS_GRP")>
    Public Class SettingModuleGroup
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SettingModuleID
            SettingModuleTabID
            ID
            Description
        End Enum

#End Region

#Region " Variables "

        Private _SettingModuleID As Long = 0
        Private _SettingModuleTabID As Long = 0
        Private _ID As Long = 0
        Private _Description As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_APP", Storage:="_SettingModuleID", DBType:="smallint"), _
        System.ComponentModel.DisplayName("SettingModuleID")> _
        Public Property SettingModuleID() As Long
            Get
                SettingModuleID = _SettingModuleID
            End Get
            Set(ByVal value As Long)
                _SettingModuleID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_TAB", Storage:="_SettingModuleTabID", DBType:="smallint"), _
        System.ComponentModel.DisplayName("SettingModuleTabID")> _
        Public Property SettingModuleTabID() As Long
            Get
                SettingModuleTabID = _SettingModuleTabID
            End Get
            Set(ByVal value As Long)
                _SettingModuleTabID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_GRP", Storage:="_ID", DBType:="smallint"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GRP_DESC", Storage:="_Description", DbType:="varchar"),
		System.ComponentModel.DisplayName("Description"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
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



#End Region

    End Class

End Namespace
