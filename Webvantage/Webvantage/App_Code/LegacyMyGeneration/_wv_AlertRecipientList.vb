
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

Public MustInherit Class _WV_ALERTRECIPIENTLIST
    Inherits SqlClientEntity

    Public Sub New()
        Me.QuerySource = "WV_ALERTRECIPIENTLIST"
        Me.MappingName = "WV_ALERTRECIPIENTLIST"
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

        Public Shared ReadOnly Property AlertID() As SqlParameter
            Get
                Return New SqlParameter("AlertID", SqlDbType.Int, 0)
            End Get
        End Property

        Public Shared ReadOnly Property AlertRecipientID() As SqlParameter
            Get
                Return New SqlParameter("AlertRecipientID", SqlDbType.Int, 0)
            End Get
        End Property

        Public Shared ReadOnly Property EmpCode() As SqlParameter
            Get
                Return New SqlParameter("EmpCode", SqlDbType.VarChar, 6)
            End Get
        End Property

        Public Shared ReadOnly Property Email() As SqlParameter
            Get
                Return New SqlParameter("Email", SqlDbType.VarChar, 50)
            End Get
        End Property

        Public Shared ReadOnly Property DismissedTS() As SqlParameter
            Get
                Return New SqlParameter("DismissedTS", SqlDbType.SmallDateTime, 0)
            End Get
        End Property

        Public Shared ReadOnly Property NEW_ALERT() As SqlParameter
            Get
                Return New SqlParameter("NEW_ALERT", SqlDbType.SmallInt, 0)
            End Get
        End Property

        Public Shared ReadOnly Property READ_ALERT() As SqlParameter
            Get
                Return New SqlParameter("READ_ALERT", SqlDbType.SmallInt, 0)
            End Get
        End Property

        Public Shared ReadOnly Property UserName() As SqlParameter
            Get
                Return New SqlParameter("UserName", SqlDbType.VarChar, 61)
            End Get
        End Property

        Public Shared ReadOnly Property CURRENT_RCPT() As SqlParameter
            Get
                Return New SqlParameter("CURRENT_RCPT", SqlDbType.SmallInt, 0)
            End Get
        End Property

    End Class
#End Region

#Region "ColumnNames"
    Public Class ColumnNames

        Public Const AlertID As String = "AlertID"
        Public Const AlertRecipientID As String = "AlertRecipientID"
        Public Const EmpCode As String = "EmpCode"
        Public Const Email As String = "Email"
        Public Const DismissedTS As String = "DismissedTS"
        Public Const NEW_ALERT As String = "NEW_ALERT"
        Public Const READ_ALERT As String = "READ_ALERT"
        Public Const UserName As String = "UserName"
        Public Const CURRENT_RCPT As String = "CURRENT_RCPT"

        Public Shared Function ToPropertyName(ByVal columnName As String) As String

            If ht Is Nothing Then

                ht = New Hashtable

                ht(AlertID) = _WV_ALERTRECIPIENTLIST.PropertyNames.AlertID
                ht(AlertRecipientID) = _WV_ALERTRECIPIENTLIST.PropertyNames.AlertRecipientID
                ht(EmpCode) = _WV_ALERTRECIPIENTLIST.PropertyNames.EmpCode
                ht(Email) = _WV_ALERTRECIPIENTLIST.PropertyNames.Email
                ht(DismissedTS) = _WV_ALERTRECIPIENTLIST.PropertyNames.DismissedTS
                ht(NEW_ALERT) = _WV_ALERTRECIPIENTLIST.PropertyNames.NEW_ALERT
                ht(READ_ALERT) = _WV_ALERTRECIPIENTLIST.PropertyNames.READ_ALERT
                ht(UserName) = _WV_ALERTRECIPIENTLIST.PropertyNames.UserName
                ht(CURRENT_RCPT) = _WV_ALERTRECIPIENTLIST.PropertyNames.CURRENT_RCPT

            End If

            Return CType(ht(columnName), String)

        End Function

        Private Shared ht As Hashtable = Nothing
    End Class
#End Region

