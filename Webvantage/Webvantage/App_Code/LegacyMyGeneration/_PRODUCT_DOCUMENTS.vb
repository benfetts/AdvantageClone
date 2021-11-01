
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

Public MustInherit Class _PRODUCT_DOCUMENTS
	Inherits SqlClientEntity

		Public Sub New() 
			Me.QuerySource = "PRODUCT_DOCUMENTS"
			Me.MappingName = "PRODUCT_DOCUMENTS"
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
		
		
    	Return MyBase.LoadFromSql("[" + Me.SchemaStoredProcedure + "proc_PRODUCT_DOCUMENTSLoadAll]", parameters)
		
	End Function

	'=================================================================
	' Public Overridable Function LoadByPrimaryKey()  As Boolean
	'=================================================================
	'  Loads a single row of via the primary key
	'=================================================================
	Public Overridable Function LoadByPrimaryKey(ByVal DOCUMENT_ID As Integer) As Boolean

		Dim parameters As ListDictionary = New ListDictionary()
		parameters.Add(_PRODUCT_DOCUMENTS.Parameters.DOCUMENT_ID, DOCUMENT_ID)

		
		Return MyBase.LoadFromSql("[" + Me.SchemaStoredProcedure + "proc_PRODUCT_DOCUMENTSLoadByPrimaryKey]", parameters)

	End Function

	#Region "Parameters"
	Protected class Parameters 
		
		Public Shared ReadOnly Property DOCUMENT_ID As SqlParameter
			Get
				Return New SqlParameter("@DOCUMENT_ID", SqlDbType.Int, 0)
			End Get
		End Property
		
		Public Shared ReadOnly Property CL_CODE As SqlParameter
			Get
				Return New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
			End Get
		End Property
		
		Public Shared ReadOnly Property DIV_CODE As SqlParameter
			Get
				Return New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
			End Get
		End Property
		
		Public Shared ReadOnly Property PRD_CODE As SqlParameter
			Get
				Return New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
			End Get
		End Property
		
	End Class
	#End Region	

	#Region "ColumnNames"
	Public class ColumnNames
		
        Public Const DOCUMENT_ID As String = "DOCUMENT_ID"
        Public Const CL_CODE As String = "CL_CODE"
        Public Const DIV_CODE As String = "DIV_CODE"
        Public Const PRD_CODE As String = "PRD_CODE"

		Shared Public Function ToPropertyName(ByVal columnName As String) As String

			If ht Is Nothing Then
			
				ht = new Hashtable
				
				ht(DOCUMENT_ID) = _PRODUCT_DOCUMENTS.PropertyNames.DOCUMENT_ID
				ht(CL_CODE) = _PRODUCT_DOCUMENTS.PropertyNames.CL_CODE
				ht(DIV_CODE) = _PRODUCT_DOCUMENTS.PropertyNames.DIV_CODE
				ht(PRD_CODE) = _PRODUCT_DOCUMENTS.PropertyNames.PRD_CODE

			End If
			
			Return CType(ht(columnName), String)
			
		End Function
		
		Shared Private ht  As Hashtable = Nothing		 
	End Class
	#End Region	
	
	#Region "PropertyNames"
	Public class PropertyNames
		
        Public Const DOCUMENT_ID As String = "DOCUMENT_ID"
        Public Const CL_CODE As String = "CL_CODE"
        Public Const DIV_CODE As String = "DIV_CODE"
        Public Const PRD_CODE As String = "PRD_CODE"

		Shared Public Function ToColumnName(ByVal propertyName As String) As String

			If ht Is Nothing Then
			
				ht = new Hashtable
				
				ht(DOCUMENT_ID) = _PRODUCT_DOCUMENTS.ColumnNames.DOCUMENT_ID
				ht(CL_CODE) = _PRODUCT_DOCUMENTS.ColumnNames.CL_CODE
				ht(DIV_CODE) = _PRODUCT_DOCUMENTS.ColumnNames.DIV_CODE
				ht(PRD_CODE) = _PRODUCT_DOCUMENTS.ColumnNames.PRD_CODE

			End If
			
			Return CType(ht(propertyName), String)
			
		End Function
		
		Shared Private ht  As Hashtable = Nothing
		
	End Class
	#End Region	
	
	#Region "StringPropertyNames"
	Public class StringPropertyNames
		
        Public Const DOCUMENT_ID As String = "s_DOCUMENT_ID"
        Public Const CL_CODE As String = "s_CL_CODE"
        Public Const DIV_CODE As String = "s_DIV_CODE"
        Public Const PRD_CODE As String = "s_PRD_CODE"

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

		Public Overridable Property CL_CODE As String
			Get
				Return MyBase.GetString(ColumnNames.CL_CODE)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(ColumnNames.CL_CODE, Value)
			End Set
		End Property

		Public Overridable Property DIV_CODE As String
			Get
				Return MyBase.GetString(ColumnNames.DIV_CODE)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(ColumnNames.DIV_CODE, Value)
			End Set
		End Property

		Public Overridable Property PRD_CODE As String
			Get
				Return MyBase.GetString(ColumnNames.PRD_CODE)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(ColumnNames.PRD_CODE, Value)
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

		Public Overridable Property s_CL_CODE As String
			Get
				If Me.IsColumnNull(ColumnNames.CL_CODE) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(ColumnNames.CL_CODE)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.CL_CODE)
				Else
					Me.CL_CODE = MyBase.SetStringAsString(ColumnNames.CL_CODE, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_DIV_CODE As String
			Get
				If Me.IsColumnNull(ColumnNames.DIV_CODE) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(ColumnNames.DIV_CODE)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.DIV_CODE)
				Else
					Me.DIV_CODE = MyBase.SetStringAsString(ColumnNames.DIV_CODE, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_PRD_CODE As String
			Get
				If Me.IsColumnNull(ColumnNames.PRD_CODE) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(ColumnNames.PRD_CODE)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.PRD_CODE)
				Else
					Me.PRD_CODE = MyBase.SetStringAsString(ColumnNames.PRD_CODE, Value)
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

			Public ReadOnly Property CL_CODE() As WhereParameter
				Get
					Dim where As WhereParameter = New WhereParameter(ColumnNames.CL_CODE, Parameters.CL_CODE)
					Me._clause._entity.Query.AddWhereParemeter(where)
					Return where
				End Get
			End Property

			Public ReadOnly Property DIV_CODE() As WhereParameter
				Get
					Dim where As WhereParameter = New WhereParameter(ColumnNames.DIV_CODE, Parameters.DIV_CODE)
					Me._clause._entity.Query.AddWhereParemeter(where)
					Return where
				End Get
			End Property

			Public ReadOnly Property PRD_CODE() As WhereParameter
				Get
					Dim where As WhereParameter = New WhereParameter(ColumnNames.PRD_CODE, Parameters.PRD_CODE)
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

		Public ReadOnly Property CL_CODE() As WhereParameter 
			Get
				If _CL_CODE_W Is Nothing Then
					_CL_CODE_W = TearOff.CL_CODE
				End If
				Return _CL_CODE_W
			End Get
		End Property

		Public ReadOnly Property DIV_CODE() As WhereParameter 
			Get
				If _DIV_CODE_W Is Nothing Then
					_DIV_CODE_W = TearOff.DIV_CODE
				End If
				Return _DIV_CODE_W
			End Get
		End Property

		Public ReadOnly Property PRD_CODE() As WhereParameter 
			Get
				If _PRD_CODE_W Is Nothing Then
					_PRD_CODE_W = TearOff.PRD_CODE
				End If
				Return _PRD_CODE_W
			End Get
		End Property

		Private _DOCUMENT_ID_W As WhereParameter = Nothing
		Private _CL_CODE_W As WhereParameter = Nothing
		Private _DIV_CODE_W As WhereParameter = Nothing
		Private _PRD_CODE_W As WhereParameter = Nothing

			Public Sub WhereClauseReset()

			_DOCUMENT_ID_W = Nothing
			_CL_CODE_W = Nothing
			_DIV_CODE_W = Nothing
			_PRD_CODE_W = Nothing
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

		Public ReadOnly Property CL_CODE() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.CL_CODE, Parameters.CL_CODE)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property DIV_CODE() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.DIV_CODE, Parameters.DIV_CODE)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property PRD_CODE() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.PRD_CODE, Parameters.PRD_CODE)
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

		Public ReadOnly Property CL_CODE() As AggregateParameter 
			Get
				If _CL_CODE_W Is Nothing Then
					_CL_CODE_W = TearOff.CL_CODE
				End If
				Return _CL_CODE_W
			End Get
		End Property

		Public ReadOnly Property DIV_CODE() As AggregateParameter 
			Get
				If _DIV_CODE_W Is Nothing Then
					_DIV_CODE_W = TearOff.DIV_CODE
				End If
				Return _DIV_CODE_W
			End Get
		End Property

		Public ReadOnly Property PRD_CODE() As AggregateParameter 
			Get
				If _PRD_CODE_W Is Nothing Then
					_PRD_CODE_W = TearOff.PRD_CODE
				End If
				Return _PRD_CODE_W
			End Get
		End Property

		Private _DOCUMENT_ID_W As AggregateParameter = Nothing
		Private _CL_CODE_W As AggregateParameter = Nothing
		Private _DIV_CODE_W As AggregateParameter = Nothing
		Private _PRD_CODE_W As AggregateParameter = Nothing

		Public Sub AggregateClauseReset()

		_DOCUMENT_ID_W = Nothing
		_CL_CODE_W = Nothing
		_DIV_CODE_W = Nothing
		_PRD_CODE_W = Nothing
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
		cmd.CommandText = "[" + Me.SchemaStoredProcedure + "proc_PRODUCT_DOCUMENTSInsert]" 
	    
		CreateParameters(cmd)
		    
		Return cmd 

  	End Function
	
	Protected Overrides Function GetUpdateCommand() As IDbCommand
	
		Dim cmd As SqlCommand = New SqlCommand
		cmd.CommandType = CommandType.StoredProcedure    
		cmd.CommandText = "[" + Me.SchemaStoredProcedure + "proc_PRODUCT_DOCUMENTSUpdate]" 
		
		CreateParameters(cmd) 
		    
		Return cmd
	
	End Function	
	
	Protected Overrides Function GetDeleteCommand() As IDbCommand
	
		Dim cmd As SqlCommand = New SqlCommand
		cmd.CommandType = CommandType.StoredProcedure    
		cmd.CommandText = "[" + Me.SchemaStoredProcedure + "proc_PRODUCT_DOCUMENTSDelete]" 
		
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

		p = cmd.Parameters.Add(Parameters.CL_CODE)
		p.SourceColumn = ColumnNames.CL_CODE
		p.SourceVersion = DataRowVersion.Current

		p = cmd.Parameters.Add(Parameters.DIV_CODE)
		p.SourceColumn = ColumnNames.DIV_CODE
		p.SourceVersion = DataRowVersion.Current

		p = cmd.Parameters.Add(Parameters.PRD_CODE)
		p.SourceColumn = ColumnNames.PRD_CODE
		p.SourceVersion = DataRowVersion.Current


	End Sub	

End Class

