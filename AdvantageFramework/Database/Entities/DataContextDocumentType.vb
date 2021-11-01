Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.DOCUMENT_TYPE")>
    Public Class DataContextDocumentType
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
            IsInactive
            IsDefault
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _Name As String = ""
        Private _IsInactive As System.Nullable(Of Long) = False
        Private _IsDefault As System.Nullable(Of Boolean) = False

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DOCUMENT_TYPE_ID", Storage:="_ID", DbType:="int"),
        System.ComponentModel.DisplayName("ID")>
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DOCUMENT_TYPE_DESC", Storage:="_Name", DbType:="varchar"),
		System.ComponentModel.DisplayName("Name"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INACTIVE_FLAG", Storage:="_IsInactive", DbType:="bit"),
        System.ComponentModel.DisplayName("IsInactive")>
        Public Property IsInactive() As System.Nullable(Of Boolean)
            Get
                IsInactive = _IsInactive
            End Get
            Set(ByVal value As System.Nullable(Of Boolean))
                _IsInactive = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IS_DEFAULT", Storage:="_IsDefault", DbType:="bit"),
        System.ComponentModel.DisplayName("IsDefault")>
        Public Property IsDefault() As System.Nullable(Of Boolean)
            Get
                IsDefault = _IsDefault
            End Get
            Set(ByVal value As System.Nullable(Of Boolean))
                _IsDefault = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
