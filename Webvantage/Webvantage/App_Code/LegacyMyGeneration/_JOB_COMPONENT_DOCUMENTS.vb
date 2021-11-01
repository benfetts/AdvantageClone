
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

' Generated by MyGeneration Version # (1.1.5.1)

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Collections.Specialized

Imports MyGeneration.dOOdads

Public MustInherit Class _JOB_COMPONENT_DOCUMENTS
	Inherits SqlClientEntity

		Public Sub New() 
			Me.QuerySource = "JOB_COMPONENT_DOCUMENTS"
			Me.MappingName = "JOB_COMPONENT_DOCUMENTS"
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
		Me._whereClause = nothing
		Me._aggregateClause = nothing		
		MyBase.FlushData()
	End Sub
	
		
	'=================================================================
	'  	Public Function LoadAll() As Boolean
	'=================================================================
	'  Loads all of the records in the database, and sets the currentRow to the first row
	'=================================================================
	Public Function LoadAll() As Boolean
	
		Dim parameters As ListDictionary = Nothing
		
		
    	Return MyBase.LoadFromSql("[" + Me.SchemaStoredProcedure + "proc_JOB_COMPONENT_DOCUMENTSLoadAll]", parameters)
		
	End Function

	'=================================================================
	' Public Overridable Function LoadByPrimaryKey()  As Boolean
	'=================================================================
	'  Loads a single row of via the primary key
	'=================================================================
	Public Overridable Function LoadByPrimaryKey(ByVal DOCUMENT_ID As Integer) As Boolean

		Dim parameters As ListDictionary = New ListDictionary()
		parameters.Add(_JOB_COMPONENT_DOCUMENTS.Parameters.DOCUMENT_ID, DOCUMENT_ID)

		
		Return MyBase.LoadFromSql("[" + Me.SchemaStoredProcedure + "proc_JOB_COMPONENT_DOCUMENTSLoadByPrimaryKey]", parameters)

	End Function

	#Region "Parameters"
	Protected class Parameters 
		
		Public Shared ReadOnly Property DOCUMENT_ID As SqlParameter
			Get
				Return New SqlParameter("@DOCUMENT_ID", SqlDbType.Int, 0)
			End Get
		End Property
		
		Public Shared ReadOnly Property JOB_COMPONENT_NUMBER As SqlParameter
			Get
				Return New SqlParameter("@JOB_COMPONENT_NUMBER", SqlDbType.Int, 0)
			End Get
		End Property
		
		Public Shared ReadOnly Property JOB_NUMBER As SqlParameter
			Get
				Return New SqlParameter("@JOB_NUMBER", SqlDbType.Int, 0)
			End Get
		End Property
		
	End Class
	#End Region	

	#Region "ColumnNames"
	Public class ColumnNames
		
        Public Const DOCUMENT_ID As String = "DOCUMENT_ID"
        Public Const JOB_COMPONENT_NUMBER As String = "JOB_COMPONENT_NUMBER"
        Public Const JOB_NUMBER As String = "JOB_NUMBER"

		Shared Public Function ToPropertyName(ByVal columnName As String) As String

			If ht Is Nothing Then
			
				ht = new Hashtable
				
				ht(DOCUMENT_ID) = _JOB_COMPONENT_DOCUMENTS.PropertyNames.DOCUMENT_ID
				ht(JOB_COMPONENT_NUMBER) = _JOB_COMPONENT_DOCUMENTS.PropertyNames.JOB_COMPONENT_NUMBER
				ht(JOB_NUMBER) = _JOB_COMPONENT_DOCUMENTS.PropertyNames.JOB_NUMBER

			End If
			
			Return CType(ht(columnName), String)
			
		End Function
		
		Shared Private ht  As Hashtable = Nothing		 
	End Class
	#End Region	
	
	#Region "PropertyNames"
	Public class PropertyNames
		
        Public Const DOCUMENT_ID As String = "DOCUMENT_ID"
        Public Const JOB_COMPONENT_NUMBER As String = "JOB_COMPONENT_NUMBER"
        Public Const JOB_NUMBER As String = "JOB_NUMBER"

		Shared Public Function ToColumnName(ByVal propertyName As String) As String

			If ht Is Nothing Then
			
				ht = new Hashtable
				
				ht(DOCUMENT_ID) = _JOB_COMPONENT_DOCUMENTS.ColumnNames.DOCUMENT_ID
				ht(JOB_COMPONENT_NUMBER) = _JOB_COMPONENT_DOCUMENTS.ColumnNames.JOB_COMPONENT_NUMBER
				ht(JOB_NUMBER) = _JOB_COMPONENT_DOCUMENTS.ColumnNames.JOB_NUMBER

			End If
			
			Return CType(ht(propertyName), String)
			
		End Function
		
		Shared Private ht  As Hashtable = Nothing
		
	End Class
	#End Region	
	
	#Region "StringPropertyNames"
	Public class StringPropertyNames
		
        Public Const DOCUMENT_ID As String = "s_DOCUMENT_ID"
        Public Const JOB_COMPONENT_NUMBER As String = "s_JOB_COMPONENT_NUMBER"
        Public Const JOB_NUMBER As String = "s_JOB_NUMBER"

	End Class
	#End Region		
	
	#Region "Properties" 
		Public Overridable Property DOCUMENT_ID As Integer
			Get
				Return MyBase.GetInteger(ColumnNames.DOCUMENT_ID)
			End Get
			Set(ByVal Value As Integer)
				MyBase.SetInteger(ColumnNames.DOCUMENT_ID, Value)
			End Set
		End Property

		Public Overridable Property JOB_COMPONENT_NUMBER As Integer
			Get
				Return MyBase.GetInteger(ColumnNames.JOB_COMPONENT_NUMBER)
			End Get
			Set(ByVal Value As Integer)
				MyBase.SetInteger(ColumnNames.JOB_COMPONENT_NUMBER, Value)
			End Set
		End Property

		Public Overridable Property JOB_NUMBER As Integer
			Get
				Return MyBase.GetInteger(ColumnNames.JOB_NUMBER)
			End Get
			Set(ByVal Value As Integer)
				MyBase.SetInteger(ColumnNames.JOB_NUMBER, Value)
			End Set
		End Property


	#End Region  
	
	#Region "String Properties" 

		Public Overridable Property s_DOCUMENT_ID As String
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

		Public Overridable Property s_JOB_COMPONENT_NUMBER As String
			Get
				If Me.IsColumnNull(ColumnNames.JOB_COMPONENT_NUMBER) Then
					Return String.Empty
				Else
					Return MyBase.GetIntegerAsString(ColumnNames.JOB_COMPONENT_NUMBER)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.JOB_COMPONENT_NUMBER)
				Else
					Me.JOB_COMPONENT_NUMBER = MyBase.SetIntegerAsString(ColumnNames.JOB_COMPONENT_NUMBER, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_JOB_NUMBER As String
			Get
				If Me.IsColumnNull(ColumnNames.JOB_NUMBER) Then
					Return String.Empty
				Else
					Return MyBase.GetIntegerAsString(ColumnNames.JOB_NUMBER)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.JOB_NUMBER)
				Else
					Me.JOB_NUMBER = MyBase.SetIntegerAsString(ColumnNames.JOB_NUMBER, Value)
				End If
			End Set
		End Property


	#End Region  	

	#Region "Where Clause"
    Public Class WhereClause

        Public Sub New(ByVal entity As BusinessEntity)
            Me._entity = entity
        End Sub
		
		Public ReadOnly Property TearOff As TearOffWhereParameter
			Get
				If _tearOff Is Nothing Then
					_tearOff = new TearOffWhereParameter(Me)
				End If

				Return _tearOff
			End Get
		End Property

		#Region "TearOff's"
		Public class TearOffWhereParameter

			Public Sub New(ByVal clause As WhereClause)
				Me._clause = clause
			End Sub
		
	
			Public ReadOnly Property DOCUMENT_ID() As WhereParameter
				Get
					Dim where As WhereParameter = New WhereParameter(ColumnNames.DOCUMENT_ID, Parameters.DOCUMENT_ID)
					Me._clause._entity.Query.AddWhereParemeter(where)
					Return where
				End Get
			End Property

			Public ReadOnly Property JOB_COMPONENT_NUMBER() As WhereParameter
				Get
					Dim where As WhereParameter = New WhereParameter(ColumnNames.JOB_COMPONENT_NUMBER, Parameters.JOB_COMPONENT_NUMBER)
					Me._clause._entity.Query.AddWhereParemeter(where)
					Return where
				End Get
			End Property

			Public ReadOnly Property JOB_NUMBER() As WhereParameter
				Get
					Dim where As WhereParameter = New WhereParameter(ColumnNames.JOB_NUMBER, Parameters.JOB_NUMBER)
					Me._clause._entity.Query.AddWhereParemeter(where)
					Return where
				End Get
			End Property


			Private _clause as WhereClause
		End Class
		#End Region	

		Public ReadOnly Property DOCUMENT_ID() As WhereParameter 
			Get
				If _DOCUMENT_ID_W Is Nothing Then
					_DOCUMENT_ID_W = TearOff.DOCUMENT_ID
				End If
				Return _DOCUMENT_ID_W
			End Get
		End Property

		Public ReadOnly Property JOB_COMPONENT_NUMBER() As WhereParameter 
			Get
				If _JOB_COMPONENT_NUMBER_W Is Nothing Then
					_JOB_COMPONENT_NUMBER_W = TearOff.JOB_COMPONENT_NUMBER
				End If
				Return _JOB_COMPONENT_NUMBER_W
			End Get
		End Property

		Public ReadOnly Property JOB_NUMBER() As WhereParameter 
			Get
				If _JOB_NUMBER_W Is Nothing Then
					_JOB_NUMBER_W = TearOff.JOB_NUMBER
				End If
				Return _JOB_NUMBER_W
			End Get
		End Property

		Private _DOCUMENT_ID_W As WhereParameter = Nothing
		Private _JOB_COMPONENT_NUMBER_W As WhereParameter = Nothing
		Private _JOB_NUMBER_W As WhereParameter = Nothing

			Public Sub WhereClauseReset()

			_DOCUMENT_ID_W = Nothing
			_JOB_COMPONENT_NUMBER_W = Nothing
			_JOB_NUMBER_W = Nothing
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
		
		Public ReadOnly Property TearOff As TearOffAggregateParameter
			Get
				If _tearOff Is Nothing Then
					_tearOff = new TearOffAggregateParameter(Me)
				End If

				Return _tearOff
			End Get
		End Property

		#Region "AggregateParameter TearOff's"
		Public class TearOffAggregateParameter

			Public Sub New(ByVal clause As AggregateClause)
				Me._clause = clause
			End Sub
		
	
		Public ReadOnly Property DOCUMENT_ID() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.DOCUMENT_ID, Parameters.DOCUMENT_ID)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property JOB_COMPONENT_NUMBER() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.JOB_COMPONENT_NUMBER, Parameters.JOB_COMPONENT_NUMBER)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property JOB_NUMBER() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.JOB_NUMBER, Parameters.JOB_NUMBER)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property


			Private _clause as AggregateClause
		End Class
		#End Region	

		Public ReadOnly Property DOCUMENT_ID() As AggregateParameter 
			Get
				If _DOCUMENT_ID_W Is Nothing Then
					_DOCUMENT_ID_W = TearOff.DOCUMENT_ID
				End If
				Return _DOCUMENT_ID_W
			End Get
		End Property

		Public ReadOnly Property JOB_COMPONENT_NUMBER() As AggregateParameter 
			Get
				If _JOB_COMPONENT_NUMBER_W Is Nothing Then
					_JOB_COMPONENT_NUMBER_W = TearOff.JOB_COMPONENT_NUMBER
				End If
				Return _JOB_COMPONENT_NUMBER_W
			End Get
		End Property

		Public ReadOnly Property JOB_NUMBER() As AggregateParameter 
			Get
				If _JOB_NUMBER_W Is Nothing Then
					_JOB_NUMBER_W = TearOff.JOB_NUMBER
				End If
				Return _JOB_NUMBER_W
			End Get
		End Property

		Private _DOCUMENT_ID_W As AggregateParameter = Nothing
		Private _JOB_COMPONENT_NUMBER_W As AggregateParameter = Nothing
		Private _JOB_NUMBER_W As AggregateParameter = Nothing

		Public Sub AggregateClauseReset()

		_DOCUMENT_ID_W = Nothing
		_JOB_COMPONENT_NUMBER_W = Nothing
		_JOB_NUMBER_W = Nothing
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
		cmd.CommandText = "[" + Me.SchemaStoredProcedure + "proc_JOB_COMPONENT_DOCUMENTSInsert]" 
	    
		CreateParameters(cmd)
		    
		Return cmd 

  	End Function
	
	Protected Overrides Function GetUpdateCommand() As IDbCommand
	
		Dim cmd As SqlCommand = New SqlCommand
		cmd.CommandType = CommandType.StoredProcedure    
		cmd.CommandText = "[" + Me.SchemaStoredProcedure + "proc_JOB_COMPONENT_DOCUMENTSUpdate]" 
		
		CreateParameters(cmd) 
		    
		Return cmd
	
	End Function	
	
	Protected Overrides Function GetDeleteCommand() As IDbCommand
	
		Dim cmd As SqlCommand = New SqlCommand
		cmd.CommandType = CommandType.StoredProcedure    
		cmd.CommandText = "[" + Me.SchemaStoredProcedure + "proc_JOB_COMPONENT_DOCUMENTSDelete]" 
		
		Dim p As SqlParameter
		p = cmd.Parameters.Add(Parameters.DOCUMENT_ID)
		p.SourceColumn = ColumnNames.DOCUMENT_ID
		p.SourceVersion = DataRowVersion.Current

  
		Return cmd
	
	End Function	
	
	Private Sub CreateParameters(ByVal cmd As SqlCommand)
	
		Dim p As SqlParameter
		p = cmd.Parameters.Add(Parameters.DOCUMENT_ID)
		p.SourceColumn = ColumnNames.DOCUMENT_ID
		p.SourceVersion = DataRowVersion.Current

		p = cmd.Parameters.Add(Parameters.JOB_COMPONENT_NUMBER)
		p.SourceColumn = ColumnNames.JOB_COMPONENT_NUMBER
		p.SourceVersion = DataRowVersion.Current

		p = cmd.Parameters.Add(Parameters.JOB_NUMBER)
		p.SourceColumn = ColumnNames.JOB_NUMBER
		p.SourceVersion = DataRowVersion.Current


	End Sub	

End Class

