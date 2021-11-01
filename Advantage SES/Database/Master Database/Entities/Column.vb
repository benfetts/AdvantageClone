﻿Namespace Database.MasterDatabase.Entities

    <System.ComponentModel.DataAnnotations.Schema.NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="sys.columns")>
    Public Class Column

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ObjectID
            Name
            ColumnID
            MaxLength
            UserTypeID
            GetFriendlyUserType
            DisplayName
            IsIdentity
            IsNullable
        End Enum

#End Region

#Region " Variables "

        Private _ObjectID As Long = 0
        Private _Name As String = ""
        Private _ColumnID As Integer = 0
        Private _MaxLength As Integer = 0
        Private _UserTypeID As Integer = 0
        Private _DisplayName As String = ""
        Private _IsIdentity As Boolean = False
        Private _IsNullable As Long = 0

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="object_id", Storage:="_ObjectID", DbType:="int"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ObjectID() As Long
            Get
                ObjectID = _ObjectID
            End Get
            Set(value As Long)
                _ObjectID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="name", Storage:="_Name"),
        System.ComponentModel.DisplayName("Name")>
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="column_id", Storage:="_ColumnID", DbType:="int"),
        System.ComponentModel.DisplayName("Column ID")>
        Public Property ColumnID() As Integer
            Get
                ColumnID = _ColumnID
            End Get
            Set(value As Integer)
                _ColumnID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="is_nullable", Storage:="_IsNullable", DbType:="bit"),
        System.ComponentModel.DisplayName("Column ID")>
        Public Property IsNullable() As Long
            Get
                IsNullable = _IsNullable
            End Get
            Set(value As Long)
                _IsNullable = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="max_length", Storage:="_MaxLength", DbType:="smallint"),
        System.ComponentModel.DisplayName("Maximum Length")>
        Public Property MaxLength() As Integer
            Get
                MaxLength = _MaxLength
            End Get
            Set(value As Integer)
                _MaxLength = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="user_type_id", Storage:="_UserTypeID", DbType:="int"),
        System.ComponentModel.DisplayName("User Type ID")>
        Public Property UserTypeID() As Integer
            Get
                UserTypeID = _UserTypeID
            End Get
            Set(value As Integer)
                _UserTypeID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="is_identity", Storage:="_IsIdentity", DbType:="bit"),
        System.ComponentModel.DisplayName("Identity?")>
        Public Property IsIdentity() As Boolean
            Get
                IsIdentity = _IsIdentity
            End Get
            Set(value As Boolean)
                _IsIdentity = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Name

        End Function

#End Region

    End Class

End Namespace
