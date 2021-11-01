
'===============================================================================
'  Generated From - VbNet_SQL_dOOdads_BusinessEntity.vbgen
' 
'  ** IMPORTANT  **
'  How to Generate your stored procedures:
' 
'  SQL        = SQL_StoredProcs.vbgen
'  ACCESS     = Access_StoredProcs.vbgen
'  ORACLE     = Oracle_StoredProcs.vbgen
'  FIREBIRD   = FirebirdStoredProcs.vbgen
'  POSTGRESQL = PostgreSQL_StoredProcs.vbgen
'
'  The supporting base class SqlClientEntity is in the Architecture directory in "dOOdads".
'  
'  This object is 'MustInherit' which means you need to inherit from it to be able
'  to instantiate it.  This is very easilly done. You can Override properties and
'  methods in your derived class, this allows you to regenerate this class at any
'  time and not worry about overwriting custom code. 
'
'  NEVER EDIT THIS FILE.
'
'  Public Class YourObject
'    Inherits _YourObject
'
'  End Class
'
'===============================================================================

' Generated by MyGeneration Version # (1.2.0.2)

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Collections.Specialized

Imports MyGeneration.dOOdads

Public MustInherit Class _ALERT_ATTACHMENT
    Inherits SqlClientEntity

    Public Sub New()
        Me.QuerySource = "ALERT_ATTACHMENT"
        Me.MappingName = "ALERT_ATTACHMENT"
    End Sub

    '=================================================================
    '  Public Overrides Sub AddNew()
    '=================================================================
    '
    '=================================================================
    Public Overrides Sub AddNew()
        MyBase.AddNew()

    End Sub

    Public Overrides Sub FlushData()
        Me._whereClause = Nothing
        Me._aggregateClause = Nothing
        MyBase.FlushData()
    End Sub


    '=================================================================
    '  	Public Function LoadAll() As Boolean
    '=================================================================
    '  Loads all of the records in the database, and sets the currentRow to the first row
    '=================================================================
    Public Function LoadAll() As Boolean

        Dim parameters As ListDictionary = Nothing


        Return MyBase.LoadFromSql("[" + Me.SchemaStoredProcedure + "proc_ALERT_ATTACHMENTLoadAll]", parameters)

    End Function

    '=================================================================
    ' Public Overridable Function LoadByPrimaryKey()  As Boolean
    '=================================================================
    '  Loads a single row of via the primary key
    '=================================================================
    Public Overridable Function LoadByPrimaryKey(ByVal ATTACHMENT_ID As Integer) As Boolean

        Dim parameters As ListDictionary = New ListDictionary()
        parameters.Add(_ALERT_ATTACHMENT.Parameters.ATTACHMENT_ID, ATTACHMENT_ID)


        Return MyBase.LoadFromSql("[" + Me.SchemaStoredProcedure + "proc_ALERT_ATTACHMENTLoadByPrimaryKey]", parameters)

    End Function

#Region "Parameters"
    Protected Class Parameters

        Public Shared ReadOnly Property ATTACHMENT_ID() As SqlParameter
            Get
                Return New SqlParameter("@ATTACHMENT_ID", SqlDbType.Int, 0)
            End Get
        End Property

        Public Shared ReadOnly Property ALERT_ID() As SqlParameter
            Get
                Return New SqlParameter("@ALERT_ID", SqlDbType.Int, 0)
            End Get
        End Property

        Public Shared ReadOnly Property USER_CODE() As SqlParameter
            Get
                Return New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            End Get
        End Property

        Public Shared ReadOnly Property GENERATED_DATE() As SqlParameter
            Get
                Return New SqlParameter("@GENERATED_DATE", SqlDbType.SmallDateTime, 0)
            End Get
        End Property

        Public Shared ReadOnly Property EMAILSENT() As SqlParameter
            Get
                Return New SqlParameter("@EMAILSENT", SqlDbType.Bit, 0)
            End Get
        End Property

        Public Shared ReadOnly Property DOCUMENT_ID() As SqlParameter
            Get
                Return New SqlParameter("@DOCUMENT_ID", SqlDbType.Int, 0)
            End Get
        End Property

        Public Shared ReadOnly Property USER_CODE_CP() As SqlParameter
            Get
                Return New SqlParameter("@USER_CODE_CP", SqlDbType.Int, 0)
            End Get
        End Property

    End Class
