Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class InvoiceFunctionDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Type
            Item
            ItemDate
            Quantity
            Hours
            Rate
            NetAmount
            CommissionAmount
            NonResaleTax
            CityTax
            CountyTax
            StateTax
            TotalTax
            TotalAmount
            Comment
        End Enum

#End Region

#Region " Variables "

        Private _Type As String = Nothing
        Private _Item As String = Nothing
        Private _ItemDate As Nullable(Of Date) = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _NetAmount As Nullable(Of Decimal) = Nothing
        Private _CommissionAmount As Nullable(Of Decimal) = Nothing
        Private _NonResaleTax As Nullable(Of Decimal) = Nothing
        Private _CityTax As Nullable(Of Decimal) = Nothing
        Private _CountyTax As Nullable(Of Decimal) = Nothing
        Private _StateTax As Nullable(Of Decimal) = Nothing
        Private _TotalTax As Nullable(Of Decimal) = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _Comment As String = Nothing

#End Region

#Region " Properties "

		Public Property FunctionType As String
		<System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(ByVal value As String)
                _Type = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Item() As String
            Get
                Item = _Item
            End Get
            Set(ByVal value As String)
                _Item = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ItemDate() As Nullable(Of Date)
            Get
                ItemDate = _ItemDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ItemDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionAmount() As Nullable(Of Decimal)
            Get
                CommissionAmount = _CommissionAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CommissionAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonResaleTax() As Nullable(Of Decimal)
            Get
                NonResaleTax = _NonResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTax() As Nullable(Of Decimal)
            Get
                CityTax = _CityTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CityTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTax() As Nullable(Of Decimal)
            Get
                CountyTax = _CountyTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CountyTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTax() As Nullable(Of Decimal)
            Get
                StateTax = _StateTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StateTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalTax() As Nullable(Of Decimal)
            Get
                TotalTax = _TotalTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalTax = value
            End Set
        End Property
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
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Item

        End Function

#End Region

    End Class

End Namespace
