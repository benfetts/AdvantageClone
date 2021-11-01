Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.JOB_VER_VALUE_LIST")>
    Public Class JobVersionTemplateDetailListValue
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobVersionTemplateDetailID
            Value
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _JobVersionTemplateDetailID As Long = 0
        Private _Value As Object = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JV_VALUE_LIST_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID"),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JV_TMPLT_DTL_ID", Storage:="_JobVersionTemplateDetailID", DbType:="int"), _
        System.ComponentModel.DisplayName("Job Version Template Detail ID"),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)> _
        Public Property JobVersionTemplateDetailID() As Long
            Get
                JobVersionTemplateDetailID = _JobVersionTemplateDetailID
            End Get
            Set(ByVal value As Long)
                _JobVersionTemplateDetailID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JV_VALID_VALUE", Storage:="_Value", DbType:="sql_variant"),
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

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