#End Region

#Region "ColumnNames"
    Public Class ColumnNames

        Public Const ATTACHMENT_ID As String = "ATTACHMENT_ID"
        Public Const ALERT_ID As String = "ALERT_ID"
        Public Const USER_CODE As String = "USER_CODE"
        Public Const GENERATED_DATE As String = "GENERATED_DATE"
        Public Const EMAILSENT As String = "EMAILSENT"
        Public Const DOCUMENT_ID As String = "DOCUMENT_ID"
        Public Const USER_CODE_CP As String = "USER_CODE_CP"

        Public Shared Function ToPropertyName(ByVal columnName As String) As String

            If ht Is Nothing Then

                ht = New Hashtable

                ht(ATTACHMENT_ID) = _ALERT_ATTACHMENT.PropertyNames.ATTACHMENT_ID
                ht(ALERT_ID) = _ALERT_ATTACHMENT.PropertyNames.ALERT_ID
                ht(USER_CODE) = _ALERT_ATTACHMENT.PropertyNames.USER_CODE
                ht(GENERATED_DATE) = _ALERT_ATTACHMENT.PropertyNames.GENERATED_DATE
                ht(EMAILSENT) = _ALERT_ATTACHMENT.PropertyNames.EMAILSENT
                ht(DOCUMENT_ID) = _ALERT_ATTACHMENT.PropertyNames.DOCUMENT_ID
                ht(USER_CODE_CP) = _ALERT_ATTACHMENT.PropertyNames.USER_CODE_CP

            End If

            Return CType(ht(columnName), String)

        End Function

        Private Shared ht As Hashtable = Nothing
    End Class
#End Region

#Region "PropertyNames"
    Public Class PropertyNames

        Public Const ATTACHMENT_ID As String = "ATTACHMENT_ID"
        Public Const ALERT_ID As String = "ALERT_ID"
        Public Const USER_CODE As String = "USER_CODE"
        Public Const GENERATED_DATE As String = "GENERATED_DATE"
        Public Const EMAILSENT As String = "EMAILSENT"
        Public Const DOCUMENT_ID As String = "DOCUMENT_ID"
        Public Const USER_CODE_CP As String = "USER_CODE_CP"

        Public Shared Function ToColumnName(ByVal propertyName As String) As String

            If ht Is Nothing Then

                ht = New Hashtable

                ht(ATTACHMENT_ID) = _ALERT_ATTACHMENT.ColumnNames.ATTACHMENT_ID
                ht(ALERT_ID) = _ALERT_ATTACHMENT.ColumnNames.ALERT_ID
                ht(USER_CODE) = _ALERT_ATTACHMENT.ColumnNames.USER_CODE
                ht(GENERATED_DATE) = _ALERT_ATTACHMENT.ColumnNames.GENERATED_DATE
                ht(EMAILSENT) = _ALERT_ATTACHMENT.ColumnNames.EMAILSENT
                ht(DOCUMENT_ID) = _ALERT_ATTACHMENT.ColumnNames.DOCUMENT_ID
                ht(USER_CODE_CP) = _ALERT_ATTACHMENT.ColumnNames.USER_CODE_CP

            End If

            Return CType(ht(propertyName), String)

        End Function

        Private Shared ht As Hashtable = Nothing

    End Class
#End Region

