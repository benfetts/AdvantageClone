
'===============================================================================
'  Generated From - VbNet_SQL_dOOdads_View.vbgen
'
'  The supporting base class SqlClientEntity is in the 
'  Architecture directory in "dOOdads".
'===============================================================================

' Generated by MyGeneration Version # (1.1.5.1)

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Collections.Specialized

Imports MyGeneration.dOOdads

Public MustInherit Class _WV_JOB_COMPONENT_DOCUMENTS
	Inherits  SqlClientEntity
	
		Public Sub New() 
			Me.QuerySource = "WV_JOB_COMPONENT_DOCUMENTS"
			Me.MappingName = "WV_JOB_COMPONENT_DOCUMENTS"
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
		Me._whereClause = nothing
		Me._aggregateClause = nothing		
		MyBase.FlushData()
	End Sub	

	#Region "Parameters"
	Protected class Parameters 
		
		Public Shared ReadOnly Property JOB_NUMBER As SqlParameter
			Get
				Return New SqlParameter("JOB_NUMBER", SqlDbType.Int, 0)
			End Get
		End Property
		
		Public Shared ReadOnly Property JOB_COMPONENT_NUMBER As SqlParameter
			Get
				Return New SqlParameter("JOB_COMPONENT_NUMBER", SqlDbType.Int, 0)
			End Get
		End Property
		
		Public Shared ReadOnly Property DOCUMENT_ID As SqlParameter
			Get
				Return New SqlParameter("DOCUMENT_ID", SqlDbType.Int, 0)
			End Get
		End Property
		
		Public Shared ReadOnly Property FILENAME As SqlParameter
			Get
				Return New SqlParameter("FILENAME", SqlDbType.VarChar, 50)
			End Get
		End Property
		
		Public Shared ReadOnly Property MIME_TYPE As SqlParameter
			Get
				Return New SqlParameter("MIME_TYPE", SqlDbType.VarChar, 50)
			End Get
		End Property
		
		Public Shared ReadOnly Property DESCRIPTION As SqlParameter
			Get
				Return New SqlParameter("DESCRIPTION", SqlDbType.VarChar, 200)
			End Get
		End Property
		
		Public Shared ReadOnly Property KEYWORDS As SqlParameter
			Get
				Return New SqlParameter("KEYWORDS", SqlDbType.VarChar, 255)
			End Get
		End Property
		
		Public Shared ReadOnly Property UPLOADED_DATE As SqlParameter
			Get
				Return New SqlParameter("UPLOADED_DATE", SqlDbType.DateTime, 0)
			End Get
		End Property
		
		Public Shared ReadOnly Property USER_CODE As SqlParameter
			Get
				Return New SqlParameter("USER_CODE", SqlDbType.VarChar, 6)
			End Get
		End Property
		
		Public Shared ReadOnly Property FILE_SIZE As SqlParameter
			Get
				Return New SqlParameter("FILE_SIZE", SqlDbType.Int, 0)
			End Get
		End Property
		
		Public Shared ReadOnly Property USER_NAME As SqlParameter
			Get
				Return New SqlParameter("USER_NAME", SqlDbType.VarChar, 30)
			End Get
		End Property
		
		Public Shared ReadOnly Property REPOSITORY_FILENAME As SqlParameter
			Get
				Return New SqlParameter("REPOSITORY_FILENAME", SqlDbType.VarChar, 200)
			End Get
		End Property
		
	End Class
	#End Region	

	#Region "ColumnNames"
	Public class ColumnNames
		
        Public Const JOB_NUMBER As String = "JOB_NUMBER"
        Public Const JOB_COMPONENT_NUMBER As String = "JOB_COMPONENT_NUMBER"
        Public Const DOCUMENT_ID As String = "DOCUMENT_ID"
        Public Const FILENAME As String = "FILENAME"
        Public Const MIME_TYPE As String = "MIME_TYPE"
        Public Const DESCRIPTION As String = "DESCRIPTION"
        Public Const KEYWORDS As String = "KEYWORDS"
        Public Const UPLOADED_DATE As String = "UPLOADED_DATE"
        Public Const USER_CODE As String = "USER_CODE"
        Public Const FILE_SIZE As String = "FILE_SIZE"
        Public Const USER_NAME As String = "USER_NAME"
        Public Const REPOSITORY_FILENAME As String = "REPOSITORY_FILENAME"

		Shared Public Function ToPropertyName(ByVal columnName As String) As String

			If ht Is Nothing Then
			
				ht = new Hashtable
				
				ht(JOB_NUMBER) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.JOB_NUMBER
				ht(JOB_COMPONENT_NUMBER) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.JOB_COMPONENT_NUMBER
				ht(DOCUMENT_ID) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.DOCUMENT_ID
				ht(FILENAME) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.FILENAME
				ht(MIME_TYPE) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.MIME_TYPE
				ht(DESCRIPTION) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.DESCRIPTION
				ht(KEYWORDS) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.KEYWORDS
				ht(UPLOADED_DATE) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.UPLOADED_DATE
				ht(USER_CODE) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.USER_CODE
				ht(FILE_SIZE) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.FILE_SIZE
				ht(USER_NAME) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.USER_NAME
				ht(REPOSITORY_FILENAME) = _WV_JOB_COMPONENT_DOCUMENTS.PropertyNames.REPOSITORY_FILENAME

			End If
			
			Return CType(ht(columnName), String)
			
		End Function
		
		Shared Private ht  As Hashtable = Nothing		 
	End Class
	#End Region	
	
	#Region "PropertyNames"
	Public class PropertyNames
		
        Public Const JOB_NUMBER As String = "JOB_NUMBER"
        Public Const JOB_COMPONENT_NUMBER As String = "JOB_COMPONENT_NUMBER"
        Public Const DOCUMENT_ID As String = "DOCUMENT_ID"
        Public Const FILENAME As String = "FILENAME"
        Public Const MIME_TYPE As String = "MIME_TYPE"
        Public Const DESCRIPTION As String = "DESCRIPTION"
        Public Const KEYWORDS As String = "KEYWORDS"
        Public Const UPLOADED_DATE As String = "UPLOADED_DATE"
        Public Const USER_CODE As String = "USER_CODE"
        Public Const FILE_SIZE As String = "FILE_SIZE"
        Public Const USER_NAME As String = "USER_NAME"
        Public Const REPOSITORY_FILENAME As String = "REPOSITORY_FILENAME"

		Shared Public Function ToColumnName(ByVal propertyName As String) As String

			If ht Is Nothing Then
			
				ht = new Hashtable
				
				ht(JOB_NUMBER) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.JOB_NUMBER
				ht(JOB_COMPONENT_NUMBER) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.JOB_COMPONENT_NUMBER
				ht(DOCUMENT_ID) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.DOCUMENT_ID
				ht(FILENAME) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.FILENAME
				ht(MIME_TYPE) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.MIME_TYPE
				ht(DESCRIPTION) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.DESCRIPTION
				ht(KEYWORDS) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.KEYWORDS
				ht(UPLOADED_DATE) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.UPLOADED_DATE
				ht(USER_CODE) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.USER_CODE
				ht(FILE_SIZE) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.FILE_SIZE
				ht(USER_NAME) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.USER_NAME
				ht(REPOSITORY_FILENAME) = _WV_JOB_COMPONENT_DOCUMENTS.ColumnNames.REPOSITORY_FILENAME

			End If
			
			Return CType(ht(propertyName), String)
			
		End Function
		
		Shared Private ht  As Hashtable = Nothing
		
	End Class
	#End Region	
	
	#Region "StringPropertyNames"
	Public class StringPropertyNames
		
        Public Const JOB_NUMBER As String = "s_JOB_NUMBER"
        Public Const JOB_COMPONENT_NUMBER As String = "s_JOB_COMPONENT_NUMBER"
        Public Const DOCUMENT_ID As String = "s_DOCUMENT_ID"
        Public Const FILENAME As String = "s_FILENAME"
        Public Const MIME_TYPE As String = "s_MIME_TYPE"
        Public Const DESCRIPTION As String = "s_DESCRIPTION"
        Public Const KEYWORDS As String = "s_KEYWORDS"
        Public Const UPLOADED_DATE As String = "s_UPLOADED_DATE"
        Public Const USER_CODE As String = "s_USER_CODE"
        Public Const FILE_SIZE As String = "s_FILE_SIZE"
        Public Const USER_NAME As String = "s_USER_NAME"
        Public Const REPOSITORY_FILENAME As String = "s_REPOSITORY_FILENAME"

	End Class
	#End Region		
	
	#Region "Properties" 
		Public Overridable Property JOB_NUMBER As Integer
			Get
				Return MyBase.GetInteger(ColumnNames.JOB_NUMBER)
			End Get
			Set(ByVal Value As Integer)
				MyBase.SetInteger(ColumnNames.JOB_NUMBER, Value)
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

		Public Overridable Property DOCUMENT_ID As Integer
			Get
				Return MyBase.GetInteger(ColumnNames.DOCUMENT_ID)
			End Get
			Set(ByVal Value As Integer)
				MyBase.SetInteger(ColumnNames.DOCUMENT_ID, Value)
			End Set
		End Property

		Public Overridable Property FILENAME As String
			Get
				Return MyBase.GetString(ColumnNames.FILENAME)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(ColumnNames.FILENAME, Value)
			End Set
		End Property

		Public Overridable Property MIME_TYPE As String
			Get
				Return MyBase.GetString(ColumnNames.MIME_TYPE)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(ColumnNames.MIME_TYPE, Value)
			End Set
		End Property

		Public Overridable Property DESCRIPTION As String
			Get
				Return MyBase.GetString(ColumnNames.DESCRIPTION)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(ColumnNames.DESCRIPTION, Value)
			End Set
		End Property

		Public Overridable Property KEYWORDS As String
			Get
				Return MyBase.GetString(ColumnNames.KEYWORDS)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(ColumnNames.KEYWORDS, Value)
			End Set
		End Property

		Public Overridable Property UPLOADED_DATE As DateTime
			Get
				Return MyBase.GetDateTime(ColumnNames.UPLOADED_DATE)
			End Get
			Set(ByVal Value As DateTime)
				MyBase.SetDateTime(ColumnNames.UPLOADED_DATE, Value)
			End Set
		End Property

		Public Overridable Property USER_CODE As String
			Get
				Return MyBase.GetString(ColumnNames.USER_CODE)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(ColumnNames.USER_CODE, Value)
			End Set
		End Property

		Public Overridable Property FILE_SIZE As Integer
			Get
				Return MyBase.GetInteger(ColumnNames.FILE_SIZE)
			End Get
			Set(ByVal Value As Integer)
				MyBase.SetInteger(ColumnNames.FILE_SIZE, Value)
			End Set
		End Property

		Public Overridable Property USER_NAME As String
			Get
				Return MyBase.GetString(ColumnNames.USER_NAME)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(ColumnNames.USER_NAME, Value)
			End Set
		End Property

		Public Overridable Property REPOSITORY_FILENAME As String
			Get
				Return MyBase.GetString(ColumnNames.REPOSITORY_FILENAME)
			End Get
			Set(ByVal Value As String)
				MyBase.SetString(ColumnNames.REPOSITORY_FILENAME, Value)
			End Set
		End Property


	#End Region  
	
	#Region "String Properties" 

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

		Public Overridable Property s_FILENAME As String
			Get
				If Me.IsColumnNull(ColumnNames.FILENAME) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(ColumnNames.FILENAME)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.FILENAME)
				Else
					Me.FILENAME = MyBase.SetStringAsString(ColumnNames.FILENAME, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_MIME_TYPE As String
			Get
				If Me.IsColumnNull(ColumnNames.MIME_TYPE) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(ColumnNames.MIME_TYPE)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.MIME_TYPE)
				Else
					Me.MIME_TYPE = MyBase.SetStringAsString(ColumnNames.MIME_TYPE, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_DESCRIPTION As String
			Get
				If Me.IsColumnNull(ColumnNames.DESCRIPTION) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(ColumnNames.DESCRIPTION)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.DESCRIPTION)
				Else
					Me.DESCRIPTION = MyBase.SetStringAsString(ColumnNames.DESCRIPTION, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_KEYWORDS As String
			Get
				If Me.IsColumnNull(ColumnNames.KEYWORDS) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(ColumnNames.KEYWORDS)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.KEYWORDS)
				Else
					Me.KEYWORDS = MyBase.SetStringAsString(ColumnNames.KEYWORDS, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_UPLOADED_DATE As String
			Get
				If Me.IsColumnNull(ColumnNames.UPLOADED_DATE) Then
					Return String.Empty
				Else
					Return MyBase.GetDateTimeAsString(ColumnNames.UPLOADED_DATE)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.UPLOADED_DATE)
				Else
					Me.UPLOADED_DATE = MyBase.SetDateTimeAsString(ColumnNames.UPLOADED_DATE, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_USER_CODE As String
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

		Public Overridable Property s_FILE_SIZE As String
			Get
				If Me.IsColumnNull(ColumnNames.FILE_SIZE) Then
					Return String.Empty
				Else
					Return MyBase.GetIntegerAsString(ColumnNames.FILE_SIZE)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.FILE_SIZE)
				Else
					Me.FILE_SIZE = MyBase.SetIntegerAsString(ColumnNames.FILE_SIZE, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_USER_NAME As String
			Get
				If Me.IsColumnNull(ColumnNames.USER_NAME) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(ColumnNames.USER_NAME)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.USER_NAME)
				Else
					Me.USER_NAME = MyBase.SetStringAsString(ColumnNames.USER_NAME, Value)
				End If
			End Set
		End Property

		Public Overridable Property s_REPOSITORY_FILENAME As String
			Get
				If Me.IsColumnNull(ColumnNames.REPOSITORY_FILENAME) Then
					Return String.Empty
				Else
					Return MyBase.GetStringAsString(ColumnNames.REPOSITORY_FILENAME)
				End If
			End Get
			Set(ByVal Value As String)
				If String.Empty = value Then
					Me.SetColumnNull(ColumnNames.REPOSITORY_FILENAME)
				Else
					Me.REPOSITORY_FILENAME = MyBase.SetStringAsString(ColumnNames.REPOSITORY_FILENAME, Value)
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
		
	
		Public ReadOnly Property JOB_NUMBER() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(ColumnNames.JOB_NUMBER, Parameters.JOB_NUMBER)
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

		Public ReadOnly Property DOCUMENT_ID() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(ColumnNames.DOCUMENT_ID, Parameters.DOCUMENT_ID)
				Me._clause._entity.Query.AddWhereParemeter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property FILENAME() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(ColumnNames.FILENAME, Parameters.FILENAME)
				Me._clause._entity.Query.AddWhereParemeter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property MIME_TYPE() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(ColumnNames.MIME_TYPE, Parameters.MIME_TYPE)
				Me._clause._entity.Query.AddWhereParemeter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property DESCRIPTION() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(ColumnNames.DESCRIPTION, Parameters.DESCRIPTION)
				Me._clause._entity.Query.AddWhereParemeter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property KEYWORDS() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(ColumnNames.KEYWORDS, Parameters.KEYWORDS)
				Me._clause._entity.Query.AddWhereParemeter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property UPLOADED_DATE() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(ColumnNames.UPLOADED_DATE, Parameters.UPLOADED_DATE)
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

		Public ReadOnly Property FILE_SIZE() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(ColumnNames.FILE_SIZE, Parameters.FILE_SIZE)
				Me._clause._entity.Query.AddWhereParemeter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property USER_NAME() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(ColumnNames.USER_NAME, Parameters.USER_NAME)
				Me._clause._entity.Query.AddWhereParemeter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property REPOSITORY_FILENAME() As WhereParameter
			Get
				Dim where As WhereParameter = New WhereParameter(ColumnNames.REPOSITORY_FILENAME, Parameters.REPOSITORY_FILENAME)
				Me._clause._entity.Query.AddWhereParemeter(where)
				Return where
			End Get
		End Property


		Private _clause as WhereClause
	End Class
	#End Region	

		Public ReadOnly Property JOB_NUMBER() As WhereParameter 
			Get
				If _JOB_NUMBER_W Is Nothing Then
					_JOB_NUMBER_W = TearOff.JOB_NUMBER
				End If
				Return _JOB_NUMBER_W
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

		Public ReadOnly Property DOCUMENT_ID() As WhereParameter 
			Get
				If _DOCUMENT_ID_W Is Nothing Then
					_DOCUMENT_ID_W = TearOff.DOCUMENT_ID
				End If
				Return _DOCUMENT_ID_W
			End Get
		End Property

		Public ReadOnly Property FILENAME() As WhereParameter 
			Get
				If _FILENAME_W Is Nothing Then
					_FILENAME_W = TearOff.FILENAME
				End If
				Return _FILENAME_W
			End Get
		End Property

		Public ReadOnly Property MIME_TYPE() As WhereParameter 
			Get
				If _MIME_TYPE_W Is Nothing Then
					_MIME_TYPE_W = TearOff.MIME_TYPE
				End If
				Return _MIME_TYPE_W
			End Get
		End Property

		Public ReadOnly Property DESCRIPTION() As WhereParameter 
			Get
				If _DESCRIPTION_W Is Nothing Then
					_DESCRIPTION_W = TearOff.DESCRIPTION
				End If
				Return _DESCRIPTION_W
			End Get
		End Property

		Public ReadOnly Property KEYWORDS() As WhereParameter 
			Get
				If _KEYWORDS_W Is Nothing Then
					_KEYWORDS_W = TearOff.KEYWORDS
				End If
				Return _KEYWORDS_W
			End Get
		End Property

		Public ReadOnly Property UPLOADED_DATE() As WhereParameter 
			Get
				If _UPLOADED_DATE_W Is Nothing Then
					_UPLOADED_DATE_W = TearOff.UPLOADED_DATE
				End If
				Return _UPLOADED_DATE_W
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

		Public ReadOnly Property FILE_SIZE() As WhereParameter 
			Get
				If _FILE_SIZE_W Is Nothing Then
					_FILE_SIZE_W = TearOff.FILE_SIZE
				End If
				Return _FILE_SIZE_W
			End Get
		End Property

		Public ReadOnly Property USER_NAME() As WhereParameter 
			Get
				If _USER_NAME_W Is Nothing Then
					_USER_NAME_W = TearOff.USER_NAME
				End If
				Return _USER_NAME_W
			End Get
		End Property

		Public ReadOnly Property REPOSITORY_FILENAME() As WhereParameter 
			Get
				If _REPOSITORY_FILENAME_W Is Nothing Then
					_REPOSITORY_FILENAME_W = TearOff.REPOSITORY_FILENAME
				End If
				Return _REPOSITORY_FILENAME_W
			End Get
		End Property

		Private _JOB_NUMBER_W As WhereParameter = Nothing
		Private _JOB_COMPONENT_NUMBER_W As WhereParameter = Nothing
		Private _DOCUMENT_ID_W As WhereParameter = Nothing
		Private _FILENAME_W As WhereParameter = Nothing
		Private _MIME_TYPE_W As WhereParameter = Nothing
		Private _DESCRIPTION_W As WhereParameter = Nothing
		Private _KEYWORDS_W As WhereParameter = Nothing
		Private _UPLOADED_DATE_W As WhereParameter = Nothing
		Private _USER_CODE_W As WhereParameter = Nothing
		Private _FILE_SIZE_W As WhereParameter = Nothing
		Private _USER_NAME_W As WhereParameter = Nothing
		Private _REPOSITORY_FILENAME_W As WhereParameter = Nothing

		Public Sub WhereClauseReset()

		_JOB_NUMBER_W = Nothing
		_JOB_COMPONENT_NUMBER_W = Nothing
		_DOCUMENT_ID_W = Nothing
		_FILENAME_W = Nothing
		_MIME_TYPE_W = Nothing
		_DESCRIPTION_W = Nothing
		_KEYWORDS_W = Nothing
		_UPLOADED_DATE_W = Nothing
		_USER_CODE_W = Nothing
		_FILE_SIZE_W = Nothing
		_USER_NAME_W = Nothing
		_REPOSITORY_FILENAME_W = Nothing
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
		
	
		Public ReadOnly Property JOB_NUMBER() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.JOB_NUMBER, Parameters.JOB_NUMBER)
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

		Public ReadOnly Property DOCUMENT_ID() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.DOCUMENT_ID, Parameters.DOCUMENT_ID)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property FILENAME() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.FILENAME, Parameters.FILENAME)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property MIME_TYPE() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.MIME_TYPE, Parameters.MIME_TYPE)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property DESCRIPTION() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.DESCRIPTION, Parameters.DESCRIPTION)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property KEYWORDS() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.KEYWORDS, Parameters.KEYWORDS)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property UPLOADED_DATE() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.UPLOADED_DATE, Parameters.UPLOADED_DATE)
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

		Public ReadOnly Property FILE_SIZE() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.FILE_SIZE, Parameters.FILE_SIZE)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property USER_NAME() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.USER_NAME, Parameters.USER_NAME)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property

		Public ReadOnly Property REPOSITORY_FILENAME() As AggregateParameter
			Get
				Dim where As AggregateParameter = New AggregateParameter(ColumnNames.REPOSITORY_FILENAME, Parameters.REPOSITORY_FILENAME)
				Me._clause._entity.Query.AddAggregateParameter(where)
				Return where
			End Get
		End Property


			Private _clause as AggregateClause
		End Class
		#End Region	

		Public ReadOnly Property JOB_NUMBER() As AggregateParameter 
			Get
				If _JOB_NUMBER_W Is Nothing Then
					_JOB_NUMBER_W = TearOff.JOB_NUMBER
				End If
				Return _JOB_NUMBER_W
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

		Public ReadOnly Property DOCUMENT_ID() As AggregateParameter 
			Get
				If _DOCUMENT_ID_W Is Nothing Then
					_DOCUMENT_ID_W = TearOff.DOCUMENT_ID
				End If
				Return _DOCUMENT_ID_W
			End Get
		End Property

		Public ReadOnly Property FILENAME() As AggregateParameter 
			Get
				If _FILENAME_W Is Nothing Then
					_FILENAME_W = TearOff.FILENAME
				End If
				Return _FILENAME_W
			End Get
		End Property

		Public ReadOnly Property MIME_TYPE() As AggregateParameter 
			Get
				If _MIME_TYPE_W Is Nothing Then
					_MIME_TYPE_W = TearOff.MIME_TYPE
				End If
				Return _MIME_TYPE_W
			End Get
		End Property

		Public ReadOnly Property DESCRIPTION() As AggregateParameter 
			Get
				If _DESCRIPTION_W Is Nothing Then
					_DESCRIPTION_W = TearOff.DESCRIPTION
				End If
				Return _DESCRIPTION_W
			End Get
		End Property

		Public ReadOnly Property KEYWORDS() As AggregateParameter 
			Get
				If _KEYWORDS_W Is Nothing Then
					_KEYWORDS_W = TearOff.KEYWORDS
				End If
				Return _KEYWORDS_W
			End Get
		End Property

		Public ReadOnly Property UPLOADED_DATE() As AggregateParameter 
			Get
				If _UPLOADED_DATE_W Is Nothing Then
					_UPLOADED_DATE_W = TearOff.UPLOADED_DATE
				End If
				Return _UPLOADED_DATE_W
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

		Public ReadOnly Property FILE_SIZE() As AggregateParameter 
			Get
				If _FILE_SIZE_W Is Nothing Then
					_FILE_SIZE_W = TearOff.FILE_SIZE
				End If
				Return _FILE_SIZE_W
			End Get
		End Property

		Public ReadOnly Property USER_NAME() As AggregateParameter 
			Get
				If _USER_NAME_W Is Nothing Then
					_USER_NAME_W = TearOff.USER_NAME
				End If
				Return _USER_NAME_W
			End Get
		End Property

		Public ReadOnly Property REPOSITORY_FILENAME() As AggregateParameter 
			Get
				If _REPOSITORY_FILENAME_W Is Nothing Then
					_REPOSITORY_FILENAME_W = TearOff.REPOSITORY_FILENAME
				End If
				Return _REPOSITORY_FILENAME_W
			End Get
		End Property

		Private _JOB_NUMBER_W As AggregateParameter = Nothing
		Private _JOB_COMPONENT_NUMBER_W As AggregateParameter = Nothing
		Private _DOCUMENT_ID_W As AggregateParameter = Nothing
		Private _FILENAME_W As AggregateParameter = Nothing
		Private _MIME_TYPE_W As AggregateParameter = Nothing
		Private _DESCRIPTION_W As AggregateParameter = Nothing
		Private _KEYWORDS_W As AggregateParameter = Nothing
		Private _UPLOADED_DATE_W As AggregateParameter = Nothing
		Private _USER_CODE_W As AggregateParameter = Nothing
		Private _FILE_SIZE_W As AggregateParameter = Nothing
		Private _USER_NAME_W As AggregateParameter = Nothing
		Private _REPOSITORY_FILENAME_W As AggregateParameter = Nothing

		Public Sub AggregateClauseReset()

		_JOB_NUMBER_W = Nothing
		_JOB_COMPONENT_NUMBER_W = Nothing
		_DOCUMENT_ID_W = Nothing
		_FILENAME_W = Nothing
		_MIME_TYPE_W = Nothing
		_DESCRIPTION_W = Nothing
		_KEYWORDS_W = Nothing
		_UPLOADED_DATE_W = Nothing
		_USER_CODE_W = Nothing
		_FILE_SIZE_W = Nothing
		_USER_NAME_W = Nothing
		_REPOSITORY_FILENAME_W = Nothing
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

