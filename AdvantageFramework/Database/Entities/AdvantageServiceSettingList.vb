Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.ADV_SERVICE_SETTING_LIST")>
    Public Class AdvantageServiceSettingList
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            AdvantageServiceSettingID
            Value
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _AdvantageServiceSettingID As Integer = 0
        Private _Value As Object = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADV_SERVICE_SETTING_LIST_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADV_SERVICE_SETTING_ID", Storage:="_AdvantageServiceSettingID", DBType:="int"), _
        System.ComponentModel.DisplayName("AdvantageServiceSettingID")> _
        Public Property AdvantageServiceSettingID() As Integer
            Get
                AdvantageServiceSettingID = _AdvantageServiceSettingID
            End Get
            Set(ByVal value As Integer)
                _AdvantageServiceSettingID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VALUE", Storage:="_Value", DBType:="sql_variant"), _
        System.ComponentModel.DisplayName("Value")> _
        Public Property Value() As Object
            Get
                Value = _Value
            End Get
            Set(ByVal value As Object)
                _Value = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
