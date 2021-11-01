Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.AGY_SETTINGS_DTYPE")>
    Public Class SettingDatabaseType
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            DatabaseTypeID
            Precision
            Scale
            Column
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _DatabaseTypeID As Long = 0
        Private _Precision As System.Nullable(Of Long) = 0
        Private _Scale As System.Nullable(Of Long) = 0
        Private _Column As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DTYPE_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADVAN_DTYPE_ID", Storage:="_DatabaseTypeID", DBType:="smallint"), _
        System.ComponentModel.DisplayName("DatabaseTypeID")> _
        Public Property DatabaseTypeID() As Long
            Get
                DatabaseTypeID = _DatabaseTypeID
            End Get
            Set(ByVal value As Long)
                _DatabaseTypeID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_PREC", Storage:="_Precision", DBType:="smallint"), _
        System.ComponentModel.DisplayName("Precision")> _
        Public Property Precision() As System.Nullable(Of Long)
            Get
                Precision = _Precision
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _Precision = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_SCALE", Storage:="_Scale", DBType:="smallint"), _
        System.ComponentModel.DisplayName("Scale")> _
        Public Property Scale() As System.Nullable(Of Long)
            Get
                Scale = _Scale
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _Scale = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_DW_COL", Storage:="_Column", DbType:="varchar"),
		System.ComponentModel.DisplayName("Column"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property Column() As String
            Get
                Column = _Column
            End Get
            Set(ByVal value As String)
                _Column = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
