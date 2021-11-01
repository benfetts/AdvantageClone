
'===============================================================================
'  Generated From - VbNet_SQL_dOOdads_View.vbgen
'
'  The supporting base class SqlClientEntity is in the 
'  Architecture directory in "dOOdads".
'===============================================================================

' Generated by MyGeneration Version # (1.2.0.2)

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Collections.Specialized

Imports MyGeneration.dOOdads

Public MustInherit Class _WV_SMTPSETTINGS
    Inherits SqlClientEntity

    Public Sub New()
        Me.QuerySource = "WV_SMTPSETTINGS"
        Me.MappingName = "WV_SMTPSETTINGS"
    End Sub

    '=================================================================
    '  	Public Function LoadAll() As Boolean
    '=================================================================
    '  Loads all of the records in the database, and sets the currentRow to the first row
    '=================================================================
    Public Function LoadAll() As Boolean
        Return MyBase.Query.Load()
    End Function

    Public Overrides Sub FlushData()
        Me._whereClause = Nothing
        Me._aggregateClause = Nothing
        MyBase.FlushData()
    End Sub

#Region "Parameters"
    Protected Class Parameters

        Public Shared ReadOnly Property SMTP_SERVER() As SqlParameter
            Get
                Return New SqlParameter("SMTP_SERVER", SqlDbType.VarChar, 40)
            End Get
        End Property

        Public Shared ReadOnly Property SMTP_SENDER() As SqlParameter
            Get
                Return New SqlParameter("SMTP_SENDER", SqlDbType.VarChar, 50)
            End Get
        End Property

        Public Shared ReadOnly Property EMAIL_USERNAME() As SqlParameter
            Get
                Return New SqlParameter("EMAIL_USERNAME", SqlDbType.VarChar, 50)
            End Get
        End Property

        Public Shared ReadOnly Property EMAIL_PWD() As SqlParameter
            Get
                Return New SqlParameter("EMAIL_PWD", SqlDbType.VarChar, 25)
            End Get
        End Property

    End Class
#End Region

#Region "ColumnNames"
    Public Class ColumnNames

        Public Const SMTP_SERVER As String = "SMTP_SERVER"
        Public Const SMTP_SENDER As String = "SMTP_SENDER"
        Public Const EMAIL_USERNAME As String = "EMAIL_USERNAME"
        Public Const EMAIL_PWD As String = "EMAIL_PWD"

        Public Shared Function ToPropertyName(ByVal columnName As String) As String

            If ht Is Nothing Then

                ht = New Hashtable

                ht(SMTP_SERVER) = _WV_SMTPSETTINGS.PropertyNames.SMTP_SERVER
                ht(SMTP_SENDER) = _WV_SMTPSETTINGS.PropertyNames.SMTP_SENDER
                ht(EMAIL_USERNAME) = _WV_SMTPSETTINGS.PropertyNames.EMAIL_USERNAME
                ht(EMAIL_PWD) = _WV_SMTPSETTINGS.PropertyNames.EMAIL_PWD

            End If

            Return CType(ht(columnName), String)

        End Function

        Private Shared ht As Hashtable = Nothing
    End Class
#End Region

#Region "PropertyNames"
    Public Class PropertyNames

        Public Const SMTP_SERVER As String = "SMTP_SERVER"
        Public Const SMTP_SENDER As String = "SMTP_SENDER"
        Public Const EMAIL_USERNAME As String = "EMAIL_USERNAME"
        Public Const EMAIL_PWD As String = "EMAIL_PWD"

        Public Shared Function ToColumnName(ByVal propertyName As String) As String

            If ht Is Nothing Then

                ht = New Hashtable

                ht(SMTP_SERVER) = _WV_SMTPSETTINGS.ColumnNames.SMTP_SERVER
                ht(SMTP_SENDER) = _WV_SMTPSETTINGS.ColumnNames.SMTP_SENDER
                ht(EMAIL_USERNAME) = _WV_SMTPSETTINGS.ColumnNames.EMAIL_USERNAME
                ht(EMAIL_PWD) = _WV_SMTPSETTINGS.ColumnNames.EMAIL_PWD

            End If

            Return CType(ht(propertyName), String)

        End Function

        Private Shared ht As Hashtable = Nothing

    End Class
#End Region

#Region "StringPropertyNames"
    Public Class StringPropertyNames

        Public Const SMTP_SERVER As String = "s_SMTP_SERVER"
        Public Const SMTP_SENDER As String = "s_SMTP_SENDER"
        Public Const EMAIL_USERNAME As String = "s_EMAIL_USERNAME"
        Public Const EMAIL_PWD As String = "s_EMAIL_PWD"

    End Class
#End Region