#Region "StringPropertyNames"
    Public Class StringPropertyNames

        Public Const ATTACHMENT_ID As String = "s_ATTACHMENT_ID"
        Public Const ALERT_ID As String = "s_ALERT_ID"
        Public Const USER_CODE As String = "s_USER_CODE"
        Public Const GENERATED_DATE As String = "s_GENERATED_DATE"
        Public Const EMAILSENT As String = "s_EMAILSENT"
        Public Const DOCUMENT_ID As String = "s_DOCUMENT_ID"
        Public Const USER_CODE_CP As String = "s_USER_CODE_CP"

    End Class
#End Region

#Region "Properties"
    Public Overridable Property ATTACHMENT_ID() As Integer
        Get
            Return MyBase.GetInteger(ColumnNames.ATTACHMENT_ID)
        End Get
        Set(ByVal Value As Integer)
            MyBase.SetInteger(ColumnNames.ATTACHMENT_ID, Value)
        End Set
    End Property

    Public Overridable Property ALERT_ID() As Integer
        Get
            Return MyBase.GetInteger(ColumnNames.ALERT_ID)
        End Get
        Set(ByVal Value As Integer)
            MyBase.SetInteger(ColumnNames.ALERT_ID, Value)
        End Set
    End Property

    Public Overridable Property USER_CODE() As String
        Get
            Return MyBase.GetString(ColumnNames.USER_CODE)
        End Get
        Set(ByVal Value As String)
            MyBase.SetString(ColumnNames.USER_CODE, Value)
        End Set
    End Property

    Public Overridable Property GENERATED_DATE() As DateTime
        Get
            Return MyBase.GetDateTime(ColumnNames.GENERATED_DATE)
        End Get
        Set(ByVal Value As DateTime)
            MyBase.SetDateTime(ColumnNames.GENERATED_DATE, Value)
        End Set
    End Property

    Public Overridable Property EMAILSENT() As Boolean
        Get
            Return MyBase.GetBoolean(ColumnNames.EMAILSENT)
        End Get
        Set(ByVal Value As Boolean)
            MyBase.SetBoolean(ColumnNames.EMAILSENT, Value)
        End Set
    End Property

    Public Overridable Property DOCUMENT_ID() As Integer
        Get
            Return MyBase.GetInteger(ColumnNames.DOCUMENT_ID)
        End Get
        Set(ByVal Value As Integer)
            MyBase.SetInteger(ColumnNames.DOCUMENT_ID, Value)
        End Set
    End Property

    Public Overridable Property USER_CODE_CP() As Integer
        Get
            Return MyBase.GetInteger(ColumnNames.USER_CODE_CP)
        End Get
        Set(ByVal Value As Integer)
            MyBase.SetInteger(ColumnNames.USER_CODE_CP, Value)
        End Set
    End Property


#End Region

