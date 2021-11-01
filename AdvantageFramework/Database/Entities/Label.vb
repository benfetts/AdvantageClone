Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.LABEL")>
    Public Class Label
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
            Description
            HexColor
            CreatedBy
            ParentID
            SequenceNumber
            IsInactive
            IsUserLabel
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _Name As String = ""
        Private _Description As String = ""
        Private _HexColor As String = ""
        Private _CreatedBy As String = ""
        Private _ParentID As System.Nullable(Of Long) = 0
        Private _SequenceNumber As System.Nullable(Of Long) = 0
        Private _IsInactive As System.Nullable(Of Long) = 0
        Private _IsUserLabel As System.Nullable(Of Long) = 0

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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NAME", Storage:="_Name", DbType:="varchar"),
	System.ComponentModel.DisplayName("Name"),
	System.ComponentModel.DataAnnotations.MaxLength(30)>
		Public Property Name() As String
			Get
				Name = _Name
			End Get
			Set(ByVal value As String)
				_Name = value
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="HEX_COLOR", Storage:="_HexColor", DbType:="varchar"),
	System.ComponentModel.DisplayName("HexColor"),
	System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property HexColor() As String
			Get
				HexColor = _HexColor
			End Get
			Set(ByVal value As String)
				_HexColor = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CREATED_BY", Storage:="_CreatedBy", DbType:="varchar"),
	System.ComponentModel.DisplayName("CreatedBy"),
	System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property CreatedBy() As String
            Get
                CreatedBy = _CreatedBy
            End Get
            Set(ByVal value As String)
                _CreatedBy = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PARENT_ID", Storage:="_ParentID", DbType:="int"),
    System.ComponentModel.DisplayName("ParentID")>
        Public Property ParentID() As System.Nullable(Of Long)
            Get
                ParentID = _ParentID
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _ParentID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SEQ_NBR", Storage:="_SequenceNumber", DbType:="smallint"),
    System.ComponentModel.DisplayName("SequenceNumber")>
        Public Property SequenceNumber() As System.Nullable(Of Long)
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _SequenceNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IS_INACTIVE", Storage:="_IsInactive", DbType:="bit"),
    System.ComponentModel.DisplayName("IsInactive")>
        Public Property IsInactive() As System.Nullable(Of Long)
            Get
                IsInactive = _IsInactive
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsInactive = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IS_USER_LABEL", Storage:="_IsUserLabel", DbType:="bit"),
    System.ComponentModel.DisplayName("IsUserLabel")>
        Public Property IsUserLabel() As System.Nullable(Of Long)
            Get
                IsUserLabel = _IsUserLabel
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _IsUserLabel = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

