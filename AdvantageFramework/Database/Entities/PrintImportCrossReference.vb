Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.PRINT_IMPORT_XREF")>
    Public Class PrintImportCrossReference
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ImportOrderNumber
            OrderNumber
            ImportLineNumber
            LineNumber
            MediaType
            ImportedFrom
            LastRevisedDate
            LastUserCode
            ImportSequence
            ImportAdNumber
            ImportYear
            SalesClassCode
        End Enum

#End Region

#Region " Variables "

        Private _ImportOrderNumber As System.Nullable(Of Long) = 0
        Private _OrderNumber As System.Nullable(Of Long) = 0
        Private _ImportLineNumber As System.Nullable(Of Long) = 0
        Private _LineNumber As System.Nullable(Of Long) = 0
        Private _MediaType As String = ""
        Private _ImportedFrom As String = ""
        Private _LastRevisedDate As System.Nullable(Of DateTime) = "1/1/1900"
        Private _LastUserCode As String = ""
        Private _ImportSequence As System.Nullable(Of Long) = 0
        Private _ImportAdNumber As String = ""
        Private _ImportYear As System.Nullable(Of Long) = 0
        Private _SalesClassCode As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_ORDER_NBR", Storage:="_ImportOrderNumber", DBType:="int", IsPrimaryKey:=True), _
        System.ComponentModel.DisplayName("ImportOrderNumber")> _
        Public Property ImportOrderNumber() As System.Nullable(Of Long)
            Get
                ImportOrderNumber = _ImportOrderNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _ImportOrderNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ORDER_NBR", Storage:="_OrderNumber", DBType:="int", IsPrimaryKey:=True), _
        System.ComponentModel.DisplayName("OrderNumber")> _
        Public Property OrderNumber() As System.Nullable(Of Long)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _OrderNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_LINE_NBR", Storage:="_ImportLineNumber", DBType:="int", IsPrimaryKey:=True), _
        System.ComponentModel.DisplayName("ImportLineNumber")> _
        Public Property ImportLineNumber() As System.Nullable(Of Long)
            Get
                ImportLineNumber = _ImportLineNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _ImportLineNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LINE_NBR", Storage:="_LineNumber", DBType:="smallint", IsPrimaryKey:=True), _
        System.ComponentModel.DisplayName("LineNumber")> _
        Public Property LineNumber() As System.Nullable(Of Long)
            Get
                LineNumber = _LineNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _LineNumber = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MEDIA_TYPE", Storage:="_MediaType", DbType:="varchar", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("MediaType"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property MediaType() As String
			Get
				MediaType = _MediaType
			End Get
			Set(ByVal value As String)
				_MediaType = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORTED_FROM", Storage:="_ImportedFrom", DbType:="varchar", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("ImportedFrom"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property ImportedFrom() As String
			Get
				ImportedFrom = _ImportedFrom
			End Get
			Set(ByVal value As String)
				_ImportedFrom = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LAST_DATE_REVISED", Storage:="_LastRevisedDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("LastRevisedDate")>
		Public Property LastRevisedDate() As System.Nullable(Of DateTime)
			Get
				LastRevisedDate = _LastRevisedDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_LastRevisedDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LAST_USERID", Storage:="_LastUserCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("LastUserCode"),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property LastUserCode() As String
			Get
				LastUserCode = _LastUserCode
			End Get
			Set(ByVal value As String)
				_LastUserCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_SEQUENCE", Storage:="_ImportSequence", DbType:="int"),
		System.ComponentModel.DisplayName("ImportSequence")>
		Public Property ImportSequence() As System.Nullable(Of Long)
			Get
				ImportSequence = _ImportSequence
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ImportSequence = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_AD_NUMBER", Storage:="_ImportAdNumber", DbType:="varchar"),
		System.ComponentModel.DisplayName("ImportAdNumber"),
		System.ComponentModel.DataAnnotations.MaxLength(25)>
		Public Property ImportAdNumber() As String
			Get
				ImportAdNumber = _ImportAdNumber
			End Get
			Set(ByVal value As String)
				_ImportAdNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_YEAR", Storage:="_ImportYear", DbType:="smallint"),
		System.ComponentModel.DisplayName("ImportYear")>
		Public Property ImportYear() As System.Nullable(Of Long)
			Get
				ImportYear = _ImportYear
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ImportYear = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SALES_CLASS_CODE", Storage:="_SalesClassCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("SalesClassCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
