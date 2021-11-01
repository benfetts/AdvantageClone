Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.ADV_SERVICE_SETTING")>
    Public Class AdvantageServiceSetting
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            AdvantageServiceID
            Code
            Description
            Value
            DefaultValue
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _AdvantageServiceID As Integer = 0
        Private _Code As String = ""
        Private _Description As String = ""
        Private _Value As Object = Nothing
        Private _DefaultValue As Object = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADV_SERVICE_SETTING_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADV_SERVICE_ID", Storage:="_AdvantageServiceID", DBType:="int"), _
        System.ComponentModel.DisplayName("AdvantageServiceID")> _
        Public Property AdvantageServiceID() As Integer
            Get
                AdvantageServiceID = _AdvantageServiceID
            End Get
            Set(ByVal value As Integer)
                _AdvantageServiceID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CODE", Storage:="_Code", DbType:="varchar"),
		System.ComponentModel.DisplayName("Code"),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property Code() As String
			Get
				Code = _Code
			End Get
			Set(ByVal value As String)
				_Code = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DESCRIPTION", Storage:="_Description", DbType:="varchar"),
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
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DEFAULT_VALUE", Storage:="_DefaultValue", DBType:="sql_variant"), _
        System.ComponentModel.DisplayName("DefaultValue")> _
        Public Property DefaultValue() As Object
            Get
                DefaultValue = _DefaultValue
            End Get
            Set(ByVal value As Object)
                _DefaultValue = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