#Region "PropertyNames"
    Public Class PropertyNames

        Public Const AlertID As String = "AlertID"
        Public Const AlertRecipientID As String = "AlertRecipientID"
        Public Const EmpCode As String = "EmpCode"
        Public Const Email As String = "Email"
        Public Const DismissedTS As String = "DismissedTS"
        Public Const NEW_ALERT As String = "NEW_ALERT"
        Public Const READ_ALERT As String = "READ_ALERT"
        Public Const UserName As String = "UserName"
        Public Const CURRENT_RCPT As String = "CURRENT_RCPT"

        Public Shared Function ToColumnName(ByVal propertyName As String) As String

            If ht Is Nothing Then

                ht = New Hashtable

                ht(AlertID) = _WV_ALERTRECIPIENTLIST.ColumnNames.AlertID
                ht(AlertRecipientID) = _WV_ALERTRECIPIENTLIST.ColumnNames.AlertRecipientID
                ht(EmpCode) = _WV_ALERTRECIPIENTLIST.ColumnNames.EmpCode
                ht(Email) = _WV_ALERTRECIPIENTLIST.ColumnNames.Email
                ht(DismissedTS) = _WV_ALERTRECIPIENTLIST.ColumnNames.DismissedTS
                ht(NEW_ALERT) = _WV_ALERTRECIPIENTLIST.ColumnNames.NEW_ALERT
                ht(READ_ALERT) = _WV_ALERTRECIPIENTLIST.ColumnNames.READ_ALERT
                ht(UserName) = _WV_ALERTRECIPIENTLIST.ColumnNames.UserName
                ht(CURRENT_RCPT) = _WV_ALERTRECIPIENTLIST.ColumnNames.CURRENT_RCPT

            End If

            Return CType(ht(propertyName), String)

        End Function

        Private Shared ht As Hashtable = Nothing

    End Class
#End Region

#Region "StringPropertyNames"
    Public Class StringPropertyNames

        Public Const AlertID As String = "s_AlertID"
        Public Const AlertRecipientID As String = "s_AlertRecipientID"
        Public Const EmpCode As String = "s_EmpCode"
        Public Const Email As String = "s_Email"
        Public Const DismissedTS As String = "s_DismissedTS"
        Public Const NEW_ALERT As String = "s_NEW_ALERT"
        Public Const READ_ALERT As String = "s_READ_ALERT"
        Public Const UserName As String = "s_UserName"
        Public Const CURRENT_RCPT As String = "s_CURRENT_RCPT"

    End Class
#End Region

#Region "Properties"
    Public Overridable Property AlertID() As Integer
        Get
            Return MyBase.GetInteger(ColumnNames.AlertID)
        End Get
        Set(ByVal Value As Integer)
            MyBase.SetInteger(ColumnNames.AlertID, Value)
        End Set
    End Property

    Public Overridable Property AlertRecipientID() As Integer
        Get
            Return MyBase.GetInteger(ColumnNames.AlertRecipientID)
        End Get
        Set(ByVal Value As Integer)
            MyBase.SetInteger(ColumnNames.AlertRecipientID, Value)
        End Set
    End Property

    Public Overridable Property EmpCode() As String
        Get
            Return MyBase.GetString(ColumnNames.EmpCode)
        End Get
        Set(ByVal Value As String)
            MyBase.SetString(ColumnNames.EmpCode, Value)
        End Set
    End Property

    Public Overridable Property Email() As String
        Get
            Return MyBase.GetString(ColumnNames.Email)
        End Get
        Set(ByVal Value As String)
            MyBase.SetString(ColumnNames.Email, Value)
        End Set
    End Property

    Public Overridable Property DismissedTS() As DateTime
        Get
            Return MyBase.GetDateTime(ColumnNames.DismissedTS)
        End Get
        Set(ByVal Value As DateTime)
            MyBase.SetDateTime(ColumnNames.DismissedTS, Value)
        End Set
    End Property

    Public Overridable Property NEW_ALERT() As Short
        Get
            Return MyBase.GetShort(ColumnNames.NEW_ALERT)
        End Get
        Set(ByVal Value As Short)
            MyBase.SetShort(ColumnNames.NEW_ALERT, Value)
        End Set
    End Property

    Public Overridable Property READ_ALERT() As Short
        Get
            Return MyBase.GetShort(ColumnNames.READ_ALERT)
        End Get
        Set(ByVal Value As Short)
            MyBase.SetShort(ColumnNames.READ_ALERT, Value)
        End Set
    End Property

    Public Overridable Property UserName() As String
        Get
            Return MyBase.GetString(ColumnNames.UserName)
        End Get
        Set(ByVal Value As String)
            MyBase.SetString(ColumnNames.UserName, Value)
        End Set
    End Property

    Public Overridable Property CURRENT_RCPT() As Short
        Get
            Return MyBase.GetShort(ColumnNames.CURRENT_RCPT)
        End Get
        Set(ByVal Value As Short)
            MyBase.SetShort(ColumnNames.CURRENT_RCPT, Value)
        End Set
    End Property


