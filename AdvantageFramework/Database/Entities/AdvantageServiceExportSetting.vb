Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.ADV_SERVICE_EXPORT_SETTING")>
    Public Class AdvantageServiceExportSetting
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            AdvantageServiceExportID
            Code
            Description
            Value
            DefaultValue
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _AdvantageServiceExportID As Long = 0
        Private _Code As String = ""
        Private _Description As String = ""
        Private _Value As Object = Nothing
        Private _DefaultValue As Object = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADV_SERVICE_EXPORT_SETTING_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADV_SERVICE_EXPORT_ID", Storage:="_AdvantageServiceExportID", DBType:="int"), _
        System.ComponentModel.DisplayName("AdvantageServiceExportID")> _
        Public Property AdvantageServiceExportID() As Long
            Get
                AdvantageServiceExportID = _AdvantageServiceExportID
            End Get
            Set(ByVal value As Long)
                _AdvantageServiceExportID = value
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VALUE", Storage:="_Value", DbType:="sql_variant"),
		System.ComponentModel.DisplayName("Value"),
		System.ComponentModel.DataAnnotations.MaxLength(8016)>
		Public Property Value() As Object
			Get
				Value = _Value
			End Get
			Set(ByVal value As Object)
				_Value = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DEFAULT_VALUE", Storage:="_DefaultValue", DbType:="sql_variant"),
		System.ComponentModel.DisplayName("DefaultValue"),
		System.ComponentModel.DataAnnotations.MaxLength(8016)>
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