#Region "String Properties"

    Public Overridable Property s_ATTACHMENT_ID() As String
        Get
            If Me.IsColumnNull(ColumnNames.ATTACHMENT_ID) Then
                Return String.Empty
            Else
                Return MyBase.GetIntegerAsString(ColumnNames.ATTACHMENT_ID)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.ATTACHMENT_ID)
            Else
                Me.ATTACHMENT_ID = MyBase.SetIntegerAsString(ColumnNames.ATTACHMENT_ID, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_ALERT_ID() As String
        Get
            If Me.IsColumnNull(ColumnNames.ALERT_ID) Then
                Return String.Empty
            Else
                Return MyBase.GetIntegerAsString(ColumnNames.ALERT_ID)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.ALERT_ID)
            Else
                Me.ALERT_ID = MyBase.SetIntegerAsString(ColumnNames.ALERT_ID, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_USER_CODE() As String
        Get
            If Me.IsColumnNull(ColumnNames.USER_CODE) Then
                Return String.Empty
            Else
                Return MyBase.GetStringAsString(ColumnNames.USER_CODE)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.USER_CODE)
            Else
                Me.USER_CODE = MyBase.SetStringAsString(ColumnNames.USER_CODE, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_GENERATED_DATE() As String
        Get
            If Me.IsColumnNull(ColumnNames.GENERATED_DATE) Then
                Return String.Empty
            Else
                Return MyBase.GetDateTimeAsString(ColumnNames.GENERATED_DATE)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.GENERATED_DATE)
            Else
                Me.GENERATED_DATE = MyBase.SetDateTimeAsString(ColumnNames.GENERATED_DATE, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_EMAILSENT() As String
        Get
            If Me.IsColumnNull(ColumnNames.EMAILSENT) Then
                Return String.Empty
            Else
                Return MyBase.GetBooleanAsString(ColumnNames.EMAILSENT)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.EMAILSENT)
            Else
                Me.EMAILSENT = MyBase.SetBooleanAsString(ColumnNames.EMAILSENT, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_DOCUMENT_ID() As String
        Get
            If Me.IsColumnNull(ColumnNames.DOCUMENT_ID) Then
                Return String.Empty
            Else
                Return MyBase.GetIntegerAsString(ColumnNames.DOCUMENT_ID)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.DOCUMENT_ID)
            Else
                Me.DOCUMENT_ID = MyBase.SetIntegerAsString(ColumnNames.DOCUMENT_ID, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_USER_CODE_CP() As String
        Get
            If Me.IsColumnNull(ColumnNames.USER_CODE_CP) Then
                Return String.Empty
            Else
                Return MyBase.GetIntegerAsString(ColumnNames.USER_CODE_CP)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = Value Then
                Me.SetColumnNull(ColumnNames.USER_CODE_CP)
            Else
                Me.USER_CODE_CP = MyBase.SetIntegerAsString(ColumnNames.USER_CODE_CP, Value)
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


            Public ReadOnly Property ATTACHMENT_ID() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.ATTACHMENT_ID, Parameters.ATTACHMENT_ID)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property ALERT_ID() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.ALERT_ID, Parameters.ALERT_ID)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property USER_CODE() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.USER_CODE, Parameters.USER_CODE)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property GENERATED_DATE() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.GENERATED_DATE, Parameters.GENERATED_DATE)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property EMAILSENT() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.EMAILSENT, Parameters.EMAILSENT)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property DOCUMENT_ID() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.DOCUMENT_ID, Parameters.DOCUMENT_ID)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property USER_CODE_CP() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.USER_CODE_CP, Parameters.USER_CODE_CP)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property


            Private _clause As WhereClause
        End Class