#End Region

#Region "String Properties"

    Public Overridable Property s_AlertID() As String
        Get
            If Me.IsColumnNull(ColumnNames.AlertID) Then
                Return String.Empty
            Else
                Return MyBase.GetIntegerAsString(ColumnNames.AlertID)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.AlertID)
            Else
                Me.AlertID = MyBase.SetIntegerAsString(ColumnNames.AlertID, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_AlertRecipientID() As String
        Get
            If Me.IsColumnNull(ColumnNames.AlertRecipientID) Then
                Return String.Empty
            Else
                Return MyBase.GetIntegerAsString(ColumnNames.AlertRecipientID)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.AlertRecipientID)
            Else
                Me.AlertRecipientID = MyBase.SetIntegerAsString(ColumnNames.AlertRecipientID, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_EmpCode() As String
        Get
            If Me.IsColumnNull(ColumnNames.EmpCode) Then
                Return String.Empty
            Else
                Return MyBase.GetStringAsString(ColumnNames.EmpCode)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.EmpCode)
            Else
                Me.EmpCode = MyBase.SetStringAsString(ColumnNames.EmpCode, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_Email() As String
        Get
            If Me.IsColumnNull(ColumnNames.Email) Then
                Return String.Empty
            Else
                Return MyBase.GetStringAsString(ColumnNames.Email)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.Email)
            Else
                Me.Email = MyBase.SetStringAsString(ColumnNames.Email, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_DismissedTS() As String
        Get
            If Me.IsColumnNull(ColumnNames.DismissedTS) Then
                Return String.Empty
            Else
                Return MyBase.GetDateTimeAsString(ColumnNames.DismissedTS)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.DismissedTS)
            Else
                Me.DismissedTS = MyBase.SetDateTimeAsString(ColumnNames.DismissedTS, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_NEW_ALERT() As String
        Get
            If Me.IsColumnNull(ColumnNames.NEW_ALERT) Then
                Return String.Empty
            Else
                Return MyBase.GetShortAsString(ColumnNames.NEW_ALERT)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.NEW_ALERT)
            Else
                Me.NEW_ALERT = MyBase.SetShortAsString(ColumnNames.NEW_ALERT, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_READ_ALERT() As String
        Get
            If Me.IsColumnNull(ColumnNames.READ_ALERT) Then
                Return String.Empty
            Else
                Return MyBase.GetShortAsString(ColumnNames.READ_ALERT)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.READ_ALERT)
            Else
                Me.READ_ALERT = MyBase.SetShortAsString(ColumnNames.READ_ALERT, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_UserName() As String
        Get
            If Me.IsColumnNull(ColumnNames.UserName) Then
                Return String.Empty
            Else
                Return MyBase.GetStringAsString(ColumnNames.UserName)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.UserName)
            Else
                Me.UserName = MyBase.SetStringAsString(ColumnNames.UserName, Value)
            End If
        End Set
    End Property

    Public Overridable Property s_CURRENT_RCPT() As String
        Get
            If Me.IsColumnNull(ColumnNames.CURRENT_RCPT) Then
                Return String.Empty
            Else
                Return MyBase.GetShortAsString(ColumnNames.CURRENT_RCPT)
            End If
        End Get
        Set(ByVal Value As String)
            If String.Empty = value Then
                Me.SetColumnNull(ColumnNames.CURRENT_RCPT)
            Else
                Me.CURRENT_RCPT = MyBase.SetShortAsString(ColumnNames.CURRENT_RCPT, Value)
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


            Public ReadOnly Property AlertID() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.AlertID, Parameters.AlertID)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property AlertRecipientID() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.AlertRecipientID, Parameters.AlertRecipientID)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property EmpCode() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.EmpCode, Parameters.EmpCode)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property Email() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.Email, Parameters.Email)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property DismissedTS() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.DismissedTS, Parameters.DismissedTS)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property NEW_ALERT() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.NEW_ALERT, Parameters.NEW_ALERT)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property READ_ALERT() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.READ_ALERT, Parameters.READ_ALERT)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property UserName() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.UserName, Parameters.UserName)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property CURRENT_RCPT() As WhereParameter
                Get
                    Dim where As WhereParameter = New WhereParameter(ColumnNames.CURRENT_RCPT, Parameters.CURRENT_RCPT)
                    Me._clause._entity.Query.AddWhereParemeter(where)
                    Return where
                End Get
            End Property


            Private _clause As WhereClause
        End Class
