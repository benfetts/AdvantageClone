Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.SERVICE_FEE_INV")>
    Public Class ServiceFeeInvoice
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            IncomeOnlyID
            SequenceNumber
            InvoiceOnlyInvoiceNumber
            FeeReconciled
            CreatedDate
            CreatedBy
        End Enum

#End Region

#Region " Variables "

        Private _JobNumber As Long = 0
        Private _JobComponentNumber As Long = 0
        Private _IncomeOnlyID As Long = 0
        Private _SequenceNumber As System.Nullable(Of Long) = Nothing
        Private _InvoiceOnlyInvoiceNumber As String = ""
        Private _FeeReconciled As System.Nullable(Of Long) = Nothing
        Private _CreatedDate As System.Nullable(Of DateTime) = Nothing
        Private _CreatedBy As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_NUMBER", Storage:="_JobNumber", DBType:="int"), _
        System.ComponentModel.DisplayName("JobNumber")> _
        Public Property JobNumber() As Long
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Long)
                _JobNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_COMPONENT_NBR", Storage:="_JobComponentNumber", DBType:="smallint"), _
        System.ComponentModel.DisplayName("JobComponentNumber")> _
        Public Property JobComponentNumber() As Long
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Long)
                _JobComponentNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IO_ID", Storage:="_IncomeOnlyID", DBType:="int"), _
        System.ComponentModel.DisplayName("IncomeOnlyID")> _
        Public Property IncomeOnlyID() As Long
            Get
                IncomeOnlyID = _IncomeOnlyID
            End Get
            Set(ByVal value As Long)
                _IncomeOnlyID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SEQ_NBR", Storage:="_SequenceNumber", DBType:="smallint"), _
        System.ComponentModel.DisplayName("SequenceNumber")> _
        Public Property SequenceNumber() As System.Nullable(Of Long)
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _SequenceNumber = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IO_INV_NBR", Storage:="_InvoiceOnlyInvoiceNumber", DbType:="varchar"),
		System.ComponentModel.DisplayName("InvoiceOnlyInvoiceNumber"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property InvoiceOnlyInvoiceNumber() As String
			Get
				InvoiceOnlyInvoiceNumber = _InvoiceOnlyInvoiceNumber
			End Get
			Set(ByVal value As String)
				_InvoiceOnlyInvoiceNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FEE_RECONCILED", Storage:="_FeeReconciled", DbType:="smallint"),
		System.ComponentModel.DisplayName("FeeReconciled")>
		Public Property FeeReconciled() As System.Nullable(Of Long)
			Get
				FeeReconciled = _FeeReconciled
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_FeeReconciled = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE_CREATED", Storage:="_CreatedDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("CreatedDate")>
		Public Property CreatedDate() As System.Nullable(Of DateTime)
			Get
				CreatedDate = _CreatedDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_CreatedDate = value
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

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