#Region "Properties"
    Public Overridable Property SMTP_SERVER() As String
        Get
            Return MyBase.GetString(ColumnNames.SMTP_SERVER)
        End Get
        Set(ByVal Value As String)
            MyBase.SetString(ColumnNames.SMTP_SERVER, Value)
        End Set
    End Property

    Public Overridable Property SMTP_SENDER() As String
        Get
            Return MyBase.GetString(ColumnNames.SMTP_SENDER)
        End Get
        Set(ByVal Value As String)
            MyBase.SetString(ColumnNames.SMTP_SENDER, Value)
        End Set
    End Property

    Public Overridable Property EMAIL_USERNAME() As String
        Get
            Return MyBase.GetString(ColumnNames.EMAIL_USERNAME)
        End Get
        Set(ByVal Value As String)
            MyBase.SetString(ColumnNames.EMAIL_USERNAME, Value)
        End Set
    End Property

    Public Overridable Property EMAIL_PWD() As String
        Get
            Return MyBase.GetString(ColumnNames.EMAIL_PWD)
        End Get
        Set(ByVal Value As String)
            MyBase.SetString(ColumnNames.EMAIL_PWD, Value)
        End Set
    End Property


#End Region

#Region "String Properties"

    Public Overridable Property s_SMTP_SERVER() As String
        Get
            If Me.IsColumnNull(ColumnNames.SMTP_SERVER) Then
                Return String.Empty
            Else
                Return MyBase.GetStringAsString(ColumnNames.SMTP_SERVER)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.SMTP_SERVER)
            Else
                Me.SMTP_SERVER = MyBase.SetStringAsString(ColumnNames.SMTP_SERVER, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_SMTP_SENDER() As String
        Get
            If Me.IsColumnNull(ColumnNames.SMTP_SENDER) Then
                Return String.Empty
            Else
                Return MyBase.GetStringAsString(ColumnNames.SMTP_SENDER)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.SMTP_SENDER)
            Else
                Me.SMTP_SENDER = MyBase.SetStringAsString(ColumnNames.SMTP_SENDER, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_EMAIL_USERNAME() As String
        Get
            If Me.IsColumnNull(ColumnNames.EMAIL_USERNAME) Then
                Return String.Empty
            Else
                Return MyBase.GetStringAsString(ColumnNames.EMAIL_USERNAME)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.EMAIL_USERNAME)
            Else
                Me.EMAIL_USERNAME = MyBase.SetStringAsString(ColumnNames.EMAIL_USERNAME, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_EMAIL_PWD() As String
        Get
            If Me.IsColumnNull(ColumnNames.EMAIL_PWD) Then
                Return String.Empty
            Else
                Return MyBase.GetStringAsString(ColumnNames.EMAIL_PWD)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.EMAIL_PWD)
            Else
                Me.EMAIL_PWD = MyBase.SetStringAsString(ColumnNames.EMAIL_PWD, Value)
            End If
        End Set
    End Property


#End Region

#Region "Where Clause"
    Public Class WhereClause

        Public Sub New(ByVal entity As BusinessEntity)
            Me._entity = entity
        End Sub

        Public ReadOnly Property TearOff() As TearOffWhereParameter
            Get
                If _tearOff Is Nothing Then
                    _tearOff = New TearOffWhereParameter(Me)
                End If

                Return _tearOff
            End Get
        End Property

#Region "TearOff's"
        Public Class TearOffWhereParameter

            Public Sub New(ByVal clause As WhereClause)
                Me._clause = clause
            End Sub


            Public ReadOnly Property SMTP_SERVER() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.SMTP_SERVER, Parameters.SMTP_SERVER)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property SMTP_SENDER() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.SMTP_SENDER, Parameters.SMTP_SENDER)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property EMAIL_USERNAME() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.EMAIL_USERNAME, Parameters.EMAIL_USERNAME)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property EMAIL_PWD() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.EMAIL_PWD, Parameters.EMAIL_PWD)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property


            Private _clause As WhereClause
        End Class
