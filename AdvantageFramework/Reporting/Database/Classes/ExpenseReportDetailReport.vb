Namespace Reporting.Database.Classes

    <Serializable>
    Public Class ExpenseReportDetailReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            LineNumber
            ItemDate
            Description
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            FunctionCode
            FunctionDescription
            Quantity
            Rate
            Amount
            CreditCardFlag
            PaymentType
            NonBillable
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As Integer = Nothing
        Private _LineNumber As Integer = Nothing
        Private _ItemDate As Nullable(Of Date) = Nothing
        Private _Description As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _Quantity As Nullable(Of Integer) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _CreditCardFlag As Nullable(Of Boolean) = Nothing
        Private _PaymentType As Nullable(Of Short) = Nothing
        Private _NonBillable As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        Public Property InvoiceNumber() As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        Public Property LineNumber() As Integer
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Integer)
                _LineNumber = value
            End Set
        End Property
        Public Property ItemDate() As Nullable(Of Date)
            Get
                ItemDate = _ItemDate
            End Get
            Set(value As Nullable(Of Date))
                _ItemDate = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        Public Property Quantity() As Nullable(Of Integer)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Integer))
                _Quantity = value
            End Set
        End Property
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        Public Property CreditCardFlag() As Nullable(Of Boolean)
            Get
                CreditCardFlag = _CreditCardFlag
            End Get
            Set(value As Nullable(Of Boolean))
                _CreditCardFlag = value
            End Set
        End Property
        Public Property PaymentType() As Nullable(Of Short)
            Get
                PaymentType = _PaymentType
            End Get
            Set(value As Nullable(Of Short))
                _PaymentType = value
            End Set
        End Property
        Public Property NonBillable() As Nullable(Of Short)
            Get
                NonBillable = _NonBillable
            End Get
            Set(value As Nullable(Of Short))
                _NonBillable = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.InvoiceNumber.ToString

        End Function

#End Region

    End Class

End Namespace
