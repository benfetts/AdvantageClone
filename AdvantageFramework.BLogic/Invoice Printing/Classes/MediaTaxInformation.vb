Namespace InvoicePrinting.Classes

	<Serializable()>
	Public Class MediaTaxInformation

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			FullInvoiceNumber
			TaxLabel
			TaxAmount
			EstimateTaxAmount
			PriorTaxAmount
			TTDTaxAmount
		End Enum

#End Region

#Region " Variables "

		Private _FullInvoiceNumber As String = Nothing
		Private _TaxLabel As String = Nothing
		Private _TaxAmountColumn3 As Nullable(Of Decimal) = Nothing
		Private _TaxAmountColumn4 As Nullable(Of Decimal) = Nothing
		Private _TaxAmountColumn5 As Nullable(Of Decimal) = Nothing
		Private _TaxAmountColumn6 As Nullable(Of Decimal) = Nothing
		Private _TaxAmountColumn7 As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

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
		Public Property TaxLabel() As String
			Get
				TaxLabel = _TaxLabel
			End Get
			Set(ByVal value As String)
				_TaxLabel = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TaxAmountColumn3() As Nullable(Of Decimal)
			Get
				TaxAmountColumn3 = _TaxAmountColumn3
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_TaxAmountColumn3 = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TaxAmountColumn4() As Nullable(Of Decimal)
			Get
				TaxAmountColumn4 = _TaxAmountColumn4
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_TaxAmountColumn4 = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TaxAmountColumn5() As Nullable(Of Decimal)
			Get
				TaxAmountColumn5 = _TaxAmountColumn5
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_TaxAmountColumn5 = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TaxAmountColumn6() As Nullable(Of Decimal)
			Get
				TaxAmountColumn6 = _TaxAmountColumn6
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_TaxAmountColumn6 = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TaxAmountColumn7() As Nullable(Of Decimal)
			Get
				TaxAmountColumn7 = _TaxAmountColumn7
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_TaxAmountColumn7 = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New(ByVal FullInvoiceNumber As String, TaxLabel As String, TaxAmountColumn3 As Nullable(Of Decimal), TaxAmountColumn4 As Nullable(Of Decimal),
					   TaxAmountColumn5 As Nullable(Of Decimal), TaxAmountColumn6 As Nullable(Of Decimal), TaxAmountColumn7 As Nullable(Of Decimal))

			_FullInvoiceNumber = FullInvoiceNumber
			_TaxLabel = TaxLabel
			_TaxAmountColumn3 = TaxAmountColumn3
			_TaxAmountColumn4 = TaxAmountColumn4
			_TaxAmountColumn5 = TaxAmountColumn5
			_TaxAmountColumn6 = TaxAmountColumn6
			_TaxAmountColumn7 = TaxAmountColumn7

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.FullInvoiceNumber.ToString

		End Function

#End Region

	End Class

End Namespace
