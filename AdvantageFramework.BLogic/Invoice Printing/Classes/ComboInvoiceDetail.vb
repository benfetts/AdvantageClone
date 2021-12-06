Namespace InvoicePrinting.Classes

	<Serializable()>
	Public Class ComboInvoiceDetail

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			InvoiceNumber
			InvoiceSequenceNumber
			InvoiceDate
			InvoiceType
            FullInvoiceNumber
            MediaType
            ClientCode
			DivisionCode
			ProductCode
			BillingComment
			InvoiceDueDate
			ClientPO
			SalesClassCode
			SalesClassDescription
			Address
			InvoiceCategory
			InvoiceFooterComment
            InvoiceFooterCommentFontSize
            TotalAmount
            ClientReference
            AccountExecutive
            Campaign
            VATNumber
        End Enum

#End Region

#Region " Variables "

		Private _InvoiceNumber As Nullable(Of Integer) = Nothing
		Private _InvoiceSequenceNumber As Nullable(Of Short) = Nothing
		Private _InvoiceDate As Nullable(Of Date) = Nothing
		Private _InvoiceType As String = Nothing
        Private _FullInvoiceNumber As String = Nothing
        Private _MediaType As String = Nothing
        Private _ClientCode As String = Nothing
		Private _DivisionCode As String = Nothing
		Private _ProductCode As String = Nothing
		Private _BillingComment As String = Nothing
		Private _InvoiceDueDate As Nullable(Of Date) = Nothing
		Private _ClientPO As String = Nothing
		Private _SalesClassCode As String = Nothing
		Private _SalesClassDescription As String = Nothing
		Private _Address As String = Nothing
		Private _InvoiceCategory As String = Nothing
		Private _InvoiceFooterComment As String = Nothing
        Private _InvoiceFooterCommentFontSize As Integer = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
		Public Property InvoiceNumber() As Nullable(Of Integer)
			Get
				InvoiceNumber = _InvoiceNumber
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_InvoiceNumber = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property InvoiceSequenceNumber() As Nullable(Of Short)
			Get
				InvoiceSequenceNumber = _InvoiceSequenceNumber
			End Get
			Set(ByVal value As Nullable(Of Short))
				_InvoiceSequenceNumber = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property InvoiceDate() As Nullable(Of Date)
			Get
				InvoiceDate = _InvoiceDate
			End Get
			Set(ByVal value As Nullable(Of Date))
				_InvoiceDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property InvoiceType() As String
			Get
				InvoiceType = _InvoiceType
			End Get
			Set(ByVal value As String)
				_InvoiceType = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FullInvoiceNumber() As String
            Get
                FullInvoiceNumber = _FullInvoiceNumber
            End Get
            Set(ByVal value As String)
                _FullInvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(ByVal value As String)
                _MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
		Public Property ClientCode() As String
			Get
				ClientCode = _ClientCode
			End Get
			Set(ByVal value As String)
				_ClientCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
			Set(ByVal value As String)
				_DivisionCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property ProductCode() As String
			Get
				ProductCode = _ProductCode
			End Get
			Set(ByVal value As String)
				_ProductCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property BillingComment() As String
			Get
				BillingComment = _BillingComment
			End Get
			Set(ByVal value As String)
				_BillingComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property InvoiceDueDate() As Nullable(Of Date)
			Get
				InvoiceDueDate = _InvoiceDueDate
			End Get
			Set(ByVal value As Nullable(Of Date))
				_InvoiceDueDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property ClientPO() As String
			Get
				ClientPO = _ClientPO
			End Get
			Set(ByVal value As String)
				_ClientPO = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property SalesClassCode() As String
			Get
				SalesClassCode = _SalesClassCode
			End Get
			Set(ByVal value As String)
				_SalesClassCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property SalesClassDescription() As String
			Get
				SalesClassDescription = _SalesClassDescription
			End Get
			Set(ByVal value As String)
				_SalesClassDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property Address() As String
			Get
				Address = _Address
			End Get
			Set(ByVal value As String)
				_Address = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property InvoiceCategory() As String
			Get
				InvoiceCategory = _InvoiceCategory
			End Get
			Set(ByVal value As String)
				_InvoiceCategory = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property InvoiceFooterComment() As String
			Get
				InvoiceFooterComment = _InvoiceFooterComment
			End Get
			Set(ByVal value As String)
				_InvoiceFooterComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property InvoiceFooterCommentFontSize() As Integer
			Get
				InvoiceFooterCommentFontSize = _InvoiceFooterCommentFontSize
			End Get
			Set(ByVal value As Integer)
				_InvoiceFooterCommentFontSize = value
			End Set
		End Property
        Public Property SortOrder As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalAmount() As Nullable(Of Decimal)
            Get
                TotalAmount = _TotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientReference() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountExecutive() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Campaign() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VATNumber() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

			ToString = Me.InvoiceNumber.ToString

		End Function

#End Region

	End Class

End Namespace
