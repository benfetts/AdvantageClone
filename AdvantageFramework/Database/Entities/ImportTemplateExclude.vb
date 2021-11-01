Namespace Database.Entities

    <System.Data.Linq.Mapping.Table(Name:="dbo.IMPORT_TEMPLATE_EXCLUDE")>
    Public Class ImportTemplateExclude
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ImportTemplateID
            FieldName
            ExcludeValue
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _ImportTemplateID As Integer = 0
        Private _FieldName As String = Nothing
        Private _ExcludeValue As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EXCLUDE_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY"),
        System.ComponentModel.DisplayName("ID"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TEMPLATE_ID", Storage:="_ImportTemplateID", DbType:="int"),
        System.ComponentModel.DisplayName("ImportTemplateID"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property ImportTemplateID() As Integer
            Get
                ImportTemplateID = _ImportTemplateID
            End Get
            Set(ByVal value As Integer)
                _ImportTemplateID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FIELD_NAME", Storage:="_FieldName", DbType:="varchar"),
		System.ComponentModel.DisplayName("FieldName"),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
		Public Property FieldName() As String
            Get
                FieldName = _FieldName
            End Get
            Set(ByVal value As String)
                _FieldName = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EXCLUDE_VALUE", Storage:="_ExcludeValue", DbType:="varchar"),
        System.ComponentModel.DisplayName("ExcludeValue")>
        Public Property ExcludeValue() As String
            Get
                ExcludeValue = _ExcludeValue
            End Get
            Set(ByVal value As String)
                _ExcludeValue = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
