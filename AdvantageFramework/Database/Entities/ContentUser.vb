Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.CONTENT_USER")>
    Public Class ContentUser
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            ContentID
            ContentItemID
            SequenceNumber
            IsVisible
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _UserCode As String = ""
        Private _ContentID As Long = 0
        Private _ContentItemID As Long = 0
        Private _SequenceNumber As System.Nullable(Of Long) = 0
        Private _IsVisible As Long = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
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
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CONTENT_ID", Storage:="_ContentID", DBType:="int"), _
        System.ComponentModel.DisplayName("ContentID")> _
        Public Property ContentID() As Long
            Get
                ContentID = _ContentID
            End Get
            Set(ByVal value As Long)
                _ContentID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CONTENT_ITEM_ID", Storage:="_ContentItemID", DBType:="int"), _
        System.ComponentModel.DisplayName("ContentItemID")> _
        Public Property ContentItemID() As Long
            Get
                ContentItemID = _ContentItemID
            End Get
            Set(ByVal value As Long)
                _ContentItemID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SEQ_NBR", Storage:="_SequenceNumber", DBType:="int"), _
        System.ComponentModel.DisplayName("SequenceNumber")> _
        Public Property SequenceNumber() As System.Nullable(Of Long)
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _SequenceNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IS_VISIBLE", Storage:="_IsVisible", DBType:="bit"), _
        System.ComponentModel.DisplayName("IsVisible")> _
        Public Property IsVisible() As Long
            Get
                IsVisible = _IsVisible
            End Get
            Set(ByVal value As Long)
                _IsVisible = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