#End Region

        Public ReadOnly Property AlertID() As WhereParameter
            Get
                If _AlertID_W Is Nothing Then
                    _AlertID_W = TearOff.AlertID
                End If
                Return _AlertID_W
            End Get
        End Property

        Public ReadOnly Property AlertRecipientID() As WhereParameter
            Get
                If _AlertRecipientID_W Is Nothing Then
                    _AlertRecipientID_W = TearOff.AlertRecipientID
                End If
                Return _AlertRecipientID_W
            End Get
        End Property

        Public ReadOnly Property EmpCode() As WhereParameter
            Get
                If _EmpCode_W Is Nothing Then
                    _EmpCode_W = TearOff.EmpCode
                End If
                Return _EmpCode_W
            End Get
        End Property

        Public ReadOnly Property Email() As WhereParameter
            Get
                If _Email_W Is Nothing Then
                    _Email_W = TearOff.Email
                End If
                Return _Email_W
            End Get
        End Property

        Public ReadOnly Property DismissedTS() As WhereParameter
            Get
                If _DismissedTS_W Is Nothing Then
                    _DismissedTS_W = TearOff.DismissedTS
                End If
                Return _DismissedTS_W
            End Get
        End Property

        Public ReadOnly Property NEW_ALERT() As WhereParameter
            Get
                If _NEW_ALERT_W Is Nothing Then
                    _NEW_ALERT_W = TearOff.NEW_ALERT
                End If
                Return _NEW_ALERT_W
            End Get
        End Property

        Public ReadOnly Property READ_ALERT() As WhereParameter
            Get
                If _READ_ALERT_W Is Nothing Then
                    _READ_ALERT_W = TearOff.READ_ALERT
                End If
                Return _READ_ALERT_W
            End Get
        End Property

        Public ReadOnly Property UserName() As WhereParameter
            Get
                If _UserName_W Is Nothing Then
                    _UserName_W = TearOff.UserName
                End If
                Return _UserName_W
            End Get
        End Property

        Public ReadOnly Property CURRENT_RCPT() As WhereParameter
            Get
                If _CURRENT_RCPT_W Is Nothing Then
                    _CURRENT_RCPT_W = TearOff.CURRENT_RCPT
                End If
                Return _CURRENT_RCPT_W
            End Get
        End Property

        Private _AlertID_W As WhereParameter = Nothing
        Private _AlertRecipientID_W As WhereParameter = Nothing
        Private _EmpCode_W As WhereParameter = Nothing
        Private _Email_W As WhereParameter = Nothing
        Private _DismissedTS_W As WhereParameter = Nothing
        Private _NEW_ALERT_W As WhereParameter = Nothing
        Private _READ_ALERT_W As WhereParameter = Nothing
        Private _UserName_W As WhereParameter = Nothing
        Private _CURRENT_RCPT_W As WhereParameter = Nothing

        Public Sub WhereClauseReset()

            _AlertID_W = Nothing
            _AlertRecipientID_W = Nothing
            _EmpCode_W = Nothing
            _Email_W = Nothing
            _DismissedTS_W = Nothing
            _NEW_ALERT_W = Nothing
            _READ_ALERT_W = Nothing
            _UserName_W = Nothing
            _CURRENT_RCPT_W = Nothing
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


            Public ReadOnly Property AlertID() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.AlertID, Parameters.AlertID)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property AlertRecipientID() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.AlertRecipientID, Parameters.AlertRecipientID)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property EmpCode() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.EmpCode, Parameters.EmpCode)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property Email() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.Email, Parameters.Email)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property DismissedTS() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.DismissedTS, Parameters.DismissedTS)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property NEW_ALERT() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.NEW_ALERT, Parameters.NEW_ALERT)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property READ_ALERT() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.READ_ALERT, Parameters.READ_ALERT)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property UserName() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.UserName, Parameters.UserName)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property

            Public ReadOnly Property CURRENT_RCPT() As AggregateParameter
                Get
                    Dim where As AggregateParameter = New AggregateParameter(ColumnNames.CURRENT_RCPT, Parameters.CURRENT_RCPT)
                    Me._clause._entity.Query.AddAggregateParameter(where)
                    Return where
                End Get
            End Property


            Private _clause As AggregateClause
        End Class