#End Region

        Public ReadOnly Property SMTP_SERVER() As WhereParameter
            Get
                If _SMTP_SERVER_W Is Nothing Then
                    _SMTP_SERVER_W = TearOff.SMTP_SERVER
                End If
                Return _SMTP_SERVER_W
            End Get
        End Property

        Public ReadOnly Property SMTP_SENDER() As WhereParameter
            Get
                If _SMTP_SENDER_W Is Nothing Then
                    _SMTP_SENDER_W = TearOff.SMTP_SENDER
                End If
                Return _SMTP_SENDER_W
            End Get
        End Property

        Public ReadOnly Property EMAIL_USERNAME() As WhereParameter
            Get
                If _EMAIL_USERNAME_W Is Nothing Then
                    _EMAIL_USERNAME_W = TearOff.EMAIL_USERNAME
                End If
                Return _EMAIL_USERNAME_W
            End Get
        End Property

        Public ReadOnly Property EMAIL_PWD() As WhereParameter
            Get
                If _EMAIL_PWD_W Is Nothing Then
                    _EMAIL_PWD_W = TearOff.EMAIL_PWD
                End If
                Return _EMAIL_PWD_W
            End Get
        End Property

        Private _SMTP_SERVER_W As WhereParameter = Nothing
        Private _SMTP_SENDER_W As WhereParameter = Nothing
        Private _EMAIL_USERNAME_W As WhereParameter = Nothing
        Private _EMAIL_PWD_W As WhereParameter = Nothing

        Public Sub WhereClauseReset()

            _SMTP_SERVER_W = Nothing
            _SMTP_SENDER_W = Nothing
            _EMAIL_USERNAME_W = Nothing
            _EMAIL_PWD_W = Nothing
            Me._entity.Query.FlushWhereParameters()

        End Sub

        Private _entity As BusinessEntity
        Private _tearOff As TearOffWhereParameter
    End Class

    Public ReadOnly Property Where() As WhereClause
        Get
            If _whereClause Is Nothing Then
                _whereClause = New WhereClause(Me)
            End If

            Return _whereClause
        End Get
    End Property

    Private _whereClause As WhereClause = Nothing
#End Region

#Region "Aggregate Clause"
    Public Class AggregateClause

        Public Sub New(ByVal entity As BusinessEntity)
            Me._entity = entity
        End Sub

        Public ReadOnly Property TearOff() As TearOffAggregateParameter
            Get
                If _tearOff Is Nothing Then
                    _tearOff = New TearOffAggregateParameter(Me)
                End If

                Return _tearOff
            End Get
        End Property

#Region "AggregateParameter TearOff's"
        Public Class TearOffAggregateParameter

            Public Sub New(ByVal clause As AggregateClause)
                Me._clause = clause
            End Sub


            Public ReadOnly Property SMTP_SERVER() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.SMTP_SERVER, Parameters.SMTP_SERVER)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property SMTP_SENDER() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.SMTP_SENDER, Parameters.SMTP_SENDER)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property EMAIL_USERNAME() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.EMAIL_USERNAME, Parameters.EMAIL_USERNAME)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property EMAIL_PWD() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.EMAIL_PWD, Parameters.EMAIL_PWD)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property


            Private _clause As AggregateClause
        End Class
#End Region

        Public ReadOnly Property SMTP_SERVER() As AggregateParameter
            Get
                If _SMTP_SERVER_W Is Nothing Then
                    _SMTP_SERVER_W = TearOff.SMTP_SERVER
                End If
                Return _SMTP_SERVER_W
            End Get
        End Property

        Public ReadOnly Property SMTP_SENDER() As AggregateParameter
            Get
                If _SMTP_SENDER_W Is Nothing Then
                    _SMTP_SENDER_W = TearOff.SMTP_SENDER
                End If
                Return _SMTP_SENDER_W
            End Get
        End Property

        Public ReadOnly Property EMAIL_USERNAME() As AggregateParameter
            Get
                If _EMAIL_USERNAME_W Is Nothing Then
                    _EMAIL_USERNAME_W = TearOff.EMAIL_USERNAME
                End If
                Return _EMAIL_USERNAME_W
            End Get
        End Property

        Public ReadOnly Property EMAIL_PWD() As AggregateParameter
            Get
                If _EMAIL_PWD_W Is Nothing Then
                    _EMAIL_PWD_W = TearOff.EMAIL_PWD
                End If
                Return _EMAIL_PWD_W
            End Get
        End Property

        Private _SMTP_SERVER_W As AggregateParameter = Nothing
        Private _SMTP_SENDER_W As AggregateParameter = Nothing
        Private _EMAIL_USERNAME_W As AggregateParameter = Nothing
        Private _EMAIL_PWD_W As AggregateParameter = Nothing

        Public Sub AggregateClauseReset()

            _SMTP_SERVER_W = Nothing
            _SMTP_SENDER_W = Nothing
            _EMAIL_USERNAME_W = Nothing
            _EMAIL_PWD_W = Nothing
            Me._entity.Query.FlushAggregateParameters()

        End Sub

        Private _entity As BusinessEntity
        Private _tearOff As TearOffAggregateParameter
    End Class

    Public ReadOnly Property Aggregate() As AggregateClause
        Get
            If _aggregateClause Is Nothing Then
                _aggregateClause = New AggregateClause(Me)
            End If

            Return _aggregateClause
        End Get
    End Property

    Private _aggregateClause As AggregateClause = Nothing
#End Region

    Protected Overrides Function GetInsertCommand() As IDbCommand
        Return Nothing
    End Function

    Protected Overrides Function GetUpdateCommand() As IDbCommand
        Return Nothing
    End Function

    Protected Overrides Function GetDeleteCommand() As IDbCommand
        Return Nothing
    End Function

End Class