#End Region

        Public ReadOnly Property ATTACHMENT_ID() As WhereParameter
            Get
                If _ATTACHMENT_ID_W Is Nothing Then
                    _ATTACHMENT_ID_W = TearOff.ATTACHMENT_ID
                End If
                Return _ATTACHMENT_ID_W
            End Get
        End Property

        Public ReadOnly Property ALERT_ID() As WhereParameter
            Get
                If _ALERT_ID_W Is Nothing Then
                    _ALERT_ID_W = TearOff.ALERT_ID
                End If
                Return _ALERT_ID_W
            End Get
        End Property

        Public ReadOnly Property USER_CODE() As WhereParameter
            Get
                If _USER_CODE_W Is Nothing Then
                    _USER_CODE_W = TearOff.USER_CODE
                End If
                Return _USER_CODE_W
            End Get
        End Property

        Public ReadOnly Property GENERATED_DATE() As WhereParameter
            Get
                If _GENERATED_DATE_W Is Nothing Then
                    _GENERATED_DATE_W = TearOff.GENERATED_DATE
                End If
                Return _GENERATED_DATE_W
            End Get
        End Property

        Public ReadOnly Property EMAILSENT() As WhereParameter
            Get
                If _EMAILSENT_W Is Nothing Then
                    _EMAILSENT_W = TearOff.EMAILSENT
                End If
                Return _EMAILSENT_W
            End Get
        End Property

        Public ReadOnly Property DOCUMENT_ID() As WhereParameter
            Get
                If _DOCUMENT_ID_W Is Nothing Then
                    _DOCUMENT_ID_W = TearOff.DOCUMENT_ID
                End If
                Return _DOCUMENT_ID_W
            End Get
        End Property

        Public ReadOnly Property USER_CODE_CP() As WhereParameter
            Get
                If _USER_CODE_CP_W Is Nothing Then
                    _USER_CODE_CP_W = TearOff.USER_CODE_CP
                End If
                Return _USER_CODE_CP_W
            End Get
        End Property

        Private _ATTACHMENT_ID_W As WhereParameter = Nothing
        Private _ALERT_ID_W As WhereParameter = Nothing
        Private _USER_CODE_W As WhereParameter = Nothing
        Private _GENERATED_DATE_W As WhereParameter = Nothing
        Private _EMAILSENT_W As WhereParameter = Nothing
        Private _DOCUMENT_ID_W As WhereParameter = Nothing
        Private _USER_CODE_CP_W As WhereParameter = Nothing

        Public Sub WhereClauseReset()

            _ATTACHMENT_ID_W = Nothing
            _ALERT_ID_W = Nothing
            _USER_CODE_W = Nothing
            _USER_CODE_CP_W = Nothing
            _GENERATED_DATE_W = Nothing
            _EMAILSENT_W = Nothing
            _DOCUMENT_ID_W = Nothing
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


            Public ReadOnly Property ATTACHMENT_ID() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.ATTACHMENT_ID, Parameters.ATTACHMENT_ID)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property ALERT_ID() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.ALERT_ID, Parameters.ALERT_ID)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property USER_CODE() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.USER_CODE, Parameters.USER_CODE)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property GENERATED_DATE() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.GENERATED_DATE, Parameters.GENERATED_DATE)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property EMAILSENT() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.EMAILSENT, Parameters.EMAILSENT)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property DOCUMENT_ID() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.DOCUMENT_ID, Parameters.DOCUMENT_ID)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property USER_CODE_CP() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.USER_CODE_CP, Parameters.USER_CODE_CP)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property


            Private _clause As AggregateClause
        End Class
