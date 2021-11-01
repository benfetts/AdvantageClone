Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.GRID_ADVANTAGE")>
    Public Class GridAdvantage
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            GridType
            UserCode
            XmlLayout
            GridSubtype
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _GridType As Long = 0
        Private _UserCode As String = ""
        Private _XmlLayout As String = ""
        Private _GridSubtype As System.Nullable(Of Long) = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GRID_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GRID_TYPE", Storage:="_GridType", DBType:="int"), _
        System.ComponentModel.DisplayName("GridType")> _
        Public Property GridType() As Long
            Get
                GridType = _GridType
            End Get
            Set(ByVal value As Long)
                _GridType = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="USER_CODE", Storage:="_UserCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("UserCode"),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(ByVal value As String)
                _UserCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="XML_LAYOUT", Storage:="_XmlLayout", DBType:="nvarchar"), _
        System.ComponentModel.DisplayName("XmlLayout")> _
        Public Property XmlLayout() As String
            Get
                XmlLayout = _XmlLayout
            End Get
            Set(ByVal value As String)
                _XmlLayout = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GRID_SUBTYPE", Storage:="_GridSubtype", DBType:="int"), _
        System.ComponentModel.DisplayName("GridSubtype")> _
        Public Property GridSubtype() As System.Nullable(Of Long)
            Get
                GridSubtype = _GridSubtype
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _GridSubtype = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
