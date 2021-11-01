Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.GRID_ADVANTAGE_COLUMN")>
    Public Class GridAdvantageColumn
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            GridID
            FieldName
            Visible
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = Nothing
        Private _GridID As Long = Nothing
        Private _FieldName As String = Nothing
        Private _Visible As Boolean = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COLUMN_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY"),
        System.ComponentModel.DisplayName("ID")>
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GRID_ID", Storage:="_GridID", DbType:="int"),
        System.ComponentModel.DisplayName("ID")>
        Public Property GridID() As Long
            Get
                GridID = _GridID
            End Get
            Set(ByVal value As Long)
                _GridID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FIELD_NAME", Storage:="_FieldName", DbType:="varchar"),
        System.ComponentModel.DisplayName("FieldName"),
        System.ComponentModel.DataAnnotations.MaxLength(50)>
        Public Property FieldName() As String
            Get
                FieldName = _FieldName
            End Get
            Set(ByVal value As String)
                _FieldName = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VISIBLE", Storage:="_Visible", DbType:="bit"),
        System.ComponentModel.DisplayName("Visible")>
        Public Property Visible() As Boolean
            Get
                Visible = _Visible
            End Get
            Set(ByVal value As Boolean)
                _Visible = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