#End Region

        Public ReadOnly Property ATTACHMENT_ID() As AggregateParameter
            Get
                If _ATTACHMENT_ID_W Is Nothing Then
                    _ATTACHMENT_ID_W = TearOff.ATTACHMENT_ID
                End If
                Return _ATTACHMENT_ID_W
            End Get
        End Property

        Public ReadOnly Property ALERT_ID() As AggregateParameter
            Get
                If _ALERT_ID_W Is Nothing Then
                    _ALERT_ID_W = TearOff.ALERT_ID
                End If
                Return _ALERT_ID_W
            End Get
        End Property

        Public ReadOnly Property USER_CODE() As AggregateParameter
            Get
                If _USER_CODE_W Is Nothing Then
                    _USER_CODE_W = TearOff.USER_CODE
                End If
                Return _USER_CODE_W
            End Get
        End Property

        Public ReadOnly Property GENERATED_DATE() As AggregateParameter
            Get
                If _GENERATED_DATE_W Is Nothing Then
                    _GENERATED_DATE_W = TearOff.GENERATED_DATE
                End If
                Return _GENERATED_DATE_W
            End Get
        End Property

        Public ReadOnly Property EMAILSENT() As AggregateParameter
            Get
                If _EMAILSENT_W Is Nothing Then
                    _EMAILSENT_W = TearOff.EMAILSENT
                End If
                Return _EMAILSENT_W
            End Get
        End Property

        Public ReadOnly Property DOCUMENT_ID() As AggregateParameter
            Get
                If _DOCUMENT_ID_W Is Nothing Then
                    _DOCUMENT_ID_W = TearOff.DOCUMENT_ID
                End If
                Return _DOCUMENT_ID_W
            End Get
        End Property

        Public ReadOnly Property USER_CODE_CP() As AggregateParameter
            Get
                If _USER_CODE_CP_W Is Nothing Then
                    _USER_CODE_CP_W = TearOff.USER_CODE_CP
                End If
                Return _USER_CODE_CP_W
            End Get
        End Property

        Private _ATTACHMENT_ID_W As AggregateParameter = Nothing
        Private _ALERT_ID_W As AggregateParameter = Nothing
        Private _USER_CODE_W As AggregateParameter = Nothing
        Private _GENERATED_DATE_W As AggregateParameter = Nothing
        Private _EMAILSENT_W As AggregateParameter = Nothing
        Private _DOCUMENT_ID_W As AggregateParameter = Nothing
        Private _USER_CODE_CP_W As AggregateParameter = Nothing

        Public Sub AggregateClauseReset()

            _ATTACHMENT_ID_W = Nothing
            _ALERT_ID_W = Nothing
            _USER_CODE_W = Nothing
            _GENERATED_DATE_W = Nothing
            _EMAILSENT_W = Nothing
            _DOCUMENT_ID_W = Nothing
            _USER_CODE_CP_W = Nothing
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

        Dim cmd As SqlCommand = New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[" + Me.SchemaStoredProcedure + "proc_ALERT_ATTACHMENTInsert]"

        CreateParameters(cmd)

        Dim p As SqlParameter
        p = cmd.Parameters(Parameters.ATTACHMENT_ID.ParameterName)
        p.Direction = ParameterDirection.Output

        Return cmd

    End Function

    Protected Overrides Function GetUpdateCommand() As IDbCommand

        Dim cmd As SqlCommand = New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[" + Me.SchemaStoredProcedure + "proc_ALERT_ATTACHMENTUpdate]"

        CreateParameters(cmd)

        Return cmd

    End Function

    Protected Overrides Function GetDeleteCommand() As IDbCommand

        Dim cmd As SqlCommand = New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[" + Me.SchemaStoredProcedure + "proc_ALERT_ATTACHMENTDelete]"

        Dim p As SqlParameter
        p = cmd.Parameters.Add(Parameters.ATTACHMENT_ID)
        p.SourceColumn = ColumnNames.ATTACHMENT_ID
        p.SourceVersion = DataRowVersion.Current


        Return cmd

    End Function

    Private Sub CreateParameters(ByVal cmd As SqlCommand)

        Dim p As SqlParameter
        p = cmd.Parameters.Add(Parameters.ATTACHMENT_ID)
        p.SourceColumn = ColumnNames.ATTACHMENT_ID
        p.SourceVersion = DataRowVersion.Current

        p = cmd.Parameters.Add(Parameters.ALERT_ID)
        p.SourceColumn = ColumnNames.ALERT_ID
        p.SourceVersion = DataRowVersion.Current

        p = cmd.Parameters.Add(Parameters.USER_CODE)
        p.SourceColumn = ColumnNames.USER_CODE
        p.SourceVersion = DataRowVersion.Current

        p = cmd.Parameters.Add(Parameters.GENERATED_DATE)
        p.SourceColumn = ColumnNames.GENERATED_DATE
        p.SourceVersion = DataRowVersion.Current

        p = cmd.Parameters.Add(Parameters.EMAILSENT)
        p.SourceColumn = ColumnNames.EMAILSENT
        p.SourceVersion = DataRowVersion.Current

        p = cmd.Parameters.Add(Parameters.DOCUMENT_ID)
        p.SourceColumn = ColumnNames.DOCUMENT_ID
        p.SourceVersion = DataRowVersion.Current

        p = cmd.Parameters.Add(Parameters.USER_CODE_CP)
        p.SourceColumn = ColumnNames.USER_CODE_CP
        p.SourceVersion = DataRowVersion.Current


    End Sub

End Class