#End Region

        Public ReadOnly Property AlertID() As AggregateParameter
            Get
                If _AlertID_W Is Nothing Then
                    _AlertID_W = TearOff.AlertID
                End If
                Return _AlertID_W
            End Get
        End Property

        Public ReadOnly Property AlertRecipientID() As AggregateParameter
            Get
                If _AlertRecipientID_W Is Nothing Then
                    _AlertRecipientID_W = TearOff.AlertRecipientID
                End If
                Return _AlertRecipientID_W
            End Get
        End Property

        Public ReadOnly Property EmpCode() As AggregateParameter
            Get
                If _EmpCode_W Is Nothing Then
                    _EmpCode_W = TearOff.EmpCode
                End If
                Return _EmpCode_W
            End Get
        End Property

        Public ReadOnly Property Email() As AggregateParameter
            Get
                If _Email_W Is Nothing Then
                    _Email_W = TearOff.Email
                End If
                Return _Email_W
            End Get
        End Property

        Public ReadOnly Property DismissedTS() As AggregateParameter
            Get
                If _DismissedTS_W Is Nothing Then
                    _DismissedTS_W = TearOff.DismissedTS
                End If
                Return _DismissedTS_W
            End Get
        End Property

        Public ReadOnly Property NEW_ALERT() As AggregateParameter
            Get
                If _NEW_ALERT_W Is Nothing Then
                    _NEW_ALERT_W = TearOff.NEW_ALERT
                End If
                Return _NEW_ALERT_W
            End Get
        End Property

        Public ReadOnly Property READ_ALERT() As AggregateParameter
            Get
                If _READ_ALERT_W Is Nothing Then
                    _READ_ALERT_W = TearOff.READ_ALERT
                End If
                Return _READ_ALERT_W
            End Get
        End Property

        Public ReadOnly Property UserName() As AggregateParameter
            Get
                If _UserName_W Is Nothing Then
                    _UserName_W = TearOff.UserName
                End If
                Return _UserName_W
            End Get
        End Property

        Public ReadOnly Property CURRENT_RCPT() As AggregateParameter
            Get
                If _CURRENT_RCPT_W Is Nothing Then
                    _CURRENT_RCPT_W = TearOff.CURRENT_RCPT
                End If
                Return _CURRENT_RCPT_W
            End Get
        End Property

        Private _AlertID_W As AggregateParameter = Nothing
        Private _AlertRecipientID_W As AggregateParameter = Nothing
        Private _EmpCode_W As AggregateParameter = Nothing
        Private _Email_W As AggregateParameter = Nothing
        Private _DismissedTS_W As AggregateParameter = Nothing
        Private _NEW_ALERT_W As AggregateParameter = Nothing
        Private _READ_ALERT_W As AggregateParameter = Nothing
        Private _UserName_W As AggregateParameter = Nothing
        Private _CURRENT_RCPT_W As AggregateParameter = Nothing

        Public Sub AggregateClauseReset()

            _AlertID_W = Nothing
            _AlertRecipientID_W = Nothing
            _EmpCode_W = Nothing
            _Email_W = Nothing
            _DismissedTS_W = Nothing
            _NEW_ALERT_W = Nothing
            _READ_ALERT_W = Nothing
            _UserName_W = Nothing
            _CURRENT_RCPT_W = Nothing
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

