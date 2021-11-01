Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.DOCUMENT_VERSION")>
    Public Class DocumentVersion
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            DocumentID
            UserCode
            CheckOutDate
            CheckInDate
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _DocumentID As Long = 0
        Private _UserCode As String = ""
        Private _CheckOutDate As DateTime = "1/1/1900"
        Private _CheckInDate As System.Nullable(Of DateTime) = "1/1/1900"

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY"),
    System.ComponentModel.DisplayName("ID")>
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DOCUMENT_ID", Storage:="_DocumentID", DbType:="int"),
    System.ComponentModel.DisplayName("DocumentID")>
        Public Property DocumentID() As Long
            Get
                DocumentID = _DocumentID
            End Get
            Set(ByVal value As Long)
                _DocumentID = value
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
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CHECKOUT_DATE", Storage:="_CheckOutDate", DbType:="smalldatetime"),
    System.ComponentModel.DisplayName("CheckOutDate")>
        Public Property CheckOutDate() As DateTime
            Get
                CheckOutDate = _CheckOutDate
            End Get
            Set(ByVal value As DateTime)
                _CheckOutDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CHECKIN_DATE", Storage:="_CheckInDate", DbType:="smalldatetime"),
    System.ComponentModel.DisplayName("CheckInDate")>
        Public Property CheckInDate() As System.Nullable(Of DateTime)
            Get
                CheckInDate = _CheckInDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _CheckInDate = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

